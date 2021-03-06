﻿namespace Sepehr.Forms.Documents
{
    partial class frmDocumentMonitor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDocumentMonitor));
            this.txtBeginTime = new DevComponents.Editors.IntegerInput();
            this.ribbonBarOrders = new DevComponents.DotNetBar.RibbonBar();
            this.btnClose = new DevComponents.DotNetBar.ButtonItem();
            this.btnRefresh = new DevComponents.DotNetBar.ButtonItem();
            this.iContainerSettings = new DevComponents.DotNetBar.ItemContainer();
            this.cBoxShowNoServiceRefs = new DevComponents.DotNetBar.CheckBoxItem();
            this.iContainerRefPhysician = new DevComponents.DotNetBar.ItemContainer();
            this.lblRefPhysician = new DevComponents.DotNetBar.LabelItem();
            this.cboRefPhysician = new DevComponents.DotNetBar.ComboBoxItem();
            this.iContainerTypist = new DevComponents.DotNetBar.ItemContainer();
            this.lblServiceCat = new DevComponents.DotNetBar.LabelItem();
            this.cboServiceCat = new DevComponents.DotNetBar.ComboBoxItem();
            this.btnHelp = new DevComponents.DotNetBar.ButtonItem();
            this.dgvData = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ColRowNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRefDate = new Negar.PersianCalendar.UI.Controls.DataGridViewPersianDateTimePickerColumn();
            this.PanelDocPatients = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblTime1 = new DevComponents.DotNetBar.LabelX();
            this.lblTime3 = new DevComponents.DotNetBar.LabelX();
            this.lblTime2 = new DevComponents.DotNetBar.LabelX();
            this.txtEndTime = new DevComponents.Editors.IntegerInput();
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.BGWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.txtBeginTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.PanelDocPatients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEndTime)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBeginTime
            // 
            this.txtBeginTime.AllowEmptyState = false;
            this.txtBeginTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtBeginTime.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtBeginTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtBeginTime.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtBeginTime.Location = new System.Drawing.Point(512, 7);
            this.txtBeginTime.MaxValue = 100;
            this.txtBeginTime.MinValue = 1;
            this.txtBeginTime.Name = "txtBeginTime";
            this.txtBeginTime.ShowUpDown = true;
            this.txtBeginTime.Size = new System.Drawing.Size(54, 21);
            this.txtBeginTime.TabIndex = 0;
            this.txtBeginTime.Value = 1;
            this.txtBeginTime.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TextBoxes_PreviewKeyDown);
            // 
            // ribbonBarOrders
            // 
            this.ribbonBarOrders.AutoOverflowEnabled = true;
            this.ribbonBarOrders.Dock = System.Windows.Forms.DockStyle.Top;
            this.ribbonBarOrders.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnClose,
            this.btnRefresh,
            this.iContainerSettings,
            this.btnHelp});
            this.ribbonBarOrders.ItemSpacing = 2;
            this.ribbonBarOrders.Location = new System.Drawing.Point(0, 0);
            this.ribbonBarOrders.Name = "ribbonBarOrders";
            this.ribbonBarOrders.ShowShortcutKeysInToolTips = true;
            this.ribbonBarOrders.Size = new System.Drawing.Size(784, 75);
            this.ribbonBarOrders.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.ribbonBarOrders.TabIndex = 1;
            this.ribbonBarOrders.TabStop = false;
            this.ribbonBarOrders.Text = "نوار دسترسی";
            this.ribbonBarOrders.TitleVisible = false;
            this.ribbonBarOrders.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle;
            // 
            // btnClose
            // 
            this.btnClose.BeginGroup = true;
            this.btnClose.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnClose.ForeColor = System.Drawing.Color.DarkViolet;
            this.btnClose.Image = global::Sepehr.Forms.Documents.Properties.Resources.Cancel;
            this.btnClose.ImageFixedSize = new System.Drawing.Size(30, 30);
            this.btnClose.ImagePaddingHorizontal = 8;
            this.btnClose.ImagePaddingVertical = 10;
            this.btnClose.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnClose.Name = "btnClose";
            this.btnClose.RibbonWordWrap = false;
            this.btnClose.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.AltF4);
            this.btnClose.SubItemsExpandWidth = 20;
            this.btnClose.Text = "خروج\r\n(Esc)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BeginGroup = true;
            this.btnRefresh.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnRefresh.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnRefresh.FontBold = true;
            this.btnRefresh.Image = global::Sepehr.Forms.Documents.Properties.Resources.Refresh;
            this.btnRefresh.ImagePaddingHorizontal = 8;
            this.btnRefresh.ImagePaddingVertical = 10;
            this.btnRefresh.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F5);
            this.btnRefresh.SubItemsExpandWidth = 14;
            this.btnRefresh.Text = "بازخوانی (F5)";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // iContainerSettings
            // 
            this.iContainerSettings.BeginGroup = true;
            this.iContainerSettings.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.iContainerSettings.Name = "iContainerSettings";
            this.iContainerSettings.ResizeItemsToFit = false;
            this.iContainerSettings.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.cBoxShowNoServiceRefs,
            this.iContainerRefPhysician,
            this.iContainerTypist});
            this.iContainerSettings.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle;
            // 
            // cBoxShowNoServiceRefs
            // 
            this.cBoxShowNoServiceRefs.Name = "cBoxShowNoServiceRefs";
            this.cBoxShowNoServiceRefs.Text = "نمایش بیماران دارای مراجعات <b><i><font color=\"#C0504D\">فاقد  خدمت</font></i></b>" +
                ".";
            this.cBoxShowNoServiceRefs.CheckedChanged += new DevComponents.DotNetBar.CheckBoxChangeEventHandler(this.cBoxes_CheckedChanged);
            // 
            // iContainerRefPhysician
            // 
            this.iContainerRefPhysician.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center;
            this.iContainerRefPhysician.Name = "iContainerRefPhysician";
            this.iContainerRefPhysician.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.lblRefPhysician,
            this.cboRefPhysician});
            this.iContainerRefPhysician.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle;
            // 
            // lblRefPhysician
            // 
            this.lblRefPhysician.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblRefPhysician.ForeColor = System.Drawing.Color.Green;
            this.lblRefPhysician.Name = "lblRefPhysician";
            this.lblRefPhysician.PaddingLeft = 4;
            this.lblRefPhysician.PaddingRight = 4;
            this.lblRefPhysician.Text = "پزشك خدمات:";
            this.lblRefPhysician.TextAlignment = System.Drawing.StringAlignment.Far;
            this.lblRefPhysician.Width = 110;
            // 
            // cboRefPhysician
            // 
            this.cboRefPhysician.ComboWidth = 160;
            this.cboRefPhysician.DropDownHeight = 106;
            this.cboRefPhysician.Name = "cboRefPhysician";
            // 
            // iContainerTypist
            // 
            this.iContainerTypist.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center;
            this.iContainerTypist.Name = "iContainerTypist";
            this.iContainerTypist.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.lblServiceCat,
            this.cboServiceCat});
            this.iContainerTypist.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle;
            // 
            // lblServiceCat
            // 
            this.lblServiceCat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblServiceCat.ForeColor = System.Drawing.Color.Green;
            this.lblServiceCat.Name = "lblServiceCat";
            this.lblServiceCat.PaddingLeft = 4;
            this.lblServiceCat.PaddingRight = 4;
            this.lblServiceCat.Text = "طبقه بندی خدمات:";
            this.lblServiceCat.TextAlignment = System.Drawing.StringAlignment.Far;
            this.lblServiceCat.Width = 110;
            // 
            // cboServiceCat
            // 
            this.cboServiceCat.ComboWidth = 160;
            this.cboServiceCat.DropDownHeight = 106;
            this.cboServiceCat.Name = "cboServiceCat";
            // 
            // btnHelp
            // 
            this.btnHelp.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnHelp.Image = global::Sepehr.Forms.Documents.Properties.Resources.HelpMed;
            this.btnHelp.ImagePaddingHorizontal = 8;
            this.btnHelp.ImagePaddingVertical = 10;
            this.btnHelp.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.RibbonWordWrap = false;
            this.btnHelp.SubItemsExpandWidth = 20;
            this.btnHelp.Text = "راهنمای\r\nفرمان ها";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
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
            this.ColRowNum,
            this.Column1,
            this.Column2,
            this.ColRefDate});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvData.Location = new System.Drawing.Point(12, 35);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowTemplate.Height = 35;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(760, 442);
            this.dgvData.StandardTab = true;
            this.dgvData.TabIndex = 5;
            this.dgvData.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dgvData_PreviewKeyDown);
            this.dgvData.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPatients_CellMouseDoubleClick);
            this.dgvData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvData_KeyDown);
            // 
            // ColRowNum
            // 
            this.ColRowNum.DataPropertyName = "RowNumber";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ColRowNum.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColRowNum.HeaderText = "ردیف";
            this.ColRowNum.Name = "ColRowNum";
            this.ColRowNum.ReadOnly = true;
            this.ColRowNum.Width = 50;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "PatientID";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Column1.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column1.HeaderText = "كد بیمار";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 120;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.DataPropertyName = "FullName";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("B Koodak", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Column2.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column2.HeaderText = "نام بیمار";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // ColRefDate
            // 
            this.ColRefDate.DataPropertyName = "RefDate";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ColRefDate.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColRefDate.HeaderText = "زمان مراجعه";
            this.ColRefDate.Name = "ColRefDate";
            this.ColRefDate.ReadOnly = true;
            this.ColRefDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColRefDate.ShowTime = true;
            this.ColRefDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColRefDate.Width = 180;
            // 
            // PanelDocPatients
            // 
            this.PanelDocPatients.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelDocPatients.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelDocPatients.Controls.Add(this.btnExit);
            this.PanelDocPatients.Controls.Add(this.lblTime1);
            this.PanelDocPatients.Controls.Add(this.lblTime3);
            this.PanelDocPatients.Controls.Add(this.lblTime2);
            this.PanelDocPatients.Controls.Add(this.dgvData);
            this.PanelDocPatients.Controls.Add(this.txtEndTime);
            this.PanelDocPatients.Controls.Add(this.txtBeginTime);
            this.PanelDocPatients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelDocPatients.Location = new System.Drawing.Point(0, 75);
            this.PanelDocPatients.Name = "PanelDocPatients";
            this.PanelDocPatients.Size = new System.Drawing.Size(784, 489);
            // 
            // 
            // 
            this.PanelDocPatients.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.PanelDocPatients.Style.BackColorGradientAngle = 90;
            this.PanelDocPatients.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.PanelDocPatients.Style.BorderBottomWidth = 1;
            this.PanelDocPatients.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.PanelDocPatients.Style.BorderLeftWidth = 1;
            this.PanelDocPatients.Style.BorderRightWidth = 1;
            this.PanelDocPatients.Style.BorderTopWidth = 1;
            this.PanelDocPatients.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.PanelDocPatients.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.PanelDocPatients.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(0, -30);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 6;
            this.btnExit.TabStop = false;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTime1
            // 
            this.lblTime1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTime1.BackColor = System.Drawing.Color.Transparent;
            this.lblTime1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTime1.Location = new System.Drawing.Point(574, 6);
            this.lblTime1.Name = "lblTime1";
            this.lblTime1.Size = new System.Drawing.Size(203, 23);
            this.lblTime1.TabIndex = 2;
            this.lblTime1.Text = "نمایش مراجعات بیماران پذیرش شده از";
            this.lblTime1.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblTime3
            // 
            this.lblTime3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTime3.BackColor = System.Drawing.Color.Transparent;
            this.lblTime3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTime3.Location = new System.Drawing.Point(275, 6);
            this.lblTime3.Name = "lblTime3";
            this.lblTime3.Size = new System.Drawing.Size(79, 23);
            this.lblTime3.TabIndex = 4;
            this.lblTime3.Text = "ساعت گذشته.";
            // 
            // lblTime2
            // 
            this.lblTime2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTime2.BackColor = System.Drawing.Color.Transparent;
            this.lblTime2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTime2.Location = new System.Drawing.Point(420, 6);
            this.lblTime2.Name = "lblTime2";
            this.lblTime2.Size = new System.Drawing.Size(86, 23);
            this.lblTime2.TabIndex = 3;
            this.lblTime2.Text = "ساعت گذشته تا";
            // 
            // txtEndTime
            // 
            this.txtEndTime.AllowEmptyState = false;
            this.txtEndTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtEndTime.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtEndTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtEndTime.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtEndTime.Location = new System.Drawing.Point(360, 7);
            this.txtEndTime.MaxValue = 100;
            this.txtEndTime.MinValue = 0;
            this.txtEndTime.Name = "txtEndTime";
            this.txtEndTime.ShowUpDown = true;
            this.txtEndTime.Size = new System.Drawing.Size(54, 21);
            this.txtEndTime.TabIndex = 1;
            this.txtEndTime.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TextBoxes_PreviewKeyDown);
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
            // frmDocumentMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(784, 564);
            this.Controls.Add(this.PanelDocPatients);
            this.Controls.Add(this.ribbonBarOrders);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "frmDocumentMonitor";
            this.Opacity = 0.01;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "بیماران - مراجعات تصویربرداری - مدارك - فرم مانیتور بیماران جوابدهی";
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.txtBeginTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.PanelDocPatients.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtEndTime)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private DevComponents.Editors.IntegerInput txtBeginTime;
        private DevComponents.DotNetBar.RibbonBar ribbonBarOrders;
        private DevComponents.DotNetBar.ButtonItem btnRefresh;
        private DevComponents.DotNetBar.CheckBoxItem cBoxShowNoServiceRefs;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvData;
        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel PanelDocPatients;
        private DevComponents.DotNetBar.LabelX lblTime2;
        private DevComponents.DotNetBar.LabelX lblTime1;
        private DevComponents.DotNetBar.LabelX lblTime3;
        private DevComponents.Editors.IntegerInput txtEndTime;
        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        private DevComponents.DotNetBar.ButtonItem btnClose;
        private DevComponents.DotNetBar.ButtonItem btnHelp;
        private System.Windows.Forms.Button btnExit;
        private DevComponents.DotNetBar.ItemContainer iContainerSettings;
        private DevComponents.DotNetBar.ItemContainer iContainerRefPhysician;
        private DevComponents.DotNetBar.LabelItem lblRefPhysician;
        private DevComponents.DotNetBar.ComboBoxItem cboRefPhysician;
        private DevComponents.DotNetBar.ItemContainer iContainerTypist;
        private DevComponents.DotNetBar.LabelItem lblServiceCat;
        private DevComponents.DotNetBar.ComboBoxItem cboServiceCat;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRowNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private Negar.PersianCalendar.UI.Controls.DataGridViewPersianDateTimePickerColumn ColRefDate;
        private System.ComponentModel.BackgroundWorker BGWorker;
    }
}