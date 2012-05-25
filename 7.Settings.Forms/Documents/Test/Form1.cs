using System;
using System.Windows.Forms;
using Negar;

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
            new Sepehr.Settings.Documents.frmDocTemplates();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Sepehr.Settings.Documents.frmDocTypes();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Sepehr.Settings.Documents.frmDocTexts();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
    }
}
