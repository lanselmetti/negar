namespace Sepehr.Forms.SpecialReports
{
    partial class frmList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmList));
            this.PanelForm = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.lstReportsList = new DevComponents.DotNetBar.ItemPanel();
            this.btnHelp = new DevComponents.DotNetBar.ButtonX();
            this.btnRefresh = new DevComponents.DotNetBar.ButtonX();
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.PanelForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelForm
            // 
            this.PanelForm.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelForm.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelForm.Controls.Add(this.btnClose);
            this.PanelForm.Controls.Add(this.lstReportsList);
            this.PanelForm.Controls.Add(this.btnHelp);
            this.PanelForm.Controls.Add(this.btnRefresh);
            this.PanelForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelForm.Location = new System.Drawing.Point(0, 0);
            this.PanelForm.Name = "PanelForm";
            this.PanelForm.Size = new System.Drawing.Size(334, 362);
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
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = global::Sepehr.Properties.Resources.Cancel;
            this.btnClose.Location = new System.Drawing.Point(12, 290);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(92, 60);
            this.btnClose.TabIndex = 1;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "خروج (Esc)";
            // 
            // lstReportsList
            // 
            this.lstReportsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.lstReportsList.BackgroundStyle.BackColor = System.Drawing.Color.White;
            this.lstReportsList.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lstReportsList.BackgroundStyle.BorderBottomWidth = 1;
            this.lstReportsList.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            this.lstReportsList.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lstReportsList.BackgroundStyle.BorderLeftWidth = 1;
            this.lstReportsList.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lstReportsList.BackgroundStyle.BorderRightWidth = 1;
            this.lstReportsList.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lstReportsList.BackgroundStyle.BorderTopWidth = 1;
            this.lstReportsList.BackgroundStyle.PaddingBottom = 1;
            this.lstReportsList.BackgroundStyle.PaddingLeft = 1;
            this.lstReportsList.BackgroundStyle.PaddingRight = 1;
            this.lstReportsList.BackgroundStyle.PaddingTop = 1;
            this.lstReportsList.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lstReportsList.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.lstReportsList.Location = new System.Drawing.Point(12, 12);
            this.lstReportsList.Name = "lstReportsList";
            this.lstReportsList.Size = new System.Drawing.Size(310, 272);
            this.lstReportsList.TabIndex = 0;
            // 
            // btnHelp
            // 
            this.btnHelp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnHelp.Image = global::Sepehr.Properties.Resources.Help;
            this.btnHelp.Location = new System.Drawing.Point(230, 290);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F1);
            this.btnHelp.Size = new System.Drawing.Size(92, 60);
            this.btnHelp.TabIndex = 3;
            this.btnHelp.TabStop = false;
            this.btnHelp.Text = "راهنما\r\n(F1)";
            // 
            // btnRefresh
            // 
            this.btnRefresh.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefresh.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnRefresh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnRefresh.Image = global::Sepehr.Properties.Resources.Refresh;
            this.btnRefresh.Location = new System.Drawing.Point(110, 290);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F5);
            this.btnRefresh.Size = new System.Drawing.Size(92, 60);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "بازخوانی\r\n(F5)";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            // 
            // frmList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(334, 362);
            this.Controls.Add(this.PanelForm);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(450, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(350, 400);
            this.Name = "frmList";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "گزارش ها - گزارش های اختصاصی";
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.PanelForm.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel PanelForm;
        private DevComponents.DotNetBar.ButtonX btnHelp;
        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        private DevComponents.DotNetBar.ItemPanel lstReportsList;
        private DevComponents.DotNetBar.ButtonX btnRefresh;
        private DevComponents.DotNetBar.ButtonX btnClose;
    }
}