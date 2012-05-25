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
using Sepehr.DBLayerIMS.DataLayer;
#endregion

namespace Negar.Customers.Reports0003
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

        #region List<SP_SelectRefPhysiciansFullDataListResult> _RefPhysList
        private List<SP_SelectRefPhysiciansFullDataListResult> _RefPhysList;
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
            dgvPhysician.AutoGenerateColumns = false;
            dgvInsFilter.AutoGenerateColumns = false;
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

        #region cBoxServPhysician_CheckedChanged
        private void cBoxServPhysician_CheckedChanged(object sender, EventArgs e)
        {
            cBoxServPhysician.CheckedChanged -= cBoxServPhysician_CheckedChanged;
            cBoxRefPhysician.CheckedChanged -= cBoxServPhysician_CheckedChanged;
            if (((CheckBox)sender).Name.Equals(cBoxServPhysician.Name) && cBoxServPhysician.Checked)
            {
                cBoxRefPhysician.Checked = false;
                dgvPhysician.DataSource = Sepehr.DBLayerIMS.Referrals.RefServPerformers.
                    Where(Data => Data.ID != null && Data.IsActive == true && Data.IsPhysician == true).ToList();
            }
            else if (((CheckBox)sender).Name.Equals(cBoxRefPhysician.Name) && cBoxRefPhysician.Checked)
            {
                cBoxServPhysician.Checked = false;
                if (_RefPhysList == null)
                    try { _RefPhysList = Negar.DBLayerPMS.Manager.DBML.SP_SelectRefPhysiciansFullDataList().ToList(); }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage = "امكان خواندن اطلاعات گزارش از بانك وجود ندارد.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Sepehr", "Customers Report0003",
                            Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                        cBoxServPhysician.Checked = false; return;
                    }
                    #endregion
                dgvPhysician.DataSource = _RefPhysList;
            }
            else dgvPhysician.DataSource = null;
            cBoxServPhysician.CheckedChanged += cBoxServPhysician_CheckedChanged;
            cBoxRefPhysician.CheckedChanged += cBoxServPhysician_CheckedChanged;
        }
        #endregion

        #region cBoxIns1_CheckedChanged
        private void cBoxIns1_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxIns1.Checked)
            {
                cBoxJustIns.Checked = false;
                dgvInsFilter.DataSource = Sepehr.DBLayerIMS.Insurance.InsFullList.
                    Where(Data => Data.IsActive == true && Data.ID != null).ToList();
            }
            else dgvInsFilter.DataSource = null;
        }
        #endregion

        #region cBoxJustIns_CheckedChanged
        private void cBoxJustIns_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxJustIns.Checked) cBoxIns1.Checked = false;
        }
        #endregion

        #region btnReport_Click
        private void btnReport_Click(object sender, EventArgs e)
        {
            dgvPhysician.EndEdit();
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
                const String ErrorMessage =
                    "امكان خواندن اطلاعات گزارش از بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Customers Report0003",
                    Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                BGWorker.CancelAsync(); return;
            }
            finally { _ReportSqlCommand.Connection.Close(); }
            #endregion

            #region Replace PersianDateTime With Original Data
            _ReportDataTable.Columns["RegisterDateFa"].ReadOnly = false;
            _ReportDataTable.Columns["Ins1PhysPart"].ReadOnly = false;
            _ReportDataTable.Columns["Ins1PhysPart"].DataType = typeof(Int32);
            _ReportDataTable.Columns["TotalIncome"].ReadOnly = false;
            _ReportDataTable.Columns["TaxValue"].ReadOnly = false;
            _ReportDataTable.Columns["TempTaxValue"].ReadOnly = false;
            _ReportDataTable.Columns["UniversityValue"].ReadOnly = false;
            _ReportDataTable.Columns["TempUniversityValue"].ReadOnly = false;
            _ReportDataTable.Columns["TotalPhysValue"].ReadOnly = false;
            _ReportDataTable.Columns["PhysPart"].ReadOnly = false;
            _ReportDataTable.Columns["TempTotalIncome"].ReadOnly = false;
            _ReportDataTable.Columns["TempPhysPart"].ReadOnly = false;
            Decimal TempTotalIncome = 0;
            Decimal InsPhysPartTotal = 0;
            for (Int32 i = 0; i < _ReportDataTable.Rows.Count; i++)
            {
                PersianDate PD = Convert.ToDateTime(_ReportDataTable.Rows[i]["RegisterDate"]).ToPersianDate();
                _ReportDataTable.Rows[i]["RegisterDateFa"] = PD.Year + "/" + PD.Month + "/" + PD.Day;
                InsPhysPartTotal += Convert.ToDecimal(_ReportDataTable.Rows[i]["Ins1Part"]);
                _ReportDataTable.Rows[i]["TotalIncome"] = Convert.ToInt32(_ReportDataTable.Rows[i]["Ins1Part"]) +
                        Convert.ToDecimal(_ReportDataTable.Rows[i]["PatientPart"]);
                Object TotalIncome = _ReportDataTable.Rows[i]["TotalIncome"];
                if (TotalIncome != null && TotalIncome != DBNull.Value)
                {
                    _ReportDataTable.Rows[i]["TaxValue"] = Convert.ToDecimal(TotalIncome) * txtTax.Value / 100;
                    _ReportDataTable.Rows[i]["UniversityValue"] = Convert.ToDecimal(TotalIncome) * txtUniversity.Value / 100;
                    _ReportDataTable.Rows[i]["TotalPhysValue"] = Convert.ToDecimal(TotalIncome) -
                        Convert.ToDecimal(_ReportDataTable.Rows[i]["TaxValue"]) -
                        Convert.ToDecimal(_ReportDataTable.Rows[i]["UniversityValue"]);
                    _ReportDataTable.Rows[i]["PhysPart"] = Convert.ToDecimal(_ReportDataTable.Rows[i]["TotalPhysValue"]) *
                        txtPhysician.Value / 100;
                }
                else
                {
                    _ReportDataTable.Rows[i]["TaxValue"] = 0;
                    _ReportDataTable.Rows[i]["UniversityValue"] = 0;
                    _ReportDataTable.Rows[i]["TotalPhysValue"] = 0;
                    _ReportDataTable.Rows[i]["PhysPart"] = 0;
                }
                TempTotalIncome += Convert.ToDecimal(_ReportDataTable.Rows[i]["TotalIncome"]);
            }
            if (_ReportDataTable.Rows.Count > 0)
            {
                _ReportDataTable.Rows[0]["TempTaxValue"] = TempTotalIncome * txtTax.Value / 100;
                _ReportDataTable.Rows[0]["TempUniversityValue"] = TempTotalIncome * txtUniversity.Value / 100;
                _ReportDataTable.Rows[0]["TempTotalIncome"] = TempTotalIncome -
                    Convert.ToDecimal(_ReportDataTable.Rows[0]["TempTaxValue"]) -
                    Convert.ToDecimal(_ReportDataTable.Rows[0]["TempUniversityValue"]);
                _ReportDataTable.Rows[0]["TempPhysPart"] =
                    Convert.ToDecimal(_ReportDataTable.Rows[0]["TempTotalIncome"]) * txtPhysician.Value / 100;
                // RTotalns1PhysPart
                Decimal Val1 = InsPhysPartTotal * txtTax.Value / 100;
                Decimal Val2 = InsPhysPartTotal * txtUniversity.Value / 100;
                Decimal Val3 = InsPhysPartTotal - Val1 - Val2;
                _ReportDataTable.Rows[0]["Ins1PhysPart"] = Val3 * txtPhysician.Value / 100;
            }
            #endregion
        }
        #endregion

        #region BGWorker_RunWorkerCompleted
        private void BGWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            #region Make Report
            PersianDate DateVal1 = new DateTime(
                FromDateRef.SelectedDateTime.Value.Year, FromDateRef.SelectedDateTime.Value.Month,
                FromDateRef.SelectedDateTime.Value.Day, FromTimeRef.Value.Hour,
                FromTimeRef.Value.Minute, FromTimeRef.Value.Second).ToPersianDate();
            PersianDate DateVal2 = new DateTime(
                ToDateRef.SelectedDateTime.Value.Year, ToDateRef.SelectedDateTime.Value.Month,
                ToDateRef.SelectedDateTime.Value.Day, ToTimeRef.Value.Hour,
                ToTimeRef.Value.Minute, ToTimeRef.Value.Second).ToPersianDate();
            if (cBoxHideUniversityPercent.Checked)
            {
                Report2 MyReport = new Report2();
                ((TextObject)MyReport.Section2.ReportObjects["txtTitle"]).Text = txtHeader1.Text.Trim();
                ((TextObject)MyReport.Section2.ReportObjects["txtBeginDate"]).Text =
                    DateVal1.Year + "/" + DateVal1.Month + "/" + DateVal1.Day + " - " +
                    DateVal1.Hour + ":" + DateVal1.Minute + ":" + DateVal1.Second;
                ((TextObject)MyReport.Section2.ReportObjects["txtEndDate"]).Text =
                    DateVal2.Year + "/" + DateVal2.Month + "/" + DateVal2.Day + " - " +
                    DateVal2.Hour + ":" + DateVal2.Minute + ":" + DateVal2.Second;
                ((TextObject)MyReport.Section5.ReportObjects["txtPrintDate"]).Text =
                    DateTime.Now.ToPersianDate().ToWritten() + " - " +
                    DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
                ((TextObject)MyReport.Section4.ReportObjects["Total2"]).Text += "(" + txtTax.Value + "%):";
                ((TextObject)MyReport.Section4.ReportObjects["Total5"]).Text += txtPhysician.Value + "% :";
                ((TextObject)MyReport.Section4.ReportObjects["Total9"]).Text += txtPhysician.Value + "% :";
                ((TextObject)MyReport.Section4.ReportObjects["Total11"]).Text += txtPhysician.Value + "% :";
                new frmPublicReportPreview(_ReportDataTable, MyReport);
            }
            else
            {
                Report1 MyReport = new Report1();
                ((TextObject)MyReport.Section2.ReportObjects["txtTitle"]).Text = txtHeader1.Text.Trim();
                ((TextObject)MyReport.Section2.ReportObjects["txtBeginDate"]).Text =
                    DateVal1.Year + "/" + DateVal1.Month + "/" + DateVal1.Day + " - " +
                    DateVal1.Hour + ":" + DateVal1.Minute + ":" + DateVal1.Second;
                ((TextObject)MyReport.Section2.ReportObjects["txtEndDate"]).Text =
                    DateVal2.Year + "/" + DateVal2.Month + "/" + DateVal2.Day + " - " +
                    DateVal2.Hour + ":" + DateVal2.Minute + ":" + DateVal2.Second;
                ((TextObject)MyReport.Section5.ReportObjects["txtPrintDate"]).Text =
                    DateTime.Now.ToPersianDate().ToWritten() + " - " +
                    DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
                ((TextObject)MyReport.Section4.ReportObjects["Total2"]).Text += "(" + txtTax.Value + "%):";
                ((TextObject)MyReport.Section4.ReportObjects["Total3"]).Text += "(" + txtUniversity.Value + "%):";
                ((TextObject)MyReport.Section4.ReportObjects["Total5"]).Text += txtPhysician.Value + "% :";
                ((TextObject)MyReport.Section4.ReportObjects["Total9"]).Text += txtPhysician.Value + "% :";
                ((TextObject)MyReport.Section4.ReportObjects["Total11"]).Text += txtPhysician.Value + "% :";
                new frmPublicReportPreview(_ReportDataTable, MyReport);
            }
            #endregion
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

            #region Step 1 - SELECT Columns & INNER JOINs
            StringBuilder ReportSelectString = new StringBuilder();
            ReportSelectString.Append("SELECT [TblPatients].[PatientID], " +
                "ISNULL([TblPatients].[FirstName] + ' ' , '') + [TblPatients].[LastName] AS [FullName], " +
                "[TblRefs].[ID] AS [RefID] , " +
                "[TblRefs].[RegisterDate], " +
                "'1380/10/01 - 12:20:50' AS [RegisterDateFa], " +
                // =========================================
                // دریافت غیر نقدی مراجعه
                "ISNULL((SELECT SUM([MyTbl1].[Value]) FROM [ImagingSystem].[Accounting].[RefTransaction] AS [MyTbl1]  " +
                "LEFT OUTER JOIN [ImagingSystem].[Accounting].[RefTransactionAdditionalData] AS [MyTbl2] " +
                "ON [MyTbl1].[ID] = [MyTbl2].[RefTransactionIX] " +
                "WHERE [MyTbl1].[ReferralIX] = [TblRefs].[ID] AND [MyTbl1].[Value] > 0  " +
                "AND [MyTbl2].[RefTransactionIX] IS NOT NULL) , 0) AS [CheckRecieve] , " +
                // =========================================
                // سهم پزشك از دریافت های غیر نقدی همراه با محاسبه مالیات و سهم دانشگاه
                "ISNULL((SELECT SUM([MyTbl1].[Value]) FROM [ImagingSystem].[Accounting].[RefTransaction] AS [MyTbl1]  " +
                "LEFT OUTER JOIN [ImagingSystem].[Accounting].[RefTransactionAdditionalData] AS [MyTbl2] " +
                "ON [MyTbl1].[ID] = [MyTbl2].[RefTransactionIX] " +
                "WHERE [MyTbl1].[ReferralIX] = [TblRefs].[ID] AND [MyTbl1].[Value] > 0  " +
                "AND [MyTbl2].[RefTransactionIX] IS NOT NULL) * " + (100 - txtTax.Value) + " / 100 * " +
                (100 - txtUniversity.Value) + " / 100 * " + txtPhysician.Value + " / 100 , 0) AS [PhysCheckRecieve] , " +
                // =========================================
                "[ImagingSystem].[Accounting].[FK_CalcSumDiscount] ([TblRefs].[ID]) AS [TotalDiscounts] , " + // مجموع تخفیف ها
                "[TblServices].[Name] AS [ServiceName], "); // نام خدمت
            // =========================================
            ReportSelectString.Append("ISNULL([TblRefService].[Ins1PartPrice] , 0) AS [Ins1Part] ,"); // سهم بیمه
            ReportSelectString.Append("0 AS [Ins1PhysPart] ,"); // سهم پزشك از سهم بیمه
            // =========================================
            // سهم بیمار: "پرداختنی بیمار" یا "قیمت دولتی" برای مراجعات آزاد
            if (!cBoxCalcByPatientPayablePrice.Checked)
                ReportSelectString.Append(
                    "(CASE WHEN [TblRefService].[Ins1PartPrice] IS NULL THEN ISNULL([TblServices].[PriceGov] , 0) " +
                    "ELSE [TblRefService].[Ins1Price] - [TblRefService].[Ins1PartPrice] END) " +
                    "* [TblRefService].[Quantity] AS [PatientPart] , ");
            else ReportSelectString.Append(
                "ISNULL([TblRefService].[PatientPayablePrice] , 0) * [TblRefService].[Quantity] AS [PatientPart] , ");
            // =========================================
            ReportSelectString.Append("10000000 AS [TotalIncome] , " + // كل درآمد خدمت: سهم بیمه + سهم بیمار 
            "0 AS [TempTotalIncome] , " + // كل درآمد موقت
            "10000000 AS [TaxValue] , " + // كسر مالیات
            "0 AS [TempTaxValue] , " + // كسر مالیات موقت
            "10000000 AS [UniversityValue] , " + // كسر دانشگاه
            "0 AS [TempUniversityValue] , " + // كسر دانشگاه موقت
            "10000000 AS [TotalPhysValue] , " + // مبنای نهایی
            "10000000 AS [PhysPart] , " + // سهم پزشك
            "0 AS [TempPhysPart] " + // سهم موقت پزشك
                // =========================================
            "FROM [PatientsSystem].[Patients].[List] AS [TblPatients] " +
            "INNER JOIN [ImagingSystem].[Referrals].[List] AS [TblRefs]  " +
            "ON [TblPatients].[ID] = [TblRefs].[PatientIX] " +
            "INNER JOIN [ImagingSystem].[Referrals].[RefServices] AS [TblRefService] " +
            "ON [TblRefService].[ReferralIX] = [TblRefs].[ID] " +
            "INNER JOIN [ImagingSystem].[Services].[List] AS [TblServices] " +
            "ON [TblRefService].[ServiceIX] = [TblServices].[ID] " +
            "LEFT OUTER JOIN [ImagingSystem].[Services].[ServiceInGroups] AS [TblGroups] " +
            "ON [TblServices].[ID] = [TblGroups].[ServiceIX] ");
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
                " WHERE [TblRefService].[IsActive] = 1 AND " + 
                "[TblRefs].[RegisterDate] >= @RefDateBegin AND [TblRefs].[RegisterDate] <= @RefDateEnd ");
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
                        SelectedID += ((Sepehr.DBLayerIMS.DataLayer.SP_SelectCategoriesResult)
                            Row.DataBoundItem).ID.Value + " , ";
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
                    ReportSelectWhereString.Append(" AND [TblRefService].ServiceIX IN (" + SelectedID + ")");
                }
            }
            #endregion

            #region Set Physician Filters
            // پزشك خدمت
            if (cBoxServPhysician.Checked)
            {
                String SelectedID = String.Empty;
                foreach (DataGridViewRow Row in dgvPhysician.Rows)
                {
                    if (Row.Cells[ColPhysSelection.Index].Value != null &&
                        Convert.ToBoolean(Row.Cells[ColPhysSelection.Name].Value))
                        SelectedID += ((SP_SelectPerformersResult)Row.DataBoundItem).ID + " , ";
                }
                if (!String.IsNullOrEmpty(SelectedID))
                {
                    // حذف آخرین ویرگول از لیست
                    SelectedID = SelectedID.Substring(0, SelectedID.Length - 3);
                    ReportSelectWhereString.Append(" AND [TblRefService].[PhysicianIX] IN (" + SelectedID + ") ");
                }
            }
            // پزشك درخواست كننده مراجعه
            else if (cBoxRefPhysician.Checked)
            {
                String SelectedID = String.Empty;
                foreach (DataGridViewRow Row in dgvPhysician.Rows)
                {
                    if (Row.Cells[ColPhysSelection.Index].Value != null &&
                        Convert.ToBoolean(Row.Cells[ColPhysSelection.Name].Value))
                        SelectedID += ((SP_SelectRefPhysiciansFullDataListResult)Row.DataBoundItem).ID + " , ";
                }
                // اگر بیمه ای انتخاب نشده باشد
                if (!String.IsNullOrEmpty(SelectedID))
                {
                    // حذف آخرین ویرگول از لیست
                    SelectedID = SelectedID.Substring(0, SelectedID.Length - 3);
                    ReportSelectWhereString.Append("AND [TblRefs].[ReferPhysicianIX] IN (" + SelectedID + ") ");
                }
            }
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
                if (String.IsNullOrEmpty(SelectedID))
                {
                    if (dgvInsFilter.Rows[0].Cells[ColInsSelection.Index].Value != null &&
                        Convert.ToBoolean(dgvInsFilter.Rows[0].Cells[ColInsSelection.Name].Value))
                        ReportSelectWhereString.Append(" AND [TblRefs].[Ins1IX] IS NULL");
                }
                else
                {
                    // حذف آخرین ویرگول از لیست
                    SelectedID = SelectedID.Substring(0, SelectedID.Length - 3);
                    ReportSelectWhereString.Append(" AND (([TblRefs].[Ins1IX] IN (" + SelectedID + ")");
                    if (Convert.ToBoolean(dgvInsFilter.Rows[0].Cells[ColInsSelection.Name].Value))
                        ReportSelectWhereString.Append(" AND [TblRefService].[IsIns1Cover] = 1) OR [TblRefs].[Ins1IX] IS NULL)");
                    else ReportSelectWhereString.Append(" AND [TblRefService].[IsIns1Cover] = 1))");
                }
            }
            else if (cBoxJustIns.Checked)
                ReportSelectWhereString.Append(" AND [TblRefs].[Ins1IX] IS NOT NULL AND [TblRefService].[IsIns1Cover] = 1");
            #endregion

            #endregion

            #region Step 3 - Add ORDER BY
            ReportSelectWhereString.Append(" ORDER BY [TblRefs].[RegisterDate] , [TblRefService].[ID];");
            #endregion

            _ReportSqlCommand.CommandText = ReportSelectString.Append(ReportSelectWhereString).ToString();
            return true;
        }
        #endregion

        #endregion

    }
}