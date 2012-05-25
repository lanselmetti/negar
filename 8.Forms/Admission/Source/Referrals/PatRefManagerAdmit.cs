#region using

using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Negar;
using Negar.DBLayerPMS.DataLayer;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Forms.Admission.Classes;
using Sepehr.Forms.Admission.Patients;

#endregion

namespace Sepehr.Forms.Admission.Referrals
{
    /// <summary>
    /// كدهای مربوط به ثبت اطلاعات بیمار یا مراجعه
    /// </summary>
    internal partial class frmPatRefManager
    {

        #region Fields
        private frmRefModalitySelection _PACSManager;
        #endregion

        #region Event Handlers

        #region btnNewPatient_Click
        /// <summary>
        /// دكمه ای برای ثبت مراجعه ی بیمار جدید
        /// </summary>
        private void btnNewPatient_Click(object sender, EventArgs e)
        {
            ManageFormState(RefFormState.AddingPatRef);
        }
        #endregion

        #region btnNewReferral_Click
        /// <summary>
        /// دكمه ای برای ثبت مراجعه جدید برای بیمار جاری
        /// </summary>
        private void btnNewReferral_Click(object sender, EventArgs e)
        {
            ManageFormState(RefFormState.AddingRef);
        }
        #endregion

        #region btnEditMode_Click
        private void btnEditMode_Click(object sender, EventArgs e)
        {
            if (CurrentFormState == RefFormState.Viewing) ManageFormState(RefFormState.Editing);
            else ManageFormState(RefFormState.Viewing);
        }
        #endregion

        #region btnRefresh_Click
        /// <summary>
        /// دكمه ای برای بازخوانی اطلاعات بیمار و مراجعه جاری
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            CurrentPatientListID = CurrentPatientListID;
            if (_CurrentPatientData == null) { _IsCurrentPatModified = false; Close(); return; }
            CurrentRefID = CurrentRefID;
            if (_CurrentRefData == null) { _IsCurrentPatModified = false; Close(); return; }
        }
        #endregion

        #endregion

        #region Methods

        #region internal void AdmitNewPatRef(Int32? SchAppointmentID)
        /// <summary>
        /// روال تنظیم حالت فرم بع حالت افزودن مراجعه بیمار جدید
        /// </summary>
        /// <param name="SchAppointmentID">كلید نوبتی كه بیمار جدید جاری باید بر اساس آن تنظیم شود</param>
        /// <returns>امكان فراخوانی فرم در این حالت</returns>
        internal void AdmitNewPatRef(Int32? SchAppointmentID)
        {
            if (!_CanAddPatOrRef)
            {
                PMBox.Show("كاربر جاری دسترسی لازم برای ثبت مراجعه بیمار جدید را ندارد!", "محدودیت دسترسی!",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop); return;
            }
            // هنگامی كه كلید بیمار صفر می شود ، كلید مراجعه نیز
            // صفر شده و فرم به حالت ثبت مراجعه بیمار جدید می رود
            CurrentFormState = RefFormState.AddingPatRef;
            #region Set Sch Data
            _CurrentSchID = SchAppointmentID;
            if (_CurrentSchID != null)
            {
                try
                {
                    SchAppointments SchAppData = DBLayerIMS.Manager.DBML.SchAppointments.
                        Where(Data => Data.ID == _CurrentSchID.Value).First();
                    DBLayerIMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, SchAppData);
                    txtFirstName.Text = SchAppData.FirstName;
                    txtLastName.Text = SchAppData.LastName;
                    if (SchAppData.IsMale != null)
                    {
                        if (SchAppData.IsMale.Value) cBoxMale.Checked = true;
                        else cBoxFemale.Checked = true;
                    }
                    txtAgeYear.ValueObject = (Int32?)SchAppData.Age;
                    txtTel1.Text = SchAppData.TelNo1;
                    txtTel2.Text = SchAppData.TelNo2;
                    // اعمال تنظیم برابر قراردادن تاریخ و ساعت مراجعه با نوبت در هنگام ثبت مراجعه از یك نوبت
                    List<UsersSetting> Setting203 =
                        DBLayerIMS.Settings.CurrentUserSettingsFullList.Where(Data => Data.SettingIX == 203).ToList();
                    if (Setting203.Count != 0 && Setting203.First().Boolean != null && Setting203.First().Boolean.Value)
                    {
                        DateReferral.SelectedDateTime = SchAppData.OccuredDateTime;
                        TimeReferral.Value = SchAppData.OccuredDateTime;
                    }
                    _IsCurrentPatModified = true;
                }
                #region Catch
                catch (Exception Ex)
                {
                    const String ErrorMessage = "امكان خواندن اطلاعات نوبت بیمار از بانك اطلاعات ممكن نیست.\n" +
                        "موارد زیر را بررسی نمایید:\n" +
                        "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogManager.SaveLogEntry("Sepehr", "Admission Forms", Ex.Message + "\n" +
                        Ex.StackTrace, EventLogEntryType.Error);
                }
                #endregion
            }
            #endregion
            ShowDialog();
        }
        #endregion

        #region internal void AdmitNewRef(Int32 PatID, Int32? SchAppointmentID)
        /// <summary>
        /// روال تنظیم حالت فرم به حالت افزودن مراجعه جدید برای یك بیمار
        /// </summary>
        /// <param name="PatID">كلید بیماری كه باید برای آن مراجعه جدید ثبت شود</param>
        /// <param name="SchAppointmentID">كلید نوبتی كه بیمار جدید جاری باید بر اساس آن تنظیم شود</param>
        /// <returns>امكان فراخوانی فرم در این حالت</returns>
        internal void AdmitNewRef(Int32 PatID, Int32? SchAppointmentID)
        {
            if (!_CanAddPatOrRef)
            {
                PMBox.Show("كاربر جاری دسترسی لازم برای ثبت مراجعه جدید برای بیمار را ندارد!", "محدودیت دسترسی!",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop); return;
            }
            if (!_CanAddMultipleRefs)
            {
                List<Int32> PatRefList = DBLayerIMS.Referrals.GetPatRefIDListByPatID(PatID);
                if (PatRefList == null) return;
                if (PatRefList.Count >= 1)
                {
                    PMBox.Show("كاربر جاری دسترسی لازم برای ثبت چند مراجعه برای یك بیمار را ندارد!",
                        "محدودیت دسترسی!", MessageBoxButtons.OK, MessageBoxIcon.Stop); return;
                }
            }
            CurrentPatientListID = PatID;
            if (IsDisposed) return;
            CurrentFormState = RefFormState.AddingRef;
            #region Set Sch Data
            _CurrentSchID = SchAppointmentID;
            if (_CurrentSchID != null)
            {
                // اعمال تنظیم برابر قراردادن تاریخ و ساعت مراجعه با نوبت در هنگام ثبت مراجعه از یك نوبت
                List<UsersSetting> Setting203 =
                    DBLayerIMS.Settings.CurrentUserSettingsFullList.Where(Data => Data.SettingIX == 203).ToList();
                if (Setting203.Count != 0 && Setting203.First().Boolean != null && Setting203.First().Boolean.Value)
                {
                    try
                    {
                        SchAppointments SchAppData = DBLayerIMS.Manager.DBML.SchAppointments.
                            Where(Data => Data.ID == _CurrentSchID.Value).First();
                        DBLayerIMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, SchAppData);
                        DateReferral.SelectedDateTime = SchAppData.OccuredDateTime;
                        TimeReferral.Value = SchAppData.OccuredDateTime;
                    }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage = "امكان خواندن اطلاعات تاریخ نوبت بیمار ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Sepehr", "Admission Forms", Ex.Message + "\n" +
                            Ex.StackTrace, EventLogEntryType.Error);
                    }
                    #endregion
                }
                _IsCurrentPatModified = true;
            }
            #endregion
            ShowDialog();
        }
        #endregion

        #region internal void ShowPatLastRef(Int32 PatID)
        /// <summary>
        /// روال تنظیم حالت فرم به نمایش آخرین مراجعه یك بیمار
        /// </summary>
        /// <param name="PatID">كلید بیماری كه باید آخرین مراجعه آن نمایش داده شود</param>
        /// <returns>امكان فراخوانی فرم در این حالت</returns>
        internal void ShowPatLastRef(Int32 PatID)
        {
            CurrentPatientListID = PatID;
            if (IsDisposed) return;
            Int32? TempRefID = DBLayerIMS.Referrals.GetPatFirstOrLastRefID(PatID, true);
            if (TempRefID == null) return;
            if (TempRefID == 0)
            {
                PMBox.Show("بیمار انتخاب شده دارای مراجعه نمی باشد!", "عدم وجود مراجعه!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            CurrentRefID = TempRefID.Value;
            // اگر امكان ویرایش آخرین مراجعه بیمار نباشد ، فرم به حالت نمایش خواهد رفت
            if (_CanEditReferral) { if (!ChangeToEditStateAfterCheckAccess()) CurrentFormState = RefFormState.Viewing; }
            else CurrentFormState = RefFormState.Viewing;
            ShowDialog();
        }
        #endregion

        #region internal void ShowRef(Int32 RefID)
        /// <summary>
        /// روال تنظیم حالت فرم به نمایش مراجعه یك بیمار
        /// </summary>
        /// <param name="RefID">كلید مراجعه بیمار</param>
        /// <returns>امكان فراخوانی فرم در این حالت</returns>
        internal void ShowRef(Int32 RefID)
        {
            Int32? PatID = DBLayerIMS.Referrals.GetPatIDByRefID(RefID);
            if (PatID == null) return;
            CurrentPatientListID = PatID.Value;
            if (IsDisposed) return;
            CurrentRefID = RefID;
            if (IsDisposed) return;
            if (_CanEditReferral) { if (!ChangeToEditStateAfterCheckAccess()) CurrentFormState = RefFormState.Viewing; }
            else CurrentFormState = RefFormState.Viewing;
            ShowDialog();
        }
        #endregion

        // =================================================

        #region Boolean ManageFormState(RefFormState FinalState)
        /// <summary>
        /// تابعی برای مدیریت تعیین رفتار در حالت مختلف
        /// </summary>
        /// <param name="FinalState">حالت نهایی بعد از اعمال تغییرات</param>
        private Boolean ManageFormState(RefFormState FinalState)
        {
            // حالت نمایش مراجعه ی یك بیمار - انتقال به حالت ویرایش
            if (CurrentFormState == RefFormState.Viewing && FinalState == RefFormState.Editing)
                return ChangeToEditStateAfterCheckAccess();
            // حالت نمایش مراجعه ی یك بیمار - انتقال به سایر حالت ها
            if (CurrentFormState == RefFormState.Viewing && FinalState != RefFormState.Editing)
                CurrentFormState = FinalState;
            // حالت افزودن بیمار جدید همراه با مراجعه یا افزودن مراجعه
            else if (CurrentFormState == RefFormState.AddingPatRef || CurrentFormState == RefFormState.AddingRef)
            {
                if (_IsCurrentPatModified)
                {
                    if (SaveCurrentPatientData()) CurrentFormState = FinalState;
                    else return false;
                }
                else
                {
                    PMBox.Show("اطلاعاتی برای ثبت بیمار و مراجعه وارد نشده است.", "خطا!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
                }
            }
            // حالت ویرایش یك بیمار - انتقال به حالت نمایش
            else if (CurrentFormState == RefFormState.Editing)
            {
                if (!SaveCurrentPatientData()) return false;
                Negar.DBLayerPMS.Patients.ChangePatLock(CurrentPatientListID, false); // آزاد كردن بیمار جاری
                DBLayerIMS.Referrals.ChangeRefLock(CurrentRefID, false); // آزاد سازی مراجعه
                CurrentFormState = FinalState;
            }
            return true;
        }
        #endregion

        #region Boolean ChangeToEditStateAfterCheckAccess()
        /// <summary>
        /// تابعی برای بررسی امكان ویرایش بیمار جاری توسط كاربر جاری
        /// </summary>
        /// <remarks>این تابع ابتدا بررسی می كند كه كاربر جاری دسترسی برای ویرایش بیمار جاری را دارد.
        /// سپس بیمار و مراجعه را قفل كرده و فرم را به حالت ویرایش می برد.</remarks>
        private Boolean ChangeToEditStateAfterCheckAccess()
        {
            if (!_CanEditReferral)
            {
                PMBox.Show("كاربر جاری دسترسی لازم برای ویرایش مراجعات بیماران را ندارد!", "محدودیت دسترسی!",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            if (!_CanEditReferralAfterPay)
            {
                try
                {
                    IQueryable<RefTransaction> TempData = DBLayerIMS.Manager.DBML.RefTransactions.
                        Where(Data => Data.ReferralIX == CurrentRefID);
                    DBLayerIMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, TempData);
                    if (TempData.Count() > 0)
                    {
                        PMBox.Show("كاربر جاری دسترسی لازم برای ویرایش مراجعات دارای تراكنش بیماران را ندارد!"
                            , "محدودیت دسترسی!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return false;
                    }
                }
                #region Catch
                catch (Exception Ex)
                {
                    LogManager.SaveLogEntry("Sepehr", "Admission Forms", Ex.Message + "\n" +
                        Ex.StackTrace, EventLogEntryType.Error);
                    return false;
                }
                #endregion
            }
            // اینجا بررسی می شود كه بیمار توسط كاربر دیگری ویرایش نگردد
            if (!Negar.DBLayerPMS.Patients.CheckPatIsLock(CurrentPatientListID)) return false;
            // اینجا بررسی می شود كه مراجعه توسط كاربر دیگری ویرایش نگردد
            if (!DBLayerIMS.Referrals.CheckRefIsLock(CurrentRefID)) return false;
            // قفل كردن بیمار جاری برای ویرایش
            Negar.DBLayerPMS.Patients.ChangePatLock(CurrentPatientListID, true);
            // قفل كردن مراجعه جاری برای ویرایش
            DBLayerIMS.Referrals.ChangeRefLock(CurrentRefID, true);
            CurrentFormState = RefFormState.Editing;
            return true;
        }
        #endregion

        #region Boolean SaveCurrentPatientData()
        /// <summary>
        /// تابعی برای ثبت اطلاعات بیمار و مراجعه جاری بر اساس وضعیت فرم و تعیین مجوز برای تغییر وضعیت
        /// </summary>
        /// <remarks>این تابع پس از ثبت وضعیت فرم را تغییر نمی دهد</remarks>
        /// <returns>صحت ثبت اطلاعات</returns>
        private Boolean SaveCurrentPatientData()
        {
            if (!ValidatePatientData() || !ValidateReferralData()) return false;
            switch (CurrentFormState)
            {
                case RefFormState.AddingPatRef:
                    if (!AddOrEditPatient(true) || !AddOrEditRef(true)) return false; break;
                case RefFormState.AddingRef:
                    if (!AddOrEditPatient(false) || !AddOrEditRef(true)) return false; break;
                case RefFormState.Editing:
                    if (!AddOrEditPatient(false) || !AddOrEditRef(false)) return false; break;
            }
            return true;
        }
        #endregion

        // =================================================

        #region Boolean ValidatePatientData()
        /// <summary>
        /// تابعی برای بررسی ورود صحیح اطلاعات فرم
        /// </summary>
        /// <returns>کامل بودن یا نبودن</returns>
        private Boolean ValidatePatientData()
        {
            if (String.IsNullOrEmpty(txtLastName.Text.Trim()))
            {
                PMBox.Show("نام خانوادگی بیمار وارد نشده است! لطفاً حتماً نام خانوادگی را وارد نمایید.", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLastName.Focus();
                return false;
            }
            if (_ShouldEnterGender && cBoxMale.Checked == false && cBoxFemale.Checked == false)
            {
                cBoxMale.Focus();
                PMBox.Show("انتخاب جنسیت ضروری است!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (_ShouldEnterBirthDay && txtAgeYear.ValueObject == null && txtAgeMonth.ValueObject == null && txtAgeDay.ValueObject == null)
            {
                PMBox.Show("وارد كردن تاریخ تولد یا سن بیمارضروری است!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (_ShouldEnterTelNo1 && String.IsNullOrEmpty(txtTel1.Text))
            {
                PMBox.Show("وارد كردن شماره تلفن 1 ضروری است!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (_ShouldEnterTelNo2 && String.IsNullOrEmpty(txtTel2.Text))
            {
                PMBox.Show("وارد كردن شماره تلفن 2 ضروری است!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (_ShouldEnterAddress && String.IsNullOrEmpty(txtAddress.Text))
            {
                PMBox.Show("وارد كردن شماره آدرس ضروری است!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        #endregion

        #region Boolean AddOrEditPatient(Boolean IsAdding)
        /// <summary>
        /// تابعی برای ثبت بیمار جدید یا ویرایش بیمار جاری بر اساس اطلاعات جاری موجود در كنترل ها
        /// </summary>
        /// <returns>صحت انجام عملیات</returns>
        private Boolean AddOrEditPatient(Boolean IsAdding)
        {
            #region Find Patient EnglishName
            if (_ShouldSaveEnglishName)
            {
                String EnglishFirstName = Negar.DBLayerPMS.Patients.GetEnglishName(txtFirstName.Text, true);
                String EnglishLastName = Negar.DBLayerPMS.Patients.GetEnglishName(txtLastName.Text, false);
                if (String.IsNullOrEmpty(EnglishFirstName)) new frmNamesTranslator(txtFirstName.Text.Trim(), true);
                if (String.IsNullOrEmpty(EnglishLastName)) new frmNamesTranslator(txtLastName.Text.Trim(), false);
            }
            #endregion

            #region IsMale CheckBoxes
            Boolean? IsMale = null;
            if (cBoxMale.Checked) IsMale = true;
            else if (cBoxFemale.Checked) IsMale = false;
            #endregion

            #region BirthDate
            DateTime? BirthDate = DateTime.Now;
            if (cBoxEnterPatAge.Checked)
            {
                if (txtAgeYear.ValueObject != null)
                    BirthDate = BirthDate.Value.AddYears(-1 * txtAgeYear.Value);
                if (txtAgeMonth.ValueObject != null)
                    BirthDate = BirthDate.Value.AddMonths(-1 * txtAgeMonth.Value);
                if (txtAgeDay.ValueObject != null)
                    BirthDate = BirthDate.Value.AddDays(-1 * txtAgeDay.Value);
            }
            else if (DateInputBirthDate.SelectedDateTime != DateTime.MinValue)
                BirthDate = DateInputBirthDate.SelectedDateTime;
            #endregion

            #region Add Or Edit Data

            #region AddingPatRef State
            if (IsAdding)
            {
                #region Search For Same Patient
                // جستجوی برای بیماران هم نام
                if (_ShouldSearchForSamePatient)
                {
                    frmSimilarPatients MyForm = new frmSimilarPatients(txtFirstName.Text.Trim(), txtLastName.Text.Trim());
                    if (MyForm.DialogResult == DialogResult.OK)
                    {
                        CurrentPatientListID = MyForm.SelectedPatientListID;
                        MyForm.Dispose();
                        return true;
                    }
                    MyForm.Dispose();
                    BringToFront();
                    Focus();
                }
                #endregion
                _CurrentPatientData.PatientID = Negar.DBLayerPMS.Patients.GenerateNewPatientID();
                if (String.IsNullOrEmpty(_CurrentPatientData.PatientID)) return false;
            }
            #endregion

            _CurrentPatientData.FirstName = txtFirstName.Text.Trim().Normalize();
            _CurrentPatientData.LastName = txtLastName.Text.Trim().Normalize();
            _CurrentPatientData.IsMale = IsMale;
            _CurrentPatientData.BirthDate = BirthDate;
            if (_CurrentPatientData.PatDetail == null) _CurrentPatientData.PatDetail = new PatDetail();
            _CurrentPatientData.PatDetail.EngFirstName = Negar.DBLayerPMS.Patients.GetEnglishName(txtFirstName.Text, true);
            _CurrentPatientData.PatDetail.EngLastName = Negar.DBLayerPMS.Patients.GetEnglishName(txtLastName.Text, false);
            _CurrentPatientData.PatDetail.TelNo1 = txtTel1.Text.Trim().Normalize();
            _CurrentPatientData.PatDetail.TelNo2 = txtTel2.Text.Trim().Normalize();
            _CurrentPatientData.PatDetail.Address = txtAddress.Text.Trim().Normalize();
            if (IsAdding) Negar.DBLayerPMS.Manager.DBML.PatLists.InsertOnSubmit(_CurrentPatientData);
            else
            {
                try
                {
                    Negar.DBLayerPMS.Manager.DBML.Refresh(RefreshMode.KeepChanges, _CurrentPatientData);
                    Negar.DBLayerPMS.Manager.DBML.Refresh(RefreshMode.KeepChanges, _CurrentPatientData.PatDetail);
                }
                #region Catch
                catch (Exception Ex)
                {
                    const String ErrorMessage = "امكان مقایسه اطلاعات بیمار با اطلاعات موجود در بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogManager.SaveLogEntry("Sepehr", "Admission Forms", Ex.Message + "\n" +
                        Ex.StackTrace, EventLogEntryType.Error);
                }
                #endregion
            }
            if (!Negar.DBLayerPMS.Manager.Submit())
            {
                const String ErrorMessage = "امكان ثبت اطلاعات بیمار در بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
            }
            txtPatientID.TextBox.Text = _CurrentPatientData.PatientID;
            #endregion

            // آزاد كردن بیمار جاری در حالت ویرایش
            if (!IsAdding) Negar.DBLayerPMS.Patients.ChangePatLock(CurrentPatientListID, false);

            #region Update Current Patient Appointment ID
            if (IsAdding && _CurrentSchID != null)
            {
                SchAppointments SchApp = null;
                try
                {
                    IQueryable<SchAppointments> TheApps =
                        DBLayerIMS.Manager.DBML.SchAppointments.Where(Data => Data.ID == _CurrentSchID.Value);
                    DBLayerIMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, TheApps);
                    if (TheApps.Count() == 0)
                        PMBox.Show("نوبت ارسال شده در سیستم وجود ندارد و امكان ارتباط آن به بیمار جاری وجود ندارد.", "خطا!",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else SchApp = TheApps.First();
                }
                #region Catch
                catch (Exception Ex)
                {
                    const String ErrorMessage =
                        "امكان ثبت اطلاعات ارتباط بیمار و نوبت دهی در بانك اطلاعات ممكن نیست.\n" +
                        "موارد زیر را بررسی نمایید:\n" +
                        "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogManager.SaveLogEntry("Sepehr", "Admission Forms", Ex.Message + "\n" +
                        Ex.StackTrace, EventLogEntryType.Error);
                }
                #endregion
                if (SchApp != null)
                {
                    SchApp.PatientIX = _CurrentPatientData.ID;
                    if (!DBLayerIMS.Manager.Submit())
                    {
                        const String ErrorMessage = "امكان ثبت اطلاعات ارتباط نوبت بیمار با پذیرش جاری در بانك اطلاعات ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
                    }
                }
            }
            #endregion

            return true;
        }
        #endregion

        // =================================================

        #region Boolean ValidateReferralData()
        /// <summary>
        /// تابعی برای بررسی اطلاعات وارد شده در فرم
        /// </summary>
        /// <returns>صحت ورود اطلاعات یا خطا در اطلاعات</returns>
        internal Boolean ValidateReferralData()
        {
            #region Referral Data
            if (DatePrescribe.SelectedDateTime != null &&
                DatePrescribe.SelectedDateTime.Value.Date > DateReferral.SelectedDateTime.Value.Date)
            {
                DialogResult Result = PMBox.Show("تاریخ نسخه بیمار نمی تواند بعد از زمان مراجعه بیمار باشد!\n" +
                "آیا مایلید با تاریخ نسخه نادرست ادامه دهید؟",
                    "خطا! پرسش؟", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (Result != DialogResult.Yes)
                {
                    DatePrescribe.Focus();
                    return false;
                }
            }
            if (_ShouldEnterPrescribeDate && DatePrescribe.SelectedDateTime == null)
            {
                PMBox.Show("وارد كردن تاریخ نسخه بیمار ضروری است!",
                    "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DatePrescribe.Focus();
                return false;
            }
            if (DatePrescribe.SelectedDateTime != null && DatePrescribe.SelectedDateTime.Value.Year > 2050)
            {
                PMBox.Show("تاریخ نسخه وارد شده بیش از حد مجاز می باشد!",
                    "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DatePrescribe.Focus();
                return false;
            }
            if (_ShouldEnterWeight && String.IsNullOrEmpty(txtWeight.Text))
            {
                PMBox.Show("وارد كردن وزن بیمار ضروری است!",
                    "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtWeight.Focus();
                return false;
            }
            if (_ShouldEnterReferralPhysician && (cboRefPhysician.SelectedIndex < 0 || cboRefPhysician.SelectedValue == null))
            {
                PMBox.Show("وارد كردن نام  پزشك مراجعه بیمار ضروری است!",
                    "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboRefPhysician.Focus();
                return false;
            }
            if (_ShouldEnterRefStatus && cboRefStatus.SelectedIndex < 1)
            {
                PMBox.Show("وارد كردن وضعیت مراجعه بیمار ضروری است!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboRefStatus.Focus();
                return false;
            }
            if (_ShouldEnterDescription && String.IsNullOrEmpty(txtDescription.Text))
            {
                PMBox.Show("وارد كردن توضیحات مراجعه بیمار ضروری است!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDescription.Focus();
                return false;
            }
            #endregion

            #region Ins1
            if (_ShouldEnterIns1 && cboIns1.SelectedIndex == 0)
            {
                PMBox.Show("انتخاب بیمه اول ضروری است!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboIns1.Focus();
                return false;
            }
            if (cboIns1.SelectedIndex != 0 && _ShouldEnterIns1Num && String.IsNullOrEmpty(txtIns1No1.Text.Trim()))
            {
                PMBox.Show("وارد كردن شماره بیمه اول ضروری است!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtIns1No1.Focus();
                return false;
            }
            if (cboIns1.SelectedIndex != 0 && _ShouldWarnIns1Num && String.IsNullOrEmpty(txtIns1No1.Text.Trim()))
            {
                DialogResult Result = PMBox.Show("شماره بیمه اول وارد نشده است.\n" +
                    "آیا مایلید بدون وارد كردن شماره بیمه پذیرش نمایید؟", "هشدار!",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                if (Result == DialogResult.No) { txtIns1No1.Focus(); return false; }
            }
            if (cboIns1.SelectedIndex != 0 && _ShouldEnterIns1ExpireDate && Ins1ExpireDate.SelectedDateTime == null)
            {
                PMBox.Show("وارد كردن تاریخ اعتبار بیمه اول ضروری است!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Ins1ExpireDate.Focus();
                return false;
            }
            if (cboIns1.SelectedIndex != 0 && _ShouldWarnForInsExpireDate && Ins1ExpireDate.SelectedDateTime != null &&
                Ins1ExpireDate.SelectedDateTime.Value.Date < DateReferral.SelectedDateTime.Value.Date)
            {
                DialogResult Result = PMBox.Show("اعتبار دفترچه بیمه ی اول نسبت به تاریخ پذیرش به اتمام رسیده است!\n" +
                    "آیا مایلید با تاریخ اعتبار پایان یافته ادامه دهید؟",
                    "خطا! پرسش؟", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (Result != DialogResult.Yes)
                {
                    Ins1ExpireDate.Focus();
                    return false;
                }
            }
            if (Ins1ExpireDate.SelectedDateTime != null && Ins1ExpireDate.SelectedDateTime.Value.Year > 2050)
            {
                PMBox.Show("تاریخ اعتبار بیمه اول وارد شده بیش از حد مجاز می باشد!",
                    "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Ins1ExpireDate.Focus();
                return false;
            }
            if (cboIns1.SelectedIndex != 0 && _ShouldEnterPageNo && txtPageNo.ValueObject == null)
            {
                PMBox.Show("وارد كردن شماره صفحه دفترچه بیمه اول ضروری است!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPageNo.Focus();
                return false;
            }

            #region Ref Physician Spec Coverage & Ref Physician Coverage
            // در این قسمت تخصص ها و پزشكان ارجاع دهنده مجاز بررسی می شود
            if (cboIns1.SelectedIndex != 0 && _RefServices.Count != 0)
            {
                #region Ref Phys Spec
                // بررسی وجود اطلاعات برای بیمه انتخاب شده
                // اگر آیتمی برای كل خدمات بیمه جاری ثبت شده باشد
                if (DBLayerIMS.Manager.DBML.InsRefPhysSpecExcludes.
                    Where(Data => Data.InsIX == Convert.ToInt16(cboIns1.SelectedValue)).Count() > 0)
                {
                    if (cboRefPhysician.SelectedValue == null)
                    {
                        PMBox.Show("برای بیمه اول انتخاب شده باید حتماً پزشك درخواست كننده انتخاب شود!", "خطا!",
                            MessageBoxButtons.OK, MessageBoxIcon.Error); cboRefPhysician.Focus(); return false;
                    }
                    RefPhysician CurrentRefPhys = Negar.DBLayerPMS.ClinicData.GetRefPhysBaseDataByID(
                        Convert.ToInt16(cboRefPhysician.SelectedValue));
                    if (CurrentRefPhys == null) return false;
                    if (CurrentRefPhys.SpecialtyIX == null)
                    {
                        PMBox.Show("برای پزشك درخواست كننده انتخاب شده تخصصی ثبت نشده است!", "خطا!",
                            MessageBoxButtons.OK, MessageBoxIcon.Error); cboRefPhysician.Focus(); return false;
                    }
                    List<InsRefPhysSpecExclude> ExcludedRefPhysSpecs =
                        DBLayerIMS.Manager.DBML.ExecuteQuery<InsRefPhysSpecExclude>(
                        "SELECT * FROM [ImagingSystem].[Insurances].[RefPhysSpecExclude] " +
                        "WHERE [InsIX] = " + Convert.ToInt16(cboIns1.SelectedValue) +
                    " AND [RefPhysSpecID] = " + CurrentRefPhys.SpecialtyIX).ToList();
                    if (ExcludedRefPhysSpecs.Count() == 0)
                    {
                        PMBox.Show("پزشك انتخاب شده با تخصص خود قادر به تجویز نسخه برای بیمه اول جاری نمی باشد.", "خطا!",
                            MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
                    }
                    foreach (RefService service in _RefServices.Where(Data => Data.IsActive && Data.IsIns1Cover == true).ToList())
                    {
                        if (ExcludedRefPhysSpecs.Where(Data => Data.ServiceIX == service.ServiceIX).Count() == 0)
                        {
                            SP_SelectServicesListResult ServiceData =
                                DBLayerIMS.Services.ServicesList.Where(Data => Data.ID == service.ServiceIX).First();
                            PMBox.Show("پزشك درخواست كننده انتخاب شده با این تخصص مجاز به ارائه خدمت زیر برای این بیمه اول نمیباشد:\n" +
                                "كد: " + ServiceData.Code + " - " + ServiceData.Name, "خطا!",
                                MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
                        }
                    }
                }
                #endregion

                #region Ref Phys
                // بررسی وجود اطلاعات برای بیمه انتخاب شده
                // اگر آیتمی برای كل خدمات بیمه جاری ثبت شده باشد
                if (DBLayerIMS.Manager.DBML.InsPhysicianExcludes.
                    Where(Data => Data.InsIX == Convert.ToInt16(cboIns1.SelectedValue)).Count() > 0)
                {
                    if (cboRefPhysician.SelectedValue == null)
                    {
                        PMBox.Show("برای بیمه اول انتخاب شده باید حتماً پزشك درخواست كننده انتخاب شود!", "خطا!",
                            MessageBoxButtons.OK, MessageBoxIcon.Error); cboRefPhysician.Focus(); return false;
                    }
                    RefPhysician CurrentRefPhys = Negar.DBLayerPMS.ClinicData.GetRefPhysBaseDataByID(
                        Convert.ToInt16(cboRefPhysician.SelectedValue));
                    if (CurrentRefPhys == null) return false;
                    // بررسی خدمات مجاز برای پزشك جاری
                    List<InsPhysicianExclude> ExcludedPhysicians =
                        DBLayerIMS.Manager.DBML.ExecuteQuery<InsPhysicianExclude>(
                        "SELECT * FROM [ImagingSystem].[Insurances].[PhysicianExclude] " +
                        "WHERE [InsIX] = " + Convert.ToInt16(cboIns1.SelectedValue) +
                        " AND [RefPhysID] = " + CurrentRefPhys.ID).ToList();
                    if (ExcludedPhysicians.Count() == 0)
                    {
                        PMBox.Show("پزشك انتخاب شده قادر به تجویز نسخه برای بیمه اول جاری نمی باشد.", "خطا!",
                            MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
                    }
                    foreach (RefService service in _RefServices.Where(Data => Data.IsActive && Data.IsIns1Cover == true).ToList())
                    {
                        if (ExcludedPhysicians.Where(Data => Data.ServiceIX == service.ServiceIX).Count() == 0)
                        {
                            SP_SelectServicesListResult ServiceData =
                                DBLayerIMS.Services.ServicesList.Where(Data => Data.ID == service.ServiceIX).First();
                            PMBox.Show("پزشك درخواست كننده انتخاب شده مجاز به ارائه خدمت زیر برای این بیمه اول نمیباشد:\n" +
                                "كد: " + ServiceData.Code + " - " + ServiceData.Name, "خطا!",
                                MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
                        }
                    }
                }
                #endregion
            }
            #endregion

            #endregion

            #region Ins2
            if (_ShouldEnterIns2 && cboIns1.SelectedIndex != 0 && cboIns2.SelectedIndex == 0)
            {
                PMBox.Show("انتخاب بیمه دوم ضروری است!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboIns2.Focus();
                return false;
            }
            if (cboIns2.SelectedIndex != 0 && _ShouldEnterIns2Num &&
                String.IsNullOrEmpty(txtIns2No1.Text.Trim()))
            {
                PMBox.Show("وارد كردن شماره بیمه دوم ضروری است!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtIns2No1.Focus();
                return false;
            }
            if (cboIns2.SelectedIndex != 0 &&
                _ShouldEnterIns2ExpireDate && Ins2ExpireDate.SelectedDateTime == null)
            {
                PMBox.Show("وارد كردن تاریخ اعتبار بیمه دوم ضروری است!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Ins2ExpireDate.Focus();
                return false;
            }
            if (cboIns2.SelectedIndex != 0 && _ShouldWarnForInsExpireDate &&
                Ins2ExpireDate.SelectedDateTime != null &&
                Ins2ExpireDate.SelectedDateTime.Value.Date < DateReferral.SelectedDateTime.Value.Date)
            {
                DialogResult Result = PMBox.Show("اعتبار دفترچه بیمه ی دوم نسبت به تاریخ پذیرش به اتمام رسیده است!\n" +
                   "آیا مایلید با تاریخ اعتبار پایان یافته ادامه دهید؟",
                   "خطا! پرسش؟", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (Result != DialogResult.Yes)
                {
                    Ins2ExpireDate.Focus();
                    return false;
                }
            }
            if (Ins2ExpireDate.SelectedDateTime != null && Ins2ExpireDate.SelectedDateTime.Value.Year > 2050)
            {
                PMBox.Show("تاریخ اعتبار بیمه دوم وارد شده بیش از حد مجاز می باشد!",
                    "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Ins2ExpireDate.Focus();
                return false;
            }

            #region Ref Physician Spec Coverage & Ref Physician Coverage
            // در این قسمت تخصص ها و پزشكان ارجاع دهنده مجاز بررسی می شود
            if (cboIns2.SelectedIndex != 0 && _RefServices.Count != 0)
            {
                #region Ref Phys Spec
                // بررسی وجود اطلاعات برای بیمه انتخاب شده
                // اگر آیتمی برای كل خدمات بیمه جاری ثبت شده باشد
                if (DBLayerIMS.Manager.DBML.InsRefPhysSpecExcludes.
                    Where(Data => Data.InsIX == Convert.ToInt16(cboIns2.SelectedValue)).Count() > 0)
                {
                    if (cboRefPhysician.SelectedValue == null)
                    {
                        PMBox.Show("برای بیمه دوم انتخاب شده باید حتماً پزشك درخواست كننده انتخاب شود!", "خطا!",
                            MessageBoxButtons.OK, MessageBoxIcon.Error); cboRefPhysician.Focus(); return false;
                    }
                    RefPhysician CurrentRefPhys = Negar.DBLayerPMS.ClinicData.GetRefPhysBaseDataByID(
                        Convert.ToInt16(cboRefPhysician.SelectedValue));
                    if (CurrentRefPhys == null) return false;
                    if (CurrentRefPhys.SpecialtyIX == null)
                    {
                        PMBox.Show("برای پزشك درخواست كننده انتخاب شده تخصصی ثبت نشده است!", "خطا!",
                            MessageBoxButtons.OK, MessageBoxIcon.Error); cboRefPhysician.Focus(); return false;
                    }
                    List<InsRefPhysSpecExclude> ExcludedRefPhysSpecs =
                        DBLayerIMS.Manager.DBML.ExecuteQuery<InsRefPhysSpecExclude>(
                        "SELECT * FROM [ImagingSystem].[Insurances].[RefPhysSpecExclude] " +
                        "WHERE [InsIX] = " + Convert.ToInt16(cboIns2.SelectedValue) +
                    " AND [RefPhysSpecID] = " + CurrentRefPhys.SpecialtyIX).ToList();
                    if (ExcludedRefPhysSpecs.Count() == 0)
                    {
                        PMBox.Show("پزشك انتخاب شده با تخصص خود قادر به تجویز نسخه برای بیمه دوم جاری نمی باشد.", "خطا!",
                            MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
                    }
                    foreach (RefService service in _RefServices.Where(Data => Data.IsActive && Data.IsIns2Cover == true).ToList())
                    {
                        if (ExcludedRefPhysSpecs.Where(Data => Data.ServiceIX == service.ServiceIX).Count() == 0)
                        {
                            SP_SelectServicesListResult ServiceData =
                                DBLayerIMS.Services.ServicesList.Where(Data => Data.ID == service.ServiceIX).First();
                            PMBox.Show("پزشك درخواست كننده انتخاب شده با این تخصص مجاز به ارائه خدمت زیر برای این بیمه دوم نمیباشد:\n" +
                                "كد: " + ServiceData.Code + " - " + ServiceData.Name, "خطا!",
                                MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
                        }
                    }
                }
                #endregion

                #region Ref Phys
                // بررسی وجود اطلاعات برای بیمه انتخاب شده
                // اگر آیتمی برای كل خدمات بیمه جاری ثبت شده باشد
                if (DBLayerIMS.Manager.DBML.InsPhysicianExcludes.
                    Where(Data => Data.InsIX == Convert.ToInt16(cboIns2.SelectedValue)).Count() > 0)
                {
                    if (cboRefPhysician.SelectedValue == null)
                    {
                        PMBox.Show("برای بیمه دوم انتخاب شده باید حتماً پزشك درخواست كننده انتخاب شود!", "خطا!",
                            MessageBoxButtons.OK, MessageBoxIcon.Error); cboRefPhysician.Focus(); return false;
                    }
                    RefPhysician CurrentRefPhys = Negar.DBLayerPMS.ClinicData.GetRefPhysBaseDataByID(
                        Convert.ToInt16(cboRefPhysician.SelectedValue));
                    if (CurrentRefPhys == null) return false;
                    // بررسی خدمات مجاز برای پزشك جاری
                    List<InsPhysicianExclude> ExcludedPhysicians =
                        DBLayerIMS.Manager.DBML.ExecuteQuery<InsPhysicianExclude>(
                        "SELECT * FROM [ImagingSystem].[Insurances].[PhysicianExclude] " +
                        "WHERE [InsIX] = " + Convert.ToInt16(cboIns2.SelectedValue) +
                        " AND [RefPhysID] = " + CurrentRefPhys.ID).ToList();
                    if (ExcludedPhysicians.Count() == 0)
                    {
                        PMBox.Show("پزشك انتخاب شده قادر به تجویز نسخه برای بیمه دوم جاری نمی باشد.", "خطا!",
                            MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
                    }
                    foreach (RefService service in _RefServices.Where(Data => Data.IsActive && Data.IsIns2Cover == true).ToList())
                    {
                        if (ExcludedPhysicians.Where(Data => Data.ServiceIX == service.ServiceIX).Count() == 0)
                        {
                            SP_SelectServicesListResult ServiceData =
                                DBLayerIMS.Services.ServicesList.Where(Data => Data.ID == service.ServiceIX).First();
                            PMBox.Show("پزشك درخواست كننده انتخاب شده مجاز به ارائه خدمت زیر برای این بیمه دوم نمیباشد:\n" +
                                "كد: " + ServiceData.Code + " - " + ServiceData.Name, "خطا!",
                                MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
                        }
                    }
                }
                #endregion
            }
            #endregion

            #endregion

            #region Services
            if (_ShouldEnterServices && _RefServices.Count == 0)
            {
                PMBox.Show("وارد كردن خدمت برای ثبت مراجعه بیمار ضروری است!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtServiceCode.Focus();
                return false;
            }
            foreach (RefService service in _RefServices)
            {
                if (_ShouldEnterServiceExpert && service.ExpertIX == null)
                {
                    PMBox.Show("وارد كردن نام كارشناس برای كلیه خدمات مراجعه بیمار ضروری است!", "خطا!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvRefServices.Focus();
                    return false;
                }
                if (_ShouldEnterServicePhysician && service.PhysicianIX == null)
                {
                    PMBox.Show("وارد كردن نام پزشك برای كلیه خدمات مراجعه بیمار ضروری است!", "خطا!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvRefServices.Focus();
                    return false;
                }
            }
            #endregion

            #region PrePayment
            if (_ShouldEnterPrePayment && txtPrePayment.ValueObject == null)
            {
                PMBox.Show("وارد كردن مبلغ پیش پرداخت مراجعه بیمار ضروری است!",
                    "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrePayment.Focus();
                return false;
            }
            #endregion

            return true;
        }
        #endregion

        #region Boolean AddOrEditRef(Boolean IsAdding)
        /// <summary>
        /// مراجعه جدیدی را برای بیمار جاری ثبت می كند
        /// </summary>
        /// <param name="IsAdding">تعیین حالت افزودن مراجعه یا ویرایش مراجعه</param>
        /// <returns>درج یا عدم درج</returns>
        private Boolean AddOrEditRef(Boolean IsAdding)
        {
            dgvRefServices.EndEdit();
            DateReferral.Focus();
            if (IsAdding) TimeTimer.Stop();

            #region Read Form Data

            #region Date & Times
            // تاریخ و ساعت مراجعه
            DateTime RefDate = new DateTime(DateReferral.SelectedDateTime.Value.Year,
                DateReferral.SelectedDateTime.Value.Month, DateReferral.SelectedDateTime.Value.Day,
                TimeReferral.Value.Hour, TimeReferral.Value.Minute, TimeReferral.Value.Second, 0);
            // تاریخ نسخه
            DateTime? PrescribeDate = null;
            if (DatePrescribe.SelectedDateTime != null)
                PrescribeDate = new DateTime(DatePrescribe.SelectedDateTime.Value.Year,
                    DatePrescribe.SelectedDateTime.Value.Month,
                    DatePrescribe.SelectedDateTime.Value.Day, 12, 0, 0, 0);
            DateTime? ReportDate = null;
            if (PDateReport.SelectedDateTime != null)
                ReportDate = new DateTime(PDateReport.SelectedDateTime.Value.Year,
                    PDateReport.SelectedDateTime.Value.Month,
                    PDateReport.SelectedDateTime.Value.Day, 12, 0, 0, 0);
            #endregion

            #region Combo Boxes
            Int16? StatusID = null;
            if (cboRefStatus.SelectedIndex != 0) StatusID = Convert.ToInt16(cboRefStatus.SelectedValue);
            try
            {
                Int32 TheIndex = cboRefPhysician.FindStringExact(cboRefPhysician.Text);
                if (TheIndex >= 0) cboRefPhysician.SelectedIndex = TheIndex;
            }
            // ReSharper disable EmptyGeneralCatchClause
            catch (Exception) { }
            // ReSharper restore EmptyGeneralCatchClause
            Int16? ReferPhysicianID = null;
            if (!String.IsNullOrEmpty(cboRefPhysician.Text) && cboRefPhysician.SelectedValue != null &&
                cboRefPhysician.SelectedIndex >= 0)
                ReferPhysicianID = Convert.ToInt16(cboRefPhysician.SelectedValue);

            // كلید كاربر پذیرش كننده حتماً باید وارد شود
            Int16 AdmitterID = Convert.ToInt16(cboAdmitter.SelectedValue);

            Int16? Ins1ID = null;
            if (cboIns1.SelectedIndex != 0) Ins1ID = Convert.ToInt16(cboIns1.SelectedValue);

            Int16? Ins2ID = null;
            if (cboIns2.SelectedIndex != 0) Ins2ID = Convert.ToInt16(cboIns2.SelectedValue);
            #endregion

            #region Weight
            Byte? Weight = null;
            if (txtWeight.ValueObject != null) Weight = Convert.ToByte(txtWeight.Value);
            #endregion

            #region Page No
            String PageNo = null;
            if (txtPageNo.ValueObject != null) PageNo = txtPageNo.Text;
            #endregion

            #endregion

            #region Set Data To Ref Object
            _CurrentRefData.PatientIX = CurrentPatientListID;
            _CurrentRefData.RegisterDate = RefDate;
            _CurrentRefData.PrescriptionDate = PrescribeDate;
            _CurrentRefData.Weight = Weight;
            _CurrentRefData.AdmitterIX = AdmitterID;
            _CurrentRefData.ReferPhysicianIX = ReferPhysicianID;
            _CurrentRefData.ReferStatusIX = StatusID;
            if (!IsAdding)
            {
                if (!DBLayerIMS.Manager.Submit())
                {
                    const String ErrorMessage = "امكان ثبت اطلاعات مراجعه جاری بیمار در بانك اطلاعات ممكن نیست.\n" +
                        "موارد زیر را بررسی نمایید:\n" +
                        "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
                }
                DBLayerIMS.Manager.DBML.Refresh(RefreshMode.KeepChanges, _CurrentRefData);
            }
            _CurrentRefData.Ins1IX = Ins1ID;
            _CurrentRefData.Ins1Num1 = txtIns1No1.Text.Trim();
            _CurrentRefData.Ins1Validation = Ins1ExpireDate.SelectedDateTime;
            _CurrentRefData.Ins1PageNum = PageNo;
            _CurrentRefData.Ins2IX = Ins2ID;
            _CurrentRefData.Ins2Num = txtIns2No1.Text.Trim();
            _CurrentRefData.Ins2Validation = Ins2ExpireDate.SelectedDateTime;
            if (!IsAdding)
            {
                if (!DBLayerIMS.Manager.Submit())
                {
                    const String ErrorMessage = "امكان ثبت اطلاعات مراجعه جاری بیمار در بانك اطلاعات ممكن نیست.\n" +
                        "موارد زیر را بررسی نمایید:\n" +
                        "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
                }
                DBLayerIMS.Manager.DBML.Refresh(RefreshMode.KeepChanges, _CurrentRefData);
            }
            _CurrentRefData.PrePayable = (Int32?)txtPrePayment.ValueObject;
            _CurrentRefData.Description = txtDescription.Text.Trim().Normalize();
            _CurrentRefData.ReportDate = ReportDate;
            #endregion

            #region Insert New Ref Row In Adding State
            if (IsAdding)
            {
                DBLayerIMS.Manager.DBML.RefLists.InsertOnSubmit(_CurrentRefData);
                if (!DBLayerIMS.Manager.Submit())
                {
                    const String ErrorMessage = "امكان ثبت اطلاعات مراجعه جاری بیمار در بانك اطلاعات ممكن نیست.\n" +
                        "موارد زیر را بررسی نمایید:\n" +
                        "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
                }
                lblRefID.Text = _CurrentRefData.ID.ToString();
                foreach (RefService service in _RefServices)
                {
                    service.ReferralIX = _CurrentRefData.ID;
                    DBLayerIMS.Manager.DBML.RefServices.InsertOnSubmit(service);
                }
            }
            #endregion

            #region Submit Changes In Edit State Or Add Ref Services In Adding State
            try { if (!IsAdding) DBLayerIMS.Manager.DBML.Refresh(RefreshMode.KeepChanges, _CurrentRefData); }
            catch { }
            if (!DBLayerIMS.Manager.Submit())
            {
                const String ErrorMessage = "امكان ثبت اطلاعات مراجعه جاری بیمار در بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
            }
            #endregion

            #region Update Current Patient Appointment ID
            if (IsAdding && _CurrentSchID != null)
            {
                SchAppointments SchApp = null;
                try
                {
                    IQueryable<SchAppointments> TheApps =
                        DBLayerIMS.Manager.DBML.SchAppointments.Where(Data => Data.ID == _CurrentSchID.Value);
                    DBLayerIMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, TheApps);
                    if (TheApps.Count() == 0)
                        PMBox.Show("نوبت ارسال شده در سیستم وجود ندارد و امكان ارتباط آن به بیمار جاری وجود ندارد.", "خطا!",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else SchApp = TheApps.First();
                }
                #region Catch
                catch (Exception Ex)
                {
                    const String ErrorMessage = "امكان ثبت اطلاعات ارتباط مراجعه و نوبت بیمار ممكن نیست.\n" +
                        "موارد زیر را بررسی نمایید:\n" +
                        "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogManager.SaveLogEntry("Sepehr", "Admission Forms", Ex.Message + "\n" +
                        Ex.StackTrace, EventLogEntryType.Error);
                }
                #endregion
                if (SchApp != null)
                {
                    SchApp.ReferralIX = _CurrentRefData.ID;
                    if (!DBLayerIMS.Manager.Submit())
                    {
                        const String ErrorMessage = "امكان ثبت ارتباط نوبت با مراجعه جاری ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
                    }
                }
            }
            _CurrentSchID = null;
            #endregion

            #region Submit Data To PACS Integration Service
            if (IsAdding && DBLayerIMS.PACS.Modalities.Count != 0)
            {
                for (int i = 0; i < _RefServices.Count; i++)
                {
                    List<ServiceModality> List = DBLayerIMS.PACS.ServiceModalities.
                        Where(Data => Data.ServiceIX == _RefServices[i].ServiceIX).ToList();
                    if (List.Count == 0) continue;
                    if (List.Count == 1)
                    {
                        List<Int16> Modalities = new List<Int16>();
                        Modalities.Add(List[0].ModalityIX);
                        DBLayerIMS.PACS.RegisterRefDataInPACS(_RefServices[i].ID, Modalities);
                    }
                    else
                    {
                        if (_PACSManager == null || _PACSManager.IsDisposed)
                            _PACSManager = new frmRefModalitySelection();
                        _PACSManager.Show(_RefServices[i].ServiceIX);
                        if (_PACSManager.DialogResult == DialogResult.OK && _PACSManager.Modalities != null)
                        {
                            List<Int16> finalList = new List<Int16>();
                            foreach (Int16 modality in _PACSManager.Modalities)
                                if (modality != 0) finalList.Add(modality);
                            if (finalList.Count != 0)
                                DBLayerIMS.PACS.RegisterRefDataInPACS(_RefServices[i].ID, finalList);
                        }
                    }
                }
            }
            #endregion

            // آزاد سازی مراجعه
            if (!IsAdding) DBLayerIMS.Referrals.ChangeRefLock(CurrentRefID, false);
            _IsCurrentPatModified = false;
            return true;
        }
        #endregion

        #endregion

    }
}