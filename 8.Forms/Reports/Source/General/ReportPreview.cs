#region using
using System;
using System.Data;
using System.Windows.Forms;
using Negar;
using CrystalDecisions.CrystalReports.Engine;
using DevComponents.DotNetBar;
using Sepehr.Forms.Reports.Properties;
#endregion

namespace Sepehr.Forms.Reports.General
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
            FormCrystalReportViewer.Zoom(txtZoom.Value);
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            SetControlsToolTipTexts();
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
            FormCrystalReportViewer.Zoom(txtZoom.Value);
            txtZoom.ValueChanged += txtZoom_ValueChanged;
        }
        #endregion

        #region txtCurrentPage_ValueChanged
        private void txtCurrentPage_ValueChanged(object sender, EventArgs e)
        {
            FormCrystalReportViewer.Navigate -= FormCrystalReportViewer_Navigate;
            Int32 CurrentPage = FormCrystalReportViewer.GetCurrentPageNumber();
            FormCrystalReportViewer.ShowNthPage(txtCurrentPage.Value);
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

        #region Methods

        #region void SetControlsToolTipTexts()
        /// <summary>
        /// تابع تنظیم متن راهنمای كنترل ها
        /// </summary>
        private void SetControlsToolTipTexts()
        {
            const String TooltipHeader = "راهنمای تنظیمات سیستم";
            const String TooltipFooter = "سیستم مدیریت تصویربرداری سپهر";

            #region btnCancel
            String TooltipText = ToolTipManager.GetText("btnClose", "IMS");
            FormToolTip.SetSuperTooltip(btnCancel, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnNextPage
            TooltipText = ToolTipManager.GetText("btnReportNextPage", "IMS");
            FormToolTip.SetSuperTooltip(btnNextPage, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnPrevPage
            TooltipText = ToolTipManager.GetText("btnReportPrevPage", "IMS");
            FormToolTip.SetSuperTooltip(btnPrevPage, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnFirstPage
            TooltipText = ToolTipManager.GetText("btnReportFirstPage", "IMS");
            FormToolTip.SetSuperTooltip(btnFirstPage, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnLastPage
            TooltipText = ToolTipManager.GetText("btnReportLastPage", "IMS");
            FormToolTip.SetSuperTooltip(btnLastPage, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnRefreshReport
            TooltipText = ToolTipManager.GetText("btnDesignedReportRefreshReport", "IMS");
            FormToolTip.SetSuperTooltip(btnRefreshReport, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnExportReport
            TooltipText = ToolTipManager.GetText("btnDesignedReportExport", "IMS");
            FormToolTip.SetSuperTooltip(btnExportReport, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

        }
        #endregion

        #endregion

    }
}