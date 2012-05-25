#region using

using System;
using System.Data.Linq;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Negar;
using Sepehr.DBLayerIMS.DataLayer;

#endregion

namespace Sepehr.Forms.Admission.Referrals
{
    /// <summary>
    /// فرمان های مربوط به جابجایی بیمار یا مراجعه جاری در فرم
    /// </summary>
    internal partial class frmPatRefManager
    {

        #region Event Handlers

        #region txtPatientID_KeyPress
        /// <summary>
        /// روال مدیریت شماره بیمار وارد شده برای جابجایی بیمار
        /// </summary>
        private void txtPatientID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\r' || String.IsNullOrEmpty(txtPatientID.TextBox.Text.Trim())) return;
            if (!ManageNavigation()) return;
            txtPatientID.Text = txtPatientID.Text.Trim();
            Int32? PatientListID = Negar.DBLayerPMS.Patients.GetPatListIDByPatientID(txtPatientID.TextBox.Text);
            if (PatientListID == 0) return;
            if (PatientListID == null)
            {
                PMBox.Show("بیماری با كد وارد شده وجود ندارد!", "خطا!",
                  MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            Int32? PatientLastRefID = DBLayerIMS.Referrals.GetPatFirstOrLastRefID(PatientListID.Value, true);
            if (PatientLastRefID == null) return;
            if (PatientLastRefID == 0)
            {
                PMBox.Show("بیمار انتخاب شده دارای مراجعه نمی باشد!", "خطا!",
                  MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            if (CurrentPatientListID != PatientListID.Value)
            {
                CurrentPatientListID = PatientListID.Value;
                CurrentRefID = PatientLastRefID.Value;
                CurrentFormState = RefFormState.Viewing;
            }
        }
        #endregion

        #region btnPrevPatient_Click
        /// <summary>
        /// روال جابجایی بیمار جاری به بیمار قبلی
        /// </summary>
        private void btnPrevPatient_Click(object sender, EventArgs e)
        {
            if (!ManageNavigation()) return;
            // بدست آوردن كد بیمار قبلی
            Int32? PrevPatientListID;

            #region CurrentFormState == RefFormState.AddingPatRef
            // اگر بیمار جاری در حالت افزودن باشد ، از آخرین بیمار به دنبال بیمارانی كه دارای مراجعه هستند خواهد گشت
            if (CurrentFormState == RefFormState.AddingPatRef)
            {
                PrevPatientListID = Negar.DBLayerPMS.Patients.GetFirstOrLastPatientListID(true);
                // اگر بیمار قبلی وجود نداشت ، عملیات متوقف می شود
                if (PrevPatientListID == 0) return;
                while (true)
                {
                    // ابتدا بررسی می شود كه بیمار جاری آخرین مراجعه دارد یا خیر
                    Int32? PatientLastRefID = DBLayerIMS.Referrals.GetPatFirstOrLastRefID(PrevPatientListID.Value, true);
                    if (PatientLastRefID == null) return;
                    // اگر آخرین مراجعه وجود داشت ، بیمار نمایش داده می شود
                    if (PatientLastRefID != 0)
                    {
                        CurrentPatientListID = PrevPatientListID.Value; // ابتدا بیمار جاری تغییر می كند
                        CurrentRefID = PatientLastRefID.Value; // سپس آخرین مراجعه ی بیمار نمایش داده می شود
                        CurrentFormState = RefFormState.Viewing;
                        break;
                    }
                    PrevPatientListID = Negar.DBLayerPMS.Patients.GetPrevOrNextPatID(PrevPatientListID.Value, false);
                }
            }
            #endregion

            #region Other Form States
            // اگر فرم در سایر حالات خود باشد
            else
            {
                PrevPatientListID = Negar.DBLayerPMS.Patients.GetPrevOrNextPatID(CurrentPatientListID, false);
                while (true)
                {
                    // اگر بیمار قبلی وجود نداشت یا با بیمار جاری یكسان بود ، عملیات متوقف می شود
                    if (PrevPatientListID == null || PrevPatientListID == 0 || PrevPatientListID == CurrentPatientListID) return;
                    // ابتدا بررسی می شود كه بیمار جاری آخرین مراجعه دارد یا خیر
                    Int32? PatientLastRefID = DBLayerIMS.Referrals.GetPatFirstOrLastRefID(PrevPatientListID.Value, true);
                    if (PatientLastRefID == null) return;
                    // اگر آخرین مراجعه وجود داشت و با مراجعه ی فعلی متفاوت بود
                    if (PatientLastRefID != 0 && PatientLastRefID != CurrentRefID)
                    {
                        CurrentPatientListID = PrevPatientListID.Value; // ابتدا بیمار جاری تغییر می كند
                        CurrentRefID = PatientLastRefID.Value; // سپس مراجعه ی جاری تغییر می كند
                        CurrentFormState = RefFormState.Viewing;
                        break;
                    }
                    // اگر حلقه به آخرین بیمار رسیده باشد ، عملیات جستجو متوقف می شود
                    // و به این معنی است كه بیماری با مراجعه پیدا نشده
                    if (PrevPatientListID == Negar.DBLayerPMS.Patients.GetFirstOrLastPatientListID(false)) break;
                    // در غیر اینصورت بیمار بعدی پیدا شده و حلقه ادامه می یابد
                    PrevPatientListID = Negar.DBLayerPMS.Patients.GetPrevOrNextPatID(PrevPatientListID.Value, false);
                }
            }
            #endregion
        }
        #endregion

        #region btnNextPatient_Click
        /// <summary>
        /// روال جابجایی بیمار جاری به بیمار بعدی
        /// </summary>
        private void btnNextPatient_Click(object sender, EventArgs e)
        {
            if (!ManageNavigation()) return;
            // بدست آوردن كد بیمار بعدی
            Int32? NextPatientListID;

            #region CurrentFormState == RefFormState.AddingPatRef
            // اگر بیمار جاری در حالت افزودن باشد ، از آخرین بیمار به دنبال بیمارانی كه دارای مراجعه هستند خواهد گشت
            if (CurrentFormState == RefFormState.AddingPatRef)
            {
                NextPatientListID = Negar.DBLayerPMS.Patients.GetFirstOrLastPatientListID(true);
                // اگر بیمار بعدی وجود نداشت ، عملیات متوقف می شود
                if (NextPatientListID == 0) return;
                while (true)
                {
                    // ابتدا بررسی می شود كه بیمار جاری آخرین مراجعه دارد یا خیر
                    Int32? PatientLastRefID = DBLayerIMS.Referrals.GetPatFirstOrLastRefID(NextPatientListID.Value, true);
                    if (PatientLastRefID == null) return;
                    // اگر آخرین مراجعه وجود داشت ، بیمار نمایش داده می شود
                    if (PatientLastRefID != 0)
                    {
                        CurrentPatientListID = NextPatientListID.Value; // ابتدا بیمار جاری تغییر می كند
                        CurrentRefID = PatientLastRefID.Value; // سپس آخرین مراجعه ی بیمار نمایش داده می شود
                        CurrentFormState = RefFormState.Viewing;
                        break;
                    }
                    NextPatientListID = Negar.DBLayerPMS.Patients.GetPrevOrNextPatID(NextPatientListID.Value, true);
                }
            }
            #endregion

            #region Other Form States
            // اگر فرم در سایر حالات خود باشد
            else
            {
                NextPatientListID = Negar.DBLayerPMS.Patients.GetPrevOrNextPatID(CurrentPatientListID, true);
                while (true)
                {
                    // اگر بیمار بعدی وجود نداشت یا با بیمار جاری یكسان بود ، عملیات متوقف می شود
                    if (NextPatientListID == null || NextPatientListID == 0 || NextPatientListID == CurrentPatientListID) return;
                    // ابتدا بررسی می شود كه بیمار جاری آخرین مراجعه دارد یا خیر
                    Int32? PatientLastRefID = DBLayerIMS.Referrals.GetPatFirstOrLastRefID(NextPatientListID.Value, true);
                    if (PatientLastRefID == null) return;
                    // اگر آخرین مراجعه وجود داشت و با مراجعه ی فعلی متفاوت بود
                    if (PatientLastRefID != 0 && PatientLastRefID != CurrentRefID)
                    {
                        CurrentPatientListID = NextPatientListID.Value; // ابتدا بیمار جاری تغییر می كند
                        CurrentRefID = PatientLastRefID.Value; // سپس مراجعه ی جاری تغییر می كند
                        CurrentFormState = RefFormState.Viewing;
                        break;
                    }
                    // اگر حلقه به آخرین بیمار رسیده باشد ، عملیات جستجو متوقف می شود
                    // و به این معنی است كه بیماری با مراجعه پیدا نشده
                    if (NextPatientListID == Negar.DBLayerPMS.Patients.GetFirstOrLastPatientListID(true)) break;
                    // در غیر اینصورت بیمار بعدی پیدا شده و حلقه ادامه می یابد
                    NextPatientListID = Negar.DBLayerPMS.Patients.GetPrevOrNextPatID(NextPatientListID.Value, true);
                }
            }
            #endregion
        }
        #endregion

        #region btnPrevRef_Click
        /// <summary>
        /// دكمه ی جابجایی مراجعه ی بیمار جاری به مراجعه ی قبلی آن بیمار
        /// </summary>
        private void btnPrevRef_Click(object sender, EventArgs e)
        {
            if (!ManageNavigation()) return;
            // بدست آوردن كد مراجعه ی قبلی بیمار جاری
            Int32? PrevRefID = DBLayerIMS.Referrals.GetPatRefNextOrPrevRefID(CurrentRefID, false);
            // اگر مراجعه ی قبلی وجود داشت و همچنین با مراجعه ی جاری متفاوت بود
            // مراجعه ی جاری تغییر می كند و در فرم نمایش داده می شود
            if (PrevRefID != null && PrevRefID != 0 && PrevRefID != CurrentRefID)
            {
                CurrentRefID = PrevRefID.Value;
                CurrentFormState = RefFormState.Viewing;
            }
        }
        #endregion

        #region btnNextRef_Click
        /// <summary>
        /// دكمه ی جابجایی مراجعه ی بیمار جاری به مراجعه ی بعدی آن بیمار
        /// </summary>
        private void btnNextRef_Click(object sender, EventArgs e)
        {
            if (!ManageNavigation()) return;
            // بدست آوردن كد مراجعه بعدی
            Int32? NextRefID = DBLayerIMS.Referrals.GetPatRefNextOrPrevRefID(CurrentRefID, true);
            // اگر مراجعه بعدی وجود داشت و همچنین با مراجعه جاری متفاوت بود مراجعه جاری تغییر می كند
            if (NextRefID != null && NextRefID != 0 && NextRefID != CurrentRefID)
            {
                CurrentRefID = Convert.ToInt32(NextRefID);
                if (IsDisposed) return;
                CurrentFormState = RefFormState.Viewing;
            }
        }
        #endregion

        #endregion

        #region Methods

        #region Boolean ManageNavigation()
        /// <summary>
        /// تابعی برای مدیریت جابجایی بیمار در صورتی كه مقادیر فرم تغییر كرده باشد
        /// </summary>
        /// <returns>تعیین دریافت مجوز كاربر</returns>
        private Boolean ManageNavigation()
        {
            // اگر بیمار یا مراجعه ویرایش شده بود
            if (CurrentFormState != RefFormState.Viewing && _IsCurrentPatModified && !CheckUserPermissionForNavigation())
                return false; // اگر كاربر اجازه تغییر صادر نكرد بیمار تغییر نمی كند
            // اگر فرم در حالت ویرایش باشد اول بیمار آزاد شده سپس اجازه جابجایی داده می شود
            if (CurrentFormState == RefFormState.Editing)
            {
                Negar.DBLayerPMS.Patients.ChangePatLock(CurrentPatientListID, false); // آزاد كردن بیمار جاری
                DBLayerIMS.Referrals.ChangeRefLock(CurrentRefID, false); // آزاد سازی مراجعه
            }
            return true;
        }
        #endregion

        #region Boolean CheckUserPermissionForNavigation()
        /// <summary>
        /// تابعی برای مدیریت جابجایی بیمار در صورتی كه مقادیر فرم تغییر كرده باشد
        /// </summary>
        /// <returns>تعیین دریافت مجوز كاربر</returns>
        private Boolean CheckUserPermissionForNavigation()
        {
            DialogResult Dr = PMBox.Show("بدون ذخیره سازی تغییرات ، اطلاعات وارد شده از دست می رود.\n" +
                "آیا مایلید قبل از تغییر وضعیت بیمار جاری ، اطلاعات وارد شده ثبت گردند؟", "هشدار!",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3);
            // در صورتی كه كاربر دكمه ی آری را فشار دهد ، پس از ذخیره سازی ، مقدار صحیح باز گردانده میشود
            if (Dr == DialogResult.Yes) return ManageFormState(RefFormState.Viewing);
            // در صورتی كه كاربر دكمه ی خیر را فشار دهد ، بدون ذخیره سازی ، مقدار صحیح باز گردانده می شود.
            // روال های آزاد كردن بیمار در این حالت بیرون تابع مدیریت می شود
            if (Dr == DialogResult.No) return true;
            // در صورتی كه كاربر دكمه ی انصراف را فشار دهد ، بدون ذخیره سازی ، مقدار غلط باز گردانده می شود.
            return false;
        }
        #endregion

        #region Boolean FillPatientDataByID(Int32 PatientListID)
        /// <summary>
        /// تابع خواندن اطلاعات بیمار
        /// </summary>
        /// <param name="PatientListID">كلید بیمار</param>
        /// <returns>صحت انجام كار</returns>
        private Boolean FillPatientDataByID(Int32 PatientListID)
        {
            _CurrentPatientData = Negar.DBLayerPMS.Patients.GetPatFullDataByPatListID(PatientListID);
            if (_CurrentPatientData == null) return false;

            #region Set Gender Radio Buttons
            if (_CurrentPatientData.IsMale == null)
            {
                cBoxMale.Checked = false;
                cBoxFemale.Checked = false;
            }
            else
            {
                if (_CurrentPatientData.IsMale.Value) cBoxMale.Checked = true;
                else cBoxFemale.Checked = true;
            }
            #endregion

            #region Fill Other Controls

            #region Patient ID
            if (_CurrentPatientData.PatientID != null)
                txtPatientID.TextBox.Text = _CurrentPatientData.PatientID;
            else txtPatientID.TextBox.Text = String.Empty;
            #endregion

            #region First Name
            if (_CurrentPatientData.FirstName != null) txtFirstName.Text = _CurrentPatientData.FirstName;
            else txtFirstName.Text = String.Empty;
            #endregion

            #region Last Name
            if (_CurrentPatientData.LastName != null) txtLastName.Text = _CurrentPatientData.LastName;
            else txtLastName.Text = String.Empty;
            #endregion

            #region Birth Date
            if (_CurrentPatientData.BirthDate == null)
            {
                txtAgeYear.ValueObject = null;
                DateInputBirthDate.ResetSelectedDateTime();
            }
            else
            {
                int Year = DateTime.Now.Year - _CurrentPatientData.BirthDate.Value.Year;
                int Month = DateTime.Now.Month - _CurrentPatientData.BirthDate.Value.Month;
                if (Month < 0)
                {
                    Year--;
                    Month = -1 * Month;
                }
                int Day = DateTime.Now.Day - _CurrentPatientData.BirthDate.Value.Day;
                if (Day < 0)
                {
                    Month--;
                    Day = -1 * Day;
                }
                DateInputBirthDate.SelectedDateTime = Convert.ToDateTime(_CurrentPatientData.BirthDate);
                txtAgeYear.Value = Year;
                txtAgeMonth.Value = Month;
                txtAgeDay.Value = Day;
            }
            #endregion

            #region TelNo1
            if (_CurrentPatientData.PatDetail != null && _CurrentPatientData.PatDetail.TelNo1 != null)
                txtTel1.Text = _CurrentPatientData.PatDetail.TelNo1;
            else txtTel1.Text = String.Empty;
            #endregion

            #region TelNo2
            if (_CurrentPatientData.PatDetail != null && _CurrentPatientData.PatDetail.TelNo2 != null)
                txtTel2.Text = _CurrentPatientData.PatDetail.TelNo2;
            else txtTel2.Text = String.Empty;
            #endregion

            #region Address
            if (_CurrentPatientData.PatDetail != null && _CurrentPatientData.PatDetail.Address != null)
                txtAddress.Text = _CurrentPatientData.PatDetail.Address;
            else txtAddress.Text = String.Empty;
            #endregion

            #endregion

            _IsCurrentPatModified = false;
            return true;
        }
        #endregion

        #region Boolean FillRefDataByID(Int32 RefID)
        /// <summary>
        /// تابع تكمیل اطلاعات مراجعه ی فرم بر اساس كلید مراجعه
        /// </summary>
        /// <param name="RefID">كلید مراجعه</param>
        /// <returns>صحت انجام كار</returns>
        private Boolean FillRefDataByID(Int32 RefID)
        {
            _CurrentRefData = DBLayerIMS.Referrals.GetRefDataByID(RefID);
            if (_CurrentRefData == null) return false;
            lblRefID.Text = CurrentRefID.ToString();

            #region Fill Combo Boxes

            #region cboAdmitter
            cboAdmitter.SelectedValue = _CurrentRefData.AdmitterIX;
            #endregion

            #region cboRefStatus
            if (_CurrentRefData.ReferStatusIX == null)
            {
                cboRefStatus.DataSource = DBLayerIMS.Referrals.RefStatusList.Where(Data => Data.IsActive.Value).ToList();
                cboRefStatus.DisplayMember = "Title";
                cboRefStatus.ValueMember = "ID";
                cboRefStatus.SelectedIndex = 0;
            }
            else
            {
                cboRefStatus.DataSource = DBLayerIMS.Referrals.RefStatusList.
                    Where(Data => Data.IsActive.Value || Data.ID.Value == _CurrentRefData.ReferStatusIX.Value).ToList();
                cboRefStatus.DisplayMember = "Title";
                cboRefStatus.ValueMember = "ID";
                cboRefStatus.SelectedValue = _CurrentRefData.ReferStatusIX;
            }
            #endregion

            #region cboRefPhysician
            if (_CurrentRefData.ReferPhysicianIX == null)
            {
                cboRefPhysician.DataSource = null;
                cboRefPhysician.Text = String.Empty;
            }
            else
            {
                cboRefPhysician.DataSource = Negar.DBLayerPMS.ClinicData.
                    GetRefPhysFullDataByID(_CurrentRefData.ReferPhysicianIX.Value, false);
                if (cboRefPhysician.DataSource == null) return false;
                cboRefPhysician.DisplayMember = "FullTitle";
                cboRefPhysician.ValueMember = "ID";
                cboRefPhysician.SelectedIndex = 0;
            }
            #endregion

            #region cboIns1
            cboIns1.SelectedIndexChanged -= (cboIns1_SelectedIndexChanged);
            if (_CurrentRefData.Ins1IX == null)
            {
                cboIns1.DataSource = DBLayerIMS.Insurance.InsFullList.Where(Data => Data.IsIns1 == true &&
                    Data.BaseIsActive.Value && Data.IsActive.Value).ToList();
                cboIns1.ValueMember = "ID";
                cboIns1.DisplayMember = "Name";
                cboIns1.SelectedIndex = 0;
            }
            else
            {
                cboIns1.DataSource = DBLayerIMS.Insurance.InsFullList.Where(Data => Data.IsIns1 == true &&
                    Data.BaseIsActive.Value && Data.IsActive.Value || Data.ID == _CurrentRefData.Ins1IX.Value).ToList();
                cboIns1.ValueMember = "ID";
                cboIns1.DisplayMember = "Name";
                cboIns1.SelectedValue = _CurrentRefData.Ins1IX.Value;
            }
            cboIns1.SelectedIndexChanged += (cboIns1_SelectedIndexChanged);
            #endregion

            #region cboIns2
            cboIns2.SelectedIndexChanged -= (cboIns2_SelectedIndexChanged);
            if (_CurrentRefData.Ins2IX == null)
            {
                cboIns2.DataSource = DBLayerIMS.Insurance.InsFullList.Where(Data => Data.IsIns2 == true &&
                    Data.BaseIsActive.Value && Data.IsActive.Value).ToList();
                cboIns2.ValueMember = "ID";
                cboIns2.DisplayMember = "Name";
                cboIns2.SelectedIndex = 0;
            }
            else
            {
                cboIns2.DataSource = DBLayerIMS.Insurance.InsFullList.Where(Data => Data.IsIns2 == true &&
                    Data.BaseIsActive.Value && Data.IsActive.Value || Data.ID == _CurrentRefData.Ins2IX.Value).ToList();
                cboIns2.ValueMember = "ID";
                cboIns2.DisplayMember = "Name";
                cboIns2.SelectedValue = _CurrentRefData.Ins2IX.Value;
            }
            cboIns2.SelectedIndexChanged += (cboIns2_SelectedIndexChanged);
            #endregion

            #endregion

            #region Fill Date Times
            // تاریخ و ساعت مراجعه
            DateReferral.SelectedDateTime = Convert.ToDateTime(_CurrentRefData.RegisterDate);
            TimeReferral.Value = Convert.ToDateTime(_CurrentRefData.RegisterDate);
            DateReferral.UpdateTextValue();
            // تاریخ ارائه گزارش
            if (_CurrentRefData.ReportDate != null)
                PDateReport.SelectedDateTime = Convert.ToDateTime(_CurrentRefData.ReportDate);
            else PDateReport.ResetSelectedDateTime();
            // تاریخ نسخه
            if (_CurrentRefData.PrescriptionDate != null)
                DatePrescribe.SelectedDateTime = Convert.ToDateTime(_CurrentRefData.PrescriptionDate);
            else DatePrescribe.ResetSelectedDateTime();
            // تاریخ اعتبار بیمه اول
            if (_CurrentRefData.Ins1Validation != null)
                Ins1ExpireDate.SelectedDateTime = Convert.ToDateTime(_CurrentRefData.Ins1Validation);
            else Ins1ExpireDate.ResetSelectedDateTime();
            // تاریخ اعتبار بیمه دوم
            if (_CurrentRefData.Ins2Validation != null)
                Ins2ExpireDate.SelectedDateTime = Convert.ToDateTime(_CurrentRefData.Ins2Validation);
            else Ins2ExpireDate.ResetSelectedDateTime();
            #endregion

            #region Fill TextBoxes
            if (_CurrentRefData.Weight != null) txtWeight.Value = Convert.ToDouble(_CurrentRefData.Weight);
            else txtWeight.ValueObject = null;

            if (_CurrentRefData.Description != null) txtDescription.Text = _CurrentRefData.Description;
            else txtDescription.Text = String.Empty;

            if (_CurrentRefData.Ins1Num1 != null) txtIns1No1.Text = _CurrentRefData.Ins1Num1;
            else txtIns1No1.Text = String.Empty;

            if (!String.IsNullOrEmpty(_CurrentRefData.Ins1PageNum)) txtPageNo.Text = _CurrentRefData.Ins1PageNum;
            else txtPageNo.ValueObject = null;

            if (_CurrentRefData.Ins2Num != null) txtIns2No1.Text = _CurrentRefData.Ins2Num;
            else txtIns2No1.Text = String.Empty;

            if (_CurrentRefData.PrePayable != null) txtPrePayment.Value = _CurrentRefData.PrePayable.Value;
            else txtPrePayment.ValueObject = null;
            #endregion

            #region Fill Ref Services
            try
            {
                IOrderedQueryable<RefService> TempServices =
                    DBLayerIMS.Manager.DBML.RefServices.Where(Data => Data.ReferralIX == RefID &&
                    Data.IsActive).OrderBy(Data => Data.ID);
                DBLayerIMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, TempServices);
                _RefServices = TempServices.ToList();
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان خواندن اطلاعات خدمات مراجعه از بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Admission Forms", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion
            dgvRefServices.DataSource = _RefServices.Where(Data => Data.IsActive).ToList();
            #endregion

            ReCalculateAddedServicesPrices(false);
            _IsCurrentPatModified = false;
            return true;
        }
        #endregion

        #endregion

    }
}