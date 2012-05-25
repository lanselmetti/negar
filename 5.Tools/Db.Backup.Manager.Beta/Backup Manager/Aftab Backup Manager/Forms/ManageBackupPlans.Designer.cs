namespace Aftab
{
    partial class frmManageBackupPlans
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageBackupPlans));
            this.PanelCostDiscount = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.lblTopic = new DevComponents.DotNetBar.LabelX();
            this.cBoxIsActive = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.lblAppName = new DevComponents.DotNetBar.LabelX();
            this.txtAppName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblAppStart = new DevComponents.DotNetBar.LabelX();
            this.DateAppStart = new AftabCalendar.UI.Controls.PersianDatePicker();
            this.lblAppEnd = new DevComponents.DotNetBar.LabelX();
            this.DateAppEnd = new AftabCalendar.UI.Controls.PersianDatePicker();
            this.lblStartTime = new DevComponents.DotNetBar.LabelX();
            this.TimeStart = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.PanelDays = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.cBoxDay1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cBoxDay2 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cBoxDay3 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cBoxDay4 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cBoxDay5 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cBoxDay6 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cBoxDay7 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.PanelInstance = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.cBoxInstanceName = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtInstanceName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblInstanceName = new DevComponents.DotNetBar.LabelX();
            this.btnSelectInstance = new DevComponents.DotNetBar.ButtonX();
            this.PanelSettings = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.cBoxImagingBank = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.lblSaveFirstPath = new DevComponents.DotNetBar.LabelX();
            this.txtSaveFirstPath = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnSelectFirstPath = new DevComponents.DotNetBar.ButtonX();
            this.lblSaveSecondPath = new DevComponents.DotNetBar.LabelX();
            this.txtSaveSecondPath = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnSelectSecondPath = new DevComponents.DotNetBar.ButtonX();
            this.lblSaveThirdPath = new DevComponents.DotNetBar.LabelX();
            this.txtSaveThirdPath = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnSelectThirdPath = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnAccept = new DevComponents.DotNetBar.ButtonX();
            this.FolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.PanelCostDiscount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimeStart)).BeginInit();
            this.PanelDays.SuspendLayout();
            this.PanelInstance.SuspendLayout();
            this.PanelSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelCostDiscount
            // 
            this.PanelCostDiscount.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelCostDiscount.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelCostDiscount.Controls.Add(this.lblTopic);
            this.PanelCostDiscount.Controls.Add(this.cBoxIsActive);
            this.PanelCostDiscount.Controls.Add(this.lblAppName);
            this.PanelCostDiscount.Controls.Add(this.txtAppName);
            this.PanelCostDiscount.Controls.Add(this.lblAppStart);
            this.PanelCostDiscount.Controls.Add(this.DateAppStart);
            this.PanelCostDiscount.Controls.Add(this.lblAppEnd);
            this.PanelCostDiscount.Controls.Add(this.DateAppEnd);
            this.PanelCostDiscount.Controls.Add(this.lblStartTime);
            this.PanelCostDiscount.Controls.Add(this.TimeStart);
            this.PanelCostDiscount.Controls.Add(this.PanelDays);
            this.PanelCostDiscount.Controls.Add(this.PanelInstance);
            this.PanelCostDiscount.Controls.Add(this.PanelSettings);
            this.PanelCostDiscount.Controls.Add(this.lblSaveFirstPath);
            this.PanelCostDiscount.Controls.Add(this.txtSaveFirstPath);
            this.PanelCostDiscount.Controls.Add(this.btnSelectFirstPath);
            this.PanelCostDiscount.Controls.Add(this.lblSaveSecondPath);
            this.PanelCostDiscount.Controls.Add(this.txtSaveSecondPath);
            this.PanelCostDiscount.Controls.Add(this.btnSelectSecondPath);
            this.PanelCostDiscount.Controls.Add(this.lblSaveThirdPath);
            this.PanelCostDiscount.Controls.Add(this.txtSaveThirdPath);
            this.PanelCostDiscount.Controls.Add(this.btnSelectThirdPath);
            this.PanelCostDiscount.Controls.Add(this.btnCancel);
            this.PanelCostDiscount.Controls.Add(this.btnAccept);
            this.PanelCostDiscount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelCostDiscount.Location = new System.Drawing.Point(0, 0);
            this.PanelCostDiscount.Name = "PanelCostDiscount";
            this.PanelCostDiscount.Size = new System.Drawing.Size(469, 500);
            // 
            // 
            // 
            this.PanelCostDiscount.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.PanelCostDiscount.Style.BackColorGradientAngle = 90;
            this.PanelCostDiscount.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.PanelCostDiscount.Style.BorderBottomWidth = 1;
            this.PanelCostDiscount.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.PanelCostDiscount.Style.BorderLeftWidth = 1;
            this.PanelCostDiscount.Style.BorderRightWidth = 1;
            this.PanelCostDiscount.Style.BorderTopWidth = 1;
            this.PanelCostDiscount.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.PanelCostDiscount.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.PanelCostDiscount.TabIndex = 0;
            // 
            // lblTopic
            // 
            this.lblTopic.BackColor = System.Drawing.Color.Transparent;
            this.lblTopic.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTopic.Font = new System.Drawing.Font("B Koodak", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTopic.Location = new System.Drawing.Point(0, 0);
            this.lblTopic.Name = "lblTopic";
            this.lblTopic.Size = new System.Drawing.Size(469, 52);
            this.lblTopic.TabIndex = 0;
            this.lblTopic.Text = "مدیریت برنامه تولید فایل پشتیبانی";
            this.lblTopic.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // cBoxIsActive
            // 
            this.cBoxIsActive.AutoSize = true;
            this.cBoxIsActive.BackColor = System.Drawing.Color.Transparent;
            this.cBoxIsActive.Checked = true;
            this.cBoxIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBoxIsActive.CheckValue = "Y";
            this.cBoxIsActive.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxIsActive.Location = new System.Drawing.Point(411, 69);
            this.cBoxIsActive.Name = "cBoxIsActive";
            this.cBoxIsActive.Size = new System.Drawing.Size(47, 16);
            this.cBoxIsActive.TabIndex = 1;
            this.cBoxIsActive.Tag = "ctrl";
            this.cBoxIsActive.Text = "فعال";
            this.cBoxIsActive.TextColor = System.Drawing.Color.Purple;
            // 
            // lblAppName
            // 
            this.lblAppName.AutoSize = true;
            this.lblAppName.BackColor = System.Drawing.Color.Transparent;
            this.lblAppName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblAppName.Location = new System.Drawing.Point(353, 69);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(55, 16);
            this.lblAppName.TabIndex = 2;
            this.lblAppName.Text = "نام برنامه:";
            this.lblAppName.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // txtAppName
            // 
            // 
            // 
            // 
            this.txtAppName.Border.Class = "TextBoxBorder";
            this.txtAppName.Location = new System.Drawing.Point(9, 67);
            this.txtAppName.MaxLength = 50;
            this.txtAppName.Name = "txtAppName";
            this.txtAppName.Size = new System.Drawing.Size(336, 21);
            this.txtAppName.TabIndex = 3;
            this.txtAppName.Tag = "ctrl";
            // 
            // lblAppStart
            // 
            this.lblAppStart.AutoSize = true;
            this.lblAppStart.BackColor = System.Drawing.Color.Transparent;
            this.lblAppStart.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblAppStart.Location = new System.Drawing.Point(406, 99);
            this.lblAppStart.Name = "lblAppStart";
            this.lblAppStart.Size = new System.Drawing.Size(54, 16);
            this.lblAppStart.TabIndex = 4;
            this.lblAppStart.Text = "تاریخ آغاز:";
            this.lblAppStart.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // DateAppStart
            // 
            this.DateAppStart.IsAllowNullDate = false;
            this.DateAppStart.IsPopupOpen = false;
            this.DateAppStart.Location = new System.Drawing.Point(315, 97);
            this.DateAppStart.Name = "DateAppStart";
            this.DateAppStart.SelectedDateTime = new System.DateTime(2009, 7, 23, 0, 0, 0, 0);
            this.DateAppStart.Size = new System.Drawing.Size(85, 21);
            this.DateAppStart.TabIndex = 5;
            this.DateAppStart.Tag = "ctrl";
            // 
            // lblAppEnd
            // 
            this.lblAppEnd.AutoSize = true;
            this.lblAppEnd.BackColor = System.Drawing.Color.Transparent;
            this.lblAppEnd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblAppEnd.Location = new System.Drawing.Point(250, 99);
            this.lblAppEnd.Name = "lblAppEnd";
            this.lblAppEnd.Size = new System.Drawing.Size(60, 16);
            this.lblAppEnd.TabIndex = 7;
            this.lblAppEnd.Text = "تاریخ اتمام:";
            this.lblAppEnd.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // DateAppEnd
            // 
            this.DateAppEnd.IsAllowNullDate = false;
            this.DateAppEnd.IsPopupOpen = false;
            this.DateAppEnd.Location = new System.Drawing.Point(160, 97);
            this.DateAppEnd.Name = "DateAppEnd";
            this.DateAppEnd.SelectedDateTime = new System.DateTime(2009, 7, 23, 0, 0, 0, 0);
            this.DateAppEnd.Size = new System.Drawing.Size(85, 21);
            this.DateAppEnd.TabIndex = 8;
            this.DateAppEnd.Tag = "ctrl";
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.BackColor = System.Drawing.Color.Transparent;
            this.lblStartTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblStartTime.Location = new System.Drawing.Point(80, 99);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(75, 16);
            this.lblStartTime.TabIndex = 9;
            this.lblStartTime.Text = "ساعت شروع:";
            this.lblStartTime.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // TimeStart
            // 
            this.TimeStart.AllowEmptyState = false;
            // 
            // 
            // 
            this.TimeStart.BackgroundStyle.Class = "DateTimeInputBackground";
            this.TimeStart.CustomFormat = "HH:mm";
            this.TimeStart.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.TimeStart.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.TimeStart.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.TimeStart.Location = new System.Drawing.Point(8, 97);
            // 
            // 
            // 
            this.TimeStart.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.TimeStart.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.TimeStart.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.TimeStart.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.TimeStart.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.TimeStart.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.TimeStart.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.TimeStart.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.TimeStart.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.TimeStart.MonthCalendar.DisplayMonth = new System.DateTime(2008, 10, 1, 0, 0, 0, 0);
            this.TimeStart.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Saturday;
            this.TimeStart.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.TimeStart.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.TimeStart.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.TimeStart.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.TimeStart.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.TimeStart.MonthCalendar.TodayButtonVisible = true;
            this.TimeStart.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.TimeStart.Name = "TimeStart";
            this.TimeStart.ShowUpDown = true;
            this.TimeStart.Size = new System.Drawing.Size(66, 21);
            this.TimeStart.TabIndex = 10;
            this.TimeStart.Tag = "RefData";
            this.TimeStart.Value = new System.DateTime(((long)(0)));
            this.TimeStart.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            // 
            // PanelDays
            // 
            this.PanelDays.BackColor = System.Drawing.Color.Transparent;
            this.PanelDays.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelDays.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelDays.Controls.Add(this.cBoxDay1);
            this.PanelDays.Controls.Add(this.cBoxDay2);
            this.PanelDays.Controls.Add(this.cBoxDay3);
            this.PanelDays.Controls.Add(this.cBoxDay4);
            this.PanelDays.Controls.Add(this.cBoxDay5);
            this.PanelDays.Controls.Add(this.cBoxDay6);
            this.PanelDays.Controls.Add(this.cBoxDay7);
            this.PanelDays.DrawTitleBox = false;
            this.PanelDays.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.PanelDays.Location = new System.Drawing.Point(9, 126);
            this.PanelDays.Name = "PanelDays";
            this.PanelDays.Size = new System.Drawing.Size(449, 47);
            // 
            // 
            // 
            this.PanelDays.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.PanelDays.Style.BackColorGradientAngle = 90;
            this.PanelDays.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.PanelDays.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelDays.Style.BorderBottomWidth = 1;
            this.PanelDays.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.PanelDays.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelDays.Style.BorderLeftWidth = 1;
            this.PanelDays.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelDays.Style.BorderRightWidth = 1;
            this.PanelDays.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelDays.Style.BorderTopWidth = 1;
            this.PanelDays.Style.CornerDiameter = 4;
            this.PanelDays.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.PanelDays.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.PanelDays.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.PanelDays.TabIndex = 11;
            this.PanelDays.Tag = "ctrl";
            this.PanelDays.Text = "مدیریت برنامه های ثابت هفتگی";
            // 
            // cBoxDay1
            // 
            this.cBoxDay1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cBoxDay1.AutoSize = true;
            this.cBoxDay1.BackColor = System.Drawing.Color.Transparent;
            this.cBoxDay1.CheckValueChecked = "1";
            this.cBoxDay1.Location = new System.Drawing.Point(394, 3);
            this.cBoxDay1.Name = "cBoxDay1";
            this.cBoxDay1.Size = new System.Drawing.Size(50, 16);
            this.cBoxDay1.TabIndex = 0;
            this.cBoxDay1.Tag = "WeekDays";
            this.cBoxDay1.Text = "شنبه";
            // 
            // cBoxDay2
            // 
            this.cBoxDay2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cBoxDay2.AutoSize = true;
            this.cBoxDay2.BackColor = System.Drawing.Color.Transparent;
            this.cBoxDay2.CheckValueChecked = "2";
            this.cBoxDay2.Location = new System.Drawing.Point(333, 3);
            this.cBoxDay2.Name = "cBoxDay2";
            this.cBoxDay2.Size = new System.Drawing.Size(61, 16);
            this.cBoxDay2.TabIndex = 1;
            this.cBoxDay2.Tag = "WeekDays";
            this.cBoxDay2.Text = "یكشنبه";
            // 
            // cBoxDay3
            // 
            this.cBoxDay3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cBoxDay3.AutoSize = true;
            this.cBoxDay3.BackColor = System.Drawing.Color.Transparent;
            this.cBoxDay3.CheckValueChecked = "3";
            this.cBoxDay3.Location = new System.Drawing.Point(271, 3);
            this.cBoxDay3.Name = "cBoxDay3";
            this.cBoxDay3.Size = new System.Drawing.Size(62, 16);
            this.cBoxDay3.TabIndex = 2;
            this.cBoxDay3.Tag = "WeekDays";
            this.cBoxDay3.Text = "دوشنبه";
            // 
            // cBoxDay4
            // 
            this.cBoxDay4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cBoxDay4.AutoSize = true;
            this.cBoxDay4.BackColor = System.Drawing.Color.Transparent;
            this.cBoxDay4.CheckValueChecked = "4";
            this.cBoxDay4.Location = new System.Drawing.Point(198, 3);
            this.cBoxDay4.Name = "cBoxDay4";
            this.cBoxDay4.Size = new System.Drawing.Size(73, 16);
            this.cBoxDay4.TabIndex = 3;
            this.cBoxDay4.Tag = "WeekDays";
            this.cBoxDay4.Text = "سه شنبه";
            // 
            // cBoxDay5
            // 
            this.cBoxDay5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cBoxDay5.AutoSize = true;
            this.cBoxDay5.BackColor = System.Drawing.Color.Transparent;
            this.cBoxDay5.CheckValueChecked = "5";
            this.cBoxDay5.Location = new System.Drawing.Point(124, 3);
            this.cBoxDay5.Name = "cBoxDay5";
            this.cBoxDay5.Size = new System.Drawing.Size(74, 16);
            this.cBoxDay5.TabIndex = 4;
            this.cBoxDay5.Tag = "WeekDays";
            this.cBoxDay5.Text = "چهارشنبه";
            // 
            // cBoxDay6
            // 
            this.cBoxDay6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cBoxDay6.AutoSize = true;
            this.cBoxDay6.BackColor = System.Drawing.Color.Transparent;
            this.cBoxDay6.CheckValueChecked = "6";
            this.cBoxDay6.Location = new System.Drawing.Point(57, 3);
            this.cBoxDay6.Name = "cBoxDay6";
            this.cBoxDay6.Size = new System.Drawing.Size(67, 16);
            this.cBoxDay6.TabIndex = 5;
            this.cBoxDay6.Tag = "WeekDays";
            this.cBoxDay6.Text = "پنجشنبه";
            // 
            // cBoxDay7
            // 
            this.cBoxDay7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cBoxDay7.AutoSize = true;
            this.cBoxDay7.BackColor = System.Drawing.Color.Transparent;
            this.cBoxDay7.CheckValueChecked = "7";
            this.cBoxDay7.Location = new System.Drawing.Point(5, 3);
            this.cBoxDay7.Name = "cBoxDay7";
            this.cBoxDay7.Size = new System.Drawing.Size(52, 16);
            this.cBoxDay7.TabIndex = 6;
            this.cBoxDay7.Tag = "WeekDays";
            this.cBoxDay7.Text = "جمعه";
            // 
            // PanelInstance
            // 
            this.PanelInstance.BackColor = System.Drawing.Color.Transparent;
            this.PanelInstance.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelInstance.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelInstance.Controls.Add(this.cBoxInstanceName);
            this.PanelInstance.Controls.Add(this.txtInstanceName);
            this.PanelInstance.Controls.Add(this.lblInstanceName);
            this.PanelInstance.Controls.Add(this.btnSelectInstance);
            this.PanelInstance.DrawTitleBox = false;
            this.PanelInstance.Location = new System.Drawing.Point(8, 179);
            this.PanelInstance.Name = "PanelInstance";
            this.PanelInstance.Size = new System.Drawing.Size(449, 45);
            // 
            // 
            // 
            this.PanelInstance.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.PanelInstance.Style.BackColorGradientAngle = 90;
            this.PanelInstance.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.PanelInstance.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelInstance.Style.BorderBottomWidth = 1;
            this.PanelInstance.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.PanelInstance.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelInstance.Style.BorderLeftWidth = 1;
            this.PanelInstance.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelInstance.Style.BorderRightWidth = 1;
            this.PanelInstance.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelInstance.Style.BorderTopWidth = 1;
            this.PanelInstance.Style.CornerDiameter = 4;
            this.PanelInstance.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.PanelInstance.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.PanelInstance.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.PanelInstance.TabIndex = 12;
            this.PanelInstance.Text = "تنظیمات نمونه بانك اطلاعاتی";
            // 
            // cBoxInstanceName
            // 
            this.cBoxInstanceName.DisplayMember = "Text";
            this.cBoxInstanceName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cBoxInstanceName.FormattingEnabled = true;
            this.cBoxInstanceName.ItemHeight = 15;
            this.cBoxInstanceName.Location = new System.Drawing.Point(33, 0);
            this.cBoxInstanceName.Name = "cBoxInstanceName";
            this.cBoxInstanceName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cBoxInstanceName.Size = new System.Drawing.Size(277, 21);
            this.cBoxInstanceName.TabIndex = 25;
            // 
            // txtInstanceName
            // 
            // 
            // 
            // 
            this.txtInstanceName.Border.Class = "TextBoxBorder";
            this.txtInstanceName.Location = new System.Drawing.Point(33, 0);
            this.txtInstanceName.Name = "txtInstanceName";
            this.txtInstanceName.ReadOnly = true;
            this.txtInstanceName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtInstanceName.Size = new System.Drawing.Size(277, 21);
            this.txtInstanceName.TabIndex = 1;
            this.txtInstanceName.Visible = false;
            // 
            // lblInstanceName
            // 
            this.lblInstanceName.AutoSize = true;
            this.lblInstanceName.BackColor = System.Drawing.Color.Transparent;
            this.lblInstanceName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblInstanceName.Location = new System.Drawing.Point(316, 2);
            this.lblInstanceName.Name = "lblInstanceName";
            this.lblInstanceName.Size = new System.Drawing.Size(128, 16);
            this.lblInstanceName.TabIndex = 0;
            this.lblInstanceName.Text = "نام نمونه بانك اطلاعاتی:";
            this.lblInstanceName.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // btnSelectInstance
            // 
            this.btnSelectInstance.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelectInstance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectInstance.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelectInstance.Enabled = false;
            this.btnSelectInstance.Location = new System.Drawing.Point(6, 0);
            this.btnSelectInstance.Name = "btnSelectInstance";
            this.btnSelectInstance.Size = new System.Drawing.Size(21, 21);
            this.btnSelectInstance.TabIndex = 16;
            this.btnSelectInstance.TabStop = false;
            this.btnSelectInstance.Text = "...";
            this.btnSelectInstance.Click += new System.EventHandler(this.btnSelectInstance_Click);
            // 
            // PanelSettings
            // 
            this.PanelSettings.BackColor = System.Drawing.Color.Transparent;
            this.PanelSettings.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelSettings.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelSettings.Controls.Add(this.cBoxImagingBank);
            this.PanelSettings.DrawTitleBox = false;
            this.PanelSettings.Location = new System.Drawing.Point(9, 230);
            this.PanelSettings.Name = "PanelSettings";
            this.PanelSettings.Size = new System.Drawing.Size(448, 45);
            // 
            // 
            // 
            this.PanelSettings.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.PanelSettings.Style.BackColorGradientAngle = 90;
            this.PanelSettings.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.PanelSettings.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelSettings.Style.BorderBottomWidth = 1;
            this.PanelSettings.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.PanelSettings.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelSettings.Style.BorderLeftWidth = 1;
            this.PanelSettings.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelSettings.Style.BorderRightWidth = 1;
            this.PanelSettings.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelSettings.Style.BorderTopWidth = 1;
            this.PanelSettings.Style.CornerDiameter = 4;
            this.PanelSettings.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.PanelSettings.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.PanelSettings.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.PanelSettings.TabIndex = 13;
            this.PanelSettings.Text = "تنظیمات پشتیبانی";
            // 
            // cBoxImagingBank
            // 
            this.cBoxImagingBank.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxImagingBank.AutoSize = true;
            this.cBoxImagingBank.BackColor = System.Drawing.Color.Transparent;
            this.cBoxImagingBank.Checked = true;
            this.cBoxImagingBank.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBoxImagingBank.CheckValue = "Y";
            this.cBoxImagingBank.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxImagingBank.Location = new System.Drawing.Point(150, 3);
            this.cBoxImagingBank.Name = "cBoxImagingBank";
            this.cBoxImagingBank.Size = new System.Drawing.Size(289, 16);
            this.cBoxImagingBank.TabIndex = 0;
            this.cBoxImagingBank.Text = "ایجاد پشتیبانی از بانك اطلاعات مدیریت تصویربرداری";
            // 
            // lblSaveFirstPath
            // 
            this.lblSaveFirstPath.AutoSize = true;
            this.lblSaveFirstPath.BackColor = System.Drawing.Color.Transparent;
            this.lblSaveFirstPath.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblSaveFirstPath.Location = new System.Drawing.Point(260, 281);
            this.lblSaveFirstPath.Name = "lblSaveFirstPath";
            this.lblSaveFirstPath.Size = new System.Drawing.Size(197, 16);
            this.lblSaveFirstPath.TabIndex = 14;
            this.lblSaveFirstPath.Text = "اولین محل ذخیره فایل های پشتیبانی:";
            this.lblSaveFirstPath.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // txtSaveFirstPath
            // 
            this.txtSaveFirstPath.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtSaveFirstPath.Border.Class = "TextBoxBorder";
            this.txtSaveFirstPath.Location = new System.Drawing.Point(38, 302);
            this.txtSaveFirstPath.Name = "txtSaveFirstPath";
            this.txtSaveFirstPath.ReadOnly = true;
            this.txtSaveFirstPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSaveFirstPath.Size = new System.Drawing.Size(419, 21);
            this.txtSaveFirstPath.TabIndex = 15;
            this.txtSaveFirstPath.Text = "C:\\Aftab Backup";
            // 
            // btnSelectFirstPath
            // 
            this.btnSelectFirstPath.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelectFirstPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectFirstPath.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelectFirstPath.Location = new System.Drawing.Point(11, 302);
            this.btnSelectFirstPath.Name = "btnSelectFirstPath";
            this.btnSelectFirstPath.Size = new System.Drawing.Size(21, 21);
            this.btnSelectFirstPath.TabIndex = 16;
            this.btnSelectFirstPath.TabStop = false;
            this.btnSelectFirstPath.Text = "...";
            this.btnSelectFirstPath.Click += new System.EventHandler(this.btnSelectPath_Click);
            // 
            // lblSaveSecondPath
            // 
            this.lblSaveSecondPath.AutoSize = true;
            this.lblSaveSecondPath.BackColor = System.Drawing.Color.Transparent;
            this.lblSaveSecondPath.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblSaveSecondPath.Location = new System.Drawing.Point(254, 328);
            this.lblSaveSecondPath.Name = "lblSaveSecondPath";
            this.lblSaveSecondPath.Size = new System.Drawing.Size(203, 16);
            this.lblSaveSecondPath.TabIndex = 17;
            this.lblSaveSecondPath.Text = "دومین محل ذخیره فایل های پشتیبانی:";
            this.lblSaveSecondPath.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // txtSaveSecondPath
            // 
            this.txtSaveSecondPath.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtSaveSecondPath.Border.Class = "TextBoxBorder";
            this.txtSaveSecondPath.Location = new System.Drawing.Point(38, 350);
            this.txtSaveSecondPath.Name = "txtSaveSecondPath";
            this.txtSaveSecondPath.ReadOnly = true;
            this.txtSaveSecondPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSaveSecondPath.Size = new System.Drawing.Size(419, 21);
            this.txtSaveSecondPath.TabIndex = 18;
            // 
            // btnSelectSecondPath
            // 
            this.btnSelectSecondPath.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelectSecondPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectSecondPath.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelectSecondPath.Location = new System.Drawing.Point(11, 350);
            this.btnSelectSecondPath.Name = "btnSelectSecondPath";
            this.btnSelectSecondPath.Size = new System.Drawing.Size(21, 21);
            this.btnSelectSecondPath.TabIndex = 19;
            this.btnSelectSecondPath.TabStop = false;
            this.btnSelectSecondPath.Text = "...";
            this.btnSelectSecondPath.Click += new System.EventHandler(this.btnSelectSecondPath_Click);
            // 
            // lblSaveThirdPath
            // 
            this.lblSaveThirdPath.AutoSize = true;
            this.lblSaveThirdPath.BackColor = System.Drawing.Color.Transparent;
            this.lblSaveThirdPath.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblSaveThirdPath.Location = new System.Drawing.Point(248, 376);
            this.lblSaveThirdPath.Name = "lblSaveThirdPath";
            this.lblSaveThirdPath.Size = new System.Drawing.Size(209, 16);
            this.lblSaveThirdPath.TabIndex = 20;
            this.lblSaveThirdPath.Text = "سومین محل ذخیره فایل های پشتیبانی:";
            this.lblSaveThirdPath.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // txtSaveThirdPath
            // 
            this.txtSaveThirdPath.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtSaveThirdPath.Border.Class = "TextBoxBorder";
            this.txtSaveThirdPath.Location = new System.Drawing.Point(38, 398);
            this.txtSaveThirdPath.Name = "txtSaveThirdPath";
            this.txtSaveThirdPath.ReadOnly = true;
            this.txtSaveThirdPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSaveThirdPath.Size = new System.Drawing.Size(419, 21);
            this.txtSaveThirdPath.TabIndex = 21;
            // 
            // btnSelectThirdPath
            // 
            this.btnSelectThirdPath.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelectThirdPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectThirdPath.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelectThirdPath.Location = new System.Drawing.Point(11, 398);
            this.btnSelectThirdPath.Name = "btnSelectThirdPath";
            this.btnSelectThirdPath.Size = new System.Drawing.Size(21, 21);
            this.btnSelectThirdPath.TabIndex = 22;
            this.btnSelectThirdPath.TabStop = false;
            this.btnSelectThirdPath.Text = "...";
            this.btnSelectThirdPath.Click += new System.EventHandler(this.btnSelectThirdPath_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Aftab.Properties.Resources.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(110, 429);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 60);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "انصراف (Esc)";
            // 
            // btnAccept
            // 
            this.btnAccept.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAccept.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAccept.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnAccept.Image = global::Aftab.Properties.Resources.Accept;
            this.btnAccept.Location = new System.Drawing.Point(9, 429);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnAccept.Size = new System.Drawing.Size(95, 60);
            this.btnAccept.TabIndex = 23;
            this.btnAccept.Text = "تائید (F8)";
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // FolderBrowser
            // 
            this.FolderBrowser.Description = "انتخاب محل پوشه ی ذخیره فایل های پشتیبانی";
            // 
            // frmManageBackupPlans
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(469, 500);
            this.Controls.Add(this.PanelCostDiscount);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManageBackupPlans";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "مدیریت پشتیبان گیری منظم";
            this.PanelCostDiscount.ResumeLayout(false);
            this.PanelCostDiscount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimeStart)).EndInit();
            this.PanelDays.ResumeLayout(false);
            this.PanelDays.PerformLayout();
            this.PanelInstance.ResumeLayout(false);
            this.PanelInstance.PerformLayout();
            this.PanelSettings.ResumeLayout(false);
            this.PanelSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel PanelCostDiscount;
        private DevComponents.DotNetBar.LabelX lblSaveFirstPath;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSaveFirstPath;
        private DevComponents.DotNetBar.ButtonX btnSelectFirstPath;
        private DevComponents.DotNetBar.Controls.GroupPanel PanelSettings;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxImagingBank;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnAccept;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxIsActive;
        private DevComponents.DotNetBar.LabelX lblAppName;
        private DevComponents.DotNetBar.Controls.TextBoxX txtAppName;
        private DevComponents.DotNetBar.LabelX lblAppStart;
        private AftabCalendar.UI.Controls.PersianDatePicker DateAppStart;
        private DevComponents.DotNetBar.LabelX lblAppEnd;
        private AftabCalendar.UI.Controls.PersianDatePicker DateAppEnd;
        private DevComponents.DotNetBar.Controls.GroupPanel PanelDays;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxDay1;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxDay2;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxDay3;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxDay4;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxDay5;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxDay6;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxDay7;
        private DevComponents.DotNetBar.LabelX lblStartTime;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput TimeStart;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowser;
        private DevComponents.DotNetBar.LabelX lblTopic;
        private DevComponents.DotNetBar.ButtonX btnSelectThirdPath;
        private DevComponents.DotNetBar.ButtonX btnSelectSecondPath;
        private DevComponents.DotNetBar.LabelX lblSaveThirdPath;
        private DevComponents.DotNetBar.LabelX lblSaveSecondPath;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSaveThirdPath;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSaveSecondPath;
        private DevComponents.DotNetBar.Controls.GroupPanel PanelInstance;
        private DevComponents.DotNetBar.Controls.TextBoxX txtInstanceName;
        private DevComponents.DotNetBar.LabelX lblInstanceName;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cBoxInstanceName;
        private DevComponents.DotNetBar.ButtonX btnSelectInstance;

    }
}