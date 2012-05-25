#region using

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Negar.PersianCalendar.UI.PersianPopup;

#endregion

namespace Negar.PersianCalendar.UI
{

    #region Delegates

    internal delegate Int32 Hook(Int32 ncode, IntPtr wParam, IntPtr lParam);

    public delegate void CalendarButtonClickedEventHandler(object sender, CalendarButtonClickedEventArgs e);

    public delegate void BindPopupControlEventHandler(object sender, BindPopupControlEventArgs e);

    public delegate void ValueValidatingEventHandler(object sender, ValueValidatingEventArgs e);

    public delegate void SelectedDateTimeChangingEventHandler(object sender, SelectedDateTimeChangingEventArgs e);

    public delegate void ControlChangedEventHandler(object sender, EventArgs e);

    public delegate void CloseDropDownEventHandler(object sender, CloseDropDownEventArgs e);

    public delegate void PopupClosedEventHandler(object sender, PopupClosedEventArgs e);

    public delegate void PopupCancelEventHandler(object sender, PopupCancelEventArgs e);

    public delegate void CustomDrawDayEventHandler(object sender, CustomDrawDayEventArgs e);

    #endregion

    #region public class BindPopupControlEventArgs : EventArgs

    /// <summary>
    /// 
    /// </summary>
    public class BindPopupControlEventArgs : EventArgs
    {
        #region Class members

        private readonly Control parent;

        #endregion

        #region Props

        public IPopupControl BindedControl { get; set; }

        public Control OwnerControl
        {
            get { return parent; }
        }

        #endregion

        #region Ctor

        public BindPopupControlEventArgs(Control owner)
        {
            parent = owner;
        }

        #endregion
    }

    #endregion

    #region public class CloseDropDownEventArgs : EventArgs

    /// <summary>
    /// 
    /// </summary>
    public class CloseDropDownEventArgs : EventArgs
    {
        #region Fields

        private readonly Keys _keyCode;

        #endregion

        #region Properties

        public Boolean Close { get; set; }

        public Keys KeyCode
        {
            get { return _keyCode; }
        }

        #endregion

        #region Ctor

        public CloseDropDownEventArgs(Boolean close)
        {
            Close = close;
        }

        public CloseDropDownEventArgs(Boolean close, Keys keycode)
        {
            Close = close;
            _keyCode = keycode;
        }

        #endregion
    }

    #endregion

    #region public class PopupClosedEventArgs : EventArgs

    /// <summary>
    /// Contains event information events.
    /// </summary>
    public class PopupClosedEventArgs : EventArgs
    {
        /// <summary>
        /// The popup form.
        /// </summary>
        private readonly Form popup;

        /// <summary>
        /// Constructs a new instance of this class for the specified
        /// popup form.
        /// </summary>
        /// <param name="popup">Popup Form which is being closed.</param>
        public PopupClosedEventArgs(Form popup)
        {
            this.popup = popup;
        }

        /// <summary>
        /// Gets the popup form which is being closed.
        /// </summary>
        public Form Popup
        {
            get { return popup; }
        }
    }

    #endregion

    #region public class PopupCancelEventArgs : EventArgs

    /// <summary>
    /// Provides a reference to the popup form that is to be closed and 
    /// allows the operation to be cancelled.
    /// </summary>
    public class PopupCancelEventArgs : EventArgs
    {
        /// <summary>
        /// Mouse down location
        /// </summary>
        private readonly Point location;

        /// <summary>
        /// Popup form.
        /// </summary>
        private readonly Form popup;

        /// <summary>
        /// Constructs a new instance of this class.
        /// </summary>
        /// <param name="popupForm">The popup form</param>
        /// <param name="pt">The mouse location, if any, where the
        /// mouse event that would cancel the popup occured.</param>
        public PopupCancelEventArgs(Form popupForm, Point pt)
        {
            popup = popupForm;
            location = pt;
            Cancel = false;
        }

        /// <summary>
        /// Gets the popup form
        /// </summary>
        public Form Popup
        {
            get { return popup; }
        }

        /// <summary>
        /// Gets the location that the mouse down which would cancel this 
        /// popup occurred
        /// </summary>
        public Point CursorLocation
        {
            get { return location; }
        }

        /// <summary>
        /// Gets/sets whether to cancel closing the form. Set to
        /// <c>true</c> to prevent the popup from being closed.
        /// </summary>
        public Boolean Cancel { get; set; }
    }

    #endregion

    #region public class SelectedDateRangeChangedEventArgs : EventArgs

    /// <summary>
    /// FarsiCalendarEvents fired by calendar controls when the currently selected Date changes.
    /// </summary>
    public class SelectedDateRangeChangedEventArgs : EventArgs
    {
        #region Fields

        private readonly List<DateTime> selectedDates;

        #endregion

        #region Ctor

        /// <summary>
        /// Delegate fire when currentItem Date changes in the control.
        /// </summary>
        /// <param name="SelectedDates"></param>
        public SelectedDateRangeChangedEventArgs(List<DateTime> SelectedDates)
        {
            selectedDates = SelectedDates;
        }

        #endregion

        #region Props

        /// <summary>
        /// Currently selected Date in the control.
        /// </summary>
        public List<DateTime> SelectedDateRange
        {
            get { return selectedDates; }
        }

        #endregion
    }

    #endregion

    #region public class SelectedDateTimeChangingEventArgs : EventArgs

    /// <summary>
    /// 
    /// </summary>
    public class SelectedDateTimeChangingEventArgs : EventArgs
    {
        #region Fields

        /// <summary>
        /// 
        /// </summary>
        private readonly DateTime? _OldValue;

        #endregion

        #region Properties

        #region String Message

        /// <summary>
        /// 
        /// </summary>
        public String Message { get; set; }

        #endregion

        #region DateTime NewValue

        /// <summary>
        /// 
        /// </summary>
        public DateTime? NewValue { get; set; }

        #endregion

        #region DateTime? OldValue

        public DateTime? OldValue
        {
            get { return _OldValue; }
        }

        #endregion

        #region Boolean Cancel

        /// <summary>
        /// 
        /// </summary>
        public Boolean Cancel { get; set; }

        #endregion

        #endregion

        #region Methods

        #region public SelectedDateTimeChangingEventArgs(DateTime OldValue, DateTime NewValue)

        public SelectedDateTimeChangingEventArgs(DateTime? OldValue, DateTime? NewValue)
        {
            _OldValue = OldValue;
            this.NewValue = NewValue;
            Cancel = false;
            Message = String.Empty;
        }

        #endregion

        #endregion
    }

    #endregion

    #region public class ValueValidatingEventArgs : EventArgs

    public class ValueValidatingEventArgs : EventArgs
    {
        private readonly object value;

        public ValueValidatingEventArgs(object Value)
        {
            value = Value;
        }

        public Boolean HasError { get; set; }

        public object Value
        {
            get { return value; }
        }
    }

    #endregion

    #region public class CustomDrawDayEventArgs : EventArgs

    public class CustomDrawDayEventArgs : EventArgs
    {
        private readonly Int32 dayNo;
        private readonly Graphics g;
        private readonly Boolean isToday;
        private readonly Int32 monthNo;
        private readonly Rectangle r;
        private readonly Int32 yearNo;

        public CustomDrawDayEventArgs(Rectangle rectangle, Graphics graphics, Int32 year, Int32 month, Int32 day,
                                      Boolean today)
        {
            dayNo = day;
            yearNo = year;
            monthNo = month;
            r = rectangle;
            g = graphics;
            isToday = today;
            Handled = false;
        }

        public Boolean Handled { get; set; }

        public Rectangle Rectangle
        {
            get { return r; }
        }

        public Graphics Graphics
        {
            get { return g; }
        }

        public Int32 Day
        {
            get { return dayNo; }
        }

        public Int32 Year
        {
            get { return yearNo; }
        }

        public Int32 Month
        {
            get { return monthNo; }
        }

        public Boolean IsToday
        {
            get { return isToday; }
        }
    }

    #endregion

    #region public class CalendarButtonClickedEventArgs : EventArgs

    /// <summary>
    /// 
    /// </summary>
    public class CalendarButtonClickedEventArgs : EventArgs
    {
        #region Fields

        private readonly FAMonthViewButtons button;

        #endregion

        #region Ctor

        public CalendarButtonClickedEventArgs(FAMonthViewButtons button)
        {
            this.button = button;
        }

        #endregion

        #region Props

        public FAMonthViewButtons Button
        {
            get { return button; }
        }

        #endregion
    }

    #endregion

    #region public class CollectionChangedEventArgs : EventArgs

    /// <summary>
    /// Specifies change type of the collection.
    /// </summary>
    public class CollectionChangedEventArgs : EventArgs
    {
        private readonly CollectionChangeType changeType = CollectionChangeType.Other;

        public CollectionChangedEventArgs(CollectionChangeType type)
        {
            changeType = type;
        }

        public CollectionChangeType ChangeType
        {
            get { return changeType; }
        }
    }

    #endregion
}