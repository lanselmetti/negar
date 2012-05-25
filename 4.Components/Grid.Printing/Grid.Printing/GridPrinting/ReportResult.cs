#region using
using System;
using System.Drawing.Printing;
using System.Windows.Forms;
using Negar;
using Negar.Properties;
using DevComponents.DotNetBar;
#endregion

namespace Negar.GridPrinting
{
    /// <summary>
    /// فرم پیش نمایش چاپ گزارش 
    /// </summary>
    internal partial class frmReportResult : Form
    {

        #region Fields

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmReportResult(PrintDocument SentPrintDocument)
        {
            InitializeComponent();
            PrintPreviewControlForm.Document = SentPrintDocument;
            PrintPreviewControlForm.Show();
            PrintPreviewControlForm.Refresh();
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            SetControlsToolTipTexts();
        }
        #endregion

        #region btnShowPageColumns_Click
        private void btnShowPageColumns_Click(object sender, EventArgs e)
        {
            if (((ButtonX)sender).Name == "btnShow1Page") PrintPreviewControlForm.Columns = 1;
            else PrintPreviewControlForm.Columns = 2;
        }
        #endregion

        #region txtPageNum_ValueChanged
        private void txtPageNum_ValueChanged(object sender, EventArgs e)
        {
            PrintPreviewControlForm.StartPage = txtPageNum.Value - 1;
            Boolean IsLastPage = false;
            if (PrintPreviewControlForm.StartPage != txtPageNum.Value - 1) IsLastPage = true;
            txtPageNum.ValueChanged -= txtPageNum_ValueChanged;
            txtPageNum.Value = PrintPreviewControlForm.StartPage + 1;
            txtPageNum.ValueChanged += txtPageNum_ValueChanged;
            if (!IsLastPage) PrintPreviewControlForm.InvalidatePreview();
        }
        #endregion

        #region SliderPreviewZoom_ValueChanged
        private void SliderPreviewZoom_ValueChanged(object sender, EventArgs e)
        {
            SliderPreviewZoom.Text = "بزرگنمایی: %" + SliderPreviewZoom.Value;
            PrintPreviewControlForm.Zoom = Convert.ToDouble(Convert.ToDouble(SliderPreviewZoom.Value) / 100.0);
        }
        #endregion

        #region btnPrinterSettings_Click
        private void btnPrinterSettings_Click(object sender, EventArgs e)
        {
            DialogResult Dr = PrinterDialog.ShowDialog();
            if (Dr == DialogResult.OK)
                PrintPreviewControlForm.Document.PrinterSettings = PrinterDialog.PrinterSettings;
        }
        #endregion

        #region btnPrint_Click
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                PrintPreviewControlForm.Document.Print();
            }
            // ReSharper disable EmptyGeneralCatchClause
            catch (Exception) { }
            // ReSharper restore EmptyGeneralCatchClause
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
            String TooltipText = ToolTipManager.GetText("btnClose", "IMS");
            FormToolTip.SetSuperTooltip(btnCancel, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnHelp
            TooltipText = ToolTipManager.GetText("btnHelp", "IMS");
            FormToolTip.SetSuperTooltip(btnHelp, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region  btnPrintSettings
            TooltipText = ToolTipManager.GetText("btnGridPrintingPrinterSettings", "IMS");
            FormToolTip.SetSuperTooltip(btnPrinterSettings, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnPrint
            TooltipText = ToolTipManager.GetText("btnPrintReport", "IMS");
            FormToolTip.SetSuperTooltip(btnPrint, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

        }
        #endregion

        #endregion

    }
}