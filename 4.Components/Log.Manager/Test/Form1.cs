using System;
using System.Diagnostics;
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
            LogManager.SaveLogEntry("Sepehr" , "Main Project", "Test Text" , EventLogEntryType.Error);
        }

    }
}