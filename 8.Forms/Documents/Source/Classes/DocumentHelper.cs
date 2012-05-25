#region using

using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Negar;
using Negar.DBLayerPMS.DataLayer;
using Negar.PersianCalendar.Utilities;
using Chilkat;
using Microsoft.Office.Interop.Word;
using Sepehr.DBLayerIMS.DataLayer;
using Application = System.Windows.Forms.Application;

#endregion

namespace Sepehr.Forms.Documents.Classes
{
    /// <summary>
    /// كلاسی برای انجام عملیات مشترك فرم مدیریت مدارك
    /// </summary>
    public static class DocumentHelper
    {

        #region Fields

        #region String_RefDocPath
        static readonly String _RefDocPath = Application.StartupPath + "\\RefDoc.Doc";
        #endregion

        #region static frmManageDocument _DocManager
        private static frmManageDocument _DocManager;
        #endregion

        #endregion

        #region Methods

        #region void AddNewDocument(Int32 RefID)
        /// <summary>
        /// روالی برای ثبت مدرك جدید برای مراجعه
        /// </summary>
        /// <param name="RefID">كلید مراجعه</param>
        public static void AddNewDocument(Int32 RefID)
        {
            if (_DocManager == null || _DocManager.IsDisposed) _DocManager = new frmManageDocument();
            if (_DocManager.IsDisposed) _DocManager = null;
            else if (_DocManager.Visible) PMBox.Show("مدرك دیگری در حال ویرایش می باشد!\n" + "ابتدا فرم مدرك مورد نظر را ببندید.",
                "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            else _DocManager.AddNewDocument(RefID);
        }
        #endregion

        #region void EditRefDocument(Int32 DocID)
        public static void EditRefDocument(Int32 DocID)
        {
            if (_DocManager == null || _DocManager.IsDisposed) _DocManager = new frmManageDocument();
            if (_DocManager.IsDisposed) _DocManager = null;
            else if (_DocManager.Visible) PMBox.Show("مدرك دیگری در حال ویرایش می باشد!\n" + "ابتدا فرم مدرك مورد نظر را ببندید.",
                "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            else _DocManager.EditRefDocument(DocID);
        }
        #endregion

        #region void ResetDocTemplateData()
        public static void ResetDocTemplateData()
        {
            if (_DocManager != null && !_DocManager.IsDisposed) _DocManager.FillDocTemplates();
        }
        #endregion

        #region void DisposeDocumentForm()
        /// <summary>
        /// روالی برای حذف فرم مدیریت كدرك از حافظه
        /// </summary>
        public static void DisposeDocumentForm()
        {
            try
            {
                if (_DocManager != null && !_DocManager.IsDisposed)
                {
                    _DocManager._TemplatesList = null;
                    _DocManager._IsFormHaveError = true;
                    _DocManager.Close();
                }
                _DocManager = null;
            }
            catch (Exception Ex)
            {
                LogManager.SaveLogEntry("Sepehr", "Documents Forms", Ex.Message + "\n" +
                  Ex.StackTrace, EventLogEntryType.Error);
            }
        }
        #endregion

        #region void ViewDocumentInWord(Int32 DocID)
        /// <summary>
        /// تابعی برای نمایش مدرك در آفیس به صورت خارجی
        /// </summary>
        public static void ViewDocumentInWord(Int32 DocID)
        {
            DialogResult Result = PMBox.Show("آیا مایلید متن مدرك مورد نظر را مشاهده نمایید؟", "پرسش؟",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (Result == DialogResult.No) return;
            String TempDocFilePath = Application.StartupPath + "\\TempDoc" +
                DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day +
                DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + ".";
            try
            {
                RefDocument DocData = DBLayerIMS.Manager.DBML.RefDocuments.Where(Data => Data.ID == DocID).First();
                if (File.Exists(TempDocFilePath + "Zip")) File.Delete(TempDocFilePath + "Zip");
                File.Create(TempDocFilePath + "Zip").Close();
                Binary ReportData = DBLayerIMS.Document.GetRefDocBinaryByDocID(DocData.ID);
                if (ReportData != null) File.WriteAllBytes(TempDocFilePath + "Zip", ReportData.ToArray());
                #region Unzip Document
                Zip ZipHelper = new Zip();
                ZipHelper.UnlockComponent("ZIP-TEAMBEAN_4F46F322914X");
                Boolean IsOpenedZipFile = ZipHelper.OpenZip(TempDocFilePath + "Zip");
                if (!IsOpenedZipFile) throw new Exception(ZipHelper.LastErrorText);
                if (File.Exists(_RefDocPath))
                {
                    File.SetAttributes(_RefDocPath, FileAttributes.Normal);
                    File.Delete(_RefDocPath);
                }
                Int32 FilesCount = ZipHelper.Unzip(Application.StartupPath);
                if (FilesCount == -1) throw new Exception(ZipHelper.LastErrorText);
                ZipHelper.CloseZip();
                ZipHelper.Dispose();
                if (File.Exists(TempDocFilePath + "Zip")) File.Delete(TempDocFilePath + "Zip");
                if (!File.Exists(_RefDocPath)) throw new Exception("فایل مدرك مورد نظر به درستی ذخیره نشده است.");
                File.SetAttributes(_RefDocPath, FileAttributes.Normal);
                File.Copy(_RefDocPath, TempDocFilePath + "Doc");
                File.Delete(_RefDocPath);
                #endregion

                File.Delete(TempDocFilePath + "Zip");
                Process.Start(TempDocFilePath + "Doc");
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان خواندن اطلاعات مدرك انتخاب شده از بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟\n" +
                    "2. آیا برنامه ورد به طور موازی باز نشده است؟\n" +
                    "3. كاربر ویندوز خود را یك بار Log Off كرده و سپس مجدداً وارد شوید.";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Documents Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return;
            }
            #endregion
        }
        #endregion

        // ===========================================

        #region public void PrintPatientsDocs(IEnumerable<Int32> PatListID, Boolean IsLast)
        /// <summary>
        /// تابعی برای چاپ تمام مدرك یك بیمار
        /// </summary>
        public static void PrintPatientsDocs(IEnumerable<Int32> PatListID, Boolean IsLast)
        {
            Thread MyThread = new Thread(() => PrintPatientsDocsAsync(PatListID, IsLast));
            MyThread.Start();
        }
        #endregion

        #region void PrintPatientsDocsAsync(IEnumerable<Int32> PatListID, Boolean IsLast)
        /// <summary>
        /// تابعی برای چاپ تمام مدرك یك بیمار
        /// </summary>
        private static void PrintPatientsDocsAsync(IEnumerable<Int32> PatListID, Boolean IsLast)
        {
            if (IsLast) foreach (Int32 PatID in PatListID) PrintPatLastDocumentAsync(PatID);
            else foreach (Int32 PatID in PatListID) PrintPatAllDocumentsAsync(PatID);
        }
        #endregion

        #region void PrintPatientsDocsAsync(Int32 PatListID)
        /// <summary>
        /// تابعی برای چاپ تمام مدرك یك بیمار
        /// </summary>
        private static void PrintPatLastDocumentAsync(Int32 PatListID)
        {
            Int32? LastDocID = DBLayerIMS.Referrals.GetPatFirstOrLastDocID(PatListID, true);
            if (LastDocID == null) return;
            PrintDocument(LastDocID.Value);
        }
        #endregion

        #region void PrintPatAllDocumentsAsync(Int32 PatListID)
        /// <summary>
        /// تابعی برای چاپ آخرین مدرك یك بیمار
        /// </summary>
        private static void PrintPatAllDocumentsAsync(Int32 PatListID)
        {
            List<Int32> PatRefList = DBLayerIMS.Referrals.GetPatRefIDListByPatID(PatListID);
            if (PatRefList == null) return;
            foreach (Int32 RefID in PatRefList)
            {
                List<Int32> DocIDList = DBLayerIMS.Document.GetRefDocIDListByRefID(RefID);
                if (DocIDList == null) return;
                foreach (Int32 DocID in DocIDList) PrintDocument(DocID);
            }
        }
        #endregion

        #region void PrintDocument(Int32 DocID)
        /// <summary>
        /// تابعی برای نمایش مدرك در آفیس به صورت خارجی
        /// </summary>
        public static void PrintDocument(Int32 DocID)
        {
            try
            {
                String TempDocFilePath = Application.StartupPath + "\\TempDoc" +
                    DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + ".";
                IQueryable<RefDocument> TempData =
                    DBLayerIMS.Manager.DBML.RefDocuments.Where(Data => Data.ID == DocID);
                DBLayerIMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, TempData);
                if (TempData.Count() == 0) return;
                RefDocument DocData = TempData.First();
                File.Create(TempDocFilePath + "Zip").Close();
                Binary ReportData = DBLayerIMS.Document.GetRefDocBinaryByDocID(DocData.ID);
                if (ReportData != null) File.WriteAllBytes(TempDocFilePath + "Zip", ReportData.ToArray());
                
                #region Unzip Document
                Zip ZipHelper = new Zip();
                ZipHelper.UnlockComponent("ZIP-TEAMBEAN_4F46F322914X");
                Boolean IsOpenedZipFile = ZipHelper.OpenZip(TempDocFilePath + "Zip");
                if (!IsOpenedZipFile) throw new Exception(ZipHelper.LastErrorText);
                Int32 FilesCount = ZipHelper.Unzip(Application.StartupPath);
                if (FilesCount == -1) throw new Exception(ZipHelper.LastErrorText);
                ZipHelper.CloseZip();
                ZipHelper.Dispose();
                if (File.Exists(TempDocFilePath + "Zip")) File.Delete(TempDocFilePath + "Zip");
                if (File.Exists("RefDoc.Doc")) File.Copy(Application.StartupPath + "\\RefDoc.Doc",
                    TempDocFilePath + "Doc");
                if (File.Exists("RefDoc.Doc")) File.Delete("RefDoc.Doc");
                #endregion

                Microsoft.Office.Interop.Word.Application WordApp = new Microsoft.Office.Interop.Word.Application();
                Object missing = System.Reflection.Missing.Value;
                Object BooleanFalse = false;
                Object FilePath = TempDocFilePath + "Doc";
                Document Doc = WordApp.Documents.Open(ref FilePath, ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing);
                Doc.Activate();
                WordApp.PrintOut(ref BooleanFalse, ref missing, ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing, ref BooleanFalse, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
                ((ApplicationClass)WordApp).Quit(ref missing, ref missing, ref missing);
                Thread.Sleep(1000);
                File.Delete(TempDocFilePath + "Zip");
                File.Delete(TempDocFilePath + "Doc");
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان خواندن اطلاعات مدرك انتخاب شده از بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Documents Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return;
            }
            #endregion
        }
        #endregion

        #region Boolean IsMessageTemplateReady()
        /// <summary>
        /// تابعی برای بررسی ثبت بودن امكان ارسال پیام كوتاه
        /// </summary>
        public static Boolean IsMessageTemplateReady()
        {
            try
            {
                UsersSetting SMSTextTemplate = null;
                for (Int16 i = 708; i < 713; i++)
                {
                    SMSTextTemplate = DBLayerIMS.Settings.ReadSetting(i, null);
                    if (SMSTextTemplate == null || String.IsNullOrEmpty(SMSTextTemplate.Value) ||
                        SMSTextTemplate.Boolean == null || SMSTextTemplate.Boolean == false) continue;
                    break;
                }
                if (SMSTextTemplate == null || String.IsNullOrEmpty(SMSTextTemplate.Value)) return false;
            }
            #region Catch
            catch (Exception Ex)
            {
                LogManager.SaveLogEntry("Sepehr", "Documents Forms", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error); return false;
            }
            #endregion
            return true;
        }
        #endregion

        #region Boolean SendMessageToPatient(Int32 RefID)
        /// <summary>
        /// تابعی برای ارسال پیام كوتاه به بیمار در مورد اتمام ریورت
        /// </summary>
        public static Boolean SendMessageToPatient(Int32 RefID)
        {
            try
            {
                UsersSetting SMSTextTemplate = null;
                for (Int16 i = 708; i < 713; i++)
                {
                    SMSTextTemplate = DBLayerIMS.Settings.ReadSetting(i, null);
                    if (SMSTextTemplate == null || String.IsNullOrEmpty(SMSTextTemplate.Value) ||
                        SMSTextTemplate.Boolean == null || SMSTextTemplate.Boolean == false) continue;
                    break;
                }
                if (SMSTextTemplate == null || String.IsNullOrEmpty(SMSTextTemplate.Value))
                {
                    PMBox.Show("قالبی برای ارسال پیام به بیماران تعریف نشده است!", "خطا!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
                }
                String MessageText = SMSTextTemplate.Value;
                RefList RefList = DBLayerIMS.Referrals.GetRefDataByID(RefID);
                PatList PatData = Negar.DBLayerPMS.Patients.GetPatFullDataByPatListID(RefList.PatientIX);
                if (PatData.PatDetail == null || String.IsNullOrEmpty(PatData.PatDetail.TelNo2))
                {
                    PMBox.Show("تلفن همراه بیمار انتخاب شده ثبت نشده است!", "خطا!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
                }
                if (MessageText.Contains("[CurrentDate]"))
                {
                    PersianDate PDate = DateTime.Now.ToPersianDate();
                    MessageText = MessageText.Replace("[CurrentDate]", PDate.Year + "/" + PDate.Month + "/" + PDate.Day);
                }
                if (MessageText.Contains("[CurrentTime]")) MessageText = MessageText.Replace("[CurrentTime]",
                    DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second);
                if (MessageText.Contains("[PatFullName]"))
                {
                    String FullName = String.Empty;
                    if (PatData.IsMale != null)
                    {
                        if (PatData.IsMale.Value) FullName = "جناب آقای ";
                        else FullName = "سركار خانم ";
                    }
                    if (!String.IsNullOrEmpty(PatData.FirstName)) FullName += PatData.FirstName + " ";
                    FullName += PatData.LastName;
                    MessageText = MessageText.Replace("[PatFullName]", FullName);
                }
                if (MessageText.Contains("[RefDate]"))
                {
                    PersianDate PDate = RefList.RegisterDate.ToPersianDate();
                    MessageText = MessageText.Replace("[RefDate]", PDate.Year + "/" + PDate.Month + "/" + PDate.Day);
                }
                Negar.DBLayerPMS.SMS.InsertNewSMS(String.Empty, PatData.PatDetail.TelNo2, MessageText, null, RefList.ID);
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان ارسال پبام كوتاه به بیمار ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Documents Forms", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error); return false;
            }
            #endregion
            return true;
        }
        #endregion

        #region void ExportDocument(List<Int32> PatList, String FolderPath)
        /// <summary>
        /// تابعی برای تولید خروجی از مدرك در آفیس
        /// </summary>
        public static void ExportDocument(List<Int32> PatList, String FolderPath)
        {
            for (Int32 i = 0; i < PatList.Count; i++)
            {
                List<Int32> refList = DBLayerIMS.Referrals.GetPatRefIDListByPatID(PatList[i]);
                for (Int32 j = 0; j < refList.Count; j++)
                {
                    List<Int32> docList = DBLayerIMS.Document.GetRefDocIDListByRefID(refList[j]);
                    for (int k = 0; k < docList.Count; k++)
                    {
                        Int32 docID = docList[k];
                        String TempDocFilePath = FolderPath + "\\" +
                            Negar.DBLayerPMS.Patients.GetPatientIDByPatListID(PatList[i]) + " - DocID" + docID + ".";
                        try
                        {
                            RefDocument DocData = DBLayerIMS.Manager.DBML.RefDocuments.Where(Data => Data.ID == docID).First();
                            if (File.Exists(TempDocFilePath + "Zip")) File.Delete(TempDocFilePath + "Zip");
                            File.Create(TempDocFilePath + "Zip").Close();
                            Binary ReportData = DBLayerIMS.Document.GetRefDocBinaryByDocID(DocData.ID);
                            if (ReportData != null) File.WriteAllBytes(TempDocFilePath + "Zip", ReportData.ToArray());
                            #region Unzip Document
                            Zip ZipHelper = new Zip();
                            ZipHelper.UnlockComponent("ZIP-TEAMBEAN_4F46F322914X");
                            Boolean IsOpenedZipFile = ZipHelper.OpenZip(TempDocFilePath + "Zip");
                            if (!IsOpenedZipFile) throw new Exception(ZipHelper.LastErrorText);
                            if (File.Exists(_RefDocPath))
                            {
                                File.SetAttributes(_RefDocPath, FileAttributes.Normal);
                                File.Delete(_RefDocPath);
                            }
                            Int32 FilesCount = ZipHelper.Unzip(Application.StartupPath);
                            if (FilesCount == -1) throw new Exception(ZipHelper.LastErrorText);
                            ZipHelper.CloseZip();
                            ZipHelper.Dispose();
                            if (File.Exists(TempDocFilePath + "Zip")) File.Delete(TempDocFilePath + "Zip");
                            if (!File.Exists(_RefDocPath)) throw new Exception("فایل مدرك مورد نظر به درستی ذخیره نشده است.");
                            File.SetAttributes(_RefDocPath, FileAttributes.Normal);
                            File.Copy(_RefDocPath, TempDocFilePath + "Doc");
                            File.Delete(_RefDocPath);
                            #endregion

                            File.Delete(TempDocFilePath + "Zip");
                        }
                        #region Catch
                        catch (Exception Ex)
                        {
                            const String ErrorMessage =
                                "امكان خواندن اطلاعات مدرك انتخاب شده از بانك اطلاعات ممكن نیست.\n" +
                                "موارد زیر را بررسی نمایید:\n" +
                                "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟\n" +
                                "2. آیا برنامه ورد به طور موازی باز نشده است؟\n" +
                                "3. كاربر ویندوز خود را یك بار Log Off كرده و سپس مجدداً وارد شوید.";
                            PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            LogManager.SaveLogEntry("Sepehr", "Documents Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                            return;
                        }
                        #endregion
                    }
                }
            }
            PMBox.Show("حروجی اطلاعات با موفقیت پایان یافت.", "پایان تولید جواب ها.");
        }
        #endregion

        #endregion

    }
}