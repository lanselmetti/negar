namespace Sepehr.Forms.Cash
{
    partial class frmCashPatients
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCashPatients));
            this.txtBeginTime = new DevComponents.Editors.IntegerInput();
            this.ribbonBarOrders = new DevComponents.DotNetBar.RibbonBar();
            this.btnClose = new DevComponents.DotNetBar.ButtonItem();
            this.btnRecieveMoney = new DevComponents.DotNetBar.ButtonItem();
            this.btnAccount = new DevComponents.DotNetBar.ButtonItem();
            this.btnCashReport = new DevComponents.DotNetBar.ButtonItem();
            this.btnRefresh = new DevComponents.DotNetBar.ButtonItem();
            this.iContainerOptions = new DevComponents.DotNetBar.ItemContainer();
            this.iContainerSearchOptions = new DevComponents.DotNetBar.ItemContainer();
            this.cBoxHidePayedRefs = new DevComponents.DotNetBar.CheckBoxItem();
            this.cBoxShowNoServiceRefs = new DevComponents.DotNetBar.CheckBoxItem();
            this.iContainerCashierName = new DevComponents.DotNetBar.ItemContainer();
            this.lblCashierTitle = new DevComponents.DotNetBar.LabelItem();
            this.lblCashier = new DevComponents.DotNetBar.LabelItem();
            this.btnHelp = new DevComponents.DotNetBar.ButtonItem();
            this.dgvData = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRefDate = new Negar.PersianCalendar.UI.Controls.DataGridViewPersianDateTimePickerColumn();
            this.ColIns1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColIns2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PanelCashPatients = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.lblTime1 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.lblTime2 = new DevComponents.DotNetBar.LabelX();
            this.txtEndTime = new DevComponents.Editors.IntegerInput();
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.btnExit = new System.Windows.Forms.Button();
            this.TimerRefresh = new System.Windows.Forms.Timer(this.components);
            this.BGWorker = new System.ComponentModel.BackgroundWorker();
            this.cBoxShowExcludedRefs = new DevComponents.DotNetBar.CheckBoxItem();
            this.btnHide = new DevComponents.DotNetBar.ButtonItem();
            this.btnShow = new DevComponents.DotNetBar.ButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.txtBeginTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.PanelCashPatients.SuspendLayout();
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
            this.txtBeginTime.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtBeginTime.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtBeginTime.Location = new System.Drawing.Point(734, 6);
            this.txtBeginTime.MaxValue = 99;
            this.txtBeginTime.MinValue = 1;
            this.txtBeginTime.Name = "txtBeginTime";
            this.txtBeginTime.ShowUpDown = true;
            this.txtBeginTime.Size = new System.Drawing.Size(54, 22);
            this.txtBeginTime.TabIndex = 0;
            this.txtBeginTime.Value = 10;
            this.txtBeginTime.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TextBoxes_PreviewKeyDown);
            // 
            // ribbonBarOrders
            // 
            this.ribbonBarOrders.AutoOverflowEnabled = true;
            this.ribbonBarOrders.Dock = System.Windows.Forms.DockStyle.Top;
            this.ribbonBarOrders.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnClose,
            this.btnRecieveMoney,
            this.btnHide,
            this.btnShow,
            this.btnAccount,
            this.btnCashReport,
            this.btnRefresh,
            this.iContainerOptions,
            this.btnHelp});
            this.ribbonBarOrders.ItemSpacing = 2;
            this.ribbonBarOrders.Location = new System.Drawing.Point(0, 0);
            this.ribbonBarOrders.Name = "ribbonBarOrders";
            this.ribbonBarOrders.ShowShortcutKeysInToolTips = true;
            this.ribbonBarOrders.Size = new System.Drawing.Size(1008, 86);
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
            this.btnClose.Image = global::Sepehr.Forms.Cash.Properties.Resources.Cancel;
            this.btnClose.ImageFixedSize = new System.Drawing.Size(40, 40);
            this.btnClose.ImagePaddingHorizontal = 8;
            this.btnClose.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnClose.Name = "btnClose";
            this.btnClose.RibbonWordWrap = false;
            this.btnClose.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.AltF4);
            this.btnClose.Text = "خروج\r\n(Esc)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRecieveMoney
            // 
            this.btnRecieveMoney.BeginGroup = true;
            this.btnRecieveMoney.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnRecieveMoney.FontBold = true;
            this.btnRecieveMoney.Image = global::Sepehr.Forms.Cash.Properties.Resources.Cash;
            this.btnRecieveMoney.ImageFixedSize = new System.Drawing.Size(40, 40);
            this.btnRecieveMoney.ImagePaddingHorizontal = 8;
            this.btnRecieveMoney.ImagePaddingVertical = 8;
            this.btnRecieveMoney.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnRecieveMoney.Name = "btnRecieveMoney";
            this.btnRecieveMoney.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnRecieveMoney.Text = "دریافت از\r\nبیمار (F8)";
            this.btnRecieveMoney.Click += new System.EventHandler(this.btnRecieveMoney_Click);
            // 
            // btnAccount
            // 
            this.btnAccount.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnAccount.FontBold = true;
            this.btnAccount.ForeColor = System.Drawing.Color.Green;
            this.btnAccount.Image = global::Sepehr.Forms.Cash.Properties.Resources.RefAccount;
            this.btnAccount.ImagePaddingHorizontal = 8;
            this.btnAccount.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F4);
            this.btnAccount.Text = "حساب (F4)";
            this.btnAccount.Click += new System.EventHandler(this.btnAccount_Click);
            // 
            // btnCashReport
            // 
            this.btnCashReport.BeginGroup = true;
            this.btnCashReport.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnCashReport.Image = global::Sepehr.Forms.Cash.Properties.Resources.CashReport;
            this.btnCashReport.ImagePaddingHorizontal = 8;
            this.btnCashReport.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnCashReport.Name = "btnCashReport";
            this.btnCashReport.Text = "گزارش صندوق ها";
            this.btnCashReport.Click += new System.EventHandler(this.btnCash_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BeginGroup = true;
            this.btnRefresh.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnRefresh.Image = global::Sepehr.Forms.Cash.Properties.Resources.Refresh;
            this.btnRefresh.ImagePaddingHorizontal = 15;
            this.btnRefresh.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F5);
            this.btnRefresh.Text = "بازخوانی (F5)";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // iContainerOptions
            // 
            this.iContainerOptions.ItemSpacing = 2;
            this.iContainerOptions.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.iContainerOptions.Name = "iContainerOptions";
            this.iContainerOptions.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.iContainerSearchOptions,
            this.iContainerCashierName});
            this.iContainerOptions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle;
            // 
            // iContainerSearchOptions
            // 
            this.iContainerSearchOptions.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.iContainerSearchOptions.Name = "iContainerSearchOptions";
            this.iContainerSearchOptions.ResizeItemsToFit = false;
            this.iContainerSearchOptions.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.cBoxHidePayedRefs,
            this.cBoxShowNoServiceRefs,
            this.cBoxShowExcludedRefs});
            this.iContainerSearchOptions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle;
            // 
            // cBoxHidePayedRefs
            // 
            this.cBoxHidePayedRefs.Name = "cBoxHidePayedRefs";
            this.cBoxHidePayedRefs.Stretch = true;
            this.cBoxHidePayedRefs.Text = "نمایش مراجعات <b><i><font color=\"#C0504D\">دارای یك بار پرداخت</font></i></b>.";
            this.cBoxHidePayedRefs.CheckedChanged += new DevComponents.DotNetBar.CheckBoxChangeEventHandler(this.cBoxes_CheckedChanged);
            // 
            // cBoxShowNoServiceRefs
            // 
            this.cBoxShowNoServiceRefs.Name = "cBoxShowNoServiceRefs";
            this.cBoxShowNoServiceRefs.Text = "نمایش مراجعات <b><i><font color=\"#C0504D\">فاقد  خدمت ثبت شده</font></i></b>.";
            this.cBoxShowNoServiceRefs.CheckedChanged += new DevComponents.DotNetBar.CheckBoxChangeEventHandler(this.cBoxes_CheckedChanged);
            // 
            // iContainerCashierName
            // 
            this.iContainerCashierName.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center;
            this.iContainerCashierName.Name = "iContainerCashierName";
            this.iContainerCashierName.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.lblCashierTitle,
            this.lblCashier});
            this.iContainerCashierName.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle;
            // 
            // lblCashierTitle
            // 
            this.lblCashierTitle.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblCashierTitle.Name = "lblCashierTitle";
            this.lblCashierTitle.Text = "صندوقدار:";
            // 
            // lblCashier
            // 
            this.lblCashier.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblCashier.Name = "lblCashier";
            this.lblCashier.ShowSubItems = false;
            this.lblCashier.Text = "نام كاربر";
            // 
            // btnHelp
            // 
            this.btnHelp.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnHelp.Image = global::Sepehr.Forms.Cash.Properties.Resources.HelpMed;
            this.btnHelp.ImagePaddingHorizontal = 8;
            this.btnHelp.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.RibbonWordWrap = false;
            this.btnHelp.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F1);
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
            this.dgvData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
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
            this.Column1,
            this.Column2,
            this.ColRefDate,
            this.ColIns1,
            this.ColIns2,
            this.ColValue});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvData.Location = new System.Drawing.Point(12, 35);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(984, 597);
            this.dgvData.StandardTab = true;
            this.dgvData.TabIndex = 5;
            this.dgvData.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dgvData_PreviewKeyDown);
            this.dgvData.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvData_CellFormatting);
            this.dgvData.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPatients_CellMouseDoubleClick);
            this.dgvData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvData_KeyDown);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "PatientID";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.HeaderText = "كد بیمار";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 110;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.DataPropertyName = "FullName";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("B Koodak", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Column2.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column2.HeaderText = "نام بیمار";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // ColRefDate
            // 
            this.ColRefDate.DataPropertyName = "RefDate";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ColRefDate.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColRefDate.HeaderText = "زمان مراجعه";
            this.ColRefDate.Name = "ColRefDate";
            this.ColRefDate.ReadOnly = true;
            this.ColRefDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColRefDate.ShowTime = true;
            this.ColRefDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColRefDate.Width = 165;
            // 
            // ColIns1
            // 
            this.ColIns1.DataPropertyName = "Ins1IX";
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle5.NullValue = "(بدون بیمه)";
            this.ColIns1.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColIns1.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ColIns1.HeaderText = "بیمه اول";
            this.ColIns1.Name = "ColIns1";
            this.ColIns1.ReadOnly = true;
            this.ColIns1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColIns1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColIns1.Width = 180;
            // 
            // ColIns2
            // 
            this.ColIns2.DataPropertyName = "Ins2IX";
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle6.NullValue = "(بدون بیمه)";
            this.ColIns2.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColIns2.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ColIns2.HeaderText = "بیمه دوم";
            this.ColIns2.Name = "ColIns2";
            this.ColIns2.ReadOnly = true;
            this.ColIns2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColIns2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColIns2.Width = 180;
            // 
            // ColValue
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("B Koodak", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ColValue.DefaultCellStyle = dataGridViewCellStyle7;
            this.ColValue.HeaderText = "قابل دریافت";
            this.ColValue.Name = "ColValue";
            this.ColValue.ReadOnly = true;
            this.ColValue.Width = 150;
            // 
            // PanelCashPatients
            // 
            this.PanelCashPatients.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelCashPatients.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelCashPatients.Controls.Add(this.lblTime1);
            this.PanelCashPatients.Controls.Add(this.labelX1);
            this.PanelCashPatients.Controls.Add(this.lblTime2);
            this.PanelCashPatients.Controls.Add(this.dgvData);
            this.PanelCashPatients.Controls.Add(this.txtEndTime);
            this.PanelCashPatients.Controls.Add(this.txtBeginTime);
            this.PanelCashPatients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelCashPatients.Location = new System.Drawing.Point(0, 86);
            this.PanelCashPatients.Name = "PanelCashPatients";
            this.PanelCashPatients.Size = new System.Drawing.Size(1008, 644);
            // 
            // 
            // 
            this.PanelCashPatients.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.PanelCashPatients.Style.BackColorGradientAngle = 90;
            this.PanelCashPatients.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.PanelCashPatients.Style.BorderBottomWidth = 1;
            this.PanelCashPatients.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.PanelCashPatients.Style.BorderLeftWidth = 1;
            this.PanelCashPatients.Style.BorderRightWidth = 1;
            this.PanelCashPatients.Style.BorderTopWidth = 1;
            this.PanelCashPatients.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.PanelCashPatients.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.PanelCashPatients.TabIndex = 0;
            // 
            // lblTime1
            // 
            this.lblTime1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTime1.BackColor = System.Drawing.Color.Transparent;
            this.lblTime1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTime1.Location = new System.Drawing.Point(794, 6);
            this.lblTime1.Name = "lblTime1";
            this.lblTime1.Size = new System.Drawing.Size(202, 23);
            this.lblTime1.TabIndex = 4;
            this.lblTime1.Text = "نمایش مراجعات بیماران پذیرش شده از";
            this.lblTime1.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX1
            // 
            this.labelX1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            this.labelX1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.labelX1.Location = new System.Drawing.Point(507, 6);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(67, 23);
            this.labelX1.TabIndex = 3;
            this.labelX1.Text = "ساعت آینده.";
            // 
            // lblTime2
            // 
            this.lblTime2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTime2.BackColor = System.Drawing.Color.Transparent;
            this.lblTime2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTime2.Location = new System.Drawing.Point(636, 6);
            this.lblTime2.Name = "lblTime2";
            this.lblTime2.Size = new System.Drawing.Size(92, 23);
            this.lblTime2.TabIndex = 1;
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
            this.txtEndTime.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtEndTime.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtEndTime.Location = new System.Drawing.Point(580, 6);
            this.txtEndTime.MaxValue = 99;
            this.txtEndTime.MinValue = 0;
            this.txtEndTime.Name = "txtEndTime";
            this.txtEndTime.ShowUpDown = true;
            this.txtEndTime.Size = new System.Drawing.Size(54, 22);
            this.txtEndTime.TabIndex = 2;
            this.txtEndTime.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TextBoxes_PreviewKeyDown);
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(0, -50);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 2;
            this.btnExit.TabStop = false;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // TimerRefresh
            // 
            this.TimerRefresh.Interval = 1000;
            this.TimerRefresh.Tick += new System.EventHandler(this.TimerRefresh_Tick);
            // 
            // BGWorker
            // 
            this.BGWorker.WorkerSupportsCancellation = true;
            this.BGWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGWorker_DoWork);
            this.BGWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BGWorker_RunWorkerCompleted);
            // 
            // cBoxShowExcludedRefs
            // 
            this.cBoxShowExcludedRefs.Name = "cBoxShowExcludedRefs";
            this.cBoxShowExcludedRefs.Text = "نمایش مراجعات <b><i><font color=\"#C0504D\">مخفی شده</font></i></b>.";
            this.cBoxShowExcludedRefs.CheckedChanged += new DevComponents.DotNetBar.CheckBoxChangeEventHandler(this.cBoxes_CheckedChanged);
            // 
            // btnHide
            // 
            this.btnHide.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnHide.FontBold = true;
            this.btnHide.Image = global::Sepehr.Forms.Cash.Properties.Resources.Deny;
            this.btnHide.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnHide.Name = "btnHide";
            this.btnHide.Text = "پنهان كردن";
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // btnShow
            // 
            this.btnShow.BeginGroup = true;
            this.btnShow.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnShow.FontBold = true;
            this.btnShow.Image = global::Sepehr.Forms.Cash.Properties.Resources.Allow;
            this.btnShow.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnShow.Name = "btnShow";
            this.btnShow.Text = "آشكار كردن";
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // frmCashPatients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.PanelCashPatients);
            this.Controls.Add(this.ribbonBarOrders);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmCashPatients";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "صندوق - فرم مانیتور بیماران صندوق";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.txtBeginTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.PanelCashPatients.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtEndTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.Editors.IntegerInput txtBeginTime;
        private DevComponents.DotNetBar.RibbonBar ribbonBarOrders;
        private DevComponents.DotNetBar.ButtonItem btnRefresh;
        private DevComponents.DotNetBar.ButtonItem btnRecieveMoney;
        private DevComponents.DotNetBar.ButtonItem btnCashReport;
        private DevComponents.DotNetBar.CheckBoxItem cBoxHidePayedRefs;
        private DevComponents.DotNetBar.CheckBoxItem cBoxShowNoServiceRefs;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvData;
        private DevComponents.DotNetBar.ItemContainer iContainerOptions;
        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel PanelCashPatients;
        private DevComponents.DotNetBar.LabelX lblTime2;
        private DevComponents.DotNetBar.LabelX lblTime1;
        private DevComponents.DotNetBar.ButtonItem btnAccount;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.Editors.IntegerInput txtEndTime;
        private DevComponents.DotNetBar.ItemContainer iContainerCashierName;
        private DevComponents.DotNetBar.LabelItem lblCashierTitle;
        private DevComponents.DotNetBar.LabelItem lblCashier;
        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        private DevComponents.DotNetBar.ButtonItem btnClose;
        private DevComponents.DotNetBar.ButtonItem btnHelp;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Timer TimerRefresh;
        private DevComponents.DotNetBar.ItemContainer iContainerSearchOptions;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private Negar.PersianCalendar.UI.Controls.DataGridViewPersianDateTimePickerColumn ColRefDate;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColIns1;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColIns2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColValue;
        private System.ComponentModel.BackgroundWorker BGWorker;
        private DevComponents.DotNetBar.CheckBoxItem cBoxShowExcludedRefs;
        private DevComponents.DotNetBar.ButtonItem btnHide;
        private DevComponents.DotNetBar.ButtonItem btnShow;
    }
}