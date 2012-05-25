using System;
using System.Windows.Forms;
using Negar;
using Sepehr.Settings.Referrals;

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
            new frmStatus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new frmPerformers();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new frmPhysiciansSpecs();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new frmPhysicians();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new frmAdditionalCols();
        }
        
    }
}
