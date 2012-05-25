namespace Sepehr.Forms.Account
{
    partial class frmManageTransDesc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageTransDesc));
            this.lblDescription = new DevComponents.DotNetBar.LabelX();
            this.CheckDate = new Negar.PersianCalendar.UI.Controls.PersianDatePicker();
            this.lblCheckDate = new DevComponents.DotNetBar.LabelX();
            this.txtDescription = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtBranchName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblBranchName = new DevComponents.DotNetBar.LabelX();
            this.lblInsName = new DevComponents.DotNetBar.LabelX();
            this.cboBankName = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.lblBranchCode = new DevComponents.DotNetBar.LabelX();
            this.lblCheckNumber = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.lblAccountNumber = new DevComponents.DotNetBar.LabelX();
            this.txtBranchCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtAccountNumber = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtCheckNumber = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.PanelTransaction = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.cBox3 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cBox2 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cBox1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.lblTitle = new DevComponents.DotNetBar.LabelX();
            this.btnAccept = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.PanelTransaction.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblDescription.Location = new System.Drawing.Point(392, 189);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(65, 16);
            this.lblDescription.TabIndex = 16;
            this.lblDescription.Text = "توضیحات:";
            this.lblDescription.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // CheckDate
            // 
            this.CheckDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckDate.IsPopupOpen = false;
            this.CheckDate.Location = new System.Drawing.Point(281, 158);
            this.CheckDate.Name = "CheckDate";
            this.CheckDate.SelectedDateTime = new System.DateTime(2010, 4, 15, 22, 33, 45, 125);
            this.CheckDate.Size = new System.Drawing.Size(104, 21);
            this.CheckDate.TabIndex = 15;
            // 
            // lblCheckDate
            // 
            this.lblCheckDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCheckDate.BackColor = System.Drawing.Color.Transparent;
            this.lblCheckDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblCheckDate.Location = new System.Drawing.Point(392, 160);
            this.lblCheckDate.Name = "lblCheckDate";
            this.lblCheckDate.Size = new System.Drawing.Size(42, 16);
            this.lblCheckDate.TabIndex = 14;
            this.lblCheckDate.Text = "تاریخ :";
            this.lblCheckDate.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtDescription.Border.Class = "TextBoxBorder";
            this.txtDescription.Location = new System.Drawing.Point(12, 185);
            this.txtDescription.MaxLength = 300;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(373, 34);
            this.txtDescription.TabIndex = 17;
            // 
            // txtBranchName
            // 
            this.txtBranchName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtBranchName.Border.Class = "TextBoxBorder";
            this.txtBranchName.ForeColor = System.Drawing.Color.Navy;
            this.txtBranchName.Location = new System.Drawing.Point(243, 104);
            this.txtBranchName.MaxLength = 50;
            this.txtBranchName.Name = "txtBranchName";
            this.txtBranchName.Size = new System.Drawing.Size(142, 21);
            this.txtBranchName.TabIndex = 7;
            this.txtBranchName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblBranchName
            // 
            this.lblBranchName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBranchName.AutoSize = true;
            this.lblBranchName.BackColor = System.Drawing.Color.Transparent;
            this.lblBranchName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblBranchName.Location = new System.Drawing.Point(392, 106);
            this.lblBranchName.Name = "lblBranchName";
            this.lblBranchName.Size = new System.Drawing.Size(55, 16);
            this.lblBranchName.TabIndex = 6;
            this.lblBranchName.Text = "نام شعبه:";
            this.lblBranchName.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblInsName
            // 
            this.lblInsName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInsName.AutoSize = true;
            this.lblInsName.BackColor = System.Drawing.Color.Transparent;
            this.lblInsName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblInsName.Location = new System.Drawing.Point(392, 57);
            this.lblInsName.Name = "lblInsName";
            this.lblInsName.Size = new System.Drawing.Size(46, 16);
            this.lblInsName.TabIndex = 1;
            this.lblInsName.Text = "نام بانك:";
            this.lblInsName.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // cboBankName
            // 
            this.cboBankName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboBankName.DisplayMember = "Name";
            this.cboBankName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBankName.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.cboBankName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cboBankName.ItemHeight = 13;
            this.cboBankName.Location = new System.Drawing.Point(184, 55);
            this.cboBankName.Name = "cboBankName";
            this.cboBankName.Size = new System.Drawing.Size(201, 21);
            this.cboBankName.TabIndex = 0;
            this.cboBankName.ValueMember = "ID";
            // 
            // lblBranchCode
            // 
            this.lblBranchCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBranchCode.AutoSize = true;
            this.lblBranchCode.BackColor = System.Drawing.Color.Transparent;
            this.lblBranchCode.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblBranchCode.Location = new System.Drawing.Point(148, 106);
            this.lblBranchCode.Name = "lblBranchCode";
            this.lblBranchCode.Size = new System.Drawing.Size(74, 16);
            this.lblBranchCode.TabIndex = 8;
            this.lblBranchCode.Text = "شماره شعبه:";
            this.lblBranchCode.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblCheckNumber
            // 
            this.lblCheckNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCheckNumber.AutoSize = true;
            this.lblCheckNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblCheckNumber.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblCheckNumber.Location = new System.Drawing.Point(148, 135);
            this.lblCheckNumber.Name = "lblCheckNumber";
            this.lblCheckNumber.Size = new System.Drawing.Size(95, 16);
            this.lblCheckNumber.TabIndex = 12;
            this.lblCheckNumber.Text = "شماره چك/فیش:";
            this.lblCheckNumber.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX4
            // 
            this.labelX4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelX4.AutoSize = true;
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            this.labelX4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.labelX4.Location = new System.Drawing.Point(392, 82);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(62, 16);
            this.labelX4.TabIndex = 2;
            this.labelX4.Text = "نوع حساب:";
            this.labelX4.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblAccountNumber
            // 
            this.lblAccountNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAccountNumber.AutoSize = true;
            this.lblAccountNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblAccountNumber.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblAccountNumber.Location = new System.Drawing.Point(392, 133);
            this.lblAccountNumber.Name = "lblAccountNumber";
            this.lblAccountNumber.Size = new System.Drawing.Size(79, 16);
            this.lblAccountNumber.TabIndex = 10;
            this.lblAccountNumber.Text = "شماره حساب:";
            this.lblAccountNumber.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // txtBranchCode
            // 
            this.txtBranchCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtBranchCode.Border.Class = "TextBoxBorder";
            this.txtBranchCode.ForeColor = System.Drawing.Color.Navy;
            this.txtBranchCode.Location = new System.Drawing.Point(12, 104);
            this.txtBranchCode.MaxLength = 50;
            this.txtBranchCode.Name = "txtBranchCode";
            this.txtBranchCode.Size = new System.Drawing.Size(131, 21);
            this.txtBranchCode.TabIndex = 9;
            this.txtBranchCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAccountNumber
            // 
            this.txtAccountNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtAccountNumber.Border.Class = "TextBoxBorder";
            this.txtAccountNumber.ForeColor = System.Drawing.Color.Navy;
            this.txtAccountNumber.Location = new System.Drawing.Point(243, 131);
            this.txtAccountNumber.MaxLength = 50;
            this.txtAccountNumber.Name = "txtAccountNumber";
            this.txtAccountNumber.Size = new System.Drawing.Size(142, 21);
            this.txtAccountNumber.TabIndex = 11;
            this.txtAccountNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCheckNumber
            // 
            this.txtCheckNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtCheckNumber.Border.Class = "TextBoxBorder";
            this.txtCheckNumber.ForeColor = System.Drawing.Color.Navy;
            this.txtCheckNumber.Location = new System.Drawing.Point(12, 133);
            this.txtCheckNumber.MaxLength = 50;
            this.txtCheckNumber.Name = "txtCheckNumber";
            this.txtCheckNumber.Size = new System.Drawing.Size(131, 21);
            this.txtCheckNumber.TabIndex = 13;
            this.txtCheckNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            // 
            // PanelTransaction
            // 
            this.PanelTransaction.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelTransaction.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelTransaction.Controls.Add(this.cBox3);
            this.PanelTransaction.Controls.Add(this.cBox2);
            this.PanelTransaction.Controls.Add(this.cBox1);
            this.PanelTransaction.Controls.Add(this.lblTitle);
            this.PanelTransaction.Controls.Add(this.btnAccept);
            this.PanelTransaction.Controls.Add(this.lblInsName);
            this.PanelTransaction.Controls.Add(this.lblBranchName);
            this.PanelTransaction.Controls.Add(this.txtBranchName);
            this.PanelTransaction.Controls.Add(this.txtCheckNumber);
            this.PanelTransaction.Controls.Add(this.btnCancel);
            this.PanelTransaction.Controls.Add(this.txtAccountNumber);
            this.PanelTransaction.Controls.Add(this.txtDescription);
            this.PanelTransaction.Controls.Add(this.txtBranchCode);
            this.PanelTransaction.Controls.Add(this.lblCheckDate);
            this.PanelTransaction.Controls.Add(this.lblAccountNumber);
            this.PanelTransaction.Controls.Add(this.CheckDate);
            this.PanelTransaction.Controls.Add(this.labelX4);
            this.PanelTransaction.Controls.Add(this.lblDescription);
            this.PanelTransaction.Controls.Add(this.lblCheckNumber);
            this.PanelTransaction.Controls.Add(this.lblBranchCode);
            this.PanelTransaction.Controls.Add(this.cboBankName);
            this.PanelTransaction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelTransaction.Location = new System.Drawing.Point(0, 0);
            this.PanelTransaction.Name = "PanelTransaction";
            this.PanelTransaction.Size = new System.Drawing.Size(476, 301);
            // 
            // 
            // 
            this.PanelTransaction.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.PanelTransaction.Style.BackColorGradientAngle = 90;
            this.PanelTransaction.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.PanelTransaction.Style.BorderBottomWidth = 1;
            this.PanelTransaction.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.PanelTransaction.Style.BorderLeftWidth = 1;
            this.PanelTransaction.Style.BorderRightWidth = 1;
            this.PanelTransaction.Style.BorderTopWidth = 1;
            this.PanelTransaction.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.PanelTransaction.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.PanelTransaction.TabIndex = 0;
            // 
            // cBox3
            // 
            this.cBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBox3.AutoSize = true;
            this.cBox3.BackColor = System.Drawing.Color.Transparent;
            this.cBox3.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.cBox3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBox3.Location = new System.Drawing.Point(166, 82);
            this.cBox3.Name = "cBox3";
            this.cBox3.Size = new System.Drawing.Size(92, 16);
            this.cBox3.TabIndex = 5;
            this.cBox3.Text = "قرض الحسنه";
            // 
            // cBox2
            // 
            this.cBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBox2.AutoSize = true;
            this.cBox2.BackColor = System.Drawing.Color.Transparent;
            this.cBox2.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.cBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBox2.Location = new System.Drawing.Point(264, 82);
            this.cBox2.Name = "cBox2";
            this.cBox2.Size = new System.Drawing.Size(67, 16);
            this.cBox2.TabIndex = 4;
            this.cBox2.Text = "پس انداز";
            // 
            // cBox1
            // 
            this.cBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBox1.AutoSize = true;
            this.cBox1.BackColor = System.Drawing.Color.Transparent;
            this.cBox1.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.cBox1.Checked = true;
            this.cBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBox1.CheckValue = "Y";
            this.cBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBox1.Location = new System.Drawing.Point(337, 82);
            this.cBox1.Name = "cBox1";
            this.cBox1.Size = new System.Drawing.Size(50, 16);
            this.cBox1.TabIndex = 3;
            this.cBox1.Text = "جاری";
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("B Yekan", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(476, 49);
            this.lblTitle.TabIndex = 20;
            this.lblTitle.Text = "سایر اطلاعات تراكنش";
            this.lblTitle.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // btnAccept
            // 
            this.btnAccept.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAccept.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAccept.Image = global::Sepehr.Forms.Account.Properties.Resources.Accept;
            this.btnAccept.Location = new System.Drawing.Point(12, 229);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnAccept.Size = new System.Drawing.Size(95, 60);
            this.btnAccept.TabIndex = 18;
            this.btnAccept.Text = "اعمال\r\n(F8)";
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Sepehr.Forms.Account.Properties.Resources.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(113, 229);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 60);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "انصراف\r\n(Esc)";
            // 
            // frmManageTransDesc
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(476, 301);
            this.Controls.Add(this.PanelTransaction);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManageTransDesc";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "بیماران - مراجعات - حساب - تراكنش - سایر اطلاعات";
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.PanelTransaction.ResumeLayout(false);
            this.PanelTransaction.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public Negar.PersianCalendar.UI.Controls.PersianDatePicker CheckDate;
        internal DevComponents.DotNetBar.Controls.TextBoxX txtDescription;
        internal DevComponents.DotNetBar.Controls.TextBoxX txtBranchName;
        internal DevComponents.DotNetBar.Controls.ComboBoxEx cboBankName;
        internal DevComponents.DotNetBar.Controls.TextBoxX txtBranchCode;
        internal DevComponents.DotNetBar.Controls.TextBoxX txtAccountNumber;
        internal DevComponents.DotNetBar.Controls.TextBoxX txtCheckNumber;
        internal DevComponents.DotNetBar.Controls.CheckBoxX cBox3;
        internal DevComponents.DotNetBar.Controls.CheckBoxX cBox2;
        internal DevComponents.DotNetBar.Controls.CheckBoxX cBox1;
        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel PanelTransaction;
        private DevComponents.DotNetBar.LabelX lblTitle;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.LabelX lblDescription;
        private DevComponents.DotNetBar.LabelX lblCheckDate;
        private DevComponents.DotNetBar.LabelX lblBranchName;
        private DevComponents.DotNetBar.LabelX lblInsName;
        private DevComponents.DotNetBar.LabelX lblBranchCode;
        private DevComponents.DotNetBar.LabelX lblCheckNumber;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX lblAccountNumber;
        private DevComponents.DotNetBar.ButtonX btnAccept;
    }
}