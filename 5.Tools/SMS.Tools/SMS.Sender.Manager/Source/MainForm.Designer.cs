namespace Negar
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
            this.lblPortSelection = new DevComponents.DotNetBar.LabelX();
            this.btnRetryFaileds = new DevComponents.DotNetBar.ButtonX();
            this.dgvFaileds = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ColFailedsRecieverNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFailedsMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFailedsDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSents = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ColSentsRecieverNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSentsMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSentsDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvQueue = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ColQueueRecieverNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColQueueMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColQueueSendDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColQueueSendKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.lblServiceStatus = new DevComponents.DotNetBar.LabelX();
            this.txtServiceStatus = new DevComponents.DotNetBar.LabelX();
            this.btnRefresh1 = new DevComponents.DotNetBar.ButtonX();
            this.btnStopService = new DevComponents.DotNetBar.ButtonX();
            this.btnStartService = new DevComponents.DotNetBar.ButtonX();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnUninstallService = new DevComponents.DotNetBar.ButtonX();
            this.btnInstallService = new DevComponents.DotNetBar.ButtonX();
            this.btnSaveSettings = new DevComponents.DotNetBar.ButtonX();
            this.tabControl1 = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.lblCount1 = new System.Windows.Forms.Label();
            this.tabItem1 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel3 = new DevComponents.DotNetBar.TabControlPanel();
            this.lblCount3 = new System.Windows.Forms.Label();
            this.buttonX7 = new DevComponents.DotNetBar.ButtonX();
            this.btnRefresh3 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.lblCount2 = new System.Windows.Forms.Label();
            this.btnRefresh2 = new DevComponents.DotNetBar.ButtonX();
            this.tabItem2 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel4 = new DevComponents.DotNetBar.TabControlPanel();
            this.btnRefreshServiceStatus = new DevComponents.DotNetBar.ButtonX();
            this.tabItem4 = new DevComponents.DotNetBar.TabItem(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFaileds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabControlPanel1.SuspendLayout();
            this.tabControlPanel3.SuspendLayout();
            this.tabControlPanel2.SuspendLayout();
            this.tabControlPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboPortName
            // 
            this.cboPortName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPortName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboPortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPortName.FormattingEnabled = true;
            this.cboPortName.ItemHeight = 15;
            this.cboPortName.Location = new System.Drawing.Point(378, 161);
            this.cboPortName.Name = "cboPortName";
            this.cboPortName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cboPortName.Size = new System.Drawing.Size(137, 21);
            this.cboPortName.TabIndex = 0;
            // 
            // lblPortSelection
            // 
            this.lblPortSelection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPortSelection.AutoSize = true;
            this.lblPortSelection.BackColor = System.Drawing.Color.Transparent;
            this.lblPortSelection.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblPortSelection.ForeColor = System.Drawing.Color.Crimson;
            this.lblPortSelection.Location = new System.Drawing.Point(378, 143);
            this.lblPortSelection.Name = "lblPortSelection";
            this.lblPortSelection.Size = new System.Drawing.Size(137, 16);
            this.lblPortSelection.TabIndex = 1;
            this.lblPortSelection.Text = "پورت اتصال به مودم GSM:";
            // 
            // btnRetryFaileds
            // 
            this.btnRetryFaileds.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRetryFaileds.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRetryFaileds.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnRetryFaileds.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.btnRetryFaileds.Location = new System.Drawing.Point(327, 4);
            this.btnRetryFaileds.Name = "btnRetryFaileds";
            this.btnRetryFaileds.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor();
            this.btnRetryFaileds.Size = new System.Drawing.Size(95, 51);
            this.btnRetryFaileds.TabIndex = 6;
            this.btnRetryFaileds.TabStop = false;
            this.btnRetryFaileds.Tag = "";
            this.btnRetryFaileds.Text = "ارسال مجدد";
            this.btnRetryFaileds.Click += new System.EventHandler(this.btnRetryFaileds_Click);
            // 
            // dgvFaileds
            // 
            this.dgvFaileds.AllowUserToAddRows = false;
            this.dgvFaileds.AllowUserToDeleteRows = false;
            this.dgvFaileds.AllowUserToOrderColumns = true;
            this.dgvFaileds.AllowUserToResizeRows = false;
            this.dgvFaileds.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvFaileds.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dgvFaileds.BorderStyle = System.Windows.Forms.BorderStyle.None;
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
            this.dgvFaileds.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvFaileds.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvFaileds.Location = new System.Drawing.Point(1, 63);
            this.dgvFaileds.MultiSelect = false;
            this.dgvFaileds.Name = "dgvFaileds";
            this.dgvFaileds.ReadOnly = true;
            this.dgvFaileds.RowHeadersVisible = false;
            this.dgvFaileds.Size = new System.Drawing.Size(525, 179);
            this.dgvFaileds.StandardTab = true;
            this.dgvFaileds.TabIndex = 2;
            this.dgvFaileds.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvQueue_CellFormatting);
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
            // dgvSents
            // 
            this.dgvSents.AllowUserToAddRows = false;
            this.dgvSents.AllowUserToDeleteRows = false;
            this.dgvSents.AllowUserToOrderColumns = true;
            this.dgvSents.AllowUserToResizeRows = false;
            this.dgvSents.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvSents.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvSents.BorderStyle = System.Windows.Forms.BorderStyle.None;
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
            this.dgvSents.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvSents.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvSents.Location = new System.Drawing.Point(1, 63);
            this.dgvSents.MultiSelect = false;
            this.dgvSents.Name = "dgvSents";
            this.dgvSents.ReadOnly = true;
            this.dgvSents.RowHeadersVisible = false;
            this.dgvSents.Size = new System.Drawing.Size(525, 179);
            this.dgvSents.StandardTab = true;
            this.dgvSents.TabIndex = 2;
            this.dgvSents.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvQueue_CellFormatting);
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
            // dgvQueue
            // 
            this.dgvQueue.AllowUserToAddRows = false;
            this.dgvQueue.AllowUserToDeleteRows = false;
            this.dgvQueue.AllowUserToOrderColumns = true;
            this.dgvQueue.AllowUserToResizeRows = false;
            this.dgvQueue.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvQueue.BackgroundColor = System.Drawing.Color.PowderBlue;
            this.dgvQueue.BorderStyle = System.Windows.Forms.BorderStyle.None;
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
            this.dgvQueue.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvQueue.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvQueue.Location = new System.Drawing.Point(1, 63);
            this.dgvQueue.MultiSelect = false;
            this.dgvQueue.Name = "dgvQueue";
            this.dgvQueue.ReadOnly = true;
            this.dgvQueue.RowHeadersVisible = false;
            this.dgvQueue.Size = new System.Drawing.Size(525, 179);
            this.dgvQueue.StandardTab = true;
            this.dgvQueue.TabIndex = 2;
            this.dgvQueue.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvQueue_CellFormatting);
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
            // FormNotifyIcon
            // 
            this.FormNotifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.FormNotifyIcon.BalloonTipText = "آیكون برنامه اینجا قرار گرفته";
            this.FormNotifyIcon.BalloonTipTitle = "من اینجا هستم!";
            this.FormNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("FormNotifyIcon.Icon")));
            this.FormNotifyIcon.Text = "سیستم مدیریت پیام كوتاه رایان پرتونگار";
            this.FormNotifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FormNotifyIcon_MouseClick);
            // 
            // lblServiceStatus
            // 
            this.lblServiceStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblServiceStatus.AutoSize = true;
            this.lblServiceStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblServiceStatus.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblServiceStatus.ForeColor = System.Drawing.Color.Black;
            this.lblServiceStatus.Location = new System.Drawing.Point(387, 20);
            this.lblServiceStatus.Name = "lblServiceStatus";
            this.lblServiceStatus.Size = new System.Drawing.Size(91, 16);
            this.lblServiceStatus.TabIndex = 1;
            this.lblServiceStatus.Text = "وضعیت سرویس:";
            this.lblServiceStatus.TextLineAlignment = System.Drawing.StringAlignment.Near;
            // 
            // txtServiceStatus
            // 
            this.txtServiceStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServiceStatus.BackColor = System.Drawing.Color.Transparent;
            this.txtServiceStatus.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtServiceStatus.ForeColor = System.Drawing.Color.Black;
            this.txtServiceStatus.Location = new System.Drawing.Point(223, 20);
            this.txtServiceStatus.Name = "txtServiceStatus";
            this.txtServiceStatus.Size = new System.Drawing.Size(161, 16);
            this.txtServiceStatus.TabIndex = 1;
            this.txtServiceStatus.Text = "نصب نشده.";
            this.txtServiceStatus.TextLineAlignment = System.Drawing.StringAlignment.Near;
            // 
            // btnRefresh1
            // 
            this.btnRefresh1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRefresh1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh1.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnRefresh1.Image = global::Negar.Properties.Resources.Refresh;
            this.btnRefresh1.Location = new System.Drawing.Point(428, 4);
            this.btnRefresh1.Name = "btnRefresh1";
            this.btnRefresh1.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor();
            this.btnRefresh1.Size = new System.Drawing.Size(95, 51);
            this.btnRefresh1.TabIndex = 6;
            this.btnRefresh1.TabStop = false;
            this.btnRefresh1.Tag = "";
            this.btnRefresh1.Text = "بازخوانی";
            this.btnRefresh1.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnStopService
            // 
            this.btnStopService.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnStopService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStopService.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnStopService.Image = global::Negar.Properties.Resources.Deny;
            this.btnStopService.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnStopService.Location = new System.Drawing.Point(295, 106);
            this.btnStopService.Name = "btnStopService";
            this.btnStopService.Size = new System.Drawing.Size(101, 31);
            this.btnStopService.TabIndex = 2;
            this.btnStopService.TabStop = false;
            this.btnStopService.Tag = "";
            this.btnStopService.Text = "متوقف كردن";
            this.btnStopService.Click += new System.EventHandler(this.btnStopService_Click);
            // 
            // btnStartService
            // 
            this.btnStartService.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnStartService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartService.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnStartService.Image = global::Negar.Properties.Resources.Allow;
            this.btnStartService.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnStartService.Location = new System.Drawing.Point(295, 69);
            this.btnStartService.Name = "btnStartService";
            this.btnStartService.Size = new System.Drawing.Size(101, 31);
            this.btnStartService.TabIndex = 2;
            this.btnStartService.TabStop = false;
            this.btnStartService.Tag = "";
            this.btnStartService.Text = "اجرا";
            this.btnStartService.Click += new System.EventHandler(this.btnStartService_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Negar.Properties.Resources.SMS_Logo_1;
            this.pictureBox1.Location = new System.Drawing.Point(12, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(205, 188);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // btnUninstallService
            // 
            this.btnUninstallService.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUninstallService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUninstallService.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnUninstallService.Image = global::Negar.Properties.Resources.SelectNone;
            this.btnUninstallService.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnUninstallService.Location = new System.Drawing.Point(402, 106);
            this.btnUninstallService.Name = "btnUninstallService";
            this.btnUninstallService.Size = new System.Drawing.Size(113, 31);
            this.btnUninstallService.TabIndex = 2;
            this.btnUninstallService.TabStop = false;
            this.btnUninstallService.Tag = "";
            this.btnUninstallService.Text = "حذف سرویس";
            this.btnUninstallService.Click += new System.EventHandler(this.btnUninstallService_Click);
            // 
            // btnInstallService
            // 
            this.btnInstallService.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnInstallService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInstallService.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnInstallService.Image = global::Negar.Properties.Resources.SelectAll;
            this.btnInstallService.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnInstallService.Location = new System.Drawing.Point(402, 69);
            this.btnInstallService.Name = "btnInstallService";
            this.btnInstallService.Size = new System.Drawing.Size(113, 31);
            this.btnInstallService.TabIndex = 2;
            this.btnInstallService.TabStop = false;
            this.btnInstallService.Tag = "";
            this.btnInstallService.Text = "نصب سرویس";
            this.btnInstallService.Click += new System.EventHandler(this.btnInstallService_Click);
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSaveSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveSettings.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSaveSettings.Image = global::Negar.Properties.Resources.Save;
            this.btnSaveSettings.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnSaveSettings.Location = new System.Drawing.Point(378, 184);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(137, 31);
            this.btnSaveSettings.TabIndex = 2;
            this.btnSaveSettings.TabStop = false;
            this.btnSaveSettings.Tag = "";
            this.btnSaveSettings.Text = "ذخیره تنظیمات";
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.CanReorderTabs = true;
            this.tabControl1.Controls.Add(this.tabControlPanel1);
            this.tabControl1.Controls.Add(this.tabControlPanel2);
            this.tabControl1.Controls.Add(this.tabControlPanel4);
            this.tabControl1.Controls.Add(this.tabControlPanel3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedTabFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.tabControl1.SelectedTabIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(527, 269);
            this.tabControl1.TabIndex = 7;
            this.tabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl1.Tabs.Add(this.tabItem1);
            this.tabControl1.Tabs.Add(this.tabItem2);
            this.tabControl1.Tabs.Add(this.btnRefresh3);
            this.tabControl1.Tabs.Add(this.tabItem4);
            this.tabControl1.Text = "پیام های در انتظار ارسال";
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.Controls.Add(this.lblCount1);
            this.tabControlPanel1.Controls.Add(this.dgvQueue);
            this.tabControlPanel1.Controls.Add(this.btnRefresh1);
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 26);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(527, 243);
            this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = 90;
            this.tabControlPanel1.TabIndex = 4;
            this.tabControlPanel1.TabItem = this.tabItem1;
            // 
            // lblCount1
            // 
            this.lblCount1.AutoSize = true;
            this.lblCount1.BackColor = System.Drawing.Color.Transparent;
            this.lblCount1.Location = new System.Drawing.Point(12, 42);
            this.lblCount1.Name = "lblCount1";
            this.lblCount1.Size = new System.Drawing.Size(54, 13);
            this.lblCount1.TabIndex = 7;
            this.lblCount1.Text = "تعداد: 50";
            // 
            // tabItem1
            // 
            this.tabItem1.AttachedControl = this.tabControlPanel1;
            this.tabItem1.Name = "tabItem1";
            this.tabItem1.Text = "در حال ارسال";
            // 
            // tabControlPanel3
            // 
            this.tabControlPanel3.Controls.Add(this.lblCount3);
            this.tabControlPanel3.Controls.Add(this.buttonX7);
            this.tabControlPanel3.Controls.Add(this.btnRetryFaileds);
            this.tabControlPanel3.Controls.Add(this.dgvFaileds);
            this.tabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel3.Location = new System.Drawing.Point(0, 26);
            this.tabControlPanel3.Name = "tabControlPanel3";
            this.tabControlPanel3.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel3.Size = new System.Drawing.Size(527, 243);
            this.tabControlPanel3.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanel3.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel3.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel3.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel3.Style.GradientAngle = 90;
            this.tabControlPanel3.TabIndex = 6;
            this.tabControlPanel3.TabItem = this.btnRefresh3;
            // 
            // lblCount3
            // 
            this.lblCount3.AutoSize = true;
            this.lblCount3.BackColor = System.Drawing.Color.Transparent;
            this.lblCount3.Location = new System.Drawing.Point(12, 42);
            this.lblCount3.Name = "lblCount3";
            this.lblCount3.Size = new System.Drawing.Size(54, 13);
            this.lblCount3.TabIndex = 8;
            this.lblCount3.Text = "تعداد: 50";
            // 
            // buttonX7
            // 
            this.buttonX7.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonX7.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.buttonX7.Image = global::Negar.Properties.Resources.Refresh;
            this.buttonX7.Location = new System.Drawing.Point(428, 4);
            this.buttonX7.Name = "buttonX7";
            this.buttonX7.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor();
            this.buttonX7.Size = new System.Drawing.Size(95, 51);
            this.buttonX7.TabIndex = 7;
            this.buttonX7.TabStop = false;
            this.buttonX7.Tag = "";
            this.buttonX7.Text = "بازخوانی";
            this.buttonX7.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnRefresh3
            // 
            this.btnRefresh3.AttachedControl = this.tabControlPanel3;
            this.btnRefresh3.Name = "btnRefresh3";
            this.btnRefresh3.Text = "ارسال نشده";
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Controls.Add(this.lblCount2);
            this.tabControlPanel2.Controls.Add(this.btnRefresh2);
            this.tabControlPanel2.Controls.Add(this.dgvSents);
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 26);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(527, 243);
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel2.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel2.Style.GradientAngle = 90;
            this.tabControlPanel2.TabIndex = 5;
            this.tabControlPanel2.TabItem = this.tabItem2;
            // 
            // lblCount2
            // 
            this.lblCount2.AutoSize = true;
            this.lblCount2.BackColor = System.Drawing.Color.Transparent;
            this.lblCount2.Location = new System.Drawing.Point(12, 42);
            this.lblCount2.Name = "lblCount2";
            this.lblCount2.Size = new System.Drawing.Size(54, 13);
            this.lblCount2.TabIndex = 8;
            this.lblCount2.Text = "تعداد: 50";
            // 
            // btnRefresh2
            // 
            this.btnRefresh2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRefresh2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh2.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnRefresh2.Image = global::Negar.Properties.Resources.Refresh;
            this.btnRefresh2.Location = new System.Drawing.Point(428, 4);
            this.btnRefresh2.Name = "btnRefresh2";
            this.btnRefresh2.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor();
            this.btnRefresh2.Size = new System.Drawing.Size(95, 51);
            this.btnRefresh2.TabIndex = 7;
            this.btnRefresh2.TabStop = false;
            this.btnRefresh2.Tag = "";
            this.btnRefresh2.Text = "بازخوانی";
            this.btnRefresh2.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // tabItem2
            // 
            this.tabItem2.AttachedControl = this.tabControlPanel2;
            this.tabItem2.Name = "tabItem2";
            this.tabItem2.Text = "ارسال شده";
            // 
            // tabControlPanel4
            // 
            this.tabControlPanel4.Controls.Add(this.btnRefreshServiceStatus);
            this.tabControlPanel4.Controls.Add(this.txtServiceStatus);
            this.tabControlPanel4.Controls.Add(this.pictureBox1);
            this.tabControlPanel4.Controls.Add(this.lblServiceStatus);
            this.tabControlPanel4.Controls.Add(this.lblPortSelection);
            this.tabControlPanel4.Controls.Add(this.btnStopService);
            this.tabControlPanel4.Controls.Add(this.btnSaveSettings);
            this.tabControlPanel4.Controls.Add(this.btnUninstallService);
            this.tabControlPanel4.Controls.Add(this.cboPortName);
            this.tabControlPanel4.Controls.Add(this.btnStartService);
            this.tabControlPanel4.Controls.Add(this.btnInstallService);
            this.tabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel4.Location = new System.Drawing.Point(0, 26);
            this.tabControlPanel4.Name = "tabControlPanel4";
            this.tabControlPanel4.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel4.Size = new System.Drawing.Size(527, 243);
            this.tabControlPanel4.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanel4.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanel4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel4.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel4.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel4.Style.GradientAngle = 90;
            this.tabControlPanel4.TabIndex = 7;
            this.tabControlPanel4.TabItem = this.tabItem4;
            // 
            // btnRefreshServiceStatus
            // 
            this.btnRefreshServiceStatus.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRefreshServiceStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshServiceStatus.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnRefreshServiceStatus.Image = global::Negar.Properties.Resources.Refresh;
            this.btnRefreshServiceStatus.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnRefreshServiceStatus.Location = new System.Drawing.Point(484, 8);
            this.btnRefreshServiceStatus.Name = "btnRefreshServiceStatus";
            this.btnRefreshServiceStatus.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor();
            this.btnRefreshServiceStatus.Size = new System.Drawing.Size(40, 40);
            this.btnRefreshServiceStatus.TabIndex = 8;
            this.btnRefreshServiceStatus.TabStop = false;
            this.btnRefreshServiceStatus.Tag = "";
            this.btnRefreshServiceStatus.Click += new System.EventHandler(this.btnRefreshServiceStatus_Click);
            // 
            // tabItem4
            // 
            this.tabItem4.AttachedControl = this.tabControlPanel4;
            this.tabItem4.Name = "tabItem4";
            this.tabItem4.Text = " تنظیمات و ابزارها";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 269);
            this.Controls.Add(this.tabControl1);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvFaileds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabControlPanel1.ResumeLayout(false);
            this.tabControlPanel1.PerformLayout();
            this.tabControlPanel3.ResumeLayout(false);
            this.tabControlPanel3.PerformLayout();
            this.tabControlPanel2.ResumeLayout(false);
            this.tabControlPanel2.PerformLayout();
            this.tabControlPanel4.ResumeLayout(false);
            this.tabControlPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.ComboBoxEx cboPortName;
        private DevComponents.DotNetBar.LabelX lblPortSelection;
        private DevComponents.DotNetBar.ButtonX btnSaveSettings;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvQueue;
        private DevComponents.DotNetBar.ButtonX btnRetryFaileds;
        private System.Windows.Forms.NotifyIcon FormNotifyIcon;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvFaileds;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvSents;
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
        private DevComponents.DotNetBar.ButtonX btnRefresh1;
        private DevComponents.DotNetBar.LabelX txtServiceStatus;
        private DevComponents.DotNetBar.LabelX lblServiceStatus;
        private DevComponents.DotNetBar.ButtonX btnUninstallService;
        private DevComponents.DotNetBar.ButtonX btnInstallService;
        private DevComponents.DotNetBar.ButtonX btnStopService;
        private DevComponents.DotNetBar.ButtonX btnStartService;
        private DevComponents.DotNetBar.TabControl tabControl1;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
        private DevComponents.DotNetBar.TabItem tabItem1;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
        private DevComponents.DotNetBar.TabItem tabItem2;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel3;
        private DevComponents.DotNetBar.TabItem btnRefresh3;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel4;
        private DevComponents.DotNetBar.TabItem tabItem4;
        private DevComponents.DotNetBar.ButtonX buttonX7;
        private DevComponents.DotNetBar.ButtonX btnRefresh2;
        private DevComponents.DotNetBar.ButtonX btnRefreshServiceStatus;
        private System.Windows.Forms.Label lblCount1;
        private System.Windows.Forms.Label lblCount3;
        private System.Windows.Forms.Label lblCount2;
    }
}

