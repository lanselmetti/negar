#region using

using System;
using Negar.PersianCalendar.UI.Controls;

#endregion

namespace Negar.PersianCalendar.UI
{

    #region CultureName

    public enum CultureName
    {
        /// <summary>
        /// Persian Culture
        /// </summary>
        Persian,

        /// <summary>
        /// English Culture
        /// </summary>
        English
    }

    #endregion

    #region CollectionChangeType

    /// <summary>
    /// 
    /// </summary>
    public enum CollectionChangeType
    {
        Add,
        Remove,
        Clear,
        Other
    }

    #endregion

    #region MessageBeepType

    /// <summary>
    /// Beep Types of the system
    /// </summary>
    public enum MessageBeepType
    {
        Default = -1,
        Ok = 0,
        Error = 16,
        Question = 22,
        Warning = 48,
        Information = 64
    }

    #endregion

    #region FAMessageBoxButtons

    /// <summary>
    /// Standard MessageBoxEx buttons
    /// </summary>
    public enum FAMessageBoxButtons
    {
        /// <summary>
        /// Ok
        /// </summary>
        Ok = 0,

        /// <summary>
        /// Cancel
        /// </summary>
        Cancel = 1,

        /// <summary>
        /// Yes
        /// </summary>
        Yes = 2,

        /// <summary>
        /// No
        /// </summary>
        No = 4,

        /// <summary>
        /// Abort
        /// </summary>
        Abort = 8,

        /// <summary>
        /// Retry
        /// </summary>
        Retry = 16,

        /// <summary>
        /// Ignore
        /// </summary>
        Ignore = 32,
    }

    #endregion

    #region FarsiMessageBoxExIcon

    /// <summary>
    /// Standard MessageBoxEx icons
    /// </summary>
    public enum FarsiMessageBoxExIcon
    {
        /// <summary>
        /// No icon visible
        /// </summary>
        None,

        /// <summary>
        /// Astrisk icon
        /// </summary>
        Asterisk,

        /// <summary>
        /// Error icon
        /// </summary>
        Error,

        /// <summary>
        /// Exclamation icon
        /// </summary>
        Exclamation,

        /// <summary>
        /// Hand icon
        /// </summary>
        Hand,

        /// <summary>
        /// Information icon
        /// </summary>
        Information,

        /// <summary>
        /// Question icon
        /// </summary>
        Question,

        /// <summary>
        /// Stop icon
        /// </summary>
        Stop,

        /// <summary>
        /// Warning icon
        /// </summary>
        Warning
    }

    #endregion

    #region FAMonthViewButtons

    /// <summary>
    /// PersianMonthView buttons which will raise the button click event.
    /// </summary>
    public enum FAMonthViewButtons
    {
        /// <summary>
        /// None button of PersianMonthView control
        /// </summary>
        None,

        /// <summary>
        /// Today button of PersianMonthView control
        /// </summary>
        Today,

        /// <summary>
        /// Any normal day of PersianMonthView control
        /// </summary>
        MonthDay,
    }

    #endregion

    #region FormatInfoTypes

    /// <summary>
    /// Various Formatting Info for PersianDate to format its text values.
    /// </summary>
    public enum FormatInfoTypes
    {
        /// <summary>
        /// PersianDate instance in WrittenDate format equals calling ToString("d"). This is the default value
        /// when using ToString() overload.
        /// </summary>
        ShortDate,

        /// <summary>
        /// PersianDate instance in WrittenDate format equals calling ToString("g")
        /// </summary>
        DateShortTime,

        /// <summary>
        /// PersianDate instance in WrittenDate format equals calling ToString("G")
        /// </summary>
        FullDateTime
    }

    #endregion

    #region ScrollOptionTypes

    /// <summary>
    /// Decides which property to change when user scrolls mouse wheel over the <see cref="PersianMonthView"/> control.
    /// </summary>
    public enum ScrollOptionTypes
    {
        /// <summary>
        /// Scroll days in the PersianMonthView control.
        /// </summary>
        Day,

        /// <summary>
        /// Scroll months in the PersianMonthView control.
        /// </summary>
        Month,

        /// <summary>
        /// Scroll years in the PersianMonthView control.
        /// </summary>
        Year
    }

    #endregion

    #region TRectangleStatus

    /// <summary>
    /// Status of each ActRect instances in PersianMonthView controls.
    /// </summary>
    [Flags]
    internal enum TRectangleStatus
    {
        Normal = 0x0000,
        Active = 0x0001,
        Selected = 0x0002,
        Focused = 0x0004,
        Pressed = 0x0008,
        ActiveSelect = Active | Selected,
        FocusSelect = Focused | Selected,
        All = Active | Selected | Focused
    } ;

    #endregion

    #region TRectangleAction

    /// <summary>
    /// Action Type of the ActRect class.
    /// </summary>
    internal enum TRectangleAction
    {
        None,
        MonthDown,
        MonthUp,
        YearDown,
        YearUp,
        TodayBtn,
        NoneBtn,
        MonthDay,
        WeekDay
    } ;

    #endregion

    #region Office2007Color

    /// <summary>
    /// Office 2007 predefined colors.
    /// </summary>
    public enum Office2007Color
    {
        Border,
        Button1,
        Button2,
        Button1Hot,
        Button2Hot,
        Button1Pressed,
        Button2Pressed,
        ButtonDisabled,
        Text,
        TextDisabled,
        Header,
        Header2,
        GroupRow,
        TabPageForeColor,
        TabBackColor1,
        TabBackColor2,
        TabPageBackColor1,
        TabPageBackColor2,
        TabPageBorderColor,
        NavBarBackColor1,
        NavBarBackColor2,
        NavBarLinkTextColor,
        NavBarLinkHightlightedTextColor,
        NavBarLinkDisabledTextColor,
        NavBarGroupClientBackColor,
        NavBarGroupCaptionBackColor1,
        NavBarGroupCaptionBackColor2,
        NavBarExpandButtonRoundColor,
        NavPaneBorderColor,
        NavBarNavPaneHeaderBackColor,
        LinkBorder
    }

    #endregion

    #region XPThemeType

    /// <summary>
    /// Specifies Theme types of WindowsXP.
    /// </summary>
    public enum XPThemeType
    {
        Unknown,
        NormalColor,
        Homestead,
        Metallic
    }

    #endregion

    #region CalendarTypes

    /// <summary>
    /// نوع تقویم نمایش داده شده در كنترل كمبوی تبدیل تقویم
    /// </summary>
    public enum CalendarTypes
    {
        /// <summary>
        /// تقویم فارسی
        /// </summary>
        Persian,

        /// <summary>
        /// تقویم انگلیسی
        /// </summary>
        English
    }

    #endregion

    #region ItemState

    /// <summary>
    /// Specifies the state DrawTab command is in.
    /// </summary>
    public enum ItemState
    {
        /// <summary>
        /// Specifies the command is in default state.
        /// </summary>
        Normal,

        /// <summary>
        /// Specifies command is being hot tracked.
        /// </summary>
        HotTrack,

        /// <summary>
        /// Specifies command is user pressing it down.
        /// </summary>
        Pressed,

        /// <summary>
        /// Specifies command is has been opened.
        /// </summary>
        Open
    }

    #endregion

    #region TextAlignment

    public enum TextAlignment
    {
        /// <summary>
        /// Alignment based on system default settings.
        /// </summary>
        Default,

        /// <summary>
        /// Center alignment.
        /// </summary>
        Center,

        /// <summary>
        /// Near alignment, based on RTL settings.
        /// </summary>
        Near,

        /// <summary>
        /// Far alignment, based on RTL settings.
        /// </summary>
        Far
    }

    #endregion
}