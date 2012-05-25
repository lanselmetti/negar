#region using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Negar;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Settings.Insurances.Properties;
#endregion

namespace Sepehr.Settings.Insurances.InsurancesServices
{
    /// <summary>
    /// فرم محاسبه خودكار قیمت خدمات بیمه ها
    /// </summary>
    internal partial class frmAutoCalculation : Form
    {

        #region Fields

        #region readonly Int16 _RowID
        /// <summary>
        /// كلید ردیف جاری جهت ویرایش
        /// </summary>
        private readonly Int16 _RowID;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده كلاس جهت ویرایش یك ردیف
        /// </summary>
        /// <param name="RowID">كلید جدول</param>
        public frmAutoCalculation(Int16 RowID)
        {
            InitializeComponent();
            _RowID = RowID;
            FillInsControlsData();
            if (!FillCboCategory() || !FillServiceColumnsComboBoxes()) { Close(); return; }
            SetControlsToolTipTexts();
            cBox21.Checked = false;
            cBox42.Checked = false;
            cBox22.Checked = false;
            cBox43.Checked = false;
            cboCoverage.SelectedIndex = 1;
            cbo24.SelectedIndex = 0;
            cbo43.SelectedIndex = 0;
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
        }
        #endregion

        #region cbo11_SelectedIndexChanged
        private void cbo11_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbo21.SelectedIndex = cbo11.SelectedIndex;
        }
        #endregion

        #region RoundingTextBoxes_Validating
        private void RoundingTextBoxes_Validating(object sender, CancelEventArgs e)
        {
            Int32 SelectedValue = Convert.ToInt32(((IntegerInput)sender).Text);

            if (SelectedValue == 5 || SelectedValue == 10) return;

            #region Check If Value Is Not Multiplied 5 Or 10
            if (SelectedValue % 5 != 0 || SelectedValue % 10 != 0 || SelectedValue < 10)
            {
                PMBox.Show("امكان گرد كردن به اعدادی غیر از ضرایبی" +
                           " 5 و 10 (مانند 50 ، 100 ، 500 یا 1000) ممكن نیست! لطفا مجدداً امتحان نمایید.", "خطا",
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
                    PMBox.Show("امكان گرد كردن به اعدادی غیر از ضرایبی" +
                               " 5 و 10 (مانند 50 ، 100 ، 500 یا 1000) ممكن نیست! لطفا مجدداً امتحان نمایید.", "خطا",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                    return;
                }
            }
            #endregion
        }
        #endregion

        #region Plus_CheckedChanged
        private void Plus_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBoxX)sender).Checked)
            {
                foreach (Control Ctrl in ((CheckBoxX)sender).Parent.Controls)
                    if (Ctrl.AccessibleName == "Plus") Ctrl.Enabled = true;
            }
            else
            {
                foreach (Control Ctrl in ((CheckBoxX)sender).Parent.Controls)
                    if (Ctrl.AccessibleName == "Plus") Ctrl.Enabled = false;
            }
        }
        #endregion

        #region Round_CheckedChange
        private void Round_CheckedChange(object sender, EventArgs e)
        {
            if (((CheckBoxX)sender).Checked)
            {
                foreach (Control Ctrl in ((CheckBoxX)sender).Parent.Controls)
                    if (Ctrl.AccessibleName == "Round") Ctrl.Enabled = true;
            }
            else
            {
                foreach (Control Ctrl in ((CheckBoxX)sender).Parent.Controls)
                    if (Ctrl.AccessibleName == "Round") Ctrl.Enabled = false;
            }
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

        #region void FillInsControlsData()
        /// <summary>
        /// تابع تكمیل اطلاعات بیمه ی فرم
        /// </summary>
        private void FillInsControlsData()
        {
            txtInsName.Text = DBLayerIMS.Insurance.InsFullList.
                    Where(result => result.ID == _RowID).Select(result => result.Name).First();
            txt21.Value = 100 - Convert.ToDouble(DBLayerIMS.Insurance.InsFullList.
                Where(result => result.ID == _RowID).Select(result => result.PatientPercent).First());
        }
        #endregion

        #region Boolean FillCboCategory()
        /// <summary>
        /// پركردن كمبو باكس نوع خدمات
        /// </summary>
        private Boolean FillCboCategory()
        {
            DBLayerIMS.Services.ServCategoriesList = null;
            List<SP_SelectCategoriesResult> Categories = DBLayerIMS.Services.ServCategoriesList;
            if (Categories == null) return false;
            Categories = Categories.Where(Data => Data.IsActive == true || Data.ID == null).ToList();
            Categories[0].Name = "(همه خدمات)";
            cboCategory.DataSource = Categories;
            return true;
        }
        #endregion

        #region Boolean FillServiceColumnsComboBoxes()
        /// <summary>
        /// تابع خواندن اطلاعات سرفصل های قیمت در كمبو باكس ها
        /// </summary>
        /// <returns>صحت انجام كار</returns>
        private Boolean FillServiceColumnsComboBoxes()
        {
            List<SP_SelectPriceColumnsListResult> PriceColumnsList;
            try { PriceColumnsList =DBLayerIMS.Manager.DBML.SP_SelectPriceColumnsList().ToList(); }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "خواندن اطلاعات سرفصل های قیمت از بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Insurances Settings", Ex.Message + "\n" + 
                    Ex.StackTrace, EventLogEntryType.Error); return false;
            }
            #endregion
            // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            SP_SelectPriceColumnsListResult ZeroValue = new SP_SelectPriceColumnsListResult();
            ZeroValue.ColumnName = "0Zero";
            ZeroValue.Name = "صفر";
            PriceColumnsList.Add(ZeroValue);
            // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            foreach (Control ctrl in FormPanel.Controls)
                if (ctrl is GroupPanel)
                    foreach (Control Combo in ctrl.Controls)
                        if (Combo is ComboBoxEx && Combo.Tag != null && 
                            Combo.Tag.ToString() == "ServiceColumns")
                        {
                            ((ComboBoxEx)Combo).DataSource = PriceColumnsList.ToList();
                            ((ComboBoxEx)Combo).DisplayMember = "Name";
                            ((ComboBoxEx)Combo).ValueMember = "ColumnName";
                        }
            return true;
        }
        #endregion

        #endregion

    }
}