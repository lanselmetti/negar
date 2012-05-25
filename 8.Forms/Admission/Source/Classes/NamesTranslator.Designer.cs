namespace Sepehr.Forms.Admission.Classes
{
    partial class frmNamesTranslator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNamesTranslator));
            this.FormPanel = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.lblTitle = new DevComponents.DotNetBar.LabelX();
            this.LogoImage = new DevComponents.DotNetBar.Controls.ReflectionImage();
            this.txtEnglishName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtLocaleName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblFirstName = new DevComponents.DotNetBar.LabelX();
            this.lblLastName = new DevComponents.DotNetBar.LabelX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.FormPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // FormPanel
            // 
            this.FormPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.FormPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.FormPanel.Controls.Add(this.lblTitle);
            this.FormPanel.Controls.Add(this.LogoImage);
            this.FormPanel.Controls.Add(this.txtEnglishName);
            this.FormPanel.Controls.Add(this.txtLocaleName);
            this.FormPanel.Controls.Add(this.lblFirstName);
            this.FormPanel.Controls.Add(this.lblLastName);
            this.FormPanel.Controls.Add(this.btnCancel);
            this.FormPanel.Controls.Add(this.btnSave);
            this.FormPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormPanel.Location = new System.Drawing.Point(0, 0);
            this.FormPanel.Name = "FormPanel";
            this.FormPanel.Size = new System.Drawing.Size(325, 246);
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
            // 
            // 
            // 
            this.lblTitle.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Double;
            this.lblTitle.BackgroundStyle.BorderBottomWidth = 2;
            this.lblTitle.BackgroundStyle.BorderColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarCaptionInactiveText;
            this.lblTitle.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarCaptionBackground2;
            this.lblTitle.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Double;
            this.lblTitle.BackgroundStyle.BorderLeftWidth = 1;
            this.lblTitle.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Double;
            this.lblTitle.BackgroundStyle.BorderRightWidth = 1;
            this.lblTitle.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Double;
            this.lblTitle.BackgroundStyle.BorderTopWidth = 1;
            this.lblTitle.Font = new System.Drawing.Font("B Yekan", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTitle.Location = new System.Drawing.Point(126, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(187, 65);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "ثبت معادل نام یا \r\nنام خانوادگی به انگلیسی";
            this.lblTitle.TextAlignment = System.Drawing.StringAlignment.Center;
            this.lblTitle.WordWrap = true;
            // 
            // LogoImage
            // 
            this.LogoImage.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.LogoImage.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.LogoImage.Image = global::Sepehr.Forms.Admission.Properties.Resources.PatientNameAddLogo;
            this.LogoImage.Location = new System.Drawing.Point(12, 12);
            this.LogoImage.MinimumSize = new System.Drawing.Size(32, 32);
            this.LogoImage.Name = "LogoImage";
            this.LogoImage.Size = new System.Drawing.Size(108, 156);
            this.LogoImage.TabIndex = 6;
            // 
            // txtEnglishName
            // 
            this.txtEnglishName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtEnglishName.Border.Class = "TextBoxBorder";
            this.txtEnglishName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtEnglishName.ForeColor = System.Drawing.Color.Navy;
            this.txtEnglishName.Location = new System.Drawing.Point(126, 147);
            this.txtEnglishName.MaxLength = 30;
            this.txtEnglishName.Name = "txtEnglishName";
            this.txtEnglishName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtEnglishName.Size = new System.Drawing.Size(187, 21);
            this.txtEnglishName.TabIndex = 1;
            this.txtEnglishName.Enter += new System.EventHandler(this.txtEnglishName_Enter);
            this.txtEnglishName.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Controls_PreviewKeyDown);
            this.txtEnglishName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEnglishName_KeyPress);
            // 
            // txtLocaleName
            // 
            this.txtLocaleName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtLocaleName.Border.Class = "TextBoxBorder";
            this.txtLocaleName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtLocaleName.ForeColor = System.Drawing.Color.Navy;
            this.txtLocaleName.Location = new System.Drawing.Point(126, 101);
            this.txtLocaleName.MaxLength = 30;
            this.txtLocaleName.Name = "txtLocaleName";
            this.txtLocaleName.Size = new System.Drawing.Size(187, 21);
            this.txtLocaleName.TabIndex = 0;
            this.txtLocaleName.Enter += new System.EventHandler(this.txtLocaleName_Enter);
            this.txtLocaleName.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Controls_PreviewKeyDown);
            this.txtLocaleName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLocaleName_KeyPress);
            // 
            // lblFirstName
            // 
            this.lblFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.BackColor = System.Drawing.Color.Transparent;
            this.lblFirstName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblFirstName.Location = new System.Drawing.Point(227, 128);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(86, 16);
            this.lblFirstName.TabIndex = 8;
            this.lblFirstName.Text = "نام به انگلیسی:";
            this.lblFirstName.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblLastName
            // 
            this.lblLastName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLastName.AutoSize = true;
            this.lblLastName.BackColor = System.Drawing.Color.Transparent;
            this.lblLastName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblLastName.Location = new System.Drawing.Point(235, 83);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(78, 16);
            this.lblLastName.TabIndex = 7;
            this.lblLastName.Text = "نام به فارسی:";
            this.lblLastName.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Sepehr.Forms.Admission.Properties.Resources.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(113, 174);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 60);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "انصراف (Esc)";
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Image = global::Sepehr.Forms.Admission.Properties.Resources.Accept;
            this.btnSave.Location = new System.Drawing.Point(12, 174);
            this.btnSave.Name = "btnSave";
            this.btnSave.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnSave.Size = new System.Drawing.Size(95, 60);
            this.btnSave.TabIndex = 2;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "ثبت (F8)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            // 
            // frmNamesTranslator
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(325, 246);
            this.Controls.Add(this.FormPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNamesTranslator";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "بیماران - ثبت معادل نام فارسی استثناء";
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.FormPanel.ResumeLayout(false);
            this.FormPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel FormPanel;
        internal DevComponents.DotNetBar.Controls.TextBoxX txtLocaleName;
        private DevComponents.DotNetBar.LabelX lblLastName;
        internal DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.LabelX lblFirstName;
        internal DevComponents.DotNetBar.Controls.TextBoxX txtEnglishName;
        internal DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        private DevComponents.DotNetBar.LabelX lblTitle;
        private DevComponents.DotNetBar.Controls.ReflectionImage LogoImage;

    }
}