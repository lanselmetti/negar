using System.Windows.Forms;

namespace Reports_Test_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            switch (listBox1.SelectedIndex)
            {
                case 0: Negar.Customers.StartReports0001.ReportStartClass.StartReport("اتصال به سرور محلی"); break;
                case 1: Negar.Customers.StartReports0002.ReportStartClass.StartReport("اتصال به سرور محلی"); break;
                case 2: Negar.Customers.StartReports0003.ReportStartClass.StartReport("اتصال به سرور محلی"); break;
                case 3: Negar.Customers.StartReports0004.ReportStartClass.StartReport("اتصال به سرور محلی"); break;
                //case 4: Negar.Customers.StartReports0005.ReportStartClass.StartReport("اتصال به سرور محلی"); break;
                //case 5: Negar.Customers.StartReports0006.ReportStartClass.StartReport("اتصال به سرور محلی"); break;
            }
        }
    }
}
