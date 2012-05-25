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
using Sepehr.Forms.Reports.Designables;
#endregion

namespace Sepehr.Forms.Reports.Designables.Design
{
    /// <summary>
    /// فرم افزودن یا ویرایش یگ گزارش قابل طراحی
    /// </summary>
    internal partial class frmManage : Form
    {

        #region Fields

        #region readonly Boolean _IsAdding
        /// <summary>
        ///  مجزا كننده حالت ویرایش از حالت افزودن
        /// </summary>
        private readonly Boolean _IsAdding;
        #endregion

        #region DesignableReport _CurrentReportStruct
        /// <summary>
        ///  شی گزارش در حال ویرایش
        /// </summary>
        private DesignableReport _CurrentReportStruct;
        #endregion

        #region DataTable _ReportColumns
        /// <summary>
        /// دیتا تیبل ستون های انتخاب شده در گزارش
        /// </summary>
        private DataTable _ReportColumns;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        ///  سازنده فرم برای حالت افزودن و ویرایش گزارش
        /// </summary>
        /// <param name="ReportID">كلید گزارش یا تهی برای ثبت گزارش جدید</param>
        public frmManage(Int16? ReportID)
        {
            InitializeComponent();
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("Fa-Ir"));
            dgvCurrentReportCols.AutoGenerateColumns = false;
            dgvColumnsList.AutoGenerateColumns = false;
            if (!FilldgvColumnsList()) { Close(); return; }
            if (ReportID == null) _IsAdding = true;
            else
            {
                _IsAdding = false;
                if (!FillCurrentReportColumns(ReportID.Value)) { Close(); return; }
            }
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            dgvColumnsList.DefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
            dgvCurrentReportCols.DefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
            Opacity = 1;
        }
        #endregion

        #region dgvSource_CellMouseClick
        private void dgvSource_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == ColColumnsSelection.Index)
            {
                dgvColumnsList[ColColumnsSelection.Index, e.RowIndex].Value =
                    !Convert.ToBoolean(dgvColumnsList[ColColumnsSelection.Index, e.RowIndex].Value);
                dgvColumnsList.EndEdit();
            }
        }
        #endregion

        #region dgvSource_CellMouseDoubleClick
        private void dgvSource_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvColumnsList.Rows[e.RowIndex];
                dgvCurrentReportCols.Rows.Add(row.Cells[ColColumnsName.Index].Value,
                    row.Cells[ColColumnsHeader.Index].Value, row.Cells[ColColumnsHeader.Index].Value);
            }
        }
        #endregion

        #region btnManageFields_Click
        private void btnManageFields_Click(object sender, EventArgs e)
        {
            new frmAddinFields();
            ReportHelper.CleanTempData();
            if (!FilldgvColumnsList()) { Close(); return; }
        }
        #endregion

        #region btnAdd_Click
        private void btnAdd_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvColumnsList.Rows)
                if (Convert.ToBoolean(row.Cells[ColColumnsSelection.Index].Value))
                    dgvCurrentReportCols.Rows.Add(row.Cells[ColColumnsName.Index].Value,
                        row.Cells[ColColumnsHeader.Index].Value, row.Cells[ColColumnsHeader.Index].Value);
        }
        #endregion

        #region btnUp_Click
        private void btnUp_Click(object sender, EventArgs e)
        {
            if (dgvCurrentReportCols.Rows.Count == 0) return;
            if (dgvCurrentReportCols.SelectedRows[0].Index == 0) return;
            Int32 TempInsertIndex = dgvCurrentReportCols.SelectedRows[0].Index - 1;
            dgvCurrentReportCols.Rows.InsertCopy(dgvCurrentReportCols.SelectedRows[0].Index, TempInsertIndex);
            foreach (DataGridViewCell cell in dgvCurrentReportCols.Rows[dgvCurrentReportCols.SelectedRows[0].Index].Cells)
                dgvCurrentReportCols.Rows[dgvCurrentReportCols.SelectedRows[0].Index - 2].Cells[cell.ColumnIndex].Value = cell.Value;
            dgvCurrentReportCols.Rows.Remove(dgvCurrentReportCols.SelectedRows[0]);
            dgvCurrentReportCols.Rows[TempInsertIndex].Selected = true;
        }
        #endregion

        #region btnDown_Click
        private void btnDown_Click(object sender, EventArgs e)
        {
            if (dgvCurrentReportCols.Rows.Count == 0) return;
            if (dgvCurrentReportCols.SelectedRows[0].Index == dgvCurrentReportCols.Rows.Count - 1) return;
            Int32 TempInsertIndex = dgvCurrentReportCols.SelectedRows[0].Index;
            dgvCurrentReportCols.Rows.InsertCopy(TempInsertIndex, TempInsertIndex + 2);
            foreach (DataGridViewCell cell in dgvCurrentReportCols.Rows[dgvCurrentReportCols.SelectedRows[0].Index].Cells)
                dgvCurrentReportCols.Rows[dgvCurrentReportCols.SelectedRows[0].Index + 2].Cells[cell.ColumnIndex].Value = cell.Value;
            dgvCurrentReportCols.Rows.Remove(dgvCurrentReportCols.SelectedRows[0]);
            dgvCurrentReportCols.Rows[TempInsertIndex + 1].Selected = true;
        }
        #endregion

        #region btnDelete_Click
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCurrentReportCols.SelectedRows.Count != 0)
                dgvCurrentReportCols.Rows.RemoveAt(dgvCurrentReportCols.SelectedRows[0].Index);
        }
        #endregion

        #region btnSave_Click
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!AddOrEditReport()) return;
            DialogResult = DialogResult.OK;
        }
        #endregion

        #endregion

        #region Methods

        #region Boolean FilldgvColumnsList()
        /// <summary>
        ///  تابع پر كردن جدول ستون های قابل انتخاب برای گزارش های قابل طراحی
        /// </summary>
        /// <return>صحت انجام كار</return>
        private Boolean FilldgvColumnsList()
        {
            List<ReportHelper.Column> ColumnsList = ReportHelper.ColumnsList;
            if (ColumnsList == null) return false;
            dgvColumnsList.Rows.Clear();
            foreach (ReportHelper.Column Column in ReportHelper.ColumnsList)
            {
                Int32 Index = dgvColumnsList.Rows.Add(false, Column.ColumnName, Column.ColumnDescription);
                dgvColumnsList.Rows[Index].DefaultCellStyle.BackColor =
                    ReportHelper.ColumnsColorsList[Column.GroupID - 1];
            }
            return true;
        }
        #endregion

        #region Boolean FillCurrentReportColumns(Int16 _ReportID)
        /// <summary>
        /// تابع خواندن اطلاعات گزارش انتخاب شده در حالت ویرایش
        /// </summary>
        /// <return>صحت انجام كار</return>
        private Boolean FillCurrentReportColumns(Int16 _ReportID)
        {
            #region Read Report Base Data And Fill Controls
            try
            {
                _CurrentReportStruct = DBLayerIMS.Manager.DBML.DesignableReports.Where(Data => Data.ID == _ReportID).First();
                DBLayerIMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, _CurrentReportStruct);
            }
            #region Catch
            catch (Exception Ex)
            {
                PMBox.Show("امكان خواندن اطلاعات گزارش قابل طراحی جاری وجود ندارد!\n" + "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟.\n" +
                    "2. آیا سرور در وضعیت متعادلی است و شبكه دارای ترافیك بالا نیست؟.", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Reports Forms", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error); return false;
            }
            #endregion
            txtName.Text = _CurrentReportStruct.Name;
            txtTopic.Text = _CurrentReportStruct.Topic;

            #region Generate Current Report Columns DataTable
            _ReportColumns = new DataTable("DesignableReport");
            _ReportColumns.Columns.Add("ColColumnsName", typeof(String));
            _ReportColumns.Columns.Add("ColColumnsHeaders", typeof(String));
            _ReportColumns.Columns.Add("ColIsNumeric", typeof(Boolean));
            try
            {
                if (File.Exists("DesignableReport.DAT")) File.Delete("DesignableReport.DAT");
                File.WriteAllText("DesignableReport.DAT", _CurrentReportStruct.ColumnsData);
                _ReportColumns.ReadXml("DesignableReport.DAT");
            }
            #region Catch
            catch (Exception Ex)
            {
                PMBox.Show("امكان خواندن ستون های انتخاب شده برای گزارش جاری وجود ندارد!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Reports Forms", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error); return false;
            }
            #endregion
            #region Finally
            finally
            {
                try { if (File.Exists("DesignableReport.DAT")) File.Delete("DesignableReport.DAT"); }
                catch { }
            }
            #endregion
            #endregion

            #endregion

            #region Add Current Report Columns To dgv
            foreach (DataRow row in _ReportColumns.Rows)
            {
                Int32 ID = dgvCurrentReportCols.Rows.Add();
                dgvCurrentReportCols.Rows[ID].Cells[ColName.Index].Value = row["ColColumnsName"];

                #region Check Whether Column Exist Or Not
                Boolean IsColumnExists = false;
                foreach (DataGridViewRow ViewRow in dgvColumnsList.Rows)
                    if (dgvCurrentReportCols.Rows[ID].Cells[ColName.Index].Value.Equals(ViewRow.Cells[ColColumnsName.Index].Value))
                    {
                        dgvCurrentReportCols.Rows[ID].Cells[ColHeader.Index].Value = ViewRow.Cells[ColColumnsHeader.Index].Value;
                        IsColumnExists = true;
                        break;
                    }
                #endregion

                if (!IsColumnExists) dgvCurrentReportCols.Rows[ID].Cells[ColHeader.Index].Value = "== حذف شده ==";
                dgvCurrentReportCols.Rows[ID].Cells[ColEditedHeader.Index].Value = row["ColColumnsHeaders"];
            }
            #endregion

            return true;
        }
        #endregion

        #region Boolean AddOrEditReport()
        /// <summary>
        ///   تابع افزودن گزارش جدید ویا ویرایش گزارش در بانك  
        /// </summary>
        /// <returns>صحت انجام كار</returns>
        private Boolean AddOrEditReport()
        {
            if (String.IsNullOrEmpty(txtName.Text.Trim()))
            {
                PMBox.Show("برای گزارش حتماً نامی انتخاب نمایید!", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return false;
            }
            if (dgvCurrentReportCols.Rows.Count == 0)
            {
                PMBox.Show("برای گزارش حتماً ستون انتخاب نمایید!", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            #region Prepare DataTable For Selected Columns
            _ReportColumns = new DataTable("DesignableReport");
            _ReportColumns.Columns.Add("ColColumnsName", typeof(String));
            _ReportColumns.Columns.Add("ColColumnsHeaders", typeof(String));
            _ReportColumns.Columns.Add("ColIsNumeric", typeof(Boolean));
            foreach (DataGridViewRow row in dgvCurrentReportCols.Rows)
                _ReportColumns.Rows.Add(row.Cells[ColName.Index].Value, row.Cells[ColEditedHeader.Index].Value,
                    ReportHelper.ColumnsList.Where(Data => Data.ColumnName ==
                        row.Cells[ColName.Index].Value.ToString()).First().IsAdditionalInformation);
            // تولید متن ایكس ام ال ستون های انتخاب شده
            StringWriter DataTableXml = new StringWriter();
            _ReportColumns.WriteXml(DataTableXml, true);
            String FilterString = DataTableXml.GetStringBuilder().ToString();
            #endregion

            #region Adding State
            if (_IsAdding)
            {
                DesignableReport DesignableReport = new DesignableReport();
                DesignableReport.Name = txtName.Text.Trim().Normalize();
                DesignableReport.Topic = txtTopic.Text.Trim().Normalize();
                DesignableReport.ColumnsData = FilterString;
                DBLayerIMS.Manager.DBML.DesignableReports.InsertOnSubmit(DesignableReport);
            }
            #endregion

            #region Editing State
            else
            {
                _CurrentReportStruct.Name = txtName.Text.Trim();
                _CurrentReportStruct.Topic = txtTopic.Text.Trim();
                _CurrentReportStruct.ColumnsData = FilterString;
            }
            #endregion

            if (!DBLayerIMS.Manager.Submit())
            {
                PMBox.Show("امكان خواندن اطلاعات از بانك اطلاعاتی وجود ندارد!\n" + "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟.\n" +
                    "2. آیا سرور در وضعیت متعادلی است و شبكه دارای ترافیك بالا نیست؟.", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
            }
            return true;
        }
        #endregion

        #endregion

    }
}