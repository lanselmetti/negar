using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using FileSystems;
using Helper.Algorithms;
using Scsi;
using Helper.Forms;

namespace BurnApp
{
	public partial class FormProcessing : Form
	{
		private LinearProgressEstimator progress = new LinearProgressEstimator(32);
		private int lastProgressReportTick;
		private MasterStage lastMasterStage = MasterStage.None;
		private BurnStage lastStage = BurnStage.None;
		private BackgroundBurner bwCDBurner;
		private int startTime;

		public FormProcessing()
		{
			this.InitializeComponent();
			Program.SetProperty(this.lvProgress, "DoubleBuffered", true, true);
			Program.SetProperty(this.lvRecorders, "DoubleBuffered", true, true);
			this.bwCDBurner = new BackgroundBurner(this);
			this.bwCDBurner.ProgressChanged += new ProgressChangedEventHandler(bwCDBurner_ProgressChanged);
			this.bwCDBurner.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bwCDBurner_RunWorkerCompleted);
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			this.tbarUpdateInterval.Value = Program.SLOW_UPDATE_PAUSE_MILLIS < 1000 ? 1000 / Program.SLOW_UPDATE_PAUSE_MILLIS : (Program.SLOW_UPDATE_PAUSE_MILLIS > 1000 ? -Program.SLOW_UPDATE_PAUSE_MILLIS / 1000 : 0);
		}

		protected override void OnFormClosing(FormClosingEventArgs e) { e.Cancel |= this.bwCDBurner.IsBusy; base.OnFormClosing(e); }

		private void bwCDBurner_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			var tickCount = Environment.TickCount;
			var state = (ProgressInfo)e.UserState;
			bool canCalculateProgress;
			bool stateChanged = this.lastMasterStage != state.MasterStage | this.lastStage != state.BurnStage;
			if (stateChanged)
			{
				var newItem = this.lvProgress.Items.Add(new ListViewItem(new string[] { DateTime.Now.ToLongTimeString(), state.Description }));
				newItem.EnsureVisible();
				this.progress.Clear();
				this.lastMasterStage = state.MasterStage;
				this.lastStage = state.BurnStage;
				canCalculateProgress = false;
			}
			else { canCalculateProgress = true; }
			if (tickCount - this.lastProgressReportTick > Program.SLOW_UPDATE_PAUSE_MILLIS) { this.progress.ReportProgress((double)state.Completed / (double)state.Total); }

			var buf = state.ProgramBufferCapacity.GetValueOrDefault();
			this.epMain.SetError(this.lblUsedReadBufferLabel, state.BurnStage != BurnStage.FlushingBuffer && buf.Key * 2 < buf.Value ? "Warning: The read buffer level is currently too low and a buffer underrun may occur." + Environment.NewLine + "Either the write speed is higher than read speed or the refresh rate is too high." : null);
			this.pbBuffer.Maximum = (int)Math.Min(int.MaxValue, buf.Value);
			this.pbBuffer.Value = (int)Math.Min(int.MaxValue, buf.Key);
			this.lblUsedReadBuffer.Text = buf.Value != 0 ? string.Format("{0:N2} MiB of {1:N2} MiB ({2:P2})", buf.Key / (1024D * 1024D), buf.Value / (1024D * 1024D), buf.Key / (double)buf.Value) : string.Empty;
			var drvBuf = state.DriveBufferCapacity.GetValueOrDefault();

			bool invalidateRecorders = false;
			for (int i = 0; i < this.lvRecorders.Items.Count; i++)
			{
				this.lvRecorders.Items[i].SubItems[this.colBufferUsed.Index].Text = state.DriveBufferCapacity == null ? string.Empty : string.Format("{0:N0} bytes", drvBuf.BufferLength - drvBuf.BlankBufferLength);
				this.lvRecorders.Items[i].SubItems[this.colBufferCapacity.Index].Text = state.DriveBufferCapacity == null ? string.Empty : string.Format("{0:N0} bytes", drvBuf.BufferLength);
				this.lvRecorders.Items[i].SubItems[this.colBufferPercent.Index].Text = state.DriveBufferCapacity == null ? string.Empty : string.Format("{0:P2}", 1 - (double)drvBuf.BlankBufferLength / drvBuf.BufferLength);
			}
			if (invalidateRecorders) { this.lvRecorders.Invalidate(); }

			if (stateChanged || tickCount - this.lastProgressReportTick >= Program.SLOW_UPDATE_PAUSE_MILLIS)
			{
				this.lblCurrentFile.Text = string.Format("{0}", state.State);
				this.lblCompleted.Text = string.Format("{0:N0} of {1:N0} {2} ({3:P2})", state.Completed, state.Total, string.IsNullOrEmpty(state.ProgressUnits) ? "steps" : state.ProgressUnits.ToLower(), (double)state.Completed / state.Total);
				var speed = this.progress.CalculateCurrentSpeed(Program.INSTANTANEOUS_SPEED_INCLUSION_TIME) * 1000 /*to get % per second*/ * state.Total /*To get progress/sec*/;
				speed = Program.RoundUserFriendly(speed, 10, 4);
				this.lblStatus.Text = state.Description;
				this.lblSpeed.Text = double.IsNaN(speed) | speed < 0 ? string.Empty : string.Format("{0:N0} {1}/s", speed, string.IsNullOrEmpty(state.ProgressUnits) ? "steps" : state.ProgressUnits.ToLower());
				TimeSpan remaining = canCalculateProgress ? this.progress.GetTimeTo(1) : TimeSpan.Zero;
				if (remaining.TotalDays > 1) { remaining = new TimeSpan(10, 0, 0, 0); }
				if (remaining < TimeSpan.Zero) { remaining = TimeSpan.Zero; }
				this.lblElapsed.Text = canCalculateProgress ? Program.FormatTimeUserFriendly(TimeSpan.FromMilliseconds(Environment.TickCount - this.startTime), 32) : string.Empty;
				this.lblRemainingTime.Text = canCalculateProgress ? string.Format("{0} left", Program.FormatTimeUserFriendly(remaining, 3)) : string.Empty;
				this.lblEndTime.Text = canCalculateProgress ? (DateTime.Now + remaining).ToLongTimeString() : string.Empty;
				if (state.Total > int.MaxValue) { this.pbBurn.Maximum = int.MaxValue; this.pbBurn.Value = (int)((double)state.Completed * int.MaxValue / state.Total); }
				else { this.pbBurn.Maximum = (int)state.Total; this.pbBurn.Value = (int)state.Completed; }
				this.lastProgressReportTick = tickCount;
			}
		}

		internal void DoWork(DoWorkInfo info)
		{
			this.lvRecorders.Items.Clear();
			this.lvProgress.Items.Clear();

			string recorder;
			object target;
			if (info.TargetDevice != null)
			{
				target = info.TargetDevice;
				byte lun = info.TargetDevice.Interface.LogicalUnitNumber;
				byte busId = info.TargetDevice.Interface.PathId;
				byte targetId = info.TargetDevice.Interface.TargetId;
				byte port = info.TargetDevice.Interface.PortNumber;
				StandardInquiryData inquiry = info.TargetDevice.Interface.CdromInquiry();
				string vendor = VendorIdentifiers.GetVendorName(inquiry.VendorIdentification);
				if (vendor == null) { vendor = inquiry.VendorIdentification; }
				recorder = string.Format("{0} {1} {2}", vendor, inquiry.ProductIdentification, inquiry.ProductRevisionLevel);
			}
			else
			{
				target = info.TargetImage;
				recorder = info.TargetImage.ToString();
			}
			var item = new ListViewItem(new string[this.lvRecorders.Columns.Count])
			{
				Tag = new RecorderTag(target),
				UseItemStyleForSubItems = true,
			};
			item.SubItems[this.colRecorder.Index].Text = recorder;

			this.lvRecorders.Items.Add(item);
			this.lastMasterStage = MasterStage.None;
			this.lastStage = BurnStage.None;
			this.startTime = Environment.TickCount;
			this.bwCDBurner.RunWorkerAsync(info);
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			if (this.bwCDBurner.IsBusy)
			{
				if (MessageBox.Show(this, "Are you sure you want to cancel the burn process?" + Environment.NewLine + "The disc may be unreadable if you stop now.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
				{ this.bwCDBurner.CancelAsync(); }
			}
		}

		private void bwCDBurner_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (e.Error != null)
			{
				this.lblStatus.Text = "Error";
				this.lblCurrentFile.Text = e.Error.Message;
#if DEBUG
				var asTargetInvokEx = e.Error as System.Reflection.TargetInvocationException;
				throw asTargetInvokEx != null ? asTargetInvokEx.InnerException : e.Error;
#else
				MessageBox.Show(e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
			}
			else
			{
				this.lblStatus.Text = string.Empty;
				this.lblCurrentFile.Text = string.Empty;
				if (e.Cancelled) { MessageBox.Show(this, "Operation cancelled by user.", this.MdiParent.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
				else { MessageBox.Show(this, "Process finished successfully.", this.MdiParent.Text, MessageBoxButtons.OK, MessageBoxIcon.Information); }
			}
			((FormMdiParent)this.MdiParent).BurnComplete(e);
		}

		private void lvRecorders_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e) { e.DrawDefault = true; }
		private void lvRecorders_DrawItem(object sender, DrawListViewItemEventArgs e) { e.DrawDefault = true; }
		private void lvRecorders_DrawSubItem(object sender, DrawListViewSubItemEventArgs e) { e.DrawDefault = true; }

		private void lvProgress_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e) { e.DrawDefault = true; }
		private void lvProgress_DrawItem(object sender, DrawListViewItemEventArgs e) { e.DrawDefault = true; }
		private void lvProgress_DrawSubItem(object sender, DrawListViewSubItemEventArgs e) { e.DrawDefault = true; }

		private class RecorderTag { public RecorderTag(object target) { this.Target = target; } public object Target { get; private set; } }

		private class MyProgressBar : ProgressBar
		{
			private bool _Vertical;
			private bool _SmoothReverse = true;

			protected override CreateParams CreateParams { get { var cp = base.CreateParams; cp.ClassStyle |= 0x0200; if (this.Vertical) { cp.Style |= 4; } return cp; } }

			[DefaultValue(false)]
			public bool Vertical { get { return this._Vertical; } set { this._Vertical = value; if (base.IsHandleCreated) { base.RecreateHandle(); } } }

			[DefaultValue(false)]
			public bool SmoothReverse
			{
				get { return this._SmoothReverse; }
				set
				{
					if (this.IsHandleCreated)
					{
						int ws = WinHelper.GetWindowLong(this, -16);
						if (WinHelper.SetWindowLong(this, -16, value ? ws | 0x10 : ws & ~0x10) == 0) { Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error()); }
					}
					this._SmoothReverse = value;
				}
			}

			protected override void OnHandleCreated(EventArgs e) { this.SmoothReverse = this._SmoothReverse; base.OnHandleCreated(e); }
		}

		private void tbarUpdateInterval_ValueChanged(object sender, EventArgs e)
		{
			var pauseMS = this.tbarUpdateInterval.Value > 0 ? 1000 / (double)this.tbarUpdateInterval.Value : (this.tbarUpdateInterval.Value < 0 ? -(double)this.tbarUpdateInterval.Value * 1000 : 1000);
			Program.SLOW_UPDATE_PAUSE_MILLIS = (int)pauseMS;
			this.lblUpdateSpeed.Text = string.Format("{0:N2} updates/second", (double)1000 / (double)pauseMS);
			this.epMain.SetError(this.lblUpdateSpeedLabel, pauseMS >= 40 ? null : "Warning: High refresh rates can use up a lot of CPU and cause buffer underruns." + Environment.NewLine + "It is recommended that you lower the refresh rate.");
		}
	}
}