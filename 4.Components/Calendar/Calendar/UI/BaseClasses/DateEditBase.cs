#region using
using System;
using System.ComponentModel;
#endregion

namespace Negar.PersianCalendar.UI.BaseClasses
{
    /// <summary>
    /// این كلاس ، كلاس پایه برای كنترل هایی است كه قابلیت ویرایش دارند
    /// </summary>
    [ToolboxItem(false)]
    public class DateEditBase : TextEditBase
    {

        #region Fields
        /// <summary>
        /// فرمت نمایش تقویم
        /// </summary>
        private FormatInfoTypes _Format;
        #endregion

        #region Properties

        #region public FormatInfoTypes FormatInfo
        /// <summary>
        /// تعیین فرمت نمایش تاریخ در تقویم
        /// </summary>
        [Description("تعیین فرمت نمایش تاریخ در تقویم.")]
        [DefaultValue(typeof (FormatInfoTypes), "ShortDate")]
        [Browsable(false)]
        public FormatInfoTypes FormatInfo
        {
            get { return _Format; }
            set
            {
                if (value != FormatInfoTypes.ShortDate)
                    value = FormatInfoTypes.ShortDate;
                if (_Format == value) return;
                _Format = value;
                UpdateTextValue();
            }
        }
        #endregion

        #endregion

        #region Methods

        #region public virtual void UpdateTextValue()
        /// <summary>
        /// تابع به روز رسانی متن كنترل
        /// </summary>
        public virtual void UpdateTextValue()
        {
        }
        #endregion

        #region protected internal static String GetFormatByFormatInfo(FormatInfoTypes TheFormayInfo)
        /// <summary>
        /// بازگرداندن تاریخ بر اساس نوع درخواستی
        /// </summary>
        /// <param name="TheFormayInfo">نوع فرمت</param>
        /// <returns>متن فرمت شده تاریخ</returns>
        protected internal static String GetFormatByFormatInfo(FormatInfoTypes TheFormayInfo)
        {
            switch (TheFormayInfo)
            {
                case FormatInfoTypes.DateShortTime: return "g";
                case FormatInfoTypes.FullDateTime: return "G";
                default: return "d";
            }
        }
        #endregion

        #endregion

    }
}