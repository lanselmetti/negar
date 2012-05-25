namespace mCoreDemo
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
            this.tabMessaging = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.grpOtherSettings = new System.Windows.Forms.GroupBox();
            this.chkDisableCheckPIN = new System.Windows.Forms.CheckBox();
            this.cmdApplySettings = new System.Windows.Forms.Button();
            this.cmdRefreshSettings = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.chkIncomingCall = new System.Windows.Forms.CheckBox();
            this.txtTimeout = new System.Windows.Forms.TextBox();
            this.txtSendRetry = new System.Windows.Forms.TextBox();
            this.txtSendDelay = new System.Windows.Forms.TextBox();
            this.txtSMSC = new System.Windows.Forms.TextBox();
            this.txtPIN = new System.Windows.Forms.TextBox();
            this.grpPortSettings = new System.Windows.Forms.GroupBox();
            this.cmdDisconnect = new System.Windows.Forms.Button();
            this.cmdConnect = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboFlowControl = new System.Windows.Forms.ComboBox();
            this.cboStopBits = new System.Windows.Forms.ComboBox();
            this.cboParity = new System.Windows.Forms.ComboBox();
            this.cboDataBits = new System.Windows.Forms.ComboBox();
            this.cboBaudRate = new System.Windows.Forms.ComboBox();
            this.cboPort = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdInboxRefresh = new System.Windows.Forms.Button();
            this.cmdMsgDelete = new System.Windows.Forms.Button();
            this.lblMsgCount = new System.Windows.Forms.Label();
            this.lstInbox = new System.Windows.Forms.ListView();
            this.clmFrom = new System.Windows.Forms.ColumnHeader();
            this.clmMessage = new System.Windows.Forms.ColumnHeader();
            this.clmTime = new System.Windows.Forms.ColumnHeader();
            this.chkAutoDelete = new System.Windows.Forms.CheckBox();
            this.chkRefreshInbox = new System.Windows.Forms.CheckBox();
            this.chkCleanUp = new System.Windows.Forms.CheckBox();
            this.chkNewMsgIndication = new System.Windows.Forms.CheckBox();
            this.chkInConcatenate = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cboMsgMemory = new System.Windows.Forms.ComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox20 = new System.Windows.Forms.GroupBox();
            this.cmdClearQueue = new System.Windows.Forms.Button();
            this.lblQueueStatus = new System.Windows.Forms.Label();
            this.lblQueueCount = new System.Windows.Forms.Label();
            this.chkQueue = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.cboValidity = new System.Windows.Forms.ComboBox();
            this.txtValidity = new System.Windows.Forms.TextBox();
            this.cboEncoding = new System.Windows.Forms.ComboBox();
            this.cboLongMsg = new System.Windows.Forms.ComboBox();
            this.chkDeliveryReport = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboSMSQPriority = new System.Windows.Forms.ComboBox();
            this.lblSMSQPriority = new System.Windows.Forms.Label();
            this.chkSMSQueue = new System.Windows.Forms.CheckBox();
            this.cmdSendMsg = new System.Windows.Forms.Button();
            this.lblNoteSMS = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.chkAlert = new System.Windows.Forms.CheckBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblNoteWP = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.cmdSendWapPush = new System.Windows.Forms.Button();
            this.dtpCreated = new System.Windows.Forms.DateTimePicker();
            this.chkExpiry = new System.Windows.Forms.CheckBox();
            this.chkCreated = new System.Windows.Forms.CheckBox();
            this.cboExpiry = new System.Windows.Forms.ComboBox();
            this.cboAction = new System.Windows.Forms.ComboBox();
            this.txtExpiry = new System.Windows.Forms.TextBox();
            this.txtMessageWP = new System.Windows.Forms.TextBox();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.txtPhoneWP = new System.Windows.Forms.TextBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.cmdSendVCard = new System.Windows.Forms.Button();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.txtBusinessZIP = new System.Windows.Forms.TextBox();
            this.txtBusinessCountry = new System.Windows.Forms.TextBox();
            this.txtBusinessState = new System.Windows.Forms.TextBox();
            this.txtBusinessCity = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.txtBusinessStreet = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.txtJobTitle = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.cmdSendVCF = new System.Windows.Forms.Button();
            this.cmdBrowseVCF = new System.Windows.Forms.Button();
            this.txtVCFFile = new System.Windows.Forms.TextBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.txtWebsite = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.txtHomeZIP = new System.Windows.Forms.TextBox();
            this.txtHomeCountry = new System.Windows.Forms.TextBox();
            this.txtHomeState = new System.Windows.Forms.TextBox();
            this.txtHomeCity = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.txtHomeStreet = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txtMobilePhone = new System.Windows.Forms.TextBox();
            this.txtBusinessPhone = new System.Windows.Forms.TextBox();
            this.txtHomePhone = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.txtLName = new System.Windows.Forms.TextBox();
            this.txtMName = new System.Windows.Forms.TextBox();
            this.txtFName = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtPhoneVCF = new System.Windows.Forms.TextBox();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.cmdSendVCS = new System.Windows.Forms.Button();
            this.cmdBrowseVCS = new System.Windows.Forms.Button();
            this.txtVCSFile = new System.Windows.Forms.TextBox();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.cmdSendVCalendar = new System.Windows.Forms.Button();
            this.txtSummary = new System.Windows.Forms.TextBox();
            this.label49 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.cboDuration = new System.Windows.Forms.ComboBox();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.rdbDuration = new System.Windows.Forms.RadioButton();
            this.dtpEndDateTime = new System.Windows.Forms.DateTimePicker();
            this.rdbEndDateTime = new System.Windows.Forms.RadioButton();
            this.dtpStartDateTime = new System.Windows.Forms.DateTimePicker();
            this.label46 = new System.Windows.Forms.Label();
            this.txtPhoneVCL = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.lblIMSI = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.cmdMdmRefresh = new System.Windows.Forms.Button();
            this.lblOwnNum = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.lblBattery = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.lblIMEI = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.lblRevision = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.lblModel = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.lblManufacturer = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.cmdNetRefresh = new System.Windows.Forms.Button();
            this.lblNetwork = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.prbSignal = new System.Windows.Forms.ProgressBar();
            this.label50 = new System.Windows.Forms.Label();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.cmdLogSettings = new System.Windows.Forms.Button();
            this.cmdClearLog = new System.Windows.Forms.Button();
            this.cmdViewLog = new System.Windows.Forms.Button();
            this.cmdLogFolder = new System.Windows.Forms.Button();
            this.txtLogFolder = new System.Windows.Forms.TextBox();
            this.label55 = new System.Windows.Forms.Label();
            this.cboLogType = new System.Windows.Forms.ComboBox();
            this.label53 = new System.Windows.Forms.Label();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.chkDebugMode = new System.Windows.Forms.CheckBox();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.lblTerminalStatus = new System.Windows.Forms.Label();
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.tabPage11 = new System.Windows.Forms.TabPage();
            this.groupBox22 = new System.Windows.Forms.GroupBox();
            this.chkUSSD = new System.Windows.Forms.CheckBox();
            this.lblUSSDStatus = new System.Windows.Forms.Label();
            this.txtUSSDMessage = new System.Windows.Forms.TextBox();
            this.groupBox21 = new System.Windows.Forms.GroupBox();
            this.cmdUSSD = new System.Windows.Forms.Button();
            this.txtUSSDCommand = new System.Windows.Forms.TextBox();
            this.tabPage12 = new System.Windows.Forms.TabPage();
            this.groupBox23 = new System.Windows.Forms.GroupBox();
            this.cmdSendSmartSMS = new System.Windows.Forms.Button();
            this.label61 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.nudDestinationPort = new System.Windows.Forms.NumericUpDown();
            this.txtSmartText = new System.Windows.Forms.TextBox();
            this.txtDestinationPhone = new System.Windows.Forms.TextBox();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.tabMessaging.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.grpOtherSettings.SuspendLayout();
            this.grpPortSettings.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox20.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.groupBox18.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.groupBox19.SuspendLayout();
            this.tabPage11.SuspendLayout();
            this.groupBox22.SuspendLayout();
            this.groupBox21.SuspendLayout();
            this.tabPage12.SuspendLayout();
            this.groupBox23.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDestinationPort)).BeginInit();
            this.SuspendLayout();
            // 
            // tabMessaging
            // 
            this.tabMessaging.Controls.Add(this.tabPage1);
            this.tabMessaging.Controls.Add(this.tabPage2);
            this.tabMessaging.Controls.Add(this.tabPage3);
            this.tabMessaging.Controls.Add(this.tabPage4);
            this.tabMessaging.Controls.Add(this.tabPage5);
            this.tabMessaging.Controls.Add(this.tabPage6);
            this.tabMessaging.Controls.Add(this.tabPage7);
            this.tabMessaging.Controls.Add(this.tabPage8);
            this.tabMessaging.Controls.Add(this.tabPage9);
            this.tabMessaging.Controls.Add(this.tabPage11);
            this.tabMessaging.Controls.Add(this.tabPage12);
            this.tabMessaging.Controls.Add(this.tabPage10);
            this.tabMessaging.Location = new System.Drawing.Point(12, 12);
            this.tabMessaging.Multiline = true;
            this.tabMessaging.Name = "tabMessaging";
            this.tabMessaging.SelectedIndex = 0;
            this.tabMessaging.Size = new System.Drawing.Size(568, 417);
            this.tabMessaging.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabMessaging.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.grpOtherSettings);
            this.tabPage1.Controls.Add(this.grpPortSettings);
            this.tabPage1.Location = new System.Drawing.Point(4, 40);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(560, 373);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Settings";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // grpOtherSettings
            // 
            this.grpOtherSettings.Controls.Add(this.chkDisableCheckPIN);
            this.grpOtherSettings.Controls.Add(this.cmdApplySettings);
            this.grpOtherSettings.Controls.Add(this.cmdRefreshSettings);
            this.grpOtherSettings.Controls.Add(this.label13);
            this.grpOtherSettings.Controls.Add(this.label12);
            this.grpOtherSettings.Controls.Add(this.label11);
            this.grpOtherSettings.Controls.Add(this.label10);
            this.grpOtherSettings.Controls.Add(this.label9);
            this.grpOtherSettings.Controls.Add(this.label8);
            this.grpOtherSettings.Controls.Add(this.label7);
            this.grpOtherSettings.Controls.Add(this.chkIncomingCall);
            this.grpOtherSettings.Controls.Add(this.txtTimeout);
            this.grpOtherSettings.Controls.Add(this.txtSendRetry);
            this.grpOtherSettings.Controls.Add(this.txtSendDelay);
            this.grpOtherSettings.Controls.Add(this.txtSMSC);
            this.grpOtherSettings.Controls.Add(this.txtPIN);
            this.grpOtherSettings.Location = new System.Drawing.Point(286, 6);
            this.grpOtherSettings.Name = "grpOtherSettings";
            this.grpOtherSettings.Size = new System.Drawing.Size(268, 361);
            this.grpOtherSettings.TabIndex = 1;
            this.grpOtherSettings.TabStop = false;
            this.grpOtherSettings.Text = "Other Settings";
            // 
            // chkDisableCheckPIN
            // 
            this.chkDisableCheckPIN.AutoSize = true;
            this.chkDisableCheckPIN.Location = new System.Drawing.Point(95, 56);
            this.chkDisableCheckPIN.Name = "chkDisableCheckPIN";
            this.chkDisableCheckPIN.Size = new System.Drawing.Size(146, 17);
            this.chkDisableCheckPIN.TabIndex = 16;
            this.chkDisableCheckPIN.Text = "Disable PIN status check";
            this.chkDisableCheckPIN.UseVisualStyleBackColor = true;
            this.chkDisableCheckPIN.CheckedChanged += new System.EventHandler(this.chkDisableCheckPIN_CheckedChanged);
            // 
            // cmdApplySettings
            // 
            this.cmdApplySettings.Location = new System.Drawing.Point(29, 310);
            this.cmdApplySettings.Name = "cmdApplySettings";
            this.cmdApplySettings.Size = new System.Drawing.Size(218, 23);
            this.cmdApplySettings.TabIndex = 15;
            this.cmdApplySettings.Text = "Apply";
            this.cmdApplySettings.UseVisualStyleBackColor = true;
            this.cmdApplySettings.Click += new System.EventHandler(this.cmdApplySettings_Click);
            // 
            // cmdRefreshSettings
            // 
            this.cmdRefreshSettings.Location = new System.Drawing.Point(29, 272);
            this.cmdRefreshSettings.Name = "cmdRefreshSettings";
            this.cmdRefreshSettings.Size = new System.Drawing.Size(218, 23);
            this.cmdRefreshSettings.TabIndex = 14;
            this.cmdRefreshSettings.Text = "Refresh";
            this.cmdRefreshSettings.UseVisualStyleBackColor = true;
            this.cmdRefreshSettings.Click += new System.EventHandler(this.cmdRefreshSettings_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(41, 193);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 13);
            this.label13.TabIndex = 12;
            this.label13.Text = "Timeout:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(26, 159);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "Send Retry:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(143, 194);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Seconds";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(143, 125);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Seconds";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 125);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Send Delay:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(49, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "SMSC:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(61, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "PIN:";
            // 
            // chkIncomingCall
            // 
            this.chkIncomingCall.AutoSize = true;
            this.chkIncomingCall.Location = new System.Drawing.Point(44, 229);
            this.chkIncomingCall.Name = "chkIncomingCall";
            this.chkIncomingCall.Size = new System.Drawing.Size(178, 17);
            this.chkIncomingCall.TabIndex = 5;
            this.chkIncomingCall.Text = "Display incoming call information";
            this.chkIncomingCall.UseVisualStyleBackColor = true;
            this.chkIncomingCall.CheckedChanged += new System.EventHandler(this.chkIncomingCall_CheckedChanged);
            // 
            // txtTimeout
            // 
            this.txtTimeout.Location = new System.Drawing.Point(95, 191);
            this.txtTimeout.Name = "txtTimeout";
            this.txtTimeout.Size = new System.Drawing.Size(42, 20);
            this.txtTimeout.TabIndex = 4;
            // 
            // txtSendRetry
            // 
            this.txtSendRetry.Location = new System.Drawing.Point(95, 156);
            this.txtSendRetry.Name = "txtSendRetry";
            this.txtSendRetry.Size = new System.Drawing.Size(42, 20);
            this.txtSendRetry.TabIndex = 3;
            // 
            // txtSendDelay
            // 
            this.txtSendDelay.Location = new System.Drawing.Point(95, 122);
            this.txtSendDelay.Name = "txtSendDelay";
            this.txtSendDelay.Size = new System.Drawing.Size(42, 20);
            this.txtSendDelay.TabIndex = 2;
            // 
            // txtSMSC
            // 
            this.txtSMSC.Location = new System.Drawing.Point(95, 88);
            this.txtSMSC.Name = "txtSMSC";
            this.txtSMSC.Size = new System.Drawing.Size(124, 20);
            this.txtSMSC.TabIndex = 1;
            // 
            // txtPIN
            // 
            this.txtPIN.Location = new System.Drawing.Point(95, 30);
            this.txtPIN.Name = "txtPIN";
            this.txtPIN.Size = new System.Drawing.Size(59, 20);
            this.txtPIN.TabIndex = 0;
            // 
            // grpPortSettings
            // 
            this.grpPortSettings.Controls.Add(this.cmdDisconnect);
            this.grpPortSettings.Controls.Add(this.cmdConnect);
            this.grpPortSettings.Controls.Add(this.label6);
            this.grpPortSettings.Controls.Add(this.label5);
            this.grpPortSettings.Controls.Add(this.label4);
            this.grpPortSettings.Controls.Add(this.label3);
            this.grpPortSettings.Controls.Add(this.label2);
            this.grpPortSettings.Controls.Add(this.label1);
            this.grpPortSettings.Controls.Add(this.cboFlowControl);
            this.grpPortSettings.Controls.Add(this.cboStopBits);
            this.grpPortSettings.Controls.Add(this.cboParity);
            this.grpPortSettings.Controls.Add(this.cboDataBits);
            this.grpPortSettings.Controls.Add(this.cboBaudRate);
            this.grpPortSettings.Controls.Add(this.cboPort);
            this.grpPortSettings.Location = new System.Drawing.Point(6, 6);
            this.grpPortSettings.Name = "grpPortSettings";
            this.grpPortSettings.Size = new System.Drawing.Size(265, 361);
            this.grpPortSettings.TabIndex = 0;
            this.grpPortSettings.TabStop = false;
            this.grpPortSettings.Text = "Serial Port Settings";
            // 
            // cmdDisconnect
            // 
            this.cmdDisconnect.Location = new System.Drawing.Point(14, 310);
            this.cmdDisconnect.Name = "cmdDisconnect";
            this.cmdDisconnect.Size = new System.Drawing.Size(233, 23);
            this.cmdDisconnect.TabIndex = 13;
            this.cmdDisconnect.Text = "Disconnect";
            this.cmdDisconnect.UseVisualStyleBackColor = true;
            this.cmdDisconnect.Click += new System.EventHandler(this.cmdDisconnect_Click);
            // 
            // cmdConnect
            // 
            this.cmdConnect.Location = new System.Drawing.Point(14, 272);
            this.cmdConnect.Name = "cmdConnect";
            this.cmdConnect.Size = new System.Drawing.Size(233, 23);
            this.cmdConnect.TabIndex = 12;
            this.cmdConnect.Text = "Connect";
            this.cmdConnect.UseVisualStyleBackColor = true;
            this.cmdConnect.Click += new System.EventHandler(this.cmdConnect_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 228);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Flow Control:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Stop Bits:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Parity:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Data Bits:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Baud Rate:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Port:";
            // 
            // cboFlowControl
            // 
            this.cboFlowControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFlowControl.FormattingEnabled = true;
            this.cboFlowControl.Location = new System.Drawing.Point(85, 225);
            this.cboFlowControl.Name = "cboFlowControl";
            this.cboFlowControl.Size = new System.Drawing.Size(121, 21);
            this.cboFlowControl.TabIndex = 5;
            // 
            // cboStopBits
            // 
            this.cboStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStopBits.FormattingEnabled = true;
            this.cboStopBits.Location = new System.Drawing.Point(85, 186);
            this.cboStopBits.Name = "cboStopBits";
            this.cboStopBits.Size = new System.Drawing.Size(121, 21);
            this.cboStopBits.TabIndex = 4;
            // 
            // cboParity
            // 
            this.cboParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboParity.FormattingEnabled = true;
            this.cboParity.Location = new System.Drawing.Point(85, 147);
            this.cboParity.Name = "cboParity";
            this.cboParity.Size = new System.Drawing.Size(121, 21);
            this.cboParity.TabIndex = 3;
            // 
            // cboDataBits
            // 
            this.cboDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDataBits.FormattingEnabled = true;
            this.cboDataBits.Location = new System.Drawing.Point(85, 108);
            this.cboDataBits.Name = "cboDataBits";
            this.cboDataBits.Size = new System.Drawing.Size(121, 21);
            this.cboDataBits.TabIndex = 2;
            // 
            // cboBaudRate
            // 
            this.cboBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBaudRate.FormattingEnabled = true;
            this.cboBaudRate.Location = new System.Drawing.Point(85, 69);
            this.cboBaudRate.Name = "cboBaudRate";
            this.cboBaudRate.Size = new System.Drawing.Size(121, 21);
            this.cboBaudRate.TabIndex = 1;
            // 
            // cboPort
            // 
            this.cboPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPort.FormattingEnabled = true;
            this.cboPort.Location = new System.Drawing.Point(85, 30);
            this.cboPort.MaxDropDownItems = 16;
            this.cboPort.Name = "cboPort";
            this.cboPort.Size = new System.Drawing.Size(121, 21);
            this.cboPort.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 40);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(560, 373);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Incoming SMS";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmdInboxRefresh);
            this.groupBox1.Controls.Add(this.cmdMsgDelete);
            this.groupBox1.Controls.Add(this.lblMsgCount);
            this.groupBox1.Controls.Add(this.lstInbox);
            this.groupBox1.Controls.Add(this.chkAutoDelete);
            this.groupBox1.Controls.Add(this.chkRefreshInbox);
            this.groupBox1.Controls.Add(this.chkCleanUp);
            this.groupBox1.Controls.Add(this.chkNewMsgIndication);
            this.groupBox1.Controls.Add(this.chkInConcatenate);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.cboMsgMemory);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(548, 361);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Message Inbox";
            // 
            // cmdInboxRefresh
            // 
            this.cmdInboxRefresh.Location = new System.Drawing.Point(439, 318);
            this.cmdInboxRefresh.Name = "cmdInboxRefresh";
            this.cmdInboxRefresh.Size = new System.Drawing.Size(105, 23);
            this.cmdInboxRefresh.TabIndex = 10;
            this.cmdInboxRefresh.Text = "Refresh";
            this.cmdInboxRefresh.UseVisualStyleBackColor = true;
            this.cmdInboxRefresh.Click += new System.EventHandler(this.cmdInboxRefresh_Click);
            // 
            // cmdMsgDelete
            // 
            this.cmdMsgDelete.Location = new System.Drawing.Point(334, 318);
            this.cmdMsgDelete.Name = "cmdMsgDelete";
            this.cmdMsgDelete.Size = new System.Drawing.Size(105, 23);
            this.cmdMsgDelete.TabIndex = 9;
            this.cmdMsgDelete.Text = "Delete";
            this.cmdMsgDelete.UseVisualStyleBackColor = true;
            this.cmdMsgDelete.Click += new System.EventHandler(this.cmdMsgDelete_Click);
            // 
            // lblMsgCount
            // 
            this.lblMsgCount.Location = new System.Drawing.Point(6, 309);
            this.lblMsgCount.Name = "lblMsgCount";
            this.lblMsgCount.Size = new System.Drawing.Size(322, 32);
            this.lblMsgCount.TabIndex = 8;
            // 
            // lstInbox
            // 
            this.lstInbox.CheckBoxes = true;
            this.lstInbox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmFrom,
            this.clmMessage,
            this.clmTime});
            this.lstInbox.FullRowSelect = true;
            this.lstInbox.GridLines = true;
            this.lstInbox.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstInbox.Location = new System.Drawing.Point(6, 91);
            this.lstInbox.MultiSelect = false;
            this.lstInbox.Name = "lstInbox";
            this.lstInbox.Size = new System.Drawing.Size(536, 215);
            this.lstInbox.TabIndex = 7;
            this.lstInbox.UseCompatibleStateImageBehavior = false;
            this.lstInbox.View = System.Windows.Forms.View.Details;
            this.lstInbox.DoubleClick += new System.EventHandler(this.lstInbox_DoubleClick);
            // 
            // clmFrom
            // 
            this.clmFrom.Text = "From";
            this.clmFrom.Width = 120;
            // 
            // clmMessage
            // 
            this.clmMessage.Text = "Message";
            this.clmMessage.Width = 285;
            // 
            // clmTime
            // 
            this.clmTime.Text = "Date/Time";
            this.clmTime.Width = 125;
            // 
            // chkAutoDelete
            // 
            this.chkAutoDelete.AutoSize = true;
            this.chkAutoDelete.Location = new System.Drawing.Point(356, 45);
            this.chkAutoDelete.Name = "chkAutoDelete";
            this.chkAutoDelete.Size = new System.Drawing.Size(139, 17);
            this.chkAutoDelete.TabIndex = 6;
            this.chkAutoDelete.Text = "Auto delete after display";
            this.chkAutoDelete.UseVisualStyleBackColor = true;
            this.chkAutoDelete.CheckedChanged += new System.EventHandler(this.chkAutoDelete_CheckedChanged);
            // 
            // chkRefreshInbox
            // 
            this.chkRefreshInbox.AutoSize = true;
            this.chkRefreshInbox.Location = new System.Drawing.Point(356, 21);
            this.chkRefreshInbox.Name = "chkRefreshInbox";
            this.chkRefreshInbox.Size = new System.Drawing.Size(174, 17);
            this.chkRefreshInbox.TabIndex = 5;
            this.chkRefreshInbox.Text = "Refresh inbox on new message";
            this.chkRefreshInbox.UseVisualStyleBackColor = true;
            // 
            // chkCleanUp
            // 
            this.chkCleanUp.AutoSize = true;
            this.chkCleanUp.Location = new System.Drawing.Point(161, 68);
            this.chkCleanUp.Name = "chkCleanUp";
            this.chkCleanUp.Size = new System.Drawing.Size(335, 17);
            this.chkCleanUp.TabIndex = 4;
            this.chkCleanUp.Text = "Clean up message memory on refresh (i.e. delete smart-messages)";
            this.chkCleanUp.UseVisualStyleBackColor = true;
            // 
            // chkNewMsgIndication
            // 
            this.chkNewMsgIndication.AutoSize = true;
            this.chkNewMsgIndication.Location = new System.Drawing.Point(161, 45);
            this.chkNewMsgIndication.Name = "chkNewMsgIndication";
            this.chkNewMsgIndication.Size = new System.Drawing.Size(175, 17);
            this.chkNewMsgIndication.TabIndex = 3;
            this.chkNewMsgIndication.Text = "Enable new message indication";
            this.chkNewMsgIndication.UseVisualStyleBackColor = true;
            this.chkNewMsgIndication.CheckedChanged += new System.EventHandler(this.chkNewMsgIndication_CheckedChanged);
            // 
            // chkInConcatenate
            // 
            this.chkInConcatenate.AutoSize = true;
            this.chkInConcatenate.Location = new System.Drawing.Point(161, 21);
            this.chkInConcatenate.Name = "chkInConcatenate";
            this.chkInConcatenate.Size = new System.Drawing.Size(130, 17);
            this.chkInConcatenate.TabIndex = 2;
            this.chkInConcatenate.Text = "Enable concatenation";
            this.chkInConcatenate.UseVisualStyleBackColor = true;
            this.chkInConcatenate.CheckedChanged += new System.EventHandler(this.chkInConcatenate_CheckedChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(17, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(93, 13);
            this.label14.TabIndex = 1;
            this.label14.Text = "Message Memory:";
            // 
            // cboMsgMemory
            // 
            this.cboMsgMemory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMsgMemory.FormattingEnabled = true;
            this.cboMsgMemory.Location = new System.Drawing.Point(20, 37);
            this.cboMsgMemory.Name = "cboMsgMemory";
            this.cboMsgMemory.Size = new System.Drawing.Size(90, 21);
            this.cboMsgMemory.TabIndex = 0;
            this.cboMsgMemory.SelectedIndexChanged += new System.EventHandler(this.cboMsgMemory_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox20);
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Location = new System.Drawing.Point(4, 40);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(560, 373);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Send SMS";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox20
            // 
            this.groupBox20.Controls.Add(this.cmdClearQueue);
            this.groupBox20.Controls.Add(this.lblQueueStatus);
            this.groupBox20.Controls.Add(this.lblQueueCount);
            this.groupBox20.Controls.Add(this.chkQueue);
            this.groupBox20.Location = new System.Drawing.Point(327, 208);
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.Size = new System.Drawing.Size(227, 159);
            this.groupBox20.TabIndex = 2;
            this.groupBox20.TabStop = false;
            this.groupBox20.Text = "Message Queue";
            // 
            // cmdClearQueue
            // 
            this.cmdClearQueue.Location = new System.Drawing.Point(20, 122);
            this.cmdClearQueue.Name = "cmdClearQueue";
            this.cmdClearQueue.Size = new System.Drawing.Size(188, 23);
            this.cmdClearQueue.TabIndex = 3;
            this.cmdClearQueue.Text = "Clear Queue";
            this.cmdClearQueue.UseVisualStyleBackColor = true;
            this.cmdClearQueue.Click += new System.EventHandler(this.cmdClearQueue_Click);
            // 
            // lblQueueStatus
            // 
            this.lblQueueStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQueueStatus.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblQueueStatus.Location = new System.Drawing.Point(6, 72);
            this.lblQueueStatus.Name = "lblQueueStatus";
            this.lblQueueStatus.Size = new System.Drawing.Size(215, 44);
            this.lblQueueStatus.TabIndex = 2;
            // 
            // lblQueueCount
            // 
            this.lblQueueCount.AutoSize = true;
            this.lblQueueCount.Location = new System.Drawing.Point(17, 47);
            this.lblQueueCount.Name = "lblQueueCount";
            this.lblQueueCount.Size = new System.Drawing.Size(102, 13);
            this.lblQueueCount.TabIndex = 1;
            this.lblQueueCount.Text = "Messages in queue:";
            // 
            // chkQueue
            // 
            this.chkQueue.AutoSize = true;
            this.chkQueue.Location = new System.Drawing.Point(20, 19);
            this.chkQueue.Name = "chkQueue";
            this.chkQueue.Size = new System.Drawing.Size(137, 17);
            this.chkQueue.TabIndex = 0;
            this.chkQueue.Text = "Enable message queue";
            this.chkQueue.UseVisualStyleBackColor = true;
            this.chkQueue.CheckedChanged += new System.EventHandler(this.chkQueue_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.cboValidity);
            this.groupBox3.Controls.Add(this.txtValidity);
            this.groupBox3.Controls.Add(this.cboEncoding);
            this.groupBox3.Controls.Add(this.cboLongMsg);
            this.groupBox3.Controls.Add(this.chkDeliveryReport);
            this.groupBox3.Location = new System.Drawing.Point(327, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(227, 196);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Message Settings";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(17, 148);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(76, 13);
            this.label20.TabIndex = 8;
            this.label20.Text = "Validity Period:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(17, 100);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(55, 13);
            this.label19.TabIndex = 7;
            this.label19.Text = "Encoding:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(17, 54);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(85, 13);
            this.label18.TabIndex = 6;
            this.label18.Text = "Long Messages:";
            // 
            // cboValidity
            // 
            this.cboValidity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboValidity.FormattingEnabled = true;
            this.cboValidity.Location = new System.Drawing.Point(59, 164);
            this.cboValidity.Name = "cboValidity";
            this.cboValidity.Size = new System.Drawing.Size(54, 21);
            this.cboValidity.TabIndex = 5;
            // 
            // txtValidity
            // 
            this.txtValidity.Location = new System.Drawing.Point(20, 164);
            this.txtValidity.Multiline = true;
            this.txtValidity.Name = "txtValidity";
            this.txtValidity.Size = new System.Drawing.Size(40, 21);
            this.txtValidity.TabIndex = 4;
            // 
            // cboEncoding
            // 
            this.cboEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEncoding.FormattingEnabled = true;
            this.cboEncoding.Location = new System.Drawing.Point(20, 116);
            this.cboEncoding.Name = "cboEncoding";
            this.cboEncoding.Size = new System.Drawing.Size(145, 21);
            this.cboEncoding.TabIndex = 3;
            this.cboEncoding.SelectedIndexChanged += new System.EventHandler(this.cboEncoding_SelectedIndexChanged);
            // 
            // cboLongMsg
            // 
            this.cboLongMsg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLongMsg.FormattingEnabled = true;
            this.cboLongMsg.Location = new System.Drawing.Point(20, 70);
            this.cboLongMsg.Name = "cboLongMsg";
            this.cboLongMsg.Size = new System.Drawing.Size(145, 21);
            this.cboLongMsg.TabIndex = 2;
            this.cboLongMsg.SelectedIndexChanged += new System.EventHandler(this.cboLongMsg_SelectedIndexChanged);
            // 
            // chkDeliveryReport
            // 
            this.chkDeliveryReport.AutoSize = true;
            this.chkDeliveryReport.Location = new System.Drawing.Point(20, 27);
            this.chkDeliveryReport.Name = "chkDeliveryReport";
            this.chkDeliveryReport.Size = new System.Drawing.Size(145, 17);
            this.chkDeliveryReport.TabIndex = 1;
            this.chkDeliveryReport.Text = "Message Delivery Report";
            this.chkDeliveryReport.UseVisualStyleBackColor = true;
            this.chkDeliveryReport.CheckedChanged += new System.EventHandler(this.chkDeliveryReport_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboSMSQPriority);
            this.groupBox2.Controls.Add(this.lblSMSQPriority);
            this.groupBox2.Controls.Add(this.chkSMSQueue);
            this.groupBox2.Controls.Add(this.cmdSendMsg);
            this.groupBox2.Controls.Add(this.lblNoteSMS);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.txtMessage);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.txtPhone);
            this.groupBox2.Controls.Add(this.chkAlert);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(308, 361);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Send Message";
            // 
            // cboSMSQPriority
            // 
            this.cboSMSQPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSMSQPriority.FormattingEnabled = true;
            this.cboSMSQPriority.Location = new System.Drawing.Point(92, 280);
            this.cboSMSQPriority.Name = "cboSMSQPriority";
            this.cboSMSQPriority.Size = new System.Drawing.Size(62, 21);
            this.cboSMSQPriority.TabIndex = 8;
            // 
            // lblSMSQPriority
            // 
            this.lblSMSQPriority.AutoSize = true;
            this.lblSMSQPriority.Location = new System.Drawing.Point(15, 283);
            this.lblSMSQPriority.Name = "lblSMSQPriority";
            this.lblSMSQPriority.Size = new System.Drawing.Size(76, 13);
            this.lblSMSQPriority.TabIndex = 7;
            this.lblSMSQPriority.Text = "Queue Priority:";
            // 
            // chkSMSQueue
            // 
            this.chkSMSQueue.AutoSize = true;
            this.chkSMSQueue.Location = new System.Drawing.Point(18, 259);
            this.chkSMSQueue.Name = "chkSMSQueue";
            this.chkSMSQueue.Size = new System.Drawing.Size(141, 17);
            this.chkSMSQueue.TabIndex = 6;
            this.chkSMSQueue.Text = "Send to message queue";
            this.chkSMSQueue.UseVisualStyleBackColor = true;
            this.chkSMSQueue.CheckedChanged += new System.EventHandler(this.chkSMSQueue_CheckedChanged);
            // 
            // cmdSendMsg
            // 
            this.cmdSendMsg.Location = new System.Drawing.Point(18, 324);
            this.cmdSendMsg.Name = "cmdSendMsg";
            this.cmdSendMsg.Size = new System.Drawing.Size(264, 23);
            this.cmdSendMsg.TabIndex = 5;
            this.cmdSendMsg.Text = "Send Message";
            this.cmdSendMsg.UseVisualStyleBackColor = true;
            this.cmdSendMsg.Click += new System.EventHandler(this.cmdSendMsg_Click);
            // 
            // lblNoteSMS
            // 
            this.lblNoteSMS.Location = new System.Drawing.Point(15, 179);
            this.lblNoteSMS.Name = "lblNoteSMS";
            this.lblNoteSMS.Size = new System.Drawing.Size(267, 67);
            this.lblNoteSMS.TabIndex = 4;
            this.lblNoteSMS.Text = "NOTE:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(15, 75);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(77, 13);
            this.label16.TabIndex = 3;
            this.label16.Text = "Text Message:";
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(18, 91);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage.Size = new System.Drawing.Size(264, 76);
            this.txtMessage.TabIndex = 2;
            this.txtMessage.Text = "Test Message";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(15, 33);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(81, 13);
            this.label15.TabIndex = 1;
            this.label15.Text = "Phone Number:";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(102, 29);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(180, 20);
            this.txtPhone.TabIndex = 0;
            this.txtPhone.Text = "+989124389435";
            // 
            // chkAlert
            // 
            this.chkAlert.AutoSize = true;
            this.chkAlert.Location = new System.Drawing.Point(189, 74);
            this.chkAlert.Name = "chkAlert";
            this.chkAlert.Size = new System.Drawing.Size(93, 17);
            this.chkAlert.TabIndex = 0;
            this.chkAlert.Text = "Alert Message";
            this.chkAlert.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox4);
            this.tabPage4.Location = new System.Drawing.Point(4, 40);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(560, 373);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "WAP Push";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblNoteWP);
            this.groupBox4.Controls.Add(this.label24);
            this.groupBox4.Controls.Add(this.label23);
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Controls.Add(this.cmdSendWapPush);
            this.groupBox4.Controls.Add(this.dtpCreated);
            this.groupBox4.Controls.Add(this.chkExpiry);
            this.groupBox4.Controls.Add(this.chkCreated);
            this.groupBox4.Controls.Add(this.cboExpiry);
            this.groupBox4.Controls.Add(this.cboAction);
            this.groupBox4.Controls.Add(this.txtExpiry);
            this.groupBox4.Controls.Add(this.txtMessageWP);
            this.groupBox4.Controls.Add(this.txtURL);
            this.groupBox4.Controls.Add(this.txtPhoneWP);
            this.groupBox4.Location = new System.Drawing.Point(6, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(548, 361);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Send WAP Push";
            // 
            // lblNoteWP
            // 
            this.lblNoteWP.Location = new System.Drawing.Point(21, 257);
            this.lblNoteWP.Name = "lblNoteWP";
            this.lblNoteWP.Size = new System.Drawing.Size(209, 55);
            this.lblNoteWP.TabIndex = 15;
            this.lblNoteWP.Text = "NOTE:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(301, 155);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(40, 13);
            this.label24.TabIndex = 14;
            this.label24.Text = "Action:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(18, 151);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(77, 13);
            this.label23.TabIndex = 13;
            this.label23.Text = "Text Message:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(18, 96);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(32, 13);
            this.label22.TabIndex = 12;
            this.label22.Text = "URL:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(18, 45);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(111, 13);
            this.label21.TabIndex = 11;
            this.label21.Text = "Send To (Phone No.):";
            // 
            // cmdSendWapPush
            // 
            this.cmdSendWapPush.Location = new System.Drawing.Point(304, 279);
            this.cmdSendWapPush.Name = "cmdSendWapPush";
            this.cmdSendWapPush.Size = new System.Drawing.Size(207, 23);
            this.cmdSendWapPush.TabIndex = 10;
            this.cmdSendWapPush.Text = "Send WAP Push";
            this.cmdSendWapPush.UseVisualStyleBackColor = true;
            this.cmdSendWapPush.Click += new System.EventHandler(this.cmdSendWapPush_Click);
            // 
            // dtpCreated
            // 
            this.dtpCreated.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCreated.Location = new System.Drawing.Point(367, 185);
            this.dtpCreated.Name = "dtpCreated";
            this.dtpCreated.Size = new System.Drawing.Size(144, 20);
            this.dtpCreated.TabIndex = 9;
            // 
            // chkExpiry
            // 
            this.chkExpiry.AutoSize = true;
            this.chkExpiry.Location = new System.Drawing.Point(304, 225);
            this.chkExpiry.Name = "chkExpiry";
            this.chkExpiry.Size = new System.Drawing.Size(57, 17);
            this.chkExpiry.TabIndex = 8;
            this.chkExpiry.Text = "Expiry:";
            this.chkExpiry.UseVisualStyleBackColor = true;
            this.chkExpiry.CheckedChanged += new System.EventHandler(this.chkExpiry_CheckedChanged);
            // 
            // chkCreated
            // 
            this.chkCreated.AutoSize = true;
            this.chkCreated.Location = new System.Drawing.Point(304, 188);
            this.chkCreated.Name = "chkCreated";
            this.chkCreated.Size = new System.Drawing.Size(66, 17);
            this.chkCreated.TabIndex = 7;
            this.chkCreated.Text = "Created:";
            this.chkCreated.UseVisualStyleBackColor = true;
            this.chkCreated.CheckedChanged += new System.EventHandler(this.chkCreated_CheckedChanged);
            // 
            // cboExpiry
            // 
            this.cboExpiry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboExpiry.FormattingEnabled = true;
            this.cboExpiry.Location = new System.Drawing.Point(428, 223);
            this.cboExpiry.Name = "cboExpiry";
            this.cboExpiry.Size = new System.Drawing.Size(83, 21);
            this.cboExpiry.TabIndex = 6;
            // 
            // cboAction
            // 
            this.cboAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAction.FormattingEnabled = true;
            this.cboAction.Location = new System.Drawing.Point(367, 151);
            this.cboAction.Name = "cboAction";
            this.cboAction.Size = new System.Drawing.Size(144, 21);
            this.cboAction.TabIndex = 4;
            // 
            // txtExpiry
            // 
            this.txtExpiry.Location = new System.Drawing.Point(367, 223);
            this.txtExpiry.Multiline = true;
            this.txtExpiry.Name = "txtExpiry";
            this.txtExpiry.Size = new System.Drawing.Size(61, 21);
            this.txtExpiry.TabIndex = 3;
            // 
            // txtMessageWP
            // 
            this.txtMessageWP.Location = new System.Drawing.Point(21, 167);
            this.txtMessageWP.Multiline = true;
            this.txtMessageWP.Name = "txtMessageWP";
            this.txtMessageWP.Size = new System.Drawing.Size(209, 77);
            this.txtMessageWP.TabIndex = 2;
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(21, 112);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(490, 20);
            this.txtURL.TabIndex = 1;
            // 
            // txtPhoneWP
            // 
            this.txtPhoneWP.Location = new System.Drawing.Point(21, 61);
            this.txtPhoneWP.Name = "txtPhoneWP";
            this.txtPhoneWP.Size = new System.Drawing.Size(209, 20);
            this.txtPhoneWP.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.cmdSendVCard);
            this.tabPage5.Controls.Add(this.groupBox12);
            this.tabPage5.Controls.Add(this.groupBox11);
            this.tabPage5.Controls.Add(this.groupBox10);
            this.tabPage5.Controls.Add(this.groupBox9);
            this.tabPage5.Controls.Add(this.groupBox8);
            this.tabPage5.Controls.Add(this.groupBox7);
            this.tabPage5.Controls.Add(this.groupBox6);
            this.tabPage5.Controls.Add(this.groupBox5);
            this.tabPage5.Location = new System.Drawing.Point(4, 40);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(560, 373);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "vCard";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // cmdSendVCard
            // 
            this.cmdSendVCard.Location = new System.Drawing.Point(360, 289);
            this.cmdSendVCard.Name = "cmdSendVCard";
            this.cmdSendVCard.Size = new System.Drawing.Size(194, 23);
            this.cmdSendVCard.TabIndex = 8;
            this.cmdSendVCard.Text = "Send vCard";
            this.cmdSendVCard.UseVisualStyleBackColor = true;
            this.cmdSendVCard.Click += new System.EventHandler(this.cmdSendVCard_Click);
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.txtBusinessZIP);
            this.groupBox12.Controls.Add(this.txtBusinessCountry);
            this.groupBox12.Controls.Add(this.txtBusinessState);
            this.groupBox12.Controls.Add(this.txtBusinessCity);
            this.groupBox12.Controls.Add(this.label44);
            this.groupBox12.Controls.Add(this.label43);
            this.groupBox12.Controls.Add(this.label42);
            this.groupBox12.Controls.Add(this.label41);
            this.groupBox12.Controls.Add(this.txtBusinessStreet);
            this.groupBox12.Controls.Add(this.label40);
            this.groupBox12.Controls.Add(this.txtCompany);
            this.groupBox12.Controls.Add(this.label39);
            this.groupBox12.Controls.Add(this.txtJobTitle);
            this.groupBox12.Controls.Add(this.label38);
            this.groupBox12.Location = new System.Drawing.Point(360, 4);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(194, 258);
            this.groupBox12.TabIndex = 7;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Business";
            // 
            // txtBusinessZIP
            // 
            this.txtBusinessZIP.Location = new System.Drawing.Point(50, 229);
            this.txtBusinessZIP.Name = "txtBusinessZIP";
            this.txtBusinessZIP.Size = new System.Drawing.Size(130, 20);
            this.txtBusinessZIP.TabIndex = 13;
            // 
            // txtBusinessCountry
            // 
            this.txtBusinessCountry.Location = new System.Drawing.Point(50, 203);
            this.txtBusinessCountry.Name = "txtBusinessCountry";
            this.txtBusinessCountry.Size = new System.Drawing.Size(130, 20);
            this.txtBusinessCountry.TabIndex = 12;
            // 
            // txtBusinessState
            // 
            this.txtBusinessState.Location = new System.Drawing.Point(50, 177);
            this.txtBusinessState.Name = "txtBusinessState";
            this.txtBusinessState.Size = new System.Drawing.Size(130, 20);
            this.txtBusinessState.TabIndex = 11;
            // 
            // txtBusinessCity
            // 
            this.txtBusinessCity.Location = new System.Drawing.Point(50, 151);
            this.txtBusinessCity.Name = "txtBusinessCity";
            this.txtBusinessCity.Size = new System.Drawing.Size(130, 20);
            this.txtBusinessCity.TabIndex = 10;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(20, 233);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(27, 13);
            this.label44.TabIndex = 9;
            this.label44.Text = "ZIP:";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(1, 207);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(46, 13);
            this.label43.TabIndex = 8;
            this.label43.Text = "Country:";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(12, 181);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(35, 13);
            this.label42.TabIndex = 7;
            this.label42.Text = "State:";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(20, 155);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(27, 13);
            this.label41.TabIndex = 6;
            this.label41.Text = "City:";
            // 
            // txtBusinessStreet
            // 
            this.txtBusinessStreet.Location = new System.Drawing.Point(9, 88);
            this.txtBusinessStreet.Multiline = true;
            this.txtBusinessStreet.Name = "txtBusinessStreet";
            this.txtBusinessStreet.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBusinessStreet.Size = new System.Drawing.Size(173, 57);
            this.txtBusinessStreet.TabIndex = 5;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(6, 73);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(79, 13);
            this.label40.TabIndex = 4;
            this.label40.Text = "Street Address:";
            // 
            // txtCompany
            // 
            this.txtCompany.Location = new System.Drawing.Point(62, 44);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Size = new System.Drawing.Size(120, 20);
            this.txtCompany.TabIndex = 3;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(4, 47);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(54, 13);
            this.label39.TabIndex = 2;
            this.label39.Text = "Company:";
            // 
            // txtJobTitle
            // 
            this.txtJobTitle.Location = new System.Drawing.Point(62, 15);
            this.txtJobTitle.Name = "txtJobTitle";
            this.txtJobTitle.Size = new System.Drawing.Size(120, 20);
            this.txtJobTitle.TabIndex = 1;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(8, 18);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(50, 13);
            this.label38.TabIndex = 0;
            this.label38.Text = "Job Title:";
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.cmdSendVCF);
            this.groupBox11.Controls.Add(this.cmdBrowseVCF);
            this.groupBox11.Controls.Add(this.txtVCFFile);
            this.groupBox11.Location = new System.Drawing.Point(7, 320);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(547, 47);
            this.groupBox11.TabIndex = 6;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Send vCard File (.vcf file)";
            // 
            // cmdSendVCF
            // 
            this.cmdSendVCF.Location = new System.Drawing.Point(444, 16);
            this.cmdSendVCF.Name = "cmdSendVCF";
            this.cmdSendVCF.Size = new System.Drawing.Size(97, 23);
            this.cmdSendVCF.TabIndex = 2;
            this.cmdSendVCF.Text = "Send";
            this.cmdSendVCF.UseVisualStyleBackColor = true;
            this.cmdSendVCF.Click += new System.EventHandler(this.cmdSendVCF_Click);
            // 
            // cmdBrowseVCF
            // 
            this.cmdBrowseVCF.Location = new System.Drawing.Point(385, 16);
            this.cmdBrowseVCF.Name = "cmdBrowseVCF";
            this.cmdBrowseVCF.Size = new System.Drawing.Size(53, 23);
            this.cmdBrowseVCF.TabIndex = 1;
            this.cmdBrowseVCF.Text = "Browse";
            this.cmdBrowseVCF.UseVisualStyleBackColor = true;
            this.cmdBrowseVCF.Click += new System.EventHandler(this.cmdBrowseVCF_Click);
            // 
            // txtVCFFile
            // 
            this.txtVCFFile.Location = new System.Drawing.Point(10, 19);
            this.txtVCFFile.Name = "txtVCFFile";
            this.txtVCFFile.Size = new System.Drawing.Size(369, 20);
            this.txtVCFFile.TabIndex = 0;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.txtWebsite);
            this.groupBox10.Controls.Add(this.label37);
            this.groupBox10.Controls.Add(this.txtEmail);
            this.groupBox10.Controls.Add(this.label36);
            this.groupBox10.Location = new System.Drawing.Point(209, 220);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(145, 97);
            this.groupBox10.TabIndex = 5;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Internet";
            // 
            // txtWebsite
            // 
            this.txtWebsite.Location = new System.Drawing.Point(9, 71);
            this.txtWebsite.Name = "txtWebsite";
            this.txtWebsite.Size = new System.Drawing.Size(130, 20);
            this.txtWebsite.TabIndex = 3;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(6, 55);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(49, 13);
            this.label37.TabIndex = 2;
            this.label37.Text = "Website:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(9, 32);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(130, 20);
            this.txtEmail.TabIndex = 1;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(6, 16);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(35, 13);
            this.label36.TabIndex = 0;
            this.label36.Text = "Email:";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.txtHomeZIP);
            this.groupBox9.Controls.Add(this.txtHomeCountry);
            this.groupBox9.Controls.Add(this.txtHomeState);
            this.groupBox9.Controls.Add(this.txtHomeCity);
            this.groupBox9.Controls.Add(this.label35);
            this.groupBox9.Controls.Add(this.label34);
            this.groupBox9.Controls.Add(this.label33);
            this.groupBox9.Controls.Add(this.label32);
            this.groupBox9.Controls.Add(this.txtHomeStreet);
            this.groupBox9.Controls.Add(this.label31);
            this.groupBox9.Location = new System.Drawing.Point(209, 4);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(145, 210);
            this.groupBox9.TabIndex = 4;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Home";
            // 
            // txtHomeZIP
            // 
            this.txtHomeZIP.Location = new System.Drawing.Point(54, 177);
            this.txtHomeZIP.Name = "txtHomeZIP";
            this.txtHomeZIP.Size = new System.Drawing.Size(77, 20);
            this.txtHomeZIP.TabIndex = 9;
            // 
            // txtHomeCountry
            // 
            this.txtHomeCountry.Location = new System.Drawing.Point(54, 151);
            this.txtHomeCountry.Name = "txtHomeCountry";
            this.txtHomeCountry.Size = new System.Drawing.Size(77, 20);
            this.txtHomeCountry.TabIndex = 8;
            // 
            // txtHomeState
            // 
            this.txtHomeState.Location = new System.Drawing.Point(54, 125);
            this.txtHomeState.Name = "txtHomeState";
            this.txtHomeState.Size = new System.Drawing.Size(77, 20);
            this.txtHomeState.TabIndex = 7;
            // 
            // txtHomeCity
            // 
            this.txtHomeCity.Location = new System.Drawing.Point(54, 99);
            this.txtHomeCity.Name = "txtHomeCity";
            this.txtHomeCity.Size = new System.Drawing.Size(77, 20);
            this.txtHomeCity.TabIndex = 6;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(19, 181);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(27, 13);
            this.label35.TabIndex = 5;
            this.label35.Text = "ZIP:";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(2, 155);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(46, 13);
            this.label34.TabIndex = 4;
            this.label34.Text = "Country:";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(13, 129);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(35, 13);
            this.label33.TabIndex = 3;
            this.label33.Text = "State:";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(21, 103);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(27, 13);
            this.label32.TabIndex = 2;
            this.label32.Text = "City:";
            // 
            // txtHomeStreet
            // 
            this.txtHomeStreet.Location = new System.Drawing.Point(11, 34);
            this.txtHomeStreet.Multiline = true;
            this.txtHomeStreet.Name = "txtHomeStreet";
            this.txtHomeStreet.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtHomeStreet.Size = new System.Drawing.Size(120, 60);
            this.txtHomeStreet.TabIndex = 1;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(8, 18);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(79, 13);
            this.label31.TabIndex = 0;
            this.label31.Text = "Street Address:";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.txtComment);
            this.groupBox8.Location = new System.Drawing.Point(6, 268);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(197, 49);
            this.groupBox8.TabIndex = 3;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Comment";
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(10, 19);
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(175, 20);
            this.txtComment.TabIndex = 0;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.txtMobilePhone);
            this.groupBox7.Controls.Add(this.txtBusinessPhone);
            this.groupBox7.Controls.Add(this.txtHomePhone);
            this.groupBox7.Controls.Add(this.label30);
            this.groupBox7.Controls.Add(this.label29);
            this.groupBox7.Controls.Add(this.label28);
            this.groupBox7.Location = new System.Drawing.Point(6, 161);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(197, 101);
            this.groupBox7.TabIndex = 2;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Telephone";
            // 
            // txtMobilePhone
            // 
            this.txtMobilePhone.Location = new System.Drawing.Point(84, 69);
            this.txtMobilePhone.Name = "txtMobilePhone";
            this.txtMobilePhone.Size = new System.Drawing.Size(100, 20);
            this.txtMobilePhone.TabIndex = 5;
            // 
            // txtBusinessPhone
            // 
            this.txtBusinessPhone.Location = new System.Drawing.Point(84, 45);
            this.txtBusinessPhone.Name = "txtBusinessPhone";
            this.txtBusinessPhone.Size = new System.Drawing.Size(100, 20);
            this.txtBusinessPhone.TabIndex = 4;
            // 
            // txtHomePhone
            // 
            this.txtHomePhone.Location = new System.Drawing.Point(84, 19);
            this.txtHomePhone.Name = "txtHomePhone";
            this.txtHomePhone.Size = new System.Drawing.Size(100, 20);
            this.txtHomePhone.TabIndex = 3;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(37, 72);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(41, 13);
            this.label30.TabIndex = 2;
            this.label30.Text = "Mobile:";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(27, 47);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(52, 13);
            this.label29.TabIndex = 1;
            this.label29.Text = "Business:";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(40, 22);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(38, 13);
            this.label28.TabIndex = 0;
            this.label28.Text = "Home:";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label27);
            this.groupBox6.Controls.Add(this.label26);
            this.groupBox6.Controls.Add(this.label25);
            this.groupBox6.Controls.Add(this.txtLName);
            this.groupBox6.Controls.Add(this.txtMName);
            this.groupBox6.Controls.Add(this.txtFName);
            this.groupBox6.Location = new System.Drawing.Point(6, 51);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(197, 104);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Contact Name";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(19, 73);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(61, 13);
            this.label27.TabIndex = 5;
            this.label27.Text = "Last Name:";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(8, 48);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(72, 13);
            this.label26.TabIndex = 4;
            this.label26.Text = "Middle Name:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(20, 23);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(60, 13);
            this.label25.TabIndex = 3;
            this.label25.Text = "First Name:";
            // 
            // txtLName
            // 
            this.txtLName.Location = new System.Drawing.Point(86, 69);
            this.txtLName.Name = "txtLName";
            this.txtLName.Size = new System.Drawing.Size(100, 20);
            this.txtLName.TabIndex = 2;
            // 
            // txtMName
            // 
            this.txtMName.Location = new System.Drawing.Point(86, 44);
            this.txtMName.Name = "txtMName";
            this.txtMName.Size = new System.Drawing.Size(100, 20);
            this.txtMName.TabIndex = 1;
            // 
            // txtFName
            // 
            this.txtFName.Location = new System.Drawing.Point(86, 19);
            this.txtFName.Name = "txtFName";
            this.txtFName.Size = new System.Drawing.Size(100, 20);
            this.txtFName.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtPhoneVCF);
            this.groupBox5.Location = new System.Drawing.Point(6, 4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(197, 41);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Send vCard To (Phone No.)";
            // 
            // txtPhoneVCF
            // 
            this.txtPhoneVCF.Location = new System.Drawing.Point(10, 15);
            this.txtPhoneVCF.Name = "txtPhoneVCF";
            this.txtPhoneVCF.Size = new System.Drawing.Size(175, 20);
            this.txtPhoneVCF.TabIndex = 0;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.groupBox14);
            this.tabPage6.Controls.Add(this.groupBox13);
            this.tabPage6.Location = new System.Drawing.Point(4, 40);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(560, 373);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "vCalendar";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.cmdSendVCS);
            this.groupBox14.Controls.Add(this.cmdBrowseVCS);
            this.groupBox14.Controls.Add(this.txtVCSFile);
            this.groupBox14.Location = new System.Drawing.Point(6, 275);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(547, 92);
            this.groupBox14.TabIndex = 1;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Send vCalendar File (.vcs file)";
            // 
            // cmdSendVCS
            // 
            this.cmdSendVCS.Location = new System.Drawing.Point(438, 35);
            this.cmdSendVCS.Name = "cmdSendVCS";
            this.cmdSendVCS.Size = new System.Drawing.Size(96, 23);
            this.cmdSendVCS.TabIndex = 2;
            this.cmdSendVCS.Text = "Send";
            this.cmdSendVCS.UseVisualStyleBackColor = true;
            this.cmdSendVCS.Click += new System.EventHandler(this.cmdSendVCS_Click);
            // 
            // cmdBrowseVCS
            // 
            this.cmdBrowseVCS.Location = new System.Drawing.Point(378, 35);
            this.cmdBrowseVCS.Name = "cmdBrowseVCS";
            this.cmdBrowseVCS.Size = new System.Drawing.Size(54, 23);
            this.cmdBrowseVCS.TabIndex = 1;
            this.cmdBrowseVCS.Text = "Browse";
            this.cmdBrowseVCS.UseVisualStyleBackColor = true;
            this.cmdBrowseVCS.Click += new System.EventHandler(this.cmdBrowseVCS_Click);
            // 
            // txtVCSFile
            // 
            this.txtVCSFile.Location = new System.Drawing.Point(17, 37);
            this.txtVCSFile.Name = "txtVCSFile";
            this.txtVCSFile.Size = new System.Drawing.Size(355, 20);
            this.txtVCSFile.TabIndex = 0;
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.cmdSendVCalendar);
            this.groupBox13.Controls.Add(this.txtSummary);
            this.groupBox13.Controls.Add(this.label49);
            this.groupBox13.Controls.Add(this.txtDescription);
            this.groupBox13.Controls.Add(this.label48);
            this.groupBox13.Controls.Add(this.txtLocation);
            this.groupBox13.Controls.Add(this.label47);
            this.groupBox13.Controls.Add(this.cboDuration);
            this.groupBox13.Controls.Add(this.txtDuration);
            this.groupBox13.Controls.Add(this.rdbDuration);
            this.groupBox13.Controls.Add(this.dtpEndDateTime);
            this.groupBox13.Controls.Add(this.rdbEndDateTime);
            this.groupBox13.Controls.Add(this.dtpStartDateTime);
            this.groupBox13.Controls.Add(this.label46);
            this.groupBox13.Controls.Add(this.txtPhoneVCL);
            this.groupBox13.Controls.Add(this.label45);
            this.groupBox13.Location = new System.Drawing.Point(6, 6);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(547, 263);
            this.groupBox13.TabIndex = 0;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Send vCalendar";
            // 
            // cmdSendVCalendar
            // 
            this.cmdSendVCalendar.Location = new System.Drawing.Point(293, 214);
            this.cmdSendVCalendar.Name = "cmdSendVCalendar";
            this.cmdSendVCalendar.Size = new System.Drawing.Size(239, 23);
            this.cmdSendVCalendar.TabIndex = 15;
            this.cmdSendVCalendar.Text = "Send vCalendar";
            this.cmdSendVCalendar.UseVisualStyleBackColor = true;
            this.cmdSendVCalendar.Click += new System.EventHandler(this.cmdSendVCalendar_Click);
            // 
            // txtSummary
            // 
            this.txtSummary.Location = new System.Drawing.Point(293, 178);
            this.txtSummary.Name = "txtSummary";
            this.txtSummary.Size = new System.Drawing.Size(239, 20);
            this.txtSummary.TabIndex = 14;
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(290, 162);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(84, 13);
            this.label49.TabIndex = 13;
            this.label49.Text = "Event Summary:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(293, 114);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(239, 36);
            this.txtDescription.TabIndex = 12;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(290, 98);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(94, 13);
            this.label48.TabIndex = 11;
            this.label48.Text = "Event Description:";
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(293, 35);
            this.txtLocation.Multiline = true;
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLocation.Size = new System.Drawing.Size(150, 53);
            this.txtLocation.TabIndex = 10;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(290, 19);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(82, 13);
            this.label47.TabIndex = 9;
            this.label47.Text = "Event Location:";
            // 
            // cboDuration
            // 
            this.cboDuration.FormattingEnabled = true;
            this.cboDuration.Location = new System.Drawing.Point(122, 177);
            this.cboDuration.Name = "cboDuration";
            this.cboDuration.Size = new System.Drawing.Size(95, 21);
            this.cboDuration.TabIndex = 8;
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(86, 177);
            this.txtDuration.Multiline = true;
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(36, 21);
            this.txtDuration.TabIndex = 7;
            // 
            // rdbDuration
            // 
            this.rdbDuration.AutoSize = true;
            this.rdbDuration.Location = new System.Drawing.Point(19, 178);
            this.rdbDuration.Name = "rdbDuration";
            this.rdbDuration.Size = new System.Drawing.Size(68, 17);
            this.rdbDuration.TabIndex = 6;
            this.rdbDuration.TabStop = true;
            this.rdbDuration.Text = "Duration:";
            this.rdbDuration.UseVisualStyleBackColor = true;
            this.rdbDuration.Click += new System.EventHandler(this.rdbDuration_Click);
            // 
            // dtpEndDateTime
            // 
            this.dtpEndDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDateTime.Location = new System.Drawing.Point(19, 151);
            this.dtpEndDateTime.Name = "dtpEndDateTime";
            this.dtpEndDateTime.Size = new System.Drawing.Size(200, 20);
            this.dtpEndDateTime.TabIndex = 5;
            // 
            // rdbEndDateTime
            // 
            this.rdbEndDateTime.AutoSize = true;
            this.rdbEndDateTime.Location = new System.Drawing.Point(19, 128);
            this.rdbEndDateTime.Name = "rdbEndDateTime";
            this.rdbEndDateTime.Size = new System.Drawing.Size(108, 17);
            this.rdbEndDateTime.TabIndex = 4;
            this.rdbEndDateTime.TabStop = true;
            this.rdbEndDateTime.Text = "End Date && Time:";
            this.rdbEndDateTime.UseVisualStyleBackColor = true;
            this.rdbEndDateTime.Click += new System.EventHandler(this.rdbEndDateTime_Click);
            // 
            // dtpStartDateTime
            // 
            this.dtpStartDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDateTime.Location = new System.Drawing.Point(17, 91);
            this.dtpStartDateTime.Name = "dtpStartDateTime";
            this.dtpStartDateTime.Size = new System.Drawing.Size(200, 20);
            this.dtpStartDateTime.TabIndex = 3;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(16, 75);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(93, 13);
            this.label46.TabIndex = 2;
            this.label46.Text = "Start Date && Time:";
            // 
            // txtPhoneVCL
            // 
            this.txtPhoneVCL.Location = new System.Drawing.Point(14, 35);
            this.txtPhoneVCL.Name = "txtPhoneVCL";
            this.txtPhoneVCL.Size = new System.Drawing.Size(203, 20);
            this.txtPhoneVCL.TabIndex = 1;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(11, 19);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(111, 13);
            this.label45.TabIndex = 0;
            this.label45.Text = "Send To (Phone No.):";
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.groupBox16);
            this.tabPage7.Controls.Add(this.groupBox15);
            this.tabPage7.Location = new System.Drawing.Point(4, 40);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(560, 373);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "Modem & Network";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.lblIMSI);
            this.groupBox16.Controls.Add(this.label17);
            this.groupBox16.Controls.Add(this.cmdMdmRefresh);
            this.groupBox16.Controls.Add(this.lblOwnNum);
            this.groupBox16.Controls.Add(this.label62);
            this.groupBox16.Controls.Add(this.lblBattery);
            this.groupBox16.Controls.Add(this.label60);
            this.groupBox16.Controls.Add(this.lblIMEI);
            this.groupBox16.Controls.Add(this.label58);
            this.groupBox16.Controls.Add(this.lblRevision);
            this.groupBox16.Controls.Add(this.label56);
            this.groupBox16.Controls.Add(this.lblModel);
            this.groupBox16.Controls.Add(this.label54);
            this.groupBox16.Controls.Add(this.lblManufacturer);
            this.groupBox16.Controls.Add(this.label52);
            this.groupBox16.Location = new System.Drawing.Point(6, 112);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(547, 255);
            this.groupBox16.TabIndex = 1;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "Modem Information";
            // 
            // lblIMSI
            // 
            this.lblIMSI.Location = new System.Drawing.Point(110, 148);
            this.lblIMSI.Name = "lblIMSI";
            this.lblIMSI.Size = new System.Drawing.Size(386, 13);
            this.lblIMSI.TabIndex = 14;
            this.lblIMSI.Text = "???";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(72, 148);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(32, 13);
            this.label17.TabIndex = 13;
            this.label17.Text = "IMSI:";
            // 
            // cmdMdmRefresh
            // 
            this.cmdMdmRefresh.Location = new System.Drawing.Point(410, 211);
            this.cmdMdmRefresh.Name = "cmdMdmRefresh";
            this.cmdMdmRefresh.Size = new System.Drawing.Size(131, 23);
            this.cmdMdmRefresh.TabIndex = 12;
            this.cmdMdmRefresh.Text = "Refresh";
            this.cmdMdmRefresh.UseVisualStyleBackColor = true;
            this.cmdMdmRefresh.Click += new System.EventHandler(this.cmdMdmRefresh_Click);
            // 
            // lblOwnNum
            // 
            this.lblOwnNum.Location = new System.Drawing.Point(110, 208);
            this.lblOwnNum.Name = "lblOwnNum";
            this.lblOwnNum.Size = new System.Drawing.Size(210, 13);
            this.lblOwnNum.TabIndex = 11;
            this.lblOwnNum.Text = "???";
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Location = new System.Drawing.Point(32, 208);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(72, 13);
            this.label62.TabIndex = 10;
            this.label62.Text = "Own Number:";
            // 
            // lblBattery
            // 
            this.lblBattery.Location = new System.Drawing.Point(110, 178);
            this.lblBattery.Name = "lblBattery";
            this.lblBattery.Size = new System.Drawing.Size(210, 13);
            this.lblBattery.TabIndex = 9;
            this.lblBattery.Text = "???";
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(32, 178);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(72, 13);
            this.label60.TabIndex = 8;
            this.label60.Text = "Battery Level:";
            // 
            // lblIMEI
            // 
            this.lblIMEI.Location = new System.Drawing.Point(110, 118);
            this.lblIMEI.Name = "lblIMEI";
            this.lblIMEI.Size = new System.Drawing.Size(386, 13);
            this.lblIMEI.TabIndex = 7;
            this.lblIMEI.Text = "???";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(72, 118);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(32, 13);
            this.label58.TabIndex = 6;
            this.label58.Text = "IMEI:";
            // 
            // lblRevision
            // 
            this.lblRevision.Location = new System.Drawing.Point(110, 88);
            this.lblRevision.Name = "lblRevision";
            this.lblRevision.Size = new System.Drawing.Size(386, 13);
            this.lblRevision.TabIndex = 5;
            this.lblRevision.Text = "???";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(8, 88);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(96, 13);
            this.label56.TabIndex = 4;
            this.label56.Text = "Firmware Revision:";
            // 
            // lblModel
            // 
            this.lblModel.Location = new System.Drawing.Point(110, 58);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(386, 13);
            this.lblModel.TabIndex = 3;
            this.lblModel.Text = "???";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(65, 58);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(39, 13);
            this.label54.TabIndex = 2;
            this.label54.Text = "Model:";
            // 
            // lblManufacturer
            // 
            this.lblManufacturer.Location = new System.Drawing.Point(110, 28);
            this.lblManufacturer.Name = "lblManufacturer";
            this.lblManufacturer.Size = new System.Drawing.Size(386, 13);
            this.lblManufacturer.TabIndex = 1;
            this.lblManufacturer.Text = "???";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(31, 28);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(73, 13);
            this.label52.TabIndex = 0;
            this.label52.Text = "Manufacturer:";
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.cmdNetRefresh);
            this.groupBox15.Controls.Add(this.lblNetwork);
            this.groupBox15.Controls.Add(this.label51);
            this.groupBox15.Controls.Add(this.prbSignal);
            this.groupBox15.Controls.Add(this.label50);
            this.groupBox15.Location = new System.Drawing.Point(6, 6);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(547, 100);
            this.groupBox15.TabIndex = 0;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "Network Information";
            // 
            // cmdNetRefresh
            // 
            this.cmdNetRefresh.Location = new System.Drawing.Point(410, 71);
            this.cmdNetRefresh.Name = "cmdNetRefresh";
            this.cmdNetRefresh.Size = new System.Drawing.Size(131, 23);
            this.cmdNetRefresh.TabIndex = 4;
            this.cmdNetRefresh.Text = "Refresh";
            this.cmdNetRefresh.UseVisualStyleBackColor = true;
            this.cmdNetRefresh.Click += new System.EventHandler(this.cmdNetRefresh_Click);
            // 
            // lblNetwork
            // 
            this.lblNetwork.Location = new System.Drawing.Point(110, 60);
            this.lblNetwork.Name = "lblNetwork";
            this.lblNetwork.Size = new System.Drawing.Size(278, 13);
            this.lblNetwork.TabIndex = 3;
            this.lblNetwork.Text = "???";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(54, 60);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(50, 13);
            this.label51.TabIndex = 2;
            this.label51.Text = "Network:";
            // 
            // prbSignal
            // 
            this.prbSignal.Location = new System.Drawing.Point(110, 24);
            this.prbSignal.Name = "prbSignal";
            this.prbSignal.Size = new System.Drawing.Size(386, 16);
            this.prbSignal.TabIndex = 1;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(22, 24);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(82, 13);
            this.label50.TabIndex = 0;
            this.label50.Text = "Signal Strength:";
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.groupBox18);
            this.tabPage8.Controls.Add(this.groupBox17);
            this.tabPage8.Location = new System.Drawing.Point(4, 40);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(560, 373);
            this.tabPage8.TabIndex = 7;
            this.tabPage8.Text = "Troubleshooting";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // groupBox18
            // 
            this.groupBox18.Controls.Add(this.cmdLogSettings);
            this.groupBox18.Controls.Add(this.cmdClearLog);
            this.groupBox18.Controls.Add(this.cmdViewLog);
            this.groupBox18.Controls.Add(this.cmdLogFolder);
            this.groupBox18.Controls.Add(this.txtLogFolder);
            this.groupBox18.Controls.Add(this.label55);
            this.groupBox18.Controls.Add(this.cboLogType);
            this.groupBox18.Controls.Add(this.label53);
            this.groupBox18.Location = new System.Drawing.Point(6, 88);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(548, 279);
            this.groupBox18.TabIndex = 1;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "Log Options";
            // 
            // cmdLogSettings
            // 
            this.cmdLogSettings.Location = new System.Drawing.Point(375, 206);
            this.cmdLogSettings.Name = "cmdLogSettings";
            this.cmdLogSettings.Size = new System.Drawing.Size(135, 23);
            this.cmdLogSettings.TabIndex = 7;
            this.cmdLogSettings.Text = "Apply Log Settings";
            this.cmdLogSettings.UseVisualStyleBackColor = true;
            this.cmdLogSettings.Click += new System.EventHandler(this.cmdLogSettings_Click);
            // 
            // cmdClearLog
            // 
            this.cmdClearLog.Location = new System.Drawing.Point(200, 206);
            this.cmdClearLog.Name = "cmdClearLog";
            this.cmdClearLog.Size = new System.Drawing.Size(135, 23);
            this.cmdClearLog.TabIndex = 6;
            this.cmdClearLog.Text = "Clear Log";
            this.cmdClearLog.UseVisualStyleBackColor = true;
            this.cmdClearLog.Click += new System.EventHandler(this.cmdClearLog_Click);
            // 
            // cmdViewLog
            // 
            this.cmdViewLog.Location = new System.Drawing.Point(25, 206);
            this.cmdViewLog.Name = "cmdViewLog";
            this.cmdViewLog.Size = new System.Drawing.Size(135, 23);
            this.cmdViewLog.TabIndex = 5;
            this.cmdViewLog.Text = "View Log";
            this.cmdViewLog.UseVisualStyleBackColor = true;
            this.cmdViewLog.Click += new System.EventHandler(this.cmdViewLog_Click);
            // 
            // cmdLogFolder
            // 
            this.cmdLogFolder.Location = new System.Drawing.Point(435, 126);
            this.cmdLogFolder.Name = "cmdLogFolder";
            this.cmdLogFolder.Size = new System.Drawing.Size(75, 23);
            this.cmdLogFolder.TabIndex = 4;
            this.cmdLogFolder.Text = "Browse";
            this.cmdLogFolder.UseVisualStyleBackColor = true;
            this.cmdLogFolder.Click += new System.EventHandler(this.cmdLogFolder_Click);
            // 
            // txtLogFolder
            // 
            this.txtLogFolder.Location = new System.Drawing.Point(25, 128);
            this.txtLogFolder.Name = "txtLogFolder";
            this.txtLogFolder.Size = new System.Drawing.Size(404, 20);
            this.txtLogFolder.TabIndex = 3;
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(22, 112);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(60, 13);
            this.label55.TabIndex = 2;
            this.label55.Text = "Log Folder:";
            // 
            // cboLogType
            // 
            this.cboLogType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLogType.FormattingEnabled = true;
            this.cboLogType.Location = new System.Drawing.Point(25, 51);
            this.cboLogType.Name = "cboLogType";
            this.cboLogType.Size = new System.Drawing.Size(218, 21);
            this.cboLogType.TabIndex = 1;
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(22, 35);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(55, 13);
            this.label53.TabIndex = 0;
            this.label53.Text = "Log Type:";
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.chkDebugMode);
            this.groupBox17.Location = new System.Drawing.Point(6, 6);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(548, 76);
            this.groupBox17.TabIndex = 0;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "Debug Mode";
            // 
            // chkDebugMode
            // 
            this.chkDebugMode.AutoSize = true;
            this.chkDebugMode.Location = new System.Drawing.Point(25, 30);
            this.chkDebugMode.Name = "chkDebugMode";
            this.chkDebugMode.Size = new System.Drawing.Size(218, 17);
            this.chkDebugMode.TabIndex = 0;
            this.chkDebugMode.Text = "Enable Debug Mode (Error Messagebox)";
            this.chkDebugMode.UseVisualStyleBackColor = true;
            this.chkDebugMode.CheckedChanged += new System.EventHandler(this.chkDebugMode_CheckedChanged);
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.groupBox19);
            this.tabPage9.Location = new System.Drawing.Point(4, 40);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Size = new System.Drawing.Size(560, 373);
            this.tabPage9.TabIndex = 8;
            this.tabPage9.Text = "Terminal";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // groupBox19
            // 
            this.groupBox19.Controls.Add(this.lblTerminalStatus);
            this.groupBox19.Controls.Add(this.txtCommand);
            this.groupBox19.Location = new System.Drawing.Point(6, 6);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Size = new System.Drawing.Size(547, 361);
            this.groupBox19.TabIndex = 0;
            this.groupBox19.TabStop = false;
            this.groupBox19.Text = "Command Terminal";
            // 
            // lblTerminalStatus
            // 
            this.lblTerminalStatus.AutoSize = true;
            this.lblTerminalStatus.Location = new System.Drawing.Point(6, 25);
            this.lblTerminalStatus.Name = "lblTerminalStatus";
            this.lblTerminalStatus.Size = new System.Drawing.Size(204, 13);
            this.lblTerminalStatus.TabIndex = 1;
            this.lblTerminalStatus.Text = "Type a AT Command and press Enter key";
            // 
            // txtCommand
            // 
            this.txtCommand.Location = new System.Drawing.Point(6, 44);
            this.txtCommand.Multiline = true;
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCommand.Size = new System.Drawing.Size(535, 311);
            this.txtCommand.TabIndex = 0;
            this.txtCommand.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCommand_KeyUp);
            // 
            // tabPage11
            // 
            this.tabPage11.Controls.Add(this.groupBox22);
            this.tabPage11.Controls.Add(this.groupBox21);
            this.tabPage11.Location = new System.Drawing.Point(4, 40);
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.Size = new System.Drawing.Size(560, 373);
            this.tabPage11.TabIndex = 10;
            this.tabPage11.Text = "USSD";
            this.tabPage11.UseVisualStyleBackColor = true;
            // 
            // groupBox22
            // 
            this.groupBox22.Controls.Add(this.chkUSSD);
            this.groupBox22.Controls.Add(this.lblUSSDStatus);
            this.groupBox22.Controls.Add(this.txtUSSDMessage);
            this.groupBox22.Location = new System.Drawing.Point(6, 142);
            this.groupBox22.Name = "groupBox22";
            this.groupBox22.Size = new System.Drawing.Size(547, 225);
            this.groupBox22.TabIndex = 1;
            this.groupBox22.TabStop = false;
            this.groupBox22.Text = "Incoming USSD";
            // 
            // chkUSSD
            // 
            this.chkUSSD.AutoSize = true;
            this.chkUSSD.Location = new System.Drawing.Point(289, 31);
            this.chkUSSD.Name = "chkUSSD";
            this.chkUSSD.Size = new System.Drawing.Size(167, 17);
            this.chkUSSD.TabIndex = 2;
            this.chkUSSD.Text = "Enable incoming USSD event";
            this.chkUSSD.UseVisualStyleBackColor = true;
            this.chkUSSD.CheckedChanged += new System.EventHandler(this.chkUSSD_CheckedChanged);
            // 
            // lblUSSDStatus
            // 
            this.lblUSSDStatus.AutoSize = true;
            this.lblUSSDStatus.Location = new System.Drawing.Point(286, 189);
            this.lblUSSDStatus.Name = "lblUSSDStatus";
            this.lblUSSDStatus.Size = new System.Drawing.Size(40, 13);
            this.lblUSSDStatus.TabIndex = 1;
            this.lblUSSDStatus.Text = "Status:";
            // 
            // txtUSSDMessage
            // 
            this.txtUSSDMessage.BackColor = System.Drawing.SystemColors.Window;
            this.txtUSSDMessage.Location = new System.Drawing.Point(77, 29);
            this.txtUSSDMessage.Multiline = true;
            this.txtUSSDMessage.Name = "txtUSSDMessage";
            this.txtUSSDMessage.ReadOnly = true;
            this.txtUSSDMessage.Size = new System.Drawing.Size(190, 173);
            this.txtUSSDMessage.TabIndex = 0;
            // 
            // groupBox21
            // 
            this.groupBox21.Controls.Add(this.cmdUSSD);
            this.groupBox21.Controls.Add(this.txtUSSDCommand);
            this.groupBox21.Location = new System.Drawing.Point(6, 6);
            this.groupBox21.Name = "groupBox21";
            this.groupBox21.Size = new System.Drawing.Size(547, 130);
            this.groupBox21.TabIndex = 0;
            this.groupBox21.TabStop = false;
            this.groupBox21.Text = "Send USSD";
            // 
            // cmdUSSD
            // 
            this.cmdUSSD.Location = new System.Drawing.Point(273, 57);
            this.cmdUSSD.Name = "cmdUSSD";
            this.cmdUSSD.Size = new System.Drawing.Size(75, 23);
            this.cmdUSSD.TabIndex = 1;
            this.cmdUSSD.Text = "Send";
            this.cmdUSSD.UseVisualStyleBackColor = true;
            this.cmdUSSD.Click += new System.EventHandler(this.cmdUSSD_Click);
            // 
            // txtUSSDCommand
            // 
            this.txtUSSDCommand.Location = new System.Drawing.Point(77, 59);
            this.txtUSSDCommand.Name = "txtUSSDCommand";
            this.txtUSSDCommand.Size = new System.Drawing.Size(190, 20);
            this.txtUSSDCommand.TabIndex = 0;
            // 
            // tabPage12
            // 
            this.tabPage12.Controls.Add(this.groupBox23);
            this.tabPage12.Location = new System.Drawing.Point(4, 40);
            this.tabPage12.Name = "tabPage12";
            this.tabPage12.Size = new System.Drawing.Size(560, 373);
            this.tabPage12.TabIndex = 11;
            this.tabPage12.Text = "Smart SMS";
            this.tabPage12.UseVisualStyleBackColor = true;
            // 
            // groupBox23
            // 
            this.groupBox23.Controls.Add(this.cmdSendSmartSMS);
            this.groupBox23.Controls.Add(this.label61);
            this.groupBox23.Controls.Add(this.label59);
            this.groupBox23.Controls.Add(this.label57);
            this.groupBox23.Controls.Add(this.nudDestinationPort);
            this.groupBox23.Controls.Add(this.txtSmartText);
            this.groupBox23.Controls.Add(this.txtDestinationPhone);
            this.groupBox23.Location = new System.Drawing.Point(6, 6);
            this.groupBox23.Name = "groupBox23";
            this.groupBox23.Size = new System.Drawing.Size(547, 354);
            this.groupBox23.TabIndex = 0;
            this.groupBox23.TabStop = false;
            this.groupBox23.Text = "Send Smart SMS";
            // 
            // cmdSendSmartSMS
            // 
            this.cmdSendSmartSMS.Location = new System.Drawing.Point(312, 244);
            this.cmdSendSmartSMS.Name = "cmdSendSmartSMS";
            this.cmdSendSmartSMS.Size = new System.Drawing.Size(75, 23);
            this.cmdSendSmartSMS.TabIndex = 6;
            this.cmdSendSmartSMS.Text = "Send";
            this.cmdSendSmartSMS.UseVisualStyleBackColor = true;
            this.cmdSendSmartSMS.Click += new System.EventHandler(this.cmdSendSmartSMS_Click);
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(122, 134);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(77, 13);
            this.label61.TabIndex = 5;
            this.label61.Text = "Text Message:";
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(309, 78);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(85, 13);
            this.label59.TabIndex = 4;
            this.label59.Text = "Destination Port:";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(122, 77);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(61, 13);
            this.label57.TabIndex = 3;
            this.label57.Text = "Phone No.:";
            // 
            // nudDestinationPort
            // 
            this.nudDestinationPort.Location = new System.Drawing.Point(312, 94);
            this.nudDestinationPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudDestinationPort.Name = "nudDestinationPort";
            this.nudDestinationPort.Size = new System.Drawing.Size(75, 20);
            this.nudDestinationPort.TabIndex = 2;
            // 
            // txtSmartText
            // 
            this.txtSmartText.Location = new System.Drawing.Point(125, 150);
            this.txtSmartText.Multiline = true;
            this.txtSmartText.Name = "txtSmartText";
            this.txtSmartText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSmartText.Size = new System.Drawing.Size(262, 78);
            this.txtSmartText.TabIndex = 1;
            // 
            // txtDestinationPhone
            // 
            this.txtDestinationPhone.Location = new System.Drawing.Point(125, 93);
            this.txtDestinationPhone.Name = "txtDestinationPhone";
            this.txtDestinationPhone.Size = new System.Drawing.Size(155, 20);
            this.txtDestinationPhone.TabIndex = 0;
            // 
            // tabPage10
            // 
            this.tabPage10.Location = new System.Drawing.Point(4, 40);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Size = new System.Drawing.Size(560, 373);
            this.tabPage10.TabIndex = 9;
            this.tabPage10.Text = "About";
            this.tabPage10.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 441);
            this.Controls.Add(this.tabMessaging);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RPN Negar .NET SMS Library Demo";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.tabMessaging.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.grpOtherSettings.ResumeLayout(false);
            this.grpOtherSettings.PerformLayout();
            this.grpPortSettings.ResumeLayout(false);
            this.grpPortSettings.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox20.ResumeLayout(false);
            this.groupBox20.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.tabPage7.ResumeLayout(false);
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            this.tabPage8.ResumeLayout(false);
            this.groupBox18.ResumeLayout(false);
            this.groupBox18.PerformLayout();
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            this.tabPage9.ResumeLayout(false);
            this.groupBox19.ResumeLayout(false);
            this.groupBox19.PerformLayout();
            this.tabPage11.ResumeLayout(false);
            this.groupBox22.ResumeLayout(false);
            this.groupBox22.PerformLayout();
            this.groupBox21.ResumeLayout(false);
            this.groupBox21.PerformLayout();
            this.tabPage12.ResumeLayout(false);
            this.groupBox23.ResumeLayout(false);
            this.groupBox23.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDestinationPort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMessaging;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.TabPage tabPage10;
        private System.Windows.Forms.GroupBox grpOtherSettings;
        private System.Windows.Forms.GroupBox grpPortSettings;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.GroupBox groupBox16;
        private System.Windows.Forms.GroupBox groupBox15;
        private System.Windows.Forms.GroupBox groupBox17;
        private System.Windows.Forms.GroupBox groupBox18;
        private System.Windows.Forms.ComboBox cboPort;
        private System.Windows.Forms.GroupBox groupBox19;
        private System.Windows.Forms.ComboBox cboBaudRate;
        private System.Windows.Forms.ComboBox cboDataBits;
        private System.Windows.Forms.ComboBox cboStopBits;
        private System.Windows.Forms.ComboBox cboParity;
        private System.Windows.Forms.ComboBox cboFlowControl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdDisconnect;
        private System.Windows.Forms.Button cmdConnect;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkIncomingCall;
        private System.Windows.Forms.TextBox txtTimeout;
        private System.Windows.Forms.TextBox txtSendRetry;
        private System.Windows.Forms.TextBox txtSendDelay;
        private System.Windows.Forms.TextBox txtSMSC;
        private System.Windows.Forms.TextBox txtPIN;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button cmdApplySettings;
        private System.Windows.Forms.Button cmdRefreshSettings;
        private System.Windows.Forms.CheckBox chkInConcatenate;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboMsgMemory;
        private System.Windows.Forms.CheckBox chkAutoDelete;
        private System.Windows.Forms.CheckBox chkRefreshInbox;
        private System.Windows.Forms.CheckBox chkCleanUp;
        private System.Windows.Forms.CheckBox chkNewMsgIndication;
        private System.Windows.Forms.ListView lstInbox;
        private System.Windows.Forms.Label lblMsgCount;
        private System.Windows.Forms.ColumnHeader clmFrom;
        private System.Windows.Forms.ColumnHeader clmMessage;
        private System.Windows.Forms.ColumnHeader clmTime;
        private System.Windows.Forms.Button cmdInboxRefresh;
        private System.Windows.Forms.Button cmdMsgDelete;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblNoteSMS;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button cmdSendMsg;
        private System.Windows.Forms.ComboBox cboValidity;
        private System.Windows.Forms.TextBox txtValidity;
        private System.Windows.Forms.ComboBox cboEncoding;
        private System.Windows.Forms.ComboBox cboLongMsg;
        private System.Windows.Forms.CheckBox chkDeliveryReport;
        private System.Windows.Forms.CheckBox chkAlert;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cboAction;
        private System.Windows.Forms.TextBox txtExpiry;
        private System.Windows.Forms.TextBox txtMessageWP;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.TextBox txtPhoneWP;
        private System.Windows.Forms.CheckBox chkExpiry;
        private System.Windows.Forms.CheckBox chkCreated;
        private System.Windows.Forms.ComboBox cboExpiry;
        private System.Windows.Forms.DateTimePicker dtpCreated;
        private System.Windows.Forms.Button cmdSendWapPush;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtLName;
        private System.Windows.Forms.TextBox txtMName;
        private System.Windows.Forms.TextBox txtFName;
        private System.Windows.Forms.TextBox txtPhoneVCF;
        private System.Windows.Forms.TextBox txtMobilePhone;
        private System.Windows.Forms.TextBox txtBusinessPhone;
        private System.Windows.Forms.TextBox txtHomePhone;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.TextBox txtHomeZIP;
        private System.Windows.Forms.TextBox txtHomeCountry;
        private System.Windows.Forms.TextBox txtHomeState;
        private System.Windows.Forms.TextBox txtHomeCity;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox txtHomeStreet;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox txtVCFFile;
        private System.Windows.Forms.TextBox txtWebsite;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.TextBox txtBusinessStreet;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.TextBox txtCompany;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.TextBox txtJobTitle;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.TextBox txtBusinessZIP;
        private System.Windows.Forms.TextBox txtBusinessCountry;
        private System.Windows.Forms.TextBox txtBusinessState;
        private System.Windows.Forms.TextBox txtBusinessCity;
        private System.Windows.Forms.Button cmdSendVCard;
        private System.Windows.Forms.Button cmdSendVCF;
        private System.Windows.Forms.Button cmdBrowseVCF;
        private System.Windows.Forms.RadioButton rdbDuration;
        private System.Windows.Forms.DateTimePicker dtpEndDateTime;
        private System.Windows.Forms.RadioButton rdbEndDateTime;
        private System.Windows.Forms.DateTimePicker dtpStartDateTime;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.TextBox txtPhoneVCL;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Button cmdSendVCalendar;
        private System.Windows.Forms.TextBox txtSummary;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.ComboBox cboDuration;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.Button cmdSendVCS;
        private System.Windows.Forms.Button cmdBrowseVCS;
        private System.Windows.Forms.TextBox txtVCSFile;
        private System.Windows.Forms.Button cmdNetRefresh;
        private System.Windows.Forms.Label lblNetwork;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.ProgressBar prbSignal;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label lblBattery;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.Label lblIMEI;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label lblRevision;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Label lblManufacturer;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label lblOwnNum;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.Button cmdMdmRefresh;
        private System.Windows.Forms.Button cmdLogSettings;
        private System.Windows.Forms.Button cmdClearLog;
        private System.Windows.Forms.Button cmdViewLog;
        private System.Windows.Forms.Button cmdLogFolder;
        private System.Windows.Forms.TextBox txtLogFolder;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.ComboBox cboLogType;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.CheckBox chkDebugMode;
        private System.Windows.Forms.Label lblTerminalStatus;
        private System.Windows.Forms.TextBox txtCommand;
        private System.Windows.Forms.Label lblNoteWP;
        private System.Windows.Forms.Label lblSMSQPriority;
        private System.Windows.Forms.CheckBox chkSMSQueue;
        private System.Windows.Forms.ComboBox cboSMSQPriority;
        private System.Windows.Forms.GroupBox groupBox20;
        private System.Windows.Forms.CheckBox chkQueue;
        private System.Windows.Forms.Label lblQueueCount;
        private System.Windows.Forms.Label lblQueueStatus;
        private System.Windows.Forms.Button cmdClearQueue;
        private System.Windows.Forms.Label lblIMSI;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.CheckBox chkDisableCheckPIN;
        private System.Windows.Forms.TabPage tabPage11;
        private System.Windows.Forms.GroupBox groupBox21;
        private System.Windows.Forms.GroupBox groupBox22;
        private System.Windows.Forms.CheckBox chkUSSD;
        private System.Windows.Forms.Label lblUSSDStatus;
        private System.Windows.Forms.TextBox txtUSSDMessage;
        private System.Windows.Forms.Button cmdUSSD;
        private System.Windows.Forms.TextBox txtUSSDCommand;
        private System.Windows.Forms.TabPage tabPage12;
        private System.Windows.Forms.GroupBox groupBox23;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.NumericUpDown nudDestinationPort;
        private System.Windows.Forms.TextBox txtSmartText;
        private System.Windows.Forms.TextBox txtDestinationPhone;
        private System.Windows.Forms.Button cmdSendSmartSMS;
    }
}

