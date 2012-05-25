namespace Sepehr.Forms.Admission.Referrals
{
    partial class frmRefInsDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRefInsDetails));
            this.lblInsName = new DevComponents.DotNetBar.LabelX();
            this.txtInsName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblPatientPercent = new DevComponents.DotNetBar.LabelX();
            this.lblContractDate = new DevComponents.DotNetBar.LabelX();
            this.lblInsPartLimit = new DevComponents.DotNetBar.LabelX();
            this.txtDescription = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblInsExpireDate = new DevComponents.DotNetBar.LabelX();
            this.lblIns2Formula = new DevComponents.DotNetBar.LabelX();
            this.lblDescription = new DevComponents.DotNetBar.LabelX();
            this.cBoxIsIns1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cBoxIsIns2 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.FormPanel = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.lblTitle = new DevComponents.DotNetBar.LabelX();
            this.txtFormula = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.txtInsPartLimit = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.DateExpiration = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.DateContract = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtPatientPercent = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.FormPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblInsName
            // 
            this.lblInsName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInsName.AutoSize = true;
            this.lblInsName.BackColor = System.Drawing.Color.Transparent;
            this.lblInsName.Location = new System.Drawing.Point(312, 50);
            this.lblInsName.Name = "lblInsName";
            this.lblInsName.Size = new System.Drawing.Size(47, 16);
            this.lblInsName.TabIndex = 1;
            this.lblInsName.Text = "نام بیمه:";
            this.lblInsName.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // txtInsName
            // 
            this.txtInsName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtInsName.Border.Class = "TextBoxBorder";
            this.txtInsName.ForeColor = System.Drawing.Color.Green;
            this.txtInsName.Location = new System.Drawing.Point(14, 45);
            this.txtInsName.MaxLength = 20;
            this.txtInsName.Name = "txtInsName";
            this.txtInsName.Size = new System.Drawing.Size(292, 21);
            this.txtInsName.TabIndex = 0;
            this.txtInsName.TabStop = false;
            this.txtInsName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxes_KeyPress);
            // 
            // lblPatientPercent
            // 
            this.lblPatientPercent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPatientPercent.AutoSize = true;
            this.lblPatientPercent.BackColor = System.Drawing.Color.Transparent;
            this.lblPatientPercent.Location = new System.Drawing.Point(312, 103);
            this.lblPatientPercent.Name = "lblPatientPercent";
            this.lblPatientPercent.Size = new System.Drawing.Size(91, 16);
            this.lblPatientPercent.TabIndex = 7;
            this.lblPatientPercent.Text = "درصد سهم بیمار:";
            this.lblPatientPercent.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblContractDate
            // 
            this.lblContractDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblContractDate.AutoSize = true;
            this.lblContractDate.BackColor = System.Drawing.Color.Transparent;
            this.lblContractDate.Location = new System.Drawing.Point(312, 76);
            this.lblContractDate.Name = "lblContractDate";
            this.lblContractDate.Size = new System.Drawing.Size(93, 16);
            this.lblContractDate.TabIndex = 3;
            this.lblContractDate.Text = "تاریخ آغاز قرارداد:";
            this.lblContractDate.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblInsPartLimit
            // 
            this.lblInsPartLimit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInsPartLimit.AutoSize = true;
            this.lblInsPartLimit.BackColor = System.Drawing.Color.Transparent;
            this.lblInsPartLimit.Location = new System.Drawing.Point(117, 101);
            this.lblInsPartLimit.Name = "lblInsPartLimit";
            this.lblInsPartLimit.Size = new System.Drawing.Size(103, 16);
            this.lblInsPartLimit.TabIndex = 9;
            this.lblInsPartLimit.Text = "سقف تعهد مراجعه:";
            this.lblInsPartLimit.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtDescription.Border.Class = "TextBoxBorder";
            this.txtDescription.ForeColor = System.Drawing.Color.Blue;
            this.txtDescription.Location = new System.Drawing.Point(14, 175);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(292, 38);
            this.txtDescription.TabIndex = 23;
            this.txtDescription.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxes_KeyPress);
            // 
            // lblInsExpireDate
            // 
            this.lblInsExpireDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInsExpireDate.AutoSize = true;
            this.lblInsExpireDate.BackColor = System.Drawing.Color.Transparent;
            this.lblInsExpireDate.Location = new System.Drawing.Point(117, 74);
            this.lblInsExpireDate.Name = "lblInsExpireDate";
            this.lblInsExpireDate.Size = new System.Drawing.Size(99, 16);
            this.lblInsExpireDate.TabIndex = 5;
            this.lblInsExpireDate.Text = "تاریخ اتمام قرارداد:";
            this.lblInsExpireDate.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblIns2Formula
            // 
            this.lblIns2Formula.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIns2Formula.AutoSize = true;
            this.lblIns2Formula.BackColor = System.Drawing.Color.Transparent;
            this.lblIns2Formula.ForeColor = System.Drawing.Color.Black;
            this.lblIns2Formula.Location = new System.Drawing.Point(312, 150);
            this.lblIns2Formula.Name = "lblIns2Formula";
            this.lblIns2Formula.Size = new System.Drawing.Size(88, 16);
            this.lblIns2Formula.TabIndex = 20;
            this.lblIns2Formula.Text = "فرمول بیمه دوم:";
            this.lblIns2Formula.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescription.AutoSize = true;
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.ForeColor = System.Drawing.Color.Black;
            this.lblDescription.Location = new System.Drawing.Point(312, 175);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(53, 16);
            this.lblDescription.TabIndex = 22;
            this.lblDescription.Text = "توضیحات:";
            this.lblDescription.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // cBoxIsIns1
            // 
            this.cBoxIsIns1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxIsIns1.AutoSize = true;
            this.cBoxIsIns1.BackColor = System.Drawing.Color.Transparent;
            this.cBoxIsIns1.Location = new System.Drawing.Point(240, 126);
            this.cBoxIsIns1.Name = "cBoxIsIns1";
            this.cBoxIsIns1.Size = new System.Drawing.Size(66, 16);
            this.cBoxIsIns1.TabIndex = 11;
            this.cBoxIsIns1.Text = "بیمه اول";
            this.cBoxIsIns1.TextColor = System.Drawing.Color.Green;
            // 
            // cBoxIsIns2
            // 
            this.cBoxIsIns2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxIsIns2.AutoSize = true;
            this.cBoxIsIns2.BackColor = System.Drawing.Color.Transparent;
            this.cBoxIsIns2.Location = new System.Drawing.Point(166, 126);
            this.cBoxIsIns2.Name = "cBoxIsIns2";
            this.cBoxIsIns2.Size = new System.Drawing.Size(68, 16);
            this.cBoxIsIns2.TabIndex = 12;
            this.cBoxIsIns2.Text = "بیمه دوم";
            this.cBoxIsIns2.TextColor = System.Drawing.Color.Green;
            // 
            // FormPanel
            // 
            this.FormPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.FormPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.FormPanel.Controls.Add(this.lblTitle);
            this.FormPanel.Controls.Add(this.txtFormula);
            this.FormPanel.Controls.Add(this.cBoxIsIns2);
            this.FormPanel.Controls.Add(this.cBoxIsIns1);
            this.FormPanel.Controls.Add(this.lblDescription);
            this.FormPanel.Controls.Add(this.lblIns2Formula);
            this.FormPanel.Controls.Add(this.lblInsExpireDate);
            this.FormPanel.Controls.Add(this.txtDescription);
            this.FormPanel.Controls.Add(this.lblInsPartLimit);
            this.FormPanel.Controls.Add(this.lblContractDate);
            this.FormPanel.Controls.Add(this.lblPatientPercent);
            this.FormPanel.Controls.Add(this.btnCancel);
            this.FormPanel.Controls.Add(this.txtInsPartLimit);
            this.FormPanel.Controls.Add(this.DateExpiration);
            this.FormPanel.Controls.Add(this.DateContract);
            this.FormPanel.Controls.Add(this.txtPatientPercent);
            this.FormPanel.Controls.Add(this.txtInsName);
            this.FormPanel.Controls.Add(this.lblInsName);
            this.FormPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormPanel.Location = new System.Drawing.Point(0, 0);
            this.FormPanel.Name = "FormPanel";
            this.FormPanel.Size = new System.Drawing.Size(411, 293);
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
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("B Yekan", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(411, 39);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "خلاصه ساختار تنظیمات بیمه";
            this.lblTitle.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // txtFormula
            // 
            this.txtFormula.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtFormula.Border.Class = "TextBoxBorder";
            this.txtFormula.ForeColor = System.Drawing.Color.Blue;
            this.txtFormula.Location = new System.Drawing.Point(14, 147);
            this.txtFormula.MaxLength = 30;
            this.txtFormula.Multiline = true;
            this.txtFormula.Name = "txtFormula";
            this.txtFormula.Size = new System.Drawing.Size(292, 22);
            this.txtFormula.TabIndex = 21;
            this.txtFormula.TabStop = false;
            this.txtFormula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxes_KeyPress);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnCancel.Image = global::Sepehr.Forms.Admission.Properties.Resources.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(14, 221);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 60);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "خروج\r\n(Esc)";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtInsPartLimit
            // 
            this.txtInsPartLimit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtInsPartLimit.Border.Class = "TextBoxBorder";
            this.txtInsPartLimit.ForeColor = System.Drawing.Color.Green;
            this.txtInsPartLimit.Location = new System.Drawing.Point(14, 99);
            this.txtInsPartLimit.MaxLength = 30;
            this.txtInsPartLimit.Name = "txtInsPartLimit";
            this.txtInsPartLimit.Size = new System.Drawing.Size(96, 21);
            this.txtInsPartLimit.TabIndex = 10;
            this.txtInsPartLimit.TabStop = false;
            this.txtInsPartLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtInsPartLimit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxes_KeyPress);
            // 
            // DateExpiration
            // 
            this.DateExpiration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.DateExpiration.Border.Class = "TextBoxBorder";
            this.DateExpiration.ForeColor = System.Drawing.Color.Green;
            this.DateExpiration.Location = new System.Drawing.Point(14, 72);
            this.DateExpiration.MaxLength = 20;
            this.DateExpiration.Name = "DateExpiration";
            this.DateExpiration.Size = new System.Drawing.Size(96, 21);
            this.DateExpiration.TabIndex = 6;
            this.DateExpiration.TabStop = false;
            this.DateExpiration.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.DateExpiration.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxes_KeyPress);
            // 
            // DateContract
            // 
            this.DateContract.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.DateContract.Border.Class = "TextBoxBorder";
            this.DateContract.ForeColor = System.Drawing.Color.Green;
            this.DateContract.Location = new System.Drawing.Point(223, 72);
            this.DateContract.MaxLength = 20;
            this.DateContract.Name = "DateContract";
            this.DateContract.Size = new System.Drawing.Size(83, 21);
            this.DateContract.TabIndex = 4;
            this.DateContract.TabStop = false;
            this.DateContract.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.DateContract.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxes_KeyPress);
            // 
            // txtPatientPercent
            // 
            this.txtPatientPercent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtPatientPercent.Border.Class = "TextBoxBorder";
            this.txtPatientPercent.ForeColor = System.Drawing.Color.Green;
            this.txtPatientPercent.Location = new System.Drawing.Point(223, 99);
            this.txtPatientPercent.MaxLength = 20;
            this.txtPatientPercent.Name = "txtPatientPercent";
            this.txtPatientPercent.Size = new System.Drawing.Size(83, 21);
            this.txtPatientPercent.TabIndex = 8;
            this.txtPatientPercent.TabStop = false;
            this.txtPatientPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPatientPercent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxes_KeyPress);
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            // 
            // frmRefInsDetails
            // 
            this.AcceptButton = this.btnCancel;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(411, 293);
            this.Controls.Add(this.FormPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRefInsDetails";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "بیماران - مراجعات - اطلاعات بیمه ها - خلاصه اطلاعات";
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.FormPanel.ResumeLayout(false);
            this.FormPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX lblInsName;
        internal DevComponents.DotNetBar.Controls.TextBoxX txtInsName;
        internal DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.LabelX lblPatientPercent;
        private DevComponents.DotNetBar.LabelX lblContractDate;
        private DevComponents.DotNetBar.LabelX lblInsPartLimit;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDescription;
        private DevComponents.DotNetBar.LabelX lblInsExpireDate;
        private DevComponents.DotNetBar.LabelX lblIns2Formula;
        private DevComponents.DotNetBar.LabelX lblDescription;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxIsIns1;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxIsIns2;
        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel FormPanel;
        internal DevComponents.DotNetBar.Controls.TextBoxX txtFormula;
        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        internal DevComponents.DotNetBar.Controls.TextBoxX txtInsPartLimit;
        internal DevComponents.DotNetBar.Controls.TextBoxX txtPatientPercent;
        internal DevComponents.DotNetBar.Controls.TextBoxX DateExpiration;
        internal DevComponents.DotNetBar.Controls.TextBoxX DateContract;
        private DevComponents.DotNetBar.LabelX lblTitle;

    }
}