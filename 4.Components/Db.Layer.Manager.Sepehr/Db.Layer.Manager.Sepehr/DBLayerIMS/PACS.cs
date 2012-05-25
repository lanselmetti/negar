#region using
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Negar;
using Negar.DBLayerPMS.DataLayer;
using Sepehr.DBLayerIMS.DataLayer;
#endregion

namespace Sepehr.DBLayerIMS
{
    /// <summary>
    /// كلاس مدیریت اطلاعات پكس
    /// </summary>
    public static class PACS
    {

        #region Fields
        private static List<Modality> _Modalities;
        private static List<Study> _Studies;
        private static List<ServiceModality> _ServiceModalities;
        private static List<ServiceStudy> _ServiceStudies;

        #region PACSDbLayer _DBML
        /// <summary>
        /// شی ء مدیریت اتصال به بانك اطلاعات
        /// </summary>
        private static PACSDbLayer _DBML;
        #endregion

        #endregion

        #region Properties

        #region List<Modality> Modalities
        /// <summary>
        /// لیست ستون های پویا برنامه های نوبت دهی ثبت شده در سیستم
        /// </summary>
        public static List<Modality> Modalities
        {
            get
            {
                if (_Modalities == null)
                    try
                    {
                        Table<Modality> TempSchAddinColumnsList = Manager.DBML.Modalities;
                        Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, TempSchAddinColumnsList);
                        _Modalities = TempSchAddinColumnsList.OrderBy(Data => Data.Name).ToList();
                    }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage = "خواندن لیست لیست مودالیتی ها از بانك ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Sepehr", "DBLayer - PACS",
                            Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                        return null;
                    }
                    #endregion
                return _Modalities;
            }
            set { _Modalities = value; }
        }
        #endregion

        #region List<ServiceModality> ServiceModalities
        public static List<ServiceModality> ServiceModalities
        {
            get
            {
                if (_ServiceModalities == null)
                    try { _ServiceModalities = Manager.DBML.ServiceModalities.ToList(); }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage =
                            "خواندن لیست سرویس های تحت پوشش مودالیتی ها ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Sepehr", "DBLayer - PACS",
                            Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                        return null;
                    }
                    #endregion
                return _ServiceModalities;
            }
            set { _ServiceModalities = value; }
        }
        #endregion

        #region List<Study> Studies
        public static List<Study> Studies
        {
            get
            {
                if (_Studies == null)
                    try
                    {
                        Table<Study> TempData = Manager.DBML.Studies;
                        Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, TempData);
                        _Studies = TempData.ToList();
                    }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage = "خواندن لیست Study ها ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Sepehr", "DBLayer - PACS",
                            Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error); return null;
                    }
                    #endregion
                return _Studies;
            }
            set { _Studies = value; }
        }
        #endregion

        #region List<ServiceStudy> ServiceStudies
        public static List<ServiceStudy> ServiceStudies
        {
            get
            {
                if (_ServiceStudies == null)
                    try
                    {
                        Table<ServiceStudy> TempData = Manager.DBML.ServiceStudies;
                        Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, TempData);
                        _ServiceStudies = TempData.ToList();
                    }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage = "خواندن لیست ارتباط ارگان ها و خدمات از بانك ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Sepehr", "DBLayer - PACS",
                            Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                        return null;
                    }
                    #endregion
                return _ServiceStudies;
            }
            set { _ServiceStudies = value; }
        }
        #endregion

        #region PACSDbLayer DBML
        /// <summary>
        /// شیء مدیریت اتصال به بانك اطلاعات
        /// </summary>
        public static PACSDbLayer DBML
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

        #region Boolean RegisterRefDataInPACS(Int32 ServiceIX, List<Int16> TheModalities)
        /// <summary>
        /// تابعی برای ثبت اطلاعات بیمار در پكس
        /// </summary>
        public static Boolean RegisterRefDataInPACS(Int32 RefServiceID, List<Int16> TheModalities)
        {
            Boolean ReturnValue = true;
            try
            {
                PATIENTWL newItem = new PATIENTWL();
                RefService serviceData = Manager.DBML.RefServices.
                    Where(Data => Data.ID == RefServiceID).First();
                RefList RefData = serviceData.RefList;
                PatList PatData = Negar.DBLayerPMS.Patients.GetPatFullDataByPatListID(RefData.PatientIX);
                newItem.PATIENTWL_KEY = PatData.ID;
                newItem.TRIGGER_DTTM = "20111201224520";
                newItem.REPLICA_DTTM = "20111201224520";
                newItem.PATIENT_ID = PatData.PatientID;
                newItem.PATIENT_NAME = PatData.FirstName + " " + PatData.LastName;
                newItem.ENGLISH_NAME = PatData.PatDetail.EngFirstName + " " + PatData.PatDetail.EngLastName;
                newItem.PATIENT_BIRTH_DTTM = "20111201224520";
                newItem.PATIENT_SEX = "M";
                DBML.PATIENTWLs.InsertOnSubmit(newItem);
                if (!Submit())
                {
                    PMBox.Show("امكان ثبت اطلاعات خدمت در بانك واسط پكس وجود ندارد!",
                        "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ReturnValue = false;
                }
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان ثبت اطلاعات خدمت جاری در سیستم پكس وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "PACS", Ex.Message + "\n" + Ex.StackTrace,
                    EventLogEntryType.Error); ReturnValue = false;
            }
            #endregion
            return ReturnValue;
        }
        #endregion

        #region void Initialize()
        /// <summary>
        /// تابعی برای نمونه سازی از شیء اتصال به بانك اطلاعات
        /// </summary>
        private static void Initialize()
        {
            DBML = new PACSDbLayer(CSManager.GetConnectionString("PACS"));
            DBML.CommandTimeout = 0;
        }
        #endregion

        #region Boolean Submit()
        /// <summary>
        /// تابعی برای اعمال تغییرات انجام شده در لایه داده
        /// </summary>
        private static Boolean Submit()
        {
            DBML.CommandTimeout = 0;
            try { DBML.SubmitChanges(ConflictMode.ContinueOnConflict); }
            #region Catch
            catch (Exception Ex)
            {
                LogManager.SaveLogEntry("Sepehr", "PACS DbLayer Manager", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion
            return true;
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
        }
        #endregion

        #endregion

    }
}