using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Negar;
using Negar.SMSWebService;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Manager.Username = "parto";
            Manager.Password = "parto49164";
            CSManager.CurrentSetting = "اتصال به سرور محلی";

        }

        private void button1_Click(object sender, EventArgs e)
        {

          
            //Manager.SendOneSMSToOneNumber(textBox1.Text, textBox2.Text);
            Manager.TimerStart();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Sepehr.DBLayerIMS.Messages.InsertMessageToMsgList(100, null, null, textBox2.Text, null, textBox1.Text);
        }
    }
}
