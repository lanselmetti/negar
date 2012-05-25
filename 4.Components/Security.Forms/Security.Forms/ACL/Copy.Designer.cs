namespace Negar.Security.ACL
{
    partial class frmCopy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCopy));
            this.FormPanel = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.cBoxSelectGroups = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cBoxSelectUsers = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.lstGroups = new DevComponents.DotNetBar.ItemPanel();
            this.lstUsers = new DevComponents.DotNetBar.ItemPanel();
            this.lblDestinationGroups = new DevComponents.DotNetBar.LabelX();
            this.lblDestinationUsers = new DevComponents.DotNetBar.LabelX();
            this.cboSelection = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnCopyUserACL = new DevComponents.DotNetBar.ButtonX();
            this.btnHelp = new DevComponents.DotNetBar.ButtonX();
            this.FormPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // FormPanel
            // 
            this.FormPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.FormPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.FormPanel.Controls.Add(this.cBoxSelectGroups);
            this.FormPanel.Controls.Add(this.cBoxSelectUsers);
            this.FormPanel.Controls.Add(this.lstGroups);
            this.FormPanel.Controls.Add(this.lstUsers);
            this.FormPanel.Controls.Add(this.lblDestinationGroups);
            this.FormPanel.Controls.Add(this.lblDestinationUsers);
            this.FormPanel.Controls.Add(this.cboSelection);
            this.FormPanel.Controls.Add(this.btnCopyUserACL);
            this.FormPanel.Controls.Add(this.btnClose);
            this.FormPanel.Controls.Add(this.btnHelp);
            this.FormPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormPanel.Location = new System.Drawing.Point(0, 0);
            this.FormPanel.Name = "FormPanel";
            this.FormPanel.Size = new System.Drawing.Size(428, 436);
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
            // cBoxSelectGroups
            // 
            this.cBoxSelectGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxSelectGroups.AutoSize = true;
            this.cBoxSelectGroups.BackColor = System.Drawing.Color.Transparent;
            this.cBoxSelectGroups.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.cBoxSelectGroups.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxSelectGroups.Location = new System.Drawing.Point(245, 12);
            this.cBoxSelectGroups.Name = "cBoxSelectGroups";
            this.cBoxSelectGroups.Size = new System.Drawing.Size(83, 16);
            this.cBoxSelectGroups.TabIndex = 1;
            this.cBoxSelectGroups.Text = "انتخاب گروه";
            this.cBoxSelectGroups.TextColor = System.Drawing.Color.Green;
            // 
            // cBoxSelectUsers
            // 
            this.cBoxSelectUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxSelectUsers.AutoSize = true;
            this.cBoxSelectUsers.BackColor = System.Drawing.Color.Transparent;
            this.cBoxSelectUsers.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.cBoxSelectUsers.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxSelectUsers.Location = new System.Drawing.Point(333, 12);
            this.cBoxSelectUsers.Name = "cBoxSelectUsers";
            this.cBoxSelectUsers.Size = new System.Drawing.Size(84, 16);
            this.cBoxSelectUsers.TabIndex = 0;
            this.cBoxSelectUsers.Text = "انتخاب كاربر";
            this.cBoxSelectUsers.TextColor = System.Drawing.Color.Green;
            this.cBoxSelectUsers.CheckedChanged += new System.EventHandler(this.cBoxSelectUsers_CheckedChanged);
            // 
            // lstGroups
            // 
            this.lstGroups.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstGroups.AutoScroll = true;
            // 
            // 
            // 
            this.lstGroups.BackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.lstGroups.BackgroundStyle.BackColorGradientAngle = 90;
            this.lstGroups.BackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.lstGroups.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lstGroups.BackgroundStyle.BorderBottomWidth = 1;
            this.lstGroups.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.lstGroups.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lstGroups.BackgroundStyle.BorderLeftWidth = 1;
            this.lstGroups.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lstGroups.BackgroundStyle.BorderRightWidth = 1;
            this.lstGroups.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lstGroups.BackgroundStyle.BorderTopWidth = 1;
            this.lstGroups.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lstGroups.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.lstGroups.Location = new System.Drawing.Point(13, 54);
            this.lstGroups.Name = "lstGroups";
            this.lstGroups.Size = new System.Drawing.Size(198, 307);
            this.lstGroups.TabIndex = 6;
            this.lstGroups.TabStop = false;
            // 
            // lstUsers
            // 
            this.lstUsers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstUsers.AutoScroll = true;
            // 
            // 
            // 
            this.lstUsers.BackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.lstUsers.BackgroundStyle.BackColorGradientAngle = 90;
            this.lstUsers.BackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.lstUsers.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lstUsers.BackgroundStyle.BorderBottomWidth = 1;
            this.lstUsers.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.lstUsers.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lstUsers.BackgroundStyle.BorderLeftWidth = 1;
            this.lstUsers.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lstUsers.BackgroundStyle.BorderRightWidth = 1;
            this.lstUsers.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lstUsers.BackgroundStyle.BorderTopWidth = 1;
            this.lstUsers.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lstUsers.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.lstUsers.Location = new System.Drawing.Point(217, 54);
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(198, 307);
            this.lstUsers.TabIndex = 4;
            this.lstUsers.TabStop = false;
            // 
            // lblDestinationGroups
            // 
            this.lblDestinationGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDestinationGroups.AutoSize = true;
            this.lblDestinationGroups.BackColor = System.Drawing.Color.Transparent;
            this.lblDestinationGroups.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblDestinationGroups.Location = new System.Drawing.Point(162, 36);
            this.lblDestinationGroups.Name = "lblDestinationGroups";
            this.lblDestinationGroups.Size = new System.Drawing.Size(46, 16);
            this.lblDestinationGroups.TabIndex = 5;
            this.lblDestinationGroups.Text = "گروه ها:";
            this.lblDestinationGroups.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblDestinationUsers
            // 
            this.lblDestinationUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDestinationUsers.AutoSize = true;
            this.lblDestinationUsers.BackColor = System.Drawing.Color.Transparent;
            this.lblDestinationUsers.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblDestinationUsers.Location = new System.Drawing.Point(373, 36);
            this.lblDestinationUsers.Name = "lblDestinationUsers";
            this.lblDestinationUsers.Size = new System.Drawing.Size(43, 16);
            this.lblDestinationUsers.TabIndex = 3;
            this.lblDestinationUsers.Text = "كاربران:";
            this.lblDestinationUsers.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // cboSelection
            // 
            this.cboSelection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSelection.DisplayMember = "Text";
            this.cboSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSelection.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.cboSelection.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cboSelection.FormattingEnabled = true;
            this.cboSelection.ItemHeight = 13;
            this.cboSelection.Location = new System.Drawing.Point(15, 10);
            this.cboSelection.Name = "cboSelection";
            this.cboSelection.Size = new System.Drawing.Size(224, 21);
            this.cboSelection.TabIndex = 2;
            this.cboSelection.WatermarkText = "یك گروه از لیست انتخاب نمایید...";
            this.cboSelection.SelectedIndexChanged += new System.EventHandler(this.cboSelection_SelectedIndexChanged);
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = global::Negar.Security.Properties.Resources.Cancel;
            this.btnClose.Location = new System.Drawing.Point(113, 367);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 57);
            this.btnClose.TabIndex = 8;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "خروج\r\n(Esc)";
            // 
            // btnCopyUserACL
            // 
            this.btnCopyUserACL.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCopyUserACL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCopyUserACL.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCopyUserACL.Image = global::Negar.Security.Properties.Resources.Accept;
            this.btnCopyUserACL.Location = new System.Drawing.Point(12, 367);
            this.btnCopyUserACL.Name = "btnCopyUserACL";
            this.btnCopyUserACL.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnCopyUserACL.Size = new System.Drawing.Size(95, 57);
            this.btnCopyUserACL.TabIndex = 7;
            this.btnCopyUserACL.TabStop = false;
            this.btnCopyUserACL.Text = "اجرا (F8)";
            this.btnCopyUserACL.Click += new System.EventHandler(this.btnCopyUserACL_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnHelp.Image = global::Negar.Security.Properties.Resources.Help;
            this.btnHelp.Location = new System.Drawing.Point(321, 367);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F1);
            this.btnHelp.Size = new System.Drawing.Size(95, 57);
            this.btnHelp.TabIndex = 9;
            this.btnHelp.TabStop = false;
            this.btnHelp.Text = "راهنما\r\n(F1)";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // frmCopy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(428, 436);
            this.Controls.Add(this.FormPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCopy";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "مديريت امنيت سيستم - كپی دسترسی های كاربران و گروه ها";
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.FormPanel.ResumeLayout(false);
            this.FormPanel.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel FormPanel;
        private DevComponents.DotNetBar.ButtonX btnHelp;
        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboSelection;
        private DevComponents.DotNetBar.ItemPanel lstGroups;
        private DevComponents.DotNetBar.ItemPanel lstUsers;
        private DevComponents.DotNetBar.LabelX lblDestinationGroups;
        private DevComponents.DotNetBar.LabelX lblDestinationUsers;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.ButtonX btnCopyUserACL;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxSelectGroups;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxSelectUsers;
    }
}