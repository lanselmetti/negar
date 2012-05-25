#region using
using System;
using System.Collections.Generic;
using System.Linq;
using NovinAfzar;
#endregion

namespace Negar
{
    /// <summary>
    /// كلاس مدیریت لایسنس های سیستم
    /// </summary>
    public static class LicenseHelper
    {

        #region Fields
        private static clsHIDLock _LockObject;
        private const String _DeveloeprPassword1 = "53.48.48.109.97.108.101.107.";
        private static Boolean _IsLockInitialized;
        /// <summary>
        /// تعیین آنكه قفل آماده بررسی شده است یا خیر
        /// </summary>
        private static String _LockDeviceSerial;
        private static List<String> _LicensesList;
        private static String _ReturnPassword;
        #endregion

        #region Properties

        #region public static String LockDeviceSerial
        /// <summary>
        /// تعیین آنكه قفل آماده بررسی شده است یا خیر
        /// </summary>
        public static String LockDeviceSerial
        {
            get { return _LockDeviceSerial; }
        }
        #endregion

        #region public static String LockDeviceVersion
        /// <summary>
        /// تعیین آنكه قفل آماده بررسی شده است یا خیر
        /// </summary>
        public static String LockDeviceVersion
        {
            get { return _LockObject.GetVersion(); }
        }
        #endregion

        #endregion

        #region static Boolean InitializeLock()
        /// <summary>
        /// آماده سازی قفل برای استفاده
        /// </summary>
        private static Boolean InitializeLock()
        {
            try
            {
                _LockObject = new clsHIDLock();
                _LockObject.Init();
                // اگر سخت افزاری 
                if (_LockObject.GetDeviceCount() == 0) return false;
                // فعال سازی اولین سخت افزار موجود در سیستم
                _LockObject.GetFirstDevice();
                if (_LockObject.ErrNo != 0) return false;
                // خواندن سریال قفل جاری
                _LockDeviceSerial = _LockObject.DeviceSerial;
                _LockObject.SelectDevice(LockDeviceSerial);
                _LockObject.GetDeviceReady();
                if (_LockObject.ErrNo != 0) return false;
                if (_LockObject.GetTimerCounter() > 20000 || _LockObject.GetTimerCounter() < 2) return false;
                _LockObject.DecreaseCounter();
            }
            catch (Exception) { return false; }
            _IsLockInitialized = true;
            return true;
        }
        #endregion

        #region static String GetDbSaPassword()
        /// <summary>
        /// دریافت رمز اتصال به بانك اطلاعاتی
        /// </summary>
        public static String GetDbSaPassword()
        {
            //return "sudnhdvhk";
            if (!String.IsNullOrEmpty(_ReturnPassword)) return _ReturnPassword;
            // در صورتی كه قفل آماده نباشد ، آماده می گردد
            if (!_IsLockInitialized && !InitializeLock()) return _ReturnPassword;
            try
            {
                // در صورتی كه سریال قفلی كه اولین بار متصل شده با سریال قفل جاری متفاوت باشد خطا بازگردانده می شود
                if (LockDeviceSerial != _LockObject.DeviceSerial) return _ReturnPassword;
                _ReturnPassword = _LockObject.GetDataBlockStr(Constants.LockVendorID,
                    _DeveloeprPassword1 + Constants.DeveloeprPassword2, 300, 61);
                #region Decrypt Data
                _ReturnPassword = _LockObject.GetDecryption(Constants.LockVendorID,
                    _DeveloeprPassword1 + Constants.DeveloeprPassword2, _ReturnPassword, 1);
                if (_LockObject.ErrNo != 0) return String.Empty;
                _ReturnPassword = _LockObject.ConvDelimiteredStringToString(_ReturnPassword, _ReturnPassword.Length, ".").Trim();
                _ReturnPassword = _ReturnPassword.Substring(0, _ReturnPassword.IndexOf('\0'));
                #endregion
            }
            catch (Exception) { return String.Empty; }
            return _ReturnPassword;
        }
        #endregion

        #region static List<String> GetSavedLicenses()
        /// <summary>
        /// دریافت رمز اتصال به بانك اطلاعاتی
        /// </summary>
        public static List<String> GetSavedLicenses()
        {
            #region Test Part - For
            if (false)
            {
                _LicensesList = new List<String>();
                _LicensesList.Add("110");
                _LicensesList.Add("120");
                _LicensesList.Add("510");
                _LicensesList.Add("511");
                _LicensesList.Add("515");
                _LicensesList.Add("516");
                _LicensesList.Add("520");
                _LicensesList.Add("521");
                _LicensesList.Add("525");
                _LicensesList.Add("526");
                _LicensesList.Add("530");
                _LicensesList.Add("531");
                _LicensesList.Add("540");
                _LicensesList.Add("541");
                _LicensesList.Add("550");
                _LicensesList.Add("551");
                _LicensesList.Add("560");
                _LicensesList.Add("561");
                _LicensesList.Add("590");
                _LicensesList.Add("591");
                _LicensesList.Add("592");
                _LicensesList.Add("593");
                _LicensesList.Add("594");
                _LicensesList.Add("571");
                return _LicensesList;
            }
            #endregion
            // در صورتی كه قفل آماده نباشد ، آماده می گردد
            if (!_IsLockInitialized && !InitializeLock()) return _LicensesList;
            try
            {
                // در صورتی كه سریال قفلی كه اولین بار متصل شده با سریال قفل جاری متفاوت باشد خطا بازگردانده می شود
                if (LockDeviceSerial != _LockObject.DeviceSerial) return new List<String>();
                if (_LicensesList != null) return _LicensesList;
                _LicensesList = new List<String>();
                String LicenseListString = _LockObject.GetDataBlockStr(Constants.LockVendorID,
                    _DeveloeprPassword1 + Constants.DeveloeprPassword2, 0, 300);
                if (String.IsNullOrEmpty(LicenseListString)) return _LicensesList;
                for (Int32 i = 0; i < 100; i++)
                {
                    String TheLicense = LicenseListString.Substring(i * 3, 3);
                    if (!String.IsNullOrEmpty(TheLicense.Trim()) && TheLicense.Length == 3)
                        _LicensesList.Add(TheLicense);
                }
                _LicensesList = _LicensesList.Distinct().ToList();
            }
            catch (Exception) { return _LicensesList; }
            return _LicensesList;
        }
        #endregion

        #region static void ReleaseCachedData()
        /// <summary>
        /// تابعی برای حذف اطلاعات ذخیره شده قفل در حافظه
        /// </summary>
        public static void ReleaseCachedData()
        {
            _IsLockInitialized = false;
            _LockDeviceSerial = String.Empty;
            _ReturnPassword = String.Empty;
        }
        #endregion

    }
}