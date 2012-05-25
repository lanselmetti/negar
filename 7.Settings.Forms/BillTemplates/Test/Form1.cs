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
            SecurityManager.CurrentUserID = 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Sepehr.Settings.BillTemplates.frmBillTemplates();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Sepehr.Settings.BillTemplates.frmBillUserAccess();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Sepehr.Settings.BillTemplates.frmBillServiceGroupsExclude();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Sepehr.Settings.BillTemplates.frmBillDefaultPrinter();
        }
        
    }
}
