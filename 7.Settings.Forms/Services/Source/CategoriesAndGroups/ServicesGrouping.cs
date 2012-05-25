#region using
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Negar;
using DevComponents.DotNetBar;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Settings.Services.Properties;
#endregion

namespace Sepehr.Settings.Services
{
    /// <summary>
    /// فرم مدیریت گروه بندی خدمات
    /// </summary>
    public partial class frmServicesGrouping : Form
    {

        #region Fields

        #region List<SP_SelectServicesInGroupsResult> _ServicesInSelectedGroup
        /// <summary>
        /// فیلد منبع اطلاعاتی فرم
        /// </summary>
        private List<SP_SelectServicesInGroupsResult> _ServicesInSelectedGroup;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmServicesGrouping()
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            if (!FillServicesDataSource() || !FillGroupsDataSource()) { Close(); return; }
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            SetControlsToolTipTexts();
            // تنظیم اولیه اطلاعات جدول
            dgvData.DataSource = _ServicesInSelectedGroup.Where(
                Data => Data.GroupID == Convert.ToInt16(cboGroups.SelectedValue)).ToList();
        }
        #endregion

        #region cboGroups_SelectedIndexChanged
        private void cboGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvData.DataSource = _ServicesInSelectedGroup.Where(
                Data => Data.GroupID == Convert.ToInt16(cboGroups.SelectedValue)).ToList();
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
                        dgvData.GetRowDisplayRectangle(dgvData.SelectedCells[0].RowIndex, true).Top
                        + dgvData.ColumnHeadersHeight + 30 + Top,
                        new MouseEventArgs(System.Windows.Forms.MouseButtons.Right, 1, 1, 1, 1)));
            }
        }
        #endregion

        #region dgvData_CellMouseClick
        private void dgvData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            System.Drawing.Point Position = MousePosition;
            // اگر درخواست كننده تابع جاری كلید ویندوز باشد و نه كلیك راست موس محل نمایش نموی كلیك راست تغییر می كند
            if (sender is Int32 && e.RowIndex >= 0 && e.ColumnIndex >= 0) Position = e.Location;
            else if (e.Button != MouseButtons.Right || e.RowIndex < 0 || e.ColumnIndex < 0) return;
            // منوی كلیك راست نمایش داده می شود
            cmsMenu.Popup(Position);
        }
        #endregion

        #region btnAdd_Click
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmServicesGroupingAdd MyForm = new frmServicesGroupingAdd();
            if (MyForm.DialogResult != DialogResult.OK) { MyForm.Dispose(); return; }

            #region Add Members To ServicesGrouping
            ArrayList AddedServicesID = MyForm.SelectedServicesID;
            List<ServicesInGroups> Serv;
            try
            {
                Serv = DBLayerIMS.Manager.DBML.ServicesInGroups.
                    Where(Data => Data.GroupIX == Convert.ToInt16(cboGroups.SelectedValue)).ToList();
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان افزودن خدمات قبلی عضو گروه انتخاب شده به گروه جاری وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Services Settings", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                Close(); return;
            }
            #endregion
            foreach (Int16 ServiceID in AddedServicesID)
            {
                Int16 CurrentServiceID = ServiceID;
                if (Serv.Where(Data => Data.ServiceIX == CurrentServiceID).Count() == 0)
                {
                    ServicesInGroups NewItem = new ServicesInGroups();
                    NewItem.GroupIX = Convert.ToInt16(cboGroups.SelectedValue);
                    NewItem.ServiceIX = CurrentServiceID;
                    DBLayerIMS.Manager.DBML.ServicesInGroups.InsertOnSubmit(NewItem);
                }
            }
            if (!DBLayerIMS.Manager.Submit())
            {
                const String ErrorMessage = "امكان افزودن خدمات قبلی عضو گروه انتخاب شده به گروه جاری وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close(); return;
            }
            #endregion

            if (!FillServicesDataSource()) { Close(); return; }
            dgvData.DataSource = _ServicesInSelectedGroup.
                Where(Data => Data.GroupID == Convert.ToInt16(cboGroups.SelectedValue)).ToList();
            TopMost = true;
            Select();
            Activate();
            BringToFront();
            Focus();
            TopMost = false;
        }
        #endregion

        #region btnDelete_Click
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 0) return;
            DialogResult Dr = PMBox.Show("آیا مایلید خدمات انتخاب شده از گروه جاری حذف گردد؟\n" +
                "با حذف خدمات از این گروه ، تغییرات عیناً در یانك اطلاعات منعكس می گردد و امكان بازگشت وجود ندارد.",
                "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Dr != DialogResult.Yes) return;
            // ReSharper disable AccessToModifiedClosure
            foreach (DataGridViewRow row in dgvData.SelectedRows)
                DBLayerIMS.Manager.DBML.ServicesInGroups.DeleteAllOnSubmit(
                    DBLayerIMS.Manager.DBML.ServicesInGroups.
                        Where(Data => Data.GroupIX == Convert.ToInt16(cboGroups.SelectedValue) &&
                            Data.ServiceIX == Convert.ToInt16(((SP_SelectServicesInGroupsResult)row.DataBoundItem).ID)));
            // ReSharper restore AccessToModifiedClosure
            if (!DBLayerIMS.Manager.Submit())
            {
                const String ErrorMessage = "امكان حذف خدمت انتخاب شده از گروه جاری وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error); Close(); return;
            }
            if (!FillServicesDataSource()) { Close(); return; }
            dgvData.DataSource = _ServicesInSelectedGroup.
                Where(Data => Data.GroupID == Convert.ToInt16(cboGroups.SelectedValue)).ToList();
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

            #region btnHelp
            String TooltipText = ToolTipManager.GetText("btnHelp", "IMS");
            FormToolTip.SetSuperTooltip(btnHelp, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnCancel
            TooltipText = ToolTipManager.GetText("btnClose", "IMS");
            FormToolTip.SetSuperTooltip(btnCancel, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region cboGroups
            TooltipText = ToolTipManager.GetText("cboGroupsServices", "IMS");
            FormToolTip.SetSuperTooltip(cboGroups, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnAdd
            TooltipText = ToolTipManager.GetText("btnAddGroupsInServices", "IMS");
            FormToolTip.SetSuperTooltip(btnAdd, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion
        }
        #endregion

        #region Boolean FillGroupsDataSource()
        /// <summary>
        /// تابع خواندن اطلاعات گروه های خدمات از بانك
        /// </summary>
        private Boolean FillGroupsDataSource()
        {
            List<SP_SelectGroupsResult> GroupsDataSource = DBLayerIMS.Services.ServGroupsList;
            if (GroupsDataSource == null) return false;
            if (GroupsDataSource.Count == 1)
            {
                PMBox.Show("گروهی برای مدیریت گروه بندی خدمات ثبت نگردیده است!\n" +
                    "لطفاً ابتدا گروهی را تعریف نمایید.", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            cboGroups.DataSource = GroupsDataSource.Where(Data => Data.IsActive == true).ToList();
            return true;
        }
        #endregion

        #region Boolean FillServicesDataSource()
        /// <summary>
        /// تابع تكمیل اطلاعات خدمات تحت پوشش گروه ها
        /// </summary>
        private Boolean FillServicesDataSource()
        {
            try { _ServicesInSelectedGroup = DBLayerIMS.Manager.DBML.SP_SelectServicesInGroups().ToList(); }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان خواندن اطلاعات خدمات تحت پوشش گروه ها از بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Services Settings", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion
            return true;
        }
        #endregion

        #endregion

    }
}