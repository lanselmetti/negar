#region using
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Negar;
using DevComponents.DotNetBar;
using Sepehr.DBLayerIMS;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Settings.Schedules.Properties;
#endregion

namespace Sepehr.Settings.Schedules.AppsAddinFields
{
    /// <summary>
    /// فرم مدیریت فیلدهای اطلاعات اضافی نوبت دهی
    /// </summary>
    public partial class frmAddinCols : Form
    {

        #region Fields

        #region List<SchAddinColumns> _DataSource
        /// <summary>
        /// فیلد منبع اطلاعاتی فرم
        /// </summary>
        private List<SchAddinColumns> _DataSource;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmAddinCols()
        {
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("Fa-Ir"));
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
            if (sender.GetType().Equals(typeof(Int32)) &&
                e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dgvData.Rows[e.RowIndex].Selected = true;
                cmsMenu.PopupMenu(e.Location);
            }
            else if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dgvData.Rows[e.RowIndex].Selected = true;
                cmsMenu.Popup(MousePosition);
            }
        }
        #endregion

        #region dgvData_CellMouseDoubleClick
        private void dgvData_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0 || e.Button != MouseButtons.Left) return;
            btnEditApp_Click(null, null);
        }
        #endregion

        #region btnAdd_Click
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddinColsManage MyForm = new frmAddinColsManage();
            if (MyForm.DialogResult != DialogResult.OK) return;
            if (!FillDataSource()) { Close(); return; }
        }
        #endregion

        #region btnEditApp_Click
        private void btnEditApp_Click(object sender, EventArgs e)
        {
            if (dgvData.Rows.Count == 0 || dgvData.SelectedRows.Count == 0) return;
            frmAddinColsManage MyForm = new
                frmAddinColsManage(((SchAddinColumns)dgvData.SelectedRows[0].DataBoundItem).ID);
            if (MyForm.DialogResult == DialogResult.OK && !FillDataSource()) { Close(); return; }
            dgvData.Refresh();
        }
        #endregion

        #region btnMultiChoiceFieldItems_Click
        private void btnMultiChoiceFieldItems_Click(object sender, EventArgs e)
        {
            if (dgvData.Rows.Count == 0 || dgvData.SelectedRows.Count == 0) return;
            if (((SchAddinColumns)dgvData.SelectedRows[0].DataBoundItem).TypeID != 3)
            {
                PMBox.Show("امكان تخصیص آیتم به ستون هایی كه از نوع چند گزینه ای نیستند وجود ندارد!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            new frmAddinColsMultiChoiceFieldItems(((SchAddinColumns)dgvData.SelectedRows[0].DataBoundItem).ID);
        }
        #endregion

        #region btnColsOrder_Click
        private void btnColsOrder_Click(object sender, EventArgs e)
        {
            new frmColumnsOrder();
        }
        #endregion

        #region btnDelete_Click
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 0 || dgvData.SelectedCells.Count == 0) return;
            Int32 RowIndex;
            if (dgvData.SelectedRows.Count == 0) RowIndex = dgvData.SelectedCells[0].RowIndex;
            else RowIndex = dgvData.SelectedRows[0].Index;
            DialogResult Dr = PMBox.Show("آیا مایلید فیلد زیر حذف گردد:\n\"" +
                dgvData.Rows[RowIndex].Cells[ColTitle.Index].Value + "\n" +
                "با حذف یك فیلد تغییرات عیناً در بانك اطلاعات اعمال می گردند و امكان بازگشت اطلاعات وجود ندارد."
                , "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Dr == DialogResult.Yes) if (!DeleteSchAddinColumn((
                (SchAddinColumns)dgvData.Rows[RowIndex].DataBoundItem).ID) || !FillDataSource()) { Close(); return; }
        }
        #endregion

        #region btnMultiChoiceItems_Click
        private void btnMultiChoiceItems_Click(object sender, EventArgs e)
        {
            new frmAddinColsMultiChoiceItems();
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
            TooltipText = ToolTipManager.GetText("btnAddSchAddinData", "IMS");
            FormToolTip.SetSuperTooltip(btnAdd, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnClose
            TooltipText = ToolTipManager.GetText("btnClose", "IMS");
            FormToolTip.SetSuperTooltip(btnClose, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

        }
        #endregion

        #region Boolean FillDataSource()
        /// <summary>
        /// تابع خواندن اطلاعات جدول از بانك
        /// </summary>
        private Boolean FillDataSource()
        {
            DBLayerIMS.Schedules.SchAddinColumnsList = null;
            _DataSource = DBLayerIMS.Schedules.SchAddinColumnsList;
            if (_DataSource == null) return false;
            dgvData.DataSource = _DataSource;
            return true;
        }
        #endregion

        #region Boolean DeleteSchAddinColumn(Int16 ColID)
        /// <summary>
        /// تابعی برای حذف یك فیلد اطلاعاتی پویا نوبت دهی از بانك اطلاعات
        /// </summary>
        /// <returns>حذف موفقیت آمیز یا وقوع خطا</returns>
        private static Boolean DeleteSchAddinColumn(Int16 ColID)
        {
            try { Manager.DBML.SP_DeleteAdditionalColumns(ColID); }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان حذف فیلد اطلاعاتی اضافی نوبت دهی از بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Schedules Settings", Ex.Message + "\n" + Ex.StackTrace, 
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