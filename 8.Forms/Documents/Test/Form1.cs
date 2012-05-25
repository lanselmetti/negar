#region using
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Negar;
using Sepehr.Forms.Documents;
using Sepehr.Forms.Documents.Classes;

#endregion

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CSManager.CurrentSetting = "اتصال به سرور محلی";
            SecurityManager.CurrentUserID = 3;
            //foreach (System.Diagnostics.Process Word in System.Diagnostics.Process.GetProcessesByName("WINWORD")) Word.Kill();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Int32 PatientListID = Convert.ToInt32(txt1.Text);
            new frmDocuments(PatientListID, true);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Int32 RefID = Convert.ToInt32(txt2.Text);
            new frmDocuments(RefID, false);
        }

        private void ManageDocument_Click(object sender, EventArgs e)
        {
            Int32 RefID = Convert.ToInt32(txt3.Text);
            DocumentHelper.AddNewDocument(RefID);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Int32 DocID = Convert.ToInt32(textBox1.Text);
            DocumentHelper.EditRefDocument(DocID);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new frmDocumentMonitor();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            List<Int32> PatList = new List<Int32>();
            PatList.Add(1000);
            PatList.Add(1001);
            PatList.Add(1002);
            // Sepehr.Documents.DocumentHelper.PrintPatLastDocument(PatList, false);
            DocumentHelper.PrintPatientsDocs(PatList, true);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Int32 DocID = Convert.ToInt32(txt2.Text);
            new frmFileBurner(DocID);
        }

    }
}