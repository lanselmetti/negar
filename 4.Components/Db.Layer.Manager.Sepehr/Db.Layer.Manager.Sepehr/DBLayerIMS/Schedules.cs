#region using
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Negar;
using Sepehr.DBLayerIMS.DataLayer;

#endregion

namespace Sepehr.DBLayerIMS
{
    /// <summary>
    /// كلاس مدیریت اطلاعات نوبت دهی تصویربرداری
    /// </summary>
    public static class Schedules
    {

        #region Fields
        private static List<SP_SelectApplicationsResult> _SchAppList;
        private static List<SchAddinColumns> _SchAddinColumnsList;
        private static List<SchColumnsOrder> _SchAddinColumnsOrdersList;
        private static List<SchAddinDataItem> _SchAddinDataItemsList;
        private static List<SchAddinColsAppCover> _SchAddinColsAppCover;
        private static List<SP_SelectLogCategoriesResult> _SchSchLogCategoriesList;
        #endregion

        #region Properties

        #region List<SP_SelectApplicationsResult> SchAppList
        /// <summary>
        /// لیست برنامه های نوبت دهی ثبت شده در سیستم
        /// </summary>
        /// <remarks>
        /// بدون اعمال فعال بودن یا نبودن آنها. همراه با آیتم انتخاب نشده
        /// </remarks>
        public static List<SP_SelectApplicationsResult> SchAppList
        {
            get
            {
                if (_SchAppList == null)
                    try { _SchAppList = Manager.DBML.SP_SelectApplications().ToList(); }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage = "خواندن لیست برنامه های نوبت دهی از بانك اطلاعات ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Sepehr", "DBLayer - Schedules",
                            Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                        return null;
                    }
                    #endregion
                return _SchAppList;
            }
            set { _SchAppList = value; }
        }
        #endregion

        #region List<SchAddinColumns> SchAddinColumnsList
        /// <summary>
        /// لیست ستون های پویا برنامه های نوبت دهی ثبت شده در سیستم
        /// </summary>
        public static List<SchAddinColumns> SchAddinColumnsList
        {
            get
            {
                if (_SchAddinColumnsList == null)
                    try
                    {
                        Table<SchAddinColumns> TempSchAddinColumnsList = Manager.DBML.SchAddinColumns;
                        Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, TempSchAddinColumnsList);
                        _SchAddinColumnsList = TempSchAddinColumnsList.OrderBy(Data => Data.Title).ToList();
                    }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage = "خواندن لیست ستون های پویا برنامه های نوبت دهی از بانك ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Sepehr", "DBLayer - Schedules",
                            Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                        return null;
                    }
                    #endregion
                return _SchAddinColumnsList;
            }
            set { _SchAddinColumnsList = value; }
        }
        #endregion

        #region List<SchAddinColsAppCover> SchAddinColsAppCover
        /// <summary>
        /// لیست پوشش ستون های پویا برنامه های نوبت دهی ثبت شده در سیستم
        /// </summary>
        public static List<SchAddinColsAppCover> SchAddinColsAppCover
        {
            get
            {
                if (_SchAddinColsAppCover == null)
                    try
                    {
                        Table<SchAddinColsAppCover> TempData = Manager.DBML.SchAddinColsAppCovers;
                        Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, TempData);
                        _SchAddinColsAppCover = TempData.ToList();
                    }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage = "خواندن لیست پوشش ستون های پویا برنامه های نوبت دهی ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Sepehr", "DBLayer - Schedules",
                            Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error); return null;
                    }
                    #endregion
                return _SchAddinColsAppCover;
            }
            set { _SchAddinColsAppCover = value; }
        }
        #endregion

        #region List<SchColumnsOrder> SchAddinColumnsOrdersList
        /// <summary>
        /// لیست ترتیب ستون های اضافی برنامه های نوبت دهی ثبت شده در سیستم
        /// </summary>
        public static List<SchColumnsOrder> SchAddinColumnsOrdersList
        {
            get
            {
                if (_SchAddinColumnsOrdersList == null)
                    try
                    {
                        Table<SchColumnsOrder> TempData = Manager.DBML.SchColumnsOrders;
                        Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, TempData);
                        _SchAddinColumnsOrdersList = TempData.OrderBy(Data => Data.OrderNumber).ToList();
                    }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage = "خواندن لیست ترتیب ستون های اضافی برنامه های نوبت دهی از بانك ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Sepehr", "DBLayer - Schedules",
                            Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                        return null;
                    }
                    #endregion
                return _SchAddinColumnsOrdersList;
            }
            set { _SchAddinColumnsOrdersList = value; }
        }
        #endregion

        #region List<SchAddinDataItem> SchAddinDataItemsList
        /// <summary>
        /// لیست آیتم های قابل استفاده در فیلد های اضافی نوبت دهی چند گزینه ای
        /// </summary>
        public static List<SchAddinDataItem> SchAddinDataItemsList
        {
            get
            {
                if (_SchAddinDataItemsList == null)
                    try
                    {
                        Table<SchAddinDataItem> TempSchAddinDataItemsList = Manager.DBML.SchAddinDataItems;
                        Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, TempSchAddinDataItemsList);
                        _SchAddinDataItemsList = TempSchAddinDataItemsList.OrderBy(Data => Data.Title).ToList();
                    }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage = "خواندن آیتمهای قابل استفاده در فیلدهای اضافی نوبت دهی چند گزینه ای ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Sepehr", "DBLayer - Schedules",
                            Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                        return null;
                    }
                    #endregion
                return _SchAddinDataItemsList;
            }
            set { _SchAddinDataItemsList = value; }
        }
        #endregion

        #region List<SP_SelectApplicationsResult> SchAppList
        /// <summary>
        /// لیست برنامه های نوبت دهی ثبت شده در سیستم
        /// </summary>
        /// <remarks>
        /// بدون اعمال فعال بودن یا نبودن آنها. همراه با آیتم انتخاب نشده
        /// </remarks>
        public static List<SP_SelectLogCategoriesResult> SchLogCategoriesList
        {
            get
            {
                if (_SchSchLogCategoriesList == null)
                    try { _SchSchLogCategoriesList = Manager.DBML.SP_SelectLogCategories().ToList(); }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage = "خواندن لیست طبقه بندی رخداد های نوبت دهی از بانك اطلاعات ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Sepehr", "DBLayer - Schedules",
                            Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                        return null;
                    }
                    #endregion
                return _SchSchLogCategoriesList;
            }
        }
        #endregion

        #endregion

        #region Methods

        // ======================== تنظیمات =========================

        #region SchApplications GetSchAppData(Int16 ApplicationID)
        /// <summary>
        /// تابعی برای خواندن اطلاعات به روز شده یك برنامه نوبت دهی ، مستقیماً از بانك اطلاعات
        /// </summary>
        /// <returns>اطلاعات برنامه یا تهی برای وقوع خطا</returns>
        public static SchApplications GetSchAppData(Int16 ApplicationID)
        {
            SchApplications AppData;
            try
            {
                AppData = Manager.DBML.SchApplications.Where(Data => Data.ID == ApplicationID).First();
                Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, AppData);
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان خواندن اطلاعات برنامه نوبت دهی انتخاب شده از بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Schedules", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return null;
            }
            #endregion
            return AppData;
        }
        #endregion

        #region List<SchAppointments> GetSchAppConflictsInPeriod(Int16 ApplicationID, DateTime DateStart, DateTime DateEnd)
        /// <summary>
        /// تابعی برای خواندن نقاط تلاقی تاریخ های ارائه شده به تابع با نوبت های موجود در بانك برای یك برنامه
        /// </summary>
        /// <returns>اطلاعات تلاقی ها یا تهی برای وقوع خطا</returns>
        public static List<SchAppointments> GetSchAppConflictsInPeriod(Int16 ApplicationID, DateTime DateStart, DateTime DateEnd)
        {
            IOrderedQueryable<SchAppointments> Conflicts;
            try
            {
                Conflicts = Manager.DBML.SchAppointments.
                    Where(Data => Data.ApplicationIX == ApplicationID &&
                    Data.OccuredDateTime >= DateStart && Data.OccuredDateTime <= DateEnd).
                    OrderBy(Data => Data.OccuredDateTime).ThenBy(Data => Data.OrderNo);
                Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, Conflicts);
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان خواندن اطلاعات تداخلات برنامه نوبت دهی انتخاب شده از بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Schedules", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return null;
            }
            #endregion
            return Conflicts.ToList();
        }
        #endregion

        #region List<SchAppWeekPeriods> GetSchAppWeekPeriodData(Int16 ApplicationID)
        /// <summary>
        /// تابعی برای خواندن اطلاعات به روز شده ساختار روز های یك برنامه نوبت دهی ، مستقیماً از بانك اطلاعات
        /// </summary>
        /// <returns>اطلاعات برنامه یا تهی برای وقوع خطا</returns>
        public static List<SchAppWeekPeriods> GetSchAppWeekPeriodData(Int16 ApplicationID)
        {
            IQueryable<SchAppWeekPeriods> AppWeekPeriodData;
            try
            {
                AppWeekPeriodData = Manager.DBML.SchAppWeekPeriods.Where(Data => Data.ApplicationIX == ApplicationID);
                Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, AppWeekPeriodData);
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان خواندن اطلاعات ساختار روزهای برنامه نوبت دهی انتخاب شده از بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Schedules", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return null;
            }
            #endregion
            return AppWeekPeriodData.ToList();
        }
        #endregion

        #region DateTime? GetSchAppFirstDateTime(Int16 ApplicationID, Boolean IsFirst)
        /// <summary>
        /// تابعی برای خواندن اولین یا آخرین نوبت ثبت شده در بانك برای یك برنامه
        /// </summary>
        /// <param name="ApplicationID">كلید برنامه مورد نظر</param>
        /// <param name="IsFirst">تعیین اولین روز یا آخرین روز</param>
        /// <returns>تاریخ مورد نظر یا تهی برای وقوع خطا</returns>
        public static DateTime? GetSchAppFirstOrLastDateTime(Int16 ApplicationID, Boolean IsFirst)
        {
            SchAppointments ReturnValue;
            try
            {
                if (IsFirst) ReturnValue = Manager.DBML.SchAppointments.Where(Data => Data.ApplicationIX == ApplicationID).
                    OrderBy(Data => Data.OccuredDateTime).Take(1).First();
                else ReturnValue = Manager.DBML.SchAppointments.Where(Data => Data.ApplicationIX == ApplicationID).
                    OrderByDescending(Data => Data.OccuredDateTime).Take(1).First();
                Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, ReturnValue);
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان خواندن اطلاعات نوبت های برنامه های نوبت دهی از بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Schedules", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return null;
            }
            #endregion
            return ReturnValue.OccuredDateTime;
        }
        #endregion

        #region Boolean? GetSchAddinColumnsAppCover(Int16 ColID, Int16 AppID)
        /// <summary>
        /// تابعی برای دسترسی یك برنامه نوبت دهی به یك فیلد پویا نوبت دهی
        /// </summary>
        /// <returns>دسترسی برنامه یا تهی برای وقوع خطا</returns>
        public static Boolean? GetSchAddinColumnsAppCover(Int16 ColID, Int16 AppID)
        {
            try
            {
                IQueryable<SchAddinColsAppCover> TempData = Manager.DBML.SchAddinColsAppCovers.
                    Where(Data => Data.ApplicationIX == AppID && Data.FieldIX == ColID);
                Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, TempData);
                if (TempData.Count() == 0) return false;
                return true;
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان خواندن دسترسی برنامه نوبت دهی جاری به ستون های پویا از بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Schedules", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return null;
            }
            #endregion
        }
        #endregion

        #region List<SchAddinDataItemsColCover> GetSchAddinDataItemsColCovers(Int16 AddinColumnID)
        /// <summary>
        /// تابعی برای خواندن آیتم های تحت پوشش فیلد چند گزینه ای پویا برنامه نوبت دهی ، مستقیماً از بانك اطلاعات
        /// </summary>
        /// <returns>اطلاعات برنامه یا تهی برای وقوع خطا</returns>
        public static List<SchAddinDataItemsColCover> GetSchAddinDataItemsColCovers(Int16 AddinColumnID)
        {
            IQueryable<SchAddinDataItemsColCover> SchAddinDataItemsColCovers;
            try
            {
                SchAddinDataItemsColCovers =
                    Manager.DBML.SchAddinDataItemsColCovers.Where(Data => Data.ColumnIX == AddinColumnID);
                Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, SchAddinDataItemsColCovers);
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان خواندن آیتم های تحت پوشش فیلد پویای انتخاب شده از بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Schedules", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return null;
            }
            #endregion
            return SchAddinDataItemsColCovers.ToList();
        }
        #endregion

        #region Boolean InsertSchAppWeekPeriod(...)
        /// <summary>
        /// تابعی برای ثبت دوره های زمانی برنامه نوبت دهی جدید در بانك اطلاعات
        /// </summary>
        /// <returns>صحت ثبت اطلاعات یا وقوع خطا</returns>
        public static Boolean InsertSchAppWeekPeriod(Int16 ApplicationIX, Byte DayNo,
            DateTime BeginTime, DateTime EndTime, Int16 Capacity, Byte RoundingMinute)
        {
            SchAppWeekPeriods NewAppPeriod = new SchAppWeekPeriods();
            NewAppPeriod.ApplicationIX = ApplicationIX;
            NewAppPeriod.DayNo = DayNo;
            NewAppPeriod.BeginTime = BeginTime;
            NewAppPeriod.EndTime = EndTime;
            NewAppPeriod.Capacity = Capacity;
            NewAppPeriod.RoundingMinute = RoundingMinute;
            Manager.DBML.SchAppWeekPeriods.InsertOnSubmit(NewAppPeriod);
            if (!Manager.Submit())
            {
                const String ErrorMessage =
                    "امكان ثبت اطلاعات ساختار برنامه ی نوبت دهی در بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        #endregion

        #region Boolean InsertOneDayAppointments(...)
        /// <summary>
        /// تابعی برای ثبت نوبت های یك روز مشخص برای برنامه نوبت دهی در بانك اطلاعات
        /// </summary>
        /// <returns>صحت ثبت اطلاعات یا وقوع خطا</returns>
        public static Boolean InsertOneDayAppointments(Int16 ApplicationIX, DateTime BeginTime, DateTime EndTime,
            Int16 Capacity, Int16 RoundingMinute)
        {
            try { Manager.DBML.SP_InsertOneDayAppointments(ApplicationIX, BeginTime, EndTime, Capacity, RoundingMinute); }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان ثبت نوبت های انتخاب شده برای برنامه ی نوبت دهی مورد نظر در بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Schedules", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion
            return true;
        }
        #endregion

        #region Boolean DeleteSchApp(Int16 ApplicationID)
        /// <summary>
        /// تابعی برای حذف یك برنامه نوبت دهی از بانك اطلاعات
        /// </summary>
        /// <returns>حذف موفقیت آمیز یا وقوع خطا</returns>
        public static Boolean DeleteSchApp(Int16 ApplicationID)
        {
            try
            {
                IQueryable<SchApplications> DataToDelete =
                    Manager.DBML.SchApplications.Where(Data => Data.ID == ApplicationID);
                Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, DataToDelete);
                Manager.DBML.SchApplications.DeleteAllOnSubmit(DataToDelete);
                if (!Manager.Submit())
                {
                    const String ErrorMessage = "امكان حذف برنامه ی نوبت دهی از بانك وجود ندارد.\n" +
                        "موارد زیر را بررسی نمایید:\n" +
                        "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            #region Catch
            catch (Exception)
            {
                const String ErrorMessage = "امكان حذف برنامه ی نوبت دهی از بانك وجود ندارد.\n" +
                        "موارد زیر را بررسی نمایید:\n" +
                        "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion
            return true;
        }
        #endregion

        // ======================= فرم نوبت دهی ==========================

        #region DateTime? GetSchApplicationNextOrPrevDay(Int16 ApplicationID, DateTime CurrentDate, Boolean IsNext)
        /// <summary>
        /// تابع پیدا كردن روز بعدی یك شیفت در یك برنامه نوبت دهی بر اساس تاریخ ارائه شده
        /// </summary>
        /// <param name="ApplicationID">كلید برنامه نوبت دهی</param>
        /// <param name="CurrentDate">تاریخ مورد نظر برای مقایسه</param>
        /// <param name="IsNext">شیفت بعدی یا قبلی</param>
        /// <returns>قفل بودن یا آزاد بودن نوبت</returns>
        public static DateTime? GetSchApplicationNextOrPrevDay(Int16 ApplicationID, DateTime CurrentDate, Boolean IsNext)
        {
            DateTime? TheDay = null;
            try
            {
                if (IsNext)
                {
                    CurrentDate = new DateTime(CurrentDate.Year, CurrentDate.Month, CurrentDate.Day, 23, 59, 59, 59);
                    Manager.DBML.SP_SelectAppNextDay(ApplicationID, CurrentDate, ref TheDay);
                }
                else
                {
                    CurrentDate = new DateTime(CurrentDate.Year, CurrentDate.Month, CurrentDate.Day, 0, 0, 0, 0);
                    Manager.DBML.SP_SelectAppPrevDay(ApplicationID, CurrentDate, ref TheDay);
                }
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان خواندن روز بعدی برنامه نوبت دهی انتخاب شده از بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Schedules Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return null;
            }
            #endregion
            return TheDay;
        }
        #endregion

        #region Boolean CheckLockAppointment(Int32 AppointmentID)
        /// <summary>
        /// تابع بررسی قفل بودن یك ردیف نوبت
        /// </summary>
        /// <param name="AppointmentID">كلید نوبت</param>
        /// <returns>قفل بودن یا آزاد بودن نوبت</returns>
        public static Boolean CheckLockAppointment(Int32 AppointmentID)
        {
            Boolean? IsEditing = false;
            try
            {
                Manager.DBML.SP_CheckLockAppointments(AppointmentID, ref IsEditing);
                if (IsEditing == true)
                {
                    PMBox.Show("این نوبت توسط كاربر دیگری در حال ویرایش می باشد!\n" +
                    "ممكن است تداخل اطلاعات بین 2 كاربر ایجاد شود.",
                        "محدودیت دسترسی!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان خواندن وضعیت نوبت انتخاب شده از بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Schedules Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion
            return true;
        }
        #endregion

        #region Boolean ChangeLockAppointment(Int32 AppointmentID, Boolean IsLock)
        /// <summary>
        /// تابع تغییر وضعیت قفل بودن یك ردیف نوبت
        /// </summary>
        /// <param name="AppointmentID">كلید نوبت</param>
        /// <param name="IsLock">قفل كردن یا آزاد كردن</param>
        /// <returns>صحت انجام كار</returns>
        public static Boolean ChangeLockAppointment(Int32 AppointmentID, Boolean IsLock)
        {
            try { Manager.DBML.SP_ChangeLockAppointments(Convert.ToInt32(AppointmentID), IsLock); }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان تغییر وضعیت قفل بدون نوبت انتخاب شده وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Schedules Forms", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error); return false;
            }
            #endregion
            return true;
        }
        #endregion

        #region List<SP_SelectMultiSelectItemsResult> GetMultiSelectItemsByColID(Int16 ColID)
        /// <summary>
        /// تابع ارائه لیست آیتم های مجاز ستون پویا
        /// </summary>
        /// <param name="ColID">كلید ستون پویا چند گزینه ای</param>
        /// <returns>لیست آیتم های یا تهی برای خطا</returns>
        public static List<SP_SelectMultiSelectItemsResult> GetMultiSelectItemsByColID(Int16 ColID)
        {
            try { return Manager.DBML.SP_SelectMultiSelectItems(ColID).ToList(); }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان خواندن آیتم های مجاز ستون پویای انتخاب شده وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Schedules Forms", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error); return null;
            }
            #endregion
        }
        #endregion

        // ======================= سابقه نوبت ==========================

        #region List<SP_SelectLogEventsResult> SchAppointmentLogEvents(Int32 AppointmentID)
        ///<summary>
        /// تابع بازگرداننده لیست سابقه نوبت انتخاب شده
        ///</summary>
        ///<param name="AppointmentID">شناسه نوبت انتخاب شده</param>
        ///<returns></returns>
        public static List<SP_SelectLogEventsResult> SchAppointmentLogEvents(Int32 AppointmentID)
        {
            try { return Manager.DBML.SP_SelectLogEvents(AppointmentID).ToList(); }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان خواندن سابقه نوبت انتخاب شده وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Schedules Forms", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error); return null;
            }
            #endregion
        }
        #endregion

        #region Boolean InsertSchLogEvents(Int32 AppointmentIX, Byte CategoryIX, String ColumnName, String Value)
        ///<summary>
        /// تابع ثبت رخدادهای نوبت دهی در بانك اطلاعاتی
        ///</summary>
        ///<param name="AppointmentIX">شناسه نوبت</param>
        ///<param name="CategoryIX">شناسه طبقه بندی</param>
        ///<param name="ColumnName">نام ستونی كه تغییر كرده</param>
        ///<param name="Value">مقدار ستون پس از تغییر</param>
        ///<returns></returns>
        public static Boolean InsertSchLogEvents(Int32 AppointmentIX, Byte CategoryIX, String ColumnName, String Value)
        {

            SchLogEvents LogEvent = new SchLogEvents();
            LogEvent.AppointmentIX = AppointmentIX;
            LogEvent.CategoryIX = CategoryIX;
            LogEvent.Date = DateTime.Now;
            LogEvent.UserIX = SecurityManager.CurrentUserID;
            switch (CategoryIX)
            {
                //لغو شدن نوبت
                case 100:LogEvent.Description = null;break;
                //پر شدن نوبت
                case 101:LogEvent.Description = null;break;
                //فعال شدن نوبت
                case 102:LogEvent.Description = null;break;
                //غیر فعال شدن نوبت
                case 103:LogEvent.Description = null;break;
                //تغییر مقدار ستون
                case 104:LogEvent.Description = "ستون \"" + ColumnName + "\" به مقدار: \"" 
                    + Value + "\" تغییر كرد.\n";break;
                //خالی شدن ستون
                case 105:LogEvent.Description = "نام ستون : " + ColumnName;break;
                //كپی كردن
                case 106: LogEvent.Description = ColumnName; break;
                //انتقال نوبت
                case 107: LogEvent.Description = ColumnName; break;
                //جایگذاری از كپی
                case 108: LogEvent.Description = ColumnName; break;
                //جایگذاری از انتقال
                case 109: LogEvent.Description = ColumnName; break;
            }
            Manager.DBML.SchLogEvents.InsertOnSubmit(LogEvent);
            if (!Manager.Submit())
            {
                const String ErrorMessage =
                    "خطا در ثبت رخداد های نوبت دهی در بانك اطلاعات.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        #endregion

        #endregion

    }
}