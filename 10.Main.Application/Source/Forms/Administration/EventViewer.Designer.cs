namespace Sepehr.Forms.Administration
{
    partial class frmEventViewer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEventViewer));
            this.PanelForm = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.btnReport = new DevComponents.DotNetBar.ButtonX();
            this.dgvData = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.PanelDate = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.ToDate = new Negar.PersianCalendar.UI.Controls.PersianDatePicker();
            this.FromDate = new Negar.PersianCalendar.UI.Controls.PersianDatePicker();
            this.ToTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.FromTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.lblETime1 = new DevComponents.DotNetBar.LabelX();
            this.lblSTime1 = new DevComponents.DotNetBar.LabelX();
            this.lblEDate1 = new DevComponents.DotNetBar.LabelX();
            this.lblSDate1 = new DevComponents.DotNetBar.LabelX();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblApp = new System.Windows.Forms.Label();
            this.cboApp = new System.Windows.Forms.ComboBox();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.cboUser = new System.Windows.Forms.ComboBox();
            this.btnHelp = new DevComponents.DotNetBar.ButtonX();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAppName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDate = new Negar.PersianCalendar.UI.Controls.DataGridViewPersianDateTimePickerColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PanelForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.PanelDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromTime)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelForm
            // 
            this.PanelForm.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelForm.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelForm.Controls.Add(this.btnReport);
            this.PanelForm.Controls.Add(this.dgvData);
            this.PanelForm.Controls.Add(this.PanelDate);
            this.PanelForm.Controls.Add(this.lblCategory);
            this.PanelForm.Controls.Add(this.lblUser);
            this.PanelForm.Controls.Add(this.lblApp);
            this.PanelForm.Controls.Add(this.cboApp);
            this.PanelForm.Controls.Add(this.cboCategory);
            this.PanelForm.Controls.Add(this.cboUser);
            this.PanelForm.Controls.Add(this.btnHelp);
            this.PanelForm.Controls.Add(this.btnClose);
            this.PanelForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelForm.Location = new System.Drawing.Point(0, 0);
            this.PanelForm.Name = "PanelForm";
            this.PanelForm.Size = new System.Drawing.Size(884, 570);
            // 
            // 
            // 
            this.PanelForm.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.PanelForm.Style.BackColorGradientAngle = 90;
            this.PanelForm.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.PanelForm.Style.BorderBottomWidth = 1;
            this.PanelForm.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.PanelForm.Style.BorderLeftWidth = 1;
            this.PanelForm.Style.BorderRightWidth = 1;
            this.PanelForm.Style.BorderTopWidth = 1;
            this.PanelForm.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.PanelForm.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.PanelForm.TabIndex = 0;
            // 
            // btnReport
            // 
            this.btnReport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReport.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnReport.Image = global::Sepehr.Properties.Resources.Accept;
            this.btnReport.Location = new System.Drawing.Point(136, 15);
            this.btnReport.Name = "btnReport";
            this.btnReport.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnReport.Size = new System.Drawing.Size(95, 66);
            this.btnReport.TabIndex = 7;
            this.btnReport.Text = "گزارش\r\n(F8)";
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToOrderColumns = true;
            this.dgvData.AllowUserToResizeColumns = false;
            this.dgvData.AllowUserToResizeRows = false;
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvData.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1,
            this.ColAppName,
            this.ColUserName,
            this.ColFullName,
            this.ColCategory,
            this.ColDate,
            this.dataGridViewTextBoxColumn2});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvData.Location = new System.Drawing.Point(12, 91);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(859, 401);
            this.dgvData.TabIndex = 8;
            // 
            // PanelDate
            // 
            this.PanelDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelDate.BackColor = System.Drawing.Color.Transparent;
            this.PanelDate.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelDate.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelDate.Controls.Add(this.ToDate);
            this.PanelDate.Controls.Add(this.FromDate);
            this.PanelDate.Controls.Add(this.ToTime);
            this.PanelDate.Controls.Add(this.FromTime);
            this.PanelDate.Controls.Add(this.lblETime1);
            this.PanelDate.Controls.Add(this.lblSTime1);
            this.PanelDate.Controls.Add(this.lblEDate1);
            this.PanelDate.Controls.Add(this.lblSDate1);
            this.PanelDate.DrawTitleBox = false;
            this.PanelDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.PanelDate.Location = new System.Drawing.Point(237, 6);
            this.PanelDate.Name = "PanelDate";
            this.PanelDate.Size = new System.Drawing.Size(294, 75);
            // 
            // 
            // 
            this.PanelDate.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.PanelDate.Style.BackColorGradientAngle = 90;
            this.PanelDate.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.PanelDate.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelDate.Style.BorderBottomWidth = 1;
            this.PanelDate.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.PanelDate.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelDate.Style.BorderLeftWidth = 1;
            this.PanelDate.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelDate.Style.BorderRightWidth = 1;
            this.PanelDate.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelDate.Style.BorderTopWidth = 1;
            this.PanelDate.Style.CornerDiameter = 4;
            this.PanelDate.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.PanelDate.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.PanelDate.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.PanelDate.TabIndex = 6;
            this.PanelDate.Text = "بازه ی رخداد";
            // 
            // ToDate
            // 
            this.ToDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ToDate.IsPopupOpen = false;
            this.ToDate.Location = new System.Drawing.Point(154, 31);
            this.ToDate.Name = "ToDate";
            this.ToDate.SelectedDateTime = new System.DateTime(2009, 7, 16, 10, 41, 0, 0);
            this.ToDate.Size = new System.Drawing.Size(84, 20);
            this.ToDate.TabIndex = 5;
            // 
            // FromDate
            // 
            this.FromDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FromDate.IsPopupOpen = false;
            this.FromDate.Location = new System.Drawing.Point(154, 4);
            this.FromDate.Name = "FromDate";
            this.FromDate.SelectedDateTime = new System.DateTime(2009, 7, 16, 10, 41, 0, 0);
            this.FromDate.Size = new System.Drawing.Size(84, 20);
            this.FromDate.TabIndex = 1;
            // 
            // ToTime
            // 
            this.ToTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.ToTime.BackgroundStyle.Class = "DateTimeInputBackground";
            this.ToTime.CustomFormat = "HH:mm:ss";
            this.ToTime.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.ToTime.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.ToTime.Location = new System.Drawing.Point(7, 31);
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
            this.ToTime.Size = new System.Drawing.Size(83, 21);
            this.ToTime.TabIndex = 7;
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
            this.FromTime.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.FromTime.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.FromTime.Location = new System.Drawing.Point(7, 4);
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
            this.FromTime.Size = new System.Drawing.Size(83, 21);
            this.FromTime.TabIndex = 3;
            this.FromTime.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            // 
            // lblETime1
            // 
            this.lblETime1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblETime1.AutoSize = true;
            this.lblETime1.BackColor = System.Drawing.Color.Transparent;
            this.lblETime1.Location = new System.Drawing.Point(95, 33);
            this.lblETime1.Name = "lblETime1";
            this.lblETime1.Size = new System.Drawing.Size(52, 16);
            this.lblETime1.TabIndex = 6;
            this.lblETime1.Text = "تا ساعت:";
            this.lblETime1.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblSTime1
            // 
            this.lblSTime1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSTime1.AutoSize = true;
            this.lblSTime1.BackColor = System.Drawing.Color.Transparent;
            this.lblSTime1.Location = new System.Drawing.Point(95, 6);
            this.lblSTime1.Name = "lblSTime1";
            this.lblSTime1.Size = new System.Drawing.Size(53, 16);
            this.lblSTime1.TabIndex = 2;
            this.lblSTime1.Text = "از ساعت:";
            this.lblSTime1.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblEDate1
            // 
            this.lblEDate1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEDate1.AutoSize = true;
            this.lblEDate1.BackColor = System.Drawing.Color.Transparent;
            this.lblEDate1.Location = new System.Drawing.Point(242, 33);
            this.lblEDate1.Name = "lblEDate1";
            this.lblEDate1.Size = new System.Drawing.Size(42, 16);
            this.lblEDate1.TabIndex = 4;
            this.lblEDate1.Text = "تا تاریخ:";
            this.lblEDate1.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblSDate1
            // 
            this.lblSDate1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSDate1.AutoSize = true;
            this.lblSDate1.BackColor = System.Drawing.Color.Transparent;
            this.lblSDate1.Location = new System.Drawing.Point(242, 6);
            this.lblSDate1.Name = "lblSDate1";
            this.lblSDate1.Size = new System.Drawing.Size(43, 16);
            this.lblSDate1.TabIndex = 0;
            this.lblSDate1.Text = "از تاریخ:";
            this.lblSDate1.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblCategory
            // 
            this.lblCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCategory.AutoSize = true;
            this.lblCategory.BackColor = System.Drawing.Color.Transparent;
            this.lblCategory.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblCategory.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblCategory.Location = new System.Drawing.Point(816, 41);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(64, 13);
            this.lblCategory.TabIndex = 3;
            this.lblCategory.Text = "طبقه بندی:";
            // 
            // lblUser
            // 
            this.lblUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUser.AutoSize = true;
            this.lblUser.BackColor = System.Drawing.Color.Transparent;
            this.lblUser.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblUser.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblUser.Location = new System.Drawing.Point(816, 68);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(35, 13);
            this.lblUser.TabIndex = 5;
            this.lblUser.Text = "كاربر:";
            // 
            // lblApp
            // 
            this.lblApp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblApp.AutoSize = true;
            this.lblApp.BackColor = System.Drawing.Color.Transparent;
            this.lblApp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblApp.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblApp.Location = new System.Drawing.Point(816, 15);
            this.lblApp.Name = "lblApp";
            this.lblApp.Size = new System.Drawing.Size(42, 13);
            this.lblApp.TabIndex = 1;
            this.lblApp.Text = "برنامه:";
            // 
            // cboApp
            // 
            this.cboApp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboApp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboApp.FormattingEnabled = true;
            this.cboApp.Location = new System.Drawing.Point(537, 11);
            this.cboApp.Name = "cboApp";
            this.cboApp.Size = new System.Drawing.Size(274, 21);
            this.cboApp.TabIndex = 0;
            // 
            // cboCategory
            // 
            this.cboCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(537, 37);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(274, 21);
            this.cboCategory.TabIndex = 2;
            // 
            // cboUser
            // 
            this.cboUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUser.FormattingEnabled = true;
            this.cboUser.Location = new System.Drawing.Point(537, 64);
            this.cboUser.Name = "cboUser";
            this.cboUser.Size = new System.Drawing.Size(274, 21);
            this.cboUser.TabIndex = 4;
            // 
            // btnHelp
            // 
            this.btnHelp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnHelp.Image = global::Sepehr.Properties.Resources.Help;
            this.btnHelp.Location = new System.Drawing.Point(777, 498);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F1);
            this.btnHelp.Size = new System.Drawing.Size(95, 60);
            this.btnHelp.TabIndex = 10;
            this.btnHelp.TabStop = false;
            this.btnHelp.Text = "راهنما\r\n(F1)";
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = global::Sepehr.Properties.Resources.Cancel;
            this.btnClose.Location = new System.Drawing.Point(12, 498);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 60);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "خروج\r\n(Esc)";
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "RowNumber";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.dataGridViewCheckBoxColumn1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewCheckBoxColumn1.HeaderText = "ردیف";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewCheckBoxColumn1.Width = 40;
            // 
            // ColAppName
            // 
            this.ColAppName.DataPropertyName = "ApplicationName";
            this.ColAppName.HeaderText = "نام برنامه";
            this.ColAppName.Name = "ColAppName";
            this.ColAppName.ReadOnly = true;
            this.ColAppName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColAppName.Width = 160;
            // 
            // ColUserName
            // 
            this.ColUserName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ColUserName.DataPropertyName = "UserName";
            this.ColUserName.HeaderText = "نام كاربری";
            this.ColUserName.Name = "ColUserName";
            this.ColUserName.ReadOnly = true;
            this.ColUserName.Width = 78;
            // 
            // ColFullName
            // 
            this.ColFullName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ColFullName.DataPropertyName = "FullName";
            this.ColFullName.HeaderText = "نام كاربر";
            this.ColFullName.Name = "ColFullName";
            this.ColFullName.ReadOnly = true;
            this.ColFullName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColFullName.Width = 68;
            // 
            // ColCategory
            // 
            this.ColCategory.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ColCategory.DataPropertyName = "CategoryName";
            this.ColCategory.HeaderText = "طبقه بندی";
            this.ColCategory.Name = "ColCategory";
            this.ColCategory.ReadOnly = true;
            this.ColCategory.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColCategory.Width = 81;
            // 
            // ColDate
            // 
            this.ColDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ColDate.DataPropertyName = "Date";
            this.ColDate.HeaderText = "زمان رخداد";
            this.ColDate.Name = "ColDate";
            this.ColDate.ReadOnly = true;
            this.ColDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColDate.ShowTime = true;
            this.ColDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColDate.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Description";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn2.HeaderText = "شرح";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // frmEventViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(884, 570);
            this.Controls.Add(this.PanelForm);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmEventViewer";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "سیستم مدیریت تصویربرداری سپهر - نمایش رخداد های سیستم";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.PanelForm.ResumeLayout(false);
            this.PanelForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.PanelDate.ResumeLayout(false);
            this.PanelDate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel PanelForm;
        private DevComponents.DotNetBar.ButtonX btnHelp;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        private System.Windows.Forms.ComboBox cboUser;
        private System.Windows.Forms.Label lblApp;
        private System.Windows.Forms.ComboBox cboApp;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.ComboBox cboCategory;
        private DevComponents.DotNetBar.Controls.GroupPanel PanelDate;
        private Negar.PersianCalendar.UI.Controls.PersianDatePicker ToDate;
        private Negar.PersianCalendar.UI.Controls.PersianDatePicker FromDate;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput ToTime;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput FromTime;
        private DevComponents.DotNetBar.LabelX lblETime1;
        private DevComponents.DotNetBar.LabelX lblSTime1;
        private DevComponents.DotNetBar.LabelX lblEDate1;
        private DevComponents.DotNetBar.LabelX lblSDate1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvData;
        private DevComponents.DotNetBar.ButtonX btnReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAppName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCategory;
        private Negar.PersianCalendar.UI.Controls.DataGridViewPersianDateTimePickerColumn ColDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}