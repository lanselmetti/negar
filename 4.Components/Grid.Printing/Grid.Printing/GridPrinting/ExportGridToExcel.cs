#region using
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Negar;
#endregion

namespace Negar.GridPrinting
{
    /// <summary>
    /// كلاسی برای تبدیل جدول به فایل اكسل
    /// </summary>
    public static class ExportGridToExcel
    {

        #region public static Boolean ExportToExcel(DataGridView SentDataGridView, String ExcelFilePath)
        /// <summary>
        /// تابع ایجاد فایل اكسل از جدول
        /// </summary>
        /// <param name="SentDataGridView">جدول مورد نظر</param>
        /// <param name="ExcelFilePath">آدرس فایل</param>
        public static Boolean ExportToExcel(DataGridView SentDataGridView, String ExcelFilePath)
        {
            try
            {
                #region Create New Excel Document
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                Microsoft.Office.Interop.Excel.Application ExcelApp = new ApplicationClass();
                Workbook CurrentWorkbook = ExcelApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                Sheets WorkSheets = CurrentWorkbook.Sheets;
                Worksheet _WorkSheet = (Worksheet)WorkSheets.get_Item(1);
                #endregion

                #region Setup Styles
                Style ColumnStyle = CurrentWorkbook.Styles.Add("styleColumnHeadings", Type.Missing);
                ColumnStyle.Font.Name = "B Titr";
                ColumnStyle.Font.Size = 11;
                ColumnStyle.Font.Color = (255 << 16) | (255 << 8) | 255;
                ColumnStyle.Interior.Color = (0 << 16) | (0 << 8) | 0;
                ColumnStyle.Interior.Pattern = XlPattern.xlPatternSolid;
                ColumnStyle.VerticalAlignment = XlVAlign.xlVAlignCenter;
                ColumnStyle.HorizontalAlignment = XlHAlign.xlHAlignCenter;

                Style RowsStyle = CurrentWorkbook.Styles.Add("styleRows", Type.Missing);
                if (SentDataGridView.Rows.Count != 0 && SentDataGridView.Rows[0].Cells[0].Style.Font != null)
                {
                    RowsStyle.Font.Name = SentDataGridView.Rows[0].Cells[0].Style.Font.Name;
                    RowsStyle.Font.Size = SentDataGridView.Rows[0].Cells[0].Style.Font.Size;
                }
                else
                {
                    RowsStyle.Font.Name = "B Koodak";
                    RowsStyle.Font.Size = 12;
                }
                RowsStyle.Font.Color = (0 << 16) | (0 << 8) | 0;
                RowsStyle.Interior.Color = (192 << 16) | (192 << 8) | 192;
                RowsStyle.Interior.Pattern = XlPattern.xlPatternSolid;
                RowsStyle.VerticalAlignment = XlVAlign.xlVAlignCenter;
                RowsStyle.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                #endregion

                #region Fill Worksheet With DataGridView Data
                List<DataGridViewColumn> ColList = new List<DataGridViewColumn>();
                foreach (DataGridViewColumn column in SentDataGridView.Columns)
                    if (column.Visible) ColList.Add(column);
                ColList = ColList.OrderBy(Data => Data.DisplayIndex).ToList();

                for (Int32 i = 0; i < ColList.Count; i++)
                    InsertValueToExcel(_WorkSheet, 1, (i + 1), ColList[i].HeaderText, ColumnStyle.Name);
                for (Int32 i = 0; i < SentDataGridView.Rows.Count; i++)
                {
                    if (SentDataGridView.Rows[i].IsNewRow) continue;
                    Int32 j = 1;
                    foreach (DataGridViewColumn column in ColList)
                    {
                        if (SentDataGridView[column.Index, i].Value == null) SentDataGridView[column.Index, i].Value = String.Empty;
                        InsertValueToExcel(_WorkSheet, i + 2, j,
                            SentDataGridView[column.Index, i].Value.ToString(), RowsStyle.Name);
                        j++;
                    }
                }
                #endregion

                #region Finalize Class
                Missing missing = Missing.Value;
                if (File.Exists(ExcelFilePath)) File.Delete(ExcelFilePath);
                CurrentWorkbook.SaveAs(ExcelFilePath, XlFileFormat.xlWorkbookNormal, missing, missing, missing, missing,
                    XlSaveAsAccessMode.xlNoChange, missing, missing, missing, missing, missing);
                CurrentWorkbook.Close(true, ExcelFilePath, Type.Missing);
                ExcelApp.UserControl = false;
                ExcelApp.Quit();
                #region Kill Excel Processes
                Process[] ps = Process.GetProcesses();
                foreach (Process p in ps)
                    if (p.ProcessName.ToUpper().Equals("EXCEL")) p.Kill();
                #endregion
                PMBox.Show("تبدیل به اكسل با موفقیت به پایان رسید!", "موفقیت تبدیل اطلاعات!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                #endregion
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان تولید فایل اكسل از اطلاعات ارائه شده ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا نرم افزار اكسل مایكروسافت بر روی سیستم جاری نصب می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Negar", "ExportGridToExcel", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion
            return true;
        }
        #endregion

        #region private static void InsertValueToExcel(_Worksheet worksheet, Int32 RowID, Int32 ColID, Object Value, String StyleName)
        private static void InsertValueToExcel(_Worksheet worksheet, Int32 RowID, Int32 ColID, Object Value, String StyleName)
        {
            Range ExcelRange = (Range)worksheet.Cells[RowID, ColID];
            ExcelRange.Select();
            ExcelRange.Value2 = Value.ToString();
            ExcelRange.Style = StyleName;
            ExcelRange.Columns.EntireColumn.AutoFit();
            ExcelRange.Borders.Weight = XlBorderWeight.xlThin;
            ExcelRange.Borders.LineStyle = XlLineStyle.xlContinuous;
            ExcelRange.Borders.ColorIndex = XlColorIndex.xlColorIndexAutomatic;
        }
        #endregion

    }
}