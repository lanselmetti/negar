#region using
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Negar.DirectShow.Manager;
using Negar.DirectX.Capture.Manager;
#endregion

namespace CaptureTest
{
    public partial class CaptureTest : Form
    {

        #region Fields
        private const Int32 WM_GRAPHNOTIFY = 0x8000 + 1;
        private readonly Filters filters;
        private readonly TVSelections tvSelections = new TVSelections();
        private Capture _CaptureObject;
        private NumericUpDown channelUpDown1;
        private IContainer components;
        private Int32 DefaultChannel = 88;
        private Int32 DefaultCountryCode = 31;
        private Int32 DefaultTuningSpace;
#pragma warning disable 649
        private IMediaEventEx mediaEvent;
#pragma warning restore 649
        private TunerInputType tunerInputType = TunerInputType.Cable;
        private AMTunerModeType tunerModeType = AMTunerModeType.TV;
        private bool noChannelChange;
        private bool audioViaPci;
        private bool sampleGrabber;

        #endregion

        #region AMTunerModeType TunerModeType
        private AMTunerModeType TunerModeType
        {
            get { return tunerModeType; }
            set
            {
                tunerModeType = value;
                if ((_CaptureObject != null) && (_CaptureObject.Tuner != null))
                {
                    _CaptureObject.Tuner.AudioMode = value;
                    _CaptureObject.Tuner.InputType = tunerInputType;
                    _CaptureObject.Tuner.TuningSpace = DefaultTuningSpace;
                    _CaptureObject.Tuner.CountryCode = DefaultCountryCode;
                }

                if ((_CaptureObject != null) && (_CaptureObject.AllowSampleGrabber))
                {
                    menuSampleGrabber1.Visible = true;
                    menuSampleGrabber1.Enabled = true;
                }
                else
                {
                    menuSampleGrabber1.Visible = false;
                    menuSampleGrabber1.Enabled = false;
                }

                _CaptureObject.Tuner.Channel = DefaultChannel;
            }
        }
        #endregion

        #region TunerInputType TunerInputType
        private TunerInputType TunerInputType
        {
            set
            {
                tunerInputType = value;
                _CaptureObject.Tuner.InputType = value;
            }
        }
        #endregion

        #region Boolean AudioViaPci
        // Option to switch between audio via pci or wired audio connection
        // Default value is false (wired audio connection).

        /// <summary>
        /// Audio captured via Capture card in a PCI bus
        /// </summary>
        public Boolean AudioViaPci
        {
            get { return audioViaPci; }
            set
            {
                audioViaPci = value;
                menuAudioViaPci1.Checked = audioViaPci;
            }
        }
        #endregion

        #region Boolean SampleGrabber
        private Boolean SampleGrabber
        {
            get { return sampleGrabber; }
            set
            {
                if ((_CaptureObject != null) && (_CaptureObject.AllowSampleGrabber))
                    sampleGrabber = value;
                else sampleGrabber = false;
                menuSampleGrabber1.Checked = sampleGrabber;
                if (sampleGrabber)
                {
                    imageFileName.Visible = true;
                    button1.Visible = true;
                    btnSaveImage.Visible = true;
                    pictureBox1.Visible = true;
                    txtFilename.Visible = false;
                    btnCue.Visible = false;
                    btnStart.Visible = false;
                    btnStop.Visible = false;
                    if (_CaptureObject != null)
                    {
                        _CaptureObject.FrameEvent2 += CaptureDone;
                    }
                }
                else
                {
                    if (_CaptureObject != null)
                    {
                        _CaptureObject.DisableEvent();
                        _CaptureObject.FrameEvent2 -= CaptureDone;
                    }
                    imageFileName.Visible = false;
                    button1.Visible = false;
                    btnSaveImage.Visible = false;
                    pictureBox1.Visible = false;
                    txtFilename.Visible = true;
                    btnCue.Visible = true;
                    btnStart.Visible = true;
                    btnStop.Visible = true;
                }
            }
        }
        #endregion

        #region protected override void WndProc(ref Message m)
        // Media events are sent to use as windows messages
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                // If this is a windows media message
                case WM_GRAPHNOTIFY:
                    DsEvCode eventCode;

                    Int32 p1, p2;
                    Int32 hr = mediaEvent.GetEvent(out eventCode, out p1, out p2, 0);
                    while (hr == 0)
                    {
                        // Handle the event.
                        switch (eventCode)
                        {
                            case DsEvCode.ErrorAbort:
                                // The capture has been aborted
                                break;
                            case DsEvCode.FullScreenLost:
                                break;
                            default:
                                break;
                        }
                        // Release parms
                        mediaEvent.FreeEventParams(eventCode, p1, p2);

                        // check for additional events
                        hr = mediaEvent.GetEvent(out eventCode, out p1, out p2, 0);
                    }
                    break;

                // All other messages
                default:
                    try
                    {
                        // unhandled window message
                        base.WndProc(ref m);
                    }
                    catch
                    {
                        Debug.WriteLine("Fatal exception catching a message with WndProc()");
                    }
                    break;
            }
        }
        #endregion

        #region protected override void Dispose(bool disposing)
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        #endregion

        #region Ctor
        public CaptureTest()
        {
            InitializeComponent();

            // Start with the first video/audio devices
            // Don't do this in the Release build in case the
            // first devices cause problems.
            AudioViaPci = menuAudioViaPci1.Checked;
            try
            {
                filters = new Filters(true, true);
            }
            catch (Exception Ex1)
            {
                MessageBox.Show(Ex1.Message);
                try
                {
                    filters = new Filters(false, true);
                }
                catch (Exception Ex2)
                {
                    MessageBox.Show(Ex2.Message);
                    Close(); return;
                }
            }

            // Update the main menu
            // Much of the interesting work of this sample occurs here
            try
            {
                initMenu();
                updateMenu();
            }
            catch { }
            ShowDialog();
        }
        #endregion

        #region btnCue_Click
        private void btnCue_Click(object sender, EventArgs e)
        {
            try
            {
                if (_CaptureObject == null)
                    throw new ApplicationException("Please select a video and/or audio device.");
                if (!_CaptureObject.Cued)
                    _CaptureObject.Filename = txtFilename.Text;
                _CaptureObject.Cue();
                btnCue.Enabled = false;
                btnStop.Enabled = true;
                btnStart.Enabled = true;
                MessageBox.Show("Ready to capture.\n\nUse Cue() before Start() to " +
                                "do all the preparation work that needs to be done to start a " +
                                "capture. Now, when you click Start the capture will begin faster " +
                                "than if you had just clicked Start. Using Cue() is completely " +
                                "optional. The downside to using Cue() is the preview is disabled until " +
                                "the capture begins.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex);
            }
        }

        #endregion

        #region btnStart_Click
        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (_CaptureObject == null)
                    throw new ApplicationException("Please select a video and/or audio device.");
                if (!_CaptureObject.Cued)
                    _CaptureObject.Filename = txtFilename.Text;
                _CaptureObject.Start();
                btnCue.Enabled = false;
                btnStart.Enabled = false;
                btnStop.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex);
            }
        }
        #endregion

        #region btnStop_Click
        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                if (_CaptureObject == null)
                    throw new ApplicationException("Please select a video and/or audio device.");
                _CaptureObject.Stop();
                btnCue.Enabled = true;
                btnStart.Enabled = true;
                btnStop.Enabled = false;
                btnStop.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex);
            }
        }
        #endregion

        #region void initMenu()
        private void initMenu()
        {
            if (_CaptureObject != null)
            {
                // Show County Dependent settings to user
                ShowCountryDep();

                // Set flag only if capture device is initialized
                _CaptureObject.AllowSampleGrabber = menuAllowSampleGrabber1.Checked;
                menuSampleGrabber1.Enabled = menuAllowSampleGrabber1.Checked;
                menuSampleGrabber1.Visible = menuAllowSampleGrabber1.Checked;

                // Set flag only if capture device is initialized
                _CaptureObject.VideoSource = _CaptureObject.VideoSource;
                _CaptureObject.UseVMR9 = menuUseVMR9.Checked;
                menuUseDeInterlace1.Checked = FindDeinterlaceFilter(menuUseDeInterlace1.Checked);
            }
        }
        #endregion

        #region void updateMenu()
        private void updateMenu()
        {
            Source s;
            Source current;
            Filter f;
            PropertyPage p;
            Control oldPreviewWindow = null;

            // Disable preview to avoid additional flashes (optional)
            if (_CaptureObject != null)
            {
                oldPreviewWindow = _CaptureObject.PreviewWindow;
                _CaptureObject.PreviewWindow = null;
            }

            // Load video devices
            Filter videoDevice = null;
            if (_CaptureObject != null) videoDevice = _CaptureObject.VideoDevice;
            mnuVideoDevices.MenuItems.Clear();
            MenuItem m = new MenuItem("(None)", mnuVideoDevices_Click);
            m.Checked = (videoDevice == null);
            mnuVideoDevices.MenuItems.Add(m);
            for (Int32 c = 0; c < filters.VideoInputDevices.Count; c++)
            {
                f = filters.VideoInputDevices[c];
                m = new MenuItem(f.Name, mnuVideoDevices_Click);
                m.Checked = (videoDevice == f);
                mnuVideoDevices.MenuItems.Add(m);
            }
            mnuVideoDevices.Enabled = (filters.VideoInputDevices.Count > 0);

            // Load audio devices
            Filter audioDevice = null;
            if (_CaptureObject != null)
                audioDevice = _CaptureObject.AudioDevice;
            mnuAudioDevices.MenuItems.Clear();
            m = new MenuItem("(None)", mnuAudioDevices_Click);
            m.Checked = (audioDevice == null);
            mnuAudioDevices.MenuItems.Add(m);
            for (Int32 c = 0; c < filters.AudioInputDevices.Count; c++)
            {
                f = filters.AudioInputDevices[c];
                m = new MenuItem(f.Name, mnuAudioDevices_Click);
                m.Checked = (audioDevice == f);
                mnuAudioDevices.MenuItems.Add(m);
            }
            mnuAudioDevices.Enabled = (filters.AudioInputDevices.Count > 0);


            // Load video compressors
            try
            {
                mnuVideoCompressors.MenuItems.Clear();
                m = new MenuItem("(None)", mnuVideoCompressors_Click);
                m.Checked = (_CaptureObject.VideoCompressor == null);
                mnuVideoCompressors.MenuItems.Add(m);
                for (Int32 c = 0; c < filters.VideoCompressors.Count; c++)
                {
                    f = filters.VideoCompressors[c];
                    m = new MenuItem(f.Name, mnuVideoCompressors_Click);
                    m.Checked = (_CaptureObject.VideoCompressor == f);
                    mnuVideoCompressors.MenuItems.Add(m);
                }
                mnuVideoCompressors.Enabled = ((_CaptureObject.VideoDevice != null) && (filters.VideoCompressors.Count > 0));
            }
            catch
            {
                mnuVideoCompressors.Enabled = false;
            }
            // Load audio compressors
            try
            {
                mnuAudioCompressors.MenuItems.Clear();
                m = new MenuItem("(None)", mnuAudioCompressors_Click);
                m.Checked = (_CaptureObject.AudioCompressor == null);
                mnuAudioCompressors.MenuItems.Add(m);
                for (Int32 c = 0; c < filters.AudioCompressors.Count; c++)
                {
                    f = filters.AudioCompressors[c];
                    m = new MenuItem(f.Name, mnuAudioCompressors_Click);
                    m.Checked = (_CaptureObject.AudioCompressor == f);
                    mnuAudioCompressors.MenuItems.Add(m);
                }
                mnuAudioCompressors.Enabled = ((_CaptureObject.AudioAvailable) && (filters.AudioCompressors.Count > 0));
            }
            catch
            {
                mnuAudioCompressors.Enabled = false;
            }

            // Load video sources
            try
            {
                mnuVideoSources.MenuItems.Clear();
                _CaptureObject.VideoSources = null;
                current = _CaptureObject.VideoSource;
                for (Int32 c = 0; c < _CaptureObject.VideoSources.Count; c++)
                {
                    s = _CaptureObject.VideoSources[c];
                    m = new MenuItem(s.Name, mnuVideoSources_Click);
                    m.Checked = (current == s);
                    mnuVideoSources.MenuItems.Add(m);
                }
                mnuVideoSources.Enabled = (_CaptureObject.VideoSources.Count > 0);
                if (current != null) _CaptureObject.VideoSource = current;
            }
            catch
            {
                mnuVideoSources.Enabled = false;
            }

            // Load audio sources
            try
            {
                mnuAudioSources.MenuItems.Clear();
#if TEST
				if(this.capture.AudioSource == null)
				{
					this.capture.AudioSources = null;
					if(this.capture.AudioSources.Count > 0)
					{
					}
				}
#else
                _CaptureObject.AudioSources = null;
#endif
                current = _CaptureObject.AudioSource;
                for (Int32 c = 0; c < _CaptureObject.AudioSources.Count; c++)
                {
                    s = _CaptureObject.AudioSources[c];
                    m = new MenuItem(s.Name, mnuAudioSources_Click);
                    m.Checked = (current == s);
                    mnuAudioSources.MenuItems.Add(m);
                }
                mnuAudioSources.Enabled = (_CaptureObject.AudioSources.Count > 0);
            }
            catch
            {
                mnuAudioSources.Enabled = false;
            }

            // Start of new Brian's Low code, with some modifcations to make it more usable,
            // such as listing the available video standards and color spaces only.
            // Load video standards
            menuVideoStandard1.MenuItems.Clear();
            if ((_CaptureObject != null) &&
                (_CaptureObject.dxUtils != null) && (_CaptureObject.dxUtils.VideoDecoderAvail))
            {
                try
                {
                    menuVideoStandard1.MenuItems.Clear();
                    AnalogVideoStandard currentStandard = _CaptureObject.dxUtils.VideoStandard;
                    AnalogVideoStandard availableStandards = _CaptureObject.dxUtils.AvailableVideoStandards;
                    Int32 mask = 1;
                    while (mask <= (Int32)AnalogVideoStandard.PAL_N_COMBO)
                    {
                        Int32 avs = mask & (Int32)availableStandards;
                        if (avs != 0)
                        {
                            m = new MenuItem(((AnalogVideoStandard)avs).ToString(), menuVideoStandard1_Click);
                            m.Checked = (currentStandard == (AnalogVideoStandard)avs);
                            menuVideoStandard1.MenuItems.Add(m);
                        }
                        mask *= 2;
                    }
                    menuVideoStandard1.Enabled = true;
                }
                catch
                {
                    menuVideoStandard1.Enabled = false;
                }
            }
            else
            {
                menuVideoStandard1.Enabled = false;
            }

            // Load color spaces
            menuColorSpace1.MenuItems.Clear();
            if ((_CaptureObject != null) && (_CaptureObject.dxUtils != null))
            {
                try
                {
                    DxUtils.ColorSpaceEnum currentColorSpace = _CaptureObject.ColorSpace;
                    string[] names = _CaptureObject.dxUtils.SubTypeList;
                    foreach (string name in names)
                    {
                        m = new MenuItem(name, menuColorSpace1_Click);
                        m.Checked = (currentColorSpace ==
                                     (DxUtils.ColorSpaceEnum)Enum.Parse(typeof(DxUtils.ColorSpaceEnum), name));
                        menuColorSpace1.MenuItems.Add(m);
                    }
                    menuColorSpace1.Enabled = true;
                }
                catch
                {
                    menuColorSpace1.Enabled = false;
                }
            }
            else
            {
                menuColorSpace1.Enabled = false;
            }

            // End of new Brian's Low code

            // Load frame rates
            try
            {
                mnuFrameRates.MenuItems.Clear();
                var frameRate = (Int32)(_CaptureObject.FrameRate * 1000);
                m = new MenuItem("15 fps", mnuFrameRates_Click);
                m.Checked = (frameRate == 15000);
                mnuFrameRates.MenuItems.Add(m);
                m = new MenuItem("24 fps (Film)", mnuFrameRates_Click);
                m.Checked = (frameRate == 24000);
                mnuFrameRates.MenuItems.Add(m);
                m = new MenuItem("25 fps (PAL)", mnuFrameRates_Click);
                m.Checked = (frameRate == 25000);
                mnuFrameRates.MenuItems.Add(m);
                m = new MenuItem("29.997 fps (NTSC)", mnuFrameRates_Click);
                m.Checked = (frameRate == 29997);
                mnuFrameRates.MenuItems.Add(m);
                m = new MenuItem("30 fps (~NTSC)", mnuFrameRates_Click);
                m.Checked = (frameRate == 30000);
                mnuFrameRates.MenuItems.Add(m);
                m = new MenuItem("59.994 fps (2xNTSC)", mnuFrameRates_Click);
                m.Checked = (frameRate == 59994);
                mnuFrameRates.MenuItems.Add(m);
                mnuFrameRates.Enabled = true;
            }
            catch
            {
                mnuFrameRates.Enabled = false;
            }

            // Load frame sizes
            try
            {
                mnuFrameSizes.MenuItems.Clear();
                Size frameSize = _CaptureObject.FrameSize;
                m = new MenuItem("160 x 120", mnuFrameSizes_Click);
                m.Checked = (frameSize == new Size(160, 120));
                mnuFrameSizes.MenuItems.Add(m);
                m = new MenuItem("320 x 240", mnuFrameSizes_Click);
                m.Checked = (frameSize == new Size(320, 240));
                mnuFrameSizes.MenuItems.Add(m);

                // Added a Pal format ...
                m = new MenuItem("352 x 288", mnuFrameSizes_Click);
                m.Checked = (frameSize == new Size(352, 288));
                mnuFrameSizes.MenuItems.Add(m);

                m = new MenuItem("640 x 480", mnuFrameSizes_Click);
                m.Checked = (frameSize == new Size(640, 480));
                mnuFrameSizes.MenuItems.Add(m);

                // Added a Ntsc format ...
                m = new MenuItem("720 x 480", mnuFrameSizes_Click);
                m.Checked = (frameSize == new Size(720, 480));
                mnuFrameSizes.MenuItems.Add(m);
                mnuFrameSizes.Enabled = true;

                // Added some Pal formats ...
                m = new MenuItem("720 x 576", mnuFrameSizes_Click);
                m.Checked = (frameSize == new Size(720, 576));
                mnuFrameSizes.MenuItems.Add(m);
                m = new MenuItem("768 x 576", mnuFrameSizes_Click);
                m.Checked = (frameSize == new Size(768, 576));
                mnuFrameSizes.MenuItems.Add(m);
            }
            catch
            {
                mnuFrameSizes.Enabled = false;
            }

            // Load audio channels
            try
            {
                mnuAudioChannels.MenuItems.Clear();
                short audioChannels = _CaptureObject.AudioChannels;
                m = new MenuItem("Mono", mnuAudioChannels_Click);
                m.Checked = (audioChannels == 1);
                mnuAudioChannels.MenuItems.Add(m);
                m = new MenuItem("Stereo", mnuAudioChannels_Click);
                m.Checked = (audioChannels == 2);
                mnuAudioChannels.MenuItems.Add(m);
                mnuAudioChannels.Enabled = true;
                _CaptureObject.AudioSources = null;
            }
            catch
            {
                mnuAudioChannels.Enabled = false;
            }

            // Load audio sampling rate
            try
            {
                mnuAudioSamplingRate.MenuItems.Clear();
                Int32 samplingRate = _CaptureObject.AudioSamplingRate;
                m = new MenuItem("8 kHz", mnuAudioSamplingRate_Click);
                m.Checked = (samplingRate == 8000);
                mnuAudioSamplingRate.MenuItems.Add(m);
                m = new MenuItem("11,025 kHz", mnuAudioSamplingRate_Click);
                m.Checked = (_CaptureObject.AudioSamplingRate == 11025);
                mnuAudioSamplingRate.MenuItems.Add(m);
                m = new MenuItem("22,05 kHz", mnuAudioSamplingRate_Click);
                m.Checked = (_CaptureObject.AudioSamplingRate == 22050);
                mnuAudioSamplingRate.MenuItems.Add(m);
                m = new MenuItem("32 kHz", mnuAudioSamplingRate_Click);
                m.Checked = (_CaptureObject.AudioSamplingRate == 32000);
                mnuAudioSamplingRate.MenuItems.Add(m);
                m = new MenuItem("44,1 kHz", mnuAudioSamplingRate_Click);
                m.Checked = (_CaptureObject.AudioSamplingRate == 44100);
                mnuAudioSamplingRate.MenuItems.Add(m);
                m = new MenuItem("48 kHz", mnuAudioSamplingRate_Click);
                m.Checked = (_CaptureObject.AudioSamplingRate == 48000);
                mnuAudioSamplingRate.MenuItems.Add(m);
                mnuAudioSamplingRate.Enabled = true;
            }
            catch
            {
                mnuAudioSamplingRate.Enabled = false;
            }

            // Load audio sample sizes
            try
            {
                mnuAudioSampleSizes.MenuItems.Clear();
                short sampleSize = _CaptureObject.AudioSampleSize;
                m = new MenuItem("8 bit", mnuAudioSampleSizes_Click);
                m.Checked = (sampleSize == 8);
                mnuAudioSampleSizes.MenuItems.Add(m);
                m = new MenuItem("16 bit", mnuAudioSampleSizes_Click);
                m.Checked = (sampleSize == 16);
                mnuAudioSampleSizes.MenuItems.Add(m);
                mnuAudioSampleSizes.Enabled = true;
            }
            catch
            {
                mnuAudioSampleSizes.Enabled = false;
            }

            // Load property pages
            try
            {
                mnuPropertyPages.MenuItems.Clear();
                for (Int32 c = 0; c < _CaptureObject.PropertyPages.Count; c++)
                {
                    p = _CaptureObject.PropertyPages[c];
                    m = new MenuItem(p.Name + "...", mnuPropertyPages_Click);
                    mnuPropertyPages.MenuItems.Add(m);
                }
                mnuPropertyPages.Enabled = (_CaptureObject.PropertyPages.Count > 0);
            }
            catch
            {
                mnuPropertyPages.Enabled = false;
            }
            // Load TV Tuner channels
            try
            {
                mnuChannel.MenuItems.Clear();
                if (TunerModeType == AMTunerModeType.TV)
                {
                    Int32 current_channel = tvSelections.CurrentChannel;

                    for (Int32 c = 1; c <= tvSelections.NbrTunerChannels; c++)
                    {
                        tvSelections.CurrentChannel = c;
                        m = new MenuItem(tvSelections.GetChannelName, mnuChannel_Click);
                        m.Checked = ((current_channel == c) &&
                                     (_CaptureObject.Tuner.Channel == tvSelections.GetChannelNumber));
                        mnuChannel.MenuItems.Add(m);
                    }

                    tvSelections.CurrentChannel = current_channel;
                    //this.capture.Tuner.Channel = this.tvSelections.GetChannelNumber;

                    mnuChannel.Enabled = true;
                }
                else
                {
                    mnuChannel.Enabled = false;
                }
            }
            catch
            {
                mnuChannel.Enabled = false;
            }

            // Load Tuner Modes (such as TV and FM Radio
            try
            {
                menuTunerModes1.MenuItems.Clear();
                if ((_CaptureObject.Tuner.AvailableAudioModes.TV) &&
                    (_CaptureObject.Tuner.AvailableAudioModes.FMRadio))
                {
                    m = new MenuItem(AMTunerModeType.TV.ToString(), menuTunerModes1_Click);
                    m.Checked = (TunerModeType == AMTunerModeType.TV);
                    menuTunerModes1.MenuItems.Add(m);
                    m = new MenuItem(AMTunerModeType.FMRadio.ToString(), menuTunerModes1_Click);
                    m.Checked = (TunerModeType == AMTunerModeType.FMRadio);
                    m.Enabled = false;
                    menuTunerModes1.MenuItems.Add(m);

                    menuTunerModes1.Enabled = true;
                    menuTunerModes1.Visible = true;

                    //this.tvSelections.CurrentChannel = current_channel;
                    //this.capture.Tuner.SetFrequency(this.tvSelections.GetChannelFrequency);
                }
                else
                {
                    menuTunerModes1.Enabled = false;
                    menuTunerModes1.Visible = false;
                }
            }
            catch
            {
                menuTunerModes1.Enabled = false;
                menuTunerModes1.Visible = false;
            }

            // Load TV Tuner input types
            try
            {
                mnuInputType.MenuItems.Clear();
                m = new MenuItem(TunerInputType.Cable.ToString(), mnuInputType_Click);
                m.Checked = (_CaptureObject.Tuner.InputType == TunerInputType.Cable);
                mnuInputType.MenuItems.Add(m);
                m = new MenuItem(TunerInputType.Antenna.ToString(), mnuInputType_Click);
                m.Checked = (_CaptureObject.Tuner.InputType == TunerInputType.Antenna);
                mnuInputType.MenuItems.Add(m);
                mnuInputType.Enabled = true;
            }
            catch
            {
                mnuInputType.Enabled = false;
            }

            // Load audio/video recording file modes
            try
            {
                menuAVRecFileModes.MenuItems.Clear();

                // Fill in all file modes, use enumerations also as string (and file extension)
                for (Int32 i = 0; i < 3; i++)
                {
                    m = new MenuItem(((Capture.RecFileModeType)i).ToString(), menuAVRecFileModes_Click);
                    m.Checked = (i == (Int32)_CaptureObject.RecFileMode);
                    menuAVRecFileModes.MenuItems.Add(m);
                }
                menuAVRecFileModes.Enabled = true;
            }
            catch
            {
                menuAVRecFileModes.Enabled = false;
            }

            // Enable/disable caps
            mnuVideoCaps.Enabled = ((_CaptureObject != null) && (_CaptureObject.VideoCaps != null));
            menuPreviewCaps.Enabled = ((_CaptureObject != null) && (_CaptureObject.PreviewCaps != null));
            mnuAudioCaps.Enabled = ((_CaptureObject != null) && (_CaptureObject.AudioCaps != null));

            // Check Preview menu option
            mnuPreview.Checked = (oldPreviewWindow != null);
            mnuPreview.Enabled = (_CaptureObject != null);

            // Reenable preview if it was enabled before
            if (_CaptureObject != null)
                _CaptureObject.PreviewWindow = oldPreviewWindow;

            // Determine if the tuner status should be shown. Status is not
            // stable upon setting the TV broadcast frequency. Therefore it
            // the tuner status is shown at the end of this function.
            if (mnuChannel.Enabled)
            {
                string name = tvSelections.GetChannelName;
                if ((_CaptureObject != null) && (_CaptureObject.Tuner != null))
                {
                    if (_CaptureObject.Tuner != null)
                    {
                        noChannelChange = true;
                        Int32[] minmax = _CaptureObject.Tuner.ChanelMinMax;
                        channelUpDown1.Maximum = minmax[1];
                        channelUpDown1.Minimum = minmax[0];
                        channelUpDown1.Increment = 1;
                        if (DefaultChannel < minmax[0])
                        {
                            DefaultChannel = minmax[0];
                        }
                        if (DefaultChannel > minmax[1])
                        {
                            DefaultChannel = minmax[1];
                        }
                        channelUpDown1.Value = DefaultChannel;
                        noChannelChange = false;
                    }
                }
                if (DefaultChannel != tvSelections.GetChannelNumber)
                {
                    name = "Free choice";
                }
                SetTunerStatus(name);
            }
        }
        #endregion

        #region mnuVideoDevices_Click
        private void mnuVideoDevices_Click(object sender, EventArgs e)
        {
            try
            {
                // Get current devices and dispose of capture object
                // because the video and audio device can only be changed
                // by creating a new Capture object.
                Filter videoDevice = null;
                Filter audioDevice = null;

                // Dispose sample grabber data
                SampleGrabber = false;

                if (_CaptureObject != null)
                {
                    videoDevice = _CaptureObject.VideoDevice;
                    try
                    { audioDevice = _CaptureObject.AudioDevice; }
                    catch (Exception) { }

                    _CaptureObject.Dispose();
                    _CaptureObject = null;
                }

                // Get new video device
                MenuItem m = sender as MenuItem;
                if (m != null) videoDevice = (m.Index > 0 ? filters.VideoInputDevices[m.Index - 1] : null);

                // Create capture object
                if ((videoDevice != null) || (audioDevice != null))
                {
                    if (audioDevice == null) _CaptureObject = new Capture(videoDevice, null, false);
                    else _CaptureObject = new Capture(videoDevice, audioDevice, AudioViaPci);
                    _CaptureObject.CaptureComplete += OnCaptureComplete;
                    _CaptureObject.Filename = txtFilename.Text;
                    initMenu();
                }

                // Update the menu
                updateMenu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Video device not supported.\n\n" + ex.Message + "\n\n" + ex);
            }
        }
        #endregion

        #region mnuAudioDevices_Click
        private void mnuAudioDevices_Click(object sender, EventArgs e)
        {
            try
            {
                // Get current devices and dispose of capture object
                // because the video and audio device can only be changed
                // by creating a new Capture object.
                Filter videoDevice = null;
                Filter audioDevice = filters.AudioInputDevices[0];

                // Dispose sample grabber data
                SampleGrabber = false;

                if (_CaptureObject != null)
                {
                    videoDevice = _CaptureObject.VideoDevice;
                    audioDevice = _CaptureObject.AudioDevice;
                    _CaptureObject.Dispose();
                    _CaptureObject = null;
                }

                // Get new audio device
                MenuItem m = sender as MenuItem;
                if (m != null) audioDevice = (m.Index > 0 ? filters.AudioInputDevices[m.Index - 1] : null);

                // Create capture object
                if ((videoDevice != null))
                {
                    _CaptureObject = new Capture(videoDevice, audioDevice, AudioViaPci);
                    _CaptureObject.CaptureComplete += OnCaptureComplete;
                    _CaptureObject.Filename = txtFilename.Text;
                    initMenu();
                }

                // Update the menu
                updateMenu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Audio device not supported.\n\n" + ex.Message + "\n\n" + ex);
            }
        }
        #endregion

        #region mnuVideoCompressors_Click
        private void mnuVideoCompressors_Click(object sender, EventArgs e)
        {
            try
            {
                // Change the video compressor
                // We subtract 1 from m.Index beacuse the first item is (None)
                var m = sender as MenuItem;
                if (m != null)
                    _CaptureObject.VideoCompressor = (m.Index > 0 ? filters.VideoCompressors[m.Index - 1] : null);
                updateMenu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Video compressor not supported.\n\n" + ex.Message + "\n\n" + ex);
            }
        }
        #endregion

        #region mnuAudioCompressors_Click
        private void mnuAudioCompressors_Click(object sender, EventArgs e)
        {
            try
            {
                // Change the audio compressor
                // We subtract 1 from m.Index beacuse the first item is (None)
                var m = sender as MenuItem;
                if (m != null)
                    _CaptureObject.AudioCompressor = (m.Index > 0 ? filters.AudioCompressors[m.Index - 1] : null);
                updateMenu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Audio compressor not supported.\n\n" + ex.Message + "\n\n" + ex);
            }
        }
        #endregion

        #region mnuVideoSources_Click
        private void mnuVideoSources_Click(object sender, EventArgs e)
        {
            try
            {
                // Choose the video source
                // If the device only has one source, this menu item will be disabled
                MenuItem mnuNew = sender as MenuItem;
                _CaptureObject.VideoSources = null;
                if (mnuNew != null) _CaptureObject.VideoSource = _CaptureObject.VideoSources[mnuNew.Index];
                updateMenu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to set video source. Please submit bug report.\n\n" + ex.Message + "\n\n" + ex);
            }
        }
        #endregion

        #region mnuAudioSources_Click
        private void mnuAudioSources_Click(object sender, EventArgs e)
        {
            try
            {
                // Choose the audio source
                // If the device only has one source, this menu item will be disabled
                MenuItem m = sender as MenuItem;
                _CaptureObject.AudioSources = null;
                if (m != null) _CaptureObject.AudioSource = _CaptureObject.AudioSources[m.Index];
                updateMenu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to set audio source. Please submit bug report.\n\n" + ex.Message + "\n\n" + ex);
            }
        }
        #endregion

        #region mnuFrameSizes_Click
        private void mnuFrameSizes_Click(object sender, EventArgs e)
        {
            try
            {
                // Disable preview to avoid additional flashes (optional)
                bool preview = (_CaptureObject.PreviewWindow != null);
                _CaptureObject.PreviewWindow = null;

                // Update the frame size
                var m = sender as MenuItem;
                if (m != null)
                {
                    string[] s = m.Text.Split('x');
                    var size = new Size(Int32.Parse(s[0]), Int32.Parse(s[1]));
                    _CaptureObject.FrameSize = size;
                }

                // Restore previous preview setting
                _CaptureObject.PreviewWindow = (preview ? panelVideo : null);

                // Update the menu
                updateMenu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Frame size not supported.\n\n" + ex.Message + "\n\n" + ex);
            }
        }
        #endregion

        #region mnuFrameRates_Click
        private void mnuFrameRates_Click(object sender, EventArgs e)
        {
            try
            {
                MenuItem m = sender as MenuItem;
                if (m != null)
                {
                    string[] s = m.Text.Split(' ');
                    _CaptureObject.FrameRate = double.Parse(s[0]);
                }
                updateMenu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Frame rate not supported.\n\n" + ex.Message + "\n\n" + ex);
            }
        }
        #endregion

        #region mnuAudioChannels_Click
        private void mnuAudioChannels_Click(object sender, EventArgs e)
        {
            try
            {
                MenuItem m = sender as MenuItem;
                if (m != null) _CaptureObject.AudioChannels = (Int16)Math.Pow(2, m.Index);
                updateMenu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Number of audio channels not supported.\n\n" + ex.Message + "\n\n" + ex);
            }
        }
        #endregion

        #region mnuAudioSamplingRate_Click
        private void mnuAudioSamplingRate_Click(object sender, EventArgs e)
        {
            try
            {
                var m = sender as MenuItem;
                if (m != null)
                {
                    String[] s = m.Text.Split(' ');
                    // Parsing is country dependent, in European countries a number
                    // with a fraction are separated with a komma, in US this is a dot:
                    // 44,1 kHz in Europe versus 44.1 kHz in US
                    Int32 samplingRate = (Int32)(Double.Parse(s[0]) * 1000);
                    _CaptureObject.AudioSamplingRate = samplingRate;
                }
                updateMenu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Audio sampling rate not supported.\n\n" + ex.Message + "\n\n" + ex);
            }
        }
        #endregion

        #region mnuAudioSampleSizes_Click
        private void mnuAudioSampleSizes_Click(object sender, EventArgs e)
        {
            try
            {
                var m = sender as MenuItem;
                if (m != null)
                {
                    string[] s = m.Text.Split(' ');
                    short sampleSize = short.Parse(s[0]);
                    _CaptureObject.AudioSampleSize = sampleSize;
                }
                updateMenu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Audio sample size not supported.\n\n" + ex.Message + "\n\n" + ex);
            }
        }
        #endregion

        #region mnuPreview_Click
        private void mnuPreview_Click(object sender, EventArgs e)
        {
            try
            {
                if (_CaptureObject.PreviewWindow == null)
                {
                    _CaptureObject.PreviewWindow = panelVideo;
                    mnuPreview.Checked = true;
                }
                else
                {
                    _CaptureObject.PreviewWindow = null;
                    mnuPreview.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to enable/disable preview. Please submit a bug report.\n\n" + ex.Message + "\n\n" + ex);
            }
        }
        #endregion

        #region mnuPropertyPages_Click
        private void mnuPropertyPages_Click(object sender, EventArgs e)
        {
            try
            {
                MenuItem m = sender as MenuItem;
                _CaptureObject.PropertyPages = null;
                if (m != null) _CaptureObject.PropertyPages[m.Index].Show(this);

                if (m != null)
                    if (mnuPropertyPages.MenuItems[m.Index].Text == "TV Tuner...")
                    {
                        DefaultChannel = _CaptureObject.Tuner.Channel;
                        DefaultCountryCode = _CaptureObject.Tuner.CountryCode;
                        DefaultTuningSpace = _CaptureObject.Tuner.TuningSpace;
                        tunerInputType = _CaptureObject.Tuner.InputType;
                    }

                updateMenu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable display property page. Please submit a bug report.\n\n" +
                    ex.Message + "\n\n" + ex);
            }
        }
        #endregion

        #region mnuChannel_Click
        private void mnuChannel_Click(object sender, EventArgs e)
        {
            try
            {
                MenuItem m = sender as MenuItem;
                if (m != null) tvSelections.CurrentChannel = m.Index + 1;
                if ((_CaptureObject != null) && (_CaptureObject.Tuner != null))
                {
                    _CaptureObject.Tuner.Channel = tvSelections.GetChannelNumber;
                    DefaultChannel = _CaptureObject.Tuner.Channel;
                }

                updateMenu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable change channel. Please submit a bug report.\n\n" + ex.Message + "\n\n" + ex);
            }
        }
        #endregion

        #region menuTunerModes1_Click
        private void menuTunerModes1_Click(object sender, EventArgs e)
        {
            // Select selected Tuner Mode
            var m = sender as MenuItem;
            if (m != null)
                if (m.Text == AMTunerModeType.TV.ToString())
                {
                    // This is TV
                    TunerModeType = AMTunerModeType.TV;
                }

            // Temporary fix ...
            updateMenu();
        }
        #endregion

        #region mnuInputType_Click
        private void mnuInputType_Click(object sender, EventArgs e)
        {
            try
            {
                MenuItem m = sender as MenuItem;
                if (m != null) TunerInputType = (TunerInputType)m.Index;
                updateMenu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable change tuner input type. Please submit a bug report.\n\n" + ex.Message + "\n\n" + ex);
            }
        }
        #endregion

        #region mnuVideoCaps_Click
        private void mnuVideoCaps_Click(object sender, EventArgs e)
        {
            try
            {
                string s = String.Format(
                    "Video Device Capabilities\n" +
                    "--------------------------------\n\n" +
                    "Input Size:\t\t{0} x {1}\n" +
                    "\n" +
                    "Min Frame Size:\t\t{2} x {3}\n" +
                    "Max Frame Size:\t\t{4} x {5}\n" +
                    "Frame Size Granularity X:\t{6}\n" +
                    "Frame Size Granularity Y:\t{7}\n" +
                    "\n" +
                    "Min Frame Rate:\t\t{8:0.000} fps\n" +
                    "Max Frame Rate:\t\t{9:0.000} fps\n" +
                    "Video modes: {10}\n",
                    _CaptureObject.VideoCaps.InputSize.Width, _CaptureObject.VideoCaps.InputSize.Height,
                    _CaptureObject.VideoCaps.MinFrameSize.Width,
                    _CaptureObject.VideoCaps.MinFrameSize.Height,
                    _CaptureObject.VideoCaps.MaxFrameSize.Width,
                    _CaptureObject.VideoCaps.MaxFrameSize.Height,
                    _CaptureObject.VideoCaps.FrameSizeGranularityX,
                    _CaptureObject.VideoCaps.FrameSizeGranularityY,
                    _CaptureObject.VideoCaps.MinFrameRate,
                    _CaptureObject.VideoCaps.MaxFrameRate,
                    _CaptureObject.VideoCaps.AnalogVideoStandard);
                MessageBox.Show(s);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable display video capabilities. Please submit a bug report.\n\n" + ex.Message +
                                "\n\n" + ex);
            }
        }
        #endregion

        #region mnuAudioCaps_Click
        private void mnuAudioCaps_Click(object sender, EventArgs e)
        {
            try
            {
                string s = String.Format(
                    "Audio Device Capabilities\n" +
                    "--------------------------------\n\n" +
                    "Min Channels:\t\t{0}\n" +
                    "Max Channels:\t\t{1}\n" +
                    "Channels Granularity:\t{2}\n" +
                    "\n" +
                    "Min Sample Size:\t\t{3}\n" +
                    "Max Sample Size:\t\t{4}\n" +
                    "Sample Size Granularity:\t{5}\n" +
                    "\n" +
                    "Min Sampling Rate:\t\t{6}\n" +
                    "Max Sampling Rate:\t\t{7}\n" +
                    "Sampling Rate Granularity:\t{8}\n",
                    _CaptureObject.AudioCaps.MinimumChannels,
                    _CaptureObject.AudioCaps.MaximumChannels,
                    _CaptureObject.AudioCaps.ChannelsGranularity,
                    _CaptureObject.AudioCaps.MinimumSampleSize,
                    _CaptureObject.AudioCaps.MaximumSampleSize,
                    _CaptureObject.AudioCaps.SampleSizeGranularity,
                    _CaptureObject.AudioCaps.MinimumSamplingRate,
                    _CaptureObject.AudioCaps.MaximumSamplingRate,
                    _CaptureObject.AudioCaps.SamplingRateGranularity);
                MessageBox.Show(s);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable display audio capabilities. Please submit a bug report.\n\n" + ex.Message +
                                "\n\n" + ex);
            }
        }
        #endregion

        #region OnCaptureComplete
        private static void OnCaptureComplete(object sender, EventArgs e)
        {
            // Demonstrate the Capture.CaptureComplete event.
            Debug.WriteLine("Capture complete.");
        }
        #endregion

        #region menuAudioViaPci1_Click
        private void menuAudioViaPci1_Click(object sender, EventArgs e)
        {
            // Turn on/off option for getting Audio via Pci bus.
            // This option will work properly only after reloading
            // the audio or video device.
            AudioViaPci = !AudioViaPci;
        }
        #endregion

        #region menuAVRecFileModes_Click
        private void menuAVRecFileModes_Click(object sender, EventArgs e)
        {
            try
            {
                var m = sender as MenuItem;
                if (m != null) _CaptureObject.RecFileMode = (Capture.RecFileModeType)m.Index;
                txtFilename.Text = _CaptureObject.Filename;
                switch (_CaptureObject.RecFileMode)
                {
                    case Negar.DirectX.Capture.Manager.Capture.RecFileModeType.Wmv:
                    case Negar.DirectX.Capture.Manager.Capture.RecFileModeType.Wma:
                        menuAsfFileFormat.Enabled = true;
                        break;
                    case Negar.DirectX.Capture.Manager.Capture.RecFileModeType.Avi:
                        menuAsfFileFormat.Enabled = false;
                        break;
                    default:
                        break;
                }

                updateMenu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Audio sample size not supported.\n\n" + ex.Message + "\n\n" + ex);
            }
            updateMenu();
        }
        #endregion

        #region menuAsfFileFormat_Click
        private void menuAsfFileFormat_Click(object sender, EventArgs e)
        {
            if (_CaptureObject != null)
            {
                // Show form for Windows Media formats only
                switch (_CaptureObject.RecFileMode)
                {
                    case Negar.DirectX.Capture.Manager.Capture.RecFileModeType.Wmv:
                    case Negar.DirectX.Capture.Manager.Capture.RecFileModeType.Wma:
                        var asfForm = new AsfForm(_CaptureObject);
                        asfForm.ShowDialog(this);
                        updateMenu();
                        break;
                    default:
                        break;
                }
            }
        }
        #endregion

        #region txtFilename_TextChanged
        private void txtFilename_TextChanged(object sender, EventArgs e)
        {
            _CaptureObject.Filename = txtFilename.Text;
        }
        #endregion

        #region void SetTunerStatus(String channelName)
        private void SetTunerStatus(String channelName)
        {
            if (_CaptureObject != null)
            {
                if (_CaptureObject.Tuner != null)
                {
                    label3.Text = channelName;
                    try
                    {
                        // SignalPresent fails if this feature is not available
                        // or the tuner input is not used. Catch error so
                        // progrom will not fail.
                        if (_CaptureObject.Tuner.SignalPresent)
                        {
                            label3.Text = label3.Text + " (Signal)";
                        }
                    }
                    catch
                    {
                        // No signal present
                        Debug.WriteLine("This tuner does not support signal present!");
                    }
                }
            }
        }
        #endregion

        #region menuVideoRenderer1_Click
        private void menuVideoRenderer1_Click(object sender, EventArgs e)
        {
            // Try to show property page video renderer
            if (_CaptureObject != null)
            {
                _CaptureObject.ShowPropertyPage(1, this);
            }
        }
        #endregion

        #region Boolean FindDeinterlaceFilter(bool addFilter)
        private Boolean FindDeinterlaceFilter(bool addFilter)
        {
            if (addFilter)
            {
                const string filterName = "Alparysoft Deinterlace Filter";

                for (Int32 i = 0; i < filters.LegacyFilters.Count; i++)
                {
                    if (filters.LegacyFilters[i].Name.StartsWith(filterName))
                    {
                        _CaptureObject.DeInterlace = filters.LegacyFilters[i];
                        return true;
                    }
                }
            }

            // Either no de-interlace filter needs to be found
            // or no de-interlace filter could be found
            _CaptureObject.DeInterlace = null;
            return false;
        }
        #endregion

        #region menuDeInterlaceFilter1_Click
        private void menuDeInterlaceFilter1_Click(object sender, EventArgs e)
        {
            // Try to show property page DeInterlace Filter if selected
            if (_CaptureObject != null)
            {
                _CaptureObject.ShowPropertyPage(2, this);
            }
        }
        #endregion

        #region menuVideoStandard1_Click
        // Start of new Brian's Low code
        private void menuVideoStandard1_Click(object sender, EventArgs e)
        {
            if ((_CaptureObject == null) || (_CaptureObject.dxUtils == null)) return;
            try
            {
                MenuItem m = sender as MenuItem;
                if (m != null)
                {
                    AnalogVideoStandard a = (AnalogVideoStandard)Enum.Parse(typeof(AnalogVideoStandard), m.Text);
                    _CaptureObject.dxUtils.VideoStandard = a;
                }
                updateMenu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to set video standard.\n\n" + ex.Message + "\n\n" + ex);
            }
        }
        #endregion

        #region menuColorSpace1_Click
        private void menuColorSpace1_Click(object sender, EventArgs e)
        {
            try
            {
                MenuItem m = sender as MenuItem;
                if (m != null)
                {
                    DxUtils.ColorSpaceEnum c = (DxUtils.ColorSpaceEnum)Enum.Parse(typeof(DxUtils.ColorSpaceEnum), m.Text);
                    _CaptureObject.ColorSpace = c;
                }
                updateMenu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to set color space.\n\n" + ex.Message + "\n\n" + ex);
            }
        }
        #endregion

        #region menuPreviewCaps_Click
        private void menuPreviewCaps_Click(object sender, EventArgs e)
        {
            try
            {
                String s = String.Format(
                    "Video Preview Capabilities\n" +
                    "--------------------------------\n\n" +
                    "Input Size:\t\t{0} x {1}\n" +
                    "\n" +
                    "Min Frame Size:\t\t{2} x {3}\n" +
                    "Max Frame Size:\t\t{4} x {5}\n" +
                    "Frame Size Granularity X:\t{6}\n" +
                    "Frame Size Granularity Y:\t{7}\n" +
                    "\n" +
                    "Min Frame Rate:\t\t{8:0.000} fps\n" +
                    "Max Frame Rate:\t\t{9:0.000} fps\n",
                    _CaptureObject.PreviewCaps.InputSize.Width,
                    _CaptureObject.PreviewCaps.InputSize.Height,
                    _CaptureObject.PreviewCaps.MinFrameSize.Width,
                    _CaptureObject.PreviewCaps.MinFrameSize.Height,
                    _CaptureObject.PreviewCaps.MaxFrameSize.Width,
                    _CaptureObject.PreviewCaps.MaxFrameSize.Height,
                    _CaptureObject.PreviewCaps.FrameSizeGranularityX,
                    _CaptureObject.PreviewCaps.FrameSizeGranularityY,
                    _CaptureObject.PreviewCaps.MinFrameRate,
                    _CaptureObject.PreviewCaps.MaxFrameRate);
                MessageBox.Show(s);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable display video capabilities. Please submit a bug report.\n\n" + ex.Message +
                                "\n\n" + ex);
            }
        }
        #endregion

        #region void ShowCountryDep()
        private void ShowCountryDep()
        {
            if ((_CaptureObject != null) && (_CaptureObject.VideoDevice != null))
            {
                if ((_CaptureObject.Tuner == null) &&
                    ((_CaptureObject.dxUtils == null) ||
                     ((_CaptureObject.dxUtils != null) &&
                      (!_CaptureObject.dxUtils.VideoDecoderAvail))))
                {
                    return; // Nothing to do
                }
                CountryDep countryDep = new CountryDep();
                countryDep.Capture = _CaptureObject;
                countryDep.DefaultChannel = DefaultChannel;
                countryDep.DefaultTuningSpace = DefaultTuningSpace;
                countryDep.DefaultCountryCode = DefaultCountryCode;
                countryDep.DefaultInputType = tunerInputType;
                countryDep.ShowDialog(this);
                DefaultTuningSpace = countryDep.DefaultTuningSpace;
                DefaultCountryCode = countryDep.DefaultCountryCode;
                DefaultChannel = countryDep.DefaultChannel;
                tunerInputType = countryDep.DefaultInputType;
                countryDep.Dispose();
            }
        }
        #endregion

        #region channelUpDown1_ValueChanged
        private void channelUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (noChannelChange)
            {
                return;
            }
            if ((_CaptureObject != null) && (_CaptureObject.Tuner != null))
            {
                DefaultChannel = (Int32)channelUpDown1.Value;
                _CaptureObject.Tuner.Channel = DefaultChannel;
                updateMenu();
            }
        }
        #endregion

        #region void CaptureDone(Bitmap e)
        private void CaptureDone(Bitmap e)
        {
            pictureBox1.Image = e;
            // Show only the selected frame ...
            // If you want to capture all frames, then remove the next line
            //this.capture.FrameEvent2 -= new Capture.HeFrame(this.CaptureDone); 
        }
        #endregion

        #region btnSaveImage_Click
        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            if ((pictureBox1 != null) &&
                (pictureBox1.Image != null) &&
                (imageFileName.Text.Length > 0))
            {
                pictureBox1.Image.Save(imageFileName.Text, ImageFormat.Bmp);
            }
        }
        #endregion

        #region Other
        private void menuUseDeInterlace1_Click(object sender, EventArgs e)
        {
            menuUseDeInterlace1.Checked = !menuUseDeInterlace1.Checked;
        }

        private void txtFilename_DoubleClick(object sender, EventArgs e)
        {
            txtFilename_TextChanged(sender, e);
        }

        private void txtFilename_KeyDown(object sender, KeyEventArgs e)
        {
            txtFilename_TextChanged(sender, e);
        }

        private void menuUseVMR9_Click(object sender, EventArgs e)
        {
            menuUseVMR9.Checked = !menuUseVMR9.Checked;
        }

        private void menuAllowSampleGrabber1_Click(object sender, EventArgs e)
        {
            // Set flag, if set, then after reselection video device sample grabber
            // shows up in the menu.
            menuAllowSampleGrabber1.Checked = !menuAllowSampleGrabber1.Checked;
        }

        private void menuSampleGrabber1_Click(object sender, EventArgs e)
        {
            mnuPreview_Click(null, null);
            if (SampleGrabber) SampleGrabber = false;
            else SampleGrabber = true;
        }
        #endregion

    }
}