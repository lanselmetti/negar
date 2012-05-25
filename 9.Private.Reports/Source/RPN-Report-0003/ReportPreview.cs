#region using
using System;
using System.Data;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
#endregion

namespace Negar.Customers.Reports0003
{
    /// <summary>
    /// فرم نمایش اطلاعات گزارش های قابل طراحی
    /// </summary>
    internal partial class frmPublicReportPreview : Form
    {
        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmPublicReportPreview(DataTable ReportDataTable, ReportDocument FormReportClass)
        {
            InitializeComponent();
            if (ReportDataTable != null) FormReportClass.SetDataSource(ReportDataTable);
            FormCrystalReportViewer.ReportSource = FormReportClass;
            FormCrystalReportViewer.Zoom(Convert.ToInt32(txtZoom.Value));
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            BringToFront();
            Focus();
        }
        #endregion

        #region btnPrintReport_Click
        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            FormCrystalReportViewer.PrintReport();
        }
        #endregion

        #region btnRefreshReport_Click
        private void btnRefreshReport_Click(object sender, EventArgs e)
        {
            FormCrystalReportViewer.RefreshReport();
        }
        #endregion

        #region btnExportReport_Click
        private void btnExportReport_Click(object sender, EventArgs e)
        {
            FormCrystalReportViewer.ExportReport();
        }
        #endregion

        #region btnFirstPage_Click
        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            FormCrystalReportViewer.ShowFirstPage();
        }
        #endregion

        #region btnLastPage_Click
        private void btnLastPage_Click(object sender, EventArgs e)
        {
            FormCrystalReportViewer.ShowLastPage();
        }
        #endregion

        #region btnPrevPage_Click
        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            FormCrystalReportViewer.ShowPreviousPage();
        }
        #endregion

        #region btnNextPage_Click
        private void btnNextPage_Click(object sender, EventArgs e)
        {
            FormCrystalReportViewer.ShowNextPage();
        }
        #endregion

        #region txtZoom_ValueChanged
        private void txtZoom_ValueChanged(object sender, EventArgs e)
        {
            txtZoom.ValueChanged -= txtZoom_ValueChanged;
            FormCrystalReportViewer.Zoom(Convert.ToInt32(txtZoom.Value));
            txtZoom.ValueChanged += txtZoom_ValueChanged;
        }
        #endregion

        #region txtCurrentPage_ValueChanged
        private void txtCurrentPage_ValueChanged(object sender, EventArgs e)
        {
            FormCrystalReportViewer.Navigate -= FormCrystalReportViewer_Navigate;
            Int32 CurrentPage = FormCrystalReportViewer.GetCurrentPageNumber();
            FormCrystalReportViewer.ShowNthPage(Convert.ToInt32(txtCurrentPage.Value));
            if (CurrentPage == FormCrystalReportViewer.GetCurrentPageNumber())
            {
                txtCurrentPage.ValueChanged -= txtCurrentPage_ValueChanged;
                txtCurrentPage.Value = CurrentPage;
                txtCurrentPage.ValueChanged += txtCurrentPage_ValueChanged;
            }
            FormCrystalReportViewer.Navigate += FormCrystalReportViewer_Navigate;
        }
        #endregion

        #region FormCrystalReportViewer_Navigate
        private void FormCrystalReportViewer_Navigate(object source, CrystalDecisions.Windows.Forms.NavigateEventArgs e)
        {
            if (e.NewPageNumber != 0)
            {
                txtCurrentPage.ValueChanged -= txtCurrentPage_ValueChanged;
                txtCurrentPage.Value = e.NewPageNumber;
                txtCurrentPage.ValueChanged += txtCurrentPage_ValueChanged;
            }
        }
        #endregion

        #region Form_Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            Dispose();
        }
        #endregion

        #endregion

    }
}
