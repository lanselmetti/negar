#region using
using System;
using System.Globalization;
using System.Windows.Forms;
using Negar;
using Sepehr.Forms;
using System.Linq;
#endregion

namespace Sepehr
{
    static class Program
    {
        #region void Main(String[] Arguments)
        /// <summary>
        /// تابع اصلی اجرایی برنامه
        /// </summary>
        [STAThread]
        static void Main(String[] Arguments)
        {
            #region Testing Block
            //if (Arguments.Length == 0)
            //{
            //    Arguments = new string[5];
            //    Arguments[0] = "1";
            //    Arguments[1] = "اتصال";
            //    Arguments[2] = "به";
            //    Arguments[3] = "سرور";
            //    Arguments[4] = "محلی";
            //}
            #endregion

            // تغییر فرهنگ برنامه جاری به فارسی
            Application.CurrentCulture = new CultureInfo("Fa-Ir");
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("Fa-Ir"));
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            #region Check Current Lock
            if (!LicenseHelper.GetSavedLicenses().Contains("591"))
            {
                PMBox.Show("قفل سخت افزاری متصل شده ، \n" + "مجوز استفاده از برنامه دیسكت جاری را ندارد!",
                    "محدودیت دسترسی!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Application.Exit();
                return;
            }
            #endregion

            #region Beta Expiration
            //if (DateTime.Now.Year > 2010)
            //{
            //    PMBox.Show("مدت زمان آزمایشی استفاده از این نرم افزار به پایان رسیده است!", "خطا!",
            //        MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    Application.Exit();
            //    return;
            //}
            #endregion

            #region Check Application Call Method
            if (Arguments.Count() == 0)
            {
                PMBox.Show("سیستم تولید فایل دیسكت به درستی فراخوانی نشده!\n" +
                    "لطفاً برنامه را از طریق سیستم مدیریت آرش فراخوانی نمایید!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }
            #endregion

            #region Set Security Data
            String CurrentSettingName = String.Empty;
            for (Int32 i = 1; i < Arguments.Count(); i++)
            {
                if (i == 1) CurrentSettingName = Arguments[i];
                else CurrentSettingName = CurrentSettingName + " " + Arguments[i];
            }
            CSManager.CurrentSetting = CurrentSettingName;
            #endregion

            try
            {
                frmMainForm MyForm = new frmMainForm();
                if (!MyForm.IsDisposed) MyForm.ShowDialog();
            }
            catch (Exception Ex) { MessageBox.Show(Ex.Message); }
            finally { Application.Exit(); }
        }
        #endregion
    }
}