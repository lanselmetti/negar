#region using

using System;
using Sepehr.Forms.Admission.Patients;
using Sepehr.Forms.Admission.Referrals;

#endregion

namespace Sepehr.Forms.Admission.Classes
{
    /// <summary>
    /// كلاسی برای مدیریت پذیرش بیماران
    /// </summary>
    /// <remarks>از این كلاس برای فراخوانی فرم پذیرش بیمار و
    /// پذیرش مراجعه بیمار جدید و حذف آن از حافظه استفاده می شود</remarks>
    public static class AdmitHelper
    {

        #region Fields
        private static frmPatients _AdmitPatForm;
        private static frmPatRefManager _AdmitPatNewRefForm;
        #endregion

        #region Methods

        #region void AdmitPatient(Int32? SchAppointmentID)
        /// <summary>
        /// تابعی برای ثبت پرونده بیمار جدید
        /// </summary>
        /// <param name="SchAppointmentID">كلید نوبت ارسال شده برای پذیرش یا تهی برای عدم پذیرش از نوبت دهی</param>
        public static void AdmitPatient(Int32? SchAppointmentID)
        {
            if (_AdmitPatForm == null || _AdmitPatForm.IsDisposed) _AdmitPatForm = new frmPatients();
            if (_AdmitPatForm == null || _AdmitPatForm.IsDisposed) return;
            if (_AdmitPatForm.AddNewPatient(SchAppointmentID)) _AdmitPatForm.ShowDialog();
        }
        #endregion

        #region void EditPatient(Int32 PatID, Boolean IsSingleEdit)
        /// <summary>
        /// روالی برای ویرایش پرونده بیمار
        /// </summary>
        public static void EditPatient(Int32 PatID, Boolean IsSingleEdit)
        {
            if (_AdmitPatForm == null || _AdmitPatForm.IsDisposed) _AdmitPatForm = new frmPatients();
            if (_AdmitPatForm == null || _AdmitPatForm.IsDisposed) return;
            if (_AdmitPatForm.EditPatient(PatID, IsSingleEdit)) _AdmitPatForm.ShowDialog();
        }
        #endregion

        // =================================================

        #region void AdmitPatWithRef(Int32? SchAppointmentID)
        /// <summary>
        /// پذیرش مراجعه بیمار جدید
        /// </summary>
        /// <param name="SchAppointmentID">كلید نوبت ارسال شده برای پذیرش یا تهی برای عدم پذیرش از نوبت دهی</param>
        public static void AdmitPatWithRef(Int32? SchAppointmentID)
        {
            if (_AdmitPatNewRefForm == null || _AdmitPatNewRefForm.IsDisposed) 
                _AdmitPatNewRefForm = new frmPatRefManager();
            if (_AdmitPatNewRefForm == null || _AdmitPatNewRefForm.IsDisposed) return;
            _AdmitPatNewRefForm.AdmitNewPatRef(SchAppointmentID);
        }
        #endregion

        #region void AdmitNewRef(Int32 PatientListID, Int32? SchAppointmentID)
        /// <summary>
        /// ثبت مراجعه جدید برای یك بیمار
        /// </summary>
        public static void AdmitNewRef(Int32 PatientListID, Int32? SchAppointmentID)
        {
            if (_AdmitPatNewRefForm == null || _AdmitPatNewRefForm.IsDisposed) _AdmitPatNewRefForm = new frmPatRefManager();
            if (_AdmitPatNewRefForm == null || _AdmitPatNewRefForm.IsDisposed) return;
            _AdmitPatNewRefForm.AdmitNewRef(PatientListID, SchAppointmentID);
        }
        #endregion

        #region void EditPatientLastRef(Int32 PatID)
        /// <summary>
        /// روالی برای ویرایش آخرین مراجعه یك بیمار
        /// </summary>
        public static void EditPatientLastRef(Int32 PatID)
        {
            if (_AdmitPatNewRefForm == null || _AdmitPatNewRefForm.IsDisposed) 
                _AdmitPatNewRefForm = new frmPatRefManager();
            if (_AdmitPatNewRefForm == null || _AdmitPatNewRefForm.IsDisposed) return;
            _AdmitPatNewRefForm.ShowPatLastRef(PatID);
        }
        #endregion

        #region void EditPatientRef(Int32 RefID)
        /// <summary>
        /// روالی برای ویرایش مراجعه یك بیمار
        /// </summary>
        public static void EditPatientRef(Int32 RefID)
        {
            if (_AdmitPatNewRefForm == null || _AdmitPatNewRefForm.IsDisposed) 
                _AdmitPatNewRefForm = new frmPatRefManager();
            if (_AdmitPatNewRefForm == null || _AdmitPatNewRefForm.IsDisposed) return;
            _AdmitPatNewRefForm.ShowRef(RefID);
        }
        #endregion

        // =================================================

        #region void ClearTempAdmit()
        /// <summary>
        /// حذف كردن اطلاعات فرم پذیرش از حافظه
        /// </summary>
        public static void ClearTempAdmit()
        {
            if (_AdmitPatForm != null) _AdmitPatForm = null;
            if (_AdmitPatNewRefForm != null) _AdmitPatNewRefForm = null;
        }
        #endregion

        #endregion

    }
}