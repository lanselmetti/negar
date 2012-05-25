using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace FileSystems.Udf
{
	[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
	public class MetadataPartitionMap : UdfType2PartitionMap
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr METADATA_FILE_LOCATION_BP = (IntPtr)40; //Marshal.OffsetOf(typeof(MetadataPartitionMap), "_MetadataFileLocation");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr METADATA_MIRROR_FILE_LOCATION_BP = (IntPtr)44; //Marshal.OffsetOf(typeof(MetadataPartitionMap), "_MetadataMirrorFileLocation");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr METADATA_BITMAP_FILE_LOCATION_BP = (IntPtr)48; //Marshal.OffsetOf(typeof(MetadataPartitionMap), "_MetadataBitmapFileLocation");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr ALLOCATION_UNIT_SIZE_BP = (IntPtr)52; //Marshal.OffsetOf(typeof(MetadataPartitionMap), "_AllocationUnitSize");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr ALIGNMENT_UNIT_SIZE_BP = (IntPtr)56; //Marshal.OffsetOf(typeof(MetadataPartitionMap), "_AlignmentUnitSize");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr FLAGS_BP = (IntPtr)58; //Marshal.OffsetOf(typeof(MetadataPartitionMap), "_Flags");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr RESERVED2_BP = (IntPtr)59; //Marshal.OffsetOf(typeof(MetadataPartitionMap), "_Reserved2");

		public MetadataPartitionMap() : base(new EntityIdentifier(0, EntityIdentifier.MetadataPartitionMapId, 0)) { }

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private uint _MetadataFileLocation;
		/// <summary>Address of the block containing the file entry for the metadata file. This address is interpreted as a logical block number within the physical or sparable partition associated with this partition map.</summary>
		public uint MetadataFileLocation { get { return this._MetadataFileLocation; } set { this._MetadataFileLocation = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private uint _MetadataMirrorFileLocation;
		/// <summary>Address of the block containing the file entry for the metadata file mirror. This address is interpreted as a logical block number within the physical or sparable partition associated with this partition map.</summary>
		public uint MetadataMirrorFileLocation { get { return this._MetadataMirrorFileLocation; } set { this._MetadataMirrorFileLocation = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private uint _MetadataBitmapFileLocation;
		/// <summary>Address of the block containing the file entry for the metadata file bitmap. This address is interpreted as a logical block number within the physical or sparable partition associated with this partition map. If the value of the metadata bitmap file location field is equal to <see cref="uint.MaxValue"/>, no file entry for the metadata bitmap file is defined.</summary>
		public uint MetadataBitmapFileLocation { get { return this._MetadataBitmapFileLocation; } set { this._MetadataBitmapFileLocation = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private uint _AllocationUnitSize; //In blocks
		public uint AllocationUnitSize { get { return this._AllocationUnitSize; } set { this._AllocationUnitSize = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ushort _AlignmentUnitSize; //In blocks
		public ushort AlignmentUnitSize { get { return this._AlignmentUnitSize; } set { this._AlignmentUnitSize = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetadataPartitionMapFlags _Flags;
		public MetadataPartitionMapFlags Flags { get { return this._Flags; } set { this._Flags = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
		private byte[] _Reserved2 = new byte[5];

		protected override void MarshalFrom(BufferWithSize buffer)
		{
			base.MarshalFrom(buffer);
			this._MetadataFileLocation = buffer.Read<uint>(METADATA_FILE_LOCATION_BP);
			this._MetadataMirrorFileLocation = buffer.Read<uint>(METADATA_MIRROR_FILE_LOCATION_BP);
			this._MetadataBitmapFileLocation = buffer.Read<uint>(METADATA_BITMAP_FILE_LOCATION_BP);
			this._AllocationUnitSize = buffer.Read<uint>(ALLOCATION_UNIT_SIZE_BP);
			this._AlignmentUnitSize = buffer.Read<ushort>(ALIGNMENT_UNIT_SIZE_BP);
			this._Flags = buffer.Read<MetadataPartitionMapFlags>(FLAGS_BP);
			this._Reserved2 = new byte[5];
			buffer.CopyTo((int)RESERVED2_BP, this._Reserved2, 0, this._Reserved2.Length);
		}

		protected override void MarshalTo(BufferWithSize buffer)
		{
			base.MarshalTo(buffer);
			buffer.Write(this._MetadataFileLocation, METADATA_FILE_LOCATION_BP);
			buffer.Write(this._MetadataMirrorFileLocation, METADATA_MIRROR_FILE_LOCATION_BP);
			buffer.Write(this._MetadataBitmapFileLocation, METADATA_BITMAP_FILE_LOCATION_BP);
			buffer.Write(this._AllocationUnitSize, ALLOCATION_UNIT_SIZE_BP);
			buffer.Write(this._AlignmentUnitSize, ALIGNMENT_UNIT_SIZE_BP);
			buffer.Write(this._Flags, FLAGS_BP);
			if (this._Reserved2.Length > 5) { throw new OverflowException("Field is too large."); }
			buffer.CopyFrom((int)RESERVED2_BP, this._Reserved2, 0, this._Reserved2.Length);
			buffer.Initialize((int)RESERVED2_BP + this._Reserved2.Length, 5 - this._Reserved2.Length);
		}

		protected override int MarshaledSize { get { return Marshaler.DefaultSizeOf<MetadataPartitionMap>(); } }
	}

	[Flags]
	public enum MetadataPartitionMapFlags : byte { None = 0, DuplicateMetadata = 1 << 0 }
}