#region using
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Media;
using System.Text;
using System.Windows.Forms;
using Negar;
using DevComponents.DotNetBar;
using Microsoft.Win32;
using Negar.DirectShow.Manager;
using Negar.DirectX.Capture.Manager;
#endregion

namespace Negar.Medical.VideoCapture
{
    /// <summary>
    /// فرم ثبت ویدئو و تصاویر از ابزار ویدئویی
    /// </summary>
    internal partial class frmPanelClipGraber : Form
    {

        #region Fields

        #region Filters _Filters
        private Filters _Filters;
        #endregion

        #region Capture _CaptureObject
        private Capture _CaptureObject;
        #endregion

        #region Int32 _CurrentRefID
        private readonly Int32 _CurrentRefID;
        #endregion

        #region SerialPortManager _SerialPortManager
        private SerialPortManager _SerialPortManager;
        #endregion

        #region String _CaptureSetting
        /// <summary>
        /// كلید ذخیره سازی اطلاعات كام پورت برای كاربر جاری در رجیستری
        /// </summary>
        private const String _CaptureSetting =
            "Software\\Negar\\NegarCaptureVideoStandardSetting";
        #endregion

        #region String _CaptureVideoStandard
        private const String _CaptureVideoStandard = "VideoStandard";
        #endregion

        #region String _CaptureVideoSource
        private const String _CaptureVideoSource = "VideoSource";
        #endregion

        #endregion

        #region Ctor
        public frmPanelClipGraber(Int32 RefID)
        {
            InitializeComponent();
            Cursor.Current = Cursors.WaitCursor;
            if (!InitializeVideoDevices() || !InitializeVideoCompressors()) { Dispose(); return; }
            _CurrentRefID = RefID;
            _SerialPortManager = new SerialPortManager();
            _SerialPortManager.NewSerialDataRecieved += NewSerialDataRecieved;
        }
        #endregion

        #region Event Handlers

        #region MainForm_Shown
        private void MainForm_Shown(object sender, EventArgs e)
        {
            btnExit.Click += btnExit_Click;
            ((ButtonItem)lstVideoDevice.Items[0]).Checked = true;
            Opacity = 1;
            if (!_CaptureObject.Capturing)
            {
                String FilePath = CaptureHelper.GetVideoRefDataFilesFolderAndFile(_CurrentRefID);
                if (FilePath != String.Empty)
                {
                    _CaptureObject.Filename = FilePath;
                    _CaptureObject.Start();
                    TimerRecord.Start();
                }
            }
            btnGrab.Focus();
            btnGrab.Select();
            Cursor.Current = Cursors.Default;
            Focus();
            Activate();
            Select();
            TopMost = false;
            Cursor.Position = new Point(Left + btnGrab.Width / 2, Top + btnGrab.Top + btnGrab.Height);
        }
        #endregion

        #region NavPane_ExpandedChanged
        private void NavPane_ExpandedChanged(object sender, ExpandedChangeEventArgs e)
        {
            if (e.NewExpandedValue) Width = 890;
            else Width = 690;
        }
        #endregion

        #region btnVideoDevice_CheckedChanged
        void btnVideoDevice_CheckedChanged(object sender, EventArgs e)
        {
            if (!((ButtonItem)sender).Checked) return;
            try
            {
                if (_CaptureObject != null) { _CaptureObject.Dispose(); _CaptureObject = null; }
                Int32 DeviceIndex = lstVideoDevice.Items.IndexOf((ButtonItem)sender);
                // خواندن كارت ویدئو جاری
                Filter CurrentVideoDevice = _Filters.VideoInputDevices[DeviceIndex];
                Filter CurrentAudioDevice = null;
                if (_Filters.AudioInputDevices != null && _Filters.AudioInputDevices.Count > 0)
                    CurrentAudioDevice = _Filters.AudioInputDevices[0];
                // ایجاد شیء كپچر
                if (CurrentVideoDevice != null)
                {
                    try { _CaptureObject = new Capture(CurrentVideoDevice, CurrentAudioDevice, false); }
                    catch (Exception) { _CaptureObject = new Capture(CurrentVideoDevice, null, false); }
                    _CaptureObject.AllowSampleGrabber = true;
                    if (_CaptureObject.VideoSources != null && _CaptureObject.VideoSources.Count == 2)
                    {
                        Boolean Setting751 = false;
                        try
                        {
                            RegistryKey MyKey = Registry.CurrentUser.OpenSubKey(_CaptureSetting, true);
                            if (MyKey != null) Setting751 =
                                Convert.ToBoolean(MyKey.GetValue(_CaptureVideoSource, true));
                        }
                        catch (Exception) { }
                        if (Setting751)
                            _CaptureObject.VideoSource = _CaptureObject.VideoSources[0];
                        else _CaptureObject.VideoSource = _CaptureObject.VideoSources[1];
                    }
                    Boolean Setting750 = false;
                    try
                    {
                        RegistryKey MyKey = Registry.CurrentUser.OpenSubKey(_CaptureSetting, true);
                        if (MyKey != null) Setting750 =
                            Convert.ToBoolean(MyKey.GetValue(_CaptureVideoStandard, true));
                    }
                    catch (Exception) { }
                    if (Setting750)
                        _CaptureObject.dxUtils.VideoStandard = AnalogVideoStandard.PAL_B;
                    else _CaptureObject.dxUtils.VideoStandard = AnalogVideoStandard.NTSC_M;
                    _CaptureObject.FrameSize = new Size(_CaptureObject.VideoCaps.MaxFrameSize.Width,
                        _CaptureObject.VideoCaps.MaxFrameSize.Height);
                    _CaptureObject.FrameRate = _CaptureObject.VideoCaps.MaxFrameRate;
                }
            }
            #region Catch
            catch (Exception Ex)
            {
                MessageBox.Show("كارت ویدئو انتخاب شده پشتیبانی نمی شود!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Negar", "Medical Video Capture", Ex.Message, EventLogEntryType.Error);
                return;
            }
            #endregion
            foreach (ButtonItem btn in lstVideoDevice.Items)
                if (!btn.Name.Equals(((ButtonItem)sender).Name))
                {
                    btn.CheckedChanged -= btnVideoDevice_CheckedChanged;
                    btn.Checked = false;
                    btn.CheckedChanged += btnVideoDevice_CheckedChanged;
                }
            try
            {
                _CaptureObject.PreviewWindow = PreviewPanel;
                _CaptureObject.FrameEvent2 += CaptureDone;
            }
            #region Catch
            catch (Exception Ex)
            {
                MessageBox.Show("پیش نمایش ویدئو ممكن نیست!", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Negar", "Medical Video Capture", Ex.Message, EventLogEntryType.Error);
                return;
            }
            #endregion
        }
        #endregion

        #region btnVideoCompressor_CheckedChanged
        void btnVideoCompressor_CheckedChanged(object sender, EventArgs e)
        {
            if (!((ButtonItem)sender).Checked) return;
            Int32 CurrentIndex = lstVideoVideoCompressors.Items.IndexOf((ButtonItem)sender);
            if (CurrentIndex == 0) _CaptureObject.VideoCompressor = null;
            else
                try
                {
                    _CaptureObject.VideoCompressor = _Filters.VideoCompressors[CurrentIndex];
                }
                #region Catch
                catch (Exception Ex)
                {
                    MessageBox.Show("كارت ویدئو انتخاب شده فشرده سازی مورد نظر را پشتیبانی نمی كند!", "خطا!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogManager.SaveLogEntry("Negar", "Medical Video Capture", Ex.Message, EventLogEntryType.Error);
                    return;
                }
                #endregion
            foreach (ButtonItem btn in lstVideoVideoCompressors.Items)
                if (!btn.Name.Equals(((ButtonItem)sender).Name))
                {
                    btn.CheckedChanged -= btnVideoCompressor_CheckedChanged;
                    btn.Checked = false;
                    btn.CheckedChanged += btnVideoCompressor_CheckedChanged;
                }
        }
        #endregion

        #region pictureBox1_MouseClick
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            try
            {
                Int32 CurrentPicBoxIndex = PanelImages.Controls.IndexOf((PictureBox)sender);
                PictureBox CurrentPicBox = (PictureBox)PanelImages.Controls[CurrentPicBoxIndex];
                String Path = CurrentPicBox.Tag.ToString();
                CurrentPicBox.Image.Dispose();
                CurrentPicBox.Image = null;
                CurrentPicBox.InitialImage = null;
                File.Delete(Path);
                for (Int32 i = CurrentPicBoxIndex + 1; i < PanelImages.Controls.Count; i++)
                {
                    PictureBox NextPicBox = (PictureBox)PanelImages.Controls[i];
                    if (i % 2 == 0)
                    {
                        NextPicBox.Top -= 158;
                        NextPicBox.Left += 209;
                    }
                    else NextPicBox.Left -= 209;
                }
                CurrentPicBox.Dispose();
                PanelImages.Controls.Remove(((PictureBox)sender));
            }
            catch { }
        }
        #endregion

        #region NewSerialDataRecieved
        void NewSerialDataRecieved(object sender, SerialDataEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler<SerialDataEventArgs>(NewSerialDataRecieved), new[] { sender, e });
                return;
            }
            if (!String.IsNullOrEmpty(Encoding.ASCII.GetString(e.Data)))
                btnGrab_MouseClick(null, new MouseEventArgs(MouseButtons.Left, 1, 1, 1, 1));
        }
        #endregion

        #region btnAction_Click
        private void btnAction_Click(object sender, EventArgs e)
        {
            btnGrab_MouseClick(null, new MouseEventArgs(MouseButtons.Middle, 1, 0, 0, 0));
        }
        #endregion

        #region btnGrab_MouseClick
        private void btnGrab_MouseClick(object sender, MouseEventArgs e)
        {
            btnGrab.Enabled = false;
            Int32 GrabsCount = PanelImages.Controls.Count;
            PictureBox picBox = new PictureBox();
            PanelImages.Controls.Add(picBox);
            picBox.Name = "picBox" + (GrabsCount + 1);
            picBox.SizeMode = PictureBoxSizeMode.Zoom;
            picBox.Size = new Size(200, 150);
            picBox.MouseClick += pictureBox1_MouseClick;
            if (GrabsCount % 2 == 0)
            {
                picBox.Left = 18;
                picBox.Top = (158 * GrabsCount / 2) + 8;
            }
            else
            {
                picBox.Left = 227;
                picBox.Top = (158 * (GrabsCount - 1) / 2) + 8;
            }
            SystemSounds.Asterisk.Play();
            _CaptureObject.GrapImg();
            System.Threading.Thread.Sleep(1000);
            btnGrab.Enabled = true;
        }

        #endregion

        #region CaptureDone(Bitmap e)
        private void CaptureDone(Bitmap e)
        {
            if (!CaptureHelper.CheckCaptureDataFilesFolder()) return;
            if (!CaptureHelper.CheckCaptureRefDataFilesFolder(_CurrentRefID)) return;
            String PicPath = CaptureHelper.TempFilesPath + "\\" + _CurrentRefID + "\\" +
                DateTime.Now.ToString("yyyyMMdd-HHmmss") + ".Jpg";
            e.Save(PicPath);
            ((PictureBox)PanelImages.Controls[PanelImages.Controls.Count - 1]).Image = Image.FromFile(PicPath);
            PanelImages.Controls[PanelImages.Controls.Count - 1].Tag = PicPath;
        }
        #endregion

        #region TimerRecord_Tick
        private void TimerRecord_Tick(object sender, EventArgs e)
        {
            Int32 curentTimeSecond = Convert.ToInt32(lblTimer.Tag) + 1;
            Int32 Minute = curentTimeSecond / 60;
            Int32 Second = curentTimeSecond % 60;
            if (Minute == 0) lblTimer.Text = "00:" + Second;
            else lblTimer.Text = Minute + ":" + Second;
            lblTimer.Tag = Convert.ToInt32(lblTimer.Tag) + 1;
        }
        #endregion
        
        #region btnExit_Click
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region MainForm_FormClosed
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TimerRecord.Stop();
            Enabled = false;
            _SerialPortManager.NewSerialDataRecieved += (NewSerialDataRecieved);
            _SerialPortManager.Dispose();
            _SerialPortManager = null;
            for (Int32 i = 0; i < PanelImages.Controls.Count; i++)
            {
                PictureBox PicBox = ((PictureBox)PanelImages.Controls[i]);
                if (PicBox.Image != null) PicBox.Image.Dispose();
                PicBox.Image = null;
                PicBox.InitialImage = null;
            }
            if (_CaptureObject != null)
            {
                _CaptureObject.Stop();
                _CaptureObject.Dispose();
                _CaptureObject = null;
            }
            _Filters = null;
            foreach (ButtonItem btn in lstVideoDevice.Items) btn.Checked = false;
            Dispose();
        }
        #endregion

        #endregion

        #region Methods

        #region Boolean InitializeVideoDevices()
        /// <summary>
        /// تابع خواندن ابزارهای ویدئویی متصل به سیستم جاری
        /// </summary>
        /// <returns>صحت خواندن اطلاعات</returns>
        private Boolean InitializeVideoDevices()
        {
            try
            {
                _Filters = new Filters(true, true);
                if (_Filters.VideoInputDevices.Count == 0)
                {
                    PMBox.Show("ابزار دریافت ویدئو پیدا نشد!", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                for (Int32 i = 0; i < _Filters.VideoInputDevices.Count; i++)
                {
                    Filter filter = _Filters.VideoInputDevices[i];
                    ButtonItem btn = new ButtonItem();
                    btn.Name = "VideoDevice" + i;
                    btn.Text = filter.Name;
                    btn.FontBold = true;
                    btn.Checked = false;
                    btn.AutoCheckOnClick = true;
                    btn.CheckedChanged += btnVideoDevice_CheckedChanged;
                    lstVideoDevice.Items.Add(btn);
                }
            }
            #region Catch
            catch (Exception Ex)
            {
                PMBox.Show("خطا در خواندن سخت افزارهای دریافت ویدئو!", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Negar", "Medical Video Capture", Ex.Message, EventLogEntryType.Error);
                return false;
            }
            #endregion
            return true;
        }
        #endregion

        #region Boolean InitializeVideoCompressors()
        private Boolean InitializeVideoCompressors()
        {
            try
            {
                for (Int32 i = 0; i < _Filters.VideoCompressors.Count; i++)
                {
                    Filter filter = _Filters.VideoCompressors[i];
                    ButtonItem btn = new ButtonItem();
                    btn.Name = "VideoCompressor" + i;
                    btn.Text = filter.Name;
                    btn.FontBold = true;
                    btn.AutoCheckOnClick = true;
                    btn.Checked = false;
                    btn.CheckedChanged += btnVideoCompressor_CheckedChanged;
                    lstVideoVideoCompressors.Items.Add(btn);
                }
            }
            #region Catch
            catch (Exception Ex)
            {
                PMBox.Show("خطا در خواندن استانداردهی افشرده سازی ویدئو!", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Negar", "Medical Video Capture", Ex.Message, EventLogEntryType.Error);
            }
            #endregion
            return true;
        }
        #endregion

        #endregion

    }
}