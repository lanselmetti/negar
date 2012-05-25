using System;

namespace Negar.PersianCalendar.Utilities.Exceptions
{
    /// <summary>
    /// مدیریت خطای تاریخ فارسی
    /// </summary>
    public class InvalidPersianDateException : Exception
    {
        #region Ctors

        #region public InvalidPersianDateException()

        /// <summary>
        /// سازنده پیش فرض
        /// </summary>
        public InvalidPersianDateException()
        {
        }

        #endregion

        #region public InvalidPersianDateException(String message) : base(message)

        /// <summary>
        /// سازنده با دریافت پیغام خطا
        /// </summary>
        /// <param name="Message">پیام خطا</param>
        public InvalidPersianDateException(String Message) : base(Message)
        {
        }

        #endregion

        #endregion
    }
}