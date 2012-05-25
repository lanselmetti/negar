//******************************************************************************************
// mCore .NET SMS Library 1.2 Demo for C#
// Copyright (c) IG Logix Softech Pvt Ltd, All rights reserved.
// This sample highlights usage of all properties & methods of mCore .NET SMS Library 1.2
// mCore ('mCore .NET SMS Library 1.2') is added as a .NET reference.
// IMPORTANT: "mCore .NET SMS Library" requires minimum Microsoft .NET Framework 2.0
// This sample code is not intended to be a C# or .NET tutorial.
//******************************************************************************************

using System;
using System.Diagnostics;
using System.Windows.Forms;
using mCore;
using Message = mCore.Message;

namespace mCoreDemo
{
    public partial class frmMain : Form
    {
        private SMS objSMS = new SMS();
        private const String strMyAppName = "RPN™ (C# Demo)";

        public frmMain()
        {
            InitializeComponent();
            objSMS.License().Company = "ZURICH INSURANCE GROUP (HK)";
            objSMS.License().LicenseType = "PRO-DISTRIBUTION";
            objSMS.License().Key = "FJ4F-C51W-MCER-BRAW";
            objSMS.NewMessageReceived += objSMS_NewMessageReceived;
            
            objSMS.NewDeliveryReport += objSMS_NewDeliveryReport;//

            objSMS.NewIncomingCall += objSMS_NewIncomingCall;
            
            objSMS.QueueSMSSent += objSMS_QueueSMSSent; //

            objSMS.QueueSMSSending += objSMS_QueueSMSSending;
            
            objSMS.NewUSSDReceived += objSMS_NewUSSDReceived;
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            objSMS.Dispose();
            objSMS = null;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            int i;

            //=====================================================================
            // If you have purchased mCore .NET Library license, then enter license
            // information in the following three lines of code
            //=====================================================================

            /*
            mCore.License objLic = objSMS.License();
            objLic.Company = "My Company Name";
            objLic.LicenseType = "My License Type";
            objLic.Key = "My License Key";
            */

            //=====================================================================


            //-------------------------------------
            //Initialize COM Port DropDown List
            //-------------------------------------
            cboPort.Items.Add("Select Port");
            for (i = 1; i <= 256; i++)
            {
                cboPort.Items.Add("COM" + i);
            }
            cboPort.SelectedIndex = 0;


            //--------------------------------------
            //Initialize BaudRate DropDown List
            //--------------------------------------
            cboBaudRate.Items.Add("110");
            cboBaudRate.Items.Add("300");
            cboBaudRate.Items.Add("1200");
            cboBaudRate.Items.Add("2400");
            cboBaudRate.Items.Add("4800");
            cboBaudRate.Items.Add("9600");
            cboBaudRate.Items.Add("14400");
            cboBaudRate.Items.Add("19200");
            cboBaudRate.Items.Add("38400");
            cboBaudRate.Items.Add("57600");
            cboBaudRate.Items.Add("115200");
            cboBaudRate.Items.Add("230400");
            cboBaudRate.Items.Add("460800");
            cboBaudRate.Items.Add("921600");
            cboBaudRate.SelectedIndex = cboBaudRate.FindString(((int)objSMS.BaudRate).ToString());

            //--------------------------------------
            //Initialize DataBits DropDown List
            //--------------------------------------
            cboDataBits.Items.Add("4");
            cboDataBits.Items.Add("5");
            cboDataBits.Items.Add("6");
            cboDataBits.Items.Add("7");
            cboDataBits.Items.Add("8");
            cboDataBits.SelectedIndex = cboDataBits.FindString(((int)objSMS.DataBits).ToString());


            //--------------------------------------
            //Initialize Parity DropDown List
            //--------------------------------------
            cboParity.Items.Add("None");
            cboParity.Items.Add("Odd");
            cboParity.Items.Add("Even");
            cboParity.Items.Add("Mark");
            cboParity.Items.Add("Space");
            cboParity.SelectedIndex = (int)objSMS.Parity;


            //--------------------------------------
            //Initialize StopBits DropDown List
            //--------------------------------------
            cboStopBits.Items.Add("1");
            cboStopBits.Items.Add("2");
            cboStopBits.Items.Add("1.5");
            cboStopBits.SelectedIndex = (int)objSMS.StopBits - 1;


            //--------------------------------------
            //Initialize FlowControl DropDown List
            //--------------------------------------
            cboFlowControl.Items.Add("None");
            cboFlowControl.Items.Add("Hardware");
            cboFlowControl.Items.Add("Xon/Xoff");
            cboFlowControl.SelectedIndex = (int)objSMS.FlowControl;


            //-------------------------------------------------
            //Initialize Send Delay, Send Retry & Timeout
            //-------------------------------------------------
            txtSendDelay.Text = Convert.ToString(objSMS.SendDelay / 1000);
            txtSendRetry.Text = objSMS.SendRetry.ToString();
            txtTimeout.Text = Convert.ToString(objSMS.Timeout / 1000);

            objSMS.ReadIntervalTimeout = 100;
            objSMS.DelayAfterPIN = 20000;

            chkIncomingCall.Checked = objSMS.IncomingCallIndication;
            objSMS.Queue().Enabled = true;
            chkQueue.Checked = objSMS.Queue().Enabled;

            //----------------------------------------
            //Initialize Message Memory DropDown List
            //----------------------------------------
            cboMsgMemory.Items.Add("SIM");
            cboMsgMemory.Items.Add("Phone");
            cboMsgMemory.Items.Add("SIM+Phone");
            cboMsgMemory.SelectedIndex = 0;

            //-------------------------------------------------
            //Initialize incoming message concatenate setting
            //-------------------------------------------------
            if (objSMS.Inbox().Concatenate)
            {
                chkInConcatenate.Checked = true;
                objSMS.NewMessageConcatenate = true;
            }

            //---------------------------------------------------
            //Initialize new incoming message indication setting
            //---------------------------------------------------
            if (objSMS.NewMessageIndication)
            {
                chkNewMsgIndication.Checked = true;
            }
            if (objSMS.AutoDeleteNewMessage)
            {
                chkAutoDelete.Checked = true;
            }
            if (chkNewMsgIndication.Checked)
            {
                chkRefreshInbox.Enabled = true;
                chkAutoDelete.Enabled = true;
            }
            else
            {
                chkRefreshInbox.Enabled = false;
                chkAutoDelete.Enabled = false;
            }
            if (objSMS.DeliveryReport)
            {
                chkDeliveryReport.Checked = true;
            }
            if (objSMS.DisableCheckPIN)
            {
                chkDisableCheckPIN.Checked = true;
            }

            //----------------------------------------
            //Initialize Long Message DropDown List
            //----------------------------------------
            cboLongMsg.Items.Add("Truncate");
            cboLongMsg.Items.Add("Simple Split");
            cboLongMsg.Items.Add("Formatted Split");
            cboLongMsg.Items.Add("Concatenate");
            cboLongMsg.SelectedIndex = (int)objSMS.LongMessage;

            //----------------------------------------
            //Initialize Encoding Type DropDown List
            //----------------------------------------
            cboEncoding.Items.Add("Default Alphabet");
            cboEncoding.Items.Add("ANSI (8-bit)");
            cboEncoding.Items.Add("Unicode (16-bit)");
            cboEncoding.SelectedIndex = (int)objSMS.Encoding;

            lblNoteSMS.Text =
                "NOTE: For non-english language messages you must select encoding type as Unicode (16-Bit).\r\nUse a suitable keyboard/IME to type non-english messages.";
            lblNoteWP.Text = "NOTE: For non-english language message use a suitable keyboard/IME to type the message.";
            //----------------------------------------
            //Initialize message validity setting
            //----------------------------------------
            txtValidity.Text = "24";
            cboValidity.Items.Add("Min");
            cboValidity.Items.Add("Hour");
            cboValidity.Items.Add("Day");
            cboValidity.Items.Add("Week");
            cboValidity.SelectedIndex = 1;

            cboSMSQPriority.Items.Add("High");
            cboSMSQPriority.Items.Add("Normal");
            cboSMSQPriority.Items.Add("Low");
            cboSMSQPriority.SelectedIndex = 1;

            chkSMSQueue.Checked = false;
            cboSMSQPriority.Enabled = false;
            lblSMSQPriority.Enabled = false;

            //----------------------------------------
            //Initialize WAP Push Settings
            //----------------------------------------
            cboAction.Items.Add("signal-low");
            cboAction.Items.Add("signal-medium");
            cboAction.Items.Add("signal-high");
            cboAction.SelectedIndex = (int)objSMS.WapPush().Action - 1;

            txtExpiry.Text = "1";
            txtExpiry.Enabled = false;

            cboExpiry.Items.Add("Hour");
            cboExpiry.Items.Add("Day");
            cboExpiry.Items.Add("Month");
            cboExpiry.SelectedIndex = 0;
            cboExpiry.Enabled = false;

            txtURL.Text = "http://www.logixmobile.com";

            dtpCreated.MaxDate = DateTime.Now;
            dtpCreated.Value = DateTime.Now.AddDays(-1);
            dtpCreated.Enabled = false;

            chkDebugMode.Checked = objSMS.DebugMode;

            cboLogType.Items.Add("No Log");
            cboLogType.Items.Add("Error Log");
            cboLogType.Items.Add("Error & Status Log");
            cboLogType.SelectedIndex = (int)objSMS.LogType;

            txtLogFolder.Text = objSMS.LogFolderPath;

            cboDuration.Items.Add("Minute");
            cboDuration.Items.Add("Hour");
            cboDuration.Items.Add("Day");
            cboDuration.SelectedIndex = 0;

            dtpStartDateTime.CustomFormat = "dd MMM yyyy, hh:mm:ss tt";
            dtpStartDateTime.MinDate = DateTime.Now;
            dtpEndDateTime.CustomFormat = "dd MMM yyyy, hh:mm:ss tt";

            txtDuration.Text = "30";
            rdbEndDateTime.Checked = true;
            rdbDuration.Checked = false;
            dtpEndDateTime.Enabled = false;
            txtDuration.Enabled = false;
            cboDuration.Enabled = false;

            lblQueueCount.Text = "Messages in queue: 0";
            lblQueueStatus.Text = "";

            lblUSSDStatus.Text = "";
            objSMS.NewUSSDIndication = true;
            chkUSSD.Checked = objSMS.NewUSSDIndication;
        }


        private void cmdConnect_Click(object sender, EventArgs e)
        {
            //
            //Connect is optional.
            //The Connect method is called automatically inside
            //mCore object whenever any property is read
            //or a method is called, that requires connection
            //with GSM modem
            //

            try
            {
                if (cboPort.SelectedIndex == 0)
                {
                    MessageBox.Show("Select a serial port!", strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                cmdConnect.Text = "Please Wait...";
                cmdConnect.Enabled = false;
                cmdDisconnect.Enabled = false;

                SetCommParameters();

                if (objSMS.Connect())
                {
                    cmdConnect.Enabled = false;
                    cmdDisconnect.Enabled = true;

                    //Retrieve SMSC setting from SIM card
                    txtSMSC.Text = objSMS.SMSC;

                    switch (objSMS.MessageMemory)
                    {
                        case MessageMemory.SM:
                            {
                                cboMsgMemory.SelectedIndex = 0;
                                break;
                            }
                        case MessageMemory.ME:
                            {
                                cboMsgMemory.SelectedIndex = 1;
                                break;
                            }
                        case MessageMemory.MT:
                            {
                                cboMsgMemory.SelectedIndex = 2;
                                break;
                            }
                    }

                    MessageBox.Show("Connection Successful", strMyAppName, MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Connection Error", strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmdConnect.Enabled = true;
                    cmdDisconnect.Enabled = false;
                }

                // THE FOLLOWING GIVES SAME RESULT AS ABOVE
                // Remember that connect method is not called explicitly in the following lines

                /*
                txtSMSC.Text = objSMS.SMSC;
                MessageBox.Show("Connection Successful", strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                */
            }
            catch (GeneralException ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                cmdConnect.Text = "Connect";
                if (objSMS.IsConnected)
                {
                    cmdConnect.Enabled = false;
                    cmdDisconnect.Enabled = true;
                }
                else
                {
                    cmdConnect.Enabled = true;
                    cmdDisconnect.Enabled = false;
                }
            }
            catch (Exception)
            {
            }
        }


        private void cmdDisconnect_Click(object sender, EventArgs e)
        {
            //It is not mandatory to call Disconnect method.
            //Closing mCore object will automatically call Disconnect

            cmdDisconnect.Text = "Please Wait...";
            cmdDisconnect.Enabled = false;
            cmdConnect.Enabled = false;

            try
            {
                objSMS.Disconnect();
                cmdConnect.Enabled = true;
                cmdDisconnect.Enabled = false;
            }
            catch (GeneralException ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            cmdDisconnect.Text = "Disconnect";
        }


        private void cmdRefreshSettings_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboPort.SelectedIndex == 0)
                {
                    MessageBox.Show("Select a serial port", strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                cmdRefreshSettings.Text = "Please Wait...";
                cmdRefreshSettings.Enabled = false;
                cmdApplySettings.Enabled = false;

                //Retrieve SendRetry, SendDelay and Timeout
                //PIN is not retrieved (it is a write only property)
                //However to retrieve SMSC value, the PIN maybe required,
                //if the SIM is still waiting for PIN

                objSMS.PIN = txtPIN.Text.Trim();
                chkDisableCheckPIN.Checked = objSMS.DisableCheckPIN;
                txtSendRetry.Text = objSMS.SendRetry.ToString();
                txtSendDelay.Text = Convert.ToString(objSMS.SendDelay / 1000);
                txtTimeout.Text = Convert.ToString(objSMS.Timeout / 1000);
                Application.DoEvents();

                SetCommParameters();

                //Retrieve SMSC information
                txtSMSC.Text = objSMS.SMSC;
            }
            catch (GeneralException ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            cmdRefreshSettings.Text = "Refresh";
            cmdRefreshSettings.Enabled = true;
            cmdApplySettings.Enabled = true;
        }


        private void cmdApplySettings_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboPort.SelectedIndex == 0)
                {
                    MessageBox.Show("Select a serial port", strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                cmdApplySettings.Text = "Please Wait...";
                cmdApplySettings.Enabled = false;
                cmdRefreshSettings.Enabled = false;

                //Set PIN
                objSMS.PIN = txtPIN.Text;

                //Set SendDelay (min delay between sending two messages) in milliseconds
                objSMS.SendDelay = (int)(Convert.ToDouble(txtSendDelay.Text) * 1000);

                //Send number of retries if error is encountered when sending message
                objSMS.SendRetry = Convert.ToInt32(txtSendRetry.Text);

                //Set modem timeout (in milliseconds)
                objSMS.Timeout = (long)(Convert.ToDouble(txtTimeout.Text) * 1000);

                SetCommParameters();

                //Set SMSC number
                objSMS.SMSC = txtSMSC.Text;
            }
            catch (GeneralException ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void chkInConcatenate_CheckedChanged(object sender, EventArgs e)
        {
            objSMS.Inbox().Concatenate = chkInConcatenate.Checked;
        }


        private void chkNewMsgIndication_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                chkNewMsgIndication.Enabled = false;

                SetCommParameters();

                objSMS.NewMessageIndication = chkNewMsgIndication.Checked;

                if (chkInConcatenate.Checked)
                {
                    objSMS.NewMessageConcatenate = true;
                }
                else
                {
                    objSMS.NewMessageConcatenate = false;
                }
            }
            catch (GeneralException ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                chkNewMsgIndication.Checked = objSMS.NewMessageIndication;
                chkInConcatenate.Checked = objSMS.NewMessageConcatenate;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            chkNewMsgIndication.Enabled = true;

            if (chkNewMsgIndication.Checked)
            {
                chkRefreshInbox.Enabled = true;
                chkAutoDelete.Enabled = true;
            }
            else
            {
                chkRefreshInbox.Enabled = false;
                chkAutoDelete.Enabled = false;
            }
        }


        private void chkAutoDelete_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                objSMS.AutoDeleteNewMessage = chkAutoDelete.Checked;
            }
            catch (GeneralException ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                chkAutoDelete.Checked = objSMS.AutoDeleteNewMessage;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                chkAutoDelete.Checked = objSMS.AutoDeleteNewMessage;
            }
        }


        private void cboMsgMemory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPort.SelectedIndex == 0)
            {
                tabMessaging.SelectedIndex = 0;
                return;
            }

            try
            {
                cboMsgMemory.Enabled = false;

                //Define message memory type
                //message memory type will define the memory from where
                //messages will be read/deleted

                lblMsgCount.Text = "Setting message memory... Please wait...";
                Application.DoEvents();

                SetCommParameters();

                switch (cboMsgMemory.SelectedIndex)
                {
                    case 0:
                        {
                            objSMS.MessageMemory = MessageMemory.SM;
                            break;
                        }
                    case 1:
                        {
                            objSMS.MessageMemory = MessageMemory.ME;
                            break;
                        }
                    case 2:
                        {
                            objSMS.MessageMemory = MessageMemory.MT;
                            break;
                        }
                }
            }
            catch (GeneralException ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            lblMsgCount.Text = String.Empty;
            cboMsgMemory.Enabled = true;
        }

        private void cmdInboxRefresh_Click(object sender, EventArgs e)
        {
            RefreshInbox();
        }

        private void lstInbox_DoubleClick(object sender, EventArgs e)
        {
            Inbox objInbox = objSMS.Inbox();
            Message Msg;

            try
            {
                //Read properties of selected message index from Inbox
                int i;
                for (i = 1; i <= lstInbox.Items.Count; i++)
                {
                    Msg = objInbox.Message(i);
                    if (lstInbox.Items[i - 1].Checked)
                    {
                        MessageBox.Show(Msg.TimeStampRFC + "\r\n\r\n" + Msg.Text, "From: " + Msg.Phone,
                                        MessageBoxButtons.OK);
                        break;
                    }
                }
                if (lstInbox.Items[i - 1].Checked)
                {
                    lstInbox.Items[i - 1].Checked = false;
                }
            }
            catch (SMSReadException ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (GeneralException ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdMsgDelete_Click(object sender, EventArgs e)
        {
            try
            {
                cmdMsgDelete.Enabled = false;

                //Delete selected message(s)
                if (
                    MessageBox.Show("Delete selected message(s)?", strMyAppName, MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    lblMsgCount.Text = "Deleting selected message(s)...";
                    int i;
                    for (i = lstInbox.Items.Count; i >= 1; i--)
                    {
                        if (lstInbox.Items[i - 1].Checked)
                        {
                            objSMS.Inbox().Message(i).Delete();
                        }
                    }
                    lstInbox.Items.Clear();
                    FillInboxList();
                }

                lblMsgCount.Text = "Total Messages: " + objSMS.Inbox().Count;
                if (objSMS.Inbox().Count > 0)
                {
                    lblMsgCount.Text = lblMsgCount.Text + "\r\n\r\n(double click on a message to view)";
                }
            }
            catch (SMSDeleteException ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (GeneralException ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            cmdMsgDelete.Enabled = true;
        }


        private void RefreshInbox()
        {
            Inbox objInbox = objSMS.Inbox();

            SetCommParameters();

            lblMsgCount.Text = "Reading messages... Please wait...";
            Application.DoEvents();

            try
            {
                cmdInboxRefresh.Enabled = false;
                cmdMsgDelete.Enabled = false;
                cboMsgMemory.Enabled = false;
                chkInConcatenate.Enabled = false;

                //Retrieve all messages from inbox

                //Also try:
                /*
                objInbox.Refresh(mCore.Inbox.EnumMessageType.ReceivedUnreadMessages)
                objInbox.Refresh(mCore.Inbox.EnumMessageType.ReceivedReadMessages)
                */

                if (chkCleanUp.Checked)
                {
                    objInbox.Refresh(MessageType.ReceivedAllMessages, true);
                }
                else
                {
                    objInbox.Refresh();
                }

                lstInbox.Items.Clear();
                FillInboxList();
            }
            catch (SMSReadException ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (GeneralException ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            lblMsgCount.Text = "Total Messages: " + objInbox.Count;
            if (objInbox.Count > 0)
            {
                lblMsgCount.Text = lblMsgCount.Text + "\r\n(double click on a message to view)";
            }

            cmdMsgDelete.Enabled = true;
            cmdInboxRefresh.Enabled = true;
            cboMsgMemory.Enabled = true;
            chkInConcatenate.Enabled = true;
        }


        private void FillInboxList()
        {
            Inbox objInbox = objSMS.Inbox();

            try
            {
                //Read properties of each message read from modem
                //and fill the listview collumns
                int i = 0;
                foreach (Message Msg in objInbox)
                {
                    lstInbox.Items.Add(Msg.Phone);
                    lstInbox.Items[i].SubItems.Add(Msg.Text);
                    lstInbox.Items[i].SubItems.Add(Msg.TimeStamp.ToString());
                    i++;
                }

                //Folowing code will also generate same result as above
                /*
                for (i = 1; i <= objInbox.Count; i++)
                {
                    lstInbox.Items.Add(objInbox.Message(i).Phone);
                    lstInbox.Items[i - 1].SubItems.Add(objInbox.Message(i).Text);
                    lstInbox.Items[i - 1].SubItems.Add(objInbox.Message(i).TimeStamp.ToString());
                }
                */
            }
            catch (SMSReadException ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (GeneralException ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void objSMS_NewMessageReceived(object sender, NewMessageReceivedEventArgs e)
        {
            //New Message Indication Event
            //Display the new message

            MessageBox.Show(
                "FROM: " + e.Phone + "\r\n\r\nDATE/TIME: " + e.TimeStampRFC + "\r\n\r\nMESSAGE:\r\n" + e.TextMessage,
                "NEW MESSAGE RECEIVED...", MessageBoxButtons.OK, MessageBoxIcon.None);

            //Refresh Inbox
            //Disable illegal cross thread calls to form controls
            //(because NewMessageReceived event is on a secondary thread)
            //Please remember this is not the best way if other threads may simultaneously
            //access the form controls in your application

            CheckForIllegalCrossThreadCalls = false;

            if (chkRefreshInbox.Checked)
            {
                RefreshInbox();
            }

            CheckForIllegalCrossThreadCalls = true;
        }


        private static void objSMS_NewDeliveryReport(object sender, NewDeliveryReportEventArgs e)
        {
            //New Delivery Report Event

            //Display delivery report
            if (e.Status)
            {
                MessageBox.Show(
                    "MESSAGE DELIVERED\r\n\r\nTO: " + e.Phone + "\r\n\r\nSENT DATE/TIME: " + e.SentTimeStamp +
                    "\r\n\r\nDELIVERY DATE/TIME: " + e.DeliveryTimeStamp + "\r\n\r\n[Message Ref.: " +
                    e.MessageReference + "]", "DELIVERY REPORT...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(
                    "MESSAGE DELIVERY FAILED\r\n\r\nTO: " + e.Phone + "\r\n\r\nSENT DATE/TIME: " + e.SentTimeStamp +
                    "\r\n\r\nREPORT DATE/TIME: " + e.DeliveryTimeStamp + "\r\n\r\n[Message Ref.: " + e.MessageReference +
                    "]", "DELIVERY REPORT...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private static void objSMS_NewIncomingCall(object sender, NewIncomingCallEventArgs e)
        {
            //New Incoming Call Event

            //Display the incoming call information
            MessageBox.Show("Incoming call from: " + e.CallerID, "INCOMING CALL...", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }


        private void chkDeliveryReport_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                chkDeliveryReport.Enabled = false;

                SetCommParameters();

                //Set delivery report for outgoing SMS
                objSMS.DeliveryReport = chkDeliveryReport.Checked;
            }
            catch (GeneralException ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            chkDeliveryReport.Enabled = true;
        }


        private void cboLongMsg_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Set long message treatment (LongMessage propety)
                objSMS.LongMessage = (LongMessage)cboLongMsg.SelectedIndex;
            }
            catch (GeneralException ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void cboEncoding_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Set message encoding type
                objSMS.Encoding = (Encoding)cboEncoding.SelectedIndex;
            }
            catch (GeneralException ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void cmdSendMsg_Click(object sender, EventArgs e)
        {
            if (txtPhone.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Destination phone number is required!", strMyAppName,
                    MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }

            cmdSendMsg.Text = "Sending SMS...Please Wait...";
            cmdSendMsg.Enabled = false;
            Application.DoEvents();

            try
            {
                SetCommParameters();
                objSMS.Validity = txtValidity.Text + cboValidity.Text.Substring(0, 1); //Set message validity period

                if (chkSMSQueue.Checked)
                {
                    //Send the text message to message queue
                    QueuePriority EnumPriority = QueuePriority.Normal;
                    switch (cboSMSQPriority.SelectedIndex)
                    {
                        case 0: { EnumPriority = QueuePriority.High; break; }
                        case 1: { EnumPriority = QueuePriority.Normal; break; }
                        case 2: { EnumPriority = QueuePriority.Low; break; }
                    }
                    String strKey = objSMS.SendSMSToQueue(txtPhone.Text, txtMessage.Text, EnumPriority, chkAlert.Checked);
                    lblQueueCount.Text = "Messages in queue: " + objSMS.Queue().Count;
                    MessageBox.Show("Message sent to queue!" + "\r\n\r\n[Message Queue Key: " + strKey + "]",
                        strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //Send the message
                    String strSendResult = objSMS.SendSMS(txtPhone.Text, txtMessage.Text, chkAlert.Checked);
                    MessageBox.Show("Message sent!\r\n\r\n[Message Ref.: " + strSendResult + "]", strMyAppName,
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SMSSendException ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (GeneralException ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            cmdSendMsg.Text = "Send Message";
            cmdSendMsg.Enabled = true;
        }


        private void chkCreated_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCreated.Checked)
            {
                dtpCreated.Enabled = true;
            }
            else
            {
                dtpCreated.Enabled = false;
            }
        }


        private void chkExpiry_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExpiry.Checked)
            {
                txtExpiry.Enabled = true;
                cboExpiry.Enabled = true;
            }
            else
            {
                txtExpiry.Enabled = false;
                cboExpiry.Enabled = false;
            }
        }


        private void cmdSendWapPush_Click(object sender, EventArgs e)
        {
            WapPush objWP = objSMS.WapPush();

            if (txtPhoneWP.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Destination phone number is required!", strMyAppName, MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            cmdSendWapPush.Text = "Sending WAP Push...Please Wait...";
            cmdSendWapPush.Enabled = false;
            Application.DoEvents();

            try
            {
                SetCommParameters();

                objWP.Destination = txtPhoneWP.Text; //Destination phone
                objWP.Text = txtMessageWP.Text; //Text message
                objWP.URL = txtURL.Text; //Content URL
                objWP.Action = (WapPushAction)(cboAction.SelectedIndex + 1); //Action attribute

                //Set content created (or last modified) date
                //If not required then specify as null
                if (chkCreated.Checked)
                {
                    objWP.Created = dtpCreated.Value;
                }
                else
                {
                    objWP.Created = Convert.ToDateTime(null);
                }

                //Content expiry date
                //If not required set as "0"
                if (chkExpiry.Checked)
                {
                    objWP.Expiry = txtExpiry.Text.Trim() + cboExpiry.Text.Substring(0, 1);
                }
                else
                {
                    objWP.Expiry = "0";
                }

                //Send the wap push service message
                objWP.Send();

                MessageBox.Show("WAP Push Sent!", strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (WapPushException ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (GeneralException ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            cmdSendWapPush.Text = "Send WAP Push";
            cmdSendWapPush.Enabled = true;
        }


        private void cmdSendVCard_Click(object sender, EventArgs e)
        {
            vCard objVCARD = objSMS.vCard();

            try
            {
                cmdSendVCard.Text = "Sending vCard...Please Wait...";
                cmdSendVCard.Enabled = false;
                Application.DoEvents();

                SetCommParameters();

                objVCARD.Destination = txtPhoneVCF.Text.Trim();

                objVCARD.FirstName = txtFName.Text.Trim();
                objVCARD.MiddleName = txtMName.Text.Trim();
                objVCARD.LastName = txtLName.Text.Trim();

                objVCARD.Email = txtEmail.Text.Trim();
                objVCARD.URL = txtWebsite.Text.Trim();

                objVCARD.Company = txtCompany.Text.Trim();
                objVCARD.JobTitle = txtJobTitle.Text.Trim();

                objVCARD.HomePhone = txtHomePhone.Text.Trim();
                objVCARD.BusinessPhone = txtBusinessPhone.Text.Trim();
                objVCARD.MobilePhone = txtMobilePhone.Text.Trim();

                objVCARD.HomeAddressStreet = txtHomeStreet.Text.Trim();
                objVCARD.HomeAddressCity = txtHomeCity.Text.Trim();
                objVCARD.HomeAddressState = txtHomeState.Text.Trim();
                objVCARD.HomeAddressCountry = txtHomeCountry.Text.Trim();
                objVCARD.HomeAddressZIP = txtHomeZIP.Text.Trim();

                objVCARD.BusinessAddressStreet = txtBusinessStreet.Text.Trim();
                objVCARD.BusinessAddressCity = txtBusinessCity.Text.Trim();
                objVCARD.BusinessAddressState = txtBusinessState.Text.Trim();
                objVCARD.BusinessAddressCountry = txtBusinessCountry.Text.Trim();
                objVCARD.BusinessAddressZIP = txtBusinessZIP.Text.Trim();

                objVCARD.Comment = txtComment.Text.Trim();

                //Send the vCard
                objVCARD.Send();

                MessageBox.Show("vCard Sent!!!", strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (vCardException ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (GeneralException ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            cmdSendVCard.Text = "Send vCard";
            cmdSendVCard.Enabled = true;
        }


        private void cmdNetRefresh_Click(object sender, EventArgs e)
        {
            string strNetwork = "";

            cmdNetRefresh.Text = "Please Wait...";
            cmdNetRefresh.Enabled = false;
            lblNetwork.Text = "Reading... Please wait...";
            prbSignal.Value = 0;
            lblNetwork.Enabled = false;
            prbSignal.Enabled = false;

            Application.DoEvents();

            try
            {
                SetCommParameters();

                //Retrieve GSM network signal strength
                prbSignal.Value = objSMS.SignalStrength;

                Application.DoEvents();

                //Read service provider network identification
                //Depending on the modem and the network, this process may take some time
                strNetwork = objSMS.Network;
            }
            catch (GeneralException ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (strNetwork == "")
            {
                strNetwork = "Read timeout";
            }

            lblNetwork.Text = strNetwork;

            cmdNetRefresh.Text = "Refresh";
            cmdNetRefresh.Enabled = true;
            lblNetwork.Enabled = true;
            prbSignal.Enabled = true;
        }


        private void cmdMdmRefresh_Click(object sender, EventArgs e)
        {
            int BattLevel = -1;
            string OwnNumber = "";

            cmdMdmRefresh.Text = "Please wait...";
            cmdMdmRefresh.Enabled = false;

            lblManufacturer.Enabled = false;
            lblModel.Enabled = false;
            lblRevision.Enabled = false;
            lblIMEI.Enabled = false;
            lblIMSI.Enabled = false;
            lblBattery.Enabled = false;
            lblOwnNum.Enabled = false;

            lblManufacturer.Text = "Reading... Please wait...";
            lblModel.Text = "Reading... Please wait...";
            lblRevision.Text = "Reading... Please wait...";
            lblIMEI.Text = "Reading... Please wait...";
            lblIMSI.Text = "Reading... Please wait...";
            lblBattery.Text = "Reading... Please wait...";
            lblOwnNum.Text = "Reading... Please wait...";

            Application.DoEvents();

            SetCommParameters();

            try
            {
                //Retrieve modem Manufacturer information
                lblManufacturer.Text = objSMS.Manufacturer;
            }
            catch (GeneralException ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            lblManufacturer.Enabled = true;
            Application.DoEvents();

            try
            {
                //Retrieve modem Model information
                lblModel.Text = objSMS.Model;
            }
            catch (GeneralException ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            lblModel.Enabled = true;
            Application.DoEvents();

            try
            {
                //Retrieve firmware Revision information
                lblRevision.Text = objSMS.Revision;
            }
            catch (GeneralException ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            lblRevision.Enabled = true;
            Application.DoEvents();

            try
            {
                //Retrieve modem IMEI information
                lblIMEI.Text = objSMS.IMEI;
            }
            catch (GeneralException ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            lblIMEI.Enabled = true;
            Application.DoEvents();

            try
            {
                //Retrieve IMSI information
                lblIMSI.Text = objSMS.IMSI;
            }
            catch (GeneralException ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            lblIMSI.Enabled = true;
            Application.DoEvents();

            try
            {
                //Retrieve battery charge level
                //If battery charge level reading is not supported,
                //the property will return -1
                BattLevel = objSMS.BatteryLevel;
            }
            catch (GeneralException ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (BattLevel > 0)
            {
                lblBattery.Text = BattLevel + "%";
            }
            else
            {
                lblBattery.Text = "Unknown";
            }

            lblBattery.Enabled = true;
            Application.DoEvents();

            try
            {
                //Retrieve MSISDN of the SIM card used
                //If MSISDN reading is not supported,
                //the property will return blank string
                OwnNumber = objSMS.OwnNumber;
            }
            catch (GeneralException ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (OwnNumber.Length > 0)
            {
                lblOwnNum.Text = OwnNumber;
            }
            else
            {
                lblOwnNum.Text = "Unknown";
            }

            lblOwnNum.Enabled = true;

            cmdMdmRefresh.Text = "Refresh";
            cmdMdmRefresh.Enabled = true;
        }


        private void SetCommParameters()
        {
            //Set communication parameters
            //check if port is already connected

            try
            {
                if (!objSMS.IsConnected && cboPort.SelectedIndex > 0)
                {
                    objSMS.Port = cboPort.Text;
                    objSMS.BaudRate = (BaudRate)(Convert.ToInt32(cboBaudRate.Text));
                    objSMS.DataBits = (DataBits)(Convert.ToInt32(cboDataBits.Text));
                    objSMS.Parity = (Parity)cboParity.SelectedIndex;
                    objSMS.StopBits = (StopBits)(cboStopBits.SelectedIndex + 1);
                    objSMS.FlowControl = (FlowControl)cboFlowControl.SelectedIndex;
                    objSMS.DisableCheckPIN = chkDisableCheckPIN.Checked;
                }
            }
            catch (GeneralException ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkDebugMode_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                objSMS.DebugMode = chkDebugMode.Checked;
            }
            catch (GeneralException ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void cmdLogFolder_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            fbd.Description = "Select a folder for mCore log file";
            fbd.SelectedPath = txtLogFolder.Text;
            fbd.ShowDialog();
            txtLogFolder.Text = fbd.SelectedPath;
        }


        private void cmdViewLog_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(objSMS.LogFolderPath + "mCoreLib.log");
            }
            catch (GeneralException ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void cmdClearLog_Click(object sender, EventArgs e)
        {
            try
            {
                //Clear log file

                objSMS.ClearLog();

                //Try using objSMS.ClearLog(LinesToKeep)
                //LinesToKeep is a integer value
            }
            catch (GeneralException ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void cmdLogSettings_Click(object sender, EventArgs e)
        {
            try
            {
                //Set log type etc.

                objSMS.LogType = (LogType)cboLogType.SelectedIndex;
                if (cboLogType.SelectedIndex > 0)
                {
                    if (txtLogFolder.Text.Trim().Length == 0)
                    {
                        txtLogFolder.Text = AppDomain.CurrentDomain.BaseDirectory;
                    }
                    objSMS.LogFolderPath = txtLogFolder.Text.Trim();
                }
            }
            catch (GeneralException ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void rdbEndDateTime_Click(object sender, EventArgs e)
        {
            rdbEndDateTime.Checked = true;
            rdbDuration.Checked = false;
            dtpEndDateTime.Enabled = true;
            txtDuration.Enabled = false;
            cboDuration.Enabled = false;
        }


        private void rdbDuration_Click(object sender, EventArgs e)
        {
            rdbDuration.Checked = true;
            rdbEndDateTime.Checked = false;
            dtpEndDateTime.Enabled = false;
            txtDuration.Enabled = true;
            cboDuration.Enabled = true;
        }


        private void cmdSendVCalendar_Click(object sender, EventArgs e)
        {
            vCalendar objVCAL = objSMS.vCalendar();

            try
            {
                cmdSendVCalendar.Text = "Sending vCalendar... Please Wait...";
                cmdSendVCalendar.Enabled = false;

                SetCommParameters();

                objVCAL.Destination = txtPhoneVCL.Text;
                objVCAL.StartDateTime = dtpStartDateTime.Value;
                if (rdbEndDateTime.Checked)
                {
                    objVCAL.EndDateTime = dtpEndDateTime.Value;
                }
                if (rdbDuration.Checked)
                {
                    objVCAL.EventDuration = txtDuration.Text + cboDuration.Text.Substring(0, 1);
                }
                objVCAL.Location = txtLocation.Text;
                objVCAL.Description = txtDescription.Text;
                objVCAL.Summary = txtSummary.Text;
                objVCAL.Send();

                MessageBox.Show("vCalendar Sent!", strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (vCalendarException ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (GeneralException ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            cmdSendVCalendar.Text = "Send vCalendar";
            cmdSendVCalendar.Enabled = true;
        }

        private void txtCommand_KeyUp(object sender, KeyEventArgs e)
        {
            string CommandString;
            string strModemResponse = "";
            bool blnUpdateResponse = false;

            SetCommParameters();

            //Send the typed command to the modem when Enter key is pressed
            if (e.KeyCode == Keys.Enter)
            {
                lblTerminalStatus.Text = "Please wait...";
                string[] TerminalLines = txtCommand.Text.Replace("\n", null).Split(new[] { '\r' });
                CommandString = TerminalLines[TerminalLines.GetUpperBound(0) - 1].Trim();

                if (CommandString == null)
                {
                    CommandString = "";
                }

                if (CommandString.Length > 0)
                {
                    //Read modem response
                    try
                    {
                        strModemResponse = objSMS.Command(CommandString);
                    }
                    catch (GeneralException ex)
                    {
                        MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    if (strModemResponse.Length > 0)
                    {
                        blnUpdateResponse = true;
                    }
                    else
                    {
                        strModemResponse = "NO RESPONSE FROM MODEM";
                        blnUpdateResponse = true;
                    }
                }

                if (blnUpdateResponse) txtCommand.Text = txtCommand.Text + strModemResponse + "\r\n";

                txtCommand.SelectionStart = txtCommand.Text.Length;
                txtCommand.ScrollToCaret();

                lblTerminalStatus.Text = "Type a command and press Enter key";
            }
        }


        private void chkIncomingCall_CheckedChanged(object sender, EventArgs e)
        {
            chkIncomingCall.Enabled = false;
            try
            {
                objSMS.IncomingCallIndication = chkIncomingCall.Checked;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            chkIncomingCall.Checked = objSMS.IncomingCallIndication;
            chkIncomingCall.Enabled = true;
        }


        private void cmdBrowseVCS_Click(object sender, EventArgs e)
        {
            var OpenFileDialogVCS = new OpenFileDialog();
            OpenFileDialogVCS.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            OpenFileDialogVCS.Filter = "vCalendar files (*.vcs)|*.vcs";
            OpenFileDialogVCS.RestoreDirectory = true;
            OpenFileDialogVCS.Multiselect = false;
            OpenFileDialogVCS.Title = "Select vCalendar file";
            OpenFileDialogVCS.ShowDialog();
            txtVCSFile.Text = OpenFileDialogVCS.FileName;
        }


        private void cmdSendVCS_Click(object sender, EventArgs e)
        {
            vCalendar objVCAL = objSMS.vCalendar();

            try
            {
                cmdSendVCS.Text = "Sending...";
                txtVCSFile.Enabled = false;
                cmdBrowseVCS.Enabled = false;
                cmdSendVCS.Enabled = false;

                objVCAL.Destination = txtPhoneVCL.Text;
                objVCAL.SendFile(txtVCSFile.Text);

                MessageBox.Show("vCalendar Sent!", strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (vCalendarException ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (GeneralException ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            cmdSendVCS.Text = "Send";
            txtVCSFile.Enabled = true;
            cmdBrowseVCS.Enabled = true;
            cmdSendVCS.Enabled = true;
        }

        private void cmdBrowseVCF_Click(object sender, EventArgs e)
        {
            var OpenFileDialogVCF = new OpenFileDialog();
            OpenFileDialogVCF.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            OpenFileDialogVCF.Filter = "vCalendar files (*.vcf)|*.vcf";
            OpenFileDialogVCF.RestoreDirectory = true;
            OpenFileDialogVCF.Multiselect = false;
            OpenFileDialogVCF.Title = "Select vCard file";
            OpenFileDialogVCF.ShowDialog();
            txtVCFFile.Text = OpenFileDialogVCF.FileName;
        }

        private void cmdSendVCF_Click(object sender, EventArgs e)
        {
            vCard objVCARD = objSMS.vCard();

            try
            {
                cmdSendVCF.Text = "Sending...";
                txtVCFFile.Enabled = false;
                cmdBrowseVCF.Enabled = false;
                cmdSendVCF.Enabled = false;

                objVCARD.Destination = txtPhoneVCF.Text;
                objVCARD.SendFile(txtVCFFile.Text);

                MessageBox.Show("vCard Sent!", strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (vCardException ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (GeneralException ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            cmdSendVCF.Text = "Send";
            txtVCFFile.Enabled = true;
            cmdBrowseVCF.Enabled = true;
            cmdSendVCF.Enabled = true;
        }


        private void chkSMSQueue_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSMSQueue.Checked)
            {
                cboSMSQPriority.Enabled = true;
                lblSMSQPriority.Enabled = true;
            }
            else
            {
                cboSMSQPriority.Enabled = false;
                lblSMSQPriority.Enabled = false;
            }
        }


        private void objSMS_QueueSMSSent(object sender, QueueSMSSentEventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            lblQueueStatus.Text = "";
            lblQueueCount.Text = "Messages in queue: " + objSMS.Queue().Count;
            CheckForIllegalCrossThreadCalls = true;
            Application.DoEvents();
            if (e.ErrorCode > 0)
            {
                MessageBox.Show(
                    "Message sending from queue failed to " + e.DestinationNumber + "\r\n[Queue Message Key: " +
                    e.QueueMessageKey + "]\r\nERROR " + e.ErrorCode + ": " + e.ErrorDescription,
                    "Message Sending FAILED", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(
                    "Message from queue sent to: " + e.DestinationNumber + "\r\n[Queue Message Key: " +
                    e.QueueMessageKey + "]", "Message SENT", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void objSMS_QueueSMSSending(object sender, QueueSMSSendingEventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            lblQueueStatus.Text = "Sending to:" + e.DestinationNumber + "\r\n[Key:" + e.QueueMessageKey + "]";
            CheckForIllegalCrossThreadCalls = true;
            Application.DoEvents();
        }


        private void cmdClearQueue_Click(object sender, EventArgs e)
        {
            objSMS.Queue().Clear();
            CheckForIllegalCrossThreadCalls = false;
            lblQueueCount.Text = "Messages in queue: " + objSMS.Queue().Count;
            CheckForIllegalCrossThreadCalls = true;
            Application.DoEvents();
        }


        private void chkQueue_CheckedChanged(object sender, EventArgs e)
        {
            chkQueue.Enabled = false;
            try
            {
                objSMS.Queue().Enabled = chkQueue.Checked;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            chkQueue.Checked = objSMS.Queue().Enabled;
            chkQueue.Enabled = true;
        }

        private void chkDisableCheckPIN_CheckedChanged(object sender, EventArgs e)
        {
            objSMS.DisableCheckPIN = chkDisableCheckPIN.Checked;
        }

        private void cmdUSSD_Click(object sender, EventArgs e)
        {
            try
            {
                cmdUSSD.Enabled = false;
                cmdUSSD.Text = "Sending...";
                SetCommParameters();

                if (!objSMS.SendUSSD(txtUSSDCommand.Text))
                {
                    MessageBox.Show("Error sending USSD command!", "USSD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmdUSSD.Text = "Send";
                cmdUSSD.Enabled = true;
            }
        }

        private void chkUSSD_CheckedChanged(object sender, EventArgs e)
        {
            objSMS.NewUSSDIndication = chkUSSD.Checked;
        }

        private void objSMS_NewUSSDReceived(object sender, NewUSSDReceivedEventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            txtUSSDMessage.Text = e.Message.Replace("\n", "\r\n").Replace("\r\r", "\r");
            lblUSSDStatus.Text = "STATUS: " + e.Status;
            CheckForIllegalCrossThreadCalls = true;
        }

        private void cmdSendSmartSMS_Click(object sender, EventArgs e)
        {
            try
            {
                cmdSendSmartSMS.Enabled = false;
                cmdSendSmartSMS.Text = "Sending...";
                SetCommParameters();

                objSMS.SendSmartMessage(txtDestinationPhone.Text.Trim(), txtSmartText.Text,
                                        Convert.ToInt32(nudDestinationPort.Value));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, strMyAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmdSendSmartSMS.Text = "Send";
                cmdSendSmartSMS.Enabled = true;
            }
        }
    }
}