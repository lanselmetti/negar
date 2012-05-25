#region using

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using Negar.PersianCalendar.Resource;
using Negar.PersianCalendar.Utilities.Exceptions;

#endregion

namespace Negar.PersianCalendar.Utilities
{
    /// <summary>
    /// كلاس ارائه تقویم جلالی
    /// <example>مثالی از نحوه فراخوانی كد
    /// <code>
    ///		class MyClass 
    ///     {
    ///		   public static void Main() 
    ///        {
    ///		      Console.WriteLine("Current Persian Date Is : " + PersianDate.Now.ToString());
    ///		   }
    ///		}
    /// </code>
    /// </example>
    /// <seealso cref="PersianDateConverter"/>
    /// </summary>
    [TypeConverter("Negar.PersianCalendar.UI.Design.PersianDateTypeConverter")]
    [Serializable]
    public sealed class PersianDate :
        IFormattable,
        ICloneable,
        IComparable,
        IComparable<PersianDate>,
        IComparer,
        IComparer<PersianDate>,
        IEquatable<PersianDate>
    {
        #region Fields

        #region Private Methods
        private static readonly String _AmDesignator = Thread.CurrentThread.CurrentCulture.DateTimeFormat.AMDesignator;
        private static readonly String _PmDesignator = Thread.CurrentThread.CurrentCulture.DateTimeFormat.PMDesignator;
        private static readonly PersianDate _CurrentPersianDate;
        private readonly PersianCalendar _PersianCalendar = new PersianCalendar();
        private readonly TimeSpan _Time;
        private Int32 _Day;
        private Int32 _Hour;
        private Int32 _Millisecond;
        private Int32 _Minute;
        private Int32 _Month;
        private Int32 _Second;
        private Int32 _Year;
        #endregion

        #region Public Methods

        [NonSerialized] public static PersianDate MaxValue;
        [NonSerialized] public static PersianDate MinValue;

        #endregion

        #endregion

        #region Constructors

        #region static PersianDate()
        /// <summary>
        /// سازنده استاتیك كلاس ، تنظیم كننده مقدار جاری تقویم فارسی و كران تقویم
        /// </summary>
        static PersianDate()
        {
            _CurrentPersianDate = PersianDateConverter.ToPersianDate(DateTime.Now);
            MinValue = new PersianDate(1, 1, 1, 12, 0, 0, 0); // 12:00:00.000 AM, 22/03/0622
            MaxValue = new PersianDate(DateTime.MaxValue);
        }
        #endregion

        #region public PersianDate()

        /// <summary>
        /// سازنده پیش فرض كلاس
        /// </summary>
        public PersianDate()
        {
            _Year = Now._Year;
            _Month = Now.Month;
            _Day = Now.Day;
            _Hour = Now.Hour;
            _Minute = Now.Minute;
            _Second = Now.Second;
            _Millisecond = Now.Millisecond;
            _Time = Now.Time;
        }

        #endregion

        #region public PersianDate(DateTime EnglishDateTime)

        /// <summary>
        /// 
        /// </summary>
        /// <param name="EnglishDateTime"></param>
        public PersianDate(DateTime EnglishDateTime)
        {
            Assign(PersianDateConverter.ToPersianDate(EnglishDateTime));
        }

        #endregion

        #region public PersianDate(String datetime, String format)

        /// <summary>
        /// Constructs a PersianDate instance with values provided in datetime String. 
        /// use the format you want to parse the String with. Currently it can be either g, G, or d value.
        /// </summary>
        /// <param name="datetime"></param>
        /// <param name="format"></param>
        public PersianDate(String datetime, String format)
        {
            Assign(Parse(datetime, format));
        }

        #endregion

        #region public PersianDate(String Date, TimeSpan time)

        /// <summary>
        /// Constructs a PersianDate instance with values provided in datetime String. You should
        /// include Date part only in <c>Date</c> and set the Time of the instance as a <c>TimeSpan</c>.
        /// </summary>
        /// <exception cref="InvalidPersianDateException"></exception>
        /// <param name="Date"></param>
        /// <param name="time"></param>
        public PersianDate(String Date, TimeSpan time)
        {
            PersianDate pd = Parse(Date);

            pd.Hour = time.Hours;
            pd.Minute = time.Minutes;
            pd.Second = time.Seconds;
            pd.Millisecond = time.Milliseconds;

            Assign(pd);
        }

        #endregion

        #region public PersianDate(String Date)

        /// <summary>
        /// Constructs a PersianDate instance with values provided as a String. The provided String should be in format 'yyyy/mm/dd'.
        /// </summary>
        /// <exception cref="InvalidPersianDateException"></exception>
        /// <param name="Date"></param>
        public PersianDate(String Date)
        {
            Assign(Parse(Date));
        }

        #endregion

        #region public PersianDate(Int32 year, Int32 month, Int32 day, Int32 hour, Int32 minute)

        /// <summary>
        /// Constructs a PersianDate instance with values specified as <c>Integer</c> 
        /// and default second and millisecond set to zero.
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        public PersianDate(Int32 year, Int32 month, Int32 day, Int32 hour, Int32 minute)
            : this(year, month, day, hour, minute, 0)
        {
        }

        #endregion

        #region public PersianDate(Int32 year, Int32 month, Int32 day, Int32 hour, Int32 minute, Int32 second)

        /// <summary>
        /// Constructs a PersianDate instance with values specified as <c>Integer</c> and default millisecond set to zero.
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="second"></param>
        public PersianDate(Int32 year, Int32 month, Int32 day, Int32 hour, Int32 minute, Int32 second)
            : this(year, month, day, hour, minute, second, 0)
        {
        }

        #endregion

        #region public PersianDate(Int32 year, Int32 month, Int32 day, Int32 hour, Int32 minute, Int32 second, Int32 millisecond)

        /// <summary>
        /// Constructs a PersianDate instance with values specified as <c>Integer</c>.
        /// </summary>
        /// <exception cref="InvalidPersianDateException"></exception>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="second"></param>
        /// <param name="millisecond"></param>
        public PersianDate(Int32 year, Int32 month, Int32 day, Int32 hour, Int32 minute, Int32 second, Int32 millisecond)
        {
            CheckYear(year);
            CheckMonth(month);
            CheckDay(year, month, day);
            CheckHour(hour);
            CheckMinute(minute);
            CheckSecond(second);
            CheckMillisecond(millisecond);

            _Year = year;
            _Month = month;
            _Day = day;
            _Hour = hour;
            _Minute = minute;
            _Second = second;
            _Millisecond = millisecond;

            _Time = new TimeSpan(0, hour, minute, second, millisecond);
        }

        #endregion

        #region public PersianDate(Int32 year, Int32 month, Int32 day)

        /// <summary>
        /// Constructs a PersianDate instance with values specified as <c>Integer</c>. 
        /// Time value of this instance is set to <c>DateTime.Now</c>.
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        public PersianDate(Int32 year, Int32 month, Int32 day)
        {
            CheckYear(year);
            CheckMonth(month);
            CheckDay(year, month, day);

            _Year = year;
            _Month = month;
            _Day = day;
            _Hour = DateTime.Now.Hour;
            _Minute = DateTime.Now.Minute;
            _Second = DateTime.Now.Second;
            _Millisecond = DateTime.Now.Millisecond;

            _Time = new TimeSpan(0, _Hour, _Minute, _Second, _Millisecond);
        }

        #endregion

        #endregion

        #region Properties

        #region public static String AMDesignator
        /// <summary>
        /// رشته تعیین كننده مقدار صبح
        /// </summary>
        public static String AMDesignator
        {
            get { return _AmDesignator; }
        }
        #endregion

        #region public static String PMDesignator
        /// <summary>
        /// رشته تعیین كننده مقدار عصر
        /// </summary>
        public static String PMDesignator
        {
            get { return _PmDesignator; }
        }
        #endregion

        #region public static PersianDate Now
        /// <summary>
        /// Current date/time in PersianDate format.
        /// </summary>
        [Browsable(false)]
        [Description("Current date/time in PersianDate format")]
        public static PersianDate Now
        {
            get { return _CurrentPersianDate; }
        }
        #endregion

        #region public Int32 Year

        /// <summary>
        /// Year value of PersianDate.
        /// </summary>
        [Description("Year value of PersianDate")]
        [NotifyParentProperty(true)]
        public Int32 Year
        {
            get { return _Year; }
            set
            {
                CheckYear(value);
                _Year = value;
            }
        }

        #endregion

        #region public Int32 Month

        /// <summary>
        /// Month value of PersianDate.
        /// </summary>
        [Description("Month value of PersianDate")]
        [NotifyParentProperty(true)]
        public Int32 Month
        {
            get { return _Month; }
            set
            {
                CheckMonth(value);
                _Month = value;
            }
        }

        #endregion

        #region public Int32 Day

        /// <summary>
        /// Day value of PersianDate.
        /// </summary>
        [Description("Day value of PersianDate")]
        [NotifyParentProperty(true)]
        public Int32 Day
        {
            get { return _Day; }
            set
            {
                CheckDay(Year, Month, value);
                _Day = value;
            }
        }

        #endregion

        #region public Int32 Hour

        /// <summary>
        /// Hour value of PersianDate.
        /// </summary>
        [Description("Hour value of PersianDate")]
        [NotifyParentProperty(true)]
        public Int32 Hour
        {
            get { return _Hour; }
            set
            {
                CheckHour(value);
                _Hour = value;
            }
        }

        #endregion

        #region public Int32 Minute

        /// <summary>
        /// Minute value of PersianDate.
        /// </summary>
        [Description("Minute value of PersianDate")]
        [NotifyParentProperty(true)]
        public Int32 Minute
        {
            get { return _Minute; }
            set
            {
                CheckMinute(value);
                _Minute = value;
            }
        }

        #endregion

        #region public Int32 Second

        /// <summary>
        /// Second value of PersianDate.
        /// </summary>
        [Description("Second value of PersianDate")]
        [NotifyParentProperty(true)]
        public Int32 Second
        {
            get { return _Second; }
            set
            {
                CheckSecond(value);
                _Second = value;
            }
        }

        #endregion

        #region public Int32 Millisecond

        /// <summary>
        /// Millisecond value of PersianDate.
        /// </summary>
        [Description("Millisecond value of PersianDate")]
        [NotifyParentProperty(true)]
        public Int32 Millisecond
        {
            get { return _Millisecond; }
            set
            {
                CheckMillisecond(value);
                _Millisecond = value;
            }
        }

        #endregion

        #region public TimeSpan Time

        /// <summary>
        /// Time value of PersianDate in TimeSpan format.
        /// </summary>
        [Browsable(false)]
        [Description("Time value of PersianDate in TimeSpan format.")]
        public TimeSpan Time
        {
            get { return _Time; }
        }

        #endregion

        #region public PersianDayOfWeek DayOfWeek
        /// <summary>
        /// Returns the DayOfWeek of the date instance
        /// </summary>
        public PersianDayOfWeek DayOfWeek
        {
            get
            {
                DateTime dt = this;
                switch (dt.DayOfWeek)
                {
                    case System.DayOfWeek.Saturday:
                        return PersianDayOfWeek.Saturday;
                    case System.DayOfWeek.Sunday:
                        return PersianDayOfWeek.Sunday;
                    case System.DayOfWeek.Monday:
                        return PersianDayOfWeek.Monday;
                    case System.DayOfWeek.Tuesday:
                        return PersianDayOfWeek.Tuesday;
                    case System.DayOfWeek.Wednesday:
                        return PersianDayOfWeek.Wednesday;
                    case System.DayOfWeek.Thursday:
                        return PersianDayOfWeek.Thursday;
                    default: return PersianDayOfWeek.Friday;
                }
            }
        }
        #endregion

        #region public String LocalizedMonthName

        /// <summary>
        /// Localized name of PersianDate months.
        /// </summary>
        [Browsable(false)]
        [Description("Localized name of PersianDate months")]
        public String LocalizedMonthName
        {
            get { return PersianMonthNames.Default[_Month]; }
        }

        #endregion

        #region public String LocalizedWeekDayName

        /// <summary>
        /// Weekday names of this instance in localized format.
        /// </summary>
        [Browsable(false)]
        [Description("Weekday names of this instance in localized format.")]
        public String LocalizedWeekDayName
        {
            get { return PersianDateConverter.DayOfWeek(this); }
        }

        #endregion

        #region public Int32 MonthDays

        /// <summary>
        /// Number of days in this _Month.
        /// </summary>
        [Browsable(false)]
        [Description("Number of days in this _Month")]
        public Int32 MonthDays
        {
            get { return PersianDateConverter.MonthDays(_Month); }
        }

        #endregion

        #region public Boolean IsAllowNullDate

        [Browsable(false)]
        public Boolean IsNull
        {
            get { return Year == MinValue.Year && Month == MinValue.Month && Day == MinValue.Day; }
        }

        #endregion

        #endregion

        #region Overrided Methods

        #region public override String ToString()
        /// <summary>
        /// Returns Date in 'yyyy/mm/dd' String format.
        /// </summary>
        /// <returns>String representation of evaluated Date.</returns>
        /// <example>An example on how to get the written form of a Date.
        /// <code>
        ///		class MyClass {
        ///		   public static void Main()
        ///		   {	
        ///				Console.WriteLine(PersianDate.Now.ToString());
        ///		   }
        ///		}
        /// </code>
        /// </example>
        /// <seealso cref="ToWritten"/>
        public override String ToString()
        {
            return ToString("g", null);
        }
        #endregion

        #endregion

        #region Operators Overloading

        #region public static Boolean operator == (PersianDate date1, PersianDate date2)

        /// <summary>
        /// Compares two instance of the PersianDate for the specified operator.
        /// </summary>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <returns></returns>
        public static Boolean operator ==(PersianDate date1, PersianDate date2)
        {
            if ((date1 as object) == null && (date2 as object) == null) return true;
            if ((date1 as object) == null || (date2 as object) == null) return false;

            return date1.Year == date2.Year &&
                   date1.Month == date2.Month &&
                   date1.Day == date2.Day &&
                   date1.Hour == date2.Hour &&
                   date1.Minute == date2.Minute &&
                   date1.Second == date2.Second &&
                   date1.Millisecond == date2.Millisecond;
        }

        #endregion

        #region public static Boolean operator != (PersianDate date1, PersianDate date2)

        /// <summary>
        /// Compares two instance of the PersianDate for the specified operator.
        /// </summary>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <returns></returns>
        public static Boolean operator !=(PersianDate date1, PersianDate date2)
        {
            if ((date1 as object) == null && (date2 as object) == null) return false;
            if ((date1 as object) == null || (date2 as object) == null) return true;

            return date1.Year != date2.Year ||
                   date1.Month != date2.Month ||
                   date1.Day != date2.Day ||
                   date1.Hour != date2.Hour ||
                   date1.Minute != date2.Minute ||
                   date1.Second != date2.Second ||
                   date1.Millisecond != date2.Millisecond;
        }

        #endregion

        #region public static Boolean operator > (PersianDate date1, PersianDate date2)

        /// <summary>
        /// Compares two instance of the PersianDate for the specified operator.
        /// </summary>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <returns></returns>
        public static Boolean operator >(PersianDate date1, PersianDate date2)
        {
            if ((date1 as object) == null && (date2 as object) == null) return false;
            if ((date1 as object) == null || (date2 as object) == null)
                throw new NullReferenceException();
            // =======================================================
            if (date1.Year > date2.Year) return true;
            if (date1.Year == date2.Year && date1.Month > date2.Month) return true;
            // =======================================================
            if (date1.Year == date2.Year &&
                date1.Month == date2.Month &&
                date1.Day > date2.Day)
                return true;
            // =======================================================
            if (date1.Year == date2.Year &&
                date1.Month == date2.Month &&
                date1.Day == date2.Day &&
                date1.Hour > date2.Hour)
                return true;
            // =======================================================
            if (date1.Year == date2.Year &&
                date1.Month == date2.Month &&
                date1.Day == date2.Day &&
                date1.Hour == date2.Hour &&
                date1.Minute > date2.Minute)
                return true;
            // =======================================================
            if (date1.Year == date2.Year &&
                date1.Month == date2.Month &&
                date1.Day == date2.Day &&
                date1.Hour == date2.Hour &&
                date1.Minute == date2.Minute &&
                date1.Second > date2.Second)
                return true;
            // =======================================================
            if (date1.Year == date2.Year &&
                date1.Month == date2.Month &&
                date1.Day == date2.Day &&
                date1.Hour == date2.Hour &&
                date1.Minute == date2.Minute &&
                date1.Second == date2.Second &&
                date1.Millisecond > date2.Millisecond)
                return true;
            // =======================================================
            return false;
        }

        #endregion

        #region public static Boolean operator < (PersianDate date1, PersianDate date2)

        /// <summary>
        /// Compares two instance of the PersianDate for the specified operator.
        /// </summary>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <returns></returns>
        public static Boolean operator <(PersianDate date1, PersianDate date2)
        {
            if ((date1 as object) == null && (date2 as object) == null)
                return false;
            // =======================================================
            if ((date1 as object) == null || (date2 as object) == null)
                throw new NullReferenceException();
            // =======================================================
            if (date1.Year < date2.Year) return true;
            // =======================================================
            if (date1.Year == date2.Year && date1.Month < date2.Month) return true;
            // =======================================================
            if (date1.Year == date2.Year &&
                date1.Month == date2.Month &&
                date1.Day < date2.Day)
                return true;
            // =======================================================
            if (date1.Year == date2.Year &&
                date1.Month == date2.Month &&
                date1.Day == date2.Day &&
                date1.Hour < date2.Hour)
                return true;
            // =======================================================
            if (date1.Year == date2.Year &&
                date1.Month == date2.Month &&
                date1.Day == date2.Day &&
                date1.Hour == date2.Hour &&
                date1.Minute < date2.Minute)
                return true;
            // =======================================================
            if (date1.Year == date2.Year &&
                date1.Month == date2.Month &&
                date1.Day == date2.Day &&
                date1.Hour == date2.Hour &&
                date1.Minute == date2.Minute &&
                date1.Second < date2.Second)
                return true;
            // =======================================================
            if (date1.Year == date2.Year &&
                date1.Month == date2.Month &&
                date1.Day == date2.Day &&
                date1.Hour == date2.Hour &&
                date1.Minute == date2.Minute &&
                date1.Second == date2.Second &&
                date1.Millisecond < date2.Millisecond)
                return true;
            // =======================================================
            return false;
        }

        #endregion

        #region public static Boolean operator <= (PersianDate date1, PersianDate date2)

        /// <summary>
        /// Compares two instance of the PersianDate for the specified operator.
        /// </summary>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <returns></returns>
        public static Boolean operator <=(PersianDate date1, PersianDate date2)
        {
            return (date1 < date2) || (date1 == date2);
        }

        #endregion

        #region public static Boolean operator >= (PersianDate date1, PersianDate date2)

        /// <summary>
        /// Compares two instance of the PersianDate for the specified operator.
        /// </summary>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <returns></returns>
        public static Boolean operator >=(PersianDate date1, PersianDate date2)
        {
            return (date1 > date2) || (date1 == date2);
        }

        #endregion

        #region public override Int32 GetHashCode()

        /// <summary>
        /// Serves as a hash function for a particular type. 
        /// System.Object.GetHashCode() is suitable for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns></returns>
        public override Int32 GetHashCode()
        {
            return ToString("s").GetHashCode();
        }

        #endregion

        #region public override Boolean Equals(object obj)

        /// <summary>
        /// Determines whether the specified System.Object instances are considered equal.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override Boolean Equals(object obj)
        {
            if (obj is PersianDate) return this == (PersianDate) obj;
            return false;
        }

        #endregion

        #endregion

        #region Implicit Casting

        #region public static implicit operator DateTime(PersianDate ThePersianDate)

        public static implicit operator DateTime(PersianDate ThePersianDate)
        {
            return PersianDateConverter.ToGregorianDateTime(ThePersianDate);
        }

        #endregion

        #region public static implicit operator PersianDate(DateTime EnglishDate)

        public static implicit operator PersianDate(DateTime EnglishDate)
        {
            if (EnglishDate.Equals(DateTime.MinValue)) return MinValue;
            return PersianDateConverter.ToPersianDate(EnglishDate);
        }

        #endregion

        #endregion

        #region Interfaces Implementation

        #region public Object Clone()
        /// <summary>
        /// ارائه یك شیء شبیه سازی شده از كلاس تقویم فارسی
        /// </summary>
        /// <returns></returns>
        public Object Clone()
        {
            return new PersianDate(Year, Month, Day, Hour, Minute, Second, Millisecond);
        }
        #endregion

        #region ICompareable Interface

        #region public Int32 CompareTo(object obj)

        ///<summary>
        /// Compares the current instance with another object of the same type.
        ///</summary>
        ///<returns>
        ///A 32-bit signed integer that indicates the relative order of the objects being compared. 
        /// The return value has these meanings: 
        /// Less than zero: This instance is less than obj. Zero: This instance is equal to obj. 
        /// Greater than zero: This instance is greater than obj.
        ///</returns>
        ///<param name="obj">An object to compare with this instance. </param>
        ///<exception cref="T:System.ArgumentException">
        /// obj is not the same type as this instance. 
        /// </exception>
        /// <filterpriority>2</filterpriority>
        public Int32 CompareTo(object obj)
        {
            if (!(obj is PersianDate))
                throw new ArgumentException("Comparing value is not of type PersianDate.");
            // =====================================================
            var ComparedPersianDate = (PersianDate) obj;
            if (ComparedPersianDate < this) return 1;
            if (ComparedPersianDate > this) return -1;
            return 0;
        }

        #endregion

        #endregion

        #region IComparer Interface

        #region public Int32 Compare(object x, object y)

        ///<summary>
        ///Compares two objects and returns a value indicating whether 
        /// one is less than, equal to, or greater than the other.
        ///</summary>
        ///<returns>
        ///Value Condition Less than zero x is less than y. Zero x equals y. Greater than zero x is greater than y. 
        ///</returns>
        ///<param name="y">The second object to compare. </param>
        ///<param name="x">The first object to compare. </param>
        ///<exception cref="T:System.ArgumentException">
        /// either x nor y implements the 
        /// <see cref="T:System.IComparable"></see> 
        /// interface.-or- x and y are of different types and neither one can handle comparisons with the other. 
        /// </exception><filterpriority>2</filterpriority>
        /// <exception cref="T:System.ApplicationException">Either x or y is a null reference</exception>
        public Int32 Compare(object x, object y)
        {
            if (x == null || y == null) throw new ApplicationException("Invalid PersianDate comparer.");

            if (!(x is PersianDate)) throw new ArgumentException("x value is not of type PersianDate.");

            if (!(y is PersianDate)) throw new ArgumentException("y value is not of type PersianDate.");

            var pd1 = (PersianDate) x;
            var pd2 = (PersianDate) y;

            if (pd1 > pd2) return 1;
            if (pd1 < pd2) return -1;
            return 0;
        }

        #endregion

        #endregion

        #region IComparer<T> Interface

        #region public Int32 CompareTo(PersianDate other)

        ///<summary>
        /// Compares the current object with another object of the same type.
        ///</summary>
        ///<returns>
        /// A 32-bit signed integer that indicates the relative order of the objects being compared. 
        /// The return value has the following meanings: 
        /// Less than zero: This object is less than the other parameter. 
        /// Zero: This object is equal to other. Greater than zero: This object is greater than other. 
        ///</returns>
        ///<param name="other">An object to compare with this object.</param>
        public Int32 CompareTo(PersianDate other)
        {
            if (other < this) return 1;
            if (other > this) return -1;
            return 0;
        }

        #endregion

        #region public Int32 Compare(PersianDate x, PersianDate y)

        ///<summary>
        /// Compares two objects and returns a value indicating 
        /// whether one is less than, equal to, or greater than the other.
        ///</summary>
        ///<returns>
        /// Value Condition Less than zerox is less than y.Zerox equals y.Greater than zero x is greater than y.
        ///</returns>
        ///<param name="y">The second object to compare.</param>
        ///<param name="x">The first object to compare.</param>
        public Int32 Compare(PersianDate x, PersianDate y)
        {
            if (x > y) return 1;
            if (x < y) return -1;
            return 0;
        }

        #endregion

        #endregion

        #region IEquatable<T>

        #region public Boolean Equals(PersianDate other)

        ///<summary>
        /// Indicates whether the current object is equal to another object of the same type.
        ///</summary>
        ///<returns>
        /// true if the current object is equal to the other parameter; otherwise, false.
        ///</returns>
        ///<param name="other">An object to compare with this object.</param>
        public Boolean Equals(PersianDate other)
        {
            return this == other;
        }

        #endregion

        #endregion

        #region IFormattable

        #region public String ToString(String format)

        /// <summary>
        /// Returns String representation of this instance in default format.
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public String ToString(String format)
        {
            return ToString(format, null);
        }

        #endregion

        #region public String ToString(IFormatProvider formatProvider)

        /// <summary>
        /// Returns String representation of this instance and format it using the <see cref="IFormatProvider"/> instance.
        /// </summary>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public String ToString(IFormatProvider formatProvider)
        {
            return ToString(null, formatProvider);
        }

        #endregion

        #region public String ToString(String format, IFormatProvider formatProvider)

        /// <summary>
        /// Returns String representation of this instance in desired format, 
        /// or using provided <see cref="IFormatProvider"/> instance.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public String ToString(String format, IFormatProvider formatProvider)
        {
            if (format == null) format = "G";
            Int32 smallhour = (Hour > 12) ? Hour - 12 : Hour;
            String designator = Hour > 12 ? PMDesignator : AMDesignator;
            // ===============================================
            if (formatProvider != null)
            {
                var formatter = formatProvider.GetFormat(typeof (ICustomFormatter)) as ICustomFormatter;
                if (formatter != null) return formatter.Format(format, this, formatProvider);
            }
            // ===============================================
            switch (format)
            {
                case "D":
                    //'yyyy mm dd dddd' e.g. 'دوشنبه 20 شهریور 1384'
                    return String.Format("{0} {1} {2} {3}",
                                         new object[]
                                             {
                                                 LocalizedWeekDayName, PersianUtilities.ConvertToDuplex(Day),
                                                 LocalizedMonthName, Year
                                             });
                    // ===============================================
                case "f":
                    //'hh:mm yyyy mmmm dd dddd' e.g. 'دوشنبه 20 شهریور 1384 21:30'
                    return String.Format("{0} {1} {2} {3} {4}:{5}",
                                         new object[]
                                             {
                                                 LocalizedWeekDayName, PersianUtilities.ConvertToDuplex(Day),
                                                 LocalizedMonthName, Year, PersianUtilities.ConvertToDuplex(Hour),
                                                 PersianUtilities.ConvertToDuplex(Minute)
                                             });
                    // ===============================================
                case "F":
                    //'tt hh:mm:ss yyyy mmmm dd dddd' e.g. 'دوشنبه 20 شهریور 1384 02:30:22 ب.ض'
                    return String.Format("{0} {1} {2} {3} {4}:{5}:{6} {7}", new object[]
                                                                                {
                                                                                    LocalizedWeekDayName,
                                                                                    PersianUtilities.ConvertToDuplex(Day)
                                                                                    , LocalizedMonthName, Year,
                                                                                    PersianUtilities.ConvertToDuplex(
                                                                                        smallhour),
                                                                                    PersianUtilities.ConvertToDuplex(
                                                                                        Minute),
                                                                                    PersianUtilities.ConvertToDuplex(
                                                                                        Second), designator
                                                                                });
                    // ===============================================
                case "g":
                    // 'yyyy/mm/dd hh:mm tt'
                    return String.Format("{0}/{1}/{2} {3}:{4} {5}", new object[]
                                                                        {
                                                                            Year,
                                                                            PersianUtilities.ConvertToDuplex(Month),
                                                                            PersianUtilities.ConvertToDuplex(Day),
                                                                            PersianUtilities.ConvertToDuplex(smallhour),
                                                                            PersianUtilities.ConvertToDuplex(Minute),
                                                                            designator
                                                                        });
                    // ===============================================
                case "G":
                    // 'yyyy/mm/dd hh:mm:ss tt'
                    return String.Format("{0}/{1}/{2} {3}:{4}:{5} {6}", new object[]
                                                                            {
                                                                                Year,
                                                                                PersianUtilities.ConvertToDuplex(Month),
                                                                                PersianUtilities.ConvertToDuplex(Day),
                                                                                PersianUtilities.ConvertToDuplex(
                                                                                    smallhour),
                                                                                PersianUtilities.ConvertToDuplex(Minute)
                                                                                ,
                                                                                PersianUtilities.ConvertToDuplex(Second)
                                                                                , designator
                                                                            });
                    // ===============================================
                case "M":
                case "m":
                    // 'yyyy mmmm'
                    return String.Format("{0} {1}", Year, LocalizedMonthName);
                    // ===============================================
                case "s":
                    //'yyyy-mm-ddThh:mm:ss'
                    return String.Format("{0}-{1}-{2}T{3}:{4}:{5}", Year, PersianUtilities.ConvertToDuplex(Month),
                                         PersianUtilities.ConvertToDuplex(Day), PersianUtilities.ConvertToDuplex(Hour),
                                         PersianUtilities.ConvertToDuplex(Minute),
                                         PersianUtilities.ConvertToDuplex(Second));
                    // ===============================================
                case "t":
                    //'hh:mm tt'
                    return String.Format("{0}:{1} {2}", PersianUtilities.ConvertToDuplex(smallhour),
                                         PersianUtilities.ConvertToDuplex(Minute), designator);
                    // ===============================================
                case "T":
                    //'hh:mm:ss tt'
                    return String.Format("{0}:{1}:{2} {3}", new object[]
                                                                {
                                                                    PersianUtilities.ConvertToDuplex(smallhour),
                                                                    PersianUtilities.ConvertToDuplex(Minute),
                                                                    PersianUtilities.ConvertToDuplex(Second), designator
                                                                });
                    // ===============================================
                default:
                    //ShortDatePattern yyyy/mm/dd e.g. '1384/9/1'
                    return String.Format("{0}/{1}/{2}", Year, PersianUtilities.ConvertToDuplex(Month),
                                         PersianUtilities.ConvertToDuplex(Day));
            }
        }

        #endregion

        #endregion

        #endregion

        #region Private Check Methods

        #region static void CheckYear(Int32 YearNo)

        private static void CheckYear(Int32 YearNo)
        {
            if (YearNo < 1 || YearNo > 9999)
                throw new InvalidPersianDateException(PersianLocalizeManager.GetLocalizerByCulture(
                                                          Thread.CurrentThread.CurrentUICulture).GetLocalizedString(
                                                          StringIDEnum.PersianDate_InvalidYear));
        }

        #endregion

        #region static void CheckMonth(Int32 MonthNo)

        private static void CheckMonth(Int32 MonthNo)
        {
            if (MonthNo > 12 || MonthNo < 1)
                throw new InvalidPersianDateException(PersianLocalizeManager.GetLocalizerByCulture(
                                                          Thread.CurrentThread.CurrentUICulture).GetLocalizedString(
                                                          StringIDEnum.PersianDate_InvalidMonth));
        }

        #endregion

        #region void CheckDay(Int32 YearNo, Int32 MonthNo, Int32 DayNo)
        private void CheckDay(Int32 YearNo, Int32 MonthNo, Int32 DayNo)
        {
            if (MonthNo < 6 && DayNo > 31)
                throw new InvalidPersianDateException(PersianLocalizeManager.
                    GetLocalizerByCulture(Thread.CurrentThread.CurrentUICulture).
                    GetLocalizedString(StringIDEnum.PersianDate_InvalidDay));
            if (MonthNo > 6 && DayNo > 30)
                throw new InvalidPersianDateException(PersianLocalizeManager.
                    GetLocalizerByCulture(Thread.CurrentThread.CurrentUICulture).
                    GetLocalizedString(StringIDEnum.PersianDate_InvalidDay));
            if (MonthNo == 12 && DayNo > 29)
                if (!_PersianCalendar.IsLeapDay(YearNo, MonthNo, DayNo) || DayNo > 30)
                    throw new InvalidPersianDateException(PersianLocalizeManager.
                        GetLocalizerByCulture(Thread.CurrentThread.CurrentUICulture).
                        GetLocalizedString(StringIDEnum.PersianDate_InvalidDay));
        }
        #endregion

        #region static void CheckHour(Int32 HourNo)

        private static void CheckHour(Int32 HourNo)
        {
            if (HourNo > 24 || HourNo < 0)
                throw new InvalidPersianDateException(PersianLocalizeManager.GetLocalizerByCulture(
                                                          Thread.CurrentThread.CurrentUICulture).GetLocalizedString(
                                                          StringIDEnum.PersianDate_InvalidHour));
        }

        #endregion

        #region static void CheckMinute(Int32 MinuteNo)

        private static void CheckMinute(Int32 MinuteNo)
        {
            if (MinuteNo > 60 || MinuteNo < 0)
                throw new InvalidPersianDateException(PersianLocalizeManager.GetLocalizerByCulture(
                                                          Thread.CurrentThread.CurrentUICulture).GetLocalizedString(
                                                          StringIDEnum.PersianDate_InvalidMinute));
        }

        #endregion

        #region static void CheckSecond(Int32 SecondNo)

        private static void CheckSecond(Int32 SecondNo)
        {
            if (SecondNo > 60 || SecondNo < 0)
                throw new InvalidPersianDateException(PersianLocalizeManager.GetLocalizerByCulture(
                                                          Thread.CurrentThread.CurrentUICulture).GetLocalizedString(
                                                          StringIDEnum.PersianDate_InvalidSecond));
        }

        #endregion

        #region static void CheckMillisecond(Int32 MillisecondNo)

        private static void CheckMillisecond(Int32 MillisecondNo)
        {
            if (MillisecondNo < 0 || MillisecondNo > 1000)
                throw new InvalidPersianDateException(PersianLocalizeManager.GetLocalizerByCulture(
                                                          Thread.CurrentThread.CurrentUICulture).GetLocalizedString(
                                                          StringIDEnum.PersianDate_InvalidMillisecond));
        }

        #endregion

        #endregion

        #region Public Methods

        #region void Assign(PersianDate pd)
        /// <summary>
        /// Assigns an instance of PersianDate's values to this instance.
        /// </summary>
        /// <param name="pd"></param>
        public void Assign(PersianDate pd)
        {
            Year = pd.Year;
            Month = pd.Month;
            Day = pd.Day;
            Hour = pd.Hour;
            Minute = pd.Minute;
            Second = pd.Second;
        }
        #endregion

        #region String ToWritten()
        /// <summary>
        /// بازگرداندن مقدار تاریخ جاری به صورت حرفی
        /// </summary>
        public String ToWritten()
        {
            return (LocalizedWeekDayName + " " + _Day + " " + LocalizedMonthName + " " + _Year);
        }
        #endregion

        #region Public Parse Methods

        #region static PersianDate Parse(String value, Boolean includesTime)

        /// <summary>
        /// Parse a String value into a PersianDate instance. Value could be either in 'yyyy/mm/dd hh:mm:ss' or 
        /// 'yyyy/mm/dd' formats. If you want to parse <c>Time</c> value too,
        /// you should set <c>includesTime</c> to <c>true</c>.
        /// </summary>
        /// <exception cref="InvalidPersianDateException"></exception>
        /// <param name="value"></param>
        /// <param name="includesTime"></param>
        /// <returns></returns>
        public static PersianDate Parse(String value, Boolean includesTime)
        {
            if (value == String.Empty)
                return MinValue;
            if (includesTime)
            {
                if (value.Length > 19)
                    throw new InvalidPersianDateFormatException(PersianLocalizeManager.GetLocalizerByCulture(
                                                                    Thread.CurrentThread.CurrentUICulture).
                                                                    GetLocalizedString(
                                                                    StringIDEnum.PersianDate_InvalidDateTimeLength));

                String[] dt = value.Split(" ".ToCharArray());

                if (dt.Length != 2)
                    throw new InvalidPersianDateFormatException(PersianLocalizeManager.GetLocalizerByCulture(
                                                                    Thread.CurrentThread.CurrentUICulture).
                                                                    GetLocalizedString(
                                                                    StringIDEnum.PersianDate_InvalidDateFormat));

                String _date = dt[0];
                String _time = dt[1];

                String[] dateParts = _date.Split("/".ToCharArray());
                String[] timeParts = _time.Split(":".ToCharArray());

                if (dateParts.Length != 3)
                    throw new InvalidPersianDateFormatException(PersianLocalizeManager.GetLocalizerByCulture(
                                                                    Thread.CurrentThread.CurrentUICulture).
                                                                    GetLocalizedString(
                                                                    StringIDEnum.PersianDate_InvalidDateFormat));

                if (timeParts.Length != 3)
                    throw new InvalidPersianDateFormatException(PersianLocalizeManager.GetLocalizerByCulture(
                                                                    Thread.CurrentThread.CurrentUICulture).
                                                                    GetLocalizedString(
                                                                    StringIDEnum.PersianDate_InvalidTimeFormat));

                Int32 day = Int32.Parse(dateParts[2]);
                Int32 month = Int32.Parse(dateParts[1]);
                Int32 year = Int32.Parse(dateParts[0]);
                Int32 hour = Int32.Parse(timeParts[0]);
                Int32 minute = Int32.Parse(timeParts[1]);
                Int32 second = Int32.Parse(timeParts[2]);

                return new PersianDate(year, month, day, hour, minute, second);
            }
            return Parse(value);
        }

        #endregion

        #region static PersianDate Parse(String value, String format)

        public static PersianDate Parse(String value, String format)
        {
            switch (format)
            {
                case "G": //yyyy/mm/dd hh:mm:ss tt
                    return ParseFullDateTime(value);

                case "g": //yyyy/mm/dd hh:mm tt
                    return ParseDateShortTime(value);

                case "d": //yyyy/mm/dd
                    return Parse(value);

                default:
                    throw new ArgumentException("Currently G,g,d formats are supported.");
            }
        }

        #endregion

        #region static PersianDate ParseFullDateTime(String value)

        /// <summary>
        /// Parse a String value into a PersianDate instance. Value should be in 'yyyy/mm/dd hh:mm:ss tt' formats.
        /// </summary>
        /// <exception cref="InvalidPersianDateException"></exception>
        /// <param name="value"></param>
        /// <returns></returns>
        private static PersianDate ParseFullDateTime(String value)
        {
            if (value == String.Empty)
                return PersianDateConverter.ToPersianDate(DateTime.Now);

            if (value.Length > 23)
                throw new InvalidPersianDateFormatException(PersianLocalizeManager.GetLocalizerByCulture(
                                                                Thread.CurrentThread.CurrentUICulture).
                                                                GetLocalizedString(
                                                                StringIDEnum.PersianDate_InvalidDateTimeLength));

            String[] dt = value.Split(" ".ToCharArray());

            if (dt.Length != 3)
                throw new InvalidPersianDateFormatException(PersianLocalizeManager.GetLocalizerByCulture(
                                                                Thread.CurrentThread.CurrentUICulture).
                                                                GetLocalizedString(
                                                                StringIDEnum.PersianDate_InvalidDateFormat));

            String _date = dt[0];
            String _time = dt[1];

            String[] dateParts = _date.Split("/".ToCharArray());
            String[] timeParts = _time.Split(":".ToCharArray());

            if (dateParts.Length != 3)
                throw new InvalidPersianDateFormatException(PersianLocalizeManager.GetLocalizerByCulture(
                                                                Thread.CurrentThread.CurrentUICulture).
                                                                GetLocalizedString(
                                                                StringIDEnum.PersianDate_InvalidDateFormat));

            if (timeParts.Length != 3)
                throw new InvalidPersianDateFormatException(PersianLocalizeManager.GetLocalizerByCulture(
                                                                Thread.CurrentThread.CurrentUICulture).
                                                                GetLocalizedString(
                                                                StringIDEnum.PersianDate_InvalidTimeFormat));

            Int32 day = Int32.Parse(dateParts[2]);
            Int32 month = Int32.Parse(dateParts[1]);
            Int32 year = Int32.Parse(dateParts[0]);
            Int32 hour = Int32.Parse(timeParts[0]);
            Int32 minute = Int32.Parse(timeParts[1]);
            Int32 second = Int32.Parse(timeParts[2]);

            return new PersianDate(year, month, day, hour, minute, second, 0);
        }

        #endregion

        #region static PersianDate ParseDateShortTime(String value)

        /// <summary>
        /// Parse a String value into a PersianDate instance. Value should be in 'yyyy/mm/dd hh:mm tt' formats.
        /// </summary>
        /// <exception cref="InvalidPersianDateException"></exception>
        /// <param name="value"></param>
        /// <returns></returns>
        private static PersianDate ParseDateShortTime(String value)
        {
            if (value == String.Empty)
                return PersianDateConverter.ToPersianDate(DateTime.Now);

            if (value.Length > 20)
                throw new InvalidPersianDateFormatException(PersianLocalizeManager.GetLocalizerByCulture(
                                                                Thread.CurrentThread.CurrentUICulture).
                                                                GetLocalizedString(
                                                                StringIDEnum.PersianDate_InvalidDateTimeLength));

            String[] dt = value.Split(" ".ToCharArray());

            if (dt.Length != 3)
                throw new InvalidPersianDateFormatException(PersianLocalizeManager.GetLocalizerByCulture(
                                                                Thread.CurrentThread.CurrentUICulture).
                                                                GetLocalizedString(
                                                                StringIDEnum.PersianDate_InvalidDateFormat));

            String _date = dt[0];
            String _time = dt[1];

            String[] dateParts = _date.Split("/".ToCharArray());
            String[] timeParts = _time.Split(":".ToCharArray());

            if (dateParts.Length != 3)
                throw new InvalidPersianDateFormatException(PersianLocalizeManager.GetLocalizerByCulture(
                                                                Thread.CurrentThread.CurrentUICulture).
                                                                GetLocalizedString(
                                                                StringIDEnum.PersianDate_InvalidDateFormat));

            if (timeParts.Length != 2)
                throw new InvalidPersianDateFormatException(PersianLocalizeManager.GetLocalizerByCulture(
                                                                Thread.CurrentThread.CurrentUICulture).
                                                                GetLocalizedString(
                                                                StringIDEnum.PersianDate_InvalidTimeFormat));

            Int32 day = Int32.Parse(dateParts[2]);
            Int32 month = Int32.Parse(dateParts[1]);
            Int32 year = Int32.Parse(dateParts[0]);
            Int32 hour = Int32.Parse(timeParts[0]);
            Int32 minute = Int32.Parse(timeParts[1]);

            return new PersianDate(year, month, day, hour, minute, 0, 0);
        }

        #endregion

        #region static PersianDate Parse(String value)

        /// <summary>
        /// Parse a String value into a PersianDate instance. Value can only be in 'yyyy/mm/dd' format.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static PersianDate Parse(String value)
        {
            if (value.Length == 10) return ParseShortDate(value);
            if (value.Length == 20) return ParseDateShortTime(value);
            if (value.Length == 23) return ParseFullDateTime(value);

            throw new InvalidPersianDateFormatException("Can not parse the value. Format is incorrect.");
        }

        #endregion

        #region static PersianDate ParseShortDate(String value)

        private static PersianDate ParseShortDate(String value)
        {
            if (value == String.Empty) return PersianDateConverter.ToPersianDate(DateTime.Now);

            if (value.Length > 10)
                throw new InvalidPersianDateFormatException(PersianLocalizeManager.GetLocalizerByCulture(
                                                                Thread.CurrentThread.CurrentUICulture).
                                                                GetLocalizedString(
                                                                StringIDEnum.PersianDate_InvalidDateTimeLength));

            String[] dateParts = value.Split("/".ToCharArray());

            if (dateParts.Length != 3)
                throw new InvalidPersianDateFormatException(PersianLocalizeManager.GetLocalizerByCulture(
                                                                Thread.CurrentThread.CurrentUICulture).
                                                                GetLocalizedString(
                                                                StringIDEnum.PersianDate_InvalidDateFormat));

            Int32 day = Int32.Parse(dateParts[2]);
            Int32 month = Int32.Parse(dateParts[1]);
            Int32 year = Int32.Parse(dateParts[0]);

            return new PersianDate(year, month, day);
        }

        #endregion

        #endregion

        #endregion

        #region Classes

        #region public class PersianMonthNames

        /// <summary>
        /// كلاس مدیریت نام ماه های فارسی
        /// </summary>
        public class PersianMonthNames
        {
            #region Fields

            private static readonly PersianMonthNames _PersianMonthNames;
            public String Aban = "آبان";
            public String Azar = "آذر";
            public String Bahman = "بهمن";
            public String Day = "دی";
            public String Esfand = "اسفند";
            public String Farvardin = "فروردین";
            public String Khordad = "خرداد";
            public String Mehr = "مهر";
            public String Mordad = "مرداد";
            public String Ordibehesht = "اردیبهشت";
            public String Shahrivar = "شهریور";
            public String Tir = "تیر";
            #endregion

            #region Ctor

            /// <summary>
            /// سازنده پیش فرض
            /// </summary>
            static PersianMonthNames()
            {
                _PersianMonthNames = new PersianMonthNames();
            }

            #endregion

            #region Indexers

            #region public static PersianMonthNames Default

            /// <summary>
            /// ماه پیش فرض تقویم
            /// </summary>
            public static PersianMonthNames Default
            {
                get { return _PersianMonthNames; }
            }

            #endregion

            #region public String this[Int32 month]

            /// <summary>
            /// شمارشگر ماه تقویم
            /// </summary>
            /// <param name="month"></param>
            /// <returns></returns>
            public String this[Int32 month]
            {
                get { return GetName(month); }
            }

            #endregion

            #endregion

            #region Methods

            #region private String GetName(Int32 monthNo)

            /// <summary>
            /// دریافت نام ماه تقویم فارسی بر اساس شماره ماه
            /// </summary>
            /// <param name="monthNo">شماره ماه</param>
            /// <returns>نام ماه</returns>
            private String GetName(Int32 monthNo)
            {
                switch (monthNo)
                {
                    case 1:
                        return Farvardin;
                    case 2:
                        return Ordibehesht;
                    case 3:
                        return Khordad;
                    case 4:
                        return Tir;
                    case 5:
                        return Mordad;
                    case 6:
                        return Shahrivar;
                    case 7:
                        return Mehr;
                    case 8:
                        return Aban;
                    case 9:
                        return Azar;
                    case 10:
                        return Day;
                    case 11:
                        return Bahman;
                    case 12:
                        return Esfand;
                    default:
                        throw new ArgumentOutOfRangeException("Month value " + monthNo + " is out of range");
                }
            }

            #endregion

            #endregion
        }
        #endregion

        #region public class PersianWeekDayNames
        /// <summary>
        /// كلاس مدیریت متن نام روزهای هفته
        /// </summary>
        public class PersianWeekDayNames
        {
            #region Fields

            private static readonly PersianWeekDayNames _PersianWeekDayNames;
            public String Chaharshanbeh = "چهارشنبه";
            public String Doshanbeh = "دوشنبه";
            public String Jomeh = "جمعه";
            public String Panjshanbeh = "پنجشنبه";
            public String Seshanbeh = "سه شنبه";
            public String Shanbeh = "شنبه";
            public String Yekshanbeh = "یکشنبه";
            #endregion

            #region Ctor

            /// <summary>
            /// سازنده پیش فرض كلاس
            /// </summary>
            static PersianWeekDayNames()
            {
                _PersianWeekDayNames = new PersianWeekDayNames();
            }

            #endregion

            #region Indexer

            #region public static PersianWeekDayNames Default

            /// <summary>
            /// شیء پیش فرض كلاس نام های فارسی
            /// </summary>
            public static PersianWeekDayNames Default
            {
                get { return _PersianWeekDayNames; }
            }

            #endregion

            #region public String this[Int32 day]

            /// <summary>
            /// ارائه نام روز هفته بر اساس شماره روز
            /// </summary>
            /// <param name="day"></param>
            /// <returns></returns>
            public String this[Int32 day]
            {
                get { return GetName(day); }
            }

            #endregion

            #endregion

            #region Methods

            private String GetName(Int32 WeekDayNo)
            {
                switch (WeekDayNo)
                {
                    case 0:
                        return Shanbeh;

                    case 1:
                        return Yekshanbeh;

                    case 2:
                        return Doshanbeh;

                    case 3:
                        return Seshanbeh;

                    case 4:
                        return Chaharshanbeh;

                    case 5:
                        return Panjshanbeh;

                    case 6:
                        return Jomeh;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            #endregion
        }
        #endregion

        #region public class PersianWeekDayAbbr

        /// <summary>
        /// كلاس مدیریت نام كوتاه ایام هفته تقویم
        /// </summary>
        public class PersianWeekDayAbbr
        {
            #region Fields

            private static readonly PersianWeekDayAbbr _PersianWeekDayAbbr;
            public String Chaharshanbeh = "چ";
            public String Doshanbeh = "د";
            public String Jomeh = "ج";
            public String Panjshanbeh = "پ";
            public String Seshanbeh = "س";
            public String Shanbeh = "ش";
            public String Yekshanbeh = "ی";

            #endregion

            #region Ctor

            /// <summary>
            /// سازنده پیش فرض كلاس
            /// </summary>
            static PersianWeekDayAbbr()
            {
                _PersianWeekDayAbbr = new PersianWeekDayAbbr();
            }

            #endregion

            #region Indexer

            #region public static PersianWeekDayAbbr Default

            /// <summary>
            /// 
            /// </summary>
            public static PersianWeekDayAbbr Default
            {
                get { return _PersianWeekDayAbbr; }
            }

            #endregion

            #region public String this[Int32 day]

            /// <summary>
            /// 
            /// </summary>
            /// <param name="day"></param>
            /// <returns></returns>
            public String this[Int32 day]
            {
                get { return GetName(day); }
            }

            #endregion

            #endregion

            #region Methods

            #region private String GetName(Int32 WeekDayNo)

            private String GetName(Int32 WeekDayNo)
            {
                switch (WeekDayNo)
                {
                    case 0:
                        return Shanbeh;
                    case 1:
                        return Yekshanbeh;
                    case 2:
                        return Doshanbeh;
                    case 3:
                        return Seshanbeh;
                    case 4:
                        return Chaharshanbeh;
                    case 5:
                        return Panjshanbeh;
                    case 6:
                        return Jomeh;
                    default:
                        throw new ArgumentOutOfRangeException("WeekDay number " + "is out of range");
                }
            }

            #endregion

            #endregion
        }

        #endregion

        #endregion
    }
}