using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace FileSystems.Udf
{
	[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
	public class LogicalVolumeDescriptor : TaggedDescriptor
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr VOLUME_DESCRIPTOR_SEQUENCE_NUMBER_BP = (IntPtr)16; //Marshal.OffsetOf(typeof(LogicalVolumeDescriptor), "_VolumeDescriptorSequenceNumber");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr DESCRIPTOR_CHARACTER_SET_BP = (IntPtr)20; //Marshal.OffsetOf(typeof(LogicalVolumeDescriptor), "_DescriptorCharacterSet");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr LOGICAL_VOLUME_IDENTIFIER_BP = (IntPtr)84; //Marshal.OffsetOf(typeof(LogicalVolumeDescriptor), "_LogicalVolumeIdentifier");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr LOGICAL_BLOCK_SIZE_BP = (IntPtr)212; //Marshal.OffsetOf(typeof(LogicalVolumeDescriptor), "_LogicalBlockSize");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr DOMAIN_IDENTIFIER_BP = (IntPtr)216; //Marshal.OffsetOf(typeof(LogicalVolumeDescriptor), "_DomainIdentifier");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr FILE_SET_DESCRIPTOR_EXTENT_BP = (IntPtr)248; //Marshal.OffsetOf(typeof(LogicalVolumeDescriptor), "_FileSetDescriptorExtent");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr MAP_TABLE_LENGTH_BP = (IntPtr)264; //Marshal.OffsetOf(typeof(LogicalVolumeDescriptor), "_MapTableLength");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr PARTITION_MAP_COUNT_BP = (IntPtr)268; //Marshal.OffsetOf(typeof(LogicalVolumeDescriptor), "_PartitionMapCount");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr IMPLEMENTATION_IDENTIFIER_BP = (IntPtr)272; //Marshal.OffsetOf(typeof(LogicalVolumeDescriptor), "_ImplementationIdentifier");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr IMPLEMENTATION_USE_BP = (IntPtr)304; //Marshal.OffsetOf(typeof(LogicalVolumeDescriptor), "_ImplementationUse");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr INTEGRITY_SEQUENCE_EXTENT_BP = (IntPtr)432; //Marshal.OffsetOf(typeof(LogicalVolumeDescriptor), "_IntegritySequenceExtent");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr PARTITION_MAPS_BP = (IntPtr)440; //Marshal.OffsetOf(typeof(LogicalVolumeDescriptor), "_PartitionMaps");

		public LogicalVolumeDescriptor() : base(DescriptorTagIdentifier.LogicalVolumeDescriptor) { }

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private uint _VolumeDescriptorSequenceNumber;
		public uint VolumeDescriptorSequenceNumber { get { return this._VolumeDescriptorSequenceNumber; } set { this._VolumeDescriptorSequenceNumber = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private CharacterSpecification _DescriptorCharacterSet = CharacterSpecification.OstaCompressedUnicode;
		public CharacterSpecification DescriptorCharacterSet { get { return this._DescriptorCharacterSet; } set { this._DescriptorCharacterSet = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
		private string _LogicalVolumeIdentifier = string.Empty;
		public string LogicalVolumeIdentifier { get { return this._LogicalVolumeIdentifier; } set { if (value.Length >= 128) { throw new ArgumentException("value", "String must be at most 127 characters long."); } this._LogicalVolumeIdentifier = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _LogicalBlockSize;
		public int LogicalBlockSize { get { return this._LogicalBlockSize; } set { if (value < 512 | value % 512 != 0) { throw new ArgumentOutOfRangeException("value", value, "The logical block size must be positive and a multiple of 512 bytes."); } this._LogicalBlockSize = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EntityIdentifier _DomainIdentifier = new EntityIdentifier(EntityIdentifierFlags.None, EntityIdentifier.LogicalVolumeDescriptorDomainId, 0);
		public EntityIdentifier DomainIdentifier { get { return this._DomainIdentifier; } set { this._DomainIdentifier = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private LongAllocationDescriptor _FileSetDescriptorExtent;
		public LongAllocationDescriptor FileSetDescriptorExtent { get { return this._FileSetDescriptorExtent; } set { this._FileSetDescriptorExtent = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private uint _MapTableLength;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private uint _PartitionMapCount;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EntityIdentifier _ImplementationIdentifier;
		public EntityIdentifier ImplementationIdentifier { get { return this._ImplementationIdentifier; } set { this._ImplementationIdentifier = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
		private byte[] _ImplementationUse = EMPTY_BYTES; //new byte[128];
		public byte[] ImplementationUse { get { return this._ImplementationUse; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ExtentAllocationDescriptor _IntegritySequenceExtent;
		public ExtentAllocationDescriptor IntegritySequenceExtent { get { return this._IntegritySequenceExtent; } set { this._IntegritySequenceExtent = value; } }
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		private PartitionMap[] _PartitionMaps = new PartitionMap[0];
		public PartitionMap[] PartitionMaps
		{
			get { return this._PartitionMaps; }
			set
			{
				this._PartitionMaps = value;
				this._PartitionMapCount = (uint)value.Length;
				this._MapTableLength = 0;
				foreach (var item in value) { this._MapTableLength += (uint)Marshaler.SizeOf(item); }
			}
		}

		protected override void MarshalFromBeforeValidate(BufferWithSize buffer)
		{
			base.MarshalFromBeforeValidate(buffer);

			this._DescriptorCharacterSet = buffer.Read<CharacterSpecification>(DESCRIPTOR_CHARACTER_SET_BP);
			if (this._DescriptorCharacterSet != CharacterSpecification.OstaCompressedUnicode) { throw new NotSupportedException("Character set not supported."); }

			this._VolumeDescriptorSequenceNumber = buffer.Read<uint>(VOLUME_DESCRIPTOR_SEQUENCE_NUMBER_BP);
			this._LogicalVolumeIdentifier = UdfHelper.DecodeOstaCompressedUnicode(buffer.ExtractSegment((int)LOGICAL_VOLUME_IDENTIFIER_BP, 128), true);
			this._LogicalBlockSize = buffer.Read<int>(LOGICAL_BLOCK_SIZE_BP);
			this._DomainIdentifier = buffer.Read<EntityIdentifier>(DOMAIN_IDENTIFIER_BP);
			this._FileSetDescriptorExtent = buffer.Read<LongAllocationDescriptor>(FILE_SET_DESCRIPTOR_EXTENT_BP);
			this._MapTableLength = buffer.Read<uint>(MAP_TABLE_LENGTH_BP);
			this._PartitionMapCount = buffer.Read<uint>(PARTITION_MAP_COUNT_BP);
			this._ImplementationIdentifier = buffer.Read<EntityIdentifier>(IMPLEMENTATION_IDENTIFIER_BP);
			this._ImplementationUse = new byte[128];
			buffer.CopyTo((int)IMPLEMENTATION_USE_BP, this._ImplementationUse, 0, this._ImplementationUse.Length);
			this._IntegritySequenceExtent = buffer.Read<ExtentAllocationDescriptor>(INTEGRITY_SEQUENCE_EXTENT_BP);
			this._PartitionMaps = new PartitionMap[this._PartitionMapCount];
			var partitionMapBuffer = buffer.ExtractSegment(PARTITION_MAPS_BP);
			for (uint i = 0; i < this._PartitionMapCount; i++)
			{
				this._PartitionMaps[i] = PartitionMap.FromBuffer(partitionMapBuffer);
				partitionMapBuffer = partitionMapBuffer.ExtractSegment(this._PartitionMaps[i].Length);
			}
		}

		protected override void MarshalToBeforeValidate(BufferWithSize buffer)
		{
			base.MarshalToBeforeValidate(buffer);

			if (this._DescriptorCharacterSet != CharacterSpecification.OstaCompressedUnicode) { throw new NotSupportedException("Character set not supported."); }

			buffer.Write(this._VolumeDescriptorSequenceNumber, VOLUME_DESCRIPTOR_SEQUENCE_NUMBER_BP);
			buffer.Write(this._DescriptorCharacterSet, DESCRIPTOR_CHARACTER_SET_BP);
			UdfHelper.EncodeOstaCompressedUnicode(this._LogicalVolumeIdentifier, buffer.ExtractSegment((int)LOGICAL_VOLUME_IDENTIFIER_BP, 128), true);
			buffer.Write(this._LogicalBlockSize, LOGICAL_BLOCK_SIZE_BP);
			buffer.Write(this._DomainIdentifier, DOMAIN_IDENTIFIER_BP);
			buffer.Write(this._FileSetDescriptorExtent, FILE_SET_DESCRIPTOR_EXTENT_BP);
			buffer.Write(this._MapTableLength, MAP_TABLE_LENGTH_BP);
			buffer.Write(this._PartitionMapCount, PARTITION_MAP_COUNT_BP);
			buffer.Write(this._ImplementationIdentifier, IMPLEMENTATION_IDENTIFIER_BP);
			if (this._ImplementationUse.Length > 128) { throw new OverflowException("Field is too large."); }
			buffer.CopyFrom((int)IMPLEMENTATION_USE_BP, this._ImplementationUse, 0, this._ImplementationUse.Length);
			buffer.Write(this._IntegritySequenceExtent, INTEGRITY_SEQUENCE_EXTENT_BP);
			var partitionMapBuffer = buffer.ExtractSegment(PARTITION_MAPS_BP);
			for (uint i = 0; i < this._PartitionMapCount; i++)
			{
				Marshaler.StructureToPtr(this._PartitionMaps[i], partitionMapBuffer.ExtractSegment(0, this._PartitionMaps[i].Length));
				partitionMapBuffer = partitionMapBuffer.ExtractSegment(this._PartitionMaps[i].Length);
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected override int MarshaledSize { get { return (int)PARTITION_MAPS_BP + (int)this._MapTableLength; } }

		public override object Clone()
		{
			var me = (LogicalVolumeDescriptor)base.Clone();
			me._ImplementationUse = (byte[])me._ImplementationUse.Clone();
			me._PartitionMaps = (PartitionMap[])me._PartitionMaps.Clone();
			for (int i = 0; i < me._PartitionMaps.Length; i++)
			{ me._PartitionMaps[i] = (PartitionMap)me._PartitionMaps[i].Clone(); }
			return me;
		}
	}
}