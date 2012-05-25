namespace Sepehr.Forms.Cash
{
    partial class frmCashInOut
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCashInOut));
            this.PanelOpenCloseCash = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.txtValue = new DevComponents.Editors.IntegerInput();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnApply = new DevComponents.DotNetBar.ButtonX();
            this.lblTitle = new DevComponents.DotNetBar.LabelX();
            this.lblRial = new DevComponents.DotNetBar.LabelX();
            this.lblStartValue = new DevComponents.DotNetBar.LabelX();
            this.lblCash = new DevComponents.DotNetBar.LabelX();
            this.lblDescription = new DevComponents.DotNetBar.LabelX();
            this.lblCashier = new DevComponents.DotNetBar.LabelX();
            this.txtCash = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtDescription = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtCashier = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.PanelOpenCloseCash.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtValue)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelOpenCloseCash
            // 
            this.PanelOpenCloseCash.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelOpenCloseCash.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelOpenCloseCash.Controls.Add(this.txtValue);
            this.PanelOpenCloseCash.Controls.Add(this.btnClose);
            this.PanelOpenCloseCash.Controls.Add(this.btnApply);
            this.PanelOpenCloseCash.Controls.Add(this.lblTitle);
            this.PanelOpenCloseCash.Controls.Add(this.lblRial);
            this.PanelOpenCloseCash.Controls.Add(this.lblStartValue);
            this.PanelOpenCloseCash.Controls.Add(this.lblCash);
            this.PanelOpenCloseCash.Controls.Add(this.lblDescription);
            this.PanelOpenCloseCash.Controls.Add(this.lblCashier);
            this.PanelOpenCloseCash.Controls.Add(this.txtCash);
            this.PanelOpenCloseCash.Controls.Add(this.txtDescription);
            this.PanelOpenCloseCash.Controls.Add(this.txtCashier);
            this.PanelOpenCloseCash.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelOpenCloseCash.Location = new System.Drawing.Point(0, 0);
            this.PanelOpenCloseCash.Name = "PanelOpenCloseCash";
            this.PanelOpenCloseCash.Size = new System.Drawing.Size(334, 260);
            // 
            // 
            // 
            this.PanelOpenCloseCash.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.PanelOpenCloseCash.Style.BackColorGradientAngle = 90;
            this.PanelOpenCloseCash.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.PanelOpenCloseCash.Style.BorderBottomWidth = 1;
            this.PanelOpenCloseCash.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.PanelOpenCloseCash.Style.BorderLeftWidth = 1;
            this.PanelOpenCloseCash.Style.BorderRightWidth = 1;
            this.PanelOpenCloseCash.Style.BorderTopWidth = 1;
            this.PanelOpenCloseCash.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.PanelOpenCloseCash.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.PanelOpenCloseCash.TabIndex = 0;
            // 
            // txtValue
            // 
            this.txtValue.AllowEmptyState = false;
            this.txtValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtValue.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtValue.DisplayFormat = "N0";
            this.txtValue.Font = new System.Drawing.Font("Tahoma", 8.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtValue.ForeColor = System.Drawing.Color.Green;
            this.txtValue.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtValue.Location = new System.Drawing.Point(133, 97);
            this.txtValue.MaxValue = 100000000;
            this.txtValue.MinValue = 0;
            this.txtValue.Name = "txtValue";
            this.txtValue.ShowUpDown = true;
            this.txtValue.Size = new System.Drawing.Size(109, 22);
            this.txtValue.TabIndex = 0;
            this.txtValue.Tag = "";
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = global::Sepehr.Forms.Cash.Properties.Resources.Cancel;
            this.btnClose.Location = new System.Drawing.Point(118, 188);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 60);
            this.btnClose.TabIndex = 10;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "انصراف (Esc)";
            // 
            // btnApply
            // 
            this.btnApply.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnApply.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnApply.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnApply.Image = global::Sepehr.Forms.Cash.Properties.Resources.Accept;
            this.btnApply.Location = new System.Drawing.Point(12, 188);
            this.btnApply.Name = "btnApply";
            this.btnApply.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnApply.Size = new System.Drawing.Size(100, 60);
            this.btnApply.TabIndex = 9;
            this.btnApply.TabStop = false;
            this.btnApply.Text = "اعمال (F8)";
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("B Yekan", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(334, 39);
            this.lblTitle.TabIndex = 12;
            this.lblTitle.Text = "ورود/خروج پول";
            this.lblTitle.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lblRial
            // 
            this.lblRial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRial.AutoSize = true;
            this.lblRial.BackColor = System.Drawing.Color.Transparent;
            this.lblRial.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblRial.ForeColor = System.Drawing.Color.Green;
            this.lblRial.Location = new System.Drawing.Point(108, 100);
            this.lblRial.Name = "lblRial";
            this.lblRial.Size = new System.Drawing.Size(24, 16);
            this.lblRial.TabIndex = 1;
            this.lblRial.Text = "ریال";
            this.lblRial.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblStartValue
            // 
            this.lblStartValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStartValue.AutoSize = true;
            this.lblStartValue.BackColor = System.Drawing.Color.Transparent;
            this.lblStartValue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblStartValue.ForeColor = System.Drawing.Color.Green;
            this.lblStartValue.Location = new System.Drawing.Point(250, 100);
            this.lblStartValue.Name = "lblStartValue";
            this.lblStartValue.Size = new System.Drawing.Size(29, 16);
            this.lblStartValue.TabIndex = 2;
            this.lblStartValue.Text = "مبلغ:";
            this.lblStartValue.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblCash
            // 
            this.lblCash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCash.AutoSize = true;
            this.lblCash.BackColor = System.Drawing.Color.Transparent;
            this.lblCash.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblCash.Location = new System.Drawing.Point(250, 46);
            this.lblCash.Name = "lblCash";
            this.lblCash.Size = new System.Drawing.Size(44, 16);
            this.lblCash.TabIndex = 5;
            this.lblCash.Text = "صندوق:";
            this.lblCash.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescription.AutoSize = true;
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblDescription.Location = new System.Drawing.Point(250, 130);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(53, 16);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "توضیحات:";
            this.lblDescription.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblCashier
            // 
            this.lblCashier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCashier.AutoSize = true;
            this.lblCashier.BackColor = System.Drawing.Color.Transparent;
            this.lblCashier.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblCashier.Location = new System.Drawing.Point(250, 73);
            this.lblCashier.Name = "lblCashier";
            this.lblCashier.Size = new System.Drawing.Size(72, 16);
            this.lblCashier.TabIndex = 7;
            this.lblCashier.Text = "كاربر صندوق:";
            this.lblCashier.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // txtCash
            // 
            this.txtCash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            // 
            // 
            // 
            this.txtCash.Border.Class = "TextBoxBorder";
            this.txtCash.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtCash.ForeColor = System.Drawing.Color.Black;
            this.txtCash.Location = new System.Drawing.Point(13, 44);
            this.txtCash.Name = "txtCash";
            this.txtCash.ReadOnly = true;
            this.txtCash.Size = new System.Drawing.Size(229, 21);
            this.txtCash.TabIndex = 6;
            this.txtCash.TabStop = false;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtDescription.Border.Class = "TextBoxBorder";
            this.txtDescription.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtDescription.ForeColor = System.Drawing.Color.Black;
            this.txtDescription.Location = new System.Drawing.Point(13, 125);
            this.txtDescription.MaxLength = 300;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(229, 51);
            this.txtDescription.TabIndex = 3;
            // 
            // txtCashier
            // 
            this.txtCashier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCashier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            // 
            // 
            // 
            this.txtCashier.Border.Class = "TextBoxBorder";
            this.txtCashier.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtCashier.ForeColor = System.Drawing.Color.Black;
            this.txtCashier.Location = new System.Drawing.Point(13, 71);
            this.txtCashier.Name = "txtCashier";
            this.txtCashier.ReadOnly = true;
            this.txtCashier.Size = new System.Drawing.Size(229, 21);
            this.txtCashier.TabIndex = 8;
            this.txtCashier.TabStop = false;
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            // 
            // frmCashInOut
            // 
            this.AcceptButton = this.btnApply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(334, 260);
            this.Controls.Add(this.PanelOpenCloseCash);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCashInOut";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "صندوق - مدیریت صندوق ها - ورود یا خروج پول";
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.PanelOpenCloseCash.ResumeLayout(false);
            this.PanelOpenCloseCash.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtValue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel PanelOpenCloseCash;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.ButtonX btnApply;
        private DevComponents.DotNetBar.LabelX lblTitle;
        private DevComponents.DotNetBar.LabelX lblStartValue;
        private DevComponents.DotNetBar.LabelX lblCash;
        private DevComponents.DotNetBar.LabelX lblCashier;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCashier;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCash;
        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        private DevComponents.Editors.IntegerInput txtValue;
        private DevComponents.DotNetBar.LabelX lblDescription;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDescription;
        private DevComponents.DotNetBar.LabelX lblRial;

    }
}