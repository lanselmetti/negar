#region using

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace Sepehr.Forms.Admission.Classes
{
    /// <summary>
    /// كلاس كمبوباكس اختصاصی رایان پرتونگار
    /// </summary>
    public class IMSComboBox : ComboBox
    {

        #region Fields
        private readonly Collection<String> _ColumnNames;
        private readonly Collection<Int32> _ColumnWidths;
        private Boolean _AutoComplete;
        private Boolean _AutoDropdown;
        private Color _BackColorEven = Color.White;
        private Color _BackColorOdd = Color.White;
        private String _ColumnNameString = String.Empty;
        private Int32 _ColumnWidthDefault = 75;
        private String _ColumnWidthString = String.Empty;
        private Int32 _LinkedColumnIndex;
        private Int32 _TotalWidth;
        #endregion

        #region Properties

        #region Boolean AutoComplete
        public Boolean AutoComplete
        {
            get { return _AutoComplete; }
            set { _AutoComplete = value; }
        }
        #endregion

        #region Boolean AutoDropdown
        public Boolean AutoDropdown
        {
            get { return _AutoDropdown; }
            set { _AutoDropdown = value; }
        }
        #endregion

        #region Color BackColorEven
        public Color BackColorEven
        {
            get { return _BackColorEven; }
            set { _BackColorEven = value; }
        }
        #endregion

        #region Color BackColorOdd
        public Color BackColorOdd
        {
            get { return _BackColorOdd; }
            set { _BackColorOdd = value; }
        }
        #endregion

        #region Collection<String> ColumnNameCollection
        public Collection<String> ColumnNameCollection
        {
            get { return _ColumnNames; }
        }
        #endregion

        #region Collection<Int32> ColumnWidthCollection
        public Collection<Int32> ColumnWidthCollection
        {
            get { return _ColumnWidths; }
        }
        #endregion

        #region String ColumnNames
        /// <summary>
        /// نام ستون ها
        /// </summary>
        public String ColumnNames
        {
            get { return _ColumnNameString; }

            set
            {
                // If the column string is blank, leave it blank.
                // The default width will be used for all columns.
                if (!Convert.ToBoolean(value.Trim().Length))
                {
                    _ColumnNameString = String.Empty;
                }
                else if (!String.IsNullOrEmpty(value))
                {
                    char[] delimiterChars = { ',', ';', ':' };
                    string[] columnNames = value.Split(delimiterChars);

                    if (!DesignMode)
                    {
                        _ColumnNames.Clear();
                    }

                    // After splitting the string into an array, iterate
                    // through the strings and check that they're all valid.
                    foreach (string s in columnNames)
                    {
                        // Does it have length?
                        if (Convert.ToBoolean(s.Trim().Length))
                        {
                            if (!DesignMode)
                            {
                                _ColumnNames.Add(s.Trim());
                            }
                        }
                        else // The value is blank
                        {
                            throw new NotSupportedException("Column names can not be blank.");
                        }
                    }
                    _ColumnNameString = value;
                }
            }
        }
        #endregion

        #region Int32 ColumnWidthDefault
        public Int32 ColumnWidthDefault
        {
            get { return _ColumnWidthDefault; }
            set { _ColumnWidthDefault = value; }
        }
        #endregion

        #region String ColumnWidths
        public String ColumnWidths
        {
            get { return _ColumnWidthString; }

            set
            {
                // If the column string is blank, leave it blank.
                // The default width will be used for all columns.
                if (!Convert.ToBoolean(value.Trim().Length))
                {
                    _ColumnWidthString = String.Empty;
                }
                else if (!String.IsNullOrEmpty(value))
                {
                    char[] delimiterChars = { ',', ';', ':' };
                    String[] columnWidths = value.Split(delimiterChars);
                    String invalidValue = String.Empty;
                    Int32 invalidIndex = -1;
                    Int32 idx = 1;

                    // After splitting the string into an array, iterate
                    // through the strings and check that they're all integers
                    // or blanks
                    foreach (String s in columnWidths)
                    {
                        // If it has length, test if it's an integer
                        if (Convert.ToBoolean(s.Trim().Length))
                        {
                            // It's not an integer. Flag the offending value.
                            Int32 intValue;
                            if (!Int32.TryParse(s, out intValue))
                            {
                                invalidIndex = idx;
                                invalidValue = s;
                            }
                            else // The value was okay. Increment the item index.
                            {
                                idx++;
                            }
                        }
                        else // The value is a space. Use the default width.
                        {
                            idx++;
                        }
                    }

                    // If an invalid value was found, raise an exception.
                    if (invalidIndex > -1)
                    {
                        string errMsg = "Invalid column width '" + invalidValue + "' located at column " + invalidIndex;
                        throw new ArgumentOutOfRangeException(errMsg);
                    }
                    // The string is fine
                    _ColumnWidthString = value;

                    // Only set the values of the collections at runtime.
                    // Setting them at design time doesn't accomplish 
                    // anything and causes errors since the collections 
                    // don't exist at design time.
                    if (!DesignMode)
                    {
                        _ColumnWidths.Clear();
                        foreach (string s in columnWidths)
                        {
                            // Initialize a column width to an integer
                            if (Convert.ToBoolean(s.Trim().Length))
                            {
                                _ColumnWidths.Add(Convert.ToInt32(s));
                            }
                            else // Initialize the column to the default
                            {
                                _ColumnWidths.Add(_ColumnWidthDefault);
                            }
                        }

                        // If the column is bound to data, set the column widths
                        // for any columns that aren't explicitly set by the 
                        // string value entered by the programmer
                        if (DataManager != null)
                        {
                            InitializeColumns();
                        }
                    }
                }
            }
        }
        #endregion

        #region new DrawMode DrawMode
        public new DrawMode DrawMode
        {
            get { return base.DrawMode; }
            set
            {
                if (value != DrawMode.OwnerDrawVariable)
                {
                    throw new NotSupportedException("Needs to be DrawMode.OwnerDrawVariable");
                }
                base.DrawMode = value;
            }
        }
        #endregion

        #region new ComboBoxStyle DropDownStyle
        public new ComboBoxStyle DropDownStyle
        {
            get { return base.DropDownStyle; }
            set
            {
                //if (value != ComboBoxStyle.DropDown)
                //{
                //    throw new NotSupportedException("ComboBoxStyle.DropDown is the only supported style");
                //}
                base.DropDownStyle = value;
            }
        }
        #endregion

        #region Int32 LinkedColumnIndex
        public Int32 LinkedColumnIndex
        {
            get { return _LinkedColumnIndex; }
            set
            {
                if (value < 0)
                {
                    const string Message = "A column index can not be negative";
                    throw new ArgumentOutOfRangeException(Message);
                }
                _LinkedColumnIndex = value;
            }
        }
        #endregion

        #region Int32 TotalWidth
        public Int32 TotalWidth
        {
            get { return _TotalWidth; }
        }
        #endregion

        #region Boolean ReadOnly
        /// <summary>
        /// تعیین امكان تغییر جعبه متن
        /// </summary>
        public Boolean ReadOnly { get; set; }
        #endregion

        #endregion

        #region Events
        /// <summary>
        /// رخداد پیدا نشدن آیتم در منبع داده
        /// </summary>
        public event EventHandler NoDataFound;
        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض كنترل
        /// </summary>
        public IMSComboBox()
        {
            _ColumnNames = new Collection<String>();
            _ColumnWidths = new Collection<Int32>();
            DrawMode = DrawMode.OwnerDrawVariable;
            // ReSharper disable DoNotCallOverridableMethodsInConstructor
            ContextMenu = new ContextMenu();
            // ReSharper restore DoNotCallOverridableMethodsInConstructor
        }
        #endregion

        #region Overrided Methods

        #region protected override void OnDataSourceChanged(EventArgs e)
        protected override void OnDataSourceChanged(EventArgs e)
        {
            base.OnDataSourceChanged(e);
            InitializeColumns();
        }
        #endregion

        #region protected override void OnDrawItem(DrawItemEventArgs e)
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            //base.OnDrawItem(e);
            if (DesignMode) return;
            e.DrawBackground();
            Rectangle boundsRect = e.Bounds;
            Int32 lastRight = 0;
            Color brushForeColor;
            if ((e.State & DrawItemState.Selected) == 0)
            {
                // Item is not selected. Use BackColorOdd & BackColorEven
                Color backColor = Convert.ToBoolean(e.Index % 2) ? _BackColorOdd : _BackColorEven;
                using (SolidBrush brushBackColor = new SolidBrush(backColor))
                    e.Graphics.FillRectangle(brushBackColor, e.Bounds);
                brushForeColor = Color.Black;
            }
            // Item is selected. Use ForeColor = White
            else brushForeColor = Color.White;
            using (Pen linePen = new Pen(SystemColors.GrayText))
            {
                using (SolidBrush brush = new SolidBrush(brushForeColor))
                {
                    if (!Convert.ToBoolean(_ColumnNames.Count))
                        e.Graphics.DrawString(Convert.ToString(Items[e.Index]), Font, brush, boundsRect);
                    else
                    {
                        #region Draw Right To Left Order
                        // If the ComboBox is displaying a RightToLeft language, draw it this way.
                        if (RightToLeft.Equals(RightToLeft.Yes))
                        {
                            // Define a StringFormat object to make the string display RTL.
                            StringFormat rtl = new StringFormat();
                            rtl.Alignment = StringAlignment.Near;
                            rtl.FormatFlags = StringFormatFlags.DirectionRightToLeft;

                            // Draw the strings in reverse order from high column index to zero column index.
                            for (Int32 colIndex = _ColumnNames.Count - 1; colIndex >= 0; colIndex--)
                                if (Convert.ToBoolean(_ColumnWidths[colIndex]))
                                {
                                    String item = Convert.ToString(FilterItemOnProperty(Items[e.Index], _ColumnNames[colIndex]));
                                    boundsRect.X = lastRight;
                                    boundsRect.Width = _ColumnWidths[colIndex];
                                    lastRight = boundsRect.Right;
                                    // Draw the string with the RTL object.
                                    e.Graphics.DrawString(item, Font, brush, boundsRect, rtl);
                                    if (colIndex > 0)
                                        e.Graphics.DrawLine(linePen, boundsRect.Right,
                                            boundsRect.Top, boundsRect.Right, boundsRect.Bottom);
                                }
                        }
                        #endregion

                        #region Draw Left To Right Order
                        // If the ComboBox is displaying a LeftToRight language, draw it this way.
                        else
                        {
                            // Display the Strings in ascending order from zero to the highest column.
                            for (Int32 colIndex = 0; colIndex < _ColumnNames.Count; colIndex++)
                                if (Convert.ToBoolean(_ColumnWidths[colIndex]))
                                {
                                    String item =
                                        Convert.ToString(FilterItemOnProperty(Items[e.Index], _ColumnNames[colIndex]));
                                    boundsRect.X = lastRight;
                                    boundsRect.Width = _ColumnWidths[colIndex];
                                    lastRight = boundsRect.Right;
                                    e.Graphics.DrawString(item, Font, brush, boundsRect);
                                    if (colIndex < _ColumnNames.Count - 1)
                                        e.Graphics.DrawLine(linePen, boundsRect.Right, boundsRect.Top, boundsRect.Right,
                                            boundsRect.Bottom);
                                }
                        }
                        #endregion
                    }
                }
            }
            e.DrawFocusRectangle();
        }
        #endregion

        #region protected override void OnDropDown(EventArgs e)
        protected override void OnDropDown(EventArgs e)
        {
            if (_TotalWidth > 0)
            {
                if (Items.Count > MaxDropDownItems)
                {
                    // اگر كل نتیجه در لیست قرار نگیرد:
                    // عرض به اندازه طول اسكرول افزایش می یابد
                    DropDownWidth = _TotalWidth + SystemInformation.VerticalScrollBarWidth;
                    // ارتفاع به اندازه ارتفاع مجاز برای حداكثر ردیف مجاز افزایش می یابد
                    DropDownHeight = MaxDropDownItems * 25;
                }
                else
                {
                    // اگر كل نتیجه در لیست قرار بگیرد:
                    // عرض به اندازه عادی تغییر می یابد
                    DropDownWidth = _TotalWidth;
                    // ارتفاع به اندازه ارتفاع مجاز برای ردیف های موجود افزایش می یابد
                    if (Items.Count != 0) DropDownHeight = Items.Count * 25;
                    else DropDownHeight = 200;
                }
            }
        }
        #endregion

        #region protected override void OnKeyDown(KeyEventArgs e)
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (ReadOnly) { e.Handled = true; return; }
            #region Delete
            if (e.KeyData == Keys.Delete)
            {
                DroppedDown = false;
                SelectedIndex = -1;
                Text = String.Empty;
                DataSource = null;
                Parent.SelectNextControl(this, true, true, true, true);
                Focus();
                Select();
                e.Handled = true;
            }
            #endregion

            #region Escape
            else if (e.KeyData == Keys.Escape)
            {
                e.Handled = true;
                Parent.SelectNextControl(this, true, true, true, true);
                base.OnKeyDown(e);
                e.Handled = true;
                Focus();
                Select();
                return;
            }
            #endregion

            #region BackSpace
            // كلید BackSpapce نادیده گرفته می شود. 
            // به جای آن ، رفتاری مانند كلید سمت راست برای جابجایی اعمال می شود
            else if ((e.KeyData == Keys.Back) && _AutoComplete &&
                Convert.ToBoolean(SelectionStart)) // And the SelectionStart is positive
            {
                String TextToFind = Text.Substring(0, SelectionStart - 1);
                if (String.IsNullOrEmpty(TextToFind))
                {
                    DroppedDown = false;
                    SelectedIndex = -1;
                    Text = String.Empty;
                    DataSource = null;
                    Parent.SelectNextControl(this, true, true, true, true);
                    Focus();
                    Select();
                    e.Handled = true;
                }
                else
                {
                    Int32 FoundedRowIndex = FindString(TextToFind);
                    if (FoundedRowIndex != -1)
                    {
                        SelectedIndex = FoundedRowIndex;
                        SelectionStart = TextToFind.Length;
                        SelectionLength = Text.Length - SelectionStart;
                    }
                }
            }
            #endregion
        }
        #endregion

        #region protected override void OnKeyPress(KeyPressEventArgs e)
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            // اگر كنترل در حالت فقط خواندنی باشد ، عملی انجام نمی شود
            if (ReadOnly || e.KeyChar == '') { e.Handled = true; return; }
            if (e.KeyChar == '\b') return; // BackSpace
            if (e.KeyChar == '\r') // Enter
            {
                Int32 NewIndex = FindStringExact(Text);
                Parent.Parent.SelectNextControl(this, true, true, true, true);
                SelectedIndex = NewIndex;
                return;
            }

            #region For First Char Or For Selected Physician

            // اكر كاراكتر اول وارد شده باشد یا بر روی یك پزشك انتخاب شده دكمه ای فشار داده شود
            if (Char.IsLetterOrDigit(e.KeyChar) && Text.Length == 0 && !DroppedDown)
            {
                DataSource = null;
                Text = String.Empty;
                Text = e.KeyChar.ToString();
                SelectionStart = 1;
                SelectionLength = 0;
                Parent.SelectNextControl(this, true, true, true, true);
                Focus();
                Select();
                return;
            }
            if (Text.Length == SelectionLength && SelectedIndex >= 0 && !DroppedDown)
            {
                DataSource = null;
                Parent.SelectNextControl(this, true, true, true, true);
                Focus();
                Select();
                Text = String.Empty;
                Text = e.KeyChar.ToString();
                SelectionStart = 1;
                SelectionLength = 0;
                e.Handled = true;
                return;
            }

            #endregion

            #region if (Char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Space))

            // اگر كاراكتر ارسالی از كنترل های كیبورد نبود
            if (Char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Space))
            {
                String CurrentText = Text.Substring(0, SelectionStart) + e.KeyChar;
                base.OnKeyPress(e);
                DroppedDown = _AutoDropdown;
                if (_AutoComplete)
                {
                    String TextToFind = CurrentText;
                    Int32 FoundedRowIndex = FindStringExact(TextToFind);
                    // اگر عین عبارت یافت نشد دنبال عبارتی شبیه آن می گردد
                    if (FoundedRowIndex == -1) FoundedRowIndex = FindString(TextToFind);
                    // اگر عبارتی شبیه به عبارت مورد نظر پیدا شود
                    if (FoundedRowIndex != -1)
                    {
                        SelectedIndex = FoundedRowIndex;
                        SelectionStart = TextToFind.Length;
                        SelectionLength = Text.Length - SelectionStart;
                    }
                    // اگر به هیچ وجه عبارتی شبیه به عبارت وارد شده پیدا نشود
                    else if (NoDataFound != null) NoDataFound(e.KeyChar, EventArgs.Empty);
                }
                else // AutoComplete = false. Treat it like a DropDownList by finding the
                // KeyChar that was struck starting from the current index
                {
                    Int32 FoundedRowIndex = FindString(e.KeyChar.ToString(), SelectedIndex);
                    if (FoundedRowIndex != -1) SelectedIndex = FoundedRowIndex;
                }
            }

            #endregion

            // e.Handled همواره برابر صحیح می باشد چون مدیریت كنترل ، خارج از آن صورت نمی گیرد
            e.Handled = true;
        }
        #endregion

        #endregion

        #region Methods
        private void InitializeColumns()
        {
            if (DataSource != null && !Convert.ToBoolean(_ColumnNameString.Length))
            {
                PropertyDescriptorCollection propertyDescriptorCollection = DataManager.GetItemProperties();
                _TotalWidth = 0;
                _ColumnNames.Clear();
                for (Int32 colIndex = 0; colIndex < propertyDescriptorCollection.Count; colIndex++)
                {
                    _ColumnNames.Add(propertyDescriptorCollection[colIndex].Name);
                    // If the index is greater than the collection of explicitly
                    // set column widths, set any additional columns to the default
                    if (colIndex >= _ColumnWidths.Count) _ColumnWidths.Add(_ColumnWidthDefault);
                    _TotalWidth += _ColumnWidths[colIndex];
                }
            }
            else
            {
                _TotalWidth = 0;
                for (Int32 colIndex = 0; colIndex < _ColumnNames.Count; colIndex++)
                {
                    // If the index is greater than the collection of explicitly
                    // set column widths, set any additional columns to the default
                    if (colIndex >= _ColumnWidths.Count) _ColumnWidths.Add(_ColumnWidthDefault);
                    _TotalWidth += _ColumnWidths[colIndex];
                }
            }
            // Check to see if the programmer is trying to display a column
            // in the linked textbox that is greater than the columns in the 
            // ComboBox. I handle this error by resetting it to zero.
            if (_LinkedColumnIndex >= _ColumnNames.Count)
                _LinkedColumnIndex = 0; // Or replace this with an OutOfBounds Exception
        }
        #endregion

    }
}