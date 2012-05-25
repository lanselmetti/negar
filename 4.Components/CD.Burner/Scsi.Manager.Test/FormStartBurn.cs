using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System;
using Helper.IO;
using Scsi;
using Scsi.Multimedia;
using System.IO;
using System.ComponentModel;
using System.Drawing;

namespace BurnApp
{
	public partial class FormStartBurn : Form
	{
		private int lastMediaChangeCount = 0;

		public FormStartBurn()
		{
			this.InitializeComponent();
			//Program.SetProperty(this, "Font", System.Drawing.SystemFonts.DialogFont, true);
		}

		private class WriteSpeed
		{
			private string description;
			public WriteSpeed(SetCDSpeedCommand command, string description) { this.Command = command; this.description = description; }
			public override string ToString() { return this.description; }
			public SetCDSpeedCommand Command { get; set; }
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		protected override void OnLoad(EventArgs e)
		{
			this.RefreshDrive();
			var mem = MemoryStatusEx.GlobalMemoryStatusEx();
			this.BufferSize = (int)Math.Max(1024 * 1024, Math.Min(mem.availPhys * 0.5, int.MaxValue));
			this.RefreshMem();
			base.OnLoad(e);
			this.tmrRefresh.Start();
		}

		protected override void OnShown(EventArgs e)
		{
			this.btnOK.Focus();
			base.OnShown(e);
		}

		private void tmrRefresh_Tick(object sender, EventArgs e) { this.RefreshDrive(); }

		private void RefreshDrive()
		{
			using (new CursorChange(this, Cursors.WaitCursor))
			{
				if (this.CurrentDevice != null)
				{
					int cv = -2;
					//Do NOT use CheckVerify2() -- it doesn't work with Windows 7 for some reason...
					cv = this.CurrentDevice.Interface.CheckVerify();
					if (cv == -2 || cv != this.lastMediaChangeCount)
					{
						if (this.lastMediaChangeCount != cv)
						{
							bool enabled = cv >= 0;
							if (this.btnOK.Enabled != enabled)
							{
								this.btnOK.Enabled = enabled;
								if (this.btnCancel.Focused) { this.btnOK.Focus(); }
							}
							this.RefreshDriveNoCheck();
						}
						this.lastMediaChangeCount = cv;
					}
				}
				else
				{
					this.chkFinalize.Enabled = this.chkSimulation.Enabled = this.chkBufferUnderrunProtection.Enabled = this.cmbDataBlockType.Enabled = this.cmbWriteSpeed.Enabled = this.cmbWriteType.Enabled = false;
					this.Text = "Burn Disc - Image";
				}
			}
		}

		private void RefreshDriveNoCheck()
		{
			this.tlpMain.SuspendLayout();
			try
			{
				var inq = this.CurrentDevice.Inquiry();
				this.Text = string.Format("Burn Disc - {0} {1} {2}", VendorIdentifiers.GetVendorName(inq.VendorIdentification), inq.ProductIdentification, inq.ProductRevisionLevel);
				//Win32DeviceType devType;
				//var infos = this.CurrentDevice.GetMediaTypesEx(out devType);

				//Do NOT use CheckVerify2() -- it doesn't work with Windows 7 for some reason...
				bool mediaPresent = this.CurrentDevice.Interface.CheckVerify() >= 0;
				string capacityStr;
				if (mediaPresent)
				{
					//long capacity = infos[0].BytesPerSector * (long)infos[0].SectorsPerTrack * (long)infos[0].TracksPerCylinder * (long)infos[0].Cylinders;
					long capacity = GetCapacity(this.CurrentDevice);
					DataUnits units;
					string s = Program.FormatByteSize(capacity, 64, 2, out units);
					capacityStr = string.Format("{0} {1}", s, Program.GetUserFriendlyString(units));
				}
				else { capacityStr = "N/A"; }
				this.txtDiscCapacity.Text = capacityStr;
				DiscInformationBlock discInfo = mediaPresent ? this.CurrentDevice.ReadDiscInformation() : null;
				var a = (EnumValueDisplayNameAttribute)Attribute.GetCustomAttribute(typeof(MultimediaProfile).GetField(this.CurrentDevice.CurrentProfile.ToString()), typeof(EnumValueDisplayNameAttribute));
				this.lblCurrentDisc.Text = mediaPresent && a != null ? a.DisplayName : "(no disc)";
				this.lblDiscStatus.Text = discInfo != null ? discInfo.DiscStatus.ToString() : "N/A";
				this.lblSessions.Text = discInfo != null ? string.Format("{0:N0} {1} containing {2:N0} {3}", discInfo.SessionCount, discInfo.SessionCount == 1 ? "session" : "sessions", discInfo.LastTrackNumberInLastSession + 1 - discInfo.FirstTrackNumberInLastSession, discInfo.LastTrackNumberInLastSession == discInfo.FirstTrackNumberInLastSession ? "track" : "tracks") : "N/A";
				
				this.cmbWriteSpeed.Items.Clear();
				if (this.CurrentDevice != null)
				{
					this.cmbWriteSpeed.Items.Add(new WriteSpeed(new SetCDSpeedCommand(ushort.MaxValue, ushort.MaxValue, RotationControl.ConstantLinearVelocity), "Maximum"));
					foreach (WriteSpeedDescriptor speed in this.CurrentDevice.GetPerformance(new GetPerformanceCommand(0, ushort.MaxValue, new WriteSpeedInformation())).PerformanceDescriptors)
					{
						var command = new SetCDSpeedCommand(checked((ushort)speed.ReadSpeed), checked((ushort)speed.WriteSpeed), speed.WriteRotationControl);
						var multiple = GetSpeed(command.LogicalUnitWriteSpeed, this.CurrentDevice.CurrentProfile);
						string desc = string.Format("{0:N0} KB/s", command.LogicalUnitWriteSpeed);
						if (!double.IsNaN(multiple)) { desc = string.Format("{0:N0}× ({1})", multiple, desc); }
						this.cmbWriteSpeed.Items.Add(new WriteSpeed(command, desc));
					}
					this.cmbWriteSpeed.Items.Add(new WriteSpeed(null, "No change"));
					if (this.cmbWriteSpeed.SelectedIndex < 0) { this.cmbWriteSpeed.SelectedIndex = 0; }
				}

				//Assume track-at-once is always supported
				bool sao = false;
				bool testWrite = false;
				bool bufferUnderrunProtection = false;
				DataBlockTypesSupported supported = DataBlockTypesSupported.Mode1; //Assume this is always supported

				var taoFeature = this.CurrentDevice == null ? null : this.CurrentDevice.GetConfiguration<CDTrackAtOnceFeature>();
				if (taoFeature != null && taoFeature.Current) { supported |= taoFeature.DataBlockTypesSupported; bufferUnderrunProtection |= taoFeature.BufferUnderrunProtection; testWrite |= taoFeature.TestWrite; }

				var iswFeature = this.CurrentDevice == null ? null : this.CurrentDevice.GetConfiguration<IncrementalStreamingWritableFeature>();
				if (iswFeature != null && iswFeature.Current) { supported |= iswFeature.DataBlockTypesSupported; bufferUnderrunProtection |= iswFeature.BufferUnderrunProtection; }

				var saoFeature = this.CurrentDevice == null ? null : this.CurrentDevice.GetConfiguration<CDMasteringFeature>();
				if (saoFeature != null && saoFeature.Current) { bufferUnderrunProtection |= saoFeature.BufferUnderrunProtection; sao |= saoFeature.SessionAtOnce; testWrite |= saoFeature.TestWrite; }

				var dvdmrwWriteFeature = this.CurrentDevice == null ? null : this.CurrentDevice.GetConfiguration<DvdMinusRWWriteFeature>();
				if (dvdmrwWriteFeature != null && dvdmrwWriteFeature.Current) { bufferUnderrunProtection |= dvdmrwWriteFeature.BufferUnderrunProtection; testWrite |= dvdmrwWriteFeature.TestWrite; }

				this.cmbWriteType.Items.Clear();
				this.cmbWriteType.Items.Add(new EnumValue(WriteType.TrackAtOnce));
				this.cmbWriteType.SelectedIndex = 0;
				if (sao) { this.cmbWriteType.Items.Add(new EnumValue(WriteType.SessionAtOnce)); }

				this.chkBufferUnderrunProtection.Enabled = bufferUnderrunProtection;

				this.chkSimulation.Enabled = testWrite;

				this.cmbDataBlockType.Items.Clear();
				for (int i = 0; i < sizeof(DataBlockTypesSupported) * 8; i++)
				{
					var type = (DataBlockTypesSupported)(1 << i);
					if ((type == DataBlockTypesSupported.Mode1 || type == DataBlockTypesSupported.Mode2XAForm1) && (supported & type) != 0)
					{
						this.cmbDataBlockType.Items.Add(new EnumValue((DataBlockType)i));
						if (this.cmbDataBlockType.SelectedIndex < 0) { this.cmbDataBlockType.SelectedIndex = 0; }
					}
				}
			}
			finally { this.tlpMain.ResumeLayout(true); }
		}

		private static double GetSpeed(ushort kbps, MultimediaProfile multimediaProfile)
		{
			double unit;
			switch (multimediaProfile)
			{
				case MultimediaProfile.CDROM:
				case MultimediaProfile.CDR:
				case MultimediaProfile.CDRW:
					unit = 75D /*frames per second*/ * 2352D /*bytes per sector*/ / 1000D /*1000 bytes per KB*/; //176.4;
					break;
				case MultimediaProfile.DvdRom:
				case MultimediaProfile.DvdMinusRSequentialRecording:
				case MultimediaProfile.DvdRam:
				case MultimediaProfile.DvdMinusRWRestrictedOverwrite:
				case MultimediaProfile.DvdMinusRWSequentialRecording:
				case MultimediaProfile.DvdMinusRDualLayerSequentialRecording:
				case MultimediaProfile.DvdMinusRDualLayerJumpRecording:
				case MultimediaProfile.DvdMinusRWDualLayer:
				case MultimediaProfile.DvdPlusRW:
				case MultimediaProfile.DvdPlusR:
				case MultimediaProfile.DvdPlusRWDualLayer:
				case MultimediaProfile.DvdPlusRDualLayer:
					unit = 1385;
					break;
				default:
					unit = double.NaN;
					break;
			}
			return Math.Round(kbps / unit);
		}

		private static long GetCapacity(MultimediaDevice multimediaDevice)
		{
			var info = multimediaDevice.ReadTrackInformation(new ReadTrackInformationCommand(false, TrackIdentificationType.LogicalTrackNumber, (uint)(multimediaDevice.FirstTrackNumber + multimediaDevice.TrackCount) - 1));
			return (long)info.LogicalTrackSize * (long)multimediaDevice.BlockSize;
		}

		public MultimediaDevice CurrentDevice { get; set; }
		public long ApproximateSpaceNeeded { get; set; }
		public SetCDSpeedCommand SetCDSpeed { get { return this.cmbWriteSpeed.SelectedIndex >= 0 ? ((WriteSpeed)this.cmbWriteSpeed.SelectedItem).Command : null; } }
		public bool EmbedFiles { get { return this.chkEmbedFiles.Enabled && this.chkEmbedFiles.Checked; } }
		public bool FindDuplicates { get { return this.chkFindDuplicates.Enabled && this.chkFindDuplicates.Checked; } }
		public bool MasteringOptionsEnabled { get { return this.chkEmbedFiles.Enabled | this.chkFindDuplicates.Enabled; } set { this.chkFindDuplicates.Enabled = this.chkEmbedFiles.Enabled = value; } }

		public int BufferSize
		{
			get
			{
				var p = (double)this.tbBufferSize.Value / (double)this.tbBufferSize.Maximum;
				var mem = MemoryStatusEx.GlobalMemoryStatusEx();
				return checked((int)Math.Min(Math.Min(Math.Max(1024 * 1024, (long)(p * mem.totalPageFile)), mem.totalPageFile - 32 * 1024 * 1024 /*In case user selects 100%, leave a small amount*/), int.MaxValue));
			}
			set { var mem = MemoryStatusEx.GlobalMemoryStatusEx(); this.tbBufferSize.Value = (int)((double)value * (double)this.tbBufferSize.Maximum / (double)mem.totalPageFile); }
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (this.CurrentDevice != null)
			{
				var wp = this.CurrentDevice.GetWriteParameters(new ModeSense10Command(PageControl.DefaultValues));
				wp.BufferUnderrunProtection = this.chkBufferUnderrunProtection.Enabled && this.chkBufferUnderrunProtection.Checked;
				wp.TestWrite = this.chkSimulation.Enabled && this.chkSimulation.Checked;
				if (this.cmbDataBlockType.Enabled && this.cmbDataBlockType.SelectedIndex >= 0)
				{ wp.DataBlockType = (DataBlockType)((EnumValue)this.cmbDataBlockType.SelectedItem).Value; }
				if (this.chkFinalize.Enabled)
				{ wp.MultiSession = this.chkFinalize.Checked ? MultisessionType.SingleSession : MultisessionType.Multisession; }
				if (this.cmbWriteType.Enabled && this.cmbWriteType.SelectedIndex >= 0)
				{ wp.WriteType = (WriteType)((EnumValue)this.cmbWriteType.SelectedItem).Value; }
				this.CurrentDevice.SetWriteParameters(new ModeSelect10Command(false, true), wp);
			}
		}

		private void lnkPrefixHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			MessageBox.Show(this,
				"Originally, one \"kilobyte\" (1 KB) used to mean 1024 bytes." + Environment.NewLine +
				"Some companies, however, used the word to mean 1000 bytes." + Environment.NewLine +
				"Because of this, these new prefixes were developed for disambiguation:" + Environment.NewLine + 
				Environment.NewLine +
				"1 MB  = 1,000 KB = 1,000,000 bytes" + Environment.NewLine + "1 MiB = 1,024 KiB = 1,048,576 bytes" + Environment.NewLine + Environment.NewLine + "et cetera.",
				"Byte Prefix Notation", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void tbBufferSize_ValueChanged(object sender, EventArgs e) { this.RefreshMem(); }

		private void RefreshMem() { this.lblBufferSize.Text = string.Format("{0:P1}" + Environment.NewLine + "({1:N0} MiB)", (double)this.tbBufferSize.Value / (double)this.tbBufferSize.Maximum, (double)this.BufferSize / (1024 * 1024)); }
	}
}