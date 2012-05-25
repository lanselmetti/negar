namespace Sepehr.Settings.Insurances
{
    partial class frmInsurances
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInsurances));
            this.FormPanel = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.dgvData = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Column2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new Negar.PersianCalendar.UI.Controls.DataGridViewPersianDateTimePickerColumn();
            this.Column4 = new Negar.PersianCalendar.UI.Controls.DataGridViewPersianDateTimePickerColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColFormula = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cBoxWithInActives = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cmsForm = new DevComponents.DotNetBar.ContextMenuBar();
            this.cmsMenu = new DevComponents.DotNetBar.ButtonItem();
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnHelp = new DevComponents.DotNetBar.ButtonX();
            this.btnAdd = new DevComponents.DotNetBar.ButtonX();
            this.btnIns2Formulas = new DevComponents.DotNetBar.ButtonX();
            this.btnCopyInsuranceSettings = new DevComponents.DotNetBar.ButtonX();
            this.btnEdit = new DevComponents.DotNetBar.ButtonItem();
            this.btnInsuranceServices = new DevComponents.DotNetBar.ButtonItem();
            this.btnExcludeSpecs = new DevComponents.DotNetBar.ButtonItem();
            this.btnExcludeRefPhys = new DevComponents.DotNetBar.ButtonItem();
            this.FormPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmsForm)).BeginInit();
            this.SuspendLayout();
            // 
            // FormPanel
            // 
            this.FormPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.FormPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.FormPanel.Controls.Add(this.dgvData);
            this.FormPanel.Controls.Add(this.cBoxWithInActives);
            this.FormPanel.Controls.Add(this.btnHelp);
            this.FormPanel.Controls.Add(this.btnAdd);
            this.FormPanel.Controls.Add(this.btnIns2Formulas);
            this.FormPanel.Controls.Add(this.btnCopyInsuranceSettings);
            this.FormPanel.Controls.Add(this.btnCancel);
            this.FormPanel.Controls.Add(this.cmsForm);
            this.FormPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormPanel.Location = new System.Drawing.Point(0, 0);
            this.FormPanel.Name = "FormPanel";
            this.FormPanel.Size = new System.Drawing.Size(784, 564);
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
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToOrderColumns = true;
            this.dgvData.AllowUserToResizeRows = false;
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
            this.Column2,
            this.Column1,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.ColFormula,
            this.Column15});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvData.Location = new System.Drawing.Point(12, 12);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(762, 450);
            this.dgvData.TabIndex = 0;
            this.dgvData.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvData_CellMouseClick);
            this.dgvData.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dgvData_PreviewKeyDown);
            this.dgvData.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvData_CellMouseDoubleClick);
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "IsActive";
            this.Column2.Frozen = true;
            this.Column2.HeaderText = "فعال";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column2.ToolTipText = "تعیین فعال بودن یا نبودن بیمه";
            this.Column2.Width = 35;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.DataPropertyName = "Name";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.HeaderText = "نام بیمه";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "ContractStartDate";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Navy;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column3.HeaderText = "آغاز قرارداد";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column3.ShowTime = false;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column3.ToolTipText = "تاریخی كه قرارداد با سازمان بیمه آغاز گردیده است.";
            this.Column3.Width = 80;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "ContractEndDate";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Navy;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column4.HeaderText = "پایان قرارداد";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column4.ShowTime = false;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column4.ToolTipText = "تاریخی كه قرارداد با سازمان بیمه پایان می یابد.";
            this.Column4.Width = 80;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "PatientPercent";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Column5.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column5.HeaderText = "درصد بیمار";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.ToolTipText = "درصد پرداختی سهم بیمار";
            this.Column5.Width = 50;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "InsurerPartLimit";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Column6.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column6.HeaderText = "سقف تعهد";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.ToolTipText = "سقف تعهد بیمه به ازای مراجعه.";
            this.Column6.Width = 70;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "IsIns1";
            this.Column7.HeaderText = "بیمه 1";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.ToolTipText = "تعیین بیمه ی اول بودن.";
            this.Column7.Width = 50;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "IsIns2";
            this.Column8.HeaderText = "بیمه 2";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.ToolTipText = "تعیین بیمه ی دوم بودن.";
            this.Column8.Width = 50;
            // 
            // ColFormula
            // 
            this.ColFormula.DataPropertyName = "Ins2FormulasIX";
            this.ColFormula.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ColFormula.HeaderText = "فرمول بیمه دوم";
            this.ColFormula.Name = "ColFormula";
            this.ColFormula.ReadOnly = true;
            this.ColFormula.ToolTipText = "نام فرمول بیمه دوم تعیین شده برای بیمه";
            // 
            // Column15
            // 
            this.Column15.DataPropertyName = "Description";
            this.Column15.HeaderText = "توضیحات";
            this.Column15.Name = "Column15";
            this.Column15.ReadOnly = true;
            this.Column15.ToolTipText = "توضیحاتی پیرامون بیمه ی ثبت شده";
            this.Column15.Width = 150;
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
            this.cBoxWithInActives.Location = new System.Drawing.Point(618, 468);
            this.cBoxWithInActives.Name = "cBoxWithInActives";
            this.cBoxWithInActives.Size = new System.Drawing.Size(158, 16);
            this.cBoxWithInActives.TabIndex = 6;
            this.cBoxWithInActives.Text = "نمایش بیمه های غیر فعال";
            this.cBoxWithInActives.TextColor = System.Drawing.Color.MediumVioletRed;
            this.cBoxWithInActives.CheckedChanged += new System.EventHandler(this.cBoxWithInActives_CheckedChanged);
            // 
            // cmsForm
            // 
            this.cmsForm.DockSide = DevComponents.DotNetBar.eDockSide.Document;
            this.cmsForm.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmsForm.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.cmsMenu});
            this.cmsForm.Location = new System.Drawing.Point(316, 490);
            this.cmsForm.Name = "cmsForm";
            this.cmsForm.Size = new System.Drawing.Size(55, 25);
            this.cmsForm.Stretch = true;
            this.cmsForm.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.cmsForm.TabIndex = 22;
            this.cmsForm.TabStop = false;
            // 
            // cmsMenu
            // 
            this.cmsMenu.AutoExpandOnClick = true;
            this.cmsMenu.ImagePaddingHorizontal = 8;
            this.cmsMenu.Name = "cmsMenu";
            this.cmsMenu.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnEdit,
            this.btnInsuranceServices,
            this.btnExcludeSpecs,
            this.btnExcludeRefPhys});
            this.cmsMenu.Text = "منو";
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Sepehr.Settings.Insurances.Properties.Resources.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(12, 490);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 57);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "خروج\r\n(Esc)";
            // 
            // btnHelp
            // 
            this.btnHelp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnHelp.Image = global::Sepehr.Settings.Insurances.Properties.Resources.Help;
            this.btnHelp.Location = new System.Drawing.Point(680, 490);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F1);
            this.btnHelp.Size = new System.Drawing.Size(95, 57);
            this.btnHelp.TabIndex = 5;
            this.btnHelp.TabStop = false;
            this.btnHelp.Text = "راهنما\r\n(F1)";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAdd.Image = global::Sepehr.Settings.Insurances.Properties.Resources.AddMed;
            this.btnAdd.Location = new System.Drawing.Point(579, 490);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F6);
            this.btnAdd.Size = new System.Drawing.Size(95, 57);
            this.btnAdd.TabIndex = 21;
            this.btnAdd.TabStop = false;
            this.btnAdd.Text = "افزودن بیمه\r\n (F6)";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnIns2Formulas
            // 
            this.btnIns2Formulas.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnIns2Formulas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIns2Formulas.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnIns2Formulas.Image = global::Sepehr.Settings.Insurances.Properties.Resources.InsLogo;
            this.btnIns2Formulas.Location = new System.Drawing.Point(478, 490);
            this.btnIns2Formulas.Name = "btnIns2Formulas";
            this.btnIns2Formulas.Size = new System.Drawing.Size(95, 57);
            this.btnIns2Formulas.TabIndex = 2;
            this.btnIns2Formulas.TabStop = false;
            this.btnIns2Formulas.Text = "فرمول های\r\nبیمه دوم";
            this.btnIns2Formulas.Click += new System.EventHandler(this.btnIns2Formulas_Click);
            // 
            // btnCopyInsuranceSettings
            // 
            this.btnCopyInsuranceSettings.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCopyInsuranceSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopyInsuranceSettings.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCopyInsuranceSettings.Image = global::Sepehr.Settings.Insurances.Properties.Resources.Copy;
            this.btnCopyInsuranceSettings.Location = new System.Drawing.Point(377, 490);
            this.btnCopyInsuranceSettings.Name = "btnCopyInsuranceSettings";
            this.btnCopyInsuranceSettings.Size = new System.Drawing.Size(95, 57);
            this.btnCopyInsuranceSettings.TabIndex = 7;
            this.btnCopyInsuranceSettings.TabStop = false;
            this.btnCopyInsuranceSettings.Text = "كپی خصوصیات بیمه ها";
            this.btnCopyInsuranceSettings.Click += new System.EventHandler(this.btnCopyInsuranceSettings_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Image = global::Sepehr.Settings.Insurances.Properties.Resources.EditSmall;
            this.btnEdit.ImagePaddingHorizontal = 8;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F2);
            this.btnEdit.Text = "<b>ویرایش بیمه</b>\r\n<div></div>\r\n<font color=\"#000000\">ویرایش تنظیمات بیمه.</font" +
                ">";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnInsuranceServices
            // 
            this.btnInsuranceServices.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnInsuranceServices.Image = global::Sepehr.Settings.Insurances.Properties.Resources.ServicesSettings;
            this.btnInsuranceServices.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnInsuranceServices.ImagePaddingHorizontal = 8;
            this.btnInsuranceServices.Name = "btnInsuranceServices";
            this.btnInsuranceServices.Text = "<b>ارتباط با خدمات</b>\r\n<div></div>\r\n<font color=\"#000000\">مدیریت ارتباط بیمه با " +
                "خدمات.</font>";
            this.btnInsuranceServices.Click += new System.EventHandler(this.btnInsuranceServices_Click);
            // 
            // btnExcludeSpecs
            // 
            this.btnExcludeSpecs.BeginGroup = true;
            this.btnExcludeSpecs.ForeColor = System.Drawing.Color.Green;
            this.btnExcludeSpecs.Image = global::Sepehr.Settings.Insurances.Properties.Resources.Job;
            this.btnExcludeSpecs.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnExcludeSpecs.ImagePaddingHorizontal = 8;
            this.btnExcludeSpecs.Name = "btnExcludeSpecs";
            this.btnExcludeSpecs.Text = "<b>تخصص های پزشكان مجاز</b>\r\n<div></div>\r\n<font color=\"#000000\">مدیریت تخصص های م" +
                "جاز بیمه.</font>";
            this.btnExcludeSpecs.Click += new System.EventHandler(this.btnExcludeSpecs_Click);
            // 
            // btnExcludeRefPhys
            // 
            this.btnExcludeRefPhys.ForeColor = System.Drawing.Color.Green;
            this.btnExcludeRefPhys.Image = global::Sepehr.Settings.Insurances.Properties.Resources.Physician;
            this.btnExcludeRefPhys.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnExcludeRefPhys.ImagePaddingHorizontal = 8;
            this.btnExcludeRefPhys.Name = "btnExcludeRefPhys";
            this.btnExcludeRefPhys.Text = "<b>پزشكان درخواست كننده مجاز</b>\r\n<div></div>\r\n<font color=\"#000000\">مدیریت پزشكا" +
                "ن مجاز بیمه.</font>";
            this.btnExcludeRefPhys.Click += new System.EventHandler(this.btnExcludeRefPhys_Click);
            // 
            // frmInsurances
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(784, 564);
            this.Controls.Add(this.FormPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmInsurances";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تنظیمات - مراجعات بیماران - مدیریت بیمه ها";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.FormPanel.ResumeLayout(false);
            this.FormPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmsForm)).EndInit();
            this.ResumeLayout(false);

        }

        

        

        #endregion

        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel FormPanel;
        internal DevComponents.DotNetBar.ButtonX btnHelp;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvData;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxWithInActives;
        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        internal DevComponents.DotNetBar.ButtonX btnIns2Formulas;
        internal DevComponents.DotNetBar.ButtonX btnCancel;
        internal DevComponents.DotNetBar.ButtonX btnCopyInsuranceSettings;
        private DevComponents.DotNetBar.ContextMenuBar cmsForm;
        private DevComponents.DotNetBar.ButtonItem cmsMenu;
        private DevComponents.DotNetBar.ButtonItem btnEdit;
        internal DevComponents.DotNetBar.ButtonX btnAdd;
        private DevComponents.DotNetBar.ButtonItem btnInsuranceServices;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private Negar.PersianCalendar.UI.Controls.DataGridViewPersianDateTimePickerColumn Column3;
        private Negar.PersianCalendar.UI.Controls.DataGridViewPersianDateTimePickerColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column7;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column8;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColFormula;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private DevComponents.DotNetBar.ButtonItem btnExcludeSpecs;
        private DevComponents.DotNetBar.ButtonItem btnExcludeRefPhys;
    }
}