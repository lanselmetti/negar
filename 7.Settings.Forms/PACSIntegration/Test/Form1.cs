using System;
using System.Windows.Forms;
using Negar;
using Sepehr.Settings.PACSIntegration;

namespace Test_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CSManager.CurrentSetting = "اتصال به سرور محلی";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new frmModalities();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new frmStudies();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new frmModalitiesServicesGrouping();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new frmStudiesServicesGrouping();
        }
    }
}