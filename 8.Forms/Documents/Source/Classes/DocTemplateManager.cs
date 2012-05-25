#region using

using System;
using System.Data;
using System.Data.Linq;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Negar;
using Negar.DBLayerPMS.DataLayer;
using Negar.PersianCalendar.Utilities;
using Microsoft.Office.Interop.Word;
using Sepehr.DBLayerIMS.DataLayer;
using Application = Microsoft.Office.Interop.Word.Application;

#endregion

namespace Sepehr.Forms.Documents.Classes
{
    /// <summary>
    /// كلاس مدیریت فرمول های قالب های مدارك
    /// </summary>
    public static class DocTemplateFormulaManager
    {

        #region Fields

        #region static Object _MissingValue
        /// <summary>
        /// شیء تهی برای مدیریت پیش فرض ها
        /// </summary>
        private static Object _MissingValue = Missing.Value;
        #endregion

        #region static Int32 _CapturePicWidth
        private static Int32 _CapturePicWidth;
        #endregion

        #region static Int32 _CapturePicHeight
        private static Int32 _CapturePicHeight;
        #endregion

        #endregion

        #region Properties

        #region Int32 CapturePicWidth
        public static Int32 CapturePicWidth
        {
            get
            {
                if (_CapturePicWidth == 0) ReadCapturePicSize();
                return _CapturePicWidth;
            }
        }
        #endregion

        #region Int32 CapturePicHeight
        public static Int32 CapturePicHeight
        {
            get
            {
                if (_CapturePicWidth == 0) ReadCapturePicSize();
                return _CapturePicHeight;
            }
        }
        #endregion

        #endregion

        #region Methods

        #region Boolean ReplaceDocFormulas(Int32 RefID, Application WordApp, Document WordDoc, Boolean ShowDoc)
        /// <summary>
        /// تابع اصلاح فرمول های قالب های مدارك
        /// </summary>
        /// <param name="RefID">كلید مراجعه</param>
        /// <param name="WordApp">شیؤ برنامه آفیس</param>
        /// <param name="WordDoc">شیء فایل آفیس</param>
        /// <param name="ShowDoc">تعیین نمایش فایل آفیس</param>
        /// <returns>صحت انجام كار</returns>
        internal static Boolean ReplaceDocFormulas(Int32 RefID, Application WordApp, Document WordDoc, Boolean ShowDoc)
        {
            Cursor.Current = Cursors.WaitCursor;
            #region Check If Objects Does Not Exists
            if (WordApp == null || WordDoc == null)
            {
                PMBox.Show("فایل انتخاب شده برای مدیریت قالب مدرك پیدا نشد!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor.Current = Cursors.Default;
                return false;
            }
            #endregion
            Range Rng = WordDoc.Range(ref _MissingValue, ref _MissingValue);

            #region Replace Formulas
            Int32? PatientID = DBLayerIMS.Referrals.GetPatIDByRefID(RefID);

            #region Patient
            if (FindTextInWord(Rng, "NegarPatID") || FindTextInWord(Rng, "NegarPatFN") || FindTextInWord(Rng, "NegarPatLN") ||
                FindTextInWord(Rng, "NegarPatFullN") || FindTextInWord(Rng, "NegarPatEnFullN") ||
                FindTextInWord(Rng, "NegarPatGender") || FindTextInWord(Rng, "NegarPatEnGender") ||
                FindTextInWord(Rng, "NegarPatBirthS") || FindTextInWord(Rng, "NegarPatBirthG") ||
                FindTextInWord(Rng, "NegarPatAge") || FindTextInWord(Rng, "NegarPatFullAge") ||
                FindTextInWord(Rng, "NegarPatChildFullAge") || FindTextInWord(Rng, "NegarPatEnFullAge")
                || FindTextInWord(Rng, "NegarPatEnChildFullAge"))
            {
                PatList PatBaseData = Negar.DBLayerPMS.Patients.GetPatFullDataByPatListID(PatientID.Value);
                if (PatBaseData == null) return false;
                Rng = WordDoc.Range(ref _MissingValue, ref _MissingValue);

                #region NegarPatID
                if (FindTextInWord(Rng, "NegarPatID")) ReplaceDocFormula(Rng, "NegarPatID", PatBaseData.PatientID);
                #endregion

                #region NegarPatFN
                if (FindTextInWord(Rng, "NegarPatFN"))
                {
                    if (String.IsNullOrEmpty(PatBaseData.FirstName)) ReplaceDocFormula(Rng, "NegarPatFN", String.Empty);
                    else ReplaceDocFormula(Rng, "NegarPatFN", PatBaseData.FirstName);
                }
                #endregion

                #region NegarPatLN
                if (FindTextInWord(Rng, "NegarPatLN")) ReplaceDocFormula(Rng, "NegarPatLN", PatBaseData.LastName);
                #endregion

                #region NegarPatFullN
                if (FindTextInWord(Rng, "NegarPatFullN"))
                {
                    String FullName = PatBaseData.LastName;
                    if (!String.IsNullOrEmpty(PatBaseData.FirstName))
                        FullName = PatBaseData.FirstName + " " + FullName;
                    if (PatBaseData.IsMale == null) ReplaceDocFormula(Rng, "NegarPatFullN", FullName);
                    else if (PatBaseData.IsMale.Value) ReplaceDocFormula(Rng, "NegarPatFullN", "آقای " + FullName);
                    else ReplaceDocFormula(Rng, "NegarPatFullN", "خانم " + FullName);
                }
                #endregion

                #region NegarPatEnFullN
                if (FindTextInWord(Rng, "NegarPatEnFullN"))
                {
                    if (PatBaseData.PatDetail == null || String.IsNullOrEmpty(PatBaseData.PatDetail.EngLastName) ||
                       String.IsNullOrEmpty(PatBaseData.PatDetail.EngFirstName))
                        ReplaceDocFormula(Rng, "NegarPatEnFullN", String.Empty);
                    else ReplaceDocFormula(Rng, "NegarPatEnFullN",
                        PatBaseData.PatDetail.EngFirstName + " " + PatBaseData.PatDetail.EngLastName);
                }
                #endregion

                #region NegarPatGender
                if (FindTextInWord(Rng, "NegarPatGender"))
                {
                    if (PatBaseData.IsMale == null) ReplaceDocFormula(Rng, "NegarPatGender", String.Empty);
                    else if (PatBaseData.IsMale.Value) ReplaceDocFormula(Rng, "NegarPatGender", "مرد");
                    else ReplaceDocFormula(Rng, "NegarPatGender", "زن");
                }
                #endregion

                #region NegarPatEnGender
                if (FindTextInWord(Rng, "NegarPatEnGender"))
                {
                    if (PatBaseData.IsMale == null) ReplaceDocFormula(Rng, "NegarPatEnGender", String.Empty);
                    else if (PatBaseData.IsMale.Value) ReplaceDocFormula(Rng, "NegarPatEnGender", "Male");
                    else ReplaceDocFormula(Rng, "NegarPatEnGender", "Female");
                }
                #endregion

                #region NegarPatBirthS
                if (FindTextInWord(Rng, "NegarPatBirthS"))
                {
                    if (PatBaseData.BirthDate == null) ReplaceDocFormula(Rng, "NegarPatBirthS", String.Empty);
                    else
                    {
                        PersianDate Pcal = PatBaseData.BirthDate.Value.ToPersianDate();
                        String PatBirthS = Pcal.Day + "/" + Pcal.Month + "/" + Pcal.Year;
                        ReplaceDocFormula(Rng, "NegarPatBirthS", PatBirthS);
                    }
                }
                #endregion

                #region NegarPatBirthG
                if (FindTextInWord(Rng, "NegarPatBirthG"))
                {
                    if (PatBaseData.BirthDate == null) ReplaceDocFormula(Rng, "NegarPatBirthG", String.Empty);
                    else
                    {
                        String PatBirthG = PatBaseData.BirthDate.Value.Day + "/" +
                            PatBaseData.BirthDate.Value.Month + "/" + PatBaseData.BirthDate.Value.Year;
                        ReplaceDocFormula(Rng, "NegarPatBirthG", PatBirthG);
                    }
                }
                #endregion

                #region NegarPatAge
                if (FindTextInWord(Rng, "NegarPatAge"))
                {
                    if (PatBaseData.BirthDate == null) ReplaceDocFormula(Rng, "NegarPatAge", String.Empty);
                    else
                    {
                        String PatAge = (DateTime.Now.Year - PatBaseData.BirthDate.Value.Year).ToString();
                        ReplaceDocFormula(Rng, "NegarPatAge", PatAge);
                    }
                }
                #endregion

                #region NegarPatFullAge
                if (FindTextInWord(Rng, "NegarPatFullAge"))
                {
                    if ((PatBaseData.BirthDate == null)) ReplaceDocFormula(Rng, "NegarPatFullAge", String.Empty);
                    else
                    {
                        TimeSpan SubstractDate = DateTime.Now.Subtract(PatBaseData.BirthDate.Value);
                        Int32 Years = (Int32)SubstractDate.TotalDays / 365;
                        Int32 RemainDays = Math.Abs((Years * 365) - (Int32)SubstractDate.TotalDays);
                        Int32 Month = Math.Abs(RemainDays / 30);
                        RemainDays -= (Month * 30);
                        String Result = String.Empty;
                        if (Years != 0) Result = Math.Abs(Years) + " سال و ";
                        if (Month != 0) Result += Math.Abs(Month) + " ماه و ";
                        if (RemainDays != 0) Result += Math.Abs(RemainDays) + " روز";
                        Result = Result.Trim();
                        if (Result.Length > 0 && Result.Substring(Result.Length - 1) == "و")
                            // ReSharper disable EmptyGeneralCatchClause
                            try { Result = Result.Remove(Result.Length - 2, 2); }
                            catch { Result = "0 روز"; }
                        // ReSharper restore EmptyGeneralCatchClause
                        ReplaceDocFormula(Rng, "NegarPatFullAge", Result);
                    }
                }
                #endregion

                #region NegarPatChildFullAge
                if (FindTextInWord(Rng, "NegarPatChildFullAge"))
                {
                    if ((PatBaseData.BirthDate == null)) ReplaceDocFormula(Rng, "NegarPatChildFullAge", String.Empty);
                    else
                    {
                        System.Collections.Generic.List<UsersSetting> Setting303 =
                            DBLayerIMS.Settings.CurrentUserSettingsFullList.Where(Data => Data.SettingIX == 303).ToList();
                        if (Setting303.Count > 0 && Setting303.First().Boolean != null && !Setting303.First().Boolean.Value)
                            ReplaceDocFormula(Rng, "NegarPatChildFullAge",
                                (DateTime.Now.Year - PatBaseData.BirthDate.Value.Year).ToString());
                        else
                        {
                            System.Collections.Generic.List<UsersSetting> Setting307 =
                                DBLayerIMS.Settings.CurrentUserSettingsFullList.Where(Data => Data.SettingIX == 307).ToList();
                            Int16 AgeDetailsLimit = 0;
                            if (Setting307.Count > 0 && !String.IsNullOrEmpty(Setting307.First().Value))
                                AgeDetailsLimit = Convert.ToInt16(Setting307.First().Value);
                            if (AgeDetailsLimit >= DateTime.Now.Year - PatBaseData.BirthDate.Value.Year)
                            {
                                TimeSpan SubstractDate = DateTime.Now.Subtract(PatBaseData.BirthDate.Value);
                                Int32 Years = (Int32)SubstractDate.TotalDays / 365;
                                Int32 RemainDays = Math.Abs((Years * 365) - (Int32)SubstractDate.TotalDays);
                                Int32 Month = Math.Abs(RemainDays / 30);
                                RemainDays -= (Month * 30);
                                String Result = String.Empty;
                                if (Years != 0) Result = Math.Abs(Years) + " سال و ";
                                if (Month != 0) Result += Math.Abs(Month) + " ماه و ";
                                if (RemainDays != 0) Result += Math.Abs(RemainDays) + " روز";
                                Result = Result.Trim();
                                if (Result.Length > 0 && Result.Substring(Result.Length - 1) == "و")
                                    // ReSharper disable EmptyGeneralCatchClause
                                    try { Result = Result.Remove(Result.Length - 2, 2); }
                                    catch { Result = "0 روز"; }
                                // ReSharper restore EmptyGeneralCatchClause
                                ReplaceDocFormula(Rng, "NegarPatChildFullAge", Result);
                            }
                            else ReplaceDocFormula(Rng, "NegarPatChildFullAge",
                                (DateTime.Now.Year - PatBaseData.BirthDate.Value.Year).ToString());
                        }
                    }
                }
                #endregion

                #region NegarPatEnFullAge
                if (FindTextInWord(Rng, "NegarPatEnFullAge"))
                {
                    if ((PatBaseData.BirthDate == null)) ReplaceDocFormula(Rng, "NegarPatEnFullAge", String.Empty);
                    else
                    {
                        TimeSpan SubstractDate = DateTime.Now.Subtract(PatBaseData.BirthDate.Value);
                        Int32 Years = (Int32)SubstractDate.TotalDays / 365;
                        Int32 RemainDays = Math.Abs((Years * 365) - (Int32)SubstractDate.TotalDays);
                        Int32 Month = Math.Abs(RemainDays / 30);
                        RemainDays -= (Month * 30);
                        String Result = String.Empty;
                        if (Years != 0) Result = Math.Abs(Years) + " Years , ";
                        if (Month != 0) Result += Math.Abs(Month) + " Month , ";
                        if (RemainDays != 0) Result += Math.Abs(RemainDays) + " Days";
                        Result = Result.Trim();
                        // ReSharper disable EmptyGeneralCatchClause
                        if (Result.Length > 0 && Result.Substring(Result.Length - 1) == ",")
                            try { Result = Result.Remove(Result.Length - 2, 2); }
                            catch { Result = "0 Day"; }
                        // ReSharper restore EmptyGeneralCatchClause
                        ReplaceDocFormula(Rng, "NegarPatEnFullAge", Result);
                    }
                }
                #endregion

                #region NegarPatEnChildFullAge
                if (FindTextInWord(Rng, "NegarPatEnChildFullAge"))
                {
                    if ((PatBaseData.BirthDate == null)) ReplaceDocFormula(Rng, "NegarPatEnChildFullAge", String.Empty);
                    else
                    {
                        System.Collections.Generic.List<UsersSetting> Setting303 =
                           DBLayerIMS.Settings.CurrentUserSettingsFullList.Where(Data => Data.SettingIX == 303).ToList();
                        if (Setting303.Count > 0 && Setting303.First().Boolean != null && !Setting303.First().Boolean.Value)
                            ReplaceDocFormula(Rng, "NegarPatEnChildFullAge",
                                (DateTime.Now.Year - PatBaseData.BirthDate.Value.Year).ToString());
                        else
                        {
                            System.Collections.Generic.List<UsersSetting> Setting307 =
                                DBLayerIMS.Settings.CurrentUserSettingsFullList.Where(Data => Data.SettingIX == 307).ToList();
                            Int16 AgeDetailsLimit = 0;
                            if (Setting307.Count > 0 && !String.IsNullOrEmpty(Setting307.First().Value))
                                AgeDetailsLimit = Convert.ToInt16(Setting307.First().Value);
                            if (AgeDetailsLimit >= DateTime.Now.Year - PatBaseData.BirthDate.Value.Year)
                            {
                                TimeSpan SubstractDate = DateTime.Now.Subtract(PatBaseData.BirthDate.Value);
                                Int32 Years = (Int32)SubstractDate.TotalDays / 365;
                                Int32 RemainDays = Math.Abs((Years * 365) - (Int32)SubstractDate.TotalDays);
                                Int32 Month = Math.Abs(RemainDays / 30);
                                RemainDays -= (Month * 30);
                                String Result = String.Empty;
                                if (Years != 0) Result = Math.Abs(Years) + " Years , ";
                                if (Month != 0) Result += Math.Abs(Month) + " Month , ";
                                if (RemainDays != 0) Result += Math.Abs(RemainDays) + " Days";
                                Result = Result.Trim();
                                // ReSharper disable EmptyGeneralCatchClause
                                if (Result.Length > 0 && Result.Substring(Result.Length - 1) == ",")
                                    try { Result = Result.Remove(Result.Length - 2, 2); }
                                    catch { Result = "0 Day"; }
                                // ReSharper restore EmptyGeneralCatchClause
                                ReplaceDocFormula(Rng, "NegarPatEnChildFullAge", Result);
                            }
                            else ReplaceDocFormula(Rng, "NegarPatEnChildFullAge",
                                (DateTime.Now.Year - PatBaseData.BirthDate.Value.Year).ToString());
                        }
                    }
                }
                #endregion

            }
            #endregion

            #region Pat Addin Data
            // بررسی آنكه آیا فرمولی برای فیلد های اطلاعاتی پویا بیمار در قبض استفاده شده است تا اطلاعات آن از بانك خوانده شود
            Boolean IsAnyAddinFieldExists = false;
            foreach (PatAdditionalColumn column in DBLayerIMS.Referrals.PatAddinColsList)
                if (FindTextInWord(Rng, "NegarPatField" + column.ID)) IsAnyAddinFieldExists = true;
            if (IsAnyAddinFieldExists && DBLayerIMS.Referrals.PatAddinColsList.Count > 0)
            {
                #region Read Data
                DataTable TempDataTable = DBLayerIMS.Manager.ExecuteQuery(
                    "EXEC [ImagingSystem].[Referrals].[SP_SelectPatAdditionalData] " + PatientID.Value, 10);
                if (TempDataTable == null) return false;
                #endregion

                #region Set Data
                if (TempDataTable.Rows.Count != 0)
                    foreach (PatAdditionalColumn column in DBLayerIMS.Referrals.PatAddinColsList)
                    {
                        if (column.TypeID == 0 || column.TypeID == 2) // String Or Integer Data
                        {
                            String TheValue = String.Empty;
                            if (TempDataTable.Rows[0][column.FieldName] != null &&
                                TempDataTable.Rows[0][column.FieldName] != DBNull.Value &&
                                !String.IsNullOrEmpty(TempDataTable.Rows[0][column.FieldName].ToString()))
                                TheValue = TempDataTable.Rows[0][column.FieldName].ToString();
                            ReplaceDocFormula(Rng, "NegarPatField" + column.ID, TheValue);
                        }
                        else if (column.TypeID == 1) // Boolean Data
                        {
                            Boolean TheValue = false;
                            if (TempDataTable.Rows[0][column.FieldName] != null &&
                                TempDataTable.Rows[0][column.FieldName] != DBNull.Value &&
                                Convert.ToBoolean(TempDataTable.Rows[0][column.FieldName]))
                                TheValue = true;
                            if (TheValue) ReplaceDocFormula(Rng, "NegarPatField" + column.ID, "صحیح");
                            else ReplaceDocFormula(Rng, "NegarPatField" + column.ID, "غلط");
                        }
                        else if (column.TypeID == 3) // MultiChoice Data
                        {
                            String TheValue = String.Empty;
                            if (TempDataTable.Rows[0][column.FieldName] != null &&
                                TempDataTable.Rows[0][column.FieldName] != DBNull.Value)
                                TheValue = DBLayerIMS.Referrals.PatAddinDataItemsList.Where(Data => Data.ID ==
                                Convert.ToInt16(TempDataTable.Rows[0][column.FieldName])).First().Title;
                            ReplaceDocFormula(Rng, "NegarPatField" + column.ID, TheValue);
                        }
                    }
                #endregion
            }
            #endregion

            #region Ref Data
            if (FindTextInWord(Rng, "NegarRefDate") || FindTextInWord(Rng, "NegarRefTime") ||
                FindTextInWord(Rng, "NegarRefDT") || FindTextInWord(Rng, "NegarRefEnDT") ||
                FindTextInWord(Rng, "NegarRefPresD") || FindTextInWord(Rng, "NegarRefPresEnD") ||
                FindTextInWord(Rng, "NegarRefWeight") || FindTextInWord(Rng, "NegarRefPhysN") ||
                FindTextInWord(Rng, "NegarRefPhysFullN") || FindTextInWord(Rng, "NegarRefPhysID") ||
                FindTextInWord(Rng, "NegarRefPhysEnN") || FindTextInWord(Rng, "NegarRefStatus") ||
                FindTextInWord(Rng, "NegarRefAdmitter") || FindTextInWord(Rng, "NegarServ1Phys") ||
                FindTextInWord(Rng, "NegarServ1Exp") || FindTextInWord(Rng, "NegarServ1Cat"))
            {
                RefList RefData = DBLayerIMS.Referrals.GetRefDataByID(RefID);
                if (RefData == null) return false;
                Rng = WordDoc.Range(ref _MissingValue, ref _MissingValue);

                #region NegarRefDate
                PersianDate RefDate = RefData.RegisterDate.ToPersianDate();
                String PersianRefDate = RefDate.Day + "/" + RefDate.Month + "/" + RefDate.Year;
                ReplaceDocFormula(Rng, "NegarRefDate", PersianRefDate);
                #endregion

                #region NegarRefTime
                String RefTime = RefDate.Hour + ":" + RefDate.Minute + ":" + RefDate.Second;
                ReplaceDocFormula(Rng, "NegarRefTime", RefTime);
                #endregion

                #region NegarRefDT
                ReplaceDocFormula(Rng, "NegarRefDT", PersianRefDate + " - " + RefTime);
                #endregion

                #region NegarRefEnDT
                if (FindTextInWord(Rng, "NegarRefEnDT"))
                {
                    DateTime RefDateEn = RefData.RegisterDate;
                    String RefDateEnString = RefDateEn.Day + "/" + RefDateEn.Month + "/" + RefDateEn.Year;
                    ReplaceDocFormula(Rng, "NegarRefEnDT", RefDateEnString);
                }
                #endregion

                #region NegarRefPresD
                if (FindTextInWord(Rng, "NegarRefPresD"))
                {
                    if (RefData.PrescriptionDate == null) ReplaceDocFormula(Rng, "NegarRefPresD", String.Empty);
                    else
                    {
                        PersianDate DateFa = RefData.PrescriptionDate.Value.ToPersianDate();
                        String PrescriptionDateFaString = DateFa.Day + "/" + DateFa.Month + "/" + DateFa.Year;
                        ReplaceDocFormula(Rng, "NegarRefPresD", PrescriptionDateFaString);
                    }
                }
                #endregion

                #region NegarRefPresEnD
                if (FindTextInWord(Rng, "NegarRefPresEnD"))
                {
                    if (RefData.PrescriptionDate == null) ReplaceDocFormula(Rng, "NegarRefPresEnD", String.Empty);
                    else
                    {
                        DateTime DateEn = RefData.PrescriptionDate.Value;
                        String PrescriptionDateEnString = DateEn.Day + "/" + DateEn.Month + "/" + DateEn.Year;
                        ReplaceDocFormula(Rng, "NegarRefPresEnD", PrescriptionDateEnString);
                    }
                }
                #endregion

                #region NegarRefWeight
                if (FindTextInWord(Rng, "NegarRefWeight"))
                {
                    if (RefData.Weight == null) ReplaceDocFormula(Rng, "NegarRefWeight", String.Empty);
                    else ReplaceDocFormula(Rng, "NegarRefWeight", RefData.Weight.ToString());
                }
                #endregion

                #region Ref Physician Data
                if (FindTextInWord(Rng, "NegarRefPhysN") || FindTextInWord(Rng, "NegarRefPhysFullN") ||
                    FindTextInWord(Rng, "NegarRefPhysID") || FindTextInWord(Rng, "NegarRefPhysEnN"))
                {
                    if (RefData.ReferPhysicianIX != null)
                    {
                        RefPhysician PhysData =
                            Negar.DBLayerPMS.ClinicData.GetRefPhysBaseDataByID(RefData.ReferPhysicianIX.Value);
                        if (PhysData != null)
                        {
                            #region NegarRefPhysN
                            String FullName = PhysData.LastName;
                            if (!String.IsNullOrEmpty(PhysData.FirstName.Trim()))
                                FullName = PhysData.FirstName.Trim() + " " + FullName;
                            ReplaceDocFormula(Rng, "NegarRefPhysN", FullName);
                            #endregion

                            #region NegarRefPhysFullN
                            if (PhysData.IsMale)
                                ReplaceDocFormula(Rng, "NegarRefPhysFullN", "جناب آقای دكتر " + FullName);
                            else ReplaceDocFormula(Rng, "NegarRefPhysFullN", "سركار خانم دكتر " + FullName);
                            #endregion

                            #region NegarRefPhysID
                            ReplaceDocFormula(Rng, "NegarRefPhysID", PhysData.MedicalID);
                            #endregion

                            #region NegarRefPhysEnN
                            String FullNameEn = String.Empty;
                            if (!String.IsNullOrEmpty(PhysData.FirstNameEn))
                                FullNameEn = PhysData.FirstNameEn.Trim();
                            if (!String.IsNullOrEmpty(PhysData.LastNameEn))
                                FullNameEn += " " + PhysData.LastNameEn;
                            ReplaceDocFormula(Rng, "NegarRefPhysEnN", FullNameEn);
                            #endregion
                        }
                        else
                        {
                            ReplaceDocFormula(Rng, "NegarRefPhysN", String.Empty);
                            ReplaceDocFormula(Rng, "NegarRefPhysFullN", String.Empty);
                            ReplaceDocFormula(Rng, "NegarRefPhysID", String.Empty);
                            ReplaceDocFormula(Rng, "NegarRefPhysEnN", String.Empty);
                        }
                    }
                    else
                    {
                        ReplaceDocFormula(Rng, "NegarRefPhysN", String.Empty);
                        ReplaceDocFormula(Rng, "NegarRefPhysFullN", String.Empty);
                        ReplaceDocFormula(Rng, "NegarRefPhysID", String.Empty);
                        ReplaceDocFormula(Rng, "NegarRefPhysEnN", String.Empty);
                    }
                }
                #endregion

                #region NegarRefStatus
                if (FindTextInWord(Rng, "NegarRefStatus"))
                {
                    if (RefData.ReferStatusIX == null) ReplaceDocFormula(Rng, "NegarRefStatus", String.Empty);
                    else
                    {
                        String StatusTitle = DBLayerIMS.Referrals.RefStatusList.
                            Where(Data => Data.ID == RefData.ReferStatusIX).Select(Data => Data.Title).First();
                        ReplaceDocFormula(Rng, "NegarRefStatus", StatusTitle);
                    }
                }
                #endregion

                #region NegarRefAdmitter
                if (FindTextInWord(Rng, "NegarRefAdmitter"))
                {
                    String UserFullName = Negar.DBLayerPMS.Security.UsersList.
                        Where(Data => Data.ID == RefData.AdmitterIX).Select(Data => Data.FullName).First();
                    ReplaceDocFormula(Rng, "NegarRefAdmitter", UserFullName);
                }
                #endregion

                #region Ref Services
                if (FindTextInWord(Rng, "NegarServ1Phys") || FindTextInWord(Rng, "NegarServ1Exp") ||
                    FindTextInWord(Rng, "NegarServ1Cat"))
                    try
                    {
                        IQueryable<RefService> CurrentRefServices =
                            DBLayerIMS.Manager.DBML.RefServices.Where(Data => Data.ReferralIX == RefID && Data.IsActive);
                        DBLayerIMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, CurrentRefServices);
                        if (CurrentRefServices.Count() == 0)
                        {
                            ReplaceDocFormula(Rng, "NegarServ1Phys", String.Empty);
                            ReplaceDocFormula(Rng, "NegarServ1Exp", String.Empty);
                            ReplaceDocFormula(Rng, "NegarServ1Cat", String.Empty);
                        }
                        else
                        {
                            if (CurrentRefServices.First().PhysicianIX == null)
                                ReplaceDocFormula(Rng, "NegarServ1Phys", String.Empty);
                            else
                            {
                                String FullName = DBLayerIMS.Referrals.RefServPerformers.
                                    Where(Data => Data.ID == CurrentRefServices.First().PhysicianIX).First().LastName;
                                String FirstName = DBLayerIMS.Referrals.RefServPerformers.
                                    Where(Data => Data.ID == CurrentRefServices.First().PhysicianIX).First().FirstName;
                                if (!String.IsNullOrEmpty(FirstName)) FullName = FirstName + " " + FullName;
                                ReplaceDocFormula(Rng, "NegarServ1Phys", FullName);
                            }
                            if (CurrentRefServices.First().ExpertIX == null)
                                ReplaceDocFormula(Rng, "NegarServ1Exp", String.Empty);
                            else
                            {
                                String FullName = DBLayerIMS.Referrals.RefServPerformers.
                                    Where(Data => Data.ID == CurrentRefServices.First().ExpertIX).First().LastName;
                                String FirstName = DBLayerIMS.Referrals.RefServPerformers.
                                    Where(Data => Data.ID == CurrentRefServices.First().ExpertIX).First().FirstName;
                                if (!String.IsNullOrEmpty(FirstName)) FullName = FirstName + " " + FullName;
                                ReplaceDocFormula(Rng, "NegarServ1Exp", FullName);
                            }
                            if (CurrentRefServices.First().ServicesList.CategoryIX == null)
                                ReplaceDocFormula(Rng, "NegarServ1Cat", String.Empty);
                            else ReplaceDocFormula(Rng, "NegarServ1Cat", CurrentRefServices.First().ServicesList.ServicesCategories.Name);
                        }
                    }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage = "خواندن اطلاعات خدمات مراجعه بیمار جاری ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Sepehr", "Documents Forms", Ex.Message + "\n" +
                            Ex.StackTrace, EventLogEntryType.Error);
                    }
                    #endregion
                #endregion
            }
            #endregion

            #region Ref Addin Data
            // بررسی آنكه آیا فرمولی برای فیلد های اطلاعاتی پویا مراجعات در قبض استفاده شده است تا اطلاعات آن از بانك خوانده شود
            IsAnyAddinFieldExists = false;
            foreach (RefAdditionalColumn column in DBLayerIMS.Referrals.RefAddinColsList)
                if (FindTextInWord(Rng, "NegarRefField" + column.ID + "")) IsAnyAddinFieldExists = true;
            if (IsAnyAddinFieldExists)
            {
                #region Read
                DataTable TempDataTable = DBLayerIMS.Manager.ExecuteQuery(
                    "EXEC [ImagingSystem].[Referrals].[SP_SelectRefAdditionalData] " + RefID, 10);
                #endregion

                #region Set Data
                if (TempDataTable.Rows.Count == 0)
                {
                    foreach (RefAdditionalColumn column in DBLayerIMS.Referrals.RefAddinColsList)
                        ReplaceDocFormula(Rng, "NegarRefField" + column.ID, String.Empty);
                }
                else
                {
                    foreach (RefAdditionalColumn column in DBLayerIMS.Referrals.RefAddinColsList)
                        if (column.TypeID == 0 || column.TypeID == 2) // String Or Integer Data
                        {
                            String TheValue = String.Empty;
                            if (TempDataTable.Rows[0][column.FieldName] != null &&
                                TempDataTable.Rows[0][column.FieldName] != DBNull.Value &&
                                !String.IsNullOrEmpty(TempDataTable.Rows[0][column.FieldName].ToString()))
                                TheValue = TempDataTable.Rows[0][column.FieldName].ToString();
                            ReplaceDocFormula(Rng, "NegarRefField" + column.ID, TheValue);
                        }
                        else if (column.TypeID == 1) // Boolean Data
                        {
                            Boolean TheValue = false;
                            if (TempDataTable.Rows[0][column.FieldName] != null &&
                                TempDataTable.Rows[0][column.FieldName] != DBNull.Value &&
                                Convert.ToBoolean(TempDataTable.Rows[0][column.FieldName]))
                                TheValue = true;
                            if (TheValue) ReplaceDocFormula(Rng, "NegarRefField" + column.ID, "صحیح");
                            else ReplaceDocFormula(Rng, "NegarRefField" + column.ID, "غلط");
                        }
                        else if (column.TypeID == 3) // MultiChoice Data
                        {
                            String TheValue = String.Empty;
                            if (TempDataTable.Rows[0][column.FieldName] != null &&
                                TempDataTable.Rows[0][column.FieldName] != DBNull.Value)
                                TheValue = DBLayerIMS.Referrals.RefAddinDataItemsList.Where(Data => Data.ID ==
                                Convert.ToInt16(TempDataTable.Rows[0][column.FieldName])).First().Title;
                            ReplaceDocFormula(Rng, "NegarRefField" + column.ID, TheValue);
                        }
                }
                #endregion
            }
            #endregion

            #endregion

            WordDoc.Save();
            if (ShowDoc)
            {
                WordApp.ShowWindowsInTaskbar = true;
                WordApp.WindowState = WdWindowState.wdWindowStateMaximize;
                WordApp.Visible = true;
                WordApp.ShowMe();
                WordApp.Activate();
                WordDoc.Activate();
                WordDoc.Select();
            }
            Cursor.Current = Cursors.Default;
            return true;
        }
        #endregion

        #region Boolean FindTextInWord(Range Range, Object TextToFind)
        /// <summary>
        /// تابعی برای جستجوی وجود یك متن در یك مدرك ورد
        /// </summary>
        /// <param name="Range">محدوده فایل مورد نظر</param>
        /// <param name="TextToFind">متن اصلی</param>
        internal static Boolean FindTextInWord(Range Range, Object TextToFind)
        {
            return Range.Find.Execute(ref TextToFind, ref _MissingValue, ref _MissingValue, ref _MissingValue,
                ref _MissingValue, ref _MissingValue, ref _MissingValue, ref _MissingValue, ref _MissingValue,
                ref _MissingValue, ref _MissingValue, ref _MissingValue, ref _MissingValue,
                ref _MissingValue, ref _MissingValue);
        }
        #endregion

        #region void ReplaceDocFormula(Range Range, Object TextToFind, Object TextToReplace)
        /// <summary>
        /// تابعی برای جانشانی یك عبارت در یك مدرك ورد
        /// </summary>
        /// <param name="Range">محدوده فایل مورد نظر</param>
        /// <param name="TextToFind">متن اصلی</param>
        /// <param name="TextToReplace">متن جایگزین</param>
        internal static void ReplaceDocFormula(Range Range, Object TextToFind, Object TextToReplace)
        {
            if (TextToReplace == null) TextToReplace = String.Empty;
            Object ShoudReplaceAllWords = WdReplace.wdReplaceAll;
            Object MachWholeWord = true;
            Range.Find.Execute(ref TextToFind, ref _MissingValue, ref MachWholeWord, ref _MissingValue,
                ref _MissingValue, ref _MissingValue, ref _MissingValue, ref _MissingValue, ref _MissingValue,
                ref TextToReplace, ref ShoudReplaceAllWords, ref _MissingValue, ref _MissingValue,
                ref _MissingValue, ref _MissingValue);
        }
        #endregion

        #region private void ReadCapturePicSize()
        private static void ReadCapturePicSize()
        {
            System.Collections.Generic.List<UsersSetting> UserSettings;
            try
            {
                IQueryable<UsersSetting> TempData =
                    DBLayerIMS.Manager.DBML.UsersSettings.Where(Data => Data.SettingIX == 752);
                DBLayerIMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, TempData);
                UserSettings = TempData.ToList();
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان خواندن اطلاعات تنظیمات كاربری كاربر جاری از بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Document Class", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return;
            }
            #endregion
            if (UserSettings.Exists(Data => Data.SettingIX == 752) &&
              UserSettings.Where(Data => Data.SettingIX == 752).First().Value != null &&
              !String.IsNullOrEmpty(UserSettings.Where(Data => Data.SettingIX == 752).First().Value))
            {
                String value = UserSettings.Where(Data => Data.SettingIX == 752).First().Value;
                for (Int32 i = 0; i < value.Length; i++)
                    if (value[i].Equals(','))
                    {
                        _CapturePicWidth = Convert.ToInt32(value.Substring(0, i));
                        _CapturePicHeight = Convert.ToInt32(value.Substring(i + 1));
                        break;
                    }
            }
            else
            {
                _CapturePicWidth = 320;
                _CapturePicHeight= 240;
            }
        }
        #endregion

        #endregion

    }
}