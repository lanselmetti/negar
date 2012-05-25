using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Helper;

namespace Ata
{
    public class AtaStream : Stream
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private long _Position;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private bool leaveOpen;

        public AtaStream(AtaDevice device, bool leaveOpen)
        {
            this.leaveOpen = leaveOpen;
            AtaDevice = device;
        }

        public AtaDevice AtaDevice { get; private set; }

        //public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state) { return new SynchronousAsyncResult(callback, state, this.Read(buffer, offset, count)); }
        //public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state) { this.Write(buffer, offset, count); return new SynchronousAsyncResult(callback, state, count); }

        public override bool CanRead
        {
            get { return true; }
        }

        public override bool CanSeek
        {
            get { return true; }
        }

        public override bool CanWrite
        {
            get { return true; }
        }

        public override long Length
        {
            get
            {
                return AtaDevice.LogicalSectorSize*
                       (AtaDevice.Supports48BitLogicalBlockAddressing
                            ? AtaDevice.NativeMaximumAddress
                            : AtaDevice.NativeMaximumAddressExt);
            }
        }

        /// <summary>Use only ONCE per method, to ensure asynchronous calls can work!</summary>
        public override long Position
        {
            get { return _Position; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", value, "Value must be nonnegative.");
                }
                Seek(value, SeekOrigin.Begin);
            }
        }

        protected override void Dispose(bool disposing)
        {
            try
            {
                try
                {
                    if (!leaveOpen)
                    {
                        AtaDevice.Dispose();
                    }
                }
                finally
                {
                    AtaDevice = null;
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        //public override int EndRead(IAsyncResult asyncResult) { var asAsync = asyncResult as SynchronousAsyncResult; if (asAsync != null) { return asAsync.Count; } else { return base.EndRead(asAsync); } }
        //public override void EndWrite(IAsyncResult asyncResult) { var asAsync = asyncResult as SynchronousAsyncResult; if (asAsync != null) { } else { base.EndWrite(asAsync); } }

        public override void Flush()
        {
            AtaDevice.FlushCache();
        }

        /// <summary>The position must be updated manually!</summary>
        private int Process(long position, byte[] buffer, int bufferOffset, int count, bool write)
        {
            int processed;
            if (count > buffer.Length - bufferOffset)
            {
                throw new ArgumentException(
                    "Offset and length were out of bounds for the array or count is greater than the number of elements from index to the end of the source collection.");
            }
            uint bps = AtaDevice.LogicalSectorSize;
            if (position%bps == 0 && count%bps == 0)
            {
                if (AtaDevice.Supports48BitLogicalBlockAddressing)
                {
                    if (AtaDevice.DmaSupported)
                    {
                        AtaDevice.ReadDmaExt(position/bps, checked((ushort) (count/bps)), buffer, bufferOffset);
                    }
                    else
                    {
                        AtaDevice.ReadSectorsExt(position/bps, checked((ushort) (count/bps)), buffer, bufferOffset);
                    }
                }
                else
                {
                    if (AtaDevice.DmaSupported)
                    {
                        AtaDevice.ReadDma(checked((int) (position/bps)), checked((byte) (count/bps)), buffer,
                                          bufferOffset);
                    }
                    else
                    {
                        AtaDevice.ReadSectors(checked((int) (position/bps)), checked((byte) (count/bps)), buffer,
                                              bufferOffset);
                    }
                }
                processed = count;
                if (write)
                {
                    throw new NotSupportedException("Writing not supported; it's too dangerous for me to implement!");
                }
            }
            else
            {
                long basePosition = position/bps*bps;
                var alignedData = new byte[(position + count - basePosition + bps - 1)/bps*bps];
                if (AtaDevice.Supports48BitLogicalBlockAddressing)
                {
                    if (AtaDevice.DmaSupported)
                    {
                        AtaDevice.ReadDmaExt(basePosition/bps, checked((ushort) (alignedData.Length/bps)), alignedData,
                                             0);
                    }
                    else
                    {
                        AtaDevice.ReadSectorsExt(basePosition/bps, checked((ushort) (alignedData.Length/bps)),
                                                 alignedData, 0);
                    }
                }
                else
                {
                    if (AtaDevice.DmaSupported)
                    {
                        AtaDevice.ReadDma(checked((int) (basePosition/bps)), checked((byte) (alignedData.Length/bps)),
                                          alignedData, 0);
                    }
                    else
                    {
                        AtaDevice.ReadSectors(checked((int) (basePosition/bps)),
                                              checked((byte) (alignedData.Length/bps)), alignedData, 0);
                    }
                }
                processed = alignedData.Length;
                if (write)
                {
                    throw new NotSupportedException("Writing not supported; it's too dangerous for me to implement!");
                }
                if (!write)
                {
                    checked
                    {
                        Buffer.BlockCopy(alignedData, (int) (position - basePosition), buffer, bufferOffset, count);
                    }
                }
            }
            processed = Math.Min(processed, count);
            return processed;
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            long pos = Position;
            int processed = Process(pos, buffer, offset, count, false);
            Position = pos + processed;
            return processed;
        }

        public override int ReadByte()
        {
            uint bps = AtaDevice.LogicalSectorSize;
            long position = Position;
            byte b;
            long basePosition = position/bps*bps;
            var alignedDataLength = checked((int) ((position + 1 - basePosition + bps - 1)/bps*bps));
            unsafe
            {
                byte* pAlignedData = stackalloc byte[alignedDataLength];
                if (AtaDevice.Supports48BitLogicalBlockAddressing)
                {
                    if (AtaDevice.DmaSupported)
                    {
                        AtaDevice.ReadDmaExt(basePosition/bps, checked((ushort) (alignedDataLength/bps)),
                                             new BufferWithSize(pAlignedData, alignedDataLength));
                    }
                    else
                    {
                        AtaDevice.ReadSectorsExt(basePosition/bps, checked((ushort) (alignedDataLength/bps)),
                                                 new BufferWithSize(pAlignedData, alignedDataLength));
                    }
                }
                else
                {
                    if (AtaDevice.DmaSupported)
                    {
                        AtaDevice.ReadDma(checked((int) (basePosition/bps)), checked((byte) (alignedDataLength/bps)),
                                          new BufferWithSize(pAlignedData, alignedDataLength));
                    }
                    else
                    {
                        AtaDevice.ReadSectors(checked((int) (basePosition/bps)), checked((byte) (alignedDataLength/bps)),
                                              new BufferWithSize(pAlignedData, alignedDataLength));
                    }
                }
                b = pAlignedData[position - basePosition];
            }
            Position = position + 1;
            return b;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            long newPos;
            if (!CanSeek)
            {
                throw new InvalidOperationException();
            }
            {
                switch (origin)
                {
                    case SeekOrigin.Begin:
                        newPos = 0 + offset;
                        break;
                    case SeekOrigin.Current:
                        newPos = _Position + offset;
                        break;
                    case SeekOrigin.End:
                        newPos = Length + offset;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("origin", origin, "Invalid seek origin.");
                }
            }
            _Position = newPos;
            return newPos;
        }

        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            long pos = Position;
            Position = pos + Process(pos, buffer, offset, count, true);
        }

        #region Nested type: SynchronousAsyncResult

        private sealed class SynchronousAsyncResult : IAsyncResult
        {
            private static readonly ManualResetEvent RESET_EVENT = new ManualResetEvent(true);

            public SynchronousAsyncResult(AsyncCallback callback, object state, int count)
            {
                Callback = callback;
                AsyncState = state;
                Count = count;
                AsyncWaitHandle = RESET_EVENT;
            }

            public int Count { get; private set; }
            public AsyncCallback Callback { get; set; }

            #region IAsyncResult Members

            public object AsyncState { get; private set; }
            public WaitHandle AsyncWaitHandle { get; private set; }

            public bool CompletedSynchronously
            {
                get { return true; }
            }

            public bool IsCompleted
            {
                get { return true; }
            }

            #endregion
        }

        #endregion
    }
}