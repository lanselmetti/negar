using System;
using System.Windows.Forms;
using Negar.DAM;

namespace Test_Project
{
    public partial class Form1 : Form
    {
        private PluginManager _PluginManager;
        private String[] _PluginsList;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _PluginManager = new PluginManager();
            _PluginManager.PluginsReloaded += (_PluginManager_PluginsReloaded);
            _PluginManager.Start();
        }

        void _PluginManager_PluginsReloaded(Object sender, EventArgs e)
        {
            _PluginsList = _PluginManager.GetSubClasses("System.Object");
            lstReports.Items.Clear();
            foreach (String ReportPlugins in _PluginsList)
            {
                lstReports.Items.Add("نام شیء گزارش: " + ReportPlugins +
                    " - نام فارسی گزارش: " + _PluginManager.GetStaticPropertyValue(ReportPlugins, "ReportName") +
                    " - نام سفارش دهنده گزارش:" + _PluginManager.GetStaticPropertyValue(ReportPlugins, "CustomerName") +
                    " - تاریخ تولید گزارش: " + _PluginManager.GetStaticPropertyValue(ReportPlugins, "ReleaseDate") +
                    " - نسخه گزارش: " + _PluginManager.GetStaticPropertyValue(ReportPlugins, "Version") +
                    " - نام آخرین برنامه نویس: " + _PluginManager.GetStaticPropertyValue(ReportPlugins, "LastDeveloper"));
            }
            _PluginManager.PluginsReloaded -= (_PluginManager_PluginsReloaded);
            _PluginManager.Stop();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _PluginManager = new PluginManager();
            _PluginManager.Start();
            _PluginManager.CallStaticMethod(_PluginsList[lstReports.SelectedIndex], "StartReport", null);
            _PluginManager.Stop();
            _PluginManager = null;

        }
    }
}
