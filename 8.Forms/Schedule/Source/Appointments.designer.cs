namespace Sepehr.Forms.Schedules
{
    partial class frmAppointments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAppointments));
            this.ScheduleMenu = new DevComponents.DotNetBar.ButtonItem();
            this.cmsSchedules = new DevComponents.DotNetBar.ContextMenuBar();
            this.cmsGridView = new DevComponents.DotNetBar.ButtonItem();
            this.btnIsActive = new DevComponents.DotNetBar.ButtonItem();
            this.btnSelectNextApp = new DevComponents.DotNetBar.ButtonX();
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.BarSchedules = new DevComponents.DotNetBar.PanelEx();
            this.PanelCurrentSchData = new System.Windows.Forms.Panel();
            this.lblCurrentAppUsedShifts = new DevComponents.DotNetBar.LabelX();
            this.lblCurrentAppShiftCount = new DevComponents.DotNetBar.LabelX();
            this.lblCurrentDayOfWeek = new DevComponents.DotNetBar.LabelX();
            this.btnCurrentDate = new DevComponents.DotNetBar.ButtonX();
            this.PanelApplications = new DevComponents.DotNetBar.PanelEx();
            this.lblDescription = new System.Windows.Forms.Label();
            this.cboApplications = new System.Windows.Forms.ComboBox();
            this.lblAppName = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCopy = new DevComponents.DotNetBar.ButtonItem();
            this.btnCut = new DevComponents.DotNetBar.ButtonItem();
            this.btnPaste = new DevComponents.DotNetBar.ButtonItem();
            this.btnPatFileManage = new DevComponents.DotNetBar.ButtonItem();
            this.btnAdmitNewRef = new DevComponents.DotNetBar.ButtonItem();
            this.btnSelectPat = new DevComponents.DotNetBar.ButtonItem();
            this.btnSelectRef = new DevComponents.DotNetBar.ButtonItem();
            this.btnViewPatData = new DevComponents.DotNetBar.ButtonItem();
            this.btnViewRefData = new DevComponents.DotNetBar.ButtonItem();
            this.btnClear = new DevComponents.DotNetBar.ButtonItem();
            this.btnEdit = new DevComponents.DotNetBar.ButtonItem();
            this.btnAppointmentLog = new DevComponents.DotNetBar.ButtonItem();
            this.btnSearchPatientName = new DevComponents.DotNetBar.ButtonItem();
            this.btnFreeAppointment = new DevComponents.DotNetBar.ButtonItem();
            this.btnRemove = new DevComponents.DotNetBar.ButtonItem();
            this.btnHelp = new DevComponents.DotNetBar.ButtonX();
            this.btnPrintTable = new DevComponents.DotNetBar.ButtonX();
            this.btnFindPatientSchedule = new DevComponents.DotNetBar.ButtonX();
            this.btnSearchApplications = new DevComponents.DotNetBar.ButtonX();
            this.btnPasteShiftApps = new DevComponents.DotNetBar.ButtonX();
            this.btnCopyShiftApps = new DevComponents.DotNetBar.ButtonX();
            this.btnAddAppointment = new DevComponents.DotNetBar.ButtonX();
            this.btnRefresh = new DevComponents.DotNetBar.ButtonX();
            this.btnNextShift = new DevComponents.DotNetBar.ButtonX();
            this.btnPrevShift = new DevComponents.DotNetBar.ButtonX();
            this.btnAppDetail = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.cmsSchedules)).BeginInit();
            this.BarSchedules.SuspendLayout();
            this.PanelCurrentSchData.SuspendLayout();
            this.PanelApplications.SuspendLayout();
            this.SuspendLayout();
            // 
            // ScheduleMenu
            // 
            this.ScheduleMenu.AutoExpandOnClick = true;
            this.ScheduleMenu.ImagePaddingHorizontal = 8;
            this.ScheduleMenu.Name = "ScheduleMenu";
            this.ScheduleMenu.Text = "منوی مدیریت نوبتدهی";
            // 
            // cmsSchedules
            // 
            this.cmsSchedules.AntiAlias = true;
            this.cmsSchedules.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmsSchedules.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.cmsGridView});
            this.cmsSchedules.Location = new System.Drawing.Point(688, 101);
            this.cmsSchedules.Name = "cmsSchedules";
            this.cmsSchedules.Size = new System.Drawing.Size(89, 25);
            this.cmsSchedules.Stretch = true;
            this.cmsSchedules.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.cmsSchedules.TabIndex = 27;
            this.cmsSchedules.TabStop = false;
            this.cmsSchedules.Text = "cmsSchedules";
            // 
            // cmsGridView
            // 
            this.cmsGridView.AutoExpandOnClick = true;
            this.cmsGridView.ImagePaddingHorizontal = 8;
            this.cmsGridView.Name = "cmsGridView";
            this.cmsGridView.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlP);
            this.cmsGridView.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnCopy,
            this.btnCut,
            this.btnPaste,
            this.btnPatFileManage,
            this.btnClear,
            this.btnEdit,
            this.btnIsActive,
            this.btnAppointmentLog,
            this.btnSearchPatientName,
            this.btnFreeAppointment,
            this.btnRemove});
            this.cmsGridView.Text = "منوی كمكی";
            this.cmsGridView.Visible = false;
            this.cmsGridView.PopupOpen += new DevComponents.DotNetBar.DotNetBarManager.PopupOpenEventHandler(this.cmsGridView_PopupOpen);
            // 
            // btnIsActive
            // 
            this.btnIsActive.Checked = true;
            this.btnIsActive.ForeColor = System.Drawing.Color.Navy;
            this.btnIsActive.ImagePaddingHorizontal = 8;
            this.btnIsActive.Name = "btnIsActive";
            this.btnIsActive.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F2);
            this.btnIsActive.Text = "<b>فعال بودن نوبت</b>";
            this.btnIsActive.Click += new System.EventHandler(this.btnIsActive_Click);
            // 
            // btnSelectNextApp
            // 
            this.btnSelectNextApp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelectNextApp.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnSelectNextApp.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSelectNextApp.Location = new System.Drawing.Point(0, -50);
            this.btnSelectNextApp.Name = "btnSelectNextApp";
            this.btnSelectNextApp.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);
            this.btnSelectNextApp.Size = new System.Drawing.Size(20, 20);
            this.btnSelectNextApp.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.btnSelectNextApp.TabIndex = 28;
            this.btnSelectNextApp.TabStop = false;
            this.btnSelectNextApp.Click += new System.EventHandler(this.btnSelectAppFromList_Click);
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            // 
            // BarSchedules
            // 
            this.BarSchedules.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.BarSchedules.Controls.Add(this.btnHelp);
            this.BarSchedules.Controls.Add(this.btnPrintTable);
            this.BarSchedules.Controls.Add(this.btnFindPatientSchedule);
            this.BarSchedules.Controls.Add(this.btnSearchApplications);
            this.BarSchedules.Controls.Add(this.btnPasteShiftApps);
            this.BarSchedules.Controls.Add(this.btnCopyShiftApps);
            this.BarSchedules.Controls.Add(this.btnAddAppointment);
            this.BarSchedules.Controls.Add(this.btnRefresh);
            this.BarSchedules.Controls.Add(this.btnNextShift);
            this.BarSchedules.Controls.Add(this.PanelCurrentSchData);
            this.BarSchedules.Controls.Add(this.btnPrevShift);
            this.BarSchedules.Controls.Add(this.PanelApplications);
            this.BarSchedules.Dock = System.Windows.Forms.DockStyle.Top;
            this.BarSchedules.Location = new System.Drawing.Point(0, 0);
            this.BarSchedules.Name = "BarSchedules";
            this.BarSchedules.Size = new System.Drawing.Size(784, 83);
            this.BarSchedules.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.BarSchedules.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.BarSchedules.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.BarSchedules.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.BarSchedules.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.BarSchedules.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.BarSchedules.Style.GradientAngle = 90;
            this.BarSchedules.TabIndex = 0;
            // 
            // PanelCurrentSchData
            // 
            this.PanelCurrentSchData.Controls.Add(this.lblCurrentAppUsedShifts);
            this.PanelCurrentSchData.Controls.Add(this.lblCurrentAppShiftCount);
            this.PanelCurrentSchData.Controls.Add(this.lblCurrentDayOfWeek);
            this.PanelCurrentSchData.Controls.Add(this.btnCurrentDate);
            this.PanelCurrentSchData.Dock = System.Windows.Forms.DockStyle.Right;
            this.PanelCurrentSchData.Location = new System.Drawing.Point(374, 0);
            this.PanelCurrentSchData.Name = "PanelCurrentSchData";
            this.PanelCurrentSchData.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.PanelCurrentSchData.Size = new System.Drawing.Size(129, 83);
            this.PanelCurrentSchData.TabIndex = 15;
            // 
            // lblCurrentAppUsedShifts
            // 
            this.lblCurrentAppUsedShifts.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.lblCurrentAppUsedShifts.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblCurrentAppUsedShifts.BackgroundStyle.BorderBottomWidth = 1;
            this.lblCurrentAppUsedShifts.BackgroundStyle.BorderColor = System.Drawing.Color.Navy;
            this.lblCurrentAppUsedShifts.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblCurrentAppUsedShifts.BackgroundStyle.BorderLeftWidth = 1;
            this.lblCurrentAppUsedShifts.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblCurrentAppUsedShifts.BackgroundStyle.BorderRightWidth = 1;
            this.lblCurrentAppUsedShifts.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblCurrentAppUsedShifts.BackgroundStyle.BorderTopWidth = 1;
            this.lblCurrentAppUsedShifts.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCurrentAppUsedShifts.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblCurrentAppUsedShifts.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblCurrentAppUsedShifts.Location = new System.Drawing.Point(0, 61);
            this.lblCurrentAppUsedShifts.Name = "lblCurrentAppUsedShifts";
            this.lblCurrentAppUsedShifts.Size = new System.Drawing.Size(129, 20);
            this.lblCurrentAppUsedShifts.TabIndex = 3;
            this.lblCurrentAppUsedShifts.Text = "اشغال";
            this.lblCurrentAppUsedShifts.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lblCurrentAppShiftCount
            // 
            this.lblCurrentAppShiftCount.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.lblCurrentAppShiftCount.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblCurrentAppShiftCount.BackgroundStyle.BorderBottomWidth = 1;
            this.lblCurrentAppShiftCount.BackgroundStyle.BorderColor = System.Drawing.Color.Navy;
            this.lblCurrentAppShiftCount.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblCurrentAppShiftCount.BackgroundStyle.BorderLeftWidth = 1;
            this.lblCurrentAppShiftCount.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblCurrentAppShiftCount.BackgroundStyle.BorderRightWidth = 1;
            this.lblCurrentAppShiftCount.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblCurrentAppShiftCount.BackgroundStyle.BorderTopWidth = 1;
            this.lblCurrentAppShiftCount.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCurrentAppShiftCount.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblCurrentAppShiftCount.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblCurrentAppShiftCount.Location = new System.Drawing.Point(0, 41);
            this.lblCurrentAppShiftCount.Name = "lblCurrentAppShiftCount";
            this.lblCurrentAppShiftCount.Size = new System.Drawing.Size(129, 20);
            this.lblCurrentAppShiftCount.TabIndex = 2;
            this.lblCurrentAppShiftCount.Text = "تعداد نوبت ها";
            this.lblCurrentAppShiftCount.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lblCurrentDayOfWeek
            // 
            this.lblCurrentDayOfWeek.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.lblCurrentDayOfWeek.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblCurrentDayOfWeek.BackgroundStyle.BorderBottomWidth = 1;
            this.lblCurrentDayOfWeek.BackgroundStyle.BorderColor = System.Drawing.Color.Navy;
            this.lblCurrentDayOfWeek.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblCurrentDayOfWeek.BackgroundStyle.BorderLeftWidth = 1;
            this.lblCurrentDayOfWeek.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblCurrentDayOfWeek.BackgroundStyle.BorderRightWidth = 1;
            this.lblCurrentDayOfWeek.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblCurrentDayOfWeek.BackgroundStyle.BorderTopWidth = 1;
            this.lblCurrentDayOfWeek.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCurrentDayOfWeek.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblCurrentDayOfWeek.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblCurrentDayOfWeek.Location = new System.Drawing.Point(0, 21);
            this.lblCurrentDayOfWeek.Name = "lblCurrentDayOfWeek";
            this.lblCurrentDayOfWeek.Size = new System.Drawing.Size(129, 20);
            this.lblCurrentDayOfWeek.TabIndex = 1;
            this.lblCurrentDayOfWeek.Text = "روز هفته";
            this.lblCurrentDayOfWeek.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // btnCurrentDate
            // 
            this.btnCurrentDate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCurrentDate.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCurrentDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCurrentDate.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnCurrentDate.ForeColor = System.Drawing.Color.Blue;
            this.btnCurrentDate.Location = new System.Drawing.Point(0, 1);
            this.btnCurrentDate.Name = "btnCurrentDate";
            this.btnCurrentDate.Size = new System.Drawing.Size(129, 20);
            this.btnCurrentDate.TabIndex = 0;
            this.btnCurrentDate.TabStop = false;
            this.btnCurrentDate.Text = "1390/01/01";
            this.btnCurrentDate.Click += new System.EventHandler(this.btnCurrentDate_Click);
            // 
            // PanelApplications
            // 
            this.PanelApplications.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelApplications.Controls.Add(this.btnAppDetail);
            this.PanelApplications.Controls.Add(this.lblDescription);
            this.PanelApplications.Controls.Add(this.cboApplications);
            this.PanelApplications.Controls.Add(this.lblAppName);
            this.PanelApplications.Dock = System.Windows.Forms.DockStyle.Right;
            this.PanelApplications.Location = new System.Drawing.Point(547, 0);
            this.PanelApplications.Name = "PanelApplications";
            this.PanelApplications.Size = new System.Drawing.Size(237, 83);
            this.PanelApplications.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.PanelApplications.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.PanelApplications.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.PanelApplications.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.PanelApplications.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.PanelApplications.Style.BorderWidth = 2;
            this.PanelApplications.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.PanelApplications.Style.GradientAngle = 90;
            this.PanelApplications.TabIndex = 0;
            // 
            // lblDescription
            // 
            this.lblDescription.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblDescription.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblDescription.ForeColor = System.Drawing.Color.Teal;
            this.lblDescription.Location = new System.Drawing.Point(0, 53);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(237, 30);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "توضیحات برنامه";
            // 
            // cboApplications
            // 
            this.cboApplications.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboApplications.DisplayMember = "Name";
            this.cboApplications.DropDownHeight = 300;
            this.cboApplications.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboApplications.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboApplications.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cboApplications.FormattingEnabled = true;
            this.cboApplications.IntegralHeight = false;
            this.cboApplications.Location = new System.Drawing.Point(7, 27);
            this.cboApplications.Name = "cboApplications";
            this.cboApplications.Size = new System.Drawing.Size(225, 22);
            this.cboApplications.TabIndex = 0;
            this.cboApplications.ValueMember = "ID";
            this.cboApplications.SelectedIndexChanged += new System.EventHandler(this.cboApplications_SelectedIndexChanged);
            // 
            // lblAppName
            // 
            this.lblAppName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAppName.AutoSize = true;
            this.lblAppName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblAppName.ForeColor = System.Drawing.Color.Navy;
            this.lblAppName.Location = new System.Drawing.Point(94, 7);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(141, 14);
            this.lblAppName.TabIndex = 2;
            this.lblAppName.Text = " برنامه های نوبت دهی:";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(50, -50);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 30;
            this.btnClose.Text = "بستن";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnCopy
            // 
            this.btnCopy.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnCopy.Image = global::Sepehr.Forms.Schedules.Properties.Resources.Copy;
            this.btnCopy.ImagePaddingHorizontal = 8;
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlC);
            this.btnCopy.Text = "<b>كپی</b>\r\n<div></div>\r\n<font color=\"#000000\">كپی برداری از این نوبت.</font>";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnCut
            // 
            this.btnCut.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnCut.Image = global::Sepehr.Forms.Schedules.Properties.Resources.Cut;
            this.btnCut.ImagePaddingHorizontal = 8;
            this.btnCut.Name = "btnCut";
            this.btnCut.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlX);
            this.btnCut.Text = "<b>انتقال</b>\r\n<div></div>\r\n<font color=\"#000000\">انتقال این نوبت به حافظه.</font" +
                ">";
            this.btnCut.Click += new System.EventHandler(this.btnCut_Click);
            // 
            // btnPaste
            // 
            this.btnPaste.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnPaste.Image = global::Sepehr.Forms.Schedules.Properties.Resources.Paste;
            this.btnPaste.ImagePaddingHorizontal = 8;
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlV);
            this.btnPaste.Text = "<b>جایگذاری</b>\r\n<div></div>\r\n<font color=\"#000000\">ثبت نوبت حافظه.</font>";
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // btnPatFileManage
            // 
            this.btnPatFileManage.BeginGroup = true;
            this.btnPatFileManage.ForeColor = System.Drawing.Color.Black;
            this.btnPatFileManage.Image = global::Sepehr.Forms.Schedules.Properties.Resources.SchAdmitPat;
            this.btnPatFileManage.ImagePaddingHorizontal = 8;
            this.btnPatFileManage.Name = "btnPatFileManage";
            this.btnPatFileManage.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnAdmitNewRef,
            this.btnSelectPat,
            this.btnSelectRef,
            this.btnViewPatData,
            this.btnViewRefData});
            this.btnPatFileManage.Text = "<b>مدیریت پذیرش بیمار...</b>\r\n<div></div>\r\n<font color=\"#000000\">پرونده و مراجعه " +
                "بیمار.</font>";
            // 
            // btnAdmitNewRef
            // 
            this.btnAdmitNewRef.ForeColor = System.Drawing.Color.Black;
            this.btnAdmitNewRef.Image = global::Sepehr.Forms.Schedules.Properties.Resources.SchAdmitRef;
            this.btnAdmitNewRef.ImagePaddingHorizontal = 8;
            this.btnAdmitNewRef.Name = "btnAdmitNewRef";
            this.btnAdmitNewRef.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnAdmitNewRef.Text = "<b>پذیرش نوبت...</b>\r\n<div></div>\r\n<font color=\"#000000\">بر اساس اطلاعات نوبت.</f" +
                "ont>";
            this.btnAdmitNewRef.Click += new System.EventHandler(this.btnAdmitAsNewRef_Click);
            // 
            // btnSelectPat
            // 
            this.btnSelectPat.BeginGroup = true;
            this.btnSelectPat.ForeColor = System.Drawing.Color.MediumBlue;
            this.btnSelectPat.Image = global::Sepehr.Forms.Schedules.Properties.Resources.PatientSearch;
            this.btnSelectPat.ImagePaddingHorizontal = 8;
            this.btnSelectPat.Name = "btnSelectPat";
            this.btnSelectPat.Text = "<b>انتخاب بیمار...</b>\r\n<div></div>\r\n<font color=\"#000000\">ارتباط بیمار ثبت شده ق" +
                "بلی.</font>";
            this.btnSelectPat.Click += new System.EventHandler(this.btnSelectPat_Click);
            // 
            // btnSelectRef
            // 
            this.btnSelectRef.ForeColor = System.Drawing.Color.MediumBlue;
            this.btnSelectRef.Image = global::Sepehr.Forms.Schedules.Properties.Resources.RefSearch;
            this.btnSelectRef.ImagePaddingHorizontal = 8;
            this.btnSelectRef.Name = "btnSelectRef";
            this.btnSelectRef.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F4);
            this.btnSelectRef.Text = "<b>انتخاب مراجعه...</b>\r\n<div></div>\r\n<font color=\"#000000\">ارتباط مراجعه ثبت شده" +
                " قبلی.</font>";
            this.btnSelectRef.Click += new System.EventHandler(this.btnSelectRef_Click);
            // 
            // btnViewPatData
            // 
            this.btnViewPatData.BeginGroup = true;
            this.btnViewPatData.ForeColor = System.Drawing.Color.Crimson;
            this.btnViewPatData.Image = global::Sepehr.Forms.Schedules.Properties.Resources.PatientFile;
            this.btnViewPatData.ImagePaddingHorizontal = 8;
            this.btnViewPatData.Name = "btnViewPatData";
            this.btnViewPatData.Text = "<b>مشاهده پرونده...</b>\r\n<div></div>\r\n<font color=\"#000000\">مشاهده اطلاعات پرونده" +
                " بیمار.</font>";
            this.btnViewPatData.Click += new System.EventHandler(this.btnViewPatData_Click);
            // 
            // btnViewRefData
            // 
            this.btnViewRefData.ForeColor = System.Drawing.Color.Crimson;
            this.btnViewRefData.Image = global::Sepehr.Forms.Schedules.Properties.Resources.RefData;
            this.btnViewRefData.ImagePaddingHorizontal = 8;
            this.btnViewRefData.Name = "btnViewRefData";
            this.btnViewRefData.Text = "<b>مشاهده مراجعه...</b>\r\n<div></div>\r\n<font color=\"#000000\">مشاهده اطلاعات مراجعه" +
                " بیمار.</font>";
            this.btnViewRefData.Click += new System.EventHandler(this.btnViewRefData_Click);
            // 
            // btnClear
            // 
            this.btnClear.BeginGroup = true;
            this.btnClear.Image = global::Sepehr.Forms.Schedules.Properties.Resources.SchClearShift;
            this.btnClear.ImagePaddingHorizontal = 8;
            this.btnClear.Name = "btnClear";
            this.btnClear.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.Del);
            this.btnClear.Text = "<b>لغو</b>\r\n<div></div>\r\n<font color=\"#000000\">پاك كردن كامل اطلاعات.</font>";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Image = global::Sepehr.Forms.Schedules.Properties.Resources.SchEditApp;
            this.btnEdit.ImagePaddingHorizontal = 8;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlE);
            this.btnEdit.Text = "<b>ویرایش...</b>\r\n<div></div>\r\n<font color=\"#000000\">ویرایش در فرم جداگانه.</font" +
                ">";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAppointmentLog
            // 
            this.btnAppointmentLog.BeginGroup = true;
            this.btnAppointmentLog.ForeColor = System.Drawing.Color.Red;
            this.btnAppointmentLog.Image = global::Sepehr.Forms.Schedules.Properties.Resources.SchInfo;
            this.btnAppointmentLog.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnAppointmentLog.ImagePaddingHorizontal = 8;
            this.btnAppointmentLog.Name = "btnAppointmentLog";
            this.btnAppointmentLog.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlL);
            this.btnAppointmentLog.Text = "<b>سابقه...</b>\r\n<div></div>\r\n<font color=\"#000000\">مشاهده سابقه نوبت.</font>";
            this.btnAppointmentLog.Click += new System.EventHandler(this.btnAppointmentLog_Click);
            // 
            // btnSearchPatientName
            // 
            this.btnSearchPatientName.BeginGroup = true;
            this.btnSearchPatientName.ForeColor = System.Drawing.Color.Black;
            this.btnSearchPatientName.Image = global::Sepehr.Forms.Schedules.Properties.Resources.Find;
            this.btnSearchPatientName.ImagePaddingHorizontal = 8;
            this.btnSearchPatientName.Name = "btnSearchPatientName";
            this.btnSearchPatientName.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F6);
            this.btnSearchPatientName.Text = "<b>جستجوی نوبت...</b>\r\n<div></div>\r\nجستجوی نوبت های مشابه.";
            this.btnSearchPatientName.Click += new System.EventHandler(this.btnSearchPatientName_Click);
            // 
            // btnFreeAppointment
            // 
            this.btnFreeAppointment.BeginGroup = true;
            this.btnFreeAppointment.Image = global::Sepehr.Forms.Schedules.Properties.Resources.FreeLockedRow;
            this.btnFreeAppointment.ImagePaddingHorizontal = 8;
            this.btnFreeAppointment.Name = "btnFreeAppointment";
            this.btnFreeAppointment.Text = "<b>آزاد سازی نوبت</b>\r\n<div></div>\r\n<font color=\"#000000\">آزاد سازی نوبت قفل شده." +
                "</font>";
            this.btnFreeAppointment.Click += new System.EventHandler(this.btnFreeAppointment_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.ForeColor = System.Drawing.Color.Red;
            this.btnRemove.Image = global::Sepehr.Forms.Schedules.Properties.Resources.DeleteMed;
            this.btnRemove.ImagePaddingHorizontal = 8;
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Text = "<b>حذف ردیف نوبت</b>\r\n<div></div>\r\n<font color=\"#000000\">حذف ردیف نوبت از روز جار" +
                "ی.</font>";
            this.btnRemove.Click += new System.EventHandler(this.btnRemoveAppointment_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnHelp.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange;
            this.btnHelp.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnHelp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnHelp.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnHelp.Image = global::Sepehr.Forms.Schedules.Properties.Resources.HelpMed;
            this.btnHelp.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnHelp.Location = new System.Drawing.Point(-48, 0);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(46, 83);
            this.btnHelp.TabIndex = 7;
            this.btnHelp.TabStop = false;
            this.btnHelp.Text = "راهنمای\r\nفرمان ها";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnPrintTable
            // 
            this.btnPrintTable.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPrintTable.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange;
            this.btnPrintTable.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnPrintTable.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnPrintTable.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnPrintTable.Image = global::Sepehr.Forms.Schedules.Properties.Resources.PrintGrid;
            this.btnPrintTable.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnPrintTable.Location = new System.Drawing.Point(-2, 0);
            this.btnPrintTable.Name = "btnPrintTable";
            this.btnPrintTable.Size = new System.Drawing.Size(40, 83);
            this.btnPrintTable.TabIndex = 6;
            this.btnPrintTable.TabStop = false;
            this.btnPrintTable.Text = "چاپ\r\nجدول";
            this.btnPrintTable.Click += new System.EventHandler(this.btnPrintTable_Click);
            // 
            // btnFindPatientSchedule
            // 
            this.btnFindPatientSchedule.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnFindPatientSchedule.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange;
            this.btnFindPatientSchedule.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnFindPatientSchedule.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnFindPatientSchedule.ForeColor = System.Drawing.Color.Green;
            this.btnFindPatientSchedule.Image = global::Sepehr.Forms.Schedules.Properties.Resources.Search;
            this.btnFindPatientSchedule.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnFindPatientSchedule.Location = new System.Drawing.Point(38, 0);
            this.btnFindPatientSchedule.Name = "btnFindPatientSchedule";
            this.btnFindPatientSchedule.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F7);
            this.btnFindPatientSchedule.Size = new System.Drawing.Size(55, 83);
            this.btnFindPatientSchedule.TabIndex = 5;
            this.btnFindPatientSchedule.TabStop = false;
            this.btnFindPatientSchedule.Text = "جستجوی\r\nنوبت بیماران";
            this.btnFindPatientSchedule.Click += new System.EventHandler(this.btnFindPatientSchedule_Click);
            // 
            // btnSearchApplications
            // 
            this.btnSearchApplications.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearchApplications.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange;
            this.btnSearchApplications.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSearchApplications.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSearchApplications.ForeColor = System.Drawing.Color.Green;
            this.btnSearchApplications.Image = global::Sepehr.Forms.Schedules.Properties.Resources.SchSearchApps;
            this.btnSearchApplications.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnSearchApplications.Location = new System.Drawing.Point(93, 0);
            this.btnSearchApplications.Name = "btnSearchApplications";
            this.btnSearchApplications.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlS);
            this.btnSearchApplications.Size = new System.Drawing.Size(54, 83);
            this.btnSearchApplications.TabIndex = 4;
            this.btnSearchApplications.TabStop = false;
            this.btnSearchApplications.Text = "جستجوی\r\nبرنامه ها";
            this.btnSearchApplications.Click += new System.EventHandler(this.btnSearchApplications_Click);
            // 
            // btnPasteShiftApps
            // 
            this.btnPasteShiftApps.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPasteShiftApps.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange;
            this.btnPasteShiftApps.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnPasteShiftApps.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnPasteShiftApps.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnPasteShiftApps.Image = global::Sepehr.Forms.Schedules.Properties.Resources.Paste;
            this.btnPasteShiftApps.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnPasteShiftApps.Location = new System.Drawing.Point(147, 0);
            this.btnPasteShiftApps.Name = "btnPasteShiftApps";
            this.btnPasteShiftApps.Size = new System.Drawing.Size(44, 83);
            this.btnPasteShiftApps.TabIndex = 18;
            this.btnPasteShiftApps.TabStop = false;
            this.btnPasteShiftApps.Text = "جایگذاری\r\nنوبتهای\r\nشیفت";
            this.btnPasteShiftApps.Click += new System.EventHandler(this.btnPasteShiftApps_Click);
            // 
            // btnCopyShiftApps
            // 
            this.btnCopyShiftApps.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCopyShiftApps.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange;
            this.btnCopyShiftApps.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCopyShiftApps.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnCopyShiftApps.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnCopyShiftApps.Image = global::Sepehr.Forms.Schedules.Properties.Resources.Copy;
            this.btnCopyShiftApps.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnCopyShiftApps.Location = new System.Drawing.Point(191, 0);
            this.btnCopyShiftApps.Name = "btnCopyShiftApps";
            this.btnCopyShiftApps.Size = new System.Drawing.Size(44, 83);
            this.btnCopyShiftApps.TabIndex = 17;
            this.btnCopyShiftApps.TabStop = false;
            this.btnCopyShiftApps.Text = "كپی\r\nنوبتهای\r\nشیفت";
            this.btnCopyShiftApps.Click += new System.EventHandler(this.btnCopyShiftApps_Click);
            // 
            // btnAddAppointment
            // 
            this.btnAddAppointment.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddAppointment.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange;
            this.btnAddAppointment.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAddAppointment.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnAddAppointment.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnAddAppointment.Image = global::Sepehr.Forms.Schedules.Properties.Resources.SchAdd;
            this.btnAddAppointment.ImageFixedSize = new System.Drawing.Size(36, 36);
            this.btnAddAppointment.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnAddAppointment.Location = new System.Drawing.Point(235, 0);
            this.btnAddAppointment.Name = "btnAddAppointment";
            this.btnAddAppointment.Size = new System.Drawing.Size(44, 83);
            this.btnAddAppointment.TabIndex = 3;
            this.btnAddAppointment.TabStop = false;
            this.btnAddAppointment.Text = "افزودن\r\nنوبت";
            this.btnAddAppointment.Click += new System.EventHandler(this.btnAddAppointment_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRefresh.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange;
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRefresh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnRefresh.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnRefresh.Image = global::Sepehr.Forms.Schedules.Properties.Resources.Refresh;
            this.btnRefresh.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnRefresh.Location = new System.Drawing.Point(279, 0);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F5);
            this.btnRefresh.Size = new System.Drawing.Size(51, 83);
            this.btnRefresh.TabIndex = 16;
            this.btnRefresh.TabStop = false;
            this.btnRefresh.Text = "بازخوانی\r\nامروز (F5)";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnNextShift
            // 
            this.btnNextShift.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnNextShift.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange;
            this.btnNextShift.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnNextShift.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnNextShift.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnNextShift.Image = global::Sepehr.Forms.Schedules.Properties.Resources.LeftLarge;
            this.btnNextShift.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnNextShift.Location = new System.Drawing.Point(330, 0);
            this.btnNextShift.Name = "btnNextShift";
            this.btnNextShift.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlQ);
            this.btnNextShift.Size = new System.Drawing.Size(44, 83);
            this.btnNextShift.TabIndex = 2;
            this.btnNextShift.TabStop = false;
            this.btnNextShift.Text = "شیفت\r\nبعدی";
            this.btnNextShift.Click += new System.EventHandler(this.btnNextShift_Click);
            // 
            // btnPrevShift
            // 
            this.btnPrevShift.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPrevShift.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange;
            this.btnPrevShift.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnPrevShift.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnPrevShift.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnPrevShift.Image = global::Sepehr.Forms.Schedules.Properties.Resources.RightLarge;
            this.btnPrevShift.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnPrevShift.Location = new System.Drawing.Point(503, 0);
            this.btnPrevShift.Name = "btnPrevShift";
            this.btnPrevShift.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlW);
            this.btnPrevShift.Size = new System.Drawing.Size(44, 83);
            this.btnPrevShift.TabIndex = 1;
            this.btnPrevShift.TabStop = false;
            this.btnPrevShift.Text = "شیفت\r\nقبلی";
            this.btnPrevShift.Click += new System.EventHandler(this.btnPrevShift_Click);
            // 
            // btnAppDetail
            // 
            this.btnAppDetail.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAppDetail.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange;
            this.btnAppDetail.ForeColor = System.Drawing.Color.Black;
            this.btnAppDetail.Image = global::Sepehr.Forms.Schedules.Properties.Resources.InfoSmall;
            this.btnAppDetail.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnAppDetail.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnAppDetail.Location = new System.Drawing.Point(2, 0);
            this.btnAppDetail.Name = "btnAppDetail";
            this.btnAppDetail.Size = new System.Drawing.Size(31, 27);
            this.btnAppDetail.TabIndex = 1;
            this.btnAppDetail.TabStop = false;
            this.btnAppDetail.Click += new System.EventHandler(this.btnShowProgramDetails_Click);
            // 
            // frmAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(784, 570);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cmsSchedules);
            this.Controls.Add(this.btnSelectNextApp);
            this.Controls.Add(this.BarSchedules);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmAppointments";
            this.Opacity = 0.01;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "بیماران - نوبت دهی - فرم مدیریت نوبت بیماران";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.cmsSchedules)).EndInit();
            this.BarSchedules.ResumeLayout(false);
            this.PanelCurrentSchData.ResumeLayout(false);
            this.PanelApplications.ResumeLayout(false);
            this.PanelApplications.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private DevComponents.DotNetBar.ButtonItem ScheduleMenu;
        private DevComponents.DotNetBar.ContextMenuBar cmsSchedules;
        private DevComponents.DotNetBar.ButtonItem cmsGridView;
        private DevComponents.DotNetBar.ButtonItem btnCopy;
        private DevComponents.DotNetBar.ButtonItem btnCut;
        private DevComponents.DotNetBar.ButtonItem btnPaste;
        private DevComponents.DotNetBar.ButtonItem btnRemove;
        private DevComponents.DotNetBar.ButtonItem btnEdit;
        private DevComponents.DotNetBar.ButtonItem btnAdmitNewRef;
        private DevComponents.DotNetBar.ButtonItem btnIsActive;
        private DevComponents.DotNetBar.ButtonItem btnSearchPatientName;
        private DevComponents.DotNetBar.ButtonItem btnClear;
        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        private DevComponents.DotNetBar.ButtonX btnSelectNextApp;
        private DevComponents.DotNetBar.ButtonItem btnFreeAppointment;
        private DevComponents.DotNetBar.PanelEx BarSchedules;
        private DevComponents.DotNetBar.PanelEx PanelApplications;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.ComboBox cboApplications;
        private System.Windows.Forms.Label lblAppName;
        private DevComponents.DotNetBar.ButtonX btnAddAppointment;
        private System.Windows.Forms.Panel PanelCurrentSchData;
        private DevComponents.DotNetBar.LabelX lblCurrentDayOfWeek;
        private DevComponents.DotNetBar.ButtonX btnCurrentDate;
        private DevComponents.DotNetBar.ButtonX btnPrevShift;
        private DevComponents.DotNetBar.ButtonX btnHelp;
        private DevComponents.DotNetBar.ButtonX btnPrintTable;
        private DevComponents.DotNetBar.ButtonX btnFindPatientSchedule;
        private DevComponents.DotNetBar.ButtonX btnSearchApplications;
        private DevComponents.DotNetBar.LabelX lblCurrentAppUsedShifts;
        private DevComponents.DotNetBar.LabelX lblCurrentAppShiftCount;
        private DevComponents.DotNetBar.ButtonX btnNextShift;
        private DevComponents.DotNetBar.ButtonX btnAppDetail;
        private DevComponents.DotNetBar.ButtonX btnRefresh;
        private DevComponents.DotNetBar.ButtonItem btnPatFileManage;
        private DevComponents.DotNetBar.ButtonItem btnSelectPat;
        private DevComponents.DotNetBar.ButtonItem btnSelectRef;
        private DevComponents.DotNetBar.ButtonItem btnViewPatData;
        private DevComponents.DotNetBar.ButtonItem btnViewRefData;
        private System.Windows.Forms.Button btnClose;
        private DevComponents.DotNetBar.ButtonX btnCopyShiftApps;
        private DevComponents.DotNetBar.ButtonX btnPasteShiftApps;
        private DevComponents.DotNetBar.ButtonItem btnAppointmentLog;

    }
}