#region using
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Negar;
using Chilkat;
using DevComponents.DotNetBar;
using Microsoft.Office.Interop.Word;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Settings.Documents;
using Sepehr.Settings.Documents.Properties;
using Application = System.Windows.Forms.Application;
#endregion

namespace Sepehr.Documents
{
    /// <summary>
    /// فرم مدیریت قالب های مدارك مراجعات تصویربرداری بیماران
    /// </summary>
    internal partial class frmDocTemplatesManage : Form
    {

        #region Fields

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

        #region readonly Boolean _IsAdding
        /// <summary>
        /// مجزا كننده فراخوانی فرم 
        /// </summary>
        private readonly Boolean _IsAdding;
        #endregion

        #region DocTemplate _CurrentDocumentData
        /// <summary>
        /// اطلاعات قالب مدرك جاری
        /// </summary>
        private DocTemplate _CurrentDocumentData;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmDocTemplatesManage(Int16? CurrentTemplateID)
        {
            if (CurrentTemplateID != null) //اگر فرم در حال ویرایش فراخوانی شده بود
            {
                _CurrentTemplateID = CurrentTemplateID;
                _IsAdding = false;
            }
            else _IsAdding = true; //اگر فرم در حال افزودن فراخوانی شده بود
            Cursor.Current = Cursors.WaitCursor;
            InitializeComponent();
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            Object FilePath = FormFilePath + "Doc";
            Opacity = 0.01;
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
                    else
                    {
                        File.Create("EmptyTemplate.Doc").Close();
                        File.Create(FilePath.ToString()).Close();
                        File.SetAttributes(FilePath.ToString(), FileAttributes.Normal);
                    }
                }
                #region Catch
                catch (Exception Ex)
                {
                    const String ErrorMessage =
                        "امكان باز كردن نرم افزار وُرد مایكروسافت ممكن نیست.\n" +
                        "موارد زیر را بررسی نمایید:\n" +
                        "1. آیا نرم افزار وُرد مایكروسافت نصب شده است؟";
                    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogManager.SaveLogEntry("Sepehr", "Documents Settings", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                    Close(); return;
                }
                #endregion
                txtTemplateCode.ValueObject = null;
            }
            #endregion

            #region Editing State
            // خواندن مدرك آماده شده - جدید یا ذخیره شده - در آفیس
            else if (!FillFormBaseDataSources(_CurrentTemplateID.Value) || !LoadDocData(_CurrentTemplateID.Value))
            { _HaveError = true; Close(); return; }
            #endregion
            if (!OpenDocTemplateInOffice()) { _HaveError = true; Close(); return; }
            Cursor.Current = Cursors.Default;
            Opacity = 1;
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

        #region btnImport_Click
        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog.Filter = "فایل ورد آفیس 2003 (*.Doc)|*.Doc";
            if (OpenFileDialog.ShowDialog() != DialogResult.OK) return;
            try
            {
                #region Close Current Word Object And Application
                // بستن فایل آفیس جاری
                if (_CurrentWordDocument != null)
                {
                    Object FalseValue = false;
                    // ReSharper disable EmptyGeneralCatchClause
                    try { _CurrentWordDocument.DocumentEvents2_Event_Close -= _CurrentWordDocument_OnQuit; }
                    catch { }
                    try { _CurrentWordDocument.Close(ref FalseValue, ref _Missing, ref _Missing); }
                    catch { }
                    // ReSharper restore EmptyGeneralCatchClause
                }
                if (_CurrentWordApp != null)
                {
                    Object FalseValue = false;
                    // ReSharper disable EmptyGeneralCatchClause
                    try { _CurrentWordApp.Quit(ref FalseValue, ref _Missing, ref _Missing); }
                    catch { }
                    // ReSharper restore EmptyGeneralCatchClause
                }
                _CurrentWordDocument = null;
                _CurrentWordApp = null;
                #endregion
                // حذف فایل جاری آفیس
                if (File.Exists(FormFilePath + "Doc"))
                {
                    File.SetAttributes(FormFilePath + "Doc", FileAttributes.Normal);
                    File.Delete(FormFilePath + "Doc");
                }
                // كپی كردن فایل آفیس انتخاب شده به آدرس فایل آفیس جاری
                File.Copy(OpenFileDialog.FileName, FormFilePath + "Doc");
                File.SetAttributes(FormFilePath + "Doc", FileAttributes.Normal);
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                "امكان خواندن اطلاعات فایل آفیس انتخاب شده وجود ندارد.\n" +
                "موارد زیر را بررسی نمایید:\n" +
                "1. آیا فایل انتخاب شده در آفیس دیگری باز شده است؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Documents Settings", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                _HaveError = true;
                return;
            }
            #endregion
            // نمایش مجدد آفیس انتخاب شده
            OpenDocTemplateInOffice();
        }
        #endregion

        #region btnAddinFieldsList_Click
        private void btnAddinFieldsList_Click(object sender, EventArgs e)
        {
            new frmAddinFieldsList();
        }
        #endregion

        #region void _CurrentWordDocument_OnQuit()
        void _CurrentWordDocument_OnQuit()
        {
            _CurrentWordDocument = null;
        }
        #endregion

        #region btnCancel_Click
        /// <summary>
        /// دكمه بستن فرم
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(FormFilePath + "Zip")) File.Delete(FormFilePath + "Zip");
                if (File.Exists(FormFilePath + "Doc")) File.Delete(FormFilePath + "Doc");
            }
            #region Catch
            catch (Exception Ex)
            {
                LogManager.SaveLogEntry("Sepehr", "Documents Settings", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
            }
            #endregion
            DialogResult = DialogResult.Cancel;
        }
        #endregion

        #region btnAccept_Click
        /// <summary>
        /// دكمه ذخیره سازی فرم مدرك
        /// </summary>
        private void btnAccept_Click(object sender, EventArgs e)
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
                List<DocTemplate> SelectedCode;
                try
                {
                    if (_CurrentTemplateID == null) SelectedCode =
                        DBLayerIMS.Manager.DBML.DocTemplates.
                        Where(Data => Data.Code == Convert.ToInt16(txtTemplateCode.Value)).ToList();
                    else SelectedCode = DBLayerIMS.Manager.DBML.DocTemplates.
                        Where(Data => Data.ID != _CurrentTemplateID.Value &&
                            Data.Code == Convert.ToInt16(txtTemplateCode.Value)).ToList();
                }
                #region Catch
                catch (Exception Ex)
                {
                    const String ErrorMessage = "امكان بررسی تكراری بودن كد قالب جاری ممكن نیست.\n" +
                        "موارد زیر را بررسی نمایید:\n" +
                        "1. آیا ارتباط شبكه شما متصل می باشد؟";
                    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogManager.SaveLogEntry("Sepehr", "Documents Settings", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                    return;
                }
                #endregion
                if (SelectedCode.Count != 0)
                {
                    PMBox.Show("كد وارد شده برای قالب جاری قبلاً برای قالب دیگری انتخاب شده است!\n" +
                    "كد دیگری برای قالب جاری انتخاب نمایید!", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTemplateCode.Focus();
                    return;
                }
            }
            #endregion
            if (!SaveCurrentDocTemplate()) return;
            #region Close Word Application Process
            if (_CurrentWordApp != null)
            {
                try { _CurrentWordApp.Quit(ref _Missing, ref _Missing, ref _Missing); }
                // ReSharper disable EmptyGeneralCatchClause
                catch (Exception) { }
                // ReSharper restore EmptyGeneralCatchClause
            }
            _CurrentWordDocument = null;
            _CurrentWordApp = null;
            #endregion
            FormClosing -= Form_Closing;
            DialogResult = DialogResult.OK;
        }
        #endregion

        #region Form_Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            #region Check For Exit Without Save
            if (!_HaveError)
            {
                DialogResult Dr = PMBox.Show("آیا مایلید فرم را بدون ذخیره سازی اطلاعات قالب مدرك ببندید؟",
                    "پرسش؟", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (Dr == DialogResult.No) { e.Cancel = true; return; }
            }
            #endregion

            Opacity = 0.01;
            Cursor = Cursors.WaitCursor;
            #region Close Word Application Process
            if (_CurrentWordApp != null)
            {
                try { _CurrentWordApp.Quit(ref _Missing, ref _Missing, ref _Missing); }
                // ReSharper disable EmptyGeneralCatchClause
                catch (Exception) { }
                // ReSharper restore EmptyGeneralCatchClause
            }
            _CurrentWordApp = null;
            #endregion
            if (_HaveError)
            {
                Dispose();
                GC.Collect();
                _HaveError = false;
            }
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

            #region btnCancel
            String TooltipText = ToolTipManager.GetText("btnCancel", "IMS");
            FormToolTip.SetSuperTooltip(btnCancel, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnHelp
            TooltipText = ToolTipManager.GetText("btnHelp", "IMS");
            FormToolTip.SetSuperTooltip(btnHelp, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnAccept
            TooltipText = ToolTipManager.GetText("btnAccept_NoApply", "IMS");
            FormToolTip.SetSuperTooltip(btnAccept, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

        }
        #endregion

        #region Boolean OpenDocTemplateInOffice()
        /// <summary>
        /// روالی برای باز كردن فایل آفیس مدرك در كنترل
        /// </summary>
        private Boolean OpenDocTemplateInOffice()
        {
            #region Close Current Word Object
            if (_CurrentWordDocument != null)
            {
                Object FalseValue = false;
                // ReSharper disable EmptyGeneralCatchClause
                try { _CurrentWordDocument.DocumentEvents2_Event_Close -= _CurrentWordDocument_OnQuit; }
                catch { }
                try { _CurrentWordDocument.Close(ref FalseValue, ref _Missing, ref _Missing); }
                catch { }
                // ReSharper restore EmptyGeneralCatchClause
                _CurrentWordDocument = null;
            }
            #endregion

            #region Initialize Word Application Object If It's Disposed
            if (_CurrentWordApp == null)
                try { _CurrentWordApp = new ApplicationClass(); }
                #region Catch
                catch (Exception Ex)
                {
                    const String ErrorMessage =
                    "امكان باز كردن برنامه ورد مایكروسافت ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا این برنامه بر روی سیستم شما نصب می باشد؟";
                    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogManager.SaveLogEntry("Sepehr", "Documents Settings", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                    _HaveError = true;
                    return false;
                }
                #endregion
            #endregion

            Object FilePath = FormFilePath + "Doc";
            try
            {
                _CurrentWordDocument = (DocumentClass)_CurrentWordApp.Documents.Open(ref FilePath, ref _Missing,
                    ref _Missing, ref _Missing, ref _Missing, ref _Missing, ref _Missing, ref _Missing, ref _Missing, ref _Missing,
                    ref _Missing, ref _Missing, ref _Missing, ref _Missing, ref _Missing, ref _Missing);
                _CurrentWordDocument.DocumentEvents2_Event_Close += _CurrentWordDocument_OnQuit;
                _CurrentWordApp.ShowMe();
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
                LogManager.SaveLogEntry("Sepehr", "Documents Settings", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                _HaveError = true;
                return false;
            }
            #endregion
            return true;
        }
        #endregion

        #region Boolean LoadDocData(Int32 TemplateID)
        /// <summary>
        /// تابع خواندن اطلاعات و فایل مدرك در ویرایشگر
        /// </summary>
        /// <param name="TemplateID">كلید مدرك</param>
        /// <returns>صحت انجام كار</returns>
        private Boolean LoadDocData(Int32 TemplateID)
        {
            try
            {
                _CurrentDocumentData = DBLayerIMS.Manager.DBML.DocTemplates.
                    Where(Data => Data.ID == TemplateID).First();
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
                LogManager.SaveLogEntry("Sepehr", "Documents Settings", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion
            return true;
        }
        #endregion

        #region Boolean FillFormBaseDataSources(Int16 TemplateID)
        /// <summary>
        /// تابع خواندن اطلاعات قالب مدرك
        /// </summary>
        /// <returns>صحت خواندن اطلاعات</returns>
        private Boolean FillFormBaseDataSources(Int16 TemplateID)
        {
            DocTemplate DocTemplateData;
            try
            {
                DocTemplateData = DBLayerIMS.Manager.DBML.DocTemplates.
                    Where(Data => Data.ID == TemplateID).ToList().First();
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
                LogManager.SaveLogEntry("Sepehr", "Documents Settings", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion
            // خواندن اطلاعات پایه قالب
            txtName.Text = DocTemplateData.Name;
            if (DocTemplateData.Code == null) txtTemplateCode.ValueObject = null;
            else txtTemplateCode.Value = Convert.ToInt32(DocTemplateData.Code);
            if (DocTemplateData.IsDefault != null && DocTemplateData.IsDefault.Value) cBoxIsDefault.Checked = true;
            else cBoxIsDefault.Checked = false;
            txtDescription.Text = DocTemplateData.Description;
            return true;
        }
        #endregion

        #region Boolean SaveCurrentDocTemplate()
        /// <summary>
        /// تابع به ذخیره سازی قالب مدرك جاری در فایل ورد و زیپ كردن آن
        /// </summary>
        /// <returns>صحت انجام كار</returns>
        private Boolean SaveCurrentDocTemplate()
        {
            #region Save Current Office Document If It's Not Closed
            // اگر آفیس قبلاً به صورت دستی بسته شده باشند ، نیازی به ذخیره سازی قالب و بستن آفیس نیست
            if (_CurrentWordApp != null && _CurrentWordDocument != null)
            {
                Object FilePath = FormFilePath + "Doc";
                Object FileFormat = WdSaveFormat.wdFormatDocument;
                try
                {
                    _CurrentWordDocument.SaveAs(ref FilePath, ref FileFormat, ref _Missing, ref _Missing, ref _Missing,
                        ref _Missing, ref _Missing, ref _Missing, ref _Missing, ref _Missing, ref _Missing, ref _Missing,
                        ref _Missing, ref _Missing, ref _Missing, ref _Missing);
                }
                #region Catch
                catch (Exception Ex)
                {
                    const String ErrorMessage = "امكان ذخیره سازی محلی فایل آفیس جاری در سیستم كاربر ممكن نیست.\n" +
                        "موارد زیر را بررسی نمایید:\n" +
                        "1. آیا ترم افزار ورد مایكروسافت آسیب ندیده است؟";
                    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogManager.SaveLogEntry("Sepehr", "Documents Settings", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                    return false;
                }
                #endregion
            }
            #endregion
            #region Close Office Processes If It's Not Closed
            try
            {
                Object FalseValue = false;
                if (_CurrentWordDocument != null) _CurrentWordDocument.Close(ref FalseValue, ref _Missing, ref _Missing);
                _CurrentWordDocument = null;
                if (_CurrentWordApp != null) _CurrentWordApp.Quit(ref FalseValue, ref _Missing, ref _Missing);
                _CurrentWordApp = null;
            }
            // ReSharper disable EmptyGeneralCatchClause
            catch { }
            // ReSharper restore EmptyGeneralCatchClause
            #endregion
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
            return true;
        }
        #endregion

        #endregion

    }
}