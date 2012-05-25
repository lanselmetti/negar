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

namespace Sepehr.Forms.Reports.General.Report04
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
            dgvInsFilter.AutoGenerateColumns = false;
            dgvServiceCat.AutoGenerateColumns = false;
            if (!FillDataSource()) { Close(); return; }
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
            FromDatePrescription.SelectedDateTime = GregorianMonthBeginDate;
            ToDatePrescription.SelectedDateTime = DateTime.Now;
            #endregion
            if (!ReadTopics()) { Close(); return; }
            SetControlsToolTipTexts();
        }
        #endregion

        #region cBoxRefDateFilter_CheckedChanged
        private void cBoxRefDateFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxRefDateFilter.Checked) PanelRefDateTimeFilter.Enabled = true;
            else PanelRefDateTimeFilter.Enabled = false;
            if (!cBoxPrescribeDateFilter.Checked && !cBoxRefDateFilter.Checked)
                cBoxPrescribeDateFilter.Checked = true;
        }
        #endregion

        #region cBoxPrescribeDateFilter_CheckedChanged
        private void cBoxPrescribeDateFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxPrescribeDateFilter.Checked) PanelPrescribeDate.Enabled = true;
            else PanelPrescribeDate.Enabled = false;
            if (!cBoxPrescribeDateFilter.Checked && !cBoxRefDateFilter.Checked)
                cBoxRefDateFilter.Checked = true;
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

        #region cBoxServiceCat_CheckedChanged
        private void cBoxServiceCat_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxServiceCat.Checked) dgvServiceCat.DataSource =
                DBLayerIMS.Services.ServCategoriesList.Where(Data => Data.ID != null).ToList();
            else dgvServiceCat.DataSource = null;
        }
        #endregion

        #region btnReport_Click
        private void btnReport_Click(object sender, EventArgs e)
        {
            if (sender.GetType().Equals(typeof(Boolean))) _CalcReportRowCount = true;
            else _CalcReportRowCount = false;
            dgvInsFilter.EndEdit();
            dgvServiceCat.EndEdit();
            btnReport.Focus();
            if (!SaveTopics() || !GenerateReportString()) return;
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
                // حذف شد
                //_ReportDataTable.Columns["PrescriptionDateFa"].ReadOnly = false;
                for (Int16 i = 0; i < _ReportDataTable.Rows.Count; i++)
                {
                    PersianDate PDate = Convert.ToDateTime(_ReportDataTable.Rows[i]["RegisterDate"]).ToPersianDate();
                    _ReportDataTable.Rows[i]["RegisterDateFa"] = PDate.Year + "/" + PDate.Month + "/" + PDate.Day;
                    // حذف شد
                    //if (_ReportDataTable.Rows[i]["PrescriptionDate"] == null ||
                    //    _ReportDataTable.Rows[i]["PrescriptionDate"] == DBNull.Value) PDate = null;
                    //else PDate = PersianDateConverter.ToPersianDate(Convert.ToDateTime(
                    //_ReportDataTable.Rows[i]["PrescriptionDate"]));
                    //if (PDate == null) _ReportDataTable.Rows[i]["PrescriptionDateFa"] = String.Empty;
                    //else _ReportDataTable.Rows[i]["PrescriptionDateFa"] = PDate.Year + "/" + PDate.Month + "/" + PDate.Day;
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
                if (cBoxIns1.Checked)
                {
                    Report4_1 MyReport = new Report4_1();
                    ((TextObject)MyReport.Section2.ReportObjects["txtHeader1"]).Text = txtHeader1.Text.Trim();
                    ((TextObject)MyReport.Section2.ReportObjects["txtHeader2"]).Text = txtHeader2.Text.Trim();
                    ((TextObject)MyReport.Section2.ReportObjects["txtHeader3"]).Text = txtHeader3.Text.Trim();
                    ((TextObject)MyReport.Section5.ReportObjects["txtPrintDate"]).Text =
                        DateTime.Now.ToPersianDate().ToWritten() + " - " +
                        DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
                    new frmPublicReportPreview(_ReportDataTable, MyReport);
                }
                else
                {
                    Report4_2 MyReport = new Report4_2();
                    ((TextObject)MyReport.Section2.ReportObjects["txtHeader1"]).Text = txtHeader1.Text.Trim();
                    ((TextObject)MyReport.Section2.ReportObjects["txtHeader2"]).Text = txtHeader2.Text.Trim();
                    ((TextObject)MyReport.Section2.ReportObjects["txtHeader3"]).Text = txtHeader3.Text.Trim();
                    ((TextObject)MyReport.Section5.ReportObjects["txtPrintDate"]).Text =
                        DateTime.Now.ToPersianDate().ToWritten() + " - " +
                        DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
                    new frmPublicReportPreview(_ReportDataTable, MyReport);
                }
                #endregion
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
            dgvInsFilter.DataSource = DBLayerIMS.Insurance.InsFullList.Where(Data => Data.IsIns1 == true && Data.ID != null).ToList();
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
            if (cBoxIns1.Checked) ReportSelectString.Append(
                "SELECT ISNULL([TblPatList].[FirstName] + ' ' , '') + [TblPatList].[LastName] AS [FullName],  " +
                "[TblRefList].[RegisterDate] , '1380/01/01 - 10:00:00' AS [RegisterDateFa] , " +
                "[TblRefList].[Ins1Num1] AS [InsNum] , " +
                "SUM([TblRefService].[Ins1Price] * [TblRefService].[Quantity]) AS [InsPrice], " +
                "SUM([TblRefService].[Ins1PartPrice] * [TblRefService].[Quantity]) AS [InsPart], " +
                "SUM(([TblRefService].[Ins1Price] - [TblRefService].[Ins1PartPrice]) * [TblRefService].[Quantity]) AS [InsPatPart] " +
                "FROM [PatientsSystem].[Patients].[List] AS [TblPatList] " +
                "INNER JOIN [ImagingSystem].[Referrals].[List] AS [TblRefList]  " +
                "ON [TblPatList].[ID] = [TblRefList].[PatientIX] " +
                "INNER JOIN [ImagingSystem].[Referrals].[RefServices] AS [TblRefService] " +
                "ON [TblRefService].[ReferralIX] = [TblRefList].[ID] " +
                "WHERE [TblRefService].[IsActive] = 1 AND [TblRefService].[IsIns1Cover] = 1 ");
            else ReportSelectString.Append(
                "SELECT [TblPatList].[PatientID], " +
                "ISNULL([TblPatList].[FirstName] + ' ' , '') +	[TblPatList].[LastName] AS [FullName],  " +
                "[TblRefList].[RegisterDate] , '1380/01/01 - 10:00:00' AS [RegisterDateFa] , " +
                "[TblRefList].[Ins2Num] AS [InsNum] , " +
                "SUM([TblRefService].[Ins2Price] * [TblRefService].[Quantity]) AS [Ins2Price], " +
                "SUM([TblRefService].[Ins1PartPrice] * [TblRefService].[Quantity]) AS [Ins1Part], " +
                "SUM([TblRefService].[Ins2PartPrice] * [TblRefService].[Quantity]) AS [Ins2Part] ," +
                "SUM([TblRefService].[PatientPayablePrice] * [TblRefService].[Quantity]) AS [InsPatPart] " +
                "FROM [PatientsSystem].[Patients].[List] AS [TblPatList] " +
                "INNER JOIN [ImagingSystem].[Referrals].[List] AS [TblRefList] " +
                "ON [TblPatList].[ID] = [TblRefList].[PatientIX] " +
                "INNER JOIN [ImagingSystem].[Referrals].[RefServices] AS [TblRefService] " +
                "ON [TblRefService].[ReferralIX] = [TblRefList].[ID] " +
                "WHERE [TblRefService].[IsActive] = 1 AND [TblRefService].[IsIns2Cover] = 1 ");
            #endregion

            #region Step 2 - Add WHERE SELECT
            StringBuilder ReportSelectWhereString = new StringBuilder();

            #region RefTime && PrescribeDate
            #region Set SqlParams
            SqlParameter Param1 = new SqlParameter("@PrescDateBegin", SqlDbType.DateTime);
            Param1.Value = new DateTime(FromDatePrescription.SelectedDateTime.Value.Year,
                FromDatePrescription.SelectedDateTime.Value.Month, FromDatePrescription.SelectedDateTime.Value.Day,
                0, 0, 0, 0);
            SqlParameter Param2 = new SqlParameter("@PrescDateEnd", SqlDbType.DateTime);
            Param2.Value = new DateTime(ToDatePrescription.SelectedDateTime.Value.Year,
                ToDatePrescription.SelectedDateTime.Value.Month, ToDatePrescription.SelectedDateTime.Value.Day, 23, 59, 59);
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

            if (cBoxPrescribeDateFilter.Checked && !cBoxRefDateFilter.Checked)
                ReportSelectWhereString.Append(
                    " AND [TblRefList].[PrescriptionDate] >= @PrescDateBegin AND " +
                    "[TblRefList].[PrescriptionDate] <= @PrescDateEnd ");
            else if (cBoxRefDateFilter.Checked && !cBoxPrescribeDateFilter.Checked)
                ReportSelectWhereString.Append(
                    " AND [TblRefList].[RegisterDate] >= @RefDateBegin AND [TblRefList].[RegisterDate] <= @RefDateEnd ");
            else ReportSelectWhereString.Append(
                " AND [TblRefList].[PrescriptionDate] >= @PrescDateBegin " +
                "AND [TblRefList].[PrescriptionDate] <= @PrescDateEnd " +
                " AND [TblRefList].[RegisterDate] >= @RefDateBegin AND " +
                "[TblRefList].[RegisterDate] <= @RefDateEnd ");
            #endregion

            #region Set Ins Filter
            String SelectedID = String.Empty;
            foreach (DataGridViewRow Row in dgvInsFilter.Rows)
            {
                if (Row.Cells[ColInsSelection.Index].Value != null &&
                    Convert.ToBoolean(Row.Cells[ColInsSelection.Name].Value))
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
            if (cBoxIns1.Checked) ReportSelectWhereString.Append(" AND [TblRefList].[Ins1IX] IN (" + SelectedID + ")");
            else ReportSelectWhereString.Append(" AND [TblRefList].[Ins2IX] IN (" + SelectedID + ")");
            #endregion

            #region Set Category Filter
            if (cBoxServiceCat.Checked)
            {
                // افزودن فیلتر طبقه بندی خدمت
                SelectedID = String.Empty;
                foreach (DataGridViewRow Row in dgvServiceCat.Rows)
                {
                    if (Row.Cells[ColCatSelection.Index].Value != null &&
                        Convert.ToBoolean(Row.Cells[ColCatSelection.Index].Value))
                        SelectedID += ((SP_SelectCategoriesResult)Row.DataBoundItem).ID.Value + " , ";
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
            #endregion

            #endregion

            #region Step 3 - Add GROUP BY & ORDER BY
            if (cBoxIns1.Checked)
                ReportSelectWhereString.Append(" GROUP BY [TblPatList].[PatientID] , [TblRefList].[RegisterDate] , " +
                "ISNULL([TblPatList].[FirstName] + ' ' , '') + [TblPatList].[LastName] , " +
                "[TblRefList].[Ins1Num1] ");
            else ReportSelectWhereString.Append(" GROUP BY [TblPatList].[PatientID] , [TblRefList].[RegisterDate] , " +
                "ISNULL([TblPatList].[FirstName] + ' ' , '') + [TblPatList].[LastName] , " +
                "[TblRefList].[Ins2Num] ");
            if (!_CalcReportRowCount)
                ReportSelectWhereString.Append(" ORDER BY [TblRefList].[RegisterDate] , [TblPatList].[PatientID] ASC;");
            #endregion

            _ReportSqlCommand.CommandText = ReportSelectString.Append(ReportSelectWhereString).ToString();
            if (_CalcReportRowCount)
                _ReportSqlCommand.CommandText = "SELECT COUNT (*) FROM (" + _ReportSqlCommand.CommandText + ") AS TBL";
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
            List<UsersSetting> Setting900 = DBLayerIMS.Settings.CurrentUserSettingsFullList.
                Where(Data => Data.SettingIX == 900).ToList();
            if (Setting900.Count != 0 && !String.IsNullOrEmpty(Setting900.First().Value)) txtHeader1.Text = Setting900.First().Value;
            List<UsersSetting> Setting901 = DBLayerIMS.Settings.CurrentUserSettingsFullList.
                Where(Data => Data.SettingIX == 901).ToList();
            if (Setting901.Count != 0 && !String.IsNullOrEmpty(Setting901.First().Value)) txtHeader2.Text = Setting901.First().Value;
            List<UsersSetting> Setting902 = DBLayerIMS.Settings.CurrentUserSettingsFullList.
                Where(Data => Data.SettingIX == 902).ToList();
            if (Setting902.Count != 0 && !String.IsNullOrEmpty(Setting902.First().Value)) txtHeader3.Text = Setting902.First().Value;
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
            if (!DBLayerIMS.Settings.InsertCurrentUserSetting(900, null, txtHeader1.Text.Normalize()) ||
                !DBLayerIMS.Settings.InsertCurrentUserSetting(901, null, txtHeader2.Text.Normalize()) ||
                !DBLayerIMS.Settings.InsertCurrentUserSetting(902, null, txtHeader3.Text.Normalize())) return false;
            return true;
        }
        #endregion

        #endregion

    }
}