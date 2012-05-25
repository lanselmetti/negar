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
    /// فرم مدیریت فیلد های سرفصل های اضافه خدمات
    /// </summary>
    internal partial class frmServicesPriceFields : Form
    {

        #region Fields

        #region List<AdditionalPriceColumn> _DataSource
        /// <summary>
        /// فیلد منبع اطلاعاتی فرم
        /// </summary>
        private List<AdditionalPriceColumn> _DataSource;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmServicesPriceFields()
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            if (!FillDataSource()) { Close(); return; }
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            SetControlsToolTipTexts();
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
            System.Drawing.Point Position = MousePosition;
            // اگر درخواست كننده تابع جاری كلید ویندوز باشد و نه كلیك راست موس محل نمایش نموی كلیك راست تغییر می كند
            if (sender is Int32 && e.RowIndex >= 0 && e.ColumnIndex >= 0) Position = e.Location;
            else if (e.Button != MouseButtons.Right || e.RowIndex < 0 || e.ColumnIndex < 0) return;
            // ردیف مورد نظر انتخاب می شود
            dgvData.Rows[e.RowIndex].Selected = true;
            // منوی كلیك راست نمایش داده می شود
            cmsMenu.Popup(Position);
        }
        #endregion

        #region dgvData_CellMouseDoubleClick
        private void dgvData_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || e.ColumnIndex < 0 || e.RowIndex < 0) return;
            btnEdit_Click(null, null);
        }
        #endregion

        #region dgvData_CellBeginEdit
        private void dgvData_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            btnDelete.Shortcuts.Clear();
        }
        #endregion

        #region dgvData_CellEndEdit
        private void dgvData_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            btnDelete.Shortcuts.Add(eShortcut.Del);
        }
        #endregion

        #region btnAdd_Click
        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult Dr = new frmServicesPriceFieldsManage().DialogResult;
            if (Dr == DialogResult.OK)
                if (!FillDataSource()) Close();
        }
        #endregion

        #region btnEdit_Click
        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmServicesPriceFieldsManage MyForm =
                  new frmServicesPriceFieldsManage
                      (((AdditionalPriceColumn)dgvData.SelectedRows[0].DataBoundItem).ID);
            if (MyForm.DialogResult == DialogResult.OK)
            { if (!FillDataSource()) { Close(); return; } }
            MyForm.Dispose();
        }
        #endregion

        #region btnDelete_Click
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult Dr = PMBox.Show("آیا نسبت به حذف سرفصل قیمت اطمینان دارید؟\n" +
                "با حذف یك سرفصل قیمت كلیه فرمول های بیمه دومی " +
                "كه از آن سرفصل استفاده كرده اند غیر قابل استفاده می گردند.\n" +
                "اما خدماتی كه قبلاً از این قیمت ها در مراجعات " +
                "استفاده نموده اند بدون تغییر باقی خواهند ماند.",
                "هشدار!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);
            if (Dr == DialogResult.Yes)
                try
                {
                    DBLayerIMS.Manager.DBML.SP_DeleteAdditionalPriceColumns((
                        (AdditionalPriceColumn)dgvData.SelectedRows[0].DataBoundItem).ID);
                }
                #region Catch
                catch (Exception Ex)
                {
                    const String ErrorMessage =
                        "امكان حذف ستون قیمت اضافی خدمات از بانك اطلاعات ممكن نیست.\n" +
                        "موارد زیر را بررسی نمایید:\n" +
                        "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogManager.SaveLogEntry("Sepehr", "Services Settings",
                        Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error); return;
                }
                #endregion
            if (!FillDataSource()) Close();
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

            #region btnAdd
            TooltipText = ToolTipManager.GetText("btnAddServicesPriceField", "IMS");
            FormToolTip.SetSuperTooltip(btnAdd, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnDelete
            TooltipText = ToolTipManager.GetText("btnDelete", "IMS");
            FormToolTip.SetSuperTooltip(btnDelete, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnSave
            TooltipText = ToolTipManager.GetText("btnClose", "IMS");
            FormToolTip.SetSuperTooltip(btnClose, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

        }
        #endregion

        #region Boolean FillDataSource()
        /// <summary>
        /// تابع خواندن  اطلاعات فیلد های سرفصل های اضافه از بانك
        /// </summary>
        private Boolean FillDataSource()
        {
            try
            {
                _DataSource = DBLayerIMS.Manager.DBML.AdditionalPriceColumns.ToList();
                DBLayerIMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, _DataSource);
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان خواندن اطلاعات فیلد های سرفصل های اضافه از بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Services Settings", Ex.Message + "\n" + Ex.StackTrace,
                    EventLogEntryType.Error);
                return false;
            }
            #endregion
            dgvData.DataSource = _DataSource;
            dgvData.Refresh();
            return true;
        }
        #endregion

        #endregion

    }
}