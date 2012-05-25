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
using Sepehr.Settings.PACSIntegration.Properties;
#endregion

namespace Sepehr.Settings.PACSIntegration
{
    /// <summary>
    /// فرم مدیریت گروه بندی خدمات
    /// </summary>
    public partial class frmModalitiesServicesGrouping : Form
    {

        #region Fields

        #region List<SP_SelectServicesInGroupsResult> _ServicesModalities
        /// <summary>
        /// فیلد منبع اطلاعاتی فرم
        /// </summary>
        private List<ServiceModality> _ServicesModalities;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmModalitiesServicesGrouping()
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            DBLayerIMS.PACS.Modalities = null;
            DBLayerIMS.PACS.ServiceModalities = null;
            if (!FillServicesDataSource() || !FillModalitiesDataSource()) { Close(); return; }
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            SetControlsToolTipTexts();
            // تنظیم اولیه اطلاعات جدول
            dgvData.DataSource = _ServicesModalities.Where(
                Data => Data.ModalityIX == Convert.ToInt16(cboGroups.SelectedValue)).ToList();
        }
        #endregion

        #region cboGroups_SelectedIndexChanged
        private void cboGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvData.DataSource = _ServicesModalities.Where(
                Data => Data.ModalityIX == Convert.ToInt16(cboGroups.SelectedValue)).ToList();
        }
        #endregion

        #region dgvData_CellFormatting
        private void dgvData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            try
            {
                if (e.ColumnIndex == ColCode.Index)
                    e.Value = ((ServiceModality)dgvData.Rows[e.RowIndex].DataBoundItem).ServicesList.Code;
                else if (e.ColumnIndex == ColServiceName.Index)
                    e.Value = ((ServiceModality)dgvData.Rows[e.RowIndex].DataBoundItem).ServicesList.Name;
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان خواندن اطلاعات خدمات وجود ندارد.\n" +
                   "موارد زیر را بررسی نمایید:\n" +
                   "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "PACS Settings", 
                    Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
            }
            #endregion
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
            frmServicesSelection MyForm = new frmServicesSelection();
            if (MyForm.DialogResult != DialogResult.OK) { MyForm.Dispose(); return; }

            #region Add Members To ServicesGrouping
            ArrayList AddedServicesID = MyForm.SelectedServicesID;
            List<ServiceModality> Items;
            try
            {
                Items = DBLayerIMS.Manager.DBML.ServiceModalities.
                    Where(Data => Data.ModalityIX == Convert.ToInt16(cboGroups.SelectedValue)).ToList();
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
                if (Items.Where(Data => Data.ServiceIX == CurrentServiceID).Count() == 0)
                {
                    ServiceModality NewItem = new ServiceModality();
                    NewItem.ModalityIX = Convert.ToInt16(cboGroups.SelectedValue);
                    NewItem.ServiceIX = CurrentServiceID;
                    DBLayerIMS.Manager.DBML.ServiceModalities.InsertOnSubmit(NewItem);
                }
            }
            if (!DBLayerIMS.Manager.Submit())
            {
                const String ErrorMessage =
                    "امكان افزودن خدمات قبلی عضو مودالیتی انتخاب شده به مودالیتی جاری وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close(); return;
            }
            #endregion

            if (!FillServicesDataSource()) { Close(); return; }
            dgvData.DataSource = _ServicesModalities.
                Where(Data => Data.ModalityIX == Convert.ToInt16(cboGroups.SelectedValue)).ToList();
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
            DialogResult Dr = PMBox.Show("آیا مایلید خدمات انتخاب شده از مودالیتی جاری حذف گردد؟\n" +
                "با تایید این فرمان تغییرات عیناً در یانك اطلاعاتی منعكس می گردد و امكان بازگشت وجود ندارد.",
                "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Dr != DialogResult.Yes) return;
            // ReSharper disable AccessToModifiedClosure
            foreach (DataGridViewRow row in dgvData.SelectedRows)
                DBLayerIMS.Manager.DBML.ServiceModalities.DeleteAllOnSubmit(
                    DBLayerIMS.Manager.DBML.ServiceModalities.
                        Where(Data => Data.ModalityIX == Convert.ToInt16(cboGroups.SelectedValue) &&
                            Data.ServiceIX == ((ServiceModality)row.DataBoundItem).ServiceIX));
            // ReSharper restore AccessToModifiedClosure
            dgvData.DataSource = null;
            dgvData.Refresh();
            if (!DBLayerIMS.Manager.Submit())
            {
                const String ErrorMessage = "امكان حذف خدمت انتخاب شده از مودالیتی جاری وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error); Close(); return;
            }
            if (!FillServicesDataSource()) { Close(); return; }
            dgvData.DataSource = _ServicesModalities.
                Where(Data => Data.ModalityIX == Convert.ToInt16(cboGroups.SelectedValue)).ToList();
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

        #region Boolean FillModalitiesDataSource()
        /// <summary>
        /// تابع خواندن اطلاعات گروه های خدمات از بانك
        /// </summary>
        private Boolean FillModalitiesDataSource()
        {
            List<Modality> GroupsDataSource = DBLayerIMS.PACS.Modalities;
            if (GroupsDataSource == null) return false;
            if (GroupsDataSource.Count == 0)
            {
                PMBox.Show("گروهی برای مدیریت گروه بندی خدمات ثبت نگردیده است!\n" +
                    "لطفاً ابتدا گروهی را تعریف نمایید.", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            cboGroups.DataSource = GroupsDataSource.Where(Data => Data.IsActive).ToList();
            return true;
        }
        #endregion

        #region Boolean FillServicesDataSource()
        /// <summary>
        /// تابع تكمیل اطلاعات خدمات تحت پوشش مودالیتی ها
        /// </summary>
        private Boolean FillServicesDataSource()
        {
            DBLayerIMS.PACS.ServiceModalities = null;
            _ServicesModalities = DBLayerIMS.PACS.ServiceModalities;
            if (_ServicesModalities == null) return false;
            return true;
        }
        #endregion

        #endregion

    }
}