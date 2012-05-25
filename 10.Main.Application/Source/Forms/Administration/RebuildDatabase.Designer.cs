namespace Sepehr.Forms.Administration
{
    partial class frmRebuildDatabase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRebuildDatabase));
            this.PanelForm = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.ProgressBarForm = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.lblSavePath = new DevComponents.DotNetBar.LabelX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnAccept = new DevComponents.DotNetBar.ButtonX();
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.SaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.BGWorker = new System.ComponentModel.BackgroundWorker();
            this.PanelForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelForm
            // 
            this.PanelForm.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelForm.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelForm.Controls.Add(this.ProgressBarForm);
            this.PanelForm.Controls.Add(this.lblSavePath);
            this.PanelForm.Controls.Add(this.btnCancel);
            this.PanelForm.Controls.Add(this.btnAccept);
            this.PanelForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelForm.Location = new System.Drawing.Point(0, 0);
            this.PanelForm.Name = "PanelForm";
            this.PanelForm.Size = new System.Drawing.Size(327, 219);
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
            // ProgressBarForm
            // 
            this.ProgressBarForm.Location = new System.Drawing.Point(12, 115);
            this.ProgressBarForm.Name = "ProgressBarForm";
            this.ProgressBarForm.Size = new System.Drawing.Size(303, 23);
            this.ProgressBarForm.TabIndex = 6;
            this.ProgressBarForm.Text = "در انتظار بازسازی بانك اطلاعاتی";
            this.ProgressBarForm.TextVisible = true;
            // 
            // lblSavePath
            // 
            this.lblSavePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSavePath.BackColor = System.Drawing.Color.Transparent;
            this.lblSavePath.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblSavePath.Location = new System.Drawing.Point(12, 12);
            this.lblSavePath.Name = "lblSavePath";
            this.lblSavePath.Size = new System.Drawing.Size(303, 97);
            this.lblSavePath.TabIndex = 3;
            this.lblSavePath.Text = resources.GetString("lblSavePath.Text");
            this.lblSavePath.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Sepehr.Properties.Resources.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(113, 147);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 60);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "انصراف (Esc)";
            // 
            // btnAccept
            // 
            this.btnAccept.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAccept.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAccept.Image = global::Sepehr.Properties.Resources.Accept;
            this.btnAccept.Location = new System.Drawing.Point(12, 147);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnAccept.Size = new System.Drawing.Size(95, 60);
            this.btnAccept.TabIndex = 4;
            this.btnAccept.Text = "تایید (F8)";
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            // 
            // BGWorker
            // 
            this.BGWorker.WorkerReportsProgress = true;
            this.BGWorker.WorkerSupportsCancellation = true;
            this.BGWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGWorker_DoWork);
            this.BGWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BGWorker_RunWorkerCompleted);
            this.BGWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BGWorker_ProgressChanged);
            // 
            // frmRebuildDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(327, 219);
            this.Controls.Add(this.PanelForm);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRebuildDatabase";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "بازسازی ساختار بانك اطلاعاتی";
            this.Load += new System.EventHandler(this.Form_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.PanelForm.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel PanelForm;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnAccept;
        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        private System.Windows.Forms.SaveFileDialog SaveDialog;
        private DevComponents.DotNetBar.LabelX lblSavePath;
        private DevComponents.DotNetBar.Controls.ProgressBarX ProgressBarForm;
        private System.ComponentModel.BackgroundWorker BGWorker;
    }
}