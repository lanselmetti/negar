using System;
using System.Windows.Forms;
using Negar;
using Sepehr.Forms.Schedules;

namespace Test_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CSManager.CurrentSetting = "اتصال به سرور محلی";
            //CSManager.CurrentSetting = "اتصال به سرور دارالشفاء";
            SecurityManager.CurrentUserID = 3;
            SecurityManager.CurrentApplicationID = 500;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new frmAppointments();
            Activate();
            BringToFront();
            Focus();
        }
        
    }
}