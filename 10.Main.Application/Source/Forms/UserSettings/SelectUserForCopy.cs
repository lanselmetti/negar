#region using
using System;
using System.Linq;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Negar;
using Sepehr.Properties;
#endregion

namespace Sepehr.Forms.UserSettings
{
    /// <summary>
    /// فرم مدیریت تنظیمات كاربری
    /// </summary>
    public partial class frmSelectUserForCopy : Form
    {

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmSelectUserForCopy(Int16 CurrentUserID)
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            FillUsersDataSource(CurrentUserID);
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

        #region btnAll_Click
        private void btnAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvData.Rows)
                row.Cells[ColSelection.Name].Value = true;
        }
        #endregion

        #region Form_Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {

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

            #region btnAll
            TooltipText = ToolTipManager.GetText("btnAll", "IMS");
            FormToolTip.SetSuperTooltip(btnAll, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

        }
        #endregion

        #region void FillUsersDataSource(Int16 CurrentUserID)
        /// <summary>
        /// تابع خواندن اطلاعات جدول از بانك
        /// </summary>
        private void FillUsersDataSource(Int16 CurrentUserID)
        {
            dgvData.DataSource = Negar.DBLayerPMS.Security.UsersList.
                    Where(Data => Data.ID > 2 && Data.ID != CurrentUserID).ToList();
            Text += " - كاربر مبداء برای كپی: " +
                Negar.DBLayerPMS.Security.UsersList.Where(Data => Data.ID == CurrentUserID).First().FullName;
        }
        #endregion

        #endregion

    }
}