#region using
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Threading;
using Microsoft.Win32;
#endregion

namespace Negar
{
    /// <summary>
    /// كلاس مدیریت رشته اتصال با برنامه های پزشكی
    /// </summary>
    /// <remarks>
    /// این كلاس وظیفه مدیریت تولید رشته اتصال به بانك های مختلف
    /// بر اساس تنظیمات ثبت شده بر روی رجیستری كاربر جاری را بر عهده دارد
    /// همچنین وظیفه نمایش لیست تنظیمات كاربر جاری ، افزودن تنظیمات جدید ، حذف آنها و سایر عملیات مورد نیاز بر عهده آن می باشد
    /// </remarks>
    public static class CSManager
    {

        #region Fields

        #region String _SubKeyAftabInstalledApps
        /// <summary>
        /// كلید اطلاعات برنامه های تعریف شده در رجیستری برای كاربر جاری
        /// </summary>
        private const String _SubKeyAftabInstalledApps = "Software\\Aftab\\AftabInstalledApps";
        #endregion

        #region String _SubKeyAftabSavedConnections
        /// <summary>
        /// كلید ذخیره سازی اطلاعات اتصال های ذخیره شده برای كاربر جاری در رجیستری
        /// </summary>
        private const String _SubKeyAftabSavedConnections = "Software\\Aftab\\AftabSecurityManager";
        #endregion

        #region String _SubKeyArashLastSettings
        /// <summary>
        /// كلید ذخیره سازی اطلاعات آخرین تنظیمات آرش در رجیستری
        /// </summary>
        private const String _SubKeyArashLastSettings = "Software\\Aftab\\AftabLastSettings";
        #endregion

        #region String _LastAppIDKey
        /// <summary>
        /// نام كلید آخرین برنامه استفاده شده در رجیستری
        /// </summary>
        private const String _LastAppIDKey = "LastAppID";
        #endregion

        #region String _LastUserIDKey
        /// <summary>
        /// نام كلید آخرین كاربر وارد شده به برنامه در رجیستری
        /// </summary>
        private const String _LastUserIDKey = "LastUserID";
        #endregion

        #region String _CurrentSetting
        /// <summary>
        /// نام تنظیمات جاری كه برنامه ی جاری استفاده می كند
        /// </summary>
        private static String _CurrentSetting;
        #endregion

        #region String _TempCSForChecking
        /// <summary>
        /// فیلد رشته اتصال موقت برای تست سالم بودن رشته اتصال
        /// </summary>
        private static String _TempCSForChecking;
        #endregion

        #endregion

        #region Properties

        #region String CurrentSetting
        /// <summary>
        /// نام تنظیمات جاری كه برنامه ی جاری استفاده می كند
        /// </summary>
        public static String CurrentSetting
        {
            get { return _CurrentSetting; }
            set { _CurrentSetting = value; }
        }
        #endregion

        #region Dictionary<String , String> Settings
        /// <summary>
        /// لیست اتصال های ذخیره شده در رجیستری
        /// </summary>
        public static Dictionary<String, String> Settings
        {
            get
            {
                Dictionary<String, String> SettingsList = new Dictionary<String, String>();
                try
                {
                    RegistryKey MyKey = Registry.CurrentUser.OpenSubKey(_SubKeyAftabSavedConnections, true);
                    if (MyKey == null) return null;
                    foreach (String valueName in MyKey.GetValueNames())
                        SettingsList.Add(valueName, MyKey.GetValue(valueName).ToString());
                }
                catch (Exception) { return null; }
                return SettingsList;
            }
        }
        #endregion

        #region Int32 LastOpenedAppID
        /// <summary>
        /// كلید آخرین برنامه استفاده شده در آرش
        /// </summary>
        public static Int32 LastOpenedAppID
        {
            get
            {
                Int32 ReturnValue = 0;
                try
                {
                    RegistryKey MyKey = Registry.CurrentUser.OpenSubKey(_SubKeyArashLastSettings, true);
                    if (MyKey == null) return ReturnValue;
                    ReturnValue = Convert.ToInt32(MyKey.GetValue(_LastAppIDKey, String.Empty));
                }
                catch (Exception) { return ReturnValue; }
                return ReturnValue;
            }
        }
        #endregion

        #region Int16 LastUserID
        /// <summary>
        /// كلید آخرین كاربر وارد شده به برنامه از آرش
        /// </summary>
        public static Int16 LastUserID
        {
            get
            {
                Int16 ReturnValue = 0;
                try
                {
                    RegistryKey MyKey = Registry.CurrentUser.OpenSubKey(_SubKeyArashLastSettings, true);
                    if (MyKey == null) return ReturnValue;
                    ReturnValue = Convert.ToInt16(MyKey.GetValue(_LastUserIDKey, String.Empty));
                }
                catch (Exception) { return ReturnValue; }
                return ReturnValue;
            }
        }
        #endregion

        #endregion

        #region Methods

        #region Boolean CheckConnectionIsAlive(String ConnectionString)
        /// <summary>
        /// تابعی برای تعیین صحت كاركرد رشته اتصال دریافت شده
        /// </summary>
        /// <param name="ConnectionString">رشته اتصال</param>
        /// <returns>صحت كاركرد</returns>
        public static Boolean CheckConnectionIsAlive(String ConnectionString)
        {
            _TempCSForChecking = ConnectionString;
            Thread MyThread = new Thread(CheckCSInNewThread);
            MyThread.Start();
            Thread.Sleep(250);
            if (MyThread.ThreadState == ThreadState.Running)
            {
                Thread.Sleep(1500);
                if (MyThread.ThreadState == ThreadState.Running)
                {
                    Thread.Sleep(2000);
                    if (MyThread.ThreadState == ThreadState.Running)
                    {
                        MyThread.Interrupt();
                        _TempCSForChecking = String.Empty;
                    }
                }
            }
            if (String.IsNullOrEmpty(_TempCSForChecking)) return false;
            return true;
        }
        #endregion

        #region void CheckCSInNewThread()
        /// <summary>
        /// تابعی برای بررسی یك رشته اتصال در ریسمانی خارج از ریسمان فرم اصلی
        /// </summary>
        private static void CheckCSInNewThread()
        {
            DataContext MyDbClass = new DataContext(_TempCSForChecking);
            try { MyDbClass.Connection.Open(); }
            #region Catch
            catch (Exception) { _TempCSForChecking = String.Empty; }
            finally
            {
                MyDbClass.Connection.Close();
                MyDbClass.Dispose();
            }
            #endregion
        }
        #endregion

        #region Boolean AddCSSetting(String SettingName , String ServerName, String InstanceName)
        /// <summary>
        /// افزودن تنظیمات اطلاعات رشته اتصال جدید در رجیستری
        /// </summary>
        /// <param name="SettingName">نام نمایشی</param>
        /// <param name="ServerName">نام سرور</param>
        /// <param name="InstanceName">نام نمونه بانك</param>
        /// <returns>صحت انجام</returns>
        public static Boolean AddCSSetting(String SettingName, String ServerName, String InstanceName)
        {
            try
            {
                RegistryKey MyKey = Registry.CurrentUser.OpenSubKey(_SubKeyAftabSavedConnections, true);
                if (MyKey == null)
                {
                    Registry.CurrentUser.CreateSubKey(_SubKeyAftabSavedConnections);
                    MyKey = Registry.CurrentUser.OpenSubKey(_SubKeyAftabSavedConnections, true);
                }
                // اگر نمونه بانك ارسال نشود به معنی پیش فرض بودن نمونه است و نیازی به استفاده از آن نیست
                String FullServerName = ServerName;
                if (!String.IsNullOrEmpty(InstanceName)) FullServerName += "\\" + InstanceName;
                if (MyKey != null) MyKey.SetValue(SettingName, FullServerName, RegistryValueKind.String);
            }
            catch (Exception) { return false; }
            return true;
        }
        #endregion

        #region Boolean DeleteCSSetting(String SettingName)
        /// <summary>
        /// حذف اطلاعات رشته اتصال از رجیستری
        /// </summary>
        /// <param name="SettingName">نام نمایشی</param>
        /// <returns>صحت انجام</returns>
        public static Boolean DeleteCSSetting(String SettingName)
        {
            try
            {
                RegistryKey MyKey = Registry.CurrentUser.OpenSubKey(_SubKeyAftabSavedConnections, true);
                if (MyKey != null) MyKey.DeleteValue(SettingName);
            }
            catch (Exception) { return false; }
            return true;
        }
        #endregion

        #region Boolean IsSettingExists(String SettingName)
        /// <summary>
        /// تابعی برای بررسی وجود داشتن یك تنظیمات در رجیستری كاربر جاری
        /// </summary>
        /// <param name="SettingName">نام تنظیمات</param>
        /// <returns>صحیح برای وجود و غلط برای عدم وجود</returns>
        public static Boolean IsSettingExists(String SettingName)
        {
            try
            {
                RegistryKey MyKey = Registry.CurrentUser.OpenSubKey(_SubKeyAftabSavedConnections, true);
                if (MyKey == null) return false;
                if (MyKey.GetValue(SettingName) == null) return false;
            }
            catch (Exception) { return false; }
            return true;
        }
        #endregion

        #region Boolean SaveLastSettingsToReg(Int32 AppID, Int32 UserID)
        /// <summary>
        /// ذخیره سازی آخرین تنظیمات كاربر در رجیستری
        /// </summary>
        /// <param name="AppID">كلید آخرین برنامه</param>
        /// <param name="UserID">كلید آخرین كاربر</param>
        /// <returns>صحت انجام</returns>
        public static Boolean SaveLastSettingsToReg(Int32 AppID, Int32 UserID)
        {
            try
            {
                RegistryKey MyKey = Registry.CurrentUser.OpenSubKey(_SubKeyArashLastSettings, true);
                if (MyKey == null)
                {
                    Registry.CurrentUser.CreateSubKey(_SubKeyArashLastSettings);
                    MyKey = Registry.CurrentUser.OpenSubKey(_SubKeyArashLastSettings, true);
                }
                // ReSharper disable PossibleNullReferenceException
                MyKey.SetValue(_LastAppIDKey, AppID, RegistryValueKind.String);
                // ReSharper restore PossibleNullReferenceException
                MyKey.SetValue(_LastUserIDKey, UserID, RegistryValueKind.String);
            }
            catch (Exception) { return false; }
            return true;
        }
        #endregion

        #region void SaveNewAppPathToReg(Int16 ApplicationID, String ApplicationPath)
        /// <summary>
        /// تابعی برای افزودن آدرس فیزیكی زیر سیستم به رجیستری
        /// </summary>
        /// <param name="ApplicationID">كلید برنامه</param>
        /// <param name="ApplicationPath">آدرس فیزیكی</param>
        /// <remarks>به ازای هر زیر سیستم بیش از 1 آدرس فیزیكی نمی توان ذخیره كرد</remarks>
        public static void SaveNewAppPathToReg(Int16 ApplicationID, String ApplicationPath)
        {
            RegistryKey MyKey = Registry.CurrentUser.OpenSubKey(_SubKeyAftabInstalledApps, true);
            if (MyKey == null) MyKey = Registry.CurrentUser.CreateSubKey(_SubKeyAftabInstalledApps);
            if (MyKey != null) MyKey.SetValue(ApplicationID.ToString(), ApplicationPath);
        }
        #endregion

        #region Boolean DeleteLastAppAndUser()
        /// <summary>
        /// حذف اطلاعات آخرین زیر سیستم وارد شده و آخرین كاربر انتخاب شده از رجیستری
        /// </summary>
        /// <returns>صحت انجام</returns>
        public static Boolean DeleteLastAppAndUser()
        {
            try
            {
                RegistryKey MyKey = Registry.CurrentUser.OpenSubKey(_SubKeyArashLastSettings, true);
                if (MyKey == null) return true;
                MyKey.DeleteValue(_LastAppIDKey);
                MyKey.DeleteValue(_LastUserIDKey);
            }
            catch (Exception) { return false; }
            return true;
        }
        #endregion

        #region String LoadAppPath(Int32 ApplicationID)
        /// <summary>
        /// خواندن آدرس فایل اجرایی برنامه از رجیستری
        /// </summary>
        /// <returns>كلید برنامه</returns>
        /// <remarks>صفر برای عدم وجود یا خطا</remarks>
        public static String LoadAppPath(Int32 ApplicationID)
        {
            String ReturnValue = String.Empty;
            try
            {
                RegistryKey MyKey = Registry.CurrentUser.OpenSubKey(_SubKeyAftabInstalledApps, true);
                if (MyKey == null) return String.Empty;
                ReturnValue = MyKey.GetValue(ApplicationID.ToString(), String.Empty).ToString();
            }
            catch (Exception) { return ReturnValue; }
            return ReturnValue;
        }
        #endregion

        #region String GetConnectionString(String DbName)
        /// <summary>
        /// تولید رشته اتصال بر اساس تنظیمات جاری انتخاب شده برای زیر سیستم و بانك انتخاب شده
        /// </summary>
        /// <returns>رشته ی اتصال</returns>
        /// <remarks>در صورت وجود خطا در رشته اتصال مقدار خالی باز گردانده می شود</remarks>
        public static String GetConnectionString(String DbName)
        {
            String ServerAndInstance = String.Empty;
            try
            {
                RegistryKey MyKey = Registry.CurrentUser.OpenSubKey(_SubKeyAftabSavedConnections, true);
                if (MyKey == null) return ServerAndInstance;
                ServerAndInstance = MyKey.GetValue(_CurrentSetting, String.Empty).ToString();
            }
            catch (Exception) { return ServerAndInstance; }
            if (ServerAndInstance == String.Empty) return String.Empty;
            return GenerateCS(ServerAndInstance, DbName, 0);
        }
        #endregion

        #region String GetConnectionString(String DbName , Int32 Timeout)
        /// <summary>
        /// تولید رشته اتصال بر اساس تنظیمات جاری انتخاب شده برای زیر سیستم و بانك انتخاب شده
        /// </summary>
        /// <returns>رشته ی اتصال</returns>
        /// <remarks>در صورت وجود خطا در رشته اتصال مقدار خالی باز گردانده می شود</remarks>
        public static String GetConnectionString(String DbName, Int32 Timeout)
        {
            String ServerAndInstance = String.Empty;
            try
            {
                RegistryKey MyKey = Registry.CurrentUser.OpenSubKey(_SubKeyAftabSavedConnections, true);
                if (MyKey == null) return ServerAndInstance;
                ServerAndInstance = MyKey.GetValue(_CurrentSetting, String.Empty).ToString();
            }
            catch (Exception) { return ServerAndInstance; }
            if (ServerAndInstance == String.Empty) return String.Empty;
            return GenerateCS(ServerAndInstance, DbName, Timeout);
        }
        #endregion

        #region String GenerateCS(String ServerAndInstance, String DbName , Int32 Timeout)
        /// <summary>
        /// تابع تولید رشته اتصال استاندارد ارتباط با سیستم بیمارستانی بر اساس ورودی ها با زمان بسته شدن انتخابی
        /// </summary>
        /// <param name="ServerAndInstance">نام سرور و نمونه بانك اطلاعات</param>
        /// <param name="DbName">نام بانك مورد نظر</param>
        /// <param name="Timeout">زمان اتمام اتصال</param>
        /// <returns>رشته اتصال</returns>
        /// <remarks>این تابع با اطلاعات ذخیره شده در رجیستری كار نمی كند</remarks>
        public static String GenerateCS(String ServerAndInstance, String DbName, Int32 Timeout)
        {
            String DataBaseName = "; Initial Catalog = " + DbName + "; ";
            String SecurityValues = " Persist Security Info=False; User ID=sa; Password= " + LicenseHelper.GetDbSaPassword() + ";";
            String ConnectionTimeOut = "Connection Timeout = " + Timeout + ";";
            // =========================================
            String ConnectionString = "Data Source = " + ServerAndInstance +
                DataBaseName + SecurityValues + ConnectionTimeOut;
            // =========================================
            return ConnectionString;
        }
        #endregion

        #region String GenerateCS(...)
        /// <summary>
        /// تابع تولید رشته اتصال استاندارد ارتباط با سیستم بیمارستانی بر اساس ورودی ها با زمان بسته شدن انتخابی
        /// </summary>
        /// <param name="ServerAndInstance">نام سرور و نمونه بانك اطلاعات</param>
        /// <param name="DbName">نام بانك مورد نظر</param>
        /// <param name="Timeout">زمان اتمام اتصال</param>
        /// <param name="UserName">نام كاربری اتصال به بانك</param>
        /// <param name="Password">رمز عبور اتصال به بانك</param>
        /// <returns>رشته اتصال</returns>
        /// <remarks>این تابع با اطلاعات ذخیره شده در رجیستری كار نمی كند</remarks>
        public static String GenerateCS(String ServerAndInstance, String DbName, Int32 Timeout, String UserName, String Password)
        {
            String DataBaseName = "; Initial Catalog = " + DbName + "; ";
            // =========================================
            String SecurityValues = " Persist Security Info=False; User ID=" + UserName + "; Password= " + Password + ";";
            // =========================================
            String ConnectionTimeOut = "Connection Timeout = " + Timeout + ";";
            // =========================================
            String ConnectionString = "Data Source = " + ServerAndInstance +
                DataBaseName + SecurityValues + ConnectionTimeOut;
            // =========================================
            return ConnectionString;
        }
        #endregion

        #endregion

    }
}