namespace Sepehr.Documents
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageDocument));
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.iContainerSettings = new DevComponents.DotNetBar.ItemContainer();
            this.iContainerDocType = new DevComponents.DotNetBar.ItemContainer();
            this.lblDocType = new DevComponents.DotNetBar.LabelItem();
            this.iContainerRefPhysician = new DevComponents.DotNetBar.ItemContainer();
            this.lblRefPhysician = new DevComponents.DotNetBar.LabelItem();
            this.cboDocPhysician = new DevComponents.DotNetBar.ComboBoxItem();
            this.iContainerTypist = new DevComponents.DotNetBar.ItemContainer();
            this.lblTypist = new DevComponents.DotNetBar.LabelItem();
            this.cboTypist = new DevComponents.DotNetBar.ComboBoxItem();
            this.cboDocType = new DevComponents.DotNetBar.ComboBoxItem();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTemplateCode = new DevComponents.Editors.IntegerInput();
            this.txtDescription = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblTemplateCode = new DevComponents.DotNetBar.LabelX();
            this.lblDescription = new DevComponents.DotNetBar.LabelX();
            this.txtName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblName = new DevComponents.DotNetBar.LabelX();
            this.RibbonBarForm = new DevComponents.DotNetBar.Bar();
            this.btnClose = new DevComponents.DotNetBar.ButtonItem();
            this.btnSave = new DevComponents.DotNetBar.ButtonItem();
            this.btnPrint = new DevComponents.DotNetBar.ButtonItem();
            this.btnHelp = new DevComponents.DotNetBar.ButtonItem();
            this.btnImport = new DevComponents.DotNetBar.ButtonX();
            this.btnAddinFieldsList = new DevComponents.DotNetBar.ButtonX();
            this.ribbonClientPanel1 = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTemplateCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonBarForm)).BeginInit();
            this.ribbonClientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.FileName = "openFileDialog1";
            // 
            // iContainerSettings
            // 
            this.iContainerSettings.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.iContainerSettings.Name = "iContainerSettings";
            this.iContainerSettings.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.iContainerDocType,
            this.iContainerRefPhysician,
            this.iContainerTypist,
            this.cboDocType});
            this.iContainerSettings.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle;
            // 
            // iContainerDocType
            // 
            this.iContainerDocType.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center;
            this.iContainerDocType.Name = "iContainerDocType";
            this.iContainerDocType.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.lblDocType});
            this.iContainerDocType.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle;
            // 
            // lblDocType
            // 
            this.lblDocType.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblDocType.ForeColor = System.Drawing.Color.Green;
            this.lblDocType.Name = "lblDocType";
            this.lblDocType.PaddingLeft = 4;
            this.lblDocType.PaddingRight = 4;
            this.lblDocType.Text = "نوع مدرك:";
            this.lblDocType.Width = 95;
            // 
            // iContainerRefPhysician
            // 
            this.iContainerRefPhysician.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center;
            this.iContainerRefPhysician.Name = "iContainerRefPhysician";
            this.iContainerRefPhysician.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.lblRefPhysician,
            this.cboDocPhysician});
            this.iContainerRefPhysician.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle;
            // 
            // lblRefPhysician
            // 
            this.lblRefPhysician.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblRefPhysician.ForeColor = System.Drawing.Color.Green;
            this.lblRefPhysician.Name = "lblRefPhysician";
            this.lblRefPhysician.PaddingLeft = 4;
            this.lblRefPhysician.PaddingRight = 4;
            this.lblRefPhysician.Text = "پزشك متخصص:";
            this.lblRefPhysician.Width = 95;
            // 
            // cboDocPhysician
            // 
            this.cboDocPhysician.Caption = "comboBoxItem1";
            this.cboDocPhysician.ComboWidth = 150;
            this.cboDocPhysician.DropDownHeight = 106;
            this.cboDocPhysician.Name = "cboDocPhysician";
            // 
            // iContainerTypist
            // 
            this.iContainerTypist.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center;
            this.iContainerTypist.Name = "iContainerTypist";
            this.iContainerTypist.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.lblTypist,
            this.cboTypist});
            this.iContainerTypist.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle;
            // 
            // lblTypist
            // 
            this.lblTypist.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTypist.ForeColor = System.Drawing.Color.Green;
            this.lblTypist.Name = "lblTypist";
            this.lblTypist.PaddingLeft = 4;
            this.lblTypist.PaddingRight = 4;
            this.lblTypist.Text = "كاربر ثبت كننده:";
            this.lblTypist.Width = 95;
            // 
            // cboTypist
            // 
            this.cboTypist.Caption = "comboBoxItem1";
            this.cboTypist.ComboWidth = 150;
            this.cboTypist.DropDownHeight = 106;
            this.cboTypist.Name = "cboTypist";
            // 
            // cboDocType
            // 
            this.cboDocType.Caption = "comboBoxItem1";
            this.cboDocType.ComboWidth = 150;
            this.cboDocType.DropDownHeight = 106;
            this.cboDocType.Name = "cboDocType";
            // 
            // buttonItem1
            // 
            this.buttonItem1.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem1.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem1.Image")));
            this.buttonItem1.ImagePaddingHorizontal = 8;
            this.buttonItem1.ImagePaddingVertical = 10;
            this.buttonItem1.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.RibbonWordWrap = false;
            this.buttonItem1.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.buttonItem1.SubItemsExpandWidth = 20;
            this.buttonItem1.Text = "راهنمای\r\nكاربری";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.txtTemplateCode);
            this.panel1.Controls.Add(this.txtDescription);
            this.panel1.Controls.Add(this.lblTemplateCode);
            this.panel1.Controls.Add(this.lblDescription);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 63);
            this.panel1.TabIndex = 14;
            // 
            // txtTemplateCode
            // 
            this.txtTemplateCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtTemplateCode.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtTemplateCode.ButtonClear.Visible = true;
            this.txtTemplateCode.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtTemplateCode.Location = new System.Drawing.Point(5, 7);
            this.txtTemplateCode.MaxValue = 32767;
            this.txtTemplateCode.MinValue = 1;
            this.txtTemplateCode.Name = "txtTemplateCode";
            this.txtTemplateCode.ShowUpDown = true;
            this.txtTemplateCode.Size = new System.Drawing.Size(98, 21);
            this.txtTemplateCode.TabIndex = 9;
            this.txtTemplateCode.Value = 1;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtDescription.Border.Class = "TextBoxBorder";
            this.txtDescription.Location = new System.Drawing.Point(5, 34);
            this.txtDescription.MaxLength = 300;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(336, 21);
            this.txtDescription.TabIndex = 11;
            // 
            // lblTemplateCode
            // 
            this.lblTemplateCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTemplateCode.AutoSize = true;
            this.lblTemplateCode.BackColor = System.Drawing.Color.Transparent;
            this.lblTemplateCode.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTemplateCode.Location = new System.Drawing.Point(109, 9);
            this.lblTemplateCode.Name = "lblTemplateCode";
            this.lblTemplateCode.Size = new System.Drawing.Size(19, 16);
            this.lblTemplateCode.TabIndex = 8;
            this.lblTemplateCode.Text = "كد:";
            this.lblTemplateCode.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescription.AutoSize = true;
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblDescription.Location = new System.Drawing.Point(343, 34);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(53, 16);
            this.lblDescription.TabIndex = 10;
            this.lblDescription.Text = "توضیحات:";
            this.lblDescription.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtName.Border.Class = "TextBoxBorder";
            this.txtName.Location = new System.Drawing.Point(134, 7);
            this.txtName.MaxLength = 100;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(207, 21);
            this.txtName.TabIndex = 6;
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblName.Location = new System.Drawing.Point(347, 7);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(49, 16);
            this.lblName.TabIndex = 7;
            this.lblName.Text = "نام قالب:";
            this.lblName.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // RibbonBarForm
            // 
            this.RibbonBarForm.ColorScheme.BarBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.RibbonBarForm.DockSide = DevComponents.DotNetBar.eDockSide.Document;
            this.RibbonBarForm.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RibbonBarForm.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnClose,
            this.btnSave,
            this.btnPrint,
            this.btnHelp});
            this.RibbonBarForm.ItemSpacing = 1;
            this.RibbonBarForm.Location = new System.Drawing.Point(216, 81);
            this.RibbonBarForm.Name = "RibbonBarForm";
            this.RibbonBarForm.Size = new System.Drawing.Size(196, 80);
            this.RibbonBarForm.Stretch = true;
            this.RibbonBarForm.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.RibbonBarForm.TabIndex = 15;
            this.RibbonBarForm.TabStop = false;
            this.RibbonBarForm.Tag = "0";
            // 
            // btnClose
            // 
            this.btnClose.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnClose.ForeColor = System.Drawing.Color.DarkViolet;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageFixedSize = new System.Drawing.Size(40, 40);
            this.btnClose.ImagePaddingHorizontal = 8;
            this.btnClose.ImagePaddingVertical = 10;
            this.btnClose.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnClose.Name = "btnClose";
            this.btnClose.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.AltF4);
            this.btnClose.SubItemsExpandWidth = 14;
            this.btnClose.Text = "خروج\r\n(Alt+F4)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BeginGroup = true;
            this.btnSave.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnSave.FontBold = true;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageFixedSize = new System.Drawing.Size(40, 40);
            this.btnSave.ImagePaddingHorizontal = 8;
            this.btnSave.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnSave.Name = "btnSave";
            this.btnSave.SubItemsExpandWidth = 14;
            this.btnSave.Text = "ثبت";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnPrint.FontBold = true;
            this.btnPrint.ForeColor = System.Drawing.Color.Blue;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImagePaddingHorizontal = 8;
            this.btnPrint.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Text = "چاپ\r\nمدرك";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.ImagePaddingHorizontal = 8;
            this.btnHelp.ImagePaddingVertical = 10;
            this.btnHelp.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.RibbonWordWrap = false;
            this.btnHelp.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnHelp.SubItemsExpandWidth = 20;
            this.btnHelp.Text = "راهنمای\r\nكاربری";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnImport
            // 
            this.btnImport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnImport.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnImport.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnImport.Image = global::Sepehr.Settings.Documents.Properties.Resources.Browse;
            this.btnImport.Location = new System.Drawing.Point(100, 87);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(77, 74);
            this.btnImport.TabIndex = 17;
            this.btnImport.TabStop = false;
            this.btnImport.Text = "خواندن از فایل";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnAddinFieldsList
            // 
            this.btnAddinFieldsList.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddinFieldsList.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddinFieldsList.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAddinFieldsList.Image = global::Sepehr.Settings.Documents.Properties.Resources.AddinFields;
            this.btnAddinFieldsList.Location = new System.Drawing.Point(12, 87);
            this.btnAddinFieldsList.Name = "btnAddinFieldsList";
            this.btnAddinFieldsList.Size = new System.Drawing.Size(82, 74);
            this.btnAddinFieldsList.TabIndex = 16;
            this.btnAddinFieldsList.TabStop = false;
            this.btnAddinFieldsList.Text = "لیست فیلدهای پویا";
            this.btnAddinFieldsList.Click += new System.EventHandler(this.btnAddinFieldsList_Click);
            // 
            // ribbonClientPanel1
            // 
            this.ribbonClientPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.ribbonClientPanel1.Controls.Add(this.panel1);
            this.ribbonClientPanel1.Controls.Add(this.btnAddinFieldsList);
            this.ribbonClientPanel1.Controls.Add(this.RibbonBarForm);
            this.ribbonClientPanel1.Controls.Add(this.btnImport);
            this.ribbonClientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonClientPanel1.Location = new System.Drawing.Point(0, 0);
            this.ribbonClientPanel1.Name = "ribbonClientPanel1";
            this.ribbonClientPanel1.Size = new System.Drawing.Size(430, 182);
            // 
            // 
            // 
            this.ribbonClientPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.ribbonClientPanel1.Style.BackColorGradientAngle = 90;
            this.ribbonClientPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.ribbonClientPanel1.Style.BackgroundImagePosition = DevComponents.DotNetBar.eStyleBackgroundImage.Tile;
            this.ribbonClientPanel1.Style.BorderBottomWidth = 1;
            this.ribbonClientPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.ribbonClientPanel1.Style.BorderLeftWidth = 1;
            this.ribbonClientPanel1.Style.BorderRightWidth = 1;
            this.ribbonClientPanel1.Style.BorderTopWidth = 1;
            this.ribbonClientPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.ribbonClientPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.ribbonClientPanel1.TabIndex = 19;
            // 
            // frmManageDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(430, 182);
            this.Controls.Add(this.ribbonClientPanel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
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
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTemplateCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonBarForm)).EndInit();
            this.ribbonClientPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private DevComponents.DotNetBar.ItemContainer iContainerSettings;
        private DevComponents.DotNetBar.ItemContainer iContainerDocType;
        private DevComponents.DotNetBar.LabelItem lblDocType;
        private DevComponents.DotNetBar.ItemContainer iContainerRefPhysician;
        private DevComponents.DotNetBar.LabelItem lblRefPhysician;
        private DevComponents.DotNetBar.ComboBoxItem cboDocPhysician;
        private DevComponents.DotNetBar.ItemContainer iContainerTypist;
        private DevComponents.DotNetBar.LabelItem lblTypist;
        private DevComponents.DotNetBar.ComboBoxItem cboTypist;
        private DevComponents.DotNetBar.ComboBoxItem cboDocType;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private System.Windows.Forms.Panel panel1;
        public DevComponents.Editors.IntegerInput txtTemplateCode;
        public DevComponents.DotNetBar.Controls.TextBoxX txtDescription;
        private DevComponents.DotNetBar.LabelX lblTemplateCode;
        private DevComponents.DotNetBar.LabelX lblDescription;
        public DevComponents.DotNetBar.Controls.TextBoxX txtName;
        private DevComponents.DotNetBar.LabelX lblName;
        private DevComponents.DotNetBar.Bar RibbonBarForm;
        private DevComponents.DotNetBar.ButtonItem btnClose;
        private DevComponents.DotNetBar.ButtonItem btnSave;
        private DevComponents.DotNetBar.ButtonItem btnPrint;
        private DevComponents.DotNetBar.ButtonItem btnHelp;
        private DevComponents.DotNetBar.ButtonX btnImport;
        private DevComponents.DotNetBar.ButtonX btnAddinFieldsList;
        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel ribbonClientPanel1;
    }
}