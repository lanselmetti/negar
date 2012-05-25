using DevComponents.DotNetBar;

namespace Negar.Forms
{
    public partial class frmLicenseAgreement : Office2007Form
    {
        public frmLicenseAgreement()
        {
            InitializeComponent();
            txtText.Text = Properties.Resources.LicenseAgreement;
            txtText.Select(0 , 0);
        }
    }
}