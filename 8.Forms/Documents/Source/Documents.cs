#region using

using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using Negar;
using Negar.DBLayerPMS.DataLayer;
using Negar.PersianCalendar.Utilities;
using Chilkat;
using Microsoft.Office.Interop.Word;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Forms.Documents.Classes;
using Application = Microsoft.Office.Interop.Word.Application;

#endregion

namespace Sepehr.Forms.Documents
{
    /// <summary>
    /// فرم مدیریت مدارك تصویربرداری بیمار
    /// </summary>
    public partial class frmDocuments : Form
    {

        #region Events & Delegates
        public delegate void DataChanged();
        public static event DataChanged DocumentDataChanged;
        #endregion

        #region Field & Properties

        #region Int32 _CurrentPatientListID
        /// <summary>
        /// كلید بیمار جاری
        /// </summary>
        private Int32 _CurrentPatientListID;
        #endregion

        #region Int32 _CurrentRefID
        /// <summary>
        /// كلید مراجعه  جاری
        /// </summary>
        private Int32 _CurrentRefID;
        #endregion

        #region PatList _CurrentPatientData
        /// <summary>
        /// فیلد اطلاعات بیمار جاری
        /// </summary>
        private PatList _CurrentPatientData;
        #endregion

        #region RefList _CurrentRefData
        /// <summary>
        /// اطلاعات مراجعه جاری
        /// </summary>
        private RefList _CurrentRefData;
        #endregion

        #region List<RefService> _RefServices
        private List<RefService> _RefServices;
        #endregion

        #region private Int32 CurrentPatientListID
        /// <summary>
        /// کد بیمارجاری فرم
        /// </summary>
        private Int32 CurrentPatientListID
        {
            set
            {
                if (!FillFormPatientDataByPatientListID(value))
                { _CurrentPatientListID = 0; return; }
                _CurrentPatientListID = value;
            }
        }
        #endregion

        #region private Int32 CurrentRefID
        /// <summary>
        /// کد مراجعه  جاری فرم
        /// </summary>
        private Int32 CurrentRefID
        {
            set
            {
                if (!FillFormRefDataByRefID(value)) { _CurrentRefID = 0; return; }
                _CurrentRefID = value;
            }
        }
        #endregion

        #region ACL Fields
        /// <summary>
        /// تعیین امكان ویرایش مدرك توسط كاربر
        /// </summary>
        private Boolean _CanEditDocument = true;
        /// <summary>
        /// دسترسی امكان ویرایش مدرك سایر كاربران
        /// </summary>
        private Boolean _CanDeleteOthersDocument = true;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده فرم 
        /// </summary>
        /// <param name="ID">كلید دریافتی</param>
        /// <param name="IsPatientID">كلید بیمار یا كلید مراجعه</param>
        public frmDocuments(Int32 ID, Boolean IsPatientID)
        {
            Cursor.Current = Cursors.WaitCursor;
            InitializeComponent();
            System.Windows.Forms.Application.CurrentInputLanguage =
                InputLanguage.FromCulture(new System.Globalization.CultureInfo("Fa-Ir"));
            dgvDocuments.AutoGenerateColumns = false;
            dgvRefServices.AutoGenerateColumns = false;
            if (Negar.DBLayerPMS.Security.UsersList == null) { Close(); return; }
            #region @ Check Security @
            if (SecurityManager.CurrentUserID > 2 && !ReadCurrentUserPermissions())
            { Cursor.Current = Cursors.Default; Close(); return; }
            // ReSharper disable DoNotCallOverridableMethodsInConstructor
            Text += " - كاربر جاری: " + Negar.DBLayerPMS.Security.UsersList.
                Where(Data => Data.ID == SecurityManager.CurrentUserID).Select(Data => Data.FullName).First();
            // ReSharper restore DoNotCallOverridableMethodsInConstructor
            #endregion

            #region ColExpert
            ColExpert.DataSource = DBLayerIMS.Referrals.RefServPerformers.ToList();
            ColExpert.DataPropertyName = "ExpertIX";
            ColExpert.DisplayMember = "FullName";
            ColExpert.ValueMember = "ID";
            #endregion

            #region ColPhysician
            ColPhysician.DataSource = DBLayerIMS.Referrals.RefServPerformers.ToList();
            ColPhysician.DataPropertyName = "PhysicianIX";
            ColPhysician.ValueMember = "ID";
            ColPhysician.DisplayMember = "FullName";
            #endregion

            #region PatientID Passed (IsPatientID = True)
            // اگر كلید بیمار ارسال شده باشد مدارك آخرین مراجعه ی بیمار نمایش داده می شود
            if (IsPatientID)
            {
                CurrentPatientListID = ID;
                if (_CurrentPatientListID == 0) { Close(); return; }
                Int32? PatientLastRefID = DBLayerIMS.Referrals.GetPatFirstOrLastRefID(_CurrentPatientListID, true);
                if (PatientLastRefID == null) { Cursor.Current = Cursors.Default; Close(); return; }
                CurrentRefID = Convert.ToInt32(PatientLastRefID);
                if (_CurrentRefID == 0) { Cursor.Current = Cursors.Default; Close(); return; }
            }
            #endregion

            #region RefID Passed (IsPatientID = False)
            // اگر كلید ارسالی ، كلید مراجعه باشد ، مراجعه ی مورد نظر نمایش داده می شود
            else
            {
                Int32? PatientListID = DBLayerIMS.Referrals.GetPatIDByRefID(ID);
                if (PatientListID == null) { Cursor.Current = Cursors.Default; Close(); return; }
                CurrentPatientListID = Convert.ToInt32(PatientListID);
                if (_CurrentPatientListID == 0) { Cursor.Current = Cursors.Default; Close(); return; }
                CurrentRefID = ID;
                if (_CurrentRefID == 0) { Cursor.Current = Cursors.Default; Close(); return; }
            }
            #endregion
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            Opacity = 1;
            Cursor.Current = Cursors.Default;
            DocumentDataChanged += frmDocuments_DocumentDataChanged;
        }
        #endregion

        #region frmDocuments_DocumentDataChanged
        void frmDocuments_DocumentDataChanged()
        {
            RefreshCurrentDoc();
        }
        #endregion

        #region @@@ Ribbon Event Handlers @@@

        #region btnClose_Click
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region btnPrevPatient_Click
        /// <summary>
        /// دكمه ی جابجایی بیمار جاری به بیمار قبلی
        /// </summary>
        private void btnPrevPatient_Click(object sender, EventArgs e)
        {
            Int32? PrevPatientListID = _CurrentPatientListID;
            while (true)
            {
                // بدست آوردن كد بیمار قبلی
                PrevPatientListID = Negar.DBLayerPMS.Patients.GetPrevOrNextPatID(PrevPatientListID.Value, false);
                // اگر بیمار قبلی وجود نداشت یا با بیمار جاری یكسان بود ، عملیات متوقف می شود
                if (PrevPatientListID == null || PrevPatientListID == _CurrentPatientListID) break;
                // ابتدا بررسی می شود كه بیمار جاری آخرین مراجعه دارد یا خیر
                Int32? PatientLastRefID = DBLayerIMS.Referrals.GetPatFirstOrLastRefID(PrevPatientListID.Value, true);
                // اگر آخرین مراجعه وجود داشت و با مراجعه ی فعلی متفاوت بود
                if (PatientLastRefID != null && PatientLastRefID != _CurrentRefID)
                {
                    // ابتدا بیمار جاری تغییر می كند
                    CurrentPatientListID = Convert.ToInt32(PrevPatientListID);
                    // شماره مراجعه ی جاری تغییر كرده و وضعیت فرم به نمایش تغییر می كند
                    CurrentRefID = Convert.ToInt32(PatientLastRefID);
                    break;
                }
                if (PrevPatientListID == Negar.DBLayerPMS.Patients.GetFirstOrLastPatientListID(false)) break;
            }
        }
        #endregion

        #region btnNextPatient_Click
        /// <summary>
        /// دكمه ی جابجایی بیمار جاری به بیمار بعدی
        /// </summary>
        private void btnNextPatient_Click(object sender, EventArgs e)
        {
            Int32? NextPatientListID = _CurrentPatientListID;
            while (true)
            {
                // بدست آوردن كد بیمار بعدی
                NextPatientListID = Negar.DBLayerPMS.Patients.GetPrevOrNextPatID(NextPatientListID.Value, true);
                // اگر بیمار بعدی وجود نداشت یا با بیمار جاری یكسان بود ، عملیات متوقف می شود
                if (NextPatientListID == null || NextPatientListID == _CurrentPatientListID) return;
                // ابتدا بررسی می شود كه بیمار جاری آخرین مراجعه دارد یا خیر
                Int32? PatientLastRefID = DBLayerIMS.Referrals.GetPatFirstOrLastRefID(NextPatientListID.Value, true);
                // اگر آخرین مراجعه وجود داشت و با مراجعه ی فعلی متفاوت بود
                if (PatientLastRefID != null && PatientLastRefID != _CurrentRefID)
                {
                    // ابتدا بیمار جاری تغییر می كند
                    CurrentPatientListID = Convert.ToInt32(NextPatientListID);
                    // شماره مراجعه ی جاری تغییر كرده و وضعیت فرم به نمایش تغییر می كند
                    CurrentRefID = Convert.ToInt32(PatientLastRefID);
                    break;
                }
                if (NextPatientListID == Negar.DBLayerPMS.Patients.GetFirstOrLastPatientListID(true)) break;
            }
        }
        #endregion

        #region btnPrevRef_Click
        /// <summary>
        /// دكمه ی جابجایی مراجعه ی بیمار جاری به مراجعه ی قبلی آن بیمار
        /// </summary>
        private void btnPrevRef_Click(object sender, EventArgs e)
        {
            // بدست آوردن كد مراجعه ی قبلی بیمار جاری
            Int32? PrevRefID = DBLayerIMS.Referrals.GetPatRefNextOrPrevRefID(_CurrentRefID, false);
            // اگر مراجعه ی قبلی وجود داشت و همچنین با مراجعه ی جاری متفاوت بود
            // مراجعه ی جاری تغییر می كند و در فرم نمایش داده می شود
            if (PrevRefID != null && PrevRefID != _CurrentRefID) CurrentRefID = Convert.ToInt32(PrevRefID);
        }
        #endregion

        #region btnNextRef_Click
        /// <summary>
        /// دكمه ی جابجایی مراجعه ی بیمار جاری به مراجعه ی بعدی آن بیمار
        /// </summary>
        private void btnNextRef_Click(object sender, EventArgs e)
        {
            // بدست آوردن كد مراجعه بعدی
            Int32? NextRefID = DBLayerIMS.Referrals.GetPatRefNextOrPrevRefID(_CurrentRefID, true);
            // اگر مراجعه بعدی وجود داشت و همچنین با مراجعه جاری متفاوت بود مراجعه جاری تغییر می كند
            if (NextRefID != null && NextRefID != _CurrentRefID) CurrentRefID = Convert.ToInt32(NextRefID);
        }
        #endregion

        #region btnNewDoc_Click
        /// <summary>
        /// فرم اضافه كردن مدرك جدید رانمایش می دهد
        /// </summary>
        private void btnNewDoc_Click(object sender, EventArgs e)
        {
            DocumentHelper.AddNewDocument(_CurrentRefID);
            if (!FillFormRefDataByRefID(_CurrentRefID)) { Close(); return; }
            BringToFront();
            Focus();
        }
        #endregion

        #region btnPrintDefaultDoc_Click
        /// <summary>
        /// فرمان چاپ قالب مدرك پیش فرض بدون نمایش آن
        /// </summary>
        private void btnPrintDefaultDoc_Click(object sender, EventArgs e)
        {
            #region Check User Permission
            if (SecurityManager.CurrentUserID > 2 && SecurityManager.GetCurrentUserPermission(5061) == false)
            {
                PMBox.Show("كاربر جاری دسترسی لازم برای ثبت مدرك برای بیمار را ندارد.", "محدودیت دسترسی!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            if (SecurityManager.CurrentUserID > 2 && SecurityManager.GetCurrentUserPermission(50611) == false)
            {
                try
                {
                    Int32 CurrentRefDocCount = DBLayerIMS.Manager.DBML.RefDocuments.
                        Where(Data => Data.RefIX == _CurrentRefID).Count();
                    if (CurrentRefDocCount > 0)
                    {
                        PMBox.Show("كاربر جاری دسترسی لازم برای ثبت بیش از 1 جواب برای بیمار را ندارد.",
                            "محدودیت دسترسی!", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                    }
                }
                #region Catch
                catch (Exception Ex)
                {
                    const String ErrorMessage = "امكان خواندن تعداد جواب های مراجعه جاری وجود ندارد.\n" +
                        "موارد زیر را بررسی نمایید:\n" +
                        "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogManager.SaveLogEntry("Sepehr", "Documents Forms", Ex.Message + "\n" + Ex.StackTrace,
                        EventLogEntryType.Error); return;
                }
                #endregion
            }
            #endregion

            #region Read Default Template
            List<SP_SelectTemplatesResult> TemplatesList = DBLayerIMS.Document.DocTemplatesList;
            if (TemplatesList == null) return;
            IEnumerable<SP_SelectTemplatesResult> DefaultTemplates = TemplatesList.Where(Data => Data.IsDefault == true);
            if (DefaultTemplates == null || DefaultTemplates.Count() == 0)
            {
                PMBox.Show("قالب پیش فرضی برای ثبت مدرك تعریف نشده است.", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            SP_SelectTemplatesResult DefaultTemplate = DefaultTemplates.First();
            #endregion

            #region Read Template Binary Data
            String DocFilePath;
            try
            {
                // خواندن فایل باینری فشرده شده ی قالب
                DocFilePath = System.Windows.Forms.Application.StartupPath + "\\Document" +
                DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + ".";
                // حذف فایل های مقصدی كه فرم بر اساس زمان سیستم تولید كرده در صورت وجود
                if (File.Exists(DocFilePath + "Doc")) File.Delete(DocFilePath + "Doc");
                // ایجاد فایل زیپ قالب مورد نظر به صورت خالی
                File.Create(DocFilePath + "Zip").Close();
                // ریختن اطلاعات باینری فایل فشرده شده ی قالب
                Binary BinaryData = DBLayerIMS.Document.GetDocTemplateBinaryData(DefaultTemplate.ID);
                if (BinaryData != null) File.WriteAllBytes(DocFilePath + "Zip", BinaryData.ToArray());
                #region Unzip Document
                Zip ZipHelper = new Zip();
                ZipHelper.UnlockComponent("ZIP-TEAMBEAN_4F46F322914X");
                Boolean IsOpenedZipFile = ZipHelper.OpenZip(DocFilePath + "Zip");
                if (!IsOpenedZipFile) throw new Exception(ZipHelper.LastErrorText);
                Int32 FilesCount = ZipHelper.Unzip(System.Windows.Forms.Application.StartupPath);
                if (FilesCount == -1) throw new Exception(ZipHelper.LastErrorText);
                ZipHelper.CloseZip();
                ZipHelper.Dispose();
                if (File.Exists(DocFilePath + "Zip")) File.Delete(DocFilePath + "Zip");
                if (File.Exists("RefDocTemplate.Doc"))
                    File.Copy(System.Windows.Forms.Application.StartupPath + "\\RefDocTemplate.Doc", DocFilePath + "Doc");
                if (File.Exists("RefDocTemplate.Doc")) File.Delete("RefDocTemplate.Doc");
                #endregion
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان خواندن اطلاعات قالب مدرك از بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Documents Forms", Ex.Message + "\n" + Ex.StackTrace,
                    EventLogEntryType.Error); return;
            }
            #endregion
            #endregion

            if (!OpenDocInWord(false, DocFilePath)) return;
            TopMost = true;
            Select();
            BringToFront();
            Focus();
            TopMost = false;
            RefreshCurrentDoc();
        }
        #endregion

        #region btnClipAndGrab_Click
        private void btnClipAndGrab_Click(object sender, EventArgs e)
        {
            Negar.Medical.VideoCapture.CaptureHelper.ShowCaptureClipForm(_CurrentRefID);
        }
        #endregion

        #region btnGrabber_Click
        private void btnGrabber_Click(object sender, EventArgs e)
        {
            Negar.Medical.VideoCapture.CaptureHelper.ShowCaptureForm(_CurrentRefID);
        }
        #endregion

        #region btnClip_Click
        private void btnClip_Click(object sender, EventArgs e)
        {
            Negar.Medical.VideoCapture.CaptureHelper.ShowClipForm(_CurrentRefID);
        }
        #endregion

        #region btnShowFiles_Click
        private void btnShowFiles_Click(object sender, EventArgs e)
        {
            String RefDataFolderPath = Negar.Medical.VideoCapture.CaptureHelper.GetRefDataFilesFolder(_CurrentRefID);
            if (!String.IsNullOrEmpty(RefDataFolderPath))
                Process.Start(RefDataFolderPath);
        }
        #endregion

        #region btnBurnCD_Click
        private void btnBurnCD_Click(object sender, EventArgs e)
        {
            new frmFileBurner(_CurrentRefID);
        }
        #endregion

        #endregion

        #region dgvRefServices_CellFormatting
        private void dgvRefServices_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == ColServiceName.Index)
                e.Value = DBLayerIMS.Services.ServicesList.Where(Data => Data.ID ==
                    ((RefService)dgvRefServices.Rows[e.RowIndex].DataBoundItem).ServiceIX).First().Name;
        }
        #endregion

        #region dgvDocuments_CellFormatting
        private void dgvDocuments_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex == ColRowNum.Index) e.Value = e.RowIndex + 1;
        }
        #endregion

        #region dgvDocuments_PreviewKeyDown
        private void dgvDocuments_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (dgvDocuments.Rows.Count == 0 || dgvDocuments.SelectedRows.Count == 0) return;
            if (e.KeyData == Keys.Enter) btnEditDoc_Click(null, null);
            else if (e.KeyData == Keys.Apps) dgvDocuments_CellMouseClick(1,
                new DataGridViewCellMouseEventArgs
                    (0, dgvDocuments.SelectedCells[0].RowIndex, Left + Width - 150,
                    Top + dgvDocuments.Top + dgvDocuments.ColumnHeadersHeight +
                    dgvDocuments.GetRowDisplayRectangle(dgvDocuments.SelectedCells[0].RowIndex, true).Top + 30,
                    new MouseEventArgs(System.Windows.Forms.MouseButtons.Right, 1, 1, 1, 1)));
        }
        #endregion

        #region dgvDocuments_CellMouseClick
        private void dgvDocuments_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (sender.GetType().Equals(typeof(Int32)) &&
                e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dgvDocuments.Rows[e.RowIndex].Selected = true;
                cmsdgvDocuments.PopupMenu(e.Location);
            }
            else if (e.Button == MouseButtons.Right && e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                dgvDocuments.Rows[e.RowIndex].Selected = true;
                cmsdgvDocuments.Popup(MousePosition);
            }
        }
        #endregion

        #region dgvDocuments_CellMouseDoubleClick
        /// <summary>
        /// اگر مدركی برای مراجعه موجود باشد نمایش می دهد
        /// </summary>
        private void dgvDocuments_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
                btnEditDoc_Click(null, null);
        }
        #endregion

        #region @@@ cmsdgvDocuments @@@

        #region btnEditDoc_Click
        private void btnEditDoc_Click(object sender, EventArgs e)
        {
            if (dgvDocuments.SelectedRows.Count == 0) return;
            if (!_CanEditDocument) return;
            DocumentHelper.EditRefDocument(((DBLayerIMS.RefDocData)dgvDocuments.SelectedRows[0].DataBoundItem).ID);
            if (!FillFormRefDataByRefID(_CurrentRefID)) { Close(); return; }
            BringToFront();
            Focus();
        }
        #endregion

        #region btnRemove_Click
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvDocuments.SelectedRows.Count == 0) return;
            Sepehr.DBLayerIMS.RefDocData DocData = ((DBLayerIMS.RefDocData)dgvDocuments.SelectedRows[0].DataBoundItem);
            if (!_CanDeleteOthersDocument && SecurityManager.CurrentUserID != DocData.TypistIX)
            {
                PMBox.Show("كاربر جاری امكان حذف مدارك ثبت شده توسط سایر كاربران را ندارد.", "محدودیت دسترسی!",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop); return;
            }
            DialogResult Dr = PMBox.Show("آیا مایلید مدرك انتخاب شده از پرونده بیمار حذف گردد؟\n" +
                "با حذف مدرك امكان بازگرداندن آن وجود ندارد.", "پرسش؟",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Dr != DialogResult.Yes) return;
            DBLayerIMS.Manager.DBML.RefDocuments.DeleteAllOnSubmit(
                DBLayerIMS.Manager.DBML.RefDocuments.Where(Data => Data.ID == DocData.ID));
            if (!DBLayerIMS.Manager.Submit())
            {
                const String ErrorMessage = "امكان حذف اطلاعات مدرك انتخاب شده از بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            Int32 LastIndex = dgvDocuments.SelectedRows[0].Index;
            CurrentRefID = _CurrentRefID;
            if (LastIndex != 0) dgvDocuments.Rows[LastIndex - 1].Selected = true;
        }
        #endregion

        #region btnEditInWord_Click
        private void btnEditInWord_Click(object sender, EventArgs e)
        {
            if (dgvDocuments.SelectedRows.Count == 0) return;
            DocumentHelper.ViewDocumentInWord(
                ((DBLayerIMS.RefDocData)dgvDocuments.SelectedRows[0].DataBoundItem).ID);
        }
        #endregion

        #region btnDocumentPreview_Click
        private void btnDocumentPreview_Click(object sender, EventArgs e)
        {
            if (dgvDocuments.SelectedRows.Count == 0) return;
            DialogResult Result = PMBox.Show("آیا مایلید متن مدرك مورد نظر را مشاهده نمایید؟", "پرسش؟",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (Result != DialogResult.Yes) return;
            String TempDocFilePath = System.Windows.Forms.Application.StartupPath + "\\TempDoc" +
                    DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + ".";
            try
            {
                RefDocument DocData = DBLayerIMS.Manager.DBML.RefDocuments.Where(Data => Data.ID ==
                    ((DBLayerIMS.RefDocData)dgvDocuments.SelectedRows[0].DataBoundItem).ID).First();
                File.Create(TempDocFilePath + "Zip").Close();
                Binary ReportData = DBLayerIMS.Document.GetRefDocBinaryByDocID(DocData.ID);
                if (ReportData != null) File.WriteAllBytes(TempDocFilePath + "Zip", ReportData.ToArray());
                #region Unzip Document
                Zip ZipHelper = new Zip();
                ZipHelper.UnlockComponent("ZIP-TEAMBEAN_4F46F322914X");
                Boolean IsOpenedZipFile = ZipHelper.OpenZip(TempDocFilePath + "Zip");
                if (!IsOpenedZipFile) throw new Exception(ZipHelper.LastErrorText);
                Int32 FilesCount = ZipHelper.Unzip(System.Windows.Forms.Application.StartupPath);
                if (FilesCount == -1) throw new Exception(ZipHelper.LastErrorText);
                ZipHelper.CloseZip();
                ZipHelper.Dispose();
                if (File.Exists(TempDocFilePath + "Zip")) File.Delete(TempDocFilePath + "Zip");
                if (File.Exists("RefDoc.Doc")) File.Copy(System.Windows.Forms.Application.StartupPath + "\\RefDoc.Doc",
                    TempDocFilePath + "Doc");
                if (File.Exists("RefDoc.Doc")) File.Delete("RefDoc.Doc");
                #endregion

                Application WordDoc = new Application();
                Object missing = Missing.Value;
                Object FilePath = TempDocFilePath + "Doc";
                WordDoc.Documents.Open(ref FilePath, ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing);
                WordDoc.PrintPreview = true;
                WordDoc.Visible = true;
                WordDoc.Activate();
                while (WordDoc.PrintPreview) Thread.Sleep(500);
                Object SaveOption = WdSaveOptions.wdDoNotSaveChanges;
                // ReSharper disable RedundantCast
                ((_Application)WordDoc).Quit(ref SaveOption, ref missing, ref missing);
                // ReSharper restore RedundantCast
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

            TopMost = true;
            Select();
            BringToFront();
            Focus();
            TopMost = false;
        }
        #endregion

        #region btnPrintDoc_Click
        private void btnPrintDoc_Click(object sender, EventArgs e)
        {
            if (dgvDocuments.SelectedRows.Count == 0) return;
            DialogResult Result = PMBox.Show("آیا مایلید متن مدرك مورد نظر را چاپ نمایید؟", "پرسش؟",
                 MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (Result == DialogResult.No) return;
            DocumentHelper.PrintDocument(((DBLayerIMS.RefDocData)dgvDocuments.SelectedRows[0].DataBoundItem).ID);
            BringToFront();
            Focus();
        }
        #endregion

        #endregion

        #endregion

        #region Methods

        #region Boolean ReadCurrentUserPermissions()
        /// <summary>
        /// تابع بررسی سطوح دسترسی فرم
        /// </summary>
        /// <returns>صحت خواندن اطلاعات</returns>
        private Boolean ReadCurrentUserPermissions()
        {
            // مدیریت مدارك مراجعات بیمار
            if (SecurityManager.GetCurrentUserPermission(506) == false)
            {
                PMBox.Show("كاربر جاری دسترسی لازم برای مشاهده مدارك مراجعات بیماران را ندارد!",
                    "محدودیت دسترسی!", MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
            }

            #region Add New Document - 5061
            // افزودن مدرك جدید برای مراجعه
            if (SecurityManager.GetCurrentUserPermission(5061) == false)
                ribbonBarOrders.Items.Remove(btnNewDoc);
            #endregion

            #region Edit Referral Document - 5062
            // ویرایش مدرك پس از ثبت مدرك مراجعه 
            if (SecurityManager.GetCurrentUserPermission(5062) == false)
            {
                cmsdgvDocuments.SubItems.Remove(btnEditDoc);
                _CanEditDocument = false;
            }
            #endregion

            #region Remove Referral Document - 5064
            // امكان حذف یك مدرك مراجعه
            if (SecurityManager.GetCurrentUserPermission(5064) == false)
                cmsdgvDocuments.SubItems.Remove(btnRemove);
            else if (SecurityManager.GetCurrentUserPermission(50641) == false)
                _CanDeleteOthersDocument = false;
            #endregion

            if (!LicenseHelper.GetSavedLicenses().Contains("555"))
                iContainerCaptureManager.Visible = false;

            return true;
        }
        #endregion

        #region Boolean FillFormPatientDataByPatientListID(Int32 PatientListID)
        /// <summary>
        /// پركردن اطلاعات بیمار ومراجعه فرم
        /// </summary>
        /// <param name="PatientListID">كلید مراجعه</param>
        /// <returns>صحت انجام</returns>
        private Boolean FillFormPatientDataByPatientListID(Int32 PatientListID)
        {
            _CurrentPatientData = Negar.DBLayerPMS.Patients.GetPatFullDataByPatListID(PatientListID);
            if (_CurrentPatientData == null) return false;
            if (String.IsNullOrEmpty(_CurrentPatientData.FirstName))
                lblPatientFullName.Text = _CurrentPatientData.LastName;
            else lblPatientFullName.Text = _CurrentPatientData.FirstName + " " + _CurrentPatientData.LastName;
            lblPatientID.Text = "شماره بیمار: " + _CurrentPatientData.PatientID;
            return true;
        }
        #endregion

        #region Boolean FillFormRefDataByRefID(Int32 RefID)
        /// <summary>
        /// تابع به روز رسانی اطلاعات مراجعه ی فرم بر اساس كلید مراجعه
        /// </summary>
        /// <param name="RefID">كلید مراجعه</param>
        /// <returns>صحت انجام كار</returns>
        private Boolean FillFormRefDataByRefID(Int32 RefID)
        {
            _CurrentRefData = DBLayerIMS.Referrals.GetRefDataByID(RefID);
            List<Sepehr.DBLayerIMS.RefDocData> DocData = DBLayerIMS.Document.GetRefDocsByRefID(RefID);
            if (_CurrentRefData == null || DocData == null) return false;
            dgvDocuments.DataSource = DocData;
            lblRefID.Text = "مراجعه:" + _CurrentRefData.ID;
            PersianDate FaRegDate = _CurrentRefData.RegisterDate.ToPersianDate();
            lblRefDate.Text = FaRegDate.Hour + ":" + FaRegDate.Minute + ":" + FaRegDate.Second + " - " +
                FaRegDate.Year + "/" + FaRegDate.Month + "/" + FaRegDate.Day;
            #region Fill Ref Services
            try
            {
                IOrderedQueryable<RefService> TempServices =
                    DBLayerIMS.Manager.DBML.RefServices.Where(Data => Data.ReferralIX == RefID &&
                    Data.IsActive).OrderBy(Data => Data.ID);
                DBLayerIMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, TempServices);
                _RefServices = TempServices.ToList();
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان خواندن اطلاعات خدمات مراجعه از بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Admission Forms", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion
            dgvRefServices.DataSource = _RefServices.Where(Data => Data.IsActive).ToList();
            #endregion
            return true;
        }
        #endregion

        #region @O@ Boolean OpenDocInWord(Boolean ShowDocument) @O@
        /// <summary>
        /// روالی برای باز كردن فایل آفیس مدرك در كنترل
        /// </summary>
        private Boolean OpenDocInWord(Boolean ShowDocument, String DocFilePath)
        {
            try
            {
                #region Generate Document
                Application CurrentWordApp = new ApplicationClass();
                CurrentWordApp.Visible = false;
                Object FilePath = DocFilePath + "Doc";
                Object _Missing = Missing.Value;
                DocumentClass CurrentWordDocument = (DocumentClass)CurrentWordApp.Documents.Open(ref FilePath, ref _Missing,
                    ref _Missing, ref _Missing, ref _Missing, ref _Missing, ref _Missing, ref _Missing, ref _Missing, ref _Missing,
                    ref _Missing, ref _Missing, ref _Missing, ref _Missing, ref _Missing, ref _Missing);
                CurrentWordApp.ShowWindowsInTaskbar = true;
                CurrentWordApp.WindowState = WdWindowState.wdWindowStateMaximize;
                CurrentWordApp.Visible = ShowDocument;
                if (ShowDocument)
                {
                    CurrentWordApp.ShowMe();
                    CurrentWordApp.Activate();
                    CurrentWordDocument.Activate();
                    CurrentWordDocument.Select();
                }
                #endregion

                #region Replace Formulas
                if (!DocTemplateFormulaManager.ReplaceDocFormulas(_CurrentRefID,
                    CurrentWordApp, CurrentWordDocument, ShowDocument))
                {
                    const String ErrorMessage = "امكان جانشانی فرمول های قالب مدرك ممكن نیست.\n" +
                        "موارد زیر را بررسی نمایید:\n" +
                        "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                CurrentWordApp.Visible = true;
                String[] PictureFileList = Negar.Medical.VideoCapture.CaptureHelper.GetRefDataFilesList(_CurrentRefID, "*.Jpg");
                for (Int32 i = 0; i <= 50; i++)
                {
                    Range Rng = CurrentWordDocument.Range(ref _Missing, ref _Missing);
                    // حالتی كه عكس موجود نیست - فرمول موجود است یا موجود نیست
                    if (PictureFileList.Length - 1 < i)
                    {
                        Object TextToFind = "NegarCapturePic" + (i + 1);
                        if (!DocTemplateFormulaManager.FindTextInWord(Rng, TextToFind)) break;
                        DocTemplateFormulaManager.ReplaceDocFormula(Rng, "NegarCapturePic" + (i + 1), String.Empty);
                    }
                    else // حالتی كه عكس موجود است
                    {
                        // بررسی وجود فایل عكس
                        if (!File.Exists(PictureFileList[i]))
                        {
                            DocTemplateFormulaManager.ReplaceDocFormula(Rng, "NegarCapturePic" + (i + 1), String.Empty);
                            continue;
                        }
                        Object TextToFind = "NegarCapturePic" + (i + 1);
                        // اگر فرمول موجود باشد
                        if (DocTemplateFormulaManager.FindTextInWord(Rng, TextToFind))
                        {
                            Rng = CurrentWordDocument.Range(ref _Missing, ref _Missing);
                            if (Rng.Find.Execute(ref TextToFind, ref _Missing, ref _Missing, ref _Missing, ref _Missing, ref _Missing,
                                ref _Missing, ref _Missing, ref _Missing, ref _Missing, ref _Missing,
                                ref _Missing, ref _Missing, ref _Missing, ref _Missing))
                            {
                                Object TempRange = Rng;
                                InlineShape NewPic = Rng.InlineShapes.AddPicture(PictureFileList[i], ref _Missing, ref _Missing, ref TempRange);
                                NewPic.Width = DocTemplateFormulaManager.CapturePicWidth;
                                NewPic.Height = DocTemplateFormulaManager.CapturePicHeight;
                            }
                            Rng = CurrentWordDocument.Range(ref _Missing, ref _Missing);
                            DocTemplateFormulaManager.ReplaceDocFormula(Rng, "NegarCapturePic" + (i + 1), String.Empty);
                        }
                        else break;
                    }
                }
                CurrentWordDocument.Save();
                CurrentWordApp.Visible = false;
                #endregion

                #region Print Document
                Object BooleanFalse = false;
                CurrentWordApp.PrintOut(ref BooleanFalse, ref _Missing, ref _Missing, ref _Missing, ref _Missing, ref _Missing,
                    ref _Missing, ref _Missing, ref _Missing, ref _Missing, ref BooleanFalse, ref _Missing, ref _Missing,
                    ref _Missing, ref _Missing, ref _Missing, ref _Missing, ref _Missing, ref _Missing);
                Thread.Sleep(1000);
                ((ApplicationClass)CurrentWordApp).Quit(ref _Missing, ref _Missing, ref _Missing);
                #endregion

                #region Zip Document Data
                try
                {
                    if (File.Exists(DocFilePath + "Zip")) File.Delete(DocFilePath + "Zip");
                    Zip ZipHelper = new Zip();
                    ZipHelper.UnlockComponent("ZIP-TEAMBEAN_4F46F322914X");
                    // نام فایلی كه باید برای زیپ تولید شود
                    ZipHelper.NewZip(DocFilePath + "Zip");
                    // فایل هایی كه باید به زیپ اضافه شوند اینجا تخصیص می باید
                    ZipHelper.AppendFiles(DocFilePath + "Doc", true);
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
                        Ex.StackTrace, EventLogEntryType.Error); return false;
                }
                #endregion
                #endregion

                #region Insert New Doc To Db
                Binary BinaryData = File.ReadAllBytes(DocFilePath + "Zip");
                RefDocument CurrentDoc = new RefDocument();
                CurrentDoc.RefIX = _CurrentRefID;
                CurrentDoc.TypeIX = null;
                CurrentDoc.Date = DateTime.Now;
                CurrentDoc.TypistIX = SecurityManager.CurrentUserID;
                DBLayerIMS.Manager.DBML.RefDocuments.InsertOnSubmit(CurrentDoc);
                if (!DBLayerIMS.Manager.Submit())
                {
                    const String ErrorMessage = "امكان ذخیره سازی فایل مدرك جاری ممكن نیست.\n" +
                        "موارد زیر را بررسی نمایید:\n" +
                        "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
                }
                DBLayerIMS.Document.SetRefDocBinaryByDocID(CurrentDoc.ID, BinaryData);
                if (File.Exists(DocFilePath + "Zip")) File.Delete(DocFilePath + "Zip");
                #endregion
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                "امكان باز كردن برنامه ورد مایكروسافت ممكن نیست.\n" +
                "موارد زیر را بررسی نمایید:\n" +
                "1. آیا این برنامه بر روی سیستم شما نصب می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Documents Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion
            return true;
        }
        #endregion

        #region private void RefreshCurrentDoc()
        private void RefreshCurrentDoc()
        {
            CurrentPatientListID = _CurrentPatientListID;
            CurrentRefID = _CurrentRefID;
        }
        #endregion

        #region public static void RefreshFormData()
        public static void RefreshFormData()
        {
            if (DocumentDataChanged != null) DocumentDataChanged();
        }
        #endregion

        #endregion

    }
}