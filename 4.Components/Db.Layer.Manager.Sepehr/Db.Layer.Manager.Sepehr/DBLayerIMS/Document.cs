#region using
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Negar;
using Negar.PersianCalendar.Utilities;
using Sepehr.DBLayerIMS.DataLayer;
#endregion

namespace Sepehr.DBLayerIMS
{
    /// <summary>
    /// كلاس مدیریت اطلاعات مدارك تصویربرداری
    /// </summary>
    public static class Document
    {

        #region Fields
        private static List<SP_SelectTemplatesResult> _DocTemplatesList;
        private static Dictionary<Int16, Binary> _DocTemplatesFullList;
        private static List<SP_SelectTypeResult> _DocTypesList;
        private static List<DocText> _DocTextsList;
        #endregion

        #region Properties

        #region List<SP_SelectTemplatesResult> DocTemplatesList
        /// <summary>
        /// لیست قالب های مدرك تعریف شده برای سیستم تصویربرداری در سیستم
        /// </summary>
        public static List<SP_SelectTemplatesResult> DocTemplatesList
        {
            get
            {
                if (_DocTemplatesList == null)
                    try { _DocTemplatesList = Manager.DBML.SP_SelectTemplates().ToList(); }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage = "خواندن لیست قالب های مدرك تعریف شده ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Sepehr", "DBLayer - Document",
                            Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                        return null;
                    }
                    #endregion
                return _DocTemplatesList;
            }
            set
            {
                _DocTemplatesList = new List<SP_SelectTemplatesResult>();
                _DocTemplatesList = value;
            }
        }
        #endregion

        #region List<DocText> DocTextsList
        /// <summary>
        /// لیست متن های مدرك تعریف شده برای سیستم تصویربرداری در سیستم
        /// </summary>
        public static List<DocText> DocTextsList
        {
            get
            {
                if (_DocTextsList == null)
                    try
                    {
                        Table<DocText> TempData = Manager.DBML.DocTexts;
                        Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, TempData);
                        _DocTextsList = TempData.ToList();
                    }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage = "خواندن لیست متن های مدرك تعریف شده ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Sepehr", "DBLayer - Document",
                            Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                        return null;
                    }
                    #endregion
                return _DocTextsList;
            }
            set
            {
                _DocTextsList = new List<DocText>();
                _DocTextsList = value;
            }
        }
        #endregion

        #region List<SP_SelectTypeResult> DocTypesList
        /// <summary>
        /// لیست نوع مدرك تعریف شده برای سیستم تصویربرداری در سیستم
        /// </summary>
        public static List<SP_SelectTypeResult> DocTypesList
        {
            get
            {
                if (_DocTypesList == null)
                    try { _DocTypesList = Manager.DBML.SP_SelectType().ToList(); }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage = "خواندن لیست نوع مدرك تعریف شده ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Sepehr", "DBLayer - Document",
                            Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                        return null;
                    }
                    #endregion
                return _DocTypesList;
            }
            set
            {
                _DocTypesList = new List<SP_SelectTypeResult>();
                _DocTypesList = value;
            }
        }
        #endregion

        #endregion

        #region Methods

        #region Int32? GetPatDocCountByPatID(Int32 PatID)
        /// <summary>
        /// تابعی برای خواندن تعداد مدارك ثبت شده برای یك بیمار ، بر اساس كلید بیمار
        /// </summary>
        /// <returns>تعداد مدارك بیمار یا تهی برای وقوع خطا</returns>
        public static Int32? GetPatDocCountByPatID(Int32 PatID)
        {
            Int32 ReturnValue = 0;
            try
            {
                IQueryable<Int32> RefList = Manager.DBML.RefLists.Where(Data => Data.PatientIX == PatID).Select(Data => Data.ID);
                foreach (Int32 RefID in RefList)
                    ReturnValue += Manager.DBML.RefDocuments.Where(Data => Data.RefIX == RefID).Count();
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان خواندن تعداد مدارك مراجعه تصویربرداری بیمار از بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "DB Layer - Document", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error); return null;
            }
            #endregion
            return ReturnValue;
        }
        #endregion

        #region Int32? GetRefDocCountByRefID(Int32 RefID)
        /// <summary>
        /// تابعی برای خواندن تعداد مدارك ثبت شده برای یك مراجعه ، بر اساس كلید مراجعه
        /// </summary>
        /// <returns>تعداد مدارك مراجعه یا تهی برای وقوع خطا</returns>
        public static Int32? GetRefDocCountByRefID(Int32 RefID)
        {
            Int32 ReturnValue;
            try
            {
                ReturnValue = Manager.DBML.RefDocuments.Where(Data => Data.RefIX == RefID).Count();
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان خواندن تعداد مدارك مراجعه تصویربرداری بیمار از بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "DB Layer - Document", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error); return null;
            }
            #endregion
            return ReturnValue;
        }
        #endregion

        #region List<RefDocData> GetRefDocsByRefID(Int32 RefID)
        /// <summary>
        /// روالی برای خواندن مدرك یك مراجعه
        /// </summary>
        /// <param name="RefID">كلید مراجعه</param>
        /// <returns>اطلاعات مدارك مراجعه یا تهی برای خطا</returns>
        public static List<RefDocData> GetRefDocsByRefID(Int32 RefID)
        {
            List<Int32> DocList = GetRefDocIDListByRefID(RefID);
            if (DocList == null) return null;
            List<RefDocData> ReturnValue = new List<RefDocData>();
            foreach (Int32 DocID in DocList)
            {
                RefDocData DocData = new RefDocData(DocID);
                if (DocData.ID == 0) return null;
                ReturnValue.Add(DocData);
            }
            return ReturnValue;
        }
        #endregion

        #region List<Int32> GetRefDocIDListByRefID(Int32 RefID)
        /// <summary>
        /// تابعی برای خواندن لیست كلید های مدارك مراجعه تصویربرداری بیمار ، بر اساس كلید مراجعه
        /// </summary>
        /// <returns>لیست كلیدهای مدارك مراجعه بیمار یا تهی برای وقوع خطا</returns>
        public static List<Int32> GetRefDocIDListByRefID(Int32 RefID)
        {
            List<Int32> ReturnValue;
            try
            {
                ReturnValue = Manager.DBML.RefDocuments.Where(Data => Data.RefIX == RefID)
                  .OrderBy(Data => Data.Date).Select(Data => Data.ID).ToList();
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان خواندن لیست كلید های مدارك مراجعه تصویربرداری بیمار از بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "DB Layer - Document", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error); return null;
            }
            #endregion
            return ReturnValue;
        }
        #endregion

        #region Int32? GetRefLastDocIDByRefID(Int32 RefID)
        /// <summary>
        /// تابعی برای خواندن كلید آخرین مدرك مراجعه تصویربرداری بیمار ، بر اساس كلید مراجعه
        /// </summary>
        /// <returns>لیست كلید مدرك مراجعه بیمار یا تهی برای وقوع خطا</returns>
        public static Int32? GetRefLastDocIDByRefID(Int32 RefID)
        {
            Int32? ReturnValue;
            try
            {
                IQueryable<Int32> Result = Manager.DBML.RefDocuments.Where(Data => Data.RefIX == RefID)
                  .OrderByDescending(Data => Data.Date).Take(1).Select(Data => Data.ID);
                if (Result.Count() == 0) ReturnValue = 0;
                else ReturnValue = Result.First();
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان خواندن آخرین مدرك مراجعه تصویربرداری بیمار از بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "DB Layer - Document", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error); return null;
            }
            #endregion
            return ReturnValue;
        }
        #endregion

        #region DateTime? GetRefDocDateByDocID(Int32 DocID)
        /// <summary>
        /// تابعی برای خواندن تاریخ مدرك مراجعه تصویربرداری ، بر اساس كلید مدرك
        /// </summary>
        /// <returns>لیست كلید مدرك مراجعه بیمار یا تهی برای وقوع خطا</returns>
        public static DateTime? GetRefDocDateByDocID(Int32 DocID)
        {
            DateTime? ReturnValue;
            try
            {
                ReturnValue = Manager.DBML.RefDocuments.Where(Data => Data.ID == DocID)
                  .OrderByDescending(Data => Data.Date).Take(1).Select(Data => Data.Date).First();
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان خواندن تاریخ مدرك مراجعه تصویربرداری انتخاب شده از بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "DB Layer - Referrals", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error); return null;
            }
            #endregion
            return ReturnValue;
        }
        #endregion

        #region Binary GetDocTemplateBinaryData(Int16 DocTemplateID)
        /// <summary>
        /// روالی برای خواندن اطلاعات باینری یك قالب مدرك و نگاه داری آن در حافظه موقت
        /// </summary>
        /// <param name="DocTemplateID">كلید قالب</param>
        /// <returns>اطلاعات باینری قالب مدرك یا تهی برای خطا</returns>
        public static Binary GetDocTemplateBinaryData(Int16 DocTemplateID)
        {
            if (_DocTemplatesFullList == null) _DocTemplatesFullList = new Dictionary<Int16, Binary>();
            if (_DocTemplatesFullList.ContainsKey(DocTemplateID)) return _DocTemplatesFullList[DocTemplateID];
            try
            {
                IQueryable<DocTemplate> TempData = Manager.DBML.DocTemplates.Where(Data => Data.ID == DocTemplateID);
                Manager.DBML.Refresh(RefreshMode.KeepChanges, TempData);
                DocTemplate DocData = TempData.First();
                _DocTemplatesFullList.Add(DocTemplateID, DocData.TemplateData);
                return DocData.TemplateData;
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "خواندن قالب مدرك مورد نظر ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "DBLayer - Document",
                    Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return null;
            }
            #endregion
        }
        #endregion

        #region void ClearCatchedDocTemplates()
        /// <summary>
        /// روالی برای تخلیه كردن اطلاعات قالب های مدرك نگاه داشته شده در حافظه موقت
        /// </summary>
        public static void ClearCatchedDocTemplates()
        {
            _DocTemplatesFullList = null;
        }
        #endregion

        #region Binary GetRefDocBinaryByDocID(Int32 DocID)
        /// <summary>
        /// تابعی برای خواندن فایل باینری یك مدرك ، بر اساس كلید مدرك
        /// </summary>
        /// <returns>فایل باینری مدرك مراجعه بیمار یا تهی برای وقوع خطا</returns>
        public static Binary GetRefDocBinaryByDocID(Int32 DocID)
        {
            Byte[] returnValue;
            try
            {
                DataTable tempDataSet = Manager.
                    ExecuteQuery("EXEC [ImagingSystem].[Referrals].[SP_SelectDocBinary] " + DocID, 0);
                if (tempDataSet == null || tempDataSet.Rows[0][0] == DBNull.Value) returnValue = null;
                else returnValue = (Byte[])tempDataSet.Rows[0][0];
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان خواندن فایل باینری مدرك مراجعه انتخاب شده وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "DB Layer - Referrals", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error); return null;
            }
            #endregion

            if (returnValue != null) return new Binary(returnValue);
            return null;
        }
        #endregion

        #region Boolean SetRefDocBinaryByDocID(Int32 DocID , Binary BinaryData)
        /// <summary>
        /// تابعی برای ذخیره فایل باینری یك مدرك ، بر اساس كلید مدرك
        /// </summary>
        /// <returns>صحت ذخیره سازی</returns>
        public static Boolean SetRefDocBinaryByDocID(Int32 DocID, Binary BinaryData)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[1];
                parameter[0] = new SqlParameter("@Binary", SqlDbType.VarBinary);
                parameter[0].Value = BinaryData.ToArray();
                Manager.ExecuteQuery("EXEC [ImagingSystem].[Referrals].[SP_SaveDocBinary] " +
                    DocID + " , @Binary", 0, parameter);
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان خواندن فایل باینری مدرك مراجعه انتخاب شده وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "DB Layer - Referrals", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error); return false;
            }
            #endregion
            return true;
        }
        #endregion

        #endregion

    }

    #region Classes
    /// <summary>
    /// كلاس پایه ای برای اطلاعات مدارك
    /// </summary>
    public class RefDocData
    {
        public Int32 ID { get; set; }
        public Int32 RefIX { get; set; }
        public Boolean IsReport { get; set; }
        public Int16? TypeIX { get; set; }
        public String TypeOf { get; set; }
        public String TitleOf { get; set; }
        public DateTime DateOf { get; set; }
        public String FaDateOf { get; set; }
        public Int16? ReportPhysicianIX { get; set; }
        public String ReportPhysicianName { get; set; }
        public Int16 TypistIX { get; set; }
        public String TypistName { get; set; }
        public String DocPath { get; set; }

        #region Ctor
        public RefDocData(Int32 DocID)
        {
            try
            {
                var DocData = Manager.DBML.RefDocuments.Where(Data => Data.ID == DocID).
                    Select(Data => new
                    {
                        Data.RefIX,
                        Data.TypeIX,
                        Data.Title,
                        Data.Date,
                        Data.ReportPhysicianIX,
                        Data.TypistIX,
                        Data.IsReport,
                        Data.DocPath
                    }).First();
                RefIX = DocData.RefIX;
                IsReport = DocData.IsReport;
                TypeIX = DocData.TypeIX;
                if (TypeIX == null)
                {
                    if (IsReport) TypeOf = "گزارش تصویربرداری";
                    else TypeOf = "مدرك پزشكی";
                }
                else TypeOf = Document.DocTypesList.Where(Data => Data.ID == TypeIX).Select(Data => Data.Title).First();
                TitleOf = DocData.Title;
                DateOf = DocData.Date;
                PersianDate FaDate = DocData.Date.ToPersianDate();
                FaDateOf = FaDate.Year + "/" + FaDate.Month + "/" + FaDate.Day + " " +
                    FaDate.Hour + ":" + FaDate.Minute + ":" + FaDate.Second;
                ReportPhysicianIX = DocData.ReportPhysicianIX;
                if (ReportPhysicianIX == null) ReportPhysicianName = String.Empty;
                else ReportPhysicianName = Referrals.RefServPerformers.
                    Where(Data => Data.ID == DocData.ReportPhysicianIX).Select(Data => Data.FullName).First();
                TypistIX = DocData.TypistIX;
                TypistName = Negar.DBLayerPMS.Security.UsersList.
                    Where(Data => Data.ID == DocData.TypistIX).Select(Data => Data.FullName).First();
                DocPath = DocData.DocPath;
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "خواندن اطلاعات مدرك مراجعه انتخاب شده ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "DBLayer - Document",
                    Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error); return;
            }
            #endregion
            ID = DocID;
        }
        #endregion
    }
    #endregion

}