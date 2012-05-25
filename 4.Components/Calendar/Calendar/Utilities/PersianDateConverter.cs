#region using
using System;
#endregion

namespace Negar.PersianCalendar.Utilities
{
    /// <summary>Class to convert PersianDate into normal DateTime value and vice versa.
    /// <seealso cref="PersianDate"/>
    /// </summary>
    public static class PersianDateConverter
    {
        #region Fields

        private const Int32 GYearOff = 226894;
        private const double Solar = 365.25;

        private static readonly Int32[,] gdaytable =
            new[,] { { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 }, { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 } };

        private static readonly Int32[,] jdaytable =
            new[,] { { 31, 31, 31, 31, 31, 31, 30, 30, 30, 30, 30, 29 }, { 31, 31, 31, 31, 31, 31, 30, 30, 30, 30, 30, 30 } };

        private static readonly String[] weekdays =
            new[] { "شنبه", "یکشنبه", "دوشنبه", "سه شنبه", "چهارشنبه", "پنجشنبه", "جمعه" };

        private static readonly String[] weekdaysabbr = new[] { "ش", "ی", "د", "س", "چ", "پ", "ج" };

        #endregion

        #region Properties

        #region internal static Int32[,] GDayTable

        /// <summary>
        /// Array of Day Table for Gregorian Days.
        /// </summary>
        internal static Int32[,] GDayTable
        {
            get { return gdaytable; }
        }

        #endregion

        #region internal static Int32[,] JDayTable

        /// <summary>
        /// Array of Day Table for Jalali Days.
        /// </summary>
        internal static Int32[,] JDayTable
        {
            get { return jdaytable; }
        }

        #endregion

        #region internal static String[] WeekDaysAbbr

        /// <summary>
        /// Array of WeekDay names for Persian Weekdays. This array is a collection of abbreviated weekday names. 
        /// The abbreviation name is just the first character of normal weekday names.
        /// </summary>
        internal static String[] WeekDaysAbbr
        {
            get { return weekdaysabbr; }
        }

        #endregion

        #region internal static String[] WeekDays

        internal static String[] WeekDays
        {
            get { return weekdays; }
        }

        #endregion

        #endregion

        #region Methods

        #region Public Methods

        #region static PersianDate ToPersianDate(this String date)
        /// <overloads>Has two overloads.</overloads>
        /// <summary>Converts a Gregorian Date of type <c>System.DateTime</c> class to Persian Date.</summary>
        /// <param name="date">DateTime to evaluate</param>
        /// <returns>String representation of Jalali Date</returns>
        public static PersianDate ToPersianDate(this String date)
        {
            return ToPersianDate(Convert.ToDateTime(date));
        }
        #endregion

        #region static PersianDate ToPersianDate(String date, TimeSpan time)

        /// <summary>
        /// Converts a Gregorian Date of type <c>String</c> and a <c>TimeSpan</c> into a Persian Date.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public static PersianDate ToPersianDate(String date, TimeSpan time)
        {
            PersianDate pd = ToPersianDate(date);
            pd.Hour = time.Hours;
            pd.Minute = time.Minutes;
            pd.Second = time.Seconds;

            return pd;
        }

        #endregion

        #region static PersianDate ToPersianDate(this DateTime dt)
        /// <summary>
        /// Converts a Gregorian Date of type <c>String</c> class to Persian Date.
        /// </summary>
        /// <param name="dt">Date to evaluate</param>
        /// <returns>String representation of Jalali Date.</returns>
        public static PersianDate ToPersianDate(this DateTime dt)
        {
            Int32 iCounter;

            Int32 iGYear = dt.Year;
            Int32 iGMonth = dt.Month;
            Int32 iGDay = dt.Day;

            //Calculate total days from the base of gregorian calendar
            Int32 iTotalDays = GregDays(iGYear, iGMonth, iGDay);
            iTotalDays = iTotalDays - GYearOff;

            //Calculate total jalali years passed
            Int32 iJYear = (Int32)(iTotalDays / (Solar - 0.25 / 33));
            //Calculate passed leap years
            Int32 iLeap = JLeapYears(iJYear);

            //Calculate total days from the base of jalali calendar
            Int32 iJDay = iTotalDays - (365 * iJYear + iLeap);
            //Calculate the correct year of jalali calendar
            iJYear++;

            if (iJDay == 0)
            {
                iJYear--;
                if (JLeap(iJYear) == 1) iJDay = 366;
                else iJDay = 365;
            }
            else
            {
                if ((iJDay == 366) && (JLeap(iJYear) != 1))
                {
                    iJDay = 1;
                    iJYear++;
                }
            }
            // Calculate correct month of jalali calendar
            iLeap = JLeap(iJYear);
            for (iCounter = 0; iCounter <= 12; iCounter++)
            {
                if (iJDay <= JDayTable[iLeap, iCounter]) break;
                iJDay = iJDay - JDayTable[iLeap, iCounter];
            }
            Int32 iJMonth = iCounter + 1;
            PersianCalendar PCal = new PersianCalendar();
            if (!PCal.IsLeapDay(iJYear, iJMonth, iJDay) && iJMonth == 12 && iJDay == 30) iJDay = 29;
            return new PersianDate(iJYear, iJMonth, iJDay, dt.Hour, dt.Minute, dt.Second);
        }
        #endregion

        #region static DateTime ToGregorianDateTime(this String date)

        /// <summary>
        /// Converts a Persian Date of type <c>String</c> to Gregorian Date of type <c>DateTime</c> class.
        /// </summary>
        /// <param name="date">Date to evaluate</param>
        /// <returns>Gregorian DateTime representation of evaluated Jalali Date.</returns>
        public static DateTime ToGregorianDateTime(this String date)
        {
            var pd = new PersianDate(date);
            return Convert.ToDateTime(ToGregorianDate(pd));
        }

        #endregion

        #region static DateTime ToGregorianDateTime(this PersianDate date)
        public static DateTime ToGregorianDateTime(this PersianDate date)
        {
            return Convert.ToDateTime(ToGregorianDate(date));
        }
        #endregion

        #region static String ToGregorianDate(this PersianDate date)
        /// <summary>
        /// Converts a Persian Date of type <c>String</c> to Gregorian Date of type <c>String</c>.
        /// </summary>
        /// <param name="date"></param>
        /// <returns>Gregorian DateTime representation in String format of evaluated Jalali Date.</returns>
        public static String ToGregorianDate(this PersianDate date)
        {
            Int32 iJYear = date.Year;
            Int32 iJMonth = date.Month;
            Int32 iJDay = date.Day;

            Int32 iTotalDays = JalaliDays(iJYear, iJMonth, iJDay);
            iTotalDays = iTotalDays + GYearOff;
            Int32 iGYear = (Int32)(iTotalDays / (Solar - 0.25 / 33));

            Int32 Div4 = iGYear / 4;
            Int32 Div100 = iGYear / 100;
            Int32 Div400 = iGYear / 400;

            Int32 iGDays = iTotalDays - (365 * iGYear) - (Div4 - Div100 + Div400);
            iGYear = iGYear + 1;
            // =============================================
            if (iGDays == 0)
            {
                iGYear--;
                if (GLeap(iGYear) == 1) iGDays = 366;
                else iGDays = 365;
            }
            else if (iGDays == 366 && GLeap(iGYear) != 1)
            {
                iGDays = 1;
                iGYear++;
            }
            // =============================================
            Int32 leap = GLeap(iGYear);
            Int32 i;
            for (i = 0; i <= 12; i++)
            {
                if (iGDays <= GDayTable[leap, i]) break;
                iGDays = iGDays - GDayTable[leap, i];
            }
            // =============================================
            Int32 iGMonth = i + 1;
            Int32 iGDay = iGDays;
            return (iGYear + "/" + toDouble(iGMonth) + "/" + toDouble(iGDay) + " " +
                       toDouble(date.Hour) + ":" + toDouble(date.Minute) + ":" + toDouble(date.Second));
        }
        #endregion

        #endregion

        #region Private Methods

        #region static Int32 JLeap(Int32 iJYear)

        /// <summary>
        /// Checks if a specified Persian year is a leap one.
        /// </summary>
        /// <param name="iJYear"></param>
        /// <returns>returns 1 if the year is leap, otherwise returns 0.</returns>
        private static Int32 JLeap(Int32 iJYear)
        {
            //Is jalali year a leap year?
            Int32 tmp;
            Math.DivRem(iJYear, 33, out tmp);
            if ((tmp == 1) || (tmp == 5) || (tmp == 9) || (tmp == 13) ||
                (tmp == 17) || (tmp == 22) || (tmp == 26) || (tmp == 30))
                return 1;
            return 0;
        }

        #endregion

        #region static Int32 GLeap(Int32 GregYear)

        /// <summary>
        /// Checks if a specified Gregorian year is a leap one.
        /// </summary>
        /// <param name="GregYear"></param>
        /// <returns>returns 1 if the year is leap, otherwise returns 0.</returns>
        private static Int32 GLeap(Int32 GregYear)
        {
            //Is gregorian year a leap year?
            Int32 Mod4, Mod100, Mod400;
            Math.DivRem(GregYear, 4, out Mod4);
            Math.DivRem(GregYear, 100, out Mod100);
            Math.DivRem(GregYear, 400, out Mod400);
            if (((Mod4 == 0) && (Mod100 != 0)) || (Mod400 == 0))
                return 1;
            return 0;
        }

        #endregion

        #region static Int32 GregDays(Int32 iGYear, Int32 iGMonth, Int32 iGDay)

        private static Int32 GregDays(Int32 iGYear, Int32 iGMonth, Int32 iGDay)
        {
            //Calculate total days of gregorian from calendar base
            Int32 Div4 = (iGYear - 1) / 4;
            Int32 Div100 = (iGYear - 1) / 100;
            Int32 Div400 = (iGYear - 1) / 400;
            Int32 iLeap = GLeap(iGYear);
            for (Int32 iCounter = 0; iCounter < iGMonth - 1; iCounter++)
                iGDay = iGDay + GDayTable[iLeap, iCounter];
            return ((iGYear - 1) * 365 + iGDay + Div4 - Div100 + Div400);
        }

        #endregion

        #region static Int32 JLeapYears(Int32 iJYear)
        private static Int32 JLeapYears(Int32 iJYear)
        {
            Int32 iCounter;
            Int32 Div33 = iJYear / 33;
            Int32 iCurrentCycle = iJYear - (Div33 * 33);
            Int32 iLeap = (Div33 * 8);
            if (iCurrentCycle > 0)
                for (iCounter = 1; iCounter <= 18; iCounter = iCounter + 4)
                {
                    if (iCounter > iCurrentCycle)
                        break;
                    iLeap++;
                }
            if (iCurrentCycle > 21)
                for (iCounter = 22; iCounter <= 31; iCounter = iCounter + 4)
                {
                    if (iCounter > iCurrentCycle)
                        break;
                    iLeap++;
                }
            return iLeap;
        }
        #endregion

        #region static String toDouble(Int32 i)

        /// <summary>
        /// Adds to single day or months a preceding zero
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private static String toDouble(Int32 i)
        {
            if (i > 9)
            {
                return i.ToString();
            }
            return "0" + i;
        }

        #endregion

        #endregion

        #region Internal Methods

        #region static Int32 JalaliDays(Int32 iJYear, Int32 iJMonth, Int32 iJDay)

        internal static Int32 JalaliDays(Int32 iJYear, Int32 iJMonth, Int32 iJDay)
        {
            //Calculate total days of jalali years from the base calendar
            Int32 iLeap = JLeap(iJYear);
            for (Int32 i = 0; i < iJMonth - 1; i++)
                iJDay = iJDay + JDayTable[iLeap, i];
            iLeap = JLeapYears(iJYear - 1);
            Int32 iTotalDays = ((iJYear - 1) * 365 + iLeap + iJDay);
            return iTotalDays;
        }

        #endregion

        #region static String DayOfWeek(PersianDate date)

        internal static String DayOfWeek(PersianDate date)
        {
            if (!date.IsNull)
            {
                DateTime dt = ToGregorianDateTime(date);
                return DayOfWeek(dt);
            }
            return String.Empty;
        }

        #endregion

        #region static String DayOfWeek(DateTime date)

        /// <summary>
        /// Gets Persian Weekday name from specified Gregorian Date.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        internal static String DayOfWeek(DateTime date)
        {
            String DayOfWeek = date.DayOfWeek.ToString().ToLower();
            String day;
            switch (DayOfWeek)
            {
                case "saturday":
                    day = PersianDate.PersianWeekDayNames.Default.Shanbeh;
                    break;
                case "sunday":
                    day = PersianDate.PersianWeekDayNames.Default.Yekshanbeh;
                    break;
                case "monday":
                    day = PersianDate.PersianWeekDayNames.Default.Doshanbeh;
                    break;
                case "tuesday":
                    day = PersianDate.PersianWeekDayNames.Default.Seshanbeh;
                    break;
                case "wednesday":
                    day = PersianDate.PersianWeekDayNames.Default.Chaharshanbeh;
                    break;
                case "thursday":
                    day = PersianDate.PersianWeekDayNames.Default.Panjshanbeh;
                    break;
                case "friday":
                    day = PersianDate.PersianWeekDayNames.Default.Jomeh;
                    break;
                default:
                    day = String.Empty;
                    break;
            }
            return (day);
        }

        #endregion

        #region static Int32 MonthDays(Int32 MonthNo)

        /// <summary>
        /// Returns number of days in specified month number.
        /// </summary>
        /// <param name="MonthNo">Month no to evaluate in integer</param>
        /// <returns>number of days in the evaluated month</returns>
        internal static Int32 MonthDays(Int32 MonthNo)
        {
            return (JDayTable[1, MonthNo - 1]);
        }

        #endregion

        #endregion

        #endregion
    }
}