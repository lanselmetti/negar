#region using
using System;
using System.Windows.Forms;
#endregion

namespace Negar
{
    /// <summary>
    /// سیستم مدیریت نرم افزارهای كلینیكی نگار
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
                Application.SetCompatibleTextRenderingDefault(true);
                #region Check For Single Instance - Disabled
                //System.Diagnostics.Process[] SameProccessList = 
                //    System.Diagnostics.Process.GetProcessesByName(System.Diagnostics.Process.GetCurrentProcess().ProcessName);
                //if (SameProccessList.Length > 1)
                //{
                //    PMBox.Show("برنامه مشابهی در حال حاضر باز می باشد!\nلطفاً ابتدا برنامه فوق را ببندید!", "محدودیت فراخوانی!",
                //        MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    Application.Exit();
                //    return;
                //}
                #endregion
                Application.Run(new frmMain());
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "خطا در اجرای برنامه.\n" + "آیا مایلید متن خطا را مشاهده نمایید؟";
                DialogResult Dr = PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.YesNo, MessageBoxIcon.Error , 
                    MessageBoxDefaultButton.Button1);
                if (Dr == DialogResult.Yes) MessageBox.Show(Ex.Message , "متن خطای به وقوع پیوسته." , 
                        MessageBoxButtons.OK , MessageBoxIcon.Information);
                Application.Exit();
            }
            #endregion
        }
    }
}