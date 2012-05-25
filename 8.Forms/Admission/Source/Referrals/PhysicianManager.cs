#region using

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Negar;
using Negar.DBLayerPMS.DataLayer;
using DevComponents.DotNetBar.Controls;

#endregion

namespace Sepehr.Forms.Admission.Referrals
{
    /// <summary>
    /// فرم ثبت یا ویرایش پزشك ارجاع دهنده
    /// </summary>
    internal partial class frmPhysicianManager : Form
    {

        #region Fields & Properties

        #region Boolean _IsFormControlsModified
        /// <summary>
        /// تعیین ویرایش شدن مراجعه جاری توسط كاربر از حالت اولیه
        /// </summary>
        private Boolean _IsFormControlsModified;
        #endregion

        #region public Int16 ID
        /// <summary>
        /// كلید ردیف جاری
        /// </summary>
        public Int16 ID { get; set; }
        #endregion

        #region RefPhysician _CurrentRefPhysician
        /// <summary>
        /// فیلد اطلاعاتی پزشك جاری
        /// </summary>
        private RefPhysician _CurrentRefPhysician;
        #endregion

        #region readonly Boolean _IsAdding
        private readonly Boolean _IsAdding;
        #endregion

        #endregion

        #region Ctors

        #region frmPhysicianManager(String SentData)
        /// <summary>
        /// سازنده فرم برای ثبت پزشك جدید
        /// </summary>
        /// <param name="SentData">نظام پزشكی وارد شده در فرم پذیرش مراجعه</param>
        public frmPhysicianManager(String SentData)
        {
            InitializeComponent();
            _IsAdding = true;
            if (String.IsNullOrEmpty(SentData.Trim()))
            {
                txtMedicalID.Focus();
                txtMedicalID.SelectionLength = 0;
            }
            else if (Char.IsLetter(SentData, 0))
            {
                txtLastName.TabIndex = 0;
                txtMedicalID.TabIndex = 1;
                txtLastName.Text = SentData;
                txtLastName.Focus();
                txtLastName.SelectionStart = SentData.Length;
                txtLastName.SelectionLength = 0;
            }
            else if (Char.IsDigit(SentData, 0))
            {
                txtMedicalID.Text = SentData;
                txtMedicalID.SelectionStart = txtMedicalID.Text.Length;
                txtMedicalID.SelectionLength = 0;
            }
            if (!FillSpecialty()) { Close(); return; }
            ShowDialog();
        }
        #endregion

        #region frmPhysicianManager(Int16 RecievedID)
        /// <summary>
        /// سازنده ای كه برای حالت ویرایش است  
        /// </summary>
        /// <param name="RefPhysID"> كد پزشك</param>
        public frmPhysicianManager(Int16 RefPhysID)
        {
            InitializeComponent();
            _IsAdding = false;
            ID = RefPhysID;
            if (!FillPhysicianData(RefPhysID)) { Close(); return; }
            ShowDialog();
        }
        #endregion

        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            SetFormControlsChangeEventHandlers();
            _IsFormControlsModified = false;
        }
        #endregion

        #region FormControls_ValuesChanged
        /// <summary>
        /// دستگیره ی مدیریت ایجاد تغییرات در كنترل های اطلاعات بیمار
        /// </summary>
        void FormControls_ValuesChanged(object sender, EventArgs e)
        {
            // در صورتی كه یك مقدار در یك كنترل تغییر كند ، این متغیر تغییر می كند
            _IsFormControlsModified = true;
        }
        #endregion

        #region Controls_PreviewKeyDown
        private void Controls_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Down) SelectNextControl(((Control)sender), true, true, true, true);
            else if (e.KeyCode == Keys.Up) SelectNextControl(((Control)sender), false, true, true, true);
        }
        #endregion

        #region txtNames_Leave
        private void txtNames_Leave(object sender, EventArgs e)
        {
            if (!LicenseHelper.GetSavedLicenses().Contains("525")) return;
            String EnglishName;
            if (sender.Equals(txtLastName))
            {
                EnglishName = Negar.DBLayerPMS.Patients.GetEnglishName(txtLastName.Text, false);
                if (!String.IsNullOrEmpty(EnglishName)) txtLastNameEn.Text = EnglishName;

            }
            else
            {
                EnglishName = Negar.DBLayerPMS.Patients.GetEnglishName(txtFirstName.Text, true);
                if (!String.IsNullOrEmpty(EnglishName)) txtFirstNameEn.Text = EnglishName;
            }
        }
        #endregion

        #region txtFa_Enter
        private void txtFa_Enter(object sender, EventArgs e)
        {
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("Fa-Ir"));
        }
        #endregion

        #region EngTextBox_Enter
        private void EngTextBox_Enter(object sender, EventArgs e)
        {
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("En-Us"));
        }
        #endregion

        #region btnSave_Click
        private void btnSave_Click(object sender, EventArgs e)
        {
            #region Validation
            if (String.IsNullOrEmpty(txtLastName.Text.Trim()))
            {
                PMBox.Show("وارد كردن نام خانوادگی اجباری می باشد!\nلطفاً مجدداً بررسی نمایید.",
                    "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error); txtLastName.Focus(); return;
            }
            if (txtLastName.Text.Length < 3)
            {
                PMBox.Show("وارد كردن حداقل 3 حرف برای نام خانوادگی اجباری می باشد!\nلطفاً مجدداً بررسی نمایید.",
                    "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error); txtLastName.Focus(); return;
            }
            if (String.IsNullOrEmpty(txtMedicalID.Text.Trim()))
            {
                DialogResult Dr = PMBox.Show("شماره نظام پزشكی وارد نشده است!\n" +
                    "در صورت ثبت پزشك بدون شماره نظام پزشكی\nزمان گزارش گیری بیمه ها با مشكل مواجه خواهید شد.\n" +
                "آیا مایل به ادامه هستید؟",
                    "هشدار!", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                if (Dr != DialogResult.Yes) return;
            }
            if (txtMedicalID.Text.Length < 3)
            {
                DialogResult Result = PMBox.Show("شماره نظام پزشكی وارد شده كمتر از 3 رقم دارد!\n" +
                    "در صورت ثبت پزشك با شماره نظام پزشكی اشتباه\nزمان گزارش گیری بیمه ها با مشكل مواجه خواهید شد.\n" +
                    "آیا مایل به ادامه هستید؟",
                    "هشدار!", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                if (Result == DialogResult.No) return;
            }
            if (cboSpecs.SelectedIndex == 0)
            {
                PMBox.Show("هیچ تخصصی برای این پزشك انتخاب نشده است!\n" +
                    "در صورت ثبت پزشك بدون تخصص\nزمان گزارش گیری بیمه ها با مشكل مواجه خواهید شد.",
                    "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            try
            {
                List<RefPhysician> Result;
                if (_IsAdding) Result = Negar.DBLayerPMS.Manager.DBML.RefPhysicians.
                    Where(Data => Data.MedicalID == txtMedicalID.Text.Trim()).ToList();
                else Result = Negar.DBLayerPMS.Manager.DBML.RefPhysicians.Where(Data => Data.ID != ID &&
                    Data.MedicalID == txtMedicalID.Text.Trim()).ToList();
                if (Result.Count != 0)
                {
                    PMBox.Show("شماره نظام پزشكی وارد شده تكراری می باشد!\nلطفاً مجدداً بررسی نمایید.",
                        "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1); return;
                }
            }
            #region Catch
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                const String ErrorMessage =
                    "امكان خواندن اطلاعات از بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Admission Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return;
            }
            #endregion
            #endregion
            if (_IsAdding) { if (!AddOrEditCurrentPhysician(true)) return; }
            else if (!AddOrEditCurrentPhysician(false)) return;
            DialogResult = DialogResult.OK;
        }
        #endregion

        #region Form Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            if (_IsFormControlsModified)
            {
                DialogResult Dr = PMBox.Show("آیا مایلید بدون ذخیره سازی فرم را ببندید؟",
                    "هشدار!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (Dr == DialogResult.No) { e.Cancel = true; return; }
            }
        }
        #endregion

        #endregion

        #region Methods

        #region void SetFormControlsChangeEventHandlers()
        /// <summary>
        /// تابعی برای تنظیم رخداد تغییر برای كنترل های روی فرم
        /// </summary>
        private void SetFormControlsChangeEventHandlers()
        {
            foreach (Control ctrl in Controls)
            {
                // TextBoxes:
                if (ctrl is TextBoxX) ctrl.TextChanged += (FormControls_ValuesChanged);
                // ComboBoxes:
                else if (ctrl is ComboBoxEx)
                    ((ComboBoxEx)ctrl).SelectedValueChanged += (FormControls_ValuesChanged);
            }
        }
        #endregion

        #region Boolean FillSpecialty()
        /// <summary>
        /// تابع خواندن اطلاعات تخصص
        /// </summary>
        /// <returns>صحت خواندن اطلاعات</returns>
        private Boolean FillSpecialty()
        {
            cboSpecs.DataSource = Negar.DBLayerPMS.ClinicData.RefPhysicianSpecsList.
                Where(Data => Data.IsActive == 1 || Data.ID == null).ToList();
            return true;
        }
        #endregion

        #region Boolean FillPhysicianData(Int16 RowID)
        /// <summary>
        /// تابه خواندن اطلاعات یك پزشك در فرم
        /// </summary>
        /// <param name="RowID">كلید پزشك</param>
        /// <returns></returns>
        private Boolean FillPhysicianData(Int16 RowID)
        {
            _CurrentRefPhysician = Negar.DBLayerPMS.ClinicData.GetRefPhysBaseDataByID(RowID);

            if (_CurrentRefPhysician == null) return false;
            #region TextBoxes
            txtFirstName.Text = _CurrentRefPhysician.FirstName;
            txtLastName.Text = _CurrentRefPhysician.LastName;
            txtFirstNameEn.Text = _CurrentRefPhysician.FirstNameEn;
            txtLastNameEn.Text = _CurrentRefPhysician.LastNameEn;
            txtMedicalID.Text = _CurrentRefPhysician.MedicalID;
            txtDescription.Text = _CurrentRefPhysician.Description;
            #endregion

            #region Set Gender Radio Buttons
            if (_CurrentRefPhysician.IsMale) cBoxMale.Checked = true;
            else cBoxFemale.Checked = true;
            #endregion

            #region Set Selected Specialty
            if (_CurrentRefPhysician.SpecialtyIX == null)
            {
                cboSpecs.DataSource = Negar.DBLayerPMS.ClinicData.RefPhysicianSpecsList.
                Where(Data => Data.IsActive == 1 || Data.ID == null).ToList();
                cboSpecs.SelectedValue = 0;
            }
            else
            {
                cboSpecs.DataSource = Negar.DBLayerPMS.ClinicData.RefPhysicianSpecsList.
                Where(Data => Data.IsActive == 1 || Data.ID == null || Data.ID == _CurrentRefPhysician.SpecialtyIX).ToList();
                cboSpecs.SelectedValue = _CurrentRefPhysician.SpecialtyIX;
            }
            #endregion

            return true;
        }
        #endregion

        #region Boolean AddOrEditCurrentPhysician(Boolean IsAdding)
        /// <summary>
        /// تابع افزودن یا ویرایش پزشك
        /// </summary>
        /// <returns>صحت انجام كار</returns>
        private Boolean AddOrEditCurrentPhysician(Boolean IsAdding)
        {
            #region Read Data From Controls
            Boolean IsMale = true;
            if (cBoxFemale.Checked) IsMale = false;
            Int16? SpecID = null;
            if (cboSpecs.SelectedValue != null) SpecID = Convert.ToInt16(cboSpecs.SelectedValue);
            #endregion

            if (IsAdding)
            {
                _CurrentRefPhysician = new RefPhysician();
                Negar.DBLayerPMS.Manager.DBML.RefPhysicians.InsertOnSubmit(_CurrentRefPhysician);
            }
            _CurrentRefPhysician.IsActive = true;
            _CurrentRefPhysician.IsMale = IsMale;
            _CurrentRefPhysician.FirstName = txtFirstName.Text.Trim().Normalize();
            _CurrentRefPhysician.LastName = txtLastName.Text.Trim().Normalize();
            _CurrentRefPhysician.FirstNameEn = txtFirstNameEn.Text.Trim();
            _CurrentRefPhysician.LastNameEn = txtLastNameEn.Text.Trim();
            _CurrentRefPhysician.MedicalID = txtMedicalID.Text.Trim();
            _CurrentRefPhysician.SpecialtyIX = SpecID;
            _CurrentRefPhysician.Description = txtDescription.Text.Trim().Normalize();
            if (!Negar.DBLayerPMS.Manager.Submit())
            {
                const String ErrorMessage = "امكان ثبت اطلاعات پزشك در بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
            }
            if (!String.IsNullOrEmpty(txtFirstNameEn.Text.Trim()))
                if (!Negar.DBLayerPMS.Patients.AddNewNameTranslation(txtFirstName.Text, txtFirstNameEn.Text, true)) return false;
            if (!String.IsNullOrEmpty(txtLastNameEn.Text.Trim()))
                if (!Negar.DBLayerPMS.Patients.AddNewNameTranslation(txtLastName.Text, txtLastNameEn.Text, false)) return false;
            ID = _CurrentRefPhysician.ID;
            return true;
        }
        #endregion

        #endregion

    }
}