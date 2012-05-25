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
using Negar.PersianCalendar.Utilities;
using DevComponents.DotNetBar;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Forms.Account.Properties;

#endregion

namespace Sepehr.Forms.Account
{
    /// <summary>
    /// فرم مدیریت حساب بیمار
    /// </summary>
    public partial class frmAccount : Form
    {

        #region Enums
        /// <summary>
        /// تعیین وضعیت فرم حساب 
        /// </summary>
        public enum AccountFormStates
        {
            /// <summary>
            /// حالت نمایش یك حساب  برای یك بیمار
            /// </summary>
            Viewing = 1,
            /// <summary>
            /// حالت ویرایش یك حساب  بیمار
            /// </summary>
            Editing = 2
        } ;
        #endregion

        #region Fields & Properties

        #region AccountFormStates _FormState
        /// <summary>
        /// وضعیت فرم حساب   در سه حالت افزودن , ویرایش و نمایش
        /// </summary>
        private AccountFormStates _FormState;
        #endregion

        #region AccountFormStates CurrentFormState
        /// <summary>
        /// وضعیت فرم جاری
        /// </summary>
        private AccountFormStates CurrentFormState
        {
            get { return _FormState; }
            set
            {
                if (value == AccountFormStates.Viewing) { ChangeToViewState(); }
                else if (value == AccountFormStates.Editing) { ChangeToEditState(); }
                _FormState = value;
            }
        }
        #endregion

        #region Boolean _IsCurrentFormModified
        /// <summary>
        /// تعیین ویرایش شدن تراكنش حساب  جاری توسط كاربر از حالت اولیه
        /// </summary>
        private Boolean _IsCurrentFormModified;
        #endregion

        #region @@@ Current Data @@@

        #region Int32 _CurrentPatientListID
        /// <summary>
        /// كلید بیمار جاری
        /// </summary>
        private Int32 _CurrentPatientListID;
        #endregion

        #region Int32 CurrentPatientListID
        /// <summary>
        /// کد بیمارجاری فرم
        /// </summary>
        private Int32 CurrentPatientListID
        {
            get { return _CurrentPatientListID; }
            set
            {
                if (!FillPatDataByPatID(value)) _CurrentPatientListID = 0;
                else _CurrentPatientListID = value;
            }
        }
        #endregion

        #region Int32 _CurrentRefID
        /// <summary>
        /// كلید مراجعه ی جاری
        /// </summary>
        private Int32 _CurrentRefID;
        #endregion

        #region Int32 CurrentRefID
        /// <summary>
        /// کد مراجعه  جاری فرم
        /// </summary>
        private Int32 CurrentRefID
        {
            set
            {
                if (!FillRefDataByRefID(value)) { _CurrentRefID = 0; return; }
                _CurrentRefID = value;
            }
        }
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

        #region List<RefService> _CurrentRefServices
        /// <summary>
        /// لیست خدمات ثبت شده برای مراجعه ی جاری
        /// </summary>
        private List<RefService> _CurrentRefServices;
        #endregion

        #region List<RefCostsAndDiscount> _CurrentRefCostsDiscounts
        /// <summary>
        /// لیست تخفیف ها 
        /// </summary>
        private List<RefCostsAndDiscount> _CurrentRefCostsDiscounts;
        #endregion

        #region List<RefTransaction> _CurrentRefTransaction
        /// <summary>
        /// اطلاعات داد و سند مالی مراجعه جاری
        /// </summary>
        private List<RefTransaction> _CurrentRefTransaction;
        #endregion

        #region Int32 _CurrentRefRecievableValue
        /// <summary>
        /// مبلغ قابل دریافت برای مراجعه جاری
        /// </summary>
        private Int32 _CurrentRefRecievableValue;
        #endregion

        #endregion

        #region Settings Fields
        /// <summary>
        /// حساب هایی كه تاریخ مراجعه آنها برای بیش از تاریخی مشخص است بسته شوند
        /// </summary>
        private Boolean _ShouldCloseAccountByTime;
        /// <summary>
        /// تعداد روزهایی كه باید پس از گذشتن ، یك حساب بسته شود
        /// </summary>
        private Int32 _DaysToCloseAccount = 90;
        #endregion

        #region ACL Fields
        /// <summary>
        /// تعیین امكان ویرایش دریافت ها
        /// </summary>
        private Boolean _CanEditRecievesMoney = true;
        /// <summary>
        /// تعیین امكان ویرایش بازپرداخت ها
        /// </summary>
        private Boolean _CanEditPayMoney = true;
        /// <summary>
        /// امكان حذف دریافت
        /// </summary>
        private Boolean _CanRemoveRecieves = true;
        /// <summary>
        /// امكان حذف بازپرداخت
        /// </summary>
        private Boolean _CanRemovePays = true;
        /// <summary>
        /// تعیین امكان ویرایش تخفیف ها
        /// </summary>
        private Boolean _CanEditDiscounts = true;
        /// <summary>
        /// امكان حذف یك تخفیف
        /// </summary>
        private Boolean _CanRemoveDiscounts = true;
        /// <summary>
        /// امكان ویرایش یك هزینه
        /// </summary>
        private Boolean _CanEditCosts = true;
        /// <summary>
        /// امكان حذف یك هزینه
        /// </summary>
        private Boolean _CanRemoveCosts = true;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده فرم برای نمایش یك حساب یك مراجعه خاص یا آخرین مراجعه ی یك بیمار
        /// </summary>
        /// <param name="ID">كلید دریافتی</param>
        /// <param name="IsPatientID">كلید بیمار یا كلید مراجعه</param>
        public frmAccount(Int32 ID, Boolean IsPatientID)
        {
            Cursor.Current = Cursors.WaitCursor;
            InitializeComponent();
            dgvServices.AutoGenerateColumns = false;
            dgvCostDiscounts.AutoGenerateColumns = false;
            dgvTransaction.AutoGenerateColumns = false;
            if (Negar.DBLayerPMS.Security.UsersList == null) { Close(); return; }
            // بررسی سطح دسترسی كاربر جاری
            if (SecurityManager.CurrentUserID > 2 && !ReadCurrentUserPermissions()) { Close(); return; }
            if (!ReadCurrentUserSettings() || !FillDataSources()) { _IsCurrentFormModified = false; Close(); return; }
            txtPatientID.TextBox.Font = new Font("B Zar", 12, FontStyle.Bold);
            txtPatientID.HeightInternal = 25;
            txtPatientID.TextBox.RightToLeft = RightToLeft.No;
            txtPatientID.TextBox.TextAlign = HorizontalAlignment.Center;

            #region PatientID Passed
            // اگر كلید بیمار باشد حساب آخرین مراجعه ی بیمار نمایش داده می شود
            if (IsPatientID)
            {
                CurrentPatientListID = ID;
                if (CurrentPatientListID == 0) { _IsCurrentFormModified = false; Close(); return; }
                Int32? PatientLastRefID = DBLayerIMS.Referrals.GetPatFirstOrLastRefID(ID, true);
                if (PatientLastRefID == null) { _IsCurrentFormModified = false; Close(); return; }
                if (PatientLastRefID == 0)
                {
                    PMBox.Show("برای بیمار انتخاب شده مراجعه ای وجود ندارد!\n" +
                        "برای نمایش حساب باید بیمار دارای مراجعه باشد.", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _IsCurrentFormModified = false; Close(); return;
                }
                CurrentRefID = PatientLastRefID.Value;
                if (_CurrentRefID == 0) { _IsCurrentFormModified = false; Close(); return; }
            }
            #endregion

            #region RefID Passed
            // اگر كلید ارسالی ، كلید مراجعه باشد ، مراجعه ی مورد نظر نمایش داده می شود
            else
            {
                Int32? PatientListID = DBLayerIMS.Referrals.GetPatIDByRefID(ID);
                if (PatientListID == null) { _IsCurrentFormModified = false; Close(); return; }
                if (PatientListID == 0)
                {
                    PMBox.Show("بیماری با مراجعه ی انتخاب شده وجود ندارد!", "خطا!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error); _IsCurrentFormModified = false; Close(); return;
                }
                CurrentPatientListID = PatientListID.Value;
                if (_CurrentPatientListID == 0) { _IsCurrentFormModified = false; Close(); return; }
                CurrentRefID = ID;
                if (_CurrentRefID == 0) { _IsCurrentFormModified = false; Close(); return; }
            }
            #endregion

            if (!IsDisposed) ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            #region Try Open Form In Editing State
            // اگر حساب ها بر اساس زمان آنها باید بسته شوند و حساب جاری از زمان مورد نظر گذشته ، فرم در حالت نمایش باز میشود
            if (_ShouldCloseAccountByTime && _CurrentRefData.RegisterDate < DateTime.Now.AddDays(-1 * _DaysToCloseAccount))
                CurrentFormState = AccountFormStates.Viewing;
            // اینجا باید بررسی می شود كه مراجعه توسط كاربر دیگری ویرایش نگردد
            else if (!DBLayerIMS.Referrals.CheckRefIsLock(_CurrentRefID)) CurrentFormState = AccountFormStates.Viewing;
            else
            {
                CurrentFormState = AccountFormStates.Viewing;
                btnEditMode_Click(null, null);
            }
            #endregion
            _IsCurrentFormModified = false;
            btnRecieveMoney.Focus();
            Opacity = 1;
            Cursor.Current = Cursors.Default;
        }
        #endregion

        #region @@@ Ribbon Event Handlers @@@

        #region btnClose_Click
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region @@@ Navigation Event Handlers @@@

        #region txtPatientID_KeyPress
        /// <summary>
        /// روال مدیریت شماره بیمار وارد شده برای جابجایی بیمار
        /// </summary>
        private void txtPatientID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\r' || String.IsNullOrEmpty(txtPatientID.TextBox.Text.Trim())) return;
            dgvServices.EndEdit();
            dgvServices.Focus();
            #region Check User Permission If _IsCurrentFormModified Is True
            // اگر مراجعه ویرایش شده بود
            if (CurrentFormState == AccountFormStates.Editing && _IsCurrentFormModified && !ManageNavigation()) return;
            #region UnLock Current Ref
            // آزاد سازی مراجعه
            if (CurrentFormState == AccountFormStates.Editing) DBLayerIMS.Referrals.ChangeRefLock(_CurrentRefID, false);
            #endregion
            _IsCurrentFormModified = false;
            #endregion
            txtPatientID.Text = txtPatientID.Text.Trim();
            Int32? PatientListID = Negar.DBLayerPMS.Patients.GetPatListIDByPatientID(txtPatientID.TextBox.Text);
            if (PatientListID == 0) return;
            if (PatientListID == null)
            {
                PMBox.Show("بیماری با كد وارد شده وجود ندارد!", "خطا!",
                  MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            Int32? PatientLastRefID = DBLayerIMS.Referrals.GetPatFirstOrLastRefID(PatientListID.Value, true);
            if (PatientLastRefID == null) return;
            if (PatientLastRefID == 0)
            {
                PMBox.Show("بیمار انتخاب شده دارای مراجعه نمی باشد!", "خطا!",
                  MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            if (CurrentPatientListID != PatientListID.Value)
            {
                CurrentPatientListID = PatientListID.Value;
                CurrentRefID = PatientLastRefID.Value;
                CurrentFormState = AccountFormStates.Viewing;
            }
            dgvServices.Focus();
        }
        #endregion

        #region btnPrevPatient_Click
        /// <summary>
        /// دكمه ی جابجایی بیمار جاری به بیمار قبلی
        /// </summary>
        private void btnPrevPatient_Click(object sender, EventArgs e)
        {
            dgvServices.EndEdit();
            dgvServices.Focus();
            #region Check User Permission If _IsCurrentFormModified Is True
            // اگر مراجعه ویرایش شده بود
            if (CurrentFormState == AccountFormStates.Editing && _IsCurrentFormModified && !ManageNavigation()) return;
            #region UnLock Current Ref
            // آزاد سازی مراجعه
            if (CurrentFormState == AccountFormStates.Editing) DBLayerIMS.Referrals.ChangeRefLock(_CurrentRefID, false);
            #endregion
            _IsCurrentFormModified = false;
            #endregion

            Int32? PrevPatientListID = _CurrentPatientListID;
            while (true)
            {
                // بدست آوردن كد بیمار قبلی
                PrevPatientListID = Negar.DBLayerPMS.Patients.GetPrevOrNextPatID(Convert.ToInt32(PrevPatientListID), false);
                // اگر بیمار قبلی وجود نداشت یا با بیمار جاری یكسان بود ، عملیات متوقف می شود
                if (PrevPatientListID == null || PrevPatientListID == _CurrentPatientListID) break;
                // ابتدا بررسی می شود كه بیمار جاری آخرین مراجعه دارد یا خیر
                Int32? PatientLastRefID = DBLayerIMS.Referrals.GetPatFirstOrLastRefID(PrevPatientListID.Value, true);
                // اگر آخرین مراجعه وجود داشت و با مراجعه ی فعلی متفاوت بود
                if (PatientLastRefID != null && PatientLastRefID.Value != 0 && PatientLastRefID != _CurrentRefID)
                {
                    // ابتدا بیمار جاری تغییر می كند
                    CurrentPatientListID = Convert.ToInt32(PrevPatientListID);
                    // شماره مراجعه ی جاری تغییر كرده و وضعیت فرم به نمایش تغییر می كند
                    CurrentRefID = Convert.ToInt32(PatientLastRefID);
                    CurrentFormState = AccountFormStates.Viewing;
                    break;
                }
                if (PrevPatientListID == Negar.DBLayerPMS.Patients.GetFirstOrLastPatientListID(false)) break;
            }
            dgvServices.Focus();
        }
        #endregion

        #region btnNextPatient_Click
        /// <summary>
        /// دكمه ی جابجایی بیمار جاری به بیمار بعدی
        /// </summary>
        private void btnNextPatient_Click(object sender, EventArgs e)
        {
            dgvServices.EndEdit();
            dgvServices.Focus();
            #region Check User Permission If _IsCurrentFormModified Is True
            // اگر مراجعه ویرایش شده بود
            if (CurrentFormState == AccountFormStates.Editing && _IsCurrentFormModified && !ManageNavigation()) return;
            #region UnLock Current Ref
            // آزاد سازی مراجعه
            if (CurrentFormState == AccountFormStates.Editing) DBLayerIMS.Referrals.ChangeRefLock(_CurrentRefID, false);
            #endregion
            _IsCurrentFormModified = false;
            #endregion

            Int32? NextPatientListID = _CurrentPatientListID;
            while (true)
            {
                // بدست آوردن كد بیمار بعدی
                NextPatientListID = Negar.DBLayerPMS.Patients.GetPrevOrNextPatID(Convert.ToInt32(NextPatientListID), true);
                // اگر بیمار بعدی وجود نداشت یا با بیمار جاری یكسان بود ، عملیات متوقف می شود
                if (NextPatientListID == null || NextPatientListID == _CurrentPatientListID) return;
                // ابتدا بررسی می شود كه بیمار جاری آخرین مراجعه دارد یا خیر
                Int32? PatientLastRefID = DBLayerIMS.Referrals.GetPatFirstOrLastRefID(NextPatientListID.Value, true);
                // اگر آخرین مراجعه وجود داشت و با مراجعه ی فعلی متفاوت بود
                if (PatientLastRefID != null && PatientLastRefID.Value != 0 && PatientLastRefID != _CurrentRefID)
                {
                    // ابتدا بیمار جاری تغییر می كند
                    CurrentPatientListID = Convert.ToInt32(NextPatientListID);
                    // شماره مراجعه ی جاری تغییر كرده و وضعیت فرم به نمایش تغییر می كند
                    CurrentRefID = Convert.ToInt32(PatientLastRefID);
                    CurrentFormState = AccountFormStates.Viewing;
                    break;
                }
                if (NextPatientListID == Negar.DBLayerPMS.Patients.GetFirstOrLastPatientListID(true)) break;
            }
            dgvServices.Focus();
        }
        #endregion

        #region btnPrevRef_Click
        /// <summary>
        /// دكمه ی جابجایی مراجعه ی بیمار جاری به مراجعه ی قبلی آن بیمار
        /// </summary>
        private void btnPrevRef_Click(object sender, EventArgs e)
        {
            btnPrevReferral.Pulse(2);
            dgvServices.EndEdit();
            dgvServices.Focus();
            #region Check User Permission If _IsCurrentFormModified Is True
            // اگر مراجعه ویرایش شده بود
            if (CurrentFormState == AccountFormStates.Editing && _IsCurrentFormModified && !ManageNavigation()) return;
            #region UnLock Current Ref
            // آزاد سازی مراجعه
            if (CurrentFormState == AccountFormStates.Editing) DBLayerIMS.Referrals.ChangeRefLock(_CurrentRefID, false);
            #endregion
            _IsCurrentFormModified = false;
            #endregion

            // بدست آوردن كد مراجعه ی قبلی بیمار جاری
            Int32? PrevRefID = DBLayerIMS.Referrals.GetPatRefNextOrPrevRefID(_CurrentRefID, false);
            // اگر مراجعه ی قبلی وجود داشت و همچنین با مراجعه ی جاری متفاوت بود
            // مراجعه ی جاری تغییر می كند و در فرم نمایش داده می شود
            if (PrevRefID != null && PrevRefID != _CurrentRefID)
            {
                CurrentRefID = Convert.ToInt32(PrevRefID);
                CurrentFormState = AccountFormStates.Viewing;
            }
            dgvServices.Focus();
        }
        #endregion

        #region btnNextRef_Click
        /// <summary>
        /// دكمه ی جابجایی مراجعه ی بیمار جاری به مراجعه ی بعدی آن بیمار
        /// </summary>
        private void btnNextReff_Click(object sender, EventArgs e)
        {
            btnNextReferral.Pulse(2);
            dgvServices.EndEdit();
            dgvServices.Focus();
            #region Check User Permission If _IsCurrentFormModified Is True
            // اگر مراجعه ویرایش شده بود
            if (CurrentFormState == AccountFormStates.Editing && _IsCurrentFormModified && !ManageNavigation()) return;
            #region UnLock Current Ref
            // آزاد سازی مراجعه
            if (CurrentFormState == AccountFormStates.Editing) DBLayerIMS.Referrals.ChangeRefLock(_CurrentRefID, false);
            #endregion
            _IsCurrentFormModified = false;
            #endregion

            // بدست آوردن كد مراجعه بعدی
            Int32? NextRefID = DBLayerIMS.Referrals.GetPatRefNextOrPrevRefID(_CurrentRefID, true);
            // اگر مراجعه بعدی وجود داشت و همچنین با مراجعه جاری متفاوت بود مراجعه جاری تغییر می كند
            if (NextRefID != null && NextRefID != _CurrentRefID)
            {
                CurrentRefID = Convert.ToInt32(NextRefID);
                CurrentFormState = AccountFormStates.Viewing;
            }
            dgvServices.Focus();
        }
        #endregion

        #endregion

        #region btnEditMode_Click
        private void btnEditMode_Click(object sender, EventArgs e)
        {
            if (CurrentFormState == AccountFormStates.Editing)
            {
                dgvServices.EndEdit();
                dgvTransaction.EndEdit();
                dgvCostDiscounts.EndEdit();
                if (_IsCurrentFormModified && !DBLayerIMS.Manager.Submit())
                {
                    const String ErrorMessage = "امكان ذخیره سازی تغییرات حساب در بانك اطلاعات ممكن نیست.\n" +
                        "موارد زیر را بررسی نمایید:\n" +
                        "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // آزاد سازی مراجعه
                DBLayerIMS.Referrals.ChangeRefLock(_CurrentRefID, false);
                CurrentFormState = AccountFormStates.Viewing;
                _IsCurrentFormModified = false;
            }
            else if (CurrentFormState == AccountFormStates.Viewing)
            {
                #region Check If Should Close Account By Time
                if (_ShouldCloseAccountByTime)
                {
                    if (_CurrentRefData.RegisterDate < DateTime.Now.AddDays(-1 * _DaysToCloseAccount))
                    {
                        PMBox.Show("تاریخ مراجعه جاری قبل از " + _DaysToCloseAccount + " روز قبل می باشد و قابلیت ویرایش ندارد.",
                            "محدودیت دسترسی!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                #endregion

                #region Check If Current Ref Is Lock
                // اینجا باید بررسی می شود كه مراجعه توسط كاربر دیگری ویرایش نگردد
                if (!DBLayerIMS.Referrals.CheckRefIsLock(_CurrentRefID)) return;
                // قفل كردن مراجعه
                DBLayerIMS.Referrals.ChangeRefLock(_CurrentRefID, true);
                #endregion

                CurrentFormState = AccountFormStates.Editing;
            }
        }
        #endregion

        #region btnFreeAccount_Click
        private void btnFreeAccount_Click(object sender, EventArgs e)
        {
            if (CurrentFormState != AccountFormStates.Viewing) return;
            DialogResult Result = PMBox.Show("آیا مایلید مراجعه جاری را از حالت قفل خارج نمایید؟", "پرسش؟",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Result != DialogResult.Yes) return;
            DBLayerIMS.Referrals.ChangeRefLock(_CurrentRefID, false);
        }
        #endregion

        #region btnExpand_Click
        private void btnExpand_Click(object sender, EventArgs e)
        {
            ((ButtonItem)sender).Expanded = true;
        }
        #endregion

        #region SliderPrintCount_ValueChanged
        private void SliderPrintCount_ValueChanged(object sender, EventArgs e)
        {
            sliderPrintCount.Text = "تعداد چاپ: " + sliderPrintCount.Value + " نسخه";
        }
        #endregion

        #region btnQuickBillPrint_Click
        private void btnQuickBillPrint_Click(object sender, EventArgs e)
        {
            if (((ButtonItem)sender).Name == btnQuickBillPrint1.Name)
                cboPrintTemplates.ComboBoxEx.SelectedIndex = 0;
            else cboPrintTemplates.ComboBoxEx.SelectedIndex = 1;
            btnPrint_Click(null, null);
        }
        #endregion

        #region btnPrint_Click
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (!ManagePrintBill()) return;
            BillPrintManager.RefBillPrint(_CurrentRefID,
                ((SP_SelectBillTemplateResult)cboPrintTemplates.ComboBoxEx.SelectedItem).ID,
                Convert.ToInt16(sliderPrintCount.Value));
        }
        #endregion

        #region btnPrintPreview_Click
        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            if (!ManagePrintBill()) return;
            BillPrintManager.RefBillPrintPreview(_CurrentRefID,
                ((SP_SelectBillTemplateResult)cboPrintTemplates.ComboBoxEx.SelectedItem).ID);
        }
        #endregion

        #region btnHelp_Click
        private void btnHelp_Click(object sender, EventArgs e)
        {
            SetControlsToolTipTexts();
        }
        #endregion

        #endregion

        #region dgv_Enter
        private void dgv_Enter(object sender, EventArgs e)
        {
            if (((Control)sender).Name == dgvServices.Name)
                dgvServices.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            else if (((Control)sender).Name == dgvTransaction.Name)
            {
                PanelTransaction.BorderStyle = BorderStyle.Fixed3D;
                dgvTransaction.BorderStyle = BorderStyle.FixedSingle;
            }
            else if (((Control)sender).Name == PanelCostDiscount.Name)
            {
                PanelCostDiscount.BorderStyle = BorderStyle.Fixed3D;
                dgvCostDiscounts.BorderStyle = BorderStyle.FixedSingle;
            }
        }
        #endregion

        #region dgv_Leave
        private void dgv_Leave(object sender, EventArgs e)
        {
            if (((Control)sender).Name == dgvServices.Name)
                dgvServices.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            else if (((Control)sender).Name == dgvTransaction.Name)
            {
                PanelTransaction.BorderStyle = BorderStyle.FixedSingle;
                dgvTransaction.BorderStyle = BorderStyle.Fixed3D;
            }
            else if (((Control)sender).Name == PanelCostDiscount.Name)
            {
                PanelCostDiscount.BorderStyle = BorderStyle.FixedSingle;
                dgvCostDiscounts.BorderStyle = BorderStyle.Fixed3D;
            }
        }
        #endregion

        #region Form Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            dgvServices.EndEdit();
            dgvTransaction.EndEdit();
            dgvCostDiscounts.EndEdit();
            if (CurrentFormState == AccountFormStates.Editing && _IsCurrentFormModified)
            {
                DialogResult Dr = PMBox.Show("آیا مایلید بدون ذخیره سازی تغییرات فرم حساب را ببندید؟",
                    "هشدار!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (Dr == DialogResult.No) { e.Cancel = true; return; }
            }
            Cursor.Current = Cursors.WaitCursor;
            Visible = false;
            if (CurrentFormState == AccountFormStates.Editing) DBLayerIMS.Referrals.ChangeRefLock(_CurrentRefID, false);
            Dispose();
            GC.Collect();
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
            #region Account Access (505)
            // مدیریت حساب مراجعات بیماران
            if (SecurityManager.GetCurrentUserPermission(505) == false)
            {
                PMBox.Show("كاربر جاری دسترسی به حساب بیماران تصویربرداری را ندارد!", "محدودیت دسترسی!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
            }
            #endregion

            #region Edit Account Service (5051)
            // تغییر اطلاعات خدمات.
            if (SecurityManager.GetCurrentUserPermission(5051) == false)
                dgvServices.Enabled = false;
            else
            {
                if (SecurityManager.GetCurrentUserPermission(50511) == false)
                    ColQuantity.Tag = "Hide";
                if (SecurityManager.GetCurrentUserPermission(50512) == false)
                    ColPatientPayablePrice.Tag = "Hide";
                if (SecurityManager.GetCurrentUserPermission(50513) == false)
                    ColIns1Price.Tag = "Hide";
                if (SecurityManager.GetCurrentUserPermission(50514) == false)
                    ColIns2Price.Tag = "Hide";
                if (SecurityManager.GetCurrentUserPermission(50515) == false)
                    ColIsIns1Cover.Tag = "Hide";
                if (SecurityManager.GetCurrentUserPermission(50516) == false)
                    ColIsIns2Cover.Tag = "Hide";
                if (SecurityManager.GetCurrentUserPermission(50517) == false)
                    btnIsActive.Visible = false;
            }
            #endregion

            #region Edit Transaction (5052)
            // تغییر اطلاعات تراكنش ها
            if (SecurityManager.GetCurrentUserPermission(5052) == false)
            {
                dgvTransaction.Enabled = false;
                btnPayMoney.Enabled = false;
                btnRecieveMoney.Enabled = false;
            }
            else
            {
                if (SecurityManager.GetCurrentUserPermission(50521) == false)
                    btnRecieveMoney.Enabled = false;
                if (SecurityManager.GetCurrentUserPermission(50522) == false)
                    _CanEditRecievesMoney = false;
                if (SecurityManager.GetCurrentUserPermission(50523) == false)
                    _CanRemoveRecieves = false;
                if (SecurityManager.GetCurrentUserPermission(50524) == false)
                    btnPayMoney.Enabled = false;
                if (SecurityManager.GetCurrentUserPermission(50525) == false)
                    _CanEditPayMoney = false;
                if (SecurityManager.GetCurrentUserPermission(50526) == false)
                    _CanRemovePays = false;
            }
            #endregion

            #region Edit Costs & Discounts (5053)
            // تغییر اطلاعات تخفیف ها و هزینه ها
            if (SecurityManager.GetCurrentUserPermission(5053) == false)
            {
                dgvCostDiscounts.Enabled = false;
                btnAddCost.Enabled = false;
                btnAddDiscount.Enabled = false;
                cboCostAndDiscountType.Enabled = false;
                txtCostAndDiscountValue.Enabled = false;
            }
            else
            {
                if (SecurityManager.GetCurrentUserPermission(50531) == false)
                    btnAddDiscount.Enabled = false;
                if (SecurityManager.GetCurrentUserPermission(50532) == false)
                    _CanEditDiscounts = false;
                if (SecurityManager.GetCurrentUserPermission(50533) == false)
                    _CanRemoveDiscounts = false;
                if (SecurityManager.GetCurrentUserPermission(50534) == false)
                    btnAddCost.Enabled = false;
                if (SecurityManager.GetCurrentUserPermission(50535) == false)
                    _CanEditCosts = false;
                if (SecurityManager.GetCurrentUserPermission(50536) == false)
                    _CanRemoveCosts = false;
            }
            #endregion

            #region Can Unlock Accounts (5054)
            // امكان آزاد سازی حساب بیمار
            if (SecurityManager.GetCurrentUserPermission(5054) == false)
                btnEditMode.SubItems.Remove(btnFreeAccount);
            #endregion

            return true;
        }
        #endregion

        #region Boolean ReadCurrentUserSettings()
        /// <summary>
        /// تابع اعمال تنظیمات فرم
        /// </summary>
        /// <returns>صحت اعمال تنظیمات</returns>
        private Boolean ReadCurrentUserSettings()
        {
            List<UsersSetting> SettingList = DBLayerIMS.Settings.CurrentUserSettingsFullList;
            if (SettingList == null) return false;
            #region 503
            // مشاهده خدمات در فرم حساب.
            List<UsersSetting> Setting503 = SettingList.Where(Data => Data.SettingIX == 503).ToList();
            if (Setting503.Count > 0 && Setting503.First().Boolean == false)
            {
                dgvServices.Visible = false;
                PanelFormBottom.Dock = DockStyle.Fill;
            }
            #endregion

            #region 504
            // مشاهده دریافت ها و بازپرداخت ها در فرم حساب.
            List<UsersSetting> Setting504 = SettingList.Where(Data => Data.SettingIX == 504).ToList();
            if (Setting504.Count > 0 && Setting504.First().Boolean == false)
            {
                LayoutPanelBottom.Controls.Remove(PanelTransaction);
                LayoutPanelBottom.ColumnStyles[0].SizeType = SizeType.Percent;
                LayoutPanelBottom.ColumnStyles[1].SizeType = SizeType.Percent;
                LayoutPanelBottom.ColumnStyles[1].Width = 0;
                LayoutPanelBottom.ColumnStyles[0].Width = 100;
            }
            #endregion

            #region 505
            // مشاهده تخفیف ها و هزینه ها در فرم حساب.
            List<UsersSetting> Setting505 = SettingList.Where(Data => Data.SettingIX == 505).ToList();
            if (Setting505.Count > 0 && Setting505.First().Boolean == false)
            {
                LayoutPanelBottom.Controls.Remove(PanelCostDiscount);
                LayoutPanelBottom.ColumnStyles[0].SizeType = SizeType.Percent;
                LayoutPanelBottom.ColumnStyles[1].SizeType = SizeType.Percent;
                LayoutPanelBottom.ColumnStyles[0].Width = 100;
                LayoutPanelBottom.ColumnStyles[1].Width = 0;
            }
            #endregion

            #region Check 503 , 504 & 505
            // اگر تراكنش ها و تخفیف ها و هزینه ها مخفی باشد ولی خدمات 
            // مخفی نباشد ، جدول خدمات كل صفحه را پوشش خواهد داد
            if (Setting504.Count > 0 && Setting504.First().Boolean == false &&
                Setting505.Count > 0 && Setting505.First().Boolean == false)
            {
                PanelFormBottom.Visible = false;
                dgvServices.Dock = DockStyle.Fill;
            }
            #endregion

            #region 508
            // حساب هایی كه تاریخ مراجعه آنها برای بیش از تاریخی مشخص است بسته شوند.
            List<UsersSetting> Setting508 = SettingList.Where(Data => Data.SettingIX == 508).ToList();
            if (Setting508.Count > 0 && Setting508.First().Boolean == true) _ShouldCloseAccountByTime = true;
            #endregion

            #region 509
            // تعداد روزهای مشخص شده برای بستن حساب هایی با تاریخ مراجعه قبل از آن.
            if (_ShouldCloseAccountByTime)
            {
                List<UsersSetting> Setting509 = SettingList.Where(Data => Data.SettingIX == 509).ToList();
                if (Setting509.Count > 0 && Setting509.First().Value != null)
                    _DaysToCloseAccount = Convert.ToInt32(Setting509.First().Value);
                else _DaysToCloseAccount = 90;
            }
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

            #region btnPrevPatient
            String TooltipText = ToolTipManager.GetText("btnPatPrevPatient", "IMS");
            FormToolTip.SetSuperTooltip(btnPrevPatient, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnNextPatient
            TooltipText = ToolTipManager.GetText("btnPatNextPatient", "IMS");
            FormToolTip.SetSuperTooltip(btnNextPatient, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnPrevReferral
            TooltipText = ToolTipManager.GetText("btnPrevReferral", "IMS");
            FormToolTip.SetSuperTooltip(btnPrevReferral, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnNextReferral
            TooltipText = ToolTipManager.GetText("btnNextReferral", "IMS");
            FormToolTip.SetSuperTooltip(btnNextReferral, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnEditMode
            TooltipText = ToolTipManager.GetText("btnAccountEditMode", "IMS");
            FormToolTip.SetSuperTooltip(btnEditMode, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnFreeAccount
            TooltipText = ToolTipManager.GetText("btnFreeAccount", "IMS");
            FormToolTip.SetSuperTooltip(btnFreeAccount, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnInsDetails
            TooltipText = ToolTipManager.GetText("btnAccountInsDetails", "IMS");
            FormToolTip.SetSuperTooltip(btnInsDetails, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnAccountTotalData
            TooltipText = ToolTipManager.GetText("btnAccountTotalData", "IMS");
            FormToolTip.SetSuperTooltip(btnAccountTotalData, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region lblTotalPayableValue
            TooltipText = ToolTipManager.GetText("lblTotalPayableValue", "IMS");
            FormToolTip.SetSuperTooltip(lblTotalPayable, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            FormToolTip.SetSuperTooltip(lblTotalPayableValue, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region lblTotalPayedValue
            TooltipText = ToolTipManager.GetText("lblTotalPayedValue", "IMS");
            FormToolTip.SetSuperTooltip(lblTotalPayed, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            FormToolTip.SetSuperTooltip(lblTotalPayedValue, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region lblRecievableValue
            TooltipText = ToolTipManager.GetText("lblRecievableValue", "IMS");
            FormToolTip.SetSuperTooltip(lblRecievable, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            FormToolTip.SetSuperTooltip(lblRecievableValue, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
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

            #region btnRecieveMoney
            TooltipText = ToolTipManager.GetText("btnAccountRecieveMoney", "IMS");
            FormToolTip.SetSuperTooltip(btnRecieveMoney, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnPayMoney
            TooltipText = ToolTipManager.GetText("btnAccountPayMoney", "IMS");
            FormToolTip.SetSuperTooltip(btnPayMoney, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnAddDiscount
            TooltipText = ToolTipManager.GetText("btnAddAccountDiscount", "IMS");
            FormToolTip.SetSuperTooltip(btnAddDiscount, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnAddCost
            TooltipText = ToolTipManager.GetText("btnAddAccountCost", "IMS");
            FormToolTip.SetSuperTooltip(btnAddCost, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

        }
        #endregion

        #region Boolean FillDataSources()
        /// <summary>
        /// تابع خواندن اطلاعات پایه فرم
        /// </summary>
        /// <returns>صحت خواندن اطلاعات</returns>
        private Boolean FillDataSources()
        {
            #region ColTransactionCashiers
            ColTransactionCashiers.DataSource = Negar.DBLayerPMS.Security.UsersList.ToList();
            ColTransactionCashiers.DisplayMember = "FullName";
            ColTransactionCashiers.ValueMember = "ID";
            #endregion

            #region ColCostDiscountCashiers
            ColCostDiscountCashiers.DataSource = Negar.DBLayerPMS.Security.UsersList.ToList();
            ColCostDiscountCashiers.DisplayMember = "FullName";
            ColCostDiscountCashiers.ValueMember = "ID";
            #endregion

            #region ColCostAndDiscountType
            List<CostsAndDiscountsType> TempCDTypes = DBLayerIMS.Account.CostAndDiscountFullList;
            if (TempCDTypes == null) return false;
            ColCostAndDiscountType.DataSource = TempCDTypes.ToList();
            ColCostAndDiscountType.DataPropertyName = "CostIXOrDiscountIX";
            ColCostAndDiscountType.DisplayMember = "Name";
            ColCostAndDiscountType.ValueMember = "ID";
            #endregion

            #region cboCostAndDiscountType
            List<CostsAndDiscountsType> CorrectCDDataSource = TempCDTypes.Where(Data => Data.IsActive)
                .OrderBy(Data => Data.Name).ToList();

            if (!btnAddCost.Enabled) CorrectCDDataSource = CorrectCDDataSource.Where(Data => !Data.IsCost &&
                Data.CostsAndDiscountsUsersExcludes.
                Where(MyData => MyData.UserIX == SecurityManager.CurrentUserID).Count() == 0).ToList();
            if (!btnAddDiscount.Enabled) CorrectCDDataSource = CorrectCDDataSource.Where(Data => Data.IsCost).ToList();
            IQueryable<Int16> ExcludedCD = DBLayerIMS.Account.GetUserExcludedCD(SecurityManager.CurrentUserID);
            if (ExcludedCD == null) return false;
            for (Int32 i = CorrectCDDataSource.Count - 1; i >= 0; i--)
                if (ExcludedCD.Contains(CorrectCDDataSource[i].ID)) CorrectCDDataSource.Remove(CorrectCDDataSource[i]);
            if (CorrectCDDataSource.Count == 0)
            {
                if (PanelCostDiscount.Contains(cboCostAndDiscountType))
                    PanelCostDiscount.Controls.Remove(cboCostAndDiscountType);
                if (PanelCostDiscount.Contains(lblType)) PanelCostDiscount.Controls.Remove(lblType);
                if (PanelCostDiscount.Contains(lblValue)) PanelCostDiscount.Controls.Remove(lblValue);
                if (PanelCostDiscount.Contains(txtCostAndDiscountValue))
                    PanelCostDiscount.Controls.Remove(txtCostAndDiscountValue);
                if (PanelCostDiscount.Contains(lblRial)) PanelCostDiscount.Controls.Remove(lblRial);
                if (PanelCostDiscount.Contains(lblCDPercent)) PanelCostDiscount.Controls.Remove(lblCDPercent);
                if (PanelCostDiscount.Contains(txtCDPercent)) PanelCostDiscount.Controls.Remove(txtCDPercent);
            }
            else
            {
                cboCostAndDiscountType.DataSource = CorrectCDDataSource.ToList();
                cboCostAndDiscountType.DisplayMember = "Name";
                cboCostAndDiscountType.ValueMember = "ID";
            }
            #endregion

            #region Bill Templates
            if (BillPrintManager.CurrentUserBillTemplatesList.Count == 0)
            {
                ribbonBarOrders.Items.Remove(btnPrint);
                ribbonBarOrders.Items.Remove(iContainerQuickBillPrint);
            }
            else
            {
                cboPrintTemplates.ComboBoxEx.DrawMode = DrawMode.Normal;
                cboPrintTemplates.ComboBoxEx.FlatStyle = FlatStyle.Standard;
                cboPrintTemplates.ComboBoxEx.DisplayMember = "Name";
                cboPrintTemplates.ComboBoxEx.ValueMember = "ID";
                foreach (SP_SelectBillTemplateResult BillTemplate in BillPrintManager.CurrentUserBillTemplatesList)
                    cboPrintTemplates.ComboBoxEx.Items.Add(BillTemplate);
                cboPrintTemplates.ComboBoxEx.SelectedIndex = 0;
                if (BillPrintManager.CurrentUserBillTemplatesList.Count == 1)
                {
                    ribbonBarOrders.Items.Remove(iContainerQuickBillPrint);
                    btnPrintSelectedBill.Visible = false;
                }
                else
                {
                    btnPrint.Text = "قبوض";
                    btnPrint.Shortcuts.Clear();
                    btnPrint.AutoExpandOnClick = true;
                    btnPrint.Click -= btnPrint_Click;
                    btnPrint.ImagePaddingHorizontal = 10;
                    btnQuickBillPrint1.Text = BillPrintManager.CurrentUserBillTemplatesList[0].Name;
                    btnQuickBillPrint2.Text = BillPrintManager.CurrentUserBillTemplatesList[1].Name;
                    btnPrintSelectedBill.Shortcuts.Add(eShortcut.F8);
                }
            }
            #endregion

            return true;
        }
        #endregion

        // OOOOOOOO Change Form State Methods: OOOOOOOO

        #region void ChangeToViewState()
        /// <summary>
        /// تغییر حالت کنترل های فرم به حالت نمایش
        /// </summary>
        private void ChangeToViewState()
        {
            Text = "بیماران - مراجعات - حساب مراجعات تصویربرداری - نمایش حساب مراجعه بیمار - كاربر جاری: " +
                Negar.DBLayerPMS.Security.UsersList.
                    Where(Data => Data.ID == SecurityManager.CurrentUserID).Select(Data => Data.FullName).First();
            btnEditMode.Text = "ویرایش\n(F3)";
            btnEditMode.Image = Resources.EditLarge;
            btnEditMode.ShowSubItems = true;
            ribbonBarOrders.InvalidateLayout();
            ribbonBarOrders.Invalidate();

            #region dgvServices
            dgvServices.ReadOnly = true;
            cmsdgvServices.Enabled = false;
            #endregion

            #region dgvTransactions
            cmsdgvTransactions.Enabled = false;
            btnRecieveMoney.Visible = false;
            btnPayMoney.Visible = false;
            dgvTransaction.Dock = DockStyle.Fill;
            #endregion

            #region dgvCostDiscounts
            dgvCostDiscounts.Dock = DockStyle.Fill;
            cmsdgvCostOrDiscount.Enabled = false;
            btnAddCost.Visible = false;
            btnAddDiscount.Visible = false;
            cboCostAndDiscountType.Visible = false;
            txtCostAndDiscountValue.Visible = false;
            lblCDPercent.Visible = false;
            txtCDPercent.Visible = false;
            lblType.Visible = false;
            lblValue.Visible = false;
            lblRial.Visible = false;
            #endregion

            _IsCurrentFormModified = false;
        }
        #endregion

        #region void ChangeToEditState()
        /// <summary>
        /// تغییر حالت کنترل های فرم به حالت ویرایش
        /// </summary>
        private void ChangeToEditState()
        {
            Text = "بیماران - مراجعات - حساب مراجعات تصویربرداری - ویرایش حساب مراجعه بیمار - كاربر جاری: " +
                Negar.DBLayerPMS.Security.UsersList.
                    Where(Data => Data.ID == SecurityManager.CurrentUserID).Select(Data => Data.FullName).First();
            btnEditMode.Text = "ثبت\n(F3)";
            btnEditMode.Image = Resources.Apply;
            btnEditMode.ShowSubItems = false;
            ribbonBarOrders.InvalidateLayout();
            ribbonBarOrders.Invalidate();

            #region dgvServices
            dgvServices.ReadOnly = false;
            cmsdgvServices.Enabled = true;
            foreach (DataGridViewRow row in dgvServices.Rows)
                foreach (DataGridViewCell cell in row.Cells) SetServiceCellSettings(row.Index, cell.ColumnIndex);
            #endregion

            #region dgvTransaction
            dgvTransaction.Dock = DockStyle.None;
            dgvTransaction.Width = PanelTransaction.Width;
            dgvTransaction.Height = PanelTransaction.Height - 115;
            dgvTransaction.Anchor = (AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            cmsdgvTransactions.Enabled = true;
            btnRecieveMoney.Visible = true;
            btnPayMoney.Visible = true;
            #endregion

            #region dgvCostDiscounts
            dgvCostDiscounts.Dock = DockStyle.None;
            dgvCostDiscounts.Width = PanelCostDiscount.Width;
            dgvCostDiscounts.Height = PanelCostDiscount.Height - 115;
            dgvCostDiscounts.Anchor = (AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            cmsdgvCostOrDiscount.Visible = true;
            btnAddCost.Visible = true;
            btnAddDiscount.Visible = true;
            cboCostAndDiscountType.Visible = true;
            txtCostAndDiscountValue.Visible = true;
            lblCDPercent.Visible = true;
            txtCDPercent.Visible = true;
            lblType.Visible = true;
            lblValue.Visible = true;
            lblRial.Visible = true;
            #endregion

            btnRecieveMoney.Focus();
            _IsCurrentFormModified = false;
        }
        #endregion

        // OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO

        #region Boolean FillPatDataByPatID(Int32 PatientListID)
        /// <summary>
        /// پركردن اطلاعات بیمار ومراجعه فرم
        /// </summary>
        /// <param name="PatientListID">كلید مراجعه</param>
        /// <returns>صحت انجام</returns>
        private Boolean FillPatDataByPatID(Int32 PatientListID)
        {
            Negar.DBLayerPMS.Manager.ReleaseCachedFiles();
            DBLayerIMS.Manager.ReleaseCachedFiles();
            PatList PatientData = Negar.DBLayerPMS.Patients.GetPatFullDataByPatListID(PatientListID);
            if (PatientData == null) return false;
            _CurrentPatientData = PatientData;
            txtPatientID.TextBox.Text = _CurrentPatientData.PatientID;
            if (String.IsNullOrEmpty(_CurrentPatientData.FirstName))
                lblPatientFullName.Text = _CurrentPatientData.LastName;
            else lblPatientFullName.Text = _CurrentPatientData.FirstName + " " + _CurrentPatientData.LastName;
            ribbonBarOrders.InvalidateLayout();
            ribbonBarOrders.Invalidate();
            return true;
        }
        #endregion

        #region Boolean FillRefDataByRefID(Int32 RefID)
        /// <summary>
        /// تابع به روز رسانی اطلاعات مراجعه ی فرم بر اساس كلید مراجعه
        /// </summary>
        /// <param name="RefID">كلید مراجعه</param>
        /// <returns>صحت انجام كار</returns>
        private Boolean FillRefDataByRefID(Int32 RefID)
        {
            try
            {
                _CurrentRefData = DBLayerIMS.Manager.DBML.RefLists.Where(Data => Data.ID == RefID).First();
                IQueryable<RefService> TempRefServices = DBLayerIMS.Manager.DBML.
                    RefServices.Where(Result => Result.ReferralIX == RefID);
                IQueryable<RefTransaction> TempRefTransaction = DBLayerIMS.Manager.DBML.
                    RefTransactions.Where(Result => Result.ReferralIX == RefID);
                IQueryable<RefCostsAndDiscount> TempRefCostsDiscounts = DBLayerIMS.Manager.DBML
                    .RefCostsAndDiscounts.Where(Result => Result.ReferralIX == RefID);
                DBLayerIMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, _CurrentRefData);
                DBLayerIMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, TempRefServices);
                _CurrentRefServices = TempRefServices.ToList();
                DBLayerIMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, TempRefTransaction);
                _CurrentRefTransaction = TempRefTransaction.ToList();
                DBLayerIMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, TempRefCostsDiscounts);
                _CurrentRefCostsDiscounts = TempRefCostsDiscounts.ToList();
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان خواندن اطلاعات حساب مراجعه بیمار از بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Account Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion

            #region RegDate
            PersianDate PersianRegDate = PersianDateConverter.ToPersianDate(_CurrentRefData.RegisterDate);
            lblRefDate.Text = PersianRegDate.Hour + ":" + PersianRegDate.Minute + ":" + PersianRegDate.Second + " - " +
                PersianRegDate.Year + "/" + PersianRegDate.Month + "/" + PersianRegDate.Day;
            #endregion

            #region Insurance TextBox
            txtIns1Name.Text = DBLayerIMS.Insurance.InsFullList.Where(Data => Data.ID == _CurrentRefData.Ins1IX).
                Select(Data => Data.Name).First();
            txtIns2Name.Text = DBLayerIMS.Insurance.InsFullList.Where(Data => Data.ID == _CurrentRefData.Ins2IX).
                Select(Data => Data.Name).First();
            #endregion

            dgvServices.DataSource = _CurrentRefServices.ToList();
            dgvServices.Refresh();
            dgvTransaction.DataSource = _CurrentRefTransaction.ToList();
            dgvTransaction.Refresh();
            dgvCostDiscounts.DataSource = _CurrentRefCostsDiscounts.ToList();
            dgvCostDiscounts.Refresh();
            ReCalculateRefPrices();
            return true;
        }
        #endregion

        #region void ReCalculateRefPrices()
        /// <summary>
        /// تابعی برای محاسبه مجدد قیمت های مراجعه جاری بر اساس اطلاعات فرم
        /// </summary>
        private void ReCalculateRefPrices()
        {
            #region Calculate Total Cost & Discount

            #region Calculate
            Int32 TotalRefCosts = 0;
            Int32 TotalRefDiscounts = 0;
            foreach (RefCostsAndDiscount RefCD in _CurrentRefCostsDiscounts)
            {
                if (RefCD.CostsAndDiscountsType.IsCost) TotalRefCosts += RefCD.Value;
                else TotalRefDiscounts = TotalRefDiscounts + RefCD.Value;
            }
            #endregion

            #region Set Values
            lblTotalCostsValue.Text = String.Format("{0:N0}", TotalRefCosts) + " ریال";
            lblTotalDiscountsValue.Text = String.Format("{0:N0}", TotalRefDiscounts) + " ریال";
            #endregion

            #endregion

            #region Calculate Ins1 & Ins2 Prices

            #region Calculate
            Int32 Ins1PriceTotal = 0;
            Int32 Ins1PartTotal = 0;
            Int32 Ins2PriceTotal = 0;
            Int32 Ins2PartTotal = 0;
            foreach (RefService service in _CurrentRefServices)
                if (service.IsActive)
                {
                    if (service.IsIns1Cover != null && service.IsIns1Cover.Value)
                    {
                        if (service.Ins1Price != null) Ins1PriceTotal += (service.Ins1Price.Value * service.Quantity);
                        if (service.Ins1PartPrice != null) Ins1PartTotal += (service.Ins1PartPrice.Value * service.Quantity);
                    }
                    if (service.IsIns2Cover != null && service.IsIns2Cover.Value)
                    {
                        if (service.Ins2Price != null) Ins2PriceTotal += (service.Ins2Price.Value * service.Quantity);
                        if (service.Ins2PartPrice != null) Ins2PartTotal += (service.Ins2PartPrice.Value * service.Quantity);
                    }
                }
            #endregion

            #region Set Values
            lblTotalIns1PriceValue.Text = String.Format("{0:N0}", Ins1PriceTotal) + " ریال";
            lblTotalIns1PartValue.Text = String.Format("{0:N0}", Ins1PartTotal) + " ریال";
            lblTotalIns1PatientPartValue.Text = String.Format("{0:N0}", (Ins1PriceTotal - Ins1PartTotal)) + " ریال";

            lblTotalIns2PriceValue.Text = String.Format("{0:N0}", Ins2PriceTotal) + " ریال";
            lblTotalIns2PartValue.Text = String.Format("{0:N0}", Ins2PartTotal) + " ریال";
            #endregion

            #endregion

            #region Calculate Ref Totals

            #region Total Patient Payed
            // مجموع پرداختی بیمار
            Int32 TotalRefPayed = 0;
            foreach (RefTransaction transaction in _CurrentRefTransaction)
                if (transaction.IsActive) TotalRefPayed = TotalRefPayed + transaction.Value;
            #endregion

            #region Total Service Payable
            // مجموع پرداختنی خدمات مراجعه
            Int32 TotalRefServicesPayable = 0;
            foreach (RefService service in _CurrentRefServices)
                if (service.IsActive)
                    TotalRefServicesPayable = TotalRefServicesPayable + (service.PatientPayablePrice * service.Quantity);
            #endregion

            #region Total Ref Payable
            // مجموع پرداختنی مراجعه بیمار
            Int32 TotalRefPayable = TotalRefServicesPayable + TotalRefCosts - TotalRefDiscounts;
            #endregion

            // پرداختنی مراجعه
            lblTotalPayableValue.Text = String.Format("{0:N0}", TotalRefPayable) + " ریال";
            // پرداختی مراجعه
            lblTotalPayedValue.Text = String.Format("{0:N0}", TotalRefPayed) + " ریال";
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
            _CurrentRefRecievableValue = TotalRefPayable - TotalRefPayed;
            lblRecievableValue.Text = String.Format("{0:N0}", Math.Abs(TotalRefPayable - TotalRefPayed)) + " ریال";
            #endregion
        }
        #endregion

        #region Boolean ManageNavigation()
        /// <summary>
        /// تابعی برای مدیریت جابجایی بیمار در صورتی كه مقادیر فرم تغییر كرده باشد
        /// </summary>
        /// <returns>تعیین دریافت مجوز كاربر</returns>
        private Boolean ManageNavigation()
        {
            DialogResult Dr = PMBox.Show("بدون ذخیره سازی تغییرات ، اطلاعات وارد شده از دست می رود.\n" +
                "آیا مایلید قبل از تغییر ، اطلاعات مالی وارد شده ثبت گردند؟", "هشدار!",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3);

            #region YES - Save And Continue
            // در صورتی كه كاربر دكمه ی آری را فشار دهد ، پس از ذخیره سازی ، مقدار صحیح باز گردانده میشود
            if (Dr == DialogResult.Yes)
            {
                if (!DBLayerIMS.Manager.Submit())
                {
                    const String ErrorMessage = "امكان ثبت اطلاعات مالی مراجعه در بانك اطلاعات ممكن نیست.\n" +
                        "موارد زیر را بررسی نمایید:\n" +
                        "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }
            #endregion

            #region NO - Don't Save And Continue
            // در صورتی كه كاربر دكمه ی خیر را فشار دهد ، بدون ذخیره سازی ، مقدار صحیح باز گردانده می شود.
            if (Dr == DialogResult.No)
            {
                try
                {
                    DBLayerIMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, _CurrentRefData);
                    DBLayerIMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, _CurrentRefServices);
                    DBLayerIMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, _CurrentRefTransaction);
                    DBLayerIMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, _CurrentRefCostsDiscounts);
                }
                #region Catch
                catch { return true; }
                #endregion
                return true;
            }
            #endregion

            // در صورتی كه كاربر دكمه ی انصراف را فشار دهد ، بدون ذخیره سازی ، مقدار غلط باز گردانده می شود.
            return false;
        }
        #endregion

        #region Boolean ManagePrintBill()
        /// <summary>
        /// تابعی برای مدیریت چاپ قبض در حالت ویرایش بیماران
        /// </summary>
        /// <returns>امكان چاپ</returns>
        private Boolean ManagePrintBill()
        {
            if (CurrentFormState != AccountFormStates.Editing) return true;
            // اگر مراجعه ویرایش شده بود
            if (_IsCurrentFormModified && !DBLayerIMS.Manager.Submit())
            {
                const String ErrorMessage = "ثبت اطلاعات مالی مراجعه ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
            }
            _IsCurrentFormModified = false;
            CurrentFormState = AccountFormStates.Viewing;
            // آزاد سازی مراجعه
            return DBLayerIMS.Referrals.ChangeRefLock(_CurrentRefID, false);
        }
        #endregion

        #endregion

    }
}