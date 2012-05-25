using System;
using System.Windows.Forms;

namespace Test_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Negar.CSManager.CurrentSetting = "اتصال به سرور محلی";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Sepehr.SMSSender.frmDashboard();
        }
    }
}
