using System.Windows.Forms;
using System;
using Scsi.Multimedia;

namespace BurnApp
{
	public partial class FormBlank : Form
	{
		public FormBlank()
		{
			this.InitializeComponent();
			//Program.SetProperty(this, "Font", System.Drawing.SystemFonts.DialogFont, true);
		}

		private void rbBlankTrack_CheckedChanged(object sender, EventArgs e) { this.nudTrackNumber.Enabled = this.rbBlankTrack.Checked; }
		private void rbBlankTrackTail_CheckedChanged(object sender, EventArgs e) { this.nudStartLBA.Enabled = this.rbBlankTrackTail.Checked; }
		public decimal MaximumTrackNumber { get { return this.nudTrackNumber.Maximum; } set { this.nudTrackNumber.Maximum = value; } }
		public decimal MaximumStartLBA { get { return this.nudStartLBA.Maximum; } set { this.nudStartLBA.Maximum = value; } }
		public decimal MinimumTrackNumber { get { return this.nudTrackNumber.Minimum; } set { this.nudTrackNumber.Minimum = value; } }
		public decimal MinimumStartLBA { get { return this.nudStartLBA.Minimum; } set { this.nudStartLBA.Minimum = value; } }

		public BlankCommand BlankCommand
		{
			get
			{
				if (this.DialogResult == DialogResult.OK)
				{
					BlankingType type;
					if (this.rbBlank.Checked) { type = BlankingType.Blank; }
					else if (this.rbBlankMinimal.Checked) { type = BlankingType.BlankMinimal; }
					else if (this.rbBlankTrack.Checked) { type = BlankingType.BlankTrack; }
					else if (this.rbBlankTrackTail.Checked) { type = BlankingType.BlankTrackTail; }
					else if (this.rbBlankLastSession.Checked) { type = BlankingType.EraseSession; }
					else if (this.rbUncloseLastSession.Checked) { type = BlankingType.UncloseLastSession; }
					else if (this.rbUnreserveTrack.Checked) { type = BlankingType.UnreserveTrack; }
					else { throw new InvalidOperationException(); }

					uint lbaOrTrack;
					if (type == BlankingType.BlankTrack) { lbaOrTrack = decimal.ToUInt32(this.nudTrackNumber.Value); }
					else if (type == BlankingType.BlankTrackTail) { lbaOrTrack = decimal.ToUInt32(this.nudStartLBA.Value); }
					else { lbaOrTrack = 0; }
					return new BlankCommand(type, true, lbaOrTrack);
				}
				else { return null; }
			}
		}
	}
}