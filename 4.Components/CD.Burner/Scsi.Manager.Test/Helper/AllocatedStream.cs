using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Helper.IO
{
	public class AllocatedStream : Stream
	{
		[DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
		private bool _CanRead;
		[DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
		private bool _CanWrite;
		[DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
		private long _Position;
		private SortedList<Range<long>, IStreamSource> allocation;
		private KeyValuePair<int, Stream> currentStream;
		[DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
		private static readonly IComparer<Range<long>> comparer = Range<long>.StartComparer.Default;

		public AllocatedStream(ICollection<KeyValuePair<Range<long>, IStreamSource>> allocation, bool canRead, bool canWrite)
		{
			//the input had better be sorted or we'll be really slow!!
			this.allocation = new SortedList<Range<long>, IStreamSource>(allocation.Count, Range<long>.StartComparer.Default);
			foreach (var item in allocation) { this.allocation.Add(item.Key, item.Value); }
			this._CanRead = canRead;
			this._CanWrite = canWrite;
		}

		public override bool CanRead { get { return this._CanRead; } }
		public override bool CanSeek { get { return true; } }
		public override bool CanWrite { get { return this._CanWrite; } }

		private sealed class AsyncResult : IAsyncResult
		{
			public IAsyncResult Value { get; private set; }
			public AsyncResult(IAsyncResult value) { this.Value = value; }
			public object AsyncState { get { return this.AsyncState; } }
			public System.Threading.WaitHandle AsyncWaitHandle { get { return this.AsyncWaitHandle; } }
			public bool CompletedSynchronously { get { return this.CompletedSynchronously; } }
			public bool IsCompleted { get { return this.IsCompleted; } }
		}

		public long Start { get { return this.allocation.Keys[0].Start; } }

		public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
		{
			this.SeekAndOpenCurrentIfElsewhere();
			if (this.currentStream.Key >= 0)
			{
				var alloc = this.allocation.Keys[this.currentStream.Key];
				if (alloc.End - this.Position >= count)
				{
					var async = new AsyncResult(this.currentStream.Value.BeginRead(buffer, offset, count, callback, state));
					this.Position += count;
					return async;
				}
			}
			return base.BeginRead(buffer, offset, count, callback, state);
		}

		public override int EndRead(IAsyncResult asyncResult) { var asAsync = asyncResult as AsyncResult; return asAsync != null ? this.currentStream.Value.EndRead(asAsync.Value) : base.EndRead(asyncResult); }

		protected override void Dispose(bool disposing)
		{
			try
			{
				// Flush on the underlying stream can throw (ex., low disk space) 
				if (disposing && this.currentStream.Value != null)
				{
					//Do any flushing here, e.g.: this.Flush(); or this.BaseStream.Flush();
				}
			}
			finally
			{
				try { if (disposing && this.currentStream.Value != null) { this.currentStream.Value.Close(); } }
				finally { this.currentStream = new KeyValuePair<int, Stream>(-1, null); base.Dispose(disposing); }
				this.allocation = null;
			}
		}

		public override long Length { get { return this.allocation.Keys[this.allocation.Keys.Count - 1].End; } }

		public override long Position
		{
			get { return this._Position; }
			set
			{
				if (value < 0)
				{ throw new ArgumentOutOfRangeException("value", value, "Value must be nonnegative."); }
				this._Position = value;
			}
		}

		public override void Flush() { if (this.currentStream.Value != null) { this.currentStream.Value.Flush(); } }

		public override int Read(byte[] buffer, int offset, int count)
		{
			var rangeToRead = new Range<long>(this.Position, this.Position + count);
			int left = count;
			while (left > 0)
			{
				this.SeekAndOpenCurrentIfElsewhere();
				if (this.currentStream.Key >= 0)
				{
					var allocRange = this.allocation.Keys[this.currentStream.Key];
					Debug.Assert(allocRange.Overlaps(rangeToRead, null));
					var rangeToReadFromCurrent = new Range<long>(Math.Max(rangeToRead.Start, allocRange.Start), Math.Min(rangeToRead.End, allocRange.End));
					long newPosition = rangeToReadFromCurrent.Start - allocRange.Start;
					if (newPosition != this.currentStream.Value.Position) { this.currentStream.Value.Position = newPosition; }
					int len = (int)(rangeToReadFromCurrent.End - rangeToReadFromCurrent.Start);
					int read = this.currentStream.Value.ReadFully(buffer, offset + (count - left), len);
					Array.Clear(buffer, offset + count - left + read, len - read);
					left -= len;
					this.Position += len;
				}
				else
				{
					if (~this.currentStream.Key < this.allocation.Keys.Count)
					{
						if (this.Position + left >= this.allocation.Keys[~this.currentStream.Key].Start)
						{
							int len = (int)(this.allocation.Keys[~this.currentStream.Key].Start - this.Position);
							Array.Clear(buffer, offset + (count - left), len);
							left -= len;
							this.Position += len;
							this.currentStream = new KeyValuePair<int, Stream>(this.currentStream.Key - 1, null);
						}
						else
						{
							Array.Clear(buffer, offset + (count - left), left);
							this.Position += left;
							left = 0;
						}
					}
					else { break; } //We're at the end of the allocated stream
				}
			}
			this.SeekAndOpenCurrentIfElsewhere();
			return count - left;
		}

		private static int BinarySearch<T>(IList<T> list, T value, IComparer<T> comparer) { return BinarySearch(list, 0, list.Count, value, comparer); }

		private static int BinarySearch<T>(IList<T> list, int index, int length, T value, IComparer<T> comparer)
		{
			if (comparer == null) { comparer = Comparer<T>.Default; }
			int start = index;
			int end = (index + length) - 1;
			while (start <= end)
			{
				int middle = start + ((end - start) >> 1);
				int compare = comparer.Compare(list[middle], value);
				if (compare == 0) { return middle; }
				if (compare < 0) { start = middle + 1; }
				else { end = middle - 1; }
			}
			return ~start;
		}

		private void SeekAndOpenCurrentIfElsewhere()
		{
			long pos = this.Position;
			var keys = this.allocation.Keys;
			if (this.currentStream.Value == null || !keys[this.currentStream.Key].Contains(pos, null))
			{
				if (this.currentStream.Value != null)
				{
					this.currentStream.Value.Close();
					this.currentStream = new KeyValuePair<int, Stream>(-1, null);
				}

				int i = BinarySearch(keys, new Range<long>(pos, pos), comparer);
				if (i < 0 && ~i > 0 && keys[~i - 1].Contains(pos, null))
				{ i = ~i - 1; }

				if (i >= 0)
				{
					var stream = this.allocation.Values[i].Open(FileMode.Open, (this.CanRead ? FileAccess.Read : 0) | (this.CanWrite ? FileAccess.Write : 0), FileShare.Read, FileOptions.None, false);
					this.currentStream = new KeyValuePair<int, Stream>(i, stream);
				}
				else { this.currentStream = new KeyValuePair<int, Stream>(i, null); }
			}
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			long newPos = offset;
			switch (origin)
			{
				case SeekOrigin.Begin:
					newPos += 0;
					break;
				case SeekOrigin.Current:
					newPos += this.Position;
					break;
				case SeekOrigin.End:
					newPos += this.Length;
					break;
				default:
					throw new ArgumentOutOfRangeException("origin", origin, "Invalid seek origin.");
			}
			return this.Position = newPos;
		}

		public override void SetLength(long value) { throw new InvalidOperationException(); }

		public IStreamSource CurrentSource { get { return this.currentStream.Key >= 0 ? this.allocation.Values[this.currentStream.Key] : null; } }

		public override void Write(byte[] buffer, int offset, int count) { throw new NotImplementedException(); }
	}
}