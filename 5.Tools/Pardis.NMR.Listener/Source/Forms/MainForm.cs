#region using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Chilkat;
using Microsoft.Office.Interop.Word;
using Negar;
using Sepehr.DBLayerIMS.DataLayer;
using Application = System.Windows.Forms.Application;

#endregion

namespace Sepehr.Forms
{
    /// <summary>
    /// فرم مدیریت اطلاعات دیسكت
    /// </summary>
    internal partial class frmMainForm : Form
    {

        #region Fields

        #region DataTable _DataTableReadData
        /// <summary>
        /// انتخاب شده
        /// </summary>
        private DataTable _DataTableReadData;
        #endregion

        #region Object _Missing
        private Object _MissingValue = Missing.Value;
        #endregion

        #region String _AccessPath
        private String _AccessPath;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmMainForm()
        {
            InitializeComponent();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            Text += " - نسخه: " + Assembly.GetExecutingAssembly().GetName().Version;
            Activate();
            Focus();
            BringToFront();
        }
        #endregion

        #region btnSelectBankPath_Click
        private void btnSelectBankPath_Click(object sender, EventArgs e)
        {
            ofdAccess.FileName = txtBankPath.Text;
            DialogResult Result = ofdAccess.ShowDialog();
            if (Result != DialogResult.OK) return;
            txtBankPath.Text = ofdAccess.FileName;
        }
        #endregion

        #region btnLoadData_Click
        private void btnLoadData_Click(object sender, EventArgs e)
        {
            _AccessPath = txtBankPath.Text;
            OleDbCommand cm = null;
            try
            {
                OleDbConnection cn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;" +
                "Data Source=\"" + _AccessPath + "\"");
                cm = new OleDbCommand("Select * from T2star where HasTransfered = 0", cn);
                cm.Connection.Open();
                _DataTableReadData = new DataTable();
                _DataTableReadData.Load(cm.ExecuteReader());
                dgvData.DataSource = _DataTableReadData;
                dgvData.AutoResizeColumns();
            }
            #region catch
            catch (Exception Ex)
            {
                PMBox.Show("خطا در خواندن اطلاعات!", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Pardis Transfer", Ex.Message, EventLogEntryType.Error);
            }
            finally
            {
                if (cm != null) cm.Connection.Close();
            }
            #endregion
        }
        #endregion

        #region btnMakeReport_Click
        /// <summary>
        /// رویداد كلیك بر روی دكمه نمایش اطلاعات
        /// </summary>
        private void btnMakeReport_Click(object sender, EventArgs e)
        {
            #region User Data Validation
            if (_DataTableReadData == null)
            {
                PMBox.Show("اطلاعاتی برای ثبت خوانده نشده.", "خطا!");
                return;
            }
            #endregion
            btnRegister.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;
            pBar.Maximum = _DataTableReadData.Rows.Count;
            pBar.Value = 0;
            pBar.Text = "تعداد موارد: " + pBar.Maximum;
            BGWorkerSearchData.RunWorkerAsync();
        }
        #endregion

        #region BGWorkerSearchData_DoWork
        private void BGWorkerSearchData_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                ApplicationClass _CurrentWordApp = new ApplicationClass();
                for (Int32 i = 0; i < _DataTableReadData.Rows.Count; i++)
                {
                    // ردیف اطلاعاتی بیمار جاری در اكسس
                    DataRow accessRow = _DataTableReadData.Rows[i];
                    Int32? PatID = Negar.DBLayerPMS.Patients.
                        GetPatListIDByPatientID(accessRow["admission number"].ToString());
                    if (PatID == null) continue;
                    String strDate = accessRow["date"].ToString();
                    DateTime refDate = new DateTime(Convert.ToInt32(strDate.Substring(0, 4)),
                        Convert.ToInt32(strDate.Substring(4, 2)), Convert.ToInt32(strDate.Substring(6, 2)));
                    List<RefList> refList = DBLayerIMS.Manager.DBML.RefLists.
                        Where(data => data.PatientIX == PatID.Value &&
                            data.RegisterDate.Date == refDate.Date).ToList();
                    if (refList.Count == 0) continue;
                    for (Int32 j = 0; j < refList.Count; j++)
                    {
                        Int32 refServicesCount = DBLayerIMS.Manager.DBML.RefServices.
                            Where(data => data.ReferralIX == refList[j].ID &&
                                data.ServicesList.CategoryIX == 7).Count();
                        if (refServicesCount != 0)
                        {
                            // بیمار مورد نظر در پزشكی هسته ای پیدا شده. باید برای مراجعه بیمار مدرك جدیدی ثبت شود.
                            // ====================================
                            String docFilePath = Application.StartupPath + "\\Document" +
                                DateTime.Now.Hour + DateTime.Now.Minute +
                                DateTime.Now.Second + DateTime.Now.Millisecond + ".";
                            RefDocument currentDocumentData = new RefDocument();

                            // ثبت متنی كه باید در گزارش وارد شود

                            DocumentClass _WordDoc;
                            Object BooleanFalse = false;

                            #region Create Word
                            if (File.Exists(Application.StartupPath + "\\Template.Doc"))
                            {
                                File.Copy(Application.StartupPath + "\\Template.Doc", docFilePath + "Doc");
                                Object FilePath = docFilePath + "Doc";
                                _WordDoc = (DocumentClass)_CurrentWordApp.Documents.
                                    Open(ref FilePath, ref _MissingValue, ref _MissingValue, ref _MissingValue,
                                    ref _MissingValue, ref _MissingValue, ref _MissingValue, ref _MissingValue,
                                    ref _MissingValue, ref _MissingValue, ref _MissingValue, ref _MissingValue,
                                    ref _MissingValue, ref _MissingValue, ref _MissingValue, ref _MissingValue);

                                #region Replace Formula
                                Range Rng = _WordDoc.Range(ref _MissingValue, ref _MissingValue);
                                ReplaceDocFormula(Rng, "#Date#", accessRow["date"].ToString());
                                ReplaceDocFormula(Rng, "#PatID#", accessRow["admission number"].ToString());
                                ReplaceDocFormula(Rng, "#PatName#", accessRow["name"].ToString());
                                ReplaceDocFormula(Rng, "#BirthDate#", accessRow["date of birth"].ToString());
                                ReplaceDocFormula(Rng, "#Height#", accessRow["height"].ToString());
                                ReplaceDocFormula(Rng, "#Weight#", accessRow["weight"].ToString());
                                ReplaceDocFormula(Rng, "#Sex#", accessRow["Sex"].ToString());
                                ReplaceDocFormula(Rng, "#PhysName#", accessRow["clinician"].ToString());
                                ReplaceDocFormula(Rng, "#TechniqueName#", accessRow["Technique"].ToString());
                                ReplaceDocFormula(Rng, "#T2heart#", accessRow["T2heart"].ToString());
                                ReplaceDocFormula(Rng, "#T2liver#", accessRow["T2liver"].ToString());
                                ReplaceDocFormula(Rng, "#Loadingliver#", accessRow["loadingliver"].ToString());
                                ReplaceDocFormula(Rng, "#Conclusion1#", accessRow["conclusion1"].ToString());
                                ReplaceDocFormula(Rng, "#Conclusion2#", accessRow["conclusion2"].ToString());
                                ReplaceDocFormula(Rng, "#Comment#", accessRow["comment"].ToString());
                                #endregion
                            }
                            else
                            {
                                _WordDoc = new DocumentClass();
                                String InsertText = String.Empty;
                                for (Int32 k = 0; k < _DataTableReadData.Columns.Count; k++)
                                    InsertText += _DataTableReadData.Columns[k].Caption + ": " + accessRow[k] + "\n";
                                Range range = _WordDoc.Range(ref _MissingValue, ref _MissingValue);
                                range.Text = InsertText;
                            }
                            #endregion

                            #region Close Document
                            Object FileFormat = WdSaveFormat.wdFormatDocument;
                            Object EmptyTemplate = docFilePath + "Doc";
                            _WordDoc.SaveAs(ref EmptyTemplate, ref FileFormat,
                                    ref _MissingValue, ref _MissingValue, ref _MissingValue, ref _MissingValue, ref BooleanFalse,
                                    ref _MissingValue, ref _MissingValue, ref _MissingValue, ref _MissingValue, ref _MissingValue,
                                    ref _MissingValue, ref _MissingValue, ref _MissingValue, ref _MissingValue);
                            // ReSharper disable RedundantCast
                            _WordDoc.Close(ref BooleanFalse, ref _MissingValue, ref _MissingValue);
                            // ReSharper restore RedundantCast  
                            try { File.SetAttributes(docFilePath + "Doc", FileAttributes.Normal); }
                            catch { }
                            #endregion

                            #region Zip Document Data
                            try
                            {
                                if (File.Exists(docFilePath + "Zip")) File.Delete(docFilePath + "Zip");
                                Zip ZipHelper = new Zip();
                                ZipHelper.UnlockComponent("ZIP-TEAMBEAN_4F46F322914X");
                                // نام فایلی كه باید برای زیپ تولید شود
                                ZipHelper.NewZip(docFilePath + "Zip");
                                // فایل هایی كه باید به زیپ اضافه شوند اینجا تخصیص می باید
                                ZipHelper.AppendFiles(docFilePath + "Doc", true);
                                // نوشتن فایل زیپ
                                Boolean IsWritingDoCorrectly = ZipHelper.WriteZip();
                                if (!IsWritingDoCorrectly) throw new Exception(ZipHelper.LastErrorText);
                                // تغییر نام فایل افزوده شده به چت
                                ZipEntry MyZipEntry = ZipHelper.GetEntryByIndex(0);
                                MyZipEntry.FileName = "RefDoc.Doc";
                                IsWritingDoCorrectly = ZipHelper.WriteZipAndClose();
                                if (!IsWritingDoCorrectly) throw new Exception(ZipHelper.LastErrorText);
                                ZipHelper.Dispose();
                            }
                            #region Catch
                            catch (Exception Ex)
                            {
                                const String ErrorMessage = "امكان كوچك سازی فایل مدرك جاری ممكن نیست.\n" +
                                    "موارد زیر را بررسی نمایید:\n" +
                                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                LogManager.SaveLogEntry("Sepehr", "Documents Forms", Ex.Message + "\n" +
                                    Ex.StackTrace, EventLogEntryType.Error); continue;
                            }
                            #endregion
                            #endregion

                            #region Insert New Doc To Db
                            Binary BinaryData = File.ReadAllBytes(docFilePath + "Zip");
                            currentDocumentData.RefIX = refList[j].ID;
                            currentDocumentData.TypeIX = null;
                            currentDocumentData.Date = refDate;
                            currentDocumentData.IsReport = true;
                            currentDocumentData.TypistIX = 12;
                            //currentDocumentData.ReportData = BinaryData;
                            currentDocumentData.Extension = "doc"; 
                            DBLayerIMS.Manager.DBML.RefDocuments.InsertOnSubmit(currentDocumentData);
                            if (!DBLayerIMS.Manager.Submit())
                            {
                                const String ErrorMessage = "امكان ذخیره سازی فایل مدرك جاری ممكن نیست.\n" +
                                    "موارد زیر را بررسی نمایید:\n" +
                                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            currentDocumentData.DocPath = ((currentDocumentData.ID / 1000) + 1) + "\\" + currentDocumentData.ID + ".zip";
                            if (!DBLayerIMS.Manager.Submit())
                            {
                                const String ErrorMessage = "امكان ذخیره سازی فایل مدرك جاری ممكن نیست.\n" +
                                    "موارد زیر را بررسی نمایید:\n" +
                                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            #endregion

                            // ذخیره سازی فایل مدرك در پوشه ذخیره سازی مدارك
                            DBLayerIMS.Document.SetRefDocBinaryByDocID(currentDocumentData.ID, BinaryData);
                            try { if (File.Exists(docFilePath + "Zip")) File.Delete(docFilePath + "Zip"); }
                            catch { }
                            try { if (File.Exists(docFilePath + "doc")) File.Delete(docFilePath + "doc"); }
                            catch { }

                            OleDbCommand cm = null;
                            try
                            {
                                OleDbConnection cn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;" +
                                "Data Source=\"" + _AccessPath + "\"");
                                cm = new OleDbCommand("UPDATE T2star SET HasTransfered = 1 " +
                                    "WHERE [admission number] = '" + accessRow["admission number"] + "'", cn);
                                cm.Connection.Open();
                                cm.ExecuteNonQuery();
                            }
                            #region catch
                            catch (Exception Ex)
                            {
                                PMBox.Show("خطا در ثبت اطلاعات!", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                LogManager.SaveLogEntry("Sepehr", "Pardis Transfer", Ex.Message, EventLogEntryType.Error);
                            }
                            finally
                            {
                                if (cm != null) cm.Connection.Close();
                            }
                            #endregion
                        }
                    }
                    BGWorkerSearchData.ReportProgress(1);
                }
            }
            #region Catch
            catch (Exception Ex)
            {
                PMBox.Show("خطا در ثبت اطلاعات در بانك.", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Pardis Transfer", Ex.Message, EventLogEntryType.Error);
            }
            #endregion
        }
        #endregion

        #region BGWorkerSearchData_ProgressChanged
        private void BGWorkerSearchData_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pBar.Value += 1;
            pBar.Text = pBar.Value + " items from " + pBar.Maximum + " has transfered.";
        }
        #endregion

        #region BGWorkerSearchData_RunWorkerCompleted
        private void BGWorkerSearchData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Cursor.Current = Cursors.Default;
            btnRegister.Enabled = true;
            if (e.Cancelled) return;
        }
        #endregion

        #region Form Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            DialogResult Result = PMBox.Show("آیا مایلید از برنامه خارج شوید؟", "پرسش؟",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Result != DialogResult.Yes) { e.Cancel = true; return; }
            Dispose();
        }
        #endregion

        #endregion

        #region Methods

        #region void ReplaceDocFormula(Range Range, Object TextToFind, Object TextToReplace)
        /// <summary>
        /// تابعی برای جانشانی یك عبارت در یك مدرك ورد
        /// </summary>
        /// <param name="Range">محدوده فایل مورد نظر</param>
        /// <param name="TextToFind">متن اصلی</param>
        /// <param name="TextToReplace">متن جایگزین</param>
        private void ReplaceDocFormula(Range Range, Object TextToFind, Object TextToReplace)
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

        #endregion

    }
}