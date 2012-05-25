#region using

using System;
using System.Data;
using System.Data.Linq;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Negar;
using Negar.DBLayerPMS.DataLayer;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Forms.Admission.Classes;

#endregion

namespace Sepehr.Forms.Admission.Patients
{
    /// <summary>
    /// فرم مدیریت بیماران - بخش مدیریت اطلاعات بیمار
    /// </summary>
    internal partial class frmPatients
    {

        #region Event Handlers

        #region btnNewPatient_Click
        /// <summary>
        /// دكمه ی درخواست ثبت بیمار جدید یا ثبت بیمار وارد شده
        /// </summary>
        private void btnNewPatient_Click(object sender, EventArgs e)
        {
            // اگر فرم در حالت ثبت بیمار جدید بود:
            if (FormState == PatientFormStates.Adding)
            {
                // در این حالت بیمار ثبت شده و سپس فرم به حالت ثبت بیمار جدید می رود
                if (_IsCurrentPatModified)
                {
                    if (AddOrEditPatient(true)) FormState = PatientFormStates.Adding;
                }
                else PMBox.Show("اطلاعاتی برای ثبت بیمار وارد نشده است!\n" + "ابتدا اطلاعاتی برای پرونده بیمار وارد نمایید.",
                    "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            // اگر فرم در حالت ویرایش یك بیمار بود:
            else if (FormState == PatientFormStates.Editing)
            {
                // در این حالت بیمار ویرایش شده و سپس فرم به حالت ثبت بیمار جدید می رود
                if (AddOrEditPatient(false))
                {
                    // آزاد كردن بیمار جاری
                    Negar.DBLayerPMS.Patients.ChangePatLock(_CurrentPatientData.ID, false);
                    FormState = PatientFormStates.Adding;
                }
            }
            // اگر فرم در حالت نمایش یك بیمار بود:
            else if (FormState == PatientFormStates.Viewing)
            {
                // در این حالت فرم به حالت ثبت بیمار جدید می رود
                FormState = PatientFormStates.Adding;
            }
        }
        #endregion

        #region btnNewReferral_Click
        /// <summary>
        /// دكمه ی ثبت مراجعه جدید برای بیمار جاری
        /// </summary>
        private void btnNewReferral_Click(object sender, EventArgs e)
        {
            #region Adding State
            // اگر فرم در حالت ثبت بیمار جدید بود:
            if (FormState == PatientFormStates.Adding)
            {
                // در این حالت ابتدا بیمار ثبت شده و سپس فرم به حالت نمایش بیمار می رود
                // سپس فرم ثبت مراجعه جدید برای آن بیمار نمایش داده می شود
                if (_IsCurrentPatModified)
                {
                    if (AddOrEditPatient(true))
                    {
                        FormState = PatientFormStates.Viewing;
                        AdmitHelper.AdmitNewRef(CurrentPatientListID, null);
                        CurrentPatientListID = _CurrentPatientData.ID;
                    }
                }
                else PMBox.Show("اطلاعاتی برای ثبت بیمار وارد نشده است!\n" + "ابتدا اطلاعاتی برای پرونده بیمار وارد نمایید.",
                    "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            #endregion

            #region Editing State
            // اگر فرم در حالت ویرایش یك بیمار بود:
            else if (FormState == PatientFormStates.Editing)
            {
                // در این حالت بیمار ویرایش شده و فرم به حالت نمایش بیمار می رود
                // سپس فرم ثبت مراجعه جدید برای آن بیمار نمایش داده می شود
                if (AddOrEditPatient(false))
                {
                    FormState = PatientFormStates.Viewing;
                    // آزاد كردن بیمار جاری
                    Negar.DBLayerPMS.Patients.ChangePatLock(_CurrentPatientData.ID, false);
                    AdmitHelper.AdmitNewRef(CurrentPatientListID, null);
                    CurrentPatientListID = _CurrentPatientData.ID;
                }
            }
            #endregion

            #region Viewing State
            // اگر فرم در حالت نمایش یك بیمار بود:
            else if (FormState == PatientFormStates.Viewing)
            {
                // در این حالت فرم ثبت مراجعه جدید برای آن بیمار نمایش داده می شود
                FormState = PatientFormStates.Viewing;
                AdmitHelper.AdmitNewRef(CurrentPatientListID, null);
                CurrentPatientListID = _CurrentPatientData.ID;
            }
            #endregion
        }
        #endregion

        #region btnEditMode_Click
        /// <summary>
        /// دكمه ی ویرایش یا ثبت بیمار
        /// </summary>
        private void btnEditMode_Click(object sender, EventArgs e)
        {
            #region AddingPatRef State (btnEditMode => Add New Patient)
            // اگر فرم در حالت ثبت بیمار جدید بود:
            if (FormState == PatientFormStates.Adding)
            {
                // در این حالت در صورتی كه مقادیر روی فرم تغییر كرده باشند بیمار ثبت شده
                // و سپس فرم به حالت نمایش می رود
                if (_IsCurrentPatModified)
                { if (AddOrEditPatient(true)) FormState = PatientFormStates.Viewing; }
                else PMBox.Show("اطلاعاتی برای ثبت بیمار وارد نشده است!\n" + "ابتدا اطلاعاتی برای پرونده بیمار وارد نمایید.",
                    "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            #endregion

            #region Editing State (btnEditMode => Save)
            // اگر فرم در حالت ویرایش یك بیمار بود:
            else if (FormState == PatientFormStates.Editing)
            {
                // در این حالت در صورتی كه مقادیر روی فرم تغییر كرده باشند بیمار ویرایش شده
                // و سپس فرم به حالت نمایش می رود
                if (_IsCurrentPatModified)
                { if (AddOrEditPatient(false)) FormState = PatientFormStates.Viewing; }
                else FormState = PatientFormStates.Viewing;
                // آزاد كردن بیمار جاری
                Negar.DBLayerPMS.Patients.ChangePatLock(_CurrentPatientData.ID, false);
            }
            #endregion

            #region Viewing State (btnEditMode => Edit)
            // اگر فرم در حالت نمایش یك بیمار بود:
            else if (FormState == PatientFormStates.Viewing)
            {
                // در این حالت فرم در حالت نمایش است و به حالت ویرایش تغییر حالت می دهد
                if (!_CanEditPatient)
                {
                    PMBox.Show("كاربر جاری امكان ویرایش اطلاعات بیماران ثبت شده را ندارد!", "خطا!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                #region Check If Current Patient Is Lock
                // اینجا باید بررسی می شود كه مراجعه توسط كاربر دیگری ویرایش نگردد
                if (_HaveAdvancedLicense && !Negar.DBLayerPMS.Patients.CheckPatIsLock(_CurrentPatientData.ID)) return;
                // قفل كردن بیمار جاری برای ویرایش
                Negar.DBLayerPMS.Patients.ChangePatLock(_CurrentPatientData.ID, true);
                #endregion
                FormState = PatientFormStates.Editing;
            }
            #endregion
        }
        #endregion

        #endregion

        #region Methods

        #region @@@ internal Boolean AddNewPatient(Int32? SchAppointmentID) @@@
        /// <summary>
        /// تابعی برای تنظیم فرم برای حالت افزودن بیمار جدید
        /// </summary>
        /// <returns>صحت آماده سازی فرم</returns>
        internal Boolean AddNewPatient(Int32? SchAppointmentID)
        {
            // بررسی دسترسی افزودن بیمار جدید
            if (!_CanAddPatient)
            {
                PMBox.Show("كاربر جاری دسترسی لازم برای افزودن بیمار جدید را ندارد!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
            }
            PrepareControlSettings(false);
            CurrentPatientListID = 0;
            #region Set Sch Data
            _CurrentSchAppointmentID = SchAppointmentID;
            if (_CurrentSchAppointmentID != null)
            {
                try
                {
                    SchAppointments SchAppData = DBLayerIMS.Manager.DBML.SchAppointments.
                        Where(Data => Data.ID == _CurrentSchAppointmentID.Value).First();
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
                }
                #region Catch
                catch (Exception Ex)
                {
                    const String ErrorMessage = "امكان خواندن اطلاعات نوبت بیمار از بانك اطلاعات ممكن نیست.\n" +
                        "موارد زیر را بررسی نمایید:\n" +
                        "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogManager.SaveLogEntry("Sepehr", "Admission Forms", Ex.Message + "\n" +
                        Ex.StackTrace, EventLogEntryType.Error); return false;
                }
                #endregion
                _IsCurrentPatModified = true;
            }
            #endregion
            return true;
        }
        #endregion

        #region @@@ internal Boolean EditPatient(Int32 PatID, Boolean IsSingleEdit) @@@
        /// <summary>
        /// تابعی برای ویرایش یك بیمار با كلید بیمار
        /// </summary>
        /// <param name="PatID">كلید بیمار</param>
        /// <param name="IsSingleEdit">تعیین امكان جابجایی بین بیماران</param>
        /// <returns>صحت آماده سازی فرم</returns>
        internal Boolean EditPatient(Int32 PatID, Boolean IsSingleEdit)
        {
            PrepareControlSettings(IsSingleEdit);
            CurrentPatientListID = PatID;
            if (IsDisposed) { Close(); return false; }
            // اگر كاربر امكان ویرایش یك بیمار را نداشته باشد ، فرم در حالت نمایش باز می شود
            if (!_CanEditPatient) FormState = PatientFormStates.Viewing;
            // اگر مدیریت همزمانی باید اعمال شود د بیمار جاری قفل باشد ، فرم در حالت نمایش باز می شود
            else if (_HaveAdvancedLicense && !Negar.DBLayerPMS.Patients.CheckPatIsLock(CurrentPatientListID))
                FormState = PatientFormStates.Viewing;
            else
            {
                Negar.DBLayerPMS.Patients.ChangePatLock(_CurrentPatientData.ID, true);
                FormState = PatientFormStates.Editing;
            }
            _IsCurrentPatModified = false;
            return true;
        }
        #endregion

        // ==== توابع مدیریت افزودن یا ثبت اطلاعات پرونده بیمار ====

        #region Boolean ValidatePatientData()
        /// <summary>
        /// تابعی برای بررسی ورود صحیح اطلاعات فرم
        /// </summary>
        /// <returns>کامل بودن یا نبودن</returns>
        private Boolean ValidatePatientData()
        {
            #region Tab1
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
            if (_ShouldEnterBirthDay && txtAgeYear.ValueObject == null)
            {
                PMBox.Show("وارد كردن تاریخ تولد یا سن بیمارضروری است!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (_ShouldEnterMaritualStatus && cBoxMaried.Checked == false && cboxSingle.Checked == false)
            {
                PMBox.Show("وارد كردن وضعیت تاهل بیمار ضروری است!",
                    "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (_ShouldEnterFatherName && String.IsNullOrEmpty(txtFatherName.Text.Trim()))
            {
                PMBox.Show("وارد كردن نام پدربیمار ضروری است!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (_ShouldEnterNationalCode && String.IsNullOrEmpty(txtNationalCode.Text.Trim()))
            {
                PMBox.Show("وارد كردن شماره شناسنامه بیمار ضروری است!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (_ShouldEnterNationalID && String.IsNullOrEmpty(txtNationalID.Text.Trim()))
            {
                PMBox.Show("وارد كردن كد ملی بیمار ضروری است!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (_ShouldEnterBirthLocation && String.IsNullOrEmpty(txtBirthLocation.Text.Trim()))
            {
                PMBox.Show("وارد كردن محل تولد بیمار ضروری است!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBirthLocation.Focus();
                return false;
            }
            if (_ShouldEnterJob && cboJob.SelectedIndex == 0)
            {
                PMBox.Show("وارد كردن شغل بیمار ضروری است!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboJob.Focus();
                return false;
            }
            #endregion

            #region Tab2
            if (_ShouldEnterTel1 && String.IsNullOrEmpty(txtTel1.Text.Trim()))
            {
                PMBox.Show("وارد كردن شماره تلفن اول بیمار ضروری است!", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (_ShouldEnterTel2 && String.IsNullOrEmpty(txtTel2.Text.Trim()))
            {
                PMBox.Show("وارد كردن شماره تلفن دوم بیمار ضروری است!", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (_ShouldEnterLocation && cboCity.SelectedIndex < 1)
            {
                PMBox.Show("وارد كردن محل سكونت بیمار ضروری است!", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboCountry.Focus();
                return false;
            }
            if (_ShouldEnterEmail && String.IsNullOrEmpty(txtEmail.Text.Trim()))
            {
                PMBox.Show("وارد كردن پست الكترونیكی بیمار تلفن ضروری است!", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return false;
            }
            if (_ShouldEnterZipCode && String.IsNullOrEmpty(txtZipCode.Text.Trim()))
            {
                PMBox.Show("وارد كردن كد پستی بیمار ضروری است!", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtZipCode.Focus();
                return false;
            }
            if (_ShouldEnterAddress && String.IsNullOrEmpty(txtAddress.Text.Trim()))
            {
                PMBox.Show("وارد كردن آدرس بیمار ضروری است!", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAddress.Focus();
                return false;
            }
            #endregion
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
            if (!ValidatePatientData()) return false;

            #region Search For Same Patient In AddingPatRef State
            if (IsAdding && _ShouldSearchForSamePatient)
            {
                frmSimilarPatients MyForm = new frmSimilarPatients(txtFirstName.Text.Trim(), txtLastName.Text.Trim());
                if (MyForm.DialogResult == DialogResult.OK)
                { CurrentPatientListID = MyForm.SelectedPatientListID; return true; }
            }
            #endregion

            #region Find Patient EnglishName
            if (_ShouldSaveEnglishName)
            {
                String EnglishFirstName = Negar.DBLayerPMS.Patients.GetEnglishName(txtFirstName.Text, true);
                String EnglishLastName = Negar.DBLayerPMS.Patients.GetEnglishName(txtLastName.Text, false);
                if (String.IsNullOrEmpty(EnglishFirstName)) new frmNamesTranslator(txtFirstName.Text.Trim().Normalize(), true);
                if (String.IsNullOrEmpty(EnglishLastName)) new frmNamesTranslator(txtLastName.Text.Trim().Normalize(), false);
            }
            #endregion

            #region Prepare Patient Data

            #region IsMale & IsMaried CheckBoxes
            Boolean? IsMale = null;
            if (cBoxMale.Checked) IsMale = true;
            else if (cBoxFemale.Checked) IsMale = false;

            Boolean? IsMaried = null;
            if (cBoxMaried.Checked) IsMaried = true;
            else if (cboxSingle.Checked) IsMaried = false;
            #endregion

            #region CityID
            Int16? CityID = null;
            if (cboCity.SelectedValue != null) CityID = Convert.ToInt16(cboCity.SelectedValue);
            #endregion

            #region JobID
            short? JobID = null;
            if (cboJob.SelectedValue != null) JobID = Convert.ToInt16(cboJob.SelectedValue);
            #endregion

            #region BirthDate
            DateTime? BirthDate = null;
            if (cBoxEnterPatAge.Checked)
            {
                if (txtAgeYear.ValueObject != null)
                    BirthDate = DateTime.Now.AddYears(-1 * txtAgeYear.Value);
            }
            else
            {
                if (DateInputBirthDate.SelectedDateTime != DateTime.MinValue)
                    BirthDate = DateInputBirthDate.SelectedDateTime;
            }
            #endregion

            #endregion

            #region Add Or Edit Data
            if (IsAdding)
            {
                _CurrentPatientData.PatientID = Negar.DBLayerPMS.Patients.GenerateNewPatientID();
                if (String.IsNullOrEmpty(_CurrentPatientData.PatientID)) return false;
            }
            _CurrentPatientData.FirstName = txtFirstName.Text.Trim().Normalize();
            _CurrentPatientData.LastName = txtLastName.Text.Trim().Normalize();
            _CurrentPatientData.IsMale = IsMale;
            _CurrentPatientData.BirthDate = BirthDate;
            if (IsAdding) Negar.DBLayerPMS.Manager.DBML.PatLists.InsertOnSubmit(_CurrentPatientData);
            if (_CurrentPatientData.PatDetail == null) _CurrentPatientData.PatDetail = new PatDetail();
            _CurrentPatientData.PatDetail.PatientListIX = _CurrentPatientData.ID;
            if (String.IsNullOrEmpty(_CurrentPatientData.PatDetail.EngFirstName))
                _CurrentPatientData.PatDetail.EngFirstName = Negar.DBLayerPMS.Patients.GetEnglishName(txtFirstName.Text, true);
            if (String.IsNullOrEmpty(_CurrentPatientData.PatDetail.EngLastName))
                _CurrentPatientData.PatDetail.EngLastName = Negar.DBLayerPMS.Patients.GetEnglishName(txtLastName.Text, false);
            _CurrentPatientData.PatDetail.IsMaried = IsMaried;
            _CurrentPatientData.PatDetail.FatherName = txtFatherName.Text.Trim().Normalize();
            _CurrentPatientData.PatDetail.IDNo = txtNationalID.Text.Trim().Normalize();
            _CurrentPatientData.PatDetail.NationalID = txtNationalCode.Text.Trim();
            _CurrentPatientData.PatDetail.CityIX = CityID;
            _CurrentPatientData.PatDetail.BirthLocation = txtBirthLocation.Text.Trim().Normalize();
            _CurrentPatientData.PatDetail.JobIX = JobID;
            _CurrentPatientData.PatDetail.TelNo1 = txtTel1.Text.Trim().Normalize();
            _CurrentPatientData.PatDetail.TelNo2 = txtTel2.Text.Trim().Normalize();
            _CurrentPatientData.PatDetail.Address = txtAddress.Text.Trim().Normalize();
            _CurrentPatientData.PatDetail.ZipCode = txtZipCode.Text.Trim().Normalize();
            _CurrentPatientData.PatDetail.Email = txtEmail.Text.Trim().Normalize();
            if (!IsAdding)
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

            #region Save Appointment Data
            if (IsAdding && _CurrentSchAppointmentID != null)
            {
                try
                {
                    SchAppointments SchAppointment = DBLayerIMS.Manager.DBML.SchAppointments.
                        Where(Data => Data.ID == _CurrentSchAppointmentID.Value).First();
                    SchAppointment.PatientIX = _CurrentPatientData.ID;
                    DBLayerIMS.Manager.DBML.SubmitChanges();
                }
                #region Catch
                catch (Exception Ex)
                {
                    const String ErrorMessage = "ارتباط بیمار ثبت شده با نوبت مورد نظر در بانك اطلاعات ممكن نیست.\n" +
                        "موارد زیر را بررسی نمایید:\n" +
                        "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogManager.SaveLogEntry("Sepehr", "Admission Forms", Ex.Message + "\n" +
                        Ex.StackTrace, EventLogEntryType.Error);
                }
                #endregion
            }
            _CurrentSchAppointmentID = null;
            #endregion

            #region Insert Pat Additional Data
            // افزودن فیلد های اطلاعاتی اضافی
            if (DBLayerIMS.Referrals.PatAddinColsList.Count != 0)
                try
                {
                    foreach (PatAdditionalColumn column in DBLayerIMS.Referrals.PatAddinColsList)
                    {
                        if (column.TypeID == 0)
                            DBLayerIMS.Manager.DBML.SP_InsertPatAddinStringData(_CurrentPatientData.ID, column.FieldName,
                            TabPanelAddInData.Controls["txt" + column.FieldName].Text);
                        else if (column.TypeID == 1)
                            DBLayerIMS.Manager.DBML.SP_InsertPatAddinBoolData(_CurrentPatientData.ID, column.FieldName,
                                ((CheckBoxX)TabPanelAddInData.Controls["cBox" + column.FieldName]).Checked);
                        else if (column.TypeID == 2)
                            DBLayerIMS.Manager.DBML.SP_InsertPatIntData(_CurrentPatientData.ID, column.FieldName,
                                ((Int32?)((IntegerInput)TabPanelAddInData.Controls["txt" + column.FieldName]).ValueObject));
                        else if (column.TypeID == 3)
                            DBLayerIMS.Manager.DBML.SP_InsertPatIntData(_CurrentPatientData.ID, column.FieldName,
                                ((Int16?)((ComboBox)TabPanelAddInData.Controls["cbo" + column.FieldName]).SelectedValue));
                    }
                }
                #region Catch
                catch (Exception Ex)
                {
                    const String ErrorMessage = "امكان ثبت اطلاعات پویا بیمار در بانك اطلاعات ممكن نیست.\n" +
                        "موارد زیر را بررسی نمایید:\n" +
                        "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogManager.SaveLogEntry("Sepehr", "Admission Forms", Ex.Message + "\n" +
                        Ex.StackTrace, EventLogEntryType.Error);
                }
                #endregion
            #endregion

            #endregion

            _IsCurrentPatModified = false;
            return true;
        }
        #endregion

        // ==== توابع خواندن اطلاعات بیمار از بانك اطلاعات ====

        #region Boolean FillPatientDataInControlsByID(Int32 PatientListID)
        /// <summary>
        /// تابعی برای به روز رسانی داده های كنترل های فرم بر اساس اطلاعات بیمار
        /// </summary>
        /// <param name="PatientListID">كلید بیمار</param>
        private Boolean FillPatientDataInControlsByID(Int32 PatientListID)
        {
            _CurrentPatientData = Negar.DBLayerPMS.Patients.GetPatFullDataByPatListID(PatientListID);
            if (_CurrentPatientData == null) return false;

            #region Set Gender Radio Buttons
            if ((_CurrentPatientData.IsMale == null))
            {
                cBoxMale.Checked = false;
                cBoxFemale.Checked = false;
            }
            else
            {
                if (Convert.ToBoolean(_CurrentPatientData.IsMale)) cBoxMale.Checked = true;
                else cBoxFemale.Checked = true;
            }
            #endregion

            #region Set Mariage Status Radio Buttons
            if (_CurrentPatientData.PatDetail == null || _CurrentPatientData.PatDetail.IsMaried == null)
            {
                cBoxMaried.Checked = false;
                cboxSingle.Checked = false;
            }
            else
            {
                if (_CurrentPatientData.PatDetail.IsMaried.Value) cBoxMaried.Checked = true;
                else cboxSingle.Checked = true;
            }
            #endregion

            #region Set Patient Location
            // در حالتی که برای بیمار شهر انتخاب نشده
            if (_CurrentPatientData.PatDetail == null || _CurrentPatientData.PatDetail.CityIX == null)
            {
                cboCountry.DataSource = Negar.DBLayerPMS.Patients.CountriesList.
                    Where(Data => Data.IsActive == true).ToList();
                cboCountry.SelectedIndex = 0;
            }
            else
            {
                cboCountry.SelectedIndexChanged -= (cboCountry_SelectedIndexChanged);
                cboState.SelectedIndexChanged -= (cboState_SelectedIndexChanged);
                Int16 CurrentCityStateID = Negar.DBLayerPMS.Patients.CitiesList.
                    Where(CityData => CityData.ID == _CurrentPatientData.PatDetail.CityIX.Value).First().StateIX.Value;
                Int16 CurrentCityCountryID = Negar.DBLayerPMS.Patients.StatesList.
                    Where(StateData => StateData.ID == CurrentCityStateID).First().CountryIX.Value;
                // +++++++++++++++++++++++
                cboCity.DataSource = Negar.DBLayerPMS.Patients.CitiesList.
                    Where(Data => Data.StateIX == CurrentCityStateID || Data.StateIX == -1).ToList();
                cboCity.SelectedValue = _CurrentPatientData.PatDetail.CityIX;
                // +++++++++++++++++++++++
                cboState.DataSource = Negar.DBLayerPMS.Patients.StatesList.
                    Where(Data => Data.CountryIX == CurrentCityCountryID || Data.CountryIX == -1).ToList();
                cboState.SelectedValue = CurrentCityStateID;
                // +++++++++++++++++++++++
                cboCountry.DataSource = Negar.DBLayerPMS.Patients.CountriesList.
                    Where(Data => Data.IsActive == true || Data.ID == CurrentCityCountryID).ToList();
                cboCountry.SelectedValue = CurrentCityCountryID;
                cboState.SelectedIndexChanged += cboState_SelectedIndexChanged;
                cboCountry.SelectedIndexChanged += cboCountry_SelectedIndexChanged;
            }
            #endregion

            #region Set Patient Job
            if (_CurrentPatientData.PatDetail == null || _CurrentPatientData.PatDetail.JobIX == null)
            {
                cboJob.DataSource =
                    Negar.DBLayerPMS.Patients.PatientsJobsList.Where(Data => Data.IsActive == true).ToList();
                cboJob.SelectedIndex = 0;
            }
            else
            {
                cboJob.DataSource = Negar.DBLayerPMS.Patients.PatientsJobsList.
                    Where(Data => Data.IsActive == true || Data.ID == _CurrentPatientData.PatDetail.JobIX).ToList();
                cboJob.SelectedValue = _CurrentPatientData.PatDetail.JobIX;
            }
            #endregion

            #region Fill Other Controls

            #region Patient ID
            if (!txtPatientID.IsDisposed)
            {
                if (_CurrentPatientData.PatientID != null)
                    txtPatientID.TextBox.Text = _CurrentPatientData.PatientID;
                else txtPatientID.TextBox.Text = String.Empty;
            }
            #endregion

            #region First Name
            if (!txtFirstName.IsDisposed)
            {
                if (_CurrentPatientData.FirstName != null) txtFirstName.Text = _CurrentPatientData.FirstName;
                else txtFirstName.Text = String.Empty;
            }
            #endregion

            #region Last Name
            if (!txtLastName.IsDisposed)
            {
                if (_CurrentPatientData.LastName != null) txtLastName.Text = _CurrentPatientData.LastName;
                else txtLastName.Text = String.Empty;
            }
            #endregion

            #region Birth Date
            if (!DateInputBirthDate.IsDisposed)
            {
                if ((_CurrentPatientData.BirthDate) != null)
                {
                    txtAgeYear.Value = DateTime.Now.Year - _CurrentPatientData.BirthDate.Value.Year;
                    DateInputBirthDate.SelectedDateTime = Convert.ToDateTime(_CurrentPatientData.BirthDate);
                }
                else
                {
                    txtAgeYear.ValueObject = null;
                    DateInputBirthDate.ResetSelectedDateTime();
                }
            }
            #endregion

            #region Email Address
            if (!txtEmail.IsDisposed)
            {
                if (_CurrentPatientData.PatDetail == null || _CurrentPatientData.PatDetail.Email == null)
                    txtEmail.Text = String.Empty;
                else txtEmail.Text = _CurrentPatientData.PatDetail.Email;
            }
            #endregion

            #region Father Name
            if (!txtFatherName.IsDisposed)
            {
                if (_CurrentPatientData.PatDetail == null || _CurrentPatientData.PatDetail.FatherName == null)
                    txtFatherName.Text = String.Empty;
                else txtFatherName.Text = _CurrentPatientData.PatDetail.FatherName;
            }
            #endregion

            #region National ID
            if (!txtNationalCode.IsDisposed)
            {
                if (_CurrentPatientData.PatDetail == null || _CurrentPatientData.PatDetail.NationalID == null)
                    txtNationalCode.Text = String.Empty;
                else txtNationalCode.Text = _CurrentPatientData.PatDetail.NationalID;
            }
            #endregion

            #region ID No
            if (!txtNationalID.IsDisposed)
            {
                if (_CurrentPatientData.PatDetail == null || _CurrentPatientData.PatDetail.IDNo == null)
                    txtNationalID.Text = String.Empty;
                else txtNationalID.Text = _CurrentPatientData.PatDetail.IDNo;
            }
            #endregion

            #region Tel 1
            if (!txtTel1.IsDisposed)
            {
                if (_CurrentPatientData.PatDetail == null || _CurrentPatientData.PatDetail.TelNo1 == null)
                    txtTel1.Text = String.Empty;
                else txtTel1.Text = _CurrentPatientData.PatDetail.TelNo1;
            }
            #endregion

            #region Tel 2
            if (!txtTel2.IsDisposed)
            {
                if (_CurrentPatientData.PatDetail == null || _CurrentPatientData.PatDetail.TelNo2 == null)
                    txtTel2.Text = String.Empty;
                else txtTel2.Text = _CurrentPatientData.PatDetail.TelNo2;
            }
            #endregion

            #region Zip Code
            if (!txtZipCode.IsDisposed)
            {
                if (_CurrentPatientData.PatDetail == null || _CurrentPatientData.PatDetail.ZipCode == null)
                    txtZipCode.Text = String.Empty;
                else txtZipCode.Text = _CurrentPatientData.PatDetail.ZipCode;
            }
            #endregion

            #region Address
            if (!txtAddress.IsDisposed)
            {
                if (_CurrentPatientData.PatDetail == null || _CurrentPatientData.PatDetail.Address == null)
                    txtAddress.Text = String.Empty;
                else txtAddress.Text = _CurrentPatientData.PatDetail.Address;
            }
            #endregion

            #endregion

            #region Fill Additional Data
            if (TabAddInData != null && TabAddInData.Visible && DBLayerIMS.Referrals.PatAddinColsList.Count != 0)
            {
                DataTable TempDataSet = DBLayerIMS.Manager.ExecuteQuery(
                    "EXECUTE [ImagingSystem].[Referrals].[SP_SelectPatAdditionalData] " + PatientListID, 5);
                if (TempDataSet == null)
                {
                    const String ErrorMessage = "امكان خواندن اطلاعات اضافی بیمار از بانك اطلاعات ممكن نیست.\n" +
                        "موارد زیر را بررسی نمایید:\n" +
                        "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
                }
                if (TempDataSet.Rows.Count != 0)
                    foreach (PatAdditionalColumn column in DBLayerIMS.Referrals.PatAddinColsList)
                    {
                        if (column.TypeID == 0)
                            TabPanelAddInData.Controls["txt" + column.FieldName].Text =
                                TempDataSet.Rows[0][column.FieldName].ToString();
                        else if (column.TypeID == 1)
                            ((CheckBoxX)TabPanelAddInData.Controls["cBox" + column.FieldName]).Checked =
                                Convert.ToBoolean(TempDataSet.Rows[0][column.FieldName]);
                        else if (column.TypeID == 2)
                        {
                            Object Value = TempDataSet.Rows[0][column.FieldName];
                            if (Value == null || Value == DBNull.Value)
                                ((IntegerInput)TabPanelAddInData.Controls["txt" + column.FieldName]).ValueObject = null;
                            else ((IntegerInput)TabPanelAddInData.Controls["txt" + column.FieldName]).ValueObject = (Int32?)Value;
                        }
                        else if (column.TypeID == 3)
                        {
                            Object Value = TempDataSet.Rows[0][column.FieldName];
                            if (Value == null || Value == DBNull.Value)
                                ((ComboBox)TabPanelAddInData.Controls["cbo" + column.FieldName]).SelectedIndex = 0;
                            else ((ComboBox)TabPanelAddInData.Controls["cbo" + column.FieldName]).SelectedValue =
                                (Int16?)Value;
                        }
                    }
                else foreach (PatAdditionalColumn column in DBLayerIMS.Referrals.PatAddinColsList)
                    {
                        if (column.TypeID == 0)
                            TabPanelAddInData.Controls["txt" + column.FieldName].Text = String.Empty;
                        else if (column.TypeID == 1)
                            ((CheckBoxX)TabPanelAddInData.Controls["cBox" + column.FieldName]).Checked = false;
                        else if (column.TypeID == 2)
                            ((IntegerInput)TabPanelAddInData.Controls["txt" + column.FieldName]).ValueObject = null;
                        else if (column.TypeID == 3)
                            ((ComboBox)TabPanelAddInData.Controls["cbo" + column.FieldName]).SelectedIndex = 0;
                    }
            }
            #endregion

            if (!FillRefListDataGridView(PatientListID)) return false;
            _IsCurrentPatModified = false;
            return true;
        }
        #endregion

        #region Boolean FillRefListDataGridView(Int32 PatientListID)
        /// <summary>
        /// تابع به روز رسانی اطلاعات مراجعات كاربر
        /// </summary>
        /// <param name="PatientListID">كلید بیمار</param>
        private Boolean FillRefListDataGridView(Int32 PatientListID)
        {
            try
            {
                IQueryable<RefList> TempData = DBLayerIMS.Manager.DBML.RefLists.
                    Where(Data => Data.PatientIX == PatientListID);
                DBLayerIMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, TempData);
                dgvData.DataSource = TempData.ToList();
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان خواندن اطلاعات مراجعات بیمار جاری از بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Admission Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion
            return true;
        }
        #endregion

        #region Boolean ManageAdmit()
        /// <summary>
        /// مدیریت ثبت بیمار قبل از اقدامات ثانویه
        /// </summary>
        private Boolean ManageAdmit()
        {
            #region AddingPatRef State (btnEditMode => Add New Patient)
            // اگر فرم در حالت ثبت بیمار جدید بود:
            if (FormState == PatientFormStates.Adding)
            {
                // در این حالت در صورتی كه مقادیر روی فرم تغییر كرده باشند بیمار ثبت شده
                // و سپس فرم به حالت نمایش می رود
                if (_IsCurrentPatModified)
                { if (!AddOrEditPatient(true)) return false; }
                else
                {
                    PMBox.Show("اطلاعاتی برای ثبت بیمار وارد نشده است!\n" + "ابتدا اطلاعاتی برای پرونده بیمار وارد نمایید.",
                        "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Stop); return false;
                }
            }
            #endregion

            #region Editing State (btnEditMode => Save)
            // اگر فرم در حالت ویرایش یك بیمار بود:
            else if (FormState == PatientFormStates.Editing)
            {
                // در این حالت در صورتی كه مقادیر روی فرم تغییر كرده باشند بیمار ویرایش شده
                // و سپس فرم به حالت نمایش می رود
                if (_IsCurrentPatModified)
                { if (!AddOrEditPatient(false)) return false; }
                // آزاد كردن بیمار جاری
                Negar.DBLayerPMS.Patients.ChangePatLock(_CurrentPatientData.ID, false);
            }
            #endregion

            FormState = PatientFormStates.Viewing;
            return true;
        }
        #endregion

        #endregion

    }
}