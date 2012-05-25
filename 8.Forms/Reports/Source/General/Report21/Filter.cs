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

namespace Sepehr.Forms.Reports.General.Report21
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
            #region Set DateTime.Now
            PersianDate PersianMonthBeginDate = DateTime.Now.ToPersianDate();
            PersianMonthBeginDate.Day = 1;
            DateTime GregorianMonthBeginDate = PersianMonthBeginDate.ToGregorianDateTime();
            FromDateRef.SelectedDateTime = GregorianMonthBeginDate;
            try { PersianMonthBeginDate.Day = 31; }
            catch (Exception)
            {
                try { PersianMonthBeginDate.Day = 30; }
                catch (Exception) { PersianMonthBeginDate.Day = 29; }
            }
            GregorianMonthBeginDate = PersianMonthBeginDate.ToGregorianDateTime();
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

        #region btnReport_Click
        private void btnReport_Click(object sender, EventArgs e)
        {
            if (sender.GetType().Equals(typeof(Boolean))) _CalcReportRowCount = true;
            else _CalcReportRowCount = false;
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
                #region Make Report
                if (_ReportDataTable == null) return;
                Report21 MyReport = new Report21();
                PersianDate DateVal1 = new DateTime(FromDateRef.SelectedDateTime.Value.Year,
                    FromDateRef.SelectedDateTime.Value.Month, FromDateRef.SelectedDateTime.Value.Day,
                    FromTimeRef.Value.Hour, FromTimeRef.Value.Minute, FromTimeRef.Value.Second).ToPersianDate();
                if (cBox1.Checked) ((TextObject)MyReport.Section1.ReportObjects["txtTitle"]).Text += " - " + cBox1.Text;
                else ((TextObject)MyReport.Section1.ReportObjects["txtTitle"]).Text += " - " + cBox2.Text;
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
            if (cBox1.Checked)
            {
                // دریافت های نقدی
                ReportSelectString.Append("SELECT N'دریافت های نقدی' AS [Title] , SUM(ABS([TblTrans].[Value])) AS [Value] " +
                    "FROM [ImagingSystem].[Accounting].[RefTransaction] AS [TblTrans] " +
                    "LEFT OUTER JOIN [ImagingSystem].[Accounting].[RefTransactionAdditionalData] AS [TblTransAddin] " +
                    "ON [TblTrans].[ID] = [TblTransAddin].[RefTransactionIX] " +
                    "WHERE [TblTrans].[OccuredDate] >= @BeginDate AND [TblTrans].[OccuredDate] <= @EndDate " +
                    "AND [TblTrans].[Value] > 0 " +
                    "AND [TblTransAddin].[RefTransactionIX] IS NULL ");
                // دریافت های چك
                ReportSelectString.Append("UNION ALL SELECT N'دریافت های چك' AS [Title] , SUM(ABS([TblTrans].[Value])) AS [Value] " +
                    "FROM [ImagingSystem].[Accounting].[RefTransaction] AS [TblTrans] " +
                    "INNER JOIN [ImagingSystem].[Accounting].[RefTransactionAdditionalData] AS [TblTransAddin] " +
                    "ON [TblTrans].[ID] = [TblTransAddin].[RefTransactionIX] " +
                    "WHERE [TblTrans].[OccuredDate] >= @BeginDate AND [TblTrans].[OccuredDate] <= @EndDate " +
                    "AND [TblTrans].[Value] > 0 " +
                    "AND [TblTransAddin].[PayType] = 1 ");
                // دریافت های فیش
                ReportSelectString.Append("UNION ALL SELECT N'دریافت های فیش' AS [Title] , SUM(ABS([TblTrans].[Value])) AS [Value] " +
                    "FROM [ImagingSystem].[Accounting].[RefTransaction] AS [TblTrans] " +
                    "INNER JOIN [ImagingSystem].[Accounting].[RefTransactionAdditionalData] AS [TblTransAddin] " +
                    "ON [TblTrans].[ID] = [TblTransAddin].[RefTransactionIX] " +
                    "WHERE [TblTrans].[OccuredDate] >= @BeginDate AND [TblTrans].[OccuredDate] <= @EndDate " +
                    "AND [TblTrans].[Value] > 0 " +
                    "AND [TblTransAddin].[PayType] = 2 ");
                // دریافت های كارتخوان
                ReportSelectString.Append("UNION ALL SELECT N'دریافت های كارتخوان' AS [Title] , SUM(ABS([TblTrans].[Value])) AS [Value] " +
                    "FROM [ImagingSystem].[Accounting].[RefTransaction] AS [TblTrans] " +
                    "INNER JOIN [ImagingSystem].[Accounting].[RefTransactionAdditionalData] AS [TblTransAddin] " +
                    "ON [TblTrans].[ID] = [TblTransAddin].[RefTransactionIX] " +
                    "WHERE [TblTrans].[OccuredDate] >= @BeginDate AND [TblTrans].[OccuredDate] <= @EndDate " +
                    "AND [TblTrans].[Value] > 0 " +
                    "AND [TblTransAddin].[PayType] = 3 ");
                // سهم بیمه های اصلی
                ReportSelectString.Append("UNION ALL SELECT N'سهم بیمه اصلی: \"' + [TblIns].[Name] + '\"' AS [Title] , " +
                    "SUM([RefServ].[Ins1PartPrice] * [RefServ].[Quantity]) AS [Value] " +
                    "FROM [ImagingSystem].[Referrals].[RefServices] AS [RefServ] " +
                    "INNER JOIN [ImagingSystem].[Referrals].[List] AS [RefList] " +
                    "ON [RefList].[ID] = [RefServ].[ReferralIX] " +
                    "INNER JOIN [PatientsSystem].[Clinic].[Insurances] AS [TblIns] " +
                    "ON [RefList].[Ins1IX] = [TblIns].[ID] " +
                    "WHERE [RefList].[RegisterDate] >= @BeginDate AND [RefList].[RegisterDate] <= @EndDate " +
                    "AND [RefServ].[IsActive] = 1 AND [RefServ].[IsIns1Cover] = 1 GROUP BY [TblIns].[ID] , [TblIns].[Name] ");
                // بیمه های تكمیلی
                ReportSelectString.Append("UNION ALL SELECT N'سهم بیمه تكمیلی: \"' + [TblIns].[Name] + '\"' AS [Title] , " +
                    "SUM([RefServ].[Ins2PartPrice] * [RefServ].[Quantity]) AS [Value] " +
                    "FROM [ImagingSystem].[Referrals].[RefServices] AS [RefServ] " +
                    "INNER JOIN [ImagingSystem].[Referrals].[List] AS [RefList] " +
                    "ON [RefList].[ID] = [RefServ].[ReferralIX] " +
                    "INNER JOIN [PatientsSystem].[Clinic].[Insurances] AS [TblIns] " +
                    "ON [RefList].[Ins2IX] = [TblIns].[ID] " +
                    "WHERE [RefList].[RegisterDate] >= @BeginDate AND [RefList].[RegisterDate] <= @EndDate " +
                    "AND [RefServ].[IsActive] = 1 AND [RefServ].[IsIns2Cover] = 1 GROUP BY [TblIns].[ID] , [TblIns].[Name] ");
                // وصول طلب از بیماران
                ReportSelectString.Append("UNION ALL SELECT N'وصول طلب از بیماران' AS [Title] , " +
                    "SUM(-1 * ABS([TblTrans].[Value])) AS [Value] " +
                    "FROM [ImagingSystem].[Accounting].[RefTransaction] AS [TblTrans] " +
                    "INNER JOIN [ImagingSystem].[Referrals].[List] AS [RefList] " +
                    "ON [RefList].[ID] = [TblTrans].[ReferralIX] " +
                    "WHERE [TblTrans].[OccuredDate] >= @BeginDate AND [TblTrans].[OccuredDate] <= @EndDate " +
                    "AND ([PatientsSystem].[Clinic].[FK_DateToString]([RefList].[RegisterDate]) < " +
                    "[PatientsSystem].[Clinic].[FK_DateToString](@BeginDate) " +
                    "AND [PatientsSystem].[Clinic].[FK_DateToString]([RefList].[RegisterDate]) < " +
                    "[PatientsSystem].[Clinic].[FK_DateToString](@EndDate) " +
                    "OR [PatientsSystem].[Clinic].[FK_DateToString]([RefList].[RegisterDate]) > " +
                    "[PatientsSystem].[Clinic].[FK_DateToString](@BeginDate) " +
                    "AND [PatientsSystem].[Clinic].[FK_DateToString]([RefList].[RegisterDate]) > " +
                    "[PatientsSystem].[Clinic].[FK_DateToString](@EndDate)) " +
                    "AND [TblTrans].[Value] > 0 ");
                // مجموع طلبكاری
                ReportSelectString.Append("UNION ALL SELECT N'مجموع طلب ها از بیماران' AS [Title] , " +
                    "SUM([TblTemp].[RemainValue]) FROM (" +
                    "SELECT SUM([ImagingSystem].[Accounting].[FK_CalcRefPayable]([RefList].[ID])) - " +
                    "ISNULL((SELECT SUM([TblTrans].[Value]) AS [Value] " +
                    "FROM [ImagingSystem].[Accounting].[RefTransaction] AS [TblTrans] " +
                    "WHERE [TblTrans].[ReferralIX] = [RefList].[ID] " +
                    "AND [TblTrans].[OccuredDate] >= @BeginDate AND [TblTrans].[OccuredDate] <= @EndDate) , 0) AS [RemainValue] " +
                    "FROM [ImagingSystem].[Referrals].[List] AS [RefList] " +
                    "WHERE [RefList].[RegisterDate] >= @BeginDate AND [RefList].[RegisterDate] <= @EndDate " +
                    "GROUP BY [RefList].[ID]) AS [TblTemp] WHERE [TblTemp].[RemainValue] > 0 ");
                // مجموع تخفیف ها
                ReportSelectString.Append("UNION ALL SELECT N'تخفیف: \"' + [TblCD].[Name] + '\"' AS [Title] , " +
                    "SUM(ABS([RefCD].[Value])) AS [Value] " +
                    "FROM [ImagingSystem].[Accounting].[RefCostsAndDiscounts] AS [RefCD] " +
                    "INNER JOIN [ImagingSystem].[Accounting].[CostsAndDiscountsTypes] AS [TblCD] " +
                    "ON [TblCD].[ID] = [RefCD].[CostIXOrDiscountIX] " +
                    "INNER JOIN [ImagingSystem].[Referrals].[List] AS [RefList] " +
                    "ON [RefList].[ID] = [RefCD].[ReferralIX] " +
                    "WHERE [RefList].[RegisterDate] >= @BeginDate AND [RefList].[RegisterDate] <= @EndDate " +
                    "AND [TblCD].[IsCost] = 0 GROUP BY [TblCD].[Name] ");
            }
            else
            {
                // بازپرداخت های نقدی
                ReportSelectString.Append("SELECT N'بازپرداخت های نقدی' AS [Title] , SUM(ABS([TblTrans].[Value])) AS [Value] " +
                    "FROM [ImagingSystem].[Accounting].[RefTransaction] AS [TblTrans] " +
                    "LEFT OUTER JOIN [ImagingSystem].[Accounting].[RefTransactionAdditionalData] AS [TblTransAddin] " +
                    "ON [TblTrans].[ID] = [TblTransAddin].[RefTransactionIX] " +
                    "WHERE [TblTrans].[OccuredDate] >= @BeginDate AND [TblTrans].[OccuredDate] <= @EndDate " +
                    "AND [TblTrans].[Value] < 0 " +
                    "AND [TblTransAddin].[RefTransactionIX] IS NULL ");
                // بازپرداخت های چك
                ReportSelectString.Append("UNION ALL SELECT N'بازپرداخت های چك' AS [Title] , SUM(ABS([TblTrans].[Value])) AS [Value] " +
                    "FROM [ImagingSystem].[Accounting].[RefTransaction] AS [TblTrans] " +
                    "INNER JOIN [ImagingSystem].[Accounting].[RefTransactionAdditionalData] AS [TblTransAddin] " +
                    "ON [TblTrans].[ID] = [TblTransAddin].[RefTransactionIX] " +
                    "WHERE [TblTrans].[OccuredDate] >= @BeginDate AND [TblTrans].[OccuredDate] <= @EndDate " +
                    "AND [TblTrans].[Value] < 0 " +
                    "AND [TblTransAddin].[PayType] = 1 ");
                // بازپرداخت های فیش
                ReportSelectString.Append("UNION ALL SELECT N'بازپرداخت های فیش' AS [Title] , SUM(ABS([TblTrans].[Value])) AS [Value] " +
                    "FROM [ImagingSystem].[Accounting].[RefTransaction] AS [TblTrans] " +
                    "INNER JOIN [ImagingSystem].[Accounting].[RefTransactionAdditionalData] AS [TblTransAddin] " +
                    "ON [TblTrans].[ID] = [TblTransAddin].[RefTransactionIX] " +
                    "WHERE [TblTrans].[OccuredDate] >= @BeginDate AND [TblTrans].[OccuredDate] <= @EndDate " +
                    "AND [TblTrans].[Value] < 0 " +
                    "AND [TblTransAddin].[PayType] = 2 ");
                // بازپرداخت های كارتخوان
                ReportSelectString.Append("UNION ALL SELECT N'بازپرداخت های كارتخوان' AS [Title] , " +
                    "SUM(ABS([TblTrans].[Value])) AS [Value] " +
                    "FROM [ImagingSystem].[Accounting].[RefTransaction] AS [TblTrans] " +
                    "INNER JOIN [ImagingSystem].[Accounting].[RefTransactionAdditionalData] AS [TblTransAddin] " +
                    "ON [TblTrans].[ID] = [TblTransAddin].[RefTransactionIX] " +
                    "WHERE [TblTrans].[OccuredDate] >= @BeginDate AND [TblTrans].[OccuredDate] <= @EndDate " +
                    "AND [TblTrans].[Value] < 0 " +
                    "AND [TblTransAddin].[PayType] = 3 ");
                // مجموع بدهكاری
                ReportSelectString.Append("UNION ALL SELECT N'مجموع بدهی ها به  بیماران' AS [Title] , " +
                    "ABS(SUM([TblTemp].[RemainValue])) FROM (" +
                    "SELECT SUM([ImagingSystem].[Accounting].[FK_CalcRefPayable]([RefList].[ID])) - " +
                    "ISNULL((SELECT SUM([TblTrans].[Value]) AS [Value] " +
                    "FROM [ImagingSystem].[Accounting].[RefTransaction] AS [TblTrans] " +
                    "WHERE [TblTrans].[ReferralIX] = [RefList].[ID] " +
                    "AND [TblTrans].[OccuredDate] >= @BeginDate AND [TblTrans].[OccuredDate] <= @EndDate) , 0) AS [RemainValue] " +
                    "FROM [ImagingSystem].[Referrals].[List] AS [RefList] " +
                    "WHERE [RefList].[RegisterDate] >= @BeginDate AND [RefList].[RegisterDate] <= @EndDate " +
                    "GROUP BY [RefList].[ID]) AS [TblTemp] WHERE [TblTemp].[RemainValue] < 0 ");
                // درآمد طبقه بندی های مختلف
                ReportSelectString.Append("UNION ALL SELECT N'درآمد طبقه بندی: \"' + [TblCatList].[Name] + '\"' AS [Title] , " +
                    "SUM(([RefServ].[PatientPayablePrice] * [RefServ].[Quantity]) + " + 
                    "ISNULL([RefServ].[Ins1PartPrice] * [RefServ].[Quantity], 0) + " +
                    "ISNULL([RefServ].[Ins2PartPrice] * [RefServ].[Quantity], 0)) AS [Value] " +
                    "FROM [ImagingSystem].[Referrals].[RefServices] AS [RefServ] " +
                    "INNER JOIN [ImagingSystem].[Referrals].[List] AS [RefList] " +
                    "ON [RefList].[ID] = [RefServ].[ReferralIX] " +
                    "INNER JOIN [ImagingSystem].[Services].[List] AS [TblServList] " +
                    "ON [TblServList].[ID] = [RefServ].[ServiceIX] " +
                    "LEFT OUTER JOIN [ImagingSystem].[Services].[Categories] AS [TblCatList] " +
                    "ON [TblCatList].[ID] = [TblServList].[CategoryIX] " +
                    "WHERE [RefList].[RegisterDate] >= @BeginDate AND [RefList].[RegisterDate] <= @EndDate " +
                    "AND [RefServ].[IsActive] = 1 GROUP BY [TblCatList].[ID] , [TblCatList].[Name] ");
                // پرداخت بدهی به بیماران
                ReportSelectString.Append("UNION ALL SELECT N'پرداخت بدهی به بیماران' AS [Title] , " +
                    "SUM(-1 * ABS([TblTrans].[Value])) AS [Value] " +
                    "FROM [ImagingSystem].[Accounting].[RefTransaction] AS [TblTrans] " +
                    "INNER JOIN [ImagingSystem].[Referrals].[List] AS [RefList] " +
                    "ON [RefList].[ID] = [TblTrans].[ReferralIX] " +
                    "WHERE [TblTrans].[OccuredDate] >= @BeginDate AND [TblTrans].[OccuredDate] <= @EndDate " +
                    "AND ([PatientsSystem].[Clinic].[FK_DateToString]([RefList].[RegisterDate]) < " +
                    "[PatientsSystem].[Clinic].[FK_DateToString](@BeginDate) " +
                    "AND [PatientsSystem].[Clinic].[FK_DateToString]([RefList].[RegisterDate]) < " +
                    "[PatientsSystem].[Clinic].[FK_DateToString](@EndDate) " +
                    "OR [PatientsSystem].[Clinic].[FK_DateToString]([RefList].[RegisterDate]) > " +
                    "[PatientsSystem].[Clinic].[FK_DateToString](@BeginDate) " +
                    "AND [PatientsSystem].[Clinic].[FK_DateToString]([RefList].[RegisterDate]) > " +
                    "[PatientsSystem].[Clinic].[FK_DateToString](@EndDate)) " +
                    "AND [TblTrans].[Value] < 0 ");
                // مجموع هزینه ها
                ReportSelectString.Append("UNION ALL SELECT N'هزینه: \"' + [TblCD].[Name] + '\"' AS [Title] , " +
                    "SUM(ABS([RefCD].[Value])) AS [Value] " +
                    "FROM [ImagingSystem].[Accounting].[RefCostsAndDiscounts] AS [RefCD] " +
                    "INNER JOIN [ImagingSystem].[Accounting].[CostsAndDiscountsTypes] AS [TblCD] " +
                    "ON [TblCD].[ID] = [RefCD].[CostIXOrDiscountIX] " +
                    "INNER JOIN [ImagingSystem].[Referrals].[List] AS [RefList] " +
                    "ON [RefList].[ID] = [RefCD].[ReferralIX] " +
                    "WHERE [RefList].[RegisterDate] >= @BeginDate AND [RefList].[RegisterDate] <= @EndDate " +
                    "AND [TblCD].[IsCost] = 1 GROUP BY [TblCD].[ID] , [TblCD].[Name] ");
            }
            #endregion

            #region Step 2 - Add WHERE SELECT
            StringBuilder ReportSelectWhereString = new StringBuilder();

            #region RefTime
            SqlParameter Param1 = new SqlParameter("@BeginDate", SqlDbType.DateTime);
            Param1.Value = new DateTime(FromDateRef.SelectedDateTime.Value.Year,
                FromDateRef.SelectedDateTime.Value.Month, FromDateRef.SelectedDateTime.Value.Day,
                FromTimeRef.Value.Hour, FromTimeRef.Value.Minute, FromTimeRef.Value.Second);
            SqlParameter Param2 = new SqlParameter("@EndDate", SqlDbType.DateTime);
            Param2.Value = new DateTime(ToDateRef.SelectedDateTime.Value.Year,
                ToDateRef.SelectedDateTime.Value.Month, ToDateRef.SelectedDateTime.Value.Day,
                ToTimeRef.Value.Hour, ToTimeRef.Value.Minute, ToTimeRef.Value.Second);
            _ReportSqlCommand.Parameters.Add(Param1);
            _ReportSqlCommand.Parameters.Add(Param2);
            #endregion

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