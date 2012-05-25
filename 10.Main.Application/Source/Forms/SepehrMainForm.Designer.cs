namespace Sepehr.Forms
{
    partial class frmSepehrMainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSepehrMainForm));
            this.cmsPatData = new DevComponents.DotNetBar.ContextMenuBar();
            this.cmsdgvPatData = new DevComponents.DotNetBar.ButtonItem();
            this.btnLastRef = new DevComponents.DotNetBar.ButtonItem();
            this.btnPatientFile = new DevComponents.DotNetBar.ButtonItem();
            this.btnNewRef = new DevComponents.DotNetBar.ButtonItem();
            this.btnLastAccount = new DevComponents.DotNetBar.ButtonItem();
            this.btnPrintBill = new DevComponents.DotNetBar.ButtonItem();
            this.lblPrintTemplate = new DevComponents.DotNetBar.LabelItem();
            this.iContainerBillTemplates = new DevComponents.DotNetBar.ItemContainer();
            this.cboPrintTemplates = new DevComponents.DotNetBar.ComboBoxItem();
            this.sliderPrintCount = new DevComponents.DotNetBar.SliderItem();
            this.btnPrintBillLastRef = new DevComponents.DotNetBar.ButtonItem();
            this.btnPrintBillAllRef = new DevComponents.DotNetBar.ButtonItem();
            this.btnDicomImages = new DevComponents.DotNetBar.ButtonItem();
            this.btnLastDicomImage = new DevComponents.DotNetBar.ButtonItem();
            this.btnManageDoc = new DevComponents.DotNetBar.ButtonItem();
            this.btnEditLastDoc = new DevComponents.DotNetBar.ButtonItem();
            this.btnNewDoc = new DevComponents.DotNetBar.ButtonItem();
            this.btnPrintRefDoc = new DevComponents.DotNetBar.ButtonItem();
            this.btnPrintLastRefDoc = new DevComponents.DotNetBar.ButtonItem();
            this.btnPrintAllRefDoc = new DevComponents.DotNetBar.ButtonItem();
            this.btnExportPatDocuments = new DevComponents.DotNetBar.ButtonItem();
            this.btnSendSMS = new DevComponents.DotNetBar.ButtonItem();
            this.btnDeletePatient = new DevComponents.DotNetBar.ButtonItem();
            this.barStatus = new DevComponents.DotNetBar.Bar();
            this.iContainerCurrentUserName = new DevComponents.DotNetBar.ItemContainer();
            this.lblCurrentUserName = new DevComponents.DotNetBar.LabelItem();
            this.txtCurrentUserName = new DevComponents.DotNetBar.LabelItem();
            this.iContainerDbConnection = new DevComponents.DotNetBar.ItemContainer();
            this.lblCSName = new DevComponents.DotNetBar.LabelItem();
            this.txtCSName = new DevComponents.DotNetBar.LabelItem();
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.BWFormThread = new System.ComponentModel.BackgroundWorker();
            this.dgvPatData = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ColRow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPatientID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColGender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRefCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPersianRefDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RBarSearchPatients = new DevComponents.DotNetBar.RibbonBar();
            this.btnPrevPatient = new DevComponents.DotNetBar.ButtonItem();
            this.iContainerPatientID = new DevComponents.DotNetBar.ItemContainer();
            this.itemContainer2 = new DevComponents.DotNetBar.ItemContainer();
            this.cBoxSearchByPatientID = new DevComponents.DotNetBar.CheckBoxItem();
            this.lblSearchByPatientID = new DevComponents.DotNetBar.LabelItem();
            this.itemContainer3 = new DevComponents.DotNetBar.ItemContainer();
            this.cBoxSearchByRefID = new DevComponents.DotNetBar.CheckBoxItem();
            this.lblSearchByRefID = new DevComponents.DotNetBar.LabelItem();
            this.iContainerPatientIDTextBox = new DevComponents.DotNetBar.ItemContainer();
            this.txtPatientID = new DevComponents.DotNetBar.TextBoxItem();
            this.btnNextPatient = new DevComponents.DotNetBar.ButtonItem();
            this.iContainerSearchPatient = new DevComponents.DotNetBar.ItemContainer();
            this.iContainerName = new DevComponents.DotNetBar.ItemContainer();
            this.lblPName = new DevComponents.DotNetBar.LabelItem();
            this.txtFName = new DevComponents.DotNetBar.TextBoxItem();
            this.iContainerLName = new DevComponents.DotNetBar.ItemContainer();
            this.lblPLName = new DevComponents.DotNetBar.LabelItem();
            this.txtLName = new DevComponents.DotNetBar.TextBoxItem();
            this.iContainerAge = new DevComponents.DotNetBar.ItemContainer();
            this.lblAge = new DevComponents.DotNetBar.LabelItem();
            this.txtAge = new DevComponents.DotNetBar.TextBoxItem();
            this.iContainerDays = new DevComponents.DotNetBar.ItemContainer();
            this.btnToday = new DevComponents.DotNetBar.ButtonItem();
            this.btnYesterday = new DevComponents.DotNetBar.ButtonItem();
            this.btnSearch = new DevComponents.DotNetBar.ButtonItem();
            this.btnAdvancedSearch = new DevComponents.DotNetBar.ButtonItem();
            this.btnClearGrid = new DevComponents.DotNetBar.ButtonItem();
            this.btnPrintGrid = new DevComponents.DotNetBar.ButtonItem();
            this.btnSearchHelp = new DevComponents.DotNetBar.ButtonItem();
            this.FormMenu = new DevComponents.DotNetBar.RibbonBar();
            this.btnLastPatients = new DevComponents.DotNetBar.ButtonItem();
            this.IContainerStart = new DevComponents.DotNetBar.ItemContainer();
            this.iContainerStartButton = new DevComponents.DotNetBar.ItemContainer();
            this.iContainerRecentPatients = new DevComponents.DotNetBar.ItemContainer();
            this.lblRecentPatients = new DevComponents.DotNetBar.LabelItem();
            this.btnFile = new DevComponents.DotNetBar.ButtonItem();
            this.btnAppointments = new DevComponents.DotNetBar.ButtonItem();
            this.btnNewPatient = new DevComponents.DotNetBar.ButtonItem();
            this.btnNewPatientRef = new DevComponents.DotNetBar.ButtonItem();
            this.btnCashManage = new DevComponents.DotNetBar.ButtonItem();
            this.btnCashPatients = new DevComponents.DotNetBar.ButtonItem();
            this.btnCashReport = new DevComponents.DotNetBar.ButtonItem();
            this.btnDocumentPatients = new DevComponents.DotNetBar.ButtonItem();
            this.btnMessagesDashboard = new DevComponents.DotNetBar.ButtonItem();
            this.btnReport = new DevComponents.DotNetBar.ButtonItem();
            this.btnGeneralReports = new DevComponents.DotNetBar.ButtonItem();
            this.btnR1 = new DevComponents.DotNetBar.ButtonItem();
            this.btnR1_1 = new DevComponents.DotNetBar.ButtonItem();
            this.btnR1_2 = new DevComponents.DotNetBar.ButtonItem();
            this.btnR1_3 = new DevComponents.DotNetBar.ButtonItem();
            this.btnR1_4 = new DevComponents.DotNetBar.ButtonItem();
            this.btnR2 = new DevComponents.DotNetBar.ButtonItem();
            this.btnR2_1 = new DevComponents.DotNetBar.ButtonItem();
            this.btnR2_2 = new DevComponents.DotNetBar.ButtonItem();
            this.btnR3 = new DevComponents.DotNetBar.ButtonItem();
            this.btnR3_1 = new DevComponents.DotNetBar.ButtonItem();
            this.btnR3_2 = new DevComponents.DotNetBar.ButtonItem();
            this.btnR4 = new DevComponents.DotNetBar.ButtonItem();
            this.btnR4_1 = new DevComponents.DotNetBar.ButtonItem();
            this.btnR4_2 = new DevComponents.DotNetBar.ButtonItem();
            this.btnR4_3 = new DevComponents.DotNetBar.ButtonItem();
            this.btnR4_4 = new DevComponents.DotNetBar.ButtonItem();
            this.btnR5 = new DevComponents.DotNetBar.ButtonItem();
            this.btnR5_1 = new DevComponents.DotNetBar.ButtonItem();
            this.btnR5_2 = new DevComponents.DotNetBar.ButtonItem();
            this.btnR5_3 = new DevComponents.DotNetBar.ButtonItem();
            this.btnR5_4 = new DevComponents.DotNetBar.ButtonItem();
            this.btnR5_5 = new DevComponents.DotNetBar.ButtonItem();
            this.btnR5_10 = new DevComponents.DotNetBar.ButtonItem();
            this.btnR5_11 = new DevComponents.DotNetBar.ButtonItem();
            this.btnR5_12 = new DevComponents.DotNetBar.ButtonItem();
            this.btnR5_13 = new DevComponents.DotNetBar.ButtonItem();
            this.btnR6 = new DevComponents.DotNetBar.ButtonItem();
            this.btnR6_1 = new DevComponents.DotNetBar.ButtonItem();
            this.btnR6_2 = new DevComponents.DotNetBar.ButtonItem();
            this.btnR6_3 = new DevComponents.DotNetBar.ButtonItem();
            this.btnR8 = new DevComponents.DotNetBar.ButtonItem();
            this.btnR1_3_1 = new DevComponents.DotNetBar.ButtonItem();
            this.btnR1_3_2 = new DevComponents.DotNetBar.ButtonItem();
            this.btnR1_3_3 = new DevComponents.DotNetBar.ButtonItem();
            this.btnR1_3_4 = new DevComponents.DotNetBar.ButtonItem();
            this.btnDesignableReports = new DevComponents.DotNetBar.ButtonItem();
            this.btnSpecialReports = new DevComponents.DotNetBar.ButtonItem();
            this.btnSettings = new DevComponents.DotNetBar.ButtonItem();
            this.btnChangePassword = new DevComponents.DotNetBar.ButtonItem();
            this.btnUserSettings = new DevComponents.DotNetBar.ButtonItem();
            this.btnSecuritySettings = new DevComponents.DotNetBar.ButtonItem();
            this.btnUsers = new DevComponents.DotNetBar.ButtonItem();
            this.btnGroups = new DevComponents.DotNetBar.ButtonItem();
            this.btnUsersGrouping = new DevComponents.DotNetBar.ButtonItem();
            this.btnACLManage = new DevComponents.DotNetBar.ButtonItem();
            this.btnSchSettings = new DevComponents.DotNetBar.ButtonItem();
            this.btnAppointmentsDef = new DevComponents.DotNetBar.ButtonItem();
            this.btnSchAddinFields = new DevComponents.DotNetBar.ButtonItem();
            this.btnPatientsSettings = new DevComponents.DotNetBar.ButtonItem();
            this.btnPatAddinData = new DevComponents.DotNetBar.ButtonItem();
            this.btnJobs = new DevComponents.DotNetBar.ButtonItem();
            this.btnLocations = new DevComponents.DotNetBar.ButtonItem();
            this.btnCountries = new DevComponents.DotNetBar.ButtonItem();
            this.btnStates = new DevComponents.DotNetBar.ButtonItem();
            this.btnCities = new DevComponents.DotNetBar.ButtonItem();
            this.btnNamesBank = new DevComponents.DotNetBar.ButtonItem();
            this.btnRefSettings = new DevComponents.DotNetBar.ButtonItem();
            this.btnPerformers = new DevComponents.DotNetBar.ButtonItem();
            this.btnPhysiciansSpecs = new DevComponents.DotNetBar.ButtonItem();
            this.btnPhysicians = new DevComponents.DotNetBar.ButtonItem();
            this.btnRefAddinData = new DevComponents.DotNetBar.ButtonItem();
            this.btnRefStatus = new DevComponents.DotNetBar.ButtonItem();
            this.btnServInsSettings = new DevComponents.DotNetBar.ButtonItem();
            this.btnServiceTypes = new DevComponents.DotNetBar.ButtonItem();
            this.btnServiceGroups = new DevComponents.DotNetBar.ButtonItem();
            this.btnServices = new DevComponents.DotNetBar.ButtonItem();
            this.btnServiceGrouping = new DevComponents.DotNetBar.ButtonItem();
            this.btnDefaultServicePerformers = new DevComponents.DotNetBar.ButtonItem();
            this.btnInsurances = new DevComponents.DotNetBar.ButtonItem();
            this.btnAccountCashSettings = new DevComponents.DotNetBar.ButtonItem();
            this.btnCostDiscountTypes = new DevComponents.DotNetBar.ButtonItem();
            this.btnCostDiscountExcludedUsers = new DevComponents.DotNetBar.ButtonItem();
            this.btnBanks = new DevComponents.DotNetBar.ButtonItem();
            this.btnCashes = new DevComponents.DotNetBar.ButtonItem();
            this.btnCashCashiers = new DevComponents.DotNetBar.ButtonItem();
            this.btnDocSettings = new DevComponents.DotNetBar.ButtonItem();
            this.btnDocTemplates = new DevComponents.DotNetBar.ButtonItem();
            this.btnDocTexts = new DevComponents.DotNetBar.ButtonItem();
            this.btnDocTypes = new DevComponents.DotNetBar.ButtonItem();
            this.btnBillTemplatesSettings = new DevComponents.DotNetBar.ButtonItem();
            this.btnBillTemplates = new DevComponents.DotNetBar.ButtonItem();
            this.btnBillTemplatesAccess = new DevComponents.DotNetBar.ButtonItem();
            this.btnBillServCatExclude = new DevComponents.DotNetBar.ButtonItem();
            this.btnBillDefaultPrinter = new DevComponents.DotNetBar.ButtonItem();
            this.btnPacsManage = new DevComponents.DotNetBar.ButtonItem();
            this.btnPACSModalities = new DevComponents.DotNetBar.ButtonItem();
            this.btnPACSServicesModalities = new DevComponents.DotNetBar.ButtonItem();
            this.btnPACSStudies = new DevComponents.DotNetBar.ButtonItem();
            this.btnPACSServicesStudies = new DevComponents.DotNetBar.ButtonItem();
            this.btnMessagesSettings = new DevComponents.DotNetBar.ButtonItem();
            this.btnDocMessageTemplate = new DevComponents.DotNetBar.ButtonItem();
            this.btnTools = new DevComponents.DotNetBar.ButtonItem();
            this.btnBackup = new DevComponents.DotNetBar.ButtonItem();
            this.btnRestore = new DevComponents.DotNetBar.ButtonItem();
            this.btnRebuildDataBase = new DevComponents.DotNetBar.ButtonItem();
            this.btnDeleteData = new DevComponents.DotNetBar.ButtonItem();
            this.btnEventsViewer = new DevComponents.DotNetBar.ButtonItem();
            this.btnHelp = new DevComponents.DotNetBar.ButtonItem();
            this.btnUserGuide = new DevComponents.DotNetBar.ButtonItem();
            this.btnFaq = new DevComponents.DotNetBar.ButtonItem();
            this.btnLicenseList = new DevComponents.DotNetBar.ButtonItem();
            this.btnContactUs = new DevComponents.DotNetBar.ButtonItem();
            this.btnAbout = new DevComponents.DotNetBar.ButtonItem();
            this.btnRefreshSettings = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem3 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem4 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem6 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem7 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem8 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem11 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem12 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem13 = new DevComponents.DotNetBar.ButtonItem();
            this.dgvRefData = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.cmsRefData = new DevComponents.DotNetBar.ContextMenuBar();
            this.cmsdgvRefData = new DevComponents.DotNetBar.ButtonItem();
            this.btnRefAdmit = new DevComponents.DotNetBar.ButtonItem();
            this.btnRefAccount = new DevComponents.DotNetBar.ButtonItem();
            this.btnRefBills = new DevComponents.DotNetBar.ButtonItem();
            this.lblRefBill = new DevComponents.DotNetBar.LabelItem();
            this.iContainerRefBill = new DevComponents.DotNetBar.ItemContainer();
            this.cboRefBill = new DevComponents.DotNetBar.ComboBoxItem();
            this.sliderRefBillQty = new DevComponents.DotNetBar.SliderItem();
            this.btnRefBillPrint = new DevComponents.DotNetBar.ButtonItem();
            this.btnRefDocs = new DevComponents.DotNetBar.ButtonItem();
            this.btnRefLastDoc = new DevComponents.DotNetBar.ButtonItem();
            this.btnRefNewDoc = new DevComponents.DotNetBar.ButtonItem();
            this.btnRefPrintDoc = new DevComponents.DotNetBar.ButtonItem();
            this.btnRefLastDocPrint = new DevComponents.DotNetBar.ButtonItem();
            this.btnRefAllDocPrint = new DevComponents.DotNetBar.ButtonItem();
            this.btnRefRemove = new DevComponents.DotNetBar.ButtonItem();
            this.ColRefRow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRefNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRefDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRefIns1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRefIns2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRefPeriod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRefServCat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRefDocCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRefLastDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIns1PriceTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIns1PartTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIns1PatientPart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIns2PriceTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIns2PartTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.cmsPatData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRefData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmsRefData)).BeginInit();
            this.SuspendLayout();
            // 
            // cmsPatData
            // 
            this.cmsPatData.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmsPatData.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.cmsdgvPatData});
            this.cmsPatData.Location = new System.Drawing.Point(644, 135);
            this.cmsPatData.Name = "cmsPatData";
            this.cmsPatData.Size = new System.Drawing.Size(136, 25);
            this.cmsPatData.Stretch = true;
            this.cmsPatData.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.cmsPatData.TabIndex = 11;
            this.cmsPatData.TabStop = false;
            this.cmsPatData.Text = "منو";
            // 
            // cmsdgvPatData
            // 
            this.cmsdgvPatData.AutoExpandOnClick = true;
            this.cmsdgvPatData.ImagePaddingHorizontal = 8;
            this.cmsdgvPatData.Name = "cmsdgvPatData";
            this.cmsdgvPatData.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnLastRef,
            this.btnPatientFile,
            this.btnNewRef,
            this.btnLastAccount,
            this.btnPrintBill,
            this.btnDicomImages,
            this.btnLastDicomImage,
            this.btnManageDoc,
            this.btnEditLastDoc,
            this.btnNewDoc,
            this.btnPrintRefDoc,
            this.btnSendSMS,
            this.btnDeletePatient});
            this.cmsdgvPatData.SubItemsExpandWidth = 15;
            this.cmsdgvPatData.Text = "منوی جدول بیماران";
            this.cmsdgvPatData.Visible = false;
            this.cmsdgvPatData.PopupOpen += new DevComponents.DotNetBar.DotNetBarManager.PopupOpenEventHandler(this.cmsdgvData_PopupOpen);
            // 
            // btnLastRef
            // 
            this.btnLastRef.ForeColor = System.Drawing.Color.Blue;
            this.btnLastRef.Image = global::Sepehr.Properties.Resources.PatLastRef;
            this.btnLastRef.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnLastRef.ImagePaddingHorizontal = 8;
            this.btnLastRef.Name = "btnLastRef";
            this.btnLastRef.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F4);
            this.btnLastRef.Text = "<b>آخرین مراجعه...</b>\r\n<div></div>\r\n<font color=\"#000000\">نمایش آخرین مراجعه.</f" +
                "ont>";
            this.btnLastRef.Click += new System.EventHandler(this.btnLastRef_Click);
            // 
            // btnPatientFile
            // 
            this.btnPatientFile.ForeColor = System.Drawing.Color.Blue;
            this.btnPatientFile.Image = global::Sepehr.Properties.Resources.PatientFile;
            this.btnPatientFile.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnPatientFile.ImagePaddingHorizontal = 8;
            this.btnPatientFile.Name = "btnPatientFile";
            this.btnPatientFile.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F3);
            this.btnPatientFile.Text = "<b>پرونده بیمار...</b>\r\n<div></div>\r\n<font color=\"#000000\">مشاهده پرونده بیمار.</" +
                "font>";
            this.btnPatientFile.Click += new System.EventHandler(this.btnPatientFile_Click);
            // 
            // btnNewRef
            // 
            this.btnNewRef.ForeColor = System.Drawing.Color.Blue;
            this.btnNewRef.Image = global::Sepehr.Properties.Resources.NewRef;
            this.btnNewRef.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnNewRef.ImagePaddingHorizontal = 8;
            this.btnNewRef.Name = "btnNewRef";
            this.btnNewRef.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F2);
            this.btnNewRef.Text = "<b>مراجعه جدید...</b>\r\n<div></div>\r\n<font color=\"#000000\">ثبت مراجعه جدید بیمار.<" +
                "/font>";
            this.btnNewRef.Click += new System.EventHandler(this.btnNewRef_Click);
            // 
            // btnLastAccount
            // 
            this.btnLastAccount.BeginGroup = true;
            this.btnLastAccount.ForeColor = System.Drawing.Color.Green;
            this.btnLastAccount.Image = global::Sepehr.Properties.Resources.RefAccount;
            this.btnLastAccount.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnLastAccount.ImagePaddingHorizontal = 8;
            this.btnLastAccount.Name = "btnLastAccount";
            this.btnLastAccount.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F5);
            this.btnLastAccount.Text = "<b>آخرین حساب...</b>\r\n<div></div>\r\n<font color=\"#000000\">حساب آخرین مراجعه.</font" +
                ">";
            this.btnLastAccount.Click += new System.EventHandler(this.btnLastAccount_Click);
            // 
            // btnPrintBill
            // 
            this.btnPrintBill.BeginGroup = true;
            this.btnPrintBill.ForeColor = System.Drawing.Color.Black;
            this.btnPrintBill.Image = global::Sepehr.Properties.Resources.PrintBill;
            this.btnPrintBill.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnPrintBill.ImagePaddingHorizontal = 8;
            this.btnPrintBill.Name = "btnPrintBill";
            this.btnPrintBill.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.lblPrintTemplate,
            this.iContainerBillTemplates,
            this.sliderPrintCount,
            this.btnPrintBillLastRef,
            this.btnPrintBillAllRef});
            this.btnPrintBill.Text = "<b>چاپ قبض</b>\r\n<div></div>\r\n<font color=\"#000000\">چاپ قبوض مراجعات بیمار.</font>" +
                "";
            // 
            // lblPrintTemplate
            // 
            this.lblPrintTemplate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblPrintTemplate.Name = "lblPrintTemplate";
            this.lblPrintTemplate.Text = "قالب قبض:";
            // 
            // iContainerBillTemplates
            // 
            this.iContainerBillTemplates.Name = "iContainerBillTemplates";
            this.iContainerBillTemplates.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.cboPrintTemplates});
            // 
            // cboPrintTemplates
            // 
            this.cboPrintTemplates.CanCustomize = false;
            this.cboPrintTemplates.ComboWidth = 110;
            this.cboPrintTemplates.DropDownHeight = 50;
            this.cboPrintTemplates.DropDownWidth = 50;
            this.cboPrintTemplates.ItemHeight = 17;
            this.cboPrintTemplates.Name = "cboPrintTemplates";
            this.cboPrintTemplates.ShowSubItems = false;
            this.cboPrintTemplates.Stretch = true;
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
            // btnPrintBillLastRef
            // 
            this.btnPrintBillLastRef.BeginGroup = true;
            this.btnPrintBillLastRef.FontBold = true;
            this.btnPrintBillLastRef.HotFontBold = true;
            this.btnPrintBillLastRef.Image = global::Sepehr.Properties.Resources.PrintBill;
            this.btnPrintBillLastRef.ImagePaddingHorizontal = 8;
            this.btnPrintBillLastRef.Name = "btnPrintBillLastRef";
            this.btnPrintBillLastRef.Text = " چاپ آخرین\r\nمراجعه بیمار";
            this.btnPrintBillLastRef.Click += new System.EventHandler(this.btnPrintBillLastRef_Click);
            // 
            // btnPrintBillAllRef
            // 
            this.btnPrintBillAllRef.FontBold = true;
            this.btnPrintBillAllRef.HotFontBold = true;
            this.btnPrintBillAllRef.Image = global::Sepehr.Properties.Resources.PrintGrid;
            this.btnPrintBillAllRef.ImagePaddingHorizontal = 8;
            this.btnPrintBillAllRef.Name = "btnPrintBillAllRef";
            this.btnPrintBillAllRef.Text = "چاپ همه\r\nمراجعات";
            this.btnPrintBillAllRef.Click += new System.EventHandler(this.btnPrintBillAllRef_Click);
            // 
            // btnDicomImages
            // 
            this.btnDicomImages.BeginGroup = true;
            this.btnDicomImages.ForeColor = System.Drawing.Color.Olive;
            this.btnDicomImages.Image = global::Sepehr.Properties.Resources.Dicom;
            this.btnDicomImages.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnDicomImages.ImagePaddingHorizontal = 8;
            this.btnDicomImages.Name = "btnDicomImages";
            this.btnDicomImages.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F6);
            this.btnDicomImages.Text = "<b>تصاویر پزشكی...</b>\r\n<div></div>\r\n<font color=\"#000000\">نمایش لیست تصاویر مراج" +
                "عات.</font>";
            this.btnDicomImages.Visible = false;
            // 
            // btnLastDicomImage
            // 
            this.btnLastDicomImage.ForeColor = System.Drawing.Color.Olive;
            this.btnLastDicomImage.Image = global::Sepehr.Properties.Resources.Dicom;
            this.btnLastDicomImage.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnLastDicomImage.ImagePaddingHorizontal = 8;
            this.btnLastDicomImage.Name = "btnLastDicomImage";
            this.btnLastDicomImage.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F7);
            this.btnLastDicomImage.Text = "<b>آخرین تصویر پزشكی...</b>\r\n<div></div>\r\n<font color=\"#000000\">نمایش آخرین تصویر" +
                " ثبت شده.</font>";
            this.btnLastDicomImage.Visible = false;
            this.btnLastDicomImage.Click += new System.EventHandler(this.btnLastDicomImage_Click);
            // 
            // btnManageDoc
            // 
            this.btnManageDoc.BeginGroup = true;
            this.btnManageDoc.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnManageDoc.Image = global::Sepehr.Properties.Resources.RefDocuments;
            this.btnManageDoc.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnManageDoc.ImagePaddingHorizontal = 8;
            this.btnManageDoc.Name = "btnManageDoc";
            this.btnManageDoc.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnManageDoc.Text = "<b>مدیریت مدارک...</b>\r\n<div></div>\r\n<font color=\"#000000\">مدیریت مدارك قبلی مراج" +
                "عات.</font>";
            this.btnManageDoc.Click += new System.EventHandler(this.btnManageDoc_Click);
            // 
            // btnEditLastDoc
            // 
            this.btnEditLastDoc.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnEditLastDoc.Image = global::Sepehr.Properties.Resources.RefLastDoc;
            this.btnEditLastDoc.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnEditLastDoc.ImagePaddingHorizontal = 8;
            this.btnEditLastDoc.Name = "btnEditLastDoc";
            this.btnEditLastDoc.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F9);
            this.btnEditLastDoc.Text = "<b>ویرایش آخرین جواب...</b>\r\n<div></div>\r\n<font color=\"#000000\">ویرایش آخرین جواب" +
                " ثبت شده.</font>";
            this.btnEditLastDoc.Click += new System.EventHandler(this.btnLastDoc_Click);
            // 
            // btnNewDoc
            // 
            this.btnNewDoc.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnNewDoc.Image = global::Sepehr.Properties.Resources.DocumentAdd;
            this.btnNewDoc.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnNewDoc.ImagePaddingHorizontal = 8;
            this.btnNewDoc.Name = "btnNewDoc";
            this.btnNewDoc.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F11);
            this.btnNewDoc.Text = "<b>جوابدهی جدید...</b>\r\n<div></div>\r\n<font color=\"#000000\">جوابدهی برای آخرین مرا" +
                "جعه.</font>";
            this.btnNewDoc.Click += new System.EventHandler(this.btnNewDoc_Click);
            // 
            // btnPrintRefDoc
            // 
            this.btnPrintRefDoc.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnPrintRefDoc.Image = global::Sepehr.Properties.Resources.PrintGrid;
            this.btnPrintRefDoc.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnPrintRefDoc.ImagePaddingHorizontal = 8;
            this.btnPrintRefDoc.Name = "btnPrintRefDoc";
            this.btnPrintRefDoc.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnPrintLastRefDoc,
            this.btnPrintAllRefDoc,
            this.btnExportPatDocuments});
            this.btnPrintRefDoc.Text = "<b>خروجی جواب</b>\r\n<div></div>\r\n<font color=\"#000000\">چاپ یا تولید فایل جواب های " +
                "بیمار.</font>";
            // 
            // btnPrintLastRefDoc
            // 
            this.btnPrintLastRefDoc.FontBold = true;
            this.btnPrintLastRefDoc.HotFontBold = true;
            this.btnPrintLastRefDoc.Image = global::Sepehr.Properties.Resources.PrintBill;
            this.btnPrintLastRefDoc.ImagePaddingHorizontal = 8;
            this.btnPrintLastRefDoc.Name = "btnPrintLastRefDoc";
            this.btnPrintLastRefDoc.Text = "چاپ آخرین\r\nجواب بیمار";
            this.btnPrintLastRefDoc.Click += new System.EventHandler(this.btnPrintLastRefDoc_Click);
            // 
            // btnPrintAllRefDoc
            // 
            this.btnPrintAllRefDoc.FontBold = true;
            this.btnPrintAllRefDoc.HotFontBold = true;
            this.btnPrintAllRefDoc.Image = global::Sepehr.Properties.Resources.PrintGrid;
            this.btnPrintAllRefDoc.ImagePaddingHorizontal = 8;
            this.btnPrintAllRefDoc.Name = "btnPrintAllRefDoc";
            this.btnPrintAllRefDoc.Text = "چاپ همه\r\nجواب ها";
            this.btnPrintAllRefDoc.Click += new System.EventHandler(this.btnPrintAllRefDoc_Click);
            // 
            // btnExportPatDocuments
            // 
            this.btnExportPatDocuments.BeginGroup = true;
            this.btnExportPatDocuments.FontBold = true;
            this.btnExportPatDocuments.HotFontBold = true;
            this.btnExportPatDocuments.Image = global::Sepehr.Properties.Resources.PrintBill;
            this.btnExportPatDocuments.ImagePaddingHorizontal = 8;
            this.btnExportPatDocuments.Name = "btnExportPatDocuments";
            this.btnExportPatDocuments.Text = "تولید خروجی\r\nجوابهای بیمار";
            this.btnExportPatDocuments.Click += new System.EventHandler(this.btnExportPatDocuments_Click);
            // 
            // btnSendSMS
            // 
            this.btnSendSMS.BeginGroup = true;
            this.btnSendSMS.CanCustomize = false;
            this.btnSendSMS.ForeColor = System.Drawing.Color.DarkOrchid;
            this.btnSendSMS.Image = global::Sepehr.Properties.Resources.SMS_Logo_2;
            this.btnSendSMS.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnSendSMS.ImagePaddingHorizontal = 8;
            this.btnSendSMS.Name = "btnSendSMS";
            this.btnSendSMS.Text = "<b>ارسال پیام</b>\r\n<div></div>\r\n<font color=\"#000000\">ارسال پیام با قالب پیش فرض." +
                "</font>";
            this.btnSendSMS.Click += new System.EventHandler(this.btnSendSMS_Click);
            // 
            // btnDeletePatient
            // 
            this.btnDeletePatient.BeginGroup = true;
            this.btnDeletePatient.CanCustomize = false;
            this.btnDeletePatient.ForeColor = System.Drawing.Color.Red;
            this.btnDeletePatient.Image = global::Sepehr.Properties.Resources.DeleteMed;
            this.btnDeletePatient.ImagePaddingHorizontal = 8;
            this.btnDeletePatient.Name = "btnDeletePatient";
            this.btnDeletePatient.Text = "<u><b>حذف بیمار</b></u>\r\n<div></div>\r\n<font color=\"#000000\">حذف كامل اطلاعات پرون" +
                "ده بیمار.</font>";
            this.btnDeletePatient.Click += new System.EventHandler(this.btnDeletePatient_Click);
            // 
            // barStatus
            // 
            this.barStatus.AccessibleDescription = "DotNetBar Bar (barStatus)";
            this.barStatus.AccessibleName = "DotNetBar Bar";
            this.barStatus.AccessibleRole = System.Windows.Forms.AccessibleRole.StatusBar;
            this.barStatus.BarType = DevComponents.DotNetBar.eBarType.StatusBar;
            this.barStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barStatus.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.barStatus.GrabHandleStyle = DevComponents.DotNetBar.eGrabHandleStyle.ResizeHandle;
            this.barStatus.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.iContainerCurrentUserName,
            this.iContainerDbConnection});
            this.barStatus.ItemSpacing = 2;
            this.barStatus.Location = new System.Drawing.Point(0, 547);
            this.barStatus.Name = "barStatus";
            this.barStatus.PaddingBottom = 5;
            this.barStatus.PaddingLeft = 0;
            this.barStatus.PaddingRight = 0;
            this.barStatus.PaddingTop = 6;
            this.barStatus.Size = new System.Drawing.Size(792, 26);
            this.barStatus.Stretch = true;
            this.barStatus.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.barStatus.TabIndex = 14;
            this.barStatus.TabStop = false;
            this.barStatus.Text = "barStatus";
            // 
            // iContainerCurrentUserName
            // 
            this.iContainerCurrentUserName.Name = "iContainerCurrentUserName";
            this.iContainerCurrentUserName.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.lblCurrentUserName,
            this.txtCurrentUserName});
            // 
            // lblCurrentUserName
            // 
            this.lblCurrentUserName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblCurrentUserName.ForeColor = System.Drawing.Color.Blue;
            this.lblCurrentUserName.Name = "lblCurrentUserName";
            this.lblCurrentUserName.PaddingRight = 3;
            this.lblCurrentUserName.Text = "نام كاربر جاری:";
            // 
            // txtCurrentUserName
            // 
            this.txtCurrentUserName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtCurrentUserName.ForeColor = System.Drawing.Color.Blue;
            this.txtCurrentUserName.Name = "txtCurrentUserName";
            this.txtCurrentUserName.Text = "نام كاربر جاری";
            // 
            // iContainerDbConnection
            // 
            this.iContainerDbConnection.Name = "iContainerDbConnection";
            this.iContainerDbConnection.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.lblCSName,
            this.txtCSName});
            // 
            // lblCSName
            // 
            this.lblCSName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblCSName.ForeColor = System.Drawing.Color.Black;
            this.lblCSName.Name = "lblCSName";
            this.lblCSName.PaddingRight = 3;
            this.lblCSName.Text = "-  نام اتصال سرور جاری:";
            // 
            // txtCSName
            // 
            this.txtCSName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtCSName.ForeColor = System.Drawing.Color.Black;
            this.txtCSName.Name = "txtCSName";
            this.txtCSName.Text = "نام اتصال جاری";
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            // 
            // BWFormThread
            // 
            this.BWFormThread.WorkerReportsProgress = true;
            this.BWFormThread.WorkerSupportsCancellation = true;
            this.BWFormThread.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BWFormThread_DoWork);
            this.BWFormThread.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BWFormThread_RunWorkerCompleted);
            // 
            // dgvPatData
            // 
            this.dgvPatData.AllowUserToAddRows = false;
            this.dgvPatData.AllowUserToDeleteRows = false;
            this.dgvPatData.AllowUserToOrderColumns = true;
            this.dgvPatData.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(255)))), ((int)(((byte)(210)))));
            this.dgvPatData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPatData.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(250)))));
            this.dgvPatData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPatData.CausesValidation = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPatData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPatData.ColumnHeadersHeight = 25;
            this.dgvPatData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPatData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColRow,
            this.ColPatientID,
            this.ColFullName,
            this.ColGender,
            this.ColAge,
            this.ColRefCount,
            this.ColPersianRefDate});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPatData.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvPatData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPatData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvPatData.Location = new System.Drawing.Point(0, 129);
            this.dgvPatData.Name = "dgvPatData";
            this.dgvPatData.ReadOnly = true;
            this.dgvPatData.RowHeadersVisible = false;
            this.dgvPatData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvPatData.RowTemplate.Height = 30;
            this.dgvPatData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPatData.Size = new System.Drawing.Size(792, 299);
            this.dgvPatData.StandardTab = true;
            this.dgvPatData.TabIndex = 1;
            this.dgvPatData.TabStop = false;
            this.dgvPatData.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPatData_CellMouseClick);
            this.dgvPatData.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Control_PreviewKeyDown);
            this.dgvPatData.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPatData_CellMouseDoubleClick);
            this.dgvPatData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvData_KeyDown);
            this.dgvPatData.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvPatData_RowStateChanged);
            // 
            // ColRow
            // 
            this.ColRow.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColRow.DataPropertyName = "RowID";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColRow.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColRow.HeaderText = "ردیف";
            this.ColRow.Name = "ColRow";
            this.ColRow.ReadOnly = true;
            this.ColRow.Width = 40;
            // 
            // ColPatientID
            // 
            this.ColPatientID.DataPropertyName = "PatientID";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("B Titr", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Navy;
            this.ColPatientID.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColPatientID.HeaderText = "كد بیمار";
            this.ColPatientID.Name = "ColPatientID";
            this.ColPatientID.ReadOnly = true;
            // 
            // ColFullName
            // 
            this.ColFullName.DataPropertyName = "PatientFullName";
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold);
            this.ColFullName.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColFullName.HeaderText = "نام بیمار";
            this.ColFullName.Name = "ColFullName";
            this.ColFullName.ReadOnly = true;
            this.ColFullName.Width = 150;
            // 
            // ColGender
            // 
            this.ColGender.DataPropertyName = "PatientGender";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Green;
            this.ColGender.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColGender.HeaderText = "جنسیت";
            this.ColGender.Name = "ColGender";
            this.ColGender.ReadOnly = true;
            this.ColGender.Width = 50;
            // 
            // ColAge
            // 
            this.ColAge.DataPropertyName = "PatientAge";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.ColAge.DefaultCellStyle = dataGridViewCellStyle7;
            this.ColAge.HeaderText = "سن";
            this.ColAge.Name = "ColAge";
            this.ColAge.ReadOnly = true;
            this.ColAge.Width = 35;
            // 
            // ColRefCount
            // 
            this.ColRefCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColRefCount.DataPropertyName = "RefCount";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Purple;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColRefCount.DefaultCellStyle = dataGridViewCellStyle8;
            this.ColRefCount.HeaderText = "مراجعه";
            this.ColRefCount.Name = "ColRefCount";
            this.ColRefCount.ReadOnly = true;
            this.ColRefCount.ToolTipText = "تعداد مراجعه";
            this.ColRefCount.Width = 50;
            // 
            // ColPersianRefDate
            // 
            this.ColPersianRefDate.DataPropertyName = "LastRefPDateTime";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle9.NullValue = "\"بدون مراجعه\"";
            this.ColPersianRefDate.DefaultCellStyle = dataGridViewCellStyle9;
            this.ColPersianRefDate.HeaderText = "آخرین مراجعه";
            this.ColPersianRefDate.Name = "ColPersianRefDate";
            this.ColPersianRefDate.ReadOnly = true;
            this.ColPersianRefDate.ToolTipText = "تاریخ آخرین مراجعه";
            // 
            // RBarSearchPatients
            // 
            this.RBarSearchPatients.AutoOverflowEnabled = false;
            this.RBarSearchPatients.Dock = System.Windows.Forms.DockStyle.Top;
            this.RBarSearchPatients.FadeEffect = false;
            this.RBarSearchPatients.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.RBarSearchPatients.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnPrevPatient,
            this.iContainerPatientID,
            this.btnNextPatient,
            this.iContainerSearchPatient,
            this.iContainerDays,
            this.btnSearch,
            this.btnClearGrid,
            this.btnPrintGrid,
            this.btnSearchHelp});
            this.RBarSearchPatients.ItemSpacing = 2;
            this.RBarSearchPatients.KeyTipsFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.RBarSearchPatients.Location = new System.Drawing.Point(0, 51);
            this.RBarSearchPatients.Name = "RBarSearchPatients";
            this.RBarSearchPatients.Size = new System.Drawing.Size(792, 78);
            this.RBarSearchPatients.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.RBarSearchPatients.TabIndex = 0;
            this.RBarSearchPatients.Text = "پنل جستجوی بیماران ثبت شده";
            this.RBarSearchPatients.TitleVisible = false;
            // 
            // btnPrevPatient
            // 
            this.btnPrevPatient.ForeColor = System.Drawing.Color.Green;
            this.btnPrevPatient.HotFontBold = true;
            this.btnPrevPatient.Image = global::Sepehr.Properties.Resources.RightLarge;
            this.btnPrevPatient.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.Medium;
            this.btnPrevPatient.ImagePaddingHorizontal = 8;
            this.btnPrevPatient.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnPrevPatient.Name = "btnPrevPatient";
            this.btnPrevPatient.RibbonWordWrap = false;
            this.btnPrevPatient.Text = "بیمار\r\nقبلی";
            this.btnPrevPatient.Click += new System.EventHandler(this.btnPrevPatient_Click);
            // 
            // iContainerPatientID
            // 
            this.iContainerPatientID.CanCustomize = false;
            this.iContainerPatientID.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center;
            this.iContainerPatientID.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.iContainerPatientID.Name = "iContainerPatientID";
            this.iContainerPatientID.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.itemContainer2,
            this.itemContainer3,
            this.iContainerPatientIDTextBox});
            this.iContainerPatientID.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle;
            // 
            // itemContainer2
            // 
            this.itemContainer2.Name = "itemContainer2";
            this.itemContainer2.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.cBoxSearchByPatientID,
            this.lblSearchByPatientID});
            // 
            // cBoxSearchByPatientID
            // 
            this.cBoxSearchByPatientID.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.cBoxSearchByPatientID.Checked = true;
            this.cBoxSearchByPatientID.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBoxSearchByPatientID.Name = "cBoxSearchByPatientID";
            this.cBoxSearchByPatientID.Click += new System.EventHandler(this.cBoxSearchBy_Click);
            // 
            // lblSearchByPatientID
            // 
            this.lblSearchByPatientID.CanCustomize = false;
            this.lblSearchByPatientID.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblSearchByPatientID.ForeColor = System.Drawing.Color.Blue;
            this.lblSearchByPatientID.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right;
            this.lblSearchByPatientID.Name = "lblSearchByPatientID";
            this.lblSearchByPatientID.SingleLineColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblSearchByPatientID.Text = "كد بیمار";
            this.lblSearchByPatientID.Click += new System.EventHandler(this.cBoxSearchBy_Click);
            // 
            // itemContainer3
            // 
            this.itemContainer3.Name = "itemContainer3";
            this.itemContainer3.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.cBoxSearchByRefID,
            this.lblSearchByRefID});
            // 
            // cBoxSearchByRefID
            // 
            this.cBoxSearchByRefID.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.cBoxSearchByRefID.Name = "cBoxSearchByRefID";
            this.cBoxSearchByRefID.Click += new System.EventHandler(this.cBoxSearchBy_Click);
            // 
            // lblSearchByRefID
            // 
            this.lblSearchByRefID.CanCustomize = false;
            this.lblSearchByRefID.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblSearchByRefID.ForeColor = System.Drawing.Color.Blue;
            this.lblSearchByRefID.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right;
            this.lblSearchByRefID.Name = "lblSearchByRefID";
            this.lblSearchByRefID.SingleLineColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblSearchByRefID.Text = "كد مراجعه";
            this.lblSearchByRefID.Click += new System.EventHandler(this.cBoxSearchBy_Click);
            // 
            // iContainerPatientIDTextBox
            // 
            this.iContainerPatientIDTextBox.MinimumSize = new System.Drawing.Size(10, 30);
            this.iContainerPatientIDTextBox.Name = "iContainerPatientIDTextBox";
            this.iContainerPatientIDTextBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.txtPatientID});
            // 
            // txtPatientID
            // 
            this.txtPatientID.CanCustomize = false;
            this.txtPatientID.Name = "txtPatientID";
            this.txtPatientID.ShowSubItems = false;
            this.txtPatientID.TextBoxWidth = 110;
            this.txtPatientID.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.txtPatientID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPatientFilters_KeyPress);
            // 
            // btnNextPatient
            // 
            this.btnNextPatient.BeginGroup = true;
            this.btnNextPatient.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnNextPatient.ForeColor = System.Drawing.Color.Green;
            this.btnNextPatient.HotFontBold = true;
            this.btnNextPatient.Image = global::Sepehr.Properties.Resources.LeftLarge;
            this.btnNextPatient.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.Medium;
            this.btnNextPatient.ImagePaddingHorizontal = 8;
            this.btnNextPatient.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnNextPatient.Name = "btnNextPatient";
            this.btnNextPatient.RibbonWordWrap = false;
            this.btnNextPatient.Text = "بیمار\r\nبعدی";
            this.btnNextPatient.Click += new System.EventHandler(this.btnNextPatient_Click);
            // 
            // iContainerSearchPatient
            // 
            this.iContainerSearchPatient.CanCustomize = false;
            this.iContainerSearchPatient.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center;
            this.iContainerSearchPatient.ItemSpacing = 0;
            this.iContainerSearchPatient.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.iContainerSearchPatient.Name = "iContainerSearchPatient";
            this.iContainerSearchPatient.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.iContainerName,
            this.iContainerLName,
            this.iContainerAge});
            this.iContainerSearchPatient.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle;
            // 
            // iContainerName
            // 
            this.iContainerName.MinimumSize = new System.Drawing.Size(10, 24);
            this.iContainerName.Name = "iContainerName";
            this.iContainerName.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.lblPName,
            this.txtFName});
            // 
            // lblPName
            // 
            this.lblPName.CanCustomize = false;
            this.lblPName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblPName.ForeColor = System.Drawing.Color.Green;
            this.lblPName.Name = "lblPName";
            this.lblPName.Text = " نام:";
            // 
            // txtFName
            // 
            this.txtFName.CanCustomize = false;
            this.txtFName.MaxLength = 30;
            this.txtFName.Name = "txtFName";
            this.txtFName.TextBoxWidth = 100;
            this.txtFName.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.txtFName.WatermarkFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtFName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPatientFilters_KeyPress);
            // 
            // iContainerLName
            // 
            this.iContainerLName.MinimumSize = new System.Drawing.Size(10, 24);
            this.iContainerLName.Name = "iContainerLName";
            this.iContainerLName.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.lblPLName,
            this.txtLName});
            // 
            // lblPLName
            // 
            this.lblPLName.CanCustomize = false;
            this.lblPLName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblPLName.ForeColor = System.Drawing.Color.Green;
            this.lblPLName.Name = "lblPLName";
            this.lblPLName.PaddingRight = 2;
            this.lblPLName.Text = " نام خانوادگی:";
            // 
            // txtLName
            // 
            this.txtLName.CanCustomize = false;
            this.txtLName.MaxLength = 30;
            this.txtLName.Name = "txtLName";
            this.txtLName.TextBoxWidth = 100;
            this.txtLName.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.txtLName.WatermarkFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtLName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPatientFilters_KeyPress);
            // 
            // iContainerAge
            // 
            this.iContainerAge.MinimumSize = new System.Drawing.Size(10, 24);
            this.iContainerAge.Name = "iContainerAge";
            this.iContainerAge.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.lblAge,
            this.txtAge});
            // 
            // lblAge
            // 
            this.lblAge.CanCustomize = false;
            this.lblAge.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblAge.ForeColor = System.Drawing.Color.Green;
            this.lblAge.Name = "lblAge";
            this.lblAge.Text = "سن:";
            // 
            // txtAge
            // 
            this.txtAge.CanCustomize = false;
            this.txtAge.MaxLength = 3;
            this.txtAge.Name = "txtAge";
            this.txtAge.TextBoxWidth = 100;
            this.txtAge.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.txtAge.WatermarkFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtAge.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPatientFilters_KeyPress);
            // 
            // iContainerDays
            // 
            this.iContainerDays.CanCustomize = false;
            this.iContainerDays.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center;
            this.iContainerDays.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.iContainerDays.Name = "iContainerDays";
            this.iContainerDays.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnToday,
            this.btnYesterday});
            this.iContainerDays.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle;
            // 
            // btnToday
            // 
            this.btnToday.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnToday.CanCustomize = false;
            this.btnToday.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnToday.FontBold = true;
            this.btnToday.ImagePaddingHorizontal = 8;
            this.btnToday.ImagePaddingVertical = 20;
            this.btnToday.Name = "btnToday";
            this.btnToday.RibbonWordWrap = false;
            this.btnToday.Text = " امروز ";
            this.btnToday.Tooltip = "نمایش بیماران امروز";
            this.btnToday.Click += new System.EventHandler(this.btnTodayOrYesterday_Click);
            // 
            // btnYesterday
            // 
            this.btnYesterday.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnYesterday.CanCustomize = false;
            this.btnYesterday.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnYesterday.FontBold = true;
            this.btnYesterday.ImagePaddingHorizontal = 8;
            this.btnYesterday.ImagePaddingVertical = 20;
            this.btnYesterday.Name = "btnYesterday";
            this.btnYesterday.RibbonWordWrap = false;
            this.btnYesterday.Text = " دیروز ";
            this.btnYesterday.Tooltip = "نمایش بیماران دیروز";
            this.btnYesterday.Click += new System.EventHandler(this.btnTodayOrYesterday_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnSearch.CanCustomize = false;
            this.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearch.FontBold = true;
            this.btnSearch.Image = global::Sepehr.Properties.Resources.Search;
            this.btnSearch.ImagePaddingHorizontal = 8;
            this.btnSearch.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnAdvancedSearch});
            this.btnSearch.SubItemsExpandWidth = 20;
            this.btnSearch.Text = "جستجو\r\n";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnAdvancedSearch
            // 
            this.btnAdvancedSearch.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnAdvancedSearch.CanCustomize = false;
            this.btnAdvancedSearch.Image = global::Sepehr.Properties.Resources.Find;
            this.btnAdvancedSearch.ImagePaddingHorizontal = 8;
            this.btnAdvancedSearch.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnAdvancedSearch.Name = "btnAdvancedSearch";
            this.btnAdvancedSearch.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlF);
            this.btnAdvancedSearch.Text = "جستجوی\r\nپیشرفته";
            this.btnAdvancedSearch.Click += new System.EventHandler(this.btnAdvancedSearch_Click);
            // 
            // btnClearGrid
            // 
            this.btnClearGrid.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnClearGrid.CanCustomize = false;
            this.btnClearGrid.ColorTable = DevComponents.DotNetBar.eButtonColor.Magenta;
            this.btnClearGrid.Image = global::Sepehr.Properties.Resources.Delete;
            this.btnClearGrid.ImagePaddingHorizontal = 8;
            this.btnClearGrid.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnClearGrid.Name = "btnClearGrid";
            this.btnClearGrid.RibbonWordWrap = false;
            this.btnClearGrid.Text = "پاك كردن\r\nجدول";
            this.btnClearGrid.Click += new System.EventHandler(this.btnClearGrid_Click);
            // 
            // btnPrintGrid
            // 
            this.btnPrintGrid.BeginGroup = true;
            this.btnPrintGrid.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnPrintGrid.Image = global::Sepehr.Properties.Resources.PrintGrid;
            this.btnPrintGrid.ImagePaddingHorizontal = 12;
            this.btnPrintGrid.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnPrintGrid.Name = "btnPrintGrid";
            this.btnPrintGrid.RibbonWordWrap = false;
            this.btnPrintGrid.Text = "چاپ\r\nجدول";
            this.btnPrintGrid.Click += new System.EventHandler(this.btnPrintGrid_Click);
            // 
            // btnSearchHelp
            // 
            this.btnSearchHelp.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnSearchHelp.Image = global::Sepehr.Properties.Resources.HelpMed;
            this.btnSearchHelp.ImagePaddingHorizontal = 12;
            this.btnSearchHelp.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnSearchHelp.Name = "btnSearchHelp";
            this.btnSearchHelp.RibbonWordWrap = false;
            this.btnSearchHelp.Text = "راهنمای\r\nجستجو";
            this.btnSearchHelp.Visible = false;
            // 
            // FormMenu
            // 
            this.FormMenu.AutoOverflowEnabled = false;
            this.FormMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.FormMenu.FadeEffect = false;
            this.FormMenu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormMenu.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnLastPatients,
            this.btnFile,
            this.btnReport,
            this.btnSettings,
            this.btnTools,
            this.btnHelp,
            this.btnRefreshSettings});
            this.FormMenu.KeyTipsFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormMenu.Location = new System.Drawing.Point(0, 0);
            this.FormMenu.Name = "FormMenu";
            this.FormMenu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.FormMenu.Size = new System.Drawing.Size(792, 51);
            this.FormMenu.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.FormMenu.TabIndex = 2;
            this.FormMenu.TabStop = false;
            this.FormMenu.TitleVisible = false;
            // 
            // btnLastPatients
            // 
            this.btnLastPatients.AutoExpandOnClick = true;
            this.btnLastPatients.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnLastPatients.FontBold = true;
            this.btnLastPatients.Image = global::Sepehr.Properties.Resources.SepehrIcon;
            this.btnLastPatients.ImagePaddingHorizontal = 12;
            this.btnLastPatients.Name = "btnLastPatients";
            this.btnLastPatients.Shape = new DevComponents.DotNetBar.EllipticalShapeDescriptor();
            this.btnLastPatients.ShowSubItems = false;
            this.btnLastPatients.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.IContainerStart});
            this.btnLastPatients.Visible = false;
            // 
            // IContainerStart
            // 
            // 
            // 
            // 
            this.IContainerStart.BackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.IContainerStart.BackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.IContainerStart.BackgroundStyle.Class = "RibbonFileMenuContainer";
            this.IContainerStart.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.IContainerStart.Name = "IContainerStart";
            this.IContainerStart.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.iContainerStartButton});
            // 
            // iContainerStartButton
            // 
            // 
            // 
            // 
            this.iContainerStartButton.BackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.iContainerStartButton.BackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.DockSiteBackColor;
            this.iContainerStartButton.BackgroundStyle.Class = "TextBoxBorder";
            this.iContainerStartButton.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.iContainerStartButton.Name = "iContainerStartButton";
            this.iContainerStartButton.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.iContainerRecentPatients});
            // 
            // iContainerRecentPatients
            // 
            // 
            // 
            // 
            this.iContainerRecentPatients.BackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.iContainerRecentPatients.BackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.DockSiteBackColor;
            this.iContainerRecentPatients.BackgroundStyle.Class = "RibbonFileMenuColumnTwoContainer";
            this.iContainerRecentPatients.CanCustomize = false;
            this.iContainerRecentPatients.ItemSpacing = 3;
            this.iContainerRecentPatients.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.iContainerRecentPatients.MinimumSize = new System.Drawing.Size(210, 0);
            this.iContainerRecentPatients.Name = "iContainerRecentPatients";
            this.iContainerRecentPatients.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.lblRecentPatients});
            // 
            // lblRecentPatients
            // 
            this.lblRecentPatients.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom;
            this.lblRecentPatients.BorderType = DevComponents.DotNetBar.eBorderType.Etched;
            this.lblRecentPatients.CanCustomize = false;
            this.lblRecentPatients.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblRecentPatients.ForeColor = System.Drawing.Color.Black;
            this.lblRecentPatients.Name = "lblRecentPatients";
            this.lblRecentPatients.PaddingBottom = 2;
            this.lblRecentPatients.PaddingTop = 2;
            this.lblRecentPatients.Stretch = true;
            this.lblRecentPatients.Text = "آخرین بیماران مشاهده شده:";
            // 
            // btnFile
            // 
            this.btnFile.AutoExpandOnClick = true;
            this.btnFile.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnFile.FontBold = true;
            this.btnFile.Image = global::Sepehr.Properties.Resources.Performers;
            this.btnFile.ImagePaddingHorizontal = 8;
            this.btnFile.Name = "btnFile";
            this.btnFile.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor();
            this.btnFile.ShowSubItems = false;
            this.btnFile.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnAppointments,
            this.btnNewPatient,
            this.btnNewPatientRef,
            this.btnCashManage,
            this.btnCashPatients,
            this.btnCashReport,
            this.btnDocumentPatients,
            this.btnMessagesDashboard});
            this.btnFile.Text = "<font color=\"#0072BC\">پرونده</font>";
            // 
            // btnAppointments
            // 
            this.btnAppointments.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnAppointments.ForeColor = System.Drawing.Color.Blue;
            this.btnAppointments.Image = global::Sepehr.Properties.Resources.Sch;
            this.btnAppointments.ImagePaddingHorizontal = 8;
            this.btnAppointments.Name = "btnAppointments";
            this.btnAppointments.PopupFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnAppointments.RibbonWordWrap = false;
            this.btnAppointments.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlA);
            this.btnAppointments.Tag = "frmAppointments";
            this.btnAppointments.Text = "<b>نوبت دهی</b>\r\r\n<div></div>\r\n<font color=\"#000000\">مدیریت برنامه های نوبتدهی.</" +
                "font>";
            this.btnAppointments.Click += new System.EventHandler(this.btnFiles_Click);
            // 
            // btnNewPatient
            // 
            this.btnNewPatient.BeginGroup = true;
            this.btnNewPatient.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnNewPatient.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnNewPatient.Image = global::Sepehr.Properties.Resources.NewPat;
            this.btnNewPatient.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnNewPatient.ImagePaddingHorizontal = 8;
            this.btnNewPatient.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnNewPatient.Name = "btnNewPatient";
            this.btnNewPatient.RibbonWordWrap = false;
            this.btnNewPatient.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlS);
            this.btnNewPatient.Tag = "frmPatients";
            this.btnNewPatient.Text = "<b>بیمار جدید</b>\r\n<div></div>\r\n<font color=\"#000000\">ثبت پرونده بیمار جدید.</fon" +
                "t>";
            this.btnNewPatient.Click += new System.EventHandler(this.btnFiles_Click);
            // 
            // btnNewPatientRef
            // 
            this.btnNewPatientRef.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnNewPatientRef.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnNewPatientRef.Image = global::Sepehr.Properties.Resources.NewRef;
            this.btnNewPatientRef.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnNewPatientRef.ImagePaddingHorizontal = 8;
            this.btnNewPatientRef.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnNewPatientRef.Name = "btnNewPatientRef";
            this.btnNewPatientRef.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlD);
            this.btnNewPatientRef.Stretch = true;
            this.btnNewPatientRef.Tag = "frmAdmitNewReferral";
            this.btnNewPatientRef.Text = "<b>مراجعه بیمار جدید</b>\r\n<div></div>\r\n<font color=\"#000000\">ثبت همزمان بیمار و م" +
                "راجعه.</font>";
            this.btnNewPatientRef.Click += new System.EventHandler(this.btnFiles_Click);
            // 
            // btnCashManage
            // 
            this.btnCashManage.BeginGroup = true;
            this.btnCashManage.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnCashManage.Image = global::Sepehr.Properties.Resources.CashManage;
            this.btnCashManage.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnCashManage.ImagePaddingHorizontal = 8;
            this.btnCashManage.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnCashManage.Name = "btnCashManage";
            this.btnCashManage.SubItemsExpandWidth = 14;
            this.btnCashManage.Tag = "frmCashesManage";
            this.btnCashManage.Text = "<b>مدیریت صندوق ها</b>\r\n<div></div>\r\n<font color=\"#000000\">باز و بسته كردن ، ورود" +
                " و خروج پول.</font>";
            this.btnCashManage.Click += new System.EventHandler(this.btnFiles_Click);
            // 
            // btnCashPatients
            // 
            this.btnCashPatients.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnCashPatients.Image = global::Sepehr.Properties.Resources.CashMonitor;
            this.btnCashPatients.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnCashPatients.ImagePaddingHorizontal = 8;
            this.btnCashPatients.Name = "btnCashPatients";
            this.btnCashPatients.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlQ);
            this.btnCashPatients.Tag = "frmCashMonitor";
            this.btnCashPatients.Text = "<b>بیماران صندوق</b>\r\n<div></div>\r\n<font color=\"#000000\">بیماران فاقد دریافت مالی" +
                ".</font>";
            this.btnCashPatients.Click += new System.EventHandler(this.btnFiles_Click);
            // 
            // btnCashReport
            // 
            this.btnCashReport.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnCashReport.Image = global::Sepehr.Properties.Resources.CashReport;
            this.btnCashReport.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnCashReport.ImagePaddingHorizontal = 8;
            this.btnCashReport.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnCashReport.Name = "btnCashReport";
            this.btnCashReport.Tag = "frmCashesReport";
            this.btnCashReport.Text = "<b>گزارش صندوق ها</b>\r\n<div></div>\r\n<font color=\"#000000\">گزارشی در مورد صندوق ها" +
                ".</font>";
            this.btnCashReport.Click += new System.EventHandler(this.btnFiles_Click);
            // 
            // btnDocumentPatients
            // 
            this.btnDocumentPatients.BeginGroup = true;
            this.btnDocumentPatients.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnDocumentPatients.ForeColor = System.Drawing.Color.Purple;
            this.btnDocumentPatients.Image = global::Sepehr.Properties.Resources.DocumentCheck;
            this.btnDocumentPatients.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnDocumentPatients.ImagePaddingHorizontal = 8;
            this.btnDocumentPatients.Name = "btnDocumentPatients";
            this.btnDocumentPatients.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlW);
            this.btnDocumentPatients.Tag = "frmDocumentMonitor";
            this.btnDocumentPatients.Text = "<b>بیماران جوابدهی</b>\r\n<div></div>\r\n<font color=\"#000000\">بیماران فاقد مدرك.</fo" +
                "nt>";
            this.btnDocumentPatients.Click += new System.EventHandler(this.btnFiles_Click);
            // 
            // btnMessagesDashboard
            // 
            this.btnMessagesDashboard.BeginGroup = true;
            this.btnMessagesDashboard.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnMessagesDashboard.ForeColor = System.Drawing.Color.Crimson;
            this.btnMessagesDashboard.Image = global::Sepehr.Properties.Resources.SMS_Logo_2;
            this.btnMessagesDashboard.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnMessagesDashboard.ImagePaddingHorizontal = 8;
            this.btnMessagesDashboard.Name = "btnMessagesDashboard";
            this.btnMessagesDashboard.Tag = "frmMessagesDashboard";
            this.btnMessagesDashboard.Text = "<b>داشبورد پیام رسانی</b>\r\n<div></div>\r\n<font color=\"#000000\">پنل مدیریت پیام های" +
                " كوتاه.</font>";
            this.btnMessagesDashboard.Click += new System.EventHandler(this.btnFiles_Click);
            // 
            // btnReport
            // 
            this.btnReport.AutoExpandOnClick = true;
            this.btnReport.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnReport.FontBold = true;
            this.btnReport.Image = global::Sepehr.Properties.Resources.ReportMenu;
            this.btnReport.ImagePaddingHorizontal = 12;
            this.btnReport.Name = "btnReport";
            this.btnReport.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor();
            this.btnReport.ShowSubItems = false;
            this.btnReport.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnGeneralReports,
            this.btnDesignableReports,
            this.btnSpecialReports});
            this.btnReport.Text = "<font color=\"#22B14C\">گزارشها</font>";
            // 
            // btnGeneralReports
            // 
            this.btnGeneralReports.AutoExpandOnClick = true;
            this.btnGeneralReports.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnGeneralReports.Image = global::Sepehr.Properties.Resources.ReportAccounting;
            this.btnGeneralReports.ImagePaddingHorizontal = 8;
            this.btnGeneralReports.ImagePaddingVertical = 0;
            this.btnGeneralReports.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnGeneralReports.Name = "btnGeneralReports";
            this.btnGeneralReports.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnR1,
            this.btnR2,
            this.btnR3,
            this.btnR4,
            this.btnR5,
            this.btnR6,
            this.btnR8});
            this.btnGeneralReports.SubItemsExpandWidth = 14;
            this.btnGeneralReports.Text = "<b>عمومی</b>\r\n<div></div>\r\n<font color=\"#000000\">گزارش های ثابت.</font>";
            // 
            // btnR1
            // 
            this.btnR1.ImagePaddingHorizontal = 8;
            this.btnR1.Name = "btnR1";
            this.btnR1.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnR1_1,
            this.btnR1_2,
            this.btnR1_3,
            this.btnR1_4});
            this.btnR1.Text = "<b>1- تراكنش ها</b>\r\n<div></div>\r\n<font color=\"#000000\">دریافت ها و بازپرداخت ها." +
                "</font>";
            // 
            // btnR1_1
            // 
            this.btnR1_1.ImagePaddingHorizontal = 8;
            this.btnR1_1.Name = "btnR1_1";
            this.btnR1_1.Tag = "Report1.1";
            this.btnR1_1.Text = "1-1- به تفكیك مراجعه";
            this.btnR1_1.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnR1_2
            // 
            this.btnR1_2.ImagePaddingHorizontal = 8;
            this.btnR1_2.Name = "btnR1_2";
            this.btnR1_2.Tag = "Report1.2";
            this.btnR1_2.Text = "1-2- به ترتیب تراكنش ها";
            this.btnR1_2.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnR1_3
            // 
            this.btnR1_3.ImagePaddingHorizontal = 8;
            this.btnR1_3.Name = "btnR1_3";
            this.btnR1_3.Tag = "Report1.3";
            this.btnR1_3.Text = "1-3- به تفكیك مراجعه - خلاصه";
            this.btnR1_3.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnR1_4
            // 
            this.btnR1_4.ImagePaddingHorizontal = 8;
            this.btnR1_4.Name = "btnR1_4";
            this.btnR1_4.Tag = "Report1.4";
            this.btnR1_4.Text = "1-4- با شرح نوع پرداخت";
            this.btnR1_4.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnR2
            // 
            this.btnR2.FontBold = true;
            this.btnR2.ImagePaddingHorizontal = 8;
            this.btnR2.Name = "btnR2";
            this.btnR2.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnR2_1,
            this.btnR2_2});
            this.btnR2.Text = "2- تخفیف ها و هزینه ها";
            // 
            // btnR2_1
            // 
            this.btnR2_1.ImagePaddingHorizontal = 8;
            this.btnR2_1.Name = "btnR2_1";
            this.btnR2_1.Tag = "Report2.1";
            this.btnR2_1.Text = "2-1- به تفكیك مراجعات بیماران";
            this.btnR2_1.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnR2_2
            // 
            this.btnR2_2.ImagePaddingHorizontal = 8;
            this.btnR2_2.Name = "btnR2_2";
            this.btnR2_2.Tag = "Report2.2";
            this.btnR2_2.Text = "2-2- خلاصه به تفكیك نوع";
            this.btnR2_2.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnR3
            // 
            this.btnR3.FontBold = true;
            this.btnR3.ImagePaddingHorizontal = 8;
            this.btnR3.Name = "btnR3";
            this.btnR3.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnR3_1,
            this.btnR3_2});
            this.btnR3.Text = "3- بدهكاران و طلبكاران";
            // 
            // btnR3_1
            // 
            this.btnR3_1.ImagePaddingHorizontal = 8;
            this.btnR3_1.Name = "btnR3_1";
            this.btnR3_1.Tag = "Report3.1";
            this.btnR3_1.Text = "3-1- به تفكیك بیمار و مراجعه";
            this.btnR3_1.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnR3_2
            // 
            this.btnR3_2.ImagePaddingHorizontal = 8;
            this.btnR3_2.Name = "btnR3_2";
            this.btnR3_2.Tag = "Report3.2";
            this.btnR3_2.Text = "3-2- خلاصه اطلاعات";
            this.btnR3_2.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnR4
            // 
            this.btnR4.FontBold = true;
            this.btnR4.ImagePaddingHorizontal = 8;
            this.btnR4.Name = "btnR4";
            this.btnR4.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnR4_1,
            this.btnR4_2,
            this.btnR4_3,
            this.btnR4_4});
            this.btnR4.Text = "4- بیمه ها";
            // 
            // btnR4_1
            // 
            this.btnR4_1.ImagePaddingHorizontal = 8;
            this.btnR4_1.Name = "btnR4_1";
            this.btnR4_1.Tag = "Report4.1";
            this.btnR4_1.Text = "4-1- ارسال به بیمه";
            this.btnR4_1.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnR4_2
            // 
            this.btnR4_2.ImagePaddingHorizontal = 8;
            this.btnR4_2.Name = "btnR4_2";
            this.btnR4_2.Tag = "Report4.2";
            this.btnR4_2.Text = "4-2- چك نسخ - به تفصیل";
            this.btnR4_2.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnR4_3
            // 
            this.btnR4_3.ImagePaddingHorizontal = 8;
            this.btnR4_3.Name = "btnR4_3";
            this.btnR4_3.Tag = "Report4.3";
            this.btnR4_3.Text = "4-3- چك نسخ - خلاصه";
            this.btnR4_3.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnR4_4
            // 
            this.btnR4_4.ImagePaddingHorizontal = 8;
            this.btnR4_4.Name = "btnR4_4";
            this.btnR4_4.Tag = "Report4.4";
            this.btnR4_4.Text = "4-4- ارسال به بیمه - با خدمات";
            this.btnR4_4.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnR5
            // 
            this.btnR5.FontBold = true;
            this.btnR5.ImagePaddingHorizontal = 8;
            this.btnR5.Name = "btnR5";
            this.btnR5.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnR5_1,
            this.btnR5_2,
            this.btnR5_3,
            this.btnR5_4,
            this.btnR5_5,
            this.btnR5_10,
            this.btnR5_11,
            this.btnR5_12,
            this.btnR5_13});
            this.btnR5.Text = "5- خدمات ارائه شده";
            // 
            // btnR5_1
            // 
            this.btnR5_1.ImagePaddingHorizontal = 8;
            this.btnR5_1.Name = "btnR5_1";
            this.btnR5_1.Tag = "Report5.1";
            this.btnR5_1.Text = "5-1- به تفكیك مراجعات بیماران";
            this.btnR5_1.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnR5_2
            // 
            this.btnR5_2.ImagePaddingHorizontal = 8;
            this.btnR5_2.Name = "btnR5_2";
            this.btnR5_2.Tag = "Report5.2";
            this.btnR5_2.Text = "5-2- مالی مراجعات";
            this.btnR5_2.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnR5_3
            // 
            this.btnR5_3.ImagePaddingHorizontal = 8;
            this.btnR5_3.Name = "btnR5_3";
            this.btnR5_3.Tag = "Report5.3";
            this.btnR5_3.Text = "5-3- مالی خدمات مراجعات";
            this.btnR5_3.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnR5_4
            // 
            this.btnR5_4.ImagePaddingHorizontal = 8;
            this.btnR5_4.Name = "btnR5_4";
            this.btnR5_4.Tag = "Report5.4";
            this.btnR5_4.Text = "5-4- مالی به تفكیك طبقه بندی خدمات";
            this.btnR5_4.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnR5_5
            // 
            this.btnR5_5.ImagePaddingHorizontal = 8;
            this.btnR5_5.Name = "btnR5_5";
            this.btnR5_5.Tag = "Report5.5";
            this.btnR5_5.Text = "5-5 حسابداری دوطرفه - دوبل";
            this.btnR5_5.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnR5_10
            // 
            this.btnR5_10.Enabled = false;
            this.btnR5_10.ImagePaddingHorizontal = 8;
            this.btnR5_10.Name = "btnR5_10";
            this.btnR5_10.Text = "5-4 بیشترین خدمات ارائه شده";
            this.btnR5_10.Visible = false;
            // 
            // btnR5_11
            // 
            this.btnR5_11.Enabled = false;
            this.btnR5_11.ImagePaddingHorizontal = 8;
            this.btnR5_11.Name = "btnR5_11";
            this.btnR5_11.Text = "5-5 خدمات ارائه نشده";
            this.btnR5_11.Visible = false;
            // 
            // btnR5_12
            // 
            this.btnR5_12.Enabled = false;
            this.btnR5_12.ImagePaddingHorizontal = 8;
            this.btnR5_12.Name = "btnR5_12";
            this.btnR5_12.Text = "5-6 رشد ارائه خدمات";
            this.btnR5_12.Visible = false;
            // 
            // btnR5_13
            // 
            this.btnR5_13.Enabled = false;
            this.btnR5_13.ImagePaddingHorizontal = 8;
            this.btnR5_13.Name = "btnR5_13";
            this.btnR5_13.Text = "5-7 رشد درآمد";
            this.btnR5_13.Visible = false;
            // 
            // btnR6
            // 
            this.btnR6.FontBold = true;
            this.btnR6.ImagePaddingHorizontal = 8;
            this.btnR6.Name = "btnR6";
            this.btnR6.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnR6_1,
            this.btnR6_2,
            this.btnR6_3});
            this.btnR6.Text = "6- كاركرد كادر پزشكی";
            // 
            // btnR6_1
            // 
            this.btnR6_1.ImagePaddingHorizontal = 8;
            this.btnR6_1.Name = "btnR6_1";
            this.btnR6_1.Tag = "Report6.1";
            this.btnR6_1.Text = "6-1- خلاصه كاركرد";
            this.btnR6_1.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnR6_2
            // 
            this.btnR6_2.ImagePaddingHorizontal = 8;
            this.btnR6_2.Name = "btnR6_2";
            this.btnR6_2.Tag = "Report6.2";
            this.btnR6_2.Text = "6-2- ریز كاركرد";
            this.btnR6_2.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnR6_3
            // 
            this.btnR6_3.ImagePaddingHorizontal = 8;
            this.btnR6_3.Name = "btnR6_3";
            this.btnR6_3.Tag = "Report6.3";
            this.btnR6_3.Text = "6-3- درخواست كننده ها - طبقه بندی";
            this.btnR6_3.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnR8
            // 
            this.btnR8.FontBold = true;
            this.btnR8.ImagePaddingHorizontal = 8;
            this.btnR8.Name = "btnR8";
            this.btnR8.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnR1_3_1,
            this.btnR1_3_2,
            this.btnR1_3_3,
            this.btnR1_3_4});
            this.btnR8.Text = "؟- آمار كاربران";
            this.btnR8.Visible = false;
            // 
            // btnR1_3_1
            // 
            this.btnR1_3_1.ImagePaddingHorizontal = 8;
            this.btnR1_3_1.Name = "btnR1_3_1";
            this.btnR1_3_1.Text = "8-1 نوبت دهندگان";
            // 
            // btnR1_3_2
            // 
            this.btnR1_3_2.ImagePaddingHorizontal = 8;
            this.btnR1_3_2.Name = "btnR1_3_2";
            this.btnR1_3_2.Text = "8-2 پذیرش كنندگان";
            // 
            // btnR1_3_3
            // 
            this.btnR1_3_3.ImagePaddingHorizontal = 8;
            this.btnR1_3_3.Name = "btnR1_3_3";
            this.btnR1_3_3.Text = "8-3 صندوقداران";
            // 
            // btnR1_3_4
            // 
            this.btnR1_3_4.ImagePaddingHorizontal = 8;
            this.btnR1_3_4.Name = "btnR1_3_4";
            this.btnR1_3_4.Text = "8-4 تایپیست ها";
            // 
            // btnDesignableReports
            // 
            this.btnDesignableReports.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnDesignableReports.Image = global::Sepehr.Properties.Resources.DesignableReports;
            this.btnDesignableReports.ImagePaddingHorizontal = 8;
            this.btnDesignableReports.ImagePaddingVertical = 0;
            this.btnDesignableReports.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnDesignableReports.Name = "btnDesignableReports";
            this.btnDesignableReports.Tag = "DesignableReports";
            this.btnDesignableReports.Text = "<b>قابل طراحی</b>\r\n<div></div>\r\n<font color=\"#000000\">ساختار انتخابی.</font>";
            this.btnDesignableReports.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnSpecialReports
            // 
            this.btnSpecialReports.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnSpecialReports.Image = global::Sepehr.Properties.Resources.SpecianReports;
            this.btnSpecialReports.ImagePaddingHorizontal = 8;
            this.btnSpecialReports.ImagePaddingVertical = 0;
            this.btnSpecialReports.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnSpecialReports.Name = "btnSpecialReports";
            this.btnSpecialReports.SubItemsExpandWidth = 14;
            this.btnSpecialReports.Tag = "frmReportSpecial";
            this.btnSpecialReports.Text = "<b>اختصاصی</b>\r\n<div></div>\r\n<font color=\"#000000\">ویژه مشتری.</font>";
            this.btnSpecialReports.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.AutoExpandOnClick = true;
            this.btnSettings.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnSettings.FontBold = true;
            this.btnSettings.Image = global::Sepehr.Properties.Resources.Setting1;
            this.btnSettings.ImagePaddingHorizontal = 8;
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor();
            this.btnSettings.ShowSubItems = false;
            this.btnSettings.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnChangePassword,
            this.btnUserSettings,
            this.btnSecuritySettings,
            this.btnSchSettings,
            this.btnPatientsSettings,
            this.btnRefSettings,
            this.btnServInsSettings,
            this.btnAccountCashSettings,
            this.btnDocSettings,
            this.btnBillTemplatesSettings,
            this.btnPacsManage,
            this.btnMessagesSettings});
            this.btnSettings.Text = "<font color=\"#FF0AF8\">تنظیمات</font>";
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.BeginGroup = true;
            this.btnChangePassword.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnChangePassword.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.btnChangePassword.Image = global::Sepehr.Properties.Resources.Password;
            this.btnChangePassword.ImagePaddingHorizontal = 8;
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Tag = "ChangeUserPassword";
            this.btnChangePassword.Text = "<b>تغییر كلمه عبور</b>\r\n<div></div>\r\n<font color=\"#000000\">تغییر كلمه عبور كاربر " +
                "جاری.</font>";
            this.btnChangePassword.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnUserSettings
            // 
            this.btnUserSettings.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnUserSettings.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.btnUserSettings.Image = global::Sepehr.Properties.Resources.UsersSettings;
            this.btnUserSettings.ImagePaddingHorizontal = 8;
            this.btnUserSettings.Name = "btnUserSettings";
            this.btnUserSettings.Tag = "frmManageUserSettings";
            this.btnUserSettings.Text = "<b>تنظیمات كاربر جاری</b>\r\n<div></div>\r\n<font color=\"#000000\">تغییر تنظیمات كاربر" +
                " جاری.</font>";
            this.btnUserSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnSecuritySettings
            // 
            this.btnSecuritySettings.BeginGroup = true;
            this.btnSecuritySettings.ForeColor = System.Drawing.Color.Navy;
            this.btnSecuritySettings.Image = global::Sepehr.Properties.Resources.SysSecurity1;
            this.btnSecuritySettings.ImagePaddingHorizontal = 8;
            this.btnSecuritySettings.Name = "btnSecuritySettings";
            this.btnSecuritySettings.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnUsers,
            this.btnGroups,
            this.btnUsersGrouping,
            this.btnACLManage});
            this.btnSecuritySettings.Text = "<b>تنظیمات امنیتی</b>\r\n<div></div>\r\n<font color=\"#000000\">كاربران و دسترسی ها.</f" +
                "ont>";
            // 
            // btnUsers
            // 
            this.btnUsers.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnUsers.ForeColor = System.Drawing.Color.Navy;
            this.btnUsers.Image = global::Sepehr.Properties.Resources.AllowedUsers;
            this.btnUsers.ImagePaddingHorizontal = 8;
            this.btnUsers.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Tag = "frmUsers";
            this.btnUsers.Text = "<b>كاربران</b>\r\n<br></br>\r\n<font color=\"#000000\">تعریف و ویرایش.</font>";
            this.btnUsers.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnGroups
            // 
            this.btnGroups.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnGroups.ForeColor = System.Drawing.Color.Navy;
            this.btnGroups.Image = global::Sepehr.Properties.Resources.GroupsManage;
            this.btnGroups.ImagePaddingHorizontal = 8;
            this.btnGroups.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnGroups.Name = "btnGroups";
            this.btnGroups.Tag = "frmUsersGroups";
            this.btnGroups.Text = "<b>گروه های كاربری</b>\r\n<br></br>\r\n<font color=\"#000000\">جهت مدیریت جمعی كاربران." +
                "</font>";
            this.btnGroups.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnUsersGrouping
            // 
            this.btnUsersGrouping.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnUsersGrouping.ForeColor = System.Drawing.Color.Navy;
            this.btnUsersGrouping.Image = global::Sepehr.Properties.Resources.SetUsersInGroups;
            this.btnUsersGrouping.ImagePaddingHorizontal = 8;
            this.btnUsersGrouping.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnUsersGrouping.Name = "btnUsersGrouping";
            this.btnUsersGrouping.Tag = "frmUsersGrouping";
            this.btnUsersGrouping.Text = "<b>گروه بندی كاربران</b>\r\n<br></br>\r\n<font color=\"#000000\">قراردادن كاربر در گروه" +
                ".</font>";
            this.btnUsersGrouping.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnACLManage
            // 
            this.btnACLManage.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnACLManage.ForeColor = System.Drawing.Color.Navy;
            this.btnACLManage.Image = global::Sepehr.Properties.Resources.ACLManage;
            this.btnACLManage.ImagePaddingHorizontal = 4;
            this.btnACLManage.ImagePaddingVertical = 0;
            this.btnACLManage.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnACLManage.Name = "btnACLManage";
            this.btnACLManage.SubItemsExpandWidth = 14;
            this.btnACLManage.Tag = "frmACLManages";
            this.btnACLManage.Text = "<b>سطوح دسترسی</b>\r\n<br></br>\r\n<font color=\"#000000\">تعیین دسترسی گروه/كاربر.</fo" +
                "nt>";
            this.btnACLManage.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnSchSettings
            // 
            this.btnSchSettings.BeginGroup = true;
            this.btnSchSettings.ForeColor = System.Drawing.Color.Green;
            this.btnSchSettings.Image = global::Sepehr.Properties.Resources.Sch;
            this.btnSchSettings.ImagePaddingHorizontal = 8;
            this.btnSchSettings.Name = "btnSchSettings";
            this.btnSchSettings.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnAppointmentsDef,
            this.btnSchAddinFields});
            this.btnSchSettings.Text = "<b>نوبت دهی</b>\r\n<div></div>\r\n<font color=\"#000000\">تعریف و ویرایش برنامه ها.</fo" +
                "nt>";
            // 
            // btnAppointmentsDef
            // 
            this.btnAppointmentsDef.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnAppointmentsDef.ForeColor = System.Drawing.Color.Green;
            this.btnAppointmentsDef.Image = global::Sepehr.Properties.Resources.SchEditApp;
            this.btnAppointmentsDef.ImagePaddingHorizontal = 6;
            this.btnAppointmentsDef.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnAppointmentsDef.Name = "btnAppointmentsDef";
            this.btnAppointmentsDef.Tag = "frmApplications";
            this.btnAppointmentsDef.Text = "<b>مدیریت</b>\r\n<div></div>\r\n<font color=\"#000000\">افزودن ، ویرایش و حذف.</font>";
            this.btnAppointmentsDef.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnSchAddinFields
            // 
            this.btnSchAddinFields.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnSchAddinFields.ForeColor = System.Drawing.Color.Green;
            this.btnSchAddinFields.Image = global::Sepehr.Properties.Resources.AddinFields;
            this.btnSchAddinFields.ImagePaddingHorizontal = 6;
            this.btnSchAddinFields.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnSchAddinFields.Name = "btnSchAddinFields";
            this.btnSchAddinFields.Tag = "frmSchAddinFields";
            this.btnSchAddinFields.Text = "<b>فیلدهای پویا</b>\r\n<div></div>\r\n<font color=\"#000000\">ستون های جدید و ترتیب آنه" +
                "ا.</font>";
            this.btnSchAddinFields.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnPatientsSettings
            // 
            this.btnPatientsSettings.BeginGroup = true;
            this.btnPatientsSettings.Image = global::Sepehr.Properties.Resources.PatientFile;
            this.btnPatientsSettings.ImagePaddingHorizontal = 8;
            this.btnPatientsSettings.Name = "btnPatientsSettings";
            this.btnPatientsSettings.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnPatAddinData,
            this.btnJobs,
            this.btnLocations,
            this.btnNamesBank});
            this.btnPatientsSettings.Text = "<b>بیماران</b>\r\n<div></div>\r\n<font color=\"#000000\">تنظیمات پرونده بیمار.</font>";
            // 
            // btnPatAddinData
            // 
            this.btnPatAddinData.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnPatAddinData.Image = global::Sepehr.Properties.Resources.AddinFields;
            this.btnPatAddinData.ImagePaddingHorizontal = 4;
            this.btnPatAddinData.ImagePaddingVertical = 0;
            this.btnPatAddinData.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnPatAddinData.Name = "btnPatAddinData";
            this.btnPatAddinData.Tag = "frmPatAdditionalCols";
            this.btnPatAddinData.Text = "<b>فیلدهای پویا</b>\r\n<br></br>\r\n<font color=\"#000000\">آیتم (فیلد) جدید به ازای بی" +
                "مار.</font>";
            this.btnPatAddinData.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnJobs
            // 
            this.btnJobs.BeginGroup = true;
            this.btnJobs.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnJobs.Image = global::Sepehr.Properties.Resources.Job;
            this.btnJobs.ImagePaddingHorizontal = 8;
            this.btnJobs.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnJobs.Name = "btnJobs";
            this.btnJobs.Tag = "frmPatientsJob";
            this.btnJobs.Text = "<b>انواع مشاغل</b>\r\n<br></br>\r\n<font color=\"#000000\">تعریف پیش فرض شغل بیمار.</fo" +
                "nt>";
            this.btnJobs.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnLocations
            // 
            this.btnLocations.AutoExpandOnClick = true;
            this.btnLocations.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnLocations.Image = global::Sepehr.Properties.Resources.Address;
            this.btnLocations.ImagePaddingHorizontal = 8;
            this.btnLocations.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnLocations.Name = "btnLocations";
            this.btnLocations.SplitButton = true;
            this.btnLocations.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnCountries,
            this.btnStates,
            this.btnCities});
            this.btnLocations.Text = "<b>آدرس ها</b>\r\n<br></br>\r\n<font color=\"#000000\">كشور ، استان و شهر بیمار.</font>" +
                "";
            // 
            // btnCountries
            // 
            this.btnCountries.BeginGroup = true;
            this.btnCountries.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnCountries.ImagePaddingHorizontal = 8;
            this.btnCountries.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnCountries.Name = "btnCountries";
            this.btnCountries.Tag = "frmCountries";
            this.btnCountries.Text = "كشور ها";
            this.btnCountries.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnStates
            // 
            this.btnStates.ImagePaddingHorizontal = 8;
            this.btnStates.Name = "btnStates";
            this.btnStates.Tag = "frmStates";
            this.btnStates.Text = "استان ها";
            this.btnStates.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnCities
            // 
            this.btnCities.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnCities.ImagePaddingHorizontal = 8;
            this.btnCities.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnCities.Name = "btnCities";
            this.btnCities.Tag = "frmCities";
            this.btnCities.Text = "شهر ها";
            this.btnCities.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnNamesBank
            // 
            this.btnNamesBank.BeginGroup = true;
            this.btnNamesBank.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnNamesBank.Image = global::Sepehr.Properties.Resources.Data;
            this.btnNamesBank.ImagePaddingHorizontal = 8;
            this.btnNamesBank.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnNamesBank.Name = "btnNamesBank";
            this.btnNamesBank.Tag = "frmPatientsName";
            this.btnNamesBank.Text = "<b>اسامی انگلیسی</b>\r\n<br></br>\r\n<font color=\"#000000\">معادل انگلیسی اسامی فارسی." +
                "</font>";
            this.btnNamesBank.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnRefSettings
            // 
            this.btnRefSettings.ForeColor = System.Drawing.Color.Black;
            this.btnRefSettings.Image = global::Sepehr.Properties.Resources.Setting1;
            this.btnRefSettings.ImagePaddingHorizontal = 8;
            this.btnRefSettings.Name = "btnRefSettings";
            this.btnRefSettings.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnPerformers,
            this.btnPhysiciansSpecs,
            this.btnPhysicians,
            this.btnRefAddinData,
            this.btnRefStatus});
            this.btnRefSettings.Text = "<b>مراجعات</b>\r\n<br></br>\r\n<font color=\"#000000\">اطلاعات پذیرش مراجعات.</font>";
            // 
            // btnPerformers
            // 
            this.btnPerformers.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnPerformers.ForeColor = System.Drawing.Color.Black;
            this.btnPerformers.Image = global::Sepehr.Properties.Resources.Performers;
            this.btnPerformers.ImagePaddingHorizontal = 8;
            this.btnPerformers.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnPerformers.Name = "btnPerformers";
            this.btnPerformers.Tag = "frmPerformers";
            this.btnPerformers.Text = "<b>کادر پزشكی</b>\r\n<br></br>\r\n<font color=\"#000000\">پزشك و كارشناس.</font>";
            this.btnPerformers.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnPhysiciansSpecs
            // 
            this.btnPhysiciansSpecs.BeginGroup = true;
            this.btnPhysiciansSpecs.ForeColor = System.Drawing.Color.Black;
            this.btnPhysiciansSpecs.Image = global::Sepehr.Properties.Resources.Job;
            this.btnPhysiciansSpecs.ImagePaddingHorizontal = 8;
            this.btnPhysiciansSpecs.Name = "btnPhysiciansSpecs";
            this.btnPhysiciansSpecs.Tag = "frmPhysiciansSpecs";
            this.btnPhysiciansSpecs.Text = "<b>تخصص ها</b>\r\n<br></br>\r\n<font color=\"#000000\">تخصص های پزشكان.</font>";
            this.btnPhysiciansSpecs.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnPhysicians
            // 
            this.btnPhysicians.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnPhysicians.ForeColor = System.Drawing.Color.Black;
            this.btnPhysicians.Image = global::Sepehr.Properties.Resources.Physician;
            this.btnPhysicians.ImagePaddingHorizontal = 8;
            this.btnPhysicians.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnPhysicians.Name = "btnPhysicians";
            this.btnPhysicians.Tag = "frmPhysicians";
            this.btnPhysicians.Text = "<b>پزشكان ارجاع دهنده</b>\r\n<br></br>\r\n<font color=\"#000000\">درخواست كنندگان تصویر" +
                "برداری.</font>";
            this.btnPhysicians.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnRefAddinData
            // 
            this.btnRefAddinData.BeginGroup = true;
            this.btnRefAddinData.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnRefAddinData.ForeColor = System.Drawing.Color.Black;
            this.btnRefAddinData.Image = global::Sepehr.Properties.Resources.AddinFields;
            this.btnRefAddinData.ImagePaddingHorizontal = 4;
            this.btnRefAddinData.ImagePaddingVertical = 0;
            this.btnRefAddinData.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnRefAddinData.Name = "btnRefAddinData";
            this.btnRefAddinData.Tag = "frmRefAdditionalCols";
            this.btnRefAddinData.Text = "<b>فیلدهای پویا</b>\r\n<br></br>\r\n<font color=\"#000000\">فیلد جدید به ازای مراجعات.<" +
                "/font>";
            this.btnRefAddinData.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnRefStatus
            // 
            this.btnRefStatus.ForeColor = System.Drawing.Color.Black;
            this.btnRefStatus.Image = global::Sepehr.Properties.Resources.Data;
            this.btnRefStatus.ImagePaddingHorizontal = 8;
            this.btnRefStatus.ImagePaddingVertical = 0;
            this.btnRefStatus.Name = "btnRefStatus";
            this.btnRefStatus.Tag = "frmStatus";
            this.btnRefStatus.Text = "<b>شرایط مراجعات</b>\r\n<br></br>\r\n<font color=\"#000000\">وضعیتهای دلخواه مراجعه.</f" +
                "ont>";
            this.btnRefStatus.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnServInsSettings
            // 
            this.btnServInsSettings.ForeColor = System.Drawing.Color.Purple;
            this.btnServInsSettings.Image = global::Sepehr.Properties.Resources.Setting2;
            this.btnServInsSettings.ImagePaddingHorizontal = 8;
            this.btnServInsSettings.Name = "btnServInsSettings";
            this.btnServInsSettings.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnServiceTypes,
            this.btnServiceGroups,
            this.btnServices,
            this.btnServiceGrouping,
            this.btnDefaultServicePerformers,
            this.btnInsurances});
            this.btnServInsSettings.Text = "<b>خدمات و بیمه ها</b>\r\n<br></br>\r\n<font color=\"#000000\">تنظیمات خدمات و بیمه ها." +
                "</font>";
            // 
            // btnServiceTypes
            // 
            this.btnServiceTypes.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnServiceTypes.ForeColor = System.Drawing.Color.Blue;
            this.btnServiceTypes.Image = global::Sepehr.Properties.Resources.Setting2;
            this.btnServiceTypes.ImagePaddingHorizontal = 8;
            this.btnServiceTypes.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnServiceTypes.Name = "btnServiceTypes";
            this.btnServiceTypes.Tag = "frmCategories";
            this.btnServiceTypes.Text = "<b>طبقه بندی خدمات</b>\r\n<div></div>\r\n<font color=\"#000000\">هر خدمت دارای 1 طبقه ب" +
                "ندی.</font>";
            this.btnServiceTypes.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnServiceGroups
            // 
            this.btnServiceGroups.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnServiceGroups.ForeColor = System.Drawing.Color.Blue;
            this.btnServiceGroups.Image = global::Sepehr.Properties.Resources.Data;
            this.btnServiceGroups.ImagePaddingHorizontal = 8;
            this.btnServiceGroups.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnServiceGroups.Name = "btnServiceGroups";
            this.btnServiceGroups.Stretch = true;
            this.btnServiceGroups.Tag = "frmGroupsServices";
            this.btnServiceGroups.Text = "<b>گروه های خدمات</b>\r\n<div></div>\r\n<font color=\"#000000\">هر خدمت در چند گروه.</f" +
                "ont>";
            this.btnServiceGroups.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnServices
            // 
            this.btnServices.BeginGroup = true;
            this.btnServices.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnServices.ForeColor = System.Drawing.Color.Purple;
            this.btnServices.Image = global::Sepehr.Properties.Resources.ServicesSettings;
            this.btnServices.ImagePaddingHorizontal = 8;
            this.btnServices.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnServices.Name = "btnServices";
            this.btnServices.Stretch = true;
            this.btnServices.Tag = "frmServices";
            this.btnServices.Text = "<b>مدیریت خدمات</b>\r\n<div></div>\r\n<font color=\"#000000\">تعریف خدمات و قیمت های آن" +
                "ها.</font>";
            this.btnServices.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnServiceGrouping
            // 
            this.btnServiceGrouping.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnServiceGrouping.ForeColor = System.Drawing.Color.Purple;
            this.btnServiceGrouping.Image = global::Sepehr.Properties.Resources.GroupsManage;
            this.btnServiceGrouping.ImagePaddingHorizontal = 8;
            this.btnServiceGrouping.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnServiceGrouping.Name = "btnServiceGrouping";
            this.btnServiceGrouping.Stretch = true;
            this.btnServiceGrouping.Tag = "frmServicesGrouping";
            this.btnServiceGrouping.Text = "<b>گروهبندی خدمات</b>\r\n<div></div>\r\n<font color=\"#000000\">تعیین خدمات عضو گروه ها" +
                ".</font>";
            this.btnServiceGrouping.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnDefaultServicePerformers
            // 
            this.btnDefaultServicePerformers.ForeColor = System.Drawing.Color.Purple;
            this.btnDefaultServicePerformers.Image = global::Sepehr.Properties.Resources.Performers;
            this.btnDefaultServicePerformers.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnDefaultServicePerformers.ImagePaddingHorizontal = 8;
            this.btnDefaultServicePerformers.Name = "btnDefaultServicePerformers";
            this.btnDefaultServicePerformers.Tag = "frmDefaultPerformers";
            this.btnDefaultServicePerformers.Text = "<b>كادر پزشكی پیش فرض</b>\r\n<div></div>\r\n<font color=\"#000000\">كادر خدمات در زمان " +
                "مشخص.</font>";
            this.btnDefaultServicePerformers.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnInsurances
            // 
            this.btnInsurances.BeginGroup = true;
            this.btnInsurances.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnInsurances.ForeColor = System.Drawing.Color.Green;
            this.btnInsurances.Image = global::Sepehr.Properties.Resources.InsLogo;
            this.btnInsurances.ImagePaddingHorizontal = 8;
            this.btnInsurances.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnInsurances.Name = "btnInsurances";
            this.btnInsurances.Tag = "frmInsurances";
            this.btnInsurances.Text = "<b>مدیریت بیمه ها</b>\r\n<div></div>\r\n<font color=\"#000000\">تنظیم بیمه و قیمت خدمات" +
                " آنها.</font>";
            this.btnInsurances.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnAccountCashSettings
            // 
            this.btnAccountCashSettings.BeginGroup = true;
            this.btnAccountCashSettings.ForeColor = System.Drawing.Color.Blue;
            this.btnAccountCashSettings.Image = global::Sepehr.Properties.Resources.Payment;
            this.btnAccountCashSettings.ImagePaddingHorizontal = 8;
            this.btnAccountCashSettings.Name = "btnAccountCashSettings";
            this.btnAccountCashSettings.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnCostDiscountTypes,
            this.btnCostDiscountExcludedUsers,
            this.btnBanks,
            this.btnCashes,
            this.btnCashCashiers});
            this.btnAccountCashSettings.Text = "<b>حساب و صندوق</b>\r\n<br></br>\r\n<font color=\"#000000\">تعاریف مالی و چند صندوقی.</" +
                "font>";
            // 
            // btnCostDiscountTypes
            // 
            this.btnCostDiscountTypes.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnCostDiscountTypes.ForeColor = System.Drawing.Color.Blue;
            this.btnCostDiscountTypes.Image = global::Sepehr.Properties.Resources.AccountSetting;
            this.btnCostDiscountTypes.ImagePaddingHorizontal = 8;
            this.btnCostDiscountTypes.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnCostDiscountTypes.Name = "btnCostDiscountTypes";
            this.btnCostDiscountTypes.Tag = "frmCostDiscountTypes";
            this.btnCostDiscountTypes.Text = "<b>تخفیف ها و هزینه ها</b>\r\n<br></br>\r\n<font color=\"#000000\">مدیریت انواع و سقف آ" +
                "نها.</font>";
            this.btnCostDiscountTypes.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnCostDiscountExcludedUsers
            // 
            this.btnCostDiscountExcludedUsers.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnCostDiscountExcludedUsers.ForeColor = System.Drawing.Color.Blue;
            this.btnCostDiscountExcludedUsers.Image = global::Sepehr.Properties.Resources.UsersSettings;
            this.btnCostDiscountExcludedUsers.ImagePaddingHorizontal = 8;
            this.btnCostDiscountExcludedUsers.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnCostDiscountExcludedUsers.Name = "btnCostDiscountExcludedUsers";
            this.btnCostDiscountExcludedUsers.Tag = "frmCostDiscountUsersExclude";
            this.btnCostDiscountExcludedUsers.Text = "<b>محدود سازی كاربران</b>\r\n<br></br>\r\n<font color=\"#000000\">مجوز ارائه تخفیف و هز" +
                "ینه.</font>";
            this.btnCostDiscountExcludedUsers.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnBanks
            // 
            this.btnBanks.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnBanks.ForeColor = System.Drawing.Color.Blue;
            this.btnBanks.Image = global::Sepehr.Properties.Resources.Bank;
            this.btnBanks.ImagePaddingHorizontal = 8;
            this.btnBanks.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnBanks.Name = "btnBanks";
            this.btnBanks.Tag = "frmBanks";
            this.btnBanks.Text = "<b>بانك ها و موسسات</b>\r\n<br></br>\r\n<font color=\"#000000\">بانك هادر پرداخت های غی" +
                "ر نقدی.</font>";
            this.btnBanks.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnCashes
            // 
            this.btnCashes.BeginGroup = true;
            this.btnCashes.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnCashes.ForeColor = System.Drawing.Color.Green;
            this.btnCashes.Image = global::Sepehr.Properties.Resources.Cash;
            this.btnCashes.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnCashes.ImagePaddingHorizontal = 8;
            this.btnCashes.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnCashes.Name = "btnCashes";
            this.btnCashes.Tag = "frmCashes";
            this.btnCashes.Text = "<b>مدیریت صندوق ها</b>\r\n<br></br>\r\n<font color=\"#000000\">تعریف صندوق های فعال.</f" +
                "ont>";
            this.btnCashes.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnCashCashiers
            // 
            this.btnCashCashiers.ForeColor = System.Drawing.Color.Green;
            this.btnCashCashiers.Image = global::Sepehr.Properties.Resources.AllowedUsers;
            this.btnCashCashiers.ImagePaddingHorizontal = 8;
            this.btnCashCashiers.Name = "btnCashCashiers";
            this.btnCashCashiers.Tag = "frmCashCashiers";
            this.btnCashCashiers.Text = "<b>ارتباط كاربران و صندوق ها</b>\r\n<br></br>\r\n<font color=\"#000000\">دسترسی هر كارب" +
                "ر به هر صندوق.</font>";
            this.btnCashCashiers.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnDocSettings
            // 
            this.btnDocSettings.BeginGroup = true;
            this.btnDocSettings.ForeColor = System.Drawing.Color.Teal;
            this.btnDocSettings.Image = global::Sepehr.Properties.Resources.DocumentSetting;
            this.btnDocSettings.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnDocSettings.ImagePaddingHorizontal = 8;
            this.btnDocSettings.Name = "btnDocSettings";
            this.btnDocSettings.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnDocTemplates,
            this.btnDocTexts,
            this.btnDocTypes});
            this.btnDocSettings.Text = "<b>مدارك مراجعات</b>\r\n<br></br>\r\n<font color=\"#000000\">قالبها ، متن ها و گروه ها." +
                "</font>";
            // 
            // btnDocTemplates
            // 
            this.btnDocTemplates.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnDocTemplates.ForeColor = System.Drawing.Color.Teal;
            this.btnDocTemplates.Image = global::Sepehr.Properties.Resources.DocTemplates;
            this.btnDocTemplates.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnDocTemplates.ImagePaddingHorizontal = 6;
            this.btnDocTemplates.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnDocTemplates.Name = "btnDocTemplates";
            this.btnDocTemplates.Tag = "frmDocTemplates";
            this.btnDocTemplates.Text = "<b>مدیریت قالب ها</b>\r\n<br></br>\r\n<font color=\"#000000\">قالب صفحه مدرك مراجعه.</f" +
                "ont>";
            this.btnDocTemplates.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnDocTexts
            // 
            this.btnDocTexts.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnDocTexts.ForeColor = System.Drawing.Color.Teal;
            this.btnDocTexts.Image = global::Sepehr.Properties.Resources.DocToolbar;
            this.btnDocTexts.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnDocTexts.ImagePaddingHorizontal = 6;
            this.btnDocTexts.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnDocTexts.Name = "btnDocTexts";
            this.btnDocTexts.Tag = "frmDocTexts";
            this.btnDocTexts.Text = "<b>مدیریت متن ها</b>\r\n<br></br>\r\n<font color=\"#000000\">متن های آماده مدرك.</font>" +
                "";
            this.btnDocTexts.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnDocTypes
            // 
            this.btnDocTypes.BeginGroup = true;
            this.btnDocTypes.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnDocTypes.ForeColor = System.Drawing.Color.Teal;
            this.btnDocTypes.Image = global::Sepehr.Properties.Resources.DocumentSetting;
            this.btnDocTypes.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnDocTypes.ImagePaddingHorizontal = 8;
            this.btnDocTypes.ImagePaddingVertical = 0;
            this.btnDocTypes.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnDocTypes.Name = "btnDocTypes";
            this.btnDocTypes.SplitButton = true;
            this.btnDocTypes.Tag = "frmDocumentsTypes";
            this.btnDocTypes.Text = "<b>انواع مدارك</b>\r\n<br></br>\r\n<font color=\"#000000\">گروه های طبقه بندی مدارك.</f" +
                "ont>";
            this.btnDocTypes.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnBillTemplatesSettings
            // 
            this.btnBillTemplatesSettings.BeginGroup = true;
            this.btnBillTemplatesSettings.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnBillTemplatesSettings.Image = global::Sepehr.Properties.Resources.BillsTemplate;
            this.btnBillTemplatesSettings.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnBillTemplatesSettings.ImagePaddingHorizontal = 8;
            this.btnBillTemplatesSettings.Name = "btnBillTemplatesSettings";
            this.btnBillTemplatesSettings.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnBillTemplates,
            this.btnBillTemplatesAccess,
            this.btnBillServCatExclude,
            this.btnBillDefaultPrinter});
            this.btnBillTemplatesSettings.Text = "<b>قالب های قبوض</b>\r\n<br></br>\r\n<font color=\"#000000\">طراحی و دسترسی ها.</font>";
            // 
            // btnBillTemplates
            // 
            this.btnBillTemplates.BeginGroup = true;
            this.btnBillTemplates.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnBillTemplates.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnBillTemplates.Image = global::Sepehr.Properties.Resources.BillsTemplate;
            this.btnBillTemplates.ImagePaddingHorizontal = 8;
            this.btnBillTemplates.ImagePaddingVertical = 0;
            this.btnBillTemplates.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnBillTemplates.Name = "btnBillTemplates";
            this.btnBillTemplates.Tag = "frmBillTemplates";
            this.btnBillTemplates.Text = "<b>مدیریت قالب ها</b>\r\n<div></div>\r\n<font color=\"#000000\">قالب های قبوض</font>";
            this.btnBillTemplates.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnBillTemplatesAccess
            // 
            this.btnBillTemplatesAccess.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnBillTemplatesAccess.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnBillTemplatesAccess.Image = global::Sepehr.Properties.Resources.UsersSettings;
            this.btnBillTemplatesAccess.ImagePaddingHorizontal = 8;
            this.btnBillTemplatesAccess.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnBillTemplatesAccess.Name = "btnBillTemplatesAccess";
            this.btnBillTemplatesAccess.SubItemsExpandWidth = 14;
            this.btnBillTemplatesAccess.Tag = "frmBillTemplatesAccess";
            this.btnBillTemplatesAccess.Text = "<b>دسترسی قالب ها</b>\r\n<div></div>\r\n<font color=\"#000000\">دسترسی كاربران.</font>";
            this.btnBillTemplatesAccess.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnBillServCatExclude
            // 
            this.btnBillServCatExclude.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnBillServCatExclude.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnBillServCatExclude.Image = global::Sepehr.Properties.Resources.ServicesSettings;
            this.btnBillServCatExclude.ImagePaddingHorizontal = 8;
            this.btnBillServCatExclude.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnBillServCatExclude.Name = "btnBillServCatExclude";
            this.btnBillServCatExclude.SubItemsExpandWidth = 14;
            this.btnBillServCatExclude.Tag = "frmBillServCatExclude";
            this.btnBillServCatExclude.Text = "<b>چاپ خدمات در قبوض</b>\r\n<div></div>\r\n<font color=\"#000000\">دسترسی طبقه بندی خدم" +
                "ات.</font>";
            this.btnBillServCatExclude.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnBillDefaultPrinter
            // 
            this.btnBillDefaultPrinter.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnBillDefaultPrinter.Image = global::Sepehr.Properties.Resources.PrintSettings;
            this.btnBillDefaultPrinter.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnBillDefaultPrinter.ImagePaddingHorizontal = 8;
            this.btnBillDefaultPrinter.Name = "btnBillDefaultPrinter";
            this.btnBillDefaultPrinter.Tag = "frmBillDefaultPrinter";
            this.btnBillDefaultPrinter.Text = "<b>چاپگر پیش فرض قالب ها</b>\r\n<div></div>\r\n<font color=\"#000000\">چاپگر های نصب شد" +
                "ه.</font>";
            this.btnBillDefaultPrinter.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnPacsManage
            // 
            this.btnPacsManage.BeginGroup = true;
            this.btnPacsManage.ForeColor = System.Drawing.Color.Olive;
            this.btnPacsManage.Image = global::Sepehr.Properties.Resources.Dicom;
            this.btnPacsManage.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnPacsManage.ImagePaddingHorizontal = 8;
            this.btnPacsManage.Name = "btnPacsManage";
            this.btnPacsManage.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnPACSModalities,
            this.btnPACSServicesModalities,
            this.btnPACSStudies,
            this.btnPACSServicesStudies});
            this.btnPacsManage.Text = "<b>ارتباط با پكس</b>\r\n<br></br>\r\n<font color=\"#000000\">تنظیمات ارتباط با پكس.</fo" +
                "nt>";
            this.btnPacsManage.Visible = false;
            // 
            // btnPACSModalities
            // 
            this.btnPACSModalities.ForeColor = System.Drawing.Color.Olive;
            this.btnPACSModalities.Image = global::Sepehr.Properties.Resources.Dicom;
            this.btnPACSModalities.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnPACSModalities.ImagePaddingHorizontal = 8;
            this.btnPACSModalities.Name = "btnPACSModalities";
            this.btnPACSModalities.Tag = "frmPACSModalities";
            this.btnPACSModalities.Text = "<b>مدیریت Modality ها</b>\r\n<br></br>\r\n<font color=\"#000000\">افزودن ، ویرایش یا حذ" +
                "ف.</font>";
            this.btnPACSModalities.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnPACSServicesModalities
            // 
            this.btnPACSServicesModalities.ForeColor = System.Drawing.Color.Olive;
            this.btnPACSServicesModalities.Image = global::Sepehr.Properties.Resources.Dicom;
            this.btnPACSServicesModalities.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnPACSServicesModalities.ImagePaddingHorizontal = 8;
            this.btnPACSServicesModalities.Name = "btnPACSServicesModalities";
            this.btnPACSServicesModalities.Tag = "frmPACSServicesModalities";
            this.btnPACSServicesModalities.Text = "<b>ارتباط خدمات و مودالیتی</b>\r\n<br></br>\r\n<font color=\"#000000\">افزودن یا حذف.</" +
                "font>";
            this.btnPACSServicesModalities.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnPACSStudies
            // 
            this.btnPACSStudies.ForeColor = System.Drawing.Color.Olive;
            this.btnPACSStudies.Image = global::Sepehr.Properties.Resources.Dicom;
            this.btnPACSStudies.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnPACSStudies.ImagePaddingHorizontal = 8;
            this.btnPACSStudies.Name = "btnPACSStudies";
            this.btnPACSStudies.Tag = "frmPACSStudies";
            this.btnPACSStudies.Text = "<b>مدیریت ارگان ها</b>\r\n<br></br>\r\n<font color=\"#000000\">افزودن ، ویرایش یا حذف.<" +
                "/font>";
            this.btnPACSStudies.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnPACSServicesStudies
            // 
            this.btnPACSServicesStudies.ForeColor = System.Drawing.Color.Olive;
            this.btnPACSServicesStudies.Image = global::Sepehr.Properties.Resources.Dicom;
            this.btnPACSServicesStudies.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnPACSServicesStudies.ImagePaddingHorizontal = 8;
            this.btnPACSServicesStudies.Name = "btnPACSServicesStudies";
            this.btnPACSServicesStudies.Tag = "frmPACSServicesStudies";
            this.btnPACSServicesStudies.Text = "<b>ارتباط خدمات و ارگان ها</b>\r\n<br></br>\r\n<font color=\"#000000\">افزودن یا حذف.</" +
                "font>";
            this.btnPACSServicesStudies.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnMessagesSettings
            // 
            this.btnMessagesSettings.BeginGroup = true;
            this.btnMessagesSettings.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnMessagesSettings.Image = global::Sepehr.Properties.Resources.SMS_Logo_2;
            this.btnMessagesSettings.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnMessagesSettings.ImagePaddingHorizontal = 8;
            this.btnMessagesSettings.Name = "btnMessagesSettings";
            this.btnMessagesSettings.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnDocMessageTemplate});
            this.btnMessagesSettings.Text = "<b>پیام رسانی</b>\r\n<br></br>\r\n<font color=\"#000000\">تنظیمات ارسال پیام.</font>";
            // 
            // btnDocMessageTemplate
            // 
            this.btnDocMessageTemplate.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnDocMessageTemplate.Image = global::Sepehr.Properties.Resources.SMS_Logo_1;
            this.btnDocMessageTemplate.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnDocMessageTemplate.ImagePaddingHorizontal = 8;
            this.btnDocMessageTemplate.Name = "btnDocMessageTemplate";
            this.btnDocMessageTemplate.Tag = "frmDocMessageTemplate";
            this.btnDocMessageTemplate.Text = "<b>قالب پیام اتمام ریپورت</b>\r\n<br></br>\r\n<font color=\"#000000\">ارسال به بیمار پس" +
                " از ریپورت.</font>";
            this.btnDocMessageTemplate.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnTools
            // 
            this.btnTools.AutoExpandOnClick = true;
            this.btnTools.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnTools.FontBold = true;
            this.btnTools.Image = global::Sepehr.Properties.Resources.Config;
            this.btnTools.ImagePaddingHorizontal = 12;
            this.btnTools.Name = "btnTools";
            this.btnTools.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor();
            this.btnTools.ShowSubItems = false;
            this.btnTools.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnBackup,
            this.btnRestore,
            this.btnRebuildDataBase,
            this.btnDeleteData,
            this.btnEventsViewer});
            this.btnTools.Text = "<font color=\"#6F3198\">ابزارها</font>";
            // 
            // btnBackup
            // 
            this.btnBackup.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnBackup.Image = global::Sepehr.Properties.Resources.Backup;
            this.btnBackup.ImagePaddingHorizontal = 8;
            this.btnBackup.ImagePaddingVertical = 0;
            this.btnBackup.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Tag = "frmBackup";
            this.btnBackup.Text = "<b>پشتیبانی</b>\r\n<div></div>\r\n<font color=\"#000000\">ایجاد فایل پشتیبانی از بانك.<" +
                "/font>";
            this.btnBackup.Click += new System.EventHandler(this.btnTools_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnRestore.Image = global::Sepehr.Properties.Resources.Restore;
            this.btnRestore.ImagePaddingHorizontal = 8;
            this.btnRestore.ImagePaddingVertical = 0;
            this.btnRestore.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Tag = "frmRestore";
            this.btnRestore.Text = "<b>بازیابی</b>\r\n<br></br>\r\n<font color=\"#000000\">بازیابی فایل پشتیبانی قبلی.</fon" +
                "t>";
            this.btnRestore.Click += new System.EventHandler(this.btnTools_Click);
            // 
            // btnRebuildDataBase
            // 
            this.btnRebuildDataBase.BeginGroup = true;
            this.btnRebuildDataBase.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnRebuildDataBase.Image = global::Sepehr.Properties.Resources.RebuildDatabase;
            this.btnRebuildDataBase.ImagePaddingHorizontal = 8;
            this.btnRebuildDataBase.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnRebuildDataBase.Name = "btnRebuildDataBase";
            this.btnRebuildDataBase.Tag = "frmRebuildDatabase";
            this.btnRebuildDataBase.Text = "<b>بازسازی بانك</b>\r\n<div></div>\r\n<font color=\"#000000\">افزایش سرعت ، كاهش حجم.</" +
                "font>";
            this.btnRebuildDataBase.Click += new System.EventHandler(this.btnTools_Click);
            // 
            // btnDeleteData
            // 
            this.btnDeleteData.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnDeleteData.Image = global::Sepehr.Properties.Resources.DeleteMed;
            this.btnDeleteData.ImagePaddingHorizontal = 8;
            this.btnDeleteData.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnDeleteData.Name = "btnDeleteData";
            this.btnDeleteData.Tag = "frmRemoveData";
            this.btnDeleteData.Text = "<b>حذف اطلاعات</b>\r\n<br></br>\r\n<font color=\"#000000\">حذف پرونده ها بر اساس تاریخ." +
                "</font>";
            this.btnDeleteData.Click += new System.EventHandler(this.btnTools_Click);
            // 
            // btnEventsViewer
            // 
            this.btnEventsViewer.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnEventsViewer.Image = global::Sepehr.Properties.Resources.EventsLogs;
            this.btnEventsViewer.ImagePaddingHorizontal = 8;
            this.btnEventsViewer.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnEventsViewer.Name = "btnEventsViewer";
            this.btnEventsViewer.Tag = "frmEventViewer";
            this.btnEventsViewer.Text = "<b>نمایش رخدادها</b>\r\n<br></br>\r\n<font color=\"#000000\">رخدادهای مهم سیستم.</font>" +
                "";
            this.btnEventsViewer.Visible = false;
            this.btnEventsViewer.Click += new System.EventHandler(this.btnTools_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.AutoExpandOnClick = true;
            this.btnHelp.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnHelp.FontBold = true;
            this.btnHelp.Image = global::Sepehr.Properties.Resources.Help;
            this.btnHelp.ImageFixedSize = new System.Drawing.Size(40, 40);
            this.btnHelp.ImagePaddingHorizontal = 12;
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor();
            this.btnHelp.ShowSubItems = false;
            this.btnHelp.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnUserGuide,
            this.btnFaq,
            this.btnLicenseList,
            this.btnContactUs,
            this.btnAbout});
            this.btnHelp.Text = "<font color=\"#000000\">كمك</font>";
            // 
            // btnUserGuide
            // 
            this.btnUserGuide.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnUserGuide.FontBold = true;
            this.btnUserGuide.Image = global::Sepehr.Properties.Resources.HowTo;
            this.btnUserGuide.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnUserGuide.ImagePaddingHorizontal = 8;
            this.btnUserGuide.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnUserGuide.Name = "btnUserGuide";
            this.btnUserGuide.Tag = "frmUserLearning";
            this.btnUserGuide.Text = "آموزش كاربری";
            this.btnUserGuide.Visible = false;
            this.btnUserGuide.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnFaq
            // 
            this.btnFaq.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnFaq.FontBold = true;
            this.btnFaq.Image = global::Sepehr.Properties.Resources.HelpMed;
            this.btnFaq.ImagePaddingHorizontal = 8;
            this.btnFaq.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnFaq.Name = "btnFaq";
            this.btnFaq.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F1);
            this.btnFaq.Text = "سوالات رایج";
            this.btnFaq.Visible = false;
            this.btnFaq.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnLicenseList
            // 
            this.btnLicenseList.BeginGroup = true;
            this.btnLicenseList.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnLicenseList.FontBold = true;
            this.btnLicenseList.Image = global::Sepehr.Properties.Resources.Licenses;
            this.btnLicenseList.ImagePaddingHorizontal = 8;
            this.btnLicenseList.ImagePaddingVertical = 10;
            this.btnLicenseList.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnLicenseList.Name = "btnLicenseList";
            this.btnLicenseList.Tag = "frmLicenseList";
            this.btnLicenseList.Text = "مجوزها";
            this.btnLicenseList.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnContactUs
            // 
            this.btnContactUs.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnContactUs.Image = global::Sepehr.Properties.Resources.ContactUs;
            this.btnContactUs.ImagePaddingHorizontal = 8;
            this.btnContactUs.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnContactUs.Name = "btnContactUs";
            this.btnContactUs.Tag = "frmContactUs";
            this.btnContactUs.Text = "ارتباط با ما";
            this.btnContactUs.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnAbout.Image = global::Sepehr.Properties.Resources.SepehrIcon;
            this.btnAbout.ImagePaddingHorizontal = 8;
            this.btnAbout.ImagePaddingVertical = 10;
            this.btnAbout.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Tag = "frmAbout";
            this.btnAbout.Text = "درباره سپهر...";
            this.btnAbout.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnRefreshSettings
            // 
            this.btnRefreshSettings.ForeColor = System.Drawing.Color.White;
            this.btnRefreshSettings.Image = global::Sepehr.Properties.Resources.Refresh;
            this.btnRefreshSettings.ImagePaddingHorizontal = 8;
            this.btnRefreshSettings.Name = "btnRefreshSettings";
            this.btnRefreshSettings.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor();
            this.btnRefreshSettings.Text = "<b>بازخوانی <div></div>تنظیمات</b>";
            this.btnRefreshSettings.Click += new System.EventHandler(this.btnRefreshSettings_Click);
            // 
            // buttonItem3
            // 
            this.buttonItem3.ImagePaddingHorizontal = 8;
            this.buttonItem3.Name = "buttonItem3";
            this.buttonItem3.Text = "1-1-1- ریز مراجعات";
            // 
            // buttonItem4
            // 
            this.buttonItem4.ImagePaddingHorizontal = 8;
            this.buttonItem4.Name = "buttonItem4";
            this.buttonItem4.Text = "1-1-2- مراجعات به تفكیك وضعیت";
            // 
            // buttonItem6
            // 
            this.buttonItem6.ImagePaddingHorizontal = 8;
            this.buttonItem6.Name = "buttonItem6";
            this.buttonItem6.Text = "1-2-1- مراجعات به تفكیك پزشك";
            // 
            // buttonItem7
            // 
            this.buttonItem7.ImagePaddingHorizontal = 8;
            this.buttonItem7.Name = "buttonItem7";
            this.buttonItem7.Text = "1-2-2- مراجعات به تفكیك تخصص";
            // 
            // buttonItem8
            // 
            this.buttonItem8.ImagePaddingHorizontal = 8;
            this.buttonItem8.Name = "buttonItem8";
            this.buttonItem8.Text = "1-2-3- به تفكیك پزشك و طبقه بندی خدمت";
            // 
            // buttonItem11
            // 
            this.buttonItem11.ImagePaddingHorizontal = 8;
            this.buttonItem11.Name = "buttonItem11";
            this.buttonItem11.Text = "1-3-2 پذیرش كنندگان";
            // 
            // buttonItem12
            // 
            this.buttonItem12.ImagePaddingHorizontal = 8;
            this.buttonItem12.Name = "buttonItem12";
            this.buttonItem12.Text = "1-3-3 صندوقداران";
            // 
            // buttonItem13
            // 
            this.buttonItem13.ImagePaddingHorizontal = 8;
            this.buttonItem13.Name = "buttonItem13";
            this.buttonItem13.Text = "1-3-4 تایپیست ها";
            // 
            // dgvRefData
            // 
            this.dgvRefData.AllowUserToAddRows = false;
            this.dgvRefData.AllowUserToDeleteRows = false;
            this.dgvRefData.AllowUserToOrderColumns = true;
            this.dgvRefData.AllowUserToResizeRows = false;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(255)))), ((int)(((byte)(210)))));
            this.dgvRefData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvRefData.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(250)))));
            this.dgvRefData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvRefData.CausesValidation = false;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRefData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvRefData.ColumnHeadersHeight = 25;
            this.dgvRefData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRefData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColRefRow,
            this.ColRefNo,
            this.ColRefDate,
            this.ColRefIns1,
            this.ColRefIns2,
            this.ColRefPeriod,
            this.ColRefServCat,
            this.ColRefDocCount,
            this.ColRefLastDoc,
            this.ColIns1PriceTotal,
            this.ColIns1PartTotal,
            this.ColIns1PatientPart,
            this.ColIns2PriceTotal,
            this.ColIns2PartTotal});
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle26.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle26.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle26.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRefData.DefaultCellStyle = dataGridViewCellStyle26;
            this.dgvRefData.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvRefData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvRefData.Location = new System.Drawing.Point(0, 428);
            this.dgvRefData.MultiSelect = false;
            this.dgvRefData.Name = "dgvRefData";
            this.dgvRefData.ReadOnly = true;
            this.dgvRefData.RowHeadersVisible = false;
            this.dgvRefData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvRefData.RowTemplate.Height = 30;
            this.dgvRefData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRefData.Size = new System.Drawing.Size(792, 119);
            this.dgvRefData.StandardTab = true;
            this.dgvRefData.TabIndex = 15;
            this.dgvRefData.TabStop = false;
            this.dgvRefData.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvRefData_CellMouseClick);
            this.dgvRefData.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvRefData_CellMouseDoubleClick);
            // 
            // cmsRefData
            // 
            this.cmsRefData.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmsRefData.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.cmsdgvRefData});
            this.cmsRefData.Location = new System.Drawing.Point(110, 135);
            this.cmsRefData.Name = "cmsRefData";
            this.cmsRefData.Size = new System.Drawing.Size(136, 25);
            this.cmsRefData.Stretch = true;
            this.cmsRefData.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.cmsRefData.TabIndex = 16;
            this.cmsRefData.TabStop = false;
            this.cmsRefData.Text = "منو";
            // 
            // cmsdgvRefData
            // 
            this.cmsdgvRefData.AutoExpandOnClick = true;
            this.cmsdgvRefData.ImagePaddingHorizontal = 8;
            this.cmsdgvRefData.Name = "cmsdgvRefData";
            this.cmsdgvRefData.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnRefAdmit,
            this.btnRefAccount,
            this.btnRefBills,
            this.btnRefDocs,
            this.btnRefLastDoc,
            this.btnRefNewDoc,
            this.btnRefPrintDoc,
            this.btnRefRemove});
            this.cmsdgvRefData.SubItemsExpandWidth = 15;
            this.cmsdgvRefData.Text = "منوی جدول مراجعات";
            this.cmsdgvRefData.Visible = false;
            this.cmsdgvRefData.PopupOpen += new DevComponents.DotNetBar.DotNetBarManager.PopupOpenEventHandler(this.cmsdgvRefData_PopupOpen);
            // 
            // btnRefAdmit
            // 
            this.btnRefAdmit.ForeColor = System.Drawing.Color.Blue;
            this.btnRefAdmit.Image = global::Sepehr.Properties.Resources.PatLastRef;
            this.btnRefAdmit.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnRefAdmit.ImagePaddingHorizontal = 8;
            this.btnRefAdmit.Name = "btnRefAdmit";
            this.btnRefAdmit.Text = "<b>نمایش مراجعه...</b>\r\n<div></div>\r\n<font color=\"#000000\">نمایش اطلاعات مراجعه.<" +
                "/font>";
            this.btnRefAdmit.Click += new System.EventHandler(this.btnRefAdmit_Click);
            // 
            // btnRefAccount
            // 
            this.btnRefAccount.BeginGroup = true;
            this.btnRefAccount.ForeColor = System.Drawing.Color.Green;
            this.btnRefAccount.Image = global::Sepehr.Properties.Resources.RefAccount;
            this.btnRefAccount.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnRefAccount.ImagePaddingHorizontal = 8;
            this.btnRefAccount.Name = "btnRefAccount";
            this.btnRefAccount.Text = "<b>حساب...</b>\r\n<div></div>\r\n<font color=\"#000000\">نمایش حساب مراجعه.</font>";
            this.btnRefAccount.Click += new System.EventHandler(this.btnRefAccount_Click);
            // 
            // btnRefBills
            // 
            this.btnRefBills.BeginGroup = true;
            this.btnRefBills.ForeColor = System.Drawing.Color.Black;
            this.btnRefBills.Image = global::Sepehr.Properties.Resources.PrintBill;
            this.btnRefBills.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnRefBills.ImagePaddingHorizontal = 8;
            this.btnRefBills.Name = "btnRefBills";
            this.btnRefBills.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.lblRefBill,
            this.iContainerRefBill,
            this.sliderRefBillQty,
            this.btnRefBillPrint});
            this.btnRefBills.Text = "<b>چاپ قبض</b>\r\n<div></div>\r\n<font color=\"#000000\">چاپ قبض مراجعه.</font>";
            // 
            // lblRefBill
            // 
            this.lblRefBill.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblRefBill.Name = "lblRefBill";
            this.lblRefBill.Text = "قالب قبض:";
            // 
            // iContainerRefBill
            // 
            this.iContainerRefBill.Name = "iContainerRefBill";
            this.iContainerRefBill.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.cboRefBill});
            // 
            // cboRefBill
            // 
            this.cboRefBill.CanCustomize = false;
            this.cboRefBill.ComboWidth = 110;
            this.cboRefBill.DropDownHeight = 50;
            this.cboRefBill.DropDownWidth = 50;
            this.cboRefBill.ItemHeight = 17;
            this.cboRefBill.Name = "cboRefBill";
            this.cboRefBill.ShowSubItems = false;
            this.cboRefBill.Stretch = true;
            this.cboRefBill.WatermarkText = "قالب چاپ";
            // 
            // sliderRefBillQty
            // 
            this.sliderRefBillQty.AutoCollapseOnClick = false;
            this.sliderRefBillQty.LabelPosition = DevComponents.DotNetBar.eSliderLabelPosition.Top;
            this.sliderRefBillQty.LabelWidth = 50;
            this.sliderRefBillQty.Maximum = 5;
            this.sliderRefBillQty.Minimum = 1;
            this.sliderRefBillQty.Name = "sliderRefBillQty";
            this.sliderRefBillQty.Text = "تعداد چاپ: 1 نسخه";
            this.sliderRefBillQty.TrackMarker = false;
            this.sliderRefBillQty.Value = 1;
            this.sliderRefBillQty.Width = 50;
            this.sliderRefBillQty.ValueChanged += new System.EventHandler(this.sliderRefBillQty_ValueChanged);
            // 
            // btnRefBillPrint
            // 
            this.btnRefBillPrint.FontBold = true;
            this.btnRefBillPrint.HotFontBold = true;
            this.btnRefBillPrint.Image = global::Sepehr.Properties.Resources.PrintGrid;
            this.btnRefBillPrint.ImagePaddingHorizontal = 8;
            this.btnRefBillPrint.Name = "btnRefBillPrint";
            this.btnRefBillPrint.Text = "چاپ";
            this.btnRefBillPrint.Click += new System.EventHandler(this.btnRefBillPrint_Click);
            // 
            // btnRefDocs
            // 
            this.btnRefDocs.BeginGroup = true;
            this.btnRefDocs.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnRefDocs.Image = global::Sepehr.Properties.Resources.RefDocuments;
            this.btnRefDocs.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnRefDocs.ImagePaddingHorizontal = 8;
            this.btnRefDocs.Name = "btnRefDocs";
            this.btnRefDocs.Text = "<b>مدیریت مدارک...</b>\r\n<div></div>\r\n<font color=\"#000000\">مدیریت مدارك مراجعه.</" +
                "font>";
            this.btnRefDocs.Click += new System.EventHandler(this.btnRefDocs_Click);
            // 
            // btnRefLastDoc
            // 
            this.btnRefLastDoc.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnRefLastDoc.Image = global::Sepehr.Properties.Resources.RefLastDoc;
            this.btnRefLastDoc.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnRefLastDoc.ImagePaddingHorizontal = 8;
            this.btnRefLastDoc.Name = "btnRefLastDoc";
            this.btnRefLastDoc.Text = "<b>ویرایش آخرین جواب...</b>\r\n<div></div>\r\n<font color=\"#000000\">ویرایش آخرین جواب" +
                " ثبت شده.</font>";
            this.btnRefLastDoc.Click += new System.EventHandler(this.btnRefLastDoc_Click);
            // 
            // btnRefNewDoc
            // 
            this.btnRefNewDoc.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnRefNewDoc.Image = global::Sepehr.Properties.Resources.DocumentAdd;
            this.btnRefNewDoc.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnRefNewDoc.ImagePaddingHorizontal = 8;
            this.btnRefNewDoc.Name = "btnRefNewDoc";
            this.btnRefNewDoc.Text = "<b>جواب جدید...</b>\r\n<div></div>\r\n<font color=\"#000000\">جوابدهی جدید برای مراجعه." +
                "</font>";
            this.btnRefNewDoc.Click += new System.EventHandler(this.btnRefNewDoc_Click);
            // 
            // btnRefPrintDoc
            // 
            this.btnRefPrintDoc.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnRefPrintDoc.Image = global::Sepehr.Properties.Resources.PrintGrid;
            this.btnRefPrintDoc.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnRefPrintDoc.ImagePaddingHorizontal = 8;
            this.btnRefPrintDoc.Name = "btnRefPrintDoc";
            this.btnRefPrintDoc.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnRefLastDocPrint,
            this.btnRefAllDocPrint});
            this.btnRefPrintDoc.Text = "<b>چاپ جواب</b>\r\n<div></div>\r\n<font color=\"#000000\">چاپ جواب ثبت شده.</font>";
            // 
            // btnRefLastDocPrint
            // 
            this.btnRefLastDocPrint.FontBold = true;
            this.btnRefLastDocPrint.HotFontBold = true;
            this.btnRefLastDocPrint.Image = global::Sepehr.Properties.Resources.PrintBill;
            this.btnRefLastDocPrint.ImagePaddingHorizontal = 8;
            this.btnRefLastDocPrint.Name = "btnRefLastDocPrint";
            this.btnRefLastDocPrint.Text = "چاپ آخرین\r\nجواب مراجعه";
            this.btnRefLastDocPrint.Click += new System.EventHandler(this.btnRefLastDocPrint_Click);
            // 
            // btnRefAllDocPrint
            // 
            this.btnRefAllDocPrint.FontBold = true;
            this.btnRefAllDocPrint.HotFontBold = true;
            this.btnRefAllDocPrint.Image = global::Sepehr.Properties.Resources.PrintGrid;
            this.btnRefAllDocPrint.ImagePaddingHorizontal = 8;
            this.btnRefAllDocPrint.Name = "btnRefAllDocPrint";
            this.btnRefAllDocPrint.Text = "چاپ همه\r\nجواب های مراجعه";
            this.btnRefAllDocPrint.Click += new System.EventHandler(this.btnRefAllDocPrint_Click);
            // 
            // btnRefRemove
            // 
            this.btnRefRemove.BeginGroup = true;
            this.btnRefRemove.CanCustomize = false;
            this.btnRefRemove.ForeColor = System.Drawing.Color.Red;
            this.btnRefRemove.Image = global::Sepehr.Properties.Resources.DeleteMed;
            this.btnRefRemove.ImagePaddingHorizontal = 8;
            this.btnRefRemove.Name = "btnRefRemove";
            this.btnRefRemove.Text = "<u><b>حذف مراجعه</b></u>\r\n<div></div>\r\n<font color=\"#000000\">حذف كامل اطلاعات مرا" +
                "جعه.</font>";
            this.btnRefRemove.Click += new System.EventHandler(this.btnRefRemove_Click);
            // 
            // ColRefRow
            // 
            this.ColRefRow.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColRefRow.DataPropertyName = "RowID";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColRefRow.DefaultCellStyle = dataGridViewCellStyle13;
            this.ColRefRow.HeaderText = "ردیف";
            this.ColRefRow.Name = "ColRefRow";
            this.ColRefRow.ReadOnly = true;
            this.ColRefRow.Width = 40;
            // 
            // ColRefNo
            // 
            this.ColRefNo.DataPropertyName = "RefID";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("B Titr", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.Navy;
            this.ColRefNo.DefaultCellStyle = dataGridViewCellStyle14;
            this.ColRefNo.HeaderText = "كد مراجعه";
            this.ColRefNo.Name = "ColRefNo";
            this.ColRefNo.ReadOnly = true;
            // 
            // ColRefDate
            // 
            this.ColRefDate.DataPropertyName = "RefDate";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle15.NullValue = "\"بدون مراجعه\"";
            this.ColRefDate.DefaultCellStyle = dataGridViewCellStyle15;
            this.ColRefDate.HeaderText = "تاریخ مراجعه";
            this.ColRefDate.Name = "ColRefDate";
            this.ColRefDate.ReadOnly = true;
            this.ColRefDate.ToolTipText = "تاریخ مراجعه";
            // 
            // ColRefIns1
            // 
            this.ColRefIns1.DataPropertyName = "Ins1Name";
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold);
            this.ColRefIns1.DefaultCellStyle = dataGridViewCellStyle16;
            this.ColRefIns1.HeaderText = "بیمه اول";
            this.ColRefIns1.Name = "ColRefIns1";
            this.ColRefIns1.ReadOnly = true;
            // 
            // ColRefIns2
            // 
            this.ColRefIns2.DataPropertyName = "Ins2Name";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.Green;
            this.ColRefIns2.DefaultCellStyle = dataGridViewCellStyle17;
            this.ColRefIns2.HeaderText = "بیمه دوم";
            this.ColRefIns2.Name = "ColRefIns2";
            this.ColRefIns2.ReadOnly = true;
            // 
            // ColRefPeriod
            // 
            this.ColRefPeriod.DataPropertyName = "Period";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.Blue;
            this.ColRefPeriod.DefaultCellStyle = dataGridViewCellStyle18;
            this.ColRefPeriod.HeaderText = "توالی";
            this.ColRefPeriod.Name = "ColRefPeriod";
            this.ColRefPeriod.ReadOnly = true;
            this.ColRefPeriod.Width = 40;
            // 
            // ColRefServCat
            // 
            this.ColRefServCat.DataPropertyName = "FirstServiceCategory";
            this.ColRefServCat.HeaderText = "طبقه بندی اولین خدمت";
            this.ColRefServCat.Name = "ColRefServCat";
            this.ColRefServCat.ReadOnly = true;
            this.ColRefServCat.Width = 151;
            // 
            // ColRefDocCount
            // 
            this.ColRefDocCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColRefDocCount.DataPropertyName = "DocCount";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColRefDocCount.DefaultCellStyle = dataGridViewCellStyle19;
            this.ColRefDocCount.HeaderText = "مدارك";
            this.ColRefDocCount.Name = "ColRefDocCount";
            this.ColRefDocCount.ReadOnly = true;
            this.ColRefDocCount.ToolTipText = "تعداد مدارك مراجعه";
            this.ColRefDocCount.Width = 50;
            // 
            // ColRefLastDoc
            // 
            this.ColRefLastDoc.DataPropertyName = "LastDocDate";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ColRefLastDoc.DefaultCellStyle = dataGridViewCellStyle20;
            this.ColRefLastDoc.HeaderText = "آخرین مدرك";
            this.ColRefLastDoc.Name = "ColRefLastDoc";
            this.ColRefLastDoc.ReadOnly = true;
            this.ColRefLastDoc.ToolTipText = "تاریخ و ساعت آخرین مدرك ثبت شده برای مراجعه";
            // 
            // ColIns1PriceTotal
            // 
            this.ColIns1PriceTotal.DataPropertyName = "Ins1PriceTotal";
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("B Titr", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle21.Format = "N0";
            this.ColIns1PriceTotal.DefaultCellStyle = dataGridViewCellStyle21;
            this.ColIns1PriceTotal.HeaderText = "قیمت بیمه 1";
            this.ColIns1PriceTotal.Name = "ColIns1PriceTotal";
            this.ColIns1PriceTotal.ReadOnly = true;
            // 
            // ColIns1PartTotal
            // 
            this.ColIns1PartTotal.DataPropertyName = "Ins1PartTotal";
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("B Titr", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle22.Format = "N0";
            this.ColIns1PartTotal.DefaultCellStyle = dataGridViewCellStyle22;
            this.ColIns1PartTotal.HeaderText = "سهم بیمه 1";
            this.ColIns1PartTotal.Name = "ColIns1PartTotal";
            this.ColIns1PartTotal.ReadOnly = true;
            // 
            // ColIns1PatientPart
            // 
            this.ColIns1PatientPart.DataPropertyName = "Ins1PatientPart";
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("B Titr", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle23.Format = "N0";
            this.ColIns1PatientPart.DefaultCellStyle = dataGridViewCellStyle23;
            this.ColIns1PatientPart.HeaderText = "سهم بیمار";
            this.ColIns1PatientPart.Name = "ColIns1PatientPart";
            this.ColIns1PatientPart.ReadOnly = true;
            // 
            // ColIns2PriceTotal
            // 
            this.ColIns2PriceTotal.DataPropertyName = "Ins2PriceTotal";
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("B Titr", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle24.Format = "N0";
            this.ColIns2PriceTotal.DefaultCellStyle = dataGridViewCellStyle24;
            this.ColIns2PriceTotal.HeaderText = "قیمت بیمه 2";
            this.ColIns2PriceTotal.Name = "ColIns2PriceTotal";
            this.ColIns2PriceTotal.ReadOnly = true;
            // 
            // ColIns2PartTotal
            // 
            this.ColIns2PartTotal.DataPropertyName = "Ins2PartTotal";
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle25.Font = new System.Drawing.Font("B Titr", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle25.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle25.Format = "N0";
            this.ColIns2PartTotal.DefaultCellStyle = dataGridViewCellStyle25;
            this.ColIns2PartTotal.HeaderText = "سهم بیمه 2";
            this.ColIns2PartTotal.Name = "ColIns2PartTotal";
            this.ColIns2PartTotal.ReadOnly = true;
            // 
            // frmSepehrMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.cmsRefData);
            this.Controls.Add(this.cmsPatData);
            this.Controls.Add(this.dgvPatData);
            this.Controls.Add(this.dgvRefData);
            this.Controls.Add(this.RBarSearchPatients);
            this.Controls.Add(this.FormMenu);
            this.Controls.Add(this.barStatus);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmSepehrMainForm";
            this.Opacity = 0.01;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "رایان پرتونگار - سیستم مدیریت تصویربرداری سپهر";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.cmsPatData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRefData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmsRefData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ContextMenuBar cmsPatData;
        private DevComponents.DotNetBar.ButtonItem cmsdgvPatData;
        private DevComponents.DotNetBar.ButtonItem btnNewRef;
        private DevComponents.DotNetBar.ButtonItem btnLastRef;
        private DevComponents.DotNetBar.ButtonItem btnLastAccount;
        private DevComponents.DotNetBar.ButtonItem btnEditLastDoc;
        private DevComponents.DotNetBar.ButtonItem btnDeletePatient;
        private DevComponents.DotNetBar.ButtonItem btnPatientFile;
        private DevComponents.DotNetBar.ButtonItem btnManageDoc;
        private DevComponents.DotNetBar.Bar barStatus;
        private DevComponents.DotNetBar.ItemContainer iContainerCurrentUserName;
        private DevComponents.DotNetBar.LabelItem lblCurrentUserName;
        private DevComponents.DotNetBar.LabelItem txtCurrentUserName;
        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        private System.ComponentModel.BackgroundWorker BWFormThread;
        private DevComponents.DotNetBar.ButtonItem btnDicomImages;
        private DevComponents.DotNetBar.ButtonItem btnLastDicomImage;
        private DevComponents.DotNetBar.ButtonItem btnNewDoc;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvPatData;
        private DevComponents.DotNetBar.RibbonBar RBarSearchPatients;
        private DevComponents.DotNetBar.ButtonItem btnPrevPatient;
        private DevComponents.DotNetBar.ItemContainer iContainerPatientID;
        private DevComponents.DotNetBar.LabelItem lblSearchByPatientID;
        private DevComponents.DotNetBar.ItemContainer iContainerPatientIDTextBox;
        private DevComponents.DotNetBar.TextBoxItem txtPatientID;
        private DevComponents.DotNetBar.ButtonItem btnNextPatient;
        private DevComponents.DotNetBar.ItemContainer iContainerSearchPatient;
        private DevComponents.DotNetBar.ItemContainer iContainerName;
        private DevComponents.DotNetBar.LabelItem lblPName;
        private DevComponents.DotNetBar.TextBoxItem txtFName;
        private DevComponents.DotNetBar.ItemContainer iContainerLName;
        private DevComponents.DotNetBar.LabelItem lblPLName;
        private DevComponents.DotNetBar.TextBoxItem txtLName;
        private DevComponents.DotNetBar.ItemContainer iContainerAge;
        private DevComponents.DotNetBar.LabelItem lblAge;
        private DevComponents.DotNetBar.TextBoxItem txtAge;
        private DevComponents.DotNetBar.ButtonItem btnSearch;
        private DevComponents.DotNetBar.ButtonItem btnAdvancedSearch;
        private DevComponents.DotNetBar.ButtonItem btnClearGrid;
        private DevComponents.DotNetBar.ButtonItem btnPrintGrid;
        private DevComponents.DotNetBar.RibbonBar FormMenu;
        private DevComponents.DotNetBar.ButtonItem btnLastPatients;
        private DevComponents.DotNetBar.ItemContainer IContainerStart;
        private DevComponents.DotNetBar.ItemContainer iContainerStartButton;
        private DevComponents.DotNetBar.ItemContainer iContainerRecentPatients;
        private DevComponents.DotNetBar.LabelItem lblRecentPatients;
        private DevComponents.DotNetBar.ButtonItem btnChangePassword;
        private DevComponents.DotNetBar.ButtonItem btnUserSettings;
        private DevComponents.DotNetBar.ButtonItem btnRefreshSettings;
        private DevComponents.DotNetBar.ButtonItem btnFile;
        private DevComponents.DotNetBar.ButtonItem btnAppointments;
        private DevComponents.DotNetBar.ButtonItem btnNewPatientRef;
        private DevComponents.DotNetBar.ButtonItem btnNewPatient;
        private DevComponents.DotNetBar.ButtonItem btnCashManage;
        private DevComponents.DotNetBar.ButtonItem btnCashPatients;
        private DevComponents.DotNetBar.ButtonItem btnCashReport;
        private DevComponents.DotNetBar.ButtonItem btnDocumentPatients;
        private DevComponents.DotNetBar.ButtonItem btnReport;
        private DevComponents.DotNetBar.ButtonItem btnR8;
        private DevComponents.DotNetBar.ButtonItem btnR1_3_1;
        private DevComponents.DotNetBar.ButtonItem btnR1_3_2;
        private DevComponents.DotNetBar.ButtonItem btnR1_3_3;
        private DevComponents.DotNetBar.ButtonItem btnR1_3_4;
        private DevComponents.DotNetBar.ButtonItem btnGeneralReports;
        private DevComponents.DotNetBar.ButtonItem btnR1;
        private DevComponents.DotNetBar.ButtonItem btnR1_1;
        private DevComponents.DotNetBar.ButtonItem btnR1_2;
        private DevComponents.DotNetBar.ButtonItem btnR2;
        private DevComponents.DotNetBar.ButtonItem btnR2_1;
        private DevComponents.DotNetBar.ButtonItem btnR3;
        private DevComponents.DotNetBar.ButtonItem btnR3_1;
        private DevComponents.DotNetBar.ButtonItem btnR4;
        private DevComponents.DotNetBar.ButtonItem btnR4_1;
        private DevComponents.DotNetBar.ButtonItem btnR4_2;
        private DevComponents.DotNetBar.ButtonItem btnR4_3;
        private DevComponents.DotNetBar.ButtonItem btnR5;
        private DevComponents.DotNetBar.ButtonItem btnR5_1;
        private DevComponents.DotNetBar.ButtonItem btnR6;
        private DevComponents.DotNetBar.ButtonItem btnR6_1;
        private DevComponents.DotNetBar.ButtonItem btnBillTemplates;
        private DevComponents.DotNetBar.ButtonItem btnBillTemplatesAccess;
        private DevComponents.DotNetBar.ButtonItem btnSettings;
        private DevComponents.DotNetBar.ButtonItem btnSecuritySettings;
        private DevComponents.DotNetBar.ButtonItem btnUsers;
        private DevComponents.DotNetBar.ButtonItem btnGroups;
        private DevComponents.DotNetBar.ButtonItem btnUsersGrouping;
        private DevComponents.DotNetBar.ButtonItem btnACLManage;
        private DevComponents.DotNetBar.ButtonItem btnSchSettings;
        private DevComponents.DotNetBar.ButtonItem btnAppointmentsDef;
        private DevComponents.DotNetBar.ButtonItem btnSchAddinFields;
        private DevComponents.DotNetBar.ButtonItem btnPatientsSettings;
        private DevComponents.DotNetBar.ButtonItem btnPatAddinData;
        private DevComponents.DotNetBar.ButtonItem btnJobs;
        private DevComponents.DotNetBar.ButtonItem btnNamesBank;
        private DevComponents.DotNetBar.ButtonItem btnLocations;
        private DevComponents.DotNetBar.ButtonItem btnCountries;
        private DevComponents.DotNetBar.ButtonItem btnStates;
        private DevComponents.DotNetBar.ButtonItem btnCities;
        private DevComponents.DotNetBar.ButtonItem btnRefSettings;
        private DevComponents.DotNetBar.ButtonItem btnRefAddinData;
        private DevComponents.DotNetBar.ButtonItem btnPerformers;
        private DevComponents.DotNetBar.ButtonItem btnPhysiciansSpecs;
        private DevComponents.DotNetBar.ButtonItem btnPhysicians;
        private DevComponents.DotNetBar.ButtonItem btnRefStatus;
        private DevComponents.DotNetBar.ButtonItem btnServInsSettings;
        private DevComponents.DotNetBar.ButtonItem btnServices;
        private DevComponents.DotNetBar.ButtonItem btnServiceGrouping;
        private DevComponents.DotNetBar.ButtonItem btnInsurances;
        private DevComponents.DotNetBar.ButtonItem btnServiceTypes;
        private DevComponents.DotNetBar.ButtonItem btnServiceGroups;
        private DevComponents.DotNetBar.ButtonItem btnAccountCashSettings;
        private DevComponents.DotNetBar.ButtonItem btnCashes;
        private DevComponents.DotNetBar.ButtonItem btnCashCashiers;
        private DevComponents.DotNetBar.ButtonItem btnBanks;
        private DevComponents.DotNetBar.ButtonItem btnCostDiscountTypes;
        private DevComponents.DotNetBar.ButtonItem btnDocSettings;
        private DevComponents.DotNetBar.ButtonItem btnDocTemplates;
        private DevComponents.DotNetBar.ButtonItem btnDocTypes;
        private DevComponents.DotNetBar.ButtonItem btnTools;
        private DevComponents.DotNetBar.ButtonItem btnBackup;
        private DevComponents.DotNetBar.ButtonItem btnRestore;
        private DevComponents.DotNetBar.ButtonItem btnRebuildDataBase;
        private DevComponents.DotNetBar.ButtonItem btnDeleteData;
        private DevComponents.DotNetBar.ButtonItem btnEventsViewer;
        private DevComponents.DotNetBar.ButtonItem btnHelp;
        private DevComponents.DotNetBar.ButtonItem btnUserGuide;
        private DevComponents.DotNetBar.ButtonItem btnFaq;
        private DevComponents.DotNetBar.ButtonItem btnContactUs;
        private DevComponents.DotNetBar.ButtonItem btnLicenseList;
        private DevComponents.DotNetBar.ButtonItem btnAbout;
        private DevComponents.DotNetBar.ButtonItem btnPacsManage;
        private DevComponents.DotNetBar.ButtonItem btnPACSModalities;
        private DevComponents.DotNetBar.ButtonItem btnR5_2;
        private DevComponents.DotNetBar.ButtonItem btnR5_3;
        private DevComponents.DotNetBar.ButtonItem btnR6_2;
        private DevComponents.DotNetBar.ButtonItem btnBillTemplatesSettings;
        private DevComponents.DotNetBar.ButtonItem btnDefaultServicePerformers;
        private DevComponents.DotNetBar.ButtonItem btnSearchHelp;
        private DevComponents.DotNetBar.ItemContainer iContainerDbConnection;
        private DevComponents.DotNetBar.LabelItem lblCSName;
        private DevComponents.DotNetBar.LabelItem txtCSName;
        private DevComponents.DotNetBar.ButtonItem btnR2_2;
        private DevComponents.DotNetBar.ButtonItem btnR3_2;
        private DevComponents.DotNetBar.ButtonItem btnSpecialReports;
        private DevComponents.DotNetBar.ButtonItem buttonItem3;
        private DevComponents.DotNetBar.ButtonItem buttonItem4;
        private DevComponents.DotNetBar.ButtonItem buttonItem6;
        private DevComponents.DotNetBar.ButtonItem buttonItem7;
        private DevComponents.DotNetBar.ButtonItem buttonItem8;
        private DevComponents.DotNetBar.ButtonItem buttonItem11;
        private DevComponents.DotNetBar.ButtonItem buttonItem12;
        private DevComponents.DotNetBar.ButtonItem buttonItem13;
        private DevComponents.DotNetBar.ButtonItem btnDesignableReports;
        private DevComponents.DotNetBar.ButtonItem btnR5_10;
        private DevComponents.DotNetBar.ButtonItem btnR5_11;
        private DevComponents.DotNetBar.ButtonItem btnR5_12;
        private DevComponents.DotNetBar.ButtonItem btnR5_13;
        private DevComponents.DotNetBar.ButtonItem btnPrintBill;
        private DevComponents.DotNetBar.LabelItem lblPrintTemplate;
        private DevComponents.DotNetBar.ComboBoxItem cboPrintTemplates;
        private DevComponents.DotNetBar.SliderItem sliderPrintCount;
        private DevComponents.DotNetBar.ButtonItem btnPrintBillLastRef;
        private DevComponents.DotNetBar.ButtonItem btnPrintBillAllRef;
        private DevComponents.DotNetBar.ButtonItem btnPrintRefDoc;
        private DevComponents.DotNetBar.ButtonItem btnPrintLastRefDoc;
        private DevComponents.DotNetBar.ButtonItem btnPrintAllRefDoc;
        private DevComponents.DotNetBar.ItemContainer iContainerBillTemplates;
        private DevComponents.DotNetBar.ButtonItem btnDocTexts;
        private DevComponents.DotNetBar.ButtonItem btnMessagesSettings;
        private DevComponents.DotNetBar.ButtonItem btnDocMessageTemplate;
        private DevComponents.DotNetBar.ButtonItem btnMessagesDashboard;
        private DevComponents.DotNetBar.ButtonItem btnR4_4;
        private DevComponents.DotNetBar.ButtonItem btnR1_3;
        private DevComponents.DotNetBar.ButtonItem btnR5_4;
        private DevComponents.DotNetBar.ButtonItem btnR6_3;
        private DevComponents.DotNetBar.ItemContainer iContainerDays;
        private DevComponents.DotNetBar.ButtonItem btnToday;
        private DevComponents.DotNetBar.ButtonItem btnYesterday;
        private DevComponents.DotNetBar.ButtonItem btnR1_4;
        private DevComponents.DotNetBar.ButtonItem btnBillServCatExclude;
        private DevComponents.DotNetBar.ButtonItem btnCostDiscountExcludedUsers;
        private DevComponents.DotNetBar.ButtonItem btnSendSMS;
        private DevComponents.DotNetBar.ButtonItem btnR5_5;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvRefData;
        private DevComponents.DotNetBar.ContextMenuBar cmsRefData;
        private DevComponents.DotNetBar.ButtonItem cmsdgvRefData;
        private DevComponents.DotNetBar.ButtonItem btnRefAdmit;
        private DevComponents.DotNetBar.ButtonItem btnRefAccount;
        private DevComponents.DotNetBar.ButtonItem btnRefBills;
        private DevComponents.DotNetBar.LabelItem lblRefBill;
        private DevComponents.DotNetBar.ItemContainer iContainerRefBill;
        private DevComponents.DotNetBar.ComboBoxItem cboRefBill;
        private DevComponents.DotNetBar.SliderItem sliderRefBillQty;
        private DevComponents.DotNetBar.ButtonItem btnRefBillPrint;
        private DevComponents.DotNetBar.ButtonItem btnRefDocs;
        private DevComponents.DotNetBar.ButtonItem btnRefLastDoc;
        private DevComponents.DotNetBar.ButtonItem btnRefNewDoc;
        private DevComponents.DotNetBar.ButtonItem btnRefPrintDoc;
        private DevComponents.DotNetBar.ButtonItem btnRefLastDocPrint;
        private DevComponents.DotNetBar.ButtonItem btnRefAllDocPrint;
        private DevComponents.DotNetBar.ButtonItem btnRefRemove;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRow;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPatientID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAge;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRefCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPersianRefDate;
        private DevComponents.DotNetBar.CheckBoxItem cBoxSearchByPatientID;
        private DevComponents.DotNetBar.ItemContainer itemContainer2;
        private DevComponents.DotNetBar.ItemContainer itemContainer3;
        private DevComponents.DotNetBar.CheckBoxItem cBoxSearchByRefID;
        private DevComponents.DotNetBar.LabelItem lblSearchByRefID;
        private DevComponents.DotNetBar.ButtonItem btnPACSServicesModalities;
        private DevComponents.DotNetBar.ButtonItem btnPACSStudies;
        private DevComponents.DotNetBar.ButtonItem btnPACSServicesStudies;
        private DevComponents.DotNetBar.ButtonItem btnExportPatDocuments;
        private DevComponents.DotNetBar.ButtonItem btnBillDefaultPrinter;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRefRow;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRefNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRefDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRefIns1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRefIns2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRefPeriod;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRefServCat;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRefDocCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRefLastDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIns1PriceTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIns1PartTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIns1PatientPart;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIns2PriceTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIns2PartTotal;
    }
}