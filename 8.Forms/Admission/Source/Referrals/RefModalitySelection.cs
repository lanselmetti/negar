#region using

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Negar;
using DevComponents.DotNetBar;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Forms.Admission.Properties;

#endregion

namespace Sepehr.Forms.Admission.Referrals
{
    /// <summary>
    /// فرم ثبت یا ویرایش پزشك ارجاع دهنده
    /// </summary>
    internal partial class frmRefModalitySelection : Form
    {

        #region Fields & Properties

        #region public Int16[] Modalities
        /// <summary>
        /// كلید ردیف جاری
        /// </summary>
        public Int16[] Modalities { get; set; }
        #endregion

        #endregion

        #region Ctor
        public frmRefModalitySelection()
        {
            InitializeComponent();
            SetControlsToolTipTexts();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {

        }
        #endregion

        #region lstModalities_Format
        private void lstModalities_Format(object sender, ListControlConvertEventArgs e)
        {
            try
            {
                e.Value = ((ServiceModality)e.ListItem).Modality.Name;
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان خواندن اطلاعات مودالیتی از بانك اطلاعات وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "RefModalitySelection Form", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error); Dispose(); return;
            }
            #endregion
        }
        #endregion

        #region btnSave_Click
        private void btnSave_Click(object sender, EventArgs e)
        {
            Modalities = new Int16[lstModalities.Items.Count];
            for (int i = 0; i < lstModalities.Items.Count; i++)
                if (lstModalities.GetItemChecked(i))
                    Modalities[i] = ((ServiceModality)lstModalities.Items[i]).ModalityIX;
        }
        #endregion

        #region Form Closing
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

            #region btnSave
            TooltipText = ToolTipManager.GetText("btnAccept", "IMS");
            FormToolTip.SetSuperTooltip(btnSave, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion
        }
        #endregion

        #region public void Show(Int16 ServiceID)
        public void Show(Int16 ServiceID)
        {
            try
            {
                Modalities = null;
                lblServiceName.Text =
                    DBLayerIMS.Services.ServicesList.Where(Data => Data.ID == ServiceID).First().Name;
                List<ServiceModality> ModalitiesList = DBLayerIMS.PACS.ServiceModalities.
                    Where(Data => Data.ServiceIX == ServiceID).ToList();
                lstModalities.DataSource = ModalitiesList;
                lstModalities.ValueMember = "ModalityIX";
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان خواندن اطلاعات ارتباط خدمت و مودالیتی از بانك اطلاعات وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "RefModalitySelection Form", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error); Dispose(); return;
            }
            #endregion
            ShowDialog();
        }
        #endregion

        #endregion

    }
}