#region using

using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Negar;
using Negar.DBLayerPMS.DataLayer;
using Negar.PersianCalendar.Utilities;
using Chilkat;
using DevComponents.DotNetBar;
using Microsoft.Office.Interop.Word;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Forms.Documents.Classes;
using Sepehr.Forms.Documents.Properties;
using Application = System.Windows.Forms.Application;

#endregion

namespace Sepehr.Forms.Documents
{
    /// <summary>
    /// فرم مدیریت مدارك مراجعات بیماران
    /// </summary>
    internal partial class frmManageDocument : Form
    {

        #region Fields

        #region ApplicationClass _CurrentWordApp
        private ApplicationClass _CurrentWordApp;
        #endregion

        #region DocumentClass _CurrentWordDocument
        private DocumentClass _CurrentWordDocument;
        #endregion

        #region Object _Missing
        private Object _Missing = Missing.Value;
        #endregion

        #region String _DocFilePath
        /// <summary>
        /// نام رشته فایل مدرك جاری
        /// </summary>
        private String _DocFilePath;
        #endregion

        #region Boolean _IsNewDoc
        /// <summary>
        /// تعیین جدید بودن مدرك جاری
        /// </summary>
        private Boolean _IsNewDoc;
        #endregion

        #region Boolean _IsOfficeClosedTimerFlag
        /// <summary>
        /// تعیین آنكه آیا برنامه آفیس بسته شده یا خیر
        /// </summary>
        private Boolean _IsOfficeClosedTimerFlag;
        #endregion

        #region Boolean _IsOfficeClosedManualy
        /// <summary>
        /// تعیین آنكه آیا آفیس به صورت دستی بسته شده یا خیر
        /// </summary>
        private Boolean _IsOfficeClosedManualy;
        #endregion

        #region Boolean _IsFormHaveError
        /// <summary>
        /// تعیین رخ دادن خطا جهت بستن بدون پرسش فرم
        /// </summary>
        internal Boolean _IsFormHaveError;
        #endregion

        #region List<SP_SelectTypeResult> _DocTypesList
        /// <summary>
        /// لیست انواع مدارك تصویربرداری
        /// </summary>
        private List<SP_SelectTypeResult> _DocTypesList;
        #endregion

        #region Int32 _CurrentRefID
        /// <summary>
        /// كلید مراجعه جاری
        /// </summary>
        private Int32 _CurrentRefID;
        #endregion

        #region RefDocument _CurrentDoc
        private RefDocument _CurrentDoc;
        #endregion

        #region RefList _CurrentRefData
        /// <summary>
        /// شیء اطلاعات مراجعه مدرك جاری
        /// </summary>
        private RefList _CurrentRefData;
        #endregion

        #region Int32? _CurrentDocID
        /// <summary>
        /// كلید مدرك جاری
        /// </summary>
        Int32? _CurrentDocID;
        #endregion

        #region List<SP_SelectTemplatesResult> _TemplatesList
        /// <summary>
        /// لیست قالب های ثبت شده برای مدارك بیماران
        /// </summary>
        internal List<SP_SelectTemplatesResult> _TemplatesList;
        #endregion

        #region List<DocText> _DocTextsList
        /// <summary>
        /// لیست متن های ثبت شده برای مدارك بیماران
        /// </summary>
        private List<DocText> _DocTextsList;
        #endregion

        #region Settings Fields
        /// <summary>
        /// تعیین برابر بودن تاریخ مدرك با تاریخ مراجعه
        /// </summary>
        private Boolean _ShouldDocTimeEqualRefTime;
        /// <summary>
        /// كلید نوع مدرك پیش فرض
        /// </summary>
        private Int16? _DefaultDocType;
        #endregion

        #region ACL Fields
        /// <summary>
        /// امكان افزودن مدرك جدید
        /// </summary>
        private Boolean _CanAddNewDocument = true;
        /// <summary>
        /// امكان افزودن چندین گزارش
        /// </summary>
        private Boolean _CanAddNewSeveralReports = true;
        /// <summary>
        /// امكان افزودن چندین گزارش برای مراجعه دارای مدرك
        /// </summary>
        private Boolean _CanAddNewSeveralReportsByOthers = true;
        /// <summary>
        /// فیلد تعیین امكان ویرایش متن مدرك ثبت شده توسط كاربر
        /// </summary>
        private Boolean _CanEditDocument = true;
        /// <summary>
        /// امكان ویرایش مدارك سایر كاربران
        /// </summary>
        private Boolean _CanEditOthersDocument = true;
        /// <summary>
        /// امكان ارسال پیام كوتاه به بیمار
        /// </summary>
        private Boolean _CanSendSMS = true;
        #endregion

        #region readonly String_RefDocPath
        private readonly String _RefDocPath = Application.StartupPath + "\\RefDoc.Doc";
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم برای ساخت كنترل ها
        /// </summary>
        public frmManageDocument()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (Negar.DBLayerPMS.Security.UsersList == null) { _IsFormHaveError = true; Close(); return; }
            InitializeComponent();
            Top = 0;
            // بررسی دسترسی ها و تنظیمات
            if (SecurityManager.CurrentUserID > 2 && !ReadCurrentUserPermissions()) { _IsFormHaveError = true; Close(); return; }
            if (!(ReadCurrentUserSettings())) { _IsFormHaveError = true; Close(); return; }
            // خواندن اطلاعات پایه مانند پزشكان ، نوع مدارك و كاربران و قالب های مدارك
            if (!FillFormBaseDataSources() || !FillDocTemplates() || !FillDocTexts())
            { _IsFormHaveError = true; Close(); return; }
            SetControlsToolTipTexts();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            // خواندن مدرك آماده شده - جدید یا ذخیره شده - در آفیس
            if (!OpenDocInWord(true)) { _IsFormHaveError = true; Close(); return; }
            // ===== تنظیمات فرم به ازای هر بار فراخوانی =====
            DateFa.SelectedDateTime = DateTime.Now;
            ExPanel.Expanded = false;
            ExPanel.Expanded = true;
            // تنظیم فرم در حالت افزودن مدرك جدید
            if (_IsNewDoc) SetControlsAddingStateProperties();
            // تنظیم فرم در حالت ویرایش مدرك ثبت شده
            else SetControlsEditingStateProperties();
            // فعال كردن تایمر تعریف شده برای بررسی آنكه آیا آفیس به صورت دستی توسط كاربر بسته شده یا خیر
            _IsOfficeClosedTimerFlag = false;
            TimerClosing.Start();
            ReplaceCapturedImages();
            // =============================
            Cursor.Current = Cursors.Default;
            Opacity = 1;
        }
        #endregion

        #region TimerFormHide_Tick
        private void TimerFormHide_Tick(object sender, EventArgs e)
        {
            ExPanel.Expanded = false;
            TimerFormHide.Stop();
        }
        #endregion

        #region CurrentWordApp_OnQuit
        void CurrentWordApp_OnQuit()
        {
            _IsOfficeClosedTimerFlag = true;
        }
        #endregion

        #region TimerClosing_Tick
        private void TimerClosing_Tick(object sender, EventArgs e)
        {
            if (!_IsOfficeClosedTimerFlag) return;
            TimerClosing.Stop();
            TimerClosing.Enabled = false;
            _IsOfficeClosedTimerFlag = false;
            #region Check For Exit Without Save
            if (!_IsFormHaveError)
            {
                // افزودن مدرك
                if (_IsNewDoc)
                {
                    if (InsertNewDocument())
                    {
                        _IsOfficeClosedManualy = true;
                        _IsFormHaveError = false;
                    }
                    else
                    {
                        _IsOfficeClosedManualy = false;
                        _IsFormHaveError = true;
                    }
                }
                // ویرایش مدرك
                else
                {
                    if (UpdateDocument())
                    {
                        _IsOfficeClosedManualy = true;
                        _IsFormHaveError = false;
                    }
                    else
                    {
                        _IsOfficeClosedManualy = false;
                        _IsFormHaveError = true;
                    }
                }
            }
            #endregion
            Close();
        }
        #endregion

        #region ExPanel_ExpandedChanged
        private void ExPanel_ExpandedChanged(object sender, ExpandedChangeEventArgs e)
        {
            if (e.NewExpandedValue)
            {
                Width = 764;
                Left = Screen.PrimaryScreen.WorkingArea.Width - Width - 100;
                Height = 90;
                Opacity = 1;
            }
            else
            {
                Width = 200;
                Left = Screen.PrimaryScreen.WorkingArea.Width / 2 - 100;
                Height = 16;
                Opacity = 1;
            }
        }
        #endregion

        #region DateFa_SelectedDateTimeChanged
        private void DateFa_SelectedDateTimeChanged(object sender, EventArgs e)
        {
            DateEn.ValueChanged -= DateEn_ValueChanged;
            DateEn.Value = DateFa.SelectedDateTime.Value;
            DateEn.ValueChanged += DateEn_ValueChanged;
        }
        #endregion

        #region DateEn_ValueChanged
        private void DateEn_ValueChanged(object sender, EventArgs e)
        {
            DateFa.SelectedDateTimeChanged -= DateFa_SelectedDateTimeChanged;
            DateFa.SelectedDateTime = DateEn.Value;
            DateFa.SelectedDateTimeChanged += DateFa_SelectedDateTimeChanged;
        }
        #endregion

        #region txtTemplate_KeyPress
        void txtTemplate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar)) e.Handled = true;
            else if (e.KeyChar == '\r')
            {
                Int16 ServiceCode;
                Boolean IsParsed = Int16.TryParse(txtTemplateCode.Text.Trim(), out ServiceCode);
                if (IsParsed)
                {
                    List<SP_SelectTemplatesResult> SelectedTemplate =
                        _TemplatesList.Where(Data => Data.Code == ServiceCode).ToList();
                    if (SelectedTemplate.Count == 0)
                    {
                        PMBox.Show("قالبی با كد انتخاب شده پیدا نشد!\nلطفاً قالب ها را بررسی نمایید.", "خطا!",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtTemplateCode.Focus();
                        return;
                    }
                    LoadDocTemplateInWord(SelectedTemplate.First().ID, true);
                    ReplaceCapturedImages();
                }
            }
        }
        #endregion

        #region txtTextCode_KeyPress
        void txtTextCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar)) e.Handled = true;
            else if (e.KeyChar == '\r')
            {
                Int16 TextCode;
                Boolean IsParsed = Int16.TryParse(txtTextCode.Text.Trim(), out TextCode);
                if (IsParsed)
                {
                    List<DocText> SelectedText = _DocTextsList.Where(Data => Data.Code == TextCode).ToList();
                    if (SelectedText.Count == 0)
                    {
                        PMBox.Show("متنی با كد انتخاب شده پیدا نشد!\nلطفاً متن ها را بررسی نمایید.", "خطا!",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtTextCode.Focus();
                        return;
                    }
                    _CurrentWordApp.Selection.Range.Text = SelectedText.First().TextsData;
                }
            }
        }
        #endregion

        #region ComboBoxEx_KeyPress
        void ComboBoxEx_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        void ComboBoxEx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Delete)
                e.Handled = true;
        }
        #endregion

        #region btnTemplates_Click
        private void btnTemplates_Click(object sender, EventArgs e)
        {
            if (!LoadDocTemplateInWord(Convert.ToInt32(((ButtonItem)sender).Tag), true))
            { _IsFormHaveError = true; Close(); return; }
            ReplaceCapturedImages();
        }
        #endregion

        #region btnTexts_Click
        private void btnTexts_Click(object sender, EventArgs e)
        {
            DocText CurrentText = _DocTextsList.
                Where(Data => Data.ID == Convert.ToInt32(((ButtonItem)sender).Tag)).ToList().First();
            _CurrentWordApp.Selection.Range.Text = CurrentText.TextsData;
            _CurrentDoc.Title = CurrentText.Name;
        }
        #endregion

        #region btnSave_Click
        /// <summary>
        /// دكمه ذخیره سازی فرم مدرك
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            _CurrentWordApp.ApplicationEvents2_Event_Quit -= CurrentWordApp_OnQuit;
            // افزودن مدرك
            if (_IsNewDoc)
            {
                if (!InsertNewDocument()) { _IsFormHaveError = true; Close(); return; }
                btnSave.Text = "ذخیره";
                PanelActions.Invalidate();
            }
            // ویرایش مدرك
            else if (!UpdateDocument()) { _IsFormHaveError = true; Close(); return; }
            OpenDocInWord(true);
        }
        #endregion

        #region btnSetRefServicePhysicians_Click
        private void btnSetRefServicePhysicians_Click(object sender, EventArgs e)
        {
            new frmRefServiceManager(_CurrentRefID);
        }
        #endregion

        #region btnImport_Click
        /// <summary>
        /// روال مدیریت خواندن مدرك از فایل آفیس
        /// </summary>
        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog.Filter = "فایل ورد (*.doc)|*.doc";
            if (OpenFileDialog.ShowDialog() != DialogResult.OK) return;
            DialogResult Result = PMBox.Show("آیا مایلید فایل انتخاب شده جایگزین متن جاری شود؟", "هشدار! پرسش؟",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (Result != DialogResult.Yes) return;
            #region Close Current Word Object
            // ReSharper disable EmptyGeneralCatchClause
            if (_CurrentWordDocument != null)
            {
                try
                {
                    _CurrentWordApp.ApplicationEvents2_Event_Quit -= CurrentWordApp_OnQuit;
                    _CurrentWordDocument.Close(ref _Missing, ref _Missing, ref _Missing);
                }
                catch (Exception) { }
                _CurrentWordDocument = null;
            }
            // ReSharper restore EmptyGeneralCatchClause
            #endregion
            try
            {
                if (File.Exists(_DocFilePath + "Doc")) File.Delete(_DocFilePath + "Doc");
                File.Copy(OpenFileDialog.FileName, _DocFilePath + "Doc");
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان خواندن اطلاعات نرم افزار ورد مایكروسافت ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا این برنامه بر روی سیستم شما نصب می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Documents Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                _IsFormHaveError = true;
                Close();
                return;
            }
            #endregion
            if (!OpenDocInWord(true)) { _IsFormHaveError = true; Close(); return; }
            ExPanel.Expanded = false;
        }
        #endregion

        #region btnCaptureImage_Click
        private void btnCaptureImage_Click(object sender, EventArgs e)
        {
            TopMost = false;
            if (Negar.Medical.VideoCapture.CaptureHelper.ShowCaptureForm(_CurrentRefID)) ReplaceCapturedImages();
            TopMost = true;
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

        #region Form_Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            #region Check For Exit Without Save
            if (!_IsOfficeClosedManualy && !_IsFormHaveError)
            {
                DialogResult Dr = PMBox.Show("آیا مایلید مدرك جاری را پیش از ترك فرم ذخیره نمایید؟",
                    "پرسش؟", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (Dr == DialogResult.Yes)
                {
                    TimerClosing.Stop();
                    if (_IsNewDoc) { if (!InsertNewDocument()) _IsFormHaveError = true; } // افزودن مدرك
                    else if (!UpdateDocument()) _IsFormHaveError = true; // ویرایش مدرك
                    if (!_IsFormHaveError && _CanSendSMS && DocumentHelper.IsMessageTemplateReady())
                    {
                        Dr = PMBox.Show("آیا مایلید برای بیمار جاری پیام اتمام گزارش ارسال شود؟", "پرسش؟",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (Dr == DialogResult.Yes) DocumentHelper.SendMessageToPatient(_CurrentRefID);
                    }
                }
                else if (Dr == DialogResult.No)
                {
                    // ReSharper disable EmptyGeneralCatchClause
                    try { _CurrentWordApp.ApplicationEvents2_Event_Quit -= CurrentWordApp_OnQuit; }
                    catch { }
                    Object FalseValue = false;
                    try
                    {
                        _CurrentWordDocument.Close(ref FalseValue, ref _Missing, ref _Missing);
                        _CurrentWordDocument = null;
                    }
                    catch { }
                    // ReSharper restore EmptyGeneralCatchClause
                    TimerClosing.Stop();
                }
                else if (Dr == DialogResult.Cancel) { e.Cancel = true; return; }
            }
            #endregion
            Opacity = 0.01;
            Cursor = Cursors.WaitCursor;

            #region Close Word Document Process
            // ReSharper disable EmptyGeneralCatchClause
            try { _CurrentWordApp.ApplicationEvents2_Event_Quit -= CurrentWordApp_OnQuit; }
            catch { }
            //try { _CurrentWordApp.Visible = false; }
            //catch { _IsFormHaveError = true; }
            //if (Environment.OSVersion.Version.Major == 5) // تنهای برای ویندوز XP
            //    foreach (Process process in Process.GetProcessesByName("WINWORD"))
            //    {
            //        try { process.Kill(); }
            //        catch { _IsFormHaveError = true; }
            //    }
            // ReSharper restore EmptyGeneralCatchClause
            #endregion

            #region Delete Temp File
            if (File.Exists(_DocFilePath + "Doc"))
                try { File.Delete(_DocFilePath + "Doc"); }
                #region Catch
                catch (Exception Ex)
                {
                    _IsFormHaveError = true;
                    LogManager.SaveLogEntry("Sepehr", "Documents Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                }
                #endregion
            #endregion

            #region Dispose Form When Error Raised
            if (_IsFormHaveError)
            {
                try
                {
                    _CurrentWordDocument = null; _CurrentWordApp = null;
                    _DocTextsList = null; _TemplatesList = null; _DocTextsList = null;
                }
                // ReSharper disable EmptyGeneralCatchClause
                catch { }
                // ReSharper restore EmptyGeneralCatchClause
                Dispose();
                GC.Collect();
                _IsFormHaveError = false;
            }
            #endregion

            Cursor = Cursors.Default;
            frmDocuments.RefreshFormData();
        }
        #endregion

        #endregion

        #region Methods

        #region Boolean FillFormBaseDataSources()
        /// <summary>
        /// تابع خواندن اطلاعات پایه فرم
        /// </summary>
        /// <returns>صحت خواندن اطلاعات</returns>
        private Boolean FillFormBaseDataSources()
        {
            _DocTypesList = DBLayerIMS.Document.DocTypesList;
            if (_DocTypesList == null) return false;

            #region cboDocType
            cboDocType.DataSource = _DocTypesList.Where(Data => Data.IsActive == 1).ToList();
            cboDocType.DisplayMember = "Title";
            cboDocType.ValueMember = "ID";
            #endregion

            #region cboTypist
            cboTypist.DataSource = Negar.DBLayerPMS.Security.UsersList;
            cboTypist.DisplayMember = "FullName";
            cboTypist.ValueMember = "ID";
            #endregion

            return true;
        }
        #endregion

        #region internal Boolean FillDocTemplates()
        /// <summary>
        /// تابع خواندن لیست قالب های مدارك تصویربرداری
        /// </summary>
        /// <returns>صحت خواندن اطلاعات</returns>
        internal Boolean FillDocTemplates()
        {
            _TemplatesList = DBLayerIMS.Document.DocTemplatesList;
            if (_TemplatesList == null) return false;
            // اگر قالبی در بانك وجود نداشته باشد دكمه قالب ها غیر فعال می شود
            if (_TemplatesList.Count == 0)
            {
                iContainerTemplates.Visible = false;
                txtTemplateCode.Visible = false;
                btnTemplates.SubItems.Clear();
                return true;
            }
            iContainerTemplates.Visible = true;
            txtTemplateCode.Visible = true;
            btnTemplates.SubItems.Clear();
            foreach (SP_SelectTemplatesResult Data in _TemplatesList)
            {
                if (Data.ParentIX == null)
                {
                    ButtonItem btn = new ButtonItem();
                    btn.Tag = Data.ID;
                    btn.FontBold = true;
                    btn.Text = Data.Name;
                    if (!String.IsNullOrEmpty(Data.Description.Trim())) btn.Tooltip = Data.Description;
                    if (Data.Code != null)
                    {
                        if (!String.IsNullOrEmpty(Data.Description.Trim())) btn.Tooltip += "\n";
                        btn.Tooltip += "كد: " + Data.Code.Value;
                    }
                    if (Data.IsGroup)
                    {
                        btn.IsAccessible = true;
                        AddChildDocTemplates(btn);
                    }
                    else
                    {
                        btn.IsAccessible = false;
                        btn.ForeColor = Color.Green;
                        btn.Click += btnTemplates_Click;
                    }
                    btnTemplates.SubItems.Add(btn);
                }
            }
            return true;
        }
        #endregion

        #region internal Boolean FillDocTexts()
        /// <summary>
        /// تابع خواندن لیست متن های مدارك تصویربرداری
        /// </summary>
        /// <returns>صحت خواندن اطلاعات</returns>
        internal Boolean FillDocTexts()
        {
            _DocTextsList = DBLayerIMS.Document.DocTextsList;
            if (_DocTextsList == null) return false;
            // اگر متنی در بانك وجود نداشته باشد دكمه متن ها غیر فعال می شود
            if (_DocTextsList.Count == 0)
            {
                iContainerText.Visible = false;
                txtTextCode.Visible = false;
                btnTexts.SubItems.Clear();
                return true;
            }
            iContainerText.Visible = true;
            txtTextCode.Visible = true;
            btnTexts.SubItems.Clear();
            foreach (DocText Data in _DocTextsList)
            {
                if (Data.ParentIX == null)
                {
                    ButtonItem btn = new ButtonItem();
                    btn.Tag = Data.ID;
                    btn.FontBold = true;
                    btn.Text = Data.Name;
                    if (!String.IsNullOrEmpty(Data.Description.Trim())) btn.Tooltip = Data.Description;
                    if (Data.Code != null)
                    {
                        if (!String.IsNullOrEmpty(Data.Description.Trim())) btn.Tooltip += "\n";
                        btn.Tooltip += "كد: " + Data.Code.Value;
                    }
                    if (Data.IsGroup)
                    {
                        btn.IsAccessible = true;
                        AddChildDocTexts(btn);
                    }
                    else
                    {
                        btn.IsAccessible = false;
                        btn.ForeColor = Color.Green;
                        btn.Click += btnTexts_Click;
                    }
                    btnTexts.SubItems.Add(btn);
                }
            }
            return true;
        }
        #endregion

        #region void AddChildDocTemplates(BaseItem btn)
        /// <summary>
        /// روال جستجو و افزودن قالب های مدارك
        /// </summary>
        /// <param name="btn">كنترل قالب پدر</param>
        private void AddChildDocTemplates(BaseItem btn)
        {
            foreach (SP_SelectTemplatesResult Data in _TemplatesList)
            {
                if (Data.ParentIX == Convert.ToInt16(btn.Tag))
                {
                    ButtonItem Childbtn = new ButtonItem();
                    Childbtn.Tag = Data.ID;
                    Childbtn.FontBold = true;
                    Childbtn.Text = Data.Name;
                    if (!String.IsNullOrEmpty(Data.Description.Trim())) Childbtn.Tooltip = Data.Description;
                    if (Data.Code != null)
                    {
                        if (!String.IsNullOrEmpty(Data.Description.Trim())) Childbtn.Tooltip += "\n";
                        Childbtn.Tooltip += "كد: " + Data.Code.Value;
                    }
                    if (Data.IsGroup)
                    {
                        Childbtn.IsAccessible = true;
                        AddChildDocTemplates(Childbtn);
                    }
                    else
                    {
                        Childbtn.IsAccessible = false;
                        Childbtn.ForeColor = Color.Green;
                        Childbtn.Click += btnTemplates_Click;
                    }
                    btn.SubItems.Add(Childbtn);
                }
            }
        }
        #endregion

        #region void AddChildDocTexts(BaseItem btn)
        /// <summary>
        /// روال جستجو و افزودن متن های مدارك
        /// </summary>
        /// <param name="btn">كنترل قالب پدر</param>
        private void AddChildDocTexts(BaseItem btn)
        {
            foreach (DocText Data in _DocTextsList)
            {
                if (Data.ParentIX == Convert.ToInt16(btn.Tag))
                {
                    ButtonItem Childbtn = new ButtonItem();
                    Childbtn.Tag = Data.ID;
                    Childbtn.FontBold = true;
                    Childbtn.Text = Data.Name;
                    if (!String.IsNullOrEmpty(Data.Description.Trim())) Childbtn.Tooltip = Data.Description;
                    if (Data.Code != null)
                    {
                        if (!String.IsNullOrEmpty(Data.Description.Trim())) Childbtn.Tooltip += "\n";
                        Childbtn.Tooltip += "كد: " + Data.Code.Value;
                    }
                    if (Data.IsGroup)
                    {
                        Childbtn.IsAccessible = true;
                        AddChildDocTexts(Childbtn);
                    }
                    else
                    {
                        Childbtn.IsAccessible = false;
                        Childbtn.ForeColor = Color.Green;
                        Childbtn.Click += btnTexts_Click;
                    }
                    btn.SubItems.Add(Childbtn);
                }
            }
        }
        #endregion

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

            #region btnTemplates
            TooltipText = ToolTipManager.GetText("btnDocTemplates", "IMS");
            FormToolTip.SetSuperTooltip(btnTemplates, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnSave
            TooltipText = ToolTipManager.GetText("btnDocSave", "IMS");
            FormToolTip.SetSuperTooltip(btnSave, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

        }
        #endregion

        #region @@ Security Methods @@

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
                PMBox.Show("كاربر جاری دسترسی لازم برای مشاهده مدارك بیماران را ندارد.", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            #region Add New Document - 5061
            // افزودن مدرك جدید برای مراجعه
            if (SecurityManager.GetCurrentUserPermission(5061) == false)
                _CanAddNewDocument = false;

            #region Add New Several Reports For Referral With Report - 50611
            if (SecurityManager.GetCurrentUserPermission(50611) == false)
                _CanAddNewSeveralReports = false;
            #endregion

            #region Add New Several Reports For Referral With Report By Others - 50612
            if (SecurityManager.GetCurrentUserPermission(50612) == false)
                _CanAddNewSeveralReportsByOthers = false;
            #endregion

            #endregion

            #region Edit Referral Document - 5062
            // ویرایش مدرك پس از ثبت مدرك مراجعه 
            if (SecurityManager.GetCurrentUserPermission(5062) == false) _CanEditDocument = false;
            else if (SecurityManager.GetCurrentUserPermission(50621) == false) _CanEditOthersDocument = false;
            #endregion

            #region Edit Document DateTime - 5063
            // ویرایش تاریخ زمان مدرك مراجعه
            if (SecurityManager.GetCurrentUserPermission(5063) == false)
            {
                DateDoc.IsReadonly = true;
                TimeDoc.IsInputReadOnly = true;
                TimeDoc.ShowUpDown = false;
            }
            #endregion

            #region Edit Ref Services - 5065
            // ویرایش كادر پزشكی خدمات مراجعه
            if (SecurityManager.GetCurrentUserPermission(5065) == false)
            {
                btnSetRefServicePhysicians.Visible = false;
                cboTypist.Left = cboDocType.Left;
                cboTypist.Width = cboDocType.Width;
            }
            #endregion

            #region Send SMS To Patient - 5103
            // امكان ارسال پیام كوتاه اعلام اتمام گزارش به بیمار
            if (SecurityManager.GetCurrentUserPermission(5103) == false) _CanSendSMS = false;
            else _CanSendSMS = true;
            #endregion

            if (!LicenseHelper.GetSavedLicenses().Contains("555"))
            {
                btnCapture.Visible = false;
                btnImport.ImagePosition = eImagePosition.Top;
            }

            return true;
        }
        #endregion

        #region Boolean ReadCurrentUserSettings()
        /// <summary>
        /// تابع اعمال تنظیمات فرم بر كنترل ها
        /// </summary>
        /// <returns>صحت انجام كار</returns>
        private Boolean ReadCurrentUserSettings()
        {
            #region 701
            // تاریخ مدرك جدید به صورت پیش فرض برابر تاریخ مراجعه ی مدرك باشد
            List<UsersSetting> Setting701 =
                DBLayerIMS.Settings.CurrentUserSettingsFullList.Where(Data => Data.SettingIX == 701).ToList();
            if (Setting701.Count > 0 && Setting701.First().Boolean == true)
                _ShouldDocTimeEqualRefTime = true;
            #endregion

            #region 702
            // نوع مدرك پیش فرض برای كاربر جاری
            List<UsersSetting> Setting702 =
                DBLayerIMS.Settings.CurrentUserSettingsFullList.Where(Data => Data.SettingIX == 702).ToList();
            if (Setting702.Count > 0 && Setting702.First().Value != null)
                _DefaultDocType = Convert.ToInt16(Setting702.First().Value);
            #endregion

            // پزشك متخصص پیش فرض مدرك برای كاربر جاری - 703 - حذف شد
            // نمایش نوار فرمان ویرایشگر - 704 - حذف شد
            // عنوان مدرك به صورت چپ به راست باشد - 705 - حذف شد
            return true;
        }
        #endregion

        #endregion

        #region +++ public void AddNewDocument(Int32 RefID) +++
        /// <summary>
        /// روال ثبت مدرك جدید برای یك مراجعه
        /// </summary>
        /// <param name="RefID">كلید مراجعه</param>
        public void AddNewDocument(Int32 RefID)
        {
            if (!_CanAddNewDocument)
            {
                PMBox.Show("كاربر جاری دسترسی لازم برای افزودن مدرك به مراجعات تصویربرداری بیماران را ندارد!",
                    "محدودیت دسترسی!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                _IsFormHaveError = true; Close(); return;
            }
            if (!_CanAddNewSeveralReports)
            {
                try
                {
                    Int32 CurrentRefDocCount = DBLayerIMS.Manager.DBML.RefDocuments.
                        Where(Data => Data.RefIX == RefID).Count();
                    if (CurrentRefDocCount > 0)
                    {
                        PMBox.Show("كاربر جاری دسترسی لازم برای ثبت بیش از 1 جواب برای بیمار را ندارد.",
                            "محدودیت دسترسی!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        _IsFormHaveError = true; Close(); return;
                    }
                }
                #region Catch
                catch (Exception Ex)
                {
                    const String ErrorMessage = "امكان خواندن تعداد جواب های مراجعه جاری وجود ندارد.\n" +
                        "موارد زیر را بررسی نمایید:\n" +
                        "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogManager.SaveLogEntry("Sepehr", "Manage Doc Form", Ex.Message + "\n" + Ex.StackTrace,
                        EventLogEntryType.Error); return;
                }
                #endregion
            }
            if (!_CanAddNewSeveralReportsByOthers)
            {
                try
                {
                    Int32 CurrentRefDocCount = DBLayerIMS.Manager.DBML.RefDocuments.
                        Where(Data => Data.RefIX == RefID &&
                            Data.TypistIX != SecurityManager.CurrentUserID).Count();
                    if (CurrentRefDocCount > 0)
                    {
                        PMBox.Show("كاربر جاری دسترسی لازم برای ثبت بیش از 1 جواب" +
                            " برای بیمار دارای مدرك ثبت شده توسط سایر كاربران را ندارد.",
                            "محدودیت دسترسی!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        _IsFormHaveError = true; Close(); return;
                    }
                }
                #region Catch
                catch (Exception Ex)
                {
                    const String ErrorMessage = "امكان خواندن تعداد جواب های مراجعه جاری وجود ندارد.\n" +
                        "موارد زیر را بررسی نمایید:\n" +
                        "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogManager.SaveLogEntry("Sepehr", "Manage Doc Form", Ex.Message + "\n" + Ex.StackTrace,
                        EventLogEntryType.Error); return;
                }
                #endregion
            }
            Negar.DBLayerPMS.Manager.ReleaseCachedFiles();
            Negar.DBLayerPMS.Manager.DBML = null;
            DBLayerIMS.Manager.ReleaseCachedFiles();
            DBLayerIMS.Manager.DBML = null;
            _CurrentRefData = null;
            _CurrentRefID = 0;
            _CurrentDoc = null;
            _CurrentDoc = new RefDocument();
            _CurrentDocID = null;
            _IsNewDoc = true;
            _DocFilePath = Application.StartupPath + "\\Document" +
                DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + ".";
            _CurrentRefID = RefID;
            _CurrentDocID = null;
            // در صورت وجود قالب مدرك پیش فرض ، این قسمت بررسی می شود
            IEnumerable<SP_SelectTemplatesResult> DefaultTemplates =
                _TemplatesList.Where(Data => Data.IsDefault == true);
            if (DefaultTemplates.Count() != 0)
            {
                if (!LoadDocTemplateInWord(DefaultTemplates.First().ID, false))
                { _IsFormHaveError = true; Close(); return; }
            }
            #region Create New Empty Document File
            else
            {
                // اگر فایل مدرك پیش فرض موجود باشد ، یك فایل خالی از آن ایجاد میشود
                #region Copy Last Saved File
                if (File.Exists(Application.StartupPath + "\\EmptyDocument.Doc"))
                    try
                    {
                        File.Copy(Application.StartupPath + "\\EmptyDocument.Doc", _DocFilePath + "Doc");
                    }
                    #region Catch
                    catch (Exception Ex)
                    {
                        LogManager.SaveLogEntry("Sepehr", "Documents Forms", Ex.Message + "\n" +
                            Ex.StackTrace, EventLogEntryType.Error); _IsFormHaveError = true;
                        const String ErrorMessage = "امكان كپی كردن فایل قالب روی هارد ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. ممكن است یكی نرم افزار ورد توسط فایل هایی كه خارج از برنامه باز كرده اید قفل شده باشد.\n" +
                            "آیا مایلید تمام فایل های باز مانده بسته شود؟ قبل از تایید ، تمام فایل های ذخیره نشده را ببندید.";
                        DialogResult Result = PMBox.Show(ErrorMessage, "خطا! پرسش؟ هشدار!",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                        if (Result == DialogResult.Yes)
                            try
                            {
                                foreach (System.Diagnostics.Process Word in Process.GetProcessesByName("WINWORD")) Word.Kill();
                            }
                            catch { }
                        Close(); return;
                    }
                    #endregion
                #endregion
                // اگر فایل پیش فرض وجود نداشته باشد یك فایل خالی ساخته می شود
                #region Add New Empty File
                // اگر فایل پیش فرض وجود نداشته باشد یك فایل خالی ساخته می شود
                else
                {
                    try
                    {
                        DocumentClass _WordDoc = new DocumentClass();
                        Range range = _WordDoc.Range(ref _Missing, ref _Missing);
                        range.Text = " ";
                        Object BooleanFalse = false;
                        Object FileFormat = WdSaveFormat.wdFormatDocument;
                        Object EmptyTemplate = Application.StartupPath + "\\EmptyDocument.Doc";
                        _WordDoc.SaveAs(ref EmptyTemplate, ref FileFormat,
                            ref _Missing, ref _Missing, ref _Missing, ref _Missing, ref BooleanFalse, ref _Missing, ref _Missing,
                            ref _Missing, ref _Missing, ref _Missing, ref _Missing, ref _Missing, ref _Missing, ref _Missing);
                        // ReSharper disable RedundantCast
                        ((ApplicationClass)((DocumentClass)_WordDoc).Application).Quit(ref BooleanFalse, ref _Missing, ref _Missing);
                        // ReSharper restore RedundantCast
                        if (File.Exists(Application.StartupPath + "\\EmptyDocument.Doc"))
                            File.Copy(Application.StartupPath + "\\EmptyDocument.Doc", _DocFilePath + "Doc");
                    }
                    #region Catch
                    catch (Exception Ex)
                    {
                        LogManager.SaveLogEntry("Sepehr", "Documents Forms", Ex.Message + "\n" +
                            Ex.StackTrace, EventLogEntryType.Error); _IsFormHaveError = true;
                        const String ErrorMessage = "امكان باز كردن نرم افزار وُرد مایكروسافت ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا برنامه وُرد نصب شده است؟\n" +
                            "ممكن است یكی نرم افزار ورد توسط فایل هایی كه خارج از برنامه باز كرده اید قفل شده باشد.\n" +
                            "آیا مایلید تمام فایل های باز مانده بسته شود؟ قبل از تایید ، تمام فایل های ذخیره نشده را ببندید.";
                        DialogResult Result = PMBox.Show(ErrorMessage, "خطا! پرسش؟ هشدار!",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                        if (Result == DialogResult.Yes)
                            try
                            {
                                foreach (System.Diagnostics.Process Word in Process.GetProcessesByName("WINWORD")) Word.Kill();
                            }
                            catch { }
                        Close(); return;
                    }
                    #endregion
                }
                #endregion
                // تغییر حالت فایل تولید شده به قابل خواندن
                try { File.SetAttributes(_DocFilePath + "Doc", FileAttributes.Normal); }
                catch { }
            }
            #endregion
            if (!LoadCurrentPatAndRefData())
            {
                PMBox.Show("امکان خواندن اطلاعات بیمار یا مراجعه انتخاب شده وجود ندارد!", "خطا!");
                _IsFormHaveError = true; Close(); return;
            }
            Opacity = 0.01;
            Show();
        }
        #endregion

        #region void SetControlsAddingStateProperties()
        /// <summary>
        /// تنظیمات پایه ای كه در فرم تنها در هر اجرا برای ثبت مدرك جدید اعمال می شود
        /// </summary>
        private void SetControlsAddingStateProperties()
        {
            // اگر قبلاً در حالت ویرایش این كنترل ها به خاطر دسترسی كاربر غیر فعال شده باشند ، فعال می شوند
            if (!cboDocType.Enabled) cboDocType.Enabled = true;
            if (!PanelActions.Controls.Contains(btnSave)) PanelActions.Controls.Add(btnSave);
            // در صورتی كه تنظیمات كاربر جاری برای ثبت تاریخ مدرك مساوی با تاریخ مراجعه باشد - این قسمت اعمال می شود
            if (_ShouldDocTimeEqualRefTime)
            {
                DateDoc.SelectedDateTime = _CurrentRefData.RegisterDate;
                TimeDoc.Value = _CurrentRefData.RegisterDate;
            }
            // در صورتی كه این تنظیم اعمال نشده باشد ، مدرك جدید با تاریخ جاری تنظیم می شود
            else
            {
                DateDoc.SelectedDateTime = DateTime.Now;
                TimeDoc.Value = DateTime.Now;
            }
            // تنظیم كاربر تایپیست جاری
            cboTypist.SelectedValue = SecurityManager.CurrentUserID;
            // تنظیم نوع مدرك پیش فرض
            if (_DefaultDocType != null &&
                _DocTypesList.Where(Data => Data.ID == _DefaultDocType.Value).Count() != 0)
                cboDocType.SelectedValue = _DefaultDocType.Value;
            else cboDocType.SelectedIndex = 0;
        }
        #endregion

        #region +++ public void EditRefDocument(Int32 DocID) +++
        /// <summary>
        /// روال ویرایش یك مدرك از مدارك یك مراجعه
        /// </summary>
        /// <param name="DocID">كلید مدرك</param>
        public void EditRefDocument(Int32 DocID)
        {
            if (!_CanEditDocument)
            {
                PMBox.Show("كاربر جاری دسترسی لازم برای ویرایش مدرك مراجعات تصویربرداری بیماران را ندارد!",
                    "محدودیت دسترسی!", MessageBoxButtons.OK, MessageBoxIcon.Stop); return;
            }
            Negar.DBLayerPMS.Manager.ReleaseCachedFiles();
            Negar.DBLayerPMS.Manager.DBML = null;
            DBLayerIMS.Manager.ReleaseCachedFiles();
            DBLayerIMS.Manager.DBML = null;
            _CurrentRefData = null;
            _CurrentRefID = 0;
            _CurrentDoc = null;
            _CurrentDocID = null;
            _IsNewDoc = false;
            _DocFilePath = Application.StartupPath + "\\Document" +
                DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + ".";
            _CurrentDocID = DocID;
            if (!LoadDocData(_CurrentDocID.Value)) { _IsFormHaveError = true; Close(); return; }
            #region Find Document RefID
            // خواندن كلید مراجعه ی مدرك انتخاب شده
            List<Int32> RefList;
            try
            {
                RefList = DBLayerIMS.Manager.DBML.RefDocuments.Where(Data => Data.ID == _CurrentDocID).
                    Select(Data => Data.RefIX).ToList();
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان خواندن اطلاعات مراجعه ی مدرك انتخاب شده از بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Documents Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return;
            }
            #endregion
            // اگر مراجعه ای با كلید ارسال شده وجود نداشته باشد فرم بسته می شود
            if (RefList.Count == 0)
            {
                PMBox.Show("مراجعه ای با كلید مدرك ارسال شده در سیستم یافت نمی شود!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                _IsFormHaveError = true; Close(); return;
            }
            _CurrentRefID = RefList.First();
            #endregion
            if (!LoadCurrentPatAndRefData()) { _IsFormHaveError = true; Close(); return; }
            btnSave.Text = "ذخیره";
            Opacity = 0.01;
            Show();
        }
        #endregion

        #region void SetControlsEditingStateProperties()
        /// <summary>
        /// تنظیمات پایه ای كه در فرم تنها در هر اجرا برای ویرایش مدرك ثبت شده اعمال می شود
        /// </summary>
        private void SetControlsEditingStateProperties()
        {
            if (_CurrentDoc.TypeIX != null)
            {
                if (((List<SP_SelectTypeResult>)cboDocType.DataSource).
                    Where(Data => Data.ID == _CurrentDoc.TypeIX).ToList().Count == 0)
                    cboDocType.DataSource = _DocTypesList.
                        Where(Data => Data.IsActive == 1 || Data.ID == _CurrentDoc.TypeIX).ToList();
                cboDocType.SelectedValue = _CurrentDoc.TypeIX;
            }
            else cboDocType.SelectedIndex = 0;
            cboTypist.SelectedValue = _CurrentDoc.TypistIX;
            DateDoc.SelectedDateTime = _CurrentDoc.Date;
            TimeDoc.Value = _CurrentDoc.Date;
        }
        #endregion

        // ==========================================

        #region @O@ Boolean OpenDocInWord(Boolean ShowDocument) @O@
        /// <summary>
        /// روالی برای باز كردن فایل آفیس مدرك در كنترل
        /// </summary>
        private Boolean OpenDocInWord(Boolean ShowDocument)
        {
            #region Close Current Word Object And Init New Word Application If It Is Not Initialize
            // ReSharper disable EmptyGeneralCatchClause
            Object FalseValue = false;
            if (_CurrentWordDocument != null)
            {
                try
                {
                    _CurrentWordApp.ApplicationEvents2_Event_Quit -= CurrentWordApp_OnQuit;
                    _CurrentWordDocument.Close(ref FalseValue, ref _Missing, ref _Missing);
                }
                catch (Exception) { }
                _CurrentWordDocument = null;
            }
            if (_CurrentWordApp == null)
            {
                try { _CurrentWordApp = new ApplicationClass(); }
                #region Catch
                catch (Exception Ex)
                {
                    const String ErrorMessage =
                    "امكان باز كردن برنامه ورد مایكروسافت ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا این برنامه بر روی سیستم شما نصب می باشد؟";
                    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogManager.SaveLogEntry("Sepehr", "Documents Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                    _IsFormHaveError = true;
                    return false;
                }
                #endregion
            }
            // ReSharper restore EmptyGeneralCatchClause
            _CurrentWordApp.ApplicationEvents2_Event_Quit += CurrentWordApp_OnQuit;
            #endregion
            try
            {
                _CurrentWordApp.Visible = false;
                Object FilePath = _DocFilePath + "Doc";
                _CurrentWordDocument = (DocumentClass)_CurrentWordApp.Documents.Open(ref FilePath, ref _Missing,
                    ref _Missing, ref _Missing, ref _Missing, ref _Missing, ref _Missing, ref _Missing, ref _Missing, ref _Missing,
                    ref _Missing, ref _Missing, ref _Missing, ref _Missing, ref _Missing, ref _Missing);
                _CurrentWordApp.ShowWindowsInTaskbar = true;
                _CurrentWordApp.WindowState = WdWindowState.wdWindowStateMaximize;
                _CurrentWordApp.Visible = ShowDocument;
                if (ShowDocument)
                {
                    _CurrentWordApp.ShowMe();
                    _CurrentWordApp.Activate();
                    _CurrentWordDocument.Activate();
                    _CurrentWordDocument.Select();
                }
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                "امكان خواندن اطلاعات نرم افزار ورد مایكروسافت ممكن نیست.\n" +
                "موارد زیر را بررسی نمایید:\n" +
                "1. آیا این برنامه بر روی سیستم شما نصب می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Documents Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                _IsFormHaveError = true;
                return false;
            }
            #endregion
            return true;
        }
        #endregion

        // ==========================================

        #region Boolean LoadCurrentPatAndRefData()
        /// <summary>
        /// پركردن اطلاعات بیمار و مراجعه فرم
        /// </summary>
        /// <returns>صحت انجام</returns>
        private Boolean LoadCurrentPatAndRefData()
        {
            _CurrentRefData = DBLayerIMS.Referrals.GetRefDataByID(_CurrentRefID);
            if (_CurrentRefData == null) return false;
            PatList PatientsData = Negar.DBLayerPMS.Patients.GetPatFullDataByPatListID(_CurrentRefData.PatientIX);
            if (PatientsData == null) return false;

            #region Read Ref Date
            PersianDate PersianRegDate = _CurrentRefData.RegisterDate.ToPersianDate();
            lblRefDate.Text = PersianRegDate.Hour + ":" + PersianRegDate.Minute + ":" + PersianRegDate.Second + " - " +
                PersianRegDate.Year + "/" + PersianRegDate.Month + "/" + PersianRegDate.Day;
            #endregion

            #region Fill Patient Controls
            lblPatientID.Text = PatientsData.PatientID;
            if (String.IsNullOrEmpty(PatientsData.FirstName)) lblPatientFullName.Text = PatientsData.LastName;
            else lblPatientFullName.Text = PatientsData.FirstName + " " + PatientsData.LastName;
            #endregion
            return true;
        }
        #endregion

        #region Boolean LoadDocData(Int32 DocumentID)
        /// <summary>
        /// تابع خواندن اطلاعات و فایل مدرك در ویرایشگر
        /// </summary>
        /// <param name="DocumentID">كلید مدرك</param>
        /// <returns>صحت انجام كار</returns>
        private Boolean LoadDocData(Int32 DocumentID)
        {
            try
            {
                _CurrentDoc = DBLayerIMS.Manager.DBML.
                    RefDocuments.Where(Data => Data.ID == DocumentID).First();
                DBLayerIMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, _CurrentDoc);
                if (SecurityManager.CurrentUserID != _CurrentDoc.TypistIX && !_CanEditOthersDocument)
                {
                    PMBox.Show("كاربر جاری دسترسی لازم برای ویرایش مدرك ثبت شده توسط سایر كاربران را ندارد!",
                        "محدودیت دسترسی!", MessageBoxButtons.OK, MessageBoxIcon.Stop); return false;
                }
                Binary CurrentDocumentFile = DBLayerIMS.Document.GetRefDocBinaryByDocID(_CurrentDoc.ID);
                File.Create(_DocFilePath + "Zip").Close();
                if (CurrentDocumentFile != null) File.WriteAllBytes(_DocFilePath + "Zip", CurrentDocumentFile.ToArray());

                #region Unzip Document
                Zip ZipHelper = new Zip();
                ZipHelper.UnlockComponent("ZIP-TEAMBEAN_4F46F322914X");
                Boolean IsOpenedZipFile = ZipHelper.OpenZip(_DocFilePath + "Zip");
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
                if (File.Exists(_DocFilePath + "Zip")) File.Delete(_DocFilePath + "Zip");
                if (File.Exists(_RefDocPath))
                {
                    File.SetAttributes(_RefDocPath, FileAttributes.Normal);
                    File.Copy(_RefDocPath, _DocFilePath + "Doc");
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
                LogManager.SaveLogEntry("Sepehr", "Documents Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion
            return true;
        }
        #endregion

        #region Boolean LoadDocTemplateInWord(Int32 TemplateID, Boolean ShowTemplate)
        /// <summary>
        /// تابع خواندن فایل قالب مدرك در ویرایشگر
        /// </summary>
        /// <param name="TemplateID">كلید قالب</param>
        /// <param name="ShowTemplate">تعیی نمایش فایل قالب</param>
        /// <returns>صحت انجام كار</returns>
        private Boolean LoadDocTemplateInWord(Int32 TemplateID, Boolean ShowTemplate)
        {
            #region Close Current Word Application Object
            // ReSharper disable EmptyGeneralCatchClause
            if (_CurrentWordDocument != null)
            {
                try
                {
                    _CurrentWordApp.ApplicationEvents2_Event_Quit -= CurrentWordApp_OnQuit;
                    _CurrentWordDocument.Close(ref _Missing, ref _Missing, ref _Missing);
                }
                catch (Exception) { }
                _CurrentWordDocument = null;
            }
            // ReSharper restore EmptyGeneralCatchClause
            #endregion
            try
            {
                // خواندن فایل باینری فشرده شده ی قالب
                SP_SelectTemplatesResult TemplateData = _TemplatesList.Where(Data => Data.ID == TemplateID).First();
                _CurrentDoc.Title = TemplateData.Name;
                // حذف فایل های مقصدی كه فرم بر اساس زمان سیستم تولید كرده در صورت وجود
                if (File.Exists(_DocFilePath + "Doc")) File.Delete(_DocFilePath + "Doc");
                // ایجاد فایل زیپ قالب مورد نظر به صورت خالی
                File.Create(_DocFilePath + "Zip").Close();
                // ریختن اطلاعات باینری فایل فشرده شده ی قالب
                Binary BinaryData = DBLayerIMS.Document.GetDocTemplateBinaryData(TemplateData.ID);
                if (BinaryData != null) File.WriteAllBytes(_DocFilePath + "Zip", BinaryData.ToArray());
                #region Unzip Document
                Zip ZipHelper = new Zip();
                ZipHelper.UnlockComponent("ZIP-TEAMBEAN_4F46F322914X");
                Boolean IsOpenedZipFile = ZipHelper.OpenZip(_DocFilePath + "Zip");
                if (!IsOpenedZipFile) throw new Exception(ZipHelper.LastErrorText);
                Int32 FilesCount = ZipHelper.Unzip(Application.StartupPath);
                if (FilesCount == -1) throw new Exception(ZipHelper.LastErrorText);
                ZipHelper.CloseZip();
                ZipHelper.Dispose();
                if (File.Exists(_DocFilePath + "Zip")) File.Delete(_DocFilePath + "Zip");
                if (File.Exists("RefDocTemplate.Doc"))
                    File.Copy(Application.StartupPath + "\\RefDocTemplate.Doc", _DocFilePath + "Doc");
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
                    EventLogEntryType.Error); return false;
            }
            #endregion
            if (!OpenDocInWord(false)) return false;
            if (!DocTemplateFormulaManager.ReplaceDocFormulas(_CurrentRefID,
                _CurrentWordApp, _CurrentWordDocument, ShowTemplate))
            {
                const String ErrorMessage = "امكان جانشانی فرمول های قالب مدرك ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        #endregion

        #region void ReplaceCapturedImages()
        /// <summary>
        /// تابعی برای جایگزین كردن تصاویر كپچر شده در مدرك
        /// </summary>
        private void ReplaceCapturedImages()
        {
            String[] PictureFileList = Negar.Medical.VideoCapture.CaptureHelper.GetRefDataFilesList(_CurrentRefID, "*.Jpg");
            for (Int32 i = 0; i <= 50; i++)
            {
                Range Rng = _CurrentWordDocument.Range(ref _Missing, ref _Missing);
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
                        Rng = _CurrentWordDocument.Range(ref _Missing, ref _Missing);
                        if (File.Exists(PictureFileList[i]))
                        {
                            if (Rng.Find.Execute(ref TextToFind, ref _Missing, ref _Missing, ref _Missing, ref _Missing, ref _Missing,
                                ref _Missing, ref _Missing, ref _Missing, ref _Missing, ref _Missing,
                                ref _Missing, ref _Missing, ref _Missing, ref _Missing))
                            {
                                Object TempRange = Rng;
                                InlineShape NewPic = Rng.InlineShapes.AddPicture(PictureFileList[i], ref _Missing, ref _Missing, ref TempRange);
                                NewPic.Width = DocTemplateFormulaManager.CapturePicWidth;
                                NewPic.Height = DocTemplateFormulaManager.CapturePicHeight;
                            }
                            Rng = _CurrentWordDocument.Range(ref _Missing, ref _Missing);
                            DocTemplateFormulaManager.ReplaceDocFormula(Rng, "NegarCapturePic" + (i + 1), String.Empty);
                        }
                        else break;
                    }
                }
            }
        }
        #endregion

        #region *** Boolean InsertNewDocument() ***
        /// <summary>
        /// ثبت یك مدرك جدید برای مراجعه ی جاری
        /// </summary>
        /// <returns>ٌصحت انجام كار</returns>
        private Boolean InsertNewDocument()
        {
            #region Close Current Word Object
            // ReSharper disable EmptyGeneralCatchClause
            try { _CurrentWordApp.ApplicationEvents2_Event_Quit -= CurrentWordApp_OnQuit; }
            catch (Exception) { }
            if (_CurrentWordDocument != null)
            {
                Object FilePath = _DocFilePath + "Doc";
                Object FileFormat = WdSaveFormat.wdFormatDocument;
                try
                {
                    _CurrentWordDocument.SaveAs(ref FilePath, ref FileFormat, ref _Missing, ref _Missing, ref _Missing
                        , ref _Missing, ref _Missing, ref _Missing, ref _Missing, ref _Missing, ref _Missing, ref _Missing
                        , ref _Missing, ref _Missing, ref _Missing, ref _Missing);
                }
                catch (Exception) { }
                try { _CurrentWordDocument.Close(ref _Missing, ref _Missing, ref _Missing); }
                catch (Exception) { }
                _CurrentWordDocument = null;
            }
            // ReSharper restore EmptyGeneralCatchClause
            #endregion

            #region Read Form Data

            #region Date & Times
            // تاریخ و ساعت مراجعه
            DateTime DocDate = new DateTime(DateDoc.SelectedDateTime.Value.Year,
                DateDoc.SelectedDateTime.Value.Month, DateDoc.SelectedDateTime.Value.Day,
                TimeDoc.Value.Hour, TimeDoc.Value.Minute, TimeDoc.Value.Second, TimeDoc.Value.Millisecond);
            #endregion

            #region Combo Boxes
            Int16? TypeID = null;
            if (cboDocType.SelectedIndex != 0) TypeID = Convert.ToInt16(cboDocType.SelectedValue);
            Int16 TypistID = Convert.ToInt16(cboTypist.SelectedValue);
            #endregion

            #endregion

            #region Zip Document Data
            try
            {
                if (File.Exists(_DocFilePath + "Zip")) File.Delete(_DocFilePath + "Zip");
                Zip ZipHelper = new Zip();
                ZipHelper.UnlockComponent("ZIP-TEAMBEAN_4F46F322914X");
                // نام فایلی كه باید برای زیپ تولید شود
                ZipHelper.NewZip(_DocFilePath + "Zip");
                // فایل هایی كه باید به زیپ اضافه شوند اینجا تخصیص می باید
                ZipHelper.AppendFiles(_DocFilePath + "Doc", true);
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
            Binary BinaryData = File.ReadAllBytes(_DocFilePath + "Zip");
            _CurrentDoc.RefIX = _CurrentRefID;
            _CurrentDoc.TypeIX = TypeID;
            _CurrentDoc.Date = DocDate;
            _CurrentDoc.IsReport = true;
            _CurrentDoc.TypistIX = TypistID;
            _CurrentDoc.Extension = "doc";
            DBLayerIMS.Manager.DBML.RefDocuments.InsertOnSubmit(_CurrentDoc);
            if (!DBLayerIMS.Manager.Submit())
            {
                const String ErrorMessage = "امكان ذخیره سازی فایل مدرك جاری ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
            }
            _CurrentDoc.DocPath = ((_CurrentDoc.ID / 1000) + 1) + "\\" + _CurrentDoc.ID + ".zip";
            if (!DBLayerIMS.Manager.Submit())
            {
                const String ErrorMessage = "امكان ذخیره سازی فایل مدرك جاری ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
            }
            #endregion

            DBLayerIMS.Document.SetRefDocBinaryByDocID(_CurrentDoc.ID, BinaryData);
            if (File.Exists(_DocFilePath + "Zip")) File.Delete(_DocFilePath + "Zip");
            _IsNewDoc = false;
            return true;
        }
        #endregion

        #region *** Boolean UpdateDocument() ***
        /// <summary>
        /// تابع به روز رسانی مدرك جاری
        /// </summary>
        /// <returns>صحت انجام كار</returns>
        private Boolean UpdateDocument()
        {
            #region Read Form Data

            #region Date & Times
            // تاریخ و ساعت مراجعه
            DateTime DocDate = new DateTime(DateDoc.SelectedDateTime.Value.Year, DateDoc.SelectedDateTime.Value.Month,
                DateDoc.SelectedDateTime.Value.Day, TimeDoc.Value.Hour, TimeDoc.Value.Minute,
                TimeDoc.Value.Second, TimeDoc.Value.Millisecond);
            #endregion

            #region Combo Boxes
            Int16? TypeID = null;
            if (cboDocType.SelectedIndex != 0) TypeID = Convert.ToInt16(cboDocType.SelectedValue);
            Int16 TypistID = Convert.ToInt16(cboTypist.SelectedValue);
            #endregion

            #endregion

            #region Close Current Word Object
            // ReSharper disable EmptyGeneralCatchClause
            try { _CurrentWordApp.ApplicationEvents2_Event_Quit -= CurrentWordApp_OnQuit; }
            catch (Exception) { }
            if (_CurrentWordDocument != null)
            {
                Object FilePath = _DocFilePath + "Doc";
                Object FileFormat = WdSaveFormat.wdFormatDocument;
                try
                {
                    _CurrentWordDocument.SaveAs(ref FilePath, ref FileFormat, ref _Missing, ref _Missing, ref _Missing
                        , ref _Missing, ref _Missing, ref _Missing, ref _Missing, ref _Missing, ref _Missing, ref _Missing
                        , ref _Missing, ref _Missing, ref _Missing, ref _Missing);
                }
                catch (Exception) { }
                try { _CurrentWordDocument.Close(ref _Missing, ref _Missing, ref _Missing); }
                catch (Exception) { }
                _CurrentWordDocument = null;
            }
            // ReSharper restore EmptyGeneralCatchClause
            #endregion

            #region Zip Document Data
            try
            {
                if (File.Exists(_DocFilePath + "Zip")) File.Delete(_DocFilePath + "Zip");
                Zip ZipHelper = new Zip();
                ZipHelper.UnlockComponent("ZIP-TEAMBEAN_4F46F322914X");
                // نام فایلی كه باید برای زیپ تولید شود
                ZipHelper.NewZip(_DocFilePath + "Zip");
                // فایل هایی كه باید به زیپ اضافه شوند اینجا تخصیص می باید
                ZipHelper.AppendFiles(_DocFilePath + "Doc", true);
                // Write Zip File
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

            #region Update Current Doc To Db
            Binary BinaryData;
            if (_CanEditDocument) BinaryData = File.ReadAllBytes(_DocFilePath + "Zip");
            else BinaryData = DBLayerIMS.Document.GetRefDocBinaryByDocID(_CurrentDoc.ID);
            _CurrentDoc.RefIX = _CurrentRefID;
            _CurrentDoc.IsReport = true;
            _CurrentDoc.TypeIX = TypeID;
            _CurrentDoc.Date = DocDate;
            _CurrentDoc.TypistIX = TypistID;
            if (!DBLayerIMS.Manager.Submit())
            {
                const String ErrorMessage = "امكان ذخیره سازی فایل مدرك جاری ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
            }
            DBLayerIMS.Document.SetRefDocBinaryByDocID(_CurrentDoc.ID, BinaryData);
            #endregion
            if (File.Exists(_DocFilePath + "Zip")) File.Delete(_DocFilePath + "Zip");
            return true;
        }
        #endregion

        #endregion

    }
}