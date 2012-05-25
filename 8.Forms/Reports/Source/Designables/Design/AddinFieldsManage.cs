#region using
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Negar;
using Sepehr.DBLayerIMS.DataLayer;
#endregion

namespace Sepehr.Forms.Reports.Designables.Design
{
    /// <summary>
    /// فرم افزودن یا ویرایش فیلد های پویا برای گزارش های قابل طراحی
    /// </summary>
    internal partial class frmAddinFieldsManage : Form
    {

        #region Fields

        #region readonly Int16 _FieldID
        /// <summary>
        /// كلید فیلد اطلاعاتی در حال ویرایش
        /// </summary>
        private readonly Int16 _FieldID;
        #endregion

        #region Boolean _IsEditing
        /// <summary>
        ///  مجزا كننده حالت ویرایش از حالت افزودن
        /// </summary>
        private readonly Boolean _IsEditing;
        #endregion

        #region DesignableReportsAddinCol _CurrentAddinField
        /// <summary>
        ///  نمونه فیلد اطلاعاتی در حال ویرایش
        /// </summary>
        private DesignableReportsAddinCol _CurrentAddinField;
        #endregion

        #region Dictionary<String, String> _FormulaDataSource
        /// <summary>
        /// دیكشنری پر شده با ستون های قابل انتخاب برای فیلد های اضافه
        /// </summary>
        private Dictionary<String, String> _FormulaDataSource;
        #endregion

        #endregion

        #region Ctor

        #region frmAddinFieldsManage()
        /// <summary>
        /// سازنده فرم در حالت افزودن
        /// </summary>
        public frmAddinFieldsManage()
        {
            _IsEditing = false;
            InitializeComponent();
            if (!FillcBoxFields()) { Close(); return; }
            ShowDialog();
        }
        #endregion

        #region frmAddinFieldsManage(Int16 FieldID)
        /// <summary>
        /// سازنده فرم در حالت ویرایش
        /// </summary>
        /// <param name="FieldID">شناسه جزء اطلاعاتی در حال ویرایش</param>
        public frmAddinFieldsManage(Int16 FieldID)
        {
            _IsEditing = true;
            _FieldID = FieldID;
            InitializeComponent();
            if (!FillcBoxFields() || !FillSelectedColumns()) { Close(); return; }
            ShowDialog();
        }
        #endregion

        #endregion

        #region EventHandlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            txtResult.CompileKeywords();
            txtResult.ProcessAllLines();
            Opacity = 1;
        }
        #endregion

        #region btnAdd_Click
        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtResult.Text += cBoxFields.Text + " ";
            txtResult.Focus();
            txtResult.SelectionStart = txtResult.Text.Length - 1;
            txtResult.SelectionLength = 0;
        }
        #endregion

        #region FarsiTextBoxes_Enter
        private void FarsiTextBoxes_Enter(object sender, EventArgs e)
        {
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("Fa-Ir"));
        }
        #endregion

        #region txtFormulas_KeyDown
        private void txtFormulas_KeyDown(object sender, KeyEventArgs e)
        {
            #region Handle Cross
            if (e.KeyValue == 106 || e.KeyValue == 56)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                Int32 Start = ((NegarSyntaxHighlighter)sender).SelectionStart;
                ((NegarSyntaxHighlighter)sender).Text = ((NegarSyntaxHighlighter)sender).Text.Insert(Start, "×");
                ((NegarSyntaxHighlighter)sender).SelectionStart = Start + 1;
            }
            #endregion

            #region Handle Devision
            else if (e.KeyValue == 111 || e.KeyValue == 191)
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

        #region btnCheck_Click
        private void btnCheck_Click(object sender, EventArgs e)
        {
            String Formula = MakeCorrectFormulaText(txtResult.Text);
            if (!CheckVeracity(Formula))
            {
                const String ErrorMessage = "فرمول وارد شده صحیح نمی باشد!\n" + "لطفاً مجدداً بررسی نمایید.";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                const String ErrorMessage = "فرمول وارد شده صحیح می باشد!";
                PMBox.Show(ErrorMessage, "تبریك!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region btnSave_Click
        private void btnSave_Click(object sender, EventArgs e)
        {
            #region Validations
            if (String.IsNullOrEmpty(txtName.Text.Trim()))
            {
                PMBox.Show("برای فیلد حتماً نامی انتخاب نمایید!", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return;
            }
            String Formula = MakeCorrectFormulaText(txtResult.Text);
            if (!CheckVeracity(Formula))
            {
                const String ErrorMessage = " فرمول وارد شده صحیح نمی باشد !\n" + "لطفاً مجدداً بررسی نمایید.";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            #region In Adding Mode
            if (!_IsEditing)
            {
                DesignableReportsAddinCol Item = new DesignableReportsAddinCol();
                Item.Title = txtName.Text;
                Item.FieldFormula = Formula;
                Item.SelectedFields = CreateFormulaXMLFile(Formula);
                DBLayerIMS.Manager.DBML.DesignableReportsAddinCols.InsertOnSubmit(Item);
                Boolean HaveError = false;
                if (!DBLayerIMS.Manager.Submit()) HaveError = true;
                if (!HaveError)
                {
                    Item.FieldName = "Field" + Item.ID;
                    if (!DBLayerIMS.Manager.Submit()) HaveError = true;
                }
                if (HaveError)
                {
                    const String ErrorMessage = "ثبت فیلد اطلاعاتی جدید گزارش های قابل طراحی ممكن نیست.\n" +
                        "موارد زیر را بررسی نمایید:\n" +
                        "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                }
            }
            #endregion

            #region In Editing Mode
            else
            {
                DesignableReportsAddinCol Item = _CurrentAddinField;
                Item.Title = txtName.Text;
                Item.FieldFormula = Formula;
                Item.SelectedFields = CreateFormulaXMLFile(Formula);
                if (!DBLayerIMS.Manager.Submit())
                {
                    const String ErrorMessage = "ثبت اطلاعات فیلد اطلاعاتی گزارش های قابل طراحی ممكن نیست.\n" +
                        "موارد زیر را بررسی نمایید:\n" +
                        "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                }
            }
            #endregion

            DialogResult = DialogResult.OK;
            Dispose();
        }
        #endregion

        #endregion

        #region Methods

        #region Boolean FillcBoxFields()
        /// <summary>
        /// پر كردن كومبوباكس فیلد های قابل انتخاب
        /// </summary>
        /// <returns>صحت انجام كار</returns>
        private Boolean FillcBoxFields()
        {
            _FormulaDataSource = new Dictionary<String, String>();
            foreach (ReportHelper.Column Column in ReportHelper.ColumnsList)
                if (Column.IsAdditionalInformation) _FormulaDataSource.Add(Column.ColumnName, Column.ColumnDescription);
            cBoxFields.DataSource = _FormulaDataSource.ToList();
            cBoxFields.DisplayMember = "Value";
            cBoxFields.ValueMember = "Key";
            txtResult.CompilerSettings.KeywordColor = Color.Teal;
            foreach (KeyValuePair<String, String> Item in _FormulaDataSource)
                txtResult.CompilerSettings.Keywords.Add(Item.Value);
            txtResult.CompileKeywords();
            return true;
        }
        #endregion

        #region Boolean FillSelectedColumns()
        /// <summary>
        /// تابع خواندن اطلاعات فیلد در حالت ویرایش
        /// </summary>
        private Boolean FillSelectedColumns()
        {
            try
            {
                _CurrentAddinField = DBLayerIMS.Manager.DBML.
                    DesignableReportsAddinCols.Where(Data => Data.ID == _FieldID).First();
                DBLayerIMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, _CurrentAddinField);
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "ارتباط با بانك اطلاعاتی ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Reports Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion
            String FormulaText = _CurrentAddinField.FieldFormula;
            foreach (KeyValuePair<String, String> item in _FormulaDataSource.OrderByDescending(Data => Data.Key.Length))
                if (FormulaText.Contains(item.Key))
                    FormulaText = FormulaText.Replace(item.Key, item.Value);
            txtResult.Text = FormulaText + " ";
            txtName.Text = _CurrentAddinField.Title;
            return true;
        }
        #endregion

        #region Boolean CheckVeracity(String Formula)
        /// <summary>
        /// تابع چك كردن صحت فرمول تعریف شده توسط كاربر
        /// </summary>
        /// <returns>صحت انجام كار</returns>
        private Boolean CheckVeracity(String Formula)
        {
            foreach (KeyValuePair<String, String> item in _FormulaDataSource.OrderByDescending(Data => Data.Value.Length))
                if (Formula.Contains(item.Value))
                    Formula = Formula.Replace(item.Value, " 500 ");
            if (!TestFormula(Formula)) return false;
            foreach (KeyValuePair<String, String> item in _FormulaDataSource.OrderByDescending(Data => Data.Value.Length))
                if (Formula.Contains(item.Value)) Formula = Formula.Replace(item.Value, " 0 ");
            if (!TestFormula(Formula)) return false;
            return true;
        }
        #endregion

        #region String CreateFormulaXMLFile(String Formula)
        /// <summary>
        /// تابع جایگذاری عبارات اصلی فرمول های وارد شده
        /// </summary>
        private String CreateFormulaXMLFile(String Formula)
        {
            DataTable _SelectedFieldsDataTable = new DataTable("SelectedFields");
            _SelectedFieldsDataTable.Columns.Add("FieldsName", typeof(String));
            foreach (KeyValuePair<String, String> item in _FormulaDataSource.OrderByDescending(Data => Data.Value.Length))
                if (Formula.Contains(item.Value))
                {
                    Formula = Formula.Replace(item.Value, item.Key);
                    _SelectedFieldsDataTable.Rows.Add(item.Key);
                }
            StringWriter writer = new StringWriter();
            _SelectedFieldsDataTable.WriteXml(writer, true);
            return writer.GetStringBuilder().ToString();
        }
        #endregion

        #region String MakeCorrectFormulaText(String Formula)
        /// <summary>
        /// تابعی برای اصلاح علائم تقسیم و ضرب
        /// </summary>
        private static String MakeCorrectFormulaText(String Formula)
        {
            if (Formula.Contains("×") || Formula.Contains("÷"))
            {
                Formula = Formula.Replace("×", "*");
                Formula = Formula.Replace("÷", "/");
            }
            return Formula.Trim();
        }
        #endregion

        #region Boolean TestFormula(String Formula)
        /// <summary>
        /// تابع تست فرمول بر اساس فرمان تولید شده
        /// </summary>
        private static Boolean TestFormula(String Formula)
        {
            String _SearchCommand = "DECLARE @Result BIGINT; " + "DECLARE @ParamDefinition NVARCHAR(50); " +
                "DECLARE @Formula NVARCHAR(MAX); " + "SET @Formula = 'SET @Result = " + Formula + ";' " +
                "SET @ParamDefinition = N'@Result BIGINT OUTPUT'; " +
                "EXECUTE SP_EXECUTESQL @Formula, @ParamDefinition, @Result = @Result OUTPUT; " + "SELECT @Result; ";
            DataTable TempDataTable = DBLayerIMS.Manager.ExecuteQuery(_SearchCommand, 10);
            if (TempDataTable == null) return false;
            return true;
        }
        #endregion

        #endregion

    }
}