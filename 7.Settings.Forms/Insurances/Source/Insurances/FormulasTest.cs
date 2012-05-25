#region using
using System;
using System.Diagnostics;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Negar;

using Sepehr.Settings.Insurances.Properties;
#endregion

namespace Sepehr.Settings.Insurances.Insurances
{
    /// <summary>
    /// فرم بررسی فرمول بیمه دوم وارد شده 
    /// </summary>
    internal partial class frmFormulasTest : Form
    {

        #region Properties
        public String Field1 { get; set; }
        public String Field2 { get; set; }
        public String Field3 { get; set; }
        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض جهت افزودن یك ردیف جدید
        /// </summary>
        public frmFormulasTest()
        {
            InitializeComponent();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            SetControlsToolTipTexts();
            if (!Validation())
                PMBox.Show("متن فرمول وارد شده صحیح نمی باشد!", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            txtIns2Price.Focus();
        }
        #endregion

        #region btnAccept_Click
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (!Validation())
                PMBox.Show("متن فرمول وارد شده صحیح نمی باشد!", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        #region Form Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
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
            TooltipText = ToolTipManager.GetText("btnClose", "IMS");
            FormToolTip.SetSuperTooltip(btnCancel, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnValidation
            TooltipText = ToolTipManager.GetText("btnInsFormulaValidation", "IMS");
            FormToolTip.SetSuperTooltip(btnAccept, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

        }
        #endregion

        #region Boolean Validation()
        /// <summary>
        /// تابع بررسی اطلاعات وارد شده در فرم
        /// </summary>
        /// <returns>صحت اطلاعات ورودی یا خطا در اطلاعات وارد شده</returns>
        internal Boolean Validation()
        {
            Int32? Result1 = null;
            Int32? Result2 = null;
            Int32? Result3 = null;
            Boolean? IsOk = null;
            try
            {
                DBLayerIMS.Manager.DBML.SP_CheckIns2Formula(Field1, Field2, Field3,
                    txtPriceFree.Value, txtPriceGov.Value, txtIns1Price.Value, txtIns1Part.Value,
                    txtIns1Price.Value - txtIns1Part.Value, txtIns1PatientPayable.Value,
                    txtIns1Limit.Value, txtIns1PatientPercent.Value, txtIns2Limit.Value,
                    ref Result1, ref Result2, ref Result3, ref IsOk);
            }
            #region Catch
            catch (Exception Ex)
            {
                PMBox.Show("خطا در به روز رسانی اطلاعات بیمه جاری!", "خطا",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Insurances Settings", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion
            if (Visible)
            {
                txtIns2Price.Text = Result1.Value.ToString("N0");
                txtIns2Part.Text = Result2.Value.ToString("N0");
                txtPatientPayable.Text = Result3.Value.ToString("N0");
            }
            if (IsOk != null && IsOk.Value) return true;
            return false;
        }
        #endregion

        #endregion

    }
}