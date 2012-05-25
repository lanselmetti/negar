using System;
using System.Windows.Forms;
using Negar;
using Negar.Medical.VideoCapture;

namespace CaptureTest
{
    public partial class TestFormManager : Form
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new TestFormManager());
        }

        public TestFormManager()
        {
            InitializeComponent();
            CSManager.CurrentSetting = "اتصال به سرور محلی";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CaptureHelper.ShowCaptureForm(1234);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CaptureHelper.ReleaseCachedData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new CaptureTest();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CaptureHelper.ShowClipForm(1234);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CaptureHelper.ShowCaptureClipForm(1234);
        }
    }
}
