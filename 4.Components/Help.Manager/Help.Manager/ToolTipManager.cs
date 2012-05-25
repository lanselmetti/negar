using System;

namespace Negar
{
    /// <summary>
    /// كلاس مدیریت لیست متن راهنمای های كنترل ها
    /// </summary>
    public static class ToolTipManager
    {
        /// <summary>
        /// تابع بازگرداندن یك متن ذخیره شده
        /// </summary>
        /// <param name="Name">كلید ردیف</param>
        /// <param name="SubSystemName">نام سیستم مدیریت مورد نظر</param>
        /// <returns>متن راهنما</returns>
        public static String GetText(String Name, String SubSystemName)
        {
            if (SubSystemName == "IMS")
                return IMSTooltipsResource.ResourceManager.GetString(Name);
            if (SubSystemName == "CMS")
                return IMSTooltipsResource.ResourceManager.GetString(Name);
            return "خطا";
        }
    }
}