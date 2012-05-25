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
    internal partial class frmCashOpenClose : Form
    {

        #region Fields

        #region readonly Int16  _CashID
        /// <summary>
        /// كلید صندوق جاری
        /// </summary>
        private readonly Int16 _CashID;
        #endregion

        #region Boolean _IsNewLog
        /// <summary>
        /// تعیین باز نشده بودن صندوق
        /// </summary>
        private Boolean _IsNewLog;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmCashOpenClose(Int16 CashID)
        {
            Cursor.Current = Cursors.WaitCursor;
            InitializeComponent();
            _CashID = CashID;
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
            if (_IsNewLog) DBLayerIMS.Cash.OpenCash(_CashID, txtStartValue.Value);
            else DBLayerIMS.Cash.CloseCash(_CashID, txtFinishValue.Value);
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
                SP_SelectCashesStatusResult CashesStatus = DBLayerIMS.Manager.DBML.
                    SP_SelectCashesStatus(SecurityManager.CurrentUserID).Where(Data => Data.CashID == _CashID).First();
                txtCash.Text = CashesStatus.Name;
                txtCashStatus.Text = CashesStatus.CashStatus;

                #region Close Cash
                // اگر ردیف انتخاب شده صندوقی باشد كه باز است
                // فرم در حالت بستن صندوق باز می شود
                if (CashesStatus.CashStatus == "باز")
                {
                    _IsNewLog = false;
                    lblTitle.Text = "بستن صندوق";
                    btnApply.Text = "بستن صندوق\n(F8)";
                    Int32 StartValue = DBLayerIMS.Manager.DBML.CashLogs.Where(Data => Data.ID == CashesStatus.CashLogID).
                        Select(Data => Data.SupplyBegin).First();
                    txtStartValue.Value = StartValue;
                    txtStartValue.IsInputReadOnly = true;
                    txtStartValue.ShowUpDown = false;
                    Int32? OrderedValue = DBLayerIMS.Manager.DBML.FK_GetCashLogStatutorySypply(CashesStatus.CashLogID);
                    if (OrderedValue == null) OrderedValue = 0;
                    txtOrderedValue.Text = OrderedValue.Value + " ریال";
                    txtFinishValue.Value = StartValue + OrderedValue.Value;
                    txtFinishValue.Focus();
                }
                #endregion

                #region Open Cash
                // اگر ردیف انتخاب شده صندوقی باشد كه تا كنون باز نشده
                // یك ردیف جدید برای آن صندوق ایجاد می شود
                else
                {
                    _IsNewLog = true;
                    lblTitle.Text = "باز كردن صندوق";
                    btnApply.Text = "باز كردن صندوق\n(F8)";
                    txtStartValue.Value = 0;
                    txtOrderedValue.Visible = false;
                    lblOrderedValue.Visible = false;
                    lblRial2.Visible = false;
                    txtFinishValue.Visible = false;
                    lblFinishValue.Visible = false;
                    lblRial3.Visible = false;
                    Height = Height - 40;
                    txtStartValue.Focus();
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