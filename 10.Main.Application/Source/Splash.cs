#region using
using System;
using System.Windows.Forms;
#endregion

namespace Sepehr
{
    /// <summary>
    /// فرم اسپلش سیستم
    /// </summary>
    internal class frmSplash : Form
    {

        #region Designer

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSplash));
            this.PanelMain = new DevComponents.DotNetBar.PanelEx();
            this.PictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.PanelTitle = new DevComponents.DotNetBar.PanelEx();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.reflectionImage1 = new DevComponents.DotNetBar.Controls.ReflectionImage();
            this.lblTitle = new System.Windows.Forms.Label();
            this.PanelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxLogo)).BeginInit();
            this.PanelTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelMain
            // 
            this.PanelMain.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelMain.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelMain.Controls.Add(this.PictureBoxLogo);
            this.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelMain.Location = new System.Drawing.Point(0, 80);
            this.PanelMain.Name = "PanelMain";
            this.PanelMain.Size = new System.Drawing.Size(405, 220);
            this.PanelMain.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.PanelMain.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.PanelMain.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.PanelMain.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.PanelMain.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.PanelMain.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.PanelMain.Style.GradientAngle = 90;
            this.PanelMain.TabIndex = 0;
            // 
            // PictureBoxLogo
            // 
            this.PictureBoxLogo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.PictureBoxLogo.BackColor = System.Drawing.Color.Transparent;
            this.PictureBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PictureBoxLogo.Image = global::Sepehr.Properties.Resources.SepehrLogo;
            this.PictureBoxLogo.Location = new System.Drawing.Point(75, -2);
            this.PictureBoxLogo.Name = "PictureBoxLogo";
            this.PictureBoxLogo.Size = new System.Drawing.Size(254, 222);
            this.PictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBoxLogo.TabIndex = 18;
            this.PictureBoxLogo.TabStop = false;
            // 
            // PanelTitle
            // 
            this.PanelTitle.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelTitle.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelTitle.Controls.Add(this.label3);
            this.PanelTitle.Controls.Add(this.lblSubtitle);
            this.PanelTitle.Controls.Add(this.reflectionImage1);
            this.PanelTitle.Controls.Add(this.lblTitle);
            this.PanelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelTitle.Location = new System.Drawing.Point(0, 0);
            this.PanelTitle.Name = "PanelTitle";
            this.PanelTitle.Size = new System.Drawing.Size(405, 80);
            this.PanelTitle.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.PanelTitle.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.PanelTitle.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.PanelTitle.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.PanelTitle.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.PanelTitle.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.PanelTitle.Style.GradientAngle = 90;
            this.PanelTitle.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("B Yekan", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label3.Location = new System.Drawing.Point(-2, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 48);
            this.label3.TabIndex = 22;
            this.label3.Text = "رایان پرتونگار";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtitle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitle.ForeColor = System.Drawing.Color.Blue;
            this.lblSubtitle.Location = new System.Drawing.Point(6, 48);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(173, 14);
            this.lblSubtitle.TabIndex = 0;
            this.lblSubtitle.Text = "سیستم مدیریت تصویربرداری";
            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // reflectionImage1
            // 
            // 
            // 
            // 
            this.reflectionImage1.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.reflectionImage1.Image = global::Sepehr.Properties.Resources.SepehrIcon;
            this.reflectionImage1.Location = new System.Drawing.Point(366, 3);
            this.reflectionImage1.Name = "reflectionImage1";
            this.reflectionImage1.Size = new System.Drawing.Size(41, 59);
            this.reflectionImage1.TabIndex = 20;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("B Mitra", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTitle.ForeColor = System.Drawing.Color.Crimson;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(405, 80);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "  سپهر 3";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 300);
            this.ControlBox = false;
            this.Controls.Add(this.PanelMain);
            this.Controls.Add(this.PanelTitle);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSplash";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "سیستم مدیریت تصویربرداری سپهر";
            this.Shown += new System.EventHandler(this.frmSplash_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.PanelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxLogo)).EndInit();
            this.PanelTitle.ResumeLayout(false);
            this.PanelTitle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx PanelMain;
        private DevComponents.DotNetBar.PanelEx PanelTitle;
        private Label lblSubtitle;
        private Label lblTitle;
        private PictureBox PictureBoxLogo;
        private DevComponents.DotNetBar.Controls.ReflectionImage reflectionImage1;
        #endregion

        private Label label3;

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض كلاس
        /// </summary>
        public frmSplash()
        {
            InitializeComponent();
        }
        #endregion

        #region Event Handlers

        #region Form Shown
        private void frmSplash_Shown(object sender, EventArgs e)
        {
            BringToFront();
            Focus();
        }
        #endregion

        #region Form Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            Dispose();
        }
        #endregion

        #endregion

    }
}