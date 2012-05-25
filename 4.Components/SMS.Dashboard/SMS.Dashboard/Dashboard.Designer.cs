namespace Sepehr.SMSSender
{
    partial class frmDashboard
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDashboard));
            this.tabControl1 = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel3 = new DevComponents.DotNetBar.TabControlPanel();
            this.btnSearchSentPat = new DevComponents.DotNetBar.ButtonX();
            this.btnSearchByName = new DevComponents.DotNetBar.ButtonX();
            this.btnSearchByPatID = new DevComponents.DotNetBar.ButtonX();
            this.txtLastName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtPatID = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtFirstName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.dgvSearchSentPatients = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ColPatID2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPatFullName2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRefDate2 = new Negar.PersianCalendar.UI.Controls.DataGridViewPersianDateTimePickerColumn();
            this.ColStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PanelRefDateTimeFilter2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.ToDateRef2 = new Negar.PersianCalendar.UI.Controls.PersianDatePicker();
            this.FromDateRef2 = new Negar.PersianCalendar.UI.Controls.PersianDatePicker();
            this.ToTimeRef2 = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.FromTimeRef2 = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.lblToRefTime2 = new DevComponents.DotNetBar.LabelX();
            this.lblFromRefTime2 = new DevComponents.DotNetBar.LabelX();
            this.lblToRefDate2 = new DevComponents.DotNetBar.LabelX();
            this.lblFromRefDate2 = new DevComponents.DotNetBar.LabelX();
            this.cboServCat2 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.lblPatID = new DevComponents.DotNetBar.LabelX();
            this.lblLastName = new DevComponents.DotNetBar.LabelX();
            this.lblFirstName = new DevComponents.DotNetBar.LabelX();
            this.lblServCat2 = new DevComponents.DotNetBar.LabelX();
            this.lblSearchTitle = new DevComponents.DotNetBar.LabelX();
            this.tabItem3 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.btnSendMessages = new DevComponents.DotNetBar.ButtonX();
            this.btnShowTemplate = new DevComponents.DotNetBar.ButtonX();
            this.btnSearchSentMessages = new DevComponents.DotNetBar.ButtonX();
            this.txtMessageTemplate = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.dgvSelectPatients = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ColCheck1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColPatientID1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPatientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRefDate = new Negar.PersianCalendar.UI.Controls.DataGridViewPersianDateTimePickerColumn();
            this.PanelRefDateTimeFilter1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.ToDateRef1 = new Negar.PersianCalendar.UI.Controls.PersianDatePicker();
            this.FromDateRef1 = new Negar.PersianCalendar.UI.Controls.PersianDatePicker();
            this.ToTimeRef1 = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.FromTimeRef1 = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.lblToRefTime1 = new DevComponents.DotNetBar.LabelX();
            this.lblFromRefTime1 = new DevComponents.DotNetBar.LabelX();
            this.lblToRefDate1 = new DevComponents.DotNetBar.LabelX();
            this.lblFromRefDate1 = new DevComponents.DotNetBar.LabelX();
            this.cboTemplates = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.lblMessageTemplate = new DevComponents.DotNetBar.LabelX();
            this.lblSelectTemplate = new DevComponents.DotNetBar.LabelX();
            this.cboServCat1 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.lblServCat1 = new DevComponents.DotNetBar.LabelX();
            this.lblSendingTitle = new DevComponents.DotNetBar.LabelX();
            this.tabItem2 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.lblCount3 = new System.Windows.Forms.Label();
            this.lblCount2 = new System.Windows.Forms.Label();
            this.lblCount1 = new System.Windows.Forms.Label();
            this.btnRefreshToday = new DevComponents.DotNetBar.ButtonX();
            this.btnRetryFaileds = new DevComponents.DotNetBar.ButtonX();
            this.lblSents = new DevComponents.DotNetBar.LabelX();
            this.lblFaileds = new DevComponents.DotNetBar.LabelX();
            this.lblQueue = new DevComponents.DotNetBar.LabelX();
            this.dgvSents = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ColSentsRecieverNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSentsMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSentsDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvFaileds = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ColFailedsRecieverNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFailedsMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFailedsDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvQueue = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ColQueueRecieverNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColQueueMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColQueueSendDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColQueueSendKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabItem1 = new DevComponents.DotNetBar.TabItem(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabControlPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchSentPatients)).BeginInit();
            this.PanelRefDateTimeFilter2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToTimeRef2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromTimeRef2)).BeginInit();
            this.tabControlPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectPatients)).BeginInit();
            this.PanelRefDateTimeFilter1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToTimeRef1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromTimeRef1)).BeginInit();
            this.tabControlPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFaileds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueue)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.CanReorderTabs = true;
            this.tabControl1.Controls.Add(this.tabControlPanel1);
            this.tabControl1.Controls.Add(this.tabControlPanel3);
            this.tabControl1.Controls.Add(this.tabControlPanel2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedTabFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.tabControl1.SelectedTabIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(527, 550);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl1.Tabs.Add(this.tabItem1);
            this.tabControl1.Tabs.Add(this.tabItem2);
            this.tabControl1.Tabs.Add(this.tabItem3);
            this.tabControl1.Text = "tabControl1";
            // 
            // tabControlPanel3
            // 
            this.tabControlPanel3.Controls.Add(this.btnSearchSentPat);
            this.tabControlPanel3.Controls.Add(this.btnSearchByName);
            this.tabControlPanel3.Controls.Add(this.btnSearchByPatID);
            this.tabControlPanel3.Controls.Add(this.txtLastName);
            this.tabControlPanel3.Controls.Add(this.txtPatID);
            this.tabControlPanel3.Controls.Add(this.txtFirstName);
            this.tabControlPanel3.Controls.Add(this.dgvSearchSentPatients);
            this.tabControlPanel3.Controls.Add(this.PanelRefDateTimeFilter2);
            this.tabControlPanel3.Controls.Add(this.cboServCat2);
            this.tabControlPanel3.Controls.Add(this.lblPatID);
            this.tabControlPanel3.Controls.Add(this.lblLastName);
            this.tabControlPanel3.Controls.Add(this.lblFirstName);
            this.tabControlPanel3.Controls.Add(this.lblServCat2);
            this.tabControlPanel3.Controls.Add(this.lblSearchTitle);
            this.tabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel3.Location = new System.Drawing.Point(0, 26);
            this.tabControlPanel3.Name = "tabControlPanel3";
            this.tabControlPanel3.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel3.Size = new System.Drawing.Size(527, 524);
            this.tabControlPanel3.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanel3.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel3.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel3.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel3.Style.GradientAngle = 90;
            this.tabControlPanel3.TabIndex = 0;
            this.tabControlPanel3.TabItem = this.tabItem3;
            // 
            // btnSearchSentPat
            // 
            this.btnSearchSentPat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearchSentPat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchSentPat.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearchSentPat.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.btnSearchSentPat.Location = new System.Drawing.Point(127, 161);
            this.btnSearchSentPat.Name = "btnSearchSentPat";
            this.btnSearchSentPat.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor();
            this.btnSearchSentPat.Size = new System.Drawing.Size(80, 21);
            this.btnSearchSentPat.TabIndex = 12;
            this.btnSearchSentPat.TabStop = false;
            this.btnSearchSentPat.Tag = "";
            this.btnSearchSentPat.Text = "جستجو";
            this.btnSearchSentPat.Click += new System.EventHandler(this.btnSearchSentPat_Click);
            // 
            // btnSearchByName
            // 
            this.btnSearchByName.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearchByName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchByName.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearchByName.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.btnSearchByName.Location = new System.Drawing.Point(12, 26);
            this.btnSearchByName.Name = "btnSearchByName";
            this.btnSearchByName.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor();
            this.btnSearchByName.Size = new System.Drawing.Size(80, 21);
            this.btnSearchByName.TabIndex = 5;
            this.btnSearchByName.TabStop = false;
            this.btnSearchByName.Tag = "";
            this.btnSearchByName.Text = "جستجو";
            this.btnSearchByName.Click += new System.EventHandler(this.btnSearchByName_Click);
            // 
            // btnSearchByPatID
            // 
            this.btnSearchByPatID.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearchByPatID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchByPatID.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearchByPatID.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.btnSearchByPatID.Location = new System.Drawing.Point(211, 54);
            this.btnSearchByPatID.Name = "btnSearchByPatID";
            this.btnSearchByPatID.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor();
            this.btnSearchByPatID.Size = new System.Drawing.Size(80, 21);
            this.btnSearchByPatID.TabIndex = 8;
            this.btnSearchByPatID.TabStop = false;
            this.btnSearchByPatID.Tag = "";
            this.btnSearchByPatID.Text = "جستجو";
            this.btnSearchByPatID.Click += new System.EventHandler(this.btnSearchByPatID_Click);
            // 
            // txtLastName
            // 
            // 
            // 
            // 
            this.txtLastName.Border.Class = "TextBoxBorder";
            this.txtLastName.Location = new System.Drawing.Point(98, 26);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(141, 21);
            this.txtLastName.TabIndex = 4;
            // 
            // txtPatID
            // 
            // 
            // 
            // 
            this.txtPatID.Border.Class = "TextBoxBorder";
            this.txtPatID.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtPatID.Location = new System.Drawing.Point(297, 53);
            this.txtPatID.Name = "txtPatID";
            this.txtPatID.Size = new System.Drawing.Size(165, 22);
            this.txtPatID.TabIndex = 6;
            this.txtPatID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtFirstName
            // 
            // 
            // 
            // 
            this.txtFirstName.Border.Class = "TextBoxBorder";
            this.txtFirstName.Location = new System.Drawing.Point(352, 26);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(110, 21);
            this.txtFirstName.TabIndex = 0;
            // 
            // dgvSearchSentPatients
            // 
            this.dgvSearchSentPatients.AllowUserToAddRows = false;
            this.dgvSearchSentPatients.AllowUserToDeleteRows = false;
            this.dgvSearchSentPatients.AllowUserToOrderColumns = true;
            this.dgvSearchSentPatients.AllowUserToResizeRows = false;
            this.dgvSearchSentPatients.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSearchSentPatients.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvSearchSentPatients.BackgroundColor = System.Drawing.Color.PowderBlue;
            this.dgvSearchSentPatients.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSearchSentPatients.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvSearchSentPatients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSearchSentPatients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColPatID2,
            this.ColPatFullName2,
            this.ColRefDate2,
            this.ColStatus});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSearchSentPatients.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvSearchSentPatients.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvSearchSentPatients.Location = new System.Drawing.Point(12, 188);
            this.dgvSearchSentPatients.MultiSelect = false;
            this.dgvSearchSentPatients.Name = "dgvSearchSentPatients";
            this.dgvSearchSentPatients.ReadOnly = true;
            this.dgvSearchSentPatients.RowHeadersVisible = false;
            this.dgvSearchSentPatients.Size = new System.Drawing.Size(503, 324);
            this.dgvSearchSentPatients.StandardTab = true;
            this.dgvSearchSentPatients.TabIndex = 13;
            // 
            // ColPatID2
            // 
            this.ColPatID2.DataPropertyName = "PatientID";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColPatID2.DefaultCellStyle = dataGridViewCellStyle8;
            this.ColPatID2.HeaderText = "كد بیمار";
            this.ColPatID2.Name = "ColPatID2";
            this.ColPatID2.ReadOnly = true;
            this.ColPatID2.Width = 75;
            // 
            // ColPatFullName2
            // 
            this.ColPatFullName2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColPatFullName2.DataPropertyName = "PatFullName";
            this.ColPatFullName2.HeaderText = "نام بیمار";
            this.ColPatFullName2.Name = "ColPatFullName2";
            this.ColPatFullName2.ReadOnly = true;
            // 
            // ColRefDate2
            // 
            this.ColRefDate2.DataPropertyName = "RefDate";
            this.ColRefDate2.HeaderText = "تاریخ پذیرش";
            this.ColRefDate2.Name = "ColRefDate2";
            this.ColRefDate2.ReadOnly = true;
            this.ColRefDate2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColRefDate2.ShowTime = true;
            this.ColRefDate2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColRefDate2.Width = 130;
            // 
            // ColStatus
            // 
            this.ColStatus.DataPropertyName = "Status";
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColStatus.DefaultCellStyle = dataGridViewCellStyle9;
            this.ColStatus.HeaderText = "وضعیت";
            this.ColStatus.Name = "ColStatus";
            this.ColStatus.ReadOnly = true;
            this.ColStatus.Width = 160;
            // 
            // PanelRefDateTimeFilter2
            // 
            this.PanelRefDateTimeFilter2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelRefDateTimeFilter2.BackColor = System.Drawing.Color.Transparent;
            this.PanelRefDateTimeFilter2.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelRefDateTimeFilter2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelRefDateTimeFilter2.Controls.Add(this.ToDateRef2);
            this.PanelRefDateTimeFilter2.Controls.Add(this.FromDateRef2);
            this.PanelRefDateTimeFilter2.Controls.Add(this.ToTimeRef2);
            this.PanelRefDateTimeFilter2.Controls.Add(this.FromTimeRef2);
            this.PanelRefDateTimeFilter2.Controls.Add(this.lblToRefTime2);
            this.PanelRefDateTimeFilter2.Controls.Add(this.lblFromRefTime2);
            this.PanelRefDateTimeFilter2.Controls.Add(this.lblToRefDate2);
            this.PanelRefDateTimeFilter2.Controls.Add(this.lblFromRefDate2);
            this.PanelRefDateTimeFilter2.DrawTitleBox = false;
            this.PanelRefDateTimeFilter2.Font = new System.Drawing.Font("Tahoma", 8.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.PanelRefDateTimeFilter2.Location = new System.Drawing.Point(213, 107);
            this.PanelRefDateTimeFilter2.Name = "PanelRefDateTimeFilter2";
            this.PanelRefDateTimeFilter2.Size = new System.Drawing.Size(302, 75);
            // 
            // 
            // 
            this.PanelRefDateTimeFilter2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.PanelRefDateTimeFilter2.Style.BackColorGradientAngle = 90;
            this.PanelRefDateTimeFilter2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.PanelRefDateTimeFilter2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelRefDateTimeFilter2.Style.BorderBottomWidth = 1;
            this.PanelRefDateTimeFilter2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.PanelRefDateTimeFilter2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelRefDateTimeFilter2.Style.BorderLeftWidth = 1;
            this.PanelRefDateTimeFilter2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelRefDateTimeFilter2.Style.BorderRightWidth = 1;
            this.PanelRefDateTimeFilter2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelRefDateTimeFilter2.Style.BorderTopWidth = 1;
            this.PanelRefDateTimeFilter2.Style.CornerDiameter = 4;
            this.PanelRefDateTimeFilter2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.PanelRefDateTimeFilter2.Style.TextColor = System.Drawing.Color.Navy;
            this.PanelRefDateTimeFilter2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.PanelRefDateTimeFilter2.TabIndex = 11;
            this.PanelRefDateTimeFilter2.Text = "تاریخ مراجعه ی بیمار";
            // 
            // ToDateRef2
            // 
            this.ToDateRef2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ToDateRef2.IsAllowNullDate = false;
            this.ToDateRef2.IsPopupOpen = false;
            this.ToDateRef2.Location = new System.Drawing.Point(158, 31);
            this.ToDateRef2.Name = "ToDateRef2";
            this.ToDateRef2.SelectedDateTime = new System.DateTime(2009, 7, 16, 10, 41, 0, 0);
            this.ToDateRef2.Size = new System.Drawing.Size(87, 20);
            this.ToDateRef2.TabIndex = 4;
            // 
            // FromDateRef2
            // 
            this.FromDateRef2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FromDateRef2.IsAllowNullDate = false;
            this.FromDateRef2.IsPopupOpen = false;
            this.FromDateRef2.Location = new System.Drawing.Point(158, 4);
            this.FromDateRef2.Name = "FromDateRef2";
            this.FromDateRef2.SelectedDateTime = new System.DateTime(2009, 7, 16, 10, 41, 0, 0);
            this.FromDateRef2.Size = new System.Drawing.Size(87, 20);
            this.FromDateRef2.TabIndex = 0;
            // 
            // ToTimeRef2
            // 
            this.ToTimeRef2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.ToTimeRef2.BackgroundStyle.Class = "DateTimeInputBackground";
            this.ToTimeRef2.CustomFormat = "HH:mm:ss";
            this.ToTimeRef2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ToTimeRef2.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.ToTimeRef2.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.ToTimeRef2.Location = new System.Drawing.Point(7, 31);
            // 
            // 
            // 
            this.ToTimeRef2.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.ToTimeRef2.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.ToTimeRef2.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.ToTimeRef2.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.ToTimeRef2.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.ToTimeRef2.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.ToTimeRef2.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.ToTimeRef2.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.ToTimeRef2.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.ToTimeRef2.MonthCalendar.DisplayMonth = new System.DateTime(2008, 10, 1, 0, 0, 0, 0);
            this.ToTimeRef2.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Saturday;
            this.ToTimeRef2.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.ToTimeRef2.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.ToTimeRef2.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.ToTimeRef2.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.ToTimeRef2.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.ToTimeRef2.MonthCalendar.TodayButtonVisible = true;
            this.ToTimeRef2.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.ToTimeRef2.Name = "ToTimeRef2";
            this.ToTimeRef2.ShowUpDown = true;
            this.ToTimeRef2.Size = new System.Drawing.Size(84, 21);
            this.ToTimeRef2.TabIndex = 7;
            this.ToTimeRef2.Value = new System.DateTime(2009, 12, 29, 23, 59, 59, 0);
            this.ToTimeRef2.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            // 
            // FromTimeRef2
            // 
            this.FromTimeRef2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.FromTimeRef2.BackgroundStyle.Class = "DateTimeInputBackground";
            this.FromTimeRef2.CustomFormat = "HH:mm:ss";
            this.FromTimeRef2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FromTimeRef2.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.FromTimeRef2.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.FromTimeRef2.Location = new System.Drawing.Point(7, 4);
            // 
            // 
            // 
            this.FromTimeRef2.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.FromTimeRef2.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.FromTimeRef2.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.FromTimeRef2.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.FromTimeRef2.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.FromTimeRef2.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.FromTimeRef2.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.FromTimeRef2.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.FromTimeRef2.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.FromTimeRef2.MonthCalendar.DisplayMonth = new System.DateTime(2008, 10, 1, 0, 0, 0, 0);
            this.FromTimeRef2.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Saturday;
            this.FromTimeRef2.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.FromTimeRef2.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.FromTimeRef2.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.FromTimeRef2.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.FromTimeRef2.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.FromTimeRef2.MonthCalendar.TodayButtonVisible = true;
            this.FromTimeRef2.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.FromTimeRef2.Name = "FromTimeRef2";
            this.FromTimeRef2.ShowUpDown = true;
            this.FromTimeRef2.Size = new System.Drawing.Size(84, 21);
            this.FromTimeRef2.TabIndex = 3;
            this.FromTimeRef2.Value = new System.DateTime(2009, 12, 29, 0, 0, 0, 0);
            this.FromTimeRef2.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            // 
            // lblToRefTime2
            // 
            this.lblToRefTime2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblToRefTime2.AutoSize = true;
            this.lblToRefTime2.BackColor = System.Drawing.Color.Transparent;
            this.lblToRefTime2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblToRefTime2.Location = new System.Drawing.Point(94, 33);
            this.lblToRefTime2.Name = "lblToRefTime2";
            this.lblToRefTime2.Size = new System.Drawing.Size(52, 16);
            this.lblToRefTime2.TabIndex = 6;
            this.lblToRefTime2.Text = "تا ساعت:";
            this.lblToRefTime2.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblFromRefTime2
            // 
            this.lblFromRefTime2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFromRefTime2.AutoSize = true;
            this.lblFromRefTime2.BackColor = System.Drawing.Color.Transparent;
            this.lblFromRefTime2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblFromRefTime2.Location = new System.Drawing.Point(94, 6);
            this.lblFromRefTime2.Name = "lblFromRefTime2";
            this.lblFromRefTime2.Size = new System.Drawing.Size(53, 16);
            this.lblFromRefTime2.TabIndex = 2;
            this.lblFromRefTime2.Text = "از ساعت:";
            this.lblFromRefTime2.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblToRefDate2
            // 
            this.lblToRefDate2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblToRefDate2.AutoSize = true;
            this.lblToRefDate2.BackColor = System.Drawing.Color.Transparent;
            this.lblToRefDate2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblToRefDate2.Location = new System.Drawing.Point(251, 33);
            this.lblToRefDate2.Name = "lblToRefDate2";
            this.lblToRefDate2.Size = new System.Drawing.Size(42, 16);
            this.lblToRefDate2.TabIndex = 5;
            this.lblToRefDate2.Text = "تا تاریخ:";
            this.lblToRefDate2.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblFromRefDate2
            // 
            this.lblFromRefDate2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFromRefDate2.AutoSize = true;
            this.lblFromRefDate2.BackColor = System.Drawing.Color.Transparent;
            this.lblFromRefDate2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblFromRefDate2.Location = new System.Drawing.Point(251, 6);
            this.lblFromRefDate2.Name = "lblFromRefDate2";
            this.lblFromRefDate2.Size = new System.Drawing.Size(43, 16);
            this.lblFromRefDate2.TabIndex = 1;
            this.lblFromRefDate2.Text = "از تاریخ:";
            this.lblFromRefDate2.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // cboServCat2
            // 
            this.cboServCat2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboServCat2.DisplayMember = "Name";
            this.cboServCat2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboServCat2.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.cboServCat2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cboServCat2.ForeColor = System.Drawing.Color.Navy;
            this.cboServCat2.FormattingEnabled = true;
            this.cboServCat2.ItemHeight = 13;
            this.cboServCat2.Location = new System.Drawing.Point(213, 80);
            this.cboServCat2.Name = "cboServCat2";
            this.cboServCat2.Size = new System.Drawing.Size(174, 21);
            this.cboServCat2.TabIndex = 9;
            this.cboServCat2.ValueMember = "ID";
            // 
            // lblPatID
            // 
            this.lblPatID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPatID.AutoSize = true;
            this.lblPatID.BackColor = System.Drawing.Color.Transparent;
            this.lblPatID.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblPatID.Location = new System.Drawing.Point(466, 56);
            this.lblPatID.Name = "lblPatID";
            this.lblPatID.Size = new System.Drawing.Size(46, 16);
            this.lblPatID.TabIndex = 7;
            this.lblPatID.Text = "كد بیمار:";
            this.lblPatID.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lblLastName
            // 
            this.lblLastName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLastName.AutoSize = true;
            this.lblLastName.BackColor = System.Drawing.Color.Transparent;
            this.lblLastName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblLastName.Location = new System.Drawing.Point(245, 28);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(101, 16);
            this.lblLastName.TabIndex = 2;
            this.lblLastName.Text = "نام خانوادگی بیمار:";
            this.lblLastName.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lblFirstName
            // 
            this.lblFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.BackColor = System.Drawing.Color.Transparent;
            this.lblFirstName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblFirstName.Location = new System.Drawing.Point(466, 28);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(49, 16);
            this.lblFirstName.TabIndex = 1;
            this.lblFirstName.Text = "نام بیمار:";
            this.lblFirstName.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lblServCat2
            // 
            this.lblServCat2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblServCat2.AutoSize = true;
            this.lblServCat2.BackColor = System.Drawing.Color.Transparent;
            this.lblServCat2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblServCat2.Location = new System.Drawing.Point(391, 82);
            this.lblServCat2.Name = "lblServCat2";
            this.lblServCat2.Size = new System.Drawing.Size(127, 16);
            this.lblServCat2.TabIndex = 10;
            this.lblServCat2.Text = "فیلتر طبقه بندی خدمات:";
            this.lblServCat2.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lblSearchTitle
            // 
            this.lblSearchTitle.AutoSize = true;
            this.lblSearchTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSearchTitle.Location = new System.Drawing.Point(281, 4);
            this.lblSearchTitle.Name = "lblSearchTitle";
            this.lblSearchTitle.Size = new System.Drawing.Size(234, 16);
            this.lblSearchTitle.TabIndex = 3;
            this.lblSearchTitle.Text = "جستجوی پیام های ارسال شده برای بیماران.";
            // 
            // tabItem3
            // 
            this.tabItem3.AttachedControl = this.tabControlPanel3;
            this.tabItem3.Name = "tabItem3";
            this.tabItem3.Text = "جستجو";
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Controls.Add(this.btnSendMessages);
            this.tabControlPanel2.Controls.Add(this.btnShowTemplate);
            this.tabControlPanel2.Controls.Add(this.btnSearchSentMessages);
            this.tabControlPanel2.Controls.Add(this.txtMessageTemplate);
            this.tabControlPanel2.Controls.Add(this.dgvSelectPatients);
            this.tabControlPanel2.Controls.Add(this.PanelRefDateTimeFilter1);
            this.tabControlPanel2.Controls.Add(this.cboTemplates);
            this.tabControlPanel2.Controls.Add(this.lblMessageTemplate);
            this.tabControlPanel2.Controls.Add(this.lblSelectTemplate);
            this.tabControlPanel2.Controls.Add(this.cboServCat1);
            this.tabControlPanel2.Controls.Add(this.lblServCat1);
            this.tabControlPanel2.Controls.Add(this.lblSendingTitle);
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 26);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(527, 524);
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel2.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel2.Style.GradientAngle = 90;
            this.tabControlPanel2.TabIndex = 0;
            this.tabControlPanel2.TabItem = this.tabItem2;
            // 
            // btnSendMessages
            // 
            this.btnSendMessages.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSendMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendMessages.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnSendMessages.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.btnSendMessages.Location = new System.Drawing.Point(12, 491);
            this.btnSendMessages.Name = "btnSendMessages";
            this.btnSendMessages.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor();
            this.btnSendMessages.Size = new System.Drawing.Size(80, 21);
            this.btnSendMessages.TabIndex = 11;
            this.btnSendMessages.TabStop = false;
            this.btnSendMessages.Tag = "";
            this.btnSendMessages.Text = "ارسال";
            this.btnSendMessages.Click += new System.EventHandler(this.btnSendMessages_Click);
            // 
            // btnShowTemplate
            // 
            this.btnShowTemplate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnShowTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowTemplate.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnShowTemplate.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.btnShowTemplate.Location = new System.Drawing.Point(165, 437);
            this.btnShowTemplate.Name = "btnShowTemplate";
            this.btnShowTemplate.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor();
            this.btnShowTemplate.Size = new System.Drawing.Size(80, 21);
            this.btnShowTemplate.TabIndex = 8;
            this.btnShowTemplate.TabStop = false;
            this.btnShowTemplate.Tag = "";
            this.btnShowTemplate.Text = "نمایش";
            this.btnShowTemplate.Click += new System.EventHandler(this.btnShowTemplate_Click);
            // 
            // btnSearchSentMessages
            // 
            this.btnSearchSentMessages.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearchSentMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchSentMessages.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearchSentMessages.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.btnSearchSentMessages.Location = new System.Drawing.Point(127, 105);
            this.btnSearchSentMessages.Name = "btnSearchSentMessages";
            this.btnSearchSentMessages.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor();
            this.btnSearchSentMessages.Size = new System.Drawing.Size(80, 21);
            this.btnSearchSentMessages.TabIndex = 4;
            this.btnSearchSentMessages.TabStop = false;
            this.btnSearchSentMessages.Tag = "";
            this.btnSearchSentMessages.Text = "جستجو";
            this.btnSearchSentMessages.Click += new System.EventHandler(this.btnSearchSentMessages_Click);
            // 
            // txtMessageTemplate
            // 
            // 
            // 
            // 
            this.txtMessageTemplate.Border.Class = "TextBoxBorder";
            this.txtMessageTemplate.Location = new System.Drawing.Point(104, 464);
            this.txtMessageTemplate.Multiline = true;
            this.txtMessageTemplate.Name = "txtMessageTemplate";
            this.txtMessageTemplate.Size = new System.Drawing.Size(324, 48);
            this.txtMessageTemplate.TabIndex = 9;
            // 
            // dgvSelectPatients
            // 
            this.dgvSelectPatients.AllowUserToAddRows = false;
            this.dgvSelectPatients.AllowUserToDeleteRows = false;
            this.dgvSelectPatients.AllowUserToOrderColumns = true;
            this.dgvSelectPatients.AllowUserToResizeRows = false;
            this.dgvSelectPatients.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSelectPatients.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvSelectPatients.BackgroundColor = System.Drawing.Color.PowderBlue;
            this.dgvSelectPatients.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSelectPatients.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvSelectPatients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSelectPatients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColCheck1,
            this.ColPatientID1,
            this.ColPatientName,
            this.ColRefDate});
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSelectPatients.DefaultCellStyle = dataGridViewCellStyle14;
            this.dgvSelectPatients.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvSelectPatients.Location = new System.Drawing.Point(12, 132);
            this.dgvSelectPatients.MultiSelect = false;
            this.dgvSelectPatients.Name = "dgvSelectPatients";
            this.dgvSelectPatients.RowHeadersVisible = false;
            this.dgvSelectPatients.Size = new System.Drawing.Size(503, 299);
            this.dgvSelectPatients.StandardTab = true;
            this.dgvSelectPatients.TabIndex = 5;
            // 
            // ColCheck1
            // 
            this.ColCheck1.HeaderText = "چك";
            this.ColCheck1.Name = "ColCheck1";
            this.ColCheck1.Width = 35;
            // 
            // ColPatientID1
            // 
            this.ColPatientID1.DataPropertyName = "PatientID";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColPatientID1.DefaultCellStyle = dataGridViewCellStyle12;
            this.ColPatientID1.HeaderText = "كد بیمار";
            this.ColPatientID1.Name = "ColPatientID1";
            this.ColPatientID1.ReadOnly = true;
            this.ColPatientID1.Width = 75;
            // 
            // ColPatientName
            // 
            this.ColPatientName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColPatientName.DataPropertyName = "PatFullName";
            this.ColPatientName.HeaderText = "نام بیمار";
            this.ColPatientName.Name = "ColPatientName";
            this.ColPatientName.ReadOnly = true;
            // 
            // ColRefDate
            // 
            this.ColRefDate.DataPropertyName = "RefDate";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ColRefDate.DefaultCellStyle = dataGridViewCellStyle13;
            this.ColRefDate.HeaderText = "تاریخ پذیرش";
            this.ColRefDate.Name = "ColRefDate";
            this.ColRefDate.ReadOnly = true;
            this.ColRefDate.ShowTime = true;
            this.ColRefDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColRefDate.Width = 130;
            // 
            // PanelRefDateTimeFilter1
            // 
            this.PanelRefDateTimeFilter1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelRefDateTimeFilter1.BackColor = System.Drawing.Color.Transparent;
            this.PanelRefDateTimeFilter1.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelRefDateTimeFilter1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelRefDateTimeFilter1.Controls.Add(this.ToDateRef1);
            this.PanelRefDateTimeFilter1.Controls.Add(this.FromDateRef1);
            this.PanelRefDateTimeFilter1.Controls.Add(this.ToTimeRef1);
            this.PanelRefDateTimeFilter1.Controls.Add(this.FromTimeRef1);
            this.PanelRefDateTimeFilter1.Controls.Add(this.lblToRefTime1);
            this.PanelRefDateTimeFilter1.Controls.Add(this.lblFromRefTime1);
            this.PanelRefDateTimeFilter1.Controls.Add(this.lblToRefDate1);
            this.PanelRefDateTimeFilter1.Controls.Add(this.lblFromRefDate1);
            this.PanelRefDateTimeFilter1.DrawTitleBox = false;
            this.PanelRefDateTimeFilter1.Font = new System.Drawing.Font("Tahoma", 8.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.PanelRefDateTimeFilter1.Location = new System.Drawing.Point(213, 51);
            this.PanelRefDateTimeFilter1.Name = "PanelRefDateTimeFilter1";
            this.PanelRefDateTimeFilter1.Size = new System.Drawing.Size(302, 75);
            // 
            // 
            // 
            this.PanelRefDateTimeFilter1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.PanelRefDateTimeFilter1.Style.BackColorGradientAngle = 90;
            this.PanelRefDateTimeFilter1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.PanelRefDateTimeFilter1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelRefDateTimeFilter1.Style.BorderBottomWidth = 1;
            this.PanelRefDateTimeFilter1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.PanelRefDateTimeFilter1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelRefDateTimeFilter1.Style.BorderLeftWidth = 1;
            this.PanelRefDateTimeFilter1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelRefDateTimeFilter1.Style.BorderRightWidth = 1;
            this.PanelRefDateTimeFilter1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelRefDateTimeFilter1.Style.BorderTopWidth = 1;
            this.PanelRefDateTimeFilter1.Style.CornerDiameter = 4;
            this.PanelRefDateTimeFilter1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.PanelRefDateTimeFilter1.Style.TextColor = System.Drawing.Color.Navy;
            this.PanelRefDateTimeFilter1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.PanelRefDateTimeFilter1.TabIndex = 1;
            this.PanelRefDateTimeFilter1.Text = "تاریخ مراجعه ی بیمار";
            // 
            // ToDateRef1
            // 
            this.ToDateRef1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ToDateRef1.IsAllowNullDate = false;
            this.ToDateRef1.IsPopupOpen = false;
            this.ToDateRef1.Location = new System.Drawing.Point(159, 31);
            this.ToDateRef1.Name = "ToDateRef1";
            this.ToDateRef1.SelectedDateTime = new System.DateTime(2009, 7, 16, 10, 41, 0, 0);
            this.ToDateRef1.Size = new System.Drawing.Size(87, 20);
            this.ToDateRef1.TabIndex = 5;
            // 
            // FromDateRef1
            // 
            this.FromDateRef1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FromDateRef1.IsAllowNullDate = false;
            this.FromDateRef1.IsPopupOpen = false;
            this.FromDateRef1.Location = new System.Drawing.Point(159, 4);
            this.FromDateRef1.Name = "FromDateRef1";
            this.FromDateRef1.SelectedDateTime = new System.DateTime(2009, 7, 16, 10, 41, 0, 0);
            this.FromDateRef1.Size = new System.Drawing.Size(87, 20);
            this.FromDateRef1.TabIndex = 0;
            // 
            // ToTimeRef1
            // 
            this.ToTimeRef1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.ToTimeRef1.BackgroundStyle.Class = "DateTimeInputBackground";
            this.ToTimeRef1.CustomFormat = "HH:mm:ss";
            this.ToTimeRef1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ToTimeRef1.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.ToTimeRef1.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.ToTimeRef1.Location = new System.Drawing.Point(8, 31);
            // 
            // 
            // 
            this.ToTimeRef1.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.ToTimeRef1.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.ToTimeRef1.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.ToTimeRef1.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.ToTimeRef1.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.ToTimeRef1.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.ToTimeRef1.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.ToTimeRef1.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.ToTimeRef1.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.ToTimeRef1.MonthCalendar.DisplayMonth = new System.DateTime(2008, 10, 1, 0, 0, 0, 0);
            this.ToTimeRef1.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Saturday;
            this.ToTimeRef1.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.ToTimeRef1.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.ToTimeRef1.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.ToTimeRef1.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.ToTimeRef1.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.ToTimeRef1.MonthCalendar.TodayButtonVisible = true;
            this.ToTimeRef1.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.ToTimeRef1.Name = "ToTimeRef1";
            this.ToTimeRef1.ShowUpDown = true;
            this.ToTimeRef1.Size = new System.Drawing.Size(84, 21);
            this.ToTimeRef1.TabIndex = 7;
            this.ToTimeRef1.Value = new System.DateTime(2009, 12, 29, 23, 59, 59, 0);
            this.ToTimeRef1.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            // 
            // FromTimeRef1
            // 
            this.FromTimeRef1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.FromTimeRef1.BackgroundStyle.Class = "DateTimeInputBackground";
            this.FromTimeRef1.CustomFormat = "HH:mm:ss";
            this.FromTimeRef1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FromTimeRef1.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.FromTimeRef1.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.FromTimeRef1.Location = new System.Drawing.Point(8, 4);
            // 
            // 
            // 
            this.FromTimeRef1.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.FromTimeRef1.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.FromTimeRef1.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.FromTimeRef1.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.FromTimeRef1.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.FromTimeRef1.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.FromTimeRef1.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.FromTimeRef1.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.FromTimeRef1.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.FromTimeRef1.MonthCalendar.DisplayMonth = new System.DateTime(2008, 10, 1, 0, 0, 0, 0);
            this.FromTimeRef1.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Saturday;
            this.FromTimeRef1.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.FromTimeRef1.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.FromTimeRef1.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.FromTimeRef1.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.FromTimeRef1.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.FromTimeRef1.MonthCalendar.TodayButtonVisible = true;
            this.FromTimeRef1.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.FromTimeRef1.Name = "FromTimeRef1";
            this.FromTimeRef1.ShowUpDown = true;
            this.FromTimeRef1.Size = new System.Drawing.Size(84, 21);
            this.FromTimeRef1.TabIndex = 3;
            this.FromTimeRef1.Value = new System.DateTime(2009, 12, 29, 0, 0, 0, 0);
            this.FromTimeRef1.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            // 
            // lblToRefTime1
            // 
            this.lblToRefTime1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblToRefTime1.AutoSize = true;
            this.lblToRefTime1.BackColor = System.Drawing.Color.Transparent;
            this.lblToRefTime1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblToRefTime1.Location = new System.Drawing.Point(95, 33);
            this.lblToRefTime1.Name = "lblToRefTime1";
            this.lblToRefTime1.Size = new System.Drawing.Size(52, 16);
            this.lblToRefTime1.TabIndex = 6;
            this.lblToRefTime1.Text = "تا ساعت:";
            this.lblToRefTime1.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblFromRefTime1
            // 
            this.lblFromRefTime1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFromRefTime1.AutoSize = true;
            this.lblFromRefTime1.BackColor = System.Drawing.Color.Transparent;
            this.lblFromRefTime1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblFromRefTime1.Location = new System.Drawing.Point(95, 6);
            this.lblFromRefTime1.Name = "lblFromRefTime1";
            this.lblFromRefTime1.Size = new System.Drawing.Size(53, 16);
            this.lblFromRefTime1.TabIndex = 2;
            this.lblFromRefTime1.Text = "از ساعت:";
            this.lblFromRefTime1.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblToRefDate1
            // 
            this.lblToRefDate1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblToRefDate1.AutoSize = true;
            this.lblToRefDate1.BackColor = System.Drawing.Color.Transparent;
            this.lblToRefDate1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblToRefDate1.Location = new System.Drawing.Point(252, 33);
            this.lblToRefDate1.Name = "lblToRefDate1";
            this.lblToRefDate1.Size = new System.Drawing.Size(42, 16);
            this.lblToRefDate1.TabIndex = 4;
            this.lblToRefDate1.Text = "تا تاریخ:";
            this.lblToRefDate1.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblFromRefDate1
            // 
            this.lblFromRefDate1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFromRefDate1.AutoSize = true;
            this.lblFromRefDate1.BackColor = System.Drawing.Color.Transparent;
            this.lblFromRefDate1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblFromRefDate1.Location = new System.Drawing.Point(252, 6);
            this.lblFromRefDate1.Name = "lblFromRefDate1";
            this.lblFromRefDate1.Size = new System.Drawing.Size(43, 16);
            this.lblFromRefDate1.TabIndex = 1;
            this.lblFromRefDate1.Text = "از تاریخ:";
            this.lblFromRefDate1.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // cboTemplates
            // 
            this.cboTemplates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTemplates.DisplayMember = "Name";
            this.cboTemplates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTemplates.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.cboTemplates.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cboTemplates.ForeColor = System.Drawing.Color.Navy;
            this.cboTemplates.FormattingEnabled = true;
            this.cboTemplates.ItemHeight = 13;
            this.cboTemplates.Location = new System.Drawing.Point(251, 437);
            this.cboTemplates.Name = "cboTemplates";
            this.cboTemplates.Size = new System.Drawing.Size(177, 21);
            this.cboTemplates.TabIndex = 7;
            this.cboTemplates.ValueMember = "ID";
            // 
            // lblMessageTemplate
            // 
            this.lblMessageTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMessageTemplate.AutoSize = true;
            this.lblMessageTemplate.BackColor = System.Drawing.Color.Transparent;
            this.lblMessageTemplate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblMessageTemplate.Location = new System.Drawing.Point(434, 461);
            this.lblMessageTemplate.Name = "lblMessageTemplate";
            this.lblMessageTemplate.Size = new System.Drawing.Size(49, 16);
            this.lblMessageTemplate.TabIndex = 10;
            this.lblMessageTemplate.Text = "متن پیام:";
            this.lblMessageTemplate.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lblSelectTemplate
            // 
            this.lblSelectTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelectTemplate.AutoSize = true;
            this.lblSelectTemplate.BackColor = System.Drawing.Color.Transparent;
            this.lblSelectTemplate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblSelectTemplate.Location = new System.Drawing.Point(434, 439);
            this.lblSelectTemplate.Name = "lblSelectTemplate";
            this.lblSelectTemplate.Size = new System.Drawing.Size(83, 16);
            this.lblSelectTemplate.TabIndex = 6;
            this.lblSelectTemplate.Text = "قالب پیام كوتاه:";
            this.lblSelectTemplate.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // cboServCat1
            // 
            this.cboServCat1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboServCat1.DisplayMember = "Name";
            this.cboServCat1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboServCat1.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.cboServCat1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cboServCat1.ForeColor = System.Drawing.Color.Navy;
            this.cboServCat1.FormattingEnabled = true;
            this.cboServCat1.ItemHeight = 13;
            this.cboServCat1.Location = new System.Drawing.Point(213, 24);
            this.cboServCat1.Name = "cboServCat1";
            this.cboServCat1.Size = new System.Drawing.Size(171, 21);
            this.cboServCat1.TabIndex = 0;
            this.cboServCat1.ValueMember = "ID";
            // 
            // lblServCat1
            // 
            this.lblServCat1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblServCat1.AutoSize = true;
            this.lblServCat1.BackColor = System.Drawing.Color.Transparent;
            this.lblServCat1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblServCat1.Location = new System.Drawing.Point(388, 26);
            this.lblServCat1.Name = "lblServCat1";
            this.lblServCat1.Size = new System.Drawing.Size(127, 16);
            this.lblServCat1.TabIndex = 2;
            this.lblServCat1.Text = "فیلتر طبقه بندی خدمات:";
            this.lblServCat1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lblSendingTitle
            // 
            this.lblSendingTitle.AutoSize = true;
            this.lblSendingTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSendingTitle.Location = new System.Drawing.Point(297, 4);
            this.lblSendingTitle.Name = "lblSendingTitle";
            this.lblSendingTitle.Size = new System.Drawing.Size(218, 16);
            this.lblSendingTitle.TabIndex = 3;
            this.lblSendingTitle.Text = "جستجوی بیماران برای ارسال پیام جمعی.";
            // 
            // tabItem2
            // 
            this.tabItem2.AttachedControl = this.tabControlPanel2;
            this.tabItem2.Name = "tabItem2";
            this.tabItem2.Text = "ارسال پیام";
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.Controls.Add(this.lblCount3);
            this.tabControlPanel1.Controls.Add(this.lblCount2);
            this.tabControlPanel1.Controls.Add(this.lblCount1);
            this.tabControlPanel1.Controls.Add(this.btnRefreshToday);
            this.tabControlPanel1.Controls.Add(this.btnRetryFaileds);
            this.tabControlPanel1.Controls.Add(this.lblSents);
            this.tabControlPanel1.Controls.Add(this.lblFaileds);
            this.tabControlPanel1.Controls.Add(this.lblQueue);
            this.tabControlPanel1.Controls.Add(this.dgvSents);
            this.tabControlPanel1.Controls.Add(this.dgvFaileds);
            this.tabControlPanel1.Controls.Add(this.dgvQueue);
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 26);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(527, 524);
            this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = 90;
            this.tabControlPanel1.TabIndex = 0;
            this.tabControlPanel1.TabItem = this.tabItem1;
            // 
            // lblCount3
            // 
            this.lblCount3.AutoSize = true;
            this.lblCount3.BackColor = System.Drawing.Color.Transparent;
            this.lblCount3.Location = new System.Drawing.Point(13, 362);
            this.lblCount3.Name = "lblCount3";
            this.lblCount3.Size = new System.Drawing.Size(54, 13);
            this.lblCount3.TabIndex = 10;
            this.lblCount3.Text = "تعداد: 50";
            // 
            // lblCount2
            // 
            this.lblCount2.AutoSize = true;
            this.lblCount2.BackColor = System.Drawing.Color.Transparent;
            this.lblCount2.Location = new System.Drawing.Point(13, 192);
            this.lblCount2.Name = "lblCount2";
            this.lblCount2.Size = new System.Drawing.Size(54, 13);
            this.lblCount2.TabIndex = 5;
            this.lblCount2.Text = "تعداد: 50";
            // 
            // lblCount1
            // 
            this.lblCount1.AutoSize = true;
            this.lblCount1.BackColor = System.Drawing.Color.Transparent;
            this.lblCount1.Location = new System.Drawing.Point(13, 22);
            this.lblCount1.Name = "lblCount1";
            this.lblCount1.Size = new System.Drawing.Size(54, 13);
            this.lblCount1.TabIndex = 3;
            this.lblCount1.Text = "تعداد: 50";
            // 
            // btnRefreshToday
            // 
            this.btnRefreshToday.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRefreshToday.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshToday.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnRefreshToday.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.btnRefreshToday.Location = new System.Drawing.Point(436, 9);
            this.btnRefreshToday.Name = "btnRefreshToday";
            this.btnRefreshToday.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor();
            this.btnRefreshToday.Size = new System.Drawing.Size(80, 21);
            this.btnRefreshToday.TabIndex = 0;
            this.btnRefreshToday.TabStop = false;
            this.btnRefreshToday.Tag = "";
            this.btnRefreshToday.Text = "بازخوانی";
            this.btnRefreshToday.Click += new System.EventHandler(this.btnRefreshToday_Click);
            // 
            // btnRetryFaileds
            // 
            this.btnRetryFaileds.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRetryFaileds.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRetryFaileds.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnRetryFaileds.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.btnRetryFaileds.Location = new System.Drawing.Point(435, 344);
            this.btnRetryFaileds.Name = "btnRetryFaileds";
            this.btnRetryFaileds.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor();
            this.btnRetryFaileds.Size = new System.Drawing.Size(80, 31);
            this.btnRetryFaileds.TabIndex = 8;
            this.btnRetryFaileds.TabStop = false;
            this.btnRetryFaileds.Tag = "";
            this.btnRetryFaileds.Text = "ارسال مجدد";
            this.btnRetryFaileds.Click += new System.EventHandler(this.btnRetryFaileds_Click);
            // 
            // lblSents
            // 
            this.lblSents.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSents.AutoSize = true;
            this.lblSents.BackColor = System.Drawing.Color.Transparent;
            this.lblSents.Font = new System.Drawing.Font("B Mitra", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblSents.ForeColor = System.Drawing.Color.Green;
            this.lblSents.Location = new System.Drawing.Point(181, 174);
            this.lblSents.Name = "lblSents";
            this.lblSents.Size = new System.Drawing.Size(173, 31);
            this.lblSents.TabIndex = 4;
            this.lblSents.Text = "پیام های ارسال شده امروز";
            // 
            // lblFaileds
            // 
            this.lblFaileds.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFaileds.AutoSize = true;
            this.lblFaileds.BackColor = System.Drawing.Color.Transparent;
            this.lblFaileds.Font = new System.Drawing.Font("B Mitra", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblFaileds.ForeColor = System.Drawing.Color.Crimson;
            this.lblFaileds.Location = new System.Drawing.Point(175, 344);
            this.lblFaileds.Name = "lblFaileds";
            this.lblFaileds.Size = new System.Drawing.Size(179, 31);
            this.lblFaileds.TabIndex = 7;
            this.lblFaileds.Text = "پیام های ارسال نشده امروز";
            // 
            // lblQueue
            // 
            this.lblQueue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblQueue.AutoSize = true;
            this.lblQueue.BackColor = System.Drawing.Color.Transparent;
            this.lblQueue.Font = new System.Drawing.Font("B Mitra", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblQueue.Location = new System.Drawing.Point(186, 4);
            this.lblQueue.Name = "lblQueue";
            this.lblQueue.Size = new System.Drawing.Size(162, 31);
            this.lblQueue.TabIndex = 1;
            this.lblQueue.Text = "پیام های در انتظار ارسال";
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColSentsRecieverNum,
            this.ColSentsMessage,
            this.ColSentsDateTime});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSents.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSents.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvSents.Location = new System.Drawing.Point(13, 208);
            this.dgvSents.MultiSelect = false;
            this.dgvSents.Name = "dgvSents";
            this.dgvSents.ReadOnly = true;
            this.dgvSents.RowHeadersVisible = false;
            this.dgvSents.Size = new System.Drawing.Size(503, 130);
            this.dgvSents.StandardTab = true;
            this.dgvSents.TabIndex = 6;
            this.dgvSents.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvToday_CellFormatting);
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
            this.ColSentsDateTime.Width = 130;
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFaileds.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvFaileds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFaileds.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColFailedsRecieverNum,
            this.ColFailedsMessage,
            this.ColFailedsDateTime});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFaileds.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvFaileds.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvFaileds.Location = new System.Drawing.Point(13, 381);
            this.dgvFaileds.MultiSelect = false;
            this.dgvFaileds.Name = "dgvFaileds";
            this.dgvFaileds.ReadOnly = true;
            this.dgvFaileds.RowHeadersVisible = false;
            this.dgvFaileds.Size = new System.Drawing.Size(503, 130);
            this.dgvFaileds.StandardTab = true;
            this.dgvFaileds.TabIndex = 9;
            this.dgvFaileds.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvToday_CellFormatting);
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
            this.ColFailedsDateTime.Width = 130;
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
            this.dgvQueue.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvQueue.Location = new System.Drawing.Point(13, 38);
            this.dgvQueue.MultiSelect = false;
            this.dgvQueue.Name = "dgvQueue";
            this.dgvQueue.ReadOnly = true;
            this.dgvQueue.RowHeadersVisible = false;
            this.dgvQueue.Size = new System.Drawing.Size(503, 130);
            this.dgvQueue.StandardTab = true;
            this.dgvQueue.TabIndex = 2;
            this.dgvQueue.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvToday_CellFormatting);
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
            this.ColQueueSendDateTime.Width = 130;
            // 
            // ColQueueSendKey
            // 
            this.ColQueueSendKey.HeaderText = "كلید ارسال";
            this.ColQueueSendKey.Name = "ColQueueSendKey";
            this.ColQueueSendKey.ReadOnly = true;
            this.ColQueueSendKey.Visible = false;
            // 
            // tabItem1
            // 
            this.tabItem1.AttachedControl = this.tabControlPanel1;
            this.tabItem1.Name = "tabItem1";
            this.tabItem1.Text = "گزارش روز";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(0, -50);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(52, 26);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "خروج";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(527, 550);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDashboard";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "رایان پرتونگار - داشبورد مدیریت پیام كوتاه (SMS)";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabControlPanel3.ResumeLayout(false);
            this.tabControlPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchSentPatients)).EndInit();
            this.PanelRefDateTimeFilter2.ResumeLayout(false);
            this.PanelRefDateTimeFilter2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToTimeRef2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromTimeRef2)).EndInit();
            this.tabControlPanel2.ResumeLayout(false);
            this.tabControlPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectPatients)).EndInit();
            this.PanelRefDateTimeFilter1.ResumeLayout(false);
            this.PanelRefDateTimeFilter1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToTimeRef1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromTimeRef1)).EndInit();
            this.tabControlPanel1.ResumeLayout(false);
            this.tabControlPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFaileds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.TabControl tabControl1;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
        private DevComponents.DotNetBar.TabItem tabItem2;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel3;
        private DevComponents.DotNetBar.TabItem tabItem3;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
        private DevComponents.DotNetBar.TabItem tabItem1;
        private DevComponents.DotNetBar.LabelX lblSendingTitle;
        private DevComponents.DotNetBar.ButtonX btnRetryFaileds;
        private DevComponents.DotNetBar.LabelX lblSents;
        private DevComponents.DotNetBar.LabelX lblFaileds;
        private DevComponents.DotNetBar.LabelX lblQueue;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvSents;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSentsRecieverNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSentsMessage;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSentsDateTime;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvFaileds;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFailedsRecieverNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFailedsMessage;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFailedsDateTime;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvQueue;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColQueueRecieverNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColQueueMessage;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColQueueSendDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColQueueSendKey;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboServCat1;
        private DevComponents.DotNetBar.LabelX lblServCat1;
        private DevComponents.DotNetBar.Controls.GroupPanel PanelRefDateTimeFilter1;
        private Negar.PersianCalendar.UI.Controls.PersianDatePicker ToDateRef1;
        private Negar.PersianCalendar.UI.Controls.PersianDatePicker FromDateRef1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput ToTimeRef1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput FromTimeRef1;
        private DevComponents.DotNetBar.LabelX lblToRefTime1;
        private DevComponents.DotNetBar.LabelX lblFromRefTime1;
        private DevComponents.DotNetBar.LabelX lblToRefDate1;
        private DevComponents.DotNetBar.LabelX lblFromRefDate1;
        private DevComponents.DotNetBar.ButtonX btnSearchSentMessages;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMessageTemplate;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvSelectPatients;
        private DevComponents.DotNetBar.LabelX lblMessageTemplate;
        private DevComponents.DotNetBar.LabelX lblSelectTemplate;
        private DevComponents.DotNetBar.Controls.TextBoxX txtFirstName;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvSearchSentPatients;
        private DevComponents.DotNetBar.Controls.GroupPanel PanelRefDateTimeFilter2;
        private Negar.PersianCalendar.UI.Controls.PersianDatePicker ToDateRef2;
        private Negar.PersianCalendar.UI.Controls.PersianDatePicker FromDateRef2;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput ToTimeRef2;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput FromTimeRef2;
        private DevComponents.DotNetBar.LabelX lblToRefTime2;
        private DevComponents.DotNetBar.LabelX lblFromRefTime2;
        private DevComponents.DotNetBar.LabelX lblToRefDate2;
        private DevComponents.DotNetBar.LabelX lblFromRefDate2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboServCat2;
        private DevComponents.DotNetBar.LabelX lblLastName;
        private DevComponents.DotNetBar.LabelX lblFirstName;
        private DevComponents.DotNetBar.LabelX lblServCat2;
        private DevComponents.DotNetBar.LabelX lblSearchTitle;
        private DevComponents.DotNetBar.ButtonX btnSendMessages;
        private DevComponents.DotNetBar.ButtonX btnShowTemplate;
        private DevComponents.DotNetBar.Controls.TextBoxX txtLastName;
        private DevComponents.DotNetBar.ButtonX btnSearchSentPat;
        private DevComponents.DotNetBar.ButtonX btnSearchByPatID;
        private System.Windows.Forms.Label lblCount3;
        private System.Windows.Forms.Label lblCount2;
        private System.Windows.Forms.Label lblCount1;
        private DevComponents.DotNetBar.ButtonX btnRefreshToday;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboTemplates;
        private DevComponents.DotNetBar.ButtonX btnSearchByName;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPatID;
        private DevComponents.DotNetBar.LabelX lblPatID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPatID2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPatFullName2;
        private Negar.PersianCalendar.UI.Controls.DataGridViewPersianDateTimePickerColumn ColRefDate2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStatus;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColCheck1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPatientID1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPatientName;
        private Negar.PersianCalendar.UI.Controls.DataGridViewPersianDateTimePickerColumn ColRefDate;
        private System.Windows.Forms.Button btnClose;
    }
}

