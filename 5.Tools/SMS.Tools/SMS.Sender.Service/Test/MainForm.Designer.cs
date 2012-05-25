namespace Negar.SMSSender
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.cboPortName = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.PanelModemConnection = new DevComponents.DotNetBar.PanelEx();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblPortSelection = new DevComponents.DotNetBar.LabelX();
            this.btnConnectGSMModem = new DevComponents.DotNetBar.ButtonX();
            this.FormPanel = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.lblFaileds = new DevComponents.DotNetBar.LabelX();
            this.lblSents = new DevComponents.DotNetBar.LabelX();
            this.btnRetryFaileds = new DevComponents.DotNetBar.ButtonX();
            this.lblQueue = new DevComponents.DotNetBar.LabelX();
            this.dgvFaileds = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.dgvSents = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.dgvQueue = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.FormNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.TimerDataRefresh = new System.Windows.Forms.Timer(this.components);
            this.ColSentsRecieverNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSentsMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSentsDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColQueueRecieverNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColQueueMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColQueueSendDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColQueueSendKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFailedsRecieverNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFailedsMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFailedsDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PanelModemConnection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.FormPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFaileds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueue)).BeginInit();
            this.SuspendLayout();
            // 
            // cboPortName
            // 
            this.cboPortName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPortName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboPortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPortName.FormattingEnabled = true;
            this.cboPortName.ItemHeight = 15;
            this.cboPortName.Location = new System.Drawing.Point(383, 37);
            this.cboPortName.Name = "cboPortName";
            this.cboPortName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cboPortName.Size = new System.Drawing.Size(137, 21);
            this.cboPortName.TabIndex = 0;
            // 
            // PanelModemConnection
            // 
            this.PanelModemConnection.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelModemConnection.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelModemConnection.Controls.Add(this.pictureBox1);
            this.PanelModemConnection.Controls.Add(this.lblPortSelection);
            this.PanelModemConnection.Controls.Add(this.cboPortName);
            this.PanelModemConnection.Controls.Add(this.btnConnectGSMModem);
            this.PanelModemConnection.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelModemConnection.Location = new System.Drawing.Point(0, 0);
            this.PanelModemConnection.Name = "PanelModemConnection";
            this.PanelModemConnection.Size = new System.Drawing.Size(527, 83);
            this.PanelModemConnection.Style.BackColor1.Color = System.Drawing.Color.Azure;
            this.PanelModemConnection.Style.BackColor2.Color = System.Drawing.Color.CornflowerBlue;
            this.PanelModemConnection.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.PanelModemConnection.Style.BorderColor.Color = System.Drawing.Color.Blue;
            this.PanelModemConnection.Style.GradientAngle = 90;
            this.PanelModemConnection.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Negar.SMSSender.Properties.Resources.SMS_Logo_1;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(89, 77);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // lblPortSelection
            // 
            this.lblPortSelection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPortSelection.AutoSize = true;
            this.lblPortSelection.BackColor = System.Drawing.Color.Transparent;
            this.lblPortSelection.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblPortSelection.ForeColor = System.Drawing.Color.Crimson;
            this.lblPortSelection.Location = new System.Drawing.Point(383, 16);
            this.lblPortSelection.Name = "lblPortSelection";
            this.lblPortSelection.Size = new System.Drawing.Size(137, 16);
            this.lblPortSelection.TabIndex = 1;
            this.lblPortSelection.Text = "پورت اتصال به مودم GSM:";
            // 
            // btnConnectGSMModem
            // 
            this.btnConnectGSMModem.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnConnectGSMModem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnectGSMModem.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnConnectGSMModem.Image = global::Negar.SMSSender.Properties.Resources.SMS_Logo_2;
            this.btnConnectGSMModem.Location = new System.Drawing.Point(257, 10);
            this.btnConnectGSMModem.Name = "btnConnectGSMModem";
            this.btnConnectGSMModem.Size = new System.Drawing.Size(120, 63);
            this.btnConnectGSMModem.TabIndex = 2;
            this.btnConnectGSMModem.TabStop = false;
            this.btnConnectGSMModem.Tag = "";
            this.btnConnectGSMModem.Text = "اتصال به مودم";
            this.btnConnectGSMModem.Click += new System.EventHandler(this.btnConnectGSMModem_Click);
            // 
            // FormPanel
            // 
            this.FormPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.FormPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.FormPanel.Controls.Add(this.lblFaileds);
            this.FormPanel.Controls.Add(this.lblSents);
            this.FormPanel.Controls.Add(this.btnRetryFaileds);
            this.FormPanel.Controls.Add(this.lblQueue);
            this.FormPanel.Controls.Add(this.dgvFaileds);
            this.FormPanel.Controls.Add(this.dgvSents);
            this.FormPanel.Controls.Add(this.dgvQueue);
            this.FormPanel.Controls.Add(this.PanelModemConnection);
            this.FormPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormPanel.Location = new System.Drawing.Point(0, 0);
            this.FormPanel.Name = "FormPanel";
            this.FormPanel.Size = new System.Drawing.Size(527, 610);
            // 
            // 
            // 
            this.FormPanel.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.FormPanel.Style.BackColorGradientAngle = 90;
            this.FormPanel.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.FormPanel.Style.BorderBottomWidth = 1;
            this.FormPanel.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.FormPanel.Style.BorderLeftWidth = 1;
            this.FormPanel.Style.BorderRightWidth = 1;
            this.FormPanel.Style.BorderTopWidth = 1;
            this.FormPanel.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.FormPanel.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.FormPanel.TabIndex = 0;
            // 
            // lblFaileds
            // 
            this.lblFaileds.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFaileds.AutoSize = true;
            this.lblFaileds.BackColor = System.Drawing.Color.Transparent;
            this.lblFaileds.Font = new System.Drawing.Font("B Mitra", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblFaileds.ForeColor = System.Drawing.Color.Crimson;
            this.lblFaileds.Location = new System.Drawing.Point(174, 429);
            this.lblFaileds.Name = "lblFaileds";
            this.lblFaileds.Size = new System.Drawing.Size(179, 31);
            this.lblFaileds.TabIndex = 5;
            this.lblFaileds.Text = "پیام های ارسال نشده امروز";
            // 
            // lblSents
            // 
            this.lblSents.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSents.AutoSize = true;
            this.lblSents.BackColor = System.Drawing.Color.Transparent;
            this.lblSents.Font = new System.Drawing.Font("B Mitra", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblSents.ForeColor = System.Drawing.Color.Green;
            this.lblSents.Location = new System.Drawing.Point(177, 259);
            this.lblSents.Name = "lblSents";
            this.lblSents.Size = new System.Drawing.Size(173, 31);
            this.lblSents.TabIndex = 3;
            this.lblSents.Text = "پیام های ارسال شده امروز";
            // 
            // btnRetryFaileds
            // 
            this.btnRetryFaileds.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRetryFaileds.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRetryFaileds.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnRetryFaileds.Enabled = false;
            this.btnRetryFaileds.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.btnRetryFaileds.Location = new System.Drawing.Point(12, 429);
            this.btnRetryFaileds.Name = "btnRetryFaileds";
            this.btnRetryFaileds.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor();
            this.btnRetryFaileds.Size = new System.Drawing.Size(80, 31);
            this.btnRetryFaileds.TabIndex = 6;
            this.btnRetryFaileds.TabStop = false;
            this.btnRetryFaileds.Tag = "";
            this.btnRetryFaileds.Text = "ارسال مجدد";
            this.btnRetryFaileds.Click += new System.EventHandler(this.btnRetryFaileds_Click);
            // 
            // lblQueue
            // 
            this.lblQueue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblQueue.AutoSize = true;
            this.lblQueue.BackColor = System.Drawing.Color.Transparent;
            this.lblQueue.Font = new System.Drawing.Font("B Mitra", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblQueue.Location = new System.Drawing.Point(182, 89);
            this.lblQueue.Name = "lblQueue";
            this.lblQueue.Size = new System.Drawing.Size(162, 31);
            this.lblQueue.TabIndex = 1;
            this.lblQueue.Text = "پیام های در انتظار ارسال";
            // 
            // dgvFaileds
            // 
            this.dgvFaileds.AllowUserToAddRows = false;
            this.dgvFaileds.AllowUserToDeleteRows = false;
            this.dgvFaileds.AllowUserToOrderColumns = true;
            this.dgvFaileds.AllowUserToResizeRows = false;
            this.dgvFaileds.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFaileds.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvFaileds.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dgvFaileds.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFaileds.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFaileds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFaileds.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColFailedsRecieverNum,
            this.ColFailedsMessage,
            this.ColFailedsDateTime});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFaileds.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvFaileds.Enabled = false;
            this.dgvFaileds.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvFaileds.Location = new System.Drawing.Point(12, 466);
            this.dgvFaileds.MultiSelect = false;
            this.dgvFaileds.Name = "dgvFaileds";
            this.dgvFaileds.ReadOnly = true;
            this.dgvFaileds.RowHeadersVisible = false;
            this.dgvFaileds.Size = new System.Drawing.Size(503, 130);
            this.dgvFaileds.StandardTab = true;
            this.dgvFaileds.TabIndex = 2;
            this.dgvFaileds.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvQueue_CellFormatting);
            // 
            // dgvSents
            // 
            this.dgvSents.AllowUserToAddRows = false;
            this.dgvSents.AllowUserToDeleteRows = false;
            this.dgvSents.AllowUserToOrderColumns = true;
            this.dgvSents.AllowUserToResizeRows = false;
            this.dgvSents.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSents.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvSents.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvSents.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColSentsRecieverNum,
            this.ColSentsMessage,
            this.ColSentsDateTime});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSents.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSents.Enabled = false;
            this.dgvSents.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvSents.Location = new System.Drawing.Point(12, 293);
            this.dgvSents.MultiSelect = false;
            this.dgvSents.Name = "dgvSents";
            this.dgvSents.ReadOnly = true;
            this.dgvSents.RowHeadersVisible = false;
            this.dgvSents.Size = new System.Drawing.Size(503, 130);
            this.dgvSents.StandardTab = true;
            this.dgvSents.TabIndex = 2;
            this.dgvSents.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvQueue_CellFormatting);
            // 
            // dgvQueue
            // 
            this.dgvQueue.AllowUserToAddRows = false;
            this.dgvQueue.AllowUserToDeleteRows = false;
            this.dgvQueue.AllowUserToOrderColumns = true;
            this.dgvQueue.AllowUserToResizeRows = false;
            this.dgvQueue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvQueue.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvQueue.BackgroundColor = System.Drawing.Color.PowderBlue;
            this.dgvQueue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvQueue.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvQueue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQueue.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColQueueRecieverNum,
            this.ColQueueMessage,
            this.ColQueueSendDateTime,
            this.ColQueueSendKey});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvQueue.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvQueue.Enabled = false;
            this.dgvQueue.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvQueue.Location = new System.Drawing.Point(12, 123);
            this.dgvQueue.MultiSelect = false;
            this.dgvQueue.Name = "dgvQueue";
            this.dgvQueue.ReadOnly = true;
            this.dgvQueue.RowHeadersVisible = false;
            this.dgvQueue.Size = new System.Drawing.Size(503, 130);
            this.dgvQueue.StandardTab = true;
            this.dgvQueue.TabIndex = 2;
            this.dgvQueue.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvQueue_CellFormatting);
            // 
            // FormNotifyIcon
            // 
            this.FormNotifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.FormNotifyIcon.BalloonTipText = "آیكون برنامه اینجا قرار گرفته";
            this.FormNotifyIcon.BalloonTipTitle = "من اینجا هستم!";
            this.FormNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("FormNotifyIcon.Icon")));
            this.FormNotifyIcon.Text = "سیستم مدیریت پیام كوتاه رایان پرتونگار";
            this.FormNotifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FormNotifyIcon_MouseClick);
            // 
            // TimerDataRefresh
            // 
            this.TimerDataRefresh.Interval = 3000;
            this.TimerDataRefresh.Tick += new System.EventHandler(this.TimerDataRefresh_Tick);
            // 
            // ColSentsRecieverNum
            // 
            this.ColSentsRecieverNum.HeaderText = "تلفن دریافت كننده";
            this.ColSentsRecieverNum.Name = "ColSentsRecieverNum";
            this.ColSentsRecieverNum.ReadOnly = true;
            this.ColSentsRecieverNum.Width = 114;
            // 
            // ColSentsMessage
            // 
            this.ColSentsMessage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColSentsMessage.HeaderText = "متن پیام";
            this.ColSentsMessage.Name = "ColSentsMessage";
            this.ColSentsMessage.ReadOnly = true;
            // 
            // ColSentsDateTime
            // 
            this.ColSentsDateTime.HeaderText = "زمان ارسال";
            this.ColSentsDateTime.Name = "ColSentsDateTime";
            this.ColSentsDateTime.ReadOnly = true;
            this.ColSentsDateTime.Width = 140;
            // 
            // ColQueueRecieverNum
            // 
            this.ColQueueRecieverNum.HeaderText = "تلفن دریافت كننده";
            this.ColQueueRecieverNum.Name = "ColQueueRecieverNum";
            this.ColQueueRecieverNum.ReadOnly = true;
            this.ColQueueRecieverNum.Width = 114;
            // 
            // ColQueueMessage
            // 
            this.ColQueueMessage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColQueueMessage.HeaderText = "متن پیام";
            this.ColQueueMessage.Name = "ColQueueMessage";
            this.ColQueueMessage.ReadOnly = true;
            // 
            // ColQueueSendDateTime
            // 
            this.ColQueueSendDateTime.HeaderText = "زمان ارسال";
            this.ColQueueSendDateTime.Name = "ColQueueSendDateTime";
            this.ColQueueSendDateTime.ReadOnly = true;
            this.ColQueueSendDateTime.Width = 140;
            // 
            // ColQueueSendKey
            // 
            this.ColQueueSendKey.HeaderText = "كلید ارسال";
            this.ColQueueSendKey.Name = "ColQueueSendKey";
            this.ColQueueSendKey.ReadOnly = true;
            this.ColQueueSendKey.Visible = false;
            // 
            // ColFailedsRecieverNum
            // 
            this.ColFailedsRecieverNum.HeaderText = "تلفن دریافت كننده";
            this.ColFailedsRecieverNum.Name = "ColFailedsRecieverNum";
            this.ColFailedsRecieverNum.ReadOnly = true;
            this.ColFailedsRecieverNum.Width = 114;
            // 
            // ColFailedsMessage
            // 
            this.ColFailedsMessage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColFailedsMessage.HeaderText = "متن پیام";
            this.ColFailedsMessage.Name = "ColFailedsMessage";
            this.ColFailedsMessage.ReadOnly = true;
            // 
            // ColFailedsDateTime
            // 
            this.ColFailedsDateTime.HeaderText = "زمان ارسال";
            this.ColFailedsDateTime.Name = "ColFailedsDateTime";
            this.ColFailedsDateTime.ReadOnly = true;
            this.ColFailedsDateTime.Width = 140;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 610);
            this.Controls.Add(this.FormPanel);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "رایان پرتونگار - سیستم مدیریت پیام كوتاه (SMS)";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.PanelModemConnection.ResumeLayout(false);
            this.PanelModemConnection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.FormPanel.ResumeLayout(false);
            this.FormPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFaileds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.ComboBoxEx cboPortName;
        private DevComponents.DotNetBar.PanelEx PanelModemConnection;
        private DevComponents.DotNetBar.LabelX lblPortSelection;
        private DevComponents.DotNetBar.ButtonX btnConnectGSMModem;
        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel FormPanel;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvQueue;
        private DevComponents.DotNetBar.LabelX lblQueue;
        private DevComponents.DotNetBar.LabelX lblFaileds;
        private DevComponents.DotNetBar.LabelX lblSents;
        private DevComponents.DotNetBar.ButtonX btnRetryFaileds;
        private System.Windows.Forms.NotifyIcon FormNotifyIcon;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvFaileds;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvSents;
        private System.Windows.Forms.Timer TimerDataRefresh;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFailedsRecieverNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFailedsMessage;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFailedsDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSentsRecieverNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSentsMessage;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSentsDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColQueueRecieverNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColQueueMessage;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColQueueSendDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColQueueSendKey;
    }
}

