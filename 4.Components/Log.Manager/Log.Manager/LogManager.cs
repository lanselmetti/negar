#region using
using System;
using System.Diagnostics;
using System.Windows.Forms;

#endregion

namespace Negar
{
    /// <summary>
    /// كلاس مدیریت و ثبت رخداد های برنامه در ویندوز
    /// </summary>
    public static class LogManager
    {
        /// <summary>
        /// تابع ثبت رخداد در ماشین جاری
        /// </summary>
        /// <param name="Source">نام نرم افزار یا زیر سیستمی كه منجر به رخداد شده است</param>
        /// <param name="Categories">طبقه بندی رخداد</param>
        /// <param name="EventText">متن رخداد</param>
        /// <param name="EventType">نوع رخداد</param>
        public static void SaveLogEntry(String Source, String Categories, String EventText, EventLogEntryType EventType)
        {
            String CompleteSource = Source + " - " + Categories;
            using (EventLog FormLog = new EventLog("Application"))
            {
                try
                {
                    FormLog.Source = CompleteSource;
                    FormLog.WriteEntry("== رخداد در سیستم مدیریت پزشكی رایان پرتونگار ==\n" + EventText, EventType);
                }
                catch (Exception)
                {
                    try
                    {
                        FormLog.Source = "EventSystem";
                        FormLog.WriteEntry(CompleteSource +
                            "\n== رخداد در سیستم مدیریت پزشكی رایان پرتونگار ==\n" + EventText, EventType);
                    }
                    catch (Exception Ex)
                    {
                        DialogResult Result = PMBox.Show("خطا در ثبت رخداد انتخاب شده در ویندوز!\nآیا مایلید متن خطا را مشاهده نمایید؟",
                            "خطا!", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                        if (Result == DialogResult.Yes)
                            MessageBox.Show(Ex.Message, "Negar Error Message!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}