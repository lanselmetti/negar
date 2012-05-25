namespace Sepehr.Forms.Schedules
{
    partial class frmPatientSearch
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPatientSearch));
            this.MainPanel = new DevComponents.DotNetBar.PanelEx();
            this.dgvRefList = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ColRefRowNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRefID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRefDate = new Negar.PersianCalendar.UI.Controls.DataGridViewPersianDateTimePickerColumn();
            this.ColIns1Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIns2Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPatList = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ColRow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPatientID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColGender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSearch = new DevComponents.DotNetBar.ButtonX();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnSelect = new DevComponents.DotNetBar.ButtonX();
            this.lblPID = new DevComponents.DotNetBar.LabelX();
            this.lblLastName = new DevComponents.DotNetBar.LabelX();
            this.lblFirstName = new DevComponents.DotNetBar.LabelX();
            this.txtFirstName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtPID = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtLastName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRefList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatList)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.MainPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.MainPanel.Controls.Add(this.dgvRefList);
            this.MainPanel.Controls.Add(this.dgvPatList);
            this.MainPanel.Controls.Add(this.btnSearch);
            this.MainPanel.Controls.Add(this.btnClose);
            this.MainPanel.Controls.Add(this.btnSelect);
            this.MainPanel.Controls.Add(this.lblPID);
            this.MainPanel.Controls.Add(this.lblLastName);
            this.MainPanel.Controls.Add(this.lblFirstName);
            this.MainPanel.Controls.Add(this.txtFirstName);
            this.MainPanel.Controls.Add(this.txtPID);
            this.MainPanel.Controls.Add(this.txtLastName);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(634, 454);
            this.MainPanel.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.MainPanel.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.MainPanel.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.MainPanel.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.MainPanel.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.MainPanel.Style.GradientAngle = 90;
            this.MainPanel.TabIndex = 0;
            // 
            // dgvRefList
            // 
            this.dgvRefList.AllowUserToAddRows = false;
            this.dgvRefList.AllowUserToDeleteRows = false;
            this.dgvRefList.AllowUserToOrderColumns = true;
            this.dgvRefList.AllowUserToResizeRows = false;
            this.dgvRefList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRefList.BackgroundColor = System.Drawing.Color.PowderBlue;
            this.dgvRefList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRefList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRefList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRefList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColRefRowNo,
            this.ColRefID,
            this.ColumnRefDate,
            this.ColIns1Name,
            this.ColIns2Name});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRefList.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvRefList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvRefList.Location = new System.Drawing.Point(12, 241);
            this.dgvRefList.MultiSelect = false;
            this.dgvRefList.Name = "dgvRefList";
            this.dgvRefList.ReadOnly = true;
            this.dgvRefList.RowHeadersVisible = false;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.dgvRefList.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvRefList.RowTemplate.Height = 25;
            this.dgvRefList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRefList.Size = new System.Drawing.Size(609, 135);
            this.dgvRefList.StandardTab = true;
            this.dgvRefList.TabIndex = 8;
            // 
            // ColRefRowNo
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ColRefRowNo.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColRefRowNo.HeaderText = "ردیف";
            this.ColRefRowNo.Name = "ColRefRowNo";
            this.ColRefRowNo.ReadOnly = true;
            this.ColRefRowNo.Width = 35;
            // 
            // ColRefID
            // 
            this.ColRefID.DataPropertyName = "ID";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColRefID.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColRefID.HeaderText = "شماره مراجعه";
            this.ColRefID.Name = "ColRefID";
            this.ColRefID.ReadOnly = true;
            this.ColRefID.ToolTipText = "شماره مراجعه بیمار";
            this.ColRefID.Width = 70;
            // 
            // ColumnRefDate
            // 
            this.ColumnRefDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnRefDate.DataPropertyName = "RegisterDate";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColumnRefDate.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColumnRefDate.HeaderText = "زمان مراجعه";
            this.ColumnRefDate.Name = "ColumnRefDate";
            this.ColumnRefDate.ReadOnly = true;
            this.ColumnRefDate.ShowTime = true;
            this.ColumnRefDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnRefDate.ToolTipText = "تاریخ و ساعت مراجعه بیمار";
            // 
            // ColIns1Name
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = "تسویه";
            this.ColIns1Name.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColIns1Name.HeaderText = "بیمه اول";
            this.ColIns1Name.Name = "ColIns1Name";
            this.ColIns1Name.ReadOnly = true;
            this.ColIns1Name.Width = 160;
            // 
            // ColIns2Name
            // 
            this.ColIns2Name.HeaderText = "بیمه دوم";
            this.ColIns2Name.Name = "ColIns2Name";
            this.ColIns2Name.ReadOnly = true;
            this.ColIns2Name.Width = 160;
            // 
            // dgvPatList
            // 
            this.dgvPatList.AllowUserToAddRows = false;
            this.dgvPatList.AllowUserToDeleteRows = false;
            this.dgvPatList.AllowUserToOrderColumns = true;
            this.dgvPatList.AllowUserToResizeRows = false;
            this.dgvPatList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPatList.BackgroundColor = System.Drawing.Color.LightSkyBlue;
            this.dgvPatList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Green;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPatList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvPatList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPatList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColRow,
            this.ColPatientID,
            this.ColFullName,
            this.ColAge,
            this.ColGender,
            this.Column6,
            this.Column7});
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPatList.DefaultCellStyle = dataGridViewCellStyle14;
            this.dgvPatList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvPatList.Location = new System.Drawing.Point(12, 65);
            this.dgvPatList.MultiSelect = false;
            this.dgvPatList.Name = "dgvPatList";
            this.dgvPatList.ReadOnly = true;
            this.dgvPatList.RowHeadersVisible = false;
            this.dgvPatList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPatList.Size = new System.Drawing.Size(609, 170);
            this.dgvPatList.StandardTab = true;
            this.dgvPatList.TabIndex = 7;
            this.dgvPatList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Grids_KeyDown);
            // 
            // ColRow
            // 
            this.ColRow.DataPropertyName = "RowID";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColRow.DefaultCellStyle = dataGridViewCellStyle9;
            this.ColRow.Frozen = true;
            this.ColRow.HeaderText = "ردیف";
            this.ColRow.Name = "ColRow";
            this.ColRow.ReadOnly = true;
            this.ColRow.Width = 35;
            // 
            // ColPatientID
            // 
            this.ColPatientID.DataPropertyName = "PatientID";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ColPatientID.DefaultCellStyle = dataGridViewCellStyle10;
            this.ColPatientID.Frozen = true;
            this.ColPatientID.HeaderText = "كد بیمار";
            this.ColPatientID.Name = "ColPatientID";
            this.ColPatientID.ReadOnly = true;
            this.ColPatientID.Width = 90;
            // 
            // ColFullName
            // 
            this.ColFullName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColFullName.DataPropertyName = "PatientFullName";
            this.ColFullName.HeaderText = "نام بیمار";
            this.ColFullName.Name = "ColFullName";
            this.ColFullName.ReadOnly = true;
            // 
            // ColAge
            // 
            this.ColAge.DataPropertyName = "PatientAge";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColAge.DefaultCellStyle = dataGridViewCellStyle11;
            this.ColAge.HeaderText = "سن";
            this.ColAge.Name = "ColAge";
            this.ColAge.ReadOnly = true;
            this.ColAge.Width = 35;
            // 
            // ColGender
            // 
            this.ColGender.DataPropertyName = "PatientGender";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColGender.DefaultCellStyle = dataGridViewCellStyle12;
            this.ColGender.HeaderText = "جنس";
            this.ColGender.Name = "ColGender";
            this.ColGender.ReadOnly = true;
            this.ColGender.Width = 50;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "RefCount";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Column6.DefaultCellStyle = dataGridViewCellStyle13;
            this.Column6.HeaderText = "تعداد مراجعه";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 50;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "LastRefPDateTime";
            this.Column7.HeaderText = "آخرین مراجعه";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column7.ToolTipText = "تاریخ آخرین مراجعه";
            this.Column7.Width = 180;
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnSearch.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSearch.ForeColor = System.Drawing.Color.Blue;
            this.btnSearch.Image = global::Sepehr.Forms.Schedules.Properties.Resources.Find;
            this.btnSearch.Location = new System.Drawing.Point(173, 11);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F4);
            this.btnSearch.Size = new System.Drawing.Size(89, 48);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.TabStop = false;
            this.btnSearch.Text = "جستجو (F4)";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnClose.Image = global::Sepehr.Forms.Schedules.Properties.Resources.Cancel;
            this.btnClose.Location = new System.Drawing.Point(113, 382);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 60);
            this.btnClose.TabIndex = 10;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "خروج\r\n(Esc)";
            // 
            // btnSelect
            // 
            this.btnSelect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelect.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSelect.Image = global::Sepehr.Forms.Schedules.Properties.Resources.Accept;
            this.btnSelect.Location = new System.Drawing.Point(12, 382);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnSelect.Size = new System.Drawing.Size(95, 60);
            this.btnSelect.TabIndex = 9;
            this.btnSelect.TabStop = false;
            this.btnSelect.Text = "انتخاب (F8)";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // lblPID
            // 
            this.lblPID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPID.AutoSize = true;
            this.lblPID.BackColor = System.Drawing.Color.Transparent;
            this.lblPID.Location = new System.Drawing.Point(545, 15);
            this.lblPID.Name = "lblPID";
            this.lblPID.Size = new System.Drawing.Size(68, 16);
            this.lblPID.TabIndex = 1;
            this.lblPID.Text = "شماره بیمار:";
            // 
            // lblLastName
            // 
            this.lblLastName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLastName.AutoSize = true;
            this.lblLastName.BackColor = System.Drawing.Color.Transparent;
            this.lblLastName.ForeColor = System.Drawing.Color.Red;
            this.lblLastName.Location = new System.Drawing.Point(545, 40);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(74, 16);
            this.lblLastName.TabIndex = 2;
            this.lblLastName.Text = "نام خانوادگی:";
            // 
            // lblFirstName
            // 
            this.lblFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.BackColor = System.Drawing.Color.Transparent;
            this.lblFirstName.ForeColor = System.Drawing.Color.Red;
            this.lblFirstName.Location = new System.Drawing.Point(383, 40);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(21, 16);
            this.lblFirstName.TabIndex = 4;
            this.lblFirstName.Text = "نام:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtFirstName.Border.Class = "TextBoxBorder";
            this.txtFirstName.ButtonCustom.Image = global::Sepehr.Forms.Schedules.Properties.Resources.DeleteSmall;
            this.txtFirstName.ButtonCustom.Visible = true;
            this.txtFirstName.Location = new System.Drawing.Point(268, 37);
            this.txtFirstName.MaxLength = 15;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(113, 22);
            this.txtFirstName.TabIndex = 5;
            this.txtFirstName.Tag = "";
            this.txtFirstName.ButtonCustomClick += new System.EventHandler(this.txtClear_ButtonCustomClick);
            // 
            // txtPID
            // 
            this.txtPID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtPID.Border.Class = "TextBoxBorder";
            this.txtPID.ButtonCustom.Image = global::Sepehr.Forms.Schedules.Properties.Resources.DeleteSmall;
            this.txtPID.ButtonCustom.Visible = true;
            this.txtPID.Location = new System.Drawing.Point(439, 12);
            this.txtPID.MaxLength = 25;
            this.txtPID.Name = "txtPID";
            this.txtPID.Size = new System.Drawing.Size(106, 22);
            this.txtPID.TabIndex = 0;
            this.txtPID.Tag = "";
            this.txtPID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPID.ButtonCustomClick += new System.EventHandler(this.txtClear_ButtonCustomClick);
            // 
            // txtLastName
            // 
            this.txtLastName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtLastName.Border.Class = "TextBoxBorder";
            this.txtLastName.ButtonCustom.Image = global::Sepehr.Forms.Schedules.Properties.Resources.DeleteSmall;
            this.txtLastName.ButtonCustom.Visible = true;
            this.txtLastName.Location = new System.Drawing.Point(409, 37);
            this.txtLastName.MaxLength = 25;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(136, 22);
            this.txtLastName.TabIndex = 3;
            this.txtLastName.Tag = "";
            this.txtLastName.ButtonCustomClick += new System.EventHandler(this.txtClear_ButtonCustomClick);
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            // 
            // frmPatientSearch
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(634, 454);
            this.Controls.Add(this.MainPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "frmPatientSearch";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "بیماران - نوبت دهی - جستجوی بیماران ثبت شده و دارای پرونده در سیستم";
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRefList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx MainPanel;
        private DevComponents.DotNetBar.LabelX lblLastName;
        private DevComponents.DotNetBar.LabelX lblFirstName;
        internal DevComponents.DotNetBar.Controls.TextBoxX txtFirstName;
        internal DevComponents.DotNetBar.Controls.TextBoxX txtLastName;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.ButtonX btnSelect;
        private DevComponents.DotNetBar.LabelX lblPID;
        private DevComponents.DotNetBar.ButtonX btnSearch;
        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        internal DevComponents.DotNetBar.Controls.TextBoxX txtPID;
        public DevComponents.DotNetBar.Controls.DataGridViewX dgvPatList;
        public DevComponents.DotNetBar.Controls.DataGridViewX dgvRefList;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRow;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPatientID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAge;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRefRowNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRefID;
        private Negar.PersianCalendar.UI.Controls.DataGridViewPersianDateTimePickerColumn ColumnRefDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIns1Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIns2Name;

    }
}