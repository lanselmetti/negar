namespace Sepehr.Forms.Reports.General.Report13
{
    partial class frmFilter
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFilter));
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.ToDatePrescription = new Negar.PersianCalendar.UI.Controls.PersianDatePicker();
            this.FromDatePrescription = new Negar.PersianCalendar.UI.Controls.PersianDatePicker();
            this.ToTimePrescription = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.FromTimePrescription = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.lblSDate4 = new DevComponents.DotNetBar.LabelX();
            this.cBox2 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cBox1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.dgvCostsAndDiscounts = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ColTypeSelection = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cBoxType = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cBoxCashier = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.dgvCashiers = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ColCashierSelection = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColCashierName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormPanel = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.cBoxCDDate = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.lblType = new DevComponents.DotNetBar.LabelX();
            this.PanelCDDateTimeFilter = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.ToDateCD = new Negar.PersianCalendar.UI.Controls.PersianDatePicker();
            this.FromDateCD = new Negar.PersianCalendar.UI.Controls.PersianDatePicker();
            this.ToTimeCD = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.FromTimeCD = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.lblToCDTime = new DevComponents.DotNetBar.LabelX();
            this.lblFromCDTime = new DevComponents.DotNetBar.LabelX();
            this.lblToCDDate = new DevComponents.DotNetBar.LabelX();
            this.lblFromCDDate = new DevComponents.DotNetBar.LabelX();
            this.cBoxRefDateFilter = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.PanelRefDateTimeFilter = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.ToDateRef = new Negar.PersianCalendar.UI.Controls.PersianDatePicker();
            this.FromDateRef = new Negar.PersianCalendar.UI.Controls.PersianDatePicker();
            this.ToTimeRef = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.FromTimeRef = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.lblToRefTime = new DevComponents.DotNetBar.LabelX();
            this.lblFromRefTime = new DevComponents.DotNetBar.LabelX();
            this.lblToRefDate = new DevComponents.DotNetBar.LabelX();
            this.lblFromRefDate = new DevComponents.DotNetBar.LabelX();
            this.ProgressBar = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.btnHelp = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnReport = new DevComponents.DotNetBar.ButtonX();
            this.BGWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.ToTimePrescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromTimePrescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCostsAndDiscounts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCashiers)).BeginInit();
            this.FormPanel.SuspendLayout();
            this.PanelCDDateTimeFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToTimeCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromTimeCD)).BeginInit();
            this.PanelRefDateTimeFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToTimeRef)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromTimeRef)).BeginInit();
            this.SuspendLayout();
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            // 
            // ToDatePrescription
            // 
            this.ToDatePrescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ToDatePrescription.IsPopupOpen = false;
            this.ToDatePrescription.Location = new System.Drawing.Point(141, 31);
            this.ToDatePrescription.Name = "ToDatePrescription";
            this.ToDatePrescription.SelectedDateTime = new System.DateTime(2009, 7, 16, 10, 41, 0, 0);
            this.ToDatePrescription.Size = new System.Drawing.Size(84, 20);
            this.ToDatePrescription.TabIndex = 27;
            // 
            // FromDatePrescription
            // 
            this.FromDatePrescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FromDatePrescription.IsPopupOpen = false;
            this.FromDatePrescription.Location = new System.Drawing.Point(141, 4);
            this.FromDatePrescription.Name = "FromDatePrescription";
            this.FromDatePrescription.SelectedDateTime = new System.DateTime(2009, 7, 16, 10, 41, 0, 0);
            this.FromDatePrescription.Size = new System.Drawing.Size(84, 20);
            this.FromDatePrescription.TabIndex = 28;
            // 
            // ToTimePrescription
            // 
            this.ToTimePrescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.ToTimePrescription.BackgroundStyle.Class = "DateTimeInputBackground";
            this.ToTimePrescription.CustomFormat = "HH:mm:ss";
            this.ToTimePrescription.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ToTimePrescription.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.ToTimePrescription.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.ToTimePrescription.Location = new System.Drawing.Point(2, 31);
            // 
            // 
            // 
            this.ToTimePrescription.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.ToTimePrescription.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.ToTimePrescription.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.ToTimePrescription.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.ToTimePrescription.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.ToTimePrescription.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.ToTimePrescription.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.ToTimePrescription.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.ToTimePrescription.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.ToTimePrescription.MonthCalendar.DisplayMonth = new System.DateTime(2008, 10, 1, 0, 0, 0, 0);
            this.ToTimePrescription.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Saturday;
            this.ToTimePrescription.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.ToTimePrescription.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.ToTimePrescription.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.ToTimePrescription.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.ToTimePrescription.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.ToTimePrescription.MonthCalendar.TodayButtonVisible = true;
            this.ToTimePrescription.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.ToTimePrescription.Name = "ToTimePrescription";
            this.ToTimePrescription.ShowUpDown = true;
            this.ToTimePrescription.Size = new System.Drawing.Size(75, 21);
            this.ToTimePrescription.TabIndex = 24;
            this.ToTimePrescription.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            // 
            // FromTimePrescription
            // 
            this.FromTimePrescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.FromTimePrescription.BackgroundStyle.Class = "DateTimeInputBackground";
            this.FromTimePrescription.CustomFormat = "HH:mm:ss";
            this.FromTimePrescription.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FromTimePrescription.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.FromTimePrescription.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.FromTimePrescription.Location = new System.Drawing.Point(2, 4);
            // 
            // 
            // 
            this.FromTimePrescription.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.FromTimePrescription.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.FromTimePrescription.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.FromTimePrescription.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.FromTimePrescription.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.FromTimePrescription.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.FromTimePrescription.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.FromTimePrescription.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.FromTimePrescription.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.FromTimePrescription.MonthCalendar.DisplayMonth = new System.DateTime(2008, 10, 1, 0, 0, 0, 0);
            this.FromTimePrescription.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Saturday;
            this.FromTimePrescription.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.FromTimePrescription.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.FromTimePrescription.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.FromTimePrescription.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.FromTimePrescription.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.FromTimePrescription.MonthCalendar.TodayButtonVisible = true;
            this.FromTimePrescription.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.FromTimePrescription.Name = "FromTimePrescription";
            this.FromTimePrescription.ShowUpDown = true;
            this.FromTimePrescription.Size = new System.Drawing.Size(75, 21);
            this.FromTimePrescription.TabIndex = 23;
            this.FromTimePrescription.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            // 
            // lblSDate4
            // 
            this.lblSDate4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSDate4.AutoSize = true;
            this.lblSDate4.BackColor = System.Drawing.Color.Transparent;
            this.lblSDate4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblSDate4.Location = new System.Drawing.Point(234, 6);
            this.lblSDate4.Name = "lblSDate4";
            this.lblSDate4.Size = new System.Drawing.Size(0, 0);
            this.lblSDate4.TabIndex = 22;
            this.lblSDate4.Text = "از تاریخ:";
            this.lblSDate4.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // cBox2
            // 
            this.cBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBox2.AutoSize = true;
            this.cBox2.BackColor = System.Drawing.Color.Transparent;
            this.cBox2.Checked = true;
            this.cBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBox2.CheckValue = "Y";
            this.cBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBox2.Location = new System.Drawing.Point(477, 8);
            this.cBox2.Name = "cBox2";
            this.cBox2.Size = new System.Drawing.Size(52, 16);
            this.cBox2.TabIndex = 2;
            this.cBox2.TabStop = false;
            this.cBox2.Text = "هزینه";
            this.cBox2.CheckedChanged += new System.EventHandler(this.cBox2_CheckedChanged);
            // 
            // cBox1
            // 
            this.cBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBox1.AutoSize = true;
            this.cBox1.BackColor = System.Drawing.Color.Transparent;
            this.cBox1.Checked = true;
            this.cBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBox1.CheckValue = "Y";
            this.cBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBox1.Location = new System.Drawing.Point(534, 8);
            this.cBox1.Name = "cBox1";
            this.cBox1.Size = new System.Drawing.Size(57, 16);
            this.cBox1.TabIndex = 1;
            this.cBox1.TabStop = false;
            this.cBox1.Text = "تخفیف ";
            this.cBox1.CheckedChanged += new System.EventHandler(this.cBox1_CheckedChanged);
            // 
            // dgvCostsAndDiscounts
            // 
            this.dgvCostsAndDiscounts.AllowUserToAddRows = false;
            this.dgvCostsAndDiscounts.AllowUserToDeleteRows = false;
            this.dgvCostsAndDiscounts.AllowUserToOrderColumns = true;
            this.dgvCostsAndDiscounts.AllowUserToResizeColumns = false;
            this.dgvCostsAndDiscounts.AllowUserToResizeRows = false;
            this.dgvCostsAndDiscounts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCostsAndDiscounts.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dgvCostsAndDiscounts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCostsAndDiscounts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCostsAndDiscounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCostsAndDiscounts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColTypeSelection,
            this.ColTypeName});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCostsAndDiscounts.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCostsAndDiscounts.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvCostsAndDiscounts.Location = new System.Drawing.Point(12, 141);
            this.dgvCostsAndDiscounts.MultiSelect = false;
            this.dgvCostsAndDiscounts.Name = "dgvCostsAndDiscounts";
            this.dgvCostsAndDiscounts.RowHeadersVisible = false;
            this.dgvCostsAndDiscounts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCostsAndDiscounts.Size = new System.Drawing.Size(302, 280);
            this.dgvCostsAndDiscounts.TabIndex = 10;
            // 
            // ColTypeSelection
            // 
            this.ColTypeSelection.HeaderText = "اضافه";
            this.ColTypeSelection.Name = "ColTypeSelection";
            this.ColTypeSelection.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColTypeSelection.Width = 35;
            // 
            // ColTypeName
            // 
            this.ColTypeName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColTypeName.DataPropertyName = "Name";
            this.ColTypeName.HeaderText = "نام هزینه یا تخفیف";
            this.ColTypeName.Name = "ColTypeName";
            this.ColTypeName.ReadOnly = true;
            // 
            // cBoxType
            // 
            this.cBoxType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxType.AutoSize = true;
            this.cBoxType.BackColor = System.Drawing.Color.Transparent;
            this.cBoxType.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxType.Location = new System.Drawing.Point(167, 119);
            this.cBoxType.Name = "cBoxType";
            this.cBoxType.Size = new System.Drawing.Size(148, 16);
            this.cBoxType.TabIndex = 8;
            this.cBoxType.Text = "فیلتر نوع هزینه یا تخفیف";
            this.cBoxType.CheckedChanged += new System.EventHandler(this.cBoxType_CheckedChanged);
            // 
            // cBoxCashier
            // 
            this.cBoxCashier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxCashier.AutoSize = true;
            this.cBoxCashier.BackColor = System.Drawing.Color.Transparent;
            this.cBoxCashier.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxCashier.Location = new System.Drawing.Point(463, 119);
            this.cBoxCashier.Name = "cBoxCashier";
            this.cBoxCashier.Size = new System.Drawing.Size(160, 16);
            this.cBoxCashier.TabIndex = 7;
            this.cBoxCashier.Text = "كاربران صندوق ارائه دهنده";
            this.cBoxCashier.CheckedChanged += new System.EventHandler(this.cBoxCashier_CheckedChanged);
            // 
            // dgvCashiers
            // 
            this.dgvCashiers.AllowUserToAddRows = false;
            this.dgvCashiers.AllowUserToDeleteRows = false;
            this.dgvCashiers.AllowUserToOrderColumns = true;
            this.dgvCashiers.AllowUserToResizeColumns = false;
            this.dgvCashiers.AllowUserToResizeRows = false;
            this.dgvCashiers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCashiers.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dgvCashiers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCashiers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCashiers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCashiers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColCashierSelection,
            this.ColCashierName});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCashiers.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCashiers.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvCashiers.Location = new System.Drawing.Point(320, 141);
            this.dgvCashiers.MultiSelect = false;
            this.dgvCashiers.Name = "dgvCashiers";
            this.dgvCashiers.RowHeadersVisible = false;
            this.dgvCashiers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCashiers.Size = new System.Drawing.Size(302, 280);
            this.dgvCashiers.TabIndex = 9;
            // 
            // ColCashierSelection
            // 
            this.ColCashierSelection.HeaderText = "اضافه";
            this.ColCashierSelection.Name = "ColCashierSelection";
            this.ColCashierSelection.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColCashierSelection.Width = 35;
            // 
            // ColCashierName
            // 
            this.ColCashierName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColCashierName.DataPropertyName = "FullName";
            this.ColCashierName.HeaderText = "صندوقدار";
            this.ColCashierName.Name = "ColCashierName";
            this.ColCashierName.ReadOnly = true;
            // 
            // FormPanel
            // 
            this.FormPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.FormPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.FormPanel.Controls.Add(this.cBoxCDDate);
            this.FormPanel.Controls.Add(this.lblType);
            this.FormPanel.Controls.Add(this.cBox1);
            this.FormPanel.Controls.Add(this.cBox2);
            this.FormPanel.Controls.Add(this.PanelCDDateTimeFilter);
            this.FormPanel.Controls.Add(this.cBoxRefDateFilter);
            this.FormPanel.Controls.Add(this.PanelRefDateTimeFilter);
            this.FormPanel.Controls.Add(this.cBoxCashier);
            this.FormPanel.Controls.Add(this.dgvCashiers);
            this.FormPanel.Controls.Add(this.cBoxType);
            this.FormPanel.Controls.Add(this.dgvCostsAndDiscounts);
            this.FormPanel.Controls.Add(this.ProgressBar);
            this.FormPanel.Controls.Add(this.btnHelp);
            this.FormPanel.Controls.Add(this.btnCancel);
            this.FormPanel.Controls.Add(this.btnReport);
            this.FormPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormPanel.Location = new System.Drawing.Point(0, 0);
            this.FormPanel.Name = "FormPanel";
            this.FormPanel.Size = new System.Drawing.Size(634, 529);
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
            // cBoxCDDate
            // 
            this.cBoxCDDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxCDDate.BackColor = System.Drawing.Color.Transparent;
            this.cBoxCDDate.Checked = true;
            this.cBoxCDDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBoxCDDate.CheckValue = "Y";
            this.cBoxCDDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxCDDate.Location = new System.Drawing.Point(602, 32);
            this.cBoxCDDate.Name = "cBoxCDDate";
            this.cBoxCDDate.Size = new System.Drawing.Size(20, 16);
            this.cBoxCDDate.TabIndex = 3;
            this.cBoxCDDate.TabStop = false;
            this.cBoxCDDate.CheckedChanged += new System.EventHandler(this.cBoxCDDate_CheckedChanged);
            // 
            // lblType
            // 
            this.lblType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblType.AutoSize = true;
            this.lblType.BackColor = System.Drawing.Color.Transparent;
            this.lblType.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblType.Location = new System.Drawing.Point(596, 8);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(24, 16);
            this.lblType.TabIndex = 0;
            this.lblType.Text = "نوع:";
            this.lblType.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // PanelCDDateTimeFilter
            // 
            this.PanelCDDateTimeFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelCDDateTimeFilter.BackColor = System.Drawing.Color.Transparent;
            this.PanelCDDateTimeFilter.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelCDDateTimeFilter.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelCDDateTimeFilter.Controls.Add(this.ToDateCD);
            this.PanelCDDateTimeFilter.Controls.Add(this.FromDateCD);
            this.PanelCDDateTimeFilter.Controls.Add(this.ToTimeCD);
            this.PanelCDDateTimeFilter.Controls.Add(this.FromTimeCD);
            this.PanelCDDateTimeFilter.Controls.Add(this.lblToCDTime);
            this.PanelCDDateTimeFilter.Controls.Add(this.lblFromCDTime);
            this.PanelCDDateTimeFilter.Controls.Add(this.lblToCDDate);
            this.PanelCDDateTimeFilter.Controls.Add(this.lblFromCDDate);
            this.PanelCDDateTimeFilter.DrawTitleBox = false;
            this.PanelCDDateTimeFilter.Font = new System.Drawing.Font("Tahoma", 8.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.PanelCDDateTimeFilter.Location = new System.Drawing.Point(320, 38);
            this.PanelCDDateTimeFilter.Name = "PanelCDDateTimeFilter";
            this.PanelCDDateTimeFilter.Size = new System.Drawing.Size(302, 75);
            // 
            // 
            // 
            this.PanelCDDateTimeFilter.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.PanelCDDateTimeFilter.Style.BackColorGradientAngle = 90;
            this.PanelCDDateTimeFilter.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.PanelCDDateTimeFilter.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelCDDateTimeFilter.Style.BorderBottomWidth = 1;
            this.PanelCDDateTimeFilter.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.PanelCDDateTimeFilter.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelCDDateTimeFilter.Style.BorderLeftWidth = 1;
            this.PanelCDDateTimeFilter.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelCDDateTimeFilter.Style.BorderRightWidth = 1;
            this.PanelCDDateTimeFilter.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelCDDateTimeFilter.Style.BorderTopWidth = 1;
            this.PanelCDDateTimeFilter.Style.CornerDiameter = 4;
            this.PanelCDDateTimeFilter.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.PanelCDDateTimeFilter.Style.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(0)))), ((int)(((byte)(132)))));
            this.PanelCDDateTimeFilter.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.PanelCDDateTimeFilter.TabIndex = 4;
            this.PanelCDDateTimeFilter.Text = "تاریخ هزینه یا تخفیف";
            // 
            // ToDateCD
            // 
            this.ToDateCD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ToDateCD.IsAllowNullDate = false;
            this.ToDateCD.IsPopupOpen = false;
            this.ToDateCD.Location = new System.Drawing.Point(156, 31);
            this.ToDateCD.Name = "ToDateCD";
            this.ToDateCD.SelectedDateTime = new System.DateTime(2009, 7, 16, 10, 41, 0, 0);
            this.ToDateCD.Size = new System.Drawing.Size(87, 20);
            this.ToDateCD.TabIndex = 5;
            // 
            // FromDateCD
            // 
            this.FromDateCD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FromDateCD.IsAllowNullDate = false;
            this.FromDateCD.IsPopupOpen = false;
            this.FromDateCD.Location = new System.Drawing.Point(156, 4);
            this.FromDateCD.Name = "FromDateCD";
            this.FromDateCD.SelectedDateTime = new System.DateTime(2009, 7, 16, 10, 41, 0, 0);
            this.FromDateCD.Size = new System.Drawing.Size(87, 20);
            this.FromDateCD.TabIndex = 1;
            // 
            // ToTimeCD
            // 
            this.ToTimeCD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.ToTimeCD.BackgroundStyle.Class = "DateTimeInputBackground";
            this.ToTimeCD.CustomFormat = "HH:mm:ss";
            this.ToTimeCD.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ToTimeCD.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.ToTimeCD.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.ToTimeCD.Location = new System.Drawing.Point(8, 31);
            // 
            // 
            // 
            this.ToTimeCD.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.ToTimeCD.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.ToTimeCD.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.ToTimeCD.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.ToTimeCD.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.ToTimeCD.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.ToTimeCD.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.ToTimeCD.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.ToTimeCD.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.ToTimeCD.MonthCalendar.DisplayMonth = new System.DateTime(2008, 10, 1, 0, 0, 0, 0);
            this.ToTimeCD.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Saturday;
            this.ToTimeCD.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.ToTimeCD.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.ToTimeCD.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.ToTimeCD.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.ToTimeCD.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.ToTimeCD.MonthCalendar.TodayButtonVisible = true;
            this.ToTimeCD.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.ToTimeCD.Name = "ToTimeCD";
            this.ToTimeCD.ShowUpDown = true;
            this.ToTimeCD.Size = new System.Drawing.Size(84, 21);
            this.ToTimeCD.TabIndex = 7;
            this.ToTimeCD.Value = new System.DateTime(2009, 12, 29, 23, 59, 59, 0);
            this.ToTimeCD.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            // 
            // FromTimeCD
            // 
            this.FromTimeCD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.FromTimeCD.BackgroundStyle.Class = "DateTimeInputBackground";
            this.FromTimeCD.CustomFormat = "HH:mm:ss";
            this.FromTimeCD.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FromTimeCD.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.FromTimeCD.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.FromTimeCD.Location = new System.Drawing.Point(8, 4);
            // 
            // 
            // 
            this.FromTimeCD.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.FromTimeCD.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.FromTimeCD.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.FromTimeCD.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.FromTimeCD.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.FromTimeCD.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.FromTimeCD.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.FromTimeCD.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.FromTimeCD.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.FromTimeCD.MonthCalendar.DisplayMonth = new System.DateTime(2008, 10, 1, 0, 0, 0, 0);
            this.FromTimeCD.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Saturday;
            this.FromTimeCD.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.FromTimeCD.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.FromTimeCD.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.FromTimeCD.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.FromTimeCD.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.FromTimeCD.MonthCalendar.TodayButtonVisible = true;
            this.FromTimeCD.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.FromTimeCD.Name = "FromTimeCD";
            this.FromTimeCD.ShowUpDown = true;
            this.FromTimeCD.Size = new System.Drawing.Size(84, 21);
            this.FromTimeCD.TabIndex = 3;
            this.FromTimeCD.Value = new System.DateTime(2009, 12, 29, 0, 0, 0, 0);
            this.FromTimeCD.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            // 
            // lblToCDTime
            // 
            this.lblToCDTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblToCDTime.AutoSize = true;
            this.lblToCDTime.BackColor = System.Drawing.Color.Transparent;
            this.lblToCDTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblToCDTime.Location = new System.Drawing.Point(95, 33);
            this.lblToCDTime.Name = "lblToCDTime";
            this.lblToCDTime.Size = new System.Drawing.Size(52, 16);
            this.lblToCDTime.TabIndex = 6;
            this.lblToCDTime.Text = "تا ساعت:";
            this.lblToCDTime.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblFromCDTime
            // 
            this.lblFromCDTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFromCDTime.AutoSize = true;
            this.lblFromCDTime.BackColor = System.Drawing.Color.Transparent;
            this.lblFromCDTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblFromCDTime.Location = new System.Drawing.Point(95, 6);
            this.lblFromCDTime.Name = "lblFromCDTime";
            this.lblFromCDTime.Size = new System.Drawing.Size(53, 16);
            this.lblFromCDTime.TabIndex = 2;
            this.lblFromCDTime.Text = "از ساعت:";
            this.lblFromCDTime.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblToCDDate
            // 
            this.lblToCDDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblToCDDate.AutoSize = true;
            this.lblToCDDate.BackColor = System.Drawing.Color.Transparent;
            this.lblToCDDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblToCDDate.Location = new System.Drawing.Point(249, 33);
            this.lblToCDDate.Name = "lblToCDDate";
            this.lblToCDDate.Size = new System.Drawing.Size(42, 16);
            this.lblToCDDate.TabIndex = 4;
            this.lblToCDDate.Text = "تا تاریخ:";
            this.lblToCDDate.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblFromCDDate
            // 
            this.lblFromCDDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFromCDDate.AutoSize = true;
            this.lblFromCDDate.BackColor = System.Drawing.Color.Transparent;
            this.lblFromCDDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblFromCDDate.Location = new System.Drawing.Point(249, 6);
            this.lblFromCDDate.Name = "lblFromCDDate";
            this.lblFromCDDate.Size = new System.Drawing.Size(43, 16);
            this.lblFromCDDate.TabIndex = 0;
            this.lblFromCDDate.Text = "از تاریخ:";
            this.lblFromCDDate.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // cBoxRefDateFilter
            // 
            this.cBoxRefDateFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxRefDateFilter.BackColor = System.Drawing.Color.Transparent;
            this.cBoxRefDateFilter.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxRefDateFilter.Location = new System.Drawing.Point(294, 32);
            this.cBoxRefDateFilter.Name = "cBoxRefDateFilter";
            this.cBoxRefDateFilter.Size = new System.Drawing.Size(20, 16);
            this.cBoxRefDateFilter.TabIndex = 5;
            this.cBoxRefDateFilter.TabStop = false;
            this.cBoxRefDateFilter.CheckedChanged += new System.EventHandler(this.cBoxRefDateFilter_CheckedChanged);
            // 
            // PanelRefDateTimeFilter
            // 
            this.PanelRefDateTimeFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelRefDateTimeFilter.BackColor = System.Drawing.Color.Transparent;
            this.PanelRefDateTimeFilter.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelRefDateTimeFilter.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelRefDateTimeFilter.Controls.Add(this.ToDateRef);
            this.PanelRefDateTimeFilter.Controls.Add(this.FromDateRef);
            this.PanelRefDateTimeFilter.Controls.Add(this.ToTimeRef);
            this.PanelRefDateTimeFilter.Controls.Add(this.FromTimeRef);
            this.PanelRefDateTimeFilter.Controls.Add(this.lblToRefTime);
            this.PanelRefDateTimeFilter.Controls.Add(this.lblFromRefTime);
            this.PanelRefDateTimeFilter.Controls.Add(this.lblToRefDate);
            this.PanelRefDateTimeFilter.Controls.Add(this.lblFromRefDate);
            this.PanelRefDateTimeFilter.DrawTitleBox = false;
            this.PanelRefDateTimeFilter.Enabled = false;
            this.PanelRefDateTimeFilter.Font = new System.Drawing.Font("Tahoma", 8.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.PanelRefDateTimeFilter.Location = new System.Drawing.Point(12, 38);
            this.PanelRefDateTimeFilter.Name = "PanelRefDateTimeFilter";
            this.PanelRefDateTimeFilter.Size = new System.Drawing.Size(302, 75);
            // 
            // 
            // 
            this.PanelRefDateTimeFilter.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.PanelRefDateTimeFilter.Style.BackColorGradientAngle = 90;
            this.PanelRefDateTimeFilter.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.PanelRefDateTimeFilter.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelRefDateTimeFilter.Style.BorderBottomWidth = 1;
            this.PanelRefDateTimeFilter.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.PanelRefDateTimeFilter.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelRefDateTimeFilter.Style.BorderLeftWidth = 1;
            this.PanelRefDateTimeFilter.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelRefDateTimeFilter.Style.BorderRightWidth = 1;
            this.PanelRefDateTimeFilter.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelRefDateTimeFilter.Style.BorderTopWidth = 1;
            this.PanelRefDateTimeFilter.Style.CornerDiameter = 4;
            this.PanelRefDateTimeFilter.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.PanelRefDateTimeFilter.Style.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(0)))), ((int)(((byte)(132)))));
            this.PanelRefDateTimeFilter.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.PanelRefDateTimeFilter.TabIndex = 6;
            this.PanelRefDateTimeFilter.Text = "تاریخ پذیرش مراجعه";
            // 
            // ToDateRef
            // 
            this.ToDateRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ToDateRef.IsAllowNullDate = false;
            this.ToDateRef.IsPopupOpen = false;
            this.ToDateRef.Location = new System.Drawing.Point(156, 31);
            this.ToDateRef.Name = "ToDateRef";
            this.ToDateRef.SelectedDateTime = new System.DateTime(2009, 7, 16, 10, 41, 0, 0);
            this.ToDateRef.Size = new System.Drawing.Size(87, 20);
            this.ToDateRef.TabIndex = 5;
            // 
            // FromDateRef
            // 
            this.FromDateRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FromDateRef.IsAllowNullDate = false;
            this.FromDateRef.IsPopupOpen = false;
            this.FromDateRef.Location = new System.Drawing.Point(156, 4);
            this.FromDateRef.Name = "FromDateRef";
            this.FromDateRef.SelectedDateTime = new System.DateTime(2009, 7, 16, 10, 41, 0, 0);
            this.FromDateRef.Size = new System.Drawing.Size(87, 20);
            this.FromDateRef.TabIndex = 1;
            // 
            // ToTimeRef
            // 
            this.ToTimeRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.ToTimeRef.BackgroundStyle.Class = "DateTimeInputBackground";
            this.ToTimeRef.CustomFormat = "HH:mm:ss";
            this.ToTimeRef.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ToTimeRef.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.ToTimeRef.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.ToTimeRef.Location = new System.Drawing.Point(8, 31);
            // 
            // 
            // 
            this.ToTimeRef.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.ToTimeRef.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.ToTimeRef.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.ToTimeRef.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.ToTimeRef.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.ToTimeRef.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.ToTimeRef.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.ToTimeRef.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.ToTimeRef.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.ToTimeRef.MonthCalendar.DisplayMonth = new System.DateTime(2008, 10, 1, 0, 0, 0, 0);
            this.ToTimeRef.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Saturday;
            this.ToTimeRef.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.ToTimeRef.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.ToTimeRef.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.ToTimeRef.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.ToTimeRef.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.ToTimeRef.MonthCalendar.TodayButtonVisible = true;
            this.ToTimeRef.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.ToTimeRef.Name = "ToTimeRef";
            this.ToTimeRef.ShowUpDown = true;
            this.ToTimeRef.Size = new System.Drawing.Size(84, 21);
            this.ToTimeRef.TabIndex = 7;
            this.ToTimeRef.Value = new System.DateTime(2009, 12, 29, 23, 59, 59, 0);
            this.ToTimeRef.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            // 
            // FromTimeRef
            // 
            this.FromTimeRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.FromTimeRef.BackgroundStyle.Class = "DateTimeInputBackground";
            this.FromTimeRef.CustomFormat = "HH:mm:ss";
            this.FromTimeRef.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FromTimeRef.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.FromTimeRef.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.FromTimeRef.Location = new System.Drawing.Point(8, 4);
            // 
            // 
            // 
            this.FromTimeRef.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.FromTimeRef.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.FromTimeRef.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.FromTimeRef.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.FromTimeRef.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.FromTimeRef.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.FromTimeRef.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.FromTimeRef.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.FromTimeRef.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.FromTimeRef.MonthCalendar.DisplayMonth = new System.DateTime(2008, 10, 1, 0, 0, 0, 0);
            this.FromTimeRef.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Saturday;
            this.FromTimeRef.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.FromTimeRef.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.FromTimeRef.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.FromTimeRef.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.FromTimeRef.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.FromTimeRef.MonthCalendar.TodayButtonVisible = true;
            this.FromTimeRef.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.FromTimeRef.Name = "FromTimeRef";
            this.FromTimeRef.ShowUpDown = true;
            this.FromTimeRef.Size = new System.Drawing.Size(84, 21);
            this.FromTimeRef.TabIndex = 3;
            this.FromTimeRef.Value = new System.DateTime(2009, 12, 29, 0, 0, 0, 0);
            this.FromTimeRef.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            // 
            // lblToRefTime
            // 
            this.lblToRefTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblToRefTime.AutoSize = true;
            this.lblToRefTime.BackColor = System.Drawing.Color.Transparent;
            this.lblToRefTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblToRefTime.Location = new System.Drawing.Point(95, 33);
            this.lblToRefTime.Name = "lblToRefTime";
            this.lblToRefTime.Size = new System.Drawing.Size(52, 16);
            this.lblToRefTime.TabIndex = 6;
            this.lblToRefTime.Text = "تا ساعت:";
            this.lblToRefTime.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblFromRefTime
            // 
            this.lblFromRefTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFromRefTime.AutoSize = true;
            this.lblFromRefTime.BackColor = System.Drawing.Color.Transparent;
            this.lblFromRefTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblFromRefTime.Location = new System.Drawing.Point(95, 6);
            this.lblFromRefTime.Name = "lblFromRefTime";
            this.lblFromRefTime.Size = new System.Drawing.Size(53, 16);
            this.lblFromRefTime.TabIndex = 2;
            this.lblFromRefTime.Text = "از ساعت:";
            this.lblFromRefTime.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblToRefDate
            // 
            this.lblToRefDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblToRefDate.AutoSize = true;
            this.lblToRefDate.BackColor = System.Drawing.Color.Transparent;
            this.lblToRefDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblToRefDate.Location = new System.Drawing.Point(249, 33);
            this.lblToRefDate.Name = "lblToRefDate";
            this.lblToRefDate.Size = new System.Drawing.Size(42, 16);
            this.lblToRefDate.TabIndex = 4;
            this.lblToRefDate.Text = "تا تاریخ:";
            this.lblToRefDate.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblFromRefDate
            // 
            this.lblFromRefDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFromRefDate.AutoSize = true;
            this.lblFromRefDate.BackColor = System.Drawing.Color.Transparent;
            this.lblFromRefDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblFromRefDate.Location = new System.Drawing.Point(249, 6);
            this.lblFromRefDate.Name = "lblFromRefDate";
            this.lblFromRefDate.Size = new System.Drawing.Size(43, 16);
            this.lblFromRefDate.TabIndex = 0;
            this.lblFromRefDate.Text = "از تاریخ:";
            this.lblFromRefDate.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // ProgressBar
            // 
            this.ProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressBar.Location = new System.Drawing.Point(12, 427);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(610, 23);
            this.ProgressBar.TabIndex = 11;
            this.ProgressBar.TabStop = false;
            this.ProgressBar.Text = "در انتظار ایجاد گزارش";
            this.ProgressBar.TextVisible = true;
            // 
            // btnHelp
            // 
            this.btnHelp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnHelp.Image = global::Sepehr.Forms.Reports.Properties.Resources.Help;
            this.btnHelp.Location = new System.Drawing.Point(527, 456);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F1);
            this.btnHelp.Size = new System.Drawing.Size(95, 57);
            this.btnHelp.TabIndex = 14;
            this.btnHelp.TabStop = false;
            this.btnHelp.Text = "راهنما\r\n(F1)";
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Sepehr.Forms.Reports.Properties.Resources.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(113, 456);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 57);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "خروج\r\n(Esc)";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnReport
            // 
            this.btnReport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReport.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnReport.Image = global::Sepehr.Forms.Reports.Properties.Resources.Accept;
            this.btnReport.Location = new System.Drawing.Point(12, 456);
            this.btnReport.Name = "btnReport";
            this.btnReport.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnReport.Size = new System.Drawing.Size(95, 57);
            this.btnReport.TabIndex = 12;
            this.btnReport.TabStop = false;
            this.btnReport.Text = "گزارش(F8)";
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // BGWorker
            // 
            this.BGWorker.WorkerSupportsCancellation = true;
            this.BGWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGWorker_DoWork);
            this.BGWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BGWorker_RunWorkerCompleted);
            // 
            // frmFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(634, 529);
            this.Controls.Add(this.FormPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFilter";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "گزارش های حسابداری - گزارش خلاصه تخفیف های و هزینه ها";
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.ToTimePrescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromTimePrescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCostsAndDiscounts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCashiers)).EndInit();
            this.FormPanel.ResumeLayout(false);
            this.FormPanel.PerformLayout();
            this.PanelCDDateTimeFilter.ResumeLayout(false);
            this.PanelCDDateTimeFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToTimeCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromTimeCD)).EndInit();
            this.PanelRefDateTimeFilter.ResumeLayout(false);
            this.PanelRefDateTimeFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToTimeRef)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromTimeRef)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        private Negar.PersianCalendar.UI.Controls.PersianDatePicker ToDatePrescription;
        private Negar.PersianCalendar.UI.Controls.PersianDatePicker FromDatePrescription;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput ToTimePrescription;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput FromTimePrescription;
        private DevComponents.DotNetBar.LabelX lblSDate4;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBox2;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBox1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvCostsAndDiscounts;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxType;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxCashier;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvCashiers;
        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel FormPanel;
        private DevComponents.DotNetBar.Controls.ProgressBarX ProgressBar;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxCDDate;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxRefDateFilter;
        private DevComponents.DotNetBar.ButtonX btnHelp;
        private DevComponents.DotNetBar.Controls.GroupPanel PanelRefDateTimeFilter;
        private Negar.PersianCalendar.UI.Controls.PersianDatePicker ToDateRef;
        private Negar.PersianCalendar.UI.Controls.PersianDatePicker FromDateRef;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput ToTimeRef;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput FromTimeRef;
        private DevComponents.DotNetBar.LabelX lblToRefTime;
        private DevComponents.DotNetBar.LabelX lblFromRefTime;
        private DevComponents.DotNetBar.LabelX lblToRefDate;
        private DevComponents.DotNetBar.LabelX lblFromRefDate;
        private DevComponents.DotNetBar.Controls.GroupPanel PanelCDDateTimeFilter;
        private Negar.PersianCalendar.UI.Controls.PersianDatePicker ToDateCD;
        private Negar.PersianCalendar.UI.Controls.PersianDatePicker FromDateCD;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput ToTimeCD;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput FromTimeCD;
        private DevComponents.DotNetBar.LabelX lblToCDTime;
        private DevComponents.DotNetBar.LabelX lblFromCDTime;
        private DevComponents.DotNetBar.LabelX lblToCDDate;
        private DevComponents.DotNetBar.LabelX lblFromCDDate;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnReport;
        private DevComponents.DotNetBar.LabelX lblType;
        private System.ComponentModel.BackgroundWorker BGWorker;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColCashierSelection;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCashierName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColTypeSelection;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTypeName;
    }
}