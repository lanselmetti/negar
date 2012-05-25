#region using
using System;
using System.Windows.Forms;
using Sepehr.DBLayerIMS.DataLayer;
#endregion

namespace Sepehr.Forms.Search
{
    /// <summary>
    /// فرم انتخاب ستون های نمایش داده شده در نتیجه جستجوی پیشرفته
    /// </summary>
    public partial class frmSearchColumns : Form
    {

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmSearchColumns()
        {
            InitializeComponent();
            foreach (PatAdditionalColumn column in DBLayerIMS.Referrals.PatAddinColsList)
            {
                TreeNode node = new TreeNode(column.Title);
                node.Tag = column.ID;
                node.Name = "Pat" + column.ID;
                node.ToolTipText = column.Description;
                TreeViewOptions.Nodes[2].Nodes.Add(node);
            }
            foreach (RefAdditionalColumn column in DBLayerIMS.Referrals.RefAddinColsList)
            {
                TreeNode node = new TreeNode(column.Title);
                node.Tag = column.ID;
                node.Name = "Ref" + column.ID;
                node.ToolTipText = column.Description;
                TreeViewOptions.Nodes[3].Nodes[1].Nodes.Add(node);
            }
            Top = 0;
            Left = (Screen.PrimaryScreen.WorkingArea.Width - Width) / 2;
            Height = Screen.PrimaryScreen.WorkingArea.Height;
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            TreeViewOptions.Nodes[0].Expand();
        }
        #endregion

        #region TreeViewOptions_AfterCheck
        private void TreeViewOptions_AfterCheck(object sender, TreeViewEventArgs e)
        {
            TreeViewOptions.AfterCheck -= TreeViewOptions_AfterCheck;
            if (e.Node.Parent != null && e.Node.Checked)
            {
                e.Node.Parent.Checked = true;
                if (e.Node.Parent.Parent != null && !e.Node.Parent.Parent.Checked)
                    e.Node.Parent.Parent.Checked = true;
            }
            else if (e.Node.Nodes.Count != 0 && !e.Node.Checked)
                foreach (TreeNode node in e.Node.Nodes)
                {
                    node.Checked = false;
                    foreach (TreeNode nodeChild in node.Nodes) nodeChild.Checked = false;
                }
            else if (e.Node.Nodes.Count != 0 && e.Node.Checked)
                foreach (TreeNode node in e.Node.Nodes) node.Checked = true;
            TreeViewOptions.AfterCheck += TreeViewOptions_AfterCheck;
        }
        #endregion

        #region Form_Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {

        }
        #endregion

        #endregion

    }
}