using System;
using System.Diagnostics;
using System.IO;
namespace FileSystems.Udf
{
	public class UdfPartition : Stream
	{
		private bool leaveOpen;
		private Stream partitionStream;
		private PartitionDescriptor partitionDescriptor;
		/// <param name="partitionStream">The stream representing the partition data. This stream is closed when the partition is disposed.</param>
		internal UdfPartition(UdfVolume fs, PartitionDescriptor descriptor, Stream partitionStream)
		{
			this.Volume = fs;
			this.leaveOpen = true;
			this.partitionDescriptor = descriptor;
			this.partitionStream = partitionStream;
		}

		//IMPORTANT NOTE: You CANNOT change the Partition Number unless you notify UdfVolume first!

		protected override void Dispose(bool disposing)
		{
			try
			{
				// Flush on the underlying stream can throw (ex., low disk space) 
				if (disposing && this.partitionStream != null)
				{
					//Do any flushing here, e.g.: this.Flush(); or this.PartitionStream.Flush();
					//this.fs.ClosePartition(this);
				}
			}
			finally
			{
				try { if (disposing && !this.leaveOpen && this.partitionStream != null) { this.partitionStream.Close(); } }
				finally { this.partitionStream = null; base.Dispose(disposing); }
			}
		}

		public override bool CanRead { get { return this.partitionStream.CanRead; } }
		public override bool CanSeek { get { return this.partitionStream.CanSeek; } }
		public override bool CanTimeout { get { return this.partitionStream.CanTimeout; } }
		public override bool CanWrite { get { return this.partitionStream.CanWrite && (this.partitionDescriptor.AccessType == PartitionAccessType.WriteOnce || this.partitionDescriptor.AccessType == PartitionAccessType.Rewritable || this.partitionDescriptor.AccessType == PartitionAccessType.Overwritable); } }
		public override void Flush() { this.partitionStream.Flush(); }
		public override long Length { get { return this.partitionStream.Length; } }

		public ushort PartitionNumber { get { return this.partitionDescriptor.PartitionNumber; } }

		public override long Position { get { return this.partitionStream.Position; } set { this.partitionStream.Position = value; } }

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

		public override void SetLength(long value) { this.partitionStream.SetLength(value); }

		public override int Read(byte[] buffer, int offset, int count) { return this.partitionStream.Read(buffer, offset, count); }

		public override void Write(byte[] buffer, int offset, int count)
		{
			if (this.partitionDescriptor.AccessType != PartitionAccessType.WriteOnce && this.partitionDescriptor.AccessType != PartitionAccessType.Rewritable && this.partitionDescriptor.AccessType != PartitionAccessType.Overwritable)
			{ throw new IOException("Partition is read-only.", new UnauthorizedAccessException()); }
			this.partitionStream.Write(buffer, offset, count);
		}

		public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state) { return this.partitionStream.BeginRead(buffer, offset, count, callback, state); }

		public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
		{
			if (this.partitionDescriptor.AccessType != PartitionAccessType.WriteOnce && this.partitionDescriptor.AccessType != PartitionAccessType.Rewritable && this.partitionDescriptor.AccessType != PartitionAccessType.Overwritable)
			{ throw new IOException("Partition is read-only.", new UnauthorizedAccessException()); }
			return this.partitionStream.BeginWrite(buffer, offset, count, callback, state);
		}

		public override int EndRead(IAsyncResult asyncResult) { return this.partitionStream.EndRead(asyncResult); }

		public override void EndWrite(IAsyncResult asyncResult) { this.partitionStream.EndWrite(asyncResult); }

		public UdfVolume Volume { get; private set; }
	}
}