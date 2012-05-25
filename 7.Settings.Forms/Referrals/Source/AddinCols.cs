#region using
using System;
using System.Data.Linq;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Negar;
using DevComponents.DotNetBar;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Settings.Referrals.Properties;
#endregion

namespace Sepehr.Settings.Referrals
{
    /// <summary>
    /// فرم مدیریت فیلدهای اطلاعات اضافی بیماران
    /// </summary>
    public partial class frmAdditionalCols : Form
    {

        #region Fields

        #region IOrderedQueryable<RefAdditionalColumn> _DataSource
        /// <summary>
        /// فیلد منبع اطلاعاتی فرم
        /// </summary>
        private IOrderedQueryable<RefAdditionalColumn> _DataSource;
        #endregion

        #region Boolean _IsGridValuesChanged
        /// <summary>
        /// تعیین ویرایش شدن فرم توسط كاربر
        /// </summary>
        private Boolean _IsGridValuesChanged;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmAdditionalCols()
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
            _IsGridValuesChanged = false;
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
            if (e.ColumnIndex < 0 || e.RowIndex < 0 || e.Button != MouseButtons.Left) return;
            btnEditApp_Click(null, null);
        }
        #endregion

        #region dgvData_CellValueChanged
        private void dgvData_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            _IsGridValuesChanged = true;
        }
        #endregion

        #region btnAdd_Click
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAdditionalColsAdd MyForm = new frmAdditionalColsAdd();
            if (MyForm.DialogResult == DialogResult.OK)
            { if (!FillDataSource()) { Close(); return; } }
            MyForm.Dispose();
        }
        #endregion

        #region btnEditApp_Click
        private void btnEditApp_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 0) return;
            frmAdditionalColsAdd MyForm =
                new frmAdditionalColsAdd(((RefAdditionalColumn)dgvData.SelectedRows[0].DataBoundItem).ID);
            if (MyForm.DialogResult == DialogResult.OK)
            { if (!FillDataSource()) { Close(); return; } }
            MyForm.Dispose();
        }
        #endregion

        #region btnMultiChoiceFieldItems_Click
        private void btnMultiChoiceFieldItems_Click(object sender, EventArgs e)
        {
            if (dgvData.Rows.Count == 0 || dgvData.SelectedRows.Count == 0) return;
            if (((RefAdditionalColumn)dgvData.SelectedRows[0].DataBoundItem).TypeID != 3)
            {
                PMBox.Show("امكان تخصیص آیتم به ستون هایی كه از نوع چند گزینه ای نیستند وجود ندارد!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            new frmAddinColsMultiChoiceFieldItems(((RefAdditionalColumn)dgvData.SelectedRows[0].DataBoundItem).ID);
        }
        #endregion

        #region btnDelete_Click
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 0) return;
            Int32 RowIndex = dgvData.SelectedCells[0].RowIndex;
            DialogResult Dr = PMBox.Show("آیا مایلید ردیف زیر حذف گردد:\n\"" +
                dgvData.Rows[RowIndex].Cells[ColTitle.Index].Value + "\"", "هشدار", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Dr != DialogResult.Yes) return;
            try
            {
                DBLayerIMS.Manager.DBML.SP_DeleteRefAdditionalColumns(
                    ((RefAdditionalColumn)dgvData.Rows[RowIndex].DataBoundItem).ID);
            }
            #region Catch
            catch (Exception Ex)
            {
                PMBox.Show("امكان حذف ستون اطلاعاتی انتخاب شده وجود ندارد! موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Referrals Setting", Ex.Message + "\n" + Ex.StackTrace,
                    EventLogEntryType.Error);
            }
            #endregion
            if (!FillDataSource()) { Close(); return; }
        }
        #endregion

        #region btnMultiChoiceItems_Click
        private void btnMultiChoiceItems_Click(object sender, EventArgs e)
        {
            new frmAddinColsMultiChoiceItems();
        }
        #endregion

        #region btnHelp_Click
        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("نمایش راهنما");
        }
        #endregion

        #region Form_Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            if (_IsGridValuesChanged)
            {
                DialogResult Dr = PMBox.Show("آیا ار اعمال تغییرات منصرف شده اید؟", "پرسش؟", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (Dr == DialogResult.No) { e.Cancel = true; return; }
            }
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

            #region btnAddAddinData
            TooltipText = ToolTipManager.GetText("btnAddRefAddinData", "IMS");
            FormToolTip.SetSuperTooltip(btnAdd, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnSave
            TooltipText = ToolTipManager.GetText("btnClose", "IMS");
            FormToolTip.SetSuperTooltip(btnSave, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

        }
        #endregion

        #region Boolean FillDataSource()
        /// <summary>
        /// تابع خواندن اطلاعات جدول فیلد های اطلاعات اضافی نوبت دهی از بانك
        /// </summary>
        private Boolean FillDataSource()
        {
            try
            {
                _DataSource = DBLayerIMS.Manager.DBML.RefAdditionalColumns.OrderBy(AdditionalColumn => AdditionalColumn.Title);
                DBLayerIMS.Manager.DBML.Refresh(RefreshMode.KeepChanges, _DataSource);
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان خواندن اطلاعات فیلد های اطلاعات اضافی نوبت دهی از بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Referrals Setting", Ex.Message + "\n" + Ex.StackTrace,
                    EventLogEntryType.Error); return false;
            }
            #endregion
            dgvData.DataSource = _DataSource;
            return true;
        }
        #endregion

        #endregion

    }
}