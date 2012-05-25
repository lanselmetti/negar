#region using
using System;
using System.Windows.Forms;
using Negar.Forms;
#endregion

namespace Negar
{
    /// <summary>
    /// سیستم نصب نرم افزار مدیریت تصویربرداری سپهر
    /// </summary>
    static class Program
    {
        /// <summary>
        /// تابع ورودی نرم افزار
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                // ReSharper disable AssignNullToNotNullAttribute
                //WindowsPrincipal SecurityData = new WindowsPrincipal(WindowsIdentity.GetCurrent());
                // ReSharper restore AssignNullToNotNullAttribute
                //if (!SecurityData.IsInRole(WindowsBuiltInRole.Administrator))
                //{
                //    PMBox.Show("كاربر جاری دارای دسترسی مدیریت (Administrator) نمی باشد!\n" +
                //        "لطفاً ابتدا با كاربری دارای این سطح دسترسی وارد ویندوز شوید.", "خطا! محدودیت دسترسی.",
                //        MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    Application.Exit();
                //    return;
                //}
                Application.Run(new frmMain());
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "خطا در اجرای برنامه.\n" + "آیا مایلید متن خطا را مشاهده نمایید؟";
                DialogResult Dr = PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                if (Dr == DialogResult.Yes) MessageBox.Show(Ex.Message, "متن خطای به وقوع پیوسته.",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
            #endregion
        }
    }
}