#region using
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negar;
using Negar.PersianCalendar.Utilities;
using CrystalDecisions.CrystalReports.Engine;
using Sepehr.DBLayerIMS.DataLayer;
#endregion

namespace Negar.Customers.Reports0002
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
        }
        #endregion

        #region cBoxIns1_CheckedChanged
        private void cBoxIns1_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxIns1.Checked)
            {
                cBoxBaseIns.Checked = false;
                dgvInsFilter.DataSource = Sepehr.DBLayerIMS.Insurance.InsFullList.
                    Where(Data => Data.IsActive == true && Data.ID != null).ToList();
                btnSelectAllIns.Visible = true;
            }
            else
            {
                dgvInsFilter.DataSource = null;
                btnSelectAllIns.Visible = false;
            }
        }
        #endregion

        #region cBoxBaseIns_CheckedChanged
        private void cBoxBaseIns_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxBaseIns.Checked) cBoxIns1.Checked = false;
        }
        #endregion

        #region btnSelectAllIns_Click
        private void btnSelectAllIns_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvInsFilter.Rows) row.Cells[ColInsSelection.Index].Value = true;
        }
        #endregion

        #region cBoxServiceCat_CheckedChanged
        private void cBoxServiceCat_CheckedChanged(object sender, EventArgs e)
        {
            cBoxService.CheckedChanged -= cBoxServiceCat_CheckedChanged;
            cBoxServiceCat.CheckedChanged -= cBoxServiceCat_CheckedChanged;
            if (((CheckBox)sender).Name.Equals(cBoxServiceCat.Name) && cBoxServiceCat.Checked)
            {
                cBoxService.Checked = false;
                dgvServiceCat.DataSource = Sepehr.DBLayerIMS.Services.ServCategoriesList.Where(Data => Data.ID != null).ToList();
            }
            else if (((CheckBox)sender).Name.Equals(cBoxService.Name) && cBoxService.Checked)
            {
                cBoxServiceCat.Checked = false;
                dgvServiceCat.DataSource = Sepehr.DBLayerIMS.Services.ServicesList.Where(Data => Data.IsActive).ToList();
            }
            else dgvServiceCat.DataSource = null;
            cBoxService.CheckedChanged += cBoxServiceCat_CheckedChanged;
            cBoxServiceCat.CheckedChanged += cBoxServiceCat_CheckedChanged;
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
            ProgressBar.Style = ProgressBarStyle.Marquee;
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
                const String ErrorMessage = "امكان خواندن اطلاعات گزارش از بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Customers Report002",
                    Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error); BGWorker.CancelAsync(); return;
            }
            finally { _ReportSqlCommand.Connection.Close(); }
            #endregion

            #region Replace PersianDateTime With Original Data
            _ReportDataTable.Columns["RegisterDateFa"].ReadOnly = false;
            for (Int32 i = 0; i < _ReportDataTable.Rows.Count; i++)
            {
                PersianDate PD = Convert.ToDateTime(_ReportDataTable.Rows[i]["RegisterDate"]).ToPersianDate();
                _ReportDataTable.Rows[i]["RegisterDateFa"] = PD.Year + "/" + PD.Month + "/" + PD.Day;
            }
            #endregion
        }
        #endregion

        #region BGWorker_RunWorkerCompleted
        private void BGWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            #region Make Report
            Report MyReport = new Report();
            ((TextObject)MyReport.Section2.ReportObjects["txtInsName"]).Text = txtHeader1.Text.Trim();
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
            ProgressBar.Text = "در انتظار ایجاد گزارش";
            ProgressBar.Style = ProgressBarStyle.Blocks;
            btnReport.Enabled = true;
            BringToFront();
            Focus();
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
            _ReportSqlCommand.Connection = MyConnection;
            #endregion

            #region Check For Special Service Selection
            Boolean Is613Selected;
            if (cBoxService.Checked)
            {
                Is613Selected = false;
                foreach (DataGridViewRow row in dgvServiceCat.Rows)
                    if (row.Cells[ColInsSelection.Index].Value != null && Convert.ToBoolean(row.Cells[ColServSelection.Index].Value) &&
                        ((SP_SelectServicesListResult)row.DataBoundItem).ID == 613) Is613Selected = true;
            }
            else if (cBoxServiceCat.Checked)
            {
                Is613Selected = false;
                foreach (DataGridViewRow row in dgvServiceCat.Rows)
                    if (row.Cells[ColInsSelection.Index].Value != null && Convert.ToBoolean(row.Cells[ColServSelection.Index].Value) &&
                        ((SP_SelectCategoriesResult)row.DataBoundItem).ID == 17) Is613Selected = true;
            }
            else Is613Selected = true;
            #endregion

            #region Step 1 - SELECT Columns & INNER JOINs
            StringBuilder ReportSelectString = new StringBuilder();
            ReportSelectString.Append("SELECT [TblPatList].[PatientID] , " +
                "ISNULL([TblPatList].[FirstName] + ' ' , '') + [TblPatList].[LastName] AS [FullName], " +
                "[TblRefList].[RegisterDate] , " +
                "'1380/01/01' AS [RegisterDateFa] , " +
                "ISNULL((SELECT TOP 1 [TblIns].[Name] FROM [PatientsSystem].[Clinic].[Insurances] AS [TblIns] " +
                "WHERE [TblIns].[ID] = [TblRefList].[Ins1IX]) , '(بدون بیمه)') AS [InsName] , " +
                "(SELECT TOP 1 [TblServices].[Name] FROM [ImagingSystem].[Services].[List] AS [TblServices] " +
                "WHERE [TblServices].[ID] = [TblRefService].[ServiceIX]) AS [ServiceName], " +
                "[TblRefService].[Quantity] AS [ServiceQty], " +
                "[TblRefService].[Ins1Price] * [TblRefService].[Quantity] AS [Ins1Price], " +
                "[TblRefService].[Ins1PartPrice] * [TblRefService].[Quantity] AS [Ins1PartPrice], " +
                "([TblRefService].[Ins1Price] - [TblRefService].[Ins1PartPrice]) * [TblRefService].[Quantity] AS [Ins1PatientPart] " +
                "FROM [PatientsSystem].[Patients].[List] AS [TblPatList] " +
                "INNER JOIN [ImagingSystem].[Referrals].[List] AS [TblRefList] " +
                "ON [TblPatList].[ID] = [TblRefList].[PatientIX] " +
                "INNER JOIN [ImagingSystem].[Referrals].[RefServices] AS [TblRefService] " +
                "ON [TblRefService].[ReferralIX] = [TblRefList].[ID] " +
                "WHERE [TblRefService].[IsActive] = 1 AND " +
                "[TblRefList].[Ins1IX] IS NOT NULL AND [TblRefService].[IsIns1Cover] = 1 " +
                "AND [TblRefService].[ServiceIX] <> 613");
            #endregion

            #region Step 2 - Add WHERE SELECT
            StringBuilder ReportSelectWhereString = new StringBuilder();

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
            ReportSelectWhereString.Append(
                " AND [TblRefList].[RegisterDate] >= @RefDateBegin AND [TblRefList].[RegisterDate] <= @RefDateEnd ");
            #endregion

            #region Set Ins Filter
            if (cBoxIns1.Checked)
            {
                String SelectedID = String.Empty;
                foreach (DataGridViewRow Row in dgvInsFilter.Rows)
                {
                    if (Row.Cells[ColInsSelection.Index].Value != null &&
                        Convert.ToBoolean(Row.Cells[ColInsSelection.Name].Value))
                        SelectedID += ((SP_SelectInsFullDataResult)Row.DataBoundItem).ID + " , ";
                }
                // اگر بیمه ای انتخاب نشده باشد
                if (!String.IsNullOrEmpty(SelectedID))
                {
                    // حذف آخرین ویرگول از لیست
                    SelectedID = SelectedID.Substring(0, SelectedID.Length - 3);
                    ReportSelectWhereString.Append("AND [TblRefList].[Ins1IX] IN (" + SelectedID + ") ");
                }
            }
            // بیمه های پایه
            else if (cBoxBaseIns.Checked) ReportSelectWhereString.Append(
                "AND [TblRefList].[Ins1IX] IN (1 , 2 , 3 , 4 , 5 , 6 , 9 , 10 , 13 , 40) ");
            #endregion

            #region Set Service Filters
            if (cBoxServiceCat.Checked)
            {
                // افزودن فیلتر طبقه بندی خدمت
                String SelectedID = String.Empty;
                foreach (DataGridViewRow Row in dgvServiceCat.Rows)
                {
                    if (Row.Cells[ColServSelection.Index].Value != null &&
                        Convert.ToBoolean(Row.Cells[ColServSelection.Index].Value))
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
            else if (cBoxService.Checked)
            {
                // افزودن فیلتر خدمت
                String SelectedID = String.Empty;
                foreach (DataGridViewRow Row in dgvServiceCat.Rows)
                {
                    if (Row.Cells[ColServSelection.Index].Value != null &&
                        Convert.ToBoolean(Row.Cells[ColServSelection.Index].Value))
                        SelectedID += ((SP_SelectServicesListResult)Row.DataBoundItem).ID + " , ";
                }
                if (!String.IsNullOrEmpty(SelectedID))
                {
                    // حذف آخرین ویرگول از لیست
                    SelectedID = SelectedID.Substring(0, SelectedID.Length - 3);
                    ReportSelectWhereString.Append(" AND [TblRefService].[ServiceIX] IN (" + SelectedID + ")");
                }
            }
            #endregion

            #endregion

            _ReportSqlCommand.CommandText = ReportSelectString.Append(ReportSelectWhereString).ToString();

            #region Step 3 - 613 Service ID Options
            if (Is613Selected)
            {
                StringBuilder ReportSelectString613 = new StringBuilder();
                ReportSelectString613.Append(" UNION SELECT TOP 50 PERCENT [TblPatList].[PatientID] , " +
                "ISNULL([TblPatList].[FirstName] + ' ' , '') + [TblPatList].[LastName] AS [FullName], " +
                "[TblRefList].[RegisterDate] , " +
                "'1380/01/01' AS [RegisterDateFa] , " +
                "ISNULL((SELECT TOP 1 [TblIns].[Name] FROM [PatientsSystem].[Clinic].[Insurances] AS [TblIns] " +
                "WHERE [TblIns].[ID] = [TblRefList].[Ins1IX]) , '(بدون بیمه)') AS [InsName] , " +
                "(SELECT TOP 1 [TblServices].[Name] FROM [ImagingSystem].[Services].[List] AS [TblServices] " +
                "WHERE [TblServices].[ID] = [TblRefService].[ServiceIX]) AS [ServiceName], " +
                "[TblRefService].[Quantity] AS [ServiceQty], " +
                "[TblRefService].[Ins1Price] * [TblRefService].[Quantity] AS [Ins1Price], " +
                "[TblRefService].[Ins1PartPrice] * [TblRefService].[Quantity] AS [Ins1PartPrice], " +
                "[TblRefService].[PatientPayablePrice] * [TblRefService].[Quantity] AS [Ins1PatientPart] " +
                "FROM [PatientsSystem].[Patients].[List] AS [TblPatList] " +
                "INNER JOIN [ImagingSystem].[Referrals].[List] AS [TblRefList] " +
                "ON [TblPatList].[ID] = [TblRefList].[PatientIX] " +
                "INNER JOIN [ImagingSystem].[Referrals].[RefServices] AS [TblRefService] " +
                "ON [TblRefService].[ReferralIX] = [TblRefList].[ID] " +
                "WHERE [TblRefService].[IsActive] = 1 AND [TblRefService].[ServiceIX] = 613");
                _ReportSqlCommand.CommandText += ReportSelectString613.Append(ReportSelectWhereString).ToString();
            }
            #endregion

            #region Step 4 - Add ORDER BY
            _ReportSqlCommand.CommandText += " ORDER BY [TblRefList].[RegisterDate] , [TblPatList].[PatientID] ASC;";
            #endregion

            return true;
        }
        #endregion

        #endregion

    }
}