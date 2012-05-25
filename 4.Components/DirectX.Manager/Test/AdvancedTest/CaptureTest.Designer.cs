using System.Windows.Forms;

namespace CaptureTest
{
    partial class CaptureTest
    {
        #region Fields
        private Button btnCue;
        private Button btnStart;
        private Button btnStop;
        private Button button1;
        private Button btnSaveImage;
        private TextBox imageFileName;
        private Panel MainPanel;
        private Label label1;
        private Label label3;
        private Label labelTvChannel1;
        private MainMenu mainMenu;
        private MenuItem menuAllowSampleGrabber1;
        private MenuItem menuAsfFileFormat;
        private MenuItem menuAudioViaPci1;
        private MenuItem menuAVRecFileModes;
        private MenuItem menuColorSpace1;
        private MenuItem menuDeInterlaceFilter1;
        private MenuItem menuItem1;
        private MenuItem menuItem2;
        private MenuItem menuItem3;
        private MenuItem menuItem4;
        private MenuItem menuItem5;
        private MenuItem menuItem6;
        private MenuItem menuItem7;
        private MenuItem menuItem8;
        private MenuItem menuItem9;
        private MenuItem menuPreviewCaps;
        private MenuItem menuSampleGrabber1;
        private MenuItem menuTunerModes1;
        private MenuItem menuUseDeInterlace1;
        private MenuItem menuUseVMR9;
        private MenuItem menuVidCapSettings1;
        private MenuItem menuVideoRenderer1;
        private MenuItem menuVideoStandard1;
        private MenuItem menuVidPrevSettings1;
        private MenuItem mnuAudioCaps;
        private MenuItem mnuAudioChannels;
        private MenuItem mnuAudioCompressors;
        private MenuItem mnuAudioDevices;
        private MenuItem mnuAudioSampleSizes;
        private MenuItem mnuAudioSamplingRate;
        private MenuItem mnuAudioSources;
        private MenuItem mnuChannel;
        private MenuItem mnuDevices;
        private MenuItem mnuExit;
        private MenuItem mnuFrameRates;
        private MenuItem mnuFrameSizes;
        private MenuItem mnuInputType;
        private MenuItem mnuPreview;
        private MenuItem mnuPropertyPages;
        private MenuItem mnuVideoCaps;
        private MenuItem mnuVideoCompressors;
        private MenuItem mnuVideoDevices;
        private MenuItem mnuVideoSources;
        private Panel panelVideo;
        private PictureBox pictureBox1;
        private TextBox txtFilename;

        #endregion


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CaptureTest));
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuAVRecFileModes = new System.Windows.Forms.MenuItem();
            this.menuAsfFileFormat = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.mnuExit = new System.Windows.Forms.MenuItem();
            this.mnuDevices = new System.Windows.Forms.MenuItem();
            this.mnuVideoDevices = new System.Windows.Forms.MenuItem();
            this.mnuAudioDevices = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.mnuVideoCompressors = new System.Windows.Forms.MenuItem();
            this.mnuAudioCompressors = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuAudioViaPci1 = new System.Windows.Forms.MenuItem();
            this.menuAllowSampleGrabber1 = new System.Windows.Forms.MenuItem();
            this.menuUseVMR9 = new System.Windows.Forms.MenuItem();
            this.menuUseDeInterlace1 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.mnuPreview = new System.Windows.Forms.MenuItem();
            this.mnuChannel = new System.Windows.Forms.MenuItem();
            this.menuSampleGrabber1 = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.mnuVideoSources = new System.Windows.Forms.MenuItem();
            this.menuVideoStandard1 = new System.Windows.Forms.MenuItem();
            this.menuVidCapSettings1 = new System.Windows.Forms.MenuItem();
            this.mnuFrameSizes = new System.Windows.Forms.MenuItem();
            this.mnuFrameRates = new System.Windows.Forms.MenuItem();
            this.menuColorSpace1 = new System.Windows.Forms.MenuItem();
            this.mnuVideoCaps = new System.Windows.Forms.MenuItem();
            this.menuVidPrevSettings1 = new System.Windows.Forms.MenuItem();
            this.menuPreviewCaps = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.mnuAudioSources = new System.Windows.Forms.MenuItem();
            this.mnuAudioChannels = new System.Windows.Forms.MenuItem();
            this.mnuAudioSamplingRate = new System.Windows.Forms.MenuItem();
            this.mnuAudioSampleSizes = new System.Windows.Forms.MenuItem();
            this.mnuAudioCaps = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.mnuInputType = new System.Windows.Forms.MenuItem();
            this.menuTunerModes1 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.mnuPropertyPages = new System.Windows.Forms.MenuItem();
            this.menuVideoRenderer1 = new System.Windows.Forms.MenuItem();
            this.menuDeInterlaceFilter1 = new System.Windows.Forms.MenuItem();
            this.panelVideo = new System.Windows.Forms.Panel();
            this.btnCue = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.channelUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.labelTvChannel1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSaveImage = new System.Windows.Forms.Button();
            this.imageFileName = new System.Windows.Forms.TextBox();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.channelUpDown1)).BeginInit();
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFilename
            // 
            this.txtFilename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtFilename.Location = new System.Drawing.Point(16, 367);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(268, 20);
            this.txtFilename.TabIndex = 0;
            this.txtFilename.Text = "C:\\TestMovie.wmv";
            this.txtFilename.DoubleClick += new System.EventHandler(this.txtFilename_DoubleClick);
            this.txtFilename.TextChanged += new System.EventHandler(this.txtFilename_TextChanged);
            this.txtFilename.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFilename_KeyDown);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Location = new System.Drawing.Point(12, 346);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Filename:";
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStart.Location = new System.Drawing.Point(100, 417);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(80, 24);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(186, 417);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(80, 24);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "Stop";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.mnuDevices,
            this.menuItem7});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuAVRecFileModes,
            this.menuAsfFileFormat,
            this.menuItem9,
            this.mnuExit});
            this.menuItem1.Text = "File";
            // 
            // menuAVRecFileModes
            // 
            this.menuAVRecFileModes.Index = 0;
            this.menuAVRecFileModes.Text = "File recording &mode";
            // 
            // menuAsfFileFormat
            // 
            this.menuAsfFileFormat.Index = 1;
            this.menuAsfFileFormat.Text = "File audio/video format";
            this.menuAsfFileFormat.Click += new System.EventHandler(this.menuAsfFileFormat_Click);
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 2;
            this.menuItem9.Text = "-";
            // 
            // mnuExit
            // 
            this.mnuExit.Index = 3;
            this.mnuExit.Text = "E&xit";
            // 
            // mnuDevices
            // 
            this.mnuDevices.Index = 1;
            this.mnuDevices.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuVideoDevices,
            this.mnuAudioDevices,
            this.menuItem4,
            this.mnuVideoCompressors,
            this.mnuAudioCompressors,
            this.menuItem2,
            this.menuAudioViaPci1,
            this.menuAllowSampleGrabber1,
            this.menuUseVMR9,
            this.menuUseDeInterlace1});
            this.mnuDevices.Text = "Devices";
            // 
            // mnuVideoDevices
            // 
            this.mnuVideoDevices.Index = 0;
            this.mnuVideoDevices.Text = "Video Devices";
            // 
            // mnuAudioDevices
            // 
            this.mnuAudioDevices.Index = 1;
            this.mnuAudioDevices.Text = "Audio Devices";
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 2;
            this.menuItem4.Text = "-";
            // 
            // mnuVideoCompressors
            // 
            this.mnuVideoCompressors.Index = 3;
            this.mnuVideoCompressors.Text = "Video Compressors";
            // 
            // mnuAudioCompressors
            // 
            this.mnuAudioCompressors.Index = 4;
            this.mnuAudioCompressors.Text = "Audio Compressors";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 5;
            this.menuItem2.Text = "-";
            // 
            // menuAudioViaPci1
            // 
            this.menuAudioViaPci1.Index = 6;
            this.menuAudioViaPci1.Text = "Audio via Pci";
            this.menuAudioViaPci1.Click += new System.EventHandler(this.menuAudioViaPci1_Click);
            // 
            // menuAllowSampleGrabber1
            // 
            this.menuAllowSampleGrabber1.Checked = true;
            this.menuAllowSampleGrabber1.Index = 7;
            this.menuAllowSampleGrabber1.Text = "Allow SampleGrabber";
            this.menuAllowSampleGrabber1.Click += new System.EventHandler(this.menuAllowSampleGrabber1_Click);
            // 
            // menuUseVMR9
            // 
            this.menuUseVMR9.Index = 8;
            this.menuUseVMR9.Text = "Use VMR9";
            this.menuUseVMR9.Click += new System.EventHandler(this.menuUseVMR9_Click);
            // 
            // menuUseDeInterlace1
            // 
            this.menuUseDeInterlace1.Index = 9;
            this.menuUseDeInterlace1.Text = "Use DeInterlace";
            this.menuUseDeInterlace1.Click += new System.EventHandler(this.menuUseDeInterlace1_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 2;
            this.menuItem7.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuPreview,
            this.mnuChannel,
            this.menuSampleGrabber1,
            this.menuItem8,
            this.mnuVideoSources,
            this.menuVideoStandard1,
            this.menuVidCapSettings1,
            this.menuVidPrevSettings1,
            this.menuItem5,
            this.mnuAudioSources,
            this.mnuAudioChannels,
            this.mnuAudioSamplingRate,
            this.mnuAudioSampleSizes,
            this.mnuAudioCaps,
            this.menuItem3,
            this.mnuInputType,
            this.menuTunerModes1,
            this.menuItem6,
            this.mnuPropertyPages,
            this.menuVideoRenderer1,
            this.menuDeInterlaceFilter1});
            this.menuItem7.Text = "Options";
            // 
            // mnuPreview
            // 
            this.mnuPreview.Index = 0;
            this.mnuPreview.Text = "Preview";
            this.mnuPreview.Click += new System.EventHandler(this.mnuPreview_Click);
            // 
            // mnuChannel
            // 
            this.mnuChannel.Index = 1;
            this.mnuChannel.Text = "TV Tuner Channel";
            // 
            // menuSampleGrabber1
            // 
            this.menuSampleGrabber1.Checked = true;
            this.menuSampleGrabber1.Index = 2;
            this.menuSampleGrabber1.Text = "Sample Grabber";
            this.menuSampleGrabber1.Click += new System.EventHandler(this.menuSampleGrabber1_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 3;
            this.menuItem8.Text = "-";
            // 
            // mnuVideoSources
            // 
            this.mnuVideoSources.Index = 4;
            this.mnuVideoSources.Text = "Video Sources";
            // 
            // menuVideoStandard1
            // 
            this.menuVideoStandard1.Index = 5;
            this.menuVideoStandard1.Text = "Video Standard";
            // 
            // menuVidCapSettings1
            // 
            this.menuVidCapSettings1.Index = 6;
            this.menuVidCapSettings1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuFrameSizes,
            this.mnuFrameRates,
            this.menuColorSpace1,
            this.mnuVideoCaps});
            this.menuVidCapSettings1.Text = "Video Capture Settings";
            this.menuVidCapSettings1.Click += new System.EventHandler(this.mnuVideoCaps_Click);
            // 
            // mnuFrameSizes
            // 
            this.mnuFrameSizes.Index = 0;
            this.mnuFrameSizes.Text = "Video Frame Size";
            // 
            // mnuFrameRates
            // 
            this.mnuFrameRates.Index = 1;
            this.mnuFrameRates.Text = "Video Frame Rate";
            // 
            // menuColorSpace1
            // 
            this.menuColorSpace1.Index = 2;
            this.menuColorSpace1.Text = "Color Space";
            // 
            // mnuVideoCaps
            // 
            this.mnuVideoCaps.Index = 3;
            this.mnuVideoCaps.Text = "Video Capabilities...";
            this.mnuVideoCaps.Click += new System.EventHandler(this.mnuVideoCaps_Click);
            // 
            // menuVidPrevSettings1
            // 
            this.menuVidPrevSettings1.Index = 7;
            this.menuVidPrevSettings1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuPreviewCaps});
            this.menuVidPrevSettings1.Text = "Video Preview Settings";
            // 
            // menuPreviewCaps
            // 
            this.menuPreviewCaps.Index = 0;
            this.menuPreviewCaps.Text = "Video Capabilities";
            this.menuPreviewCaps.Click += new System.EventHandler(this.menuPreviewCaps_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 8;
            this.menuItem5.Text = "-";
            // 
            // mnuAudioSources
            // 
            this.mnuAudioSources.Index = 9;
            this.mnuAudioSources.Text = "Audio Sources";
            // 
            // mnuAudioChannels
            // 
            this.mnuAudioChannels.Index = 10;
            this.mnuAudioChannels.Text = "Audio Channels";
            // 
            // mnuAudioSamplingRate
            // 
            this.mnuAudioSamplingRate.Index = 11;
            this.mnuAudioSamplingRate.Text = "Audio Sampling Rate";
            // 
            // mnuAudioSampleSizes
            // 
            this.mnuAudioSampleSizes.Index = 12;
            this.mnuAudioSampleSizes.Text = "Audio Sample Size";
            // 
            // mnuAudioCaps
            // 
            this.mnuAudioCaps.Index = 13;
            this.mnuAudioCaps.Text = "Audio Capabilities...";
            this.mnuAudioCaps.Click += new System.EventHandler(this.mnuAudioCaps_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 14;
            this.menuItem3.Text = "-";
            // 
            // mnuInputType
            // 
            this.mnuInputType.Index = 15;
            this.mnuInputType.Text = "TV Tuner Input Type";
            this.mnuInputType.Click += new System.EventHandler(this.mnuInputType_Click);
            // 
            // menuTunerModes1
            // 
            this.menuTunerModes1.Index = 16;
            this.menuTunerModes1.Text = "TV Tuner Mode";
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 17;
            this.menuItem6.Text = "-";
            // 
            // mnuPropertyPages
            // 
            this.mnuPropertyPages.Index = 18;
            this.mnuPropertyPages.Text = "PropertyPages";
            // 
            // menuVideoRenderer1
            // 
            this.menuVideoRenderer1.Index = 19;
            this.menuVideoRenderer1.Text = "Video Renderer";
            this.menuVideoRenderer1.Click += new System.EventHandler(this.menuVideoRenderer1_Click);
            // 
            // menuDeInterlaceFilter1
            // 
            this.menuDeInterlaceFilter1.Index = 20;
            this.menuDeInterlaceFilter1.Text = "DeInterlace Filter";
            this.menuDeInterlaceFilter1.Click += new System.EventHandler(this.menuDeInterlaceFilter1_Click);
            // 
            // panelVideo
            // 
            this.panelVideo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelVideo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelVideo.Location = new System.Drawing.Point(12, 12);
            this.panelVideo.Name = "panelVideo";
            this.panelVideo.Size = new System.Drawing.Size(473, 308);
            this.panelVideo.TabIndex = 6;
            // 
            // btnCue
            // 
            this.btnCue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCue.Location = new System.Drawing.Point(14, 417);
            this.btnCue.Name = "btnCue";
            this.btnCue.Size = new System.Drawing.Size(80, 24);
            this.btnCue.TabIndex = 8;
            this.btnCue.Text = "Cue";
            this.btnCue.Click += new System.EventHandler(this.btnCue_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.Location = new System.Drawing.Point(13, 324);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(271, 22);
            this.label3.TabIndex = 11;
            this.label3.Text = "Status";
            // 
            // channelUpDown1
            // 
            this.channelUpDown1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.channelUpDown1.Location = new System.Drawing.Point(396, 388);
            this.channelUpDown1.Name = "channelUpDown1";
            this.channelUpDown1.Size = new System.Drawing.Size(80, 20);
            this.channelUpDown1.TabIndex = 12;
            this.channelUpDown1.Visible = false;
            this.channelUpDown1.ValueChanged += new System.EventHandler(this.channelUpDown1_ValueChanged);
            // 
            // labelTvChannel1
            // 
            this.labelTvChannel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelTvChannel1.Location = new System.Drawing.Point(308, 390);
            this.labelTvChannel1.Name = "labelTvChannel1";
            this.labelTvChannel1.Size = new System.Drawing.Size(72, 16);
            this.labelTvChannel1.TabIndex = 13;
            this.labelTvChannel1.Text = "TV Channel:";
            this.labelTvChannel1.Visible = false;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(15, 390);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 24);
            this.button1.TabIndex = 14;
            this.button1.Text = "Grab Sample";
            this.button1.Visible = false;
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveImage.Location = new System.Drawing.Point(101, 390);
            this.btnSaveImage.Name = "btnSaveImage";
            this.btnSaveImage.Size = new System.Drawing.Size(80, 24);
            this.btnSaveImage.TabIndex = 15;
            this.btnSaveImage.Text = "Save Image";
            this.btnSaveImage.Visible = false;
            this.btnSaveImage.Click += new System.EventHandler(this.btnSaveImage_Click);
            // 
            // imageFileName
            // 
            this.imageFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imageFileName.Location = new System.Drawing.Point(68, 346);
            this.imageFileName.Name = "imageFileName";
            this.imageFileName.Size = new System.Drawing.Size(112, 20);
            this.imageFileName.TabIndex = 16;
            this.imageFileName.Text = "C:\\TestImage.Bmp";
            this.imageFileName.Visible = false;
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.imageFileName);
            this.MainPanel.Controls.Add(this.panelVideo);
            this.MainPanel.Controls.Add(this.button1);
            this.MainPanel.Controls.Add(this.btnSaveImage);
            this.MainPanel.Controls.Add(this.labelTvChannel1);
            this.MainPanel.Controls.Add(this.pictureBox1);
            this.MainPanel.Controls.Add(this.channelUpDown1);
            this.MainPanel.Controls.Add(this.label1);
            this.MainPanel.Controls.Add(this.txtFilename);
            this.MainPanel.Controls.Add(this.btnStart);
            this.MainPanel.Controls.Add(this.label3);
            this.MainPanel.Controls.Add(this.btnStop);
            this.MainPanel.Controls.Add(this.btnCue);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(497, 458);
            this.MainPanel.TabIndex = 17;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.Location = new System.Drawing.Point(294, 324);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(182, 122);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // CaptureTest
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(497, 458);
            this.Controls.Add(this.MainPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu;
            this.Name = "CaptureTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Negar Capture Tester - Rayan Parto Negar";
            ((System.ComponentModel.ISupportInitialize)(this.channelUpDown1)).EndInit();
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

    }
}