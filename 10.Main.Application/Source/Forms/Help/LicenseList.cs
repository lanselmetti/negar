#region using
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Negar;
#endregion

namespace Sepehr.Forms.Help
{
    /// <summary>
    /// فرم نمایش لایسنس های قفل جاری
    /// </summary>
    public partial class frmLicenseList : Form
    {

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض كلاس
        /// </summary>
        public frmLicenseList()
        {
            InitializeComponent();
            txtSerial.Text = LicenseHelper.LockDeviceSerial;
            txtLockVersion.Text = LicenseHelper.LockDeviceVersion;
            List<String> LicensesList = LicenseHelper.GetSavedLicenses();
            // در صورتی كه قفل آماده نباشد ، آماده می گردد
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
            lstLicenseList.ItemCheck += lstLicenseList_ItemCheck;
            if (String.IsNullOrEmpty(LicenseHelper.GetDbSaPassword())) Application.Exit();
            ShowDialog();
        }
        #endregion

        #region Event Hadlers

        #region lstLicenseList_ItemCheck
        private void lstLicenseList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            e.NewValue = e.CurrentValue;
        }
        #endregion

        #region PictureBoxLogo_MouseClick
        private void PictureBoxLogo_MouseClick(object sender, MouseEventArgs e)
        {
            Close();
        }
        #endregion
        
        #endregion

    }
}