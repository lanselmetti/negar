#region using
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Negar;
using DevComponents.DotNetBar;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Settings.Services.Properties;
#endregion

namespace Sepehr.Settings.Services
{
    /// <summary>
    /// فرم مدیریت پزشكان و كارشناسان پیش فرض
    /// </summary>
    public partial class frmDefaultPerformers : Form
    {

        #region Fields

        #region List<SP_SelectCategoriesResult> _CategoriesDataSource
        /// <summary>
        /// فیلد منبع اطلاعاتی كومبو باكس طبقه بندی خدمات
        /// </summary>
        private List<SP_SelectCategoriesResult> _CategoriesDataSource;
        #endregion

        #region List<SP_SelectPerformersResult> _PerformersDataSource
        private List<SP_SelectPerformersResult> _PerformersDataSource;
        #endregion

        #region List<SP_SelectServicesListResult> _ServiceDataSource
        /// <summary>
        /// لیست خدمات ثبت شده
        /// </summary>
        private List<SP_SelectServicesListResult> _ServiceDataSource;
        #endregion

        #region List<DefaultPerformers> _DefaultPerformersList
        /// <summary>
        /// فیلد منبع اطلاعاتی پزشكان و كارشناسان پیش فرض
        /// </summary>
        private List<DefaultPerformers> _DefaultPerformersList;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmDefaultPerformers()
        {
            InitializeComponent();
            Cursor.Current = Cursors.WaitCursor;
            dgvData.AutoGenerateColumns = false;
            if (!FillDefaultPerformersDataSource() || !FillBaseDataSource()) { Close(); return; }
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
                e.Value = _ServiceDataSource.Where(Data => Data.ID == Convert.ToInt16(
                    ((DefaultPerformers)dgvData.Rows[e.RowIndex].DataBoundItem).ServiceIX)).First().Name;
            }
            // كد سرویس
            else if (e.ColumnIndex == ColServiceCode.Index)
            {
                e.FormattingApplied = true;
                e.Value = _ServiceDataSource.Where(Data => Data.ID == Convert.ToInt16(
                    ((DefaultPerformers)dgvData.Rows[e.RowIndex].DataBoundItem).ServiceIX)).First().Code;}
            // نام انجام دهنده
            else if (e.ColumnIndex == ColPerformerName.Index)
            {
                e.FormattingApplied = true;
                try
                {
                    e.Value = DBLayerIMS.Manager.DBML.SP_SelectPerformers().Where(Data => Data.ID == Convert.ToInt16(
                    ((DefaultPerformers)dgvData.Rows[e.RowIndex].DataBoundItem).PerformerIX)).First().FullName;
                }
                #region Catch
                catch (Exception Ex)
                {
                    const String ErrorMessage =
                        "امكان خواندن اطلاعات پزشكان و كارشناسان از بانك وجود ندارد.\n" +
                        "موارد زیر را بررسی نمایید:\n" +
                        "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogManager.SaveLogEntry("Sepehr", "Services Settings", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                    return;
                }
                #endregion
            }
            // ساعت آغاز پیش فرض
            else if (e.ColumnIndex == ColStartTime.Index)
            {
                e.FormattingApplied = true;
                String Temp = String.Empty;
                String TimePeriod = ((DefaultPerformers)dgvData.Rows[e.RowIndex].DataBoundItem).Period;
                if (!String.IsNullOrEmpty(TimePeriod)) Temp = TimePeriod.Substring(0, 2) + ":" + TimePeriod.Substring(2, 2);
                e.Value = Temp;
            }
            // ساعت پایان پیش فرض
            else if (e.ColumnIndex == ColEndTime.Index)
            {
                e.FormattingApplied = true;
                String Temp = String.Empty;
                String TimePeriod = ((DefaultPerformers)dgvData.Rows[e.RowIndex].DataBoundItem).Period;
                if (!String.IsNullOrEmpty(TimePeriod)) Temp = TimePeriod.Substring(4, 2) + ":" + TimePeriod.Substring(6, 2);
                e.Value = Temp;
            }
            // روز های پیش فرض
            if (e.ColumnIndex == ColDaysName.Index)
            {
                e.FormattingApplied = true;
                Int16 DayDetector = 0;
                String Temp = String.Empty;
                String SavedDays = ((DefaultPerformers)dgvData.Rows[e.RowIndex].DataBoundItem).Days;
                foreach (Char Day in SavedDays)
                {
                    DayDetector++;
                    if (Day.ToString() == "1")
                        switch (DayDetector)
                        {
                            case 1: Temp += "شنبه، "; break;
                            case 2: Temp += "یك شنبه، "; break;
                            case 3: Temp += "دوشنبه، "; break;
                            case 4: Temp += "سه شنبه، "; break;
                            case 5: Temp += "چهارشنبه، "; break;
                            case 6: Temp += "پنج شنبه، "; break;
                            case 7: Temp += "جمعه، "; break;
                        }
                }
                // حذف "و" آخر از عبارت
                if (!String.IsNullOrEmpty(Temp)) e.Value = Temp.Substring(0, Temp.Count() - 2);
            }
        }
        #endregion

        #region btnAdd_Click
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmDefaultPerformersAdd MyForm = new frmDefaultPerformersAdd();
            if (MyForm.DialogResult != DialogResult.OK) { MyForm.Dispose(); }
            // بعد از افزودن نیاز به تازه سازی می باشد
            if (!FillDefaultPerformersDataSource()) { Close(); return; }
            ChangedgvDataSource();
        }
        #endregion

        #region btnDelete_Click
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count <= 0) return;
            DialogResult Dr = PMBox.Show("آیا مایلید پزشك یا كارشناس پیش فرض حذف گردد؟\n" +
                "با حذف پزشك یا كارشناس پیش فرض امكان بازگشت وجود ندارد.",
                "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Dr != DialogResult.Yes) return;
            foreach (DataGridViewRow row in dgvData.SelectedRows)
                DBLayerIMS.Manager.DBML.DefaultPerformers.DeleteOnSubmit(((DefaultPerformers)row.DataBoundItem));
            if (!DBLayerIMS.Manager.Submit())
            {
                const String ErrorMessage =
                    "امكان حذف پزشك یا كارشناس پیش فرض وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            // بعد از حذف نیاز به تازه سازی منبع داده می باشد
            if (!FillDefaultPerformersDataSource()) { Close(); return; }
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
            _PerformersDataSource = DBLayerIMS.Referrals.RefServPerformers;
            if (_PerformersDataSource == null) return false;
            _CategoriesDataSource[0].Name = "(همه ی خدمات)";
            _PerformersDataSource[0].FullName = "(همه ی كادر پزشكی)";
            cboCategories.DataSource = _CategoriesDataSource;
            cboPerformers.DataSource = _PerformersDataSource;
            return true;
        }
        #endregion

        #region Boolean FillDefaultPerformersDataSource()
        /// <summary>
        /// تابع تكمیل اطلاعات پزشكان و كارشناسان پیش فرض
        /// </summary>
        private Boolean FillDefaultPerformersDataSource()
        {
            _ServiceDataSource = DBLayerIMS.Services.ServicesList;
            if (_ServiceDataSource == null) return false;
            try
            {
                _DefaultPerformersList = DBLayerIMS.Manager.DBML.DefaultPerformers.OrderBy(Data => Data.PerformerIX).
                    ThenBy(Data => Convert.ToInt32(Data.ServicesList.Code)).ToList();
                DBLayerIMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, _DefaultPerformersList);
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان خواندن اطلاعات پزشكان و كارشناسان پیش فرض از بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Services Settings", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion
            return true;
        }
        #endregion

        #region void ChangedgvDataSource()
        /// <summary>
        /// تابعی برای تغییر منبع داده جدول كادر درمان پیش فرض
        /// </summary>
        private void ChangedgvDataSource()
        {
            Cursor = Cursors.WaitCursor;
            if (cboCategories.SelectedIndex == 0 && cboPerformers.SelectedIndex == 0)
                dgvData.DataSource = _DefaultPerformersList;
            else if (cboCategories.SelectedIndex != 0 && cboPerformers.SelectedIndex == 0)
                dgvData.DataSource = _DefaultPerformersList.
                    Where(Data => Data.ServicesList.CategoryIX == Convert.ToInt16(cboCategories.SelectedValue)).ToList();
            else if (cboCategories.SelectedIndex == 0 && cboPerformers.SelectedIndex != 0)
                dgvData.DataSource = _DefaultPerformersList.
                    Where(Data => Data.PerformerIX == Convert.ToInt16(cboPerformers.SelectedValue)).ToList();
            else dgvData.DataSource = _DefaultPerformersList.
                Where(Data => Data.ServicesList.CategoryIX == Convert.ToInt16(cboCategories.SelectedValue) &&
                    Data.PerformerIX == Convert.ToInt16(cboPerformers.SelectedValue)).ToList();
            Cursor = Cursors.Default;
        }
        #endregion

        #endregion

    }
}