#region using
using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Negar;
#endregion

namespace Negar
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(String[] Arguments)
        {
            #region Testing Block
            //if (Arguments.Length == 0)
            //{
            //    Arguments = new String[5];
            //    Arguments[0] = "2"; // كلید كاربر جاری
            //    Arguments[1] = "اتصال";
            //    Arguments[2] = "به";
            //    Arguments[3] = "سرور";
            //    Arguments[4] = "محلی";
            //}
            #endregion

            #region Change Application Culture And Settings
            // تغییر فرهنگ برنامه جاری به فارسی
            Application.CurrentCulture = new CultureInfo("Fa-Ir");
            //Application.CurrentCulture.DateTimeFormat.FirstDayOfWeek = DayOfWeek.Saturday;
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("Fa-Ir"));
            Application.SetCompatibleTextRenderingDefault(false);
            Application.EnableVisualStyles();
            #endregion

            #region Check Application Call Method
            if (Arguments.Count() == 0)
            {
                PMBox.Show("سیستم مدیریت تصویربرداری به درستی فراخوانی نشده!\n" +
                    "لطفاً برنامه را از طریق سیستم مدیریت آرش فراخوانی نمایید!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit(); return;
            }
            #endregion

            #region Beta Expiration Date
            //if (DateTime.Now > new DateTime(2010, 5, 1))
            //{
            //    PMBox.Show("مدت زمان آزمایشی استفاده از این نرم افزار به پایان رسیده است!", "خطا!",
            //        MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    Application.Exit();
            //    return;
            //}
            #endregion

            #region Set Security Data
            SecurityManager.CurrentUserID = Convert.ToInt16(Arguments[0]);
            SecurityManager.CurrentApplicationID = 500;
            String CurrentSettingName = String.Empty;
            for (Int32 i = 1; i < Arguments.Count(); i++)
            {
                if (i == 1) CurrentSettingName = Arguments[i];
                else CurrentSettingName = CurrentSettingName + " " + Arguments[i];
            }
            CSManager.CurrentSetting = CurrentSettingName;
            #endregion

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}