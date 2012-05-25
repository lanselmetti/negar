using System;
using System.Windows.Forms;
using Negar;
using Sepehr.Settings.Cash;

namespace Test_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CSManager.CurrentSetting = "اتصال به سرور محلی";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new frmCashes();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new frmCashCashiers();
        }
       
    }
}
