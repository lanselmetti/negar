using System.Windows.Forms;
namespace System.Shell
{
	public class ShellChangeNotifyEventArgs : EventArgs
	{
		public ShellChangeNotifyEventArgs(ShellItemIdList idList1, ShellItemIdList idList2, ShellChangeNotificationEvents type)
		{
			this.ItemIdList1 = idList1;
			this.ItemIdList2 = idList2;
			this.ChangeType = type;
		}

		public ShellItemIdList ItemIdList1 { get; set; }
		public ShellItemIdList ItemIdList2 { get; set; }
		public ShellChangeNotificationEvents ChangeType { get; private set; }
	}
}