namespace Sepehr.Forms.Help
{
    partial class frmAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
            this.lblCopyright = new System.Windows.Forms.Label();
            this.PanelMain = new DevComponents.DotNetBar.PanelEx();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.lblIMSDbVersion = new System.Windows.Forms.Label();
            this.lblPMSDbVersion = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.PanelTitle = new DevComponents.DotNetBar.PanelEx();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.ClosingTimer = new System.Windows.Forms.Timer(this.components);
            this.PanelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxLogo)).BeginInit();
            this.PanelTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCopyright
            // 
            this.lblCopyright.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.BackColor = System.Drawing.Color.Transparent;
            this.lblCopyright.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopyright.ForeColor = System.Drawing.Color.Black;
            this.lblCopyright.Location = new System.Drawing.Point(49, 192);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(306, 13);
            this.lblCopyright.TabIndex = 13;
            this.lblCopyright.Text = "كلیه حقوق © برای شركت رایان پرتونگار محفوظ می باشد.";
            this.lblCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCopyright.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBoxLogo_MouseClick);
            // 
            // PanelMain
            // 
            this.PanelMain.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelMain.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelMain.Controls.Add(this.pictureBox1);
            this.PanelMain.Controls.Add(this.PictureBoxLogo);
            this.PanelMain.Controls.Add(this.lblIMSDbVersion);
            this.PanelMain.Controls.Add(this.lblPMSDbVersion);
            this.PanelMain.Controls.Add(this.lblVersion);
            this.PanelMain.Controls.Add(this.lblCopyright);
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
            this.PanelMain.TabIndex = 14;
            this.PanelMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBoxLogo_MouseClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = global::Sepehr.Properties.Resources.SepehrLogo;
            this.pictureBox1.Location = new System.Drawing.Point(12, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(191, 181);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBoxLogo_MouseClick);
            // 
            // PictureBoxLogo
            // 
            this.PictureBoxLogo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.PictureBoxLogo.BackColor = System.Drawing.Color.Transparent;
            this.PictureBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PictureBoxLogo.Image = global::Sepehr.Properties.Resources.RPNLogo;
            this.PictureBoxLogo.Location = new System.Drawing.Point(205, 6);
            this.PictureBoxLogo.Name = "PictureBoxLogo";
            this.PictureBoxLogo.Size = new System.Drawing.Size(229, 100);
            this.PictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBoxLogo.TabIndex = 19;
            this.PictureBoxLogo.TabStop = false;
            this.PictureBoxLogo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBoxLogo_MouseClick);
            // 
            // lblIMSDbVersion
            // 
            this.lblIMSDbVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIMSDbVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblIMSDbVersion.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIMSDbVersion.ForeColor = System.Drawing.Color.Brown;
            this.lblIMSDbVersion.Location = new System.Drawing.Point(203, 165);
            this.lblIMSDbVersion.Name = "lblIMSDbVersion";
            this.lblIMSDbVersion.Size = new System.Drawing.Size(228, 19);
            this.lblIMSDbVersion.TabIndex = 13;
            this.lblIMSDbVersion.Text = "نسخه بانك تصویربرداری:";
            this.lblIMSDbVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblIMSDbVersion.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBoxLogo_MouseClick);
            // 
            // lblPMSDbVersion
            // 
            this.lblPMSDbVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPMSDbVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblPMSDbVersion.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPMSDbVersion.ForeColor = System.Drawing.Color.Brown;
            this.lblPMSDbVersion.Location = new System.Drawing.Point(203, 138);
            this.lblPMSDbVersion.Name = "lblPMSDbVersion";
            this.lblPMSDbVersion.Size = new System.Drawing.Size(228, 19);
            this.lblPMSDbVersion.TabIndex = 13;
            this.lblPMSDbVersion.Text = "نسخه بانك بیمارستانی:";
            this.lblPMSDbVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPMSDbVersion.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBoxLogo_MouseClick);
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblVersion.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.Color.Brown;
            this.lblVersion.Location = new System.Drawing.Point(203, 111);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(228, 19);
            this.lblVersion.TabIndex = 13;
            this.lblVersion.Text = "نسخه برنامه:";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblVersion.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBoxLogo_MouseClick);
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
            this.PanelTitle.TabIndex = 17;
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
            this.lblSubtitle.Location = new System.Drawing.Point(138, 47);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(159, 13);
            this.lblSubtitle.TabIndex = 17;
            this.lblSubtitle.Text = "سیستم مدیریت تصویربرداری";
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
            this.lblTitle.TabIndex = 16;
            this.lblTitle.Text = "سپهر";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBoxLogo_MouseClick);
            // 
            // ClosingTimer
            // 
            this.ClosingTimer.Enabled = true;
            this.ClosingTimer.Interval = 10000;
            this.ClosingTimer.Tick += new System.EventHandler(this.ClosingTimer_Tick);
            // 
            // frmAbout
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
            this.Name = "frmAbout";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "سیستم مدیریت تصویربرداری سپهر";
            this.PanelMain.ResumeLayout(false);
            this.PanelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxLogo)).EndInit();
            this.PanelTitle.ResumeLayout(false);
            this.PanelTitle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCopyright;
        private DevComponents.DotNetBar.PanelEx PanelMain;
        private DevComponents.DotNetBar.PanelEx PanelTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Timer ClosingTimer;
        private System.Windows.Forms.PictureBox PictureBoxLogo;
        private System.Windows.Forms.Label lblPMSDbVersion;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblIMSDbVersion;
    }
}