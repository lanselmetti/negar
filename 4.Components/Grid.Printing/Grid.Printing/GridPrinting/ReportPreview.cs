#region using
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Negar;
using Negar.PersianCalendar.UI.Controls;
using Negar.PersianCalendar.Utilities;
using Negar.Properties;
using DevComponents.DotNetBar;
#endregion

namespace Negar.GridPrinting
{
    /// <summary>
    /// فرم پیش نمایش برای چاپ یك جدول
    /// </summary>
    public partial class frmReportPreview : Form
    {

        #region Ctors

        #region frmReportPreview(DataTable tbl)
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmReportPreview(DataTable tbl)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (tbl == null) { Close(); return; }
            InitializeComponent();
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("Fa-Ir"));
            #region Set dgvData Properties
            foreach (DataColumn column in tbl.Columns)
            {
                Int32 NewColID = dgvData.Columns.Add(column.ColumnName, column.Caption);
                dgvData.Columns[NewColID].HeaderCell.Style.Font = new Font("B Mitra", 11, FontStyle.Bold);
            }
            foreach (DataRow row in tbl.Rows)
            {
                Int32 RowIndex = dgvData.Rows.Add(row.ItemArray);
                foreach (DataGridViewCell cell in dgvData.Rows[RowIndex].Cells) if (cell.Value == null) cell.Value = String.Empty;
            }
            #region Set Special Columns
            // تنظیم ستون های تاریخ در فرم
            for (Int32 i = 0; i < tbl.Columns.Count; i++)
                if (tbl.Columns[i].DataType.Equals(typeof(DateTime)))
                    foreach (DataGridViewRow row in dgvData.Rows)
                        if (!row.IsNewRow && !(row.Cells[i].Value is DBNull))
                            row.Cells[i].Value = Convert.ToDateTime(row.Cells[i].Value).ToPersianDate().Year + "/" +
                                Convert.ToDateTime(row.Cells[i].Value).ToPersianDate().Month + "/" +
                                Convert.ToDateTime(row.Cells[i].Value).ToPersianDate().Day;
            #endregion
            dgvData.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dgvData.AutoResizeColumnHeadersHeight();
            #endregion
            ShowDialog();
        }
        #endregion

        #region frmReportPreview(DataGridView dgv)
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmReportPreview(DataGridView dgv)
        {
            Cursor.Current = Cursors.WaitCursor;
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("Fa-Ir"));
            InitializeComponent();
            DataTable tbl = new DataTable();
            List<DataGridViewColumn> VisibleCols = new List<DataGridViewColumn>();
            #region Add Columns To Grid
            // افزودن ستون های جدول
            for (Int32 i = 0; i < dgv.Columns.Count; i++)
            {
                if (!dgv.Columns[i].Visible) continue;
                DataColumn NewItem;
                if (dgv.Columns[i].CellType.Equals(typeof(DataGridViewCheckBoxCell)))
                    NewItem = tbl.Columns.Add(dgv.Columns[i].Name, typeof(Boolean));
                else if (dgv.Columns[i].CellType.Equals(typeof(DataGridViewPersianDateTimePickerCell)))
                    NewItem = tbl.Columns.Add(dgv.Columns[i].Name, typeof(String));
                else if (dgv.Columns[i].ValueType != null && dgv.Columns[i].ValueType.Equals(typeof(Int32)))
                    NewItem = tbl.Columns.Add(dgv.Columns[i].Name, typeof(Int32));
                else if (dgv.Columns[i].ValueType != null && dgv.Columns[i].ValueType.Equals(typeof(DateTime)))
                    NewItem = tbl.Columns.Add(dgv.Columns[i].Name, typeof(String));
                else NewItem = tbl.Columns.Add(dgv.Columns[i].Name, typeof(String));
                NewItem.Caption = dgv.Columns[i].HeaderText;
                VisibleCols.Add(dgv.Columns[i]);
            }
            #endregion

            #region Add Rows
            foreach (DataGridViewRow row in dgv.Rows)
            {
                Object[] CollectedData = new Object[tbl.Columns.Count];
                Int32 Index = 0;
                foreach (DataGridViewColumn column in VisibleCols)
                {
                    if (!column.Visible) continue;
                    if (column.GetType().Equals(typeof(DataGridViewPersianDateTimePickerColumn)))
                    {
                        if (row.Cells[column.Index].Value != null && row.Cells[column.Index].Value != DBNull.Value)
                        {
                            PersianDate TheDate = Convert.ToDateTime(row.Cells[column.Index].Value).ToPersianDate();
                            if (((DataGridViewPersianDateTimePickerColumn)column).ShowTime)
                                CollectedData[Index] = TheDate.Hour + ":" + TheDate.Minute + ":" + TheDate.Second + " - " +
                                    TheDate.Year + "/" + TheDate.Month + "/" + TheDate.Day;
                            else CollectedData[Index] = TheDate.Year + "/" + TheDate.Month + "/" + TheDate.Day;
                        }
                    }
                    else if (row.Cells[column.Index].FormattedValue != null &&
                        row.Cells[column.Index].FormattedValue != DBNull.Value)
                    {
                        if (column.ValueType != null && (column.ValueType.Equals(typeof(Int32)) ||
                            column.ValueType.Equals(typeof(Int16)) || column.ValueType.Equals(typeof(Int64))))
                        {
                            try
                            {
                                int Formatted;
                                Int32.TryParse(row.Cells[column.Index].FormattedValue.ToString(), 
                                    NumberStyles.AllowThousands, column.CellTemplate.Style.FormatProvider, 
                                    out Formatted);
                                CollectedData[Index] = Formatted;
                            }
                            catch (Exception Ex)
                            {
                                CollectedData[Index] = row.Cells[column.Index].FormattedValue.ToString();
                                MessageBox.Show(Ex.Message);
                            }
                        }
                        else CollectedData[Index] = row.Cells[column.Index].FormattedValue.ToString();
                    }
                    Index++;
                }
                tbl.Rows.Add(CollectedData);
            }
            #endregion

            #region Set dgvData Properties
            foreach (DataColumn column in tbl.Columns)
            {
                Int32 NewColID = dgvData.Columns.Add(column.ColumnName, column.Caption);
                dgvData.Columns[NewColID].HeaderCell.Style.Font = new Font("B Mitra", 11, FontStyle.Bold);
            }
            foreach (DataRow row in tbl.Rows)
            {
                Int32 RowIndex = dgvData.Rows.Add(row.ItemArray);
                foreach (DataGridViewCell cell in dgvData.Rows[RowIndex].Cells)
                {
                    if (cell.Value == null || cell.Value == DBNull.Value) cell.Value = String.Empty;
                    cell.Style.Font = FontDialogBox.Font;
                }
            }
            #region Set Special Columns
            for (Int32 i = 0; i < tbl.Columns.Count; i++)
            {
                // تنظیم ستون های تاریخ
                if (tbl.Columns[i].DataType.Equals(typeof(DateTime)))
                {
                    foreach (DataGridViewRow row in dgvData.Rows)
                        if (!row.IsNewRow && !(row.Cells[i].Value is DBNull) && !String.IsNullOrEmpty(row.Cells[i].Value.ToString()))
                        {
                            PersianDate TheDate = Convert.ToDateTime(row.Cells[i].Value).ToPersianDate();
                            if (((DataGridViewPersianDateTimePickerColumn)dgv.Columns[i]).ShowTime)
                                row.Cells[i].Value = TheDate.Hour + ":" + TheDate.Minute + ":" + TheDate.Second + " - " +
                                    TheDate.Year + "/" + TheDate.Month + "/" + TheDate.Day;
                            else row.Cells[i].Value = TheDate.Year + "/" + TheDate.Month + "/" + TheDate.Day;
                        }
                }
                // تنظیم ستون های بولین
                else if (tbl.Columns[i].DataType.Equals(typeof(Boolean)))
                {
                    foreach (DataGridViewRow row in dgvData.Rows)
                        if (!row.IsNewRow && !(row.Cells[i].Value is DBNull))
                        {
                            if (Convert.ToBoolean(row.Cells[i].Value)) row.Cells[i].Value = "آری";
                            else row.Cells[i].Value = "خیر";
                        }
                }
            }
            #endregion
            dgvData.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dgvData.AutoResizeColumnHeadersHeight();
            #endregion
            ShowDialog();
        }
        #endregion

        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            SetControlsToolTipTexts();
            dgvData.Focus();
            Cursor.Current = Cursors.Default;
        }
        #endregion

        #region dgvData_CellMouseClick
        private void dgvData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dgvData.Rows[e.RowIndex].IsNewRow) return;
                dgvData.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                cmsMenuRows.Popup(MousePosition);
            }
            else if (e.ColumnIndex >= 0)
            {
                dgvData.Rows[0].Cells[e.ColumnIndex].Selected = true;
                cmsMenuCols.Popup(MousePosition);
            }
        }
        #endregion

        #region dgvData_RowHeightChanged
        private void dgvData_RowHeightChanged(object sender, DataGridViewRowEventArgs e)
        {
            foreach (DataGridViewRow row in dgvData.Rows) row.Height = e.Row.Height;
        }
        #endregion

        #region dgvData_SortCompare
        private void dgvData_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            Boolean Val1IsNull = false;
            Boolean Val2IsNull = false;
            if (e.CellValue1 == null || e.CellValue1 == DBNull.Value) Val1IsNull = true;
            if (e.CellValue2 == null || e.CellValue2 == DBNull.Value) Val2IsNull = true;
            if (!Val1IsNull && !Val2IsNull) return;
            if (Val1IsNull & !Val2IsNull) e.SortResult = -1;
            if (!Val1IsNull & Val2IsNull) e.SortResult = 1;
            if (Val1IsNull & Val2IsNull) e.SortResult = 0;
            e.Handled = true;
        }
        #endregion

        #region @@@ cmsMenuRows @@@

        #region btnRowAddUp_Click
        private void btnRowAddUp_Click(object sender, EventArgs e)
        {
            Int32 NewRowIndex = dgvData.Rows.Add();
            DataGridViewRow NewRow = dgvData.Rows[NewRowIndex];
            dgvData.Rows.RemoveAt(NewRowIndex);
            dgvData.Rows.Insert(dgvData.SelectedCells[0].RowIndex, NewRow);
        }
        #endregion

        #region btnRowAddDown_Click
        private void btnRowAddDown_Click(object sender, EventArgs e)
        {
            Int32 NewRowIndex = dgvData.Rows.Add();
            DataGridViewRow NewRow = dgvData.Rows[NewRowIndex];
            dgvData.Rows.RemoveAt(NewRowIndex);
            dgvData.Rows.Insert(dgvData.SelectedCells[0].RowIndex + 1, NewRow);
        }
        #endregion

        #region btnRowMoveUp_Click
        private void btnRowMoveUp_Click(object sender, EventArgs e)
        {
            Int32 OldRowIndex = dgvData.SelectedCells[0].RowIndex;
            if (OldRowIndex == 0) return;
            DataGridViewRow CurrentRow = dgvData.Rows[dgvData.SelectedCells[0].RowIndex];
            dgvData.Rows.Remove(CurrentRow);
            dgvData.Rows.Insert(OldRowIndex - 1, CurrentRow);
        }
        #endregion

        #region btnRowMoveDown_Click
        private void btnRowMoveDown_Click(object sender, EventArgs e)
        {
            Int32 OldRowIndex = dgvData.SelectedCells[0].RowIndex;
            if (OldRowIndex == dgvData.Rows.Count - 2) return;
            DataGridViewRow CurrentRow = dgvData.Rows[dgvData.SelectedCells[0].RowIndex];
            dgvData.Rows.Remove(CurrentRow);
            dgvData.Rows.Insert(OldRowIndex + 1, CurrentRow);
        }
        #endregion

        #region btnRowRemove_Click
        private void btnRowRemove_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedCells.Count != 0 && !dgvData.Rows[dgvData.SelectedCells[0].RowIndex].IsNewRow)
                dgvData.Rows.RemoveAt(dgvData.SelectedCells[0].RowIndex);
        }
        #endregion

        #endregion

        #region @@@ cmsMenuCols @@@

        #region btnColAddRight_Click
        private void btnColAddRight_Click(object sender, EventArgs e)
        {
            Int32 CurrentColumnDisplayIndex = dgvData.Columns[dgvData.SelectedCells[0].ColumnIndex].DisplayIndex;
            Int32 NewCol = dgvData.Columns.Add("NewColumn", "ستون جدید");
            dgvData.Columns[NewCol].HeaderCell.Style.Font = FontDialogBox.Font;
            dgvData.Columns[NewCol].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvData.Columns[NewCol].DisplayIndex = CurrentColumnDisplayIndex;
        }
        #endregion

        #region btnColAddLeft_Click
        private void btnColAddLeft_Click(object sender, EventArgs e)
        {
            Int32 CurrentColumnDisplayIndex = dgvData.Columns[dgvData.SelectedCells[0].ColumnIndex].DisplayIndex;
            Int32 NewCol = dgvData.Columns.Add("NewColumn", "ستون جدید");
            dgvData.Columns[NewCol].HeaderCell.Style.Font = FontDialogBox.Font;
            dgvData.Columns[NewCol].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvData.Columns[NewCol].DisplayIndex = CurrentColumnDisplayIndex + 1;
        }
        #endregion

        #region btnColEdit_Click
        private void btnColEdit_Click(object sender, EventArgs e)
        {
            Int32 ColIndex = dgvData.SelectedCells[0].ColumnIndex;
            frmEditColName MyForm = new frmEditColName(dgvData.Columns[ColIndex].HeaderText);
            if (MyForm.DialogResult == DialogResult.OK)
                dgvData.Columns[ColIndex].HeaderText = MyForm.txtName.Text.Trim();
        }
        #endregion

        #region btnColRightAlign_Click
        private void btnColRightAlign_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (row.IsNewRow) continue;
                row.Cells[dgvData.SelectedCells[0].ColumnIndex].Style.Alignment =
                DataGridViewContentAlignment.MiddleLeft;
            }
        }
        #endregion

        #region btnColCenterAlign_Click
        private void btnColCenterAlign_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (row.IsNewRow) continue;
                row.Cells[dgvData.SelectedCells[0].ColumnIndex].Style.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
            }
        }
        #endregion

        #region btnColLeftAlign_Click
        private void btnColLeftAlign_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (row.IsNewRow) continue;
                row.Cells[dgvData.SelectedCells[0].ColumnIndex].Style.Alignment =
                DataGridViewContentAlignment.MiddleRight;
            }
        }
        #endregion

        #region btnColRemove_Click
        private void btnColRemove_Click(object sender, EventArgs e)
        {
            dgvData.Columns.RemoveAt(dgvData.SelectedCells[0].ColumnIndex);
        }
        #endregion

        #endregion

        #region btnEditRowFonts_Click
        private void btnEditRowFonts_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Dr = FontDialogBox.ShowDialog();
                if (Dr == DialogResult.OK)
                {
                    foreach (DataGridViewRow row in dgvData.Rows)
                        foreach (DataGridViewCell cell in row.Cells)
                            cell.Style.Font = FontDialogBox.Font;
                    dgvData.AutoResizeColumns();
                    dgvData.AutoResizeColumnHeadersHeight();
                    dgvData.AutoResizeRows();
                }
            }
            // ReSharper disable EmptyGeneralCatchClause
            catch { }
            // ReSharper restore EmptyGeneralCatchClause
        }
        #endregion

        #region btnEditColFonts_Click
        private void btnEditColFonts_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Dr = FontDialogBox.ShowDialog();
                if (Dr == DialogResult.OK)
                {
                    foreach (DataGridViewColumn column in dgvData.Columns)
                    {
                        column.HeaderCell.Style.Font = FontDialogBox.Font;
                        dgvData.AutoResizeColumn(column.Index);
                    }
                    dgvData.AutoResizeColumns();
                    dgvData.AutoResizeColumnHeadersHeight();
                    dgvData.AutoResizeRows();
                }
            }
            // ReSharper disable EmptyGeneralCatchClause
            catch { }
            // ReSharper restore EmptyGeneralCatchClause
        }
        #endregion

        #region btnPrintSettings_Click
        private void btnPrintSettings_Click(object sender, EventArgs e)
        {
            if (NegarPrintWinFormControls._PrintDocument == null) NegarPrintWinFormControls.InitPrintDocument();
            ReportPageSetupDialog.Document = NegarPrintWinFormControls._PrintDocument;
            ReportPageSetupDialog.PageSettings = NegarPrintWinFormControls._PrintDocument.DefaultPageSettings;
            DialogResult Dr = ReportPageSetupDialog.ShowDialog();
            if (Dr == DialogResult.OK)
                NegarPrintWinFormControls._PrintDocument.DefaultPageSettings = ReportPageSetupDialog.PageSettings;
        }
        #endregion

        #region btnView_Click
        private void btnView_Click(object sender, EventArgs e)
        {
            dgvData.EndEdit();
            dgvData.AllowUserToAddRows = false;
            if (dgvData.Rows.Count == 0)
            {
                PMBox.Show("هیچ ردیفی برای چاپ وجود ندارد!", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvData.AllowUserToAddRows = true;
                BringToFront();
                Focus();
                return;
            }
            NegarPrintWinFormControls._HeaderTitle1 = txtHeaderTitle1.Text.Trim();
            NegarPrintWinFormControls._HeaderTitle2 = txtHeaderTitle2.Text.Trim();
            NegarPrintWinFormControls._HeaderTitle3 = txtHeaderTitle3.Text.Trim();
            NegarPrintWinFormControls._RowsPerPage = txtRowsLimitation.Value;
            NegarPrintWinFormControls.Print(dgvData);
            new frmReportResult(NegarPrintWinFormControls._PrintDocument);
            dgvData.AllowUserToAddRows = true;
            BringToFront();
            Focus();
        }
        #endregion

        #region btnExcel_Click
        private void btnExcel_Click(object sender, EventArgs e)
        {
            ExcelSaveFileDialog.Filter = "فرمت فایل اكسل (*.Xls)|*.Xls";
            if (ExcelSaveFileDialog.ShowDialog() == DialogResult.OK && !ExcelSaveFileDialog.FileName.Equals(String.Empty))
            {
                Enabled = false;
                ProgressBar.Visible = true;
                Cursor.Current = Cursors.WaitCursor;
                BGWorker.RunWorkerAsync();
            }
        }
        #endregion

        #region BGWorker_DoWork
        private void BGWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            ExportGridToExcel.ExportToExcel(dgvData, ExcelSaveFileDialog.FileName);
        }
        #endregion

        #region BGWorker_RunWorkerCompleted
        private void BGWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            ProgressBar.Visible = false;
            Enabled = true;
            BringToFront();
            Focus();
            Cursor.Current = Cursors.Default;
        }
        #endregion

        #region Form_Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
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

            #region btnCancel
            String TooltipText = ToolTipManager.GetText("btnClose", "IMS");
            FormToolTip.SetSuperTooltip(btnCancel, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnExportToExcel
            TooltipText = ToolTipManager.GetText("btnExportReportToExcel", "IMS");
            FormToolTip.SetSuperTooltip(btnExportToExcel, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region  btnEditFont
            TooltipText = ToolTipManager.GetText("btnReportEditFont", "IMS");
            FormToolTip.SetSuperTooltip(btnEditRowFonts, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region  btnView
            TooltipText = ToolTipManager.GetText("btnReportPreviewView", "IMS");
            FormToolTip.SetSuperTooltip(btnView, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnPrintSettings
            TooltipText = ToolTipManager.GetText("btnGridPrintingPrintSettings", "IMS");
            FormToolTip.SetSuperTooltip(btnPrintSettings, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

        }
        #endregion

        #endregion

    }
}