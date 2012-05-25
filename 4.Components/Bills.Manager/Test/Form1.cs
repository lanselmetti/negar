using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Sepehr;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            Negar.CSManager.CurrentSetting = "اتصال به سرور محلی";
            Negar.SecurityManager.CurrentUserID = 3;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BillPrintManager.RefBillPrintPreview(19122, 1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BillPrintManager.RefBillPrint(93396, 1, 1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<Int32> PList = new List<Int32>();
            PList.Add(119590);
            PList.Add(119591);
            BillPrintManager.RefBillPrint(PList, 3, 1, false);
        }

    }
}