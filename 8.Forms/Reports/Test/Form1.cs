#region using
using System;
using System.Windows.Forms;
using Negar;

#endregion

namespace Test_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CSManager.CurrentSetting = "اتصال به سرور محلی";
            SecurityManager.CurrentUserID = 2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Sepehr.Forms.Reports.Designables.frmReports();
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            switch (listBox1.SelectedIndex)
            {
                case 0: new Sepehr.Forms.Reports.General.Report01.frmFilter(); break;
                case 1: new Sepehr.Forms.Reports.General.Report02.frmFilter(); break;
                case 2: new Sepehr.Forms.Reports.General.Report03.frmFilter(); break;
                case 3: new Sepehr.Forms.Reports.General.Report04.frmFilter(); break;
                case 4: new Sepehr.Forms.Reports.General.Report05.frmFilter(); break;
                case 5: new Sepehr.Forms.Reports.General.Report06.frmFilter(); break;
                case 6: new Sepehr.Forms.Reports.General.Report07.frmFilter(); break;
                case 7: new Sepehr.Forms.Reports.General.Report08.frmFilter(); break;
                case 8: new Sepehr.Forms.Reports.General.Report09.frmFilter(); break;
                case 9: new Sepehr.Forms.Reports.General.Report10.frmFilter(); break;
                case 10: new Sepehr.Forms.Reports.General.Report11.frmFilter(); break;
                case 11: new Sepehr.Forms.Reports.General.Report12.frmFilter(); break;
                case 12: new Sepehr.Forms.Reports.General.Report13.frmFilter(); break;
                case 13: new Sepehr.Forms.Reports.General.Report14.frmFilter(); break;
                case 14: new Sepehr.Forms.Reports.General.Report15.frmFilter(); break;
                case 15: new Sepehr.Forms.Reports.General.Report16.frmFilter(); break;
                case 16: new Sepehr.Forms.Reports.General.Report17.frmFilter(); break;
                case 17: new Sepehr.Forms.Reports.General.Report18.frmFilter(); break;
                case 18: new Sepehr.Forms.Reports.General.Report19.frmFilter(); break;
                case 19: new Sepehr.Forms.Reports.General.Report20.frmFilter(); break;
                case 20: new Sepehr.Forms.Reports.General.Report21.frmFilter(); break;
            }
        }
    }
}