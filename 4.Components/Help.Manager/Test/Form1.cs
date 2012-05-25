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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new HelpViewer(@"C:\Projects\Negar\4.Components\Help.Manager\Test\bin\Debug\Help Template File\Template.htm");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String X = ToolTipManager.GetText("btnHelp" , "IMS");
            MessageBox.Show(X);
        }
    }
}
