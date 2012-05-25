#region using
using System;
using System.IO;
using System.Windows.Forms;
using Negar;
using Negar.DAM;
using DevComponents.DotNetBar;
using Sepehr.Properties;
#endregion

namespace Sepehr.Forms.SpecialReports
{
    /// <summary>
    /// فرم نمایش گزارش های اختصاصی مشتریان
    /// </summary>
    public partial class frmList : Form
    {

        #region Fields

        #region PluginManager _PluginManager
        private PluginManager _PluginManager;
        #endregion

        #region String[] _PluginsList
        private String[] _PluginsList;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmList()
        {
            InitializeComponent();
            if (!Directory.Exists(Application.StartupPath + "\\ReportPlugins"))
                Directory.CreateDirectory(Application.StartupPath + "\\ReportPlugins");
            btnRefresh_Click(null, null);
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

        #region btnRefresh_Click
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (_PluginManager != null)
            {
                _PluginManager.PluginsReloaded -= _PluginManager_PluginsReloaded;
                _PluginManager.Stop();
                _PluginManager = null;
            }
            _PluginManager = new PluginManager();
            _PluginManager.PluginsReloaded += _PluginManager_PluginsReloaded;
            _PluginManager.Start();
        }
        #endregion

        #region _PluginManager_PluginsReloaded
        void _PluginManager_PluginsReloaded(Object sender, EventArgs e)
        {
            _PluginManager.PluginsReloaded -= _PluginManager_PluginsReloaded;
            _PluginManager.PluginSources = PluginSourceEnum.DynamicAssemblies;
            String[] AllPluginsList = _PluginManager.GetSubClasses("System.Object");
            _PluginsList = new String[AllPluginsList.Length];
            for (Int32 Index = lstReportsList.Items.Count - 1; Index >= 0; Index--)
            {
                lstReportsList.Items[Index].Dispose();
                lstReportsList.Items.RemoveAt(Index);
            }
            Int32 i = 0;
            foreach (String ReportPlugins in AllPluginsList)
            {
                if (ReportPlugins == null || ReportPlugins.Length < 28 ||
                    ReportPlugins.Substring(0, 28) != "Negar.Customers.StartReports") continue;
                _PluginsList[i] = ReportPlugins;
                i++;
                ButtonItem btnReport = new ButtonItem();
                btnReport.Tag = ReportPlugins;
                btnReport.Text = " " + _PluginManager.GetStaticPropertyValue(ReportPlugins, "ReportName");
                btnReport.Tooltip = "تاریخ تولید گزارش: " + _PluginManager.GetStaticPropertyValue(ReportPlugins, "ReleaseDate") +
                    "\nنسخه گزارش: " + _PluginManager.GetStaticPropertyValue(ReportPlugins, "Version");
                btnReport.Click += ReportLabel_Click;
                lstReportsList.Items.Add(btnReport);
            }
            _PluginManager.Stop();
            _PluginManager = null;
        }
        #endregion

        #region ReportLabel_Click
        void ReportLabel_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _PluginManager = new PluginManager();
            _PluginManager.PluginSources = PluginSourceEnum.DynamicAssemblies;
            _PluginManager.IgnoreErrors = true;
            _PluginManager.Start();
            Object[] CSName = new Object[1];
            CSName[0] = CSManager.CurrentSetting;
            _PluginManager.CallStaticMethod(((ButtonItem)sender).Tag.ToString(), "StartReport", CSName);
            _PluginManager.AutoReload = false;
            _PluginManager.Stop();
            Cursor = Cursors.Default;
        }
        #endregion

        #region Form_Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            if (_PluginManager != null)
            {
                _PluginManager.PluginsReloaded -= _PluginManager_PluginsReloaded;
                _PluginManager.Stop();
                _PluginManager = null;
            }
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
            const String TooltipText = "نمایش آموزش كاربری فرم.\r\n" +
                "این راهنمای كاربری به شما در مورد نحوه عملكرد فرم كمك مینماید.";
            FormToolTip.SetSuperTooltip(btnHelp, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion
        }
        #endregion

        #endregion

    }
}