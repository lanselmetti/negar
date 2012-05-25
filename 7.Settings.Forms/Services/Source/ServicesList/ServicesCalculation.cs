#region using
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Negar;
using DevComponents.DotNetBar;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Settings.Services.Properties;
#endregion

namespace Sepehr.Settings.Services
{
    /// <summary>
    /// فرم مدیریت محاسبه خودكار سرفصل های قیمت خدمات
    /// </summary>
    internal partial class frmServicesCalculation : Form
    {

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmServicesCalculation()
        {
            InitializeComponent();
            if (!FillColumnsDataSource() || !FillCategories()) { Close(); return; }
            cBox1.Checked = true;
            cbo1.SelectedIndex = 0;
            cbo2.SelectedIndex = 0;
            cbo3.SelectedIndex = 0;
            txt1.DisplayFormat = "#####.####";
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            SetControlsToolTipTexts();
        }
        #endregion

        #region cBox1_CheckedChanged
        private void cBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (cBox1.Checked)
            {
                foreach (Control ctrl in FormPanel.Controls)
                {
                    if ((String)ctrl.Tag == "1") ctrl.Enabled = true;
                    else if ((String)ctrl.Tag == "2") ctrl.Enabled = false;
                }
                if (cbo1.SelectedIndex == 2) txt1.Enabled = false;
                else if (cbo1.SelectedIndex == 3)
                {
                    txt1.Enabled = false;
                    cbo2.Enabled = false;
                }
            }
            else if (cBox2.Checked)
                foreach (Control ctrl in FormPanel.Controls)
                {
                    if ((String)ctrl.Tag == "1") ctrl.Enabled = false;
                    else if ((String)ctrl.Tag == "2") ctrl.Enabled = true;
                }
        }
        #endregion

        #region cbo1_SelectedIndexChanged
        private void cbo1_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Inverse
            if (cbo1.SelectedIndex == 2)
            {
                txt1.Value = 1;
                txt1.Enabled = false;
                cbo2.Enabled = true;
            }
            #endregion

            #region Empty
            else if (cbo1.SelectedIndex == 3)
            {
                cbo2.Enabled = false;
                txt1.Enabled = false;
            }
            #endregion

            #region Others
            else
            {
                cbo2.Enabled = true;
                txt1.Enabled = true;
            }
            #endregion
        }
        #endregion

        #region txt2_Validating
        private void txt2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Int32 SelectedValue = txt2.Value;
            if (SelectedValue == 5 || SelectedValue == 10) return;

            #region Check If Value Is Not Multiplied 5 Or 10
            if (SelectedValue % 5 != 0 || SelectedValue % 10 != 0 || SelectedValue < 10)
            {
                PMBox.Show("امكان گرد كردن به اعدادی غیر از ضرایب خاصی از " +
                    "5 و 10 (مانند 50 ، 100 ، 500 یا 1000) ممكن نیست! لطفاً مجدداً امتحان نمایید.", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                return;
            }
            #endregion

            #region Check If Value Is Multiplied 5 Or 10
            for (; ; SelectedValue /= 10)
            {
                if (SelectedValue == 10 || SelectedValue == 5) return;
                if (SelectedValue < 10)
                {
                    PMBox.Show("امكان گرد كردن به اعدادی غیر از ضرایب خاصی از " +
                        "5 و 10 (مانند 50 ، 100 ، 500 یا 1000) ممكن نیست! لطفاً مجدداً امتحان نمایید.", "خطا!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                    return;
                }
            }
            #endregion
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

        #region Boolean FillColumnsDataSource()
        /// <summary>
        /// تابع خواندن اطلاعات سرفصل های قیمت در كمبو باكس ها
        /// </summary>
        /// <returns>صحت انجام كار</returns>
        private Boolean FillColumnsDataSource()
        {
            List<SP_SelectPriceColumnsListResult> PriceColumnsList;
            try { PriceColumnsList = DBLayerIMS.Manager.DBML.SP_SelectPriceColumnsList().ToList(); }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان خواندن اطلاعات سرفصل های قیمت موجود از بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr" , "Services Settings" , Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion
            cboColumns.DataSource = PriceColumnsList;
            cbo2.DataSource = PriceColumnsList.ToList();
            return true;
        }
        #endregion

        #region Boolean FillCategories()
        /// <summary>
        /// تابع خواندن اطلاعات طبقه بندی قیمت ها در كمبو باكس ها
        /// </summary>
        /// <returns>صحت انجام كار</returns>
        private Boolean FillCategories()
        {
            List<SP_SelectCategoriesResult> Categories;
            try { Categories = DBLayerIMS.Manager.DBML.SP_SelectCategories().ToList(); }
            #region Catch
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                const String ErrorMessage =
                    "امكان خواندن اطلاعات طبقه بندی قیمت ها از بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr" , "Services Settings" , Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion
            Categories[0].Name = "(همه خدمات)";
            cboCategory.DataSource = Categories;
            return true;
        }
        #endregion

        #endregion

    }
}