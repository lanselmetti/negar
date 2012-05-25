#region using

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Negar;
using Negar.DBLayerPMS.DataLayer;
using Negar.PersianCalendar.Utilities;
using DevComponents.DotNetBar;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Forms.Account.Properties;

#endregion

namespace Sepehr.Forms.Account
{
    /// <summary>
    /// فرم مدیریت تراكنش های حساب مراجعات بیمار
    /// </summary>
    public partial class frmManageTrans : Form
    {

        #region Fields & Properties

        #region readonly Boolean _IsAdding
        private readonly Boolean _IsAdding;
        #endregion

        #region Boolean _IsFormControlsModified
        /// <summary>
        /// تعیین ویرایش شدن تراكنش حساب  جاری توسط كاربر از حالت اولیه
        /// </summary>
        private Boolean _IsFormControlsModified;
        #endregion

        #region readonly Int32 _CurrentRefID
        /// <summary>
        /// كلید مراجعه جاری
        /// </summary>
        private readonly Int32 _CurrentRefID;
        #endregion

        #region Boolean _ShouldSubmit
        /// <summary>
        /// تعیین ثبت تراكنش پس از فشردن دكمه ثبت و نمایش قالب های قبوض
        /// </summary>
        private Boolean _ShouldSubmit;
        #endregion

        #region public  frmManageTransDesc ManageTransDescForm
        /// <summary>
        /// نمونه ی كلاس جزئیات پرداخت
        /// </summary>
        public frmManageTransDesc ManageTransDescForm { get; set; }
        #endregion

        #region Settings Fields
        /// <summary>
        /// نمایش مبلغ وارد شده به حروف در فرم تراكنش به صورت تومان.
        /// </summary>
        private Boolean _ShouldViewPriceInToman = true;
        #endregion

        #region Boolean _IsFirstInput
        private Boolean _IsFirstInput;
        #endregion

        #region Int32 _RefRemainValue
        private Int32? _RefRemainValue;
        #endregion

        #region readonly Boolean _ShouldChangePrice
        private readonly Boolean _ShouldChangePrice;
        #endregion

        #endregion

        #region Ctors

        #region frmManageTrans(Boolean IsPay, Int32 RefID, Boolean ShouldSubmit, Int32? RefRemainValue)
        /// <summary>
        /// سازنده فرم برای اضافه كردن یك تراكنش به یك مراجعه
        /// </summary>
        public frmManageTrans(Boolean IsPay, Int32 RefID, Boolean ShouldSubmit, Int32? RefRemainValue)
        {
            _IsAdding = true;
            Cursor.Current = Cursors.WaitCursor;
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("Fa-Ir"));
            InitializeComponent();
            _CurrentRefID = RefID;
            _ShouldSubmit = ShouldSubmit;
            _RefRemainValue = RefRemainValue;
            _ShouldChangePrice = true;
            #region Set Pay Status
            if (IsPay)
            {
                PanelType.Tag = 0;
                PanelType.Text = "بازپرداخت";
                lblValue.Text = "پرداختی:";
            }
            else
            {
                PanelType.Tag = 1;
                PanelType.Text = "دریافت";
                lblValue.Text = "دریافتی:";
            }
            #endregion
            #region Fill Cashes ComboBox
            // پر كردن اطلاعات كمبو باكس صندوق های مجاز
            try
            {
                cboCash.DataSource = DBLayerIMS.Manager.DBML.
                    SP_SelectCashiersCashes(SecurityManager.CurrentUserID, null).ToList();
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان خواندن اطلاعات صندوق های ثبت شده در سیستم از بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Account Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                Close();
                return;
            }
            #endregion
            #endregion
            if (!FillFormBaseData(RefID)) { Close(); return; }
            if (SecurityManager.CurrentUserID > 2 && !ReadUserPermissions()) { Close(); return; }
            if (!ReadCurrentUserSettings()) { Close(); return; }
            txtCashier.Text = Negar.DBLayerPMS.Security.UsersList.
                Where(Data => Data.ID == SecurityManager.CurrentUserID).First().FullName;
            cBoxInCash.Checked = true;
            #region Manage Showing Bill Templates
            if (!_ShouldSubmit)
            {
                cBoxPrintWithCommit.Checked = false;
                Height = Height - PanelBillTemplateSettings.Height;
                PanelBillTemplateSettings.Hide();
                lblPrintSettings.Hide();
            }
            #endregion
            TransDate.SelectedDateTime = DateTime.Now;
            TransTime.Value = DateTime.Now;
            ShowDialog();
        }
        #endregion

        #region frmManageTrans(Int32 TransID, Int32? _RefRemainValue)
        /// <summary>
        ///  سازنده فرم برای ویرایش یك تراكنش
        /// </summary>
        public frmManageTrans(Int32 TransID, Int32? RefRemainValue)
        {
            _IsAdding = false;
            Cursor.Current = Cursors.WaitCursor;
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("Fa-Ir"));
            InitializeComponent();
            if (SecurityManager.CurrentUserID > 2 && !ReadUserPermissions()) { Close(); return; }
            #region Set _CurrentRefID By TransID
            Int32? RefID = DBLayerIMS.Account.GetRefIDByTransID(TransID);
            if (RefID == null) { Close(); return; }
            _CurrentRefID = RefID.Value;
            #endregion
            if (!FillFormBaseData(Convert.ToInt32(RefID)) || !FillTransData(TransID)) { Close(); return; }
            if (!ReadCurrentUserSettings()) { Close(); return; }
            #region Hide Bill Templates Settings Panel
            Height = Height - PanelBillTemplateSettings.Height;
            PanelBillTemplateSettings.Hide();
            lblPrintSettings.Hide();
            #endregion
            _RefRemainValue = RefRemainValue;
            _ShouldChangePrice = false;
            ShowDialog();
        }
        #endregion

        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            #region Set Print With Commit Setting
            if (_ShouldSubmit)
            {
                List<UsersSetting> Setting606 = DBLayerIMS.Settings.CurrentUserSettingsFullList.
                    Where(Data => Data.SettingIX == 606).ToList();
                if (Setting606.Count != 0 && Setting606.First().Boolean != null && Setting606.First().Boolean.Value)
                    cBoxPrintWithCommit.Checked = true;
                else cBoxPrintWithCommit.Checked = false;
            }
            #endregion
            if (!SetRefRemainValue()) { Close(); return; }
            SetControlsToolTipTexts();
            txtValue_ValueChanged(null, null);
            _IsFormControlsModified = false;
            Cursor.Current = Cursors.Default;
        }
        #endregion

        #region txtValue_KeyPress
        private void txtValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!_IsFirstInput && Char.IsDigit(e.KeyChar) && SecurityManager.GetCurrentUserPermission(5620440))
            {
                _IsFirstInput = true;
                txtValue.Value = Convert.ToInt32(e.KeyChar.ToString());
            }
        }
        #endregion

        #region txtValue_ValueChanged
        /// <summary>
        /// روالی برای مدیریت نمایش مقدار عددی دریافت به حروف
        /// </summary>
        private void txtValue_ValueChanged(object sender, EventArgs e)
        {
            if (_ShouldViewPriceInToman)
            {
                if (txtValue.Value < 10) txtValueInChar.Text = "0 تومان";
                else txtValueInChar.Text = ToWords.ToString(txtValue.Value / 10) + " تومان";
            }
            else
            {
                if (txtValue.Value == 0) txtValueInChar.Text = "0 ریال";
                else txtValueInChar.Text = ToWords.ToString(txtValue.Value) + " ریال";
            }
        }
        #endregion

        #region cBoxInCash_CheckedChanged
        private void cBoxInCash_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxInCash.Checked)
            {
                btnPayTypeDetails.Visible = false;
                PanelTransaction.Invalidate();
            }
            else btnPayTypeDetails.Visible = true;
        }
        #endregion

        #region cBoxInCheck_CheckedChanged
        private void cBoxInCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxInCash.Checked)
                btnPayTypeDetails.Visible = false;
            else btnPayTypeDetails.Visible = true;
        }
        #endregion

        #region cBoxInBill_CheckedChanged
        private void cBoxInBill_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxInCash.Checked)
                btnPayTypeDetails.Visible = false;
            else btnPayTypeDetails.Visible = true;
        }
        #endregion

        #region btnPayTypeDetails_Click
        private void btnPayTypeDetails_Click(object sender, EventArgs e)
        {
            if (cBoxInBill.Checked || cBoxInCheck.Checked || cBoxInATM.Checked)
            {
                if (ManageTransDescForm == null) ManageTransDescForm = new frmManageTransDesc();
                if (ManageTransDescForm != null) ManageTransDescForm.ShowDialog();
            }
        }
        #endregion

        #region cBoxPrintWithCommit_CheckedChanged
        private void cBoxPrintWithCommit_CheckedChanged(object sender, EventArgs e)
        {
            DBLayerIMS.Settings.InsertCurrentUserSetting(606, cBoxPrintWithCommit.Checked, null);
        }
        #endregion

        #region btnPrintPreview_Click
        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            BillPrintManager.RefBillPrintPreview(_CurrentRefID, Convert.ToInt16(cboPrintTemplates.SelectedValue));
        }
        #endregion

        #region btnSave_Click
        private void btnSave_Click(object sender, EventArgs e)
        {
            #region Save Transaction If Requiered
            if (_ShouldSubmit)
            {
                RefTransaction NewRefTran = new RefTransaction();
                NewRefTran.ReferralIX = _CurrentRefID;
                NewRefTran.IsActive = true;
                if (cboCash.SelectedValue == null) NewRefTran.CashIX = null;
                else NewRefTran.CashIX = Convert.ToInt16(cboCash.SelectedValue);
                NewRefTran.CashierIX = SecurityManager.CurrentUserID;
                NewRefTran.OccuredDate = new DateTime(TransDate.SelectedDateTime.Value.Year,
                    TransDate.SelectedDateTime.Value.Month, TransDate.SelectedDateTime.Value.Day,
                    TransTime.Value.Hour, TransTime.Value.Minute, TransTime.Value.Second);
                // در فرم صندوق همراه دریافت صورت می گیرد نه بازپرداخت
                NewRefTran.Value = txtValue.Value;
                NewRefTran.Description = txtDescription.Text.Trim().Normalize();
                #region Set RefTransaction Additional Data
                // اطلاعات اضافی تراكنش
                if (!cBoxInCash.Checked)
                {
                    RefTransAddinData RefTransAdditionalData = new RefTransAddinData();
                    RefTransAdditionalData.RefTransactionIX = 0;
                    if (cBoxInCash.Checked) RefTransAdditionalData.PayType = 0;
                    else if (cBoxInCheck.Checked) RefTransAdditionalData.PayType = 1;
                    else if (cBoxInBill.Checked) RefTransAdditionalData.PayType = 2;
                    else RefTransAdditionalData.PayType = 3;
                    if (ManageTransDescForm != null)
                    {
                        if (ManageTransDescForm.cboBankName.SelectedIndex != 0)
                            RefTransAdditionalData.BankIX = Convert.ToInt16(ManageTransDescForm.cboBankName.SelectedValue);
                        RefTransAdditionalData.BranchName = ManageTransDescForm.txtBranchName.Text.Trim();
                        RefTransAdditionalData.BranchCode = ManageTransDescForm.txtBranchCode.Text.Trim();
                        RefTransAdditionalData.CheckDate = ManageTransDescForm.CheckDate.SelectedDateTime;
                        RefTransAdditionalData.CheckNumber = ManageTransDescForm.txtCheckNumber.Text.Trim();
                        if (ManageTransDescForm.cBox1.Checked) RefTransAdditionalData.AccountType = 1;
                        else if (ManageTransDescForm.cBox2.Checked) RefTransAdditionalData.AccountType = 2;
                        else RefTransAdditionalData.AccountType = 3;
                        RefTransAdditionalData.AccountNumber = ManageTransDescForm.txtAccountNumber.Text.Trim();
                        RefTransAdditionalData.Description = ManageTransDescForm.txtAccountNumber.Text.Trim();
                    }
                    NewRefTran.RefTransactionAdditionalData = RefTransAdditionalData;
                }
                #endregion
                DBLayerIMS.Manager.DBML.RefTransactions.InsertOnSubmit(NewRefTran);
                if (!DBLayerIMS.Manager.Submit())
                {
                    PMBox.Show("خطا در خواندن اطلاعات صندوقداران از بانك اطلاعات!" +
                        "موارد زیر را بررسی نمایید:\n" +
                        "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟.", "خطا!");
                    return;
                }
                // چاپ قالب
                if (cBoxPrintWithCommit.Checked && cboPrintTemplates.DataSource != null && cboPrintTemplates.SelectedIndex >= 0)
                    BillPrintManager.RefBillPrint(_CurrentRefID, Convert.ToInt16(cboPrintTemplates.SelectedValue),
                        Convert.ToInt16(txtPrintCount.Value));
            }
            #endregion
            _IsFormControlsModified = false;
            DialogResult = DialogResult.OK;
        }
        #endregion

        #region Form Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            if (_IsFormControlsModified)
            {
                DialogResult Dr = PMBox.Show("آیا مایلید بدون ذخیره سازی فرم را ببندید؟", "هشدار!",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (Dr == DialogResult.No) { e.Cancel = true; return; }
            }
            Cursor.Current = Cursors.Default;
        }
        #endregion

        #endregion

        #region Methods

        #region @@@ Security Methods @@@

        #region Boolean ReadUserPermissions()
        /// <summary>
        /// تابع بررسی سطوح دسترسی فرم
        /// </summary>
        /// <returns>صحت خواندن اطلاعات</returns>
        private Boolean ReadUserPermissions()
        {
            // تغییر اطلاعات تراكنش ها
            if (SecurityManager.GetCurrentUserPermission(5052) == false)
            {
                PMBox.Show("كاربر حاری دسترسی لازم برای تغییر اطلاعات دریافت ها و بازپرداخت ها را ندارد.",
                    "محدودیت دسترسی!", MessageBoxButtons.OK, MessageBoxIcon.Stop); return false;
            }
            // امكان ویرایش زمان تراكنش در ثبت یا ویرایش
            if (SecurityManager.GetCurrentUserPermission(50527) == false)
            {
                TransDate.IsReadonly = true;
                TransTime.IsInputReadOnly = true;
                TransTime.ShowUpDown = false;
            }
            if (!_IsAdding)
            {
                // امكان ویرایش مبلغ تراكنش
                if (SecurityManager.GetCurrentUserPermission(50528) == false)
                {
                    txtValue.IsInputReadOnly = true;
                    txtValue.ShowUpDown = false;
                }
                // امكان ویرایش نقدی یا غیر نقدی بودن تراكنش
                if (SecurityManager.GetCurrentUserPermission(50529) == false)
                {
                    PanelPayType.Enabled = false;
                    btnPayTypeDetails.Enabled = false;
                }
            }
            return true;
        }
        #endregion

        #region Boolean ReadCurrentUserSettings()
        /// <summary>
        /// تابع خواندن نظیمات فرم
        /// </summary>
        /// <returns>صحت خواندن تنظیمات</returns>
        private Boolean ReadCurrentUserSettings()
        {
            #region 506 - Default Cash
            if (_IsAdding)
            {
                // كلید صندوق پیش فرض برای عملیات ها.
                List<UsersSetting> Setting506 = DBLayerIMS.Settings.CurrentUserSettingsFullList.
                    Where(Data => Data.SettingIX == 506).ToList();
                if (Setting506.Count > 0 && Setting506.First().Value != null &&
                    ((List<SP_SelectCashiersCashesResult>)cboCash.DataSource)
                        .Exists(Data => Data.CashID == Convert.ToInt16(Setting506.First().Value)))
                    cboCash.SelectedValue = Convert.ToInt16(Setting506.First().Value);
            }
            #endregion

            #region 507 - Show Price In Toman
            List<UsersSetting> Setting507 = DBLayerIMS.Settings.CurrentUserSettingsFullList.
                Where(Data => Data.SettingIX == 507).ToList();
            // نمایش مبلغ وارد شده به حروف در فرم تراكنش به صورت تومان.
            if (Setting507.Count > 0 && Setting507.First().Boolean != null)
                _ShouldViewPriceInToman = Setting507.First().Boolean.Value;
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

            #region btnCancel
            String TooltipText = ToolTipManager.GetText("btnCancel_NoApply", "IMS");
            FormToolTip.SetSuperTooltip(btnCancel, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region cboCash
            TooltipText = ToolTipManager.GetText("cboCash", "IMS");
            FormToolTip.SetSuperTooltip(cboCash, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnPayTypeDetails
            TooltipText = ToolTipManager.GetText("btnAccountPayTypeDetails", "IMS");
            FormToolTip.SetSuperTooltip(btnPayTypeDetails, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
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

            #region btnSave
            TooltipText = ToolTipManager.GetText("btnAccept", "IMS");
            FormToolTip.SetSuperTooltip(btnSave, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

        }
        #endregion

        #region Boolean FillFormBaseData(Int32 RefID)
        /// <summary>
        /// تابع خواندن اطلاعات پایه فرم بر اساس كلید مراجعه
        /// </summary>
        /// <param name="RefID">كلید مراجعه</param>
        /// <returns>صحت خواندن اطلاعات</returns>
        private Boolean FillFormBaseData(Int32 RefID)
        {
            #region Read Patient Data
            Int32? PatientID = DBLayerIMS.Referrals.GetPatIDByRefID(RefID);
            if (PatientID == null) return false;
            // خواندن اطلاعات بیمار 
            PatList PatientDataSource = Negar.DBLayerPMS.Patients.GetPatFullDataByPatListID(PatientID.Value);
            if (PatientDataSource == null) return false;
            // پركردن فیلد های اطلاعات بیمار
            if (String.IsNullOrEmpty(PatientDataSource.FirstName))
                txtPatientFullName.Text = PatientDataSource.LastName;
            else txtPatientFullName.Text = PatientDataSource.FirstName + " " + PatientDataSource.LastName;
            txtPatientID.Text = PatientDataSource.PatientID;
            #endregion

            #region Read Ref Data
            RefList RefData = DBLayerIMS.Referrals.GetRefDataByID(RefID);
            if (RefData == null) return false;
            PersianDate PersianRefDate = PersianDateConverter.ToPersianDate(RefData.RegisterDate);
            txtRefDate.Text = PersianRefDate.Hour + ":" + PersianRefDate.Minute + ":" + PersianRefDate.Second + " - " +
                PersianRefDate.Year + "/" + PersianRefDate.Month + "/" + PersianRefDate.Day;
            // تكمیل مبلغ پیش پرداخت تعیین شده برای مراجعه در فرم پذیرش
            if (RefData.PrePayable == null) txtPrePayValue.Text = "تعیین نشده";
            else txtPrePayValue.Text = String.Format("{0:N0}", RefData.PrePayable.Value) + " ریال";
            #endregion

            #region Fill Bill Templates
            if (_ShouldSubmit && BillPrintManager.CurrentUserBillTemplatesList != null)
            {
                if (BillPrintManager.CurrentUserBillTemplatesList.Count == 0) _ShouldSubmit = false;
                else
                {
                    cboPrintTemplates.DataSource = BillPrintManager.CurrentUserBillTemplatesList;
                    cboPrintTemplates.DisplayMember = "Name";
                    cboPrintTemplates.ValueMember = "ID";
                    cboPrintTemplates.SelectedIndex = 0;
                }
            }
            #endregion
            return true;
        }
        #endregion

        #region Boolean FillTransData(Int32 TransID)
        /// <summary>
        /// تابع خواندن اطلاعات یك تراكنش از بانك اطلاعات
        /// </summary>
        /// <param name="TransID">كلید تراكنش</param>
        /// <returns>صحت خواندن اطلاعات</returns>
        private Boolean FillTransData(Int32 TransID)
        {
            try
            {
                RefTransaction TransData = DBLayerIMS.Manager.DBML.RefTransactions.
                    Where(Data => Data.ID == TransID).ToList().First();
                TransDate.SelectedDateTime = TransData.OccuredDate.Date;
                TransTime.Value = TransData.OccuredDate;
                // پر كردن اطلاعات كمبو باكس صندوق های مجاز
                cboCash.DataSource = DBLayerIMS.Manager.DBML.
                    SP_SelectCashiersCashes(SecurityManager.CurrentUserID, TransData.CashIX).ToList();
                // نمایش صندوقدار تراكنش
                if (TransData.CashIX == null)
                {
                    foreach (SP_SelectCashiersCashesResult CashItem in cboCash.Items)
                        if (CashItem.CashID == null) { cboCash.SelectedItem = CashItem; break; }
                }
                else cboCash.SelectedValue = TransData.CashIX.Value;
                // تكمیل نام صندوقدار تراكنش
                txtCashier.Text = Negar.DBLayerPMS.Security.UsersList.
                    Where(Data => Data.ID == TransData.CashierIX).First().FullName;
                // تعیین وضعیت دریافت یا بازپرداخت تراكنش
                if (TransData.Value < 0)
                {
                    PanelType.Text = "بازپرداخت";
                    PanelType.Tag = 0;
                    lblValue.Text = "پرداختی:";
                }
                else
                {
                    PanelType.Text = "دریافت";
                    PanelType.Tag = 1;
                    lblValue.Text = "دریافتی:";
                }
                // تكمیل مقدار تراكنش
                txtValue.Value = Math.Abs(TransData.Value);
                // تكمیل توضیحات تراكنش
                txtDescription.Text = TransData.Description;

                #region Fill Trans Additional Data
                if (TransData.RefTransactionAdditionalData == null) cBoxInCash.Checked = true;
                else
                {
                    ManageTransDescForm = new frmManageTransDesc();
                    if (ManageTransDescForm.IsDisposed) return false;
                    switch (TransData.RefTransactionAdditionalData.PayType)
                    {
                        case 0: cBoxInCash.Checked = true; break;
                        case 1: cBoxInCheck.Checked = true; break;
                        case 2: cBoxInBill.Checked = true; break;
                        case 3: cBoxInATM.Checked = true; break;
                    }
                    if (((List<SP_SelectBanksResult>)ManageTransDescForm.cboBankName.DataSource).
                        Where(Data => Data.ID == TransData.RefTransactionAdditionalData.BankIX).ToList().Count == 0)
                    {
                        ((List<SP_SelectBanksResult>)ManageTransDescForm.cboBankName.DataSource).
                            Union(DBLayerIMS.Account.BanksFullList.
                            Where(Data => Data.ID == TransData.RefTransactionAdditionalData.BankIX)).ToList();
                    }
                    if (TransData.RefTransactionAdditionalData.BankIX == null)
                        ManageTransDescForm.cboBankName.SelectedIndex = 0;
                    else ManageTransDescForm.cboBankName.SelectedValue = TransData.RefTransactionAdditionalData.BankIX;
                    switch (TransData.RefTransactionAdditionalData.AccountType)
                    {
                        case 1: ManageTransDescForm.cBox1.Checked = true; break;
                        case 2: ManageTransDescForm.cBox2.Checked = true; break;
                        case 3: ManageTransDescForm.cBox3.Checked = true; break;
                    }
                    ManageTransDescForm.txtBranchName.Text = TransData.RefTransactionAdditionalData.BranchName;
                    ManageTransDescForm.txtBranchCode.Text = TransData.RefTransactionAdditionalData.BranchCode;
                    ManageTransDescForm.txtAccountNumber.Text = TransData.RefTransactionAdditionalData.AccountNumber;
                    ManageTransDescForm.txtCheckNumber.Text = TransData.RefTransactionAdditionalData.CheckNumber;
                    ManageTransDescForm.CheckDate.SelectedDateTime = TransData.RefTransactionAdditionalData.CheckDate;
                    ManageTransDescForm.txtDescription.Text = TransData.RefTransactionAdditionalData.Description;
                }
                #endregion
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان خواندن اطلاعات تراكنش از بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Account Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion
            return true;
        }
        #endregion

        #region Boolean SetRefRemainValue()
        private Boolean SetRefRemainValue()
        {
            #region Ref Payable
            // خواندن پرداختنی مراجعه بیمار
            if (_RefRemainValue == null)
                try { _RefRemainValue = DBLayerIMS.Manager.DBML.FK_CalcTotalRefRemain(_CurrentRefID).Value; }
                #region Catch
                catch (Exception Ex)
                {
                    const String ErrorMessage =
                        "امكان خواندن اطلاعات باقیمانده مراجعه از بانك اطلاعات ممكن نیست.\n" +
                        "موارد زیر را بررسی نمایید:\n" +
                        "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogManager.SaveLogEntry("Sepehr", "Account Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                    return false;
                }
                #endregion
            if (_RefRemainValue == null) _RefRemainValue = 0;
            #endregion

            #region Set Default Patient Recievable
            if (_RefRemainValue >= 0) lblPatientPayable.Text = "قابل دریافت:";
            else lblPatientPayable.Text = "قابل بازپرداخت:";
            txtPatientPayable.Text = String.Format("{0:N0}", Math.Abs(_RefRemainValue.Value)) + " ریال";
            if (!_ShouldChangePrice) return true;
            // تخصیص مقدار پیش فرض پرداخت به مقدار قابل دریافت مراجعه
            // اگر مقدار باقیمانده بزرگتر از صفر است ، یعنی باید هنوز پول دریافت شود
            if (_RefRemainValue.Value >= 0)
            {
                // اگر در فرم بازپرداخت باشیم
                if (Convert.ToInt32(PanelType.Tag) == 0)
                    // مقدار پیش فرض برابر است با مجموع دریافتی های بیمار منهای مجموع بازپرداخت های بیمار
                    txtValue.Value = Math.Abs(DBLayerIMS.Manager.DBML.FK_CalcSumRecieve(_CurrentRefID).Value) -
                        Math.Abs(DBLayerIMS.Manager.DBML.FK_CalcSumPay(_CurrentRefID).Value);
                // اگر در فرم دریافت باشیم مقدار پیش فرض برابر است با باقیمانده ی مراجعه
                else txtValue.Value = _RefRemainValue.Value;
            }
            // اگر مقدار باقیمانده كوچكتر از صفر است ، یعنی باید پول بازپرداخت شود
            else
            {
                // اگر در فرم بازپرداخت باشیم
                if (Convert.ToInt32(PanelType.Tag) == 0)
                    // مقدار پیش فرض برابر است با باقیمانده مراجعه بیمار
                    txtValue.Value = Math.Abs(_RefRemainValue.Value);
                // اگر در فرم دریافت باشیم مقدار پیش فرض برابر است با صفر است
                else txtValue.Value = 0;
            }
            #endregion
            return true;
        }
        #endregion

        #endregion

    }
}