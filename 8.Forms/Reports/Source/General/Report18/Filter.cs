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
using Negar.PersianCalendar.Utilities;
using CrystalDecisions.CrystalReports.Engine;
using DevComponents.DotNetBar;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Forms.Reports.Properties;
#endregion

namespace Sepehr.Forms.Reports.General.Report18
{
    /// <summary>
    /// فرم فیلتر گزارش های عمومی
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

        #region DataTable _ReportSumDataTable
        /// <summary>
        /// جدول اطلاعات ثانویه گزارش
        /// </summary>
        private DataTable _ReportSumDataTable;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmFilter()
        {
            InitializeComponent();
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
            ToDateRef.SelectedDateTime = DateTime.Now;
            FromTimeRef.Value = new DateTime(2000, 1, 1, 0, 0, 0);
            ToTimeRef.Value = new DateTime(2000, 1, 1, 23, 59, 59);
            #endregion
            if (!ReadTopics()) { Close(); return; }
            SetControlsToolTipTexts();
        }
        #endregion

        #region btnReport_Click
        private void btnReport_Click(object sender, EventArgs e)
        {
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
            #region Execute SqlCommand
            _ReportDataTable = new DataTable();
            _ReportSumDataTable = new DataTable();
            try
            {
                _ReportSqlCommand.Connection.Open();
                // ReSharper disable AssignNullToNotNullAttribute
                _ReportDataTable.Load(_ReportSqlCommand.ExecuteReader());
                _ReportSqlCommand.CommandText =
                    "SELECT SUM(CONVERT(BIGINT,[ImagingSystem].[Accounting].[FK_CalcSumDiscount] ([TblRefList].[ID]))) AS [TotalDiscounts], " +
                    "SUM(CONVERT(BIGINT,[ImagingSystem].[Accounting].[FK_CalcSumCost] ([TblRefList].[ID]))) AS [TotalCosts], " +
                    "SUM(CONVERT(BIGINT,[ImagingSystem].[Accounting].[FK_CalcSumRecieve] ([TblRefList].[ID]))) AS [TotalRecieves], " +
                    "SUM(CONVERT(BIGINT,[ImagingSystem].[Accounting].[FK_CalcSumPay] ([TblRefList].[ID]))) AS [TotalPays], " +
                    "SUM(CONVERT(BIGINT,([ImagingSystem].[Accounting].[FK_CalcSumRecieve] ([TblRefList].[ID]) - " +
                    "[ImagingSystem].[Accounting].[FK_CalcSumPay] ([TblRefList].[ID]) +  " +
                    "[ImagingSystem].[Accounting].[FK_CalcSumIns1PartPrice] ([TblRefList].[ID]) +  " +
                    "[ImagingSystem].[Accounting].[FK_CalcSumIns2PartPrice] ([TblRefList].[ID])))) AS [Income], " +
                    "SUM(CONVERT(BIGINT,[ImagingSystem].[Accounting].[FK_CalcTotalRefRemain] ([TblRefList].[ID]))) AS [RemainValue] " +
                    "FROM [ImagingSystem].[Referrals].[List] AS [TblRefList] " +
                    "WHERE [TblRefList].[RegisterDate] >= @RefDateBegin AND [TblRefList].[RegisterDate] <= @RefDateEnd";
                _ReportSumDataTable.Load(_ReportSqlCommand.ExecuteReader());
                // ReSharper restore AssignNullToNotNullAttribute
            }
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان خواندن اطلاعات گزارش از بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Reports Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                BGWorker.CancelAsync();
                return;
            }
            finally { _ReportSqlCommand.Connection.Close(); }
            #endregion
        }
        #endregion

        #region BGWorker_RunWorkerCompleted
        private void BGWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            #region Make Report
            Report18 MyReport = new Report18();
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
            // تنظیم اطلاعات مجموع مراجعات
            if (_ReportSumDataTable.Rows.Count > 0)
            {
                Int64 Val = 0;
                if (_ReportSumDataTable.Rows[0][0] != null && _ReportSumDataTable.Rows[0][0] != DBNull.Value)
                    Val = Convert.ToInt64(_ReportSumDataTable.Rows[0][0]);
                ((TextObject)MyReport.Section4.ReportObjects["txt1"]).Text = String.Format("{0:N0}", Val);
                Val = 0;
                if (_ReportSumDataTable.Rows[0][1] != null && _ReportSumDataTable.Rows[0][1] != DBNull.Value)
                    Val = Convert.ToInt64(_ReportSumDataTable.Rows[0][1]);
                ((TextObject)MyReport.Section4.ReportObjects["txt2"]).Text = String.Format("{0:N0}", Val);
                Val = 0;
                if (_ReportSumDataTable.Rows[0][2] != null && _ReportSumDataTable.Rows[0][2] != DBNull.Value)
                    Val = Convert.ToInt64(_ReportSumDataTable.Rows[0][2]);
                ((TextObject)MyReport.Section4.ReportObjects["txt3"]).Text = String.Format("{0:N0}", Val);
                Val = 0;
                if (_ReportSumDataTable.Rows[0][3] != null && _ReportSumDataTable.Rows[0][3] != DBNull.Value)
                    Val = Convert.ToInt64(_ReportSumDataTable.Rows[0][3]);
                ((TextObject)MyReport.Section4.ReportObjects["txt4"]).Text = String.Format("{0:N0}", Val);
                Val = 0;
                if (_ReportSumDataTable.Rows[0][4] != null && _ReportSumDataTable.Rows[0][4] != DBNull.Value)
                    Val = Convert.ToInt64(_ReportSumDataTable.Rows[0][4]);
                ((TextObject)MyReport.Section4.ReportObjects["txt5"]).Text = String.Format("{0:N0}", Val);
                Val = 0;
                if (_ReportSumDataTable.Rows[0][5] != null && _ReportSumDataTable.Rows[0][5] != DBNull.Value)
                    Val = Convert.ToInt64(_ReportSumDataTable.Rows[0][5]);
                ((TextObject)MyReport.Section4.ReportObjects["txt6"]).Text = String.Format("{0:N0}", Val);
            }
            #endregion
            if (!SaveTopics()) { Close(); return; }
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
            ReportSelectString.Append("SELECT ISNULL((SELECT TOP 1 [TblServiceCat].[Name] " +
                "FROM [ImagingSystem].[Services].[Categories] AS [TblServiceCat] " +
                "WHERE [TblServiceCat].[ID] = [TblServList].[CategoryIX]) , '(بدون طبقه بندی)') AS [ServCatName] , " +
                "ISNULL((SELECT TOP 1 [TblIns].[Name] FROM [PatientsSystem].[Clinic].[Insurances] AS [TblIns] " +
                "WHERE [TblIns].[ID] = [TblRefList].[Ins1IX]) , '(بدون بیمه اصلی)') AS [Ins1Name] , " +
                "ISNULL((SELECT TOP 1 [TblIns].[Name] FROM [PatientsSystem].[Clinic].[Insurances] AS [TblIns] " +
                "WHERE [TblIns].[ID] = [TblRefList].[Ins2IX]) , '(بدون بیمه تكمیلی)') AS [Ins2Name] , " +
                "SUM([TblRefService].[Quantity]) AS [ServQty] ," +
                "SUM([TblRefService].[PatientPayablePrice] * [TblRefService].[Quantity]) AS [PatPayablePrice]," +
                "SUM([TblRefService].[Ins1PartPrice] * [TblRefService].[Quantity]) AS [Ins1Part], " +
                "SUM([TblRefService].[Ins2PartPrice] * [TblRefService].[Quantity]) AS [Ins2Part] " +
                "FROM [ImagingSystem].[Referrals].[RefServices] AS [TblRefService] " +
                "INNER JOIN [ImagingSystem].[Services].[List] AS [TblServList] " +
                "ON [TblRefService].[ServiceIX] = [TblServList].[ID] " +
                "INNER JOIN [ImagingSystem].[Referrals].[List] AS [TblRefList] " +
                "ON [TblRefList].[ID] = [TblRefService].[ReferralIX] " +
                "WHERE [TblRefService].[IsActive] = 1 ");
            #endregion

            #region Step 2 - Add WHERE SELECT
            StringBuilder ReportSelectWhereString = new StringBuilder();

            #region RefTime Filter

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

            #endregion

            #region Step 3 - Add GROUP BY & ORDER BY
            ReportSelectWhereString.Append(
                " GROUP BY [TblServList].[CategoryIX] , [TblRefList].[Ins1IX] , [TblRefList].[Ins2IX] " +
                "ORDER BY [TblServList].[CategoryIX] , [TblRefList].[Ins1IX] , [TblRefList].[Ins2IX] ASC");
            #endregion

            _ReportSqlCommand.CommandText = ReportSelectString.Append(ReportSelectWhereString).ToString();
            return true;
        }
        #endregion

        #region  Boolean ReadTopics()
        /// <summary>
        /// تابع خواندن عناوین ذخیره شده در بانك
        /// </summary>
        /// <returns>صحت انجام كار</returns>
        private Boolean ReadTopics()
        {
            List<UsersSetting> Setting908 = DBLayerIMS.Settings.CurrentUserSettingsFullList.
                Where(Data => Data.SettingIX == 908).ToList();
            if (Setting908.Count != 0 && !String.IsNullOrEmpty(Setting908.First().Value)) txtHeader1.Text = Setting908.First().Value;
            List<UsersSetting> Setting909 = DBLayerIMS.Settings.CurrentUserSettingsFullList.
                Where(Data => Data.SettingIX == 909).ToList();
            if (Setting909.Count != 0 && !String.IsNullOrEmpty(Setting909.First().Value)) txtHeader2.Text = Setting909.First().Value;
            return true;
        }
        #endregion

        #region Boolean SaveTopics()
        /// <summary>
        /// تابع ذخیره كردن عناوین گزارش ها
        /// </summary>
        /// <returns>صحت انجام كار</returns>
        private Boolean SaveTopics()
        {
            if (!DBLayerIMS.Settings.InsertCurrentUserSetting(908, null, txtHeader1.Text.Normalize()) ||
                !DBLayerIMS.Settings.InsertCurrentUserSetting(909, null, txtHeader2.Text.Normalize())) return false;
            return true;
        }
        #endregion

        #endregion

    }
}