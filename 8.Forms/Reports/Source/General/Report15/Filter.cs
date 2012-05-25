#region using
using System;
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

namespace Sepehr.Forms.Reports.General.Report15
{
    /// <summary>
    /// فرم فیلتر گزارش های تراكنش های مالی
    /// </summary>
    public partial class frmFilter : Form
    {

        #region Fields & Properties

        #region SqlCommand _ReportSqlCommand
        /// <summary>
        /// فرمان اس كیو ال گزارش
        /// </summary>
        private SqlCommand _ReportSqlCommand;
        #endregion

        #region DataTable _ReportDataTable
        /// <summary>
        /// جدول اطلاعات جستجوی شده
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
            dgvCashier.AutoGenerateColumns = false;
            #region Set DateTime.Now
            FromDateTrans.SelectedDateTime = DateTime.Now;
            ToDateTrans.SelectedDateTime = DateTime.Now;
            FromTimeTrans.Value = new DateTime(2000, 1, 1, 0, 0, 0);
            ToTimeTrans.Value = new DateTime(2000, 1, 1, 23, 59, 59);
            PersianDate PersianMonthBeginDate = PersianDateConverter.ToPersianDate(DateTime.Now);
            PersianMonthBeginDate.Day = 1;
            DateTime GregorianMonthBeginDate = PersianDateConverter.ToGregorianDateTime(PersianMonthBeginDate);
            FromDateRef.SelectedDateTime = GregorianMonthBeginDate;
            try { PersianMonthBeginDate.Day = 31; }
            catch (Exception)
            {
                try { PersianMonthBeginDate.Day = 30; }
                catch (Exception) { PersianMonthBeginDate.Day = 29; }
            }
            GregorianMonthBeginDate = PersianDateConverter.ToGregorianDateTime(PersianMonthBeginDate);
            ToDateRef.SelectedDateTime = GregorianMonthBeginDate;
            FromTimeRef.Value = new DateTime(2000, 1, 1, 0, 0, 0);
            ToTimeRef.Value = new DateTime(2000, 1, 1, 23, 59, 59);
            #endregion
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            SetControlsToolTipTexts();
        }
        #endregion

        #region cBox1_CheckedChanged
        private void cBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!cBox1.Checked && !cBox2.Checked) cBox2.Checked = true;
        }
        #endregion

        #region cBox2_CheckedChanged
        private void cBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (!cBox1.Checked && !cBox2.Checked) cBox1.Checked = true;
        }
        #endregion

        #region cBoxTransDate_CheckedChanged
        private void cBoxTransDate_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxTransDate.Checked) PanelTransDateTimeFilter.Enabled = true;
            else PanelTransDateTimeFilter.Enabled = false;
            if (!cBoxTransDate.Checked && !cBoxRefDateFilter.Checked)
                cBoxRefDateFilter.Checked = true;
        }
        #endregion

        #region cBoxRefDateFilter_CheckedChanged
        private void cBoxRefDateFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxRefDateFilter.Checked) PanelRefDateTimeFilter.Enabled = true;
            else PanelRefDateTimeFilter.Enabled = false;
            if (!cBoxTransDate.Checked && !cBoxRefDateFilter.Checked)
                cBoxTransDate.Checked = true;
        }
        #endregion

        #region cBoxFilterCashiers_CheckedChanged
        private void cBoxFilterCashiers_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxFilterCashiers.Checked)
                dgvCashier.DataSource = Negar.DBLayerPMS.Security.UsersList.Where(Data => Data.ID != null).ToList();
            else dgvCashier.DataSource = null;
        }
        #endregion

        #region btnReport_Click
        private void btnReport_Click(object sender, EventArgs e)
        {
            dgvCashier.EndEdit();
            btnReport.Focus();
            btnReport.Enabled = false;
            ProgressBar.Text = "در حال تولید گزارش...";
            ProgressBar.ProgressType = eProgressItemType.Marquee;
            if (!GenerateReportString()) { Close(); return; }
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
            finally
            {
                _ReportSqlCommand.Connection.Close();
            }
            #endregion

            #region Replace PersianDateTime With Original Data
            _ReportDataTable.Columns["TransDateTime"].ReadOnly = false;
            _ReportDataTable.Columns["CheckDate"].ReadOnly = false;
            for (Int16 i = 0; i < _ReportDataTable.Rows.Count; i++)
            {
                PersianDate PDate = PersianDateConverter.ToPersianDate(
                    Convert.ToDateTime(_ReportDataTable.Rows[i]["TransDateTimeEn"]));
                _ReportDataTable.Rows[i]["TransDateTime"] = PDate.Year + "/" + PDate.Month + "/" + PDate.Day + " - " +
                    PDate.Hour + ":" + PDate.Minute + ":" + PDate.Second;
                if (_ReportDataTable.Rows[i]["CheckDateEn"] == null ||
                    _ReportDataTable.Rows[i]["CheckDateEn"] == DBNull.Value) _ReportDataTable.Rows[i]["CheckDate"] = String.Empty;
                else
                {
                    PDate = PersianDateConverter.ToPersianDate(Convert.ToDateTime(_ReportDataTable.Rows[i]["CheckDateEn"]));
                    _ReportDataTable.Rows[i]["CheckDate"] = PDate.Year + "/" + PDate.Month + "/" + PDate.Day;
                }
            }
            #endregion
        }
        #endregion

        #region BGWorker_RunWorkerCompleted
        private void BGWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            #region Make Report
            Report15 MyReport = new Report15();
            PersianDate DateVal1 = PersianDateConverter.ToPersianDate(new DateTime(
                FromDateTrans.SelectedDateTime.Value.Year, FromDateTrans.SelectedDateTime.Value.Month,
                FromDateTrans.SelectedDateTime.Value.Day, FromTimeTrans.Value.Hour,
                FromTimeTrans.Value.Minute, FromTimeTrans.Value.Second));
            ((TextObject)MyReport.Section2.ReportObjects["txtBeginDate"]).Text =
                DateVal1.Year + "/" + DateVal1.Month + "/" + DateVal1.Day + " - " +
                DateVal1.Hour + ":" + DateVal1.Minute + ":" + DateVal1.Second;
            PersianDate DateVal2 = PersianDateConverter.ToPersianDate(new DateTime(
                ToDateTrans.SelectedDateTime.Value.Year, ToDateTrans.SelectedDateTime.Value.Month,
                ToDateTrans.SelectedDateTime.Value.Day, ToTimeTrans.Value.Hour,
                ToTimeTrans.Value.Minute, ToTimeTrans.Value.Second));
            ((TextObject)MyReport.Section2.ReportObjects["txtEndDate"]).Text =
                DateVal2.Year + "/" + DateVal2.Month + "/" + DateVal2.Day + " - " +
                DateVal2.Hour + ":" + DateVal2.Minute + ":" + DateVal2.Second;
            if (cBoxRefDateFilter.Checked)
            {
                PersianDate DateVal3 = PersianDateConverter.ToPersianDate(new DateTime(
                    FromDateRef.SelectedDateTime.Value.Year, FromDateRef.SelectedDateTime.Value.Month,
                    FromDateRef.SelectedDateTime.Value.Day, FromTimeRef.Value.Hour,
                    FromTimeRef.Value.Minute, FromTimeRef.Value.Second));
                ((TextObject)MyReport.Section2.ReportObjects["txtRefBegin"]).Text =
                    DateVal3.Year + "/" + DateVal3.Month + "/" + DateVal3.Day + " - " +
                    DateVal3.Hour + ":" + DateVal3.Minute + ":" + DateVal3.Second;
                PersianDate DateVal4 = PersianDateConverter.ToPersianDate(new DateTime(
                    ToDateRef.SelectedDateTime.Value.Year, ToDateRef.SelectedDateTime.Value.Month,
                    ToDateRef.SelectedDateTime.Value.Day, ToTimeRef.Value.Hour,
                    ToTimeRef.Value.Minute, ToTimeRef.Value.Second));
                ((TextObject)MyReport.Section2.ReportObjects["txtRefEnd"]).Text =
                    DateVal4.Year + "/" + DateVal4.Month + "/" + DateVal4.Day + " - " +
                    DateVal4.Hour + ":" + DateVal4.Minute + ":" + DateVal4.Second;
            }
            else
            {
                ((TextObject)MyReport.Section2.ReportObjects["txtRefBegin"]).Text = String.Empty;
                ((TextObject)MyReport.Section2.ReportObjects["txtRefEnd"]).Text = String.Empty;
                ((TextObject)MyReport.Section2.ReportObjects["txtRef1"]).Text = String.Empty;
                ((TextObject)MyReport.Section2.ReportObjects["txtRef2"]).Text = String.Empty;
            }
            ((TextObject)MyReport.Section5.ReportObjects["txtPrintDate"]).Text =
                PersianDateConverter.ToPersianDate(DateTime.Now).ToWritten() + " - " +
                DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
            #endregion
            new frmPublicReportPreview(_ReportDataTable, MyReport);
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
            // ToDo: نمایش راهنما تكمیل شود
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
            ReportSelectString.Append("SELECT [TblPatList].[PatientID] , " +
                "(ISNULL([TblPatList].[FirstName] + ' ' , '') + [TblPatList].[LastName] ) AS [FullName], " +
                "[TblRefTrans].[OccuredDate] AS [TransDateTimeEn], " +
                "'1380/01/01 - 10:00:00' AS [TransDateTime]," +
                "[TblRefTrans].[Value] AS [RealValue] , " +
                "(CASE WHEN [TblRefTrans].[Value] >= 0 THEN 'دریافت' ELSE 'بازپرداخت' END) AS [Type] ," +
                "ABS([TblRefTrans].[Value]) AS [Value] ," +
                "(CASE WHEN [TblRefTransAddin].[PayType] = 1 THEN 'چك' " +
                "WHEN [TblRefTransAddin].[PayType] = 2 THEN 'فیش' ELSE 'نقد' END) AS [PayType] ," +
                "(SELECT TOP 1 [Tbl].[Name] FROM [ImagingSystem].[Accounting].[Banks] AS [Tbl]" +
                "WHERE [Tbl].[ID] = [TblRefTransAddin].[BankIX]) AS [BankName] ," +
                "[TblRefTransAddin].[BranchName] ," +
                "[TblRefTransAddin].[BranchCode] ," +
                "[TblRefTransAddin].[CheckDate] AS [CheckDateEn] ," +
                "'1380/01/01' AS [CheckDate] ," +
                "[TblRefTransAddin].[CheckNumber] ," +
                "(CASE WHEN [TblRefTransAddin].[AccountType] = 1 THEN 'جاری' " +
                "WHEN [TblRefTransAddin].[AccountType] = 2 THEN 'پس انداز' " +
                "WHEN [TblRefTransAddin].[AccountType] = 3 THEN 'قرض الحسنه' END) AS [AccountType] ," +
                "[TblRefTransAddin].[AccountNumber] " +
                "FROM [PatientsSystem].[Patients].[List] AS [TblPatList]  " +
                "INNER JOIN  [ImagingSystem].[Referrals].[List] AS [TblRefList]  " +
                "ON [TblPatList].[ID] = [TblRefList].[PatientIX] " +
                "INNER JOIN [ImagingSystem].[Accounting].[RefTransaction] AS [TblRefTrans]  " +
                "ON [TblRefTrans].[ReferralIX] = [TblRefList].[ID] " +
                "LEFT OUTER JOIN [ImagingSystem].[Accounting].[RefTransactionAdditionalData] AS [TblRefTransAddin]  " +
                "ON [TblRefTrans].[ID] = [TblRefTransAddin].[RefTransactionIX] ");
            #endregion

            #region Step 2 - Add WHERE SELECT
            StringBuilder ReportSelectWhereString = new StringBuilder();

            #region TranType
            // اگر فقط دریافت ها انتخاب شده باشد
            if (cBox1.Checked && !cBox2.Checked)
                ReportSelectWhereString.Append("WHERE [TblRefTrans].[Value] >= 0 AND ");
            // اگر فقط بازپرداخت ها انتخاب شده باشد
            else if (cBox2.Checked && !cBox1.Checked)
                ReportSelectWhereString.Append("WHERE [TblRefTrans].Value < 0 AND ");
            // اگر دریافت ها و بازپرداخت ها همزمان انتخاب شده باشد
            else ReportSelectWhereString.Append("WHERE ");
            #endregion

            #region TransTime & RefTime

            #region Set SqlParams
            SqlParameter Param1 = new SqlParameter("@TransDateBegin", SqlDbType.DateTime);
            Param1.Value = new DateTime(FromDateTrans.SelectedDateTime.Value.Year,
                FromDateTrans.SelectedDateTime.Value.Month, FromDateTrans.SelectedDateTime.Value.Day,
                FromTimeTrans.Value.Hour, FromTimeTrans.Value.Minute, FromTimeTrans.Value.Second);
            SqlParameter Param2 = new SqlParameter("@TransDateEnd", SqlDbType.DateTime);
            Param2.Value = new DateTime(ToDateTrans.SelectedDateTime.Value.Year,
                ToDateTrans.SelectedDateTime.Value.Month, ToDateTrans.SelectedDateTime.Value.Day,
                ToTimeTrans.Value.Hour, ToTimeTrans.Value.Minute, ToTimeTrans.Value.Second);
            _ReportSqlCommand.Parameters.Add(Param1);
            _ReportSqlCommand.Parameters.Add(Param2);
            SqlParameter Param3 = new SqlParameter("@RefDateBegin", SqlDbType.DateTime);
            Param3.Value = new DateTime(FromDateRef.SelectedDateTime.Value.Year,
                FromDateRef.SelectedDateTime.Value.Month, FromDateRef.SelectedDateTime.Value.Day,
                FromTimeRef.Value.Hour, FromTimeRef.Value.Minute, FromTimeRef.Value.Second);
            SqlParameter Param4 = new SqlParameter("@RefDateEnd", SqlDbType.DateTime);
            Param4.Value = new DateTime(ToDateRef.SelectedDateTime.Value.Year,
                ToDateRef.SelectedDateTime.Value.Month, ToDateRef.SelectedDateTime.Value.Day,
                ToTimeRef.Value.Hour, ToTimeRef.Value.Minute, ToTimeRef.Value.Second);
            _ReportSqlCommand.Parameters.Add(Param3);
            _ReportSqlCommand.Parameters.Add(Param4);
            #endregion

            if (cBoxTransDate.Checked && !cBoxRefDateFilter.Checked)
                ReportSelectWhereString.Append("[TblRefTrans].[OccuredDate] >= @TransDateBegin " +
                    "AND [TblRefTrans].[OccuredDate] <= @TransDateEnd ");
            else if (cBoxRefDateFilter.Checked && !cBoxTransDate.Checked)
                ReportSelectWhereString.Append("[TblRefList].[RegisterDate] >= @RefDateBegin " +
                    "AND [TblRefList].[RegisterDate] <= @RefDateEnd ");
            else ReportSelectWhereString.Append("[TblRefTrans].[OccuredDate] >= @TransDateBegin " +
                "AND [TblRefTrans].[OccuredDate] <= @TransDateEnd " + " AND [TblRefList].[RegisterDate] >= @RefDateBegin " +
                "AND [TblRefList].[RegisterDate] <= @RefDateEnd ");
            #endregion

            #region Set Trans Cashiers
            if (cBoxFilterCashiers.Checked)
            {
                String SelectedID = String.Empty;
                foreach (DataGridViewRow Row in dgvCashier.Rows)
                {
                    if (Row.Cells[ColSelection.Index].Value != null && Convert.ToBoolean(Row.Cells[ColSelection.Index].Value))
                        SelectedID += ((SP_SelectUsersResult)Row.DataBoundItem).ID + " , ";
                }
                // حذف آخرین ویرگول از لیست
                if (!String.IsNullOrEmpty(SelectedID))
                    SelectedID = SelectedID.Substring(0, SelectedID.Length - 3);
                ReportSelectWhereString.Append(" AND [TblRefTrans].[CashierIX] IN (" + SelectedID + ")");
            }
            #endregion

            #endregion

            #region Step 3 - Add ORDER BY
            // مرتب سازی بر اساس تاریخ دریافت
            ReportSelectWhereString.Append(
                " ORDER BY [TblRefList].[RegisterDate] , [TblRefList].[ID] , [TblRefTrans].[OccuredDate] ASC");
            #endregion

            _ReportSqlCommand.CommandText = ReportSelectString.Append(ReportSelectWhereString).ToString();
            return true;
        }
        #endregion

        #endregion

    }
}