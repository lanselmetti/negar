namespace Sepehr.Forms.Schedules
{
    partial class frmPatientShiftSearch
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPatientShiftSearch));
            this.MainPanel = new DevComponents.DotNetBar.PanelEx();
            this.EndDate = new Negar.PersianCalendar.UI.Controls.PersianDatePicker();
            this.StartDate = new Negar.PersianCalendar.UI.Controls.PersianDatePicker();
            this.txtAge = new DevComponents.Editors.IntegerInput();
            this.btnSearch = new DevComponents.DotNetBar.ButtonX();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnSelect = new DevComponents.DotNetBar.ButtonX();
            this.lblAge = new DevComponents.DotNetBar.LabelX();
            this.lblTel = new DevComponents.DotNetBar.LabelX();
            this.lblLastName = new DevComponents.DotNetBar.LabelX();
            this.lblFirstName = new DevComponents.DotNetBar.LabelX();
            this.txtFirstName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtTel = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtLastName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.dgvData = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ColumnAppName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColDate = new Negar.PersianCalendar.UI.Controls.DataGridViewPersianDateTimePickerColumn();
            this.ColTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboSchedulesPrograms = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.lblToDate = new DevComponents.DotNetBar.LabelX();
            this.lblFromDate = new DevComponents.DotNetBar.LabelX();
            this.lblPrograms = new DevComponents.DotNetBar.LabelX();
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.MainPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.MainPanel.Controls.Add(this.EndDate);
            this.MainPanel.Controls.Add(this.StartDate);
            this.MainPanel.Controls.Add(this.txtAge);
            this.MainPanel.Controls.Add(this.btnSearch);
            this.MainPanel.Controls.Add(this.btnClose);
            this.MainPanel.Controls.Add(this.btnSelect);
            this.MainPanel.Controls.Add(this.lblAge);
            this.MainPanel.Controls.Add(this.lblTel);
            this.MainPanel.Controls.Add(this.lblLastName);
            this.MainPanel.Controls.Add(this.lblFirstName);
            this.MainPanel.Controls.Add(this.txtFirstName);
            this.MainPanel.Controls.Add(this.txtTel);
            this.MainPanel.Controls.Add(this.txtLastName);
            this.MainPanel.Controls.Add(this.dgvData);
            this.MainPanel.Controls.Add(this.cboSchedulesPrograms);
            this.MainPanel.Controls.Add(this.lblToDate);
            this.MainPanel.Controls.Add(this.lblFromDate);
            this.MainPanel.Controls.Add(this.lblPrograms);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(874, 572);
            this.MainPanel.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.MainPanel.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.MainPanel.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.MainPanel.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.MainPanel.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.MainPanel.Style.GradientAngle = 90;
            this.MainPanel.TabIndex = 0;
            // 
            // EndDate
            // 
            this.EndDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EndDate.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.EndDate.IsAllowNullDate = false;
            this.EndDate.IsPopupOpen = false;
            this.EndDate.Location = new System.Drawing.Point(505, 38);
            this.EndDate.Name = "EndDate";
            this.EndDate.SelectedDateTime = new System.DateTime(2009, 7, 12, 11, 27, 50, 0);
            this.EndDate.Size = new System.Drawing.Size(99, 20);
            this.EndDate.TabIndex = 9;
            // 
            // StartDate
            // 
            this.StartDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.StartDate.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.StartDate.IsAllowNullDate = false;
            this.StartDate.IsPopupOpen = false;
            this.StartDate.Location = new System.Drawing.Point(673, 38);
            this.StartDate.Name = "StartDate";
            this.StartDate.SelectedDateTime = new System.DateTime(2009, 7, 12, 11, 27, 50, 0);
            this.StartDate.Size = new System.Drawing.Size(99, 20);
            this.StartDate.TabIndex = 7;
            // 
            // txtAge
            // 
            this.txtAge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtAge.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtAge.ButtonClear.Image = global::Sepehr.Forms.Schedules.Properties.Resources.DeleteSmall;
            this.txtAge.ButtonClear.Visible = true;
            this.txtAge.ButtonCustom.Visible = true;
            this.txtAge.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtAge.Location = new System.Drawing.Point(370, 38);
            this.txtAge.MaxValue = 110;
            this.txtAge.MinValue = 0;
            this.txtAge.Name = "txtAge";
            this.txtAge.ShowUpDown = true;
            this.txtAge.Size = new System.Drawing.Size(91, 21);
            this.txtAge.TabIndex = 11;
            this.txtAge.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            this.txtAge.ButtonCustomClick += new System.EventHandler(this.txtAge_ButtonCustomClick);
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnSearch.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSearch.ForeColor = System.Drawing.Color.Black;
            this.btnSearch.Image = global::Sepehr.Forms.Schedules.Properties.Resources.Find;
            this.btnSearch.Location = new System.Drawing.Point(92, 11);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F4);
            this.btnSearch.Size = new System.Drawing.Size(89, 48);
            this.btnSearch.TabIndex = 14;
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
            this.btnClose.Location = new System.Drawing.Point(113, 500);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 60);
            this.btnClose.TabIndex = 17;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "خروج\r\n(Esc)";
            // 
            // btnSelect
            // 
            this.btnSelect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelect.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSelect.Image = global::Sepehr.Forms.Schedules.Properties.Resources.Accept;
            this.btnSelect.Location = new System.Drawing.Point(12, 500);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnSelect.Size = new System.Drawing.Size(95, 60);
            this.btnSelect.TabIndex = 16;
            this.btnSelect.TabStop = false;
            this.btnSelect.Text = "انتخاب (F8)";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // lblAge
            // 
            this.lblAge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAge.AutoSize = true;
            this.lblAge.BackColor = System.Drawing.Color.Transparent;
            this.lblAge.Location = new System.Drawing.Point(464, 40);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(28, 16);
            this.lblAge.TabIndex = 10;
            this.lblAge.Text = "سن:";
            // 
            // lblTel
            // 
            this.lblTel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTel.AutoSize = true;
            this.lblTel.BackColor = System.Drawing.Color.Transparent;
            this.lblTel.Location = new System.Drawing.Point(328, 40);
            this.lblTel.Name = "lblTel";
            this.lblTel.Size = new System.Drawing.Size(30, 16);
            this.lblTel.TabIndex = 12;
            this.lblTel.Text = "تلفن:";
            // 
            // lblLastName
            // 
            this.lblLastName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLastName.AutoSize = true;
            this.lblLastName.BackColor = System.Drawing.Color.Transparent;
            this.lblLastName.Location = new System.Drawing.Point(788, 14);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(74, 16);
            this.lblLastName.TabIndex = 1;
            this.lblLastName.Text = "نام خانوادگی:";
            // 
            // lblFirstName
            // 
            this.lblFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.BackColor = System.Drawing.Color.Transparent;
            this.lblFirstName.Location = new System.Drawing.Point(622, 14);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(21, 16);
            this.lblFirstName.TabIndex = 2;
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
            this.txtFirstName.Location = new System.Drawing.Point(505, 11);
            this.txtFirstName.MaxLength = 15;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(113, 22);
            this.txtFirstName.TabIndex = 3;
            this.txtFirstName.Tag = "";
            this.txtFirstName.ButtonCustomClick += new System.EventHandler(this.txtClear_ButtonCustomClick);
            // 
            // txtTel
            // 
            this.txtTel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtTel.Border.Class = "TextBoxBorder";
            this.txtTel.ButtonCustom.Image = global::Sepehr.Forms.Schedules.Properties.Resources.DeleteSmall;
            this.txtTel.ButtonCustom.Visible = true;
            this.txtTel.Location = new System.Drawing.Point(187, 37);
            this.txtTel.MaxLength = 25;
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(137, 22);
            this.txtTel.TabIndex = 13;
            this.txtTel.Tag = "";
            this.txtTel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTel.ButtonCustomClick += new System.EventHandler(this.txtClear_ButtonCustomClick);
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
            this.txtLastName.Location = new System.Drawing.Point(649, 11);
            this.txtLastName.MaxLength = 25;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(138, 22);
            this.txtLastName.TabIndex = 0;
            this.txtLastName.Tag = "";
            this.txtLastName.ButtonCustomClick += new System.EventHandler(this.txtClear_ButtonCustomClick);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToOrderColumns = true;
            this.dgvData.AllowUserToResizeRows = false;
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnAppName,
            this.ColDate,
            this.ColTime,
            this.ColDay,
            this.Column7,
            this.Column5,
            this.Column6,
            this.Column9,
            this.Column10});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvData.Location = new System.Drawing.Point(12, 65);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(850, 429);
            this.dgvData.StandardTab = true;
            this.dgvData.TabIndex = 15;
            this.dgvData.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dgvData_PreviewKeyDown);
            this.dgvData.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvResult_CellMouseDoubleClick);
            // 
            // ColumnAppName
            // 
            this.ColumnAppName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnAppName.DataPropertyName = "ApplicationIX";
            this.ColumnAppName.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ColumnAppName.HeaderText = "برنامه نوبت دهی";
            this.ColumnAppName.Name = "ColumnAppName";
            this.ColumnAppName.ReadOnly = true;
            this.ColumnAppName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnAppName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColDate
            // 
            this.ColDate.DataPropertyName = "OccuredDateTime";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(212)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ColDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColDate.HeaderText = "تاریخ";
            this.ColDate.Name = "ColDate";
            this.ColDate.ReadOnly = true;
            this.ColDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColDate.ShowTime = true;
            this.ColDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColDate.Width = 85;
            // 
            // ColTime
            // 
            this.ColTime.DataPropertyName = "OccuredDateTime";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "HH:mm";
            this.ColTime.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColTime.HeaderText = "ساعت";
            this.ColTime.Name = "ColTime";
            this.ColTime.ReadOnly = true;
            this.ColTime.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColTime.Width = 50;
            // 
            // ColDay
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ColDay.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColDay.HeaderText = "روز";
            this.ColDay.Name = "ColDay";
            this.ColDay.ReadOnly = true;
            this.ColDay.Width = 75;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "OrderNo";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Column7.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column7.HeaderText = "نوبت";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 35;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "FirstName";
            this.Column5.HeaderText = "نام";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 90;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "LastName";
            this.Column6.HeaderText = "نام خانوادگی";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 110;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "TelNo1";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column9.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column9.HeaderText = "تلفن 1";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "TelNo2";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column10.DefaultCellStyle = dataGridViewCellStyle7;
            this.Column10.HeaderText = "تلفن 2";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 110;
            // 
            // cboSchedulesPrograms
            // 
            this.cboSchedulesPrograms.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSchedulesPrograms.DisplayMember = "Text";
            this.cboSchedulesPrograms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSchedulesPrograms.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.cboSchedulesPrograms.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cboSchedulesPrograms.FormattingEnabled = true;
            this.cboSchedulesPrograms.ItemHeight = 13;
            this.cboSchedulesPrograms.Location = new System.Drawing.Point(187, 12);
            this.cboSchedulesPrograms.Name = "cboSchedulesPrograms";
            this.cboSchedulesPrograms.Size = new System.Drawing.Size(274, 21);
            this.cboSchedulesPrograms.TabIndex = 5;
            // 
            // lblToDate
            // 
            this.lblToDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblToDate.AutoSize = true;
            this.lblToDate.Location = new System.Drawing.Point(608, 40);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(42, 16);
            this.lblToDate.TabIndex = 8;
            this.lblToDate.Text = "تا تاریخ:";
            // 
            // lblFromDate
            // 
            this.lblFromDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new System.Drawing.Point(776, 40);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(86, 16);
            this.lblFromDate.TabIndex = 6;
            this.lblFromDate.Text = "جستجو از تاریخ:";
            // 
            // lblPrograms
            // 
            this.lblPrograms.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPrograms.AutoSize = true;
            this.lblPrograms.Location = new System.Drawing.Point(462, 14);
            this.lblPrograms.Name = "lblPrograms";
            this.lblPrograms.Size = new System.Drawing.Size(37, 16);
            this.lblPrograms.TabIndex = 4;
            this.lblPrograms.Text = "برنامه:";
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            // 
            // frmPatientShiftSearch
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(874, 572);
            this.Controls.Add(this.MainPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(880, 600);
            this.Name = "frmPatientShiftSearch";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "بیماران - نوبت دهی - جستجوی بیماران نوبت داده شده";
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx MainPanel;
        private DevComponents.DotNetBar.LabelX lblLastName;
        private DevComponents.DotNetBar.LabelX lblFirstName;
        internal DevComponents.DotNetBar.Controls.TextBoxX txtFirstName;
        internal DevComponents.DotNetBar.Controls.TextBoxX txtLastName;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvData;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboSchedulesPrograms;
        private DevComponents.DotNetBar.LabelX lblToDate;
        private DevComponents.DotNetBar.LabelX lblFromDate;
        private DevComponents.DotNetBar.LabelX lblPrograms;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.ButtonX btnSelect;
        private DevComponents.DotNetBar.LabelX lblTel;
        private DevComponents.DotNetBar.ButtonX btnSearch;
        private DevComponents.DotNetBar.LabelX lblAge;
        private Negar.PersianCalendar.UI.Controls.PersianDatePicker EndDate;
        private Negar.PersianCalendar.UI.Controls.PersianDatePicker StartDate;
        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        internal DevComponents.Editors.IntegerInput txtAge;
        internal DevComponents.DotNetBar.Controls.TextBoxX txtTel;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnAppName;
        private Negar.PersianCalendar.UI.Controls.DataGridViewPersianDateTimePickerColumn ColDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;

    }
}