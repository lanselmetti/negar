using Sepehr.Forms.Admission.Classes;

namespace Sepehr.Forms.Admission.Referrals
{
    partial class frmPatRefManager
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPatRefManager));
            this.PanelPatientData = new DevComponents.DotNetBar.PanelEx();
            this.txtAgeDay = new DevComponents.Editors.IntegerInput();
            this.txtAgeMonth = new DevComponents.Editors.IntegerInput();
            this.txtAgeYear = new DevComponents.Editors.IntegerInput();
            this.DateInputBirthDate = new Negar.PersianCalendar.UI.Controls.PersianDatePicker();
            this.lblFName = new DevComponents.DotNetBar.LabelX();
            this.txtFirstName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnShowEnglishFirstName = new DevComponents.DotNetBar.ButtonX();
            this.txtLastName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnShowEnglishLastName = new DevComponents.DotNetBar.ButtonX();
            this.PanelGender = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.cBoxFemale = new System.Windows.Forms.RadioButton();
            this.cBoxMale = new System.Windows.Forms.RadioButton();
            this.lblBirthDate = new DevComponents.DotNetBar.LabelX();
            this.lblTel1 = new DevComponents.DotNetBar.LabelX();
            this.txtTel1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblTel2 = new DevComponents.DotNetBar.LabelX();
            this.txtTel2 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblAddress = new DevComponents.DotNetBar.LabelX();
            this.txtAddress = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblLName = new DevComponents.DotNetBar.LabelX();
            this.lblGender = new DevComponents.DotNetBar.LabelX();
            this.cBoxEnterPatAge = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.RibbonOrders = new DevComponents.DotNetBar.RibbonBar();
            this.btnNewPatient = new DevComponents.DotNetBar.ButtonItem();
            this.btnNewRef = new DevComponents.DotNetBar.ButtonItem();
            this.btnPrevPatient = new DevComponents.DotNetBar.ButtonItem();
            this.iContainerPatientID = new DevComponents.DotNetBar.ItemContainer();
            this.lblPatientID = new DevComponents.DotNetBar.LabelItem();
            this.iContainerPatientIDText = new DevComponents.DotNetBar.ItemContainer();
            this.txtPatientID = new DevComponents.DotNetBar.TextBoxItem();
            this.btnNextPatient = new DevComponents.DotNetBar.ButtonItem();
            this.iContainerRefNav = new DevComponents.DotNetBar.ItemContainer();
            this.btnNextRef = new DevComponents.DotNetBar.ButtonItem();
            this.lblRefID = new DevComponents.DotNetBar.LabelItem();
            this.btnPrevRef = new DevComponents.DotNetBar.ButtonItem();
            this.btnEditMode = new DevComponents.DotNetBar.ButtonItem();
            this.btnPatientFile = new DevComponents.DotNetBar.ButtonItem();
            this.btnRefresh = new DevComponents.DotNetBar.ButtonItem();
            this.btnFreePatAndRef = new DevComponents.DotNetBar.ButtonItem();
            this.btnRefAddInData = new DevComponents.DotNetBar.ButtonItem();
            this.btnRefAccount = new DevComponents.DotNetBar.ButtonItem();
            this.btnRefDocuments = new DevComponents.DotNetBar.ButtonItem();
            this.btnNewDocument = new DevComponents.DotNetBar.ButtonItem();
            this.btnPrint = new DevComponents.DotNetBar.ButtonItem();
            this.iContainerPrintTemplate = new DevComponents.DotNetBar.ItemContainer();
            this.lblPrintTemplate = new DevComponents.DotNetBar.LabelItem();
            this.cboPrintTemplates = new DevComponents.DotNetBar.ComboBoxItem();
            this.SliderBillPrintCount = new DevComponents.DotNetBar.SliderItem();
            this.btnPrintPreview = new DevComponents.DotNetBar.ButtonItem();
            this.btnPrintByOtherPrinter = new DevComponents.DotNetBar.ButtonItem();
            this.btnHelp = new DevComponents.DotNetBar.ButtonItem();
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.btnExit = new System.Windows.Forms.Button();
            this.PanelRefServices = new DevComponents.DotNetBar.PanelEx();
            this.txtServiceCode = new System.Windows.Forms.NumericUpDown();
            this.lblServiceCode = new DevComponents.DotNetBar.LabelX();
            this.btnChooseService = new DevComponents.DotNetBar.ButtonX();
            this.lblServiceExpert = new DevComponents.DotNetBar.LabelX();
            this.cboServiceExpert = new System.Windows.Forms.ComboBox();
            this.lblServicePhysician = new DevComponents.DotNetBar.LabelX();
            this.cboServicePhysician = new System.Windows.Forms.ComboBox();
            this.cmsPatientRef = new DevComponents.DotNetBar.ContextMenuBar();
            this.cmsdgvServices = new DevComponents.DotNetBar.ButtonItem();
            this.SliderItemCount = new DevComponents.DotNetBar.SliderItem();
            this.btnServiceActivation = new DevComponents.DotNetBar.ButtonItem();
            this.btnIns1Cover = new DevComponents.DotNetBar.ButtonItem();
            this.btnIns2Cover = new DevComponents.DotNetBar.ButtonItem();
            this.btnServicePrices = new DevComponents.DotNetBar.ButtonItem();
            this.itemContainer1 = new DevComponents.DotNetBar.ItemContainer();
            this.lblService1 = new DevComponents.DotNetBar.LabelItem();
            this.lblServiceFreePrice = new DevComponents.DotNetBar.LabelItem();
            this.itemContainer3 = new DevComponents.DotNetBar.ItemContainer();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.lblServiceGovPrice = new DevComponents.DotNetBar.LabelItem();
            this.itemContainer4 = new DevComponents.DotNetBar.ItemContainer();
            this.labelItem3 = new DevComponents.DotNetBar.LabelItem();
            this.lblIns1Price = new DevComponents.DotNetBar.LabelItem();
            this.itemContainer5 = new DevComponents.DotNetBar.ItemContainer();
            this.labelItem5 = new DevComponents.DotNetBar.LabelItem();
            this.lblIns1Part = new DevComponents.DotNetBar.LabelItem();
            this.itemContainer6 = new DevComponents.DotNetBar.ItemContainer();
            this.labelItem7 = new DevComponents.DotNetBar.LabelItem();
            this.lblIns1PatientPart = new DevComponents.DotNetBar.LabelItem();
            this.itemContainer7 = new DevComponents.DotNetBar.ItemContainer();
            this.labelItem9 = new DevComponents.DotNetBar.LabelItem();
            this.lblIns2Price = new DevComponents.DotNetBar.LabelItem();
            this.itemContainer8 = new DevComponents.DotNetBar.ItemContainer();
            this.labelItem11 = new DevComponents.DotNetBar.LabelItem();
            this.lblIns2Part = new DevComponents.DotNetBar.LabelItem();
            this.itemContainer10 = new DevComponents.DotNetBar.ItemContainer();
            this.labelItem2 = new DevComponents.DotNetBar.LabelItem();
            this.lblPatientPayable = new DevComponents.DotNetBar.LabelItem();
            this.dgvRefServices = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ColServiceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColExpert = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColPhysician = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColIns1Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PanelTotalPrices = new DevComponents.DotNetBar.PanelEx();
            this.txtPrePayment = new DevComponents.Editors.IntegerInput();
            this.lblPrePayment = new DevComponents.DotNetBar.LabelX();
            this.txtTotalIns1Price = new DevComponents.DotNetBar.LabelX();
            this.lblTotalIns1Price = new DevComponents.DotNetBar.LabelX();
            this.lblRecievableValue = new DevComponents.DotNetBar.LabelX();
            this.txtTotalPatPartPrice = new DevComponents.DotNetBar.LabelX();
            this.lblRecievable = new DevComponents.DotNetBar.LabelX();
            this.lblTotalIns1Part = new DevComponents.DotNetBar.LabelX();
            this.txtTotalIns1Part = new DevComponents.DotNetBar.LabelX();
            this.lblTotalPatPartPrice = new DevComponents.DotNetBar.LabelX();
            this.PanelIns2 = new DevComponents.DotNetBar.PanelEx();
            this.btnIns2Details = new DevComponents.DotNetBar.ButtonX();
            this.txtIns2No1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblIns2No1 = new DevComponents.DotNetBar.LabelX();
            this.Ins2ExpireDate = new Negar.PersianCalendar.UI.Controls.PersianDatePicker();
            this.lblIns2ExpireDate = new DevComponents.DotNetBar.LabelX();
            this.cboIns2 = new System.Windows.Forms.ComboBox();
            this.labelX23 = new DevComponents.DotNetBar.LabelX();
            this.PanelIns1 = new DevComponents.DotNetBar.PanelEx();
            this.cboIns1 = new System.Windows.Forms.ComboBox();
            this.btnIns1Details = new DevComponents.DotNetBar.ButtonX();
            this.txtPageNo = new DevComponents.Editors.IntegerInput();
            this.lblPageNo = new DevComponents.DotNetBar.LabelX();
            this.lblIns1No1 = new DevComponents.DotNetBar.LabelX();
            this.lblIns1 = new DevComponents.DotNetBar.LabelX();
            this.lblIns1ExpireDate = new DevComponents.DotNetBar.LabelX();
            this.Ins1ExpireDate = new Negar.PersianCalendar.UI.Controls.PersianDatePicker();
            this.txtIns1No1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.PanelRefData = new DevComponents.DotNetBar.PanelEx();
            this.lblReportDate = new DevComponents.DotNetBar.LabelX();
            this.PDateReport = new Negar.PersianCalendar.UI.Controls.PersianDatePicker();
            this.lblRefDate = new DevComponents.DotNetBar.LabelX();
            this.DateReferral = new Negar.PersianCalendar.UI.Controls.PersianDatePicker();
            this.lblRefTime = new DevComponents.DotNetBar.LabelX();
            this.TimeReferral = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.lblAdmiter = new DevComponents.DotNetBar.LabelX();
            this.cboAdmitter = new System.Windows.Forms.ComboBox();
            this.lblPrescribeDate = new DevComponents.DotNetBar.LabelX();
            this.DatePrescribe = new Negar.PersianCalendar.UI.Controls.PersianDatePicker();
            this.lblWeight = new DevComponents.DotNetBar.LabelX();
            this.txtWeight = new DevComponents.Editors.DoubleInput();
            this.lblReferralPhysician = new DevComponents.DotNetBar.LabelX();
            this.cboRefPhysician = new IMSComboBox();
            this.btnEditPhysician = new DevComponents.DotNetBar.ButtonX();
            this.btnAddPhysician = new DevComponents.DotNetBar.ButtonX();
            this.lblRefStatus = new DevComponents.DotNetBar.LabelX();
            this.cboRefStatus = new System.Windows.Forms.ComboBox();
            this.lblDescription = new DevComponents.DotNetBar.LabelX();
            this.txtDescription = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.TimeTimer = new System.Windows.Forms.Timer(this.components);
            this.PanelPatientData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAgeDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAgeMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAgeYear)).BeginInit();
            this.PanelGender.SuspendLayout();
            this.PanelRefServices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtServiceCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmsPatientRef)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRefServices)).BeginInit();
            this.PanelTotalPrices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrePayment)).BeginInit();
            this.PanelIns2.SuspendLayout();
            this.PanelIns1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPageNo)).BeginInit();
            this.PanelRefData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimeReferral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWeight)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelPatientData
            // 
            this.PanelPatientData.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelPatientData.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelPatientData.Controls.Add(this.txtAgeDay);
            this.PanelPatientData.Controls.Add(this.txtAgeMonth);
            this.PanelPatientData.Controls.Add(this.txtAgeYear);
            this.PanelPatientData.Controls.Add(this.DateInputBirthDate);
            this.PanelPatientData.Controls.Add(this.lblFName);
            this.PanelPatientData.Controls.Add(this.txtFirstName);
            this.PanelPatientData.Controls.Add(this.btnShowEnglishFirstName);
            this.PanelPatientData.Controls.Add(this.txtLastName);
            this.PanelPatientData.Controls.Add(this.btnShowEnglishLastName);
            this.PanelPatientData.Controls.Add(this.PanelGender);
            this.PanelPatientData.Controls.Add(this.lblBirthDate);
            this.PanelPatientData.Controls.Add(this.lblTel1);
            this.PanelPatientData.Controls.Add(this.txtTel1);
            this.PanelPatientData.Controls.Add(this.lblTel2);
            this.PanelPatientData.Controls.Add(this.txtTel2);
            this.PanelPatientData.Controls.Add(this.lblAddress);
            this.PanelPatientData.Controls.Add(this.txtAddress);
            this.PanelPatientData.Controls.Add(this.lblLName);
            this.PanelPatientData.Controls.Add(this.lblGender);
            this.PanelPatientData.Controls.Add(this.cBoxEnterPatAge);
            this.PanelPatientData.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelPatientData.Location = new System.Drawing.Point(0, 83);
            this.PanelPatientData.Name = "PanelPatientData";
            this.PanelPatientData.Size = new System.Drawing.Size(794, 60);
            this.PanelPatientData.Style.BackColor1.Color = System.Drawing.Color.PowderBlue;
            this.PanelPatientData.Style.BackColor2.Color = System.Drawing.Color.White;
            this.PanelPatientData.TabIndex = 0;
            // 
            // txtAgeDay
            // 
            this.txtAgeDay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtAgeDay.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtAgeDay.DisplayFormat = "#";
            this.txtAgeDay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAgeDay.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtAgeDay.Location = new System.Drawing.Point(73, 8);
            this.txtAgeDay.MaxValue = 110;
            this.txtAgeDay.MinValue = 0;
            this.txtAgeDay.Name = "txtAgeDay";
            this.txtAgeDay.Size = new System.Drawing.Size(30, 21);
            this.txtAgeDay.TabIndex = 12;
            this.txtAgeDay.Tag = "PatData";
            this.txtAgeDay.Visible = false;
            this.txtAgeDay.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            this.txtAgeDay.WatermarkText = "روز";
            this.txtAgeDay.ValueChanged += new System.EventHandler(this.txtAge_ValueChanged);
            // 
            // txtAgeMonth
            // 
            this.txtAgeMonth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtAgeMonth.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtAgeMonth.DisplayFormat = "#";
            this.txtAgeMonth.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAgeMonth.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtAgeMonth.Location = new System.Drawing.Point(109, 8);
            this.txtAgeMonth.MaxValue = 110;
            this.txtAgeMonth.MinValue = 0;
            this.txtAgeMonth.Name = "txtAgeMonth";
            this.txtAgeMonth.Size = new System.Drawing.Size(30, 21);
            this.txtAgeMonth.TabIndex = 10;
            this.txtAgeMonth.Tag = "PatData";
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
            this.txtAgeYear.DisplayFormat = "#";
            this.txtAgeYear.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAgeYear.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtAgeYear.Location = new System.Drawing.Point(145, 8);
            this.txtAgeYear.MaxValue = 110;
            this.txtAgeYear.MinValue = 0;
            this.txtAgeYear.Name = "txtAgeYear";
            this.txtAgeYear.Size = new System.Drawing.Size(30, 21);
            this.txtAgeYear.TabIndex = 9;
            this.txtAgeYear.Tag = "PatData";
            this.txtAgeYear.Visible = false;
            this.txtAgeYear.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            this.txtAgeYear.WatermarkText = "سال";
            this.txtAgeYear.ValueChanged += new System.EventHandler(this.txtAge_ValueChanged);
            // 
            // DateInputBirthDate
            // 
            this.DateInputBirthDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DateInputBirthDate.IsPopupOpen = false;
            this.DateInputBirthDate.Location = new System.Drawing.Point(86, 8);
            this.DateInputBirthDate.Name = "DateInputBirthDate";
            this.DateInputBirthDate.SelectedDateTime = new System.DateTime(2009, 11, 29, 20, 4, 4, 774);
            this.DateInputBirthDate.Size = new System.Drawing.Size(89, 20);
            this.DateInputBirthDate.TabIndex = 11;
            this.DateInputBirthDate.Tag = "PatData";
            this.DateInputBirthDate.SelectedDateTimeChanged += new System.EventHandler(this.DateInputBirthDate_SelectedDateTimeChanged);
            // 
            // lblFName
            // 
            this.lblFName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFName.AutoSize = true;
            this.lblFName.BackColor = System.Drawing.Color.Transparent;
            this.lblFName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblFName.ForeColor = System.Drawing.Color.Black;
            this.lblFName.Location = new System.Drawing.Point(738, 10);
            this.lblFName.Name = "lblFName";
            this.lblFName.Size = new System.Drawing.Size(49, 16);
            this.lblFName.TabIndex = 1;
            this.lblFName.Text = "نام بیمار:";
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
            this.txtFirstName.Location = new System.Drawing.Point(637, 8);
            this.txtFirstName.MaxLength = 20;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(99, 21);
            this.txtFirstName.TabIndex = 0;
            this.txtFirstName.Tag = "PatData";
            // 
            // btnShowEnglishFirstName
            // 
            this.btnShowEnglishFirstName.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnShowEnglishFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowEnglishFirstName.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnShowEnglishFirstName.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.btnShowEnglishFirstName.Location = new System.Drawing.Point(616, 8);
            this.btnShowEnglishFirstName.Name = "btnShowEnglishFirstName";
            this.btnShowEnglishFirstName.Size = new System.Drawing.Size(21, 21);
            this.btnShowEnglishFirstName.TabIndex = 2;
            this.btnShowEnglishFirstName.TabStop = false;
            this.btnShowEnglishFirstName.Tag = "";
            this.btnShowEnglishFirstName.Text = "...";
            this.btnShowEnglishFirstName.Click += new System.EventHandler(this.btnShownEnglishName_Click);
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
            this.txtLastName.Location = new System.Drawing.Point(399, 8);
            this.txtLastName.MaxLength = 30;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(139, 21);
            this.txtLastName.TabIndex = 4;
            this.txtLastName.Tag = "PatData";
            // 
            // btnShowEnglishLastName
            // 
            this.btnShowEnglishLastName.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnShowEnglishLastName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowEnglishLastName.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnShowEnglishLastName.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.btnShowEnglishLastName.Location = new System.Drawing.Point(378, 8);
            this.btnShowEnglishLastName.Name = "btnShowEnglishLastName";
            this.btnShowEnglishLastName.Size = new System.Drawing.Size(21, 21);
            this.btnShowEnglishLastName.TabIndex = 5;
            this.btnShowEnglishLastName.TabStop = false;
            this.btnShowEnglishLastName.Tag = "";
            this.btnShowEnglishLastName.Text = "...";
            this.btnShowEnglishLastName.Click += new System.EventHandler(this.btnShownEnglishName_Click);
            // 
            // PanelGender
            // 
            this.PanelGender.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelGender.BackColor = System.Drawing.Color.Transparent;
            this.PanelGender.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelGender.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelGender.Controls.Add(this.cBoxFemale);
            this.PanelGender.Controls.Add(this.cBoxMale);
            this.PanelGender.DrawTitleBox = false;
            this.PanelGender.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.PanelGender.Location = new System.Drawing.Point(240, 5);
            this.PanelGender.Name = "PanelGender";
            this.PanelGender.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.PanelGender.Size = new System.Drawing.Size(89, 25);
            // 
            // 
            // 
            this.PanelGender.Style.BackColor = System.Drawing.Color.Transparent;
            this.PanelGender.Style.BackColor2 = System.Drawing.Color.Transparent;
            this.PanelGender.Style.BorderBottomWidth = 1;
            this.PanelGender.Style.BorderColor = System.Drawing.Color.Navy;
            this.PanelGender.Style.BorderColor2 = System.Drawing.Color.Navy;
            this.PanelGender.Style.BorderColorLight = System.Drawing.Color.Navy;
            this.PanelGender.Style.BorderColorLight2 = System.Drawing.Color.Navy;
            this.PanelGender.Style.BorderLeftWidth = 1;
            this.PanelGender.Style.BorderRightWidth = 1;
            this.PanelGender.Style.BorderTopWidth = 1;
            this.PanelGender.Style.CornerDiameter = 4;
            this.PanelGender.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.PanelGender.Style.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(0)))));
            this.PanelGender.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.PanelGender.TabIndex = 7;
            this.PanelGender.Tag = "PatData";
            this.PanelGender.TitleImagePosition = DevComponents.DotNetBar.eTitleImagePosition.Center;
            // 
            // cBoxFemale
            // 
            this.cBoxFemale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxFemale.AutoSize = true;
            this.cBoxFemale.BackColor = System.Drawing.Color.Transparent;
            this.cBoxFemale.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxFemale.Location = new System.Drawing.Point(2, 4);
            this.cBoxFemale.Name = "cBoxFemale";
            this.cBoxFemale.Size = new System.Drawing.Size(39, 17);
            this.cBoxFemale.TabIndex = 1;
            this.cBoxFemale.TabStop = true;
            this.cBoxFemale.Tag = "PatData";
            this.cBoxFemale.Text = "زن";
            this.cBoxFemale.UseVisualStyleBackColor = false;
            // 
            // cBoxMale
            // 
            this.cBoxMale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxMale.AutoSize = true;
            this.cBoxMale.BackColor = System.Drawing.Color.Transparent;
            this.cBoxMale.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxMale.Location = new System.Drawing.Point(41, 4);
            this.cBoxMale.Name = "cBoxMale";
            this.cBoxMale.Size = new System.Drawing.Size(44, 17);
            this.cBoxMale.TabIndex = 0;
            this.cBoxMale.TabStop = true;
            this.cBoxMale.Tag = "PatData";
            this.cBoxMale.Text = "مرد";
            this.cBoxMale.UseVisualStyleBackColor = false;
            this.cBoxMale.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cBoxMale_KeyPress);
            // 
            // lblBirthDate
            // 
            this.lblBirthDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBirthDate.BackColor = System.Drawing.Color.Transparent;
            this.lblBirthDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblBirthDate.ForeColor = System.Drawing.Color.Black;
            this.lblBirthDate.Location = new System.Drawing.Point(179, 10);
            this.lblBirthDate.Name = "lblBirthDate";
            this.lblBirthDate.Size = new System.Drawing.Size(58, 16);
            this.lblBirthDate.TabIndex = 8;
            this.lblBirthDate.Text = "تاریخ تولد:";
            this.lblBirthDate.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblTel1
            // 
            this.lblTel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTel1.AutoSize = true;
            this.lblTel1.BackColor = System.Drawing.Color.Transparent;
            this.lblTel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTel1.ForeColor = System.Drawing.Color.Black;
            this.lblTel1.Location = new System.Drawing.Point(738, 35);
            this.lblTel1.Name = "lblTel1";
            this.lblTel1.Size = new System.Drawing.Size(40, 16);
            this.lblTel1.TabIndex = 14;
            this.lblTel1.Text = "تلفن 1:";
            // 
            // txtTel1
            // 
            this.txtTel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTel1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtTel1.Border.Class = "TextBoxBorder";
            this.txtTel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtTel1.Location = new System.Drawing.Point(637, 33);
            this.txtTel1.MaxLength = 15;
            this.txtTel1.Name = "txtTel1";
            this.txtTel1.Size = new System.Drawing.Size(99, 21);
            this.txtTel1.TabIndex = 15;
            this.txtTel1.Tag = "PatData";
            this.txtTel1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblTel2
            // 
            this.lblTel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTel2.AutoSize = true;
            this.lblTel2.BackColor = System.Drawing.Color.Transparent;
            this.lblTel2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTel2.ForeColor = System.Drawing.Color.Black;
            this.lblTel2.Location = new System.Drawing.Point(590, 35);
            this.lblTel2.Name = "lblTel2";
            this.lblTel2.Size = new System.Drawing.Size(40, 16);
            this.lblTel2.TabIndex = 16;
            this.lblTel2.Text = "تلفن 2:";
            // 
            // txtTel2
            // 
            this.txtTel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTel2.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtTel2.Border.Class = "TextBoxBorder";
            this.txtTel2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtTel2.Location = new System.Drawing.Point(487, 33);
            this.txtTel2.MaxLength = 15;
            this.txtTel2.Name = "txtTel2";
            this.txtTel2.Size = new System.Drawing.Size(99, 21);
            this.txtTel2.TabIndex = 17;
            this.txtTel2.Tag = "PatData";
            this.txtTel2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblAddress
            // 
            this.lblAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAddress.AutoSize = true;
            this.lblAddress.BackColor = System.Drawing.Color.Transparent;
            this.lblAddress.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblAddress.ForeColor = System.Drawing.Color.Black;
            this.lblAddress.Location = new System.Drawing.Point(446, 35);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(36, 16);
            this.lblAddress.TabIndex = 18;
            this.lblAddress.Text = "آدرس:";
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddress.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtAddress.Border.Class = "TextBoxBorder";
            this.txtAddress.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtAddress.Location = new System.Drawing.Point(12, 33);
            this.txtAddress.MaxLength = 200;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(432, 21);
            this.txtAddress.TabIndex = 19;
            this.txtAddress.Tag = "PatData";
            // 
            // lblLName
            // 
            this.lblLName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLName.AutoSize = true;
            this.lblLName.BackColor = System.Drawing.Color.Transparent;
            this.lblLName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblLName.ForeColor = System.Drawing.Color.Black;
            this.lblLName.Location = new System.Drawing.Point(537, 10);
            this.lblLName.Name = "lblLName";
            this.lblLName.Size = new System.Drawing.Size(74, 16);
            this.lblLName.TabIndex = 3;
            this.lblLName.Text = "نام خانوادگی:";
            // 
            // lblGender
            // 
            this.lblGender.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGender.AutoSize = true;
            this.lblGender.BackColor = System.Drawing.Color.Transparent;
            this.lblGender.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblGender.ForeColor = System.Drawing.Color.Black;
            this.lblGender.Location = new System.Drawing.Point(327, 10);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(47, 16);
            this.lblGender.TabIndex = 6;
            this.lblGender.Text = "جنسیت:";
            // 
            // cBoxEnterPatAge
            // 
            this.cBoxEnterPatAge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxEnterPatAge.AutoSize = true;
            this.cBoxEnterPatAge.BackColor = System.Drawing.Color.Transparent;
            this.cBoxEnterPatAge.Location = new System.Drawing.Point(20, 10);
            this.cBoxEnterPatAge.Name = "cBoxEnterPatAge";
            this.cBoxEnterPatAge.Size = new System.Drawing.Size(63, 16);
            this.cBoxEnterPatAge.TabIndex = 13;
            this.cBoxEnterPatAge.TabStop = false;
            this.cBoxEnterPatAge.Text = "ورود سن";
            this.cBoxEnterPatAge.TextColor = System.Drawing.Color.Black;
            this.cBoxEnterPatAge.CheckedChanged += new System.EventHandler(this.cBoxEnterPatientAge_CheckedChanged);
            // 
            // RibbonOrders
            // 
            this.RibbonOrders.AutoOverflowEnabled = true;
            this.RibbonOrders.Dock = System.Windows.Forms.DockStyle.Top;
            this.RibbonOrders.FadeEffect = false;
            this.RibbonOrders.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnNewPatient,
            this.btnNewRef,
            this.btnPrevPatient,
            this.iContainerPatientID,
            this.btnNextPatient,
            this.iContainerRefNav,
            this.btnEditMode,
            this.btnRefAddInData,
            this.btnRefAccount,
            this.btnRefDocuments,
            this.btnPrint,
            this.btnHelp});
            this.RibbonOrders.Location = new System.Drawing.Point(0, 0);
            this.RibbonOrders.Name = "RibbonOrders";
            this.RibbonOrders.Size = new System.Drawing.Size(794, 83);
            this.RibbonOrders.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.RibbonOrders.TabIndex = 6;
            this.RibbonOrders.TabStop = false;
            this.RibbonOrders.TitleVisible = false;
            this.RibbonOrders.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle;
            // 
            // btnNewPatient
            // 
            this.btnNewPatient.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnNewPatient.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnNewPatient.FontBold = true;
            this.btnNewPatient.ForeColor = System.Drawing.Color.White;
            this.btnNewPatient.Image = global::Sepehr.Forms.Admission.Properties.Resources.NewPat;
            this.btnNewPatient.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnNewPatient.ImagePaddingHorizontal = 8;
            this.btnNewPatient.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnNewPatient.Name = "btnNewPatient";
            this.btnNewPatient.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F2);
            this.btnNewPatient.Text = "بیمار\r\nجدید\r (F2)";
            this.btnNewPatient.Click += new System.EventHandler(this.btnNewPatient_Click);
            // 
            // btnNewRef
            // 
            this.btnNewRef.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnNewRef.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnNewRef.FontBold = true;
            this.btnNewRef.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnNewRef.Image = global::Sepehr.Forms.Admission.Properties.Resources.AddMed;
            this.btnNewRef.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnNewRef.ImagePaddingHorizontal = 8;
            this.btnNewRef.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnNewRef.Name = "btnNewRef";
            this.btnNewRef.Text = "مراجعه\r\nجدید";
            this.btnNewRef.Click += new System.EventHandler(this.btnNewReferral_Click);
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
            this.btnPrevPatient.SubItemsExpandWidth = 14;
            this.btnPrevPatient.Text = "قبلی (F11)";
            this.btnPrevPatient.Click += new System.EventHandler(this.btnPrevPatient_Click);
            // 
            // iContainerPatientID
            // 
            this.iContainerPatientID.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center;
            this.iContainerPatientID.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.iContainerPatientID.Name = "iContainerPatientID";
            this.iContainerPatientID.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.lblPatientID,
            this.iContainerPatientIDText});
            this.iContainerPatientID.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle;
            // 
            // lblPatientID
            // 
            this.lblPatientID.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblPatientID.Image = global::Sepehr.Forms.Admission.Properties.Resources.PatientID;
            this.lblPatientID.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right;
            this.lblPatientID.Name = "lblPatientID";
            this.lblPatientID.Text = "كد بیمار جاری:";
            this.lblPatientID.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // iContainerPatientIDText
            // 
            this.iContainerPatientIDText.MinimumSize = new System.Drawing.Size(0, 30);
            this.iContainerPatientIDText.Name = "iContainerPatientIDText";
            this.iContainerPatientIDText.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
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
            this.btnNextPatient.SubItemsExpandWidth = 14;
            this.btnNextPatient.Text = "بعدی (F12)";
            this.btnNextPatient.Click += new System.EventHandler(this.btnNextPatient_Click);
            // 
            // iContainerRefNav
            // 
            this.iContainerRefNav.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center;
            this.iContainerRefNav.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.iContainerRefNav.Name = "iContainerRefNav";
            this.iContainerRefNav.ResizeItemsToFit = false;
            this.iContainerRefNav.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnNextRef,
            this.lblRefID,
            this.btnPrevRef});
            this.iContainerRefNav.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle;
            // 
            // btnNextRef
            // 
            this.btnNextRef.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnNextRef.FontBold = true;
            this.btnNextRef.Image = global::Sepehr.Forms.Admission.Properties.Resources.UpLarge;
            this.btnNextRef.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.btnNextRef.ImagePaddingHorizontal = 8;
            this.btnNextRef.Name = "btnNextRef";
            this.btnNextRef.Text = "مراجعه بعدی";
            this.btnNextRef.Click += new System.EventHandler(this.btnNextRef_Click);
            // 
            // lblRefID
            // 
            this.lblRefID.BackColor = System.Drawing.Color.White;
            this.lblRefID.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.lblRefID.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblRefID.Name = "lblRefID";
            this.lblRefID.SingleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.lblRefID.TextAlignment = System.Drawing.StringAlignment.Center;
            this.lblRefID.Width = 90;
            // 
            // btnPrevRef
            // 
            this.btnPrevRef.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnPrevRef.FontBold = true;
            this.btnPrevRef.Image = global::Sepehr.Forms.Admission.Properties.Resources.DownLarge;
            this.btnPrevRef.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.btnPrevRef.ImagePaddingHorizontal = 8;
            this.btnPrevRef.Name = "btnPrevRef";
            this.btnPrevRef.Text = "مراجعه قبلی";
            this.btnPrevRef.Click += new System.EventHandler(this.btnPrevRef_Click);
            // 
            // btnEditMode
            // 
            this.btnEditMode.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnEditMode.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnEditMode.FontBold = true;
            this.btnEditMode.ForeColor = System.Drawing.Color.DarkViolet;
            this.btnEditMode.Image = global::Sepehr.Forms.Admission.Properties.Resources.EditLarge;
            this.btnEditMode.ImagePaddingHorizontal = 8;
            this.btnEditMode.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnEditMode.Name = "btnEditMode";
            this.btnEditMode.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F3);
            this.btnEditMode.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnPatientFile,
            this.btnRefresh,
            this.btnFreePatAndRef});
            this.btnEditMode.Text = "ویرایش\r\n(F3)";
            this.btnEditMode.Click += new System.EventHandler(this.btnEditMode_Click);
            // 
            // btnPatientFile
            // 
            this.btnPatientFile.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnPatientFile.Image = global::Sepehr.Forms.Admission.Properties.Resources.PatientFile;
            this.btnPatientFile.ImagePaddingHorizontal = 8;
            this.btnPatientFile.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnPatientFile.Name = "btnPatientFile";
            this.btnPatientFile.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F9);
            this.btnPatientFile.Text = "<b>پرونده بیمار...</b>";
            this.btnPatientFile.Click += new System.EventHandler(this.btnPatientFile_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BeginGroup = true;
            this.btnRefresh.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnRefresh.Image = global::Sepehr.Forms.Admission.Properties.Resources.Refresh;
            this.btnRefresh.ImagePaddingHorizontal = 8;
            this.btnRefresh.ImagePaddingVertical = 10;
            this.btnRefresh.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F5);
            this.btnRefresh.SubItemsExpandWidth = 14;
            this.btnRefresh.Text = "<b>بازخوانی پرونده</b>";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnFreePatAndRef
            // 
            this.btnFreePatAndRef.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnFreePatAndRef.FontBold = true;
            this.btnFreePatAndRef.ForeColor = System.Drawing.Color.Red;
            this.btnFreePatAndRef.Image = global::Sepehr.Forms.Admission.Properties.Resources.FreeLockedRow;
            this.btnFreePatAndRef.ImagePaddingHorizontal = 12;
            this.btnFreePatAndRef.ImagePaddingVertical = 10;
            this.btnFreePatAndRef.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnFreePatAndRef.Name = "btnFreePatAndRef";
            this.btnFreePatAndRef.RibbonWordWrap = false;
            this.btnFreePatAndRef.SubItemsExpandWidth = 20;
            this.btnFreePatAndRef.Text = "آزاد كردن قفل ویرایش";
            this.btnFreePatAndRef.Click += new System.EventHandler(this.btnFreePatAndRef_Click);
            // 
            // btnRefAddInData
            // 
            this.btnRefAddInData.BeginGroup = true;
            this.btnRefAddInData.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnRefAddInData.FontBold = true;
            this.btnRefAddInData.ForeColor = System.Drawing.Color.Chocolate;
            this.btnRefAddInData.HotFontBold = true;
            this.btnRefAddInData.Image = global::Sepehr.Forms.Admission.Properties.Resources.AddinFields;
            this.btnRefAddInData.ImagePaddingHorizontal = 8;
            this.btnRefAddInData.ImagePaddingVertical = 2;
            this.btnRefAddInData.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnRefAddInData.Name = "btnRefAddInData";
            this.btnRefAddInData.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlW);
            this.btnRefAddInData.Text = "فیلدهای\r\nمراجعه";
            this.btnRefAddInData.Click += new System.EventHandler(this.btnRefAddinData_Click);
            // 
            // btnRefAccount
            // 
            this.btnRefAccount.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnRefAccount.FontBold = true;
            this.btnRefAccount.ForeColor = System.Drawing.Color.Green;
            this.btnRefAccount.Image = global::Sepehr.Forms.Admission.Properties.Resources.RefAccount;
            this.btnRefAccount.ImagePaddingHorizontal = 8;
            this.btnRefAccount.ImagePaddingVertical = 10;
            this.btnRefAccount.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnRefAccount.Name = "btnRefAccount";
            this.btnRefAccount.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F4);
            this.btnRefAccount.Text = "حساب (F4)";
            this.btnRefAccount.Click += new System.EventHandler(this.btnAccount_Click);
            // 
            // btnRefDocuments
            // 
            this.btnRefDocuments.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnRefDocuments.FontBold = true;
            this.btnRefDocuments.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnRefDocuments.Image = global::Sepehr.Forms.Admission.Properties.Resources.RefDocuments;
            this.btnRefDocuments.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnRefDocuments.ImagePaddingHorizontal = 8;
            this.btnRefDocuments.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnRefDocuments.Name = "btnRefDocuments";
            this.btnRefDocuments.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlQ);
            this.btnRefDocuments.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnNewDocument});
            this.btnRefDocuments.Text = "مدارك\r\n(Ctrl+Q)";
            this.btnRefDocuments.Click += new System.EventHandler(this.btnRefDocuments_Click);
            // 
            // btnNewDocument
            // 
            this.btnNewDocument.FontBold = true;
            this.btnNewDocument.Image = global::Sepehr.Forms.Admission.Properties.Resources.DocumentAdd;
            this.btnNewDocument.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnNewDocument.ImagePaddingHorizontal = 8;
            this.btnNewDocument.Name = "btnNewDocument";
            this.btnNewDocument.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F6);
            this.btnNewDocument.Text = "جوابدهی\r\nگزارش جدید";
            this.btnNewDocument.Click += new System.EventHandler(this.btnNewDocument_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnPrint.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnPrint.FontBold = true;
            this.btnPrint.Image = global::Sepehr.Forms.Admission.Properties.Resources.PrintBill;
            this.btnPrint.ImagePaddingHorizontal = 20;
            this.btnPrint.ImagePaddingVertical = 2;
            this.btnPrint.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnPrint.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.iContainerPrintTemplate,
            this.SliderBillPrintCount,
            this.btnPrintPreview,
            this.btnPrintByOtherPrinter});
            this.btnPrint.SubItemsExpandWidth = 15;
            this.btnPrint.Text = "چاپ (F8)";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
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
            this.cboPrintTemplates.Name = "cboPrintTemplates";
            this.cboPrintTemplates.WatermarkText = "قالب چاپ";
            // 
            // SliderBillPrintCount
            // 
            this.SliderBillPrintCount.AutoCollapseOnClick = false;
            this.SliderBillPrintCount.LabelPosition = DevComponents.DotNetBar.eSliderLabelPosition.Top;
            this.SliderBillPrintCount.LabelWidth = 50;
            this.SliderBillPrintCount.Maximum = 5;
            this.SliderBillPrintCount.Minimum = 1;
            this.SliderBillPrintCount.Name = "SliderBillPrintCount";
            this.SliderBillPrintCount.Text = "تعداد چاپ: 1 نسخه";
            this.SliderBillPrintCount.TrackMarker = false;
            this.SliderBillPrintCount.Value = 1;
            this.SliderBillPrintCount.Width = 50;
            this.SliderBillPrintCount.ValueChanged += new System.EventHandler(this.SliderBillPrintCount_ValueChanged);
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
            // btnPrintByOtherPrinter
            // 
            this.btnPrintByOtherPrinter.FontBold = true;
            this.btnPrintByOtherPrinter.Image = global::Sepehr.Forms.Admission.Properties.Resources.PrintBill;
            this.btnPrintByOtherPrinter.ImagePaddingHorizontal = 8;
            this.btnPrintByOtherPrinter.ImagePaddingVertical = 10;
            this.btnPrintByOtherPrinter.Name = "btnPrintByOtherPrinter";
            this.btnPrintByOtherPrinter.Text = "چاپگر...";
            this.btnPrintByOtherPrinter.Click += new System.EventHandler(this.btnPrintByOtherPrinter_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnHelp.Image = global::Sepehr.Forms.Admission.Properties.Resources.HelpMed;
            this.btnHelp.ImagePaddingHorizontal = 8;
            this.btnHelp.ImagePaddingVertical = 16;
            this.btnHelp.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.RibbonWordWrap = false;
            this.btnHelp.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F1);
            this.btnHelp.SubItemsExpandWidth = 20;
            this.btnHelp.Text = "راهنمای\r\nكاربری";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
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
            this.btnExit.Size = new System.Drawing.Size(45, 23);
            this.btnExit.TabIndex = 88;
            this.btnExit.TabStop = false;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // PanelRefServices
            // 
            this.PanelRefServices.AccessibleDescription = "Show";
            this.PanelRefServices.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelRefServices.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelRefServices.Controls.Add(this.txtServiceCode);
            this.PanelRefServices.Controls.Add(this.lblServiceCode);
            this.PanelRefServices.Controls.Add(this.btnChooseService);
            this.PanelRefServices.Controls.Add(this.lblServiceExpert);
            this.PanelRefServices.Controls.Add(this.cboServiceExpert);
            this.PanelRefServices.Controls.Add(this.lblServicePhysician);
            this.PanelRefServices.Controls.Add(this.cboServicePhysician);
            this.PanelRefServices.Controls.Add(this.cmsPatientRef);
            this.PanelRefServices.Controls.Add(this.dgvRefServices);
            this.PanelRefServices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelRefServices.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.PanelRefServices.Location = new System.Drawing.Point(0, 298);
            this.PanelRefServices.Name = "PanelRefServices";
            this.PanelRefServices.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.PanelRefServices.Size = new System.Drawing.Size(794, 232);
            this.PanelRefServices.Style.BackColor1.Color = System.Drawing.Color.White;
            this.PanelRefServices.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.PanelRefServices.Style.BorderColor.Color = System.Drawing.Color.Blue;
            this.PanelRefServices.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.Top;
            this.PanelRefServices.Style.BorderWidth = 2;
            this.PanelRefServices.TabIndex = 4;
            // 
            // txtServiceCode
            // 
            this.txtServiceCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServiceCode.BackColor = System.Drawing.Color.White;
            this.txtServiceCode.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtServiceCode.ForeColor = System.Drawing.Color.Blue;
            this.txtServiceCode.Location = new System.Drawing.Point(667, 6);
            this.txtServiceCode.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.txtServiceCode.Name = "txtServiceCode";
            this.txtServiceCode.Size = new System.Drawing.Size(66, 21);
            this.txtServiceCode.TabIndex = 0;
            this.txtServiceCode.Tag = "Services";
            this.txtServiceCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtServiceCode.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.ServiceAddingControls_PreviewKeyDown);
            this.txtServiceCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtServiceCode_KeyPress);
            // 
            // lblServiceCode
            // 
            this.lblServiceCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblServiceCode.AutoSize = true;
            this.lblServiceCode.BackColor = System.Drawing.Color.Transparent;
            this.lblServiceCode.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblServiceCode.ForeColor = System.Drawing.Color.Navy;
            this.lblServiceCode.Location = new System.Drawing.Point(732, 8);
            this.lblServiceCode.Name = "lblServiceCode";
            this.lblServiceCode.Size = new System.Drawing.Size(55, 16);
            this.lblServiceCode.TabIndex = 1;
            this.lblServiceCode.Text = "كد خدمت:";
            // 
            // btnChooseService
            // 
            this.btnChooseService.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnChooseService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChooseService.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnChooseService.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnChooseService.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.btnChooseService.Location = new System.Drawing.Point(559, 4);
            this.btnChooseService.Name = "btnChooseService";
            this.btnChooseService.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F7);
            this.btnChooseService.Size = new System.Drawing.Size(104, 25);
            this.btnChooseService.TabIndex = 2;
            this.btnChooseService.TabStop = false;
            this.btnChooseService.Tag = "Services";
            this.btnChooseService.Text = "انتخاب خدمت (F7)";
            this.btnChooseService.Click += new System.EventHandler(this.btnChooseService_Click);
            // 
            // lblServiceExpert
            // 
            this.lblServiceExpert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblServiceExpert.AutoSize = true;
            this.lblServiceExpert.BackColor = System.Drawing.Color.Transparent;
            this.lblServiceExpert.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblServiceExpert.ForeColor = System.Drawing.Color.Navy;
            this.lblServiceExpert.Location = new System.Drawing.Point(495, 8);
            this.lblServiceExpert.Name = "lblServiceExpert";
            this.lblServiceExpert.Size = new System.Drawing.Size(57, 16);
            this.lblServiceExpert.TabIndex = 3;
            this.lblServiceExpert.Text = "كارشناس:";
            // 
            // cboServiceExpert
            // 
            this.cboServiceExpert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboServiceExpert.DropDownHeight = 150;
            this.cboServiceExpert.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboServiceExpert.FormattingEnabled = true;
            this.cboServiceExpert.IntegralHeight = false;
            this.cboServiceExpert.ItemHeight = 13;
            this.cboServiceExpert.Location = new System.Drawing.Point(320, 6);
            this.cboServiceExpert.Name = "cboServiceExpert";
            this.cboServiceExpert.Size = new System.Drawing.Size(175, 21);
            this.cboServiceExpert.TabIndex = 4;
            this.cboServiceExpert.Tag = "Services";
            this.cboServiceExpert.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.ServiceAddingControls_PreviewKeyDown);
            this.cboServiceExpert.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbo_KeyDown);
            // 
            // lblServicePhysician
            // 
            this.lblServicePhysician.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblServicePhysician.AutoSize = true;
            this.lblServicePhysician.BackColor = System.Drawing.Color.Transparent;
            this.lblServicePhysician.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblServicePhysician.ForeColor = System.Drawing.Color.Navy;
            this.lblServicePhysician.Location = new System.Drawing.Point(274, 8);
            this.lblServicePhysician.Name = "lblServicePhysician";
            this.lblServicePhysician.Size = new System.Drawing.Size(38, 16);
            this.lblServicePhysician.TabIndex = 5;
            this.lblServicePhysician.Text = "پزشك:";
            // 
            // cboServicePhysician
            // 
            this.cboServicePhysician.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboServicePhysician.DropDownHeight = 150;
            this.cboServicePhysician.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboServicePhysician.FormattingEnabled = true;
            this.cboServicePhysician.IntegralHeight = false;
            this.cboServicePhysician.ItemHeight = 13;
            this.cboServicePhysician.Location = new System.Drawing.Point(71, 6);
            this.cboServicePhysician.Name = "cboServicePhysician";
            this.cboServicePhysician.Size = new System.Drawing.Size(202, 21);
            this.cboServicePhysician.TabIndex = 6;
            this.cboServicePhysician.Tag = "Services";
            this.cboServicePhysician.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.ServiceAddingControls_PreviewKeyDown);
            this.cboServicePhysician.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbo_KeyDown);
            // 
            // cmsPatientRef
            // 
            this.cmsPatientRef.DockSide = DevComponents.DotNetBar.eDockSide.Document;
            this.cmsPatientRef.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmsPatientRef.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.cmsdgvServices});
            this.cmsPatientRef.Location = new System.Drawing.Point(666, 62);
            this.cmsPatientRef.Name = "cmsPatientRef";
            this.cmsPatientRef.Size = new System.Drawing.Size(120, 25);
            this.cmsPatientRef.Stretch = true;
            this.cmsPatientRef.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.cmsPatientRef.TabIndex = 75;
            this.cmsPatientRef.TabStop = false;
            // 
            // cmsdgvServices
            // 
            this.cmsdgvServices.AutoExpandOnClick = true;
            this.cmsdgvServices.ClickRepeatInterval = 500;
            this.cmsdgvServices.ImagePaddingHorizontal = 8;
            this.cmsdgvServices.Name = "cmsdgvServices";
            this.cmsdgvServices.PopupAnimation = DevComponents.DotNetBar.ePopupAnimation.Fade;
            this.cmsdgvServices.PulseSpeed = 10;
            this.cmsdgvServices.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.SliderItemCount,
            this.btnServiceActivation,
            this.btnIns1Cover,
            this.btnIns2Cover,
            this.btnServicePrices});
            this.cmsdgvServices.Text = "منوی جدول خدمات";
            // 
            // SliderItemCount
            // 
            this.SliderItemCount.LabelPosition = DevComponents.DotNetBar.eSliderLabelPosition.Top;
            this.SliderItemCount.Maximum = 10;
            this.SliderItemCount.Minimum = 1;
            this.SliderItemCount.Name = "SliderItemCount";
            this.SliderItemCount.Text = "تعداد خدمت: 1";
            this.SliderItemCount.TrackMarker = false;
            this.SliderItemCount.Value = 1;
            this.SliderItemCount.Width = 50;
            this.SliderItemCount.Click += new System.EventHandler(this.SliderItemCount_ValueChanged);
            // 
            // btnServiceActivation
            // 
            this.btnServiceActivation.BeginGroup = true;
            this.btnServiceActivation.Checked = true;
            this.btnServiceActivation.ColorTable = DevComponents.DotNetBar.eButtonColor.Magenta;
            this.btnServiceActivation.FontBold = true;
            this.btnServiceActivation.ForeColor = System.Drawing.Color.Red;
            this.btnServiceActivation.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.btnServiceActivation.ImagePaddingHorizontal = 8;
            this.btnServiceActivation.Name = "btnServiceActivation";
            this.btnServiceActivation.Text = "لغو خدمت";
            this.btnServiceActivation.Click += new System.EventHandler(this.btnRemoveService_Click);
            // 
            // btnIns1Cover
            // 
            this.btnIns1Cover.BeginGroup = true;
            this.btnIns1Cover.Checked = true;
            this.btnIns1Cover.FontBold = true;
            this.btnIns1Cover.ForeColor = System.Drawing.Color.Black;
            this.btnIns1Cover.ImagePaddingHorizontal = 8;
            this.btnIns1Cover.Name = "btnIns1Cover";
            this.btnIns1Cover.Text = "پوشش بیمه 1";
            this.btnIns1Cover.Click += new System.EventHandler(this.btnIns1Cover_Click);
            // 
            // btnIns2Cover
            // 
            this.btnIns2Cover.Checked = true;
            this.btnIns2Cover.FontBold = true;
            this.btnIns2Cover.ForeColor = System.Drawing.Color.Fuchsia;
            this.btnIns2Cover.ImagePaddingHorizontal = 8;
            this.btnIns2Cover.Name = "btnIns2Cover";
            this.btnIns2Cover.Text = "پوشش بیمه 2";
            this.btnIns2Cover.Click += new System.EventHandler(this.btnIns2Cover_Click);
            // 
            // btnServicePrices
            // 
            this.btnServicePrices.BeginGroup = true;
            this.btnServicePrices.FontBold = true;
            this.btnServicePrices.ForeColor = System.Drawing.Color.Blue;
            this.btnServicePrices.ImagePaddingHorizontal = 8;
            this.btnServicePrices.Name = "btnServicePrices";
            this.btnServicePrices.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.itemContainer1,
            this.itemContainer3,
            this.itemContainer4,
            this.itemContainer5,
            this.itemContainer6,
            this.itemContainer7,
            this.itemContainer8,
            this.itemContainer10});
            this.btnServicePrices.Text = "قیمت های خدمت";
            // 
            // itemContainer1
            // 
            this.itemContainer1.ItemSpacing = 0;
            this.itemContainer1.Name = "itemContainer1";
            this.itemContainer1.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.lblService1,
            this.lblServiceFreePrice});
            // 
            // lblService1
            // 
            this.lblService1.BackColor = System.Drawing.Color.White;
            this.lblService1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblService1.Name = "lblService1";
            this.lblService1.Text = "تعرفه آزاد خدمت:";
            this.lblService1.Width = 100;
            // 
            // lblServiceFreePrice
            // 
            this.lblServiceFreePrice.BackColor = System.Drawing.Color.White;
            this.lblServiceFreePrice.BeginGroup = true;
            this.lblServiceFreePrice.BorderSide = DevComponents.DotNetBar.eBorderSide.None;
            this.lblServiceFreePrice.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblServiceFreePrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(21)))), ((int)(((byte)(110)))));
            this.lblServiceFreePrice.Name = "lblServiceFreePrice";
            this.lblServiceFreePrice.PaddingBottom = 1;
            this.lblServiceFreePrice.PaddingLeft = 10;
            this.lblServiceFreePrice.PaddingTop = 1;
            this.lblServiceFreePrice.SingleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.lblServiceFreePrice.Width = 100;
            // 
            // itemContainer3
            // 
            this.itemContainer3.ItemSpacing = 0;
            this.itemContainer3.Name = "itemContainer3";
            this.itemContainer3.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelItem1,
            this.lblServiceGovPrice});
            // 
            // labelItem1
            // 
            this.labelItem1.BackColor = System.Drawing.Color.White;
            this.labelItem1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.labelItem1.Name = "labelItem1";
            this.labelItem1.Text = "تعرفه دولتی:";
            this.labelItem1.Width = 100;
            // 
            // lblServiceGovPrice
            // 
            this.lblServiceGovPrice.BackColor = System.Drawing.Color.White;
            this.lblServiceGovPrice.BeginGroup = true;
            this.lblServiceGovPrice.BorderSide = DevComponents.DotNetBar.eBorderSide.None;
            this.lblServiceGovPrice.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblServiceGovPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(21)))), ((int)(((byte)(110)))));
            this.lblServiceGovPrice.Name = "lblServiceGovPrice";
            this.lblServiceGovPrice.PaddingBottom = 1;
            this.lblServiceGovPrice.PaddingLeft = 10;
            this.lblServiceGovPrice.PaddingTop = 1;
            this.lblServiceGovPrice.SingleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.lblServiceGovPrice.Width = 100;
            // 
            // itemContainer4
            // 
            this.itemContainer4.BeginGroup = true;
            this.itemContainer4.ItemSpacing = 0;
            this.itemContainer4.Name = "itemContainer4";
            this.itemContainer4.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelItem3,
            this.lblIns1Price});
            // 
            // labelItem3
            // 
            this.labelItem3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.labelItem3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.labelItem3.Name = "labelItem3";
            this.labelItem3.Text = "قیمت بیمه اول:";
            this.labelItem3.Width = 100;
            // 
            // lblIns1Price
            // 
            this.lblIns1Price.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblIns1Price.BeginGroup = true;
            this.lblIns1Price.BorderSide = DevComponents.DotNetBar.eBorderSide.None;
            this.lblIns1Price.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblIns1Price.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(21)))), ((int)(((byte)(110)))));
            this.lblIns1Price.Name = "lblIns1Price";
            this.lblIns1Price.PaddingBottom = 1;
            this.lblIns1Price.PaddingLeft = 10;
            this.lblIns1Price.PaddingTop = 1;
            this.lblIns1Price.SingleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.lblIns1Price.Width = 100;
            // 
            // itemContainer5
            // 
            this.itemContainer5.ItemSpacing = 0;
            this.itemContainer5.Name = "itemContainer5";
            this.itemContainer5.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelItem5,
            this.lblIns1Part});
            // 
            // labelItem5
            // 
            this.labelItem5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.labelItem5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.labelItem5.Name = "labelItem5";
            this.labelItem5.Text = "سهم بیمه اول:";
            this.labelItem5.Width = 100;
            // 
            // lblIns1Part
            // 
            this.lblIns1Part.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblIns1Part.BeginGroup = true;
            this.lblIns1Part.BorderSide = DevComponents.DotNetBar.eBorderSide.None;
            this.lblIns1Part.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblIns1Part.ForeColor = System.Drawing.Color.Black;
            this.lblIns1Part.Name = "lblIns1Part";
            this.lblIns1Part.PaddingBottom = 1;
            this.lblIns1Part.PaddingLeft = 10;
            this.lblIns1Part.PaddingTop = 1;
            this.lblIns1Part.SingleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.lblIns1Part.Width = 100;
            // 
            // itemContainer6
            // 
            this.itemContainer6.ItemSpacing = 0;
            this.itemContainer6.Name = "itemContainer6";
            this.itemContainer6.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelItem7,
            this.lblIns1PatientPart});
            // 
            // labelItem7
            // 
            this.labelItem7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.labelItem7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.labelItem7.Name = "labelItem7";
            this.labelItem7.Text = "سهم بیمار:";
            this.labelItem7.Width = 100;
            // 
            // lblIns1PatientPart
            // 
            this.lblIns1PatientPart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblIns1PatientPart.BeginGroup = true;
            this.lblIns1PatientPart.BorderSide = DevComponents.DotNetBar.eBorderSide.None;
            this.lblIns1PatientPart.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblIns1PatientPart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(21)))), ((int)(((byte)(110)))));
            this.lblIns1PatientPart.Name = "lblIns1PatientPart";
            this.lblIns1PatientPart.PaddingBottom = 1;
            this.lblIns1PatientPart.PaddingLeft = 10;
            this.lblIns1PatientPart.PaddingTop = 1;
            this.lblIns1PatientPart.SingleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.lblIns1PatientPart.Stretch = true;
            this.lblIns1PatientPart.Width = 100;
            // 
            // itemContainer7
            // 
            this.itemContainer7.BeginGroup = true;
            this.itemContainer7.ItemSpacing = 0;
            this.itemContainer7.Name = "itemContainer7";
            this.itemContainer7.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelItem9,
            this.lblIns2Price});
            // 
            // labelItem9
            // 
            this.labelItem9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.labelItem9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.labelItem9.Name = "labelItem9";
            this.labelItem9.Text = "قیمت بیمه دوم:";
            this.labelItem9.Width = 100;
            // 
            // lblIns2Price
            // 
            this.lblIns2Price.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblIns2Price.BeginGroup = true;
            this.lblIns2Price.BorderSide = DevComponents.DotNetBar.eBorderSide.None;
            this.lblIns2Price.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblIns2Price.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(21)))), ((int)(((byte)(110)))));
            this.lblIns2Price.Name = "lblIns2Price";
            this.lblIns2Price.PaddingBottom = 1;
            this.lblIns2Price.PaddingLeft = 10;
            this.lblIns2Price.PaddingTop = 1;
            this.lblIns2Price.SingleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.lblIns2Price.Width = 100;
            // 
            // itemContainer8
            // 
            this.itemContainer8.ItemSpacing = 0;
            this.itemContainer8.Name = "itemContainer8";
            this.itemContainer8.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelItem11,
            this.lblIns2Part});
            // 
            // labelItem11
            // 
            this.labelItem11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.labelItem11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.labelItem11.Name = "labelItem11";
            this.labelItem11.Text = "سهم بیمه دوم:";
            this.labelItem11.Width = 100;
            // 
            // lblIns2Part
            // 
            this.lblIns2Part.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblIns2Part.BeginGroup = true;
            this.lblIns2Part.BorderSide = DevComponents.DotNetBar.eBorderSide.None;
            this.lblIns2Part.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblIns2Part.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(21)))), ((int)(((byte)(110)))));
            this.lblIns2Part.Name = "lblIns2Part";
            this.lblIns2Part.PaddingBottom = 1;
            this.lblIns2Part.PaddingLeft = 10;
            this.lblIns2Part.PaddingTop = 1;
            this.lblIns2Part.SingleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.lblIns2Part.Width = 100;
            // 
            // itemContainer10
            // 
            this.itemContainer10.BeginGroup = true;
            this.itemContainer10.ItemSpacing = 0;
            this.itemContainer10.Name = "itemContainer10";
            this.itemContainer10.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelItem2,
            this.lblPatientPayable});
            // 
            // labelItem2
            // 
            this.labelItem2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.labelItem2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.labelItem2.Name = "labelItem2";
            this.labelItem2.Text = "پرداختنی بیمار:";
            this.labelItem2.Width = 100;
            // 
            // lblPatientPayable
            // 
            this.lblPatientPayable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblPatientPayable.BeginGroup = true;
            this.lblPatientPayable.BorderSide = DevComponents.DotNetBar.eBorderSide.None;
            this.lblPatientPayable.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblPatientPayable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(21)))), ((int)(((byte)(110)))));
            this.lblPatientPayable.Name = "lblPatientPayable";
            this.lblPatientPayable.PaddingBottom = 1;
            this.lblPatientPayable.PaddingLeft = 10;
            this.lblPatientPayable.PaddingTop = 1;
            this.lblPatientPayable.SingleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.lblPatientPayable.Width = 100;
            // 
            // dgvRefServices
            // 
            this.dgvRefServices.AllowUserToAddRows = false;
            this.dgvRefServices.AllowUserToDeleteRows = false;
            this.dgvRefServices.AllowUserToOrderColumns = true;
            this.dgvRefServices.AllowUserToResizeRows = false;
            this.dgvRefServices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRefServices.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvRefServices.BackgroundColor = System.Drawing.Color.PowderBlue;
            this.dgvRefServices.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRefServices.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRefServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRefServices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColServiceName,
            this.ColQuantity,
            this.ColExpert,
            this.ColPhysician,
            this.ColIns1Price});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRefServices.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvRefServices.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvRefServices.Location = new System.Drawing.Point(0, 35);
            this.dgvRefServices.MultiSelect = false;
            this.dgvRefServices.Name = "dgvRefServices";
            this.dgvRefServices.RowHeadersVisible = false;
            this.dgvRefServices.Size = new System.Drawing.Size(794, 197);
            this.dgvRefServices.StandardTab = true;
            this.dgvRefServices.TabIndex = 7;
            this.dgvRefServices.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRefServices_CellValueChanged);
            this.dgvRefServices.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvRefServices_CellMouseClick);
            this.dgvRefServices.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvRefServices_CellBeginEdit);
            this.dgvRefServices.Enter += new System.EventHandler(this.dgvRefServices_Enter);
            this.dgvRefServices.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dgvRefServices_PreviewKeyDown);
            this.dgvRefServices.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvRefServices_CellFormatting);
            this.dgvRefServices.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvRefServices_CellValidating);
            this.dgvRefServices.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvRefServices_RowsAdded);
            this.dgvRefServices.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvRefServices_RowsRemoved);
            // 
            // ColServiceName
            // 
            this.ColServiceName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColServiceName.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColServiceName.HeaderText = "نام خدمت بیمار";
            this.ColServiceName.Name = "ColServiceName";
            this.ColServiceName.ReadOnly = true;
            this.ColServiceName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColServiceName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // ColQuantity
            // 
            this.ColQuantity.DataPropertyName = "Quantity";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColQuantity.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColQuantity.HeaderText = "تعداد";
            this.ColQuantity.MaxInputLength = 3;
            this.ColQuantity.Name = "ColQuantity";
            this.ColQuantity.Width = 40;
            // 
            // ColExpert
            // 
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Purple;
            this.ColExpert.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColExpert.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.ColExpert.DisplayStyleForCurrentCellOnly = true;
            this.ColExpert.HeaderText = "كارشناس";
            this.ColExpert.Name = "ColExpert";
            this.ColExpert.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColExpert.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColExpert.Width = 130;
            // 
            // ColPhysician
            // 
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Purple;
            this.ColPhysician.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColPhysician.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.ColPhysician.DisplayStyleForCurrentCellOnly = true;
            this.ColPhysician.HeaderText = "پزشك";
            this.ColPhysician.Name = "ColPhysician";
            this.ColPhysician.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColPhysician.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColPhysician.Width = 130;
            // 
            // ColIns1Price
            // 
            this.ColIns1Price.DataPropertyName = "Ins1Price";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = "0";
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ColIns1Price.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColIns1Price.HeaderText = "قیمت بیمه";
            this.ColIns1Price.Name = "ColIns1Price";
            this.ColIns1Price.ReadOnly = true;
            this.ColIns1Price.Width = 70;
            // 
            // PanelTotalPrices
            // 
            this.PanelTotalPrices.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelTotalPrices.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelTotalPrices.Controls.Add(this.txtPrePayment);
            this.PanelTotalPrices.Controls.Add(this.lblPrePayment);
            this.PanelTotalPrices.Controls.Add(this.txtTotalIns1Price);
            this.PanelTotalPrices.Controls.Add(this.lblTotalIns1Price);
            this.PanelTotalPrices.Controls.Add(this.lblRecievableValue);
            this.PanelTotalPrices.Controls.Add(this.txtTotalPatPartPrice);
            this.PanelTotalPrices.Controls.Add(this.lblRecievable);
            this.PanelTotalPrices.Controls.Add(this.lblTotalIns1Part);
            this.PanelTotalPrices.Controls.Add(this.txtTotalIns1Part);
            this.PanelTotalPrices.Controls.Add(this.lblTotalPatPartPrice);
            this.PanelTotalPrices.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelTotalPrices.Location = new System.Drawing.Point(0, 530);
            this.PanelTotalPrices.Name = "PanelTotalPrices";
            this.PanelTotalPrices.Size = new System.Drawing.Size(794, 42);
            this.PanelTotalPrices.Style.BackColor1.Color = System.Drawing.Color.LightBlue;
            this.PanelTotalPrices.Style.BackColor2.Color = System.Drawing.Color.White;
            this.PanelTotalPrices.Style.BorderColor.Color = System.Drawing.Color.Black;
            this.PanelTotalPrices.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.None;
            this.PanelTotalPrices.Style.GradientAngle = 90;
            this.PanelTotalPrices.TabIndex = 5;
            // 
            // txtPrePayment
            // 
            this.txtPrePayment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrePayment.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.txtPrePayment.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtPrePayment.ButtonClear.Visible = true;
            this.txtPrePayment.DisplayFormat = "#,#";
            this.txtPrePayment.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtPrePayment.Increment = 10000;
            this.txtPrePayment.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtPrePayment.Location = new System.Drawing.Point(42, 11);
            this.txtPrePayment.MaxValue = 90000000;
            this.txtPrePayment.MinValue = 0;
            this.txtPrePayment.Name = "txtPrePayment";
            this.txtPrePayment.Size = new System.Drawing.Size(102, 21);
            this.txtPrePayment.TabIndex = 0;
            this.txtPrePayment.Tag = "";
            // 
            // lblPrePayment
            // 
            this.lblPrePayment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPrePayment.BackColor = System.Drawing.Color.Transparent;
            this.lblPrePayment.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblPrePayment.ForeColor = System.Drawing.Color.Black;
            this.lblPrePayment.Location = new System.Drawing.Point(148, 6);
            this.lblPrePayment.Name = "lblPrePayment";
            this.lblPrePayment.Size = new System.Drawing.Size(43, 31);
            this.lblPrePayment.TabIndex = 9;
            this.lblPrePayment.Text = "پیش پرداخت:";
            this.lblPrePayment.TextAlignment = System.Drawing.StringAlignment.Center;
            this.lblPrePayment.WordWrap = true;
            // 
            // txtTotalIns1Price
            // 
            this.txtTotalIns1Price.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalIns1Price.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtTotalIns1Price.BackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemHotBackground2;
            this.txtTotalIns1Price.BackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemCheckedBackground2;
            this.txtTotalIns1Price.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtTotalIns1Price.BackgroundStyle.BorderBottomWidth = 2;
            this.txtTotalIns1Price.BackgroundStyle.BorderColor = System.Drawing.Color.Black;
            this.txtTotalIns1Price.BackgroundStyle.BorderColor2 = System.Drawing.Color.Black;
            this.txtTotalIns1Price.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtTotalIns1Price.BackgroundStyle.BorderLeftWidth = 2;
            this.txtTotalIns1Price.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtTotalIns1Price.BackgroundStyle.BorderRightWidth = 2;
            this.txtTotalIns1Price.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtTotalIns1Price.BackgroundStyle.BorderTopWidth = 2;
            this.txtTotalIns1Price.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtTotalIns1Price.ForeColor = System.Drawing.Color.Black;
            this.txtTotalIns1Price.Location = new System.Drawing.Point(649, 8);
            this.txtTotalIns1Price.Name = "txtTotalIns1Price";
            this.txtTotalIns1Price.Size = new System.Drawing.Size(105, 26);
            this.txtTotalIns1Price.TabIndex = 2;
            this.txtTotalIns1Price.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lblTotalIns1Price
            // 
            this.lblTotalIns1Price.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalIns1Price.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalIns1Price.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTotalIns1Price.ForeColor = System.Drawing.Color.Blue;
            this.lblTotalIns1Price.Location = new System.Drawing.Point(753, 6);
            this.lblTotalIns1Price.Name = "lblTotalIns1Price";
            this.lblTotalIns1Price.Size = new System.Drawing.Size(38, 30);
            this.lblTotalIns1Price.TabIndex = 1;
            this.lblTotalIns1Price.Text = "قیمت بیمه:";
            this.lblTotalIns1Price.TextAlignment = System.Drawing.StringAlignment.Center;
            this.lblTotalIns1Price.WordWrap = true;
            // 
            // lblRecievableValue
            // 
            this.lblRecievableValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRecievableValue.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.lblRecievableValue.BackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemHotBackground2;
            this.lblRecievableValue.BackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemCheckedBackground2;
            this.lblRecievableValue.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblRecievableValue.BackgroundStyle.BorderBottomWidth = 2;
            this.lblRecievableValue.BackgroundStyle.BorderColor = System.Drawing.Color.Black;
            this.lblRecievableValue.BackgroundStyle.BorderColor2 = System.Drawing.Color.Black;
            this.lblRecievableValue.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblRecievableValue.BackgroundStyle.BorderLeftWidth = 2;
            this.lblRecievableValue.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblRecievableValue.BackgroundStyle.BorderRightWidth = 2;
            this.lblRecievableValue.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblRecievableValue.BackgroundStyle.BorderTopWidth = 2;
            this.lblRecievableValue.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblRecievableValue.ForeColor = System.Drawing.Color.Blue;
            this.lblRecievableValue.Location = new System.Drawing.Point(197, 8);
            this.lblRecievableValue.Name = "lblRecievableValue";
            this.lblRecievableValue.Size = new System.Drawing.Size(105, 26);
            this.lblRecievableValue.TabIndex = 8;
            this.lblRecievableValue.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // txtTotalPatPartPrice
            // 
            this.txtTotalPatPartPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalPatPartPrice.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtTotalPatPartPrice.BackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemHotBackground2;
            this.txtTotalPatPartPrice.BackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemCheckedBackground2;
            this.txtTotalPatPartPrice.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtTotalPatPartPrice.BackgroundStyle.BorderBottomWidth = 2;
            this.txtTotalPatPartPrice.BackgroundStyle.BorderColor = System.Drawing.Color.Black;
            this.txtTotalPatPartPrice.BackgroundStyle.BorderColor2 = System.Drawing.Color.Black;
            this.txtTotalPatPartPrice.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtTotalPatPartPrice.BackgroundStyle.BorderLeftWidth = 2;
            this.txtTotalPatPartPrice.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtTotalPatPartPrice.BackgroundStyle.BorderRightWidth = 2;
            this.txtTotalPatPartPrice.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtTotalPatPartPrice.BackgroundStyle.BorderTopWidth = 2;
            this.txtTotalPatPartPrice.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtTotalPatPartPrice.ForeColor = System.Drawing.Color.Black;
            this.txtTotalPatPartPrice.Location = new System.Drawing.Point(505, 8);
            this.txtTotalPatPartPrice.Name = "txtTotalPatPartPrice";
            this.txtTotalPatPartPrice.Size = new System.Drawing.Size(105, 26);
            this.txtTotalPatPartPrice.TabIndex = 6;
            this.txtTotalPatPartPrice.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lblRecievable
            // 
            this.lblRecievable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRecievable.BackColor = System.Drawing.Color.Transparent;
            this.lblRecievable.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblRecievable.ForeColor = System.Drawing.Color.SaddleBrown;
            this.lblRecievable.Location = new System.Drawing.Point(304, 6);
            this.lblRecievable.Name = "lblRecievable";
            this.lblRecievable.Size = new System.Drawing.Size(55, 30);
            this.lblRecievable.TabIndex = 7;
            this.lblRecievable.Text = "قابل بازپرداخت:";
            this.lblRecievable.TextAlignment = System.Drawing.StringAlignment.Center;
            this.lblRecievable.WordWrap = true;
            // 
            // lblTotalIns1Part
            // 
            this.lblTotalIns1Part.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalIns1Part.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalIns1Part.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTotalIns1Part.ForeColor = System.Drawing.Color.Blue;
            this.lblTotalIns1Part.Location = new System.Drawing.Point(467, 6);
            this.lblTotalIns1Part.Name = "lblTotalIns1Part";
            this.lblTotalIns1Part.Size = new System.Drawing.Size(38, 30);
            this.lblTotalIns1Part.TabIndex = 3;
            this.lblTotalIns1Part.Text = "سهم بیمه:";
            this.lblTotalIns1Part.TextAlignment = System.Drawing.StringAlignment.Center;
            this.lblTotalIns1Part.WordWrap = true;
            // 
            // txtTotalIns1Part
            // 
            this.txtTotalIns1Part.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalIns1Part.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtTotalIns1Part.BackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemHotBackground2;
            this.txtTotalIns1Part.BackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemCheckedBackground2;
            this.txtTotalIns1Part.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtTotalIns1Part.BackgroundStyle.BorderBottomWidth = 2;
            this.txtTotalIns1Part.BackgroundStyle.BorderColor = System.Drawing.Color.Black;
            this.txtTotalIns1Part.BackgroundStyle.BorderColor2 = System.Drawing.Color.Black;
            this.txtTotalIns1Part.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtTotalIns1Part.BackgroundStyle.BorderLeftWidth = 2;
            this.txtTotalIns1Part.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtTotalIns1Part.BackgroundStyle.BorderRightWidth = 2;
            this.txtTotalIns1Part.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtTotalIns1Part.BackgroundStyle.BorderTopWidth = 2;
            this.txtTotalIns1Part.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtTotalIns1Part.ForeColor = System.Drawing.Color.Black;
            this.txtTotalIns1Part.Location = new System.Drawing.Point(362, 8);
            this.txtTotalIns1Part.Name = "txtTotalIns1Part";
            this.txtTotalIns1Part.Size = new System.Drawing.Size(105, 26);
            this.txtTotalIns1Part.TabIndex = 4;
            this.txtTotalIns1Part.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lblTotalPatPartPrice
            // 
            this.lblTotalPatPartPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalPatPartPrice.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalPatPartPrice.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTotalPatPartPrice.ForeColor = System.Drawing.Color.Blue;
            this.lblTotalPatPartPrice.Location = new System.Drawing.Point(610, 6);
            this.lblTotalPatPartPrice.Name = "lblTotalPatPartPrice";
            this.lblTotalPatPartPrice.Size = new System.Drawing.Size(38, 30);
            this.lblTotalPatPartPrice.TabIndex = 5;
            this.lblTotalPatPartPrice.Text = "سهم بیمار:";
            this.lblTotalPatPartPrice.TextAlignment = System.Drawing.StringAlignment.Center;
            this.lblTotalPatPartPrice.WordWrap = true;
            // 
            // PanelIns2
            // 
            this.PanelIns2.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelIns2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelIns2.Controls.Add(this.btnIns2Details);
            this.PanelIns2.Controls.Add(this.txtIns2No1);
            this.PanelIns2.Controls.Add(this.lblIns2No1);
            this.PanelIns2.Controls.Add(this.Ins2ExpireDate);
            this.PanelIns2.Controls.Add(this.lblIns2ExpireDate);
            this.PanelIns2.Controls.Add(this.cboIns2);
            this.PanelIns2.Controls.Add(this.labelX23);
            this.PanelIns2.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelIns2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.PanelIns2.Location = new System.Drawing.Point(0, 263);
            this.PanelIns2.Name = "PanelIns2";
            this.PanelIns2.Size = new System.Drawing.Size(794, 35);
            this.PanelIns2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.PanelIns2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.PanelIns2.Style.BorderColor.Color = System.Drawing.Color.Blue;
            this.PanelIns2.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.Top;
            this.PanelIns2.Style.BorderWidth = 2;
            this.PanelIns2.TabIndex = 3;
            // 
            // btnIns2Details
            // 
            this.btnIns2Details.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnIns2Details.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIns2Details.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnIns2Details.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnIns2Details.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnIns2Details.Location = new System.Drawing.Point(504, 7);
            this.btnIns2Details.Name = "btnIns2Details";
            this.btnIns2Details.Size = new System.Drawing.Size(19, 21);
            this.btnIns2Details.TabIndex = 1;
            this.btnIns2Details.TabStop = false;
            this.btnIns2Details.Tag = "Ins2";
            this.btnIns2Details.Text = "...";
            this.btnIns2Details.Click += new System.EventHandler(this.btnInsDetails_Click);
            // 
            // txtIns2No1
            // 
            this.txtIns2No1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIns2No1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtIns2No1.Border.Class = "TextBoxBorder";
            this.txtIns2No1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtIns2No1.Location = new System.Drawing.Point(320, 7);
            this.txtIns2No1.MaxLength = 20;
            this.txtIns2No1.Name = "txtIns2No1";
            this.txtIns2No1.Size = new System.Drawing.Size(129, 21);
            this.txtIns2No1.TabIndex = 2;
            this.txtIns2No1.Tag = "Ins2";
            this.txtIns2No1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblIns2No1
            // 
            this.lblIns2No1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIns2No1.AutoSize = true;
            this.lblIns2No1.BackColor = System.Drawing.Color.Transparent;
            this.lblIns2No1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblIns2No1.ForeColor = System.Drawing.Color.Fuchsia;
            this.lblIns2No1.Location = new System.Drawing.Point(457, 9);
            this.lblIns2No1.Name = "lblIns2No1";
            this.lblIns2No1.Size = new System.Drawing.Size(41, 16);
            this.lblIns2No1.TabIndex = 6;
            this.lblIns2No1.Text = "شماره:";
            this.lblIns2No1.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // Ins2ExpireDate
            // 
            this.Ins2ExpireDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Ins2ExpireDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ins2ExpireDate.IsPopupOpen = false;
            this.Ins2ExpireDate.Location = new System.Drawing.Point(174, 7);
            this.Ins2ExpireDate.Name = "Ins2ExpireDate";
            this.Ins2ExpireDate.SelectedDateTime = new System.DateTime(2010, 3, 4, 13, 50, 58, 323);
            this.Ins2ExpireDate.Size = new System.Drawing.Size(100, 21);
            this.Ins2ExpireDate.TabIndex = 4;
            this.Ins2ExpireDate.Tag = "Ins2";
            this.Ins2ExpireDate.TextHorizontalAlignment = Negar.PersianCalendar.UI.TextAlignment.Center;
            this.Ins2ExpireDate.TextVerticalAlignment = Negar.PersianCalendar.UI.TextAlignment.Center;
            // 
            // lblIns2ExpireDate
            // 
            this.lblIns2ExpireDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIns2ExpireDate.AutoSize = true;
            this.lblIns2ExpireDate.BackColor = System.Drawing.Color.Transparent;
            this.lblIns2ExpireDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblIns2ExpireDate.ForeColor = System.Drawing.Color.Fuchsia;
            this.lblIns2ExpireDate.Location = new System.Drawing.Point(280, 9);
            this.lblIns2ExpireDate.Name = "lblIns2ExpireDate";
            this.lblIns2ExpireDate.Size = new System.Drawing.Size(35, 16);
            this.lblIns2ExpireDate.TabIndex = 3;
            this.lblIns2ExpireDate.Text = "اعتبار:";
            this.lblIns2ExpireDate.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // cboIns2
            // 
            this.cboIns2.AccessibleDescription = "DropDownList";
            this.cboIns2.AccessibleName = "";
            this.cboIns2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboIns2.DropDownHeight = 250;
            this.cboIns2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIns2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cboIns2.FormattingEnabled = true;
            this.cboIns2.IntegralHeight = false;
            this.cboIns2.ItemHeight = 13;
            this.cboIns2.Location = new System.Drawing.Point(523, 7);
            this.cboIns2.Name = "cboIns2";
            this.cboIns2.Size = new System.Drawing.Size(210, 21);
            this.cboIns2.TabIndex = 0;
            this.cboIns2.TabStop = false;
            this.cboIns2.Tag = "";
            this.cboIns2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbo_KeyDown);
            // 
            // labelX23
            // 
            this.labelX23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelX23.AutoSize = true;
            this.labelX23.BackColor = System.Drawing.Color.Transparent;
            this.labelX23.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.labelX23.ForeColor = System.Drawing.Color.Fuchsia;
            this.labelX23.Location = new System.Drawing.Point(737, 9);
            this.labelX23.Name = "labelX23";
            this.labelX23.Size = new System.Drawing.Size(52, 16);
            this.labelX23.TabIndex = 5;
            this.labelX23.Text = "بیمه دوم:";
            this.labelX23.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // PanelIns1
            // 
            this.PanelIns1.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelIns1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelIns1.Controls.Add(this.cboIns1);
            this.PanelIns1.Controls.Add(this.btnIns1Details);
            this.PanelIns1.Controls.Add(this.txtPageNo);
            this.PanelIns1.Controls.Add(this.lblPageNo);
            this.PanelIns1.Controls.Add(this.lblIns1No1);
            this.PanelIns1.Controls.Add(this.lblIns1);
            this.PanelIns1.Controls.Add(this.lblIns1ExpireDate);
            this.PanelIns1.Controls.Add(this.Ins1ExpireDate);
            this.PanelIns1.Controls.Add(this.txtIns1No1);
            this.PanelIns1.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelIns1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.PanelIns1.Location = new System.Drawing.Point(0, 228);
            this.PanelIns1.Name = "PanelIns1";
            this.PanelIns1.Size = new System.Drawing.Size(794, 35);
            this.PanelIns1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.PanelIns1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.PanelIns1.Style.BorderColor.Color = System.Drawing.Color.Blue;
            this.PanelIns1.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.Top;
            this.PanelIns1.Style.BorderWidth = 2;
            this.PanelIns1.TabIndex = 2;
            // 
            // cboIns1
            // 
            this.cboIns1.AccessibleDescription = "DropDownList";
            this.cboIns1.AccessibleName = "";
            this.cboIns1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboIns1.DropDownHeight = 250;
            this.cboIns1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIns1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cboIns1.FormattingEnabled = true;
            this.cboIns1.IntegralHeight = false;
            this.cboIns1.ItemHeight = 13;
            this.cboIns1.Location = new System.Drawing.Point(523, 7);
            this.cboIns1.Name = "cboIns1";
            this.cboIns1.Size = new System.Drawing.Size(210, 21);
            this.cboIns1.TabIndex = 0;
            this.cboIns1.Tag = "";
            this.cboIns1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbo_KeyDown);
            // 
            // btnIns1Details
            // 
            this.btnIns1Details.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnIns1Details.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIns1Details.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnIns1Details.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnIns1Details.ForeColor = System.Drawing.Color.Black;
            this.btnIns1Details.Location = new System.Drawing.Point(504, 7);
            this.btnIns1Details.Name = "btnIns1Details";
            this.btnIns1Details.Size = new System.Drawing.Size(19, 21);
            this.btnIns1Details.TabIndex = 1;
            this.btnIns1Details.TabStop = false;
            this.btnIns1Details.Tag = "Ins1";
            this.btnIns1Details.Text = "...";
            this.btnIns1Details.Click += new System.EventHandler(this.btnInsDetails_Click);
            // 
            // txtPageNo
            // 
            this.txtPageNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPageNo.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.txtPageNo.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtPageNo.ButtonClear.Visible = true;
            this.txtPageNo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtPageNo.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtPageNo.Location = new System.Drawing.Point(75, 7);
            this.txtPageNo.MaxValue = 1000;
            this.txtPageNo.MinValue = 1;
            this.txtPageNo.Name = "txtPageNo";
            this.txtPageNo.ShowUpDown = true;
            this.txtPageNo.Size = new System.Drawing.Size(53, 21);
            this.txtPageNo.TabIndex = 7;
            this.txtPageNo.Tag = "Ins1";
            this.txtPageNo.Value = 1;
            // 
            // lblPageNo
            // 
            this.lblPageNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPageNo.AutoSize = true;
            this.lblPageNo.BackColor = System.Drawing.Color.Transparent;
            this.lblPageNo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblPageNo.ForeColor = System.Drawing.Color.Black;
            this.lblPageNo.Location = new System.Drawing.Point(133, 9);
            this.lblPageNo.Name = "lblPageNo";
            this.lblPageNo.Size = new System.Drawing.Size(39, 16);
            this.lblPageNo.TabIndex = 6;
            this.lblPageNo.Text = "صفحه:";
            this.lblPageNo.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblIns1No1
            // 
            this.lblIns1No1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIns1No1.AutoSize = true;
            this.lblIns1No1.BackColor = System.Drawing.Color.Transparent;
            this.lblIns1No1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblIns1No1.ForeColor = System.Drawing.Color.Black;
            this.lblIns1No1.Location = new System.Drawing.Point(457, 9);
            this.lblIns1No1.Name = "lblIns1No1";
            this.lblIns1No1.Size = new System.Drawing.Size(41, 16);
            this.lblIns1No1.TabIndex = 9;
            this.lblIns1No1.Text = "شماره:";
            this.lblIns1No1.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblIns1
            // 
            this.lblIns1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIns1.AutoSize = true;
            this.lblIns1.BackColor = System.Drawing.Color.Transparent;
            this.lblIns1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblIns1.ForeColor = System.Drawing.Color.Black;
            this.lblIns1.Location = new System.Drawing.Point(737, 9);
            this.lblIns1.Name = "lblIns1";
            this.lblIns1.Size = new System.Drawing.Size(50, 16);
            this.lblIns1.TabIndex = 8;
            this.lblIns1.Text = "بیمه اول:";
            this.lblIns1.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblIns1ExpireDate
            // 
            this.lblIns1ExpireDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIns1ExpireDate.AutoSize = true;
            this.lblIns1ExpireDate.BackColor = System.Drawing.Color.Transparent;
            this.lblIns1ExpireDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblIns1ExpireDate.ForeColor = System.Drawing.Color.Black;
            this.lblIns1ExpireDate.Location = new System.Drawing.Point(280, 9);
            this.lblIns1ExpireDate.Name = "lblIns1ExpireDate";
            this.lblIns1ExpireDate.Size = new System.Drawing.Size(35, 16);
            this.lblIns1ExpireDate.TabIndex = 10;
            this.lblIns1ExpireDate.Text = "اعتبار:";
            this.lblIns1ExpireDate.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // Ins1ExpireDate
            // 
            this.Ins1ExpireDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Ins1ExpireDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ins1ExpireDate.IsPopupOpen = false;
            this.Ins1ExpireDate.Location = new System.Drawing.Point(174, 7);
            this.Ins1ExpireDate.Name = "Ins1ExpireDate";
            this.Ins1ExpireDate.SelectedDateTime = new System.DateTime(2010, 3, 4, 13, 50, 58, 502);
            this.Ins1ExpireDate.Size = new System.Drawing.Size(100, 21);
            this.Ins1ExpireDate.TabIndex = 5;
            this.Ins1ExpireDate.Tag = "Ins1";
            this.Ins1ExpireDate.TextHorizontalAlignment = Negar.PersianCalendar.UI.TextAlignment.Center;
            this.Ins1ExpireDate.TextVerticalAlignment = Negar.PersianCalendar.UI.TextAlignment.Center;
            // 
            // txtIns1No1
            // 
            this.txtIns1No1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIns1No1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtIns1No1.Border.Class = "TextBoxBorder";
            this.txtIns1No1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtIns1No1.Location = new System.Drawing.Point(320, 7);
            this.txtIns1No1.MaxLength = 20;
            this.txtIns1No1.Name = "txtIns1No1";
            this.txtIns1No1.Size = new System.Drawing.Size(129, 21);
            this.txtIns1No1.TabIndex = 2;
            this.txtIns1No1.Tag = "Ins1";
            this.txtIns1No1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIns1No1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIns1No1_KeyPress);
            // 
            // PanelRefData
            // 
            this.PanelRefData.CanvasColor = System.Drawing.Color.Transparent;
            this.PanelRefData.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelRefData.Controls.Add(this.lblReportDate);
            this.PanelRefData.Controls.Add(this.PDateReport);
            this.PanelRefData.Controls.Add(this.lblRefDate);
            this.PanelRefData.Controls.Add(this.DateReferral);
            this.PanelRefData.Controls.Add(this.lblRefTime);
            this.PanelRefData.Controls.Add(this.TimeReferral);
            this.PanelRefData.Controls.Add(this.lblAdmiter);
            this.PanelRefData.Controls.Add(this.cboAdmitter);
            this.PanelRefData.Controls.Add(this.lblPrescribeDate);
            this.PanelRefData.Controls.Add(this.DatePrescribe);
            this.PanelRefData.Controls.Add(this.lblWeight);
            this.PanelRefData.Controls.Add(this.txtWeight);
            this.PanelRefData.Controls.Add(this.lblReferralPhysician);
            this.PanelRefData.Controls.Add(this.cboRefPhysician);
            this.PanelRefData.Controls.Add(this.btnEditPhysician);
            this.PanelRefData.Controls.Add(this.btnAddPhysician);
            this.PanelRefData.Controls.Add(this.lblRefStatus);
            this.PanelRefData.Controls.Add(this.cboRefStatus);
            this.PanelRefData.Controls.Add(this.lblDescription);
            this.PanelRefData.Controls.Add(this.txtDescription);
            this.PanelRefData.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelRefData.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.PanelRefData.Location = new System.Drawing.Point(0, 143);
            this.PanelRefData.Name = "PanelRefData";
            this.PanelRefData.Size = new System.Drawing.Size(794, 85);
            this.PanelRefData.Style.BackColor1.Color = System.Drawing.Color.PowderBlue;
            this.PanelRefData.Style.BackColor2.Color = System.Drawing.Color.White;
            this.PanelRefData.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.PanelRefData.Style.BorderColor.Color = System.Drawing.Color.Blue;
            this.PanelRefData.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.Top;
            this.PanelRefData.Style.BorderWidth = 2;
            this.PanelRefData.TabIndex = 1;
            // 
            // lblReportDate
            // 
            this.lblReportDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReportDate.AutoSize = true;
            this.lblReportDate.BackColor = System.Drawing.Color.Transparent;
            this.lblReportDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblReportDate.ForeColor = System.Drawing.Color.Blue;
            this.lblReportDate.Location = new System.Drawing.Point(116, 10);
            this.lblReportDate.Name = "lblReportDate";
            this.lblReportDate.Size = new System.Drawing.Size(60, 16);
            this.lblReportDate.TabIndex = 12;
            this.lblReportDate.Text = "ارائه نتیجه:";
            this.lblReportDate.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // PDateReport
            // 
            this.PDateReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PDateReport.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PDateReport.IsPopupOpen = false;
            this.PDateReport.Location = new System.Drawing.Point(12, 8);
            this.PDateReport.Name = "PDateReport";
            this.PDateReport.SelectedDateTime = new System.DateTime(2010, 3, 4, 13, 50, 58, 884);
            this.PDateReport.Size = new System.Drawing.Size(99, 21);
            this.PDateReport.TabIndex = 13;
            this.PDateReport.Tag = "RefData";
            // 
            // lblRefDate
            // 
            this.lblRefDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRefDate.AutoSize = true;
            this.lblRefDate.BackColor = System.Drawing.Color.Transparent;
            this.lblRefDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblRefDate.ForeColor = System.Drawing.Color.Blue;
            this.lblRefDate.Location = new System.Drawing.Point(699, 10);
            this.lblRefDate.Name = "lblRefDate";
            this.lblRefDate.Size = new System.Drawing.Size(72, 16);
            this.lblRefDate.TabIndex = 14;
            this.lblRefDate.Text = "تاریخ مراجعه:";
            this.lblRefDate.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // DateReferral
            // 
            this.DateReferral.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DateReferral.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateReferral.IsAllowNullDate = false;
            this.DateReferral.IsPopupOpen = false;
            this.DateReferral.Location = new System.Drawing.Point(595, 8);
            this.DateReferral.Name = "DateReferral";
            this.DateReferral.SelectedDateTime = new System.DateTime(2010, 3, 21, 0, 0, 0, 0);
            this.DateReferral.Size = new System.Drawing.Size(99, 21);
            this.DateReferral.TabIndex = 15;
            this.DateReferral.TabStop = false;
            this.DateReferral.Tag = "RefData";
            // 
            // lblRefTime
            // 
            this.lblRefTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRefTime.AutoSize = true;
            this.lblRefTime.BackColor = System.Drawing.Color.Transparent;
            this.lblRefTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblRefTime.ForeColor = System.Drawing.Color.Blue;
            this.lblRefTime.Location = new System.Drawing.Point(513, 10);
            this.lblRefTime.Name = "lblRefTime";
            this.lblRefTime.Size = new System.Drawing.Size(82, 16);
            this.lblRefTime.TabIndex = 16;
            this.lblRefTime.Text = "ساعت مراجعه:";
            this.lblRefTime.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // TimeReferral
            // 
            this.TimeReferral.AllowEmptyState = false;
            this.TimeReferral.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.TimeReferral.BackgroundStyle.Class = "DateTimeInputBackground";
            this.TimeReferral.CustomFormat = "HH:mm:ss";
            this.TimeReferral.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeReferral.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.TimeReferral.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.TimeReferral.Location = new System.Drawing.Point(434, 8);
            // 
            // 
            // 
            this.TimeReferral.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.TimeReferral.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.TimeReferral.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.TimeReferral.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.TimeReferral.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.TimeReferral.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.TimeReferral.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.TimeReferral.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.TimeReferral.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.TimeReferral.MonthCalendar.DisplayMonth = new System.DateTime(2008, 10, 1, 0, 0, 0, 0);
            this.TimeReferral.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Saturday;
            this.TimeReferral.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.TimeReferral.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.TimeReferral.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.TimeReferral.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.TimeReferral.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.TimeReferral.MonthCalendar.TodayButtonVisible = true;
            this.TimeReferral.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.TimeReferral.Name = "TimeReferral";
            this.TimeReferral.ShowUpDown = true;
            this.TimeReferral.Size = new System.Drawing.Size(75, 21);
            this.TimeReferral.TabIndex = 17;
            this.TimeReferral.TabStop = false;
            this.TimeReferral.Tag = "RefData";
            this.TimeReferral.Value = new System.DateTime(((long)(0)));
            this.TimeReferral.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            // 
            // lblAdmiter
            // 
            this.lblAdmiter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAdmiter.AutoSize = true;
            this.lblAdmiter.BackColor = System.Drawing.Color.Transparent;
            this.lblAdmiter.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblAdmiter.ForeColor = System.Drawing.Color.Blue;
            this.lblAdmiter.Location = new System.Drawing.Point(353, 10);
            this.lblAdmiter.Name = "lblAdmiter";
            this.lblAdmiter.Size = new System.Drawing.Size(72, 16);
            this.lblAdmiter.TabIndex = 18;
            this.lblAdmiter.Text = "پذیرش كننده:";
            this.lblAdmiter.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // cboAdmitter
            // 
            this.cboAdmitter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboAdmitter.BackColor = System.Drawing.SystemColors.Window;
            this.cboAdmitter.DisplayMember = "FullName";
            this.cboAdmitter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAdmitter.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cboAdmitter.FormattingEnabled = true;
            this.cboAdmitter.ItemHeight = 13;
            this.cboAdmitter.Location = new System.Drawing.Point(188, 8);
            this.cboAdmitter.Name = "cboAdmitter";
            this.cboAdmitter.Size = new System.Drawing.Size(162, 21);
            this.cboAdmitter.TabIndex = 19;
            this.cboAdmitter.TabStop = false;
            this.cboAdmitter.Tag = "RefData";
            this.cboAdmitter.ValueMember = "ID";
            this.cboAdmitter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbo_KeyDown);
            // 
            // lblPrescribeDate
            // 
            this.lblPrescribeDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPrescribeDate.AutoSize = true;
            this.lblPrescribeDate.BackColor = System.Drawing.Color.Transparent;
            this.lblPrescribeDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblPrescribeDate.ForeColor = System.Drawing.Color.Crimson;
            this.lblPrescribeDate.Location = new System.Drawing.Point(699, 35);
            this.lblPrescribeDate.Name = "lblPrescribeDate";
            this.lblPrescribeDate.Size = new System.Drawing.Size(67, 16);
            this.lblPrescribeDate.TabIndex = 1;
            this.lblPrescribeDate.Text = "تاریخ نسخه:";
            this.lblPrescribeDate.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // DatePrescribe
            // 
            this.DatePrescribe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DatePrescribe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DatePrescribe.IsPopupOpen = false;
            this.DatePrescribe.Location = new System.Drawing.Point(595, 33);
            this.DatePrescribe.Name = "DatePrescribe";
            this.DatePrescribe.SelectedDateTime = new System.DateTime(2010, 3, 4, 13, 50, 58, 884);
            this.DatePrescribe.Size = new System.Drawing.Size(99, 21);
            this.DatePrescribe.TabIndex = 0;
            this.DatePrescribe.Tag = "RefData";
            // 
            // lblWeight
            // 
            this.lblWeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWeight.AutoSize = true;
            this.lblWeight.BackColor = System.Drawing.Color.Transparent;
            this.lblWeight.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblWeight.ForeColor = System.Drawing.Color.Crimson;
            this.lblWeight.Location = new System.Drawing.Point(513, 35);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(53, 16);
            this.lblWeight.TabIndex = 2;
            this.lblWeight.Text = "وزن بیمار:";
            this.lblWeight.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // txtWeight
            // 
            this.txtWeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtWeight.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtWeight.ButtonClear.Visible = true;
            this.txtWeight.DisplayFormat = "# Kg";
            this.txtWeight.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWeight.Increment = 1;
            this.txtWeight.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtWeight.Location = new System.Drawing.Point(434, 33);
            this.txtWeight.MaxValue = 200;
            this.txtWeight.MinValue = 1;
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtWeight.ShowUpDown = true;
            this.txtWeight.Size = new System.Drawing.Size(75, 21);
            this.txtWeight.TabIndex = 3;
            this.txtWeight.Tag = "RefData";
            this.txtWeight.Value = 1;
            // 
            // lblReferralPhysician
            // 
            this.lblReferralPhysician.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReferralPhysician.BackColor = System.Drawing.Color.Transparent;
            this.lblReferralPhysician.Font = new System.Drawing.Font("Tahoma", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblReferralPhysician.ForeColor = System.Drawing.Color.Crimson;
            this.lblReferralPhysician.Location = new System.Drawing.Point(355, 30);
            this.lblReferralPhysician.Name = "lblReferralPhysician";
            this.lblReferralPhysician.Size = new System.Drawing.Size(78, 27);
            this.lblReferralPhysician.TabIndex = 4;
            this.lblReferralPhysician.Text = "درخواست\r\nكننده:";
            this.lblReferralPhysician.TextAlignment = System.Drawing.StringAlignment.Far;
            this.lblReferralPhysician.WordWrap = true;
            // 
            // cboRefPhysician
            // 
            this.cboRefPhysician.AccessibleDescription = "DropDown";
            this.cboRefPhysician.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboRefPhysician.AutoComplete = true;
            this.cboRefPhysician.AutoDropdown = true;
            this.cboRefPhysician.BackColorEven = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cboRefPhysician.BackColorOdd = System.Drawing.Color.White;
            this.cboRefPhysician.ColumnNames = "";
            this.cboRefPhysician.ColumnWidthDefault = 25;
            this.cboRefPhysician.ColumnWidths = "0;0;0;0;0;200;0;0;25;50;0;345;0";
            this.cboRefPhysician.DisplayMember = "FullName";
            this.cboRefPhysician.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboRefPhysician.DropDownHeight = 200;
            this.cboRefPhysician.DropDownWidth = 250;
            this.cboRefPhysician.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cboRefPhysician.ForeColor = System.Drawing.Color.Green;
            this.cboRefPhysician.FormattingEnabled = true;
            this.cboRefPhysician.IntegralHeight = false;
            this.cboRefPhysician.ItemHeight = 15;
            this.cboRefPhysician.LinkedColumnIndex = 1;
            this.cboRefPhysician.Location = new System.Drawing.Point(56, 33);
            this.cboRefPhysician.MaxDropDownItems = 10;
            this.cboRefPhysician.Name = "cboRefPhysician";
            this.cboRefPhysician.ReadOnly = false;
            this.cboRefPhysician.Size = new System.Drawing.Size(294, 21);
            this.cboRefPhysician.TabIndex = 5;
            this.cboRefPhysician.Tag = "RefData";
            this.cboRefPhysician.ValueMember = "ID";
            this.cboRefPhysician.Enter += new System.EventHandler(this.cboRefPhysician_Enter);
            this.cboRefPhysician.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboRefPhysician_KeyPress);
            this.cboRefPhysician.NoDataFound += new System.EventHandler(this.cboRefPhysician_NoDataFound);
            // 
            // btnEditPhysician
            // 
            this.btnEditPhysician.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEditPhysician.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditPhysician.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnEditPhysician.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.btnEditPhysician.Location = new System.Drawing.Point(34, 33);
            this.btnEditPhysician.Name = "btnEditPhysician";
            this.btnEditPhysician.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlR);
            this.btnEditPhysician.Size = new System.Drawing.Size(21, 21);
            this.btnEditPhysician.TabIndex = 6;
            this.btnEditPhysician.TabStop = false;
            this.btnEditPhysician.Tag = "RefData";
            this.btnEditPhysician.Text = "...";
            this.btnEditPhysician.Click += new System.EventHandler(this.btnEditPhysician_Click);
            // 
            // btnAddPhysician
            // 
            this.btnAddPhysician.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddPhysician.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddPhysician.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAddPhysician.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.btnAddPhysician.Location = new System.Drawing.Point(12, 33);
            this.btnAddPhysician.Name = "btnAddPhysician";
            this.btnAddPhysician.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlT);
            this.btnAddPhysician.Size = new System.Drawing.Size(21, 21);
            this.btnAddPhysician.TabIndex = 7;
            this.btnAddPhysician.TabStop = false;
            this.btnAddPhysician.Tag = "RefData";
            this.btnAddPhysician.Text = "+";
            this.btnAddPhysician.Click += new System.EventHandler(this.btnAddPhysician_Click);
            // 
            // lblRefStatus
            // 
            this.lblRefStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRefStatus.AutoSize = true;
            this.lblRefStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblRefStatus.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblRefStatus.ForeColor = System.Drawing.Color.Crimson;
            this.lblRefStatus.Location = new System.Drawing.Point(699, 61);
            this.lblRefStatus.Name = "lblRefStatus";
            this.lblRefStatus.Size = new System.Drawing.Size(85, 16);
            this.lblRefStatus.TabIndex = 8;
            this.lblRefStatus.Text = "وضعیت مراجعه:";
            this.lblRefStatus.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // cboRefStatus
            // 
            this.cboRefStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboRefStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRefStatus.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cboRefStatus.FormattingEnabled = true;
            this.cboRefStatus.ItemHeight = 13;
            this.cboRefStatus.Location = new System.Drawing.Point(523, 59);
            this.cboRefStatus.Name = "cboRefStatus";
            this.cboRefStatus.Size = new System.Drawing.Size(171, 21);
            this.cboRefStatus.TabIndex = 9;
            this.cboRefStatus.Tag = "RefData";
            this.cboRefStatus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbo_KeyDown);
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescription.AutoSize = true;
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblDescription.ForeColor = System.Drawing.Color.Crimson;
            this.lblDescription.Location = new System.Drawing.Point(457, 61);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(53, 16);
            this.lblDescription.TabIndex = 10;
            this.lblDescription.Text = "یادداشت:";
            this.lblDescription.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtDescription.Border.Class = "TextBoxBorder";
            this.txtDescription.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtDescription.Location = new System.Drawing.Point(12, 59);
            this.txtDescription.MaxLength = 300;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDescription.Size = new System.Drawing.Size(442, 21);
            this.txtDescription.TabIndex = 11;
            this.txtDescription.Tag = "RefData";
            // 
            // TimeTimer
            // 
            this.TimeTimer.Interval = 1000;
            this.TimeTimer.Tick += new System.EventHandler(this.TimeTimer_Tick);
            // 
            // frmPatRefManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(794, 572);
            this.Controls.Add(this.PanelRefServices);
            this.Controls.Add(this.PanelTotalPrices);
            this.Controls.Add(this.PanelIns2);
            this.Controls.Add(this.PanelIns1);
            this.Controls.Add(this.PanelRefData);
            this.Controls.Add(this.PanelPatientData);
            this.Controls.Add(this.RibbonOrders);
            this.Controls.Add(this.btnExit);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimizeBox = false;
            this.Name = "frmPatRefManager";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "بیماران - مدیریت بیمار و مراجعات";
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.Activated += new System.EventHandler(this.frmPatRefManager_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.PanelPatientData.ResumeLayout(false);
            this.PanelPatientData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAgeDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAgeMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAgeYear)).EndInit();
            this.PanelGender.ResumeLayout(false);
            this.PanelGender.PerformLayout();
            this.PanelRefServices.ResumeLayout(false);
            this.PanelRefServices.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtServiceCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmsPatientRef)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRefServices)).EndInit();
            this.PanelTotalPrices.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPrePayment)).EndInit();
            this.PanelIns2.ResumeLayout(false);
            this.PanelIns2.PerformLayout();
            this.PanelIns1.ResumeLayout(false);
            this.PanelIns1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPageNo)).EndInit();
            this.PanelRefData.ResumeLayout(false);
            this.PanelRefData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimeReferral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWeight)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx PanelPatientData;
        private DevComponents.DotNetBar.LabelX lblGender;
        private DevComponents.DotNetBar.RibbonBar RibbonOrders;
        private DevComponents.DotNetBar.ButtonItem btnRefAccount;
        private DevComponents.DotNetBar.ButtonItem btnRefDocuments;
        private DevComponents.DotNetBar.ButtonItem btnNewDocument;
        private DevComponents.DotNetBar.ButtonItem btnRefAddInData;
        private DevComponents.DotNetBar.ButtonItem btnPatientFile;
        private DevComponents.DotNetBar.ItemContainer iContainerPatientID;
        private DevComponents.DotNetBar.LabelItem lblPatientID;
        private DevComponents.DotNetBar.ButtonItem btnPrint;
        private DevComponents.DotNetBar.ItemContainer iContainerPrintTemplate;
        private DevComponents.DotNetBar.LabelItem lblPrintTemplate;
        private DevComponents.DotNetBar.ComboBoxItem cboPrintTemplates;
        private DevComponents.DotNetBar.SliderItem SliderBillPrintCount;
        private DevComponents.DotNetBar.ButtonItem btnPrintPreview;
        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        private DevComponents.DotNetBar.ButtonItem btnHelp;
        private DevComponents.DotNetBar.ButtonItem btnRefresh;
        private DevComponents.DotNetBar.ButtonItem btnNewPatient;
        private DevComponents.DotNetBar.ItemContainer iContainerPatientIDText;
        private DevComponents.DotNetBar.TextBoxItem txtPatientID;
        private DevComponents.DotNetBar.ButtonItem btnEditMode;
        private System.Windows.Forms.RadioButton cBoxFemale;
        private System.Windows.Forms.RadioButton cBoxMale;
        private System.Windows.Forms.Button btnExit;
        private DevComponents.Editors.IntegerInput txtAgeYear;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxEnterPatAge;
        private DevComponents.DotNetBar.LabelX lblBirthDate;
        private Negar.PersianCalendar.UI.Controls.PersianDatePicker DateInputBirthDate;
        private DevComponents.DotNetBar.Controls.TextBoxX txtLastName;
        private DevComponents.DotNetBar.Controls.TextBoxX txtFirstName;
        private DevComponents.DotNetBar.ButtonX btnShowEnglishLastName;
        private DevComponents.DotNetBar.ButtonX btnShowEnglishFirstName;
        private DevComponents.DotNetBar.Controls.GroupPanel PanelGender;
        private DevComponents.DotNetBar.ButtonItem btnFreePatAndRef;
        private DevComponents.DotNetBar.ButtonItem btnPrevPatient;
        private DevComponents.DotNetBar.ButtonItem btnNextPatient;
        private DevComponents.DotNetBar.LabelX lblLName;
        private DevComponents.DotNetBar.LabelX lblFName;
        private DevComponents.DotNetBar.Controls.TextBoxX txtAddress;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTel2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTel1;
        private DevComponents.DotNetBar.LabelX lblAddress;
        private DevComponents.DotNetBar.LabelX lblTel1;
        private DevComponents.DotNetBar.LabelX lblTel2;
        private DevComponents.Editors.IntegerInput txtAgeDay;
        private DevComponents.Editors.IntegerInput txtAgeMonth;
        private DevComponents.DotNetBar.PanelEx PanelRefServices;
        private System.Windows.Forms.NumericUpDown txtServiceCode;
        private DevComponents.DotNetBar.LabelX lblServiceCode;
        private DevComponents.DotNetBar.ButtonX btnChooseService;
        private DevComponents.DotNetBar.LabelX lblServiceExpert;
        private System.Windows.Forms.ComboBox cboServiceExpert;
        private DevComponents.DotNetBar.LabelX lblServicePhysician;
        private System.Windows.Forms.ComboBox cboServicePhysician;
        private DevComponents.DotNetBar.ContextMenuBar cmsPatientRef;
        private DevComponents.DotNetBar.ButtonItem cmsdgvServices;
        private DevComponents.DotNetBar.SliderItem SliderItemCount;
        private DevComponents.DotNetBar.ButtonItem btnServiceActivation;
        private DevComponents.DotNetBar.ButtonItem btnIns1Cover;
        private DevComponents.DotNetBar.ButtonItem btnIns2Cover;
        private DevComponents.DotNetBar.ButtonItem btnServicePrices;
        private DevComponents.DotNetBar.ItemContainer itemContainer1;
        private DevComponents.DotNetBar.LabelItem lblService1;
        private DevComponents.DotNetBar.LabelItem lblServiceFreePrice;
        private DevComponents.DotNetBar.ItemContainer itemContainer3;
        private DevComponents.DotNetBar.LabelItem labelItem1;
        private DevComponents.DotNetBar.LabelItem lblServiceGovPrice;
        private DevComponents.DotNetBar.ItemContainer itemContainer4;
        private DevComponents.DotNetBar.LabelItem labelItem3;
        private DevComponents.DotNetBar.LabelItem lblIns1Price;
        private DevComponents.DotNetBar.ItemContainer itemContainer5;
        private DevComponents.DotNetBar.LabelItem labelItem5;
        private DevComponents.DotNetBar.LabelItem lblIns1Part;
        private DevComponents.DotNetBar.ItemContainer itemContainer6;
        private DevComponents.DotNetBar.LabelItem labelItem7;
        private DevComponents.DotNetBar.LabelItem lblIns1PatientPart;
        private DevComponents.DotNetBar.ItemContainer itemContainer7;
        private DevComponents.DotNetBar.LabelItem labelItem9;
        private DevComponents.DotNetBar.LabelItem lblIns2Price;
        private DevComponents.DotNetBar.ItemContainer itemContainer8;
        private DevComponents.DotNetBar.LabelItem labelItem11;
        private DevComponents.DotNetBar.LabelItem lblIns2Part;
        private DevComponents.DotNetBar.ItemContainer itemContainer10;
        private DevComponents.DotNetBar.LabelItem labelItem2;
        private DevComponents.DotNetBar.LabelItem lblPatientPayable;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvRefServices;
        private DevComponents.DotNetBar.PanelEx PanelTotalPrices;
        private DevComponents.Editors.IntegerInput txtPrePayment;
        private DevComponents.DotNetBar.LabelX lblPrePayment;
        private DevComponents.DotNetBar.LabelX txtTotalIns1Price;
        private DevComponents.DotNetBar.LabelX lblTotalIns1Price;
        private DevComponents.DotNetBar.LabelX lblRecievableValue;
        private DevComponents.DotNetBar.LabelX txtTotalPatPartPrice;
        private DevComponents.DotNetBar.LabelX lblRecievable;
        private DevComponents.DotNetBar.LabelX lblTotalIns1Part;
        private DevComponents.DotNetBar.LabelX txtTotalIns1Part;
        private DevComponents.DotNetBar.LabelX lblTotalPatPartPrice;
        private DevComponents.DotNetBar.PanelEx PanelIns2;
        private DevComponents.DotNetBar.ButtonX btnIns2Details;
        private DevComponents.DotNetBar.Controls.TextBoxX txtIns2No1;
        private DevComponents.DotNetBar.LabelX lblIns2No1;
        private Negar.PersianCalendar.UI.Controls.PersianDatePicker Ins2ExpireDate;
        private DevComponents.DotNetBar.LabelX lblIns2ExpireDate;
        private System.Windows.Forms.ComboBox cboIns2;
        private DevComponents.DotNetBar.LabelX labelX23;
        private DevComponents.DotNetBar.PanelEx PanelIns1;
        private System.Windows.Forms.ComboBox cboIns1;
        private DevComponents.DotNetBar.ButtonX btnIns1Details;
        private DevComponents.Editors.IntegerInput txtPageNo;
        private DevComponents.DotNetBar.LabelX lblPageNo;
        private DevComponents.DotNetBar.LabelX lblIns1No1;
        private DevComponents.DotNetBar.LabelX lblIns1;
        private DevComponents.DotNetBar.LabelX lblIns1ExpireDate;
        private Negar.PersianCalendar.UI.Controls.PersianDatePicker Ins1ExpireDate;
        private DevComponents.DotNetBar.Controls.TextBoxX txtIns1No1;
        private DevComponents.DotNetBar.PanelEx PanelRefData;
        private DevComponents.DotNetBar.LabelX lblRefDate;
        private Negar.PersianCalendar.UI.Controls.PersianDatePicker DateReferral;
        private DevComponents.DotNetBar.LabelX lblRefTime;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput TimeReferral;
        private DevComponents.DotNetBar.LabelX lblAdmiter;
        private System.Windows.Forms.ComboBox cboAdmitter;
        private DevComponents.DotNetBar.LabelX lblPrescribeDate;
        private Negar.PersianCalendar.UI.Controls.PersianDatePicker DatePrescribe;
        private DevComponents.DotNetBar.LabelX lblWeight;
        private DevComponents.Editors.DoubleInput txtWeight;
        private DevComponents.DotNetBar.LabelX lblReferralPhysician;
        private IMSComboBox cboRefPhysician;
        private DevComponents.DotNetBar.ButtonX btnEditPhysician;
        private DevComponents.DotNetBar.ButtonX btnAddPhysician;
        private DevComponents.DotNetBar.LabelX lblRefStatus;
        private System.Windows.Forms.ComboBox cboRefStatus;
        private DevComponents.DotNetBar.LabelX lblDescription;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDescription;
        private DevComponents.DotNetBar.ItemContainer iContainerRefNav;
        private DevComponents.DotNetBar.ButtonItem btnNextRef;
        private DevComponents.DotNetBar.LabelItem lblRefID;
        private DevComponents.DotNetBar.ButtonItem btnPrevRef;
        private DevComponents.DotNetBar.ButtonItem btnNewRef;
        private System.Windows.Forms.Timer TimeTimer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColServiceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColQuantity;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColExpert;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColPhysician;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIns1Price;
        private DevComponents.DotNetBar.ButtonItem btnPrintByOtherPrinter;
        private DevComponents.DotNetBar.LabelX lblReportDate;
        private Negar.PersianCalendar.UI.Controls.PersianDatePicker PDateReport;
    }
}