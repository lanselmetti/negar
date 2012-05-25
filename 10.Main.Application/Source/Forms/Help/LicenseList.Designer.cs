namespace Sepehr.Forms.Help
{
    partial class frmLicenseList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLicenseList));
            this.PanelMain = new DevComponents.DotNetBar.PanelEx();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.txtLockVersion = new System.Windows.Forms.Label();
            this.txtSerial = new System.Windows.Forms.Label();
            this.lblLockVersion = new System.Windows.Forms.Label();
            this.lblSerial = new System.Windows.Forms.Label();
            this.lstLicenseList = new System.Windows.Forms.CheckedListBox();
            this.PanelTitle = new DevComponents.DotNetBar.PanelEx();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.PanelMain.SuspendLayout();
            this.PanelTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelMain
            // 
            this.PanelMain.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelMain.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelMain.Controls.Add(this.btnClose);
            this.PanelMain.Controls.Add(this.txtLockVersion);
            this.PanelMain.Controls.Add(this.txtSerial);
            this.PanelMain.Controls.Add(this.lblLockVersion);
            this.PanelMain.Controls.Add(this.lblSerial);
            this.PanelMain.Controls.Add(this.lstLicenseList);
            this.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelMain.Location = new System.Drawing.Point(0, 69);
            this.PanelMain.Name = "PanelMain";
            this.PanelMain.Size = new System.Drawing.Size(434, 219);
            this.PanelMain.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.PanelMain.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.PanelMain.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.PanelMain.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.PanelMain.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.PanelMain.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.PanelMain.Style.GradientAngle = 90;
            this.PanelMain.TabIndex = 0;
            this.PanelMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBoxLogo_MouseClick);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.Image = global::Sepehr.Properties.Resources.Cancel;
            this.btnClose.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnClose.Location = new System.Drawing.Point(12, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 40);
            this.btnClose.TabIndex = 5;
            // 
            // txtLockVersion
            // 
            this.txtLockVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLockVersion.BackColor = System.Drawing.Color.Transparent;
            this.txtLockVersion.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLockVersion.ForeColor = System.Drawing.Color.Brown;
            this.txtLockVersion.Location = new System.Drawing.Point(213, 31);
            this.txtLockVersion.Name = "txtLockVersion";
            this.txtLockVersion.Size = new System.Drawing.Size(108, 14);
            this.txtLockVersion.TabIndex = 4;
            this.txtLockVersion.Text = "0";
            this.txtLockVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtLockVersion.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBoxLogo_MouseClick);
            // 
            // txtSerial
            // 
            this.txtSerial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSerial.BackColor = System.Drawing.Color.Transparent;
            this.txtSerial.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerial.ForeColor = System.Drawing.Color.Brown;
            this.txtSerial.Location = new System.Drawing.Point(213, 9);
            this.txtSerial.Name = "txtSerial";
            this.txtSerial.Size = new System.Drawing.Size(108, 14);
            this.txtSerial.TabIndex = 2;
            this.txtSerial.Text = "0";
            this.txtSerial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtSerial.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBoxLogo_MouseClick);
            // 
            // lblLockVersion
            // 
            this.lblLockVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLockVersion.AutoSize = true;
            this.lblLockVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblLockVersion.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLockVersion.ForeColor = System.Drawing.Color.Brown;
            this.lblLockVersion.Location = new System.Drawing.Point(320, 31);
            this.lblLockVersion.Name = "lblLockVersion";
            this.lblLockVersion.Size = new System.Drawing.Size(74, 14);
            this.lblLockVersion.TabIndex = 3;
            this.lblLockVersion.Text = "نسخه قفل:";
            this.lblLockVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLockVersion.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBoxLogo_MouseClick);
            // 
            // lblSerial
            // 
            this.lblSerial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSerial.AutoSize = true;
            this.lblSerial.BackColor = System.Drawing.Color.Transparent;
            this.lblSerial.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerial.ForeColor = System.Drawing.Color.Brown;
            this.lblSerial.Location = new System.Drawing.Point(320, 9);
            this.lblSerial.Name = "lblSerial";
            this.lblSerial.Size = new System.Drawing.Size(110, 14);
            this.lblSerial.TabIndex = 1;
            this.lblSerial.Text = "سریال قفل جاری:";
            this.lblSerial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSerial.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBoxLogo_MouseClick);
            // 
            // lstLicenseList
            // 
            this.lstLicenseList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstLicenseList.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lstLicenseList.FormattingEnabled = true;
            this.lstLicenseList.IntegralHeight = false;
            this.lstLicenseList.Items.AddRange(new object[] {
            "110 - مجوز مدیریت امنیت سیستم های كلینیكی.",
            "120 - مجوز مدیریت بانك اطلاعاتی سیستم های كلینیكی.",
            "515 - مجوز مدیریت نوبت دهی پیشرفته.",
            "516 - مجوز تنظیمات نوبت دهی پیشرفته.",
            "525 - مجوز مدیریت بیماران پیشرفته.",
            "526 - مجوز تنظیمات بیماران پیشرفته.",
            "530 - مجوز مدیریت حساب.",
            "531 - مجوز تنظیمات حساب.",
            "540 - مجوز مدیریت صندوق.",
            "541 - مجوز تنظیمات صندوق.",
            "550 - مجوز مدیریت مدارك.",
            "551 - مجوز تنظیمات مدارك.",
            "555 - مجوز كپچر تصاویر پزشكی",
            "560 - مجوز گزارش گیری.",
            "561 - مجوز مدیریت قالب های قبوض.",
            "580 - مجوز تنظیمات ارتباط با پكس.",
            "590 - مجوز برنامه دیسكت تصویربرداری \"تامین اجتماعی\".",
            "591 - مجوز برنامه دیسكت تصویربرداری \"خدمات درمانی\".",
            "592 - مجوز برنامه دیسكت تصویربرداری \"ارتش\".",
            "593 - مجوز برنامه دیسكت تصویربرداری \"صدا و سیما\".",
            "594 - مجوز برنامه دیسكت تصویربرداری \"كمیته امداد\".",
            "610 - مجوز سیستم مدیریت باركد - خواندن باركد",
            "611 - مجوز سیستم مدیریت باركد - چاپ باركد"});
            this.lstLicenseList.Location = new System.Drawing.Point(12, 52);
            this.lstLicenseList.Name = "lstLicenseList";
            this.lstLicenseList.Size = new System.Drawing.Size(410, 155);
            this.lstLicenseList.TabIndex = 0;
            // 
            // PanelTitle
            // 
            this.PanelTitle.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelTitle.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.PanelTitle.Controls.Add(this.lblSubtitle);
            this.PanelTitle.Controls.Add(this.lblTitle);
            this.PanelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelTitle.Location = new System.Drawing.Point(0, 0);
            this.PanelTitle.Name = "PanelTitle";
            this.PanelTitle.Size = new System.Drawing.Size(434, 69);
            this.PanelTitle.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.PanelTitle.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.PanelTitle.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.PanelTitle.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.PanelTitle.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.PanelTitle.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.PanelTitle.Style.GradientAngle = 90;
            this.PanelTitle.TabIndex = 1;
            this.PanelTitle.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBoxLogo_MouseClick);
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtitle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitle.ForeColor = System.Drawing.Color.White;
            this.lblSubtitle.Location = new System.Drawing.Point(36, 47);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(363, 13);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "اطلاعاتی قفل سخت افزاری و مجوزهای نصب شده بر روی قفل جاری";
            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSubtitle.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBoxLogo_MouseClick);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("B Yekan", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTitle.ForeColor = System.Drawing.Color.PaleGreen;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(434, 47);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "مجوز استفاده";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBoxLogo_MouseClick);
            // 
            // frmLicenseList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 288);
            this.ControlBox = false;
            this.Controls.Add(this.PanelMain);
            this.Controls.Add(this.PanelTitle);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLicenseList";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "سیستم مدیریت تصویربرداری سپهر";
            this.PanelMain.ResumeLayout(false);
            this.PanelMain.PerformLayout();
            this.PanelTitle.ResumeLayout(false);
            this.PanelTitle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx PanelMain;
        private DevComponents.DotNetBar.PanelEx PanelTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.CheckedListBox lstLicenseList;
        private System.Windows.Forms.Label lblSerial;
        private System.Windows.Forms.Label txtSerial;
        private System.Windows.Forms.Label txtLockVersion;
        private System.Windows.Forms.Label lblLockVersion;
        private DevComponents.DotNetBar.ButtonX btnClose;
    }
}