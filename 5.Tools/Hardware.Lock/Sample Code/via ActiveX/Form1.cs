using System;
using System.ComponentModel;
using System.Windows.Forms;
using NovinAfzar;

namespace CSTestLock
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class fclsTestLock : Form
    {

        #region Form Fields
        private Button btnGetDataBlock;
        private Button btnGetDataByte;
        private Button btnGetDecryption;
        private Button btnGetEncryption;
        private Button btnGetMemorySize;
        private Button btnGetNET;
        private Button btnGetPID;
        private Button btnGetSerial;
        private Button btnGetVersion;
        private Button btnSetDataBlock;
        private Button btnSetDataByte;
        private ComboBox cboDevicess;
        private IContainer components;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private ImageList imgIcon;
        private Label label1;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label17;
        private Label label18;
        private Label label19;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox lblGetDataBlock;
        private Label lblGetDataByte;
        private Label lblStatus;
        private RadioButton rdbCharacter;
        private RadioButton rdbCharacter2;
        private RadioButton rdbCharacter3;
        private RadioButton rdbDecimal;
        private RadioButton rdbDecimal2;
        private RadioButton rdbDecimal3;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage5;
        private Timer tmrStatus;
        private TextBox txtAddress;
        private TextBox txtCData;
        private TextBox txtDataLen;
        private TextBox txtPData;
        private TextBox txtPWD;
        private TextBox txtRepetition;
        private TextBox txtSAddress;
        private TextBox txtSetDataBlock;
        private TextBox txtSetDataByte;
        private TextBox lblNET;
        private TextBox lblPID;
        private TextBox lblMemorySize;
        private TextBox lblVersion;
        private TextBox lblSerial;
        private TextBox txtCounter;
        private Label label16;
        private Button btnGetCounter;
        private Button btnAddCounter;
        private TextBox txtVID;
        #endregion

        #region Ctor
        public fclsTestLock()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.DoEvents();
            Application.Run(new fclsTestLock());
        }
        #endregion

        private readonly clsHIDLock NovinLock = new clsHIDLock();
        private int DevCnt;

        #region Form_Load
        private void Form_Load(object sender, EventArgs e)
        {
            NovinLock.Init();
            tmrStatus_Tick(null, null);
        }
        #endregion

        #region tmrStatus_Tick
        private void tmrStatus_Tick(object sender, EventArgs e)
        {
            if (NovinLock.GetDeviceCount() != DevCnt)
            {
                DevCnt = NovinLock.GetDeviceCount();
                cboDevicess.Items.Clear();
                NovinLock.GetFirstDevice();
                while (NovinLock.ErrNo == 0)
                {
                    if (!String.IsNullOrEmpty(NovinLock.DeviceSerial))
                        cboDevicess.Items.Add(NovinLock.DeviceSerial);
                    NovinLock.GetNextDevice();
                }
            }
            string sStatus;
            NovinLock.GetDeviceReady();
            if (NovinLock.ErrNo == 0)
            {
                lblStatus.ImageIndex = 1;
                sStatus = "ready.";
            }
            else
            {
                lblStatus.ImageIndex = 0;
                sStatus = "not ready.";
            }
            lblStatus.Text = "      NovinLock is " + sStatus;
        }
        #endregion

        #region btnGetSerial_Click
        private void btnGetSerial_Click(object sender, EventArgs e)
        {
            String sTemp = NovinLock.GetSerial();
            lblSerial.Text = sTemp;
            MessageBox.Show(NovinLock.ErrDescrFA);
        }
        #endregion

        #region btnGetVersion_Click
        private void btnGetVersion_Click(object sender, EventArgs e)
        {
            String sTemp = NovinLock.GetVersion();
            lblVersion.Text = sTemp;
            MessageBox.Show(NovinLock.ErrDescrFA);
        }
        #endregion

        #region btnGetMemorySize_Click
        private void btnGetMemorySize_Click(object sender, EventArgs e)
        {
            String sTemp = NovinLock.GetMemorySizeEx();
            if (NovinLock.ErrNo != 0)
                lblMemorySize.Text = "-";
            else
                lblMemorySize.Text = sTemp;
            MessageBox.Show(NovinLock.ErrDescrFA);
        }
        #endregion

        #region btnGetPID_Click
        private void btnGetPID_Click(object sender, EventArgs e)
        {
            String sVID = txtVID.Text;
            String sPWD = NovinLock.ConvStringToDelimiteredString(txtPWD.Text, txtPWD.Text.Length, ".");
            lblPID.Text = NovinLock.GetPID(sVID, sPWD);
            MessageBox.Show(NovinLock.ErrDescrFA);
        }
        #endregion

        #region btnGetNET_Click
        private void btnGetNET_Click(object sender, EventArgs e)
        {
            int bTemp = NovinLock.GetNET();
            lblNET.Text = bTemp.ToString();
            MessageBox.Show(NovinLock.ErrDescrFA);
        }
        #endregion

        #region btnGetCounter_Click
        private void btnGetCounter_Click(object sender, EventArgs e)
        {
            txtCounter.Text = NovinLock.GetTimerCounter().ToString();
        }
        #endregion

        #region btnAddCounter_Click
        private void btnAddCounter_Click(object sender, EventArgs e)
        {
            NovinLock.DecreaseCounter();
        }
        #endregion

        #region rdbDecimal_CheckedChanged
        private void rdbDecimal_CheckedChanged(object sender, EventArgs e)
        {
            txtSetDataByte.MaxLength = 3;
        }
        #endregion

        #region rdbCharacter2_CheckedChanged
        private void rdbCharacter2_CheckedChanged(object sender, EventArgs e)
        {
            txtSetDataByte.MaxLength = 1;
        }
        #endregion

        #region btnSetDataByte_Click
        private void btnSetDataByte_Click(object sender, EventArgs e)
        {
            if ((txtAddress.Text == "") || (txtSetDataByte.Text == "")) return;
            String sPWD = NovinLock.ConvStringToDelimiteredString(txtPWD.Text, 16, ".");
            if (txtVID.Text == "") return;
            string sVID = txtVID.Text;


            UInt16 wAddr = Convert.ToUInt16(txtAddress.Text);
            byte bData;
            if (rdbDecimal.Checked) bData = Convert.ToByte(txtSetDataByte.Text);
            else bData = Convert.ToByte(Convert.ToChar(txtSetDataByte.Text));
            NovinLock.SetDataByte(sVID, sPWD, wAddr, bData);
            if (NovinLock.ErrNo == 0) return;
            MessageBox.Show(this, "Error: " + NovinLock.ErrDescr, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        #region btnGetDataByte_Click
        private void btnGetDataByte_Click(object sender, EventArgs e)
        {
            if (txtAddress.Text == "") return;
            string sPWD = NovinLock.ConvStringToDelimiteredString(txtPWD.Text, 16, ".");
            UInt16 wAddr = Convert.ToUInt16(txtAddress.Text);
            if (txtVID.Text == "") return;
            string sVID = txtVID.Text;

            byte bData = NovinLock.GetDataByte(sVID, sPWD, wAddr);
            if (NovinLock.ErrNo == 0)
            {
                if (rdbDecimal.Checked) lblGetDataByte.Text = bData.ToString();
                else lblGetDataByte.Text = Convert.ToChar(bData).ToString();
                return;
            }
            MessageBox.Show(this, "Error: " + NovinLock.ErrDescr, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        #region btnSetDataBlock_Click
        private void btnSetDataBlock_Click(object sender, EventArgs e)
        {
            if ((txtSAddress.Text == "") || (txtDataLen.Text == "")) return;
            if (txtVID.Text == "") return;
            string sVID = txtVID.Text;

            string sPWD = NovinLock.ConvStringToDelimiteredString(txtPWD.Text, 16, ".");
            UInt16 wSAddr = Convert.ToUInt16(txtSAddress.Text);
            UInt16 wDLen = Convert.ToUInt16(txtDataLen.Text);
            NovinLock.SetDataBlockStr(sVID, sPWD, wSAddr, wDLen, txtSetDataBlock.Text, " ");
            if (NovinLock.ErrNo == 0) return;
            MessageBox.Show(this, "Error: " + NovinLock.ErrDescr, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        #region btnGetDataBlock_Click
        private void btnGetDataBlock_Click(object sender, EventArgs e)
        {
            if ((txtSAddress.Text == "") || (txtDataLen.Text == "")) return;
            if (txtVID.Text == "") return;
            string sVID = txtVID.Text;
            string sPWD = NovinLock.ConvStringToDelimiteredString(txtPWD.Text, 16, ".");
            UInt16 wSAddr = Convert.ToUInt16(txtSAddress.Text);
            UInt16 wDLen = Convert.ToUInt16(txtDataLen.Text);
            string DBlockStr = NovinLock.GetDataBlockStr(sVID, sPWD, wSAddr, wDLen);
            lblGetDataBlock.Text = "";
            if (NovinLock.ErrNo == 0)
                lblGetDataBlock.Text = DBlockStr;
            else
            {
                MessageBox.Show(this, "Error: " + NovinLock.ErrNo + " - " + 
                    NovinLock.ErrDescrFA, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region btnGetEncryption_Click
        private void btnGetEncryption_Click(object sender, EventArgs e)
        {
            if (txtRepetition.Text == "") return;
            string sPData;
            if (txtVID.Text == "") return;
            string sVID = txtVID.Text;
            UInt16 wRepit = Convert.ToUInt16(txtRepetition.Text);
            string sPWD = NovinLock.ConvStringToDelimiteredString(txtPWD.Text, 16, ".");
            if (rdbDecimal3.Checked)
                sPData = txtPData.Text;
            else
                sPData = NovinLock.ConvStringToDelimiteredString(txtPData.Text, 16, ".");

            tmrStatus.Enabled = false;
            string sCData = NovinLock.GetEncryption(sVID, sPWD, sPData, wRepit);
            tmrStatus.Enabled = true;

            if (NovinLock.ErrNo == 0)
            {
                txtCData.Text = sCData;
                MessageBox.Show(txtCData.Text.Length.ToString());
                return;
            }
            MessageBox.Show(this, "Error: " + NovinLock.ErrDescr, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        #region btnGetDecryption_Click
        private void btnGetDecryption_Click(object sender, EventArgs e)
        {
            if (txtRepetition.Text == "") return;

            if (txtVID.Text == "") return;
            string sVID = txtVID.Text;

            UInt16 wRepit = Convert.ToUInt16(txtRepetition.Text);
            string sPWD = NovinLock.ConvStringToDelimiteredString(txtPWD.Text, 16, ".");
            string sCData = txtCData.Text;

            tmrStatus.Enabled = false;
            string sPData = NovinLock.GetDecryption(sVID, sPWD, sCData, wRepit);
            tmrStatus.Enabled = true;

            if (NovinLock.ErrNo == 0)
            {
                if (rdbDecimal3.Checked)
                    txtCData.Text = sPData;
                else
                {
                    string sTemp = NovinLock.ConvDelimiteredStringToString(sPData, 16, ".");
                    txtPData.Text = sTemp;
                }
                return;
            }
            MessageBox.Show(this, "Error: " + NovinLock.ErrDescr, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        #region cbxDevs_SelectedIndexChanged
        private void cbxDevs_SelectedIndexChanged(object sender, EventArgs e)
        {
            NovinLock.SelectDevice(cboDevicess.Items[cboDevicess.SelectedIndex].ToString());
        }
        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fclsTestLock));
            this.label1 = new System.Windows.Forms.Label();
            this.txtVID = new System.Windows.Forms.TextBox();
            this.txtPWD = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtCounter = new System.Windows.Forms.TextBox();
            this.lblNET = new System.Windows.Forms.TextBox();
            this.lblPID = new System.Windows.Forms.TextBox();
            this.lblMemorySize = new System.Windows.Forms.TextBox();
            this.lblVersion = new System.Windows.Forms.TextBox();
            this.lblSerial = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnAddCounter = new System.Windows.Forms.Button();
            this.btnGetCounter = new System.Windows.Forms.Button();
            this.btnGetNET = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.btnGetPID = new System.Windows.Forms.Button();
            this.btnGetSerial = new System.Windows.Forms.Button();
            this.btnGetMemorySize = new System.Windows.Forms.Button();
            this.btnGetVersion = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdbCharacter2 = new System.Windows.Forms.RadioButton();
            this.rdbDecimal2 = new System.Windows.Forms.RadioButton();
            this.btnGetDataBlock = new System.Windows.Forms.Button();
            this.btnSetDataBlock = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.lblGetDataBlock = new System.Windows.Forms.TextBox();
            this.txtSetDataBlock = new System.Windows.Forms.TextBox();
            this.txtDataLen = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbCharacter = new System.Windows.Forms.RadioButton();
            this.rdbDecimal = new System.Windows.Forms.RadioButton();
            this.btnSetDataByte = new System.Windows.Forms.Button();
            this.txtSetDataByte = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnGetDataByte = new System.Windows.Forms.Button();
            this.lblGetDataByte = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rdbCharacter3 = new System.Windows.Forms.RadioButton();
            this.rdbDecimal3 = new System.Windows.Forms.RadioButton();
            this.btnGetDecryption = new System.Windows.Forms.Button();
            this.btnGetEncryption = new System.Windows.Forms.Button();
            this.txtCData = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtPData = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtRepetition = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.imgIcon = new System.Windows.Forms.ImageList(this.components);
            this.tmrStatus = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cboDevicess = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter the VID (Vendor ID):";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtVID
            // 
            this.txtVID.Location = new System.Drawing.Point(179, 20);
            this.txtVID.MaxLength = 15;
            this.txtVID.Name = "txtVID";
            this.txtVID.Size = new System.Drawing.Size(128, 21);
            this.txtVID.TabIndex = 0;
            this.txtVID.Text = "109.232.151.58";
            // 
            // txtPWD
            // 
            this.txtPWD.Location = new System.Drawing.Point(179, 45);
            this.txtPWD.MaxLength = 16;
            this.txtPWD.Name = "txtPWD";
            this.txtPWD.PasswordChar = '*';
            this.txtPWD.Size = new System.Drawing.Size(128, 21);
            this.txtPWD.TabIndex = 1;
            this.txtPWD.Text = "500malekolmot500";
            this.txtPWD.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(10, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Enter the Developer Password:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(80, 22);
            this.tabControl1.Location = new System.Drawing.Point(0, 80);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(12, 3);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(573, 298);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtCounter);
            this.tabPage1.Controls.Add(this.lblNET);
            this.tabPage1.Controls.Add(this.lblPID);
            this.tabPage1.Controls.Add(this.lblMemorySize);
            this.tabPage1.Controls.Add(this.lblVersion);
            this.tabPage1.Controls.Add(this.lblSerial);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.btnAddCounter);
            this.tabPage1.Controls.Add(this.btnGetCounter);
            this.tabPage1.Controls.Add(this.btnGetNET);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.btnGetPID);
            this.tabPage1.Controls.Add(this.btnGetSerial);
            this.tabPage1.Controls.Add(this.btnGetMemorySize);
            this.tabPage1.Controls.Add(this.btnGetVersion);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(565, 268);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtCounter
            // 
            this.txtCounter.Location = new System.Drawing.Point(197, 191);
            this.txtCounter.Name = "txtCounter";
            this.txtCounter.Size = new System.Drawing.Size(100, 21);
            this.txtCounter.TabIndex = 15;
            // 
            // lblNET
            // 
            this.lblNET.Location = new System.Drawing.Point(197, 158);
            this.lblNET.Name = "lblNET";
            this.lblNET.Size = new System.Drawing.Size(100, 21);
            this.lblNET.TabIndex = 15;
            // 
            // lblPID
            // 
            this.lblPID.Location = new System.Drawing.Point(197, 120);
            this.lblPID.Name = "lblPID";
            this.lblPID.Size = new System.Drawing.Size(100, 21);
            this.lblPID.TabIndex = 15;
            // 
            // lblMemorySize
            // 
            this.lblMemorySize.Location = new System.Drawing.Point(197, 83);
            this.lblMemorySize.Name = "lblMemorySize";
            this.lblMemorySize.Size = new System.Drawing.Size(100, 21);
            this.lblMemorySize.TabIndex = 15;
            // 
            // lblVersion
            // 
            this.lblVersion.Location = new System.Drawing.Point(197, 48);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(100, 21);
            this.lblVersion.TabIndex = 15;
            // 
            // lblSerial
            // 
            this.lblSerial.Location = new System.Drawing.Point(197, 16);
            this.lblSerial.Name = "lblSerial";
            this.lblSerial.Size = new System.Drawing.Size(100, 21);
            this.lblSerial.TabIndex = 15;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(30, 189);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(161, 25);
            this.label16.TabIndex = 13;
            this.label16.Text = "Lock Counter:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(30, 156);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(161, 25);
            this.label13.TabIndex = 13;
            this.label13.Text = "NET (Maximum network users):";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAddCounter
            // 
            this.btnAddCounter.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAddCounter.Location = new System.Drawing.Point(409, 188);
            this.btnAddCounter.Name = "btnAddCounter";
            this.btnAddCounter.Size = new System.Drawing.Size(100, 27);
            this.btnAddCounter.TabIndex = 4;
            this.btnAddCounter.Text = "Decrese Counter";
            this.btnAddCounter.Click += new System.EventHandler(this.btnAddCounter_Click);
            // 
            // btnGetCounter
            // 
            this.btnGetCounter.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnGetCounter.Location = new System.Drawing.Point(303, 188);
            this.btnGetCounter.Name = "btnGetCounter";
            this.btnGetCounter.Size = new System.Drawing.Size(100, 27);
            this.btnGetCounter.TabIndex = 4;
            this.btnGetCounter.Text = "Get Counter";
            this.btnGetCounter.Click += new System.EventHandler(this.btnGetCounter_Click);
            // 
            // btnGetNET
            // 
            this.btnGetNET.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnGetNET.Location = new System.Drawing.Point(303, 155);
            this.btnGetNET.Name = "btnGetNET";
            this.btnGetNET.Size = new System.Drawing.Size(100, 27);
            this.btnGetNET.TabIndex = 4;
            this.btnGetNET.Text = "GetNET";
            this.btnGetNET.Click += new System.EventHandler(this.btnGetNET_Click);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(101, 118);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 25);
            this.label11.TabIndex = 10;
            this.label11.Text = "PID (Product ID):";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnGetPID
            // 
            this.btnGetPID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnGetPID.Location = new System.Drawing.Point(303, 117);
            this.btnGetPID.Name = "btnGetPID";
            this.btnGetPID.Size = new System.Drawing.Size(100, 27);
            this.btnGetPID.TabIndex = 3;
            this.btnGetPID.Text = "GetPID";
            this.btnGetPID.Click += new System.EventHandler(this.btnGetPID_Click);
            // 
            // btnGetSerial
            // 
            this.btnGetSerial.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnGetSerial.Location = new System.Drawing.Point(303, 13);
            this.btnGetSerial.Name = "btnGetSerial";
            this.btnGetSerial.Size = new System.Drawing.Size(100, 27);
            this.btnGetSerial.TabIndex = 0;
            this.btnGetSerial.Text = "GetSerial";
            this.btnGetSerial.Click += new System.EventHandler(this.btnGetSerial_Click);
            // 
            // btnGetMemorySize
            // 
            this.btnGetMemorySize.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnGetMemorySize.Location = new System.Drawing.Point(303, 80);
            this.btnGetMemorySize.Name = "btnGetMemorySize";
            this.btnGetMemorySize.Size = new System.Drawing.Size(100, 27);
            this.btnGetMemorySize.TabIndex = 2;
            this.btnGetMemorySize.Text = "GetMemorySize";
            this.btnGetMemorySize.Click += new System.EventHandler(this.btnGetMemorySize_Click);
            // 
            // btnGetVersion
            // 
            this.btnGetVersion.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnGetVersion.Location = new System.Drawing.Point(303, 45);
            this.btnGetVersion.Name = "btnGetVersion";
            this.btnGetVersion.Size = new System.Drawing.Size(100, 27);
            this.btnGetVersion.TabIndex = 1;
            this.btnGetVersion.Text = "GetVersion";
            this.btnGetVersion.Click += new System.EventHandler(this.btnGetVersion_Click);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(111, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 25);
            this.label9.TabIndex = 7;
            this.label9.Text = "Serial#:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(111, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 25);
            this.label7.TabIndex = 4;
            this.label7.Text = "Memory Size:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(111, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 25);
            this.label4.TabIndex = 1;
            this.label4.Text = "Version#:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Controls.Add(this.btnGetDataBlock);
            this.tabPage3.Controls.Add(this.btnSetDataBlock);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.lblGetDataBlock);
            this.tabPage3.Controls.Add(this.txtSetDataBlock);
            this.tabPage3.Controls.Add(this.txtDataLen);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.txtSAddress);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(565, 268);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Read Data By Block";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdbCharacter2);
            this.groupBox3.Controls.Add(this.rdbDecimal2);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox3.Location = new System.Drawing.Point(360, 10);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(195, 50);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Data View";
            // 
            // rdbCharacter2
            // 
            this.rdbCharacter2.Checked = true;
            this.rdbCharacter2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rdbCharacter2.Location = new System.Drawing.Point(105, 15);
            this.rdbCharacter2.Name = "rdbCharacter2";
            this.rdbCharacter2.Size = new System.Drawing.Size(80, 24);
            this.rdbCharacter2.TabIndex = 1;
            this.rdbCharacter2.TabStop = true;
            this.rdbCharacter2.Text = "Character";
            // 
            // rdbDecimal2
            // 
            this.rdbDecimal2.Enabled = false;
            this.rdbDecimal2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rdbDecimal2.Location = new System.Drawing.Point(15, 15);
            this.rdbDecimal2.Name = "rdbDecimal2";
            this.rdbDecimal2.Size = new System.Drawing.Size(75, 24);
            this.rdbDecimal2.TabIndex = 0;
            this.rdbDecimal2.Text = "Decimal";
            // 
            // btnGetDataBlock
            // 
            this.btnGetDataBlock.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnGetDataBlock.Location = new System.Drawing.Point(96, 205);
            this.btnGetDataBlock.Name = "btnGetDataBlock";
            this.btnGetDataBlock.Size = new System.Drawing.Size(100, 27);
            this.btnGetDataBlock.TabIndex = 24;
            this.btnGetDataBlock.Text = "GetDataBlock";
            this.btnGetDataBlock.Click += new System.EventHandler(this.btnGetDataBlock_Click);
            // 
            // btnSetDataBlock
            // 
            this.btnSetDataBlock.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSetDataBlock.Location = new System.Drawing.Point(361, 205);
            this.btnSetDataBlock.Name = "btnSetDataBlock";
            this.btnSetDataBlock.Size = new System.Drawing.Size(100, 27);
            this.btnSetDataBlock.TabIndex = 23;
            this.btnSetDataBlock.Text = "SetDataBlock";
            this.btnSetDataBlock.Click += new System.EventHandler(this.btnSetDataBlock_Click);
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(3, 70);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(115, 25);
            this.label14.TabIndex = 22;
            this.label14.Text = "Data Block (Read):";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblGetDataBlock
            // 
            this.lblGetDataBlock.Location = new System.Drawing.Point(21, 95);
            this.lblGetDataBlock.MaxLength = 512;
            this.lblGetDataBlock.Multiline = true;
            this.lblGetDataBlock.Name = "lblGetDataBlock";
            this.lblGetDataBlock.ReadOnly = true;
            this.lblGetDataBlock.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.lblGetDataBlock.Size = new System.Drawing.Size(250, 100);
            this.lblGetDataBlock.TabIndex = 21;
            // 
            // txtSetDataBlock
            // 
            this.txtSetDataBlock.Location = new System.Drawing.Point(286, 95);
            this.txtSetDataBlock.MaxLength = 400;
            this.txtSetDataBlock.Multiline = true;
            this.txtSetDataBlock.Name = "txtSetDataBlock";
            this.txtSetDataBlock.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSetDataBlock.Size = new System.Drawing.Size(250, 100);
            this.txtSetDataBlock.TabIndex = 19;
            // 
            // txtDataLen
            // 
            this.txtDataLen.Location = new System.Drawing.Point(120, 43);
            this.txtDataLen.MaxLength = 3;
            this.txtDataLen.Name = "txtDataLen";
            this.txtDataLen.Size = new System.Drawing.Size(100, 21);
            this.txtDataLen.TabIndex = 18;
            this.txtDataLen.Text = "400";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(2, 40);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(115, 25);
            this.label10.TabIndex = 17;
            this.label10.Text = "Data Length:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSAddress
            // 
            this.txtSAddress.Location = new System.Drawing.Point(120, 18);
            this.txtSAddress.MaxLength = 3;
            this.txtSAddress.Name = "txtSAddress";
            this.txtSAddress.Size = new System.Drawing.Size(100, 21);
            this.txtSAddress.TabIndex = 16;
            this.txtSAddress.Text = "0";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(5, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 25);
            this.label3.TabIndex = 15;
            this.label3.Text = "Start Address:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(268, 70);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(115, 25);
            this.label12.TabIndex = 20;
            this.label12.Text = "Data Block (Write):";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.btnSetDataByte);
            this.tabPage2.Controls.Add(this.txtSetDataByte);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.txtAddress);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.btnGetDataByte);
            this.tabPage2.Controls.Add(this.lblGetDataByte);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(565, 268);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Read Data By Byte";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbCharacter);
            this.groupBox2.Controls.Add(this.rdbDecimal);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox2.Location = new System.Drawing.Point(18, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(195, 50);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data View";
            // 
            // rdbCharacter
            // 
            this.rdbCharacter.Checked = true;
            this.rdbCharacter.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rdbCharacter.Location = new System.Drawing.Point(105, 15);
            this.rdbCharacter.Name = "rdbCharacter";
            this.rdbCharacter.Size = new System.Drawing.Size(80, 24);
            this.rdbCharacter.TabIndex = 1;
            this.rdbCharacter.TabStop = true;
            this.rdbCharacter.Text = "Character";
            this.rdbCharacter.CheckedChanged += new System.EventHandler(this.rdbCharacter2_CheckedChanged);
            // 
            // rdbDecimal
            // 
            this.rdbDecimal.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rdbDecimal.Location = new System.Drawing.Point(15, 15);
            this.rdbDecimal.Name = "rdbDecimal";
            this.rdbDecimal.Size = new System.Drawing.Size(75, 24);
            this.rdbDecimal.TabIndex = 0;
            this.rdbDecimal.Text = "Decimal";
            this.rdbDecimal.CheckedChanged += new System.EventHandler(this.rdbDecimal_CheckedChanged);
            // 
            // btnSetDataByte
            // 
            this.btnSetDataByte.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSetDataByte.Location = new System.Drawing.Point(235, 108);
            this.btnSetDataByte.Name = "btnSetDataByte";
            this.btnSetDataByte.Size = new System.Drawing.Size(100, 27);
            this.btnSetDataByte.TabIndex = 8;
            this.btnSetDataByte.Text = "SetDataByte";
            this.btnSetDataByte.Click += new System.EventHandler(this.btnSetDataByte_Click);
            // 
            // txtSetDataByte
            // 
            this.txtSetDataByte.Location = new System.Drawing.Point(130, 111);
            this.txtSetDataByte.MaxLength = 3;
            this.txtSetDataByte.Name = "txtSetDataByte";
            this.txtSetDataByte.Size = new System.Drawing.Size(100, 21);
            this.txtSetDataByte.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(15, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 25);
            this.label6.TabIndex = 15;
            this.label6.Text = "Data Byte (Write):";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(130, 76);
            this.txtAddress.MaxLength = 3;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(100, 21);
            this.txtAddress.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(13, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 25);
            this.label8.TabIndex = 12;
            this.label8.Text = "Address:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnGetDataByte
            // 
            this.btnGetDataByte.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnGetDataByte.Location = new System.Drawing.Point(235, 143);
            this.btnGetDataByte.Name = "btnGetDataByte";
            this.btnGetDataByte.Size = new System.Drawing.Size(100, 27);
            this.btnGetDataByte.TabIndex = 9;
            this.btnGetDataByte.Text = "GetDataByte";
            this.btnGetDataByte.Click += new System.EventHandler(this.btnGetDataByte_Click);
            // 
            // lblGetDataByte
            // 
            this.lblGetDataByte.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblGetDataByte.Location = new System.Drawing.Point(130, 146);
            this.lblGetDataByte.Name = "lblGetDataByte";
            this.lblGetDataByte.Size = new System.Drawing.Size(100, 22);
            this.lblGetDataByte.TabIndex = 11;
            this.lblGetDataByte.Text = "-";
            this.lblGetDataByte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(15, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 25);
            this.label5.TabIndex = 10;
            this.label5.Text = "Data Byte (Read):";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.groupBox4);
            this.tabPage5.Controls.Add(this.btnGetDecryption);
            this.tabPage5.Controls.Add(this.btnGetEncryption);
            this.tabPage5.Controls.Add(this.txtCData);
            this.tabPage5.Controls.Add(this.label19);
            this.tabPage5.Controls.Add(this.txtPData);
            this.tabPage5.Controls.Add(this.label18);
            this.tabPage5.Controls.Add(this.txtRepetition);
            this.tabPage5.Controls.Add(this.label17);
            this.tabPage5.Location = new System.Drawing.Point(4, 26);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(565, 268);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "AES Encryption Helper";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rdbCharacter3);
            this.groupBox4.Controls.Add(this.rdbDecimal3);
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox4.Location = new System.Drawing.Point(360, 10);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(195, 50);
            this.groupBox4.TabIndex = 26;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Data View";
            // 
            // rdbCharacter3
            // 
            this.rdbCharacter3.Checked = true;
            this.rdbCharacter3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rdbCharacter3.Location = new System.Drawing.Point(105, 15);
            this.rdbCharacter3.Name = "rdbCharacter3";
            this.rdbCharacter3.Size = new System.Drawing.Size(80, 24);
            this.rdbCharacter3.TabIndex = 1;
            this.rdbCharacter3.TabStop = true;
            this.rdbCharacter3.Text = "Character";
            // 
            // rdbDecimal3
            // 
            this.rdbDecimal3.Enabled = false;
            this.rdbDecimal3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rdbDecimal3.Location = new System.Drawing.Point(15, 15);
            this.rdbDecimal3.Name = "rdbDecimal3";
            this.rdbDecimal3.Size = new System.Drawing.Size(75, 24);
            this.rdbDecimal3.TabIndex = 0;
            this.rdbDecimal3.Text = "Decimal";
            // 
            // btnGetDecryption
            // 
            this.btnGetDecryption.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnGetDecryption.Location = new System.Drawing.Point(450, 115);
            this.btnGetDecryption.Name = "btnGetDecryption";
            this.btnGetDecryption.Size = new System.Drawing.Size(100, 27);
            this.btnGetDecryption.TabIndex = 23;
            this.btnGetDecryption.Text = "GetDecryption";
            this.btnGetDecryption.Click += new System.EventHandler(this.btnGetDecryption_Click);
            // 
            // btnGetEncryption
            // 
            this.btnGetEncryption.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnGetEncryption.Location = new System.Drawing.Point(450, 80);
            this.btnGetEncryption.Name = "btnGetEncryption";
            this.btnGetEncryption.Size = new System.Drawing.Size(100, 27);
            this.btnGetEncryption.TabIndex = 21;
            this.btnGetEncryption.Text = "GetEncryption";
            this.btnGetEncryption.Click += new System.EventHandler(this.btnGetEncryption_Click);
            // 
            // txtCData
            // 
            this.txtCData.Location = new System.Drawing.Point(130, 118);
            this.txtCData.MaxLength = 100;
            this.txtCData.Name = "txtCData";
            this.txtCData.Size = new System.Drawing.Size(315, 21);
            this.txtCData.TabIndex = 20;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(-4, 115);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(135, 25);
            this.label19.TabIndex = 19;
            this.label19.Text = "Cipher Data (DNString):";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPData
            // 
            this.txtPData.Location = new System.Drawing.Point(130, 83);
            this.txtPData.MaxLength = 100;
            this.txtPData.Name = "txtPData";
            this.txtPData.Size = new System.Drawing.Size(315, 21);
            this.txtPData.TabIndex = 18;
            this.txtPData.Text = "TheAdminPassword";
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(15, 80);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(115, 25);
            this.label18.TabIndex = 17;
            this.label18.Text = "Plain Data (String):";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRepetition
            // 
            this.txtRepetition.Location = new System.Drawing.Point(130, 48);
            this.txtRepetition.MaxLength = 3;
            this.txtRepetition.Name = "txtRepetition";
            this.txtRepetition.Size = new System.Drawing.Size(100, 21);
            this.txtRepetition.TabIndex = 16;
            this.txtRepetition.Text = "1";
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(6, 45);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(125, 25);
            this.label17.TabIndex = 15;
            this.label17.Text = "Number of Repetitions:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblStatus
            // 
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStatus.ImageIndex = 0;
            this.lblStatus.ImageList = this.imgIcon;
            this.lblStatus.Location = new System.Drawing.Point(0, 378);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(573, 25);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // imgIcon
            // 
            this.imgIcon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgIcon.ImageStream")));
            this.imgIcon.TransparentColor = System.Drawing.Color.Transparent;
            this.imgIcon.Images.SetKeyName(0, "");
            this.imgIcon.Images.SetKeyName(1, "");
            // 
            // tmrStatus
            // 
            this.tmrStatus.Enabled = true;
            this.tmrStatus.Interval = 500;
            this.tmrStatus.Tick += new System.EventHandler(this.tmrStatus_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.cboDevicess);
            this.groupBox1.Controls.Add(this.txtVID);
            this.groupBox1.Controls.Add(this.txtPWD);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(573, 80);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Verification";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(328, 24);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(62, 13);
            this.label15.TabIndex = 4;
            this.label15.Text = "Device List:";
            // 
            // cboDevicess
            // 
            this.cboDevicess.FormattingEnabled = true;
            this.cboDevicess.Location = new System.Drawing.Point(397, 19);
            this.cboDevicess.Name = "cboDevicess";
            this.cboDevicess.Size = new System.Drawing.Size(164, 21);
            this.cboDevicess.TabIndex = 3;
            this.cboDevicess.SelectedIndexChanged += new System.EventHandler(this.cbxDevs_SelectedIndexChanged);
            // 
            // fclsTestLock
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.ClientSize = new System.Drawing.Size(573, 403);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblStatus);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "fclsTestLock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aftab Test Application for Hardware Lock";
            this.Load += new System.EventHandler(this.Form_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

    }
}