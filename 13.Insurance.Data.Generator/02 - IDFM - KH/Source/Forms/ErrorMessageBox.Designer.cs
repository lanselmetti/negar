namespace Sepehr.Forms
{
    partial class frmErrorMessageBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmErrorMessageBox));
            this.txtErrorMessage = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.panel = new DevComponents.DotNetBar.PanelEx();
            this.lblErrorCount = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtErrorMessage
            // 
            this.txtErrorMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtErrorMessage.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtErrorMessage.Border.Class = "TextBoxBorder";
            this.txtErrorMessage.Font = new System.Drawing.Font("B Roya", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtErrorMessage.Location = new System.Drawing.Point(12, 57);
            this.txtErrorMessage.Multiline = true;
            this.txtErrorMessage.Name = "txtErrorMessage";
            this.txtErrorMessage.ReadOnly = true;
            this.txtErrorMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtErrorMessage.Size = new System.Drawing.Size(760, 430);
            this.txtErrorMessage.TabIndex = 0;
            // 
            // panel
            // 
            this.panel.CanvasColor = System.Drawing.SystemColors.Control;
            this.panel.Controls.Add(this.lblErrorCount);
            this.panel.Controls.Add(this.lblTitle);
            this.panel.Controls.Add(this.btnCancel);
            this.panel.Controls.Add(this.txtErrorMessage);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(784, 562);
            this.panel.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panel.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.panel.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.panel.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.panel.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.panel.Style.GradientAngle = 90;
            this.panel.TabIndex = 0;
            // 
            // lblErrorCount
            // 
            this.lblErrorCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblErrorCount.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblErrorCount.ForeColor = System.Drawing.Color.Crimson;
            this.lblErrorCount.Location = new System.Drawing.Point(542, 493);
            this.lblErrorCount.Name = "lblErrorCount";
            this.lblErrorCount.Size = new System.Drawing.Size(230, 20);
            this.lblErrorCount.TabIndex = 3;
            this.lblErrorCount.Text = "تعداد مراجعات دارای خطا: ";
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("B Mitra", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTitle.ForeColor = System.Drawing.Color.Teal;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(784, 54);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "خطاهای بررسی شده در اطلاعات مراجعات جستجوی شده:";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnCancel.Image = global::Sepehr.Properties.Resources.Cancel_Logo;
            this.btnCancel.Location = new System.Drawing.Point(12, 493);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 57);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "خروج\r\n(Esc)";
            // 
            // frmErrorMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.panel);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmErrorMessageBox";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فرم نمایش خطاهای موجود در اطلاعات مراجعات جستجو شده";
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX txtErrorMessage;
        private DevComponents.DotNetBar.PanelEx panel;
        private System.Windows.Forms.Label lblTitle;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private System.Windows.Forms.Label lblErrorCount;
    }
}