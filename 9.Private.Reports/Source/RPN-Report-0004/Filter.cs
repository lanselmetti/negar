#region using
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using Negar;
using Negar.Customers.Reports0004;
using Negar.PersianCalendar.Utilities;
using Sepehr.DBLayerIMS.DataLayer;
#endregion

namespace Negar.Customers.Reports0004
{
    /// <summary>
    /// فرم فیلتر گزارش های قابل طراحی
    /// </summary>
    public partial class frmFilter : Form
    {

        #region Fields & Properties

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
        }
        #endregion

        #region cBoxIns1_CheckedChanged
        private void cBoxIns1_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxIns1.Checked)
                dgvInsFilter.DataSource = Sepehr.DBLayerIMS.
                    Insurance.InsFullList.Where(Data => Data.IsActive == true).ToList();
            else dgvInsFilter.DataSource = null;
        }
        #endregion

        #region btnReport_Click
        private void btnReport_Click(object sender, EventArgs e)
        {
            dgvInsFilter.EndEdit();
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
            #region Execute SqlCommand
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
                const String ErrorMessage =
                    "امكان خواندن اطلاعات گزارش از بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Reports Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                BGWorker.CancelAsync();
                return;
            }
            finally { _ReportSqlCommand.Connection.Close(); }
            #endregion

            #region Replace PersianDateTime With Original Data
            _ReportDataTable.Columns["RegisterDateFa"].ReadOnly = false;
            // حذف شد
            //_ReportDataTable.Columns["PrescriptionDateFa"].ReadOnly = false;
            for (Int16 i = 0; i < _ReportDataTable.Rows.Count; i++)
            {
                PersianDate PDate =
                    Convert.ToDateTime(_ReportDataTable.Rows[i]["RegisterDate"]).ToPersianDate();
                _ReportDataTable.Rows[i]["RegisterDateFa"] = PDate.Year + "/" + PDate.Month + "/" + PDate.Day;
                // حذف شد
                //if (_ReportDataTable.Rows[i]["PrescriptionDate"] == null ||
                //    _ReportDataTable.Rows[i]["PrescriptionDate"] == DBNull.Value) PDate = null;
                //else PDate = PersianDateConverter.ToPersianDate(Convert.ToDateTime(
                //_ReportDataTable.Rows[i]["PrescriptionDate"]));
                //if (PDate == null) _ReportDataTable.Rows[i]["PrescriptionDateFa"] = String.Empty;
                //else _ReportDataTable.Rows[i]["PrescriptionDateFa"] = PDate.Year + "/" + PDate.Month + "/" + PDate.Day;
            }
            #endregion
        }
        #endregion

        #region BGWorker_RunWorkerCompleted
        private void BGWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            #region Make Report
            Report MyReport = new Report();
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
            _ReportSqlCommand.CommandTimeout = 0;
            _ReportSqlCommand.Connection = MyConnection;
            #endregion

            #region Step 1 - SELECT Columns & INNER JOINs
            StringBuilder ReportSelectString = new StringBuilder();
            ReportSelectString.Append(
                "SELECT [TblPatList].[PatientID], " +
                "ISNULL([TblPatList].[FirstName] + ' ' , '') +	[TblPatList].[LastName] AS [FullName],  " +
                "(SELECT TOP 1 [TblCatList].[Name] FROM [ImagingSystem].[Services].[List] AS [TblServiceList] " +
                "INNER JOIN [ImagingSystem].[Services].[Categories] AS [TblCatList] " +
                "ON [TblServiceList].[CategoryIX] = [TblCatList].[ID] " +
                "INNER JOIN [ImagingSystem].[Referrals].[RefServices] AS [RefService] " +
                "ON [RefService].[ServiceIX] = [TblServiceList].[ID] " +
                "WHERE [RefService].[ReferralIX] = [TblRefList].[ID] " +
                "AND [RefService].[IsActive] = 1) AS [CategoryName] , " +	
                "(SELECT TOP 1 [TblIns].[Name] FROM [PatientsSystem].[Clinic].[Insurances] AS [TblIns] " +
                "WHERE [TblIns].[ID] = [TblRefList].[Ins1IX]) AS [InsName] , " +
                "SUM(([TblRefService].[Ins1Price] - [TblRefService].[Ins1PartPrice]) * [TblRefService].[Quantity]) AS [InsPatPart], " +
                "SUM((ISNULL([TblRefService].[Ins1PartPrice] , 0) + " +
                "ISNULL([TblRefService].[Ins2PartPrice] , 0)) * [TblRefService].[Quantity]) AS [InsPart], " +
                "SUM([TblRefService].[PatientPayablePrice] * [TblRefService].[Quantity]) AS [PatientPayablePrice], " +
                "(SELECT SUM([TblTempService].[PatientPayablePrice] * [TblTempService].[Quantity]) " +
                "FROM [ImagingSystem].[Referrals].[RefServices] AS [TblTempService] " +
                "WHERE [TblTempService].[ReferralIX] = [TblRefList].[ID] AND " +
                "(SELECT TOP 1 [TblServiceList].[CategoryIX] FROM [ImagingSystem].[Services].[List] AS [TblServiceList] " + 
                "WHERE [TblServiceList].[ID] = [TblTempService].[ServiceIX]) IN (12) ) AS [ConsumablesPrice]," +
                "[TblRefList].[RegisterDate] , " +
                "'1380/01/01 - 10:00:00' AS [RegisterDateFa] , " +
                "ISNULL((SELECT TOP 1 [TblIns].[Name] FROM [PatientsSystem].[Clinic].[Insurances] AS [TblIns] " +
                "WHERE [TblIns].[ID] = [TblRefList].[Ins1IX]) , '(بدون بیمه)') AS [InsName] , " +
                "SUM(([TblRefService].[Ins1Price] - [TblRefService].[Ins1PartPrice]) * [TblRefService].[Quantity]) AS [InsPatPart], " +
                "SUM((ISNULL([TblRefService].[Ins1PartPrice] , 0) + " +
                "ISNULL([TblRefService].[Ins2PartPrice] , 0)) * [TblRefService].[Quantity]) AS [InsPart]," +
                "SUM([TblRefService].[PatientPayablePrice] * [TblRefService].[Quantity]) AS [PatientPayablePrice], " +
                "(SUM((ISNULL([TblRefService].[Ins1PartPrice] , 0) + " +
                "ISNULL([TblRefService].[Ins2PartPrice] , 0)) * [TblRefService].[Quantity])) + " +
                "(SUM([TblRefService].[PatientPayablePrice] * [TblRefService].[Quantity])) AS [TotalIncome], " +
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

            #region RefTime && PrescribeDate

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

            #endregion

            #region Step 3 - Add GROUP BY & ORDER BY
            ReportSelectWhereString.Append(" GROUP BY [TblPatList].[PatientID] , " +
                "ISNULL([TblPatList].[FirstName] + ' ' , '') + [TblPatList].[LastName] , " +
                "[TblRefList].[ID] , [TblRefList].[RegisterDate] , [TblRefList].[Ins1IX] " +
                "ORDER BY [TblRefList].[RegisterDate] , [TblPatList].[PatientID] ASC;");
            #endregion

            _ReportSqlCommand.CommandText = ReportSelectString.Append(ReportSelectWhereString).ToString();
            return true;
        }
        #endregion

        #endregion

    }
}