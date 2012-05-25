using System;
using System.Windows.Forms;
using Negar;
using Sepehr.Settings.Services;

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
            new frmCategories();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new frmServices();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new frmGroups();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new frmServicesGrouping();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new frmDefaultPerformers();
        }

    }
}
