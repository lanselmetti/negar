#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Negar;
using Negar.DBLayerPMS.DataLayer;
using Negar.Security.Properties;
using DevComponents.DotNetBar;
#endregion

namespace Negar.Security.ACL
{
    /// <summary>
    /// فرم مدیریت یك سطح دسترسی سیستم برای كاربران یا گروه ها
    /// </summary>
    internal partial class frmManageAccess : Form
    {

        #region Fields

        #region readonly Boolean _IsAdding
        /// <summary>
        /// حالت افزودن یا ویرایش
        /// </summary>
        private readonly Boolean _IsAdding;
        #endregion

        #region readonly Int32 _ACLID
        /// <summary>
        /// كلید دسترسی جاری
        /// </summary>
        private readonly Int32 _ACLID;
        #endregion

        #region readonly Int16 _ID
        /// <summary>
        /// كلید كاربر یا گروه
        /// </summary>
        private readonly Int16 _ID;
        #endregion

        #region readonly Boolean _IsUser
        /// <summary>
        /// تعیین كاربر بودن یا گروه بودن فیلد جاری
        /// </summary>
        private readonly Boolean _IsUser;
        #endregion

        #region Boolean _IsFormValuesChanged
        /// <summary>
        /// تعیین ویرایش شدن فرم توسط كاربر
        /// </summary>
        private Boolean _IsFormValuesChanged;
        #endregion

        #endregion

        #region Ctor

        #region frmManageAccess(Int32 ACLID, String ACLPath)
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmManageAccess(Int32 ACLID, String ACLPath)
        {
            InitializeComponent();
            _IsAdding = true;
            lblAccessPath.Text = ACLPath;
            _ACLID = ACLID;
            if (!FillAddingDataSource()) { Close(); return; }
            ShowDialog();
        }
        #endregion

        #region frmManageAccess(Int32 ACLID, Int16 ID, Boolean IsUser, String ACLPath)
        /// <summary>
        /// سازنده فرم برای ویرایش یك دسترسی
        /// </summary>
        public frmManageAccess(Int32 ACLID, Int16 ID, Boolean IsUser, String ACLPath)
        {
            InitializeComponent();
            _IsAdding = false;
            lblAccessPath.Text = ACLPath;
            _ACLID = ACLID;
            _ID = ID;
            _IsUser = IsUser;
            if (!FillEditingDataSource()) { Close(); return; }
            ShowDialog();
        }
        #endregion

        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            SetControlsToolTipTexts();
            _IsFormValuesChanged = false;
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

        #region cBoxes_CheckedChanged
        private void cBoxes_CheckedChanged(object sender, EventArgs e)
        {
            if (sender.GetType().Equals(typeof(LabelItem)))
            {
                ((CheckBoxItem)(((LabelItem)sender).Parent).SubItems[0]).Checked =
                    !((CheckBoxItem)(((LabelItem)sender).Parent).SubItems[0]).Checked;
            }
            _IsFormValuesChanged = true;
        }
        #endregion

        #region btnAccept_Click
        /// <summary>
        /// تایید اعمال تغییرات
        /// </summary>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            _IsFormValuesChanged = false;
            #region Adding State
            if (_IsAdding)
            {
                #region Users
                foreach (ItemContainer user in lstUsers.Items)
                {
                    if (((CheckBoxItem)user.SubItems[0]).Checked)
                        if (!DBLayerPMS.Security.InsertACLPermissionUser(Convert.ToInt16((user.SubItems[0]).Tag), _ACLID,
                                cBoxAllow.Checked, cBoxIsPremiered.Checked))
                        {
                            const String ErrorMessage =
                                "ثبت اطلاعات دسترسی كاربر در بانك اطلاعات ممكن نیست.\n" +
                                "موارد زیر را بررسی نمایید:\n" +
                                "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                            PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                }
                #endregion

                #region Groups
                foreach (ItemContainer groups in lstGroups.Items)
                {
                    if (((CheckBoxItem)groups.SubItems[0]).Checked)
                        if (!DBLayerPMS.Security.InsertACLPermissionsGroups(
                            Convert.ToInt16(((groups.SubItems[0])).Tag), _ACLID, cBoxAllow.Checked))
                        {
                            const String ErrorMessage =
                                "ثبت اطلاعات دسترسی گروه در بانك اطلاعات ممكن نیست.\n" +
                                "موارد زیر را بررسی نمایید:\n" +
                                "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                            PMBox.Show(ErrorMessage, "خطا!", 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                }
                #endregion
            }
            #endregion

            #region Edit State
            else
            {
                #region Users
                if (_IsUser)
                {
                    if (!DBLayerPMS.Security.InsertACLPermissionUser(_ID, _ACLID, cBoxAllow.Checked, cBoxIsPremiered.Checked))
                    {
                        const String ErrorMessage =
                            "ثبت اطلاعات دسترسی كاربر در بانك اطلاعات ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                #endregion

                #region Groups
                else
                {
                    if (!DBLayerPMS.Security.InsertACLPermissionsGroups(_ID, _ACLID, cBoxAllow.Checked))
                    {
                        const String ErrorMessage =
                            "ثبت اطلاعات دسترسی گروه در بانك اطلاعات ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                #endregion
            }
            #endregion
        }
        #endregion

        #region Form_Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            if (_IsFormValuesChanged)
            {
                DialogResult Dr = PMBox.Show("آیا از اعمال تغییرات منصرف شدید؟", "هشدار",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
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
            const String TooltipFooter = "سیستم مدیریت تصویربرداری سپهر";

            #region btnHelp
            String TooltipText = ToolTipManager.GetText("btnHelp", "IMS");
            FormToolTip.SetSuperTooltip(btnHelp, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.ArashCSMIcon, eTooltipColor.Lemon));
            #endregion

            #region btnCancel
            TooltipText = ToolTipManager.GetText("btnCancel", "IMS");
            FormToolTip.SetSuperTooltip(btnCancel, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.ArashCSMIcon, eTooltipColor.Lemon));
            #endregion

            #region btnAccept
            TooltipText = ToolTipManager.GetText("btnAccept", "IMS");
            FormToolTip.SetSuperTooltip(btnAccept, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
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
            #region ACL Name
            List<SP_SelectACLResult> _ACLNames = DBLayerPMS.Security.GetACLList(SecurityManager.CurrentApplicationID);
            if (_ACLNames == null) return false;
            List<String> ACLNames = _ACLNames.Where(DataCollection => DataCollection.ID == _ACLID).
                Select(DataCollection => DataCollection.LocaleName).ToList();
            if (ACLNames.Count != 0) lblAccessName.Text = ACLNames.First();
            #endregion

            #region Users
            List<SP_SelectUsersResult> _Users = DBLayerPMS.Security.UsersList;
            if (_Users == null) return false;
            List<SP_SelectUsersResult> Users =
                _Users.Where(Data => Data.ID > 2 && Data.IsActive == true).ToList();
            foreach (SP_SelectUsersResult user in Users)
            {
                String FullName;
                if (String.IsNullOrEmpty(user.FirstName)) FullName = user.LastName;
                else FullName = user.FirstName + " " + user.LastName;
                CheckBoxItem cBoxControl = new CheckBoxItem();
                cBoxControl.Tag = user.ID;
                cBoxControl.CheckedChanged += cBoxes_CheckedChanged;
                LabelItem labelItem = new LabelItem();
                labelItem.Text = FullName;
                labelItem.Tooltip = user.Description;
                labelItem.Width = 140;
                labelItem.Click += cBoxes_CheckedChanged;
                ItemContainer itemContainer = new ItemContainer();
                itemContainer.Stretch = true;
                itemContainer.SubItems.Add(cBoxControl);
                itemContainer.SubItems.Add(labelItem);
                lstUsers.Items.Add(itemContainer);
            }
            #endregion

            #region Groups
            List<SP_SelectGroupsResult> _Groups = DBLayerPMS.Security.GroupsList;
            if (_Groups == null) return false;
            List<SP_SelectGroupsResult> Groups = _Groups.Where(Data => Data.ID != null && Data.IsActive == 1).ToList();
            foreach (SP_SelectGroupsResult group in Groups)
            {
                CheckBoxItem cBoxControl = new CheckBoxItem();
                cBoxControl.Tag = group.ID;
                cBoxControl.CheckedChanged += cBoxes_CheckedChanged;
                LabelItem labelItem = new LabelItem();
                labelItem.Text = group.Name;
                labelItem.Tooltip = group.Description;
                labelItem.Width = 140;
                labelItem.Click += cBoxes_CheckedChanged;
                ItemContainer itemContainer = new ItemContainer();
                itemContainer.Stretch = true;
                itemContainer.SubItems.Add(cBoxControl);
                itemContainer.SubItems.Add(labelItem);
                lstGroups.Items.Add(itemContainer);
            }
            #endregion

            panel2.Hide();
            return true;
        }
        #endregion

        #region Boolean FillEditingDataSource()
        /// <summary>
        /// تابع خواندن اطلاعات جدول از بانك
        /// </summary>
        /// <returns></returns>
        private Boolean FillEditingDataSource()
        {
            #region ACL Name
            List<SP_SelectACLResult> _ACLNames = DBLayerPMS.Security.GetACLList(SecurityManager.CurrentApplicationID);
            if (_ACLNames == null) return false;
            List<String> ACLNames = _ACLNames.Where(DataCollection => DataCollection.ID == _ACLID).
                Select(DataCollection => DataCollection.LocaleName).ToList();
            if (ACLNames.Count != 0) lblAccessName.Text = ACLNames.First();
            #endregion

            #region Fill Users Or Group Data

            #region Fill For Users
            if (_IsUser)
            {
                List<SP_SelectUsersResult> _User = DBLayerPMS.Security.UsersList;
                if (_User == null) return false;
                SP_SelectUsersResult User = _User.Where(Data => Data.ID == _ID).First();
                String FullName;
                if (String.IsNullOrEmpty(User.FirstName)) FullName = User.LastName;
                else FullName = User.FirstName + " " + User.LastName;
                lbl3.Text = "نام كاربر:";
                lblName.Text = FullName;
                PermissionsUsers UserData = DBLayerPMS.Security.GetUserPermissionData(_ID, _ACLID);
                if (UserData == null) return false;
                cBoxAllow.Checked = UserData.IsAllowed;
                if (!UserData.IsAllowed) cBoxDeny.Focus();
                cBoxDeny.Checked = !UserData.IsAllowed;
                cBoxIsPremiered.Checked = UserData.IsPremiered;
            }
            #endregion

            #region Fill For Groups
            else
            {
                List<SP_SelectGroupsResult> _GroupName = DBLayerPMS.Security.GroupsList;
                if (_GroupName == null) return false;
                String GroupName = _GroupName.Where(Data => Data.ID == _ID).Select(Data => Data.Name).First();
                lbl3.Text = "نام گروه:";
                cBoxIsPremiered.Hide();
                lblName.Text = GroupName;
                PermissionsGroups GroupData = DBLayerPMS.Security.GetGroupPermissionData(_ID, _ACLID);
                if (GroupData == null) return false;
                cBoxAllow.Checked = GroupData.IsAllowed;
                if (!GroupData.IsAllowed) cBoxDeny.Focus();
                cBoxDeny.Checked = !GroupData.IsAllowed;
            }
            #endregion

            #endregion

            panel4.Hide();
            Height = Height - (panel4.Height - 1);
            return true;
        }
        #endregion

        #endregion

    }
}