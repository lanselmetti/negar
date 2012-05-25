#region using
using System;
using System.Windows.Forms;
using Aftab.Forms;

#endregion

namespace Aftab
{
    /// <summary>
    /// فرم اصلی
    /// </summary>
    public partial class frmMainForm : Form
    {

        #region Fields

        #region frmBackup _frmBackup
        /// <summary>
        /// نمونه فرم پشتیبان گیری موردی
        /// </summary>
        private frmBackup _frmBackup;
        #endregion

        #region frmBackupPlans _frmBackupPlans
        /// <summary>
        /// نمونه فرم مدیریت پشتیبان گیری
        /// </summary>
        private frmBackupPlans _frmBackupPlans;
        #endregion

        #endregion

        #region Ctor
        public frmMainForm()
        {
            InitializeComponent();
        }
        #endregion

        #region Eventhandlers

        #region btnBackup_Click
        /// <summary>
        /// فرمان باز كردن فرم تولید پشتیبانی دستی
        /// </summary>
        private void btnBackup_Click(object sender, EventArgs e)
        {
            if (_frmBackup == null || _frmBackup.IsDisposed) _frmBackup = new frmBackup();
            else
            {
                _frmBackup.BringToFront();
                _frmBackup.Focus();
                _frmBackup.Activate();
            }
        }
        #endregion

        #region btnManageApps_Click
        /// <summary>
        /// روال مدیریت فراخوانی فرم مدیریت برنامه های پشتیبان گیری
        /// </summary>
        private void btnManageApps_Click(object sender, EventArgs e)
        {
            if (_frmBackupPlans == null || _frmBackupPlans.IsDisposed) _frmBackupPlans = new frmBackupPlans();
            else
            {
                _frmBackupPlans.BringToFront();
                _frmBackupPlans.Focus();
                _frmBackupPlans.Activate();
            }
        }
        #endregion

        #region FormNotifyIcon_MouseDoubleClick
        private void FormNotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnBackup_Click(null, null);
        }
        #endregion

        #region btnSetupService_Click
        private void btnSetupService_Click(object sender, EventArgs e)
        {
            new frmServiceSetup();
        }
        #endregion

        #endregion

    }
}