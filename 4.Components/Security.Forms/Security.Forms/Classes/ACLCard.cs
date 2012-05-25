#region using
using System;
using System.Drawing;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.AdvTree;
#endregion

namespace Negar.Security.Classes
{
    /// <summary>
    /// كنترل نمایش دسترسی یك كاربر به یك گره دسترسی
    /// </summary>
    internal partial class ACLCard : UserControl
    {

        #region Fields & Properties

        #region public String AClHeader
        public String AClHeader
        {
            get { return lblTitle.Text; }
            set
            {
                lblTitle.Text = value;
            }
        }
        #endregion

        #region public String AClPath
        public String AClPath { get; set; }
        #endregion

        #region Node HostedNode
        public Node HostedNode { get; set; }
        #endregion

        #endregion

        #region Ctor
        public ACLCard()
        {
            InitializeComponent();
        }
        #endregion

        #region Event Handlers

        #region lblTitle_LinkClicked
        private void lblTitle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Parent.SuspendLayout();
            if (HostedNode.Expanded) HostedNode.Collapse();
            else HostedNode.Expand();
            Parent.ResumeLayout();
        }
        #endregion

        #region lblTitle_Paint
        private void lblTitle_Paint(object sender, PaintEventArgs e)
        {
            SizeF ThePoint = e.Graphics.MeasureString(lblTitle.Text, lblTitle.Font, lblTitle.Width,
                new StringFormat(StringFormatFlags.DirectionRightToLeft));
            Height = Convert.ToInt32(ThePoint.Height) + 10;
            PictureBoxStatus.Top = (Height / 2) - (PictureBoxStatus.Height / 2);
        }
        #endregion

        #endregion

        #region Methods

        #region internal void SetControlToolTip()
        internal void SetControlToolTip()
        {
            FormToolTip.SetSuperTooltip(lblTitle, new SuperTooltipInfo("شرح ویژگی های دسترسی:", String.Empty, AClPath,
                    PictureBoxStatus.Image, null, eTooltipColor.Tan));
        }
        #endregion

        #endregion

    }
}
