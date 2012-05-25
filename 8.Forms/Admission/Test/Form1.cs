#region using
using System;
using System.Windows.Forms;
using Negar;
using Sepehr.Forms.Admission.Classes;

#endregion

namespace Test_Project
{
    public partial class Form1 : Form
    {

        #region Ctor
        public Form1()
        {
            InitializeComponent();
            CSManager.CurrentSetting = "اتصال به سرور محلی";
            SecurityManager.CurrentUserID = 3;
        }
        #endregion

        #region Form_Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        #endregion

        private void buttonAddNewPat_Click(object sender, EventArgs e)
        {
            AdmitHelper.AdmitPatient(null);
        }

        private void buttonModifyPat_Click(object sender, EventArgs e)
        {
            SecurityManager.RenewAccess();
            AdmitHelper.EditPatient(Convert.ToInt32(txtPatID.Text), false);
        }

        private void buttonAddNewRefForPat_Click(object sender, EventArgs e)
        {
            SecurityManager.RenewAccess();
            AdmitHelper.AdmitNewRef(Convert.ToInt32(txtRefID1.Text), null);
        }

        private void btnShowPatLastRef_Click(object sender, EventArgs e)
        {
            SecurityManager.RenewAccess();
            AdmitHelper.EditPatientLastRef(Convert.ToInt32(txtRefID1.Text));
        }

        private void btnShowRef_Click(object sender, EventArgs e)
        {
            SecurityManager.RenewAccess();
            AdmitHelper.EditPatientRef(Convert.ToInt32(txtRefID1.Text));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SecurityManager.RenewAccess();
            AdmitHelper.AdmitPatWithRef(null);
        }
    }
}