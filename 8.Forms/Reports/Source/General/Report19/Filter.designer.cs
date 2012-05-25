namespace Sepehr.Forms.Reports.General.Report19
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
            this.FormPanel = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.txtLimitation = new DevComponents.Editors.IntegerInput();
            this.txtReportTitle = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.dgvRefPhysician = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ColRefPhysicianSelection = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColRefPhysicianName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProgressBar = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.cBoxLimitation = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cBoxRefPhysycian = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cBoxServiceCat = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.dgvServiceCat = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ColCatSelection = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColCatName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblLimitation = new DevComponents.DotNetBar.LabelX();
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
            this.FormPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLimitation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRefPhysician)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiceCat)).BeginInit();
            this.PanelRefDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToTimeRef)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromTimeRef)).BeginInit();
            this.SuspendLayout();
            // 
            // FormPanel
            // 
            this.FormPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.FormPanel.Controls.Add(this.txtLimitation);
            this.FormPanel.Controls.Add(this.txtReportTitle);
            this.FormPanel.Controls.Add(this.dgvRefPhysician);
            this.FormPanel.Controls.Add(this.ProgressBar);
            this.FormPanel.Controls.Add(this.cBoxLimitation);
            this.FormPanel.Controls.Add(this.cBoxRefPhysycian);
            this.FormPanel.Controls.Add(this.cBoxServiceCat);
            this.FormPanel.Controls.Add(this.dgvServiceCat);
            this.FormPanel.Controls.Add(this.lblLimitation);
            this.FormPanel.Controls.Add(this.lblReportTitle);
            this.FormPanel.Controls.Add(this.btnHelp);
            this.FormPanel.Controls.Add(this.btnCancel);
            this.FormPanel.Controls.Add(this.btnReport);
            this.FormPanel.Controls.Add(this.PanelRefDate);
            this.FormPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormPanel.Location = new System.Drawing.Point(0, 0);
            this.FormPanel.Name = "FormPanel";
            this.FormPanel.Size = new System.Drawing.Size(612, 483);
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
            // txtLimitation
            // 
            this.txtLimitation.AllowEmptyState = false;
            this.txtLimitation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtLimitation.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtLimitation.Enabled = false;
            this.txtLimitation.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtLimitation.Location = new System.Drawing.Point(80, 34);
            this.txtLimitation.MaxValue = 99999;
            this.txtLimitation.MinValue = 1;
            this.txtLimitation.Name = "txtLimitation";
            this.txtLimitation.ShowUpDown = true;
            this.txtLimitation.Size = new System.Drawing.Size(63, 21);
            this.txtLimitation.TabIndex = 14;
            this.txtLimitation.Value = 1;
            // 
            // txtReportTitle
            // 
            this.txtReportTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtReportTitle.Border.Class = "TextBoxBorder";
            this.txtReportTitle.Location = new System.Drawing.Point(11, 8);
            this.txtReportTitle.Name = "txtReportTitle";
            this.txtReportTitle.Size = new System.Drawing.Size(207, 21);
            this.txtReportTitle.TabIndex = 11;
            this.txtReportTitle.Text = "گزارش ارجاعات پزشكان درخواست كننده";
            // 
            // dgvRefPhysician
            // 
            this.dgvRefPhysician.AllowUserToAddRows = false;
            this.dgvRefPhysician.AllowUserToDeleteRows = false;
            this.dgvRefPhysician.AllowUserToOrderColumns = true;
            this.dgvRefPhysician.AllowUserToResizeColumns = false;
            this.dgvRefPhysician.AllowUserToResizeRows = false;
            this.dgvRefPhysician.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvRefPhysician.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dgvRefPhysician.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRefPhysician.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRefPhysician.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRefPhysician.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColRefPhysicianSelection,
            this.ColRefPhysicianName});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRefPhysician.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRefPhysician.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvRefPhysician.Location = new System.Drawing.Point(11, 86);
            this.dgvRefPhysician.MultiSelect = false;
            this.dgvRefPhysician.Name = "dgvRefPhysician";
            this.dgvRefPhysician.RowHeadersVisible = false;
            this.dgvRefPhysician.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRefPhysician.Size = new System.Drawing.Size(293, 322);
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
            // ProgressBar
            // 
            this.ProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressBar.Location = new System.Drawing.Point(214, 433);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(283, 23);
            this.ProgressBar.TabIndex = 16;
            this.ProgressBar.TabStop = false;
            this.ProgressBar.Text = "در انتظار ایجاد گزارش";
            this.ProgressBar.TextVisible = true;
            // 
            // cBoxLimitation
            // 
            this.cBoxLimitation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxLimitation.AutoSize = true;
            this.cBoxLimitation.BackColor = System.Drawing.Color.Transparent;
            this.cBoxLimitation.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxLimitation.Location = new System.Drawing.Point(149, 36);
            this.cBoxLimitation.Name = "cBoxLimitation";
            this.cBoxLimitation.Size = new System.Drawing.Size(150, 16);
            this.cBoxLimitation.TabIndex = 3;
            this.cBoxLimitation.Text = "نمایش پزشكان با بیش از ";
            this.cBoxLimitation.CheckedChanged += new System.EventHandler(this.cBoxLimitation_CheckedChanged);
            // 
            // cBoxRefPhysycian
            // 
            this.cBoxRefPhysycian.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxRefPhysycian.AutoSize = true;
            this.cBoxRefPhysycian.BackColor = System.Drawing.Color.Transparent;
            this.cBoxRefPhysycian.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxRefPhysycian.Location = new System.Drawing.Point(82, 64);
            this.cBoxRefPhysycian.Name = "cBoxRefPhysycian";
            this.cBoxRefPhysycian.Size = new System.Drawing.Size(217, 16);
            this.cBoxRefPhysycian.TabIndex = 3;
            this.cBoxRefPhysycian.Text = "انتخاب پزشك درخواست كننده مراجعه";
            this.cBoxRefPhysycian.CheckedChanged += new System.EventHandler(this.cBoxRefPhysycian_CheckedChanged);
            // 
            // cBoxServiceCat
            // 
            this.cBoxServiceCat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxServiceCat.AutoSize = true;
            this.cBoxServiceCat.BackColor = System.Drawing.Color.Transparent;
            this.cBoxServiceCat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxServiceCat.Location = new System.Drawing.Point(399, 90);
            this.cBoxServiceCat.Name = "cBoxServiceCat";
            this.cBoxServiceCat.Size = new System.Drawing.Size(199, 16);
            this.cBoxServiceCat.TabIndex = 5;
            this.cBoxServiceCat.Text = "فقط خدمات در طبقه بندی های زیر";
            this.cBoxServiceCat.CheckedChanged += new System.EventHandler(this.cBoxServiceCat_CheckedChanged);
            // 
            // dgvServiceCat
            // 
            this.dgvServiceCat.AllowUserToAddRows = false;
            this.dgvServiceCat.AllowUserToDeleteRows = false;
            this.dgvServiceCat.AllowUserToOrderColumns = true;
            this.dgvServiceCat.AllowUserToResizeColumns = false;
            this.dgvServiceCat.AllowUserToResizeRows = false;
            this.dgvServiceCat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvServiceCat.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dgvServiceCat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvServiceCat.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvServiceCat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServiceCat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColCatSelection,
            this.ColCatName});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvServiceCat.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvServiceCat.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvServiceCat.Location = new System.Drawing.Point(310, 112);
            this.dgvServiceCat.MultiSelect = false;
            this.dgvServiceCat.Name = "dgvServiceCat";
            this.dgvServiceCat.RowHeadersVisible = false;
            this.dgvServiceCat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvServiceCat.Size = new System.Drawing.Size(288, 296);
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
            // lblLimitation
            // 
            this.lblLimitation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLimitation.AutoSize = true;
            this.lblLimitation.BackColor = System.Drawing.Color.Transparent;
            this.lblLimitation.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblLimitation.Location = new System.Drawing.Point(34, 36);
            this.lblLimitation.Name = "lblLimitation";
            this.lblLimitation.Size = new System.Drawing.Size(40, 16);
            this.lblLimitation.TabIndex = 12;
            this.lblLimitation.Text = "مراجعه";
            this.lblLimitation.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblReportTitle
            // 
            this.lblReportTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReportTitle.AutoSize = true;
            this.lblReportTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblReportTitle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblReportTitle.Location = new System.Drawing.Point(224, 10);
            this.lblReportTitle.Name = "lblReportTitle";
            this.lblReportTitle.Size = new System.Drawing.Size(75, 16);
            this.lblReportTitle.TabIndex = 12;
            this.lblReportTitle.Text = "عنوان گزارش:";
            this.lblReportTitle.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // btnHelp
            // 
            this.btnHelp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnHelp.Image = global::Sepehr.Forms.Reports.Properties.Resources.Help;
            this.btnHelp.Location = new System.Drawing.Point(503, 414);
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
            this.btnCancel.Location = new System.Drawing.Point(113, 414);
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
            this.btnReport.Location = new System.Drawing.Point(12, 414);
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
            this.PanelRefDate.Location = new System.Drawing.Point(305, 8);
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
            this.PanelRefDate.Text = "تاریخ پذیرش مراجعات";
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
            // frmFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(612, 483);
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
            this.Text = "گزارش های عمومی - گزارش عملكرد پزشكان ارجاع دهنده - به تفكیك طبقه بندی خدمات";
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.FormPanel.ResumeLayout(false);
            this.FormPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLimitation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRefPhysician)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiceCat)).EndInit();
            this.PanelRefDate.ResumeLayout(false);
            this.PanelRefDate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToTimeRef)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromTimeRef)).EndInit();
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
        private DevComponents.DotNetBar.Controls.ProgressBarX ProgressBar;
        private System.ComponentModel.BackgroundWorker BGWorker;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColCatSelection;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCatName;
        private DevComponents.DotNetBar.Controls.TextBoxX txtReportTitle;
        private DevComponents.DotNetBar.LabelX lblReportTitle;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxRefPhysycian;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvRefPhysician;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColRefPhysicianSelection;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRefPhysicianName;
        private DevComponents.Editors.IntegerInput txtLimitation;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxLimitation;
        private DevComponents.DotNetBar.LabelX lblLimitation;
    }
}