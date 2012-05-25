#region using
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Negar;
using DevComponents.DotNetBar;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Settings.Documents.Properties;
#endregion

namespace Sepehr.Settings.Documents
{
    /// <summary>
    /// فرم مدیریت گروه های قالب مدارك تصویربرداری
    /// </summary>
    internal partial class frmDocTemplatesGroupManage : Form
    {

        #region Ctors

        #region public frmDocTemplatesGroupManage()
        /// <summary>
        /// سازنده پیش فرض فرم در حالت افزودن
        /// </summary>
        public frmDocTemplatesGroupManage()
        {
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("Fa-Ir"));
            InitializeComponent();
            ShowDialog();
        }
        #endregion

        #region public frmDocTemplatesGroupManage(Int16 ColID)
        /// <summary>
        /// سازنده پیش فرض فرم در حالت ویرایش
        /// </summary>
        public frmDocTemplatesGroupManage(Int16 ColID)
        {
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("Fa-Ir"));
            InitializeComponent();
            if (!FillColData(ColID)) { Close(); return; }
            ShowDialog();
            SetControlsToolTipTexts();
        }
        #endregion

        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            SetControlsToolTipTexts();
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

            #region btnClose
            String TooltipText = ToolTipManager.GetText("btnCancel_NoApply", "IMS");
            FormToolTip.SetSuperTooltip(btnClose, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnSave
            TooltipText = ToolTipManager.GetText("btnAccept", "IMS");
            FormToolTip.SetSuperTooltip(btnSave, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

        }
        #endregion

        #region Boolean FillColData(Int16 ColID)
        /// <summary>
        /// اطلاعات فرم را كامل می كند
        /// </summary>
        /// <param name="ColID">كلید سرفصل</param>
        /// <returns>ٌصحت انجام كار</returns>
        private Boolean FillColData(Int16 ColID)
        {
            try
            {
                DocTemplate ColData = DBLayerIMS.Manager.DBML.
                    DocTemplates.Where(Data => Data.ID == ColID).ToList().First();
                txtName.Text = ColData.Name;
                txtDescription.Text = ColData.Description;
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان خواندن اطلاعات گروه های قالب مدارك تصویربرداری انتخاب شده از بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Documents Settings", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion
            return true;
        }
        #endregion

        #endregion

    }
}