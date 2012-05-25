#region using
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Negar;
using Negar.DBLayerPMS.DataLayer;
using Negar.PersianCalendar.Utilities;
using Sepehr.DBLayerIMS.DataLayer;
#endregion

namespace Sepehr.DBLayerIMS
{
    /// <summary>
    /// كلاس مدیریت جستجوی ساده بیماران در فرم اصلی
    /// </summary>
    public static class PatientSearcher
    {

        #region Methods

        #region PatientData GetPatDataByPatListID(Int32 PatListID)
        /// <summary>
        /// تابعی برای خواندن اطلاعات یك بیمار با كلید بیمار
        /// </summary>
        /// <param name="PatListID">كلید بیمار</param>
        /// <returns>اطلاعات بیمار یا تهی برای خطا</returns>
        public static PatientData GetPatDataByPatListID(Int32 PatListID)
        {
            PatList PData = Negar.DBLayerPMS.Patients.GetPatFullDataByPatListID(PatListID);
            if (PData == null) return null;
            PatientData ReturnValue = GeneratePatSearchResult(PData, 1);
            if (ReturnValue == null) return null;
            return ReturnValue;
        }
        #endregion

        #region PatientData GetPatDataByPatID(String PatID)
        /// <summary>
        /// تابعی برای خواندن اطلاعات یك بیمار با شماره رشته ای بیمار
        /// </summary>
        /// <param name="PatID">شماره بیمار</param>
        /// <returns>اطلاعات بیمار یا تهی برای خطا</returns>
        public static PatientData GetPatDataByPatID(String PatID)
        {
            Int32? TempPatListID = Negar.DBLayerPMS.Patients.GetPatListIDByPatientID(PatID);
            if (TempPatListID == null) return null;
            return GetPatDataByPatListID(TempPatListID.Value);
        }
        #endregion

        #region List<PatientData> GetSamePatDataByPatID(String PatID)
        /// <summary>
        /// تابعی برای خواندن اطلاعات بیماران دارای كد با شماره رشته ای بیمار
        /// </summary>
        /// <param name="PatID">شماره بیمار</param>
        /// <returns>اطلاعات بیمار یا تهی برای خطا</returns>
        public static List<PatientData> GetSamePatDataByPatID(String PatID)
        {
            IQueryable<PatList> PatientSearch = Negar.DBLayerPMS.Manager.DBML.PatLists.
                Where(Data => Data.PatientID.StartsWith(PatID.Trim().Normalize()));
            try { Negar.DBLayerPMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, PatientSearch); }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان جستجو  اطلاعات بیماران از بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Main Project", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error); return null;
            }
            #endregion
            List<PatList> Result = PatientSearch.ToList();
            if (Result.Count == 0) return new List<PatientData>();
            List<PatientData> ReturnValue = new List<PatientData>();
            Int32 RowIndex = 1;
            foreach (PatList PData in Result)
            {
                PatientData ResultData = GeneratePatSearchResult(PData, RowIndex);
                if (ResultData == null) return null;
                ReturnValue.Add(ResultData);
                RowIndex++;
            }
            return ReturnValue;
        }
        #endregion

        #region List<PatientData> GetPatDataListSimpleFilter(String FirstName, String LastName, Int32? Age)
        /// <summary>
        /// تابعی برای خواندن اطلاعات یك بیمار با شماره رشته ای بیمار
        /// </summary>
        /// <returns>اطلاعات بیمار یا تهی برای خطا</returns>
        public static List<PatientData> GetPatDataListSimpleFilter(String FirstName, String LastName, Int32? Age)
        {
            IQueryable<PatList> PatientSearch = Negar.DBLayerPMS.Manager.DBML.PatLists.
                Where(Data => Data.LastName.StartsWith(LastName.Trim().Normalize()));
            if (!String.IsNullOrEmpty(FirstName.Trim()))
                PatientSearch = PatientSearch.Where(Data => Data.FirstName.StartsWith(FirstName.Trim().Normalize()));
            if (Age != null)
                PatientSearch = PatientSearch.Where(Data => DateTime.Now.Year - Data.BirthDate.Value.Year == Age.Value);
            try { Negar.DBLayerPMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, PatientSearch); }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان جستجو  اطلاعات بیماران از بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Main Project", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error); return null;
            }
            #endregion
            List<PatList> Result = PatientSearch.ToList();
            if (Result.Count == 0) return new List<PatientData>();
            List<PatientData> ReturnValue = new List<PatientData>();
            Int32 RowIndex = 1;
            foreach (PatList PData in Result)
            {
                PatientData ResultData = GeneratePatSearchResult(PData, RowIndex);
                if (ResultData == null) return null;
                ReturnValue.Add(ResultData);
                RowIndex++;
            }
            return ReturnValue;
        }
        #endregion

        #region List<PatientData> GetPatDataListByPatListIDList(List<Int32> PIDList)
        /// <summary>
        /// تابعی برای خواندن اطلاعات لیستی از بیماران با لیستی از كلید های بیماران
        /// </summary>
        /// <returns>اطلاعات بیمار یا تهی برای خطا</returns>
        public static List<PatientData> GetPatDataListByPatListIDList(List<Int32> PIDList)
        {
            List<PatientData> ReturnValue = new List<PatientData>();
            Int32 RowIndex = 1;
            foreach (Int32 PID in PIDList)
            {
                PatientData ResultData = GetPatDataByPatListID(PID);
                if (ResultData == null) return null;
                ResultData.RowID = RowIndex;
                ReturnValue.Add(ResultData);
                RowIndex++;
            }
            return ReturnValue;
        }
        #endregion

        #region PatientData GeneratePatSearchResult(PatList PData, Int32 RowIndex)
        /// <summary>
        /// تابعی برای تولید كلاس مناسب برای نمایش نتیجه جستجوی ساده بیماران
        /// </summary>
        /// <param name="PData">اطلاعات بیمار بر اساس اطلاعات بانك</param>
        /// <param name="RowIndex">شماره ردیف مناسب برای ثبت</param>
        /// <returns>اطلاعات نتیجه جستجو یا تهی برای خطا</returns>
        private static PatientData GeneratePatSearchResult(PatList PData, Int32 RowIndex)
        {
            PatientData CurrentPatData = new PatientData();
            CurrentPatData.RowID = RowIndex;
            CurrentPatData.PatientListID = PData.ID;
            CurrentPatData.PatientID = PData.PatientID;
            String FullName = PData.LastName;
            if (!String.IsNullOrEmpty(PData.FirstName.Trim())) FullName = PData.FirstName + " " + FullName;
            CurrentPatData.PatientFullName = FullName;
            if (PData.IsMale != null)
            {
                if (PData.IsMale.Value) CurrentPatData.PatientGender = "مرد";
                else CurrentPatData.PatientGender = "زن";
            }
            if (PData.BirthDate != null) CurrentPatData.PatientAge = DateTime.Now.Year - PData.BirthDate.Value.Year;
            Int32? RefCount = Referrals.GetPatRefCountByPatID(PData.ID);
            if (RefCount == null) CurrentPatData.RefCount = -1;
            else CurrentPatData.RefCount = RefCount.Value;
            if (CurrentPatData.RefCount > 0)
            {
                Int32? LastRefID = Referrals.GetPatFirstOrLastRefID(PData.ID, true);
                if (LastRefID == null) return null;
                RefList RefData = Referrals.GetRefDataByID(LastRefID.Value);
                if (RefData == null) return null;
                CurrentPatData.LastRefPDateTime = GetShortPersianDate(RefData.RegisterDate);
            }
            return CurrentPatData;
        }
        #endregion

        #region List<PatientRefData> GetPatRefListDataByPatID(Int32 PatID)
        /// <summary>
        /// تابعی برای خواندن اطلاعات مراجعات بیمار با كد بیمار
        /// </summary>
        /// <param name="PatListID">شماره بیمار</param>
        /// <returns>اطلاعات مراجعات بیمار یا تهی برای خطا</returns>
        public static List<PatientRefData> GetPatRefListDataByPatID(Int32 PatListID)
        {
            List<Int32> RefListSearch = Referrals.GetPatRefIDListByPatID(PatListID);
            if (RefListSearch.Count == 0) return new List<PatientRefData>();
            List<PatientRefData> ReturnValue = new List<PatientRefData>();
            Int32 RowIndex = 1;
            foreach (Int32 RefID in RefListSearch)
            {
                RefList RefData = Referrals.GetRefDataByID(RefID);
                if (RefData == null) return null;
                PatientRefData ResultData = GeneratePatRefSearchResult(RefData, RowIndex);
                if (ResultData == null) return null;
                ReturnValue.Add(ResultData);
                RowIndex++;
            }
            return ReturnValue;
        }
        #endregion

        #region PatientRefData GeneratePatRefSearchResult(RefList RefData, Int32 RowIndex)
        /// <summary>
        /// تابعی برای تولید كلاس مناسب برای نمایش نتیجه جستجوی ساده مراجعات
        /// </summary>
        /// <param name="RefData">اطلاعات مراجعه بر اساس اطلاعات بانك</param>
        /// <param name="RowIndex">شماره ردیف مناسب برای ثبت</param>
        /// <returns>اطلاعات نتیجه جستجو یا تهی برای خطا</returns>
        private static PatientRefData GeneratePatRefSearchResult(RefList RefData, Int32 RowIndex)
        {
            PatientRefData CurrentRefData = new PatientRefData();
            CurrentRefData.RowID = RowIndex;
            #region Set Period
            List<RefService> RefServList = Manager.DBML.RefServices.Where(Data => Data.ReferralIX == RefData.ID).ToList();
            Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, RefServList);
            if (RefServList.Count == 0 || RefServList[0].ServicesList.CategoryIX == null)
                CurrentRefData.Period = 0;
            else
            {
                String TodayDate = RefData.RegisterDate.Year + "/" + RefData.RegisterDate.Month + "/" + RefData.RegisterDate.Day + " ";
                String RefServQtyCommand = "SELECT ROW_NUMBER() OVER (ORDER BY [RefList].[RegisterDate]) AS [RANK] , " +
                    "[RefList].[ID] AS [RefID] FROM [ImagingSystem].[Referrals].[List] AS [RefList] " +
                    "WHERE [RefList].[RegisterDate] > '" + TodayDate + "00:00:00" + "' " +
                    "AND [RefList].[RegisterDate] < '" + TodayDate + "23:59:59" + "' " +
                    "AND (SELECT COUNT(*) FROM [ImagingSystem].[Referrals].[RefServices] AS [RefServ] " +
                    "INNER JOIN [ImagingSystem].[Services].[List] AS [ServList] " +
                    "ON [RefServ].[ServiceIX] = [ServList].[ID] " +
                    "WHERE [RefServ].[ReferralIX] = [RefList].[ID] AND " +
                    "[ServList].[CategoryIX] = " + RefServList[0].ServicesList.CategoryIX.Value + ") > 0 " +
                    "ORDER BY [RefList].[RegisterDate] ASC;";
                DataTable Result = Manager.ExecuteQuery(RefServQtyCommand, 5);
                if (Result == null || Result.Rows.Count == 0 || Result.Rows[0][0] == null || Result.Rows[0][0] == DBNull.Value)
                    CurrentRefData.Period = -1;
                else
                {
                    DataRow[] Data = Result.Select("RefID = " + RefData.ID);
                    if (Data == null || Data.Length == 0) CurrentRefData.Period = -1;
                    else CurrentRefData.Period = Convert.ToInt32(Data[0][0]);
                }
            }
            #endregion
            CurrentRefData.RefID = RefData.ID;
            CurrentRefData.RefDate = GetShortPersianDate(RefData.RegisterDate);
            String Ins1Name = "(بدون بیمه اصلی)";
            if (RefData.Ins1IX != null) Ins1Name = Negar.DBLayerPMS.ClinicData.InsNameList.
                Where(Data => Data.ID == RefData.Ins1IX.Value).First().Name;
            CurrentRefData.Ins1Name = Ins1Name;
            String Ins2Name = "(بدون بیمه تكمیلی)";
            if (RefData.Ins2IX != null) Ins2Name = Negar.DBLayerPMS.ClinicData.InsNameList.
                Where(Data => Data.ID == RefData.Ins2IX.Value).First().Name;
            CurrentRefData.Ins2Name = Ins2Name;
            try
            {
                String FirstServiceCategory;
                List<RefService> RefServiceList = Manager.DBML.RefServices.
                    Where(Data => Data.ReferralIX == RefData.ID).OrderBy(Data => Data.ID).ToList();
                Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, RefServiceList);
                if (RefServiceList.Count == 0) FirstServiceCategory = "(فاقد خدمت)";
                else if (RefServiceList.First().ServicesList.CategoryIX == null)
                {
                    FirstServiceCategory = "(فاقد طبقه بندی)";
                }
                else FirstServiceCategory = RefServiceList.First().ServicesList.ServicesCategories.Name;
                CurrentRefData.FirstServiceCategory = FirstServiceCategory;

                #region Ins1 AND Ins2
                // محاسبه قیمت های بیمه
                Int32 Ins1PriceTotal = 0;
                Int32 Ins1PartTotal = 0;
                Int32 Ins2PriceTotal = 0;
                Int32 Ins2PartTotal = 0;
                foreach (RefService service in RefServiceList)
                    if (service.IsActive)
                    {
                        if (service.IsIns1Cover != null && service.IsIns1Cover.Value)
                        {
                            if (service.Ins1Price != null) Ins1PriceTotal
                                += (service.Ins1Price.Value * service.Quantity);
                            if (service.Ins1PartPrice != null) Ins1PartTotal
                                += (service.Ins1PartPrice.Value * service.Quantity);
                        }
                        if (service.IsIns2Cover != null && service.IsIns2Cover.Value)
                        {
                            if (service.Ins2Price != null) Ins2PriceTotal
                                += (service.Ins2Price.Value * service.Quantity);
                            if (service.Ins2PartPrice != null) Ins2PartTotal
                                += (service.Ins2PartPrice.Value * service.Quantity);
                        }
                    }
                CurrentRefData.Ins1PriceTotal = Ins1PriceTotal;
                CurrentRefData.Ins1PartTotal = Ins1PartTotal;
                CurrentRefData.Ins1PatientPart = Ins1PriceTotal - Ins1PartTotal;
                CurrentRefData.Ins2PriceTotal = Ins2PriceTotal;
                CurrentRefData.Ins2PartTotal = Ins2PartTotal;

                #endregion
            }
            #region Catch
            catch (Exception Ex)
            {
                LogManager.SaveLogEntry("Sepehr", "DB Layer - PatientSearcher", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error);
            }
            #endregion
            Int32? DocCount = Document.GetRefDocCountByRefID(RefData.ID);
            if (DocCount == null) CurrentRefData.DocCount = -1;
            else CurrentRefData.DocCount = DocCount.Value;
            if (CurrentRefData.DocCount > 0)
            {
                Int32? LastDocID = Document.GetRefLastDocIDByRefID(RefData.ID);
                if (LastDocID == null) return CurrentRefData;
                try
                {
                    DateTime DocData = Manager.DBML.RefDocuments.Where(Data => Data.ID == LastDocID.Value).
                        Select(Data => Data.Date).First();
                    CurrentRefData.LastDocDate = GetShortPersianDate(DocData);
                }
                #region Catch
                catch (Exception Ex)
                {
                    LogManager.SaveLogEntry("Sepehr", "DB Layer - PatientSearcher", Ex.Message + "\n" +
                        Ex.StackTrace, EventLogEntryType.Error);
                }
                #endregion
            }

            

            return CurrentRefData;
        }
        #endregion

        #region String GetLongPersianDate(DateTime SentDate)
        /// <summary>
        /// تابعی برای تبدیل تاریخ میلادی به متن فارسی
        /// </summary>
        /// <param name="SentDate">تاریخ میلادی</param>
        /// <returns>تاریخ شمسی</returns>
        private static String GetLongPersianDate(DateTime SentDate)
        {
            PersianDate PDate = SentDate.ToPersianDate();
            return PDate.ToWritten() + " - " + PDate.Hour + ":" + PDate.Minute + ":" + PDate.Second;
        }
        #endregion

        #region String GetShortPersianDate(DateTime SentDate)
        /// <summary>
        /// تابعی برای تبدیل تاریخ میلادی به متن فارسی
        /// </summary>
        /// <param name="SentDate">تاریخ میلادی</param>
        /// <returns>تاریخ شمسی</returns>
        private static String GetShortPersianDate(DateTime SentDate)
        {
            PersianDate PDate = SentDate.ToPersianDate();
            return PDate.Year + "/" + PDate.Month + "/" + PDate.Day +
                " - " + PDate.Hour + ":" + PDate.Minute + ":" + PDate.Second;
        }
        #endregion

        #endregion

        #region internal class PatientData
        /// <summary>
        /// كلاس مدیریت اطلاعات جستجوی بیماران
        /// </summary>
        public class PatientData
        {
            public Int32 RowID { get; set; }
            public Int32 PatientListID { get; set; }
            public String PatientID { get; set; }
            public String PatientFullName { get; set; }
            public String PatientGender { get; set; }
            public Int32? PatientAge { get; set; }
            public Int32 RefCount { get; set; }
            public String LastRefPDateTime { get; set; }
        }
        #endregion

        #region internal class PatientRefData
        /// <summary>
        /// كلاس مدیریت اطلاعات جستجوی مراجعات بیماران
        /// </summary>
        public class PatientRefData
        {
            public Int32 RowID { get; set; }
            public Int32 Period { get; set; }
            public Int32 RefID { get; set; }
            public String RefDate { get; set; }
            public String Ins1Name { get; set; }
            public String Ins2Name { get; set; }
            public String FirstServiceCategory { get; set; }
            public Int32 DocCount { get; set; }
            public String LastDocDate { get; set; }
            public Int32 Ins1PriceTotal { get; set; }
            public Int32 Ins1PartTotal { get; set; }
            public Int32 Ins1PatientPart { get; set; }
            public Int32 Ins2PriceTotal { get; set; }
            public Int32 Ins2PartTotal { get; set; }
        }
        #endregion

    }
}