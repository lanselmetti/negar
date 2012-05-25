namespace Sepehr.Settings.Schedules.Applications
{
    partial class frmAppsAdd
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAppsAdd));
            this.FormPanel = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.ProgressBar = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.lblTitle = new DevComponents.DotNetBar.LabelX();
            this.cBoxNoneFixApps = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cBoxFixApps = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cBoxIsActive = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.lblAppName = new DevComponents.DotNetBar.LabelX();
            this.txtAppName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblAppStart = new DevComponents.DotNetBar.LabelX();
            this.DateAppStart = new Negar.PersianCalendar.UI.Controls.PersianDatePicker();
            this.lblAppEnd = new DevComponents.DotNetBar.LabelX();
            this.DateAppEnd = new Negar.PersianCalendar.UI.Controls.PersianDatePicker();
            this.Panel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.cBoxDay1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cBoxDay2 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cBoxDay3 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cBoxDay4 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cBoxDay5 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cBoxDay6 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cBoxDay7 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.lblStartTime1 = new DevComponents.DotNetBar.LabelX();
            this.TimeStart1 = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.lblEndTime1 = new DevComponents.DotNetBar.LabelX();
            this.TimeEnd1 = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.lblCapacity1 = new DevComponents.DotNetBar.LabelX();
            this.txtCapacity1 = new DevComponents.Editors.IntegerInput();
            this.lblRoundMin1 = new DevComponents.DotNetBar.LabelX();
            this.txtRoundMin1 = new DevComponents.Editors.IntegerInput();
            this.lblMin1 = new DevComponents.DotNetBar.LabelX();
            this.Panel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.lblDayOfWeek = new DevComponents.DotNetBar.LabelX();
            this.cboWeekDays = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.comboItem4 = new DevComponents.Editors.ComboItem();
            this.comboItem5 = new DevComponents.Editors.ComboItem();
            this.comboItem6 = new DevComponents.Editors.ComboItem();
            this.comboItem7 = new DevComponents.Editors.ComboItem();
            this.lblStartTime2 = new DevComponents.DotNetBar.LabelX();
            this.TimeStart2 = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.lblEndTime2 = new DevComponents.DotNetBar.LabelX();
            this.TimeEnd2 = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.lblCapacity2 = new DevComponents.DotNetBar.LabelX();
            this.txtCapacity2 = new DevComponents.Editors.IntegerInput();
            this.lblRoundMin2 = new DevComponents.DotNetBar.LabelX();
            this.txtRoundMin2 = new DevComponents.Editors.IntegerInput();
            this.lblMin2 = new DevComponents.DotNetBar.LabelX();
            this.btnAddNewDay = new DevComponents.DotNetBar.ButtonX();
            this.dgvData = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ColDayNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBeginTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCapacity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRoundMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblDescription = new DevComponents.DotNetBar.LabelX();
            this.txtDescription = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnHelp = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnAccept = new DevComponents.DotNetBar.ButtonX();
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.FormErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.BWFormThread = new System.ComponentModel.BackgroundWorker();
            this.FormPanel.SuspendLayout();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimeStart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeEnd1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCapacity1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoundMin1)).BeginInit();
            this.Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimeStart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeEnd2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCapacity2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoundMin2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FormErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // FormPanel
            // 
            this.FormPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.FormPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.FormPanel.Controls.Add(this.ProgressBar);
            this.FormPanel.Controls.Add(this.lblTitle);
            this.FormPanel.Controls.Add(this.cBoxNoneFixApps);
            this.FormPanel.Controls.Add(this.cBoxFixApps);
            this.FormPanel.Controls.Add(this.cBoxIsActive);
            this.FormPanel.Controls.Add(this.lblAppName);
            this.FormPanel.Controls.Add(this.txtAppName);
            this.FormPanel.Controls.Add(this.lblAppStart);
            this.FormPanel.Controls.Add(this.DateAppStart);
            this.FormPanel.Controls.Add(this.lblAppEnd);
            this.FormPanel.Controls.Add(this.DateAppEnd);
            this.FormPanel.Controls.Add(this.Panel1);
            this.FormPanel.Controls.Add(this.Panel2);
            this.FormPanel.Controls.Add(this.lblDescription);
            this.FormPanel.Controls.Add(this.txtDescription);
            this.FormPanel.Controls.Add(this.btnHelp);
            this.FormPanel.Controls.Add(this.btnCancel);
            this.FormPanel.Controls.Add(this.btnAccept);
            this.FormPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormPanel.Location = new System.Drawing.Point(0, 0);
            this.FormPanel.Name = "FormPanel";
            this.FormPanel.Size = new System.Drawing.Size(547, 584);
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
            // ProgressBar
            // 
            this.ProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressBar.Location = new System.Drawing.Point(214, 530);
            this.ProgressBar.Maximum = 2;
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.ProgressType = DevComponents.DotNetBar.eProgressItemType.Marquee;
            this.ProgressBar.Size = new System.Drawing.Size(220, 23);
            this.ProgressBar.TabIndex = 17;
            this.ProgressBar.TabStop = false;
            this.ProgressBar.Text = "در حال ایجاد برنامه نوبت دهی";
            this.ProgressBar.TextVisible = true;
            this.ProgressBar.Visible = false;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("B Yekan", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(547, 48);
            this.lblTitle.TabIndex = 16;
            this.lblTitle.Text = "تعریف برنامه نوبت دهی جدید تصویربرداری";
            this.lblTitle.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // cBoxNoneFixApps
            // 
            this.cBoxNoneFixApps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxNoneFixApps.AutoSize = true;
            this.cBoxNoneFixApps.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.cBoxNoneFixApps.BackgroundStyle.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(0)))));
            this.cBoxNoneFixApps.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.cBoxNoneFixApps.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxNoneFixApps.Location = new System.Drawing.Point(408, 228);
            this.cBoxNoneFixApps.Name = "cBoxNoneFixApps";
            this.cBoxNoneFixApps.Size = new System.Drawing.Size(128, 16);
            this.cBoxNoneFixApps.TabIndex = 9;
            this.cBoxNoneFixApps.Tag = "ctrl";
            this.cBoxNoneFixApps.Text = "برنامه شناور هفتگی";
            this.cBoxNoneFixApps.TextColor = System.Drawing.Color.Green;
            this.cBoxNoneFixApps.CheckedChanged += new System.EventHandler(this.cBoxFixApps_CheckedChanged);
            // 
            // cBoxFixApps
            // 
            this.cBoxFixApps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxFixApps.AutoSize = true;
            this.cBoxFixApps.BackColor = System.Drawing.Color.Transparent;
            this.cBoxFixApps.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.cBoxFixApps.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxFixApps.Location = new System.Drawing.Point(457, 109);
            this.cBoxFixApps.Name = "cBoxFixApps";
            this.cBoxFixApps.Size = new System.Drawing.Size(79, 16);
            this.cBoxFixApps.TabIndex = 7;
            this.cBoxFixApps.Tag = "ctrl";
            this.cBoxFixApps.Text = "برنامه ثابت";
            this.cBoxFixApps.CheckedChanged += new System.EventHandler(this.cBoxFixApps_CheckedChanged);
            // 
            // cBoxIsActive
            // 
            this.cBoxIsActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxIsActive.AutoSize = true;
            this.cBoxIsActive.BackColor = System.Drawing.Color.Transparent;
            this.cBoxIsActive.Checked = true;
            this.cBoxIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBoxIsActive.CheckValue = "Y";
            this.cBoxIsActive.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxIsActive.Location = new System.Drawing.Point(487, 54);
            this.cBoxIsActive.Name = "cBoxIsActive";
            this.cBoxIsActive.Size = new System.Drawing.Size(47, 16);
            this.cBoxIsActive.TabIndex = 1;
            this.cBoxIsActive.Tag = "ctrl";
            this.cBoxIsActive.Text = "فعال";
            this.cBoxIsActive.TextColor = System.Drawing.Color.Purple;
            // 
            // lblAppName
            // 
            this.lblAppName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAppName.AutoSize = true;
            this.lblAppName.BackColor = System.Drawing.Color.Transparent;
            this.lblAppName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblAppName.Location = new System.Drawing.Point(427, 54);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(55, 16);
            this.lblAppName.TabIndex = 2;
            this.lblAppName.Text = "نام برنامه:";
            this.lblAppName.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // txtAppName
            // 
            this.txtAppName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtAppName.Border.Class = "TextBoxBorder";
            this.txtAppName.Location = new System.Drawing.Point(12, 52);
            this.txtAppName.MaxLength = 50;
            this.txtAppName.Name = "txtAppName";
            this.txtAppName.Size = new System.Drawing.Size(407, 21);
            this.txtAppName.TabIndex = 0;
            this.txtAppName.Tag = "ctrl";
            this.txtAppName.Validating += new System.ComponentModel.CancelEventHandler(this.Controls_Validating);
            // 
            // lblAppStart
            // 
            this.lblAppStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAppStart.AutoSize = true;
            this.lblAppStart.BackColor = System.Drawing.Color.Transparent;
            this.lblAppStart.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblAppStart.Location = new System.Drawing.Point(481, 81);
            this.lblAppStart.Name = "lblAppStart";
            this.lblAppStart.Size = new System.Drawing.Size(54, 16);
            this.lblAppStart.TabIndex = 3;
            this.lblAppStart.Text = "تاریخ آغاز:";
            this.lblAppStart.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // DateAppStart
            // 
            this.DateAppStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DateAppStart.IsAllowNullDate = false;
            this.DateAppStart.IsPopupOpen = false;
            this.DateAppStart.Location = new System.Drawing.Point(391, 79);
            this.DateAppStart.Name = "DateAppStart";
            this.DateAppStart.SelectedDateTime = new System.DateTime(2009, 7, 23, 0, 0, 0, 0);
            this.DateAppStart.Size = new System.Drawing.Size(85, 21);
            this.DateAppStart.TabIndex = 4;
            this.DateAppStart.Tag = "ctrl";
            this.DateAppStart.Validating += new System.ComponentModel.CancelEventHandler(this.Controls_Validating);
            // 
            // lblAppEnd
            // 
            this.lblAppEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAppEnd.AutoSize = true;
            this.lblAppEnd.BackColor = System.Drawing.Color.Transparent;
            this.lblAppEnd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblAppEnd.Location = new System.Drawing.Point(327, 81);
            this.lblAppEnd.Name = "lblAppEnd";
            this.lblAppEnd.Size = new System.Drawing.Size(60, 16);
            this.lblAppEnd.TabIndex = 5;
            this.lblAppEnd.Text = "تاریخ اتمام:";
            this.lblAppEnd.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // DateAppEnd
            // 
            this.DateAppEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DateAppEnd.IsAllowNullDate = false;
            this.DateAppEnd.IsPopupOpen = false;
            this.DateAppEnd.Location = new System.Drawing.Point(235, 79);
            this.DateAppEnd.Name = "DateAppEnd";
            this.DateAppEnd.SelectedDateTime = new System.DateTime(2009, 7, 23, 0, 0, 0, 0);
            this.DateAppEnd.Size = new System.Drawing.Size(85, 21);
            this.DateAppEnd.TabIndex = 6;
            this.DateAppEnd.Tag = "ctrl";
            this.DateAppEnd.Validating += new System.ComponentModel.CancelEventHandler(this.Controls_Validating);
            // 
            // Panel1
            // 
            this.Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.Panel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.Panel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.Panel1.Controls.Add(this.cBoxDay1);
            this.Panel1.Controls.Add(this.cBoxDay2);
            this.Panel1.Controls.Add(this.cBoxDay3);
            this.Panel1.Controls.Add(this.cBoxDay4);
            this.Panel1.Controls.Add(this.cBoxDay5);
            this.Panel1.Controls.Add(this.cBoxDay6);
            this.Panel1.Controls.Add(this.cBoxDay7);
            this.Panel1.Controls.Add(this.lblStartTime1);
            this.Panel1.Controls.Add(this.TimeStart1);
            this.Panel1.Controls.Add(this.lblEndTime1);
            this.Panel1.Controls.Add(this.TimeEnd1);
            this.Panel1.Controls.Add(this.lblCapacity1);
            this.Panel1.Controls.Add(this.txtCapacity1);
            this.Panel1.Controls.Add(this.lblRoundMin1);
            this.Panel1.Controls.Add(this.txtRoundMin1);
            this.Panel1.Controls.Add(this.lblMin1);
            this.Panel1.DrawTitleBox = false;
            this.Panel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Panel1.Location = new System.Drawing.Point(12, 124);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(524, 98);
            // 
            // 
            // 
            this.Panel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.Panel1.Style.BackColorGradientAngle = 90;
            this.Panel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.Panel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.Panel1.Style.BorderBottomWidth = 1;
            this.Panel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.Panel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.Panel1.Style.BorderLeftWidth = 1;
            this.Panel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.Panel1.Style.BorderRightWidth = 1;
            this.Panel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.Panel1.Style.BorderTopWidth = 1;
            this.Panel1.Style.CornerDiameter = 4;
            this.Panel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.Panel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.Panel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.Panel1.TabIndex = 8;
            this.Panel1.Tag = "ctrl";
            this.Panel1.Text = "مدیریت برنامه های ثابت هفتگی";
            // 
            // cBoxDay1
            // 
            this.cBoxDay1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cBoxDay1.AutoSize = true;
            this.cBoxDay1.BackColor = System.Drawing.Color.Transparent;
            this.cBoxDay1.CheckValueChecked = "1";
            this.cBoxDay1.Location = new System.Drawing.Point(465, 5);
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
            this.cBoxDay2.Location = new System.Drawing.Point(393, 5);
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
            this.cBoxDay3.Location = new System.Drawing.Point(320, 5);
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
            this.cBoxDay4.Location = new System.Drawing.Point(236, 5);
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
            this.cBoxDay5.Location = new System.Drawing.Point(151, 5);
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
            this.cBoxDay6.Location = new System.Drawing.Point(73, 5);
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
            this.cBoxDay7.Location = new System.Drawing.Point(10, 5);
            this.cBoxDay7.Name = "cBoxDay7";
            this.cBoxDay7.Size = new System.Drawing.Size(52, 16);
            this.cBoxDay7.TabIndex = 6;
            this.cBoxDay7.Tag = "WeekDays";
            this.cBoxDay7.Text = "جمعه";
            // 
            // lblStartTime1
            // 
            this.lblStartTime1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStartTime1.AutoSize = true;
            this.lblStartTime1.BackColor = System.Drawing.Color.Transparent;
            this.lblStartTime1.Location = new System.Drawing.Point(439, 30);
            this.lblStartTime1.Name = "lblStartTime1";
            this.lblStartTime1.Size = new System.Drawing.Size(75, 16);
            this.lblStartTime1.TabIndex = 7;
            this.lblStartTime1.Text = "ساعت شروع:";
            this.lblStartTime1.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // TimeStart1
            // 
            this.TimeStart1.AllowEmptyState = false;
            this.TimeStart1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.TimeStart1.BackgroundStyle.Class = "DateTimeInputBackground";
            this.TimeStart1.CustomFormat = "HH:mm";
            this.TimeStart1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.TimeStart1.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.TimeStart1.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.TimeStart1.Location = new System.Drawing.Point(362, 28);
            // 
            // 
            // 
            this.TimeStart1.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.TimeStart1.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.TimeStart1.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.TimeStart1.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.TimeStart1.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.TimeStart1.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.TimeStart1.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.TimeStart1.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.TimeStart1.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.TimeStart1.MonthCalendar.DisplayMonth = new System.DateTime(2008, 10, 1, 0, 0, 0, 0);
            this.TimeStart1.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Saturday;
            this.TimeStart1.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.TimeStart1.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.TimeStart1.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.TimeStart1.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.TimeStart1.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.TimeStart1.MonthCalendar.TodayButtonVisible = true;
            this.TimeStart1.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.TimeStart1.Name = "TimeStart1";
            this.TimeStart1.ShowUpDown = true;
            this.TimeStart1.Size = new System.Drawing.Size(74, 21);
            this.TimeStart1.TabIndex = 8;
            this.TimeStart1.Tag = "RefData";
            this.TimeStart1.Value = new System.DateTime(((long)(0)));
            this.TimeStart1.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            // 
            // lblEndTime1
            // 
            this.lblEndTime1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEndTime1.AutoSize = true;
            this.lblEndTime1.BackColor = System.Drawing.Color.Transparent;
            this.lblEndTime1.Location = new System.Drawing.Point(284, 30);
            this.lblEndTime1.Name = "lblEndTime1";
            this.lblEndTime1.Size = new System.Drawing.Size(68, 16);
            this.lblEndTime1.TabIndex = 9;
            this.lblEndTime1.Text = "ساعت پایان:";
            this.lblEndTime1.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // TimeEnd1
            // 
            this.TimeEnd1.AllowEmptyState = false;
            this.TimeEnd1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.TimeEnd1.BackgroundStyle.Class = "DateTimeInputBackground";
            this.TimeEnd1.CustomFormat = "HH:mm";
            this.TimeEnd1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.TimeEnd1.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.TimeEnd1.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.TimeEnd1.Location = new System.Drawing.Point(207, 28);
            // 
            // 
            // 
            this.TimeEnd1.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.TimeEnd1.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.TimeEnd1.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.TimeEnd1.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.TimeEnd1.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.TimeEnd1.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.TimeEnd1.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.TimeEnd1.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.TimeEnd1.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.TimeEnd1.MonthCalendar.DisplayMonth = new System.DateTime(2008, 10, 1, 0, 0, 0, 0);
            this.TimeEnd1.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Saturday;
            this.TimeEnd1.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.TimeEnd1.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.TimeEnd1.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.TimeEnd1.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.TimeEnd1.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.TimeEnd1.MonthCalendar.TodayButtonVisible = true;
            this.TimeEnd1.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.TimeEnd1.Name = "TimeEnd1";
            this.TimeEnd1.ShowUpDown = true;
            this.TimeEnd1.Size = new System.Drawing.Size(74, 21);
            this.TimeEnd1.TabIndex = 10;
            this.TimeEnd1.Tag = "RefData";
            this.TimeEnd1.Value = new System.DateTime(((long)(0)));
            this.TimeEnd1.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            // 
            // lblCapacity1
            // 
            this.lblCapacity1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCapacity1.AutoSize = true;
            this.lblCapacity1.BackColor = System.Drawing.Color.Transparent;
            this.lblCapacity1.Location = new System.Drawing.Point(467, 56);
            this.lblCapacity1.Name = "lblCapacity1";
            this.lblCapacity1.Size = new System.Drawing.Size(43, 16);
            this.lblCapacity1.TabIndex = 11;
            this.lblCapacity1.Text = "ظرفیت:";
            this.lblCapacity1.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // txtCapacity1
            // 
            this.txtCapacity1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtCapacity1.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtCapacity1.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtCapacity1.Location = new System.Drawing.Point(410, 54);
            this.txtCapacity1.MaxValue = 300;
            this.txtCapacity1.MinValue = 1;
            this.txtCapacity1.Name = "txtCapacity1";
            this.txtCapacity1.ShowUpDown = true;
            this.txtCapacity1.Size = new System.Drawing.Size(51, 21);
            this.txtCapacity1.TabIndex = 12;
            this.txtCapacity1.Value = 1;
            // 
            // lblRoundMin1
            // 
            this.lblRoundMin1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRoundMin1.AutoSize = true;
            this.lblRoundMin1.BackColor = System.Drawing.Color.Transparent;
            this.lblRoundMin1.Location = new System.Drawing.Point(289, 56);
            this.lblRoundMin1.Name = "lblRoundMin1";
            this.lblRoundMin1.Size = new System.Drawing.Size(119, 16);
            this.lblRoundMin1.TabIndex = 15;
            this.lblRoundMin1.Text = "وقت گرد شود بر مبنای";
            this.lblRoundMin1.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // txtRoundMin1
            // 
            this.txtRoundMin1.AllowEmptyState = false;
            this.txtRoundMin1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtRoundMin1.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtRoundMin1.ButtonClear.Visible = true;
            this.txtRoundMin1.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtRoundMin1.Location = new System.Drawing.Point(215, 54);
            this.txtRoundMin1.MaxValue = 90;
            this.txtRoundMin1.MinValue = 0;
            this.txtRoundMin1.Name = "txtRoundMin1";
            this.txtRoundMin1.ShowUpDown = true;
            this.txtRoundMin1.Size = new System.Drawing.Size(66, 21);
            this.txtRoundMin1.TabIndex = 16;
            this.txtRoundMin1.Validating += new System.ComponentModel.CancelEventHandler(this.txtRoundMin1_Validating);
            // 
            // lblMin1
            // 
            this.lblMin1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMin1.AutoSize = true;
            this.lblMin1.BackColor = System.Drawing.Color.Transparent;
            this.lblMin1.Location = new System.Drawing.Point(179, 56);
            this.lblMin1.Name = "lblMin1";
            this.lblMin1.Size = new System.Drawing.Size(36, 16);
            this.lblMin1.TabIndex = 17;
            this.lblMin1.Text = "دقیقه.";
            this.lblMin1.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // Panel2
            // 
            this.Panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.Panel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.Panel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.Panel2.Controls.Add(this.lblDayOfWeek);
            this.Panel2.Controls.Add(this.cboWeekDays);
            this.Panel2.Controls.Add(this.lblStartTime2);
            this.Panel2.Controls.Add(this.TimeStart2);
            this.Panel2.Controls.Add(this.lblEndTime2);
            this.Panel2.Controls.Add(this.TimeEnd2);
            this.Panel2.Controls.Add(this.lblCapacity2);
            this.Panel2.Controls.Add(this.txtCapacity2);
            this.Panel2.Controls.Add(this.lblRoundMin2);
            this.Panel2.Controls.Add(this.txtRoundMin2);
            this.Panel2.Controls.Add(this.lblMin2);
            this.Panel2.Controls.Add(this.btnAddNewDay);
            this.Panel2.Controls.Add(this.dgvData);
            this.Panel2.DrawTitleBox = false;
            this.Panel2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Panel2.Location = new System.Drawing.Point(12, 242);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(524, 237);
            // 
            // 
            // 
            this.Panel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.Panel2.Style.BackColorGradientAngle = 90;
            this.Panel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.Panel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.Panel2.Style.BorderBottomWidth = 1;
            this.Panel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.Panel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.Panel2.Style.BorderLeftWidth = 1;
            this.Panel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.Panel2.Style.BorderRightWidth = 1;
            this.Panel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.Panel2.Style.BorderTopWidth = 1;
            this.Panel2.Style.CornerDiameter = 4;
            this.Panel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.Panel2.Style.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(0)))));
            this.Panel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.Panel2.TabIndex = 10;
            this.Panel2.Tag = "ctrl";
            this.Panel2.Text = "مدیریت برنامه های شناور";
            // 
            // lblDayOfWeek
            // 
            this.lblDayOfWeek.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDayOfWeek.AutoSize = true;
            this.lblDayOfWeek.BackColor = System.Drawing.Color.Transparent;
            this.lblDayOfWeek.ForeColor = System.Drawing.Color.Green;
            this.lblDayOfWeek.Location = new System.Drawing.Point(465, 5);
            this.lblDayOfWeek.Name = "lblDayOfWeek";
            this.lblDayOfWeek.Size = new System.Drawing.Size(52, 16);
            this.lblDayOfWeek.TabIndex = 0;
            this.lblDayOfWeek.Text = "روز هفته:";
            this.lblDayOfWeek.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // cboWeekDays
            // 
            this.cboWeekDays.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboWeekDays.DisplayMember = "Text";
            this.cboWeekDays.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWeekDays.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.cboWeekDays.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cboWeekDays.FormattingEnabled = true;
            this.cboWeekDays.ItemHeight = 13;
            this.cboWeekDays.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2,
            this.comboItem3,
            this.comboItem4,
            this.comboItem5,
            this.comboItem6,
            this.comboItem7});
            this.cboWeekDays.Location = new System.Drawing.Point(361, 3);
            this.cboWeekDays.Name = "cboWeekDays";
            this.cboWeekDays.Size = new System.Drawing.Size(100, 21);
            this.cboWeekDays.TabIndex = 1;
            this.cboWeekDays.Tag = "";
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "شنبه";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "یكشنبه";
            // 
            // comboItem3
            // 
            this.comboItem3.Text = "دوشنبه";
            // 
            // comboItem4
            // 
            this.comboItem4.Text = "سه شنبه";
            // 
            // comboItem5
            // 
            this.comboItem5.Text = "چهارشنبه";
            // 
            // comboItem6
            // 
            this.comboItem6.Text = "پنج شنبه";
            // 
            // comboItem7
            // 
            this.comboItem7.Text = "جمعه";
            // 
            // lblStartTime2
            // 
            this.lblStartTime2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStartTime2.AutoSize = true;
            this.lblStartTime2.BackColor = System.Drawing.Color.Transparent;
            this.lblStartTime2.ForeColor = System.Drawing.Color.Green;
            this.lblStartTime2.Location = new System.Drawing.Point(284, 5);
            this.lblStartTime2.Name = "lblStartTime2";
            this.lblStartTime2.Size = new System.Drawing.Size(75, 16);
            this.lblStartTime2.TabIndex = 2;
            this.lblStartTime2.Text = "ساعت شروع:";
            this.lblStartTime2.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // TimeStart2
            // 
            this.TimeStart2.AllowEmptyState = false;
            this.TimeStart2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.TimeStart2.BackgroundStyle.Class = "DateTimeInputBackground";
            this.TimeStart2.CustomFormat = "HH:mm";
            this.TimeStart2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.TimeStart2.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.TimeStart2.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.TimeStart2.Location = new System.Drawing.Point(209, 3);
            // 
            // 
            // 
            this.TimeStart2.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.TimeStart2.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.TimeStart2.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.TimeStart2.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.TimeStart2.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.TimeStart2.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.TimeStart2.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.TimeStart2.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.TimeStart2.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.TimeStart2.MonthCalendar.DisplayMonth = new System.DateTime(2008, 10, 1, 0, 0, 0, 0);
            this.TimeStart2.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Saturday;
            this.TimeStart2.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.TimeStart2.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.TimeStart2.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.TimeStart2.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.TimeStart2.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.TimeStart2.MonthCalendar.TodayButtonVisible = true;
            this.TimeStart2.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.TimeStart2.Name = "TimeStart2";
            this.TimeStart2.ShowUpDown = true;
            this.TimeStart2.Size = new System.Drawing.Size(72, 21);
            this.TimeStart2.TabIndex = 3;
            this.TimeStart2.Tag = "RefData";
            this.TimeStart2.Value = new System.DateTime(((long)(0)));
            this.TimeStart2.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            // 
            // lblEndTime2
            // 
            this.lblEndTime2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEndTime2.AutoSize = true;
            this.lblEndTime2.BackColor = System.Drawing.Color.Transparent;
            this.lblEndTime2.ForeColor = System.Drawing.Color.Green;
            this.lblEndTime2.Location = new System.Drawing.Point(136, 5);
            this.lblEndTime2.Name = "lblEndTime2";
            this.lblEndTime2.Size = new System.Drawing.Size(68, 16);
            this.lblEndTime2.TabIndex = 4;
            this.lblEndTime2.Text = "ساعت پایان:";
            this.lblEndTime2.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // TimeEnd2
            // 
            this.TimeEnd2.AllowEmptyState = false;
            this.TimeEnd2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.TimeEnd2.BackgroundStyle.Class = "DateTimeInputBackground";
            this.TimeEnd2.CustomFormat = "HH:mm";
            this.TimeEnd2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.TimeEnd2.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.TimeEnd2.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.TimeEnd2.Location = new System.Drawing.Point(58, 3);
            // 
            // 
            // 
            this.TimeEnd2.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.TimeEnd2.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.TimeEnd2.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.TimeEnd2.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.TimeEnd2.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.TimeEnd2.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.TimeEnd2.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.TimeEnd2.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.TimeEnd2.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.TimeEnd2.MonthCalendar.DisplayMonth = new System.DateTime(2008, 10, 1, 0, 0, 0, 0);
            this.TimeEnd2.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Saturday;
            this.TimeEnd2.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.TimeEnd2.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.TimeEnd2.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.TimeEnd2.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.TimeEnd2.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.TimeEnd2.MonthCalendar.TodayButtonVisible = true;
            this.TimeEnd2.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.TimeEnd2.Name = "TimeEnd2";
            this.TimeEnd2.ShowUpDown = true;
            this.TimeEnd2.Size = new System.Drawing.Size(72, 21);
            this.TimeEnd2.TabIndex = 5;
            this.TimeEnd2.Tag = "RefData";
            this.TimeEnd2.Value = new System.DateTime(((long)(0)));
            this.TimeEnd2.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            // 
            // lblCapacity2
            // 
            this.lblCapacity2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCapacity2.AutoSize = true;
            this.lblCapacity2.BackColor = System.Drawing.Color.Transparent;
            this.lblCapacity2.ForeColor = System.Drawing.Color.Green;
            this.lblCapacity2.Location = new System.Drawing.Point(467, 39);
            this.lblCapacity2.Name = "lblCapacity2";
            this.lblCapacity2.Size = new System.Drawing.Size(43, 16);
            this.lblCapacity2.TabIndex = 6;
            this.lblCapacity2.Text = "ظرفیت:";
            this.lblCapacity2.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // txtCapacity2
            // 
            this.txtCapacity2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtCapacity2.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtCapacity2.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtCapacity2.Location = new System.Drawing.Point(410, 37);
            this.txtCapacity2.MaxValue = 300;
            this.txtCapacity2.MinValue = 1;
            this.txtCapacity2.Name = "txtCapacity2";
            this.txtCapacity2.ShowUpDown = true;
            this.txtCapacity2.Size = new System.Drawing.Size(51, 21);
            this.txtCapacity2.TabIndex = 7;
            this.txtCapacity2.Value = 1;
            // 
            // lblRoundMin2
            // 
            this.lblRoundMin2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRoundMin2.AutoSize = true;
            this.lblRoundMin2.BackColor = System.Drawing.Color.Transparent;
            this.lblRoundMin2.ForeColor = System.Drawing.Color.Green;
            this.lblRoundMin2.Location = new System.Drawing.Point(289, 39);
            this.lblRoundMin2.Name = "lblRoundMin2";
            this.lblRoundMin2.Size = new System.Drawing.Size(119, 16);
            this.lblRoundMin2.TabIndex = 10;
            this.lblRoundMin2.Text = "وقت گرد شود بر مبنای";
            this.lblRoundMin2.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // txtRoundMin2
            // 
            this.txtRoundMin2.AllowEmptyState = false;
            this.txtRoundMin2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtRoundMin2.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtRoundMin2.ButtonClear.Visible = true;
            this.txtRoundMin2.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtRoundMin2.Location = new System.Drawing.Point(215, 37);
            this.txtRoundMin2.MaxValue = 90;
            this.txtRoundMin2.MinValue = 0;
            this.txtRoundMin2.Name = "txtRoundMin2";
            this.txtRoundMin2.ShowUpDown = true;
            this.txtRoundMin2.Size = new System.Drawing.Size(66, 21);
            this.txtRoundMin2.TabIndex = 11;
            this.txtRoundMin2.Validating += new System.ComponentModel.CancelEventHandler(this.txtRoundMin2_Validating);
            // 
            // lblMin2
            // 
            this.lblMin2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMin2.AutoSize = true;
            this.lblMin2.BackColor = System.Drawing.Color.Transparent;
            this.lblMin2.ForeColor = System.Drawing.Color.Green;
            this.lblMin2.Location = new System.Drawing.Point(179, 39);
            this.lblMin2.Name = "lblMin2";
            this.lblMin2.Size = new System.Drawing.Size(36, 16);
            this.lblMin2.TabIndex = 12;
            this.lblMin2.Text = "دقیقه.";
            this.lblMin2.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // btnAddNewDay
            // 
            this.btnAddNewDay.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddNewDay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNewDay.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAddNewDay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnAddNewDay.Image = global::Sepehr.Settings.Schedules.Properties.Resources.AddMed;
            this.btnAddNewDay.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnAddNewDay.Location = new System.Drawing.Point(103, 32);
            this.btnAddNewDay.Name = "btnAddNewDay";
            this.btnAddNewDay.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor();
            this.btnAddNewDay.Size = new System.Drawing.Size(71, 31);
            this.btnAddNewDay.TabIndex = 13;
            this.btnAddNewDay.Tag = "Ins1";
            this.btnAddNewDay.Text = "افزودن";
            this.btnAddNewDay.Click += new System.EventHandler(this.btnAddNewDay_Click);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToOrderColumns = true;
            this.dgvData.AllowUserToResizeColumns = false;
            this.dgvData.AllowUserToResizeRows = false;
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.BackgroundColor = System.Drawing.Color.LightSkyBlue;
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
            this.ColDayNo,
            this.ColDay,
            this.ColBeginTime,
            this.ColEndTime,
            this.ColCapacity,
            this.ColRoundMin});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvData.Location = new System.Drawing.Point(9, 69);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(503, 140);
            this.dgvData.TabIndex = 14;
            this.dgvData.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvData_CellValidating);
            this.dgvData.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvData_DataError);
            // 
            // ColDayNo
            // 
            this.ColDayNo.HeaderText = "ColDayNo";
            this.ColDayNo.Name = "ColDayNo";
            this.ColDayNo.Visible = false;
            // 
            // ColDay
            // 
            this.ColDay.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColDay.HeaderText = "روز هفته";
            this.ColDay.Name = "ColDay";
            this.ColDay.ReadOnly = true;
            this.ColDay.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ColBeginTime
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "HH:mm";
            dataGridViewCellStyle2.NullValue = null;
            this.ColBeginTime.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColBeginTime.HeaderText = "ساعت شروع";
            this.ColBeginTime.Name = "ColBeginTime";
            // 
            // ColEndTime
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "HH:mm";
            this.ColEndTime.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColEndTime.HeaderText = "ساعت پایان";
            this.ColEndTime.Name = "ColEndTime";
            // 
            // ColCapacity
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColCapacity.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColCapacity.HeaderText = "ظرفیت";
            this.ColCapacity.Name = "ColCapacity";
            this.ColCapacity.Width = 70;
            // 
            // ColRoundMin
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColRoundMin.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColRoundMin.HeaderText = "گرد";
            this.ColRoundMin.Name = "ColRoundMin";
            this.ColRoundMin.Width = 70;
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescription.AutoSize = true;
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblDescription.Location = new System.Drawing.Point(482, 487);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(53, 16);
            this.lblDescription.TabIndex = 11;
            this.lblDescription.Text = "توضیحات:";
            this.lblDescription.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtDescription.Border.Class = "TextBoxBorder";
            this.txtDescription.Location = new System.Drawing.Point(12, 485);
            this.txtDescription.MaxLength = 300;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(466, 21);
            this.txtDescription.TabIndex = 12;
            this.txtDescription.Tag = "ctrl";
            this.txtDescription.WatermarkText = "توضیحاتی پیرامون برنامه نوبت دهی";
            this.txtDescription.Validating += new System.ComponentModel.CancelEventHandler(this.Controls_Validating);
            // 
            // btnHelp
            // 
            this.btnHelp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnHelp.Image = global::Sepehr.Settings.Schedules.Properties.Resources.Help;
            this.btnHelp.Location = new System.Drawing.Point(440, 513);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F1);
            this.btnHelp.Size = new System.Drawing.Size(95, 57);
            this.btnHelp.TabIndex = 15;
            this.btnHelp.TabStop = false;
            this.btnHelp.Tag = "ctrl";
            this.btnHelp.Text = "راهنما\r\n(F1)";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Sepehr.Settings.Schedules.Properties.Resources.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(113, 513);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 57);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.TabStop = false;
            this.btnCancel.Tag = "ctrl";
            this.btnCancel.Text = "انصراف\r\n(Esc)";
            // 
            // btnAccept
            // 
            this.btnAccept.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAccept.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAccept.Image = global::Sepehr.Settings.Schedules.Properties.Resources.Accept;
            this.btnAccept.Location = new System.Drawing.Point(12, 513);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnAccept.Size = new System.Drawing.Size(95, 57);
            this.btnAccept.TabIndex = 13;
            this.btnAccept.TabStop = false;
            this.btnAccept.Tag = "ctrl";
            this.btnAccept.Text = "تایید\r\n(F8)";
            this.btnAccept.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            // 
            // FormErrorProvider
            // 
            this.FormErrorProvider.ContainerControl = this;
            this.FormErrorProvider.RightToLeft = true;
            // 
            // BWFormThread
            // 
            this.BWFormThread.WorkerReportsProgress = true;
            this.BWFormThread.WorkerSupportsCancellation = true;
            this.BWFormThread.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BWFormThread_DoWork);
            this.BWFormThread.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BWFormThread_RunWorkerCompleted);
            // 
            // frmAppsAdd
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(547, 584);
            this.Controls.Add(this.FormPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAppsAdd";
            this.Opacity = 0.01;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تنظیمات - نوبت دهی تصویربرداری - تعریف برنامه نوبت دهی";
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.FormPanel.ResumeLayout(false);
            this.FormPanel.PerformLayout();
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimeStart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeEnd1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCapacity1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoundMin1)).EndInit();
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimeStart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeEnd2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCapacity2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoundMin2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FormErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel FormPanel;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnAccept;
        private DevComponents.DotNetBar.ButtonX btnHelp;
        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxFixApps;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxIsActive;
        private DevComponents.DotNetBar.LabelX lblDescription;
        private DevComponents.DotNetBar.LabelX lblAppName;
        private Negar.PersianCalendar.UI.Controls.PersianDatePicker DateAppEnd;
        private Negar.PersianCalendar.UI.Controls.PersianDatePicker DateAppStart;
        private DevComponents.DotNetBar.LabelX lblAppEnd;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDescription;
        private DevComponents.DotNetBar.Controls.TextBoxX txtAppName;
        private DevComponents.DotNetBar.LabelX lblAppStart;
        private DevComponents.DotNetBar.LabelX lblTitle;
        private DevComponents.DotNetBar.Controls.GroupPanel Panel1;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxDay7;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxDay6;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxDay5;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxDay4;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxDay3;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxDay2;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxDay1;
        private DevComponents.Editors.IntegerInput txtRoundMin1;
        private DevComponents.Editors.IntegerInput txtCapacity1;
        private DevComponents.DotNetBar.LabelX lblRoundMin1;
        private DevComponents.DotNetBar.LabelX lblCapacity1;
        private DevComponents.DotNetBar.LabelX lblMin1;
        private DevComponents.DotNetBar.LabelX lblEndTime1;
        private DevComponents.DotNetBar.LabelX lblStartTime1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput TimeEnd1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput TimeStart1;
        private DevComponents.DotNetBar.Controls.GroupPanel Panel2;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxNoneFixApps;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboWeekDays;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.Editors.ComboItem comboItem3;
        private DevComponents.Editors.ComboItem comboItem4;
        private DevComponents.Editors.ComboItem comboItem5;
        private DevComponents.Editors.ComboItem comboItem6;
        private DevComponents.Editors.ComboItem comboItem7;
        private DevComponents.DotNetBar.LabelX lblDayOfWeek;
        private DevComponents.DotNetBar.ButtonX btnAddNewDay;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput TimeEnd2;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput TimeStart2;
        private DevComponents.DotNetBar.LabelX lblStartTime2;
        private DevComponents.Editors.IntegerInput txtRoundMin2;
        private DevComponents.DotNetBar.LabelX lblCapacity2;
        private DevComponents.DotNetBar.LabelX lblEndTime2;
        private DevComponents.Editors.IntegerInput txtCapacity2;
        private DevComponents.DotNetBar.LabelX lblMin2;
        private DevComponents.DotNetBar.LabelX lblRoundMin2;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvData;
        private System.Windows.Forms.ErrorProvider FormErrorProvider;
        private DevComponents.DotNetBar.Controls.ProgressBarX ProgressBar;
        private System.ComponentModel.BackgroundWorker BWFormThread;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDayNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBeginTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColEndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCapacity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRoundMin;
    }
}