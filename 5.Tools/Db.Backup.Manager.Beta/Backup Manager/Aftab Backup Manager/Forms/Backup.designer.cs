namespace Aftab
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
            this.PanelInstance = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.cBoxInstanceName = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.lblInstanceName = new DevComponents.DotNetBar.LabelX();
            this.ProgressBarForm = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.lblSavePath = new DevComponents.DotNetBar.LabelX();
            this.txtSavePath = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnSelectPath = new DevComponents.DotNetBar.ButtonX();
            this.PanelSettings = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.cBoxOption2 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnAccept = new DevComponents.DotNetBar.ButtonX();
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.FolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.BGWorker = new System.ComponentModel.BackgroundWorker();
            this.PanelCostDiscount.SuspendLayout();
            this.PanelInstance.SuspendLayout();
            this.PanelSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelCostDiscount
            // 
            this.PanelCostDiscount.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelCostDiscount.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelCostDiscount.Controls.Add(this.PanelInstance);
            this.PanelCostDiscount.Controls.Add(this.ProgressBarForm);
            this.PanelCostDiscount.Controls.Add(this.lblSavePath);
            this.PanelCostDiscount.Controls.Add(this.txtSavePath);
            this.PanelCostDiscount.Controls.Add(this.btnSelectPath);
            this.PanelCostDiscount.Controls.Add(this.PanelSettings);
            this.PanelCostDiscount.Controls.Add(this.btnCancel);
            this.PanelCostDiscount.Controls.Add(this.btnAccept);
            this.PanelCostDiscount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelCostDiscount.Location = new System.Drawing.Point(0, 0);
            this.PanelCostDiscount.Name = "PanelCostDiscount";
            this.PanelCostDiscount.Size = new System.Drawing.Size(409, 287);
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
            // PanelInstance
            // 
            this.PanelInstance.BackColor = System.Drawing.Color.Transparent;
            this.PanelInstance.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelInstance.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelInstance.Controls.Add(this.cBoxInstanceName);
            this.PanelInstance.Controls.Add(this.lblInstanceName);
            this.PanelInstance.DrawTitleBox = false;
            this.PanelInstance.Location = new System.Drawing.Point(12, 60);
            this.PanelInstance.Name = "PanelInstance";
            this.PanelInstance.Size = new System.Drawing.Size(383, 70);
            // 
            // 
            // 
            this.PanelInstance.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.PanelInstance.Style.BackColorGradientAngle = 90;
            this.PanelInstance.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.PanelInstance.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelInstance.Style.BorderBottomWidth = 1;
            this.PanelInstance.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.PanelInstance.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelInstance.Style.BorderLeftWidth = 1;
            this.PanelInstance.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelInstance.Style.BorderRightWidth = 1;
            this.PanelInstance.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelInstance.Style.BorderTopWidth = 1;
            this.PanelInstance.Style.CornerDiameter = 4;
            this.PanelInstance.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.PanelInstance.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.PanelInstance.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.PanelInstance.TabIndex = 13;
            this.PanelInstance.Text = "تنظیمات نمونه بانك اطلاعاتی";
            // 
            // cBoxInstanceName
            // 
            this.cBoxInstanceName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cBoxInstanceName.DisplayMember = "Text";
            this.cBoxInstanceName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cBoxInstanceName.FormattingEnabled = true;
            this.cBoxInstanceName.ItemHeight = 15;
            this.cBoxInstanceName.Location = new System.Drawing.Point(11, 23);
            this.cBoxInstanceName.Name = "cBoxInstanceName";
            this.cBoxInstanceName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cBoxInstanceName.Size = new System.Drawing.Size(362, 21);
            this.cBoxInstanceName.TabIndex = 25;
            // 
            // lblInstanceName
            // 
            this.lblInstanceName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblInstanceName.AutoSize = true;
            this.lblInstanceName.BackColor = System.Drawing.Color.Transparent;
            this.lblInstanceName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblInstanceName.Location = new System.Drawing.Point(247, 2);
            this.lblInstanceName.Name = "lblInstanceName";
            this.lblInstanceName.Size = new System.Drawing.Size(128, 16);
            this.lblInstanceName.TabIndex = 0;
            this.lblInstanceName.Text = "نام نمونه بانك اطلاعاتی:";
            this.lblInstanceName.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // ProgressBarForm
            // 
            this.ProgressBarForm.Location = new System.Drawing.Point(12, 187);
            this.ProgressBarForm.Name = "ProgressBarForm";
            this.ProgressBarForm.Size = new System.Drawing.Size(383, 23);
            this.ProgressBarForm.TabIndex = 5;
            this.ProgressBarForm.Text = "در انتظار ایجاد پشتیبانی";
            this.ProgressBarForm.TextVisible = true;
            // 
            // lblSavePath
            // 
            this.lblSavePath.AutoSize = true;
            this.lblSavePath.BackColor = System.Drawing.Color.Transparent;
            this.lblSavePath.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblSavePath.Location = new System.Drawing.Point(228, 12);
            this.lblSavePath.Name = "lblSavePath";
            this.lblSavePath.Size = new System.Drawing.Size(167, 16);
            this.lblSavePath.TabIndex = 2;
            this.lblSavePath.Text = "محل ذخیره فایل های پشتیبانی:";
            this.lblSavePath.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // txtSavePath
            // 
            // 
            // 
            // 
            this.txtSavePath.Border.Class = "TextBoxBorder";
            this.txtSavePath.Location = new System.Drawing.Point(117, 33);
            this.txtSavePath.Name = "txtSavePath";
            this.txtSavePath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSavePath.Size = new System.Drawing.Size(278, 21);
            this.txtSavePath.TabIndex = 0;
            this.txtSavePath.Text = "C:\\Aftab Backup";
            // 
            // btnSelectPath
            // 
            this.btnSelectPath.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelectPath.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelectPath.Image = global::Aftab.Properties.Resources.Browse;
            this.btnSelectPath.Location = new System.Drawing.Point(12, 12);
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
            this.PanelSettings.BackColor = System.Drawing.Color.Transparent;
            this.PanelSettings.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelSettings.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelSettings.Controls.Add(this.cBoxOption2);
            this.PanelSettings.DrawTitleBox = false;
            this.PanelSettings.Location = new System.Drawing.Point(12, 136);
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
            this.cBoxOption2.Location = new System.Drawing.Point(84, 3);
            this.cBoxOption2.Name = "cBoxOption2";
            this.cBoxOption2.Size = new System.Drawing.Size(289, 16);
            this.cBoxOption2.TabIndex = 0;
            this.cBoxOption2.Text = "ایجاد پشتیبانی از بانك اطلاعات مدیریت تصویربرداری";
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Aftab.Properties.Resources.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(113, 216);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 60);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "خروج\r\n(Esc)";
            this.btnCancel.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAccept.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAccept.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnAccept.Image = global::Aftab.Properties.Resources.Accept;
            this.btnAccept.Location = new System.Drawing.Point(12, 216);
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
            this.ClientSize = new System.Drawing.Size(409, 287);
            this.Controls.Add(this.PanelCostDiscount);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBackup";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ایجاد پشتیبانی از بانك اطلاعات";
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.PanelCostDiscount.ResumeLayout(false);
            this.PanelCostDiscount.PerformLayout();
            this.PanelInstance.ResumeLayout(false);
            this.PanelInstance.PerformLayout();
            this.PanelSettings.ResumeLayout(false);
            this.PanelSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel PanelCostDiscount;
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
        private DevComponents.DotNetBar.Controls.GroupPanel PanelInstance;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cBoxInstanceName;
        private DevComponents.DotNetBar.LabelX lblInstanceName;
    }
}