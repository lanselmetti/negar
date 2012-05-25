#region using

using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Negar;
using Sepehr.DBLayerIMS.DataLayer;

#endregion

namespace Sepehr.Forms.Cash
{
    /// <summary>
    /// فرم بستن و بازكردن صندوق ها
    /// </summary>
    internal partial class frmCashInOut : Form
    {

        #region Fields

        #region readonly Int32  _CurrentCashLogID
        /// <summary>
        /// كلید صندوق جاری
        /// </summary>
        private readonly Int32 _CurrentCashLogID;
        #endregion

        #region readonly Boolean _IsInput
        /// <summary>
        /// تعیین ورود پول یا خروج پول
        /// </summary>
        private readonly Boolean _IsInput;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmCashInOut(Int32 CashLogID, Boolean IsInput)
        {
            Cursor.Current = Cursors.WaitCursor;
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("Fa-Ir"));
            InitializeComponent();
            _CurrentCashLogID = CashLogID;
            _IsInput = IsInput;
            if (!FillFormControls()) { Close(); return; }
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
        }
        #endregion

        #region btnApply_Click
        private void btnApply_Click(object sender, EventArgs e)
        {
            CashInputOutput NewItem = new CashInputOutput();
            NewItem.CashLogIX = _CurrentCashLogID;
            NewItem.CashierIX = SecurityManager.CurrentUserID;
            NewItem.IsInput = _IsInput;
            if (_IsInput) NewItem.Value = txtValue.Value;
            else NewItem.Value = txtValue.Value * -1;
            DateTime? CurrentServerDate = Negar.DBLayerPMS.Manager.ServerCurrentDateTime;
            if (CurrentServerDate == null) return;
            NewItem.OccuredDate = CurrentServerDate.Value;
            NewItem.Description = txtDescription.Text.Trim().Normalize();
            DBLayerIMS.Manager.DBML.CashInputOutputs.InsertOnSubmit(NewItem);
            if (!DBLayerIMS.Manager.Submit())
            {
                const String ErrorMessage = "امكان ثبت ورود یا خروج پول صندوق وجود در بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Form Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            Dispose();
            Cursor.Current = Cursors.Default;
        }
        #endregion

        #endregion

        #region Methods

        #region Boolean FillFormControls()
        /// <summary>
        /// تابع تكمیل اطلاعات فرم
        /// </summary>
        /// <returns>صحت انجام كار</returns>
        private Boolean FillFormControls()
        {
            txtCashier.Text = Negar.DBLayerPMS.Security.UsersList.
                    Where(Data => Data.ID == SecurityManager.CurrentUserID).Select(Data => Data.FullName).First();
            try
            {
                SP_SelectCashesStatusResult CashesStatus = DBLayerIMS.Manager.
                    DBML.SP_SelectCashesStatus(SecurityManager.CurrentUserID).
                    Where(Data => Data.CashLogID == _CurrentCashLogID).First();
                txtCash.Text = CashesStatus.Name;

                #region Close Cash
                if (_IsInput)
                {
                    lblTitle.Text = "ورود پول به صندوق";
                    btnApply.Text = "ورود پول\n(F8)";
                }
                #endregion

                #region Open Cash
                else
                {
                    lblTitle.Text = "خروج پول از صندوق";
                    btnApply.Text = "خروج پول\n(F8)";
                }
                #endregion
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان خواندن اطلاعات صندوق انتخاب شده از بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Cash Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion
            return true;
        }
        #endregion

        #endregion

    }
}