#region using
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using Negar;
#endregion

namespace Negar.GridPrinting
{
    /// <summary>
    /// كلاس مدیریت و چاپ كنترل های فرم های ویندوز
    /// </summary>
    internal static class NegarPrintWinFormControls
    {

        #region Fields
        /// <summary>
        /// شیء جدول برای چاپ
        /// </summary>
        private static DataGridView _dgv;
        /// <summary>
        /// تمام ستون های فعال در جدول
        /// </summary>
        private static readonly List<String> _AvailableColumns = new List<String>();
        /// <summary>
        /// لیست موقعیت های سمت راست ستون ها
        /// </summary>
        private static readonly List<Int32> _ColumnRights = new List<Int32>();
        /// <summary>
        /// لیسن نوع ستون ها
        /// </summary>
        private static readonly List<Type> _ColumnTypes = new List<Type>();
        /// <summary>
        /// لیست موقعیت عرض ستون ها
        /// </summary>
        private static readonly List<Int32> _ColumnWidths = new List<Int32>();
        /// <summary>
        /// شیء دكمه برای چاپ ستون هایی با نوع دكمه
        /// </summary>
        private static Button _CellButton;
        /// <summary>
        /// شیء چك باكس برای چاپ ستون هایی با نوع چك باكس
        /// </summary>
        private static CheckBox _CellCheckBox;
        /// <summary>
        /// شیء كمبو باكس برای چاپ ستون هایی با نوع كمبو باكس
        /// </summary>
        private static ComboBox _CellComboBox;
        /// <summary>
        /// ارتفاع سلول جدول
        /// </summary>
        private static Int32 _CellHeight;
        /// <summary>
        /// متغیری برای تعیین هم اندازه كردن و تنظیم عرض ستون های جدول بر اساس اندازه صفحه
        /// </summary>
        private static Boolean _FitToPageWidth;
        /// <summary>
        /// ارتفاع عناوین ستون ها
        /// </summary>
        private static Int32 _HeaderHeight;
        /// <summary>
        /// تعیین كننده رسیدن چاپ كننده به صفحه جدید
        /// </summary>
        private static Boolean _NewPage;
        /// <summary>
        /// شماره صفحات
        /// </summary>
        private static Int32 _PageNo;
        /// <summary>
        /// تعیین چاپ تمام ردیف ها
        /// </summary>
        private static Boolean _PrintAllRows = true;
        /// <summary>
        /// موقعیت ردیف جاری
        /// </summary>
        private static Int32 _RowPosition;
        /// <summary>
        /// مجموع عرض ستون ها
        /// </summary>
        private static Int32 _TotalColumnsWidth;
        /// <summary>
        /// شیء اطلاعات چاپ جدول
        /// </summary>
        public static PrintDocument _PrintDocument;
        /// <summary>
        /// عنوان اول گزارش
        /// </summary>
        public static String _HeaderTitle1;
        /// <summary>
        /// عنوان دوم گزارش
        /// </summary>
        public static String _HeaderTitle2;
        /// <summary>
        /// عنوان سوم گزارش
        /// </summary>
        public static String _HeaderTitle3;
        /// <summary>
        /// تعداد ردیف ها در هر صفحه
        /// </summary>
        public static Int32 _RowsPerPage;
        #endregion

        #region public static void Print(DataGridView DataGridViewForPrint)
        /// <summary>
        /// تابع آماده سازی شیء چاپ برای كنترل جدول
        /// </summary>
        /// <param name="DataGridViewForPrint">كنترل جدول</param>
        public static void Print(DataGridView DataGridViewForPrint)
        {
            try
            {
                _dgv = DataGridViewForPrint;
                if (_PrintDocument == null) InitPrintDocument();
                _AvailableColumns.Clear();
                foreach (DataGridViewColumn Col in _dgv.Columns)
                {
                    if (!Col.Visible) continue;
                    _AvailableColumns.Add(Col.HeaderText);
                }
                _PrintAllRows = true;
                _FitToPageWidth = true;
                if (_RowsPerPage == 0) _RowsPerPage = 20;
            }
            #region Catch
            catch (Exception Ex)
            {
                PMBox.Show("خطا در تولید فایل چاپ نهایی!", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Negar", "PrintWinFormControls", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
            }
            #endregion
        }
        #endregion

        #region internal static void InitPrintDocument()
        internal static void InitPrintDocument()
        {
            _PrintDocument = new PrintDocument();
            PaperSize MyPaperSize = new PaperSize();
            MyPaperSize.PaperName = "A4";
            MyPaperSize.Height = 1169;
            MyPaperSize.Width = 827;
            MyPaperSize.RawKind = 9;
            _PrintDocument.DefaultPageSettings.PaperSize = MyPaperSize;
            _PrintDocument.DefaultPageSettings.Margins = new Margins(50, 50, 100, 100);
            _PrintDocument.BeginPrint += PrintDoc_BeginPrint;
            _PrintDocument.PrintPage += PrintDoc_PrintPage;
        }
        #endregion

        #region static void PrintDoc_BeginPrint(object sender,PrintEventArgs e)
        private static void PrintDoc_BeginPrint(object sender, PrintEventArgs e)
        {
            _ColumnRights.Clear();
            _ColumnWidths.Clear();
            _ColumnTypes.Clear();
            _CellHeight = 0;
            _CellButton = new Button();
            _CellCheckBox = new CheckBox();
            _CellComboBox = new ComboBox();
            _TotalColumnsWidth = 0;
            foreach (DataGridViewColumn GridCol in _dgv.Columns)
                if (GridCol.Visible) _TotalColumnsWidth += GridCol.Width;
            _PageNo = 1;
            _NewPage = true;
            _RowPosition = 0;
        }
        #endregion

        #region static void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        private static void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Int32 MarginTop = e.MarginBounds.Top;
            Int32 MarginRight = e.MarginBounds.Right;
            try
            {
                List<DataGridViewColumn> ColList = new List<DataGridViewColumn>();
                foreach (DataGridViewColumn column in _dgv.Columns)
                    if (column.Visible) ColList.Add(column);
                ColList = ColList.OrderBy(Data => Data.DisplayIndex).ToList();

                #region In Drawing Page 1 ==> Save Columns Size
                // قبل از آغاز رسم صفحه اول ، طول و عرض سلول ها ذخیره می گردد
                if (_PageNo == 1)
                {
                    foreach (DataGridViewColumn GridCol in ColList)
                    {
                        // حذف ستون های غیر قالب نمایش
                        if (!GridCol.Visible) continue;
                        // تشخیص آنكه آیا ستون ها تراز هستند یا خیر
                        Int32 ColumnWith;
                        if (_FitToPageWidth)
                            ColumnWith = (Int32)(Math.Floor((GridCol.Width / (Double)_TotalColumnsWidth * _TotalColumnsWidth *
                                (e.MarginBounds.Width / (Double)_TotalColumnsWidth))));
                        else ColumnWith = GridCol.Width;
                        // تنظیم ارتفاع ردیف ستون ها
                        _HeaderHeight = (Int32)(e.Graphics.MeasureString(GridCol.HeaderText,
                            GridCol.InheritedStyle.Font, ColumnWith).Height) + 11;
                        // افزودن عرض و طول بدست آمده از ستون جاری در لیست های مربوطه
                        _ColumnRights.Add(MarginRight);
                        _ColumnWidths.Add(ColumnWith);
                        _ColumnTypes.Add(GridCol.GetType());
                        // كسر كردن موقعیت ستون جاری از موقعیت كلی به جهت راست به چپ بودن گزارش
                        MarginRight -= ColumnWith;
                    }
                }
                #endregion

                #region Printing Current Page, Row by Row
                while (_RowPosition <= _dgv.Rows.Count - 1)
                {
                    #region Set Page Row State
                    DataGridViewRow CurrentRow = _dgv.Rows[_RowPosition];
                    // اگر ردیف جزو ردیف های جدید باشد یا آنكه انتخاب شده نباشد از آن صرف نظر می كند
                    if (CurrentRow.IsNewRow || (!_PrintAllRows && !CurrentRow.Selected))
                    { _RowPosition++; continue; }
                    // تنظیم ارتفاع سلول جاری
                    _CellHeight = CurrentRow.Height;
                    // اگر اندازه ی سلول جاری از اندازه صفحه بزرگتر باشد ، فرم به صفحه بعدی می رود
                    if (MarginTop + _CellHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
                    {
                        if (_PageNo == 1) _RowsPerPage = _RowPosition;
                        DrawHeadersAndFooters(e);
                        _NewPage = true;
                        _PageNo++;
                        e.HasMorePages = true;
                        return;
                    }
                    // اگر تعداد ردیف های چاپ شده در صفحه جاری از تعداد ردیف های مجاز در كل صفحات تجاوز كند
                    // چاپ به صفحه بعد منتقل می شود
                    if (_RowPosition >= (_RowsPerPage) * _PageNo)
                    {
                        DrawHeadersAndFooters(e);
                        _NewPage = true;
                        _PageNo++;
                        e.HasMorePages = true;
                        return;
                    }
                    #endregion

                    #region Current Row Is In New Page => Draw Columns Headers
                    Int32 i = 0;
                    if (_NewPage)
                    {
                        #region Draw Column Headers
                        MarginTop = e.MarginBounds.Top;
                        if (!String.IsNullOrEmpty(_HeaderTitle1)) MarginTop = MarginTop + 28;
                        if (!String.IsNullOrEmpty(_HeaderTitle2)) MarginTop = MarginTop + 28;
                        if (!String.IsNullOrEmpty(_HeaderTitle3)) MarginTop = MarginTop + 28;
                        foreach (DataGridViewColumn Col in ColList)
                        {
                            if (!Col.Visible) continue;
                            Rectangle Rect =
                                new Rectangle(_ColumnRights[i] - _ColumnWidths[i], MarginTop, _ColumnWidths[i], _HeaderHeight);
                            e.Graphics.FillRectangle(new SolidBrush(Color.LightGray), Rect);
                            Pen MyPen = new Pen(Color.Navy);
                            MyPen.Width = 2;
                            e.Graphics.DrawRectangle(MyPen, new Rectangle(_ColumnRights[i] - _ColumnWidths[i],
                                MarginTop, _ColumnWidths[i], _HeaderHeight));
                            StringFormat CellFormat = new StringFormat();
                            CellFormat.Alignment = StringAlignment.Center;
                            CellFormat.LineAlignment = StringAlignment.Center;
                            CellFormat.Trimming = StringTrimming.EllipsisCharacter;
                            e.Graphics.DrawString(Col.HeaderText, Col.HeaderCell.Style.Font,
                                new SolidBrush(Col.InheritedStyle.ForeColor),
                                new RectangleF(_ColumnRights[i] - _ColumnWidths[i], MarginTop,
                                    _ColumnWidths[i], _HeaderHeight), CellFormat);
                            i++;
                        }
                        #endregion
                        _NewPage = false;
                        MarginTop += _HeaderHeight;
                    }
                    #endregion

                    #region Draw Columns Contents
                    i = 0;
                    foreach (DataGridViewColumn Col in ColList)
                    {
                        DataGridViewCell Cel = CurrentRow.Cells[Col.Index];
                        #region TextBox Cells
                        if ((_ColumnTypes[i]).Name == "DataGridViewTextBoxColumn" ||
                            (_ColumnTypes[i]).Name == "DataGridViewLinkColumn")
                        {
                            if (Cel.Value == null) Cel.Value = String.Empty;
                            StringFormat CellFormat = new StringFormat();
                            if (Cel.Style.Alignment == DataGridViewContentAlignment.MiddleLeft ||
                                Cel.Style.Alignment == DataGridViewContentAlignment.NotSet)
                                CellFormat.Alignment = StringAlignment.Far;
                            else if (Cel.Style.Alignment == DataGridViewContentAlignment.MiddleRight)
                                CellFormat.Alignment = StringAlignment.Near;
                            else CellFormat.Alignment = StringAlignment.Center;
                            CellFormat.LineAlignment = StringAlignment.Center;
                            CellFormat.Trimming = StringTrimming.EllipsisCharacter;
                            e.Graphics.DrawString(Cel.Value.ToString(), Cel.InheritedStyle.Font,
                                new SolidBrush(Cel.InheritedStyle.ForeColor),
                                new RectangleF(_ColumnRights[i] - _ColumnWidths[i], MarginTop,
                                    _ColumnWidths[i], _CellHeight), CellFormat);
                        }
                        #endregion

                        #region ComboBox Cells
                        else if ((_ColumnTypes[i]).Name == "DataGridViewComboBoxColumn")
                        {
                            if (Cel.Value == null) Cel.Value = String.Empty;
                            _CellComboBox.Size = new Size(_ColumnWidths[i], _CellHeight);
                            Bitmap bmp = new Bitmap(_CellComboBox.Width, _CellComboBox.Height);
                            _CellComboBox.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                            e.Graphics.DrawImage(bmp, new Point(_ColumnRights[i], MarginTop));
                            StringFormat CellFormat = new StringFormat();
                            if (Cel.Style.Alignment == DataGridViewContentAlignment.MiddleLeft)
                                CellFormat.Alignment = StringAlignment.Near;
                            else if (Cel.Style.Alignment == DataGridViewContentAlignment.MiddleRight)
                                CellFormat.Alignment = StringAlignment.Far;
                            else CellFormat.Alignment = StringAlignment.Center;
                            CellFormat.LineAlignment = StringAlignment.Center;
                            CellFormat.FormatFlags = StringFormatFlags.NoWrap;
                            CellFormat.Trimming = StringTrimming.EllipsisCharacter;
                            e.Graphics.DrawString(Cel.Value.ToString(), Cel.InheritedStyle.Font,
                                new SolidBrush(Cel.InheritedStyle.ForeColor), new RectangleF(_ColumnRights[i] + 1, MarginTop,
                                    _ColumnWidths[i] - 16, _CellHeight), CellFormat);
                        }
                        #endregion

                        #region CheckBox Cells
                        else if ((_ColumnTypes[i]).Name == "DataGridViewCheckBoxColumn")
                        {
                            if (Cel.Value == null) Cel.Value = false;
                            _CellCheckBox.Size = new Size(14, 14);
                            _CellCheckBox.Checked = (Boolean)Cel.Value;
                            Bitmap bmp = new Bitmap(_ColumnWidths[i], _CellHeight);
                            Graphics tmpGraphics = Graphics.FromImage(bmp);
                            tmpGraphics.FillRectangle(Brushes.White,
                                                      new Rectangle(0, 0, bmp.Width - _ColumnWidths[i], bmp.Height));
                            _CellCheckBox.DrawToBitmap(bmp, new Rectangle(((bmp.Width - _CellCheckBox.Width) / 2),
                                                                          ((bmp.Height - _CellCheckBox.Height) / 2), _CellCheckBox.Width, _CellCheckBox.Height));
                            e.Graphics.DrawImage(bmp, new Point(_ColumnRights[i] - _ColumnWidths[i], MarginTop));
                        }
                        #endregion

                        #region Button Cells
                        else if ((_ColumnTypes[i]).Name == "DataGridViewButtonColumn")
                        {
                            _CellButton.Text = Cel.Value.ToString();
                            _CellButton.Size = new Size(_ColumnWidths[i], _CellHeight);
                            Bitmap bmp = new Bitmap(_CellButton.Width, _CellButton.Height);
                            _CellButton.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                            e.Graphics.DrawImage(bmp, new Point(_ColumnRights[i], MarginTop));
                        }
                        #endregion

                        #region Image Cells
                        else if ((_ColumnTypes[i]).Name == "DataGridViewImageColumn")
                        {
                            Rectangle CelSize = new Rectangle(_ColumnRights[i] - _ColumnWidths[i],
                                                              MarginTop, _ColumnWidths[i], _CellHeight);
                            Size ImgSize = ((Image)(Cel.FormattedValue)).Size;
                            e.Graphics.DrawImage((Image)Cel.FormattedValue, new Rectangle(_ColumnRights[i] - _ColumnWidths[i] +
                                                                                          ((CelSize.Width - ImgSize.Width) / 2), MarginTop + ((CelSize.Height - ImgSize.Height) / 2),
                                                                                          ((Image)(Cel.FormattedValue)).Width, ((Image)(Cel.FormattedValue)).Height));
                        }
                        #endregion

                        #region Cells Borders
                        Pen MyPen = new Pen(Color.Navy);
                        MyPen.Width = 2;
                        e.Graphics.DrawRectangle(MyPen, new Rectangle(_ColumnRights[i] - _ColumnWidths[i],
                                                                      MarginTop, _ColumnWidths[i], _CellHeight));
                        #endregion
                        i++;
                    }
                    #endregion
                    MarginTop += _CellHeight;
                    _RowPosition++;
                }
                #endregion

                #region Draw Headers And Footers
                if (_RowsPerPage != 0)
                {
                    // رسم قسمت پایین صفحه
                    DrawHeadersAndFooters(e);
                    e.HasMorePages = false;
                }
                #endregion
            }
            #region Catch
            catch (Exception Ex)
            {
                PMBox.Show("خطا در تولید فایل چاپ نهایی!", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Negar", "PrintWinFormControls", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
            }
            #endregion
        }
        #endregion

        #region static void DrawHeadersAndFooters(PrintPageEventArgs e)
        /// <summary>
        /// تابع رسم اطلاعات پایین صفحه
        /// </summary>
        private static void DrawHeadersAndFooters(PrintPageEventArgs e)
        {
            Int32 CurrentPageRowsCount = 0;
            if (_dgv.Rows.Count > 0)
            {
                if (_PrintAllRows)
                {
                    if (_dgv.Rows[_dgv.Rows.Count - 1].IsNewRow) CurrentPageRowsCount = _dgv.Rows.Count;
                    else CurrentPageRowsCount = _dgv.Rows.Count;
                }
                else CurrentPageRowsCount = _dgv.SelectedRows.Count;
            }

            #region Draw Headers
            // رسم عنوان صفحه
            Int32 HeadersTopPosition = 0;
            if (!String.IsNullOrEmpty(_HeaderTitle1))
            {
                e.Graphics.DrawString(_HeaderTitle1, new Font("B Titr", 12, FontStyle.Bold), Brushes.Black,
                    Convert.ToInt32(e.PageBounds.Right / 2) -
                    Convert.ToInt32(e.Graphics.MeasureString(
                    _HeaderTitle1, new Font("B Titr", 12, FontStyle.Bold), e.PageBounds.Width).Width / 2), e.MarginBounds.Top);
                HeadersTopPosition += 25;
            }
            if (!String.IsNullOrEmpty(_HeaderTitle2))
            {
                e.Graphics.DrawString(_HeaderTitle2, new Font("B Titr", 12, FontStyle.Bold), Brushes.Black,
                    Convert.ToInt32(e.PageBounds.Right / 2) - Convert.ToInt32(e.Graphics.MeasureString(
                    _HeaderTitle2, new Font("B Titr", 12, FontStyle.Bold), e.PageBounds.Width).Width / 2),
                    e.MarginBounds.Top + HeadersTopPosition);
                HeadersTopPosition += 25;
            }
            if (!String.IsNullOrEmpty(_HeaderTitle3))
                e.Graphics.DrawString(_HeaderTitle3, new Font("B Titr", 12, FontStyle.Bold), Brushes.Black,
                    Convert.ToInt32(e.PageBounds.Right / 2) - Convert.ToInt32(e.Graphics.MeasureString(
                    _HeaderTitle3, new Font("B Titr", 12, FontStyle.Bold), e.PageBounds.Width).Width / 2),
                    e.MarginBounds.Top + HeadersTopPosition);
            #endregion

            #region Draw Footers
            StringFormat TextsFormat = new StringFormat();
            TextsFormat.Alignment = StringAlignment.Center;
            TextsFormat.LineAlignment = StringAlignment.Center;
            TextsFormat.Trimming = StringTrimming.EllipsisCharacter;
            // رسم شماره صفحه جاری
            String PageNum = "صفحه ی " + _PageNo + " از " +
                Math.Ceiling(Convert.ToDecimal(CurrentPageRowsCount) / _RowsPerPage);
            e.Graphics.DrawString(PageNum, new Font("Tahoma", 9, FontStyle.Bold), Brushes.Black,
                e.PageBounds.Right - 80, e.PageBounds.Height - 30, TextsFormat);
            // رسم تاریخ زمان گزارش
            String PrintDateString = PersianCalendar.Utilities.PersianDateConverter.ToPersianDate(DateTime.Now).ToWritten() +
                " --- " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
            e.Graphics.DrawString(PrintDateString, new Font("Tahoma", 9, FontStyle.Bold),
                Brushes.Black, e.PageBounds.Left + 150, e.PageBounds.Height - 30, TextsFormat);
            #endregion
        }
        #endregion

    }
}