#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Negar;
using Negar.DBLayerPMS.DataLayer;
using DevComponents.DotNetBar;
using Sepehr.Properties;
#endregion

namespace Sepehr.Forms.UserSettings
{
    /// <summary>
    /// فرم مدیریت تنظیمات كاربری
    /// </summary>
    public partial class frmSelectUser : Form
    {

        #region Fields

        #region List<SP_SelectUsersResult> _UsersDataSource
        /// <summary>
        /// فیلد كاربران ثبت شده در سیستم
        /// </summary>
        public List<SP_SelectUsersResult> _UsersDataSource;
        #endregion

        #region Int16 _SelectedUser
        public Int16 _SelectedUser;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmSelectUser()
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            if (!FillUsersDataSource()) { Close(); return; }
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            SetControlsToolTipTexts();
            if (_UsersDataSource.Count == 0)
            {
                PMBox.Show("كاربری برای انتخاب در سیستم وجود ندارد!", "هشدار!",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop); Close(); return;
            }
            dgvData.DataSource = _UsersDataSource.ToList();
            dgvData.Rows[0].Selected = true;
            BringToFront();
            Focus();
        }
        #endregion

        #region dgvData_CellMouseDoubleClick
        private void dgvData_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Button == MouseButtons.Left)
            {
                btnAccept_Click(null, null);
                DialogResult = DialogResult.OK;
            }
        }
        #endregion

        #region btnAccept_Click
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count != 0)
                _SelectedUser = ((SP_SelectUsersResult)dgvData.SelectedRows[0].DataBoundItem).ID.Value;
        }
        #endregion

        #region Form_Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            Dispose();
        }
        #endregion

        #endregion

        #region Methods

        #region void SetControlsToolTipTexts()
        /// <summary>
        /// تابع تنظیم متن راهنمای كنترل ها
        /// </summary>
        private void SetControlsToolTipTexts()
        {
            const String TooltipHeader = "راهنمای تنظیمات سیستم";
            const String TooltipFooter = "سیستم مدیریت تصویربرداری سپهر";

            #region btnCancel
            String TooltipText = ToolTipManager.GetText("btnCancel_NoApply", "IMS");
            FormToolTip.SetSuperTooltip(btnCancel, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnAccept
            TooltipText = ToolTipManager.GetText("btnAccept", "IMS");
            FormToolTip.SetSuperTooltip(btnAccept, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion
        }
        #endregion

        #region Boolean FillUsersDataSource()
        /// <summary>
        /// تابع خواندن اطلاعات جدول از بانك
        /// </summary>
        private Boolean FillUsersDataSource()
        {
            _UsersDataSource = Negar.DBLayerPMS.Security.UsersList.Where(Data => Data.ID > 2).ToList();
            return true;
        }
        #endregion

        #endregion

    }
}