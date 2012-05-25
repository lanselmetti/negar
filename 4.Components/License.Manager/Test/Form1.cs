using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Test_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSaPass_Click(object sender, EventArgs e)
        {
            txtSaPass.Text = Negar.LicenseHelper.GetDbSaPassword();
        }

        private void btnLicenseList_Click(object sender, EventArgs e)
        {
            List<String> Data = Negar.LicenseHelper.GetSavedLicenses();
            lstLicenseList.DataSource = Data;
        }
    }
}