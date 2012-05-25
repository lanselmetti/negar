#region using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;
using Negar;
using DevComponents.DotNetBar;
using IMAPI2.Interop;
using IMAPI2.MediaItem;

#endregion

namespace Sepehr.Forms.Documents
{
    /// <summary>
    /// فرم رایت فایل های تصویری و ویدئویی كپچر شده برای بیمار
    /// </summary>
    public partial class frmFileBurner : Form
    {

        #region Fields

        #region readonly Int32 _CurrentRefID
        /// <summary>
        /// كلید مراجعه جاری
        /// </summary>
        private readonly Int32 _CurrentRefID;
        #endregion

        #region readonly String[] _ImageFiles
        /// <summary>
        /// لیست آدرس فایل های تصویری
        /// </summary>
        private readonly String[] _ImageFiles;
        #endregion

        #region readonly String[] _VideoFiles
        /// <summary>
        /// لیست آدرس فیزیكی فایل های ویدئویی
        /// </summary>
        private readonly String[] _VideoFiles;
        #endregion

        #region BurnData _burnData
        private BurnData _burnData;
        #endregion

        #region Int64 _totalDiscSize
        /// <summary>
        /// ظرفیت كامل دیسك جاری
        /// </summary>
        private Int64 _totalDiscSize;
        #endregion

        #region IMAPI_BURN_VERIFICATION_LEVEL _verificationLevel
        /// <summary>
        /// سطح بررسی صحت رایت اطلاعات
        /// </summary>
        private IMAPI_BURN_VERIFICATION_LEVEL _verificationLevel =
            IMAPI_BURN_VERIFICATION_LEVEL.IMAPI_BURN_VERIFICATION_NONE;
        #endregion

        #region Boolean _isBurning
        private Boolean _isBurning;
        #endregion

        #region Boolean _ejectMedia
        private Boolean _ejectMedia;
        #endregion

        #region Boolean _WriteVCD
        private Boolean _WriteVCD;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmFileBurner(Int32 CurrentRefID)
        {
            Cursor.Current = Cursors.WaitCursor;
            _CurrentRefID = CurrentRefID;
            String RefDataFolderPath = Negar.Medical.VideoCapture.CaptureHelper.GetRefDataFilesFolder(_CurrentRefID);
            _ImageFiles = Directory.GetFiles(RefDataFolderPath, "*.Jpg", SearchOption.TopDirectoryOnly);
            _VideoFiles = Directory.GetFiles(RefDataFolderPath, "*.Wmv", SearchOption.TopDirectoryOnly);
            if (_ImageFiles.Length == 0 && _VideoFiles.Length == 0)
            {
                PMBox.Show("هیچ فایل ویدئو یا تصویری برای بیمار جاری ثبت نشده است!\n" +
                    "برای رایت اطلاعات باید ابتدا فایلی برای رایت وجود داشته باشد.", "عدم وجود فایل كپچر شده!",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop); Close(); return;
            }
            InitializeComponent();
            if (!PrepareForm()) { Close(); return; }
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
        }
        #endregion

        #region cboDriveSelection_SelectedIndexChanged
        private void cboDriveSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnCheckCurrentCD_Click(null, null);
        }
        #endregion

        #region cboDriveSelection_Format
        private void cboDriveSelection_Format(object sender, ListControlConvertEventArgs e)
        {
            IDiscRecorder2 TheDiscRecorder = (IDiscRecorder2)e.ListItem;
            String DevicePath = String.Empty;
            foreach (String volPath in TheDiscRecorder.VolumePathNames)
            {
                if (!String.IsNullOrEmpty(DevicePath)) DevicePath += ",";
                DevicePath += volPath;
            }
            e.Value = string.Format("{0} [{1}]", DevicePath, TheDiscRecorder.ProductId);
        }
        #endregion

        #region cboVerification_SelectedIndexChanged
        private void cboVerification_SelectedIndexChanged(object sender, EventArgs e)
        {
            _verificationLevel = (IMAPI_BURN_VERIFICATION_LEVEL)cboVerification.SelectedIndex;
        }
        #endregion

        #region btnCheckCurrentCD_Click
        private void btnCheckCurrentCD_Click(object sender, EventArgs e)
        {
            if (cboDriveSelection.SelectedIndex == -1) return;
            IDiscRecorder2 discRecorder = (IDiscRecorder2)cboDriveSelection.Items[cboDriveSelection.SelectedIndex];
            MsftFileSystemImage fileSystemImage = null;
            MsftDiscFormat2Data discFormatData = null;
            try
            {
                discFormatData = new MsftDiscFormat2Data();
                if (discRecorder.CurrentProfiles.Length == 0)
                {
                    lblStatus.Text = "دیسك خام داخل درایو قرار دهید.";
                    _totalDiscSize = 0;
                }
                else if (!discFormatData.IsCurrentMediaSupported(discRecorder))
                {
                    lblStatus.Text = "سی دی جاری پشتیبانی نمی شود.";
                    _totalDiscSize = 0;
                }
                else
                {
                    discFormatData.Recorder = discRecorder;
                    IMAPI_MEDIA_PHYSICAL_TYPE mediaType = discFormatData.CurrentPhysicalMediaType;
                    lblStatus.Text = "نوع دیسك: " + GetMediaTypeString(mediaType);
                    fileSystemImage = new MsftFileSystemImage();
                    fileSystemImage.ChooseImageDefaultsForMediaType(mediaType);
                    if (!discFormatData.MediaHeuristicallyBlank)
                    {
                        fileSystemImage.MultisessionInterfaces = discFormatData.MultisessionInterfaces;
                        fileSystemImage.ImportFileSystem();
                    }
                    Int64 freeMediaBlocks = fileSystemImage.FreeMediaBlocks;
                    _totalDiscSize = 2048 * freeMediaBlocks;
                }
            }
            #region Catch
            catch (COMException Ex)
            {
                LogManager.SaveLogEntry("Sepehr", "Documents - FileBurner Form", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error);
                PMBox.Show("امكان شناسایی دیسك قرار داده شده وجود ندارد!\n" +
                    "با واحد پشتیبانی شركت تماس حاصل نمایید.", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            catch (Exception Ex)
            {
                LogManager.SaveLogEntry("Sepehr", "Documents - FileBurner Form", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error);
                PMBox.Show("خطا در شناسایی دیسك قرار داده شده!", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            #endregion
            finally
            {
                if (discFormatData != null) Marshal.ReleaseComObject(discFormatData);
                if (fileSystemImage != null) Marshal.ReleaseComObject(fileSystemImage);
            }
            UpdateCapacity();
        }
        #endregion

        #region btnBurn_Click
        private void btnBurn_Click(object sender, EventArgs e)
        {
            _WriteVCD = cBoxVCD.Checked;
            if (cboDriveSelection.SelectedIndex == -1) return;
            if (_isBurning)
            {
                btnBurn.Enabled = false;
                backgroundBurnWorker.CancelAsync();
            }
            else
            {
                _isBurning = true;
                _ejectMedia = cBoxEjectCD.Checked;
                EnableBurnUI(false);
                IDiscRecorder2 discRecorder = (IDiscRecorder2)cboDriveSelection.Items[cboDriveSelection.SelectedIndex];
                _burnData.uniqueRecorderId = discRecorder.ActiveDiscRecorder;
                backgroundBurnWorker.RunWorkerAsync(_burnData);
            }
        }
        #endregion

        #region backgroundBurnWorker_DoWork
        private void backgroundBurnWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            MsftDiscRecorder2 discRecorder = null;
            MsftDiscFormat2Data discFormatData = null;
            try
            {
                // Create and initialize the IDiscRecorder2 object
                discRecorder = new MsftDiscRecorder2();
                BurnData burnData = (BurnData)e.Argument;
                discRecorder.InitializeDiscRecorder(burnData.uniqueRecorderId);
                // Create and initialize the IDiscFormat2Data
                discFormatData = new MsftDiscFormat2Data();
                discFormatData.Recorder = discRecorder;
                discFormatData.ClientName = "RPNBurner";
                discFormatData.ForceMediaToBeClosed = true;
                List<Int32> sortedSpeedList = new List<Int32>();
                foreach (int item in discFormatData.SupportedWriteSpeeds) sortedSpeedList.Add(item);
                sortedSpeedList.Sort();
                sortedSpeedList.Reverse();
                if (sortedSpeedList.Count > 2)
                    discFormatData.SetWriteSpeed(sortedSpeedList[2], true);
                else if (sortedSpeedList.Count > 1)
                    discFormatData.SetWriteSpeed(sortedSpeedList[1], true);
                else discFormatData.SetWriteSpeed(sortedSpeedList[0], true);
                // تنظیم سطح بررسی دیسك
                IBurnVerification burnVerification = (IBurnVerification)discFormatData;
                burnVerification.BurnVerificationLevel = _verificationLevel;
                // Check if media is blank, (for RW media)
                Object[] multisessionInterfaces = null;
                if (!discFormatData.MediaHeuristicallyBlank) multisessionInterfaces = discFormatData.MultisessionInterfaces;
                // ایجاد فایل های لازم برای رایت
                IStream fileSystem;
                if (!CreateMediaFileSystem(discRecorder, multisessionInterfaces, out fileSystem)) { e.Result = -1; return; }
                // add the Update event handler
                discFormatData.Update += discFormatData_Update;
                // Write the data here
                try
                {
                    discFormatData.Write(fileSystem);
                    e.Result = 0;
                }
                catch (COMException ex)
                {
                    e.Result = ex.ErrorCode;
                    PMBox.Show("خطا در رایت دیسك!", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (fileSystem != null) Marshal.FinalReleaseComObject(fileSystem);
                }
                // remove the Update event handler
                discFormatData.Update -= discFormatData_Update;
                if (_ejectMedia) discRecorder.EjectMedia();
            }
            catch (COMException Ex)
            {
                // If anything happens during the format, show the message
                PMBox.Show("خطا در رایت دیسك!", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(Ex.Message);
                e.Result = Ex.ErrorCode;
            }
            finally
            {
                if (discRecorder != null) Marshal.ReleaseComObject(discRecorder);
                if (discFormatData != null) Marshal.ReleaseComObject(discFormatData);
            }
        }
        #endregion

        #region backgroundBurnWorker_ProgressChanged
        private void backgroundBurnWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            BurnData burnData = (BurnData)e.UserState;
            Int64 writtenSectors = burnData.lastWrittenLba - burnData.startLba;
            if (writtenSectors > 0 && burnData.sectorCount > 0)
            {
                ProgressBurn.Text = String.Format("میزان پیشرفت: {0}%", e.ProgressPercentage);
                ProgressBurn.Value = e.ProgressPercentage;
            }
            else
            {
                ProgressBurn.Text = "میزان پیشرفت: 0 %";
                ProgressBurn.Value = 0;
            }
            if (burnData.task == BURN_MEDIA_TASK.BURN_MEDIA_TASK_FILE_SYSTEM)
                lblStatus.Text = burnData.statusMessage;
            else if (burnData.task == BURN_MEDIA_TASK.BURN_MEDIA_TASK_WRITING)
            {
                switch (burnData.currentAction)
                {
                    case IMAPI_FORMAT2_DATA_WRITE_ACTION.IMAPI_FORMAT2_DATA_WRITE_ACTION_VALIDATING_MEDIA:
                        lblStatus.Text = "تایید اعتبار داده ها";
                        break;

                    case IMAPI_FORMAT2_DATA_WRITE_ACTION.IMAPI_FORMAT2_DATA_WRITE_ACTION_FORMATTING_MEDIA:
                        lblStatus.Text = "فرمت داده ها";
                        break;

                    case IMAPI_FORMAT2_DATA_WRITE_ACTION.IMAPI_FORMAT2_DATA_WRITE_ACTION_INITIALIZING_HARDWARE:
                        lblStatus.Text = "آماده سازی سخت افزار";
                        break;

                    case IMAPI_FORMAT2_DATA_WRITE_ACTION.IMAPI_FORMAT2_DATA_WRITE_ACTION_CALIBRATING_POWER:
                        lblStatus.Text = "تنظیم لیزر رایتر";
                        break;

                    case IMAPI_FORMAT2_DATA_WRITE_ACTION.IMAPI_FORMAT2_DATA_WRITE_ACTION_WRITING_DATA:
                        writtenSectors = burnData.lastWrittenLba - burnData.startLba;
                        if (writtenSectors > 0 && burnData.sectorCount > 0)
                        {
                            Int32 percent = Convert.ToInt32((100 * writtenSectors) / burnData.sectorCount);
                            ProgressBurn.Text = String.Format("میزان پیشرفت: {0}%", percent);
                            ProgressBurn.Value = percent;
                        }
                        else
                        {
                            ProgressBurn.Text = "میزان پیشرفت 0 %";
                            ProgressBurn.Value = 0;
                        }
                        break;

                    case IMAPI_FORMAT2_DATA_WRITE_ACTION.IMAPI_FORMAT2_DATA_WRITE_ACTION_FINALIZATION:
                        lblStatus.Text = "پایان بخشیدن به نوشتن روی دیسك...";
                        break;

                    case IMAPI_FORMAT2_DATA_WRITE_ACTION.IMAPI_FORMAT2_DATA_WRITE_ACTION_COMPLETED:
                        lblStatus.Text = "اتمام رایت دیسك.";
                        break;

                    case IMAPI_FORMAT2_DATA_WRITE_ACTION.IMAPI_FORMAT2_DATA_WRITE_ACTION_VERIFYING:
                        lblStatus.Text = "در حال چك كردن دیسك...";
                        break;
                }
            }
        }
        #endregion

        #region backgroundBurnWorker_RunWorkerCompleted
        private void backgroundBurnWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ProgressBurn.Text = Convert.ToInt32(e.Result) == 0 ? "رایت دیسك پایان یافت" : "خطا در رایت دیسك";
            ProgressBurn.Value = 0;
            _isBurning = false;
            EnableBurnUI(true);
            btnBurn.Enabled = true;
        }
        #endregion

        #region fileSystemImage_Update
        /// <summary>
        /// Event Handler for File System Progress Updates
        /// </summary>
        private void fileSystemImage_Update([In, MarshalAs(UnmanagedType.IDispatch)] Object sender,
            [In, MarshalAs(UnmanagedType.BStr)]String currentFile, [In] Int32 copiedSectors, [In] Int32 totalSectors)
        {
            Int32 percentProgress = 0;
            if (copiedSectors > 0 && totalSectors > 0) percentProgress = (copiedSectors * 100) / totalSectors;
            if (!String.IsNullOrEmpty(currentFile))
            {
                FileInfo fileInfo = new FileInfo(currentFile);
                _burnData.statusMessage = "فایل \"" + fileInfo.Name + "\" افزوده شد";
                // report back to the ui
                _burnData.task = BURN_MEDIA_TASK.BURN_MEDIA_TASK_FILE_SYSTEM;
                backgroundBurnWorker.ReportProgress(percentProgress, _burnData);
            }
        }
        #endregion

        #region discFormatData_Update
        void discFormatData_Update([In, MarshalAs(UnmanagedType.IDispatch)] Object sender,
            [In, MarshalAs(UnmanagedType.IDispatch)] object progress)
        {
            // Check if we've cancelled
            if (backgroundBurnWorker.CancellationPending)
            {
                IDiscFormat2Data format2Data = (IDiscFormat2Data)sender;
                format2Data.CancelWrite();
            }
        }
        #endregion

        #region btnClose_Click
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region Form_Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            Dispose();
            GC.Collect();
            Cursor.Current = Cursors.Default;
        }
        #endregion

        #endregion

        #region Methods

        #region Boolean PrepareForm()
        /// <summary>
        /// تابعی برای آماده كردن اشیاء رایت كردن اطلاعات
        /// </summary>
        private Boolean PrepareForm()
        {
            MsftDiscMaster2 DiscMasterList = null;
            try
            {
                _burnData = new BurnData();
                DiscMasterList = new MsftDiscMaster2();
                if (!DiscMasterList.IsSupportedEnvironment)
                    throw new Exception("DiscMasterList.IsSupportedEnvironment return False.");
                foreach (String uniqueRecorderId in DiscMasterList)
                {
                    MsftDiscRecorder2 DiscRecorderItem = new MsftDiscRecorder2();
                    DiscRecorderItem.InitializeDiscRecorder(uniqueRecorderId);
                    cboDriveSelection.Items.Add(DiscRecorderItem);
                }
                if (cboDriveSelection.Items.Count > 0) cboDriveSelection.SelectedIndex = 0;
                else
                {
                    PMBox.Show("سیستم جاری دارای هیچ درایو مناسبی برای رایت سی دی نمی باشد!", "خطا!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
                }
            }
            #region Catch
            catch (COMException Ex)
            {
                LogManager.SaveLogEntry("Sepehr", "Documents - FileBurner Form", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error);
                PMBox.Show("یكی از اجزاء لازم برای رایت سی دی نصب نیست!\n" +
                    "با واحد پشتیبانی شركت تماس حاصل نمایید.", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
            }
            catch (Exception Ex)
            {
                LogManager.SaveLogEntry("Sepehr", "Documents - FileBurner Form", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error);
                PMBox.Show("خطا در اجرای فرم رایت سی دی!", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
            }
            #endregion
            finally
            {
                if (DiscMasterList != null) Marshal.ReleaseComObject(DiscMasterList);
            }
            DateTime now = DateTime.Now;
            txtCDLabel.Text = "RPN-" + now.Year + "-" + now.Month + "-" + now.Day;
            cboVerification.SelectedIndex = 0;
            btnCheckCurrentCD_Click(null, null);
            return true;
        }
        #endregion

        #region void UpdateCapacity()
        /// <summary>
        /// تابعی برای به روز رسانی ظرفیت سی دی
        /// </summary>
        private void UpdateCapacity()
        {
            if (_totalDiscSize == 0)
            {
                ProgressCheckCD.Maximum = 0;
                ProgressCheckCD.Text = "حجم خالی سی دی: 0 مگابایت";
                return;
            }
            ProgressCheckCD.Text = _totalDiscSize < 1000000000 ?
                String.Format("حجم خالی: {0} مگابایت", _totalDiscSize / 1000000) :
                String.Format("حجم خالی: {0:F2} گیگابایت", _totalDiscSize / 1000000000.0);

            Int64 FileSize = CalculateFilesSize();
            if (FileSize == 0) ProgressCheckCD.Value = 0;
            else
            {
                Int32 UsedPercent = Convert.ToInt32((FileSize * 100) / _totalDiscSize);
                if (UsedPercent > 100)
                {
                    ProgressCheckCD.Value = 100;
                    ProgressCheckCD.ColorTable = eProgressBarItemColor.Error;
                }
                else
                {
                    ProgressCheckCD.Value = UsedPercent;
                    ProgressCheckCD.ColorTable = eProgressBarItemColor.Paused;
                }
            }
        }
        #endregion

        #region Int64 CalculateFilesSize()
        /// <summary>
        /// تابعی برای محاسبه حجم فایل های مراجعه جاری برای رایت
        /// </summary>
        private Int64 CalculateFilesSize()
        {
            Int64 FileSize = 0;
            foreach (String ImageFile in _ImageFiles)
            {
                FileItem fileItem = new FileItem(ImageFile);
                FileSize += fileItem.SizeOnDisc;
            }
            foreach (String Video in _VideoFiles)
            {
                FileItem fileItem = new FileItem(Video);
                FileSize += fileItem.SizeOnDisc;
            }
            return FileSize;
        }
        #endregion

        #region static String GetMediaTypeString(IMAPI_MEDIA_PHYSICAL_TYPE mediaType)
        /// <summary>
        /// تبدیل IMAPI_MEDIA_PHYSICAL_TYPE به یك عبارت متنی
        /// </summary>
        private static String GetMediaTypeString(IMAPI_MEDIA_PHYSICAL_TYPE mediaType)
        {
            switch (mediaType)
            {
                default: return "سی دی نا شناخته";
                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_CDROM: return "CD-ROM";
                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_CDR: return "CD-R";
                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_CDRW: return "CD-RW";
                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_DVDROM: return "DVD ROM";
                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_DVDRAM: return "DVD-RAM";
                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_DVDPLUSR: return "DVD+R";
                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_DVDPLUSRW: return "DVD+RW";
                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_DVDPLUSR_DUALLAYER: return "DVD+R Dual Layer";
                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_DVDDASHR: return "DVD-R";
                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_DVDDASHRW: return "DVD-RW";
                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_DVDDASHR_DUALLAYER: return "DVD-R Dual Layer";
                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_DISK: return "random-access writes";
                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_DVDPLUSRW_DUALLAYER: return "DVD+RW DL";
                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_HDDVDROM: return "HD DVD-ROM";
                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_HDDVDR: return "HD DVD-R";
                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_HDDVDRAM: return "HD DVD-RAM";
                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_BDROM: return "Blu-ray DVD (BD-ROM)";
                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_BDR: return "Blu-ray media";
                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_BDRE: return "Blu-ray Rewritable media";
            }
        }
        #endregion

        #region void EnableBurnUI(Boolean enable)
        /// <summary>
        /// تابعی برای تنظیم ظاهر فرم در حالت رایت سی دی و اتمام آن
        /// </summary>
        private void EnableBurnUI(Boolean enable)
        {
            btnBurn.Text = enable ? "اجرا!" : "انصراف";
            btnCheckCurrentCD.Enabled = enable;
            cboDriveSelection.Enabled = enable;
            txtCDLabel.Enabled = enable;
            cBoxEjectCD.Enabled = enable;
            cboVerification.Enabled = enable;
        }
        #endregion

        #region Boolean CreateMediaFileSystem(...)
        private Boolean CreateMediaFileSystem(IDiscRecorder2 discRecorder, Object[] multisessionInterfaces, out IStream dataStream)
        {
            MsftFileSystemImage fileSystemImage = null;
            try
            {
                fileSystemImage = new MsftFileSystemImage();
                fileSystemImage.ChooseImageDefaults(discRecorder);
                fileSystemImage.FileSystemsToCreate = FsiFileSystems.FsiFileSystemJoliet | FsiFileSystems.FsiFileSystemISO9660;
                fileSystemImage.VolumeName = txtCDLabel.Text;
                fileSystemImage.Update += fileSystemImage_Update;
                // If multisessions, then import previous sessions
                if (multisessionInterfaces != null)
                {
                    fileSystemImage.MultisessionInterfaces = multisessionInterfaces;
                    fileSystemImage.ImportFileSystem();
                }
                // Get the image root
                IFsiDirectoryItem rootItem = fileSystemImage.Root;
                // Add Files and Directories to File System Image
                #region Adding Files
                if (_VideoFiles.Length == 0)
                    foreach (String ImageFile in _ImageFiles)
                    {
                        // Check if we've cancelled
                        if (backgroundBurnWorker.CancellationPending) break;
                        FileItem fileItem = new FileItem(ImageFile);
                        fileItem.AddToFileSystem(rootItem);
                    }
                else
                {
                    try
                    {
                        String RefRootPath = Negar.Medical.VideoCapture.CaptureHelper.GetRefDataFilesFolder(_CurrentRefID);
                        if (_WriteVCD)
                        {
                            if (Directory.Exists(RefRootPath + "\\TempVideoCD\\CDI"))
                                Directory.Delete(RefRootPath + "\\TempVideoCD\\CDI", true);
                            Directory.CreateDirectory(RefRootPath + "\\TempVideoCD\\CDI");
                            const String RootFolderPath = Negar.Medical.VideoCapture.CaptureHelper.TempFilesPath;
                            if (File.Exists(RootFolderPath + "\\CDI\\CDI_IMAG.RTF"))
                                File.Copy(RootFolderPath + "\\CDI\\CDI_IMAG.RTF", RefRootPath + "\\TempVideoCD\\CDI\\CDI_IMAG.RTF");
                            if (File.Exists(RootFolderPath + "\\CDI\\CDI_TEXT.FNT"))
                                File.Copy(RootFolderPath + "\\CDI\\CDI_TEXT.FNT", RefRootPath + "\\TempVideoCD\\CDI\\CDI_TEXT.FNT");
                            if (File.Exists(RootFolderPath + "\\CDI\\CDI_VCD.APP"))
                                File.Copy(RootFolderPath + "\\CDI\\CDI_VCD.APP", RefRootPath + "\\TempVideoCD\\CDI\\CDI_VCD.APP");
                            if (File.Exists(RootFolderPath + "\\CDI\\CDI_VCD.CFG"))
                                File.Copy(RootFolderPath + "\\CDI\\CDI_VCD.CFG", RefRootPath + "\\TempVideoCD\\CDI\\CDI_VCD.CFG");
                            if (Directory.Exists(RefRootPath + "\\TempVideoCD\\EXT"))
                                Directory.Delete(RefRootPath + "\\TempVideoCD\\EXT", true);
                            Directory.CreateDirectory(RefRootPath + "\\TempVideoCD\\EXT");
                            if (Directory.Exists(RefRootPath + "\\TempVideoCD\\MPEGAV"))
                                Directory.Delete(RefRootPath + "\\TempVideoCD\\MPEGAV", true);
                            Directory.CreateDirectory(RefRootPath + "\\TempVideoCD\\MPEGAV");
                            if (Directory.Exists(RefRootPath + "\\TempVideoCD\\Image"))
                                Directory.Delete(RefRootPath + "\\TempVideoCD\\Image", true);
                            Directory.CreateDirectory(RefRootPath + "\\TempVideoCD\\Image");
                            if (Directory.Exists(RefRootPath + "\\TempVideoCD\\SEGMENT"))
                                Directory.Delete(RefRootPath + "\\TempVideoCD\\SEGMENT", true);
                            Directory.CreateDirectory(RefRootPath + "\\TempVideoCD\\SEGMENT");
                            if (Directory.Exists(RefRootPath + "\\TempVideoCD\\VCD"))
                                Directory.Delete(RefRootPath + "\\TempVideoCD\\VCD", true);
                            Directory.CreateDirectory(RefRootPath + "\\TempVideoCD\\VCD");
                            if (File.Exists(RootFolderPath + "\\VCD\\ENTRIES.VCD"))
                                File.Copy(RootFolderPath + "\\VCD\\ENTRIES.VCD", RefRootPath + "\\TempVideoCD\\VCD\\ENTRIES.VCD");
                            if (File.Exists(RootFolderPath + "\\VCD\\INFO.VCD"))
                                File.Copy(RootFolderPath + "\\VCD\\INFO.VCD", RefRootPath + "\\TempVideoCD\\VCD\\INFO.VCD");
                            if (File.Exists(RootFolderPath + "\\VCD\\LOT.VCD"))
                                File.Copy(RootFolderPath + "\\VCD\\LOT.VCD", RefRootPath + "\\TempVideoCD\\VCD\\LOT.VCD");
                            if (File.Exists(RootFolderPath + "\\VCD\\PSD.VCD"))
                                File.Copy(RootFolderPath + "\\VCD\\PSD.VCD", RefRootPath + "\\TempVideoCD\\VCD\\PSD.VCD");
                            for (Int32 i = 0; i < _VideoFiles.Length; i++)
                            {
                                String NewPath = RefRootPath + "\\TempVideoCD\\MPEGAV\\AVSEQ0" + (i + 1) + ".DAT";
                                File.Copy(_VideoFiles[i], NewPath, true);
                            }
                            for (Int32 i = 0; i < _ImageFiles.Length; i++)
                            {
                                String NewPath = RefRootPath + "\\TempVideoCD\\Image\\Pic" + (i + 1) + ".Jpg";
                                File.Copy(_ImageFiles[i], NewPath, true);
                            }
                            // Check if we've cancelled
                            //if (backgroundBurnWorker.CancellationPending) return;
                            DirectoryItem DirectoryItem1 = new DirectoryItem(RefRootPath + "\\TempVideoCD\\CDI");
                            DirectoryItem1.AddToFileSystem(rootItem);
                            DirectoryItem DirectoryItem2 = new DirectoryItem(RefRootPath + "\\TempVideoCD\\EXT");
                            DirectoryItem2.AddToFileSystem(rootItem);
                            DirectoryItem DirectoryItem3 = new DirectoryItem(RefRootPath + "\\TempVideoCD\\MPEGAV");
                            DirectoryItem3.AddToFileSystem(rootItem);
                            DirectoryItem DirectoryItem4 = new DirectoryItem(RefRootPath + "\\TempVideoCD\\Image");
                            DirectoryItem4.AddToFileSystem(rootItem);
                            DirectoryItem DirectoryItem5 = new DirectoryItem(RefRootPath + "\\TempVideoCD\\SEGMENT");
                            DirectoryItem5.AddToFileSystem(rootItem);
                            DirectoryItem DirectoryItem6 = new DirectoryItem(RefRootPath + "\\TempVideoCD\\VCD");
                            DirectoryItem6.AddToFileSystem(rootItem);
                        }
                        else
                        {
                            if (Directory.Exists(RefRootPath + "\\TempData"))
                                Directory.Delete(RefRootPath + "\\TempData", true);
                            Directory.CreateDirectory(RefRootPath + "\\TempData");
                            for (Int32 i = 0; i < _VideoFiles.Length; i++)
                            {
                                String NewPath = RefRootPath + "\\TempData\\Video" + (i + 1) + ".Wmv";
                                File.Copy(_VideoFiles[i], NewPath, true);
                            }
                            for (Int32 i = 0; i < _ImageFiles.Length; i++)
                            {
                                String NewPath = RefRootPath + "\\TempData\\Pic" + (i + 1) + ".Jpg";
                                File.Copy(_ImageFiles[i], NewPath, true);
                            }
                            DirectoryItem DirectoryItem1 = new DirectoryItem(RefRootPath + "\\TempData");
                            DirectoryItem1.AddToFileSystem(rootItem);
                        }
                    }
                    #region Catch
                    catch (Exception Ex)
                    {
                        PMBox.Show("خطا در رایت دیسك!", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        MessageBox.Show(Ex.Message);
                    }
                    #endregion
                }
                #endregion

                fileSystemImage.Update -= fileSystemImage_Update;
                // did we cancel?
                if (backgroundBurnWorker.CancellationPending)
                {
                    dataStream = null;
                    return false;
                }
                dataStream = fileSystemImage.CreateResultImage().ImageStream;
            }
            catch (COMException exception)
            {

                MessageBox.Show(this, exception.Message, "Create File System Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataStream = null;
                return false;
            }
            finally
            {
                if (fileSystemImage != null) Marshal.ReleaseComObject(fileSystemImage);
            }
            return true;
        }
        #endregion

        #endregion

    }
}