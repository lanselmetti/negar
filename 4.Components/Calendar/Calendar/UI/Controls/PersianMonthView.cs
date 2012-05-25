#region using
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using Negar.PersianCalendar.Resource;
using Negar.PersianCalendar.UI.BaseClasses;
using Negar.PersianCalendar.UI.Design;
using Negar.PersianCalendar.Utilities;
#endregion

namespace Negar.PersianCalendar.UI.Controls
{
    /// <summary>
    /// كنترل نمایش تقویم ماهیانه رایان پرتونگار
    /// </summary>
    [ToolboxItem(true)]
    [Designer(typeof(PersianMonthViewDesigner))]
    [DefaultEvent("SelectedDateTimeChanged")]
    [DefaultProperty("SelectedDateTime")]
    [ToolboxBitmap(typeof(PersianMonthView))]
    public class PersianMonthView : BaseStyledControl
    {

        #region Fields

        #region Constants Fields
        private const Int32 DEF_ARROW_SIZE = 3;
        private const Int32 DEF_BUTTON_HEIGHT = 23;
        private const Int32 DEF_BUTTON_WIDTH = 60;
        private const Int32 DEF_COLUMNS_COUNT = 7;
        private const Int32 DEF_FOOTER_SIZE = 27;
        private const Int32 DEF_HEADER_SIZE = 21;
        private const Int32 DEF_NONE_TAB_INDEX = 101;
        private const Int32 DEF_ROWS_COUNT = 7;
        private const Int32 DEF_ROWS_MARGIN = 3;
        private const Int32 DEF_TODAY_TAB_INDEX = 100;
        private const Int32 DEF_WEEK_DAY_HEIGHT = 20;
        #endregion

        private readonly GregorianCalendar _GCal;
        private readonly HijriCalendar _HijCal;
        private readonly Utilities.PersianCalendar _PerCal;
        private Calendar _CustomCalendar;

        private readonly ArrayList _RectsList = new ArrayList(100);
        private readonly ArrayList _SelectedRects = new ArrayList();
        private readonly StringFormat _StringFormat;

        private Int32? _iDay;
        private Int32 _iLastFocused = 1;
        private Int32? _iMonth;

        /// <summary>
        /// 
        /// </summary>
        private Boolean _IsAllowNullDate;

        /// <summary>
        /// تعیین نمایش حاشیه اطراف كنترل
        /// </summary>
        private Boolean _IsBorderVisible = true;

        /// <summary>
        /// تعیین نمایش روز انتخاب شده به صورت گرافیكی
        /// </summary>
        private Boolean _IsFocusRectVisible;

        private Boolean _IsNoneButtonFocused;
        private Boolean _IsTodayButtonFocused;

        private Int32? _iYear;
        private Rectangle _rcBody;
        private Rectangle _rcFooter;
        private Boolean _RectsCreated;
        private ScrollOptionTypes _ScrollOption;
        /// <summary>
        /// تاریخ جاری انتخاب شده توسط كاربر
        /// </summary>
        private DateTime? _SelectedGregorianDate;

        private Rectangle _rcHeader;
        #endregion

        #region Events

        /// <summary>
        /// Fires when SelectedDateTime value changes.
        /// </summary>
        public event EventHandler SelectedDateTimeChanged;

        /// <summary>
        /// Fires when Day value changes.
        /// </summary>
        public event EventHandler DayChanged;

        /// <summary>
        /// Fires when MonthValue changes.
        /// </summary>
        public event EventHandler MonthChanged;

        /// <summary>
        /// Fires when Year value changes.
        /// </summary>
        public event EventHandler YearChanged;

        /// <summary>
        /// Fires when current day is being printed.
        /// </summary>
        public event CustomDrawDayEventHandler DrawCurrentDay;

        /// <summary>
        /// Fires when user clicks on a day, None button or Today button.
        /// </summary>
        public event CalendarButtonClickedEventHandler ButtonClicked;

        #endregion

        #region Properties

        #region public DateTime? SelectedDateTime
        /// <summary>
        /// تاریخ جاری انتخاب شده توسط كاربر
        /// </summary>
        [Description("تاریخ جاری انتخاب شده توسط كاربر.")]
        [RefreshProperties(RefreshProperties.All)]
        [Bindable(true)]
        [Localizable(true)]
        public DateTime? SelectedDateTime
        {
            get { return _SelectedGregorianDate; }
            set
            {
                // در صورتی كه كاربر مجاز به ثبت مقدار تهی نباشد و این مقدار ثبت شود عملیات لغو می گردد
                if (!_IsAllowNullDate && value == null) return;
                _SelectedGregorianDate = value;
                if (value != null)
                {
                    _iDay = DefaultCalendar.GetDayOfMonth(_SelectedGregorianDate.Value);
                    OnDayChanged(EventArgs.Empty);
                    _iMonth = DefaultCalendar.GetMonth(_SelectedGregorianDate.Value);
                    OnMonthChanged(EventArgs.Empty);
                    _iYear = DefaultCalendar.GetYear(_SelectedGregorianDate.Value);
                    OnYearChanged(EventArgs.Empty);
                }
                _RectsCreated = false;
                Invalidate();
                OnSelectedDateTimeChanged(EventArgs.Empty);
            }
        }
        #endregion

        #region public Boolean IsAllowNullDate
        /// <summary>
        /// تعیین كننده مجوز كاربر برای تهی كردن مقدار تاریخ
        /// </summary>
        [DefaultValue(true)]
        [RefreshProperties(RefreshProperties.All)]
        public Boolean IsAllowNullDate
        {
            get { return _IsAllowNullDate; }
            set
            {
                // اگر كاربر مجوز ثبت مقدار تهی برای تاریخ را بگیرد
                // اما مقدار جاری تهی باشد ،مقدار تاریخ به تاریخ امروز تغییر می كند
                _IsAllowNullDate = value;
                if (!value && _SelectedGregorianDate == null)
                    SelectedDateTime = DateTime.Now;
                Invalidate();
            }
        }
        #endregion

        #region public Boolean IsPopupMode
        /// <summary>
        /// Is control in popup mode?
        /// </summary>
        [Browsable(false)]
        [DefaultValue(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Boolean IsPopupMode { get; set; }
        #endregion

        #region public ScrollOptionTypes ScrollOption
        /// <summary>
        /// تنظیم كننده نوع حركت تقویم بر اساس حركت اسكرول موس
        /// </summary>
        [DefaultValue(typeof(ScrollOptionTypes), "Month")]
        [Description("تنظیم كننده نوع حركت تقویم بر اساس حركت اسكرول موس")]
        public ScrollOptionTypes ScrollOption
        {
            get { return _ScrollOption; }
            set { if (_ScrollOption != value) _ScrollOption = value; }
        }
        #endregion

        #region internal StringFormat OneLineNoTrimming
        [Browsable(false)]
        internal StringFormat OneLineNoTrimming
        {
            get
            {
                _StringFormat.Alignment = StringAlignment.Center;
                _StringFormat.LineAlignment = StringAlignment.Center;
                _StringFormat.Trimming = StringTrimming.None;
                _StringFormat.FormatFlags = StringFormatFlags.LineLimit;
                _StringFormat.HotkeyPrefix = HotkeyPrefix.Show;

                return _StringFormat;
            }
        }
        #endregion

        #region public Int32 Day
        /// <summary>
        /// روز تاریخ انتخاب شده
        /// </summary>
        [Browsable(false)]
        public Int32? Day
        {
            get { return _iDay; }
        }
        #endregion

        #region public Int32 Month
        /// <summary>
        /// ماه تاریخ انتخاب شده
        /// </summary>
        [Browsable(false)]
        public Int32? Month
        {
            get { return _iMonth; }
        }
        #endregion

        #region public Int32 Year
        /// <summary>
        /// دریافت سال تاریخ جاری
        /// </summary>
        [Browsable(false)]
        public Int32? Year
        {
            get { return _iYear; }
        }
        #endregion

        #region public PersianCalendar PersianCalendar
        /// <summary>
        /// شیء تقویم فارسی كنترل
        /// </summary>
        [Browsable(false)]
        public Utilities.PersianCalendar PersianCalendar
        {
            get { return _PerCal; }
        }
        #endregion

        #region public Boolean ShowBorder
        /// <summary>
        /// تعیین نمایش حاشیه اطراف كنترل
        /// </summary>
        [DefaultValue(true)]
        [Description("تعیین نمایش حاشیه اطراف كنترل.")]
        public Boolean ShowBorder
        {
            get { return _IsBorderVisible; }
            set
            {
                if (_IsBorderVisible == value) return;
                _IsBorderVisible = value;
                Invalidate();
            }
        }
        #endregion

        #region public Boolean ShowFocusRect
        /// <summary>
        /// تعیین نمایش گرافیكی روز انتخاب شده در تقویم
        /// </summary>
        [DefaultValue(true)]
        [Description("تعیین نمایش گرافیكی روز انتخاب شده در تقویم.")]
        public Boolean ShowFocusRect
        {
            get { return _IsFocusRectVisible; }
            set
            {
                if (_IsFocusRectVisible == value) return;
                _IsFocusRectVisible = value;
                Invalidate();
            }
        }
        #endregion

        #region public new Size Size
        /// <summary>
        /// Size of the control that can not be changes. Control's size is fixed to 166 x 166 pixels.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Size Size
        {
            get { return new Size(166, 166); }
        }
        #endregion

        #region private static Boolean IsRightToLeftCulture
        private static Boolean IsRightToLeftCulture
        {
            get { return Thread.CurrentThread.CurrentCulture.TextInfo.IsRightToLeft; }
        }
        #endregion

        #region public String CurrentMonthName
        /// <summary>
        /// Current Month name shown in the view.
        /// </summary>
        [Browsable(false)]
        public String CurrentMonthName
        {
            get
            {
                if (Thread.CurrentThread.CurrentCulture.Equals(PersianLocalizeManager.FarsiCulture))
                    return PersianDate.PersianMonthNames.Default[_iMonth.Value];
                return Thread.CurrentThread.CurrentCulture.DateTimeFormat.
                    MonthGenitiveNames[_iMonth.Value - 1].ToUpper();
            }
        }
        #endregion

        #region ** Cultures Props **
        /// <summary>
        /// Arabic culture supported by the control : ("Ar-Sa")
        /// </summary>
        [Browsable(false)]
        public CultureInfo ArabicCulture
        {
            get { return PersianLocalizeManager.ArabicCulture; }
        }

        /// <summary>
        /// Invariant culture supported by the control.
        /// </summary>
        [Browsable(false)]
        public CultureInfo InvariantCulture
        {
            get { return PersianLocalizeManager.InvariantCulture; }
        }

        /// <summary>
        /// Persian culture supported by the control. ("Fa-Ir")
        /// </summary>
        [Browsable(false)]
        public CultureInfo PersianCulture
        {
            get { return PersianLocalizeManager.FarsiCulture; }
        }
        #endregion

        #region ** Calendar Props **

        #region public Calendar InvariantCalendar

        /// <summary>
        /// GregorianCalendar instance with which controls calculates values of <see cref="InvariantCulture"/>.
        /// </summary>
        [Browsable(false)]
        public Calendar InvariantCalendar
        {
            get { return _GCal; }
        }

        #endregion

        #region public Calendar HijriCalendar
        /// <summary>
        /// HijriCalendar instance with which controls calculates values of <see cref="ArabicCulture"/>.
        /// </summary>
        [Browsable(false)]
        public Calendar HijriCalendar
        {
            get { return _HijCal; }
        }
        #endregion

        #region public Calendar DefaultCalendar
        /// <summary>
        /// Default calendar of the control, based on <see cref="Thread.CurrentCulture"/> 
        /// and <see cref="Thread.CurrentUICulture"/> properties.
        /// </summary>
        [Browsable(false)]
        public Calendar DefaultCalendar
        {
            get { return GetCurrentCalendar(); }
            set
            {
                _CustomCalendar = value;
                _iYear = DefaultCalendar.GetYear(_SelectedGregorianDate.Value);
                Invalidate();
            }
        }
        #endregion

        #endregion

        #region ** Hidden Props **

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Bindable(false)]
        public override String Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override DockStyle Dock
        {
            get { return DockStyle.None; }
            set { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override AnchorStyles Anchor
        {
            get { return AnchorStyles.None; }
            set { }
        }

        #endregion

        #endregion

        #region Ctors && Dispose Method
        /// <summary>
        /// سازنده كنترل.
        /// </summary>
        /// <param name="popupMode"></param>
        public PersianMonthView(Boolean popupMode)
        {
            IsPopupMode = popupMode;
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);

            _PerCal = new Utilities.PersianCalendar();
            _GCal = new GregorianCalendar();
            _HijCal = new HijriCalendar();

            base.Size = new Size(166, 166);
            base.Font = new Font("Tahoma", 8.25F);
            SelectedDateTime = DateTime.Now;
            _StringFormat = new StringFormat();
            _ScrollOption = ScrollOptionTypes.Month;
            _IsAllowNullDate = true;
            PersianLocalizeManager.LocalizerChanged += OnInternalLocalizeChanged;
        }

        /// <summary>
        /// Creates a new instance of PersianMonthView for normal mode usage.
        /// </summary>
        public PersianMonthView()
            : this(false)
        {
        }

        /// <summary>
        /// Disposes the control.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(Boolean disposing)
        {
            if (disposing && _StringFormat != null) _StringFormat.Dispose();
            base.Dispose(disposing);
        }
        #endregion

        #region Paint Methods

        #region protected override void OnPaint(PaintEventArgs ThePaintEventArgs)
        protected override void OnPaint(PaintEventArgs ThePaintEventArgs)
        {
            if (!CanUpdate) return;
            try
            {
                BeginUpdate();

                Rectangle rc = new Rectangle(0, 0, Width, Height);

                // Active rectangles must be rebuild
                if (_RectsCreated == false) _RectsList.Clear();

                OnDrawHeader(new PaintEventArgs(ThePaintEventArgs.Graphics, _rcHeader));
                OnDrawFooter(new PaintEventArgs(ThePaintEventArgs.Graphics, _rcFooter));

                if (_RectsCreated == false)
                {
                    _rcBody = new Rectangle(rc.X, _rcHeader.Bottom, rc.Width, _rcFooter.Top - _rcHeader.Bottom);
                    _rcBody = Rectangle.Inflate(_rcBody, -4, -1);
                }

                OnDrawBody(new PaintEventArgs(ThePaintEventArgs.Graphics, _rcBody));
                OnDrawBorder(new PaintEventArgs(ThePaintEventArgs.Graphics, rc));

                _RectsCreated = true;
            }
            finally
            {
                EndUpdate();
            }
        }
        #endregion

        #region protected override void OnPaintBackground(PaintEventArgs pevent)
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            if (!CanUpdate) return;
            try
            {
                BeginUpdate();
                Graphics g = pevent.Graphics;
                var rc = new Rectangle(0, 0, Width, Height);
                Painter.DrawFilledBackground(g, rc, false, 90f);
                // Draw header background
                _rcHeader = new Rectangle(rc.X + 1, rc.Y + 1, rc.Width - 2, DEF_HEADER_SIZE);
                Painter.DrawButton(g, _rcHeader, String.Empty, Font, null, ItemState.Normal, false, true);
                // Construct footer rect
                Int32 yBott = rc.Bottom - DEF_FOOTER_SIZE - 1;
                _rcFooter = new Rectangle(rc.X + 6, yBott, rc.Width - 12, DEF_FOOTER_SIZE);
            }
            finally
            {
                EndUpdate();
            }
        }
        #endregion

        #region private void OnDrawBorder(PaintEventArgs e)
        private void OnDrawBorder(PaintEventArgs e)
        {
            if (ShowBorder)
            {
                Rectangle border = new Rectangle(e.ClipRectangle.X, e.ClipRectangle.Y, e.ClipRectangle.Width - 1,
                    e.ClipRectangle.Height - 1);
                Painter.DrawBorder(e.Graphics, border, false);
            }
        }
        #endregion

        #region private void OnDrawHeader(PaintEventArgs pevent)
        private void OnDrawHeader(PaintEventArgs pevent)
        {
            Rectangle rc = pevent.ClipRectangle;
            Rectangle rcOut = Rectangle.Inflate(rc, -6, -1);
            PaintEventArgs ev = new PaintEventArgs(pevent.Graphics, rcOut);
            OnDrawMonthHeader(ev);
            OnDrawYearHeader(ev);
        }
        #endregion

        #region private void OnDrawMonthHeader(PaintEventArgs pevent)
        private void OnDrawMonthHeader(PaintEventArgs pevent)
        {
            // Note: رسم عنوان ماه
            Font TheFont = new Font("Tahoma", 8, FontStyle.Bold | FontStyle.Underline);
            Brush TheBrush = Brushes.Red;

            Graphics g = pevent.Graphics;
            Rectangle rc = pevent.ClipRectangle;

            String strMonth = CurrentMonthName;
            String strLongestMonth = PersianDate.PersianMonthNames.Default.Ordibehesht;
            // رسم پوینتر سمت چپ
            Rectangle rect = Painter.DrawArrow(g, rc, true, false, DEF_ARROW_SIZE);
            AddActiveRect(rect, TRectangleAction.MonthDown);

            SizeF sz = g.MeasureString(strLongestMonth, Font);
            Rectangle rcText = new Rectangle(rect.Right + 4, rc.Y, (Int32)sz.Width + 20, rc.Height);
            g.DrawString(strMonth, TheFont, TheBrush, rcText, OneLineNoTrimming);
            // رسم پوینتر سمت راست
            rect = Painter.DrawArrow(g, new Rectangle(rcText.Right + 4, rc.Y, 100, rc.Height), false, false,
                DEF_ARROW_SIZE);
            AddActiveRect(rect, TRectangleAction.MonthUp);
        }
        #endregion

        #region private void OnDrawYearHeader(PaintEventArgs pevent)
        private void OnDrawYearHeader(PaintEventArgs pevent)
        {
            // Note: رسم سال جاری
            Font TheFont = new Font("Tahoma", 8, FontStyle.Bold);
            Graphics g = pevent.Graphics;
            Rectangle rc = pevent.ClipRectangle;
            String strYear = toFarsi.Convert(_iYear.ToString(), Thread.CurrentThread.CurrentCulture);
            Rectangle rect = Painter.DrawArrow(g,
                new Rectangle(rc.Right - 4 - DEF_ARROW_SIZE - 2, rc.Y, DEF_ARROW_SIZE * 2,
                    rc.Height), false, false, DEF_ARROW_SIZE);
            AddActiveRect(rect, TRectangleAction.YearUp);

            SizeF sz = g.MeasureString(strYear, Font);
            Rectangle rcText = new Rectangle(rect.Left - 4 - (Int32)sz.Width - 8, rc.Y, (Int32)sz.Width + 8, rc.Height);
            g.DrawString(strYear, TheFont, SystemBrushes.WindowText, rcText, OneLineNoTrimming);
            rect = Painter.DrawArrow(g,
                new Rectangle(rcText.Left - 4 - DEF_ARROW_SIZE - 2, rc.Y, DEF_ARROW_SIZE * 2,
                    rc.Height), true, false, DEF_ARROW_SIZE);
            AddActiveRect(rect, TRectangleAction.YearDown);
        }
        #endregion

        #region private void OnDrawFooter(PaintEventArgs pevent)
        private void OnDrawFooter(PaintEventArgs pevent)
        {
            Graphics g = pevent.Graphics;
            OnDrawFooterButtons(new PaintEventArgs(g, _rcFooter));
        }
        #endregion

        #region private void OnDrawFooterButtons(PaintEventArgs pevent)
        private void OnDrawFooterButtons(PaintEventArgs pevent)
        {
            // Note: رسم دكمه های پایین كنترل
            Graphics g = pevent.Graphics;
            Rectangle rc = pevent.ClipRectangle;

            const Int32 buttonSpace = 10;
            Int32 margin = ((rc.Width - (DEF_BUTTON_WIDTH * 2) - buttonSpace) / 2);

            StringFormat fmt = new StringFormat();
            fmt.Alignment = StringAlignment.Center;
            fmt.LineAlignment = StringAlignment.Center;
            fmt.Trimming = StringTrimming.None;
            fmt.FormatFlags |= StringFormatFlags.DirectionRightToLeft | StringFormatFlags.NoWrap;

            Rectangle rcToday = new Rectangle(rc.X + margin, rc.Y + rc.Height / 2 - DEF_BUTTON_HEIGHT / 2,
                DEF_BUTTON_WIDTH, DEF_BUTTON_HEIGHT);
            Rectangle rcNone = new Rectangle(rcToday.Right + buttonSpace, rcToday.Y, rcToday.Width, rcToday.Height);
            AddActiveRect(rcToday, TRectangleAction.TodayBtn, DEF_TODAY_TAB_INDEX);
            AddActiveRect(rcNone, TRectangleAction.NoneBtn, DEF_NONE_TAB_INDEX);

            ItemState noneState = ItemState.Normal;
            if (_IsNoneButtonFocused) noneState = ItemState.HotTrack;
            ItemState todayState = ItemState.Normal;
            if (_IsTodayButtonFocused) todayState = ItemState.HotTrack;

            Font ButtonFonts = new Font("Tahoma", 8, FontStyle.Bold);
            // Note: محل رسم دكمه "خالی" بر روی كنترل
            if (_IsAllowNullDate)
            {
                Painter.DrawButton(g, rcNone,
                    PersianLocalizeManager.GetLocalizerByCulture(Thread.CurrentThread.CurrentCulture).GetLocalizedString(
                    StringIDEnum.FAMonthView_None), ButtonFonts, fmt, noneState, true, true);
            }
            // Note: محل رسم دكمه "امروز" بر روی كنترل
            Painter.DrawButton(g, rcToday,
                PersianLocalizeManager.GetLocalizerByCulture(Thread.CurrentThread.CurrentCulture).
                GetLocalizedString(StringIDEnum.FAMonthView_Today), ButtonFonts, fmt, todayState, true, true);

            fmt.Dispose();
        }
        #endregion

        #region private void OnDrawBody(PaintEventArgs pevent)
        private void OnDrawBody(PaintEventArgs pevent)
        {
            // Note: رسم ایام ماه جاری تقویم
            Font TheFont = new Font("Tahoma", 8, FontStyle.Bold);
            Graphics g = pevent.Graphics;
            Rectangle rc = pevent.ClipRectangle;

            Int32 iColWidth = rc.Width / DEF_COLUMNS_COUNT;
            Int32 iRowHeight = (rc.Height - DEF_WEEK_DAY_HEIGHT) / DEF_ROWS_COUNT;

            #region Top Separator
            Painter.DrawSeparator(g, new Point(rc.X + 2, rc.Y + DEF_WEEK_DAY_HEIGHT - 3),
                new Point(rc.Right - 2, rc.Y + DEF_WEEK_DAY_HEIGHT - 3));
            #endregion

            #region Weekday Name
            Brush TheBrush = Brushes.Green;
            Rectangle rcHead = new Rectangle(rc.X, rc.Y, iColWidth, DEF_WEEK_DAY_HEIGHT - 3);
            if (IsRightToLeftCulture)
            {
                for (Int32 i = DEF_COLUMNS_COUNT; i > 0; i--)
                {
                    rcHead.X = rc.Width - (i * iColWidth);
                    String strDayWeek = GetAbbrDayName(i - 1);
                    g.DrawString(strDayWeek, TheFont, TheBrush, rcHead, OneLineNoTrimming);
                }
            }
            else
            {
                for (Int32 i = 0; i < DEF_COLUMNS_COUNT; i++)
                {
                    rcHead.X = rc.X + (i * iColWidth);
                    String strDayWeek = GetAbbrDayName(i);
                    g.DrawString(strDayWeek, TheFont, TheBrush, rcHead, OneLineNoTrimming);
                }
            }
            #endregion

            #region Calculate Month Values
            // How many days are in DrawTab month and first day of month
            Int32 numDays = DefaultCalendar.GetDaysInMonth(_iYear.Value, _iMonth.Value);
            DateTime dtStartOfMonth = new DateTime(_iYear.Value, _iMonth.Value, 1, 0, 0, 0, DefaultCalendar);
            PersianDate X = PersianDateConverter.ToPersianDate(dtStartOfMonth);
            Int32 firstDay = GetFirstDayOfWeek(PersianDateConverter.ToGregorianDateTime(X));

            Int32 rowNo = 1;

            Int32 iLastMonth = _iMonth.Value;
            Int32 iLastYear = _iYear.Value;

            if (_iMonth - 1 < 1 && iLastYear > 1)
            {
                iLastMonth = 12;
                iLastYear--;
            }
            else if (iLastMonth - 1 > 0) iLastMonth--;

            Int32 prevMonthDays = DefaultCalendar.GetDaysInMonth(iLastYear, iLastMonth);
            Int32 lastingDays = prevMonthDays - firstDay;
            Brush brush = Brushes.Gray;
            Rectangle rcDay;

            if (IsRightToLeftCulture)
                rcDay = new Rectangle(rcHead.X, rc.Y + DEF_WEEK_DAY_HEIGHT, rcHead.Width - 2, iRowHeight + 1);
            else rcDay = new Rectangle(rc.X, rc.Y + DEF_WEEK_DAY_HEIGHT, rcHead.Width - 2, iRowHeight + 1);
            #endregion

            #region Pre-Day Padding
            for (Int32 y = lastingDays; y < prevMonthDays; y++)
            {
                // ایام غیر فعال
                String disabledDay = toFarsi.Convert((y + 1).ToString(), Thread.CurrentThread.CurrentCulture);
                g.DrawString(disabledDay, Font, brush, rcDay, OneLineNoTrimming);

                if (IsRightToLeftCulture) rcDay.X = rcDay.X - iColWidth;
                else rcDay.X = rcDay.X + iColWidth;
            }
            #endregion

            #region Current Day
            for (Int32 x = 1; x <= numDays; x++)
            {
                brush = SystemBrushes.WindowText;

                //draw weekday header names
                String DayNo = toFarsi.Convert(x.ToString(), Thread.CurrentThread.CurrentCulture);
                Int32 index = x;

                if (_iDay == x) //Current Day
                {
                    AddActiveRect(rcDay, TRectangleAction.MonthDay, index);
                    CustomDrawDayEventArgs args = new CustomDrawDayEventArgs(rcDay, g, _iYear.Value, _iMonth.Value, x, true);
                    OnDrawCurrentDay(args);

                    if (!args.Handled)
                    {
                        if (SelectedDateTime != null && !ShowFocusRect)
                            Painter.DrawSelectedPanel(g, rcDay);
                        else if (SelectedDateTime != null && ShowFocusRect)
                            Painter.DrawFocusRect(g, rcDay);
                        else if (SelectedDateTime == null)
                            Painter.DrawSelectionBorder(g, rcDay);

                        g.DrawString(DayNo, TheFont, SystemBrushes.ControlText, rcDay, OneLineNoTrimming);
                    }
                }
                else //Other Days
                {
                    AddActiveRect(rcDay, TRectangleAction.MonthDay, index);
                    CustomDrawDayEventArgs args =
                        new CustomDrawDayEventArgs(rcDay, g, _iYear.Value, _iMonth.Value, x, false);
                    OnDrawCurrentDay(args);

                    if (!args.Handled)
                    {
                        g.DrawString(DayNo, TheFont, brush, rcDay, OneLineNoTrimming);
                    }
                }

                if (IsRightToLeftCulture)
                {
                    rcDay.X = rcDay.X - iColWidth;

                    if (rcDay.X < 0)
                    {
                        rowNo++;
                        rcDay.X = rcHead.X;
                        rcDay.Y = rcDay.Y + iRowHeight + DEF_ROWS_MARGIN;
                    }
                }
                else
                {
                    rcDay.X = rcDay.X + iColWidth;

                    if (rcDay.X > rc.Width - rcDay.Width)
                    {
                        rowNo++;
                        rcDay.X = rc.X;
                        rcDay.Y = rcDay.Y + iRowHeight + DEF_ROWS_MARGIN;
                    }
                }
            }
            #endregion

            #region Post-Day Padding
            // Draw next month starting days as disabled
            Int32 endDay;
            brush = Brushes.Gray;

            if (firstDay != 0) endDay = numDays + 1;
            else endDay = numDays;

            for (Int32 i = endDay; i < 42; i++)
            {
                if (rowNo > 6) break;

                String disabledDay = toFarsi.Convert((i - endDay + 1).ToString(), Thread.CurrentThread.CurrentCulture);
                g.DrawString(disabledDay, Font, brush, rcDay, OneLineNoTrimming);

                if (IsRightToLeftCulture)
                {
                    rcDay.X = rcDay.X - iColWidth;

                    if (rcDay.X < 0)
                    {
                        rowNo++;
                        rcDay.X = rcHead.X;
                        rcDay.Y = rcDay.Y + iRowHeight + DEF_ROWS_MARGIN;
                    }
                }
                else
                {
                    rcDay.X = rcDay.X + iColWidth;

                    if (rcDay.X > rc.Width - rcDay.Width)
                    {
                        rowNo++;
                        rcDay.X = rc.X;
                        rcDay.Y = rcDay.Y + iRowHeight + DEF_ROWS_MARGIN;
                    }
                }
            }

            #endregion
        }
        #endregion

        #region protected override void OnResize(EventArgs e)
        protected override void OnResize(EventArgs e)
        {
            if (Width < 166)
                Width = 166;

            if (Height < 166)
                Height = 166;

            _RectsCreated = false;
            Invalidate();
        }
        #endregion

        #region private void AddActiveRect(Rectangle rc, TRectangleAction action, object tag)
        private void AddActiveRect(Rectangle rc, TRectangleAction action, object tag)
        {
            if (_RectsCreated == false)
                _RectsList.Add(new ActRect(rc, action, tag));
        }
        #endregion

        #region private void AddActiveRect(Rectangle rc, TRectangleAction action)
        private void AddActiveRect(Rectangle rc, TRectangleAction action)
        {
            if (_RectsCreated == false)
                _RectsList.Add(new ActRect(rc, action));
        }
        #endregion

        #endregion

        #region Methods

        #region private Int32 GetFirstDayOfWeek(DateTime date)
        private static Int32 GetFirstDayOfWeek(DateTime date)
        {
            if (Thread.CurrentThread.CurrentCulture.Equals(PersianLocalizeManager.FarsiCulture))
            {
                PersianDate pd = date;
                return (Int32)pd.DayOfWeek;
            }
            if (Thread.CurrentThread.CurrentCulture.Equals(PersianLocalizeManager.ArabicCulture))
                return (Int32)date.DayOfWeek;
            return (Int32)date.DayOfWeek;
        }
        #endregion

        #region internal void OnRecalculateRequired()
        internal void OnRecalculateRequired()
        {
            ResetAllRectangleStates();

            if (_RectsCreated)
                _RectsCreated = false;

            ActRect rect = FindActiveRectByTag(_iDay);
            if (_iLastFocused < DEF_TODAY_TAB_INDEX)
                _iLastFocused = _iDay.Value;

            if (rect != null)
                rect.State |= TRectangleStatus.FocusSelect;
        }
        #endregion

        #region public void ScrollDaysLeft()
        /// <summary>
        /// Scrolls days in the view to the Left.
        /// </summary>
        public void ScrollDaysLeft()
        {
            if (_iLastFocused < DEF_TODAY_TAB_INDEX)
                SelectedDateTime = DefaultCalendar.AddDays(SelectedDateTime.Value, -1);
        }
        #endregion

        #region public void ScrollDaysRight()
        /// <summary>
        /// Scrolls days in the view to the Right.
        /// </summary>
        public void ScrollDaysRight()
        {
            if (_iLastFocused < DEF_TODAY_TAB_INDEX)
                SelectedDateTime = DefaultCalendar.AddDays(SelectedDateTime.Value, 1);
        }
        #endregion

        #region public void ScrollDaysUp()
        /// <summary>
        /// Scrolls days in the view to the Up.
        /// </summary>
        public void ScrollDaysUp()
        {
            if (_iLastFocused < DEF_TODAY_TAB_INDEX)
                SelectedDateTime = DefaultCalendar.AddDays(SelectedDateTime.Value, -7);
        }
        #endregion

        #region public void ScrollDaysDown()
        /// <summary>
        /// Scrolls days in the view to the Down.
        /// </summary>
        public void ScrollDaysDown()
        {
            if (_iLastFocused < DEF_TODAY_TAB_INDEX)
                SelectedDateTime = DefaultCalendar.AddDays(SelectedDateTime.Value, 7);
        }
        #endregion

        #region internal void SetFocusOnNextControl()
        internal void SetFocusOnNextControl()
        {
            ResetFocusedRectangleState();

            if (_iLastFocused < DEF_TODAY_TAB_INDEX)
            {
                _iLastFocused = DEF_TODAY_TAB_INDEX;
            }
            else if (_iLastFocused == DEF_TODAY_TAB_INDEX)
            {
                _iLastFocused = DEF_NONE_TAB_INDEX;
            }
            else
            {
                // ReSharper disable PossibleNullReferenceException
                Control ctrl = FindForm().GetNextControl(this, true);
                // ReSharper restore PossibleNullReferenceException
                if (ctrl != null) ctrl.Focus();
            }
        }

        #endregion

        #region internal void SetFocusOnPrevControl()
        internal void SetFocusOnPrevControl()
        {
            ResetFocusedRectangleState();

            if (_iLastFocused < DEF_TODAY_TAB_INDEX)
            {
                _iLastFocused = DEF_NONE_TAB_INDEX;
            }
            else if (_iLastFocused == DEF_TODAY_TAB_INDEX && _iDay != 0)
            {
                _iLastFocused = _iDay.Value;

                ActRect rc = FindActiveRectByTag(_iDay);
                if (rc != null)
                {
                    rc.State |= TRectangleStatus.Focused | TRectangleStatus.Selected;
                }
            }
            else if (_iLastFocused == DEF_NONE_TAB_INDEX)
            {
                _iLastFocused = DEF_TODAY_TAB_INDEX;
            }
            else
            {
                // ReSharper disable PossibleNullReferenceException
                Control ctrl = FindForm().GetNextControl(this, false);
                // ReSharper restore PossibleNullReferenceException
                if (ctrl != null) ctrl.Focus();
            }
        }
        #endregion

        #region public void ToNextYear()
        /// <summary>
        /// Changes the Year value to the Next Year.
        /// </summary>
        public void ToNextYear()
        {
            try
            {
                if (SelectedDateTime == null) _SelectedGregorianDate = DateTime.Now;
                SelectedDateTime = DefaultCalendar.AddYears(SelectedDateTime.Value, 1);
                OnRecalculateRequired();
            }
            catch (ArgumentOutOfRangeException) { }
        }
        #endregion

        #region public void ToPrevYear()
        /// <summary>
        /// Changes the Year value to the Previous Year.
        /// </summary>
        public void ToPrevYear()
        {
            try
            {
                if (SelectedDateTime == null) _SelectedGregorianDate = DateTime.Now;
                SelectedDateTime = DefaultCalendar.AddYears(SelectedDateTime.Value, -1);
                OnRecalculateRequired();
            }
            catch (ArgumentOutOfRangeException) { }
        }
        #endregion

        #region public void ToNextMonth()
        /// <summary>
        /// Changes the Month value to the Next Month.
        /// </summary>
        public void ToNextMonth()
        {
            try
            {
                if (SelectedDateTime == null) _SelectedGregorianDate = DateTime.Now;
                SelectedDateTime = DefaultCalendar.AddMonths(SelectedDateTime.Value, 1);
                OnRecalculateRequired();
            }
            catch (ArgumentOutOfRangeException) { }
        }
        #endregion

        #region public void ToPrevMonth()
        /// <summary>
        /// Changes the Month value to the Previous Month.
        /// </summary>
        public void ToPrevMonth()
        {
            try
            {
                if (SelectedDateTime == null) _SelectedGregorianDate = DateTime.Now;
                SelectedDateTime = DefaultCalendar.AddMonths(SelectedDateTime.Value, -1);
                OnRecalculateRequired();
            }
            catch (ArgumentOutOfRangeException) { }
        }
        #endregion

        #region private Calendar GetCurrentCalendar()
        private Calendar GetCurrentCalendar()
        {
            if (ControlCulture == CultureName.Persian) return _PerCal;
            if (ControlCulture == CultureName.English) return _GCal;
            if (_CustomCalendar != null) return _CustomCalendar;
            return _HijCal;
        }
        #endregion

        #region public String GetAbbrDayName(Int32 day)
        /// <summary>
        /// Gets the abbreviated name of the specified day.
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        public String GetAbbrDayName(Int32 day)
        {
            if (PersianLocalizeManager.CustomCulture != null)
            {
                if (PersianLocalizeManager.CustomCulture.Equals(PersianLocalizeManager.FarsiCulture))
                {
                    return PersianDate.PersianWeekDayAbbr.Default[day];
                }
                return PersianLocalizeManager.CustomCulture.DateTimeFormat.ShortestDayNames[day].ToUpper();
            }

            if (Thread.CurrentThread.CurrentCulture.Equals(PersianLocalizeManager.FarsiCulture))
                return PersianDate.PersianWeekDayAbbr.Default[day];
            if (Thread.CurrentThread.CurrentCulture.Equals(PersianLocalizeManager.ArabicCulture))
                return PersianLocalizeManager.ArabicCulture.DateTimeFormat.
                    AbbreviatedDayNames[day].Substring(2, 1);
            return PersianLocalizeManager.InvariantCulture.DateTimeFormat.
                AbbreviatedDayNames[day].Substring(0, 1);
        }
        #endregion

        #region public void SetNoneDay()
        /// <summary>
        /// Clears the selection of the control. Also clears any selected date in MultiSelect mode. 
        /// </summary>
        public void SetNoneDay()
        {
            if (!_IsAllowNullDate) return;
            _SelectedGregorianDate = null;
            OnSelectedDateTimeChanged(EventArgs.Empty);
        }
        #endregion

        #region public void SetTodayDay()
        /// <summary>
        /// Sets the selection value to Today.
        /// </summary>
        public void SetTodayDay()
        {
            SelectedDateTime = DateTime.Now;
            OnSelectedDateTimeChanged(EventArgs.Empty);
        }
        #endregion

        #region private void RecalculateSelectionUp()
        private void RecalculateSelectionUp()
        {
            SelectedDateTime = _SelectedGregorianDate.Value.AddDays(-7);

            if (SelectedDateTime.Value.Month != _SelectedGregorianDate.Value.Month)
            {
                ScrollDaysUp();
            }
            else
            {
                ResetFocusedRectangleState();
            }
        }
        #endregion

        #region private void RecalculateSelectionDown()
        private void RecalculateSelectionDown()
        {
            SelectedDateTime = _SelectedGregorianDate.Value.AddDays(7);

            if (SelectedDateTime.Value.Month != _SelectedGregorianDate.Value.Month) // switch to another month
                ScrollDaysDown();
            else
                ResetFocusedRectangleState();
        }
        #endregion

        #region private void RecalculateSelectionLeft()
        private void RecalculateSelectionLeft()
        {
            SelectedDateTime = _SelectedGregorianDate.Value.AddDays(-1);
            if (SelectedDateTime.Value.Month != _SelectedGregorianDate.Value.Month) // switch to another month
                ScrollDaysLeft();
            else ResetFocusedRectangleState();
        }
        #endregion

        #region private void RecalculateSelectionRight()
        private void RecalculateSelectionRight()
        {
            SelectedDateTime = _SelectedGregorianDate.Value.AddDays(1);

            if (SelectedDateTime.Value.Month != _SelectedGregorianDate.Value.Month) // switch to another month
            {
                ScrollDaysRight();
            }
            else
            {
                ResetFocusedRectangleState();
            }
        }
        #endregion

        #region private void OnRectangleClick(ActRect rc)
        private void OnRectangleClick(ActRect rc)
        {
            switch (rc.Action)
            {
                case TRectangleAction.MonthDown: ToPrevMonth(); break;
                case TRectangleAction.MonthUp: ToNextMonth(); break;
                case TRectangleAction.YearDown: ToPrevYear(); break;
                case TRectangleAction.YearUp: ToNextYear(); break;
                case TRectangleAction.TodayBtn:
                    _iLastFocused = DEF_TODAY_TAB_INDEX;
                    SetTodayDay();
                    OnButtonClicked(new CalendarButtonClickedEventArgs(FAMonthViewButtons.Today));
                    break;
                case TRectangleAction.NoneBtn:
                    _iLastFocused = DEF_NONE_TAB_INDEX;
                    SetNoneDay();
                    OnButtonClicked(new CalendarButtonClickedEventArgs(FAMonthViewButtons.None));
                    break;
                case TRectangleAction.MonthDay:
                    if (_iDay == 0) return;
                    Int32 index = (Int32)rc.Tag;
                    _iLastFocused = index;
                    SelectedDateTime = new DateTime(_iYear.Value, _iMonth.Value, index, 0, 0, 0, DefaultCalendar);
                    OnButtonClicked(new CalendarButtonClickedEventArgs(FAMonthViewButtons.MonthDay));
                    break;
            }
            Invalidate();
        }
        #endregion

        #region private void OnSelectionClick(ActRect rc)
        private void OnSelectionClick(ActRect rc)
        {
            if (rc.Action == TRectangleAction.MonthDay)
            {
                if (rc.IsSelected == false)
                {
                    rc.State |= TRectangleStatus.Selected;

                    SelectedDateTime = new DateTime(_iYear.Value, _iMonth.Value, (Int32)rc.Tag, 0, 0, 0,
                                                    DefaultCalendar);
                    if (_SelectedGregorianDate != null)
                    {
                        if (!_SelectedRects.Contains(rc.Tag)) _SelectedRects.Add(rc.Tag);
                    }
                }
                else
                {
                    rc.State = (TRectangleStatus)((Int32)rc.State & ~(Int32)TRectangleStatus.Selected);
                    _SelectedRects.Remove(rc.Tag);
                }

                _iLastFocused = (Int32)rc.Tag;
                _IsAllowNullDate = false;
            }

            Invalidate();
        }

        #endregion

        #region private void OnEnterPressed()
        private void OnEnterPressed()
        {
            ResetSelectedRectangleState();

            ActRect rect = FindActiveRectByTag(_iLastFocused);

            if (rect != null)
            {
                switch (rect.Action)
                {
                    case TRectangleAction.TodayBtn:
                        SetTodayDay();
                        break;

                    case TRectangleAction.NoneBtn:
                        SetNoneDay();
                        break;
                }
            }
        }

        #endregion

        #endregion

        #region Event Handlers

        #region Custom Event Handlers
        protected internal virtual void OnButtonClicked(CalendarButtonClickedEventArgs e)
        {
            if (ButtonClicked != null)
                ButtonClicked(this, e);
        }

        protected internal virtual void OnMonthChanged(EventArgs e)
        {
            if (MonthChanged != null)
                MonthChanged(this, e);
        }

        protected internal virtual void OnYearChanged(EventArgs e)
        {
            if (YearChanged != null)
                YearChanged(this, e);
        }

        protected internal virtual void OnDayChanged(EventArgs e)
        {
            if (DayChanged != null)
                DayChanged(this, e);
        }

        protected internal virtual void OnSelectedDateTimeChanged(EventArgs e)
        {
            if (SelectedDateTimeChanged != null)
                SelectedDateTimeChanged(this, e);
        }

        protected internal virtual void OnDrawCurrentDay(CustomDrawDayEventArgs e)
        {
            if (DrawCurrentDay != null)
                DrawCurrentDay(this, e);
        }

        #endregion

        #region Mouse Event Handlers

        #region OnMouseEnter
        protected override void OnMouseEnter(EventArgs e)
        {
            Point pnt = MousePosition;
            pnt = PointToClient(pnt);
            ResetActiveRectanglesState();
            ActRect rect = FindActiveRectByPoint(pnt);

            if (rect != null && rect.Action != TRectangleAction.WeekDay)
                rect.State |= TRectangleStatus.Active;

            if (rect != null && rect.Action == TRectangleAction.TodayBtn)
                _IsTodayButtonFocused = true;
            else _IsTodayButtonFocused = false;

            if (rect != null && rect.Action == TRectangleAction.NoneBtn)
                _IsNoneButtonFocused = true;
            else _IsNoneButtonFocused = false;
            Invalidate();
        }
        #endregion

        #region OnMouseLeave
        protected override void OnMouseLeave(EventArgs e)
        {
            ResetActiveRectanglesState();
            Point pnt = MousePosition;
            pnt = PointToClient(pnt);
            ResetActiveRectanglesState();
            ActRect rect = FindActiveRectByPoint(pnt);

            if (rect != null && rect.Action != TRectangleAction.WeekDay)
                rect.State |= TRectangleStatus.Active;

            if (rect != null && rect.Action == TRectangleAction.TodayBtn)
                _IsTodayButtonFocused = true;
            else _IsTodayButtonFocused = false;

            if (rect != null && rect.Action == TRectangleAction.NoneBtn)
                _IsNoneButtonFocused = true;
            else _IsNoneButtonFocused = false;
            Invalidate();
        }
        #endregion

        #region OnMouseWheel
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (e.Delta >= 0)
            {
                switch (ScrollOption)
                {
                    case ScrollOptionTypes.Day: ScrollDaysLeft(); break;
                    case ScrollOptionTypes.Month: ToNextMonth(); break;
                    case ScrollOptionTypes.Year: ToNextYear(); break;
                }
            }
            else
            {
                switch (ScrollOption)
                {
                    case ScrollOptionTypes.Day: ScrollDaysRight(); break;
                    case ScrollOptionTypes.Month: ToPrevMonth(); break;
                    case ScrollOptionTypes.Year: ToPrevYear(); break;
                }
            }
        }
        #endregion

        #region OnMouseMove
        protected override void OnMouseMove(MouseEventArgs e)
        {
            Point pnt = MousePosition;
            pnt = PointToClient(pnt);
            ResetActiveRectanglesState();
            ActRect rect = FindActiveRectByPoint(pnt);

            if (rect != null && rect.Action != TRectangleAction.WeekDay)
                rect.State |= TRectangleStatus.Active;

            if (rect != null && rect.Action == TRectangleAction.TodayBtn)
                _IsTodayButtonFocused = true;
            else _IsTodayButtonFocused = false;

            if (rect != null && rect.Action == TRectangleAction.NoneBtn)
                _IsNoneButtonFocused = true;
            else _IsNoneButtonFocused = false;
            Invalidate();
        }
        #endregion

        #region OnInternalLocalizeChanged
        private void OnInternalLocalizeChanged(object sender, EventArgs e)
        {
            OnRecalculateRequired();
            Repaint();
        }
        #endregion

        #region OnInternalMouseDown
        internal void OnInternalMouseDown()
        {
            OnRecalculateRequired();
            Point pnt = MousePosition;
            pnt = PointToClient(pnt);
            ActRect rect = FindActiveRectByPoint(pnt);

            if (rect != null && rect.Action != TRectangleAction.WeekDay)
            {
                if (_iLastFocused == DEF_NONE_TAB_INDEX)
                {
                    rect.State |= TRectangleStatus.Pressed;
                }
                if (_iLastFocused == DEF_TODAY_TAB_INDEX)
                {
                    rect.State |= TRectangleStatus.Pressed;
                }
            }
        }
        #endregion

        #region OnInternalMouseClick
        internal void OnInternalMouseClick(Point location)
        {
            if (!IsPopupMode) Focus();
            ActRect rect = FindActiveRectByPoint(location);

            if (rect != null && rect.Action != TRectangleAction.WeekDay)
            {
                ResetActiveRectanglesState();
                ResetFocusedRectangleState();

                // if selection begin
                if ((ModifierKeys & (Keys.Control | Keys.Shift)) == 0)
                {
                    _SelectedRects.Clear();
                    ResetSelectedRectangleState();
                    OnRectangleClick(rect);
                }
                else
                {
                    if (!_SelectedRects.Contains(rect)) _SelectedRects.Add(rect);
                    OnSelectionClick(rect);
                }
            }
        }
        #endregion

        #region OnMouseDown
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) OnInternalMouseDown();
            base.OnMouseDown(e);
        }
        #endregion

        #region OnMouseClick
        protected override void OnMouseClick(MouseEventArgs e)
        {
            OnInternalMouseClick(e.Location);
            base.OnMouseClick(e);
        }
        #endregion

        #region OnDoubleClick
        protected override void OnDoubleClick(EventArgs e)
        {
            Point pnt = MousePosition;
            pnt = PointToClient(pnt);
            ActRect rect = FindActiveRectByPoint(pnt);
            if (rect != null && rect.Action != TRectangleAction.WeekDay)
            {
                ResetActiveRectanglesState();
                ResetSelectedRectangleState();
                ResetFocusedRectangleState();
                OnRectangleClick(rect);
            }
            base.OnDoubleClick(e);
        }
        #endregion

        #endregion

        #region Keyboard And Focus Event Handlers

        #region OnGotFocus
        protected override void OnGotFocus(EventArgs e)
        {
            Invalidate();
        }
        #endregion

        #region OnLostFocus
        protected override void OnLostFocus(EventArgs e)
        {
            ResetFocusedRectangleState();
            Invalidate();
        }
        #endregion

        #region OnKeyDown
        protected override void OnKeyDown(KeyEventArgs e)
        {
            switch (e.Modifiers & (Keys.Alt | Keys.Control | Keys.Shift))
            {
                //Only Shift key is pressed
                case Keys.Shift:
                    switch (e.KeyCode)
                    {
                        case Keys.Tab: SetFocusOnPrevControl(); break;
                        case Keys.Down: RecalculateSelectionDown(); break;
                        case Keys.Up: RecalculateSelectionUp(); break;
                        case Keys.Left: RecalculateSelectionLeft(); break;
                        case Keys.Right: RecalculateSelectionRight(); break;
                    } break;

                //Only Alt key is pressed
                case Keys.Alt:
                    switch (e.KeyCode)
                    {
                        case Keys.Left: ToPrevMonth(); break;
                        case Keys.Right: ToNextMonth(); break;
                        case Keys.N: SetNoneDay(); break;
                        case Keys.T: SetTodayDay(); break;
                    }
                    break;

                //Only Control key is pressed
                case Keys.Control:
                    switch (e.KeyCode)
                    {
                        case Keys.Up: ToNextYear(); break;
                        case Keys.Down: ToPrevYear(); break;
                    }
                    break;

                default:
                    switch (e.KeyCode)
                    {
                        case Keys.Down:
                            if (_iLastFocused == DEF_TODAY_TAB_INDEX || _iLastFocused == DEF_NONE_TAB_INDEX)
                                SetFocusOnNextControl();
                            else ScrollDaysDown();
                            break;
                        case Keys.Up:
                            if (_iLastFocused == DEF_TODAY_TAB_INDEX || _iLastFocused == DEF_NONE_TAB_INDEX)
                                SetFocusOnPrevControl();
                            else ScrollDaysUp();
                            break;
                        case Keys.Left:
                            if (_iLastFocused == DEF_TODAY_TAB_INDEX || _iLastFocused == DEF_NONE_TAB_INDEX)
                                SetFocusOnPrevControl();
                            else ScrollDaysLeft();
                            break;
                        case Keys.Right:
                            if (_iLastFocused == DEF_TODAY_TAB_INDEX || _iLastFocused == DEF_NONE_TAB_INDEX)
                                SetFocusOnNextControl();
                            else ScrollDaysRight();
                            break;
                        case Keys.Tab:
                            SetFocusOnNextControl();
                            break;

                        case Keys.Space:
                        case Keys.Enter: OnEnterPressed(); break;
                    }
                    break;
            }

            base.OnKeyDown(e);
            Invalidate();
        }
        #endregion

        #endregion

        #endregion

        #region --- Designer Methods ---

        /// <summary>
        /// Determines to serialize Size property or not.
        /// </summary>
        /// <returns></returns>
        public Boolean ShouldSerializeSize()
        {
            return false;
        }

        /// <summary>
        /// Determines to serialize SelectedDateTime property or not.
        /// </summary>
        /// <returns></returns>
        public Boolean ShouldSerializeSelectedDateTime()
        {
            return !SelectedDateTime.Equals(DateTime.MinValue);
        }

        /// <summary>
        /// Determines to serialize DefaultCalendar property or not.
        /// </summary>
        /// <returns></returns>
        public Boolean ShouldSerializeDefaultCalendar()
        {
            return false;
        }

        /// <summary>
        /// Determines to serialize DefaultCulture property or not.
        /// </summary>
        /// <returns></returns>
        public Boolean ShouldSerializeDefaultCulture()
        {
            return false;
        }

        #region public Int32 HitTest(Point location)
        /// <summary>
        /// Returns index of the ActRect control on click, if the HitTest is true. Returns -1 if hitting was not successfull.
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public Int32 HitTest(Point location)
        {
            ActRect rect = FindActiveRectByPoint(location);
            if (rect != null)
                return (Int32)rect.Tag;
            return -1;
        }
        #endregion

        #endregion

        #region --- Helper Methods ---

        private ActRect FindActiveRectByPoint(Point pnt)
        {
            foreach (ActRect rc in _RectsList)
            {
                if (rc.Rect.Contains(pnt))
                    return rc;
            }

            return null;
        }

        private ActRect FindActiveRectByTag(object tag)
        {
            foreach (ActRect rect in _RectsList)
            {
                if (rect.Tag != null && rect.Tag.Equals(tag))
                    return rect;
            }

            return null;
        }

        private void ResetActiveRectanglesState()
        {
            foreach (ActRect rc in _RectsList)
            {
                if ((rc.State & TRectangleStatus.Active) > 0)
                {
                    rc.State = (TRectangleStatus)((Int32)rc.State & ~(Int32)TRectangleStatus.Active);
                }
            }
        }

        private void ResetSelectedRectangleState()
        {
            foreach (ActRect rc in _RectsList)
            {
                if ((rc.State & TRectangleStatus.Selected) > 0)
                {
                    rc.State = (TRectangleStatus)((Int32)rc.State & ~(Int32)TRectangleStatus.Selected);
                }
            }
        }

        private void ResetFocusedRectangleState()
        {
            foreach (ActRect rc in _RectsList)
            {
                if ((rc.State & TRectangleStatus.Focused) > 0)
                {
                    rc.State = (TRectangleStatus)((Int32)rc.State & ~(Int32)TRectangleStatus.Focused);
                }
            }
        }

        private void ResetAllRectangleStates()
        {
            foreach (ActRect rc in _RectsList)
            {
                rc.State = TRectangleStatus.Normal;
            }
        }

        #endregion

        #region @@@ internal class ActRect @@@
        internal class ActRect
        {
            #region Fields
            private Boolean _IsInvalidate = true;
            private TRectangleStatus _State = TRectangleStatus.Normal;
            #endregion

            #region Ctors
            public ActRect(Rectangle rc, TRectangleStatus state,
                           TRectangleAction act, Boolean invalidate)
            {
                Rect = rc;
                _State = state;
                _IsInvalidate = invalidate;
                Action = act;
            }

            public ActRect(Rectangle rc, TRectangleStatus state, TRectangleAction act)
                : this(rc, state, act, true)
            {
            }

            public ActRect(Rectangle rc, TRectangleAction act, object tag)
            {
                Rect = rc;
                _State = TRectangleStatus.Normal;
                Action = act;
                Tag = tag;
            }

            public ActRect(Rectangle rc, TRectangleAction act)
                : this(rc, TRectangleStatus.Normal, act, true)
            {
            }

            public ActRect(Rectangle rc, TRectangleStatus state)
                : this(rc, state, TRectangleAction.None, true)
            {
            }

            public ActRect(Rectangle rc)
                : this(rc, TRectangleStatus.Normal, TRectangleAction.None, true)
            {
            }

            public ActRect()
                : this(Rectangle.Empty, TRectangleStatus.Normal, TRectangleAction.None, true)
            {
            }
            #endregion

            #region Properties

            public Rectangle Rect { get; set; }

            public TRectangleStatus State
            {
                get { return _State; }
                // ReSharper disable ValueParameterNotUsed
                set { _State = TRectangleStatus.Normal; }
                // ReSharper restore ValueParameterNotUsed
            }

            public Boolean InvalidateOnChange
            {
                get { return _IsInvalidate; }
                set { _IsInvalidate = value; }
            }

            public TRectangleAction Action { get; set; }

            public object Tag { get; set; }

            public Boolean IsFocused
            {
                get
                {
                    return (_State & TRectangleStatus.Focused) ==
                           TRectangleStatus.Focused;
                }
            }

            public Boolean IsSelected
            {
                get
                {
                    return (_State & TRectangleStatus.Selected) ==
                           TRectangleStatus.Selected;
                }
            }

            public Boolean IsActive
            {
                get { return (_State & TRectangleStatus.Active) == TRectangleStatus.Active; }
            }

            #endregion
        }
        #endregion
    }
}