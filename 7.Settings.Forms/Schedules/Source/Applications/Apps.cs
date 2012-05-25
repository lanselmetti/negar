#region using
using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Negar;
using DevComponents.DotNetBar;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Settings.Schedules.Properties;
#endregion

namespace Sepehr.Settings.Schedules.Applications
{
    /// <summary>
    /// فرم مدیریت برنامه های نوبت دهی
    /// </summary>
    public partial class frmApps : Form
    {

        #region Fields

        #region IOrderedQueryable<SchApplications> _DataSource
        /// <summary>
        /// فیلد منبع اطلاعاتی فرم
        /// </summary>
        private IOrderedQueryable<SchApplications> _DataSource;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmApps()
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            ColStartDate.ShowTime = false;
            ColEndDate.ShowTime = false;
            if (!FillDataSource()) { Close(); return; }
            // بررسی نداشتن لایسنس نوبت دهی پیشرفته
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            dgvData.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
            dgvData.RowsDefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
            SetControlsToolTipTexts();
            cBoxWithInActives.Checked = false;
        }
        #endregion

        #region cBoxWithInActives_CheckedChanged
        private void cBoxWithInActives_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxWithInActives.Checked) dgvData.DataSource = _DataSource;
            else dgvData.DataSource = _DataSource.Where(FilteredData => FilteredData.IsActive);
        }
        #endregion

        #region btnAdd_Click
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAppsAdd MyForm = new frmAppsAdd();
            if (MyForm.DialogResult == DialogResult.OK) if (!FillDataSource()) Close();
            MyForm.Dispose();
        }
        #endregion

        #region btnHolidays_Click
        private void btnHolidays_Click(object sender, EventArgs e)
        {
            new frmHolidays();
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
                        Top + dgvData.Top +
                        dgvData.GetRowDisplayRectangle(dgvData.SelectedCells[0].RowIndex, true).Top
                        + dgvData.ColumnHeadersHeight + 25,
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
            btnEditBaseData_Click(null, null);
        }
        #endregion

        #region btnEditBaseData_Click
        private void btnEditBaseData_Click(object sender, EventArgs e)
        {
            if (dgvData.Rows.Count == 0 || dgvData.SelectedRows.Count == 0) return;
            frmAppsBaseEdit MyForm = new frmAppsBaseEdit(((SchApplications)dgvData.SelectedRows[0].DataBoundItem).ID);
            if (!FillDataSource()) { Close(); return; }
            dgvData.Refresh();
            MyForm.Dispose();
            Activate();
            Focus();
            BringToFront();
        }
        #endregion

        #region btnEditCurrentShift_Click
        private void btnEditCurrentShift_Click(object sender, EventArgs e)
        {
            if (dgvData.Rows.Count == 0 || dgvData.SelectedRows.Count == 0) return;
            frmAppsCurrentEdit MyForm = new frmAppsCurrentEdit(((SchApplications)dgvData.SelectedRows[0].DataBoundItem).ID);
            if (!FillDataSource()) { Close(); return; }
            dgvData.Refresh();
            MyForm.Dispose();
            Activate();
            Focus();
            BringToFront();
        }
        #endregion

        #region btnAddNewShifts_Click
        private void btnAddNewShifts_Click(object sender, EventArgs e)
        {
            if (dgvData.Rows.Count == 0 || dgvData.SelectedRows.Count == 0) return;
            frmAppsNewPeriods MyForm = new frmAppsNewPeriods(((SchApplications)dgvData.SelectedRows[0].DataBoundItem).ID);
            if (!FillDataSource()) { Close(); return; }
            dgvData.Refresh();
            MyForm.Dispose();
            Activate();
            Focus();
            BringToFront();
        }
        #endregion

        #region btnAddDay_Click
        private void btnAddDay_Click(object sender, EventArgs e)
        {
            // ToDo: در آینده تكمیل گردد
        }
        #endregion

        #region btnDelete_Click
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvData.Rows.Count == 0 || dgvData.SelectedRows.Count == 0) return;
            DialogResult Dr = PMBox.Show("آیا مایلید برنامه ی زیر حذف گردد:\n\"" +
                dgvData.SelectedRows[0].Cells[ColName.Index].Value + "\"\n" +
                "با حذف یك برنامه تغییرات عیناً در بانك اطلاعات اعمال می گردند و امكان بازگشت اطلاعات وجود ندارد.",
                "هشدار!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Dr != DialogResult.Yes) return;
            if (!DBLayerIMS.Schedules.DeleteSchApp(((SchApplications)dgvData.SelectedRows[0].DataBoundItem).ID) ||
                !FillDataSource()) { Close(); return; }
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

            #region cBoxWithInActives
            String TooltipText = ToolTipManager.GetText("cBoxWithInActivesApplication", "IMS");
            FormToolTip.SetSuperTooltip(cBoxWithInActives,
                new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                    Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnHelp
            TooltipText = ToolTipManager.GetText("btnHelp", "IMS");
            FormToolTip.SetSuperTooltip(btnHelp, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnClose
            TooltipText = ToolTipManager.GetText("btnClose", "IMS");
            FormToolTip.SetSuperTooltip(btnClose, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnHolidays
            TooltipText = ToolTipManager.GetText("btnSchHolidays", "IMS");
            FormToolTip.SetSuperTooltip(btnHolidays, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnAdd
            TooltipText = ToolTipManager.GetText("btnAddSchApps", "IMS");
            FormToolTip.SetSuperTooltip(btnAdd, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
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
            try { _DataSource = DBLayerIMS.Manager.DBML.SchApplications.OrderBy(Data => Data.Name); }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان خواندن اطلاعات برنامه های نوبت دهی از بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Schedules Settings",
                    Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion
            dgvData.DataSource = _DataSource.Where(Data => Data.IsActive);
            return true;
        }
        #endregion

        #endregion

    }
}