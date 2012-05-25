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
    /// كلاس مدیریت اطلاعات مراجعات تصویربرداری
    /// </summary>
    public static class Referrals
    {

        #region Fields
        private static List<SP_SelectPerformersResult> _RefServPerformers;
        private static List<PatAdditionalColumn> _PatAddinColsList;
        private static List<PatAdditionalDataItem> _PatAddinDataItemsList;
        private static List<RefAdditionalColumn> _RefAddinColsList;
        private static List<RefAdditionalDataItem> _RefAddinDataItemsList;
        private static List<SP_SelectStatusResult> _RefStatusList;
        #endregion

        #region Properties

        #region List<PatAdditionalColumn> PatAddinColsList
        /// <summary>
        /// لیست فیلد های پویا بیماران تصویربرداری
        /// </summary>
        public static List<PatAdditionalColumn> PatAddinColsList
        {
            get
            {
                if (_PatAddinColsList == null)
                    try
                    {
                        Table<PatAdditionalColumn> TempData = Manager.DBML.PatAdditionalColumns;
                        Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, TempData);
                        _PatAddinColsList = TempData.ToList();
                    }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage = "خواندن لیست ستون های اطلاعاتی پویا بیماران ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Sepehr", "DBLayer - Referrals",
                            Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                        return null;
                    }
                    #endregion
                return _PatAddinColsList;
            }
            set { _PatAddinColsList = value; }
        }
        #endregion

        #region List<PatAdditionalDataItem> PatAddinDataItemsList
        /// <summary>
        /// لیست آیتم های قابل استفاده در فیلد های پویای چند گزینه ای بیماران
        /// </summary>
        public static List<PatAdditionalDataItem> PatAddinDataItemsList
        {
            get
            {
                if (_PatAddinDataItemsList == null)
                    try
                    {
                        Table<PatAdditionalDataItem> TempData = Manager.DBML.PatAdditionalDataItems;
                        Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, TempData);
                        _PatAddinDataItemsList = TempData.ToList();
                    }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage = "خواندن لیست آیتم های فیلد های چند گزینه ای بیماران ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Sepehr", "DBLayer - Referrals",
                            Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                        return null;
                    }
                    #endregion
                return _PatAddinDataItemsList;
            }
            set { _PatAddinDataItemsList = value; }
        }
        #endregion

        #region List<RefAdditionalColumn> RefAddinColsList
        /// <summary>
        /// لیست فیلد های پویا مراجعات بیماران تصویربرداری
        /// </summary>
        public static List<RefAdditionalColumn> RefAddinColsList
        {
            get
            {
                if (_RefAddinColsList == null)
                    try
                    {
                        Table<RefAdditionalColumn> TempData = Manager.DBML.RefAdditionalColumns;
                        Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, TempData);
                        _RefAddinColsList = TempData.ToList();
                    }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage = "خواندن لیست ستون های اطلاعاتی پویا مراجعات بیماران ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Sepehr", "DBLayer - Referrals",
                            Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                        return null;
                    }
                    #endregion
                return _RefAddinColsList;
            }
            set { _RefAddinColsList = value; }
        }
        #endregion

        #region List<RefAdditionalDataItem> RefAddinDataItemsList
        /// <summary>
        /// لیست آیتم های قابل استفاده در فیلد های پویای چند گزینه ای بیماران
        /// </summary>
        public static List<RefAdditionalDataItem> RefAddinDataItemsList
        {
            get
            {
                if (_RefAddinDataItemsList == null)
                    try
                    {
                        Table<RefAdditionalDataItem> TempData = Manager.DBML.RefAdditionalDataItems;
                        Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, TempData);
                        _RefAddinDataItemsList = TempData.ToList();
                    }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage = "خواندن لیست آیتم های فیلد های چند گزینه ای مراجعات ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Sepehr", "DBLayer - Referrals",
                            Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                        return null;
                    }
                    #endregion
                return _RefAddinDataItemsList;
            }
            set { _RefAddinDataItemsList = value; }
        }
        #endregion

        #region List<SP_SelectCategoriesResult> RefServPerformers
        /// <summary>
        /// لیست پزشكان و كارشناسان خدمات تصویربرداری
        /// </summary>
        /// <remarks>
        /// بدون اعمال فعال بودن یا نبودن آنها. همراه با آیتم انتخاب نشده
        /// </remarks>
        public static List<SP_SelectPerformersResult> RefServPerformers
        {
            get
            {
                if (_RefServPerformers == null)
                    try { _RefServPerformers = Manager.DBML.SP_SelectPerformers().ToList(); }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage = "خواندن لیست طبقه بندی های خدمات تعریف شده ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Sepehr", "DBLayer - Referrals",
                            Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                        return null;
                    }
                    #endregion
                return _RefServPerformers;
            }
            set { _RefServPerformers = value; }
        }
        #endregion

        #region List<SP_SelectStatusResult> RefStatusList
        /// <summary>
        /// لیست وضعیت های مراجعه تصویربرداری
        /// </summary>
        /// <remarks>
        /// بدون اعمال فعال بودن یا نبودن آنها. همراه با آیتم انتخاب نشده
        /// </remarks>
        public static List<SP_SelectStatusResult> RefStatusList
        {
            get
            {
                if (_RefStatusList == null)
                    try { _RefStatusList = Manager.DBML.SP_SelectStatus().ToList(); }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage = "خواندن لیست وضعیت های مراجعه تعریف شده ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Sepehr", "DBLayer - Referrals",
                            Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                        return null;
                    }
                    #endregion
                return _RefStatusList;
            }
            set { _RefStatusList = value; }
        }
        #endregion

        #endregion

        #region Methods

        #region List<PatAdditionalDataItemsColCover> GetPatAddinDataItemsColCovers(Int16 AddinColumnID)
        /// <summary>
        /// تابعی برای خواندن آیتم های تحت پوشش فیلد چند گزینه ای پویا
        /// </summary>
        /// <returns>اطلاعات برنامه یا تهی برای وقوع خطا</returns>
        public static List<PatAdditionalDataItemsColCover> GetPatAddinDataItemsColCovers(Int16 AddinColumnID)
        {
            IQueryable<PatAdditionalDataItemsColCover> AddinDataItemsColCovers;
            try
            {
                AddinDataItemsColCovers =
                    Manager.DBML.PatAdditionalDataItemsColCovers.Where(Data => Data.ColumnIX == AddinColumnID);
                Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, AddinDataItemsColCovers);
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان خواندن آیتم های تحت پوشش فیلد پویای انتخاب شده از بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Schedules", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return null;
            }
            #endregion
            return AddinDataItemsColCovers.ToList();
        }
        #endregion

        #region List<RefAdditionalDataItemsColCover> GetRefAddinDataItemsColCovers(Int16 AddinColumnID)
        /// <summary>
        /// تابعی برای خواندن آیتم های تحت پوشش فیلد چند گزینه ای پویا
        /// </summary>
        /// <returns>اطلاعات برنامه یا تهی برای وقوع خطا</returns>
        public static List<RefAdditionalDataItemsColCover> GetRefAddinDataItemsColCovers(Int16 AddinColumnID)
        {
            IQueryable<RefAdditionalDataItemsColCover> AddinDataItemsColCovers;
            try
            {
                AddinDataItemsColCovers =
                    Manager.DBML.RefAdditionalDataItemsColCovers.Where(Data => Data.ColumnIX == AddinColumnID);
                Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, AddinDataItemsColCovers);
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان خواندن آیتم های تحت پوشش فیلد پویای انتخاب شده از بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Schedules", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return null;
            }
            #endregion
            return AddinDataItemsColCovers.ToList();
        }
        #endregion

        #region Int32? GetPatIDByRefID(Int32 RefID)
        /// <summary>
        /// تابعی برای خواندن كلید بیمار ، بر اساس كلید مراجعه تصویربرداری بیمار
        /// </summary>
        /// <returns>كلید بیمار یا تهی برای وقوع خطا</returns>
        public static Int32? GetPatIDByRefID(Int32 RefID)
        {
            Int32? ReturnValue;
            try
            { ReturnValue = Manager.DBML.RefLists.Where(Data => Data.ID == RefID).Select(Data => Data.PatientIX).First(); }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان خواندن كلید بیمار بر اساس كلید مراجعه ارسال شده از بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Referrals", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return null;
            }
            #endregion
            return ReturnValue;
        }
        #endregion

        #region List<Int32> GetPatRefIDListByPatID(Int32 PID)
        /// <summary>
        /// تابعی برای خواندن لیست كلید های مراجعات بیمار ، بر اساس كلید بیمار
        /// </summary>
        /// <returns>لیست كلیدهای مراجعات بیمار یا تهی برای وقوع خطا</returns>
        public static List<Int32> GetPatRefIDListByPatID(Int32 PID)
        {
            List<Int32> ReturnValue;
            try
            {
                ReturnValue = Manager.DBML.RefLists.Where(Data => Data.PatientIX == PID)
                  .OrderBy(Data => Data.RegisterDate).Select(Data => Data.ID).ToList();
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان خواندن لیست كلید های مراجعات بیمار ارسال شده از بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "DB Layer - Referrals", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error);
                return null;
            }
            #endregion
            return ReturnValue;
        }
        #endregion

        #region RefList GetRefDataByID(Int32 RefID)
        /// <summary>
        /// تابع بدست آوردن اطلاعات مراجعه ی بیمار مورد نظر
        /// </summary>
        /// <param name="RefID">كلید مراجعه</param>
        /// <returns>اطلاعات مراجعه یا تهی برای خطا</returns>
        public static RefList GetRefDataByID(Int32 RefID)
        {
            RefList RefData = null;
            try
            {
                IQueryable<RefList> TempData = Manager.DBML.RefLists.Where(Data => Data.ID == RefID);
                Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, TempData);
                if (TempData.Count() != 0) RefData = TempData.First();
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "خواندن اطلاعات مراجعه انتخاب شده از بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟\n" +
                    "2. آیا مراجعه انتخاب شده حذف نشده است؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "DbLayer - Referrals", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error); return null;
            }
            #endregion
            return RefData;
        }
        #endregion

        #region Int32? GetPatRefCountByPatID(Int32 PatID)
        /// <summary>
        /// تابعی برای خواندن تعداد مراجعات بیمار با كلید بیمار
        /// </summary>
        /// <returns>تعداد مراجعه یا تهی برای وقوع خطا</returns>
        public static Int32? GetPatRefCountByPatID(Int32 PatID)
        {
            Int32? ReturnValue;
            try
            { ReturnValue = Manager.DBML.RefLists.Where(Data => Data.PatientIX == PatID).Count(); }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان خواندن تعداد مراجعات بیمار بر اساس كلید بیمار ارسال شده از بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Referrals", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return null;
            }
            #endregion
            return ReturnValue;
        }
        #endregion

        #region Int32? GetPatFirstOrLastRefID(Int32 PatientID, Boolean IsLast)
        /// <summary>
        /// تابع بدست آوردن كلید اولین یا آخرین مراجعه ی یك بیمار
        /// </summary>
        /// <param name="PatientID">كد بیمار</param>
        /// <param name="IsLast">آخرین مراجعه یا اولین مراجعه</param>
        /// <returns>كلید مراجعه ، صفر برای عدم وجود یا تهی برای خطا</returns>
        public static Int32? GetPatFirstOrLastRefID(Int32 PatientID, Boolean IsLast)
        {
            IQueryable<Int32> RefData;
            try
            {
                if (IsLast) RefData = Manager.DBML.RefLists.Where(Data => Data.PatientIX == PatientID).
                        OrderByDescending(Data => Data.RegisterDate).ThenByDescending(Data => Data.ID).
                        Select(Data => Data.ID).Take(1);
                else RefData = Manager.DBML.RefLists.Where(Data => Data.PatientIX == PatientID).
                        OrderBy(Data => Data.RegisterDate).ThenBy(Data => Data.ID).
                        Select(Data => Data.ID).Take(1);
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "خواندن اولین یا آخرین كلید مراجعه بیمار ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "DbLayer - Referrals", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error); return null;
            }
            #endregion
            if (RefData.Count() == 0) return 0;
            return RefData.First();
        }
        #endregion

        #region Int32? GetPatRefNextOrPrevRefID(Int32 CurrentRefID, Boolean IsNext)
        /// <summary>
        /// تابع بدست آوردن كلید مراجعه قبلی یا بعدی بیمار نسبت به مراجعه جاری
        /// </summary>
        /// <param name="CurrentRefID">كلید مراجعه</param>
        /// <param name="IsNext">پیدا كردن مراجعه بعدی یا قبلی</param>
        /// <returns>كلید مراجعه یا صفر برای عدم وجود یا تهی برای خطا</returns>
        public static Int32? GetPatRefNextOrPrevRefID(Int32 CurrentRefID, Boolean IsNext)
        {
            Int32? TempPatientID = GetPatIDByRefID(CurrentRefID);
            if (TempPatientID == null) return null;
            Int32 PatientID = TempPatientID.Value;
            // بررسی یكسان بودن اولین یا آخرین مراجعه و مراجعه جاری
            Int32? FirstOrLastPatRefID = GetPatFirstOrLastRefID(PatientID, IsNext);
            if (FirstOrLastPatRefID == null) return null; // اگر خطایی رخ دهد تهی باز گردانده می شود
            if (FirstOrLastPatRefID.Value == 0) return 0; // اگر بیماری در سیستم وجود نداشت 0 باز می گرداند
            // اگر اولین یا آخرین مراجعه بیمار با مراجعه جاری یكسان بود مراجعه جاری باز گردانده می شود
            if (FirstOrLastPatRefID == CurrentRefID) return CurrentRefID;
            // در غیر اینصورت كد مراجعه قبلی یا بعدی را پیدا میكنیم
            try
            {
                if (IsNext) return Manager.DBML.RefLists.Where(Data => Data.PatientIX == PatientID && Data.ID != CurrentRefID &&
                    Data.RegisterDate >= Manager.DBML.RefLists.
                    Where(TheData => TheData.ID == CurrentRefID).Select(TheData => TheData.RegisterDate).First()).
                    OrderBy(Data => Data.RegisterDate).ThenBy(Data => Data.ID).Select(Data => Data.ID).Take(1).First();
                return Manager.DBML.RefLists.Where(Data => Data.PatientIX == PatientID && Data.ID != CurrentRefID &&
                    Data.RegisterDate <= Manager.DBML.RefLists.
                    Where(TheData => TheData.ID == CurrentRefID).Select(TheData => TheData.RegisterDate).First()).
                    OrderByDescending(Data => Data.RegisterDate).
                    ThenByDescending(Data => Data.ID).Select(Data => Data.ID).Take(1).First();
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "خواندن كلید مراجعه بعدی یا قبلی بیمار انتخاب شده از بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "DbLayer - Referrals", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error); return null;
            }
            #endregion
        }
        #endregion

        #region Int32? GetPatFirstOrLastDocID(Int32 PatientID, Boolean IsLast)
        /// <summary>
        /// تابع بدست آوردن كلید اولین یا آخرین مدرك تصویربرداری ثبت شده برای یك بیمار
        /// </summary>
        /// <param name="PatientID">كد بیمار</param>
        /// <param name="IsLast">آخرین مدرك یا اولین مدرك</param>
        /// <returns>كلید مراجعه ، صفر برای عدم وجود یا تهی برای خطا</returns>
        public static Int32? GetPatFirstOrLastDocID(Int32 PatientID, Boolean IsLast)
        {
            Int32? LastRefID = GetPatFirstOrLastRefID(PatientID, true);
            if (LastRefID == null) return null;
            IQueryable<Int32> DocsData;
            try
            {
                if (IsLast) DocsData = Manager.DBML.RefDocuments.Where(Data => Data.RefIX == LastRefID).
                        OrderByDescending(Data => Data.Date).ThenByDescending(Data => Data.ID).
                        Select(Data => Data.ID).Take(1);
                else DocsData = Manager.DBML.RefDocuments.Where(Data => Data.RefIX == LastRefID).
                        OrderBy(Data => Data.Date).ThenBy(Data => Data.ID).
                        Select(Data => Data.ID).Take(1);
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "خواندن اولین یا آخرین مدرك تصویربرداری بیمار انتخاب شده ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "DbLayer - Referrals", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error); return null;
            }
            #endregion
            if (DocsData.Count() == 0) return 0;
            return DocsData.First();
        }
        #endregion

        #region Int32? DeletePatRef(Int32 RefID)
        /// <summary>
        /// حذف مراجعه یك بیمار ار بانك
        /// </summary>
        /// <param name="RefID">كلید مراجعه</param>
        /// <returns>كلید مراجعه ای كه باید بعد از حذف نمایش داده شود یا صفر برای حذف آخرین مراجعه بیمار یا تهی برای خطا</returns>
        public static Int32? DeletePatRef(Int32 RefID)
        {
            Int32? TempPatientID = GetPatIDByRefID(RefID);
            if (TempPatientID == null) return null;
            Int32 PatientID = TempPatientID.Value;
            // بیمار بعدی كه باید انتخاب شود و یا 0 برای نبودن بیمار
            Int32? LaterRefID;
            Int32? FirstRefID = GetPatFirstOrLastRefID(PatientID, false);
            Int32? LastRefID = GetPatFirstOrLastRefID(PatientID, true);
            if (FirstRefID == null || LastRefID == null || FirstRefID.Value == 0 || LastRefID.Value == 0) return null;
            // بررسی حالتی كه مراجعه جاری ای كه میخواهد حذف شود تنها مراجعه بیمار است
            // در این حالت پس از حذف مقدار مراجعه بعدی 0 خواهد شد
            if (FirstRefID.Value == LastRefID.Value) LaterRefID = 0;
            // OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
            // بررسی اینكه مراجعه بیماری كه می خواهد حذف شود ، آخرین مراجعه بیمار باشد.
            // در این صورت مراجعه بعدی كه انتخاب می شود بیمار یكی مانده به آخر خواهد بود
            else if (RefID == LastRefID.Value) LaterRefID = GetPatRefNextOrPrevRefID(RefID, false);
            // OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
            // بررسی اینكه مراجعه بیماری كه می خواهد حذف شود ، آخرین مراجعه بیمار نباشد.
            // در این صورت بیمار بعدی كه انتخاب می شود بیمار بعدی نسبت به بیمار جاری خواهد بود
            else LaterRefID = GetPatRefNextOrPrevRefID(RefID, true);
            // OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
            if (LaterRefID == null) return null;
            // حذف مراجعه بیمار از بانك اطلاعات
            Manager.DBML.RefLists.DeleteAllOnSubmit(Manager.DBML.RefLists.Where(Data => Data.ID == RefID));
            if (!Manager.Submit())
            {
                const String ErrorMessage = "حذف مراجعه انتخاب شده برای بیمار از بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            return LaterRefID;
        }
        #endregion

        // ==============================================

        #region Boolean CheckRefIsLock(Int32 RefID)
        /// <summary>
        /// تابعی برای بررسی وضعیت قفل بودن مراجعه یك بیمار
        /// </summary>
        /// <param name="RefID">كلید مراجعه</param>
        public static Boolean CheckRefIsLock(Int32 RefID)
        {
            Boolean? IsLock = null;
            try { Manager.DBML.SP_CheckLockRefList(RefID, ref IsLock); }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان خواندن قفل بودن مراجعه بیمار از بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "DB Layer - Referrals", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error); return true;
            }
            #endregion
            if (IsLock == null || IsLock.Value)
            {
                PMBox.Show("مراجعه جاری توسط كاربر دیگری در حال ویرایش می باشد و امكان ویرایش آن وجود ندارد!",
                    "محدودیت دسترسی!", MessageBoxButtons.OK, MessageBoxIcon.Stop); return false;
            }
            return true;
        }
        #endregion

        #region Boolean ChangeRefLock(Int32 RefID, Boolean IsLock)
        /// <summary>
        /// تابعی برای تغییر دادن وضعیت قفل بودن یك مراجعه تصویربرداری
        /// </summary>
        /// <param name="RefID">كلید مراجعه</param>
        /// <param name="IsLock">وضعیت مورد نظر</param>
        public static Boolean ChangeRefLock(Int32 RefID, Boolean IsLock)
        {
            try { Manager.DBML.SP_ChangeLockRefList(RefID, IsLock); }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان آزاد نمودن مراجعه بیمار انتخاب شده وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Db Layer - Referrals", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error); return false;
            }
            #endregion
            return true;
        }
        #endregion

        #endregion

    }
}