namespace Sepehr.Settings.Insurances.Insurances
{
    partial class frmInsManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInsManage));
            this.FormPanel = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.txtPatientPercent = new DevComponents.Editors.IntegerInput();
            this.txtInsPartLimit = new DevComponents.Editors.IntegerInput();
            this.cboIns2Formula = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.btnHelp = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnAccept = new DevComponents.DotNetBar.ButtonX();
            this.cBoxIsIns2 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cBoxIsIns1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cBoxActive = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.lblTitle = new DevComponents.DotNetBar.LabelX();
            this.lblDescription = new DevComponents.DotNetBar.LabelX();
            this.lblIns2Formula = new DevComponents.DotNetBar.LabelX();
            this.lblInsName = new DevComponents.DotNetBar.LabelX();
            this.DateExpiration = new Negar.PersianCalendar.UI.Controls.PersianDatePicker();
            this.DateContract = new Negar.PersianCalendar.UI.Controls.PersianDatePicker();
            this.txtDescription = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtInsName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblContractDate = new DevComponents.DotNetBar.LabelX();
            this.lblPatientPercent = new DevComponents.DotNetBar.LabelX();
            this.lblInsPartLimit = new DevComponents.DotNetBar.LabelX();
            this.lblInsExpireDate = new DevComponents.DotNetBar.LabelX();
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.ErrorManager = new System.Windows.Forms.ErrorProvider(this.components);
            this.FormPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPatientPercent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInsPartLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorManager)).BeginInit();
            this.SuspendLayout();
            // 
            // FormPanel
            // 
            this.FormPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.FormPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.FormPanel.Controls.Add(this.txtPatientPercent);
            this.FormPanel.Controls.Add(this.txtInsPartLimit);
            this.FormPanel.Controls.Add(this.cboIns2Formula);
            this.FormPanel.Controls.Add(this.btnHelp);
            this.FormPanel.Controls.Add(this.btnCancel);
            this.FormPanel.Controls.Add(this.btnAccept);
            this.FormPanel.Controls.Add(this.cBoxIsIns2);
            this.FormPanel.Controls.Add(this.cBoxIsIns1);
            this.FormPanel.Controls.Add(this.cBoxActive);
            this.FormPanel.Controls.Add(this.lblTitle);
            this.FormPanel.Controls.Add(this.lblDescription);
            this.FormPanel.Controls.Add(this.lblIns2Formula);
            this.FormPanel.Controls.Add(this.lblInsName);
            this.FormPanel.Controls.Add(this.DateExpiration);
            this.FormPanel.Controls.Add(this.DateContract);
            this.FormPanel.Controls.Add(this.txtDescription);
            this.FormPanel.Controls.Add(this.txtInsName);
            this.FormPanel.Controls.Add(this.lblContractDate);
            this.FormPanel.Controls.Add(this.lblPatientPercent);
            this.FormPanel.Controls.Add(this.lblInsPartLimit);
            this.FormPanel.Controls.Add(this.lblInsExpireDate);
            this.FormPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormPanel.Location = new System.Drawing.Point(0, 0);
            this.FormPanel.Name = "FormPanel";
            this.FormPanel.Size = new System.Drawing.Size(402, 326);
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
            // txtPatientPercent
            // 
            this.txtPatientPercent.AllowEmptyState = false;
            this.txtPatientPercent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtPatientPercent.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtPatientPercent.DisplayFormat = "# \'%\'";
            this.txtPatientPercent.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtPatientPercent.Location = new System.Drawing.Point(240, 127);
            this.txtPatientPercent.MaxValue = 100;
            this.txtPatientPercent.MinValue = 0;
            this.txtPatientPercent.Name = "txtPatientPercent";
            this.txtPatientPercent.ShowUpDown = true;
            this.txtPatientPercent.Size = new System.Drawing.Size(59, 21);
            this.txtPatientPercent.TabIndex = 3;
            // 
            // txtInsPartLimit
            // 
            this.txtInsPartLimit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtInsPartLimit.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtInsPartLimit.ButtonClear.Visible = true;
            this.txtInsPartLimit.DisplayFormat = "N0";
            this.txtInsPartLimit.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtInsPartLimit.Location = new System.Drawing.Point(12, 127);
            this.txtInsPartLimit.MaxValue = 99999999;
            this.txtInsPartLimit.MinValue = 0;
            this.txtInsPartLimit.Name = "txtInsPartLimit";
            this.txtInsPartLimit.ShowUpDown = true;
            this.txtInsPartLimit.Size = new System.Drawing.Size(99, 21);
            this.txtInsPartLimit.TabIndex = 4;
            // 
            // cboIns2Formula
            // 
            this.cboIns2Formula.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboIns2Formula.DisplayMember = "Name";
            this.cboIns2Formula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIns2Formula.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.cboIns2Formula.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cboIns2Formula.FormattingEnabled = true;
            this.cboIns2Formula.ItemHeight = 13;
            this.cboIns2Formula.Location = new System.Drawing.Point(90, 176);
            this.cboIns2Formula.Name = "cboIns2Formula";
            this.cboIns2Formula.Size = new System.Drawing.Size(211, 21);
            this.cboIns2Formula.TabIndex = 14;
            this.cboIns2Formula.ValueMember = "ID";
            this.cboIns2Formula.WatermarkText = "یك گروه از لیست انتخاب نمایید...";
            // 
            // btnHelp
            // 
            this.btnHelp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnHelp.Image = global::Sepehr.Settings.Insurances.Properties.Resources.Help;
            this.btnHelp.Location = new System.Drawing.Point(301, 257);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F1);
            this.btnHelp.Size = new System.Drawing.Size(95, 57);
            this.btnHelp.TabIndex = 18;
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
            this.btnCancel.Location = new System.Drawing.Point(113, 257);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 57);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "انصراف\r\n(Esc)";
            // 
            // btnAccept
            // 
            this.btnAccept.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAccept.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAccept.Image = global::Sepehr.Settings.Insurances.Properties.Resources.Accept;
            this.btnAccept.Location = new System.Drawing.Point(12, 257);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnAccept.Size = new System.Drawing.Size(95, 57);
            this.btnAccept.TabIndex = 16;
            this.btnAccept.TabStop = false;
            this.btnAccept.Text = "تایید\r\n(F8)";
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // cBoxIsIns2
            // 
            this.cBoxIsIns2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxIsIns2.AutoSize = true;
            this.cBoxIsIns2.BackColor = System.Drawing.Color.Transparent;
            this.cBoxIsIns2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxIsIns2.Location = new System.Drawing.Point(90, 154);
            this.cBoxIsIns2.Name = "cBoxIsIns2";
            this.cBoxIsIns2.Size = new System.Drawing.Size(68, 16);
            this.cBoxIsIns2.TabIndex = 6;
            this.cBoxIsIns2.Text = "بیمه دوم";
            this.cBoxIsIns2.TextColor = System.Drawing.Color.Green;
            // 
            // cBoxIsIns1
            // 
            this.cBoxIsIns1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxIsIns1.AutoSize = true;
            this.cBoxIsIns1.BackColor = System.Drawing.Color.Transparent;
            this.cBoxIsIns1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxIsIns1.Location = new System.Drawing.Point(236, 154);
            this.cBoxIsIns1.Name = "cBoxIsIns1";
            this.cBoxIsIns1.Size = new System.Drawing.Size(66, 16);
            this.cBoxIsIns1.TabIndex = 5;
            this.cBoxIsIns1.Text = "بیمه اول";
            // 
            // cBoxActive
            // 
            this.cBoxActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxActive.AutoSize = true;
            this.cBoxActive.BackColor = System.Drawing.Color.Transparent;
            this.cBoxActive.Checked = true;
            this.cBoxActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBoxActive.CheckValue = "Y";
            this.cBoxActive.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxActive.Location = new System.Drawing.Point(255, 51);
            this.cBoxActive.Name = "cBoxActive";
            this.cBoxActive.Size = new System.Drawing.Size(47, 16);
            this.cBoxActive.TabIndex = 26;
            this.cBoxActive.Text = "فعال";
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("B Yekan", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(402, 45);
            this.lblTitle.TabIndex = 28;
            this.lblTitle.Text = "مدیریت بیمه های تصویربرداری";
            this.lblTitle.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblDescription.Location = new System.Drawing.Point(306, 204);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(73, 16);
            this.lblDescription.TabIndex = 19;
            this.lblDescription.Text = "توضیحات:";
            this.lblDescription.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblIns2Formula
            // 
            this.lblIns2Formula.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIns2Formula.BackColor = System.Drawing.Color.Transparent;
            this.lblIns2Formula.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblIns2Formula.ForeColor = System.Drawing.Color.Green;
            this.lblIns2Formula.Location = new System.Drawing.Point(306, 178);
            this.lblIns2Formula.Name = "lblIns2Formula";
            this.lblIns2Formula.Size = new System.Drawing.Size(91, 16);
            this.lblIns2Formula.TabIndex = 20;
            this.lblIns2Formula.Text = "فرمول بیمه دوم:";
            this.lblIns2Formula.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblInsName
            // 
            this.lblInsName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInsName.AutoSize = true;
            this.lblInsName.BackColor = System.Drawing.Color.Transparent;
            this.lblInsName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblInsName.Location = new System.Drawing.Point(306, 75);
            this.lblInsName.Name = "lblInsName";
            this.lblInsName.Size = new System.Drawing.Size(47, 16);
            this.lblInsName.TabIndex = 25;
            this.lblInsName.Text = "نام بیمه:";
            this.lblInsName.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // DateExpiration
            // 
            this.DateExpiration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DateExpiration.IsPopupOpen = false;
            this.DateExpiration.Location = new System.Drawing.Point(12, 100);
            this.DateExpiration.Name = "DateExpiration";
            this.DateExpiration.SelectedDateTime = new System.DateTime(2010, 2, 23, 12, 24, 59, 198);
            this.DateExpiration.Size = new System.Drawing.Size(85, 21);
            this.DateExpiration.TabIndex = 2;
            // 
            // DateContract
            // 
            this.DateContract.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DateContract.IsPopupOpen = false;
            this.DateContract.Location = new System.Drawing.Point(216, 100);
            this.DateContract.Name = "DateContract";
            this.DateContract.SelectedDateTime = new System.DateTime(2010, 2, 23, 12, 24, 59, 231);
            this.DateContract.Size = new System.Drawing.Size(83, 21);
            this.DateContract.TabIndex = 1;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtDescription.Border.Class = "TextBoxBorder";
            this.txtDescription.Location = new System.Drawing.Point(12, 204);
            this.txtDescription.MaxLength = 300;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(289, 44);
            this.txtDescription.TabIndex = 15;
            // 
            // txtInsName
            // 
            this.txtInsName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtInsName.Border.Class = "TextBoxBorder";
            this.txtInsName.Location = new System.Drawing.Point(12, 73);
            this.txtInsName.MaxLength = 50;
            this.txtInsName.Name = "txtInsName";
            this.txtInsName.Size = new System.Drawing.Size(287, 21);
            this.txtInsName.TabIndex = 0;
            // 
            // lblContractDate
            // 
            this.lblContractDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblContractDate.AutoSize = true;
            this.lblContractDate.BackColor = System.Drawing.Color.Transparent;
            this.lblContractDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblContractDate.Location = new System.Drawing.Point(306, 102);
            this.lblContractDate.Name = "lblContractDate";
            this.lblContractDate.Size = new System.Drawing.Size(93, 16);
            this.lblContractDate.TabIndex = 24;
            this.lblContractDate.Text = "تاریخ آغاز قرارداد:";
            this.lblContractDate.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblPatientPercent
            // 
            this.lblPatientPercent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPatientPercent.AutoSize = true;
            this.lblPatientPercent.BackColor = System.Drawing.Color.Transparent;
            this.lblPatientPercent.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblPatientPercent.Location = new System.Drawing.Point(306, 129);
            this.lblPatientPercent.Name = "lblPatientPercent";
            this.lblPatientPercent.Size = new System.Drawing.Size(91, 16);
            this.lblPatientPercent.TabIndex = 22;
            this.lblPatientPercent.Text = "درصد سهم بیمار:";
            this.lblPatientPercent.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblInsPartLimit
            // 
            this.lblInsPartLimit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInsPartLimit.AutoSize = true;
            this.lblInsPartLimit.BackColor = System.Drawing.Color.Transparent;
            this.lblInsPartLimit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblInsPartLimit.Location = new System.Drawing.Point(118, 129);
            this.lblInsPartLimit.Name = "lblInsPartLimit";
            this.lblInsPartLimit.Size = new System.Drawing.Size(121, 16);
            this.lblInsPartLimit.TabIndex = 21;
            this.lblInsPartLimit.Text = "سقف تعهد هر مراجعه:";
            this.lblInsPartLimit.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblInsExpireDate
            // 
            this.lblInsExpireDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInsExpireDate.AutoSize = true;
            this.lblInsExpireDate.BackColor = System.Drawing.Color.Transparent;
            this.lblInsExpireDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblInsExpireDate.Location = new System.Drawing.Point(109, 102);
            this.lblInsExpireDate.Name = "lblInsExpireDate";
            this.lblInsExpireDate.Size = new System.Drawing.Size(99, 16);
            this.lblInsExpireDate.TabIndex = 23;
            this.lblInsExpireDate.Text = "تاریخ اتمام قرارداد:";
            this.lblInsExpireDate.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormToolTip.TooltipDuration = 25;
            // 
            // ErrorManager
            // 
            this.ErrorManager.BlinkRate = 300;
            this.ErrorManager.ContainerControl = this;
            this.ErrorManager.RightToLeft = true;
            // 
            // frmInsManage
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(402, 326);
            this.Controls.Add(this.FormPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInsManage";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تنظیمات - مراجعات - بیمه ها - فرم مدیریت بیمه های تصویربرداری";
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.FormPanel.ResumeLayout(false);
            this.FormPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPatientPercent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInsPartLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel FormPanel;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxActive;
        private DevComponents.DotNetBar.LabelX lblTitle;
        private DevComponents.DotNetBar.LabelX lblInsName;
        private Negar.PersianCalendar.UI.Controls.PersianDatePicker DateContract;
        private DevComponents.DotNetBar.Controls.TextBoxX txtInsName;
        private DevComponents.DotNetBar.LabelX lblContractDate;
        private DevComponents.DotNetBar.LabelX lblPatientPercent;
        internal DevComponents.DotNetBar.ButtonX btnHelp;
        internal DevComponents.DotNetBar.ButtonX btnCancel;
        internal DevComponents.DotNetBar.ButtonX btnAccept;
        private Negar.PersianCalendar.UI.Controls.PersianDatePicker DateExpiration;
        private DevComponents.DotNetBar.LabelX lblInsExpireDate;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxIsIns1;
        private DevComponents.DotNetBar.LabelX lblInsPartLimit;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxIsIns2;
        private DevComponents.DotNetBar.LabelX lblDescription;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDescription;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboIns2Formula;
        private DevComponents.DotNetBar.LabelX lblIns2Formula;
        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        private System.Windows.Forms.ErrorProvider ErrorManager;
        private DevComponents.Editors.IntegerInput txtInsPartLimit;
        private DevComponents.Editors.IntegerInput txtPatientPercent;
    }
}