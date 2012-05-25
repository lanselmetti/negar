using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using Helper.IO;

namespace FileSystems.Iso9660
{
	public class IsoFileSystem : IDisposable
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DirectoryRecord _RootDirectoryRecord;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private PrimaryVolumeDescriptor _PrimaryVolumeDescriptor;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SupplementaryVolumeDescriptor _SupplementaryVolumeDescriptor;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private VolumePartitionDescriptor _VolumePartitionDescriptor;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool leaveOpen;

		public IsoFileSystem(Stream volumeStream, bool leaveOpen)
		{
			this.leaveOpen = leaveOpen;
			this.DiscStream = volumeStream;
		}

		~IsoFileSystem() { this.Dispose(false); }

		protected Stream DiscStream { get; private set; }

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				try { if (!this.leaveOpen) { this.DiscStream.Close(); } }
				finally { this.DiscStream = null; }
			}
		}

		public void Dispose() { this.Dispose(true); GC.SuppressFinalize(this); }

		public uint LogicalSectorSize { get { return 2048; } }

		private VolumeStructureDescriptor TryConvertDescriptorToManaged(byte[] buffer, int bufferOffset) { return IsoVolumeDescriptor.FromBuffer(buffer, 0); }

		public PrimaryVolumeDescriptor PrimaryVolumeDescriptor
		{
			get
			{
				if (this._PrimaryVolumeDescriptor == null)
				{ uint startLBA = 16; this._PrimaryVolumeDescriptor = (PrimaryVolumeDescriptor)this.TryFindDescriptor((byte)VolumeDescriptorType.PrimaryVolumeDescriptor, null, null, ref startLBA); }
				return this._PrimaryVolumeDescriptor;
			}
		}

		public SupplementaryVolumeDescriptor SupplementaryVolumeDescriptor
		{
			get
			{
				if (this._SupplementaryVolumeDescriptor == null)
				{ uint startLBA = 16; this._SupplementaryVolumeDescriptor = (SupplementaryVolumeDescriptor)this.TryFindDescriptor((byte)VolumeDescriptorType.SupplementaryVolumeDescriptor, null, null, ref startLBA); }
				return this._SupplementaryVolumeDescriptor;
			}
		}

		public VolumePartitionDescriptor VolumePartitionDescriptor
		{
			get
			{
				if (this._VolumePartitionDescriptor == null)
				{ uint startLBA = 16; this._VolumePartitionDescriptor = (VolumePartitionDescriptor)this.TryFindDescriptor((byte)VolumeDescriptorType.VolumePartitionDescriptor, null, null, ref startLBA); }
				return this._VolumePartitionDescriptor;
			}
		}

		protected virtual VolumeStructureDescriptor TryFindDescriptor(byte? type, string standardID, byte? version, ref uint startLSN)
		{
			if (startLSN < 16) { throw new ArgumentOutOfRangeException("startLSN", startLSN, "startLSN must be greater than or equal to 16."); }
			long newPosition = startLSN * this.LogicalSectorSize;
			if (this.DiscStream.Position != newPosition) { this.DiscStream.Position = newPosition; }
			var bytes = new byte[this.LogicalSectorSize];
			for (; ; )
			{
				this.DiscStream.ReadExactly(bytes, 0, bytes.Length);
				bool stop = false;
				byte t = VolumeStructureDescriptor.ReadType(bytes, 0);
				string sid = VolumeStructureDescriptor.ReadStandardIdentifier(bytes, 0);
				byte v = VolumeStructureDescriptor.ReadVersion(bytes, 0);
				stop = t == 255 | t == 0 && string.IsNullOrEmpty(sid.Replace("\0", string.Empty)) && v == 0;
				if (stop) { break; }
				else
				{
					if ((type == null || type == t) &&
						(standardID == null || standardID == sid) &&
						(version == null || version == v))
					{
						startLSN = ((uint)this.DiscStream.Position - (uint)bytes.Length) / this.LogicalSectorSize;
						return this.TryConvertDescriptorToManaged(bytes, 0);
					}
				}
			}
			return null;
		}

		public DirectoryRecord RootDirectoryRecord
		{
			get
			{
				if (this._RootDirectoryRecord == null)
				{
					var data = this.PrimaryVolumeDescriptor.RootDirectoryRecordData;
					var record = new DirectoryRecord();
					Helper.Marshaler.PtrToStructure(data, 0, ref record);
					this._RootDirectoryRecord = record;
				}
				return this._RootDirectoryRecord;
			}
		}

		public List<DirectoryRecord> GetDirectoryRecords(DirectoryRecord directory)
		{
			if (!directory.FileId.IsDirectory) { throw new InvalidOperationException("Input file was not a directory."); }
			var items = new List<DirectoryRecord>();
			var sector = new byte[this.LogicalSectorSize];
			long newPosition = directory.ExtentLBA * this.LogicalSectorSize;
			if (this.DiscStream.Position != newPosition) { this.DiscStream.Position = newPosition; }
			int read = 0;
			while (read < directory.DataLength)
			{
				this.DiscStream.ReadExactly(sector, 0, sector.Length);
				int i;
				for (i = 0; DirectoryRecord.ReadRecordLength(sector, i) > 0; i += DirectoryRecord.ReadRecordLength(sector, i))
				{
					var item = Helper.Marshaler.PtrToStructure<DirectoryRecord>(sector, i);
					items.Add(item);
				}
				read += sector.Length;
			}
			return items;
		}

		public IEnumerable<PathTableRecord> ReadPathTableRecords(bool bigEndian, bool optional)
		{
			long newPosition = (long)this.PrimaryVolumeDescriptor.LogicalBlockSize * (bigEndian ? !optional ? this.PrimaryVolumeDescriptor.BigEndianPathTableLocation : this.PrimaryVolumeDescriptor.OptionalBigEndianPathTableLocation : (!optional ? this.PrimaryVolumeDescriptor.LittleEndianPathTableLocation : this.PrimaryVolumeDescriptor.OptionalLittleEndianPathTableLocation));
			int totalLength = (int)PathTableRecord.DIRECTORY_ID_OFFSET;
			var entryData = new byte[totalLength];
			if (this.DiscStream.Position != newPosition) { this.DiscStream.Position = newPosition; }
			for (; ; )
			{
				entryData[0] = (byte)this.DiscStream.ReadByte(); //this is the size of the ID
				if (entryData[0] == 0) { break; }
				totalLength += entryData[0];
				if (entryData.Length < totalLength) { Array.Resize(ref entryData, totalLength); }
				this.DiscStream.ReadExactly(entryData, 1, totalLength - 1);

				var entry = new PathTableRecord(bigEndian);
				Helper.Marshaler.PtrToStructure(entryData, 0, ref entry);
				yield return entry;
			}
		}
	}
}