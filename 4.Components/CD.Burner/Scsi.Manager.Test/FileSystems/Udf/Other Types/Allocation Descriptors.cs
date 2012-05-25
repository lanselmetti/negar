using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace FileSystems.Udf
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct LogicalBlockAddress : IEquatable<LogicalBlockAddress>
	{
		public LogicalBlockAddress(uint logicalBlockNumber, ushort partitionReferenceNumber) { this.LogicalBlockNumber = logicalBlockNumber; this.PartitionReferenceNumber = partitionReferenceNumber; }

		public readonly uint LogicalBlockNumber;
		public readonly ushort PartitionReferenceNumber;

		public override bool Equals(object obj) { return obj is LogicalBlockAddress && this.Equals((LogicalBlockAddress)obj); }
		public override int GetHashCode() { return this.LogicalBlockNumber.GetHashCode() ^ this.PartitionReferenceNumber.GetHashCode(); }
		public bool Equals(LogicalBlockAddress other) { return this.LogicalBlockNumber == other.LogicalBlockNumber && this.PartitionReferenceNumber == other.PartitionReferenceNumber; }
		public override string ToString() { return string.Format("LBA 0x{0:X} on Partition {1}", this.LogicalBlockNumber, this.PartitionReferenceNumber); }
		public static bool operator ==(LogicalBlockAddress left, LogicalBlockAddress right) { return left.Equals(right); }
		public static bool operator !=(LogicalBlockAddress left, LogicalBlockAddress right) { return !left.Equals(right); }
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct ShortAllocationDescriptor : IEquatable<ShortAllocationDescriptor>
	{
		public ShortAllocationDescriptor(uint location, uint length, ExtentType type) : this(location, checked((int)length), type) { }
		public ShortAllocationDescriptor(uint location, int length, ExtentType type)
		{
			if ((length & 0xC0000000) != 0) { throw new ArgumentOutOfRangeException("length", length, "Length can only use 30 bits."); }
			if (((int)type & 0x3FFFFFFF) != 0) { throw new ArgumentOutOfRangeException("type", type, "Invalid extent type."); }
			this._Length = length | (int)type;
			this.LogicalBlockNumber = location;
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly int _Length;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly uint LogicalBlockNumber;
		public int ByteLength { get { return this._Length & 0x3FFFFFFF; } }
		public ExtentType AllocationType { get { return (ExtentType)(this._Length & 0xC0000000); } }

		public bool Equals(ShortAllocationDescriptor other) { return this._Length == other._Length && this.LogicalBlockNumber == other.LogicalBlockNumber; }
		public override bool Equals(object obj) { return obj is ShortAllocationDescriptor && this.Equals((ShortAllocationDescriptor)obj); }
		public override int GetHashCode() { return this._Length.GetHashCode() ^ this.LogicalBlockNumber.GetHashCode(); }
		public override string ToString() { return string.Format("LBA = 0x{0:X}, Length = 0x{1:X} ({2})", this.LogicalBlockNumber, this._Length, this.AllocationType); }
		public static bool operator ==(ShortAllocationDescriptor left, ShortAllocationDescriptor right) { return left.Equals(right); }
		public static bool operator !=(ShortAllocationDescriptor left, ShortAllocationDescriptor right) { return !left.Equals(right); }
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct ExtentAllocationDescriptor : IEquatable<ExtentAllocationDescriptor>
	{
		public ExtentAllocationDescriptor(uint logicalSectorNumber, uint byteLength) : this(logicalSectorNumber, checked((int)byteLength)) { }
		public ExtentAllocationDescriptor(uint logicalSectorNumber, int byteLength)
		{
			if ((byteLength & 0xC0000000) != 0) { throw new ArgumentOutOfRangeException("byteLength", byteLength, "The length of any extent must be less than 2^30."); }
			this.ByteLength = byteLength;
			this.LogicalSectorNumber = logicalSectorNumber;
		}

		/// <summary>This field shall indicate the length of the extent, in bytes, identified by the <see cref="LogicalSectorNumber"/> field. The length must be less than <c>1 &lt;&lt; 30</c>. Unless otherwise specified, the length is an integral multiple of the logical sector size.</summary>
		public readonly int ByteLength;
		/// <summary>This field shall specify the location of the extent, as a logical sector number. If the extent's length is <c>0</c>, no extent is specified and this field contains <c>0</c>.</summary>
		public readonly uint LogicalSectorNumber;

		public bool Equals(ExtentAllocationDescriptor other) { return this.ByteLength == other.ByteLength && this.LogicalSectorNumber == other.LogicalSectorNumber; }
		public override bool Equals(object obj) { return obj is ExtentAllocationDescriptor && this.Equals((ExtentAllocationDescriptor)obj); }
		public override int GetHashCode() { return this.ByteLength.GetHashCode() ^ this.LogicalSectorNumber.GetHashCode(); }
		public override string ToString() { return string.Format("Sector = 0x{0:X}, Length = 0x{1:X}", this.LogicalSectorNumber, this.ByteLength); }
		public static bool operator ==(ExtentAllocationDescriptor left, ExtentAllocationDescriptor right) { return left.Equals(right); }
		public static bool operator !=(ExtentAllocationDescriptor left, ExtentAllocationDescriptor right) { return !left.Equals(right); }
	}

	public enum ExtentType : int
	{
		Recorded = 0x00000000,
		Allocated = 0x40000000,
		Unallocated = unchecked((int)0x80000000),
		NextAllocationDescriptorsExtent = unchecked((int)0xF0000000),
	}

	[StructLayout(LayoutKind.Explicit, Pack = 1), DebuggerDisplay(@"\{Partition #{ExtentLocation.PartitionReferenceNumber}, Block {ExtentLocation.LogicalBlockNumber}, {ShortAllocationDescriptor.ByteLength} bytes ({ShortAllocationDescriptor.AllocationType}), {Flags}\}")]
	public struct LongAllocationDescriptor : IEquatable<LongAllocationDescriptor>
	{
		public LongAllocationDescriptor(ShortAllocationDescriptor shortAllocationDescriptor, ushort partition, ExtentFlags flags, uint implementationUse)
		{
			this.ExtentLocation = new LogicalBlockAddress(shortAllocationDescriptor.LogicalBlockNumber, partition);
			this.ShortAllocationDescriptor = shortAllocationDescriptor;
			this.Flags = flags;
			this.ImplementationUse = implementationUse;
		}

		[FieldOffset(0)]
		public readonly ShortAllocationDescriptor ShortAllocationDescriptor;
		[FieldOffset(sizeof(uint))]
		public readonly LogicalBlockAddress ExtentLocation;
		[FieldOffset(sizeof(uint) * 2 + sizeof(ushort))]
		public readonly ExtentFlags Flags;
		[FieldOffset(sizeof(uint) * 2 + sizeof(ushort) + sizeof(ExtentFlags))]
		public readonly uint ImplementationUse;

		public bool Equals(LongAllocationDescriptor other) { return this.ShortAllocationDescriptor == other.ShortAllocationDescriptor && this.ExtentLocation == other.ExtentLocation && this.Flags == other.Flags && this.ImplementationUse == other.ImplementationUse; }
		public override bool Equals(object obj) { return obj is LongAllocationDescriptor && this.Equals((LongAllocationDescriptor)obj); }
		public override int GetHashCode() { return this.ShortAllocationDescriptor.GetHashCode() ^ this.ExtentLocation.GetHashCode() ^ this.Flags.GetHashCode() ^ this.ImplementationUse.GetHashCode(); }
		public override string ToString() { return string.Format("Allocation {{ Partition = {0:N0}, LBA = 0x{1:X}, Length = 0x{2:X} bytes ({3}), Flags = {4} }}", this.ExtentLocation.PartitionReferenceNumber, this.ExtentLocation.LogicalBlockNumber, this.ShortAllocationDescriptor.ByteLength, this.ShortAllocationDescriptor.AllocationType, this.Flags); }
		public static bool operator ==(LongAllocationDescriptor left, LongAllocationDescriptor right) { return left.Equals(right); }
		public static bool operator !=(LongAllocationDescriptor left, LongAllocationDescriptor right) { return !left.Equals(right); }
	}

	[Flags]
	public enum ExtentFlags : short { None = 0, Erased = 1 << 0 }
}