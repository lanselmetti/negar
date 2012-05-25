using System;
using System.Windows.Forms;
using Negar;
using Sepehr.Settings.SMS;

namespace Test_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CSManager.CurrentSetting = "اتصال به سرور محلی";
            SecurityManager.CurrentApplicationID = 500;
            SecurityManager.CurrentUserID = 3;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new frmDocCompleteMessage();
        }

    }
}
