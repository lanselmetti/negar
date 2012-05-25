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
            Column7.ValueType = typeof(Int32?);
            //Column8.ValueType = typeof(Int32);
            dataGridView1.Rows.Add(null, null, null, null, null);
            dataGridView1.Rows.Add(null, null, null, null, null, null, null, null);
            for (Int32 i = 0; i < 68; i++)
                dataGridView1.Rows.Add("فيلد ستون اول - " + (i + 1), "تهی", true, null, 
                    DateTime.Now.AddDays(i + 1), DateTime.Now.AddDays(i + 1), i, i * 1000);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Negar.GridPrinting.frmReportPreview(dataGridView1);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

    }
}