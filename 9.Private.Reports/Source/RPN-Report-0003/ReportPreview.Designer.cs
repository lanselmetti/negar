namespace Negar.Customers.Reports0003
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
            this.lblCurrentPage = new System.Windows.Forms.Label();
            this.lblZoom = new System.Windows.Forms.Label();
            this.FontDialogBox = new System.Windows.Forms.FontDialog();
            this.FormCrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.PanelTop = new System.Windows.Forms.Panel();
            this.txtCurrentPage = new System.Windows.Forms.NumericUpDown();
            this.txtZoom = new System.Windows.Forms.NumericUpDown();
            this.btnExportReport = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnFirstPage = new System.Windows.Forms.Button();
            this.btnLastPage = new System.Windows.Forms.Button();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.btnPrevPage = new System.Windows.Forms.Button();
            this.btnPrintReport = new System.Windows.Forms.Button();
            this.btnRefreshReport = new System.Windows.Forms.Button();
            this.PanelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCurrentPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtZoom)).BeginInit();
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
            this.lblCurrentPage.Size = new System.Drawing.Size(72, 13);
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
            this.lblZoom.Size = new System.Drawing.Size(28, 13);
            this.lblZoom.TabIndex = 7;
            this.lblZoom.Text = "زوم:";
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
            this.FormCrystalReportViewer.TabIndex = 0;
            this.FormCrystalReportViewer.ViewTimeSelectionFormula = "";
            this.FormCrystalReportViewer.Navigate += new CrystalDecisions.Windows.Forms.NavigateEventHandler(this.FormCrystalReportViewer_Navigate);
            // 
            // PanelTop
            // 
            this.PanelTop.BackColor = System.Drawing.Color.Transparent;
            this.PanelTop.Controls.Add(this.txtCurrentPage);
            this.PanelTop.Controls.Add(this.txtZoom);
            this.PanelTop.Controls.Add(this.btnExportReport);
            this.PanelTop.Controls.Add(this.btnCancel);
            this.PanelTop.Controls.Add(this.btnFirstPage);
            this.PanelTop.Controls.Add(this.btnLastPage);
            this.PanelTop.Controls.Add(this.btnNextPage);
            this.PanelTop.Controls.Add(this.btnPrevPage);
            this.PanelTop.Controls.Add(this.btnPrintReport);
            this.PanelTop.Controls.Add(this.btnRefreshReport);
            this.PanelTop.Controls.Add(this.lblCurrentPage);
            this.PanelTop.Controls.Add(this.lblZoom);
            this.PanelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelTop.Location = new System.Drawing.Point(0, 0);
            this.PanelTop.Name = "PanelTop";
            this.PanelTop.Size = new System.Drawing.Size(784, 80);
            this.PanelTop.TabIndex = 1;
            // 
            // txtCurrentPage
            // 
            this.txtCurrentPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCurrentPage.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtCurrentPage.Location = new System.Drawing.Point(214, 38);
            this.txtCurrentPage.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.txtCurrentPage.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtCurrentPage.Name = "txtCurrentPage";
            this.txtCurrentPage.Size = new System.Drawing.Size(47, 21);
            this.txtCurrentPage.TabIndex = 10;
            this.txtCurrentPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCurrentPage.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.txtCurrentPage.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtCurrentPage.ValueChanged += new System.EventHandler(this.txtCurrentPage_ValueChanged);
            // 
            // txtZoom
            // 
            this.txtZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtZoom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtZoom.Increment = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.txtZoom.Location = new System.Drawing.Point(267, 38);
            this.txtZoom.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.txtZoom.Minimum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.txtZoom.Name = "txtZoom";
            this.txtZoom.Size = new System.Drawing.Size(47, 21);
            this.txtZoom.TabIndex = 8;
            this.txtZoom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtZoom.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.txtZoom.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.txtZoom.ValueChanged += new System.EventHandler(this.txtZoom_ValueChanged);
            // 
            // btnExportReport
            // 
            this.btnExportReport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExportReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportReport.Image = global::Negar.Customers.Reports0003.Properties.Resources.ExportToExcel;
            this.btnExportReport.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExportReport.Location = new System.Drawing.Point(612, 9);
            this.btnExportReport.Name = "btnExportReport";
            this.btnExportReport.Size = new System.Drawing.Size(77, 57);
            this.btnExportReport.TabIndex = 1;
            this.btnExportReport.TabStop = false;
            this.btnExportReport.Text = "تولید خروجی";
            this.btnExportReport.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExportReport.Click += new System.EventHandler(this.btnExportReport_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Negar.Customers.Reports0003.Properties.Resources.Cancel;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(11, 9);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 57);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "خروج\r\n(Esc)";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnFirstPage
            // 
            this.btnFirstPage.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnFirstPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFirstPage.Image = global::Negar.Customers.Reports0003.Properties.Resources.RightMed2;
            this.btnFirstPage.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFirstPage.Location = new System.Drawing.Point(477, 9);
            this.btnFirstPage.Name = "btnFirstPage";
            this.btnFirstPage.Size = new System.Drawing.Size(46, 57);
            this.btnFirstPage.TabIndex = 3;
            this.btnFirstPage.TabStop = false;
            this.btnFirstPage.Text = "اولین";
            this.btnFirstPage.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFirstPage.Click += new System.EventHandler(this.btnFirstPage_Click);
            // 
            // btnLastPage
            // 
            this.btnLastPage.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLastPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLastPage.Image = global::Negar.Customers.Reports0003.Properties.Resources.LeftMed2;
            this.btnLastPage.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLastPage.Location = new System.Drawing.Point(320, 9);
            this.btnLastPage.Name = "btnLastPage";
            this.btnLastPage.Size = new System.Drawing.Size(46, 57);
            this.btnLastPage.TabIndex = 6;
            this.btnLastPage.TabStop = false;
            this.btnLastPage.Text = "آخرین";
            this.btnLastPage.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLastPage.Click += new System.EventHandler(this.btnLastPage_Click);
            // 
            // btnNextPage
            // 
            this.btnNextPage.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnNextPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextPage.Image = global::Negar.Customers.Reports0003.Properties.Resources.LeftSmall2;
            this.btnNextPage.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNextPage.Location = new System.Drawing.Point(373, 9);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(46, 57);
            this.btnNextPage.TabIndex = 5;
            this.btnNextPage.TabStop = false;
            this.btnNextPage.Text = "صفحه\r\nبعدی";
            this.btnNextPage.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // btnPrevPage
            // 
            this.btnPrevPage.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPrevPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrevPage.Image = global::Negar.Customers.Reports0003.Properties.Resources.RightSmall2;
            this.btnPrevPage.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPrevPage.Location = new System.Drawing.Point(425, 9);
            this.btnPrevPage.Name = "btnPrevPage";
            this.btnPrevPage.Size = new System.Drawing.Size(46, 57);
            this.btnPrevPage.TabIndex = 4;
            this.btnPrevPage.TabStop = false;
            this.btnPrevPage.Text = "صفحه\r\nقبلی";
            this.btnPrevPage.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPrevPage.Click += new System.EventHandler(this.btnPrevPage_Click);
            // 
            // btnPrintReport
            // 
            this.btnPrintReport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPrintReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintReport.Image = global::Negar.Customers.Reports0003.Properties.Resources.PrintGrid;
            this.btnPrintReport.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPrintReport.Location = new System.Drawing.Point(695, 9);
            this.btnPrintReport.Name = "btnPrintReport";
            this.btnPrintReport.Size = new System.Drawing.Size(77, 57);
            this.btnPrintReport.TabIndex = 0;
            this.btnPrintReport.TabStop = false;
            this.btnPrintReport.Text = "چاپ گزارش";
            this.btnPrintReport.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPrintReport.Click += new System.EventHandler(this.btnPrintReport_Click);
            // 
            // btnRefreshReport
            // 
            this.btnRefreshReport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRefreshReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshReport.Image = global::Negar.Customers.Reports0003.Properties.Resources.Refresh;
            this.btnRefreshReport.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRefreshReport.Location = new System.Drawing.Point(529, 9);
            this.btnRefreshReport.Name = "btnRefreshReport";
            this.btnRefreshReport.Size = new System.Drawing.Size(77, 57);
            this.btnRefreshReport.TabIndex = 2;
            this.btnRefreshReport.TabStop = false;
            this.btnRefreshReport.Text = "تازه كردن";
            this.btnRefreshReport.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRefreshReport.Click += new System.EventHandler(this.btnRefreshReport_Click);
            // 
            // frmPublicReportPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
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
            this.PanelTop.ResumeLayout(false);
            this.PanelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCurrentPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtZoom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FontDialog FontDialogBox;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer FormCrystalReportViewer;

        private System.Windows.Forms.Label lblZoom;
        private System.Windows.Forms.Label lblCurrentPage;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnExportReport;
        private System.Windows.Forms.Button btnRefreshReport;
        private System.Windows.Forms.Button btnPrintReport;
        private System.Windows.Forms.Button btnLastPage;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Button btnPrevPage;
        private System.Windows.Forms.Button btnFirstPage;
        private System.Windows.Forms.Panel PanelTop;
        private System.Windows.Forms.NumericUpDown txtZoom;
        private System.Windows.Forms.NumericUpDown txtCurrentPage;
    }
}