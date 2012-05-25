using System.Windows.Forms;

namespace Aftab
{
    public partial class StartupForm : Form
    {
        public StartupForm()
        {
            InitializeComponent();
            Hide();
            new frmMainForm();
        }
    }
}