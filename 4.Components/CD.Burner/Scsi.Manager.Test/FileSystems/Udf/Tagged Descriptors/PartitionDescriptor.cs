using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace FileSystems.Udf
{
	[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
	public class PartitionDescriptor : TaggedDescriptor
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr VOLUME_DESCRIPTOR_SEQUENCE_NUMBER_BP = (IntPtr)16; //Marshal.OffsetOf(typeof(PartitionDescriptor), "_VolumeDescriptorSequenceNumber");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr FLAGS_BP = (IntPtr)20; //Marshal.OffsetOf(typeof(PartitionDescriptor), "_Flags");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr PARTITION_NUMBER_BP = (IntPtr)22; //Marshal.OffsetOf(typeof(PartitionDescriptor), "_PartitionNumber");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr PARTITION_CONTENTS_BP = (IntPtr)24; //Marshal.OffsetOf(typeof(PartitionDescriptor), "_PartitionContents");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr UNALLOCATED_SPACE_TABLE_BP = (IntPtr)56; //Marshal.OffsetOf(typeof(PartitionDescriptor), "_UnallocatedSpaceTable");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr UNALLOCATED_SPACE_BITMAP_BP = (IntPtr)64; //Marshal.OffsetOf(typeof(PartitionDescriptor), "_UnallocatedSpaceBitmap");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr PARTITION_INTEGRITY_TABLE_BP = (IntPtr)72; //Marshal.OffsetOf(typeof(PartitionDescriptor), "_PartitionIntegrityTable");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr FREED_SPACE_TABLE_BP = (IntPtr)80; //Marshal.OffsetOf(typeof(PartitionDescriptor), "_FreedSpaceTable");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr FREED_SPACE_BITMAP_BP = (IntPtr)88; //Marshal.OffsetOf(typeof(PartitionDescriptor), "_FreedSpaceBitmap");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr RESERVED_BP = (IntPtr)96; //Marshal.OffsetOf(typeof(PartitionDescriptor), "_Reserved");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr ACCESS_TYPE_BP = (IntPtr)184; //Marshal.OffsetOf(typeof(PartitionDescriptor), "_AccessType");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr PARTITION_STARTING_LOCATION_BP = (IntPtr)188; //Marshal.OffsetOf(typeof(PartitionDescriptor), "_PartitionStartingLocation");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr PARTITION_LENGTH_BP = (IntPtr)192; //Marshal.OffsetOf(typeof(PartitionDescriptor), "_PartitionLength");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr IMPLEMENTATION_IDENTIFIER_BP = (IntPtr)196; //Marshal.OffsetOf(typeof(PartitionDescriptor), "_ImplementationIdentifier");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr IMPLEMENTATION_USE_BP = (IntPtr)228; //Marshal.OffsetOf(typeof(PartitionDescriptor), "_ImplementationUse");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr RESERVED2_BP = (IntPtr)356; //Marshal.OffsetOf(typeof(PartitionDescriptor), "_Reserved2");

		public PartitionDescriptor() : base(DescriptorTagIdentifier.PartitionDescriptor) { }

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private uint _VolumeDescriptorSequenceNumber;
		public uint VolumeDescriptorSequenceNumber { get { return this._VolumeDescriptorSequenceNumber; } set { this._VolumeDescriptorSequenceNumber = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private PartitionFlags _Flags;
		public PartitionFlags Flags { get { return this._Flags; } set { this._Flags = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ushort _PartitionNumber;
		public ushort PartitionNumber { get { return this._PartitionNumber; } set { this._PartitionNumber = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EntityIdentifier _PartitionContents;
		public EntityIdentifier PartitionContents { get { return this._PartitionContents; } set { this._PartitionContents = value; } }

		#region UDF-Specific - 128 bytes
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ShortAllocationDescriptor _UnallocatedSpaceTable;
		public ShortAllocationDescriptor UnallocatedSpaceTable { get { return this._UnallocatedSpaceTable; } set { this._UnallocatedSpaceTable = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ShortAllocationDescriptor _UnallocatedSpaceBitmap;
		public ShortAllocationDescriptor UnallocatedSpaceBitmap { get { return this._UnallocatedSpaceBitmap; } set { this._UnallocatedSpaceBitmap = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ShortAllocationDescriptor _PartitionIntegrityTable;
		public ShortAllocationDescriptor PartitionIntegrityTable { get { return this._PartitionIntegrityTable; } set { this._PartitionIntegrityTable = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ShortAllocationDescriptor _FreedSpaceTable;
		public ShortAllocationDescriptor FreedSpaceTable { get { return this._FreedSpaceTable; } set { this._FreedSpaceTable = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ShortAllocationDescriptor _FreedSpaceBitmap;
		public ShortAllocationDescriptor FreedSpaceBitmap { get { return this._FreedSpaceBitmap; } set { this._FreedSpaceBitmap = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 88)]
		private byte[] _Reserved = EMPTY_BYTES; //new byte[88];
		#endregion

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private PartitionAccessType _AccessType;
		public PartitionAccessType AccessType { get { return this._AccessType; } set { this._AccessType = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private uint _PartitionStartingLocation;
		/// <summary>The starting location of the partition in logical sectors.</summary>
		public uint PartitionStartSector { get { return this._PartitionStartingLocation; } set { this._PartitionStartingLocation = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private uint _PartitionLength;
		/// <summary>The length of the partition in logical sectors.</summary>
		public uint PartitionSectorCount { get { return this._PartitionLength; } set { this._PartitionLength = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EntityIdentifier _ImplementationIdentifier;
		public EntityIdentifier ImplementationIdentifier { get { return this._ImplementationIdentifier; } set { this._ImplementationIdentifier = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
		private byte[] _ImplementationUse = EMPTY_BYTES; //new byte[128];
		public byte[] ImplementationUse { get { return this._ImplementationUse; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 156)]
		private byte[] _Reserved2 = EMPTY_BYTES; //new byte[156];

		protected override void MarshalFromBeforeValidate(BufferWithSize buffer)
		{
			base.MarshalFromBeforeValidate(buffer);

			this._VolumeDescriptorSequenceNumber = buffer.Read<uint>(VOLUME_DESCRIPTOR_SEQUENCE_NUMBER_BP);
			this._Flags = buffer.Read<PartitionFlags>(FLAGS_BP);
			this._PartitionNumber = buffer.Read<ushort>(PARTITION_NUMBER_BP);
			this._PartitionContents = buffer.Read<EntityIdentifier>(PARTITION_CONTENTS_BP);
			this._UnallocatedSpaceTable = buffer.Read<ShortAllocationDescriptor>(UNALLOCATED_SPACE_TABLE_BP);
			this._UnallocatedSpaceBitmap = buffer.Read<ShortAllocationDescriptor>(UNALLOCATED_SPACE_BITMAP_BP);
			this._PartitionIntegrityTable = buffer.Read<ShortAllocationDescriptor>(PARTITION_INTEGRITY_TABLE_BP);
			this._FreedSpaceTable = buffer.Read<ShortAllocationDescriptor>(FREED_SPACE_TABLE_BP);
			this._FreedSpaceBitmap = buffer.Read<ShortAllocationDescriptor>(FREED_SPACE_BITMAP_BP);
			this._Reserved = new byte[88];
			buffer.CopyTo((int)RESERVED_BP, this._Reserved, 0, this._Reserved.Length);
			this._AccessType = buffer.Read<PartitionAccessType>(ACCESS_TYPE_BP);
			this._PartitionStartingLocation = buffer.Read<uint>(PARTITION_STARTING_LOCATION_BP);
			this._PartitionLength = buffer.Read<uint>(PARTITION_LENGTH_BP);
			this._ImplementationIdentifier = buffer.Read<EntityIdentifier>(IMPLEMENTATION_IDENTIFIER_BP);
			this._ImplementationUse = new byte[128];
			buffer.CopyTo((int)IMPLEMENTATION_USE_BP, this._ImplementationUse, 0, this._ImplementationUse.Length);
			this._Reserved2 = new byte[156];
			buffer.CopyTo((int)RESERVED2_BP, this._Reserved2, 0, this._Reserved2.Length);
		}

		protected override void MarshalToBeforeValidate(BufferWithSize buffer)
		{
			base.MarshalToBeforeValidate(buffer);

			buffer.Write(this._VolumeDescriptorSequenceNumber, VOLUME_DESCRIPTOR_SEQUENCE_NUMBER_BP);
			buffer.Write(this._Flags, FLAGS_BP);
			buffer.Write(this._PartitionNumber, PARTITION_NUMBER_BP);
			buffer.Write(this._PartitionContents, PARTITION_CONTENTS_BP);
			buffer.Write(this._UnallocatedSpaceTable, UNALLOCATED_SPACE_TABLE_BP);
			buffer.Write(this._UnallocatedSpaceBitmap, UNALLOCATED_SPACE_BITMAP_BP);
			buffer.Write(this._PartitionIntegrityTable, PARTITION_INTEGRITY_TABLE_BP);
			buffer.Write(this._FreedSpaceTable, FREED_SPACE_TABLE_BP);
			buffer.Write(this._FreedSpaceBitmap, FREED_SPACE_BITMAP_BP);
			if (this._Reserved.Length > 88) { throw new OverflowException("Field is too large."); }
			buffer.CopyFrom((int)RESERVED_BP, this._Reserved, 0, this._Reserved.Length);
			buffer.Write(this._AccessType, ACCESS_TYPE_BP);
			buffer.Write(this._PartitionStartingLocation, PARTITION_STARTING_LOCATION_BP);
			buffer.Write(this._PartitionLength, PARTITION_LENGTH_BP);
			buffer.Write(this._ImplementationIdentifier, IMPLEMENTATION_IDENTIFIER_BP);
			if (this._ImplementationUse.Length > 128) { throw new OverflowException("Field is too large."); }
			buffer.CopyFrom((int)IMPLEMENTATION_USE_BP, this._ImplementationUse, 0, this._ImplementationUse.Length);
			if (this._Reserved2.Length > 156) { throw new OverflowException("Field is too large."); }
			buffer.CopyFrom((int)RESERVED2_BP, this._Reserved2, 0, this._Reserved2.Length);
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected override int MarshaledSize { get { return 512; } }

		public override object Clone() { var me = (PartitionDescriptor)base.Clone(); me._ImplementationUse = (byte[])me._ImplementationUse.Clone(); me._Reserved = (byte[])me._Reserved.Clone(); me._Reserved2 = (byte[])me._Reserved2.Clone(); return me; }
	}

	public enum PartitionAccessType : int { None = 0, ReadOnly = 1, WriteOnce = 2, Rewritable = 3, Overwritable = 4 }

	[Flags]
	public enum PartitionFlags : short { None = 0, VolumeSpaceAllocated = 1 << 0 }
}