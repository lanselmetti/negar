#region using
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using Negar;
using Negar.PersianCalendar.Utilities;
using CrystalDecisions.CrystalReports.Engine;
using DevComponents.DotNetBar;
using Sepehr.Forms.Reports.Properties;
#endregion

namespace Sepehr.Forms.Reports.General.Report14
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
            #region Set DateTime.Now
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

        #region cBoxMinValue_CheckedChanged
        private void cBoxMinValue_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxMinValue.Checked) txtMinValue.Enabled = true;
            else txtMinValue.Enabled = false;
        }
        #endregion

        #region cBoxMaxValue_CheckedChanged
        private void cBoxMaxValue_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxMaxValue.Checked) txtMaxValue.Enabled = true;
            else txtMaxValue.Enabled = false;
        }
        #endregion

        #region btnReport_Click
        private void btnReport_Click(object sender, EventArgs e)
        {
            btnReport.Enabled = false;
            ProgressBar.Text = "در حال تولید گزارش...";
            ProgressBar.ProgressType = eProgressItemType.Marquee;
            if (!GenerateReportString()) Close();
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
            _ReportDataTable.Columns["RemainType"].ReadOnly = false;
            _ReportDataTable.Columns["RefDateFa"].ReadOnly = false;
            for (Int32 i = 0; i < _ReportDataTable.Rows.Count; i++)
            {
                if (Convert.ToInt32(_ReportDataTable.Rows[i]["RemainValue"]) <= 0)
                    _ReportDataTable.Rows[i]["RemainType"] = "طلبكار";
                else _ReportDataTable.Rows[i]["RemainType"] = "بدهكار";
                PersianDate PDate = PersianDateConverter.ToPersianDate(Convert.ToDateTime(_ReportDataTable.Rows[i]["RefDate"]));
                _ReportDataTable.Rows[i]["RefDateFa"] = PDate.Year + "/" + PDate.Month + "/" + PDate.Day + " - " +
                    PDate.Hour + ":" + PDate.Minute + ":" + PDate.Second;
            }
            #endregion
        }
        #endregion

        #region BGWorker_RunWorkerCompleted
        private void BGWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            ProgressBar.Text = "در انتظار ایجاد گزارش";
            ProgressBar.ProgressType = eProgressItemType.Standard;
            btnReport.Enabled = true;
            if (e.Cancelled) return;
            #region Make Report
            if (_ReportDataTable == null) return;
            Report14 MyReport = new Report14();
            PersianDate DateVal1 = PersianDateConverter.ToPersianDate(new DateTime(
                FromDateRef.SelectedDateTime.Value.Year, FromDateRef.SelectedDateTime.Value.Month,
                FromDateRef.SelectedDateTime.Value.Day, FromTimeRef.Value.Hour,
                FromTimeRef.Value.Minute, FromTimeRef.Value.Second));
            ((TextObject)MyReport.Section2.ReportObjects["txtBeginDate"]).Text =
                DateVal1.Year + "/" + DateVal1.Month + "/" + DateVal1.Day + " - " +
                DateVal1.Hour + ":" + DateVal1.Minute + ":" + DateVal1.Second;
            PersianDate DateVal2 = PersianDateConverter.ToPersianDate(new DateTime(
                ToDateRef.SelectedDateTime.Value.Year, ToDateRef.SelectedDateTime.Value.Month,
                ToDateRef.SelectedDateTime.Value.Day, ToTimeRef.Value.Hour,
                ToTimeRef.Value.Minute, ToTimeRef.Value.Second));
            ((TextObject)MyReport.Section2.ReportObjects["txtEndDate"]).Text =
                DateVal2.Year + "/" + DateVal2.Month + "/" + DateVal2.Day + " - " +
                DateVal2.Hour + ":" + DateVal2.Minute + ":" + DateVal2.Second;
            ((TextObject)MyReport.Section5.ReportObjects["txtPrintDate"]).Text =
                PersianDateConverter.ToPersianDate(DateTime.Now).ToWritten() + " - " +
                DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
            #endregion
            new frmPublicReportPreview(_ReportDataTable, MyReport);
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
            ReportSelectString.Append("SELECT [TblPatients].[PatientID], " +
                "(ISNULL([TblPatients].[FirstName] + ' ' , '') + [TblPatients].[LastName]) AS [FullName] , " +
                "[TblRefList].[RegisterDate] AS [RefDate] , " +
                "'1380/01/01 - 10:00:00' AS [RefDateFa] , " +
                "[ImagingSystem].[Accounting].[FK_CalcSumRecieve]([TblRefList].[ID]) AS [SumRecieve] , " +
                "[ImagingSystem].[Accounting].[FK_CalcSumPay]([TblRefList].[ID]) AS [SumPay] , " +
                "'طلب كار' AS [RemainType] , " +
                "[TblRefList].[RemainValue] AS [RemainValue] " +
                "FROM [ImagingSystem].[Referrals].[List] AS [TblRefList] " +
                "INNER JOIN [PatientsSystem].[Patients].[List] AS [TblPatients] " +
                "ON [TblPatients].[ID] = [TblRefList].[PatientIX] ");
            #endregion

            #region Step 2 - Add WHERE
            StringBuilder ReportSelectWhereString = new StringBuilder();

            #region Type
            // اگر فقط طلبكاران انتخاب شده باشد
            if (cBox1.Checked && !cBox2.Checked)
                ReportSelectWhereString.Append("WHERE [TblRefList].[RemainValue] < 0 ");
            // اگر فقط بدهكاران انتخاب شده باشد
            else if (cBox2.Checked && !cBox1.Checked)
                ReportSelectWhereString.Append("WHERE [TblRefList].[RemainValue] > 0 ");
            // اگر همزمان انتخاب شده باشد
            else ReportSelectWhereString.Append("WHERE [TblRefList].[RemainValue] <> 0 AND " +
                "[TblRefList].[RemainValue] IS NOT NULL");
            #endregion

            #region RefTime
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

            ReportSelectWhereString.Append(" AND [TblRefList].[RegisterDate] >= @RefDateBegin " +
                "AND [TblRefList].[RegisterDate] <= @RefDateEnd ");
            #endregion

            #region Limitations
            if (cBoxMinValue.Checked) ReportSelectWhereString.Append(
                "AND ABS([TblRefList].[RemainValue]) >= " + txtMinValue.Value);
            if (cBoxMaxValue.Checked) ReportSelectWhereString.Append(
                "AND ABS([TblRefList].[RemainValue]) <= " + txtMaxValue.Value);
            #endregion

            #endregion

            #region Step 3 - Add ORDER BY
            ReportSelectWhereString.Append(" ORDER BY [TblRefList].[RegisterDate] , [TblRefList].[ID];");
            #endregion

            _ReportSqlCommand.CommandText = ReportSelectString.Append(ReportSelectWhereString).ToString();
            return true;
        }
        #endregion

        #endregion

    }
}