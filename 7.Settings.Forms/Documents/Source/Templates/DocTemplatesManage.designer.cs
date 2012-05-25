namespace Sepehr.Documents
{
    partial class frmDocTemplatesManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDocTemplatesManage));
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
            this.txtTemplateCode = new DevComponents.Editors.IntegerInput();
            this.txtDescription = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblTemplateCode = new DevComponents.DotNetBar.LabelX();
            this.lblDescription = new DevComponents.DotNetBar.LabelX();
            this.txtName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblName = new DevComponents.DotNetBar.LabelX();
            this.btnImport = new DevComponents.DotNetBar.ButtonX();
            this.btnAddinFieldsList = new DevComponents.DotNetBar.ButtonX();
            this.ribbonClientPanel1 = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.btnHelp = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnAccept = new DevComponents.DotNetBar.ButtonX();
            this.cBoxIsDefault = new DevComponents.DotNetBar.Controls.CheckBoxX();
            ((System.ComponentModel.ISupportInitialize)(this.txtTemplateCode)).BeginInit();
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
            // txtTemplateCode
            // 
            // 
            // 
            // 
            this.txtTemplateCode.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtTemplateCode.ButtonClear.Visible = true;
            this.txtTemplateCode.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtTemplateCode.Location = new System.Drawing.Point(12, 12);
            this.txtTemplateCode.MaxValue = 32767;
            this.txtTemplateCode.MinValue = 1;
            this.txtTemplateCode.Name = "txtTemplateCode";
            this.txtTemplateCode.ShowUpDown = true;
            this.txtTemplateCode.Size = new System.Drawing.Size(99, 21);
            this.txtTemplateCode.TabIndex = 3;
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
            this.txtDescription.Location = new System.Drawing.Point(95, 39);
            this.txtDescription.MaxLength = 300;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(355, 21);
            this.txtDescription.TabIndex = 5;
            // 
            // lblTemplateCode
            // 
            this.lblTemplateCode.AutoSize = true;
            this.lblTemplateCode.BackColor = System.Drawing.Color.Transparent;
            this.lblTemplateCode.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTemplateCode.Location = new System.Drawing.Point(117, 14);
            this.lblTemplateCode.Name = "lblTemplateCode";
            this.lblTemplateCode.Size = new System.Drawing.Size(19, 16);
            this.lblTemplateCode.TabIndex = 2;
            this.lblTemplateCode.Text = "كد:";
            this.lblTemplateCode.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescription.AutoSize = true;
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblDescription.Location = new System.Drawing.Point(461, 41);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(53, 16);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "توضیحات:";
            this.lblDescription.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtName.Border.Class = "TextBoxBorder";
            this.txtName.Location = new System.Drawing.Point(142, 12);
            this.txtName.MaxLength = 100;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(308, 21);
            this.txtName.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblName.Location = new System.Drawing.Point(461, 14);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(49, 16);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "نام قالب:";
            this.lblName.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // btnImport
            // 
            this.btnImport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnImport.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnImport.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnImport.Image = global::Sepehr.Settings.Documents.Properties.Resources.Browse;
            this.btnImport.Location = new System.Drawing.Point(214, 70);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(95, 57);
            this.btnImport.TabIndex = 9;
            this.btnImport.TabStop = false;
            this.btnImport.Text = "خواندن از فایل";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnAddinFieldsList
            // 
            this.btnAddinFieldsList.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddinFieldsList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddinFieldsList.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAddinFieldsList.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnAddinFieldsList.Image = global::Sepehr.Settings.Documents.Properties.Resources.AddinFields;
            this.btnAddinFieldsList.Location = new System.Drawing.Point(315, 70);
            this.btnAddinFieldsList.Name = "btnAddinFieldsList";
            this.btnAddinFieldsList.Size = new System.Drawing.Size(95, 57);
            this.btnAddinFieldsList.TabIndex = 10;
            this.btnAddinFieldsList.TabStop = false;
            this.btnAddinFieldsList.Text = "لیست فیلدهای پویا";
            this.btnAddinFieldsList.Click += new System.EventHandler(this.btnAddinFieldsList_Click);
            // 
            // ribbonClientPanel1
            // 
            this.ribbonClientPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.ribbonClientPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.ribbonClientPanel1.Controls.Add(this.cBoxIsDefault);
            this.ribbonClientPanel1.Controls.Add(this.txtTemplateCode);
            this.ribbonClientPanel1.Controls.Add(this.txtDescription);
            this.ribbonClientPanel1.Controls.Add(this.btnHelp);
            this.ribbonClientPanel1.Controls.Add(this.lblTemplateCode);
            this.ribbonClientPanel1.Controls.Add(this.btnCancel);
            this.ribbonClientPanel1.Controls.Add(this.lblDescription);
            this.ribbonClientPanel1.Controls.Add(this.btnAccept);
            this.ribbonClientPanel1.Controls.Add(this.txtName);
            this.ribbonClientPanel1.Controls.Add(this.lblName);
            this.ribbonClientPanel1.Controls.Add(this.btnAddinFieldsList);
            this.ribbonClientPanel1.Controls.Add(this.btnImport);
            this.ribbonClientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonClientPanel1.Location = new System.Drawing.Point(0, 0);
            this.ribbonClientPanel1.Name = "ribbonClientPanel1";
            this.ribbonClientPanel1.Size = new System.Drawing.Size(522, 139);
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
            this.ribbonClientPanel1.TabIndex = 0;
            // 
            // btnHelp
            // 
            this.btnHelp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHelp.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnHelp.Image = global::Sepehr.Settings.Documents.Properties.Resources.Help;
            this.btnHelp.Location = new System.Drawing.Point(416, 70);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F1);
            this.btnHelp.Size = new System.Drawing.Size(95, 57);
            this.btnHelp.TabIndex = 11;
            this.btnHelp.TabStop = false;
            this.btnHelp.Text = "راهنما\r\n(F1)";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Sepehr.Settings.Documents.Properties.Resources.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(113, 70);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 57);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "انصراف\r\n(Esc)";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAccept.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAccept.Image = global::Sepehr.Settings.Documents.Properties.Resources.Accept;
            this.btnAccept.Location = new System.Drawing.Point(12, 70);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnAccept.Size = new System.Drawing.Size(95, 57);
            this.btnAccept.TabIndex = 7;
            this.btnAccept.TabStop = false;
            this.btnAccept.Text = "تایید\r\n(F8)";
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // cBoxIsDefault
            // 
            this.cBoxIsDefault.AutoSize = true;
            this.cBoxIsDefault.BackColor = System.Drawing.Color.Transparent;
            this.cBoxIsDefault.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxIsDefault.Location = new System.Drawing.Point(14, 41);
            this.cBoxIsDefault.Name = "cBoxIsDefault";
            this.cBoxIsDefault.Size = new System.Drawing.Size(77, 16);
            this.cBoxIsDefault.TabIndex = 6;
            this.cBoxIsDefault.Text = "پیش فرض";
            // 
            // frmDocTemplatesManage
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(522, 139);
            this.Controls.Add(this.ribbonClientPanel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmDocTemplatesManage";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تنظیمات - مدارك - مدیریت قالب مدرك مراجعات";
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.txtTemplateCode)).EndInit();
            this.ribbonClientPanel1.ResumeLayout(false);
            this.ribbonClientPanel1.PerformLayout();
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
        internal DevComponents.Editors.IntegerInput txtTemplateCode;
        internal DevComponents.DotNetBar.Controls.TextBoxX txtDescription;
        private DevComponents.DotNetBar.LabelX lblTemplateCode;
        private DevComponents.DotNetBar.LabelX lblDescription;
        internal DevComponents.DotNetBar.Controls.TextBoxX txtName;
        private DevComponents.DotNetBar.LabelX lblName;
        private DevComponents.DotNetBar.ButtonX btnImport;
        private DevComponents.DotNetBar.ButtonX btnAddinFieldsList;
        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel ribbonClientPanel1;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnAccept;
        private DevComponents.DotNetBar.ButtonX btnHelp;
        internal DevComponents.DotNetBar.Controls.CheckBoxX cBoxIsDefault;
    }
}