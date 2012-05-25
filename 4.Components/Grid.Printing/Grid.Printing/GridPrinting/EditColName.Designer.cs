namespace Negar.GridPrinting
{
    partial class frmEditColName
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditColName));
            this.FormPanel = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnAccept = new DevComponents.DotNetBar.ButtonX();
            this.txtName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblName = new DevComponents.DotNetBar.LabelX();
            this.lblTitle = new DevComponents.DotNetBar.LabelX();
            this.FormPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // FormPanel
            // 
            this.FormPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.FormPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.FormPanel.Controls.Add(this.lblTitle);
            this.FormPanel.Controls.Add(this.txtName);
            this.FormPanel.Controls.Add(this.lblName);
            this.FormPanel.Controls.Add(this.btnCancel);
            this.FormPanel.Controls.Add(this.btnAccept);
            this.FormPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormPanel.Location = new System.Drawing.Point(0, 0);
            this.FormPanel.Name = "FormPanel";
            this.FormPanel.Size = new System.Drawing.Size(314, 174);
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
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Negar.Properties.Resources.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(113, 105);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 57);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "انصراف\r\n(Esc)";
            // 
            // btnAccept
            // 
            this.btnAccept.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAccept.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAccept.Image = global::Negar.Properties.Resources.Accept;
            this.btnAccept.Location = new System.Drawing.Point(12, 105);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnAccept.Size = new System.Drawing.Size(95, 57);
            this.btnAccept.TabIndex = 1;
            this.btnAccept.TabStop = false;
            this.btnAccept.Text = "تایید\r\n(F8)";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtName.Border.Class = "TextBoxBorder";
            this.txtName.Location = new System.Drawing.Point(12, 71);
            this.txtName.MaxLength = 50;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(290, 21);
            this.txtName.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblName.Location = new System.Drawing.Point(203, 49);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(99, 16);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "عنوان جدید ستون:";
            this.lblName.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("B Yekan", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(314, 45);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "ویرایش عنوان ستون گزارش";
            this.lblTitle.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // frmEditColName
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(314, 174);
            this.Controls.Add(this.FormPanel);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditColName";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "گزارش ها - ویرایش عنوان ستون گزارش";
            this.FormPanel.ResumeLayout(false);
            this.FormPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel FormPanel;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnAccept;
        private DevComponents.DotNetBar.LabelX lblName;
        private DevComponents.DotNetBar.LabelX lblTitle;
        internal DevComponents.DotNetBar.Controls.TextBoxX txtName;
    }
}