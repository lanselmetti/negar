#region using
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Negar.DBLayerPMS.DataLayer;
using Negar.PersianCalendar.Utilities;
#endregion

namespace Negar.DBLayerPMS
{
    /// <summary>
    /// كلاس مدیریت اطلاعات بیماران
    /// </summary>
    public static class Patients
    {

        #region Fields
        private static List<SP_SelectCountriesResult> _CountriesList;
        private static List<SP_SelectStatesResult> _StatesList;
        private static List<SP_SelectCitiesResult> _CitiesList;
        private static List<SP_SelectJobsResult> _PatientsJobsList;
        #endregion

        #region Properties

        #region List<SP_SelectCountriesResult> CountriesList
        /// <summary>
        /// لیست كشورهای ثبت شده در سیستم
        /// </summary>
        /// <remarks>
        /// بدون اعمال فعال بودن یا نبودن آنها. - یه همراه آیتم انتخاب نشده
        /// </remarks>
        public static List<SP_SelectCountriesResult> CountriesList
        {
            get
            {
                if (_CountriesList == null)
                    try { _CountriesList = Manager.DBML.SP_SelectCountries().ToList(); }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage = "امكان خواندن لیست كشورها از بانك اطلاعات ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Negar", "DB Layer - Patients",
                            Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                        return null;
                    }
                    #endregion
                return _CountriesList;
            }
            set { _CountriesList = value; }
        }
        #endregion

        #region List<SP_SelectStatesResult> StatesList
        /// <summary>
        /// لیست استان های ثبت شده در سیستم
        /// </summary>
        /// <remarks>
        /// بدون اعمال فعال بودن یا نبودن آنها. - یه همراه آیتم انتخاب نشده
        /// </remarks>
        public static List<SP_SelectStatesResult> StatesList
        {
            get
            {
                if (_StatesList == null)
                    try { _StatesList = Manager.DBML.SP_SelectStates().ToList(); }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage = "امكان خواندن لیست استان ها از بانك اطلاعات ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Negar", "DB Layer - Patients",
                            Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                        return null;
                    }
                    #endregion
                return _StatesList;
            }
            set { _StatesList = value; }
        }
        #endregion

        #region List<SP_SelectCitiesResult> CitiesList
        /// <summary>
        /// لیست استان های ثبت شده در سیستم
        /// </summary>
        /// <remarks>
        /// بدون اعمال فعال بودن یا نبودن آنها. - یه همراه آیتم انتخاب نشده
        /// </remarks>
        public static List<SP_SelectCitiesResult> CitiesList
        {
            get
            {
                if (_CitiesList == null)
                    try { _CitiesList = Manager.DBML.SP_SelectCities().ToList(); }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage = "امكان خواندن لیست شهرها از بانك اطلاعات ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Negar", "DB Layer - Patients",
                            Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                        return null;
                    }
                    #endregion
                return _CitiesList;
            }
            set { _CitiesList = value; }
        }
        #endregion

        #region List<SP_SelectJobsResult> PatientsJobsList
        /// <summary>
        /// لیست مشاغل بیماران ثبت شده در سیستم
        /// </summary>
        /// <remarks>
        /// بدون اعمال فعال بودن یا نبودن آنها. - یه همراه آیتم انتخاب نشده
        /// </remarks>
        public static List<SP_SelectJobsResult> PatientsJobsList
        {
            get
            {
                if (_PatientsJobsList == null)
                    try { _PatientsJobsList = Manager.DBML.SP_SelectJobs().ToList(); }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage = "امكان خواندن لیست مشاغل بیماران از بانك اطلاعات ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Negar", "DB Layer - Patients",
                            Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                        return null;
                    }
                    #endregion
                return _PatientsJobsList;
            }
            set { _PatientsJobsList = value; }
        }
        #endregion

        #endregion

        #region Methods

        #region PatList GetPatFullDataByPatListID(Int32 PatID)
        /// <summary>
        /// تابعی برای خواندن اطلاعات كامل یك بیمار از بانك اطلاعات
        /// </summary>
        /// <param name="PatID">كلید بیمار</param>
        /// <returns>شیء اطلاعات كاربر</returns>
        public static PatList GetPatFullDataByPatListID(Int32 PatID)
        {
            try
            {
                PatList PatData = Manager.DBML.PatLists.Where(Data => Data.ID == PatID).First();
                Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, PatData);
                PatData.PatDetail = Manager.DBML.PatDetails.Where(Data => Data.PatientListIX == PatID).First();
                if (PatData.PatDetail != null)
                    Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, PatData.PatDetail);
                return PatData;
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان خواندن اطلاعات بیمار انتخاب شده وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا بیمار انتخاب شده در سیستم ثبت شده است؟\n" +
                    "2. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Negar", "DB Layer - Patients",
                    Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return null;
            }
            #endregion
        }
        #endregion

        #region String GenerateNewPatientID()
        /// <summary>
        /// روالی برای تولید شماره بیمار جدید بر اساس تاریخ جاری سیستم
        /// </summary>
        /// <returns>كلید بیماری كه باید بعد از حذف نمایش داده شود یا 0 برای حذف آخرین بیمار یا تهی برای خطا</returns>
        public static String GenerateNewPatientID()
        {
            DateTime? CurrentDate = Manager.ServerCurrentDateTime;
            if (CurrentDate == null) return String.Empty;
            String CurrentPersianDateString = PersianDateConverter.
                ToPersianDate(CurrentDate.Value).ToString("YYMMDD");
            // حذف علامت های اضافی برای ارسال به تابع ثبت بیمار جهت تولید شماره بیمار
            CurrentPersianDateString = CurrentPersianDateString.Remove(7, 1);
            CurrentPersianDateString = CurrentPersianDateString.Remove(4, 1);
            CurrentPersianDateString = CurrentPersianDateString.Remove(0, 2);
            String NewPatientID = String.Empty;
            try { Manager.DBML.SP_SelectLastPatientID(CurrentPersianDateString, ref NewPatientID); }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان تولید شماره بیمار جدید ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Negar", "Db Layer - Patients", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error); return String.Empty;
            }
            #endregion
            return NewPatientID;
        }
        #endregion

        #region Boolean AddNewNameTranslation(String LocaleName , String EnglishName , Boolean IsFirstName)
        /// <summary>
        /// روالی برای ثبت معادل نام محلی یا به روز رسانی آن در بانك دانش نرم افزار
        /// </summary>
        /// <returns>صحت انجام كار</returns>
        public static Boolean AddNewNameTranslation(String LocaleName, String EnglishName, Boolean IsFirstName)
        {
            try
            {
                IQueryable<NamesBank> TempData = Manager.DBML.NamesBanks.
                    Where(Data => Data.LocaleName == LocaleName.Trim().Normalize() &&
                        Data.IsFirstName == IsFirstName);
                Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, TempData);
                if (TempData.Count() == 0)
                {
                    NamesBank NewItem = new NamesBank();
                    NewItem.LocaleName = LocaleName.Trim().Normalize();
                    NewItem.EnglishName = EnglishName.Trim();
                    NewItem.IsFirstName = IsFirstName;
                    Manager.DBML.NamesBanks.InsertOnSubmit(NewItem);
                }
                else TempData.First().EnglishName = EnglishName.Trim();
                Manager.DBML.SubmitChanges();
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان ثبت معادل استثناء برای نام محلی وارد شده ممكن نیست.\n" +
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

        #region Boolean CheckPatIsLock(Int32 PatID)
        /// <summary>
        /// تابعی برای بررسی وضعیت قفل بودن پرونده یك بیمار
        /// </summary>
        /// <param name="PatID">كلید بیمار</param>
        public static Boolean CheckPatIsLock(Int32 PatID)
        {
            Boolean? IsLock = null;
            try { Manager.DBML.SP_CheckLockPatientList(PatID, ref IsLock); }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان خواندن قفل بودن پرونده بیمار از بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Negar", "DB Layer - Patients", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error); return true;
            }
            #endregion
            if (IsLock == null || IsLock.Value)
            {
                PMBox.Show("پرونده بیمار انتخاب شده توسط كاربر دیگری در حال ویرایش می باشد و امكان ویرایش آن وجود ندارد!",
                    "محدودیت دسترسی!", MessageBoxButtons.OK, MessageBoxIcon.Stop); return false;
            }
            return true;
        }
        #endregion

        #region Boolean ChangePatLock(Int32 PatID, Boolean IsLock)
        /// <summary>
        /// تابعی برای تغییر دادن وضعیت قفل بودن پرونده بیمار
        /// </summary>
        /// <param name="PatID">كلید بیمار</param>
        /// <param name="IsLock">وضعیت مورد نظر</param>
        public static Boolean ChangePatLock(Int32 PatID, Boolean IsLock)
        {
            try { Manager.DBML.SP_ChangeLockPatientList(PatID, IsLock); }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان آزاد نمودن پرونده بیمار انتخاب شده وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Negar", "Db Layer - Patients", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error); return false;
            }
            #endregion
            return true;
        }
        #endregion

        #region Int32? GetPatListIDByPatientID(String PatientID)
        /// <summary>
        /// تابعی برای خواندن كلید یك بیمار با استفاده از شماره بیمار
        /// </summary>
        /// <param name="PatientID">شماره بیمار</param>
        /// <returns>كلید بیمار ، صفر برای عدم وجود یا تهی برای خطا</returns>
        public static Int32? GetPatListIDByPatientID(String PatientID)
        {
            try
            {
                IQueryable<Int32> TempData = Manager.DBML.PatLists.
                    Where(Data => Data.PatientID == PatientID).Select(Data => Data.ID);
                if (TempData.Count() == 0) return 0;
                return TempData.First();
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان خواندن كلید بیمار انتخاب شده وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Negar", "DB Layer - Patients",
                    Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return null;
            }
            #endregion
        }
        #endregion

        #region String GetPatientIDByPatListID(Int32 PatID)
        /// <summary>
        /// تابعی برای خواندن شماره یك بیمار با استفاده از كلید بیمار
        /// </summary>
        /// <param name="PatID">كلید بیمار</param>
        /// <returns>شماره بیمار ، صفر برای عدم وجود یا تهی برای خطا</returns>
        public static String GetPatientIDByPatListID(Int32 PatID)
        {
            try
            {
                IQueryable<String> TempData = Manager.DBML.PatLists.
                    Where(Data => Data.ID == PatID).Select(Data => Data.PatientID);
                if (TempData.Count() == 0) return String.Empty;
                return TempData.First();
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان خواندن شماره بیمار انتخاب شده وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Negar", "DB Layer - Patients",
                    Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return null;
            }
            #endregion
        }
        #endregion

        #region Int32? GetFirstOrLastPatientListID(Boolean IsLast)
        /// <summary>
        /// تابع بدست آوردن كلید اولین یا آخرین بیمار ثبت شده
        /// </summary>
        /// <returns>كلید بیمار ، صفر برای عدم وجود ، یا تهی برای خطا</returns>
        public static Int32? GetFirstOrLastPatientListID(Boolean IsLast)
        {
            try
            {
                IOrderedQueryable<Int32> IDList;
                if (IsLast) IDList = Manager.DBML.PatLists.Select(Data => Data.ID).OrderByDescending(Data => Data);
                else IDList = Manager.DBML.PatLists.Select(Data => Data.ID).OrderBy(Data => Data);
                if (IDList.Count() == 0) return 0;
                return IDList.First();
            }
            #region Catch
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                const String ErrorMessage = "امكان خواندن اطلاعات بیماران از بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Negar", "Db Layer - Patients", Ex.Message + "\n" + Ex.StackTrace,
                    EventLogEntryType.Error); return null;
            }
            #endregion
        }
        #endregion

        #region Int32? GetPrevOrNextPatID(Int32 CurrentPatID, Boolean IsNext)
        /// <summary>
        /// تابع بدست آوردن كد بیمار قبلی یا بعدی نسبت به بیمار جاری
        /// </summary>
        /// <param name="CurrentPatID">كد بیمار جاری</param>
        /// <param name="IsNext">بیمار بعدی یا قبلی</param>
        /// <returns>كد بیمار قبلی یا بعدی ، 0 برای عدم وجود بیمار و تهی برای خطا</returns>
        public static Int32? GetPrevOrNextPatID(Int32 CurrentPatID, Boolean IsNext)
        {
            Int32? FirstPatientID;
            Int32? LastPatientID;
            #region Find Next ID
            if (IsNext)
            {
                // بررسی یكسان بودن آخرین بیمار و بیمار جاری یا عدم وجود بیمار در بانك
                LastPatientID = GetFirstOrLastPatientListID(true);
                // اگر مقدار تهی دریافت شده باشد ، تهی به معنی خطا باز گردانده می شود
                // اگر بیماری در سیستم وجود نداشت 0 باز می گرداند
                if (LastPatientID == null || LastPatientID == 0) return LastPatientID;
                // بررسی یكسان بودن آخرین بیمار و بیمار جاری
                // اگر آخرین بیمار با بیمار جاری یكسان بود بیمار جاری باز گردانده می شود
                if (LastPatientID.Value == CurrentPatID) return CurrentPatID;
            }
            #endregion
            #region Find Prev ID
            else
            {
                // بررسی یكسان بودن اولین بیمار و بیمار جاری یا عدم وجود بیمار در بانك
                FirstPatientID = GetFirstOrLastPatientListID(false);
                // اگر مقدار تهی دریافت شده باشد ، تهی به معنی خطا باز گردانده می شود
                // اگر بیماری در سیستم وجود نداشت 0 باز می گرداند
                if (FirstPatientID == null || FirstPatientID == 0) return FirstPatientID;
                // بررسی یكسان بودن اولین بیمار و بیمار جاری
                // اگر اولین بیمار با بیمار جاری یكسان بود بیمار جاری باز گردانده می شود
                if (FirstPatientID.Value == CurrentPatID) return CurrentPatID;
            }
            #endregion
            // در این حالت حتماً  بیمار قبلی یا بعدی وجود دارد كه جستجو می شود
            // در غیر اینصورت كد بیمار قبلی را پیدا میكند
            try
            {
                if (IsNext) return Manager.DBML.PatLists.Where(Data => Data.ID > CurrentPatID).Select(Data => Data.ID).
                    OrderBy(Data => Data).Take(1).First();
                return Manager.DBML.PatLists.Where(Data => Data.ID < CurrentPatID).Select(Data => Data.ID).
                        OrderByDescending(Data => Data).Take(1).First();
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان خواندن اطلاعات كلید بیمار بعدی از بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Negar", "Db Layer - Patients", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error); return null;
            }
            #endregion
        }
        #endregion

        #region String GetEnglishName(String LocaleName , Boolean IsFirstName)
        /// <summary>
        /// تابعی برای تولید معادل انگلیسی یك اسم
        /// </summary>
        /// <param name="LocaleName">نام محلی</param>
        /// <param name="IsFirstName">نام كوچك یا نام خانوادگی</param>
        /// <returns>نام انگلیسی ، یا تهی برای عدم وجود</returns>
        public static String GetEnglishName(String LocaleName, Boolean IsFirstName)
        {
            String ReturnValue = String.Empty;
            try
            {
                IQueryable<NamesBank> TempList = Manager.DBML.NamesBanks.Where(Data => Data.IsFirstName == IsFirstName &&
                    Data.LocaleName == LocaleName.Trim().Normalize());
                Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, TempList);
                List<String> NameList = TempList.Select(Data => Data.EnglishName).ToList();
                if (NameList.Count != 0) ReturnValue = NameList.First();
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "تولید معادل انگلیسی ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Admission Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return null;
            }
            #endregion
            return ReturnValue;
        }
        #endregion

        #region Int32? DeletePatient(Int32 PatID)
        /// <summary>
        /// حذف بیمار انتخاب شده از بانك به همراه اطلاعات موجود در زیر سیستم ها
        /// </summary>
        /// <param name="PatID">كلید بیماری كه باید حذف شود</param>
        /// <returns>كلید بیماری كه باید بعد از حذف نمایش داده شود یا 0 برای حذف آخرین بیمار یا تهی برای خطا</returns>
        public static Int32? DeletePatient(Int32 PatID)
        {
            // بیمار بعدی كه باید انتخاب شود و یا تهی برای موجود نبودن بیمار
            Int32? LaterPatientID;
            Int32? FirstPatientID = GetFirstOrLastPatientListID(false);
            Int32? LastPatientID = GetFirstOrLastPatientListID(true);
            if (FirstPatientID == null || LastPatientID == null) return null;
            // بررسی حالتی كه بیمار جاری ای كه میخواهد حذف شود تنها بیمار سیستم است ، در واقع اولین بیمار با آخرین بیمار برابر است
            // در این حالت پس از حذف مقدار بیمار بعدی 0 خواهد شد
            if (FirstPatientID.Value == LastPatientID.Value) LaterPatientID = 0;
            // OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
            // بررسی اینكه بیماری كه می خواهد حذف شود ، آخرین بیمار ثبت شده باشد.
            // در این صورت بیمار بعدی كه انتخاب می شود بیمار یكی مانده به آخر خواهد بود
            else if (PatID == LastPatientID.Value) LaterPatientID = GetPrevOrNextPatID(PatID, false);
            // OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
            // بررسی اینكه بیماری كه می خواهد حذف شود ، آخرین بیمار ثبت شده نباشد.
            // در این صورت بیمار بعدی كه انتخاب می شود بیمار بعدی نسبت به بیمار جاری خواهد بود
            else LaterPatientID = GetPrevOrNextPatID(PatID, true);
            // OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
            // اگر كد بعدی تهی باشد به معنی خطاست ، بنابر این بیمار جاری نیز حذف نخواهد شد
            if (LaterPatientID == null) return null;
            // حذف بیمار از بانك اطلاعات
            try { Manager.DBML.SP_DeleteList(PatID); }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "حذف بیمار انتخاب شده از بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Negar", "Db Layer - Patients", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error); return null;
            }
            #endregion
            return LaterPatientID;
        }
        #endregion

        #endregion

    }
}