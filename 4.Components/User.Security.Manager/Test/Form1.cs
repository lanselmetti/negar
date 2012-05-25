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
            SecurityManager.CurrentApplicationID = 500;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(SecurityManager.GetCurrentUserPermission(52).ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
