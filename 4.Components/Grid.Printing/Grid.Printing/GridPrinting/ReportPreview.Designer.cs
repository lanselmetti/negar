namespace Negar.GridPrinting
{
    partial class frmReportPreview 
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportPreview));
            this.PanelBotton = new DevComponents.DotNetBar.PanelEx();
            this.ProgressBar = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.cmsForm = new DevComponents.DotNetBar.ContextMenuBar();
            this.cmsMenuRows = new DevComponents.DotNetBar.ButtonItem();
            this.btnRowAddUp = new DevComponents.DotNetBar.ButtonItem();
            this.btnRowAddDown = new DevComponents.DotNetBar.ButtonItem();
            this.btnRowMoveUp = new DevComponents.DotNetBar.ButtonItem();
            this.btnRowMoveDown = new DevComponents.DotNetBar.ButtonItem();
            this.btnRowRemove = new DevComponents.DotNetBar.ButtonItem();
            this.cmsMenuCols = new DevComponents.DotNetBar.ButtonItem();
            this.btnColAddRight = new DevComponents.DotNetBar.ButtonItem();
            this.btnColAddLeft = new DevComponents.DotNetBar.ButtonItem();
            this.btnColEdit = new DevComponents.DotNetBar.ButtonItem();
            this.btnColRightAlign = new DevComponents.DotNetBar.ButtonItem();
            this.btnColCenterAlign = new DevComponents.DotNetBar.ButtonItem();
            this.btnColLeftAlign = new DevComponents.DotNetBar.ButtonItem();
            this.btnColRemove = new DevComponents.DotNetBar.ButtonItem();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnExportToExcel = new DevComponents.DotNetBar.ButtonX();
            this.btnPrintSettings = new DevComponents.DotNetBar.ButtonX();
            this.btnView = new DevComponents.DotNetBar.ButtonX();
            this.btnEditRowFonts = new DevComponents.DotNetBar.ButtonX();
            this.TabControlForm = new DevComponents.DotNetBar.TabControl();
            this.TCPResults = new DevComponents.DotNetBar.TabControlPanel();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.TabItemResults = new DevComponents.DotNetBar.TabItem(this.components);
            this.TCPSettings = new DevComponents.DotNetBar.TabControlPanel();
            this.txtRowsLimitation = new DevComponents.Editors.IntegerInput();
            this.lblRowsLimitation = new DevComponents.DotNetBar.LabelX();
            this.lblTitle3 = new DevComponents.DotNetBar.LabelX();
            this.lblTitle2 = new DevComponents.DotNetBar.LabelX();
            this.lblTitle1 = new DevComponents.DotNetBar.LabelX();
            this.btnEditColFonts = new DevComponents.DotNetBar.ButtonX();
            this.txtHeaderTitle3 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtHeaderTitle2 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtHeaderTitle1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.TabItemSettings = new DevComponents.DotNetBar.TabItem(this.components);
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.FontDialogBox = new System.Windows.Forms.FontDialog();
            this.ReportPageSetupDialog = new System.Windows.Forms.PageSetupDialog();
            this.ExcelSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.BGWorker = new System.ComponentModel.BackgroundWorker();
            this.PanelBotton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmsForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TabControlForm)).BeginInit();
            this.TabControlForm.SuspendLayout();
            this.TCPResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.TCPSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRowsLimitation)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelBotton
            // 
            this.PanelBotton.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelBotton.Controls.Add(this.ProgressBar);
            this.PanelBotton.Controls.Add(this.cmsForm);
            this.PanelBotton.Controls.Add(this.btnCancel);
            this.PanelBotton.Controls.Add(this.btnExportToExcel);
            this.PanelBotton.Controls.Add(this.btnPrintSettings);
            this.PanelBotton.Controls.Add(this.btnView);
            this.PanelBotton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelBotton.Location = new System.Drawing.Point(0, 482);
            this.PanelBotton.Name = "PanelBotton";
            this.PanelBotton.Size = new System.Drawing.Size(784, 80);
            this.PanelBotton.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.PanelBotton.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.PanelBotton.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.PanelBotton.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.PanelBotton.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.PanelBotton.Style.GradientAngle = 90;
            this.PanelBotton.TabIndex = 1;
            // 
            // ProgressBar
            // 
            this.ProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressBar.Location = new System.Drawing.Point(314, 45);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.ProgressType = DevComponents.DotNetBar.eProgressItemType.Marquee;
            this.ProgressBar.Size = new System.Drawing.Size(158, 23);
            this.ProgressBar.TabIndex = 1;
            this.ProgressBar.TabStop = false;
            this.ProgressBar.Text = "در حال ایجاد گزارش اكسل";
            this.ProgressBar.TextVisible = true;
            this.ProgressBar.Visible = false;
            // 
            // cmsForm
            // 
            this.cmsForm.DockSide = DevComponents.DotNetBar.eDockSide.Bottom;
            this.cmsForm.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmsForm.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.cmsMenuRows,
            this.cmsMenuCols});
            this.cmsForm.Location = new System.Drawing.Point(349, 11);
            this.cmsForm.Name = "cmsForm";
            this.cmsForm.Size = new System.Drawing.Size(123, 25);
            this.cmsForm.Stretch = true;
            this.cmsForm.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.cmsForm.TabIndex = 79;
            this.cmsForm.TabStop = false;
            // 
            // cmsMenuRows
            // 
            this.cmsMenuRows.AutoExpandOnClick = true;
            this.cmsMenuRows.ImagePaddingHorizontal = 8;
            this.cmsMenuRows.Name = "cmsMenuRows";
            this.cmsMenuRows.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnRowAddUp,
            this.btnRowAddDown,
            this.btnRowMoveUp,
            this.btnRowMoveDown,
            this.btnRowRemove});
            this.cmsMenuRows.Text = "ردیفها";
            // 
            // btnRowAddUp
            // 
            this.btnRowAddUp.FontBold = true;
            this.btnRowAddUp.ForeColor = System.Drawing.Color.Green;
            this.btnRowAddUp.ImagePaddingHorizontal = 8;
            this.btnRowAddUp.Name = "btnRowAddUp";
            this.btnRowAddUp.Text = "افزوده ردیف قبل از این ردیف";
            this.btnRowAddUp.Click += new System.EventHandler(this.btnRowAddUp_Click);
            // 
            // btnRowAddDown
            // 
            this.btnRowAddDown.FontBold = true;
            this.btnRowAddDown.ForeColor = System.Drawing.Color.Green;
            this.btnRowAddDown.ImagePaddingHorizontal = 8;
            this.btnRowAddDown.Name = "btnRowAddDown";
            this.btnRowAddDown.Text = "افزوده ردیف بعد از این ردیف";
            this.btnRowAddDown.Click += new System.EventHandler(this.btnRowAddDown_Click);
            // 
            // btnRowMoveUp
            // 
            this.btnRowMoveUp.BeginGroup = true;
            this.btnRowMoveUp.FontBold = true;
            this.btnRowMoveUp.ImagePaddingHorizontal = 8;
            this.btnRowMoveUp.Name = "btnRowMoveUp";
            this.btnRowMoveUp.Text = "انتقال به بالا";
            this.btnRowMoveUp.Click += new System.EventHandler(this.btnRowMoveUp_Click);
            // 
            // btnRowMoveDown
            // 
            this.btnRowMoveDown.FontBold = true;
            this.btnRowMoveDown.ImagePaddingHorizontal = 8;
            this.btnRowMoveDown.Name = "btnRowMoveDown";
            this.btnRowMoveDown.Text = "انتقال به پایین";
            this.btnRowMoveDown.Click += new System.EventHandler(this.btnRowMoveDown_Click);
            // 
            // btnRowRemove
            // 
            this.btnRowRemove.BeginGroup = true;
            this.btnRowRemove.FontBold = true;
            this.btnRowRemove.ForeColor = System.Drawing.Color.Red;
            this.btnRowRemove.ImagePaddingHorizontal = 8;
            this.btnRowRemove.Name = "btnRowRemove";
            this.btnRowRemove.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.Del);
            this.btnRowRemove.Text = "حذف این ردیف";
            this.btnRowRemove.Click += new System.EventHandler(this.btnRowRemove_Click);
            // 
            // cmsMenuCols
            // 
            this.cmsMenuCols.AutoExpandOnClick = true;
            this.cmsMenuCols.ImagePaddingHorizontal = 8;
            this.cmsMenuCols.Name = "cmsMenuCols";
            this.cmsMenuCols.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnColAddRight,
            this.btnColAddLeft,
            this.btnColEdit,
            this.btnColRightAlign,
            this.btnColCenterAlign,
            this.btnColLeftAlign,
            this.btnColRemove});
            this.cmsMenuCols.Text = "ستونها";
            // 
            // btnColAddRight
            // 
            this.btnColAddRight.FontBold = true;
            this.btnColAddRight.ForeColor = System.Drawing.Color.Green;
            this.btnColAddRight.ImagePaddingHorizontal = 8;
            this.btnColAddRight.Name = "btnColAddRight";
            this.btnColAddRight.Text = "افزودن ستون در راست";
            this.btnColAddRight.Click += new System.EventHandler(this.btnColAddRight_Click);
            // 
            // btnColAddLeft
            // 
            this.btnColAddLeft.FontBold = true;
            this.btnColAddLeft.ForeColor = System.Drawing.Color.Green;
            this.btnColAddLeft.ImagePaddingHorizontal = 8;
            this.btnColAddLeft.Name = "btnColAddLeft";
            this.btnColAddLeft.Text = "افزودن ستون در چپ";
            this.btnColAddLeft.Click += new System.EventHandler(this.btnColAddLeft_Click);
            // 
            // btnColEdit
            // 
            this.btnColEdit.BeginGroup = true;
            this.btnColEdit.FontBold = true;
            this.btnColEdit.ForeColor = System.Drawing.Color.Purple;
            this.btnColEdit.ImagePaddingHorizontal = 8;
            this.btnColEdit.Name = "btnColEdit";
            this.btnColEdit.Text = "ویرایش نام ستون";
            this.btnColEdit.Click += new System.EventHandler(this.btnColEdit_Click);
            // 
            // btnColRightAlign
            // 
            this.btnColRightAlign.BeginGroup = true;
            this.btnColRightAlign.FontBold = true;
            this.btnColRightAlign.ImagePaddingHorizontal = 8;
            this.btnColRightAlign.Name = "btnColRightAlign";
            this.btnColRightAlign.Text = "راست چین كردن محتویات";
            this.btnColRightAlign.Click += new System.EventHandler(this.btnColRightAlign_Click);
            // 
            // btnColCenterAlign
            // 
            this.btnColCenterAlign.FontBold = true;
            this.btnColCenterAlign.ImagePaddingHorizontal = 8;
            this.btnColCenterAlign.Name = "btnColCenterAlign";
            this.btnColCenterAlign.Text = "وسط چین كردن محتویات";
            this.btnColCenterAlign.Click += new System.EventHandler(this.btnColCenterAlign_Click);
            // 
            // btnColLeftAlign
            // 
            this.btnColLeftAlign.FontBold = true;
            this.btnColLeftAlign.ImagePaddingHorizontal = 8;
            this.btnColLeftAlign.Name = "btnColLeftAlign";
            this.btnColLeftAlign.Text = "چپ چین كردن محتویات";
            this.btnColLeftAlign.Click += new System.EventHandler(this.btnColLeftAlign_Click);
            // 
            // btnColRemove
            // 
            this.btnColRemove.BeginGroup = true;
            this.btnColRemove.FontBold = true;
            this.btnColRemove.ForeColor = System.Drawing.Color.Red;
            this.btnColRemove.ImagePaddingHorizontal = 8;
            this.btnColRemove.Name = "btnColRemove";
            this.btnColRemove.Text = "حذف ستون";
            this.btnColRemove.Click += new System.EventHandler(this.btnColRemove_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Negar.Properties.Resources.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(12, 11);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 57);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "خروج\r\n(Esc)";
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExportToExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportToExcel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExportToExcel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnExportToExcel.ForeColor = System.Drawing.Color.Green;
            this.btnExportToExcel.Image = global::Negar.Properties.Resources.ExportToExcel;
            this.btnExportToExcel.Location = new System.Drawing.Point(475, 11);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(95, 57);
            this.btnExportToExcel.TabIndex = 2;
            this.btnExportToExcel.TabStop = false;
            this.btnExportToExcel.Text = "انتقال به اكسل";
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnPrintSettings
            // 
            this.btnPrintSettings.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPrintSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintSettings.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnPrintSettings.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnPrintSettings.ForeColor = System.Drawing.Color.Black;
            this.btnPrintSettings.Image = global::Negar.Properties.Resources.PrintSettings;
            this.btnPrintSettings.Location = new System.Drawing.Point(677, 11);
            this.btnPrintSettings.Name = "btnPrintSettings";
            this.btnPrintSettings.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F4);
            this.btnPrintSettings.Size = new System.Drawing.Size(95, 57);
            this.btnPrintSettings.TabIndex = 4;
            this.btnPrintSettings.TabStop = false;
            this.btnPrintSettings.Text = "تنظیمات چاپ (F4)";
            this.btnPrintSettings.Click += new System.EventHandler(this.btnPrintSettings_Click);
            // 
            // btnView
            // 
            this.btnView.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnView.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnView.ForeColor = System.Drawing.Color.Blue;
            this.btnView.Image = global::Negar.Properties.Resources.PrintPreview;
            this.btnView.Location = new System.Drawing.Point(576, 11);
            this.btnView.Name = "btnView";
            this.btnView.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnView.Size = new System.Drawing.Size(95, 57);
            this.btnView.TabIndex = 3;
            this.btnView.TabStop = false;
            this.btnView.Text = "پیش نمایش\r\n(F8)";
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnEditRowFonts
            // 
            this.btnEditRowFonts.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEditRowFonts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditRowFonts.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnEditRowFonts.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnEditRowFonts.Location = new System.Drawing.Point(598, 87);
            this.btnEditRowFonts.Name = "btnEditRowFonts";
            this.btnEditRowFonts.Size = new System.Drawing.Size(115, 29);
            this.btnEditRowFonts.TabIndex = 6;
            this.btnEditRowFonts.TabStop = false;
            this.btnEditRowFonts.Text = "تنظیم قلم ردیف ها";
            this.btnEditRowFonts.Click += new System.EventHandler(this.btnEditRowFonts_Click);
            // 
            // TabControlForm
            // 
            this.TabControlForm.BackColor = System.Drawing.Color.Transparent;
            this.TabControlForm.CanReorderTabs = false;
            this.TabControlForm.ColorScheme.TabBackground2 = System.Drawing.Color.White;
            this.TabControlForm.ColorScheme.TabItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TabControlForm.ColorScheme.TabItemBorderDark = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.TabControlForm.ColorScheme.TabItemSelectedBackground = System.Drawing.Color.GreenYellow;
            this.TabControlForm.ColorScheme.TabItemSelectedBackground2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.TabControlForm.ColorScheme.TabPanelBorder = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.TabControlForm.Controls.Add(this.TCPResults);
            this.TabControlForm.Controls.Add(this.TCPSettings);
            this.TabControlForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControlForm.Location = new System.Drawing.Point(0, 0);
            this.TabControlForm.Name = "TabControlForm";
            this.TabControlForm.SelectedTabFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabControlForm.SelectedTabIndex = 0;
            this.TabControlForm.Size = new System.Drawing.Size(784, 482);
            this.TabControlForm.Style = DevComponents.DotNetBar.eTabStripStyle.Office2007Document;
            this.TabControlForm.TabIndex = 0;
            this.TabControlForm.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.MultilineNoNavigationBox;
            this.TabControlForm.Tabs.Add(this.TabItemResults);
            this.TabControlForm.Tabs.Add(this.TabItemSettings);
            this.TabControlForm.Text = "نتیجه اطلاعات";
            // 
            // TCPResults
            // 
            this.TCPResults.Controls.Add(this.dgvData);
            this.TCPResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TCPResults.Location = new System.Drawing.Point(0, 24);
            this.TCPResults.Name = "TCPResults";
            this.TCPResults.Padding = new System.Windows.Forms.Padding(1);
            this.TCPResults.Size = new System.Drawing.Size(784, 458);
            this.TCPResults.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.TCPResults.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(188)))), ((int)(((byte)(227)))));
            this.TCPResults.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.TCPResults.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.TCPResults.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.TCPResults.Style.GradientAngle = 90;
            this.TCPResults.TabIndex = 0;
            this.TCPResults.TabItem = this.TabItemResults;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToOrderColumns = true;
            this.dgvData.BackgroundColor = System.Drawing.Color.PowderBlue;
            this.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvData.Location = new System.Drawing.Point(1, 1);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvData.Size = new System.Drawing.Size(782, 456);
            this.dgvData.TabIndex = 0;
            this.dgvData.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvData_CellMouseClick);
            this.dgvData.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.dgvData_SortCompare);
            this.dgvData.RowHeightChanged += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvData_RowHeightChanged);
            // 
            // TabItemResults
            // 
            this.TabItemResults.AttachedControl = this.TCPResults;
            this.TabItemResults.Name = "TabItemResults";
            this.TabItemResults.Text = "نتیجه اطلاعات";
            // 
            // TCPSettings
            // 
            this.TCPSettings.Controls.Add(this.txtRowsLimitation);
            this.TCPSettings.Controls.Add(this.lblRowsLimitation);
            this.TCPSettings.Controls.Add(this.lblTitle3);
            this.TCPSettings.Controls.Add(this.lblTitle2);
            this.TCPSettings.Controls.Add(this.lblTitle1);
            this.TCPSettings.Controls.Add(this.btnEditColFonts);
            this.TCPSettings.Controls.Add(this.btnEditRowFonts);
            this.TCPSettings.Controls.Add(this.txtHeaderTitle3);
            this.TCPSettings.Controls.Add(this.txtHeaderTitle2);
            this.TCPSettings.Controls.Add(this.txtHeaderTitle1);
            this.TCPSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TCPSettings.Location = new System.Drawing.Point(0, 24);
            this.TCPSettings.Name = "TCPSettings";
            this.TCPSettings.Padding = new System.Windows.Forms.Padding(1);
            this.TCPSettings.Size = new System.Drawing.Size(784, 458);
            this.TCPSettings.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.TCPSettings.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(188)))), ((int)(((byte)(227)))));
            this.TCPSettings.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.TCPSettings.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.TCPSettings.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.TCPSettings.Style.GradientAngle = 90;
            this.TCPSettings.TabIndex = 0;
            this.TCPSettings.TabItem = this.TabItemSettings;
            // 
            // txtRowsLimitation
            // 
            this.txtRowsLimitation.AllowEmptyState = false;
            this.txtRowsLimitation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtRowsLimitation.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtRowsLimitation.ButtonClear.Enabled = false;
            this.txtRowsLimitation.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtRowsLimitation.Location = new System.Drawing.Point(228, 91);
            this.txtRowsLimitation.MaxValue = 10000;
            this.txtRowsLimitation.MinValue = 1;
            this.txtRowsLimitation.Name = "txtRowsLimitation";
            this.txtRowsLimitation.ShowUpDown = true;
            this.txtRowsLimitation.Size = new System.Drawing.Size(51, 21);
            this.txtRowsLimitation.TabIndex = 9;
            this.txtRowsLimitation.Value = 30;
            // 
            // lblRowsLimitation
            // 
            this.lblRowsLimitation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRowsLimitation.AutoSize = true;
            this.lblRowsLimitation.BackColor = System.Drawing.Color.Transparent;
            this.lblRowsLimitation.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblRowsLimitation.Location = new System.Drawing.Point(284, 93);
            this.lblRowsLimitation.Name = "lblRowsLimitation";
            this.lblRowsLimitation.Size = new System.Drawing.Size(182, 16);
            this.lblRowsLimitation.TabIndex = 8;
            this.lblRowsLimitation.Text = "حداكثر تعداد ردیف ها در هر صفحه:";
            this.lblRowsLimitation.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblTitle3
            // 
            this.lblTitle3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle3.AutoSize = true;
            this.lblTitle3.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTitle3.Location = new System.Drawing.Point(719, 62);
            this.lblTitle3.Name = "lblTitle3";
            this.lblTitle3.Size = new System.Drawing.Size(53, 16);
            this.lblTitle3.TabIndex = 5;
            this.lblTitle3.Text = "تیتر سوم:";
            this.lblTitle3.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblTitle2
            // 
            this.lblTitle2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle2.AutoSize = true;
            this.lblTitle2.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTitle2.Location = new System.Drawing.Point(719, 37);
            this.lblTitle2.Name = "lblTitle2";
            this.lblTitle2.Size = new System.Drawing.Size(47, 16);
            this.lblTitle2.TabIndex = 4;
            this.lblTitle2.Text = "تیتر دوم:";
            this.lblTitle2.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblTitle1
            // 
            this.lblTitle1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle1.AutoSize = true;
            this.lblTitle1.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTitle1.Location = new System.Drawing.Point(719, 12);
            this.lblTitle1.Name = "lblTitle1";
            this.lblTitle1.Size = new System.Drawing.Size(45, 16);
            this.lblTitle1.TabIndex = 3;
            this.lblTitle1.Text = "تیتر اول:";
            this.lblTitle1.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // btnEditColFonts
            // 
            this.btnEditColFonts.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEditColFonts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditColFonts.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnEditColFonts.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnEditColFonts.Location = new System.Drawing.Point(477, 87);
            this.btnEditColFonts.Name = "btnEditColFonts";
            this.btnEditColFonts.Size = new System.Drawing.Size(115, 29);
            this.btnEditColFonts.TabIndex = 7;
            this.btnEditColFonts.TabStop = false;
            this.btnEditColFonts.Text = "تنظیم قلم ستون ها";
            this.btnEditColFonts.Click += new System.EventHandler(this.btnEditColFonts_Click);
            // 
            // txtHeaderTitle3
            // 
            this.txtHeaderTitle3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtHeaderTitle3.Border.Class = "TextBoxBorder";
            this.txtHeaderTitle3.Location = new System.Drawing.Point(228, 60);
            this.txtHeaderTitle3.Name = "txtHeaderTitle3";
            this.txtHeaderTitle3.Size = new System.Drawing.Size(485, 21);
            this.txtHeaderTitle3.TabIndex = 2;
            // 
            // txtHeaderTitle2
            // 
            this.txtHeaderTitle2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtHeaderTitle2.Border.Class = "TextBoxBorder";
            this.txtHeaderTitle2.Location = new System.Drawing.Point(228, 35);
            this.txtHeaderTitle2.Name = "txtHeaderTitle2";
            this.txtHeaderTitle2.Size = new System.Drawing.Size(485, 21);
            this.txtHeaderTitle2.TabIndex = 1;
            // 
            // txtHeaderTitle1
            // 
            this.txtHeaderTitle1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtHeaderTitle1.Border.Class = "TextBoxBorder";
            this.txtHeaderTitle1.Location = new System.Drawing.Point(228, 10);
            this.txtHeaderTitle1.Name = "txtHeaderTitle1";
            this.txtHeaderTitle1.Size = new System.Drawing.Size(485, 21);
            this.txtHeaderTitle1.TabIndex = 0;
            this.txtHeaderTitle1.Text = "گزارش پویا سیستم";
            // 
            // TabItemSettings
            // 
            this.TabItemSettings.AttachedControl = this.TCPSettings;
            this.TabItemSettings.Name = "TabItemSettings";
            this.TabItemSettings.Text = "تنظیمات";
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            // 
            // FontDialogBox
            // 
            this.FontDialogBox.Font = new System.Drawing.Font("B Koodak", 11F, System.Drawing.FontStyle.Bold);
            this.FontDialogBox.FontMustExist = true;
            // 
            // ReportPageSetupDialog
            // 
            this.ReportPageSetupDialog.AllowPrinter = false;
            this.ReportPageSetupDialog.ShowNetwork = false;
            // 
            // BGWorker
            // 
            this.BGWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGWorker_DoWork);
            this.BGWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BGWorker_RunWorkerCompleted);
            // 
            // frmReportPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.TabControlForm);
            this.Controls.Add(this.PanelBotton);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "frmReportPreview";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "گزارش ها - تنظیم اطلاعات تولید شده";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.PanelBotton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmsForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TabControlForm)).EndInit();
            this.TabControlForm.ResumeLayout(false);
            this.TCPResults.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.TCPSettings.ResumeLayout(false);
            this.TCPSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRowsLimitation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx PanelBotton;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnView;
        private DevComponents.DotNetBar.TabControl TabControlForm;
        private DevComponents.DotNetBar.TabControlPanel TCPResults;
        private DevComponents.DotNetBar.TabItem TabItemResults;
        private DevComponents.DotNetBar.TabControlPanel TCPSettings;
        private DevComponents.DotNetBar.TabItem TabItemSettings;
        private System.Windows.Forms.DataGridView dgvData;
        private DevComponents.DotNetBar.ButtonX btnExportToExcel;
        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        private System.Windows.Forms.FontDialog FontDialogBox;
        private DevComponents.DotNetBar.ButtonX btnPrintSettings;
        private System.Windows.Forms.PageSetupDialog ReportPageSetupDialog;
        private DevComponents.DotNetBar.ButtonX btnEditRowFonts;
        private DevComponents.DotNetBar.LabelX lblTitle3;
        private DevComponents.DotNetBar.LabelX lblTitle2;
        private DevComponents.DotNetBar.LabelX lblTitle1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtHeaderTitle3;
        private DevComponents.DotNetBar.Controls.TextBoxX txtHeaderTitle2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtHeaderTitle1;
        private System.Windows.Forms.SaveFileDialog ExcelSaveFileDialog;
        private System.ComponentModel.BackgroundWorker BGWorker;
        private DevComponents.DotNetBar.ContextMenuBar cmsForm;
        private DevComponents.DotNetBar.ButtonItem cmsMenuCols;
        private DevComponents.DotNetBar.ButtonItem btnColAddRight;
        private DevComponents.DotNetBar.ButtonItem btnColAddLeft;
        private DevComponents.DotNetBar.ButtonItem btnColEdit;
        private DevComponents.DotNetBar.ButtonItem btnColRemove;
        private DevComponents.DotNetBar.ButtonItem btnColRightAlign;
        private DevComponents.DotNetBar.ButtonItem btnColCenterAlign;
        private DevComponents.DotNetBar.ButtonItem btnColLeftAlign;
        private DevComponents.DotNetBar.ButtonItem cmsMenuRows;
        private DevComponents.DotNetBar.ButtonItem btnRowAddUp;
        private DevComponents.DotNetBar.ButtonItem btnRowAddDown;
        private DevComponents.DotNetBar.ButtonItem btnRowRemove;
        private DevComponents.DotNetBar.ButtonItem btnRowMoveUp;
        private DevComponents.DotNetBar.ButtonItem btnRowMoveDown;
        private DevComponents.DotNetBar.ButtonX btnEditColFonts;
        private DevComponents.DotNetBar.Controls.ProgressBarX ProgressBar;
        private DevComponents.DotNetBar.LabelX lblRowsLimitation;
        private DevComponents.Editors.IntegerInput txtRowsLimitation;
    }
}