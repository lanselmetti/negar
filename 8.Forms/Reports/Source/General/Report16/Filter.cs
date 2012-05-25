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

namespace Sepehr.Forms.Reports.General.Report16
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
            dgvServiceCat.AutoGenerateColumns = false;
            if (!FillDataSource()) { Close(); return; }
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
            dgvInsFilter.EndEdit();
            dgvServiceCat.EndEdit();
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
            _ReportDataTable.Columns["PrescriptionDateFa"].ReadOnly = false;
            _ReportDataTable.Columns["Ins1ValidationFa"].ReadOnly = false;
            for (Int16 i = 0; i < _ReportDataTable.Rows.Count; i++)
            {
                PersianDate PDate;
                if (_ReportDataTable.Rows[i]["PrescriptionDate"] == null ||
                    _ReportDataTable.Rows[i]["PrescriptionDate"] == DBNull.Value) PDate = null;
                else PDate = Convert.ToDateTime(_ReportDataTable.Rows[i]["PrescriptionDate"]).ToPersianDate();
                if (PDate == null) _ReportDataTable.Rows[i]["PrescriptionDateFa"] = String.Empty;
                else _ReportDataTable.Rows[i]["PrescriptionDateFa"] = PDate.Year + "/" + PDate.Month + "/" + PDate.Day;
                // =================================================
                if (_ReportDataTable.Rows[i]["Ins1Validation"] == null ||
                    _ReportDataTable.Rows[i]["Ins1Validation"] == DBNull.Value) PDate = null;
                else PDate = Convert.ToDateTime(_ReportDataTable.Rows[i]["Ins1Validation"]).ToPersianDate();
                if (PDate == null) _ReportDataTable.Rows[i]["Ins1ValidationFa"] = String.Empty;
                else _ReportDataTable.Rows[i]["Ins1ValidationFa"] = PDate.Year + "/" + PDate.Month + "/" + PDate.Day;
            }
            #endregion
        }
        #endregion

        #region BGWorker_RunWorkerCompleted
        private void BGWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            #region Make Report
            Report16 MyReport = new Report16();
            // ثبت نام بیمه در گزارش
            ((TextObject)MyReport.Section2.ReportObjects["txtInsName"]).Text = txtInsName.Text.Trim();
            if (cBoxPrescribeDateFilter.Checked)
            {
                ((TextObject)MyReport.Section2.ReportObjects["txtBeginDate"]).Text =
                    FromDatePrescription.SelectedDateTime.Value.ToPersianDate().Year + "/" +
                    FromDatePrescription.SelectedDateTime.Value.ToPersianDate().Month + "/" +
                    FromDatePrescription.SelectedDateTime.Value.ToPersianDate().Day;
                ((TextObject)MyReport.Section2.ReportObjects["txtEndDate"]).Text =
                    ToDatePrescription.SelectedDateTime.Value.ToPersianDate().Year + "/" +
                    ToDatePrescription.SelectedDateTime.Value.ToPersianDate().Month + "/" +
                    ToDatePrescription.SelectedDateTime.Value.ToPersianDate().Day;
            }
            else
            {
                ((TextObject)MyReport.Section2.ReportObjects["txtEndDate"]).Text = String.Empty;
                ((TextObject)MyReport.Section2.ReportObjects["txtBeginDate"]).Text = String.Empty;
                ((TextObject)MyReport.Section2.ReportObjects["txtPr1"]).Text = String.Empty;
                ((TextObject)MyReport.Section2.ReportObjects["txtPr2"]).Text = String.Empty;
            }
            if (cBoxRefDateFilter.Checked)
            {
                ((TextObject)MyReport.Section2.ReportObjects["txtRefDateBegin"]).Text =
                    FromDateRef.SelectedDateTime.Value.ToPersianDate().Year + "/" +
                    FromDateRef.SelectedDateTime.Value.ToPersianDate().Month + "/" +
                    FromDateRef.SelectedDateTime.Value.ToPersianDate().Day + " - " +
                    FromTimeRef.Value.ToPersianDate().Hour + ":" +
                    FromTimeRef.Value.ToPersianDate().Minute + ":" +
                    FromTimeRef.Value.ToPersianDate().Second;
                ((TextObject)MyReport.Section2.ReportObjects["txtRefDateEnd"]).Text =
                    ToDateRef.SelectedDateTime.Value.ToPersianDate().Year + "/" +
                    ToDateRef.SelectedDateTime.Value.ToPersianDate().Month + "/" +
                    ToDateRef.SelectedDateTime.Value.ToPersianDate().Day + " - " +
                    ToTimeRef.Value.ToPersianDate().Hour + ":" +
                    ToTimeRef.Value.ToPersianDate().Minute + ":" +
                    ToTimeRef.Value.ToPersianDate().Second;
            }
            else
            {
                ((TextObject)MyReport.Section2.ReportObjects["txtRefDateBegin"]).Text = String.Empty;
                ((TextObject)MyReport.Section2.ReportObjects["txtRefDateEnd"]).Text = String.Empty;
                ((TextObject)MyReport.Section2.ReportObjects["txtRefDate1"]).Text = String.Empty;
                ((TextObject)MyReport.Section2.ReportObjects["txtRefDate2"]).Text = String.Empty;
            }
            // تاریخ چاپ گزارش
            ((TextObject)MyReport.Section5.ReportObjects["txtPrintDate"]).Text =
                DateTime.Now.ToPersianDate().ToWritten() + " - " +
                DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
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
            ReportSelectString.Append("SELECT  " +
                "ISNULL([TblPatList].[FirstName] + ' ' , '') +	[TblPatList].[LastName] AS [FullName],  " +
                "[TblRefList].[ID] AS [RefID] , " +
                "[TblRefList].[Ins1Num1] , " +
                "[TblRefList].[PrescriptionDate] , " +
                "'1380/01/01 - 10:00:00' AS [PrescriptionDateFa] , " +
                "[TblRefList].[Ins1Validation] , " +
                "'1380/01/01 - 10:00:00' AS [Ins1ValidationFa] , " +
                "[TblRefList].[Ins1PageNum] , " +
                "(SELECT TOP 1 ISNULL([RefPhys].[FirstName] + ' ' , '') + [RefPhys].[LastName] +  " +
                "ISNULL(' - ' + [RefPhys].[MedicalID] , '')  " +
                "FROM [PatientsSystem].[Clinic].[RefPhysicians] AS [RefPhys]  " +
                "WHERE [RefPhys].[ID] = [TblRefList].[ReferPhysicianIX]) AS [RefPhysName], " +
                "[ImagingSystem].[Accounting].[FK_CalcSumIns1Price] ([TblRefList].[ID]) AS [TotInsPrice], " +
                "[ImagingSystem].[Accounting].[FK_CalcSumIns1PartPrice] ([TblRefList].[ID]) AS [TotInsPart], " +
                "[ImagingSystem].[Accounting].[FK_CalcSumIns1PatientPart] ([TblRefList].[ID]) AS [TotInsPatPart], " +
                "[TblRefService].[ID] AS [RefServID] , " +
                "(SELECT TOP 1 [TblServices].[Name] FROM [ImagingSystem].[Services].[List] AS [TblServices] " +
                "WHERE [TblServices].[ID] = [TblRefService].[ServiceIX]) AS [ServiceName], " +
                "[TblRefService].[Quantity] AS [ServiceQty], " +
                "[TblRefService].[Ins1Price] * [TblRefService].[Quantity] AS [Ins1Price], " +
                "[TblRefService].[Ins1PartPrice] * [TblRefService].[Quantity] AS [Ins1PartPrice], " +
                "([TblRefService].[Ins1Price] - [TblRefService].[Ins1PartPrice]) * [TblRefService].[Quantity] AS [Ins1PatientPart] " +
                "FROM [PatientsSystem].[Patients].[List] AS [TblPatList] " +
                "INNER JOIN [ImagingSystem].[Referrals].[List] AS [TblRefList]  " +
                "ON [TblPatList].[ID] = [TblRefList].[PatientIX] " +
                "INNER JOIN [ImagingSystem].[Referrals].[RefServices] AS [TblRefService] " +
                "ON [TblRefService].[ReferralIX] = [TblRefList].[ID] " +
                // شروط ثابت
                "WHERE [TblRefList].[Ins1IX] IS NOT NULL AND [TblRefService].[IsActive] = 1 AND [TblRefService].[IsIns1Cover] = 1 ");
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
                ToDatePrescription.SelectedDateTime.Value.Month, ToDatePrescription.SelectedDateTime.Value.Day,
                23, 59, 59);
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
            ReportSelectWhereString.Append(" AND [TblRefList].[Ins1IX] IN (" + SelectedID + ")");
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

            #region Step 3 - Add ORDER BY
            if (cBoxOrder1.Checked)
                ReportSelectWhereString.Append(" ORDER BY [TblRefList].[PrescriptionDate] ASC, [TblRefList].[RegisterDate] ASC;");
            else ReportSelectWhereString.Append(" ORDER BY [TblRefList].[RegisterDate] , [TblRefList].[PrescriptionDate] ASC;");
            #endregion

            _ReportSqlCommand.CommandText = ReportSelectString.Append(ReportSelectWhereString).ToString();
            return true;
        }
        #endregion

        #region Boolean ReadTopics()
        /// <summary>
        /// تابع خواندن عناوین ذخیره شده در بانك
        /// </summary>
        /// <returns>صحت انجام كار</returns>
        private Boolean ReadTopics()
        {
            List<UsersSetting> Setting906 = DBLayerIMS.Settings.CurrentUserSettingsFullList.
                Where(Data => Data.SettingIX == 906).ToList();
            if (Setting906.Count != 0 && !String.IsNullOrEmpty(Setting906.First().Value)) txtInsName.Text = Setting906.First().Value;
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
            if (!DBLayerIMS.Settings.InsertCurrentUserSetting(906, null, txtInsName.Text.Normalize())) return false;
            return true;
        }
        #endregion

        #endregion

    }
}