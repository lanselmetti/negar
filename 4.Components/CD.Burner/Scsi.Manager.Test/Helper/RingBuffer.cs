using System;
using System.Diagnostics;
using System.Threading;
using System.Runtime;

namespace Helper.IO
{
	public class RingBuffer : IDisposable
	{
		private long startLength;
		private BufferWithSize buffer;
		private int pollInterval;
		private int pollSpin;
		//private ManualResetEvent bufferNotEmpty = new ManualResetEvent(false);
		//private ManualResetEvent bufferNotFull = new ManualResetEvent(true);
		private readonly object syncRoot = new object();
		private volatile bool stop = false;

		public RingBuffer(int bufferSize, int pollInterval, int pollSpin)
		{
			this.pollInterval = pollInterval;
			this.pollSpin = pollSpin;
			try { new MemoryFailPoint(1 + ((bufferSize - 1) / (1024 * 1024))).Dispose(); }
			catch (InsufficientMemoryException ex) { throw new InsufficientMemoryException(string.Format("The application requested {0:N0} bytes of memory, which was not available." + Environment.NewLine + "Try decreasing the buffer size.", bufferSize), ex); }
			this.buffer = BufferWithSize.AllocHGlobal(bufferSize);
		}

		~RingBuffer() { this.Dispose(false); }
		public void Dispose() { this.Dispose(true); GC.SuppressFinalize(this); }
		
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				/*
				this.bufferNotEmpty.Close();
				this.bufferNotEmpty = null;
				this.bufferNotFull.Close();
				this.bufferNotFull = null;
				//*/
			}
			BufferWithSize.FreeHGlobal(this.buffer);
			this.buffer = BufferWithSize.Zero;
		}

		public int Length { get { int len; Unpack64(Interlocked.Read(ref this.startLength), out len); return len; } }
		public int Capacity { get { return this.buffer.Length32; } }
		
		public void EndWrite()
		{
			this.stop = true;
			//this.bufferNotEmpty.Set();
		}

		public int Read(byte[] data, int offset, int count)
		{
			if (count > this.buffer.Length32) { throw new ArgumentOutOfRangeException("count", count, "Count must be less than or equal to buffer size."); }
			var left = count;
			while (left > 0)
			{
				this.WaitBufferNotEmpty();
				//lock (this.syncRoot)
				{
					int oldLength;
					int oldStart = Unpack64(Interlocked.Read(ref this.startLength), out oldLength);
					if (oldLength == 0) { break; }
					var toCopy = Math.Min(oldLength, left);
					CopyFromRing(this.buffer, oldStart, data, offset, toCopy);
					left -= toCopy;
					offset += toCopy;
					var deltaStart = (int)((oldStart + toCopy) % this.buffer.Length64) - oldStart;
					int newLength;
					var packed = Pack64(deltaStart, -toCopy - (deltaStart < 0 ? 1 : 0 /*This is for carryover when using packing with Interlocked.Add*/));
					var newStart = Unpack64(Interlocked.Add(ref this.startLength, packed), out newLength);
					//this._Length -= toCopy;
					//this.start = (int)((this.start + toCopy) % this.buffer.Length64);
					//if (newLength == 0) { this.bufferNotEmpty.Reset(); }
					//if (newLength != this.buffer.Length64) { this.bufferNotFull.Set(); }
				}
			}
			return count - left;
		}

		[System.Security.SuppressUnmanagedCodeSecurity, System.Runtime.InteropServices.DllImport("NTDLL.dll", SetLastError = false)]
		private static extern int NtYieldExecution();

		private void WaitBufferNotEmpty()
		{
			//this.bufferNotEmpty.WaitOne();
			int count = 0;
			while (this.Length == 0 && !this.stop)
			{
				if ((count & 1) != 0) { Thread.Sleep(this.pollInterval); }
				else { NtYieldExecution(); Thread.SpinWait(this.pollSpin); }
				count++;
			}
		}

		public void Write(byte[] data, int offset, int count)
		{
			if (count > this.buffer.Length64) { throw new ArgumentOutOfRangeException("count", count, "Count must be less than or equal to buffer size."); }
			while (count > 0)
			{
				this.WaitBufferNotFull();
				//lock (this.syncRoot)
				{
					int oldLength;
					int oldStart = Unpack64(Interlocked.Read(ref this.startLength), out oldLength);
					var toCopy = checked((int)Math.Min(this.buffer.Length64 - oldLength, count));
					CopyToRing(data, offset, this.buffer, (oldStart + oldLength) % this.buffer.Length64, toCopy);
					count -= toCopy;
					offset += toCopy;
					
					int newLength;
					var newStart = Unpack64(Interlocked.Add(ref this.startLength, Pack64(0, toCopy)), out newLength);
					//this._Length += toCopy;

					//if (newLength != 0) { this.bufferNotEmpty.Set(); }
					//if (newLength == this.buffer.Length64) { this.bufferNotFull.Reset(); }
				}
			}
		}

		private void WaitBufferNotFull()
		{
			//this.bufferNotFull.WaitOne();
			int count = 0;
			while (this.Length == this.buffer.Length32 && !this.stop)
			{
				if ((count & 1) != 0) { Thread.Sleep(this.pollInterval); }
				else { NtYieldExecution(); Thread.SpinWait(this.pollSpin); }
				count++;
			}
		}

		public static void CopyToRing(byte[] sourceArray, long sourceIndex, BufferWithSize destinationRingArray, long destinationIndex, long length)
		{
			var firstPart = Math.Min(length, destinationRingArray.Length32 - destinationIndex);
			destinationRingArray.CopyFrom(destinationIndex, sourceArray, sourceIndex, firstPart);
			destinationRingArray.CopyFrom((destinationIndex + firstPart) % destinationRingArray.Length32, sourceArray, sourceIndex + firstPart, length - firstPart);
		}

		public static void CopyFromRing(BufferWithSize sourceRingArray, long sourceIndex, byte[] destinationArray, long destinationIndex, long length)
		{
			var firstPart = Math.Min(length, sourceRingArray.Length32 - sourceIndex);
			sourceRingArray.CopyTo(sourceIndex, destinationArray, destinationIndex, firstPart);
			sourceRingArray.CopyTo((sourceIndex + firstPart) % sourceRingArray.Length32, destinationArray, destinationIndex + firstPart, length - firstPart);
		}

		private static long Pack64(int low, int high) { return ((long)low & 0xFFFFFFFFL) | ((long)high << 32); }
		private static int Unpack64(long value, out int high) { high = (int)(value >> 32); return (int)(value & 0xFFFFFFFFL); }
	}
}