namespace Sepehr.Settings.SMS
{
    partial class frmDocCompleteMessage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDocCompleteMessage));
            this.FormPanel = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.cboTemplateSelection = new System.Windows.Forms.ComboBox();
            this.lblTitle = new DevComponents.DotNetBar.LabelX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnHelp = new DevComponents.DotNetBar.ButtonX();
            this.txtCharCount = new DevComponents.DotNetBar.LabelX();
            this.lblCharCount = new DevComponents.DotNetBar.LabelX();
            this.lblTemplateSelection = new DevComponents.DotNetBar.LabelX();
            this.lblFormulaText = new DevComponents.DotNetBar.LabelX();
            this.txtFormulaText = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnAccept = new DevComponents.DotNetBar.ButtonX();
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.FormPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // FormPanel
            // 
            this.FormPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.FormPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.FormPanel.Controls.Add(this.cboTemplateSelection);
            this.FormPanel.Controls.Add(this.lblTitle);
            this.FormPanel.Controls.Add(this.btnCancel);
            this.FormPanel.Controls.Add(this.btnHelp);
            this.FormPanel.Controls.Add(this.txtCharCount);
            this.FormPanel.Controls.Add(this.lblCharCount);
            this.FormPanel.Controls.Add(this.lblTemplateSelection);
            this.FormPanel.Controls.Add(this.lblFormulaText);
            this.FormPanel.Controls.Add(this.txtFormulaText);
            this.FormPanel.Controls.Add(this.btnAccept);
            this.FormPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormPanel.Location = new System.Drawing.Point(0, 0);
            this.FormPanel.Name = "FormPanel";
            this.FormPanel.Size = new System.Drawing.Size(310, 238);
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
            // cboTemplateSelection
            // 
            this.cboTemplateSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTemplateSelection.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cboTemplateSelection.FormattingEnabled = true;
            this.cboTemplateSelection.Items.AddRange(new object[] {
            "قالب 1",
            "قالب 2",
            "قالب 3",
            "فالب 4",
            "قالب 5"});
            this.cboTemplateSelection.Location = new System.Drawing.Point(153, 45);
            this.cboTemplateSelection.Name = "cboTemplateSelection";
            this.cboTemplateSelection.Size = new System.Drawing.Size(92, 21);
            this.cboTemplateSelection.TabIndex = 8;
            this.cboTemplateSelection.SelectedIndexChanged += new System.EventHandler(this.cboTemplateSelection_SelectedIndexChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("B Yekan", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(310, 39);
            this.lblTitle.TabIndex = 7;
            this.lblTitle.Text = "قالب متن پیام آماده بودن گزارش";
            this.lblTitle.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Sepehr.Settings.SMS.Properties.Resources.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(108, 169);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 57);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "انصراف\r\n(Esc)";
            // 
            // btnHelp
            // 
            this.btnHelp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnHelp.Image = global::Sepehr.Settings.SMS.Properties.Resources.Help;
            this.btnHelp.Location = new System.Drawing.Point(208, 169);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F1);
            this.btnHelp.Size = new System.Drawing.Size(90, 57);
            this.btnHelp.TabIndex = 4;
            this.btnHelp.TabStop = false;
            this.btnHelp.Text = "راهنما\r\n(F1)";
            this.btnHelp.Visible = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // txtCharCount
            // 
            this.txtCharCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCharCount.AutoSize = true;
            this.txtCharCount.BackColor = System.Drawing.Color.Transparent;
            this.txtCharCount.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtCharCount.ForeColor = System.Drawing.Color.ForestGreen;
            this.txtCharCount.Location = new System.Drawing.Point(247, 144);
            this.txtCharCount.Name = "txtCharCount";
            this.txtCharCount.Size = new System.Drawing.Size(10, 16);
            this.txtCharCount.TabIndex = 5;
            this.txtCharCount.Text = "0";
            // 
            // lblCharCount
            // 
            this.lblCharCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCharCount.AutoSize = true;
            this.lblCharCount.BackColor = System.Drawing.Color.Transparent;
            this.lblCharCount.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblCharCount.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblCharCount.Location = new System.Drawing.Point(269, 144);
            this.lblCharCount.Name = "lblCharCount";
            this.lblCharCount.Size = new System.Drawing.Size(37, 16);
            this.lblCharCount.TabIndex = 5;
            this.lblCharCount.Text = "حروف:";
            // 
            // lblTemplateSelection
            // 
            this.lblTemplateSelection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTemplateSelection.AutoSize = true;
            this.lblTemplateSelection.BackColor = System.Drawing.Color.Transparent;
            this.lblTemplateSelection.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTemplateSelection.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblTemplateSelection.Location = new System.Drawing.Point(252, 47);
            this.lblTemplateSelection.Name = "lblTemplateSelection";
            this.lblTemplateSelection.Size = new System.Drawing.Size(31, 16);
            this.lblTemplateSelection.TabIndex = 5;
            this.lblTemplateSelection.Text = "قالب:";
            // 
            // lblFormulaText
            // 
            this.lblFormulaText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFormulaText.AutoSize = true;
            this.lblFormulaText.BackColor = System.Drawing.Color.Transparent;
            this.lblFormulaText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblFormulaText.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblFormulaText.Location = new System.Drawing.Point(252, 73);
            this.lblFormulaText.Name = "lblFormulaText";
            this.lblFormulaText.Size = new System.Drawing.Size(39, 16);
            this.lblFormulaText.TabIndex = 5;
            this.lblFormulaText.Text = "فرمول:";
            // 
            // txtFormulaText
            // 
            this.txtFormulaText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtFormulaText.Border.Class = "TextBoxBorder";
            this.txtFormulaText.Location = new System.Drawing.Point(13, 73);
            this.txtFormulaText.MaxLength = 300;
            this.txtFormulaText.Multiline = true;
            this.txtFormulaText.Name = "txtFormulaText";
            this.txtFormulaText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtFormulaText.Size = new System.Drawing.Size(232, 87);
            this.txtFormulaText.TabIndex = 1;
            this.txtFormulaText.TextChanged += new System.EventHandler(this.txtFormulaText_TextChanged);
            // 
            // btnAccept
            // 
            this.btnAccept.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAccept.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAccept.Image = global::Sepehr.Settings.SMS.Properties.Resources.Accept;
            this.btnAccept.Location = new System.Drawing.Point(12, 169);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnAccept.Size = new System.Drawing.Size(90, 57);
            this.btnAccept.TabIndex = 2;
            this.btnAccept.TabStop = false;
            this.btnAccept.Text = "ثبت\r\n(F8)";
            this.btnAccept.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            // 
            // frmDocCompleteMessage
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(310, 238);
            this.Controls.Add(this.FormPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDocCompleteMessage";
            this.Opacity = 0.01;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تنظیمات - پیام كوتاه - قالب متن پیام آماده بودن ریپورت";
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.FormPanel.ResumeLayout(false);
            this.FormPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel FormPanel;
        internal DevComponents.DotNetBar.ButtonX btnAccept;
        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        private DevComponents.DotNetBar.LabelX lblFormulaText;
        internal DevComponents.DotNetBar.ButtonX btnHelp;
        private DevComponents.DotNetBar.Controls.TextBoxX txtFormulaText;
        internal DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.LabelX lblTitle;
        private DevComponents.DotNetBar.LabelX lblCharCount;
        private DevComponents.DotNetBar.LabelX txtCharCount;
        private DevComponents.DotNetBar.LabelX lblTemplateSelection;
        private System.Windows.Forms.ComboBox cboTemplateSelection;
    }
}