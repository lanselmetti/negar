#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Negar;
using DevComponents.DotNetBar;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Settings.Schedules.Properties;
#endregion

namespace Sepehr.Settings.Schedules.AppsAddinFields
{
    /// <summary>
    /// فرم مدیریت آیتم های ستون های چند گزینه ای برای ستون های پویا
    /// </summary>
    internal partial class frmAddinColsMultiChoiceFieldItems : Form
    {

        #region Fields

        #region readonly Int16 _CurrentFieldID
        /// <summary>
        /// كلید فیلد جاری
        /// </summary>
        private readonly Int16 _CurrentFieldID;
        #endregion

        #region List<SchAddinDataItemsColCover> _CurrentFieldItems
        /// <summary>
        /// لیست آیتم های تحت پوشش فیلد چندگزینه ای پویا جاری
        /// </summary>
        private List<SchAddinDataItemsColCover> _CurrentFieldItems;
        #endregion

        #region Boolean _IsGridValuesChanged
        /// <summary>
        /// تعیین ویرایش شدن فرم توسط كاربر
        /// </summary>
        private Boolean _IsGridValuesChanged;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmAddinColsMultiChoiceFieldItems(Int16 FieldID)
        {
            InitializeComponent();
            dgvItems.AutoGenerateColumns = false;
            dgvSelectedItems.AutoGenerateColumns = false;
            _CurrentFieldID = FieldID;
            if (!FillDataSource()) { Close(); return; }
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            SetControlsToolTipTexts();
            _IsGridValuesChanged = false;
        }
        #endregion

        #region dgvSelectedItems_CellFormatting
        private void dgvSelectedItems_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            Int16 ItemID = ((SchAddinDataItemsColCover)dgvSelectedItems.Rows[e.RowIndex].DataBoundItem).ItemIX;
            List<SchAddinDataItem> TempData = DBLayerIMS.Schedules.SchAddinDataItemsList;
            if (TempData == null) { Close(); return; }
            e.Value = DBLayerIMS.Schedules.SchAddinDataItemsList.Where(Data => Data.ID == ItemID).First().Title;
        }
        #endregion

        #region btnAdd_Click
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dgvItems.SelectedRows.Count == 0) return;
            _IsGridValuesChanged = true;
            Int16 SelectedItem = ((SchAddinDataItem)dgvItems.SelectedRows[0].DataBoundItem).ID;
            foreach (DataGridViewRow row in dgvSelectedItems.Rows)
                if (((SchAddinDataItemsColCover)row.DataBoundItem).ItemIX == SelectedItem) return;
            SchAddinDataItemsColCover NewItem = new SchAddinDataItemsColCover();
            NewItem.ColumnIX = _CurrentFieldID;
            NewItem.ItemIX = SelectedItem;
            DBLayerIMS.Manager.DBML.SchAddinDataItemsColCovers.InsertOnSubmit(NewItem);
            _CurrentFieldItems.Add(NewItem);
            dgvSelectedItems.DataSource = _CurrentFieldItems.ToList();
        }
        #endregion

        #region btnSave_Click
        private void btnSave_Click(object sender, EventArgs e)
        {
            btnAccept.Focus();
            dgvItems.EndEdit();
            if (!DBLayerIMS.Manager.Submit())
            {
                const String ErrorMessage = "امكان به روز رسانی بانك بر اساس اطلاعات وارد شده ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            _IsGridValuesChanged = false;
        }
        #endregion

        #region Form_Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            dgvItems.EndEdit();
            btnAccept.Focus();
            if (_IsGridValuesChanged)
            {
                DialogResult Dr = PMBox.Show("آیا از اعمال تغییرات منصرف شدید؟", "هشدار!", MessageBoxButtons.YesNo,
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

            #region btnCancel
            String TooltipText = ToolTipManager.GetText("btnCancel", "IMS");
            FormToolTip.SetSuperTooltip(btnCancel, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnAccept
            TooltipText = ToolTipManager.GetText("btnAccept", "IMS");
            FormToolTip.SetSuperTooltip(btnAccept, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion
        }
        #endregion

        #region Boolean FillDataSource()
        /// <summary>
        /// تابع خواندن اطلاعات جدول از بانك
        /// </summary>
        private Boolean FillDataSource()
        {
            DBLayerIMS.Schedules.SchAddinDataItemsList = null;
            List<SchAddinDataItem> TempSchAddinItemsList = DBLayerIMS.Schedules.SchAddinDataItemsList;
            if (TempSchAddinItemsList == null) return false;
            dgvItems.DataSource = TempSchAddinItemsList;
            if (dgvItems.Rows.Count == 0)
            {
                PMBox.Show("آیتمی برای تخصیص به این فیلد تعریف نشده است!\n" + "ابتدا آیتم فیلد های چند گزینه ای تعیین نمایید.",
                    "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            _CurrentFieldItems = DBLayerIMS.Schedules.GetSchAddinDataItemsColCovers(_CurrentFieldID);
            if (_CurrentFieldItems == null) return false;
            dgvSelectedItems.DataSource = _CurrentFieldItems;
            return true;
        }
        #endregion

        #endregion

    }
}