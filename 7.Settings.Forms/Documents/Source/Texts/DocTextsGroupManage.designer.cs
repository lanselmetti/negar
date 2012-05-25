namespace Sepehr.Settings.Documents
{
    partial class frmDocTextsGroupManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDocTextsGroupManage));
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.FormPanel = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.lblTitle = new DevComponents.DotNetBar.LabelX();
            this.txtDescription = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblDescription = new DevComponents.DotNetBar.LabelX();
            this.txtName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblName = new DevComponents.DotNetBar.LabelX();
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.FormPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Image = global::Sepehr.Settings.Documents.Properties.Resources.Accept;
            this.btnSave.Location = new System.Drawing.Point(12, 143);
            this.btnSave.Name = "btnSave";
            this.btnSave.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnSave.Size = new System.Drawing.Size(95, 57);
            this.btnSave.TabIndex = 4;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "تایید (F8)";
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = global::Sepehr.Settings.Documents.Properties.Resources.Cancel;
            this.btnClose.Location = new System.Drawing.Point(113, 143);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 57);
            this.btnClose.TabIndex = 5;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "انصراف\r\n(Esc)";
            // 
            // FormPanel
            // 
            this.FormPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.FormPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.FormPanel.Controls.Add(this.lblTitle);
            this.FormPanel.Controls.Add(this.txtDescription);
            this.FormPanel.Controls.Add(this.lblDescription);
            this.FormPanel.Controls.Add(this.txtName);
            this.FormPanel.Controls.Add(this.lblName);
            this.FormPanel.Controls.Add(this.btnClose);
            this.FormPanel.Controls.Add(this.btnSave);
            this.FormPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormPanel.Location = new System.Drawing.Point(0, 0);
            this.FormPanel.Name = "FormPanel";
            this.FormPanel.Size = new System.Drawing.Size(321, 212);
            // 
            // 
            // 
            this.FormPanel.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.FormPanel.Style.BackColorGradientAngle = 90;
            this.FormPanel.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.FormPanel.Style.BorderBottomWidth = 1;
            this.FormPanel.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.FormPanel.Style.BorderLeftWidth = 1;
            this.FormPanel.Style.BorderRightWidth = 1;
            this.FormPanel.Style.BorderTopWidth = 1;
            this.FormPanel.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.FormPanel.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.FormPanel.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("B Yekan", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(321, 39);
            this.lblTitle.TabIndex = 7;
            this.lblTitle.Text = "مدیریت گروه های متن مدارك";
            this.lblTitle.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtDescription.Border.Class = "TextBoxBorder";
            this.txtDescription.Location = new System.Drawing.Point(12, 72);
            this.txtDescription.MaxLength = 300;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(247, 62);
            this.txtDescription.TabIndex = 2;
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescription.AutoSize = true;
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblDescription.Location = new System.Drawing.Point(264, 74);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(53, 16);
            this.lblDescription.TabIndex = 3;
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
            this.txtName.Location = new System.Drawing.Point(12, 45);
            this.txtName.MaxLength = 100;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(247, 21);
            this.txtName.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblName.Location = new System.Drawing.Point(264, 47);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(48, 16);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "نام گروه:";
            this.lblName.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            // 
            // frmDocTextsGroupManage
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(321, 212);
            this.Controls.Add(this.FormPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDocTextsGroupManage";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تنظیمات مدارك - مدیریت گروه های متن مدارك";
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.FormPanel.ResumeLayout(false);
            this.FormPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel FormPanel;
        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        private DevComponents.DotNetBar.LabelX lblName;
        private DevComponents.DotNetBar.LabelX lblDescription;
        private DevComponents.DotNetBar.LabelX lblTitle;
        internal DevComponents.DotNetBar.Controls.TextBoxX txtName;
        internal DevComponents.DotNetBar.Controls.TextBoxX txtDescription;




    }
}