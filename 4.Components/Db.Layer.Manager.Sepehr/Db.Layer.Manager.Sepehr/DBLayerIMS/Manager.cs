#region using
using System;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Diagnostics;
using Negar;
using Sepehr.DBLayerIMS.DataLayer;
#endregion

namespace Sepehr.DBLayerIMS
{
    /// <summary>
    /// كلاس مدیریت اتصال به بانك تصویربرداری
    /// </summary>
    public static class Manager
    {

        #region Fields

        #region DbLayer _DBML
        /// <summary>
        /// شی ء مدیریت اتصال به بانك اطلاعات
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

        #endregion

        #region Methods

        #region void Initialize()
        /// <summary>
        /// تابعی برای نمونه سازی از شیء اتصال به بانك اطلاعات
        /// </summary>
        public static void Initialize()
        {
            DBML = new DbLayer(CSManager.GetConnectionString("ImagingSystem"));
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
                LogManager.SaveLogEntry("Sepehr", "DB Layer Manager", Ex.Message + "\n" + 
                    Ex.StackTrace, EventLogEntryType.Error);
                return false;
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
            DBML = new DbLayer(CSManager.GetConnectionString("ImagingSystem", Timeout));
            DBML.CommandTimeout = Timeout;
            try { DBML.ExecuteCommand(CommandString); }
            #region Catch
            catch (Exception Ex)
            {
                LogManager.SaveLogEntry("Sepehr", "DB Layer Manager", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            finally { DBML.CommandTimeout = 0; }
            #endregion
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
                LogManager.SaveLogEntry("Sepehr", "DB Layer Manager", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
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

        #region DataTable ExecuteQuery(String CommandString, Int32 Timeout)
        /// <summary>
        /// تابعی برای اجرای دستورات بانك با مقدار بازگشتی جدول
        /// </summary>
        /// <param name="CommandString">متن فرمان</param>
        /// <param name="Timeout">زمان اجرا</param>
        /// <param name="Params">پارامتر های دلخواه كاربر برای ارسال كه فرمان</param>
        /// <returns>صحت اجرای فرمان</returns>
        public static DataTable ExecuteQuery(String CommandString, Int32 Timeout, SqlParameter[] Params)
        {
            SqlConnection Connection = new SqlConnection(CSManager.GetConnectionString("ImagingSystem", Timeout));
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
                LogManager.SaveLogEntry("Sepehr", "DB Layer Manager", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return null;
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
            Settings.CurrentUserSettingsFullList = null;
            Schedules.SchAppList = null;
            Schedules.SchAddinDataItemsList = null;
            Schedules.SchAddinColumnsOrdersList = null;
            Schedules.SchAddinColumnsList = null;
            Schedules.SchAddinColsAppCover = null;
            Referrals.RefStatusList = null;
            Referrals.RefServPerformers = null;
            Referrals.PatAddinColsList = null;
            Referrals.RefAddinColsList = null;
            Insurance.InsFullList = null;
            Insurance.Ins2FormulaList = null;
            Services.ServicesList = null;
            Services.ServCategoriesList = null;
            Services.ServGroupsList = null;
            Services.ServicesInGroupsList = null;
            Services.ServAddinPriceColsList = null;
            Account.BanksFullList = null;
            Account.CostAndDiscountFullList = null;
            Cash.CashFullList = null;
            Document.ClearCatchedDocTemplates();
            Document.DocTemplatesList = null;
            Document.DocTextsList = null;
            Document.DocTypesList = null;
            PACS.Modalities = null;
            PACS.Studies = null;
            PACS.ServiceModalities = null;
            PACS.ServiceStudies = null;
            PACS.ReleaseCachedFiles();
        }
        #endregion

        #endregion

    }
}