using System.IO;
using Helper.IO;
//#define RESERVE_TRACK

namespace Scsi.Multimedia
{
    public class TrackStream : SubStream
    {
        private readonly MultimediaDevice device;
        private ushort trackNumber;
#if RESERVE_TRACK
		private bool started = false;
		private bool trackReserved = false;
#endif

        public TrackStream(MultimediaDevice device, ushort trackNumber, long startPos, long length, long maxLength,
                           bool leaveOpen)
            : base(new ScsiStream(device), startPos, length, maxLength, leaveOpen)
        {
            this.device = device;
            this.trackNumber = trackNumber;
#if CLOSE
			switch (device.CurrentProfile)
			{
				case MultimediaProfile.CDROM:
				case MultimediaProfile.CDR:
				case MultimediaProfile.CDRW:
				case MultimediaProfile.DvdRom:
				case MultimediaProfile.DvdMinusRSequentialRecording:
				case MultimediaProfile.DvdMinusRWRestrictedOverwrite:
				case MultimediaProfile.DvdMinusRWSequentialRecording:
				case MultimediaProfile.DvdMinusRDualLayerSequentialRecording:
				case MultimediaProfile.DvdMinusRDualLayerJumpRecording:
				case MultimediaProfile.DvdMinusRWDualLayer:
				case MultimediaProfile.DvdPlusR:
				case MultimediaProfile.DvdPlusRDualLayer:
				case MultimediaProfile.HDDvdR:
				case MultimediaProfile.BDROM:
				case MultimediaProfile.BDRSequentialRecording:
					this.closeNeeded = closeNeeded = true;
					break;
				default:
					this.closeNeeded = closeNeeded = false;
					break;
			}
#endif
        }

        public MultimediaDevice Device
        {
            get { return device; }
        }

        protected override void Dispose(bool disposing)
        {
            try
            {
#if RESERVE_TRACK
				if (this.trackReserved) { this.device.CloseTrackOrSession(new CloseSessionTrackCommand(false, TrackSessionCloseFunction.CloseLogicalTrack, this.trackNumber)); }
#endif
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            long pos = base.Seek(offset, origin);
            Device.Seek10(new Seek10Command((uint) ((pos + BaseStartPosition)/Device.BlockSize)));
            return pos;
        }

#if RESERVE_TRACK
		public override void Write(byte[] buffer, int offset, int count) { this.started = true; base.Write(buffer, offset, count); }
		public override void WriteByte(byte value) { this.started = true; base.WriteByte(value); }
		public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state) { this.started = true; return base.BeginWrite(buffer, offset, count, callback, state); }
		public override void EndWrite(IAsyncResult asyncResult) { this.started = true; base.EndWrite(asyncResult); }
		public override void Flush() { this.started = true; base.Flush(); }


		/// <summary>Sets the length of this track by reserving it, if it has not yet been written to.</summary>
		public override void SetLength(long value)
		{
			if (!this.started)
			{
				this.started = true;
				Feature feature;
				if (((feature = this.device.GetConfiguration<IncrementalStreamingWritableFeature>()) != null && feature.Current)
					|| ((feature = this.device.GetConfiguration<DvdPlusRFeature>()) != null && feature.Current)
					|| ((feature = this.device.GetConfiguration<CDTrackAtOnceFeature>()) != null && feature.Current)
					|| ((feature = this.device.GetConfiguration<DvdMinusRWWriteFeature>()) != null && feature.Current)
					|| ((feature = this.device.GetConfiguration<DvdPlusRDualLayerFeature>()) != null && feature.Current)
					|| ((feature = this.device.GetConfiguration<HDDvdWriteFeature>()) != null && feature.Current))
				{
					var sectorCount = Math.Max((uint)(1 + (value - 1) / this.device.BlockSize), 298);
					this.device.ReserveTrack(new ReserveTrackCommand(false, new LogicalTrackReservationParameter((1 + (sectorCount - 1) / 16) * 16, false)));
					this.trackReserved = true;
				}
			}
			base.SetLength(value);
		}
#endif
    }
}