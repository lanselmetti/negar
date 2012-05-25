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
using Sepehr.Settings.BillTemplates.Properties;
#endregion

namespace Sepehr.Settings.BillTemplates
{
    /// <summary>
    /// فرم مدیریت محدود كردن نمایش خدمات در قبوض
    /// </summary>
    public partial class frmBillServiceGroupsExclude : Form
    {

        #region Fields

        #region List<BillServCatExclude> _ExcludedServiceCategories
        private List<BillServCatExclude> _ExcludedServiceCategories;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmBillServiceGroupsExclude()
        {
            Cursor.Current = Cursors.WaitCursor;
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            if (!FillServiceCategories() || !FillExcludedServiceCategories()) { Close(); return; }
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            SetControlsToolTipTexts();
            Cursor.Current = Cursors.Default;
        }
        #endregion

        #region dgvData_CellFormatting
        private void dgvData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex > 0 && e.ColumnIndex == ColHide.Index)
            {
                if (!FillExcludedServiceCategories()) { Close(); return; }
                if (_ExcludedServiceCategories.Where(Data => Data.CategoryIX ==
                    ((ServicesCategories)dgvData.Rows[e.RowIndex].DataBoundItem).ID).Count() > 0) e.Value = true;
                else e.Value = false;
                e.FormattingApplied = true;
            }
        }
        #endregion

        #region dgvData_CellEndEdit
        private void dgvData_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == ColHide.Index)
            {
                //((ServicesCategories)dgvData.Rows[e.RowIndex].DataBoundItem).ID
                if (dgvData[e.ColumnIndex, e.RowIndex].Value == null || dgvData[e.ColumnIndex, e.RowIndex].Value == DBNull.Value ||
                    Convert.ToBoolean(dgvData[e.ColumnIndex, e.RowIndex].Value) == false)
                {
                    IQueryable<BillServCatExclude> RowData = DBLayerIMS.Manager.DBML.BillServCatExcludes.
                        Where(Data => Data.CategoryIX == ((ServicesCategories)dgvData.Rows[e.RowIndex].DataBoundItem).ID);
                    if (RowData.Count() != 0)
                        DBLayerIMS.Manager.DBML.BillServCatExcludes.DeleteOnSubmit(RowData.First());
                }
                else
                {
                    IQueryable<BillServCatExclude> RowData = DBLayerIMS.Manager.DBML.BillServCatExcludes.
                        Where(Data => Data.CategoryIX == ((ServicesCategories)dgvData.Rows[e.RowIndex].DataBoundItem).ID);
                    if (RowData.Count() == 0)
                    {
                        BillServCatExclude NewRow = new BillServCatExclude();
                        NewRow.CategoryIX = ((ServicesCategories)dgvData.Rows[e.RowIndex].DataBoundItem).ID;
                        DBLayerIMS.Manager.DBML.BillServCatExcludes.InsertOnSubmit(NewRow);
                    }
                }
                if (!DBLayerIMS.Manager.Submit())
                {
                    PMBox.Show("خطا در ثبت محدودیت قالب چاپ انتخاب شده!" +
                        "موارد زیر را بررسی نمایید:\n" +
                        "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟.\n" +
                        "2. آیا سرور در وضعیت متعادلی است و شبكه دارای ترافیك بالا نیست؟.");
                    Close(); return;
                }
            }
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
            dgvData.EndEdit();
            btnCancel.Focus();
            Dispose();
            Cursor.Current = Cursors.Default;
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

        }
        #endregion

        #region Boolean FillServiceCategories()
        /// <summary>
        /// تابع خواندن اطلاعات طبقه بندی های خدمات
        /// </summary>
        private Boolean FillServiceCategories()
        {
            List<ServicesCategories> DataSource;
            try
            {
                DataSource = DBLayerIMS.Manager.DBML.ServicesCategories.ToList();
                _ExcludedServiceCategories = DBLayerIMS.Manager.DBML.BillServCatExcludes.ToList();
            }
            #region Catch
            catch (Exception Ex)
            {
                PMBox.Show("خطا در خواندن اطلاعات قبوض تعریف شده از بانك اطلاعات!\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟.\n" +
                    "2. آیا سرور در وضعیت متعادلی است و شبكه دارای ترافیك بالا نیست؟.");
                LogManager.SaveLogEntry("Sepehr", "Bills Template Settings", Ex.Message + "\n" + Ex.StackTrace,
                    EventLogEntryType.Error);
                return false;
            }
            #endregion
            if (DataSource.Count == 0)
            {
                PMBox.Show("طبقه بندی خدمتی در سیستم ثبت نشده تا نمایش داده شود!\n" +
                    "ابتدا برای خدمات طبقه بندی تعریف كنید و سپس خدمات را عضو آنها نمایید.", "خطا!");
                return false;
            }
            dgvData.DataSource = DataSource;
            return true;
        }
        #endregion

        #region Boolean FillExcludedServiceCategories()
        /// <summary>
        /// تابع خواندن اطلاعات طبقه بندی های خدمات حذف شده
        /// </summary>
        private Boolean FillExcludedServiceCategories()
        {
            try
            {
                _ExcludedServiceCategories = DBLayerIMS.Manager.DBML.BillServCatExcludes.ToList();
                DBLayerIMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, _ExcludedServiceCategories);
            }
            #region Catch
            catch (Exception Ex)
            {
                PMBox.Show("خطا در خواندن اطلاعات طبقه بندی های حذف شده از قبوض!\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟.\n" +
                    "2. آیا سرور در وضعیت متعادلی است و شبكه دارای ترافیك بالا نیست؟.");
                LogManager.SaveLogEntry("Sepehr", "Bills Template Settings", Ex.Message + "\n" + Ex.StackTrace,
                    EventLogEntryType.Error);
                return false;
            }
            #endregion
            return true;
        }
        #endregion

        #endregion

    }
}