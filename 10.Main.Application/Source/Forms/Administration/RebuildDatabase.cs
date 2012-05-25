#region using
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Negar;
using Negar.DBLayerPMS.DataLayer;
using DevComponents.DotNetBar;
using Sepehr.Properties;
#endregion

namespace Sepehr.Forms.Administration
{
    /// <summary>
    /// فرم بازسازی ساختار ایندكس های جداول
    /// </summary>
    public partial class frmRebuildDatabase : Form
    {

        #region Fields

        #region List<TablesIndex> _IndexList
        /// <summary>
        /// لیست ایندكس های ثبت شده در زیر سیستم ها
        /// </summary>
        private List<TablesIndex> _IndexList;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmRebuildDatabase()
        {
            InitializeComponent();
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form_Load
        private void Form_Load(object sender, EventArgs e)
        {
            SetControlsToolTipTexts();
        }
        #endregion

        #region btnAccept_Click
        private void btnAccept_Click(object sender, EventArgs e)
        {
            // خواندن لیست ایندكس های صبت شده در بانك از جدول ایندكس ها
            try { _IndexList = Negar.DBLayerPMS.Manager.DBML.TablesIndexes.ToList(); }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان بازسازی ساختار بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Main Project", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return;
            }
            #endregion
            ProgressBarForm.Maximum = _IndexList.Count;
            Enabled = false;
            ProgressBarForm.Text = "در حال بازسازی بانك اطلاعات";
            BGWorker.RunWorkerAsync();
        }
        #endregion

        #region BGWorker_DoWork
        private void BGWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            RebuildDatabase();
        }
        #endregion

        #region BGWorker_ProgressChanged
        private void BGWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            ProgressBarForm.Value = e.ProgressPercentage;
        }
        #endregion

        #region BGWorker_RunWorkerCompleted
        private void BGWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            System.Threading.Thread.Sleep(1000);
            Enabled = true;
            ProgressBarForm.Text = "در انتظار بازسازی بانك اطلاعات";
            PMBox.Show("اتمام بازسازی بانك اطلاعاتی.", "تبریك!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            #region btnAccept
            TooltipText = ToolTipManager.GetText("btnRebuildDb", "IMS");
            FormToolTip.SetSuperTooltip(btnAccept, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

        }
        #endregion

        #region void RebuildDatabase()
        /// <summary>
        /// تابعی برای بازسازی تك به تك ایندكس ها
        /// </summary>
        void RebuildDatabase()
        {
            Negar.DBLayerPMS.Manager.DBML = null;
            Boolean Result = Negar.DBLayerPMS.Manager.ExecuteCommand(
                "USE [Master]; BACKUP LOG PatientsSystem WITH TRUNCATE_ONLY; " +
                "USE PatientsSystem; DBCC SHRINKFILE(2, 0); DBCC SHRINKDATABASE(PatientsSystem, 1);" +
                "USE [Master]; BACKUP LOG ImagingSystem WITH TRUNCATE_ONLY; " +
                "USE ImagingSystem; DBCC SHRINKFILE(2, 0); DBCC SHRINKDATABASE(ImagingSystem, 1);", 0);
            if (!Result)
            {
                const String ErrorMessage = "امكان بازسازی ساختار بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            for (Int32 i = 0; i < _IndexList.Count; i++)
                try
                {
                    Negar.DBLayerPMS.Manager.DBML.SP_RebuildIndex(
                         _IndexList[i].ApplicationDb, _IndexList[i].TableFullName, _IndexList[i].IndexName);
                }
                #region Catch
                catch (Exception Ex)
                {
                    const String ErrorMessage =
                        "امكان بازسازی ساختار بانك وجود ندارد.\n" +
                        "موارد زیر را بررسی نمایید:\n" +
                        "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogManager.SaveLogEntry("Sepehr", "Main Project", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                    continue;
                }
                #endregion
                finally { BGWorker.ReportProgress(i + 1); }
        }
        #endregion

        #endregion

    }
}