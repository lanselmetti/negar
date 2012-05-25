namespace Sepehr.Settings.Schedules.Applications
{
    partial class frmAppsBaseEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAppsBaseEdit));
            this.FormPanel = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.lblTitle = new DevComponents.DotNetBar.LabelX();
            this.cBoxIsActive = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.lblAppName = new DevComponents.DotNetBar.LabelX();
            this.txtAppName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblDescription = new DevComponents.DotNetBar.LabelX();
            this.txtDescription = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnAccept = new DevComponents.DotNetBar.ButtonX();
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.FormErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.FormPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FormErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // FormPanel
            // 
            this.FormPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.FormPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.FormPanel.Controls.Add(this.lblTitle);
            this.FormPanel.Controls.Add(this.cBoxIsActive);
            this.FormPanel.Controls.Add(this.lblAppName);
            this.FormPanel.Controls.Add(this.txtAppName);
            this.FormPanel.Controls.Add(this.lblDescription);
            this.FormPanel.Controls.Add(this.txtDescription);
            this.FormPanel.Controls.Add(this.btnCancel);
            this.FormPanel.Controls.Add(this.btnAccept);
            this.FormPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormPanel.Location = new System.Drawing.Point(0, 0);
            this.FormPanel.Name = "FormPanel";
            this.FormPanel.Size = new System.Drawing.Size(321, 181);
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
            this.lblTitle.Font = new System.Drawing.Font("B Yekan", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(321, 48);
            this.lblTitle.TabIndex = 7;
            this.lblTitle.Text = "ویرایش اطلاعات پایه برنامه نوبت دهی";
            this.lblTitle.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // cBoxIsActive
            // 
            this.cBoxIsActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxIsActive.AutoSize = true;
            this.cBoxIsActive.BackColor = System.Drawing.Color.Transparent;
            this.cBoxIsActive.Checked = true;
            this.cBoxIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBoxIsActive.CheckValue = "Y";
            this.cBoxIsActive.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxIsActive.Location = new System.Drawing.Point(261, 54);
            this.cBoxIsActive.Name = "cBoxIsActive";
            this.cBoxIsActive.Size = new System.Drawing.Size(47, 16);
            this.cBoxIsActive.TabIndex = 4;
            this.cBoxIsActive.Tag = "ctrl";
            this.cBoxIsActive.Text = "فعال";
            this.cBoxIsActive.TextColor = System.Drawing.Color.Purple;
            // 
            // lblAppName
            // 
            this.lblAppName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAppName.AutoSize = true;
            this.lblAppName.BackColor = System.Drawing.Color.Transparent;
            this.lblAppName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblAppName.Location = new System.Drawing.Point(201, 54);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(55, 16);
            this.lblAppName.TabIndex = 6;
            this.lblAppName.Text = "نام برنامه:";
            this.lblAppName.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // txtAppName
            // 
            this.txtAppName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtAppName.Border.Class = "TextBoxBorder";
            this.txtAppName.Location = new System.Drawing.Point(12, 52);
            this.txtAppName.MaxLength = 50;
            this.txtAppName.Name = "txtAppName";
            this.txtAppName.Size = new System.Drawing.Size(181, 21);
            this.txtAppName.TabIndex = 0;
            this.txtAppName.Tag = "ctrl";
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescription.AutoSize = true;
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblDescription.Location = new System.Drawing.Point(256, 81);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(53, 16);
            this.lblDescription.TabIndex = 5;
            this.lblDescription.Text = "توضیحات:";
            this.lblDescription.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtDescription.Border.Class = "TextBoxBorder";
            this.txtDescription.Location = new System.Drawing.Point(12, 79);
            this.txtDescription.MaxLength = 300;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(236, 21);
            this.txtDescription.TabIndex = 1;
            this.txtDescription.Tag = "ctrl";
            this.txtDescription.WatermarkText = "توضیحاتی پیرامون برنامه نوبت دهی";
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Sepehr.Settings.Schedules.Properties.Resources.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(113, 110);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 57);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.TabStop = false;
            this.btnCancel.Tag = "ctrl";
            this.btnCancel.Text = "انصراف\r\n(Esc)";
            // 
            // btnAccept
            // 
            this.btnAccept.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAccept.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAccept.Image = global::Sepehr.Settings.Schedules.Properties.Resources.Accept;
            this.btnAccept.Location = new System.Drawing.Point(12, 110);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnAccept.Size = new System.Drawing.Size(95, 57);
            this.btnAccept.TabIndex = 2;
            this.btnAccept.TabStop = false;
            this.btnAccept.Tag = "ctrl";
            this.btnAccept.Text = "تایید\r\n(F8)";
            this.btnAccept.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            // 
            // FormErrorProvider
            // 
            this.FormErrorProvider.ContainerControl = this;
            this.FormErrorProvider.RightToLeft = true;
            // 
            // frmAppsBaseEdit
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(321, 181);
            this.Controls.Add(this.FormPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAppsBaseEdit";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تنظیمات - نوبت دهی - ویرایش اطلاعات پایه";
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.FormPanel.ResumeLayout(false);
            this.FormPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FormErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel FormPanel;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnAccept;
        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxIsActive;
        private DevComponents.DotNetBar.LabelX lblDescription;
        private DevComponents.DotNetBar.LabelX lblAppName;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDescription;
        private DevComponents.DotNetBar.Controls.TextBoxX txtAppName;
        private DevComponents.DotNetBar.LabelX lblTitle;
        private System.Windows.Forms.ErrorProvider FormErrorProvider;
    }

}