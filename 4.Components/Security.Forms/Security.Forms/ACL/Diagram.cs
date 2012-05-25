#region using
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Negar;
using Negar.DBLayerPMS.DataLayer;
using Negar.Security.Classes;
using Negar.Security.Properties;
using DevComponents.DotNetBar;
using DevComponents.AdvTree;
#endregion

namespace Negar.Security.ACL
{
    /// <summary>
    /// فرم نمایش دیاگرام دسترسی یك كاربر
    /// </summary>
    internal partial class frmDiagram : Form
    {

        #region Fields

        #region List<SP_SelectACLResult> _ACLDataSource
        /// <summary>
        /// فیلد منبع اطلاعاتی فرم
        /// </summary>
        private List<SP_SelectACLResult> _ACLDataSource;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmDiagram()
        {
            InitializeComponent();
            if (!FillACLDataSource() || !FillUsersDataSource()) { Close(); return; }
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            cboUsers.SelectedIndexChanged += cboUsers_SelectedIndexChanged;
            SetControlsToolTipTexts();
            if (SecurityManager.CurrentUserID > 2)
                cboUsers.SelectedValue = SecurityManager.CurrentUserID;
            else cboUsers.SelectedIndex = 0;
            cboUsers_SelectedIndexChanged(null, null);
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

        #region cboUsers_SelectedIndexChanged
        private void cboUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            TreeViewACL.SuspendLayout();
            if (TreeViewACL.Nodes.Count != 0)
            {
                DeleteNodeSubItems(TreeViewACL.Nodes[0].Nodes);
                if (TreeViewACL.Nodes[0].HostedControl != null)
                    TreeViewACL.Nodes[0].HostedControl.Dispose();
                TreeViewACL.Nodes[0].Dispose();
                TreeViewACL.Nodes[0].Remove();
                TreeViewACL.Nodes.Clear();
            }
            LoadACLInTree();
            TreeViewACL.ResumeLayout();
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

        }
        #endregion

        #region Boolean FillUsersDataSource()
        /// <summary>
        /// تابع خواندن اطلاعات جدول از بانك
        /// </summary>
        /// <returns></returns>
        private Boolean FillUsersDataSource()
        {
            List<SP_SelectUsersResult> _TempUserList = DBLayerPMS.Security.UsersList;
            if (_TempUserList == null) return false;
            // حذف كاربر Administrator , Sa
            cboUsers.DataSource = _TempUserList.Where(Data => Data.ID > 2 && Data.IsActive == true).ToList();
            cboUsers.DisplayMember = "FullName";
            cboUsers.ValueMember = "ID";
            return true;
        }
        #endregion

        #region Boolean FillACLDataSource()
        /// <summary>
        /// تابع خواندن اطلاعات جدول از بانك
        /// </summary>
        /// <returns></returns>
        private Boolean FillACLDataSource()
        {
            _ACLDataSource = DBLayerPMS.Security.GetACLList(SecurityManager.CurrentApplicationID);
            if (_ACLDataSource == null) return false;
            return true;
        }
        #endregion

        #region static void DeleteNodeSubItems(NodeCollection nodes)
        private static void DeleteNodeSubItems(NodeCollection nodes)
        {
            for (Int32 i = nodes.Count - 1; i >= 0; i--)
            {
                DeleteNodeSubItems(nodes[i].Nodes);
                if (nodes[i].HostedControl != null)
                    nodes[i].HostedControl.Dispose();
                nodes[i].Dispose();
                nodes[i].Remove();
            }
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
                Node node = new Node();
                ACLCard TheCard = new ACLCard();
                node.Tag = Data.ID;
                TheCard.AClHeader = Data.LocaleName;
                TheCard.AClPath = Data.Description;
                if (Data.IsTitle)
                {
                    TheCard.FormPanel.Style.BackColor = Color.SkyBlue;
                    TheCard.PictureBoxStatus.Image = Resources.InfoSmall;
                    node.Style = GroupsNodeStyle;
                }
                else
                {
                    Boolean Access = DBLayerPMS.Security.GetUserPermission(Convert.ToInt16(cboUsers.SelectedValue), Data.ID);
                    if (Access)
                    {
                        TheCard.FormPanel.Style.BackColor = Color.PaleGreen;
                        TheCard.PictureBoxStatus.Image = Resources.Allow;
                        node.Checked = true;
                    }
                    else
                    {
                        TheCard.FormPanel.Style.BackColor = Color.Salmon;
                        TheCard.PictureBoxStatus.Image = Resources.Deny;
                        node.Checked = false;
                    }
                    node.Style = GroupsNodeStyle;
                }
                node.ExpandVisibility = eNodeExpandVisibility.Visible;
                TheCard.SetControlToolTip();
                node.HostedControl = TheCard;
                AddACLChild(node);
                TheCard.HostedNode = node;
                TreeViewACL.Nodes.Add(node);
            }
            TreeViewACL.Nodes[0].Expand();
        }
        #endregion

        #region void AddACLChild(Node SentNode)
        /// <summary>
        /// تابع خواندن اطلاعات جدول از بانك
        /// </summary>
        private void AddACLChild(Node SentNode)
        {
            Object ACLID = SentNode.Tag;
            foreach (SP_SelectACLResult Data in _ACLDataSource.Where(
                SP_SelectACLResult => SP_SelectACLResult.ParentIX == Convert.ToInt32(ACLID)))
            {
                Node NewNode = new Node();
                NewNode.Tag = Data.ID;
                NewNode.Checked = Data.IsTitle;
                ACLCard TheCard = new ACLCard();
                TheCard.AClHeader = Data.LocaleName;
                TheCard.AClPath = Data.Description;
                if (Data.IsTitle)
                {
                    TheCard.FormPanel.Style.BackColor = Color.SkyBlue;
                    TheCard.PictureBoxStatus.Image = Resources.InfoSmall;
                    NewNode.Style = GroupsNodeStyle;
                    NewNode.Checked = SentNode.Checked;
                }
                else
                {
                    if (!SentNode.Checked)
                    {
                        TheCard.FormPanel.Style.BackColor = Color.Salmon;
                        TheCard.PictureBoxStatus.Image = Resources.Deny;
                        NewNode.Checked = false;
                    }
                    else
                    {
                        Boolean Access = DBLayerPMS.Security.GetUserPermission(Convert.ToInt16(cboUsers.SelectedValue), Data.ID);
                        if (Access)
                        {
                            TheCard.FormPanel.Style.BackColor = Color.PaleGreen;
                            TheCard.PictureBoxStatus.Image = Resources.Allow;
                            NewNode.Checked = true;
                        }
                        else
                        {
                            TheCard.FormPanel.Style.BackColor = Color.Salmon;
                            TheCard.PictureBoxStatus.Image = Resources.Deny;
                            NewNode.Checked = false;
                        }
                    }
                    NewNode.Style = GroupsNodeStyle;
                }
                TheCard.SetControlToolTip();
                NewNode.HostedControl = TheCard;
                AddACLChild(NewNode);
                SentNode.Nodes.Add(NewNode);
                TheCard.HostedNode = NewNode;
            }
        }
        #endregion

        #endregion

    }
}