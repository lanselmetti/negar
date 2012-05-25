using System;
using System.Windows.Forms;

namespace Test_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Negar.PMBox.Show("متن", "تیتر", MessageBoxButtons.YesNoCancel, 
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        }

    }
}
