namespace Sepehr.Forms.Cash
{
    partial class frmCashesReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCashesReport));
            this.FromDate = new Negar.PersianCalendar.UI.Controls.PersianDatePicker();
            this.PanelFilters = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.btnPrint = new DevComponents.DotNetBar.ButtonX();
            this.btnRefresh = new DevComponents.DotNetBar.ButtonX();
            this.ToDate = new Negar.PersianCalendar.UI.Controls.PersianDatePicker();
            this.ToTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.FromTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.lblFromDate = new DevComponents.DotNetBar.LabelX();
            this.lblFromTime = new DevComponents.DotNetBar.LabelX();
            this.lblToDate = new DevComponents.DotNetBar.LabelX();
            this.lblToTime = new DevComponents.DotNetBar.LabelX();
            this.lblCashier = new DevComponents.DotNetBar.LabelX();
            this.lblCash = new DevComponents.DotNetBar.LabelX();
            this.cboCashier = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cboCash = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.ColRowNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCashStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new Negar.PersianCalendar.UI.Controls.DataGridViewPersianDateTimePickerColumn();
            this.ColSupplyBegin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStatutorySypply = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSupplyEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRemainValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEndCashier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new Negar.PersianCalendar.UI.Controls.DataGridViewPersianDateTimePickerColumn();
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.cmsPatients = new DevComponents.DotNetBar.ContextMenuBar();
            this.cmsdgvData = new DevComponents.DotNetBar.ButtonItem();
            this.btnCashInOutReport = new DevComponents.DotNetBar.ButtonItem();
            this.PanelFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmsPatients)).BeginInit();
            this.SuspendLayout();
            // 
            // FromDate
            // 
            this.FromDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FromDate.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.FromDate.IsAllowNullDate = false;
            this.FromDate.IsPopupOpen = false;
            this.FromDate.Location = new System.Drawing.Point(826, 59);
            this.FromDate.Name = "FromDate";
            this.FromDate.SelectedDateTime = new System.DateTime(2009, 7, 9, 18, 10, 43, 0);
            this.FromDate.Size = new System.Drawing.Size(98, 21);
            this.FromDate.TabIndex = 5;
            // 
            // PanelFilters
            // 
            this.PanelFilters.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelFilters.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelFilters.Controls.Add(this.btnPrint);
            this.PanelFilters.Controls.Add(this.btnRefresh);
            this.PanelFilters.Controls.Add(this.ToDate);
            this.PanelFilters.Controls.Add(this.FromDate);
            this.PanelFilters.Controls.Add(this.ToTime);
            this.PanelFilters.Controls.Add(this.FromTime);
            this.PanelFilters.Controls.Add(this.lblFromDate);
            this.PanelFilters.Controls.Add(this.lblFromTime);
            this.PanelFilters.Controls.Add(this.lblToDate);
            this.PanelFilters.Controls.Add(this.lblToTime);
            this.PanelFilters.Controls.Add(this.lblCashier);
            this.PanelFilters.Controls.Add(this.lblCash);
            this.PanelFilters.Controls.Add(this.cboCashier);
            this.PanelFilters.Controls.Add(this.cboCash);
            this.PanelFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelFilters.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.PanelFilters.Location = new System.Drawing.Point(0, 0);
            this.PanelFilters.Name = "PanelFilters";
            this.PanelFilters.Size = new System.Drawing.Size(1008, 114);
            // 
            // 
            // 
            this.PanelFilters.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarCaptionInactiveBackground2;
            this.PanelFilters.Style.BackColorGradientAngle = 180;
            this.PanelFilters.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.DockSiteBackColor;
            this.PanelFilters.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelFilters.Style.BorderBottomWidth = 1;
            this.PanelFilters.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.PanelFilters.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelFilters.Style.BorderLeftWidth = 1;
            this.PanelFilters.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelFilters.Style.BorderRightWidth = 1;
            this.PanelFilters.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelFilters.Style.BorderTopWidth = 1;
            this.PanelFilters.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.PanelFilters.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.PanelFilters.TabIndex = 0;
            // 
            // btnPrint
            // 
            this.btnPrint.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnPrint.Image = global::Sepehr.Forms.Cash.Properties.Resources.PrintGrid;
            this.btnPrint.Location = new System.Drawing.Point(564, 59);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(81, 48);
            this.btnPrint.TabIndex = 13;
            this.btnPrint.TabStop = false;
            this.btnPrint.Text = "چاپ جدول";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnRefresh.Image = global::Sepehr.Forms.Cash.Properties.Resources.Refresh;
            this.btnRefresh.Location = new System.Drawing.Point(564, 7);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F5);
            this.btnRefresh.Size = new System.Drawing.Size(81, 48);
            this.btnRefresh.TabIndex = 12;
            this.btnRefresh.TabStop = false;
            this.btnRefresh.Text = "بازخوانی (F5)";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // ToDate
            // 
            this.ToDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ToDate.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ToDate.IsAllowNullDate = false;
            this.ToDate.IsPopupOpen = false;
            this.ToDate.Location = new System.Drawing.Point(651, 59);
            this.ToDate.Name = "ToDate";
            this.ToDate.SelectedDateTime = new System.DateTime(2009, 7, 9, 18, 10, 43, 0);
            this.ToDate.Size = new System.Drawing.Size(98, 21);
            this.ToDate.TabIndex = 9;
            // 
            // ToTime
            // 
            this.ToTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.ToTime.BackgroundStyle.Class = "DateTimeInputBackground";
            this.ToTime.CustomFormat = "HH:mm:ss";
            this.ToTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ToTime.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.ToTime.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.ToTime.Location = new System.Drawing.Point(651, 86);
            // 
            // 
            // 
            this.ToTime.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.ToTime.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.ToTime.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.ToTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.ToTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.ToTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.ToTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.ToTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.ToTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.ToTime.MonthCalendar.DisplayMonth = new System.DateTime(2008, 10, 1, 0, 0, 0, 0);
            this.ToTime.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Saturday;
            this.ToTime.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.ToTime.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.ToTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.ToTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.ToTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.ToTime.MonthCalendar.TodayButtonVisible = true;
            this.ToTime.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.ToTime.Name = "ToTime";
            this.ToTime.ShowUpDown = true;
            this.ToTime.Size = new System.Drawing.Size(98, 21);
            this.ToTime.TabIndex = 11;
            this.ToTime.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            // 
            // FromTime
            // 
            this.FromTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.FromTime.BackgroundStyle.Class = "DateTimeInputBackground";
            this.FromTime.CustomFormat = "HH:mm:ss";
            this.FromTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FromTime.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.FromTime.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.FromTime.Location = new System.Drawing.Point(826, 86);
            // 
            // 
            // 
            this.FromTime.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.FromTime.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.FromTime.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.FromTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.FromTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.FromTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.FromTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.FromTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.FromTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.FromTime.MonthCalendar.DisplayMonth = new System.DateTime(2008, 10, 1, 0, 0, 0, 0);
            this.FromTime.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Saturday;
            this.FromTime.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.FromTime.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.FromTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.FromTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.FromTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.FromTime.MonthCalendar.TodayButtonVisible = true;
            this.FromTime.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.FromTime.Name = "FromTime";
            this.FromTime.ShowUpDown = true;
            this.FromTime.Size = new System.Drawing.Size(98, 21);
            this.FromTime.TabIndex = 7;
            this.FromTime.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            // 
            // lblFromDate
            // 
            this.lblFromDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.BackColor = System.Drawing.Color.Transparent;
            this.lblFromDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblFromDate.ForeColor = System.Drawing.Color.Navy;
            this.lblFromDate.Location = new System.Drawing.Point(930, 61);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(66, 16);
            this.lblFromDate.TabIndex = 4;
            this.lblFromDate.Text = "از تاریخ آغاز:";
            this.lblFromDate.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblFromTime
            // 
            this.lblFromTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFromTime.AutoSize = true;
            this.lblFromTime.BackColor = System.Drawing.Color.Transparent;
            this.lblFromTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblFromTime.ForeColor = System.Drawing.Color.Navy;
            this.lblFromTime.Location = new System.Drawing.Point(930, 88);
            this.lblFromTime.Name = "lblFromTime";
            this.lblFromTime.Size = new System.Drawing.Size(53, 16);
            this.lblFromTime.TabIndex = 6;
            this.lblFromTime.Text = "از ساعت:";
            this.lblFromTime.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblToDate
            // 
            this.lblToDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblToDate.AutoSize = true;
            this.lblToDate.BackColor = System.Drawing.Color.Transparent;
            this.lblToDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblToDate.ForeColor = System.Drawing.Color.Navy;
            this.lblToDate.Location = new System.Drawing.Point(756, 61);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(65, 16);
            this.lblToDate.TabIndex = 8;
            this.lblToDate.Text = "تا تاریخ آغاز:";
            this.lblToDate.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblToTime
            // 
            this.lblToTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblToTime.AutoSize = true;
            this.lblToTime.BackColor = System.Drawing.Color.Transparent;
            this.lblToTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblToTime.ForeColor = System.Drawing.Color.Navy;
            this.lblToTime.Location = new System.Drawing.Point(756, 88);
            this.lblToTime.Name = "lblToTime";
            this.lblToTime.Size = new System.Drawing.Size(52, 16);
            this.lblToTime.TabIndex = 10;
            this.lblToTime.Text = "تا ساعت:";
            this.lblToTime.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblCashier
            // 
            this.lblCashier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCashier.AutoSize = true;
            this.lblCashier.BackColor = System.Drawing.Color.Transparent;
            this.lblCashier.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblCashier.ForeColor = System.Drawing.Color.Navy;
            this.lblCashier.Location = new System.Drawing.Point(930, 36);
            this.lblCashier.Name = "lblCashier";
            this.lblCashier.Size = new System.Drawing.Size(66, 16);
            this.lblCashier.TabIndex = 2;
            this.lblCashier.Text = "صندوقداران:";
            this.lblCashier.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblCash
            // 
            this.lblCash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCash.AutoSize = true;
            this.lblCash.BackColor = System.Drawing.Color.Transparent;
            this.lblCash.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblCash.ForeColor = System.Drawing.Color.Navy;
            this.lblCash.Location = new System.Drawing.Point(930, 10);
            this.lblCash.Name = "lblCash";
            this.lblCash.Size = new System.Drawing.Size(60, 16);
            this.lblCash.TabIndex = 1;
            this.lblCash.Text = "صندوق ها:";
            this.lblCash.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // cboCashier
            // 
            this.cboCashier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCashier.DisplayMember = "FullName";
            this.cboCashier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCashier.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.cboCashier.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cboCashier.FormattingEnabled = true;
            this.cboCashier.ItemHeight = 13;
            this.cboCashier.Location = new System.Drawing.Point(651, 34);
            this.cboCashier.Name = "cboCashier";
            this.cboCashier.Size = new System.Drawing.Size(273, 21);
            this.cboCashier.TabIndex = 3;
            this.cboCashier.ValueMember = "ID";
            this.cboCashier.WatermarkText = "نام صندوقدار";
            // 
            // cboCash
            // 
            this.cboCash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCash.DisplayMember = "Name";
            this.cboCash.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCash.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.cboCash.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cboCash.FormattingEnabled = true;
            this.cboCash.ItemHeight = 13;
            this.cboCash.Location = new System.Drawing.Point(651, 8);
            this.cboCash.Name = "cboCash";
            this.cboCash.Size = new System.Drawing.Size(273, 21);
            this.cboCash.TabIndex = 0;
            this.cboCash.ValueMember = "ID";
            this.cboCash.WatermarkText = "نام صندوق";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(0, -50);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "بستن";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToOrderColumns = true;
            this.dgvData.AllowUserToResizeRows = false;
            this.dgvData.BackgroundColor = System.Drawing.Color.PowderBlue;
            this.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.ColumnHeadersHeight = 40;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColRowNumber,
            this.Column2,
            this.ColCashStatus,
            this.Column3,
            this.Column4,
            this.ColSupplyBegin,
            this.ColStatutorySypply,
            this.ColSupplyEnd,
            this.ColRemainValue,
            this.Column9,
            this.ColEndCashier,
            this.Column5});
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle14;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvData.Location = new System.Drawing.Point(0, 114);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvData.RowTemplate.Height = 30;
            this.dgvData.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvData.Size = new System.Drawing.Size(1008, 618);
            this.dgvData.StandardTab = true;
            this.dgvData.TabIndex = 1;
            this.dgvData.TabStop = false;
            this.dgvData.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvData_CellMouseClick);
            this.dgvData.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvData_CellFormatting);
            // 
            // ColRowNumber
            // 
            this.ColRowNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ColRowNumber.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColRowNumber.HeaderText = "ردیف";
            this.ColRowNumber.MaxInputLength = 5;
            this.ColRowNumber.Name = "ColRowNumber";
            this.ColRowNumber.ReadOnly = true;
            this.ColRowNumber.Width = 40;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "CashName";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Column2.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column2.HeaderText = "صندوق";
            this.Column2.MaxInputLength = 50;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 140;
            // 
            // ColCashStatus
            // 
            this.ColCashStatus.DataPropertyName = "CashStatus";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ColCashStatus.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColCashStatus.HeaderText = "وضعیت";
            this.ColCashStatus.MaxInputLength = 50;
            this.ColCashStatus.Name = "ColCashStatus";
            this.ColCashStatus.ReadOnly = true;
            this.ColCashStatus.Width = 60;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "OpenerCashierName";
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Column3.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column3.HeaderText = "صندوقدار باز كننده";
            this.Column3.MaxInputLength = 50;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 140;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "StartDateTime";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Column4.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column4.HeaderText = "زمان آغاز";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column4.ShowTime = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column4.Width = 150;
            // 
            // ColSupplyBegin
            // 
            this.ColSupplyBegin.DataPropertyName = "SupplyBegin";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Green;
            dataGridViewCellStyle7.Format = "N0";
            dataGridViewCellStyle7.NullValue = "0";
            this.ColSupplyBegin.DefaultCellStyle = dataGridViewCellStyle7;
            this.ColSupplyBegin.HeaderText = "موجودی اول";
            this.ColSupplyBegin.MaxInputLength = 50;
            this.ColSupplyBegin.Name = "ColSupplyBegin";
            this.ColSupplyBegin.ReadOnly = true;
            this.ColSupplyBegin.Width = 90;
            // 
            // ColStatutorySypply
            // 
            this.ColStatutorySypply.DataPropertyName = "StatutorySypply";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.Format = "N0";
            dataGridViewCellStyle8.NullValue = "0";
            this.ColStatutorySypply.DefaultCellStyle = dataGridViewCellStyle8;
            this.ColStatutorySypply.HeaderText = "موجودی مقرر";
            this.ColStatutorySypply.MaxInputLength = 50;
            this.ColStatutorySypply.Name = "ColStatutorySypply";
            this.ColStatutorySypply.ReadOnly = true;
            this.ColStatutorySypply.Width = 90;
            // 
            // ColSupplyEnd
            // 
            this.ColSupplyEnd.DataPropertyName = "SupplyEnd";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle9.Format = "N0";
            dataGridViewCellStyle9.NullValue = "0";
            this.ColSupplyEnd.DefaultCellStyle = dataGridViewCellStyle9;
            this.ColSupplyEnd.HeaderText = "موجودی آخر";
            this.ColSupplyEnd.MaxInputLength = 50;
            this.ColSupplyEnd.Name = "ColSupplyEnd";
            this.ColSupplyEnd.ReadOnly = true;
            this.ColSupplyEnd.Width = 90;
            // 
            // ColRemainValue
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Red;
            this.ColRemainValue.DefaultCellStyle = dataGridViewCellStyle10;
            this.ColRemainValue.HeaderText = "كسر آخر";
            this.ColRemainValue.Name = "ColRemainValue";
            this.ColRemainValue.ReadOnly = true;
            this.ColRemainValue.Width = 90;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "InputsOutputsBalance";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle11.Format = "N0";
            dataGridViewCellStyle11.NullValue = "0";
            this.Column9.DefaultCellStyle = dataGridViewCellStyle11;
            this.Column9.HeaderText = "تراز ورود و خروج";
            this.Column9.MaxInputLength = 50;
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 70;
            // 
            // ColEndCashier
            // 
            this.ColEndCashier.DataPropertyName = "CloserCashierName";
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColEndCashier.DefaultCellStyle = dataGridViewCellStyle12;
            this.ColEndCashier.HeaderText = "صندوقدار اتمام دهنده";
            this.ColEndCashier.MaxInputLength = 50;
            this.ColEndCashier.Name = "ColEndCashier";
            this.ColEndCashier.ReadOnly = true;
            this.ColEndCashier.Width = 140;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "FinishDateTime";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Column5.DefaultCellStyle = dataGridViewCellStyle13;
            this.Column5.HeaderText = "زمان پایان";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column5.ShowTime = true;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column5.Width = 150;
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            // 
            // cmsPatients
            // 
            this.cmsPatients.CanCustomize = false;
            this.cmsPatients.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmsPatients.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.cmsdgvData});
            this.cmsPatients.Location = new System.Drawing.Point(853, 163);
            this.cmsPatients.Name = "cmsPatients";
            this.cmsPatients.Size = new System.Drawing.Size(142, 25);
            this.cmsPatients.Stretch = true;
            this.cmsPatients.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.cmsPatients.TabIndex = 6655;
            this.cmsPatients.TabStop = false;
            // 
            // cmsdgvData
            // 
            this.cmsdgvData.AutoExpandOnClick = true;
            this.cmsdgvData.ImagePaddingHorizontal = 8;
            this.cmsdgvData.Name = "cmsdgvData";
            this.cmsdgvData.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnCashInOutReport});
            this.cmsdgvData.Text = "منوی گزارش صندوق ها";
            // 
            // btnCashInOutReport
            // 
            this.btnCashInOutReport.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnCashInOutReport.FontBold = true;
            this.btnCashInOutReport.Image = global::Sepehr.Forms.Cash.Properties.Resources.CashReport;
            this.btnCashInOutReport.ImagePaddingHorizontal = 8;
            this.btnCashInOutReport.Name = "btnCashInOutReport";
            this.btnCashInOutReport.Text = "گزارش ورود\r\nو خروج پول";
            this.btnCashInOutReport.Click += new System.EventHandler(this.btnCashInOutReport_Click);
            // 
            // frmCashesReport
            // 
            this.AcceptButton = this.btnRefresh;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1008, 732);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cmsPatients);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.PanelFilters);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmCashesReport";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "صندوق - گزارش وضعیت صندوق ها";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.PanelFilters.ResumeLayout(false);
            this.PanelFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmsPatients)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel PanelFilters;
        private DevComponents.DotNetBar.ButtonX btnPrint;
        private DevComponents.DotNetBar.ButtonX btnRefresh;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput ToTime;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput FromTime;
        private DevComponents.DotNetBar.LabelX lblFromDate;
        private DevComponents.DotNetBar.LabelX lblFromTime;
        private DevComponents.DotNetBar.LabelX lblToDate;
        private DevComponents.DotNetBar.LabelX lblToTime;
        private DevComponents.DotNetBar.LabelX lblCashier;
        private DevComponents.DotNetBar.LabelX lblCash;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboCashier;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboCash;
        private System.Windows.Forms.DataGridView dgvData;
        private Negar.PersianCalendar.UI.Controls.PersianDatePicker ToDate;
        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        private Negar.PersianCalendar.UI.Controls.PersianDatePicker FromDate;
        private DevComponents.DotNetBar.ContextMenuBar cmsPatients;
        private DevComponents.DotNetBar.ButtonItem cmsdgvData;
        private DevComponents.DotNetBar.ButtonItem btnCashInOutReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRowNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCashStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private Negar.PersianCalendar.UI.Controls.DataGridViewPersianDateTimePickerColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSupplyBegin;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStatutorySypply;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSupplyEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRemainValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColEndCashier;
        private Negar.PersianCalendar.UI.Controls.DataGridViewPersianDateTimePickerColumn Column5;
        private System.Windows.Forms.Button btnClose;

    }
}