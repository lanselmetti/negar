using System;

namespace Negar.PersianCalendar.Resource
{
    /// <summary>
    /// كلاس پایه تغییر زبان
    /// </summary>
    public abstract class BaseLocalizer
    {
        #region Abstract Methods

        /// <summary>
        /// متد ابستركت برای دریافت كلمه ی محلی شده
        /// </summary>
        /// <param name="ID">كد كلمه</param>
        /// <returns>مقدار كلمه</returns>
        public abstract String GetLocalizedString(StringIDEnum ID);

        #endregion
    }
}