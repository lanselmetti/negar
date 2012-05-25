#region using
using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Negar;
using Negar.DBLayerPMS.DataLayer;
using Sepehr.Forms;

#endregion

namespace Sepehr
{
    /// <summary>
    /// كلاس اجرایی آغاز برنامه
    /// </summary>
    static class StartUpClass
    {
        /// <summary>
        /// تابع اصلی اجرایی برنامه
        /// </summary>
        [STAThread]
        static void Main(String[] Arguments)
        {
            #region Testing Block
            //if (Arguments.Length == 0)
            //{
            //    Arguments = new String[5];
            //    Arguments[0] = "3"; // كلید كاربر جاری
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
                Application.Exit();
                return;
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

            #region Check Db Version
            try
            {
                HISApplication DbDate = Negar.DBLayerPMS.Manager.DBML.HISApplications.Where(Data => Data.ID == 500).First();
                String DbBaseVersion = DbDate.DbVersion;
                for (Int32 i = 0; i < DbBaseVersion.Length; i++)
                    if (DbBaseVersion[i] == '.')
                    {
                        DbBaseVersion = DbBaseVersion.Substring(0, i);
                        break;
                    }
                if (Convert.ToInt32(DbBaseVersion) != Assembly.GetExecutingAssembly().GetName().Version.Major)
                {
                    PMBox.Show("نسخه ی بانك نصب شده بر روی سرور یا برنامه جاری هماهنگ نیست!\n" +
                        "لطفاً نسخه ای هماهنگ با نسخه برنامه را فراخوانی نمایید.\n" +
                        "نسخه بانك اطلاعاتی: " + DbDate.DbVersion +
                        "\nنسخه برنامه: " + Assembly.GetExecutingAssembly().GetName().Version);
                    Application.Exit();
                    return;
                }
            }
            #region Catch
            catch (Exception)
            {
                const String ErrorMessage =
                    "امكان خواندن اطلاعات بانك اطلاعاتی تصویربرداری ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟\n" +
                    "2. آیا قفل سخت افزاری متصل بوده و سالم است؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }
            #endregion
            #endregion

            #region Check Current System DateTime
            if (Negar.DBLayerPMS.Manager.ServerCurrentDateTime == null ||
                Negar.DBLayerPMS.Manager.ServerCurrentDateTime.Value.Date != DateTime.Now.Date)
                PMBox.Show("تاریخ سیستم جاری با تاریخ تنظیم شده در سرور هماهنگ نیست!\n" +
                    "لطفاً قبل از استفاده حتماً این موضوع را بررسی نمایید.", "هشدار! هشدار!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            #endregion

            #region Call Application
            // برای ویندوز XP
            if (Environment.OSVersion.Version.Major == 5)
            {
                Application.Run(new frmSepehrMainForm());
                //try { Application.Run(new StartupForm()); }
                //catch (Exception Ex)
                //{
                //    PMBox.Show("خطایی در اجرای برنامه به وقوع پیوسته است. لطفاً برای اصلاح خطا با شركت تماس بگیرید.", "خطا!",
                //        MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    LogManager.SaveLogEntry("Sepehr", "Main Project", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                //    Application.Exit();
                //    return;
                //}
            }
            else Application.Run(new frmSepehrMainForm());
            #endregion

        }
    }
}