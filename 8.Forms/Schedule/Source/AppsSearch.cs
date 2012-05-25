#region using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Negar;
using Negar.PersianCalendar.Utilities;
using DevComponents.DotNetBar;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Forms.Schedules.Properties;

#endregion

namespace Sepehr.Forms.Schedules
{
    /// <summary>
    /// فرم جستجوی نوبت های برنامه های نوبت دهی
    /// </summary>
    internal partial class frmAppsSearch : Form
    {

        #region Fields & Properties

        #region List<SearchResultData> _SearchAppsStatusResult
        /// <summary>
        /// لیست برنامه های ثبت شده برای بیماران
        /// </summary>
        private List<SearchResultData> _SearchAppsStatusResult;
        #endregion

        #region public SearchResultData ReturnKey
        /// <summary>
        /// اطلاعات برنامه یافت شده و روز مورد نظر
        /// </summary>
        public SearchResultData ReturnData { get; set; }
        #endregion

        #region Int32 _SearchFrom
        private Int32 _SearchFrom;
        #endregion

        #region Int32 _SearchTo
        private Int32 _SearchTo;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmAppsSearch()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("Fa-Ir");
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            if (!FillApplicationsComboBox() || !ReadFormCurrentUserSettings()) { Close(); return; }
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            if (!ReadFormCurrentUserSettings()) { Close(); return; }
            SetControlsToolTipTexts();
        }
        #endregion

        #region txtSearchFrom_ButtonCustomClick
        private void txtSearchFrom_ButtonCustomClick(object sender, EventArgs e)
        {
            frmChangeDate MyForm = new frmChangeDate();
            MyForm.ShowDialog();
            if (MyForm.DialogResult == DialogResult.OK)
            {
                if (MyForm.FormDatePicker.SelectedDateTime.Value.Date > DateTime.Now.Date)
                {
                    PMBox.Show("تاریخ انتخاب شده از تاریخ امروز بزرگتر است! لطفاً تاریخ كوچكتری برای این فیلد انتخاب نمایید.",
                        "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MyForm.Dispose();
                    return;
                }
                TimeSpan Difference = DateTime.Now.Date.Subtract(MyForm.FormDatePicker.SelectedDateTime.Value.Date);
                txtSearchFrom.Value = Difference.Days;
            }
            MyForm.Dispose();
        }
        #endregion

        #region txtSearchTo_ButtonCustomClick
        private void txtSearchTo_ButtonCustomClick(object sender, EventArgs e)
        {
            frmChangeDate MyForm = new frmChangeDate();
            MyForm.ShowDialog();
            if (MyForm.DialogResult == DialogResult.OK)
            {
                if (MyForm.FormDatePicker.SelectedDateTime.Value.Date < DateTime.Now.Date)
                {
                    PMBox.Show("تاریخ انتخاب شده از تاریخ امروز كوچكتر است! لطفاً تاریخ بزرگتری برای این فیلد انتخاب نمایید.",
                        "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MyForm.Dispose();
                    return;
                }
                TimeSpan Difference = MyForm.FormDatePicker.SelectedDateTime.Value.Date.Subtract(DateTime.Now.Date);
                txtSearchTo.Value = Difference.Days;
            }
            MyForm.Dispose();
        }
        #endregion

        #region btnSearch_Click
        /// <summary>
        /// دكمه ی آغاز روال جستجوی در برنامه های نوبت دهی
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            foreach (Control ctrl in MainPanel.Controls)
                if (ctrl.Name != "ProgressBarSearch") ctrl.Enabled = false;
            ProgressBarSearch.Visible = true;
            ProgressBarSearch.ProgressType = eProgressItemType.Marquee;
            ProgressBarSearch.ColorTable = eProgressBarItemColor.Error;
            #region Find Selected Application ID
            Int16? AppID = null;
            if (cboSchedulesPrograms.SelectedIndex != 0)
                AppID = Convert.ToInt16(cboSchedulesPrograms.SelectedValue);
            #endregion
            _SearchFrom = txtSearchFrom.Value;
            _SearchTo = txtSearchTo.Value;
            BWFormThread.RunWorkerAsync(AppID);
        }
        #endregion

        #region BWFormThread_DoWork
        private void BWFormThread_DoWork(object sender, DoWorkEventArgs e)
        {
            Int16? AppID = null;
            if (e.Argument != null) AppID = Convert.ToInt16(e.Argument);
            if (!SearchApplications(AppID))
            { BWFormThread.CancelAsync(); e.Cancel = true; return; }
        }
        #endregion

        #region BWFormThread_RunWorkerCompleted
        private void BWFormThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            { ProgressBarSearch.Value = 0; ProgressBarSearch.Text = "خطا در جستجو"; DialogResult = DialogResult.Cancel; }
            else
            {
                ProgressBarSearch.ProgressType = eProgressItemType.Standard;
                ProgressBarSearch.ColorTable = eProgressBarItemColor.Paused;
                ProgressBarSearch.Value = 2;
                ProgressBarSearch.Text = "اتمام جستجو";
                foreach (Control ctrl in MainPanel.Controls) if (ctrl.Name != "ProgressBarSearch") ctrl.Enabled = true;
                Cursor = DefaultCursor;
                dgvData.DataSource = _SearchAppsStatusResult;
                if (dgvData.Rows.Count == 0)
                {
                    PMBox.Show("برنامه ی نوبت دهی در این فاصله تعریف نشده است!", "هشدار!",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboSchedulesPrograms.Focus();
                }
                else dgvData.Focus();
            }
        }
        #endregion

        #region dgvSearchResult_CellMouseDoubleClick
        private void dgvSearchResult_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 && e.ColumnIndex < 0) return;
            ReturnData = (SearchResultData)dgvData.SelectedRows[0].DataBoundItem;
            DialogResult = DialogResult.OK;
        }
        #endregion

        #region dgvData_PreviewKeyDown
        private void dgvData_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter && dgvData.SelectedRows.Count != 0) btnSelect_Click(sender, new EventArgs());
        }
        #endregion

        #region btnSelect_Click
        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (dgvData.Rows.Count == 0 || dgvData.SelectedRows.Count == 0) return;
            ReturnData = (SearchResultData)dgvData.SelectedRows[0].DataBoundItem;
            DialogResult = DialogResult.OK;
        }
        #endregion

        #region Form Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            if (BWFormThread.IsBusy)
            {
                PMBox.Show("امكان خروج از فرم جستجو در هنگام انجام جستجو ممكن نیست!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                return;
            }
            BWFormThread.Dispose();
            Dispose();
            GC.Collect();
        }
        #endregion

        #endregion

        #region Methods

        #region Boolean ReadFormCurrentUserSettings()
        /// <summary>
        /// اعمال تنظیمات كاربر جاری
        /// </summary>
        /// <returns></returns>
        private Boolean ReadFormCurrentUserSettings()
        {
            #region Search From & Search To Values
            String _txt205Value = String.Empty;
            // 205: روز پیش فرض بازه ی تاریخی جستجو در فرم جستجوی برنامه ها
            if (DBLayerIMS.Settings.CurrentUserSettingsFullList.Where(Data => Data.SettingIX == 205).Count() > 0 &&
                DBLayerIMS.Settings.CurrentUserSettingsFullList.Where(Data => Data.SettingIX == 205).First().Value != null)
                _txt205Value = DBLayerIMS.Settings.CurrentUserSettingsFullList.Where(Data => Data.SettingIX == 205).First().Value;
            if (!String.IsNullOrEmpty(_txt205Value))
            {
                for (Int32 i = 0; i < _txt205Value.Length; i++)
                    if (_txt205Value[i] == '-')
                    {
                        txtSearchFrom.Value = Convert.ToInt32(_txt205Value.Substring(0, i));
                        txtSearchTo.Value = Convert.ToInt32(_txt205Value.Substring(i + 1));
                        break;
                    }
            }
            #endregion
            return true;
        }
        #endregion

        #region void SetControlsToolTipTexts()
        /// <summary>
        /// تابع تنظیم متن راهنمای كنترل ها
        /// </summary>
        private void SetControlsToolTipTexts()
        {
            const String TooltipHeader = "راهنمای تنظیمات سیستم";
            const String TooltipFooter = "سیستم مدیریت تصویربرداری سپهر";

            #region btnClose
            String TooltipText = ToolTipManager.GetText("btnClose", "IMS");
            FormToolTip.SetSuperTooltip(btnClose, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnSelect
            TooltipText = ToolTipManager.GetText("btnSchSelectApp", "IMS");
            FormToolTip.SetSuperTooltip(btnSelect, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnSearch
            TooltipText = ToolTipManager.GetText("btnSchAppSearch", "IMS");
            FormToolTip.SetSuperTooltip(btnSearch, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

        }
        #endregion

        #region Boolean FillApplicationsComboBox()
        /// <summary>
        /// تابع خواندن اطلاعات برنامه های نصب شده
        /// </summary>
        private Boolean FillApplicationsComboBox()
        {
            List<SP_SelectApplicationsResult> _ApplicationsDataSource = DBLayerIMS.Schedules.SchAppList.
                    OrderBy(Data => Data.Name).ToList();
            _ApplicationsDataSource.First().Name = "(همه برنامه ها)";
            cboSchedulesPrograms.DataSource = _ApplicationsDataSource;
            cboSchedulesPrograms.DisplayMember = "Name";
            cboSchedulesPrograms.ValueMember = "ID";
            return true;
        }
        #endregion

        #region Boolean SearchApplications(Int16? AppID)
        /// <summary>
        /// تابع جستجوی اطلاعات برنامه های نوبت دهی
        /// </summary>
        private Boolean SearchApplications(Int16? AppID)
        {
            List<SP_SelectApplicationsResult> SchApps = DBLayerIMS.Schedules.SchAppList.Where(Data => Data.ID != null).ToList();
            if (AppID != null) SchApps = SchApps.Where(Data => Data.ID == AppID.Value).ToList();
            _SearchAppsStatusResult = new List<SearchResultData>();
            try
            {
                // پیمایش بین برنامه های انتخاب شده
                foreach (SP_SelectApplicationsResult app in SchApps)
                {
                    // بدست آوردن شیفت هایی از برنامه حلقه كه دارای شرایط جستجوی انتخاب شده هستند
                    List<DateTime> CurrentApplicationData =
                        DBLayerIMS.Manager.DBML.SchAppointments.Where(Data => Data.ApplicationIX == app.ID.Value &&
                            Data.OccuredDateTime.Date >= DateTime.Now.AddDays(_SearchFrom * -1).Date &&
                            Data.OccuredDateTime.Date <= DateTime.Now.AddDays(_SearchTo).Date)
                            .Select(Data => Data.OccuredDateTime.Date).Distinct().ToList();
                    foreach (DateTime TheDate in CurrentApplicationData)
                    {
                        SearchResultData TheItem = new SearchResultData();
                        TheItem.AppID = app.ID.Value;
                        TheItem.AppName = app.Name;
                        TheItem.Date = TheDate.Date;
                        PersianDate PDate = PersianDateConverter.ToPersianDate(TheDate);
                        TheItem.PDate = PDate.Year + "/" + PDate.Month + "/" + PDate.Day;
                        switch (PDate.DayOfWeek)
                        {
                            case PersianDayOfWeek.Saturday: TheItem.DayOfWeek = "شنبه"; break;
                            case PersianDayOfWeek.Sunday: TheItem.DayOfWeek = "یكشنبه"; break;
                            case PersianDayOfWeek.Monday: TheItem.DayOfWeek = "دوشنبه"; break;
                            case PersianDayOfWeek.Tuesday: TheItem.DayOfWeek = "سه شنبه"; break;
                            case PersianDayOfWeek.Wednesday: TheItem.DayOfWeek = "چهارشنبه"; break;
                            case PersianDayOfWeek.Thursday: TheItem.DayOfWeek = "پنجشنبه"; break;
                            case PersianDayOfWeek.Friday: TheItem.DayOfWeek = "جمعه"; break;
                        }
                        var AppointmentData =
                            DBLayerIMS.Manager.DBML.SchAppointments.Where(Data => Data.ApplicationIX == app.ID.Value &&
                                Data.OccuredDateTime.Date >= TheDate.Date && Data.OccuredDateTime.Date <= TheDate.Date)
                                .Select(Data => new { Data.IsActive, Data.IsAppointed }).ToList();
                        TheItem.Capacity = AppointmentData.Count();
                        TheItem.Used = AppointmentData.Where(Data => Data.IsAppointed).Count();
                        TheItem.Empty = AppointmentData.Where(Data => !Data.IsAppointed && Data.IsActive).Count();
                        TheItem.InActive = AppointmentData.Where(Data => !Data.IsActive).Count();
                        _SearchAppsStatusResult.Add(TheItem);
                    }
                }
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان جستجوی اطلاعات برنامه های نوبت دهی از بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Schedules Forms", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error); return false;
            }
            #endregion
            _SearchAppsStatusResult = _SearchAppsStatusResult.OrderBy(Data => Data.AppID).ThenBy(Data => Data.Date).ToList();
            return true;
        }
        #endregion

        #endregion

        #region class SearchResultData
        /// <summary>
        /// كلاس برای مدیریت نتیجه جستجوی اطلاعات
        /// </summary>
        internal class SearchResultData
        {
            public Int16 AppID { get; set; }
            public String AppName { get; set; }
            public String DayOfWeek { get; set; }
            public DateTime Date { get; set; }
            public String PDate { get; set; }
            public Int32 Capacity { get; set; }
            public Int32 Used { get; set; }
            public Int32 Empty { get; set; }
            public Int32 InActive { get; set; }
        }
        #endregion

    }
}