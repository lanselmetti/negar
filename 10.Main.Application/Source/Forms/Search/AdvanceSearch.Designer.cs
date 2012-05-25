namespace Sepehr.Forms.Search
{
    partial class frmAdvancedSearch
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdvancedSearch));
            this.PanelCostDiscount = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.TabControlForm = new DevComponents.DotNetBar.TabControl();
            this.TCPCondition = new DevComponents.DotNetBar.TabControlPanel();
            this.btnClearFilters = new DevComponents.DotNetBar.ButtonX();
            this.lblSearchIn = new DevComponents.DotNetBar.LabelX();
            this.cBoxSType1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cBoxSType2 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cBoxSType3 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cBoxSType4 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.lblFields = new DevComponents.DotNetBar.LabelX();
            this.cboFields = new System.Windows.Forms.ComboBox();
            this.lblConditions = new DevComponents.DotNetBar.LabelX();
            this.cboConditions = new System.Windows.Forms.ComboBox();
            this.lblConditionValue = new DevComponents.DotNetBar.LabelX();
            this.DateInput = new Negar.PersianCalendar.UI.Controls.PersianDatePicker();
            this.cboFixItem = new System.Windows.Forms.ComboBox();
            this.TimeInput = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.IntInput = new DevComponents.Editors.IntegerInput();
            this.txtStringInput = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblOrders = new DevComponents.DotNetBar.LabelX();
            this.btnOrder_P1 = new DevComponents.DotNetBar.ButtonX();
            this.btnOrder_P2 = new DevComponents.DotNetBar.ButtonX();
            this.btnOrder_Not = new DevComponents.DotNetBar.ButtonX();
            this.btnOrder_AndSingle = new DevComponents.DotNetBar.ButtonX();
            this.btnOrder_OrSingle = new DevComponents.DotNetBar.ButtonX();
            this.btnAddCondition = new DevComponents.DotNetBar.ButtonX();
            this.btnOrder_And = new DevComponents.DotNetBar.ButtonX();
            this.btnOrder_Or = new DevComponents.DotNetBar.ButtonX();
            this.ProgressBarForm = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.dgvConditions = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ColText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSql = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColInnerJoins = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSaveAs = new DevComponents.DotNetBar.ButtonX();
            this.btnSaveSearchStructure = new DevComponents.DotNetBar.ButtonX();
            this.btnReportColumns = new DevComponents.DotNetBar.ButtonX();
            this.btnSearch = new DevComponents.DotNetBar.ButtonX();
            this.TabCondition = new DevComponents.DotNetBar.TabItem(this.components);
            this.TCPResult = new DevComponents.DotNetBar.TabControlPanel();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.btnMoveResult = new DevComponents.DotNetBar.ButtonX();
            this.btnPrint = new DevComponents.DotNetBar.ButtonX();
            this.TabSaved = new DevComponents.DotNetBar.TabItem(this.components);
            this.TCPSaved = new DevComponents.DotNetBar.TabControlPanel();
            this.dgvSavedSearch = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ColSearchName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TabResult = new DevComponents.DotNetBar.TabItem(this.components);
            this.cmsMainForm = new DevComponents.DotNetBar.ContextMenuBar();
            this.cmsdgvData = new DevComponents.DotNetBar.ButtonItem();
            this.btnEditSearchName = new DevComponents.DotNetBar.ButtonItem();
            this.btnDeleteSearch = new DevComponents.DotNetBar.ButtonItem();
            this.btnHelp = new DevComponents.DotNetBar.ButtonX();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.BGWorker = new System.ComponentModel.BackgroundWorker();
            this.PanelCostDiscount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TabControlForm)).BeginInit();
            this.TabControlForm.SuspendLayout();
            this.TCPCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimeInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IntInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConditions)).BeginInit();
            this.TCPResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.TCPSaved.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSavedSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmsMainForm)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelCostDiscount
            // 
            this.PanelCostDiscount.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelCostDiscount.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelCostDiscount.Controls.Add(this.TabControlForm);
            this.PanelCostDiscount.Controls.Add(this.cmsMainForm);
            this.PanelCostDiscount.Controls.Add(this.btnHelp);
            this.PanelCostDiscount.Controls.Add(this.btnClose);
            this.PanelCostDiscount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelCostDiscount.Location = new System.Drawing.Point(0, 0);
            this.PanelCostDiscount.Name = "PanelCostDiscount";
            this.PanelCostDiscount.Size = new System.Drawing.Size(792, 570);
            // 
            // 
            // 
            this.PanelCostDiscount.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.PanelCostDiscount.Style.BackColorGradientAngle = 90;
            this.PanelCostDiscount.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.PanelCostDiscount.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelCostDiscount.Style.BorderBottomWidth = 1;
            this.PanelCostDiscount.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.PanelCostDiscount.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelCostDiscount.Style.BorderLeftWidth = 1;
            this.PanelCostDiscount.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelCostDiscount.Style.BorderRightWidth = 1;
            this.PanelCostDiscount.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelCostDiscount.Style.BorderTopWidth = 1;
            this.PanelCostDiscount.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.PanelCostDiscount.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.PanelCostDiscount.TabIndex = 0;
            // 
            // TabControlForm
            // 
            this.TabControlForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControlForm.BackColor = System.Drawing.Color.LightSkyBlue;
            this.TabControlForm.CanReorderTabs = false;
            this.TabControlForm.ColorScheme.TabItemSelectedBackground2 = System.Drawing.Color.PowderBlue;
            this.TabControlForm.ColorScheme.TabPanelBackground = System.Drawing.Color.PowderBlue;
            this.TabControlForm.Controls.Add(this.TCPCondition);
            this.TabControlForm.Controls.Add(this.TCPResult);
            this.TabControlForm.Controls.Add(this.TCPSaved);
            this.TabControlForm.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.TabControlForm.Location = new System.Drawing.Point(0, 0);
            this.TabControlForm.Name = "TabControlForm";
            this.TabControlForm.SelectedTabFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.TabControlForm.SelectedTabIndex = 0;
            this.TabControlForm.Size = new System.Drawing.Size(792, 492);
            this.TabControlForm.TabIndex = 0;
            this.TabControlForm.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.MultilineNoNavigationBox;
            this.TabControlForm.Tabs.Add(this.TabCondition);
            this.TabControlForm.Tabs.Add(this.TabResult);
            this.TabControlForm.Tabs.Add(this.TabSaved);
            // 
            // TCPCondition
            // 
            this.TCPCondition.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TCPCondition.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.TCPCondition.Controls.Add(this.btnClearFilters);
            this.TCPCondition.Controls.Add(this.lblSearchIn);
            this.TCPCondition.Controls.Add(this.cBoxSType1);
            this.TCPCondition.Controls.Add(this.cBoxSType2);
            this.TCPCondition.Controls.Add(this.cBoxSType3);
            this.TCPCondition.Controls.Add(this.cBoxSType4);
            this.TCPCondition.Controls.Add(this.lblFields);
            this.TCPCondition.Controls.Add(this.cboFields);
            this.TCPCondition.Controls.Add(this.lblConditions);
            this.TCPCondition.Controls.Add(this.cboConditions);
            this.TCPCondition.Controls.Add(this.lblConditionValue);
            this.TCPCondition.Controls.Add(this.DateInput);
            this.TCPCondition.Controls.Add(this.cboFixItem);
            this.TCPCondition.Controls.Add(this.TimeInput);
            this.TCPCondition.Controls.Add(this.IntInput);
            this.TCPCondition.Controls.Add(this.txtStringInput);
            this.TCPCondition.Controls.Add(this.lblOrders);
            this.TCPCondition.Controls.Add(this.btnOrder_P1);
            this.TCPCondition.Controls.Add(this.btnOrder_P2);
            this.TCPCondition.Controls.Add(this.btnOrder_Not);
            this.TCPCondition.Controls.Add(this.btnOrder_AndSingle);
            this.TCPCondition.Controls.Add(this.btnOrder_OrSingle);
            this.TCPCondition.Controls.Add(this.btnAddCondition);
            this.TCPCondition.Controls.Add(this.btnOrder_And);
            this.TCPCondition.Controls.Add(this.btnOrder_Or);
            this.TCPCondition.Controls.Add(this.ProgressBarForm);
            this.TCPCondition.Controls.Add(this.dgvConditions);
            this.TCPCondition.Controls.Add(this.btnSaveAs);
            this.TCPCondition.Controls.Add(this.btnSaveSearchStructure);
            this.TCPCondition.Controls.Add(this.btnReportColumns);
            this.TCPCondition.Controls.Add(this.btnSearch);
            this.TCPCondition.Location = new System.Drawing.Point(0, 26);
            this.TCPCondition.Name = "TCPCondition";
            this.TCPCondition.Padding = new System.Windows.Forms.Padding(1);
            this.TCPCondition.Size = new System.Drawing.Size(792, 466);
            this.TCPCondition.Style.BackColor1.Color = System.Drawing.Color.PowderBlue;
            this.TCPCondition.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.TCPCondition.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.TCPCondition.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.TCPCondition.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.TCPCondition.Style.GradientAngle = 90;
            this.TCPCondition.TabIndex = 0;
            this.TCPCondition.TabItem = this.TabCondition;
            // 
            // btnClearFilters
            // 
            this.btnClearFilters.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClearFilters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearFilters.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClearFilters.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnClearFilters.ForeColor = System.Drawing.Color.Crimson;
            this.btnClearFilters.Image = global::Sepehr.Properties.Resources.DeleteSmall;
            this.btnClearFilters.Location = new System.Drawing.Point(388, 70);
            this.btnClearFilters.Name = "btnClearFilters";
            this.btnClearFilters.Size = new System.Drawing.Size(131, 33);
            this.btnClearFilters.TabIndex = 28;
            this.btnClearFilters.TabStop = false;
            this.btnClearFilters.Text = "حذف كلیه شروط";
            this.btnClearFilters.Click += new System.EventHandler(this.btnClearFilters_Click);
            // 
            // lblSearchIn
            // 
            this.lblSearchIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSearchIn.AutoSize = true;
            this.lblSearchIn.BackColor = System.Drawing.Color.Transparent;
            this.lblSearchIn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblSearchIn.ForeColor = System.Drawing.Color.Navy;
            this.lblSearchIn.Location = new System.Drawing.Point(720, 4);
            this.lblSearchIn.Name = "lblSearchIn";
            this.lblSearchIn.Size = new System.Drawing.Size(60, 16);
            this.lblSearchIn.TabIndex = 0;
            this.lblSearchIn.Text = "جستجو در:";
            this.lblSearchIn.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // cBoxSType1
            // 
            this.cBoxSType1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxSType1.AutoSize = true;
            this.cBoxSType1.BackColor = System.Drawing.Color.Transparent;
            this.cBoxSType1.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.cBoxSType1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxSType1.Location = new System.Drawing.Point(608, 4);
            this.cBoxSType1.Name = "cBoxSType1";
            this.cBoxSType1.Size = new System.Drawing.Size(103, 16);
            this.cBoxSType1.TabIndex = 1;
            this.cBoxSType1.Text = "اطلاعات بیماران";
            this.cBoxSType1.TextColor = System.Drawing.Color.Blue;
            this.cBoxSType1.CheckedChangedEx += new DevComponents.DotNetBar.Controls.CheckBoxXChangeEventHandler(this.cBoxSearchLocation_CheckedChangedEx);
            // 
            // cBoxSType2
            // 
            this.cBoxSType2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxSType2.AutoSize = true;
            this.cBoxSType2.BackColor = System.Drawing.Color.Transparent;
            this.cBoxSType2.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.cBoxSType2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxSType2.Location = new System.Drawing.Point(494, 4);
            this.cBoxSType2.Name = "cBoxSType2";
            this.cBoxSType2.Size = new System.Drawing.Size(112, 16);
            this.cBoxSType2.TabIndex = 2;
            this.cBoxSType2.TabStop = false;
            this.cBoxSType2.Text = "اطلاعات مراجعات";
            this.cBoxSType2.TextColor = System.Drawing.Color.Blue;
            this.cBoxSType2.CheckedChangedEx += new DevComponents.DotNetBar.Controls.CheckBoxXChangeEventHandler(this.cBoxSearchLocation_CheckedChangedEx);
            // 
            // cBoxSType3
            // 
            this.cBoxSType3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxSType3.AutoSize = true;
            this.cBoxSType3.BackColor = System.Drawing.Color.Transparent;
            this.cBoxSType3.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.cBoxSType3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxSType3.Location = new System.Drawing.Point(386, 4);
            this.cBoxSType3.Name = "cBoxSType3";
            this.cBoxSType3.Size = new System.Drawing.Size(106, 16);
            this.cBoxSType3.TabIndex = 3;
            this.cBoxSType3.TabStop = false;
            this.cBoxSType3.Text = "اطلاعات  خدمات";
            this.cBoxSType3.TextColor = System.Drawing.Color.Blue;
            this.cBoxSType3.CheckedChangedEx += new DevComponents.DotNetBar.Controls.CheckBoxXChangeEventHandler(this.cBoxSearchLocation_CheckedChangedEx);
            // 
            // cBoxSType4
            // 
            this.cBoxSType4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxSType4.AutoSize = true;
            this.cBoxSType4.BackColor = System.Drawing.Color.Transparent;
            this.cBoxSType4.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.cBoxSType4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxSType4.Location = new System.Drawing.Point(286, 4);
            this.cBoxSType4.Name = "cBoxSType4";
            this.cBoxSType4.Size = new System.Drawing.Size(98, 16);
            this.cBoxSType4.TabIndex = 3;
            this.cBoxSType4.TabStop = false;
            this.cBoxSType4.Text = "اطلاعات مدارك";
            this.cBoxSType4.TextColor = System.Drawing.Color.Blue;
            this.cBoxSType4.CheckedChangedEx += new DevComponents.DotNetBar.Controls.CheckBoxXChangeEventHandler(this.cBoxSearchLocation_CheckedChangedEx);
            // 
            // lblFields
            // 
            this.lblFields.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFields.AutoSize = true;
            this.lblFields.BackColor = System.Drawing.Color.Transparent;
            this.lblFields.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblFields.ForeColor = System.Drawing.Color.Black;
            this.lblFields.Location = new System.Drawing.Point(702, 24);
            this.lblFields.Name = "lblFields";
            this.lblFields.Size = new System.Drawing.Size(78, 16);
            this.lblFields.TabIndex = 5;
            this.lblFields.Text = "فیلد اطلاعاتی:";
            this.lblFields.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // cboFields
            // 
            this.cboFields.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboFields.DisplayMember = "Value";
            this.cboFields.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFields.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cboFields.FormattingEnabled = true;
            this.cboFields.Location = new System.Drawing.Point(525, 43);
            this.cboFields.Name = "cboFields";
            this.cboFields.Size = new System.Drawing.Size(255, 21);
            this.cboFields.TabIndex = 4;
            this.cboFields.ValueMember = "Key";
            this.cboFields.SelectedIndexChanged += new System.EventHandler(this.cboFields_SelectedIndexChanged);
            // 
            // lblConditions
            // 
            this.lblConditions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblConditions.AutoSize = true;
            this.lblConditions.BackColor = System.Drawing.Color.Transparent;
            this.lblConditions.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblConditions.ForeColor = System.Drawing.Color.Black;
            this.lblConditions.Location = new System.Drawing.Point(486, 26);
            this.lblConditions.Name = "lblConditions";
            this.lblConditions.Size = new System.Drawing.Size(33, 16);
            this.lblConditions.TabIndex = 7;
            this.lblConditions.Text = "شرط:";
            this.lblConditions.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // cboConditions
            // 
            this.cboConditions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboConditions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboConditions.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cboConditions.FormattingEnabled = true;
            this.cboConditions.Location = new System.Drawing.Point(388, 43);
            this.cboConditions.Name = "cboConditions";
            this.cboConditions.Size = new System.Drawing.Size(131, 21);
            this.cboConditions.TabIndex = 6;
            // 
            // lblConditionValue
            // 
            this.lblConditionValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblConditionValue.AutoSize = true;
            this.lblConditionValue.BackColor = System.Drawing.Color.Transparent;
            this.lblConditionValue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblConditionValue.ForeColor = System.Drawing.Color.Black;
            this.lblConditionValue.Location = new System.Drawing.Point(321, 26);
            this.lblConditionValue.Name = "lblConditionValue";
            this.lblConditionValue.Size = new System.Drawing.Size(64, 16);
            this.lblConditionValue.TabIndex = 9;
            this.lblConditionValue.Text = "مقدار شرط:";
            this.lblConditionValue.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // DateInput
            // 
            this.DateInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DateInput.IsAllowNullDate = false;
            this.DateInput.IsPopupOpen = false;
            this.DateInput.Location = new System.Drawing.Point(296, 43);
            this.DateInput.Name = "DateInput";
            this.DateInput.SelectedDateTime = new System.DateTime(2010, 1, 10, 16, 10, 52, 768);
            this.DateInput.Size = new System.Drawing.Size(89, 21);
            this.DateInput.TabIndex = 8;
            this.DateInput.Visible = false;
            // 
            // cboFixItem
            // 
            this.cboFixItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboFixItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFixItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cboFixItem.FormattingEnabled = true;
            this.cboFixItem.Items.AddRange(new object[] {
            "حاوی",
            "مساوی",
            "بزرگتر",
            "بزرگتر مساوی",
            "كوچكتر مساوی",
            "كوچكتر"});
            this.cboFixItem.Location = new System.Drawing.Point(185, 43);
            this.cboFixItem.Name = "cboFixItem";
            this.cboFixItem.Size = new System.Drawing.Size(200, 21);
            this.cboFixItem.TabIndex = 10;
            this.cboFixItem.Visible = false;
            // 
            // TimeInput
            // 
            this.TimeInput.AllowEmptyState = false;
            this.TimeInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.TimeInput.BackgroundStyle.Class = "DateTimeInputBackground";
            this.TimeInput.CustomFormat = "HH:mm:ss";
            this.TimeInput.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.TimeInput.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.TimeInput.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.TimeInput.Location = new System.Drawing.Point(296, 43);
            // 
            // 
            // 
            this.TimeInput.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.TimeInput.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.TimeInput.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.TimeInput.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.TimeInput.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.TimeInput.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.TimeInput.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.TimeInput.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.TimeInput.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.TimeInput.MonthCalendar.DisplayMonth = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.TimeInput.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Saturday;
            this.TimeInput.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.TimeInput.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.TimeInput.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.TimeInput.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.TimeInput.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.TimeInput.MonthCalendar.TodayButtonVisible = true;
            this.TimeInput.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.TimeInput.Name = "TimeInput";
            this.TimeInput.ShowUpDown = true;
            this.TimeInput.Size = new System.Drawing.Size(89, 21);
            this.TimeInput.TabIndex = 9;
            this.TimeInput.Value = new System.DateTime(2010, 1, 29, 23, 41, 28, 657);
            this.TimeInput.Visible = false;
            // 
            // IntInput
            // 
            this.IntInput.AllowEmptyState = false;
            this.IntInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.IntInput.BackgroundStyle.Class = "DateTimeInputBackground";
            this.IntInput.DisplayFormat = "N0";
            this.IntInput.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.IntInput.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.IntInput.Location = new System.Drawing.Point(296, 43);
            this.IntInput.Name = "IntInput";
            this.IntInput.ShowUpDown = true;
            this.IntInput.Size = new System.Drawing.Size(89, 21);
            this.IntInput.TabIndex = 7;
            this.IntInput.Visible = false;
            // 
            // txtStringInput
            // 
            this.txtStringInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtStringInput.Border.Class = "TextBoxBorder";
            this.txtStringInput.Location = new System.Drawing.Point(185, 43);
            this.txtStringInput.MaxLength = 300;
            this.txtStringInput.Name = "txtStringInput";
            this.txtStringInput.Size = new System.Drawing.Size(200, 21);
            this.txtStringInput.TabIndex = 27;
            this.txtStringInput.Visible = false;
            // 
            // lblOrders
            // 
            this.lblOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOrders.AutoSize = true;
            this.lblOrders.BackColor = System.Drawing.Color.Transparent;
            this.lblOrders.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblOrders.ForeColor = System.Drawing.Color.Black;
            this.lblOrders.Location = new System.Drawing.Point(700, 78);
            this.lblOrders.Name = "lblOrders";
            this.lblOrders.Size = new System.Drawing.Size(80, 16);
            this.lblOrders.TabIndex = 11;
            this.lblOrders.Text = "فرمان جستجو:";
            this.lblOrders.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // btnOrder_P1
            // 
            this.btnOrder_P1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOrder_P1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOrder_P1.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnOrder_P1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnOrder_P1.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnOrder_P1.Location = new System.Drawing.Point(662, 70);
            this.btnOrder_P1.Name = "btnOrder_P1";
            this.btnOrder_P1.Size = new System.Drawing.Size(33, 33);
            this.btnOrder_P1.TabIndex = 12;
            this.btnOrder_P1.TabStop = false;
            this.btnOrder_P1.Text = "(";
            this.btnOrder_P1.Click += new System.EventHandler(this.btnOrders_Click);
            // 
            // btnOrder_P2
            // 
            this.btnOrder_P2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOrder_P2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOrder_P2.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnOrder_P2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnOrder_P2.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnOrder_P2.Location = new System.Drawing.Point(628, 70);
            this.btnOrder_P2.Name = "btnOrder_P2";
            this.btnOrder_P2.Size = new System.Drawing.Size(33, 33);
            this.btnOrder_P2.TabIndex = 13;
            this.btnOrder_P2.TabStop = false;
            this.btnOrder_P2.Text = ")";
            this.btnOrder_P2.Click += new System.EventHandler(this.btnOrders_Click);
            // 
            // btnOrder_Not
            // 
            this.btnOrder_Not.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOrder_Not.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOrder_Not.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnOrder_Not.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnOrder_Not.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnOrder_Not.Location = new System.Drawing.Point(594, 70);
            this.btnOrder_Not.Name = "btnOrder_Not";
            this.btnOrder_Not.Size = new System.Drawing.Size(33, 33);
            this.btnOrder_Not.TabIndex = 14;
            this.btnOrder_Not.TabStop = false;
            this.btnOrder_Not.Text = "غیر";
            this.btnOrder_Not.Click += new System.EventHandler(this.btnOrders_Click);
            // 
            // btnOrder_AndSingle
            // 
            this.btnOrder_AndSingle.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOrder_AndSingle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOrder_AndSingle.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnOrder_AndSingle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnOrder_AndSingle.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnOrder_AndSingle.Location = new System.Drawing.Point(560, 70);
            this.btnOrder_AndSingle.Name = "btnOrder_AndSingle";
            this.btnOrder_AndSingle.Size = new System.Drawing.Size(33, 33);
            this.btnOrder_AndSingle.TabIndex = 15;
            this.btnOrder_AndSingle.TabStop = false;
            this.btnOrder_AndSingle.Text = "و";
            this.btnOrder_AndSingle.Click += new System.EventHandler(this.btnOrders_Click);
            // 
            // btnOrder_OrSingle
            // 
            this.btnOrder_OrSingle.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOrder_OrSingle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOrder_OrSingle.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnOrder_OrSingle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnOrder_OrSingle.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnOrder_OrSingle.Location = new System.Drawing.Point(526, 70);
            this.btnOrder_OrSingle.Name = "btnOrder_OrSingle";
            this.btnOrder_OrSingle.Size = new System.Drawing.Size(33, 33);
            this.btnOrder_OrSingle.TabIndex = 16;
            this.btnOrder_OrSingle.TabStop = false;
            this.btnOrder_OrSingle.Text = "یا";
            this.btnOrder_OrSingle.Click += new System.EventHandler(this.btnOrders_Click);
            // 
            // btnAddCondition
            // 
            this.btnAddCondition.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddCondition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddCondition.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnAddCondition.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnAddCondition.Image = global::Sepehr.Properties.Resources.AddSmall;
            this.btnAddCondition.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnAddCondition.Location = new System.Drawing.Point(296, 70);
            this.btnAddCondition.Name = "btnAddCondition";
            this.btnAddCondition.Size = new System.Drawing.Size(89, 33);
            this.btnAddCondition.TabIndex = 17;
            this.btnAddCondition.TabStop = false;
            this.btnAddCondition.Text = "افزودن";
            this.btnAddCondition.Click += new System.EventHandler(this.btnAddCondition_Click);
            // 
            // btnOrder_And
            // 
            this.btnOrder_And.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOrder_And.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOrder_And.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnOrder_And.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnOrder_And.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnOrder_And.Location = new System.Drawing.Point(261, 70);
            this.btnOrder_And.Name = "btnOrder_And";
            this.btnOrder_And.Size = new System.Drawing.Size(33, 33);
            this.btnOrder_And.TabIndex = 18;
            this.btnOrder_And.TabStop = false;
            this.btnOrder_And.Text = "و";
            this.btnOrder_And.Click += new System.EventHandler(this.btnOrders_Click);
            // 
            // btnOrder_Or
            // 
            this.btnOrder_Or.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOrder_Or.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOrder_Or.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnOrder_Or.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnOrder_Or.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnOrder_Or.Location = new System.Drawing.Point(226, 70);
            this.btnOrder_Or.Name = "btnOrder_Or";
            this.btnOrder_Or.Size = new System.Drawing.Size(33, 33);
            this.btnOrder_Or.TabIndex = 19;
            this.btnOrder_Or.TabStop = false;
            this.btnOrder_Or.Text = "یا";
            this.btnOrder_Or.Click += new System.EventHandler(this.btnOrders_Click);
            // 
            // ProgressBarForm
            // 
            this.ProgressBarForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressBarForm.Location = new System.Drawing.Point(22, 75);
            this.ProgressBarForm.Name = "ProgressBarForm";
            this.ProgressBarForm.Size = new System.Drawing.Size(200, 23);
            this.ProgressBarForm.TabIndex = 20;
            this.ProgressBarForm.Text = "در انتظار جستجوی اطلاعات";
            this.ProgressBarForm.TextVisible = true;
            // 
            // dgvConditions
            // 
            this.dgvConditions.AllowDrop = true;
            this.dgvConditions.AllowUserToAddRows = false;
            this.dgvConditions.AllowUserToOrderColumns = true;
            this.dgvConditions.AllowUserToResizeRows = false;
            this.dgvConditions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvConditions.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(250)))));
            this.dgvConditions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Green;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvConditions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvConditions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConditions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColText,
            this.ColSql,
            this.ColInnerJoins});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvConditions.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvConditions.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvConditions.Location = new System.Drawing.Point(12, 108);
            this.dgvConditions.MultiSelect = false;
            this.dgvConditions.Name = "dgvConditions";
            this.dgvConditions.ReadOnly = true;
            this.dgvConditions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConditions.Size = new System.Drawing.Size(768, 301);
            this.dgvConditions.StandardTab = true;
            this.dgvConditions.TabIndex = 21;
            this.dgvConditions.TabStop = false;
            this.dgvConditions.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvConditions_CellMouseUp);
            this.dgvConditions.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConditions_CellMouseLeave);
            this.dgvConditions.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvConditions_CellMouseDown);
            this.dgvConditions.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConditions_CellMouseEnter);
            // 
            // ColText
            // 
            this.ColText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColText.DataPropertyName = "PatientID";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Blue;
            this.ColText.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColText.HeaderText = "جستجوی بیمارانی كه:";
            this.ColText.Name = "ColText";
            this.ColText.ReadOnly = true;
            // 
            // ColSql
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColSql.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColSql.HeaderText = "متن Sql";
            this.ColSql.Name = "ColSql";
            this.ColSql.ReadOnly = true;
            this.ColSql.Visible = false;
            this.ColSql.Width = 200;
            // 
            // ColInnerJoins
            // 
            this.ColInnerJoins.HeaderText = "ستون های الحاقی";
            this.ColInnerJoins.Name = "ColInnerJoins";
            this.ColInnerJoins.ReadOnly = true;
            this.ColInnerJoins.Visible = false;
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSaveAs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveAs.Image = global::Sepehr.Properties.Resources.EditLarge;
            this.btnSaveAs.Location = new System.Drawing.Point(339, 414);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(103, 39);
            this.btnSaveAs.TabIndex = 24;
            this.btnSaveAs.TabStop = false;
            this.btnSaveAs.Text = "جایگذاری با\r\n ذخیره ی ...";
            this.btnSaveAs.Visible = false;
            this.btnSaveAs.Click += new System.EventHandler(this.btnSaveSearch_Click);
            // 
            // btnSaveSearchStructure
            // 
            this.btnSaveSearchStructure.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSaveSearchStructure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveSearchStructure.Image = global::Sepehr.Properties.Resources.Apply;
            this.btnSaveSearchStructure.ImageFixedSize = new System.Drawing.Size(34, 34);
            this.btnSaveSearchStructure.Location = new System.Drawing.Point(230, 414);
            this.btnSaveSearchStructure.Name = "btnSaveSearchStructure";
            this.btnSaveSearchStructure.Size = new System.Drawing.Size(103, 39);
            this.btnSaveSearchStructure.TabIndex = 24;
            this.btnSaveSearchStructure.TabStop = false;
            this.btnSaveSearchStructure.Text = "ذخیره\r\nساختار";
            this.btnSaveSearchStructure.Click += new System.EventHandler(this.btnSaveSearch_Click);
            // 
            // btnReportColumns
            // 
            this.btnReportColumns.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnReportColumns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReportColumns.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnReportColumns.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnReportColumns.Image = global::Sepehr.Properties.Resources.AddinFields;
            this.btnReportColumns.Location = new System.Drawing.Point(121, 414);
            this.btnReportColumns.Name = "btnReportColumns";
            this.btnReportColumns.Size = new System.Drawing.Size(103, 39);
            this.btnReportColumns.TabIndex = 23;
            this.btnReportColumns.TabStop = false;
            this.btnReportColumns.Text = "ستون های گزارش";
            this.btnReportColumns.Click += new System.EventHandler(this.btnReportColumns_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearch.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSearch.ForeColor = System.Drawing.Color.Crimson;
            this.btnSearch.Image = global::Sepehr.Properties.Resources.Search;
            this.btnSearch.Location = new System.Drawing.Point(12, 414);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnSearch.Size = new System.Drawing.Size(103, 39);
            this.btnSearch.TabIndex = 22;
            this.btnSearch.TabStop = false;
            this.btnSearch.Text = "جستجو (F8)";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // TabCondition
            // 
            this.TabCondition.AttachedControl = this.TCPCondition;
            this.TabCondition.Name = "TabCondition";
            this.TabCondition.Text = "مدیریت شروط جستجو";
            // 
            // TCPResult
            // 
            this.TCPResult.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.TCPResult.Controls.Add(this.dgvData);
            this.TCPResult.Controls.Add(this.btnMoveResult);
            this.TCPResult.Controls.Add(this.btnPrint);
            this.TCPResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TCPResult.Location = new System.Drawing.Point(0, 26);
            this.TCPResult.Name = "TCPResult";
            this.TCPResult.Padding = new System.Windows.Forms.Padding(1);
            this.TCPResult.Size = new System.Drawing.Size(792, 466);
            this.TCPResult.Style.BackColor1.Color = System.Drawing.Color.PowderBlue;
            this.TCPResult.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.TCPResult.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.TCPResult.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.TCPResult.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.TCPResult.Style.GradientAngle = 90;
            this.TCPResult.TabIndex = 0;
            this.TCPResult.TabItem = this.TabSaved;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToOrderColumns = true;
            this.dgvData.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(255)))), ((int)(((byte)(210)))));
            this.dgvData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(250)))));
            this.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvData.Location = new System.Drawing.Point(12, 1);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowTemplate.Height = 30;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(768, 408);
            this.dgvData.StandardTab = true;
            this.dgvData.TabIndex = 0;
            this.dgvData.TabStop = false;
            // 
            // btnMoveResult
            // 
            this.btnMoveResult.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnMoveResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMoveResult.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnMoveResult.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnMoveResult.ForeColor = System.Drawing.Color.Crimson;
            this.btnMoveResult.Image = global::Sepehr.Properties.Resources.CashReport;
            this.btnMoveResult.Location = new System.Drawing.Point(123, 415);
            this.btnMoveResult.Name = "btnMoveResult";
            this.btnMoveResult.Size = new System.Drawing.Size(105, 41);
            this.btnMoveResult.TabIndex = 2;
            this.btnMoveResult.TabStop = false;
            this.btnMoveResult.Text = "انتقال به فرم بیماران";
            this.btnMoveResult.Click += new System.EventHandler(this.btnMoveResult_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrint.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnPrint.Image = global::Sepehr.Properties.Resources.PrintGrid;
            this.btnPrint.Location = new System.Drawing.Point(12, 415);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(105, 41);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.TabStop = false;
            this.btnPrint.Text = "چاپ\r\nجدول";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // TabSaved
            // 
            this.TabSaved.AttachedControl = this.TCPSaved;
            this.TabSaved.Name = "TabSaved";
            this.TabSaved.Text = "جستجوهای ذخیره شده";
            // 
            // TCPSaved
            // 
            this.TCPSaved.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.TCPSaved.Controls.Add(this.dgvSavedSearch);
            this.TCPSaved.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TCPSaved.Location = new System.Drawing.Point(0, 26);
            this.TCPSaved.Name = "TCPSaved";
            this.TCPSaved.Padding = new System.Windows.Forms.Padding(1);
            this.TCPSaved.Size = new System.Drawing.Size(792, 466);
            this.TCPSaved.Style.BackColor1.Color = System.Drawing.Color.PowderBlue;
            this.TCPSaved.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.TCPSaved.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.TCPSaved.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.TCPSaved.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.TCPSaved.Style.GradientAngle = 90;
            this.TCPSaved.TabIndex = 1;
            this.TCPSaved.TabItem = this.TabSaved;
            // 
            // dgvSavedSearch
            // 
            this.dgvSavedSearch.AllowUserToAddRows = false;
            this.dgvSavedSearch.AllowUserToDeleteRows = false;
            this.dgvSavedSearch.AllowUserToResizeRows = false;
            this.dgvSavedSearch.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(250)))));
            this.dgvSavedSearch.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Green;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSavedSearch.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvSavedSearch.ColumnHeadersHeight = 30;
            this.dgvSavedSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSavedSearch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColSearchName});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSavedSearch.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvSavedSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSavedSearch.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvSavedSearch.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvSavedSearch.HighlightSelectedColumnHeaders = false;
            this.dgvSavedSearch.Location = new System.Drawing.Point(1, 1);
            this.dgvSavedSearch.MultiSelect = false;
            this.dgvSavedSearch.Name = "dgvSavedSearch";
            this.dgvSavedSearch.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvSavedSearch.RowTemplate.Height = 40;
            this.dgvSavedSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSavedSearch.Size = new System.Drawing.Size(790, 464);
            this.dgvSavedSearch.StandardTab = true;
            this.dgvSavedSearch.TabIndex = 0;
            this.dgvSavedSearch.TabStop = false;
            this.dgvSavedSearch.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvSavedReports_CellMouseClick);
            this.dgvSavedSearch.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSavedReports_CellEndEdit);
            this.dgvSavedSearch.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvSavedReports_CellMouseDoubleClick);
            // 
            // ColSearchName
            // 
            this.ColSearchName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColSearchName.DataPropertyName = "Name";
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ColSearchName.DefaultCellStyle = dataGridViewCellStyle9;
            this.ColSearchName.HeaderText = "لیست جستجوهای ذخیره شده";
            this.ColSearchName.MaxInputLength = 50;
            this.ColSearchName.Name = "ColSearchName";
            // 
            // TabResult
            // 
            this.TabResult.AttachedControl = this.TCPResult;
            this.TabResult.Name = "TabResult";
            this.TabResult.Text = "نتیجه جستجو";
            // 
            // cmsMainForm
            // 
            this.cmsMainForm.DockSide = DevComponents.DotNetBar.eDockSide.Document;
            this.cmsMainForm.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmsMainForm.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.cmsdgvData});
            this.cmsMainForm.Location = new System.Drawing.Point(584, 498);
            this.cmsMainForm.Name = "cmsMainForm";
            this.cmsMainForm.Size = new System.Drawing.Size(95, 25);
            this.cmsMainForm.Stretch = true;
            this.cmsMainForm.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.cmsMainForm.TabIndex = 12;
            this.cmsMainForm.TabStop = false;
            this.cmsMainForm.Text = "منو";
            // 
            // cmsdgvData
            // 
            this.cmsdgvData.AutoExpandOnClick = true;
            this.cmsdgvData.ImagePaddingHorizontal = 8;
            this.cmsdgvData.Name = "cmsdgvData";
            this.cmsdgvData.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnEditSearchName,
            this.btnDeleteSearch});
            this.cmsdgvData.SubItemsExpandWidth = 15;
            this.cmsdgvData.Text = "منوی جدول";
            // 
            // btnEditSearchName
            // 
            this.btnEditSearchName.Image = global::Sepehr.Properties.Resources.EditSmall;
            this.btnEditSearchName.ImagePaddingHorizontal = 8;
            this.btnEditSearchName.Name = "btnEditSearchName";
            this.btnEditSearchName.Text = "<b>ویرایش نام</b>\r\n<div></div>\r\n<font color=\"#000000\">ویرایش نام جستجو.</font>";
            this.btnEditSearchName.Click += new System.EventHandler(this.btnEditSearchName_Click);
            // 
            // btnDeleteSearch
            // 
            this.btnDeleteSearch.ForeColor = System.Drawing.Color.Red;
            this.btnDeleteSearch.Image = global::Sepehr.Properties.Resources.Delete;
            this.btnDeleteSearch.ImagePaddingHorizontal = 8;
            this.btnDeleteSearch.Name = "btnDeleteSearch";
            this.btnDeleteSearch.Text = "<u><b>حذف جستجو</b></u>\r\n<div></div>\r\n<font color=\"#000000\">حذف اطلاعات جستجو.</f" +
                "ont>";
            this.btnDeleteSearch.Click += new System.EventHandler(this.btnDeleteSearch_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnHelp.Image = global::Sepehr.Properties.Resources.Help;
            this.btnHelp.Location = new System.Drawing.Point(685, 498);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F1);
            this.btnHelp.Size = new System.Drawing.Size(95, 60);
            this.btnHelp.TabIndex = 2;
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
            this.btnClose.Image = global::Sepehr.Properties.Resources.Cancel;
            this.btnClose.Location = new System.Drawing.Point(12, 498);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 60);
            this.btnClose.TabIndex = 1;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "خروج (Esc)";
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
            // frmAdvancedSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(792, 570);
            this.Controls.Add(this.PanelCostDiscount);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmAdvancedSearch";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "سیستم مدیریت تصویربرداری سپهر - جستجوی پیشرفته اطلاعات بیماران";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.PanelCostDiscount.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TabControlForm)).EndInit();
            this.TabControlForm.ResumeLayout(false);
            this.TCPCondition.ResumeLayout(false);
            this.TCPCondition.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimeInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IntInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConditions)).EndInit();
            this.TCPResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.TCPSaved.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSavedSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmsMainForm)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel PanelCostDiscount;
        private DevComponents.DotNetBar.ButtonX btnHelp;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.ButtonX btnPrint;
        private DevComponents.DotNetBar.TabControl TabControlForm;
        private DevComponents.DotNetBar.TabControlPanel TCPSaved;
        private DevComponents.DotNetBar.TabItem TabSaved;
        private DevComponents.DotNetBar.TabControlPanel TCPCondition;
        private DevComponents.DotNetBar.TabItem TabCondition;
        private DevComponents.DotNetBar.TabControlPanel TCPResult;
        private DevComponents.DotNetBar.TabItem TabResult;
        private DevComponents.DotNetBar.ButtonX btnSearch;
        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvConditions;
        private Negar.PersianCalendar.UI.Controls.PersianDatePicker DateInput;
        private DevComponents.DotNetBar.ButtonX btnAddCondition;
        private System.Windows.Forms.ComboBox cboConditions;
        private System.Windows.Forms.ComboBox cboFields;
        private DevComponents.DotNetBar.LabelX lblSearchIn;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxSType3;
        private DevComponents.DotNetBar.ButtonX btnOrder_P2;
        private DevComponents.DotNetBar.ButtonX btnOrder_P1;
        private DevComponents.DotNetBar.ButtonX btnOrder_And;
        private DevComponents.DotNetBar.ButtonX btnOrder_Or;
        private DevComponents.DotNetBar.ButtonX btnOrder_Not;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxSType2;
        private DevComponents.DotNetBar.LabelX lblConditionValue;
        private DevComponents.DotNetBar.LabelX lblConditions;
        private DevComponents.DotNetBar.LabelX lblFields;
        private DevComponents.DotNetBar.LabelX lblOrders;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxSType1;
        private DevComponents.DotNetBar.ButtonX btnSaveSearchStructure;
        private DevComponents.Editors.IntegerInput IntInput;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput TimeInput;
        private System.Windows.Forms.ComboBox cboFixItem;
        private DevComponents.DotNetBar.ButtonX btnMoveResult;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvSavedSearch;
        private DevComponents.DotNetBar.ButtonX btnReportColumns;
        private DevComponents.DotNetBar.Controls.TextBoxX txtStringInput;
        private DevComponents.DotNetBar.ButtonX btnOrder_AndSingle;
        private DevComponents.DotNetBar.ButtonX btnOrder_OrSingle;
        private System.ComponentModel.BackgroundWorker BGWorker;
        private DevComponents.DotNetBar.Controls.ProgressBarX ProgressBarForm;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColText;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSql;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColInnerJoins;
        private DevComponents.DotNetBar.ContextMenuBar cmsMainForm;
        private DevComponents.DotNetBar.ButtonItem cmsdgvData;
        private DevComponents.DotNetBar.ButtonItem btnDeleteSearch;
        private DevComponents.DotNetBar.ButtonItem btnEditSearchName;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxSType4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSearchName;
        public System.Windows.Forms.DataGridView dgvData;
        private DevComponents.DotNetBar.ButtonX btnClearFilters;
        private DevComponents.DotNetBar.ButtonX btnSaveAs;
    }
}