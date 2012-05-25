namespace Sepehr.Forms.Admission.Patients
{
    partial class frmPatients
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPatients));
            this.cmsdgvData = new DevComponents.DotNetBar.ButtonItem();
            this.btnShowAdmit = new DevComponents.DotNetBar.ButtonItem();
            this.btnShowAccount = new DevComponents.DotNetBar.ButtonItem();
            this.btnShowDocuments = new DevComponents.DotNetBar.ButtonItem();
            this.btnPrint = new DevComponents.DotNetBar.ButtonItem();
            this.iContainerPrintTemplate = new DevComponents.DotNetBar.ItemContainer();
            this.lblPrintTemplate = new DevComponents.DotNetBar.LabelItem();
            this.cboPrintTemplates = new DevComponents.DotNetBar.ComboBoxItem();
            this.sliderPrintCount = new DevComponents.DotNetBar.SliderItem();
            this.btnPrintPreview = new DevComponents.DotNetBar.ButtonItem();
            this.btnPrintTemplate = new DevComponents.DotNetBar.ButtonItem();
            this.btnRemoveRef = new DevComponents.DotNetBar.ButtonItem();
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.ExpReferrals = new DevComponents.DotNetBar.ExpandablePanel();
            this.cmsPatients = new DevComponents.DotNetBar.ContextMenuBar();
            this.dgvData = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ColRow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRefID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRefDate = new Negar.PersianCalendar.UI.Controls.DataGridViewPersianDateTimePickerColumn();
            this.ColAdmitter = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColPaymentStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRefDocsCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TabCtrlPatientData = new DevComponents.DotNetBar.TabControl();
            this.TabPanelBasicData = new DevComponents.DotNetBar.TabControlPanel();
            this.cBoxEnterPatAge = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.btnShowEnglishLastName = new DevComponents.DotNetBar.ButtonX();
            this.btnShowEnglishFirstName = new DevComponents.DotNetBar.ButtonX();
            this.txtFirstName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtAgeMonth = new DevComponents.Editors.IntegerInput();
            this.txtAgeYear = new DevComponents.Editors.IntegerInput();
            this.PanelMaritualStatus = new System.Windows.Forms.Panel();
            this.cboxSingle = new System.Windows.Forms.RadioButton();
            this.cBoxMaried = new System.Windows.Forms.RadioButton();
            this.PanelGender = new System.Windows.Forms.Panel();
            this.cBoxFemale = new System.Windows.Forms.RadioButton();
            this.cBoxMale = new System.Windows.Forms.RadioButton();
            this.lblFirstName = new DevComponents.DotNetBar.LabelX();
            this.lblLastName = new DevComponents.DotNetBar.LabelX();
            this.lblGender = new DevComponents.DotNetBar.LabelX();
            this.lblBirthDate = new DevComponents.DotNetBar.LabelX();
            this.lblMaritualStatus = new DevComponents.DotNetBar.LabelX();
            this.lblFatherName = new DevComponents.DotNetBar.LabelX();
            this.lblNationalCode = new DevComponents.DotNetBar.LabelX();
            this.lblNationalID = new DevComponents.DotNetBar.LabelX();
            this.lblBirthLocation = new DevComponents.DotNetBar.LabelX();
            this.lblOccupation = new DevComponents.DotNetBar.LabelX();
            this.txtBirthLocation = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtFatherName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cboJob = new System.Windows.Forms.ComboBox();
            this.txtLastName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtNationalCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtNationalID = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.DateInputBirthDate = new Negar.PersianCalendar.UI.Controls.PersianDatePicker();
            this.txtAgeDay = new DevComponents.Editors.IntegerInput();
            this.TabBasicData = new DevComponents.DotNetBar.TabItem(this.components);
            this.TabPanelAddInData = new DevComponents.DotNetBar.TabControlPanel();
            this.TabAddInData = new DevComponents.DotNetBar.TabItem(this.components);
            this.TabPanelContactData = new DevComponents.DotNetBar.TabControlPanel();
            this.txtTel1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cboCountry = new System.Windows.Forms.ComboBox();
            this.lblEmail = new DevComponents.DotNetBar.LabelX();
            this.lblState = new DevComponents.DotNetBar.LabelX();
            this.lblTel2 = new DevComponents.DotNetBar.LabelX();
            this.lblAddress = new DevComponents.DotNetBar.LabelX();
            this.lblCity = new DevComponents.DotNetBar.LabelX();
            this.lblCountry = new DevComponents.DotNetBar.LabelX();
            this.lblZipCode = new DevComponents.DotNetBar.LabelX();
            this.lblTel1 = new DevComponents.DotNetBar.LabelX();
            this.cboCity = new System.Windows.Forms.ComboBox();
            this.cboState = new System.Windows.Forms.ComboBox();
            this.txtZipCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtEmail = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtAddress = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtTel2 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.TabContactData = new DevComponents.DotNetBar.TabItem(this.components);
            this.RibbonBarNavigation = new DevComponents.DotNetBar.RibbonBar();
            this.btnNewPatient = new DevComponents.DotNetBar.ButtonItem();
            this.btnNewReferral = new DevComponents.DotNetBar.ButtonItem();
            this.btnPrevPatient = new DevComponents.DotNetBar.ButtonItem();
            this.iContainerPatientID = new DevComponents.DotNetBar.ItemContainer();
            this.lblPatientID = new DevComponents.DotNetBar.LabelItem();
            this.iContainerPatientIDTextBox = new DevComponents.DotNetBar.ItemContainer();
            this.txtPatientID = new DevComponents.DotNetBar.TextBoxItem();
            this.btnNextPatient = new DevComponents.DotNetBar.ButtonItem();
            this.btnEditMode = new DevComponents.DotNetBar.ButtonItem();
            this.btnFreePatient = new DevComponents.DotNetBar.ButtonItem();
            this.btnDeletePatient = new DevComponents.DotNetBar.ButtonItem();
            this.btnRefresh = new DevComponents.DotNetBar.ButtonItem();
            this.btnSchList = new DevComponents.DotNetBar.ButtonItem();
            this.btnHelp = new DevComponents.DotNetBar.ButtonItem();
            this.btnNextTab = new DevComponents.DotNetBar.ButtonX();
            this.ExpReferrals.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmsPatients)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TabCtrlPatientData)).BeginInit();
            this.TabCtrlPatientData.SuspendLayout();
            this.TabPanelBasicData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAgeMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAgeYear)).BeginInit();
            this.PanelMaritualStatus.SuspendLayout();
            this.PanelGender.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAgeDay)).BeginInit();
            this.TabPanelContactData.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsdgvData
            // 
            this.cmsdgvData.AutoExpandOnClick = true;
            this.cmsdgvData.ImagePaddingHorizontal = 8;
            this.cmsdgvData.Name = "cmsdgvData";
            this.cmsdgvData.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnShowAdmit,
            this.btnShowAccount,
            this.btnShowDocuments,
            this.btnPrint,
            this.btnRemoveRef});
            this.cmsdgvData.Text = "منوی جدول مراجعات";
            // 
            // btnShowAdmit
            // 
            this.btnShowAdmit.Image = global::Sepehr.Forms.Admission.Properties.Resources.PatRef;
            this.btnShowAdmit.ImagePaddingHorizontal = 8;
            this.btnShowAdmit.Name = "btnShowAdmit";
            this.btnShowAdmit.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F7);
            this.btnShowAdmit.Text = "<b>مشاهده پذیرش</b>\r\n<div></div>\r\n<font color=\"#000000\">اطلاعات مراجعه.</font>";
            this.btnShowAdmit.Click += new System.EventHandler(this.btnShowAdmit_Click);
            // 
            // btnShowAccount
            // 
            this.btnShowAccount.ForeColor = System.Drawing.Color.Green;
            this.btnShowAccount.Image = global::Sepehr.Forms.Admission.Properties.Resources.RefAccount;
            this.btnShowAccount.ImagePaddingHorizontal = 8;
            this.btnShowAccount.Name = "btnShowAccount";
            this.btnShowAccount.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnShowAccount.Text = "<b>مشاهده حساب</b>\r\n<div></div>\r\n<font color=\"#000000\">اطلاعات مالی مراجعه.</font" +
                ">";
            this.btnShowAccount.Click += new System.EventHandler(this.btnShowAccount_Click);
            // 
            // btnShowDocuments
            // 
            this.btnShowDocuments.ForeColor = System.Drawing.Color.Black;
            this.btnShowDocuments.Image = global::Sepehr.Forms.Admission.Properties.Resources.RefDocuments;
            this.btnShowDocuments.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnShowDocuments.ImagePaddingHorizontal = 8;
            this.btnShowDocuments.Name = "btnShowDocuments";
            this.btnShowDocuments.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F9);
            this.btnShowDocuments.Text = "<b>مشاهده مدارك</b>\r\n<div></div>\r\n<font color=\"#000000\">مدارك مراجعه.</font>";
            this.btnShowDocuments.Click += new System.EventHandler(this.btnShowDocuments_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.AutoCollapseOnClick = false;
            this.btnPrint.BeginGroup = true;
            this.btnPrint.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnPrint.ForeColor = System.Drawing.Color.Olive;
            this.btnPrint.Image = global::Sepehr.Forms.Admission.Properties.Resources.PrintBill;
            this.btnPrint.ImagePaddingHorizontal = 8;
            this.btnPrint.ImagePaddingVertical = 0;
            this.btnPrint.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.iContainerPrintTemplate,
            this.sliderPrintCount,
            this.btnPrintPreview,
            this.btnPrintTemplate});
            this.btnPrint.SubItemsExpandWidth = 15;
            this.btnPrint.Text = "<b>چاپ قبض</b>\r\n<div></div>\r\n<font color=\"#000000\">چاپ برای مراجعه.</font>";
            // 
            // iContainerPrintTemplate
            // 
            this.iContainerPrintTemplate.BeginGroup = true;
            this.iContainerPrintTemplate.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center;
            this.iContainerPrintTemplate.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.iContainerPrintTemplate.Name = "iContainerPrintTemplate";
            this.iContainerPrintTemplate.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.lblPrintTemplate,
            this.cboPrintTemplates});
            this.iContainerPrintTemplate.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle;
            // 
            // lblPrintTemplate
            // 
            this.lblPrintTemplate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblPrintTemplate.Name = "lblPrintTemplate";
            this.lblPrintTemplate.Text = "قالب قبض:";
            // 
            // cboPrintTemplates
            // 
            this.cboPrintTemplates.AutoCollapseOnClick = false;
            this.cboPrintTemplates.ComboWidth = 100;
            this.cboPrintTemplates.DropDownHeight = 50;
            this.cboPrintTemplates.DropDownWidth = 50;
            this.cboPrintTemplates.ItemHeight = 17;
            this.cboPrintTemplates.Name = "cboPrintTemplates";
            this.cboPrintTemplates.WatermarkText = "قالب چاپ";
            // 
            // sliderPrintCount
            // 
            this.sliderPrintCount.AutoCollapseOnClick = false;
            this.sliderPrintCount.LabelPosition = DevComponents.DotNetBar.eSliderLabelPosition.Top;
            this.sliderPrintCount.LabelWidth = 50;
            this.sliderPrintCount.Maximum = 5;
            this.sliderPrintCount.Minimum = 1;
            this.sliderPrintCount.Name = "sliderPrintCount";
            this.sliderPrintCount.Text = "تعداد چاپ: 1 نسخه";
            this.sliderPrintCount.TrackMarker = false;
            this.sliderPrintCount.Value = 1;
            this.sliderPrintCount.Width = 50;
            this.sliderPrintCount.ValueChanged += new System.EventHandler(this.sliderPrintCount_ValueChanged);
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.BeginGroup = true;
            this.btnPrintPreview.Image = global::Sepehr.Forms.Admission.Properties.Resources.PrintPreview;
            this.btnPrintPreview.ImagePaddingHorizontal = 8;
            this.btnPrintPreview.ImagePaddingVertical = 10;
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.Text = "پیش نمایش";
            this.btnPrintPreview.Click += new System.EventHandler(this.btnPrintPreview_Click);
            // 
            // btnPrintTemplate
            // 
            this.btnPrintTemplate.FontBold = true;
            this.btnPrintTemplate.HotFontBold = true;
            this.btnPrintTemplate.Image = global::Sepehr.Forms.Admission.Properties.Resources.PrintBill;
            this.btnPrintTemplate.ImagePaddingHorizontal = 8;
            this.btnPrintTemplate.Name = "btnPrintTemplate";
            this.btnPrintTemplate.Text = "چاپ قبض";
            this.btnPrintTemplate.Click += new System.EventHandler(this.btnPrintTemplate_Click);
            // 
            // btnRemoveRef
            // 
            this.btnRemoveRef.BeginGroup = true;
            this.btnRemoveRef.ForeColor = System.Drawing.Color.Red;
            this.btnRemoveRef.Image = global::Sepehr.Forms.Admission.Properties.Resources.DeleteMed;
            this.btnRemoveRef.ImagePaddingHorizontal = 8;
            this.btnRemoveRef.Name = "btnRemoveRef";
            this.btnRemoveRef.Text = "<b>حذف مراجعه</b>\r\n<div></div>\r\n<font color=\"#000000\">حذف از پرونده بیمار.</font>" +
                "";
            this.btnRemoveRef.Click += new System.EventHandler(this.btnRemoveRef_Click);
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            // 
            // ExpReferrals
            // 
            this.ExpReferrals.AnimationTime = 0;
            this.ExpReferrals.CanvasColor = System.Drawing.SystemColors.Control;
            this.ExpReferrals.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.ExpReferrals.Controls.Add(this.cmsPatients);
            this.ExpReferrals.Controls.Add(this.dgvData);
            this.ExpReferrals.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ExpReferrals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExpReferrals.ExpandOnTitleClick = true;
            this.ExpReferrals.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ExpReferrals.Location = new System.Drawing.Point(0, 244);
            this.ExpReferrals.Name = "ExpReferrals";
            this.ExpReferrals.RightToLeftLayout = true;
            this.ExpReferrals.Size = new System.Drawing.Size(594, 208);
            this.ExpReferrals.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.ExpReferrals.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.ExpReferrals.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.ExpReferrals.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.ExpReferrals.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.ExpReferrals.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.ExpReferrals.Style.GradientAngle = 90;
            this.ExpReferrals.TabIndex = 1;
            this.ExpReferrals.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.ExpReferrals.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.ExpReferrals.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.ExpReferrals.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.ExpReferrals.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.ExpReferrals.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.ExpReferrals.TitleStyle.GradientAngle = 90;
            this.ExpReferrals.TitleText = "مراجعات بیمار";
            this.ExpReferrals.ExpandedChanged += new DevComponents.DotNetBar.ExpandChangeEventHandler(this.ExpReferrals_ExpandedChanged);
            // 
            // cmsPatients
            // 
            this.cmsPatients.DockSide = DevComponents.DotNetBar.eDockSide.Document;
            this.cmsPatients.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmsPatients.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.cmsdgvData});
            this.cmsPatients.Location = new System.Drawing.Point(3, 71);
            this.cmsPatients.Name = "cmsPatients";
            this.cmsPatients.Size = new System.Drawing.Size(133, 25);
            this.cmsPatients.Stretch = true;
            this.cmsPatients.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.cmsPatients.TabIndex = 2;
            this.cmsPatients.TabStop = false;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToOrderColumns = true;
            this.dgvData.AllowUserToResizeRows = false;
            this.dgvData.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColRow,
            this.ColRefID,
            this.ColumnRefDate,
            this.ColAdmitter,
            this.ColPaymentStatus,
            this.ColRefDocsCount});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvData.Location = new System.Drawing.Point(0, 26);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.dgvData.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvData.RowTemplate.Height = 25;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(594, 182);
            this.dgvData.StandardTab = true;
            this.dgvData.TabIndex = 0;
            this.dgvData.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvData_CellMouseClick);
            this.dgvData.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dgvData_PreviewKeyDown);
            this.dgvData.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvData_CellFormatting);
            this.dgvData.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvData_CellMouseDoubleClick);
            // 
            // ColRow
            // 
            this.ColRow.DataPropertyName = "RowNo";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ColRow.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColRow.HeaderText = "ردیف";
            this.ColRow.Name = "ColRow";
            this.ColRow.ReadOnly = true;
            this.ColRow.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColRow.Width = 35;
            // 
            // ColRefID
            // 
            this.ColRefID.DataPropertyName = "ID";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ColRefID.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColRefID.HeaderText = "شماره مراجعه";
            this.ColRefID.Name = "ColRefID";
            this.ColRefID.ReadOnly = true;
            this.ColRefID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColRefID.ToolTipText = "شماره مراجعه بیمار";
            this.ColRefID.Width = 70;
            // 
            // ColumnRefDate
            // 
            this.ColumnRefDate.DataPropertyName = "RegisterDate";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColumnRefDate.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColumnRefDate.HeaderText = "زمان مراجعه";
            this.ColumnRefDate.Name = "ColumnRefDate";
            this.ColumnRefDate.ReadOnly = true;
            this.ColumnRefDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnRefDate.ShowTime = true;
            this.ColumnRefDate.ToolTipText = "تاریخ و ساعت مراجعه بیمار";
            this.ColumnRefDate.Width = 160;
            // 
            // ColAdmitter
            // 
            this.ColAdmitter.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColAdmitter.DataPropertyName = "AdmitterIX";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ColAdmitter.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColAdmitter.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ColAdmitter.HeaderText = "پذیرش كننده";
            this.ColAdmitter.Name = "ColAdmitter";
            this.ColAdmitter.ReadOnly = true;
            this.ColAdmitter.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ColPaymentStatus
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = "تسویه";
            this.ColPaymentStatus.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColPaymentStatus.HeaderText = "قابل دریافت (ریال)";
            this.ColPaymentStatus.Name = "ColPaymentStatus";
            this.ColPaymentStatus.ReadOnly = true;
            this.ColPaymentStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColPaymentStatus.ToolTipText = "وضعیت حساب بیمار";
            this.ColPaymentStatus.Width = 160;
            // 
            // ColRefDocsCount
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColRefDocsCount.DefaultCellStyle = dataGridViewCellStyle7;
            this.ColRefDocsCount.HeaderText = "تعداد مدارك";
            this.ColRefDocsCount.Name = "ColRefDocsCount";
            this.ColRefDocsCount.ReadOnly = true;
            this.ColRefDocsCount.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColRefDocsCount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColRefDocsCount.ToolTipText = "تعداد گزارش های بیمار";
            this.ColRefDocsCount.Width = 40;
            // 
            // TabCtrlPatientData
            // 
            this.TabCtrlPatientData.Animate = false;
            this.TabCtrlPatientData.AntiAlias = true;
            this.TabCtrlPatientData.BackColor = System.Drawing.Color.Transparent;
            this.TabCtrlPatientData.CanReorderTabs = false;
            this.TabCtrlPatientData.ColorScheme.TabItemBackgroundColorBlend.AddRange(new DevComponents.DotNetBar.BackgroundColorBlend[] {
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(230)))), ((int)(((byte)(249))))), 0F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(220)))), ((int)(((byte)(248))))), 0.45F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(208)))), ((int)(((byte)(245))))), 0.45F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(229)))), ((int)(((byte)(247))))), 1F)});
            this.TabCtrlPatientData.ColorScheme.TabItemHotBackgroundColorBlend.AddRange(new DevComponents.DotNetBar.BackgroundColorBlend[] {
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(253)))), ((int)(((byte)(235))))), 0F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(236)))), ((int)(((byte)(168))))), 0.45F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(218)))), ((int)(((byte)(89))))), 0.45F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(141))))), 1F)});
            this.TabCtrlPatientData.ColorScheme.TabItemSelectedBackgroundColorBlend.AddRange(new DevComponents.DotNetBar.BackgroundColorBlend[] {
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.White, 0F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254))))), 0.45F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254))))), 0.45F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254))))), 1F)});
            this.TabCtrlPatientData.ColorScheme.TabItemSelectedText = System.Drawing.Color.RoyalBlue;
            this.TabCtrlPatientData.Controls.Add(this.TabPanelBasicData);
            this.TabCtrlPatientData.Controls.Add(this.TabPanelAddInData);
            this.TabCtrlPatientData.Controls.Add(this.TabPanelContactData);
            this.TabCtrlPatientData.Dock = System.Windows.Forms.DockStyle.Top;
            this.TabCtrlPatientData.Location = new System.Drawing.Point(0, 74);
            this.TabCtrlPatientData.MinimumSize = new System.Drawing.Size(594, 170);
            this.TabCtrlPatientData.Name = "TabCtrlPatientData";
            this.TabCtrlPatientData.SelectedTabFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.TabCtrlPatientData.SelectedTabIndex = 0;
            this.TabCtrlPatientData.Size = new System.Drawing.Size(594, 170);
            this.TabCtrlPatientData.Style = DevComponents.DotNetBar.eTabStripStyle.Office2007Document;
            this.TabCtrlPatientData.TabIndex = 0;
            this.TabCtrlPatientData.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.MultilineNoNavigationBox;
            this.TabCtrlPatientData.Tabs.Add(this.TabBasicData);
            this.TabCtrlPatientData.Tabs.Add(this.TabContactData);
            this.TabCtrlPatientData.Tabs.Add(this.TabAddInData);
            this.TabCtrlPatientData.TabStop = false;
            // 
            // TabPanelBasicData
            // 
            this.TabPanelBasicData.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.TabPanelBasicData.Controls.Add(this.txtAgeDay);
            this.TabPanelBasicData.Controls.Add(this.cBoxEnterPatAge);
            this.TabPanelBasicData.Controls.Add(this.btnShowEnglishLastName);
            this.TabPanelBasicData.Controls.Add(this.btnShowEnglishFirstName);
            this.TabPanelBasicData.Controls.Add(this.txtFirstName);
            this.TabPanelBasicData.Controls.Add(this.txtAgeMonth);
            this.TabPanelBasicData.Controls.Add(this.txtAgeYear);
            this.TabPanelBasicData.Controls.Add(this.PanelMaritualStatus);
            this.TabPanelBasicData.Controls.Add(this.PanelGender);
            this.TabPanelBasicData.Controls.Add(this.lblFirstName);
            this.TabPanelBasicData.Controls.Add(this.lblLastName);
            this.TabPanelBasicData.Controls.Add(this.lblGender);
            this.TabPanelBasicData.Controls.Add(this.lblBirthDate);
            this.TabPanelBasicData.Controls.Add(this.lblMaritualStatus);
            this.TabPanelBasicData.Controls.Add(this.lblFatherName);
            this.TabPanelBasicData.Controls.Add(this.lblNationalCode);
            this.TabPanelBasicData.Controls.Add(this.lblNationalID);
            this.TabPanelBasicData.Controls.Add(this.lblBirthLocation);
            this.TabPanelBasicData.Controls.Add(this.lblOccupation);
            this.TabPanelBasicData.Controls.Add(this.txtBirthLocation);
            this.TabPanelBasicData.Controls.Add(this.txtFatherName);
            this.TabPanelBasicData.Controls.Add(this.cboJob);
            this.TabPanelBasicData.Controls.Add(this.txtLastName);
            this.TabPanelBasicData.Controls.Add(this.txtNationalCode);
            this.TabPanelBasicData.Controls.Add(this.txtNationalID);
            this.TabPanelBasicData.Controls.Add(this.DateInputBirthDate);
            this.TabPanelBasicData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabPanelBasicData.Location = new System.Drawing.Point(0, 23);
            this.TabPanelBasicData.Name = "TabPanelBasicData";
            this.TabPanelBasicData.Padding = new System.Windows.Forms.Padding(1);
            this.TabPanelBasicData.Size = new System.Drawing.Size(594, 147);
            this.TabPanelBasicData.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.TabPanelBasicData.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(188)))), ((int)(((byte)(227)))));
            this.TabPanelBasicData.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.TabPanelBasicData.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(165)))), ((int)(((byte)(199)))));
            this.TabPanelBasicData.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.TabPanelBasicData.Style.GradientAngle = 90;
            this.TabPanelBasicData.TabIndex = 0;
            this.TabPanelBasicData.TabItem = this.TabBasicData;
            // 
            // cBoxEnterPatAge
            // 
            this.cBoxEnterPatAge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxEnterPatAge.AutoSize = true;
            this.cBoxEnterPatAge.BackColor = System.Drawing.Color.Transparent;
            this.cBoxEnterPatAge.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxEnterPatAge.Location = new System.Drawing.Point(35, 37);
            this.cBoxEnterPatAge.Name = "cBoxEnterPatAge";
            this.cBoxEnterPatAge.Size = new System.Drawing.Size(70, 16);
            this.cBoxEnterPatAge.TabIndex = 13;
            this.cBoxEnterPatAge.TabStop = false;
            this.cBoxEnterPatAge.Text = "ورود سن";
            this.cBoxEnterPatAge.TextColor = System.Drawing.Color.Green;
            this.cBoxEnterPatAge.Click += new System.EventHandler(this.cBoxEnterPatientAge_CheckedChanged);
            this.cBoxEnterPatAge.CheckedChanged += new System.EventHandler(this.cBoxEnterPatientAge_CheckedChanged);
            // 
            // btnShowEnglishLastName
            // 
            this.btnShowEnglishLastName.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnShowEnglishLastName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowEnglishLastName.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnShowEnglishLastName.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.btnShowEnglishLastName.Location = new System.Drawing.Point(20, 8);
            this.btnShowEnglishLastName.Name = "btnShowEnglishLastName";
            this.btnShowEnglishLastName.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor();
            this.btnShowEnglishLastName.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F7);
            this.btnShowEnglishLastName.Size = new System.Drawing.Size(21, 21);
            this.btnShowEnglishLastName.TabIndex = 5;
            this.btnShowEnglishLastName.TabStop = false;
            this.btnShowEnglishLastName.Tag = "";
            this.btnShowEnglishLastName.Text = "...";
            this.btnShowEnglishLastName.Click += new System.EventHandler(this.btnShownEnglishName_Click);
            // 
            // btnShowEnglishFirstName
            // 
            this.btnShowEnglishFirstName.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnShowEnglishFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowEnglishFirstName.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnShowEnglishFirstName.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.btnShowEnglishFirstName.Location = new System.Drawing.Point(302, 8);
            this.btnShowEnglishFirstName.Name = "btnShowEnglishFirstName";
            this.btnShowEnglishFirstName.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor();
            this.btnShowEnglishFirstName.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F7);
            this.btnShowEnglishFirstName.Size = new System.Drawing.Size(21, 21);
            this.btnShowEnglishFirstName.TabIndex = 2;
            this.btnShowEnglishFirstName.TabStop = false;
            this.btnShowEnglishFirstName.Tag = "";
            this.btnShowEnglishFirstName.Text = "...";
            this.btnShowEnglishFirstName.Click += new System.EventHandler(this.btnShownEnglishName_Click);
            // 
            // txtFirstName
            // 
            this.txtFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFirstName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtFirstName.Border.Class = "TextBoxBorder";
            this.txtFirstName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtFirstName.ForeColor = System.Drawing.Color.Blue;
            this.txtFirstName.Location = new System.Drawing.Point(323, 8);
            this.txtFirstName.MaxLength = 20;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(164, 21);
            this.txtFirstName.TabIndex = 0;
            this.txtFirstName.Tag = "";
            // 
            // txtAgeMonth
            // 
            this.txtAgeMonth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtAgeMonth.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtAgeMonth.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtAgeMonth.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtAgeMonth.Location = new System.Drawing.Point(139, 35);
            this.txtAgeMonth.MaxValue = 12;
            this.txtAgeMonth.MinValue = 0;
            this.txtAgeMonth.Name = "txtAgeMonth";
            this.txtAgeMonth.Size = new System.Drawing.Size(31, 21);
            this.txtAgeMonth.TabIndex = 10;
            this.txtAgeMonth.Tag = "";
            this.txtAgeMonth.Visible = false;
            this.txtAgeMonth.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            this.txtAgeMonth.WatermarkText = "ماه";
            this.txtAgeMonth.ValueChanged += new System.EventHandler(this.txtAge_ValueChanged);
            // 
            // txtAgeYear
            // 
            this.txtAgeYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtAgeYear.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtAgeYear.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtAgeYear.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtAgeYear.Location = new System.Drawing.Point(173, 35);
            this.txtAgeYear.MaxValue = 110;
            this.txtAgeYear.MinValue = 0;
            this.txtAgeYear.Name = "txtAgeYear";
            this.txtAgeYear.Size = new System.Drawing.Size(31, 21);
            this.txtAgeYear.TabIndex = 9;
            this.txtAgeYear.Tag = "";
            this.txtAgeYear.Visible = false;
            this.txtAgeYear.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            this.txtAgeYear.WatermarkText = "سال";
            this.txtAgeYear.ValueChanged += new System.EventHandler(this.txtAge_ValueChanged);
            // 
            // PanelMaritualStatus
            // 
            this.PanelMaritualStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelMaritualStatus.BackColor = System.Drawing.Color.Transparent;
            this.PanelMaritualStatus.Controls.Add(this.cboxSingle);
            this.PanelMaritualStatus.Controls.Add(this.cBoxMaried);
            this.PanelMaritualStatus.Location = new System.Drawing.Point(302, 60);
            this.PanelMaritualStatus.Name = "PanelMaritualStatus";
            this.PanelMaritualStatus.Size = new System.Drawing.Size(185, 25);
            this.PanelMaritualStatus.TabIndex = 15;
            // 
            // cboxSingle
            // 
            this.cboxSingle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxSingle.AutoSize = true;
            this.cboxSingle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cboxSingle.ForeColor = System.Drawing.Color.DarkBlue;
            this.cboxSingle.Location = new System.Drawing.Point(120, 4);
            this.cboxSingle.Name = "cboxSingle";
            this.cboxSingle.Size = new System.Drawing.Size(52, 17);
            this.cboxSingle.TabIndex = 0;
            this.cboxSingle.TabStop = true;
            this.cboxSingle.Text = "مجرد";
            this.cboxSingle.UseMnemonic = false;
            this.cboxSingle.UseVisualStyleBackColor = false;
            this.cboxSingle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RadioButton_KeyPress);
            // 
            // cBoxMaried
            // 
            this.cBoxMaried.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxMaried.AutoSize = true;
            this.cBoxMaried.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxMaried.ForeColor = System.Drawing.Color.DarkBlue;
            this.cBoxMaried.Location = new System.Drawing.Point(59, 4);
            this.cBoxMaried.Name = "cBoxMaried";
            this.cBoxMaried.Size = new System.Drawing.Size(58, 17);
            this.cBoxMaried.TabIndex = 1;
            this.cBoxMaried.Text = "متاهل";
            this.cBoxMaried.UseMnemonic = false;
            this.cBoxMaried.UseVisualStyleBackColor = true;
            // 
            // PanelGender
            // 
            this.PanelGender.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelGender.BackColor = System.Drawing.Color.Transparent;
            this.PanelGender.Controls.Add(this.cBoxFemale);
            this.PanelGender.Controls.Add(this.cBoxMale);
            this.PanelGender.ForeColor = System.Drawing.Color.Navy;
            this.PanelGender.Location = new System.Drawing.Point(302, 33);
            this.PanelGender.Name = "PanelGender";
            this.PanelGender.Size = new System.Drawing.Size(185, 25);
            this.PanelGender.TabIndex = 7;
            // 
            // cBoxFemale
            // 
            this.cBoxFemale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxFemale.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxFemale.ForeColor = System.Drawing.Color.DarkBlue;
            this.cBoxFemale.Location = new System.Drawing.Point(78, 4);
            this.cBoxFemale.Name = "cBoxFemale";
            this.cBoxFemale.Size = new System.Drawing.Size(39, 17);
            this.cBoxFemale.TabIndex = 1;
            this.cBoxFemale.Text = "زن";
            this.cBoxFemale.UseVisualStyleBackColor = true;
            // 
            // cBoxMale
            // 
            this.cBoxMale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxMale.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxMale.ForeColor = System.Drawing.Color.DarkBlue;
            this.cBoxMale.Location = new System.Drawing.Point(128, 4);
            this.cBoxMale.Name = "cBoxMale";
            this.cBoxMale.Size = new System.Drawing.Size(44, 17);
            this.cBoxMale.TabIndex = 0;
            this.cBoxMale.TabStop = true;
            this.cBoxMale.Text = "مرد";
            this.cBoxMale.UseVisualStyleBackColor = true;
            this.cBoxMale.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RadioButton_KeyPress);
            // 
            // lblFirstName
            // 
            this.lblFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.BackColor = System.Drawing.Color.Transparent;
            this.lblFirstName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblFirstName.ForeColor = System.Drawing.Color.Black;
            this.lblFirstName.Location = new System.Drawing.Point(494, 10);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(21, 16);
            this.lblFirstName.TabIndex = 1;
            this.lblFirstName.Text = "نام:";
            this.lblFirstName.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblLastName
            // 
            this.lblLastName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLastName.AutoSize = true;
            this.lblLastName.BackColor = System.Drawing.Color.Transparent;
            this.lblLastName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblLastName.ForeColor = System.Drawing.Color.Black;
            this.lblLastName.Location = new System.Drawing.Point(210, 10);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(74, 16);
            this.lblLastName.TabIndex = 3;
            this.lblLastName.Text = "نام خانوادگی:";
            this.lblLastName.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblGender
            // 
            this.lblGender.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGender.AutoSize = true;
            this.lblGender.BackColor = System.Drawing.Color.Transparent;
            this.lblGender.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblGender.Location = new System.Drawing.Point(494, 37);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(47, 16);
            this.lblGender.TabIndex = 6;
            this.lblGender.Text = "جنسیت:";
            this.lblGender.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblBirthDate
            // 
            this.lblBirthDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBirthDate.AutoSize = true;
            this.lblBirthDate.BackColor = System.Drawing.Color.Transparent;
            this.lblBirthDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblBirthDate.Location = new System.Drawing.Point(210, 37);
            this.lblBirthDate.Name = "lblBirthDate";
            this.lblBirthDate.Size = new System.Drawing.Size(55, 16);
            this.lblBirthDate.TabIndex = 8;
            this.lblBirthDate.Text = "تاریخ تولد:";
            this.lblBirthDate.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblMaritualStatus
            // 
            this.lblMaritualStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMaritualStatus.AutoSize = true;
            this.lblMaritualStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblMaritualStatus.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblMaritualStatus.Location = new System.Drawing.Point(494, 64);
            this.lblMaritualStatus.Name = "lblMaritualStatus";
            this.lblMaritualStatus.Size = new System.Drawing.Size(73, 16);
            this.lblMaritualStatus.TabIndex = 14;
            this.lblMaritualStatus.Text = "وضعیت تاهل:";
            this.lblMaritualStatus.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblFatherName
            // 
            this.lblFatherName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFatherName.AutoSize = true;
            this.lblFatherName.BackColor = System.Drawing.Color.Transparent;
            this.lblFatherName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblFatherName.Location = new System.Drawing.Point(210, 64);
            this.lblFatherName.Name = "lblFatherName";
            this.lblFatherName.Size = new System.Drawing.Size(40, 16);
            this.lblFatherName.TabIndex = 16;
            this.lblFatherName.Text = "نام پدر:";
            this.lblFatherName.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblNationalCode
            // 
            this.lblNationalCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNationalCode.AutoSize = true;
            this.lblNationalCode.BackColor = System.Drawing.Color.Transparent;
            this.lblNationalCode.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblNationalCode.Location = new System.Drawing.Point(494, 91);
            this.lblNationalCode.Name = "lblNationalCode";
            this.lblNationalCode.Size = new System.Drawing.Size(98, 16);
            this.lblNationalCode.TabIndex = 18;
            this.lblNationalCode.Text = "شماره شناسنامه:";
            this.lblNationalCode.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblNationalID
            // 
            this.lblNationalID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNationalID.AutoSize = true;
            this.lblNationalID.BackColor = System.Drawing.Color.Transparent;
            this.lblNationalID.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblNationalID.Location = new System.Drawing.Point(210, 91);
            this.lblNationalID.Name = "lblNationalID";
            this.lblNationalID.Size = new System.Drawing.Size(45, 16);
            this.lblNationalID.TabIndex = 20;
            this.lblNationalID.Text = "كد ملی:";
            this.lblNationalID.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblBirthLocation
            // 
            this.lblBirthLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBirthLocation.AutoSize = true;
            this.lblBirthLocation.BackColor = System.Drawing.Color.Transparent;
            this.lblBirthLocation.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblBirthLocation.Location = new System.Drawing.Point(494, 118);
            this.lblBirthLocation.Name = "lblBirthLocation";
            this.lblBirthLocation.Size = new System.Drawing.Size(54, 16);
            this.lblBirthLocation.TabIndex = 22;
            this.lblBirthLocation.Text = "محل تولد:";
            this.lblBirthLocation.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblOccupation
            // 
            this.lblOccupation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOccupation.AutoSize = true;
            this.lblOccupation.BackColor = System.Drawing.Color.Transparent;
            this.lblOccupation.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblOccupation.Location = new System.Drawing.Point(210, 118);
            this.lblOccupation.Name = "lblOccupation";
            this.lblOccupation.Size = new System.Drawing.Size(34, 16);
            this.lblOccupation.TabIndex = 24;
            this.lblOccupation.Text = "شغل:";
            this.lblOccupation.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // txtBirthLocation
            // 
            this.txtBirthLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBirthLocation.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtBirthLocation.Border.Class = "TextBoxBorder";
            this.txtBirthLocation.Location = new System.Drawing.Point(302, 116);
            this.txtBirthLocation.MaxLength = 20;
            this.txtBirthLocation.Name = "txtBirthLocation";
            this.txtBirthLocation.Size = new System.Drawing.Size(185, 21);
            this.txtBirthLocation.TabIndex = 23;
            this.txtBirthLocation.Tag = "";
            // 
            // txtFatherName
            // 
            this.txtFatherName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFatherName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtFatherName.Border.Class = "TextBoxBorder";
            this.txtFatherName.Location = new System.Drawing.Point(20, 62);
            this.txtFatherName.MaxLength = 15;
            this.txtFatherName.Name = "txtFatherName";
            this.txtFatherName.Size = new System.Drawing.Size(184, 21);
            this.txtFatherName.TabIndex = 17;
            this.txtFatherName.Tag = "";
            // 
            // cboJob
            // 
            this.cboJob.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboJob.DisplayMember = "Title";
            this.cboJob.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboJob.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboJob.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cboJob.ItemHeight = 13;
            this.cboJob.Location = new System.Drawing.Point(20, 116);
            this.cboJob.Name = "cboJob";
            this.cboJob.Size = new System.Drawing.Size(184, 21);
            this.cboJob.TabIndex = 25;
            this.cboJob.ValueMember = "ID";
            // 
            // txtLastName
            // 
            this.txtLastName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLastName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtLastName.Border.Class = "TextBoxBorder";
            this.txtLastName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtLastName.ForeColor = System.Drawing.Color.Blue;
            this.txtLastName.Location = new System.Drawing.Point(40, 8);
            this.txtLastName.MaxLength = 30;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(164, 21);
            this.txtLastName.TabIndex = 4;
            this.txtLastName.Tag = "";
            // 
            // txtNationalCode
            // 
            this.txtNationalCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNationalCode.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtNationalCode.Border.Class = "TextBoxBorder";
            this.txtNationalCode.Location = new System.Drawing.Point(302, 89);
            this.txtNationalCode.MaxLength = 15;
            this.txtNationalCode.Name = "txtNationalCode";
            this.txtNationalCode.Size = new System.Drawing.Size(185, 21);
            this.txtNationalCode.TabIndex = 19;
            this.txtNationalCode.Tag = "";
            this.txtNationalCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtNationalID
            // 
            this.txtNationalID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNationalID.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtNationalID.Border.Class = "TextBoxBorder";
            this.txtNationalID.Location = new System.Drawing.Point(20, 89);
            this.txtNationalID.MaxLength = 15;
            this.txtNationalID.Name = "txtNationalID";
            this.txtNationalID.Size = new System.Drawing.Size(184, 21);
            this.txtNationalID.TabIndex = 21;
            this.txtNationalID.Tag = "";
            this.txtNationalID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DateInputBirthDate
            // 
            this.DateInputBirthDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DateInputBirthDate.IsPopupOpen = false;
            this.DateInputBirthDate.Location = new System.Drawing.Point(115, 35);
            this.DateInputBirthDate.Name = "DateInputBirthDate";
            this.DateInputBirthDate.SelectedDateTime = new System.DateTime(2010, 2, 7, 21, 50, 2, 978);
            this.DateInputBirthDate.Size = new System.Drawing.Size(89, 20);
            this.DateInputBirthDate.TabIndex = 11;
            this.DateInputBirthDate.SelectedDateTimeChanged += new System.EventHandler(this.DateInputBirthDate_SelectedDateTimeChanged);
            // 
            // txtAgeDay
            // 
            this.txtAgeDay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtAgeDay.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtAgeDay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtAgeDay.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtAgeDay.Location = new System.Drawing.Point(105, 35);
            this.txtAgeDay.MaxValue = 31;
            this.txtAgeDay.MinValue = 0;
            this.txtAgeDay.Name = "txtAgeDay";
            this.txtAgeDay.Size = new System.Drawing.Size(31, 21);
            this.txtAgeDay.TabIndex = 12;
            this.txtAgeDay.Tag = "";
            this.txtAgeDay.Visible = false;
            this.txtAgeDay.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            this.txtAgeDay.WatermarkText = "روز";
            this.txtAgeDay.ValueChanged += new System.EventHandler(this.txtAge_ValueChanged);
            // 
            // TabBasicData
            // 
            this.TabBasicData.AttachedControl = this.TabPanelBasicData;
            this.TabBasicData.Name = "TabBasicData";
            this.TabBasicData.Text = "اطلاعات پایه";
            // 
            // TabPanelAddInData
            // 
            this.TabPanelAddInData.AutoScroll = true;
            this.TabPanelAddInData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabPanelAddInData.Location = new System.Drawing.Point(0, 23);
            this.TabPanelAddInData.Name = "TabPanelAddInData";
            this.TabPanelAddInData.Padding = new System.Windows.Forms.Padding(1);
            this.TabPanelAddInData.Size = new System.Drawing.Size(594, 147);
            this.TabPanelAddInData.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.TabPanelAddInData.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(188)))), ((int)(((byte)(227)))));
            this.TabPanelAddInData.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.TabPanelAddInData.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(165)))), ((int)(((byte)(199)))));
            this.TabPanelAddInData.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.TabPanelAddInData.Style.GradientAngle = 90;
            this.TabPanelAddInData.TabIndex = 0;
            this.TabPanelAddInData.TabItem = this.TabAddInData;
            // 
            // TabAddInData
            // 
            this.TabAddInData.AttachedControl = this.TabPanelAddInData;
            this.TabAddInData.Name = "TabAddInData";
            this.TabAddInData.Text = "سایر اطلاعات بیمار";
            // 
            // TabPanelContactData
            // 
            this.TabPanelContactData.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.TabPanelContactData.Controls.Add(this.txtTel1);
            this.TabPanelContactData.Controls.Add(this.cboCountry);
            this.TabPanelContactData.Controls.Add(this.lblEmail);
            this.TabPanelContactData.Controls.Add(this.lblState);
            this.TabPanelContactData.Controls.Add(this.lblTel2);
            this.TabPanelContactData.Controls.Add(this.lblAddress);
            this.TabPanelContactData.Controls.Add(this.lblCity);
            this.TabPanelContactData.Controls.Add(this.lblCountry);
            this.TabPanelContactData.Controls.Add(this.lblZipCode);
            this.TabPanelContactData.Controls.Add(this.lblTel1);
            this.TabPanelContactData.Controls.Add(this.cboCity);
            this.TabPanelContactData.Controls.Add(this.cboState);
            this.TabPanelContactData.Controls.Add(this.txtZipCode);
            this.TabPanelContactData.Controls.Add(this.txtEmail);
            this.TabPanelContactData.Controls.Add(this.txtAddress);
            this.TabPanelContactData.Controls.Add(this.txtTel2);
            this.TabPanelContactData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabPanelContactData.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.TabPanelContactData.Location = new System.Drawing.Point(0, 23);
            this.TabPanelContactData.Name = "TabPanelContactData";
            this.TabPanelContactData.Padding = new System.Windows.Forms.Padding(1);
            this.TabPanelContactData.Size = new System.Drawing.Size(594, 147);
            this.TabPanelContactData.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.TabPanelContactData.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(188)))), ((int)(((byte)(227)))));
            this.TabPanelContactData.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.TabPanelContactData.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(165)))), ((int)(((byte)(199)))));
            this.TabPanelContactData.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.TabPanelContactData.Style.GradientAngle = 90;
            this.TabPanelContactData.TabIndex = 0;
            this.TabPanelContactData.TabItem = this.TabContactData;
            // 
            // txtTel1
            // 
            this.txtTel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTel1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtTel1.Border.Class = "TextBoxBorder";
            this.txtTel1.Location = new System.Drawing.Point(300, 8);
            this.txtTel1.MaxLength = 15;
            this.txtTel1.Name = "txtTel1";
            this.txtTel1.Size = new System.Drawing.Size(184, 21);
            this.txtTel1.TabIndex = 0;
            this.txtTel1.Tag = "";
            this.txtTel1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cboCountry
            // 
            this.cboCountry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCountry.DisplayMember = "Name";
            this.cboCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCountry.FormattingEnabled = true;
            this.cboCountry.Location = new System.Drawing.Point(300, 35);
            this.cboCountry.Name = "cboCountry";
            this.cboCountry.Size = new System.Drawing.Size(184, 21);
            this.cboCountry.TabIndex = 5;
            this.cboCountry.ValueMember = "ID";
            // 
            // lblEmail
            // 
            this.lblEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEmail.AutoSize = true;
            this.lblEmail.BackColor = System.Drawing.Color.Transparent;
            this.lblEmail.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblEmail.ForeColor = System.Drawing.Color.Green;
            this.lblEmail.Location = new System.Drawing.Point(208, 64);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(34, 16);
            this.lblEmail.TabIndex = 10;
            this.lblEmail.Text = "ایمیل:";
            // 
            // lblState
            // 
            this.lblState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblState.AutoSize = true;
            this.lblState.BackColor = System.Drawing.Color.Transparent;
            this.lblState.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblState.ForeColor = System.Drawing.Color.Green;
            this.lblState.Location = new System.Drawing.Point(208, 37);
            this.lblState.Name = "lblState";
            this.lblState.SingleLineColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblState.Size = new System.Drawing.Size(38, 16);
            this.lblState.TabIndex = 6;
            this.lblState.Text = "استان:";
            // 
            // lblTel2
            // 
            this.lblTel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTel2.AutoSize = true;
            this.lblTel2.BackColor = System.Drawing.Color.Transparent;
            this.lblTel2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTel2.ForeColor = System.Drawing.Color.Green;
            this.lblTel2.Location = new System.Drawing.Point(208, 10);
            this.lblTel2.Name = "lblTel2";
            this.lblTel2.Size = new System.Drawing.Size(40, 16);
            this.lblTel2.TabIndex = 2;
            this.lblTel2.Text = "تلفن 2:";
            // 
            // lblAddress
            // 
            this.lblAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAddress.AutoSize = true;
            this.lblAddress.BackColor = System.Drawing.Color.Transparent;
            this.lblAddress.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblAddress.ForeColor = System.Drawing.Color.Green;
            this.lblAddress.Location = new System.Drawing.Point(487, 110);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(72, 16);
            this.lblAddress.TabIndex = 14;
            this.lblAddress.Text = "آدرس پستی:";
            // 
            // lblCity
            // 
            this.lblCity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCity.AutoSize = true;
            this.lblCity.BackColor = System.Drawing.Color.Transparent;
            this.lblCity.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblCity.ForeColor = System.Drawing.Color.Green;
            this.lblCity.Location = new System.Drawing.Point(487, 64);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(31, 16);
            this.lblCity.TabIndex = 8;
            this.lblCity.Text = "شهر:";
            // 
            // lblCountry
            // 
            this.lblCountry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCountry.AutoSize = true;
            this.lblCountry.BackColor = System.Drawing.Color.Transparent;
            this.lblCountry.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblCountry.ForeColor = System.Drawing.Color.Green;
            this.lblCountry.Location = new System.Drawing.Point(487, 37);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(36, 16);
            this.lblCountry.TabIndex = 4;
            this.lblCountry.Text = "كشور:";
            // 
            // lblZipCode
            // 
            this.lblZipCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblZipCode.AutoSize = true;
            this.lblZipCode.BackColor = System.Drawing.Color.Transparent;
            this.lblZipCode.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblZipCode.ForeColor = System.Drawing.Color.Green;
            this.lblZipCode.Location = new System.Drawing.Point(487, 89);
            this.lblZipCode.Name = "lblZipCode";
            this.lblZipCode.Size = new System.Drawing.Size(55, 16);
            this.lblZipCode.TabIndex = 12;
            this.lblZipCode.Text = "کد پستی:";
            // 
            // lblTel1
            // 
            this.lblTel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTel1.AutoSize = true;
            this.lblTel1.BackColor = System.Drawing.Color.Transparent;
            this.lblTel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTel1.ForeColor = System.Drawing.Color.Green;
            this.lblTel1.Location = new System.Drawing.Point(487, 10);
            this.lblTel1.Name = "lblTel1";
            this.lblTel1.Size = new System.Drawing.Size(40, 16);
            this.lblTel1.TabIndex = 1;
            this.lblTel1.Text = "تلفن 1:";
            // 
            // cboCity
            // 
            this.cboCity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCity.DisplayMember = "Name";
            this.cboCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCity.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboCity.ItemHeight = 13;
            this.cboCity.Location = new System.Drawing.Point(300, 62);
            this.cboCity.Name = "cboCity";
            this.cboCity.Size = new System.Drawing.Size(184, 21);
            this.cboCity.TabIndex = 9;
            this.cboCity.ValueMember = "ID";
            // 
            // cboState
            // 
            this.cboState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboState.DisplayMember = "Name";
            this.cboState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboState.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboState.FormattingEnabled = true;
            this.cboState.ItemHeight = 13;
            this.cboState.Location = new System.Drawing.Point(22, 35);
            this.cboState.Name = "cboState";
            this.cboState.Size = new System.Drawing.Size(184, 21);
            this.cboState.TabIndex = 7;
            this.cboState.ValueMember = "ID";
            // 
            // txtZipCode
            // 
            this.txtZipCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtZipCode.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtZipCode.Border.Class = "TextBoxBorder";
            this.txtZipCode.Location = new System.Drawing.Point(300, 87);
            this.txtZipCode.MaxLength = 20;
            this.txtZipCode.Name = "txtZipCode";
            this.txtZipCode.Size = new System.Drawing.Size(184, 21);
            this.txtZipCode.TabIndex = 13;
            this.txtZipCode.Tag = "";
            this.txtZipCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtEmail.Border.Class = "TextBoxBorder";
            this.txtEmail.Location = new System.Drawing.Point(22, 62);
            this.txtEmail.MaxLength = 25;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtEmail.Size = new System.Drawing.Size(184, 21);
            this.txtEmail.TabIndex = 11;
            this.txtEmail.Tag = "";
            this.txtEmail.Leave += new System.EventHandler(this.txtEmail_Leave);
            this.txtEmail.Enter += new System.EventHandler(this.txtEmail_Enter);
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddress.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtAddress.Border.Class = "TextBoxBorder";
            this.txtAddress.Location = new System.Drawing.Point(22, 110);
            this.txtAddress.MaxLength = 200;
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAddress.Size = new System.Drawing.Size(462, 33);
            this.txtAddress.TabIndex = 15;
            this.txtAddress.Tag = "";
            // 
            // txtTel2
            // 
            this.txtTel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTel2.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtTel2.Border.Class = "TextBoxBorder";
            this.txtTel2.Location = new System.Drawing.Point(22, 8);
            this.txtTel2.MaxLength = 15;
            this.txtTel2.Name = "txtTel2";
            this.txtTel2.Size = new System.Drawing.Size(184, 21);
            this.txtTel2.TabIndex = 3;
            this.txtTel2.Tag = "";
            this.txtTel2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TabContactData
            // 
            this.TabContactData.AttachedControl = this.TabPanelContactData;
            this.TabContactData.Name = "TabContactData";
            this.TabContactData.Text = "اطلاعات تماس";
            // 
            // RibbonBarNavigation
            // 
            this.RibbonBarNavigation.AutoOverflowEnabled = true;
            this.RibbonBarNavigation.Dock = System.Windows.Forms.DockStyle.Top;
            this.RibbonBarNavigation.FadeEffect = false;
            this.RibbonBarNavigation.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnNewPatient,
            this.btnNewReferral,
            this.btnPrevPatient,
            this.iContainerPatientID,
            this.btnNextPatient,
            this.btnEditMode,
            this.btnRefresh,
            this.btnSchList,
            this.btnHelp});
            this.RibbonBarNavigation.ItemSpacing = 0;
            this.RibbonBarNavigation.Location = new System.Drawing.Point(0, 0);
            this.RibbonBarNavigation.Name = "RibbonBarNavigation";
            this.RibbonBarNavigation.Size = new System.Drawing.Size(594, 74);
            this.RibbonBarNavigation.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.RibbonBarNavigation.TabIndex = 2;
            this.RibbonBarNavigation.TabStop = false;
            this.RibbonBarNavigation.TitleVisible = false;
            // 
            // btnNewPatient
            // 
            this.btnNewPatient.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnNewPatient.FontBold = true;
            this.btnNewPatient.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnNewPatient.Image = global::Sepehr.Forms.Admission.Properties.Resources.NewPat;
            this.btnNewPatient.ImagePaddingHorizontal = 8;
            this.btnNewPatient.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnNewPatient.Name = "btnNewPatient";
            this.btnNewPatient.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F2);
            this.btnNewPatient.Text = "بیمار جدید\r\n(F2)";
            this.btnNewPatient.Click += new System.EventHandler(this.btnNewPatient_Click);
            // 
            // btnNewReferral
            // 
            this.btnNewReferral.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnNewReferral.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnNewReferral.FontBold = true;
            this.btnNewReferral.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnNewReferral.Image = global::Sepehr.Forms.Admission.Properties.Resources.AddMed;
            this.btnNewReferral.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnNewReferral.ImagePaddingHorizontal = 8;
            this.btnNewReferral.ImagePaddingVertical = 10;
            this.btnNewReferral.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnNewReferral.Name = "btnNewReferral";
            this.btnNewReferral.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F4);
            this.btnNewReferral.Text = "مراجعه\r\nجدید (F4)";
            this.btnNewReferral.Click += new System.EventHandler(this.btnNewReferral_Click);
            // 
            // btnPrevPatient
            // 
            this.btnPrevPatient.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnPrevPatient.FontBold = true;
            this.btnPrevPatient.ForeColor = System.Drawing.Color.Green;
            this.btnPrevPatient.Image = global::Sepehr.Forms.Admission.Properties.Resources.RightLarge;
            this.btnPrevPatient.ImagePaddingHorizontal = 8;
            this.btnPrevPatient.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnPrevPatient.Name = "btnPrevPatient";
            this.btnPrevPatient.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F11);
            this.btnPrevPatient.Text = "قبلی (F11)";
            this.btnPrevPatient.Click += new System.EventHandler(this.btnPrevPatient_Click);
            // 
            // iContainerPatientID
            // 
            this.iContainerPatientID.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center;
            this.iContainerPatientID.ItemSpacing = 0;
            this.iContainerPatientID.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.iContainerPatientID.MultiLine = true;
            this.iContainerPatientID.Name = "iContainerPatientID";
            this.iContainerPatientID.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.lblPatientID,
            this.iContainerPatientIDTextBox});
            this.iContainerPatientID.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle;
            // 
            // lblPatientID
            // 
            this.lblPatientID.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblPatientID.Image = global::Sepehr.Forms.Admission.Properties.Resources.PatientID;
            this.lblPatientID.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right;
            this.lblPatientID.Name = "lblPatientID";
            this.lblPatientID.Text = "شماره بیمار:";
            this.lblPatientID.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // iContainerPatientIDTextBox
            // 
            this.iContainerPatientIDTextBox.MinimumSize = new System.Drawing.Size(0, 28);
            this.iContainerPatientIDTextBox.Name = "iContainerPatientIDTextBox";
            this.iContainerPatientIDTextBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.txtPatientID});
            // 
            // txtPatientID
            // 
            this.txtPatientID.ControlText = "شماره بیمار";
            this.txtPatientID.MaxLength = 20;
            this.txtPatientID.Name = "txtPatientID";
            this.txtPatientID.ShowSubItems = false;
            this.txtPatientID.TextBoxWidth = 110;
            this.txtPatientID.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.txtPatientID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPatientID_KeyPress);
            // 
            // btnNextPatient
            // 
            this.btnNextPatient.BeginGroup = true;
            this.btnNextPatient.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnNextPatient.FontBold = true;
            this.btnNextPatient.ForeColor = System.Drawing.Color.Green;
            this.btnNextPatient.Image = global::Sepehr.Forms.Admission.Properties.Resources.LeftLarge;
            this.btnNextPatient.ImagePaddingHorizontal = 8;
            this.btnNextPatient.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnNextPatient.Name = "btnNextPatient";
            this.btnNextPatient.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);
            this.btnNextPatient.Text = "بعدی (F12)";
            this.btnNextPatient.Click += new System.EventHandler(this.btnNextPatient_Click);
            // 
            // btnEditMode
            // 
            this.btnEditMode.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnEditMode.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnEditMode.FontBold = true;
            this.btnEditMode.ForeColor = System.Drawing.Color.DarkViolet;
            this.btnEditMode.HotFontBold = true;
            this.btnEditMode.HotForeColor = System.Drawing.Color.Green;
            this.btnEditMode.Image = global::Sepehr.Forms.Admission.Properties.Resources.EditLarge;
            this.btnEditMode.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnEditMode.ImagePaddingHorizontal = 8;
            this.btnEditMode.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnEditMode.Name = "btnEditMode";
            this.btnEditMode.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F3);
            this.btnEditMode.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnFreePatient,
            this.btnDeletePatient});
            this.btnEditMode.Text = "ویرایش\r\n(F3)";
            this.btnEditMode.Click += new System.EventHandler(this.btnEditMode_Click);
            // 
            // btnFreePatient
            // 
            this.btnFreePatient.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnFreePatient.FontBold = true;
            this.btnFreePatient.ForeColor = System.Drawing.Color.Blue;
            this.btnFreePatient.Image = global::Sepehr.Forms.Admission.Properties.Resources.FreeLockedRow;
            this.btnFreePatient.ImagePaddingHorizontal = 8;
            this.btnFreePatient.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnFreePatient.Name = "btnFreePatient";
            this.btnFreePatient.RibbonWordWrap = false;
            this.btnFreePatient.Text = "آزاد كردن";
            this.btnFreePatient.Click += new System.EventHandler(this.btnFreePatient_Click);
            // 
            // btnDeletePatient
            // 
            this.btnDeletePatient.BeginGroup = true;
            this.btnDeletePatient.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnDeletePatient.ForeColor = System.Drawing.Color.Red;
            this.btnDeletePatient.HotFontBold = true;
            this.btnDeletePatient.HotForeColor = System.Drawing.Color.Navy;
            this.btnDeletePatient.Image = global::Sepehr.Forms.Admission.Properties.Resources.DeleteMed;
            this.btnDeletePatient.ImagePaddingHorizontal = 8;
            this.btnDeletePatient.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnDeletePatient.Name = "btnDeletePatient";
            this.btnDeletePatient.Text = "حذف بیمار";
            this.btnDeletePatient.Click += new System.EventHandler(this.btnDeleteCurrentPatient_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnRefresh.Image = global::Sepehr.Forms.Admission.Properties.Resources.Refresh;
            this.btnRefresh.ImagePaddingHorizontal = 8;
            this.btnRefresh.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F5);
            this.btnRefresh.Text = "بازخوانی (F5)";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSchList
            // 
            this.btnSchList.BeginGroup = true;
            this.btnSchList.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnSchList.ForeColor = System.Drawing.Color.Blue;
            this.btnSchList.Image = global::Sepehr.Forms.Admission.Properties.Resources.SchSearchPatSch;
            this.btnSchList.ImagePaddingHorizontal = 8;
            this.btnSchList.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnSchList.Name = "btnSchList";
            this.btnSchList.Text = "نوبتهای\r\nبیمار";
            this.btnSchList.Click += new System.EventHandler(this.btnSchList_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnHelp.Image = global::Sepehr.Forms.Admission.Properties.Resources.HelpMed;
            this.btnHelp.ImagePaddingHorizontal = 8;
            this.btnHelp.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.RibbonWordWrap = false;
            this.btnHelp.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F1);
            this.btnHelp.Text = "راهنمای\r\nفرمان ها";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnNextTab
            // 
            this.btnNextTab.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnNextTab.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnNextTab.Location = new System.Drawing.Point(0, -30);
            this.btnNextTab.Name = "btnNextTab";
            this.btnNextTab.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlQ);
            this.btnNextTab.Size = new System.Drawing.Size(75, 23);
            this.btnNextTab.TabIndex = 3;
            this.btnNextTab.TabStop = false;
            this.btnNextTab.Text = "نوار بعدی";
            this.btnNextTab.Click += new System.EventHandler(this.btnNextTab_Click);
            // 
            // frmPatients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 452);
            this.Controls.Add(this.btnNextTab);
            this.Controls.Add(this.ExpReferrals);
            this.Controls.Add(this.TabCtrlPatientData);
            this.Controls.Add(this.RibbonBarNavigation);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 480);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 270);
            this.Name = "frmPatients";
            this.Opacity = 0.01;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "بیماران - پرونده بیمار";
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.ExpReferrals.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmsPatients)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TabCtrlPatientData)).EndInit();
            this.TabCtrlPatientData.ResumeLayout(false);
            this.TabPanelBasicData.ResumeLayout(false);
            this.TabPanelBasicData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAgeMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAgeYear)).EndInit();
            this.PanelMaritualStatus.ResumeLayout(false);
            this.PanelMaritualStatus.PerformLayout();
            this.PanelGender.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtAgeDay)).EndInit();
            this.TabPanelContactData.ResumeLayout(false);
            this.TabPanelContactData.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX txtFirstName;
        private System.Windows.Forms.RadioButton cBoxFemale;
        private System.Windows.Forms.RadioButton cBoxMale;
        private DevComponents.DotNetBar.Controls.TextBoxX txtLastName;
        private Negar.PersianCalendar.UI.Controls.PersianDatePicker DateInputBirthDate;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTel1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTel2;
        private DevComponents.DotNetBar.RibbonBar RibbonBarNavigation;
        private DevComponents.DotNetBar.ExpandablePanel ExpReferrals;
        private DevComponents.DotNetBar.ButtonItem cmsdgvData;
        private DevComponents.DotNetBar.ButtonItem btnShowAdmit;
        private DevComponents.DotNetBar.ButtonItem btnShowAccount;
        private DevComponents.DotNetBar.ButtonItem btnShowDocuments;
        private DevComponents.DotNetBar.ButtonItem btnPrint;
        private DevComponents.DotNetBar.SliderItem sliderPrintCount;
        private DevComponents.DotNetBar.ButtonItem btnPrintTemplate;
        private DevComponents.DotNetBar.ButtonItem btnPrintPreview;
        private DevComponents.DotNetBar.ButtonItem btnRemoveRef;
        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        private DevComponents.DotNetBar.ContextMenuBar cmsPatients;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvData;
        private DevComponents.DotNetBar.TabControl TabCtrlPatientData;
        private DevComponents.DotNetBar.TabControlPanel TabPanelBasicData;
        private DevComponents.DotNetBar.ButtonX btnShowEnglishLastName;
        private DevComponents.DotNetBar.ButtonX btnShowEnglishFirstName;
        private DevComponents.Editors.IntegerInput txtAgeYear;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxEnterPatAge;
        private System.Windows.Forms.Panel PanelMaritualStatus;
        private System.Windows.Forms.RadioButton cboxSingle;
        private System.Windows.Forms.RadioButton cBoxMaried;
        private System.Windows.Forms.Panel PanelGender;
        private DevComponents.DotNetBar.LabelX lblFirstName;
        private DevComponents.DotNetBar.LabelX lblLastName;
        private DevComponents.DotNetBar.LabelX lblGender;
        private DevComponents.DotNetBar.LabelX lblBirthDate;
        private DevComponents.DotNetBar.LabelX lblMaritualStatus;
        private DevComponents.DotNetBar.LabelX lblFatherName;
        private DevComponents.DotNetBar.LabelX lblNationalCode;
        private DevComponents.DotNetBar.LabelX lblNationalID;
        private DevComponents.DotNetBar.LabelX lblBirthLocation;
        private DevComponents.DotNetBar.LabelX lblOccupation;
        private DevComponents.DotNetBar.Controls.TextBoxX txtBirthLocation;
        private DevComponents.DotNetBar.Controls.TextBoxX txtFatherName;
        private System.Windows.Forms.ComboBox cboJob;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNationalCode;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNationalID;
        private DevComponents.DotNetBar.TabItem TabBasicData;
        private DevComponents.DotNetBar.TabControlPanel TabPanelContactData;
        private System.Windows.Forms.ComboBox cboCountry;
        private DevComponents.DotNetBar.LabelX lblEmail;
        private DevComponents.DotNetBar.LabelX lblState;
        private DevComponents.DotNetBar.LabelX lblTel2;
        private DevComponents.DotNetBar.LabelX lblAddress;
        private DevComponents.DotNetBar.LabelX lblCity;
        private DevComponents.DotNetBar.LabelX lblCountry;
        private DevComponents.DotNetBar.LabelX lblZipCode;
        private DevComponents.DotNetBar.LabelX lblTel1;
        private System.Windows.Forms.ComboBox cboCity;
        private System.Windows.Forms.ComboBox cboState;
        private DevComponents.DotNetBar.Controls.TextBoxX txtZipCode;
        private DevComponents.DotNetBar.Controls.TextBoxX txtEmail;
        private DevComponents.DotNetBar.Controls.TextBoxX txtAddress;
        private DevComponents.DotNetBar.TabItem TabContactData;
        private DevComponents.DotNetBar.TabControlPanel TabPanelAddInData;
        private DevComponents.DotNetBar.TabItem TabAddInData;
        private DevComponents.DotNetBar.ButtonItem btnNewPatient;
        private DevComponents.DotNetBar.ButtonItem btnNewReferral;
        private DevComponents.DotNetBar.ButtonItem btnPrevPatient;
        private DevComponents.DotNetBar.ItemContainer iContainerPatientID;
        private DevComponents.DotNetBar.LabelItem lblPatientID;
        private DevComponents.DotNetBar.ItemContainer iContainerPatientIDTextBox;
        private DevComponents.DotNetBar.TextBoxItem txtPatientID;
        private DevComponents.DotNetBar.ButtonItem btnNextPatient;
        private DevComponents.DotNetBar.ButtonItem btnRefresh;
        private DevComponents.DotNetBar.ButtonItem btnEditMode;
        private DevComponents.DotNetBar.ButtonItem btnDeletePatient;
        private DevComponents.DotNetBar.ButtonItem btnHelp;
        private DevComponents.DotNetBar.ItemContainer iContainerPrintTemplate;
        private DevComponents.DotNetBar.LabelItem lblPrintTemplate;
        private DevComponents.DotNetBar.ComboBoxItem cboPrintTemplates;
        private DevComponents.DotNetBar.ButtonItem btnFreePatient;
        private DevComponents.DotNetBar.ButtonX btnNextTab;
        private DevComponents.DotNetBar.ButtonItem btnSchList;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRow;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRefID;
        private Negar.PersianCalendar.UI.Controls.DataGridViewPersianDateTimePickerColumn ColumnRefDate;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColAdmitter;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPaymentStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRefDocsCount;
        private DevComponents.Editors.IntegerInput txtAgeMonth;
        private DevComponents.Editors.IntegerInput txtAgeDay;

    }
}