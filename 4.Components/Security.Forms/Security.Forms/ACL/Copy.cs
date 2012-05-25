#region using
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Negar.DBLayerPMS.DataLayer;
using DevComponents.DotNetBar;
using Negar;
using Negar.Security.Properties;
#endregion

namespace Negar.Security.ACL
{
    /// <summary>
    /// فرم مدیریت سطوح دسترسی كاربران سیستم
    /// </summary>
    internal partial class frmCopy : Form
    {

        #region Fields

        #region List<SP_SelectUsersResult> _UsersDataSource
        /// <summary>
        /// 
        /// </summary>
        private List<SP_SelectUsersResult> _UsersDataSource;
        #endregion

        #region List<SP_SelectGroupsResult> _GroupsDataSource
        /// <summary>
        /// 
        /// </summary>
        private List<SP_SelectGroupsResult> _GroupsDataSource;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmCopy()
        {
            InitializeComponent();
            if (!FillAddingDataSource()) { Close(); return; }
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            cBoxSelectUsers.Checked = true;
            SetControlsToolTipTexts();
        }
        #endregion

        #region btnHelp_Click
        /// <summary>
        /// روال نمایش راهنمایی برای فرم
        /// </summary>
        private void btnHelp_Click(object sender, EventArgs e)
        {
            // ToDo: نمایش راهنما تكمیل شود
        }
        #endregion

        #region cBoxSelectUsers_CheckedChanged
        private void cBoxSelectUsers_CheckedChanged(object sender, EventArgs e)
        {
            cboSelection.SelectedIndexChanged -= cboSelection_SelectedIndexChanged;
            if (cBoxSelectUsers.Checked)
            {
                cboSelection.DataSource = _UsersDataSource.ToList();
                cboSelection.DisplayMember = "FullName";
                cboSelection.ValueMember = "ID";
            }
            else
            {
                cboSelection.DataSource = _GroupsDataSource.ToList();
                cboSelection.DisplayMember = "Name";
                cboSelection.ValueMember = "ID";
            }
            cboSelection.SelectedIndexChanged += cboSelection_SelectedIndexChanged;
            if (cboSelection.Items.Count != 0) cboSelection.SelectedIndex = 0;
            cboSelection_SelectedIndexChanged(null, null);
        }
        #endregion

        #region cboSelection_SelectedIndexChanged
        private void cboSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstUsers.SuspendLayout();
            lstGroups.SuspendLayout();
            lstUsers.Items.Clear();
            lstGroups.Items.Clear();
            if (cBoxSelectUsers.Checked)
            {
                #region Users
                List<SP_SelectUsersResult> FilteredData =
                    _UsersDataSource.Where(Data => Data.ID != Convert.ToInt16(cboSelection.SelectedValue)).ToList();
                foreach (SP_SelectUsersResult user in FilteredData)
                {
                    String FullName;
                    if (String.IsNullOrEmpty(user.FirstName)) FullName = user.LastName;
                    else FullName = user.FirstName + " " + user.LastName;
                    CheckBoxItem MyItem = new CheckBoxItem(FullName);
                    MyItem.Tag = user.ID;
                    MyItem.Text = FullName;
                    MyItem.Tooltip = user.Description;
                    MyItem.EnableMarkup = false;
                    lstUsers.Items.Add(MyItem);
                }
                #endregion

                #region Groups
                foreach (SP_SelectGroupsResult group in _GroupsDataSource)
                {
                    CheckBoxItem MyItem = new CheckBoxItem(group.Name);
                    MyItem.Tag = group.ID;
                    MyItem.Text = group.Name;
                    MyItem.Tooltip = group.Description;
                    lstGroups.Items.Add(MyItem);
                }
                #endregion
            }
            else
            {
                #region Users
                foreach (SP_SelectUsersResult user in _UsersDataSource)
                {
                    String FullName;
                    if (String.IsNullOrEmpty(user.FirstName)) FullName = user.LastName;
                    else FullName = user.FirstName + " " + user.LastName;
                    CheckBoxItem MyItem = new CheckBoxItem(FullName);
                    MyItem.Tag = user.ID;
                    MyItem.Text = FullName;
                    MyItem.Tooltip = user.Description;
                    lstUsers.Items.Add(MyItem);
                }
                #endregion

                #region Groups
                List<SP_SelectGroupsResult> FilteredData = _GroupsDataSource.
                    Where(Data => Data.ID != Convert.ToInt16(cboSelection.SelectedValue)).ToList();
                foreach (SP_SelectGroupsResult group in FilteredData)
                {
                    CheckBoxItem MyItem = new CheckBoxItem(group.Name);
                    MyItem.Tag = group.ID;
                    MyItem.Text = group.Name;
                    MyItem.Tooltip = group.Description;
                    lstGroups.Items.Add(MyItem);
                }
                #endregion
            }
            lstUsers.Invalidate();
            lstGroups.Invalidate();
        }
        #endregion

        #region btnCopyUserACL_Click
        private void btnCopyUserACL_Click(object sender, EventArgs e)
        {
            Boolean IsAnyItemCheck = false;
            foreach (CheckBoxItem item in lstUsers.Items) if (item.Checked) { IsAnyItemCheck = true; break; }
            foreach (CheckBoxItem item in lstGroups.Items) if (item.Checked) { IsAnyItemCheck = true; break; }
            if (!IsAnyItemCheck)
            {
                PMBox.Show("برای كپی برداری از سطوح دسترسی باید حداقل یك مورد را انتخاب نمایید!", "خطا!",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                #region Copy User ACL
                if (cBoxSelectUsers.Checked)
                {
                    List<PermissionsUsers> SelectedUserACL = DBLayerPMS.Manager.DBML.PermissionsUsers.
                        Where(Data => Data.UserIX == Convert.ToInt16(cboSelection.SelectedValue)).ToList();
                    foreach (CheckBoxItem item in lstUsers.Items)
                    {
                        if (item.Checked)
                        {
                            Int16 LoopID = Convert.ToInt16(item.Tag);
                            DBLayerPMS.Manager.DBML.PermissionsUsers.DeleteAllOnSubmit(
                            DBLayerPMS.Manager.DBML.PermissionsUsers.Where(Data => Data.UserIX == LoopID));
                            DBLayerPMS.Manager.DBML.SubmitChanges();
                            foreach (PermissionsUsers UserPermission in SelectedUserACL)
                            {
                                PermissionsUsers NewRow = new PermissionsUsers();
                                NewRow.UserIX = LoopID;
                                NewRow.ACLIX = UserPermission.ACLIX;
                                NewRow.IsAllowed = UserPermission.IsAllowed;
                                NewRow.IsPremiered = UserPermission.IsPremiered;
                                DBLayerPMS.Manager.DBML.PermissionsUsers.InsertOnSubmit(NewRow);
                            }
                            DBLayerPMS.Manager.DBML.SubmitChanges();
                        }
                    }
                    foreach (CheckBoxItem item in lstGroups.Items)
                    {
                        if (item.Checked)
                        {
                            Int16 LoopID = Convert.ToInt16(item.Tag);
                            DBLayerPMS.Manager.DBML.PermissionsGroups.DeleteAllOnSubmit(
                                DBLayerPMS.Manager.DBML.PermissionsGroups.Where(Data => Data.GroupIX == LoopID));
                            DBLayerPMS.Manager.DBML.SubmitChanges();
                            foreach (PermissionsUsers UserPermission in SelectedUserACL)
                            {
                                PermissionsGroups NewRow = new PermissionsGroups();
                                NewRow.GroupIX = LoopID;
                                NewRow.ACLIX = UserPermission.ACLIX;
                                NewRow.IsAllowed = UserPermission.IsAllowed;
                                DBLayerPMS.Manager.DBML.PermissionsGroups.InsertOnSubmit(NewRow);
                            }
                            DBLayerPMS.Manager.DBML.SubmitChanges();
                        }
                    }
                }
                #endregion

                #region Copy Group ACL
                else
                {
                    List<PermissionsGroups> SelectedGroupACL = DBLayerPMS.Manager.DBML.PermissionsGroups.
                       Where(Data => Data.GroupIX == Convert.ToInt16(cboSelection.SelectedValue)).ToList();
                    foreach (CheckBoxItem item in lstUsers.Items)
                    {
                        if (item.Checked)
                        {
                            Int16 LoopID = Convert.ToInt16(item.Tag);
                            DBLayerPMS.Manager.DBML.PermissionsUsers.DeleteAllOnSubmit(
                                DBLayerPMS.Manager.DBML.PermissionsUsers.Where(Data => Data.UserIX == LoopID));
                            DBLayerPMS.Manager.DBML.SubmitChanges();
                            foreach (PermissionsGroups GroupPermission in SelectedGroupACL)
                            {
                                PermissionsUsers NewRow = new PermissionsUsers();
                                NewRow.UserIX = LoopID;
                                NewRow.ACLIX = GroupPermission.ACLIX;
                                NewRow.IsAllowed = GroupPermission.IsAllowed;
                                DBLayerPMS.Manager.DBML.PermissionsUsers.InsertOnSubmit(NewRow);
                            }
                            DBLayerPMS.Manager.DBML.SubmitChanges();
                        }
                    }
                    foreach (CheckBoxItem item in lstGroups.Items)
                    {
                        if (item.Checked)
                        {
                            Int16 LoopID = Convert.ToInt16(item.Tag);
                            DBLayerPMS.Manager.DBML.PermissionsGroups.DeleteAllOnSubmit(
                                DBLayerPMS.Manager.DBML.PermissionsGroups.Where(Data => Data.GroupIX == LoopID));
                            DBLayerPMS.Manager.DBML.SubmitChanges();
                            foreach (PermissionsGroups GroupPermission in SelectedGroupACL)
                            {
                                PermissionsGroups NewRow = new PermissionsGroups();
                                NewRow.GroupIX = LoopID;
                                NewRow.ACLIX = GroupPermission.ACLIX;
                                NewRow.IsAllowed = GroupPermission.IsAllowed;
                                DBLayerPMS.Manager.DBML.PermissionsGroups.InsertOnSubmit(NewRow);
                            }
                            DBLayerPMS.Manager.DBML.SubmitChanges();
                        }
                    }
                }
                #endregion
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "خواندن كپی برداری سطوح دسترسی انتخاب شده ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Negar", "Security Forms - ACL Copy",
                    Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return;
            }
            #endregion
            PMBox.Show("كپی برداری از سطوح دسترسی با موفقیت به پایان رسید!", "كپی برداری سطوح دسترسی.",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region Form_Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            SecurityManager.RenewAccess();
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

            #region btnHelp
            String TooltipText = ToolTipManager.GetText("btnHelp", "IMS");
            FormToolTip.SetSuperTooltip(btnHelp, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.ArashCSMIcon, eTooltipColor.Lemon));
            #endregion

            #region btnClose
            TooltipText = ToolTipManager.GetText("btnClose", "IMS");
            FormToolTip.SetSuperTooltip(btnClose, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.ArashCSMIcon, eTooltipColor.Lemon));
            #endregion

            #region btnCopyUserACL
            TooltipText = ToolTipManager.GetText("btnCopyUserACL", "IMS");
            FormToolTip.SetSuperTooltip(btnCopyUserACL, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.ArashCSMIcon, eTooltipColor.Lemon));
            #endregion

        }
        #endregion

        #region Boolean FillAddingDataSource()
        /// <summary>
        /// تابع خواندن اطلاعات جدول از بانك
        /// </summary>
        /// <returns></returns>
        private Boolean FillAddingDataSource()
        {
            #region Users
            List<SP_SelectUsersResult> TempUserList = DBLayerPMS.Security.UsersList;
            if (TempUserList == null) return false;
            _UsersDataSource = TempUserList.Where(Data => Data.ID > 2 && Data.IsActive == true).ToList();
            if (_UsersDataSource.Count == 0)
            {
                PMBox.Show("كاربری برای كپی برداری سطوح دسترسی تعریف نشده است!\n" +
                    "ابتدا یك كاربر تعریف نمایید.", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            #endregion

            #region Groups
            List<SP_SelectGroupsResult> TempGroupList = DBLayerPMS.Security.GroupsList;
            if (TempGroupList == null) return false;
            _GroupsDataSource = TempGroupList.Where(Data => Data.ID != null && Data.IsActive == 1).ToList();
            if (_GroupsDataSource.Count == 0)
            {
                cBoxSelectGroups.Visible = false;
                cboSelection.Left += cBoxSelectGroups.Width;
            }
            #endregion
            return true;
        }
        #endregion

        #endregion

    }
}