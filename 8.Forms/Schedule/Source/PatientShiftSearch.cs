#region using

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using Negar;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Forms.Schedules.Properties;

#endregion

namespace Sepehr.Forms.Schedules
{
    /// <summary>
    /// فرم جستجوی بیمار نوبت داده شده
    /// </summary>
    internal partial class frmPatientShiftSearch : Form
    {

        #region Fields & Properties

        #region List<SP_SelectApplicationsResult> _ApplicationsDataSource
        /// <summary>
        /// لیست برنامه های بانك اطلاعاتی
        /// </summary>
        private List<SP_SelectApplicationsResult> _ApplicationsDataSource;
        #endregion

        #region List<SchAppointments> _Appointment
        /// <summary>
        /// لیست نوبت های ثبت شده برای بیماران
        /// </summary>
        private List<SchAppointments> _Appointment;
        #endregion

        #region public SchAppointments ReturnKey
        /// <summary>
        /// اطلاعات نوبت بيمار یافت شده
        /// </summary>
        public SchAppointments ReturnData { get; set; }
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmPatientShiftSearch()
        {
            InputLanguage.FromCulture(new System.Globalization.CultureInfo("Fa-Ir"));
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            ColDate.ShowTime = false;
            if (!FillApplicationsDataSource()) { Close(); return; }
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            StartDate.SelectedDateTime = DateTime.Now.Date.AddMonths(-1);
            EndDate.SelectedDateTime = DateTime.Now.AddMonths(1);
            SetControlsToolTipTexts();
        }
        #endregion

        #region txtClear_ButtonCustomClick
        private void txtClear_ButtonCustomClick(object sender, EventArgs e)
        {
            ((TextBoxX)sender).Text = String.Empty;
        }
        #endregion

        #region txtAge_ButtonCustomClick
        private void txtAge_ButtonCustomClick(object sender, EventArgs e)
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
                txtAge.Value = DateTime.Now.Date.Year - MyForm.FormDatePicker.SelectedDateTime.Value.Date.Year;
            }
            MyForm.Dispose();
        }
        #endregion

        #region btnSearch_Click
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            #region Validation
            if (String.IsNullOrEmpty(txtFirstName.Text.Trim()) && String.IsNullOrEmpty(txtLastName.Text.Trim()) &&
                txtAge.ValueObject == null && String.IsNullOrEmpty(txtTel.Text.Trim()))
            {
                PMBox.Show("جستجو بدون وارد كردن یك نوع فیلتر ممكن نیست!", "خطا در شروط!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLastName.Focus(); return;
            }
            #endregion
            if (!SearchPatientAppointments()) Close();
            Cursor = DefaultCursor;
        }
        #endregion

        #region dgvData_PreviewKeyDown
        private void dgvData_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter && dgvData.SelectedRows.Count != 0)
                btnSelect_Click(sender, new EventArgs());
        }
        #endregion

        #region dgvResult_CellMouseDoubleClick
        private void dgvResult_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                ReturnData = (SchAppointments)dgvData.Rows[e.RowIndex].DataBoundItem;
                DialogResult = DialogResult.OK;
            }
        }
        #endregion

        #region btnSelect_Click
        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (dgvData.Rows.Count == 0 && dgvData.SelectedRows.Count == 0) return;
            ReturnData = (SchAppointments)dgvData.SelectedRows[0].DataBoundItem;
            DialogResult = DialogResult.OK;
        }
        #endregion

        #region Form Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {

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

            #region btnSearch
            String TooltipText = ToolTipManager.GetText("btnSchPatSearch", "IMS");
            FormToolTip.SetSuperTooltip(btnSearch, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnSelect
            TooltipText = ToolTipManager.GetText("btnSchPatSearchSelect", "IMS");
            FormToolTip.SetSuperTooltip(btnSelect, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnClose
            TooltipText = ToolTipManager.GetText("btnClose", "IMS");
            FormToolTip.SetSuperTooltip(btnClose, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion
        }
        #endregion

        #region Boolean FillApplicationsDataSource()
        /// <summary>
        /// تابع خواندن اطلاعات برنامه های نصب شده
        /// </summary>
        private Boolean FillApplicationsDataSource()
        {
            try
            {
                _ApplicationsDataSource = DBLayerIMS.Manager.DBML.SP_SelectApplications().OrderBy(Data => Data.Name).ToList();
                _ApplicationsDataSource.First().Name = "(همه برنامه ها)";
                cboSchedulesPrograms.DataSource = _ApplicationsDataSource;
                cboSchedulesPrograms.DisplayMember = "Name";
                cboSchedulesPrograms.ValueMember = "ID";
                ColumnAppName.DataSource = _ApplicationsDataSource;
                ColumnAppName.DisplayMember = "Name";
                ColumnAppName.ValueMember = "ID";
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان خواندن اطلاعات برنامه های نوبت دهی از بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Schedules Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion
            return true;
        }
        #endregion

        #region Boolean SearchPatientAppointments()
        /// <summary>
        /// تابع جستجوي نوبت بيماران
        /// </summary>
        /// <returns>صحت جستجو</returns>
        private Boolean SearchPatientAppointments()
        {
            IQueryable<SchAppointments> SearchedData;

            #region Filter Data

            #region Search All Applications
            if (cboSchedulesPrograms.SelectedIndex == 0)
                SearchedData = DBLayerIMS.Manager.DBML.SchAppointments.
                    Where(Data => Data.OccuredDateTime.Date >= StartDate.SelectedDateTime.Value.Date &&
                        Data.OccuredDateTime.Date <= EndDate.SelectedDateTime.Value.Date);
            #endregion

            #region Search One Application
            else SearchedData = DBLayerIMS.Manager.DBML.SchAppointments.
                Where(Data => Data.ApplicationIX == Convert.ToInt16(cboSchedulesPrograms.SelectedValue) &&
                    Data.OccuredDateTime.Date >= StartDate.SelectedDateTime.Value.Date &&
                    Data.OccuredDateTime.Date <= EndDate.SelectedDateTime.Value.Date);
            #endregion

            // حالتی كه نام بیمار هم وارد شده
            if (!String.IsNullOrEmpty(txtFirstName.Text))
                SearchedData = SearchedData.
                    Where(Data => Data.FirstName != null && Data.FirstName.StartsWith(txtFirstName.Text.Trim()));
            // حالتی كه نام خانوادگی بیمار هم وارد شده
            if (!String.IsNullOrEmpty(txtLastName.Text))
                SearchedData = SearchedData.
                    Where(Data => Data.LastName != null && Data.LastName.StartsWith(txtLastName.Text.Trim()));
            // حالتی كه سن بیمار هم وارد شده
            if (!String.IsNullOrEmpty(txtAge.Text))
                SearchedData = SearchedData.Where(Data => Data.Age == Convert.ToByte(txtAge.Text));
            // حالتی كه شماره تلفن بیمار هم وارد شده
            if (!String.IsNullOrEmpty(txtTel.Text))
                SearchedData = SearchedData.Where(Data => (Data.TelNo1 != null && Data.TelNo1.StartsWith(txtTel.Text)) ||
                    (Data.TelNo2 != null && Data.TelNo2.StartsWith(txtTel.Text)));
            #endregion

            try { _Appointment = SearchedData.OrderBy(Data => Data.OccuredDateTime).ToList(); }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان جستجوي اطلاعات نوبت های بیماران از بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Schedules Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion
            dgvData.DataSource = _Appointment;

            #region Set Persian Date And Day Of Week Name
            for (Int32 i = 0; i < dgvData.Rows.Count; i++)
            {
                DateTime GregorianDate =
                    Convert.ToDateTime(((SchAppointments)dgvData.Rows[i].DataBoundItem).OccuredDateTime);
                switch (GregorianDate.DayOfWeek)
                {
                    case DayOfWeek.Saturday: dgvData.Rows[i].Cells["ColDay"].Value = "شنبه"; break;
                    case DayOfWeek.Sunday: dgvData.Rows[i].Cells["ColDay"].Value = "یكشنبه"; break;
                    case DayOfWeek.Monday: dgvData.Rows[i].Cells["ColDay"].Value = "دوشنبه"; break;
                    case DayOfWeek.Tuesday: dgvData.Rows[i].Cells["ColDay"].Value = "سه شنبه"; break;
                    case DayOfWeek.Wednesday: dgvData.Rows[i].Cells["ColDay"].Value = "چهارشنبه"; break;
                    case DayOfWeek.Thursday: dgvData.Rows[i].Cells["ColDay"].Value = "پنجشنبه"; break;
                    case DayOfWeek.Friday: dgvData.Rows[i].Cells["ColDay"].Value = "جمعه"; break;
                }
            }
            #endregion
            if (dgvData.Rows.Count == 0)
            {
                PMBox.Show("بیماری با اطلاعات وارد شده یافت نشد!", "هشدار!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLastName.SelectAll();
                txtLastName.Focus();
            }
            else dgvData.Focus();
            BringToFront();
            Focus();
            Activate();
            return true;
        }
        #endregion

        #endregion

    }
}