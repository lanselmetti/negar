#region using

using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Negar;
using Negar.DBLayerPMS.DataLayer;
using Negar.PersianCalendar.UI.Controls;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors;
using DevComponents.Editors.DateTimeAdv;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Forms.Account;
using Sepehr.Forms.Admission.Classes;
using Sepehr.Forms.Admission.Properties;
using Sepehr.Forms.Documents;
using Sepehr.Forms.Documents.Classes;

#endregion

namespace Sepehr.Forms.Admission.Referrals
{
    /// <summary>
    /// فرم مدیریت بیمار و مراجعه
    /// </summary>
    internal partial class frmPatRefManager : Form
    {

        #region Enums
        /// <summary>
        /// وضعیت فرم مدیریت مراجعات بیماران
        /// </summary>
        public enum RefFormState
        {
            /// <summary>
            /// حالت ثبت مراجعه جدید برای یك بیمار جدید
            /// </summary>
            AddingPatRef = 1,
            /// <summary>
            /// حالت ثبت مراجعه جدید برای یك بیمار ثبت شده
            /// </summary>
            AddingRef = 2,
            /// <summary>
            /// حالت ویرایش بیمار و مراجعه مشخص آن بیمار
            /// </summary>
            Editing = 3,
            /// <summary>
            /// حالت نمایش یكی از  مراجعات یك بیمار
            /// </summary>
            Viewing = 4
        } ;
        #endregion

        #region Fields & Properties

        #region CurrentFormState  _FormState
        /// <summary>
        /// وضعیت فرم مدیریت بیمار و مراجعه  در سه حالت افزودن , ویرایش و نمایش
        /// </summary>
        private RefFormState _FormState;
        #endregion

        #region RefFormState CurrentFormState
        /// <summary>
        /// وضعیت فرم جاری
        /// </summary>
        private RefFormState CurrentFormState
        {
            get { return _FormState; }
            set
            {
                if (value == RefFormState.AddingPatRef) ChangeToAddingPatState();
                else if (value == RefFormState.AddingRef) ChangeToAddingRefState();
                else if (value == RefFormState.Viewing) ChangeToViewState();
                else if (value == RefFormState.Editing) ChangeToEditState();
                _FormState = value;
            }
        }
        #endregion

        #region PatList _CurrentPatientData
        /// <summary>
        /// فیلد اطلاعات بیمار جاری
        /// </summary>
        private PatList _CurrentPatientData;
        #endregion

        #region Int32 CurrentPatientListID
        /// <summary>
        /// کد مراجعه  جاری فرم
        /// </summary>
        private Int32 CurrentPatientListID
        {
            get { return _CurrentPatientData.ID; }
            set
            {
                if (value != 0)
                    // اگر مقدار ارسالی غیر از صفر باشد ، اطلاعات بیمار دریافتی را بر روی فرم نمایش می دهد
                    // اگر خطایی در نمایش رخ دهد ، فرم به حالت ثبت بیمار جدید تغییر حالت می دهد
                    // در حالت غیر صفر ، كنترل وضعیت نمایش فرم به عهده این خصوصیت نیست
                    // اگر بیمار مورد نظر پیدا نشود یا خطایی در جستجوی بیمار 
                    // به وجود آید مقدار كلید بیمار جاری صفر می گردد
                    if (!FillPatientDataByID(value)) { _IsCurrentPatModified = false; Dispose(); }
            }
        }
        #endregion

        #region RefList _CurrentRefData
        /// <summary>
        /// شیء اطلاعات مراجعه جاری
        /// </summary>
        private RefList _CurrentRefData;
        #endregion

        #region Int32 CurrentRefID
        /// <summary>
        /// كلید مراجعه ی جاری
        /// </summary>
        private Int32 CurrentRefID
        {
            get { return _CurrentRefData.ID; }
            set
            {
                // نمایش یك مراجعه ی بیمار در صورتی كه خطایی رخ ندهد
                if (value != 0 && !FillRefDataByID(value)) { _IsCurrentPatModified = false; Dispose(); }
            }
        }
        #endregion

        #region List<RefService> _RefServices
        /// <summary>
        /// لیست خدمات ثبت شده برای مراجعه ی جاری
        /// </summary>
        private List<RefService> _RefServices;
        #endregion

        #region Int32? _CurrentSchID
        /// <summary>
        /// كلید نوبتی كه پذیرش جاری از آن ارسال شده است
        /// </summary>
        private Int32? _CurrentSchID;
        #endregion

        #region Boolean _IsCurrentPatModified
        /// <summary>
        /// تعیین ویرایش شدن بیمار جاری توسط كاربر از حالت اولیه
        /// </summary>
        private Boolean _IsCurrentPatModified;
        #endregion

        #region frmServicesSelection _frmChooseService
        /// <summary>
        /// فرم انتخاب خدمات برای افزودن به مراجعه
        /// </summary>
        private frmServicesSelection _frmChooseService;
        #endregion

        #region frmPrinterSelection _frmPrinterSelection
        private frmPrinterSelection _frmPrinterSelection;
        #endregion

        #region ACL Fields
        private Boolean _CanAddPatOrRef = true;
        private Boolean _CanAddMultipleRefs = true;
        private Boolean _CanEditReferral = true;
        private Boolean _CanEditReferralAfterPay = true;
        private Boolean _CanEditRefDate = true;
        private Boolean _CanEditServices = true;
        private Boolean _CanChangeServiceQuantity = true;
        private Boolean _CanChangeServiceActivation = true;
        private Boolean _CanChangeServiceActivationAfterPay = true;
        private Boolean _CanEditPatientFullName = true;
        private Boolean _CanEditInsData = true;
        private Boolean _CanChangeIns1 = true;
        private Boolean _CanEditIns1Num = true;
        private Boolean _CanEditIns1ExpireDate = true;
        private Boolean _CanEditIns1PageNum = true;
        private Boolean _CanChangeIns2 = true;
        private Boolean _CanEditIns2Num = true;
        private Boolean _IsBarcodeActive = true;
        private Boolean _CanEditPrescriptionDate = true;
        private Boolean _CanEditRefPhysician = true;
        #endregion

        #region Settings Fields
        private Boolean _ShouldEnterGender;
        private Int16? _AgeDetailsLimit;
        private Boolean _ShouldEnterBirthDay;
        private Boolean _ShouldSearchForSamePatient;
        private Boolean _ShouldSaveEnglishName;
        private Boolean _ShouldEnterTelNo1;
        private Boolean _ShouldEnterTelNo2;
        private Boolean _ShouldEnterAddress;
        private Boolean _ShouldEnterWeight;
        private Boolean _ShouldEnterPrescribeDate;
        private Boolean _ShouldEnterReferralPhysician;
        private Boolean _ShouldEnterRefStatus;
        private Boolean _ShouldEnterDescription;
        private Boolean _ShouldEnterIns1;
        private Boolean _ShouldEnterIns1Num;
        private Boolean _ShouldEnterIns1ExpireDate;
        private Boolean _ShouldEnterPageNo;
        private Boolean _ShouldEnterIns2;
        private Boolean _ShouldEnterIns2Num;
        private Boolean _ShouldEnterIns2ExpireDate;
        private Boolean _ShouldEnterServices;
        private Boolean _ShouldEnterServiceExpert;
        private Boolean _ShouldEnterServicePhysician;
        private Boolean _ShouldEnterPrePayment;
        private Boolean _CanAddMultipleServices;
        private Boolean _CanChangeAdmitter;
        private Boolean _ShouldWarnForInsExpireDate;
        private Boolean _ShouldWarnIns1Num;
        #endregion

        #region DateTime? _KeyPressTimer
        private DateTime? _KeyPressTimer;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده فرم برای افزودن یك بیمار جدید با مراجعه جدید
        /// </summary>
        public frmPatRefManager()
        {
            Cursor.Current = Cursors.WaitCursor;
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("Fa-Ir"));
            InitializeComponent();
            if (SecurityManager.CurrentUserID > 2 && (!ReadCurrentUserPermissions() ||
                !ReadCurrentUserSettings())) { Dispose(); return; }
            if (Negar.DBLayerPMS.Security.UsersList == null) { Dispose(); return; }
            dgvRefServices.AutoGenerateColumns = false;
            cboAdmitter.DataSource = Negar.DBLayerPMS.Security.UsersList.Where(Data => Data.ID != null).ToList();
            #region ColExpert
            cboServiceExpert.DataSource = DBLayerIMS.Referrals.RefServPerformers.
                Where(Data => Data.IsExpert == true && Data.IsActive == true).ToList();
            cboServiceExpert.DisplayMember = "FullName";
            cboServiceExpert.ValueMember = "ID";
            cboServiceExpert.SelectedIndex = 0;
            ColExpert.DataSource = DBLayerIMS.Referrals.RefServPerformers.Where(Data => Data.IsExpert == true).ToList();
            ColExpert.DataPropertyName = "ExpertIX";
            ColExpert.DisplayMember = "FullName";
            ColExpert.ValueMember = "ID";
            #endregion
            #region ColPhysician
            cboServicePhysician.DataSource = DBLayerIMS.Referrals.RefServPerformers.
                Where(Data => Data.IsPhysician == true && Data.IsActive == true).ToList();
            cboServicePhysician.DisplayMember = "FullName";
            cboServicePhysician.ValueMember = "ID";
            cboServicePhysician.SelectedIndex = 0;
            ColPhysician.DataSource = DBLayerIMS.Referrals.RefServPerformers.Where(Data => Data.IsPhysician == true).ToList();
            ColPhysician.DataPropertyName = "PhysicianIX";
            ColPhysician.ValueMember = "ID";
            ColPhysician.DisplayMember = "FullName";
            #endregion
            RibbonOrders.BackgroundHoverEnabled = false;
            RibbonOrders.BackgroundStyle.BackColor = Color.LightSkyBlue;
            RibbonOrders.BackgroundStyle.BackColor2 = Color.White;
            txtPatientID.TextBox.Font = new Font("B Zar", 12, FontStyle.Bold);
            txtPatientID.HeightInternal = 25;
            txtPatientID.TextBox.RightToLeft = RightToLeft.No;
            txtPatientID.TextBox.TextAlign = HorizontalAlignment.Center;
            SetFormControlsChangeEventHandlers();
            #region Fill Bill Templates
            if (BillPrintManager.CurrentUserBillTemplatesList == null || BillPrintManager.CurrentUserBillTemplatesList.Count == 0)
            { if (RibbonOrders.Items.Contains(btnPrint)) RibbonOrders.Items.Remove(btnPrint); }
            else
            {
                if (!RibbonOrders.Items.Contains(btnPrint)) RibbonOrders.Items.Add(btnPrint);
                cboPrintTemplates.ComboBoxEx.DrawMode = DrawMode.Normal;
                cboPrintTemplates.ComboBoxEx.DropDownStyle = ComboBoxStyle.DropDownList;
                cboPrintTemplates.ComboBoxEx.FlatStyle = FlatStyle.Standard;
                cboPrintTemplates.ComboBoxEx.DisplayMember = "Name";
                cboPrintTemplates.ComboBoxEx.ValueMember = "ID";
                foreach (SP_SelectBillTemplateResult BillTemplate in BillPrintManager.CurrentUserBillTemplatesList)
                    cboPrintTemplates.ComboBoxEx.Items.Add(BillTemplate);
                cboPrintTemplates.ComboBoxEx.SelectedIndex = 0;
            }
            #endregion
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
            RibbonOrders.InvalidateLayout();
            _IsCurrentPatModified = false;
            cBoxEnterPatAge.Checked = !cBoxEnterPatAge.Checked;
            cBoxEnterPatAge.Checked = !cBoxEnterPatAge.Checked;
        }
        #endregion

        #region btnClose_Click
        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        #endregion

        #region frmPatRefManager_Activated
        private void frmPatRefManager_Activated(object sender, EventArgs e)
        {
            if (CurrentFormState == RefFormState.AddingPatRef || CurrentFormState == RefFormState.AddingRef)
                if (String.IsNullOrEmpty(txtFirstName.Text)) txtFirstName.Focus();
        }
        #endregion

        #region FormControls_ValuesChanged
        /// <summary>
        /// دستگیره ی مدیریت ایجاد تغییرات در كنترل های اطلاعات بیمار
        /// </summary>
        void FormControls_ValuesChanged(object sender, EventArgs e)
        {
            // در صورتی كه یك مقدار در یك كنترل تغییر كند ، این متغیر تغییر می كند
            _IsCurrentPatModified = true;
            if (CurrentFormState != RefFormState.Viewing) _IsCurrentPatModified = true;
        }
        #endregion

        #region TextBoxes_Validating
        private static void TextBoxes_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.CurrentInputLanguage =
                InputLanguage.FromCulture(new System.Globalization.CultureInfo("Fa-Ir"));
            ((TextBoxX)sender).Text = ((TextBoxX)sender).Text.Trim();
        }
        #endregion

        #region @@@ Ribbon Buttons @@@

        #region btnPatientFile_Click
        private void btnPatientFile_Click(object sender, EventArgs e)
        {
            if (CurrentFormState != RefFormState.Viewing && !ManageFormState(RefFormState.Viewing)) return;
            AdmitHelper.EditPatient(CurrentPatientListID, true);
            BringToFront();
            Focus();
            CurrentPatientListID = CurrentPatientListID;
            if (CurrentPatientListID == 0) { _IsCurrentPatModified = false; Close(); return; }
        }
        #endregion

        #region btnFreePatAndRef_Click
        private void btnFreePatAndRef_Click(object sender, EventArgs e)
        {
            if (CurrentFormState != RefFormState.Viewing) return;
            DialogResult Result = PMBox.Show("آیا مایلید بیمار و مراجعه جاری را از حالت قفل خارج نمایید؟", "پرسش؟",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Result != DialogResult.Yes) return;
            Negar.DBLayerPMS.Patients.ChangePatLock(CurrentPatientListID, false);
            DBLayerIMS.Referrals.ChangeRefLock(CurrentRefID, false);
        }
        #endregion

        #region btnRefAddinData_Click
        private void btnRefAddinData_Click(object sender, EventArgs e)
        {
            if (CurrentFormState != RefFormState.Viewing && CurrentFormState != RefFormState.Editing &&
                !ManageFormState(RefFormState.Editing)) return;
            if (CurrentFormState == RefFormState.Editing) new frmReferralsAdditionalData(CurrentRefID, RefFormState.Editing);
            else if (CurrentFormState == RefFormState.Viewing) new frmReferralsAdditionalData(CurrentRefID, RefFormState.Viewing);
            BringToFront();
            Focus();
        }
        #endregion

        #region btnAccount_Click
        /// <summary>
        /// فرمانی برای فراخوانی فرم حساب برای مراجعه جاری
        /// </summary>
        private void btnAccount_Click(object sender, EventArgs e)
        {
            if (CurrentFormState != RefFormState.Viewing && !ManageFormState(RefFormState.Viewing)) return;
            new frmAccount(CurrentRefID, false);
            BringToFront();
            Focus();
        }
        #endregion

        #region btnRefDocuments_Click
        private void btnRefDocuments_Click(object sender, EventArgs e)
        {
            if (CurrentFormState != RefFormState.Viewing && !ManageFormState(RefFormState.Viewing)) return;
            new frmDocuments(CurrentRefID, false);
            BringToFront();
            Focus();
        }
        #endregion

        #region btnNewDocument_Click
        private void btnNewDocument_Click(object sender, EventArgs e)
        {
            if (CurrentFormState != RefFormState.Viewing && !ManageFormState(RefFormState.Viewing)) return;
            DocumentHelper.AddNewDocument(CurrentRefID);
            BringToFront();
            Focus();
        }
        #endregion

        #region SliderBillPrintCount_ValueChanged
        private void SliderBillPrintCount_ValueChanged(object sender, EventArgs e)
        {
            SliderBillPrintCount.Text = "تعداد چاپ: " + SliderBillPrintCount.Value + " نسخه";
        }
        #endregion

        #region btnPrint_Click
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (CurrentFormState != RefFormState.Viewing && !ManageFormState(RefFormState.Viewing)) return;
            if (_frmPrinterSelection != null && !_frmPrinterSelection.IsDisposed)
                frmPrinterSelection.PrinterManager.SetDefaultPrinter(_frmPrinterSelection.DefaultPrinterName);
            BillPrintManager.RefBillPrint(CurrentRefID, ((SP_SelectBillTemplateResult)cboPrintTemplates.ComboBoxEx.SelectedItem).ID,
                Convert.ToInt16(SliderBillPrintCount.Value));
        }
        #endregion

        #region btnPrintPreview_Click
        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            if (CurrentFormState != RefFormState.Viewing && !ManageFormState(RefFormState.Viewing)) return;
            BillPrintManager.RefBillPrintPreview(CurrentRefID,
                ((SP_SelectBillTemplateResult)cboPrintTemplates.ComboBoxEx.SelectedItem).ID);
        }
        #endregion

        #region btnPrintByOtherPrinter_Click
        private void btnPrintByOtherPrinter_Click(object sender, EventArgs e)
        {
            if (CurrentFormState != RefFormState.Viewing && !ManageFormState(RefFormState.Viewing)) return;
            if (_frmPrinterSelection == null || _frmPrinterSelection.IsDisposed)
                _frmPrinterSelection = new frmPrinterSelection();
            if (_frmPrinterSelection.IsDisposed) return;
            _frmPrinterSelection.ShowDialog();
            if (_frmPrinterSelection.DialogResult == DialogResult.OK)
            {
                frmPrinterSelection.PrinterManager.SetDefaultPrinter(
                    _frmPrinterSelection.lstPrinterList.SelectedItem.ToString());
                BillPrintManager.RefBillPrint(CurrentRefID, ((SP_SelectBillTemplateResult)cboPrintTemplates.ComboBoxEx.SelectedItem).ID,
                    Convert.ToInt16(SliderBillPrintCount.Value));
            }
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

        #endregion

        #region @@@ Panel Patient Data Event Handlers @@@

        #region cBoxMale_KeyPress
        private void cBoxMale_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') ((RadioButton)sender).Checked = true;
        }
        #endregion

        #region btnShownEnglishName_Click
        private void btnShownEnglishName_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(((Control)sender).Text)) return;
            if (((Control)sender).Name == "btnShowEnglishFirstName")
                new frmNamesTranslator(txtFirstName.Text.Trim(), true);
            else new frmNamesTranslator(txtLastName.Text.Trim(), false);
            BringToFront();
            Focus();
        }
        #endregion

        #region txtAge_ValueChanged
        /// <summary>
        /// در صورتی كه این روال فراخوانی شود ، مقدار سن بیمار ، مقدار تاریخ تولد وی را تغییر می دهد
        /// </summary>
        private void txtAge_ValueChanged(object sender, EventArgs e)
        {
            if (((IntegerInput)sender).Name == txtAgeYear.Name)
            {
                if (_AgeDetailsLimit != null)
                {
                    if (txtAgeYear.ValueObject != null && _AgeDetailsLimit.Value >= txtAgeYear.Value)
                    {
                        txtAgeMonth.Visible = true;
                        txtAgeDay.Visible = true;
                        cBoxEnterPatAge.Left = txtAgeDay.Left - cBoxEnterPatAge.Width - 5;
                    }
                    else
                    {
                        txtAgeMonth.Visible = false;
                        txtAgeDay.Visible = false;
                        cBoxEnterPatAge.Left = txtAgeYear.Left - cBoxEnterPatAge.Width - 5;
                    }
                }
                else cBoxEnterPatAge.Left = txtAgeYear.Left - cBoxEnterPatAge.Width - 5;
            }
            DateInputBirthDate.SelectedDateTimeChanged -= DateInputBirthDate_SelectedDateTimeChanged;
            DateInputBirthDate.SelectedDateTime = DateTime.Now.AddYears(-1 * txtAgeYear.Value)
                .AddMonths(-1 * txtAgeMonth.Value).AddDays(-1 * txtAgeDay.Value);
            DateInputBirthDate.SelectedDateTimeChanged += DateInputBirthDate_SelectedDateTimeChanged;
        }
        #endregion

        #region DateInputBirthDate_SelectedDateTimeChanged
        private void DateInputBirthDate_SelectedDateTimeChanged(object sender, EventArgs e)
        {
            txtAgeYear.ValueChanged -= txtAge_ValueChanged;
            txtAgeMonth.ValueChanged -= txtAge_ValueChanged;
            txtAgeDay.ValueChanged -= txtAge_ValueChanged;
            if (DateInputBirthDate.SelectedDateTime == null)
            {
                txtAgeYear.ValueObject = null;
                txtAgeMonth.ValueObject = null;
                txtAgeDay.ValueObject = null;
            }
            else
            {
                TimeSpan DateDiff = DateTime.Now.Subtract(DateInputBirthDate.SelectedDateTime.Value);
                Int32 Years = DateDiff.Days / 365;
                txtAgeYear.Value = Years;
                Int32 Days = DateDiff.Days - (Years * 365);
                Int32 Month = Days / 30;
                txtAgeMonth.Value = Month;
                txtAgeDay.Value = Days - (Month * 30);
            }
            txtAgeYear.ValueChanged += txtAge_ValueChanged;
            txtAgeMonth.ValueChanged += txtAge_ValueChanged;
            txtAgeDay.ValueChanged += txtAge_ValueChanged;
        }
        #endregion

        #region cBoxEnterPatientAge_CheckedChanged
        private void cBoxEnterPatientAge_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxEnterPatAge.Checked)
            {
                lblBirthDate.Text = "سن بیمار:";
                DateInputBirthDate.Visible = false;
                txtAgeYear.Visible = true;
                if (_AgeDetailsLimit != null &&
                    _AgeDetailsLimit.Value >= txtAgeYear.Value && txtAgeYear.ValueObject != null)
                {
                    txtAgeMonth.Visible = true;
                    txtAgeDay.Visible = true;
                    cBoxEnterPatAge.Left = txtAgeDay.Left - cBoxEnterPatAge.Width - 5;
                }
                else
                {
                    txtAgeMonth.Visible = false;
                    txtAgeDay.Visible = false;
                    cBoxEnterPatAge.Left = txtAgeYear.Left - cBoxEnterPatAge.Width - 5;
                }
            }
            else
            {
                cBoxEnterPatAge.Left = DateInputBirthDate.Left - cBoxEnterPatAge.Width - 5;
                DateInputBirthDate.Visible = true;
                txtAgeYear.Visible = false;
                txtAgeMonth.Visible = false;
                txtAgeDay.Visible = false;
                lblBirthDate.Text = "تاریخ تولد:";
            }

            PanelPatientData.Invalidate();
        }
        #endregion

        #endregion

        #region @@@ Panel "Referral" Data Event Handlers @@@

        #region TimeTimer_Tick
        /// <summary>
        /// به ازای هر ثانیه ، این رخداد به وقوع می پیوندد و تاریخ و ساعت مراجعه را به روز می كند
        /// </summary>
        private void TimeTimer_Tick(object sender, EventArgs e)
        {
            Boolean LastState = _IsCurrentPatModified;
            DateReferral.SelectedDateTimeChanged -= DateTimeReferral_SelectedDateTimeChanged;
            DateReferral.SelectedDateTimeChanged -= FormControls_ValuesChanged;
            DateReferral.ValueChanged -= DateTimeReferral_SelectedDateTimeChanged;
            DateReferral.ValueChanged -= FormControls_ValuesChanged;
            DateReferral.TextChanged -= DateTimeReferral_SelectedDateTimeChanged;
            DateReferral.TextChanged -= FormControls_ValuesChanged;
            DateReferral.SelectedDateTime = DateTime.Now;
            DateReferral.UpdateTextValue();
            DateReferral.SelectedDateTimeChanged += DateTimeReferral_SelectedDateTimeChanged;
            DateReferral.SelectedDateTimeChanged += (FormControls_ValuesChanged);
            DateReferral.ValueChanged += DateTimeReferral_SelectedDateTimeChanged;
            DateReferral.ValueChanged += (FormControls_ValuesChanged);
            DateReferral.TextChanged += DateTimeReferral_SelectedDateTimeChanged;
            DateReferral.TextChanged += (FormControls_ValuesChanged);

            TimeReferral.ValueChanged -= (FormControls_ValuesChanged);
            TimeReferral.ValueChanged -= DateTimeReferral_SelectedDateTimeChanged;
            TimeReferral.ValueObjectChanged -= (FormControls_ValuesChanged);
            TimeReferral.ValueObjectChanged -= DateTimeReferral_SelectedDateTimeChanged;
            TimeReferral.Value = DateTime.Now;
            TimeReferral.ValueChanged += (FormControls_ValuesChanged);
            TimeReferral.ValueObjectChanged += (FormControls_ValuesChanged);
            TimeReferral.ValueChanged += DateTimeReferral_SelectedDateTimeChanged;
            TimeReferral.ValueObjectChanged += DateTimeReferral_SelectedDateTimeChanged;
            _IsCurrentPatModified = LastState;
        }
        #endregion

        #region DateTimeReferral_SelectedDateTimeChanged
        private void DateTimeReferral_SelectedDateTimeChanged(object sender, EventArgs e)
        {
            if (TimeTimer.Enabled) TimeTimer.Enabled = false;
        }
        #endregion

        #region cboRefPhysician_Enter
        private void cboRefPhysician_Enter(object sender, EventArgs e)
        {
            Application.CurrentInputLanguage =
                InputLanguage.FromCulture(new System.Globalization.CultureInfo("Fa-Ir"));
        }
        #endregion

        #region cboRefPhysician_KeyPress
        /// <summary>
        /// این روال ، منبع داده پزشكان را در هنگامی كه اطلاعات بیش از 2 كاراكتر باشد تكمیل می نماید
        /// </summary>
        private void cboRefPhysician_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') { SelectNextControl(this, true, true, true, true); return; }
            if (CurrentFormState == RefFormState.Viewing || !Char.IsLetterOrDigit(e.KeyChar)) { e.Handled = true; return; }
            // تنها بعد از ورود كاراكتر دوم این روال اجرا می شود
            if (cboRefPhysician.Text.Length != 1) return;
            cboRefPhysician.Text += e.KeyChar.ToString();
            List<Negar.DBLayerPMS.PhysicianFullData> PhysData = null;
            #region Search MedicalID
            if (Char.IsDigit(e.KeyChar))
            {
                PhysData = Negar.DBLayerPMS.ClinicData.GetRefPhysFullDataByValue(cboRefPhysician.Text.Normalize(), true);
                if (PhysData == null) return;
                if (PhysData.Count == 1) { cboRefPhysician_NoDataFound(String.Empty, null); return; }
            }
            #endregion

            #region Search LastName
            else if (Char.IsLetter(e.KeyChar))
            {
                PhysData = Negar.DBLayerPMS.ClinicData.GetRefPhysFullDataByValue(cboRefPhysician.Text.Normalize(), false);
                if (PhysData == null) return;
                if (PhysData.Count == 1) { cboRefPhysician_NoDataFound(String.Empty, null); return; }
            }
            #endregion

            if (PhysData == null) return;
            cboRefPhysician.DataSource = PhysData;
            cboRefPhysician.DisplayMember = "FullTitle";
            cboRefPhysician.ValueMember = "ID";
        }
        #endregion

        #region cboRefPhysician_NoDataFound
        private void cboRefPhysician_NoDataFound(object sender, EventArgs e)
        {
            try
            {
                if (cboRefPhysician.Text.Length == 0) return;
                String TheText;
                if (String.IsNullOrEmpty(sender.ToString())) TheText = cboRefPhysician.Text;
                else TheText = cboRefPhysician.Text.Substring(0, cboRefPhysician.SelectionStart) + Convert.ToChar(sender);
                frmPhysicianManager MyForm = new frmPhysicianManager(TheText);
                if (MyForm.DialogResult == DialogResult.OK)
                {
                    cboRefPhysician.DataSource = Negar.DBLayerPMS.ClinicData.GetRefPhysFullDataByID(MyForm.ID, false);
                    if (cboRefPhysician.DataSource == null) return;
                    cboRefPhysician.DisplayMember = "FullTitle";
                    cboRefPhysician.ValueMember = "ID";
                    cboRefPhysician.SelectedIndex = 0;
                }
                else
                {
                    cboRefPhysician.DataSource = null;
                    cboRefPhysician.Text = String.Empty;
                }
                MyForm.Dispose();
            }
            catch { cboRefPhysician.DataSource = null; }
        }
        #endregion

        #region btnAddPhysician_Click
        private void btnAddPhysician_Click(object sender, EventArgs e)
        {
            frmPhysicianManager MyForm = new frmPhysicianManager(String.Empty);
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("Fa-Ir"));
            if (MyForm.DialogResult != DialogResult.OK) return;
            cboRefPhysician.DataSource = Negar.DBLayerPMS.ClinicData.GetRefPhysFullDataByID(MyForm.ID, false);
            if (cboRefPhysician.DataSource == null) return;
            cboRefPhysician.DisplayMember = "FullTitle";
            cboRefPhysician.ValueMember = "ID";
            cboRefPhysician.SelectedIndex = 0;
        }
        #endregion

        #region btnEditPhysician_Click
        private void btnEditPhysician_Click(object sender, EventArgs e)
        {
            if (cboRefPhysician.SelectedIndex < 0)
            {
                PMBox.Show("برای ویرایش پزشك ، ابتدا یك پزشك را انتخاب نمایید!", "خطا!",
                  MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            Int16 ID = Convert.ToInt16(cboRefPhysician.SelectedValue);
            DialogResult Dr = new frmPhysicianManager(ID).DialogResult;
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("Fa-Ir"));
            if (Dr != DialogResult.OK) return;
            cboRefPhysician.DataSource = Negar.DBLayerPMS.ClinicData.GetRefPhysFullDataByID(ID, false);
            if (cboRefPhysician.DataSource == null) return;
            cboRefPhysician.DisplayMember = "FullTitle";
            cboRefPhysician.ValueMember = "ID";
            cboRefPhysician.SelectedIndex = 0;
        }
        #endregion

        #endregion

        #region @@@ Panel "Insurance" Data Event Handlers @@@

        #region cboIns1_SelectedIndexChanged
        private void cboIns1_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Ins1 Is Not Selected
            if (cboIns1.SelectedIndex == 0)
            {
                txtIns1No1.ReadOnly = true;
                txtIns1No1.TabStop = false;
                Ins1ExpireDate.IsReadonly = true;
                Ins1ExpireDate.TabStop = false;
                txtPageNo.IsInputReadOnly = true;
                txtPageNo.ButtonClear.Visible = false;
                txtPageNo.ShowUpDown = false;
                txtPageNo.TabStop = false;

                cboIns2.SelectedIndex = 0;
                SetComboBoxReadOnly(cboIns2, true);
                cboIns2.TabStop = false;
            }
            #endregion

            #region Ins1 Is Selected
            else
            {
                txtIns1No1.ReadOnly = false;
                txtIns1No1.TabStop = true;
                Ins1ExpireDate.IsReadonly = false;
                Ins1ExpireDate.TabStop = true;
                txtPageNo.IsInputReadOnly = false;
                txtPageNo.ButtonClear.Visible = true;
                txtPageNo.ShowUpDown = true;
                txtPageNo.TabStop = true;
                // فعال كردن كمبو باكس بیمه دوم به خاطر انتخاب شده بودن بیمه اول می باشد
                // در صورتی كه به تغییر بیمه دوم دسترسی داشته باشد
                if(_CanChangeIns2)
                {
                    SetComboBoxReadOnly(cboIns2, false);
                    cboIns2.TabStop = true;
                }
            }
            #endregion

            ReCalculateAddedServicesPrices(true);
        }
        #endregion

        #region cboIns2_SelectedIndexChanged
        private void cboIns2_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Ins2 Is Not Selected
            if (cboIns2.SelectedIndex == 0)
            {
                txtIns2No1.ReadOnly = true;
                txtIns2No1.Text = String.Empty;
                txtIns2No1.TabStop = false;
                Ins2ExpireDate.ResetSelectedDateTime();
                Ins2ExpireDate.IsReadonly = true;
                Ins2ExpireDate.TabStop = false;
            }
            #endregion

            #region Ins2 Is Selected
            else
            {
                txtIns2No1.ReadOnly = false;
                txtIns2No1.TabStop = true;
                Ins2ExpireDate.IsReadonly = false;
                Ins2ExpireDate.TabStop = true;
            }
            #endregion

            ReCalculateAddedServicesPrices(true);
        }
        #endregion

        #region btnInsDetails_Click
        private void btnInsDetails_Click(object sender, EventArgs e)
        {
            if (((ButtonX)sender).Name == "btnIns1Details")
            { if (cboIns1.SelectedValue != null) new frmRefInsDetails((Int16)cboIns1.SelectedValue); }
            else if (((ButtonX)sender).Name == "btnIns2Details")
            { if (cboIns2.SelectedValue != null) new frmRefInsDetails((Int16)cboIns2.SelectedValue); }
        }
        #endregion

        #endregion

        #region @@@ Panel "Service" Data Event Handlers @@@

        #region txtServiceCode_KeyPress
        private void txtServiceCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                ServiceAddingControls_PreviewKeyDown(null, new PreviewKeyDownEventArgs(Keys.Enter));
        }
        #endregion

        #region ServiceAddingControls_PreviewKeyDown
        private void ServiceAddingControls_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                #region Check Entered Code
                // اگر مقداری وارد نشده بود
                if (String.IsNullOrEmpty(txtServiceCode.Text)) return;
                List<Int16> ServiceID = DBLayerIMS.Services.ServicesList.
                    Where(Data => Data.Code == txtServiceCode.Text && Data.IsActive).Select(Data => Data.ID).ToList();
                if (ServiceID.Count() == 0)
                {
                    PMBox.Show("چنین كدی برای خدمت در سیستم وجود ندارد!", "خطا!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtServiceCode.Select(0, txtServiceCode.Text.Length);
                    txtServiceCode.Focus();
                    return;
                }
                #endregion

                #region Check Different Services
                // اگر امكان ورود خدمت تكراری نباشد
                if (_CanAddMultipleServices == false)
                {
                    Boolean IsFounded = false;
                    for (Int32 i = 0; i < dgvRefServices.Rows.Count; i++)
                        if (((RefService)dgvRefServices.Rows[i].DataBoundItem).ServiceIX == ServiceID.First())
                        {
                            ((RefService)dgvRefServices.Rows[i].DataBoundItem).Quantity++;
                            IsFounded = true;
                            break;
                        }
                    if (!IsFounded) AddNewServiceToGrid(ServiceID.First(), 1);
                }
                else if (!AddNewServiceToGrid(ServiceID.First(), 1)) { Dispose(); return; }
                #endregion

                dgvRefServices.DataSource = _RefServices.Where(Data => Data.IsActive).ToList();
                ReCalculateAddedServicesPrices(false);
                txtServiceCode.Value = 0;
                txtServiceCode.Text = String.Empty;
                txtServiceCode.Focus();
            }
        }
        #endregion

        #region txtIns1No1_KeyPress
        private void txtIns1No1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_IsBarcodeActive || e.KeyChar == (Char)Keys.Space || e.KeyChar == (Char)Keys.Back) return;
            if (_KeyPressTimer == null) _KeyPressTimer = DateTime.Now;
            Int32 Sub = DateTime.Now.Subtract(_KeyPressTimer.Value).Milliseconds;
            if (Sub < 50) e.Handled = true;
            _KeyPressTimer = DateTime.Now;
        }
        #endregion

        #region btnChooseService_Click
        /// <summary>
        /// دكمه ی انتخاب چند خدمت ار فرم لیست خدمات
        /// </summary>
        private void btnChooseService_Click(object sender, EventArgs e)
        {
            if (_frmChooseService == null || _frmChooseService.IsDisposed)
                _frmChooseService = new frmServicesSelection();
            _frmChooseService.ShowDialog();
            if (_frmChooseService.DialogResult == DialogResult.OK)
            {
                foreach (KeyValuePair<Int16, Int32> SelectedService in _frmChooseService.SelectedServices)
                {
                    #region Check Different Services
                    // اگر امكان ورود خدمت تكراری نباشد
                    if (_CanAddMultipleServices == false)
                    {
                        Boolean IsFounded = false;
                        for (Int32 i = 0; i < dgvRefServices.Rows.Count; i++)
                            if (((RefService)dgvRefServices.Rows[i].DataBoundItem).ServiceIX == SelectedService.Key)
                            {
                                ((RefService)dgvRefServices.Rows[i].DataBoundItem).Quantity +=
                                    Convert.ToByte(SelectedService.Value);
                                IsFounded = true;
                                break;
                            }
                        if (!IsFounded && !AddNewServiceToGrid(SelectedService.Key, Convert.ToByte(SelectedService.Value)))
                        { _IsCurrentPatModified = false; Dispose(); return; }
                    }
                    // حالتی كه امكان ورود خدمت تكراری وجود داشته باشد
                    else
                    {
                        if (!AddNewServiceToGrid(SelectedService.Key, Convert.ToByte(SelectedService.Value)))
                        {
                            _IsCurrentPatModified = false;
                            Dispose();
                            return;
                        }
                    }
                    #endregion
                }
                dgvRefServices.DataSource = _RefServices.Where(Data => Data.IsActive).ToList();
                ReCalculateAddedServicesPrices(false);
            }
        }
        #endregion

        #region dgvRefServices_Enter
        private void dgvRefServices_Enter(object sender, EventArgs e)
        {
            if (dgvRefServices.Rows.Count == 0)
            {
                if (txtPrePayment.Visible) txtPrePayment.Focus();
                else dgvRefServices.SelectNextControl(dgvRefServices, true, true, true, true);
            }
        }
        #endregion

        #region dgvRefServices_CellFormatting
        private void dgvRefServices_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == ColServiceName.Index)
                e.Value = DBLayerIMS.Services.ServicesList.Where(Data => Data.ID ==
                    ((RefService)dgvRefServices.Rows[e.RowIndex].DataBoundItem).ServiceIX).First().Name;
        }
        #endregion

        #region dgvRefServices_CellValidating
        private void dgvRefServices_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == ColQuantity.Index)
                try
                {
                    Int32 Value;
                    Boolean IsCorrectValue = Int32.TryParse(e.FormattedValue.ToString(), out Value);
                    if (!IsCorrectValue || Value <= 0)
                    {
                        PMBox.Show("مقدار وارد شده برای تعداد خدمت صحیح نمی باشد!", "خطا!",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                        return;
                    }
                }
                catch (Exception)
                {
                    PMBox.Show("مقدار وارد شده برای تعداد خدمت صحیح نمی باشد!", "خطا!",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                    return;
                }
        }
        #endregion

        #region dgvRefServices_CellMouseClick
        /// <summary>
        /// تابع مدیریت كلیك راست بر روی جدول خدمات
        /// </summary>
        private void dgvRefServices_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Point ShowingLocation = MousePosition;
            if (sender.GetType().Equals(typeof(Int32))) ShowingLocation = e.Location;
            if (CurrentFormState == RefFormState.Editing && !_CanEditServices) return;
            if (e.Button == MouseButtons.Right &&
                (CurrentFormState == RefFormState.AddingPatRef || CurrentFormState == RefFormState.Editing) &&
                e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Select Current Row:
                if (!sender.GetType().Equals(typeof(Int32)))
                    dgvRefServices.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                // Set Service Quantity
                SliderItemCount.ValueChanged -= SliderItemCount_ValueChanged;
                SliderItemCount.Value = ((RefService)dgvRefServices.Rows[e.RowIndex].DataBoundItem).Quantity;
                SliderItemCount.Text = "تعداد خدمت: " + SliderItemCount.Value;
                SliderItemCount.ValueChanged += SliderItemCount_ValueChanged;
                // Set IsIns1Cover:
                if (((RefService)dgvRefServices.Rows[e.RowIndex].DataBoundItem).IsIns1Cover == null ||
                    ((RefService)dgvRefServices.Rows[e.RowIndex].DataBoundItem).IsIns1Cover == false)
                    btnIns1Cover.Checked = false;
                else btnIns1Cover.Checked =
                        Convert.ToBoolean(((RefService)dgvRefServices.Rows[e.RowIndex].DataBoundItem).IsIns1Cover);
                // Set IsIns2Cover:
                if (((RefService)dgvRefServices.Rows[e.RowIndex].DataBoundItem).IsIns2Cover == null ||
                    ((RefService)dgvRefServices.Rows[e.RowIndex].DataBoundItem).IsIns2Cover == false)
                    btnIns2Cover.Checked = false;
                else btnIns2Cover.Checked =
                        Convert.ToBoolean(((RefService)dgvRefServices.Rows[e.RowIndex].DataBoundItem).IsIns2Cover);
                // Set Service Free Price:
                Int32 ServiceFreePrice =
                    DBLayerIMS.Services.ServicesList.Where(
                        result => result.ID == ((RefService)dgvRefServices.Rows[e.RowIndex].DataBoundItem).ServiceIX).
                        Select(result => result.PriceFree).First();
                lblServiceFreePrice.Text = ServiceFreePrice + " ریال";
                // Set Service Goverment Price:
                Int32 ServiceGovPrice =
                    DBLayerIMS.Services.ServicesList.Where(
                        result => result.ID == ((RefService)dgvRefServices.Rows[e.RowIndex].DataBoundItem).ServiceIX).
                        Select(result => result.PriceGov).First();
                lblServiceGovPrice.Text = ServiceGovPrice + " ریال";
                // Set Ins1 Price:
                Int32? Ins1Price = ((RefService)dgvRefServices.Rows[e.RowIndex].DataBoundItem).Ins1Price;
                if (Ins1Price == null) lblIns1Price.Text = String.Empty;
                else lblIns1Price.Text = Ins1Price + " ریال";
                // Set Ins1 Part:
                Int32? Ins1Part = ((RefService)dgvRefServices.Rows[e.RowIndex].DataBoundItem).Ins1PartPrice;
                if (Ins1Part == null) lblIns1Part.Text = String.Empty;
                else lblIns1Part.Text = Ins1Part + " ریال";
                // Set Ins1 Patient Part:
                Int32? Ins1PatientPart = null;
                if (Ins1Price != null && Ins1Part != null) Ins1PatientPart = Ins1Price - Ins1Part;
                if (Ins1PatientPart == null) lblIns1PatientPart.Text = String.Empty;
                else lblIns1PatientPart.Text = Ins1PatientPart + " ریال";
                // Set Ins2 Price:
                Int32? Ins2Price = ((RefService)dgvRefServices.Rows[e.RowIndex].DataBoundItem).Ins2Price;
                if (Ins2Price == null) lblIns2Price.Text = String.Empty;
                else lblIns2Price.Text = Ins2Price + " ریال";
                // Set Ins2 Part:
                Int32? Ins2Part = ((RefService)dgvRefServices.Rows[e.RowIndex].DataBoundItem).Ins2PartPrice;
                if (Ins2Part == null) lblIns2Part.Text = String.Empty;
                else lblIns2Part.Text = Ins2Part + " ریال";
                // Set PatientPayable:
                Int32 PatientPayable = ((RefService)dgvRefServices.Rows[e.RowIndex].DataBoundItem).PatientPayablePrice;
                lblPatientPayable.Text = PatientPayable + " ریال";
                cmsdgvServices.Popup(ShowingLocation);
            }
        }
        #endregion

        #region dgvRefServices_PreviewKeyDown
        private void dgvRefServices_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Delete && CurrentFormState != RefFormState.Viewing &&
                dgvRefServices.SelectedCells.Count != 0)
            {
                if (CurrentFormState == RefFormState.Editing)
                {
                    if (((RefService)dgvRefServices.Rows[dgvRefServices.SelectedCells[0].RowIndex].DataBoundItem).ID == 0)
                    {
                        _RefServices.Remove(
                            (RefService)dgvRefServices.Rows[dgvRefServices.SelectedCells[0].RowIndex].DataBoundItem);
                        DBLayerIMS.Manager.DBML.RefServices.
                            DeleteOnSubmit((RefService)dgvRefServices.Rows[dgvRefServices.SelectedCells[0].RowIndex].DataBoundItem);
                        dgvRefServices.DataSource = _RefServices.Where(Data => Data.IsActive).ToList();
                        return;
                    }
                    if (!_CanChangeServiceActivation) return;
                    #region Can Change Service Activation After Pay
                    if (!_CanChangeServiceActivationAfterPay)
                    {
                        try
                        {
                            IQueryable<Int32> TempData = DBLayerIMS.Manager.DBML.RefTransactions.
                                Where(Data => Data.ReferralIX == _CurrentRefData.ID).Select(Data => Data.ID);
                            DBLayerIMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, TempData);
                            if (TempData.Count() > 0)
                            {
                                PMBox.Show("مراجعه جاری دارای دریافت یا بازپرداخت ثبت شده می باشد و كاربر جاری \n" +
                                    "دسترسی لازم برای لغو خدمت چنین مراجعه را ندارد.", "محدودیت دسترسی!",
                                    MessageBoxButtons.OK, MessageBoxIcon.Stop); return;
                            }
                        }
                        #region Catch
                        catch (Exception Ex)
                        {
                            LogManager.SaveLogEntry("Sepehr", "Admission Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                            return;
                        }
                        #endregion
                    }
                    #endregion

                    DialogResult Result = PMBox.Show("آیا مایلید خدمت انتخاب شده لغو گردد؟", "پرسش؟",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (Result == DialogResult.Yes)
                        ((RefService)dgvRefServices.Rows[dgvRefServices.SelectedCells[0].RowIndex].DataBoundItem).IsActive = false;
                }
                else if (CurrentFormState == RefFormState.AddingPatRef)
                {
                    _RefServices.Remove(
                        (RefService)dgvRefServices.Rows[dgvRefServices.SelectedCells[0].RowIndex].DataBoundItem);
                }
                _IsCurrentPatModified = true;
                dgvRefServices.DataSource = _RefServices.Where(Data => Data.IsActive).ToList();
                ReCalculateAddedServicesPrices(false);
            }
            else if (e.KeyData == Keys.Apps && CurrentFormState != RefFormState.Viewing &&
                dgvRefServices.SelectedCells.Count != 0)
            {
                // ReSharper disable PossibleNullReferenceException
                dgvRefServices_CellMouseClick(1, new DataGridViewCellMouseEventArgs(0,
                    dgvRefServices.SelectedCells[0].RowIndex,
                    ParentForm.Left + Left + dgvRefServices.Width - 50,
                        ParentForm.Top + Top + PanelRefServices.Top + dgvRefServices.Top +
                        dgvRefServices.ColumnHeadersHeight +
                        dgvRefServices.GetRowDisplayRectangle(dgvRefServices.SelectedCells[0].RowIndex, true).Top + 11,
                        new MouseEventArgs(MouseButtons.Right, 1, 1, 1, 1)));
                // ReSharper restore PossibleNullReferenceException
            }
        }
        #endregion

        #region dgvRefServices Values Changed Event Handlers

        #region dgvRefServices_CellBeginEdit
        private void dgvRefServices_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (CurrentFormState == RefFormState.Viewing) return;
            _IsCurrentPatModified = true;
        }
        #endregion

        #region dgvRefServices_CellValueChanged
        private void dgvRefServices_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (CurrentFormState == RefFormState.Viewing) return;
            _IsCurrentPatModified = true;
            if (e.ColumnIndex == dgvRefServices.Columns.IndexOf(ColQuantity))
                ReCalculateAddedServicesPrices(false);
        }
        #endregion

        #region dgvRefServices_RowsAdded
        private void dgvRefServices_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (CurrentFormState == RefFormState.Viewing) return;
            _IsCurrentPatModified = true;
        }
        #endregion

        #region dgvRefServices_RowsRemoved
        private void dgvRefServices_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (CurrentFormState == RefFormState.Viewing) return;
            _IsCurrentPatModified = true;
            ReCalculateAddedServicesPrices(false);
        }
        #endregion

        #endregion

        #region btnRemoveService_Click
        private void btnRemoveService_Click(object sender, EventArgs e)
        {
            if (CurrentFormState == RefFormState.Editing && dgvRefServices.SelectedCells.Count != 0)
            {
                // برای خدماتی كه به تازگی افزوده شده اند
                if (((RefService)dgvRefServices.Rows[dgvRefServices.SelectedCells[0].RowIndex].DataBoundItem).ID == 0)
                {
                    _RefServices.Remove(
                        (RefService)dgvRefServices.Rows[dgvRefServices.SelectedCells[0].RowIndex].DataBoundItem);
                    DBLayerIMS.Manager.DBML.RefServices.
                        DeleteOnSubmit((RefService)dgvRefServices.Rows[dgvRefServices.SelectedCells[0].RowIndex].DataBoundItem);
                    dgvRefServices.DataSource = _RefServices.Where(Data => Data.IsActive).ToList();
                    return;
                }
                if (!_CanChangeServiceActivation) return;
                #region Can Change Service Activation After Pay
                if (!_CanChangeServiceActivationAfterPay)
                {
                    try
                    {
                        IQueryable<Int32> TempData = DBLayerIMS.Manager.DBML.RefTransactions.
                            Where(Data => Data.ReferralIX == _CurrentRefData.ID).Select(Data => Data.ID);
                        DBLayerIMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, TempData);
                        if (TempData.Count() > 0)
                        {
                            PMBox.Show("مراجعه جاری دارای دریافت یا بازپرداخت ثبت شده می باشد و كاربر جاری \n" +
                                "دسترسی لازم برای لغو خدمت چنین مراجعه را ندارد.", "محدودیت دسترسی!",
                                MessageBoxButtons.OK, MessageBoxIcon.Stop); return;
                        }
                    }
                    #region Catch
                    catch (Exception Ex)
                    {
                        LogManager.SaveLogEntry("Sepehr", "Admission Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                        return;
                    }
                    #endregion
                }
                #endregion
                DialogResult Result = PMBox.Show("آیا مایلید خدمت انتخاب شده لغو گردد؟", "پرسش؟",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (Result != DialogResult.Yes) return;
                ((RefService)dgvRefServices.Rows[dgvRefServices.SelectedCells[0].RowIndex].DataBoundItem).IsActive = false;
                _IsCurrentPatModified = true;
                dgvRefServices.DataSource = _RefServices.Where(Data => Data.IsActive).ToList();
            }
            else if (CurrentFormState == RefFormState.AddingPatRef && dgvRefServices.SelectedCells.Count != 0)
            {
                _RefServices.Remove(
                    (RefService)dgvRefServices.Rows[dgvRefServices.SelectedCells[0].RowIndex].DataBoundItem);
                _IsCurrentPatModified = true;
                dgvRefServices.DataSource = _RefServices.Where(Data => Data.IsActive).ToList();
            }
            ReCalculateAddedServicesPrices(false);
            _IsCurrentPatModified = true;
        }
        #endregion

        #region btnIns1Cover_Click
        private void btnIns1Cover_Click(object sender, EventArgs e)
        {
            // اگر بیمه ی اول انتخاب نشده باشد ، پوشش بیمه قابل تغییر نیست
            if (cboIns1.SelectedIndex == 0)
            {
                PMBox.Show("بیمه ی اولی انتخاب نشده تا خدمت تحت پوشش آن قرار بگیرد!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            RefService Service = ((RefService)dgvRefServices.Rows[dgvRefServices.SelectedCells[0].RowIndex].DataBoundItem);
            // باید بررسی گردد كه بیمه انتخاب شده خدمت مورد نظر را پوشش میدهد یا خیر
            List<Boolean> InsData = DBLayerIMS.Insurance.InsServiceFullList.Where(result => result.ServiceIX == Service.ServiceIX &&
                result.InsIX == Convert.ToInt16(cboIns1.SelectedValue)).Select(result => result.IsCover).ToList();
            if (InsData.Count == 0 || !InsData.First())
            {
                PMBox.Show("خدمت انتخاب شده تحت پوشش بیمه ی اول انتخاب شده نیست!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            #region Set Ins1 Cover = False
            if (btnIns1Cover.Checked)
            {
                btnIns1Cover.Checked = false;
                Service.IsIns1Cover = false;
                // در صورتی كه بیمه ی اول خدمت مورد نظر را تحت پوشش قرار ندهد 
                // قیمت های بیمه ی اول برای خدمت مورد نظر صفر می شود
                Service.Ins1Price = 0;
                Service.Ins1PartPrice = 0;
                #region Ins2 IsCover = True
                if (Service.IsIns2Cover != null && Service.IsIns2Cover == true)
                {
                    // مقدار پرداختنی خدمت بر اساس بیمه دوم و با قیمت های بیمه اول صفر مجدداً محاسبه گردد
                    // OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                    SP_SelectInsFullDataResult Ins2Data =
                        DBLayerIMS.Insurance.InsFullList.Where(Result => Result.ID == Convert.ToInt16(cboIns2.SelectedValue)).First();
                    // OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                    Int32? Ins2Price = 0;
                    Int32? Ins2Part = 0;
                    Int32? Ins2Payable = 0;
                    Int32? Ins1PatientPart = Service.Ins1Price - Service.Ins1PartPrice;
                    if (Service.Ins2Price == null) Service.Ins2Price = 0;
                    // OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                    try
                    {
                        // تابع محاسبه قیمت های بیمه دوم بر اساس فرمول بیمه در اینجا فراخوانی می گردد
                        DBLayerIMS.Manager.DBML.SP_GenerateIns2Prices(
                            // بیمه دوم انتخاب شده
                            Convert.ToInt16(cboIns2.SelectedValue),
                            // خدمت انتخاب شده
                            Service.ServiceIX,
                            // قیمت بیمه اول محاسبه شده
                            Service.Ins1Price,
                            // قیمت سهم بیمه اول محاسبه شده
                            Service.Ins1PartPrice,
                            // قیمت سهم بیمار از بیمه اول محاسبه شده
                            Ins1PatientPart,
                            // قیمت پرداختنی بیمار بابت بیمه اول محاسبه شده
                            0,
                            // قیمت سقف تعهد بیمه اول
                            0,
                            // درصد بیمار برای بیمه اول
                            100,
                            // درصد بیمار برای بیمه اول
                            Ins2Data.InsurerPartLimit,
                            // خروجی 3 قیمت تولید شده
                            ref Ins2Price, ref Ins2Part, ref Ins2Payable);
                    }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage =
                            "امكان خواندن اطلاعات مبالغ بیمه دوم خدمات از بانك اطلاعات ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Sepehr", "Admission Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                        if (ParentForm != null) ParentForm.Close();
                        return;
                    }
                    #endregion
                    // OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                    Service.Ins2Price = Convert.ToInt32(Ins2Price);
                    Service.Ins2PartPrice = Convert.ToInt32(Ins2Part);
                    Service.PatientPayablePrice = Convert.ToInt32(Ins2Payable);
                }
                #endregion

                #region Ins2 IsCover = False
                else
                {
                    // مقدار پرداختنی خدمت برابر مقدار آن در حالت بدون بیمه میگردد
                    Service.PatientPayablePrice = DBLayerIMS.Services.ServicesList.Where(Data => Data.ID == Service.ServiceIX).
                    Select(Data => Data.PriceFree).First();
                }
                #endregion
            }
            #endregion

            #region Set Ins1 Cover = True
            else
            {
                btnIns1Cover.Checked = true;
                Service.IsIns1Cover = true;
                // در صورتی كه بیمه ی اول خدمت مورد نظر را تحت پوشش قرار دهد 
                // قیمت های بیمه ی اول برای خدمت مورد نظر بر اساس قیمت های آن محاسبه می شود
                // پیمایش بین جدول ارتباط بیمه ها و خدمات برای بدست آوردن قیمت های خدمات مورد نظر در بیمه ی اول انتخاب شده
                List<InsuranceService> CurrentServiceIns1Data =
                    DBLayerIMS.Insurance.InsServiceFullList.Where(Result => Result.ServiceIX == Service.ServiceIX &&
                        Result.InsIX == Convert.ToInt16(cboIns1.SelectedValue)).ToList();
                Service.Ins1Price = CurrentServiceIns1Data.First().InsPrice;
                Service.Ins1PartPrice = CurrentServiceIns1Data.First().InsPart;

                #region Ins2 IsCover = True
                if (Service.IsIns2Cover != null && Service.IsIns2Cover == true)
                {
                    // مقدار پرداختنی خدمت در این حالت باید مجددا بر اساس بیمه دوم انتخاب شده محاسبه گردد
                    // OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                    SP_SelectInsFullDataResult Ins1Data =
                        DBLayerIMS.Insurance.InsFullList.Where(Result => Result.ID == Convert.ToInt16(cboIns1.SelectedValue)).First();
                    SP_SelectInsFullDataResult Ins2Data =
                        DBLayerIMS.Insurance.InsFullList.Where(Result => Result.ID == Convert.ToInt16(cboIns2.SelectedValue)).First();
                    // OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                    Int32? Ins2Price = 0;
                    Int32? Ins2Part = 0;
                    Int32? Ins2Payable = 0;
                    Int32? Ins1PatientPart = Service.Ins1Price - Service.Ins1PartPrice;
                    if (Service.Ins2Price == null) Service.Ins2Price = 0;
                    // OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                    try
                    {
                        Int32 CurrentServiceIns1PatientPayable = 0;
                        if (CurrentServiceIns1Data.Count != 0)
                            CurrentServiceIns1PatientPayable = CurrentServiceIns1Data.First().PatientPayable;
                        // تابع محاسبه قیمت های بیمه دوم بر اساس فرمول بیمه در اینجا فراخوانی می گردد
                        DBLayerIMS.Manager.DBML.SP_GenerateIns2Prices(
                            // بیمه دوم انتخاب شده
                            Convert.ToInt16(cboIns2.SelectedValue),
                            // خدمت انتخاب شده
                            Service.ServiceIX,
                            // قیمت بیمه اول محاسبه شده
                            Service.Ins1Price,
                            // قیمت سهم بیمه اول محاسبه شده
                            Service.Ins1PartPrice,
                            // قیمت سهم بیمار از بیمه اول محاسبه شده
                            Ins1PatientPart,
                            // قیمت پرداختنی بیمار بابت بیمه اول محاسبه شده
                            CurrentServiceIns1PatientPayable,
                            // قیمت سقف تعهد بیمه اول
                            Ins1Data.InsurerPartLimit,
                            // درصد بیمار برای بیمه اول
                            Ins1Data.PatientPercent,
                            // درصد بیمار برای بیمه اول
                            Ins2Data.InsurerPartLimit,
                            // خروجی 3 قیمت تولید شده
                            ref Ins2Price, ref Ins2Part, ref Ins2Payable);
                    }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage =
                            "امكان خواندن اطلاعات مبالغ بیمه دوم خدمات از بانك اطلاعات ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Sepehr", "Admission Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                        if (ParentForm != null) ParentForm.Close();
                        return;
                    }
                    #endregion
                    // OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                    Service.Ins2Price = Convert.ToInt32(Ins2Price);
                    Service.Ins2PartPrice = Convert.ToInt32(Ins2Part);
                    Service.PatientPayablePrice = Convert.ToInt32(Ins2Payable);
                }
                #endregion

                #region Ins2 IsCover = False
                else
                {
                    // مقدار پرداختنی خدمت برابر مقدار آن در حالت با بیمه اول و بدون بیمه دوم گردد
                    Service.PatientPayablePrice = CurrentServiceIns1Data.First().PatientPayable;
                }
                #endregion
            }
            #endregion

            ReCalculateAddedServicesPrices(false);
            dgvRefServices.Refresh();
            _IsCurrentPatModified = true;
        }
        #endregion

        #region btnIns2Cover_Click
        private void btnIns2Cover_Click(object sender, EventArgs e)
        {
            if (cboIns2.SelectedIndex == 0)
            {
                PMBox.Show("بیمه ی دومی انتخاب نشده تا خدمت تحت پوشش آن قرار گیرد!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            RefService Service = ((RefService)dgvRefServices.Rows[dgvRefServices.SelectedCells[0].RowIndex].DataBoundItem);
            // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            // باید بررسی گردد كه بیمه انتخاب شده خدمت مورد نظر را پوشش میدهد یا خیر
            List<Boolean> InsData = DBLayerIMS.Insurance.InsServiceFullList.
                Where(result => result.ServiceIX == Service.ServiceIX &&
                result.InsIX == Convert.ToInt16(cboIns2.SelectedValue)).Select(result => result.IsCover).ToList();
            if (InsData.Count == 0 || !InsData.First())
            {
                PMBox.Show("خدمت انتخاب شده تحت پوشش بیمه ی دوم انتخاب شده نیست!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

            #region Set Ins2 Cover = False
            if (btnIns2Cover.Checked)
            {
                btnIns2Cover.Checked = false;
                Service.IsIns2Cover = false;
                // در صورتی كه بیمه ی دوم خدمت مورد نظر را تحت پوشش قرار ندهد 
                // قیمت های بیمه ی دوم برای خدمت مورد نظر صفر می شود
                Service.Ins2Price = 0;
                Service.Ins2PartPrice = 0;
                #region Ins1 IsCover = True
                // مقدار پرداختنی خدمت بر اساس بیمه اول و با قیمت های بیمه دوم صفر مجدداً محاسبه گردد
                if (Service.IsIns1Cover != null && Service.IsIns1Cover == true)
                {
                    // پیمایش بین جدول ارتباط بیمه ها و خدمات برای بدست آوردن قیمت های خدمات مورد نظر در بیمه ی اول انتخاب شده
                    List<InsuranceService> CurrentServiceIns1Data =
                        DBLayerIMS.Insurance.InsServiceFullList.Where(Result => Result.ServiceIX == Service.ServiceIX &&
                            Result.InsIX == Convert.ToInt16(cboIns1.SelectedValue)).ToList();
                    Service.Ins1Price = CurrentServiceIns1Data.First().InsPrice;
                    Service.Ins1PartPrice = CurrentServiceIns1Data.First().InsPart;
                    Service.PatientPayablePrice = CurrentServiceIns1Data.First().PatientPayable;
                }
                #endregion

                #region Ins1 IsCover = False
                else
                {
                    // مقدار پرداختنی خدمت برابر مقدار آن در حالت بدون بیمه میگردد
                    Service.PatientPayablePrice = DBLayerIMS.Services.ServicesList.Where(Data => Data.ID == Service.ServiceIX).
                    Select(Data => Data.PriceFree).First();
                }
                #endregion
            }
            #endregion

            #region Set Ins2 Cover = True
            else
            {
                // در صورتی كه بیمه ی دوم خدمت مورد نظر را تحت پوشش قرار دهد 
                // قیمت های بیمه ی دوم برای خدمت مورد نظر بر اساس قیمت های آن محاسبه می شود
                btnIns2Cover.Checked = true;
                Service.IsIns2Cover = true;

                #region Ins1 IsCover = True
                if (Service.IsIns2Cover != null || Service.IsIns2Cover == true)
                {
                    // پیمایش بین جدول ارتباط بیمه ها و خدمات برای بدست آوردن قیمت های خدمات مورد نظر در بیمه ی اول انتخاب شده
                    List<InsuranceService> CurrentServiceIns1Data =
                        DBLayerIMS.Insurance.InsServiceFullList.Where(Result => Result.ServiceIX == Service.ServiceIX &&
                            Result.InsIX == Convert.ToInt16(cboIns1.SelectedValue)).ToList();
                    // مقدار پرداختنی خدمت در این حالت باید مجددا بر اساس بیمه اول و دوم انتخاب شده محاسبه گردد
                    // OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                    SP_SelectInsFullDataResult Ins1Data =
                        DBLayerIMS.Insurance.InsFullList.Where(Result => Result.ID == Convert.ToInt16(cboIns1.SelectedValue)).First();
                    SP_SelectInsFullDataResult Ins2Data =
                        DBLayerIMS.Insurance.InsFullList.Where(Result => Result.ID == Convert.ToInt16(cboIns2.SelectedValue)).First();
                    // OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                    Int32? Ins2Price = 0;
                    Int32? Ins2Part = 0;
                    Int32? Ins2Payable = 0;
                    Int32? Ins1PatientPart = Service.Ins1Price - Service.Ins1PartPrice;
                    if (Service.Ins2Price == null) Service.Ins2Price = 0;
                    // OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                    try
                    {
                        Int32 CurrentServiceIns1PatientPayable = 0;
                        if (CurrentServiceIns1Data.Count != 0)
                            CurrentServiceIns1PatientPayable = CurrentServiceIns1Data.First().PatientPayable;
                        // تابع محاسبه قیمت های بیمه دوم بر اساس فرمول بیمه در اینجا فراخوانی می گردد
                        DBLayerIMS.Manager.DBML.SP_GenerateIns2Prices(
                            // بیمه دوم انتخاب شده
                            Convert.ToInt16(cboIns2.SelectedValue),
                            // خدمت انتخاب شده
                            Service.ServiceIX,
                            // قیمت بیمه اول محاسبه شده
                            Service.Ins1Price,
                            // قیمت سهم بیمه اول محاسبه شده
                            Service.Ins1PartPrice,
                            // قیمت سهم بیمار از بیمه اول محاسبه شده
                            Ins1PatientPart,
                            // قیمت پرداختنی بیمار بابت بیمه اول محاسبه شده
                            CurrentServiceIns1PatientPayable,
                            // قیمت سقف تعهد بیمه اول
                            Ins1Data.InsurerPartLimit,
                            // درصد بیمار برای بیمه اول
                            Ins1Data.PatientPercent,
                            // درصد بیمار برای بیمه اول
                            Ins2Data.InsurerPartLimit,
                            // خروجی 3 قیمت تولید شده
                            ref Ins2Price, ref Ins2Part, ref Ins2Payable);
                    }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage =
                            "امكان خواندن اطلاعات مبالغ بیمه دوم خدمات از بانك اطلاعات ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Sepehr", "Admission Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                        if (ParentForm != null) ParentForm.Close();
                        return;
                    }
                    #endregion
                    // OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                    Service.Ins2Price = Convert.ToInt32(Ins2Price);
                    Service.Ins2PartPrice = Convert.ToInt32(Ins2Part);
                    Service.PatientPayablePrice = Convert.ToInt32(Ins2Payable);
                }
                #endregion

                #region Ins1 IsCover = False
                else
                {
                    // مقدار پرداختنی خدمت بر اساس بیمه دوم و با قیمت های بیمه اول صفر مجدداً محاسبه گردد
                    // OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                    SP_SelectInsFullDataResult Ins2Data =
                        DBLayerIMS.Insurance.InsFullList.Where(Result => Result.ID == Convert.ToInt16(cboIns2.SelectedValue)).First();
                    // OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                    Int32? Ins2Price = 0;
                    Int32? Ins2Part = 0;
                    Int32? Ins2Payable = 0;
                    Int32? Ins1PatientPart = Service.Ins1Price - Service.Ins1PartPrice;
                    if (Service.Ins2Price == null) Service.Ins2Price = 0;
                    // OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                    try
                    {
                        // تابع محاسبه قیمت های بیمه دوم بر اساس فرمول بیمه در اینجا فراخوانی می گردد
                        DBLayerIMS.Manager.DBML.SP_GenerateIns2Prices(
                            // بیمه دوم انتخاب شده
                            Convert.ToInt16(cboIns2.SelectedValue),
                            // خدمت انتخاب شده
                            Service.ServiceIX,
                            // قیمت بیمه اول محاسبه شده
                            Service.Ins1Price,
                            // قیمت سهم بیمه اول محاسبه شده
                            Service.Ins1PartPrice,
                            // قیمت سهم بیمار از بیمه اول محاسبه شده
                            Ins1PatientPart,
                            // قیمت پرداختنی بیمار بابت بیمه اول محاسبه شده
                            0,
                            // قیمت سقف تعهد بیمه اول
                            0,
                            // درصد بیمار برای بیمه اول
                            100,
                            // درصد بیمار برای بیمه اول
                            Ins2Data.InsurerPartLimit,
                            // خروجی 3 قیمت تولید شده
                            ref Ins2Price, ref Ins2Part, ref Ins2Payable);
                    }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage =
                            "امكان خواندن اطلاعات مبالغ بیمه دوم خدمات از بانك اطلاعات ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Sepehr", "Admission Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                        if (ParentForm != null) ParentForm.Close();
                        return;
                    }
                    #endregion
                    // OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                    Service.Ins2Price = Convert.ToInt32(Ins2Price);
                    Service.Ins2PartPrice = Convert.ToInt32(Ins2Part);
                    Service.PatientPayablePrice = Convert.ToInt32(Ins2Payable);
                }
                #endregion
            }
            #endregion

            ReCalculateAddedServicesPrices(false);
            dgvRefServices.Refresh();
            _IsCurrentPatModified = true;
        }
        #endregion

        #region SliderItemCount_ValueChanged
        private void SliderItemCount_ValueChanged(object sender, EventArgs e)
        {
            dgvRefServices.Rows[dgvRefServices.SelectedCells[0].RowIndex].Cells["ColQuantity"].Value =
                SliderItemCount.Value;
            SliderItemCount.Text = "تعداد خدمت: " + SliderItemCount.Value;
            _IsCurrentPatModified = true;
        }
        #endregion

        #endregion

        #region Form Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            if (CurrentFormState != RefFormState.Viewing && _IsCurrentPatModified)
            {
                DialogResult Dr = PMBox.Show("آیا مایلید بدون ذخیره سازی اطلاعات مراجعه بیمار فرم را ببندید؟",
                    "هشدار!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (Dr == DialogResult.No) { e.Cancel = true; return; }
            }
            if (CurrentFormState == RefFormState.Editing)
            {
                Negar.DBLayerPMS.Patients.ChangePatLock(CurrentPatientListID, false);
                DBLayerIMS.Referrals.ChangeRefLock(CurrentRefID, false);
            }
            else if (CurrentFormState == RefFormState.AddingRef)
                Negar.DBLayerPMS.Patients.ChangePatLock(CurrentPatientListID, false);
            Cursor.Current = Cursors.Default;
        }
        #endregion

        #endregion

        #region Methods

        #region @@@ Security Methods @@@

        #region Boolean ReadCurrentUserPermissions()
        /// <summary>
        /// تابع بررسی سطوح دسترسی فرم
        /// </summary>
        /// <returns>صحت خواندن اطلاعات</returns>
        private Boolean ReadCurrentUserPermissions()
        {
            #region # Manage Lock License
            if (LicenseHelper.GetSavedLicenses() == null)
            {
                const String ErrorMessage = "امكان خواندن مجوزهای نصب شده روی قفل سخت افزاری ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            // اگر كاربر مجوز مدیریت پذیرش پیشرفته را نداشته باشد
            if (!LicenseHelper.GetSavedLicenses().Contains("525"))
            {
                if (RibbonOrders.Items.Contains(iContainerRefNav)) RibbonOrders.Items.Remove(iContainerRefNav);
                if (RibbonOrders.Items.Contains(btnRefAddInData)) RibbonOrders.Items.Remove(btnRefAddInData);
            }
            // اگر كاربر مجوز مدیریت حساب را نداشته باشد
            if (!LicenseHelper.GetSavedLicenses().Contains("530"))
            {
                if (RibbonOrders.Items.Contains(btnRefAccount)) RibbonOrders.Items.Remove(btnRefAccount);
            }
            // اگر كاربر مجوز مدیریت مدارك را نداشته باشد
            if (!LicenseHelper.GetSavedLicenses().Contains("550"))
            {
                if (RibbonOrders.Items.Contains(btnRefDocuments)) RibbonOrders.Items.Remove(btnRefDocuments);
            }
            // مجوز استفاده از باركد در سیستم
            if (!LicenseHelper.GetSavedLicenses().Contains("610")) _IsBarcodeActive = true;
            else _IsBarcodeActive = false;
            #endregion

            #region 504 - Manage Ref
            // 504 - مدیریت مراجعات بیماران
            if (SecurityManager.GetCurrentUserPermission(504) == false)
            {
                PMBox.Show("كاربر جاری دسترسی لازم برای مدیریت مراجعات بیماران سیستم را ندارد!",
                    "محدودیت دسترسی!", MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
            }
            // 5041 - دسترسی افزودن بیمار جدید یا مراجعه جدید برای بیمار
            if (!SecurityManager.GetCurrentUserPermission(5041))
            {
                _CanAddPatOrRef = false;
                _CanAddMultipleRefs = false;
                if (RibbonOrders.Items.Contains(btnNewPatient))
                    RibbonOrders.Items.Remove(btnNewPatient);
                if (RibbonOrders.Items.Contains(btnNewRef))
                    RibbonOrders.Items.Remove(btnNewRef);
            }
            else if (!SecurityManager.GetCurrentUserPermission(50411))
            {
                _CanAddMultipleRefs = false;
                if (RibbonOrders.Items.Contains(btnNewRef))
                    RibbonOrders.Items.Remove(btnNewRef);
            }

            #region 50421 - Edit Referral Date And Time
            // امكان ویرایش زمان (تاریخ و ساعت) یك مراجعه در هنگام ثبت یا ویرایش
            if (SecurityManager.GetCurrentUserPermission(50421) == false) _CanEditRefDate = false;
            else _CanEditRefDate = true;
            #endregion

            // 5042 - دسترسی ویرایش اطلاعات مراجعه بیمار
            if (SecurityManager.GetCurrentUserPermission(5042) == false) _CanEditReferral = false;

            #region 5042 - Child Permissions
            else
            {
                #region 50422 - Edit Referral Services
                // دسترسی برای ویرایش اطلاعات خدمات
                if (SecurityManager.GetCurrentUserPermission(50422) == false)
                    _CanEditServices = false;
                else
                {
                    _CanEditServices = true;

                    #region 504221 - Edit Service Quantity
                    // تغییر تعداد خدمات
                    if (SecurityManager.GetCurrentUserPermission(504221) == false)
                        _CanChangeServiceQuantity = false;
                    else _CanChangeServiceQuantity = true;
                    #endregion

                    #region 504222 - Edit Ins1 Cover
                    // خارج كردن خدمات از پوشش بیمه اول
                    if (SecurityManager.GetCurrentUserPermission(504222) == false)
                        if (cmsdgvServices.SubItems.Contains(btnIns1Cover))
                            cmsdgvServices.SubItems.Remove(btnIns1Cover);
                    #endregion

                    #region 504223 - Edit Ins2 Cover
                    // خارج كردن خدمات از پوشش بیمه دوم
                    if (SecurityManager.GetCurrentUserPermission(504223) == false)
                        if (cmsdgvServices.SubItems.Contains(btnIns2Cover))
                            cmsdgvServices.SubItems.Remove(btnIns2Cover);
                    #endregion

                    #region 504224 - Edit Service Activation
                    // لغو یا فعال كردن یك خدمت از مراجعه 
                    if (SecurityManager.GetCurrentUserPermission(504224) == false)
                        _CanChangeServiceActivation = false;
                    else
                    {
                        _CanChangeServiceActivation = true;
                        // امكان لغو خدمت پس از پرداخت
                        if (SecurityManager.GetCurrentUserPermission(5042241) == false)
                            _CanChangeServiceActivationAfterPay = false;
                        else _CanChangeServiceActivationAfterPay = true;
                    }
                    #endregion
                }
                #endregion

                #region 50423 - View Ref Services Price
                //  مشاهده قیمت های خدمات در فرم های مدیریت مراجعات
                if (SecurityManager.GetCurrentUserPermission(50423) == false)
                {
                    List<UsersSetting> Setting401 =
                        DBLayerIMS.Settings.CurrentUserSettingsFullList.Where(Data => Data.SettingIX == 401).ToList();
                    // بررسی آنكه اگر كل پنل قیمت های مراجعه كنترل فعالی ندارد ، مخفی شود
                    if (Setting401.Count == 0 || String.IsNullOrEmpty(Setting401.First().Value) ||
                        Setting401.First().Value.Substring(30, 1) == "0")
                    {
                        PanelTotalPrices.AccessibleDescription = "Hide";
                        PanelTotalPrices.Hide();
                    }
                    else
                    {
                        ColIns1Price.Visible = false;
                        cmsdgvServices.SubItems.Remove(btnServicePrices);
                        lblTotalIns1Price.Visible = false;
                        txtTotalIns1Price.Visible = false;
                        lblTotalIns1Part.Visible = false;
                        txtTotalIns1Part.Visible = false;
                        lblTotalPatPartPrice.Visible = false;
                        txtTotalPatPartPrice.Visible = false;
                        lblRecievable.Hide();
                        lblRecievableValue.Hide();
                        lblPrePayment.Left = lblTotalIns1Price.Left - 20;
                        txtPrePayment.Left = txtTotalIns1Price.Left - 20;
                    }
                }
                #endregion

                #region 50424 - View Referral Addin Data
                //  امكان مشاهده اطلاعات اضافی مراجعه
                if (SecurityManager.GetCurrentUserPermission(50424) == false &&
                    RibbonOrders.Items.Contains(btnRefAddInData))
                    RibbonOrders.Items.Remove(btnRefAddInData);
                // حذف دكمه ی اطلاعات اضافی مراجعه در صورت نداشتن فیلد اطلاعاتی پویا
                else if (DBLayerIMS.Referrals.RefAddinColsList.Count == 0 &&
                    RibbonOrders.Items.Contains(btnRefAddInData))
                    RibbonOrders.Items.Remove(btnRefAddInData);
                // امكان ویرایش فیلدهای پویا مراجعه در خود فرم مدیریت فیلدهای پویا مدیریت می شود
                #endregion

                #region 50425 - Edit Patient's FirstName & LastName
                // دسترسی برای ویرایش نام و نام خانوادگی بیمار
                if (SecurityManager.GetCurrentUserPermission(50425) == false)
                    _CanEditPatientFullName = false;
                else _CanEditPatientFullName = true;
                #endregion

                #region 50426 - Edit Ref Ins
                // دسترسی ویرایش اطلاعات بیمه 1
                if (SecurityManager.GetCurrentUserPermission(50426) == false)
                    _CanEditInsData = false;
                else
                {
                    _CanEditInsData = true;

                    #region 504261 - Can Change Ins 1
                    // دسترسی تغییر بیمه اول
                    if (SecurityManager.GetCurrentUserPermission(504261) == false) _CanChangeIns1 = false;
                    else _CanChangeIns1 = true;
                    #endregion

                    #region 504262 - Can Edit Ins 1 Number
                    // دسترسی امكان تغییر شماره بیمه اول
                    if (SecurityManager.GetCurrentUserPermission(504262) == false) _CanEditIns1Num = false;
                    else _CanEditIns1Num = true;
                    #endregion

                    #region 504263 - Can Edit Ins 1 Expire Date
                    // دسترسی امكان تغییر تاریخ اعتبار بیمه اول
                    if (SecurityManager.GetCurrentUserPermission(504263) == false) _CanEditIns1ExpireDate = false;
                    else _CanEditIns1ExpireDate = true;
                    #endregion

                    #region 504264 - Can Edit Ins 1 Page Numeber
                    // دسترسی امكان تغییر شماره صفحه بیمه اول
                    if (SecurityManager.GetCurrentUserPermission(504264) == false) _CanEditIns1PageNum = false;
                    else _CanEditIns1PageNum = true;
                    #endregion

                    #region 504265 - Can Change Ins 2
                    // دسترسی امكان تغییر بیمه دوم
                    if (SecurityManager.GetCurrentUserPermission(504265) == false) _CanChangeIns2 = false;
                    else _CanChangeIns2 = true;
                    #endregion

                    #region 504266 - Can Edit Ins 2 Number
                    // دسترسی امكان تغییر شماره بیمه دوم
                    if (SecurityManager.GetCurrentUserPermission(504266) == false) _CanEditIns2Num = false;
                    else _CanEditIns2Num = true;
                    #endregion

                }
                #endregion

                #region 50427 - Edit Ref Data After Pay
                // 50427 - دسترسی ویرایش مراجعه پس از پرداخت
                if (SecurityManager.GetCurrentUserPermission(50427) == false) _CanEditReferralAfterPay = false;
                else _CanEditReferralAfterPay = true;
                #endregion

                #region 50428 - Edit Ref Physician
                // 50428 - دسترسی ویرایش پزشك مراجعه پس از ثبت پذیرش
                if (SecurityManager.GetCurrentUserPermission(50428) == false) _CanEditRefPhysician = false;
                else _CanEditRefPhysician = true;
                #endregion

                #region 50429 - Edit Ref Prescription Date
                // 50429 - دسترسی ویرایش تاریخ نسخه مراجعه پس از ثبت پذیرش
                if (SecurityManager.GetCurrentUserPermission(50429) == false) _CanEditPrescriptionDate = false;
                else _CanEditPrescriptionDate = true;
                #endregion

            }
            #endregion

            #region 5043 - Free Patient File And Ref
            // امكان آزاد سازی بیمار
            if (SecurityManager.GetCurrentUserPermission(5043) == false)
            {
                if (btnEditMode.SubItems.Contains(btnFreePatAndRef))
                    btnEditMode.SubItems.Remove(btnFreePatAndRef);
            }
            #endregion

            #endregion

            #region 505 - Manage Account
            // مدیریت حساب بیماران
            if (SecurityManager.GetCurrentUserPermission(505) == false)
                if (RibbonOrders.Items.Contains(btnRefAccount)) RibbonOrders.Items.Remove(btnRefAccount);
            #endregion

            #region 506 - Manage Document
            // مدیریت مدارك بیماران
            if (SecurityManager.GetCurrentUserPermission(506) == false)
            {
                if (RibbonOrders.Items.Contains(btnRefDocuments))
                    RibbonOrders.Items.Remove(btnRefDocuments);
            }
            // ثبت مدرك جدید برای بیمار
            else if (SecurityManager.GetCurrentUserPermission(5061) == false)
            {
                if (btnRefDocuments.SubItems.Contains(btnNewDocument))
                    btnRefDocuments.SubItems.Remove(btnNewDocument);
            }
            #endregion

            return true;
        }
        #endregion

        #region Boolean ReadCurrentUserSettings()
        /// <summary>
        /// تابع اعمال تنظیمات 
        /// </summary>
        /// <returns>صحت خواندن اطلاعات</returns>
        private Boolean ReadCurrentUserSettings()
        {
            if (DBLayerIMS.Settings.CurrentUserSettingsFullList == null) return false;

            #region 301
            // وضعیت نمایش و اجباری بودن فیلدها در فرم مدیریت بیماران
            // فیلد تعیین آشكار بودن سن بیمار برای كاربر جاری
            Boolean IsAgeVisible = true;
            List<UsersSetting> Setting301 =
                DBLayerIMS.Settings.CurrentUserSettingsFullList.Where(Data => Data.SettingIX == 301).ToList();
            if (Setting301.Count != 0 && !String.IsNullOrEmpty(Setting301.First().Value))
            {
                #region Gender
                if (Setting301.First().Value.Substring(0, 1) == "1")
                {
                    if (Setting301.First().Value.Substring(1, 1) == "1") _ShouldEnterGender = true;
                    else _ShouldEnterGender = false;
                }
                else
                {
                    lblGender.Visible = false;
                    PanelGender.Visible = false;
                }
                #endregion

                #region Age
                if (Setting301.First().Value.Substring(2, 1) == "1")
                {
                    cBoxEnterPatAge.Checked = true;
                    if (Setting301.First().Value.Substring(3, 1) == "1")
                        _ShouldEnterBirthDay = true;
                    // اگر جنسیت مخفی باشد
                    if (Setting301.First().Value.Substring(0, 1) != "1")
                    {
                        lblBirthDate.Left += 140;
                        txtAgeYear.Left += 140;
                        txtAgeMonth.Left += 140;
                        txtAgeDay.Left += 140;
                        DateInputBirthDate.Left += 140;
                        cBoxEnterPatAge.Left = txtAgeYear.Left - cBoxEnterPatAge.Width - 5;
                    }
                }
                else
                {
                    IsAgeVisible = false;
                    lblBirthDate.Visible = false;
                    txtAgeYear.Visible = false;
                    txtAgeMonth.Visible = false;
                    txtAgeDay.Visible = false;
                    DateInputBirthDate.Visible = false;
                    cBoxEnterPatAge.Visible = false;
                }
                #endregion

                #region Tel Numbers
                if (Setting301.First().Value.Substring(16, 1) == "1")
                {
                    if (Setting301.First().Value.Substring(17, 1) == "1")
                        _ShouldEnterTelNo1 = true;
                }
                else
                {
                    lblTel1.Visible = false;
                    txtTel1.Visible = false;
                    lblAddress.Left = lblTel2.Left;
                    txtAddress.Width = lblAddress.Left - 15;
                    lblTel2.Left = lblTel1.Left;
                    txtTel2.Left = txtTel1.Left;
                }
                if (Setting301.First().Value.Substring(18, 1) == "1")
                {
                    if (Setting301.First().Value.Substring(19, 1) == "1")
                        _ShouldEnterTelNo2 = true;
                }
                else
                {
                    if (Setting301.First().Value.Substring(16, 1) == "1")
                    {
                        lblAddress.Left = lblTel2.Left;
                        txtAddress.Width = lblAddress.Left - 15;
                    }
                    else
                    {
                        lblAddress.Left = lblTel1.Left;
                        txtAddress.Width = lblAddress.Left - 15;
                    }

                    lblTel2.Visible = false;
                    txtTel2.Visible = false;
                }
                #endregion

                #region Address
                if (Setting301.First().Value.Substring(26, 1) == "1")
                {
                    if (Setting301.First().Value.Substring(27, 1) == "1")
                        _ShouldEnterAddress = true;
                }
                else
                {
                    lblAddress.Visible = false;
                    txtAddress.Visible = false;
                }
                #endregion

                if (Setting301.First().Value.Substring(16, 1) == "0" &&
                    Setting301.First().Value.Substring(18, 1) == "0" &&
                    Setting301.First().Value.Substring(26, 1) == "0")
                    PanelPatientData.Height = 35;
            }
            #endregion
            // تنظیم 302 حذف شد

            #region 303
            // نوع ثبت تاریخ تولد بیمار: به صورت پیش فرض ثبت سن
            if (IsAgeVisible)
            {
                List<UsersSetting> Setting303 =
                    DBLayerIMS.Settings.CurrentUserSettingsFullList.Where(Data => Data.SettingIX == 303).ToList();
                if (Setting303.Count > 0 && Setting303.First().Boolean != null && !Setting303.First().Boolean.Value)
                    cBoxEnterPatAge.Checked = false;
                else
                {
                    cBoxEnterPatAge.Checked = true;
                    List<UsersSetting> Setting307 =
                        DBLayerIMS.Settings.CurrentUserSettingsFullList.Where(Data => Data.SettingIX == 307).ToList();
                    if (Setting307.Count > 0 && !String.IsNullOrEmpty(Setting307.First().Value))
                        _AgeDetailsLimit = Convert.ToInt16(Setting307.First().Value);
                }
            }
            #endregion

            #region 304
            // كنترل وجود بیمار با نام و نام خانوادگی تكراری در هنگام ثبت بیمار
            List<UsersSetting> Setting304 =
                DBLayerIMS.Settings.CurrentUserSettingsFullList.Where(Data => Data.SettingIX == 304).ToList();
            if (Setting304.ToList().Count > 0 && Setting304.First().Boolean == false)
                _ShouldSearchForSamePatient = false;
            else _ShouldSearchForSamePatient = true;
            #endregion

            #region 305
            // ثبت معادل انگلیسی اسامی پرونده بیمار در صورت عدم تشخیص سیستم
            List<UsersSetting> Setting305 =
                DBLayerIMS.Settings.CurrentUserSettingsFullList.Where(Data => Data.SettingIX == 305).ToList();
            if (Setting305.Count > 0 && Setting305.First().Boolean != null && Setting305.First().Boolean.Value)
                _ShouldSaveEnglishName = true;
            else _ShouldSaveEnglishName = false;
            #endregion

            #region 401
            // وضعیت نمایش و اجباری بودن فیلدهای مراجعه در فرم
            List<UsersSetting> Setting401 =
                DBLayerIMS.Settings.CurrentUserSettingsFullList.Where(Data => Data.SettingIX == 401).ToList();
            if (Setting401.Count != 0 && !String.IsNullOrEmpty(Setting401.First().Value))
            {

                #region Referral Controls

                #region 408 - Ref DateTime IsVisible
                List<UsersSetting> Setting408 =
                    DBLayerIMS.Settings.CurrentUserSettingsFullList.Where(Data => Data.SettingIX == 408).ToList();
                if (Setting408.Count != 0 && Setting408.First().Boolean != null && !Setting408.First().Boolean.Value)
                {
                    lblRefDate.Visible = false;
                    DateReferral.Visible = false;
                    lblRefTime.Visible = false;
                    TimeReferral.Visible = false;
                    lblAdmiter.Left = lblRefDate.Left;
                    cboAdmitter.Left = lblAdmiter.Left - cboAdmitter.Width - 8;
                    lblReportDate.Left = TimeReferral.Left;
                    PDateReport.Left = TimeReferral.Left - PDateReport.Width - 5;
                }
                #endregion

                #region 409 - Admiiter Is Visible
                List<UsersSetting> Setting409 =
                    DBLayerIMS.Settings.CurrentUserSettingsFullList.Where(Data => Data.SettingIX == 409).ToList();
                if (Setting409.Count != 0 && Setting409.First().Boolean != null && !Setting409.First().Boolean.Value)
                {
                    lblAdmiter.Visible = false;
                    cboAdmitter.Visible = false;
                    lblReportDate.Left = lblAdmiter.Left;
                    PDateReport.Left = lblAdmiter.Left - PDateReport.Width - 5;
                }
                #endregion

                #region 407 - Report Date Is Visible
                List<UsersSetting> Setting407 =
                    DBLayerIMS.Settings.CurrentUserSettingsFullList.Where(Data => Data.SettingIX == 407).ToList();
                if (Setting407.Count == 0 || Setting407.First().Boolean == null || !Setting407.First().Boolean.Value)
                {
                    lblReportDate.Visible = false;
                    PDateReport.Visible = false;
                }
                else
                {
                    lblReportDate.Visible = true;
                    PDateReport.Visible = true;
                }
                #endregion

                #region 407 && 408 && 409 Is False
                if (Setting407.Count != 0 && Setting407.First().Boolean != null && !Setting407.First().Boolean.Value &&
                    Setting408.Count != 0 && Setting408.First().Boolean != null && !Setting408.First().Boolean.Value &&
                    Setting409.Count != 0 && Setting409.First().Boolean != null && !Setting409.First().Boolean.Value)
                {
                    lblRefStatus.Top = lblPrescribeDate.Top;
                    cboRefStatus.Top = DatePrescribe.Top;
                    lblDescription.Top = lblPrescribeDate.Top;
                    txtDescription.Top = DatePrescribe.Top;
                    lblPrescribeDate.Top = lblRefDate.Top;
                    DatePrescribe.Top = DateReferral.Top;
                    lblWeight.Top = lblRefDate.Top;
                    txtWeight.Top = DateReferral.Top;
                    lblReferralPhysician.Top = lblRefDate.Top;
                    cboRefPhysician.Top = DateReferral.Top;
                    btnEditPhysician.Top = DateReferral.Top;
                    btnAddPhysician.Top = DateReferral.Top;
                    PanelRefData.Height -= 25;
                }
                #endregion

                #region Prescribe Date
                if (Setting401.First().Value.Substring(0, 1) == "1")
                {
                    if (Setting401.First().Value.Substring(1, 1) == "1")
                        _ShouldEnterPrescribeDate = true;
                }
                else
                {
                    lblPrescribeDate.Visible = false;
                    DatePrescribe.Visible = false;
                    DatePrescribe.TabStop = false;
                    lblReferralPhysician.Left = lblWeight.Left;
                    cboRefPhysician.Width = txtWeight.Left - cboRefPhysician.Left + txtWeight.Width;
                    lblWeight.Left = lblPrescribeDate.Left;
                    txtWeight.Left = DatePrescribe.Left + 23;
                }
                #endregion

                #region Weight
                if (Setting401.First().Value.Substring(2, 1) == "1")
                {
                    if (Setting401.First().Value.Substring(3, 1) == "1")
                        _ShouldEnterWeight = true;
                }
                else
                {
                    lblWeight.Hide();
                    txtWeight.Hide();
                    txtWeight.TabStop = false;
                    lblReferralPhysician.Left = lblWeight.Left;
                    cboRefPhysician.Width = txtWeight.Left - cboRefPhysician.Left + txtWeight.Width;
                }
                #endregion

                #region Referral Physician
                if (Setting401.First().Value.Substring(4, 1) == "1")
                {
                    if (Setting401.First().Value.Substring(5, 1) == "1")
                        _ShouldEnterReferralPhysician = true;
                    else _ShouldEnterReferralPhysician = false;
                }
                else
                {
                    btnAddPhysician.Visible = false;
                    btnEditPhysician.Visible = false;
                    lblReferralPhysician.Visible = false;
                    cboRefPhysician.Visible = false;
                }
                #endregion

                #region "PrescribeDate" & "Weight" & "ReferralPhysician"
                if (Setting401.First().Value.Substring(0, 1) == "0" &&
                 Setting401.First().Value.Substring(2, 1) == "0" &&
                 Setting401.First().Value.Substring(4, 1) == "0")
                {
                    PanelRefData.Height -= 25;
                }
                #endregion

                #region RefStatus
                if (Setting401.First().Value.Substring(6, 1) == "1")
                {
                    if (Setting401.First().Value.Substring(7, 1) == "1")
                        _ShouldEnterRefStatus = true;
                }
                else
                {
                    lblRefStatus.Visible = false;
                    cboRefStatus.Visible = false;
                    cboRefStatus.TabStop = false;
                    lblDescription.Left = lblRefStatus.Left;
                    txtDescription.Width = cboRefStatus.Left + cboRefStatus.Width - txtDescription.Left;
                }
                #endregion

                #region Description
                if (Setting401.First().Value.Substring(8, 1) == "1")
                {
                    if (Setting401.First().Value.Substring(9, 1) == "1")
                        _ShouldEnterDescription = true;
                }
                else
                {
                    lblDescription.Visible = false;
                    txtDescription.Visible = false;
                    txtDescription.TabStop = false;
                }
                #endregion

                #region "RefStatus" & "Description"
                if (Setting401.First().Value.Substring(6, 1) == "0" &&
                    Setting401.First().Value.Substring(8, 1) == "0")
                    PanelRefData.Height -= 25;
                else
                {
                    if (Setting401.First().Value.Substring(0, 1) == "0" &&
                    Setting401.First().Value.Substring(2, 1) == "0" &&
                    Setting401.First().Value.Substring(4, 1) == "0")
                    {
                        lblRefStatus.Top = lblPrescribeDate.Top;
                        cboRefStatus.Top = DatePrescribe.Top;
                        lblDescription.Top = lblPrescribeDate.Top;
                        txtDescription.Top = DatePrescribe.Top;
                    }
                }
                #endregion

                if (Setting408.Count != 0 && Setting408.First().Boolean != null && !Setting408.First().Boolean.Value &&
                    Setting409.Count != 0 && Setting409.First().Boolean != null && !Setting409.First().Boolean.Value &&
                    Setting401.First().Value.Substring(0, 1) == "0" &&
                    Setting401.First().Value.Substring(2, 1) == "0" &&
                    Setting401.First().Value.Substring(4, 1) == "0" &&
                    Setting401.First().Value.Substring(6, 1) == "0" &&
                    Setting401.First().Value.Substring(8, 1) == "0")
                {
                    PanelRefData.AccessibleDescription = "Hide";
                    PanelRefData.Hide();
                }
                #endregion

                #region Ins1

                #region @@@ Ins1Num1 , Ins1Num2 , Ins1ExpireDate , Ins1PageNo @@@
                if (Setting401.First().Value.Substring(12, 1) == "0" &&
                 Setting401.First().Value.Substring(14, 1) == "0" &&
                 Setting401.First().Value.Substring(16, 1) == "0") PanelIns1.Height -= 25;
                #endregion

                #region Ins1
                if (Setting401.First().Value.Substring(10, 1) == "1")
                {
                    if (Setting401.First().Value.Substring(11, 1) == "1")
                        _ShouldEnterIns1 = true;
                }
                else
                {
                    PanelIns1.AccessibleDescription = "Hide";
                    PanelIns1.Visible = false;
                }
                #endregion

                #region Ins1Num
                if (Setting401.First().Value.Substring(12, 1) == "1")
                {
                    if (Setting401.First().Value.Substring(13, 1) == "1")
                        _ShouldEnterIns1Num = true;
                }
                else
                {
                    lblIns1No1.Visible = false;
                    txtIns1No1.Visible = false;
                    lblPageNo.Left = lblIns1ExpireDate.Left;
                    txtPageNo.Left = Ins1ExpireDate.Left + Ins1ExpireDate.Width - txtPageNo.Width;
                    lblIns1ExpireDate.Left = lblIns1No1.Left;
                    Ins1ExpireDate.Left = txtIns1No1.Left + txtIns1No1.Width - Ins1ExpireDate.Width;
                }
                #endregion

                #region Ins1ExpireDate
                if (Setting401.First().Value.Substring(14, 1) == "1")
                {
                    if (Setting401.First().Value.Substring(15, 1) == "1")
                        _ShouldEnterIns1ExpireDate = true;
                }
                else
                {
                    lblIns1ExpireDate.Visible = false;
                    Ins1ExpireDate.Visible = false;
                    if (Setting401.First().Value.Substring(12, 1) == "0")
                    {
                        lblPageNo.Left = lblIns1No1.Left;
                        txtPageNo.Left = txtIns1No1.Left + txtIns1No1.Width - txtPageNo.Width;
                    }
                    else
                    {
                        lblPageNo.Left = lblIns1ExpireDate.Left;
                        txtPageNo.Left = Ins1ExpireDate.Left + Ins1ExpireDate.Width - txtPageNo.Width;
                    }
                }
                #endregion

                #region Ins1PageNo
                if (Setting401.First().Value.Substring(16, 1) == "1")
                {
                    if (Setting401.First().Value.Substring(17, 1) == "1")
                        _ShouldEnterPageNo = true;
                }
                else
                {
                    lblPageNo.Visible = false;
                    txtPageNo.Visible = false;
                }
                #endregion

                #endregion

                #region Ins2

                #region Ins2
                if (Setting401.First().Value.Substring(18, 1) == "1")
                {
                    if (Setting401.First().Value.Substring(19, 1) == "1")
                        _ShouldEnterIns2 = true;
                }
                else
                {
                    PanelIns2.AccessibleDescription = "Hide";
                    PanelIns2.Visible = false;
                }
                #endregion

                #region Ins2Num
                if (Setting401.First().Value.Substring(20, 1) == "1")
                {
                    if (Setting401.First().Value.Substring(21, 1) == "1")
                        _ShouldEnterIns2Num = true;
                }
                else
                {
                    lblIns2No1.Visible = false;
                    txtIns2No1.Visible = false;
                    lblIns2ExpireDate.Left = lblIns2No1.Left;
                    Ins2ExpireDate.Left = txtIns2No1.Left + txtIns2No1.Width - Ins2ExpireDate.Width;
                }
                #endregion

                #region Ins2ExpireDate
                if (Setting401.First().Value.Substring(22, 1) == "1")
                {
                    if (Setting401.First().Value.Substring(23, 1) == "1")
                        _ShouldEnterIns2ExpireDate = true;
                }
                else
                {
                    lblIns2ExpireDate.Visible = false;
                    Ins2ExpireDate.Visible = false;
                }
                #endregion

                #endregion

                #region Services

                #region Show Services
                if (Setting401.First().Value.Substring(24, 1) == "0")
                {
                    PanelRefServices.AccessibleDescription = "Hide";
                    PanelRefServices.Hide();
                }
                else PanelRefServices.AccessibleDescription = "Show";
                if (Setting401.First().Value.Substring(25, 1) == "1") _ShouldEnterServices = true;
                #endregion

                #region ServiceExpert
                if (Setting401.First().Value.Substring(26, 1) == "1")
                {
                    if (Setting401.First().Value.Substring(27, 1) == "1")
                        _ShouldEnterServiceExpert = true;
                }
                else
                {
                    lblServiceExpert.Hide();
                    cboServiceExpert.Visible = false;
                    ColExpert.Visible = false;
                    Int32 OldX = lblServicePhysician.Location.X;
                    lblServicePhysician.Location = new Point(lblServiceExpert.Location.X + 15, lblServiceExpert.Location.Y);
                    OldX = lblServicePhysician.Location.X - OldX;
                    cboServicePhysician.Location =
                        new Point(cboServicePhysician.Location.X + OldX, cboServicePhysician.Location.Y);
                }
                #endregion

                #region ServicePhysician
                if (Setting401.First().Value.Substring(28, 1) == "1")
                {
                    if (Setting401.First().Value.Substring(29, 1) == "1")
                        _ShouldEnterServicePhysician = true;
                }
                else
                {
                    lblServicePhysician.Hide();
                    cboServicePhysician.Visible = false;
                    ColPhysician.Visible = false;
                }
                #endregion

                #endregion

                #region PrePayment
                if (Setting401.First().Value.Substring(30, 1) == "1")
                {
                    if (Setting401.First().Value.Substring(31, 1) == "1")
                        _ShouldEnterPrePayment = true;
                }
                else
                {
                    lblPrePayment.Hide();
                    txtPrePayment.Visible = false;
                }
                #endregion
            }
            // برای تنظیمات پیش فرض
            else
            {
                #region Report Date Is Visible
                lblReportDate.Visible = false;
                PDateReport.Visible = false;
                #endregion

                #region Patient Address
                lblAddress.Visible = false;
                txtAddress.Visible = false;
                #endregion

                #region Weight
                lblWeight.Hide();
                txtWeight.Hide();
                txtWeight.TabStop = false;
                lblReferralPhysician.Left = lblWeight.Left;
                cboRefPhysician.Width = txtWeight.Left - cboRefPhysician.Left + txtWeight.Width;
                #endregion

                #region RefStatus
                lblRefStatus.Visible = false;
                cboRefStatus.Visible = false;
                cboRefStatus.TabStop = false;
                lblDescription.Left = lblRefStatus.Left;
                txtDescription.Width = cboRefStatus.Left + cboRefStatus.Width - txtDescription.Left;
                #endregion

                #region Description
                lblDescription.Visible = false;
                txtDescription.Visible = false;
                txtDescription.TabStop = false;
                #endregion

                PanelRefData.Height -= 25;

                #region Ins2ExpireDate
                lblIns2ExpireDate.Visible = false;
                Ins2ExpireDate.Visible = false;
                #endregion

                #region PrePayment
                lblPrePayment.Hide();
                txtPrePayment.Visible = false;
                #endregion

            }
            #endregion
            // تنظیمات 402 حذف گردید
            #region 403
            // امكان تغییر نام پذیرش كننده
            List<UsersSetting> Setting403 =
                DBLayerIMS.Settings.CurrentUserSettingsFullList.Where(Data => Data.SettingIX == 403).ToList();
            if (Setting403.Count == 0 || Setting403.First().Boolean == null ||
                !Setting403.First().Boolean.Value) _CanChangeAdmitter = false;
            else _CanChangeAdmitter = true;
            #endregion
            // تنظیمات 404 حذف گردید
            #region 405
            // اخطار در صورت ثبت تاریخ اعتبار فاقد اعتبار هنگام ثبت مراجعه
            List<UsersSetting> Setting405 =
                DBLayerIMS.Settings.CurrentUserSettingsFullList.Where(Data => Data.SettingIX == 405).ToList();
            if (Setting405.Count == 0 || Setting405.First().Boolean == null || Setting405.First().Boolean.Value)
                _ShouldWarnForInsExpireDate = true;
            else _ShouldWarnForInsExpireDate = false;
            #endregion

            #region 406
            // امكان ورود ردیف خدمت تكراری
            List<UsersSetting> Setting406 =
                DBLayerIMS.Settings.CurrentUserSettingsFullList.Where(Data => Data.SettingIX == 406).ToList();
            if (Setting406.Count == 0 || Setting406.First().Boolean == null || Setting406.First().Boolean.Value)
                _CanAddMultipleServices = true;
            else _CanAddMultipleServices = false;
            #endregion

            #region 410
            // هشدار در صورت عدم ورود شماره بیمه اول
            if (!PanelIns1.Visible || !txtIns1No1.Visible || _ShouldEnterIns1Num) _ShouldWarnIns1Num = false;
            else
            {
                List<UsersSetting> Setting410 =
                    DBLayerIMS.Settings.CurrentUserSettingsFullList.Where(Data => Data.SettingIX == 410).ToList();
                if (Setting410.Count == 0 || Setting410.First().Boolean == null || !Setting410.First().Boolean.Value)
                    _ShouldWarnIns1Num = false;
                else _ShouldWarnIns1Num = true;
            }
            #endregion

            if (PanelRefData.AccessibleDescription == "Hide") Height -= PanelRefData.Height - 2;
            if (PanelIns1.AccessibleDescription == "Hide") Height -= PanelIns1.Height - 2;
            if (PanelIns2.AccessibleDescription == "Hide") Height -= PanelIns2.Height - 2;
            if (lblPrePayment.Visible == false && lblIns1Price.Visible == false) Height -= PanelTotalPrices.Height - 2;
            if (PanelRefServices.AccessibleDescription == "Hide") Height -= PanelRefServices.Height - 2;
            return true;
        }
        #endregion

        #endregion

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

            #region btnNewPatient
            TooltipText = ToolTipManager.GetText("btnNewPatRef", "IMS");
            FormToolTip.SetSuperTooltip(btnNewPatient, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnPatientDetailsData
            TooltipText = ToolTipManager.GetText("btnPatDetailsData", "IMS");
            FormToolTip.SetSuperTooltip(btnPatientFile, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnPrevPatient
            TooltipText = ToolTipManager.GetText("btnPatPrevPatient", "IMS");
            FormToolTip.SetSuperTooltip(btnPrevPatient, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnNextPatient
            TooltipText = ToolTipManager.GetText("btnPatNextPatient", "IMS");
            FormToolTip.SetSuperTooltip(btnNextPatient, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnRefresh
            TooltipText = ToolTipManager.GetText("btnRefresh", "IMS");
            FormToolTip.SetSuperTooltip(btnRefresh, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnEditMode
            TooltipText = ToolTipManager.GetText("btnRefEditRef", "IMS");
            FormToolTip.SetSuperTooltip(btnEditMode, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnFreePatAndRef
            TooltipText = ToolTipManager.GetText("btnRefFreeRef", "IMS");
            FormToolTip.SetSuperTooltip(btnFreePatAndRef, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnRefAddInData
            TooltipText = ToolTipManager.GetText("btnRefAddInData", "IMS");
            FormToolTip.SetSuperTooltip(btnRefAddInData, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnRefAccount
            TooltipText = ToolTipManager.GetText("btnRefAccount", "IMS");
            FormToolTip.SetSuperTooltip(btnRefAccount, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnRefDocuments
            TooltipText = ToolTipManager.GetText("btnRefDocuments", "IMS");
            FormToolTip.SetSuperTooltip(btnRefDocuments, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnPrint
            TooltipText = ToolTipManager.GetText("btnPrintRefBill", "IMS");
            FormToolTip.SetSuperTooltip(btnPrint, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region cboPrintTemplates
            TooltipText = ToolTipManager.GetText("cboPrintTemplates", "IMS");
            FormToolTip.SetSuperTooltip(cboPrintTemplates, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnPrintPreview
            TooltipText = ToolTipManager.GetText("btnPrintPreviewRefBill", "IMS");
            FormToolTip.SetSuperTooltip(btnPrintPreview, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnAddPhysician
            TooltipText = ToolTipManager.GetText("btnAddRefPhysician", "IMS");
            FormToolTip.SetSuperTooltip(btnAddPhysician, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnEditPhysician
            TooltipText = ToolTipManager.GetText("btnEditRefPhysician", "IMS");
            FormToolTip.SetSuperTooltip(btnEditPhysician, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnInsDetails
            TooltipText = ToolTipManager.GetText("btnRefInsDetails", "IMS");
            FormToolTip.SetSuperTooltip(btnIns1Details, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            FormToolTip.SetSuperTooltip(btnIns2Details, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnChooseService
            TooltipText = ToolTipManager.GetText("btnRefServiceSelection", "IMS");
            FormToolTip.SetSuperTooltip(btnChooseService, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion
        }
        #endregion

        #region void SetFormControlsChangeEventHandlers()
        /// <summary>
        /// تابعی برای تنظیم رخداد تغییر برای كنترل های روی فرم
        /// </summary>
        private void SetFormControlsChangeEventHandlers()
        {
            #region PanelPatientData
            foreach (Control ctrl in PanelPatientData.Controls)
            {
                if (ctrl is TextBoxX)
                {
                    ctrl.TextChanged += (FormControls_ValuesChanged);
                    ctrl.Validating += (TextBoxes_Validating);
                }
                else if (ctrl is IntegerInput)
                    ((IntegerInput)ctrl).ValueChanged += (FormControls_ValuesChanged);
                else if (ctrl is PersianDatePicker)
                    ((PersianDatePicker)ctrl).SelectedDateTimeChanged += (FormControls_ValuesChanged);
                else if (ctrl is GroupPanel)
                    foreach (Control control in ctrl.Controls)
                        if (control is CheckBoxX) ((CheckBoxX)control).CheckedChanged += (FormControls_ValuesChanged);
            }
            #endregion

            #region PanelRefData
            foreach (Control ctrl in PanelRefData.Controls)
            {
                // TextBoxes:
                if (ctrl is TextBoxX)
                {
                    ctrl.TextChanged += (FormControls_ValuesChanged);
                    ctrl.Validating += (TextBoxes_Validating);
                }
                // PersianDatePicker:
                else if (ctrl is PersianDatePicker)
                    ((PersianDatePicker)ctrl).SelectedDateTimeChanged += (FormControls_ValuesChanged);
                // DateTimeInput:
                else if (ctrl is DateTimeInput)
                {
                    ((DateTimeInput)ctrl).ValueChanged += (FormControls_ValuesChanged);
                    ((DateTimeInput)ctrl).ValueObjectChanged += (FormControls_ValuesChanged);
                }
                // ComboBoxes:
                else if (ctrl is IMSComboBox)
                {
                    ((IMSComboBox)ctrl).SelectedValueChanged += (FormControls_ValuesChanged);
                    ctrl.TextChanged += (FormControls_ValuesChanged);
                    ctrl.KeyPress += (FormControls_ValuesChanged);
                }
                else if (ctrl is ComboBox)
                    ((ComboBox)ctrl).SelectedValueChanged += (FormControls_ValuesChanged);
                // Inputs:
                else if (ctrl is DoubleInput)
                {
                    ((DoubleInput)ctrl).ValueChanged += (FormControls_ValuesChanged);
                    ((DoubleInput)ctrl).ValueObjectChanged += (FormControls_ValuesChanged);
                }
            }
            #endregion

            #region PanelIns1
            foreach (Control ctrl in PanelIns1.Controls)
            {
                // TextBoxes:
                if (ctrl is TextBoxX)
                {
                    ctrl.TextChanged += (FormControls_ValuesChanged);
                    ctrl.Validating += (TextBoxes_Validating);
                }
                // DateTimeInput:
                else if (ctrl is PersianDatePicker)
                    ((PersianDatePicker)ctrl).SelectedDateTimeChanged += FormControls_ValuesChanged;
                // ComboBoxes:
                else if (ctrl is ComboBox)
                    ((ComboBox)ctrl).SelectedValueChanged +=
                        (FormControls_ValuesChanged);
                // Inputs:
                else if (ctrl is IntegerInput)
                    ((IntegerInput)ctrl).ValueChanged += (FormControls_ValuesChanged);
                else if (ctrl is DoubleInput)
                    ((DoubleInput)ctrl).ValueChanged += (FormControls_ValuesChanged);
            }
            #endregion

            #region PanelIns2
            foreach (Control ctrl in PanelIns2.Controls)
            {
                // TextBoxes:
                if (ctrl is TextBoxX)
                {
                    ctrl.TextChanged += (FormControls_ValuesChanged);
                    ctrl.Validating += (TextBoxes_Validating);
                }
                // DateTimeInput:
                else if (ctrl is PersianDatePicker)
                    ((PersianDatePicker)ctrl).SelectedDateTimeChanged += (FormControls_ValuesChanged);
                // ComboBoxes:
                else if (ctrl is ComboBox) ((ComboBox)ctrl).SelectedValueChanged += (FormControls_ValuesChanged);
                // Inputs:
                else if (ctrl is IntegerInput) ((IntegerInput)ctrl).ValueChanged += (FormControls_ValuesChanged);
            }
            #endregion

            #region PanelRefServices
            foreach (Control ctrl in PanelRefServices.Controls)
            {
                // TextBoxes:
                if (ctrl is TextBoxX)
                {
                    ctrl.TextChanged += (FormControls_ValuesChanged);
                    ctrl.Validating += (TextBoxes_Validating);
                }
                // ComboBoxes:
                else if (ctrl is ComboBox) ((ComboBox)ctrl).SelectedValueChanged += (FormControls_ValuesChanged);
                // Inputs:
                else if (ctrl is IntegerInput) ((IntegerInput)ctrl).ValueChanged += (FormControls_ValuesChanged);
            }
            #endregion

            // كنترل پیش پرداخت:
            txtPrePayment.ValueChanged += (FormControls_ValuesChanged);
            txtPrePayment.ValueObjectChanged += (FormControls_ValuesChanged);
        }
        #endregion

        // OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO

        #region Boolean AddNewServiceToGrid(Int16 ServiceID , Byte Quantity)
        /// <summary>
        /// تابع افزودن یك خدمت بر اساس كلید و تعداد خدمت
        /// </summary>
        /// <param name="ServiceID">كلید خدمت</param>
        /// <param name="Quantity">تعداد خدمت</param>
        /// <returns>صحت انجام كار</returns>
        private Boolean AddNewServiceToGrid(Int16 ServiceID, Byte Quantity)
        {
            #region Calculate Service Properties
            RefService NewRefService = new RefService();
            NewRefService.ReferralIX = CurrentRefID;
            NewRefService.ServiceIX = ServiceID;
            NewRefService.IsActive = true;
            NewRefService.Quantity = Quantity;
            // ==========================================
            // Expert ID:
            // بررسی وجود كارشناس پیش فرض برای خدمت ثبت شده در امروز 
            if (cboServiceExpert.SelectedIndex == 0)
            {
                Int16? DefaultExpertID = GetServiceDefaultPerformer(ServiceID, true);
                NewRefService.ExpertIX = DefaultExpertID;
            }
            else NewRefService.ExpertIX = Convert.ToInt16(cboServiceExpert.SelectedValue);
            // ==========================================
            // Physician ID:
            // بررسی وجود پزشك پیش فرض برای خدمت ثبت شده در امروز 
            if (cboServicePhysician.SelectedIndex == 0)
            {
                Int16? DefaultPhysicianID = GetServiceDefaultPerformer(ServiceID, false);
                NewRefService.PhysicianIX = DefaultPhysicianID;
            }
            else NewRefService.PhysicianIX = Convert.ToInt16(cboServicePhysician.SelectedValue);
            #endregion

            CalculateServiceInsPrices(NewRefService);

            #region Add Service To RefServices DataSource
            // اضافه كردن سرویس انتخاب شده به شیء خدمات مراجعه جاری
            try
            {
                if (CurrentFormState == RefFormState.AddingPatRef ||
                    CurrentFormState == RefFormState.AddingRef) _RefServices.Add(NewRefService);
                else if (CurrentFormState == RefFormState.Editing)
                {
                    _RefServices.Add(NewRefService);
                    DBLayerIMS.Manager.DBML.RefServices.InsertOnSubmit(NewRefService);
                }
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان ثبت خدمت وارد شده وجود ندارد!";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Admission Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion
            #endregion

            dgvRefServices.Refresh();
            dgvRefServices.Invalidate();
            return true;
        }
        #endregion

        #region Boolean CalculateServicePrices(RefService Service)
        /// <summary>
        /// تابع به روز رسانی اطلاعات قیمت یك خدمت برای مراجعات دارای بیمه
        /// </summary>
        /// <param name="Service">شیء خدمت مراجعه</param>
        private Boolean CalculateServiceInsPrices(RefService Service)
        {
            #region Ins 1 Is Not Selected
            // قیمت خدمت به صورت آزاد محاسبه می گردد
            // و پوشش بیمه ها غیر فعال می گردد
            if (cboIns1.SelectedIndex == 0)
            {
                Service.IsIns1Cover = false;
                Service.Ins1Price = null;
                Service.Ins1PartPrice = null;
                Service.IsIns2Cover = false;
                Service.Ins2Price = null;
                Service.Ins2PartPrice = null;
                // پرداختنی بیمار بر اساس ستون قیمت بدون بیمه خدمت محاسبه می شود
                Service.PatientPayablePrice =
                    DBLayerIMS.Services.ServicesList.Where(Data => Data.ID == Service.ServiceIX).
                    Select(Data => Data.PriceFree).First();
            }
            #endregion

            #region Ins 1 Is Selected
            // حالتی كه بیمه اول انتخاب شده 
            // باید بررسی شود كه بیمه انتخاب شده خدمت انتخابی را پوشش می دهد
            // و آیا بیمه دومی انتخاب شده؟
            // بیمه دوم انتخاب شده خدمت را پوشش می دهد؟
            else
            {
                // پیمایش بین جدول ارتباط بیمه ها و خدمات برای بدست آوردن قیمت های خدمات مورد نظر در بیمه ی اول انتخاب شده
                List<InsuranceService> CurrentServiceIns1Data =
                        DBLayerIMS.Insurance.InsServiceFullList.Where(Result => Result.ServiceIX == Service.ServiceIX &&
                            Result.InsIX == Convert.ToInt16(cboIns1.SelectedValue)).ToList();
                // پیمایش بین جدول ارتباط بیمه ها و خدمات برای بدست آوردن قیمت های خدمات مورد نظر در بیمه ی دوم انتخاب شده
                List<InsuranceService> CurrentServiceIns2Data =
                    DBLayerIMS.Insurance.InsServiceFullList.Where(Result => Result.ServiceIX == Service.ServiceIX &&
                        Result.InsIX == Convert.ToInt16(cboIns2.SelectedValue)).ToList();

                #region Ins 1 Is Covered
                // بررسی حالتی كه بیمه اول انتخابی خدمت را پوشش می دهد
                // و آیا بیمه دومی انتخاب شده؟ و بیمه دوم انتخاب شده خدمت را پوشش می دهد؟
                if (CurrentServiceIns1Data.Count() != 0 && CurrentServiceIns1Data.First().IsCover)
                {

                    #region Ins 2 Is Selected And Covered
                    if (cboIns2.SelectedIndex != 0 && CurrentServiceIns2Data.Count() != 0 &&
                        CurrentServiceIns2Data.First().IsCover)
                    {
                        Service.IsIns1Cover = true;
                        Service.IsIns2Cover = true;
                        Service.Ins1Price = CurrentServiceIns1Data.First().InsPrice;
                        Service.Ins1PartPrice = CurrentServiceIns1Data.First().InsPart;
                        // OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                        SP_SelectInsFullDataResult Ins1Data =
                            DBLayerIMS.Insurance.InsFullList.Where(Result => Result.ID == Convert.ToInt16(cboIns1.SelectedValue)).First();
                        SP_SelectInsFullDataResult Ins2Data =
                            DBLayerIMS.Insurance.InsFullList.Where(Result => Result.ID == Convert.ToInt16(cboIns2.SelectedValue)).First();
                        // OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                        Int32? Ins2Price = 0;
                        Int32? Ins2Part = 0;
                        Int32? Ins2Payable = 0;
                        Int32? Ins1PatientPart = Service.Ins1Price - Service.Ins1PartPrice;
                        if (Service.Ins2Price == null) Service.Ins2Price = 0;
                        // OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                        try
                        {
                            Int32 CurrentServiceIns1PatientPayable = 0;
                            if (CurrentServiceIns1Data.Count != 0)
                                CurrentServiceIns1PatientPayable = CurrentServiceIns1Data.First().PatientPayable;
                            // تابع محاسبه قیمت های بیمه دوم بر اساس فرمول بیمه در اینجا فراخوانی می گردد
                            DBLayerIMS.Manager.DBML.SP_GenerateIns2Prices(
                                // بیمه دوم انتخاب شده
                                Convert.ToInt16(cboIns2.SelectedValue),
                                // خدمت انتخاب شده
                                Service.ServiceIX,
                                // قیمت بیمه اول محاسبه شده
                                Service.Ins1Price,
                                // قیمت سهم بیمه اول محاسبه شده
                                Service.Ins1PartPrice,
                                // قیمت سهم بیمار از بیمه اول محاسبه شده
                                Ins1PatientPart,
                                // قیمت پرداختنی بیمار بابت بیمه اول محاسبه شده
                                CurrentServiceIns1PatientPayable,
                                // قیمت سقف تعهد بیمه اول
                                Ins1Data.InsurerPartLimit,
                                // درصد بیمار برای بیمه اول
                                Ins1Data.PatientPercent,
                                // درصد بیمار برای بیمه اول
                                Ins2Data.InsurerPartLimit,
                                // خروجی 3 قیمت تولید شده
                                ref Ins2Price, ref Ins2Part, ref Ins2Payable);
                        }
                        #region Catch
                        catch (Exception Ex)
                        {
                            const String ErrorMessage =
                                "امكان خواندن اطلاعات مبالغ بیمه دوم خدمات از بانك اطلاعات ممكن نیست.\n" +
                                "موارد زیر را بررسی نمایید:\n" +
                                "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                            PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            LogManager.SaveLogEntry("Sepehr", "Admission Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                            return false;
                        }
                        #endregion
                        // OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                        Service.Ins2Price = Convert.ToInt32(Ins2Price);
                        Service.Ins2PartPrice = Convert.ToInt32(Ins2Part);
                        Service.PatientPayablePrice = Convert.ToInt32(Ins2Payable);
                    }
                    #endregion

                    #region Ins 2 Is Not Selected Or Not Covered
                    else
                    {
                        Service.IsIns1Cover = true;
                        Service.IsIns2Cover = false;
                        Service.Ins1Price = CurrentServiceIns1Data.First().InsPrice;
                        Service.Ins1PartPrice = CurrentServiceIns1Data.First().InsPart;
                        Service.Ins2Price = null;
                        Service.Ins2PartPrice = null;
                        Service.PatientPayablePrice = CurrentServiceIns1Data.First().PatientPayable;
                    }
                    #endregion

                }
                #endregion

                #region Ins 1 Is Not Covered
                // حالتی كه بیمه اول خدمت انتخابی را پوشش نمی دهد
                // و آیا بیمه دومی انتخاب شده؟ و بیمه دوم انتخاب شده خدمت را پوشش می دهد؟
                else
                {
                    #region Ins 2 Is Selected And Covered
                    if (cboIns2.SelectedIndex != 0 && CurrentServiceIns2Data.Count() != 0 &&
                        CurrentServiceIns2Data.First().IsCover)
                    {
                        Service.IsIns1Cover = false;
                        Service.IsIns2Cover = true;
                        Service.Ins1Price = null;
                        Service.Ins1PartPrice = null;

                        SP_SelectInsFullDataResult Ins1Data =
                            DBLayerIMS.Insurance.InsFullList.Where(Result => Result.ID == Convert.ToInt16(cboIns1.SelectedValue)).First();
                        SP_SelectInsFullDataResult Ins2Data =
                            DBLayerIMS.Insurance.InsFullList.Where(Result => Result.ID == Convert.ToInt16(cboIns2.SelectedValue)).First();
                        // OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                        Int32? Ins2Price = 0;
                        Int32? Ins2Part = 0;
                        Int32? Ins2Payable = 0;
                        Int32? Ins1PatientPart = Service.Ins1Price - Service.Ins1PartPrice;
                        if (Service.Ins2Price == null) Service.Ins2Price = 0;
                        // OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                        try
                        {
                            Int32 CurrentServiceIns1PatientPayable = 0;
                            if (CurrentServiceIns1Data.Count != 0)
                                CurrentServiceIns1PatientPayable = CurrentServiceIns1Data.First().PatientPayable;
                            // تابع محاسبه قیمت های بیمه دوم بر اساس فرمول بیمه در اینجا فراخوانی می گردد
                            DBLayerIMS.Manager.DBML.SP_GenerateIns2Prices(
                                // بیمه دوم انتخاب شده
                                Convert.ToInt16(cboIns2.SelectedValue),
                                // خدمت انتخاب شده
                                Service.ServiceIX,
                                // قیمت بیمه اول محاسبه شده
                                Service.Ins1Price,
                                // قیمت سهم بیمه اول محاسبه شده
                                Service.Ins1PartPrice,
                                // قیمت سهم بیمار از بیمه اول محاسبه شده
                                Ins1PatientPart,
                                // قیمت پرداختنی بیمار بابت بیمه اول محاسبه شده
                                CurrentServiceIns1PatientPayable,
                                // قیمت سقف تعهد بیمه اول
                                Ins1Data.InsurerPartLimit,
                                // درصد بیمار برای بیمه اول
                                Ins1Data.PatientPercent,
                                // درصد بیمار برای بیمه اول
                                Ins2Data.InsurerPartLimit,
                                // خروجی 3 قیمت تولید شده
                                ref Ins2Price, ref Ins2Part, ref Ins2Payable);
                        }
                        #region Catch
                        catch (Exception Ex)
                        {
                            const String ErrorMessage =
                                "امكان خواندن اطلاعات قیمت های بیمه دوم خدمت از بانك اطلاعات ممكن نیست.\n" +
                                "موارد زیر را بررسی نمایید:\n" +
                                "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                            PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            LogManager.SaveLogEntry("Sepehr", "Admission Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                            return false;
                        }
                        #endregion
                        // OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                        Service.Ins2Price = Convert.ToInt32(Ins2Price);
                        Service.Ins2PartPrice = Convert.ToInt32(Ins2Part);
                        Service.PatientPayablePrice = Convert.ToInt32(Ins2Payable);
                    }
                    #endregion

                    #region Ins 2 Is Not Selected Or Not Covered
                    else
                    {
                        Service.IsIns1Cover = false;
                        Service.IsIns2Cover = false;
                        Service.Ins1Price = null;
                        Service.Ins1PartPrice = null;
                        Service.Ins2Price = null;
                        Service.Ins2PartPrice = null;
                        Service.PatientPayablePrice = DBLayerIMS.Services.ServicesList.Where(result => result.ID == Service.ServiceIX).
                            Select(result => result.PriceFree).First();
                    }
                    #endregion
                }
                #endregion

            }
            #endregion

            return true;
        }
        #endregion

        #region void ReCalculateAddedServicesPrices(Boolean ShouldRecalculate)
        /// <summary>
        /// تابعی برای محاسبه مجدد قیمت خدمات موجود در مراجعه ی بیمار بر اساس بیمه های انتخاب شده
        /// </summary>
        /// <param name="ShouldRecalculate">محاسبه مجدد قیمت های بیمه خدمات یا تنها محاسبه مجموع قیمت ها</param>
        private void ReCalculateAddedServicesPrices(Boolean ShouldRecalculate)
        {
            if (_RefServices == null) return;
            if (ShouldRecalculate)
            {
                // جستجو بین خدمات فعال جاری
                foreach (RefService AddedService in _RefServices.Where(Data => Data.IsActive).ToList())
                    if (!CalculateServiceInsPrices(AddedService)) { if (ParentForm != null) ParentForm.Close(); return; }
                dgvRefServices.Refresh();
            }
            #region Calculate Ins1 & Ins2 Prices
            Int32 Ins1PriceTotal = 0;
            Int32 Ins1PartTotal = 0;

            for (Int32 i = 0; i < _RefServices.Count; i++)
            {
                if (!_RefServices[i].IsActive) continue;
                if (_RefServices[i].Ins1Price != null && _RefServices[i].Ins1Price != null && _RefServices[i].Ins1PartPrice != null)
                {
                    Ins1PriceTotal = Ins1PriceTotal + (_RefServices[i].Ins1Price.Value * _RefServices[i].Quantity);
                    Ins1PartTotal = Ins1PartTotal + (_RefServices[i].Ins1PartPrice.Value * _RefServices[i].Quantity);
                }
            }

            txtTotalIns1Price.Text = String.Format("{0:N0}", Ins1PriceTotal) + " ریال";
            txtTotalIns1Part.Text = String.Format("{0:N0}", Ins1PartTotal) + " ریال";
            txtTotalPatPartPrice.Text = String.Format("{0:N0}", (Ins1PriceTotal - Ins1PartTotal)) + " ریال";
            PanelTotalPrices.Invalidate();
            #endregion

            #region Calculate Remain Value

            #region Total Current Service Payable
            // مجموع پرداختنی خدمات مراجعه
            Int32 TotalRefServicesPayable = 0;
            foreach (RefService service in _RefServices)
                if (service.IsActive)
                    TotalRefServicesPayable = TotalRefServicesPayable + (service.PatientPayablePrice * service.Quantity);
            #endregion

            try
            {
                // مجموع پرداختنی مراجعه بیمار
                Int32 TotalRefPayable = TotalRefServicesPayable +
                    DBLayerIMS.Manager.DBML.FK_CalcSumCost(_CurrentRefData.ID).Value -
                    DBLayerIMS.Manager.DBML.FK_CalcSumDiscount(_CurrentRefData.ID).Value;
                Int32 TotalRefPayed = DBLayerIMS.Manager.DBML.FK_CalcSumTransactions(_CurrentRefData.ID).Value;
                // باقیمانده مراجعه
                if (TotalRefPayable - TotalRefPayed < 0)
                {
                    lblRecievable.Text = "قابل بازپرداخت:";
                    lblRecievableValue.ForeColor = Color.Red;
                }
                else
                {
                    lblRecievable.Text = "قابل دریافت:";
                    lblRecievableValue.ForeColor = Color.Blue;
                }
                lblRecievableValue.Text = String.Format("{0:N0}", Math.Abs(TotalRefPayable - TotalRefPayed)) + " ریال";
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان خواندن اطلاعات مالی مراجعه از بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Admission Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return;
            }
            #endregion
            #endregion
        }
        #endregion

        #region Int16? GetServiceDefaultPerformer(Int32 ServiceIX, Boolean IsExpert)
        /// <summary>
        /// تابعی برای بررسی وجود پزشك كارشناس پیش فرض
        /// </summary>
        /// <param name="ServiceIX">كد خدمت</param>
        /// <param name="IsExpert">آیا كارشناس است یا پزشك</param>
        /// <returns>كلید كارشناس یا پزشك پیش فرض یا تهی تهی برای عدم وجود</returns>
        private static Int16? GetServiceDefaultPerformer(Int32 ServiceIX, Boolean IsExpert)
        {
            Int32 CurrentDayKey = Convert.ToInt32(DateTime.Now.DayOfWeek);
            if (CurrentDayKey < 6) CurrentDayKey++;
            else CurrentDayKey -= 6;
            List<DefaultPerformers> DefaultPerformersResults =
                DBLayerIMS.Services.DefaultPerformersList.
                Where(Data => Data.ServiceIX == ServiceIX && Data.IsExpert == IsExpert &&
                    Data.Days.Substring(CurrentDayKey, 1) == "1").ToList();
            foreach (DefaultPerformers DefaultResult in DefaultPerformersResults)
            {
                DateTime SavedStartPeriod;
                DateTime SavedEndPeriod;
                // اگر بازه زمانی تعریف نشده باشد ، به معنی كل روز می باشد
                if (String.IsNullOrEmpty(DefaultResult.Period))
                {
                    // تاریخ آغاز به كمترین و تاریخ پایان به بیشترین تنظیم می شود
                    SavedStartPeriod = DateTime.MinValue;
                    SavedEndPeriod = DateTime.MaxValue;
                }
                // اگر بازه زمانی تعریف شده باشد
                else
                {
                    SavedStartPeriod = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                        Convert.ToInt32(DefaultResult.Period.Substring(0, 2)), Convert.ToInt32(DefaultResult.Period.Substring(2, 2)), 0);
                    SavedEndPeriod = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                        Convert.ToInt32(DefaultResult.Period.Substring(4, 2)), Convert.ToInt32(DefaultResult.Period.Substring(6, 2)), 0);
                }
                // اگر زمان حاضر در بازه تعریف شده پیش فرض جاری نباشد حلقه ادامه می یابد
                if (DateTime.Now < SavedStartPeriod || DateTime.Now >= SavedEndPeriod) continue;
                // اگر بازه زمانی جاری دقیقاً بازه حلقه جاری باشد مقدار انجام دهنده پیش فرض باز گردانده می شود
                return DefaultResult.PerformerIX;
            }
            return null;
        }
        #endregion

        #endregion

    }
}