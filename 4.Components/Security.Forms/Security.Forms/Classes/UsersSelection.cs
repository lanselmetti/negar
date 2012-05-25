#region using
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Negar;
using Negar.DBLayerPMS.DataLayer;
using Negar.Security.Properties;
using DevComponents.DotNetBar;
#endregion

namespace Negar.Security.Classes
{
    /// <summary>
    /// فرم انتخاب كاربران
    /// </summary>
    public partial class UsersSelection : Form
    {

        #region Fields & Properties

        #region List<SP_SelectUsersInGroupsResult> _DataSource
        /// <summary>
        /// فیلد منبع اطلاعاتی فرم
        /// </summary>
        private List<SP_SelectUsersInGroupsResult> _DataSource;
        #endregion

        #region Boolean _IsGridValuesChanged
        /// <summary>
        /// تعیین ویرایش شدن فرم توسط كاربر
        /// </summary>
        private Boolean _IsGridValuesChanged;
        #endregion

        #region List<Int16> _SelectedUsersID
        /// <summary>
        /// لیست كد كاربران انتخاب شده
        /// </summary>
        private List<Int16> _SelectedUsersID;
        #endregion

        #region public List<Int16> SelectedUsersID
        /// <summary>
        /// لیست كد كاربران انتخاب شده
        /// </summary>
        public List<Int16> SelectedUsersID
        {
            get { return _SelectedUsersID; }
        }
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public UsersSelection()
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            if (!FillSelectedGroupUsersDataSource() || !FillUserGroupsDataSource()) { Close(); return; }
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            SetControlsToolTipTexts();
            dgvData.DataSource = _DataSource;
            _IsGridValuesChanged = false;
        }
        #endregion

        #region cboGroups_SelectedIndexChanged
        private void cboGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboGroups.SelectedIndex == 0) dgvData.DataSource = _DataSource;
            else dgvData.DataSource = _DataSource.Where(Data => Data.GroupID == Convert.ToInt16(cboGroups.SelectedValue)).ToList();
        }
        #endregion

        #region dgvData_CellMouseClick
        private void dgvData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dgvData[0, e.RowIndex].Value == null ||
                Convert.ToBoolean(dgvData[0, e.RowIndex].Value) == false) dgvData[0, e.RowIndex].Value = true;
                else dgvData[0, e.RowIndex].Value = false;
                _IsGridValuesChanged = true;
            }
        }
        #endregion

        #region btnAllAndNone_Click
        private void btnAllAndNone_Click(object sender, EventArgs e)
        {
            if (((ButtonX)sender).Name == "btnAll")
                foreach (DataGridViewRow row in dgvData.Rows) row.Cells[0].Value = true;
            else foreach (DataGridViewRow row in dgvData.Rows) row.Cells[0].Value = false;
        }
        #endregion

        #region btnAccept_Click
        private void btnAccept_Click(object sender, EventArgs e)
        {
            dgvData.EndEdit();
            btnAccept.Focus();
            _SelectedUsersID = new List<Int16>();
            // افزودن كاربران انتخاب شده به لیست نهایی
            foreach (DataGridViewRow row in dgvData.Rows)
                if (row.Cells[ColSelection.Name].Value != null && Convert.ToBoolean(row.Cells[ColSelection.Index].Value))
                    _SelectedUsersID.Add(((SP_SelectUsersInGroupsResult)row.DataBoundItem).UserID.Value);
            _IsGridValuesChanged = false;
            DialogResult = DialogResult.OK;
        }
        #endregion

        #region Form_Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            dgvData.EndEdit();
            if (_IsGridValuesChanged)
            {
                DialogResult Dr = PMBox.Show("آیا از انتخاب كاربر جدید منصرف شدید؟", "هشدار",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (Dr == DialogResult.No) { e.Cancel = true; return; }
            }
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
            const String TooltipFooter = "سیستم مدیریت پزشكی آفتاب";

            #region btnCancel
            String TooltipText = ToolTipManager.GetText("btnCancel_NoApply", "IMS");
            FormToolTip.SetSuperTooltip(btnCancel, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.ArashCSMIcon, eTooltipColor.Lemon));
            #endregion

            #region cboGroups
            TooltipText = ToolTipManager.GetText("cboUsersGroups", "IMS");
            FormToolTip.SetSuperTooltip(cboGroups, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.ArashCSMIcon, eTooltipColor.Lemon));
            #endregion

            #region btnApply
            TooltipText = ToolTipManager.GetText("btnAccept", "IMS");
            FormToolTip.SetSuperTooltip(btnAccept, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.ArashCSMIcon, eTooltipColor.Lemon));
            #endregion

            #region btnAll
            TooltipText = ToolTipManager.GetText("btnAll", "IMS");
            FormToolTip.SetSuperTooltip(btnAll, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.ArashCSMIcon, eTooltipColor.Lemon));
            #endregion

            #region btnNone
            TooltipText = ToolTipManager.GetText("btnNone", "IMS");
            FormToolTip.SetSuperTooltip(btnNone, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.ArashCSMIcon, eTooltipColor.Lemon));
            #endregion

        }
        #endregion

        #region Boolean FillUserGroupsDataSource()
        /// <summary>
        /// تابع خواندن اطلاعات جدول از بانك
        /// </summary>
        private Boolean FillUserGroupsDataSource()
        {
            List<SP_SelectGroupsResult> UsersGroups = DBLayerPMS.Security.GroupsList;
            if (UsersGroups == null) return false;
            cboGroups.DataSource = UsersGroups;
            return true;
        }
        #endregion

        #region Boolean FillSelectedGroupUsersDataSource()
        /// <summary>
        /// تابع خواندن لیست كاربران عضو در گروه های كاربری از بانك
        /// </summary>
        private Boolean FillSelectedGroupUsersDataSource()
        {
            try { _DataSource = DBLayerPMS.Manager.DBML.SP_SelectUsersInGroups().Where(Data => Data.UserID > 2).ToList(); }
            #region Catch
            catch (Exception Ex)
            {
                PMBox.Show("خطا در خواندن اطلاعات ارتباط كاربران با گروه های كاربری از بانك اطلاعات!\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟.");
                LogManager.SaveLogEntry("Arash", "Security Forms", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion
            return true;
        }
        #endregion

        #endregion

    }
}