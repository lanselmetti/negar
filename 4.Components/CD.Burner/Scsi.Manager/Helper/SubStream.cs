using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace Helper.IO
{
	//[DebuggerStepThrough]
	public class SubStream : Stream
	{
		private Stream baseStream;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private long _Length;
		private bool leaveOpen;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private long _Position;

		public SubStream(Stream baseStream, long startPosition, long length, long maxLength, bool leaveOpen)
		{
			if (baseStream == null) { throw new ArgumentNullException("baseStream"); }
			ThrowIfNegative(startPosition, "startPosition");
			ThrowIfNegative(length, "length");
			if (maxLength == -1) { maxLength = long.MaxValue; }
			if (maxLength < 0) { throw new ArgumentOutOfRangeException("maxLength", maxLength, "Maximum length must be nonnegative or -1."); }
			if (length > maxLength) { throw new ArgumentOutOfRangeException("length", length, "Length cannot be greater than the maximum length."); }
			if (baseStream.Position != startPosition) { baseStream.Position = startPosition; }
			this.leaveOpen = leaveOpen;
			this.BaseStartPosition = startPosition;
			this.MaxLength = maxLength;
			this._Length = length;
			this.baseStream = baseStream;
		}

		protected long BaseStartPosition { get; private set; }
		protected long MaxLength { get; private set; }
		
#if !ASYNCHRONOUS_USES_BASE
		public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
		{
			ThrowIfNegative(offset, "offset");
			ThrowIfNegative(count, "count");
			if (!this.leaveOpen)
			{
				if (this.Position + count > this.MaxLength) { throw new EndOfStreamException(); }
				if (this.Position + count > this.Length) { count = (int)(this.Length - this.Position); }
				long newPosition = this.BaseStartPosition + this.Position;
				if (this.baseStream.Position != newPosition) { this.baseStream.Position = newPosition; }
				IAsyncResult async = this.baseStream.BeginRead(buffer, offset, count, callback, state);
				this.Position += count; //Possible bug, since we don't know how much can actually be read, but we advance the stream nevertheless
				return new SubStreamAsyncResult(async, count);
			}
			else { return base.BeginRead(buffer, offset, count, callback, state); }
		}

		public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
		{
			ThrowIfNegative(offset, "offset");
			ThrowIfNegative(count, "count");
			if (!this.leaveOpen)
			{
				if (this.Position + count > this.MaxLength) { throw new EndOfStreamException(); }
				if (this.Position + count > this.Length) { this.SetLength(this.Position + count); }
				long newPosition = this.BaseStartPosition + this.Position;
				if (this.baseStream.Position != newPosition) { this.baseStream.Position = newPosition; }
				IAsyncResult async = this.baseStream.BeginWrite(buffer, offset, count, callback, state);
				this.Position += count; //Possible bug, since we don't know how much can actually be read, but we advance the stream nevertheless
				return new SubStreamAsyncResult(async, count);
			}
			else { return base.BeginWrite(buffer, offset, count, callback, state); }
		}
#endif

		public override int EndRead(IAsyncResult asyncResult) { var async = asyncResult as SubStreamAsyncResult; if (async == null) { return base.EndRead(async); } else { this.baseStream.EndRead(async.BaseAsyncResult); return async.Count; } }

		public override void EndWrite(IAsyncResult asyncResult) { var async = asyncResult as SubStreamAsyncResult; if (async == null) { base.EndRead(async); } else { this.baseStream.EndWrite(async.BaseAsyncResult); } }

		public override bool CanRead { get { return this.baseStream.CanRead; } }

		public override bool CanSeek { get { return this.baseStream.CanSeek; } }

		public override bool CanTimeout { get { return this.baseStream.CanTimeout; } }

		public override bool CanWrite { get { return this.baseStream.CanWrite; } }

		protected override void Dispose(bool disposing)
		{
			try
			{
				// Flush on the underlying stream can throw (ex., low disk space) 
				if (disposing && this.baseStream != null)
				{
					//Do any flushing here, e.g.: this.Flush(); or this.BaseStream.Flush();
				}
			}
			finally
			{
				try { if (disposing && !this.leaveOpen && this.baseStream != null) { this.baseStream.Close(); } }
				finally { this.baseStream = null; base.Dispose(disposing); }
			}
		}

		public override void Flush() { this.baseStream.Flush(); }

		public override long Length { get { return this._Length; } }

		public override long Position { get { return this._Position; } set { ThrowIfNegative(value, "value"); if (value > this.MaxLength) { throw new ArgumentOutOfRangeException("value", value, "Value must be less than the maximum length of the stream."); } this._Position = value; } }

		public override int Read(byte[] buffer, int offset, int count)
		{
			ThrowIfNegative(offset, "offset");
			ThrowIfNegative(count, "count");
			if (this.Position + count > this.MaxLength) { throw new EndOfStreamException(); }
			if (this.Position + count > this.Length) { count = (int)(this.Length - this.Position); }

			long newPosition = this.BaseStartPosition + this.Position;
			if (this.baseStream.Position != newPosition) { this.baseStream.Position = newPosition; }
			int read = this.baseStream.Read(buffer, offset, count);
			this.Position += read;
			return read;
		}

		public override int ReadByte()
		{
			if (this.Position + 1 > this.MaxLength) { throw new EndOfStreamException(); }
			if (this.Position + 1 > this.Length) { return -1; }
			long newPosition = this.BaseStartPosition + this.Position;
			if (this.baseStream.Position != newPosition) { this.baseStream.Position = newPosition; }
			int read = this.baseStream.ReadByte();
			if (read >= 0) { this.Position++; }
			return read;
		}

		public override int ReadTimeout { get { return this.baseStream.ReadTimeout; } set { this.baseStream.ReadTimeout = value; } }

		public override long Seek(long offset, SeekOrigin origin)
		{
			long newPos;
			switch (origin)
			{
				case SeekOrigin.Begin:
					newPos = offset;
					break;
				case SeekOrigin.Current:
					newPos = this.Position + offset;
					break;
				case SeekOrigin.End:
					newPos = this.Length + offset;
					break;
				default:
					throw new ArgumentOutOfRangeException("origin", origin, "Invalid seek origin.");
			}
			this.Position = newPos;
			return this.Position;
		}

		public override void SetLength(long value)
		{
			ThrowIfNegative(value, "value");
			if (value > this.MaxLength) { throw new ArgumentOutOfRangeException("value", value, "Value must be less than the maximum length of the stream."); }
			this._Length = value;
			long baseLength = this.baseStream.Length;
			if (this.BaseStartPosition + this.Length > baseLength) { this.baseStream.SetLength(baseLength - (this.BaseStartPosition + this.Length)); }
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			ThrowIfNegative(offset, "offset");
			ThrowIfNegative(count, "count");
			if (this.Position + count > this.MaxLength) { throw new EndOfStreamException(); }
			if (this.Position + count > this.Length) { this.SetLength(this.Position + count); }
			long newPosition = this.BaseStartPosition + this.Position;
			if (this.baseStream.Position != newPosition) { this.baseStream.Position = newPosition; }
			this.baseStream.Write(buffer, offset, count);
			this.Position += count;
		}

		public override void WriteByte(byte value)
		{
			if (this.Position + 1 > this.MaxLength) { throw new EndOfStreamException(); }
			if (this.Position + 1 > this.Length) { this.SetLength(this.Position + 1); }
			long newPosition = this.BaseStartPosition + this.Position;
			if (this.baseStream.Position != newPosition) { this.baseStream.Position = newPosition; }
			this.baseStream.WriteByte(value);
			this.Position++;
		}

		public override int WriteTimeout { get { return this.baseStream.WriteTimeout; } set { this.baseStream.WriteTimeout = value; } }


		private static void ThrowIfNegative(long value, string argName) { if (value < 0) { throw new ArgumentOutOfRangeException(argName, value, argName + " must be nonnegative."); } }

#if !ASYNCHRONOUS_USES_BASE
		[DebuggerStepThrough]
		private sealed class SubStreamAsyncResult : IAsyncResult
		{
			public SubStreamAsyncResult(IAsyncResult async, int count) { this.BaseAsyncResult = async; this.Count = count; }
			public IAsyncResult BaseAsyncResult { get; private set; }
			public int Count { get; private set; }
			public object AsyncState { get { return this.BaseAsyncResult.AsyncState; } }
			public System.Threading.WaitHandle AsyncWaitHandle { get { return this.BaseAsyncResult.AsyncWaitHandle; } }
			public bool CompletedSynchronously { get { return this.BaseAsyncResult.CompletedSynchronously; } }
			public bool IsCompleted { get { return this.BaseAsyncResult.IsCompleted; } }
		}
#endif
	}
}