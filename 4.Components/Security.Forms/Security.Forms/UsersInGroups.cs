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
#endregion

namespace Negar.Security
{
    /// <summary>
    /// فرم مدیریت گروه بندی كاربران
    /// </summary>
    public partial class frmUsersInGroups : Form
    {

        #region Fields

        #region List<SP_SelectGroupsResult> _GroupsDataSource
        /// <summary>
        /// فیلد منبع اطلاعاتی فرم
        /// </summary>
        private List<SP_SelectGroupsResult> _GroupsDataSource;
        #endregion

        #region List<SP_SelectUsersInGroupsResult> _UsersInGroupsDataSource
        /// <summary>
        /// فیلد منبع اطلاعاتی فرم
        /// </summary>
        private List<SP_SelectUsersInGroupsResult> _UsersInGroupsDataSource;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmUsersInGroups()
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            if (!FillGroupsDataSource() || !FillUsersInGroupsDataSource()) { Close(); return; }
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            SetControlsToolTipTexts();
            cboGroups_SelectedIndexChanged(sender, e);
        }
        #endregion

        #region cboGroups_SelectedIndexChanged
        /// <summary>
        /// روال مدیریت تغییر آیتم انتخاب شده در كمبو باكس گروه ها
        /// </summary>
        private void cboGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvData.DataSource =
                (from inGroup in _UsersInGroupsDataSource
                 where inGroup.GroupID == Convert.ToInt16(cboGroups.SelectedValue)
                 select inGroup).ToList();
        }
        #endregion

        #region btnAdd_Click
        /// <summary>
        /// روال دكمه ی افزودن كاربر جدید به گروه انتخاب شده
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            UsersSelection MyForm = new UsersSelection();
            if (MyForm.DialogResult != DialogResult.OK) { MyForm.Dispose(); return; }
            #region Add Members To ServicesGrouping
            List<Int16> AddedUsersID = MyForm.SelectedUsersID;
            foreach (Int16 UserID in AddedUsersID)
                if (!DBLayerPMS.Security.InsertUsersInGroups(UserID, Convert.ToInt16(cboGroups.SelectedValue))) return;
            #endregion
            FillUsersInGroupsDataSource();
            cboGroups_SelectedIndexChanged(null, null);
            MyForm.Dispose();
        }
        #endregion

        #region dgvData_PreviewKeyDown
        private void dgvData_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Apps && dgvData.SelectedCells.Count != 0)
            {
                dgvData_CellMouseClick(1,
                    new DataGridViewCellMouseEventArgs
                        (0, dgvData.SelectedCells[0].RowIndex, Left + Width - 150,
                        Top + dgvData.Top + dgvData.ColumnHeadersHeight + 28 +
                        dgvData.GetRowDisplayRectangle(dgvData.SelectedCells[0].RowIndex, true).Top,
                        new MouseEventArgs(System.Windows.Forms.MouseButtons.Right, 1, 1, 1, 1)));
            }
        }
        #endregion

        #region dgvData_CellMouseClick
        private void dgvData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Point Position = MousePosition;
            // اگر درخواست كننده تابع جاری كلید ویندوز باشد و نه كلیك راست موس محل نمایش نموی كلیك راست تغییر می كند
            if (sender is Int32 && e.RowIndex >= 0 && e.ColumnIndex >= 0) Position = e.Location;
            else if (e.Button != MouseButtons.Right || e.RowIndex < 0 || e.ColumnIndex < 0) return;
            // ردیف مورد نظر انتخاب می شود
            dgvData.Rows[e.RowIndex].Selected = true;
            // نموی كلیك راست نمایش داده می شود
            cmsMenu.Popup(Position);
        }
        #endregion

        #region btnDelete_Click
        /// <summary>
        /// روال دكمه ی حذف كاربر از گروه انتخاب شده
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 0) return;
            DialogResult Dr = PMBox.Show("آیا مایلید كاربر انتخاب شده از گروه حذف گردد؟\n" +
                "با حذف این كاربر از گروه ، تغییرات عیناً در بانك اطلاعات منعكس می گردد.",
                "هشدار!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Dr != DialogResult.Yes) return;
            DBLayerPMS.Manager.DBML.UsersInGroups.
                DeleteAllOnSubmit(DBLayerPMS.Manager.DBML.UsersInGroups.Where
                (Data => Data.GroupIX == Convert.ToInt16(cboGroups.SelectedValue) &&
                    Data.UserIX == ((SP_SelectUsersInGroupsResult)dgvData.SelectedRows[0].DataBoundItem).UserID.Value));
            if (!DBLayerPMS.Manager.Submit()) return;
            _UsersInGroupsDataSource.Remove(((SP_SelectUsersInGroupsResult)
                dgvData.SelectedRows[0].DataBoundItem));
            cboGroups_SelectedIndexChanged(null, null);
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
            String TooltipText = ToolTipManager.GetText("btnCancel", "IMS");
            FormToolTip.SetSuperTooltip(btnCancel, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.ArashCSMIcon, eTooltipColor.Lemon));
            #endregion

            #region btnAdd
            TooltipText = ToolTipManager.GetText("btnAddUser", "IMS");
            FormToolTip.SetSuperTooltip(btnAdd, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.ArashCSMIcon, eTooltipColor.Lemon));
            #endregion

            #region btnHelp
            TooltipText = ToolTipManager.GetText("btnHelp", "IMS");
            FormToolTip.SetSuperTooltip(btnHelp, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.ArashCSMIcon, eTooltipColor.Lemon));
            #endregion

            #region btnDelete
            TooltipText = ToolTipManager.GetText("btnDelete_NoSubmit", "IMS");
            FormToolTip.SetSuperTooltip(btnDelete, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                    Resources.Help, Resources.ArashCSMIcon, eTooltipColor.Lemon));
            #endregion

            #region cboGroups
            TooltipText = ToolTipManager.GetText("cboUsersGroups", "IMS");
            FormToolTip.SetSuperTooltip(cboGroups, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.ArashCSMIcon, eTooltipColor.Lemon));
            #endregion

        }
        #endregion

        #region Boolean FillGroupsDataSource()
        /// <summary>
        /// تابع خواندن اطلاعات گروه های كاربری از بانك
        /// </summary>
        private Boolean FillGroupsDataSource()
        {
            if (DBLayerPMS.Security.GroupsList == null) return false;
            _GroupsDataSource = DBLayerPMS.Security.GroupsList.Where(Data => Data.ID != null).ToList();

            #region Check Group Existance
            if (_GroupsDataSource.Count() == 0)
            {
                PMBox.Show("گروهی برای مدیریت گروهبندی كاربران ثبت نگردیده است!\n" +
                    "لطفاً ابتدا گروه كاربری را تعریف نمایید.", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            #endregion

            #region Fill cboGroups
            cboGroups.DataSource = _GroupsDataSource;
            cboGroups.ValueMember = "ID";
            cboGroups.DisplayMember = "Name";
            #endregion

            return true;
        }
        #endregion

        #region Boolean FillUsersInGroupsDataSource()
        /// <summary>
        /// تابع تكمیل اطلاعات ارتباط كاربران و گروه ها
        /// </summary>
        private Boolean FillUsersInGroupsDataSource()
        {
            if (DBLayerPMS.Security.UsersList == null) return false;
            Int32 UserCounts = DBLayerPMS.Security.UsersList.Where(Data => Data.ID > 2).Count();
            if (UserCounts == 0)
            {
                PMBox.Show("كاربری برای مدیریت گروهبندی كاربران ثبت نگردیده است!\n" +
                    "لطفاً ابتدا كاربری را تعریف نمایید.", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            DBLayerPMS.Security.UsersInGroupsList = null;
            _UsersInGroupsDataSource = DBLayerPMS.Security.UsersInGroupsList;
            if (_UsersInGroupsDataSource == null) return false;
            return true;
        }
        #endregion

        #endregion

    }
}