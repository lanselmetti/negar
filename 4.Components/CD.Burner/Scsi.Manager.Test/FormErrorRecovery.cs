using System.Windows.Forms;
using Scsi;

namespace BurnApp
{
	public partial class FormErrorRecovery : Form
	{
		public FormErrorRecovery() { this.InitializeComponent(); }

		public ReadWriteErrorRecoveryParametersPage SelectedObject { get { return (ReadWriteErrorRecoveryParametersPage)this.peMain.SelectedObject; } set { this.peMain.SelectedObject = value; } }
	}
}