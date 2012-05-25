#region using
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;
using Negar;
using Negar.DBLayerPMS.DataLayer;
using Negar.PersianCalendar.Utilities;
using Microsoft.Office.Interop.Excel;
using Sepehr.DBLayerIMS.DataLayer;
using DataTable = System.Data.DataTable;
using DbLayer = Sepehr.DBLayerIMS.DataLayer.DbLayer;
#endregion

namespace Sepehr
{
    /// <summary>
    /// كلاس مدیریت چاپ و پیش نمایش قالب های چاپ
    /// </summary>
    public static class BillPrintManager
    {

        #region Fields

        #region Dictionary<Int16, Binary> _UsedBillsBinaryList
        /// <summary>
        /// لیست اسامی قالب های قبوض بر اساس سطح دسترسی كاربر
        /// </summary>
        private static Dictionary<Int16, Binary> _UsedBillsBinaryList;
        #endregion

        #region List<SP_SelectBillTemplateResult> _CurrentUserBillTemplatesList
        /// <summary>
        /// لیست قالب های قبوض قابل استفاده توسط كاربر جاری
        /// </summary>
        private static List<SP_SelectBillTemplateResult> _CurrentUserBillTemplatesList;
        #endregion

        #region String _SubKeyBillDefaultPrinter
        /// <summary>
        /// كلید ذخیره سازی اطلاعات پرینتر پیش فرض قالب قبوض در رجیستری
        /// </summary>
        private const String _SubKeyBillDefaultPrinter = "Software\\Negar\\NegarBillTemplateDefaultPrinter";
        #endregion

        #endregion

        #region Properties

        #region List<SP_SelectBillTemplateResult> CurrentUserBillTemplatesList
        /// <summary>
        /// لیست قالب های قبض قابل استفاده توسط كاربر جاری
        /// </summary>
        public static List<SP_SelectBillTemplateResult> CurrentUserBillTemplatesList
        {
            get
            {
                if (_CurrentUserBillTemplatesList == null)
                    try
                    {
                        _CurrentUserBillTemplatesList = DBLayerIMS.Manager.
                            DBML.SP_SelectBillTemplate(SecurityManager.CurrentUserID).ToList();
                    }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage = "خواندن لیست قبوض مجاز كاربر جاری از بانك اطلاعات ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Sepehr", "Bills Print Manager",
                            Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                        return null;
                    }
                    #endregion
                return _CurrentUserBillTemplatesList;
            }
            set
            {
                _CurrentUserBillTemplatesList = value;
                _UsedBillsBinaryList = null;
            }
        }
        #endregion

        #endregion

        #region Public Methods

        #region Boolean RefBillPrintPreview(Int32 RefID , Int16 BillTemplateID)
        /// <summary>
        /// تابع پیش نمایش از قبض برای مراجعه انتخاب شده
        /// </summary>
        /// <param name="RefID">كلید مراجعه</param>
        /// <param name="BillTemplateID">كلید قالب قبض</param>
        /// <returns>صحت انجان كار</returns>
        public static Boolean RefBillPrintPreview(Int32 RefID, Int16 BillTemplateID)
        {
            Cursor.Current = Cursors.WaitCursor;
            // فراخوانی تابه پیش نمایش با كلید كراجعه ارسال شده
            return PrintDocument(false, RefID, BillTemplateID, 0);
        }
        #endregion

        #region void RefBillPrint(Int32 RefID , Int16 BillTemplateID , Int16 CopyCount)
        /// <summary>
        /// تابع چاپ قبوض برای یك مراجعه
        /// </summary>
        /// <param name="RefID">كلید مراجعه</param>
        /// <param name="BillTemplateID">كلید قالب قبض</param>
        /// <param name="CopyCount">تعداد رونوشت</param>
        public static void RefBillPrint(Int32 RefID, Int16 BillTemplateID, Int16 CopyCount)
        {
            Cursor.Current = Cursors.WaitCursor;
            Thread MyThread = new Thread(() => PrintDocument(true, RefID, BillTemplateID, CopyCount));
            MyThread.Start();
        }
        #endregion

        #region void RefBillPrint(List<Int32> PatIDList, Int16 BillTemplateID, Int16 CopyCount, Boolean PrintLastRef)
        /// <summary>
        /// تابع چاپ جمعی قبوض
        /// </summary>
        public static void RefBillPrint(List<Int32> PatIDList, Int16 BillTemplateID, Int16 CopyCount, Boolean PrintLastRef)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (PrintLastRef)
                foreach (Int32 PID in PatIDList)
                {
                    Int32? LastRefID = DBLayerIMS.Referrals.GetPatFirstOrLastRefID(PID, true);
                    if (LastRefID == null) continue;
                    PrintDocument(true, LastRefID.Value, BillTemplateID, CopyCount);
                }
            else foreach (Int32 PID in PatIDList)
                {
                    List<Int32> RefIDList = DBLayerIMS.Referrals.GetPatRefIDListByPatID(PID);
                    if (RefIDList == null) continue;
                    foreach (Int32 RefID in RefIDList) PrintDocument(true, RefID, BillTemplateID, CopyCount);
                }
            Cursor.Current = Cursors.Default;
        }
        #endregion

        #endregion

        #region Private Methods

        #region Boolean PrintDocument(Boolean IsPrint, Int32 RefID, Int16 BillTemplateID, Int32 CopyCount)
        /// <summary>
        /// روالی برای آماده سازی یك قالب قبض برای چاپ در یك مراجعه بیمار
        /// </summary>
        private static Boolean PrintDocument(Boolean IsPrint, Int32 RefID, Int16 BillTemplateID, Int32 CopyCount)
        {
            if (SecurityManager.CurrentUserID > 2 && !CheckUserPrintLimitation(BillTemplateID, RefID)) return true;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("En-Us");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("En-Us");
            String FilePath = System.Windows.Forms.Application.StartupPath + "\\TempBillTemplate" + BillTemplateID +
                    DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + ".Xls";
            if (!ReadBillTemplateFile(BillTemplateID, FilePath)) return false;
            #region Make Excel Object
            Microsoft.Office.Interop.Excel.Application ExcelApplication;
            try
            {
                ExcelApplication = new Microsoft.Office.Interop.Excel.Application();
                // ReSharper disable ConditionIsAlwaysTrueOrFalse
                if (ExcelApplication == null)
                {
                    PMBox.Show("امكان باز كردن فایل اكسل وجود ندارد.\n" +
                        "آیا نرم افزار اكسل بر روی سیستم جاری نصب می باشد؟", "خطا!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
                }
                // ReSharper restore ConditionIsAlwaysTrueOrFalse
                // خواندن فایل اكسل:
                ExcelApplication.Workbooks.Open(FilePath, Missing.Value, true, Missing.Value, Missing.Value, true, Missing.Value,
                    Missing.Value, Missing.Value, false, false, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            }
            #region Catch
            catch (Exception Ex)
            {
                PMBox.Show("امكان باز كردن فایل اكسل وجود ندارد.\n" +
                    "آیا نرم افزار اكسل بر روی سیستم جاری نصب می باشد؟", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Bills Print Manager", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error); CloseExcelApp(null, FilePath); return false;
            }
            #endregion
            #endregion
            Negar.DBLayerPMS.DataLayer.DbLayer _PMSDbLayer =
                new Negar.DBLayerPMS.DataLayer.DbLayer(CSManager.GetConnectionString("PatientsSystem", 30));
            DbLayer _IMSDbLayer = new DbLayer(CSManager.GetConnectionString("ImagingSystem", 30));
            #region Replace Formulas
            Worksheet WSheet = ((Worksheet)ExcelApplication.Workbooks[1].Worksheets[1]);

            #region Not-Bound Params

            #region [PrintTime]
            PersianDate PCurrentDate = DateTime.Now.ToPersianDate();
            ReplaceText(WSheet, "[PrintTime]",
                PCurrentDate.Year + "/" + PCurrentDate.Month + "/" + PCurrentDate.Day + " - " +
                DateTime.Now.ToString("HH:mm:ss"));
            #endregion

            #region [PrinterUserName]
            ReplaceText(WSheet, "[PrinterUserName]", Negar.DBLayerPMS.Security.UsersList.
                Where(Data => Data.ID == SecurityManager.CurrentUserID).First().FullName);
            #endregion

            #endregion

            Int32? PatientID = DBLayerIMS.Referrals.GetPatIDByRefID(RefID);
            if (PatientID == null) { CloseExcelApp(ExcelApplication, FilePath); return false; }

            #region Patient Data
            // بررسی آنكه آیا فرمولی برای فیلدهای بیمار در قبض استفاده شده است تا اطلاعات بیمار از بانك خوانده شود
            if (FindExcelData(WSheet, "[PatID]") || FindExcelData(WSheet, "[PatFN]") || FindExcelData(WSheet, "[PatLN]") ||
                FindExcelData(WSheet, "[PatFullN]") || FindExcelData(WSheet, "[PatGender]") ||
                FindExcelData(WSheet, "[PatBirthS]") || FindExcelData(WSheet, "[PatAge]") || FindExcelData(WSheet, "[PatChildAge]") ||
                FindExcelData(WSheet, "[Tel1]") || FindExcelData(WSheet, "[Tel2]") ||
                FindExcelData(WSheet, "[PatAddress]") || FindExcelData(WSheet, "[PatNationalID]"))
            {
                PatList PatBaseData = _PMSDbLayer.PatLists.Where(Data => Data.ID == PatientID.Value).First();
                if (PatBaseData == null) return false;
                ReplaceText(WSheet, "[PatID]", PatBaseData.PatientID);

                if (String.IsNullOrEmpty(PatBaseData.FirstName)) ReplaceText(WSheet, "[PatFN]", String.Empty);
                else ReplaceText(WSheet, "[PatFN]", PatBaseData.FirstName);

                ReplaceText(WSheet, "[PatLN]", PatBaseData.LastName);

                #region [PatFullN]
                String FullName = PatBaseData.LastName;
                if (!String.IsNullOrEmpty(PatBaseData.FirstName))
                    FullName = PatBaseData.FirstName + " " + FullName;
                if (PatBaseData.IsMale == null) ReplaceText(WSheet, "[PatFullN]", FullName);
                else if (PatBaseData.IsMale.Value) ReplaceText(WSheet, "[PatFullN]", "آقای " + FullName);
                else ReplaceText(WSheet, "[PatFullN]", "خانم " + FullName);
                #endregion

                if (PatBaseData.IsMale == null) ReplaceText(WSheet, "[PatGender]", String.Empty);
                else if (PatBaseData.IsMale.Value) ReplaceText(WSheet, "[PatGender]", "مرد");
                else ReplaceText(WSheet, "[PatGender]", "زن");

                if (PatBaseData.BirthDate == null) ReplaceText(WSheet, "[PatBirthS]", String.Empty);
                else
                {
                    PersianDate Pcal = PatBaseData.BirthDate.Value.ToPersianDate();
                    String PatBirthS = Pcal.Year + "/" + Pcal.Month + "/" + Pcal.Day;
                    ReplaceText(WSheet, "[PatBirthS]", PatBirthS);
                }

                if (PatBaseData.BirthDate == null) ReplaceText(WSheet, "[PatAge]", String.Empty);
                else ReplaceText(WSheet, "[PatAge]", (DateTime.Now.Year - PatBaseData.BirthDate.Value.Year).ToString());

                #region [PatChildAge]
                if (PatBaseData.BirthDate == null) ReplaceText(WSheet, "[PatChildAge]", String.Empty);
                else
                {
                   List<UsersSetting> Setting303 =
                        DBLayerIMS.Settings.CurrentUserSettingsFullList.Where(Data => Data.SettingIX == 303).ToList();
                    if (Setting303.Count > 0 && Setting303.First().Boolean != null && !Setting303.First().Boolean.Value)
                        ReplaceText(WSheet, "[PatChildAge]", (DateTime.Now.Year - PatBaseData.BirthDate.Value.Year).ToString());
                    else
                    {
                        List<UsersSetting> Setting307 =
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
                            ReplaceText(WSheet, "[PatChildAge]", Result);
                        }
                        else ReplaceText(WSheet, "[PatChildAge]", (DateTime.Now.Year - PatBaseData.BirthDate.Value.Year).ToString());
                    }
                }
                #endregion

                if (PatBaseData.PatDetail == null) ReplaceText(WSheet, "[PatNationalID]", String.Empty);
                else ReplaceText(WSheet, "[PatNationalID]", PatBaseData.PatDetail.IDNo);

                if (PatBaseData.PatDetail == null) ReplaceText(WSheet, "[Tel1]", String.Empty);
                else ReplaceText(WSheet, "[Tel1]", PatBaseData.PatDetail.TelNo1);

                if (PatBaseData.PatDetail == null) ReplaceText(WSheet, "[Tel2]", String.Empty);
                else ReplaceText(WSheet, "[Tel2]", PatBaseData.PatDetail.TelNo2);

                if (PatBaseData.PatDetail == null) ReplaceText(WSheet, "[PatAddress]", String.Empty);
                else ReplaceText(WSheet, "[PatAddress]", PatBaseData.PatDetail.Address);
            }
            #endregion

            #region Patient Addin Data
            if (DBLayerIMS.Referrals.PatAddinColsList.Count > 0)
            {
                // بررسی آنكه آیا فرمولی برای فیلد های اطلاعاتی پویا بیمار در قبض استفاده شده است تا اطلاعات آن از بانك خوانده شود
                Boolean IsAnyAddinFieldExists = false;
                foreach (PatAdditionalColumn column in DBLayerIMS.Referrals.PatAddinColsList)
                    if (FindExcelData(WSheet, "[PatField" + column.ID + "]")) IsAnyAddinFieldExists = true;
                if (IsAnyAddinFieldExists)
                {
                    #region Read Data
                    DataTable TempDataTable = DBLayerIMS.Manager.
                        ExecuteQuery("EXEC [ImagingSystem].[Referrals].[SP_SelectPatAdditionalData] " + PatientID.Value, 10);
                    if (TempDataTable == null)
                    {
                        const String ErrorMessage = "امكان خواندن اطلاعات پویا بیمار از بانك اطلاعات ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        CloseExcelApp(ExcelApplication, FilePath); return false;
                    }
                    #endregion

                    #region Set Data
                    if (TempDataTable.Rows.Count != 0)
                        foreach (PatAdditionalColumn column in DBLayerIMS.Referrals.PatAddinColsList)
                            if (column.TypeID == 0 || column.TypeID == 2) // String Or Integer Data
                            {
                                String TheValue = String.Empty;
                                if (TempDataTable.Rows[0][column.FieldName] != null &&
                                    TempDataTable.Rows[0][column.FieldName] != DBNull.Value &&
                                    !String.IsNullOrEmpty(TempDataTable.Rows[0][column.FieldName].ToString()))
                                    TheValue = TempDataTable.Rows[0][column.FieldName].ToString();
                                ReplaceText(WSheet, "[PatField" + column.ID + "]", TheValue);
                            }
                            else if (column.TypeID == 1) // Boolean Data
                            {
                                Boolean TheValue = false;
                                if (TempDataTable.Rows[0][column.FieldName] != null &&
                                    TempDataTable.Rows[0][column.FieldName] != DBNull.Value &&
                                    Convert.ToBoolean(TempDataTable.Rows[0][column.FieldName]))
                                    TheValue = true;
                                if (TheValue) ReplaceText(WSheet, "[PatField" + column.ID + "]", "صحیح");
                                else ReplaceText(WSheet, "[PatField" + column.ID + "]", "غلط");
                            }
                            else if (column.TypeID == 3) // MultiChoice Data
                            {
                                String TheValue = String.Empty;
                                if (TempDataTable.Rows[0][column.FieldName] != null &&
                                    TempDataTable.Rows[0][column.FieldName] != DBNull.Value)
                                    TheValue = DBLayerIMS.Referrals.PatAddinDataItemsList.Where(Data => Data.ID ==
                                    Convert.ToInt16(TempDataTable.Rows[0][column.FieldName])).First().Title;
                                ReplaceText(WSheet, "[PatField" + column.ID + "]", TheValue);
                            }
                    #endregion
                }
            }
            #endregion

            #region Ref Data
            RefList RefData;
            try { RefData = _IMSDbLayer.RefLists.Where(Data => Data.ID == RefID).First(); }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان خواندن اطلاعات مراجعه بیمار از بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Bills Print Manager", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error); CloseExcelApp(ExcelApplication, FilePath); return false;
            }
            #endregion
            // بررسی آنكه آیا فرمولی برای اطلاعات پایه مراجعه در قبض استفاده شده است تا اطلاعات آن از خوانده شود
            if (FindExcelData(WSheet, "[RefID]") ||
                FindExcelData(WSheet, "[RefDate]") || FindExcelData(WSheet, "[RefTime]") ||
                FindExcelData(WSheet, "[RefPrescribeDate]") || FindExcelData(WSheet, "[RefWeight]") ||
                FindExcelData(WSheet, "[RefStatus]") || FindExcelData(WSheet, "[RefAdmitter]") ||
                FindExcelData(WSheet, "[RefPhysFullN]") || FindExcelData(WSheet, "[RefPrePayable]") ||
                FindExcelData(WSheet, "[Ins1Name]") || FindExcelData(WSheet, "[Ins1Code1]") ||
                FindExcelData(WSheet, "[Ins1Expire]") || FindExcelData(WSheet, "[Ins1PageNo]") ||
                FindExcelData(WSheet, "[Ins2Name]") || FindExcelData(WSheet, "[Ins2Code1]") ||
                FindExcelData(WSheet, "[Ins2Expire]"))
            {
                ReplaceText(WSheet, "[RefID]", RefData.ID.ToString());

                PersianDate RefDate = RefData.RegisterDate.ToPersianDate();
                String PersianRefDate = RefDate.Year + "/" + RefDate.Month + "/" + RefDate.Day;
                ReplaceText(WSheet, "[RefDate]", PersianRefDate);

                String RefTime = RefDate.Hour + ":" + RefDate.Minute + ":" + RefDate.Second;
                ReplaceText(WSheet, "[RefTime]", RefTime);

                if (RefData.PrescriptionDate == null) ReplaceText(WSheet, "[RefPrescribeDate]", String.Empty);
                else
                {
                    PersianDate DateFa = RefData.PrescriptionDate.Value.ToPersianDate();
                    String PrescriptionDateFaString = DateFa.Year + "/" + DateFa.Month + "/" + DateFa.Day;
                    ReplaceText(WSheet, "[RefPrescribeDate]", PrescriptionDateFaString);
                }

                if (RefData.ReportDate == null) ReplaceText(WSheet, "[RefReportDate]", String.Empty);
                else
                {
                    PersianDate DateFa = RefData.ReportDate.Value.ToPersianDate();
                    String FaString = DateFa.Year + "/" + DateFa.Month + "/" + DateFa.Day;
                    ReplaceText(WSheet, "[RefReportDate]", FaString);
                }

                if (RefData.Weight == null) ReplaceText(WSheet, "[RefWeight]", String.Empty);
                else ReplaceText(WSheet, "[RefWeight]", RefData.Weight.ToString());

                if (RefData.ReferStatusIX == null) ReplaceText(WSheet, "[RefStatus]", String.Empty);
                else
                {
                    String StatusTitle = DBLayerIMS.Referrals.RefStatusList.
                        Where(Data => Data.ID == RefData.ReferStatusIX).Select(Data => Data.Title).First();
                    ReplaceText(WSheet, "[RefStatus]", StatusTitle);
                }

                String UserFullName = Negar.DBLayerPMS.Security.UsersList.
                    Where(Data => Data.ID == RefData.AdmitterIX).Select(Data => Data.FullName).First();
                ReplaceText(WSheet, "[RefAdmitter]", UserFullName);

                #region [RefPhysFullN]
                // نام كامل پزشك درخواست كننده
                if (RefData.ReferPhysicianIX == null)
                    ReplaceText(WSheet, "[RefPhysFullN]", String.Empty);
                else
                {
                    RefPhysician RefPhysData;
                    try
                    {
                        RefPhysData = _PMSDbLayer.RefPhysicians.
                            Where(Data => Data.ID == RefData.ReferPhysicianIX.Value).First();
                    }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage = "امكان خواندن اطلاعات پزشك درخواست كننده مراجعه بیمار از بانك وجود ندارد.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Sepehr", "Bills Print Manager", Ex.Message + "\n" +
                            Ex.StackTrace, EventLogEntryType.Error); CloseExcelApp(ExcelApplication, FilePath); return false;
                    }
                    #endregion
                    String RefPhysFullN = RefPhysData.LastName;
                    if (!String.IsNullOrEmpty(RefPhysData.FirstName))
                        RefPhysFullN = RefPhysData.FirstName + " " + RefPhysFullN;
                    ReplaceText(WSheet, "[RefPhysFullN]", RefPhysFullN);
                }
                #endregion

                #region [RefPrePayable]
                if (RefData.PrePayable == null)
                    ReplaceText(WSheet, "[RefPrePayable]", String.Empty);
                else ReplaceText(WSheet, "[RefPrePayable]", RefData.PrePayable.ToString());
                #endregion

                #region @ Insurance Data @
                if (RefData.Ins1IX == null)
                {
                    ReplaceText(WSheet, "[Ins1Name]", "(بدون بیمه اول)");
                    ReplaceText(WSheet, "[Ins1Code1]", String.Empty);
                    ReplaceText(WSheet, "[Ins1Expire]", String.Empty);
                    ReplaceText(WSheet, "[Ins1PageNo]", String.Empty);
                    ReplaceText(WSheet, "[Ins2Name]", "(بدون بیمه دوم)");
                    ReplaceText(WSheet, "[Ins2Code1]", String.Empty);
                    ReplaceText(WSheet, "[Ins2Expire]", String.Empty);
                }
                else
                {
                    String Ins1Name = Negar.DBLayerPMS.ClinicData.InsNameList.
                        Where(Data => Data.ID == RefData.Ins1IX).Select(Data => Data.Name).First();
                    ReplaceText(WSheet, "[Ins1Name]", Ins1Name);
                    ReplaceText(WSheet, "[Ins1Code1]", RefData.Ins1Num1);
                    if (RefData.Ins1Validation == null) ReplaceText(WSheet, "[Ins1Expire]", String.Empty);
                    else
                    {
                        PersianDate Ins1ExDate = RefData.Ins1Validation.Value.ToPersianDate();
                        String PersianIns1ExDate = Ins1ExDate.Year + "/" + Ins1ExDate.Month + "/" + Ins1ExDate.Day;
                        ReplaceText(WSheet, "[Ins1Expire]", PersianIns1ExDate);
                    }
                    ReplaceText(WSheet, "[Ins1PageNo]", RefData.Ins1PageNum);
                    if (RefData.Ins2IX == null)
                    {
                        ReplaceText(WSheet, "[Ins2Name]", "(بدون بیمه دوم)");
                        ReplaceText(WSheet, "[Ins2Code1]", String.Empty);
                        ReplaceText(WSheet, "[Ins2Expire]", String.Empty);
                    }
                    else
                    {
                        String Ins2Name = Negar.DBLayerPMS.ClinicData.InsNameList.
                            Where(Data => Data.ID == RefData.Ins2IX).Select(Data => Data.Name).First();
                        ReplaceText(WSheet, "[Ins2Name]", Ins2Name);
                        ReplaceText(WSheet, "[Ins2Code1]", RefData.Ins2Num);
                        if (RefData.Ins2Validation == null) ReplaceText(WSheet, "[Ins2Expire]", String.Empty);
                        else
                        {
                            PersianDate Ins2ExDate = RefData.Ins2Validation.Value.ToPersianDate();
                            String PersianIns2ExDate = Ins2ExDate.Year + "/" + Ins2ExDate.Month + "/" + Ins2ExDate.Day;
                            ReplaceText(WSheet, "[Ins2Expire]", PersianIns2ExDate);
                        }
                    }
                }
                #endregion
            }
            #endregion

            #region Ref Addin Data
            if (DBLayerIMS.Referrals.RefAddinColsList.Count > 0)
            {
                // بررسی آنكه آیا فرمولی برای فیلد های اطلاعاتی پویا مراجعات در قبض استفاده شده است تا اطلاعات آن از بانك خوانده شود
                Boolean IsAnyAddinFieldExists = false;
                foreach (RefAdditionalColumn column in DBLayerIMS.Referrals.RefAddinColsList)
                    if (FindExcelData(WSheet, "[RefField" + column.ID + "]")) IsAnyAddinFieldExists = true;
                if (IsAnyAddinFieldExists)
                {
                    #region Read Data
                    DataTable TempDataTable = DBLayerIMS.Manager.
                        ExecuteQuery("EXEC [ImagingSystem].[Referrals].[SP_SelectRefAdditionalData] " + RefID, 10);
                    if (TempDataTable == null)
                    {
                        const String ErrorMessage = "امكان خواندن اطلاعات پویا مراجعات از بانك اطلاعات ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        CloseExcelApp(ExcelApplication, FilePath); return false;
                    }
                    #endregion

                    #region Set Data
                    if (TempDataTable.Rows.Count != 0)
                        foreach (RefAdditionalColumn column in DBLayerIMS.Referrals.RefAddinColsList)
                            if (column.TypeID == 0 || column.TypeID == 2) // String Or Integer Data
                            {
                                String TheValue = String.Empty;
                                if (TempDataTable.Rows[0][column.FieldName] != null &&
                                    TempDataTable.Rows[0][column.FieldName] != DBNull.Value &&
                                    !String.IsNullOrEmpty(TempDataTable.Rows[0][column.FieldName].ToString()))
                                    TheValue = TempDataTable.Rows[0][column.FieldName].ToString();
                                ReplaceText(WSheet, "[RefField" + column.ID + "]", TheValue);
                            }
                            else if (column.TypeID == 1) // Boolean Data
                            {
                                Boolean TheValue = false;
                                if (TempDataTable.Rows[0][column.FieldName] != null &&
                                    TempDataTable.Rows[0][column.FieldName] != DBNull.Value &&
                                    Convert.ToBoolean(TempDataTable.Rows[0][column.FieldName]))
                                    TheValue = true;
                                if (TheValue) ReplaceText(WSheet, "[RefField" + column.ID + "]", "صحیح");
                                else ReplaceText(WSheet, "[RefField" + column.ID + "]", "غلط");
                            }
                            else if (column.TypeID == 3) // MultiChoice Data
                            {
                                String TheValue = String.Empty;
                                if (TempDataTable.Rows[0][column.FieldName] != null &&
                                    TempDataTable.Rows[0][column.FieldName] != DBNull.Value)
                                    TheValue = DBLayerIMS.Referrals.PatAddinDataItemsList.Where(Data => Data.ID ==
                                    Convert.ToInt16(TempDataTable.Rows[0][column.FieldName])).First().Title;
                                ReplaceText(WSheet, "[RefField" + column.ID + "]", TheValue);
                            }
                    #endregion
                }
            }
            #endregion

            #region Ref Services Data
            List<RefService> RefServicesData;
            try
            {
                IQueryable<RefService> TempRefServices =
                    _IMSDbLayer.RefServices.Where(Data => Data.ReferralIX == RefID && Data.IsActive);
                RefServicesData = TempRefServices.ToList();
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان خواندن اطلاعات خدمات مراجعه بیمار از بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Bills Print Manager", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error); CloseExcelApp(ExcelApplication, FilePath); return false;
            }
            #endregion

            #region No Active Services Is Added
            if (RefServicesData.Count == 0)
            {
                for (Int16 i = 1; i <= 10; i++)
                {
                    ReplaceText(WSheet, "[Serv" + i + "Name]", String.Empty);
                    ReplaceText(WSheet, "[Serv" + i + "Code]", String.Empty);
                    ReplaceText(WSheet, "[Serv" + i + "Qty]", String.Empty);
                    ReplaceText(WSheet, "[Serv" + i + "CatName]", String.Empty);
                    ReplaceText(WSheet, "[Serv" + i + "Expert]", String.Empty);
                    ReplaceText(WSheet, "[Serv" + i + "Phys]", String.Empty);
                    ReplaceText(WSheet, "[Serv" + i + "FreePrice]", String.Empty);
                    ReplaceText(WSheet, "[Serv" + i + "GovPrice]", String.Empty);
                    ReplaceText(WSheet, "[Serv" + i + "Desc]", String.Empty);
                    ReplaceText(WSheet, "[Serv" + i + "Payable]", String.Empty);
                    ReplaceText(WSheet, "[Serv" + i + "Ins1Price]", String.Empty);
                    ReplaceText(WSheet, "[Serv" + i + "Ins1Part]", String.Empty);
                    ReplaceText(WSheet, "[Serv" + i + "Ins1PatPart]", String.Empty);
                    ReplaceText(WSheet, "[Serv" + i + "Ins2Price]", String.Empty);
                    ReplaceText(WSheet, "[Serv" + i + "Ins2Part]", String.Empty);
                    ReplaceText(WSheet, "[Serv" + i + "Ins2PatPart]", String.Empty);
                }
                ReplaceText(WSheet, "[ServPayableSum]", String.Empty);
                ReplaceText(WSheet, "[ServIns1PriceSum]", String.Empty);
                ReplaceText(WSheet, "[ServIns1PartSum]", String.Empty);
                ReplaceText(WSheet, "[ServIns1PatPartSum]", String.Empty);
                ReplaceText(WSheet, "[ServIns2PriceSum]", String.Empty);
                ReplaceText(WSheet, "[ServIns2PartSum]", String.Empty);
                ReplaceText(WSheet, "[ServIns2PatPartSum]", String.Empty);
                ReplaceText(WSheet, "[RefServQty]", String.Empty);
            }
            #endregion

            #region Some Services Is Available
            else
            {
                List<BillServCatExclude> ExcludedServiceCategories = _IMSDbLayer.BillServCatExcludes.ToList();
                if (ExcludedServiceCategories.Count != 0)
                {
                    foreach (BillServCatExclude exclude in ExcludedServiceCategories)
                        RefServicesData = RefServicesData.
                            Where(Data => Data.ServicesList.CategoryIX != exclude.CategoryIX).ToList();
                    RefServicesData = RefServicesData.OrderBy(Data => Data.ID).ToList();
                }
                for (Int32 i = 1; i <= 10; i++)
                {
                    if (RefServicesData.Count >= i)
                    {
                        SP_SelectServicesListResult ServiceData = DBLayerIMS.Services.ServicesList.
                            Where(Data => Data.ID == RefServicesData[i - 1].ServiceIX).First();
                        ReplaceText(WSheet, "[Serv" + i + "Name]", ServiceData.Name);
                        ReplaceText(WSheet, "[Serv" + i + "Code]", ServiceData.Code);
                        ReplaceText(WSheet, "[Serv" + i + "Qty]", RefServicesData[i - 1].Quantity.ToString());
                        ReplaceText(WSheet, "[Serv" + i + "CatName]", ServiceData.CategoryName);
                        String ExpertName = String.Empty;
                        if (RefServicesData[i - 1].ExpertIX != null)
                        {
                            ExpertName = DBLayerIMS.Referrals.RefServPerformers.
                                Where(Data => Data.ID == RefServicesData[i - 1].ExpertIX.Value).First().LastName;
                            if (!String.IsNullOrEmpty(DBLayerIMS.Referrals.RefServPerformers.
                                Where(Data => Data.ID == RefServicesData[i - 1].ExpertIX.Value).First().FirstName) &&
                                !String.IsNullOrEmpty(DBLayerIMS.Referrals.RefServPerformers.
                                Where(Data => Data.ID == RefServicesData[i - 1].ExpertIX.Value).First().FirstName.Trim()))
                                ExpertName = DBLayerIMS.Referrals.RefServPerformers.Where(Data => Data.ID == RefServicesData[i - 1].
                                    ExpertIX.Value).First().FirstName.Trim() + " " + ExpertName;
                        }
                        ReplaceText(WSheet, "[Serv" + i + "Expert]", ExpertName);
                        String PhysName = String.Empty;
                        if (RefServicesData[i - 1].PhysicianIX != null)
                        {
                            PhysName = DBLayerIMS.Referrals.RefServPerformers.
                                Where(Data => Data.ID == RefServicesData[i - 1].PhysicianIX.Value).First().LastName;
                            if (!String.IsNullOrEmpty(DBLayerIMS.Referrals.RefServPerformers.
                                Where(Data => Data.ID == RefServicesData[i - 1].PhysicianIX.Value).First().FirstName) &&
                                !String.IsNullOrEmpty(DBLayerIMS.Referrals.RefServPerformers.
                                Where(Data => Data.ID == RefServicesData[i - 1].PhysicianIX.Value).First().FirstName.Trim()))
                                PhysName = DBLayerIMS.Referrals.RefServPerformers.Where(Data => Data.ID == RefServicesData[i - 1].
                                    PhysicianIX.Value).First().FirstName.Trim() + " " + PhysName;
                        }
                        ReplaceText(WSheet, "[Serv" + i + "Phys]", PhysName);
                        ReplaceText(WSheet, "[Serv" + i + "FreePrice]", ServiceData.PriceFree.ToString());
                        ReplaceText(WSheet, "[Serv" + i + "GovPrice]", ServiceData.PriceGov.ToString());
                        ReplaceText(WSheet, "[Serv" + i + "Desc]", ServiceData.Description);
                        ReplaceText(WSheet, "[Serv" + i + "Payable]", RefServicesData[i - 1].PatientPayablePrice.ToString());
                        if (RefServicesData[i - 1].Ins1Price == null) ReplaceText(WSheet, "[Serv" + i + "Ins1Price]", String.Empty);
                        else ReplaceText(WSheet, "[Serv" + i + "Ins1Price]", RefServicesData[i - 1].Ins1Price.ToString());
                        if (RefServicesData[i - 1].Ins1PartPrice == null) ReplaceText(WSheet, "[Serv" + i + "Ins1Part]", String.Empty);
                        else ReplaceText(WSheet, "[Serv" + i + "Ins1Part]", RefServicesData[i - 1].Ins1PartPrice.ToString());
                        if (RefServicesData[i - 1].Ins1Price == null || RefServicesData[i - 1].Ins1PartPrice == null)
                            ReplaceText(WSheet, "[Serv" + i + "Ins1PatPart]", String.Empty);
                        else ReplaceText(WSheet, "[Serv" + i + "Ins1PatPart]",
                            (RefServicesData[i - 1].Ins1Price - RefServicesData[i - 1].Ins1PartPrice).ToString());
                        if (RefServicesData[i - 1].Ins2Price == null) ReplaceText(WSheet, "[Serv" + i + "Ins2Price]", String.Empty);
                        else ReplaceText(WSheet, "[Serv" + i + "Ins2Price]", RefServicesData[i - 1].Ins2Price.ToString());
                        if (RefServicesData[i - 1].Ins2PartPrice == null) ReplaceText(WSheet, "[Serv" + i + "Ins2Part]", String.Empty);
                        else ReplaceText(WSheet, "[Serv" + i + "Ins2Part]", RefServicesData[i - 1].Ins2PartPrice.ToString());
                        if (RefServicesData[i - 1].Ins2Price == null || RefServicesData[i - 1].Ins2PartPrice == null)
                            ReplaceText(WSheet, "[Serv" + i + "Ins2PatPart]", String.Empty);
                        else ReplaceText(WSheet, "[Serv" + i + "Ins2PatPart]",
                            (RefServicesData[i - 1].Ins2Price - RefServicesData[i - 1].Ins2PartPrice).ToString());
                    }
                    else
                    {
                        ReplaceText(WSheet, "[Serv" + i + "Name]", String.Empty);
                        ReplaceText(WSheet, "[Serv" + i + "Code]", String.Empty);
                        ReplaceText(WSheet, "[Serv" + i + "Qty]", String.Empty);
                        ReplaceText(WSheet, "[Serv" + i + "CatName]", String.Empty);
                        ReplaceText(WSheet, "[Serv" + i + "Expert]", String.Empty);
                        ReplaceText(WSheet, "[Serv" + i + "Phys]", String.Empty);
                        ReplaceText(WSheet, "[Serv" + i + "FreePrice]", String.Empty);
                        ReplaceText(WSheet, "[Serv" + i + "GovPrice]", String.Empty);
                        ReplaceText(WSheet, "[Serv" + i + "Desc]", String.Empty);
                        ReplaceText(WSheet, "[Serv" + i + "Payable]", String.Empty);
                        ReplaceText(WSheet, "[Serv" + i + "Ins1Price]", String.Empty);
                        ReplaceText(WSheet, "[Serv" + i + "Ins1Part]", String.Empty);
                        ReplaceText(WSheet, "[Serv" + i + "Ins1PatPart]", String.Empty);
                        ReplaceText(WSheet, "[Serv" + i + "Ins2Price]", String.Empty);
                        ReplaceText(WSheet, "[Serv" + i + "Ins2Part]", String.Empty);
                        ReplaceText(WSheet, "[Serv" + i + "Ins2PatPart]", String.Empty);
                    }
                }
                ReplaceText(WSheet, "[ServPayableSum]",
                    RefServicesData.Sum(Data => Data.PatientPayablePrice * Data.Quantity).ToString());
                ReplaceText(WSheet, "[ServIns1PriceSum]",
                    RefServicesData.Sum(Data => Data.Ins1Price * Data.Quantity).ToString());
                ReplaceText(WSheet, "[ServIns1PartSum]",
                    RefServicesData.Sum(Data => Data.Ins1PartPrice * Data.Quantity).ToString());
                ReplaceText(WSheet, "[ServIns1PatPartSum]",
                    (RefServicesData.Sum(Data => Data.Ins1Price) -
                    RefServicesData.Sum(Data => Data.Ins1PartPrice * Data.Quantity)).ToString());
                ReplaceText(WSheet, "[ServIns2PriceSum]",
                    RefServicesData.Sum(Data => Data.Ins2Price * Data.Quantity).ToString());
                ReplaceText(WSheet, "[ServIns2PartSum]",
                    RefServicesData.Sum(Data => Data.Ins2PartPrice * Data.Quantity).ToString());
                ReplaceText(WSheet, "[ServIns2PatPartSum]",
                    (RefServicesData.Sum(Data => Data.Ins2Price) -
                    RefServicesData.Sum(Data => Data.Ins2PartPrice * Data.Quantity)).ToString());
                if (RefServicesData[0].ServicesList.CategoryIX == null)
                    ReplaceText(WSheet, "[RefServQty]", String.Empty);
                else
                {
                    DateTime? CurrentDate;
                    if (RefData == null) CurrentDate = Negar.DBLayerPMS.Manager.ServerCurrentDateTime;
                    else CurrentDate = RefData.RegisterDate;
                    if (CurrentDate == null) CurrentDate = DateTime.Now;
                    String TodayDate = CurrentDate.Value.Year + "/" + CurrentDate.Value.Month + "/" + CurrentDate.Value.Day + " ";
                    String RefServQtyCommand = "SELECT ROW_NUMBER() OVER (ORDER BY [RefList].[RegisterDate]) AS [RANK] , " +
                        "[RefList].[ID] AS [RefID] FROM [ImagingSystem].[Referrals].[List] AS [RefList] " +
                        "WHERE [RefList].[RegisterDate] > '" + TodayDate + "00:00:00" + "' " +
                        "AND [RefList].[RegisterDate] < '" + TodayDate + "23:59:59" + "' " +
                        "AND (SELECT COUNT(*) FROM [ImagingSystem].[Referrals].[RefServices] AS [RefServ] " +
                        "INNER JOIN [ImagingSystem].[Services].[List] AS [ServList] " +
                        "ON [RefServ].[ServiceIX] = [ServList].[ID] " +
                        "WHERE [RefServ].[ReferralIX] = [RefList].[ID] AND " +
                        "[ServList].[CategoryIX] = " + RefServicesData[0].ServicesList.CategoryIX.Value + ") > 0 " +
                        "ORDER BY [RefList].[RegisterDate] ASC;";
                    DataTable Result = DBLayerIMS.Manager.ExecuteQuery(RefServQtyCommand, 5);
                    if (Result == null || Result.Rows.Count == 0 || Result.Rows[0][0] == null || Result.Rows[0][0] == DBNull.Value)
                        ReplaceText(WSheet, "[RefServQty]", String.Empty);
                    else
                    {
                        DataRow[] Data = Result.Select("RefID = " + RefID);
                        if (Data == null || Data.Length == 0) ReplaceText(WSheet, "[RefServQty]", String.Empty);
                        else ReplaceText(WSheet, "[RefServQty]", Data[0][0].ToString());
                    }
                }
            }
            #endregion

            #endregion

            #region Ref Costs Or Discounts
            List<RefCostsAndDiscount> RefCDData;
            try
            {
                RefCDData = _IMSDbLayer.RefCostsAndDiscounts.Where(Data => Data.ReferralIX == RefID).ToList();
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان خواندن تخفیف ها و هزینه های مراجعه بیمار از بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Bills Print Manager", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error); CloseExcelApp(ExcelApplication, FilePath); return false;
            }
            #endregion
            List<RefCostsAndDiscount> CostsData = RefCDData.Where(Data => Data.CostsAndDiscountsType.IsCost).ToList();
            if (CostsData.Count == 0)
                for (Int32 i = 1; i <= 10; i++)
                {
                    ReplaceText(WSheet, "[Cost" + i + "Name]", String.Empty);
                    ReplaceText(WSheet, "[Cost" + i + "Date]", String.Empty);
                    ReplaceText(WSheet, "[Cost" + i + "Value]", String.Empty);
                    ReplaceText(WSheet, "[Cost" + i + "Desc]", String.Empty);
                    ReplaceText(WSheet, "[Cost" + i + "DescBase]", String.Empty);
                }
            else
                for (Int32 i = 1; i <= 10; i++)
                {
                    if (CostsData.Count >= i)
                    {
                        ReplaceText(WSheet, "[Cost" + i + "Name]", CostsData[i - 1].CostsAndDiscountsType.Name);
                        PersianDate PDate = CostsData[i - 1].Date.ToPersianDate();
                        String PersianDate = PDate.Year + "/" + PDate.Month + "/" + PDate.Day;
                        ReplaceText(WSheet, "[Cost" + i + "Date]", PersianDate);
                        ReplaceText(WSheet, "[Cost" + i + "Value]", CostsData[i - 1].Value.ToString());
                        ReplaceText(WSheet, "[Cost" + i + "Desc]", CostsData[i - 1].Description);
                        ReplaceText(WSheet, "[Cost" + i + "DescBase]", CostsData[i - 1].CostsAndDiscountsType.Description);
                    }
                    else
                    {
                        ReplaceText(WSheet, "[Cost" + i + "Name]", String.Empty);
                        ReplaceText(WSheet, "[Cost" + i + "Date]", String.Empty);
                        ReplaceText(WSheet, "[Cost" + i + "Value]", String.Empty);
                        ReplaceText(WSheet, "[Cost" + i + "Desc]", String.Empty);
                        ReplaceText(WSheet, "[Cost" + i + "DescBase]", String.Empty);
                    }
                }
            List<RefCostsAndDiscount> DiscountsData =
                RefCDData.Where(Data => !Data.CostsAndDiscountsType.IsCost).ToList();
            if (DiscountsData.Count == 0)
                for (Int32 i = 1; i <= 10; i++)
                {
                    ReplaceText(WSheet, "[Discount" + i + "Name]", String.Empty);
                    ReplaceText(WSheet, "[Discount" + i + "Date]", String.Empty);
                    ReplaceText(WSheet, "[Discount" + i + "Value]", String.Empty);
                    ReplaceText(WSheet, "[Discount" + i + "Desc]", String.Empty);
                    ReplaceText(WSheet, "[Discount" + i + "DescBase]", String.Empty);
                }
            else
                for (Int32 i = 1; i <= 10; i++)
                {
                    if (DiscountsData.Count >= i)
                    {
                        ReplaceText(WSheet, "[Discount" + i + "Name]",
                                         DiscountsData[i - 1].CostsAndDiscountsType.Name);
                        PersianDate PDate = DiscountsData[i - 1].Date.ToPersianDate();
                        String PersianDate = PDate.Year + "/" + PDate.Month + "/" + PDate.Day;
                        ReplaceText(WSheet, "[Discount" + i + "Date]", PersianDate);
                        ReplaceText(WSheet, "[Discount" + i + "Value]", DiscountsData[i - 1].Value.ToString());
                        ReplaceText(WSheet, "[Discount" + i + "Desc]", DiscountsData[i - 1].Description);
                        ReplaceText(WSheet, "[Discount" + i + "DescBase]", DiscountsData[i - 1].CostsAndDiscountsType.Description);
                    }
                    else
                    {
                        ReplaceText(WSheet, "[Discount" + i + "Name]", String.Empty);
                        ReplaceText(WSheet, "[Discount" + i + "Date]", String.Empty);
                        ReplaceText(WSheet, "[Discount" + i + "Value]", String.Empty);
                        ReplaceText(WSheet, "[Discount" + i + "Desc]", String.Empty);
                        ReplaceText(WSheet, "[Discount" + i + "DescBase]", String.Empty);
                    }
                }
            ReplaceText(WSheet, "[RefDiscountsSum]", DiscountsData.Sum(Data => Data.Value).ToString());
            ReplaceText(WSheet, "[RefCostsSum]", CostsData.Sum(Data => Data.Value).ToString());
            ReplaceText(WSheet, "[RefCDBalance]", RefCDData.Sum(Data => Data.Value).ToString());
            #endregion

            #region Ref Transactions
            if (FindExcelData(WSheet, "[RefTotalRecieve]") || FindExcelData(WSheet, "[RefTotalPay]") ||
                FindExcelData(WSheet, "[RefTotalTransBalance]") || FindExcelData(WSheet, "[RefTotalPayable]") ||
                FindExcelData(WSheet, "[RefRemainValue]"))
                try
                {
                    Int32 SumRecieve = DBLayerIMS.Manager.DBML.FK_CalcSumRecieve(RefID).Value;
                    Int32 SumPay = DBLayerIMS.Manager.DBML.FK_CalcSumPay(RefID).Value;
                    ReplaceText(WSheet, "[RefTotalRecieve]", SumRecieve.ToString());
                    ReplaceText(WSheet, "[RefTotalPay]", Math.Abs(SumPay).ToString());
                    ReplaceText(WSheet, "[RefTotalTransBalance]", (SumRecieve + SumPay).ToString());
                    ReplaceText(WSheet, "[RefTotalPayable]", DBLayerIMS.Manager.DBML.
                        FK_CalcRefPayable(RefID).Value.ToString());
                    ReplaceText(WSheet, "[RefRemainValue]", DBLayerIMS.Manager.DBML.
                        FK_CalcTotalRefRemain(RefID).Value.ToString());
                }
                #region Catch
                catch (Exception Ex)
                {
                    const String ErrorMessage = "امكان خواندن اطلاعات دریافت ها و بازپرداخت های مراجعه بیمار از بانك وجود ندارد.\n" +
                        "موارد زیر را بررسی نمایید:\n" +
                        "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogManager.SaveLogEntry("Sepehr", "Bills Print Manager", Ex.Message + "\n" +
                        Ex.StackTrace, EventLogEntryType.Error); CloseExcelApp(ExcelApplication, FilePath); return false;
                }
                #endregion

            #endregion

            #endregion

            #region Protect And Save Changes
            // Protect Excel Document:
            ((Worksheet)ExcelApplication.Workbooks[1].Worksheets[1]).Protect("NegarPassword",
                true, true, true, true, true, true, true, true, true, true, true, true, true, true, true);
            // ذخیره سازی:
            ExcelApplication.Workbooks[1].Saved = true;
            #endregion

            #region Print Or Print Preview
            try
            {
                if (IsPrint)
                {
                    // ReSharper disable RedundantCast
                    ((_Workbook)ExcelApplication.ActiveWorkbook).Activate();
                    // ReSharper restore RedundantCast

                    // لیست پرینتر های نصب شده بر روی سیستم
                    List<String> InstalledPrinter = new List<String>();
                    foreach (String item in PrinterSettings.InstalledPrinters) InstalledPrinter.Add(item);
                    // شی پرینتر فعال برای ارسال به تابع پرینت اكسل
                    Object ActivePrinter;
                    // خواندن پرینتر پیش فرض به ازای كلید قالب قبوض
                    // در صورت عدم وجود متن خالی بازمی گرداند
                    String DefaultPrtFromReg = GetPrtNameFromReg(BillTemplateID.ToString());
                    // اگر كلیدی در رجیستری وجود نداشته باشد
                    if (String.IsNullOrEmpty(DefaultPrtFromReg))
                        ActivePrinter = Missing.Value;
                    // اگر وجود داشت
                    else
                    {
                        // و هم چنان این پرینتر نصب بود
                        if (InstalledPrinter.Any(Data => Data == DefaultPrtFromReg))
                            ActivePrinter =  DefaultPrtFromReg;
                        // اگر پرینتر پیش فرض پاك شده بود
                        else ActivePrinter = Missing.Value;
                    }
                    ((Worksheet)ExcelApplication.Workbooks[1].Worksheets[1]).PrintOut(Missing.Value, Missing.Value, CopyCount,
                        Missing.Value, ActivePrinter, Missing.Value, Missing.Value, Missing.Value);
                }
                else
                {
                    ExcelApplication.Visible = true;
                    // ReSharper disable RedundantCast
                    ((_Workbook)ExcelApplication.ActiveWorkbook).Activate();
                    // ReSharper restore RedundantCast
                    ((Worksheet)ExcelApplication.Workbooks[1].Worksheets[1]).PrintPreview(true);
                    ExcelApplication.Visible = false;
                }
            }
            // ReSharper disable EmptyGeneralCatchClause
            catch
            {
                CloseExcelApp(ExcelApplication, FilePath);
                return false;
            }
            // ReSharper restore EmptyGeneralCatchClause
            #endregion

            CloseExcelApp(ExcelApplication, FilePath);

            #region Insert Print Log
            BillsPrintLog NewPrintLog = new BillsPrintLog();
            NewPrintLog.BillIX = Convert.ToInt16(BillTemplateID);
            NewPrintLog.RefIX = RefID;
            NewPrintLog.UserIX = SecurityManager.CurrentUserID;
            NewPrintLog.PrintDate = DateTime.Now;
            _IMSDbLayer.BillsPrintLogs.InsertOnSubmit(NewPrintLog);
            try { _IMSDbLayer.SubmitChanges(); }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان ثبت چاپ شدن قبض جاری ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Bills Print Manager", Ex.Message + "\n" +
                       Ex.StackTrace, EventLogEntryType.Error); return false;
            }
            #endregion
            #endregion
            return true;
        }
        #endregion

        #region Boolean CheckUserPrintLimitation(Int16 BillID , Int32 RefID)
        /// <summary>
        /// تابع خواندن دسترسی داشتن كاربر جاری برای چاپ یك قبض برای یك مراجعه
        /// </summary>
        private static Boolean CheckUserPrintLimitation(Int16 BillID, Int32 RefID)
        {
            try
            {
                // بدست آوردن محدوده ی چاپ كاربر جاری
                DbLayer _IMSDbLayer = new DbLayer(CSManager.GetConnectionString("ImagingSystem", 30));
                IQueryable<BillsUserAccess> UserLimitationList = _IMSDbLayer.BillsUserAccesses.
                    Where(Data => Data.BillIX == BillID && Data.UserIX == SecurityManager.CurrentUserID);
                if (UserLimitationList.Count() == 0)
                    throw new Exception("كاربر انتخاب شده دسترسی برای چاپ قبض انتخاب شده را ندارد!");
                if (UserLimitationList.First().PrintLimitation != true) return true;
                Int16? BillPrintLimit = _IMSDbLayer.BillTemplates.
                    Where(Data => Data.ID == BillID).Select(Data => Data.PrintLimitation).First();
                if (BillPrintLimit == null) return true;
                // اگر تعداد چاپ مجاز كاربر برای قبض جاری نامحدود نباشد
                // بررسی می شوند كه چند بار از قبض جاری برای مراجعه جاری چاپ شده است
                IQueryable<BillsPrintLog> PrintListResult = _IMSDbLayer.BillsPrintLogs.
                    Where(Data => Data.RefIX == RefID && Data.BillIX == BillID);
                // اگر تعداد چاپ های انجام شده ، از تعداد چاپ های مجاز كاربر جاری بیشتر باشد ، اجازه چاپ داده نمی شود
                if (BillPrintLimit.Value <= PrintListResult.Count())
                {
                    PMBox.Show("قبض انتخاب شده ، به اندازه ی تعداد چاپ مجاز برای " +
                        "كاربر جاری چاپ یا پیش نمایش شده است!\n" +
                        "برای چاپ قبض بیشتر با مدیریت تماس بگیرید.", "محدودیت دسترسی!",
                        MessageBoxButtons.OK, MessageBoxIcon.Hand); return false;
                }
            }
            #region Catch
            catch (Exception Ex)
            {
                Cursor.Current = Cursors.Default;
                const String ErrorMessage = "امكان خواندن اطلاعات محدودیت چاپ كاربر جاری ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Bills Print Manager",
                    Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion
            return true;
        }
        #endregion

        #region Boolean ReadBillTemplateFile(Int16 BillID, String FilePath)
        /// <summary>
        /// تابع خواندن فایل قالب قبض
        /// </summary>
        private static Boolean ReadBillTemplateFile(Int16 BillID, String FilePath)
        {
            if (_UsedBillsBinaryList == null) _UsedBillsBinaryList = new Dictionary<Int16, Binary>();
            Binary TempData;
            if (_UsedBillsBinaryList.ContainsKey(BillID)) TempData = _UsedBillsBinaryList[BillID];
            else
                try
                {
                    DbLayer _IMSDbLayer = new DbLayer(CSManager.GetConnectionString("ImagingSystem", 30));
                    BillTemplate MyData = _IMSDbLayer.BillTemplates.Where(Data => Data.ID == BillID).First();
                    TempData = MyData.TemplateData;
                    _UsedBillsBinaryList.Add(BillID, TempData);
                }
                #region Catch
                catch (Exception Ex)
                {
                    Cursor.Current = Cursors.Default;
                    const String ErrorMessage =
                        "خواندن اطلاعات باینری قالب قبض انتخاب شده ممكن نیست.\n" +
                        "موارد زیر را بررسی نمایید:\n" +
                        "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogManager.SaveLogEntry("Sepehr", "Bills Print Manager", Ex.Message + "\n" +
                        Ex.StackTrace, EventLogEntryType.Error); return false;
                }
                #endregion
            if (File.Exists(FilePath)) File.Delete(FilePath);
            File.Create(FilePath).Close();
            if (TempData != null) File.WriteAllBytes(FilePath, TempData.ToArray());
            return true;
        }
        #endregion

        #region Boolean FindExcelData(_Worksheet worksheet, String ToSearch)
        /// <summary>
        /// تابع جستجوی یك مقدار در یك شیء اكسل
        /// </summary>
        /// <param name="worksheet">جدول اكسل</param>
        /// <param name="ToSearch">فرمول جستجو</param>
        private static Boolean FindExcelData(_Worksheet worksheet, String ToSearch)
        {
            if (worksheet.Cells.Find(ToSearch,
                Missing.Value, Missing.Value, Missing.Value, Missing.Value, XlSearchDirection.xlNext,
                Missing.Value, Missing.Value, Missing.Value) != null) return true;
            return false;
        }
        #endregion

        #region void ReplaceText(_Worksheet worksheet, String ToSearch, String ToReplace)
        /// <summary>
        /// تابع جایگذاری اطلاعات مراجعه داخل قالب قبض
        /// </summary>
        /// <param name="worksheet">جدول اكسل</param>
        /// <param name="ToSearch">فرمول جستجو</param>
        /// <param name="ToReplace">مقدار جانشانی</param>
        private static void ReplaceText(_Worksheet worksheet, String ToSearch, String ToReplace)
        {
            if (FindExcelData(worksheet, ToSearch))
                worksheet.Cells.Replace(ToSearch, ToReplace,
                    Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
        }
        #endregion

        #region void CloseExcelApp(_Application App, String TempFilPath)
        /// <summary>
        /// روالی برای بستن برنامه اكسل برای چاپ قبض
        /// </summary>
        private static void CloseExcelApp(_Application App, String TempFilPath)
        {
            if (App != null)
                try
                {
                    App.UserControl = false;
                    App.Workbooks[1].Close(false, Missing.Value, Missing.Value);
                    App.Quit();
                }
                #region Catch
                catch (Exception Ex)
                {
                    LogManager.SaveLogEntry("Sepehr", "Bills Print Manager", Ex.Message + "\n" +
                        Ex.StackTrace, EventLogEntryType.Error);
                }
                #endregion
            try { if (File.Exists(TempFilPath)) File.Delete(TempFilPath); }
            #region Catch
            catch (Exception Ex)
            {
                LogManager.SaveLogEntry("Sepehr", "Bills Print Manager", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error);
            }
            #endregion
            Cursor.Current = Cursors.Default;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("Fa-Ir");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("Fa-Ir");
        }
        #endregion

        #region String GetPrtNameFromReg(String BillTemplateID)
        /// <summary>
        /// تابع خواندن نام پرینتر پیش فرض به ازای كلید قالب قبض
        /// </summary>
        /// <returns>نام پرینتر پیش فرض</returns>
        /// <remarks>در صورت وجود خطا در نام پرینتر مقدار خالی باز گردانده می شود</remarks>
        private static String GetPrtNameFromReg(String BillTemplateID)
        {
            String ServerAndInstance = String.Empty;
            try
            {
                RegistryKey MyKey = Registry.CurrentUser.OpenSubKey(_SubKeyBillDefaultPrinter, true);
                if (MyKey == null) return ServerAndInstance;
                ServerAndInstance = MyKey.GetValue(BillTemplateID, String.Empty).ToString();
            }
            catch (Exception) { return ServerAndInstance; }
            return ServerAndInstance;
        }
        #endregion

        #endregion

    }
}