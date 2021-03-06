using System;

namespace Negar.PersianCalendar.Utilities
{
    /// <summary>
    /// مجموعه ابزارهای فارسی
    /// </summary>
    internal static class PersianUtilities
    {
        #region Methods

        #region internal static System.String ConvertToDuplex(Int32 Num)

        /// <summary>
        /// تبدیل عدد یك رقمی به عدد دو رقمی با صفر
        /// </summary>
        /// <param name="Num">عدد ماه یا روز</param>
        /// <returns></returns>
        internal static String ConvertToDuplex(Int32 Num)
        {
            if (Num > 9) return Num.ToString();
            return "0" + Num;
        }

        #endregion

        #endregion
    }
}