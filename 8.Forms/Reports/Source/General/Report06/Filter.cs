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
using SP_SelectCategoriesResult = Sepehr.DBLayerIMS.DataLayer.SP_SelectCategoriesResult;
using SP_SelectGroupsResult = Sepehr.DBLayerIMS.DataLayer.SP_SelectGroupsResult;
#endregion

namespace Sepehr.Forms.Reports.General.Report06
{
    /// <summary>
    /// فرم فیلتر گزارش های عمومی
    /// </summary>
    public partial class frmFilter : Form
    {

        #region Fields & Properties

        #region SqlCommand _ReportSqlCommand
        private SqlCommand _ReportSqlCommand;
        #endregion

        #region SqlCommand _CDSqlCommand
        private SqlCommand _CDSqlCommand;
        #endregion

        #region DataTable _CDDataTable
        private DataTable _CDDataTable;
        #endregion

        #region Boolean _IsCDActive
        private Boolean _IsCDActive;
        #endregion

        #region DataTable _DataTables
        private DataTable _ServicePayableDataTable;
        private DataTable _Ins1PartDataTable;
        private DataTable _Ins2PartDataTable;
        #endregion

        #region Command Texts Fields
        private String _ServicePayable;
        private String _Ins1Part;
        private String _Ins2Part;
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
            dgvPerformers.AutoGenerateColumns = false;
            dgvServiceCat.AutoGenerateColumns = false;
            dgvServiceGroups.AutoGenerateColumns = false;
            dgvRefPhysician.AutoGenerateColumns = false;
            dgvCostsAndDiscounts.AutoGenerateColumns = false;
            dgvService.AutoGenerateColumns = false;
            dgvDocUser.AutoGenerateColumns = false;
            dgvIns1.AutoGenerateColumns = false;
            dgvIns2.AutoGenerateColumns = false;
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

        #region dgvPerformers_CellContentClick
        private void dgvPerformers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvPerformers.EndEdit();
            if (e.ColumnIndex == ColPerformerSelection.Index)
                if (dgvPerformers[e.ColumnIndex, e.RowIndex].Value != null &&
                    Convert.ToBoolean(dgvPerformers[e.ColumnIndex, e.RowIndex].Value))
                    txtPhysName.Text = dgvPerformers[ColPerformerName.Index, e.RowIndex].Value.ToString();
        }
        #endregion

        #region cBoxPerformers_CheckedChanged
        private void cBoxPerformers_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxPerformers.Checked)
                dgvPerformers.DataSource = DBLayerIMS.Referrals.RefServPerformers;
            else dgvPerformers.DataSource = null;
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

        #region cBoxIns1_CheckedChanged
        private void cBoxIns1_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxIns1.Checked)
                dgvIns1.DataSource = DBLayerIMS.Insurance.InsFullList.
                    Where(Data => Data.IsIns1 == true && Data.ID != null).ToList();
            else dgvIns1.DataSource = null;
        }
        #endregion

        #region cBoxIns2_CheckedChanged
        private void cBoxIns2_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxIns2.Checked)
                dgvIns2.DataSource = DBLayerIMS.Insurance.InsFullList.
                    Where(Data => Data.IsIns2 == true && Data.ID != null).ToList();
            else dgvIns2.DataSource = null;
        }
        #endregion

        #region cBoxServiceGroups_CheckedChanged
        private void cBoxServiceGroups_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxServiceGroups.Checked) dgvServiceGroups.DataSource =
                DBLayerIMS.Services.ServGroupsList.Where(Data => Data.ID != null).ToList();
            else dgvServiceGroups.DataSource = null;
        }
        #endregion

        #region cBoxCDType_CheckedChanged
        private void cBoxCDType_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxCDType.Checked)
                dgvCostsAndDiscounts.DataSource = DBLayerIMS.Account.CostAndDiscountFullList.Where(Data => !Data.IsCost).ToList();
            else dgvCostsAndDiscounts.DataSource = null;
        }
        #endregion

        #region cBoxService_CheckedChanged
        private void cBoxService_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxService.Checked) dgvService.DataSource = DBLayerIMS.Services.ServicesList.
                OrderBy(Data => Convert.ToInt32(Data.Code)).ToList();
            else dgvService.DataSource = null;
        }
        #endregion

        #region cBoxDocTypist_CheckedChanged
        private void cBoxDocTypist_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxDocTypist.Checked) dgvDocUser.DataSource = Negar.DBLayerPMS.Security.UsersList;
            else dgvDocUser.DataSource = null;
        }
        #endregion

        #region btnReport_Click
        private void btnReport_Click(object sender, EventArgs e)
        {
            if (sender.GetType().Equals(typeof(Boolean))) _CalcReportRowCount = true;
            else _CalcReportRowCount = false;
            dgvPerformers.EndEdit();
            dgvServiceCat.EndEdit();
            dgvServiceGroups.EndEdit();
            btnReport.Focus();
            if (!GenerateReportString()) return;
            if (cBoxCDType.Checked)
            {
                _IsCDActive = true;
                if (!GenerateCDString()) return;
            }
            else _IsCDActive = false;
            btnReport.Enabled = false;
            ProgressBar.Text = "در حال تولید گزارش...";
            ProgressBar.ProgressType = eProgressItemType.Marquee;
            BGWorker.RunWorkerAsync();
        }
        #endregion

        #region BGWorker_DoWork
        private void BGWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            _ServicePayableDataTable = new DataTable();
            _Ins1PartDataTable = new DataTable();
            _Ins2PartDataTable = new DataTable();
            try
            {
                _ReportSqlCommand.CommandText = _ServicePayable;
                _ReportSqlCommand.Connection.Open();
                // ReSharper disable AssignNullToNotNullAttribute
                _ServicePayableDataTable.Load(_ReportSqlCommand.ExecuteReader());
                _ReportSqlCommand.CommandText = _Ins1Part;
                _Ins1PartDataTable.Load(_ReportSqlCommand.ExecuteReader());
                _ReportSqlCommand.CommandText = _Ins2Part;
                _Ins2PartDataTable.Load(_ReportSqlCommand.ExecuteReader());
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
            if (_IsCDActive)
            {
                _CDDataTable = new DataTable();
                try
                {
                    _CDSqlCommand.Connection.Open();
                    // ReSharper disable AssignNullToNotNullAttribute
                    _CDDataTable.Load(_CDSqlCommand.ExecuteReader());
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
                finally { _CDSqlCommand.Connection.Close(); }
            }
        }
        #endregion

        #region BGWorker_RunWorkerCompleted
        private void BGWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (_CalcReportRowCount)
            {
                if (_ServicePayableDataTable != null && _ServicePayableDataTable.Rows.Count != 0)
                    PMBox.Show("تعداد ردیف های نتیجه گزارش:\n" + _ServicePayableDataTable.Rows[0][0],
                        "تعداد ردیف های گزارش", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (!e.Cancelled)
                {
                    #region Make Report
                    Report6 MyReport = new Report6();
                    if (!String.IsNullOrEmpty(txtReportTitle.Text))
                        ((TextObject)MyReport.Section2.ReportObjects["txtTitle"]).Text = txtReportTitle.Text;
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
                    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
                    ((TextObject)MyReport.Section3.ReportObjects["txtPerformerName"]).Text = txtPhysName.Text;
                    Int64 Val1 = 0;
                    if (_ServicePayableDataTable.Rows[0][0] != null &&
                        _ServicePayableDataTable.Rows[0][0] != DBNull.Value)
                        Val1 = Convert.ToInt64(_ServicePayableDataTable.Rows[0][0]);
                    Int64 Val2 = 0;
                    if (_Ins1PartDataTable.Rows[0][0] != null && _Ins1PartDataTable.Rows[0][0] != DBNull.Value)
                        Val2 = Convert.ToInt64(_Ins1PartDataTable.Rows[0][0]);
                    Int64 Val3 = 0;
                    if (_Ins2PartDataTable.Rows[0][0] != null && _Ins2PartDataTable.Rows[0][0] != DBNull.Value)
                        Val3 = Convert.ToInt64(_Ins2PartDataTable.Rows[0][0]);
                    ((TextObject)MyReport.Section3.ReportObjects["txtServiceTotalPayable"]).Text =
                        String.Format("{0:N0}", Val1) + " ریال";
                    ((TextObject)MyReport.Section3.ReportObjects["txtIns1TotalPart"]).Text =
                        String.Format("{0:N0}", Val2) + " ریال";
                    ((TextObject)MyReport.Section3.ReportObjects["txtIns2TotalPart"]).Text =
                        String.Format("{0:N0}", Val3) + " ریال";
                    Int64 TotalValue = Val1 + Val2 + Val3;
                    ((TextObject)MyReport.Section3.ReportObjects["txtTotalIncome"]).Text =
                        String.Format("{0:N0}", TotalValue) + " ریال";
                    ((TextObject)MyReport.Section3.ReportObjects["txtPercent"]).Text = txtPercent.Value + " درصد";
                    Double X1 = TotalValue;
                    Double X2 = txtPercent.Value;
                    const Double X3 = 100;
                    ((TextObject)MyReport.Section3.ReportObjects["txtIncomePercent"]).Text =
                        String.Format("{0:N0}", X1 * (X2 / X3)) + " ریال";
                    if (cBoxCDType.Checked)
                    {
                        Double DiscountValue = _CDDataTable.Rows[0][0] == null || _CDDataTable.Rows[0][0] == DBNull.Value
                            ? 0 : Convert.ToInt32(_CDDataTable.Rows[0][0]);

                        ((TextObject)MyReport.Section3.ReportObjects["txtTotDiscount"]).Text =
                            String.Format("{0:N0}", DiscountValue) + " ریال";
                        Double TheTotalValue = X1 * (X2 / X3);
                        ((TextObject)MyReport.Section3.ReportObjects["txtLastPrice"]).Text = String.Format("{0:N0}",
                            (TheTotalValue - (DiscountValue * txtPercent.Value / 100))) + " ریال";
                    }
                    else
                    {
                        ((TextObject)MyReport.Section3.ReportObjects["txtTotDiscount"]).Text = "0 ریال";
                        ((TextObject)MyReport.Section3.ReportObjects["txtLastPrice"]).Text =
                            ((TextObject)MyReport.Section3.ReportObjects["txtIncomePercent"]).Text;
                    }
                    #endregion
                    new frmPublicReportPreview(null, MyReport);
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
            _ServicePayable = " FROM [ImagingSystem].[Referrals].[List] AS [TblRefs] " +
                "INNER JOIN [ImagingSystem].[Referrals].[RefServices] AS [TblRefService] " +
                "ON [TblRefService].[ReferralIX] = [TblRefs].[ID] ";
            _Ins1Part = _ServicePayable;
            _Ins2Part = _ServicePayable;
            _ServicePayable = "SELECT SUM([TblRefService].[Quantity] * " +
                "CONVERT(BIGINT , [TblRefService].[PatientPayablePrice])) AS [Value]" + _ServicePayable;
            _Ins1Part = "SELECT SUM([TblRefService].[Quantity] * " +
                "CONVERT(BIGINT , [TblRefService].[Ins1PartPrice])) AS [Value]" + _Ins1Part;
            if (cBoxSpecial1.Checked)
            _Ins2Part = "SELECT SUM([TblRefService].[Quantity] * " +
                "CONVERT(BIGINT , [TblRefService].[Ins2Price])) AS [Value]" + _Ins2Part;
            else _Ins2Part = "SELECT SUM([TblRefService].[Quantity] * " +
                "CONVERT(BIGINT , [TblRefService].[Ins2PartPrice])) AS [Value]" + _Ins2Part;

            #region Set Categories INNER JOIN
            if (cBoxServiceCat.Checked)
            {
                const String CategoryInnerJoin =
                    "INNER JOIN [ImagingSystem].[Services].[List] AS [TblServices] " +
                    "ON [TblRefService].[ServiceIX] = [TblServices].[ID] ";
                _ServicePayable += CategoryInnerJoin;
                _Ins1Part += CategoryInnerJoin;
                _Ins2Part += CategoryInnerJoin;
            }
            #endregion

            #region Set Groups INNER JOIN
            if (cBoxServiceGroups.Checked)
            {
                Boolean IsAnyGroupSelected = false;
                foreach (DataGridViewRow Row in dgvServiceGroups.Rows)
                {
                    if (Row.Cells[ColGroupSelection.Name].Value != null &&
                        Convert.ToBoolean(Row.Cells[ColGroupSelection.Name].Value))
                    { IsAnyGroupSelected = true; break; }
                }
                // اگر موردی انتخاب شده باشد
                if (IsAnyGroupSelected)
                {
                    const String GroupsInnerJoin =
                        "INNER JOIN [ImagingSystem].[Services].[ServiceInGroups] AS [TblGroups] " +
                        "ON [TblRefService].[ServiceIX] = [TblGroups].[ServiceIX] ";
                    _ServicePayable += GroupsInnerJoin;
                    _Ins1Part += GroupsInnerJoin;
                    _Ins2Part += GroupsInnerJoin;
                }
            }
            #endregion

            #endregion

            #region Step 2 - Add WHERE SELECT

            #region Set RefTime Filter
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
            _ServicePayable += "WHERE [TblRefs].[RegisterDate] >= @RefDateBegin " +
                "AND [TblRefs].[RegisterDate] <= @RefDateEnd AND [TblRefService].[IsActive] = 1 ";
            _Ins1Part += " WHERE [TblRefs].[RegisterDate] >= @RefDateBegin " +
                "AND [TblRefs].[RegisterDate] <= @RefDateEnd AND [TblRefService].[IsActive] = 1 " +
                "AND [TblRefService].[IsIns1Cover] = 1 ";
            _Ins2Part += " WHERE [TblRefs].[RegisterDate] >= @RefDateBegin " +
                "AND [TblRefs].[RegisterDate] <= @RefDateEnd AND [TblRefService].[IsActive] = 1 " +
                "AND [TblRefService].[IsIns2Cover] = 1 ";
            #endregion

            #region Set Performer Filter
            if (cBoxPerformers.Checked)
            {
                Boolean IsAnySelected = false;
                if (Convert.ToBoolean(dgvPerformers.Rows[0].Cells[ColPerformerSelection.Index].Value))
                {
                    if (Convert.ToBoolean(dgvPerformers.Rows[0].Cells[ColIsExpert.Index].Value))
                    {
                        _ServicePayable += " AND ([TblRefService].[ExpertIX] IS NULL ";
                        _Ins1Part += " AND ([TblRefService].[ExpertIX] IS NULL ";
                        _Ins2Part += " AND ([TblRefService].[ExpertIX] IS NULL ";
                        IsAnySelected = true;
                    }
                    if (Convert.ToBoolean(dgvPerformers.Rows[0].Cells[ColIsPhysician.Index].Value))
                    {
                        if (IsAnySelected) { _ServicePayable += " OR"; _Ins1Part += " OR"; _Ins2Part += " OR"; }
                        else { _ServicePayable += " AND ("; _Ins1Part += " AND ("; _Ins2Part += " AND ("; }
                        _ServicePayable += " [TblRefService].[PhysicianIX] IS NULL ";
                        _Ins1Part += " [TblRefService].[PhysicianIX] IS NULL ";
                        _Ins2Part += " [TblRefService].[PhysicianIX] IS NULL ";
                        IsAnySelected = true;
                    }
                }
                foreach (DataGridViewRow row in dgvPerformers.Rows)
                {
                    if (row.Index == 0 || row.Cells[ColPerformerSelection.Index].Value == null ||
                        Convert.ToBoolean(row.Cells[ColPerformerSelection.Index].Value) == false) continue;
                    if (row.Cells[ColIsExpert.Index].Value != null &&
                        Convert.ToBoolean(row.Cells[ColIsExpert.Index].Value))
                    {
                        if (IsAnySelected) { _ServicePayable += " OR"; _Ins1Part += " OR"; _Ins2Part += " OR"; }
                        else { _ServicePayable += " AND ("; _Ins1Part += " AND ("; _Ins2Part += " AND ("; }
                        _ServicePayable += " [TblRefService].[ExpertIX] = " +
                            ((SP_SelectPerformersResult)row.DataBoundItem).ID + " ";
                        _Ins1Part += " [TblRefService].[ExpertIX] = " +
                            ((SP_SelectPerformersResult)row.DataBoundItem).ID + " ";
                        _Ins2Part += " [TblRefService].[ExpertIX] = " +
                            ((SP_SelectPerformersResult)row.DataBoundItem).ID + " ";
                        IsAnySelected = true;
                    }
                    if (row.Cells[ColIsPhysician.Index].Value != null &&
                    Convert.ToBoolean(row.Cells[ColIsPhysician.Index].Value))
                    {
                        if (IsAnySelected) { _ServicePayable += " OR"; _Ins1Part += " OR"; _Ins2Part += " OR"; }
                        else { _ServicePayable += " AND ("; _Ins1Part += " AND ("; _Ins2Part += " AND ("; }
                        _ServicePayable += " [TblRefService].[PhysicianIX] = " +
                            ((SP_SelectPerformersResult)row.DataBoundItem).ID + " ";
                        _Ins1Part += " [TblRefService].[PhysicianIX] = " +
                            ((SP_SelectPerformersResult)row.DataBoundItem).ID + " ";
                        _Ins2Part += " [TblRefService].[PhysicianIX] = " +
                            ((SP_SelectPerformersResult)row.DataBoundItem).ID + " ";
                        IsAnySelected = true;
                    }
                }
                _ServicePayable += ") ";
                _Ins1Part += ") ";
                _Ins2Part += ") ";
            }
            #endregion

            #region Set Ref Physicians Filter
            if (cBoxRefPhysycian.Checked)
            {
                Boolean IsAnySelected = false;
                if (Convert.ToBoolean(dgvRefPhysician.Rows[0].Cells[0].Value))
                {
                    _ServicePayable += " AND ([TblRefs].[ReferPhysicianIX] IS NULL ";
                    _Ins1Part += " AND ([TblRefs].[ReferPhysicianIX] IS NULL ";
                    _Ins2Part += " AND ([TblRefs].[ReferPhysicianIX] IS NULL ";
                    IsAnySelected = true;
                }
                foreach (DataGridViewRow row in dgvRefPhysician.Rows)
                {
                    if (row.Index == 0 || row.Cells[ColRefPhysicianSelection.Index].Value == null ||
                        Convert.ToBoolean(row.Cells[ColRefPhysicianSelection.Index].Value) == false) continue;
                    if (IsAnySelected) { _ServicePayable += " OR"; _Ins1Part += " OR"; _Ins2Part += " OR"; }
                    else { _ServicePayable += " AND ("; _Ins1Part += " AND ("; _Ins2Part += " AND ("; }
                    _ServicePayable += " [TblRefs].[ReferPhysicianIX] = " +
                        ((SP_SelectRefPhysiciansFullDataListResult)row.DataBoundItem).ID + " ";
                    _Ins1Part += " [TblRefs].[ReferPhysicianIX] = " +
                        ((SP_SelectRefPhysiciansFullDataListResult)row.DataBoundItem).ID + " ";
                    _Ins2Part += " [TblRefs].[ReferPhysicianIX] = " +
                        ((SP_SelectRefPhysiciansFullDataListResult)row.DataBoundItem).ID + " ";
                    IsAnySelected = true;
                }
                _ServicePayable += ") ";
                _Ins1Part += ") ";
                _Ins2Part += ") ";
            }
            #endregion

            #region Set Categories Filter
            if (cBoxServiceCat.Checked)
            {
                Boolean IsAnySelected = false;
                if (Convert.ToBoolean(dgvServiceCat.Rows[0].Cells[0].Value))
                {
                    _ServicePayable += " AND ([TblServices].[CategoryIX] IS NULL ";
                    _Ins1Part += " AND ([TblServices].[CategoryIX] IS NULL ";
                    _Ins2Part += " AND ([TblServices].[CategoryIX] IS NULL ";
                    IsAnySelected = true;
                }
                String SelectedID = String.Empty;
                foreach (DataGridViewRow Row in dgvServiceCat.Rows)
                    if (Row.Index != 0 && Row.Cells[ColCatSelection.Name].Value != null &&
                        Convert.ToBoolean(Row.Cells[ColCatSelection.Name].Value))
                        SelectedID += ((SP_SelectCategoriesResult)Row.DataBoundItem).ID + " , ";
                // اگر موردی انتخاب شده باشد
                if (!String.IsNullOrEmpty(SelectedID))
                {
                    if (IsAnySelected) { _ServicePayable += " OR"; _Ins1Part += " OR"; _Ins2Part += " OR"; }
                    else { _ServicePayable += " AND ("; _Ins1Part += " AND ("; _Ins2Part += " AND ("; }
                    // حذف آخرین ویرگول از لیست
                    SelectedID = SelectedID.Substring(0, SelectedID.Length - 3);
                    _ServicePayable += " [TblServices].[CategoryIX] IN (" + SelectedID + ")";
                    _Ins1Part += " [TblServices].[CategoryIX] IN (" + SelectedID + ")";
                    _Ins2Part += " [TblServices].[CategoryIX] IN (" + SelectedID + ")";
                }
                _ServicePayable += ") ";
                _Ins1Part += ") ";
                _Ins2Part += ") ";
            }
            #endregion

            #region Set Groups Filter
            if (cBoxServiceGroups.Checked)
            {
                String SelectedID = String.Empty;
                foreach (DataGridViewRow Row in dgvServiceGroups.Rows)
                {
                    if (Row.Cells[ColGroupSelection.Index].Value != null &&
                        Convert.ToBoolean(Row.Cells[ColGroupSelection.Index].Value))
                        SelectedID += ((SP_SelectGroupsResult)Row.DataBoundItem).ID + " , ";
                }
                // اگر موردی انتخاب شده باشد
                if (!String.IsNullOrEmpty(SelectedID))
                {
                    // حذف آخرین ویرگول از لیست
                    SelectedID = SelectedID.Substring(0, SelectedID.Length - 3);
                    _ServicePayable += " AND [TblGroups].[GroupIX] IN (" + SelectedID + ") ";
                    _Ins1Part += " AND [TblGroups].[GroupIX] IN (" + SelectedID + ") ";
                    _Ins2Part += " AND [TblGroups].[GroupIX] IN (" + SelectedID + ") ";
                }
            }
            #endregion

            #region Set Services Filter
            if (cBoxService.Checked)
            {
                String SelectedID = String.Empty;
                foreach (DataGridViewRow Row in dgvService.Rows)
                {
                    if (Row.Cells[ColServiceSelection.Index].Value != null &&
                        Convert.ToBoolean(Row.Cells[ColServiceSelection.Index].Value))
                        SelectedID += ((SP_SelectServicesListResult)Row.DataBoundItem).ID + " , ";
                }
                // اگر موردی انتخاب شده باشد
                if (!String.IsNullOrEmpty(SelectedID))
                {
                    // حذف آخرین ویرگول از لیست
                    SelectedID = SelectedID.Substring(0, SelectedID.Length - 3);
                    _ServicePayable += " AND [TblRefService].[ServiceIX] IN (" + SelectedID + ") ";
                    _Ins1Part += " AND [TblRefService].[ServiceIX] IN (" + SelectedID + ") ";
                    _Ins2Part += " AND [TblRefService].[ServiceIX] IN (" + SelectedID + ") ";
                }
            }
            #endregion

            #region Set Document User Filter
            if (cBoxDocTypist.Checked)
            {
                String SelectedID = String.Empty;
                foreach (DataGridViewRow Row in dgvDocUser.Rows)
                {
                    if (Row.Cells[ColDocUserSelection.Index].Value != null &&
                        Convert.ToBoolean(Row.Cells[ColDocUserSelection.Index].Value))
                        SelectedID += ((SP_SelectUsersResult)Row.DataBoundItem).ID + " , ";
                }
                // اگر موردی انتخاب شده باشد
                if (!String.IsNullOrEmpty(SelectedID))
                {
                    // حذف آخرین ویرگول از لیست
                    SelectedID = SelectedID.Substring(0, SelectedID.Length - 3);
                    String DocFilter = " AND (SELECT COUNT(*) FROM [ImagingSystem].[Referrals].[RefDocuments] AS [RefDoc] " +
                        "WHERE [RefDoc].[RefIX] = [TblRefs].[ID] AND [RefDoc].[TypistIX] IN (" + SelectedID + ")) > 0";
                    _ServicePayable += DocFilter;
                    _Ins1Part += DocFilter;
                    _Ins2Part += DocFilter;
                }
            }
            #endregion

            #region Set Ins1 Filter
            if (cBoxIns1.Checked)
            {
                String SelectedID = String.Empty;
                foreach (DataGridViewRow Row in dgvIns1.Rows)
                {
                    if (Row.Cells[ColInsSelection1.Index].Value != null &&
                        Convert.ToBoolean(Row.Cells[ColInsSelection1.Name].Value))
                        SelectedID += ((SP_SelectInsFullDataResult)Row.DataBoundItem).ID + " , ";
                }
                // اگر بیمه ای انتخاب نشده باشد
                if (String.IsNullOrEmpty(SelectedID))
                {
                    PMBox.Show("برای ایجاد گزارش باید حتماً بیمه ای را انتخاب نمایید!", "خطا!",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                // حذف آخرین ویرگول از لیست
                SelectedID = SelectedID.Substring(0, SelectedID.Length - 3);
                String InsFilter = " AND [TblRefs].[Ins1IX] IN (" + SelectedID + ")";
                _ServicePayable += InsFilter;
                _Ins1Part += InsFilter;
                _Ins2Part += InsFilter;
            }
            #endregion

            #region Set Ins2 Filter
            if (cBoxIns2.Checked)
            {
                String SelectedID = String.Empty;
                foreach (DataGridViewRow Row in dgvIns2.Rows)
                {
                    if (Row.Cells[ColInsSelection2.Index].Value != null &&
                        Convert.ToBoolean(Row.Cells[ColInsSelection2.Name].Value))
                        SelectedID += ((SP_SelectInsFullDataResult)Row.DataBoundItem).ID + " , ";
                }
                // اگر بیمه ای انتخاب نشده باشد
                if (String.IsNullOrEmpty(SelectedID))
                {
                    PMBox.Show("برای ایجاد گزارش باید حتماً بیمه ای را انتخاب نمایید!", "خطا!",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                // حذف آخرین ویرگول از لیست
                SelectedID = SelectedID.Substring(0, SelectedID.Length - 3);
                String InsFilter = " AND [TblRefs].[Ins2IX] IN (" + SelectedID + ")";
                _ServicePayable += InsFilter;
                _Ins1Part += InsFilter;
                _Ins2Part += InsFilter;
            }
            #endregion

            #endregion

            if (_CalcReportRowCount)
            {
                _ServicePayable = "SELECT COUNT (*) FROM (" + _ServicePayable + ") AS TBL";
                _Ins1Part = "SELECT COUNT (*) FROM (" + _Ins1Part + ") AS TBL";
                _ServicePayable = "SELECT COUNT (*) FROM (" + _Ins2Part + ") AS TBL";
            }
            return true;
        }
        #endregion

        #region Boolean GenerateCDString()
        /// <summary>
        /// تابع تولید فرمان جستجوی گزارش
        /// </summary>
        /// <returns>صحت انجام كار</returns>
        private Boolean GenerateCDString()
        {
            #region Prepare SqlConnection & SqlCommand
            SqlConnection MyConnection = new SqlConnection(CSManager.GetConnectionString("PatientsSystem"));
            _CDSqlCommand = new SqlCommand();
            _CDSqlCommand.CommandTimeout = 0;
            _CDSqlCommand.Connection = MyConnection;
            #endregion

            #region Step 1 - SELECT Columns & INNER JOINs
            StringBuilder ReportSelectString = new StringBuilder();
            ReportSelectString.Append("SELECT SUM([TblCD].[Value]) " +
                "FROM [ImagingSystem].[Referrals].[List] AS [TblRefs] " +
                "INNER JOIN [ImagingSystem].[Accounting].[RefCostsAndDiscounts] AS [TblCD] " +
                "ON [TblCD].[ReferralIX] = [TblRefs].[ID] ");
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
            _CDSqlCommand.Parameters.Add(Param1);
            _CDSqlCommand.Parameters.Add(Param2);
            #endregion
            ReportSelectWhereString.Append(
                " WHERE [TblRefs].[RegisterDate] >= @RefDateBegin AND [TblRefs].[RegisterDate] <= @RefDateEnd ");
            #endregion

            #region Set Ref Physicians Filter
            if (cBoxRefPhysycian.Checked)
            {
                Boolean IsAnySelected = false;
                if (Convert.ToBoolean(dgvRefPhysician.Rows[0].Cells[0].Value))
                {
                    ReportSelectWhereString.Append(" AND ([TblRefs].[ReferPhysicianIX] IS NULL ");
                    IsAnySelected = true;
                }
                foreach (DataGridViewRow row in dgvRefPhysician.Rows)
                {
                    if (row.Index == 0 || row.Cells[ColRefPhysicianSelection.Index].Value == null ||
                        Convert.ToBoolean(row.Cells[ColRefPhysicianSelection.Index].Value) == false) continue;
                    if (IsAnySelected) ReportSelectWhereString.Append(" OR");
                    else ReportSelectWhereString.Append(" AND (");
                    ReportSelectWhereString.Append(" [TblRefs].[ReferPhysicianIX] = " +
                        ((SP_SelectRefPhysiciansFullDataListResult)row.DataBoundItem).ID + " ");
                    IsAnySelected = true;
                }
                ReportSelectWhereString.Append(") ");
            }
            #endregion

            #region Set Document User Filter
            if (cBoxDocTypist.Checked)
            {
                String SelectedID = String.Empty;
                foreach (DataGridViewRow Row in dgvDocUser.Rows)
                {
                    if (Row.Cells[ColDocUserSelection.Index].Value != null &&
                        Convert.ToBoolean(Row.Cells[ColDocUserSelection.Index].Value))
                        SelectedID += ((SP_SelectUsersResult)Row.DataBoundItem).ID + " , ";
                }
                // اگر موردی انتخاب شده باشد
                if (!String.IsNullOrEmpty(SelectedID))
                {
                    // حذف آخرین ویرگول از لیست
                    SelectedID = SelectedID.Substring(0, SelectedID.Length - 3);
                    String DocFilter = " AND (SELECT COUNT(*) FROM [ImagingSystem].[Referrals].[RefDocuments] AS [RefDoc] " +
                        "WHERE [RefDoc].[RefIX] = [TblRefs].[ID] AND [RefDoc].[TypistIX] IN (" + SelectedID + ")) > 0";
                    ReportSelectWhereString.Append(DocFilter);
                }
            }
            #endregion

            #region Set Performer Filter
            if (cBoxPerformers.Checked)
            {
                Boolean IsAnySelected = false;
                if (Convert.ToBoolean(dgvPerformers.Rows[0].Cells[ColPerformerSelection.Index].Value))
                {
                    if (Convert.ToBoolean(dgvPerformers.Rows[0].Cells[ColIsExpert.Index].Value))
                    {
                        ReportSelectWhereString.Append(
                            " AND ( (SELECT COUNT(*) FROM [ImagingSystem].[Referrals].[RefServices] AS [TblRefService] " +
                        "WHERE [TblRefService].[ReferralIX] = [TblRefs].[ID] AND [TblRefService].[ExpertIX] IS NULL) > 0");
                        IsAnySelected = true;
                    }
                    if (Convert.ToBoolean(dgvPerformers.Rows[0].Cells[ColIsPhysician.Index].Value))
                    {
                        if (IsAnySelected) ReportSelectWhereString.Append(" OR");
                        else ReportSelectWhereString.Append(" AND (");
                        ReportSelectWhereString.Append(
                            " (SELECT COUNT(*) FROM [ImagingSystem].[Referrals].[RefServices] AS [TblRefService] " +
                            "WHERE [TblRefService].[ReferralIX] = [TblRefs].[ID] AND [TblRefService].[PhysicianIX] IS NULL) > 0");
                        IsAnySelected = true;
                    }
                }
                foreach (DataGridViewRow row in dgvPerformers.Rows)
                {
                    if (row.Index == 0 || row.Cells[ColPerformerSelection.Index].Value == null ||
                        Convert.ToBoolean(row.Cells[ColPerformerSelection.Index].Value) == false) continue;
                    if (row.Cells[ColIsExpert.Index].Value != null &&
                        Convert.ToBoolean(row.Cells[ColIsExpert.Index].Value))
                    {
                        if (IsAnySelected) ReportSelectWhereString.Append(" OR");
                        else ReportSelectWhereString.Append(" AND (");
                        ReportSelectWhereString.Append(
                            " (SELECT COUNT(*) FROM [ImagingSystem].[Referrals].[RefServices] AS [TblRefService] " +
                            "WHERE [TblRefService].[ReferralIX] = [TblRefs].[ID] AND [TblRefService].[ExpertIX] = " +
                            ((SP_SelectPerformersResult)row.DataBoundItem).ID + " " + ") > 0");
                        IsAnySelected = true;
                    }
                    if (row.Cells[ColIsPhysician.Index].Value != null &&
                    Convert.ToBoolean(row.Cells[ColIsPhysician.Index].Value))
                    {
                        if (IsAnySelected) ReportSelectWhereString.Append(" OR");
                        else ReportSelectWhereString.Append(" AND (");
                        ReportSelectWhereString.Append(
                            " (SELECT COUNT(*) FROM [ImagingSystem].[Referrals].[RefServices] AS [TblRefService] " +
                            "WHERE [TblRefService].[ReferralIX] = [TblRefs].[ID] AND [TblRefService].[PhysicianIX] = " +
                            ((SP_SelectPerformersResult)row.DataBoundItem).ID + " " + ") > 0");
                        IsAnySelected = true;
                    }
                }
                ReportSelectWhereString.Append(")");
            }
            #endregion

            #region Set Categories Filter
            if (cBoxServiceCat.Checked)
            {
                Boolean IsAnySelected = false;
                if (Convert.ToBoolean(dgvServiceCat.Rows[0].Cells[0].Value))
                {
                    ReportSelectWhereString.Append(
                        " AND ((SELECT COUNT(*) FROM [ImagingSystem].[Referrals].[RefServices] AS [TblRefService] " +
                        "INNER JOIN [ImagingSystem].[Services].[List] AS [TblServices] " +
                        "ON [TblRefService].[ServiceIX] = [TblServices].[ID] " +
                        "WHERE [TblRefService].[ReferralIX] = [TblRefs].[ID] AND [TblServices].[CategoryIX] IS NULL) > 0 ");
                    IsAnySelected = true;
                }
                String SelectedID = String.Empty;
                foreach (DataGridViewRow Row in dgvServiceCat.Rows)
                    if (Row.Index != 0 && Row.Cells[ColCatSelection.Name].Value != null &&
                        Convert.ToBoolean(Row.Cells[ColCatSelection.Name].Value))
                        SelectedID += ((SP_SelectCategoriesResult)Row.DataBoundItem).ID + " , ";
                // اگر موردی انتخاب شده باشد
                if (!String.IsNullOrEmpty(SelectedID))
                {
                    if (IsAnySelected) ReportSelectWhereString.Append(" OR ");
                    else ReportSelectWhereString.Append(" AND (");
                    // حذف آخرین ویرگول از لیست
                    SelectedID = SelectedID.Substring(0, SelectedID.Length - 3);
                    ReportSelectWhereString.Append(
                        " (SELECT COUNT(*) FROM [ImagingSystem].[Referrals].[RefServices] AS [TblRefService] " +
                        " INNER JOIN [ImagingSystem].[Services].[List] AS [TblServices] " +
                        " ON [TblRefService].[ServiceIX] = [TblServices].[ID] " +
                        "WHERE [TblRefService].[ReferralIX] = [TblRefs].[ID] AND [TblServices].[CategoryIX] IN (" + SelectedID + ")) > 0 ");
                }
                ReportSelectWhereString.Append(") ");
            }
            #endregion

            #region Set Groups Filter
            if (cBoxServiceGroups.Checked)
            {
                String SelectedID = String.Empty;
                foreach (DataGridViewRow Row in dgvServiceGroups.Rows)
                {
                    if (Row.Cells[ColGroupSelection.Index].Value != null &&
                        Convert.ToBoolean(Row.Cells[ColGroupSelection.Index].Value))
                        SelectedID += ((SP_SelectGroupsResult)Row.DataBoundItem).ID + " , ";
                }
                // اگر موردی انتخاب شده باشد
                if (!String.IsNullOrEmpty(SelectedID))
                {
                    // حذف آخرین ویرگول از لیست
                    SelectedID = SelectedID.Substring(0, SelectedID.Length - 3);
                    ReportSelectWhereString.Append(
                        " AND (SELECT COUNT(*) FROM [ImagingSystem].[Referrals].[RefServices] AS [TblRefService] " +
                        "INNER JOIN [ImagingSystem].[Services].[List] AS [TblServices] " +
                        "ON [TblRefService].[ServiceIX] = [TblServices].[ID] " +
                        "LEFT OUTER JOIN [ImagingSystem].[Services].[ServiceInGroups] AS [TblGroups] " +
                        "ON [TblServices].[ID] = [TblGroups].[ServiceIX] " +
                        "WHERE [TblRefService].[ReferralIX] = [TblRefs].[ID] AND [TblGroups].[GroupIX] IN (" + SelectedID + ")) > 0");
                }
            }
            #endregion

            #region Set Services Filter
            if (cBoxService.Checked)
            {
                String SelectedID = String.Empty;
                foreach (DataGridViewRow Row in dgvService.Rows)
                {
                    if (Row.Cells[ColServiceSelection.Index].Value != null &&
                        Convert.ToBoolean(Row.Cells[ColServiceSelection.Index].Value))
                        SelectedID += ((SP_SelectServicesListResult)Row.DataBoundItem).ID + " , ";
                }
                // اگر موردی انتخاب شده باشد
                if (!String.IsNullOrEmpty(SelectedID))
                {
                    // حذف آخرین ویرگول از لیست
                    SelectedID = SelectedID.Substring(0, SelectedID.Length - 3);
                    ReportSelectWhereString.Append(
                        " AND (SELECT COUNT(*) FROM [ImagingSystem].[Referrals].[RefServices] AS [TblRefService] " +
                        "WHERE [TblRefService].[ReferralIX] = [TblRefs].[ID] AND [TblRefService].[ServiceIX] IN (" + SelectedID + ")) > 0");
                }
            }
            #endregion

            #region Set Discount Filter
            if (cBoxCDType.Checked)
            {
                String SelectedID = String.Empty;
                foreach (DataGridViewRow Row in dgvCostsAndDiscounts.Rows)
                {
                    if (Row.Cells[ColCDTypeSelection.Index].Value != null &&
                        Convert.ToBoolean(Row.Cells[ColCDTypeSelection.Index].Value))
                        SelectedID += ((CostsAndDiscountsType)Row.DataBoundItem).ID + " , ";
                }
                if (String.IsNullOrEmpty(SelectedID)) return false;
                // اگر موردی انتخاب شده باشد
                // حذف آخرین ویرگول از لیست
                SelectedID = SelectedID.Substring(0, SelectedID.Length - 3);
                String DocFilter = " AND [TblCD].[CostIXOrDiscountIX] IN (" + SelectedID + ") ";
                ReportSelectWhereString.Append(DocFilter);
            }
            #endregion

            #region Set Ins1 Filter
            if (cBoxIns1.Checked)
            {
                String SelectedID = String.Empty;
                foreach (DataGridViewRow Row in dgvIns1.Rows)
                {
                    if (Row.Cells[ColInsSelection1.Index].Value != null &&
                        Convert.ToBoolean(Row.Cells[ColInsSelection1.Name].Value))
                        SelectedID += ((SP_SelectInsFullDataResult)Row.DataBoundItem).ID + " , ";
                }
                // اگر بیمه ای انتخاب نشده باشد
                if (String.IsNullOrEmpty(SelectedID))
                {
                    PMBox.Show("برای ایجاد گزارش باید حتماً بیمه ای را انتخاب نمایید!", "خطا!",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                // حذف آخرین ویرگول از لیست
                SelectedID = SelectedID.Substring(0, SelectedID.Length - 3);
                ReportSelectWhereString.Append(" AND [TblRefs].[Ins1IX] IN (" + SelectedID + ")");
            }
            #endregion

            #region Set Ins2 Filter
            if (cBoxIns2.Checked)
            {
                String SelectedID = String.Empty;
                foreach (DataGridViewRow Row in dgvIns2.Rows)
                {
                    if (Row.Cells[ColInsSelection2.Index].Value != null &&
                        Convert.ToBoolean(Row.Cells[ColInsSelection2.Name].Value))
                        SelectedID += ((SP_SelectInsFullDataResult)Row.DataBoundItem).ID + " , ";
                }
                // اگر بیمه ای انتخاب نشده باشد
                if (String.IsNullOrEmpty(SelectedID))
                {
                    PMBox.Show("برای ایجاد گزارش باید حتماً بیمه ای را انتخاب نمایید!", "خطا!",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                // حذف آخرین ویرگول از لیست
                SelectedID = SelectedID.Substring(0, SelectedID.Length - 3);
                ReportSelectWhereString.Append(" AND [TblRefs].[Ins2IX] IN (" + SelectedID + ")");
            }
            #endregion

            #endregion

            _CDSqlCommand.CommandText = ReportSelectString.Append(ReportSelectWhereString).ToString();
            return true;
        }
        #endregion

        #endregion

    }
}