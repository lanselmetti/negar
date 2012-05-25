#region using
using System;
using System.Windows.Forms;
using Negar;
using DevComponents.DotNetBar;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Settings.SMS.Properties;
#endregion

namespace Sepehr.Settings.SMS
{
    /// <summary>
    /// فرم ثبت فرمول پیام كوتاه آماده بودن ریپورت
    /// </summary>
    public partial class frmDocCompleteMessage : Form
    {

        #region Fields

        #region Boolean _IsValueChanged
        /// <summary>
        /// فیلد مشخص كننده تغییر یافت جعبه متن قالب پیام
        /// </summary>
        private Boolean _IsValueChanged;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده فرم برای افزودن فیلد جدید
        /// </summary>
        public frmDocCompleteMessage()
        {
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("Fa-Ir"));
            InitializeComponent();
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            for (Int16 i = 708; i < 713; i++)
            {
                UsersSetting SettingData = DBLayerIMS.Settings.ReadSetting(i, null);
                if (SettingData == null || String.IsNullOrEmpty(SettingData.Value) ||
                    SettingData.Boolean == null || SettingData.Boolean == false) continue;
                cboTemplateSelection.SelectedIndex = i - 708;
                break;
            }
            if (cboTemplateSelection.SelectedIndex < 0) cboTemplateSelection.SelectedIndex = 0;
            SetControlsToolTipTexts();
            Opacity = 1;
        }
        #endregion

        #region cboTemplateSelection_SelectedIndexChanged
        private void cboTemplateSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_IsValueChanged) PMBox.Show("متن فرمول جاری تغییر یافته است. قبل از تغییر قالب ، باید قالب جاری را ثبت نمایید.\n" +
                "در غیر اینصورت متن از بین خواهد رفت. با هر تغییر دكمه تایید را فراخوانی نمایید.", "هشدار!",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            UsersSetting SMSText = null;
            switch (cboTemplateSelection.SelectedIndex)
            {
                case 0: SMSText = DBLayerIMS.Settings.ReadSetting(708, null); break;
                case 1: SMSText = DBLayerIMS.Settings.ReadSetting(709, null); break;
                case 2: SMSText = DBLayerIMS.Settings.ReadSetting(710, null); break;
                case 3: SMSText = DBLayerIMS.Settings.ReadSetting(711, null); break;
                case 4: SMSText = DBLayerIMS.Settings.ReadSetting(712, null); break;
            }
            if (SMSText == null) txtFormulaText.Text = String.Empty;
            else txtFormulaText.Text = SMSText.Value;
            _IsValueChanged = false;
        }
        #endregion

        #region txtFormulaText_TextChanged
        private void txtFormulaText_TextChanged(object sender, EventArgs e)
        {
            txtCharCount.Text = txtFormulaText.Text.Length.ToString();
            _IsValueChanged = true;
        }
        #endregion

        #region btnSave_Click
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtFormulaText.Text.Trim()))
            {
                PMBox.Show("برای فرمول پیام مورد نظر حتماً مقداری را وارد نمایید!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFormulaText.Focus();
                return;
            }
            Int16 CurrentSettingID = Convert.ToInt16(cboTemplateSelection.SelectedIndex + 708);
            if (!DBLayerIMS.Settings.InsertSystemSetting(CurrentSettingID, true, txtFormulaText.Text.Trim())) return;
            for (Int16 i = 708; i < 713; i++)
            {
                if (i == CurrentSettingID) continue;
                UsersSetting OldSetting = DBLayerIMS.Settings.ReadSetting(i, null);
                String OldValue = String.Empty;
                if (OldSetting != null && !String.IsNullOrEmpty(OldSetting.Value)) OldValue = OldSetting.Value;
                if (!DBLayerIMS.Settings.InsertSystemSetting(i, false, OldValue)) return;
            }
            FormClosing -= Form_Closing;
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

        #region Form_Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            DialogResult Dr = PMBox.Show("آیا از اعمال تغییرات منصرف شدید؟", "هشدار!", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Dr == DialogResult.No) { e.Cancel = true; return; }
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
            TooltipText = ToolTipManager.GetText("btnCancel_NoApply", "IMS");
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

        #endregion

    }
}