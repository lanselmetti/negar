#region using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using NovinAfzar;

#endregion using

namespace CSTestLock
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class fclsTestLock : Form
    {
        #region Form Fields

        private ComboBox cboDevicess;
        private IContainer components;
        private GroupBox groupBox1;
        private ImageList imgIcon;
        private Label label1;
        private Label label11;
        private Label label15;
        private Label label2;
        private Label label4;
        private Label lblStatus;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private Timer tmrStatus;
        private TextBox txtPWD;
        private TextBox lblPID;
        private TextBox lblVersion;
        private TextBox txtCounter;
        private Label label16;
        private CheckedListBox lstLicenseList;
        private Button btnSaveLicenseData;
        private Button btnReadLicenseData;
        private ToolTip toolTip1;
        private TabPage tabPage2;
        private RichTextBox txtLicenseText;
        private Button btnGenerateFile;
        private TextBox txtVID;

        #endregion Form Fields

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

        #endregion Ctor

        private readonly clsHIDLock _LockObject = new clsHIDLock();
        private int DevCnt;

        #region Form_Load
        private void Form_Load(object sender, EventArgs e)
        {
            _LockObject.Init();
            Text += " - نسخه: " + Assembly.GetExecutingAssembly().GetName().Version;
        }
        #endregion Form_Load

        #region tmrStatus_Tick
        private void tmrStatus_Tick(object sender, EventArgs e)
        {
            Int32 DevCount = _LockObject.GetDeviceCount();
            if (DevCount != DevCnt)
            {
                DevCnt = _LockObject.GetDeviceCount();
                cboDevicess.Items.Clear();
                _LockObject.GetFirstDevice();
                if (_LockObject.ErrNo == 0 && !String.IsNullOrEmpty(_LockObject.DeviceSerial))
                    cboDevicess.Items.Add(_LockObject.DeviceSerial);
                else return;
                if (cboDevicess.Items.Count != 0) cboDevicess.SelectedIndex = 0;
            }
            string sStatus;
            _LockObject.GetDeviceReady();
            if (_LockObject.ErrNo == 0)
            {
                lblStatus.ImageIndex = 1;
                sStatus = "آماده.";
            }
            else
            {
                lblStatus.ImageIndex = 0;
                sStatus = "غیر آماده.";
            }
            lblStatus.Text = "        وضعیت قفل: " + sStatus;
        }

        #endregion tmrStatus_Tick

        #region GetVersion

        private void GetVersion()
        {
            String sTemp = _LockObject.GetVersion();
            lblVersion.Text = sTemp;
            if (_LockObject.ErrNo != 0) MessageBox.Show(_LockObject.ErrDescrFA);
        }

        #endregion GetVersion

        #region GetPID

        private void GetPID()
        {
            String sVID = txtVID.Text.Trim();
            String sPWD = _LockObject.ConvStringToDelimiteredString(txtPWD.Text.Trim(), txtPWD.Text.Length, ".");
            if (String.IsNullOrEmpty(sVID) || String.IsNullOrEmpty(sPWD))
            {
                MessageBox.Show("نام كاربری و كلمه عبور باید وارد گردد.");
                return;
            }
            lblPID.Text = _LockObject.GetPID(sVID, sPWD);
            if (_LockObject.ErrNo != 0) MessageBox.Show(_LockObject.ErrDescrFA);
        }

        #endregion GetPID

        #region GetCounter

        private void GetCounter()
        {
            txtCounter.Text = _LockObject.GetTimerCounter().ToString();
            if (_LockObject.ErrNo != 0 && _LockObject.ErrNo != 56) MessageBox.Show(_LockObject.ErrDescrFA);
        }

        #endregion GetCounter

        #region btnReadLicenseData_Click
        private void btnReadLicenseData_Click(object sender, EventArgs e)
        {
            List<String> LicensesList = new List<String>();
            // در صورتی كه قفل آماده نباشد ، آماده می گردد
            try
            {
                // در صورتی كه قفل آماده نباشد ، آماده می گردد
                // در صورتی كه سریال قفلی كه اولین بار متصل شده با سریال قفل جاری متفاوت باشد خطا بازگردانده می شود
                String PWD = _LockObject.ConvStringToDelimiteredString(txtPWD.Text.Trim(), txtPWD.Text.Trim().Length, ".");
                if (String.IsNullOrEmpty(txtVID.Text.Trim()) || String.IsNullOrEmpty(PWD))
                {
                    MessageBox.Show("نام كاربری و كلمه عبور باید وارد گردد.");
                    return;
                }
                String LicenseListString = _LockObject.GetDataBlockStr(txtVID.Text.Trim(), PWD, 0, 300);
                if (_LockObject.ErrNo != 0) MessageBox.Show(_LockObject.ErrDescrFA);
                if (String.IsNullOrEmpty(LicenseListString)) return;
                for (Int32 i = 0; i < 100; i++)
                {
                    String TheLicense = LicenseListString.Substring(i * 3, 3);
                    if (!String.IsNullOrEmpty(TheLicense.Trim()) && TheLicense.Length == 3)
                        LicensesList.Add(TheLicense);
                }
            }
            catch (Exception) { return; }
            for (Int32 i = 0; i < lstLicenseList.Items.Count; i++)
                lstLicenseList.SetItemChecked(i, false);
            if (LicensesList.Contains("110")) lstLicenseList.SetItemChecked(0, true);
            if (LicensesList.Contains("120")) lstLicenseList.SetItemChecked(1, true);
            if (LicensesList.Contains("515")) lstLicenseList.SetItemChecked(2, true);
            if (LicensesList.Contains("516")) lstLicenseList.SetItemChecked(3, true);
            if (LicensesList.Contains("525")) lstLicenseList.SetItemChecked(4, true);
            if (LicensesList.Contains("526")) lstLicenseList.SetItemChecked(5, true);
            if (LicensesList.Contains("530")) lstLicenseList.SetItemChecked(6, true);
            if (LicensesList.Contains("531")) lstLicenseList.SetItemChecked(7, true);
            if (LicensesList.Contains("540")) lstLicenseList.SetItemChecked(8, true);
            if (LicensesList.Contains("541")) lstLicenseList.SetItemChecked(9, true);
            if (LicensesList.Contains("550")) lstLicenseList.SetItemChecked(10, true);
            if (LicensesList.Contains("551")) lstLicenseList.SetItemChecked(11, true);
            if (LicensesList.Contains("555")) lstLicenseList.SetItemChecked(12, true);
            if (LicensesList.Contains("560")) lstLicenseList.SetItemChecked(13, true);
            if (LicensesList.Contains("561")) lstLicenseList.SetItemChecked(14, true);
            if (LicensesList.Contains("580")) lstLicenseList.SetItemChecked(15, true);
            if (LicensesList.Contains("590")) lstLicenseList.SetItemChecked(16, true);
            if (LicensesList.Contains("591")) lstLicenseList.SetItemChecked(17, true);
            if (LicensesList.Contains("592")) lstLicenseList.SetItemChecked(18, true);
            if (LicensesList.Contains("593")) lstLicenseList.SetItemChecked(19, true);
            if (LicensesList.Contains("594")) lstLicenseList.SetItemChecked(20, true);
            if (LicensesList.Contains("610")) lstLicenseList.SetItemChecked(21, true);
            if (LicensesList.Contains("611")) lstLicenseList.SetItemChecked(22, true);
            if (_LockObject.ErrNo != 0) MessageBox.Show(_LockObject.ErrDescrFA);
        }
        #endregion btnReadLicenseData_Click

        #region btnSaveLicenseData_Click
        private void btnSaveLicenseData_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtVID.Text.Trim()) || String.IsNullOrEmpty(txtPWD.Text.Trim()))
            {
                MessageBox.Show("نام كاربری و كلمه عبور باید وارد گردد.");
                return;
            }
            StringBuilder LicenseString = new StringBuilder();
            if (lstLicenseList.GetItemChecked(0)) LicenseString.Append("110");
            if (lstLicenseList.GetItemChecked(1)) LicenseString.Append("120");
            if (lstLicenseList.GetItemChecked(2)) LicenseString.Append("515");
            if (lstLicenseList.GetItemChecked(3)) LicenseString.Append("516");
            if (lstLicenseList.GetItemChecked(4)) LicenseString.Append("525");
            if (lstLicenseList.GetItemChecked(5)) LicenseString.Append("526");
            if (lstLicenseList.GetItemChecked(6)) LicenseString.Append("530");
            if (lstLicenseList.GetItemChecked(7)) LicenseString.Append("531");
            if (lstLicenseList.GetItemChecked(8)) LicenseString.Append("540");
            if (lstLicenseList.GetItemChecked(9)) LicenseString.Append("541");
            if (lstLicenseList.GetItemChecked(10)) LicenseString.Append("550");
            if (lstLicenseList.GetItemChecked(11)) LicenseString.Append("551");
            if (lstLicenseList.GetItemChecked(12)) LicenseString.Append("555");
            if (lstLicenseList.GetItemChecked(13)) LicenseString.Append("560");
            if (lstLicenseList.GetItemChecked(14)) LicenseString.Append("561");
            if (lstLicenseList.GetItemChecked(15)) LicenseString.Append("580");
            if (lstLicenseList.GetItemChecked(16)) LicenseString.Append("590");
            if (lstLicenseList.GetItemChecked(17)) LicenseString.Append("591");
            if (lstLicenseList.GetItemChecked(18)) LicenseString.Append("592");
            if (lstLicenseList.GetItemChecked(19)) LicenseString.Append("593");
            if (lstLicenseList.GetItemChecked(20)) LicenseString.Append("594");
            if (lstLicenseList.GetItemChecked(21)) LicenseString.Append("610");
            if (lstLicenseList.GetItemChecked(22)) LicenseString.Append("611");
            Int32 LicenseLenght = LicenseString.Length;
            for (Int32 i = 0; i < 300 - LicenseLenght; i++)
                LicenseString.Append(" ");
            String PWD = _LockObject.ConvStringToDelimiteredString(txtPWD.Text, txtPWD.Text.Length, ".");
            _LockObject.SetDataBlockStr(txtVID.Text, PWD, 0, 300, LicenseString.ToString(), " ");
            if (_LockObject.ErrNo != 0) MessageBox.Show(_LockObject.ErrDescrFA);
        }

        #endregion btnSaveLicenseData_Click

        #region btnGenerateFile_Click

        private void btnGenerateFile_Click(object sender, EventArgs e)
        {
            txtLicenseText.Text = String.Empty;
            txtLicenseText.AppendText("سریال قفل: " + cboDevicess.Text + "\n");
            for (Int32 i = 0; i < lstLicenseList.Items.Count; i++)
                if (lstLicenseList.GetItemChecked(i))
                    txtLicenseText.AppendText(lstLicenseList.Items[i] + "\n");
            txtLicenseText.AppendText("==============================\n\n");
            tabControl1.SelectedIndex = 1;
        }

        #endregion btnGenerateFile_Click

        #region cbxDevs_SelectedIndexChanged

        private void cbxDevs_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 Index = cboDevicess.SelectedIndex;
            if (Index >= 0)
            {
                _LockObject.SelectDevice(cboDevicess.Text);
                _LockObject.GetFirstDevice();
                while (Index != 0)
                {
                    _LockObject.GetNextDevice();
                    Index--;
                }
                GetVersion();
                GetCounter();
                if (String.IsNullOrEmpty(txtVID.Text.Trim()) || String.IsNullOrEmpty(txtPWD.Text.Trim()))
                {
                    MessageBox.Show("نام كاربری و كلمه عبور باید وارد گردد.");
                    return;
                }
                GetPID();
                btnReadLicenseData_Click(null, null);
            }
            _LockObject.GetDeviceReady();
        }

        #endregion cbxDevs_SelectedIndexChanged

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
            this.btnGenerateFile = new System.Windows.Forms.Button();
            this.btnSaveLicenseData = new System.Windows.Forms.Button();
            this.btnReadLicenseData = new System.Windows.Forms.Button();
            this.lstLicenseList = new System.Windows.Forms.CheckedListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtLicenseText = new System.Windows.Forms.RichTextBox();
            this.txtCounter = new System.Windows.Forms.TextBox();
            this.lblPID = new System.Windows.Forms.TextBox();
            this.lblVersion = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.imgIcon = new System.Windows.Forms.ImageList(this.components);
            this.tmrStatus = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cboDevicess = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(293, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "كلید عبور:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtVID
            // 
            this.txtVID.Location = new System.Drawing.Point(196, 17);
            this.txtVID.MaxLength = 15;
            this.txtVID.Name = "txtVID";
            this.txtVID.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtVID.Size = new System.Drawing.Size(95, 21);
            this.txtVID.TabIndex = 2;
            this.txtVID.Text = "109.232.151.58";
            this.toolTip1.SetToolTip(this.txtVID, "VID");
            // 
            // txtPWD
            // 
            this.txtPWD.Location = new System.Drawing.Point(12, 17);
            this.txtPWD.MaxLength = 16;
            this.txtPWD.Name = "txtPWD";
            this.txtPWD.PasswordChar = '*';
            this.txtPWD.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPWD.Size = new System.Drawing.Size(128, 21);
            this.txtPWD.TabIndex = 3;
            this.txtPWD.Text = "500malekolmot500";
            this.toolTip1.SetToolTip(this.txtPWD, "Developer Password");
            this.txtPWD.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(143, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "رمز عبور:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(80, 22);
            this.tabControl1.Location = new System.Drawing.Point(0, 77);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(12, 3);
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(646, 448);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnGenerateFile);
            this.tabPage1.Controls.Add(this.btnSaveLicenseData);
            this.tabPage1.Controls.Add(this.btnReadLicenseData);
            this.tabPage1.Controls.Add(this.lstLicenseList);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(638, 418);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "مدیریت لایسنس های قفل";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnGenerateFile
            // 
            this.btnGenerateFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerateFile.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnGenerateFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnGenerateFile.Location = new System.Drawing.Point(8, 116);
            this.btnGenerateFile.Name = "btnGenerateFile";
            this.btnGenerateFile.Size = new System.Drawing.Size(121, 46);
            this.btnGenerateFile.TabIndex = 2;
            this.btnGenerateFile.Text = "تولید فایل خروجی";
            this.btnGenerateFile.UseVisualStyleBackColor = false;
            this.btnGenerateFile.Click += new System.EventHandler(this.btnGenerateFile_Click);
            // 
            // btnSaveLicenseData
            // 
            this.btnSaveLicenseData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveLicenseData.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSaveLicenseData.ForeColor = System.Drawing.Color.Blue;
            this.btnSaveLicenseData.Location = new System.Drawing.Point(8, 64);
            this.btnSaveLicenseData.Name = "btnSaveLicenseData";
            this.btnSaveLicenseData.Size = new System.Drawing.Size(121, 46);
            this.btnSaveLicenseData.TabIndex = 2;
            this.btnSaveLicenseData.Text = "ذخیره تنظیمات انتخاب شده در قفل";
            this.btnSaveLicenseData.UseVisualStyleBackColor = false;
            this.btnSaveLicenseData.Click += new System.EventHandler(this.btnSaveLicenseData_Click);
            // 
            // btnReadLicenseData
            // 
            this.btnReadLicenseData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReadLicenseData.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnReadLicenseData.ForeColor = System.Drawing.Color.Green;
            this.btnReadLicenseData.Location = new System.Drawing.Point(8, 12);
            this.btnReadLicenseData.Name = "btnReadLicenseData";
            this.btnReadLicenseData.Size = new System.Drawing.Size(121, 46);
            this.btnReadLicenseData.TabIndex = 1;
            this.btnReadLicenseData.Text = "خواندن اطلاعات ذخیره شده از قفل";
            this.btnReadLicenseData.Click += new System.EventHandler(this.btnReadLicenseData_Click);
            // 
            // lstLicenseList
            // 
            this.lstLicenseList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lstLicenseList.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lstLicenseList.FormattingEnabled = true;
            this.lstLicenseList.Items.AddRange(new object[] {
            "110 - مجوز مدیریت امنیت سیستم های كلینیكی.",
            "120 - مجوز مدیریت بانك اطلاعاتی سیستم های كلینیكی.",
            "515 - مجوز مدیریت نوبت دهی پیشرفته.",
            "516 - مجوز تنظیمات نوبت دهی پیشرفته.",
            "525 - مجوز مدیریت بیماران پیشرفته.",
            "526 - مجوز تنظیمات بیماران پیشرفته.",
            "530 - مجوز مدیریت حساب.",
            "531 - مجوز تنظیمات حساب.",
            "540 - مجوز مدیریت صندوق.",
            "541 - مجوز تنظیمات صندوق.",
            "550 - مجوز مدیریت مدارك.",
            "551 - مجوز تنظیمات مدارك.",
            "555 - مجوز كپچر تصاویر پزشكی",
            "560 - مجوز گزارش گیری.",
            "561 - مجوز مدیریت قالب های قبوض.",
            "580 - مجوز تنظیمات ارتباط با پكس.",
            "590 - مجوز برنامه دیسكت تصویربرداری \"تامین اجتماعی\".",
            "591 - مجوز برنامه دیسكت تصویربرداری \"خدمات درمانی\".",
            "592 - مجوز برنامه دیسكت تصویربرداری \"ارتش\".",
            "593 - مجوز برنامه دیسكت تصویربرداری \"صدا و سیما\".",
            "594 - مجوز برنامه دیسكت تصویربرداری \"كمیته امداد\".",
            "610 - مجوز سیستم مدیریت باركد - خواندن باركد",
            "611 - مجوز سیستم مدیریت باركد - چاپ باركد"});
            this.lstLicenseList.Location = new System.Drawing.Point(135, 12);
            this.lstLicenseList.Name = "lstLicenseList";
            this.lstLicenseList.Size = new System.Drawing.Size(491, 395);
            this.lstLicenseList.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtLicenseText);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(638, 418);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "متن جزئیات";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtLicenseText
            // 
            this.txtLicenseText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLicenseText.BackColor = System.Drawing.Color.White;
            this.txtLicenseText.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtLicenseText.Location = new System.Drawing.Point(8, 15);
            this.txtLicenseText.Name = "txtLicenseText";
            this.txtLicenseText.ReadOnly = true;
            this.txtLicenseText.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtLicenseText.Size = new System.Drawing.Size(622, 387);
            this.txtLicenseText.TabIndex = 8;
            this.txtLicenseText.Text = "";
            // 
            // txtCounter
            // 
            this.txtCounter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCounter.BackColor = System.Drawing.Color.White;
            this.txtCounter.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtCounter.Location = new System.Drawing.Point(139, 44);
            this.txtCounter.Name = "txtCounter";
            this.txtCounter.ReadOnly = true;
            this.txtCounter.Size = new System.Drawing.Size(90, 21);
            this.txtCounter.TabIndex = 10;
            this.txtCounter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblPID
            // 
            this.lblPID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPID.BackColor = System.Drawing.Color.White;
            this.lblPID.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblPID.Location = new System.Drawing.Point(298, 44);
            this.lblPID.Name = "lblPID";
            this.lblPID.ReadOnly = true;
            this.lblPID.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblPID.Size = new System.Drawing.Size(100, 21);
            this.lblPID.TabIndex = 7;
            this.lblPID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVersion.BackColor = System.Drawing.Color.White;
            this.lblVersion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblVersion.Location = new System.Drawing.Point(472, 44);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.ReadOnly = true;
            this.lblVersion.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblVersion.Size = new System.Drawing.Size(100, 21);
            this.lblVersion.TabIndex = 4;
            this.lblVersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label16.ForeColor = System.Drawing.Color.Green;
            this.label16.Location = new System.Drawing.Point(235, 48);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(59, 13);
            this.label16.TabIndex = 9;
            this.label16.Text = "كلید مجوز:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label11.ForeColor = System.Drawing.Color.Green;
            this.label11.Location = new System.Drawing.Point(402, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "كد محصول:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.ForeColor = System.Drawing.Color.Green;
            this.label4.Location = new System.Drawing.Point(575, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "نسخه قفل:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblStatus
            // 
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStatus.ImageIndex = 0;
            this.lblStatus.ImageList = this.imgIcon;
            this.lblStatus.Location = new System.Drawing.Point(0, 525);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(646, 25);
            this.lblStatus.TabIndex = 2;
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
            this.groupBox1.Controls.Add(this.txtCounter);
            this.groupBox1.Controls.Add(this.cboDevicess);
            this.groupBox1.Controls.Add(this.lblPID);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.txtVID);
            this.groupBox1.Controls.Add(this.txtPWD);
            this.groupBox1.Controls.Add(this.lblVersion);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(646, 77);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "انتخاب و تایید اعتبار قفل:";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label15.Location = new System.Drawing.Point(449, 21);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(185, 13);
            this.label15.TabIndex = 1;
            this.label15.Text = "لیست قفل های متصل به سیستم:";
            // 
            // cboDevicess
            // 
            this.cboDevicess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDevicess.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDevicess.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cboDevicess.FormattingEnabled = true;
            this.cboDevicess.Location = new System.Drawing.Point(350, 17);
            this.cboDevicess.Name = "cboDevicess";
            this.cboDevicess.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cboDevicess.Size = new System.Drawing.Size(98, 21);
            this.cboDevicess.TabIndex = 0;
            this.cboDevicess.SelectedIndexChanged += new System.EventHandler(this.cbxDevs_SelectedIndexChanged);
            // 
            // fclsTestLock
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.ClientSize = new System.Drawing.Size(646, 550);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblStatus);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fclsTestLock";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "سیستم مدیریت قفل های سخت افزاری شركت رایان پرتونگار";
            this.Load += new System.EventHandler(this.Form_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion Windows Form Designer generated code
    }
}