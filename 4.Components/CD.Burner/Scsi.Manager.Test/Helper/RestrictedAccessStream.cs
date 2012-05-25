#define ASYNCHRONOUS_USES_BASE
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Helper.IO
{
	public class RestrictedAccessStream : Stream
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool leaveOpen;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _CanRead;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _CanWrite;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _CanSeek;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Stream _BaseStream;

		protected Stream BaseStream { [DebuggerStepThrough] get { if (this._BaseStream == null) { throw new ObjectDisposedException("_BaseStream"); } return this._BaseStream; } private set { this._BaseStream = value; } }

		/// <summary><para>Wraps the given stream with a restricted access.</para><para>NOTE: Begin/End functions use the base stream, so the base stream should not be used directly while this stream is being used.</para></summary>
		public RestrictedAccessStream(Stream baseStream, FileAccess restrictedAccess, bool canSeek, bool leaveOpen)
		{
			this.leaveOpen = leaveOpen;
			this.BaseStream = baseStream;
			this._CanRead = (restrictedAccess & FileAccess.Read) != 0;
			this._CanWrite = (restrictedAccess & FileAccess.Write) != 0;
			this._CanSeek = canSeek;
		}

#if ASYNCHRONOUS_USES_BASE //This is allowed
		public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state) { if (!this._CanRead) { ThrowStreamNotReadableException(); } return this.BaseStream.BeginRead(buffer, offset, count, callback, state); }
		public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state) { if (!this._CanWrite) { ThrowStreamNotWriteableException(); } return this.BaseStream.BeginWrite(buffer, offset, count, callback, state); }
		public override int EndRead(IAsyncResult asyncResult) { if (!this._CanRead) { ThrowStreamNotReadableException(); } return this.BaseStream.EndRead(asyncResult); }
		public override void EndWrite(IAsyncResult asyncResult) { if (!this._CanWrite) { ThrowStreamNotWriteableException(); } this.BaseStream.EndWrite(asyncResult); }
#endif

		public override bool CanRead { get { return this._CanRead && this.BaseStream.CanRead; } }
		public override bool CanSeek { get { return this._CanSeek && this.BaseStream.CanSeek; } }
		public override bool CanTimeout { get { return this.BaseStream.CanTimeout; } }
		public override bool CanWrite { get { return this._CanWrite && this.BaseStream.CanWrite; } }
		protected override void Dispose(bool disposing) { try { if (disposing && !this.leaveOpen && this.BaseStream != null) { this.BaseStream.Close(); } } finally { this.BaseStream = null; base.Dispose(disposing); } }
		public override void Flush() { this.BaseStream.Flush(); }
		private static void ThrowStreamNotReadableException() { throw new NotSupportedException(@"Stream does not support reading."); }
		private static void ThrowStreamNotSeekableException() { throw new NotSupportedException(@"Stream does not support seeking."); }
		private static void ThrowStreamNotWriteableException() { throw new NotSupportedException(@"Stream does not support writing."); }
		public override long Length { get { if (!this._CanSeek) { ThrowStreamNotSeekableException(); } return this.BaseStream.Length; } }
		public override long Position { get { if (!this._CanSeek) { ThrowStreamNotSeekableException(); } return this.BaseStream.Position; } set { if (!this._CanSeek) { ThrowStreamNotSeekableException(); } this.BaseStream.Position = value; } }
		public override int Read(byte[] buffer, int offset, int count) { if (!this._CanRead) { ThrowStreamNotReadableException(); } return this.BaseStream.Read(buffer, offset, count); }
		public override int ReadByte() { if (!this._CanRead) { ThrowStreamNotReadableException(); } return this.BaseStream.ReadByte(); }
		public override int ReadTimeout { get { return this.BaseStream.ReadTimeout; } set { this.BaseStream.ReadTimeout = value; } }
		public override long Seek(long offset, SeekOrigin origin) { if (!this._CanSeek) { ThrowStreamNotSeekableException(); } return this.BaseStream.Seek(offset, origin); }
		public override void SetLength(long value) { if (!this._CanSeek) { ThrowStreamNotSeekableException(); } this.BaseStream.SetLength(value); }
		public override string ToString() { return this.BaseStream.ToString(); }
		public override void Write(byte[] buffer, int offset, int count) { if (!this._CanWrite) { ThrowStreamNotWriteableException(); } this.BaseStream.Write(buffer, offset, count); }
		public override void WriteByte(byte value) { if (!this._CanWrite) { ThrowStreamNotWriteableException(); } this.BaseStream.WriteByte(value); }
		public override int WriteTimeout { get { return this.BaseStream.WriteTimeout; } set { this.BaseStream.ReadTimeout = value; } }
	}
}