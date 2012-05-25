using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using FileSystems;
using FileSystems.Udf;
using Helper.IO;
using Scsi;
using Scsi.Multimedia;

namespace BurnApp
{
    public class BackgroundBurner : BackgroundWorker
    {
        private SaveFileDialog sfdSaveDuplicatesLog;
        private int lastProgressReportTick;
        private MasterStage lastMasterStage = MasterStage.None;
        private BurnStage lastBurnStage = BurnStage.None;
        private IntPtr hOwner;

        public BackgroundBurner(Control owner)
            : base()
        {
            owner.HandleCreated += (s, e) => { this.hOwner = owner.Handle; };
            this.InitializeComponent();
            this.Owner = owner;
            this.WorkerReportsProgress = true;
            this.WorkerSupportsCancellation = true;
        }

        private void InitializeComponent()
        {
            this.sfdSaveDuplicatesLog = new System.Windows.Forms.SaveFileDialog();
            // 
            // sfdSaveDuplicatesLog
            // 
            this.sfdSaveDuplicatesLog.DefaultExt = "txt";
            this.sfdSaveDuplicatesLog.Filter = "Text files (*.txt)|*.txt|All files|*";
            this.sfdSaveDuplicatesLog.SupportMultiDottedExtensions = true;
            this.sfdSaveDuplicatesLog.Title = "Save Log of Duplicate Files";

        }

        private bool Blank(DoWorkEventArgs e, bool userRequested, MultimediaDevice device)
        {
            var discInfo = device.ReadDiscInformation();
            if (discInfo.Erasable && discInfo.DiscStatus != DiscStatus.Empty)
            {
                if (CanBlank(device.CurrentProfile))
                {
                    BlankCommand command;
                    DialogResult result;
                    if (!userRequested)
                    {
                        if (discInfo.DiscStatus == DiscStatus.Finalized | discInfo.DiscStatus == DiscStatus.Other)
                        {
                            result = (DialogResult)this.Owner.Invoke((Converter<string, DialogResult>)(msg => MessageBox.Show(msg, "Erase Disc", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)), "Detected an erasable finalized disc." + Environment.NewLine + "You cannot write to this disc unless you erase it." + Environment.NewLine + "Would you like to erase the disc?");
                            command = new BlankCommand(BlankingType.BlankMinimal, true, 0);
                        }
                        else
                        {
                            result = DialogResult.No;
                            command = null;
                        }
                    }
                    else
                    {
                        using (var form = new FormBlank())
                        {
                            form.MaximumStartLBA = (decimal)discInfo.LastPossibleStartTimeForLeadOut;
                            form.MaximumTrackNumber = discInfo.LastTrackNumberInLastSession;
                            result = (DialogResult)this.Owner.Invoke((Converter<IWin32Window, DialogResult>)form.ShowDialog, this.Owner);
                            command = form.BlankCommand;
                        }
                    }
                    if (result == DialogResult.Cancel) { return false; }
                    if (result == DialogResult.Yes | result == DialogResult.OK)
                    {
                        device.Blank(command);

                        int prevTick = Environment.TickCount;

                        //Get the progress
                        SenseData sense;
                        while ((sense = device.RequestSense()).SenseKey == SenseKey.NotReady && sense.AdditionalSenseCode == AdditionalSenseCode.LogicalUnitNotReady && sense.AdditionalSenseCodeQualifier == (AdditionalSenseCodeQualifier)7)
                        {
                            int tick = Environment.TickCount;
                            if (tick - prevTick >= Program.SLOW_UPDATE_PAUSE_MILLIS)
                            {
                                this.ReportProgress(new ProgressInfo(BurnStage.Blanking, MasterStage.None, sense.SenseKeySpecific.ProgressIndication.ProgressIndication, ProgressIndicationBytes.ProgressIndicationDenominator, "Erasing disc", "(cannot be canceled)", string.Empty), false);
                                prevTick = tick;
                            }
                            else { Thread.Sleep(Program.SLOW_UPDATE_PAUSE_MILLIS); }
                        }

                        this.ReportProgress(new ProgressInfo(BurnStage.Blanking, MasterStage.None, ProgressIndicationBytes.ProgressIndicationDenominator, ProgressIndicationBytes.ProgressIndicationDenominator, "Disc erased.", null, string.Empty), false);
                    }
                }
                else
                {
                    if ((DialogResult)this.Owner.Invoke((Converter<IWin32Window, DialogResult>)(window => MessageBox.Show(window, "Would you like to erase the disc? Any data on it will become inaccessible.", "Erase Disc", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)), this.Owner) == DialogResult.OK)
                    {
                        int total = 16 + (256 - 16) + 1 + 1 + 1;
                        int current = 0;
                        try
                        {
                            //Forcing the buffer to flush every time (like I do here) actually makes everything a LOT slower
                            //But I'd rather make the user see the progress go smoothly instead of seeing a sudden (although fast) jump and a slight pause.

                            var rw = device.GetConfiguration<RandomWritableFeature>();
                            ushort blockingFactor = rw != null && rw.Current ? Math.Max((ushort)1, rw.Blocking) : (ushort)16;

                            //Erase sectors 0 to 15 a few blocks at a time
                            for (uint i = 0; i < 16; i += blockingFactor)
                            {
                                if (this.CancellationPending) { e.Cancel = true; break; }
                                this.ReportProgress(new ProgressInfo(BurnStage.Blanking, MasterStage.None, current, total, "Erasing sectors", "Boot Structures (LBAs 0-15)", string.Empty), true);
                                device.Write(false, i, Math.Min(blockingFactor, 16 - i), new byte[device.BlockSize * Math.Min(blockingFactor, 16 - i)], 0);
                                current += blockingFactor;
                            }

                            //Erase sectors 16 to 255 a few blocks at a time
                            for (uint i = 16; i < 256; i += blockingFactor)
                            {
                                if (this.CancellationPending) { e.Cancel = true; break; }
                                this.ReportProgress(new ProgressInfo(BurnStage.Blanking, MasterStage.None, current, total, "Erasing sectors", "Volume Recognition Sequence (LBAs 16-255)", string.Empty), true);
                                device.Write(false, i, Math.Min(blockingFactor, 256 - i), new byte[device.BlockSize * Math.Min(blockingFactor, 256 - i)], 0);
                                current += blockingFactor;
                            }

                            if (!this.CancellationPending)
                            {
                                this.ReportProgress(new ProgressInfo(BurnStage.Blanking, MasterStage.None, current, total, "Erasing sectors", "Anchor Volume Decriptor Pointer (LBA 256)", string.Empty), true);
                                device.Write(false, 256, 1, new byte[device.BlockSize], 0);
                                current += 1;
                            }
                            else { e.Cancel = true; }

                            uint blockCount = (uint)(((ulong)device.Capacity - 1) / device.BlockSize);
                            if (!this.CancellationPending)
                            {
                                this.ReportProgress(new ProgressInfo(BurnStage.Blanking, MasterStage.None, current, total, "Erasing sectors", string.Format("Anchor Volume Descriptor Pointer (LBA {0:N0})", blockCount - 1 - 256), string.Empty), true);
                                device.Write(false, blockCount - 1 - 256, 1, new byte[device.BlockSize], 0);
                                current += 1;
                            }
                            else { e.Cancel = true; }

                            if (!this.CancellationPending)
                            {
                                this.ReportProgress(new ProgressInfo(BurnStage.Blanking, MasterStage.None, current, total, "Erasing sectors", string.Format("Anchor Volume Descriptor Pointer or Virtual Allocation Table (LBA {0:N0})", blockCount - 1), string.Empty), true);
                                device.Write(false, blockCount - 1, 1, new byte[device.BlockSize], 0);
                                current += 1;
                            }
                            else { e.Cancel = true; }
                        }
                        finally
                        {
                            this.ReportProgress(new ProgressInfo(BurnStage.Blanking, MasterStage.None, current, total, "Flushing buffer", null, string.Empty), true);
                            device.SynchronizeCache();
                            device.Seek10(new Seek10Command(0)); //It just makes the drive sound better, since it's spinning faster (higher angular velocity)
                        }

                        this.ReportProgress(new ProgressInfo(BurnStage.Blanking, MasterStage.None, total, total, "Finished erasing disc structures.", null, string.Empty), true);
                    }
                }
            }
            return true;
        }

        private static CDMainChannelDataForm GetCDMainChannelDataFormFromBlockType(DataBlockType dataBlockType)
        {
            switch (dataBlockType)
            {
                case DataBlockType.Mode1:
                    return CDMainChannelDataForm.CdromMode1HostData2048;
                case DataBlockType.Mode2:
                    return CDMainChannelDataForm.CdromMode2HostData2336;
                case DataBlockType.Mode2XAForm1:
                    return CDMainChannelDataForm.CdromMode2HostData2336;
                case DataBlockType.Mode2XAForm2:
                    return CDMainChannelDataForm.CdromMode2HostData2336;
                case DataBlockType.Raw2352WithRawPWSubchannel96:
                case DataBlockType.Raw2352WithPQSubchannel16:
                case DataBlockType.Raw2352WithPWSubchannel96:
                case DataBlockType.Mode2XAForm1WithSubHeader:
                case DataBlockType.Mode2XAMixed:
                case DataBlockType.Raw2352:
                default:
                    throw new ArgumentOutOfRangeException("dataBlockType", dataBlockType, "Data block type not supported.");
            }
        }

        private static bool CanBlank(MultimediaProfile type) { return type == MultimediaProfile.CDRW | type == MultimediaProfile.DvdMinusRWDualLayer | type == MultimediaProfile.DvdMinusRWRestrictedOverwrite | type == MultimediaProfile.DvdMinusRWSequentialRecording; }

        protected override void OnDoWork(DoWorkEventArgs e)
        {
            this.lastBurnStage = BurnStage.None;
            this.lastMasterStage = MasterStage.None;
            this.lastProgressReportTick = 0;
            //The actual burning occurs here, asynchronously from the UI
            var info = (DoWorkInfo)e.Argument;

            try
            {
                if (info.TargetDevice != null)
                {
                LOCK_DRIVE:
                    this.ReportProgress(new ProgressInfo(BurnStage.Locking, MasterStage.None, 0, 1, "Locking volume", null, string.Empty), false);
                    try { info.TargetDevice.Interface.LockVolume(); }
                    catch
                    {
                        DialogResult dr = (DialogResult)this.Owner.Invoke((Converter<object, DialogResult>)(s => { return MessageBox.Show(this.Owner, "Could not lock the drive. Please close any programs that are using the drive." + Environment.NewLine + "Would you like to force the volume to dismount?" + Environment.NewLine + "Press Yes to force the volume to dismount (dangerous), No to continue anyway (also dangerous), or Cancel to stop the burn.", "Error Locking Volume", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button3); }), new object[] { null });
                        if (dr == DialogResult.Yes) { info.TargetDevice.Interface.DismountVolume(); goto LOCK_DRIVE; }
                        else if (dr != DialogResult.No)
                        {
                            e.Cancel = true;
                            return;
                        }
                    }
                }
                try
                {
                    if (info.TargetDevice != null)
                    {
                        if (info.TargetDevice.Interface.IsVolumeMounted())
                        {
                            this.ReportProgress(new ProgressInfo(BurnStage.Dismounting, MasterStage.None, 0, 1, "Dismounting volume", null, string.Empty), false);
                            info.TargetDevice.Interface.DismountVolume();
                        }
                    }
                    ushort trackNumber;

                    if (info.TargetDevice != null)
                    {
                        this.ReportProgress(new ProgressInfo(BurnStage.FlushingDrive, MasterStage.None, 0, 1, "Flushing any intermediate data in the cache", null, string.Empty), false);
                        info.TargetDevice.SynchronizeCache();

                        this.ReportProgress(new ProgressInfo(BurnStage.Blanking, MasterStage.None, 0, 1, info.Type == BurnType.Erase ? "Erasing disc" : "Checking if disc needs to be erased", null, string.Empty), false);
                        if (info.Type == BurnType.Erase || CanBlank(info.TargetDevice.CurrentProfile))
                        {
                            if (!this.Blank(e, info.Type == BurnType.Erase, info.TargetDevice))
                            {
                                e.Cancel = true;
                                return;
                            }
                        }

                        if (info.Type != BurnType.Erase)
                        {
                            trackNumber = (ushort)(info.TargetDevice.FirstTrackNumber + info.TargetDevice.TrackCount - 1); //Last track

                            if (info.SetCDSpeed != null)
                            {
                                this.ReportProgress(new ProgressInfo(BurnStage.SettingParameters, MasterStage.None, 0, 1, info.SetCDSpeed.LogicalUnitWriteSpeed == ushort.MaxValue ? "Setting maximum write speed" : string.Format("Setting write speed to {0:N0} KB/s ({1:N0} KiB/s)", info.SetCDSpeed.LogicalUnitWriteSpeed, 1000 * (long)info.SetCDSpeed.LogicalUnitWriteSpeed / 1024), null, string.Empty), false);
                                info.TargetDevice.SetCDSpeed(info.SetCDSpeed);
                            }
                        }
                        else { trackNumber = 0; }
                    }
                    else { trackNumber = 0; }


                    if (info.Type == BurnType.Burn)
                    {
                        int blockSize = Program.BLOCK_SIZE;
                        using (var target = info.TargetDevice == null
                            ? info.TargetImage.Open(FileMode.Create, FileAccess.ReadWrite, FileShare.Read, FileOptions.SequentialScan, false)
                            : info.TargetDevice.OpenTrack(trackNumber))
                        {
                            //Do NOT change target.Position yet -- it's set to the Next Writable Address, which we need
                            Stream source;
                            long freeSpace;
                            uint trackStartSector;
                            if (info.TargetDevice != null)
                            {
                                var ti = info.TargetDevice.ReadTrackInformation(new ReadTrackInformationCommand(false, TrackIdentificationType.LogicalTrackNumber, trackNumber));
                                trackStartSector = ti.LogicalTrackStartAddress;
                                freeSpace = (long)ti.FreeBlocks * (long)info.TargetDevice.BlockSize;
                            }
                            else { trackStartSector = 0; freeSpace = -1; }

                            var master = info.Source as UdfMaster;
                            if (master != null)
                            {
                                master.TrackStartSector = trackStartSector;
                                master.BuildProgress += (s, ea) =>
                                {
                                    int tick = Environment.TickCount;
                                    if (this.lastMasterStage != ea.Stage || tick - this.lastProgressReportTick >= Program.SLOW_UPDATE_PAUSE_MILLIS - 1)
                                    {
                                        this.ReportProgress(new ProgressInfo(BurnStage.Burning, ea.Stage, Math.Min(ea.Completed, ea.Total), ea.Total, ea.Description, ea.ExtraInformation, ea.ProgressUnits), false);
                                        if (this.CancellationPending) { ea.Cancel = true; }
                                        this.lastProgressReportTick = tick;
                                        this.lastMasterStage = ea.Stage;
                                    }
                                };
                            }
                            source = info.Source.Open(FileMode.Open, FileAccess.Read, FileShare.Read, FileOptions.SequentialScan, false);
                            if (master != null) { this.SaveDuplicatesLog(master.DuplicateFilesFound); }

                            if (!this.CancellationPending)
                            {
                                using (source)
                                {
                                    //IMPORTANT: Do NOT change target's position! It's set to the next writable address!

                                    long trackStartOffset = trackStartSector * blockSize;

                                    //Do NOT reserve track -- if the user cancels, the track must be padded anyway and canceling will be useless

                                    try { target.SetLength(target.Position + (source.Length - trackStartOffset)); }
                                    catch (Exception ex)
                                    {
                                        if (ex is IOException || ex is ArgumentException || ex is InvalidOperationException || ex is EndOfStreamException)
                                        { throw new IOException(string.Format("Insufficient space: {0:N0} bytes required on the disc.", source.Length - trackStartOffset), ex); }
                                        throw;
                                    }

                                    Debug.Assert(target.Length - target.Position >= source.Length - trackStartOffset, "Failed to set the length of the stream.");

                                    if (info.TargetDevice != null)
                                    {
                                        var wp = info.TargetDevice.GetWriteParameters(new ModeSense10Command(PageControl.CurrentValues));
                                        if (wp.WriteType == WriteType.SessionAtOnce)
                                        {
                                            this.ReportProgress(new ProgressInfo(BurnStage.Burning, MasterStage.None, 0, (source.Length - trackStartOffset), "Writing lead-in", null, string.Empty), false);
                                            SendCueSheet(info.TargetDevice, trackNumber, wp, (source.Length - trackStartOffset));
                                        }
                                    }

                                    if (!this.CancellationPending)
                                    {
                                        //Now do the actual writing
                                        this.Write(source, info.TargetDevice, target, trackStartOffset, blockSize, info.BufferSize);
                                    }
                                }
                            }
                            else { e.Cancel = true; }
                        }


                        if (info.TargetDevice != null)
                        {
                            this.ReportProgress(new ProgressInfo(BurnStage.Closing, MasterStage.None, 0, ProgressIndicationBytes.ProgressIndicationDenominator, "Closing track/session", null, string.Empty), false);
                            info.TargetDevice.CloseTrackOrSession(new CloseSessionTrackCommand(true, TrackSessionCloseFunction.CloseSessionOrStopBGFormat, trackNumber));

                            int prevTick = Environment.TickCount;
                            //Get the progress
                            SenseData sense;
                            while ((sense = info.TargetDevice.RequestSense()).SenseKey == SenseKey.NotReady && sense.AdditionalSenseCode == AdditionalSenseCode.LogicalUnitNotReady && sense.AdditionalSenseCodeQualifier == (AdditionalSenseCodeQualifier)7)
                            {
                                int tick = Environment.TickCount;
                                if (tick - prevTick >= Program.SLOW_UPDATE_PAUSE_MILLIS)
                                {
                                    this.ReportProgress(new ProgressInfo(BurnStage.Closing, MasterStage.None, sense.SenseKeySpecific.ProgressIndication.ProgressIndication, ProgressIndicationBytes.ProgressIndicationDenominator, "Closing session", "(cannot be canceled)", string.Empty), false);
                                    prevTick = tick;
                                }
                                else { Thread.Sleep(Program.SLOW_UPDATE_PAUSE_MILLIS); }
                            }
                            this.ReportProgress(new ProgressInfo(BurnStage.Closing, MasterStage.None, ProgressIndicationBytes.ProgressIndicationDenominator, ProgressIndicationBytes.ProgressIndicationDenominator, "Session closed.", null, string.Empty), false);
                        }
                    }

                    e.Result = e.Argument;
                }
                finally
                {
                    if (info.TargetDevice != null)
                    {
                        if (info.TargetDevice.Interface.IsVolumeMounted())
                        {
                            this.ReportProgress(new ProgressInfo(BurnStage.Dismounting, MasterStage.None, 1, 1, "Dismounting volume", null, string.Empty), false);
                            info.TargetDevice.Interface.DismountVolume();
                        }
                        this.ReportProgress(new ProgressInfo(BurnStage.Unlocking, MasterStage.None, 1, 1, "Unlocking volume", null, string.Empty), false);
                        info.TargetDevice.Interface.UnlockVolume();
                    }
                }
                e.Cancel = this.CancellationPending;
                base.OnDoWork(e);
            }
            finally { if (info.TargetDevice != null) { info.TargetDevice.Dispose(); } }
        }

        protected Control Owner { get; private set; }

        private void SaveDuplicatesLog(IDictionary<IStreamSource, List<IStreamSource>> duplicateFiles)
        {
            if (duplicateFiles.Count > 0)
            {
                var dr = (DialogResult)this.Owner.Invoke((Converter<object, DialogResult>)(o => MessageBox.Show(this.Owner, string.Format("{0:N0} duplicate sets of files found. Would you like to save a log of these files?", duplicateFiles.Count), "Duplicate Files", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)), new object[] { null });
                if (dr == DialogResult.Yes)
                {
                    dr = (DialogResult)this.Owner.Invoke((Converter<object, DialogResult>)(o => this.sfdSaveDuplicatesLog.ShowDialog(this.Owner)), new object[] { null });
                    if (dr == DialogResult.OK)
                    {
                        using (var sw = new StreamWriter(this.sfdSaveDuplicatesLog.FileName))
                        {
                            foreach (var item in duplicateFiles)
                            {
                                sw.WriteLine("Files identical to '{0}' ({1:N0} bytes):", item.Key, item.Key.GetLength());
                                foreach (var dupItem in item.Value)
                                {
                                    if (dupItem != item.Key)
                                    { sw.WriteLine("- {0} ({1:N0} bytes)", dupItem, dupItem.GetLength()); }
                                }
                                sw.WriteLine();
                            }
                        }
                    }
                }
            }

        }

        private static void SendCueSheet(MultimediaDevice multimediaDevice, int trackNumber, WriteParametersPage writeParameters, long length)
        {
            if (writeParameters.WriteType == WriteType.SessionAtOnce && writeParameters.DataBlockType != DataBlockType.Mode1)
            { throw new NotSupportedException("Session-at-once mode currently only supports Mode 1 data blocks."); }
            var mastering = multimediaDevice.GetConfiguration<CDMasteringFeature>();
            if (mastering != null && mastering.SessionAtOnce && mastering.Current)
            {
                var leadInStartTime = (Msf)0x00;
                var sectorSize = MultimediaDevice.GetBlockSize(writeParameters.DataBlockType);
                multimediaDevice.SendCueSheet(new SendCueSheetCommand(), new CueLine[]
				{
					new CueLine(CDControl.DataTrack, CDAddress.StartTime, 0, 0, CDSubChannelDataForm.GenerateZeroData, writeParameters.DataBlockType == DataBlockType.Mode1 ? CDMainChannelDataForm.CdromMode1GeneratedData0 : CDMainChannelDataForm.CdromXAHostData2336, false, Msf.Zero),
					new CueLine(CDControl.DataTrack, CDAddress.StartTime, (byte)trackNumber, 0, CDSubChannelDataForm.GenerateZeroData, GetCDMainChannelDataFormFromBlockType(writeParameters.DataBlockType), false, Msf.Zero),
					new CueLine(CDControl.DataTrack, CDAddress.StartTime, (byte)trackNumber, 1, CDSubChannelDataForm.GenerateZeroData, GetCDMainChannelDataFormFromBlockType(writeParameters.DataBlockType), false, leadInStartTime),
					new CueLine(CDControl.DataTrack, CDAddress.StartTime, 0xAA, 1, CDSubChannelDataForm.GenerateZeroData, writeParameters.DataBlockType == DataBlockType.Mode1 ? CDMainChannelDataForm.CdromMode1GeneratedData0 : CDMainChannelDataForm.CdromXAHostData2336, false, (Msf)((int)leadInStartTime + (int)(1 + (length - 1) / sectorSize) + 2)),
				});
                var bytes = new byte[(leadInStartTime - Msf.Zero) * sectorSize];
            //Basically a loop saying "while we can't write, try writing again..."
            TRY_WRITE:
                try { multimediaDevice.Write(false, (uint)Msf.Zero, (uint)bytes.Length / sectorSize, bytes, 0); }
                catch (Exception ex)
                {
                    var asScsi = ex as ScsiException;
                    if (ex is IOException) { asScsi = ex.InnerException as ScsiException; }
                    if (asScsi != null && asScsi.SenseData.AdditionalSenseCodeAndQualifier == AdditionalSenseInformation.LogicalUnitNotReady_LongWriteInProgress)
                    {
                        Thread.Sleep(10);
                        goto TRY_WRITE;
                    }
                    else { throw; }
                }
            }
        }

        private void Write(Stream source, MultimediaDevice device, Stream target, long trackOffset, int blockSize, int bufferSize)
        {
            //IMPORTANT: While the write thread is running, do NOT tough the target stream or query its length (even for progress)!

            var pi = new ProgressInfo(BurnStage.Burning, MasterStage.Writing, 0, source.Length - trackOffset, "Burning", null, "Bytes");
            var dataBuffer = new byte[blockSize * (device != null ? device.MaxBlockTransferCount : 16)];
            bufferSize = bufferSize / dataBuffer.Length * dataBuffer.Length;
            if (bufferSize <= 0) { throw new InvalidOperationException("Buffer size must be positive and a multiple of the blocking size."); }

            using (var ring = new RingBuffer(bufferSize, Program.POLL_MILLIS, Program.POLL_SPIN))
            {
                long newPosition = trackOffset;
                if (newPosition != source.Position) { source.Position = newPosition; }
                //if (0 != target.Position) { target.Position = 0; }

                var async = new AsyncBufferThread(target, ring, dataBuffer.Length, new ProgressInfo(BurnStage.Burning, MasterStage.Writing, target.Position, source.Length - trackOffset, pi.Description, pi.State, pi.ProgressUnits));
                var writeThread = new Thread(async.ThreadStart)
                {
                    Name = "Buffered Transfer Thread",
                    IsBackground = true,
                    Priority = ThreadPriority.Highest,
                };
                pi.Total = source.Length - trackOffset;
                try
                {
                    while (source.Position < source.Length)
                    {
                        pi.Completed = async.AsyncProgressInfo.Completed;
                        pi.DriveBufferCapacity = async.AsyncProgressInfo.DriveBufferCapacity;
                        pi.State = source is AllocatedStream ? ((AllocatedStream)source).CurrentSource : (object)string.Empty;
                        pi.ProgramBufferCapacity = new KeyValuePair<long, long>(ring.Length, ring.Capacity);
                        //These above should technically be volatile, but reporting slightly out-of-date information doesn't hurt here

                        pi.Description = "Writing data";
                        if (pi.State == null) { pi.State = "(filling empty space)"; }
                        this.ReportProgress(pi, false);
                        if (this.CancellationPending) { break; }

                        int read = source.Read(dataBuffer, 0, dataBuffer.Length);
                        if (read < dataBuffer.Length)
                        {
                            if (source.Position < source.Length)
                            { throw new InvalidOperationException("Read fewer bytes than expected."); }
                        }

                        if ((writeThread.ThreadState & System.Threading.ThreadState.Unstarted) != 0 && ring.Length + read >= ring.Capacity)
                        { writeThread.Start(); }

                        ring.Write(dataBuffer, 0, read);
                    }
                    if ((writeThread.ThreadState & System.Threading.ThreadState.Unstarted) != 0) { writeThread.Start(); }
                    pi.BurnStage = BurnStage.FlushingBuffer;
                    while (!writeThread.Join(Program.SLOW_UPDATE_PAUSE_MILLIS))
                    {
                        long ringLen = ring.Length;
                        pi.Completed = async.AsyncProgressInfo.Completed;
                        pi.DriveBufferCapacity = async.AsyncProgressInfo.DriveBufferCapacity;
                        pi.State = "(flushing buffer)";
                        pi.ProgramBufferCapacity = new KeyValuePair<long, long>(ringLen, ring.Capacity);
                        this.ReportProgress(pi, false);
                        if (this.CancellationPending)
                        {
                            async.Stop();
                            //writeThread.Interrupt();
                        }
                        ring.EndWrite();
                    }
                }
                finally
                {
                    async.Stop();
                    writeThread.Join();
                    this.ReportProgress(new ProgressInfo(BurnStage.LeadOut, MasterStage.None, 0, 1, "Flushing and writing lead-out", null, string.Empty), false);
                    target.Flush();
                    target.Seek(0, SeekOrigin.Begin);
                }
            }
        }

        private void ReportProgress(ProgressInfo ea, bool force)
        {
            int tick = Environment.TickCount;
            if (force || this.lastMasterStage != ea.MasterStage || this.lastBurnStage != ea.BurnStage || tick - this.lastProgressReportTick >= Program.SLOW_UPDATE_PAUSE_MILLIS - 1)
            {
                this.ReportProgress((int)(100 * ea.Completed / ea.Total), ea);
                this.lastProgressReportTick = tick;
                this.lastMasterStage = ea.MasterStage;
                this.lastBurnStage = ea.BurnStage;
            }
        }

        private class AsyncBufferThread
        {
            private byte[] buf;
            private RingBuffer ring;
            private Stream target;
            private volatile bool stop = false;
            public ProgressInfo AsyncProgressInfo;

            public AsyncBufferThread(Stream target, RingBuffer ring, int bufferSize, ProgressInfo progressInfo)
            {
                this.target = target;
                this.ring = ring;
                this.buf = new byte[bufferSize];
                this.AsyncProgressInfo = progressInfo;
            }

            public void Stop() { this.stop = true; }

            public virtual void ThreadStart()
            {
                try
                {
                    long read;
                    int lastTick = Environment.TickCount;
                    while (!this.stop && (read = this.ring.Read(this.buf, 0, this.buf.Length)) > 0)
                    {
                        this.target.Write(this.buf, 0, (int)read);

                        this.AsyncProgressInfo.Completed = target.Position;

                        int tick = Environment.TickCount;
                        if (tick - lastTick >= Program.SLOW_UPDATE_PAUSE_MILLIS)
                        {
                            var asScsi = this.target as TrackStream;
                            if (asScsi != null)
                            {
                                var asMMD = asScsi.Device as MultimediaDevice;
                                if (asMMD != null)
                                {
                                    var cap = asMMD.ReadBufferCapacityInBytes();
                                    this.AsyncProgressInfo.DriveBufferCapacity = cap;
                                }
                                else
                                {
                                    this.AsyncProgressInfo.DriveBufferCapacity = null;
                                }
                            }
                            else
                            {
                                this.AsyncProgressInfo.DriveBufferCapacity = null;
                            }
                            lastTick = tick;
                        }
                    }
                }
                catch (ThreadInterruptedException) { }
            }
        }
    }

    internal class ProgressInfo
    {
        public ProgressInfo(BurnStage stage, MasterStage masterStage, long completed, long total, string description, object extraInformation, string progressUnits)
        {
            this.Description = description;
            this.State = extraInformation;
            this.Completed = completed;
            this.Total = total;
            this.ProgressUnits = progressUnits;
            this.BurnStage = stage;
            this.MasterStage = masterStage;
        }

        public string Description;
        public object State;
        public long Completed;
        public long Total;
        public string ProgressUnits;
        public BurnStage BurnStage;
        public MasterStage MasterStage;
        public KeyValuePair<long, long>? ProgramBufferCapacity;
        public BufferCapacityStructureInBytes? DriveBufferCapacity;
    }

    internal class DoWorkInfo
    {
        public DoWorkInfo(BurnType type, IStreamSource source, MultimediaDevice targetDevice)
        {
            this.Type = type;
            this.Source = source;
            this.TargetDevice = targetDevice;
        }

        public int BufferSize;
        public readonly BurnType Type;
        public readonly MultimediaDevice TargetDevice;
        public IStreamSource TargetImage;
        public IStreamSource Source;
        public SetCDSpeedCommand SetCDSpeed = null;
    }

    internal enum BurnStage { None, Locking, Dismounting, FlushingBuffer, FlushingDrive, SettingParameters, Blanking, Reserving, LeadIn, Burning, LeadOut, Closing, Unlocking }
    internal enum BurnType { Erase, Burn }
}