#region using
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Windows.Forms;
using mCore;
using Negar.SMSManager;
using Parity = mCore.Parity;
using StopBits = mCore.StopBits;
#endregion

namespace Test_Project
{
    public partial class Form1 : Form
    {
        private List<SMSSentResultData> _SentList;

        #region Ctor
        public Form1()
        {
            InitializeComponent();
        }
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (String port in SerialPort.GetPortNames()) cboPortName.Items.Add(port);
            _SentList = new List<SMSSentResultData>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GSMModemManager.StaticSMSObject = GSMModemManager.ConnectGSMModem(cboPortName.Text,
                BaudRate.BaudRate_19200, DataBits.Eight, Parity.None, StopBits.One, FlowControl.None, true);
            if (GSMModemManager.StaticSMSObject == null) { MessageBox.Show("Connection Field"); return; }
            MessageBox.Show("Testing The Connection Was Successfull");
            GSMModemManager.SMSMessageSent += GSMModemManager_SMSMessageSent;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (GSMModemManager.StaticSMSObject == null) return;
            SMSMessageData SMSData = new SMSMessageData(txtNumber.Text, txtText.Text);
            SMSData.IsAlert = false;
            SMSData.RequestDelivery = true;
            String SMSKey = SMSSender.SendSyncSMS(SMSData);
            dataGridView1.Rows.Add(SMSKey, SMSData.DestinationPhoneNumber, SMSData.Message, "در حال ارسال");
            GSMModemManager.StaticSMSObject.Queue().Enabled = true;
        }

        void GSMModemManager_SMSMessageSent(SMSSentResultData ResultData)
        {
            _SentList.Add(ResultData);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (GSMModemManager.StaticSMSObject != null)
            {
                GSMModemManager.DisconnectGSMModem(GSMModemManager.StaticSMSObject);
                GSMModemManager.StaticSMSObject.Dispose();
                GSMModemManager.StaticSMSObject = null;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                if (GSMModemManager.StaticSMSObject == null) return;
                SMSMessageData SMSData = new SMSMessageData(txtNumber.Text, txtText.Text + i);
                SMSData.IsAlert = false;
                SMSData.RequestDelivery = true;
                String SMSKey = SMSSender.SendSyncSMS(SMSData);
                dataGridView1.Rows.Add(SMSKey, SMSData.DestinationPhoneNumber, SMSData.Message, "در حال ارسال");
                GSMModemManager.StaticSMSObject.Queue().Enabled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (_SentList.Count != 0)
            {
                foreach (SMSSentResultData data in _SentList)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                        if (row.Cells[ColKey.Index].Value.Equals(data.MessageReference))
                        {
                            row.Cells[ColReferrenceCode.Index].Value = data.MessageReference;
                            if (data.IsSent) row.Cells[ColStatus.Index].Value = "ارسال شده";
                            else row.Cells[ColStatus.Index].Value = "ارسال نشده";
                            row.Cells[ColDeliverTime.Index].Value = data.SendDate;
                        }
                }
                _SentList = new List<SMSSentResultData>();
            }
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
    }
}