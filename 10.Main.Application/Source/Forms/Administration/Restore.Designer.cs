namespace Sepehr.Forms.Administration
{
    partial class frmRestore
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRestore));
            this.PanelForm = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.btnBackupPath = new DevComponents.DotNetBar.ButtonX();
            this.ProgressBarForm = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.Panel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnRestorePath2 = new DevComponents.DotNetBar.ButtonX();
            this.lblRestorePath2 = new DevComponents.DotNetBar.LabelX();
            this.txtRestorePath2 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cBoxOption2 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.txtBackupPath = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.Panel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnRestorePath1 = new DevComponents.DotNetBar.ButtonX();
            this.lblRestorePath1 = new DevComponents.DotNetBar.LabelX();
            this.txtRestorePath1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cBoxOption1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.lblBackupPath = new DevComponents.DotNetBar.LabelX();
            this.btnHelp = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnAccept = new DevComponents.DotNetBar.ButtonX();
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.FolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.BGWorker = new System.ComponentModel.BackgroundWorker();
            this.PanelForm.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelForm
            // 
            this.PanelForm.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelForm.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelForm.Controls.Add(this.btnBackupPath);
            this.PanelForm.Controls.Add(this.ProgressBarForm);
            this.PanelForm.Controls.Add(this.Panel2);
            this.PanelForm.Controls.Add(this.txtBackupPath);
            this.PanelForm.Controls.Add(this.Panel1);
            this.PanelForm.Controls.Add(this.lblBackupPath);
            this.PanelForm.Controls.Add(this.btnHelp);
            this.PanelForm.Controls.Add(this.btnCancel);
            this.PanelForm.Controls.Add(this.btnAccept);
            this.PanelForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelForm.Location = new System.Drawing.Point(0, 0);
            this.PanelForm.Name = "PanelForm";
            this.PanelForm.Size = new System.Drawing.Size(372, 380);
            // 
            // 
            // 
            this.PanelForm.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.PanelForm.Style.BackColorGradientAngle = 90;
            this.PanelForm.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.PanelForm.Style.BorderBottomWidth = 1;
            this.PanelForm.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.PanelForm.Style.BorderLeftWidth = 1;
            this.PanelForm.Style.BorderRightWidth = 1;
            this.PanelForm.Style.BorderTopWidth = 1;
            this.PanelForm.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.PanelForm.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.PanelForm.TabIndex = 0;
            // 
            // btnBackupPath
            // 
            this.btnBackupPath.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnBackupPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBackupPath.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnBackupPath.Image = ((System.Drawing.Image)(resources.GetObject("btnBackupPath.Image")));
            this.btnBackupPath.Location = new System.Drawing.Point(22, 17);
            this.btnBackupPath.Name = "btnBackupPath";
            this.btnBackupPath.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnBackupPath.Size = new System.Drawing.Size(84, 42);
            this.btnBackupPath.TabIndex = 2;
            this.btnBackupPath.TabStop = false;
            this.btnBackupPath.Text = "انتخاب مسیر...";
            this.btnBackupPath.Click += new System.EventHandler(this.btnSelectPath_Click);
            // 
            // ProgressBarForm
            // 
            this.ProgressBarForm.Location = new System.Drawing.Point(12, 277);
            this.ProgressBarForm.Name = "ProgressBarForm";
            this.ProgressBarForm.Size = new System.Drawing.Size(349, 23);
            this.ProgressBarForm.TabIndex = 5;
            this.ProgressBarForm.Text = "در انتظار بازیابی بانك اطلاعاتی";
            this.ProgressBarForm.TextVisible = true;
            // 
            // Panel2
            // 
            this.Panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.Panel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.Panel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.Panel2.Controls.Add(this.btnRestorePath2);
            this.Panel2.Controls.Add(this.lblRestorePath2);
            this.Panel2.Controls.Add(this.txtRestorePath2);
            this.Panel2.Controls.Add(this.cBoxOption2);
            this.Panel2.DrawTitleBox = false;
            this.Panel2.Location = new System.Drawing.Point(12, 171);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(349, 100);
            // 
            // 
            // 
            this.Panel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.Panel2.Style.BackColorGradientAngle = 90;
            this.Panel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.Panel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.Panel2.Style.BorderBottomWidth = 1;
            this.Panel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.Panel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.Panel2.Style.BorderLeftWidth = 1;
            this.Panel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.Panel2.Style.BorderRightWidth = 1;
            this.Panel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.Panel2.Style.BorderTopWidth = 1;
            this.Panel2.Style.CornerDiameter = 4;
            this.Panel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.Panel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.Panel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.Panel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.Panel2.TabIndex = 4;
            this.Panel2.Text = "بازیابی سیستم مدیریت تصویربرداری";
            // 
            // btnRestorePath2
            // 
            this.btnRestorePath2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRestorePath2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestorePath2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnRestorePath2.Image = ((System.Drawing.Image)(resources.GetObject("btnRestorePath2.Image")));
            this.btnRestorePath2.Location = new System.Drawing.Point(7, 31);
            this.btnRestorePath2.Name = "btnRestorePath2";
            this.btnRestorePath2.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnRestorePath2.Size = new System.Drawing.Size(84, 42);
            this.btnRestorePath2.TabIndex = 3;
            this.btnRestorePath2.TabStop = false;
            this.btnRestorePath2.Text = "انتخاب مسیر...";
            this.btnRestorePath2.Click += new System.EventHandler(this.btnSelectPath_Click);
            // 
            // lblRestorePath2
            // 
            this.lblRestorePath2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRestorePath2.AutoSize = true;
            this.lblRestorePath2.BackColor = System.Drawing.Color.Transparent;
            this.lblRestorePath2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblRestorePath2.Location = new System.Drawing.Point(120, 31);
            this.lblRestorePath2.Name = "lblRestorePath2";
            this.lblRestorePath2.Size = new System.Drawing.Size(220, 16);
            this.lblRestorePath2.TabIndex = 1;
            this.lblRestorePath2.Text = "محل ذخیره سازی فایل های بانك اطلاعات:";
            this.lblRestorePath2.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // txtRestorePath2
            // 
            this.txtRestorePath2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtRestorePath2.Border.Class = "TextBoxBorder";
            this.txtRestorePath2.Location = new System.Drawing.Point(97, 52);
            this.txtRestorePath2.Name = "txtRestorePath2";
            this.txtRestorePath2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtRestorePath2.Size = new System.Drawing.Size(243, 21);
            this.txtRestorePath2.TabIndex = 2;
            this.txtRestorePath2.Text = "C:\\Negar Databases";
            // 
            // cBoxOption2
            // 
            this.cBoxOption2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxOption2.AutoSize = true;
            this.cBoxOption2.BackColor = System.Drawing.Color.Transparent;
            this.cBoxOption2.Checked = true;
            this.cBoxOption2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBoxOption2.CheckValue = "Y";
            this.cBoxOption2.Location = new System.Drawing.Point(174, 9);
            this.cBoxOption2.Name = "cBoxOption2";
            this.cBoxOption2.Size = new System.Drawing.Size(167, 16);
            this.cBoxOption2.TabIndex = 0;
            this.cBoxOption2.Text = "بازیابی بانك مدیریت تصویربرداری";
            // 
            // txtBackupPath
            // 
            this.txtBackupPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtBackupPath.Border.Class = "TextBoxBorder";
            this.txtBackupPath.Location = new System.Drawing.Point(112, 38);
            this.txtBackupPath.Name = "txtBackupPath";
            this.txtBackupPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBackupPath.Size = new System.Drawing.Size(243, 21);
            this.txtBackupPath.TabIndex = 0;
            this.txtBackupPath.Text = "C:\\Negar Backup";
            // 
            // Panel1
            // 
            this.Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.Panel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.Panel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.Panel1.Controls.Add(this.btnRestorePath1);
            this.Panel1.Controls.Add(this.lblRestorePath1);
            this.Panel1.Controls.Add(this.txtRestorePath1);
            this.Panel1.Controls.Add(this.cBoxOption1);
            this.Panel1.DrawTitleBox = false;
            this.Panel1.Location = new System.Drawing.Point(12, 65);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(349, 100);
            // 
            // 
            // 
            this.Panel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.Panel1.Style.BackColorGradientAngle = 90;
            this.Panel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.Panel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.Panel1.Style.BorderBottomWidth = 1;
            this.Panel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.Panel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.Panel1.Style.BorderLeftWidth = 1;
            this.Panel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.Panel1.Style.BorderRightWidth = 1;
            this.Panel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.Panel1.Style.BorderTopWidth = 1;
            this.Panel1.Style.CornerDiameter = 4;
            this.Panel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.Panel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.Panel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.Panel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.Panel1.TabIndex = 3;
            this.Panel1.Text = "بازیابی سیستم مدیریت بیماران";
            // 
            // btnRestorePath1
            // 
            this.btnRestorePath1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRestorePath1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestorePath1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnRestorePath1.Image = ((System.Drawing.Image)(resources.GetObject("btnRestorePath1.Image")));
            this.btnRestorePath1.Location = new System.Drawing.Point(7, 31);
            this.btnRestorePath1.Name = "btnRestorePath1";
            this.btnRestorePath1.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnRestorePath1.Size = new System.Drawing.Size(84, 42);
            this.btnRestorePath1.TabIndex = 3;
            this.btnRestorePath1.TabStop = false;
            this.btnRestorePath1.Text = "انتخاب مسیر...";
            this.btnRestorePath1.Click += new System.EventHandler(this.btnSelectPath_Click);
            // 
            // lblRestorePath1
            // 
            this.lblRestorePath1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRestorePath1.AutoSize = true;
            this.lblRestorePath1.BackColor = System.Drawing.Color.Transparent;
            this.lblRestorePath1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblRestorePath1.Location = new System.Drawing.Point(120, 31);
            this.lblRestorePath1.Name = "lblRestorePath1";
            this.lblRestorePath1.Size = new System.Drawing.Size(220, 16);
            this.lblRestorePath1.TabIndex = 1;
            this.lblRestorePath1.Text = "محل ذخیره سازی فایل های بانك اطلاعات:";
            this.lblRestorePath1.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // txtRestorePath1
            // 
            this.txtRestorePath1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtRestorePath1.Border.Class = "TextBoxBorder";
            this.txtRestorePath1.Location = new System.Drawing.Point(97, 52);
            this.txtRestorePath1.Name = "txtRestorePath1";
            this.txtRestorePath1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtRestorePath1.Size = new System.Drawing.Size(243, 21);
            this.txtRestorePath1.TabIndex = 2;
            this.txtRestorePath1.Text = "C:\\Negar Databases";
            // 
            // cBoxOption1
            // 
            this.cBoxOption1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxOption1.AutoSize = true;
            this.cBoxOption1.BackColor = System.Drawing.Color.Transparent;
            this.cBoxOption1.Checked = true;
            this.cBoxOption1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBoxOption1.CheckValue = "Y";
            this.cBoxOption1.Location = new System.Drawing.Point(196, 9);
            this.cBoxOption1.Name = "cBoxOption1";
            this.cBoxOption1.Size = new System.Drawing.Size(145, 16);
            this.cBoxOption1.TabIndex = 0;
            this.cBoxOption1.Text = "بازیابی بانك مدیریت بیماران";
            // 
            // lblBackupPath
            // 
            this.lblBackupPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBackupPath.AutoSize = true;
            this.lblBackupPath.BackColor = System.Drawing.Color.Transparent;
            this.lblBackupPath.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblBackupPath.Location = new System.Drawing.Point(220, 17);
            this.lblBackupPath.Name = "lblBackupPath";
            this.lblBackupPath.Size = new System.Drawing.Size(135, 16);
            this.lblBackupPath.TabIndex = 1;
            this.lblBackupPath.Text = "محل خواندن فایل بازیابی:";
            this.lblBackupPath.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // btnHelp
            // 
            this.btnHelp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnHelp.Image = global::Sepehr.Properties.Resources.Help;
            this.btnHelp.Location = new System.Drawing.Point(265, 308);
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
            this.btnCancel.Location = new System.Drawing.Point(113, 308);
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
            this.btnAccept.Location = new System.Drawing.Point(12, 308);
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
            // BGWorker
            // 
            this.BGWorker.WorkerSupportsCancellation = true;
            this.BGWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGWorker_DoWork);
            this.BGWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BGWorker_RunWorkerCompleted);
            // 
            // frmRestore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(372, 380);
            this.Controls.Add(this.PanelForm);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRestore";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "بازیابی فایل پشتیبانی بانك اطلاعات";
            this.Load += new System.EventHandler(this.Form_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.PanelForm.ResumeLayout(false);
            this.PanelForm.PerformLayout();
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel PanelForm;
        private DevComponents.DotNetBar.ButtonX btnHelp;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnAccept;
        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxOption1;
        private DevComponents.DotNetBar.LabelX lblRestorePath1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtRestorePath1;
        private DevComponents.DotNetBar.ButtonX btnRestorePath1;
        private DevComponents.DotNetBar.Controls.GroupPanel Panel2;
        private DevComponents.DotNetBar.ButtonX btnBackupPath;
        private DevComponents.DotNetBar.ButtonX btnRestorePath2;
        private DevComponents.DotNetBar.LabelX lblRestorePath2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtBackupPath;
        private DevComponents.DotNetBar.LabelX lblBackupPath;
        private DevComponents.DotNetBar.Controls.TextBoxX txtRestorePath2;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxOption2;
        private DevComponents.DotNetBar.Controls.GroupPanel Panel1;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowser;
        private System.ComponentModel.BackgroundWorker BGWorker;
        private DevComponents.DotNetBar.Controls.ProgressBarX ProgressBarForm;
    }
}