#region using
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Negar;
using Negar.DBLayerPMS.DataLayer;
using DevComponents.DotNetBar;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Settings.Insurances.Properties;
using SP_SelectCategoriesResult = Sepehr.DBLayerIMS.DataLayer.SP_SelectCategoriesResult;

#endregion

namespace Sepehr.Settings.Insurances.InsurancesServices
{
    /// <summary>
    /// فرم تعیین تخصص های پزشكان درخواست كننده مجاز
    /// </summary>
    internal partial class frmExcludedRefPhys : Form
    {

        #region Fields

        #region readonly Int16 _CurrentInsID
        /// <summary>
        /// كلید بیمه جاری
        /// </summary>
        private readonly Int16 _CurrentInsID;
        #endregion

        #region List<SP_SelectCategoriesResult> _CategoriesDataSource
        /// <summary>
        /// فیلد منبع اطلاعاتی كومبو باكس طبقه بندی خدمات
        /// </summary>
        private List<SP_SelectCategoriesResult> _CategoriesDataSource;
        #endregion

        #region List<SP_SelectServicesListResult> _ServicesDataSource
        /// <summary>
        /// لیست خدمات ثبت شده
        /// </summary>
        private List<SP_SelectServicesListResult> _ServicesDataSource;
        #endregion

        #region List<InsPhysicianExclude> _ExcludedItemList
        /// <summary>
        /// فیلد منبع اطلاعاتی آیتم های محدود شده
        /// </summary>
        private List<InsPhysicianExclude> _ExcludedItemList;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmExcludedRefPhys(Int16 InsID)
        {
            InitializeComponent();
            Cursor.Current = Cursors.WaitCursor;
            dgvData.AutoGenerateColumns = false;
            _CurrentInsID = InsID;
            if (!FillExcludedItems() || !FillBaseDataSource()) { Close(); return; }
            Opacity = 0.01;
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            SetControlsToolTipTexts();
            ChangedgvDataSource();
            Opacity = 1;
            Cursor.Current = Cursors.Default;
        }
        #endregion

        #region cbo_SelectedIndexChanged
        private void cbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangedgvDataSource();
        }
        #endregion

        #region cboExcludedSpecs_Enter
        private void cboExcludedSpecs_Enter(object sender, EventArgs e)
        {
            Application.CurrentInputLanguage =
                InputLanguage.FromCulture(new System.Globalization.CultureInfo("Fa-Ir"));
        }
        #endregion

        #region cboRefPhysician_KeyPress
        /// <summary>
        /// این روال ، منبع داده پزشكان را در هنگامی كه اطلاعات بیش از 2 كاراكتر باشد تكمیل می نماید
        /// </summary>
        private void cboRefPhysician_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') { SelectNextControl(this, true, true, true, true); return; }
            if (!Char.IsLetterOrDigit(e.KeyChar)) { e.Handled = true; return; }
            if (String.IsNullOrEmpty(cboRefPhysician.Text)) { cboRefPhysician.SelectedValue = null; return; }
            // تنها بعد از ورود كاراكتر دوم این روال اجرا می شود
            if (cboRefPhysician.Text.Length != 1) return;
            cboRefPhysician.Text += e.KeyChar.ToString();
            List<Negar.DBLayerPMS.PhysicianFullData> PhysData = null;
            #region Search MedicalID
            if (Char.IsDigit(e.KeyChar))
            {
                PhysData = Negar.DBLayerPMS.ClinicData.GetRefPhysFullDataByValue(cboRefPhysician.Text.Normalize(), true);
                if (PhysData == null) return;
                if (PhysData.Count == 1) { cboRefPhysician_NoDataFound(String.Empty, null); return; }
            }
            #endregion

            #region Search LastName
            else if (Char.IsLetter(e.KeyChar))
            {
                PhysData = Negar.DBLayerPMS.ClinicData.GetRefPhysFullDataByValue(cboRefPhysician.Text.Normalize(), false);
                if (PhysData == null) return;
                if (PhysData.Count == 1) { cboRefPhysician_NoDataFound(String.Empty, null); return; }
            }
            #endregion

            if (PhysData == null) return;
            cboRefPhysician.DataSource = PhysData;
            cboRefPhysician.DisplayMember = "FullTitle";
            cboRefPhysician.ValueMember = "ID";
        }
        #endregion

        #region cboRefPhysician_NoDataFound
        private void cboRefPhysician_NoDataFound(object sender, EventArgs e)
        {
            try
            {
                if (cboRefPhysician.Text.Length == 0) return;
                cboRefPhysician.DataSource = null;
                cboRefPhysician.Text = String.Empty;
                cboCategories.Focus();
                cboCategories.Select();
                cboRefPhysician.Focus();
                cboRefPhysician.Select();
            }
            catch { cboRefPhysician.DataSource = null; }
        }
        #endregion

        #region dgvData_PreviewKeyDown
        private void dgvData_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Apps && dgvData.SelectedCells.Count != 0)
            {
                dgvData_CellMouseClick(1,
                    new DataGridViewCellMouseEventArgs
                        (0, dgvData.SelectedCells[0].RowIndex, Left + Width - 150,
                        dgvData.GetRowDisplayRectangle(dgvData.SelectedCells[0].RowIndex, true).Top
                        + dgvData.ColumnHeadersHeight + 30 + Top,
                        new MouseEventArgs(System.Windows.Forms.MouseButtons.Right, 1, 1, 1, 1)));
            }
        }
        #endregion

        #region dgvData_CellMouseClick
        private void dgvData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
            dgvData.Rows[e.RowIndex].Selected = true;
            System.Drawing.Point Position = MousePosition;
            // اگر درخواست كننده تابع جاری كلید ویندوز باشد و نه كلیك راست موس محل نمایش نموی كلیك راست تغییر می كند
            if (sender is Int32 && e.RowIndex >= 0 && e.ColumnIndex >= 0) Position = e.Location;
            else if (e.Button != MouseButtons.Right || e.RowIndex < 0 || e.ColumnIndex < 0) return;
            // منوی كلیك راست نمایش داده می شود
            cmsMenu.Popup(Position);
        }
        #endregion

        #region dgvData_CellFormatting
        private void dgvData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // نام خدمت
            if (e.ColumnIndex == ColServiceName.Index)
            {
                e.FormattingApplied = true;
                e.Value = _ServicesDataSource.Where(Data => Data.ID == Convert.ToInt16(
                    ((InsPhysicianExclude)dgvData.Rows[e.RowIndex].DataBoundItem).ServiceIX)).First().Name;
            }
            // كد سرویس
            else if (e.ColumnIndex == ColServiceCode.Index)
            {
                e.FormattingApplied = true;
                e.Value = _ServicesDataSource.Where(Data => Data.ID ==
                    ((InsPhysicianExclude)dgvData.Rows[e.RowIndex].DataBoundItem).ServiceIX).First().Code;
            }
            // عنوان تخصص
            else if (e.ColumnIndex == ColSpecName.Index)
            {
                e.FormattingApplied = true;
                try
                {
                    RefPhysician PhysData = Negar.DBLayerPMS.ClinicData.GetRefPhysBaseDataByID(
                        ((InsPhysicianExclude)dgvData.Rows[e.RowIndex].DataBoundItem).RefPhysID);
                    e.Value = PhysData.FirstName + " " + PhysData.LastName + " - نظام پزشكی: " + PhysData.MedicalID;
                }
                #region Catch
                catch (Exception Ex)
                {
                    const String ErrorMessage =
                        "امكان خواندن اطلاعات پزشكان و كارشناسان از بانك وجود ندارد.\n" +
                        "موارد زیر را بررسی نمایید:\n" +
                        "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogManager.SaveLogEntry("Sepehr", "Insurance Settings", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                    return;
                }
                #endregion
            }
        }
        #endregion

        #region btnAdd_Click
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmExcludedRefPhysAdd MyForm = new frmExcludedRefPhysAdd(_CurrentInsID);
            if (MyForm.DialogResult != DialogResult.OK) { MyForm.Dispose(); }
            // بعد از افزودن نیاز به تازه سازی می باشد
            if (!FillExcludedItems()) { Close(); return; }
            ChangedgvDataSource();
        }
        #endregion

        #region btnDelete_Click
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count <= 0) return;
            DialogResult Dr = PMBox.Show("آیا مایلید پزشك مجاز انتخاب شده حذف گردد؟\n" +
                "پس از حذف امكان بازگشت وجود ندارد.",
                "هشدار!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Dr != DialogResult.Yes) return;
            foreach (DataGridViewRow row in dgvData.SelectedRows)
                DBLayerIMS.Manager.DBML.InsPhysicianExcludes.DeleteOnSubmit(((InsPhysicianExclude)row.DataBoundItem));
            if (!DBLayerIMS.Manager.Submit())
            {
                const String ErrorMessage =
                    "امكان حذف پزشك مجاز ثبت شده وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            // بعد از حذف نیاز به تازه سازی منبع داده می باشد
            if (!FillExcludedItems()) { Close(); return; }
            ChangedgvDataSource();
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

        #region Form_Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            Cursor.Current = Cursors.Default;
            Dispose();
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

            #region cboGroups
            TooltipText = ToolTipManager.GetText("cboGroupsServices", "IMS");
            FormToolTip.SetSuperTooltip(cboCategories, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnAdd
            TooltipText = ToolTipManager.GetText("btnAddServicesDefaultPerformer", "IMS");
            FormToolTip.SetSuperTooltip(btnAdd, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion
        }
        #endregion

        #region Boolean FillBaseDataSource()
        /// <summary>
        /// تابع خواندن اطلاعات طبقه بندی های خدمات از بانك
        /// </summary>
        private Boolean FillBaseDataSource()
        {
            DBLayerIMS.Services.ServCategoriesList = null;
            _CategoriesDataSource = DBLayerIMS.Services.ServCategoriesList;
            if (_CategoriesDataSource == null) return false;
            DBLayerIMS.Referrals.RefServPerformers = null;
            _CategoriesDataSource[0].Name = "(همه ی خدمات)";
            cboCategories.DataSource = _CategoriesDataSource;
            return true;
        }
        #endregion

        #region Boolean FillExcludedItems()
        /// <summary>
        /// تابع تكمیل آیتم های مجاز
        /// </summary>
        private Boolean FillExcludedItems()
        {
            _ServicesDataSource = DBLayerIMS.Services.ServicesList;
            if (_ServicesDataSource == null) return false;
            try
            {
                _ExcludedItemList = DBLayerIMS.Manager.DBML.InsPhysicianExcludes
                    .Where(Data => Data.InsIX == _CurrentInsID).OrderBy(Data => Data.RefPhysID).
                    ThenBy(Data => Convert.ToInt32(Data.ServicesList.Code)).ToList();
                DBLayerIMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, _ExcludedItemList);
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان خواندن اطلاعات تخصص های مجاز از بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Insurance Settings", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion
            return true;
        }
        #endregion

        #region void ChangedgvDataSource()
        /// <summary>
        /// تابعی برای تغییر منبع داده جدول تخصص های مجاز
        /// </summary>
        private void ChangedgvDataSource()
        {
            Cursor = Cursors.WaitCursor;
            if (cboCategories.SelectedIndex == 0 && cboRefPhysician.SelectedValue == null)
                dgvData.DataSource = _ExcludedItemList;
            else if (cboCategories.SelectedIndex != 0 && cboRefPhysician.SelectedValue == null)
                dgvData.DataSource = _ExcludedItemList.
                    Where(Data => Data.ServicesList.CategoryIX == Convert.ToInt16(cboCategories.SelectedValue)).ToList();
            else if (cboCategories.SelectedIndex == 0 && cboRefPhysician.SelectedValue != null)
                dgvData.DataSource = _ExcludedItemList.
                    Where(Data => Data.RefPhysID == Convert.ToInt16(cboRefPhysician.SelectedValue)).ToList();
            else dgvData.DataSource = _ExcludedItemList.
                Where(Data => Data.ServicesList.CategoryIX == Convert.ToInt16(cboCategories.SelectedValue) &&
                    Data.RefPhysID == Convert.ToInt16(cboRefPhysician.SelectedValue)).ToList();
            Cursor = Cursors.Default;
        }
        #endregion

        #endregion

    }
}