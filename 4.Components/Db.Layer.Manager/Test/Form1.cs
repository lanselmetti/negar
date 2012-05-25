using System;
using System.Windows.Forms;
using Negar;
using Negar.DBLayerPMS;

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
            //var x = Manager.DBML.SendQueues.First().SMSMessage;
            //MessageBox.Show(x.MessageText);
            //SMS.AddMessageToSendQueueFromFailedMessages(2);
            ClinicData.SubmitDbEventLog(5600, 500, SecurityManager.CurrentUserID, DateTime.Now, "تست");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SMS.ConnectionString = Manager.DBML.Connection.ConnectionString;
            dataGridView1.DataSource = SMS.GetQueueMessages(5);
        }
    }
}
