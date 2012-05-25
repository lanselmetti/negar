#region using
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Negar;
using Negar.PersianCalendar.Utilities;
using DevComponents.DotNetBar;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Settings.Schedules.Properties;
#endregion

namespace Sepehr.Settings.Schedules.Applications
{
    /// <summary>
    /// فرم مدیریت روزهای تعطیل برنامه های نوبت دهی
    /// </summary>
    internal partial class frmHolidays : Form
    {

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmHolidays()
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            ColDate.ShowTime = false;
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

        #region btnAdd_Click
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmHolidaysAdd MyForm = new frmHolidaysAdd();
            if (MyForm.DialogResult == DialogResult.OK) { if (!FillDataSource()) Close(); return; }
            MyForm.Dispose();
        }
        #endregion

        #region dgvData_PreviewKeyDown
        private void dgvData_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Apps && dgvData.SelectedCells.Count != 0)
                dgvData_CellMouseClick(1, new DataGridViewCellMouseEventArgs
                    (0, dgvData.SelectedCells[0].RowIndex, Left + Width - 150,
                    dgvData.GetRowDisplayRectangle(dgvData.SelectedCells[0].RowIndex, true).Top +
                    dgvData.ColumnHeadersHeight + 30 + Top,
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

        #region btnDelete_Click
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvData.Rows.Count == 0 || dgvData.SelectedRows.Count == 0) return;
            if (dgvData.SelectedRows.Count == 0)
            {
                DataGridViewRow row = dgvData.SelectedRows[0];
                PersianDate SelectedPDate = PersianDateConverter.ToPersianDate(Convert.ToDateTime(row.Cells[ColDate.Index].Value));
                DialogResult Dr = PMBox.Show("آیا مایلید روز تعطیل زیر حذف گردد:\n\"برنامه ی: " +
                    row.Cells[ColApplicationName.Name].Value + " - روز: " +
                    SelectedPDate.Year + "/" + SelectedPDate.Month + "/" + SelectedPDate.Day + "\"",
                    "هشدار!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (Dr != DialogResult.Yes) return;
                DBLayerIMS.Manager.DBML.SchHolidays.DeleteAllOnSubmit(DBLayerIMS.Manager.DBML.SchHolidays.
                    Where(Data => Data.ApplicationIX == Convert.ToInt16(row.Cells[ColID.Index].Value) &&
                        Data.HolidayDate.Date == Convert.ToDateTime(row.Cells[ColDate.Index].Value).Date));
                if (!DBLayerIMS.Manager.Submit())
                {
                    PMBox.Show("امكان حذف روز تعطیل انتخاب شده وجود ندارد! موارد زیر را بررسی نمایید:\n" +
                        "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟", "خطا!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                }
            }
            else
            {
                DialogResult Dr = PMBox.Show("آیا مایلید ایام تعطیل انتخاب شده حذف گردد؟",
                    "هشدار!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (Dr != DialogResult.Yes) return;
                foreach (DataGridViewRow row in dgvData.SelectedRows)
                {
                    DBLayerIMS.Manager.DBML.SchHolidays.DeleteAllOnSubmit(DBLayerIMS.Manager.DBML.SchHolidays.
                        Where(Data => Data.ApplicationIX == Convert.ToInt16(row.Cells[ColID.Index].Value) &&
                            Data.HolidayDate == Convert.ToDateTime(row.Cells[ColDate.Index].Value)));
                    if (!DBLayerIMS.Manager.Submit())
                    {
                        PMBox.Show("امكان حذف روز تعطیل انتخاب شده وجود ندارد! موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟", "خطا!",
                            MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                    }
                }
            }
            if (!FillDataSource()) { Close(); return; }
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

            #region btnCancel
            TooltipText = ToolTipManager.GetText("btnClose", "IMS");
            FormToolTip.SetSuperTooltip(btnCancel, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnAddHoliday
            TooltipText = ToolTipManager.GetText("btnAddSchHoliday", "IMS");
            FormToolTip.SetSuperTooltip(btnAdd, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnDelete
            TooltipText = ToolTipManager.GetText("btnDelete", "IMS");
            FormToolTip.SetSuperTooltip(btnDelete, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
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
            DBLayerIMS.Schedules.SchAppList = null;
            List<SP_SelectApplicationsResult> SchedulesApps = DBLayerIMS.Schedules.SchAppList;
            if (SchedulesApps == null) return false;
            if (SchedulesApps.Count == 0)
            {
                PMBox.Show("هیچ برنامه ای برای تعریف ایام تعطیل تعریف نشده است!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            try
            {
                dgvData.DataSource = DBLayerIMS.Manager.DBML.SchHolidays.
                    Select(Data => new { Data.ApplicationIX, Data.SchApplications.Name, Data.HolidayDate }).
                    OrderBy(Data => Data.ApplicationIX).ToList();
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان خواندن اطلاعات ایام تعطیل ثبت شده از بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Schedules Settings",
                    Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion
            return true;
        }
        #endregion

        #endregion

    }
}