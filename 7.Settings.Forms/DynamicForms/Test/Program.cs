using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Test_Project;

namespace Tester
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainForm frmMain = new MainForm();
            Application.Run(frmMain);
            frmMain.Dispose();
            frmMain = null;
        }
    }
}
