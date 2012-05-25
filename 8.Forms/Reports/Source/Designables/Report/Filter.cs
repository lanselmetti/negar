#region using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negar;
using Negar.DBLayerPMS.DataLayer;
using Negar.PersianCalendar.Utilities;
using DevComponents.DotNetBar;
using Sepehr.DBLayerIMS.DataLayer;
#endregion

namespace Sepehr.Forms.Reports.Designables.Report
{
    /// <summary>
    /// فرم فیلتر شروط گزارش های قابل طراحی
    /// </summary>
    internal partial class frmFilter : Form
    {

        #region Fields And Properties

        #region Int16 _CurrentReportID
        /// <summary>
        /// كلید گزارش جاری
        /// </summary>
        private Int16 _CurrentReportID;
        #endregion

        #region StringBuilder _SearchCommand
        /// <summary>
        /// نگهدارنده متن نهایی دستور جستجو
        /// </summary>
        private StringBuilder _SearchCommand;
        #endregion

        #region DataTable _SearchRefListResultDataTable
        /// <summary>
        /// نگهدارنده لیست مراجعات جستجو بر اساس فیلتر های انتخاب شده
        /// </summary>
        private DataTable _SearchRefListResultDataTable;
        #endregion

        #region Int32 _RowsCount
        /// <summary>
        /// نگهدارنده تعداد سطر های برگشتی گزارش
        /// </summary>
        private Int32 _RowsCount;
        #endregion

        #region List<SP_SelectRefPhysiciansFullDataListResult> _RefPhysiciansList
        private List<SP_SelectRefPhysiciansFullDataListResult> _RefPhysiciansList;
        #endregion

        #region Int16 CurrentReportID
        /// <summary>
        /// كلید گزارش جاری
        /// </summary>
        internal Int16 CurrentReportID
        {
            get { return _CurrentReportID; }
            set
            {
                _CurrentReportID = value;
                ShowDialog();
            }
        }
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض
        /// </summary>
        public frmFilter()
        {
            InitializeComponent();
            PrepareFormControls();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {

        }
        #endregion

        #region Check Box Handlers

        #region cBoxDatesFilter_CheckedChanged
        private void cBoxDatesFilter_CheckedChanged(object sender, EventArgs e)
        {
            PanelRefDate.Enabled = cBoxRefDate.Checked;
            PanelRefPrescribe.Enabled = cBoxPrescribe.Checked;
            PanelRefDocument.Enabled = cBoxDocument.Checked;
            PanelRefTrans.Enabled = cBoxTrans.Checked;
            PanelRefCostDiscount.Enabled = cBoxCostDiscount.Checked;
            RCPDates.Invalidate();
        }
        #endregion

        #region cBoxIns1Filter_CheckedChanged
        private void cBoxIns1Filter_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxIns1Filter.Checked)
            {
                cBoxIns1orIns2.Checked = false;
                dgvIns1.DataSource = DBLayerIMS.Insurance.InsFullList.Where(Data => Data.IsIns1 == true).ToList();
            }
            else dgvIns1.DataSource = null;
        }
        #endregion

        #region cBoxIns2Filter_CheckedChanged
        private void cBoxIns2Filter_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxIns2Filter.Checked)
            {
                cBoxIns1orIns2.Checked = false;
                dgvIns2.DataSource = DBLayerIMS.Insurance.InsFullList.Where(Data => Data.IsIns2 == true).ToList();
            }
            else dgvIns2.DataSource = null;
        }
        #endregion

        #region cBoxIns1orIns2_CheckedChanged
        private void cBoxIns1orIns2_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxIns1orIns2.Checked)
            {
                cBoxIns1Filter.Checked = false;
                cBoxIns2Filter.Checked = false;
                dgvIns1orIns2.DataSource = DBLayerIMS.Insurance.InsFullList.ToList();
            }
            else dgvIns1orIns2.DataSource = null;
        }
        #endregion

        #region cBoxAllSrvInCategories_CheckedChanged
        private void cBoxAllSrvInCategories_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxServiceCategoriesFilter.Checked || cBoxAllSrvInCategories.Checked)
                dgvCategories.DataSource = DBLayerIMS.Services.ServCategoriesList.Where(Data => Data.ID != null).ToList();
            else dgvCategories.DataSource = null;
        }
        #endregion

        #region cBoxSelectedService_CheckedChanged
        private void cBoxSelectedService_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxServiceFilter.Checked) dgvServices.DataSource = DBLayerIMS.Services.ServicesList.ToList();
            else dgvServices.DataSource = null;
        }
        #endregion

        #region cBoxSelectedPhysicians_CheckedChanged
        private void cBoxSelectedPhysicians_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxSelectedPhysicians.Checked)
                dgvServicePhys.DataSource = DBLayerIMS.Referrals.RefServPerformers.Where(Data => Data.IsPhysician == true).ToList();
            else dgvServicePhys.DataSource = null;
        }
        #endregion

        #region cBoxSelectedExperts_CheckedChanged
        private void cBoxSelectedExperts_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxSelectedExperts.Checked)
                dgvServiceExperts.DataSource = DBLayerIMS.Referrals.RefServPerformers.Where(Data => Data.IsExpert == true).ToList();
            else dgvServiceExperts.DataSource = null;
        }
        #endregion

        #region cBoxselectedRefPhysicians_CheckedChanged
        private void cBoxselectedRefPhysicians_CheckedChanged(object sender, EventArgs e)
        {
            if (_RefPhysiciansList == null)
                try { _RefPhysiciansList = Negar.DBLayerPMS.Manager.DBML.SP_SelectRefPhysiciansFullDataList().ToList(); }
                #region Catch
                catch (Exception)
                {
                    PMBox.Show("امكان ارتباط با بانك اطلاعاتی وجود ندارد.\n" +
                        "لطفاً موارد زیر را بررسی نمایید : \n" +
                        "1. آیا ارتباط با بانك اطلاعاتی برقرار است و شبكه متصل می باشد ؟", "خطا!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cBoxselectedRefPhysicians.Checked = false;
                    return;
                }
                #endregion
            if (cBoxselectedRefPhysicians.Checked) dgvRefPhysicians.DataSource = _RefPhysiciansList;
            else dgvRefPhysicians.DataSource = null;
        }
        #endregion

        #region cBoxSelectedCostUsers_CheckedChanged
        private void cBoxSelectedCostUsers_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxSelectedCostUsers.Checked)
                dgvCashiers.DataSource = Negar.DBLayerPMS.Security.UsersList.Where(Data => Data.ID != null).ToList();
            else dgvCashiers.DataSource = null;
        }
        #endregion

        #region cBoxSelectedCostDiscounts_CheckedChanged
        private void cBoxSelectedCostDiscounts_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxSelectedCostDiscounts.Checked) dgvCostDiscounts.DataSource = DBLayerIMS.Account.CostAndDiscountFullList;
            else dgvCostDiscounts.DataSource = null;
        }
        #endregion

        #region cBoxSelectedRefStatus_CheckedChanged
        private void cBoxSelectedRefStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxSelectedRefStatus.Checked) dgvRefStatus.DataSource = DBLayerIMS.Referrals.RefStatusList;
            else dgvRefStatus.DataSource = null;
        }
        #endregion

        #region cBoxSelectedReceptionist_CheckedChanged
        private void cBoxSelectedReceptionist_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxAdmittersFilter.Checked)
                dgvAdmitters.DataSource = Negar.DBLayerPMS.Security.UsersList.Where(Data => Data.ID != null).ToList();
            else dgvAdmitters.DataSource = null;
        }
        #endregion

        #endregion

        #region btnReport_Click
        private void btnReport_Click(object sender, EventArgs e)
        {
            if (!ValidateFilters()) return;
            GenerateSearchString();
            TCReport.Enabled = false;
            btnMaleReport.Enabled = false;
            ProgressBarForm.Text = "در حال گزارش گیری";
            ProgressBarForm.ProgressType = eProgressItemType.Marquee;
            btnClose.Text = "توقف گزارش";
            CancelButton = null;
            btnClose.DialogResult = DialogResult.None;
            BGWorker.RunWorkerAsync();
        }
        #endregion

        #region BGWorker_DoWork
        private void BGWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // پیدا كردن اطلاعات مراجعات بر اساس فیلتر های تعیین شده
            _SearchRefListResultDataTable = DBLayerIMS.Manager.ExecuteQuery(_SearchCommand.ToString(), 0);
            if (_SearchRefListResultDataTable == null)
            {
                PMBox.Show("امكان خواندن اطلاعات از بانك اطلاعاتی وجود ندارد !" + "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟.\n" +
                    "2. آیا سرور در وضعیت متعادلی است و شبكه دارای ترافیك بالا نیست؟.", "خطا !",
                    MessageBoxButtons.OK, MessageBoxIcon.Error); e.Cancel = true; return;
            }
            _RowsCount = _SearchRefListResultDataTable.Rows.Count;
            // تولید جدول نهایی گزارش بر اساس ساختار ستون های گزارش جاری
            if (!ReportGenerator.GenerateFinalResultDataTable(CurrentReportID)) { e.Cancel = true; return; }
            for (Int32 i = 0; i < _RowsCount; i++)
                if (!BGWorker.CancellationPending)
                {
                    if (ReportGenerator.AddAndGenerateReportRow(Convert.ToInt32(_SearchRefListResultDataTable.Rows[i][0]),
                        Convert.ToInt32(_SearchRefListResultDataTable.Rows[i][1]))) BGWorker.ReportProgress(i + 1);
                    else { e.Cancel = true; return; }
                }
        }
        #endregion

        #region BGWorker_ProgressChanged
        private void BGWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (ProgressBarForm.ProgressType != eProgressItemType.Standard)
                ProgressBarForm.ProgressType = eProgressItemType.Standard;
            if (ProgressBarForm.Maximum != _RowsCount) ProgressBarForm.Maximum = _RowsCount;
            ProgressBarForm.Value = e.ProgressPercentage;
            ProgressBarForm.Text = "شماره ردیف مراجعه بیمار: " + e.ProgressPercentage + " از " + _RowsCount;
        }
        #endregion

        #region BGWorker_RunWorkerCompleted
        private void BGWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled) PMBox.Show("گزارش گیری با خطا مواجه شد!", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            #region Change Form Settings
            ProgressBarForm.ProgressType = eProgressItemType.Standard;
            TCReport.Enabled = true;
            btnMaleReport.Enabled = true;
            ProgressBarForm.Text = "در انتظار گزارش گیری";
            btnClose.Text = "خروج\n(Esc)";
            CancelButton = btnClose;
            btnClose.DialogResult = DialogResult.Cancel;
            #endregion
            new Negar.GridPrinting.frmReportPreview(ReportGenerator.FinalResultDataTable);
            BringToFront();
            Focus();
        }
        #endregion

        #region btnClose_Click
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (BGWorker.IsBusy) BGWorker.CancelAsync(); // _IsCancel = true;
            else Close();
        }
        #endregion

        #endregion

        #region Methods

        #region void PrepareFormControls()
        /// <summary>
        ///  تابع آماده سازی كنترل های فرم و برخی تنظیمات اولیه
        /// </summary>
        private void PrepareFormControls()
        {
            #region Set Controls Properties
            //تعیین خواص اولیه كنترل ها
            dgvIns1.AutoGenerateColumns = false;
            dgvIns2.AutoGenerateColumns = false;
            dgvIns1orIns2.AutoGenerateColumns = false;
            dgvCategories.AutoGenerateColumns = false;
            dgvServices.AutoGenerateColumns = false;
            dgvServicePhys.AutoGenerateColumns = false;
            dgvServiceExperts.AutoGenerateColumns = false;
            dgvRefPhysicians.AutoGenerateColumns = false;
            dgvCashiers.AutoGenerateColumns = false;
            dgvCostDiscounts.AutoGenerateColumns = false;
            dgvRefStatus.AutoGenerateColumns = false;
            dgvAdmitters.AutoGenerateColumns = false;
            #endregion

            #region Set DateTime Controls Value
            // مقدار دهی اولیه كنترل ها
            PersianDate PDate = DateTime.Now.ToPersianDate();
            PDate.Day = 1;
            PDatePrescribeFrom.SelectedDateTime = PDate;
            PDateRefDateFrom.SelectedDateTime = PDate;
            PDateDocumentFrom.SelectedDateTime = PDate;
            PDateTransForm.SelectedDateTime = PDate;
            PDateCostDiscountFrom.SelectedDateTime = PDate;

            PDatePrescribeTo.SelectedDateTime = DateTime.Now;
            PDateRefDateTo.SelectedDateTime = DateTime.Now;
            PDateDocumentTo.SelectedDateTime = DateTime.Now;
            PDateTransTo.SelectedDateTime = DateTime.Now;
            PDateCostDiscountTo.SelectedDateTime = DateTime.Now;
            #endregion
        }
        #endregion

        #region Boolean ValidateFilters()
        /// <summary>
        /// بررسی صحت فیلتر های انتخاب شده
        /// </summary>
        /// <returns>صحت تنظیمات انجام شده</returns>
        private Boolean ValidateFilters()
        {
            Boolean Error;

            #region Date
            if (!cBoxRefDate.Checked && !cBoxPrescribe.Checked && !cBoxDocument.Checked &&
                !cBoxTrans.Checked && !cBoxCostDiscount.Checked)
            {
                DialogResult Result = PMBox.Show("هیچ محدوده تاریخی انتخاب نشده است!\n" +
                    "آیا از اجرای گزارش اطمینان دارید؟", "هشداز!",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (Result != DialogResult.Yes) return false;
            }

            #region Ref Date
            DateTime StartRefDate = Convert.ToDateTime(PDateRefDateFrom.SelectedDateTime.Value.Year + "/" +
                PDateRefDateFrom.SelectedDateTime.Value.Month + "/" + PDateRefDateFrom.SelectedDateTime.Value.Day + " " +
                TimeRefDateFrom.Value.Hour + ":" + TimeRefDateFrom.Value.Minute + ":" + TimeRefDateFrom.Value.Second);
            DateTime EndRefDate = Convert.ToDateTime(PDateRefDateTo.SelectedDateTime.Value.Year + "/" +
                PDateRefDateTo.SelectedDateTime.Value.Month + "/" + PDateRefDateTo.SelectedDateTime.Value.Day + " " +
                TimeRefDateTo.Value.Hour + ":" + TimeRefDateTo.Value.Minute + ":" + TimeRefDateTo.Value.Second);
            if (StartRefDate > EndRefDate)
            {
                PMBox.Show("در قسمت تاریخ پذیرش زمان شروع از زمان پایان بزرگتر است!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
            }
            #endregion

            #region Prescribe Date
            DateTime StartPrescribe = Convert.ToDateTime(PDatePrescribeFrom.SelectedDateTime.Value.Year + "/" +
                PDatePrescribeFrom.SelectedDateTime.Value.Month + "/" +
                PDatePrescribeFrom.SelectedDateTime.Value.Day + " 00:00:00");
            DateTime EndPrescribe = Convert.ToDateTime(PDatePrescribeTo.SelectedDateTime.Value.Year + "/" +
                PDatePrescribeTo.SelectedDateTime.Value.Month + "/" + PDatePrescribeTo.SelectedDateTime.Value.Day + " 00:00:00");
            if (StartPrescribe > EndPrescribe)
            {
                PMBox.Show("در قسمت تاریخ نسخه زمان شروع از زمان پایان بزرگتر است!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
            }
            #endregion

            #region Documents Date
            DateTime StartDoc = Convert.ToDateTime(PDateDocumentFrom.SelectedDateTime.Value.Year + "/" +
                PDateDocumentFrom.SelectedDateTime.Value.Month + "/" + PDateDocumentFrom.SelectedDateTime.Value.Day + " " +
                TimeDocumentFrom.Value.Hour + ":" + TimeDocumentFrom.Value.Minute + ":" + TimeDocumentFrom.Value.Second);
            DateTime EndDoc = Convert.ToDateTime(PDateDocumentTo.SelectedDateTime.Value.Year + "/" +
                PDateDocumentTo.SelectedDateTime.Value.Month + "/" + PDateDocumentTo.SelectedDateTime.Value.Day + " " +
                TimeDocumentTo.Value.Hour + ":" + TimeDocumentTo.Value.Minute + ":" + TimeDocumentTo.Value.Second);
            if (StartDoc > EndDoc)
            {
                PMBox.Show("در قسمت تاریخ ایجاد مدرك زمان شروع از زمان پایان بزرگتر است!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
            }
            #endregion

            #region Cost Or Discount Date
            DateTime StartCostDiscount = Convert.ToDateTime(PDateCostDiscountFrom.SelectedDateTime.Value.Year + "/" +
                PDateCostDiscountFrom.SelectedDateTime.Value.Month + "/" +
                PDateCostDiscountFrom.SelectedDateTime.Value.Day + " " + TimeCostDiscountFrom.Value.Hour + ":" +
                TimeCostDiscountFrom.Value.Minute + ":" + TimeCostDiscountFrom.Value.Second);
            DateTime EndCostDiscount = Convert.ToDateTime(PDateCostDiscountTo.SelectedDateTime.Value.Year + "/" +
                PDateCostDiscountTo.SelectedDateTime.Value.Month + "/" +
                PDateCostDiscountTo.SelectedDateTime.Value.Day + " " + TimeCostDiscountTo.Value.Hour + ":" +
                TimeCostDiscountTo.Value.Minute + ":" + TimeCostDiscountTo.Value.Second);
            if (StartCostDiscount > EndCostDiscount)
            {
                PMBox.Show("در قسمت تاریخ تخفیف و هزینه زمان شروع از زمان پایان بزرگتر است!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
            }
            #endregion

            #region Trans Date
            DateTime StartTrans = Convert.ToDateTime(PDateTransForm.SelectedDateTime.Value.Year + "/" +
                PDateTransForm.SelectedDateTime.Value.Month + "/" + PDateTransForm.SelectedDateTime.Value.Day + " " +
                TimeTransFrom.Value.Hour + ":" + TimeTransFrom.Value.Minute + ":" + TimeTransFrom.Value.Second);
            DateTime EndTrans = Convert.ToDateTime(PDateTransTo.SelectedDateTime.Value.Year + "/" +
                PDateTransTo.SelectedDateTime.Value.Month + "/" + PDateTransTo.SelectedDateTime.Value.Day + " " +
                TimeTransTo.Value.Hour + ":" + TimeTransTo.Value.Minute + ":" + TimeTransTo.Value.Second);
            if (StartTrans > EndTrans)
            {
                PMBox.Show("در قسمت تاریخ پرداخت و باز پرداخت زمان شروع از زمان پایان بزرگتر است!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
            }
            #endregion

            #endregion

            #region Ins
            if (cBoxIns1Filter.Checked)
            {
                Error = true;
                foreach (DataGridViewRow row in dgvIns1.Rows)
                    if (Convert.ToBoolean(row.Cells[ColIns1Selected.Index].Value)) { Error = false; break; }
                if (Error)
                {
                    PMBox.Show("هیچ بیمه اولی انتخاب نشده است!", "خطا!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
                }
            }
            if (cBoxIns2Filter.Checked)
            {
                Error = true;
                foreach (DataGridViewRow row in dgvIns2.Rows)
                    if (Convert.ToBoolean(row.Cells[ColIns2Selected.Index].Value)) { Error = false; break; }
                if (Error)
                {
                    PMBox.Show("هیچ بیمه دومی انتخاب نشده است!", "خطا!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
                }
            }
            if (cBoxIns1orIns2.Checked)
            {
                Error = true;
                foreach (DataGridViewRow row in dgvIns1orIns2.Rows)
                    if (Convert.ToBoolean(row.Cells[ColIns1orIns2Selected.Index].Value)) { Error = false; break; }
                if (Error)
                {
                    PMBox.Show("هیچ بیمه اول یا دومی انتخاب نشده است!", "خطا!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
                }
            }
            #endregion

            #region Service
            if (cBoxAllSrvInCategories.Checked || cBoxServiceCategoriesFilter.Checked)
            {
                Error = true;
                foreach (DataGridViewRow row in dgvCategories.Rows)
                    if (Convert.ToBoolean(row.Cells[ColCatSelected.Index].Value)) { Error = false; break; }
                if (Error)
                {
                    PMBox.Show("هیچ طبقه بندی انتخاب نشده است!", "خطا!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
                }
            }
            if (cBoxServiceFilter.Checked)
            {
                Error = true;
                foreach (DataGridViewRow row in dgvServices.Rows)
                    if (Convert.ToBoolean(row.Cells[ColSrvSelected.Index].Value)) { Error = false; break; }
                if (Error)
                {
                    PMBox.Show("هیچ خدمتی انتخاب نشده است!", "خطا!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
                }
            }
            #endregion

            #region Performers
            if (cBoxSelectedPhysicians.Checked)
            {
                Error = true;
                foreach (DataGridViewRow row in dgvServicePhys.Rows)
                    if (Convert.ToBoolean(row.Cells[ColServicePhysSelected.Index].Value)) { Error = false; break; }
                if (Error)
                {
                    PMBox.Show("هیچ پزشك خدمتی انتخاب نشده است!", "خطا!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
                }
            }
            if (cBoxSelectedExperts.Checked)
            {
                Error = true;
                foreach (DataGridViewRow row in dgvServiceExperts.Rows)
                    if (Convert.ToBoolean(row.Cells[ColServiceExpertSelected.Index].Value)) { Error = false; break; }
                if (Error)
                {
                    PMBox.Show("هیچ كارشناس خدمتی انتخاب نشده است!", "خطا!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
                }
            }
            if (cBoxselectedRefPhysicians.Checked)
            {
                Error = true;
                foreach (DataGridViewRow row in dgvRefPhysicians.Rows)
                    if (Convert.ToBoolean(row.Cells[ColRefPhysicianSelected.Index].Value)) { Error = false; break; }
                if (Error)
                {
                    PMBox.Show("هیچ پزشك درخواست كننده ای انتخاب نشده است!", "خطا!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
                }
            }
            #endregion

            #region Cost And Discount
            if (cBoxSelectedCostUsers.Checked)
            {
                Error = true;
                foreach (DataGridViewRow row in dgvCashiers.Rows)
                    if (Convert.ToBoolean(row.Cells[ColCashiersSelected.Index].Value)) { Error = false; break; }
                if (Error)
                {
                    PMBox.Show("هیچ كاربر ثبت كننده تخفیف یا هزینه انتخاب نشده است!", "خطا!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
                }
            }
            if (cBoxSelectedCostDiscounts.Checked)
            {
                Error = true;
                foreach (DataGridViewRow row in dgvCostDiscounts.Rows)
                    if (Convert.ToBoolean(row.Cells[ColCostDiscountSelected.Index].Value)) { Error = false; break; }
                if (Error)
                {
                    PMBox.Show("هیچ نوع تخفیف یا هزینه ای انتخاب نشده است!", "خطا!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
                }
            }
            #endregion

            #region Other Info
            if (cBoxSelectedRefStatus.Checked)
            {
                Error = true;
                foreach (DataGridViewRow row in dgvRefStatus.Rows)
                    if (Convert.ToBoolean(row.Cells[ColRefStatusSelected.Index].Value)) { Error = false; break; }
                if (Error)
                {
                    PMBox.Show("هیچ وضعیت مراجعه ای انتخاب نشده است!", "خطا!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
                }
            }
            if (cBoxAdmittersFilter.Checked)
            {
                Error = true;
                foreach (DataGridViewRow row in dgvAdmitters.Rows)
                    if (Convert.ToBoolean(row.Cells[ColAdmitterSelection.Index].Value)) { Error = false; break; }
                if (Error)
                {
                    PMBox.Show("هیچ پذیرش كننده ای انتخاب نشده است!", "خطا!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
                }
            }
            #endregion

            return true;
        }
        #endregion

        #region void GenerateSearchString()
        /// <summary>
        /// تابعی برای تولید فرمان جستجوی بر اساس فیلتر های تنظیم شده
        /// </summary>
        private void GenerateSearchString()
        {
            String SELECTAndJOINs = "SELECT [TblRefList].[PatientIX] AS [PatID] , " +
                "[TblRefList].[ID] AS [RefID] " +
                "FROM [ImagingSystem].[Referrals].[List]  AS [TblRefList] ";

            #region Add WHERE Command
            StringBuilder WhereCommand = new StringBuilder();
            Boolean IsAnyFilterSelected = false;
            Boolean IsRefServicesFilterSelected = false;
            Boolean IsBaseServicesFilterSelected = false;
            Boolean IsTransFilterSelected = false;
            Boolean IsCostDiscountFilterSelected = false;
            Boolean IsDocFiltersSelected = false;

            #region Date Tab

            #region RefDate
            // تاریخ و ساعت پذیرش 
            if (cBoxRefDate.Checked)
            {
                #region Convert DateTime to String
                String StartDateTime = PDateRefDateFrom.SelectedDateTime.Value.Year + "/" +
                    PDateRefDateFrom.SelectedDateTime.Value.Month + "/" +
                    PDateRefDateFrom.SelectedDateTime.Value.Day + " " +
                    TimeRefDateFrom.Value.Hour + ":" + TimeRefDateFrom.Value.Minute +
                    ":" + TimeRefDateFrom.Value.Second;
                String EndDateTime = PDateRefDateTo.SelectedDateTime.Value.Year + "/" +
                    PDateRefDateTo.SelectedDateTime.Value.Month + "/" +
                    PDateRefDateTo.SelectedDateTime.Value.Day + " " +
                    TimeRefDateTo.Value.Hour + ":" + TimeRefDateTo.Value.Minute +
                    ":" + TimeRefDateTo.Value.Second;
                #endregion

                WhereCommand.Append("[TblRefList].[RegisterDate] >= '" + StartDateTime +
                    "' AND [TblRefList].[RegisterDate] <= '" + EndDateTime + "' ");
                IsAnyFilterSelected = true;
            }
            #endregion

            #region Prescribe Date
            // تاریخ نسخه 
            if (cBoxPrescribe.Checked)
            {
                #region Convert DateTime to String
                String StartDateTime = PDatePrescribeFrom.SelectedDateTime.Value.Year + "/" +
                    PDatePrescribeFrom.SelectedDateTime.Value.Month + "/" +
                    PDatePrescribeFrom.SelectedDateTime.Value.Day + " 00:00:00";

                String EndDateTime = PDatePrescribeTo.SelectedDateTime.Value.Year + "/" +
                    PDatePrescribeTo.SelectedDateTime.Value.Month + "/" +
                    PDatePrescribeTo.SelectedDateTime.Value.Day + " 23:59:59";
                #endregion
                if (IsAnyFilterSelected) WhereCommand.Append("AND ");
                WhereCommand.Append("[TblRefList].[PrescriptionDate] >= '" + StartDateTime +
                    "' AND [TblRefList].[PrescriptionDate] <= '" + EndDateTime + "' ");
                IsAnyFilterSelected = true;
            }
            #endregion

            #region Ref Documents Date
            // تاریخ ایجاد مدرك
            if (cBoxDocument.Checked)
            {
                #region Convert DateTime to String
                String StartDateTime = PDateDocumentFrom.SelectedDateTime.Value.Year + "/" +
                    PDateDocumentFrom.SelectedDateTime.Value.Month + "/" +
                    PDateDocumentFrom.SelectedDateTime.Value.Day + " " +
                    TimeDocumentFrom.Value.Hour + ":" +
                    TimeDocumentFrom.Value.Minute + ":" +
                    TimeDocumentFrom.Value.Second;
                String EndDateTime = PDateDocumentTo.SelectedDateTime.Value.Year + "/" +
                    PDateDocumentTo.SelectedDateTime.Value.Month + "/" +
                    PDateDocumentTo.SelectedDateTime.Value.Day + " " +
                    TimeDocumentTo.Value.Hour + ":" +
                    TimeDocumentTo.Value.Minute + ":" +
                    TimeDocumentTo.Value.Second;
                #endregion
                if (IsAnyFilterSelected) WhereCommand.Append("AND ");
                WhereCommand.Append("[TblDoc].[Date]  >= '" + StartDateTime +
                    "' AND [TblDoc].[Date] <= '" + EndDateTime + "' ");
                IsAnyFilterSelected = true;
                IsDocFiltersSelected = true;
            }
            #endregion

            #region Cost Or Discount Date
            // فیلتر تاریخ تخفیف و هزینه  
            if (cBoxCostDiscount.Checked)
            {
                #region Convert DateTime to String
                String StartDateTime = PDateCostDiscountFrom.SelectedDateTime.Value.Year + "/" +
                    PDateCostDiscountFrom.SelectedDateTime.Value.Month + "/" +
                    PDateCostDiscountFrom.SelectedDateTime.Value.Day + " " +
                    TimeCostDiscountFrom.Value.Hour + ":" +
                    TimeCostDiscountFrom.Value.Minute + ":" +
                    TimeCostDiscountFrom.Value.Second;
                String EndDateTime = PDateCostDiscountTo.SelectedDateTime.Value.Year + "/" +
                    PDateCostDiscountTo.SelectedDateTime.Value.Month + "/" +
                    PDateCostDiscountTo.SelectedDateTime.Value.Day + " " +
                    TimeCostDiscountTo.Value.Hour + ":" +
                    TimeCostDiscountTo.Value.Minute + ":" +
                    TimeCostDiscountTo.Value.Second;
                #endregion
                if (IsAnyFilterSelected) WhereCommand.Append("AND ");
                WhereCommand.Append("[TblCostDiscount].[Date] >= '" + StartDateTime +
                    "' AND [TblCostDiscount].[Date] <= '" + EndDateTime + "' ");
                IsAnyFilterSelected = true;
                IsCostDiscountFilterSelected = true;
            }
            #endregion

            #region Trans Date
            // تاریخ تراكنش
            if (cBoxTrans.Checked)
            {
                #region Convert DateTime to String
                String StartDateTime = PDateTransForm.SelectedDateTime.Value.Year + "/" +
                    PDateTransForm.SelectedDateTime.Value.Month + "/" +
                    PDateTransForm.SelectedDateTime.Value.Day + " " +
                    TimeTransFrom.Value.Hour + ":" +
                    TimeTransFrom.Value.Minute + ":" +
                    TimeTransFrom.Value.Second;
                String EndDateTime = PDateTransTo.SelectedDateTime.Value.Year + "/" +
                    PDateTransTo.SelectedDateTime.Value.Month + "/" +
                    PDateTransTo.SelectedDateTime.Value.Day + " " +
                    TimeTransTo.Value.Hour + ":" +
                    TimeTransTo.Value.Minute + ":" +
                    TimeTransTo.Value.Second;
                #endregion
                if (IsAnyFilterSelected) WhereCommand.Append("AND ");
                String _Temp = "[TblTrans].[OccuredDate] >= '" + StartDateTime +
                    "' AND [TblTrans].[OccuredDate] <= '" + EndDateTime + "' ";
                WhereCommand.Append(_Temp);
                IsAnyFilterSelected = true;
                IsTransFilterSelected = true;
            }
            #endregion

            #endregion

            #region Insurance Tab

            #region Ins1
            // بررسی فیلتر های بیمه اول
            if (cBoxIns1Filter.Checked)
            {
                if (IsAnyFilterSelected) WhereCommand.Append("AND (");
                else WhereCommand.Append("(");
                String SelectedID = String.Empty;
                foreach (DataGridViewRow row in dgvIns1.Rows)
                    if (Convert.ToBoolean(row.Cells[ColIns1Selected.Index].Value) && row.Index > 0)
                        SelectedID += ((SP_SelectInsFullDataResult)row.DataBoundItem).ID + " , ";
                if (String.IsNullOrEmpty(SelectedID)) WhereCommand.Append("[TblRefList].[Ins1IX] IS NULL ");
                else
                {
                    SelectedID = SelectedID.Substring(0, SelectedID.Length - 2).Trim();
                    WhereCommand.Append("[TblRefList].[Ins1IX] IN (" + SelectedID + ") ");
                    if (Convert.ToBoolean(dgvIns1.Rows[0].Cells[ColIns1Selected.Index].Value))
                        WhereCommand.Append("OR [TblRefList].[Ins1IX] IS NULL ");
                }
                WhereCommand.Append(") ");
                IsAnyFilterSelected = true;
            }
            #endregion

            #region Ins2
            //بررسی فیلتر های بیمه دوم
            if (cBoxIns2Filter.Checked)
            {
                if (IsAnyFilterSelected) WhereCommand.Append("AND (");
                else WhereCommand.Append("(");
                String SelectedID = String.Empty;
                foreach (DataGridViewRow row in dgvIns2.Rows)
                    if (Convert.ToBoolean(row.Cells[ColIns2Selected.Index].Value) && row.Index > 0)
                        SelectedID += ((SP_SelectInsFullDataResult)row.DataBoundItem).ID + " , ";
                if (String.IsNullOrEmpty(SelectedID)) WhereCommand.Append("[TblRefList].[Ins2IX] IS NULL ");
                else
                {
                    SelectedID = SelectedID.Substring(0, SelectedID.Length - 2).Trim();
                    WhereCommand.Append("[TblRefList].[Ins2IX] IN (" + SelectedID + ") ");
                    if (Convert.ToBoolean(dgvIns2.Rows[0].Cells[ColIns2Selected.Index].Value))
                        WhereCommand.Append("OR [TblRefList].[Ins2IX] IS NULL ");
                }
                WhereCommand.Append(") ");
                IsAnyFilterSelected = true;
            }
            #endregion

            #region Ins1 Or Ins2
            // بررسی فیلتر بیمه اول یا دوم
            if (cBoxIns1orIns2.Checked)
            {
                if (IsAnyFilterSelected) WhereCommand.Append("AND (");
                else WhereCommand.Append("(");
                String SelectedID = String.Empty;
                foreach (DataGridViewRow row in dgvIns1orIns2.Rows)
                    if (Convert.ToBoolean(row.Cells[ColIns1orIns2Selected.Index].Value) && row.Index > 0)
                        SelectedID += ((SP_SelectInsFullDataResult)row.DataBoundItem).ID + " , ";
                if (String.IsNullOrEmpty(SelectedID))
                    WhereCommand.Append("[TblRefList].[Ins1IX] IS NULL OR [TblRefList].[Ins2IX] IS NULL");
                else
                {
                    SelectedID = SelectedID.Substring(0, SelectedID.Length - 2).Trim();
                    WhereCommand.Append("[TblRefList].[Ins1IX] IN (" + SelectedID + ") OR " +
                        "[TblRefList].[Ins2IX] IN (" + SelectedID + ")");
                    if (Convert.ToBoolean(dgvIns1orIns2.Rows[0].Cells[ColIns1orIns2Selected.Index].Value))
                        WhereCommand.Append(" OR [TblRefList].[Ins1IX] IS NULL OR [TblRefList].[Ins2IX] IS NULL");
                }
                WhereCommand.Append(") ");
                IsAnyFilterSelected = true;
            }
            #endregion

            #endregion

            #region Service Tab

            #region Categories
            // فیلتر طبقه بندی
            if (cBoxNoCategories.Checked)
            {
                if (IsAnyFilterSelected) WhereCommand.Append("AND ");
                WhereCommand.Append("[TblRefServices].[IsActive] = 1 AND " + 
                    "[TblServices].[CategoryIX] IS NULL AND [TblRefServices].[ServiceIX] IS NOT NULL ");
                IsAnyFilterSelected = true;
                IsBaseServicesFilterSelected = true;
            }
            else if (cBoxAllSrvInCategories.Checked)
            {
                if (IsAnyFilterSelected) WhereCommand.Append("AND ");
                String SelectedID = String.Empty;
                foreach (DataGridViewRow row in dgvCategories.Rows)
                    if (Convert.ToBoolean(row.Cells[ColCatSelected.Index].Value))
                        SelectedID += ((DBLayerIMS.DataLayer.SP_SelectCategoriesResult)row.DataBoundItem).ID + " , ";
                SelectedID = SelectedID.Substring(0, SelectedID.Count() - 2);
                WhereCommand.Append("[TblRefServices].[IsActive] = 1 AND " + 
                    "(SELECT COUNT(*) FROM [ImagingSystem].[Referrals].[RefServices] AS [MyTbl1]" +
                    "LEFT OUTER JOIN [ImagingSystem].[Services].[List] AS [MyTbl2]" +
                    "ON [MyTbl1].[ServiceIX] = [MyTbl2].[ID] WHERE [MyTbl1].[ReferralIX] = [TblRefList].[ID] AND " +
                    "[MyTbl2].[CategoryIX] NOT IN (" + SelectedID + ")) = 0 ");
                IsAnyFilterSelected = true;
                IsBaseServicesFilterSelected = true;
            }
            if (cBoxServiceCategoriesFilter.Checked)
            {
                if (IsAnyFilterSelected) WhereCommand.Append("AND ");
                String SelectedID = String.Empty;
                foreach (DataGridViewRow row in dgvCategories.Rows)
                    if (Convert.ToBoolean(row.Cells[ColCatSelected.Index].Value))
                        SelectedID += ((DBLayerIMS.DataLayer.SP_SelectCategoriesResult)row.DataBoundItem).ID + " , ";
                SelectedID = SelectedID.Substring(0, SelectedID.Count() - 2);
                WhereCommand.Append("[TblRefServices].[IsActive] = 1 AND [TblServices].[CategoryIX] IN (" + SelectedID + ") ");
                IsAnyFilterSelected = true;
                IsBaseServicesFilterSelected = true;
            }
            #endregion

            #region Services
            // فیلتر خدمات
            if (cBoxNoServices.Checked)
            {
                if (IsAnyFilterSelected) WhereCommand.Append("AND ");
                WhereCommand.Append("[TblRefServices].[IsActive] = 1 AND " + 
                    "(SELECT COUNT(*) FROM [ImagingSystem].[Referrals].[RefServices] AS [MyTbl2] " +
                    "WHERE [MyTbl2].[ReferralIX] = [TblRefList].[ID]) = 0 ");
                IsAnyFilterSelected = true;
            }
            else if (cBoxHaveServices.Checked)
            {
                if (IsAnyFilterSelected) WhereCommand.Append("AND ");
                WhereCommand.Append("[TblRefServices].[IsActive] = 1 AND " + 
                    "(SELECT COUNT(*) FROM  [ImagingSystem].[Referrals].[RefServices] AS [MyTbl2] " +
                    "WHERE [MyTbl2].[ReferralIX] = [TblRefList].[ID]  ) > 0 ");
                IsAnyFilterSelected = true;
            }
            else if (cBoxServiceFilter.Checked)
            {
                if (IsAnyFilterSelected) WhereCommand.Append("AND ");
                String SelectedID = String.Empty;
                foreach (DataGridViewRow row in dgvServices.Rows)
                    if (Convert.ToBoolean(row.Cells[ColSrvSelected.Index].Value))
                        SelectedID += ((SP_SelectServicesListResult)row.DataBoundItem).ID + " , ";
                SelectedID = SelectedID.Substring(0, SelectedID.Count() - 2);
                WhereCommand.Append("[TblRefServices].[IsActive] = 1 AND [TblRefServices].[ServiceIX] IN (" + SelectedID + ") ");
                IsAnyFilterSelected = true;
                IsRefServicesFilterSelected = true;
            }
            #endregion

            #endregion

            #region Performers Tab

            #region ServicePhysicians
            // فیلتر پزشكان
            if (cBoxSelectedPhysicians.Checked)
            {
                if (IsAnyFilterSelected) WhereCommand.Append("AND (");
                else WhereCommand.Append("(");
                String SelectedID = String.Empty;
                foreach (DataGridViewRow row in dgvServicePhys.Rows)
                    if (Convert.ToBoolean(row.Cells[ColServicePhysSelected.Index].Value) && row.Index > 0)
                        SelectedID += ((SP_SelectPerformersResult)row.DataBoundItem).ID + " , ";
                if (String.IsNullOrEmpty(SelectedID)) WhereCommand.Append("[TblRefServices].[IsActive] = 1 AND " + 
                    "[TblRefServices].[PhysicianIX] IS NULL ");
                else
                {
                    SelectedID = SelectedID.Substring(0, SelectedID.Length - 2).Trim();
                    WhereCommand.Append("[TblRefServices].[IsActive] = 1 AND " + 
                        "[TblRefServices].[PhysicianIX] IN (" + SelectedID + ") ");
                    if (Convert.ToBoolean(dgvServicePhys.Rows[0].Cells[ColServicePhysSelected.Index].Value))
                        WhereCommand.Append("OR [TblRefServices].[PhysicianIX] IS NULL ");
                }
                WhereCommand.Append(") ");
                IsAnyFilterSelected = true;
                IsRefServicesFilterSelected = true;
            }
            #endregion

            #region ServiceExperts
            // فیلتر كارشناسان
            if (cBoxSelectedExperts.Checked)
            {
                if (IsAnyFilterSelected) WhereCommand.Append("AND (");
                else WhereCommand.Append("(");
                String SelectedID = String.Empty;
                foreach (DataGridViewRow row in dgvServiceExperts.Rows)
                    if (Convert.ToBoolean(row.Cells[ColServiceExpertSelected.Index].Value) && row.Index > 0)
                        SelectedID += ((SP_SelectPerformersResult)row.DataBoundItem).ID + " , ";
                if (String.IsNullOrEmpty(SelectedID)) WhereCommand.Append("[TblRefServices].[IsActive] = 1 AND " + 
                    "[TblRefServices].[ExpertIX] IS NULL ");
                else
                {
                    SelectedID = SelectedID.Substring(0, SelectedID.Length - 2).Trim();
                    WhereCommand.Append("[TblRefServices].[IsActive] = 1 AND " + 
                        "[TblRefServices].[ExpertIX] IN (" + SelectedID + ") ");
                    if (Convert.ToBoolean(dgvServiceExperts.Rows[0].Cells[ColServiceExpertSelected.Index].Value))
                        WhereCommand.Append("OR [TblRefServices].[ExpertIX] IS NULL ");
                }
                WhereCommand.Append(") ");
                IsAnyFilterSelected = true;
                IsRefServicesFilterSelected = true;
            }
            #endregion

            #region RefPhysicians
            // فیلتر پزشك درخواست كننده
            if (cBoxselectedRefPhysicians.Checked)
            {
                if (IsAnyFilterSelected) WhereCommand.Append("AND (");
                else WhereCommand.Append("(");
                String SelectedID = String.Empty;
                foreach (DataGridViewRow row in dgvRefPhysicians.Rows)
                    if (Convert.ToBoolean(row.Cells[ColRefPhysicianSelected.Index].Value) && row.Index > 0)
                        SelectedID += ((SP_SelectRefPhysiciansFullDataListResult)row.DataBoundItem).ID + " , ";
                if (String.IsNullOrEmpty(SelectedID)) WhereCommand.Append("[TblRefList].[ReferPhysicianIX] IS NULL ");
                else
                {
                    SelectedID = SelectedID.Substring(0, SelectedID.Length - 2).Trim();
                    WhereCommand.Append("[TblRefList].[ReferPhysicianIX] IN (" + SelectedID + ") ");
                    if (Convert.ToBoolean(dgvRefPhysicians.Rows[0].Cells[ColRefPhysicianSelected.Index].Value))
                        WhereCommand.Append("OR [TblRefList].[ReferPhysicianIX] IS NULL ");
                }
                WhereCommand.Append(") ");
                IsAnyFilterSelected = true;
            }
            #endregion

            #endregion

            #region Cost And Discount Tab

            #region Cashiers Filter
            // تخفیف دهنده یا هزینه 
            if (cBoxSelectedCostUsers.Checked)
            {
                if (IsAnyFilterSelected) WhereCommand.Append("AND ");
                String SelectedID = String.Empty;
                foreach (DataGridViewRow row in dgvCashiers.Rows)
                    if (Convert.ToBoolean(row.Cells[ColCashiersSelected.Index].Value))
                        SelectedID += ((SP_SelectUsersResult)row.DataBoundItem).ID + " , ";
                SelectedID = SelectedID.Substring(0, SelectedID.Length - 2).Trim();
                WhereCommand.Append("[TblCostDiscount].[CashierIX] IN (" + SelectedID + ") ");
                IsAnyFilterSelected = true;
                IsCostDiscountFilterSelected = true;
            }
            #endregion

            #region Cost Discount Type
            // فیلتر نوع تخفیف یا هزینه
            if (cBoxSelectedCostDiscounts.Checked)
            {
                if (IsAnyFilterSelected) WhereCommand.Append("AND ");
                String SelectedID = String.Empty;
                foreach (DataGridViewRow row in dgvCostDiscounts.Rows)
                    if (Convert.ToBoolean(row.Cells[ColCostDiscountSelected.Index].Value))
                        SelectedID += ((CostsAndDiscountsType)row.DataBoundItem).ID + " , ";
                SelectedID = SelectedID.Substring(0, SelectedID.Length - 2).Trim();
                WhereCommand.Append("[TblCostDiscount].[CostIXOrDiscountIX] IN (" + SelectedID + ") ");
                IsAnyFilterSelected = true;
                IsCostDiscountFilterSelected = true;
            }
            #endregion

            #endregion

            #region Other Filters

            #region Ref Status
            // وضعیت مراجعات
            if (cBoxSelectedRefStatus.Checked)
            {
                if (IsAnyFilterSelected) WhereCommand.Append("AND (");
                else WhereCommand.Append("(");
                String SelectedID = String.Empty;
                foreach (DataGridViewRow row in dgvRefStatus.Rows)
                    if (Convert.ToBoolean(row.Cells[ColRefStatusSelected.Index].Value) && row.Index > 0)
                        SelectedID += ((SP_SelectStatusResult)row.DataBoundItem).ID + " , ";
                if (String.IsNullOrEmpty(SelectedID)) WhereCommand.Append("[TblRefList].[ReferStatusIX] IS NULL ");
                else
                {
                    SelectedID = SelectedID.Substring(0, SelectedID.Length - 2).Trim();
                    WhereCommand.Append("[TblRefList].[ReferStatusIX] IN (" + SelectedID + ") ");
                    if (Convert.ToBoolean(dgvRefStatus.Rows[0].Cells[ColRefStatusSelected.Index].Value))
                        WhereCommand.Append("OR [TblRefList].[ReferStatusIX] IS NULL ");
                }
                WhereCommand.Append(") ");
                IsAnyFilterSelected = true;
            }
            #endregion

            #region Ref Admitters
            // فیلتر پذیرش كننده
            if (cBoxAdmittersFilter.Checked)
            {
                if (IsAnyFilterSelected) WhereCommand.Append("AND (");
                else WhereCommand.Append("(");
                String SelectedID = String.Empty;
                foreach (DataGridViewRow row in dgvAdmitters.Rows)
                    if (Convert.ToBoolean(row.Cells[ColAdmitterSelection.Index].Value))
                        SelectedID += ((SP_SelectUsersResult)row.DataBoundItem).ID + " , ";
                SelectedID = SelectedID.Substring(0, SelectedID.Length - 2).Trim();
                WhereCommand.Append("[TblRefList].[AdmitterIX] IN (" + SelectedID + ") ");
                WhereCommand.Append(") ");
                IsAnyFilterSelected = true;
            }
            #endregion

            #endregion

            // اگر خدمات پایه انتخاب شده باشند ، خدمات مراجعه هم باید الحاق شوند
            if (IsBaseServicesFilterSelected) IsRefServicesFilterSelected = true;
            #endregion

            #region Add INNER JOINS
            if (IsRefServicesFilterSelected)
                SELECTAndJOINs += "LEFT OUTER JOIN [ImagingSystem].[Referrals].[RefServices] AS [TblRefServices] " +
                    "ON [TblRefList].[ID] = [TblRefServices].[ReferralIX] ";
            if (IsBaseServicesFilterSelected)
                SELECTAndJOINs += "INNER JOIN [ImagingSystem].[Services].[List] AS [TblServices] " +
                    "ON [TblRefServices].[ServiceIX] = [TblServices].[ID] ";
            if (IsDocFiltersSelected)
                SELECTAndJOINs += "INNER JOIN [ImagingSystem].[Referrals].[RefDocuments] AS [TblDoc] " +
                    "ON [TblRefList].[ID]=[TblDoc].[RefIX] ";
            if (IsTransFilterSelected)
                SELECTAndJOINs += "INNER JOIN [ImagingSystem].[Accounting].[RefTransaction] AS [TblTrans] " +
                    "ON [TblRefList].[ID]=[TblTrans].[ReferralIX] ";
            if (IsCostDiscountFilterSelected)
                SELECTAndJOINs += "INNER JOIN [ImagingSystem].[Accounting].[RefCostsAndDiscounts] AS [TblCostDiscount] " +
                            "ON [TblRefList].[ID]=[TblCostDiscount].[ReferralIX] ";
            #endregion

            _SearchCommand = new StringBuilder();
            _SearchCommand.Append(SELECTAndJOINs);
            if (IsAnyFilterSelected) _SearchCommand.Append("WHERE ");
            // حذف اولین شرط فاقد "و" در شروط
            if (WhereCommand.Length != 0 && WhereCommand.ToString(0, 4) == " AND") WhereCommand.Remove(0, 4);
            _SearchCommand.Append(WhereCommand);
            _SearchCommand.Append("GROUP BY [TblRefList].[ID] , [TblRefList].[PatientIX] , [TblRefList].[RegisterDate] ");
            _SearchCommand.Append("ORDER BY [TblRefList].[RegisterDate];");
        }
        #endregion

        #endregion

    }
}