namespace Sepehr.Forms.Reports.General.Report07
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
            this.PanelSort = new System.Windows.Forms.Panel();
            this.cBoxOrder1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cBoxOrder2 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cBoxServiceCat = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.dgvServiceCat = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ColCatSelection = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColCatName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblInsName = new DevComponents.DotNetBar.LabelX();
            this.txtInsName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.ProgressBar = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.cBoxPrescribeDateFilter = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cBoxRefDateFilter = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.btnHelp = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnReport = new DevComponents.DotNetBar.ButtonX();
            this.PanelRefDateTimeFilter = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.lblToRefTime = new DevComponents.DotNetBar.LabelX();
            this.lblFromRefTime = new DevComponents.DotNetBar.LabelX();
            this.lblToRefDate = new DevComponents.DotNetBar.LabelX();
            this.lblFromRefDate = new DevComponents.DotNetBar.LabelX();
            this.ToDateRef = new Negar.PersianCalendar.UI.Controls.PersianDatePicker();
            this.FromDateRef = new Negar.PersianCalendar.UI.Controls.PersianDatePicker();
            this.ToTimeRef = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.FromTimeRef = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.dgvInsFilter = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ColInsSelection = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColInsName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PanelPrescribeDate = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.lblToDatePrescribe = new DevComponents.DotNetBar.LabelX();
            this.lblFromDatePrescribe = new DevComponents.DotNetBar.LabelX();
            this.ToDatePrescription = new Negar.PersianCalendar.UI.Controls.PersianDatePicker();
            this.FromDatePrescription = new Negar.PersianCalendar.UI.Controls.PersianDatePicker();
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.BGWorker = new System.ComponentModel.BackgroundWorker();
            this.FormPanel.SuspendLayout();
            this.PanelSort.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiceCat)).BeginInit();
            this.PanelRefDateTimeFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToTimeRef)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromTimeRef)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInsFilter)).BeginInit();
            this.PanelPrescribeDate.SuspendLayout();
            this.SuspendLayout();
            // 
            // FormPanel
            // 
            this.FormPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.FormPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.FormPanel.Controls.Add(this.PanelSort);
            this.FormPanel.Controls.Add(this.cBoxServiceCat);
            this.FormPanel.Controls.Add(this.dgvServiceCat);
            this.FormPanel.Controls.Add(this.lblInsName);
            this.FormPanel.Controls.Add(this.txtInsName);
            this.FormPanel.Controls.Add(this.ProgressBar);
            this.FormPanel.Controls.Add(this.cBoxPrescribeDateFilter);
            this.FormPanel.Controls.Add(this.cBoxRefDateFilter);
            this.FormPanel.Controls.Add(this.btnHelp);
            this.FormPanel.Controls.Add(this.btnCancel);
            this.FormPanel.Controls.Add(this.btnReport);
            this.FormPanel.Controls.Add(this.PanelRefDateTimeFilter);
            this.FormPanel.Controls.Add(this.dgvInsFilter);
            this.FormPanel.Controls.Add(this.PanelPrescribeDate);
            this.FormPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormPanel.Location = new System.Drawing.Point(0, 0);
            this.FormPanel.Name = "FormPanel";
            this.FormPanel.Size = new System.Drawing.Size(630, 557);
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
            // PanelSort
            // 
            this.PanelSort.BackColor = System.Drawing.Color.Transparent;
            this.PanelSort.Controls.Add(this.cBoxOrder1);
            this.PanelSort.Controls.Add(this.cBoxOrder2);
            this.PanelSort.Location = new System.Drawing.Point(283, 485);
            this.PanelSort.Name = "PanelSort";
            this.PanelSort.Size = new System.Drawing.Size(235, 45);
            this.PanelSort.TabIndex = 10;
            // 
            // cBoxOrder1
            // 
            this.cBoxOrder1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxOrder1.AutoSize = true;
            this.cBoxOrder1.BackColor = System.Drawing.Color.Transparent;
            this.cBoxOrder1.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.cBoxOrder1.Checked = true;
            this.cBoxOrder1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBoxOrder1.CheckValue = "Y";
            this.cBoxOrder1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxOrder1.Location = new System.Drawing.Point(12, 3);
            this.cBoxOrder1.Name = "cBoxOrder1";
            this.cBoxOrder1.Size = new System.Drawing.Size(215, 16);
            this.cBoxOrder1.TabIndex = 0;
            this.cBoxOrder1.Text = "ترتیب بر اساس تاریخ نسخه و مراجعه";
            // 
            // cBoxOrder2
            // 
            this.cBoxOrder2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxOrder2.AutoSize = true;
            this.cBoxOrder2.BackColor = System.Drawing.Color.Transparent;
            this.cBoxOrder2.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.cBoxOrder2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxOrder2.Location = new System.Drawing.Point(12, 25);
            this.cBoxOrder2.Name = "cBoxOrder2";
            this.cBoxOrder2.Size = new System.Drawing.Size(215, 16);
            this.cBoxOrder2.TabIndex = 1;
            this.cBoxOrder2.Text = "ترتیب بر اساس تاریخ مراجعه و نسخه";
            // 
            // cBoxServiceCat
            // 
            this.cBoxServiceCat.AutoSize = true;
            this.cBoxServiceCat.BackColor = System.Drawing.Color.Transparent;
            this.cBoxServiceCat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxServiceCat.Location = new System.Drawing.Point(113, 70);
            this.cBoxServiceCat.Name = "cBoxServiceCat";
            this.cBoxServiceCat.Size = new System.Drawing.Size(199, 16);
            this.cBoxServiceCat.TabIndex = 6;
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
            this.dgvServiceCat.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dgvServiceCat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvServiceCat.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvServiceCat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServiceCat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColCatSelection,
            this.ColCatName});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvServiceCat.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvServiceCat.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvServiceCat.Location = new System.Drawing.Point(12, 92);
            this.dgvServiceCat.MultiSelect = false;
            this.dgvServiceCat.Name = "dgvServiceCat";
            this.dgvServiceCat.RowHeadersVisible = false;
            this.dgvServiceCat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvServiceCat.Size = new System.Drawing.Size(300, 362);
            this.dgvServiceCat.TabIndex = 5;
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
            // lblInsName
            // 
            this.lblInsName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInsName.AutoSize = true;
            this.lblInsName.BackColor = System.Drawing.Color.Transparent;
            this.lblInsName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblInsName.Location = new System.Drawing.Point(571, 461);
            this.lblInsName.Name = "lblInsName";
            this.lblInsName.Size = new System.Drawing.Size(47, 16);
            this.lblInsName.TabIndex = 8;
            this.lblInsName.Text = "نام بیمه:";
            this.lblInsName.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // txtInsName
            // 
            this.txtInsName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtInsName.Border.Class = "TextBoxBorder";
            this.txtInsName.Location = new System.Drawing.Point(318, 459);
            this.txtInsName.Name = "txtInsName";
            this.txtInsName.Size = new System.Drawing.Size(247, 21);
            this.txtInsName.TabIndex = 7;
            this.txtInsName.WatermarkText = "نام بیمه برای نمایش در گزارش";
            // 
            // ProgressBar
            // 
            this.ProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressBar.Location = new System.Drawing.Point(12, 458);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(300, 23);
            this.ProgressBar.TabIndex = 9;
            this.ProgressBar.TabStop = false;
            this.ProgressBar.Text = "در انتظار ایجاد گزارش";
            this.ProgressBar.TextVisible = true;
            // 
            // cBoxPrescribeDateFilter
            // 
            this.cBoxPrescribeDateFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxPrescribeDateFilter.BackColor = System.Drawing.Color.Transparent;
            this.cBoxPrescribeDateFilter.Location = new System.Drawing.Point(292, 6);
            this.cBoxPrescribeDateFilter.Name = "cBoxPrescribeDateFilter";
            this.cBoxPrescribeDateFilter.Size = new System.Drawing.Size(20, 16);
            this.cBoxPrescribeDateFilter.TabIndex = 11;
            this.cBoxPrescribeDateFilter.TabStop = false;
            this.cBoxPrescribeDateFilter.CheckedChanged += new System.EventHandler(this.cBoxPrescribeDateFilter_CheckedChanged);
            // 
            // cBoxRefDateFilter
            // 
            this.cBoxRefDateFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxRefDateFilter.BackColor = System.Drawing.Color.Transparent;
            this.cBoxRefDateFilter.Checked = true;
            this.cBoxRefDateFilter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBoxRefDateFilter.CheckValue = "Y";
            this.cBoxRefDateFilter.Location = new System.Drawing.Point(598, 5);
            this.cBoxRefDateFilter.Name = "cBoxRefDateFilter";
            this.cBoxRefDateFilter.Size = new System.Drawing.Size(20, 16);
            this.cBoxRefDateFilter.TabIndex = 10;
            this.cBoxRefDateFilter.TabStop = false;
            this.cBoxRefDateFilter.CheckedChanged += new System.EventHandler(this.cBoxRefDateFilter_CheckedChanged);
            // 
            // btnHelp
            // 
            this.btnHelp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnHelp.Image = global::Sepehr.Forms.Reports.Properties.Resources.Help;
            this.btnHelp.Location = new System.Drawing.Point(523, 488);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F1);
            this.btnHelp.Size = new System.Drawing.Size(95, 57);
            this.btnHelp.TabIndex = 13;
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
            this.btnCancel.Location = new System.Drawing.Point(113, 488);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 57);
            this.btnCancel.TabIndex = 12;
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
            this.btnReport.Location = new System.Drawing.Point(12, 488);
            this.btnReport.Name = "btnReport";
            this.btnReport.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnReport.Size = new System.Drawing.Size(95, 57);
            this.btnReport.TabIndex = 11;
            this.btnReport.TabStop = false;
            this.btnReport.Text = "گزارش(F8)";
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // PanelRefDateTimeFilter
            // 
            this.PanelRefDateTimeFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelRefDateTimeFilter.BackColor = System.Drawing.Color.Transparent;
            this.PanelRefDateTimeFilter.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelRefDateTimeFilter.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelRefDateTimeFilter.Controls.Add(this.lblToRefTime);
            this.PanelRefDateTimeFilter.Controls.Add(this.lblFromRefTime);
            this.PanelRefDateTimeFilter.Controls.Add(this.lblToRefDate);
            this.PanelRefDateTimeFilter.Controls.Add(this.lblFromRefDate);
            this.PanelRefDateTimeFilter.Controls.Add(this.ToDateRef);
            this.PanelRefDateTimeFilter.Controls.Add(this.FromDateRef);
            this.PanelRefDateTimeFilter.Controls.Add(this.ToTimeRef);
            this.PanelRefDateTimeFilter.Controls.Add(this.FromTimeRef);
            this.PanelRefDateTimeFilter.DrawTitleBox = false;
            this.PanelRefDateTimeFilter.Font = new System.Drawing.Font("Tahoma", 8.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.PanelRefDateTimeFilter.Location = new System.Drawing.Point(318, 11);
            this.PanelRefDateTimeFilter.Name = "PanelRefDateTimeFilter";
            this.PanelRefDateTimeFilter.Size = new System.Drawing.Size(300, 75);
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
            this.PanelRefDateTimeFilter.TabIndex = 0;
            this.PanelRefDateTimeFilter.Text = "تاریخ پذیرش مراجعه";
            // 
            // lblToRefTime
            // 
            this.lblToRefTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblToRefTime.AutoSize = true;
            this.lblToRefTime.BackColor = System.Drawing.Color.Transparent;
            this.lblToRefTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblToRefTime.Location = new System.Drawing.Point(89, 32);
            this.lblToRefTime.Name = "lblToRefTime";
            this.lblToRefTime.Size = new System.Drawing.Size(52, 16);
            this.lblToRefTime.TabIndex = 10;
            this.lblToRefTime.Text = "تا ساعت:";
            this.lblToRefTime.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblFromRefTime
            // 
            this.lblFromRefTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFromRefTime.AutoSize = true;
            this.lblFromRefTime.BackColor = System.Drawing.Color.Transparent;
            this.lblFromRefTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblFromRefTime.Location = new System.Drawing.Point(89, 6);
            this.lblFromRefTime.Name = "lblFromRefTime";
            this.lblFromRefTime.Size = new System.Drawing.Size(53, 16);
            this.lblFromRefTime.TabIndex = 8;
            this.lblFromRefTime.Text = "از ساعت:";
            this.lblFromRefTime.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblToRefDate
            // 
            this.lblToRefDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblToRefDate.AutoSize = true;
            this.lblToRefDate.BackColor = System.Drawing.Color.Transparent;
            this.lblToRefDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblToRefDate.Location = new System.Drawing.Point(240, 32);
            this.lblToRefDate.Name = "lblToRefDate";
            this.lblToRefDate.Size = new System.Drawing.Size(42, 16);
            this.lblToRefDate.TabIndex = 9;
            this.lblToRefDate.Text = "تا تاریخ:";
            this.lblToRefDate.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblFromRefDate
            // 
            this.lblFromRefDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFromRefDate.AutoSize = true;
            this.lblFromRefDate.BackColor = System.Drawing.Color.Transparent;
            this.lblFromRefDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblFromRefDate.Location = new System.Drawing.Point(240, 6);
            this.lblFromRefDate.Name = "lblFromRefDate";
            this.lblFromRefDate.Size = new System.Drawing.Size(43, 16);
            this.lblFromRefDate.TabIndex = 7;
            this.lblFromRefDate.Text = "از تاریخ:";
            this.lblFromRefDate.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // ToDateRef
            // 
            this.ToDateRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ToDateRef.IsAllowNullDate = false;
            this.ToDateRef.IsPopupOpen = false;
            this.ToDateRef.Location = new System.Drawing.Point(150, 30);
            this.ToDateRef.Name = "ToDateRef";
            this.ToDateRef.SelectedDateTime = new System.DateTime(2009, 7, 16, 10, 41, 0, 0);
            this.ToDateRef.Size = new System.Drawing.Size(84, 20);
            this.ToDateRef.TabIndex = 2;
            // 
            // FromDateRef
            // 
            this.FromDateRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FromDateRef.IsAllowNullDate = false;
            this.FromDateRef.IsPopupOpen = false;
            this.FromDateRef.Location = new System.Drawing.Point(150, 4);
            this.FromDateRef.Name = "FromDateRef";
            this.FromDateRef.SelectedDateTime = new System.DateTime(2009, 7, 16, 10, 41, 0, 0);
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
            this.ToTimeRef.Location = new System.Drawing.Point(11, 30);
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
            this.ToTimeRef.Size = new System.Drawing.Size(75, 21);
            this.ToTimeRef.TabIndex = 3;
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
            this.FromTimeRef.Location = new System.Drawing.Point(11, 4);
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
            this.FromTimeRef.Size = new System.Drawing.Size(75, 21);
            this.FromTimeRef.TabIndex = 1;
            this.FromTimeRef.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            // 
            // dgvInsFilter
            // 
            this.dgvInsFilter.AllowUserToAddRows = false;
            this.dgvInsFilter.AllowUserToDeleteRows = false;
            this.dgvInsFilter.AllowUserToOrderColumns = true;
            this.dgvInsFilter.AllowUserToResizeColumns = false;
            this.dgvInsFilter.AllowUserToResizeRows = false;
            this.dgvInsFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInsFilter.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dgvInsFilter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInsFilter.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvInsFilter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInsFilter.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColInsSelection,
            this.ColInsName});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInsFilter.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvInsFilter.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvInsFilter.Location = new System.Drawing.Point(318, 92);
            this.dgvInsFilter.MultiSelect = false;
            this.dgvInsFilter.Name = "dgvInsFilter";
            this.dgvInsFilter.RowHeadersVisible = false;
            this.dgvInsFilter.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInsFilter.Size = new System.Drawing.Size(300, 363);
            this.dgvInsFilter.StandardTab = true;
            this.dgvInsFilter.TabIndex = 4;
            // 
            // ColInsSelection
            // 
            this.ColInsSelection.HeaderText = "اضافه";
            this.ColInsSelection.Name = "ColInsSelection";
            this.ColInsSelection.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColInsSelection.Width = 35;
            // 
            // ColInsName
            // 
            this.ColInsName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColInsName.DataPropertyName = "Name";
            this.ColInsName.HeaderText = "نام بیمه";
            this.ColInsName.Name = "ColInsName";
            this.ColInsName.ReadOnly = true;
            // 
            // PanelPrescribeDate
            // 
            this.PanelPrescribeDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelPrescribeDate.BackColor = System.Drawing.Color.Transparent;
            this.PanelPrescribeDate.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelPrescribeDate.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelPrescribeDate.Controls.Add(this.lblToDatePrescribe);
            this.PanelPrescribeDate.Controls.Add(this.lblFromDatePrescribe);
            this.PanelPrescribeDate.Controls.Add(this.ToDatePrescription);
            this.PanelPrescribeDate.Controls.Add(this.FromDatePrescription);
            this.PanelPrescribeDate.DrawTitleBox = false;
            this.PanelPrescribeDate.Enabled = false;
            this.PanelPrescribeDate.Font = new System.Drawing.Font("Tahoma", 8.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.PanelPrescribeDate.Location = new System.Drawing.Point(12, 12);
            this.PanelPrescribeDate.Name = "PanelPrescribeDate";
            this.PanelPrescribeDate.Size = new System.Drawing.Size(300, 50);
            // 
            // 
            // 
            this.PanelPrescribeDate.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.PanelPrescribeDate.Style.BackColorGradientAngle = 90;
            this.PanelPrescribeDate.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.PanelPrescribeDate.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelPrescribeDate.Style.BorderBottomWidth = 1;
            this.PanelPrescribeDate.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.PanelPrescribeDate.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelPrescribeDate.Style.BorderLeftWidth = 1;
            this.PanelPrescribeDate.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelPrescribeDate.Style.BorderRightWidth = 1;
            this.PanelPrescribeDate.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelPrescribeDate.Style.BorderTopWidth = 1;
            this.PanelPrescribeDate.Style.CornerDiameter = 4;
            this.PanelPrescribeDate.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.PanelPrescribeDate.Style.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(0)))), ((int)(((byte)(132)))));
            this.PanelPrescribeDate.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.PanelPrescribeDate.TabIndex = 1;
            this.PanelPrescribeDate.Text = "تاریخ نسخه ی مراجعه";
            // 
            // lblToDatePrescribe
            // 
            this.lblToDatePrescribe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblToDatePrescribe.AutoSize = true;
            this.lblToDatePrescribe.BackColor = System.Drawing.Color.Transparent;
            this.lblToDatePrescribe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblToDatePrescribe.Location = new System.Drawing.Point(100, 6);
            this.lblToDatePrescribe.Name = "lblToDatePrescribe";
            this.lblToDatePrescribe.Size = new System.Drawing.Size(42, 16);
            this.lblToDatePrescribe.TabIndex = 13;
            this.lblToDatePrescribe.Text = "تا تاریخ:";
            this.lblToDatePrescribe.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblFromDatePrescribe
            // 
            this.lblFromDatePrescribe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFromDatePrescribe.AutoSize = true;
            this.lblFromDatePrescribe.BackColor = System.Drawing.Color.Transparent;
            this.lblFromDatePrescribe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblFromDatePrescribe.Location = new System.Drawing.Point(240, 6);
            this.lblFromDatePrescribe.Name = "lblFromDatePrescribe";
            this.lblFromDatePrescribe.Size = new System.Drawing.Size(43, 16);
            this.lblFromDatePrescribe.TabIndex = 11;
            this.lblFromDatePrescribe.Text = "از تاریخ:";
            this.lblFromDatePrescribe.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // ToDatePrescription
            // 
            this.ToDatePrescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ToDatePrescription.IsAllowNullDate = false;
            this.ToDatePrescription.IsPopupOpen = false;
            this.ToDatePrescription.Location = new System.Drawing.Point(10, 4);
            this.ToDatePrescription.Name = "ToDatePrescription";
            this.ToDatePrescription.SelectedDateTime = new System.DateTime(2009, 7, 16, 10, 41, 0, 0);
            this.ToDatePrescription.Size = new System.Drawing.Size(84, 20);
            this.ToDatePrescription.TabIndex = 2;
            // 
            // FromDatePrescription
            // 
            this.FromDatePrescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FromDatePrescription.IsAllowNullDate = false;
            this.FromDatePrescription.IsPopupOpen = false;
            this.FromDatePrescription.Location = new System.Drawing.Point(150, 4);
            this.FromDatePrescription.Name = "FromDatePrescription";
            this.FromDatePrescription.SelectedDateTime = new System.DateTime(2009, 7, 16, 10, 41, 0, 0);
            this.FromDatePrescription.Size = new System.Drawing.Size(84, 20);
            this.FromDatePrescription.TabIndex = 0;
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
            this.ClientSize = new System.Drawing.Size(630, 557);
            this.Controls.Add(this.FormPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(636, 582);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(636, 582);
            this.Name = "frmFilter";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "گزارش های حسابداری - گزارش بررسی پذیرش نسخ بیمه های اول به تفصیل";
            this.Shown += new System.EventHandler(this.frmInsurancesFilter_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.FormPanel.ResumeLayout(false);
            this.FormPanel.PerformLayout();
            this.PanelSort.ResumeLayout(false);
            this.PanelSort.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiceCat)).EndInit();
            this.PanelRefDateTimeFilter.ResumeLayout(false);
            this.PanelRefDateTimeFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToTimeRef)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromTimeRef)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInsFilter)).EndInit();
            this.PanelPrescribeDate.ResumeLayout(false);
            this.PanelPrescribeDate.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel FormPanel;
        private DevComponents.DotNetBar.ButtonX btnHelp;
        private DevComponents.DotNetBar.ButtonX btnReport;
        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput FromTimeRef;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput ToTimeRef;
        private Negar.PersianCalendar.UI.Controls.PersianDatePicker FromDateRef;
        private Negar.PersianCalendar.UI.Controls.PersianDatePicker ToDateRef;
        private DevComponents.DotNetBar.Controls.GroupPanel PanelRefDateTimeFilter;
        private Negar.PersianCalendar.UI.Controls.PersianDatePicker FromDatePrescription;
        private Negar.PersianCalendar.UI.Controls.PersianDatePicker ToDatePrescription;
        private DevComponents.DotNetBar.Controls.GroupPanel PanelPrescribeDate;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxPrescribeDateFilter;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvInsFilter;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxRefDateFilter;
        private System.ComponentModel.BackgroundWorker BGWorker;
        private DevComponents.DotNetBar.Controls.ProgressBarX ProgressBar;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColInsSelection;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColInsName;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.LabelX lblInsName;
        private DevComponents.DotNetBar.Controls.TextBoxX txtInsName;
        private DevComponents.DotNetBar.LabelX lblToRefTime;
        private DevComponents.DotNetBar.LabelX lblFromRefTime;
        private DevComponents.DotNetBar.LabelX lblToRefDate;
        private DevComponents.DotNetBar.LabelX lblFromRefDate;
        private DevComponents.DotNetBar.LabelX lblToDatePrescribe;
        private DevComponents.DotNetBar.LabelX lblFromDatePrescribe;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxServiceCat;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvServiceCat;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColCatSelection;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCatName;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxOrder1;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxOrder2;
        private System.Windows.Forms.Panel PanelSort;
    }
}