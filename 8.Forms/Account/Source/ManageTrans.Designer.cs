namespace Sepehr.Forms.Account
{
    partial class frmManageTrans
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageTrans));
            this.txtValueInChar = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblValueInChar = new DevComponents.DotNetBar.LabelX();
            this.PanelTransaction = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.lblTitle = new DevComponents.DotNetBar.LabelX();
            this.lblPatientFullName = new DevComponents.DotNetBar.LabelX();
            this.txtPatientFullName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblPatientID = new DevComponents.DotNetBar.LabelX();
            this.txtPatientID = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblRefDate = new DevComponents.DotNetBar.LabelX();
            this.txtRefDate = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblPatientPayable = new DevComponents.DotNetBar.LabelX();
            this.txtPatientPayable = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblPrePayValue = new DevComponents.DotNetBar.LabelX();
            this.txtPrePayValue = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblDate = new DevComponents.DotNetBar.LabelX();
            this.TransDate = new Negar.PersianCalendar.UI.Controls.PersianDatePicker();
            this.lblTime = new DevComponents.DotNetBar.LabelX();
            this.TransTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.lblCash = new DevComponents.DotNetBar.LabelX();
            this.cboCash = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.lblCashier = new DevComponents.DotNetBar.LabelX();
            this.txtCashier = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblType = new DevComponents.DotNetBar.LabelX();
            this.PanelType = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.lblValue = new DevComponents.DotNetBar.LabelX();
            this.txtValue = new DevComponents.Editors.IntegerInput();
            this.lblRial1 = new DevComponents.DotNetBar.LabelX();
            this.lblPayType = new DevComponents.DotNetBar.LabelX();
            this.PanelPayType = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.cBoxInCash = new System.Windows.Forms.RadioButton();
            this.cBoxInCheck = new System.Windows.Forms.RadioButton();
            this.cBoxInATM = new System.Windows.Forms.RadioButton();
            this.cBoxInBill = new System.Windows.Forms.RadioButton();
            this.btnPayTypeDetails = new DevComponents.DotNetBar.ButtonX();
            this.lblComment = new DevComponents.DotNetBar.LabelX();
            this.txtDescription = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblPrintSettings = new DevComponents.DotNetBar.LabelX();
            this.PanelBillTemplateSettings = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.lblPrintTemplate = new DevComponents.DotNetBar.LabelX();
            this.cboPrintTemplates = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cBoxPrintWithCommit = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.lblPrintCount = new DevComponents.DotNetBar.LabelX();
            this.txtPrintCount = new DevComponents.Editors.IntegerInput();
            this.btnPrintPreview = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.PanelTransaction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TransTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValue)).BeginInit();
            this.PanelPayType.SuspendLayout();
            this.PanelBillTemplateSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrintCount)).BeginInit();
            this.SuspendLayout();
            // 
            // txtValueInChar
            // 
            this.txtValueInChar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValueInChar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(200)))));
            // 
            // 
            // 
            this.txtValueInChar.Border.Class = "TextBoxBorder";
            this.txtValueInChar.Font = new System.Drawing.Font("B Koodak", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtValueInChar.ForeColor = System.Drawing.Color.Navy;
            this.txtValueInChar.Location = new System.Drawing.Point(13, 203);
            this.txtValueInChar.Multiline = true;
            this.txtValueInChar.Name = "txtValueInChar";
            this.txtValueInChar.ReadOnly = true;
            this.txtValueInChar.Size = new System.Drawing.Size(376, 74);
            this.txtValueInChar.TabIndex = 10;
            this.txtValueInChar.TabStop = false;
            this.txtValueInChar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblValueInChar
            // 
            this.lblValueInChar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblValueInChar.AutoSize = true;
            this.lblValueInChar.BackColor = System.Drawing.Color.Transparent;
            this.lblValueInChar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblValueInChar.Location = new System.Drawing.Point(397, 203);
            this.lblValueInChar.Name = "lblValueInChar";
            this.lblValueInChar.Size = new System.Drawing.Size(77, 16);
            this.lblValueInChar.TabIndex = 9;
            this.lblValueInChar.Text = "مبلغ به حروف:";
            this.lblValueInChar.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // PanelTransaction
            // 
            this.PanelTransaction.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelTransaction.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelTransaction.Controls.Add(this.lblTitle);
            this.PanelTransaction.Controls.Add(this.lblPatientFullName);
            this.PanelTransaction.Controls.Add(this.txtPatientFullName);
            this.PanelTransaction.Controls.Add(this.lblPatientID);
            this.PanelTransaction.Controls.Add(this.txtPatientID);
            this.PanelTransaction.Controls.Add(this.lblRefDate);
            this.PanelTransaction.Controls.Add(this.txtRefDate);
            this.PanelTransaction.Controls.Add(this.lblPatientPayable);
            this.PanelTransaction.Controls.Add(this.txtPatientPayable);
            this.PanelTransaction.Controls.Add(this.lblPrePayValue);
            this.PanelTransaction.Controls.Add(this.txtPrePayValue);
            this.PanelTransaction.Controls.Add(this.lblDate);
            this.PanelTransaction.Controls.Add(this.TransDate);
            this.PanelTransaction.Controls.Add(this.lblTime);
            this.PanelTransaction.Controls.Add(this.TransTime);
            this.PanelTransaction.Controls.Add(this.lblCash);
            this.PanelTransaction.Controls.Add(this.cboCash);
            this.PanelTransaction.Controls.Add(this.lblCashier);
            this.PanelTransaction.Controls.Add(this.txtCashier);
            this.PanelTransaction.Controls.Add(this.lblType);
            this.PanelTransaction.Controls.Add(this.PanelType);
            this.PanelTransaction.Controls.Add(this.lblValue);
            this.PanelTransaction.Controls.Add(this.txtValue);
            this.PanelTransaction.Controls.Add(this.lblRial1);
            this.PanelTransaction.Controls.Add(this.lblValueInChar);
            this.PanelTransaction.Controls.Add(this.txtValueInChar);
            this.PanelTransaction.Controls.Add(this.lblPayType);
            this.PanelTransaction.Controls.Add(this.PanelPayType);
            this.PanelTransaction.Controls.Add(this.btnPayTypeDetails);
            this.PanelTransaction.Controls.Add(this.lblComment);
            this.PanelTransaction.Controls.Add(this.txtDescription);
            this.PanelTransaction.Controls.Add(this.lblPrintSettings);
            this.PanelTransaction.Controls.Add(this.PanelBillTemplateSettings);
            this.PanelTransaction.Controls.Add(this.btnCancel);
            this.PanelTransaction.Controls.Add(this.btnSave);
            this.PanelTransaction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelTransaction.Location = new System.Drawing.Point(0, 0);
            this.PanelTransaction.Name = "PanelTransaction";
            this.PanelTransaction.Size = new System.Drawing.Size(481, 482);
            // 
            // 
            // 
            this.PanelTransaction.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.PanelTransaction.Style.BackColorGradientAngle = 90;
            this.PanelTransaction.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.PanelTransaction.Style.BorderBottomWidth = 1;
            this.PanelTransaction.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.PanelTransaction.Style.BorderLeftWidth = 1;
            this.PanelTransaction.Style.BorderRightWidth = 1;
            this.PanelTransaction.Style.BorderTopWidth = 1;
            this.PanelTransaction.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.PanelTransaction.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.PanelTransaction.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("B Yekan", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(481, 39);
            this.lblTitle.TabIndex = 21;
            this.lblTitle.Text = "مدیریت دریافت ها و بازپرداخت های حساب بیمار";
            this.lblTitle.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lblPatientFullName
            // 
            this.lblPatientFullName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPatientFullName.AutoSize = true;
            this.lblPatientFullName.BackColor = System.Drawing.Color.Transparent;
            this.lblPatientFullName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblPatientFullName.Location = new System.Drawing.Point(397, 43);
            this.lblPatientFullName.Name = "lblPatientFullName";
            this.lblPatientFullName.Size = new System.Drawing.Size(49, 16);
            this.lblPatientFullName.TabIndex = 22;
            this.lblPatientFullName.Text = "نام بیمار:";
            this.lblPatientFullName.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // txtPatientFullName
            // 
            this.txtPatientFullName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPatientFullName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(180)))));
            // 
            // 
            // 
            this.txtPatientFullName.Border.Class = "TextBoxBorder";
            this.txtPatientFullName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtPatientFullName.ForeColor = System.Drawing.Color.Navy;
            this.txtPatientFullName.Location = new System.Drawing.Point(13, 41);
            this.txtPatientFullName.Name = "txtPatientFullName";
            this.txtPatientFullName.ReadOnly = true;
            this.txtPatientFullName.Size = new System.Drawing.Size(376, 22);
            this.txtPatientFullName.TabIndex = 23;
            this.txtPatientFullName.TabStop = false;
            // 
            // lblPatientID
            // 
            this.lblPatientID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPatientID.AutoSize = true;
            this.lblPatientID.BackColor = System.Drawing.Color.Transparent;
            this.lblPatientID.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblPatientID.Location = new System.Drawing.Point(397, 70);
            this.lblPatientID.Name = "lblPatientID";
            this.lblPatientID.Size = new System.Drawing.Size(68, 16);
            this.lblPatientID.TabIndex = 25;
            this.lblPatientID.Text = "شماره بیمار:";
            this.lblPatientID.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // txtPatientID
            // 
            this.txtPatientID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPatientID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(180)))));
            // 
            // 
            // 
            this.txtPatientID.Border.Class = "TextBoxBorder";
            this.txtPatientID.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtPatientID.ForeColor = System.Drawing.Color.Navy;
            this.txtPatientID.Location = new System.Drawing.Point(242, 68);
            this.txtPatientID.Name = "txtPatientID";
            this.txtPatientID.ReadOnly = true;
            this.txtPatientID.Size = new System.Drawing.Size(147, 22);
            this.txtPatientID.TabIndex = 26;
            this.txtPatientID.TabStop = false;
            this.txtPatientID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblRefDate
            // 
            this.lblRefDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRefDate.AutoSize = true;
            this.lblRefDate.BackColor = System.Drawing.Color.Transparent;
            this.lblRefDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblRefDate.Location = new System.Drawing.Point(169, 70);
            this.lblRefDate.Name = "lblRefDate";
            this.lblRefDate.Size = new System.Drawing.Size(71, 16);
            this.lblRefDate.TabIndex = 27;
            this.lblRefDate.Text = "زمان مراجعه:";
            this.lblRefDate.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // txtRefDate
            // 
            this.txtRefDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRefDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(180)))));
            // 
            // 
            // 
            this.txtRefDate.Border.Class = "TextBoxBorder";
            this.txtRefDate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtRefDate.ForeColor = System.Drawing.Color.Navy;
            this.txtRefDate.Location = new System.Drawing.Point(13, 68);
            this.txtRefDate.Name = "txtRefDate";
            this.txtRefDate.ReadOnly = true;
            this.txtRefDate.Size = new System.Drawing.Size(150, 22);
            this.txtRefDate.TabIndex = 28;
            this.txtRefDate.TabStop = false;
            this.txtRefDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblPatientPayable
            // 
            this.lblPatientPayable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPatientPayable.AutoSize = true;
            this.lblPatientPayable.BackColor = System.Drawing.Color.Transparent;
            this.lblPatientPayable.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblPatientPayable.Location = new System.Drawing.Point(397, 97);
            this.lblPatientPayable.Name = "lblPatientPayable";
            this.lblPatientPayable.Size = new System.Drawing.Size(81, 16);
            this.lblPatientPayable.TabIndex = 29;
            this.lblPatientPayable.Text = "پرداختنی بیمار:";
            this.lblPatientPayable.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // txtPatientPayable
            // 
            this.txtPatientPayable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPatientPayable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(180)))));
            // 
            // 
            // 
            this.txtPatientPayable.Border.Class = "TextBoxBorder";
            this.txtPatientPayable.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtPatientPayable.ForeColor = System.Drawing.Color.Navy;
            this.txtPatientPayable.Location = new System.Drawing.Point(242, 95);
            this.txtPatientPayable.Name = "txtPatientPayable";
            this.txtPatientPayable.ReadOnly = true;
            this.txtPatientPayable.Size = new System.Drawing.Size(147, 22);
            this.txtPatientPayable.TabIndex = 30;
            this.txtPatientPayable.TabStop = false;
            this.txtPatientPayable.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblPrePayValue
            // 
            this.lblPrePayValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPrePayValue.AutoSize = true;
            this.lblPrePayValue.BackColor = System.Drawing.Color.Transparent;
            this.lblPrePayValue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblPrePayValue.Location = new System.Drawing.Point(169, 97);
            this.lblPrePayValue.Name = "lblPrePayValue";
            this.lblPrePayValue.Size = new System.Drawing.Size(72, 16);
            this.lblPrePayValue.TabIndex = 31;
            this.lblPrePayValue.Text = "پیش پرداخت:";
            this.lblPrePayValue.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // txtPrePayValue
            // 
            this.txtPrePayValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrePayValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(180)))));
            // 
            // 
            // 
            this.txtPrePayValue.Border.Class = "TextBoxBorder";
            this.txtPrePayValue.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtPrePayValue.ForeColor = System.Drawing.Color.Navy;
            this.txtPrePayValue.Location = new System.Drawing.Point(13, 95);
            this.txtPrePayValue.Name = "txtPrePayValue";
            this.txtPrePayValue.ReadOnly = true;
            this.txtPrePayValue.Size = new System.Drawing.Size(150, 22);
            this.txtPrePayValue.TabIndex = 32;
            this.txtPrePayValue.TabStop = false;
            this.txtPrePayValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblDate
            // 
            this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate.AutoSize = true;
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblDate.Location = new System.Drawing.Point(397, 124);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(65, 16);
            this.lblDate.TabIndex = 33;
            this.lblDate.Text = "تاریخ اعمال:";
            this.lblDate.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // TransDate
            // 
            this.TransDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TransDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TransDate.IsAllowNullDate = false;
            this.TransDate.IsPopupOpen = false;
            this.TransDate.Location = new System.Drawing.Point(293, 124);
            this.TransDate.Name = "TransDate";
            this.TransDate.SelectedDateTime = new System.DateTime(2010, 3, 21, 0, 0, 0, 0);
            this.TransDate.Size = new System.Drawing.Size(96, 21);
            this.TransDate.TabIndex = 34;
            this.TransDate.TabStop = false;
            this.TransDate.Tag = "";
            // 
            // lblTime
            // 
            this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTime.AutoSize = true;
            this.lblTime.BackColor = System.Drawing.Color.Transparent;
            this.lblTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTime.Location = new System.Drawing.Point(169, 124);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(75, 16);
            this.lblTime.TabIndex = 35;
            this.lblTime.Text = "ساعت اعمال:";
            this.lblTime.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // TransTime
            // 
            this.TransTime.AllowEmptyState = false;
            this.TransTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.TransTime.BackgroundStyle.Class = "DateTimeInputBackground";
            this.TransTime.CustomFormat = "HH:mm:ss";
            this.TransTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.TransTime.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.TransTime.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.TransTime.Location = new System.Drawing.Point(67, 122);
            // 
            // 
            // 
            this.TransTime.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.TransTime.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.TransTime.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.TransTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.TransTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.TransTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.TransTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.TransTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.TransTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.TransTime.MonthCalendar.DisplayMonth = new System.DateTime(2008, 10, 1, 0, 0, 0, 0);
            this.TransTime.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Saturday;
            this.TransTime.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.TransTime.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.TransTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.TransTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.TransTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.TransTime.MonthCalendar.TodayButtonVisible = true;
            this.TransTime.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.TransTime.Name = "TransTime";
            this.TransTime.ShowUpDown = true;
            this.TransTime.Size = new System.Drawing.Size(96, 21);
            this.TransTime.TabIndex = 36;
            this.TransTime.TabStop = false;
            this.TransTime.Tag = "";
            this.TransTime.Value = new System.DateTime(((long)(0)));
            this.TransTime.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            // 
            // lblCash
            // 
            this.lblCash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCash.AutoSize = true;
            this.lblCash.BackColor = System.Drawing.Color.Transparent;
            this.lblCash.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblCash.Location = new System.Drawing.Point(397, 151);
            this.lblCash.Name = "lblCash";
            this.lblCash.Size = new System.Drawing.Size(44, 16);
            this.lblCash.TabIndex = 4;
            this.lblCash.Text = "صندوق:";
            this.lblCash.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // cboCash
            // 
            this.cboCash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCash.DisplayMember = "CashName";
            this.cboCash.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCash.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.cboCash.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cboCash.FormattingEnabled = true;
            this.cboCash.ItemHeight = 13;
            this.cboCash.Location = new System.Drawing.Point(242, 149);
            this.cboCash.Name = "cboCash";
            this.cboCash.Size = new System.Drawing.Size(147, 21);
            this.cboCash.TabIndex = 3;
            this.cboCash.ValueMember = "CashID";
            // 
            // lblCashier
            // 
            this.lblCashier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCashier.AutoSize = true;
            this.lblCashier.BackColor = System.Drawing.Color.Transparent;
            this.lblCashier.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblCashier.Location = new System.Drawing.Point(169, 151);
            this.lblCashier.Name = "lblCashier";
            this.lblCashier.Size = new System.Drawing.Size(72, 16);
            this.lblCashier.TabIndex = 5;
            this.lblCashier.Text = "كاربر صندوق:";
            this.lblCashier.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // txtCashier
            // 
            this.txtCashier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCashier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(200)))));
            // 
            // 
            // 
            this.txtCashier.Border.Class = "TextBoxBorder";
            this.txtCashier.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtCashier.ForeColor = System.Drawing.Color.Navy;
            this.txtCashier.Location = new System.Drawing.Point(13, 149);
            this.txtCashier.Name = "txtCashier";
            this.txtCashier.ReadOnly = true;
            this.txtCashier.Size = new System.Drawing.Size(150, 22);
            this.txtCashier.TabIndex = 6;
            this.txtCashier.TabStop = false;
            this.txtCashier.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblType
            // 
            this.lblType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblType.AutoSize = true;
            this.lblType.BackColor = System.Drawing.Color.Transparent;
            this.lblType.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblType.Location = new System.Drawing.Point(397, 179);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(65, 16);
            this.lblType.TabIndex = 7;
            this.lblType.Text = "نوع عملیات:";
            this.lblType.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // PanelType
            // 
            this.PanelType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelType.CanvasColor = System.Drawing.Color.Transparent;
            this.PanelType.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelType.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.PanelType.Location = new System.Drawing.Point(242, 176);
            this.PanelType.Name = "PanelType";
            this.PanelType.Size = new System.Drawing.Size(147, 23);
            // 
            // 
            // 
            this.PanelType.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.PanelType.Style.BackColorGradientAngle = 90;
            this.PanelType.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.PanelType.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelType.Style.BorderBottomWidth = 1;
            this.PanelType.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.PanelType.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelType.Style.BorderLeftWidth = 1;
            this.PanelType.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelType.Style.BorderRightWidth = 1;
            this.PanelType.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelType.Style.BorderTopWidth = 1;
            this.PanelType.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.PanelType.Style.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(65)))), ((int)(((byte)(0)))));
            this.PanelType.TabIndex = 8;
            this.PanelType.Text = "دریافت";
            // 
            // lblValue
            // 
            this.lblValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblValue.AutoSize = true;
            this.lblValue.BackColor = System.Drawing.Color.Transparent;
            this.lblValue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblValue.Location = new System.Drawing.Point(169, 179);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(47, 16);
            this.lblValue.TabIndex = 2;
            this.lblValue.Text = "دریافتی:";
            this.lblValue.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // txtValue
            // 
            this.txtValue.AllowEmptyState = false;
            this.txtValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtValue.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtValue.DisplayFormat = "N0";
            this.txtValue.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValue.Increment = 1000;
            this.txtValue.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtValue.Location = new System.Drawing.Point(49, 176);
            this.txtValue.MaxValue = 50000000;
            this.txtValue.MinValue = 0;
            this.txtValue.Name = "txtValue";
            this.txtValue.ShowUpDown = true;
            this.txtValue.Size = new System.Drawing.Size(114, 22);
            this.txtValue.TabIndex = 0;
            this.txtValue.Tag = "";
            this.txtValue.ValueChanged += new System.EventHandler(this.txtValue_ValueChanged);
            this.txtValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValue_KeyPress);
            // 
            // lblRial1
            // 
            this.lblRial1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRial1.AutoSize = true;
            this.lblRial1.BackColor = System.Drawing.Color.Transparent;
            this.lblRial1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblRial1.Location = new System.Drawing.Point(24, 179);
            this.lblRial1.Name = "lblRial1";
            this.lblRial1.Size = new System.Drawing.Size(24, 16);
            this.lblRial1.TabIndex = 1;
            this.lblRial1.Text = "ریال";
            this.lblRial1.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblPayType
            // 
            this.lblPayType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPayType.AutoSize = true;
            this.lblPayType.BackColor = System.Drawing.Color.Transparent;
            this.lblPayType.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblPayType.Location = new System.Drawing.Point(397, 286);
            this.lblPayType.Name = "lblPayType";
            this.lblPayType.Size = new System.Drawing.Size(66, 16);
            this.lblPayType.TabIndex = 11;
            this.lblPayType.Text = "نوع پرداخت:";
            this.lblPayType.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // PanelPayType
            // 
            this.PanelPayType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelPayType.CanvasColor = System.Drawing.Color.Transparent;
            this.PanelPayType.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelPayType.Controls.Add(this.cBoxInCash);
            this.PanelPayType.Controls.Add(this.cBoxInCheck);
            this.PanelPayType.Controls.Add(this.cBoxInATM);
            this.PanelPayType.Controls.Add(this.cBoxInBill);
            this.PanelPayType.Location = new System.Drawing.Point(158, 283);
            this.PanelPayType.Name = "PanelPayType";
            this.PanelPayType.Size = new System.Drawing.Size(231, 23);
            // 
            // 
            // 
            this.PanelPayType.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.PanelPayType.Style.BackColorGradientAngle = 90;
            this.PanelPayType.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.PanelPayType.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelPayType.Style.BorderBottomWidth = 1;
            this.PanelPayType.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.PanelPayType.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelPayType.Style.BorderLeftWidth = 1;
            this.PanelPayType.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelPayType.Style.BorderRightWidth = 1;
            this.PanelPayType.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelPayType.Style.BorderTopWidth = 1;
            this.PanelPayType.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.PanelPayType.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.PanelPayType.TabIndex = 12;
            // 
            // cBoxInCash
            // 
            this.cBoxInCash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxInCash.AutoSize = true;
            this.cBoxInCash.BackColor = System.Drawing.Color.Transparent;
            this.cBoxInCash.Checked = true;
            this.cBoxInCash.ForeColor = System.Drawing.Color.Black;
            this.cBoxInCash.Location = new System.Drawing.Point(176, 2);
            this.cBoxInCash.Name = "cBoxInCash";
            this.cBoxInCash.Size = new System.Drawing.Size(50, 17);
            this.cBoxInCash.TabIndex = 0;
            this.cBoxInCash.TabStop = true;
            this.cBoxInCash.Text = "نقدی";
            this.cBoxInCash.UseVisualStyleBackColor = false;
            this.cBoxInCash.CheckedChanged += new System.EventHandler(this.cBoxInCash_CheckedChanged);
            // 
            // cBoxInCheck
            // 
            this.cBoxInCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxInCheck.AutoSize = true;
            this.cBoxInCheck.BackColor = System.Drawing.Color.Transparent;
            this.cBoxInCheck.ForeColor = System.Drawing.Color.Black;
            this.cBoxInCheck.Location = new System.Drawing.Point(134, 2);
            this.cBoxInCheck.Name = "cBoxInCheck";
            this.cBoxInCheck.Size = new System.Drawing.Size(41, 17);
            this.cBoxInCheck.TabIndex = 1;
            this.cBoxInCheck.Text = "چك";
            this.cBoxInCheck.UseVisualStyleBackColor = false;
            this.cBoxInCheck.CheckedChanged += new System.EventHandler(this.cBoxInCheck_CheckedChanged);
            // 
            // cBoxInATM
            // 
            this.cBoxInATM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxInATM.AutoSize = true;
            this.cBoxInATM.BackColor = System.Drawing.Color.Transparent;
            this.cBoxInATM.ForeColor = System.Drawing.Color.Black;
            this.cBoxInATM.Location = new System.Drawing.Point(4, 2);
            this.cBoxInATM.Name = "cBoxInATM";
            this.cBoxInATM.Size = new System.Drawing.Size(71, 17);
            this.cBoxInATM.TabIndex = 3;
            this.cBoxInATM.Text = "كارت خوان";
            this.cBoxInATM.UseVisualStyleBackColor = false;
            this.cBoxInATM.CheckedChanged += new System.EventHandler(this.cBoxInBill_CheckedChanged);
            // 
            // cBoxInBill
            // 
            this.cBoxInBill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxInBill.AutoSize = true;
            this.cBoxInBill.BackColor = System.Drawing.Color.Transparent;
            this.cBoxInBill.ForeColor = System.Drawing.Color.Black;
            this.cBoxInBill.Location = new System.Drawing.Point(81, 2);
            this.cBoxInBill.Name = "cBoxInBill";
            this.cBoxInBill.Size = new System.Drawing.Size(48, 17);
            this.cBoxInBill.TabIndex = 2;
            this.cBoxInBill.Text = "فیش";
            this.cBoxInBill.UseVisualStyleBackColor = false;
            this.cBoxInBill.CheckedChanged += new System.EventHandler(this.cBoxInBill_CheckedChanged);
            // 
            // btnPayTypeDetails
            // 
            this.btnPayTypeDetails.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPayTypeDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPayTypeDetails.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnPayTypeDetails.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnPayTypeDetails.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right;
            this.btnPayTypeDetails.Location = new System.Drawing.Point(61, 283);
            this.btnPayTypeDetails.Name = "btnPayTypeDetails";
            this.btnPayTypeDetails.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F2);
            this.btnPayTypeDetails.Size = new System.Drawing.Size(91, 23);
            this.btnPayTypeDetails.TabIndex = 13;
            this.btnPayTypeDetails.TabStop = false;
            this.btnPayTypeDetails.Text = "جزئیات... (F2)";
            this.btnPayTypeDetails.Visible = false;
            this.btnPayTypeDetails.Click += new System.EventHandler(this.btnPayTypeDetails_Click);
            // 
            // lblComment
            // 
            this.lblComment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblComment.AutoSize = true;
            this.lblComment.BackColor = System.Drawing.Color.Transparent;
            this.lblComment.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblComment.Location = new System.Drawing.Point(397, 312);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(53, 16);
            this.lblComment.TabIndex = 14;
            this.lblComment.Text = "یادداشت:";
            this.lblComment.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtDescription.Border.Class = "TextBoxBorder";
            this.txtDescription.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtDescription.Location = new System.Drawing.Point(13, 312);
            this.txtDescription.MaxLength = 300;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(376, 21);
            this.txtDescription.TabIndex = 15;
            // 
            // lblPrintSettings
            // 
            this.lblPrintSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPrintSettings.AutoSize = true;
            this.lblPrintSettings.BackColor = System.Drawing.Color.Transparent;
            this.lblPrintSettings.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblPrintSettings.Location = new System.Drawing.Point(397, 340);
            this.lblPrintSettings.Name = "lblPrintSettings";
            this.lblPrintSettings.Size = new System.Drawing.Size(59, 16);
            this.lblPrintSettings.TabIndex = 16;
            this.lblPrintSettings.Text = "چاپ قبض:";
            this.lblPrintSettings.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // PanelBillTemplateSettings
            // 
            this.PanelBillTemplateSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelBillTemplateSettings.CanvasColor = System.Drawing.Color.Transparent;
            this.PanelBillTemplateSettings.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelBillTemplateSettings.Controls.Add(this.lblPrintTemplate);
            this.PanelBillTemplateSettings.Controls.Add(this.cboPrintTemplates);
            this.PanelBillTemplateSettings.Controls.Add(this.cBoxPrintWithCommit);
            this.PanelBillTemplateSettings.Controls.Add(this.lblPrintCount);
            this.PanelBillTemplateSettings.Controls.Add(this.txtPrintCount);
            this.PanelBillTemplateSettings.Controls.Add(this.btnPrintPreview);
            this.PanelBillTemplateSettings.Location = new System.Drawing.Point(13, 339);
            this.PanelBillTemplateSettings.Name = "PanelBillTemplateSettings";
            this.PanelBillTemplateSettings.Size = new System.Drawing.Size(376, 67);
            // 
            // 
            // 
            this.PanelBillTemplateSettings.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.PanelBillTemplateSettings.Style.BackColorGradientAngle = 90;
            this.PanelBillTemplateSettings.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.PanelBillTemplateSettings.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelBillTemplateSettings.Style.BorderBottomWidth = 1;
            this.PanelBillTemplateSettings.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.PanelBillTemplateSettings.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelBillTemplateSettings.Style.BorderLeftWidth = 1;
            this.PanelBillTemplateSettings.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelBillTemplateSettings.Style.BorderRightWidth = 1;
            this.PanelBillTemplateSettings.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelBillTemplateSettings.Style.BorderTopWidth = 1;
            this.PanelBillTemplateSettings.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.PanelBillTemplateSettings.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.PanelBillTemplateSettings.TabIndex = 17;
            // 
            // lblPrintTemplate
            // 
            this.lblPrintTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPrintTemplate.BackColor = System.Drawing.Color.Transparent;
            this.lblPrintTemplate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblPrintTemplate.Location = new System.Drawing.Point(310, 11);
            this.lblPrintTemplate.Name = "lblPrintTemplate";
            this.lblPrintTemplate.Size = new System.Drawing.Size(58, 16);
            this.lblPrintTemplate.TabIndex = 0;
            this.lblPrintTemplate.Text = "قالب چاپ:";
            this.lblPrintTemplate.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // cboPrintTemplates
            // 
            this.cboPrintTemplates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPrintTemplates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPrintTemplates.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.cboPrintTemplates.FormattingEnabled = true;
            this.cboPrintTemplates.ItemHeight = 13;
            this.cboPrintTemplates.Location = new System.Drawing.Point(105, 9);
            this.cboPrintTemplates.Name = "cboPrintTemplates";
            this.cboPrintTemplates.Size = new System.Drawing.Size(199, 21);
            this.cboPrintTemplates.TabIndex = 1;
            // 
            // cBoxPrintWithCommit
            // 
            this.cBoxPrintWithCommit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxPrintWithCommit.AutoSize = true;
            this.cBoxPrintWithCommit.BackColor = System.Drawing.Color.Transparent;
            this.cBoxPrintWithCommit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxPrintWithCommit.Location = new System.Drawing.Point(265, 38);
            this.cBoxPrintWithCommit.Name = "cBoxPrintWithCommit";
            this.cBoxPrintWithCommit.Size = new System.Drawing.Size(104, 16);
            this.cBoxPrintWithCommit.TabIndex = 2;
            this.cBoxPrintWithCommit.Text = "چاپ هنگام تایید";
            this.cBoxPrintWithCommit.CheckedChanged += new System.EventHandler(this.cBoxPrintWithCommit_CheckedChanged);
            // 
            // lblPrintCount
            // 
            this.lblPrintCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPrintCount.AutoSize = true;
            this.lblPrintCount.BackColor = System.Drawing.Color.Transparent;
            this.lblPrintCount.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblPrintCount.Location = new System.Drawing.Point(164, 38);
            this.lblPrintCount.Name = "lblPrintCount";
            this.lblPrintCount.Size = new System.Drawing.Size(58, 16);
            this.lblPrintCount.TabIndex = 3;
            this.lblPrintCount.Text = "تعداد چاپ:";
            // 
            // txtPrintCount
            // 
            this.txtPrintCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtPrintCount.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtPrintCount.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtPrintCount.Location = new System.Drawing.Point(105, 36);
            this.txtPrintCount.MaxValue = 20;
            this.txtPrintCount.MinValue = 1;
            this.txtPrintCount.Name = "txtPrintCount";
            this.txtPrintCount.ShowUpDown = true;
            this.txtPrintCount.Size = new System.Drawing.Size(53, 21);
            this.txtPrintCount.TabIndex = 4;
            this.txtPrintCount.Value = 1;
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPrintPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintPreview.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnPrintPreview.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnPrintPreview.Image = global::Sepehr.Forms.Account.Properties.Resources.PrintPreview;
            this.btnPrintPreview.Location = new System.Drawing.Point(11, 9);
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F6);
            this.btnPrintPreview.Size = new System.Drawing.Size(88, 48);
            this.btnPrintPreview.TabIndex = 5;
            this.btnPrintPreview.TabStop = false;
            this.btnPrintPreview.Text = "پیش نمایش\r\n(F6)";
            this.btnPrintPreview.Click += new System.EventHandler(this.btnPrintPreview_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Sepehr.Forms.Account.Properties.Resources.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(114, 412);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 60);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "انصراف\r\n(Esc)";
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSave.Image = global::Sepehr.Forms.Account.Properties.Resources.Accept;
            this.btnSave.Location = new System.Drawing.Point(13, 412);
            this.btnSave.Name = "btnSave";
            this.btnSave.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnSave.Size = new System.Drawing.Size(95, 58);
            this.btnSave.SubItemsExpandWidth = 15;
            this.btnSave.TabIndex = 18;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "ثبت\r\n(F8)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            // 
            // frmManageTrans
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(481, 482);
            this.Controls.Add(this.PanelTransaction);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManageTrans";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "بیماران - مراجعات - حساب بیمار - مدیریت تراكنش مالی بیمار";
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.PanelTransaction.ResumeLayout(false);
            this.PanelTransaction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TransTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValue)).EndInit();
            this.PanelPayType.ResumeLayout(false);
            this.PanelPayType.PerformLayout();
            this.PanelBillTemplateSettings.ResumeLayout(false);
            this.PanelBillTemplateSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrintCount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal DevComponents.DotNetBar.Controls.ComboBoxEx cboCash;
        internal DevComponents.DotNetBar.Controls.TextBoxX txtDescription;
        internal Negar.PersianCalendar.UI.Controls.PersianDatePicker TransDate;
        internal DevComponents.Editors.IntegerInput txtValue;
        internal DevComponents.Editors.DateTimeAdv.DateTimeInput TransTime;
        internal DevComponents.DotNetBar.Ribbon.RibbonClientPanel PanelType;
        internal System.Windows.Forms.RadioButton cBoxInCash;
        internal System.Windows.Forms.RadioButton cBoxInCheck;
        private DevComponents.DotNetBar.Controls.TextBoxX txtValueInChar;
        private DevComponents.DotNetBar.LabelX lblValueInChar;
        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel PanelTransaction;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.LabelX lblTitle;
        private DevComponents.DotNetBar.LabelX lblType;
        private DevComponents.DotNetBar.LabelX lblValue;
        private DevComponents.DotNetBar.LabelX lblCash;
        private DevComponents.DotNetBar.LabelX lblCashier;
        private DevComponents.DotNetBar.LabelX lblDate;
        private DevComponents.DotNetBar.LabelX lblTime;
        private DevComponents.DotNetBar.LabelX lblPatientFullName;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPatientFullName;
        private DevComponents.DotNetBar.LabelX lblPatientID;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPatientID;
        private DevComponents.DotNetBar.LabelX lblPrePayValue;
        private DevComponents.DotNetBar.LabelX lblPatientPayable;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPrePayValue;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPatientPayable;
        private DevComponents.DotNetBar.LabelX lblPayType;
        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel PanelBillTemplateSettings;
        private DevComponents.Editors.IntegerInput txtPrintCount;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboPrintTemplates;
        private DevComponents.DotNetBar.LabelX lblPrintCount;
        private DevComponents.DotNetBar.LabelX lblPrintTemplate;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxPrintWithCommit;
        private DevComponents.DotNetBar.LabelX lblComment;
        private DevComponents.DotNetBar.LabelX lblPrintSettings;
        private DevComponents.DotNetBar.Controls.GroupPanel PanelPayType;
        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCashier;
        private DevComponents.DotNetBar.LabelX lblRefDate;
        private DevComponents.DotNetBar.Controls.TextBoxX txtRefDate;
        private DevComponents.DotNetBar.LabelX lblRial1;
        private DevComponents.DotNetBar.ButtonX btnPayTypeDetails;
        private DevComponents.DotNetBar.ButtonX btnPrintPreview;
        internal System.Windows.Forms.RadioButton cBoxInBill;
        internal System.Windows.Forms.RadioButton cBoxInATM;
    }
}