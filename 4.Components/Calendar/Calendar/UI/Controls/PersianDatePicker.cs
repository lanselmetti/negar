#region using
using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Negar.PersianCalendar.Resource;
using Negar.PersianCalendar.UI.Design;
using Negar.PersianCalendar.Utilities;
#endregion

namespace Negar.PersianCalendar.UI.Controls
{
    /// <summary>
    /// كنترل تقویم پارسی رایان پرتونگار
    /// </summary>
    [ToolboxItem(true)]
    [DefaultEvent("SelectedDateTimeChanged")]
    [DefaultProperty("SelectedDateTime")]
    [Designer(typeof(PersianDatePickerDesigner))]
    [DefaultBindingProperty("SelectedDateTime")]
    [Description("كنترل تقویم پارسی رایان پرتونگار")]
    [ToolboxBitmap(typeof(DataGridViewPersianDateTimePickerColumn), "Images\\FADatePicker.bmp")]
    public class PersianDatePicker : PersianContainerComboBox
    {
        #region Fields

        #region internal PersianMonthViewContainer _PersianMonthViewContainer
        /// <summary>
        /// نمونه كلاس نمایش تقویم ماهیانه فارسی
        /// </summary>
        internal PersianMonthViewContainer _PersianMonthViewContainer;
        #endregion

        #endregion

        #region Properties

        #region DateTime SelectedDateTime
        /// <summary>
        /// تاریخ انتخاب شده توسط كاربر
        /// </summary>
        [Bindable(true)]
        [Localizable(true)]
        [RefreshProperties(RefreshProperties.All)]
        [Description("تاریخ انتخاب شده توسط كاربر")]
        public DateTime? SelectedDateTime
        {
            get { return _PersianMonthViewContainer.MonthViewControl.SelectedDateTime; }
            set { _PersianMonthViewContainer.MonthViewControl.SelectedDateTime = value; }
        }
        #endregion

        #region Boolean IsAllowNullDate
        /// <summary>
        /// تعیین تهی بودن یا نبودن مقدار تاریخ انتخاب شده
        /// </summary>
        [DefaultValue(true)]
        [Description("تعیین امكان تهی بودن یا نبودن مقدار تاریخ انتخاب شده")]
        public Boolean IsAllowNullDate
        {
            get { return _PersianMonthViewContainer.MonthViewControl.IsAllowNullDate; }
            set
            {
                _PersianMonthViewContainer.MonthViewControl.IsAllowNullDate = value;
                UpdateTextValue();
            }
        }
        #endregion

        #region ScrollOptionTypes ScrollOption
        /// <summary>
        /// تعیین نحوه جابجایی و رفتار كنترل با اسكرول موس
        /// </summary>
        [DefaultValue(typeof(ScrollOptionTypes), "Month")]
        [Description("تعیین نحوه جابجایی و رفتار كنترل با اسكرول موس")]
        public ScrollOptionTypes ScrollOption
        {
            get { return _PersianMonthViewContainer.MonthViewControl.ScrollOption; }
            set { _PersianMonthViewContainer.MonthViewControl.ScrollOption = value; }
        }
        #endregion

        #endregion

        #region Events
        /// <summary>
        /// هنگامی كه مقدار تاریخ كنترل تغییر كند اتفاق می افتد
        /// </summary>
        public event EventHandler SelectedDateTimeChanged;

        /// <summary>
        /// Fires when SelectedDateTime property of the control is changing.
        /// </summary>
        public event SelectedDateTimeChangingEventHandler SelectedDateTimeChanging;
        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض برای ایجاد كلاس كمبوباكس انتخاب تاریخ فارسی
        /// </summary>
        public PersianDatePicker()
        {
            ControlCulture = CultureName.Persian;
            _PersianMonthViewContainer = new PersianMonthViewContainer(this);

            #region Add Event Handlers
            RightToLeftChanged += OnInternalRightToLeftChanged;
            _PersianMonthViewContainer.MonthViewControl.SelectedDateTimeChanged +=
                OnMVSelectedDateTimeChanged;
            _PersianMonthViewContainer.MonthViewControl.ButtonClicked += OnMVButtonClicked;
            PersianLocalizeManager.LocalizerChanged += OnInternalLocalizerChanged;
            PopupShowing += OnInternalPopupShowing;
            TextBox.PreviewKeyDown += (TextBox_PreviewKeyDown);
            TextBox.KeyDown += (TextBox_KeyDown);
            TextBox.MouseWheel += TextBox_MouseWheel;
            TextBox.KeyPress += (TextBox_KeyPress);
            TextBox.TextChanged += (TextBox_TextChanged);
            TextBox.Validating += TextBox_Validating;
            #endregion

            SelectedDateTime = DateTime.Now;
            FormatInfo = FormatInfoTypes.ShortDate;
            BindPopupControlEventArgs args = new BindPopupControlEventArgs(this);
            // ReSharper disable DoNotCallOverridableMethodsInConstructor
            OnBindingPopupControl(args);
            // ReSharper restore DoNotCallOverridableMethodsInConstructor
        }
        #endregion

        #region Event Handlers

        #region OnInternalLocalizerChanged
        private void OnInternalLocalizerChanged(object sender, EventArgs e)
        {
            UpdateTextValue();
        }
        #endregion

        #region OnInternalRightToLeftChanged
        private void OnInternalRightToLeftChanged(object sender, EventArgs e)
        {
            SetPosTextBox();
        }
        #endregion

        #region OnInternalPopupShowing
        private void OnInternalPopupShowing(object sender, EventArgs e)
        {
            Int32 Position = TextBox.SelectionStart;
            // برای تاریخ خالی
            if (TextBox.Text == "    /  /")
            {
                _PersianMonthViewContainer.MonthViewControl.SelectedDateTimeChanged -= OnMVSelectedDateTimeChanged;
                _PersianMonthViewContainer.MonthViewControl.SelectedDateTime = DateTime.Now;
                _PersianMonthViewContainer.MonthViewControl.SelectedDateTimeChanged += OnMVSelectedDateTimeChanged;
            }
            // زمانی كه مقداری ، چه صحیح و چه غلط وارد شده
            else
            {
                ValueValidatingEventArgs args =
                    new ValueValidatingEventArgs(ConvertDateToCorrectNumber(TextBox.Text));
                OnValueValidating(args);
            }
            // با باز شدن كنترل تاریخ ماهیانه ، محل كرسر تغییر نمی كند
            TextBox.SelectionStart = Position;
        }
        #endregion

        #region OnBindingPopupControl
        protected override void OnBindingPopupControl(BindPopupControlEventArgs e)
        {
            e.BindedControl = _PersianMonthViewContainer;
            base.OnBindingPopupControl(e);
        }
        #endregion

        #region OnSelectedDateTimeChanging
        protected virtual void OnSelectedDateTimeChanging(SelectedDateTimeChangingEventArgs e)
        {
            e.Cancel = false;
            if (SelectedDateTimeChanging != null) SelectedDateTimeChanging(this, e);
        }
        #endregion

        #region OnMVSelectedDateTimeChanged
        private void OnMVSelectedDateTimeChanged(object sender, EventArgs e)
        {
            UpdateTextValue();
            if (SelectedDateTimeChanged != null) SelectedDateTimeChanged(this, e);
        }
        #endregion

        #region OnMVButtonClicked
        private void OnMVButtonClicked(object sender, CalendarButtonClickedEventArgs e)
        {
            // در صورتی كه مقداری از كنترل تقویم ماهیانه انتخاب شود ، كنترل ماه بسته می شود
            HideDropDown();
        }
        #endregion

        #region TextBox_PreviewKeyDown
        private void TextBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (IsReadonly && e.KeyData != Keys.Escape) return;
            base.OnPreviewKeyDown(e);

            // Note: مدیریت كلید های بالا و پایین وارد شده در كنترل در اینجا صورت می گیرد
            Int32 Position = TextBox.SelectionStart;

            #region Up Key Pressed
            if (e.KeyData.ToString() == "Up" && SelectedDateTime != null)
            {
                if (Position < 5)
                {
                    PersianDate PDate = SelectedDateTime.Value.ToPersianDate();
                    PDate.Year++;
                    SelectedDateTime = PDate.ToGregorianDateTime();
                }
                else if (Position < 8)
                {
                    PersianDate PDate = SelectedDateTime.Value.ToPersianDate();
                    if (PDate.Month < 12) PDate.Month++;
                    else
                    {
                        PDate.Year++;
                        PDate.Month = 1;
                    }
                    SelectedDateTime = PDate.ToGregorianDateTime();
                }
                else SelectedDateTime = SelectedDateTime.Value.AddDays(1);
            }
            #endregion

            #region Down Key Pressed
            else if (e.KeyData.ToString() == "Down" && SelectedDateTime != null)
            {
                if (Position < 5)
                {
                    PersianDate PDate = SelectedDateTime.Value.ToPersianDate();
                    PDate.Year--;
                    SelectedDateTime = PDate.ToGregorianDateTime();
                }
                else if (Position < 8)
                {
                    PersianDate PDate = SelectedDateTime.Value.ToPersianDate();
                    if (PDate.Month > 1) PDate.Month--;
                    else
                    {
                        PDate.Year--;
                        PDate.Month = 12;
                    }
                    SelectedDateTime = PDate.ToGregorianDateTime();
                }
                else SelectedDateTime = SelectedDateTime.Value.AddDays(-1);
            }
            #endregion

            #region Up Or Down Key With Null Data
            else if ((e.KeyData.ToString() == "Up" || e.KeyData.ToString() == "Down") && SelectedDateTime == null)
                SelectedDateTime = DateTime.Now;
            #endregion
        }
        #endregion

        #region TextBox_KeyDown
        void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // Note: در اینجا مدیریت كلید چپ و راست انجام می گیرد
            #region Left
            if (e.KeyData == Keys.Left && !IsReadonly)
            {
                // اگر بر روی ماه قرار داشته باشد بر روی سال فوكوس می كند
                if (TextBox.SelectionStart >= 5 && TextBox.SelectionStart < 8)
                {
                    TextBox.SelectionStart = 2;
                    TextBox.SelectionLength = 0;
                }
                // اگر بر روی روز قرار داشته باشد بر روی ماه فوكوس می كند
                else if (TextBox.SelectionStart >= 8)
                {
                    TextBox.SelectionStart = 5;
                    TextBox.SelectionLength = 0;
                }
                e.Handled = true;
                return;
            }
            #endregion

            #region Right
            if (e.KeyData == Keys.Right && !IsReadonly)
            {
                // اگر بر روی سال قرار داشته باشد بر روی ماه فوكوس می كند
                if (TextBox.SelectionStart <= 4)
                {
                    TextBox.SelectionStart = 5;
                    TextBox.SelectionLength = 0;
                }
                // اگر بر روی ماه قرار داشته باشد بر روی روز فوكوس می كند
                else if (TextBox.SelectionStart >= 5 && TextBox.SelectionStart < 8)
                {
                    TextBox.SelectionStart = 8;
                    TextBox.SelectionLength = 0;
                }
                e.Handled = true;
                return;
            }
            #endregion
        }
        #endregion

        #region TextBox_KeyPress
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar)) { e.Handled = true; return; }
            if (IsReadonly && e.KeyChar != Convert.ToChar(Keys.Escape)) { e.Handled = true; return; }
            // Note: مدیریت كلید های عددی وارد شده در كنترل در اینجا صورت می گیرد
            Int32 Position = TextBox.SelectionStart;

            if (SelectedDateTime == null || Text == "    /  /") SelectedDateTime = DateTime.Now;
            #region Replace Persian Numbers
            TextBox.TextChanged -= TextBox_TextChanged;
            switch (e.KeyChar)
            {
                case '0': e.KeyChar = '۰'; break;
                case '1': e.KeyChar = '۱'; break;
                case '2': e.KeyChar = '۲'; break;
                case '3': e.KeyChar = '۳'; break;
                case '4': e.KeyChar = '۴'; break;
                case '5': e.KeyChar = '۵'; break;
                case '6': e.KeyChar = '۶'; break;
                case '7': e.KeyChar = '۷'; break;
                case '8': e.KeyChar = '۸'; break;
                case '9': e.KeyChar = '۹'; break;
            }
            TextBox.TextChanged += TextBox_TextChanged;
            String NewDateText = TextBox.Text;
            try
            {
                if (NewDateText.Length == 10) NewDateText = NewDateText.Remove(Position, 1);
                NewDateText = NewDateText.Insert(Position, e.KeyChar.ToString());
            }
            // ReSharper disable EmptyGeneralCatchClause
            catch (Exception) { }
            // ReSharper restore EmptyGeneralCatchClause
            #endregion

            if (Position == 9 || Position == 6)
            {
                e.Handled = true;
                e.KeyChar = Char.MinValue;
            }
            if (Position == 8)
                try
                {
                    if (NewDateText.Substring(8, 1) == "۰" && NewDateText.Substring(9, 1) == "۰")
                    {
                        NewDateText = NewDateText.Remove(9, 1);
                        NewDateText = NewDateText.Insert(9, "۱");
                    }
                    // تغییر تاریخ جاری بر اساس مقدار وارد شده جدید
                    SelectedDateTime =
                        PersianDate.Parse(ConvertDateToCorrectNumber(NewDateText)).ToGregorianDateTime();
                }
                // ReSharper disable EmptyGeneralCatchClause
                catch (Exception) { }
            else if (Position == 9 || Position == 6)
            {
                try
                {
                    // تغییر تاریخ جاری بر اساس مقدار وارد شده جدید
                    SelectedDateTime =
                        PersianDate.Parse(ConvertDateToCorrectNumber(NewDateText)).ToGregorianDateTime();
                }
                // ReSharper disable EmptyGeneralCatchClause
                catch (Exception)
                {
                    TextBox.Text = NewDateText;
                }
            }
            // ReSharper restore EmptyGeneralCatchClause
            base.OnKeyPress(e);
            if (Position == 9) TextBox.SelectionStart = 5;
            else if (Position == 6) TextBox.SelectionStart = 2;
            else TextBox.SelectionStart = Position;
        }
        #endregion

        #region TextBox_TextChanged
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            // Note: با تغییر متن جعبه متن ، مقدار وارد شده از نظر فارسی بودن اعداد اصلاح می شود
            Int32 Position = TextBox.SelectionStart;
            String NewText = TextBox.Text;
            NewText = NewText.Replace("0", "۰");
            NewText = NewText.Replace("1", "۱");
            NewText = NewText.Replace("2", "۲");
            NewText = NewText.Replace("3", "۳");
            NewText = NewText.Replace("4", "۴");
            NewText = NewText.Replace("5", "۵");
            NewText = NewText.Replace("6", "۶");
            NewText = NewText.Replace("7", "۷");
            NewText = NewText.Replace("8", "۸");
            NewText = NewText.Replace("9", "۹");
            Text = NewText;
            TextBox.SelectionStart = Position;
        }
        #endregion

        #region TextBox_Validating
        private void TextBox_Validating(object sender, EventArgs e)
        {
            Int32 Position = TextBox.SelectionStart;
            String NewText = TextBox.Text;
            NewText = NewText.Replace("0", "۰");
            NewText = NewText.Replace("1", "۱");
            NewText = NewText.Replace("2", "۲");
            NewText = NewText.Replace("3", "۳");
            NewText = NewText.Replace("4", "۴");
            NewText = NewText.Replace("5", "۵");
            NewText = NewText.Replace("6", "۶");
            NewText = NewText.Replace("7", "۷");
            NewText = NewText.Replace("8", "۸");
            NewText = NewText.Replace("9", "۹");
            Text = NewText;
            TextBox.SelectionStart = Position;
        }
        #endregion

        #region TextBox_MouseWheel
        void TextBox_MouseWheel(object sender, MouseEventArgs e)
        {
            if (IsReadonly) return;
            Int32 Position = TextBox.SelectionStart;
            // Note: مدیریت كلید های وسط موس در كنترل در اینجا صورت می گیرد

            #region Up Key Pressed
            if (e.Delta > 0 && SelectedDateTime != null)
            {
                if (Position < 5)
                {
                    PersianDate PDate = SelectedDateTime.Value.ToPersianDate();
                    PDate.Year++;
                    SelectedDateTime = PDate.ToGregorianDateTime();
                }
                else if (Position < 8)
                {
                    PersianDate PDate = SelectedDateTime.Value.ToPersianDate();
                    if (PDate.Month < 12) PDate.Month++;
                    else
                    {
                        PDate.Year++;
                        PDate.Month = 1;
                    }
                    SelectedDateTime = PDate.ToGregorianDateTime();
                }
                else SelectedDateTime = SelectedDateTime.Value.AddDays(1);
            }
            #endregion

            #region Down Key Pressed
            else if (e.Delta < 0 && SelectedDateTime != null)
            {
                if (Position < 5)
                {
                    PersianDate PDate = SelectedDateTime.Value.ToPersianDate();
                    PDate.Year--;
                    SelectedDateTime = PDate.ToGregorianDateTime();
                }
                else if (Position < 8)
                {
                    PersianDate PDate = SelectedDateTime.Value.ToPersianDate();
                    if (PDate.Month > 1) PDate.Month--;
                    else
                    {
                        PDate.Year--;
                        PDate.Month = 12;
                    }
                    SelectedDateTime = PDate.ToGregorianDateTime();
                }
                else SelectedDateTime = SelectedDateTime.Value.AddDays(-1);
            }
            #endregion

            else if (SelectedDateTime == null) SelectedDateTime = DateTime.Now;

            TextBox.SelectionStart = Position;
        }
        #endregion

        #endregion

        #region Methods

        #region public Boolean ShouldSerializeSelectedDateTime()
        /// <summary>
        /// Decides to serialize the SelectedDateTime property or not.
        /// </summary>
        /// <returns></returns>
        public Boolean ShouldSerializeSelectedDateTime()
        {
            return SelectedDateTime != null;
        }
        #endregion

        #region public void ResetSelectedDateTime()
        /// <summary>
        /// Rests SelectedDateTime to default value.
        /// </summary>
        public void ResetSelectedDateTime()
        {
            SelectedDateTime = null;
        }
        #endregion

        #region private static String ConvertDateToCorrectNumber(String NewText)
        private static String ConvertDateToCorrectNumber(String NewText)
        {
            NewText = NewText.Replace("۰", "0");
            NewText = NewText.Replace("۱", "1");
            NewText = NewText.Replace("۲", "2");
            NewText = NewText.Replace("۳", "3");
            NewText = NewText.Replace("۴", "4");
            NewText = NewText.Replace("۵", "5");
            NewText = NewText.Replace("۶", "6");
            NewText = NewText.Replace("۷", "7");
            NewText = NewText.Replace("۸", "8");
            NewText = NewText.Replace("۹", "9");
            return NewText;
        }
        #endregion

        #endregion

        #region Overrided Methods

        #region protected override void OnValidating(CancelEventArgs e)
        protected override void OnValidating(CancelEventArgs e)
        {
            ValueValidatingEventArgs args = new ValueValidatingEventArgs(ConvertDateToCorrectNumber(TextBox.Text));
            OnValueValidating(args);
            e.Cancel = args.HasError;
            base.OnValidating(e);
        }
        #endregion

        #region protected override void OnValueValidating(ValueValidatingEventArgs e)
        /// <summary>
        /// در هنگام تایید اعتبار تاریخ عددی وارد شده ، این روال فراخوانی می گردد
        /// </summary>
        protected override void OnValueValidating(ValueValidatingEventArgs e)
        {
            try
            {
                String ValidatedText = e.Value.ToString();
                ValidatedText = ConvertDateToCorrectNumber(ValidatedText);

                #region For Persian Culture
                if (Thread.CurrentThread.CurrentCulture.Equals(
                    _PersianMonthViewContainer.MonthViewControl.PersianCulture))
                {
                    PersianDate FarsiDate = PersianDate.Parse(ValidatedText, GetFormatByFormatInfo(FormatInfo));
                    e.HasError = false;
                    _PersianMonthViewContainer.MonthViewControl.SelectedDateTime = FarsiDate;
                }
                #endregion

                #region For English Culture
                else if (Thread.CurrentThread.CurrentCulture.
                    Equals(_PersianMonthViewContainer.MonthViewControl.InvariantCulture))
                {
                    DateTime EnDateTime = DateTime.Parse(ValidatedText);
                    e.HasError = false;
                    _PersianMonthViewContainer.MonthViewControl.SelectedDateTime = EnDateTime;
                }
                #endregion
            }
            catch (Exception)
            {
                if (_PersianMonthViewContainer.MonthViewControl.IsAllowNullDate)
                    _PersianMonthViewContainer.MonthViewControl.SelectedDateTime = null;
                else _PersianMonthViewContainer.MonthViewControl.SelectedDateTime = DateTime.Now;
                UpdateTextValue();
            }
        }
        #endregion

        #region public override void UpdateTextValue()
        /// <summary>
        /// تابع به روز رسانی جعبه متن بر اساس تاریخ انتخاب شده
        /// </summary>
        public override void UpdateTextValue()
        {
            Int32 Position = TextBox.SelectionStart;
            // اگر مقدار انتخاب شده تهی باشد جعبه متن پاك می شود
            if (_PersianMonthViewContainer.MonthViewControl.SelectedDateTime == null) TextBox.Text = String.Empty;
            else
            {
                #region For Persian Date
                if (Thread.CurrentThread.CurrentCulture.Equals(
                    _PersianMonthViewContainer.MonthViewControl.PersianCulture))
                    TextBox.Text = SelectedDateTime.Value.ToPersianDate().
                        ToString(GetFormatByFormatInfo(FormatInfo));
                #endregion

                #region For Other Cultures Date
                else
                    TextBox.Text = SelectedDateTime.Value.ToString(GetFormatByFormatInfo(FormatInfo),
                        Thread.CurrentThread.CurrentCulture);
                #endregion
            }
            // با تغییر مقدار تاریخ از كنترل تاریخ ماهیانه ، محل كرسر تغییر نمی كند
            TextBox.TextChanged -= TextBox_TextChanged;
            TextBox.SelectionStart = Position;
            TextBox.TextChanged += TextBox_TextChanged;
        }
        #endregion

        #endregion

    }
}