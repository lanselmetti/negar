using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Windows.Forms;
using Negar;
using Sepehr.DBLayerIMS.DataLayer;

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
            try
            {
                dataGridView1.DataSource =
                    Sepehr.DBLayerIMS.Schedules.SchAppList.ToList();
               if( Sepehr.DBLayerIMS.Schedules.SchAppList.Where(Data => Data.IsActive == true && Data.ID != null).Count() == 0)
                   MessageBox.Show("Test");
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Sepehr.DBLayerIMS.PatientSearcher.GetPatRefListDataByPatID(119682);
        }
    }
}
