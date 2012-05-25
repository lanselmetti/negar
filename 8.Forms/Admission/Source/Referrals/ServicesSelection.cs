#region using

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Negar;
using DevComponents.DotNetBar;
using Sepehr.DBLayerIMS.DataLayer;

#endregion

namespace Sepehr.Forms.Admission.Referrals
{
    /// <summary>
    /// فرم افزودن خدمت جدید به فرم خدمات
    /// </summary>
    internal partial class frmServicesSelection : Form
    {

        #region Fields & Properties

        #region List<SP_SelectServicesListResult> _DataSource
        /// <summary>
        /// فیلد منبع اطلاعاتی فرم
        /// </summary>
        private List<SP_SelectServicesListResult> _DataSource;
        #endregion

        #region public Dictionary<Int16, Int32> SelectedServices
        /// <summary>
        /// خدمات انتخاب شده
        /// </summary>
        public Dictionary<Int16, Int32> SelectedServices { get; set; }
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmServicesSelection()
        {
            Cursor.Current = Cursors.WaitCursor;
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            if (!FillFormDataSource()) { Close(); return; }
            dgvData.DataSource = _DataSource;
            Cursor.Current = Cursors.Default;
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
        }
        #endregion

        #region cboCategories_SelectedIndexChanged
        private void cboCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchServices();
        }
        #endregion

        #region txtServiceSearch_TextChanged
        private void txtServiceSearch_TextChanged(object sender, EventArgs e)
        {
            SearchServices();
        }
        #endregion

        #region dgvServices_CellMouseDoubleClick
        /// <summary>
        /// روال مدیریت كلیك برای تغییر چك باكس
        /// </summary>
        private void dgvServices_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.RowIndex >= 0 && e.ColumnIndex >= 0 &&
                e.ColumnIndex != ColQuantity.Index)
            {
                dgvData.CellValueChanged -= dgvData_CellValueChanged;
                if (dgvData[ColSelection.Index, e.RowIndex].Value == null ||
                    (Boolean)dgvData[ColSelection.Index, e.RowIndex].Value == false)
                {
                    dgvData[ColSelection.Index, e.RowIndex].Value = true;
                    dgvData[ColQuantity.Index, e.RowIndex].Value = 1;
                }
                else
                {
                    dgvData[ColSelection.Index, e.RowIndex].Value = false;
                    dgvData[ColQuantity.Index, e.RowIndex].Value = null;
                }
                dgvData.EndEdit();
                dgvData.CellValueChanged += dgvData_CellValueChanged;
            }
        }
        #endregion

        #region dgvData_CellValueChanged
        private void dgvData_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == ColSelection.Index)
            {
                if (dgvData[ColSelection.Index, e.RowIndex].Value == null ||
                    (Boolean)dgvData[ColSelection.Index, e.RowIndex].Value == false)
                    dgvData[ColQuantity.Index, e.RowIndex].Value = null;
                else dgvData[ColQuantity.Index, e.RowIndex].Value = 1;
            }
        }
        #endregion

        #region dgvData_CellValidating
        private void dgvData_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == ColQuantity.Index)
            {
                if (dgvData[ColSelection.Index, e.RowIndex].Value != null &&
                    (Boolean)dgvData[ColSelection.Index, e.RowIndex].Value)
                {
                    if (e.FormattedValue == null || e.FormattedValue == DBNull.Value)
                    {
                        PMBox.Show("برای تعداد خدمت باید حتماً مقداری وارد نمایید!", "خطا!",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                        return;
                    }
                    Int16 InsertedText;
                    Boolean IsCorrect = Int16.TryParse(e.FormattedValue.ToString(), out InsertedText);
                    if (!IsCorrect || InsertedText <= 0)
                    {
                        PMBox.Show("برای تعداد خدمت باید مقداری عددی وارد نمایید!", "خطا!",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                        return;
                    }
                }
            }
        }
        #endregion

        #region dgvData_CellFormatting
        private void dgvData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == ColQuantity.Index)
            {
                if (dgvData[ColSelection.Index, e.RowIndex].Value == null ||
                    (Boolean)dgvData[ColSelection.Index, e.RowIndex].Value == false)
                    dgvData[ColQuantity.Index, e.RowIndex].ReadOnly = true;
                else dgvData[ColQuantity.Index, e.RowIndex].ReadOnly = false;
            }
        }
        #endregion

        #region dgvServices_CellMouseClick
        /// <summary>
        /// روال مدیریت كلیك راست
        /// </summary>
        private void dgvServices_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0 &&
                dgvData["ColSelection", e.RowIndex].Value != null && Convert.ToBoolean(dgvData["ColSelection", e.RowIndex].Value))
            {
                dgvData[e.ColumnIndex, e.RowIndex].Selected = true;
                SliderItemCount.Value = Convert.ToInt32(dgvData["ColQuantity", e.RowIndex].Value);
                cmsServicesManage.Popup(MousePosition);
            }
            else if (e.Button == MouseButtons.Left && e.RowIndex >= 0 &&
                // ReSharper disable PossibleNullReferenceException
                e.ColumnIndex == dgvData.Columns["ColSelection"].Index)
            // ReSharper restore PossibleNullReferenceException 
            {
                if (dgvData["ColSelection", e.RowIndex].Value == null ||
                    (Boolean)dgvData["ColSelection", e.RowIndex].Value == false)
                {
                    dgvData["ColSelection", e.RowIndex].Value = true;
                    dgvData["ColQuantity", e.RowIndex].Value = 1;
                }
                else
                {
                    dgvData["ColSelection", e.RowIndex].Value = false;
                    dgvData["ColQuantity", e.RowIndex].Value = null;
                }
                dgvData.EndEdit();
            }
        }
        #endregion

        #region SliderItemCount_ValueChanged
        private void SliderItemCount_ValueChanged(object sender, EventArgs e)
        {
            dgvData.SelectedRows[0].Cells["ColQuantity"].Value = SliderItemCount.Value;
            SliderItemCount.Text = "تعداد خدمت: " + SliderItemCount.Value;
        }
        #endregion

        #region btnAllAndNone_Click
        private void btnAllAndNone_Click(object sender, EventArgs e)
        {
            if (((ButtonX)sender).Name == "btnAll")
            {
                foreach (DataGridViewRow row in dgvData.Rows)
                    if (row.Cells[ColSelection.Name].Value == null || (Boolean)row.Cells[ColSelection.Name].Value == false)
                    {
                        row.Cells[ColSelection.Name].Value = true;
                        row.Cells[ColQuantity.Name].Value = 1;
                    }
            }
            else foreach (DataGridViewRow row in dgvData.Rows)
                {
                    row.Cells[ColSelection.Name].Value = false;
                    row.Cells[ColQuantity.Name].Value = null;
                }
        }
        #endregion

        #region btnAdd_Click
        private void btnAdd_Click(object sender, EventArgs e)
        {
            dgvData.EndEdit();
            btnAdd.Focus();
            SelectedServices = new Dictionary<Int16, Int32>();
            try
            {
                for (Int32 i = 0; i < dgvData.Rows.Count; i++)
                    if (dgvData[ColSelection.Index, i].Value != null &&
                        Convert.ToBoolean(dgvData[ColSelection.Index, i].Value))
                        SelectedServices.Add(((SP_SelectServicesListResult)dgvData.Rows[i].DataBoundItem).ID,
                            Convert.ToInt32(dgvData[ColQuantity.Index, i].Value));
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان اضافه كردن خدمت به بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Admission Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return;
            }
            #endregion
            DialogResult = DialogResult.OK;
        }
        #endregion

        #region Form_Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            dgvData.EndEdit();
            btnAdd.Focus();
            Cursor.Current = Cursors.Default;
        }
        #endregion

        #endregion

        #region Methods

        #region Boolean FillFormDataSource()
        /// <summary>
        /// تابع خواندن اطلاعات پایه فرم از بانك
        /// </summary>
        private Boolean FillFormDataSource()
        {
            _DataSource = DBLayerIMS.Services.ServicesList.Where(Data => Data.IsActive).
                OrderBy(Data => Convert.ToInt32(Data.Code)).ToList();
            cboCategory.DataSource = DBLayerIMS.Services.ServCategoriesList.
                Where(Data => Data.IsActive == true || Data.ID == null).OrderBy(Data => Data.Name).ToList();
            return true;
        }
        #endregion

        #region void SearchServices()
        /// <summary>
        /// تابعی برای جستجوی خدمات بر اساس فیلتر تعیین شده
        /// </summary>
        private void SearchServices()
        {
            List<SP_SelectServicesListResult> FilteredItem;
            if (cboCategory.SelectedIndex == 0) FilteredItem = _DataSource.Where(Data => Data.IsActive).ToList();
            else FilteredItem = _DataSource.
                    Where(Data => Data.CategoryIX == Convert.ToInt16(cboCategory.SelectedValue) && Data.IsActive).ToList();
            if (!String.IsNullOrEmpty(txtServiceSearch.Text.Trim()))
                FilteredItem = FilteredItem.Where(Data => Data.Name.Contains(txtServiceSearch.Text.Trim())).ToList();
            dgvData.DataSource = FilteredItem;
        }
        #endregion

        #endregion

    }
}