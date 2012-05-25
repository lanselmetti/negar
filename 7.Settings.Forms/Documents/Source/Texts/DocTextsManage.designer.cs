namespace Sepehr.Documents
{
    partial class frmDocTextsManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDocTextsManage));
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
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
            this.txtTextCode = new DevComponents.Editors.IntegerInput();
            this.txtDescription = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblTextCode = new DevComponents.DotNetBar.LabelX();
            this.lblDescription = new DevComponents.DotNetBar.LabelX();
            this.txtName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblName = new DevComponents.DotNetBar.LabelX();
            this.RCP = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.txtText = new System.Windows.Forms.RichTextBox();
            this.btnHelp = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.lblText = new DevComponents.DotNetBar.LabelX();
            this.btnLeftToRight = new DevComponents.DotNetBar.ButtonX();
            this.btnRightToLeft = new DevComponents.DotNetBar.ButtonX();
            this.btnReplaceSpace = new DevComponents.DotNetBar.ButtonX();
            this.btnAccept = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.txtTextCode)).BeginInit();
            this.RCP.SuspendLayout();
            this.SuspendLayout();
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
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
            // txtTextCode
            // 
            // 
            // 
            // 
            this.txtTextCode.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtTextCode.ButtonClear.Visible = true;
            this.txtTextCode.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtTextCode.Location = new System.Drawing.Point(14, 12);
            this.txtTextCode.MaxValue = 32767;
            this.txtTextCode.MinValue = 1;
            this.txtTextCode.Name = "txtTextCode";
            this.txtTextCode.ShowUpDown = true;
            this.txtTextCode.Size = new System.Drawing.Size(97, 21);
            this.txtTextCode.TabIndex = 3;
            this.txtTextCode.Value = 1;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtDescription.Border.Class = "TextBoxBorder";
            this.txtDescription.Location = new System.Drawing.Point(14, 243);
            this.txtDescription.MaxLength = 300;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(438, 21);
            this.txtDescription.TabIndex = 6;
            // 
            // lblTextCode
            // 
            this.lblTextCode.AutoSize = true;
            this.lblTextCode.BackColor = System.Drawing.Color.Transparent;
            this.lblTextCode.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTextCode.Location = new System.Drawing.Point(117, 14);
            this.lblTextCode.Name = "lblTextCode";
            this.lblTextCode.Size = new System.Drawing.Size(19, 16);
            this.lblTextCode.TabIndex = 2;
            this.lblTextCode.Text = "كد:";
            this.lblTextCode.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescription.AutoSize = true;
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblDescription.Location = new System.Drawing.Point(459, 248);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(53, 16);
            this.lblDescription.TabIndex = 10;
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
            this.txtName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
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
            this.lblName.Location = new System.Drawing.Point(459, 14);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(49, 16);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "نام قالب:";
            this.lblName.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // RCP
            // 
            this.RCP.CanvasColor = System.Drawing.SystemColors.Control;
            this.RCP.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.RCP.Controls.Add(this.txtTextCode);
            this.RCP.Controls.Add(this.txtText);
            this.RCP.Controls.Add(this.txtDescription);
            this.RCP.Controls.Add(this.btnHelp);
            this.RCP.Controls.Add(this.lblTextCode);
            this.RCP.Controls.Add(this.btnCancel);
            this.RCP.Controls.Add(this.lblText);
            this.RCP.Controls.Add(this.lblDescription);
            this.RCP.Controls.Add(this.btnLeftToRight);
            this.RCP.Controls.Add(this.btnRightToLeft);
            this.RCP.Controls.Add(this.btnReplaceSpace);
            this.RCP.Controls.Add(this.btnAccept);
            this.RCP.Controls.Add(this.txtName);
            this.RCP.Controls.Add(this.lblName);
            this.RCP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RCP.Location = new System.Drawing.Point(0, 0);
            this.RCP.Name = "RCP";
            this.RCP.Size = new System.Drawing.Size(522, 342);
            // 
            // 
            // 
            this.RCP.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.RCP.Style.BackColorGradientAngle = 90;
            this.RCP.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.RCP.Style.BackgroundImagePosition = DevComponents.DotNetBar.eStyleBackgroundImage.Tile;
            this.RCP.Style.BorderBottomWidth = 1;
            this.RCP.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.RCP.Style.BorderLeftWidth = 1;
            this.RCP.Style.BorderRightWidth = 1;
            this.RCP.Style.BorderTopWidth = 1;
            this.RCP.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.RCP.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.RCP.TabIndex = 0;
            // 
            // txtText
            // 
            this.txtText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtText.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtText.Location = new System.Drawing.Point(14, 40);
            this.txtText.MaxLength = 2000;
            this.txtText.Name = "txtText";
            this.txtText.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtText.Size = new System.Drawing.Size(438, 197);
            this.txtText.TabIndex = 5;
            this.txtText.Text = "";
            // 
            // btnHelp
            // 
            this.btnHelp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHelp.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnHelp.Image = global::Sepehr.Settings.Documents.Properties.Resources.Help;
            this.btnHelp.Location = new System.Drawing.Point(416, 273);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F1);
            this.btnHelp.Size = new System.Drawing.Size(95, 57);
            this.btnHelp.TabIndex = 9;
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
            this.btnCancel.Location = new System.Drawing.Point(115, 273);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 57);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "انصراف\r\n(Esc)";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblText
            // 
            this.lblText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblText.AutoSize = true;
            this.lblText.BackColor = System.Drawing.Color.Transparent;
            this.lblText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblText.Location = new System.Drawing.Point(459, 40);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(27, 16);
            this.lblText.TabIndex = 4;
            this.lblText.Text = "متن:";
            this.lblText.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // btnLeftToRight
            // 
            this.btnLeftToRight.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLeftToRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLeftToRight.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnLeftToRight.Image = global::Sepehr.Settings.Documents.Properties.Resources.RightSmall2;
            this.btnLeftToRight.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.btnLeftToRight.Location = new System.Drawing.Point(216, 305);
            this.btnLeftToRight.Name = "btnLeftToRight";
            this.btnLeftToRight.Size = new System.Drawing.Size(95, 25);
            this.btnLeftToRight.TabIndex = 7;
            this.btnLeftToRight.TabStop = false;
            this.btnLeftToRight.Text = "چپ به راست";
            this.btnLeftToRight.Click += new System.EventHandler(this.btnLeftToRight_Click);
            // 
            // btnRightToLeft
            // 
            this.btnRightToLeft.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRightToLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRightToLeft.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnRightToLeft.Image = global::Sepehr.Settings.Documents.Properties.Resources.LeftSmall2;
            this.btnRightToLeft.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.btnRightToLeft.Location = new System.Drawing.Point(216, 273);
            this.btnRightToLeft.Name = "btnRightToLeft";
            this.btnRightToLeft.Size = new System.Drawing.Size(95, 25);
            this.btnRightToLeft.TabIndex = 7;
            this.btnRightToLeft.TabStop = false;
            this.btnRightToLeft.Text = "راست به چپ";
            this.btnRightToLeft.Click += new System.EventHandler(this.btnRightToLeft_Click);
            // 
            // btnReplaceSpace
            // 
            this.btnReplaceSpace.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnReplaceSpace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReplaceSpace.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnReplaceSpace.Image = global::Sepehr.Settings.Documents.Properties.Resources.Search;
            this.btnReplaceSpace.Location = new System.Drawing.Point(315, 273);
            this.btnReplaceSpace.Name = "btnReplaceSpace";
            this.btnReplaceSpace.Size = new System.Drawing.Size(95, 57);
            this.btnReplaceSpace.TabIndex = 7;
            this.btnReplaceSpace.TabStop = false;
            this.btnReplaceSpace.Text = "جایگزینی فاصله ها";
            this.btnReplaceSpace.Click += new System.EventHandler(this.btnReplaceSpace_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAccept.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAccept.Image = global::Sepehr.Settings.Documents.Properties.Resources.Accept;
            this.btnAccept.Location = new System.Drawing.Point(14, 273);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnAccept.Size = new System.Drawing.Size(95, 57);
            this.btnAccept.TabIndex = 7;
            this.btnAccept.TabStop = false;
            this.btnAccept.Text = "تایید\r\n(F8)";
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // frmDocTextsManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(522, 342);
            this.Controls.Add(this.RCP);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDocTextsManage";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تنظیمات - مدارك - مدیریت متن مدرك مراجعات";
            this.Shown += new System.EventHandler(this.Form_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.txtTextCode)).EndInit();
            this.RCP.ResumeLayout(false);
            this.RCP.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
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
        private DevComponents.DotNetBar.LabelX lblTextCode;
        private DevComponents.DotNetBar.LabelX lblDescription;
        private DevComponents.DotNetBar.LabelX lblName;
        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel RCP;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnAccept;
        private DevComponents.DotNetBar.ButtonX btnHelp;
        private DevComponents.DotNetBar.LabelX lblText;
        internal DevComponents.Editors.IntegerInput txtTextCode;
        internal DevComponents.DotNetBar.Controls.TextBoxX txtDescription;
        internal DevComponents.DotNetBar.Controls.TextBoxX txtName;
        internal System.Windows.Forms.RichTextBox txtText;
        private DevComponents.DotNetBar.ButtonX btnReplaceSpace;
        private DevComponents.DotNetBar.ButtonX btnRightToLeft;
        private DevComponents.DotNetBar.ButtonX btnLeftToRight;
    }
}