﻿#region using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Negar;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Settings.Schedules.Properties;
#endregion

namespace Sepehr.Settings.Schedules.Applications
{
    /// <summary>
    /// فرمی برای ویرایش برنامه های نوبت دهی تعریف شده جاری
    /// </summary>
    internal partial class frmAppsNewPeriods : Form
    {

        #region Fields

        #region readonly Int16 _CurrentAppID
        /// <summary>
        /// كلید برنامه جاری
        /// </summary>
        private readonly Int16 _CurrentAppID;
        #endregion

        #region SchApplications _CurrentAppDataSource
        /// <summary>
        /// منبع داده برنامه نوبت دهی جاری
        /// </summary>
        private SchApplications _CurrentAppDataSource;
        #endregion

        #region DateTime _CurrentAppStartDate
        private DateTime _CurrentAppStartDate;
        #endregion

        #region DateTime _CurrentAppEndDate
        private DateTime _CurrentAppEndDate;
        #endregion

        #region List<SchAppWeekPeriods> _AppWeekPeriod
        /// <summary>
        /// اطلاعات مربوط به وضعیت رفتاری برنامه در روزهای مختلف
        /// </summary>
        private List<SchAppWeekPeriods> _AppWeekPeriod;
        #endregion

        #region delegate Boolean AddAndEditMethodsDelegate()
        /// <summary>
        /// نماینده ای برای توابع افزودن و ویرایش برنامه
        /// </summary>
        /// <returns></returns>
        private delegate Boolean AddAndEditMethodsDelegate();
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده فرم برای ویرایش یك برنامه نوبت دهی
        /// </summary>
        public frmAppsNewPeriods(Int16 AppID)
        {
            Application.CurrentInputLanguage = 
                InputLanguage.FromCulture(new System.Globalization.CultureInfo("Fa-Ir"));
            InitializeComponent();
            ColBeginTime.ValueType = typeof(DateTime);
            ColEndTime.ValueType = typeof(DateTime);
            TimeStart1.Value = 
                new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0);
            TimeEnd1.Value = 
                new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 0, 0);
            _CurrentAppID = AppID;
            DateTime? FirstDate = DBLayerIMS.Schedules.GetSchAppFirstOrLastDateTime(_CurrentAppID, true);
            DateTime? LastDate = DBLayerIMS.Schedules.GetSchAppFirstOrLastDateTime(_CurrentAppID, false);
            if (FirstDate == null || LastDate == null) { Close(); return; }
            _CurrentAppStartDate = FirstDate.Value;
            _CurrentAppEndDate = LastDate.Value;
            if (!FillApplicationDataSource()) { Close(); return; }
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            SetControlsToolTipTexts();
            DateEditStart.SelectedDateTime = _CurrentAppEndDate.AddDays(1);
            DateEditEnd.SelectedDateTime = _CurrentAppEndDate.AddDays(1);
            TimeStart2.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0);
            TimeEnd2.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 0, 0);
            cboWeekDays.SelectedIndex = 0;
            Opacity = 1;
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

        #region txtRoundMin1_Validating
        private void txtRoundMin1_Validating(object sender, CancelEventArgs e)
        {
            Int32 SelectedValue = txtRoundMin1.Value;
            if (SelectedValue == 0) return;
            TimeSpan DateDiff = TimeEnd1.Value - TimeStart1.Value;
            Int32 ShiftPeriod = Convert.ToInt32(DateDiff.TotalMinutes) / txtCapacity1.Value;

            if (SelectedValue <= ShiftPeriod)
            {
                PMBox.Show("امكان گرد كردن به زمانی كمتر از زمان اصلی هر نوبت وجود ندارد!\n" +
                           "زمان اصلی هر نوبت: " + ShiftPeriod + " دقیقه.", "خطا!",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                return;
            }

            #region Check If Value Is Not Multiplied 5
            if (SelectedValue % 5 != 0)
            {
                PMBox.Show("گرد كردن به اعدادی غیر از ضرایب 5 ممكن نیست! لطفاً مجدداً امتحان نمایید.", "خطا!",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                return;
            }
            #endregion
        }
        #endregion

        #region txtRoundMin2_Validating
        private void txtRoundMin2_Validating(object sender, CancelEventArgs e)
        {
            Int32 SelectedValue = txtRoundMin2.Value;
            if (SelectedValue == 0) return;

            Int32 ShiftPeriod = TimeStart2.Value.Subtract(TimeEnd2.Value).Minutes / txtCapacity2.Value;
            if (SelectedValue <= ShiftPeriod)
            {
                PMBox.Show("امكان گرد كردن زمان نوبت ، به زمانی كمتر از زمان اصلی هر نوبت وجود ندارد!\n" +
                           "زمان اصلی هر نوبت: " + ShiftPeriod + " دقیقه.", "خطا!",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                return;
            }

            #region Check If Value Is Not Multiplied 5
            if (SelectedValue % 5 != 0)
            {
                PMBox.Show("گرد كردن به اعدادی غیر از ضرایب 5 ممكن نیست! لطفاً مجدداً امتحان نمایید.", "خطا!",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                return;
            }
            #endregion
        }
        #endregion

        #region cBoxFixApps_CheckedChanged
        private void cBoxFixApps_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxFixApps.Checked)
            {
                foreach (Control ctrl in Panel1.Controls) ctrl.Enabled = true;
                foreach (Control ctrl in Panel2.Controls) ctrl.Enabled = false;
            }
            else
            {
                foreach (Control ctrl in Panel1.Controls) ctrl.Enabled = false;
                foreach (Control ctrl in Panel2.Controls) ctrl.Enabled = true;
            }
        }
        #endregion

        #region dgvData_CellValidating
        private void dgvData_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex > ColDay.Index)
            {
                if (e.FormattedValue == null || String.IsNullOrEmpty(e.FormattedValue.ToString().Trim()))
                {
                    PMBox.Show("باید مقادیر كلیه ستون ها را تكمیل نمایید!", "خطا!",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                    e.Cancel = true;
                    return;
                }
                if (e.ColumnIndex <= ColEndTime.Index)
                {
                    foreach (Char Ch in e.FormattedValue.ToString().Trim())
                        if (!Char.IsDigit(Ch) && Ch != ':')
                        {
                            PMBox.Show("مقادیر وارد شده برای این ستون معتبر نمی باشد!", "خطا!",
                                       MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                            e.Cancel = true;
                            return;
                        }
                }
                else
                {
                    foreach (Char Ch in e.FormattedValue.ToString().Trim())
                        if (!Char.IsDigit(Ch))
                        {
                            PMBox.Show("مقادیر وارد شده برای این ستون معتبر نمی باشد!", "خطا!",
                                       MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                            e.Cancel = true;
                            return;
                        }
                }
            }
        }
        #endregion

        #region dgvData_DataError
        private void dgvData_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            PMBox.Show("مقدار وارد شده برای ستون مورد نظر صحیح نمی باشد!", "خطا!",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            e.ThrowException = false;
        }
        #endregion

        #region btnAddNewDay_Click
        private void btnAddNewDay_Click(object sender, EventArgs e)
        {
            #region  @@@ Check Application Time @@@
            if (TimeStart2.Value >= TimeEnd2.Value)
            {
                PMBox.Show("ساعت آغاز باید كوچكتر از ساعت پایان برنامه باشد!", "خطا!",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                FormErrorProvider.SetError(TimeStart2, "ساعت آغاز باید كوچكتر از ساعت پایان برنامه باشد!");
                FormErrorProvider.SetError(TimeEnd2, "ساعت آغاز باید كوچكتر از ساعت پایان برنامه باشد!");
                TimeStart2.Focus();
                return;
            }
            #endregion

            // در صورتی كه ردیف انتخاب شده موجود باشد ، مقادیر اصلاح می گردند
            foreach (DataGridViewRow row in dgvData.Rows)
                if (Convert.ToInt32(row.Cells[0].Value) == cboWeekDays.SelectedIndex + 1)
                {
                    dgvData.Rows[row.Index].SetValues(cboWeekDays.SelectedIndex + 1, cboWeekDays.SelectedItem.ToString(),
                        TimeStart2.Value, TimeEnd2.Value, txtCapacity2.Text, txtRoundMin2.Text);
                    return;
                }
            dgvData.Rows.Add(cboWeekDays.SelectedIndex + 1, cboWeekDays.SelectedItem.ToString(),
                TimeStart2.Value, TimeEnd2.Value, txtCapacity2.Text, txtRoundMin2.Text);
        }
        #endregion

        #region BWFormThread_DoWork
        private void BWFormThread_DoWork(object sender, DoWorkEventArgs e)
        {
            AddAndEditMethodsDelegate NewMyDelegate = EditCurrentApplication;
            NewMyDelegate.Invoke();
        }
        #endregion

        #region BWFormThread_RunWorkerCompleted
        private void BWFormThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Cursor = DefaultCursor;
            if (e.Cancelled) DialogResult = DialogResult.Cancel;
            else DialogResult = DialogResult.OK;
        }
        #endregion

        #region btnSave_Click
        private void btnSave_Click(object sender, EventArgs e)
        {
            #region Validations

            #region Check Application Edit Date Comparison
            if (DateEditStart.SelectedDateTime.Value.Date > DateEditEnd.SelectedDateTime.Value.Date)
            {
                const String Message = "تاریخ آغاز ویرایش برنامه باید كوچكتر از تاریخ پایان ویرایش باشد!";
                PMBox.Show(Message, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FormErrorProvider.SetError(DateEditStart, Message);
                FormErrorProvider.SetError(DateEditEnd, Message);
                DateEditStart.Focus();
                return;
            }
            FormErrorProvider.SetError(DateEditStart, String.Empty);
            FormErrorProvider.SetError(DateEditEnd, String.Empty);
            #endregion

            #region Check Edit Period With Old Period
            // بررسی اینكه تاریخ آغاز و پایان تنظیمات جدید خارج از تاریخ آغاز و پایان جاری باشد
            // در غیر این صورت باید از فرم دیگری استفاده شود
            if (DateEditStart.SelectedDateTime.Value.Date >= _CurrentAppStartDate.Date &&
                DateEditStart.SelectedDateTime.Value.Date <= _CurrentAppEndDate.Date)
            {
                PMBox.Show("تاریخ آغاز شیفت های جدید ، بین شیفت های تعریف شده قبلی در برنامه نوبت دهی جاری می باشد!\n" +
                    "این تاریخ را اصلاح نمایید.\nبرای ویرایش شبفت های قبلی برنامه جاری باید از فرم دیگری استفاده نمایید.",
                    "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                DateEditStart.Focus();
                return;
            }
            if (DateEditEnd.SelectedDateTime.Value.Date >= _CurrentAppStartDate.Date &&
                DateEditEnd.SelectedDateTime.Value.Date <= _CurrentAppEndDate.Date)
            {
                PMBox.Show("تاریخ پایان شیفت های جدید ، بین شیفت های تعریف شده قبلی در برنامه نوبت دهی جاری می باشد!\n" +
                    "این تاریخ را اصلاح نمایید.\nبرای ویرایش شبفت های قبلی برنامه جاری باید از فرم دیگری استفاده نمایید.",
                    "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                DateEditEnd.Focus();
                return;
            }
            if (DateEditStart.SelectedDateTime.Value.Date <= _CurrentAppStartDate.Date &&
                DateEditEnd.SelectedDateTime.Value.Date >= _CurrentAppEndDate.Date)
            {
                PMBox.Show("بازه شیفت های قدیم تعریف شده در برنامه نوبت دهی ، بین شیفت های تعریف شده جدید می باشد!\n" +
                    "این تاریخ را اصلاح نمایید.\nبرای ویرایش شبفت های قبلی برنامه جاری باید از فرم دیگری استفاده نمایید.",
                    "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                DateEditStart.Focus();
                return;
            }
            #endregion

            #region Check Fix Applications Data
            if (cBoxFixApps.Checked)
            {
                if (TimeStart1.Value >= TimeEnd1.Value)
                {
                    PMBox.Show("ساعت آغاز باید كوچكتر از ساعت پایان برنامه باشد!", "خطا!",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                    FormErrorProvider.SetError(TimeStart1, "ساعت آغاز باید كوچكتر از ساعت پایان برنامه باشد!");
                    FormErrorProvider.SetError(TimeEnd1, "ساعت آغاز باید كوچكتر از ساعت پایان برنامه باشد!");
                    TimeStart1.Focus();
                    return;
                }
                FormErrorProvider.SetError(TimeStart1, String.Empty);
                FormErrorProvider.SetError(TimeEnd1, String.Empty);
            }
            #endregion

            #region Check None-Fix Apps Selected Days
            if (cBoxNoneFixApps.Checked)
            {
                if (dgvData.Rows.Count == 0)
                {
                    const String Message = "حداقل یك روز برای برنامه هفتگی شناور باید انتخاب گردد!";
                    PMBox.Show(Message, "خطا!",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                    FormErrorProvider.SetError(cboWeekDays, Message);
                    cBoxDay2.Focus();
                    return;
                }
                FormErrorProvider.SetError(cboWeekDays, String.Empty);
            }
            #endregion

            #endregion

            #region Edit Current Application
            Cursor = Cursors.WaitCursor;
            foreach (Control ctrl in FormPanel.Controls)
                if (ctrl.Tag != null && ctrl.Tag.ToString() == "ctrl") ctrl.Enabled = false;
            ProgressBar.ProgressType = eProgressItemType.Marquee;
            ProgressBar.ColorTable = eProgressBarItemColor.Normal;
            ProgressBar.Visible = true;
            BWFormThread.RunWorkerAsync();
            #endregion
        }
        #endregion

        #region Form_Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            if (BWFormThread.IsBusy) { e.Cancel = true; return; }
            if (DialogResult == DialogResult.Cancel)
            {
                DialogResult Dr = PMBox.Show("آیا مایلید بدون ذخیره سازی اطلاعات ، فرم بسته شود؟", "!هشدار",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
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

            #region btnCancel
            TooltipText = ToolTipManager.GetText("btnCancel_NoApply", "IMS");
            FormToolTip.SetSuperTooltip(btnCancel, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnAccept
            TooltipText = ToolTipManager.GetText("btnAccept", "IMS");
            FormToolTip.SetSuperTooltip(btnAccept, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

        }
        #endregion

        #region Boolean FillApplicationDataSource()
        /// <summary>
        /// تابع خواندن اطلاعات برنامه نوبت دهی از بانك
        /// </summary>
        private Boolean FillApplicationDataSource()
        {
            _CurrentAppDataSource = DBLayerIMS.Schedules.GetSchAppData(_CurrentAppID);
            if (_CurrentAppDataSource == null) return false;
            txtAppName.Text = _CurrentAppDataSource.Name;
            DateEditStart.SelectedDateTime = _CurrentAppDataSource.StartDate;
            DateEditEnd.SelectedDateTime = _CurrentAppDataSource.EndDate;

            #region Set Fix Applications Setting
            if (_CurrentAppDataSource.IsFixed)
            {
                cBoxFixApps.Checked = true;
                _AppWeekPeriod = DBLayerIMS.Schedules.GetSchAppWeekPeriodData(_CurrentAppID);
                if (_AppWeekPeriod == null) return false;
                #region Fill Selected Days In Check Boxes
                foreach (SchAppWeekPeriods Period in _AppWeekPeriod)
                {
                    switch (Period.DayNo)
                    {
                        case 1: cBoxDay1.Checked = true; break;
                        case 2: cBoxDay2.Checked = true; break;
                        case 3: cBoxDay3.Checked = true; break;
                        case 4: cBoxDay4.Checked = true; break;
                        case 5: cBoxDay5.Checked = true; break;
                        case 6: cBoxDay6.Checked = true; break;
                        case 7: cBoxDay7.Checked = true; break;
                    }
                }
                #endregion
                TimeStart1.Value = _AppWeekPeriod.First().BeginTime;
                TimeEnd1.Value = _AppWeekPeriod.First().EndTime;
                txtCapacity1.Value = _AppWeekPeriod.First().Capacity;
                txtRoundMin1.Value = _AppWeekPeriod.First().RoundingMinute;
            }
            #endregion

            #region Set None Fix Applications Setting
            else
            {
                cBoxNoneFixApps.Checked = true;
                _AppWeekPeriod = DBLayerIMS.Schedules.GetSchAppWeekPeriodData(_CurrentAppID);
                if (_AppWeekPeriod == null) return false;
                #region Add Selected Days In DataGridView
                foreach (SchAppWeekPeriods Period in _AppWeekPeriod)
                {
                    String DayName = String.Empty;
                    switch (Period.DayNo)
                    {
                        case 1: DayName = "شنبه"; break;
                        case 2: DayName = "یكشنبه"; break;
                        case 3: DayName = "دوشنبه"; break;
                        case 4: DayName = "سه شنبه"; break;
                        case 5: DayName = "جهارشنبه"; break;
                        case 6: DayName = "پنجشنبه"; break;
                        case 7: DayName = "جمعه"; break;
                    }
                    dgvData.Rows.Add(Period.DayNo, DayName, Period.BeginTime, Period.EndTime, Period.Capacity, Period.RoundingMinute);
                }
                #endregion
            }
            #endregion
            return true;
        }
        #endregion

        #region Boolean EditCurrentApplication()
        /// <summary>
        /// تابع ویرایش برنامه نوبت دهی 
        /// </summary>
        /// <returns>صحت ویرایش اطلاعات</returns>
        private Boolean EditCurrentApplication()
        {
            #region Delete Old App Week Periods
            DBLayerIMS.Manager.DBML.SchAppWeekPeriods.DeleteAllOnSubmit(
                    DBLayerIMS.Manager.DBML.SchAppWeekPeriods.Where(Data => Data.ApplicationIX == _CurrentAppID));
            if (!DBLayerIMS.Manager.Submit())
            {
                const String ErrorMessage = "امكان ثبت اطلاعات ویرایش  برنامه ی نوبت دهی در بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            #endregion

            #region Calculate Fix Applications
            if (cBoxFixApps.Checked)
            {
                #region Insert AppWeekPeriod Data
                foreach (Control ctrl in Panel1.Controls)
                    if (ctrl is CheckBoxX && ctrl.Tag != null && ctrl.Tag.ToString() == "WeekDays" && ((CheckBoxX)ctrl).Checked)
                        if (!DBLayerIMS.Schedules.InsertSchAppWeekPeriod(
                            _CurrentAppID, Convert.ToByte(((CheckBoxX)ctrl).CheckValueChecked),
                            TimeStart1.Value, TimeEnd1.Value,
                            Convert.ToInt16(txtCapacity1.Value), Convert.ToByte(txtRoundMin1.Value))) return false;
                #endregion

                #region Insert Data
                // تاریخ شروع برنامه
                DateTime DateStart = DateEditStart.SelectedDateTime.Value.Date;
                // حلقه ی اضافه كردن روز به روز نوبت های یك برنامه
                while (DateStart <= DateEditEnd.SelectedDateTime.Value.Date)
                {
                    // اگر تاریخ جاری با تنظیمات فرم مطابق باشد داخل بلوك می رود
                    if ((DateStart.DayOfWeek == DayOfWeek.Saturday && cBoxDay1.Checked) ||
                        (DateStart.DayOfWeek == DayOfWeek.Sunday && cBoxDay2.Checked) ||
                        (DateStart.DayOfWeek == DayOfWeek.Monday && cBoxDay3.Checked) ||
                        (DateStart.DayOfWeek == DayOfWeek.Tuesday && cBoxDay4.Checked) ||
                        (DateStart.DayOfWeek == DayOfWeek.Wednesday && cBoxDay5.Checked) ||
                        (DateStart.DayOfWeek == DayOfWeek.Thursday && cBoxDay6.Checked) ||
                        (DateStart.DayOfWeek == DayOfWeek.Friday && cBoxDay7.Checked))
                    {
                        // ایجاد ساعت نوبت اول در روز جاری
                        DateTime Date1 = new DateTime(DateStart.Year, DateStart.Month, DateStart.Day,
                            TimeStart1.Value.Hour, TimeStart1.Value.Minute, TimeStart1.Value.Second);
                        // ایجاد ساعت نوبت آخر در روز جاری
                        DateTime Date2 = new DateTime(DateStart.Year, DateStart.Month, DateStart.Day,
                            TimeEnd1.Value.Hour, TimeEnd1.Value.Minute, TimeEnd1.Value.Second);
                        // ارسال اطلاعات به روال تولید نوبت های یك روز برای یك برنامه
                        if (!DBLayerIMS.Schedules.InsertOneDayAppointments(_CurrentAppID, Date1, Date2,
                            Convert.ToInt16(txtCapacity1.Value), Convert.ToByte(txtRoundMin1.Value))) return false;
                    }
                    // به روز جاری حلقه یك روز اضافه می گردد
                    DateStart = DateStart.AddDays(1);
                }
                #endregion
            }
            #endregion

            #region Calculate None-Fix Applications
            else // وارد كردن روز به روز برنامه هفتگی انتخاب شده
                for (Int32 i = 0; i < dgvData.Rows.Count; i++)
                {
                    #region Insert In AppWeekPeriod Table
                    if (!DBLayerIMS.Schedules.InsertSchAppWeekPeriod(_CurrentAppID, Convert.ToByte(dgvData[ColDayNo.Index, i].Value),
                        Convert.ToDateTime(dgvData[ColBeginTime.Index, i].Value),
                        Convert.ToDateTime(dgvData[ColEndTime.Index, i].Value),
                        Convert.ToInt16(dgvData[ColCapacity.Index, i].Value),
                        Convert.ToByte(dgvData[ColRoundMin.Index, i].Value))) return false;
                    #endregion

                    #region Add Selected Days
                    // متغیر روزهای قابل پیمایش
                    DateTime DateStart = DateEditStart.SelectedDateTime.Value.Date;
                    while (DateStart <= DateEditEnd.SelectedDateTime.Value.Date)
                    {
                        Int16 DayNo = Convert.ToInt16(DateStart.DayOfWeek);
                        if (DayNo < 6) DayNo += 2;
                        else DayNo -= 5;
                        if (Convert.ToByte(dgvData[ColDayNo.Index, i].Value) == DayNo)
                        {
                            DateTime Date1 = new DateTime(DateStart.Year, DateStart.Month, DateStart.Day,
                                Convert.ToDateTime(dgvData[ColBeginTime.Index, i].Value).Hour,
                                Convert.ToDateTime(dgvData[ColBeginTime.Index, i].Value).Minute,
                                Convert.ToDateTime(dgvData[ColBeginTime.Index, i].Value).Second);
                            DateTime Date2 = new DateTime(DateStart.Year, DateStart.Month, DateStart.Day,
                                Convert.ToDateTime(dgvData[ColEndTime.Index, i].Value).Hour,
                                Convert.ToDateTime(dgvData[ColEndTime.Index, i].Value).Minute,
                                Convert.ToDateTime(dgvData[ColEndTime.Index, i].Value).Second);
                            DBLayerIMS.Schedules.InsertOneDayAppointments(_CurrentAppID, Date1, Date2,
                                Convert.ToInt16(dgvData[ColCapacity.Index, i].Value),
                                Convert.ToByte(dgvData[ColRoundMin.Index, i].Value));
                        }
                        DateStart = DateStart.AddDays(1);
                    }
                    #endregion
                }
            #endregion

            return true;
        }
        #endregion

        #endregion

    }
}