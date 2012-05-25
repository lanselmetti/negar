namespace Sepehr.Forms.Reports.General.Report15
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFilter));
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.lblTransType = new DevComponents.DotNetBar.LabelX();
            this.cBoxFilterCashiers = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.dgvCashier = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ColSelection = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColCashier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PanelTransDateTimeFilter = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.ToDateTrans = new Negar.PersianCalendar.UI.Controls.PersianDatePicker();
            this.FromDateTrans = new Negar.PersianCalendar.UI.Controls.PersianDatePicker();
            this.ToTimeTrans = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.FromTimeTrans = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.lblToTransTime = new DevComponents.DotNetBar.LabelX();
            this.lblFromTransTime = new DevComponents.DotNetBar.LabelX();
            this.lblToTransDate = new DevComponents.DotNetBar.LabelX();
            this.lblFromTransDate = new DevComponents.DotNetBar.LabelX();
            this.cBox2 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cBox1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.FormPanel = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.cBoxTransDate = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cBoxRefDateFilter = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.btnHelp = new DevComponents.DotNetBar.ButtonX();
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
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnReport = new DevComponents.DotNetBar.ButtonX();
            this.BGWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCashier)).BeginInit();
            this.PanelTransDateTimeFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToTimeTrans)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromTimeTrans)).BeginInit();
            this.FormPanel.SuspendLayout();
            this.PanelRefDateTimeFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToTimeRef)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromTimeRef)).BeginInit();
            this.SuspendLayout();
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            // 
            // lblTransType
            // 
            this.lblTransType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTransType.AutoSize = true;
            this.lblTransType.BackColor = System.Drawing.Color.Transparent;
            this.lblTransType.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTransType.ForeColor = System.Drawing.Color.DarkMagenta;
            this.lblTransType.Location = new System.Drawing.Point(244, 10);
            this.lblTransType.Name = "lblTransType";
            this.lblTransType.Size = new System.Drawing.Size(72, 17);
            this.lblTransType.TabIndex = 7;
            this.lblTransType.Text = "نوع تراكنش:";
            this.lblTransType.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // cBoxFilterCashiers
            // 
            this.cBoxFilterCashiers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxFilterCashiers.AutoSize = true;
            this.cBoxFilterCashiers.BackColor = System.Drawing.Color.Transparent;
            this.cBoxFilterCashiers.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxFilterCashiers.Location = new System.Drawing.Point(97, 204);
            this.cBoxFilterCashiers.Name = "cBoxFilterCashiers";
            this.cBoxFilterCashiers.Size = new System.Drawing.Size(221, 16);
            this.cBoxFilterCashiers.TabIndex = 2;
            this.cBoxFilterCashiers.Text = "كاربران صندوق دریافت یا پرداخت كننده ";
            this.cBoxFilterCashiers.TextColor = System.Drawing.Color.Purple;
            this.cBoxFilterCashiers.CheckedChanged += new System.EventHandler(this.cBoxFilterCashiers_CheckedChanged);
            // 
            // dgvCashier
            // 
            this.dgvCashier.AllowUserToAddRows = false;
            this.dgvCashier.AllowUserToDeleteRows = false;
            this.dgvCashier.AllowUserToOrderColumns = true;
            this.dgvCashier.AllowUserToResizeColumns = false;
            this.dgvCashier.AllowUserToResizeRows = false;
            this.dgvCashier.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCashier.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dgvCashier.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCashier.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCashier.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCashier.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColSelection,
            this.ColCashier});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCashier.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCashier.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvCashier.Location = new System.Drawing.Point(14, 226);
            this.dgvCashier.MultiSelect = false;
            this.dgvCashier.Name = "dgvCashier";
            this.dgvCashier.RowHeadersVisible = false;
            this.dgvCashier.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCashier.Size = new System.Drawing.Size(303, 190);
            this.dgvCashier.TabIndex = 3;
            // 
            // ColSelection
            // 
            this.ColSelection.HeaderText = "اضافه";
            this.ColSelection.Name = "ColSelection";
            this.ColSelection.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColSelection.Width = 40;
            // 
            // ColCashier
            // 
            this.ColCashier.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColCashier.DataPropertyName = "FullName";
            this.ColCashier.HeaderText = "نام صندوقداران";
            this.ColCashier.Name = "ColCashier";
            this.ColCashier.ReadOnly = true;
            // 
            // PanelTransDateTimeFilter
            // 
            this.PanelTransDateTimeFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelTransDateTimeFilter.BackColor = System.Drawing.Color.Transparent;
            this.PanelTransDateTimeFilter.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelTransDateTimeFilter.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelTransDateTimeFilter.Controls.Add(this.ToDateTrans);
            this.PanelTransDateTimeFilter.Controls.Add(this.FromDateTrans);
            this.PanelTransDateTimeFilter.Controls.Add(this.ToTimeTrans);
            this.PanelTransDateTimeFilter.Controls.Add(this.FromTimeTrans);
            this.PanelTransDateTimeFilter.Controls.Add(this.lblToTransTime);
            this.PanelTransDateTimeFilter.Controls.Add(this.lblFromTransTime);
            this.PanelTransDateTimeFilter.Controls.Add(this.lblToTransDate);
            this.PanelTransDateTimeFilter.Controls.Add(this.lblFromTransDate);
            this.PanelTransDateTimeFilter.DrawTitleBox = false;
            this.PanelTransDateTimeFilter.Font = new System.Drawing.Font("Tahoma", 8.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.PanelTransDateTimeFilter.Location = new System.Drawing.Point(15, 38);
            this.PanelTransDateTimeFilter.Name = "PanelTransDateTimeFilter";
            this.PanelTransDateTimeFilter.Size = new System.Drawing.Size(302, 75);
            // 
            // 
            // 
            this.PanelTransDateTimeFilter.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.PanelTransDateTimeFilter.Style.BackColorGradientAngle = 90;
            this.PanelTransDateTimeFilter.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.PanelTransDateTimeFilter.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelTransDateTimeFilter.Style.BorderBottomWidth = 1;
            this.PanelTransDateTimeFilter.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.PanelTransDateTimeFilter.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelTransDateTimeFilter.Style.BorderLeftWidth = 1;
            this.PanelTransDateTimeFilter.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelTransDateTimeFilter.Style.BorderRightWidth = 1;
            this.PanelTransDateTimeFilter.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelTransDateTimeFilter.Style.BorderTopWidth = 1;
            this.PanelTransDateTimeFilter.Style.CornerDiameter = 4;
            this.PanelTransDateTimeFilter.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.PanelTransDateTimeFilter.Style.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(0)))), ((int)(((byte)(132)))));
            this.PanelTransDateTimeFilter.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.PanelTransDateTimeFilter.TabIndex = 0;
            this.PanelTransDateTimeFilter.Text = "تاریخ دریافت یا بازپرداخت";
            // 
            // ToDateTrans
            // 
            this.ToDateTrans.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ToDateTrans.IsAllowNullDate = false;
            this.ToDateTrans.IsPopupOpen = false;
            this.ToDateTrans.Location = new System.Drawing.Point(158, 31);
            this.ToDateTrans.Name = "ToDateTrans";
            this.ToDateTrans.SelectedDateTime = new System.DateTime(2009, 7, 16, 10, 41, 0, 0);
            this.ToDateTrans.Size = new System.Drawing.Size(87, 20);
            this.ToDateTrans.TabIndex = 5;
            // 
            // FromDateTrans
            // 
            this.FromDateTrans.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FromDateTrans.IsAllowNullDate = false;
            this.FromDateTrans.IsPopupOpen = false;
            this.FromDateTrans.Location = new System.Drawing.Point(158, 4);
            this.FromDateTrans.Name = "FromDateTrans";
            this.FromDateTrans.SelectedDateTime = new System.DateTime(2009, 7, 16, 10, 41, 0, 0);
            this.FromDateTrans.Size = new System.Drawing.Size(87, 20);
            this.FromDateTrans.TabIndex = 0;
            // 
            // ToTimeTrans
            // 
            this.ToTimeTrans.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.ToTimeTrans.BackgroundStyle.Class = "DateTimeInputBackground";
            this.ToTimeTrans.CustomFormat = "HH:mm:ss";
            this.ToTimeTrans.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ToTimeTrans.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.ToTimeTrans.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.ToTimeTrans.Location = new System.Drawing.Point(7, 31);
            // 
            // 
            // 
            this.ToTimeTrans.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.ToTimeTrans.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.ToTimeTrans.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.ToTimeTrans.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.ToTimeTrans.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.ToTimeTrans.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.ToTimeTrans.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.ToTimeTrans.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.ToTimeTrans.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.ToTimeTrans.MonthCalendar.DisplayMonth = new System.DateTime(2008, 10, 1, 0, 0, 0, 0);
            this.ToTimeTrans.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Saturday;
            this.ToTimeTrans.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.ToTimeTrans.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.ToTimeTrans.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.ToTimeTrans.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.ToTimeTrans.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.ToTimeTrans.MonthCalendar.TodayButtonVisible = true;
            this.ToTimeTrans.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.ToTimeTrans.Name = "ToTimeTrans";
            this.ToTimeTrans.ShowUpDown = true;
            this.ToTimeTrans.Size = new System.Drawing.Size(84, 21);
            this.ToTimeTrans.TabIndex = 7;
            this.ToTimeTrans.Value = new System.DateTime(2009, 12, 29, 23, 59, 59, 0);
            this.ToTimeTrans.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            // 
            // FromTimeTrans
            // 
            this.FromTimeTrans.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.FromTimeTrans.BackgroundStyle.Class = "DateTimeInputBackground";
            this.FromTimeTrans.CustomFormat = "HH:mm:ss";
            this.FromTimeTrans.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FromTimeTrans.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.FromTimeTrans.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.FromTimeTrans.Location = new System.Drawing.Point(7, 4);
            // 
            // 
            // 
            this.FromTimeTrans.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.FromTimeTrans.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.FromTimeTrans.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.FromTimeTrans.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.FromTimeTrans.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.FromTimeTrans.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.FromTimeTrans.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.FromTimeTrans.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.FromTimeTrans.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.FromTimeTrans.MonthCalendar.DisplayMonth = new System.DateTime(2008, 10, 1, 0, 0, 0, 0);
            this.FromTimeTrans.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Saturday;
            this.FromTimeTrans.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.FromTimeTrans.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.FromTimeTrans.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.FromTimeTrans.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.FromTimeTrans.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.FromTimeTrans.MonthCalendar.TodayButtonVisible = true;
            this.FromTimeTrans.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.FromTimeTrans.Name = "FromTimeTrans";
            this.FromTimeTrans.ShowUpDown = true;
            this.FromTimeTrans.Size = new System.Drawing.Size(84, 21);
            this.FromTimeTrans.TabIndex = 3;
            this.FromTimeTrans.Value = new System.DateTime(2009, 12, 29, 0, 0, 0, 0);
            this.FromTimeTrans.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            // 
            // lblToTransTime
            // 
            this.lblToTransTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblToTransTime.AutoSize = true;
            this.lblToTransTime.BackColor = System.Drawing.Color.Transparent;
            this.lblToTransTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblToTransTime.Location = new System.Drawing.Point(94, 33);
            this.lblToTransTime.Name = "lblToTransTime";
            this.lblToTransTime.Size = new System.Drawing.Size(52, 16);
            this.lblToTransTime.TabIndex = 6;
            this.lblToTransTime.Text = "تا ساعت:";
            this.lblToTransTime.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblFromTransTime
            // 
            this.lblFromTransTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFromTransTime.AutoSize = true;
            this.lblFromTransTime.BackColor = System.Drawing.Color.Transparent;
            this.lblFromTransTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblFromTransTime.Location = new System.Drawing.Point(94, 6);
            this.lblFromTransTime.Name = "lblFromTransTime";
            this.lblFromTransTime.Size = new System.Drawing.Size(53, 16);
            this.lblFromTransTime.TabIndex = 2;
            this.lblFromTransTime.Text = "از ساعت:";
            this.lblFromTransTime.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblToTransDate
            // 
            this.lblToTransDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblToTransDate.AutoSize = true;
            this.lblToTransDate.BackColor = System.Drawing.Color.Transparent;
            this.lblToTransDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblToTransDate.Location = new System.Drawing.Point(251, 33);
            this.lblToTransDate.Name = "lblToTransDate";
            this.lblToTransDate.Size = new System.Drawing.Size(42, 16);
            this.lblToTransDate.TabIndex = 4;
            this.lblToTransDate.Text = "تا تاریخ:";
            this.lblToTransDate.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblFromTransDate
            // 
            this.lblFromTransDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFromTransDate.AutoSize = true;
            this.lblFromTransDate.BackColor = System.Drawing.Color.Transparent;
            this.lblFromTransDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblFromTransDate.Location = new System.Drawing.Point(251, 6);
            this.lblFromTransDate.Name = "lblFromTransDate";
            this.lblFromTransDate.Size = new System.Drawing.Size(43, 16);
            this.lblFromTransDate.TabIndex = 1;
            this.lblFromTransDate.Text = "از تاریخ:";
            this.lblFromTransDate.TextAlignment = System.Drawing.StringAlignment.Far;
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
            this.cBox2.Location = new System.Drawing.Point(107, 10);
            this.cBox2.Name = "cBox2";
            this.cBox2.Size = new System.Drawing.Size(61, 16);
            this.cBox2.TabIndex = 9;
            this.cBox2.TabStop = false;
            this.cBox2.Text = "پرداخت";
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
            this.cBox1.Location = new System.Drawing.Point(181, 10);
            this.cBox1.Name = "cBox1";
            this.cBox1.Size = new System.Drawing.Size(58, 16);
            this.cBox1.TabIndex = 8;
            this.cBox1.TabStop = false;
            this.cBox1.Text = "دریافت";
            this.cBox1.CheckedChanged += new System.EventHandler(this.cBox1_CheckedChanged);
            // 
            // FormPanel
            // 
            this.FormPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.FormPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.FormPanel.Controls.Add(this.cBoxTransDate);
            this.FormPanel.Controls.Add(this.cBoxRefDateFilter);
            this.FormPanel.Controls.Add(this.cBoxFilterCashiers);
            this.FormPanel.Controls.Add(this.lblTransType);
            this.FormPanel.Controls.Add(this.cBox1);
            this.FormPanel.Controls.Add(this.cBox2);
            this.FormPanel.Controls.Add(this.dgvCashier);
            this.FormPanel.Controls.Add(this.btnHelp);
            this.FormPanel.Controls.Add(this.PanelRefDateTimeFilter);
            this.FormPanel.Controls.Add(this.PanelTransDateTimeFilter);
            this.FormPanel.Controls.Add(this.ProgressBar);
            this.FormPanel.Controls.Add(this.btnCancel);
            this.FormPanel.Controls.Add(this.btnReport);
            this.FormPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormPanel.Location = new System.Drawing.Point(0, 0);
            this.FormPanel.Name = "FormPanel";
            this.FormPanel.Size = new System.Drawing.Size(329, 524);
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
            // cBoxTransDate
            // 
            this.cBoxTransDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxTransDate.BackColor = System.Drawing.Color.Transparent;
            this.cBoxTransDate.Checked = true;
            this.cBoxTransDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBoxTransDate.CheckValue = "Y";
            this.cBoxTransDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxTransDate.Location = new System.Drawing.Point(297, 32);
            this.cBoxTransDate.Name = "cBoxTransDate";
            this.cBoxTransDate.Size = new System.Drawing.Size(20, 16);
            this.cBoxTransDate.TabIndex = 4;
            this.cBoxTransDate.TabStop = false;
            this.cBoxTransDate.CheckedChanged += new System.EventHandler(this.cBoxTransDate_CheckedChanged);
            // 
            // cBoxRefDateFilter
            // 
            this.cBoxRefDateFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxRefDateFilter.BackColor = System.Drawing.Color.Transparent;
            this.cBoxRefDateFilter.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxRefDateFilter.Location = new System.Drawing.Point(297, 117);
            this.cBoxRefDateFilter.Name = "cBoxRefDateFilter";
            this.cBoxRefDateFilter.Size = new System.Drawing.Size(20, 16);
            this.cBoxRefDateFilter.TabIndex = 4;
            this.cBoxRefDateFilter.TabStop = false;
            this.cBoxRefDateFilter.CheckedChanged += new System.EventHandler(this.cBoxRefDateFilter_CheckedChanged);
            // 
            // btnHelp
            // 
            this.btnHelp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnHelp.Image = global::Sepehr.Forms.Reports.Properties.Resources.Help;
            this.btnHelp.Location = new System.Drawing.Point(222, 451);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F1);
            this.btnHelp.Size = new System.Drawing.Size(95, 57);
            this.btnHelp.TabIndex = 6;
            this.btnHelp.TabStop = false;
            this.btnHelp.Text = "راهنما\r\n(F1)";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
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
            this.PanelRefDateTimeFilter.Location = new System.Drawing.Point(15, 123);
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
            this.PanelRefDateTimeFilter.TabIndex = 1;
            this.PanelRefDateTimeFilter.Text = "تاریخ مراجعه ی تراكنش ها";
            // 
            // ToDateRef
            // 
            this.ToDateRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ToDateRef.IsAllowNullDate = false;
            this.ToDateRef.IsPopupOpen = false;
            this.ToDateRef.Location = new System.Drawing.Point(158, 31);
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
            this.FromDateRef.Location = new System.Drawing.Point(158, 4);
            this.FromDateRef.Name = "FromDateRef";
            this.FromDateRef.SelectedDateTime = new System.DateTime(2009, 7, 16, 10, 41, 0, 0);
            this.FromDateRef.Size = new System.Drawing.Size(87, 20);
            this.FromDateRef.TabIndex = 0;
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
            this.ToTimeRef.Location = new System.Drawing.Point(7, 31);
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
            this.FromTimeRef.Location = new System.Drawing.Point(7, 4);
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
            this.lblToRefTime.Location = new System.Drawing.Point(94, 33);
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
            this.lblFromRefTime.Location = new System.Drawing.Point(94, 6);
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
            this.lblToRefDate.Location = new System.Drawing.Point(251, 33);
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
            this.lblFromRefDate.Location = new System.Drawing.Point(251, 6);
            this.lblFromRefDate.Name = "lblFromRefDate";
            this.lblFromRefDate.Size = new System.Drawing.Size(43, 16);
            this.lblFromRefDate.TabIndex = 1;
            this.lblFromRefDate.Text = "از تاریخ:";
            this.lblFromRefDate.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // ProgressBar
            // 
            this.ProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressBar.Location = new System.Drawing.Point(14, 420);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(302, 23);
            this.ProgressBar.TabIndex = 77;
            this.ProgressBar.TabStop = false;
            this.ProgressBar.Text = "در انتظار ایجاد گزارش";
            this.ProgressBar.TextVisible = true;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Sepehr.Forms.Reports.Properties.Resources.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(115, 451);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 57);
            this.btnCancel.TabIndex = 5;
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
            this.btnReport.Location = new System.Drawing.Point(14, 451);
            this.btnReport.Name = "btnReport";
            this.btnReport.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnReport.Size = new System.Drawing.Size(95, 57);
            this.btnReport.TabIndex = 4;
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
            this.ClientSize = new System.Drawing.Size(329, 524);
            this.Controls.Add(this.FormPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(335, 550);
            this.Name = "frmFilter";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "گزارش تراكنش ها با جزئیات";
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCashier)).EndInit();
            this.PanelTransDateTimeFilter.ResumeLayout(false);
            this.PanelTransDateTimeFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToTimeTrans)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromTimeTrans)).EndInit();
            this.FormPanel.ResumeLayout(false);
            this.FormPanel.PerformLayout();
            this.PanelRefDateTimeFilter.ResumeLayout(false);
            this.PanelRefDateTimeFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToTimeRef)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromTimeRef)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnHelp;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnReport;
        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        private DevComponents.DotNetBar.LabelX lblTransType;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxFilterCashiers;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvCashier;
        private DevComponents.DotNetBar.Controls.GroupPanel PanelTransDateTimeFilter;
        private Negar.PersianCalendar.UI.Controls.PersianDatePicker ToDateTrans;
        private Negar.PersianCalendar.UI.Controls.PersianDatePicker FromDateTrans;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput ToTimeTrans;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput FromTimeTrans;
        private DevComponents.DotNetBar.LabelX lblToTransTime;
        private DevComponents.DotNetBar.LabelX lblFromTransTime;
        private DevComponents.DotNetBar.LabelX lblToTransDate;
        private DevComponents.DotNetBar.LabelX lblFromTransDate;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBox2;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBox1;
        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel FormPanel;
        private DevComponents.DotNetBar.Controls.GroupPanel PanelRefDateTimeFilter;
        private Negar.PersianCalendar.UI.Controls.PersianDatePicker ToDateRef;
        private Negar.PersianCalendar.UI.Controls.PersianDatePicker FromDateRef;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput ToTimeRef;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput FromTimeRef;
        private DevComponents.DotNetBar.LabelX lblToRefTime;
        private DevComponents.DotNetBar.LabelX lblFromRefTime;
        private DevComponents.DotNetBar.LabelX lblToRefDate;
        private DevComponents.DotNetBar.LabelX lblFromRefDate;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxRefDateFilter;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxTransDate;
        private DevComponents.DotNetBar.Controls.ProgressBarX ProgressBar;
        private System.ComponentModel.BackgroundWorker BGWorker;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColSelection;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCashier;
    }
}