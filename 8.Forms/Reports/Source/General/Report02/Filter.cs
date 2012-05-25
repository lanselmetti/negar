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
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Forms.Reports.Properties;
#endregion

namespace Sepehr.Forms.Reports.General.Report02
{
    /// <summary>
    /// فرم فیلتر گزارش های قابل طراحی
    /// </summary>
    public partial class frmFilter : Form
    {

        #region Fields & Properties

        #region List<CostsAndDiscountsType> _CostAndDiscountDataSource
        /// <summary>
        /// منبع داده تخفیف ها و هزینه ها
        /// </summary>
        private List<CostsAndDiscountsType> _CostAndDiscountDataSource;
        #endregion

        #region List<SP_SelectUsersResult> _CashiersDataSource
        /// <summary>
        /// منبع داده صندوقداران
        /// </summary>
        private List<SP_SelectUsersResult> _CashiersDataSource;
        #endregion

        #region DataTable _ReportDataTable
        /// <summary>
        /// داده های تولید شده از بانك اطلاعات
        /// </summary>
        private DataTable _ReportDataTable;
        #endregion

        #region SqlCommand _ReportSqlCommand
        /// <summary>
        /// شیء فرمان ارتباط با بانك
        /// </summary>
        private SqlCommand _ReportSqlCommand;
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
            dgvCashiers.AutoGenerateColumns = false;
            dgvCostsAndDiscounts.AutoGenerateColumns = false;
            if (!FillDataSource()) { Close(); return; }
            #region Set DateTime.Now
            FromDateCD.SelectedDateTime = DateTime.Now;
            ToDateCD.SelectedDateTime = DateTime.Now;
            FromTimeCD.Value = new DateTime(2000, 1, 1, 0, 0, 0);
            ToTimeCD.Value = new DateTime(2000, 1, 1, 23, 59, 59);
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

        #region cBox1_CheckedChanged
        private void cBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!cBox1.Checked && !cBox2.Checked) cBox2.Checked = true;
            if (cBoxType.Checked)
            {
                if (cBox1.Checked && cBox2.Checked) dgvCostsAndDiscounts.DataSource = _CostAndDiscountDataSource;
                else if (!cBox1.Checked && cBox2.Checked)
                    dgvCostsAndDiscounts.DataSource = _CostAndDiscountDataSource.Where(Data => Data.IsCost).ToList();
                else dgvCostsAndDiscounts.DataSource = _CostAndDiscountDataSource.Where(Data => !Data.IsCost).ToList();
            }
        }
        #endregion

        #region cBox2_CheckedChanged
        private void cBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (!cBox1.Checked && !cBox2.Checked) cBox1.Checked = true;
            if (cBoxType.Checked)
            {
                if (cBox1.Checked && cBox2.Checked) dgvCostsAndDiscounts.DataSource = _CostAndDiscountDataSource;
                else if (!cBox1.Checked && cBox2.Checked)
                    dgvCostsAndDiscounts.DataSource = _CostAndDiscountDataSource.Where(Data => Data.IsCost).ToList();
                else dgvCostsAndDiscounts.DataSource = _CostAndDiscountDataSource.Where(Data => !Data.IsCost).ToList();
            }
        }
        #endregion

        #region cBoxCDDate_CheckedChanged
        private void cBoxCDDate_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxCDDate.Checked) PanelCDDateTimeFilter.Enabled = true;
            else PanelCDDateTimeFilter.Enabled = false;
            if (!cBoxCDDate.Checked && !cBoxRefDateFilter.Checked)
                cBoxRefDateFilter.Checked = true;
        }
        #endregion

        #region cBoxRefDateFilter_CheckedChanged
        private void cBoxRefDateFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxRefDateFilter.Checked) PanelRefDateTimeFilter.Enabled = true;
            else PanelRefDateTimeFilter.Enabled = false;
            if (!cBoxCDDate.Checked && !cBoxRefDateFilter.Checked)
                cBoxCDDate.Checked = true;
        }
        #endregion

        #region cBoxCashier_CheckedChanged
        private void cBoxCashier_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxCashier.Checked) dgvCashiers.DataSource = _CashiersDataSource;
            else dgvCashiers.DataSource = null;
        }
        #endregion

        #region cBoxType_CheckedChanged
        private void cBoxType_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxType.Checked)
            {
                if (cBox1.Checked && cBox2.Checked) dgvCostsAndDiscounts.DataSource = _CostAndDiscountDataSource;
                else if (!cBox1.Checked && cBox2.Checked)
                    dgvCostsAndDiscounts.DataSource = _CostAndDiscountDataSource.Where(Data => Data.IsCost).ToList();
                else dgvCostsAndDiscounts.DataSource = _CostAndDiscountDataSource.Where(Data => !Data.IsCost).ToList();
            }
            else dgvCostsAndDiscounts.DataSource = null;
        }
        #endregion

        #region btnReport_Click
        private void btnReport_Click(object sender, EventArgs e)
        {
            if (sender.GetType().Equals(typeof(Boolean))) _CalcReportRowCount = true;
            else _CalcReportRowCount = false;
            dgvCashiers.EndEdit();
            dgvCostsAndDiscounts.EndEdit();
            btnReport.Focus();
            ProgressBar.Text = "در حال تولید گزارش...";
            ProgressBar.ProgressType = eProgressItemType.Marquee;
            if (!GenerateReportString()) Close();
            btnReport.Enabled = false;
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
            if (!_CalcReportRowCount)
            {
                _ReportDataTable.Columns["RefDateFa"].ReadOnly = false;
                _ReportDataTable.Columns["OccuredDateFa"].ReadOnly = false;
                for (Int16 i = 0; i < _ReportDataTable.Rows.Count; i++)
                {
                    PersianDate PDate =
                        Convert.ToDateTime(_ReportDataTable.Rows[i]["RefDate"]).ToPersianDate();
                    _ReportDataTable.Rows[i]["RefDateFa"] = PDate.Year + "/" + PDate.Month + "/" + PDate.Day + " - " +
                        PDate.Hour + ":" + PDate.Minute + ":" + PDate.Second;
                    PDate = Convert.ToDateTime(_ReportDataTable.Rows[i]["OccuredDate"]).ToPersianDate();
                    _ReportDataTable.Rows[i]["OccuredDateFa"] = PDate.Year + "/" + PDate.Month + "/" + PDate.Day + " - " +
                        PDate.Hour + ":" + PDate.Minute + ":" + PDate.Second;
                }
            }
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

                Report2 MyReport = new Report2();
                PersianDate DateVal1 = new DateTime(
                    FromDateCD.SelectedDateTime.Value.Year, FromDateCD.SelectedDateTime.Value.Month,
                    FromDateCD.SelectedDateTime.Value.Day, FromTimeCD.Value.Hour,
                    FromTimeCD.Value.Minute, FromTimeCD.Value.Second).ToPersianDate();
                ((TextObject)MyReport.Section2.ReportObjects["txtBeginDate"]).Text =
                    DateVal1.Year + "/" + DateVal1.Month + "/" + DateVal1.Day + " - " +
                    DateVal1.Hour + ":" + DateVal1.Minute + ":" + DateVal1.Second;
                PersianDate DateVal2 = new DateTime(
                    ToDateCD.SelectedDateTime.Value.Year, ToDateCD.SelectedDateTime.Value.Month,
                    ToDateCD.SelectedDateTime.Value.Day, ToTimeCD.Value.Hour,
                    ToTimeCD.Value.Minute, ToTimeCD.Value.Second).ToPersianDate();
                ((TextObject)MyReport.Section2.ReportObjects["txtEndDate"]).Text =
                    DateVal2.Year + "/" + DateVal2.Month + "/" + DateVal2.Day + " - " +
                    DateVal2.Hour + ":" + DateVal2.Minute + ":" + DateVal2.Second;
                if (cBoxRefDateFilter.Checked)
                {
                    PersianDate DateVal3 = new DateTime(
                        FromDateRef.SelectedDateTime.Value.Year, FromDateRef.SelectedDateTime.Value.Month,
                        FromDateRef.SelectedDateTime.Value.Day, FromTimeRef.Value.Hour,
                        FromTimeRef.Value.Minute, FromTimeRef.Value.Second).ToPersianDate();
                    ((TextObject)MyReport.Section2.ReportObjects["txtRefBegin"]).Text =
                        DateVal3.Year + "/" + DateVal3.Month + "/" + DateVal3.Day + " - " +
                        DateVal3.Hour + ":" + DateVal3.Minute + ":" + DateVal3.Second;
                    PersianDate DateVal4 = new DateTime(
                        ToDateRef.SelectedDateTime.Value.Year, ToDateRef.SelectedDateTime.Value.Month,
                        ToDateRef.SelectedDateTime.Value.Day, ToTimeRef.Value.Hour,
                        ToTimeRef.Value.Minute, ToTimeRef.Value.Second).ToPersianDate();
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

        #region Boolean FillDataSource()
        /// <summary>
        /// تابع كامل كردن اطلاعات فرم
        /// </summary>
        /// <returns>صحت انجام كار</returns>
        private Boolean FillDataSource()
        {
            _CostAndDiscountDataSource = DBLayerIMS.Account.CostAndDiscountFullList.Where(Data => Data.IsActive).ToList();
            _CashiersDataSource = Negar.DBLayerPMS.Security.UsersList.Where(Data => Data.ID > 2).ToList();
            return true;
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
            ReportSelectString.Append("SELECT [TblPatients].[PatientID] , " +
                "ISNULL([TblPatients].[FirstName] + ' ' , '') + [TblPatients].[LastName] AS [FullName] ,  " +
                "[TblReferrals].[ID] AS [RefID] , " +
                "[TblReferrals].[RegisterDate] AS [RefDate] , " +
                "'1200/12/31 - 12:59:59' AS [RefDateFa] , " +
                "[TblCAndD].[Name] AS [TypeName] , " +
                "[TblRefCAndD].[Date] AS [OccuredDate] , " +
                "'1200/12/31 - 12:59:59' AS [OccuredDateFa] ," +
                "ISNULL([TblUsers].[FirstName] + ' ' , '') + [TblUsers].[LastName] AS [CashierName] , " +
                "[TblRefCAndD].[Value] , " +
                "[TblRefCAndD].[Description] " +
                "FROM [ImagingSystem].[Accounting].[RefCostsAndDiscounts] AS [TblRefCAndD]  " +
                "INNER JOIN [ImagingSystem].[Referrals].[List] AS [TblReferrals] " +
                "ON [TblRefCAndD].[ReferralIX] = [TblReferrals].[ID] " +
                "INNER JOIN [PatientsSystem].[Patients].[List] AS [TblPatients] " +
                "ON [TblPatients].[ID] = [TblReferrals].[PatientIX] " +
                "INNER JOIN [PatientsSystem].[Security].[Users] AS [TblUsers] " +
                "ON [TblUsers].[ID] = [TblRefCAndD].[CashierIX]  " +
                "INNER JOIN [ImagingSystem].[Accounting].[CostsAndDiscountsTypes] AS [TblCAndD] " +
                "ON [TblCAndD].[ID] = [TblRefCAndD].[CostIXOrDiscountIX] ");
            #endregion

            #region Step 2 - Add WHERE SELECT
            StringBuilder ReportSelectWhereString = new StringBuilder();

            #region Costs Or Discounts
            // اگر فقط تخفیف ها انتخاب شده باشد
            if (cBox1.Checked && !cBox2.Checked)
                ReportSelectWhereString.Append("WHERE [TblCAndD].[IsCost] = 0 AND ");
            // اگر فقط هزینه ها انتخاب شده باشد
            else if (cBox2.Checked && !cBox1.Checked)
                ReportSelectWhereString.Append("WHERE [TblCAndD].[IsCost] = 1 AND ");
            // اگر همزمان انتخاب شده باشد
            else ReportSelectWhereString.Append("WHERE ");
            #endregion

            #region Cost Or Discount Time & RefTime
            #region Set SqlParams
            SqlParameter Param1 = new SqlParameter("@CDDateBegin", SqlDbType.DateTime);
            Param1.Value = new DateTime(FromDateCD.SelectedDateTime.Value.Year,
                                        FromDateCD.SelectedDateTime.Value.Month, FromDateCD.SelectedDateTime.Value.Day,
                                        FromTimeCD.Value.Hour, FromTimeCD.Value.Minute, FromTimeCD.Value.Second);
            SqlParameter Param2 = new SqlParameter("@CDDateEnd", SqlDbType.DateTime);
            Param2.Value = new DateTime(ToDateCD.SelectedDateTime.Value.Year,
                                        ToDateCD.SelectedDateTime.Value.Month, ToDateCD.SelectedDateTime.Value.Day,
                                        ToTimeCD.Value.Hour, ToTimeCD.Value.Minute, ToTimeCD.Value.Second);
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

            if (cBoxCDDate.Checked && !cBoxRefDateFilter.Checked)
                ReportSelectWhereString.Append("[TblRefCAndD].[Date] >= @CDDateBegin " +
                                               "AND [TblRefCAndD].[Date] <= @CDDateEnd ");
            else if (cBoxRefDateFilter.Checked && !cBoxCDDate.Checked)
                ReportSelectWhereString.Append("[TblReferrals].[RegisterDate] >= @RefDateBegin " +
                                               "AND [TblReferrals].[RegisterDate] <= @RefDateEnd ");
            else ReportSelectWhereString.Append("[TblRefCAndD].[Date] >= @CDDateBegin " +
                                                "AND [TblRefCAndD].[Date] <= @CDDateEnd " + " AND [TblReferrals].[RegisterDate] >= @RefDateBegin " +
                                                "AND [TblReferrals].[RegisterDate] <= @RefDateEnd ");
            #endregion

            #region Set CD Cashiers
            if (cBoxCashier.Checked)
            {
                String SelectedID = String.Empty;
                foreach (DataGridViewRow Row in dgvCashiers.Rows)
                {
                    if (Row.Cells[ColCashierSelection.Name].Value != null &&
                        Convert.ToBoolean(Row.Cells[ColCashierSelection.Name].Value))
                        SelectedID += ((SP_SelectUsersResult)Row.DataBoundItem).ID + " , ";
                }
                // اگر كاربری انتخاب شده باشد
                if (!String.IsNullOrEmpty(SelectedID))
                {
                    // حذف آخرین ویرگول از لیست
                    SelectedID = SelectedID.Substring(0, SelectedID.Length - 3);
                    ReportSelectWhereString.Append(" AND [TblRefCAndD].[CashierIX] IN (" + SelectedID + ")");
                }
            }
            #endregion

            #region Set CD Type
            if (cBoxType.Checked)
            {
                String SelectedID = String.Empty;
                foreach (DataGridViewRow Row in dgvCostsAndDiscounts.Rows)
                {
                    if (Row.Cells[ColTypeSelection.Name].Value != null &&
                        Convert.ToBoolean(Row.Cells[ColTypeSelection.Name].Value))
                        SelectedID += ((CostsAndDiscountsType)Row.DataBoundItem).ID + " , ";
                }
                // اگر نوعی انتخاب شده باشد
                if (!String.IsNullOrEmpty(SelectedID))
                {
                    // حذف آخرین ویرگول از لیست
                    SelectedID = SelectedID.Substring(0, SelectedID.Length - 3);
                    ReportSelectWhereString.Append(" AND [TblRefCAndD].[CostIXOrDiscountIX] IN (" + SelectedID + ")");
                }
            }
            #endregion

            #endregion

            #region Step 3 - Add Order BY
            if (!_CalcReportRowCount)
                ReportSelectWhereString.Append(" ORDER BY [TblReferrals].[RegisterDate] , [TblRefCAndD].[Date];");
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