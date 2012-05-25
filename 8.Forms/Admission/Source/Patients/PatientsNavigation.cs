#region using

using System;
using System.Windows.Forms;
using Negar;

#endregion

namespace Sepehr.Forms.Admission.Patients
{
    /// <summary>
    /// فرم مدیریت بیماران - بخش مدیریت وضعیت فرم برای جابجایی بین بیماران
    /// </summary>
    internal partial class frmPatients
    {

        #region Event Handlers

        #region txtPatientID_KeyPress
        /// <summary>
        /// دستگیره مدیریت كد بیمار برای تغییر بیمار جاری
        /// </summary>
        private void txtPatientID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r' && String.IsNullOrEmpty(txtPatientID.Text.Trim()))
            {
                #region Check User Permission If (_IsCurrentPatModified) Is True
                // اگر بیمار ویرایش شده بود
                if (_IsCurrentPatModified)
                    // اگر كاربر اجازه تغییر صادر نكرد
                    if (!CheckUserPermissionForNavigation()) return;
                #endregion
                // آزاد كردن بیمار جاری
                if (FormState == PatientFormStates.Editing) Negar.DBLayerPMS.Patients.ChangePatLock(_CurrentPatientData.ID, false);
                txtPatientID.Text = txtPatientID.Text.Trim();
                Int32? PatientListID = Negar.DBLayerPMS.Patients.GetPatListIDByPatientID(txtPatientID.TextBox.Text);
                if (PatientListID == null) { Dispose(); return; }
                if (PatientListID == 0)
                {
                    PMBox.Show("بیماری با كد وارد شده وجود ندارد!", "خطا!",
                      MessageBoxButtons.OK, MessageBoxIcon.Information); return;
                }
                if (CurrentPatientListID != Convert.ToInt32(PatientListID))
                {
                    CurrentPatientListID = Convert.ToInt32(PatientListID);
                    FormState = PatientFormStates.Viewing;
                }
            }
            else if (e.KeyChar == '' && _CurrentPatientData != null &&
                String.IsNullOrEmpty(_CurrentPatientData.PatientID)) txtPatientID.TextBox.Text = _CurrentPatientData.PatientID;
        }
        #endregion

        // SSSSSSSSSSSSSSSSSSSSS Navigation Buttons SSSSSSSSSSSSSSSSSSSSSS

        #region btnPrevPatient_Click
        /// <summary>
        /// دكمه ی جابجایی بیمار جاری به بیمار قبلی
        /// </summary>
        private void btnPrevPatient_Click(object sender, EventArgs e)
        {
            #region Check User Permission If (_IsCurrentPatModified) Is True
            // اگر بیمار ویرایش شده بود
            if (_IsCurrentPatModified)
                // اگر كاربر اجازه تغییر صادر نكرد
                if (!CheckUserPermissionForNavigation()) return;
            #endregion

            #region If Form Current State Is AddingPatRef And _IsCurrentPatModified Is False
            // بررسی وضعیتی كه در حال ثبت بیمار می باشد
            if (CurrentPatientListID == 0)
            {
                Int32? LastPatient = Negar.DBLayerPMS.Patients.GetFirstOrLastPatientListID(true);
                // حالتی كه هیچ بیمار در سیستم وجود ندارد
                if (LastPatient == 0) CurrentPatientListID = 0;
                // حالتی كه بیمار در سیستم وجود دارد
                else
                {
                    CurrentPatientListID = Convert.ToInt32(LastPatient);
                    FormState = PatientFormStates.Viewing;
                }
                return;
            }
            #endregion

            // آزاد كردن بیمار جاری
            Negar.DBLayerPMS.Patients.ChangePatLock(_CurrentPatientData.ID, false);
            // بدست آوردن كد بیمار قبلی
            Int32? ID = Negar.DBLayerPMS.Patients.GetPrevOrNextPatID(CurrentPatientListID, false);
            // اگر بیمار قبلی وجود داشت و همچنین با بیمار جاری متفاوت بود بیمار جاری تغییر می كند
            if (ID != null && ID != CurrentPatientListID)
            {
                CurrentPatientListID = Convert.ToInt32(ID);
                FormState = PatientFormStates.Viewing;
            }
        }
        #endregion

        #region btnNextPatient_Click
        /// <summary>
        /// دكمه ی جابجایی بیمار جاری به بیمار بعدی
        /// </summary>
        private void btnNextPatient_Click(object sender, EventArgs e)
        {
            #region Check User Permission If (_IsCurrentPatModified) Is True
            // اگر بیمار ویرایش شده بود
            if (_IsCurrentPatModified)
                // اگر كاربر اجازه تغییر صادر نكرد
                if (!CheckUserPermissionForNavigation()) return;
            #endregion

            #region If Form Current State Is AddingPatRef And _IsCurrentPatModified Is False
            // بررسی وضعیتی كه در حال ثبت بیمار می باشد
            if (CurrentPatientListID == 0)
            {
                Int32? LastPatient = Negar.DBLayerPMS.Patients.GetFirstOrLastPatientListID(true);
                // حالتی كه هیچ بیمار در سیستم وجود ندارد
                if (LastPatient == null) CurrentPatientListID = 0;
                // حالتی كه بیمار در سیستم وجود دارد
                else
                {
                    CurrentPatientListID = Convert.ToInt32(LastPatient);
                    FormState = PatientFormStates.Viewing;
                }
                return;
            }
            #endregion

            // آزاد كردن بیمار جاری
            Negar.DBLayerPMS.Patients.ChangePatLock(_CurrentPatientData.ID, false);

            // بدست آوردن كد بیمار بعدی
            Int32? ID = Negar.DBLayerPMS.Patients.GetPrevOrNextPatID(CurrentPatientListID, true);
            // اگر بیمار بعدی وجود داشت و همچنین با بیمار جاری متفاوت بود بیمار جاری تغییر می كند
            if (ID != null && ID != CurrentPatientListID)
            {
                CurrentPatientListID = Convert.ToInt32(ID);
                FormState = PatientFormStates.Viewing;
            }
        }
        #endregion

        // SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS

        #region btnDeleteCurrentPatient_Click
        /// <summary>
        /// دكمه ی حذف بیمار جاری از بانك اطلاعات
        /// </summary>
        private void btnDeleteCurrentPatient_Click(object sender, EventArgs e)
        {
            if (FormState != PatientFormStates.Viewing || _CurrentPatientData.ID == 0) return;

            #region Check User Permission
            if (FormState == PatientFormStates.Viewing)
            {
                DialogResult Dr1 = PMBox.Show("آیا مایلید اطلاعات بیمار حذف شود؟", " هشدار",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (Dr1 == DialogResult.Yes)
                {
                    DialogResult Dr2 = PMBox.Show("آیا مطمئن هستید كه اطلاعات بیمار حذف شود؟" +
                        " پس از حذف اطلاعات پرونده بیمار كلیه اطلاعات مالی ، اطلاعات بیمه " +
                        "و همچنین اسناد بیمار حذف می گردد و امكان بازگشت آن وجود ندارد.", "هشدار!",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                    if (Dr2 == DialogResult.No) return;
                }
                else if (Dr1 == DialogResult.No) return;
            }
            #endregion

            Int32? ReturnValue = Negar.DBLayerPMS.Patients.DeletePatient(_CurrentPatientData.ID);
            // حالتی كه بیمار حذف نشده
            if (ReturnValue == 0) return;
            // حالتی كه بیمار حذف شده اما بیمار دیگری وجود ندارد
            if (ReturnValue == null) CurrentPatientListID = 0;
            // حالتی كه بیمار حذف شده و مقدار بیماری جدید برای نمایش بازگردانده شده است
            else CurrentPatientListID = Convert.ToInt32(ReturnValue);
        }
        #endregion

        #endregion

        #region Methods

        #region Boolean CheckUserPermissionForNavigation()
        /// <summary>
        /// تابعی برای مدیریت جابجایی بیمار در صورتی كه مقادیر فرم تغییر كرده باشد
        /// </summary>
        /// <returns>تعیین دریافت مجوز كاربر</returns>
        private Boolean CheckUserPermissionForNavigation()
        {
            DialogResult Dr = PMBox.Show("بدون ذخیره سازی تغییرات ، اطلاعات وارد شده از دست می رود.\n" +
                "آیا مایلید قبل از تغییر بیمار جاری ، اطلاعات وارد شده ثبت گردند؟", "هشدار!",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3);

            #region Pressed YES
            // در صورتی كه كاربر دكمه ی آری را فشار دهد ، پس از ذخیره سازی ، مقدار صحیح باز گردانده میشود
            if (Dr == DialogResult.Yes)
            {
                if (FormState == PatientFormStates.Adding)
                {
                    if (AddOrEditPatient(true)) return true;
                    return false;
                }
                if (FormState == PatientFormStates.Editing)
                {
                    if (AddOrEditPatient(false)) return true;
                    return false;
                }
            }
            #endregion

            #region Pressed NO
            // در صورتی كه كاربر دكمه ی خیر را فشار دهد ، بدون ذخیره سازی ، مقدار صحیح باز گردانده میشود.
            else if (Dr == DialogResult.No)
            {
                // در صورتی كه كاربر در حال ثبت بیمار جدید باشد و از ثبت منصرف شود ، بیمار جاری به آخرین بیمار تغییر می كند
                if (FormState == PatientFormStates.Adding)
                {
                    // بدست آوردن كد آخرین بیمار
                    Int32? NewPatientID = Negar.DBLayerPMS.Patients.GetFirstOrLastPatientListID(true);
                    // اگر بیماری وجود نداشت دوباره فرم به حالت افزودن بیمار می رود
                    if (NewPatientID == null) CurrentPatientListID = 0;
                    // اگر بیماری وجود داشت فرم به حالت نمایش آن بیمار می رود
                    else
                    {
                        CurrentPatientListID = Convert.ToInt32(NewPatientID);
                        FormState = PatientFormStates.Viewing;
                    }
                    // مقدار غطل بازگردانده می شود تا تابعی كه این تابع را فراخوانی كرده عملی انجام ندهد
                    return false;
                }
                return true;
            }
            #endregion

            // در صورتی كه كاربر دكمه ی انصراف را فشار دهد ، بدون ذخیره سازی ، مقدار غلط باز گردانده میشود.
            return false;
        }
        #endregion

        #endregion

    }
}