#region using
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Aftab;
using Chilkat;
using DevComponents.DotNetBar;
using Microsoft.Office.Interop.Word;
using Sepehr.Settings.Documents;
using Sepehr.Settings.Documents.DataLayer;
using Sepehr.Settings.Documents.Properties;
using Application = System.Windows.Forms.Application;
using Template = Sepehr.Settings.Documents.DataLayer.Template;

#endregion

namespace Sepehr.Documents
{
    /// <summary>
    /// فرم مدیریت مدارك مراجعات بیماران
    /// </summary>
    internal partial class frmManageDocument : Form
    {

        #region Fields

        #region readonly DbClassIS _DbClassIS
        /// <summary>
        /// شی ء لایه داده ارتباط با بانك اطلاعات تصویربرداری
        /// </summary>
        private readonly DbClassIS _DbClassIS;
        #endregion

        #region ApplicationClass _CurrentWordApp
        /// <summary>
        /// شی از قالب برنامه ورد آفیس
        /// </summary>
        private ApplicationClass _CurrentWordApp;
        #endregion

        #region DocumentClass _CurrentWordDocument
        /// <summary>
        /// شی از اسناد باز شده ورد 
        /// </summary>
        private DocumentClass _CurrentWordDocument;
        #endregion

        #region Object _Missing
        /// <summary>
        /// 
        /// </summary>
        private Object _Missing = Missing.Value;
        #endregion

        #region String FormFilePath
        /// <summary>
        /// نام رشته فایل مدرك جاری
        /// </summary>
        public readonly Object FormFilePath = Application.StartupPath + "\\DocumentTemplate" +
               DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + ".";
        #endregion

        #region Boolean _HaveError
        /// <summary>
        /// تعیین رخ دادن خطا جهت بستن بدون پرسش فرم
        /// </summary>
        private Boolean _HaveError;
        #endregion

        #region readonly String_RefDocPath
        /// <summary>
        /// 
        /// </summary>
        private readonly String _RefDocPath = Application.StartupPath + "\\RefDocTemplate.Doc";
        #endregion

        #region Int16? _CurrentTemplateID
        /// <summary>
        /// نگهدارنده شناسه قالب
        /// </summary>
        private Int16? _CurrentTemplateID;
        #endregion

        #region Boolean _SaveManually
        /// <summary>
        /// اگر كاربر به صورت دستی متن را ذخیره كرده باشد مقدار صحیح دارد
        /// </summary>
        private Boolean _SaveManually;
        #endregion

        #region readonly Boolean _IsAdding
        /// <summary>
        /// مجزا كننده فراخوانی فرم 
        /// </summary>
        private readonly Boolean _IsAdding;
        #endregion

        #region Template _CurrentDocumentData
        private Template _CurrentDocumentData;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmManageDocument(Int16? CurrentTemplateID)
        {
            //اگر فرم در حال ویرایش فراخوانی شده بود
            if (CurrentTemplateID != null)
            {
                _CurrentTemplateID = CurrentTemplateID;
                _IsAdding = false;
            }
            //اگر فرم در حال افزودن فراخوانی شده بود
            else _IsAdding = true;
            Cursor.Current = Cursors.WaitCursor;
            InitializeComponent();
            _DbClassIS = new DbClassIS(CSManager.GetCSFromSavedData("ImagingSystem"));
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            Object FilePath = FormFilePath + "Doc";
            Opacity = 0.1;
            #region Adding State
            //حالت افزودن 
            if (_IsAdding)
            {
                try
                {
                    // اگر فایل قالب پیش فرض موجود باشد ، یك فایل خالی از آن ایجاد میشود
                    if (File.Exists("EmptyTemplate.Doc"))
                    {
                        File.SetAttributes("EmptyTemplate.Doc", FileAttributes.Normal);
                        File.Copy("EmptyTemplate.Doc", FilePath.ToString());
                        File.SetAttributes(FilePath.ToString(), FileAttributes.Normal);
                    }
                    // اگر فایل پیش فرض وجود نداشته باشد یك فایل خالی ساخته می شود
                    #region Create Empty File
                    else
                    {
                        File.Create("EmptyTemplate.Doc").Close();
                        File.Create(FilePath.ToString()).Close();
                    }
                    #endregion
                }
                #region Catch
                catch (Exception Ex)
                {
                    const String ErrorMessage =
                        "امكان باز كردن نرم افزار وُرد مایكروسافت ممكن نیست.\n" +
                        "موارد زیر را بررسی نمایید:\n" +
                        "1. آیا نرم افزار وُرد مایكروسافت نصب شده است؟";
                    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogManager.SaveLogEntry(Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                    Close(); return;
                }
                #endregion
                txtTemplateCode.ValueObject = null;
                if (!OpenDocument(FilePath)) { _HaveError = true; Close(); return; }
            }
            #endregion

            #region Editing State
            // خواندن مدرك آماده شده - جدید یا ذخیره شده - در آفیس
            else if (!FillFormBaseDataSources(_CurrentTemplateID.Value) || !LoadDocData(_CurrentTemplateID.Value) ||
                !OpenDocument(FilePath)) { _HaveError = true; Close(); return; }
            #endregion
            Cursor.Current = Cursors.Default;
            Opacity = 1;
        }
        #endregion

        #region btnSave_Click
        /// <summary>
        /// دكمه ذخیره سازی فرم مدرك
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                #region Validate Form Data
                if (String.IsNullOrEmpty(txtName.Text.Trim()))
                {
                    PMBox.Show("برای قالب حتماً نامی انتخاب نمایید!", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtName.Focus();
                    return;
                }
                if (txtTemplateCode.ValueObject != null)
                {
                    List<Template> SelectedCode;
                    if (_CurrentTemplateID == null) SelectedCode =
                        _DbClassIS.Templates.Where(Data => Data.Code == Convert.ToInt16(txtTemplateCode.Value)).ToList();
                    else SelectedCode =
                        _DbClassIS.Templates.Where(Data => Data.ID != _CurrentTemplateID.Value &&
                            Data.Code == Convert.ToInt16(txtTemplateCode.Value)).ToList();
                    if (SelectedCode.Count != 0)
                    {
                        PMBox.Show("كد وارد شده برای قالب جاری قبلاً برای قالب دیگری انتخاب شده است!\n" +
                        "كد دیگری برای قالب جاری انتخاب نمایید!", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtTemplateCode.Focus();
                        return;
                    }
                }
                #endregion
                if (!SaveDocument()) { return; }
                #region Zip Document Data
                Zip ZipHelper = new Zip();
                ZipHelper.UnlockComponent("ZIP-TEAMBEAN_4F46F322914X");
                // نام فایلی كه باید برای زیپ تولید شود
                ZipHelper.NewZip(FormFilePath + "Zip");
                // فایل هایی كه باید به زیپ اضافه شوند اینجا تخصیص می باید
                ZipHelper.AppendFiles(FormFilePath + "Doc", true);
                // Write Zip File
                Boolean IsWritingDoCorrectly = ZipHelper.WriteZip();
                if (!IsWritingDoCorrectly) throw new Exception(ZipHelper.LastErrorText);
                // تغییر نام فایل افزوده شده به چت
                ZipEntry MyZipEntry = ZipHelper.GetEntryByIndex(0);
                MyZipEntry.FileName = "RefDocTemplate.Doc";
                IsWritingDoCorrectly = ZipHelper.WriteZipAndClose();
                if (!IsWritingDoCorrectly) throw new Exception(ZipHelper.LastErrorText);
                ZipHelper.CloseZip();
                ZipHelper.Dispose();
                if (File.Exists(FormFilePath + "Doc")) File.Delete(FormFilePath + "Doc");
                #endregion
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان باز كردن نرم افزار وُرد مایكروسافت ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا برنامه وُرد نصب شده است؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry(Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                DialogResult = DialogResult.Cancel;
                return;
            }
            #endregion
            _SaveManually = true;
            Close();
        }
        #endregion

        #region btnPrint_Click
        private void btnPrint_Click(object sender, EventArgs e)
        {
            _CurrentWordDocument.PrintOut(ref _Missing, ref _Missing, ref _Missing, ref _Missing, ref _Missing,
                ref _Missing, ref _Missing, ref _Missing, ref _Missing, ref _Missing, ref _Missing, ref _Missing,
                ref _Missing, ref _Missing, ref _Missing, ref _Missing, ref _Missing, ref _Missing);
        }
        #endregion

        #region btnImport_Click
        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog.Filter = "فایل ورد (*.doc)|*.doc";
            DialogResult Result = OpenFileDialog.ShowDialog();
            if (Result != DialogResult.OK) return;
            OpenDocument(OpenFileDialog.FileName);
        }
        #endregion

        #region btnAddinFieldsList_Click
        private void btnAddinFieldsList_Click(object sender, EventArgs e)
        {
            new frmAddinFieldsList();
        }
        #endregion

        #region btnClose_Click
        /// <summary>
        ///دكمه بستن فرم
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region btnHelp_Click
        /// <summary>
        /// روال نمایش راهنمایی برای فرم
        /// </summary>
        private void btnHelp_Click(object sender, EventArgs e)
        {
            SetControlsToolTipTexts();
        }
        #endregion

        #region Form_Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            #region Check For Exit Without Save
            if (!_HaveError)
            {
                if (!_SaveManually)
                {
                    DialogResult Dr = PMBox.Show("آیا مایلید مدرك جاری را پیش از ترك فرم ذخیره نمایید؟",
                   "پرسش؟", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (Dr == DialogResult.Yes)
                    {
                        btnSave_Click(null, null);
                    }
                    else if (Dr == DialogResult.No) { e.Cancel = true; }
                }
                DialogResult = DialogResult.OK;
            }
            #endregion

            Opacity = 0.01;
            Cursor = Cursors.WaitCursor;

            #region Close Word Application Process
            if (_CurrentWordApp != null)
            {
                try
                {
                    _CurrentWordApp.Quit(ref _Missing, ref _Missing, ref _Missing);
                    _CurrentWordApp = null;
                }
                catch (Exception) { }
            }
            #endregion

            #region Dispose Form When Error Raised
            if (_HaveError)
            {
                Dispose();
                GC.Collect();
                _HaveError = false;
            }
            #endregion

            Cursor = Cursors.Default;
        }
        #endregion

        #endregion

        #region Method

        #region void SetControlsToolTipTexts()
        /// <summary>
        /// تابع تنظیم متن راهنمای كنترل ها
        /// </summary>
        private void SetControlsToolTipTexts()
        {
            const String TooltipHeader = "راهنمای تنظیمات سیستم";
            const String TooltipFooter = "سیستم مدیریت تصویربرداری سپهر";

            #region btnClose
            String TooltipText = ToolTipManager.GetText("btnClose", "IMS");
            FormToolTip.SetSuperTooltip(btnClose, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnHelp
            TooltipText = ToolTipManager.GetText("btnHelp", "IMS");
            FormToolTip.SetSuperTooltip(btnHelp, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnSave
            TooltipText = ToolTipManager.GetText("btnDocSave", "IMS");
            FormToolTip.SetSuperTooltip(btnSave, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

        }
        #endregion

        #region Boolean OpenDocument()
        /// <summary>
        /// روالی برای باز كردن فایل آفیس مدرك در كنترل
        /// </summary>
        private bool OpenDocument(Object FilePath)
        {
            #region Close Current Word Application Object
            if (_CurrentWordApp != null)
            {
                try { _CurrentWordApp.Quit(ref _Missing, ref _Missing, ref _Missing); }
                catch (Exception) { }
                _CurrentWordApp = null;
            }
            #endregion

            try { _CurrentWordApp = new ApplicationClass(); }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                "امكان باز كردن برنامه ورد مایكروسافت ممكن نیست.\n" +
                "موارد زیر را بررسی نمایید:\n" +
                "1. آیا این برنامه بر روی سیستم شما نصب می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry(Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                _HaveError = true;
                return false;
            }
            #endregion

            #region Close Current Word Object
            if (_CurrentWordDocument != null)
            {
                try { _CurrentWordDocument.Close(ref _Missing, ref _Missing, ref _Missing); }
                catch (Exception) { }
                _CurrentWordDocument = null;
            }
            #endregion

            try
            {
                _CurrentWordDocument = (DocumentClass)_CurrentWordApp.Documents.Open(ref FilePath, ref _Missing,
                    ref _Missing, ref _Missing, ref _Missing, ref _Missing, ref _Missing, ref _Missing, ref _Missing, ref _Missing,
                    ref _Missing, ref _Missing, ref _Missing, ref _Missing, ref _Missing, ref _Missing);
                _CurrentWordApp.Visible = true;
                _CurrentWordApp.WindowState = WdWindowState.wdWindowStateMaximize;
                _CurrentWordApp.Activate();
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                "امكان خواندن اطلاعات نرم افزار ورد مایكروسافت ممكن نیست.\n" +
                "موارد زیر را بررسی نمایید:\n" +
                "1. آیا این برنامه بر روی سیستم شما نصب می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry(Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                _HaveError = true;
                return false;
            }
            #endregion
            return true;
        }
        #endregion

        #region Boolean LoadDocData(Int32 DocumentID)
        /// <summary>
        /// تابع خواندن اطلاعات و فایل مدرك در ویرایشگر
        /// </summary>
        /// <param name="TemplateID">كلید مدرك</param>
        /// <returns>صحت انجام كار</returns>
        private Boolean LoadDocData(Int32 TemplateID)
        {
            try
            {
                _CurrentDocumentData = _DbClassIS.Templates.Where(Data => Data.ID == TemplateID).First();
                Binary CurrentDocumentFile = _CurrentDocumentData.TemplateData;
                File.Create(FormFilePath + "Zip").Close();
                if (CurrentDocumentFile != null) File.WriteAllBytes(FormFilePath + "Zip", CurrentDocumentFile.ToArray());

                #region Unzip Document
                Zip ZipHelper = new Zip();
                ZipHelper.UnlockComponent("ZIP-TEAMBEAN_4F46F322914X");
                Boolean IsOpenedZipFile = ZipHelper.OpenZip(FormFilePath + "Zip");
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
                if (File.Exists(FormFilePath + "Zip")) File.Delete(FormFilePath + "Zip");
                if (File.Exists(_RefDocPath))
                {
                    File.SetAttributes(_RefDocPath, FileAttributes.Normal);
                    File.Copy(_RefDocPath, FormFilePath + "Doc");
                }
                else throw new Exception("فایلی برای خواندن مدرك از بانك وجود ندارد!");
                if (File.Exists(_RefDocPath))
                    try
                    {
                        File.SetAttributes(_RefDocPath, FileAttributes.Normal);
                        File.Delete(_RefDocPath);
                    }
                    // ReSharper disable EmptyGeneralCatchClause
                    catch (Exception) { }
                // ReSharper restore EmptyGeneralCatchClause
                #endregion
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان خواندن اطلاعات مدرك از بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟\n" +
                    "2. آیا مدرك مورد نظر در حین كار توسط كاربر دیگری حذف نشده است؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry(Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion
            return true;
        }
        #endregion

        #region Boolean FillFormBaseDataSources(Int16 ID)
        /// <summary>
        /// تابع خواندن اطلاعات قالب مدرك
        /// </summary>
        /// <returns>صحت خواندن اطلاعات</returns>
        private Boolean FillFormBaseDataSources(Int16 TemplateID)
        {
            Template DocTemplateData;
            try
            {
                DocTemplateData = _DbClassIS.Templates.Where(Data => Data.ID == TemplateID).ToList().First();
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان خواندن اطلاعات قالب مدرك انتخاب شده از بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟\n" +
                    "2. آیا ترم افزار ورد مایكروسافت نصب می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry(Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion
            // خواندن اطلاعات پایه قالب
            txtName.Text = DocTemplateData.Name;
            if (DocTemplateData.Code == null) txtTemplateCode.ValueObject = null;
            else txtTemplateCode.Value = Convert.ToInt32(DocTemplateData.Code);
            txtDescription.Text = DocTemplateData.Description;
            return true;
        }
        #endregion

        #region Boolean SaveDocument()
        /// <summary>
        /// تابع به ذخیره سازی مدرك جاری
        /// </summary>
        /// <returns>صحت انجام كار</returns>
        private Boolean SaveDocument()
        {
            if (_CurrentWordApp == null || _CurrentWordDocument == null) return true;
            Object FilePath = FormFilePath + "Doc";
            Object FileFormat = WdSaveFormat.wdFormatDocument;
            try
            {
                _CurrentWordDocument.SaveAs(ref FilePath, ref FileFormat, ref _Missing, ref _Missing, ref _Missing
                    , ref _Missing, ref _Missing, ref _Missing, ref _Missing, ref _Missing,
                    ref _Missing, ref _Missing, ref _Missing, ref _Missing, ref _Missing, ref _Missing);
            }
            catch (Exception) { }
            try
            {
                _CurrentWordDocument.Close(ref _Missing, ref _Missing, ref _Missing);
                _CurrentWordDocument = null;
                _CurrentWordApp.Quit(ref _Missing, ref _Missing, ref _Missing);
                _CurrentWordApp = null;
            }
            catch (Exception) { }
            return true;
        }
        #endregion

        #endregion

    }
}