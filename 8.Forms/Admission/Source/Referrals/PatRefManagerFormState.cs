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
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Forms.Admission.Classes;

#endregion

namespace Sepehr.Forms.Admission.Referrals
{
    /// <summary>
    /// كدهای مربوط به مدیریت حالات فرم
    /// </summary>
    internal partial class frmPatRefManager
    {

        #region Methods

        #region void ChangeToAddingPatState()
        /// <summary>
        /// تابع تغییر حالت کنترل های فرم به افزودن مراجعه بیمار جدید
        /// </summary>
        private void ChangeToAddingPatState()
        {
            Text = "پذیرش - مدیریت مراجعات بیماران - افزودن بیمار جدید همراه با مراجعه";
            // تخلیه اشیاء بیمار ، مراجعه و خدمات مراجعه برای ثبت مراجعه بیمار جدید
            _CurrentPatientData = new PatList();
            _CurrentPatientData.PatDetail = new PatDetail();
            _CurrentRefData = new RefList();
            _RefServices = new List<RefService>();
            lblRefID.Text = "مراجعه جدید";
            iContainerRefNav.Visible = false;

            #region Make Buttons
            btnNewPatient.Text = "بیمار\nجدید (F2)";
            btnNewRef.Text = "مراجعه\nجدید";
            btnEditMode.Text = "ثبت\n(F3)";
            btnFreePatAndRef.Visible = false;
            btnRefresh.Visible = false;
            RibbonOrders.Invalidate();
            #endregion

            #region Set PanelPatientData Controls Properties
            txtFirstName.Text = String.Empty;
            txtFirstName.ReadOnly = false;
            txtFirstName.BackColor = Color.White;
            txtLastName.Text = String.Empty;
            txtLastName.ReadOnly = false;
            txtLastName.BackColor = Color.White;
            txtTel1.Text = String.Empty;
            txtTel1.ReadOnly = false;
            txtTel1.BackColor = Color.White;
            txtTel2.Text = String.Empty;
            txtTel2.ReadOnly = false;
            txtTel2.BackColor = Color.White;
            txtAddress.Text = String.Empty;
            txtAddress.ReadOnly = false;
            txtAddress.BackColor = Color.White;
            PanelGender.Enabled = true;
            cBoxFemale.Checked = false;
            cBoxMale.Checked = false;
            cBoxMale.TabStop = true;
            txtAgeYear.IsInputReadOnly = false;
            txtAgeYear.ShowUpDown = false;
            txtAgeYear.ButtonClear.Visible = false;
            txtAgeYear.ValueObject = null;
            txtAgeYear.BackColor = Color.White;
            txtAgeMonth.IsInputReadOnly = false;
            txtAgeMonth.ShowUpDown = false;
            txtAgeMonth.ButtonClear.Visible = false;
            txtAgeMonth.ValueObject = null;
            txtAgeMonth.BackColor = Color.White;
            txtAgeDay.IsInputReadOnly = false;
            txtAgeDay.ShowUpDown = false;
            txtAgeDay.ButtonClear.Visible = false;
            txtAgeDay.ValueObject = null;
            txtAgeDay.BackColor = Color.White;
            DateInputBirthDate.SelectedDateTime = null;
            DateInputBirthDate.IsReadonly = false;
            #endregion

            #region Set PanelRefData Properties

            #region Referral Date & Time
            DateReferral.SelectedDateTime = DateTime.Now;
            TimeReferral.ValueObject = DateTime.Now;
            // بررسی امكان ویرایش زمان مراجعه توسط كاربر
            if (_CanEditRefDate)
            {
                DateReferral.IsReadonly = false;
                TimeReferral.IsInputReadOnly = false;
                TimeReferral.ShowUpDown = true;
            }
            else
            {
                DateReferral.IsReadonly = true;
                TimeReferral.IsInputReadOnly = true;
                TimeReferral.ShowUpDown = false;
            }
            #endregion

            #region Set cboAdmitter Settings
            // منبع داده كمبوباكس پذیرش در اینجا مجدداً تنظیم میگردد
            // در حالت ثبت مراجعه برای بیمار منبع داده تنها كاربران فعال ، پذیرش كننده و همچنین مدیران پایه را نمایش می دهد
            cboAdmitter.DataSource = Negar.DBLayerPMS.Security.UsersList.Where(Data => Data.ID != null).ToList();
            cboAdmitter.SelectedValue = SecurityManager.CurrentUserID;
            // برای حالت دسترسی به امكان تغییر كاربر پذیرش كننده
            if (_CanChangeAdmitter) SetComboBoxReadOnly(cboAdmitter, false);
            // برای حالت عدم دسترسی به امكان تغییر كاربر پذیرش كننده
            // در صورتی كه كاربر امكان تغییر پذیرش كننده را نداشته باشد تنها می تواند مراجعه ای با نام خود ثبت كند
            else SetComboBoxReadOnly(cboAdmitter, true);
            #endregion

            DatePrescribe.SelectedDateTime = null;
            DatePrescribe.IsReadonly = false;

            PDateReport.SelectedDateTime = null;
            PDateReport.IsReadonly = false;

            txtWeight.ValueObject = null;
            txtWeight.IsInputReadOnly = false;
            txtWeight.ButtonClear.Visible = true;
            txtWeight.ShowUpDown = true;

            cboRefPhysician.DataSource = null;
            cboRefPhysician.Text = String.Empty;
            cboRefPhysician.BackColor = Color.White;
            SetComboBoxReadOnly(cboRefPhysician, false);
            btnAddPhysician.Enabled = true;
            btnEditPhysician.Enabled = true;

            #region cboRefStatus
            cboRefStatus.DataSource = DBLayerIMS.Referrals.RefStatusList.Where(Data => Data.IsActive == true).ToList();
            cboRefStatus.DisplayMember = "Title";
            cboRefStatus.ValueMember = "ID";
            cboRefStatus.SelectedIndex = 0;
            SetComboBoxReadOnly(cboRefStatus, false);
            #endregion

            txtDescription.Text = String.Empty;
            txtDescription.ReadOnly = false;
            txtDescription.BackColor = Color.White;
            #endregion

            #region Set PanelIns Properties
            // دستگیره ی تغییر بیمه ها در حالت نمایش غیر فعال می شود
            // این دستگیره در حالت افزودن یا ویرایش مجدداً فعال می شود
            cboIns1.SelectedIndexChanged -= cboIns1_SelectedIndexChanged;
            cboIns2.SelectedIndexChanged -= cboIns2_SelectedIndexChanged;

            cboIns1.DataSource = DBLayerIMS.Insurance.InsFullList.Where(Data => Data.IsIns1 == true &&
                Data.BaseIsActive.Value && Data.IsActive.Value).ToList();
            cboIns1.ValueMember = "ID";
            cboIns1.DisplayMember = "Name";
            SetComboBoxReadOnly(cboIns1, false);
            cboIns1.SelectedIndex = 0;

            txtIns1No1.ReadOnly = true;
            txtIns1No1.Text = String.Empty;
            txtIns1No1.TabStop = false;
            txtIns1No1.BackColor = Color.White;

            Ins1ExpireDate.SelectedDateTime = null;
            Ins1ExpireDate.IsReadonly = true;
            Ins1ExpireDate.TabStop = false;

            txtPageNo.ValueObject = null;
            txtPageNo.IsInputReadOnly = true;
            txtPageNo.ButtonClear.Visible = false;
            txtPageNo.ShowUpDown = false;
            txtPageNo.TabStop = false;

            cboIns2.DataSource = DBLayerIMS.Insurance.InsFullList.Where(Data => Data.IsIns2 == true &&
                Data.BaseIsActive.Value && Data.IsActive.Value).ToList();
            cboIns2.ValueMember = "ID";
            cboIns2.DisplayMember = "Name";
            SetComboBoxReadOnly(cboIns2, true);
            cboIns2.SelectedIndex = 0;
            cboIns2.TabStop = false;

            txtIns2No1.ReadOnly = true;
            txtIns2No1.Text = String.Empty;
            txtIns2No1.TabStop = false;
            txtIns2No1.BackColor = Color.White;

            Ins2ExpireDate.SelectedDateTime = null;
            Ins2ExpireDate.IsReadonly = true;
            Ins2ExpireDate.TabStop = false;

            cboIns1.SelectedIndexChanged += cboIns1_SelectedIndexChanged;
            cboIns2.SelectedIndexChanged += cboIns2_SelectedIndexChanged;
            #endregion

            #region Set PanelRefServices Properties
            txtServiceCode.Value = 0;
            txtServiceCode.Text = String.Empty;
            txtServiceCode.ReadOnly = false;
            txtServiceCode.BackColor = Color.White;
            txtServiceCode.Enabled = true;
            btnChooseService.Enabled = true;
            // ===============================
            cboServiceExpert.DataSource = DBLayerIMS.Referrals.RefServPerformers.
                Where(Data => Data.IsExpert == true && Data.IsActive == true).ToList();
            cboServiceExpert.ValueMember = "ID";
            cboServiceExpert.DisplayMember = "FullName";
            cboServiceExpert.SelectedIndex = 0;
            SetComboBoxReadOnly(cboServiceExpert, false);
            // ===============================
            cboServicePhysician.DataSource = DBLayerIMS.Referrals.RefServPerformers.
                Where(Data => Data.IsPhysician == true && Data.IsActive == true).ToList();
            cboServicePhysician.ValueMember = "ID";
            cboServicePhysician.DisplayMember = "FullName";
            cboServicePhysician.SelectedIndex = 0;
            SetComboBoxReadOnly(cboServicePhysician, false);

            #region dgvRefServices
            // جدول خدمات مراجعه برای ثبت مراجعه جدید تخلیه می شود
            dgvRefServices.DataSource = _RefServices;
            // در صورتی كه تنظیمات كاربر جاری خدمات را نمایش دهد این تنظیمات اعمال می شود
            if (PanelRefServices.AccessibleDescription == "Show")
            {
                ColExpert.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                ColPhysician.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                PanelRefServices.Enabled = true;
                // دسترسی به جدول مجدداً فعال می شود
                dgvRefServices.ReadOnly = false;
                dgvRefServices.AllowUserToDeleteRows = true;
                dgvRefServices.Enabled = true;
                ColServiceName.ReadOnly = true;
                ColIns1Price.ReadOnly = true;
                // در اینجا محدودیت دسترسی برای ویرایش خدمات كه در حالت ویرایش اعمال شده برداشته می شود
                ColQuantity.ReadOnly = false;
                SliderItemCount.Visible = true;
                btnIns1Cover.Visible = true;
                btnIns2Cover.Visible = true;
                btnServiceActivation.Visible = true;
            }
            #endregion

            #endregion

            #region Set PanelTotalPrices Settings
            ReCalculateAddedServicesPrices(true);
            // تنظیم كنترل پیش پرداخت
            txtPrePayment.ValueObject = null;
            txtPrePayment.IsInputReadOnly = false;
            txtPrePayment.ButtonClear.Visible = true;
            #endregion

            txtPatientID.TextBox.Text = String.Empty;
            txtFirstName.Focus();
            txtFirstName.Select();
            TimeTimer.Enabled = true; // آغاز تایمر برای زمان مراجعه در هنگام ثبت مراجعه
            _IsCurrentPatModified = false;
            Negar.DBLayerPMS.Manager.ReleaseCachedFiles();
            DBLayerIMS.Manager.ReleaseCachedFiles();
            cBoxEnterPatientAge_CheckedChanged(null, null);
        }
        #endregion

        #region void ChangeToAddingRefState()
        /// <summary>
        /// تابع تغییر حالت کنترل های فرم به افزودن مراجعه برای یك بیمار
        /// </summary>
        private void ChangeToAddingRefState()
        {
            Text = "پذیرش - مدیریت مراجعات بیماران - افزودن مراجعه جدید برای بیمار جاری";
            lblRefID.Text = "مراجعه جدید";
            iContainerRefNav.Visible = true;
            // تخلیه شیء خدمات مراجعه برای ثبت مراجعه جدید
            _CurrentRefData = new RefList();
            _RefServices = new List<RefService>();

            #region Make Buttons
            btnNewPatient.Text = "بیمار\nجدید (F2)";
            btnNewRef.Text = "مراجعه\nجدید";
            btnEditMode.Text = "ثبت\n(F3)";
            btnFreePatAndRef.Visible = false;
            btnRefresh.Visible = false;
            RibbonOrders.Invalidate();
            #endregion

            #region Set PanelPatientData Controls Properties
            txtFirstName.ReadOnly = false;
            txtFirstName.BackColor = Color.White;
            txtLastName.ReadOnly = false;
            txtLastName.BackColor = Color.White;
            txtTel1.ReadOnly = false;
            txtTel1.BackColor = Color.White;
            txtTel2.ReadOnly = false;
            txtTel2.BackColor = Color.White;
            txtAddress.ReadOnly = false;
            txtAddress.BackColor = Color.White;
            PanelGender.Enabled = true;
            txtAgeYear.IsInputReadOnly = false;
            txtAgeYear.ShowUpDown = false;
            txtAgeYear.ButtonClear.Visible = false;
            txtAgeYear.BackColor = Color.White;
            txtAgeMonth.IsInputReadOnly = false;
            txtAgeMonth.ShowUpDown = false;
            txtAgeMonth.ButtonClear.Visible = false;
            txtAgeMonth.BackColor = Color.White;
            txtAgeDay.IsInputReadOnly = false;
            txtAgeDay.ShowUpDown = false;
            txtAgeDay.ButtonClear.Visible = false;
            txtAgeDay.BackColor = Color.White;
            DateInputBirthDate.IsReadonly = false;
            #endregion

            #region Set PanelRefData Properties

            #region Referral Date & Time
            DateReferral.SelectedDateTime = DateTime.Now;
            TimeReferral.ValueObject = DateTime.Now;
            // بررسی امكان ویرایش زمان مراجعه توسط كاربر
            if (_CanEditRefDate)
            {
                DateReferral.IsReadonly = false;
                TimeReferral.IsInputReadOnly = false;
                TimeReferral.ShowUpDown = true;
            }
            else
            {
                DateReferral.IsReadonly = true;
                TimeReferral.IsInputReadOnly = true;
                TimeReferral.ShowUpDown = false;
            }
            #endregion

            #region Set cboAdmitter Settings
            // منبع داده كمبوباكس پذیرش در اینجا مجدداً تنظیم میگردد
            // در حالت ثبت مراجعه برای بیمار منبع داده تنها كاربران فعال ، پذیرش كننده و همچنین مدیران پایه را نمایش می دهد
            cboAdmitter.DataSource = Negar.DBLayerPMS.Security.UsersList.Where(Data => Data.ID != null).ToList();
            cboAdmitter.SelectedValue = SecurityManager.CurrentUserID;
            // برای حالت دسترسی به امكان تغییر كاربر پذیرش كننده
            if (_CanChangeAdmitter) SetComboBoxReadOnly(cboAdmitter, false);
            // برای حالت عدم دسترسی به امكان تغییر كاربر پذیرش كننده
            // در صورتی كه كاربر امكان تغییر پذیرش كننده را نداشته باشد تنها می تواند مراجعه ای با نام خود ثبت كند
            else SetComboBoxReadOnly(cboAdmitter, true);
            #endregion

            DatePrescribe.SelectedDateTime = null;
            DatePrescribe.IsReadonly = false;

            PDateReport.SelectedDateTime = null;
            PDateReport.IsReadonly = false;

            txtWeight.ValueObject = null;
            txtWeight.IsInputReadOnly = false;
            txtWeight.ButtonClear.Visible = true;
            txtWeight.ShowUpDown = true;

            cboRefPhysician.DataSource = null;
            cboRefPhysician.Text = String.Empty;
            cboRefPhysician.BackColor = Color.White;
            SetComboBoxReadOnly(cboRefPhysician, false);
            btnAddPhysician.Enabled = true;
            btnEditPhysician.Enabled = true;

            #region cboRefStatus
            cboRefStatus.DataSource = DBLayerIMS.Referrals.RefStatusList.Where(Data => Data.IsActive == true).ToList();
            cboRefStatus.DisplayMember = "Title";
            cboRefStatus.ValueMember = "ID";
            cboRefStatus.SelectedIndex = 0;
            SetComboBoxReadOnly(cboRefStatus, false);
            #endregion

            txtDescription.Text = String.Empty;
            txtDescription.ReadOnly = false;
            txtDescription.BackColor = Color.White;
            #endregion

            #region Set PanelIns Properties
            // دستگیره ی تغییر بیمه ها در حالت نمایش غیر فعال می شود
            // این دستگیره در حالت افزودن یا ویرایش مجدداً فعال می شود
            cboIns1.SelectedIndexChanged -= cboIns1_SelectedIndexChanged;
            cboIns2.SelectedIndexChanged -= cboIns2_SelectedIndexChanged;

            cboIns1.DataSource = DBLayerIMS.Insurance.InsFullList.Where(Data => Data.IsIns1 == true &&
                Data.BaseIsActive.Value && Data.IsActive.Value).ToList();
            cboIns1.ValueMember = "ID";
            cboIns1.DisplayMember = "Name";
            SetComboBoxReadOnly(cboIns1, false);
            cboIns1.SelectedIndex = 0;

            txtIns1No1.ReadOnly = true;
            txtIns1No1.Text = String.Empty;
            txtIns1No1.TabStop = false;
            txtIns1No1.BackColor = Color.White;

            Ins1ExpireDate.SelectedDateTime = null;
            Ins1ExpireDate.IsReadonly = true;
            Ins1ExpireDate.TabStop = false;

            txtPageNo.ValueObject = null;
            txtPageNo.IsInputReadOnly = true;
            txtPageNo.ButtonClear.Visible = false;
            txtPageNo.ShowUpDown = false;
            txtPageNo.TabStop = false;

            cboIns2.DataSource = DBLayerIMS.Insurance.InsFullList.Where(Data => Data.IsIns2 == true &&
                Data.BaseIsActive.Value && Data.IsActive.Value).ToList();
            cboIns2.ValueMember = "ID";
            cboIns2.DisplayMember = "Name";
            SetComboBoxReadOnly(cboIns2, true);
            cboIns2.SelectedIndex = 0;
            cboIns2.TabStop = false;

            txtIns2No1.ReadOnly = true;
            txtIns2No1.Text = String.Empty;
            txtIns2No1.TabStop = false;
            txtIns2No1.BackColor = Color.White;

            Ins2ExpireDate.SelectedDateTime = null;
            Ins2ExpireDate.IsReadonly = true;
            Ins2ExpireDate.TabStop = false;

            cboIns1.SelectedIndexChanged += cboIns1_SelectedIndexChanged;
            cboIns2.SelectedIndexChanged += cboIns2_SelectedIndexChanged;
            #endregion

            #region Set PanelRefServices Properties
            txtServiceCode.Value = 0;
            txtServiceCode.Text = String.Empty;
            txtServiceCode.ReadOnly = false;
            txtServiceCode.BackColor = Color.White;
            txtServiceCode.Enabled = true;
            btnChooseService.Enabled = true;
            cboServiceExpert.DataSource = DBLayerIMS.Referrals.RefServPerformers.
                Where(Data => Data.IsExpert == true && Data.IsActive == true).ToList();
            cboServiceExpert.ValueMember = "ID";
            cboServiceExpert.DisplayMember = "FullName";
            cboServiceExpert.SelectedIndex = 0;
            SetComboBoxReadOnly(cboServiceExpert, false);
            cboServicePhysician.SelectedIndex = 0;
            cboServicePhysician.DataSource = DBLayerIMS.Referrals.RefServPerformers.
                Where(Data => Data.IsPhysician == true && Data.IsActive == true).ToList();
            cboServicePhysician.ValueMember = "ID";
            cboServicePhysician.DisplayMember = "FullName";
            SetComboBoxReadOnly(cboServicePhysician, false);

            #region dgvRefServices
            // جدول خدمات مراجعه برای ثبت مراجعه جدید تخلیه می شود
            dgvRefServices.DataSource = _RefServices;
            // در صورتی كه تنظیمات كاربر جاری خدمات را نمایش دهد این تنظیمات اعمال می شود
            if (PanelRefServices.AccessibleDescription == "Show")
            {
                ColExpert.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                ColPhysician.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                PanelRefServices.Enabled = true;
                // دسترسی به جدول مجدداً فعال می شود
                dgvRefServices.ReadOnly = false;
                dgvRefServices.AllowUserToDeleteRows = true;
                dgvRefServices.Enabled = true;
                ColServiceName.ReadOnly = true;
                ColIns1Price.ReadOnly = true;
                // در اینجا محدودیت دسترسی برای ویرایش خدمات كه در حالت ویرایش اعمال شده برداشته می شود
                ColQuantity.ReadOnly = false;
                SliderItemCount.Visible = true;
                btnIns1Cover.Visible = true;
                btnIns2Cover.Visible = true;
                btnServiceActivation.Visible = true;
            }
            #endregion

            #endregion

            // تنظیم كنترل پیش پرداخت
            txtPrePayment.ValueObject = null;
            txtPrePayment.IsInputReadOnly = false;
            txtPrePayment.ButtonClear.Visible = true;
            ReCalculateAddedServicesPrices(true);
            cboIns1.Focus();
            cboIns1.Select();
            _IsCurrentPatModified = false;
            DatePrescribe.Focus();
            TimeTimer.Enabled = true; // آغاز تایمر برای زمان مراجعه در هنگام ثبت مراجعه
            cBoxEnterPatientAge_CheckedChanged(null, null);
        }
        #endregion

        #region void ChangeToViewState()
        /// <summary>
        /// تغییر حالت کنترل های فرم به حالت نمایش
        /// </summary>
        private void ChangeToViewState()
        {
            Text = "پذیرش - مدیریت مراجعات بیماران - نمایش مراجعه بیمار";
            iContainerRefNav.Visible = true;

            #region Make Buttons
            btnNewPatient.Text = "بیمار\nجدید (F2)";
            btnNewRef.Text = "مراجعه\nجدید";
            btnEditMode.Text = "ویرایش\n(F3)";
            btnFreePatAndRef.Visible = true;
            btnRefresh.Visible = true;
            RibbonOrders.Invalidate();
            #endregion

            #region Set PanelPatientData Controls Properties
            txtFirstName.ReadOnly = true;
            txtFirstName.BackColor = Color.Gainsboro;
            txtLastName.ReadOnly = true;
            txtLastName.BackColor = Color.Gainsboro;
            txtTel1.ReadOnly = true;
            txtTel1.BackColor = Color.Gainsboro;
            txtTel2.ReadOnly = true;
            txtTel2.BackColor = Color.Gainsboro;
            txtAddress.ReadOnly = true;
            txtAddress.BackColor = Color.Gainsboro;
            PanelGender.Enabled = false;
            txtAgeYear.IsInputReadOnly = true;
            txtAgeYear.ShowUpDown = false;
            txtAgeYear.ButtonClear.Visible = false;
            txtAgeYear.BackColor = Color.Gainsboro;
            txtAgeMonth.IsInputReadOnly = true;
            txtAgeMonth.ShowUpDown = false;
            txtAgeMonth.ButtonClear.Visible = false;
            txtAgeMonth.BackColor = Color.Gainsboro;
            txtAgeDay.IsInputReadOnly = true;
            txtAgeDay.ShowUpDown = false;
            txtAgeDay.ButtonClear.Visible = false;
            txtAgeDay.BackColor = Color.Gainsboro;
            DateInputBirthDate.IsReadonly = true;
            #endregion

            #region Set PanelRefData Properties
            DateReferral.IsReadonly = true;

            TimeReferral.IsInputReadOnly = true;
            TimeReferral.ShowUpDown = false;

            SetComboBoxReadOnly(cboAdmitter, true);
            DatePrescribe.IsReadonly = true;
            PDateReport.IsReadonly = true;

            txtWeight.IsInputReadOnly = true;
            txtWeight.ShowUpDown = false;
            txtWeight.ButtonClear.Visible = false;

            SetComboBoxReadOnly(cboRefPhysician, true);
            cboRefPhysician.BackColor = Color.Gainsboro;
            SetComboBoxReadOnly(cboRefStatus, true);
            btnAddPhysician.Enabled = false;
            btnEditPhysician.Enabled = false;

            txtDescription.ReadOnly = true;
            txtDescription.BackColor = Color.Gainsboro;
            #endregion

            #region Set PanelIns Properties
            // دستگیره ی تغییر بیمه ها در حالت نمایش غیر فعال می شود
            // این دستگیره در حالت افزودن یا ویرایش مجدداً فعال می شود
            cboIns1.SelectedIndexChanged -= cboIns1_SelectedIndexChanged;
            cboIns2.SelectedIndexChanged -= cboIns2_SelectedIndexChanged;
            SetComboBoxReadOnly(cboIns1, true);
            txtIns1No1.ReadOnly = true;
            txtIns1No1.BackColor = Color.Gainsboro;
            Ins1ExpireDate.IsReadonly = true;
            txtPageNo.IsInputReadOnly = true;
            txtPageNo.ButtonClear.Visible = false;
            txtPageNo.ShowUpDown = false;
            SetComboBoxReadOnly(cboIns2, true);
            txtIns2No1.ReadOnly = true;
            txtIns2No1.BackColor = Color.Gainsboro;
            Ins2ExpireDate.IsReadonly = true;
            #endregion

            #region Set PanelRefServices Properties
            ColExpert.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            ColPhysician.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;

            txtServiceCode.Value = 0;
            txtServiceCode.Text = String.Empty;
            txtServiceCode.ReadOnly = true;
            txtServiceCode.BackColor = Color.Gainsboro;
            txtServiceCode.Enabled = false;

            btnChooseService.Enabled = false;
            SetComboBoxReadOnly(cboServiceExpert, true);
            SetComboBoxReadOnly(cboServicePhysician, true);
            dgvRefServices.ReadOnly = true;
            dgvRefServices.AllowUserToDeleteRows = false;
            // به دلیل اعمال تنظیمات برای كاربر جاری در وضعیت ویرایش ، این پنل مجدداً فعال می شود
            PanelRefServices.Enabled = true;
            #endregion

            // تنظیم كنترل پیش پرداخت
            txtPrePayment.IsInputReadOnly = true;
            txtPrePayment.ButtonClear.Visible = false;
            txtPrePayment.BackColor = Color.Gainsboro;
            // كسب اطمینان از غیر فعال بودن تایمر برای حالت ثبت مراجعه - در صورتی كه از حالت ثبت مراجعه آمده باشیم
            if (TimeTimer.Enabled) TimeTimer.Enabled = false;
            // حالت ویرایش شده فرم حذف می شود
            _IsCurrentPatModified = false;

            _CurrentSchID = null;
            _IsCurrentPatModified = false;
            cBoxEnterPatientAge_CheckedChanged(null, null);
        }
        #endregion

        #region void ChangeToEditState()
        /// <summary>
        /// تغییر حالت کنترل های فرم به حالت ویرایش
        /// </summary>
        private void ChangeToEditState()
        {
            Negar.DBLayerPMS.Manager.ReleaseCachedFiles();
            DBLayerIMS.Manager.ReleaseCachedFiles();
            btnRefresh_Click(null, null);
            Text = "پذیرش - مدیریت مراجعات بیماران - ویرایش مراجعه بیمار";
            iContainerRefNav.Visible = true;

            #region Make Buttons
            btnNewPatient.Text = "بیمار\nجدید (F2)";
            btnNewRef.Text = "مراجعه\nجدید";
            btnEditMode.Text = "ثبت\n(F3)";
            btnFreePatAndRef.Visible = false;
            btnRefresh.Visible = false;
            RibbonOrders.Invalidate();
            #endregion

            #region Set PanelPatientData Controls Properties
            if (_CanEditPatientFullName) // بررسی امكان ویرایش نام و نام خانوادگی بیمار
            {
                txtFirstName.ReadOnly = false;
                txtFirstName.BackColor = Color.White;
                txtLastName.ReadOnly = false;
                txtLastName.BackColor = Color.White;
            }
            else
            {
                txtFirstName.ReadOnly = true;
                txtFirstName.BackColor = Color.Gainsboro;
                txtLastName.ReadOnly = true;
                txtLastName.BackColor = Color.Gainsboro;
            }

            txtTel1.ReadOnly = false;
            txtTel1.BackColor = Color.White;
            txtTel2.ReadOnly = false;
            txtTel2.BackColor = Color.White;
            txtAddress.ReadOnly = false;
            txtAddress.BackColor = Color.White;
            PanelGender.Enabled = true;
            txtAgeYear.IsInputReadOnly = false;
            txtAgeYear.ShowUpDown = false;
            txtAgeYear.ButtonClear.Visible = false;
            txtAgeYear.BackColor = Color.White;
            txtAgeMonth.IsInputReadOnly = false;
            txtAgeMonth.ShowUpDown = false;
            txtAgeMonth.ButtonClear.Visible = false;
            txtAgeMonth.BackColor = Color.White;
            txtAgeDay.IsInputReadOnly = false;
            txtAgeDay.ShowUpDown = false;
            txtAgeDay.ButtonClear.Visible = false;
            txtAgeDay.BackColor = Color.White;
            DateInputBirthDate.IsReadonly = false;
            #endregion

            #region Set PanelRefData Properties
            // بررسی امكان ویرایش زمان مراجعه توسط كاربر
            if (_CanEditRefDate)
            {
                DateReferral.IsReadonly = false;
                TimeReferral.IsInputReadOnly = false;
                TimeReferral.ShowUpDown = true;
            }
            else
            {
                DateReferral.IsReadonly = true;
                TimeReferral.IsInputReadOnly = true;
                TimeReferral.ShowUpDown = false;
            }
            // برای حالت دسترسی به امكان تغییر كاربر پذیرش كننده
            if (_CanChangeAdmitter) SetComboBoxReadOnly(cboAdmitter, false);
            // برای حالت عدم دسترسی به امكان تغییر كاربر پذیرش كننده
            // در صورتی كه كاربر امكان تغییر پذیرش كننده را نداشته باشد تنها می تواند مراجعه ای با نام خود ثبت كند
            else SetComboBoxReadOnly(cboAdmitter, true);
            // در صورت دسترسی به تغییر تاریخ نسخه
            if (_CanEditPrescriptionDate) DatePrescribe.IsReadonly = false;
            else DatePrescribe.IsReadonly = true;
            PDateReport.IsReadonly = false;
            txtWeight.IsInputReadOnly = false;
            txtWeight.ShowUpDown = true;
            txtWeight.ButtonClear.Visible = true;
            // در صورت دسترسی به تغییر پزشك درخواست كننده
            if (_CanEditRefPhysician)
            {
                SetComboBoxReadOnly(cboRefPhysician, false);
                cboRefPhysician.BackColor = Color.White;
                btnAddPhysician.Enabled = true;
                btnEditPhysician.Enabled = true;
            }
            // در صورت عدم دسترسی به پزشك درخواست كننده
            else
            {
                SetComboBoxReadOnly(cboRefPhysician, true);
                cboRefPhysician.BackColor = Color.Gainsboro;
                btnAddPhysician.Enabled = false;
                btnEditPhysician.Enabled = false;
            }
            SetComboBoxReadOnly(cboRefStatus, false);
            txtDescription.ReadOnly = false;
            txtDescription.BackColor = Color.White;
            #endregion

            #region Set PanelIns Properties
            // دستگیره ی تغییر بیمه ها در حالت نمایش غیر فعال می شود
            // این دستگیره در حالت افزودن یا ویرایش مجدداً فعال می شود
            cboIns1.SelectedIndexChanged -= cboIns1_SelectedIndexChanged;
            cboIns2.SelectedIndexChanged -= cboIns2_SelectedIndexChanged;
            SetComboBoxReadOnly(cboIns1, false);

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

                SetComboBoxReadOnly(cboIns2, true);
                cboIns2.TabStop = false;
                txtIns2No1.ReadOnly = true;
                txtIns2No1.TabStop = false;
                Ins2ExpireDate.IsReadonly = true;
                Ins2ExpireDate.TabStop = false;
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
                SetComboBoxReadOnly(cboIns2, false);
                cboIns2.TabStop = true;

                #region Ins2 Is Not Selected
                if (cboIns2.SelectedIndex == 0)
                {
                    txtIns2No1.ReadOnly = true;
                    txtIns2No1.TabStop = false;
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

            }
            #endregion

            if (_CanEditInsData)
            {
                #region Can Change Ins 1
                // دسترسی تغییر بیمه اول
                if (_CanChangeIns1)
                {
                    cboIns1.SelectedIndexChanged += cboIns1_SelectedIndexChanged;
                }
                else
                {
                    cboIns1.SelectedIndexChanged -= cboIns1_SelectedIndexChanged;
                    SetComboBoxReadOnly(cboIns1, true);
                }
                #endregion

                #region Can Edit Ins 1 Number
                // دسترسی امكان تغییر شماره بیمه اول
                if (_CanEditIns1Num)
                {
                    txtIns1No1.BackColor = Color.White;
                }
                else
                {
                    txtIns1No1.ReadOnly = true;
                    txtIns1No1.BackColor = Color.Gainsboro;
                }
                #endregion

                #region Can Edit Ins 1 Expire Date
                // دسترسی امكان تغییر تاریخ اعتبار بیمه اول
                if (!_CanEditIns1ExpireDate)
                {
                    Ins1ExpireDate.IsReadonly = true;
                }
                #endregion

                #region Can Edit Ins 1 Page Numeber
                // دسترسی امكان تغییر شماره صفحه بیمه اول
                if (!_CanEditIns1PageNum)
                {
                    txtPageNo.IsInputReadOnly = true;
                    txtPageNo.ButtonClear.Visible = false;
                    txtPageNo.ShowUpDown = false;
                }
                #endregion

                #region Can Change Ins 2
                // دسترسی امكان تغییر بیمه دوم
                if (_CanChangeIns2)
                {
                    cboIns2.SelectedIndexChanged += cboIns2_SelectedIndexChanged;
                }
                else
                {
                    cboIns2.SelectedIndexChanged -= cboIns2_SelectedIndexChanged;
                    SetComboBoxReadOnly(cboIns2, true);
                }
                #endregion

                #region Can Edit Ins 2 Number
                // دسترسی امكان تغییر شماره بیمه دوم
                if (_CanEditIns2Num)
                {
                    txtIns2No1.BackColor = Color.White;
                }
                else
                {
                    txtIns2No1.ReadOnly = true;
                    txtIns2No1.BackColor = Color.Gainsboro;
                }
                #endregion
            }
            else
            {
                cboIns1.SelectedIndexChanged -= cboIns1_SelectedIndexChanged;
                SetComboBoxReadOnly(cboIns1, true);
                txtIns1No1.ReadOnly = true;
                txtIns1No1.BackColor = Color.Gainsboro;
                Ins1ExpireDate.IsReadonly = true;
                txtPageNo.IsInputReadOnly = true;
                txtPageNo.ButtonClear.Visible = false;
                txtPageNo.ShowUpDown = false;
                // =====================================
                cboIns2.SelectedIndexChanged -= cboIns2_SelectedIndexChanged;
                SetComboBoxReadOnly(cboIns2, true);
                txtIns2No1.ReadOnly = true;
                txtIns2No1.BackColor = Color.Gainsboro;
                Ins2ExpireDate.IsReadonly = true;
            }
            #endregion

            #region Set PanelRefServices Properties
            // در صورتی كه تنظیمات كاربر جاری خدمات را نمایش دهد این تنظیمات اعمال می شود
            if (PanelRefServices.AccessibleDescription == "Show")
            {
                ColExpert.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                ColPhysician.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                txtServiceCode.Value = 0;
                txtServiceCode.Text = String.Empty;
                txtServiceCode.ReadOnly = false;
                txtServiceCode.BackColor = Color.White;
                txtServiceCode.Enabled = true;
                btnChooseService.Enabled = true;
                cboServiceExpert.SelectedIndex = 0;
                SetComboBoxReadOnly(cboServiceExpert, false);
                cboServicePhysician.SelectedIndex = 0;
                SetComboBoxReadOnly(cboServicePhysician, false);
                #region dgvRefServices
                // در صورتی كه تنظیمات كاربر جاری خدمات را نمایش دهد این تنظیمات اعمال می شود
                if (_CanEditServices)
                {
                    PanelRefServices.Enabled = true;
                    // دسترسی به جدول مجدداً فعال می شود
                    dgvRefServices.ReadOnly = false;
                    dgvRefServices.AllowUserToDeleteRows = true;
                    dgvRefServices.Enabled = true;
                    ColServiceName.ReadOnly = true;
                    ColIns1Price.ReadOnly = true;
                    // در اینجا محدودیت دسترسی برای ویرایش خدمات كه در حالت ویرایش اعمال شده برداشته می شود
                    if (_CanChangeServiceQuantity)
                    {
                        ColQuantity.ReadOnly = false;
                        SliderItemCount.Visible = true;
                    }
                    else
                    {
                        ColQuantity.ReadOnly = true;
                        SliderItemCount.Visible = false;
                    }
                    btnIns1Cover.Visible = true;
                    btnIns2Cover.Visible = true;
                    if (_CanChangeServiceActivation) btnServiceActivation.Visible = true;
                    else
                    {
                        #region Can Change Service Activation After Pay
                        if (!_CanChangeServiceActivationAfterPay)
                        {
                            try
                            {
                                IQueryable<Int32> TempData = DBLayerIMS.Manager.DBML.RefTransactions.
                                    Where(Data => Data.ReferralIX == _CurrentRefData.ID).Select(Data => Data.ID);
                                DBLayerIMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, TempData);
                                if (TempData.Count() > 0) btnServiceActivation.Visible = false;
                                else btnServiceActivation.Visible = true;
                            }
                            #region Catch
                            catch (Exception Ex)
                            {
                                LogManager.SaveLogEntry("Sepehr", "Admission Forms", Ex.Message + "\n" +
                                    Ex.StackTrace, EventLogEntryType.Error); return;
                            }
                            #endregion
                        }
                        #endregion
                    }
                }
                // در اینجا در صورت محدودیت دسترسی برای ویرایش خدمات ، دسترسی ها بر روی كنترل ها اعمال می شود
                // این محدودیت ها مجدداً در حالت افزودن مراجعه برداشته می شود چون محدودیت ها فقط برای ویرایش مراجعه می باشد
                else PanelRefServices.Enabled = false;
                #endregion
            }
            #endregion

            // تنظیم كنترل پیش پرداخت
            txtPrePayment.IsInputReadOnly = false;
            txtPrePayment.ButtonClear.Visible = true;
            // فوكوس بر روی كنترل بیمه برای ویرایش مراجعه
            cboIns1.Focus();
            // حالت ویرایش شده فرم حذف می شود
            _IsCurrentPatModified = false;
            txtFirstName.Focus();
            txtFirstName.Select();
            _CurrentSchID = null;
            _IsCurrentPatModified = false;
            cBoxEnterPatientAge_CheckedChanged(null, null);
        }
        #endregion

        #region static void SetComboBoxReadOnly(ComboBox cbo, Boolean Readonly)
        private static void SetComboBoxReadOnly(ComboBox cbo, Boolean Readonly)
        {
            if (Readonly)
            {
                cbo.Tag = true;
                cbo.KeyPress += (cbo_KeyPress);
                cbo.ContextMenu = new ContextMenu();
                cbo.DropDownStyle = ComboBoxStyle.Simple;
                if (cbo.GetType().Equals(typeof(IMSComboBox)))
                    ((IMSComboBox)cbo).ReadOnly = true;
            }
            else
            {
                cbo.Tag = false;
                cbo.KeyPress -= (cbo_KeyPress);
                if (cbo.GetType().Equals(typeof(IMSComboBox))) ((IMSComboBox)cbo).ReadOnly = false;
                cbo.ContextMenu = null;
                if (cbo.AccessibleDescription == "DropDown")
                    cbo.DropDownStyle = ComboBoxStyle.DropDown;
                else if (cbo.AccessibleDescription == "Simple")
                    cbo.DropDownStyle = ComboBoxStyle.Simple;
                else cbo.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            cbo.Invalidate();
        }

        void cbo_KeyDown(object sender, KeyEventArgs e)
        {
            if (((Control)sender).Tag != null && Convert.ToBoolean(((Control)sender).Tag))
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Delete)
                    e.Handled = true;
            }
            // ReSharper disable PossibleNullReferenceException
            if (e.KeyCode == Keys.Escape) DialogResult = DialogResult.Cancel;
            // ReSharper restore PossibleNullReferenceException
        }

        static void cbo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != Convert.ToChar(Keys.Escape)) e.Handled = true;
        }
        #endregion

        #endregion

    }
}