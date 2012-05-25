#region using
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Negar;
using DevComponents.DotNetBar;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Settings.Documents.Properties;
#endregion

namespace Sepehr.Documents
{
    /// <summary>
    /// فرم مدیریت مدارك مراجعات بیماران
    /// </summary>
    internal partial class frmDocTextsManage : Form
    {

        #region Fields

        #region Int16? _CurrentTextID
        /// <summary>
        /// نگهدارنده شناسه قالب
        /// </summary>
        private Int16? _CurrentTextID;
        #endregion

        #region readonly Boolean _IsAdding
        /// <summary>
        /// مجزا كننده فراخوانی فرم 
        /// </summary>
        private readonly Boolean _IsAdding;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmDocTextsManage(Int16? CurrentTextID)
        {
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("Fa-Ir"));
            // اگر فرم در حال ویرایش فراخوانی شده بود
            if (CurrentTextID != null) { _CurrentTextID = CurrentTextID; _IsAdding = false; }
            //اگر فرم در حال افزودن فراخوانی شده بود
            else _IsAdding = true;
            InitializeComponent();
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            if (_IsAdding) txtTextCode.ValueObject = null;
            else if (!FillFormBaseDataSources(_CurrentTextID.Value)) { Close(); return; }
        }
        #endregion

        #region btnHelp_Click
        /// <summary>
        /// روال نمایش راهنمایی برای فرم
        /// </summary>
        private void btnHelp_Click(object sender, EventArgs e)
        {
            SetControlsToolTipTexts();
        }
        #endregion

        #region btnReplaceSpace_Click
        private void btnReplaceSpace_Click(object sender, EventArgs e)
        {
            txtText.Text = txtText.Text.Replace("  ", " ").Trim();
        }
        #endregion

        #region btnRightToLeft_Click
        private void btnRightToLeft_Click(object sender, EventArgs e)
        {
            txtText.RightToLeft = RightToLeft.Yes;
        }
        #endregion

        #region btnLeftToRight_Click
        private void btnLeftToRight_Click(object sender, EventArgs e)
        {
            txtText.RightToLeft = RightToLeft.No;
        }
        #endregion

        #region btnCancel_Click
        /// <summary>
        /// دكمه بستن فرم
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        #endregion

        #region btnAccept_Click
        /// <summary>
        /// دكمه ذخیره سازی فرم مدرك
        /// </summary>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            #region Validate Form Data
            if (String.IsNullOrEmpty(txtName.Text.Trim()))
            {
                PMBox.Show("برای متن حتماً نامی انتخاب نمایید!", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return;
            }
            if (txtTextCode.ValueObject != null)
            {
                List<DocText> SelectedCode;
                try
                {
                    if (_CurrentTextID == null) SelectedCode = DBLayerIMS.Manager.DBML.DocTexts.
                        Where(Data => Data.Code == Convert.ToInt16(txtTextCode.Value)).ToList();
                    else SelectedCode = DBLayerIMS.Manager.DBML.DocTexts.
                        Where(Data => Data.ID != _CurrentTextID.Value && Data.Code == Convert.ToInt16(txtTextCode.Value)).ToList();
                }
                #region Catch
                catch (Exception Ex)
                {
                    const String ErrorMessage = "امكان بررسی تكراری بودن كد متن جاری ممكن نیست.\n" +
                        "موارد زیر را بررسی نمایید:\n" +
                        "1. آیا ارتباط شبكه شما متصل می باشد؟";
                    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogManager.SaveLogEntry("Sepehr", "Documents Settings", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                    return;
                }
                #endregion
                if (SelectedCode.Count != 0)
                {
                    PMBox.Show("كد وارد شده برای متن جاری قبلاً برای متن دیگری انتخاب شده است!\n" +
                    "كد دیگری برای قالب جاری انتخاب نمایید!", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTextCode.Focus();
                    return;
                }
            }
            #endregion
            DialogResult = DialogResult.OK;
        }
        #endregion

        #endregion

        #region Method

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

            #region btnHelp
            TooltipText = ToolTipManager.GetText("btnHelp", "IMS");
            FormToolTip.SetSuperTooltip(btnHelp, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnAccept
            TooltipText = ToolTipManager.GetText("btnAccept_NoApply", "IMS");
            FormToolTip.SetSuperTooltip(btnAccept, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

        }
        #endregion

        #region Boolean FillFormBaseDataSources(Int16 ID)
        /// <summary>
        /// تابع خواندن اطلاعات قالب مدرك
        /// </summary>
        /// <returns>صحت خواندن اطلاعات</returns>
        private Boolean FillFormBaseDataSources(Int16 TextID)
        {
            DocText DocTextData;
            try { DocTextData = DBLayerIMS.Manager.DBML.DocTexts.Where(Data => Data.ID == TextID).ToList().First(); }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان خواندن اطلاعات متن مدرك انتخاب شده از بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟\n" +
                    "2. آیا ترم افزار ورد مایكروسافت نصب می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Documents Settings", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion
            // خواندن اطلاعات پایه قالب
            txtName.Text = DocTextData.Name;
            if (DocTextData.Code == null) txtTextCode.ValueObject = null;
            else txtTextCode.Value = Convert.ToInt32(DocTextData.Code);
            txtDescription.Text = DocTextData.Description;
            txtText.Text = DocTextData.TextsData;
            return true;
        }
        #endregion

        #endregion

    }
}