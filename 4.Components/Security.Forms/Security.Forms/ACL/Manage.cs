#region using
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Diagnostics;
using System.Drawing;
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
    public partial class frmManage : Form
    {

        #region Fields

        #region IEnumerable<SP_SelectACLResult> _ACLDataSource
        /// <summary>
        /// فیلد منبع اطلاعاتی فرم
        /// </summary>
        private IEnumerable<SP_SelectACLResult> _ACLDataSource;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmManage()
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            if (!FillUsersDataSource() || !FillACLDataSource()) { Close(); return; }
            LoadACLInTree();
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
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

        #region btnCopyUserACL_Click
        private void btnCopyUserACL_Click(object sender, EventArgs e)
        {
            new frmCopy();
            BringToFront();
            Focus();
            TreeViewACL.Focus();
            if (TreeViewACL.SelectedNode != null)
            {
                TreeViewEventArgs NodeEventArg = new TreeViewEventArgs(TreeViewACL.SelectedNode);
                TreeViewACL_AfterSelect(null, NodeEventArg);
            }
        }
        #endregion

        #region btnACLDiagram_Click
        private void btnACLDiagram_Click(object sender, EventArgs e)
        {
            new frmDiagram();
            BringToFront();
            Focus();
            TreeViewACL.Focus();
            if (TreeViewACL.SelectedNode != null)
            {
                TreeViewEventArgs NodeEventArg = new TreeViewEventArgs(TreeViewACL.SelectedNode);
                TreeViewACL_AfterSelect(null, NodeEventArg);
            }
        }
        #endregion

        #region TreeViewACL_AfterSelect
        /// <summary>
        /// روال مدیریت جدول دسترسی ها پس از انتخاب یك گره دسترسی
        /// </summary>
        private void TreeViewACL_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // نمایش دسترسی های زیر یك دسترسی كه از نوع عنوان نیست
            if (!e.Node.Checked && !ShowACLNodeProps(Convert.ToInt32(e.Node.Tag))) { Close(); return; }
            // خالی كردن جدول دسترسی ها
            if (e.Node.Checked) dgvData.DataSource = null;
        }
        #endregion

        #region TreeViewACL_NodeMouseClick
        /// <summary>
        /// روال مدیریت كلیك راست بر روی یك گره در درخت دسترسی ها
        /// </summary>
        private void TreeViewACL_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right && !e.Node.Checked)
            {
                TreeViewACL.SelectedNode = e.Node;
                btnNewAccess.Visible = true;
                btnEditAccess.Visible = false;
                btnRemoveAccess.Visible = false;
                cmsACLManage.Popup(MousePosition);
            }
        }
        #endregion

        #region btnNewAccess_Click
        /// <summary>
        /// روال دكمه ی ایجاد دسترسی جدید
        /// </summary>
        private void btnNewAccess_Click(object sender, EventArgs e)
        {
            String FullPath = TreeViewACL.SelectedNode.FullPath;
            if (TreeViewACL.SelectedNode.Parent != null) FullPath = TreeViewACL.SelectedNode.Parent.FullPath;
            frmManageAccess MyForm =
                new frmManageAccess(Convert.ToInt32(TreeViewACL.SelectedNode.Tag), FullPath);
            if (MyForm.DialogResult == DialogResult.OK)
                if (!ShowACLNodeProps(Convert.ToInt32(TreeViewACL.SelectedNode.Tag))) { Close(); return; }
            MyForm.Dispose();
            BringToFront();
            Focus();
            TreeViewACL.Focus();
        }
        #endregion

        #region dgvData_CellMouseClick
        private void dgvData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dgvData.Rows[e.RowIndex].Selected = true;
                btnNewAccess.Visible = false;
                btnEditAccess.Visible = true;
                btnRemoveAccess.Visible = true;
                cmsACLManage.Popup(MousePosition);
            }
        }
        #endregion

        #region dgvData_CellMouseDoubleClick
        /// <summary>
        /// روالی برای مدیریت دوبار كلیك بر روی یك دسترسی ثبت شده
        /// </summary>
        private void dgvData_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.ColumnIndex >= 0 && e.RowIndex >= 0) btnEditAccess_Click(null, null);
        }
        #endregion

        #region btnEditAccess_Click
        /// <summary>
        /// روال دكمه ی ویرایش دسترسی
        /// </summary>
        private void btnEditAccess_Click(object sender, EventArgs e)
        {
            String FullPath = TreeViewACL.SelectedNode.FullPath;
            if (TreeViewACL.SelectedNode.Parent != null) FullPath = TreeViewACL.SelectedNode.Parent.FullPath;
            frmManageAccess MyForm = new frmManageAccess(
                ((SP_SelectACLPermissionsResult)dgvData.SelectedRows[0].DataBoundItem).ACLID,
                ((SP_SelectACLPermissionsResult)dgvData.SelectedRows[0].DataBoundItem).ID,
                Convert.ToBoolean(
                ((SP_SelectACLPermissionsResult)dgvData.SelectedRows[0].DataBoundItem).IsUser), FullPath);
            if (MyForm.DialogResult == DialogResult.OK)
                if (!ShowACLNodeProps(Convert.ToInt32(TreeViewACL.SelectedNode.Tag))) { Close(); return; }
            MyForm.Dispose();
            BringToFront();
            Focus();
            TreeViewACL.Focus();
        }
        #endregion

        #region btnRemoveAccess_Click
        /// <summary>
        /// حذف دسترسی جاری
        /// </summary>
        private void btnRemoveAccess_Click(object sender, EventArgs e)
        {
            #region Check User Permission
            DialogResult Dr = PMBox.Show("آیا مایل به حذف دسترسی انتخاب شده هستید؟", "هشدار!",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Dr == DialogResult.No) return;
            #endregion

            #region Delete User
            if (Convert.ToBoolean(((SP_SelectACLPermissionsResult)dgvData.SelectedRows[0].DataBoundItem).IsUser))
            {
                try
                {
                    DBLayerPMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues,
                        DBLayerPMS.Manager.DBML.PermissionsUsers);
                }
                #region Catch
                catch (Exception Ex)
                {
                    PMBox.Show("امكان حذف دسترسی انتخاب شده وجود ندارد. ارتباط با شبكه را بررسی نمایید.", "خطا!",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogManager.SaveLogEntry("Negar", "Security Forms - ACL Form",
                        Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error); return;
                }
                #endregion
                DBLayerPMS.Manager.DBML.PermissionsUsers.DeleteAllOnSubmit(
                    DBLayerPMS.Manager.DBML.PermissionsUsers.Where(
                    Data => Data.ACLIX == ((SP_SelectACLPermissionsResult)dgvData.SelectedRows[0].DataBoundItem).ACLID &&
                        Data.UserIX == ((SP_SelectACLPermissionsResult)dgvData.SelectedRows[0].DataBoundItem).ID));
            }
            #endregion

            #region Delete Group
            else
            {
                try
                {
                    DBLayerPMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues,
                        DBLayerPMS.Manager.DBML.PermissionsGroups);
                }
                #region Catch
                catch (Exception Ex)
                {
                    PMBox.Show("امكان حذف دسترسی انتخاب شده وجود ندارد. ارتباط با شبكه را بررسی نمایید.", "خطا!",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogManager.SaveLogEntry("Negar", "Security Forms - ACL Form",
                        Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error); return;
                }
                #endregion
                DBLayerPMS.Manager.DBML.PermissionsGroups.DeleteAllOnSubmit(
                DBLayerPMS.Manager.DBML.PermissionsGroups.
                Where(Data => Data.ACLIX == ((SP_SelectACLPermissionsResult)dgvData.SelectedRows[0].DataBoundItem).ACLID &&
                    Data.GroupIX == ((SP_SelectACLPermissionsResult)dgvData.SelectedRows[0].DataBoundItem).ID));
            }
            #endregion

            if (!DBLayerPMS.Manager.Submit())
                PMBox.Show("امكان حذف دسترسی انتخاب شده وجود ندارد. ارتباط با شبكه را بررسی نمایید.", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (!ShowACLNodeProps(Convert.ToInt32(TreeViewACL.SelectedNode.Tag))) { Close(); return; }
            Select();
            BringToFront();
            Focus();
            TreeViewACL.Focus();
        }
        #endregion

        #region btnToDefaultACL_Click
        private void btnToDefaultACL_Click(object sender, EventArgs e)
        {
            DialogResult Result = PMBox.Show("آیا مایلید كلیه سطوح دسترسی كاربر جاری را به حالت اولیه بازگردانید؟", "پرسش؟",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Result != DialogResult.Yes) return;
            IQueryable<PermissionsUsers> DataToDelete = DBLayerPMS.Manager.DBML.PermissionsUsers.
                Where(Data => Data.UserIX == Convert.ToInt16(cboUsers.SelectedValue));
            try { DBLayerPMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, DataToDelete); }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "خواندن بازخوانی اطلاعات سطوح دسترسی كاربر انتخاب شده ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Negar", "Security Forms - ACL Form",
                    Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error); return;
            }
            #endregion
            DBLayerPMS.Manager.DBML.PermissionsUsers.DeleteAllOnSubmit(
                DBLayerPMS.Manager.DBML.PermissionsUsers.
                Where(Data => Data.UserIX == Convert.ToInt16(cboUsers.SelectedValue)));
            DBLayerPMS.Manager.Submit();
            // انتخاب مجدد دسترسی انتخاب شده برای به روز رسانی دسترسی ها
            if (TreeViewACL.SelectedNode != null)
                TreeViewACL_AfterSelect(null, new TreeViewEventArgs(TreeViewACL.SelectedNode, TreeViewAction.ByMouse));
            BringToFront();
            Focus();
            TreeViewACL.Focus();
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

            #region btnACLDiagram
            TooltipText = ToolTipManager.GetText("btnACLDiagram", "IMS");
            FormToolTip.SetSuperTooltip(btnACLDiagram, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.ArashCSMIcon, eTooltipColor.Lemon));
            #endregion

            #region btnCopyUserACL
            TooltipText = ToolTipManager.GetText("btnCopyUserACL", "IMS");
            FormToolTip.SetSuperTooltip(btnCopyUserACL, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.ArashCSMIcon, eTooltipColor.Lemon));
            #endregion

            #region btnNewAccess
            TooltipText = ToolTipManager.GetText("btnNewAccess", "IMS");
            FormToolTip.SetSuperTooltip(btnNewAccess, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.ArashCSMIcon, eTooltipColor.Lemon));
            #endregion

            #region btnEditAccess
            TooltipText = ToolTipManager.GetText("btnEditAccess", "IMS");
            FormToolTip.SetSuperTooltip(btnEditAccess, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.ArashCSMIcon, eTooltipColor.Lemon));
            #endregion

            #region btnRemoveAccess
            TooltipText = ToolTipManager.GetText("btnRemoveAccess", "IMS");
            FormToolTip.SetSuperTooltip(btnRemoveAccess, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.ArashCSMIcon, eTooltipColor.Lemon));
            #endregion

        }
        #endregion

        #region Boolean FillUsersDataSource()
        /// <summary>
        /// تابع خواندن اطلاعات جدول از بانك
        /// </summary>
        /// <returns></returns>
        private Boolean FillUsersDataSource()
        {
            List<SP_SelectUsersResult> TempUserList = DBLayerPMS.Security.UsersList;
            if (TempUserList == null) return false;
            // حذف كاربر Administrator , Sa
            cboUsers.DataSource = TempUserList.Where(Data => Data.ID > 2 && Data.IsActive == true).ToList();
            cboUsers.DisplayMember = "FullName";
            cboUsers.ValueMember = "ID";
            return true;
        }
        #endregion

        #region Boolean FillACLDataSource()
        /// <summary>
        /// تابع خواندن اطلاعات دسترسی های موجود در سیستم بر اساس برنامه ای كه این تابع را فراخوانی نموده است
        /// </summary>
        private Boolean FillACLDataSource()
        {
            _ACLDataSource = DBLayerPMS.Security.GetACLList(SecurityManager.CurrentApplicationID);
            if (_ACLDataSource == null) return false;
            return true;
        }
        #endregion

        #region void LoadACLInTree()
        /// <summary>
        /// تابع نمایش سطوح خوانده شده از بانك در درخت
        /// </summary>
        /// <returns></returns>
        private void LoadACLInTree()
        {
            //  این روال سطوح ریشه ی برنامه جاری را می خواند ، سپس سطوح فرزند را نمایش می دهد
            foreach (SP_SelectACLResult Data in _ACLDataSource.
                Where(SP_SelectACLResult => SP_SelectACLResult.ParentIX == null))
            {
                TreeNode node = new TreeNode(Data.ID + " - " + Data.LocaleName);
                node.Tag = Data.ID;
                node.ToolTipText = Data.Description;
                node.Checked = Data.IsTitle;
                if (Data.IsTitle)
                {
                    node.NodeFont = new Font("B Mitra", 13, FontStyle.Bold);
                    node.ForeColor = Color.Red;
                }
                AddACLChild(node);
                TreeViewACL.Nodes.Add(node);
            }
        }
        #endregion

        #region void AddACLChild(TreeNode SentNode)
        /// <summary>
        /// تابع خواندن اطلاعات جدول از بانك
        /// </summary>
        private void AddACLChild(TreeNode SentNode)
        {
            foreach (SP_SelectACLResult Data in _ACLDataSource.Where(
                SP_SelectACLResult => SP_SelectACLResult.ParentIX == Convert.ToInt32(SentNode.Tag)))
            {
                TreeNode NewNode = new TreeNode(Data.ID + " - " + Data.LocaleName);
                NewNode.Tag = Data.ID;
                NewNode.ToolTipText = Data.Description;
                NewNode.Checked = Data.IsTitle;
                if (Data.IsTitle)
                {
                    NewNode.NodeFont = new Font("B Mitra", 13, FontStyle.Bold);
                    NewNode.ForeColor = Color.Red;
                }
                AddACLChild(NewNode);
                SentNode.Nodes.Add(NewNode);
            }
        }
        #endregion

        #region Boolean ShowACLNodeProps(Int32 ACLID)
        /// <summary>
        /// تابع خواندن اطلاعات دسترسی ها ارائه شده به یك سطح
        /// </summary>
        /// <param name="ACLID">كلید دسترسی</param>
        /// <returns>صحت خواندن اطلاعات</returns>
        private Boolean ShowACLNodeProps(Int32 ACLID)
        {
            List<SP_SelectACLPermissionsResult> TempACLAccessList = DBLayerPMS.Security.GetACLAccessList(ACLID);
            if (TempACLAccessList == null) return false;
            dgvData.DataSource = TempACLAccessList;
            return true;
        }
        #endregion

        #endregion

    }
}