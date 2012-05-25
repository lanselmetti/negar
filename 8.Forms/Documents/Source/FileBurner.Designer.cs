namespace Sepehr.Forms.Documents
{
    partial class frmFileBurner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFileBurner));
            this.PanelDocPatients = new DevComponents.DotNetBar.PanelEx();
            this.cBoxVCD = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cboVerification = new System.Windows.Forms.ComboBox();
            this.ProgressBurn = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.ProgressCheckCD = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.btnBurn = new DevComponents.DotNetBar.ButtonX();
            this.btnCheckCurrentCD = new DevComponents.DotNetBar.ButtonX();
            this.cBoxEjectCD = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.txtCDLabel = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cboDriveSelection = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblDriveSelection = new DevComponents.DotNetBar.LabelX();
            this.cboCDLabel = new DevComponents.DotNetBar.LabelX();
            this.lblStatus = new DevComponents.DotNetBar.LabelX();
            this.lblVerification = new DevComponents.DotNetBar.LabelX();
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.backgroundBurnWorker = new System.ComponentModel.BackgroundWorker();
            this.PanelDocPatients.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelDocPatients
            // 
            this.PanelDocPatients.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelDocPatients.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelDocPatients.Controls.Add(this.cBoxVCD);
            this.PanelDocPatients.Controls.Add(this.cboVerification);
            this.PanelDocPatients.Controls.Add(this.ProgressBurn);
            this.PanelDocPatients.Controls.Add(this.ProgressCheckCD);
            this.PanelDocPatients.Controls.Add(this.btnBurn);
            this.PanelDocPatients.Controls.Add(this.btnCheckCurrentCD);
            this.PanelDocPatients.Controls.Add(this.cBoxEjectCD);
            this.PanelDocPatients.Controls.Add(this.txtCDLabel);
            this.PanelDocPatients.Controls.Add(this.cboDriveSelection);
            this.PanelDocPatients.Controls.Add(this.btnExit);
            this.PanelDocPatients.Controls.Add(this.lblDriveSelection);
            this.PanelDocPatients.Controls.Add(this.cboCDLabel);
            this.PanelDocPatients.Controls.Add(this.lblStatus);
            this.PanelDocPatients.Controls.Add(this.lblVerification);
            this.PanelDocPatients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelDocPatients.Location = new System.Drawing.Point(0, 0);
            this.PanelDocPatients.Name = "PanelDocPatients";
            this.PanelDocPatients.Size = new System.Drawing.Size(253, 281);
            this.PanelDocPatients.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.PanelDocPatients.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.PanelDocPatients.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.PanelDocPatients.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.PanelDocPatients.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.PanelDocPatients.Style.GradientAngle = 90;
            this.PanelDocPatients.TabIndex = 0;
            // 
            // cBoxVCD
            // 
            this.cBoxVCD.AutoSize = true;
            this.cBoxVCD.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxVCD.Location = new System.Drawing.Point(40, 115);
            this.cBoxVCD.Name = "cBoxVCD";
            this.cBoxVCD.Size = new System.Drawing.Size(172, 16);
            this.cBoxVCD.TabIndex = 9;
            this.cBoxVCD.Text = "رایت به صورت ویدئو سی دی";
            // 
            // cboVerification
            // 
            this.cboVerification.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVerification.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cboVerification.FormattingEnabled = true;
            this.cboVerification.Items.AddRange(new object[] {
            "بدون چك كردن",
            "چك كردن سریع",
            "چك كردن دقیق"});
            this.cboVerification.Location = new System.Drawing.Point(12, 66);
            this.cboVerification.Name = "cboVerification";
            this.cboVerification.Size = new System.Drawing.Size(131, 21);
            this.cboVerification.TabIndex = 6;
            this.cboVerification.SelectedIndexChanged += new System.EventHandler(this.cboVerification_SelectedIndexChanged);
            // 
            // ProgressBurn
            // 
            this.ProgressBurn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ProgressBurn.Location = new System.Drawing.Point(12, 252);
            this.ProgressBurn.Name = "ProgressBurn";
            this.ProgressBurn.Size = new System.Drawing.Size(229, 22);
            this.ProgressBurn.TabIndex = 13;
            this.ProgressBurn.TabStop = false;
            this.ProgressBurn.Text = "در انتظار رایت دیسك";
            this.ProgressBurn.TextVisible = true;
            // 
            // ProgressCheckCD
            // 
            this.ProgressCheckCD.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ProgressCheckCD.Location = new System.Drawing.Point(12, 175);
            this.ProgressCheckCD.Name = "ProgressCheckCD";
            this.ProgressCheckCD.Size = new System.Drawing.Size(229, 22);
            this.ProgressCheckCD.TabIndex = 11;
            this.ProgressCheckCD.TabStop = false;
            this.ProgressCheckCD.TextVisible = true;
            // 
            // btnBurn
            // 
            this.btnBurn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnBurn.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnBurn.Font = new System.Drawing.Font("B Titr", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnBurn.Location = new System.Drawing.Point(92, 203);
            this.btnBurn.Name = "btnBurn";
            this.btnBurn.Size = new System.Drawing.Size(69, 43);
            this.btnBurn.TabIndex = 12;
            this.btnBurn.Text = "اجرا!";
            this.btnBurn.Click += new System.EventHandler(this.btnBurn_Click);
            // 
            // btnCheckCurrentCD
            // 
            this.btnCheckCurrentCD.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCheckCurrentCD.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCheckCurrentCD.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnCheckCurrentCD.Location = new System.Drawing.Point(63, 137);
            this.btnCheckCurrentCD.Name = "btnCheckCurrentCD";
            this.btnCheckCurrentCD.Size = new System.Drawing.Size(126, 32);
            this.btnCheckCurrentCD.TabIndex = 10;
            this.btnCheckCurrentCD.Text = "بررسی دیسك موجود";
            this.btnCheckCurrentCD.Click += new System.EventHandler(this.btnCheckCurrentCD_Click);
            // 
            // cBoxEjectCD
            // 
            this.cBoxEjectCD.AutoSize = true;
            this.cBoxEjectCD.Checked = true;
            this.cBoxEjectCD.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBoxEjectCD.CheckValue = "Y";
            this.cBoxEjectCD.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cBoxEjectCD.Location = new System.Drawing.Point(38, 93);
            this.cBoxEjectCD.Name = "cBoxEjectCD";
            this.cBoxEjectCD.Size = new System.Drawing.Size(176, 16);
            this.cBoxEjectCD.TabIndex = 8;
            this.cBoxEjectCD.Text = "خروج دیسك پس از اتمام رایت";
            // 
            // txtCDLabel
            // 
            // 
            // 
            // 
            this.txtCDLabel.Border.Class = "TextBoxBorder";
            this.txtCDLabel.Location = new System.Drawing.Point(12, 39);
            this.txtCDLabel.Name = "txtCDLabel";
            this.txtCDLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCDLabel.Size = new System.Drawing.Size(140, 21);
            this.txtCDLabel.TabIndex = 2;
            // 
            // cboDriveSelection
            // 
            this.cboDriveSelection.DisplayMember = "Name";
            this.cboDriveSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDriveSelection.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.cboDriveSelection.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cboDriveSelection.FormattingEnabled = true;
            this.cboDriveSelection.ItemHeight = 13;
            this.cboDriveSelection.Location = new System.Drawing.Point(12, 12);
            this.cboDriveSelection.Name = "cboDriveSelection";
            this.cboDriveSelection.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cboDriveSelection.Size = new System.Drawing.Size(165, 21);
            this.cboDriveSelection.TabIndex = 0;
            this.cboDriveSelection.ValueMember = "ID";
            this.cboDriveSelection.SelectedIndexChanged += new System.EventHandler(this.cboDriveSelection_SelectedIndexChanged);
            this.cboDriveSelection.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cboDriveSelection_Format);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(0, -30);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 13;
            this.btnExit.TabStop = false;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblDriveSelection
            // 
            this.lblDriveSelection.AutoSize = true;
            this.lblDriveSelection.BackColor = System.Drawing.Color.Transparent;
            this.lblDriveSelection.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblDriveSelection.Location = new System.Drawing.Point(183, 14);
            this.lblDriveSelection.Name = "lblDriveSelection";
            this.lblDriveSelection.Size = new System.Drawing.Size(58, 16);
            this.lblDriveSelection.TabIndex = 1;
            this.lblDriveSelection.Text = "درایو رایت:";
            this.lblDriveSelection.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // cboCDLabel
            // 
            this.cboCDLabel.AutoSize = true;
            this.cboCDLabel.BackColor = System.Drawing.Color.Transparent;
            this.cboCDLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cboCDLabel.Location = new System.Drawing.Point(158, 41);
            this.cboCDLabel.Name = "cboCDLabel";
            this.cboCDLabel.Size = new System.Drawing.Size(83, 16);
            this.cboCDLabel.TabIndex = 3;
            this.cboCDLabel.Text = "برچسب دیسك:";
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblStatus.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Location = new System.Drawing.Point(12, 348);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(198, 24);
            this.lblStatus.TabIndex = 12;
            // 
            // lblVerification
            // 
            this.lblVerification.AutoSize = true;
            this.lblVerification.BackColor = System.Drawing.Color.Transparent;
            this.lblVerification.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblVerification.Location = new System.Drawing.Point(149, 68);
            this.lblVerification.Name = "lblVerification";
            this.lblVerification.Size = new System.Drawing.Size(92, 16);
            this.lblVerification.TabIndex = 7;
            this.lblVerification.Text = "بررسی سی دی:";
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            // 
            // backgroundBurnWorker
            // 
            this.backgroundBurnWorker.WorkerReportsProgress = true;
            this.backgroundBurnWorker.WorkerSupportsCancellation = true;
            this.backgroundBurnWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundBurnWorker_DoWork);
            this.backgroundBurnWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundBurnWorker_RunWorkerCompleted);
            this.backgroundBurnWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundBurnWorker_ProgressChanged);
            // 
            // frmFileBurner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(253, 281);
            this.Controls.Add(this.PanelDocPatients);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFileBurner";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "رایت تصاویر پزشكی بیمار";
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.PanelDocPatients.ResumeLayout(false);
            this.PanelDocPatients.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private DevComponents.DotNetBar.PanelEx PanelDocPatients;
        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        private System.Windows.Forms.Button btnExit;
        private DevComponents.DotNetBar.ButtonX btnCheckCurrentCD;
        private DevComponents.DotNetBar.ButtonX btnBurn;
        private System.ComponentModel.BackgroundWorker backgroundBurnWorker;
        private DevComponents.DotNetBar.Controls.ProgressBarX ProgressBurn;
        private DevComponents.DotNetBar.Controls.ProgressBarX ProgressCheckCD;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxEjectCD;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCDLabel;
        private DevComponents.DotNetBar.LabelX lblDriveSelection;
        private DevComponents.DotNetBar.LabelX cboCDLabel;
        private DevComponents.DotNetBar.LabelX lblVerification;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboDriveSelection;
        private System.Windows.Forms.ComboBox cboVerification;
        private DevComponents.DotNetBar.LabelX lblStatus;
        private DevComponents.DotNetBar.Controls.CheckBoxX cBoxVCD;
    }
}