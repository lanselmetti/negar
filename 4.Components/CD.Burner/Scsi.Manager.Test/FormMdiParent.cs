using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using Helper.Forms;
using System.Reflection;

namespace BurnApp
{
	public partial class FormMdiParent : Form
	{
		private FormMain filesForm = new FormMain();
		private FormProcessing burnForm = new FormProcessing();

		public FormMdiParent()
		{
			this.InitializeComponent();
			this.Icon = ((Icon)(new ComponentResourceManager(typeof(FormMdiParent)).GetObject("$this.Icon")));
			this.filesForm.MdiParent = this;
			this.filesForm.FormClosed += new FormClosedEventHandler(form_FormClosed);
			this.burnForm.MdiParent = this;
			this.burnForm.FormClosed += new FormClosedEventHandler(form_FormClosed);
			const int GWL_EXSTYLE = -20, WS_EX_CLIENTEDGE = 0x00000200;
			foreach (Control ctl in this.Controls) { var mdi = ctl as MdiClient; if (mdi != null) { WinHelper.SetWindowLong(mdi, GWL_EXSTYLE, WinHelper.GetWindowLong(mdi, GWL_EXSTYLE) & ~WS_EX_CLIENTEDGE); } }
		}

		private void form_FormClosed(object sender, FormClosedEventArgs e) { if (e.CloseReason != CloseReason.MdiFormClosing) { this.Close(); } }
		private static void RemoveIcon(Form form) { var ms = (MenuStrip)(typeof(Form).GetProperty("MdiControlStrip", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)).GetValue(form, null); }
		private void miFileGC_Click(object sender, EventArgs e) { using (new CursorChange(this, Cursors.WaitCursor)) { GC.Collect(); GC.GetTotalMemory(true); GC.WaitForPendingFinalizers(); GC.Collect(); } }
		private void miFileExit_Click(object sender, EventArgs e) { Application.Exit(); }
		protected override void OnLoad(EventArgs e) { base.OnLoad(e); this.filesForm.Show(); }
		internal void DoWork(DoWorkInfo info) { this.filesForm.Hide(); this.burnForm.WindowState = FormWindowState.Maximized; this.burnForm.Show(); this.burnForm.DoWork(info); }
		internal void BurnComplete(RunWorkerCompletedEventArgs e) { this.burnForm.Hide(); this.filesForm.Show(); this.filesForm.WindowState = FormWindowState.Maximized; }
		private void miHelpAbout_Click(object sender, EventArgs e) { using (var form = new FormAbout()) { form.ShowDialog(this); } }
	}
}