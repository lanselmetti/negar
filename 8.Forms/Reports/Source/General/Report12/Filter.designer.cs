namespace Sepehr.Forms.Reports.General.Report12
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFilter));
            this.FormPanel = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.cBoxCDType = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.dgvCostsAndDiscounts = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ColCDTypeSelection = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColCDTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDocUser = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ColDocUserSelection = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColDocUserFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cBoxDocTypist = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.txtPercent = new DevComponents.Editors.IntegerInput();
            this.txtPhysName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtReportTitle = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.dgvRefPhysician = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ColRefPhysicianSelection = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColRefPhysicianName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPerformers = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ColPerformerSelection = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColPerformerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIsExpert = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColIsPhysician = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ProgressBar = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.cBoxRefPhysycian = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cBoxPerformers = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cBoxServiceCat = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.dgvService = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ColServiceSelection = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColServiceCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColServiceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvServiceGroups = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ColGroupSelection = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColGroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cBoxService = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.dgvServiceCat = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ColCatSelection = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColCatName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cBoxServiceGroups = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.lblPerformer = new DevComponents.DotNetBar.LabelX();
            this.lblPercent = new DevComponents.DotNetBar.LabelX();
            this.lblReportTitle = new DevComponents.DotNetBar.LabelX();
            this.btnHelp = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnReport = new DevComponents.DotNetBar.ButtonX();
            this.PanelRefDate = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.ToDateRef = new Negar.PersianCalendar.UI.Controls.PersianDatePicker();
            this.FromDateRef = new Negar.PersianCalendar.UI.Controls.PersianDatePicker();
            this.ToTimeRef = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.FromTimeRef = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.lblRefToTime = new DevComponents.DotNetBar.LabelX();
            this.lblRefFromTime = new DevComponents.DotNetBar.LabelX();
            this.lblEDate1 = new DevComponents.DotNetBar.LabelX();
            this.lblSDate1 = new DevComponents.DotNetBar.LabelX();
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.BGWorker = new System.ComponentModel.BackgroundWorker();
            this.cBoxSpecial1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cBoxIns2 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.dgvIns1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.cBoxIns1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.dgvIns2 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ColInsSelection1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColInsName1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColInsSelection2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColInsName2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCostsAndDiscounts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPercent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRefPhysician)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerformers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvService)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiceGroups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiceCat)).BeginInit();
            this.PanelRefDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToTimeRef)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromTimeRef)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIns1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIns2)).BeginInit();
            this.SuspendLayout();
            // 
            // FormPanel
            // 
            this.FormPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.FormPanel.Controls.Add(this.cBoxIns2);
            this.FormPanel.Controls.Add(this.dgvIns2);
            this.FormPanel.Controls.Add(this.dgvIns1);
            this.FormPanel.Controls.Add(this.cBoxIns1);
            this.FormPanel.Controls.Add(this.cBoxSpecial1);
            this.FormPanel.Controls.Add(this.cBoxCDType);
            this.FormPanel.Controls.Add(this.dgvCostsAndDiscounts);
            this.FormPanel.Controls.Add(this.dgvDocUser);
            this.FormPanel.Controls.Add(this.cBoxDocTypist);
            this.FormPanel.Controls.Add(this.txtPercent);
            this.FormPanel.Controls.Add(this.txtPhysName);
            this.FormPanel.Controls.Add(this.txtReportTitle);
            this.FormPanel.Controls.Add(this.dgvRefPhysician);
            this.FormPanel.Controls.Add(this.dgvPerformers);
            this.FormPanel.Controls.Add(this.ProgressBar);
            this.FormPanel.Controls.Add(this.cBoxRefPhysycian);
            this.FormPanel.Controls.Add(this.cBoxPerformers);
            this.FormPanel.Controls.Add(this.cBoxServiceCat);
            this.FormPanel.Controls.Add(this.dgvService);
            this.FormPanel.Controls.Add(this.dgvServiceGroups);
            this.FormPanel.Controls.Add(this.cBoxService);
            this.FormPanel.Controls.Add(this.dgvServiceCat);
            this.FormPanel.Controls.Add(this.cBoxServiceGroups);
            this.FormPanel.Controls.Add(this.lblPerformer);
            this.FormPanel.Controls.Add(this.lblPercent);
            this.FormPanel.Controls.Add(this.lblReportTitle);
            this.FormPanel.Controls.Add(this.btnHelp);
            this.FormPanel.Controls.Add(this.btnCancel);
            this.FormPanel.Controls.Add(this.btnReport);
            this.FormPanel.Controls.Add(this.PanelRefDate);
            this.FormPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormPanel.Location = new System.Drawing.Point(0, 0);
            this.FormPanel.Name = "FormPanel";
            this.FormPanel.Size = new System.Drawing.Size(912, 665);
            // 
            // 
            // 
            this.FormPanel.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.FormPanel.Style.BackColorGradientAngle = 90;
            this.FormPanel.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.FormPanel.Style.BackgroundImagePosition = DevComponents.DotNetBar.eStyleBackgroundImage.Tile;
            this.FormPanel.Style.BorderBottomWidth = 1;
            this.FormPanel.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.FormPanel.Style.BorderLeftWidth = 1;
            this.FormPanel.Style.BorderRightWidth = 1;
            this.FormPanel.Style.BorderTopWidth = 1;
            this.FormPanel.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.FormPanel.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.FormPanel.TabIndex = 0;
            // 
            // cBoxCDType
            // 
            this.cBoxCDType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxCDType.AutoSize = true;
            this.cBoxCDType.BackColor = System.Drawing.Color.Transparent;
            this.cBoxCDType.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxCDType.Location = new System.Drawing.Point(59, 178);
            this.cBoxCDType.Name = "cBoxCDType";
            this.cBoxCDType.Size = new System.Drawing.Size(246, 16);
            this.FormToolTip.SetSuperTooltip(this.cBoxCDType, new DevComponents.DotNetBar.SuperTooltipInfo("توجه!", "", "در صورت فعال كردن این گزینه ، تخفیف های ارائه شده برای بیماران واجد شرایط فیلتر ج" +
                        "اری محاسبه شده و بر اساس درصد تعیین شده برای كاركرد پزشك ، از كل كاركرد كسر می ش" +
                        "وند.", global::Sepehr.Forms.Reports.Properties.Resources.Help, null, DevComponents.DotNetBar.eTooltipColor.Red));
            this.cBoxCDType.TabIndex = 17;
            this.cBoxCDType.Text = "كسر تخفیف های ارائه شده از كاركرد پزشك";
            this.cBoxCDType.CheckedChanged += new System.EventHandler(this.cBoxCDType_CheckedChanged);
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
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCostsAndDiscounts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvCostsAndDiscounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCostsAndDiscounts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColCDTypeSelection,
            this.ColCDTypeName});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCostsAndDiscounts.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvCostsAndDiscounts.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvCostsAndDiscounts.Location = new System.Drawing.Point(12, 200);
            this.dgvCostsAndDiscounts.MultiSelect = false;
            this.dgvCostsAndDiscounts.Name = "dgvCostsAndDiscounts";
            this.dgvCostsAndDiscounts.RowHeadersVisible = false;
            this.dgvCostsAndDiscounts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCostsAndDiscounts.Size = new System.Drawing.Size(293, 119);
            this.dgvCostsAndDiscounts.TabIndex = 18;
            // 
            // ColCDTypeSelection
            // 
            this.ColCDTypeSelection.HeaderText = "اضافه";
            this.ColCDTypeSelection.Name = "ColCDTypeSelection";
            this.ColCDTypeSelection.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColCDTypeSelection.Width = 35;
            // 
            // ColCDTypeName
            // 
            this.ColCDTypeName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColCDTypeName.DataPropertyName = "Name";
            this.ColCDTypeName.HeaderText = "نام تخفیف";
            this.ColCDTypeName.Name = "ColCDTypeName";
            this.ColCDTypeName.ReadOnly = true;
            // 
            // dgvDocUser
            // 
            this.dgvDocUser.AllowUserToAddRows = false;
            this.dgvDocUser.AllowUserToDeleteRows = false;
            this.dgvDocUser.AllowUserToOrderColumns = true;
            this.dgvDocUser.AllowUserToResizeColumns = false;
            this.dgvDocUser.AllowUserToResizeRows = false;
            this.dgvDocUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDocUser.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dgvDocUser.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDocUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvDocUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColDocUserSelection,
            this.ColDocUserFullName});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDocUser.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvDocUser.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvDocUser.Location = new System.Drawing.Point(12, 347);
            this.dgvDocUser.MultiSelect = false;
            this.dgvDocUser.Name = "dgvDocUser";
            this.dgvDocUser.RowHeadersVisible = false;
            this.dgvDocUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocUser.Size = new System.Drawing.Size(293, 243);
            this.dgvDocUser.TabIndex = 20;
            // 
            // ColDocUserSelection
            // 
            this.ColDocUserSelection.HeaderText = "اضافه";
            this.ColDocUserSelection.Name = "ColDocUserSelection";
            this.ColDocUserSelection.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColDocUserSelection.Width = 35;
            // 
            // ColDocUserFullName
            // 
            this.ColDocUserFullName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColDocUserFullName.DataPropertyName = "FullName";
            this.ColDocUserFullName.HeaderText = "نام كاربر";
            this.ColDocUserFullName.Name = "ColDocUserFullName";
            this.ColDocUserFullName.ReadOnly = true;
            // 
            // cBoxDocTypist
            // 
            this.cBoxDocTypist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxDocTypist.AutoSize = true;
            this.cBoxDocTypist.BackColor = System.Drawing.Color.Transparent;
            this.cBoxDocTypist.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxDocTypist.Location = new System.Drawing.Point(115, 325);
            this.cBoxDocTypist.Name = "cBoxDocTypist";
            this.cBoxDocTypist.Size = new System.Drawing.Size(190, 16);
            this.FormToolTip.SetSuperTooltip(this.cBoxDocTypist, new DevComponents.DotNetBar.SuperTooltipInfo("توجه!", "", "اعمال این شرط به این معنی است كه تنها مراجعاتی را نمایش دهد كه حتماً حداقل یك مدر" +
                        "ك داشته باشند و كاربر ثبت كننده یكی از مدارك آنها كاربران انتخاب شده زیر باشند.", global::Sepehr.Forms.Reports.Properties.Resources.Help, null, DevComponents.DotNetBar.eTooltipColor.Red, true, false, new System.Drawing.Size(0, 0)));
            this.cBoxDocTypist.TabIndex = 19;
            this.cBoxDocTypist.TabStop = false;
            this.cBoxDocTypist.Text = "دارای مدرك با كاربر ثبت كننده زیر";
            this.cBoxDocTypist.CheckedChanged += new System.EventHandler(this.cBoxDocTypist_CheckedChanged);
            // 
            // txtPercent
            // 
            this.txtPercent.AllowEmptyState = false;
            this.txtPercent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtPercent.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtPercent.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtPercent.Location = new System.Drawing.Point(399, 61);
            this.txtPercent.MaxValue = 100;
            this.txtPercent.MinValue = 1;
            this.txtPercent.Name = "txtPercent";
            this.txtPercent.ShowUpDown = true;
            this.txtPercent.Size = new System.Drawing.Size(63, 21);
            this.txtPercent.TabIndex = 14;
            this.txtPercent.Value = 100;
            // 
            // txtPhysName
            // 
            this.txtPhysName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtPhysName.Border.Class = "TextBoxBorder";
            this.txtPhysName.Location = new System.Drawing.Point(311, 35);
            this.txtPhysName.Name = "txtPhysName";
            this.txtPhysName.Size = new System.Drawing.Size(207, 21);
            this.txtPhysName.TabIndex = 12;
            this.txtPhysName.Text = "نام و نام خانوادگی";
            // 
            // txtReportTitle
            // 
            this.txtReportTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtReportTitle.Border.Class = "TextBoxBorder";
            this.txtReportTitle.Location = new System.Drawing.Point(311, 8);
            this.txtReportTitle.Name = "txtReportTitle";
            this.txtReportTitle.Size = new System.Drawing.Size(207, 21);
            this.txtReportTitle.TabIndex = 10;
            this.txtReportTitle.Text = "گزارش كاركرد كادر پزشكی";
            // 
            // dgvRefPhysician
            // 
            this.dgvRefPhysician.AllowUserToAddRows = false;
            this.dgvRefPhysician.AllowUserToDeleteRows = false;
            this.dgvRefPhysician.AllowUserToOrderColumns = true;
            this.dgvRefPhysician.AllowUserToResizeColumns = false;
            this.dgvRefPhysician.AllowUserToResizeRows = false;
            this.dgvRefPhysician.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRefPhysician.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dgvRefPhysician.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRefPhysician.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvRefPhysician.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRefPhysician.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColRefPhysicianSelection,
            this.ColRefPhysicianName});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRefPhysician.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvRefPhysician.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvRefPhysician.Location = new System.Drawing.Point(311, 112);
            this.dgvRefPhysician.MultiSelect = false;
            this.dgvRefPhysician.Name = "dgvRefPhysician";
            this.dgvRefPhysician.RowHeadersVisible = false;
            this.dgvRefPhysician.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRefPhysician.Size = new System.Drawing.Size(293, 207);
            this.dgvRefPhysician.TabIndex = 4;
            // 
            // ColRefPhysicianSelection
            // 
            this.ColRefPhysicianSelection.HeaderText = "اضافه";
            this.ColRefPhysicianSelection.Name = "ColRefPhysicianSelection";
            this.ColRefPhysicianSelection.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColRefPhysicianSelection.Width = 35;
            // 
            // ColRefPhysicianName
            // 
            this.ColRefPhysicianName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColRefPhysicianName.DataPropertyName = "FullName";
            this.ColRefPhysicianName.HeaderText = "نام";
            this.ColRefPhysicianName.Name = "ColRefPhysicianName";
            this.ColRefPhysicianName.ReadOnly = true;
            // 
            // dgvPerformers
            // 
            this.dgvPerformers.AllowUserToAddRows = false;
            this.dgvPerformers.AllowUserToDeleteRows = false;
            this.dgvPerformers.AllowUserToOrderColumns = true;
            this.dgvPerformers.AllowUserToResizeColumns = false;
            this.dgvPerformers.AllowUserToResizeRows = false;
            this.dgvPerformers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPerformers.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dgvPerformers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPerformers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvPerformers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPerformers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColPerformerSelection,
            this.ColPerformerName,
            this.ColIsExpert,
            this.ColIsPhysician});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPerformers.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvPerformers.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvPerformers.Location = new System.Drawing.Point(610, 112);
            this.dgvPerformers.MultiSelect = false;
            this.dgvPerformers.Name = "dgvPerformers";
            this.dgvPerformers.RowHeadersVisible = false;
            this.dgvPerformers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPerformers.Size = new System.Drawing.Size(288, 207);
            this.dgvPerformers.TabIndex = 2;
            this.dgvPerformers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPerformers_CellContentClick);
            // 
            // ColPerformerSelection
            // 
            this.ColPerformerSelection.HeaderText = "اضافه";
            this.ColPerformerSelection.Name = "ColPerformerSelection";
            this.ColPerformerSelection.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColPerformerSelection.Width = 35;
            // 
            // ColPerformerName
            // 
            this.ColPerformerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColPerformerName.DataPropertyName = "FullName";
            this.ColPerformerName.HeaderText = "نام";
            this.ColPerformerName.Name = "ColPerformerName";
            this.ColPerformerName.ReadOnly = true;
            // 
            // ColIsExpert
            // 
            this.ColIsExpert.HeaderText = "كارشناس";
            this.ColIsExpert.Name = "ColIsExpert";
            this.ColIsExpert.Width = 50;
            // 
            // ColIsPhysician
            // 
            this.ColIsPhysician.HeaderText = "پزشك";
            this.ColIsPhysician.Name = "ColIsPhysician";
            this.ColIsPhysician.Width = 40;
            // 
            // ProgressBar
            // 
            this.ProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ProgressBar.Location = new System.Drawing.Point(214, 609);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(583, 23);
            this.ProgressBar.TabIndex = 16;
            this.ProgressBar.TabStop = false;
            this.ProgressBar.Text = "در انتظار ایجاد گزارش";
            this.ProgressBar.TextVisible = true;
            // 
            // cBoxRefPhysycian
            // 
            this.cBoxRefPhysycian.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxRefPhysycian.AutoSize = true;
            this.cBoxRefPhysycian.BackColor = System.Drawing.Color.Transparent;
            this.cBoxRefPhysycian.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxRefPhysycian.Location = new System.Drawing.Point(387, 90);
            this.cBoxRefPhysycian.Name = "cBoxRefPhysycian";
            this.cBoxRefPhysycian.Size = new System.Drawing.Size(217, 16);
            this.cBoxRefPhysycian.TabIndex = 3;
            this.cBoxRefPhysycian.Text = "انتخاب پزشك درخواست كننده مراجعه";
            this.cBoxRefPhysycian.CheckedChanged += new System.EventHandler(this.cBoxRefPhysycian_CheckedChanged);
            // 
            // cBoxPerformers
            // 
            this.cBoxPerformers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxPerformers.AutoSize = true;
            this.cBoxPerformers.BackColor = System.Drawing.Color.Transparent;
            this.cBoxPerformers.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxPerformers.Location = new System.Drawing.Point(707, 90);
            this.cBoxPerformers.Name = "cBoxPerformers";
            this.cBoxPerformers.Size = new System.Drawing.Size(191, 16);
            this.cBoxPerformers.TabIndex = 1;
            this.cBoxPerformers.Text = "انتخاب كارشناس یا پزشك خدمت";
            this.cBoxPerformers.CheckedChanged += new System.EventHandler(this.cBoxPerformers_CheckedChanged);
            // 
            // cBoxServiceCat
            // 
            this.cBoxServiceCat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxServiceCat.AutoSize = true;
            this.cBoxServiceCat.BackColor = System.Drawing.Color.Transparent;
            this.cBoxServiceCat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxServiceCat.Location = new System.Drawing.Point(699, 325);
            this.cBoxServiceCat.Name = "cBoxServiceCat";
            this.cBoxServiceCat.Size = new System.Drawing.Size(199, 16);
            this.cBoxServiceCat.TabIndex = 5;
            this.cBoxServiceCat.Text = "فقط خدمات در طبقه بندی های زیر";
            this.cBoxServiceCat.CheckedChanged += new System.EventHandler(this.cBoxServiceCat_CheckedChanged);
            // 
            // dgvService
            // 
            this.dgvService.AllowUserToAddRows = false;
            this.dgvService.AllowUserToDeleteRows = false;
            this.dgvService.AllowUserToOrderColumns = true;
            this.dgvService.AllowUserToResizeColumns = false;
            this.dgvService.AllowUserToResizeRows = false;
            this.dgvService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvService.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dgvService.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvService.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvService.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvService.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColServiceSelection,
            this.ColServiceCode,
            this.ColServiceName});
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvService.DefaultCellStyle = dataGridViewCellStyle15;
            this.dgvService.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvService.Location = new System.Drawing.Point(12, 30);
            this.dgvService.MultiSelect = false;
            this.dgvService.Name = "dgvService";
            this.dgvService.RowHeadersVisible = false;
            this.dgvService.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvService.Size = new System.Drawing.Size(293, 142);
            this.dgvService.TabIndex = 16;
            // 
            // ColServiceSelection
            // 
            this.ColServiceSelection.HeaderText = "اضافه";
            this.ColServiceSelection.Name = "ColServiceSelection";
            this.ColServiceSelection.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColServiceSelection.Width = 35;
            // 
            // ColServiceCode
            // 
            this.ColServiceCode.DataPropertyName = "Code";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColServiceCode.DefaultCellStyle = dataGridViewCellStyle14;
            this.ColServiceCode.HeaderText = "كد";
            this.ColServiceCode.Name = "ColServiceCode";
            this.ColServiceCode.ReadOnly = true;
            this.ColServiceCode.Width = 45;
            // 
            // ColServiceName
            // 
            this.ColServiceName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColServiceName.DataPropertyName = "Name";
            this.ColServiceName.HeaderText = "نام خدمت";
            this.ColServiceName.Name = "ColServiceName";
            this.ColServiceName.ReadOnly = true;
            // 
            // dgvServiceGroups
            // 
            this.dgvServiceGroups.AllowUserToAddRows = false;
            this.dgvServiceGroups.AllowUserToDeleteRows = false;
            this.dgvServiceGroups.AllowUserToOrderColumns = true;
            this.dgvServiceGroups.AllowUserToResizeColumns = false;
            this.dgvServiceGroups.AllowUserToResizeRows = false;
            this.dgvServiceGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvServiceGroups.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dgvServiceGroups.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvServiceGroups.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dgvServiceGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServiceGroups.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColGroupSelection,
            this.ColGroupName});
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvServiceGroups.DefaultCellStyle = dataGridViewCellStyle17;
            this.dgvServiceGroups.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvServiceGroups.Location = new System.Drawing.Point(611, 480);
            this.dgvServiceGroups.MultiSelect = false;
            this.dgvServiceGroups.Name = "dgvServiceGroups";
            this.dgvServiceGroups.RowHeadersVisible = false;
            this.dgvServiceGroups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvServiceGroups.Size = new System.Drawing.Size(287, 110);
            this.dgvServiceGroups.TabIndex = 8;
            // 
            // ColGroupSelection
            // 
            this.ColGroupSelection.HeaderText = "اضافه";
            this.ColGroupSelection.Name = "ColGroupSelection";
            this.ColGroupSelection.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColGroupSelection.Width = 35;
            // 
            // ColGroupName
            // 
            this.ColGroupName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColGroupName.DataPropertyName = "Name";
            this.ColGroupName.HeaderText = "نام گروه";
            this.ColGroupName.Name = "ColGroupName";
            this.ColGroupName.ReadOnly = true;
            // 
            // cBoxService
            // 
            this.cBoxService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxService.AutoSize = true;
            this.cBoxService.BackColor = System.Drawing.Color.Transparent;
            this.cBoxService.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxService.Location = new System.Drawing.Point(205, 8);
            this.cBoxService.Name = "cBoxService";
            this.cBoxService.Size = new System.Drawing.Size(100, 16);
            this.cBoxService.TabIndex = 15;
            this.cBoxService.TabStop = false;
            this.cBoxService.Text = "فقط خدمات زیر";
            this.cBoxService.CheckedChanged += new System.EventHandler(this.cBoxService_CheckedChanged);
            // 
            // dgvServiceCat
            // 
            this.dgvServiceCat.AllowUserToAddRows = false;
            this.dgvServiceCat.AllowUserToDeleteRows = false;
            this.dgvServiceCat.AllowUserToOrderColumns = true;
            this.dgvServiceCat.AllowUserToResizeColumns = false;
            this.dgvServiceCat.AllowUserToResizeRows = false;
            this.dgvServiceCat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvServiceCat.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dgvServiceCat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvServiceCat.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.dgvServiceCat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServiceCat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColCatSelection,
            this.ColCatName});
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvServiceCat.DefaultCellStyle = dataGridViewCellStyle19;
            this.dgvServiceCat.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvServiceCat.Location = new System.Drawing.Point(610, 347);
            this.dgvServiceCat.MultiSelect = false;
            this.dgvServiceCat.Name = "dgvServiceCat";
            this.dgvServiceCat.RowHeadersVisible = false;
            this.dgvServiceCat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvServiceCat.Size = new System.Drawing.Size(288, 105);
            this.dgvServiceCat.TabIndex = 6;
            // 
            // ColCatSelection
            // 
            this.ColCatSelection.HeaderText = "اضافه";
            this.ColCatSelection.Name = "ColCatSelection";
            this.ColCatSelection.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColCatSelection.Width = 35;
            // 
            // ColCatName
            // 
            this.ColCatName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColCatName.DataPropertyName = "Name";
            this.ColCatName.HeaderText = "نام طبقه بندی";
            this.ColCatName.Name = "ColCatName";
            this.ColCatName.ReadOnly = true;
            // 
            // cBoxServiceGroups
            // 
            this.cBoxServiceGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxServiceGroups.AutoSize = true;
            this.cBoxServiceGroups.BackColor = System.Drawing.Color.Transparent;
            this.cBoxServiceGroups.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxServiceGroups.Location = new System.Drawing.Point(702, 458);
            this.cBoxServiceGroups.Name = "cBoxServiceGroups";
            this.cBoxServiceGroups.Size = new System.Drawing.Size(196, 16);
            this.cBoxServiceGroups.TabIndex = 7;
            this.cBoxServiceGroups.TabStop = false;
            this.cBoxServiceGroups.Text = "فقط خدمات در گروه بندی های زیر";
            this.cBoxServiceGroups.CheckedChanged += new System.EventHandler(this.cBoxServiceGroups_CheckedChanged);
            // 
            // lblPerformer
            // 
            this.lblPerformer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPerformer.AutoSize = true;
            this.lblPerformer.BackColor = System.Drawing.Color.Transparent;
            this.lblPerformer.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblPerformer.Location = new System.Drawing.Point(524, 37);
            this.lblPerformer.Name = "lblPerformer";
            this.lblPerformer.Size = new System.Drawing.Size(46, 16);
            this.lblPerformer.TabIndex = 11;
            this.lblPerformer.Text = "نام كادر:";
            this.lblPerformer.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblPercent
            // 
            this.lblPercent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPercent.AutoSize = true;
            this.lblPercent.BackColor = System.Drawing.Color.Transparent;
            this.lblPercent.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblPercent.Location = new System.Drawing.Point(468, 63);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(131, 16);
            this.lblPercent.TabIndex = 13;
            this.lblPercent.Text = "درصد سهم كادر پزشكی:";
            this.lblPercent.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblReportTitle
            // 
            this.lblReportTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReportTitle.AutoSize = true;
            this.lblReportTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblReportTitle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblReportTitle.Location = new System.Drawing.Point(524, 10);
            this.lblReportTitle.Name = "lblReportTitle";
            this.lblReportTitle.Size = new System.Drawing.Size(75, 16);
            this.lblReportTitle.TabIndex = 9;
            this.lblReportTitle.Text = "عنوان گزارش:";
            this.lblReportTitle.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // btnHelp
            // 
            this.btnHelp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnHelp.Image = global::Sepehr.Forms.Reports.Properties.Resources.Help;
            this.btnHelp.Location = new System.Drawing.Point(803, 596);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F1);
            this.btnHelp.Size = new System.Drawing.Size(95, 57);
            this.btnHelp.TabIndex = 15;
            this.btnHelp.TabStop = false;
            this.btnHelp.Text = "راهنما\r\n(F1)";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Sepehr.Forms.Reports.Properties.Resources.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(113, 596);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 57);
            this.btnCancel.TabIndex = 17;
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
            this.btnReport.Location = new System.Drawing.Point(12, 596);
            this.btnReport.Name = "btnReport";
            this.btnReport.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnReport.Size = new System.Drawing.Size(95, 57);
            this.btnReport.TabIndex = 18;
            this.btnReport.TabStop = false;
            this.btnReport.Text = "گزارش(F8)";
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // PanelRefDate
            // 
            this.PanelRefDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelRefDate.BackColor = System.Drawing.Color.Transparent;
            this.PanelRefDate.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelRefDate.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelRefDate.Controls.Add(this.ToDateRef);
            this.PanelRefDate.Controls.Add(this.FromDateRef);
            this.PanelRefDate.Controls.Add(this.ToTimeRef);
            this.PanelRefDate.Controls.Add(this.FromTimeRef);
            this.PanelRefDate.Controls.Add(this.lblRefToTime);
            this.PanelRefDate.Controls.Add(this.lblRefFromTime);
            this.PanelRefDate.Controls.Add(this.lblEDate1);
            this.PanelRefDate.Controls.Add(this.lblSDate1);
            this.PanelRefDate.DrawTitleBox = false;
            this.PanelRefDate.Font = new System.Drawing.Font("Tahoma", 8.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.PanelRefDate.Location = new System.Drawing.Point(605, 8);
            this.PanelRefDate.Name = "PanelRefDate";
            this.PanelRefDate.Size = new System.Drawing.Size(293, 75);
            // 
            // 
            // 
            this.PanelRefDate.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.PanelRefDate.Style.BackColorGradientAngle = 90;
            this.PanelRefDate.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.PanelRefDate.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelRefDate.Style.BorderBottomWidth = 1;
            this.PanelRefDate.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.PanelRefDate.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelRefDate.Style.BorderLeftWidth = 1;
            this.PanelRefDate.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelRefDate.Style.BorderRightWidth = 1;
            this.PanelRefDate.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelRefDate.Style.BorderTopWidth = 1;
            this.PanelRefDate.Style.CornerDiameter = 4;
            this.PanelRefDate.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.PanelRefDate.Style.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(0)))), ((int)(((byte)(132)))));
            this.PanelRefDate.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.PanelRefDate.TabIndex = 0;
            this.PanelRefDate.Text = "تاریخ پذیرش مراجعه خدمات";
            // 
            // ToDateRef
            // 
            this.ToDateRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ToDateRef.IsAllowNullDate = false;
            this.ToDateRef.IsPopupOpen = false;
            this.ToDateRef.Location = new System.Drawing.Point(147, 31);
            this.ToDateRef.Name = "ToDateRef";
            this.ToDateRef.SelectedDateTime = new System.DateTime(2010, 3, 24, 12, 57, 33, 182);
            this.ToDateRef.Size = new System.Drawing.Size(84, 20);
            this.ToDateRef.TabIndex = 4;
            // 
            // FromDateRef
            // 
            this.FromDateRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FromDateRef.IsAllowNullDate = false;
            this.FromDateRef.IsPopupOpen = false;
            this.FromDateRef.Location = new System.Drawing.Point(147, 4);
            this.FromDateRef.Name = "FromDateRef";
            this.FromDateRef.SelectedDateTime = new System.DateTime(2010, 3, 24, 12, 57, 33, 191);
            this.FromDateRef.Size = new System.Drawing.Size(84, 20);
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
            this.ToTimeRef.Location = new System.Drawing.Point(5, 31);
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
            this.ToTimeRef.Size = new System.Drawing.Size(81, 21);
            this.ToTimeRef.TabIndex = 7;
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
            this.FromTimeRef.Location = new System.Drawing.Point(5, 4);
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
            this.FromTimeRef.Size = new System.Drawing.Size(81, 21);
            this.FromTimeRef.TabIndex = 3;
            this.FromTimeRef.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            // 
            // lblRefToTime
            // 
            this.lblRefToTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRefToTime.AutoSize = true;
            this.lblRefToTime.BackColor = System.Drawing.Color.Transparent;
            this.lblRefToTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblRefToTime.Location = new System.Drawing.Point(89, 33);
            this.lblRefToTime.Name = "lblRefToTime";
            this.lblRefToTime.Size = new System.Drawing.Size(52, 16);
            this.lblRefToTime.TabIndex = 6;
            this.lblRefToTime.Text = "تا ساعت:";
            this.lblRefToTime.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblRefFromTime
            // 
            this.lblRefFromTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRefFromTime.AutoSize = true;
            this.lblRefFromTime.BackColor = System.Drawing.Color.Transparent;
            this.lblRefFromTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblRefFromTime.Location = new System.Drawing.Point(89, 6);
            this.lblRefFromTime.Name = "lblRefFromTime";
            this.lblRefFromTime.Size = new System.Drawing.Size(53, 16);
            this.lblRefFromTime.TabIndex = 2;
            this.lblRefFromTime.Text = "از ساعت:";
            this.lblRefFromTime.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblEDate1
            // 
            this.lblEDate1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEDate1.AutoSize = true;
            this.lblEDate1.BackColor = System.Drawing.Color.Transparent;
            this.lblEDate1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblEDate1.Location = new System.Drawing.Point(238, 33);
            this.lblEDate1.Name = "lblEDate1";
            this.lblEDate1.Size = new System.Drawing.Size(42, 16);
            this.lblEDate1.TabIndex = 5;
            this.lblEDate1.Text = "تا تاریخ:";
            this.lblEDate1.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblSDate1
            // 
            this.lblSDate1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSDate1.AutoSize = true;
            this.lblSDate1.BackColor = System.Drawing.Color.Transparent;
            this.lblSDate1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblSDate1.Location = new System.Drawing.Point(238, 6);
            this.lblSDate1.Name = "lblSDate1";
            this.lblSDate1.Size = new System.Drawing.Size(43, 16);
            this.lblSDate1.TabIndex = 1;
            this.lblSDate1.Text = "از تاریخ:";
            this.lblSDate1.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            // 
            // BGWorker
            // 
            this.BGWorker.WorkerSupportsCancellation = true;
            this.BGWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGWorker_DoWork);
            this.BGWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BGWorker_RunWorkerCompleted);
            // 
            // cBoxSpecial1
            // 
            this.cBoxSpecial1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxSpecial1.AutoSize = true;
            this.cBoxSpecial1.BackColor = System.Drawing.Color.Transparent;
            this.cBoxSpecial1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxSpecial1.Location = new System.Drawing.Point(536, 637);
            this.cBoxSpecial1.Name = "cBoxSpecial1";
            this.cBoxSpecial1.Size = new System.Drawing.Size(261, 16);
            this.cBoxSpecial1.TabIndex = 21;
            this.cBoxSpecial1.Text = "برابر قراردادن سهم بیمه دوم با قیمت بیمه دوم";
            // 
            // cBoxIns2
            // 
            this.cBoxIns2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxIns2.AutoSize = true;
            this.cBoxIns2.BackColor = System.Drawing.Color.Transparent;
            this.cBoxIns2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxIns2.Location = new System.Drawing.Point(526, 458);
            this.cBoxIns2.Name = "cBoxIns2";
            this.cBoxIns2.Size = new System.Drawing.Size(78, 16);
            this.cBoxIns2.TabIndex = 23;
            this.cBoxIns2.TabStop = false;
            this.cBoxIns2.Text = "با بیمه دوم";
            this.cBoxIns2.CheckedChanged += new System.EventHandler(this.cBoxIns2_CheckedChanged);
            // 
            // dgvIns1
            // 
            this.dgvIns1.AllowUserToAddRows = false;
            this.dgvIns1.AllowUserToDeleteRows = false;
            this.dgvIns1.AllowUserToOrderColumns = true;
            this.dgvIns1.AllowUserToResizeColumns = false;
            this.dgvIns1.AllowUserToResizeRows = false;
            this.dgvIns1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvIns1.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dgvIns1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIns1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvIns1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIns1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColInsSelection1,
            this.ColInsName1});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvIns1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvIns1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvIns1.Location = new System.Drawing.Point(311, 347);
            this.dgvIns1.MultiSelect = false;
            this.dgvIns1.Name = "dgvIns1";
            this.dgvIns1.RowHeadersVisible = false;
            this.dgvIns1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIns1.Size = new System.Drawing.Size(293, 105);
            this.dgvIns1.StandardTab = true;
            this.dgvIns1.TabIndex = 24;
            // 
            // cBoxIns1
            // 
            this.cBoxIns1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxIns1.AutoSize = true;
            this.cBoxIns1.BackColor = System.Drawing.Color.Transparent;
            this.cBoxIns1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxIns1.Location = new System.Drawing.Point(527, 325);
            this.cBoxIns1.Name = "cBoxIns1";
            this.cBoxIns1.Size = new System.Drawing.Size(77, 16);
            this.cBoxIns1.TabIndex = 22;
            this.cBoxIns1.TabStop = false;
            this.cBoxIns1.Text = "با بیمه اول";
            this.cBoxIns1.CheckedChanged += new System.EventHandler(this.cBoxIns1_CheckedChanged);
            // 
            // dgvIns2
            // 
            this.dgvIns2.AllowUserToAddRows = false;
            this.dgvIns2.AllowUserToDeleteRows = false;
            this.dgvIns2.AllowUserToOrderColumns = true;
            this.dgvIns2.AllowUserToResizeColumns = false;
            this.dgvIns2.AllowUserToResizeRows = false;
            this.dgvIns2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvIns2.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dgvIns2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIns2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvIns2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIns2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColInsSelection2,
            this.ColInsName2});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvIns2.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvIns2.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvIns2.Location = new System.Drawing.Point(311, 480);
            this.dgvIns2.MultiSelect = false;
            this.dgvIns2.Name = "dgvIns2";
            this.dgvIns2.RowHeadersVisible = false;
            this.dgvIns2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIns2.Size = new System.Drawing.Size(293, 110);
            this.dgvIns2.StandardTab = true;
            this.dgvIns2.TabIndex = 24;
            // 
            // ColInsSelection1
            // 
            this.ColInsSelection1.HeaderText = "اضافه";
            this.ColInsSelection1.Name = "ColInsSelection1";
            this.ColInsSelection1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColInsSelection1.Width = 35;
            // 
            // ColInsName1
            // 
            this.ColInsName1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColInsName1.DataPropertyName = "Name";
            this.ColInsName1.HeaderText = "نام بیمه";
            this.ColInsName1.Name = "ColInsName1";
            this.ColInsName1.ReadOnly = true;
            // 
            // ColInsSelection2
            // 
            this.ColInsSelection2.HeaderText = "اضافه";
            this.ColInsSelection2.Name = "ColInsSelection2";
            this.ColInsSelection2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColInsSelection2.Width = 35;
            // 
            // ColInsName2
            // 
            this.ColInsName2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColInsName2.DataPropertyName = "Name";
            this.ColInsName2.HeaderText = "نام بیمه";
            this.ColInsName2.Name = "ColInsName2";
            this.ColInsName2.ReadOnly = true;
            // 
            // frmFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(912, 665);
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
            this.Text = "گزارش های عمومی - گزارش كاركرد كادر پزشكی - مشروح";
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.FormPanel.ResumeLayout(false);
            this.FormPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCostsAndDiscounts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPercent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRefPhysician)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerformers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvService)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiceGroups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiceCat)).EndInit();
            this.PanelRefDate.ResumeLayout(false);
            this.PanelRefDate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToTimeRef)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromTimeRef)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIns1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIns2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel FormPanel;
        private DevComponents.DotNetBar.ButtonX btnHelp;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnReport;
        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxServiceCat;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvServiceCat;
        private DevComponents.DotNetBar.Controls.GroupPanel PanelRefDate;
        private Negar.PersianCalendar.UI.Controls.PersianDatePicker ToDateRef;
        private Negar.PersianCalendar.UI.Controls.PersianDatePicker FromDateRef;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput ToTimeRef;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput FromTimeRef;
        private DevComponents.DotNetBar.LabelX lblRefToTime;
        private DevComponents.DotNetBar.LabelX lblRefFromTime;
        private DevComponents.DotNetBar.LabelX lblEDate1;
        private DevComponents.DotNetBar.LabelX lblSDate1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvServiceGroups;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxServiceGroups;
        private DevComponents.DotNetBar.Controls.ProgressBarX ProgressBar;
        private System.ComponentModel.BackgroundWorker BGWorker;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColCatSelection;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCatName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColGroupSelection;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColGroupName;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvPerformers;
        private DevComponents.DotNetBar.Controls.TextBoxX txtReportTitle;
        private DevComponents.DotNetBar.LabelX lblReportTitle;
        private DevComponents.DotNetBar.LabelX lblPercent;
        private DevComponents.Editors.IntegerInput txtPercent;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColPerformerSelection;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPerformerName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColIsExpert;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColIsPhysician;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxPerformers;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxRefPhysycian;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvRefPhysician;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvService;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxService;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPhysName;
        private DevComponents.DotNetBar.LabelX lblPerformer;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColRefPhysicianSelection;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRefPhysicianName;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvDocUser;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColDocUserSelection;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDocUserFullName;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxDocTypist;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxCDType;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvCostsAndDiscounts;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColCDTypeSelection;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCDTypeName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColServiceSelection;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColServiceCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColServiceName;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxSpecial1;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxIns2;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvIns1;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxIns1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvIns2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColInsSelection1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColInsName1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColInsSelection2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColInsName2;
    }
}