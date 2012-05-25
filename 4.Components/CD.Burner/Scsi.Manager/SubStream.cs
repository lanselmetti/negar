using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace Helper.IO
{
    //[DebuggerStepThrough]
    public class SubStream : Stream
    {
        private readonly bool leaveOpen;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private long _Length;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private long _Position;
        private Stream baseStream;

        public SubStream(Stream baseStream, long startPosition, long length, long maxLength, bool leaveOpen)
        {
            if (baseStream == null)
            {
                throw new ArgumentNullException("baseStream");
            }
            ThrowIfNegative(startPosition, "startPosition");
            ThrowIfNegative(length, "length");
            if (maxLength == -1)
            {
                maxLength = long.MaxValue;
            }
            if (maxLength < 0)
            {
                throw new ArgumentOutOfRangeException("maxLength", maxLength,
                                                      "Maximum length must be nonnegative or -1.");
            }
            if (length > maxLength)
            {
                throw new ArgumentOutOfRangeException("length", length,
                                                      "Length cannot be greater than the maximum length.");
            }
            if (baseStream.Position != startPosition)
            {
                baseStream.Position = startPosition;
            }
            this.leaveOpen = leaveOpen;
            BaseStartPosition = startPosition;
            MaxLength = maxLength;
            _Length = length;
            this.baseStream = baseStream;
        }

        protected long BaseStartPosition { get; private set; }
        protected long MaxLength { get; private set; }

#if !ASYNCHRONOUS_USES_BASE

        public override bool CanRead
        {
            get { return baseStream.CanRead; }
        }

        public override bool CanSeek
        {
            get { return baseStream.CanSeek; }
        }

        public override bool CanTimeout
        {
            get { return baseStream.CanTimeout; }
        }

        public override bool CanWrite
        {
            get { return baseStream.CanWrite; }
        }

        public override long Length
        {
            get { return _Length; }
        }

        public override long Position
        {
            get { return _Position; }
            set
            {
                ThrowIfNegative(value, "value");
                if (value > MaxLength)
                {
                    throw new ArgumentOutOfRangeException("value", value,
                                                          "Value must be less than the maximum length of the stream.");
                }
                _Position = value;
            }
        }

        public override int ReadTimeout
        {
            get { return baseStream.ReadTimeout; }
            set { baseStream.ReadTimeout = value; }
        }

        public override int WriteTimeout
        {
            get { return baseStream.WriteTimeout; }
            set { baseStream.WriteTimeout = value; }
        }

        public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback,
                                               object state)
        {
            ThrowIfNegative(offset, "offset");
            ThrowIfNegative(count, "count");
            if (!leaveOpen)
            {
                if (Position + count > MaxLength)
                {
                    throw new EndOfStreamException();
                }
                if (Position + count > Length)
                {
                    count = (int) (Length - Position);
                }
                long newPosition = BaseStartPosition + Position;
                if (baseStream.Position != newPosition)
                {
                    baseStream.Position = newPosition;
                }
                IAsyncResult async = baseStream.BeginRead(buffer, offset, count, callback, state);
                Position += count;
                    //Possible bug, since we don't know how much can actually be read, but we advance the stream nevertheless
                return new SubStreamAsyncResult(async, count);
            }
            else
            {
                return base.BeginRead(buffer, offset, count, callback, state);
            }
        }

        public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback,
                                                object state)
        {
            ThrowIfNegative(offset, "offset");
            ThrowIfNegative(count, "count");
            if (!leaveOpen)
            {
                if (Position + count > MaxLength)
                {
                    throw new EndOfStreamException();
                }
                if (Position + count > Length)
                {
                    SetLength(Position + count);
                }
                long newPosition = BaseStartPosition + Position;
                if (baseStream.Position != newPosition)
                {
                    baseStream.Position = newPosition;
                }
                IAsyncResult async = baseStream.BeginWrite(buffer, offset, count, callback, state);
                Position += count;
                    //Possible bug, since we don't know how much can actually be read, but we advance the stream nevertheless
                return new SubStreamAsyncResult(async, count);
            }
            else
            {
                return base.BeginWrite(buffer, offset, count, callback, state);
            }
        }
#endif

        public override int EndRead(IAsyncResult asyncResult)
        {
            var async = asyncResult as SubStreamAsyncResult;
            if (async == null)
            {
                return base.EndRead(async);
            }
            else
            {
                baseStream.EndRead(async.BaseAsyncResult);
                return async.Count;
            }
        }

        public override void EndWrite(IAsyncResult asyncResult)
        {
            var async = asyncResult as SubStreamAsyncResult;
            if (async == null)
            {
                base.EndRead(async);
            }
            else
            {
                baseStream.EndWrite(async.BaseAsyncResult);
            }
        }

        protected override void Dispose(bool disposing)
        {
            try
            {
                // Flush on the underlying stream can throw (ex., low disk space) 
                if (disposing && baseStream != null)
                {
                    //Do any flushing here, e.g.: this.Flush(); or this.BaseStream.Flush();
                }
            }
            finally
            {
                try
                {
                    if (disposing && !leaveOpen && baseStream != null)
                    {
                        baseStream.Close();
                    }
                }
                finally
                {
                    baseStream = null;
                    base.Dispose(disposing);
                }
            }
        }

        public override void Flush()
        {
            baseStream.Flush();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            ThrowIfNegative(offset, "offset");
            ThrowIfNegative(count, "count");
            if (Position + count > MaxLength)
            {
                throw new EndOfStreamException();
            }
            if (Position + count > Length)
            {
                count = (int) (Length - Position);
            }

            long newPosition = BaseStartPosition + Position;
            if (baseStream.Position != newPosition)
            {
                baseStream.Position = newPosition;
            }
            int read = baseStream.Read(buffer, offset, count);
            Position += read;
            return read;
        }

        public override int ReadByte()
        {
            if (Position + 1 > MaxLength)
            {
                throw new EndOfStreamException();
            }
            if (Position + 1 > Length)
            {
                return -1;
            }
            long newPosition = BaseStartPosition + Position;
            if (baseStream.Position != newPosition)
            {
                baseStream.Position = newPosition;
            }
            int read = baseStream.ReadByte();
            if (read >= 0)
            {
                Position++;
            }
            return read;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            long newPos;
            switch (origin)
            {
                case SeekOrigin.Begin:
                    newPos = offset;
                    break;
                case SeekOrigin.Current:
                    newPos = Position + offset;
                    break;
                case SeekOrigin.End:
                    newPos = Length + offset;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("origin", origin, "Invalid seek origin.");
            }
            Position = newPos;
            return Position;
        }

        public override void SetLength(long value)
        {
            ThrowIfNegative(value, "value");
            if (value > MaxLength)
            {
                throw new ArgumentOutOfRangeException("value", value,
                                                      "Value must be less than the maximum length of the stream.");
            }
            _Length = value;
            long baseLength = baseStream.Length;
            if (BaseStartPosition + Length > baseLength)
            {
                baseStream.SetLength(baseLength - (BaseStartPosition + Length));
            }
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            ThrowIfNegative(offset, "offset");
            ThrowIfNegative(count, "count");
            if (Position + count > MaxLength)
            {
                throw new EndOfStreamException();
            }
            if (Position + count > Length)
            {
                SetLength(Position + count);
            }
            long newPosition = BaseStartPosition + Position;
            if (baseStream.Position != newPosition)
            {
                baseStream.Position = newPosition;
            }
            baseStream.Write(buffer, offset, count);
            Position += count;
        }

        public override void WriteByte(byte value)
        {
            if (Position + 1 > MaxLength)
            {
                throw new EndOfStreamException();
            }
            if (Position + 1 > Length)
            {
                SetLength(Position + 1);
            }
            long newPosition = BaseStartPosition + Position;
            if (baseStream.Position != newPosition)
            {
                baseStream.Position = newPosition;
            }
            baseStream.WriteByte(value);
            Position++;
        }


        private static void ThrowIfNegative(long value, string argName)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(argName, value, argName + " must be nonnegative.");
            }
        }

#if !ASYNCHRONOUS_USES_BASE

        #region Nested type: SubStreamAsyncResult

        [DebuggerStepThrough]
        private sealed class SubStreamAsyncResult : IAsyncResult
        {
            public SubStreamAsyncResult(IAsyncResult async, int count)
            {
                BaseAsyncResult = async;
                Count = count;
            }

            public IAsyncResult BaseAsyncResult { get; private set; }
            public int Count { get; private set; }

            #region IAsyncResult Members

            public object AsyncState
            {
                get { return BaseAsyncResult.AsyncState; }
            }

            public WaitHandle AsyncWaitHandle
            {
                get { return BaseAsyncResult.AsyncWaitHandle; }
            }

            public bool CompletedSynchronously
            {
                get { return BaseAsyncResult.CompletedSynchronously; }
            }

            public bool IsCompleted
            {
                get { return BaseAsyncResult.IsCompleted; }
            }

            #endregion
        }

        #endregion

#endif
    }
}