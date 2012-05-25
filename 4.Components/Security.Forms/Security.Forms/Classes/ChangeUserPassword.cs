#region using
using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;
using Negar;
using Negar.DBLayerPMS.DataLayer;
using Negar.Security.Classes;
using DevComponents.DotNetBar;
using Application = System.Windows.Forms.Application;
#endregion

namespace Negar.Security.Classes
{
    /// <summary>
    /// فرم بازنویسی كلمه عبور كاربر
    /// </summary>
    public partial class ChangeUserPassword : Balloon
    {

        #region Fields

        #region readonly Int16 _CurrentUserID
        /// <summary>
        /// كلید كاربر جاری
        /// </summary>
        private readonly Int16 _CurrentUserID;
        #endregion

        #region readonly Boolean _SubmitAfterAccept
        /// <summary>
        /// تعیین اعمال تغییر كلمه عبور به صورت مستقیم در بانك
        /// </summary>
        private readonly Boolean _SubmitAfterAccept;
        #endregion

        #region readonly Boolean _CheckOldPass
        /// <summary>
        /// تعیین آنكه كاربر باید رمز عبور قبلی را وارد نماید یا خیر
        /// </summary>
        private readonly Boolean _CheckOldPass;
        #endregion

        #region UsersList _CurrentUsersData
        /// <summary>
        /// اطلاعات كاربر جاری برای ذخیره سازی یا مقایسه اطلاعات
        /// </summary>
        private UsersList _CurrentUsersData;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// فراخوانی فرمی برای تغییر كلمه عبور یك كاربر
        /// </summary>
        /// <param name="UserID">كلید كاربر</param>
        /// <param name="SubmitAfterAccept">آیا پس از تایید كاربر تغییرات در بانك اطلاعات ذخیره شود یا خیر</param>
        /// <param name="CheckOldPass">آیا رمز عبور قبلی مورد سوال قرار گیرد یا خیر</param>
        public ChangeUserPassword(Int16 UserID, Boolean SubmitAfterAccept, Boolean CheckOldPass)
        {
            InitializeComponent();
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("En-Us"));
            _CurrentUserID = UserID;
            _SubmitAfterAccept = SubmitAfterAccept;
            _CheckOldPass = CheckOldPass;
            #region Set Form Controls Settings
            if (!CheckOldPass)
            {
                // اگر نیازی به بررسی كلمه عبور قبلی كاربر نباشد
                // كنترل های كلمه عبور قبلی مخفی شده و سایر كنترل های جابجا می شود
                lblOldPass.Hide();
                txtOldPass.Hide();
                lbl2.Top = lbl1.Top;
                txtPass2.Top = txtPass1.Top;
                lbl1.Top = lblOldPass.Top;
                txtPass1.Top = txtOldPass.Top;
            }
            #endregion
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Controls_Enter
        private void Controls_Enter(object sender, EventArgs e)
        {
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("En-Us"));
        }
        #endregion

        #region txtPass2_Validating
        /// <summary>
        /// روالی برای بررسی یكسان بودن كلمات عبور وارد شده
        /// </summary>
        private void txtPass2_Validating(object sender, CancelEventArgs e)
        {
            if (!txtPass1.Text.Equals(txtPass2.Text))
            {
                FormErrorProvider.SetError(txtPass1, "عبارات وارد شده با یكدیگر یكسان نیستند! لطفاً مجددا امتحان نمایید!");
                FormErrorProvider.SetError(txtPass2, "عبارات وارد شده با یكدیگر یكسان نیستند! لطفاً مجددا امتحان نمایید!");
                txtPass1.Focus();
                return;
            }
            FormErrorProvider.SetError(txtPass1, "");
            FormErrorProvider.SetError(txtPass2, "");
        }
        #endregion

        #region btnAccept_Click
        /// <summary>
        /// روال مدیریت دكمه انصراف
        /// </summary>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            #region Validation
            if (!txtPass1.Text.Trim().Equals(txtPass2.Text.Trim()))
            {
                PMBox.Show("عبارات وارد شده با یكدیگر یكسان نیستند! لطفاً مجددا امتحان نمایید!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPass1.Focus();
                return;
            }
            #endregion

            #region Fill Current User Data
            // اگر فرم در حالت مقایسه رمز عبور وارد شده با رمز قبلی باشد یا
            // پس از ثبت اطلاعات ، فرم باید اطلاعات جدید را مستقیماً به بانك اعمال نماید و
            // اطلاعات قبلاً خوانده نشده باشد این بخش فراخوانی می شود
            if ((_SubmitAfterAccept || _CheckOldPass) && _CurrentUsersData == null)
            {
                _CurrentUsersData = DBLayerPMS.Security.GetUserData(_CurrentUserID);
                if (_CurrentUsersData == null) DialogResult = DialogResult.Cancel;
            }
            #endregion

            #region Check User Old Password
            if (_CheckOldPass &&
                Cryptographer.EncryptString(txtOldPass.Text, "AftabClearPassword") != _CurrentUsersData.Password)
            {
                PMBox.Show("رمز عبور وارد شده ، با رمز عبور قبلی یكسان نیست!\nمجدداً تلاش نمایید!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtOldPass.Focus();
                return;
            }
            #endregion

            #region Submit New Password If Required
            if (_SubmitAfterAccept)
            {
                //UsersList CurrentUser;
                //try
                //{
                //    CurrentUser = DBLayerPMS.Manager.DBML.UsersLists.
                //        Where(Data => Data.ID == SecurityManager.CurrentUserID).First();
                //}
                //#region Catch
                //catch (Exception Ex)
                //{
                //    const String ErrorMessage =
                //       "خواندن اطلاعات كاربران از بانك اطلاعات ممكن نیست.\n" +
                //       "موارد زیر را بررسی نمایید:\n" +
                //       "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                //    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    LogManager.SaveLogEntry("Arash" , "Security Forms" , "Sepehr", "Security Settings", 
                //        Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                //    return;
                //}
                //#endregion
                _CurrentUsersData.Password = Cryptographer.EncryptString(txtPass1.Text.Trim(), "AftabClearPassword");
                if (!DBLayerPMS.Manager.Submit())
                {
                    const String ErrorMessage =
                        "امكان تغییر كلمه عبور كاربر انتخاب شده در بانك اطلاعات ممكن نیست.\n" +
                        "موارد زیر را بررسی نمایید:\n" +
                        "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟\n" +
                        "2. آیا بانك اطلاعاتی آسیب ندیده است؟\n";
                    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            #endregion

            DialogResult = DialogResult.OK;
        }
        #endregion

        #region Form_Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.Cancel) Dispose();
        }
        #endregion

        #endregion

        #region Methods

        #endregion

    }
}