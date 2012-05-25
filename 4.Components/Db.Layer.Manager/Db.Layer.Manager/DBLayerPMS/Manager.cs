#region using
using System;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Diagnostics;
using Negar;
using Negar.DBLayerPMS.DataLayer;
#endregion

namespace Negar.DBLayerPMS
{
    /// <summary>
    /// كلاس مدیریت اتصال به بانك بیماران
    /// </summary>
    public static class Manager
    {

        #region Fields

        #region DbLayer _DBML
        /// <summary>
        /// شیء مدیریت اتصال به بانك اطلاعات
        /// </summary>
        private static DbLayer _DBML;
        #endregion

        #endregion

        #region Properties

        #region DbLayer DBML
        /// <summary>
        /// شیء مدیریت اتصال به بانك اطلاعات
        /// </summary>
        public static DbLayer DBML
        {
            get
            {
                if (_DBML == null) Initialize();
                return _DBML;
            }
            set { _DBML = value; }
        }
        #endregion

        #region DateTime? ServerCurrentDateTime
        /// <summary>
        /// خصوصیتی برای خواندن تاریخ و ساعت سرور
        /// </summary>
        public static DateTime? ServerCurrentDateTime
        {
            get
            {
                DataTable DateTimeDataTable = ExecuteQuery("SELECT GETDATE();", 5);
                if (DateTimeDataTable == null) return null;
                return Convert.ToDateTime(DateTimeDataTable.Rows[0][0]);
            }
        }
        #endregion

        #endregion

        #region Methods

        #region void Initialize()
        /// <summary>
        /// تابعی برای نمونه سازی از شیء اتصال به بانك اطلاعات
        /// </summary>
        public static void Initialize()
        {
            DBML = new DbLayer(CSManager.GetConnectionString("PatientsSystem"));
            DBML.DeferredLoadingEnabled = false;
            DBML.CommandTimeout = 0;
        }
        #endregion

        #region Boolean Submit()
        /// <summary>
        /// تابعی برای اعمال تغییرات انجام شده در لایه داده
        /// </summary>
        public static Boolean Submit()
        {
            DBML.CommandTimeout = 0;
            try { DBML.SubmitChanges(ConflictMode.ContinueOnConflict); }
            #region Catch
            catch (Exception Ex)
            {
                LogManager.SaveLogEntry("Negar", "DB Layer Manager", Ex.Message + "\n" + 
                    Ex.StackTrace, EventLogEntryType.Error); return false;
            }
            #endregion
            return true;
        }
        #endregion

        #region Boolean ExecuteCommand(String CommandString, Int32 Timeout)
        /// <summary>
        /// تابعی برای اجرای دستورات بانك بدون مقدار بازگشتی
        /// </summary>
        /// <param name="CommandString">متن فرمان</param>
        /// <param name="Timeout">زمان اجرا</param>
        /// <returns>صحت اجرای فرمان</returns>
        public static Boolean ExecuteCommand(String CommandString, Int32 Timeout)
        {
            DBML = new DbLayer(CSManager.GetConnectionString("PatientsSystem", Timeout));
            DBML.CommandTimeout = Timeout;
            try { DBML.ExecuteCommand(CommandString); }
            #region Catch
            catch (Exception Ex)
            {
                LogManager.SaveLogEntry("Negar", "DB Layer Manager", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            finally { DBML.CommandTimeout = 0; }
            #endregion
            // پس از تكمیل فرمان ، شیء لایه داده دوباره بر اساس تنظیمات پیش فرض ساخته می شود
            Initialize();
            return true;
        }
        #endregion

        #region Boolean ExecuteCommand(String CommandString, Int32 Timeout , String DataBaseName)
        /// <summary>
        /// تابعی برای اجرای دستورات بدون مقدار بازگشتی به بانك اطلاعاتی دلخواه
        /// </summary>
        /// <param name="CommandString">متن فرمان</param>
        /// <param name="Timeout">زمان اجرا</param>
        /// <param name="DataBaseName">نام بانك جهت اتصال</param>
        /// <returns>صحت اجرای فرمان</returns>
        public static Boolean ExecuteCommand(String CommandString, Int32 Timeout, String DataBaseName)
        {
            DataContext DBLayer = new DataContext(CSManager.GetConnectionString(DataBaseName, Timeout));
            DBLayer.CommandTimeout = Timeout;
            try { DBLayer.ExecuteCommand(CommandString); }
            #region Catch
            catch (Exception Ex)
            {
                LogManager.SaveLogEntry("Negar", "DB Layer Manager",
                    Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            finally { DBML.CommandTimeout = 0; }
            #endregion
            return true;
        }
        #endregion

        #region DataTable ExecuteQuery(String CommandString, Int32 Timeout)
        /// <summary>
        /// تابعی برای اجرای دستورات بانك با مقدار بازگشتی جدول
        /// </summary>
        /// <param name="CommandString">متن فرمان</param>
        /// <param name="Timeout">زمان اجرا</param>
        /// <returns>صحت اجرای فرمان</returns>
        public static DataTable ExecuteQuery(String CommandString, Int32 Timeout)
        {
            return ExecuteQuery(CommandString, Timeout, null);
        }
        #endregion

        #region DataTable ExecuteQuery(String CommandString, Int32 Timeout , SqlParameter[] Params)
        /// <summary>
        /// تابعی برای اجرای دستورات بانك با مقدار بازگشتی جدول
        /// </summary>
        /// <param name="CommandString">متن فرمان</param>
        /// <param name="Timeout">زمان اجرا</param>
        /// <param name="Params">پارامتر های دلخواه كاربر برای ارسال كه فرمان</param>
        /// <returns>صحت اجرای فرمان</returns>
        public static DataTable ExecuteQuery(String CommandString, Int32 Timeout, SqlParameter[] Params)
        {
            SqlConnection Connection = new SqlConnection(CSManager.GetConnectionString("PatientsSystem", Timeout));
            SqlCommand Command = new SqlCommand(CommandString, Connection);
            Command.CommandTimeout = Timeout;
            if (Params != null) foreach (SqlParameter Param in Params) Command.Parameters.Add(Param);
            DataTable ReturnDataTable = new DataTable();
            try
            {
                Connection.Open();
                // ReSharper disable AssignNullToNotNullAttribute
                ReturnDataTable.Load(Command.ExecuteReader());
                // ReSharper restore AssignNullToNotNullAttribute
            }
            #region Catch
            catch (Exception Ex)
            {
                LogManager.SaveLogEntry("Negar", "DB Layer Manager", Ex.Message + "\n" + 
                    Ex.StackTrace, EventLogEntryType.Error); return null;
            }
            finally { Connection.Close(); }
            #endregion
            return ReturnDataTable;
        }
        #endregion

        #region void ReleaseCachedFiles()
        /// <summary>
        /// تابعی برای حذف كردن كلیه اطلاعات نگاه داشته شده در حافظه توسط پروژه
        /// </summary>
        public static void ReleaseCachedFiles()
        {
            DBML.Dispose();
            DBML = null;
            ClinicData.InsNameList = null;
            ClinicData.RefPhysicianSpecsList = null;
            Security.UsersList = null;
            Security.GroupsList = null;
            Security.UsersInGroupsList = null;
            Patients.PatientsJobsList = null;
            Patients.CitiesList = null;
            Patients.StatesList = null;
            Patients.CountriesList = null;
        }
        #endregion

        #endregion

    }
}