#region using
using System;
using System.ComponentModel;
using System.Windows.Forms;
using Negar;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using Sepehr.DBLayerIMS;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Settings.Schedules.Properties;
#endregion

namespace Sepehr.Settings.Schedules.Applications
{
    /// <summary>
    /// فرم مدیریت برنامه های نوبت دهی
    /// </summary>
    internal partial class frmAppsAdd : Form
    {

        #region Fields

        #region Int16? _NewAppID
        /// <summary>
        /// كلید برنامه جدید تولید شده
        /// </summary>
        private Int16? _NewAppID;
        #endregion

        #region delegate Boolean AddMethodDelegate()
        /// <summary>
        /// نماینده ای برای توابع افزودن و ویرایش برنامه
        /// </summary>
        /// <returns></returns>
        private delegate Boolean AddMethodDelegate();
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم برای تعریف برنامه جدید
        /// </summary>
        public frmAppsAdd()
        {
            Application.CurrentInputLanguage = 
                InputLanguage.FromCulture(new System.Globalization.CultureInfo("Fa-Ir"));
            InitializeComponent();
            ColBeginTime.ValueType = typeof(DateTime);
            ColEndTime.ValueType = typeof(DateTime);
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            SetControlsToolTipTexts();
            DateAppStart.SelectedDateTime = DateTime.Now;
            DateAppEnd.SelectedDateTime = DateTime.Now;
            cBoxFixApps.Checked = true;
            TimeStart1.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0);
            TimeEnd1.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 0, 0);
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

        #region Controls_Validating
        private void Controls_Validating(object sender, CancelEventArgs e)
        {
            if (sender is TextBoxX)
                ((TextBoxX)sender).Text = ((TextBoxX)sender).Text.Trim();
            if (!String.IsNullOrEmpty(txtAppName.Text.Trim()))
                FormErrorProvider.SetError(txtAppName, String.Empty);
            if (DateAppStart.SelectedDateTime.Value.Date < DateAppEnd.SelectedDateTime.Value.Date)
            {
                FormErrorProvider.SetError(DateAppStart, String.Empty);
                FormErrorProvider.SetError(DateAppEnd, String.Empty);
            }
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
            AddMethodDelegate NewMyDelegate = AddNewApplication;
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

            #region Check Application Name
            if (String.IsNullOrEmpty(txtAppName.Text))
            {
                FormErrorProvider.SetError(txtAppName, "برای برنامه حتما نامی انتخاب نمایید!");
                return;
            }
            FormErrorProvider.SetError(txtAppName, String.Empty);
            #endregion

            #region Check None-Fix Apps Selected Days
            if (cBoxNoneFixApps.Checked)
            {
                if (dgvData.Rows.Count == 0)
                {
                    const String Message = "حداقل یك روز برای برنامه هفتگی شناور باید انتخاب گردد!";
                    PMBox.Show(Message, "خطا!",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                    FormErrorProvider.SetError(cBoxDay2, Message);
                    cBoxDay2.Focus();
                    return;
                }
                FormErrorProvider.SetError(cBoxNoneFixApps, String.Empty);
            }
            #endregion

            #region Check Application Date
            if (DateAppStart.SelectedDateTime.Value.Date > DateAppEnd.SelectedDateTime.Value.Date)
            {
                const String Message = "تاریخ آغاز برنامه باید كوچكتر از تاریخ پایان برنامه باشد!";
                PMBox.Show(Message, "خطا!",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                FormErrorProvider.SetError(DateAppStart, Message);
                FormErrorProvider.SetError(DateAppEnd, Message);
                DateAppStart.Focus();
                return;
            }
            if (DateAppStart.SelectedDateTime.Value.Date < DateAppEnd.SelectedDateTime.Value.Date.AddMonths(-6))
            {
                const String Message = "بازه تعریف برنامه نمی تواند بزرگتر از شش ماه باشد!";
                PMBox.Show(Message, "خطا!",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                FormErrorProvider.SetError(DateAppStart, Message);
                FormErrorProvider.SetError(DateAppEnd, Message);
                DateAppStart.Focus();
                return;
            }
            #endregion

            #region Calculate Fix Applications
            if (cBoxFixApps.Checked)
            {
                #region @@@ Check Any Day Is Selected @@@
                Boolean IsAnyDaySelected = false;
                foreach (Control ctrl in Panel1.Controls)
                    if (ctrl.Tag != null && ctrl.Tag.ToString() == "WeekDays" && ctrl is CheckBoxX)
                        if (((CheckBoxX)ctrl).Checked) IsAnyDaySelected = true;
                if (!IsAnyDaySelected)
                {
                    PMBox.Show("حداقل یك روز برای برنامه هفتگی ثابت باید انتخاب گردد!", "خطا!",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                    FormErrorProvider.SetError(cBoxDay1, "حداقل یك روز برای برنامه هفتگی ثابت باید انتخاب گردد!");
                    cBoxDay1.Focus();
                    return;
                }
                FormErrorProvider.SetError(cBoxDay1, String.Empty);
                #endregion

                #region @@@ Check Application Time @@@
                if (TimeStart1.Value >= TimeEnd1.Value)
                {
                    PMBox.Show("ساعت آغاز باید كوچكتر از ساعت پایان برنامه باشد!", "خطا!",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                    FormErrorProvider.SetError(TimeStart1, "ساعت آغاز باید كوچكتر از ساعت پایان برنامه باشد!");
                    FormErrorProvider.SetError(TimeEnd1, "ساعت آغاز باید كوچكتر از ساعت پایان برنامه باشد!");
                    TimeStart1.Focus();
                    return;
                }
                #endregion
            }
            #endregion

            #endregion

            #region Check User Permission
            DialogResult Dr = PMBox.Show("آیا از اعمال تغییرات برای برنامه نوبت دهی جاری اطمینان دارید؟",
                "!هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Dr == DialogResult.No) return;
            #endregion

            Cursor = Cursors.WaitCursor;
            foreach (Control ctrl in FormPanel.Controls)
                if (ctrl.Tag != null && ctrl.Tag.ToString() == "ctrl") ctrl.Enabled = false;
            ProgressBar.ProgressType = eProgressItemType.Marquee;
            ProgressBar.ColorTable = eProgressBarItemColor.Normal;
            ProgressBar.Visible = true;
            BWFormThread.RunWorkerAsync(true);
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

        #region Boolean AddNewApplication()
        /// <summary>
        /// تابع افزودن یك برنامه نوبت دهی جدید به سیستم
        /// </summary>
        /// <returns>صحت انجام كار</returns>
        private Boolean AddNewApplication()
        {
            #region Insert Application
            _NewAppID = InsertSchApplication(cBoxIsActive.Checked, txtAppName.Text, cBoxFixApps.Checked,
                DateAppStart.SelectedDateTime.Value.Date, DateAppEnd.SelectedDateTime.Value.Date, txtDescription.Text);
            if (_NewAppID == null) { BWFormThread.CancelAsync(); return false; }
            #endregion

            #region Add Fix Applications Appointments
            if (cBoxFixApps.Checked)
            {

                #region Insert AppWeekPeriod Data
                foreach (Control ctrl in Panel1.Controls)
                    if (ctrl is CheckBoxX && ctrl.Tag != null && ctrl.Tag.ToString() == "WeekDays" && ((CheckBoxX)ctrl).Checked)
                        if (!DBLayerIMS.Schedules.InsertSchAppWeekPeriod(_NewAppID.Value,
                            Convert.ToByte(((CheckBoxX)ctrl).CheckValueChecked),
                            TimeStart1.Value, TimeEnd1.Value, Convert.ToInt16(txtCapacity1.Value), Convert.ToByte(txtRoundMin1.Value)))
                        {
                            DBLayerIMS.Schedules.DeleteSchApp(_NewAppID.Value);
                            BWFormThread.CancelAsync(); return false;
                        }
                #endregion

                #region Insert Appointments
                // تاریخ شروع برنامه
                DateTime DateStart = DateAppStart.SelectedDateTime.Value.Date;
                // حلقه ی اضافه كردن روز به روز نوبت های یك برنامه
                while (DateStart.Date <= DateAppEnd.SelectedDateTime.Value.Date)
                {
                    // اگر تاریخ جاری با تنظیمات فرم مطابق باشد داخل بلوك می رود
                    // یعنی مثلاً اگر روز جاری در جلقه شنبه است و كاربر روز های شنبه
                    // را انتخاب كرده فقط وارد این بخش می شود
                    if ((DateStart.DayOfWeek == DayOfWeek.Saturday && cBoxDay1.Checked) ||
                        (DateStart.DayOfWeek == DayOfWeek.Sunday && cBoxDay2.Checked) ||
                        (DateStart.DayOfWeek == DayOfWeek.Monday && cBoxDay3.Checked) ||
                        (DateStart.DayOfWeek == DayOfWeek.Tuesday && cBoxDay4.Checked) ||
                        (DateStart.DayOfWeek == DayOfWeek.Wednesday && cBoxDay5.Checked) ||
                        (DateStart.DayOfWeek == DayOfWeek.Thursday && cBoxDay6.Checked) ||
                        (DateStart.DayOfWeek == DayOfWeek.Friday && cBoxDay7.Checked))
                    {
                        // تعریف ساعت نوبت اول در روز جاری
                        DateTime Date1 = new DateTime(DateStart.Year, DateStart.Month, DateStart.Day,
                            TimeStart1.Value.Hour, TimeStart1.Value.Minute, TimeStart1.Value.Second);
                        // تعریف ساعت نوبت آخر در روز جاری
                        DateTime Date2 = new DateTime(DateStart.Year, DateStart.Month, DateStart.Day,
                            TimeEnd1.Value.Hour, TimeEnd1.Value.Minute, TimeEnd1.Value.Second);
                        // ارسال اطلاعات به روال تولید نوبت های یك روز برای یك برنامه
                        if (!DBLayerIMS.Schedules.InsertOneDayAppointments(_NewAppID.Value, Date1, Date2,
                            Convert.ToInt16(txtCapacity1.Value), Convert.ToInt16(txtRoundMin1.Value)))
                        { DBLayerIMS.Schedules.DeleteSchApp(_NewAppID.Value); BWFormThread.CancelAsync(); return false; }
                    }
                    // به روز جاری حلقه یك روز اضافه می گردد
                    DateStart = DateStart.AddDays(1);
                }
                #endregion
            }
            #endregion

            #region Add None-Fix Applications Appointments
            else // وارد كردن روز به روز  برنامه هفتگی انتخاب شده
                for (Int32 i = 0; i < dgvData.Rows.Count; i++)
                {
                    #region Insert In AppWeekPeriod Table
                    if (!DBLayerIMS.Schedules.InsertSchAppWeekPeriod(_NewAppID.Value,
                            Convert.ToByte(dgvData.Rows[i].Cells[ColDayNo.Index].Value),
                        Convert.ToDateTime(dgvData.Rows[i].Cells[ColBeginTime.Index].Value),
                        Convert.ToDateTime(dgvData.Rows[i].Cells[ColEndTime.Index].Value),
                        Convert.ToInt16(dgvData.Rows[i].Cells[ColCapacity.Index].Value),
                        Convert.ToByte(dgvData.Rows[i].Cells[ColRoundMin.Index].Value)))
                    {
                        DBLayerIMS.Schedules.DeleteSchApp(_NewAppID.Value);
                        BWFormThread.CancelAsync(); return false;
                    }
                    #endregion

                    #region AddDays Selected
                    // متغیر روزهای قابل پیمایش
                    DateTime DateStart = DateAppStart.SelectedDateTime.Value;
                    while (DateStart <= DateAppEnd.SelectedDateTime)
                    {
                        Int16 DayNo = Convert.ToInt16(DateStart.DayOfWeek);
                        if (DayNo < 6) DayNo += 2;
                        else DayNo -= 5;
                        if (Convert.ToByte(dgvData[ColDayNo.Index, i].Value) == DayNo)
                        {
                            DateTime Date1 = new DateTime(DateStart.Year, DateStart.Month, DateStart.Day,
                                Convert.ToDateTime(dgvData.Rows[i].Cells[ColBeginTime.Index].Value).Hour,
                                Convert.ToDateTime(dgvData.Rows[i].Cells[ColBeginTime.Index].Value).Minute,
                                Convert.ToDateTime(dgvData.Rows[i].Cells[ColBeginTime.Index].Value).Second);
                            DateTime Date2 = new DateTime(DateStart.Year, DateStart.Month, DateStart.Day,
                                Convert.ToDateTime(dgvData.Rows[i].Cells[ColEndTime.Index].Value).Hour,
                                Convert.ToDateTime(dgvData.Rows[i].Cells[ColEndTime.Index].Value).Minute,
                                Convert.ToDateTime(dgvData.Rows[i].Cells[ColEndTime.Index].Value).Second);
                            if (!DBLayerIMS.Schedules.InsertOneDayAppointments(_NewAppID.Value, Date1, Date2,
                            Convert.ToInt16(dgvData.Rows[i].Cells[ColCapacity.Index].Value),
                                Convert.ToByte(dgvData.Rows[i].Cells[ColRoundMin.Index].Value)))
                            { DBLayerIMS.Schedules.DeleteSchApp(_NewAppID.Value); BWFormThread.CancelAsync(); return false; }
                        }
                        DateStart = DateStart.AddDays(1);
                    }
                    #endregion
                }
            #endregion

            return true;
        }
        #endregion

        #region Int16? InsertSchApplication(...)
        /// <summary>
        /// تابعی برای ثبت برنامه نوبت دهی جدید در بانك اطلاعات
        /// </summary>
        /// <returns>كلید برنامه تولید شده یا تهی برای خطا</returns>
        private static Int16? InsertSchApplication(Boolean IsActive, String Name,
            Boolean IsFix, DateTime StartDate, DateTime EndDate, String Description)
        {
            SchApplications NewApp = new SchApplications();
            NewApp.IsActive = IsActive;
            NewApp.Name = Name.Trim().Normalize();
            NewApp.IsFixed = IsFix;
            NewApp.StartDate = StartDate;
            NewApp.EndDate = EndDate;
            NewApp.Description = Description.Trim().Normalize();
            Manager.DBML.SchApplications.InsertOnSubmit(NewApp);
            if (!Manager.Submit())
            {
                const String ErrorMessage = "امكان ثبت اطلاعات برنامه ی نوبت دهی در بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            return NewApp.ID;
        }
        #endregion

        #endregion

    }
}