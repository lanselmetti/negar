#region using
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Negar;
using Negar.GridPrinting;
using DevComponents.DotNetBar;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Settings.Services.Properties;
#endregion

namespace Sepehr.Settings.Services
{
    /// <summary>
    /// فرم مدیریت خدمات مراجعات بیماران
    /// </summary>
    public partial class frmServices : Form
    {

        #region Fields

        #region IQueryable<ServicesList> _DataSource
        /// <summary>
        /// فیلد منبع اطلاعاتی فرم
        /// </summary>
        private IQueryable<ServicesList> _DataSource;
        #endregion

        #region List<AdditionalPriceColumn> _AdditionalPriceColumns
        /// <summary>
        /// شی ء مدیریت قیمت های اضافی
        /// </summary>
        private List<AdditionalPriceColumn> _AdditionalPriceColumns;
        #endregion

        #region frmServicesCalculation _ServicesCalcForm
        /// <summary>
        /// نمونه ای از فرم محاسبه خودكار برای یكبار فراخوانی فرم
        /// </summary>
        private frmServicesCalculation _ServicesCalcForm;
        #endregion

        #region Boolean _IsGridValuesChanged
        /// <summary>
        /// تعیین ویرایش شدن فرم توسط كاربر
        /// </summary>
        private Boolean _IsGridValuesChanged;
        #endregion

        #region List<ChangedAddinServiceCells> _ChangedCells
        /// <summary>
        /// لیستی از سلول های ستون های پویا تغییر كرده
        /// </summary>
        private List<ChangedAddinServiceCells> _ChangedCells = new List<ChangedAddinServiceCells>();
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmServices()
        {
            Cursor.Current = Cursors.WaitCursor;
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("Fa-Ir"));
            InitializeComponent();
            Opacity = 0.01;
            dgvData.AutoGenerateColumns = false;
            dgvData.Columns[Col1FreePrice.Index].Name = "1FreePrice";
            dgvData.Columns[Col2GovPrice.Index].Name = "2GovPrice";
            if (!FillServicesListDataSource() || !FillCboCategories()) 
            { _IsGridValuesChanged = false; Close(); return; }
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            if (!GenerateAdditionalColumns() || !FillAddinColsData()) { Close(); return; }
            SetControlsToolTipTexts();
            _IsGridValuesChanged = false;
            dgvData.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            Opacity = 1;
            Cursor.Current = Cursors.Default;
        }
        #endregion

        #region dgvData_DataError
        private void dgvData_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            PMBox.Show("مقدار وارد شده برای ستون مورد نظر معتبر نمی باشد!", "خطا!",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            e.ThrowException = false;
            e.Cancel = true;
        }
        #endregion

        #region dgvData_CellValidating
        private void dgvData_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            #region Check Service Code
            if (e.ColumnIndex == ColCode.Index)
                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    #region Check The Same Service Code

                    // چك كردن وجود كد تكراری
                    if (!row.IsNewRow && row.Cells[e.ColumnIndex].Value != null &&
                        row.Cells[e.ColumnIndex].Value != DBNull.Value &&
                        row.Index != e.RowIndex &&
                        e.FormattedValue != null && e.FormattedValue != DBNull.Value &&
                        row.Cells[e.ColumnIndex].Value.ToString().Trim().ToLower() ==
                        e.FormattedValue.ToString().ToLower())
                    {
                        PMBox.Show("كد وارد شده تكراریست! لطفاً مقدار وارد شده را بررسی نمایید.", "خطا!",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvData.Focus();
                        e.Cancel = true;
                        return;
                    }

                    #endregion

                    #region Check Null For Code

                    if (e.ColumnIndex == ColCode.Index && (e.FormattedValue == null ||
                                                           String.IsNullOrEmpty(e.FormattedValue.ToString())))
                    {
                        PMBox.Show("وارد كردن كد عددی اجباری می باشد! لطفاً مقدار وارد شده را بررسی نمایید.", "خطا!",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvData.Focus();
                        e.Cancel = true;
                        return;
                    }

                    #endregion

                    #region Check Null For Code

                    if (e.ColumnIndex == ColCode.Index)
                        foreach (Char TheChar in e.FormattedValue.ToString())
                            if (!Char.IsDigit(TheChar))
                            {
                                PMBox.Show("وارد كردن كد از نوع عددی اجباری می باشد!\n" +
                                           "لطفاً مقدار وارد شده را بررسی نمایید.", "خطا!", MessageBoxButtons.OK,
                                           MessageBoxIcon.Error);
                                dgvData.Focus();
                                e.Cancel = true;
                                return;
                            }

                    #endregion
                }
            #endregion

            #region Number Check
            //چك كردن عدم ورود حرف در فیلد های عددی
            if (e.ColumnIndex > ColDescription.Index)
                foreach (Char Charecter in e.FormattedValue.ToString().Trim())
                    if (!Char.IsNumber(Charecter) && Charecter != ',')
                    {
                        PMBox.Show("برای این فیلد مقداری عددی وارد نمایید!", "خطا!",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                        return;
                    }
            #endregion

            if (e.ColumnIndex > ColDescription.Index || e.ColumnIndex == Col1FreePrice.Index ||
                e.ColumnIndex == Col2GovPrice.Index)
            {
                Int32 CheckedValue;
                Int32.TryParse(e.FormattedValue.ToString().Trim(), NumberStyles.AllowThousands, null, out CheckedValue);
                dgvData[e.ColumnIndex, e.RowIndex].Value = CheckedValue;
                dgvData.RefreshEdit();
            }
        }
        #endregion

        #region dgvData_CellValueChanged
        private void dgvData_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex > ColDescription.Index)
            {
                Int16 FieldID = Convert.ToInt16(dgvData.Columns[e.ColumnIndex].Tag);
                Int16 ServiceID = ((ServicesList)dgvData.Rows[e.RowIndex].DataBoundItem).ID;
                Int32 Value = 0;
                Object ValObj = dgvData[e.ColumnIndex, e.RowIndex].Value;
                if (ValObj != null && ValObj != DBNull.Value)
                    Int32.TryParse(ValObj.ToString().Trim(), NumberStyles.AllowThousands, null, out Value);
                foreach (ChangedAddinServiceCells cell in _ChangedCells)
                    if (cell.FieldID == FieldID && cell.ServiceID == ServiceID) { cell.Value = Value; return; }
                _ChangedCells.Add(new ChangedAddinServiceCells(ServiceID, FieldID, Value));
                _IsGridValuesChanged = true;
            }
            if (e.RowIndex >= 0 && e.ColumnIndex > ColDescription.Index) _IsGridValuesChanged = true;
        }
        #endregion

        #region dgvData_DefaultValuesNeeded
        private void dgvData_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[0].Value = true;
            e.Row.Cells[1].Value = "";
            e.Row.Cells[2].Value = "نام خدمت";
        }
        #endregion

        #region dgvData_UserAddedRow
        private void dgvData_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            dgvData.AllowUserToAddRows = false;
        }
        #endregion

        #region cBoxWithInActives_CheckedChanged
        private void cBoxWithInActives_CheckedChanged(object sender, EventArgs e)
        {
            #region Check For User Order
            if (_IsGridValuesChanged)
            {
                DialogResult Result = PMBox.Show("شما اطلاعاتی را در جدول خدمات تغییر داده اید.\n" +
                    "در صورت تغییر نمایش آیتم های غیر فعال ، تغییرات وارد شده از دست خواهند رفت.\n" +
                    "آیا مایلید بدون ذخیره سازی اطلاعات جدید نمایش داده شود؟", "هشدار!",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (Result != DialogResult.Yes)
                {
                    cBoxWithInActives.CheckedChanged -= cBoxWithInActives_CheckedChanged;
                    cBoxWithInActives.Checked = !cBoxWithInActives.Checked;
                    cBoxWithInActives.CheckedChanged += cBoxWithInActives_CheckedChanged;
                    return;
                }
            }
            #endregion
            if (cBoxWithInActives.Checked) dgvData.DataSource = _DataSource;
            else dgvData.DataSource = _DataSource.Where(Data => Data.IsActive);
            if (!FillAddinColsData()) { _IsGridValuesChanged = false; Close(); }
            _IsGridValuesChanged = false;
        }
        #endregion

        #region btnAdd_Click
        private void btnAdd_Click(object sender, EventArgs e)
        {
            dgvData.AllowUserToAddRows = true;
            dgvData.Rows[dgvData.Rows.Count - 1].Cells[1].Selected = true;
            dgvData.Focus();
            dgvData.BeginEdit(true);
        }
        #endregion

        #region btnChangeAllServices_Click
        private void btnChangeAllServices_Click(object sender, EventArgs e)
        {
            if (_ServicesCalcForm == null || _ServicesCalcForm.IsDisposed)
                _ServicesCalcForm = new frmServicesCalculation();
            _ServicesCalcForm.ShowDialog();
            if (_ServicesCalcForm.DialogResult == DialogResult.OK)
            {
                // نام سرفصل قیمت انتخاب شده
                String SelectedCol = _ServicesCalcForm.cboColumns.SelectedValue.ToString();
                // انتخاب نوع خدمت
                Int16 SelectedCategory = 0;
                if (_ServicesCalcForm.cboCategory.SelectedValue != null)
                    SelectedCategory = Convert.ToInt16(_ServicesCalcForm.cboCategory.SelectedValue);

                #region Multiply
                if (_ServicesCalcForm.cBox1.Checked)
                {
                    Double MultiplyCount = _ServicesCalcForm.txt1.Value;
                    Int32 UserOrderIndex = _ServicesCalcForm.cbo1.SelectedIndex;
                    String Col2 = _ServicesCalcForm.cbo2.SelectedValue.ToString();

                    switch (UserOrderIndex)
                    {

                        #region Copy
                        case 0:

                            #region Filtered Category
                            if (SelectedCategory != 0)
                            {
                                foreach (DataGridViewRow row in dgvData.Rows)
                                    if (Convert.ToInt16(row.Cells["CategoryIX"].Value) == SelectedCategory)
                                        row.Cells[Col2].Value =
                                            Math.Floor(Convert.ToDouble(row.Cells[SelectedCol].Value) * MultiplyCount);
                            }
                            #endregion

                            #region All Category
                            else
                            {
                                foreach (DataGridViewRow row in dgvData.Rows)
                                    row.Cells[Col2].Value =
                                        Math.Floor(Convert.ToDouble(row.Cells[SelectedCol].Value) * MultiplyCount);
                            }
                            #endregion

                            break;
                        #endregion

                        #region Move
                        case 1:

                            #region Filtered Category
                            if (SelectedCategory != 0)
                            {
                                foreach (DataGridViewRow row in dgvData.Rows)
                                {
                                    if (Convert.ToInt16(row.Cells["CategoryIX"].Value) == SelectedCategory)
                                    {
                                        row.Cells[Col2].Value =
                                            Math.Floor((Convert.ToDouble(row.Cells[SelectedCol].Value)) * MultiplyCount);
                                        row.Cells[SelectedCol].Value = 0;
                                    }
                                }
                            }
                            #endregion

                            #region All Category
                            else
                            {
                                foreach (DataGridViewRow row in dgvData.Rows)
                                {
                                    row.Cells[Col2].Value =
                                        Math.Floor((Convert.ToDouble(row.Cells[SelectedCol].Value)) * MultiplyCount);
                                    row.Cells[SelectedCol].Value = 0;
                                }
                            }
                            #endregion

                            break;
                        #endregion

                        #region Inverse
                        case 2:

                            #region Filtered Category
                            if (SelectedCategory != 0)
                            {
                                foreach (DataGridViewRow row in dgvData.Rows)
                                {
                                    if (Convert.ToInt16(row.Cells["CategoryIX"].Value) == SelectedCategory)
                                    {
                                        Double Temp2 = Convert.ToDouble(row.Cells[Col2].Value);
                                        row.Cells[Col2].Value = row.Cells[SelectedCol].Value;
                                        row.Cells[SelectedCol].Value = Temp2;
                                    }
                                }
                            }
                            #endregion

                            #region All Categories
                            else
                            {
                                foreach (DataGridViewRow row in dgvData.Rows)
                                {
                                    Double Temp2 = Convert.ToDouble(row.Cells[Col2].Value);
                                    row.Cells[Col2].Value = row.Cells[SelectedCol].Value;
                                    row.Cells[SelectedCol].Value = Temp2;
                                }
                            }
                            #endregion

                            break;
                        #endregion

                        #region Make Empty
                        case 3:

                            #region Filtered Category
                            if (SelectedCategory != 0)
                            {
                                foreach (DataGridViewRow row in dgvData.Rows)
                                    if (Convert.ToInt16(row.Cells["CategoryIX"].Value) == SelectedCategory)
                                        row.Cells[SelectedCol].Value = 0;
                            }
                            #endregion

                            #region All Categories
                            else
                            {
                                foreach (DataGridViewRow row in dgvData.Rows)
                                    row.Cells[SelectedCol].Value = 0;
                            }
                            #endregion

                            break;
                        #endregion

                    }
                }
                #endregion

                #region Rounding
                else
                {
                    int RoundingRange = _ServicesCalcForm.txt2.Value;
                    int Order = _ServicesCalcForm.cbo3.SelectedIndex;
                    String TargetColumn = _ServicesCalcForm.cboColumns.SelectedValue.ToString();

                    switch (Order)
                    {

                        #region Floor
                        case 0:

                            #region Filtered Category
                            if (SelectedCategory != 0)
                            {
                                foreach (DataGridViewRow row in dgvData.Rows)
                                    if (Convert.ToInt16(row.Cells["CategoryIX"].Value) == SelectedCategory)
                                    {
                                        int SelectedValue = Convert.ToInt32(row.Cells[TargetColumn].Value);
                                        if (SelectedValue < RoundingRange)
                                            SelectedValue = 0;
                                        else if (SelectedValue % RoundingRange != 0 &&
                                            SelectedValue % RoundingRange < RoundingRange)
                                            SelectedValue = Convert.ToInt32(SelectedValue / RoundingRange) * RoundingRange;
                                        row.Cells[TargetColumn].Value = SelectedValue;
                                    }
                            }
                            #endregion

                            #region All Category
                            else
                            {
                                foreach (DataGridViewRow row in dgvData.Rows)
                                {
                                    int SelectedValue = Convert.ToInt32(row.Cells[TargetColumn].Value);
                                    if (SelectedValue < RoundingRange)
                                        SelectedValue = 0;
                                    else if (SelectedValue % RoundingRange != 0 &&
                                        SelectedValue % RoundingRange < RoundingRange)
                                        SelectedValue = Convert.ToInt32(SelectedValue / RoundingRange) * RoundingRange;
                                    row.Cells[TargetColumn].Value = SelectedValue;
                                }
                            }
                            #endregion

                            break;
                        #endregion

                        #region Top
                        case 1:

                            #region Filtered Category
                            if (SelectedCategory != 0)
                            {
                                foreach (DataGridViewRow row in dgvData.Rows)
                                    if (Convert.ToInt16(row.Cells["CategoryIX"].Value) == SelectedCategory)
                                    {
                                        int SelectedValue = Convert.ToInt32(row.Cells[TargetColumn].Value);
                                        if (SelectedValue < RoundingRange)
                                            SelectedValue = RoundingRange;
                                        else if (SelectedValue % RoundingRange != 0 &&
                                            SelectedValue % RoundingRange < RoundingRange)
                                            SelectedValue = (Convert.ToInt32(SelectedValue / RoundingRange) + 1) * RoundingRange;
                                        row.Cells[TargetColumn].Value = SelectedValue;
                                    }
                            }
                            #endregion

                            #region All Category
                            else
                            {
                                foreach (DataGridViewRow row in dgvData.Rows)
                                {
                                    int SelectedValue = Convert.ToInt32(row.Cells[TargetColumn].Value);
                                    if (SelectedValue < RoundingRange)
                                        SelectedValue = RoundingRange;
                                    else if (SelectedValue % RoundingRange != 0 &&
                                        SelectedValue % RoundingRange < RoundingRange)
                                        SelectedValue = (Convert.ToInt32(SelectedValue / RoundingRange) + 1) * RoundingRange;
                                    row.Cells[TargetColumn].Value = SelectedValue;
                                }
                            }
                            #endregion

                            break;
                        #endregion

                        #region Round
                        case 2:

                            #region Filtered Category
                            if (SelectedCategory != 0)
                            {
                                foreach (DataGridViewRow row in dgvData.Rows)
                                    if (Convert.ToInt16(row.Cells["CategoryIX"].Value) == SelectedCategory)
                                    {
                                        int SelectedValue = Convert.ToInt32(row.Cells[TargetColumn].Value);
                                        if (SelectedValue % RoundingRange < RoundingRange / 2)
                                        {
                                            if (SelectedValue < RoundingRange) SelectedValue = 0;
                                            else if (SelectedValue % RoundingRange != 0 &&
                                                SelectedValue % RoundingRange < RoundingRange)
                                                SelectedValue = Convert.ToInt32(SelectedValue / RoundingRange) * RoundingRange;
                                        }
                                        else
                                        {
                                            if (SelectedValue < RoundingRange) SelectedValue = RoundingRange;
                                            else if (SelectedValue % RoundingRange != 0 &&
                                                SelectedValue % RoundingRange < RoundingRange)
                                                SelectedValue = (Convert.ToInt32(SelectedValue / RoundingRange) + 1) * RoundingRange;
                                        }
                                        row.Cells[TargetColumn].Value = SelectedValue;
                                    }
                            }
                            #endregion

                            #region All Category
                            else
                            {
                                foreach (DataGridViewRow row in dgvData.Rows)
                                {
                                    int SelectedValue = Convert.ToInt32(row.Cells[TargetColumn].Value);
                                    if (SelectedValue % RoundingRange < RoundingRange / 2)
                                    {
                                        if (SelectedValue < RoundingRange) SelectedValue = 0;
                                        else if (SelectedValue % RoundingRange != 0 &&
                                            SelectedValue % RoundingRange < RoundingRange)
                                            SelectedValue = Convert.ToInt32(SelectedValue / RoundingRange) * RoundingRange;
                                    }
                                    else
                                    {
                                        if (SelectedValue < RoundingRange) SelectedValue = RoundingRange;
                                        else if (SelectedValue % RoundingRange != 0 &&
                                            SelectedValue % RoundingRange < RoundingRange)
                                            SelectedValue = (Convert.ToInt32(SelectedValue / RoundingRange) + 1) * RoundingRange;
                                    }
                                    row.Cells[TargetColumn].Value = SelectedValue;
                                }
                            }
                            #endregion

                            break;
                        #endregion

                    }
                }
                #endregion
            }
        }
        #endregion

        #region btnServiceColumns_Click
        private void btnServiceColumns_Click(object sender, EventArgs e)
        {
            #region Check User Permission
            if (_IsGridValuesChanged)
            {
                DialogResult Dr = PMBox.Show("آیا مایلید اطلاعات تغییر یافته " +
                    "بدون ذخیره سازی از بین بروند؟\n" +
                    "در صورتی كه اطلاعات را اعمال ننمایید ، كلیه تغییرات از دست خواهد رفت.",
                    "هشدار!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2);
                if (Dr == DialogResult.No)
                    return;
            }
            #endregion
            new frmServicesPriceFields();
            // حذف ستون های اضافی
            if (!GenerateAdditionalColumns() || !FillAddinColsData()) Close();
            _IsGridValuesChanged = false;
        }
        #endregion

        #region btnPrint_Click
        private void btnPrint_Click(object sender, EventArgs e)
        {
            new frmReportPreview(dgvData);
        }
        #endregion

        #region btnApply_Click
        private void btnApply_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            dgvData.EndEdit();
            btnApply.Focus();
            #region Validations
            // تعریف لیست آیتم های چك شده برای موارد تكراری
            List<String> CheckedItems = new List<String>();
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                // نادیده گرفتن ردیف افزوده شده ی جدید
                if (row.IsNewRow) continue;
                #region Duplicate Rows
                // بررسی عدم وجود ردیف جاری در ردیف های بررسی شده
                if (!CheckedItems.Contains(row.Cells[ColCode.Index].Value.ToString().Trim()))
                {
                    // جستجوی مجدد در بین تمام آیتم های جدول
                    foreach (DataGridViewRow TempRow in dgvData.Rows)
                        if (!TempRow.IsNewRow && // ردیف جدید نباشد
                            row.Index != TempRow.Index && // با ردیف جاری برای مقایسه برابر نباشد
                            !CheckedItems.Contains(TempRow.Cells[ColCode.Index].Value.ToString().Trim()) &&
                            TempRow.Cells[ColCode.Index].Value != null && // مقدار آن تهی نباشد
                            // اگر هر دو ردیف برابر باشند
                            TempRow.Cells[ColCode.Index].Value.ToString().ToLower() ==
                            row.Cells[ColCode.Index].Value.ToString().ToLower())
                        {
                            PMBox.Show("در بین كد های ثبت شده ، كد تكراری وجود دارد!\n" +
                                "لطفاً اصلاح نمایید.", "خطا!",
                                MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            row.Cells[ColCode.Index].Selected = true;
                            return;
                        }
                    // افزودن ردیف غیر تكراری به لیست آیتم های چك شده
                    CheckedItems.Add(row.Cells[ColCode.Index].Value.ToString().Trim());
                }
                #endregion
            }
            #endregion
            
            if (!DBLayerIMS.Manager.Submit())
            {
                const String ErrorMessage = "امكان به روز رسانی بانك بر اساس اطلاعات وارد شده ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا نام تكراری وارد ننموده اید؟\n" +
                    "2. آیا ردیف جدیدی فاقد نام وارد ننموده اید؟\n" +
                    "3. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            if (!SaveAdditionalData()) return;
            _IsGridValuesChanged = false;
            dgvData.Focus();
        }
        #endregion

        #region btnSave_Click
        private void btnSave_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            dgvData.EndEdit();
            btnSave.Focus();
            #region Validations
            // تعریف لیست آیتم های چك شده برای موارد تكراری
            List<String> CheckedItems = new List<String>();
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                // نادیده گرفتن ردیف افزوده شده ی جدید
                if (row.IsNewRow) continue;
                #region Duplicate Rows
                // بررسی عدم وجود ردیف جاری در ردیف های بررسی شده
                if (!CheckedItems.Contains(row.Cells[ColCode.Index].Value.ToString().Trim()))
                {
                    // جستجوی مجدد در بین تمام آیتم های جدول
                    foreach (DataGridViewRow TempRow in dgvData.Rows)
                        if (!TempRow.IsNewRow && // ردیف جدید نباشد
                            row.Index != TempRow.Index && // با ردیف جاری برای مقایسه برابر نباشد
                            TempRow.Cells[ColCode.Index].Value != null && // مقدار آن تهی نباشد
                            // اگر هر دو ردیف برابر باشند
                            TempRow.Cells[ColCode.Index].Value.ToString().ToLower() ==
                            row.Cells[ColCode.Index].Value.ToString().ToLower())
                        {

                            PMBox.Show("در بین كد های ثبت شده ، كد تكراری وجود دارد!\n" +
                                "لطفاً اصلاح نمایید.", "خطا!",
                                MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            row.Cells[ColCode.Index].Selected = true;
                            return;
                        }
                    // افزودن ردیف غیر تكراری به لیست آیتم های چك شده
                    CheckedItems.Add(row.Cells[ColCode.Index].Value.ToString().Trim());
                }
                #endregion
            }
            #endregion
            if (!DBLayerIMS.Manager.Submit())
            {
                const String ErrorMessage = "امكان به روز رسانی بانك بر اساس اطلاعات وارد شده ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا نام تكراری وارد ننموده اید؟\n" +
                    "2. آیا ردیف جدیدی فاقد نام وارد ننموده اید؟\n" +
                    "3. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            if (!SaveAdditionalData()) return;
            _IsGridValuesChanged = false;
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
            dgvData.EndEdit();
            btnAdd.Focus();
            if (_IsGridValuesChanged)
            {
                DialogResult Dr = PMBox.Show("آیا از اعمال تغییرات منصرف شدید؟", "هشدار",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (Dr == DialogResult.No) { e.Cancel = true; return; }
            }
            Dispose();
            Cursor.Current = Cursors.Default;
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

            #region cBoxWithInActives
            String TooltipText = ToolTipManager.GetText("cBoxWithInActivesServices", "IMS");
            FormToolTip.SetSuperTooltip(cBoxWithInActives,
                new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
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

            #region btnApply
            TooltipText = ToolTipManager.GetText("btnApply", "IMS");
            FormToolTip.SetSuperTooltip(btnApply, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                    Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnSave
            TooltipText = ToolTipManager.GetText("btnAccept", "IMS");
            FormToolTip.SetSuperTooltip(btnSave, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                    Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnAdd
            TooltipText = ToolTipManager.GetText("btnAddService", "IMS");
            FormToolTip.SetSuperTooltip(btnAdd,
                new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                    Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnChangeAllServices
            TooltipText = ToolTipManager.GetText("btnServicesChangeAll", "IMS");
            FormToolTip.SetSuperTooltip(btnChangeAllServices, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                    Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnServiceColumns
            TooltipText = ToolTipManager.GetText("btnServiceColumns", "IMS");
            FormToolTip.SetSuperTooltip(btnServiceColumns, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                 Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnPrint
            TooltipText = ToolTipManager.GetText("btnPrint", "IMS");
            FormToolTip.SetSuperTooltip(btnPrint, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

        }
        #endregion

        #region Boolean FillServicesListDataSource()
        /// <summary>
        /// تابع خواندن  اطلاعات خدمات از بانك
        /// </summary>
        /// <returns></returns>
        private Boolean FillServicesListDataSource()
        {
            try
            {
                _DataSource = DBLayerIMS.Manager.
                    DBML.ServicesLists.OrderBy(List => Convert.ToInt32(List.Code));
                DBLayerIMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, _DataSource);
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان خواندن اطلاعات خدمات از بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Services Settings", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion
            dgvData.DataSource = _DataSource.Where(Data => Data.IsActive);
            return true;
        }
        #endregion

        #region Boolean FillCboCategories()
        /// <summary>
        /// تنظیم خصوصیات جدول تنظیمات
        /// </summary>
        private Boolean FillCboCategories()
        {
            List<SP_SelectCategoriesResult> CatList = DBLayerIMS.Services.ServCategoriesList;
            if (CatList == null) return false;
            ColumnCategory.DataSource = CatList;
            ColumnCategory.DisplayMember = "Name";
            ColumnCategory.ValueMember = "ID";
            return true;
        }
        #endregion

        #region Boolean GenerateAdditionalColumns()
        /// <summary>
        /// تابع تولید ستون های قیمت اضافه
        /// </summary>
        private Boolean GenerateAdditionalColumns()
        {
            // حذف ستون های قبلی افزوده شده در صورت وجود
            if (_AdditionalPriceColumns != null)
                foreach (AdditionalPriceColumn Data in _AdditionalPriceColumns)
                    if (dgvData.Columns.Contains(Data.ColumnName)) dgvData.Columns.Remove(Data.ColumnName);
            DBLayerIMS.Services.ServAddinPriceColsList = null;
            _AdditionalPriceColumns = DBLayerIMS.Services.ServAddinPriceColsList;
            if (_AdditionalPriceColumns == null) return false;

            #region Add Columns
            Int32 Index = _AdditionalPriceColumns.Count;
            for (Int32 i = 0; i < Index; i++)
            {
                DataGridViewTextBoxColumn CurrentColumn = new DataGridViewTextBoxColumn();
                CurrentColumn.Tag = _AdditionalPriceColumns[i].ID;
                CurrentColumn.HeaderText = _AdditionalPriceColumns[i].Name;
                CurrentColumn.ToolTipText = _AdditionalPriceColumns[i].Description;
                CurrentColumn.Name = _AdditionalPriceColumns[i].ColumnName;
                CurrentColumn.Width = 80;
                CurrentColumn.DefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
                CurrentColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                CurrentColumn.DefaultCellStyle.ForeColor = Color.Green;
                CurrentColumn.DefaultCellStyle.NullValue = "0";
                CurrentColumn.DefaultCellStyle.Format = "N0";
                CurrentColumn.MaxInputLength = 10;
                CurrentColumn.DisplayIndex = (dgvData.Columns[ColDescription.Index].Index + i);
                dgvData.Columns.Add(CurrentColumn);
            }
            #endregion
            return true;
        }
        #endregion

        #region Boolean FillAddinColsData()
        /// <summary>
        /// تابع تكمیل مقادیر ستون های قیمت اضافه
        /// </summary>
        private Boolean FillAddinColsData()
        {
            if (_AdditionalPriceColumns.Count == 0) return true;
            #region Fill DataTable
            DataTable TempDataTable =
                DBLayerIMS.Manager.ExecuteQuery("EXECUTE [ImagingSystem].[Services].[SP_SelectAdditionalPriceData]", 10);
            if (TempDataTable == null) return false;
            #endregion

            #region Fill Columns Data
            // پیمایش در سرویس های جدول خدمات فرم
            for (Int32 i = 0; i < dgvData.Rows.Count; i++)
            {
                // بدست آوردن كلید سرویس جاری
                Int16? CurrentServiceID = ((ServicesList)dgvData.Rows[i].DataBoundItem).ID;
                // خواندن ردیف مورد نظر برای سرویس جاری در حلقه
                DataRow[] AdditionalServicePriceRow = TempDataTable.Select("ServiceIX = " + CurrentServiceID);
                // پر كردن فیلد های موجود برای قیمت های اضافی از بانك در جدول فرم
                if (AdditionalServicePriceRow.Length > 0)
                    // پیمایش بین ستون های قیمت اضافی
                    for (Int32 j = 0; j < _AdditionalPriceColumns.Count; j++)
                    {
                        String ColumName = _AdditionalPriceColumns[j].ColumnName;
                        dgvData.Rows[i].Cells[ColumName].Value = AdditionalServicePriceRow[0][ColumName];
                    }
            }
            #endregion

            dgvData.Refresh();
            _ChangedCells = new List<ChangedAddinServiceCells>();
            return true;
        }
        #endregion

        #region Boolean SaveAdditionalData()
        /// <summary>
        /// ذخیره سازی قیمت های اضافی
        /// </summary>
        /// <returns>صحت انجام كار</returns>
        public Boolean SaveAdditionalData()
        {
            if (_AdditionalPriceColumns.Count == 0) return true;
            foreach (ChangedAddinServiceCells Cell in _ChangedCells)
            {
                if (Cell.ServiceID == 0) continue; // خارج شدن در صورتی كه به ردیف جدید رسیده باشد
                try { DBLayerIMS.Manager.DBML.SP_InsertAdditionalPriceData(Cell.ServiceID, Cell.FieldID, Cell.Value); }
                #region Catch
                catch (Exception Ex)
                {
                    const String ErrorMessage =
                        "امكان ذخیره اطلاعات ستون های قیمت اضافی در بانك اطلاعات ممكن نیست.\n" +
                        "موارد زیر را بررسی نمایید:\n" +
                        "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogManager.SaveLogEntry("Sepehr", "Services Settings", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                    return false;
                }
                #endregion
            }
            _ChangedCells = new List<ChangedAddinServiceCells>();
            return true;
        }
        #endregion

        #endregion

        #region class ChangedAddinServiceCells
        /// <summary>
        /// كلاس مدیریت سلول های تغییر كرده فیلد های پویا خدمات
        /// </summary>
        private class ChangedAddinServiceCells
        {
            public Int16 ServiceID { get; set; }
            public Int16 FieldID { get; set; }
            public Int32 Value { get; set; }

            /// <summary>
            /// سازنده پیش فرض كلاس
            /// </summary>
            public ChangedAddinServiceCells(Int16 ServID, Int16 AddinFieldID, Int32 CellValue)
            {
                ServiceID = ServID;
                FieldID = AddinFieldID;
                Value = CellValue;
            }
        }
        #endregion

    }
}