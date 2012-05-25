#region using
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Negar;
using DevComponents.DotNetBar;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Settings.Insurances.Properties;
#endregion

namespace Sepehr.Settings.Insurances.InsurancesServices
{
    /// <summary>
    /// فرم كپی برداری ساختار ارتباط خدمات یك بیمه در سایر بیمه ها
    /// </summary>
    internal partial class frmCopySettings : Form
    {

        #region Fields

        #region List<SP_SelectInsFullDataResult> _InsList
        /// <summary>
        /// لیست بیمه های سیستم
        /// </summary>
        private List<SP_SelectInsFullDataResult> _InsList;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض جهت افزودن یك ردیف جدید
        /// </summary>
        public frmCopySettings()
        {
            InitializeComponent();
            if (!FillControls()) { Close(); return; }
            SetControlsToolTipTexts();
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region cboIns_SelectedIndexChanged
        private void cboIns_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstIns.SuspendLayout();
            for (Int32 i = lstIns.Items.Count - 1; i >= 0; i--)
            { lstIns.Items[i].Dispose(); lstIns.Items.RemoveAt(i); }
            foreach (SP_SelectInsFullDataResult Ins in _InsList)
            {
                if (((SP_SelectInsFullDataResult)cboIns.SelectedItem).ID == Ins.ID) continue;
                CheckBoxItem MyItem = new CheckBoxItem(Ins.Name);
                MyItem.Text = String.Empty;
                MyItem.Tag = Ins.ID;
                LabelItem lbl = new LabelItem();
                lbl.Style = eDotNetBarStyle.Office2000;
                lbl.Text = Ins.Name;
                ItemContainer container = new ItemContainer();
                container.LayoutOrientation = eOrientation.Horizontal;
                container.SubItems.Add(MyItem);
                container.SubItems.Add(lbl);
                lstIns.Items.Add(container);
            }
            lstIns.ResumeLayout();
        }
        #endregion

        #region btnAccept_Click
        private void btnAccept_Click(object sender, EventArgs e)
        {
            foreach (ItemContainer Item in lstIns.Items)
                if (((CheckBoxItem)Item.SubItems[0]).Checked &&
                    Convert.ToInt16(cboIns.SelectedValue) != Convert.ToInt16(Item.SubItems[0].Tag))
                    try
                    {
                        DBLayerIMS.Manager.DBML.SP_CopyInsuranceServices
                            (Convert.ToInt16(cboIns.SelectedValue), Convert.ToInt16(Item.SubItems[0].Tag));
                    }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage = "امكان كپی برداری اطلاعات بیمه انتخاب شده در بانك اطلاعات ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Sepehr", "Insurances Settings", Ex.Message + "\n" +
                            Ex.StackTrace, EventLogEntryType.Error); return;
                    }
                    #endregion
            DialogResult = DialogResult.OK;
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

        #region Form Closing
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
            TooltipText = ToolTipManager.GetText("btnCancel", "IMS");
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

        #region Boolean FillControls()
        /// <summary>
        /// خواندن اطلاعات ردیف جاری فرم از بانك و تكمیل خصوصیات كنترل ها بر اساس آن
        /// </summary>
        /// <returns>صحت تكمیل فرم</returns>
        private Boolean FillControls()
        {
            _InsList = DBLayerIMS.Insurance.InsFullList.
                    Where(Data => Data.ID != null && Data.BaseIsActive == true && Data.IsActive == true)
                    .OrderBy(Data => Data.Name).ToList();
            if (_InsList.Count == 0)
            {
                PMBox.Show("بیمه ای برای كپی برداری تنظیمات ثبت نشده است یا فعال نیست!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            cboIns.DataSource = _InsList;
            return true;
        }
        #endregion

        #endregion

    }
}