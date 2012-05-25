namespace Sepehr.Settings.Schedules.Applications
{
    partial class frmApps
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmApps));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.FormPanel = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.cmsForm = new DevComponents.DotNetBar.ContextMenuBar();
            this.cmsMenu = new DevComponents.DotNetBar.ButtonItem();
            this.btnEditBaseData = new DevComponents.DotNetBar.ButtonItem();
            this.btnEditCurrentShift = new DevComponents.DotNetBar.ButtonItem();
            this.btnAddNewShifts = new DevComponents.DotNetBar.ButtonItem();
            this.btnAddDay = new DevComponents.DotNetBar.ButtonItem();
            this.btnRemove = new DevComponents.DotNetBar.ButtonItem();
            this.btnHolidays = new DevComponents.DotNetBar.ButtonX();
            this.btnAdd = new DevComponents.DotNetBar.ButtonX();
            this.cBoxWithInActives = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.dgvData = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ColActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIsWeekly = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColStartDate = new Negar.PersianCalendar.UI.Controls.DataGridViewPersianDateTimePickerColumn();
            this.ColEndDate = new Negar.PersianCalendar.UI.Controls.DataGridViewPersianDateTimePickerColumn();
            this.ColDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnHelp = new DevComponents.DotNetBar.ButtonX();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.FormPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmsForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // FormPanel
            // 
            this.FormPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.FormPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.FormPanel.Controls.Add(this.cmsForm);
            this.FormPanel.Controls.Add(this.btnHolidays);
            this.FormPanel.Controls.Add(this.btnAdd);
            this.FormPanel.Controls.Add(this.cBoxWithInActives);
            this.FormPanel.Controls.Add(this.dgvData);
            this.FormPanel.Controls.Add(this.btnHelp);
            this.FormPanel.Controls.Add(this.btnClose);
            this.FormPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormPanel.Location = new System.Drawing.Point(0, 0);
            this.FormPanel.Name = "FormPanel";
            this.FormPanel.Size = new System.Drawing.Size(790, 570);
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
            // cmsForm
            // 
            this.cmsForm.DockSide = DevComponents.DotNetBar.eDockSide.Document;
            this.cmsForm.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmsForm.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.cmsMenu});
            this.cmsForm.Location = new System.Drawing.Point(420, 479);
            this.cmsForm.Name = "cmsForm";
            this.cmsForm.Size = new System.Drawing.Size(55, 25);
            this.cmsForm.Stretch = true;
            this.cmsForm.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.cmsForm.TabIndex = 11;
            this.cmsForm.TabStop = false;
            // 
            // cmsMenu
            // 
            this.cmsMenu.AutoExpandOnClick = true;
            this.cmsMenu.ImagePaddingHorizontal = 8;
            this.cmsMenu.Name = "cmsMenu";
            this.cmsMenu.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnEditBaseData,
            this.btnEditCurrentShift,
            this.btnAddNewShifts,
            this.btnAddDay,
            this.btnRemove});
            this.cmsMenu.Text = "منو";
            // 
            // btnEditBaseData
            // 
            this.btnEditBaseData.Image = global::Sepehr.Settings.Schedules.Properties.Resources.EditSmall;
            this.btnEditBaseData.ImagePaddingHorizontal = 8;
            this.btnEditBaseData.Name = "btnEditBaseData";
            this.btnEditBaseData.Text = "<b>ویرایش اطلاعات پایه</b>\r\n<div></div>\r\n<font color=\"#000000\">نام ، توضیحات و فع" +
                "ال بودن.</font>";
            this.btnEditBaseData.Click += new System.EventHandler(this.btnEditBaseData_Click);
            // 
            // btnEditCurrentShift
            // 
            this.btnEditCurrentShift.Image = global::Sepehr.Settings.Schedules.Properties.Resources.EditLarge;
            this.btnEditCurrentShift.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnEditCurrentShift.ImagePaddingHorizontal = 8;
            this.btnEditCurrentShift.Name = "btnEditCurrentShift";
            this.btnEditCurrentShift.Text = "<b>ویرایش شیفت های جاری</b>\r\n<div></div>\r\n<font color=\"#000000\">شیفت های تعریف شد" +
                "ه موجود.</font>";
            this.btnEditCurrentShift.Click += new System.EventHandler(this.btnEditCurrentShift_Click);
            // 
            // btnAddNewShifts
            // 
            this.btnAddNewShifts.BeginGroup = true;
            this.btnAddNewShifts.Image = global::Sepehr.Settings.Schedules.Properties.Resources.SchAdmitRef;
            this.btnAddNewShifts.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnAddNewShifts.ImagePaddingHorizontal = 8;
            this.btnAddNewShifts.Name = "btnAddNewShifts";
            this.btnAddNewShifts.Text = "<b>افزودن شیفت های منظم</b>\r\n<div></div>\r\n<font color=\"#000000\">شیفت های منظم جدی" +
                "د.</font>";
            this.btnAddNewShifts.Click += new System.EventHandler(this.btnAddNewShifts_Click);
            // 
            // btnAddDay
            // 
            this.btnAddDay.Enabled = false;
            this.btnAddDay.Image = global::Sepehr.Settings.Schedules.Properties.Resources.AddMed;
            this.btnAddDay.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnAddDay.ImagePaddingHorizontal = 8;
            this.btnAddDay.Name = "btnAddDay";
            this.btnAddDay.Text = "<b>افزودن شیفت استثناء</b>\r\n<div></div>\r\n<font color=\"#000000\">افزودن یك شیفت جدی" +
                "د.</font>";
            this.btnAddDay.Visible = false;
            this.btnAddDay.Click += new System.EventHandler(this.btnAddDay_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.BeginGroup = true;
            this.btnRemove.ForeColor = System.Drawing.Color.Red;
            this.btnRemove.Image = global::Sepehr.Settings.Schedules.Properties.Resources.Delete;
            this.btnRemove.ImagePaddingHorizontal = 8;
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.Del);
            this.btnRemove.Text = "<b>حذف برنامه</b>\r\n<div></div>\r\n<font color=\"#000000\">حذف كامل برنامه و نوبت ها.<" +
                "/font>";
            this.btnRemove.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnHolidays
            // 
            this.btnHolidays.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnHolidays.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHolidays.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnHolidays.Image = ((System.Drawing.Image)(resources.GetObject("btnHolidays.Image")));
            this.btnHolidays.Location = new System.Drawing.Point(481, 501);
            this.btnHolidays.Name = "btnHolidays";
            this.btnHolidays.Size = new System.Drawing.Size(95, 57);
            this.btnHolidays.TabIndex = 3;
            this.btnHolidays.Text = "مدیریت ایام تعطیل";
            this.btnHolidays.Click += new System.EventHandler(this.btnHolidays_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAdd.Image = global::Sepehr.Settings.Schedules.Properties.Resources.AddMed;
            this.btnAdd.Location = new System.Drawing.Point(582, 501);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F6);
            this.btnAdd.Size = new System.Drawing.Size(95, 57);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.TabStop = false;
            this.btnAdd.Text = "افزودن\r\n(F6)";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cBoxWithInActives
            // 
            this.cBoxWithInActives.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxWithInActives.AutoSize = true;
            this.cBoxWithInActives.BackColor = System.Drawing.Color.Transparent;
            this.cBoxWithInActives.Checked = true;
            this.cBoxWithInActives.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBoxWithInActives.CheckValue = "Y";
            this.cBoxWithInActives.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxWithInActives.Location = new System.Drawing.Point(613, 479);
            this.cBoxWithInActives.Name = "cBoxWithInActives";
            this.cBoxWithInActives.Size = new System.Drawing.Size(166, 16);
            this.cBoxWithInActives.TabIndex = 6;
            this.cBoxWithInActives.Text = "نمایش برنامه های غیر فعال";
            this.cBoxWithInActives.TextColor = System.Drawing.Color.MediumVioletRed;
            this.cBoxWithInActives.CheckedChanged += new System.EventHandler(this.cBoxWithInActives_CheckedChanged);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToOrderColumns = true;
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.BackgroundColor = System.Drawing.Color.LightSkyBlue;
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
            this.ColActive,
            this.ColName,
            this.ColIsWeekly,
            this.ColStartDate,
            this.ColEndDate,
            this.ColDescription});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvData.Location = new System.Drawing.Point(12, 12);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(766, 461);
            this.dgvData.StandardTab = true;
            this.dgvData.TabIndex = 0;
            this.dgvData.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvData_CellMouseClick);
            this.dgvData.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dgvData_PreviewKeyDown);
            this.dgvData.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvData_CellMouseDoubleClick);
            // 
            // ColActive
            // 
            this.ColActive.DataPropertyName = "IsActive";
            this.ColActive.HeaderText = "فعال";
            this.ColActive.Name = "ColActive";
            this.ColActive.ReadOnly = true;
            this.ColActive.ToolTipText = "فعال بودن";
            this.ColActive.Width = 40;
            // 
            // ColName
            // 
            this.ColName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColName.DataPropertyName = "Name";
            this.ColName.HeaderText = "نام برنامه";
            this.ColName.Name = "ColName";
            this.ColName.ReadOnly = true;
            // 
            // ColIsWeekly
            // 
            this.ColIsWeekly.DataPropertyName = "IsFixed";
            this.ColIsWeekly.HeaderText = "ثابت";
            this.ColIsWeekly.Name = "ColIsWeekly";
            this.ColIsWeekly.ReadOnly = true;
            this.ColIsWeekly.ToolTipText = "ثابت یا شناور بودن برنامه.";
            this.ColIsWeekly.Width = 35;
            // 
            // ColStartDate
            // 
            this.ColStartDate.DataPropertyName = "StartDate";
            this.ColStartDate.HeaderText = "تاریخ آغاز";
            this.ColStartDate.Name = "ColStartDate";
            this.ColStartDate.ReadOnly = true;
            this.ColStartDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColStartDate.ShowTime = false;
            this.ColStartDate.Width = 85;
            // 
            // ColEndDate
            // 
            this.ColEndDate.DataPropertyName = "EndDate";
            this.ColEndDate.HeaderText = "تاریخ پایان";
            this.ColEndDate.Name = "ColEndDate";
            this.ColEndDate.ReadOnly = true;
            this.ColEndDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColEndDate.ShowTime = false;
            this.ColEndDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColEndDate.Width = 85;
            // 
            // ColDescription
            // 
            this.ColDescription.DataPropertyName = "Description";
            this.ColDescription.HeaderText = "توضیحات";
            this.ColDescription.Name = "ColDescription";
            this.ColDescription.ReadOnly = true;
            this.ColDescription.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColDescription.Width = 250;
            // 
            // btnHelp
            // 
            this.btnHelp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnHelp.Image = global::Sepehr.Settings.Schedules.Properties.Resources.Help;
            this.btnHelp.Location = new System.Drawing.Point(683, 501);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F1);
            this.btnHelp.Size = new System.Drawing.Size(95, 57);
            this.btnHelp.TabIndex = 5;
            this.btnHelp.TabStop = false;
            this.btnHelp.Text = "راهنما\r\n(F1)";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = global::Sepehr.Settings.Schedules.Properties.Resources.Cancel;
            this.btnClose.Location = new System.Drawing.Point(12, 501);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 57);
            this.btnClose.TabIndex = 1;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "خروج\r\n(Esc)";
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            // 
            // frmApps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(790, 570);
            this.Controls.Add(this.FormPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmApps";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تنظیمات - نوبت دهی - مدیریت برنامه های نوبت دهی";
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.FormPanel.ResumeLayout(false);
            this.FormPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmsForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel FormPanel;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.ButtonX btnHelp;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvData;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxWithInActives;
        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        private DevComponents.DotNetBar.ButtonX btnAdd;
        private DevComponents.DotNetBar.ContextMenuBar cmsForm;
        private DevComponents.DotNetBar.ButtonItem cmsMenu;
        private DevComponents.DotNetBar.ButtonItem btnEditBaseData;
        private DevComponents.DotNetBar.ButtonItem btnRemove;
        private DevComponents.DotNetBar.ButtonX btnHolidays;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColActive;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColIsWeekly;
        private Negar.PersianCalendar.UI.Controls.DataGridViewPersianDateTimePickerColumn ColStartDate;
        private Negar.PersianCalendar.UI.Controls.DataGridViewPersianDateTimePickerColumn ColEndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDescription;
        private DevComponents.DotNetBar.ButtonItem btnEditCurrentShift;
        private DevComponents.DotNetBar.ButtonItem btnAddNewShifts;
        private DevComponents.DotNetBar.ButtonItem btnAddDay;
    }
}