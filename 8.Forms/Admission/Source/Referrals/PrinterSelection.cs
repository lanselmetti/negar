#region using

using System;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Negar;
using DevComponents.DotNetBar;
using Sepehr.Forms.Admission.Properties;

#endregion

namespace Sepehr.Forms.Admission.Referrals
{
    /// <summary>
    /// فرم انتخاب چاپگر
    /// </summary>
    internal partial class frmPrinterSelection : Form
    {

        #region Fields & Properties

        #region readonly String _DefaultPrinterName
        private readonly String _DefaultPrinterName;
        #endregion

        #region DefaultPrinterName
        public String DefaultPrinterName { get { return _DefaultPrinterName; } }
        #endregion

        #endregion

        #region Ctor
        public frmPrinterSelection()
        {
            InitializeComponent();
            foreach (String item in PrinterSettings.InstalledPrinters) lstPrinterList.Items.Add(item);
            PrinterSettings DefaultPrinter = new PrinterSettings();
            try { _DefaultPrinterName = DefaultPrinter.PrinterName; }
            catch { _DefaultPrinterName = ""; }
            if (lstPrinterList.Items.Count == 0)
            {
                PMBox.Show("پرینتری برای نمایش وجود ندارد!", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Dispose();
            }
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            SetControlsToolTipTexts();
        }
        #endregion

        #region btnSave_Click
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (lstPrinterList.SelectedIndex == -1)
            {
                PMBox.Show("آیتمی برای تنظیم انتخاب نشده است!", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult = DialogResult.OK;
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

        #endregion

        #region Classes
        internal static class PrinterManager
        {
            [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern Boolean SetDefaultPrinter(String Name);
        }
        #endregion

    }
}