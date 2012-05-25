namespace Negar.Forms
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label lblFooter2;
            System.Windows.Forms.Label label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.btnPreInstall1 = new DevComponents.DotNetBar.ButtonItem();
            this.FolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.BGWorkerServer = new System.ComponentModel.BackgroundWorker();
            this.BGWorkerClient = new System.ComponentModel.BackgroundWorker();
            this.WizardControl = new DevComponents.DotNetBar.Wizard();
            this.WPageStart = new DevComponents.DotNetBar.WizardPage();
            this.btnDbUpgrade = new System.Windows.Forms.LinkLabel();
            this.btnLicenseAgreement = new System.Windows.Forms.LinkLabel();
            this.cBoxInstallClient = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cBoxInstallServer = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.PicBoxStart = new System.Windows.Forms.PictureBox();
            this.lblFooter1 = new System.Windows.Forms.Label();
            this.lblP1Desc1 = new System.Windows.Forms.Label();
            this.lblHeaderP1 = new System.Windows.Forms.Label();
            this.WPServer01 = new DevComponents.DotNetBar.WizardPage();
            this.lstServerPrequests = new DevComponents.DotNetBar.ItemPanel();
            this.btnSelectFolder1 = new DevComponents.DotNetBar.ButtonX();
            this.txtBankInstallFolder = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtServerInstanceName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblHeaderP2 = new System.Windows.Forms.Label();
            this.WPServer02 = new DevComponents.DotNetBar.WizardPage();
            this.PBarServer = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.lstInstallServer = new DevComponents.DotNetBar.ItemPanel();
            this.cBoxS1 = new DevComponents.DotNetBar.CheckBoxItem();
            this.cBoxS2 = new DevComponents.DotNetBar.CheckBoxItem();
            this.cBoxS3 = new DevComponents.DotNetBar.CheckBoxItem();
            this.cBoxS4 = new DevComponents.DotNetBar.CheckBoxItem();
            this.label5 = new System.Windows.Forms.Label();
            this.WPDbUpgrade = new DevComponents.DotNetBar.WizardPage();
            this.PanelUpgrade = new DevComponents.DotNetBar.PanelEx();
            this.lblUpgradeStatusTitle = new System.Windows.Forms.Label();
            this.btnPMSUpdate = new DevComponents.DotNetBar.ButtonX();
            this.btnIMSUpdate = new DevComponents.DotNetBar.ButtonX();
            this.lblUpgradeStatus = new System.Windows.Forms.Label();
            this.UpdateProgressBar = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.btnCheckDbVersions = new DevComponents.DotNetBar.ButtonX();
            this.txtUpdateInstance = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblUpdateTitle = new System.Windows.Forms.Label();
            this.WPClient01 = new DevComponents.DotNetBar.WizardPage();
            this.itemPanel1 = new DevComponents.DotNetBar.ItemPanel();
            this.cBoxPreInstall_HLock = new DevComponents.DotNetBar.CheckBoxItem();
            this.cBoxPreInstall_CrystalReport = new DevComponents.DotNetBar.CheckBoxItem();
            this.cBoxPreInstall_Fonts = new DevComponents.DotNetBar.CheckBoxItem();
            this.cBoxPreInstall_FaKeyboard = new DevComponents.DotNetBar.CheckBoxItem();
            this.cBoxPreInstall_FaPackage = new DevComponents.DotNetBar.CheckBoxItem();
            this.lblHeaderP3 = new System.Windows.Forms.Label();
            this.btnSelectFolder2 = new DevComponents.DotNetBar.ButtonX();
            this.txtNegarFolder = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblClientDesc4 = new System.Windows.Forms.Label();
            this.lblClientDesc3 = new System.Windows.Forms.Label();
            this.WPClient02 = new DevComponents.DotNetBar.WizardPage();
            this.PBarClient = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.lstInstallClient = new DevComponents.DotNetBar.ItemPanel();
            this.cBoxC1 = new DevComponents.DotNetBar.CheckBoxItem();
            this.cBoxC2 = new DevComponents.DotNetBar.CheckBoxItem();
            this.cBoxC3 = new DevComponents.DotNetBar.CheckBoxItem();
            this.cBoxC5 = new DevComponents.DotNetBar.CheckBoxItem();
            this.cBoxC6 = new DevComponents.DotNetBar.CheckBoxItem();
            this.cBoxC7 = new DevComponents.DotNetBar.CheckBoxItem();
            this.cBoxC8 = new DevComponents.DotNetBar.CheckBoxItem();
            this.label11 = new System.Windows.Forms.Label();
            this.WPageFinish = new DevComponents.DotNetBar.WizardPage();
            this.label12 = new System.Windows.Forms.Label();
            this.PixBoxEnd = new System.Windows.Forms.PictureBox();
            this.label13 = new System.Windows.Forms.Label();
            this.BGWorkerUpdate = new System.ComponentModel.BackgroundWorker();
            lblFooter2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.WizardControl.SuspendLayout();
            this.WPageStart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxStart)).BeginInit();
            this.WPServer01.SuspendLayout();
            this.WPServer02.SuspendLayout();
            this.WPDbUpgrade.SuspendLayout();
            this.PanelUpgrade.SuspendLayout();
            this.WPClient01.SuspendLayout();
            this.WPClient02.SuspendLayout();
            this.WPageFinish.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PixBoxEnd)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFooter2
            // 
            lblFooter2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            lblFooter2.AutoSize = true;
            lblFooter2.Location = new System.Drawing.Point(266, 244);
            lblFooter2.Name = "lblFooter2";
            lblFooter2.Size = new System.Drawing.Size(219, 13);
            lblFooter2.TabIndex = 5;
            lblFooter2.Text = "برای ادامه ، بر روی دكمه ی بعدی كلیك نمایید.";
            // 
            // label1
            // 
            label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(266, 244);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(219, 13);
            label1.TabIndex = 14;
            label1.Text = "برای ادامه ، بر روی دكمه ی بعدی كلیك نمایید.";
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            // 
            // btnPreInstall1
            // 
            this.btnPreInstall1.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnPreInstall1.ImagePaddingHorizontal = 8;
            this.btnPreInstall1.Name = "btnPreInstall1";
            this.FormToolTip.SetSuperTooltip(this.btnPreInstall1, new DevComponents.DotNetBar.SuperTooltipInfo("راهنمای نصب سیستم", "رایان پرتونگار", "با فراخوانی این فرمان ، نسخه ی سبكی از این برنامه ، ویژه نسخه های تك كاربره نصب خ" +
                        "واهد شد. برای نصب نسخه چند كاربره از سی دی مخصوص آن استفاده نمایید.", global::Negar.Properties.Resources.install, global::Negar.Properties.Resources.Help, DevComponents.DotNetBar.eTooltipColor.Blue));
            this.btnPreInstall1.Text = "1- نصب Microsoft Sql Server 2005 - نسخه Express.";
            this.btnPreInstall1.Click += new System.EventHandler(this.btnPreInstall_Click);
            // 
            // FolderBrowser
            // 
            this.FolderBrowser.Description = "انتخاب پوشه ی مورد نظر برای نصب";
            // 
            // BGWorkerServer
            // 
            this.BGWorkerServer.WorkerReportsProgress = true;
            this.BGWorkerServer.WorkerSupportsCancellation = true;
            this.BGWorkerServer.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGWorkerServer_DoWork);
            this.BGWorkerServer.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BGWorkerServer_RunWorkerCompleted);
            this.BGWorkerServer.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BGWorkerServer_ProgressChanged);
            // 
            // BGWorkerClient
            // 
            this.BGWorkerClient.WorkerReportsProgress = true;
            this.BGWorkerClient.WorkerSupportsCancellation = true;
            this.BGWorkerClient.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGWorkerClient_DoWork);
            this.BGWorkerClient.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BGWorkerClient_RunWorkerCompleted);
            this.BGWorkerClient.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BGWorkerClient_ProgressChanged);
            // 
            // WizardControl
            // 
            this.WizardControl.BackButtonText = "< قبلی";
            this.WizardControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.WizardControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.WizardControl.ButtonStyle = DevComponents.DotNetBar.eWizardStyle.Office2007;
            this.WizardControl.CancelButtonText = "انصراف";
            this.WizardControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.WizardControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WizardControl.FinishButtonTabIndex = 3;
            this.WizardControl.FinishButtonText = "خاتمه";
            this.WizardControl.FooterHeight = 40;
            // 
            // 
            // 
            this.WizardControl.FooterStyle.BackColor = System.Drawing.Color.Transparent;
            this.WizardControl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(57)))), ((int)(((byte)(129)))));
            this.WizardControl.HeaderCaptionFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WizardControl.HeaderDescriptionIndent = 40;
            this.WizardControl.HeaderDescriptionVisible = false;
            this.WizardControl.HeaderHeight = 50;
            this.WizardControl.HeaderImage = global::Negar.Properties.Resources.install;
            this.WizardControl.HeaderImageAlignment = DevComponents.DotNetBar.eWizardTitleImageAlignment.Left;
            this.WizardControl.HeaderImageSize = new System.Drawing.Size(32, 32);
            // 
            // 
            // 
            this.WizardControl.HeaderStyle.BackColor = System.Drawing.Color.Transparent;
            this.WizardControl.HeaderStyle.BackColorGradientAngle = 90;
            this.WizardControl.HeaderStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.WizardControl.HeaderStyle.BorderBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(157)))), ((int)(((byte)(182)))));
            this.WizardControl.HeaderStyle.BorderBottomWidth = 1;
            this.WizardControl.HeaderStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.WizardControl.HeaderStyle.BorderLeftWidth = 1;
            this.WizardControl.HeaderStyle.BorderRightWidth = 1;
            this.WizardControl.HeaderStyle.BorderTopWidth = 1;
            this.WizardControl.HeaderStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.WizardControl.HeaderStyle.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.WizardControl.HeaderTitleIndent = 40;
            this.WizardControl.HelpButtonText = "راهنمایی";
            this.WizardControl.HelpButtonVisible = false;
            this.WizardControl.Location = new System.Drawing.Point(0, 0);
            this.WizardControl.Name = "WizardControl";
            this.WizardControl.NextButtonText = "بعدی >";
            this.WizardControl.Size = new System.Drawing.Size(504, 374);
            this.WizardControl.TabIndex = 0;
            this.WizardControl.WizardPages.AddRange(new DevComponents.DotNetBar.WizardPage[] {
            this.WPageStart,
            this.WPServer01,
            this.WPServer02,
            this.WPDbUpgrade,
            this.WPClient01,
            this.WPClient02,
            this.WPageFinish});
            this.WizardControl.CancelButtonClick += new System.ComponentModel.CancelEventHandler(this.WizardControl_CancelButtonClick);
            // 
            // WPageStart
            // 
            this.WPageStart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.WPageStart.BackColor = System.Drawing.Color.Transparent;
            this.WPageStart.CanvasColor = System.Drawing.Color.Empty;
            this.WPageStart.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.WPageStart.Controls.Add(this.btnDbUpgrade);
            this.WPageStart.Controls.Add(this.btnLicenseAgreement);
            this.WPageStart.Controls.Add(this.cBoxInstallClient);
            this.WPageStart.Controls.Add(this.cBoxInstallServer);
            this.WPageStart.Controls.Add(this.PicBoxStart);
            this.WPageStart.Controls.Add(this.lblFooter1);
            this.WPageStart.Controls.Add(this.lblP1Desc1);
            this.WPageStart.Controls.Add(this.lblHeaderP1);
            this.WPageStart.Location = new System.Drawing.Point(7, 62);
            this.WPageStart.Name = "WPageStart";
            this.WPageStart.PageDescription = "شركت رایان پرتونگار";
            this.WPageStart.PageTitle = "نصب آسان سیستم مدیریت تصویربرداری سپهر";
            this.WPageStart.Size = new System.Drawing.Size(490, 260);
            this.WPageStart.TabIndex = 0;
            this.WPageStart.NextButtonClick += new System.ComponentModel.CancelEventHandler(this.WPageStart_NextButtonClick);
            // 
            // btnDbUpgrade
            // 
            this.btnDbUpgrade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDbUpgrade.AutoSize = true;
            this.btnDbUpgrade.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnDbUpgrade.LinkColor = System.Drawing.Color.RoyalBlue;
            this.btnDbUpgrade.Location = new System.Drawing.Point(23, 147);
            this.btnDbUpgrade.Name = "btnDbUpgrade";
            this.btnDbUpgrade.Size = new System.Drawing.Size(147, 13);
            this.btnDbUpgrade.TabIndex = 2;
            this.btnDbUpgrade.TabStop = true;
            this.btnDbUpgrade.Text = "ارتقاء بانك های اطلاعاتی...";
            this.btnDbUpgrade.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnDbUpgrade_LinkClicked);
            // 
            // btnLicenseAgreement
            // 
            this.btnLicenseAgreement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLicenseAgreement.AutoSize = true;
            this.btnLicenseAgreement.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnLicenseAgreement.LinkColor = System.Drawing.Color.RoyalBlue;
            this.btnLicenseAgreement.Location = new System.Drawing.Point(125, 189);
            this.btnLicenseAgreement.Name = "btnLicenseAgreement";
            this.btnLicenseAgreement.Size = new System.Drawing.Size(127, 13);
            this.btnLicenseAgreement.TabIndex = 3;
            this.btnLicenseAgreement.TabStop = true;
            this.btnLicenseAgreement.Text = "خواندن متن توافقنامه...";
            this.btnLicenseAgreement.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnLicenseAgreement_LinkClicked);
            // 
            // cBoxInstallClient
            // 
            this.cBoxInstallClient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxInstallClient.AutoSize = true;
            this.cBoxInstallClient.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.cBoxInstallClient.Checked = true;
            this.cBoxInstallClient.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBoxInstallClient.CheckValue = "Y";
            this.cBoxInstallClient.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxInstallClient.Location = new System.Drawing.Point(167, 167);
            this.cBoxInstallClient.Name = "cBoxInstallClient";
            this.cBoxInstallClient.Size = new System.Drawing.Size(85, 16);
            this.cBoxInstallClient.TabIndex = 0;
            this.cBoxInstallClient.Text = "نصب كلاینت";
            this.cBoxInstallClient.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            // 
            // cBoxInstallServer
            // 
            this.cBoxInstallServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxInstallServer.AutoSize = true;
            this.cBoxInstallServer.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.cBoxInstallServer.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxInstallServer.Location = new System.Drawing.Point(172, 145);
            this.cBoxInstallServer.Name = "cBoxInstallServer";
            this.cBoxInstallServer.Size = new System.Drawing.Size(80, 16);
            this.cBoxInstallServer.TabIndex = 1;
            this.cBoxInstallServer.Text = "نصب سرور";
            this.cBoxInstallServer.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            // 
            // PicBoxStart
            // 
            this.PicBoxStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PicBoxStart.Image = global::Negar.Properties.Resources.Setup;
            this.PicBoxStart.Location = new System.Drawing.Point(257, 0);
            this.PicBoxStart.Name = "PicBoxStart";
            this.PicBoxStart.Size = new System.Drawing.Size(233, 243);
            this.PicBoxStart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PicBoxStart.TabIndex = 13;
            this.PicBoxStart.TabStop = false;
            // 
            // lblFooter1
            // 
            this.lblFooter1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFooter1.AutoSize = true;
            this.lblFooter1.Location = new System.Drawing.Point(32, 243);
            this.lblFooter1.Name = "lblFooter1";
            this.lblFooter1.Size = new System.Drawing.Size(219, 13);
            this.lblFooter1.TabIndex = 6;
            this.lblFooter1.Text = "برای ادامه ، بر روی دكمه ی بعدی كلیك نمایید.";
            // 
            // lblP1Desc1
            // 
            this.lblP1Desc1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblP1Desc1.BackColor = System.Drawing.Color.Transparent;
            this.lblP1Desc1.ForeColor = System.Drawing.Color.Navy;
            this.lblP1Desc1.Location = new System.Drawing.Point(5, 42);
            this.lblP1Desc1.Name = "lblP1Desc1";
            this.lblP1Desc1.Size = new System.Drawing.Size(246, 100);
            this.lblP1Desc1.TabIndex = 5;
            this.lblP1Desc1.Text = resources.GetString("lblP1Desc1.Text");
            // 
            // lblHeaderP1
            // 
            this.lblHeaderP1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeaderP1.BackColor = System.Drawing.Color.Transparent;
            this.lblHeaderP1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblHeaderP1.ForeColor = System.Drawing.Color.Green;
            this.lblHeaderP1.Location = new System.Drawing.Point(18, 4);
            this.lblHeaderP1.Name = "lblHeaderP1";
            this.lblHeaderP1.Size = new System.Drawing.Size(233, 32);
            this.lblHeaderP1.TabIndex = 4;
            this.lblHeaderP1.Text = "این نرم افزار به شما برای نصب سیستم مدیریت تصویربرداری كمك می نماید.";
            // 
            // WPServer01
            // 
            this.WPServer01.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.WPServer01.AntiAlias = false;
            this.WPServer01.BackColor = System.Drawing.Color.Transparent;
            this.WPServer01.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.WPServer01.Controls.Add(this.lstServerPrequests);
            this.WPServer01.Controls.Add(this.btnSelectFolder1);
            this.WPServer01.Controls.Add(this.txtBankInstallFolder);
            this.WPServer01.Controls.Add(this.txtServerInstanceName);
            this.WPServer01.Controls.Add(this.label4);
            this.WPServer01.Controls.Add(this.label3);
            this.WPServer01.Controls.Add(lblFooter2);
            this.WPServer01.Controls.Add(this.label2);
            this.WPServer01.Controls.Add(this.lblHeaderP2);
            this.WPServer01.Location = new System.Drawing.Point(7, 62);
            this.WPServer01.Name = "WPServer01";
            this.WPServer01.PageTitle = "پیش نیاز های نصب سرور";
            this.WPServer01.Size = new System.Drawing.Size(490, 260);
            this.WPServer01.TabIndex = 0;
            this.WPServer01.NextButtonClick += new System.ComponentModel.CancelEventHandler(this.WPServer01_NextButtonClick);
            // 
            // lstServerPrequests
            // 
            // 
            // 
            // 
            this.lstServerPrequests.BackgroundStyle.BackColor = System.Drawing.Color.White;
            this.lstServerPrequests.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lstServerPrequests.BackgroundStyle.BorderBottomWidth = 1;
            this.lstServerPrequests.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            this.lstServerPrequests.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lstServerPrequests.BackgroundStyle.BorderLeftWidth = 1;
            this.lstServerPrequests.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lstServerPrequests.BackgroundStyle.BorderRightWidth = 1;
            this.lstServerPrequests.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lstServerPrequests.BackgroundStyle.BorderTopWidth = 1;
            this.lstServerPrequests.BackgroundStyle.PaddingBottom = 1;
            this.lstServerPrequests.BackgroundStyle.PaddingLeft = 1;
            this.lstServerPrequests.BackgroundStyle.PaddingRight = 1;
            this.lstServerPrequests.BackgroundStyle.PaddingTop = 1;
            this.lstServerPrequests.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lstServerPrequests.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnPreInstall1});
            this.lstServerPrequests.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.lstServerPrequests.Location = new System.Drawing.Point(13, 38);
            this.lstServerPrequests.Name = "lstServerPrequests";
            this.lstServerPrequests.Size = new System.Drawing.Size(469, 27);
            this.lstServerPrequests.TabIndex = 7;
            // 
            // btnSelectFolder1
            // 
            this.btnSelectFolder1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelectFolder1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelectFolder1.Location = new System.Drawing.Point(453, 110);
            this.btnSelectFolder1.Name = "btnSelectFolder1";
            this.btnSelectFolder1.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor();
            this.btnSelectFolder1.Size = new System.Drawing.Size(21, 21);
            this.btnSelectFolder1.TabIndex = 1;
            this.btnSelectFolder1.Text = "...";
            this.btnSelectFolder1.Click += new System.EventHandler(this.btnSelectFolders_Click);
            // 
            // txtBankInstallFolder
            // 
            this.txtBankInstallFolder.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtBankInstallFolder.Border.Class = "TextBoxBorder";
            this.txtBankInstallFolder.Location = new System.Drawing.Point(13, 110);
            this.txtBankInstallFolder.Name = "txtBankInstallFolder";
            this.txtBankInstallFolder.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBankInstallFolder.Size = new System.Drawing.Size(436, 21);
            this.txtBankInstallFolder.TabIndex = 0;
            this.txtBankInstallFolder.Text = "C:\\Negar Databases";
            // 
            // txtServerInstanceName
            // 
            // 
            // 
            // 
            this.txtServerInstanceName.Border.Class = "TextBoxBorder";
            this.txtServerInstanceName.Location = new System.Drawing.Point(14, 137);
            this.txtServerInstanceName.MaxLength = 100;
            this.txtServerInstanceName.Name = "txtServerInstanceName";
            this.txtServerInstanceName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtServerInstanceName.Size = new System.Drawing.Size(286, 21);
            this.txtServerInstanceName.TabIndex = 2;
            this.txtServerInstanceName.Text = ".\\NegarServer01";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(306, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "نام سرور و نمونه بانك اطلاعاتی:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(271, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(208, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "محل نصب فیزیكی بانك های اطلاعاتی:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(46, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(433, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "در صورت نصب بودن كلیه پیش نیازها ، مسیرهای درخواست شده را مشخص نمایید:";
            // 
            // lblHeaderP2
            // 
            this.lblHeaderP2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeaderP2.BackColor = System.Drawing.Color.Transparent;
            this.lblHeaderP2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblHeaderP2.ForeColor = System.Drawing.Color.Green;
            this.lblHeaderP2.Location = new System.Drawing.Point(44, 2);
            this.lblHeaderP2.Name = "lblHeaderP2";
            this.lblHeaderP2.Size = new System.Drawing.Size(438, 30);
            this.lblHeaderP2.TabIndex = 6;
            this.lblHeaderP2.Text = "لطفاً پیش از نصب نسخه سرور برنامه ، در صورت نصب نبودن گزینه ها لیست پایین ، با كل" +
                "یك بر روی آنها ، موارد مورد نظر را نصب نمایید:";
            // 
            // WPServer02
            // 
            this.WPServer02.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.WPServer02.AntiAlias = false;
            this.WPServer02.BackButtonVisible = DevComponents.DotNetBar.eWizardButtonState.False;
            this.WPServer02.BackColor = System.Drawing.Color.Transparent;
            this.WPServer02.CancelButtonVisible = DevComponents.DotNetBar.eWizardButtonState.False;
            this.WPServer02.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.WPServer02.Controls.Add(this.PBarServer);
            this.WPServer02.Controls.Add(this.lstInstallServer);
            this.WPServer02.Controls.Add(this.label5);
            this.WPServer02.Location = new System.Drawing.Point(7, 62);
            this.WPServer02.Name = "WPServer02";
            this.WPServer02.NextButtonVisible = DevComponents.DotNetBar.eWizardButtonState.False;
            this.WPServer02.PageTitle = "نصب سرور";
            this.WPServer02.Size = new System.Drawing.Size(490, 260);
            this.WPServer02.TabIndex = 0;
            this.WPServer02.NextButtonClick += new System.ComponentModel.CancelEventHandler(this.WPServer02_NextButtonClick);
            this.WPServer02.AfterPageDisplayed += new DevComponents.DotNetBar.WizardPageChangeEventHandler(this.WPServer02_AfterPageDisplayed);
            // 
            // PBarServer
            // 
            this.PBarServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PBarServer.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.PBarServer.ForeColor = System.Drawing.Color.Tomato;
            this.PBarServer.Location = new System.Drawing.Point(5, 225);
            this.PBarServer.Name = "PBarServer";
            this.PBarServer.ProgressType = DevComponents.DotNetBar.eProgressItemType.Marquee;
            this.PBarServer.Size = new System.Drawing.Size(477, 32);
            this.PBarServer.Step = 0;
            this.PBarServer.TabIndex = 2;
            this.PBarServer.Text = "در حال نصب بانك بر روی سرور";
            this.PBarServer.TextVisible = true;
            // 
            // lstInstallServer
            // 
            this.lstInstallServer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstInstallServer.AutoScroll = true;
            // 
            // 
            // 
            this.lstInstallServer.BackgroundStyle.BackColor = System.Drawing.Color.White;
            this.lstInstallServer.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lstInstallServer.BackgroundStyle.BorderBottomWidth = 1;
            this.lstInstallServer.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            this.lstInstallServer.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lstInstallServer.BackgroundStyle.BorderLeftWidth = 1;
            this.lstInstallServer.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lstInstallServer.BackgroundStyle.BorderRightWidth = 1;
            this.lstInstallServer.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lstInstallServer.BackgroundStyle.BorderTopWidth = 1;
            this.lstInstallServer.BackgroundStyle.PaddingBottom = 1;
            this.lstInstallServer.BackgroundStyle.PaddingLeft = 1;
            this.lstInstallServer.BackgroundStyle.PaddingRight = 1;
            this.lstInstallServer.BackgroundStyle.PaddingTop = 1;
            this.lstInstallServer.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lstInstallServer.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.cBoxS1,
            this.cBoxS2,
            this.cBoxS3,
            this.cBoxS4});
            this.lstInstallServer.ItemSpacing = 3;
            this.lstInstallServer.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.lstInstallServer.Location = new System.Drawing.Point(5, 26);
            this.lstInstallServer.Name = "lstInstallServer";
            this.lstInstallServer.Size = new System.Drawing.Size(477, 193);
            this.lstInstallServer.TabIndex = 0;
            // 
            // cBoxS1
            // 
            this.cBoxS1.Name = "cBoxS1";
            this.cBoxS1.Text = "ساخت كاربر برنامه برای بانك اطلاعاتی";
            // 
            // cBoxS2
            // 
            this.cBoxS2.Name = "cBoxS2";
            this.cBoxS2.Text = "آماده سازی سرور";
            // 
            // cBoxS3
            // 
            this.cBoxS3.Name = "cBoxS3";
            this.cBoxS3.Text = "حذف بانك قبلی در سرور در صورت وجود و بازیابی بانك اطلاعاتی در سرور";
            // 
            // cBoxS4
            // 
            this.cBoxS4.Name = "cBoxS4";
            this.cBoxS4.Text = "نصب قفل نرم افزاری بر روی بانك اطلاعاتی";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.ForeColor = System.Drawing.Color.Green;
            this.label5.Location = new System.Drawing.Point(341, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "انجام مراحل نصب سیستم";
            // 
            // WPDbUpgrade
            // 
            this.WPDbUpgrade.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.WPDbUpgrade.BackColor = System.Drawing.Color.Transparent;
            this.WPDbUpgrade.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.WPDbUpgrade.Controls.Add(this.PanelUpgrade);
            this.WPDbUpgrade.Controls.Add(this.btnCheckDbVersions);
            this.WPDbUpgrade.Controls.Add(this.txtUpdateInstance);
            this.WPDbUpgrade.Controls.Add(this.lblUpdateTitle);
            this.WPDbUpgrade.Location = new System.Drawing.Point(7, 62);
            this.WPDbUpgrade.Name = "WPDbUpgrade";
            this.WPDbUpgrade.NextButtonVisible = DevComponents.DotNetBar.eWizardButtonState.False;
            this.WPDbUpgrade.PageTitle = "ارتقاء بانك اطلاعاتی";
            this.WPDbUpgrade.Size = new System.Drawing.Size(490, 260);
            this.WPDbUpgrade.TabIndex = 11;
            this.WPDbUpgrade.Text = "DbUpgrade";
            this.WPDbUpgrade.BackButtonClick += new System.ComponentModel.CancelEventHandler(this.WPDbUpgrade_BackButtonClick);
            // 
            // PanelUpgrade
            // 
            this.PanelUpgrade.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelUpgrade.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelUpgrade.Controls.Add(this.lblUpgradeStatusTitle);
            this.PanelUpgrade.Controls.Add(this.btnPMSUpdate);
            this.PanelUpgrade.Controls.Add(this.btnIMSUpdate);
            this.PanelUpgrade.Controls.Add(this.lblUpgradeStatus);
            this.PanelUpgrade.Controls.Add(this.UpdateProgressBar);
            this.PanelUpgrade.Location = new System.Drawing.Point(5, 85);
            this.PanelUpgrade.Name = "PanelUpgrade";
            this.PanelUpgrade.Size = new System.Drawing.Size(477, 172);
            this.PanelUpgrade.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.PanelUpgrade.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.PanelUpgrade.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.PanelUpgrade.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.PanelUpgrade.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.PanelUpgrade.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.PanelUpgrade.Style.GradientAngle = 90;
            this.PanelUpgrade.TabIndex = 10;
            this.PanelUpgrade.Visible = false;
            // 
            // lblUpgradeStatusTitle
            // 
            this.lblUpgradeStatusTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUpgradeStatusTitle.AutoSize = true;
            this.lblUpgradeStatusTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblUpgradeStatusTitle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblUpgradeStatusTitle.ForeColor = System.Drawing.Color.Navy;
            this.lblUpgradeStatusTitle.Location = new System.Drawing.Point(219, 10);
            this.lblUpgradeStatusTitle.Name = "lblUpgradeStatusTitle";
            this.lblUpgradeStatusTitle.Size = new System.Drawing.Size(253, 13);
            this.lblUpgradeStatusTitle.TabIndex = 5;
            this.lblUpgradeStatusTitle.Text = "نتیجه بررسی نسخه بانك های اطلاعاتی موجود:";
            // 
            // btnPMSUpdate
            // 
            this.btnPMSUpdate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPMSUpdate.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnPMSUpdate.Enabled = false;
            this.btnPMSUpdate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnPMSUpdate.ForeColor = System.Drawing.Color.Navy;
            this.btnPMSUpdate.Location = new System.Drawing.Point(7, 30);
            this.btnPMSUpdate.Name = "btnPMSUpdate";
            this.btnPMSUpdate.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor();
            this.btnPMSUpdate.Size = new System.Drawing.Size(189, 45);
            this.btnPMSUpdate.TabIndex = 9;
            this.btnPMSUpdate.Text = "ارتقاء بانك هسته مركزی به نسخه\r\n";
            this.btnPMSUpdate.Click += new System.EventHandler(this.btnPMSUpdate_Click);
            // 
            // btnIMSUpdate
            // 
            this.btnIMSUpdate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnIMSUpdate.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnIMSUpdate.Enabled = false;
            this.btnIMSUpdate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnIMSUpdate.ForeColor = System.Drawing.Color.Navy;
            this.btnIMSUpdate.Location = new System.Drawing.Point(7, 81);
            this.btnIMSUpdate.Name = "btnIMSUpdate";
            this.btnIMSUpdate.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor();
            this.btnIMSUpdate.Size = new System.Drawing.Size(189, 45);
            this.btnIMSUpdate.TabIndex = 9;
            this.btnIMSUpdate.Text = "ارتقاء بانك تصویربرداری به نسخه\r\n";
            this.btnIMSUpdate.Click += new System.EventHandler(this.btnIMSUpdate_Click);
            // 
            // lblUpgradeStatus
            // 
            this.lblUpgradeStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUpgradeStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblUpgradeStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblUpgradeStatus.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblUpgradeStatus.ForeColor = System.Drawing.Color.Green;
            this.lblUpgradeStatus.Location = new System.Drawing.Point(202, 30);
            this.lblUpgradeStatus.Name = "lblUpgradeStatus";
            this.lblUpgradeStatus.Size = new System.Drawing.Size(267, 96);
            this.lblUpgradeStatus.TabIndex = 5;
            // 
            // UpdateProgressBar
            // 
            this.UpdateProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdateProgressBar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.UpdateProgressBar.ForeColor = System.Drawing.Color.Tomato;
            this.UpdateProgressBar.Location = new System.Drawing.Point(7, 133);
            this.UpdateProgressBar.Name = "UpdateProgressBar";
            this.UpdateProgressBar.ProgressType = DevComponents.DotNetBar.eProgressItemType.Marquee;
            this.UpdateProgressBar.Size = new System.Drawing.Size(464, 32);
            this.UpdateProgressBar.Step = 0;
            this.UpdateProgressBar.TabIndex = 6;
            this.UpdateProgressBar.Text = "در حال ارتقاء بانك های اطلاعاتی";
            this.UpdateProgressBar.TextVisible = true;
            this.UpdateProgressBar.Visible = false;
            // 
            // btnCheckDbVersions
            // 
            this.btnCheckDbVersions.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCheckDbVersions.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnCheckDbVersions.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnCheckDbVersions.ForeColor = System.Drawing.Color.White;
            this.btnCheckDbVersions.Location = new System.Drawing.Point(5, 37);
            this.btnCheckDbVersions.Name = "btnCheckDbVersions";
            this.btnCheckDbVersions.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor();
            this.btnCheckDbVersions.Size = new System.Drawing.Size(119, 39);
            this.btnCheckDbVersions.TabIndex = 8;
            this.btnCheckDbVersions.Text = "بررسی بانك های\r\nنصب شده";
            this.btnCheckDbVersions.Click += new System.EventHandler(this.btnCheckCurrentDb_Click);
            // 
            // txtUpdateInstance
            // 
            // 
            // 
            // 
            this.txtUpdateInstance.Border.Class = "TextBoxBorder";
            this.txtUpdateInstance.Location = new System.Drawing.Point(5, 10);
            this.txtUpdateInstance.MaxLength = 100;
            this.txtUpdateInstance.Name = "txtUpdateInstance";
            this.txtUpdateInstance.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtUpdateInstance.Size = new System.Drawing.Size(119, 21);
            this.txtUpdateInstance.TabIndex = 7;
            this.txtUpdateInstance.Text = ".\\NegarServer01";
            // 
            // lblUpdateTitle
            // 
            this.lblUpdateTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUpdateTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblUpdateTitle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblUpdateTitle.ForeColor = System.Drawing.Color.Green;
            this.lblUpdateTitle.Location = new System.Drawing.Point(130, 10);
            this.lblUpdateTitle.Name = "lblUpdateTitle";
            this.lblUpdateTitle.Size = new System.Drawing.Size(355, 66);
            this.lblUpdateTitle.TabIndex = 4;
            this.lblUpdateTitle.Text = resources.GetString("lblUpdateTitle.Text");
            // 
            // WPClient01
            // 
            this.WPClient01.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.WPClient01.BackColor = System.Drawing.Color.Transparent;
            this.WPClient01.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.WPClient01.Controls.Add(label1);
            this.WPClient01.Controls.Add(this.itemPanel1);
            this.WPClient01.Controls.Add(this.lblHeaderP3);
            this.WPClient01.Controls.Add(this.btnSelectFolder2);
            this.WPClient01.Controls.Add(this.txtNegarFolder);
            this.WPClient01.Controls.Add(this.lblClientDesc4);
            this.WPClient01.Controls.Add(this.lblClientDesc3);
            this.WPClient01.Location = new System.Drawing.Point(7, 62);
            this.WPClient01.Name = "WPClient01";
            this.WPClient01.PageTitle = "پیش نیاز های نصب ایستگاه كاری";
            this.WPClient01.Size = new System.Drawing.Size(490, 260);
            this.WPClient01.TabIndex = 0;
            this.WPClient01.Text = "wizardPage2";
            this.WPClient01.BackButtonClick += new System.ComponentModel.CancelEventHandler(this.WPClient01_BackButtonClick);
            this.WPClient01.NextButtonClick += new System.ComponentModel.CancelEventHandler(this.WPClient01_NextButtonClick);
            // 
            // itemPanel1
            // 
            // 
            // 
            // 
            this.itemPanel1.BackgroundStyle.BackColor = System.Drawing.Color.White;
            this.itemPanel1.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel1.BackgroundStyle.BorderBottomWidth = 1;
            this.itemPanel1.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            this.itemPanel1.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel1.BackgroundStyle.BorderLeftWidth = 1;
            this.itemPanel1.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel1.BackgroundStyle.BorderRightWidth = 1;
            this.itemPanel1.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel1.BackgroundStyle.BorderTopWidth = 1;
            this.itemPanel1.BackgroundStyle.PaddingBottom = 1;
            this.itemPanel1.BackgroundStyle.PaddingLeft = 1;
            this.itemPanel1.BackgroundStyle.PaddingRight = 1;
            this.itemPanel1.BackgroundStyle.PaddingTop = 1;
            this.itemPanel1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.itemPanel1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.cBoxPreInstall_HLock,
            this.cBoxPreInstall_CrystalReport,
            this.cBoxPreInstall_Fonts,
            this.cBoxPreInstall_FaKeyboard,
            this.cBoxPreInstall_FaPackage});
            this.itemPanel1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemPanel1.Location = new System.Drawing.Point(7, 36);
            this.itemPanel1.Name = "itemPanel1";
            this.itemPanel1.Size = new System.Drawing.Size(473, 111);
            this.itemPanel1.TabIndex = 13;
            this.itemPanel1.Text = "itemPanel1";
            // 
            // cBoxPreInstall_HLock
            // 
            this.cBoxPreInstall_HLock.Checked = true;
            this.cBoxPreInstall_HLock.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBoxPreInstall_HLock.Name = "cBoxPreInstall_HLock";
            this.cBoxPreInstall_HLock.Text = "ثبت ابزار مدیریت قفل سخت افزاری";
            this.cBoxPreInstall_HLock.TextColor = System.Drawing.Color.Red;
            // 
            // cBoxPreInstall_CrystalReport
            // 
            this.cBoxPreInstall_CrystalReport.Checked = true;
            this.cBoxPreInstall_CrystalReport.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBoxPreInstall_CrystalReport.Name = "cBoxPreInstall_CrystalReport";
            this.cBoxPreInstall_CrystalReport.Text = "نصب نرم افزار مدیریت گزارش ها";
            this.cBoxPreInstall_CrystalReport.TextColor = System.Drawing.Color.Red;
            // 
            // cBoxPreInstall_Fonts
            // 
            this.cBoxPreInstall_Fonts.Checked = true;
            this.cBoxPreInstall_Fonts.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBoxPreInstall_Fonts.Name = "cBoxPreInstall_Fonts";
            this.cBoxPreInstall_Fonts.Text = "نصب قلم های استاندارد فارسی پرتونگار";
            this.cBoxPreInstall_Fonts.TextColor = System.Drawing.Color.Red;
            // 
            // cBoxPreInstall_FaKeyboard
            // 
            this.cBoxPreInstall_FaKeyboard.Name = "cBoxPreInstall_FaKeyboard";
            this.cBoxPreInstall_FaKeyboard.Text = "نصب صفحه كلید استاندارد فارسی پرتونگار";
            // 
            // cBoxPreInstall_FaPackage
            // 
            this.cBoxPreInstall_FaPackage.Name = "cBoxPreInstall_FaPackage";
            this.cBoxPreInstall_FaPackage.Text = "نصب بسته های فارسی ساز پرتونگار";
            // 
            // lblHeaderP3
            // 
            this.lblHeaderP3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeaderP3.BackColor = System.Drawing.Color.Transparent;
            this.lblHeaderP3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblHeaderP3.ForeColor = System.Drawing.Color.Green;
            this.lblHeaderP3.Location = new System.Drawing.Point(11, 0);
            this.lblHeaderP3.Name = "lblHeaderP3";
            this.lblHeaderP3.Size = new System.Drawing.Size(469, 30);
            this.lblHeaderP3.TabIndex = 12;
            this.lblHeaderP3.Text = "لطفاً پیش از نصب ایستگاه كاربری برنامه ، در صورت نصب نبودن گزینه های لیست پایین ،" +
                " با كلیك بر روی آنها ، موارد مورد نظر را نصب نمایید:";
            // 
            // btnSelectFolder2
            // 
            this.btnSelectFolder2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelectFolder2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectFolder2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelectFolder2.Location = new System.Drawing.Point(276, 172);
            this.btnSelectFolder2.Name = "btnSelectFolder2";
            this.btnSelectFolder2.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor();
            this.btnSelectFolder2.Size = new System.Drawing.Size(21, 21);
            this.btnSelectFolder2.TabIndex = 7;
            this.btnSelectFolder2.Text = "...";
            this.btnSelectFolder2.Click += new System.EventHandler(this.btnSelectFolders_Click);
            // 
            // txtNegarFolder
            // 
            this.txtNegarFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNegarFolder.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtNegarFolder.Border.Class = "TextBoxBorder";
            this.txtNegarFolder.Location = new System.Drawing.Point(7, 172);
            this.txtNegarFolder.Name = "txtNegarFolder";
            this.txtNegarFolder.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtNegarFolder.Size = new System.Drawing.Size(261, 21);
            this.txtNegarFolder.TabIndex = 0;
            this.txtNegarFolder.Text = "C:\\Negar";
            // 
            // lblClientDesc4
            // 
            this.lblClientDesc4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClientDesc4.AutoSize = true;
            this.lblClientDesc4.BackColor = System.Drawing.Color.Transparent;
            this.lblClientDesc4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblClientDesc4.ForeColor = System.Drawing.Color.Blue;
            this.lblClientDesc4.Location = new System.Drawing.Point(301, 176);
            this.lblClientDesc4.Name = "lblClientDesc4";
            this.lblClientDesc4.Size = new System.Drawing.Size(181, 13);
            this.lblClientDesc4.TabIndex = 6;
            this.lblClientDesc4.Text = "آدرس نصب پكیج مدیریت پزشكی:";
            // 
            // lblClientDesc3
            // 
            this.lblClientDesc3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClientDesc3.AutoSize = true;
            this.lblClientDesc3.BackColor = System.Drawing.Color.Transparent;
            this.lblClientDesc3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblClientDesc3.ForeColor = System.Drawing.Color.Green;
            this.lblClientDesc3.Location = new System.Drawing.Point(72, 153);
            this.lblClientDesc3.Name = "lblClientDesc3";
            this.lblClientDesc3.Size = new System.Drawing.Size(410, 13);
            this.lblClientDesc3.TabIndex = 4;
            this.lblClientDesc3.Text = "در صورت آماده بودن كلیه پیش نیازها ، مسیر درخواست شده را مشخص نمایید:";
            // 
            // WPClient02
            // 
            this.WPClient02.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.WPClient02.BackButtonVisible = DevComponents.DotNetBar.eWizardButtonState.False;
            this.WPClient02.BackColor = System.Drawing.Color.Transparent;
            this.WPClient02.CancelButtonVisible = DevComponents.DotNetBar.eWizardButtonState.False;
            this.WPClient02.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.WPClient02.Controls.Add(this.PBarClient);
            this.WPClient02.Controls.Add(this.lstInstallClient);
            this.WPClient02.Controls.Add(this.label11);
            this.WPClient02.Location = new System.Drawing.Point(7, 62);
            this.WPClient02.Name = "WPClient02";
            this.WPClient02.NextButtonVisible = DevComponents.DotNetBar.eWizardButtonState.False;
            this.WPClient02.PageTitle = "نصب ایستگاه كاری";
            this.WPClient02.Size = new System.Drawing.Size(490, 260);
            this.WPClient02.TabIndex = 9;
            this.WPClient02.Text = "wizardPage3";
            this.WPClient02.AfterPageDisplayed += new DevComponents.DotNetBar.WizardPageChangeEventHandler(this.WPClient02_AfterPageDisplayed);
            // 
            // PBarClient
            // 
            this.PBarClient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PBarClient.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.PBarClient.ForeColor = System.Drawing.Color.Tomato;
            this.PBarClient.Location = new System.Drawing.Point(5, 228);
            this.PBarClient.Name = "PBarClient";
            this.PBarClient.ProgressType = DevComponents.DotNetBar.eProgressItemType.Marquee;
            this.PBarClient.Size = new System.Drawing.Size(477, 32);
            this.PBarClient.TabIndex = 6;
            this.PBarClient.Text = "در حال نصب برنامه بر روی ایستگاه كاری";
            this.PBarClient.TextVisible = true;
            // 
            // lstInstallClient
            // 
            this.lstInstallClient.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstInstallClient.AutoScroll = true;
            // 
            // 
            // 
            this.lstInstallClient.BackgroundStyle.BackColor = System.Drawing.Color.White;
            this.lstInstallClient.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lstInstallClient.BackgroundStyle.BorderBottomWidth = 1;
            this.lstInstallClient.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            this.lstInstallClient.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lstInstallClient.BackgroundStyle.BorderLeftWidth = 1;
            this.lstInstallClient.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lstInstallClient.BackgroundStyle.BorderRightWidth = 1;
            this.lstInstallClient.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lstInstallClient.BackgroundStyle.BorderTopWidth = 1;
            this.lstInstallClient.BackgroundStyle.PaddingBottom = 1;
            this.lstInstallClient.BackgroundStyle.PaddingLeft = 1;
            this.lstInstallClient.BackgroundStyle.PaddingRight = 1;
            this.lstInstallClient.BackgroundStyle.PaddingTop = 1;
            this.lstInstallClient.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lstInstallClient.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.cBoxC1,
            this.cBoxC2,
            this.cBoxC3,
            this.cBoxC5,
            this.cBoxC6,
            this.cBoxC7,
            this.cBoxC8});
            this.lstInstallClient.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.lstInstallClient.Location = new System.Drawing.Point(5, 25);
            this.lstInstallClient.Name = "lstInstallClient";
            this.lstInstallClient.Size = new System.Drawing.Size(477, 196);
            this.lstInstallClient.TabIndex = 5;
            // 
            // cBoxC1
            // 
            this.cBoxC1.Name = "cBoxC1";
            this.cBoxC1.Text = "نصب بسته های فارسی ساز نگار";
            // 
            // cBoxC2
            // 
            this.cBoxC2.Name = "cBoxC2";
            this.cBoxC2.Text = "نصب صفحه كلید استاندارد فارسی نگار";
            // 
            // cBoxC3
            // 
            this.cBoxC3.Name = "cBoxC3";
            this.cBoxC3.Text = "نصب قلم های استاندارد فارسی نگار";
            // 
            // cBoxC5
            // 
            this.cBoxC5.Name = "cBoxC5";
            this.cBoxC5.Text = "نصب برنامه ها";
            this.cBoxC5.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            // 
            // cBoxC6
            // 
            this.cBoxC6.Name = "cBoxC6";
            this.cBoxC6.Text = "ثبت اجزاء نرم افزاری و كامپوننت ها";
            // 
            // cBoxC7
            // 
            this.cBoxC7.Name = "cBoxC7";
            this.cBoxC7.Text = "ثبت برنامه ها در ویندوز";
            // 
            // cBoxC8
            // 
            this.cBoxC8.Name = "cBoxC8";
            this.cBoxC8.Text = "قراردادن آیكون برنامه در منوی استارت و دسكتاپ";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label11.ForeColor = System.Drawing.Color.Green;
            this.label11.Location = new System.Drawing.Point(341, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(144, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "انجام مراحل نصب سیستم";
            // 
            // WPageFinish
            // 
            this.WPageFinish.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.WPageFinish.BackButtonVisible = DevComponents.DotNetBar.eWizardButtonState.False;
            this.WPageFinish.BackColor = System.Drawing.Color.Transparent;
            this.WPageFinish.CancelButtonVisible = DevComponents.DotNetBar.eWizardButtonState.False;
            this.WPageFinish.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.WPageFinish.Controls.Add(this.label12);
            this.WPageFinish.Controls.Add(this.PixBoxEnd);
            this.WPageFinish.Controls.Add(this.label13);
            this.WPageFinish.Location = new System.Drawing.Point(7, 62);
            this.WPageFinish.Name = "WPageFinish";
            this.WPageFinish.PageTitle = "اتمام نصب";
            this.WPageFinish.Size = new System.Drawing.Size(490, 260);
            this.WPageFinish.TabIndex = 10;
            this.WPageFinish.Text = "wizardPage4";
            this.WPageFinish.FinishButtonClick += new System.ComponentModel.CancelEventHandler(this.WPageFinish_FinishButtonClick);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(10, 30);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(236, 222);
            this.label12.TabIndex = 19;
            this.label12.Text = resources.GetString("label12.Text");
            // 
            // PixBoxEnd
            // 
            this.PixBoxEnd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PixBoxEnd.Image = global::Negar.Properties.Resources.Setup;
            this.PixBoxEnd.Location = new System.Drawing.Point(255, 9);
            this.PixBoxEnd.Name = "PixBoxEnd";
            this.PixBoxEnd.Size = new System.Drawing.Size(233, 243);
            this.PixBoxEnd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PixBoxEnd.TabIndex = 18;
            this.PixBoxEnd.TabStop = false;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label13.ForeColor = System.Drawing.Color.Green;
            this.label13.Location = new System.Drawing.Point(141, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(108, 13);
            this.label13.TabIndex = 16;
            this.label13.Text = "نصب به پایان رسید!";
            // 
            // BGWorkerUpdate
            // 
            this.BGWorkerUpdate.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGWorkerUpdate_DoWork);
            this.BGWorkerUpdate.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BGWorkerUpdate_RunWorkerCompleted);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ClientSize = new System.Drawing.Size(504, 374);
            this.Controls.Add(this.WizardControl);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.Opacity = 0.01;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "رایان پرتونگار - مدیریت نصب آسان سیستم مدیریت تصویربرداری سپهر";
            this.TitleText = "رایان پرتونگار - مدیریت نصب آسان سیستم مدیریت تصویربرداری سپهر";
            this.Shown += new System.EventHandler(this.From_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.WizardControl.ResumeLayout(false);
            this.WPageStart.ResumeLayout(false);
            this.WPageStart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxStart)).EndInit();
            this.WPServer01.ResumeLayout(false);
            this.WPServer01.PerformLayout();
            this.WPServer02.ResumeLayout(false);
            this.WPServer02.PerformLayout();
            this.WPDbUpgrade.ResumeLayout(false);
            this.PanelUpgrade.ResumeLayout(false);
            this.PanelUpgrade.PerformLayout();
            this.WPClient01.ResumeLayout(false);
            this.WPClient01.PerformLayout();
            this.WPClient02.ResumeLayout(false);
            this.WPClient02.PerformLayout();
            this.WPageFinish.ResumeLayout(false);
            this.WPageFinish.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PixBoxEnd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.WizardPage WPageStart;
        private System.Windows.Forms.Label lblHeaderP1;
        private DevComponents.DotNetBar.WizardPage WPServer01;
        private System.Windows.Forms.Label lblHeaderP2;
        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        private System.Windows.Forms.Label lblFooter1;
        private System.Windows.Forms.Label lblP1Desc1;
        private DevComponents.DotNetBar.Wizard WizardControl;
        private System.Windows.Forms.PictureBox PicBoxStart;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxInstallClient;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxInstallServer;
        private DevComponents.DotNetBar.WizardPage WPServer02;
        private DevComponents.DotNetBar.WizardPage WPClient01;
        private DevComponents.DotNetBar.WizardPage WPClient02;
        private DevComponents.DotNetBar.WizardPage WPageFinish;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.Controls.TextBoxX txtServerInstanceName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private DevComponents.DotNetBar.ItemPanel lstInstallServer;
        private DevComponents.DotNetBar.CheckBoxItem cBoxS2;
        private DevComponents.DotNetBar.CheckBoxItem cBoxS3;
        private DevComponents.DotNetBar.CheckBoxItem cBoxS4;
        private DevComponents.DotNetBar.CheckBoxItem cBoxS1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNegarFolder;
        private System.Windows.Forms.Label lblClientDesc3;
        private DevComponents.DotNetBar.ItemPanel lstInstallClient;
        private DevComponents.DotNetBar.CheckBoxItem cBoxC1;
        private DevComponents.DotNetBar.CheckBoxItem cBoxC2;
        private DevComponents.DotNetBar.CheckBoxItem cBoxC3;
        private DevComponents.DotNetBar.CheckBoxItem cBoxC5;
        private DevComponents.DotNetBar.CheckBoxItem cBoxC7;
        private DevComponents.DotNetBar.CheckBoxItem cBoxC6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox PixBoxEnd;
        private System.Windows.Forms.Label label13;
        private DevComponents.DotNetBar.Controls.ProgressBarX PBarServer;
        private System.Windows.Forms.Label lblClientDesc4;
        private DevComponents.DotNetBar.ButtonX btnSelectFolder2;
        private DevComponents.DotNetBar.ButtonX btnSelectFolder1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtBankInstallFolder;
        private System.Windows.Forms.Label label12;
        private DevComponents.DotNetBar.Controls.ProgressBarX PBarClient;
        private DevComponents.DotNetBar.CheckBoxItem cBoxC8;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowser;
        private System.ComponentModel.BackgroundWorker BGWorkerServer;
        private System.ComponentModel.BackgroundWorker BGWorkerClient;
        private DevComponents.DotNetBar.ItemPanel lstServerPrequests;
        private DevComponents.DotNetBar.ButtonItem btnPreInstall1;
        private DevComponents.DotNetBar.ItemPanel itemPanel1;
        private System.Windows.Forms.Label lblHeaderP3;
        private DevComponents.DotNetBar.CheckBoxItem cBoxPreInstall_FaPackage;
        private DevComponents.DotNetBar.CheckBoxItem cBoxPreInstall_FaKeyboard;
        private DevComponents.DotNetBar.CheckBoxItem cBoxPreInstall_Fonts;
        private System.Windows.Forms.LinkLabel btnLicenseAgreement;
        private System.Windows.Forms.LinkLabel btnDbUpgrade;
        private DevComponents.DotNetBar.WizardPage WPDbUpgrade;
        private System.Windows.Forms.Label lblUpgradeStatusTitle;
        private System.Windows.Forms.Label lblUpdateTitle;
        private DevComponents.DotNetBar.Controls.TextBoxX txtUpdateInstance;
        private DevComponents.DotNetBar.Controls.ProgressBarX UpdateProgressBar;
        private DevComponents.DotNetBar.ButtonX btnCheckDbVersions;
        private System.Windows.Forms.Label lblUpgradeStatus;
        private DevComponents.DotNetBar.ButtonX btnPMSUpdate;
        private DevComponents.DotNetBar.ButtonX btnIMSUpdate;
        private System.ComponentModel.BackgroundWorker BGWorkerUpdate;
        private DevComponents.DotNetBar.PanelEx PanelUpgrade;
        private DevComponents.DotNetBar.CheckBoxItem cBoxPreInstall_CrystalReport;
        private DevComponents.DotNetBar.CheckBoxItem cBoxPreInstall_HLock;

    }
}