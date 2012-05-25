namespace Aftab.Forms
{
    partial class frmServiceSetup
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
            this.PanelCostDiscount = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.btnEventLog = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnStart = new DevComponents.DotNetBar.ButtonX();
            this.btnStop = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnInstall = new DevComponents.DotNetBar.ButtonX();
            this.btnUnInstall = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.ServiceController = new System.ServiceProcess.ServiceController();
            this.BGWorker = new System.ComponentModel.BackgroundWorker();
            this.PanelCostDiscount.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelCostDiscount
            // 
            this.PanelCostDiscount.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelCostDiscount.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelCostDiscount.Controls.Add(this.btnEventLog);
            this.PanelCostDiscount.Controls.Add(this.groupPanel2);
            this.PanelCostDiscount.Controls.Add(this.groupPanel1);
            this.PanelCostDiscount.Controls.Add(this.btnCancel);
            this.PanelCostDiscount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelCostDiscount.Location = new System.Drawing.Point(0, 0);
            this.PanelCostDiscount.Name = "PanelCostDiscount";
            this.PanelCostDiscount.Size = new System.Drawing.Size(291, 363);
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
            this.PanelCostDiscount.TabIndex = 1;
            // 
            // btnEventLog
            // 
            this.btnEventLog.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEventLog.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnEventLog.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnEventLog.Image = global::Aftab.Properties.Resources.EventsLogs;
            this.btnEventLog.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnEventLog.Location = new System.Drawing.Point(12, 12);
            this.btnEventLog.Name = "btnEventLog";
            this.btnEventLog.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnEventLog.Size = new System.Drawing.Size(267, 60);
            this.btnEventLog.TabIndex = 6;
            this.btnEventLog.Text = "نمایش رخداد های به \r\nوقوع پیوسته سیستم";
            this.btnEventLog.Click += new System.EventHandler(this.btnEventLog_Click);
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.btnStart);
            this.groupPanel2.Controls.Add(this.btnStop);
            this.groupPanel2.IsShadowEnabled = true;
            this.groupPanel2.Location = new System.Drawing.Point(12, 180);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(267, 91);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.groupPanel2.TabIndex = 8;
            this.groupPanel2.Text = "وضعیت فعالیت";
            // 
            // btnStart
            // 
            this.btnStart.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnStart.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnStart.Enabled = false;
            this.btnStart.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnStart.Image = global::Aftab.Properties.Resources.Accept;
            this.btnStart.Location = new System.Drawing.Point(15, 4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(101, 60);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "فعال كردن ";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnStop.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnStop.Enabled = false;
            this.btnStop.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnStop.Image = global::Aftab.Properties.Resources.Deny;
            this.btnStop.Location = new System.Drawing.Point(145, 4);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(101, 60);
            this.btnStop.TabIndex = 6;
            this.btnStop.Text = "غیر فعال كردن";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.btnInstall);
            this.groupPanel1.Controls.Add(this.btnUnInstall);
            this.groupPanel1.IsShadowEnabled = true;
            this.groupPanel1.Location = new System.Drawing.Point(12, 83);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(267, 91);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.groupPanel1.TabIndex = 8;
            this.groupPanel1.Text = "وضعیت نصب";
            // 
            // btnInstall
            // 
            this.btnInstall.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnInstall.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnInstall.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnInstall.Image = global::Aftab.Properties.Resources.AddMed;
            this.btnInstall.Location = new System.Drawing.Point(15, 4);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(101, 60);
            this.btnInstall.TabIndex = 6;
            this.btnInstall.Text = "نصب سرویس";
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // btnUnInstall
            // 
            this.btnUnInstall.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUnInstall.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnUnInstall.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnUnInstall.Image = global::Aftab.Properties.Resources.DeleteMed;
            this.btnUnInstall.Location = new System.Drawing.Point(145, 5);
            this.btnUnInstall.Name = "btnUnInstall";
            this.btnUnInstall.Size = new System.Drawing.Size(101, 59);
            this.btnUnInstall.TabIndex = 6;
            this.btnUnInstall.Text = "حذف سرویس";
            this.btnUnInstall.Click += new System.EventHandler(this.btnUnInstall_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Aftab.Properties.Resources.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(30, 291);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 60);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "خروج\r\n(Esc)";
            // 
            // ServiceController
            // 
            this.ServiceController.ServiceName = "AftabBackupService";
            // 
            // BGWorker
            // 
            this.BGWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGWorker_DoWork);
            this.BGWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BGWorker_RunWorkerCompleted);
            // 
            // frmServiceSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 363);
            this.Controls.Add(this.PanelCostDiscount);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Name = "frmServiceSetup";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "فرم مدیریت سرویس پشتیبان گیری";
            this.PanelCostDiscount.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel PanelCostDiscount;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnUnInstall;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.ButtonX btnInstall;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.ButtonX btnStart;
        private DevComponents.DotNetBar.ButtonX btnStop;
        private DevComponents.DotNetBar.ButtonX btnEventLog;
        private System.ServiceProcess.ServiceController ServiceController;
        private System.ComponentModel.BackgroundWorker BGWorker;
    }
}