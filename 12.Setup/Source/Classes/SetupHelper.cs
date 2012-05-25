#region using
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
#endregion

namespace Negar
{

    #region Enums

    #region public enum MedicalSystemDbList
    /// <summary>
    /// لیست زیر سیستم های تعریف شده
    /// </summary>
    public enum MedicalSystemDbList
    {
        PatientsSystem = 0,
        ImagingSystem = 500
    }
    #endregion

    #region public enum UpgradeTags
    /// <summary>
    /// لیست انواع تگ های فایل های ارتقاء
    /// </summary>
    public enum UpgradeTags
    {
        Comment = 0,
        UpdateStart = 1,
        UpdateEnd = 2,
        DbVersion = 3,
        Version = 4,
        CommandStart = 5,
        CommandEnd = 6
    }
    #endregion

    #endregion

    #region public static class SetupHelper
    /// <summary>
    /// كلاس مدیریت فرمان های ارتقاء بانك اطلاعاتی
    /// </summary>
    public static class SetupHelper
    {

        #region public List<DbUpgradData> GenerateUpgradeList(MedicalSystemDbList Database)
        /// <summary>
        /// تابعی برای خواندن 
        /// </summary>
        /// <param name="Database">نام بانك اطلاعاتی برای خواندن فرمان های ارتقاء</param>
        /// <returns>ساختار ردیف های ارتقاء بانك</returns>
        public static List<DbUpgradData> GenerateUpgradeList(MedicalSystemDbList Database)
        {
            String FileName = String.Empty;
            switch (Database)
            {
                case MedicalSystemDbList.PatientsSystem: FileName = "UpdateCmdPMS.DAT"; break;
                case MedicalSystemDbList.ImagingSystem: FileName = "UpdateCmdIMS.DAT"; break;
            }
            String[] UpdateStringArray = ReadUpdateFileLines(FileName);
            if (UpdateStringArray == null) return null;
            return ParseUpdateTextArray(UpdateStringArray);
        }
        #endregion

        #region String[] ReadUpdateFileLines(String FileName)
        /// <summary>
        /// تابعی برای خواندن متن ارتقاء موجود در یك فایل ارتقاء
        /// </summary>
        /// <param name="FileName">آدرس فایل</param>
        /// <returns>رشته ارتقاء موجود در فایل</returns>
        private static String[] ReadUpdateFileLines(String FileName)
        {
            if (!File.Exists(FileName))
            {
                PMBox.Show("فایل دستورات ارتقاء بانك اطلاعاتی وجود ندارد!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error); return null;
            }
            try { return File.ReadAllLines(FileName); }
            #region Catch
            catch
            {
                PMBox.Show("امكان خواندن اطلاعات فایل دستورات ارتقاء بانك اطلاعاتی وجود ندارد!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error); return null;
            }
            #endregion
        }
        #endregion

        #region List<DbUpgradData> ParseUpdateTextArray(IEnumerable<String> UpdateStringArray)
        /// <summary>
        /// تابعی برای تبدیل رشته ارتقاء به لیستی از اشیاء ارتقاء
        /// </summary>
        /// <param name="UpdateStringArray">فرمان ارتقاء</param>
        /// <returns>لیست ارتقاء هایی كه در متن فایل ارتقاء موجود است</returns>
        private static List<DbUpgradData> ParseUpdateTextArray(IEnumerable<String> UpdateStringArray)
        {
            List<DbUpgradData> ReturnValue = new List<DbUpgradData>();
            DbUpgradData CurrentRow = null;
            foreach (String CommandLine in UpdateStringArray)
            {
                if (IsContainTag(UpgradeTags.Comment, CommandLine) ||
                    IsContainTag(UpgradeTags.CommandStart, CommandLine) ||
                    IsContainTag(UpgradeTags.CommandEnd, CommandLine)) continue;
                if (IsContainTag(UpgradeTags.UpdateStart, CommandLine)) CurrentRow = new DbUpgradData();
                else if (IsContainTag(UpgradeTags.DbVersion, CommandLine) && CurrentRow != null)
                    CurrentRow.DBVersion = GetUpdateRowValue(UpgradeTags.DbVersion, CommandLine);
                else if (IsContainTag(UpgradeTags.Version, CommandLine) && CurrentRow != null)
                    CurrentRow.Version = GetUpdateRowValue(UpgradeTags.Version, CommandLine);
                else if (!IsContainTag(UpgradeTags.UpdateEnd, CommandLine) && CurrentRow != null)
                    CurrentRow.Command += " " + CommandLine;
                else if (IsContainTag(UpgradeTags.UpdateEnd, CommandLine)) ReturnValue.Add(CurrentRow);
            }
            return ReturnValue;
        }
        #endregion

        #region Boolean IsContainTag(UpgradeTags Tag, String LineText)
        /// <summary>
        /// تابعی برای بررسی نوع تگ یك ردیف
        /// </summary>
        /// <param name="Tag">نوع تگ</param>
        /// <param name="LineText">متنی كه باید در آن جستجو صورت گیرد</param>
        /// <returns>وجود یا عدم وجود</returns>
        private static Boolean IsContainTag(UpgradeTags Tag, String LineText)
        {
            switch (Tag)
            {
                case UpgradeTags.Comment: if (LineText.StartsWith("<Comment>")) return true; break;
                case UpgradeTags.UpdateStart: if (LineText.StartsWith("<Update>")) return true; break;
                case UpgradeTags.UpdateEnd: if (LineText.StartsWith("</Update>")) return true; break;
                case UpgradeTags.DbVersion: if (LineText.StartsWith("<DbVersion>")) return true; break;
                case UpgradeTags.Version: if (LineText.StartsWith("<Version>")) return true; break;
                case UpgradeTags.CommandStart: if (LineText.StartsWith("<Command>")) return true; break;
                case UpgradeTags.CommandEnd: if (LineText.StartsWith("</Command>")) return true; break;
            }
            return false;
        }
        #endregion

        #region String GetUpdateRowValue(UpgradeTags Tag, String LineText)
        /// <summary>
        /// تابعی برای خواندن متن موجود در یك ردیف ارتقاء
        /// </summary>
        /// <param name="Tag">نوع تگ</param>
        /// <param name="LineText">متنی كه باید در آن جستجو صورت گیرد</param>
        /// <returns>مقدار سطر</returns>
        private static String GetUpdateRowValue(UpgradeTags Tag, String LineText)
        {
            switch (Tag)
            {
                case UpgradeTags.DbVersion: if (LineText.StartsWith("<DbVersion>"))
                        return LineText.Substring(11, LineText.Length - 11); break;
                case UpgradeTags.Version: if (LineText.StartsWith("<Version>"))
                        return LineText.Substring(9, LineText.Length - 9); break;
            }
            return String.Empty;
        }
        #endregion

    }
    #endregion

    #region public class DbUpgradData
    /// <summary>
    /// كلاسی برای مدیریت یك ارتقاء بانك اطلاعاتی
    /// </summary>
    public class DbUpgradData
    {
        public String DBVersion { get; set; }
        public String Version { get; set; }
        public String Command { get; set; }
    }
    #endregion

}