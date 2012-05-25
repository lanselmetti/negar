namespace Sepehr.Forms.Cash
{
    partial class frmCashOpenClose
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCashOpenClose));
            this.PanelOpenCloseCash = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.txtFinishValue = new DevComponents.Editors.IntegerInput();
            this.txtStartValue = new DevComponents.Editors.IntegerInput();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnApply = new DevComponents.DotNetBar.ButtonX();
            this.lblTitle = new DevComponents.DotNetBar.LabelX();
            this.lblRial3 = new DevComponents.DotNetBar.LabelX();
            this.lblRial2 = new DevComponents.DotNetBar.LabelX();
            this.lblRial1 = new DevComponents.DotNetBar.LabelX();
            this.lblOrderedValue = new DevComponents.DotNetBar.LabelX();
            this.lblFinishValue = new DevComponents.DotNetBar.LabelX();
            this.lblStartValue = new DevComponents.DotNetBar.LabelX();
            this.lblCash = new DevComponents.DotNetBar.LabelX();
            this.lblCashStatus = new DevComponents.DotNetBar.LabelX();
            this.lblCashier = new DevComponents.DotNetBar.LabelX();
            this.txtCash = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtCashStatus = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtCashier = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtOrderedValue = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.PanelOpenCloseCash.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFinishValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStartValue)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelOpenCloseCash
            // 
            this.PanelOpenCloseCash.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelOpenCloseCash.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelOpenCloseCash.Controls.Add(this.txtFinishValue);
            this.PanelOpenCloseCash.Controls.Add(this.txtStartValue);
            this.PanelOpenCloseCash.Controls.Add(this.btnClose);
            this.PanelOpenCloseCash.Controls.Add(this.btnApply);
            this.PanelOpenCloseCash.Controls.Add(this.lblTitle);
            this.PanelOpenCloseCash.Controls.Add(this.lblRial3);
            this.PanelOpenCloseCash.Controls.Add(this.lblRial2);
            this.PanelOpenCloseCash.Controls.Add(this.lblRial1);
            this.PanelOpenCloseCash.Controls.Add(this.lblOrderedValue);
            this.PanelOpenCloseCash.Controls.Add(this.lblFinishValue);
            this.PanelOpenCloseCash.Controls.Add(this.lblStartValue);
            this.PanelOpenCloseCash.Controls.Add(this.lblCash);
            this.PanelOpenCloseCash.Controls.Add(this.lblCashStatus);
            this.PanelOpenCloseCash.Controls.Add(this.lblCashier);
            this.PanelOpenCloseCash.Controls.Add(this.txtCash);
            this.PanelOpenCloseCash.Controls.Add(this.txtCashStatus);
            this.PanelOpenCloseCash.Controls.Add(this.txtCashier);
            this.PanelOpenCloseCash.Controls.Add(this.txtOrderedValue);
            this.PanelOpenCloseCash.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelOpenCloseCash.Location = new System.Drawing.Point(0, 0);
            this.PanelOpenCloseCash.Name = "PanelOpenCloseCash";
            this.PanelOpenCloseCash.Size = new System.Drawing.Size(333, 283);
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
            // txtFinishValue
            // 
            this.txtFinishValue.AllowEmptyState = false;
            this.txtFinishValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtFinishValue.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtFinishValue.DisplayFormat = "N0";
            this.txtFinishValue.Font = new System.Drawing.Font("Tahoma", 8.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtFinishValue.ForeColor = System.Drawing.Color.Navy;
            this.txtFinishValue.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtFinishValue.Location = new System.Drawing.Point(132, 179);
            this.txtFinishValue.MaxValue = 100000000;
            this.txtFinishValue.MinValue = 0;
            this.txtFinishValue.Name = "txtFinishValue";
            this.txtFinishValue.ShowUpDown = true;
            this.txtFinishValue.Size = new System.Drawing.Size(109, 22);
            this.txtFinishValue.TabIndex = 0;
            this.txtFinishValue.Tag = "";
            // 
            // txtStartValue
            // 
            this.txtStartValue.AllowEmptyState = false;
            this.txtStartValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtStartValue.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtStartValue.DisplayFormat = "N0";
            this.txtStartValue.Font = new System.Drawing.Font("Tahoma", 8.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtStartValue.ForeColor = System.Drawing.Color.Green;
            this.txtStartValue.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtStartValue.Location = new System.Drawing.Point(132, 127);
            this.txtStartValue.MaxValue = 100000000;
            this.txtStartValue.MinValue = 0;
            this.txtStartValue.Name = "txtStartValue";
            this.txtStartValue.ShowUpDown = true;
            this.txtStartValue.Size = new System.Drawing.Size(109, 22);
            this.txtStartValue.TabIndex = 1;
            this.txtStartValue.Tag = "";
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = global::Sepehr.Forms.Cash.Properties.Resources.Cancel;
            this.btnClose.Location = new System.Drawing.Point(118, 211);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 60);
            this.btnClose.TabIndex = 17;
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
            this.btnApply.Location = new System.Drawing.Point(12, 211);
            this.btnApply.Name = "btnApply";
            this.btnApply.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnApply.Size = new System.Drawing.Size(100, 60);
            this.btnApply.TabIndex = 16;
            this.btnApply.TabStop = false;
            this.btnApply.Text = "باز كردن صندوق (F8)";
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("B Yekan", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(333, 39);
            this.lblTitle.TabIndex = 15;
            this.lblTitle.Text = "بازكردن و بستن صندوق";
            this.lblTitle.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lblRial3
            // 
            this.lblRial3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRial3.AutoSize = true;
            this.lblRial3.BackColor = System.Drawing.Color.Transparent;
            this.lblRial3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblRial3.ForeColor = System.Drawing.Color.Navy;
            this.lblRial3.Location = new System.Drawing.Point(107, 181);
            this.lblRial3.Name = "lblRial3";
            this.lblRial3.Size = new System.Drawing.Size(24, 16);
            this.lblRial3.TabIndex = 3;
            this.lblRial3.Text = "ریال";
            this.lblRial3.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblRial2
            // 
            this.lblRial2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRial2.AutoSize = true;
            this.lblRial2.BackColor = System.Drawing.Color.Transparent;
            this.lblRial2.Font = new System.Drawing.Font("Tahoma", 8.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblRial2.ForeColor = System.Drawing.Color.Black;
            this.lblRial2.Location = new System.Drawing.Point(106, 154);
            this.lblRial2.Name = "lblRial2";
            this.lblRial2.Size = new System.Drawing.Size(25, 17);
            this.lblRial2.TabIndex = 6;
            this.lblRial2.Text = "ریال";
            this.lblRial2.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblRial1
            // 
            this.lblRial1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRial1.AutoSize = true;
            this.lblRial1.BackColor = System.Drawing.Color.Transparent;
            this.lblRial1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblRial1.ForeColor = System.Drawing.Color.Green;
            this.lblRial1.Location = new System.Drawing.Point(107, 127);
            this.lblRial1.Name = "lblRial1";
            this.lblRial1.Size = new System.Drawing.Size(24, 16);
            this.lblRial1.TabIndex = 2;
            this.lblRial1.Text = "ریال";
            this.lblRial1.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblOrderedValue
            // 
            this.lblOrderedValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOrderedValue.AutoSize = true;
            this.lblOrderedValue.BackColor = System.Drawing.Color.Transparent;
            this.lblOrderedValue.Font = new System.Drawing.Font("Tahoma", 8.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblOrderedValue.ForeColor = System.Drawing.Color.Black;
            this.lblOrderedValue.Location = new System.Drawing.Point(248, 154);
            this.lblOrderedValue.Name = "lblOrderedValue";
            this.lblOrderedValue.Size = new System.Drawing.Size(82, 17);
            this.lblOrderedValue.TabIndex = 4;
            this.lblOrderedValue.Text = "موجودی مقرر:";
            this.lblOrderedValue.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblFinishValue
            // 
            this.lblFinishValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFinishValue.AutoSize = true;
            this.lblFinishValue.BackColor = System.Drawing.Color.Transparent;
            this.lblFinishValue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblFinishValue.ForeColor = System.Drawing.Color.Navy;
            this.lblFinishValue.Location = new System.Drawing.Point(248, 181);
            this.lblFinishValue.Name = "lblFinishValue";
            this.lblFinishValue.Size = new System.Drawing.Size(71, 16);
            this.lblFinishValue.TabIndex = 7;
            this.lblFinishValue.Text = "موجودی آخر:";
            this.lblFinishValue.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblStartValue
            // 
            this.lblStartValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStartValue.AutoSize = true;
            this.lblStartValue.BackColor = System.Drawing.Color.Transparent;
            this.lblStartValue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblStartValue.ForeColor = System.Drawing.Color.Green;
            this.lblStartValue.Location = new System.Drawing.Point(248, 127);
            this.lblStartValue.Name = "lblStartValue";
            this.lblStartValue.Size = new System.Drawing.Size(71, 16);
            this.lblStartValue.TabIndex = 8;
            this.lblStartValue.Text = "موجودی اول:";
            this.lblStartValue.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblCash
            // 
            this.lblCash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCash.AutoSize = true;
            this.lblCash.BackColor = System.Drawing.Color.Transparent;
            this.lblCash.Location = new System.Drawing.Point(248, 46);
            this.lblCash.Name = "lblCash";
            this.lblCash.Size = new System.Drawing.Size(39, 16);
            this.lblCash.TabIndex = 13;
            this.lblCash.Text = "صندوق:";
            this.lblCash.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblCashStatus
            // 
            this.lblCashStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCashStatus.AutoSize = true;
            this.lblCashStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblCashStatus.Location = new System.Drawing.Point(248, 73);
            this.lblCashStatus.Name = "lblCashStatus";
            this.lblCashStatus.Size = new System.Drawing.Size(75, 16);
            this.lblCashStatus.TabIndex = 11;
            this.lblCashStatus.Text = "وضعیت صندوق:";
            this.lblCashStatus.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblCashier
            // 
            this.lblCashier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCashier.AutoSize = true;
            this.lblCashier.BackColor = System.Drawing.Color.Transparent;
            this.lblCashier.Location = new System.Drawing.Point(248, 100);
            this.lblCashier.Name = "lblCashier";
            this.lblCashier.Size = new System.Drawing.Size(62, 16);
            this.lblCashier.TabIndex = 9;
            this.lblCashier.Text = "كاربر صندوق:";
            this.lblCashier.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // txtCash
            // 
            this.txtCash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCash.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtCash.Border.Class = "TextBoxBorder";
            this.txtCash.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtCash.ForeColor = System.Drawing.Color.Black;
            this.txtCash.Location = new System.Drawing.Point(12, 44);
            this.txtCash.Name = "txtCash";
            this.txtCash.ReadOnly = true;
            this.txtCash.Size = new System.Drawing.Size(229, 21);
            this.txtCash.TabIndex = 14;
            this.txtCash.TabStop = false;
            // 
            // txtCashStatus
            // 
            this.txtCashStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCashStatus.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtCashStatus.Border.Class = "TextBoxBorder";
            this.txtCashStatus.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtCashStatus.ForeColor = System.Drawing.Color.Black;
            this.txtCashStatus.Location = new System.Drawing.Point(12, 71);
            this.txtCashStatus.Name = "txtCashStatus";
            this.txtCashStatus.ReadOnly = true;
            this.txtCashStatus.Size = new System.Drawing.Size(229, 21);
            this.txtCashStatus.TabIndex = 12;
            this.txtCashStatus.TabStop = false;
            // 
            // txtCashier
            // 
            this.txtCashier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCashier.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtCashier.Border.Class = "TextBoxBorder";
            this.txtCashier.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtCashier.ForeColor = System.Drawing.Color.Black;
            this.txtCashier.Location = new System.Drawing.Point(12, 98);
            this.txtCashier.Name = "txtCashier";
            this.txtCashier.ReadOnly = true;
            this.txtCashier.Size = new System.Drawing.Size(229, 21);
            this.txtCashier.TabIndex = 10;
            this.txtCashier.TabStop = false;
            // 
            // txtOrderedValue
            // 
            this.txtOrderedValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOrderedValue.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtOrderedValue.Border.Class = "TextBoxBorder";
            this.txtOrderedValue.Font = new System.Drawing.Font("Tahoma", 8.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtOrderedValue.ForeColor = System.Drawing.Color.Black;
            this.txtOrderedValue.Location = new System.Drawing.Point(132, 152);
            this.txtOrderedValue.Name = "txtOrderedValue";
            this.txtOrderedValue.ReadOnly = true;
            this.txtOrderedValue.Size = new System.Drawing.Size(109, 22);
            this.txtOrderedValue.TabIndex = 5;
            this.txtOrderedValue.TabStop = false;
            this.txtOrderedValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            // 
            // frmCashOpenClose
            // 
            this.AcceptButton = this.btnApply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(333, 283);
            this.Controls.Add(this.PanelOpenCloseCash);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCashOpenClose";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "صندوق - مدیریت صندوق ها - باز كردن و بستن صندوق";
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.PanelOpenCloseCash.ResumeLayout(false);
            this.PanelOpenCloseCash.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFinishValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStartValue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel PanelOpenCloseCash;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.ButtonX btnApply;
        private DevComponents.DotNetBar.LabelX lblTitle;
        private DevComponents.DotNetBar.LabelX lblRial1;
        private DevComponents.DotNetBar.LabelX lblStartValue;
        private DevComponents.DotNetBar.LabelX lblCash;
        private DevComponents.DotNetBar.LabelX lblCashier;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCashier;
        private DevComponents.DotNetBar.LabelX lblRial3;
        private DevComponents.DotNetBar.LabelX lblRial2;
        private DevComponents.DotNetBar.LabelX lblOrderedValue;
        private DevComponents.DotNetBar.LabelX lblFinishValue;
        private DevComponents.DotNetBar.LabelX lblCashStatus;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCashStatus;
        private DevComponents.DotNetBar.Controls.TextBoxX txtOrderedValue;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCash;
        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        private DevComponents.Editors.IntegerInput txtFinishValue;
        private DevComponents.Editors.IntegerInput txtStartValue;

    }
}