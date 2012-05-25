using System.ComponentModel;
using System.Configuration.Install;

namespace Negar
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }
    }
}