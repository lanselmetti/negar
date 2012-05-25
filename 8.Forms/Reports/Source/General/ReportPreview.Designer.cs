namespace Sepehr.Forms.Reports.General
{
    partial class frmPublicReportPreview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPublicReportPreview));
            this.lblCurrentPage = new DevComponents.DotNetBar.LabelX();
            this.lblZoom = new DevComponents.DotNetBar.LabelX();
            this.txtCurrentPage = new DevComponents.Editors.IntegerInput();
            this.txtZoom = new DevComponents.Editors.IntegerInput();
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.FontDialogBox = new System.Windows.Forms.FontDialog();
            this.FormCrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.PanelTop = new DevComponents.DotNetBar.PanelEx();
            this.btnExportReport = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnFirstPage = new DevComponents.DotNetBar.ButtonX();
            this.btnLastPage = new DevComponents.DotNetBar.ButtonX();
            this.btnNextPage = new DevComponents.DotNetBar.ButtonX();
            this.btnPrevPage = new DevComponents.DotNetBar.ButtonX();
            this.btnPrintReport = new DevComponents.DotNetBar.ButtonX();
            this.btnRefreshReport = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.txtCurrentPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtZoom)).BeginInit();
            this.PanelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCurrentPage
            // 
            this.lblCurrentPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentPage.AutoSize = true;
            this.lblCurrentPage.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentPage.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblCurrentPage.ForeColor = System.Drawing.Color.Purple;
            this.lblCurrentPage.Location = new System.Drawing.Point(200, 16);
            this.lblCurrentPage.Name = "lblCurrentPage";
            this.lblCurrentPage.Size = new System.Drawing.Size(70, 16);
            this.lblCurrentPage.TabIndex = 9;
            this.lblCurrentPage.Text = "صفحه جاری:";
            // 
            // lblZoom
            // 
            this.lblZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblZoom.AutoSize = true;
            this.lblZoom.BackColor = System.Drawing.Color.Transparent;
            this.lblZoom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblZoom.Location = new System.Drawing.Point(278, 16);
            this.lblZoom.Name = "lblZoom";
            this.lblZoom.Size = new System.Drawing.Size(25, 16);
            this.lblZoom.TabIndex = 7;
            this.lblZoom.Text = "زوم:";
            // 
            // txtCurrentPage
            // 
            this.txtCurrentPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtCurrentPage.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtCurrentPage.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtCurrentPage.Location = new System.Drawing.Point(214, 38);
            this.txtCurrentPage.MaxValue = 100000;
            this.txtCurrentPage.MinValue = 1;
            this.txtCurrentPage.Name = "txtCurrentPage";
            this.txtCurrentPage.ShowUpDown = true;
            this.txtCurrentPage.Size = new System.Drawing.Size(47, 21);
            this.txtCurrentPage.TabIndex = 8;
            this.txtCurrentPage.Value = 1;
            this.txtCurrentPage.ValueChanged += new System.EventHandler(this.txtCurrentPage_ValueChanged);
            // 
            // txtZoom
            // 
            this.txtZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtZoom.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtZoom.Increment = 25;
            this.txtZoom.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtZoom.Location = new System.Drawing.Point(267, 38);
            this.txtZoom.MaxValue = 500;
            this.txtZoom.MinValue = 25;
            this.txtZoom.Name = "txtZoom";
            this.txtZoom.ShowUpDown = true;
            this.txtZoom.Size = new System.Drawing.Size(47, 21);
            this.txtZoom.TabIndex = 8;
            this.txtZoom.Value = 100;
            this.txtZoom.ValueChanged += new System.EventHandler(this.txtZoom_ValueChanged);
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            // 
            // FontDialogBox
            // 
            this.FontDialogBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FontDialogBox.FontMustExist = true;
            // 
            // FormCrystalReportViewer
            // 
            this.FormCrystalReportViewer.ActiveViewIndex = -1;
            this.FormCrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FormCrystalReportViewer.DisplayGroupTree = false;
            this.FormCrystalReportViewer.DisplayStatusBar = false;
            this.FormCrystalReportViewer.DisplayToolbar = false;
            this.FormCrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormCrystalReportViewer.EnableDrillDown = false;
            this.FormCrystalReportViewer.Location = new System.Drawing.Point(0, 80);
            this.FormCrystalReportViewer.Name = "FormCrystalReportViewer";
            this.FormCrystalReportViewer.SelectionFormula = "";
            this.FormCrystalReportViewer.Size = new System.Drawing.Size(784, 484);
            this.FormCrystalReportViewer.TabIndex = 1;
            this.FormCrystalReportViewer.ViewTimeSelectionFormula = "";
            this.FormCrystalReportViewer.Navigate += new CrystalDecisions.Windows.Forms.NavigateEventHandler(this.FormCrystalReportViewer_Navigate);
            // 
            // PanelTop
            // 
            this.PanelTop.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelTop.Controls.Add(this.btnExportReport);
            this.PanelTop.Controls.Add(this.btnCancel);
            this.PanelTop.Controls.Add(this.btnFirstPage);
            this.PanelTop.Controls.Add(this.btnLastPage);
            this.PanelTop.Controls.Add(this.btnNextPage);
            this.PanelTop.Controls.Add(this.btnPrevPage);
            this.PanelTop.Controls.Add(this.btnPrintReport);
            this.PanelTop.Controls.Add(this.btnRefreshReport);
            this.PanelTop.Controls.Add(this.txtCurrentPage);
            this.PanelTop.Controls.Add(this.txtZoom);
            this.PanelTop.Controls.Add(this.lblCurrentPage);
            this.PanelTop.Controls.Add(this.lblZoom);
            this.PanelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelTop.Location = new System.Drawing.Point(0, 0);
            this.PanelTop.Name = "PanelTop";
            this.PanelTop.Size = new System.Drawing.Size(784, 80);
            this.PanelTop.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.PanelTop.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.PanelTop.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.PanelTop.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.PanelTop.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.PanelTop.Style.GradientAngle = 90;
            this.PanelTop.TabIndex = 2;
            // 
            // btnExportReport
            // 
            this.btnExportReport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExportReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportReport.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExportReport.Image = global::Sepehr.Forms.Reports.Properties.Resources.ExportToExcel;
            this.btnExportReport.Location = new System.Drawing.Point(612, 9);
            this.btnExportReport.Name = "btnExportReport";
            this.btnExportReport.Size = new System.Drawing.Size(77, 57);
            this.btnExportReport.TabIndex = 1;
            this.btnExportReport.TabStop = false;
            this.btnExportReport.Text = "تولید خروجی";
            this.btnExportReport.Click += new System.EventHandler(this.btnExportReport_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Sepehr.Forms.Reports.Properties.Resources.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(11, 9);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 57);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "خروج\r\n(Esc)";
            // 
            // btnFirstPage
            // 
            this.btnFirstPage.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnFirstPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFirstPage.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnFirstPage.Image = global::Sepehr.Forms.Reports.Properties.Resources.RightMed2;
            this.btnFirstPage.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnFirstPage.Location = new System.Drawing.Point(477, 9);
            this.btnFirstPage.Name = "btnFirstPage";
            this.btnFirstPage.Size = new System.Drawing.Size(46, 57);
            this.btnFirstPage.TabIndex = 3;
            this.btnFirstPage.TabStop = false;
            this.btnFirstPage.Text = "اولین";
            this.btnFirstPage.Click += new System.EventHandler(this.btnFirstPage_Click);
            // 
            // btnLastPage
            // 
            this.btnLastPage.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLastPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLastPage.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnLastPage.Image = global::Sepehr.Forms.Reports.Properties.Resources.LeftMed2;
            this.btnLastPage.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnLastPage.Location = new System.Drawing.Point(320, 9);
            this.btnLastPage.Name = "btnLastPage";
            this.btnLastPage.Size = new System.Drawing.Size(46, 57);
            this.btnLastPage.TabIndex = 6;
            this.btnLastPage.TabStop = false;
            this.btnLastPage.Text = "آخرین";
            this.btnLastPage.Click += new System.EventHandler(this.btnLastPage_Click);
            // 
            // btnNextPage
            // 
            this.btnNextPage.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnNextPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextPage.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnNextPage.Image = ((System.Drawing.Image)(resources.GetObject("btnNextPage.Image")));
            this.btnNextPage.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnNextPage.Location = new System.Drawing.Point(373, 9);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(46, 57);
            this.btnNextPage.TabIndex = 5;
            this.btnNextPage.TabStop = false;
            this.btnNextPage.Text = "بعدی";
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // btnPrevPage
            // 
            this.btnPrevPage.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPrevPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrevPage.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnPrevPage.Image = ((System.Drawing.Image)(resources.GetObject("btnPrevPage.Image")));
            this.btnPrevPage.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnPrevPage.Location = new System.Drawing.Point(425, 9);
            this.btnPrevPage.Name = "btnPrevPage";
            this.btnPrevPage.Size = new System.Drawing.Size(46, 57);
            this.btnPrevPage.TabIndex = 4;
            this.btnPrevPage.TabStop = false;
            this.btnPrevPage.Text = "قبلی";
            this.btnPrevPage.Click += new System.EventHandler(this.btnPrevPage_Click);
            // 
            // btnPrintReport
            // 
            this.btnPrintReport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPrintReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintReport.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnPrintReport.Image = global::Sepehr.Forms.Reports.Properties.Resources.PrintGrid;
            this.btnPrintReport.Location = new System.Drawing.Point(695, 9);
            this.btnPrintReport.Name = "btnPrintReport";
            this.btnPrintReport.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnPrintReport.Size = new System.Drawing.Size(77, 57);
            this.btnPrintReport.TabIndex = 0;
            this.btnPrintReport.TabStop = false;
            this.btnPrintReport.Text = "چاپ گزارش (F8)";
            this.btnPrintReport.Click += new System.EventHandler(this.btnPrintReport_Click);
            // 
            // btnRefreshReport
            // 
            this.btnRefreshReport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRefreshReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshReport.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnRefreshReport.Image = global::Sepehr.Forms.Reports.Properties.Resources.Refresh;
            this.btnRefreshReport.Location = new System.Drawing.Point(529, 9);
            this.btnRefreshReport.Name = "btnRefreshReport";
            this.btnRefreshReport.Size = new System.Drawing.Size(77, 57);
            this.btnRefreshReport.TabIndex = 2;
            this.btnRefreshReport.TabStop = false;
            this.btnRefreshReport.Text = "تازه كردن گزارش";
            this.btnRefreshReport.Click += new System.EventHandler(this.btnRefreshReport_Click);
            // 
            // frmPublicReportPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(784, 564);
            this.Controls.Add(this.FormCrystalReportViewer);
            this.Controls.Add(this.PanelTop);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmPublicReportPreview";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "نمایش ساختار گزارش تولید شده";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.txtCurrentPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtZoom)).EndInit();
            this.PanelTop.ResumeLayout(false);
            this.PanelTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        private System.Windows.Forms.FontDialog FontDialogBox;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer FormCrystalReportViewer;
        private DevComponents.Editors.IntegerInput txtZoom;
        private DevComponents.DotNetBar.LabelX lblZoom;
        private DevComponents.DotNetBar.LabelX lblCurrentPage;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnExportReport;
        private DevComponents.DotNetBar.ButtonX btnRefreshReport;
        private DevComponents.DotNetBar.ButtonX btnPrintReport;
        private DevComponents.DotNetBar.ButtonX btnLastPage;
        private DevComponents.DotNetBar.ButtonX btnNextPage;
        private DevComponents.DotNetBar.ButtonX btnPrevPage;
        private DevComponents.DotNetBar.ButtonX btnFirstPage;
        private DevComponents.Editors.IntegerInput txtCurrentPage;
        private DevComponents.DotNetBar.PanelEx PanelTop;
    }
}