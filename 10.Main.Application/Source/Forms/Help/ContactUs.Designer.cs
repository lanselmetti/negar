using Sepehr.Forms.Help;

namespace Sepehr.Forms.Help
{
    partial class frmContactUs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmContactUs));
            this.lblCopyright = new System.Windows.Forms.Label();
            this.PanelMain = new DevComponents.DotNetBar.PanelEx();
            this.PictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.lblDbVersion = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.PanelTitle = new DevComponents.DotNetBar.PanelEx();
            this.lblTitle = new System.Windows.Forms.Label();
            this.PanelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxLogo)).BeginInit();
            this.PanelTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCopyright
            // 
            this.lblCopyright.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCopyright.BackColor = System.Drawing.Color.Transparent;
            this.lblCopyright.Font = new System.Drawing.Font("B Yekan", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblCopyright.ForeColor = System.Drawing.Color.Black;
            this.lblCopyright.Location = new System.Drawing.Point(4, 140);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(426, 75);
            this.lblCopyright.TabIndex = 13;
            this.lblCopyright.Text = "دفتر مركزی ایران:\r\nتهران - خیابان انقلاب - قبل از ضلغ غربی چهارراه ولیعصر\r\nخ.براد" +
                "ران مظفر جنوبی - پ.55 (ساختمان 18) - بلوك A - واحد 2";
            this.lblCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCopyright.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBoxLogo_MouseClick);
            // 
            // PanelMain
            // 
            this.PanelMain.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelMain.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelMain.Controls.Add(this.lblCopyright);
            this.PanelMain.Controls.Add(this.PictureBoxLogo);
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
            // PictureBoxLogo
            // 
            this.PictureBoxLogo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.PictureBoxLogo.BackColor = System.Drawing.Color.Transparent;
            this.PictureBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PictureBoxLogo.Image = global::Sepehr.Properties.Resources.RPNLogo;
            this.PictureBoxLogo.Location = new System.Drawing.Point(33, -57);
            this.PictureBoxLogo.Name = "PictureBoxLogo";
            this.PictureBoxLogo.Size = new System.Drawing.Size(369, 264);
            this.PictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBoxLogo.TabIndex = 19;
            this.PictureBoxLogo.TabStop = false;
            this.PictureBoxLogo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBoxLogo_MouseClick);
            // 
            // lblDbVersion
            // 
            this.lblDbVersion.AutoSize = true;
            this.lblDbVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblDbVersion.Font = new System.Drawing.Font("B Koodak", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblDbVersion.ForeColor = System.Drawing.Color.White;
            this.lblDbVersion.Location = new System.Drawing.Point(3, 6);
            this.lblDbVersion.Name = "lblDbVersion";
            this.lblDbVersion.Size = new System.Drawing.Size(84, 56);
            this.lblDbVersion.TabIndex = 13;
            this.lblDbVersion.Text = "فكس:\r\n66492433";
            this.lblDbVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDbVersion.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBoxLogo_MouseClick);
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVersion.AutoSize = true;
            this.lblVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblVersion.Font = new System.Drawing.Font("B Koodak", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblVersion.ForeColor = System.Drawing.Color.White;
            this.lblVersion.Location = new System.Drawing.Point(351, 6);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(84, 56);
            this.lblVersion.TabIndex = 13;
            this.lblVersion.Text = "تلفن:\r\n66492350";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblVersion.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBoxLogo_MouseClick);
            // 
            // PanelTitle
            // 
            this.PanelTitle.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelTitle.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.PanelTitle.Controls.Add(this.lblDbVersion);
            this.PanelTitle.Controls.Add(this.lblVersion);
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
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("B Yekan", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTitle.ForeColor = System.Drawing.Color.PaleGreen;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(434, 69);
            this.lblTitle.TabIndex = 16;
            this.lblTitle.Text = "تماس با ما";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBoxLogo_MouseClick);
            // 
            // frmContactUs
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
            this.Name = "frmContactUs";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "سیستم مدیریت تصویربرداری سپهر";
            this.PanelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxLogo)).EndInit();
            this.PanelTitle.ResumeLayout(false);
            this.PanelTitle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCopyright;
        private DevComponents.DotNetBar.PanelEx PanelMain;
        private DevComponents.DotNetBar.PanelEx PanelTitle;
        private System.Windows.Forms.PictureBox PictureBoxLogo;
        private System.Windows.Forms.Label lblDbVersion;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblTitle;
    }
}