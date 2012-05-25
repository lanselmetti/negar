namespace Aftab
{
    partial class frmMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainForm));
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.FormNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.BGWorker = new System.ComponentModel.BackgroundWorker();
            this.btnBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.btnManageApps = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSetupService = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // Timer
            // 
            this.Timer.Enabled = true;
            this.Timer.Interval = 300000;
            // 
            // FormNotifyIcon
            // 
            this.FormNotifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.FormNotifyIcon.ContextMenuStrip = this.ContextMenuStrip;
            this.FormNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("FormNotifyIcon.Icon")));
            this.FormNotifyIcon.Text = "سیستم مدیریت پشتیبان گیری";
            this.FormNotifyIcon.Visible = true;
            this.FormNotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.FormNotifyIcon_MouseDoubleClick);
            // 
            // ContextMenuStrip
            // 
            this.ContextMenuStrip.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnBackup,
            this.btnManageApps,
            this.btnSetupService});
            this.ContextMenuStrip.Name = "ContextMenuStrip";
            this.ContextMenuStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ContextMenuStrip.Size = new System.Drawing.Size(194, 140);
            // 
            // btnBackup
            // 
            this.btnBackup.Image = global::Aftab.Properties.Resources.Backup;
            this.btnBackup.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(193, 38);
            this.btnBackup.Text = "پشتیبانی موردی";
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnManageApps
            // 
            this.btnManageApps.Image = global::Aftab.Properties.Resources.AddinFields;
            this.btnManageApps.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnManageApps.Name = "btnManageApps";
            this.btnManageApps.Size = new System.Drawing.Size(193, 38);
            this.btnManageApps.Text = "مدیریت برنامه ها";
            this.btnManageApps.Click += new System.EventHandler(this.btnManageApps_Click);
            // 
            // btnSetupService
            // 
            this.btnSetupService.Image = global::Aftab.Properties.Resources.ServicesSettings;
            this.btnSetupService.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSetupService.Name = "btnSetupService";
            this.btnSetupService.Size = new System.Drawing.Size(193, 38);
            this.btnSetupService.Text = "مدیریت سرویس";
            this.btnSetupService.Click += new System.EventHandler(this.btnSetupService_Click);
            // 
            // frmMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 136);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMainForm";
            this.Opacity = 0.01;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.NotifyIcon FormNotifyIcon;
        private System.Windows.Forms.ContextMenuStrip ContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem btnManageApps;
        private System.ComponentModel.BackgroundWorker BGWorker;
        private System.Windows.Forms.ToolStripMenuItem btnBackup;
        private System.Windows.Forms.ToolStripMenuItem btnSetupService;
    }
}

