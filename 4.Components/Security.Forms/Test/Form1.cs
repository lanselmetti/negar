using System;
using System.Windows.Forms;
using Negar;
using Negar.Security;

namespace Test_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SecurityManager.CurrentApplicationID = 500;
            CSManager.CurrentSetting = "اتصال به سرور محلی";
            SecurityManager.CurrentUserID = 3;
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            new frmUsers();
        }

        private void btnGroups_Click(object sender, EventArgs e)
        {
            new frmUsersGroups();
        }

        private void btnUsersGroups_Click(object sender, EventArgs e)
        {
            new frmUsersInGroups();
        }

        private void btnACLManages_Click(object sender, EventArgs e)
        {
            new Negar.Security.ACL.frmManage();
        }

    }
}