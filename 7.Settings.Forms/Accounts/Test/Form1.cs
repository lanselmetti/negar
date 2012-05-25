using System;
using System.Windows.Forms;
using Negar;
using Sepehr.Settings.Accounts;

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
            new frmBanks();
            Select();
            Focus();
            BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new frmCostDiscountTypes();
            Select();
            Focus();
            BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new frmCostDiscountUsersExclude();
            Select();
            Focus();
            BringToFront();
        }
    }
}