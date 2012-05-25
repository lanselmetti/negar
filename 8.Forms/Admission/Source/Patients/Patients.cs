#region using

using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Forms.Account;
using Sepehr.Forms.Admission.Classes;
using Sepehr.Forms.Admission.Properties;
using Sepehr.Forms.Documents;

#endregion

namespace Sepehr.Forms.Admission.Patients
{
    /// <summary>
    /// فرم مدیریت بیماران
    /// </summary>
    internal partial class frmPatients : Form
    {

        #region Enums
        /// <summary>
        /// تعیین وضعیت فرم بیماران
        /// </summary>
        public enum PatientFormStates
        {
            /// <summary>
            /// حالت افزودن بیمار جدید
            /// </summary>
            Adding = 1,
            /// <summary>
            /// حالت نمایش یك بیمار
            /// </summary>
            Viewing = 2,
            /// <summary>
            /// حالت ویرایش یك بیمار
            /// </summary>
            Editing = 3
        };
        #endregion

        #region Fields & Properties

        #region ReferralFormStates _FormState
        /// <summary>
        /// وضعیت فرم بیماران در سه حالت افزودن , ویرایش و نمایش
        /// </summary>
        private PatientFormStates _FormState;
        #endregion

        #region PatList _CurrentPatientData
        /// <summary>
        /// فیلد اطلاعات بیمار جاری
        /// </summary>
        private PatList _CurrentPatientData;
        #endregion

        #region Int32? _CurrentSchAppointmentID
        /// <summary>
        /// كلید نوبتی كه پذیرش جاری از آن ارسال شده است
        /// </summary>
        private Int32? _CurrentSchAppointmentID;
        #endregion

        #region Boolean _IsCurrentPatModified
        /// <summary>
        /// تعیین ویرایش شدن بیمار توسط كاربر از حالت اولیه
        /// </summary>
        private Boolean _IsCurrentPatModified;
        #endregion

        #region Int32 CurrentPatientListID
        /// <summary>
        /// كلید بیمار جاری فرم
        /// </summary>
        private Int32 CurrentPatientListID
        {
            get { return _CurrentPatientData.ID; }
            set
            {
                // وقتی كلید بیمار جاری صفر وارد شود به معنی ورود یك بیمار جدید است
                if (value == 0) { FormState = PatientFormStates.Adding; }
                // اگر مقدار ارسالی غیر از صفر باشد ، اطلاعات بیمار دریافتی را بر روی فرم نمایش می دهد
                // اگر خطایی در نمایش رخ دهد ، فرم به حالت ثبت بیمار جدید تغییر حالت می دهد
                // در حالت غیر صفر ، كنترل وضعیت نمایش فرم به عهده این خصوصیت نیست
                else
                {
                    if (!FillPatientDataInControlsByID(value))
                    { _IsCurrentPatModified = false; Dispose(); Close(); return; }
                }
            }
        }
        #endregion

        #region PatientFormStates RefFormState
        /// <summary>
        /// وضعیت فرم جاری
        /// </summary>
        private PatientFormStates FormState
        {
            get { return _FormState; }
            set
            {
                if (value == PatientFormStates.Adding) { ChangeToAddingState(); }
                else if (value == PatientFormStates.Viewing) { ChangeToViewState(); }
                else if (value == PatientFormStates.Editing) { ChangeToEditState(); }
                _FormState = value;
            }
        }
        #endregion

        #region Setting Fields
        private Boolean _ShouldEnterGender;
        private Boolean _ShouldEnterBirthDay;
        private Int16? _AgeDetailsLimit;
        private Boolean _ShouldEnterMaritualStatus;
        private Boolean _ShouldEnterFatherName;
        private Boolean _ShouldEnterNationalCode;
        private Boolean _ShouldEnterNationalID;
        private Boolean _ShouldEnterBirthLocation;
        private Boolean _ShouldEnterJob;
        private Boolean _ShouldEnterTel1;
        private Boolean _ShouldEnterTel2;
        private Boolean _ShouldEnterLocation;
        private Boolean _ShouldEnterEmail;
        private Boolean _ShouldEnterZipCode;
        private Boolean _ShouldEnterAddress;
        private Boolean _ShouldSearchForSamePatient;
        private Boolean _ShouldSaveEnglishName;
        private Int16 _dgvDoubleClickIndex;
        #endregion

        #region Access Fields
        /// <summary>
        /// تعیین آنكه آیا قفل جاری قفل پیشرفته است یا نه
        /// </summary>
        private Boolean _HaveAdvancedLicense = true;
        /// <summary>
        /// تعیین امكان افزودن بیمار جدید
        /// </summary>
        private Boolean _CanAddPatient = true;
        /// <summary>
        /// تعیین امكان ویرایش بیمار توسط كاربر
        /// </summary>
        private Boolean _CanEditPatient = true;
        /// <summary>
        /// تعیین امكان ویرایش اطلاعات اضافی بیمار توسط كاربر جاری
        /// </summary>
        private Boolean _CanEditPatientAdditionData = true;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم جهت ثبت بیمار جدید
        /// </summary>
        public frmPatients()
        {
            Cursor.Current = Cursors.WaitCursor;
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("Fa-Ir"));
            InitializeComponent();
            if ((SecurityManager.CurrentUserID > 2 && !ReadCurrentUserPermissions()) ||
                !ReadCurrentUserSettings()) { Dispose(); return; }
            #region Fill Additional Columns Data
            // اگر كاربر مجوز مدیریت بیماران پیشرفته را نداشته باشد
            if (SecurityManager.CurrentUserID <= 2 || LicenseHelper.GetSavedLicenses().Contains("525"))
            {
                if (DBLayerIMS.Referrals.PatAddinColsList == null) { Dispose(); return; }
                if (DBLayerIMS.Referrals.PatAddinColsList.Count == 0) TabAddInData.Visible = false;
                // اضافه كردن كنترل های اطلاعات اضافی
                Int32 CtrlHeight = 3;
                for (Int32 i = 0; i < DBLayerIMS.Referrals.PatAddinColsList.Count; i++)
                {
                    #region Add String Columns
                    if (DBLayerIMS.Referrals.PatAddinColsList[i].TypeID == 0)
                    {
                        LabelX lblAdditionalTitle = new LabelX();
                        lblAdditionalTitle.Name = "lbl" + DBLayerIMS.Referrals.PatAddinColsList[i].FieldName;
                        lblAdditionalTitle.Tag = DBLayerIMS.Referrals.PatAddinColsList[i].ID;
                        lblAdditionalTitle.Text = DBLayerIMS.Referrals.PatAddinColsList[i].Title;
                        lblAdditionalTitle.Font = new Font("Tahoma", 8, FontStyle.Bold);
                        lblAdditionalTitle.BackColor = Color.Transparent;
                        lblAdditionalTitle.AutoSize = false;
                        lblAdditionalTitle.Size = new Size(TabPanelContactData.Width - 30, 21);
                        lblAdditionalTitle.Location = new Point(10, CtrlHeight);
                        lblAdditionalTitle.Margin = new System.Windows.Forms.Padding(10);
                        lblAdditionalTitle.Padding = new System.Windows.Forms.Padding(10);
                        TabPanelAddInData.Controls.Add(lblAdditionalTitle);
                        CtrlHeight = CtrlHeight + 24;
                        TextBox txtAdditionalData = new TextBox();
                        txtAdditionalData.Name = "txt" + DBLayerIMS.Referrals.PatAddinColsList[i].FieldName;
                        txtAdditionalData.BackColor = Color.White;
                        txtAdditionalData.Tag = DBLayerIMS.Referrals.PatAddinColsList[i].ID;
                        txtAdditionalData.AutoSize = false;
                        txtAdditionalData.MaxLength = 48;
                        txtAdditionalData.Size = new Size(TabPanelContactData.Width - 30, 21);
                        txtAdditionalData.Location = new Point(10, CtrlHeight);
                        txtAdditionalData.Margin = new System.Windows.Forms.Padding(10);
                        txtAdditionalData.Padding = new System.Windows.Forms.Padding(10);
                        txtAdditionalData.TextChanged += FormControls_ValuesChanged;
                        txtAdditionalData.Validating += TextBoxes_Validating;
                        TabPanelAddInData.Controls.Add(txtAdditionalData);
                        CtrlHeight = CtrlHeight + 24;
                    }
                    #endregion

                    #region Add Bool Columns
                    else if (DBLayerIMS.Referrals.PatAddinColsList[i].TypeID == 1)
                    {
                        CheckBoxX cBoxAdditionalTitle = new CheckBoxX();
                        cBoxAdditionalTitle.Name = "cBox" + DBLayerIMS.Referrals.PatAddinColsList[i].FieldName;
                        cBoxAdditionalTitle.Tag = DBLayerIMS.Referrals.PatAddinColsList[i].ID;
                        cBoxAdditionalTitle.Text = DBLayerIMS.Referrals.PatAddinColsList[i].Title;
                        cBoxAdditionalTitle.Font = new Font("Tahoma", 8, FontStyle.Bold);
                        cBoxAdditionalTitle.BackColor = Color.Transparent;
                        cBoxAdditionalTitle.AutoSize = false;
                        cBoxAdditionalTitle.Size = new Size(TabPanelContactData.Width - 30, 21);
                        cBoxAdditionalTitle.Location = new Point(10, CtrlHeight);
                        cBoxAdditionalTitle.Margin = new System.Windows.Forms.Padding(10);
                        cBoxAdditionalTitle.Padding = new System.Windows.Forms.Padding(10);
                        cBoxAdditionalTitle.CheckedChanged += FormControls_ValuesChanged;
                        TabPanelAddInData.Controls.Add(cBoxAdditionalTitle);
                        CtrlHeight = CtrlHeight + 24;
                    }
                    #endregion

                    #region Add Integer Columns
                    if (DBLayerIMS.Referrals.PatAddinColsList[i].TypeID == 2)
                    {
                        LabelX lblAdditionalTitle = new LabelX();
                        lblAdditionalTitle.Name = "lbl" + DBLayerIMS.Referrals.PatAddinColsList[i].FieldName;
                        lblAdditionalTitle.Tag = DBLayerIMS.Referrals.PatAddinColsList[i].ID;
                        lblAdditionalTitle.Text = DBLayerIMS.Referrals.PatAddinColsList[i].Title;
                        lblAdditionalTitle.Font = new Font("Tahoma", 8, FontStyle.Bold);
                        lblAdditionalTitle.BackColor = Color.Transparent;
                        lblAdditionalTitle.AutoSize = false;
                        lblAdditionalTitle.Size = new Size(TabPanelContactData.Width - 30, 21);
                        lblAdditionalTitle.Location = new Point(10, CtrlHeight);
                        lblAdditionalTitle.Margin = new System.Windows.Forms.Padding(10);
                        lblAdditionalTitle.Padding = new System.Windows.Forms.Padding(10);
                        TabPanelAddInData.Controls.Add(lblAdditionalTitle);
                        CtrlHeight = CtrlHeight + 24;
                        IntegerInput txtAdditionalData = new IntegerInput();
                        txtAdditionalData.Name = "txt" + DBLayerIMS.Referrals.PatAddinColsList[i].FieldName;
                        txtAdditionalData.BackColor = Color.White;
                        txtAdditionalData.Tag = DBLayerIMS.Referrals.PatAddinColsList[i].ID;
                        txtAdditionalData.AutoSize = false;
                        txtAdditionalData.MaxValue = 2147483647;
                        txtAdditionalData.ShowUpDown = true;
                        txtAdditionalData.InputHorizontalAlignment = eHorizontalAlignment.Center;
                        txtAdditionalData.Size = new Size(TabPanelContactData.Width - 30, 21);
                        txtAdditionalData.Location = new Point(10, CtrlHeight);
                        txtAdditionalData.Margin = new System.Windows.Forms.Padding(10);
                        txtAdditionalData.Padding = new System.Windows.Forms.Padding(10);
                        txtAdditionalData.TextChanged += FormControls_ValuesChanged;
                        txtAdditionalData.Validating += TextBoxes_Validating;
                        TabPanelAddInData.Controls.Add(txtAdditionalData);
                        CtrlHeight = CtrlHeight + 24;
                    }
                    #endregion

                    #region Add MultiChoice Columns
                    if (DBLayerIMS.Referrals.PatAddinColsList[i].TypeID == 3)
                    {
                        LabelX lblAdditionalTitle = new LabelX();
                        lblAdditionalTitle.Name = "lbl" + DBLayerIMS.Referrals.PatAddinColsList[i].FieldName;
                        lblAdditionalTitle.Tag = DBLayerIMS.Referrals.PatAddinColsList[i].ID;
                        lblAdditionalTitle.Text = DBLayerIMS.Referrals.PatAddinColsList[i].Title;
                        lblAdditionalTitle.Font = new Font("Tahoma", 8, FontStyle.Bold);
                        lblAdditionalTitle.BackColor = Color.Transparent;
                        lblAdditionalTitle.AutoSize = false;
                        lblAdditionalTitle.Size = new Size(TabPanelContactData.Width - 30, 21);
                        lblAdditionalTitle.Location = new Point(10, CtrlHeight);
                        lblAdditionalTitle.Margin = new System.Windows.Forms.Padding(10);
                        lblAdditionalTitle.Padding = new System.Windows.Forms.Padding(10);
                        TabPanelAddInData.Controls.Add(lblAdditionalTitle);
                        CtrlHeight = CtrlHeight + 24;
                        ComboBox cboAdditionalData = new ComboBox();
                        cboAdditionalData.Name = "cbo" + DBLayerIMS.Referrals.PatAddinColsList[i].FieldName;
                        cboAdditionalData.BackColor = Color.White;
                        cboAdditionalData.Tag = DBLayerIMS.Referrals.PatAddinColsList[i].ID;
                        cboAdditionalData.DropDownStyle = ComboBoxStyle.DropDownList;
                        cboAdditionalData.FlatStyle = FlatStyle.Standard;
                        cboAdditionalData.ValueMember = "ID";
                        cboAdditionalData.DisplayMember = "Title";
                        cboAdditionalData.DataSource = DBLayerIMS.Manager.DBML.
                            SP_SelectPatMultiSelectItems(DBLayerIMS.Referrals.PatAddinColsList[i].ID).ToList();
                        cboAdditionalData.AutoSize = false;
                        cboAdditionalData.Size = new Size(TabPanelContactData.Width - 30, 21);
                        cboAdditionalData.Location = new Point(10, CtrlHeight);
                        cboAdditionalData.Margin = new System.Windows.Forms.Padding(10);
                        cboAdditionalData.Padding = new System.Windows.Forms.Padding(10);
                        cboAdditionalData.TextChanged += FormControls_ValuesChanged;
                        cboAdditionalData.Validating += TextBoxes_Validating;
                        TabPanelAddInData.Controls.Add(cboAdditionalData);
                        CtrlHeight = CtrlHeight + 24;
                    }
                    #endregion
                }
            }
            #endregion

            #region Fill Bill Templates
            if (BillPrintManager.CurrentUserBillTemplatesList == null) { Dispose(); return; }
            if (BillPrintManager.CurrentUserBillTemplatesList.Count == 0 &&
                cmsdgvData.SubItems.Contains(btnPrint)) cmsdgvData.SubItems.Remove(btnPrint);
            else
            {
                cboPrintTemplates.ComboBoxEx.DrawMode = DrawMode.Normal;
                cboPrintTemplates.ComboBoxEx.FlatStyle = FlatStyle.Standard;
                cboPrintTemplates.ComboBoxEx.DisplayMember = "Name";
                cboPrintTemplates.ComboBoxEx.ValueMember = "ID";
                foreach (SP_SelectBillTemplateResult BillTemplate in BillPrintManager.CurrentUserBillTemplatesList)
                    cboPrintTemplates.ComboBoxEx.Items.Add(BillTemplate);
                cboPrintTemplates.ComboBoxEx.SelectedIndex = 0;
            }
            #endregion

            #region Set ColAdmitter DataSource
            ColAdmitter.DataSource = Negar.DBLayerPMS.Security.UsersList;
            ColAdmitter.DisplayMember = "FullName";
            ColAdmitter.ValueMember = "ID";
            ColAdmitter.DataPropertyName = "AdmitterIX";
            #endregion

            SetControlsEventHandlersAndProperties();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            Opacity = 1;
            RibbonBarNavigation.InvalidateLayout();
            Cursor.Current = Cursors.Default;
        }
        #endregion

        #region FormControls_PreviewKeyDown
        private void FormControls_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }
        #endregion

        #region @@@ Ribbon Controls Event Handlers @@@

        #region btnRefresh_Click
        /// <summary>
        /// دكمه ی به روز رسانی اطلاعات بیمار جاری در حالتی كه فرم در وضعیت نمایش است
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (FormState != PatientFormStates.Adding) CurrentPatientListID = _CurrentPatientData.ID;
        }
        #endregion

        #region btnFreePatient_Click
        /// <summary>
        /// دكمه ی آزاد سازی بیمار قفل شده
        /// </summary>
        private void btnFreePatient_Click(object sender, EventArgs e)
        {
            if (FormState != PatientFormStates.Viewing) return;
            DialogResult Result = PMBox.Show("آیا مایلید بیمار جاری را از حالت قفل خارج نمایید؟", "پرسش؟",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Result != DialogResult.Yes) return;
            Negar.DBLayerPMS.Patients.ChangePatLock(_CurrentPatientData.ID, false);
        }
        #endregion

        #region btnSchList_Click
        /// <summary>
        /// روالی برای نمایش نوبت های تخصیص یافته به بیمار
        /// </summary>
        private void btnSchList_Click(object sender, EventArgs e)
        {
            new frmPatientSchedules(CurrentPatientListID);
            Activate(); Select(); BringToFront(); Focus();
        }
        #endregion

        #region btnNextTab_Click
        /// <summary>
        /// روالی برای جابجایی بین تب های بیمار
        /// </summary>
        private void btnNextTab_Click(object sender, EventArgs e)
        {
            if (!TabCtrlPatientData.SelectNextTab()) TabCtrlPatientData.SelectedTabIndex = 0;
            if (TabCtrlPatientData.SelectedPanel.Controls.Count != 0) TabCtrlPatientData.SelectedPanel.Controls[0].Focus();
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

        #region FormControls_ValuesChanged
        /// <summary>
        /// دستگیره ی مدیریت ایجاد تغییرات در كنترل های اطلاعات بیمار
        /// </summary>
        void FormControls_ValuesChanged(object sender, EventArgs e)
        {
            // در صورتی كه یك مقدار در یك كنترل تغییر كند ، این متغیر تغییر می كند
            _IsCurrentPatModified = true;
        }
        #endregion

        #region TextBoxes_Validating
        private static void TextBoxes_Validating(object sender, CancelEventArgs e)
        {
            if (sender is TextBoxX) ((TextBoxX)sender).Text = ((TextBoxX)sender).Text.Trim();
            else if (sender is TextBox) ((TextBox)sender).Text = ((TextBox)sender).Text.Trim();
        }
        #endregion

        #region btnShownEnglishName_Click
        /// <summary>
        /// كلید مدیریت نام یا نام خانوادگی انگلیسی
        /// </summary>
        /// <remarks>
        /// در صورت ارسال نام جدید ، نام ثبت شده و در غیر اینصورت نام خانوادگی
        /// نام اصلی بیمار در تابع افزودن یا ویرایش بیمار مدیریت می شود
        /// </remarks>
        private void btnShownEnglishName_Click(object sender, EventArgs e)
        {
            if (((Control)sender).Name == "btnShowEnglishFirstName")
                new frmNamesTranslator(txtFirstName.Text.Trim(), true);
            else new frmNamesTranslator(txtLastName.Text.Trim(), false);
        }
        #endregion

        #region RadioButton_KeyPress
        private void RadioButton_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') ((RadioButton)sender).Checked = true;
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
                        cBoxEnterPatAge.Left = 35;
                    }
                    else
                    {
                        txtAgeMonth.Visible = false;
                        txtAgeDay.Visible = false;
                        cBoxEnterPatAge.Left = 100;
                    }
                }
                else cBoxEnterPatAge.Left = 100;
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
        /// <summary>
        /// این روال مدیریت نمایش كنترل مناسب برای ورود تاریخ تولد یا سن بیمار را بر عهده دارد
        /// </summary>
        private void cBoxEnterPatientAge_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxEnterPatAge.Checked)
            {
                lblBirthDate.Text = "سن:";
                DateInputBirthDate.Visible = false;
                txtAgeYear.Visible = true;
                if (_AgeDetailsLimit != null &&
                    _AgeDetailsLimit.Value >= txtAgeYear.Value && txtAgeYear.ValueObject != null)
                {
                    txtAgeMonth.Visible = true;
                    txtAgeDay.Visible = true;
                    cBoxEnterPatAge.Left = 35;
                }
                else
                {
                    txtAgeMonth.Visible = false;
                    txtAgeDay.Visible = false;
                    cBoxEnterPatAge.Left = 100;
                }
            }
            else
            {
                cBoxEnterPatAge.Left = 35;
                DateInputBirthDate.Visible = true;
                txtAgeYear.Visible = false;
                txtAgeMonth.Visible = false;
                txtAgeDay.Visible = false;
                lblBirthDate.Text = "تاریخ تولد:";
            }
        }
        #endregion

        #region cboCountry_SelectedIndexChanged
        /// <summary>
        /// دستگیره ی مدیریت تغییر یك كشور
        /// </summary>
        private void cboCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int16? SelectedCountry = null;
            if (cboCountry.SelectedIndex > 0) SelectedCountry = Convert.ToInt16(cboCountry.SelectedValue);

            #region No Country Is Selected
            if (SelectedCountry == null)
            {
                if (cboState.DataSource != null && cboState.Items.Count > 0)
                    cboState.SelectedIndex = 0;
                SetComboBoxReadOnly(cboState, true);
                return;
            }
            #endregion

            #region A Country Selected
            cboState.DataSource = Negar.DBLayerPMS.Patients.StatesList.
                Where(Data => (Data.CountryIX == SelectedCountry) || Data.CountryIX == -1).
                OrderBy(Data => Data.Name).ToList();
            SetComboBoxReadOnly(cboState, false);
            #endregion
        }
        #endregion

        #region cboState_SelectedIndexChanged
        private void cboState_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int16? SelectedState = null;
            if (cboState.SelectedIndex > 0) SelectedState = Convert.ToInt16(cboState.SelectedValue);

            #region No State Is Selected
            if (SelectedState == null)
            {
                if (cboCity.DataSource != null && cboCity.Items.Count > 0)
                    cboCity.SelectedIndex = 0;
                SetComboBoxReadOnly(cboCity, true);
                return;
            }
            #endregion

            #region A State Is Selected
            cboCity.DataSource = Negar.DBLayerPMS.Patients.CitiesList.
                Where(Data => Data.StateIX == SelectedState || Data.StateIX == -1).OrderBy(Data => Data.Name).ToList();
            SetComboBoxReadOnly(cboCity, false);
            #endregion
        }
        #endregion

        #region txtEmail_Enter
        private void txtEmail_Enter(object sender, EventArgs e)
        {
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("En-Us"));
        }
        #endregion

        #region txtEmail_Leave
        private void txtEmail_Leave(object sender, EventArgs e)
        {
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("Fa-Ir"));
        }
        #endregion

        #endregion

        #region @@@ Panel Ref Data @@@

        #region ExpReferrals_ExpandedChanged
        private void ExpReferrals_ExpandedChanged(object sender, ExpandedChangeEventArgs e)
        {
            if (ExpReferrals.Expanded) { Top = Top - 30; Height = 480; }
            else { Top = Top + 30; Height = 295; }
        }
        #endregion

        #region dgvData_CellFormatting
        private void dgvData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (e.ColumnIndex == ColRow.Index) e.Value = e.RowIndex + 1;
            else if (e.ColumnIndex == ColPaymentStatus.Index) // محاسبه باقیمانده مراجعه
            {
                Int32? RefRemainValue;
                try
                {
                    RefRemainValue = DBLayerIMS.Manager.DBML.
                        FK_CalcTotalRefRemain(((RefList)dgvData.Rows[e.RowIndex].DataBoundItem).ID);
                }
                #region Catch
                catch (Exception Ex)
                {
                    e.Value = "خطای محاسبه!";
                    LogManager.SaveLogEntry("Sepehr", "Admission Forms", Ex.Message + "\n" +
                        Ex.StackTrace, EventLogEntryType.Error); return;
                }
                #endregion
                if (RefRemainValue == null || RefRemainValue.Value == 0) e.Value = "تسویه شده";
                else if (RefRemainValue.Value < 0) e.Value =
                    "قابل بازپرداخت: " + String.Format("{0:N0}", Math.Abs(RefRemainValue.Value));
                else if (RefRemainValue.Value > 0) e.Value =
                    "قابل دریافت: " + String.Format("{0:N0}", Math.Abs(RefRemainValue.Value));
            }
            else if (e.ColumnIndex == ColRefDocsCount.Index) // محاسبه تعداد مدارك مراجعه
                try
                {
                    e.Value = DBLayerIMS.Manager.DBML.RefDocuments.
                        Where(Data => Data.RefIX == ((RefList)dgvData.Rows[e.RowIndex].DataBoundItem).ID).Count();
                }
                #region Catch
                catch (Exception Ex)
                {
                    LogManager.SaveLogEntry("Sepehr", "Admission Forms", Ex.Message + "\n" +
                        Ex.StackTrace, EventLogEntryType.Error); e.Value = "خطا!"; return;
                }
                #endregion
        }
        #endregion

        #region dgvData_CellMouseClick
        /// <summary>
        /// دستگیره مدیریت كلیك بر روی جدول مراجعات و نمایش مراجعه انتخاب شده
        /// </summary>
        private void dgvData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (sender.GetType().Equals(typeof(Int32)) && e.Button == MouseButtons.Right)
            {
                dgvData.Rows[e.RowIndex].Selected = true;
                cmsdgvData.PopupMenu(e.Location);
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (!dgvData.Rows[e.RowIndex].Selected) dgvData.Rows[e.RowIndex].Selected = true;
                cmsdgvData.Popup(MousePosition);
            }
        }
        #endregion

        #region  dgvData_CellMouseDoubleClick
        private void dgvData_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || e.ColumnIndex < 0 || e.RowIndex < 0) return;
            switch (_dgvDoubleClickIndex)
            {
                case 0:
                    {
                        if (cmsdgvData.SubItems.Contains(btnShowAdmit))
                            btnShowAdmit_Click(null, null);
                        break;
                    }
                case 1:
                    {
                        if (cmsdgvData.SubItems.Contains(btnShowAccount))
                            btnShowAccount_Click(null, null);
                        break;
                    }
                case 2:
                    {
                        if (cmsdgvData.SubItems.Contains(btnShowDocuments))
                            btnShowDocuments_Click(null, null);
                        break;
                    }
            }
        }
        #endregion

        #region dgvData_PreviewKeyDown
        private void dgvData_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData != Keys.Apps || dgvData.SelectedCells.Count == 0) return;
            dgvData_CellMouseClick(1, new DataGridViewCellMouseEventArgs(0,
                dgvData.SelectedRows[0].Index, Left + Width - 150,
                // Top:
                Top + ExpReferrals.Top + dgvData.Top + dgvData.ColumnHeadersHeight +
                dgvData.GetRowDisplayRectangle(dgvData.SelectedCells[0].RowIndex, true).Top + 12,
                new MouseEventArgs(MouseButtons.Right, 1, 1, 1, 1)));
        }
        #endregion

        #endregion

        #region @@@ Context Menu Strip Event Handlers @@@

        #region btnShowAdmit_Click
        /// <summary>
        /// دستگیره نمایش فرم مراجعه برای مراجعه انتخاب شده بیمار
        /// </summary>
        private void btnShowAdmit_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 0 || !ManageAdmit()) return;
            AdmitHelper.EditPatientRef(((RefList)dgvData.SelectedRows[0].DataBoundItem).ID);
            CurrentPatientListID = CurrentPatientListID;
            BringToFront();
            Focus();
        }
        #endregion

        #region btnShowAccount_Click
        /// <summary>
        /// دكمه ی نمایش حساب مراجعه انتخاب شده
        /// </summary>
        private void btnShowAccount_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 0 || !ManageAdmit()) return;
            new frmAccount(((RefList)dgvData.SelectedRows[0].DataBoundItem).ID, false);
            CurrentPatientListID = _CurrentPatientData.ID;
            BringToFront();
            Focus();
        }
        #endregion

        #region btnShowDocuments_Click
        /// <summary>
        /// دكمه ی نمایش ااسناد مراجعه انتخاب شده
        /// </summary>
        private void btnShowDocuments_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 0 || !ManageAdmit()) return;
            new frmDocuments(((RefList)dgvData.SelectedRows[0].DataBoundItem).ID, false);
            CurrentPatientListID = _CurrentPatientData.ID;
            BringToFront();
            Focus();
        }
        #endregion

        #region btnRemoveRef_Click
        /// <summary>
        /// دكمه ی حذف مراجعه انتخاب شده
        /// </summary>
        private void btnRemoveRef_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 0 || !ManageAdmit()) return;
            #region Ask User Permission
            DialogResult Dr1 = PMBox.Show("آیا مایلید اطلاعات مراجعه بیمار حذف شود؟", " هشدار",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Dr1 == DialogResult.Yes)
            {
                DialogResult Dr2 = PMBox.Show("آیا مطمئن هستید كه اطلاعات مراجعه بیمار حذف شود؟" +
                    " پس از حذف اطلاعات مراجعه بیمار كلیه اطلاعات مالی ، اطلاعات بیمه " +
                    "و همچنین اسناد بیمار برای آن پرونده حذف می گردد و امكان بازگشت آن وجود ندارد.", "هشدار!",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (Dr2 == DialogResult.No) return;
            }
            else if (Dr1 == DialogResult.No) return;
            #endregion
            DBLayerIMS.Referrals.DeletePatRef(((RefList)dgvData.SelectedRows[0].DataBoundItem).ID);
            if (!FillRefListDataGridView(CurrentPatientListID)) Close();
        }
        #endregion

        #region sliderPrintCount_ValueChanged
        private void sliderPrintCount_ValueChanged(object sender, EventArgs e)
        {
            sliderPrintCount.Text = "تعداد چاپ: " + sliderPrintCount.Value + " نسخه";
        }
        #endregion

        #region btnPrintPreview_Click
        /// <summary>
        /// دكمه ی پیش نمایش قبض مراجعه ی انتخاب شده
        /// </summary>
        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 0 || !ManageAdmit()) return;
            BillPrintManager.RefBillPrintPreview(((RefList)dgvData.SelectedRows[0].DataBoundItem).ID,
                ((SP_SelectBillTemplateResult)cboPrintTemplates.ComboBoxEx.SelectedItem).ID);
        }
        #endregion

        #region btnPrintTemplate_Click
        /// <summary>
        /// دكمه ی چاپ قبض انتخاب شده برای مراجعه ی انتخاب شده
        /// </summary>
        private void btnPrintTemplate_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 0 || !ManageAdmit()) return;
            BillPrintManager.RefBillPrint(((RefList)dgvData.SelectedRows[0].DataBoundItem).ID,
                ((SP_SelectBillTemplateResult)cboPrintTemplates.ComboBoxEx.SelectedItem).ID, Convert.ToInt16(sliderPrintCount.Value));
        }
        #endregion

        #endregion

        #region Form Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            if (FormState != PatientFormStates.Viewing && _IsCurrentPatModified)
            {
                DialogResult Dr = PMBox.Show("آیا مایلید بدون ذخیره سازی از فرم پرونده بیمار خارج شوید؟",
                    "هشدار!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (Dr == System.Windows.Forms.DialogResult.No) { e.Cancel = true; return; }
            }
            Opacity = 0.01;
            if (FormState == PatientFormStates.Editing)
                Negar.DBLayerPMS.Patients.ChangePatLock(CurrentPatientListID, false);
            _CurrentSchAppointmentID = null;
            Cursor.Current = Cursors.Default;
        }
        #endregion

        #endregion

        #region Methods

        #region internal void PrepareControlSettings(Boolean IsSingleEdit)
        /// <summary>
        /// تابعی برای آماده سازی كنترل برای نمایش در فرم های مورد نظر
        /// </summary>
        /// <param name="IsSingleEdit">تعیین آنكه فرم در حالت ویرایش یك بیمار نمایش داده شود یا مدیریت بیماران مختلف</param>
        /// <returns>صحت آماده سازی</returns>
        internal void PrepareControlSettings(Boolean IsSingleEdit)
        {
            if (IsSingleEdit)
            {
                // در این حالت اجازه جابجایی بیمار ، ثبت بیمار جدید ، ثبت مراجعه جدید و مدیریت مراجعات بیمار محدود می شود
                if (!btnNewPatient.IsDisposed && RibbonBarNavigation.Items.Contains(btnNewPatient))
                    RibbonBarNavigation.Items.Remove(btnNewPatient);
                if (!btnNewReferral.IsDisposed && RibbonBarNavigation.Items.Contains(btnNewReferral))
                    RibbonBarNavigation.Items.Remove(btnNewReferral);
                if (RibbonBarNavigation.Items.Contains(btnPrevPatient))
                    RibbonBarNavigation.Items.Remove(btnPrevPatient);
                if (RibbonBarNavigation.Items.Contains(btnNextPatient))
                    RibbonBarNavigation.Items.Remove(btnNextPatient);
                btnEditMode.ShowSubItems = false;
                txtPatientID.TextBox.ReadOnly = true;
                Height = 270;
                ExpReferrals.Visible = false;
            }
            else
            {
                if (!btnNewPatient.IsDisposed && !RibbonBarNavigation.Items.Contains(btnNewPatient))
                    RibbonBarNavigation.Items.Add(btnNewPatient);
                if (!btnNewReferral.IsDisposed && !RibbonBarNavigation.Items.Contains(btnNewReferral))
                    RibbonBarNavigation.Items.Add(btnNewReferral);
                if (!RibbonBarNavigation.Items.Contains(btnPrevPatient))
                    RibbonBarNavigation.Items.Add(btnPrevPatient);
                if (!RibbonBarNavigation.Items.Contains(btnNextPatient))
                    RibbonBarNavigation.Items.Add(btnNextPatient);
                btnEditMode.ShowSubItems = true;
                txtPatientID.TextBox.ReadOnly = false;
                Height = 480;
                ExpReferrals.Visible = true;
            }
        }
        #endregion

        #region @@@ Security Methods @@@

        #region Boolean ReadCurrentUserPermissions()
        /// <summary>
        /// تابع بررسی سطوح دسترسی فرم
        /// </summary>
        /// <returns>صحت خواندن اطلاعات</returns>
        private Boolean ReadCurrentUserPermissions()
        {
            if (LicenseHelper.GetSavedLicenses() == null)
            {
                const String ErrorMessage = "امكان خواندن مجوزهای نصب شده روی قفل سخت افزاری ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            #region # Manage Lock License
            // اگر كاربر مجوز مدیریت بیماران پیشرفته را نداشته باشد
            if (!LicenseHelper.GetSavedLicenses().Contains("525"))
            {
                _HaveAdvancedLicense = false;
                btnShowEnglishFirstName.Visible = false;
                btnShowEnglishLastName.Visible = false;
                TabAddInData.Visible = false;
                if (btnEditMode.SubItems.Contains(btnFreePatient))
                    btnEditMode.SubItems.Remove(btnFreePatient);
                if (RibbonBarNavigation.Items.Contains(btnSchList))
                    RibbonBarNavigation.Items.Remove(btnSchList);
            }
            // اگر كاربر مجوز مدیریت نوبت دهی پیشرفته را نداشته باشد
            if (!LicenseHelper.GetSavedLicenses().Contains("515"))
            {
                if (RibbonBarNavigation.Items.Contains(btnSchList))
                    RibbonBarNavigation.Items.Remove(btnSchList);
            }
            // اگر كاربر مجوز مدیریت حساب را نداشته باشد
            if (!LicenseHelper.GetSavedLicenses().Contains("530"))
            {
                if (cmsdgvData.SubItems.Contains(btnShowAccount))
                    cmsdgvData.SubItems.Remove(btnShowAccount);
            }
            // اگر كاربر مجوز مدیریت مدارك را نداشته باشد
            if (!LicenseHelper.GetSavedLicenses().Contains("550"))
            {
                if (cmsdgvData.SubItems.Contains(btnShowDocuments))
                    cmsdgvData.SubItems.Remove(btnShowDocuments);
            }
            #endregion

            #region Schedules - 502
            // مدیریت نوبت دهی
            if (SecurityManager.GetCurrentUserPermission(502) == false)
            {
                if (RibbonBarNavigation.Items.Contains(btnSchList))
                    RibbonBarNavigation.Items.Remove(btnSchList);
            }
            #endregion

            #region Patient File - 503
            // مدیریت بیماران 
            if (SecurityManager.GetCurrentUserPermission(503) == false)
            {
                PMBox.Show("كاربر جاری دسترسی به مدیریت پرونده بیماران سیستم ندارد!", "خطا! محدودیت دسترسی!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
            }
            #region 503 Child Permissions

            #region Add New Patient - 5031
            // افزودن بیمار جدید
            if (SecurityManager.GetCurrentUserPermission(561005) == false)
            {
                _CanAddPatient = false;
                if (RibbonBarNavigation.Items.Contains(btnNewPatient))
                    RibbonBarNavigation.Items.Remove(btnNewPatient);
                btnNewPatient.Dispose();
            }
            #endregion

            #region Edit Patient Base Data - 5032
            // ویرایش اطلاعات پایه پرونده بیمار
            if (SecurityManager.GetCurrentUserPermission(5032) == false) _CanEditPatient = false;
            #endregion

            #region View Patient Addin Fields - 5033
            // نمایش اطلاعات پویا بیماران
            if (SecurityManager.GetCurrentUserPermission(5033) == false)
            {
                TabAddInData.Dispose();
                TabPanelAddInData.Dispose();
            }
            else
            {
                // ویرایش اطلاعات پویا بیماران
                if (SecurityManager.GetCurrentUserPermission(50331) == false)
                    _CanEditPatientAdditionData = false;
            }
            #endregion

            #region Free Locked Patients - 5034
            // امكان آزاد سازی بیمار قفل شده
            if (SecurityManager.GetCurrentUserPermission(5034) == false)
            {
                if (btnEditMode.SubItems.Contains(btnFreePatient))
                    btnEditMode.SubItems.Remove(btnFreePatient);
            }
            #endregion

            #region Delete Patient - 5035
            // حذف بیمار
            if (SecurityManager.GetCurrentUserPermission(5035) == false)
            {
                if (btnEditMode.SubItems.Contains(btnDeletePatient))
                    btnEditMode.SubItems.Remove(btnDeletePatient);
            }
            #endregion

            #endregion
            #endregion

            #region Patient Ref - 504
            // مدیریت مراجعات بیماران
            if (SecurityManager.GetCurrentUserPermission(504) == false)
            {
                if (RibbonBarNavigation.Items.Contains(btnNewReferral))
                    RibbonBarNavigation.Items.Remove(btnNewReferral);
                btnNewReferral.Dispose();
                btnShowAdmit.Shortcuts.Clear();
                if (cmsdgvData.SubItems.Contains(btnShowAdmit))
                    cmsdgvData.SubItems.Remove(btnShowAdmit);
            }
            #region Patient Ref Child Permissions
            else
            {
                // دسترسی امكان افزودن مراجعه جدید برای بیمار
                if (SecurityManager.GetCurrentUserPermission(5041) == false)
                {
                    if (RibbonBarNavigation.Items.Contains(btnNewReferral))
                        RibbonBarNavigation.Items.Remove(btnNewReferral);
                    btnNewReferral.Dispose();
                }
                //  حذف مراجعه بیمار
                if (SecurityManager.GetCurrentUserPermission(5044) == false)
                    if (cmsdgvData.SubItems.Contains(btnRemoveRef))
                        cmsdgvData.SubItems.Remove(btnRemoveRef);
            }
            #endregion
            #endregion

            #region Ref Account - 505
            // مدیریت حساب مراجعات
            if (SecurityManager.GetCurrentUserPermission(505) == false)
            {
                btnShowAccount.Shortcuts.Clear();
                if (cmsdgvData.SubItems.Contains(btnShowAccount))
                    cmsdgvData.SubItems.Remove(btnShowAccount);
            }
            #endregion

            #region Ref Document - 506
            // مدیریت مدارك مراجعات
            if (SecurityManager.GetCurrentUserPermission(506) == false)
            {
                btnShowDocuments.Shortcuts.Clear();
                if (cmsdgvData.SubItems.Contains(btnShowDocuments))
                    cmsdgvData.SubItems.Remove(btnShowDocuments);
            }
            #endregion
            return true;
        }
        #endregion

        #region Boolean ReadCurrentUserSettings()
        /// <summary>
        /// تابع اعمال تنظیمات فرم
        /// </summary>
        private Boolean ReadCurrentUserSettings()
        {
            if (DBLayerIMS.Settings.CurrentUserSettingsFullList == null) return false;
            // فیلد تعیین آشكار بودن سن بیمار برای كاربر جاری
            // در صورتی كه سن بیمار آشكار نباشد ، تنظیم 303 بدون استفاده خواهد بود
            Boolean IsAgeVisible = true;
            #region 301 - Base Fields
            // وضعیت نمایش و اجباری بودن فیلدها در فرم مدیریت بیماران
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
                    if (Setting301.First().Value.Substring(3, 1) == "1") _ShouldEnterBirthDay = true;
                    else _ShouldEnterBirthDay = false;
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

                #region Maritual Status
                if (Setting301.First().Value.Substring(4, 1) == "1")
                {
                    if (Setting301.First().Value.Substring(5, 1) == "1")
                        _ShouldEnterMaritualStatus = true;
                }
                else
                {
                    lblMaritualStatus.Visible = false;
                    PanelMaritualStatus.Visible = false;
                }
                #endregion

                #region FatherName
                if (Setting301.First().Value.Substring(6, 1) == "1")
                {
                    if (Setting301.First().Value.Substring(7, 1) == "1")
                        _ShouldEnterFatherName = true;
                }
                else
                {
                    lblFatherName.Visible = false;
                    txtFatherName.Visible = false;
                }
                #endregion

                #region NationalCode
                if (Setting301.First().Value.Substring(8, 1) == "1")
                {
                    if (Setting301.First().Value.Substring(9, 1) == "1")
                        _ShouldEnterNationalCode = true;
                }
                else
                {
                    lblNationalCode.Visible = false;
                    txtNationalCode.Visible = false;
                }
                #endregion

                #region NationalID
                if (Setting301.First().Value.Substring(10, 1) == "1")
                {
                    if (Setting301.First().Value.Substring(11, 1) == "1")
                        _ShouldEnterNationalID = true;
                }
                else
                {
                    lblNationalID.Visible = false;
                    txtNationalID.Visible = false;
                }
                #endregion

                #region BirthLocation
                if (Setting301.First().Value.Substring(12, 1) == "1")
                {
                    if (Setting301.First().Value.Substring(13, 1) == "1")
                        _ShouldEnterBirthLocation = true;
                }
                else
                {
                    lblBirthLocation.Visible = false;
                    txtBirthLocation.Visible = false;
                }

                #endregion

                #region Job
                if (Setting301.First().Value.Substring(14, 1) == "1")
                {
                    if (Setting301.First().Value.Substring(15, 1) == "1")
                        _ShouldEnterJob = true;
                }
                else
                {
                    lblOccupation.Visible = false;
                    cboJob.Visible = false;
                }
                #endregion

                #region Tel Numbers
                if (Setting301.First().Value.Substring(16, 1) == "1")
                {
                    if (Setting301.First().Value.Substring(17, 1) == "1")
                        _ShouldEnterTel1 = true;
                }
                else
                {
                    lblTel1.Visible = false;
                    txtTel1.Visible = false;
                }
                if (Setting301.First().Value.Substring(18, 1) == "1")
                {
                    if (Setting301.First().Value.Substring(19, 1) == "1")
                        _ShouldEnterTel2 = true;
                }
                else
                {
                    lblTel2.Visible = false;
                    txtTel2.Visible = false;
                }
                #endregion

                #region Location
                if (Setting301.First().Value.Substring(20, 1) == "1")
                {
                    if (Setting301.First().Value.Substring(21, 1) == "1")
                        _ShouldEnterLocation = true;
                }
                else
                {
                    lblCountry.Hide();
                    cboCountry.Visible = false;
                    lblState.Hide();
                    cboState.Visible = false;
                    lblCity.Hide();
                    cboCity.Visible = false;
                }
                #endregion

                #region Email
                if (Setting301.First().Value.Substring(22, 1) == "1")
                {
                    if (Setting301.First().Value.Substring(23, 1) == "1")
                        _ShouldEnterEmail = true;
                }
                else
                {
                    lblEmail.Visible = false;
                    txtEmail.Visible = false;
                }
                #endregion

                #region ZipCode
                if (Setting301.First().Value.Substring(24, 1) == "1")
                {
                    if (Setting301.First().Value.Substring(25, 1) == "1")
                        _ShouldEnterZipCode = true;
                }
                else
                {
                    lblZipCode.Visible = false;
                    txtZipCode.Visible = false;
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

                if (Setting301.First().Value.Substring(16, 1) == "0" && Setting301.First().Value.Substring(18, 1) == "0" &&
                    Setting301.First().Value.Substring(20, 1) == "0" && Setting301.First().Value.Substring(22, 1) == "0" &&
                    Setting301.First().Value.Substring(24, 1) == "0" && Setting301.First().Value.Substring(26, 1) == "0")
                    TabContactData.Visible = false;
            }
            else
            {
                _ShouldEnterBirthDay = false;

                #region MaritualStatus
                lblMaritualStatus.Visible = false;
                PanelMaritualStatus.Visible = false;
                #endregion

                #region FatherName
                lblFatherName.Visible = false;
                txtFatherName.Visible = false;
                #endregion

                #region NationalCode
                lblNationalCode.Visible = false;
                txtNationalCode.Visible = false;
                #endregion

                #region NationalID
                lblNationalID.Visible = false;
                txtNationalID.Visible = false;
                #endregion

                #region BirthLocation
                lblBirthLocation.Visible = false;
                txtBirthLocation.Visible = false;
                #endregion

                #region Job
                lblOccupation.Visible = false;
                cboJob.Visible = false;
                #endregion

                #region Location
                lblCountry.Hide();
                cboCountry.Visible = false;
                lblState.Hide();
                cboState.Visible = false;
                lblCity.Hide();
                cboCity.Visible = false;
                #endregion

                #region Email
                lblEmail.Visible = false;
                txtEmail.Visible = false;
                #endregion

                #region ZipCode
                lblZipCode.Visible = false;
                txtZipCode.Visible = false;
                #endregion

                #region Address
                lblAddress.Visible = false;
                txtAddress.Visible = false;
                #endregion
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
            if (Setting304.ToList().Count > 0 && Setting304.First().Boolean != null && Setting304.First().Boolean.Value)
                _ShouldSearchForSamePatient = true;
            else _ShouldSearchForSamePatient = false;
            #endregion

            #region 305
            // ثبت معادل انگلیسی اسامی پرونده بیمار در صورت عدم تشخیص سیستم
            List<UsersSetting> Setting305 =
                    DBLayerIMS.Settings.CurrentUserSettingsFullList.Where(Data => Data.SettingIX == 305).ToList();
            if (Setting305.Count > 0 && Setting305.First().Boolean != null && Setting305.First().Boolean.Value)
                _ShouldSaveEnglishName = true;
            else _ShouldSaveEnglishName = false;
            #endregion

            #region 306
            // عملیات پس از دوبار كلیك بر روی یك مراجعه
            List<UsersSetting> Setting306 =
                    DBLayerIMS.Settings.CurrentUserSettingsFullList.Where(Data => Data.SettingIX == 306).ToList();
            if (Setting306.Count > 0) _dgvDoubleClickIndex = Convert.ToInt16(Setting306.First().Value);
            #endregion
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
            TooltipText = ToolTipManager.GetText("btnPatFormNewPatient", "IMS");
            FormToolTip.SetSuperTooltip(btnNewPatient, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnNewReferral
            TooltipText = ToolTipManager.GetText("btnPatFormNewRef", "IMS");
            FormToolTip.SetSuperTooltip(btnNewReferral, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
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
            TooltipText = ToolTipManager.GetText("btnPatEditPatient", "IMS");
            FormToolTip.SetSuperTooltip(btnEditMode, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnDeletePatient
            TooltipText = ToolTipManager.GetText("btnPatDeletePatient", "IMS");
            FormToolTip.SetSuperTooltip(btnDeletePatient, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnPatFreePat
            TooltipText = ToolTipManager.GetText("btnPatFreePat", "IMS");
            FormToolTip.SetSuperTooltip(btnFreePatient, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

        }
        #endregion

        #region void SetControlsEventHandlersAndProperties()
        /// <summary>
        /// تابعی برای تنظیم رخدادها و خصوصیات كنترل های فرم
        /// </summary>
        private void SetControlsEventHandlersAndProperties()
        {
            dgvData.AutoGenerateColumns = false;
            RibbonBarNavigation.BackgroundHoverEnabled = false;
            txtPatientID.TextBox.Font = new Font("B Zar", 12, FontStyle.Bold);
            txtPatientID.TextBox.RightToLeft = RightToLeft.No;
            txtPatientID.TextBox.TextAlign = HorizontalAlignment.Center;
            cmsPatients.Location = new Point(cmsPatients.Left + 1000, cmsPatients.Top);

            #region TabPanelBasicData
            foreach (Control ctrl in TabPanelBasicData.Controls)
            {
                // TextBoxes:
                if (ctrl is TextBoxX)
                {
                    ctrl.TextChanged += (FormControls_ValuesChanged);
                    ctrl.Validating += (TextBoxes_Validating);
                }
                // IntegerInput:
                else if (ctrl is IntegerInput)
                    ((IntegerInput)ctrl).ValueChanged += (FormControls_ValuesChanged);
                // DateTimeInput:
                else if (ctrl is PersianDatePicker)
                    ((PersianDatePicker)ctrl).SelectedDateTimeChanged += (FormControls_ValuesChanged);
                // ComboBoxes:
                else if (ctrl is ComboBox) ((ComboBox)ctrl).SelectedValueChanged += (FormControls_ValuesChanged);
                else if (ctrl is Panel)
                    foreach (Control control in ctrl.Controls)
                        // RadioButton:
                        if (control is RadioButton)
                        {
                            ((RadioButton)control).CheckedChanged += FormControls_ValuesChanged;
                            control.PreviewKeyDown += FormControls_PreviewKeyDown;
                        }
                if (!(ctrl is LabelX) && !(ctrl is Label)) ctrl.PreviewKeyDown += FormControls_PreviewKeyDown;
            }
            #endregion

            #region TabPanelContactData
            foreach (Control ctrl in TabPanelContactData.Controls)
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
                else if (ctrl is ComboBox)
                    ((ComboBox)ctrl).SelectedValueChanged +=
                        (FormControls_ValuesChanged);
                else if (ctrl is GroupPanel)
                    foreach (Control control in ctrl.Controls)
                        // CheckBoxes:
                        if (control is CheckBoxX)
                            ((CheckBoxX)control).CheckedChanged += (FormControls_ValuesChanged);
                if (!(ctrl is LabelX) && !(ctrl is Label)) ctrl.PreviewKeyDown += FormControls_PreviewKeyDown;
            }
            #endregion

            #region TabPanelAddInData
            foreach (Control ctrl in TabPanelAddInData.Controls)
            {
                // TextBoxes:
                if (ctrl is TextBoxX)
                {
                    ctrl.TextChanged += FormControls_ValuesChanged;
                    ctrl.Validating += TextBoxes_Validating;
                }
                else if (ctrl is CheckBoxX)
                    ((CheckBoxX)ctrl).CheckedChanged += FormControls_ValuesChanged;
                if (ctrl is IntegerInput)
                {
                    ctrl.TextChanged += FormControls_ValuesChanged;
                    ctrl.Validating += TextBoxes_Validating;
                    ((IntegerInput)ctrl).ValueChanged += FormControls_ValuesChanged;
                    ((IntegerInput)ctrl).ValueObjectChanged += FormControls_ValuesChanged;
                }
                else if (ctrl is ComboBox)
                    ((ComboBox)ctrl).SelectedIndexChanged += FormControls_ValuesChanged;
                if (!(ctrl is LabelX) && !(ctrl is Label)) ctrl.PreviewKeyDown += FormControls_PreviewKeyDown;
            }
            #endregion

            txtPatientID.TextBox.PreviewKeyDown += FormControls_PreviewKeyDown;
            dgvData.PreviewKeyDown += FormControls_PreviewKeyDown;
        }
        #endregion

        #endregion

    }
}