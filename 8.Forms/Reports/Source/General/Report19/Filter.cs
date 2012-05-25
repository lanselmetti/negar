#region using
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negar;
using Negar.DBLayerPMS.DataLayer;
using Negar.PersianCalendar.Utilities;
using CrystalDecisions.CrystalReports.Engine;
using DevComponents.DotNetBar;
using Sepehr.Forms.Reports.Properties;
#endregion

namespace Sepehr.Forms.Reports.General.Report19
{
    /// <summary>
    /// فرم فیلتر گزارش های قابل طراحی
    /// </summary>
    public partial class frmFilter : Form
    {

        #region Fields & Properties

        #region SqlCommand _ReportSqlCommand
        private SqlCommand _ReportSqlCommand;
        #endregion

        #region DataTable _ReportDataTable
        private DataTable _ReportDataTable;
        #endregion

        #region List<SP_SelectRefPhysiciansFullDataListResult> _RefPhysiciansDataSource
        /// <summary>
        /// منبع داده پزشكان درخواست كننده
        /// </summary>
        private List<SP_SelectRefPhysiciansFullDataListResult> _RefPhysiciansDataSource;
        #endregion

        #region Boolean _CalcReportRowCount
        /// <summary>
        /// تعیین محاسبه تعداد ردیف های نتیجه گزارش
        /// </summary>
        private Boolean _CalcReportRowCount;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmFilter()
        {
            InitializeComponent();
            dgvRefPhysician.AutoGenerateColumns = false;
            dgvServiceCat.AutoGenerateColumns = false;
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            #region Set DateTime.Now
            PersianDate PersianMonthBeginDate = DateTime.Now.ToPersianDate();
            PersianMonthBeginDate.Day = 1;
            DateTime GregorianMonthBeginDate = PersianMonthBeginDate.ToGregorianDateTime();
            FromDateRef.SelectedDateTime = GregorianMonthBeginDate;
            ToDateRef.SelectedDateTime = DateTime.Now;
            FromTimeRef.Value = new DateTime(2000, 1, 1, 0, 0, 0);
            ToTimeRef.Value = new DateTime(2000, 1, 1, 23, 59, 59);
            #endregion
            SetControlsToolTipTexts();
        }
        #endregion

        #region cBoxRefPhysycian_CheckedChanged
        private void cBoxRefPhysycian_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxRefPhysycian.Checked)
            {
                if (_RefPhysiciansDataSource == null)
                    try
                    {
                        _RefPhysiciansDataSource =
                            Negar.DBLayerPMS.Manager.DBML.SP_SelectRefPhysiciansFullDataList().ToList();
                    }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage = "امكان خواندن اطلاعات پزشكان درخواست كننده وجود ندارد.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Sepehr", "Reports Forms", Ex.Message + "\n" +
                            Ex.StackTrace, EventLogEntryType.Error); cBoxRefPhysycian.Checked = false; return;
                    }
                    #endregion
                dgvRefPhysician.DataSource = _RefPhysiciansDataSource;
            }
            else dgvRefPhysician.DataSource = null;
        }
        #endregion

        #region cBoxServiceCat_CheckedChanged
        private void cBoxServiceCat_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxServiceCat.Checked)
                dgvServiceCat.DataSource = DBLayerIMS.Services.ServCategoriesList;
            else dgvServiceCat.DataSource = null;
        }
        #endregion

        #region cBoxLimitation_CheckedChanged
        private void cBoxLimitation_CheckedChanged(object sender, EventArgs e)
        {
            txtLimitation.Enabled = cBoxLimitation.Checked;
        }
        #endregion

        #region btnReport_Click
        private void btnReport_Click(object sender, EventArgs e)
        {
            if (sender.GetType().Equals(typeof(Boolean))) _CalcReportRowCount = true;
            else _CalcReportRowCount = false;
            dgvServiceCat.EndEdit();
            btnReport.Focus();
            if (!GenerateReportString()) return;
            btnReport.Enabled = false;
            ProgressBar.Text = "در حال تولید گزارش...";
            ProgressBar.ProgressType = eProgressItemType.Marquee;
            BGWorker.RunWorkerAsync();
        }
        #endregion

        #region BGWorker_DoWork
        private void BGWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            _ReportDataTable = new DataTable();
            try
            {
                _ReportSqlCommand.Connection.Open();
                // ReSharper disable AssignNullToNotNullAttribute
                _ReportDataTable.Load(_ReportSqlCommand.ExecuteReader());
                // ReSharper restore AssignNullToNotNullAttribute
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان تولید اطلاعات گزارش بر اساس شروط وارد شده وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه فعال می باشد؟\n" +
                    "2. آیا برای كادر پزشكی انتخاب شده ، پزشك یا كارشناسی انتخاب كرده اید؟\n" +
                    "3. آیا برای فیلتر های اصلی انتخاب شده ، آیتمی انتخاب نموده اید؟\n";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Reports Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                e.Cancel = true;
                BGWorker.CancelAsync();
                return;
            }
            #endregion
            finally { _ReportSqlCommand.Connection.Close(); }
        }
        #endregion

        #region BGWorker_RunWorkerCompleted
        private void BGWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (_CalcReportRowCount)
            {
                if (_ReportDataTable != null && _ReportDataTable.Rows.Count != 0)
                    PMBox.Show("تعداد ردیف های نتیجه گزارش:\n" + _ReportDataTable.Rows[0][0],
                        "تعداد ردیف های گزارش", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (!e.Cancelled)
                {
                    #region Make Report
                    Report19 MyReport = new Report19();
                    if (!String.IsNullOrEmpty(txtReportTitle.Text))
                        ((TextObject)MyReport.Section2.ReportObjects["txtTitle"]).Text = txtReportTitle.Text;
                    PersianDate DateVal1 = new DateTime(FromDateRef.SelectedDateTime.Value.Year,
                        FromDateRef.SelectedDateTime.Value.Month, FromDateRef.SelectedDateTime.Value.Day,
                        FromTimeRef.Value.Hour, FromTimeRef.Value.Minute, FromTimeRef.Value.Second).ToPersianDate();
                    ((TextObject)MyReport.Section2.ReportObjects["txtBeginDate"]).Text =
                        DateVal1.Year + "/" + DateVal1.Month + "/" + DateVal1.Day + " - " +
                        DateVal1.Hour + ":" + DateVal1.Minute + ":" + DateVal1.Second;
                    PersianDate DateVal2 = new DateTime(ToDateRef.SelectedDateTime.Value.Year,
                        ToDateRef.SelectedDateTime.Value.Month, ToDateRef.SelectedDateTime.Value.Day,
                        ToTimeRef.Value.Hour, ToTimeRef.Value.Minute, ToTimeRef.Value.Second).ToPersianDate();
                    ((TextObject)MyReport.Section2.ReportObjects["txtEndDate"]).Text =
                        DateVal2.Year + "/" + DateVal2.Month + "/" + DateVal2.Day + " - " +
                        DateVal2.Hour + ":" + DateVal2.Minute + ":" + DateVal2.Second;
                    ((TextObject)MyReport.Section5.ReportObjects["txtPrintDate"]).Text =
                        DateTime.Now.ToPersianDate().ToWritten() + " - " +
                        DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
                    #endregion
                    new frmPublicReportPreview(_ReportDataTable, MyReport);
                }
            }
            ProgressBar.Text = "در انتظار ایجاد گزارش";
            ProgressBar.ProgressType = eProgressItemType.Standard;
            btnReport.Enabled = true;
            BringToFront();
            Focus();
        }
        #endregion

        #region btnHelp_Click
        /// <summary>
        /// روال نمایش راهنمایی برای فرم
        /// </summary>
        private void btnHelp_Click(object sender, EventArgs e)
        {
            btnReport_Click(true, null);
        }
        #endregion

        #region btnCancel_Click
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (BGWorker.IsBusy)
            {
                BGWorker.CancelAsync();
                btnReport.Enabled = true;
            }
            else DialogResult = DialogResult.Cancel;
        }
        #endregion

        #region Form_Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            Dispose();
            GC.Collect();
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

            #region btnHelp
            String TooltipText = ToolTipManager.GetText("btnHelp", "IMS");
            FormToolTip.SetSuperTooltip(btnHelp, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnCancel
            TooltipText = ToolTipManager.GetText("btnClose", "IMS");
            FormToolTip.SetSuperTooltip(btnCancel, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnReport
            TooltipText = ToolTipManager.GetText("btnDesignedReportGenerate", "IMS");
            FormToolTip.SetSuperTooltip(btnReport, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion
        }
        #endregion

        #region Boolean GenerateReportString()
        /// <summary>
        /// تابع تولید فرمان جستجوی گزارش
        /// </summary>
        /// <returns>صحت انجام كار</returns>
        private Boolean GenerateReportString()
        {
            #region Prepare SqlConnection & SqlCommand
            SqlConnection MyConnection = new SqlConnection(CSManager.GetConnectionString("PatientsSystem"));
            _ReportSqlCommand = new SqlCommand();
            _ReportSqlCommand.CommandTimeout = 0;
            _ReportSqlCommand.Connection = MyConnection;
            #endregion

            #region Step 1 - SELECT Columns & INNER JOINs
            StringBuilder ReportSelectString = new StringBuilder();
            ReportSelectString.Append("SELECT " +
                "ISNULL((SELECT TOP 1 ISNULL([TblRefPhys].[FirstName] + ' ' , '') + [TblRefPhys].[LastName] + " +
                "ISNULL(' - ' + [TblRefPhys].[MedicalID] , '') FROM [PatientsSystem].[Clinic].[RefPhysicians] AS [TblRefPhys] " +
                "WHERE [TblRefPhys].[ID] = [TblRefList].[ReferPhysicianIX]) , '(فاقد پزشك)') AS [RefPhysName] , " +
                "ISNULL((SELECT TOP 1 [TblServiceCat].[Name] FROM [ImagingSystem].[Services].[Categories] AS [TblServiceCat] " +
                "WHERE [TblServiceCat].[ID] = [TblServList].[CategoryIX]) , '(فاقد طبقه بندی)') AS [ServCatName] , " +
                "(SELECT COUNT(*) FROM [ImagingSystem].[Referrals].[List] AS [TblRef] " +
                "WHERE [TblRef].[RegisterDate] >= @RefDateBegin " +
                "AND [TblRef].[RegisterDate] <= @RefDateEnd " +
                "AND [TblRef].[ReferPhysicianIX] = [TblRefList].[ReferPhysicianIX] " +
                "AND (SELECT COUNT(*) FROM [ImagingSystem].[Referrals].[RefServices] AS [TblServ] " +
                "INNER JOIN [ImagingSystem].[Services].[List] AS [ServList] " +
                "ON [TblServ].[ServiceIX] = [ServList].[ID] " +
                "WHERE [TblServ].[ReferralIX] = [TblRef].[ID] AND [TblServ].[IsActive] = 1 AND " +
                "[ServList].[CategoryIX] = [TblServList].[CategoryIX]) > 0) AS [RefCount], " +
                "SUM([TblRefService].[Quantity]) AS [ServQty] , " +
                "SUM(ISNULL([TblRefService].[PatientPayablePrice] , 0) * [TblRefService].[Quantity]) AS [PatPayablePrice], " +
                "SUM(ISNULL([TblRefService].[Ins1PartPrice] , 0) * [TblRefService].[Quantity]) AS [Ins1Part], " +
                "SUM(ISNULL([TblRefService].[Ins2PartPrice] , 0) * [TblRefService].[Quantity]) AS [Ins2Part] " +
                "FROM [ImagingSystem].[Referrals].[RefServices] AS [TblRefService] " +
                "INNER JOIN [ImagingSystem].[Services].[List] AS [TblServList] " +
                "ON [TblRefService].[ServiceIX] = [TblServList].[ID] " +
                "INNER JOIN [ImagingSystem].[Referrals].[List] AS [TblRefList] " +
                "ON [TblRefList].[ID] = [TblRefService].[ReferralIX] ");
            #endregion

            #region Step 2 - Add WHERE SELECT
            StringBuilder ReportSelectWhereString = new StringBuilder();

            #region RefTime And RefService Active
            #region Set SqlParams
            SqlParameter Param1 = new SqlParameter("@RefDateBegin", SqlDbType.DateTime);
            Param1.Value = new DateTime(FromDateRef.SelectedDateTime.Value.Year,
                FromDateRef.SelectedDateTime.Value.Month, FromDateRef.SelectedDateTime.Value.Day,
                FromTimeRef.Value.Hour, FromTimeRef.Value.Minute, FromTimeRef.Value.Second);
            SqlParameter Param2 = new SqlParameter("@RefDateEnd", SqlDbType.DateTime);
            Param2.Value = new DateTime(ToDateRef.SelectedDateTime.Value.Year,
                ToDateRef.SelectedDateTime.Value.Month, ToDateRef.SelectedDateTime.Value.Day,
                ToTimeRef.Value.Hour, ToTimeRef.Value.Minute, ToTimeRef.Value.Second);
            _ReportSqlCommand.Parameters.Add(Param1);
            _ReportSqlCommand.Parameters.Add(Param2);
            #endregion
            ReportSelectWhereString.Append(
                "WHERE [TblRefList].[RegisterDate] >= @RefDateBegin AND [TblRefList].[RegisterDate] <= @RefDateEnd " +
                "AND [TblRefService].[IsActive] = 1 AND [TblRefList].[ReferPhysicianIX] IS NOT NULL ");
            #endregion

            #region Set Ref Physicians Filter
            if (cBoxRefPhysycian.Checked)
            {
                Boolean IsAnySelected = false;
                if (Convert.ToBoolean(dgvRefPhysician.Rows[0].Cells[0].Value))
                {
                    ReportSelectWhereString.Append(" AND ([TblRefList].[ReferPhysicianIX] IS NULL ");
                    IsAnySelected = true;
                }
                foreach (DataGridViewRow row in dgvRefPhysician.Rows)
                {
                    if (row.Index == 0 || row.Cells[ColRefPhysicianSelection.Index].Value == null ||
                        Convert.ToBoolean(row.Cells[ColRefPhysicianSelection.Index].Value) == false) continue;
                    if (IsAnySelected) ReportSelectWhereString.Append(" OR");
                    else ReportSelectWhereString.Append(" AND (");
                    ReportSelectWhereString.Append(" [TblRefList].[ReferPhysicianIX] = " +
                        ((SP_SelectRefPhysiciansFullDataListResult)row.DataBoundItem).ID + " ");
                    IsAnySelected = true;
                }
                ReportSelectWhereString.Append(") ");
            }
            #endregion

            #region Set Categories Filter
            if (cBoxServiceCat.Checked)
            {
                Boolean IsAnySelected = false;
                if (Convert.ToBoolean(dgvServiceCat.Rows[0].Cells[0].Value))
                {
                    ReportSelectWhereString.Append(" AND ([TblServList].[CategoryIX] IS NULL ");
                    IsAnySelected = true;
                }
                String SelectedID = String.Empty;
                foreach (DataGridViewRow Row in dgvServiceCat.Rows)
                    if (Row.Index != 0 && Row.Cells[ColCatSelection.Name].Value != null &&
                        Convert.ToBoolean(Row.Cells[ColCatSelection.Name].Value))
                        SelectedID += ((DBLayerIMS.DataLayer.SP_SelectCategoriesResult)Row.DataBoundItem).ID + " , ";
                // اگر موردی انتخاب شده باشد
                if (!String.IsNullOrEmpty(SelectedID))
                {
                    if (IsAnySelected) ReportSelectWhereString.Append(" OR");
                    else ReportSelectWhereString.Append(" AND (");
                    // حذف آخرین ویرگول از لیست
                    SelectedID = SelectedID.Substring(0, SelectedID.Length - 3);
                    ReportSelectWhereString.Append(" [TblServList].[CategoryIX] IN (" + SelectedID + ")");
                }
                ReportSelectWhereString.Append(") ");
            }
            #endregion

            #endregion

            #region Step 3 - Add GROUP BY & ORDER BY
            ReportSelectWhereString.Append("GROUP BY [TblServList].[CategoryIX] , [TblRefList].[ReferPhysicianIX] ");

            #region Set Limitation Filter
            if (cBoxLimitation.Checked)
                ReportSelectWhereString.Append("HAVING (SELECT COUNT(*) FROM [ImagingSystem].[Referrals].[List] AS [TblRef] " +
                "WHERE [TblRef].[RegisterDate] >= @RefDateBegin " +
                "AND [TblRef].[RegisterDate] <= @RefDateEnd " +
                "AND [TblRef].[ReferPhysicianIX] = [TblRefList].[ReferPhysicianIX] " +
                "AND (SELECT COUNT(*) FROM [ImagingSystem].[Referrals].[RefServices] AS [TblServ] " +
                "INNER JOIN [ImagingSystem].[Services].[List] AS [ServList] " +
                "ON [TblServ].[ServiceIX] = [ServList].[ID] " +
                "WHERE [TblServ].[ReferralIX] = [TblRef].[ID] AND [TblServ].[IsActive] = 1 AND " +
                "[ServList].[CategoryIX] = [TblServList].[CategoryIX]) > 0) >= " + txtLimitation.Value + " ");
            #endregion

            if (!_CalcReportRowCount)
                ReportSelectWhereString.Append("ORDER BY [RefCount] DESC;");
            #endregion

            _ReportSqlCommand.CommandText = ReportSelectString.Append(ReportSelectWhereString).ToString();
            if (_CalcReportRowCount)
                _ReportSqlCommand.CommandText = "SELECT COUNT (*) FROM (" + _ReportSqlCommand.CommandText + ") AS TBL";
            return true;
        }
        #endregion

        #endregion

    }
}