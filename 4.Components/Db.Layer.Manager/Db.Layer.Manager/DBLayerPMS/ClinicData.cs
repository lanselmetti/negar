#region using
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Negar.DBLayerPMS.DataLayer;
#endregion

namespace Negar.DBLayerPMS
{
    /// <summary>
    /// كلاس مدیریت اطلاعات سیستم های پزشكی
    /// </summary>
    public static class ClinicData
    {

        #region Fields
        private static List<SP_SelectRefPhysiciansSpecsResult> _RefPhysicianSpecsList;
        private static List<Insurance> _InsNameList;
        #endregion

        #region Properties

        #region List<SP_SelectRefPhysiciansSpecsResult> RefPhysicianSpecsList
        /// <summary>
        /// لیست تخصص های پزشكان درخواست كننده در سیستم
        /// </summary>
        /// <remarks>
        /// بدون اعمال فعال بودن یا نبودن آنها.
        /// این خصوصیت ، كاربران مدیریت با كلید 1 و 2 را نیز نمایش می دهد
        /// </remarks>
        public static List<SP_SelectRefPhysiciansSpecsResult> RefPhysicianSpecsList
        {
            get
            {
                if (_RefPhysicianSpecsList == null)
                    try { _RefPhysicianSpecsList = Manager.DBML.SP_SelectRefPhysiciansSpecs().ToList(); }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage = "خواندن لیست تخصصهای پزشكان درخواست كننده ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Negar", "DB Layer - Clinic Data",
                            Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                        return null;
                    }
                    #endregion
                return _RefPhysicianSpecsList;
            }
            set { _RefPhysicianSpecsList = value; }
        }
        #endregion

        #region List<Insurance> InsNameList
        /// <summary>
        /// لیست نام بیمه های ثبت شده در تمام زیر سیستم ها
        /// </summary>
        public static List<Insurance> InsNameList
        {
            get
            {
                if (_InsNameList == null)
                    try
                    {
                        Table<Insurance> TempData = Manager.DBML.Insurances;
                        Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, TempData);
                        _InsNameList = TempData.ToList();
                    }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage = "خواندن لیست نام بیمه ها ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Negar", "DB Layer - Clinic Data",
                            Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                        return null;
                    }
                    #endregion
                return _InsNameList;
            }
            set { _InsNameList = value; }
        }
        #endregion

        #endregion

        #region Methods

        #region RefPhysician GetRefPhysBaseDataByID(Int16 PhysID)
        /// <summary>
        /// تابعی برای خواندن اطلاعات كامل پزشكان ارجاع دهنده بیمار با كلید پزشك
        /// </summary>
        /// <param name="PhysID">كلید پزشك</param>
        /// <returns>شیء اطلاعات پزشك</returns>
        public static RefPhysician GetRefPhysBaseDataByID(Int16 PhysID)
        {
            try
            {
                RefPhysician TempData = Manager.DBML.RefPhysicians.Where(Data => Data.ID == PhysID).First();
                Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, TempData);
                return TempData;
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان خواندن اطلاعات پزشك مراجعه وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Negar", "DB Layer - ClinicData",
                    Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error); return null;
            }
            #endregion
        }
        #endregion

        #region List<PhysicianFullData> GetRefPhysFullDataByID(Int16 PhysID, Boolean ShouldAddEmptyRow)
        /// <summary>
        /// تابعی برای خواندن اطلاعات كامل پزشكان ارجاع دهنده بیمار با كلید پزشك
        /// </summary>
        /// <param name="PhysID">كلید پزشك</param>
        /// <param name="ShouldAddEmptyRow">تعیین لفزودن ردیف انتخاب نشده به لیست نتیجه</param>
        /// <returns>شیء اطلاعات پزشك</returns>
        public static List<PhysicianFullData> GetRefPhysFullDataByID(Int16 PhysID, Boolean ShouldAddEmptyRow)
        {
            try
            {
                RefPhysician TempData = Manager.DBML.RefPhysicians.Where(Data => Data.ID == PhysID).First();
                Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, TempData);
                List<PhysicianFullData> ReturnValue = new List<PhysicianFullData>();
                if (ShouldAddEmptyRow)
                {
                    PhysicianFullData EmptyRow = new PhysicianFullData();
                    EmptyRow.FullTitle = "(پزشك مراجعه انتخاب نشده)";
                    ReturnValue.Add(EmptyRow);
                }
                ReturnValue.Add(new PhysicianFullData(TempData, true));
                return ReturnValue;
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان خواندن اطلاعات پزشك مراجعه وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Negar", "DB Layer - ClinicData",
                    Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error); return null;
            }
            #endregion
        }
        #endregion

        #region List<PhysicianFullData> GetRefPhysFullDataByValue(String FirstChar, Boolean IsMedicalID)
        /// <summary>
        /// تابعی برای خواندن اطلاعات كامل پزشكانی كه نظام پزشكی یا نام خانوادگی آنها با یك كاراكتر مشخص شروع می شود
        /// </summary>
        /// <param name="FirstChar">حرف اول نظام پزشكی یا نام خانوادگی</param>
        /// <param name="IsMedicalID">تعیین جستجوی در نظام پزشكی یا نام خانوادگی</param>
        /// <returns>شیء لیست اطلاعات پزشكان</returns>
        public static List<PhysicianFullData> GetRefPhysFullDataByValue(String FirstChar, Boolean IsMedicalID)
        {
            List<PhysicianFullData> ReturnValue;
            try
            {
                if (IsMedicalID)
                {
                    IQueryable<RefPhysician> TempData =
                        Manager.DBML.RefPhysicians.Where(Data => Data.MedicalID.StartsWith(FirstChar))
                        .OrderBy(Data => Data.MedicalID);
                    Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, TempData);
                    ReturnValue = new List<PhysicianFullData>();
                    PhysicianFullData EmptyRow = new PhysicianFullData();
                    EmptyRow.FullTitle = "(پزشك مراجعه انتخاب نشده)";
                    ReturnValue.Add(EmptyRow);
                    foreach (RefPhysician physician in TempData) ReturnValue.Add(new PhysicianFullData(physician, true));
                }
                else
                {
                    IQueryable<RefPhysician> TempData =
                        Manager.DBML.RefPhysicians.Where(Data => Data.LastName.StartsWith(FirstChar))
                        .OrderBy(Data => Data.LastName);
                    Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, TempData);
                    ReturnValue = new List<PhysicianFullData>();
                    PhysicianFullData EmptyRow = new PhysicianFullData();
                    EmptyRow.FullTitle = "(پزشك مراجعه انتخاب نشده)";
                    ReturnValue.Add(EmptyRow);
                    foreach (RefPhysician physician in TempData) ReturnValue.Add(new PhysicianFullData(physician, false));
                }
                return ReturnValue;
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان جستجوی اطلاعات پزشكان وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Negar", "DB Layer - ClinicData",
                    Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error); return null;
            }
            #endregion
        }
        #endregion

        #region void SubmitDbEventLog(Int16 CategoryID, Int16 ApplicationID, Int16 UserID, DateTime Date, String Description)
        /// <summary>
        /// تابعی برای ثبت رخداد در بانك اطلاعاتی
        /// </summary>
        public static void SubmitDbEventLog(Int16 CategoryID, Int16 ApplicationID, Int16 UserID, DateTime Date, String Description)
        {
            try
            {
                DbEvent NewEvent = new DbEvent();
                NewEvent.CategoryIX = CategoryID;
                NewEvent.ApplicationIX = ApplicationID;
                NewEvent.UserIX = UserID;
                NewEvent.Date = Date;
                NewEvent.Description = Description;
                Manager.DBML.DbEvents.InsertOnSubmit(NewEvent);
                Manager.DBML.SubmitChanges();
            }
            #region Catch
            catch (Exception Ex)
            {
                LogManager.SaveLogEntry("Negar", "DB Layer - ClinicData",
                    Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
            }
            #endregion
        }
        #endregion

        #endregion

    }

    #region public class PhysicianFullData
    /// <summary>
    /// كلاسی برای نمایش اطلاعات كامل یك پزشك درخواست كننده
    /// </summary>
    public class PhysicianFullData
    {

        #region Properties
        public Int16? ID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String FirstNameEn { get; set; }
        public String LastNameEn { get; set; }
        public String FullName { get; set; }
        public String FullTitle { get; set; }
        public Boolean IsMale { get; set; }
        public String Gender { get; set; }
        public String MedicalID { get; set; }
        public Int16? SpecID { get; set; }
        public String SpecName { get; set; }
        public String Description { get; set; }
        #endregion

        #region Ctors

        #region PhysicianFullData()
        public PhysicianFullData()
        {
        }
        #endregion

        #region PhysicianFullData(RefPhysician SentPhysician, Boolean IsMedicalID)
        public PhysicianFullData(RefPhysician SentPhysician, Boolean IsMedicalID)
        {
            ID = SentPhysician.ID;
            IsMale = SentPhysician.IsMale;
            if (IsMale) Gender = "مرد";
            else Gender = "زن";
            FirstName = SentPhysician.FirstName;
            LastName = SentPhysician.LastName;
            if (String.IsNullOrEmpty(FirstName.Trim()))
                FullName = LastName;
            else FullName = SentPhysician.FirstName + " " + SentPhysician.LastName;
            MedicalID = SentPhysician.MedicalID;
            if (IsMedicalID)
            {
                if (String.IsNullOrEmpty(FirstName.Trim()))
                    FullTitle = MedicalID + " - " + LastName;
                else FullTitle = MedicalID + " - " + LastName + " - " + FirstName;
            }
            else
            {
                if (String.IsNullOrEmpty(FirstName.Trim()))
                    FullTitle = LastName + " - " + MedicalID;
                else FullTitle = LastName + " - " + FirstName + " - " + MedicalID;
            }
            SpecID = SentPhysician.SpecialtyIX;
            if (SpecID != null) SpecName = ClinicData.RefPhysicianSpecsList.
                Where(Data => Data.ID == SentPhysician.SpecialtyIX.Value).First().Title;
            Description = SentPhysician.Description;
        }
        #endregion

        #endregion

    }
    #endregion

}