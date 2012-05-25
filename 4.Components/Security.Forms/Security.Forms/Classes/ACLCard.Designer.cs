namespace Negar.Security.Classes
{
    partial class ACLCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.LinkLabel();
            this.FormPanel = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.PictureBoxStatus = new System.Windows.Forms.PictureBox();
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.FormPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.ActiveLinkColor = System.Drawing.Color.Blue;
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("B Koodak", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTitle.LinkColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(-1, 1);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(153, 56);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.TabStop = true;
            this.lblTitle.Text = "نام اصلی دسترسی";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Paint += new System.Windows.Forms.PaintEventHandler(this.lblTitle_Paint);
            this.lblTitle.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblTitle_LinkClicked);
            // 
            // FormPanel
            // 
            this.FormPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.FormPanel.Controls.Add(this.lblTitle);
            this.FormPanel.Controls.Add(this.PictureBoxStatus);
            this.FormPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormPanel.Location = new System.Drawing.Point(0, 0);
            this.FormPanel.Name = "FormPanel";
            this.FormPanel.Size = new System.Drawing.Size(190, 56);
            // 
            // 
            // 
            this.FormPanel.Style.BackColor = System.Drawing.Color.Salmon;
            this.FormPanel.Style.BackColor2 = System.Drawing.Color.White;
            this.FormPanel.Style.BackColorGradientAngle = 90;
            this.FormPanel.Style.BorderBottomWidth = 1;
            this.FormPanel.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.FormPanel.Style.BorderLeftWidth = 1;
            this.FormPanel.Style.BorderRightWidth = 1;
            this.FormPanel.Style.BorderTopWidth = 1;
            this.FormPanel.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.FormPanel.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.FormPanel.TabIndex = 10;
            // 
            // PictureBoxStatus
            // 
            this.PictureBoxStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PictureBoxStatus.BackColor = System.Drawing.Color.Transparent;
            this.PictureBoxStatus.Image = global::Negar.Security.Properties.Resources.InfoSmall;
            this.PictureBoxStatus.Location = new System.Drawing.Point(155, 12);
            this.PictureBoxStatus.Name = "PictureBoxStatus";
            this.PictureBoxStatus.Size = new System.Drawing.Size(32, 32);
            this.PictureBoxStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PictureBoxStatus.TabIndex = 6;
            this.PictureBoxStatus.TabStop = false;
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            // 
            // ACLCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.FormPanel);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ACLCard";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(190, 56);
            this.FormPanel.ResumeLayout(false);
            this.FormPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.LinkLabel lblTitle;
        internal DevComponents.DotNetBar.Ribbon.RibbonClientPanel FormPanel;
        internal System.Windows.Forms.PictureBox PictureBoxStatus;
        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
    }
}
