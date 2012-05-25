#region using
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Negar;
using Sepehr.DBLayerIMS.DataLayer;
#endregion

namespace Sepehr.Forms.Reports.Designables.Design
{
    internal partial class frmAddinFields : Form
    {

        #region Fields

        #region List<DesignableReportsAddinCol> _DesignableReportsAddinCols
        /// <summary>
        /// لیست اجزاء اطلاعاتی تعریف شده در سیستم
        /// </summary>
        private List<DesignableReportsAddinCol> _DesignableReportsAddinCols;
        #endregion

        #endregion

        #region Ctor
        public frmAddinFields()
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            if (!FillDataSource()) { Close(); return; }
            ShowDialog();
        }
        #endregion

        #region EventHandlers

        #region dgvData_PreviewKeyDown
        private void dgvData_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Apps && dgvData.SelectedCells.Count != 0)
                dgvData_CellMouseClick(1, new DataGridViewCellMouseEventArgs
                    (0, dgvData.SelectedCells[0].RowIndex, Left + Width - 150,
                    Top + dgvData.Top + dgvData.ColumnHeadersHeight + 18 +
                    dgvData.GetRowDisplayRectangle(dgvData.SelectedCells[0].RowIndex, true).Top,
                    new MouseEventArgs(System.Windows.Forms.MouseButtons.Right, 1, 1, 1, 1)));
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
            else if (e.Button == MouseButtons.Right && e.RowIndex >= 0 &&
                e.ColumnIndex >= 0 && e.RowIndex != dgvData.NewRowIndex)
            {
                dgvData.Rows[e.RowIndex].Selected = true;
                cmsMenu.Popup(MousePosition);
            }
        }
        #endregion

        #region dgvData_CellMouseDoubleClick
        private void dgvData_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.RowIndex >= 0 && e.ColumnIndex >= 0) btnEdit_Click(null, null);
        }
        #endregion

        #region btnAdd_Click
        private void btnAdd_Click(object sender, EventArgs e)
        {
            new frmAddinFieldsManage();
            if (!FillDataSource()) { Close(); return; }
        }
        #endregion

        #region btnDelete_Click
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult Result = PMBox.Show("آیا مایلید آیتم انتخاب شده حذف گردد؟", "هشدار!",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (Result != DialogResult.Yes) return;
            DBLayerIMS.Manager.DBML.DesignableReportsAddinCols.
                DeleteOnSubmit((DesignableReportsAddinCol)dgvData.SelectedRows[0].DataBoundItem);
            if (!DBLayerIMS.Manager.Submit())
            {
                PMBox.Show("امكان حذف ستون پویای گزارش های قابل طراحی انتخاب شده وجود ندارد!\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟.\n" +
                    "2. آیا سرور در وضعیت متعادلی است و شبكه دارای ترافیك بالا نیست؟.", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            if (!FillDataSource()) { Close(); return; }
        }
        #endregion

        #region btnEdit_Click
        private void btnEdit_Click(object sender, EventArgs e)
        {
            new frmAddinFieldsManage(((DesignableReportsAddinCol)dgvData.SelectedRows[0].DataBoundItem).ID);
            if (!FillDataSource()) { Close(); return; }
        }
        #endregion

        #endregion

        #region Methods

        #region void FillDataSource()
        /// <summary>
        /// تابع تازه سازی جدول اجزاء اطلاعاتی تعریف شده
        /// </summary>
        /// <returns>صحت انجام كار</returns>
        private Boolean FillDataSource()
        {
            try
            {
                Table<DesignableReportsAddinCol> TempData =
                    DBLayerIMS.Manager.DBML.DesignableReportsAddinCols;
                DBLayerIMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, TempData);
                _DesignableReportsAddinCols = TempData.ToList();
            }
            #region Catch
            catch (Exception Ex)
            {
                PMBox.Show("امكان خواندن اطلاعات از بانك اطلاعاتی وجود ندارد !" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟.\n" +
                    "2. آیا سرور در وضعیت متعادلی است و شبكه دارای ترافیك بالا نیست؟.");
                LogManager.SaveLogEntry("Sepehr", "Reports Forms", Ex.Message + "\n" + Ex.StackTrace,
                    EventLogEntryType.Error);
                return false;
            }
            #endregion
            dgvData.DataSource = _DesignableReportsAddinCols;
            return true;
        }
        #endregion

        #endregion

    }
}