using System;
using System.Windows.Forms;
using Negar;
using Sepehr.Forms.Account;

namespace Test_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CSManager.CurrentSetting = "اتصال به سرور محلی";
            SecurityManager.CurrentUserID = 3;
            BringToFront();
            Focus();
        }

        private void Account_Click(object sender, EventArgs e)
        {
            SecurityManager.RenewAccess();
            Int32 PatientListID = Convert.ToInt32(txt1.Text);
            new frmAccount(PatientListID, true);
            BringToFront();
            Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SecurityManager.RenewAccess();
            Int32 RefID = Convert.ToInt32(txt2.Text);
            new frmAccount(RefID, false);
            BringToFront();
            Focus();
        }
    }
}
