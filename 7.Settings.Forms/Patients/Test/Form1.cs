using System;
using System.Windows.Forms;
using Negar;
using Sepehr.Settings.Patients;

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
            new frmPatientsName();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new frmPatientsJob();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new frmCountries();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new frmStates();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new frmCities();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new frmAdditionalCols();
        }
    }
}
