namespace Sepehr.Forms.Documents
{
    partial class frmManageDocument
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageDocument));
            this.lblDocDate = new DevComponents.DotNetBar.LabelX();
            this.lblDocTime = new DevComponents.DotNetBar.LabelX();
            this.PanelActions = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.PanelRefData = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.lblRefDate = new DevComponents.DotNetBar.LabelX();
            this.lblPatientFullName = new DevComponents.DotNetBar.LabelX();
            this.lblPatientID = new DevComponents.DotNetBar.LabelX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.iContainerTemplates = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.btnTemplates = new DevComponents.DotNetBar.ButtonX();
            this.txtTemplateCode = new DevComponents.Editors.IntegerInput();
            this.lblTemplateCode = new DevComponents.DotNetBar.LabelX();
            this.iContainerText = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.btnTexts = new DevComponents.DotNetBar.ButtonX();
            this.txtTextCode = new DevComponents.Editors.IntegerInput();
            this.lblTextCode = new DevComponents.DotNetBar.LabelX();
            this.iContainerSettings = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.btnSetRefServicePhysicians = new DevComponents.DotNetBar.ButtonX();
            this.cboTypist = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cboDocType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.DateDoc = new Negar.PersianCalendar.UI.Controls.PersianDatePicker();
            this.lblTypist = new DevComponents.DotNetBar.LabelX();
            this.TimeDoc = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.lblDocType = new DevComponents.DotNetBar.LabelX();
            this.PanelTools = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.btnImport = new DevComponents.DotNetBar.ButtonX();
            this.btnCapture = new DevComponents.DotNetBar.ButtonX();
            this.PanelConvertDate = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.lblConvert = new DevComponents.DotNetBar.LabelX();
            this.DateFa = new Negar.PersianCalendar.UI.Controls.PersianDatePicker();
            this.DateEn = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ExPanel = new DevComponents.DotNetBar.ExpandablePanel();
            this.TimerClosing = new System.Windows.Forms.Timer(this.components);
            this.TimerFormHide = new System.Windows.Forms.Timer(this.components);
            this.PanelActions.SuspendLayout();
            this.PanelRefData.SuspendLayout();
            this.iContainerTemplates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTemplateCode)).BeginInit();
            this.iContainerText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTextCode)).BeginInit();
            this.iContainerSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimeDoc)).BeginInit();
            this.PanelTools.SuspendLayout();
            this.PanelConvertDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DateEn)).BeginInit();
            this.ExPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDocDate
            // 
            this.lblDocDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDocDate.AutoSize = true;
            this.lblDocDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDocDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblDocDate.Location = new System.Drawing.Point(177, 6);
            this.lblDocDate.Name = "lblDocDate";
            this.lblDocDate.Size = new System.Drawing.Size(32, 16);
            this.lblDocDate.TabIndex = 1;
            this.lblDocDate.Text = "تاریخ:";
            // 
            // lblDocTime
            // 
            this.lblDocTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDocTime.AutoSize = true;
            this.lblDocTime.BackColor = System.Drawing.Color.Transparent;
            this.lblDocTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblDocTime.Location = new System.Drawing.Point(62, 6);
            this.lblDocTime.Name = "lblDocTime";
            this.lblDocTime.Size = new System.Drawing.Size(30, 16);
            this.lblDocTime.TabIndex = 3;
            this.lblDocTime.Text = "زمان:";
            // 
            // PanelActions
            // 
            this.PanelActions.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelActions.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelActions.Controls.Add(this.PanelRefData);
            this.PanelActions.Controls.Add(this.btnSave);
            this.PanelActions.Controls.Add(this.iContainerTemplates);
            this.PanelActions.Controls.Add(this.iContainerText);
            this.PanelActions.Controls.Add(this.iContainerSettings);
            this.PanelActions.Controls.Add(this.PanelTools);
            this.PanelActions.Controls.Add(this.PanelConvertDate);
            this.PanelActions.Controls.Add(this.btnClose);
            this.PanelActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelActions.IsShadowEnabled = false;
            this.PanelActions.Location = new System.Drawing.Point(0, 16);
            this.PanelActions.Name = "PanelActions";
            this.PanelActions.Size = new System.Drawing.Size(765, 74);
            // 
            // 
            // 
            this.PanelActions.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.PanelActions.Style.BackColorGradientAngle = 90;
            this.PanelActions.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.PanelActions.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelActions.Style.BorderBottomWidth = 1;
            this.PanelActions.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.PanelActions.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelActions.Style.BorderLeftWidth = 1;
            this.PanelActions.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelActions.Style.BorderRightWidth = 1;
            this.PanelActions.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelActions.Style.BorderTopWidth = 1;
            this.PanelActions.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.PanelActions.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.PanelActions.TabIndex = 1;
            this.PanelActions.Tag = "0";
            // 
            // PanelRefData
            // 
            this.PanelRefData.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelRefData.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelRefData.Controls.Add(this.lblRefDate);
            this.PanelRefData.Controls.Add(this.lblPatientFullName);
            this.PanelRefData.Controls.Add(this.lblPatientID);
            this.PanelRefData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelRefData.IsShadowEnabled = false;
            this.PanelRefData.Location = new System.Drawing.Point(572, 0);
            this.PanelRefData.Name = "PanelRefData";
            this.PanelRefData.Size = new System.Drawing.Size(154, 74);
            // 
            // 
            // 
            this.PanelRefData.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.PanelRefData.Style.BackColorGradientAngle = 90;
            this.PanelRefData.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.PanelRefData.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelRefData.Style.BorderBottomColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarCaptionBackground;
            this.PanelRefData.Style.BorderBottomWidth = 1;
            this.PanelRefData.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.PanelRefData.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelRefData.Style.BorderLeftWidth = 1;
            this.PanelRefData.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelRefData.Style.BorderRightWidth = 1;
            this.PanelRefData.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelRefData.Style.BorderTopWidth = 1;
            this.PanelRefData.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.PanelRefData.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.PanelRefData.TabIndex = 13;
            // 
            // lblRefDate
            // 
            this.lblRefDate.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.lblRefDate.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblRefDate.BackgroundStyle.BorderBottomWidth = 1;
            this.lblRefDate.BackgroundStyle.BorderColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.lblRefDate.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.lblRefDate.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblRefDate.BackgroundStyle.BorderLeftWidth = 1;
            this.lblRefDate.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblRefDate.BackgroundStyle.BorderRightWidth = 1;
            this.lblRefDate.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblRefDate.BackgroundStyle.BorderTopWidth = 1;
            this.lblRefDate.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.lblRefDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRefDate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblRefDate.Location = new System.Drawing.Point(0, 50);
            this.lblRefDate.Name = "lblRefDate";
            this.lblRefDate.Size = new System.Drawing.Size(154, 25);
            this.lblRefDate.TabIndex = 1;
            this.lblRefDate.Text = "1380/01/01 - 12:45:45";
            this.lblRefDate.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lblPatientFullName
            // 
            this.lblPatientFullName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.lblPatientFullName.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblPatientFullName.BackgroundStyle.BorderBottomWidth = 1;
            this.lblPatientFullName.BackgroundStyle.BorderColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.lblPatientFullName.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.lblPatientFullName.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblPatientFullName.BackgroundStyle.BorderLeftWidth = 1;
            this.lblPatientFullName.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblPatientFullName.BackgroundStyle.BorderRightWidth = 1;
            this.lblPatientFullName.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblPatientFullName.BackgroundStyle.BorderTopWidth = 1;
            this.lblPatientFullName.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.lblPatientFullName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPatientFullName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblPatientFullName.Location = new System.Drawing.Point(0, 25);
            this.lblPatientFullName.Name = "lblPatientFullName";
            this.lblPatientFullName.Size = new System.Drawing.Size(154, 25);
            this.lblPatientFullName.TabIndex = 1;
            this.lblPatientFullName.Text = "نام بیمار";
            this.lblPatientFullName.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lblPatientID
            // 
            this.lblPatientID.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.lblPatientID.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblPatientID.BackgroundStyle.BorderBottomWidth = 1;
            this.lblPatientID.BackgroundStyle.BorderColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.lblPatientID.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.lblPatientID.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblPatientID.BackgroundStyle.BorderLeftWidth = 1;
            this.lblPatientID.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblPatientID.BackgroundStyle.BorderRightWidth = 1;
            this.lblPatientID.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblPatientID.BackgroundStyle.BorderTopWidth = 1;
            this.lblPatientID.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.lblPatientID.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPatientID.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblPatientID.Location = new System.Drawing.Point(0, 0);
            this.lblPatientID.Name = "lblPatientID";
            this.lblPatientID.Size = new System.Drawing.Size(154, 25);
            this.lblPatientID.TabIndex = 1;
            this.lblPatientID.Text = "800101100";
            this.lblPatientID.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = global::Sepehr.Forms.Documents.Properties.Resources.DocumentCheck;
            this.btnSave.ImageFixedSize = new System.Drawing.Size(40, 40);
            this.btnSave.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnSave.Location = new System.Drawing.Point(528, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor();
            this.btnSave.Size = new System.Drawing.Size(44, 74);
            this.btnSave.TabIndex = 12;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "ثبت";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // iContainerTemplates
            // 
            this.iContainerTemplates.CanvasColor = System.Drawing.SystemColors.Control;
            this.iContainerTemplates.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.iContainerTemplates.Controls.Add(this.btnTemplates);
            this.iContainerTemplates.Controls.Add(this.txtTemplateCode);
            this.iContainerTemplates.Controls.Add(this.lblTemplateCode);
            this.iContainerTemplates.Dock = System.Windows.Forms.DockStyle.Left;
            this.iContainerTemplates.IsShadowEnabled = false;
            this.iContainerTemplates.Location = new System.Drawing.Point(470, 0);
            this.iContainerTemplates.Name = "iContainerTemplates";
            this.iContainerTemplates.Size = new System.Drawing.Size(58, 74);
            // 
            // 
            // 
            this.iContainerTemplates.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.iContainerTemplates.Style.BackColor2 = System.Drawing.Color.White;
            this.iContainerTemplates.Style.BackColorGradientAngle = 90;
            this.iContainerTemplates.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.iContainerTemplates.Style.BorderBottomColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarCaptionBackground;
            this.iContainerTemplates.Style.BorderBottomWidth = 1;
            this.iContainerTemplates.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.iContainerTemplates.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.iContainerTemplates.Style.BorderLeftWidth = 1;
            this.iContainerTemplates.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.iContainerTemplates.Style.BorderRightWidth = 1;
            this.iContainerTemplates.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.iContainerTemplates.Style.BorderTopWidth = 1;
            this.iContainerTemplates.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.iContainerTemplates.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.iContainerTemplates.TabIndex = 13;
            // 
            // btnTemplates
            // 
            this.btnTemplates.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnTemplates.AutoExpandOnClick = true;
            this.btnTemplates.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange;
            this.btnTemplates.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnTemplates.ForeColor = System.Drawing.Color.Green;
            this.btnTemplates.Image = global::Sepehr.Forms.Documents.Properties.Resources.DocTemplates;
            this.btnTemplates.ImageFixedSize = new System.Drawing.Size(30, 30);
            this.btnTemplates.Location = new System.Drawing.Point(2, 40);
            this.btnTemplates.Name = "btnTemplates";
            this.btnTemplates.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor();
            this.btnTemplates.ShowSubItems = false;
            this.btnTemplates.Size = new System.Drawing.Size(54, 33);
            this.btnTemplates.SplitButton = true;
            this.btnTemplates.TabIndex = 12;
            // 
            // txtTemplateCode
            // 
            this.txtTemplateCode.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtTemplateCode.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtTemplateCode.DisplayFormat = "N0";
            this.txtTemplateCode.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtTemplateCode.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtTemplateCode.Location = new System.Drawing.Point(3, 18);
            this.txtTemplateCode.MaxValue = 10000000;
            this.txtTemplateCode.MinValue = 0;
            this.txtTemplateCode.Name = "txtTemplateCode";
            this.txtTemplateCode.ShowUpDown = true;
            this.txtTemplateCode.Size = new System.Drawing.Size(53, 21);
            this.txtTemplateCode.TabIndex = 3;
            this.txtTemplateCode.Tag = "";
            this.txtTemplateCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTemplate_KeyPress);
            // 
            // lblTemplateCode
            // 
            this.lblTemplateCode.BackColor = System.Drawing.Color.Transparent;
            this.lblTemplateCode.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTemplateCode.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTemplateCode.ForeColor = System.Drawing.Color.Black;
            this.lblTemplateCode.Location = new System.Drawing.Point(0, 0);
            this.lblTemplateCode.Name = "lblTemplateCode";
            this.lblTemplateCode.Size = new System.Drawing.Size(58, 17);
            this.lblTemplateCode.TabIndex = 8;
            this.lblTemplateCode.Text = "كد قالب:";
            this.lblTemplateCode.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // iContainerText
            // 
            this.iContainerText.CanvasColor = System.Drawing.SystemColors.Control;
            this.iContainerText.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.iContainerText.Controls.Add(this.btnTexts);
            this.iContainerText.Controls.Add(this.txtTextCode);
            this.iContainerText.Controls.Add(this.lblTextCode);
            this.iContainerText.Dock = System.Windows.Forms.DockStyle.Left;
            this.iContainerText.IsShadowEnabled = false;
            this.iContainerText.Location = new System.Drawing.Point(412, 0);
            this.iContainerText.Name = "iContainerText";
            this.iContainerText.Size = new System.Drawing.Size(58, 74);
            // 
            // 
            // 
            this.iContainerText.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(195)))), ((int)(((byte)(198)))));
            this.iContainerText.Style.BackColor2 = System.Drawing.Color.White;
            this.iContainerText.Style.BackColorGradientAngle = 90;
            this.iContainerText.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.iContainerText.Style.BorderBottomColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarCaptionBackground;
            this.iContainerText.Style.BorderBottomWidth = 1;
            this.iContainerText.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.iContainerText.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.iContainerText.Style.BorderLeftWidth = 1;
            this.iContainerText.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.iContainerText.Style.BorderRightWidth = 1;
            this.iContainerText.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.iContainerText.Style.BorderTopWidth = 1;
            this.iContainerText.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.iContainerText.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.iContainerText.TabIndex = 13;
            // 
            // btnTexts
            // 
            this.btnTexts.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnTexts.AutoExpandOnClick = true;
            this.btnTexts.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange;
            this.btnTexts.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnTexts.ForeColor = System.Drawing.Color.Crimson;
            this.btnTexts.Image = global::Sepehr.Forms.Documents.Properties.Resources.DocToolbar;
            this.btnTexts.ImageFixedSize = new System.Drawing.Size(30, 30);
            this.btnTexts.Location = new System.Drawing.Point(2, 40);
            this.btnTexts.Name = "btnTexts";
            this.btnTexts.ShowSubItems = false;
            this.btnTexts.Size = new System.Drawing.Size(54, 33);
            this.btnTexts.TabIndex = 12;
            // 
            // txtTextCode
            // 
            this.txtTextCode.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtTextCode.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtTextCode.DisplayFormat = "N0";
            this.txtTextCode.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtTextCode.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtTextCode.Location = new System.Drawing.Point(3, 18);
            this.txtTextCode.MaxValue = 10000000;
            this.txtTextCode.MinValue = 0;
            this.txtTextCode.Name = "txtTextCode";
            this.txtTextCode.ShowUpDown = true;
            this.txtTextCode.Size = new System.Drawing.Size(53, 21);
            this.txtTextCode.TabIndex = 3;
            this.txtTextCode.Tag = "";
            this.txtTextCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTextCode_KeyPress);
            // 
            // lblTextCode
            // 
            this.lblTextCode.BackColor = System.Drawing.Color.Transparent;
            this.lblTextCode.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTextCode.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTextCode.ForeColor = System.Drawing.Color.Crimson;
            this.lblTextCode.Location = new System.Drawing.Point(0, 0);
            this.lblTextCode.Name = "lblTextCode";
            this.lblTextCode.Size = new System.Drawing.Size(58, 16);
            this.lblTextCode.TabIndex = 8;
            this.lblTextCode.Text = "كد متن:";
            this.lblTextCode.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // iContainerSettings
            // 
            this.iContainerSettings.CanvasColor = System.Drawing.SystemColors.Control;
            this.iContainerSettings.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.iContainerSettings.Controls.Add(this.btnSetRefServicePhysicians);
            this.iContainerSettings.Controls.Add(this.cboTypist);
            this.iContainerSettings.Controls.Add(this.cboDocType);
            this.iContainerSettings.Controls.Add(this.DateDoc);
            this.iContainerSettings.Controls.Add(this.lblTypist);
            this.iContainerSettings.Controls.Add(this.TimeDoc);
            this.iContainerSettings.Controls.Add(this.lblDocType);
            this.iContainerSettings.Controls.Add(this.lblDocTime);
            this.iContainerSettings.Controls.Add(this.lblDocDate);
            this.iContainerSettings.Dock = System.Windows.Forms.DockStyle.Left;
            this.iContainerSettings.IsShadowEnabled = false;
            this.iContainerSettings.Location = new System.Drawing.Point(199, 0);
            this.iContainerSettings.Name = "iContainerSettings";
            this.iContainerSettings.Size = new System.Drawing.Size(213, 74);
            // 
            // 
            // 
            this.iContainerSettings.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.iContainerSettings.Style.BackColorGradientAngle = 90;
            this.iContainerSettings.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.iContainerSettings.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.iContainerSettings.Style.BorderBottomColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarCaptionBackground;
            this.iContainerSettings.Style.BorderBottomWidth = 1;
            this.iContainerSettings.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.iContainerSettings.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.iContainerSettings.Style.BorderLeftWidth = 1;
            this.iContainerSettings.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.iContainerSettings.Style.BorderRightWidth = 1;
            this.iContainerSettings.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.iContainerSettings.Style.BorderTopWidth = 1;
            this.iContainerSettings.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.iContainerSettings.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.iContainerSettings.TabIndex = 13;
            // 
            // btnSetRefServicePhysicians
            // 
            this.btnSetRefServicePhysicians.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSetRefServicePhysicians.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange;
            this.btnSetRefServicePhysicians.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSetRefServicePhysicians.ForeColor = System.Drawing.Color.Crimson;
            this.btnSetRefServicePhysicians.Image = global::Sepehr.Forms.Documents.Properties.Resources.Physician;
            this.btnSetRefServicePhysicians.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnSetRefServicePhysicians.Location = new System.Drawing.Point(4, 51);
            this.btnSetRefServicePhysicians.Name = "btnSetRefServicePhysicians";
            this.btnSetRefServicePhysicians.ShowSubItems = false;
            this.btnSetRefServicePhysicians.Size = new System.Drawing.Size(25, 21);
            this.btnSetRefServicePhysicians.TabIndex = 13;
            this.btnSetRefServicePhysicians.Click += new System.EventHandler(this.btnSetRefServicePhysicians_Click);
            // 
            // cboTypist
            // 
            this.cboTypist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTypist.DisplayMember = "Name";
            this.cboTypist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cboTypist.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.cboTypist.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cboTypist.ItemHeight = 13;
            this.cboTypist.Location = new System.Drawing.Point(31, 51);
            this.cboTypist.Name = "cboTypist";
            this.cboTypist.Size = new System.Drawing.Size(119, 21);
            this.cboTypist.TabIndex = 0;
            this.cboTypist.ValueMember = "ID";
            this.cboTypist.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ComboBoxEx_KeyPress);
            this.cboTypist.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ComboBoxEx_KeyDown);
            // 
            // cboDocType
            // 
            this.cboDocType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDocType.DisplayMember = "Name";
            this.cboDocType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDocType.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.cboDocType.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cboDocType.ItemHeight = 13;
            this.cboDocType.Location = new System.Drawing.Point(4, 28);
            this.cboDocType.Name = "cboDocType";
            this.cboDocType.Size = new System.Drawing.Size(146, 21);
            this.cboDocType.TabIndex = 0;
            this.cboDocType.ValueMember = "ID";
            // 
            // DateDoc
            // 
            this.DateDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DateDoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateDoc.IsAllowNullDate = false;
            this.DateDoc.IsPopupOpen = false;
            this.DateDoc.Location = new System.Drawing.Point(95, 4);
            this.DateDoc.Name = "DateDoc";
            this.DateDoc.SelectedDateTime = new System.DateTime(2009, 7, 16, 10, 41, 0, 0);
            this.DateDoc.Size = new System.Drawing.Size(83, 20);
            this.DateDoc.TabIndex = 2;
            this.DateDoc.TabStop = false;
            // 
            // lblTypist
            // 
            this.lblTypist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTypist.AutoSize = true;
            this.lblTypist.BackColor = System.Drawing.Color.Transparent;
            this.lblTypist.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTypist.Location = new System.Drawing.Point(153, 53);
            this.lblTypist.Name = "lblTypist";
            this.lblTypist.Size = new System.Drawing.Size(56, 16);
            this.lblTypist.TabIndex = 3;
            this.lblTypist.Text = "ثبت كننده:";
            // 
            // TimeDoc
            // 
            this.TimeDoc.AllowEmptyState = false;
            this.TimeDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.TimeDoc.BackgroundStyle.Class = "DateTimeInputBackground";
            this.TimeDoc.CustomFormat = "HH:mm";
            this.TimeDoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.TimeDoc.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.TimeDoc.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.TimeDoc.Location = new System.Drawing.Point(4, 4);
            // 
            // 
            // 
            this.TimeDoc.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.TimeDoc.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.TimeDoc.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.TimeDoc.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.TimeDoc.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.TimeDoc.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.TimeDoc.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.TimeDoc.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.TimeDoc.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.TimeDoc.MonthCalendar.DisplayMonth = new System.DateTime(2008, 10, 1, 0, 0, 0, 0);
            this.TimeDoc.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Saturday;
            this.TimeDoc.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.TimeDoc.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.TimeDoc.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.TimeDoc.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.TimeDoc.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.TimeDoc.MonthCalendar.TodayButtonVisible = true;
            this.TimeDoc.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.TimeDoc.Name = "TimeDoc";
            this.TimeDoc.ShowUpDown = true;
            this.TimeDoc.Size = new System.Drawing.Size(58, 21);
            this.TimeDoc.TabIndex = 4;
            this.TimeDoc.TabStop = false;
            this.TimeDoc.Tag = "";
            this.TimeDoc.Value = new System.DateTime(((long)(0)));
            this.TimeDoc.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            // 
            // lblDocType
            // 
            this.lblDocType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDocType.AutoSize = true;
            this.lblDocType.BackColor = System.Drawing.Color.Transparent;
            this.lblDocType.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblDocType.Location = new System.Drawing.Point(153, 30);
            this.lblDocType.Name = "lblDocType";
            this.lblDocType.Size = new System.Drawing.Size(55, 16);
            this.lblDocType.TabIndex = 3;
            this.lblDocType.Text = "نوع مدرك:";
            // 
            // PanelTools
            // 
            this.PanelTools.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelTools.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelTools.Controls.Add(this.btnImport);
            this.PanelTools.Controls.Add(this.btnCapture);
            this.PanelTools.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelTools.IsShadowEnabled = false;
            this.PanelTools.Location = new System.Drawing.Point(109, 0);
            this.PanelTools.Name = "PanelTools";
            this.PanelTools.Size = new System.Drawing.Size(90, 74);
            // 
            // 
            // 
            this.PanelTools.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.PanelTools.Style.BackColorGradientAngle = 90;
            this.PanelTools.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.PanelTools.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelTools.Style.BorderBottomColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarCaptionBackground;
            this.PanelTools.Style.BorderBottomWidth = 1;
            this.PanelTools.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.PanelTools.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelTools.Style.BorderLeftWidth = 1;
            this.PanelTools.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelTools.Style.BorderRightWidth = 1;
            this.PanelTools.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelTools.Style.BorderTopWidth = 1;
            this.PanelTools.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.PanelTools.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.PanelTools.TabIndex = 14;
            // 
            // btnImport
            // 
            this.btnImport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnImport.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnImport.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnImport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnImport.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnImport.ForeColor = System.Drawing.Color.Blue;
            this.btnImport.Image = global::Sepehr.Forms.Documents.Properties.Resources.Browse;
            this.btnImport.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnImport.Location = new System.Drawing.Point(0, 37);
            this.btnImport.Name = "btnImport";
            this.btnImport.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor();
            this.btnImport.Size = new System.Drawing.Size(90, 37);
            this.btnImport.TabIndex = 14;
            this.btnImport.TabStop = false;
            this.btnImport.Text = "خواندن\r\nاز فایل...";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnCapture
            // 
            this.btnCapture.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCapture.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCapture.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCapture.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCapture.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnCapture.ForeColor = System.Drawing.Color.Blue;
            this.btnCapture.Image = global::Sepehr.Forms.Documents.Properties.Resources.PrintPreview;
            this.btnCapture.Location = new System.Drawing.Point(0, 0);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor();
            this.btnCapture.Size = new System.Drawing.Size(90, 37);
            this.btnCapture.TabIndex = 13;
            this.btnCapture.TabStop = false;
            this.btnCapture.Text = "Capture تصاویر";
            this.btnCapture.Click += new System.EventHandler(this.btnCaptureImage_Click);
            // 
            // PanelConvertDate
            // 
            this.PanelConvertDate.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelConvertDate.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelConvertDate.Controls.Add(this.lblConvert);
            this.PanelConvertDate.Controls.Add(this.DateFa);
            this.PanelConvertDate.Controls.Add(this.DateEn);
            this.PanelConvertDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelConvertDate.IsShadowEnabled = false;
            this.PanelConvertDate.Location = new System.Drawing.Point(0, 0);
            this.PanelConvertDate.Name = "PanelConvertDate";
            this.PanelConvertDate.Size = new System.Drawing.Size(109, 74);
            // 
            // 
            // 
            this.PanelConvertDate.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.PanelConvertDate.Style.BackColorGradientAngle = 90;
            this.PanelConvertDate.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.PanelConvertDate.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelConvertDate.Style.BorderBottomColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarCaptionBackground;
            this.PanelConvertDate.Style.BorderBottomWidth = 1;
            this.PanelConvertDate.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.PanelConvertDate.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelConvertDate.Style.BorderLeftWidth = 1;
            this.PanelConvertDate.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelConvertDate.Style.BorderRightWidth = 1;
            this.PanelConvertDate.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelConvertDate.Style.BorderTopWidth = 1;
            this.PanelConvertDate.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.PanelConvertDate.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.PanelConvertDate.TabIndex = 13;
            // 
            // lblConvert
            // 
            this.lblConvert.BackColor = System.Drawing.Color.Transparent;
            this.lblConvert.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblConvert.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblConvert.Location = new System.Drawing.Point(0, 0);
            this.lblConvert.Name = "lblConvert";
            this.lblConvert.Size = new System.Drawing.Size(109, 17);
            this.lblConvert.TabIndex = 8;
            this.lblConvert.Text = "مبدل تقویم:";
            this.lblConvert.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // DateFa
            // 
            this.DateFa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DateFa.IsAllowNullDate = false;
            this.DateFa.IsPopupOpen = false;
            this.DateFa.Location = new System.Drawing.Point(5, 23);
            this.DateFa.Name = "DateFa";
            this.DateFa.SelectedDateTime = new System.DateTime(2009, 7, 16, 10, 41, 0, 0);
            this.DateFa.Size = new System.Drawing.Size(101, 21);
            this.DateFa.TabIndex = 6;
            this.DateFa.TabStop = false;
            this.DateFa.SelectedDateTimeChanged += new System.EventHandler(this.DateFa_SelectedDateTimeChanged);
            // 
            // DateEn
            // 
            this.DateEn.AllowEmptyState = false;
            this.DateEn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.DateEn.BackgroundStyle.Class = "DateTimeInputBackground";
            this.DateEn.ButtonDropDown.Visible = true;
            this.DateEn.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.DateEn.Location = new System.Drawing.Point(5, 49);
            // 
            // 
            // 
            this.DateEn.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.DateEn.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.DateEn.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.DateEn.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.DateEn.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.DateEn.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.DateEn.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.DateEn.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.DateEn.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.DateEn.MonthCalendar.DisplayMonth = new System.DateTime(2008, 10, 1, 0, 0, 0, 0);
            this.DateEn.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Saturday;
            this.DateEn.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.DateEn.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.DateEn.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.DateEn.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.DateEn.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.DateEn.MonthCalendar.TodayButtonVisible = true;
            this.DateEn.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.DateEn.Name = "DateEn";
            this.DateEn.ShowUpDown = true;
            this.DateEn.Size = new System.Drawing.Size(101, 21);
            this.DateEn.TabIndex = 7;
            this.DateEn.TabStop = false;
            this.DateEn.Tag = "";
            this.DateEn.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            this.DateEn.ValueChanged += new System.EventHandler(this.DateEn_ValueChanged);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnClose.ForeColor = System.Drawing.Color.DarkViolet;
            this.btnClose.Image = global::Sepehr.Forms.Documents.Properties.Resources.Cancel;
            this.btnClose.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnClose.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnClose.Location = new System.Drawing.Point(726, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor();
            this.btnClose.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.AltF4);
            this.btnClose.Size = new System.Drawing.Size(39, 74);
            this.btnClose.TabIndex = 0;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "خروح";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.FileName = "openFileDialog1";
            // 
            // ExPanel
            // 
            this.ExPanel.AnimationTime = 1;
            this.ExPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.ExPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.ExPanel.Controls.Add(this.PanelActions);
            this.ExPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExPanel.ExpandButtonVisible = false;
            this.ExPanel.ExpandOnTitleClick = true;
            this.ExPanel.Location = new System.Drawing.Point(0, 0);
            this.ExPanel.Name = "ExPanel";
            this.ExPanel.Size = new System.Drawing.Size(765, 90);
            this.ExPanel.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.ExPanel.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.ExPanel.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.ExPanel.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.ExPanel.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.ExPanel.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.ExPanel.Style.GradientAngle = 90;
            this.ExPanel.TabIndex = 0;
            this.ExPanel.TitleHeight = 16;
            this.ExPanel.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.ExPanel.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.ExPanel.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.ExPanel.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.ExPanel.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.ExPanel.TitleStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ExPanel.TitleStyle.ForeColor.Color = System.Drawing.Color.Blue;
            this.ExPanel.TitleStyle.GradientAngle = 90;
            this.ExPanel.TitleText = "ابزارهای جوابدهی";
            this.ExPanel.ExpandedChanged += new DevComponents.DotNetBar.ExpandChangeEventHandler(this.ExPanel_ExpandedChanged);
            // 
            // TimerClosing
            // 
            this.TimerClosing.Interval = 500;
            this.TimerClosing.Tick += new System.EventHandler(this.TimerClosing_Tick);
            // 
            // TimerFormHide
            // 
            this.TimerFormHide.Interval = 10000;
            this.TimerFormHide.Tick += new System.EventHandler(this.TimerFormHide_Tick);
            // 
            // frmManageDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(765, 90);
            this.Controls.Add(this.ExPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "frmManageDocument";
            this.Opacity = 0.01;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "بیماران - مراجعات - مدارك - انتشار مدرك برای مراجعه بیمار";
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.PanelActions.ResumeLayout(false);
            this.PanelRefData.ResumeLayout(false);
            this.iContainerTemplates.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTemplateCode)).EndInit();
            this.iContainerText.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTextCode)).EndInit();
            this.iContainerSettings.ResumeLayout(false);
            this.iContainerSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimeDoc)).EndInit();
            this.PanelTools.ResumeLayout(false);
            this.PanelConvertDate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DateEn)).EndInit();
            this.ExPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX lblDocDate;
        private DevComponents.DotNetBar.LabelX lblDocTime;
        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel PanelActions;
        private Negar.PersianCalendar.UI.Controls.PersianDatePicker DateDoc;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput TimeDoc;
        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        private Negar.PersianCalendar.UI.Controls.PersianDatePicker DateFa;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput DateEn;
        private DevComponents.DotNetBar.LabelX lblConvert;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private DevComponents.DotNetBar.ExpandablePanel ExPanel;
        private System.Windows.Forms.Timer TimerClosing;
        private System.Windows.Forms.Timer TimerFormHide;
        private DevComponents.DotNetBar.LabelX lblPatientFullName;
        private DevComponents.DotNetBar.LabelX lblPatientID;
        private DevComponents.DotNetBar.LabelX lblRefDate;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel iContainerTemplates;
        internal DevComponents.DotNetBar.Controls.ComboBoxEx cboDocType;
        internal DevComponents.Editors.IntegerInput txtTemplateCode;
        private DevComponents.DotNetBar.LabelX lblTemplateCode;
        private DevComponents.DotNetBar.ButtonX btnTemplates;
        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel iContainerText;
        internal DevComponents.Editors.IntegerInput txtTextCode;
        private DevComponents.DotNetBar.LabelX lblTextCode;
        private DevComponents.DotNetBar.ButtonX btnTexts;
        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel iContainerSettings;
        private DevComponents.DotNetBar.LabelX lblDocType;
        internal DevComponents.DotNetBar.Controls.ComboBoxEx cboTypist;
        private DevComponents.DotNetBar.LabelX lblTypist;
        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel PanelRefData;
        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel PanelConvertDate;
        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel PanelTools;
        private DevComponents.DotNetBar.ButtonX btnImport;
        private DevComponents.DotNetBar.ButtonX btnCapture;
        private DevComponents.DotNetBar.ButtonX btnSetRefServicePhysicians;
    }
}