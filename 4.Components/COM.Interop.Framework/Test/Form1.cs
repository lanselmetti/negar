using System;
using System.Windows.Forms;

namespace Test_Projects
{
    public partial class Form1 : Form
    {
        private Form2 _MyForm;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_MyForm == null)
                _MyForm = new Form2();
            _MyForm.ShowDialog();
        }

    }
}
