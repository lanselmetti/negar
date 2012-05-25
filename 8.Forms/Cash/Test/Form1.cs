using System;
using System.Windows.Forms;
using Negar;
using Sepehr.Forms.Cash;

namespace Test_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CSManager.CurrentSetting = "اتصال به سرور محلی";
            SecurityManager.CurrentUserID = 25;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SecurityManager.RenewAccess();
            new frmCashesReport();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SecurityManager.RenewAccess();
            new frmCashesManage();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SecurityManager.RenewAccess();
            new frmCashPatients();
        }
    }
}
