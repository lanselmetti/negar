#region using
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Negar;
using DevComponents.DotNetBar;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Settings.Patients.Properties;
#endregion

namespace Sepehr.Settings.Patients
{
    /// <summary>
    /// فرم مديريت فيلدهاي اطلاعات اضافي بيماران
    /// </summary>
    public partial class frmAdditionalCols : Form
    {

        #region Fields

        #region IOrderedQueryable<PatAdditionalColumn> _DataSource
        /// <summary>
        /// فيلد منبع اطلاعاتي فرم
        /// </summary>
        private IOrderedQueryable<PatAdditionalColumn> _DataSource;
        #endregion

        #region Boolean _IsGridValuesChanged
        /// <summary>
        /// تعيين ويرايش شدن فرم توسط كاربر
        /// </summary>
        private Boolean _IsGridValuesChanged;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پيش فرض فرم
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
            frmAdditionalColsManage MyForm = new frmAdditionalColsManage();
            if (MyForm.DialogResult == DialogResult.OK)
            { if (!FillDataSource()) { Close(); return; } }
            MyForm.Dispose();
        }
        #endregion

        #region btnEditApp_Click
        private void btnEditApp_Click(object sender, EventArgs e)
        {
            frmAdditionalColsManage MyForm =
                new frmAdditionalColsManage(((PatAdditionalColumn)dgvData.SelectedRows[0].DataBoundItem).ID);
            if (MyForm.DialogResult == DialogResult.OK)
            { if (!FillDataSource()) { Close(); return; } }
            MyForm.Dispose();
        }
        #endregion

        #region btnMultiChoiceFieldItems_Click
        private void btnMultiChoiceFieldItems_Click(object sender, EventArgs e)
        {
            if (dgvData.Rows.Count == 0 || dgvData.SelectedRows.Count == 0) return;
            if (((PatAdditionalColumn)dgvData.SelectedRows[0].DataBoundItem).TypeID != 3)
            {
                PMBox.Show("امكان تخصیص آیتم به ستون هایی كه از نوع چند گزینه ای نیستند وجود ندارد!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            new frmAddinColsMultiChoiceFieldItems(((PatAdditionalColumn)dgvData.SelectedRows[0].DataBoundItem).ID);
        }
        #endregion

        #region btnDelete_Click
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Int32 RowIndex;
            if (dgvData.SelectedRows.Count > 0) RowIndex = dgvData.SelectedRows[0].Index;
            else if (dgvData.SelectedCells.Count > 0) RowIndex = dgvData.SelectedCells[0].RowIndex;
            else return;
            DialogResult Dr = PMBox.Show("آيا مايليد رديف زير حذف گردد:\n\"" +
                dgvData.Rows[RowIndex].Cells[ColTitle.Index].Value + "\"", "هشدار", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Dr != DialogResult.Yes) return;
            try
            {
                DBLayerIMS.Manager.DBML.SP_DeletePatAdditionalColumns(
                    ((PatAdditionalColumn)dgvData.Rows[RowIndex].DataBoundItem).ID);
            }
            #region Catch
            catch (Exception Ex)
            {
                PMBox.Show("امكان حذف ستون اطلاعاتي انتخاب شده وجود ندارد! موارد زير را بررسي نماييد:\n" +
                    "1. آيا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل مي باشد؟", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Patients Settings",
                    Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
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
            MessageBox.Show("نمايش راهنما");
        }
        #endregion

        #region Form_Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            if (_IsGridValuesChanged)
            {
                DialogResult Dr = PMBox.Show("آيا منصرف شديد؟", "هشدار", MessageBoxButtons.YesNo,
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
        /// تابع تنظيم متن راهنماي كنترل ها
        /// </summary>
        private void SetControlsToolTipTexts()
        {
            const String TooltipHeader = "راهنماي تنظيمات سيستم";
            const String TooltipFooter = "سيستم مديريت تصويربرداري سپهر";

            #region btnHelp
            String TooltipText = ToolTipManager.GetText("btnHelp", "IMS");
            FormToolTip.SetSuperTooltip(btnHelp, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnAddAddinData
            TooltipText = ToolTipManager.GetText("btnAddPatAddinData", "IMS");
            FormToolTip.SetSuperTooltip(btnAdd, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnSaveAndClose
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
            try { _DataSource = DBLayerIMS.Manager.DBML.PatAdditionalColumns.OrderBy(Data => Data.Title); }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان خواندن اطلاعات فيلد هاي اطلاعات اضافي نوبت دهي از بانك وجود ندارد.\n" +
                    "موارد زير را بررسي نماييد:\n" +
                    "1. آيا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل مي باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Patients Settings", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion
            dgvData.DataSource = _DataSource;
            return true;
        }
        #endregion

        #endregion

    }
}