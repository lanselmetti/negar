#region using
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using Negar;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Settings.Insurances.Properties;
#endregion

namespace Sepehr.Settings.Insurances.Insurances
{
    /// <summary>
    /// فرم مدیریت فرمول های بیمه دوم ، شامل افزودن یا ویرایش فرمول
    /// </summary>
    internal partial class frmFormulasManage : Form
    {

        #region Fields

        #region Ins2Formula _CurrentFormula
        /// <summary>
        /// فیلد اطلاعاتی ردیف جاری جهت ویرایش
        /// </summary>
        private Ins2Formula _CurrentFormula;
        #endregion

        #region List<SP_SelectIns2FormulaColumnsResult> _ParamsList
        /// <summary>
        /// لیست ستون های قابل استفاده در فرمول های بیمه دوم
        /// </summary>
        private List<SP_SelectIns2FormulaColumnsResult> _ParamsList;
        #endregion

        #region readonly Boolean _IsAdding
        /// <summary>
        /// تعیین وضعیت فرم بین دو حالت افزودن و ویرایش
        /// </summary>
        private readonly Boolean _IsAdding;
        #endregion

        #region Formula Strings
        private String _Formula1;
        private String _Formula2;
        private String _Formula3;
        #endregion

        #endregion

        #region Ctors

        #region frmFormulasManage()
        /// <summary>
        /// سازنده پیش فرض جهت افزودن یك ردیف جدید
        /// </summary>
        public frmFormulasManage()
        {
            InitializeComponent();
            _IsAdding = true;
            if (!FillComboBoxes()) { Close(); return; }
            ShowDialog();
        }
        #endregion

        #region frmFormulasManage(Int16 CurrentD)
        /// <summary>
        /// سازنده كلاس جهت ویرایش یك ردیف
        /// </summary>
        /// <param name="CurrentD">كلید جدول</param>
        public frmFormulasManage(Int16 CurrentD)
        {
            InitializeComponent();
            _IsAdding = false;
            if (!FillComboBoxes() || !ReadFormulaData(CurrentD)) { Close(); return; }
            ShowDialog();
        }
        #endregion

        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            SetControlsToolTipTexts();
        }
        #endregion

        #region FarsiTextBoxes_Enter
        private void FarsiTextBoxes_Enter(object sender, EventArgs e)
        {
            Application.CurrentInputLanguage =
                InputLanguage.FromCulture(new System.Globalization.CultureInfo("Fa-Ir"));
        }
        #endregion

        #region txtFormulas_KeyDown
        private void txtFormulas_KeyDown(object sender, KeyEventArgs e)
        {
            #region Handle Cross
            if (e.KeyValue == 106)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                Int32 Start = ((NegarSyntaxHighlighter)sender).SelectionStart;
                ((NegarSyntaxHighlighter)sender).Text = ((NegarSyntaxHighlighter)sender).Text.Insert(Start, "×");
                ((NegarSyntaxHighlighter)sender).SelectionStart = Start + 1;
            }
            #endregion

            #region Handle Devision
            else if (e.KeyValue == 111)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                Int32 Start = ((NegarSyntaxHighlighter)sender).SelectionStart;
                ((NegarSyntaxHighlighter)sender).Text = ((NegarSyntaxHighlighter)sender).Text.Insert(Start, "÷");
                ((NegarSyntaxHighlighter)sender).SelectionStart = Start + 1;
            }
            #endregion
        }
        #endregion

        #region txtFormula2_Leave
        private void txtFormula2_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtFormula1.Text.Trim()) || String.IsNullOrEmpty(txtFormula2.Text.Trim())) return;
            if (txtFormula1.Text.Trim().Equals(txtFormula2.Text.Trim())) txtFormula3.Text = "0";
            else txtFormula3.Text = "(" + txtFormula1.Text.Trim() + ") - (" + txtFormula2.Text.Trim() + ")";
        }
        #endregion

        #region txtFormulas_Validating
        private void txtFormulas_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(((NegarSyntaxHighlighter)sender).Text.Trim()))
                ((NegarSyntaxHighlighter)sender).Text = "0";
        }
        #endregion

        #region btnAddFormula_Click
        private void btnAddFormula_Click(object sender, EventArgs e)
        {
            String InsertText = String.Empty;
            foreach (Control ctrl in ((ButtonX)sender).Parent.Controls)
                if (ctrl is ComboBoxEx)
                    InsertText = ((SP_SelectIns2FormulaColumnsResult)((ComboBoxEx)ctrl).SelectedItem).Name + " ";
            foreach (Control ctrl in ((ButtonX)sender).Parent.Controls)
                if (ctrl is NegarSyntaxHighlighter)
                {
                    Int32 SelectionStart = ((NegarSyntaxHighlighter)ctrl).SelectionStart;
                    ctrl.Text = ctrl.Text.Insert(SelectionStart, InsertText);
                    ((NegarSyntaxHighlighter)ctrl).SelectionStart = SelectionStart + InsertText.Length;
                    ctrl.Focus();
                    break;
                }
        }
        #endregion

        #region btnValidation_Click
        private void btnValidation_Click(object sender, EventArgs e)
        {
            btnValidation.Focus();
            MakeCorrectFormulasText();
            frmFormulasTest MyForm = new frmFormulasTest();
            MyForm.Field1 = _Formula1;
            MyForm.Field2 = _Formula2;
            MyForm.Field3 = _Formula3;
            MyForm.ShowDialog();
        }
        #endregion

        #region btnAccept_Click
        private void btnAccept_Click(object sender, EventArgs e)
        {
            #region Validation
            btnAccept.Focus();
            if (String.IsNullOrEmpty(txtName.Text.Trim()) || txtName.Text.Trim().Length < 3)
            {
                PMBox.Show("برای فرمول باید یك نام با حداقل سه حرف وارد نمایید!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return;
            }
            MakeCorrectFormulasText();
            frmFormulasTest MyForm = new frmFormulasTest();
            MyForm.Field1 = _Formula1;
            MyForm.Field2 = _Formula2;
            MyForm.Field3 = _Formula3;
            if (!MyForm.Validation())
            {
                PMBox.Show("فرمول های وارد شده دارای خطا می باشد! لطفاً متن فرمول را مجدداً بررسی نمایید.", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                MyForm.Dispose();
                return;
            }
            MyForm.Dispose();
            #endregion
            if (_IsAdding) { if (AddNewFormula()) DialogResult = DialogResult.OK; }
            else if (EditCurrentFormula()) DialogResult = DialogResult.OK;
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
            TooltipText = ToolTipManager.GetText("btnCancel_NoApply", "IMS");
            FormToolTip.SetSuperTooltip(btnCancel, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnAccept
            TooltipText = ToolTipManager.GetText("btnAccept", "IMS");
            FormToolTip.SetSuperTooltip(btnAccept, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnValidation
            TooltipText = ToolTipManager.GetText("btnInsFormulaValidation", "IMS");
            FormToolTip.SetSuperTooltip(btnValidation, new SuperTooltipInfo(TooltipHeader,
                TooltipFooter, TooltipText, Resources.Help, Resources.SepehrIcon,
                eTooltipColor.Lemon));
            #endregion

            #region btnAddsFormula
            TooltipText = ToolTipManager.GetText("btnAddInsFormulaToText", "IMS");
            FormToolTip.SetSuperTooltip(btnAdd1, new SuperTooltipInfo(TooltipHeader, TooltipFooter,
                TooltipText, Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            FormToolTip.SetSuperTooltip(btnAdd2, new SuperTooltipInfo(TooltipHeader, TooltipFooter,
                TooltipText, Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            FormToolTip.SetSuperTooltip(btnAdd3, new SuperTooltipInfo(TooltipHeader, TooltipFooter,
                TooltipText, Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region cboParam
            TooltipText = ToolTipManager.GetText("cboInsParamFormula", "IMS");
            FormToolTip.SetSuperTooltip(cboParam1, new SuperTooltipInfo(TooltipHeader,
                TooltipFooter, TooltipText, Resources.Help,
                Resources.SepehrIcon, eTooltipColor.Lemon));
            FormToolTip.SetSuperTooltip(cboParam2, new SuperTooltipInfo(TooltipHeader,
                TooltipFooter, TooltipText, Resources.Help,
                Resources.SepehrIcon, eTooltipColor.Lemon));
            FormToolTip.SetSuperTooltip(cboParam3, new SuperTooltipInfo(TooltipHeader,
                TooltipFooter, TooltipText, Resources.Help,
                Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

        }
        #endregion

        #region Boolean FillComboBoxes()
        /// <summary>
        /// تكمیل اطلاعات كمبو باكس پارامتر ها
        /// </summary>
        private Boolean FillComboBoxes()
        {
            try { _ParamsList = DBLayerIMS.Manager.DBML.SP_SelectIns2FormulaColumns().ToList(); }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان خواندن اطلاعات فرمولهای بیمه از بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Insurances Settings", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion
            cboParam1.DataSource = _ParamsList;
            cboParam2.DataSource = _ParamsList.ToList();
            cboParam3.DataSource = _ParamsList.ToList();

            #region Set Keywords
            txtFormula1.CompilerSettings.KeywordColor = Color.Teal;
            txtFormula2.CompilerSettings.KeywordColor = Color.Teal;
            txtFormula3.CompilerSettings.KeywordColor = Color.Teal;
            foreach (SP_SelectIns2FormulaColumnsResult Col in _ParamsList)
            {
                txtFormula1.CompilerSettings.Keywords.Add(Col.Name);
                txtFormula2.CompilerSettings.Keywords.Add(Col.Name);
                txtFormula3.CompilerSettings.Keywords.Add(Col.Name);
            }
            txtFormula1.CompileKeywords();
            txtFormula2.CompileKeywords();
            txtFormula3.CompileKeywords();
            #endregion

            return true;
        }
        #endregion

        #region Boolean ReadFormulaData()
        /// <summary>
        /// خواندن اطلاعات ردیف جاری فرم از بانك و تكمیل خصوصیات كنترل ها بر اساس آن
        /// </summary>
        /// <returns>صحت تكمیل فرم</returns>
        private bool ReadFormulaData(Int16 RowID)
        {
            try
            {
                _CurrentFormula = DBLayerIMS.Manager.DBML.Ins2Formulas.
                    Where(Data => Data.ID == RowID).First();
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان خواندن اطلاعات بیمه دوم از بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Insurances Settings", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error); return false;
            }
            #endregion
            cBoxActive.Checked = _CurrentFormula.IsActive;
            txtName.Text = _CurrentFormula.Name;
            _Formula1 = _CurrentFormula.Ins2Price;
            _Formula2 = _CurrentFormula.Ins2Part;
            _Formula3 = _CurrentFormula.PatientPayable;
            txtDescription.Text = _CurrentFormula.Description;
            MakeInCorrectFormulasText();
            return true;
        }
        #endregion

        #region Boolean AddNewFormula()
        /// <summary>
        /// ثبت اطلاعات وارد شده در فرم به بانك اطلاعات
        /// </summary>
        /// <returns>صحت انجام كار</returns>
        private Boolean AddNewFormula()
        {
            Ins2Formula NewItem = new Ins2Formula();
            NewItem.IsActive = cBoxActive.Checked;
            NewItem.Name = txtName.Text.Trim().Normalize();
            NewItem.Ins2Price = _Formula1;
            NewItem.Ins2Part = _Formula2;
            NewItem.PatientPayable = _Formula3;
            NewItem.Description = txtDescription.Text.Trim().Normalize();
            DBLayerIMS.Manager.DBML.Ins2Formulas.InsertOnSubmit(NewItem);
            if (!DBLayerIMS.Manager.Submit())
            {
                const String ErrorMessage = "ثبت اطلاعات فرمول بیمه دوم در بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        #endregion

        #region Boolean EditCurrentFormula()
        /// <summary>
        /// به روز رسانی اطلاعات ردیف جاری در فرم به بانك اطلاعات
        /// </summary>
        /// <returns>صحت انجام كار</returns>
        private Boolean EditCurrentFormula()
        {
            _CurrentFormula.IsActive = cBoxActive.Checked;
            _CurrentFormula.Name = txtName.Text.Trim().Normalize();
            _CurrentFormula.Ins2Price = _Formula1;
            _CurrentFormula.Ins2Part = _Formula2;
            _CurrentFormula.PatientPayable = _Formula3;
            _CurrentFormula.Description = txtDescription.Text.Trim().Normalize();
            if (!DBLayerIMS.Manager.Submit())
            {
                const String ErrorMessage = "ویرایش اطلاعات فرمول بیمه دوم جاری ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
            }
            return true;
        }
        #endregion

        #region void MakeCorrectFormulasText()
        /// <summary>
        /// تابع جایگذاری عبارات اصلی فرمول های وارد شده
        /// </summary>
        private void MakeCorrectFormulasText()
        {
            _Formula1 = txtFormula1.Text.Trim();
            _Formula2 = txtFormula2.Text.Trim();
            _Formula3 = txtFormula3.Text.Trim();

            #region MakeCorrectFormulasText Incorrect Texts
            if (_Formula1.Contains("×") || _Formula1.Contains("÷"))
            {
                _Formula1 = _Formula1.Replace("×", "*");
                _Formula1 = _Formula1.Replace("÷", "/");
            }
            foreach (SP_SelectIns2FormulaColumnsResult item in _ParamsList.OrderByDescending(Data => Data.Name.Length))
                if (_Formula1.Contains(item.Name)) _Formula1 = _Formula1.Replace(item.Name, item.ColumnName);
            if (_Formula2.Contains("×") || _Formula2.Contains("÷"))
            {
                _Formula2 = _Formula2.Replace("×", "*");
                _Formula2 = _Formula2.Replace("÷", "/");
            }
            foreach (SP_SelectIns2FormulaColumnsResult item in _ParamsList.OrderByDescending(Data => Data.Name.Length))
                if (_Formula2.Contains(item.Name)) _Formula2 = _Formula2.Replace(item.Name, item.ColumnName);
            if (_Formula3.Contains("×") || _Formula3.Contains("÷"))
            {
                _Formula3 = _Formula3.Replace("×", "*");
                _Formula3 = _Formula3.Replace("÷", "/");
            }
            foreach (SP_SelectIns2FormulaColumnsResult item in _ParamsList.OrderByDescending(Data => Data.Name.Length))
                if (_Formula3.Contains(item.Name)) _Formula3 = _Formula3.Replace(item.Name, item.ColumnName);
            #endregion
        }
        #endregion

        #region void MakeInCorrectFormulasText()
        /// <summary>
        /// تابع جایگذاری عبارات فارسی فرمول های وارد شده
        /// </summary>
        private void MakeInCorrectFormulasText()
        {
            #region MakeCorrectFormulasText Incorrect Texts
            if (_Formula1.Contains("*") || _Formula1.Contains("/"))
            {
                _Formula1 = _Formula1.Replace("*", "×");
                _Formula1 = _Formula1.Replace("/", "÷");
            }
            foreach (SP_SelectIns2FormulaColumnsResult item in cboParam1.Items)
                if (_Formula1.Contains(item.ColumnName))
                    _Formula1 = _Formula1.Replace(item.ColumnName, item.Name);
            if (_Formula2.Contains("*") || _Formula2.Contains("/"))
            {
                _Formula2 = _Formula2.Replace("*", "×");
                _Formula2 = _Formula2.Replace("/", "÷");
            }
            foreach (SP_SelectIns2FormulaColumnsResult item in cboParam2.Items)
                if (_Formula2.Contains(item.ColumnName))
                    _Formula2 = _Formula2.Replace(item.ColumnName, item.Name);
            if (_Formula3.Contains("*") || _Formula3.Contains("/"))
            {
                _Formula3 = _Formula3.Replace("*", "×");
                _Formula3 = _Formula3.Replace("/", "÷");
            }
            foreach (SP_SelectIns2FormulaColumnsResult item in cboParam3.Items)
                if (_Formula3.Contains(item.ColumnName))
                    _Formula3 = _Formula3.Replace(item.ColumnName, item.Name);
            #endregion
            txtFormula1.Text = _Formula1.Trim();
            txtFormula1.ProcessAllLines();
            txtFormula2.Text = _Formula2.Trim();
            txtFormula2.ProcessAllLines();
            txtFormula3.Text = _Formula3.Trim();
            txtFormula3.ProcessAllLines();
        }
        #endregion

        #endregion

    }
}