#region using
using System;
using System.Data.Linq;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using Negar;
using DevComponents.DotNetBar;
using Microsoft.Office.Interop.Excel;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Settings.BillTemplates.Properties;
#endregion

namespace Sepehr.Settings.BillTemplates
{
    /// <summary>
    /// فرم مدیریت قالب های قبوض تصویربرداری
    /// </summary>
    internal partial class frmBillTemplatesManage : Form
    {

        #region Fields

        #region readonly Boolean _IsNewTemplate
        /// <summary>
        /// تعیین جدید بودن قالب جاری
        /// </summary>
        private readonly Boolean _IsNewTemplate;
        #endregion

        #region readonly Boolean _IsCopyTemplate
        /// <summary>
        /// تعیین كپی بودن قالب جاری
        /// </summary>
        private readonly Boolean _IsCopyTemplate;
        #endregion

        #region BillTemplate _CurrentTemplateData
        /// <summary>
        /// اطلاعات قالب جاری برای ویرایش
        /// </summary>
        private BillTemplate _CurrentTemplateData;
        #endregion

        #region readonly Object _Missing = Missing.Value
        private readonly Object _Missing = Missing.Value;
        #endregion

        #region readonly String _FilePath
        /// <summary>
        /// محل ذخیره سازی 
        /// </summary>
        private readonly String _FilePath = System.Windows.Forms.Application.StartupPath + "\\BillTemplate" +
            DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + ".Xls";
        #endregion

        #region Boolean _IsAcceptButtonClicked
        /// <summary>
        /// تعیین آنكه آیا فرم با كلید تایید بسته شده یا خروج
        /// </summary>
        private Boolean _IsAcceptButtonClicked;
        #endregion

        #region ApplicationClass _CurrentExcelApp
        /// <summary>
        /// شی از قالب برنامه ورد آفیس
        /// </summary>
        private ApplicationClass _CurrentExcelApp;
        #endregion

        #region Workbook _CurrentExcelDocument
        /// <summary>
        /// شی سند باز شده ورد 
        /// </summary>
        private Workbook _CurrentExcelDocument;
        #endregion

        #endregion

        #region Ctors

        #region frmBillTemplatesManage()
        /// <summary>
        /// سازنده فرم برای افزودن قالب
        /// </summary>
        public frmBillTemplatesManage()
        {
            Cursor.Current = Cursors.WaitCursor;
            InitializeComponent();
            Thread.CurrentThread.CurrentCulture = new CultureInfo("En-Us");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("En-Us");
            System.Windows.Forms.Application.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("Fa-Ir"));
            _IsNewTemplate = true;
            #region Creat New Template
            String Path = System.Windows.Forms.Application.StartupPath + "\\EmptyBillTemplate.xls";
            try
            {
                if (File.Exists("EmptyBillTemplate.xls"))
                {
                    File.SetAttributes("EmptyBillTemplate.xls", FileAttributes.Normal);
                    File.Copy(Path, _FilePath);
                    File.SetAttributes(_FilePath, FileAttributes.Normal);
                }
                else
                {
                    Microsoft.Office.Interop.Excel.Application ExcelApplication =
                        new Microsoft.Office.Interop.Excel.Application();
                    Workbook ExcelWorkBook = ExcelApplication.Workbooks.Add(Missing.Value);
                    ExcelWorkBook.SaveAs(Path, XlFileFormat.xlWorkbookNormal, Missing.Value,
                        Missing.Value, Missing.Value, Missing.Value, XlSaveAsAccessMode.xlNoChange,
                        Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                    ExcelWorkBook.Close(true, Path, Missing.Value);
                    ExcelApplication.Quit();
                    File.SetAttributes(Path, FileAttributes.Normal);
                    File.Copy(Path, _FilePath);
                    File.SetAttributes(_FilePath, FileAttributes.Normal);
                }
                if (!OpenWorkbookInOffice()) { Close(); return; }
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان ایجاد فرم برای ویرایش اكسل قالب وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Bills Template Settings", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                _IsAcceptButtonClicked = true;
                Close(); return;
            }
            #endregion
            #endregion
            ShowDialog();
        }
        #endregion

        #region frmBillTemplatesManage(Int32 ID, Boolean IsCopyTemplate)
        /// <summary>
        /// سازنده فرم برای ویرایش قالب
        /// </summary>
        public frmBillTemplatesManage(Int32 ID, Boolean IsCopyTemplate)
        {
            Cursor.Current = Cursors.WaitCursor;
            InitializeComponent();
            Thread.CurrentThread.CurrentCulture = new CultureInfo("En-Us");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("En-Us");
            System.Windows.Forms.Application.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("Fa-Ir"));
            _IsCopyTemplate = IsCopyTemplate;
            _IsNewTemplate = IsCopyTemplate;
            if (!FillFormBaseDataSources(ID)) { _IsAcceptButtonClicked = true; Close(); return; }
            ShowDialog();
        }
        #endregion

        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            SetControlsToolTipTexts();
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
            // ToDo: نمایش راهنما تكمیل شود
        }
        #endregion

        #region btnAddinFieldsList_Click
        private void btnAddinFieldsList_Click(object sender, EventArgs e)
        {
            new frmAddinFieldsList();
        }
        #endregion

        #region btnImport_Click
        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog.Filter = "فایل اكسل آفیس 2003 (*.Xls)|*.Xls";
            if (OpenFileDialog.ShowDialog() != DialogResult.OK) return;
            try
            {
                #region Close Current Word Object And Application
                // بستن فایل آفیس جاری
                if (_CurrentExcelDocument != null)
                {
                    // ReSharper disable EmptyGeneralCatchClause
                    try { _CurrentExcelDocument.BeforeClose -= _CurrentWordDocument_OnQuit; }
                    catch { }
                    try { _CurrentExcelDocument.Close(false, _FilePath, _Missing); }
                    catch { }
                    // ReSharper restore EmptyGeneralCatchClause
                }
                if (_CurrentExcelApp != null)
                {
                    // ReSharper disable EmptyGeneralCatchClause
                    try { _CurrentExcelApp.Quit(); }
                    catch { }
                    // ReSharper restore EmptyGeneralCatchClause
                }
                _CurrentExcelDocument = null;
                _CurrentExcelApp = null;
                #endregion
                // حذف فایل جاری آفیس
                if (File.Exists(_FilePath))
                {
                    File.SetAttributes(_FilePath, FileAttributes.Normal);
                    File.Delete(_FilePath);
                }
                // كپی كردن فایل آفیس انتخاب شده به آدرس فایل آفیس جاری
                File.Copy(OpenFileDialog.FileName, _FilePath);
                File.SetAttributes(_FilePath, FileAttributes.Normal);
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                "امكان خواندن اطلاعات فایل آفیس انتخاب شده وجود ندارد.\n" +
                "موارد زیر را بررسی نمایید:\n" +
                "1. آیا فایل انتخاب شده در آفیس دیگری باز شده است؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Bills Template Settings", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                _IsAcceptButtonClicked = true;
                Close();
                return;
            }
            #endregion
            // نمایش مجدد آفیس انتخاب شده
            OpenWorkbookInOffice();
        }
        #endregion

        #region void _CurrentWordDocument_OnQuit(ref Boolean ShouldClose)
        void _CurrentWordDocument_OnQuit(ref Boolean ShouldClose)
        {
            _CurrentExcelDocument = null;
        }
        #endregion

        #region btnSave_Click
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtName.Text.Trim()))
            {
                PMBox.Show("برای قالب قبض حتماً یك نام وارد نمایید!", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return;
            }
            if (!SaveCurrentBillTemplate()) { _IsAcceptButtonClicked = true; DialogResult = DialogResult.OK; return; }
            if (_IsNewTemplate)
            { if (!InsertNewDocument()) { _IsAcceptButtonClicked = true; DialogResult = DialogResult.OK; return; } }
            else if (!UpdateDocument()) { _IsAcceptButtonClicked = true; Close(); return; }
            _IsAcceptButtonClicked = true;
            DialogResult = DialogResult.OK;
        }
        #endregion

        #region Form_Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            #region Check For Exit Without Save
            if (!_IsAcceptButtonClicked)
            {
                DialogResult Dr = PMBox.Show("آیا مایلید فرم را بدون ذخیره سازی اطلاعات قالب قبض ببندید؟",
                    "پرسش؟", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (Dr == DialogResult.No) { e.Cancel = true; return; }
            }
            #endregion

            Opacity = 0.01;
            Cursor = Cursors.WaitCursor;
            #region Close Excel Application Process
            if (_CurrentExcelApp != null)
            {
                try
                {
                    _CurrentExcelDocument = null;
                    _CurrentExcelApp.Quit();
                }
                // ReSharper disable EmptyGeneralCatchClause
                catch (Exception) { }
                // ReSharper restore EmptyGeneralCatchClause
            }
            _CurrentExcelApp = null;

            #endregion

            #region Delete Office File
            // ReSharper disable EmptyGeneralCatchClause
            if (File.Exists(_FilePath))
                try { File.Delete(_FilePath); }
                catch { }
            // ReSharper restore EmptyGeneralCatchClause
            #endregion

            Dispose();
            GC.Collect();
            Cursor.Current = Cursors.Default;
        }
        #endregion

        #endregion

        #region Methods

        #region void SetControlsToolTipTexts()
        /// <summary>
        /// تابع تنظیم متن راهنمای كنترل ها
        /// </summary>
        private void SetControlsToolTipTexts()
        {
            const String TooltipHeader = "راهنمای تنظیمات سیستم";
            const String TooltipFooter = "سیستم مدیریت تصویربرداری سپهر";

            #region btnHelp
            String TooltipText = ToolTipManager.GetText("btnHelp", "IMS");
            FormToolTip.SetSuperTooltip(btnHelp, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnClose
            TooltipText = ToolTipManager.GetText("btnCancel_NoApply", "IMS");
            FormToolTip.SetSuperTooltip(btnClose, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnSave
            TooltipText = ToolTipManager.GetText("btnAccept", "IMS");
            FormToolTip.SetSuperTooltip(btnSave, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

        }
        #endregion

        #region Boolean OpenWorkbookInOffice()
        /// <summary>
        /// روالی برای باز كردن فایل آفیس مدرك در كنترل
        /// </summary>
        private Boolean OpenWorkbookInOffice()
        {
            #region Close Current Excel Object
            if (_CurrentExcelDocument != null)
            {
                // ReSharper disable EmptyGeneralCatchClause
                try { _CurrentExcelDocument.BeforeClose -= _CurrentWordDocument_OnQuit; }
                catch { }
                try { _CurrentExcelDocument.Close(false, _Missing, _Missing); }
                catch { }
                // ReSharper restore EmptyGeneralCatchClause
                _CurrentExcelDocument = null;
            }
            #endregion

            #region Initialize Word Application Object If It's Disposed
            if (_CurrentExcelApp == null)
                try { _CurrentExcelApp = new ApplicationClass(); }
                #region Catch
                catch (Exception Ex)
                {
                    const String ErrorMessage =
                    "امكان باز كردن برنامه ورد مایكروسافت ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا این برنامه بر روی سیستم شما نصب می باشد؟";
                    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogManager.SaveLogEntry("Sepehr", "Bills Template Settings", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                    return false;
                }
                #endregion
            #endregion

            try
            {
                _CurrentExcelDocument = _CurrentExcelApp.Workbooks.Open(_FilePath,
                    Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                    Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                _CurrentExcelDocument.BeforeClose += _CurrentWordDocument_OnQuit;
                _CurrentExcelApp.Visible = true;
                _CurrentExcelApp.WindowState = XlWindowState.xlMaximized;
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                "امكان خواندن اطلاعات نرم افزار ورد مایكروسافت ممكن نیست.\n" +
                "موارد زیر را بررسی نمایید:\n" +
                "1. آیا این برنامه بر روی سیستم شما نصب می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Bills Template Settings", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion

            return true;
        }
        #endregion

        #region Boolean FillFormBaseDataSources(Int32 BillID)
        /// <summary>
        /// تابع خواندن اطلاعات قالب
        /// </summary>
        /// <returns>صحت خواندن اطلاعات</returns>
        private Boolean FillFormBaseDataSources(Int32 BillID)
        {
            try
            {
                if (File.Exists(_FilePath)) File.Delete(_FilePath);
                _CurrentTemplateData = DBLayerIMS.Manager.DBML.BillTemplates.
                    Where(Data => Data.ID == BillID).ToList().First();
                cBoxIsActive.Checked = _CurrentTemplateData.IsActive;
                String NewTemplateName = String.Empty;
                if (_IsCopyTemplate) NewTemplateName = "- كپی";
                if (_CurrentTemplateData.PrintLimitation != null)
                    txtPrintCount.Value = _CurrentTemplateData.PrintLimitation.Value;
                else txtPrintCount.ValueObject = null;
                txtName.Text = _CurrentTemplateData.Name + NewTemplateName;
                txtDescription.Text = _CurrentTemplateData.Description;
                Binary TempData = _CurrentTemplateData.TemplateData;
                File.Create(_FilePath).Close();
                if (TempData != null) File.WriteAllBytes(_FilePath, TempData.ToArray());
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان خواندن اطلاعات قالب قبض انتخاب شده از بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Bills Template Settings", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion
            if (!OpenWorkbookInOffice()) { return false; }
            return true;
        }
        #endregion

        #region Boolean SaveCurrentBillTemplate()
        /// <summary>
        /// تابع به ذخیره سازی قالب قبض جاری در فایل آفیس
        /// </summary>
        /// <returns>صحت انجام كار</returns>
        private Boolean SaveCurrentBillTemplate()
        {
            #region Save Current Office Document If T's Not Closed
            // اگر آفیس قبلاً به صورت دستی بسته شده باشند ، نیازی به ذخیره سازی قالب و بستن آفیس نیست
            if (_CurrentExcelApp != null && _CurrentExcelDocument != null)
            {
                try { _CurrentExcelDocument.Save(); }
                #region Catch
                catch (Exception Ex)
                {
                    const String ErrorMessage = "امكان ذخیره سازی محلی فایل آفیس جاری در سیستم كاربر ممكن نیست.\n" +
                        "موارد زیر را بررسی نمایید:\n" +
                        "1. آیا ترم افزار ورد مایكروسافت آسیب ندیده است؟";
                    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogManager.SaveLogEntry("Sepehr", "Bills Template Settings", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                    return false;
                }
                #endregion
            }
            #endregion
            #region Close Office Processes If It's Not
            try
            {
                if (_CurrentExcelDocument != null) _CurrentExcelDocument.Close(false, _FilePath, _Missing);
                _CurrentExcelDocument = null;
                if (_CurrentExcelApp != null) _CurrentExcelApp.Quit();
                _CurrentExcelApp = null;
            }
            // ReSharper disable EmptyGeneralCatchClause
            catch { }
            // ReSharper restore EmptyGeneralCatchClause
            #endregion
            return true;
        }
        #endregion

        #region Boolean InsertNewDocument()
        /// <summary>
        /// ثبت یك قالب قبض جدید
        /// </summary>
        /// <returns>ٌصحت انجام كار</returns>
        private Boolean InsertNewDocument()
        {
            _IsAcceptButtonClicked = true;
            try
            {
                BillTemplate NewItem = new BillTemplate();
                NewItem.IsActive = cBoxIsActive.Checked;
                if (txtPrintCount.ValueObject == null || txtPrintCount.Value == 0) NewItem.PrintLimitation = null;
                else NewItem.PrintLimitation = Convert.ToInt16(txtPrintCount.Value);
                NewItem.IsActive = cBoxIsActive.Checked;
                NewItem.Name = txtName.Text.Trim().Normalize();
                NewItem.Description = txtDescription.Text.Trim().Normalize();
                NewItem.TemplateData = File.ReadAllBytes(_FilePath);
                DBLayerIMS.Manager.DBML.BillTemplates.InsertOnSubmit(NewItem);
                DBLayerIMS.Manager.DBML.SubmitChanges();
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان اضافه كردن قالب قبض به بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Bills Template Settings", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion
            #region Finally
            finally
            {
                try { if (File.Exists(_FilePath)) File.Delete(_FilePath); }
                // ReSharper disable EmptyGeneralCatchClause
                catch (Exception) { }
                // ReSharper restore EmptyGeneralCatchClause
            }
            #endregion
            return true;
        }
        #endregion

        #region Boolean UpdateDocument()
        /// <summary>
        /// تابع به روز رسانی قالب مدرك جاری
        /// </summary>
        /// <returns>صحت انجام كار</returns>
        private Boolean UpdateDocument()
        {
            _IsAcceptButtonClicked = true;
            try
            {
                _CurrentTemplateData.IsActive = cBoxIsActive.Checked;
                _CurrentTemplateData.Name = txtName.Text.Trim().Normalize();
                if (txtPrintCount.ValueObject == null || txtPrintCount.Value == 0) _CurrentTemplateData.PrintLimitation = null;
                else _CurrentTemplateData.PrintLimitation = Convert.ToInt16(txtPrintCount.Value);
                _CurrentTemplateData.Description = txtDescription.Text.Trim().Normalize();
                _CurrentTemplateData.TemplateData = File.ReadAllBytes(_FilePath);
                DBLayerIMS.Manager.DBML.SubmitChanges();
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان به روز رسانی اطلاعات قالب قبض جاری ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Bills Template Settings", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error); return false;
            }
            #endregion
            #region Finally
            finally
            {
                try { if (File.Exists(_FilePath)) File.Delete(_FilePath); }
                // ReSharper disable EmptyGeneralCatchClause
                catch (Exception) { }
                // ReSharper restore EmptyGeneralCatchClause
            }
            #endregion
            return true;
        }
        #endregion

        #endregion

    }
}