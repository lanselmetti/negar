using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace FileSystems.Udf
{
	[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
	public class LogicalVolumeIntegrityDescriptor : TaggedDescriptor
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr RECORDING_TIME_BP = (IntPtr)16; //Marshal.OffsetOf(typeof(LogicalVolumeIntegrityDescriptor), "_RecordingTime");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr INTEGRITY_TYPE_BP = (IntPtr)28; //Marshal.OffsetOf(typeof(LogicalVolumeIntegrityDescriptor), "_IntegrityType");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr NEXT_INTEGRITY_EXTENT_BP = (IntPtr)32; //Marshal.OffsetOf(typeof(LogicalVolumeIntegrityDescriptor), "_NextIntegrityExtent");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr LOGICAL_VOLUME_HEADER_DESCRIPTOR = (IntPtr)40; //Marshal.OffsetOf(typeof(LogicalVolumeIntegrityDescriptor), "_LogicalVolumeHeaderDescriptor");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr PARTITION_COUNT_BP = (IntPtr)72; //Marshal.OffsetOf(typeof(LogicalVolumeIntegrityDescriptor), "_PartitionCount");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr IMPLEMENTATION_USE_LENGTH_BP = (IntPtr)76; //Marshal.OffsetOf(typeof(LogicalVolumeIntegrityDescriptor), "_ImplementationUseLength");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr FREE_SPACE_TABLE_BP = (IntPtr)80; //Marshal.OffsetOf(typeof(LogicalVolumeIntegrityDescriptor), "_FreeSpaceTable");

		//The following are RELATIVE Byte Pointers!
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr IMPLEMENTATION_IDENTIFIER_RBP = (IntPtr)0; //Marshal.OffsetOf(typeof(LogicalVolumeIntegrityDescriptor), "_ImplementationIdentifier");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr FILE_COUNT_RBP = (IntPtr)32; //Marshal.OffsetOf(typeof(LogicalVolumeIntegrityDescriptor), "_FileCount");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr DIRECTORY_COUNT_RBP = (IntPtr)36; //Marshal.OffsetOf(typeof(LogicalVolumeIntegrityDescriptor), "_DirectoryCount");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr MINIMUM_UDF_READ_REVISION_RBP = (IntPtr)40; //Marshal.OffsetOf(typeof(LogicalVolumeIntegrityDescriptor), "_MinimumUdfReadRevision");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr MINIMUM_UDF_WRITE_REVISION_RBP = (IntPtr)42; //Marshal.OffsetOf(typeof(LogicalVolumeIntegrityDescriptor), "_MinimumUdfWriteRevision");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr MAXIMUM_UDF_WRITE_REVISION_RBP = (IntPtr)44; //Marshal.OffsetOf(typeof(LogicalVolumeIntegrityDescriptor), "_MaximumUdfWriteRevision");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr IMPLEMENTATION_USE_RBP = (IntPtr)46; //Marshal.OffsetOf(typeof(LogicalVolumeIntegrityDescriptor), "_ImplementationUse");

		public LogicalVolumeIntegrityDescriptor() : base(DescriptorTagIdentifier.LogicalVolumeIntegrityDescriptor) { }

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Timestamp _RecordingTime = (Timestamp)DateTime.Now;
		public Timestamp RecordingTime { get { return this._RecordingTime; } set { this._RecordingTime = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private LogicalVolumeIntegrityType _IntegrityType;
		public LogicalVolumeIntegrityType IntegrityType { get { return this._IntegrityType; } set { this._IntegrityType = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ExtentAllocationDescriptor _NextIntegrityExtent;
		public ExtentAllocationDescriptor NextIntegrityExtent { get { return this._NextIntegrityExtent; } set { this._NextIntegrityExtent = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private LogicalVolumeHeaderDescriptor _LogicalVolumeHeaderDescriptor = new LogicalVolumeHeaderDescriptor(16);
		public LogicalVolumeHeaderDescriptor LogicalVolumeHeaderDescriptor { get { return this._LogicalVolumeHeaderDescriptor; } set { this._LogicalVolumeHeaderDescriptor = value; } }
		public ulong GetNextUniqueId(bool increment) { var oldID = this.LogicalVolumeHeaderDescriptor.UniqueIdentifier; var newID = oldID + 1; if ((newID & 0xFFFFFFFF) == 0) { newID += 16; } if (increment) { var header = this.LogicalVolumeHeaderDescriptor; header = new LogicalVolumeHeaderDescriptor(newID); this.LogicalVolumeHeaderDescriptor = header; } return oldID; }


		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private uint _PartitionCount;
#if OLD_ARRAYS
		public uint PartitionCount
		{
			get { return this._PartitionCount; }
			set
			{
				this._PartitionCount = value;
				var fst = this.FreeSpaceTable;
				Array.Resize(ref fst, (int)value);
				this.FreeSpaceTable = fst;
				var st = this.SizeTable;
				Array.Resize(ref st, (int)value);
				this.SizeTable = st;
			}
		}
#endif
		/// <summary>The length of ALL FIELDS AFTER and including <see cref="_ImplementationIdentifier"/>.</summary>
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private uint _ImplementationUseLength = (uint)IMPLEMENTATION_USE_RBP;
#if OLD_ARRAYS
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		private uint[] _FreeSpaceTable;
		public uint[] FreeSpaceTable { get { return this._FreeSpaceTable; } private set { this._FreeSpaceTable = value; } }
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		private uint[] _SizeTable;
		public uint[] SizeTable { get { return this._SizeTable; } private set { this._SizeTable = value; } }
#else
		//NOTE: It's VERY important that sizeof(PartitionSizeInformation) == 2 * sizeof(uint); otherwise, this.MarshaledSize won't work
		[DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
		private PartitionSizeInformation[] _PartitionSizeInfos = new PartitionSizeInformation[0];
		public PartitionSizeInformation[] PartitionSizeInfos { get { return this._PartitionSizeInfos; } set { this._PartitionSizeInfos = value; this._PartitionCount = (uint)value.Length; } }
#endif

		//Hereafter, everything is "implementation use" by ECMA 167 (but NOT UDF)
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EntityIdentifier _ImplementationIdentifier;
		public EntityIdentifier ImplementationIdentifier { get { return this._ImplementationIdentifier; } set { this._ImplementationIdentifier = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private uint _FileCount;
		public uint FileCount { get { return this._FileCount; } set { this._FileCount = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private uint _DirectoryCount;
		public uint DirectoryCount { get { return this._DirectoryCount; } set { this._DirectoryCount = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private UdfRevision _MinimumUdfReadRevision;
		public UdfRevision MinimumUdfReadRevision { get { return this._MinimumUdfReadRevision; } set { this._MinimumUdfReadRevision = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private UdfRevision _MinimumUdfWriteRevision;
		public UdfRevision MinimumUdfWriteRevision { get { return this._MinimumUdfWriteRevision; } set { this._MinimumUdfWriteRevision = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private UdfRevision _MaximumUdfWriteRevision;
		public UdfRevision MaximumUdfWriteRevision { get { return this._MaximumUdfWriteRevision; } set { this._MaximumUdfWriteRevision = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		private byte[] _ImplementationUse = EMPTY_BYTES;
		public byte[] ImplementationUse { get { return this._ImplementationUse; } set { this._ImplementationUse = value; this._ImplementationUseLength = value != null ? (uint)value.Length + (uint)IMPLEMENTATION_USE_RBP : 0; } }

		protected override void MarshalFromBeforeValidate(BufferWithSize buffer)
		{
			base.MarshalFromBeforeValidate(buffer);

			this._RecordingTime = buffer.Read<Timestamp>(RECORDING_TIME_BP);
			this._IntegrityType = buffer.Read<LogicalVolumeIntegrityType>(INTEGRITY_TYPE_BP);
			this._NextIntegrityExtent = buffer.Read<ExtentAllocationDescriptor>(NEXT_INTEGRITY_EXTENT_BP);
			this._LogicalVolumeHeaderDescriptor = buffer.Read<LogicalVolumeHeaderDescriptor>(LOGICAL_VOLUME_HEADER_DESCRIPTOR);
			this._PartitionCount = buffer.Read<uint>(PARTITION_COUNT_BP);
			this._ImplementationUseLength = buffer.Read<uint>(IMPLEMENTATION_USE_LENGTH_BP);
#if OLD_ARRAYS
			this._FreeSpaceTable = new uint[this.PartitionCount];
			unsafe { fixed (uint* pArray = this._FreeSpaceTable) { BufferWithSize.Copy(buffer, (uint)FREE_SPACE_TABLE_BP, new BufferWithSize((IntPtr)pArray, this._FreeSpaceTable.Length * sizeof(uint)), 0, this.PartitionCount * sizeof(uint)); } }
			this._SizeTable = new uint[this.PartitionCount];
			unsafe { fixed (uint* pArray = this._SizeTable) { BufferWithSize.Copy(buffer, (uint)FREE_SPACE_TABLE_BP + 1 * this.PartitionCount * sizeof(uint), new BufferWithSize((IntPtr)pArray, this._SizeTable.Length * sizeof(uint)), 0, this.PartitionCount * sizeof(uint)); } }
#else
			this._PartitionSizeInfos = new PartitionSizeInformation[this._PartitionCount];
			for (uint i = 0; i < this._PartitionCount; i++)
			{ this._PartitionSizeInfos[i] = new PartitionSizeInformation(buffer.Read<uint>((uint)FREE_SPACE_TABLE_BP + i * sizeof(uint)), buffer.Read<uint>((uint)FREE_SPACE_TABLE_BP + (1 * this._PartitionCount + i) * sizeof(uint))); }
#endif
			uint implUseStart = (uint)FREE_SPACE_TABLE_BP + 2 * sizeof(uint) * this._PartitionCount;
			this._ImplementationIdentifier = buffer.Read<EntityIdentifier>(implUseStart + (uint)IMPLEMENTATION_IDENTIFIER_RBP);
			this._FileCount = buffer.Read<uint>(implUseStart + (uint)FILE_COUNT_RBP);
			this._DirectoryCount = buffer.Read<uint>(implUseStart + (uint)DIRECTORY_COUNT_RBP);
			this._MinimumUdfReadRevision = buffer.Read<UdfRevision>(implUseStart + (uint)MINIMUM_UDF_READ_REVISION_RBP);
			this._MinimumUdfWriteRevision = buffer.Read<UdfRevision>(implUseStart + (uint)MINIMUM_UDF_WRITE_REVISION_RBP);
			this._MaximumUdfWriteRevision = buffer.Read<UdfRevision>(implUseStart + (uint)MAXIMUM_UDF_WRITE_REVISION_RBP);
			this._ImplementationUse = new byte[this._ImplementationUseLength - (int)IMPLEMENTATION_USE_RBP];
			buffer.CopyTo(implUseStart + (uint)IMPLEMENTATION_USE_RBP, this._ImplementationUse, 0, this._ImplementationUse.Length);
		}

		protected override void MarshalToBeforeValidate(BufferWithSize buffer)
		{
			base.MarshalToBeforeValidate(buffer);

			buffer.Write(this._RecordingTime, RECORDING_TIME_BP);
			buffer.Write(this._IntegrityType, INTEGRITY_TYPE_BP);
			buffer.Write(this._NextIntegrityExtent, NEXT_INTEGRITY_EXTENT_BP);
			buffer.Write(this._LogicalVolumeHeaderDescriptor, LOGICAL_VOLUME_HEADER_DESCRIPTOR);
			buffer.Write(this._PartitionCount, PARTITION_COUNT_BP);
			buffer.Write(this._ImplementationUseLength, IMPLEMENTATION_USE_LENGTH_BP);
#if OLD_ARRAYS
			if (this._FreeSpaceTable.Length > 1) { throw new OverflowException("Field is too large."); }
			unsafe { fixed (uint* pArray = this._FreeSpaceTable) { BufferWithSize.Copy(new BufferWithSize((IntPtr)pArray, this._FreeSpaceTable.Length * sizeof(uint)), 0, buffer, (uint)FREE_SPACE_TABLE_BP, this.PartitionCount * sizeof(uint)); } }
			if (this._SizeTable.Length > 1) { throw new OverflowException("Field is too large."); }
			unsafe { fixed (uint* pArray = this._SizeTable) { BufferWithSize.Copy(new BufferWithSize((IntPtr)pArray, this._SizeTable.Length * sizeof(uint)), 0, buffer, (uint)FREE_SPACE_TABLE_BP + 1 * this.PartitionCount * sizeof(uint), this.PartitionCount * sizeof(uint)); } }
#else
			for (uint i = 0; i < this._PartitionCount; i++)
			{
				buffer.Write(this._PartitionSizeInfos[i].FreeSpace, (uint)FREE_SPACE_TABLE_BP + i * sizeof(uint));
				buffer.Write(this._PartitionSizeInfos[i].Size, (uint)FREE_SPACE_TABLE_BP + (1 * this._PartitionCount + i) * sizeof(uint));
			}
#endif
			uint implUseStart = (uint)FREE_SPACE_TABLE_BP + 2 * sizeof(uint) * this._PartitionCount;
			buffer.Write(this._ImplementationIdentifier, implUseStart + (uint)IMPLEMENTATION_IDENTIFIER_RBP);
			buffer.Write(this._FileCount, implUseStart + (uint)FILE_COUNT_RBP);
			buffer.Write(this._DirectoryCount, implUseStart + (uint)DIRECTORY_COUNT_RBP);
			buffer.Write(this._MinimumUdfReadRevision, implUseStart + (uint)MINIMUM_UDF_READ_REVISION_RBP);
			buffer.Write(this._MinimumUdfWriteRevision, implUseStart + (uint)MINIMUM_UDF_WRITE_REVISION_RBP);
			buffer.Write(this._MaximumUdfWriteRevision, implUseStart + (uint)MAXIMUM_UDF_WRITE_REVISION_RBP);
			if (this._ImplementationUse.Length > 1) { throw new OverflowException("Field is too large."); }
			buffer.CopyFrom(implUseStart + (uint)IMPLEMENTATION_USE_RBP, this._ImplementationUse, 0, this._ImplementationUse.Length);
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected override int MarshaledSize { get { return (int)FREE_SPACE_TABLE_BP + (int)this._PartitionCount * 2 * sizeof(uint) + (int)this._ImplementationUseLength; } }

		public override object Clone() { var me = (LogicalVolumeIntegrityDescriptor)base.Clone(); me._PartitionSizeInfos = (PartitionSizeInformation[])me._PartitionSizeInfos.Clone(); me._ImplementationUse = (byte[])me._ImplementationUse.Clone(); return me; }
	}

	public struct PartitionSizeInformation { public PartitionSizeInformation(uint free, uint size) { this.FreeSpace = free; this.Size = size; } public readonly uint FreeSpace; public readonly uint Size; }

	[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 32)]
	public struct LogicalVolumeHeaderDescriptor : IEquatable<LogicalVolumeHeaderDescriptor>
	{
		public LogicalVolumeHeaderDescriptor(ulong uniqueId) { this.UniqueIdentifier = uniqueId; }
		public readonly ulong UniqueIdentifier;
		public static LogicalVolumeHeaderDescriptor CreateNew() { unsafe { var guid = Guid.NewGuid(); return new LogicalVolumeHeaderDescriptor(*(ulong*)&guid); } }
		public bool Equals(LogicalVolumeHeaderDescriptor other) { return this.UniqueIdentifier == other.UniqueIdentifier; }
		public override bool Equals(object obj) { return obj is LogicalVolumeHeaderDescriptor && this.Equals((LogicalVolumeHeaderDescriptor)obj); }
		public override int GetHashCode() { return this.UniqueIdentifier.GetHashCode(); }
		public override string ToString() { return this.UniqueIdentifier.ToString(); }
		public static bool operator ==(LogicalVolumeHeaderDescriptor left, LogicalVolumeHeaderDescriptor right) { return left.Equals(right); }
		public static bool operator !=(LogicalVolumeHeaderDescriptor left, LogicalVolumeHeaderDescriptor right) { return !left.Equals(right); }
	}

	public enum LogicalVolumeIntegrityType : int { Open, Closed }
}