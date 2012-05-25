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

namespace Sepehr.Forms.Reports.General.Report12
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

        #region SqlCommand _CDSqlCommand
        private SqlCommand _CDSqlCommand;
        #endregion

        #region DataTable _ReportDataTable
        private DataTable _ReportDataTable;
        #endregion

        #region DataTable _CDDataTable
        private DataTable _CDDataTable;
        #endregion

        #region Boolean _IsCDActive
        private Boolean _IsCDActive;
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
            dgvRefPhysician.AutoGenerateColumns = false;
            dgvServiceCat.AutoGenerateColumns = false;
            dgvServiceGroups.AutoGenerateColumns = false;
            dgvService.AutoGenerateColumns = false;
            dgvDocUser.AutoGenerateColumns = false;
            dgvCostsAndDiscounts.AutoGenerateColumns = false;
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
            if (!ReadTopics()) { Close(); return; }
            SetControlsToolTipTexts();
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

        #region cBoxCDType_CheckedChanged
        private void cBoxCDType_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxCDType.Checked)
                dgvCostsAndDiscounts.DataSource = DBLayerIMS.Account.CostAndDiscountFullList.Where(Data => !Data.IsCost).ToList();
            else dgvCostsAndDiscounts.DataSource = null;
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
            #region Execute SqlCommand
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
            #endregion

            #region Replace PersianDateTime With Original Data
            if (!_CalcReportRowCount)
            {
                _ReportDataTable.Columns["RegisterDateFa"].ReadOnly = false;
                for (Int16 i = 0; i < _ReportDataTable.Rows.Count; i++)
                {
                    PersianDate PDate =
                        Convert.ToDateTime(_ReportDataTable.Rows[i]["RegisterDate"]).ToPersianDate();
                    _ReportDataTable.Rows[i]["RegisterDateFa"] = PDate.Year + "/" + PDate.Month + "/" + PDate.Day + " - " +
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
                if (!e.Cancelled)
                {
                    #region Make Report
                    Report12 MyReport = new Report12();
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
                    if (cBoxCDType.Checked)
                    {
                        Int32 DiscountValue = _CDDataTable.Rows[0][0] == null || _CDDataTable.Rows[0][0] == DBNull.Value
                            ? 0 : Convert.ToInt32(_CDDataTable.Rows[0][0]);

                        ((TextObject)MyReport.Section4.ReportObjects["txtCD2"]).Text = String.Format("{0:N0}", DiscountValue);
                        Object LastValue = _ReportDataTable.Compute("Sum(PerformerPart)", String.Empty);
                        Int32 TotalValue = LastValue == null || LastValue == DBNull.Value ? 0 : Convert.ToInt32(LastValue);
                        ((TextObject)MyReport.Section4.ReportObjects["txtCD4"]).Text = String.Format("{0:N0}",
                            (TotalValue - (DiscountValue * txtPercent.Value / 100)));
                    }
                    else
                    {
                        ((TextObject)MyReport.Section4.ReportObjects["txtCD1"]).Text = String.Empty;
                        ((TextObject)MyReport.Section4.ReportObjects["txtCD2"]).Text = String.Empty;
                        ((TextObject)MyReport.Section4.ReportObjects["txtCD3"]).Text = String.Empty;
                        ((TextObject)MyReport.Section4.ReportObjects["txtCD4"]).Text = String.Empty;
                    }
                    #endregion
                    if (!SaveTopics()) { Close(); return; }
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
            ReportSelectString.Append("SELECT [TblPatients].[PatientID], " +
                "[TblRefs].[ID] AS [RefID] , " +
                "[TblRefs].[RegisterDate], " +
                "'1380/10/01 - 12:20:50' AS [RegisterDateFa], " +
                "[TblServices].[Name] AS [ServiceName], " +
                "[TblRefService].[Quantity] AS [ServiceQty], " +
                "[TblRefService].[PatientPayablePrice] AS [PatientPayablePrice], " +
                "ISNULL([TblRefService].[Ins1PartPrice], 0) AS [Ins1PartPrice], ");
            if (cBoxSpecial1.Checked) ReportSelectString.Append(
                "ISNULL([TblRefService].[Ins2Price], 0) AS [Ins2PartPrice], ");
            else ReportSelectString.Append(
                "ISNULL([TblRefService].[Ins2PartPrice], 0) AS [Ins2PartPrice], ");
            ReportSelectString.Append("ISNULL([TblRefService].[Ins2PartPrice], 0) AS [Ins2PartPrice], " +
            "ISNULL([TblRefService].[PatientPayablePrice] * [TblRefService].[Quantity], 0) " +
            "+ ISNULL([TblRefService].[Ins1PartPrice] * [TblRefService].[Quantity], 0) + ");
            if (cBoxSpecial1.Checked) ReportSelectString.Append(
                "ISNULL([TblRefService].[Ins2Price] * [TblRefService].[Quantity], 0) AS [TotalIncome], ");
            else ReportSelectString.Append(
                "ISNULL([TblRefService].[Ins2PartPrice] * [TblRefService].[Quantity], 0) AS [TotalIncome], ");
            ReportSelectString.Append(
                "((ISNULL([TblRefService].[PatientPayablePrice] * [TblRefService].[Quantity], 0) + " +
                "ISNULL([TblRefService].[Ins1PartPrice] * [TblRefService].[Quantity], 0) + ");
            if (cBoxSpecial1.Checked) ReportSelectString.Append(
                "ISNULL([TblRefService].[Ins2Price] * [TblRefService].[Quantity], 0)) * ");
            else ReportSelectString.Append(
                "ISNULL([TblRefService].[Ins2PartPrice] * [TblRefService].[Quantity], 0)) * ");
            ReportSelectString.Append(
            txtPercent.Value + " / 100) AS [PerformerPart] " +
            "FROM [PatientsSystem].[Patients].[List] AS [TblPatients] " +
            "INNER JOIN [ImagingSystem].[Referrals].[List] AS [TblRefs] " +
            "ON [TblPatients].[ID] = [TblRefs].[PatientIX] " +
            "INNER JOIN [ImagingSystem].[Referrals].[RefServices] AS [TblRefService] " +
            "ON [TblRefService].[ReferralIX] = [TblRefs].[ID] " +
            "INNER JOIN [ImagingSystem].[Services].[List] AS [TblServices] " +
            "ON [TblRefService].[ServiceIX] = [TblServices].[ID] ");

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
                    const String GroupsInnerJoin = "INNER JOIN [ImagingSystem].[Services].[ServiceInGroups] AS [TblGroups] " +
                        "ON [TblRefService].[ServiceIX] = [TblGroups].[ServiceIX] ";
                    ReportSelectString.Append(GroupsInnerJoin);
                }
            }
            #endregion

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
                " WHERE [TblRefs].[RegisterDate] >= @RefDateBegin AND [TblRefs].[RegisterDate] <= @RefDateEnd " +
                "AND [TblRefService].[IsActive] = 1 ");
            #endregion

            #region Set Performer Filter
            if (cBoxPerformers.Checked)
            {
                Boolean IsAnySelected = false;
                if (Convert.ToBoolean(dgvPerformers.Rows[0].Cells[ColPerformerSelection.Index].Value))
                {
                    if (Convert.ToBoolean(dgvPerformers.Rows[0].Cells[ColIsExpert.Index].Value))
                    {
                        ReportSelectWhereString.Append(" AND ([TblRefService].[ExpertIX] IS NULL ");
                        IsAnySelected = true;
                    }
                    if (Convert.ToBoolean(dgvPerformers.Rows[0].Cells[ColIsPhysician.Index].Value))
                    {
                        if (IsAnySelected) ReportSelectWhereString.Append(" OR");
                        else ReportSelectWhereString.Append(" AND (");
                        ReportSelectWhereString.Append(" [TblRefService].[PhysicianIX] IS NULL ");
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
                        ReportSelectWhereString.Append(" [TblRefService].[ExpertIX] = " +
                            ((SP_SelectPerformersResult)row.DataBoundItem).ID + " ");
                        IsAnySelected = true;
                    }
                    if (row.Cells[ColIsPhysician.Index].Value != null &&
                    Convert.ToBoolean(row.Cells[ColIsPhysician.Index].Value))
                    {
                        if (IsAnySelected) ReportSelectWhereString.Append(" OR");
                        else ReportSelectWhereString.Append(" AND (");
                        ReportSelectWhereString.Append(" [TblRefService].[PhysicianIX] = " +
                            ((SP_SelectPerformersResult)row.DataBoundItem).ID + " ");
                        IsAnySelected = true;
                    }
                }
                ReportSelectWhereString.Append(") ");
            }
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

            #region Set Categories Filter
            if (cBoxServiceCat.Checked)
            {
                Boolean IsAnySelected = false;
                if (Convert.ToBoolean(dgvServiceCat.Rows[0].Cells[0].Value))
                {
                    ReportSelectWhereString.Append(" AND ([TblServices].[CategoryIX] IS NULL ");
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
                    if (IsAnySelected) ReportSelectWhereString.Append(" OR");
                    else ReportSelectWhereString.Append(" AND (");
                    // حذف آخرین ویرگول از لیست
                    SelectedID = SelectedID.Substring(0, SelectedID.Length - 3);
                    ReportSelectWhereString.Append(" [TblServices].[CategoryIX] IN (" + SelectedID + ")");
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
                    ReportSelectWhereString.Append(" AND [TblGroups].[GroupIX] IN (" + SelectedID + ") ");
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
                    ReportSelectWhereString.Append(" AND [TblRefService].[ServiceIX] IN (" + SelectedID + ") ");
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
                    ReportSelectWhereString.Append(DocFilter);
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

            _ReportSqlCommand.CommandText = ReportSelectString.Append(ReportSelectWhereString).ToString();
            if (_CalcReportRowCount)
                _ReportSqlCommand.CommandText = "SELECT COUNT (*) FROM (" + _ReportSqlCommand.CommandText + ") AS TBL";
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

        #region  Boolean ReadTopics()
        /// <summary>
        /// تابع خواندن عناوین ذخیره شده در بانك
        /// </summary>
        /// <returns>صحت انجام كار</returns>
        private Boolean ReadTopics()
        {
            List<UsersSetting> Setting914 = DBLayerIMS.Settings.CurrentUserSettingsFullList.
                Where(Data => Data.SettingIX == 914).ToList();
            if (Setting914.Count != 0 && !String.IsNullOrEmpty(Setting914.First().Value)) txtReportTitle.Text = Setting914.First().Value;
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
            if (!DBLayerIMS.Settings.InsertCurrentUserSetting(914, null, txtReportTitle.Text.Normalize())) return false;
            return true;
        }
        #endregion

        #endregion

    }
}