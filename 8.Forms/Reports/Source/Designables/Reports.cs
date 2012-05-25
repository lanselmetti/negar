#region using
using System;
using System.Data.Linq;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Negar;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Forms.Reports.Designables.Report;

#endregion

namespace Sepehr.Forms.Reports.Designables
{
    /// <summary>
    /// فرم مدیریت گزارش های قابل طراحی
    /// </summary>
    public partial class frmReports : Form
    {

        #region Fields

        #region frmFilter _FilterForm
        /// <summary>
        /// شیء فرم فیلتر گزارش ها
        /// </summary>
        private frmFilter _FilterForm;
        #endregion

        #endregion

        #region Ctor
        public frmReports()
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            if (!FillFormDataSource()) { Close(); return; }
            dgvData.ColumnHeadersDefaultCellStyle.Font = new Font("B Titr", 12, FontStyle.Bold);
            dgvData.DefaultCellStyle.Font = new Font("B Koodak", 14, FontStyle.Bold);
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region dgvData_PreviewKeyDown
        private void dgvData_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Apps && dgvData.SelectedCells.Count != 0)
            {
                dgvData_CellMouseClick(1,
                    new DataGridViewCellMouseEventArgs
                        (0, dgvData.SelectedCells[0].RowIndex, Left + Width - 150,
                        Top + dgvData.Top + dgvData.ColumnHeadersHeight + 5 +
                        dgvData.GetRowDisplayRectangle(dgvData.SelectedCells[0].RowIndex, true).Top,
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
            if (e.Button == MouseButtons.Left && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (_FilterForm == null || _FilterForm.IsDisposed) _FilterForm = new frmFilter();
                _FilterForm.CurrentReportID = ((DesignableReport) dgvData.Rows[e.RowIndex].DataBoundItem).ID;
            }
        }
        #endregion

        #region btnAdd_Click
        private void btnAdd_Click(object sender, EventArgs e)
        {
            new Design.frmManage(null);
            if (!FillFormDataSource()) { Close(); return; }
        }
        #endregion

        #region btnDelete_Click
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult Result = PMBox.Show("آیا مایلید آیتم انتخاب شده حذف گردد؟", "هشدار!",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (Result != DialogResult.Yes) return;
            DBLayerIMS.Manager.DBML.DesignableReports.
                DeleteOnSubmit((DesignableReport)dgvData.SelectedRows[0].DataBoundItem);
            if (!DBLayerIMS.Manager.Submit())
            {
                PMBox.Show("خطا در حذف اطلاعات گزارش از بانك اطلاعات!\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟.\n" +
                    "2. آیا سرور در وضعیت متعادلی است و شبكه دارای ترافیك بالا نیست؟.", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            if (!FillFormDataSource()) { Close(); return; }
        }
        #endregion

        #region btnEdit_Click
        private void btnEdit_Click(object sender, EventArgs e)
        {
            new Design.frmManage(((DesignableReport)dgvData.SelectedRows[0].DataBoundItem).ID);
            if (!FillFormDataSource()) { Close(); return; }
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

        #region void FillFormDataSource()
        /// <summary>
        /// تابع تازه سازی جدول گزارش ها 
        /// </summary>
        /// <returns>صحت انجام كار</returns>
        private Boolean FillFormDataSource()
        {
            try
            {
                Table<DesignableReport> DesignableReport = DBLayerIMS.Manager.DBML.DesignableReports;
                DBLayerIMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, DesignableReport);
                dgvData.DataSource = DesignableReport.ToList();
            }
            #region Catch
            catch (Exception Ex)
            {
                PMBox.Show("خطا در خواندن لیست گزارش های طراحی شده از بانك اطلاعات ممكن نیست!" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟.\n" +
                    "2. آیا سرور در وضعیت متعادلی است و شبكه دارای ترافیك بالا نیست؟.",
                    "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Reports Forms", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error); return false;
            }
            #endregion
            return true;
        }
        #endregion

        #endregion

    }
}