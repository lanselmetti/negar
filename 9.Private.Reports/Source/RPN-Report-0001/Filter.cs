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
using Sepehr.DBLayerIMS.DataLayer;
#endregion

namespace Negar.Customers.Reports0001
{
    /// <summary>
    /// فرم فیلتر گزارش های قابل طراحی
    /// </summary>
    public partial class frmFilter : Form
    {

        #region Fields & Properties

        #region List<SP_SelectRefPhysiciansFullDataListResult> _RefPhysFullList
        /// <summary>
        /// لیست پزشكان ارجاع دهنده
        /// </summary>
        private List<SP_SelectRefPhysiciansFullDataListResult> _RefPhysFullList;
        #endregion

        #region SqlCommand _ReportSqlCommand
        /// <summary>
        /// شیء فرمان ارتباط با بانك اطلاعاتی
        /// </summary>
        private SqlCommand _ReportSqlCommand;
        #endregion

        #region DataTable _ReportDataTable
        /// <summary>
        /// جدول اطلاعات تولید شده از گزارش
        /// </summary>
        private DataTable _ReportDataTable;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmFilter()
        {
            InitializeComponent();
            dgvInsFilter.AutoGenerateColumns = false;
            dgvServiceCat.AutoGenerateColumns = false;
            dgvPhysicians.AutoGenerateColumns = false;
            dgvRefPhys.AutoGenerateColumns = false;
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void frmInsurancesFilter_Shown(object sender, EventArgs e)
        {
            #region Set DateTime.Now
            PersianDate PersianMonthBeginDate = DateTime.Now.ToPersianDate();
            PersianMonthBeginDate.Day = 1;
            DateTime GregorianMonthBeginDate = PersianMonthBeginDate.ToGregorianDateTime();
            FromDateRef.SelectedDateTime = GregorianMonthBeginDate;
            TransDateFrom.SelectedDateTime = GregorianMonthBeginDate;
            ToDateRef.SelectedDateTime = DateTime.Now;
            TransDateTo.SelectedDateTime = DateTime.Now;
            FromTimeRef.Value = new DateTime(2000, 1, 1, 0, 0, 0);
            TransTimeFrom.Value = new DateTime(2000, 1, 1, 0, 0, 0);
            ToTimeRef.Value = new DateTime(2000, 1, 1, 23, 59, 59);
            TransTimeTo.Value = new DateTime(2000, 1, 1, 23, 59, 59);
            #endregion
        }
        #endregion

        #region cBoxTransDateFilter_CheckedChanged
        private void cBoxTransDateFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxTransDateFilter.Checked)
            {
                PanelRefDateTimeFilter.Enabled = false;
                PanelTransDateTimeFilter.Enabled = true;
            }
            else
            {
                PanelRefDateTimeFilter.Enabled = true;
                PanelTransDateTimeFilter.Enabled = false;
            }
        }
        #endregion

        #region cBoxIns1_CheckedChanged
        private void cBoxIns1_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxIns1.Checked) dgvInsFilter.DataSource =
                Sepehr.DBLayerIMS.Insurance.InsFullList.Where(Data => Data.IsActive == true).ToList();
            else dgvInsFilter.DataSource = null;
        }
        #endregion

        #region cBoxServiceCat_CheckedChanged
        private void cBoxServiceCat_CheckedChanged(object sender, EventArgs e)
        {
            cBoxService.CheckedChanged -= cBoxServiceCat_CheckedChanged;
            cBoxServiceCat.CheckedChanged -= cBoxServiceCat_CheckedChanged;
            if (((CheckBox)sender).Name.Equals(cBoxServiceCat.Name) && cBoxServiceCat.Checked)
            {
                cBoxService.Checked = false;
                dgvServiceCat.DataSource = Sepehr.DBLayerIMS.Services.ServCategoriesList.Where(Data => Data.ID != null).ToList();
            }
            else if (((CheckBox)sender).Name.Equals(cBoxService.Name) && cBoxService.Checked)
            {
                cBoxServiceCat.Checked = false;
                dgvServiceCat.DataSource = Sepehr.DBLayerIMS.Services.ServicesList.Where(Data => Data.IsActive).ToList();
            }
            else dgvServiceCat.DataSource = null;
            cBoxService.CheckedChanged += cBoxServiceCat_CheckedChanged;
            cBoxServiceCat.CheckedChanged += cBoxServiceCat_CheckedChanged;
        }
        #endregion

        #region cBoxPhys_CheckedChanged
        private void cBoxPhys_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxPhys.Checked) dgvPhysicians.DataSource =
                Sepehr.DBLayerIMS.Referrals.RefServPerformers.Where(Data => Data.ID != null && Data.IsActive == true &&
                    Data.IsPhysician == true).ToList();
            else dgvPhysicians.DataSource = null;
        }
        #endregion

        #region cBoxRefPhys_CheckedChanged
        private void cBoxRefPhys_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxRefPhys.Checked)
            {
                if (_RefPhysFullList == null)
                    try { _RefPhysFullList = Negar.DBLayerPMS.Manager.DBML.SP_SelectRefPhysiciansFullDataList().ToList(); }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage = "امكان خواندن لیست پزشكان ارجاع دهنده از بانك وجود ندارد.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Sepehr", "Customerts Reports0001",
                            Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                        cBoxRefPhys.Checked = false; return;
                    }
                    #endregion
                dgvRefPhys.DataSource = _RefPhysFullList;
            }
            else dgvRefPhys.DataSource = null;
        }
        #endregion

        #region btnReport_Click
        private void btnReport_Click(object sender, EventArgs e)
        {
            dgvInsFilter.EndEdit();
            dgvServiceCat.EndEdit();
            btnReport.Focus();
            if (!GenerateReportString()) return;
            btnReport.Enabled = false;
            ProgressBar.Text = "در حال تولید گزارش...";
            ProgressBar.Style = ProgressBarStyle.Marquee;
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
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان خواندن اطلاعات گزارش از بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Customerts Reports0001",
                    Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                BGWorker.CancelAsync();
                return;
            }
            finally { _ReportSqlCommand.Connection.Close(); }
        }
        #endregion

        #region BGWorker_RunWorkerCompleted
        private void BGWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            #region Make Report
            Report MyReport = new Report();
            if (cBoxTransDateFilter.Checked)
                ((TextObject)MyReport.Section2.ReportObjects["txtRef1"]).Text = "تاریخ دریافت/پرداخت از:";
            if (!String.IsNullOrEmpty(txtHeader1.Text.Trim()))
                ((TextObject)MyReport.Section2.ReportObjects["txtHeader1"]).Text = txtHeader1.Text.Trim();
            ((TextObject)MyReport.Section2.ReportObjects["txtHeader2"]).Text = txtHeader2.Text.Trim();
            PersianDate DateVal1 = new DateTime(
                FromDateRef.SelectedDateTime.Value.Year, FromDateRef.SelectedDateTime.Value.Month,
                FromDateRef.SelectedDateTime.Value.Day, FromTimeRef.Value.Hour,
                FromTimeRef.Value.Minute, FromTimeRef.Value.Second).ToPersianDate();
            ((TextObject)MyReport.Section2.ReportObjects["txtBeginDate"]).Text =
                DateVal1.Year + "/" + DateVal1.Month + "/" + DateVal1.Day + " - " +
                DateVal1.Hour + ":" + DateVal1.Minute + ":" + DateVal1.Second;
            PersianDate DateVal2 = new DateTime(
                ToDateRef.SelectedDateTime.Value.Year, ToDateRef.SelectedDateTime.Value.Month,
                ToDateRef.SelectedDateTime.Value.Day, ToTimeRef.Value.Hour,
                ToTimeRef.Value.Minute, ToTimeRef.Value.Second).ToPersianDate();
            ((TextObject)MyReport.Section2.ReportObjects["txtEndDate"]).Text =
                DateVal2.Year + "/" + DateVal2.Month + "/" + DateVal2.Day + " - " +
                DateVal2.Hour + ":" + DateVal2.Minute + ":" + DateVal2.Second;
            ((TextObject)MyReport.Section5.ReportObjects["txtPrintDate"]).Text =
                DateTime.Now.ToPersianDate().ToWritten() + " - " +
                DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
            #endregion
            new frmPublicReportPreview(_ReportDataTable, MyReport);
            ProgressBar.Text = "در انتظار ایجاد گزارش";
            ProgressBar.Style = ProgressBarStyle.Blocks;
            btnReport.Enabled = true;
            BringToFront();
            Focus();
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
            _ReportSqlCommand.Connection = MyConnection;
            #endregion

            #region Step 1 - SELECT Columns & INNER JOINs
            StringBuilder ReportSelectString = new StringBuilder();
            ReportSelectString.Append("SELECT [TblPatList].[PatientID], " +
                "ISNULL([TblPatList].[FirstName] + ' ' , '') +	[TblPatList].[LastName] AS [FullName], " +
                "[TblRefList].[ID] AS [RefID] ," +
                "ISNULL((SELECT TOP 1 [TblIns].[Name] FROM [PatientsSystem].[Clinic].[Insurances] AS [TblIns] " +
                "WHERE [TblIns].[ID] = [TblRefList].[Ins1IX]) , '(بدون بیمه)') AS [InsName] , " +
                "(SELECT TOP 1 [TblServices].[Name] FROM [ImagingSystem].[Services].[List] AS [TblServices] " +
                "WHERE [TblServices].[ID] = [TblRefService].[ServiceIX]) AS [ServiceName] , " +
                "(SELECT TOP 1 [TblServices].[Code] FROM [ImagingSystem].[Services].[List] AS [TblServices] " +
                "WHERE [TblServices].[ID] = [TblRefService].[ServiceIX]) AS [ServiceCode] , " +
                "[TblRefService].[Quantity] AS [ServQty] , " +
                "(SELECT TOP 1 ISNULL([TblPerformer].[FirstName] + ' ' , '') + [TblPerformer].[LastName] " +
                "FROM [ImagingSystem].[Referrals].[Performers] AS [TblPerformer] " +
                "WHERE [TblPerformer].[ID] = [TblRefService].[PhysicianIX]) AS [PhysName] , " +
                "[TblRefService].[Ins1Price] * [TblRefService].[Quantity] AS [InsPrice], " +
                "([TblRefService].[Ins1Price] - [TblRefService].[Ins1PartPrice]) * [TblRefService].[Quantity] AS [InsPatPart], " +
                "[TblRefService].[Ins1PartPrice] * [TblRefService].[Quantity] AS [InsPart], " +
                "[TblRefService].[PatientPayablePrice] * [TblRefService].[Quantity] AS [PatientPayablePrice], " +
                "[ImagingSystem].[Accounting].[FK_CalcSumCost] ([TblRefList].[ID]) AS [TotalCosts], " +
                "[ImagingSystem].[Accounting].[FK_CalcSumDiscount] ([TblRefList].[ID]) AS [TotalDiscounts], " +
                "[ImagingSystem].[Accounting].[FK_CalcSumRecieve] ([TblRefList].[ID]) AS [TotalRecieves], " +
                "[ImagingSystem].[Accounting].[FK_CalcSumPay] ([TblRefList].[ID]) AS [TotalPays], " +
                "[ImagingSystem].[Accounting].[FK_CalcTotalRefRemain] ([TblRefList].[ID]) AS [RemainValue] " +
                "FROM [PatientsSystem].[Patients].[List] AS [TblPatList] " +
                "INNER JOIN [ImagingSystem].[Referrals].[List] AS [TblRefList]  " +
                "ON [TblPatList].[ID] = [TblRefList].[PatientIX] " +
                "INNER JOIN [ImagingSystem].[Referrals].[RefServices] AS [TblRefService] " +
                "ON [TblRefService].[ReferralIX] = [TblRefList].[ID] " +
                "WHERE [TblRefService].[IsActive] = 1 ");
            #endregion

            #region Step 2 - Add WHERE SELECT
            StringBuilder ReportSelectWhereString = new StringBuilder();

            #region RefTime Or TransTime
            if (cBoxTransDateFilter.Checked)
            {
                #region Set SqlParams
                SqlParameter Param1 = new SqlParameter("@RefDateBegin", SqlDbType.DateTime);
                Param1.Value = new DateTime(TransDateFrom.SelectedDateTime.Value.Year,
                    TransDateFrom.SelectedDateTime.Value.Month, TransDateFrom.SelectedDateTime.Value.Day,
                    TransTimeFrom.Value.Hour, TransTimeFrom.Value.Minute, TransTimeFrom.Value.Second);
                SqlParameter Param2 = new SqlParameter("@RefDateEnd", SqlDbType.DateTime);
                Param2.Value = new DateTime(TransDateTo.SelectedDateTime.Value.Year,
                    TransDateTo.SelectedDateTime.Value.Month, TransDateTo.SelectedDateTime.Value.Day,
                    TransTimeTo.Value.Hour, TransTimeTo.Value.Minute, TransTimeTo.Value.Second);
                _ReportSqlCommand.Parameters.Add(Param1);
                _ReportSqlCommand.Parameters.Add(Param2);
                #endregion
                ReportSelectWhereString.Append(" AND (SELECT TOP 1 [TblRefTrans].[ReferralIX] " +
                    "FROM [ImagingSystem].[Accounting].[RefTransaction] AS [TblRefTrans] " +
                    "WHERE [TblRefTrans].[ReferralIX] = [TblRefList].[ID] AND " +
                    "[TblRefTrans].[OccuredDate] >= @RefDateBegin AND " +
                    "[TblRefTrans].[OccuredDate] <= @RefDateEnd) IS NOT NULL ");
            }
            else
            {
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
                    " AND [TblRefList].[RegisterDate] >= @RefDateBegin AND [TblRefList].[RegisterDate] <= @RefDateEnd ");
            }
            #endregion

            #region Set Ins Filter
            if (cBoxIns1.Checked)
            {
                String SelectedID = String.Empty;
                foreach (DataGridViewRow Row in dgvInsFilter.Rows)
                {
                    if (Row.Index == 0) continue;
                    if (Row.Cells[ColInsSelection.Index].Value != null &&
                        Convert.ToBoolean(Row.Cells[ColInsSelection.Name].Value))
                        SelectedID += ((SP_SelectInsFullDataResult)Row.DataBoundItem).ID + " , ";
                }
                // اگر بیمه ای انتخاب نشده باشد
                if (String.IsNullOrEmpty(SelectedID))
                {
                    if (dgvInsFilter.Rows[0].Cells[ColInsSelection.Index].Value != null &&
                        Convert.ToBoolean(dgvInsFilter.Rows[0].Cells[ColInsSelection.Name].Value))
                        ReportSelectWhereString.Append("AND [TblRefList].[Ins1IX] IS NULL");
                }
                else
                {
                    // حذف آخرین ویرگول از لیست
                    SelectedID = SelectedID.Substring(0, SelectedID.Length - 3);
                    ReportSelectWhereString.Append("AND (([TblRefList].[Ins1IX] IN (" + SelectedID + ")");
                    if (Convert.ToBoolean(dgvInsFilter.Rows[0].Cells[ColInsSelection.Name].Value))
                        ReportSelectWhereString.Append(" AND [TblRefService].[IsIns1Cover] = 1) OR [TblRefList].[Ins1IX] IS NULL)");
                    else ReportSelectWhereString.Append(" AND [TblRefService].[IsIns1Cover] = 1))");
                }
            }
            #endregion

            #region Set Service Filters
            if (cBoxServiceCat.Checked)
            {
                // افزودن فیلتر طبقه بندی خدمت
                String SelectedID = String.Empty;
                foreach (DataGridViewRow Row in dgvServiceCat.Rows)
                {
                    if (Row.Cells[ColServSelection.Index].Value != null &&
                        Convert.ToBoolean(Row.Cells[ColServSelection.Index].Value))
                        SelectedID += ((Sepehr.DBLayerIMS.DataLayer.SP_SelectCategoriesResult)
                            Row.DataBoundItem).ID.Value + " , ";
                }
                if (!String.IsNullOrEmpty(SelectedID))
                {
                    // حذف آخرین ویرگول از لیست
                    SelectedID = SelectedID.Substring(0, SelectedID.Length - 3);
                    ReportSelectWhereString.Append(" AND (SELECT TOP 1 [TblServiceList].[CategoryIX] " +
                        "FROM [ImagingSystem].[Services].[List] AS [TblServiceList] " +
                        "WHERE [TblServiceList].[ID] = [TblRefService].[ServiceIX]) IN (" + SelectedID + ")");
                }
            }
            else if (cBoxService.Checked)
            {
                // افزودن فیلتر خدمت
                String SelectedID = String.Empty;
                foreach (DataGridViewRow Row in dgvServiceCat.Rows)
                {
                    if (Row.Cells[ColServSelection.Index].Value != null &&
                        Convert.ToBoolean(Row.Cells[ColServSelection.Index].Value))
                        SelectedID += ((SP_SelectServicesListResult)Row.DataBoundItem).ID + " , ";
                }
                if (!String.IsNullOrEmpty(SelectedID))
                {
                    // حذف آخرین ویرگول از لیست
                    SelectedID = SelectedID.Substring(0, SelectedID.Length - 3);
                    ReportSelectWhereString.Append(" AND [TblRefService].ServiceIX IN (" + SelectedID + ")");
                }
            }
            #endregion

            #region Set Physicians Filter
            if (cBoxPhys.Checked)
            {
                String SelectedID = String.Empty;
                foreach (DataGridViewRow Row in dgvPhysicians.Rows)
                {
                    if (Row.Cells[ColPhysSelection.Index].Value != null &&
                        Convert.ToBoolean(Row.Cells[ColPhysSelection.Index].Value))
                        SelectedID += ((SP_SelectPerformersResult)Row.DataBoundItem).ID + " , ";
                }
                // اگر پزشكی انتخاب نشده باشد
                if (String.IsNullOrEmpty(SelectedID))
                    ReportSelectWhereString.Append("AND [TblRefService].[PhysicianIX] IS NULL");
                else
                {
                    // حذف آخرین ویرگول از لیست
                    SelectedID = SelectedID.Substring(0, SelectedID.Length - 3);
                    ReportSelectWhereString.Append("AND [TblRefService].[PhysicianIX] IN (" + SelectedID + ")");
                }
            }
            #endregion

            #region Set Ref Physicians Filter
            if (cBoxRefPhys.Checked)
            {
                String SelectedID = String.Empty;
                foreach (DataGridViewRow Row in dgvRefPhys.Rows)
                {
                    if (Row.Cells[ColRefPhysSelection.Index].Value != null &&
                        Convert.ToBoolean(Row.Cells[ColRefPhysSelection.Index].Value))
                        SelectedID += ((SP_SelectRefPhysiciansFullDataListResult)Row.DataBoundItem).ID + " , ";
                }
                // اگر پزشكی انتخاب نشده باشد
                if (String.IsNullOrEmpty(SelectedID))
                    ReportSelectWhereString.Append("AND [TblRefList].[ReferPhysicianIX] IS NULL");
                else
                {
                    // حذف آخرین ویرگول از لیست
                    SelectedID = SelectedID.Substring(0, SelectedID.Length - 3);
                    ReportSelectWhereString.Append("AND [TblRefList].[ReferPhysicianIX] IN (" + SelectedID + ")");
                }
            }
            #endregion

            #region Set Discount Patients Filter
            if (cBoxDiscountOnly.Checked)
                ReportSelectWhereString.Append(" AND [ImagingSystem].[Accounting].[FK_CalcSumDiscount] ([TblRefList].[ID]) > 0 ");
            #endregion

            #endregion

            #region Step 3 - Add ORDER BY
            ReportSelectWhereString.Append(" ORDER BY [TblRefList].[RegisterDate] , [TblPatList].[PatientID] ASC;");
            #endregion

            _ReportSqlCommand.CommandText = ReportSelectString.Append(ReportSelectWhereString).ToString();
            return true;
        }
        #endregion

        #endregion

    }
}
