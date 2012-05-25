using System;

namespace Negar.PersianCalendar.Utilities.Exceptions
{
    /// <summary>
    /// خطای فرمت اشتباه تاریخ فارسی
    /// </summary>
    public class InvalidPersianDateFormatException : Exception
    {
        #region Ctors

        #region public InvalidPersianDateException()

        /// <summary>
        /// سازنده پیش فرض
        /// </summary>
        public InvalidPersianDateFormatException()
        {
        }

        #endregion

        #region public InvalidPersianDateException(String Message) : base(Message)

        /// <summary>
        /// سازنده با دریافت پیغام خطا
        /// </summary>
        /// <param name="Message">پیام خطا</param>
        public InvalidPersianDateFormatException(String Message) : base(Message)
        {
        }

        #endregion

        #endregion
    }
}