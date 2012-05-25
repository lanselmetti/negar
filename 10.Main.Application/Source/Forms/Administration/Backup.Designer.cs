namespace Sepehr.Forms.Administration
{
    partial class frmBackup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBackup));
            this.PanelCostDiscount = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.ProgressBarForm = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.lblSavePath = new DevComponents.DotNetBar.LabelX();
            this.txtSavePath = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnSelectPath = new DevComponents.DotNetBar.ButtonX();
            this.PanelSettings = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.cBoxOption2 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.btnHelp = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnAccept = new DevComponents.DotNetBar.ButtonX();
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.FolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.BGWorker = new System.ComponentModel.BackgroundWorker();
            this.PanelCostDiscount.SuspendLayout();
            this.PanelSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelCostDiscount
            // 
            this.PanelCostDiscount.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelCostDiscount.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelCostDiscount.Controls.Add(this.ProgressBarForm);
            this.PanelCostDiscount.Controls.Add(this.lblSavePath);
            this.PanelCostDiscount.Controls.Add(this.txtSavePath);
            this.PanelCostDiscount.Controls.Add(this.btnSelectPath);
            this.PanelCostDiscount.Controls.Add(this.PanelSettings);
            this.PanelCostDiscount.Controls.Add(this.btnHelp);
            this.PanelCostDiscount.Controls.Add(this.btnCancel);
            this.PanelCostDiscount.Controls.Add(this.btnAccept);
            this.PanelCostDiscount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelCostDiscount.Location = new System.Drawing.Point(0, 0);
            this.PanelCostDiscount.Name = "PanelCostDiscount";
            this.PanelCostDiscount.Size = new System.Drawing.Size(410, 208);
            // 
            // 
            // 
            this.PanelCostDiscount.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.PanelCostDiscount.Style.BackColorGradientAngle = 90;
            this.PanelCostDiscount.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.PanelCostDiscount.Style.BorderBottomWidth = 1;
            this.PanelCostDiscount.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.PanelCostDiscount.Style.BorderLeftWidth = 1;
            this.PanelCostDiscount.Style.BorderRightWidth = 1;
            this.PanelCostDiscount.Style.BorderTopWidth = 1;
            this.PanelCostDiscount.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.PanelCostDiscount.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.PanelCostDiscount.TabIndex = 0;
            // 
            // ProgressBarForm
            // 
            this.ProgressBarForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ProgressBarForm.Location = new System.Drawing.Point(13, 106);
            this.ProgressBarForm.Name = "ProgressBarForm";
            this.ProgressBarForm.Size = new System.Drawing.Size(385, 23);
            this.ProgressBarForm.TabIndex = 5;
            this.ProgressBarForm.Text = "در انتظار ایجاد پشتیبانی";
            this.ProgressBarForm.TextVisible = true;
            // 
            // lblSavePath
            // 
            this.lblSavePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSavePath.AutoSize = true;
            this.lblSavePath.BackColor = System.Drawing.Color.Transparent;
            this.lblSavePath.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblSavePath.Location = new System.Drawing.Point(229, 9);
            this.lblSavePath.Name = "lblSavePath";
            this.lblSavePath.Size = new System.Drawing.Size(167, 16);
            this.lblSavePath.TabIndex = 2;
            this.lblSavePath.Text = "محل ذخیره فایل های پشتیبانی:";
            this.lblSavePath.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // txtSavePath
            // 
            this.txtSavePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtSavePath.Border.Class = "TextBoxBorder";
            this.txtSavePath.Location = new System.Drawing.Point(118, 30);
            this.txtSavePath.Name = "txtSavePath";
            this.txtSavePath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSavePath.Size = new System.Drawing.Size(278, 21);
            this.txtSavePath.TabIndex = 0;
            this.txtSavePath.Text = "C:\\Negar Backup";
            // 
            // btnSelectPath
            // 
            this.btnSelectPath.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelectPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectPath.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelectPath.Image = global::Sepehr.Properties.Resources.Browse;
            this.btnSelectPath.Location = new System.Drawing.Point(13, 9);
            this.btnSelectPath.Name = "btnSelectPath";
            this.btnSelectPath.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnSelectPath.Size = new System.Drawing.Size(99, 42);
            this.btnSelectPath.TabIndex = 1;
            this.btnSelectPath.TabStop = false;
            this.btnSelectPath.Text = "انتخاب مسیر...";
            this.btnSelectPath.Click += new System.EventHandler(this.btnSelectPath_Click);
            // 
            // PanelSettings
            // 
            this.PanelSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelSettings.BackColor = System.Drawing.Color.Transparent;
            this.PanelSettings.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelSettings.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelSettings.Controls.Add(this.cBoxOption2);
            this.PanelSettings.DrawTitleBox = false;
            this.PanelSettings.Location = new System.Drawing.Point(13, 57);
            this.PanelSettings.Name = "PanelSettings";
            this.PanelSettings.Size = new System.Drawing.Size(383, 45);
            // 
            // 
            // 
            this.PanelSettings.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.PanelSettings.Style.BackColorGradientAngle = 90;
            this.PanelSettings.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.PanelSettings.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelSettings.Style.BorderBottomWidth = 1;
            this.PanelSettings.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.PanelSettings.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelSettings.Style.BorderLeftWidth = 1;
            this.PanelSettings.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelSettings.Style.BorderRightWidth = 1;
            this.PanelSettings.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelSettings.Style.BorderTopWidth = 1;
            this.PanelSettings.Style.CornerDiameter = 4;
            this.PanelSettings.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.PanelSettings.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.PanelSettings.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.PanelSettings.TabIndex = 3;
            this.PanelSettings.Text = "تنظیمات پشتیبانی";
            // 
            // cBoxOption2
            // 
            this.cBoxOption2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxOption2.AutoSize = true;
            this.cBoxOption2.BackColor = System.Drawing.Color.Transparent;
            this.cBoxOption2.Checked = true;
            this.cBoxOption2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBoxOption2.CheckValue = "Y";
            this.cBoxOption2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxOption2.Location = new System.Drawing.Point(89, 3);
            this.cBoxOption2.Name = "cBoxOption2";
            this.cBoxOption2.Size = new System.Drawing.Size(289, 16);
            this.cBoxOption2.TabIndex = 0;
            this.cBoxOption2.Text = "ایجاد پشتیبانی از بانك اطلاعات مدیریت تصویربرداری";
            // 
            // btnHelp
            // 
            this.btnHelp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnHelp.Image = global::Sepehr.Properties.Resources.Help;
            this.btnHelp.Location = new System.Drawing.Point(303, 136);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F1);
            this.btnHelp.Size = new System.Drawing.Size(95, 60);
            this.btnHelp.TabIndex = 8;
            this.btnHelp.TabStop = false;
            this.btnHelp.Text = "راهنما\r\n(F1)";
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Sepehr.Properties.Resources.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(113, 136);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 60);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "انصراف (Esc)";
            // 
            // btnAccept
            // 
            this.btnAccept.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAccept.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAccept.Image = global::Sepehr.Properties.Resources.Accept;
            this.btnAccept.Location = new System.Drawing.Point(12, 136);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnAccept.Size = new System.Drawing.Size(95, 60);
            this.btnAccept.TabIndex = 6;
            this.btnAccept.Text = "اجرا (F8)";
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            // 
            // FolderBrowser
            // 
            this.FolderBrowser.Description = "انتخاب محل پوشه ی ذخیره فایل های پشتیبانی";
            // 
            // BGWorker
            // 
            this.BGWorker.WorkerSupportsCancellation = true;
            this.BGWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGWorker_DoWork);
            this.BGWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BGWorker_RunWorkerCompleted);
            // 
            // frmBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(410, 208);
            this.Controls.Add(this.PanelCostDiscount);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBackup";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "مدیریت پشتیبانی از بانك اطلاعات";
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.PanelCostDiscount.ResumeLayout(false);
            this.PanelCostDiscount.PerformLayout();
            this.PanelSettings.ResumeLayout(false);
            this.PanelSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel PanelCostDiscount;
        private DevComponents.DotNetBar.ButtonX btnHelp;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnAccept;
        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxOption2;
        private DevComponents.DotNetBar.Controls.GroupPanel PanelSettings;
        private DevComponents.DotNetBar.LabelX lblSavePath;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSavePath;
        private DevComponents.DotNetBar.ButtonX btnSelectPath;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowser;
        private System.ComponentModel.BackgroundWorker BGWorker;
        private DevComponents.DotNetBar.Controls.ProgressBarX ProgressBarForm;
    }
}