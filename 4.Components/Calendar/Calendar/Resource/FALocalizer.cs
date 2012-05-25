#region using

using System;

#endregion

namespace Negar.PersianCalendar.Resource
{
    /// <summary>
    /// كلاس مدیریت كلمات محلی فارسی
    /// </summary>
    public class FALocalizer : BaseLocalizer
    {
        /// <summary>
        /// تابع ارائه لغات محلی فارسی بر اساس كلید دریافتی
        /// </summary>
        /// <param name="ID">كلید لغت</param>
        /// <returns>لغت فارسی</returns>
        public override String GetLocalizedString(StringIDEnum ID)
        {
            switch (ID)
            {
                case StringIDEnum.Empty: return String.Empty;

                #region Numbers
                case StringIDEnum.Numbers_0: return "۰";
                case StringIDEnum.Numbers_1: return "۱";
                case StringIDEnum.Numbers_2: return "۲";
                case StringIDEnum.Numbers_3: return "۳";
                case StringIDEnum.Numbers_4: return "۴";
                case StringIDEnum.Numbers_5: return "۵";
                case StringIDEnum.Numbers_6: return "۶";
                case StringIDEnum.Numbers_7: return "۷";
                case StringIDEnum.Numbers_8: return "۸";
                case StringIDEnum.Numbers_9: return "۹";
                #endregion

                #region Month Calendar Texts

                case StringIDEnum.FADateTextBox_Required:
                    return "فیلد اجباری میباشد";
                case StringIDEnum.FAMonthView_None:
                    return "خالی";
                case StringIDEnum.FAMonthView_Today:
                    return "امروز";

                #endregion

                #region Exceptions Texts

                case StringIDEnum.PersianDate_InvalidDateFormat:
                    return "ساختار تاریخ مجاز نمی باشد.";
                case StringIDEnum.PersianDate_InvalidDateTime:
                    return "مقدار زمان/ساعت صحیح نمی باشد.";
                case StringIDEnum.PersianDate_InvalidDateTimeLength:
                    return "متن وارد شده برای زمان/ساعت صحیح نمی باشد.";
                case StringIDEnum.PersianDate_InvalidDay:
                    return "مقدار روز صحیح نمیباشد.";
                case StringIDEnum.PersianDate_InvalidEra:
                    return "محدوده وارد شده صحیح نمیباشد.";
                case StringIDEnum.PersianDate_InvalidFourDigitYear:
                    return "مقدار وارد شده را نمیتوان به سال تبدیل کرد.";
                case StringIDEnum.PersianDate_InvalidHour:
                    return "مقدار ساعت صحیح نمیباشد.";
                case StringIDEnum.PersianDate_InvalidLeapYear:
                    return "این سال ، سال کبیسه نیست. مقدار روز صحیح نمیباشد.";
                case StringIDEnum.PersianDate_InvalidMinute:
                    return "مقدار دقیقه صحیح نمیباشد.";
                case StringIDEnum.PersianDate_InvalidMonth:
                    return "مقدار ماه صحیح نمیباشد.";
                case StringIDEnum.PersianDate_InvalidMonthDay:
                    return "مقدار ماه/روز صحیح نمیباشد.";
                case StringIDEnum.PersianDate_InvalidSecond:
                    return "مقدار ثانیه صحیح نمیباشد.";
                case StringIDEnum.PersianDate_InvalidTimeFormat:
                    return "ساختار زمان صحیح نمیباشد.";
                case StringIDEnum.PersianDate_InvalidYear:
                    return "مقدار سال صحیح نمیباشد.";

                case StringIDEnum.Validation_Cancel:
                    return "مقدار انتخاب شده مجاز نمیباشد.";
                case StringIDEnum.Validation_NotValid:
                    return "مقدار انتخاب شده در محدوده مجاز نمیباشد.";
                case StringIDEnum.Validation_Required:
                    return "انتخاب اجباری. لطفا مقداری برای این فیلد وارد کنید.";
                case StringIDEnum.Validation_NullText:
                    return "    /  /";

                #endregion

                #region MessageBox Texts

                case StringIDEnum.MessageBox_Ok:
                    return "قبول";
                case StringIDEnum.MessageBox_Cancel:
                    return "لغو";
                case StringIDEnum.MessageBox_Abort:
                    return "لغو";
                case StringIDEnum.MessageBox_Ignore:
                    return "ادامه عملیات";
                case StringIDEnum.MessageBox_Retry:
                    return "سعی مجدد";
                case StringIDEnum.MessageBox_No:
                    return "خیر";
                case StringIDEnum.MessageBox_Yes:
                    return "بله";

                #endregion
            }
            return String.Empty;
        }
    }
}