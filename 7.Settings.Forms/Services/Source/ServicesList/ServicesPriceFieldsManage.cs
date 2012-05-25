#region using
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Negar;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Settings.Services.Properties;
#endregion

namespace Sepehr.Settings.Services
{
    /// <summary>
    /// فرم ثبت سرفصل قیمتی جدید برای خدمات
    /// </summary>
    internal partial class frmServicesPriceFieldsManage : Form
    {

        #region Fields

        #region readonly Boolean _IsAdding
        /// <summary>
        /// تعیین وضعیت فرم در دو حالت افزودن و ویرایش
        /// </summary>
        private readonly Boolean _IsAdding;
        #endregion

        #region AdditionalPriceColumn _CurrentColData
        /// <summary>
        /// فیلد اطلاعاتی ستون انتخاب شده برای ویرایش
        /// </summary>
        private AdditionalPriceColumn _CurrentColData;
        #endregion

        #endregion

        #region Ctors

        #region frmServicesPriceFieldsManage()
        /// <summary>
        /// سازنده فرم برای افزودن فیلد جدید
        /// </summary>
        public frmServicesPriceFieldsManage()
        {
            Application.CurrentInputLanguage =
                InputLanguage.FromCulture(new System.Globalization.CultureInfo("Fa-Ir"));
            InitializeComponent();
            _IsAdding = true;
            SetControlsToolTipTexts();
            ShowDialog();
        }
        #endregion

        #region frmServicesPriceFieldsManage(Int16 ColID)
        /// <summary>
        /// سازنده فرم برای ویرایش فیلد 
        /// </summary>
        /// <param name="ColID">كلید ردیف</param>
        public frmServicesPriceFieldsManage(Int16 ColID)
        {
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("Fa-Ir"));
            InitializeComponent();
            _IsAdding = false;
            if (!FillColData(ColID)) { Close(); return; }
            SetControlsToolTipTexts();
            ShowDialog();
        }
        #endregion

        #endregion

        #region Event Handlers

        #region btnSave_Click
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtName.Text.Trim()))
            {
                PMBox.Show("برای سرفصل مورد نظر حتماً مقداری را وارد نمایید!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return;
            }
            if (_IsAdding)
                try { DBLayerIMS.Manager.DBML.SP_InsertAdditionalPriceColumns(txtName.Text, txtDescription.Text); }
                #region Catch
                catch (Exception Ex)
                {
                    const String ErrorMessage = "امكان به روز رسانی بانك بر اساس اطلاعات وارد شده ممكن نیست.\n" +
                        "موارد زیر را بررسی نمایید:\n" +
                        "1. آیا نام تكراری وارد ننموده اید؟\n" +
                        "2. آیا ردیف جدیدی فاقد نام وارد ننموده اید؟\n" +
                        "3. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogManager.SaveLogEntry("Sepehr", "Services Settings", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                }
                finally
                {
                    Dispose();
                }
                #endregion
            else
            {
                _CurrentColData.Name = txtName.Text.Trim().Normalize();
                _CurrentColData.Description = txtDescription.Text.Trim().Normalize();
                if (!DBLayerIMS.Manager.Submit())
                {
                    const String ErrorMessage = "امكان به روز رسانی بانك بر اساس اطلاعات وارد شده ممكن نیست.\n" +
                        "موارد زیر را بررسی نمایید:\n" +
                        "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                }
            }
            FormClosing -= (Form_Closing);
            DialogResult = DialogResult.OK;
        }
        #endregion

        #region btnHelp_Click
        /// <summary>
        /// روال نمایش راهنمایی برای فرم
        /// </summary>
        private void btnHelp_Click(object sender, EventArgs e)
        {
            // ToDo: نمایش راهنما تكمیل شود
        }
        #endregion

        #region Form_Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            DialogResult Dr = PMBox.Show("آیا منصرف شدید؟", "هشدار",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Dr == DialogResult.No) { e.Cancel = true; return; }
            Dispose();
        }
        #endregion

        #endregion

        #region Methods

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

            #region btnCancel
            TooltipText = ToolTipManager.GetText("btnCancel_NoApply", "IMS");
            FormToolTip.SetSuperTooltip(btnCancel, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnAccept
            TooltipText = ToolTipManager.GetText("btnAccept", "IMS");
            FormToolTip.SetSuperTooltip(btnAccept, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

        }
        #endregion

        #region Boolean FillColData(Int16 ColID)
        /// <summary>
        /// اطلاعات فرم را كامل می كند
        /// </summary>
        /// <param name="ColID">كلید سرفصل</param>
        /// <returns>ٌصحت انجام كار</returns>
        private Boolean FillColData(Int16 ColID)
        {
            try
            {
                _CurrentColData =
                    DBLayerIMS.Manager.DBML.AdditionalPriceColumns.Where(Data => Data.ID == ColID).First();
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان خواندن اطلاعات سرفصل قیمت انتخاب شده از بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Services Settings", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion
            txtName.Text = _CurrentColData.Name;
            txtDescription.Text = _CurrentColData.Description;
            return true;
        }
        #endregion

        #endregion

    }
}