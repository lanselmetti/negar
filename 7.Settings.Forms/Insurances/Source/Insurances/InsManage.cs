#region using
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Negar;
using DevComponents.DotNetBar;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Settings.Insurances.Properties;
#endregion

namespace Sepehr.Settings.Insurances.Insurances
{
    /// <summary>
    /// فرم مدیریت بیمه ها ، شامل افزودن بیمه یا ویرایش بیمه ثبت شده
    /// </summary>
    internal partial class frmInsManage : Form
    {

        #region Fields

        #region readonly Int16 _CurrentRowID
        /// <summary>
        /// كلید ردیف جاری جهت ویرایش
        /// </summary>
        private readonly Int16 _CurrentRowID;
        #endregion

        #region readonly Boolean _IsAdding
        /// <summary>
        /// تعیین وضعیت فرم بین دو حالت افزودن و ویرایش
        /// </summary>
        private readonly Boolean _IsAdding;
        #endregion

        #region List<SP_SelectIns2FormulasResult> _FormulasDataSource
        /// <summary>
        /// منبع داده فرم برای فرمول های بیمه دوم
        /// </summary>
        private List<SP_SelectIns2FormulasResult> _FormulasDataSource;
        #endregion

        #endregion

        #region Ctors

        #region frmInsuranceManage()
        /// <summary>
        /// سازنده پیش فرض جهت افزودن یك ردیف جدید
        /// </summary>
        public frmInsManage()
        {
            Application.CurrentInputLanguage =
                InputLanguage.FromCulture(new System.Globalization.CultureInfo("Fa-Ir"));
            InitializeComponent();
            _IsAdding = true;
            if (!FillFormulaComboBox()) { Close(); return; }
            txtPatientPercent.Value = 0;
            txtInsPartLimit.Value = 0;
            DateContract.SelectedDateTime = null;
            DateExpiration.SelectedDateTime = null;
            ShowDialog();
        }
        #endregion

        #region frmInsuranceManage(Int16 RowID)
        /// <summary>
        /// سازنده كلاس جهت ویرایش یك ردیف
        /// </summary>
        /// <param name="RowID">كلید جدول</param>
        public frmInsManage(Int16 RowID)
        {
            Application.CurrentInputLanguage =
                InputLanguage.FromCulture(new System.Globalization.CultureInfo("Fa-Ir"));
            InitializeComponent();
            _IsAdding = false;
            _CurrentRowID = RowID;
            if (!FillFormulaComboBox() || !FillControls()) { Close(); return; }
            ShowDialog();
        }
        #endregion

        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            SetControlsToolTipTexts();
            txtInsName.Focus();
        }
        #endregion

        #region btnAccept_Click
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (!Validation()) return;
            if (_IsAdding) { if (InsertNewRow()) DialogResult = DialogResult.OK; }
            else if (UpdateCurrentRow()) DialogResult = DialogResult.OK;
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
            TooltipText = ToolTipManager.GetText("btnCancel", "IMS");
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

        #region Boolean FillFormulaComboBox()
        /// <summary>
        /// تكمیل اطلاعات كمبوباكس فرمول های بیمه دوم
        /// </summary>
        /// <returns>صحت انجام كار</returns>
        private Boolean FillFormulaComboBox()
        {
            _FormulasDataSource = DBLayerIMS.Insurance.Ins2FormulaList;
            if (_FormulasDataSource == null) return false;
            cboIns2Formula.DataSource = _FormulasDataSource.
                Where(Data => Data.ID == null || Data.IsActive == true).ToList();
            return true;
        }
        #endregion

        #region Boolean FillControls()
        /// <summary>
        /// خواندن اطلاعات بیمه جاری از بانك برای ویرایش و تكمیل خصوصیات كنترل ها بر اساس آن
        /// </summary>
        /// <returns>صحت تكمیل فرم</returns>
        private Boolean FillControls()
        {
            List<SP_SelectInsFullDataResult> InsList = DBLayerIMS.Insurance.InsFullList;
            if (InsList == null) return false;
            SP_SelectInsFullDataResult CurrentRow = InsList.Where(Data => Data.ID == _CurrentRowID).First();
            cBoxActive.Checked = CurrentRow.IsActive.Value;
            txtInsName.Text = CurrentRow.Name;
            DateContract.SelectedDateTime = CurrentRow.ContractStartDate;
            DateExpiration.SelectedDateTime = CurrentRow.ContractEndDate;
            txtPatientPercent.Text = CurrentRow.PatientPercent.ToString();
            txtInsPartLimit.Text = CurrentRow.InsurerPartLimit.ToString();
            cBoxIsIns1.Checked = CurrentRow.IsIns1 != null &&
            Convert.ToBoolean(CurrentRow.IsIns1);
            cBoxIsIns2.Checked = CurrentRow.IsIns2 != null &&
            Convert.ToBoolean(CurrentRow.IsIns2);
            if (CurrentRow.Ins2FormulasIX == null) cboIns2Formula.SelectedIndex = 0;
            else
            {
                if (((List<SP_SelectIns2FormulasResult>)cboIns2Formula.DataSource).
                    Where(Data => Data.ID == CurrentRow.Ins2FormulasIX).Count() == 0)
                {
                    cboIns2Formula.DataSource = _FormulasDataSource.
                        Where(Data => Data.ID == null || Data.IsActive == true ||
                            Data.ID == CurrentRow.Ins2FormulasIX).ToList();
                    ((List<SP_SelectIns2FormulasResult>)cboIns2Formula.DataSource).
                        Add(_FormulasDataSource.Where(Data => Data.ID == CurrentRow.Ins2FormulasIX).First());
                }
                cboIns2Formula.SelectedValue = CurrentRow.Ins2FormulasIX;
            }
            txtDescription.Text = CurrentRow.Description;
            return true;
        }
        #endregion

        #region Boolean Validation()
        /// <summary>
        /// تابع بررسی اطلاعات وارد شده در فرم
        /// </summary>
        /// <returns>صحت اطلاعات ورودی یا خطا در اطلاعات وارد شده</returns>
        private Boolean Validation()
        {
            #region Insurance Name
            if (String.IsNullOrEmpty(txtInsName.Text.Trim()) || txtInsName.Text.Length < 3)
            {
                PMBox.Show("برای بیمه باید یك نام با حداقل سه حرف وارد نمایید!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInsName.Focus();
                return false;
            }
            #endregion

            #region Contract Dates
            if (DateContract.SelectedDateTime != null &&
                DateExpiration.SelectedDateTime != null &&
                DateContract.SelectedDateTime.Value.Date >= DateExpiration.SelectedDateTime.Value.Date)
            {
                PMBox.Show("تاریخ آغاز قرارداد بیمه باید كوچكتر از تاریخ پایان آن باشد!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                DateContract.Focus();
                return false;
            }
            #endregion

            #region IsIns1 & IsIns2
            if (!cBoxIsIns1.Checked && !cBoxIsIns2.Checked)
            {
                PMBox.Show("برای تعریف بیمه ، حتماً باید بیمه اول یا دوم را تعیین كرد!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                cBoxIsIns1.Focus();
                return false;
            }
            #endregion

            return true;
        }
        #endregion

        #region Boolean InsertNewRow()
        /// <summary>
        /// ثبت ردیف جدید در بانك اطلاعات
        /// </summary>
        /// <returns>صحت انجام كار</returns>
        private Boolean InsertNewRow()
        {
            Int16? FormulaID = null;
            if (cboIns2Formula.SelectedValue != null)
                FormulaID = Convert.ToInt16(cboIns2Formula.SelectedValue);
            try
            {
                DBLayerIMS.Manager.DBML.SP_InsertInsFullData(true, txtInsName.Text.Trim().Normalize(),
                    cBoxActive.Checked, DateContract.SelectedDateTime, DateExpiration.SelectedDateTime,
                    Convert.ToByte(txtPatientPercent.Value),
                    txtInsPartLimit.Value, cBoxIsIns1.Checked,
                    cBoxIsIns2.Checked, FormulaID, txtDescription.Text.Trim().Normalize());
            }
            #region Catch
            catch (Exception Ex)
            {
                PMBox.Show("خطا در ثبت اطلاعات بیمه جدید در بانك اطلاعاتی!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Insurances Settings", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error); return false;
            }
            #endregion
            return true;
        }
        #endregion

        #region Boolean UpdateCurrentRow()
        /// <summary>
        /// به روز رسانی ردیف جاری در بانك اطلاعات
        /// </summary>
        /// <returns>صحت انجام كار</returns>
        private Boolean UpdateCurrentRow()
        {
            Int16? FormulaID = null;
            if (cboIns2Formula.SelectedValue != null)
                FormulaID = Convert.ToInt16(cboIns2Formula.SelectedValue);
            try
            {
                DBLayerIMS.Manager.DBML.SP_UpdateInsFullData(_CurrentRowID, true,
                      txtInsName.Text.Trim().Normalize(), cBoxActive.Checked,
                      DateContract.SelectedDateTime, DateExpiration.SelectedDateTime,
                      Convert.ToByte(txtPatientPercent.Value), txtInsPartLimit.Value,
                      cBoxIsIns1.Checked, cBoxIsIns2.Checked,
                      FormulaID, txtDescription.Text.Trim().Normalize());
            }
            #region Catch
            catch (Exception Ex)
            {
                PMBox.Show("خطا در ویرایش اطلاعات بیمه جاری!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Insurances Settings", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion
            return true;
        }
        #endregion

        #endregion

    }
}