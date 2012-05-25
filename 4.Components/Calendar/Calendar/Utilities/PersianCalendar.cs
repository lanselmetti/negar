#region using

using System;
using System.Globalization;
using System.Threading;
using Negar.PersianCalendar.Resource;
using Negar.PersianCalendar.Utilities.Exceptions;

#endregion

namespace Negar.PersianCalendar.Utilities
{

    /// <summary>
    /// Persian calendar, also named Jalaali calendar, was first based on Solar year by Omar Khayyam, 
    /// the great Iranian poet, astrologer and scientist.
    /// Jalaali calendar is approximately 365 days. Each of the first six months in the Jalaali calendar has 31 days, 
    /// each of the next five months has 30 days, and the last month has 29 days in a common year and 30 days in a leap year. 
    /// A leap year is a year that, when divided by 33, has a remainder of 1, 5, 9, 13, 17, 22, 26, or 30. For example, 
    /// the year 1370 is a leap year because dividing it by 33 yields a remainder of 17. 
    /// There are approximately 8 leap years in every 33 year cycle.
    /// </summary>
    [Serializable]
    public sealed class PersianCalendar : Calendar
    {
        #region Fields

        #region public static readonly Int32 PersianEra

        /// <summary>
        /// Represents the current era.
        /// </summary>
        /// <remarks>The Persian calendar recognizes only A.P (Anno Persarum) era.</remarks>
        public static readonly Int32 PersianEra = 1;

        #endregion

        #region Int32 twoDigitYearMax = 1409

        /// <summary>
        /// حداكثر سال پشتیبانی شده در تقویم فارسی
        /// </summary>
        private Int32 twoDigitYearMax = 1409;

        #endregion

        #endregion

        #region Properties

        #region new Int32 TwoDigitYearMax

        /// <summary>
        /// Gets and sets the last year of a 100-year range that can be represented by a 2-digit year.
        /// </summary>
        /// <property_value>The last year of a 100-year range that can be represented by a 2-digit year.</property_value>
        /// <remarks>This property allows a 2-digit year to be properly translated to a 4-digit year. 
        /// For example, if this property is set to 1429, the 100-year range is from 1330 to 1429; therefore, 
        /// a 2-digit value of 30 is interpreted as 1330, while a 2-digit value of 29 is interpreted as 1429.</remarks>
        public new Int32 TwoDigitYearMax
        {
            get { return twoDigitYearMax; }
            set
            {
                if (value < 100 || 9378 < value)
                    throw new InvalidPersianDateException(PersianLocalizeManager.GetLocalizerByCulture(
                                                              Thread.CurrentThread.CurrentUICulture).GetLocalizedString(
                                                              StringIDEnum.PersianDate_InvalidFourDigitYear));
                twoDigitYearMax = value;
            }
        }

        #endregion

        #endregion

        #region Overrided Methods

        #region DateTime AddMonths(DateTime time, Int32 months)

        #region Summary

        /// <summary>
        /// Returns a DateTime that is the specified number of months away from the specified DateTime.
        /// </summary>
        /// <param name="time">The DateTime instance to add.</param>
        /// <param name="months">The number of months to add.</param>
        /// <returns>The DateTime that results from adding the specified number of months to the specified DateTime.</returns>
        /// <remarks>
        /// The year part of the resulting DateTime is affected if the resulting month is beyond the last month of the current year. 
        /// The day part of the resulting DateTime is also affected if the resulting day is not a valid day in the resulting month 
        /// of the resulting year; it is changed to the last valid day in the resulting month of the resulting year. 
        /// The time-of-day part of the resulting DateTime remains the same as the specified DateTime.
        /// 
        /// For example, if the specified month is Ordibehesht, which is the 2nd month and has 31 days, 
        /// the specified day is the 31th day of that month, and the value of the months parameter is -3, 
        /// the resulting year is one less than the specified year, the resulting month is Bahman, 
        /// and the resulting day is the 30th day, which is the last day in Bahman.
        /// 
        /// If the value of the months parameter is negative, the resulting DateTime would be earlier than the specified DateTime.
        /// </remarks>

        #endregion

        public override DateTime AddMonths(DateTime time, Int32 months)
        {
            if (Math.Abs(months) > 120000)
                throw new InvalidPersianDateException(PersianLocalizeManager.GetLocalizerByCulture(
                                                          Thread.CurrentThread.CurrentUICulture).GetLocalizedString(
                                                          StringIDEnum.PersianDate_InvalidMonth));

            #region Seperate Time Values (Year , Month , Day)

            Int32 year = GetYear(true, time);
            Int32 month = GetMonth(false, time);
            Int32 day = GetDayOfMonth(false, time);

            #endregion

            // +++++++++++++++++++++++++++++++++++++++++++
            month += (year - 1) * 12 + months;
            year = (month - 1) / 12 + 1;
            month -= (year - 1) * 12;
            // +++++++++++++++++++++++++++++++++++++++++++
            if (day > 29)
            {
                Int32 maxday = GetDaysInMonth(false, year, month, 0);
                if (maxday < day) day = maxday;
            }
            // +++++++++++++++++++++++++++++++++++++++++++
            DateTime dateTime;
            try
            {
                dateTime = ToDateTime(year, month, day, 0, 0, 0, 0) + time.TimeOfDay;
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new InvalidPersianDateException(PersianLocalizeManager.GetLocalizerByCulture(
                                                          Thread.CurrentThread.CurrentUICulture).GetLocalizedString(
                                                          StringIDEnum.PersianDate_InvalidDateTime));
            }
            return dateTime;
        }

        #endregion

        #region DateTime AddYears(DateTime time, Int32 years)

        #region Summary

        /// <summary>
        /// Returns a DateTime that is the specified number of years away from the specified DateTime.
        /// </summary>
        /// <param name="time">The DateTime instance to add.</param>
        /// <param name="years">The number of years to add.</param>
        /// <returns>The DateTime that results from adding the specified number of years to the specified DateTime.</returns>
        /// <remarks>
        /// The day part of the resulting DateTime is affected if the resulting day is not a valid day in the resulting month of 
        /// the resulting year; it is changed to the last valid day in the resulting month of the resulting year. 
        /// The time-of-day part of the resulting DateTime remains the same as the specified DateTime.
        /// 
        /// For example, Esfand has 29 days, except during leap years when it has 30 days. 
        /// If the specified Date is the 30th day of Esfand in a leap year and the value of years is 1, 
        /// the resulting Date will be the 29th day of Esfand in the following year.
        /// 
        /// If years is negative, the resulting DateTime would be earlier than the specified DateTime.
        /// </remarks>

        #endregion

        public override DateTime AddYears(DateTime time, Int32 years)
        {
            #region Seperate Date Values

            Int32 year = GetYear(true, time);
            Int32 month = GetMonth(false, time);
            Int32 day = GetDayOfMonth(false, time);

            #endregion

            #region Manage Leap Years

            year += years;
            if (day == 30 && month == 12)
                if (!IsLeapYear(false, year, 0)) day = 29;

            #endregion

            DateTime dateTime;
            try
            {
                dateTime = ToDateTime(year, month, day, 0, 0, 0, 0) + time.TimeOfDay;
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new InvalidPersianDateException(PersianLocalizeManager.GetLocalizerByCulture(
                                                          Thread.CurrentThread.CurrentUICulture).GetLocalizedString(
                                                          StringIDEnum.PersianDate_InvalidDateTime));
            }
            return dateTime;
        }

        #endregion

        #region Int32 GetDayOfMonth(DateTime time)

        /// <summary>
        /// Gets the day of the month in the specified DateTime.
        /// </summary>
        /// <param name="time">The DateTime instance to read.</param>
        /// <returns>An integer from 1 to 31 that represents the day of the month in time.</returns>
        public override Int32 GetDayOfMonth(DateTime time)
        {
            return GetDayOfMonth(true, time);
        }

        #endregion

        #region DayOfWeek GetDayOfWeek(DateTime time)
        /// <summary>
        /// Gets the day of the week in the specified DateTime.
        /// </summary>
        /// <param name="time">The DateTime instance to read.</param>
        /// <returns>A DayOfWeek value that represents the day of the week in time.</returns>
        /// <remarks>The DayOfWeek values are Sunday which indicates YekShanbe', Monday which indicates DoShanbe', 
        /// Tuesday which indicates SeShanbe', Wednesday which indicates ChaharShanbe', 
        /// Thursday which indicates PanjShanbe', Friday which indicates Jom'e, and 
        /// Saturday which indicates Shanbe'.</remarks>
        public override DayOfWeek GetDayOfWeek(DateTime time)
        {
            return time.DayOfWeek;
        }
        #endregion

        #region Int32 GetDayOfYear(DateTime time)

        /// <summary>
        /// Gets the day of the year in the specified DateTime.
        /// </summary>
        /// <param name="time">The DateTime instance to read.</param>
        /// <returns>An integer from 1 to 366 that represents the day of the year in time.</returns>
        public override Int32 GetDayOfYear(DateTime time)
        {
            return GetDayOfYear(true, time);
        }

        #endregion

        #region Int32 GetDaysInMonth(Int32 year, Int32 month, Int32 era)

        /// <summary>
        /// Gets the number of days in the specified month.
        /// </summary>
        /// <param name="year">An integer that represents the year.</param>
        /// <param name="month">An integer that represents the month.</param>
        /// <param name="era">An integer that represents the era.</param>
        /// <returns>The number of days in the specified month in the specified year in the specified era.</returns>
        /// <remarks>For example, this method might return 29 or 30 for Esfand (month = 12), 
        /// depending on whether year is a leap year.</remarks>
        public override Int32 GetDaysInMonth(Int32 year, Int32 month, Int32 era)
        {
            return GetDaysInMonth(true, year, month, era);
        }

        #endregion

        #region Int32 GetDaysInYear(Int32 year, Int32 era)

        /// <summary>
        /// Gets the number of days in the year specified by the year and era parameters.
        /// </summary>
        /// <param name="year">An integer that represents the year.</param>
        /// <param name="era">An integer that represents the era.</param>
        /// <returns>The number of days in the specified year in the specified era.</returns>
        /// <remarks>For example, this method might return 365 or 366, depending on whether year is a leap year.</remarks>
        public override Int32 GetDaysInYear(Int32 year, Int32 era)
        {
            return GetDaysInYear(true, year, era);
        }

        #endregion

        #region Int32 GetEra(DateTime time)

        /// <summary>
        /// Gets the era in the specified DateTime.
        /// </summary>
        /// <param name="time">The DateTime instance to read.</param>
        /// <returns>An integer that represents the era in time.</returns>
        /// <remarks>The Persian calendar recognizes one era: A.P. (Latin "Anno Persarum", 
        /// which means "the year of/for Persians").</remarks>
        public override Int32 GetEra(DateTime time)
        {
            CheckTicksRange(true, time);
            return PersianEra;
        }

        #endregion

        #region Int32 GetMonth(DateTime time)

        /// <summary>
        /// Gets the month in the specified DateTime.
        /// </summary>
        /// <param name="time">The DateTime instance to read.</param>
        /// <returns>An integer between 1 and 12 that represents the month in time.</returns>
        /// <remarks>Month 1 indicates Farvardin, month 2 indicates Ordibehesht, month 3 indicates Khordad, 
        /// month 4 indicates Tir, month 5 indicates Amordad, month 6 indicates Shahrivar, month 7 indicates Mehr, 
        /// month 8 indicates Aban, month 9 indicates Azar, month 10 indicates Dey, month 11 indicates Bahman, 
        /// and month 12 indicates Esfand.</remarks>
        public override Int32 GetMonth(DateTime time)
        {
            return GetMonth(true, time);
        }

        #endregion

        #region Int32 GetMonthsInYear(Int32 year, Int32 era)

        /// <summary>
        /// Gets the number of months in the year specified by the year and era parameters.
        /// </summary>
        /// <param name="year">An integer that represents the year.</param>
        /// <param name="era">An integer that represents the era.</param>
        /// <returns>The number of months in the specified year in the specified era.</returns>
        public override Int32 GetMonthsInYear(Int32 year, Int32 era)
        {
            CheckEraRange(true, era);
            CheckYearRange(true, year);
            return 12;
        }

        #endregion

        #region Int32 GetYear(DateTime time)

        /// <summary>
        /// Gets the year in the specified DateTime.
        /// </summary>
        /// <param name="time">The DateTime instance to read.</param>
        /// <returns>An integer between 1 and 9378 that represents the year in time.</returns>
        public override Int32 GetYear(DateTime time)
        {
            return GetYear(true, time);
        }

        #endregion

        #region Boolean IsLeapDay(Int32 year, Int32 month, Int32 day, Int32 era)
        /// <summary>
        /// Determines whether the Date specified by the year, month, day, and era parameters is a leap day.
        /// </summary>
        /// <param name="year">An integer that represents the year.</param>
        /// <param name="month">An integer that represents the month.</param>
        /// <param name="day">An integer that represents the day.</param>
        /// <param name="era">An integer that represents the era.</param>
        /// <returns>true if the specified day is a leap day; otherwise, false.</returns>
        /// <remarks>
        /// In the Persian calendar leap years are applied every 4 or 5 years according to a certain pattern that 
        /// iterates in a 2820-year cycle. A common year has 365 days and a leap year has 366 days.
        /// 
        /// A leap day is a day that occurs only in a leap year. In the Persian calendar, 
        /// the 30th day of Esfand (month 12) is the only leap day.
        /// </remarks>
        public override Boolean IsLeapDay(Int32 year, Int32 month, Int32 day, Int32 era)
        {
            CheckEraRange(true, era);
            CheckYearRange(true, year);
            CheckMonthRange(true, month);
            if (day == 30 && month == 12 && IsLeapYear(false, year, 0))
                return true;
            return false;
        }
        #endregion

        #region Boolean IsLeapMonth(Int32 year, Int32 month, Int32 era)

        /// <summary>
        /// Determines whether the month specified by the year, month, and era parameters is a leap month.
        /// </summary>
        /// <param name="year">An integer that represents the year.</param>
        /// <param name="month">An integer that represents the month.</param>
        /// <param name="era">An integer that represents the era.</param>
        /// <returns>This method always returns false, unless overridden by a derived class.</returns>
        /// <remarks>
        /// In the Persian calendar leap years are applied every 4 or 5 years according to a certain pattern that 
        /// iterates in a 2820-year cycle. A common year has 365 days and a leap year has 366 days.
        /// 
        /// A leap month is an entire month that occurs only in a leap year. The Persian calendar does not have any leap months.
        /// </remarks>
        public override Boolean IsLeapMonth(Int32 year, Int32 month, Int32 era)
        {
            CheckEraRange(true, era);
            CheckYearRange(true, year);
            CheckMonthRange(true, month);
            return false;
        }

        #endregion

        #region Boolean IsLeapYear(Int32 year, Int32 era)

        /// <summary>
        /// Determines whether the year specified by the year and era parameters is a leap year.
        /// </summary>
        /// <param name="year">An integer that represents the year.</param>
        /// <param name="era">An integer that represents the era.</param>
        /// <returns>true if the specified year is a leap year; otherwise, false.</returns>
        /// <remarks>In the Persian calendar leap years are applied every 4 or 5 years according to a certain 
        /// pattern that iterates in a 2820-year cycle. A common year has 365 days and a leap year has 366 days.</remarks>
        public override Boolean IsLeapYear(Int32 year, Int32 era)
        {
            return IsLeapYear(true, year, era);
        }

        #endregion

        #region DateTime ToDateTime(Int32 year, Int32 month, Int32 day, Int32 hour, Int32 minute, Int32 second, Int32 millisecond, Int32 era)

        /// <summary>
        /// Returns a DateTime that is set to the specified Date and time in the specified era.
        /// </summary>
        /// <param name="year">An integer that represents the year.</param>
        /// <param name="month">An integer that represents the month.</param>
        /// <param name="day">An integer that represents the day.</param>
        /// <param name="hour">An integer that represents the hour.</param>
        /// <param name="minute">An integer that represents the minute.</param>
        /// <param name="second">An integer that represents the second.</param>
        /// <param name="millisecond">An integer that represents the millisecond.</param>
        /// <param name="era">An integer that represents the era.</param>
        /// <returns>The DateTime instance set to the specified Date and time in the current era.</returns>
        public override DateTime ToDateTime(Int32 year, Int32 month, Int32 day, Int32 hour, Int32 minute, Int32 second,
                                            Int32 millisecond, Int32 era)
        {
            CheckEraRange(true, era);
            CheckDateRange(true, year, month, day);
            Int32 days = day;
            for (Int32 i = 1; i < month; i++)
                if (i < 7) days += 31;
                else if (i < 12) days += 30;
            days += 365 * year + NumberOfLeapYearsUntil(false, year);
            // Following line validates the arguments of time:
            var timePart = new DateTime(1, 1, 1, hour, minute, second, millisecond);
            long ticks = days * 864000000000L + timePart.Ticks + 195721056000000000L;
            DateTime dateTime;
            try
            {
                dateTime = new DateTime(ticks);
            }
            catch (ArgumentOutOfRangeException)
            {
                // If ticks go greater than DateTime.MaxValue.Ticks, this exception will be caught:
                throw new InvalidPersianDateException(PersianLocalizeManager.GetLocalizerByCulture(
                                                          Thread.CurrentThread.CurrentUICulture).GetLocalizedString(
                                                          StringIDEnum.PersianDate_InvalidMonthDay));
            }
            return dateTime;
        }

        #endregion

        #region Int32 ToFourDigitYear(Int32 year)

        /// <summary>
        /// Converts the specified two-digit year to a four-digit year by using the 
        /// Globalization.PersianCalendar.TwoDigitYearMax property to determine the appropriate century.
        /// </summary>
        /// <param name="year">A two-digit integer that represents the year to convert.</param>
        /// <returns>An integer that contains the four-digit representation of year.</returns>
        /// <remarks>TwoDigitYearMax is the last year in the 100-year range that can be represented by a two-digit year. 
        /// The century is determined by finding the sole occurrence of the two-digit year within that 100-year range. 
        /// For example, if TwoDigitYearMax is set to 1429, the 100-year range is from 1330 to 1429; therefore, 
        /// a 2-digit value of 30 is interpreted as 1330, while a 2-digit value of 29 is interpreted as 1429.</remarks>
        public override Int32 ToFourDigitYear(Int32 year)
        {
            if (year != 0)
            {
                try
                {
                    CheckYearRange(true, year);
                }
                catch (ArgumentOutOfRangeException)
                {
                    //throw new System.ArgumentOutOfRangeException(
                    // "Year", year, ResourceLibrary.GetString(CalendarKeys.InvalidYear, CalendarKeys.Root));
                    throw new InvalidPersianDateException(PersianLocalizeManager.GetLocalizerByCulture(
                                                              Thread.CurrentThread.CurrentUICulture).GetLocalizedString(
                                                              StringIDEnum.PersianDate_InvalidFourDigitYear));
                }
            }
            if (year > 99) return year;
            Int32 a = TwoDigitYearMax / 100;
            if (year > TwoDigitYearMax - a * 100) a--;
            return a * 100 + year;
        }

        #endregion

        #region Int32[] Eras

        /// <summary>
        /// Gets the list of eras in the PersianCalendar.
        /// </summary>
        /// <remarks>The Persian calendar recognizes one era: 
        /// A.P. (Latin "Anno Persarum", which means "the year of/for Persians").</remarks>
        public override Int32[] Eras
        {
            get
            {
                Int32[] eras = { 1 };
                return eras;
            }
        }

        #endregion

        #endregion

        #region Public Methods

        #region Int32 GetCentury(DateTime time)

        /// <summary>
        /// Gets the century of the specified DateTime.
        /// </summary>
        /// <param name="time">An instance of the DateTime class to read.</param>
        /// <returns>An integer from 1 to 94 that represents the century.</returns>
        /// <remarks>A century is a whole 100-year period. So the century 14 for example, 
        /// represents years 1301 through 1400.</remarks>
        public Int32 GetCentury(DateTime time)
        {
            return (GetYear(true, time) - 1) / 100 + 1;
        }

        #endregion

        #region Int32 NumberOfLeapYearsUntil(Int32 year)

        /// <summary>
        /// Calculates the number of leap years until -but not including- the specified year.
        /// </summary>
        /// <param name="year">An integer between 1 and 9378</param>
        /// <returns>An integer representing the number of leap years that have occured by the year specified.</returns>
        /// <remarks>In the Persian calendar leap years are applied every 4 or 5 years according to a certain pattern that 
        /// iterates in a 2820-year cycle. A common year has 365 days and a leap year has 366 days.</remarks>
        public Int32 NumberOfLeapYearsUntil(Int32 year)
        {
            return NumberOfLeapYearsUntil(true, year);
        }

        #endregion

        #endregion

        #region Private Methods

        #region Int32 GetDayOfMonth(Boolean validate, DateTime time)
        /// <summary>
        /// تعداد روزهای یك ماه را باز می گرداند
        /// </summary>
        /// <param name="validate">تعیین صحت اعتبار تاریخ وارد شده</param>
        /// <param name="time">تاریخ</param>
        /// <returns>تعداد روزهای ماه</returns>
        private Int32 GetDayOfMonth(Boolean validate, DateTime time)
        {
            Int32 days = GetDayOfYear(validate, time);
            for (Int32 i = 0; i < 6; i++)
            {
                if (days <= 31) return days;
                days -= 31;
            }
            for (Int32 i = 0; i < 5; i++)
            {
                if (days <= 30) return days;
                days -= 30;
            }
            return days;
        }
        #endregion

        #region Int32 GetDayOfYear(Boolean validate, DateTime time)
        /// <summary>
        /// تعداد روزهای موجود در یك سال را باز میگرداند
        /// </summary>
        /// <param name="validate">تعیین اعتبار سنجی تاریخ</param>
        /// <param name="time">تاریخ مورد نظر</param>
        /// <returns>تعداد روزهای موجود در سال</returns>
        private Int32 GetDayOfYear(Boolean validate, DateTime time)
        {
            Int32 year;
            Int32 days;
            GetYearAndRemainingDays(validate, time, out year, out days);
            return days;
        }
        #endregion

        #region Int32 GetDaysInMonth(Boolean validate, Int32 year, Int32 month, Int32 era)

        /// <summary>
        /// دریافت تعداد روزهای موجود در یك ماه
        /// </summary>
        /// <param name="validate">تعیین بررسی صحت اعتبار تاریخ</param>
        /// <param name="year">سال</param>
        /// <param name="month">ماه</param>
        /// <param name="era">محدوده</param>
        /// <returns>تعداد روزهای ماه</returns>
        private Int32 GetDaysInMonth(Boolean validate, Int32 year, Int32 month, Int32 era)
        {
            CheckEraRange(validate, era);
            CheckYearRange(validate, year);
            CheckMonthRange(validate, month);
            if (month < 7) return 31;
            if (month < 12) return 30;
            if (IsLeapYear(false, year, 0)) return 30;
            return 29;
        }

        #endregion

        #region Int32 GetDaysInYear(Boolean validate, Int32 year, Int32 era)

        /// <summary>
        /// دریافت تعداد روزهای سال
        /// </summary>
        /// <param name="validate"></param>
        /// <param name="year"></param>
        /// <param name="era"></param>
        /// <returns></returns>
        private Int32 GetDaysInYear(Boolean validate, Int32 year, Int32 era)
        {
            if (IsLeapYear(validate, year, era)) return 366;
            return 365;
        }

        #endregion

        #region Int32 GetMonth(Boolean validate, DateTime time)

        /// <summary>
        /// دریافت ماه یك تاریخ
        /// </summary>
        /// <param name="validate"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        private Int32 GetMonth(Boolean validate, DateTime time)
        {
            Int32 days = GetDayOfYear(validate, time);
            if (days <= 31) return 1;
            if (days <= 62) return 2;
            if (days <= 93) return 3;
            if (days <= 124) return 4;
            if (days <= 155) return 5;
            if (days <= 186) return 6;
            if (days <= 216) return 7;
            if (days <= 246) return 8;
            if (days <= 276) return 9;
            if (days <= 306) return 10;
            if (days <= 336) return 11;
            return 12;
        }

        #endregion

        #region Int32 GetYear(Boolean validate, DateTime time)
        /// <summary>
        /// دریافت سال یك تاریخ
        /// </summary>
        /// <param name="validate"></param>
        /// <param name="time">تاریخ</param>
        /// <returns>سال تاریخ</returns>
        private Int32 GetYear(Boolean validate, DateTime time)
        {
            Int32 days;
            Int32 year;
            GetYearAndRemainingDays(validate, time, out year, out days);
            return year;
        }
        #endregion

        #region static Boolean HasLeapFrac(Int32 year)
        /// <summary>
        /// بدست آوردن كبیسه بودن یك سال
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        private static Boolean HasLeapFrac(Int32 year)
        {
            //  if HasLeapFrac(year) == true And HasLeapFrac(year-1) == false
            //  then 'year' is a leap year.
            Double a = 31 * ((Double)year + 38) / 128;
            if (a - Math.Floor(a) < 0.31) return true;
            return false;
        }
        #endregion

        #region Boolean IsLeapYear(Boolean validate, Int32 year, Int32 era)
        /// <summary>
        /// تابع بدست آوردن كبیسه بودن سال
        /// </summary>
        /// <param name="validate"></param>
        /// <param name="year"></param>
        /// <param name="era"></param>
        /// <returns></returns>
        private Boolean IsLeapYear(Boolean validate, Int32 year, Int32 era)
        {
            CheckEraRange(validate, era);
            CheckYearRange(validate, year);
            if (HasLeapFrac(year) && !HasLeapFrac(year - 1))
                return true;
            return false;
        }
        #endregion

        #region Int32 NumberOfLeapYearsUntil(Boolean validate, Int32 year)

        /// <summary>
        /// 
        /// </summary>
        /// <param name="validate"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        private Int32 NumberOfLeapYearsUntil(Boolean validate, Int32 year)
        {
            CheckYearRange(validate, year);
            Int32 count = 0;
            for (Int32 i = 4; i < year; i++)
                if (IsLeapYear(false, i, 0))
                {
                    count++;
                    i += 3;
                }
            return count;
        }

        #endregion

        #region static void CheckEraRange(Boolean validate, Int32 era)

        /// <summary>
        /// 
        /// </summary>
        /// <param name="validate"></param>
        /// <param name="era"></param>
        private static void CheckEraRange(Boolean validate, Int32 era)
        {
            if (validate)
                if (era < 0 || 1 < era)
                    throw new InvalidPersianDateException(PersianLocalizeManager.GetLocalizerByCulture(
                                                              Thread.CurrentThread.CurrentUICulture).GetLocalizedString(
                                                              StringIDEnum.PersianDate_InvalidEra));
            return;
        }

        #endregion

        #region static void CheckYearRange(Boolean validate, Int32 year)

        private static void CheckYearRange(Boolean validate, Int32 year)
        {
            if (validate)
                if (year < 1 || 9378 < year)
                    throw new InvalidPersianDateException(PersianLocalizeManager.GetLocalizerByCulture(
                                                              Thread.CurrentThread.CurrentUICulture).GetLocalizedString(
                                                              StringIDEnum.PersianDate_InvalidYear));
            return;
        }

        #endregion

        #region static void CheckMonthRange(Boolean validate, Int32 month)

        /// <summary>
        /// 
        /// </summary>
        /// <param name="validate"></param>
        /// <param name="month"></param>
        private static void CheckMonthRange(Boolean validate, Int32 month)
        {
            if (validate)
                if (month < 1 || 12 < month)
                    throw new InvalidPersianDateException(PersianLocalizeManager.GetLocalizerByCulture(
                                                              Thread.CurrentThread.CurrentUICulture).GetLocalizedString(
                                                              StringIDEnum.PersianDate_InvalidMonth));
            return;
        }

        #endregion

        #region void CheckDateRange(Boolean validate, Int32 year, Int32 month, Int32 day)

        /// <summary>
        /// 
        /// </summary>
        /// <param name="validate"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        private void CheckDateRange(Boolean validate, Int32 year, Int32 month, Int32 day)
        {
            if (validate)
            {
                Int32 maxday = GetDaysInMonth(true, year, month, 0);
                if (day < 1 || maxday < day)
                    if (day == 30 && month == 12)
                        throw new InvalidPersianDateException(PersianLocalizeManager.GetLocalizerByCulture(
                                                                  Thread.CurrentThread.CurrentUICulture).
                                                                  GetLocalizedString(
                                                                  StringIDEnum.PersianDate_InvalidLeapYear));
                    else
                        throw new InvalidPersianDateException(PersianLocalizeManager.GetLocalizerByCulture(
                                                                  Thread.CurrentThread.CurrentUICulture).
                                                                  GetLocalizedString(
                                                                  StringIDEnum.PersianDate_InvalidDay));
            }
        }

        #endregion

        #region static void CheckTicksRange(Boolean validate, DateTime time)

        private static void CheckTicksRange(Boolean validate, DateTime time)
        {
            // Valid ticks represent times between 12:00:00.000 AM, 22/03/0622 CE and 11:59:59.999 PM, 31/12/9999 CE.
            if (validate)
            {
                long ticks = time.Ticks;
                if (ticks < 196037280000000000L)
                    throw new InvalidPersianDateException(PersianLocalizeManager.GetLocalizerByCulture(
                                                              Thread.CurrentThread.CurrentUICulture).GetLocalizedString(
                                                              StringIDEnum.PersianDate_InvalidDateTime));
            }
            return;
        }

        #endregion

        #region void GetYearAndRemainingDays(Boolean validate, DateTime time, out Int32 year, out Int32 days)

        /// <summary>
        /// 
        /// </summary>
        /// <param name="validate"></param>
        /// <param name="time"></param>
        /// <param name="year"></param>
        /// <param name="days"></param>
        private void GetYearAndRemainingDays(Boolean validate, DateTime time, out Int32 year, out Int32 days)
        {
            CheckTicksRange(validate, time);
            days = (time - new DateTime(196036416000000000L)).Days;
            year = 1;
            Int32 daysInNextYear = 365;
            while (days > daysInNextYear)
            {
                days -= daysInNextYear;
                year++;
                daysInNextYear = GetDaysInYear(false, year, 0);
            }
            return;
        }

        #endregion

        #endregion
    }
}