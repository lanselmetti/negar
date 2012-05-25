using System;
using System.Diagnostics;
using System.IO;

namespace Scsi.Multimedia
{
    public class ScsiStream : Stream
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private long _Position;

        /// <summary>Leaves the device open!</summary>
        public ScsiStream(IScsiDevice device)
        {
            Device = device;
        }

        public IScsiDevice Device { get; private set; }

        public override bool CanRead
        {
            get { return Device.CanRead; }
        }

        public override bool CanSeek
        {
            get { return Device.CanSeek; }
        }

        public override bool CanWrite
        {
            get { return Device.CanWrite; }
        }

        public override long Length
        {
            get { return Device.Capacity; }
        }

        public override long Position
        {
            get { return _Position; }
            set { _Position = value; }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Flush();
                Device = null;
            }
            base.Dispose(disposing);
        }

        public override void Flush()
        {
            Device.Flush();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            long pos = Position;
            count = Read(ref pos, buffer, offset, count);
            Position = pos;
            return count;
        }

        private int Read(ref long position, byte[] buffer, int offset, int count)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("count", count, "Value must be nonnegative.");
            }
            Device.Read(position, buffer, offset, count, false);
            position += count;
            return count;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            long newPos;
            switch (origin)
            {
                case SeekOrigin.Begin:
                    newPos = 0 + offset;
                    break;
                case SeekOrigin.Current:
                    newPos = _Position + offset;
                    break;
                case SeekOrigin.End:
                    newPos = Device.Capacity + offset;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("origin", origin, "Invalid seek origin.");
            }
            _Position = newPos;
            return _Position;
        }

        public override void SetLength(long value)
        {
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            long pos = Position;
            Write(ref pos, buffer, offset, count);
            Position = pos;
        }

        private void Write(ref long pos, byte[] buffer, int offset, int count)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("count", count, "Value must be nonnegative.");
            }
            try
            {
                Device.Write(pos, buffer, offset, count, false);
            }
            catch (ScsiException ex)
            {
                SenseData sense = ex.SenseData;
                if (sense.EndOfMedium || (sense.SenseKey == SenseKey.IllegalRequest &&
                                          sense.AdditionalSenseCodeAndQualifier ==
                                          AdditionalSenseInformation.LogicalBlockAddressOutOfRange))
                {
                    throw new EndOfStreamException(null, ex);
                }
                throw;
            }
            pos = pos + count;
        }
    }
}