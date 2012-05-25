using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using Helper;

namespace Scsi.Multimedia
{
    /// <summary>Represents a multimedia device (e.g. CD, DVD, BD, etc.). The <see cref="IMultimediaDevice"/> interface is implemented explicitly because it is not meant to be accessed directly (which would cause confusion when similarly named methods would perform differently).
    /// </summary>
    public class MultimediaDevice : ScsiDevice, IMultimediaDevice
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly int POLL_INTERVAL_MILLIS = 250;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private GetEventStatusNotificationCommand gesn =
            new GetEventStatusNotificationCommand();

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private int lastMediaEventQueryTick = -1;

        /// <summary>Initializes a new instance of the <see cref="MultimediaDevice"/> class.</summary>
        /// <param name="interface">The pass-through interface to use.</param>
        /// <param name="leaveOpen"><c>true</c> to leave the interface open, or <c>false</c> to dispose along with this object.</param>
        public MultimediaDevice(IScsiPassThrough @interface, bool leaveOpen) : base(@interface, leaveOpen)
        {
        }

        [Obsolete(
            "Do not use. This is only for viewing the data in the debugger, because manipulating the returned data has no effect. Use the appropriate Get and Set methods instead."
            , true)]
        private CapabilitiesMechanicalStatusPage Capabilities
        {
            get { return GetCapabilities(new ModeSense10Command(PageControl.CurrentValues)); }
        }

        [Obsolete(
            "Do not use. This is only for viewing the data in the debugger, because manipulating the returned data has no effect. Use the appropriate Get and Set methods instead."
            , true)]
        private CDParametersPage CDParameters
        {
            get { return GetCDParameters(new ModeSense10Command(PageControl.CurrentValues)); }
        }

        public MultimediaProfile CurrentProfile
        {
            get
            {
                unsafe
                {
                    int bufferSize = Marshaler.DefaultSizeOf<FeatureHeader>();
                    byte* pFeature = stackalloc byte[bufferSize];
                    var buffer = new BufferWithSize(pFeature, bufferSize);
                    var cmd = new GetConfigurationCommand
                                  {
                                      RequestType = FeatureRequestType.OneFeatureHeaderAndZeroOrOneDescriptor,
                                      StartingFeatureNumber = 0
                                  };
                    cmd.AllocationLength = (ushort) buffer.Length;
                    ExecuteCommand(cmd, DataTransferDirection.ReceiveData, buffer);
                    return ((FeatureHeader*) buffer.Address)->CurrentProfile;
                }
            }
        }

        public DeviceBusyEvent? DeviceBusy
        {
            get
            {
                gesn.NotificationClassRequest = NotificationClassFlags.DeviceBusy;
                Event e = GetEventStatusNotification(gesn);
                return e.Header.NoEventAvailable ? (DeviceBusyEvent?) null : e.Events.DeviceBusyEvent;
            }
        }

        [Obsolete(
            "Do not use. This is only for viewing the data in the debugger, because manipulating the returned data has no effect. Use the appropriate Get and Set methods instead."
            , true)]
        private DiscInformationBlock DiscInformation
        {
            get { return ReadDiscInformation(); }
        }

        public GeneralDiscType DiscType
        {
            get
            {
                switch (CurrentProfile)
                {
                    case MultimediaProfile.NoProfile:
                        return GeneralDiscType.None;
                    case MultimediaProfile.CDROM:
                    case MultimediaProfile.CDR:
                    case MultimediaProfile.CDRW:
                        return GeneralDiscType.CompactDisc;
                    case MultimediaProfile.DvdRom:
                    case MultimediaProfile.DvdMinusRSequentialRecording:
                    case MultimediaProfile.DvdRam:
                    case MultimediaProfile.DvdMinusRWRestrictedOverwrite:
                    case MultimediaProfile.DvdMinusRWSequentialRecording:
                    case MultimediaProfile.DvdMinusRDualLayerSequentialRecording:
                    case MultimediaProfile.DvdMinusRDualLayerJumpRecording:
                    case MultimediaProfile.DvdMinusRWDualLayer:
                    case MultimediaProfile.DvdDownloadDiscRecording:
                    case MultimediaProfile.DvdPlusRW:
                    case MultimediaProfile.DvdPlusR:
                    case MultimediaProfile.DvdPlusRWDualLayer:
                    case MultimediaProfile.DvdPlusRDualLayer:
                        return GeneralDiscType.DigitalVersatileDisc;
                    case MultimediaProfile.BDROM:
                    case MultimediaProfile.BDRSequentialRecording:
                    case MultimediaProfile.BDRERandomRecording:
                    case MultimediaProfile.BDRE:
                        return GeneralDiscType.BluRayDisc;
                    case MultimediaProfile.HDDvdRom:
                    case MultimediaProfile.HDDvdR:
                    case MultimediaProfile.HDDvdRam:
                    case MultimediaProfile.HDDvdRW:
                    case MultimediaProfile.HDDvdRDualLayer:
                    case MultimediaProfile.HDDvdRWDualLayer:
                        return GeneralDiscType.HighDensityDigitalVersatileDisc;
                    default:
                        return GeneralDiscType.Unknown;
                }
            }
        }

        public ExternalRequestEvent? ExternalRequest
        {
            get
            {
                gesn.NotificationClassRequest = NotificationClassFlags.ExternalRequest;
                Event e = GetEventStatusNotification(gesn);
                return e.Header.NoEventAvailable ? (ExternalRequestEvent?) null : e.Events.ExternalRequestEvent;
            }
        }

        [Obsolete(
            "Do not use. This is only for viewing the data in the debugger, because manipulating the returned data has no effect. Use the appropriate Get and Set methods instead."
            , true)]
        private FormatCapacityList FormatCapacities
        {
            get { return ReadFormatCapacities(); }
        }

        public MediaEvent? MediaEvent
        {
            get
            {
                gesn.NotificationClassRequest = NotificationClassFlags.Media;
                Event e = GetEventStatusNotification(gesn);
                return e.Header.NoEventAvailable ? (MediaEvent?) null : e.Events.MediaEvent;
            }
        }

        public MultipleHostEvent? MultipleHost
        {
            get
            {
                gesn.NotificationClassRequest = NotificationClassFlags.MultiHost;
                Event e = GetEventStatusNotification(gesn);
                return e.Header.NoEventAvailable ? (MultipleHostEvent?) null : e.Events.MultipleHostEvent;
            }
        }

        public OperationalChangeEvent? OperationalChange
        {
            get
            {
                gesn.NotificationClassRequest = NotificationClassFlags.OperationalChange;
                Event e = GetEventStatusNotification(gesn);
                return e.Header.NoEventAvailable ? (OperationalChangeEvent?) null : e.Events.OperationalChangeEvent;
            }
        }

        public PowerManagementEvent? PowerManagement
        {
            get
            {
                gesn.NotificationClassRequest = NotificationClassFlags.PowerManagement;
                Event e = GetEventStatusNotification(gesn);
                return e.Header.NoEventAvailable ? (PowerManagementEvent?) null : e.Events.PowerManagementEvent;
            }
        }

        [Obsolete(
            "Do not use. This is only for viewing the data in the debugger, because manipulating the returned data has no effect. Use the appropriate Get and Set methods instead."
            , true)]
        private TrackInformationBlock[] Tracks
        {
            get { return ReadAllTracksInformation(); }
        }

        [Obsolete(
            "Do not use. This is only for viewing the data in the debugger, because manipulating the returned data has no effect. Use the appropriate Get and Set methods instead."
            , true)]
        private WriteParametersPage WriteParameters
        {
            get { return GetWriteParameters(new ModeSense10Command(PageControl.CurrentValues)); }
        }

        #region IMultimediaDevice

        public virtual int FirstTrackNumber
        {
            get { return ReadDiscInformation().FirstTrackNumber; }
        }

        public virtual int TrackCount
        {
            get
            {
                DiscInformationBlock info = ReadDiscInformation();
                return info.LastTrackNumberInLastSession + 1 - info.FirstTrackNumber;
            }
        }

        public virtual int SessionCount
        {
            get { return ReadDiscInformation().SessionCount; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        int IMultimediaDevice.FirstTrackNumber
        {
            get { return FirstTrackNumber; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        int IMultimediaDevice.TrackCount
        {
            get { return TrackCount; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        int IMultimediaDevice.SessionCount
        {
            get { return SessionCount; }
        }

        Stream IMultimediaDevice.OpenTrack(int trackNumber)
        {
            return OpenTrack(trackNumber);
        }

        public virtual Stream OpenTrack(int trackNumber)
        {
            //closeNeeded = false;
            TrackInformationBlock track =
                ReadTrackInformation(new ReadTrackInformationCommand(false, TrackIdentificationType.LogicalTrackNumber,
                                                                     (uint) trackNumber));

            long startPosition = track.LogicalTrackStartAddress*(long) BlockSize;
            long maxLength = track.LogicalTrackSize*(long) BlockSize;
            long position = track.NextWritableAddress.GetValueOrDefault()*(long) BlockSize;

            var stream = new TrackStream(this, track.LogicalTrackNumber, startPosition, maxLength, maxLength, false);
            if (stream.Position != position)
            {
                stream.Position = position - startPosition;
            }
            return stream;
        }

        #endregion

        public void Blank(BlankCommand command)
        {
            ExecuteCommand(command, DataTransferDirection.NoData, BufferWithSize.Zero);
        }

        public static ushort GetBlockSize(DataBlockType blockType)
        {
            ushort result;
            switch (blockType)
            {
                case DataBlockType.Raw2352:
                    result = 2352;
                    break;
                case DataBlockType.Raw2352WithPQSubchannel16:
                    result = 2368;
                    break;
                case DataBlockType.Raw2352WithPWSubchannel96:
                    result = 2448;
                    break;
                case DataBlockType.Raw2352WithRawPWSubchannel96:
                    result = 2448;
                    break;
                case DataBlockType.Mode1:
                    result = 2048;
                    break;
                case DataBlockType.Mode2:
                    result = 2336;
                    break;
                case DataBlockType.Mode2XAForm1:
                    result = 2048;
                    break;
                case DataBlockType.Mode2XAForm1WithSubHeader:
                    result = 2056;
                    break;
                case DataBlockType.Mode2XAForm2:
                    result = 2324;
                    break;
                case DataBlockType.Mode2XAMixed:
                    result = 2332;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("blockType", blockType, "Invalid block type.");
            }
            return result;
        }

        public void CloseTrackOrSession(CloseSessionTrackCommand command)
        {
            ExecuteCommand(command, DataTransferDirection.NoData, BufferWithSize.Zero);
        }

        /// <summary>Tries to detect the disc read speeds.</summary>
        /// <returns>A list of read speeds detected, in BYTES per second.</returns>
        public ushort[] DetectReadSpeeds()
        {
            CapabilitiesMechanicalStatusPage prevCap = GetCapabilities(new ModeSense10Command(PageControl.CurrentValues));
            try
            {
                var result = new List<ushort>();
                var stack = new Stack<KeyValuePair<ushort, ushort>>();
                result.Add(prevCap.MaxReadSpeed);
                SetCDSpeed(new SetCDSpeedCommand(1, prevCap.CurrentWriteSpeed, prevCap.RotationControlSelected));
                result.Add(Capabilities.CurrentReadSpeed);
                stack.Push(new KeyValuePair<ushort, ushort>(1, prevCap.MaxReadSpeed));
                for (int counter = 0; stack.Count > 0 && (stack.Peek().Key + stack.Peek().Value)/2 > 1; counter++)
                {
                    KeyValuePair<ushort, ushort> range = stack.Pop();
                    SetCDSpeed(new SetCDSpeedCommand(range.Key, prevCap.CurrentWriteSpeed,
                                                     prevCap.RotationControlSelected));
                    ushort start = Capabilities.CurrentReadSpeed;
                    SetCDSpeed(new SetCDSpeedCommand(range.Value, prevCap.CurrentWriteSpeed,
                                                     prevCap.RotationControlSelected));
                    ushort end = Capabilities.CurrentReadSpeed;
                    SetCDSpeed(new SetCDSpeedCommand((ushort) ((range.Key + range.Value)/2), prevCap.CurrentWriteSpeed,
                                                     prevCap.RotationControlSelected));
                    ushort middle = Capabilities.CurrentReadSpeed;

                    var startToMiddle = new KeyValuePair<ushort, ushort>(start, (ushort) (middle - 1));
                    var middleToEnd = new KeyValuePair<ushort, ushort>((ushort) (middle + 1), end);

                    if (middle == start & middle == end)
                    {
                        result.Add(middle);
                    }
                    else if (middle != start & middle == end)
                    {
                        if (middle != end)
                        {
                            stack.Push(startToMiddle);
                        }
                    }
                    else if (middle == start & middle != end)
                    {
                        if (middle != start)
                        {
                            stack.Push(middleToEnd);
                        }
                    }
                    else
                    {
                        result.Add(middle);
                        stack.Push(startToMiddle);
                        stack.Push(middleToEnd);
                    }
                }
                result.Sort();
                result.Reverse();
                return result.ToArray();
            }
            finally
            {
                SetCDSpeed(new SetCDSpeedCommand(prevCap.CurrentReadSpeed, prevCap.CurrentWriteSpeed,
                                                 prevCap.RotationControlSelected));
            }
        }

        /// <summary>Tries to detect the disc write speeds.</summary>
        /// <returns>A list of write speeds detected, in BYTES per second.</returns>
        public ushort[] DetectWriteSpeeds()
        {
            CapabilitiesMechanicalStatusPage prevCap = GetCapabilities(new ModeSense10Command(PageControl.CurrentValues));
            try
            {
                var result = new List<ushort>();
                var stack = new Stack<KeyValuePair<ushort, ushort>>();
                result.Add(prevCap.MaxWriteSpeed);
                SetCDSpeed(new SetCDSpeedCommand(prevCap.CurrentReadSpeed, 1, prevCap.RotationControlSelected));
                result.Add(Capabilities.CurrentWriteSpeed);
                stack.Push(new KeyValuePair<ushort, ushort>(1, prevCap.MaxWriteSpeed));
                for (int counter = 0; stack.Count > 0 && (stack.Peek().Key + stack.Peek().Value)/2 > 1; counter++)
                {
                    KeyValuePair<ushort, ushort> range = stack.Pop();
                    SetCDSpeed(new SetCDSpeedCommand(prevCap.CurrentReadSpeed, range.Key,
                                                     prevCap.RotationControlSelected));
                    ushort start = Capabilities.CurrentWriteSpeed;
                    SetCDSpeed(new SetCDSpeedCommand(prevCap.CurrentReadSpeed, range.Value,
                                                     prevCap.RotationControlSelected));
                    ushort end = Capabilities.CurrentWriteSpeed;
                    SetCDSpeed(new SetCDSpeedCommand(prevCap.CurrentReadSpeed, (ushort) ((range.Key + range.Value)/2),
                                                     prevCap.RotationControlSelected));
                    ushort middle = Capabilities.CurrentWriteSpeed;

                    var startToMiddle = new KeyValuePair<ushort, ushort>(start, (ushort) (middle - 1));
                    var middleToEnd = new KeyValuePair<ushort, ushort>((ushort) (middle + 1), end);

                    if (middle == start & middle == end)
                    {
                        result.Add(middle);
                    }
                    else if (middle != start & middle == end)
                    {
                        if (middle != end)
                        {
                            stack.Push(startToMiddle);
                        }
                    }
                    else if (middle == start & middle != end)
                    {
                        if (middle != start)
                        {
                            stack.Push(middleToEnd);
                        }
                    }
                    else
                    {
                        result.Add(middle);
                        stack.Push(startToMiddle);
                        stack.Push(middleToEnd);
                    }
                }
                result.Sort();
                result.Reverse();
                return result.ToArray();
            }
            finally
            {
                SetCDSpeed(new SetCDSpeedCommand(prevCap.CurrentReadSpeed, prevCap.CurrentWriteSpeed,
                                                 prevCap.RotationControlSelected));
            }
        }

        public void Eject()
        {
            StartStopUnit(new StartStopUnitCommand(true, false));
        }

        public void Erase10(Erase10Command command)
        {
            ExecuteCommand(command, DataTransferDirection.NoData, BufferWithSize.Zero);
        }

        public void FormatUnit(FormatUnitCommand command, FormatDescriptor formatInfo)
        {
            GCHandle hFormatInfo = GCHandle.Alloc(formatInfo, GCHandleType.Pinned);
            try
            {
                command.FormatCode = formatInfo.FormatCode;
                ExecuteCommand(command, DataTransferDirection.SendData,
                               new BufferWithSize(hFormatInfo.AddrOfPinnedObject(), Marshaler.SizeOf(formatInfo)));
            }
            finally
            {
                hFormatInfo.Free();
            }
        }

        public CapabilitiesMechanicalStatusPage GetCapabilities(ModeSense10Command command)
        {
            return ModeSense10<CapabilitiesMechanicalStatusPage>(command);
        }

        public CDParametersPage GetCDParameters(ModeSense10Command command)
        {
            return ModeSense10<CDParametersPage>(command);
        }

        public FeatureCollection GetConfiguration(FeatureCode startingFeatureNumber, FeatureRequestType requestType)
        {
            if (!Enum.IsDefined(typeof (FeatureRequestType), requestType))
            {
                throw new ArgumentOutOfRangeException("requestType", requestType, "Invalid request type.");
            }
            if (requestType == FeatureRequestType.OneFeatureHeaderAndZeroOrOneDescriptor)
            {
                throw new ArgumentOutOfRangeException("requestType", requestType,
                                                      "Request type must return a collection.");
            }
            unsafe
            {
                int bufferSize = Marshaler.DefaultSizeOf<FeatureHeader>();
                byte* pFeature1 = stackalloc byte[bufferSize];
                var buffer = new BufferWithSize(pFeature1, bufferSize);
                var cmd = new GetConfigurationCommand
                              {
                                  RequestType = requestType,
                                  StartingFeatureNumber = startingFeatureNumber
                              };
                cmd.AllocationLength = (ushort) buffer.Length;
                ExecuteCommand(cmd, DataTransferDirection.ReceiveData, buffer);
                int requiredSize = Marshaler.DefaultSizeOf<MultimediaFeature>() +
                                   (int) ((FeatureHeader*) buffer.Address)->DataLength;
                if (bufferSize < requiredSize)
                {
                    bufferSize = requiredSize;
                    byte* pFeature2 = stackalloc byte[bufferSize];
                    buffer = new BufferWithSize(pFeature2, bufferSize);
                    cmd.AllocationLength = (ushort) buffer.Length;
                    ExecuteCommand(cmd, DataTransferDirection.ReceiveData, buffer);
                }
                return FeatureCollection.FromBuffer(buffer);
            }
        }

        public TFeature GetConfiguration<TFeature>()
            where TFeature : MultimediaFeature, new()
        {
            MultimediaFeature result = Objects.CreateInstance<TFeature>();
            GetConfiguration(result.FeatureCode, ref result);
            return (TFeature) result;
        }

        public MultimediaFeature GetConfiguration(FeatureCode featureCode)
        {
            MultimediaFeature feature = null;
            GetConfiguration(featureCode, ref feature);
            return feature;
        }

        private void GetConfiguration(FeatureCode featureCode, ref MultimediaFeature feature)
        {
            if (feature == null)
            {
                feature = MultimediaFeature.CreateInstance(featureCode);
            }
            unsafe
            {
                int bufferSize = Marshaler.DefaultSizeOf<MultimediaFeature>();
                byte* pFeature1 = stackalloc byte[bufferSize];
                var buffer = new BufferWithSize(pFeature1, bufferSize);
                var cmd = new GetConfigurationCommand
                              {
                                  RequestType = FeatureRequestType.OneFeatureHeaderAndZeroOrOneDescriptor,
                                  StartingFeatureNumber = feature.FeatureCode
                              };
                cmd.AllocationLength = (ushort) buffer.Length;
                ExecuteCommand(cmd, DataTransferDirection.ReceiveData, buffer);
                int requiredSize = Marshaler.DefaultSizeOf<FeatureHeader>() +
                                   Marshaler.DefaultSizeOf<MultimediaFeature>() +
                                   MultimediaFeature.ReadAdditionalLength(buffer);
                if (bufferSize < requiredSize)
                {
                    bufferSize = requiredSize;
                    byte* pFeature2 = stackalloc byte[bufferSize];
                    buffer = new BufferWithSize(pFeature2, bufferSize);
                    cmd.AllocationLength = (ushort) buffer.Length;
                    ExecuteCommand(cmd, DataTransferDirection.ReceiveData, buffer);
                }
                BufferWithSize newBuf = buffer.ExtractSegment(Marshaler.DefaultSizeOf<FeatureHeader>());
                if (newBuf.LengthU32 > 0 && MultimediaFeature.ReadFeatureCode(newBuf) == feature.FeatureCode)
                {
                    Marshaler.PtrToStructure(newBuf, ref feature);
                }
                else
                {
                    feature = null;
                }
            }
        }

        public Event GetEventStatusNotification(GetEventStatusNotificationCommand command)
        {
            var result = new Event();
            command.AllocationLength = (ushort) Marshaler.DefaultSizeOf<Event>();
            unsafe
            {
                ExecuteCommand(command, DataTransferDirection.ReceiveData,
                               new BufferWithSize((IntPtr) (&result), command.AllocationLength));
            }
            return result;
        }

        public PerformanceData GetPerformance(GetPerformanceCommand command)
        {
            unsafe
            {
                int size = Marshaler.DefaultSizeOf<PerformanceData>();
                byte* pBuffer = stackalloc byte[size];
                ushort prevMaxNumDesc = command.MaximumNumberOfDescriptors;
                command.MaximumNumberOfDescriptors = 0;
                var buffer = new BufferWithSize(pBuffer, size);
                ExecuteCommand(command, DataTransferDirection.ReceiveData, buffer);
                int neededLength = PerformanceData.ReadPerformanceDataLength(buffer);
                size += neededLength*2;
                {
                    byte* pBuffer2 = stackalloc byte[size];
                    pBuffer = pBuffer2;
                }
                buffer = new BufferWithSize(pBuffer, size);
                command.MaximumNumberOfDescriptors = prevMaxNumDesc;
                ExecuteCommand(command, DataTransferDirection.ReceiveData, buffer);
                var data = new PerformanceData(command.PerformanceType, command.DataType);
                Marshaler.PtrToStructure(buffer, ref data);
                return data;
            }
        }

        public WriteParametersPage GetWriteParameters(ModeSense10Command command)
        {
            return ModeSense10<WriteParametersPage>(command);
        }

        protected override bool HasMediumChanged()
        {
            int tick = Environment.TickCount;
            if (tick - lastMediaEventQueryTick >= POLL_INTERVAL_MILLIS)
            {
                bool changed =
                    MediaEvent.GetValueOrDefault(new MediaEvent {MediaEventCode = MediaEventCode.NewMedia}).
                        MediaEventCode != MediaEventCode.NoChange;
                lastMediaEventQueryTick = tick;
                return changed;
            }
            else
            {
                return false;
            }
        }

        public void Load()
        {
            StartStopUnit(new StartStopUnitCommand(true, true));
        }

        public void PreventAllowMediumRemoval(PreventAllowMediumRemovalCommand command)
        {
            ExecuteCommand(command, DataTransferDirection.NoData, BufferWithSize.Zero);
        }

        public TrackInformationBlock[] ReadAllTracksInformation()
        {
            DiscInformationBlock diskInfo = ReadDiscInformation();
            var tracks =
                new TrackInformationBlock[diskInfo.LastTrackNumberInLastSession - diskInfo.FirstTrackNumber + 1];
            for (uint i = 0; i < tracks.Length; i++)
            {
                tracks[i] =
                    ReadTrackInformation(new ReadTrackInformationCommand(false,
                                                                         TrackIdentificationType.LogicalTrackNumber,
                                                                         diskInfo.FirstTrackNumber + i));
            }
            return tracks;
        }

        public BufferCapacityStructureInBytes ReadBufferCapacityInBytes()
        {
            return ReadBufferCapacity(new ReadBufferCapacityCommand(false)).Bytes;
        }

        public BufferCapacityStructureInBlocks ReadBufferCapacityInBlocks()
        {
            return ReadBufferCapacity(new ReadBufferCapacityCommand(true)).Blocks;
        }

        public ReadBufferCapacityInfo ReadBufferCapacity(ReadBufferCapacityCommand command)
        {
            var result = new ReadBufferCapacityInfo();
            command.AllocationLength = (ushort) Marshaler.DefaultSizeOf<ReadBufferCapacityInfo>();
            unsafe
            {
                ExecuteCommand(command, DataTransferDirection.ReceiveData,
                               new BufferWithSize((IntPtr) (&result), command.AllocationLength));
            }
            return result;
        }

        public void ReadCD(ReadCDCommand command, byte[] buffer, int bufferOffset)
        {
            unsafe
            {
                fixed (byte* pBuffer = &buffer[bufferOffset])
                {
                    ReadCD(command, new BufferWithSize(pBuffer, buffer.Length - bufferOffset));
                }
            }
        }

        public void ReadCD(ReadCDCommand command, BufferWithSize buffer)
        {
            ExecuteCommand(command, DataTransferDirection.ReceiveData, buffer);
        }

        public DiscInformationBlock ReadDiscInformation()
        {
            return ReadDiscInformation(new ReadDiscInformationCommand());
        }

        public DiscInformationBlock ReadDiscInformation(ReadDiscInformationCommand command)
        {
            DiscInformationBlock result;
            unsafe
            {
                int bufferSize = Marshaler.DefaultSizeOf<DiscInformationBlock>();
                byte* pBuffer1 = stackalloc byte[bufferSize];
                var buffer = new BufferWithSize(pBuffer1, bufferSize);
                command.AllocationLength = (ushort) bufferSize;
                ExecuteCommand(command, DataTransferDirection.ReceiveData, buffer);
                byte entries = DiscInformationBlock.ReadNumOptimumPowerCalibrationEntries(buffer);
                int requiredSize = Marshaler.DefaultSizeOf<DiscInformationBlock>() +
                                   Marshaler.DefaultSizeOf<OptimumPowerCalibration>()*entries;
                if (bufferSize < requiredSize)
                {
                    bufferSize = requiredSize;
                    byte* pBuffer2 = stackalloc byte[bufferSize];
                    buffer = new BufferWithSize(pBuffer2, bufferSize);
                    command.AllocationLength = (ushort) bufferSize;
                    ExecuteCommand(command, DataTransferDirection.ReceiveData, buffer);
                }
                result = Marshaler.PtrToStructure<DiscInformationBlock>(buffer);
            }
            return result;
        }

        public DiscStructureData ReadDiscStructure(ReadDiscStructureCommand command)
        {
            command.AllocationLength = (ushort) Marshaler.DefaultSizeOf<DiscStructureData>();
            BufferWithSize buffer;
            unsafe
            {
                byte* pHeader = stackalloc byte[command.AllocationLength];
                buffer = new BufferWithSize(pHeader, command.AllocationLength);
            }
            ExecuteCommand(command, DataTransferDirection.ReceiveData, buffer); //Get the size of the required data

            //This is ADDED to the previous header size!
            command.AllocationLength =
                (ushort)
                (sizeof (ushort) /*this is for the size field itself*/+ DiscStructureData.ReadDataLength(buffer)*2);
                //Multiply by 2, just to be really sure it won't change due to race conditions
            unsafe
            {
                byte* pHeader = stackalloc byte[command.AllocationLength];
                buffer = new BufferWithSize(pHeader, command.AllocationLength);
            }
            ExecuteCommand(command, DataTransferDirection.ReceiveData, buffer); //Read the actual data
            Debug.Assert(command.AllocationLength >= DiscStructureData.ReadDataLength(buffer));
            return DiscStructureData.FromBuffer(command.Format, command.MediaType, buffer);
        }

        public FormatCapacityList ReadFormatCapacities()
        {
            return ReadFormatCapacities(new ReadFormatCapacitiesCommand());
        }

        public FormatCapacityList ReadFormatCapacities(ReadFormatCapacitiesCommand cmd)
        {
            FormatCapacityList cl;
            unsafe
            {
                int bufferSize = Marshaler.DefaultSizeOf<FormatCapacityList>();
                byte* pBuffer1 = stackalloc byte[bufferSize];
                var buffer = new BufferWithSize(pBuffer1, bufferSize);
                cmd.AllocationLength = (ushort) buffer.Length;
                ExecuteCommand(cmd, DataTransferDirection.ReceiveData, buffer);
                int requiredSize = FormatCapacityList.ReadCapacityListLength(buffer.Address) + bufferSize;
                if (bufferSize < requiredSize)
                {
                    bufferSize = requiredSize;
                    var pBuffer2 = stackalloc byte[bufferSize];
                    buffer = new BufferWithSize(pBuffer2, bufferSize);
                    cmd.AllocationLength = (ushort) buffer.Length;
                    ExecuteCommand(cmd, DataTransferDirection.ReceiveData, buffer);
                }
                cl = Marshaler.PtrToStructure<FormatCapacityList>(buffer);
            }
            return cl;
        }

        public TrackInformationBlock ReadTrackInformation(ReadTrackInformationCommand command)
        {
            var result = new TrackInformationBlock();
            command.AllocationLength = (ushort) Marshaler.DefaultSizeOf<TrackInformationBlock>();
            unsafe
            {
                ExecuteCommand(command, DataTransferDirection.ReceiveData,
                               new BufferWithSize((IntPtr) (&result), command.AllocationLength));
            }
            return result;
        }

        public TocPmaAtipResponseData ReadTocPmaAtip(ReadTocPmaAtipCommand command)
        {
            TocPmaAtipResponseData result;
            unsafe
            {
                command.AllocationLength = sizeof (ushort) + 1022;
                byte* pData = stackalloc byte[command.AllocationLength];
                ExecuteCommand(command, DataTransferDirection.ReceiveData,
                               new BufferWithSize(pData, command.AllocationLength));
                int requiredLength = TocPmaAtipResponseData.ReadDataLength((IntPtr) pData) + sizeof (ushort);
                if (requiredLength > command.AllocationLength)
                {
                    command.AllocationLength = (ushort) requiredLength;
                    byte* pData2 = stackalloc byte[command.AllocationLength];
                    pData = pData2;
                    ExecuteCommand(command, DataTransferDirection.ReceiveData,
                                   new BufferWithSize(pData, command.AllocationLength));
                    requiredLength = TocPmaAtipResponseData.ReadDataLength((IntPtr) pData) + sizeof (ushort);
                }
                result = TocPmaAtipResponseData.CreateInstance(command.Format);
                if (result != null)
                {
                    Marshaler.PtrToStructure(new BufferWithSize(pData, command.AllocationLength), ref result);
                }
            }
            return result;
        }

        public void ReserveTrack(ReserveTrackCommand command)
        {
            ExecuteCommand(command, DataTransferDirection.NoData, BufferWithSize.Zero);
        }

        public void SendCueSheet(SendCueSheetCommand command, params CueLine[] cueSheet)
        {
            unsafe
            {
                fixed (CueLine* pCueSheet = cueSheet)
                {
                    command.CueSheetSize = (uint) sizeof (CueLine)*(uint) cueSheet.Length;
                    ExecuteCommand(command, DataTransferDirection.SendData,
                                   new BufferWithSize((IntPtr) pCueSheet, command.CueSheetSize));
                }
            }
        }

        public void SendOptimumPowerCalibrationInformation(SendOpcInformationCommand command,
                                                           OptimumPowerCalibration? info)
        {
            command.DoOptimumPowerCalibration = info == null;
            OptimumPowerCalibration value = info.GetValueOrDefault();
            unsafe
            {
                ExecuteCommand(command, DataTransferDirection.SendData,
                               command.DoOptimumPowerCalibration
                                   ? BufferWithSize.Zero
                                   : new BufferWithSize((IntPtr) (&value),
                                                        Marshaler.DefaultSizeOf<OptimumPowerCalibration>()));
            }
        }

        public void SetCDParameters(ModeSelect10Command command, CDParametersPage modePage)
        {
            ModeSelect10(command, modePage);
        }

        public void SetCDSpeed(SetCDSpeedCommand command)
        {
            ExecuteCommand(command, DataTransferDirection.NoData, BufferWithSize.Zero);
        }

        public void SetReadAhead(SetReadAheadCommand command)
        {
            ExecuteCommand(command, DataTransferDirection.NoData, BufferWithSize.Zero);
        }

        public void SetStreaming(DefectiveBlockInformationCacheZoneDescriptors info)
        {
            SetStreaming(new SetStreamingCommand(), info);
        }

        public void SetStreaming(SetStreamingCommand command, DefectiveBlockInformationCacheZoneDescriptors info)
        {
            unsafe
            {
                int bufferSize = Marshaler.SizeOf(info);
                byte* pBuffer = stackalloc byte[bufferSize];
                var buffer = new BufferWithSize(pBuffer, bufferSize);
                Marshaler.StructureToPtr(info, buffer);
                command.ParameterListLength = (ushort) buffer.Length;
                command.Type = StreamingDataType.DefectiveBlockInformationCacheZoneDescriptor;
                ExecuteCommand(command, DataTransferDirection.SendData, buffer);
            }
        }

        public void SetStreaming(StreamingPerformanceDescriptor info)
        {
            SetStreaming(new SetStreamingCommand(), info);
        }

        public void SetStreaming(SetStreamingCommand command, StreamingPerformanceDescriptor info)
        {
            unsafe
            {
                var buffer = new BufferWithSize((IntPtr) (&info),
                                                Marshaler.DefaultSizeOf<StreamingPerformanceDescriptor>());
                command.ParameterListLength = (ushort) buffer.Length;
                command.Type = StreamingDataType.PerformanceDescriptor;
                ExecuteCommand(command, DataTransferDirection.SendData, buffer);
            }
        }

        public void SetWriteParameters(ModeSelect10Command command, WriteParametersPage modePage)
        {
            command.ParameterListLength = 60;
            ModeSelect10(command, modePage);
        }

        public void StartStopUnit(StartStopUnitCommand command)
        {
            try
            {
                ExecuteCommand(command, DataTransferDirection.NoData, BufferWithSize.Zero);
            }
            catch (ScsiException ex)
            {
                SenseData sense = ex.SenseData;
                if (sense.SenseKey == SenseKey.IllegalRequest &
                    sense.AdditionalSenseCode == AdditionalSenseCode.InvalidFieldInCommandDescriptorBlock)
                {
                    throw new InvalidOperationException("An error occurred. This operation may not be supported.", ex);
                }
                throw;
            }
        }

        public void Verify10(Verify10Command command)
        {
            ExecuteCommand(command, DataTransferDirection.NoData, BufferWithSize.Zero);
        }


        public bool WaitForBusyStatus(DeviceBusyStatusCode statusToWaitFor)
        {
            return WaitForBusyStatus(statusToWaitFor, -1);
        }

        /// <param name="timeoutMillis">The timeout in waiting for the event. If this member is negative, then timeouts will never occur.</param>
        public bool WaitForBusyStatus(DeviceBusyStatusCode statusToWaitFor, int timeoutMillis)
        {
            int startTick = Environment.TickCount;
            for (;;)
            {
                DeviceBusyEvent? e = DeviceBusy;
                if (e == null)
                {
                    return false;
                }
                DeviceBusyEvent val = e.Value;
                if (val.DeviceBusyStatusCode == statusToWaitFor)
                {
                    return true;
                }
                int tick = Environment.TickCount;
                if (timeoutMillis != -1 && tick - startTick > timeoutMillis)
                {
                    return false;
                }
                ushort msToWait = val.Time;
                Thread.Sleep(msToWait > 0 ? msToWait*100 : DefaultPollingInterval*100);
            }
        }

        public bool WaitForMediaEvent(MediaEventCode eventToWaitFor)
        {
            return WaitForMediaEvent(eventToWaitFor, -1);
        }

        /// <param name="timeoutMillis">The timeout in waiting for the event. If this member is negative, then timeouts will never occur.</param>
        public bool WaitForMediaEvent(MediaEventCode eventToWaitFor, int timeoutMillis)
        {
            int startTick = Environment.TickCount;
            for (;;)
            {
                MediaEvent? e = MediaEvent;
                if (e == null)
                {
                    return false;
                }
                MediaEvent val = e.Value;
                if (val.MediaEventCode == eventToWaitFor)
                {
                    return true;
                }
                int tick = Environment.TickCount;
                if (timeoutMillis != -1 && tick - startTick > timeoutMillis)
                {
                    return false;
                }
                Thread.Sleep(DefaultPollingInterval*100);
            }
        }

        public bool WaitForPowerStatus(PowerStatusCode statusToWaitFor)
        {
            return WaitForPowerStatus(statusToWaitFor, -1);
        }

        /// <param name="timeoutMillis">The timeout in waiting for the event. If this member is negative, then timeouts will never occur.</param>
        public bool WaitForPowerStatus(PowerStatusCode statusToWaitFor, int timeoutMillis)
        {
            int startTick = Environment.TickCount;
            for (;;)
            {
                PowerManagementEvent? e = PowerManagement;
                if (e == null)
                {
                    return false;
                }
                PowerManagementEvent val = e.Value;
                if (val.PowerStatusCode == statusToWaitFor)
                {
                    return true;
                }
                int tick = Environment.TickCount;
                if (timeoutMillis != -1 && tick - startTick > timeoutMillis)
                {
                    return false;
                }
                Thread.Sleep(DefaultPollingInterval*100);
            }
        }
    }
}