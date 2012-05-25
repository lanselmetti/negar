#region using
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Negar;
using Negar.GridPrinting;
using DevComponents.DotNetBar;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Settings.Insurances.Properties;
#endregion

namespace Sepehr.Settings.Insurances.InsurancesServices
{
    /// <summary>
    /// فرم مدیریت قیمت های خدمات بیمه ها
    /// </summary>
    internal partial class frmServicesCoverage : Form
    {

        #region Fields

        #region Int16 _CurrentInsID
        /// <summary>
        /// كلید بیمه جاری جهت ارتباط به خدمات
        /// </summary>
        private readonly Int16 _CurrentInsID;
        #endregion

        #region List<SP_SelectServicesListResult> _DataSource
        /// <summary>
        /// فیلد منبع داده فرم
        /// </summary>
        private List<SP_SelectServicesListResult> _DataSource;
        #endregion

        #region List<AdditionalPriceData> _AdditionalPrices
        /// <summary>
        /// شی ء مدیریت قیمت های اضافی
        /// </summary>
        private List<AdditionalPriceColumn> _AdditionalPrices;
        #endregion

        #region frmAutoCalculation _AutoCalcForm
        private frmAutoCalculation _AutoCalcForm;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده كلاس جهت ویرایش یك ردیف
        /// </summary>
        /// <param name="InsID">كلید جدول</param>
        public frmServicesCoverage(Int16 InsID)
        {
            InitializeComponent();
            Col1FreePrice.Name = "1FreePrice";
            Col2GovPrice.Name = "2GovPrice";
            dgvData.AutoGenerateColumns = false;
            _CurrentInsID = InsID;
            txtInsName.Text = DBLayerIMS.Insurance.InsFullList.
                Where(Data => Data.ID == _CurrentInsID).Select(Data => Data.Name).First();
            if (!FillDataSource()) { Close(); return; }
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            if (!GenerateAdditionalColumns() || !FillAdditionalColumns() || !FillInsServicesData()) { Close(); return; }
            SetControlsToolTipTexts();
        }
        #endregion

        #region dgvData_CellMouseClick
        private void dgvData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.ColumnIndex == ColCoverage.Index && e.RowIndex > 0)
            {
                if (dgvData[e.ColumnIndex, e.RowIndex].Value == null ||
                    !Convert.ToBoolean(dgvData[e.ColumnIndex, e.RowIndex].Value))
                    dgvData[e.ColumnIndex, e.RowIndex].Value = true;
                else dgvData[e.ColumnIndex, e.RowIndex].Value = false;
                dgvData.EndEdit();
            }
        }
        #endregion

        #region dgvData_CellBeginEdit
        private void dgvData_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == ColCoverage.Index) return;
            if (dgvData[ColCoverage.Index, e.RowIndex].Value == null ||
                Convert.ToBoolean(dgvData[ColCoverage.Index, e.RowIndex].Value) == false)
                e.Cancel = true;
        }
        #endregion

        #region dgvData_CellFormatting
        private void dgvData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (e.ColumnIndex == ColPatientPart.Index)
            {
                Int32 InsPriceValue = Convert.ToInt32(NullCorrection(dgvData.Rows[e.RowIndex].Cells[ColInsPrice.Index].Value));
                Int32 InsPartValue = Convert.ToInt32(NullCorrection(dgvData.Rows[e.RowIndex].Cells[ColInsPart.Index].Value));
                e.Value = Math.Abs(InsPriceValue - InsPartValue);
            }
        }
        #endregion

        #region dgvData_CellValidating
        private void dgvData_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == ColInsPart.Index)
            {
                Int32 InsPartValue;
                Int32.TryParse(e.FormattedValue.ToString().Trim(), NumberStyles.AllowThousands, null, out InsPartValue);
                Int32 InsPriceValue = Convert.ToInt32(NullCorrection(dgvData.Rows[e.RowIndex].Cells[ColInsPrice.Index].Value));
                if (InsPriceValue < InsPartValue)
                {
                    PMBox.Show("امكان ثبت سهم بیمه ، بزرگتر از قیمت بیمه وجود ندارد!", "خطا!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                    return;
                }
            }
        }
        #endregion

        #region dgvData_CellValueChanged
        private void dgvData_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (e.ColumnIndex == ColInsPrice.Index)
            {
                dgvData.CellValueChanged -= dgvData_CellValueChanged;
                Int32 InsPriceValue = Convert.ToInt32(
                    NullCorrection(dgvData.Rows[e.RowIndex].Cells[ColInsPrice.Index].Value));
                Int32 InsPartValue = 0;
                try
                {
                    InsPartValue = InsPriceValue * (100 - DBLayerIMS.Insurance.InsFullList.
                    Where(Data => Data.ID == _CurrentInsID).First().PatientPercent.Value) / 100;
                }
                catch { }
                dgvData.Rows[e.RowIndex].Cells[ColInsPart.Index].Value = InsPartValue;
                dgvData.CellValueChanged += dgvData_CellValueChanged;
            }
            else if (e.ColumnIndex == ColCoverage.Index)
            {
                if (dgvData.Rows[e.RowIndex].Cells[ColCoverage.Index].Value == null ||
                    Convert.ToBoolean(dgvData.Rows[e.RowIndex].Cells[ColCoverage.Index].Value) == false)
                {
                    dgvData.CellValueChanged -= dgvData_CellValueChanged;
                    dgvData.Rows[e.RowIndex].Cells[ColInsPrice.Index].Value = null;
                    dgvData.Rows[e.RowIndex].Cells[ColInsPart.Index].Value = null;
                    dgvData.CellValueChanged += dgvData_CellValueChanged;
                }
                dgvData.EndEdit();
            }
            dgvData.Invalidate();
        }
        #endregion

        #region btnAllAndNone_Click
        private void btnAllAndNone_Click(object sender, EventArgs e)
        {
            if (((ButtonX)sender).Name == "btnAll")
                foreach (DataGridViewRow row in dgvData.Rows) row.Cells[ColCoverage.Index].Value = true;
            else foreach (DataGridViewRow row in dgvData.Rows) row.Cells[ColCoverage.Index].Value = false;
        }
        #endregion

        #region btnAutoCalculation_Click
        private void btnAutoCalculation_Click(object sender, EventArgs e)
        {
            if (_AutoCalcForm == null || _AutoCalcForm.IsDisposed) _AutoCalcForm = new frmAutoCalculation(_CurrentInsID);
            _AutoCalcForm.ShowDialog();
            if (_AutoCalcForm.DialogResult != DialogResult.OK) return;

            dgvData.CellValueChanged += dgvData_CellValueChanged;
            #region Declare Base Variables
            // فیلتر برای انتخاب خدمات تحت پوشش یا فاقد پوشش یا همه خدمات
            Int16 Coverage = Convert.ToInt16(_AutoCalcForm.cboCoverage.SelectedIndex);
            // نوع خدمات انتخاب شده برای فیلتر سازی
            Int32 FilteredCategory = 0;
            if (_AutoCalcForm.cboCategory.SelectedValue != null)
                FilteredCategory = Convert.ToInt32(_AutoCalcForm.cboCategory.SelectedValue);
            // ستون انتخاب شده برای جایگزینی در ستون "قیمت بیمه" برای خدمات
            String SelectedInsPriceColumn = _AutoCalcForm.cbo11.SelectedValue.ToString();
            // درصد قیمت پایه برای سهم بیمه
            Double InsPartPercent = _AutoCalcForm.txt21.Value;
            // ستون قیمتی انتخاب شده برای قیمت پایه سهم بیمه
            String SelectedInsPartColumn = _AutoCalcForm.cbo21.SelectedValue.ToString();
            #endregion

            for (Int32 i = 0; i < dgvData.Rows.Count; i++)
            {
                dgvData.Rows[i].Cells[ColInsPrice.Index].Value =
                    NullCorrection(dgvData.Rows[i].Cells[ColInsPrice.Index].Value);
                dgvData.Rows[i].Cells[ColInsPart.Index].Value =
                    NullCorrection(dgvData.Rows[i].Cells[ColInsPart.Index].Value);

                #region Covered & Not Covered Services
                if (Coverage == 0)
                {
                    #region All Categories
                    if (FilteredCategory == 0)
                    {
                        #region Calculate Insurance Price
                        if (SelectedInsPriceColumn == "0Zero") dgvData.Rows[i].Cells["ColInsPrice"].Value = 0;
                        else dgvData.Rows[i].Cells["ColInsPrice"].Value = dgvData.Rows[i].Cells[SelectedInsPriceColumn].Value;
                        #endregion

                        #region Calculate Insurance Part

                        Double InsertedInsPart;

                        #region First Step
                        if (SelectedInsPartColumn == "0Zero") InsertedInsPart = 0;
                        else InsertedInsPart = Convert.ToDouble(dgvData.Rows[i].Cells[SelectedInsPartColumn].Value) * InsPartPercent / 100;
                        #endregion

                        #region Second Step
                        if (_AutoCalcForm.cBox21.Checked)
                        {
                            Double Percent = _AutoCalcForm.txt22.Value;
                            String Col1 = _AutoCalcForm.cbo22.SelectedValue.ToString();
                            String Col2 = _AutoCalcForm.cbo23.SelectedValue.ToString();
                            if (Col1 == "0Zero" && Col2 != "0Zero")
                            {
                                InsertedInsPart +=
                                    Convert.ToDouble(dgvData.Rows[i].Cells[Col2].Value) * Percent / 100;
                            }
                            else if (Col2 == "0Zero" && Col1 != "0Zero")
                            {
                                InsertedInsPart +=
                                    Convert.ToDouble(dgvData.Rows[i].Cells[Col1].Value) * Percent / 100;
                            }
                            else if (Col1 != "0Zero" && Col2 != "0Zero")
                            {
                                InsertedInsPart +=
                                    Math.Abs(Convert.ToDouble(dgvData.Rows[i].Cells[Col1].Value) -
                                             Convert.ToDouble(dgvData.Rows[i].Cells[Col2].Value)) * Percent / 100;
                            }
                        }
                        #endregion

                        #region Third Step (Rounding)
                        if (_AutoCalcForm.cBox22.Checked)
                        {
                            Int32 RoundingRange = _AutoCalcForm.txt23.Value;
                            Int32 RoundingOrder = _AutoCalcForm.cbo24.SelectedIndex;
                            InsertedInsPart = RoundValue(InsertedInsPart, RoundingRange, RoundingOrder);
                        }
                        #endregion

                        if (InsertedInsPart > Convert.ToInt32(dgvData.Rows[i].Cells[ColInsPrice.Index].Value)) InsertedInsPart = 0;
                        dgvData.Rows[i].Cells[ColInsPart.Index].Value = Convert.ToInt32(InsertedInsPart);

                        #endregion

                        #region Calculate Patient Payable

                        Double InsertPatientPayable = 0;
                        Double PatientPart = Math.Abs(
                            Convert.ToDouble(dgvData.Rows[i].Cells[ColInsPrice.Index].Value) -
                            Convert.ToDouble(dgvData.Rows[i].Cells[ColInsPart.Index].Value));

                        #region Is Patient Payable = Patient Part
                        if (_AutoCalcForm.cBox41.Checked) InsertPatientPayable += PatientPart;
                        #endregion

                        #region Is Patient Payable Have Additional Values
                        if (_AutoCalcForm.cBox42.Checked)
                        {
                            Double Percent = _AutoCalcForm.txt41.Value;
                            String Col1 = _AutoCalcForm.cbo41.SelectedValue.ToString();
                            String Col2 = _AutoCalcForm.cbo42.SelectedValue.ToString();
                            if (Col1 == "0Zero" && Col2 != "0Zero")
                            {
                                InsertPatientPayable +=
                                    Convert.ToDouble(dgvData.Rows[i].Cells[Col2].Value) * Percent / 100;
                            }
                            else if (Col2 == "0Zero" && Col1 != "0Zero")
                            {
                                InsertPatientPayable +=
                                    Convert.ToDouble(dgvData.Rows[i].Cells[Col1].Value) * Percent / 100;
                            }
                            else if (Col1 != "0Zero" && Col2 != "0Zero")
                            {
                                InsertPatientPayable +=
                                    Math.Abs(Convert.ToDouble(dgvData.Rows[i].Cells[Col1].Value) -
                                             Convert.ToDouble(dgvData.Rows[i].Cells[Col2].Value)) * Percent / 100;
                            }
                        }
                        #endregion

                        #region Is Patient Payable Must Rounded
                        if (_AutoCalcForm.cBox43.Checked)
                        {
                            Int32 RoundingRange = _AutoCalcForm.txt42.Value;
                            Int32 RoundingOrder = _AutoCalcForm.cbo43.SelectedIndex;
                            InsertPatientPayable = RoundValue(InsertPatientPayable, RoundingRange, RoundingOrder);
                        }
                        #endregion

                        dgvData.Rows[i].Cells[ColPatientPayble.Index].Value = (Int32)InsertPatientPayable;

                        #endregion
                    }
                    #endregion

                    #region Selected Category
                    else if (((SP_SelectServicesListResult)dgvData.Rows[i].DataBoundItem).CategoryIX != null &&
                        ((SP_SelectServicesListResult)dgvData.Rows[i].DataBoundItem).CategoryIX ==
                        Convert.ToInt16(FilteredCategory))
                    {
                        #region Calculate Insurance Price
                        if (SelectedInsPriceColumn == "0Zero") dgvData.Rows[i].Cells[ColInsPrice.Index].Value = 0;
                        else dgvData.Rows[i].Cells[ColInsPrice.Index].Value = dgvData.Rows[i].Cells[SelectedInsPriceColumn].Value;
                        #endregion

                        #region Calculate Insurance Part

                        Double InsertedInsPart;

                        #region First Step

                        if (SelectedInsPartColumn == "0Zero")
                            InsertedInsPart = 0;
                        else
                            InsertedInsPart = Convert.ToDouble(dgvData.Rows[i].Cells[SelectedInsPartColumn].Value) *
                                              InsPartPercent / 100;

                        #endregion

                        #region Second Step

                        if (_AutoCalcForm.cBox21.Checked)
                        {
                            Double Percent = _AutoCalcForm.txt22.Value;
                            String Col1 = _AutoCalcForm.cbo22.SelectedValue.ToString();
                            String Col2 = _AutoCalcForm.cbo23.SelectedValue.ToString();
                            if (Col1 == "0Zero" && Col2 != "0Zero")
                            {
                                InsertedInsPart +=
                                    Convert.ToDouble(dgvData.Rows[i].Cells[Col2].Value) * Percent / 100;
                            }
                            else if (Col2 == "0Zero" && Col1 != "0Zero")
                            {
                                InsertedInsPart +=
                                    Convert.ToDouble(dgvData.Rows[i].Cells[Col1].Value) * Percent / 100;
                            }
                            else if (Col1 != "0Zero" && Col2 != "0Zero")
                            {
                                InsertedInsPart +=
                                    Math.Abs(Convert.ToDouble(dgvData.Rows[i].Cells[Col1].Value) -
                                             Convert.ToDouble(dgvData.Rows[i].Cells[Col2].Value)) * Percent / 100;
                            }
                        }

                        #endregion

                        #region Third Step (Rounding)

                        if (_AutoCalcForm.cBox22.Checked)
                        {
                            Int32 RoundingRange = _AutoCalcForm.txt23.Value;
                            Int32 RoundingOrder = _AutoCalcForm.cbo24.SelectedIndex;
                            InsertedInsPart = RoundValue(InsertedInsPart, RoundingRange, RoundingOrder);
                        }

                        #endregion

                        if (InsertedInsPart > (Int32)dgvData.Rows[i].Cells[ColInsPrice.Index].Value)
                            InsertedInsPart = 0;
                        dgvData.Rows[i].Cells[ColInsPart.Index].Value = Convert.ToInt32(InsertedInsPart);

                        #endregion

                        #region Calculate Patient Payable

                        Double InsertPatientPayable = 0;
                        Double PatientPart = Math.Abs(Convert.ToDouble(dgvData.Rows[i].Cells[ColInsPrice.Index].Value) -
                            Convert.ToDouble(dgvData.Rows[i].Cells[ColInsPart.Index].Value));

                        #region Is Patient Payable = Patient Part
                        if (_AutoCalcForm.cBox41.Checked) InsertPatientPayable += PatientPart;
                        #endregion

                        #region Is Patient Payable Have Additional Values
                        if (_AutoCalcForm.cBox42.Checked)
                        {
                            Double Percent = _AutoCalcForm.txt41.Value;
                            String Col1 = _AutoCalcForm.cbo41.SelectedValue.ToString();
                            String Col2 = _AutoCalcForm.cbo42.SelectedValue.ToString();
                            if (Col1 == "0Zero" && Col2 != "0Zero")
                            {
                                InsertPatientPayable +=
                                    Convert.ToDouble(dgvData.Rows[i].Cells[Col2].Value) * Percent / 100;
                            }
                            else if (Col2 == "0Zero" && Col1 != "0Zero")
                            {
                                InsertPatientPayable +=
                                    Convert.ToDouble(dgvData.Rows[i].Cells[Col1].Value) * Percent / 100;
                            }
                            else if (Col1 != "0Zero" && Col2 != "0Zero")
                            {
                                InsertPatientPayable +=
                                    Math.Abs(Convert.ToDouble(dgvData.Rows[i].Cells[Col1].Value) -
                                             Convert.ToDouble(dgvData.Rows[i].Cells[Col2].Value)) * Percent / 100;
                            }
                        }
                        #endregion

                        #region Is Patient Payable Must Rounded

                        if (_AutoCalcForm.cBox43.Checked)
                        {
                            Int32 RoundingRange = _AutoCalcForm.txt42.Value;
                            Int32 RoundingOrder = _AutoCalcForm.cbo43.SelectedIndex;
                            InsertPatientPayable = RoundValue(InsertPatientPayable, RoundingRange, RoundingOrder);
                        }

                        #endregion

                        dgvData.Rows[i].Cells[ColPatientPayble.Index].Value = (Int32)InsertPatientPayable;

                        #endregion
                    }
                    #endregion
                }
                #endregion

                #region Covered Services
                else if (Coverage == 1 && dgvData.Rows[i].Cells[ColCoverage.Index].Value != null &&
                    Convert.ToBoolean(dgvData.Rows[i].Cells[ColCoverage.Index].Value))
                {
                    #region All Categories
                    if (FilteredCategory == 0)
                    {
                        #region Calculate Insurance Price
                        if (SelectedInsPriceColumn == "0Zero") dgvData.Rows[i].Cells[ColInsPrice.Index].Value = 0;
                        else dgvData.Rows[i].Cells[ColInsPrice.Index].Value = dgvData.Rows[i].Cells[SelectedInsPriceColumn].Value;
                        #endregion

                        #region Calculate Insurance Part

                        Double InsertedInsPart;

                        #region First Step
                        if (SelectedInsPartColumn == "0Zero") InsertedInsPart = 0;
                        else InsertedInsPart =
                                Convert.ToDouble(NullCorrection(dgvData.Rows[i].Cells[SelectedInsPartColumn].Value)) *
                                InsPartPercent / 100;
                        #endregion

                        #region Second Step
                        if (_AutoCalcForm.cBox21.Checked)
                        {
                            Double Percent = _AutoCalcForm.txt22.Value;
                            String Col1 = _AutoCalcForm.cbo22.SelectedValue.ToString();
                            String Col2 = _AutoCalcForm.cbo23.SelectedValue.ToString();
                            if (Col1 == "0Zero" && Col2 != "0Zero")
                                InsertedInsPart += Convert.ToDouble(dgvData.Rows[i].Cells[Col2].Value) * Percent / 100;
                            else if (Col2 == "0Zero" && Col1 != "0Zero")
                                InsertedInsPart += Convert.ToDouble(dgvData.Rows[i].Cells[Col1].Value) * Percent / 100;
                            else if (Col1 != "0Zero" && Col2 != "0Zero")
                                InsertedInsPart += Math.Abs(Convert.ToDouble(dgvData.Rows[i].Cells[Col1].Value) -
                                    Convert.ToDouble(dgvData.Rows[i].Cells[Col2].Value)) * Percent / 100;
                        }
                        #endregion

                        #region Third Step (Rounding)
                        if (_AutoCalcForm.cBox22.Checked)
                        {
                            Int32 RoundingRange = _AutoCalcForm.txt23.Value;
                            Int32 RoundingOrder = _AutoCalcForm.cbo24.SelectedIndex;
                            InsertedInsPart = RoundValue(InsertedInsPart, RoundingRange, RoundingOrder);
                        }
                        #endregion

                        if (InsertedInsPart > (Int32)NullCorrection(dgvData.Rows[i].Cells[ColInsPrice.Index].Value))
                            InsertedInsPart = 0;
                        dgvData.Rows[i].Cells[ColInsPart.Index].Value = Convert.ToInt32(InsertedInsPart);

                        #endregion

                        #region Calculate Patient Payable

                        Double InsertPatientPayable = 0;
                        Double PatientPart = Math.Abs(
                            Convert.ToDouble(NullCorrection(dgvData.Rows[i].Cells[ColInsPrice.Index].Value)) -
                            Convert.ToDouble(NullCorrection(dgvData.Rows[i].Cells[ColInsPart.Index].Value)));

                        dgvData.Invalidate();

                        #region Is Patient Payable = Patient Part
                        if (_AutoCalcForm.cBox41.Checked)
                            InsertPatientPayable += PatientPart;
                        #endregion

                        #region Is Patient Payable Have Additional Values
                        if (_AutoCalcForm.cBox42.Checked)
                        {
                            Double Percent = _AutoCalcForm.txt41.Value;
                            String Col1 = _AutoCalcForm.cbo41.SelectedValue.ToString();
                            String Col2 = _AutoCalcForm.cbo42.SelectedValue.ToString();
                            if (Col1 == "0Zero" && Col2 != "0Zero")
                            {
                                InsertPatientPayable +=
                                    Convert.ToDouble(dgvData.Rows[i].Cells[Col2].Value) * Percent / 100;
                            }
                            else if (Col2 == "0Zero" && Col1 != "0Zero")
                            {
                                InsertPatientPayable +=
                                    Convert.ToDouble(dgvData.Rows[i].Cells[Col1].Value) * Percent / 100;
                            }
                            else if (Col1 != "0Zero" && Col2 != "0Zero")
                            {
                                InsertPatientPayable +=
                                    Math.Abs(Convert.ToDouble(dgvData.Rows[i].Cells[Col1].Value) -
                                             Convert.ToDouble(dgvData.Rows[i].Cells[Col2].Value)) * Percent / 100;
                            }
                        }

                        #endregion

                        #region Is Patient Payable Must Rounded
                        if (_AutoCalcForm.cBox43.Checked)
                        {
                            Int32 RoundingRange = _AutoCalcForm.txt42.Value;
                            Int32 RoundingOrder = _AutoCalcForm.cbo43.SelectedIndex;
                            InsertPatientPayable = RoundValue(InsertPatientPayable, RoundingRange, RoundingOrder);
                        }
                        #endregion

                        dgvData.Rows[i].Cells[ColPatientPayble.Index].Value = (Int32)InsertPatientPayable;

                        #endregion
                    }
                    #endregion

                    #region Selected Category
                    else if (dgvData.Rows[i].Cells["CategoryIX"].Value != null &&
                             (Int16)dgvData.Rows[i].Cells["CategoryIX"].Value == (Int16)FilteredCategory)
                    {
                        #region Calculate Insurance Price

                        if (SelectedInsPriceColumn == "0Zero") dgvData.Rows[i].Cells[ColInsPrice.Index].Value = 0;
                        else dgvData.Rows[i].Cells[ColInsPrice.Index].Value = dgvData.Rows[i].Cells[SelectedInsPriceColumn].Value;

                        #endregion

                        #region Calculate Insurance Part

                        Double InsertedInsPart;

                        #region First Step
                        if (SelectedInsPartColumn == "0Zero") InsertedInsPart = 0;
                        else InsertedInsPart = Convert.ToDouble(dgvData.Rows[i].Cells[SelectedInsPartColumn].Value) * InsPartPercent / 100;
                        #endregion

                        #region Second Step
                        if (_AutoCalcForm.cBox21.Checked)
                        {
                            Double Percent = _AutoCalcForm.txt22.Value;
                            String Col1 = _AutoCalcForm.cbo22.SelectedValue.ToString();
                            String Col2 = _AutoCalcForm.cbo23.SelectedValue.ToString();
                            if (Col1 == "0Zero" && Col2 != "0Zero")
                            {
                                InsertedInsPart +=
                                    Convert.ToDouble(dgvData.Rows[i].Cells[Col2].Value) * Percent / 100;
                            }
                            else if (Col2 == "0Zero" && Col1 != "0Zero")
                            {
                                InsertedInsPart +=
                                    Convert.ToDouble(dgvData.Rows[i].Cells[Col1].Value) * Percent / 100;
                            }
                            else if (Col1 != "0Zero" && Col2 != "0Zero")
                            {
                                InsertedInsPart +=
                                    Math.Abs(Convert.ToDouble(dgvData.Rows[i].Cells[Col1].Value) -
                                             Convert.ToDouble(dgvData.Rows[i].Cells[Col2].Value)) * Percent / 100;
                            }
                        }
                        #endregion

                        #region Third Step (Rounding)

                        if (_AutoCalcForm.cBox22.Checked)
                        {
                            Int32 RoundingRange = _AutoCalcForm.txt23.Value;
                            Int32 RoundingOrder = _AutoCalcForm.cbo24.SelectedIndex;
                            InsertedInsPart = RoundValue(InsertedInsPart, RoundingRange, RoundingOrder);
                        }

                        #endregion

                        if (InsertedInsPart > Convert.ToInt32(dgvData.Rows[i].Cells[ColInsPrice.Index].Value)) InsertedInsPart = 0;
                        dgvData.Rows[i].Cells[ColInsPart.Index].Value = Convert.ToInt32(InsertedInsPart);

                        #endregion

                        #region Calculate Patient Payable
                        Double InsertPatientPayable = 0;
                        Double PatientPart = Math.Abs(Convert.ToDouble(dgvData.Rows[i].Cells[ColInsPrice.Index].Value) -
                            Convert.ToDouble(dgvData.Rows[i].Cells[ColInsPart.Index].Value));

                        #region Is Patient Payable = Patient Part
                        if (_AutoCalcForm.cBox41.Checked) InsertPatientPayable += PatientPart;
                        #endregion

                        #region Is Patient Payable Have Additional Values

                        if (_AutoCalcForm.cBox42.Checked)
                        {
                            Double Percent = _AutoCalcForm.txt41.Value;
                            String Col1 = _AutoCalcForm.cbo41.SelectedValue.ToString();
                            String Col2 = _AutoCalcForm.cbo42.SelectedValue.ToString();
                            if (Col1 == "0Zero" && Col2 != "0Zero")
                            {
                                InsertPatientPayable +=
                                    Convert.ToDouble(dgvData.Rows[i].Cells[Col2].Value) * Percent / 100;
                            }
                            else if (Col2 == "0Zero" && Col1 != "0Zero")
                            {
                                InsertPatientPayable +=
                                    Convert.ToDouble(dgvData.Rows[i].Cells[Col1].Value) * Percent / 100;
                            }
                            else if (Col1 != "0Zero" && Col2 != "0Zero")
                            {
                                InsertPatientPayable +=
                                    Math.Abs(Convert.ToDouble(dgvData.Rows[i].Cells[Col1].Value) -
                                             Convert.ToDouble(dgvData.Rows[i].Cells[Col2].Value)) * Percent / 100;
                            }
                        }

                        #endregion

                        #region Is Patient Payable Must Rounded

                        if (_AutoCalcForm.cBox43.Checked)
                        {
                            Int32 RoundingRange = _AutoCalcForm.txt42.Value;
                            Int32 RoundingOrder = _AutoCalcForm.cbo43.SelectedIndex;
                            InsertPatientPayable = RoundValue(InsertPatientPayable, RoundingRange, RoundingOrder);
                        }

                        #endregion

                        dgvData.Rows[i].Cells[ColPatientPayble.Index].Value = Convert.ToInt32(InsertPatientPayable);

                        #endregion
                    }
                    #endregion
                }
                #endregion

                #region Not Covered Services
                else if (Coverage == 2 && (dgvData.Rows[i].Cells[ColCoverage.Index].Value != null ||
                    Convert.ToBoolean(dgvData.Rows[i].Cells[ColCoverage.Index].Value) == false))
                {
                    #region All Categories

                    if (FilteredCategory == 0)
                    {
                        #region Calculate Insurance Price
                        if (SelectedInsPriceColumn == "0Zero") dgvData.Rows[i].Cells[ColInsPrice.Index].Value = 0;
                        else dgvData.Rows[i].Cells[ColInsPrice.Index].Value = dgvData.Rows[i].Cells[SelectedInsPriceColumn].Value;
                        #endregion

                        #region Calculate Insurance Part

                        Double InsertedInsPart;

                        #region First Step
                        if (SelectedInsPartColumn == "0Zero") InsertedInsPart = 0;
                        else InsertedInsPart = Convert.ToDouble(dgvData.Rows[i].Cells[SelectedInsPartColumn].Value) * InsPartPercent / 100;
                        #endregion

                        #region Second Step
                        if (_AutoCalcForm.cBox21.Checked)
                        {
                            Double Percent = _AutoCalcForm.txt22.Value;
                            String Col1 = _AutoCalcForm.cbo22.SelectedValue.ToString();
                            String Col2 = _AutoCalcForm.cbo23.SelectedValue.ToString();
                            if (Col1 == "0Zero" && Col2 != "0Zero")
                            {
                                InsertedInsPart +=
                                    Convert.ToDouble(dgvData.Rows[i].Cells[Col2].Value) * Percent / 100;
                            }
                            else if (Col2 == "0Zero" && Col1 != "0Zero")
                            {
                                InsertedInsPart +=
                                    Convert.ToDouble(dgvData.Rows[i].Cells[Col1].Value) * Percent / 100;
                            }
                            else if (Col1 != "0Zero" && Col2 != "0Zero")
                            {
                                InsertedInsPart +=
                                    Math.Abs(Convert.ToDouble(dgvData.Rows[i].Cells[Col1].Value) -
                                             Convert.ToDouble(dgvData.Rows[i].Cells[Col2].Value)) * Percent / 100;
                            }
                        }
                        #endregion

                        #region Third Step (Rounding)
                        if (_AutoCalcForm.cBox22.Checked)
                        {
                            Int32 RoundingRange = _AutoCalcForm.txt23.Value;
                            Int32 RoundingOrder = _AutoCalcForm.cbo24.SelectedIndex;
                            InsertedInsPart = RoundValue(InsertedInsPart, RoundingRange, RoundingOrder);
                        }
                        #endregion

                        if (InsertedInsPart > (Int32)dgvData.Rows[i].Cells[ColInsPrice.Index].Value)
                            InsertedInsPart = 0;
                        dgvData.Rows[i].Cells[ColInsPart.Index].Value = Convert.ToInt32(InsertedInsPart);

                        #endregion

                        #region Calculate Patient Payable
                        Double InsertPatientPayable = 0;
                        Double PatientPart = Math.Abs(Convert.ToDouble(dgvData.Rows[i].Cells[ColInsPrice.Index].Value) -
                            Convert.ToDouble(dgvData.Rows[i].Cells[ColInsPart.Index].Value));

                        #region Is Patient Payable = Patient Part
                        if (_AutoCalcForm.cBox41.Checked) InsertPatientPayable += PatientPart;
                        #endregion

                        #region Is Patient Payable Have Additional Values

                        if (_AutoCalcForm.cBox42.Checked)
                        {
                            Double Percent = _AutoCalcForm.txt41.Value;
                            String Col1 = _AutoCalcForm.cbo41.SelectedValue.ToString();
                            String Col2 = _AutoCalcForm.cbo42.SelectedValue.ToString();
                            if (Col1 == "0Zero" && Col2 != "0Zero")
                            {
                                InsertPatientPayable +=
                                    Convert.ToDouble(dgvData.Rows[i].Cells[Col2].Value) * Percent / 100;
                            }
                            else if (Col2 == "0Zero" && Col1 != "0Zero")
                            {
                                InsertPatientPayable +=
                                    Convert.ToDouble(dgvData.Rows[i].Cells[Col1].Value) * Percent / 100;
                            }
                            else if (Col1 != "0Zero" && Col2 != "0Zero")
                            {
                                InsertPatientPayable +=
                                    Math.Abs(Convert.ToDouble(dgvData.Rows[i].Cells[Col1].Value) -
                                             Convert.ToDouble(dgvData.Rows[i].Cells[Col2].Value)) * Percent / 100;
                            }
                        }
                        #endregion

                        #region Is Patient Payable Must Rounded

                        if (_AutoCalcForm.cBox43.Checked)
                        {
                            Int32 RoundingRange = _AutoCalcForm.txt42.Value;
                            Int32 RoundingOrder = _AutoCalcForm.cbo43.SelectedIndex;
                            InsertPatientPayable = RoundValue(InsertPatientPayable, RoundingRange, RoundingOrder);
                        }

                        #endregion

                        dgvData.Rows[i].Cells[ColPatientPayble.Index].Value = Convert.ToInt32(InsertPatientPayable);

                        #endregion
                    }
                    #endregion

                    #region Selected Category
                    else if (dgvData.Rows[i].Cells[CategoryIX.Index].Value != null &&
                        Convert.ToInt16(dgvData.Rows[i].Cells[CategoryIX.Index].Value) == Convert.ToInt16(FilteredCategory))
                    {
                        #region Calculate Insurance Price
                        if (SelectedInsPriceColumn == "0Zero") dgvData.Rows[i].Cells[ColInsPrice.Index].Value = 0;
                        else dgvData.Rows[i].Cells[ColInsPrice.Index].Value = dgvData.Rows[i].Cells[SelectedInsPriceColumn].Value;
                        #endregion

                        #region Calculate Insurance Part

                        Double InsertedInsPart;

                        #region First Step
                        if (SelectedInsPartColumn == "0Zero") InsertedInsPart = 0;
                        else InsertedInsPart = Convert.ToDouble(dgvData.Rows[i].Cells[SelectedInsPartColumn].Value) * InsPartPercent / 100;
                        #endregion

                        #region Second Step

                        if (_AutoCalcForm.cBox21.Checked)
                        {
                            Double Percent = _AutoCalcForm.txt22.Value;
                            String Col1 = _AutoCalcForm.cbo22.SelectedValue.ToString();
                            String Col2 = _AutoCalcForm.cbo23.SelectedValue.ToString();
                            if (Col1 == "0Zero" && Col2 != "0Zero")
                            {
                                InsertedInsPart += Convert.ToDouble(dgvData.Rows[i].Cells[Col2].Value) * Percent / 100;
                            }
                            else if (Col2 == "0Zero" && Col1 != "0Zero")
                            {
                                InsertedInsPart += Convert.ToDouble(dgvData.Rows[i].Cells[Col1].Value) * Percent / 100;
                            }
                            else if (Col1 != "0Zero" && Col2 != "0Zero")
                            {
                                InsertedInsPart += Math.Abs(Convert.ToDouble(dgvData.Rows[i].Cells[Col1].Value) -
                                    Convert.ToDouble(dgvData.Rows[i].Cells[Col2].Value)) * Percent / 100;
                            }
                        }
                        #endregion

                        #region Third Step (Rounding)

                        if (_AutoCalcForm.cBox22.Checked)
                        {
                            Int32 RoundingRange = _AutoCalcForm.txt23.Value;
                            Int32 RoundingOrder = _AutoCalcForm.cbo24.SelectedIndex;
                            InsertedInsPart = RoundValue(InsertedInsPart, RoundingRange, RoundingOrder);
                        }

                        #endregion
                        if (InsertedInsPart > (Int32)dgvData.Rows[i].Cells[ColInsPrice.Index].Value) InsertedInsPart = 0;
                        dgvData.Rows[i].Cells[ColInsPart.Index].Value = Convert.ToInt32(InsertedInsPart);
                        #endregion

                        #region Calculate Patient Payable

                        Double InsertPatientPayable = 0;
                        Double PatientPart = Math.Abs(Convert.ToDouble(dgvData.Rows[i].Cells[ColInsPrice.Index].Value) -
                            Convert.ToDouble(dgvData.Rows[i].Cells[ColInsPart.Index].Value));

                        #region Is Patient Payable = Patient Part
                        if (_AutoCalcForm.cBox41.Checked) InsertPatientPayable += PatientPart;
                        #endregion

                        #region Is Patient Payable Have Additional Values

                        if (_AutoCalcForm.cBox42.Checked)
                        {
                            Double Percent = _AutoCalcForm.txt41.Value;
                            String Col1 = _AutoCalcForm.cbo41.SelectedValue.ToString();
                            String Col2 = _AutoCalcForm.cbo42.SelectedValue.ToString();
                            if (Col1 == "0Zero" && Col2 != "0Zero")
                            {
                                InsertPatientPayable +=
                                    Convert.ToDouble(dgvData.Rows[i].Cells[Col2].Value) * Percent / 100;
                            }
                            else if (Col2 == "0Zero" && Col1 != "0Zero")
                            {
                                InsertPatientPayable +=
                                    Convert.ToDouble(dgvData.Rows[i].Cells[Col1].Value) * Percent / 100;
                            }
                            else if (Col1 != "0Zero" && Col2 != "0Zero")
                            {
                                InsertPatientPayable +=
                                    Math.Abs(Convert.ToDouble(dgvData.Rows[i].Cells[Col1].Value) -
                                             Convert.ToDouble(dgvData.Rows[i].Cells[Col2].Value)) * Percent / 100;
                            }
                        }
                        #endregion

                        #region Is Patient Payable Must Rounded

                        if (_AutoCalcForm.cBox43.Checked)
                        {
                            Int32 RoundingRange = _AutoCalcForm.txt42.Value;
                            Int32 RoundingOrder = _AutoCalcForm.cbo43.SelectedIndex;
                            InsertPatientPayable = RoundValue(InsertPatientPayable, RoundingRange, RoundingOrder);
                        }

                        #endregion

                        dgvData.Rows[i].Cells[ColPatientPayble.Index].Value = (Int32)InsertPatientPayable;

                        #endregion
                    }

                    #endregion
                }
                #endregion
            }
            dgvData.CellValueChanged += dgvData_CellValueChanged;
        }
        #endregion

        #region btnPrintGrid_Click
        private void btnPrintGrid_Click(object sender, EventArgs e)
        {
            new frmReportPreview(dgvData);
        }
        #endregion

        #region btnApply_Click
        private void btnApply_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (!SaveInsServicesData()) DialogResult = DialogResult.Ignore;
            Cursor.Current = Cursors.Default;
        }
        #endregion

        #region btnAccept_Click
        private void btnAccept_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (SaveInsServicesData()) DialogResult = DialogResult.OK;
            else DialogResult = DialogResult.Ignore;
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
            dgvData.EndEdit();
            Cursor.Current = Cursors.Default;
            if (DialogResult == DialogResult.Cancel)
            {
                DialogResult Dr = PMBox.Show("آیا مایلید از فرم خارج شوید؟", "هشدار",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (Dr == DialogResult.No) { e.Cancel = true; return; }
            }
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

            #region btnAll
            String TooltipText = ToolTipManager.GetText("btnAll", "IMS");
            FormToolTip.SetSuperTooltip(btnAll,
                new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                    Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnNone
            TooltipText = ToolTipManager.GetText("btnNone", "IMS");
            FormToolTip.SetSuperTooltip(btnNone,
                new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                    Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnAutoCalculation
            TooltipText = ToolTipManager.GetText("btnInsAutoCalculation", "IMS");
            FormToolTip.SetSuperTooltip(btnAutoCalculation, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                    Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnPrintGrid
            TooltipText = ToolTipManager.GetText("btnPrint", "IMS");
            FormToolTip.SetSuperTooltip(btnPrintGrid, new SuperTooltipInfo(TooltipHeader, TooltipFooter,
                TooltipText, Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnApply
            TooltipText = ToolTipManager.GetText("btnApply", "IMS");
            FormToolTip.SetSuperTooltip(btnApply, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                    Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnHelp
            TooltipText = ToolTipManager.GetText("btnHelp", "IMS");
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

        #region Boolean FillDataSource()
        /// <summary>
        /// خواندن اطلاعات ردیف جاری فرم از بانك و تكمیل خصوصیات كنترل ها بر اساس آن
        /// </summary>
        /// <returns>صحت تكمیل فرم</returns>
        private Boolean FillDataSource()
        {
            _DataSource = DBLayerIMS.Services.ServicesList;
            if (_DataSource == null) return false;
            _DataSource = _DataSource.Where(Data => Data.IsActive).
                OrderBy(Data => Convert.ToInt32(Data.Code)).ToList();
            dgvData.DataSource = _DataSource;
            return true;
        }
        #endregion

        #region Boolean GenerateAdditionalColumns()
        /// <summary>
        /// تابع تولید ستون های قیمت اضافه
        /// </summary>
        private Boolean GenerateAdditionalColumns()
        {
            List<AdditionalPriceColumn> AddinData = DBLayerIMS.Services.ServAddinPriceColsList;
            if (AddinData == null) return false;
            _AdditionalPrices = AddinData.ToList();

            #region Make Columns
            Int32 Index = _AdditionalPrices.Count();
            for (Int32 i = 0; i < Index; i++)
            {
                DataGridViewTextBoxColumn CurrentColumn = new DataGridViewTextBoxColumn();
                CurrentColumn.HeaderText = _AdditionalPrices[i].Name;
                CurrentColumn.ToolTipText = _AdditionalPrices[i].Description;
                CurrentColumn.Name = _AdditionalPrices[i].ColumnName;
                CurrentColumn.Width = 90;
                CurrentColumn.DefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
                CurrentColumn.DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;
                CurrentColumn.DefaultCellStyle.BackColor = Color.LightGray;
                CurrentColumn.DefaultCellStyle.Format = "N0";
                CurrentColumn.DefaultCellStyle.NullValue = "0";
                CurrentColumn.DisplayIndex = (10 + i);
                CurrentColumn.ReadOnly = true;
                dgvData.Columns.Add(CurrentColumn);
            }
            #endregion
            return true;
        }
        #endregion

        #region Boolean FillAdditionalColumns()
        /// <summary>
        /// تابع تكمیل ستون های قیمت اضافه
        /// </summary>
        private Boolean FillAdditionalColumns()
        {
            if (_AdditionalPrices.Count == 0) return true;
            #region Fill DataSet
            DataTable TempDataTable = DBLayerIMS.Manager.ExecuteQuery(
                "EXECUTE [ImagingSystem].[Services].[SP_SelectAdditionalPriceData]", 0);
            if (TempDataTable == null)
            {
                const String ErrorMessage = "امكان خواندن اطلاعات ستون های قیمت اضافه از بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            #endregion

            #region Fill Columns Data
            // پیمایش در سرویس های جدول خدمات فرم
            for (Int32 i = 0; i < dgvData.Rows.Count; i++)
            {
                // بدست آوردن كلید سرویس جاری
                Int32? CurrentServiceID = ((SP_SelectServicesListResult)dgvData.Rows[i].DataBoundItem).ID;
                // خواندن ردیف مورد نظر برای سرویس جاری در حلقه
                DataRow[] AdditionalServicePriceRow = TempDataTable.Select("ServiceIX = " + CurrentServiceID);
                // پر كردن فیلد های موجود برای قیمت های اضافی از بانك در جدول فرم
                if (AdditionalServicePriceRow.Length > 0)
                    // پیمایش بین ستون های قیمت اضافی
                    for (Int32 j = 0; j < _AdditionalPrices.Count; j++)
                    {
                        String ColumName = _AdditionalPrices[j].ColumnName;
                        dgvData.Rows[i].Cells[ColumName].Value = AdditionalServicePriceRow[0][ColumName];
                    }
            }
            #endregion
            return true;
        }
        #endregion

        #region Boolean FillInsServicesData()
        /// <summary>
        /// تابع تكمیل ستون های قیمت اضافه
        /// </summary>
        private Boolean FillInsServicesData()
        {
            #region Fill DataSet
            DataTable TempDataTable = DBLayerIMS.Manager.ExecuteQuery(
                "SELECT * FROM [ImagingSystem].[Insurances].[InsuranceServices] WHERE [InsIX] = " + _CurrentInsID, 0);
            if (TempDataTable == null)
            {
                const String ErrorMessage = "امكان خواندن اطلاعات ستون های قیمت اضافه از بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            #endregion

            #region Remove Other Ins
            for (Int32 i = TempDataTable.Rows.Count - 1; i >= 0; i--)
                if (Convert.ToInt16(TempDataTable.Rows[i]["InsIX"]) != _CurrentInsID)
                    TempDataTable.Rows.RemoveAt(i);
            #endregion

            #region Fill Columns Data
            // پیمایش در سرویس های جدول خدمات فرم
            for (Int32 i = 0; i < dgvData.Rows.Count; i++)
            {
                // بدست آوردن كلید سرویس جاری
                Int32? CurrentServiceID = ((SP_SelectServicesListResult)dgvData.Rows[i].DataBoundItem).ID;
                // خواندن ردیف مورد نظر برای سرویس جاری در حلقه
                //_CurrentInsID
                DataRow[] AdditionalServicePriceRow = TempDataTable.Select("ServiceIX = " + CurrentServiceID);
                if (AdditionalServicePriceRow.Length > 0)
                {
                    dgvData.Rows[i].Cells[ColCoverage.Index].Value = AdditionalServicePriceRow[0]["IsCover"];
                    dgvData.Rows[i].Cells[ColInsPrice.Index].Value = AdditionalServicePriceRow[0]["InsPrice"];
                    dgvData.Rows[i].Cells[ColInsPart.Index].Value = AdditionalServicePriceRow[0]["InsPart"];
                    dgvData.Rows[i].Cells[ColPatientPart.Index].Value = Math.Abs(
                        (Int32)dgvData.Rows[i].Cells[ColInsPrice.Index].Value -
                        (Int32)dgvData.Rows[i].Cells[ColInsPart.Index].Value);
                    dgvData.Rows[i].Cells[ColPatientPayble.Index].Value = AdditionalServicePriceRow[0]["PatientPayable"];
                }
            }
            #endregion
            return true;
        }
        #endregion

        #region Boolean SaveInsServicesData()
        /// <summary>
        /// ذخیره سازی قیمت های اضافی
        /// </summary>
        /// <returns>صحت انجام كار</returns>
        public Boolean SaveInsServicesData()
        {
            Int16 InsID = _CurrentInsID;
            foreach (DataGridViewRow Row in dgvData.Rows)
            {
                if (Row.IsNewRow) continue; // خارج شدن در صورتی كه به ردیف آخر رسیده باشد
                try
                {
                    DBLayerIMS.Manager.DBML.SP_InsertInsuranceServices(InsID,
                        ((SP_SelectServicesListResult)Row.DataBoundItem).ID,
                        Convert.ToBoolean(Row.Cells[ColCoverage.Index].Value),
                        Convert.ToInt32(NullCorrection(Row.Cells[ColInsPrice.Index].Value)), 
                        Convert.ToInt32(NullCorrection(Row.Cells[ColInsPart.Index].Value)),
                        Convert.ToInt32(NullCorrection(Row.Cells[ColPatientPayble.Index].Value)));
                }
                #region Catch
                catch (Exception Ex)
                {
                    const String ErrorMessage =
                        "امكان ثبت اطلاعات پوشش خدمات در بانك اطلاعات ممكن نیست.\n" +
                        "موارد زیر را بررسی نمایید:\n" +
                        "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogManager.SaveLogEntry("Sepehr", "Insurances Settings", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                    return false;
                }
                #endregion
            }
            return true;
        }
        #endregion

        #region static Int32 RoundValue(Double RecievedValue, Int32 RoundingRange, Int32 RoundingOrder)
        /// <summary>
        /// تابع گرد كردن یك مقدار دریافتی
        /// </summary>
        /// <param name="RecievedValue">مقدار وارد شده</param>
        /// <param name="RoundingRange">عدد گرد كردن</param>
        /// <param name="RoundingOrder">نوع گرد</param>
        /// <returns>عدد گرد شده</returns>
        private static Int32 RoundValue(Double RecievedValue, Int32 RoundingRange, Int32 RoundingOrder)
        {
            switch (RoundingOrder)
            {
                #region Floor
                case 0:
                    if (RecievedValue < RoundingRange)
                        RecievedValue = 0;
                    else if (RecievedValue % RoundingRange != 0 &&
                             (RecievedValue % RoundingRange) < RoundingRange)
                        RecievedValue = Convert.ToInt32((Int32)RecievedValue / RoundingRange) * RoundingRange;
                    break;

                #endregion

                #region Top
                case 1:
                    if (RecievedValue < RoundingRange)
                        RecievedValue = RoundingRange;
                    else if (RecievedValue % RoundingRange != 0 &&
                             RecievedValue % RoundingRange < RoundingRange)
                        RecievedValue = (Convert.ToInt32((Int32)RecievedValue / RoundingRange) + 1) * RoundingRange;
                    break;
                #endregion

                #region Round

                case 2:
                    if (Convert.ToInt32(RecievedValue) % RoundingRange < RoundingRange / 2)
                    {
                        if (RecievedValue < RoundingRange) RecievedValue = 0;
                        else if (RecievedValue % RoundingRange != 0 &&
                                 RecievedValue % RoundingRange < RoundingRange)
                            RecievedValue = Convert.ToInt32((Int32)RecievedValue / RoundingRange) * RoundingRange;
                    }
                    else
                    {
                        if (RecievedValue < RoundingRange) RecievedValue = RoundingRange;
                        else if (RecievedValue % RoundingRange != 0 &&
                                 RecievedValue % RoundingRange < RoundingRange)
                            RecievedValue = (Convert.ToInt32((Int32)RecievedValue / RoundingRange) + 1) * RoundingRange;
                    }
                    break;

                #endregion
            }
            return Convert.ToInt32(RecievedValue);
        }
        #endregion

        #region Object NullCorrection(Object Value)
        /// <summary>
        /// تابع تغییر ستون های تهی به صفر
        /// </summary>
        private Object NullCorrection(Object Value)
        {
            if (Value == null || Value == DBNull.Value) return 0;
            return Value;
        }
        #endregion


        #endregion

    }
}