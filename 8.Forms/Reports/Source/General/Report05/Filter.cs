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

namespace Sepehr.Forms.Reports.General.Report05
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
            dgvServiceCat.AutoGenerateColumns = false;
            dgvServiceGroups.AutoGenerateColumns = false;
            dgvInsFilter.AutoGenerateColumns = false;
            List<SP_SelectInsFullDataResult> tempInsList = DBLayerIMS.Insurance.InsFullList;
            if (tempInsList == null) { Close(); return; }
            dgvInsFilter.DataSource = tempInsList.
                Where(Data => Data.IsIns1 == true && Data.ID != null).ToList();
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

        #region cBoxServiceCat_CheckedChanged
        private void cBoxServiceCat_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxServiceCat.Checked) dgvServiceCat.DataSource =
                DBLayerIMS.Services.ServCategoriesList.Where(Data => Data.ID != null).ToList();
            else dgvServiceCat.DataSource = null;
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

        #region cBoxIns1_CheckedChanged
        private void cBoxIns1_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxIns1.Checked)
                dgvInsFilter.DataSource = DBLayerIMS.Insurance.InsFullList.Where(Data => Data.IsIns1 == true && Data.ID != null).ToList();
            else dgvInsFilter.DataSource = DBLayerIMS.Insurance.InsFullList.Where(Data => Data.IsIns2 == true && Data.ID != null).ToList();
        }
        #endregion

        #region btnReport_Click
        private void btnReport_Click(object sender, EventArgs e)
        {
            if (sender.GetType().Equals(typeof(Boolean))) _CalcReportRowCount = true;
            else _CalcReportRowCount = false;
            dgvServiceCat.EndEdit();
            dgvServiceGroups.EndEdit();
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
                #region Make Report

                Report5 MyReport = new Report5();
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
                "ISNULL([TblPatients].[FirstName] + ' ' , '') +	[TblPatients].[LastName] AS [FullName], " +
                "[TblRefs].[ID] AS [RefID] , " +
                "[TblRefs].[RegisterDate], " +
                "'1380/10/01 - 12:20:50' AS [RegisterDateFa], " +
                "[TblServices].[Name] AS [ServiceName], " +
                "[TblRefService].[Quantity] AS [ServiceQty], " +
                "[TblRefService].[PatientPayablePrice] * [TblRefService].[Quantity] AS [PatientPayablePrice], " +
                "ISNULL([TblRefService].[Ins1PartPrice] * [TblRefService].[Quantity], 0) AS [Ins1PartPrice], " +
                "ISNULL([TblRefService].[Ins2PartPrice] * [TblRefService].[Quantity], 0) AS [Ins2PartPrice], " +
                "ISNULL([TblRefService].[PatientPayablePrice] * [TblRefService].[Quantity], 0) " +
                "+ ISNULL([TblRefService].[Ins1PartPrice] * [TblRefService].[Quantity], 0) + " +
                "ISNULL([TblRefService].[Ins2PartPrice] * [TblRefService].[Quantity], 0) AS [TotalIncome] " +
                "FROM [PatientsSystem].[Patients].[List] AS [TblPatients] " +
                "INNER JOIN [ImagingSystem].[Referrals].[List] AS [TblRefs] " +
                "ON [TblPatients].[ID] = [TblRefs].[PatientIX] " +
                "INNER JOIN [ImagingSystem].[Referrals].[RefServices] AS [TblRefService] " +
                "ON [TblRefService].[ReferralIX] = [TblRefs].[ID] " +
                "INNER JOIN [ImagingSystem].[Services].[List] AS [TblServices] " +
                "ON [TblRefService].[ServiceIX] = [TblServices].[ID] ");
            #endregion

            #region Step 2 - Add WHERE SELECT
            StringBuilder ReportSelectWhereString = new StringBuilder();

            #region RefTime And RefService Active
            if (cBoxDateIsPID.Checked)
            {
                PersianDate beginDateFa = FromDateRef.SelectedDateTime.Value.ToPersianDate();
                String IDBegin = beginDateFa.Year.ToString().Substring(2, 2);
                if (beginDateFa.Month < 10)
                    IDBegin += "0" + beginDateFa.Month;
                else IDBegin += beginDateFa.Month;
                if (beginDateFa.Day < 10)
                    IDBegin += "0" + beginDateFa.Day;
                else IDBegin += beginDateFa.Day;
                PersianDate endDateFa = ToDateRef.SelectedDateTime.Value.ToPersianDate();
                String IDEnd = endDateFa.Year.ToString().Substring(2, 2);
                if (endDateFa.Month < 10)
                    IDEnd += "0" + endDateFa.Month;
                else IDEnd += endDateFa.Month;
                if (endDateFa.Day < 10)
                    IDEnd += "0" + endDateFa.Day;
                else IDEnd += endDateFa.Day;
                ReportSelectWhereString.Append(
                    " WHERE SUBSTRING([TblPatients].[PatientID], 0 , 7) >= '" + IDBegin + "' " +
                "AND SUBSTRING([TblPatients].[PatientID], 0 , 7) <= '" + IDEnd + "'");
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
                    " WHERE [TblRefs].[RegisterDate] >= @RefDateBegin AND " +
                    "[TblRefs].[RegisterDate] <= @RefDateEnd " +
                    "AND [TblRefService].[IsActive] = 1 ");
            }
            #endregion

            #region Set Categories And Groups Filter
            String SelectedID = String.Empty;
            if (cBoxServiceCat.Checked)
            {
                foreach (DataGridViewRow Row in dgvServiceCat.Rows)
                {
                    if (Row.Cells[ColCatSelection.Name].Value != null &&
                        Convert.ToBoolean(Row.Cells[ColCatSelection.Name].Value))
                        SelectedID += ((SP_SelectCategoriesResult)Row.DataBoundItem).ID + " , ";
                }
                // اگر موردی انتخاب شده باشد
                if (!String.IsNullOrEmpty(SelectedID))
                {
                    // حذف آخرین ویرگول از لیست
                    SelectedID = SelectedID.Substring(0, SelectedID.Length - 3);
                    ReportSelectWhereString.Append(" AND [TblServices].[CategoryIX] IN (" + SelectedID + ")");
                }
            }
            if (cBoxServiceGroups.Checked)
            {
                SelectedID = String.Empty;
                foreach (DataGridViewRow Row in dgvServiceGroups.Rows)
                {
                    if (Row.Cells[ColGroupSelection.Name].Value != null &&
                        Convert.ToBoolean(Row.Cells[ColGroupSelection.Name].Value))
                        SelectedID += ((SP_SelectGroupsResult)Row.DataBoundItem).ID + " , ";
                }
                // اگر موردی انتخاب شده باشد
                if (!String.IsNullOrEmpty(SelectedID))
                {
                    ReportSelectString.Append("INNER JOIN [ImagingSystem].[Services].[ServiceInGroups] AS [TblGroups] " +
                        "ON [TblServices].[ID] = [TblGroups].[ServiceIX]");
                    // حذف آخرین ویرگول از لیست
                    SelectedID = SelectedID.Substring(0, SelectedID.Length - 3);
                    ReportSelectWhereString.Append(" AND [TblGroups].[GroupIX] IN (" + SelectedID + ") ");
                }
            }
            #endregion

            #region Set Ins Filter
            SelectedID = String.Empty;
            foreach (DataGridViewRow Row in dgvInsFilter.Rows)
            {
                if (Row.Cells[ColInsSelection.Index].Value != null &&
                    Convert.ToBoolean(Row.Cells[ColInsSelection.Name].Value))
                    SelectedID += ((SP_SelectInsFullDataResult)Row.DataBoundItem).ID + " , ";
            }
            // اگر بیمه ای انتخاب شده باشد
            if (!String.IsNullOrEmpty(SelectedID))
            {
                // حذف آخرین ویرگول از لیست
                SelectedID = SelectedID.Substring(0, SelectedID.Length - 3);
                if (cBoxIns1.Checked) ReportSelectWhereString.
                    Append(" AND [TblRefs].[Ins1IX] IN (" + SelectedID + ")");
                else ReportSelectWhereString.Append(" AND [TblRefs].[Ins2IX] IN (" + SelectedID + ")");
            }
            #endregion

            #endregion

            #region Step 3 - Add ORDER BY
            if (!_CalcReportRowCount)
                ReportSelectWhereString.Append("ORDER BY [TblPatients].[PatientID] , [TblRefs].[RegisterDate] , [TblRefService].[ID]");
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