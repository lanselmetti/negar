#region using

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Negar;
using Sepehr.DBLayerIMS.DataLayer;

#endregion

namespace Sepehr.Forms.Cash
{
    /// <summary>
    /// فرم نمایش اطلاعات صندوق ها
    /// </summary>
    public partial class frmCashesReport : Form
    {

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmCashesReport()
        {
            Cursor.Current = Cursors.WaitCursor;
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            if (Negar.DBLayerPMS.Security.UsersList == null) { Close(); return; }
            #region Check User Permissions
            // بررسی سطح دسترسی كاربر جاری
            if (SecurityManager.CurrentUserID > 2 && !ReadCurrentUserPermissions()) { Close(); return; }
            #endregion
            cboCashier.DataSource = Negar.DBLayerPMS.Security.UsersList;
            if (!FillCashes()) { Close(); return; }
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            FromDate.SelectedDateTime = DateTime.Now.AddDays(-2);
            ToDate.SelectedDateTime = DateTime.Now;
            FromTime.Value = new DateTime(2000, 1, 1, 0, 0, 0);
            ToTime.Value = new DateTime(2000, 1, 1, 23, 59, 59);
            btnRefresh_Click(null, null);
            Cursor.Current = Cursors.Default;
        }
        #endregion

        #region btnRefresh_Click
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            List<VW_SelectCashesReport> ReportData;
            DateTime StartDate = new DateTime(FromDate.SelectedDateTime.Value.Year,
                FromDate.SelectedDateTime.Value.Month, FromDate.SelectedDateTime.Value.Day, FromTime.Value.Hour,
                FromTime.Value.Minute, FromTime.Value.Second);
            DateTime EndDate = new DateTime(ToDate.SelectedDateTime.Value.Year,
                ToDate.SelectedDateTime.Value.Month, ToDate.SelectedDateTime.Value.Day,
                ToTime.Value.Hour, ToTime.Value.Minute, ToTime.Value.Second);
            try
            {
                ReportData = DBLayerIMS.Manager.DBML.VW_SelectCashesReports.
                    Where(Data => Data.CashID == Convert.ToInt16(cboCash.SelectedValue) &&
                        (Data.StartDateTime >= StartDate || Data.StartDateTime == null) &&
                        (Data.FinishDateTime <= EndDate || Data.FinishDateTime == null)).ToList();
            }
            #region Catch
            catch (Exception Ex)
            {
                PMBox.Show("خطا در خواندن اطلاعات گزارش صندوق ها از بانك اطلاعات!\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟", "خطا!");
                LogManager.SaveLogEntry("Sepehr", "Cash Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return;
            }
            #endregion
            if (cboCashier.SelectedIndex != 0) ReportData = ReportData.
                Where(Data => Data.OpenerCashierIX == Convert.ToInt16(cboCashier.SelectedValue) ||
                    Data.CloserCashierIX == Convert.ToInt16(cboCashier.SelectedValue)).ToList();
            dgvData.DataSource = ReportData.ToList();
            for (Int32 i = 0; i < dgvData.Rows.Count; i++)
                dgvData.Rows[i].Cells[ColRowNumber.Index].Value = i + 1;
        }
        #endregion

        #region btnPrint_Click
        private void btnPrint_Click(object sender, EventArgs e)
        {
            new Negar.GridPrinting.frmReportPreview(dgvData);
        }
        #endregion

        #region dgvData_CellMouseClick
        private void dgvData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dgvData.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                cmsdgvData.Popup(MousePosition);
            }
        }
        #endregion

        #region dgvData_CellFormatting
        private void dgvData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == ColRemainValue.Index && e.RowIndex >= 0 &&
                dgvData[ColCashStatus.Index, e.RowIndex].Value.ToString() == "بسته")
                try
                {
                    e.Value = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells[ColSupplyBegin.Index].Value) +
                        Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells[ColStatutorySypply.Index].Value) -
                        Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells[ColSupplyEnd.Index].Value);
                }
                catch { e.Value = 0; }
        }
        #endregion

        #region btnCashInOutReport_Click
        private void btnCashInOutReport_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedCells.Count == 0) return;
            if (((VW_SelectCashesReport)dgvData.Rows[dgvData.SelectedCells[0].RowIndex].DataBoundItem).CashLogID == null)
            {
                PMBox.Show("صندوق انتخاب شده هنوز باز نشده تا ورود و خروج پولی داشته باشد!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            new frmCashInOutReport(Convert.ToInt32(
                ((VW_SelectCashesReport)dgvData.Rows[dgvData.SelectedCells[0].RowIndex].DataBoundItem).CashLogID));
            BringToFront();
            Focus();
        }
        #endregion

        #region Form Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            Dispose();
            GC.Collect();
            Cursor.Current = Cursors.Default;
        }
        #endregion

        #endregion

        #region Methods

        #region static Boolean ReadCurrentUserPermissions()
        /// <summary>
        /// تابع بررسی سطوح دسترسی فرم
        /// </summary>
        /// <returns>صحت خواندن اطلاعات</returns>
        private static Boolean ReadCurrentUserPermissions()
        {
            #region Account Access (5620)
            // مدیریت حساب مراجعات بیماران
            if (SecurityManager.GetCurrentUserPermission(5620) == false)
            {
                PMBox.Show("كاربر جاری دسترسی به حساب بیماران تصویربرداری را ندارد!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            #region Child Permissions

            #endregion

            #endregion
            return true;
        }
        #endregion

        #region Boolean FillCashes()
        /// <summary>
        /// تابع خواندن اطلاعات جدول از بانك
        /// </summary>
        private Boolean FillCashes()
        {
            try
            {
                cboCash.DataSource = DBLayerIMS.Cash.CashFullList.
                    Where(Data => Data.IsActive == true).ToList();
            }
            #region Catch
            catch (Exception Ex)
            {
                PMBox.Show("خطا در خواندن اطلاعات صندوق ها از بانك اطلاعات!\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟", "خطا!");
                LogManager.SaveLogEntry("Sepehr", "Cash Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion
            if (cboCash.Items.Count == 0)
            {
                PMBox.Show("صندوق فعالی برای گزارش گیری صندوق ها تعریف نشده است!", "عدم وجود صندوق!",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            return true;
        }
        #endregion

        #endregion

    }
}