namespace Sepehr.Settings.Insurances.InsurancesServices
{
    partial class frmCopySettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCopySettings));
            this.FormPanel = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.lstIns = new DevComponents.DotNetBar.ItemPanel();
            this.cboIns = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.btnHelp = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnAccept = new DevComponents.DotNetBar.ButtonX();
            this.lblTitle = new DevComponents.DotNetBar.LabelX();
            this.lblCopy = new DevComponents.DotNetBar.LabelX();
            this.lblIns = new DevComponents.DotNetBar.LabelX();
            this.LogoImage = new DevComponents.DotNetBar.Controls.ReflectionImage();
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.FormPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // FormPanel
            // 
            this.FormPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.FormPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.FormPanel.Controls.Add(this.lstIns);
            this.FormPanel.Controls.Add(this.cboIns);
            this.FormPanel.Controls.Add(this.btnHelp);
            this.FormPanel.Controls.Add(this.btnCancel);
            this.FormPanel.Controls.Add(this.btnAccept);
            this.FormPanel.Controls.Add(this.lblTitle);
            this.FormPanel.Controls.Add(this.lblCopy);
            this.FormPanel.Controls.Add(this.lblIns);
            this.FormPanel.Controls.Add(this.LogoImage);
            this.FormPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormPanel.Location = new System.Drawing.Point(0, 0);
            this.FormPanel.Name = "FormPanel";
            this.FormPanel.Size = new System.Drawing.Size(353, 483);
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
            // lstIns
            // 
            this.lstIns.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstIns.AutoScroll = true;
            // 
            // 
            // 
            this.lstIns.BackgroundStyle.BackColor = System.Drawing.Color.White;
            this.lstIns.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lstIns.BackgroundStyle.BorderBottomWidth = 1;
            this.lstIns.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            this.lstIns.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lstIns.BackgroundStyle.BorderLeftWidth = 1;
            this.lstIns.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lstIns.BackgroundStyle.BorderRightWidth = 1;
            this.lstIns.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lstIns.BackgroundStyle.BorderTopWidth = 1;
            this.lstIns.BackgroundStyle.PaddingBottom = 1;
            this.lstIns.BackgroundStyle.PaddingLeft = 1;
            this.lstIns.BackgroundStyle.PaddingRight = 1;
            this.lstIns.BackgroundStyle.PaddingTop = 1;
            this.lstIns.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lstIns.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.lstIns.Location = new System.Drawing.Point(12, 116);
            this.lstIns.Name = "lstIns";
            this.lstIns.Size = new System.Drawing.Size(329, 292);
            this.lstIns.TabIndex = 3;
            // 
            // cboIns
            // 
            this.cboIns.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboIns.DisplayMember = "Name";
            this.cboIns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIns.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.cboIns.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cboIns.FormattingEnabled = true;
            this.cboIns.ItemHeight = 13;
            this.cboIns.Location = new System.Drawing.Point(91, 65);
            this.cboIns.Name = "cboIns";
            this.cboIns.Size = new System.Drawing.Size(250, 21);
            this.cboIns.TabIndex = 0;
            this.cboIns.ValueMember = "ID";
            this.cboIns.WatermarkText = "یك گروه از لیست انتخاب نمایید...";
            this.cboIns.SelectedIndexChanged += new System.EventHandler(this.cboIns_SelectedIndexChanged);
            // 
            // btnHelp
            // 
            this.btnHelp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnHelp.Image = global::Sepehr.Settings.Insurances.Properties.Resources.Help;
            this.btnHelp.Location = new System.Drawing.Point(246, 414);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F1);
            this.btnHelp.Size = new System.Drawing.Size(95, 57);
            this.btnHelp.TabIndex = 6;
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
            this.btnCancel.Image = global::Sepehr.Settings.Insurances.Properties.Resources.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(112, 414);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 57);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "خروج\r\n(Esc)";
            // 
            // btnAccept
            // 
            this.btnAccept.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAccept.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAccept.Image = global::Sepehr.Settings.Insurances.Properties.Resources.Accept;
            this.btnAccept.Location = new System.Drawing.Point(11, 414);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F4);
            this.btnAccept.Size = new System.Drawing.Size(95, 57);
            this.btnAccept.TabIndex = 4;
            this.btnAccept.TabStop = false;
            this.btnAccept.Text = "اجرا (F4)";
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("B Yekan", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(353, 37);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "كپی برداری تنظیمات ارتباط بیمه ها و خدمات";
            this.lblTitle.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lblCopy
            // 
            this.lblCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCopy.AutoSize = true;
            this.lblCopy.BackColor = System.Drawing.Color.Transparent;
            this.lblCopy.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblCopy.Location = new System.Drawing.Point(270, 94);
            this.lblCopy.Name = "lblCopy";
            this.lblCopy.Size = new System.Drawing.Size(71, 16);
            this.lblCopy.TabIndex = 2;
            this.lblCopy.Text = "كپی شود به:";
            this.lblCopy.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblIns
            // 
            this.lblIns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIns.AutoSize = true;
            this.lblIns.BackColor = System.Drawing.Color.Transparent;
            this.lblIns.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblIns.Location = new System.Drawing.Point(188, 43);
            this.lblIns.Name = "lblIns";
            this.lblIns.Size = new System.Drawing.Size(153, 16);
            this.lblIns.TabIndex = 1;
            this.lblIns.Text = "كلیه تنظیمات خدمات بیمه ی:";
            this.lblIns.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // LogoImage
            // 
            this.LogoImage.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.LogoImage.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.LogoImage.Image = global::Sepehr.Settings.Insurances.Properties.Resources.ServicesSettings;
            this.LogoImage.Location = new System.Drawing.Point(12, 43);
            this.LogoImage.Name = "LogoImage";
            this.LogoImage.Size = new System.Drawing.Size(73, 67);
            this.LogoImage.TabIndex = 7;
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            // 
            // frmCopySettings
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(353, 483);
            this.Controls.Add(this.FormPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCopySettings";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تنظیمات - مراجعات - بیمه ها - كپی برداری تنظیمات بیمه ها";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.FormPanel.ResumeLayout(false);
            this.FormPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel FormPanel;
        private DevComponents.DotNetBar.Controls.ReflectionImage LogoImage;
        private DevComponents.DotNetBar.LabelX lblTitle;
        internal DevComponents.DotNetBar.ButtonX btnHelp;
        internal DevComponents.DotNetBar.ButtonX btnCancel;
        internal DevComponents.DotNetBar.ButtonX btnAccept;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboIns;
        private DevComponents.DotNetBar.LabelX lblIns;
        private DevComponents.DotNetBar.ItemPanel lstIns;
        private DevComponents.DotNetBar.LabelX lblCopy;
        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
    }
}