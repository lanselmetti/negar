using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace FileSystems.Udf
{
	[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
	public class ExtendedFileEntryInformationControlBlockDescriptor : FileEntryInformationControlBlockDescriptorBase
	{
		#region Offsets
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr USER_IDENTIFIER_BP = (IntPtr)36; //Marshal.OffsetOf(typeof(ExtendedFileEntryInformationControlBlockDescriptor), "_UserIdentifier");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr GROUP_IDENTIFIER_BP = (IntPtr)40; //Marshal.OffsetOf(typeof(ExtendedFileEntryInformationControlBlockDescriptor), "_GroupIdentifier");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr PERMISSIONS_BP = (IntPtr)44; //Marshal.OffsetOf(typeof(ExtendedFileEntryInformationControlBlockDescriptor), "_Permissions");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr FILE_LINK_COUNT_BP = (IntPtr)48; //Marshal.OffsetOf(typeof(ExtendedFileEntryInformationControlBlockDescriptor), "_FileLinkCount");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr RECORD_FORMAT_BP = (IntPtr)50; //Marshal.OffsetOf(typeof(ExtendedFileEntryInformationControlBlockDescriptor), "_RecordFormat");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr RECORD_DISPLAY_ATTRIBUTES_BP = (IntPtr)51; //Marshal.OffsetOf(typeof(ExtendedFileEntryInformationControlBlockDescriptor), "_RecordDisplayAttributes");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr RECORD_LENGTH_BP = (IntPtr)52; //Marshal.OffsetOf(typeof(ExtendedFileEntryInformationControlBlockDescriptor), "_RecordLength");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr INFORMATION_LENGTH_BP = (IntPtr)56; //Marshal.OffsetOf(typeof(ExtendedFileEntryInformationControlBlockDescriptor), "_InformationLength");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr OBJECT_SIZE_BP = (IntPtr)64; //Marshal.OffsetOf(typeof(ExtendedFileEntryInformationControlBlockDescriptor), "_ObjectSize");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr LOGICAL_BLOCKS_RECORDED_BP = (IntPtr)72; //Marshal.OffsetOf(typeof(ExtendedFileEntryInformationControlBlockDescriptor), "_LogicalBlocksRecorded");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr ACCESS_TIME_BP = (IntPtr)80; //Marshal.OffsetOf(typeof(ExtendedFileEntryInformationControlBlockDescriptor), "_AccessTime");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr MODIFICATION_TIME_BP = (IntPtr)92; //Marshal.OffsetOf(typeof(ExtendedFileEntryInformationControlBlockDescriptor), "_ModificationTime");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr CREATION_TIME_BP = (IntPtr)104; //Marshal.OffsetOf(typeof(ExtendedFileEntryInformationControlBlockDescriptor), "_CreationTime");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr ATTRIBUTE_TIME_BP = (IntPtr)116; //Marshal.OffsetOf(typeof(ExtendedFileEntryInformationControlBlockDescriptor), "_AttributeTime");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr CHECKPOINT_BP = (IntPtr)128; //Marshal.OffsetOf(typeof(ExtendedFileEntryInformationControlBlockDescriptor), "_Checkpoint");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr RESERVED_BP = (IntPtr)132; //Marshal.OffsetOf(typeof(ExtendedFileEntryInformationControlBlockDescriptor), "_Reserved");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr EXTENDED_ATTRIBUTE_ICB_BP = (IntPtr)136; //Marshal.OffsetOf(typeof(ExtendedFileEntryInformationControlBlockDescriptor), "_ExtendedAttributeICB");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr STREAM_DIRECTORY_ICB_BP = (IntPtr)152; //Marshal.OffsetOf(typeof(ExtendedFileEntryInformationControlBlockDescriptor), "_StreamDirectoryICB");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr IMPLEMENTATION_IDENTIFIER_BP = (IntPtr)168; //Marshal.OffsetOf(typeof(ExtendedFileEntryInformationControlBlockDescriptor), "_ImplementationIdentifier");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr UNIQUE_IDENTIFIER_BP = (IntPtr)200; //Marshal.OffsetOf(typeof(ExtendedFileEntryInformationControlBlockDescriptor), "_UniqueIdentifier");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr EXTENDED_ATTRIBUTES_LENGTH_BP = (IntPtr)208; //Marshal.OffsetOf(typeof(ExtendedFileEntryInformationControlBlockDescriptor), "_ExtendedAttributesLength");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr ALLOCATION_DESCRIPTORS_LENGTH_BP = (IntPtr)212; //Marshal.OffsetOf(typeof(ExtendedFileEntryInformationControlBlockDescriptor), "_AllocationDescriptorsLength");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr EXTENDED_ATTRIBUTES_BP = (IntPtr)216; //Marshal.OffsetOf(typeof(ExtendedFileEntryInformationControlBlockDescriptor), "_ExtendedAttributes");
		#endregion

		private ExtendedFileEntryInformationControlBlockDescriptor() : this(IcbFileType.None) { this._AccessTime = this._AttributeTime = this._ModificationTime = this._CreationTime = (Timestamp)DateTime.Now; }
		public ExtendedFileEntryInformationControlBlockDescriptor(IcbFileType type) : base(DescriptorTagIdentifier.ExtendedFileEntry, type) { }

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private uint _UserIdentifier;
		public override uint UserIdentifier { get { return this._UserIdentifier; } set { this._UserIdentifier = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private uint _GroupIdentifier;
		public override uint GroupIdentifier { get { return this._GroupIdentifier; } set { this._GroupIdentifier = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private UdfFilePermissions _Permissions;
		public override UdfFilePermissions Permissions { get { return this._Permissions; } set { this._Permissions = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ushort _FileLinkCount;
		public override ushort FileLinkCount { get { return this._FileLinkCount; } set { this._FileLinkCount = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private IcbRecordFormat _RecordFormat = IcbRecordFormat.None;
		public override IcbRecordFormat RecordFormat { get { return this._RecordFormat; } set { this._RecordFormat = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private IcbRecordDisplayCharacteristics _RecordDisplayAttributes = IcbRecordDisplayCharacteristics.None;
		public override IcbRecordDisplayCharacteristics RecordDisplayAttributes { get { return this._RecordDisplayAttributes; } set { this._RecordDisplayAttributes = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private uint _RecordLength = 0;
		public override uint RecordLength { get { return this._RecordLength; } set { this._RecordLength = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private long _InformationLength;
		public override long InformationLength { get { return this._InformationLength; } set { this._InformationLength = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private long _ObjectSize;
		public long ObjectSize { get { return this._ObjectSize; } set { this._ObjectSize = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private long _LogicalBlocksRecorded;
		public override long LogicalBlocksRecorded { get { return this._LogicalBlocksRecorded; } set { this._LogicalBlocksRecorded = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Timestamp _AccessTime; /*= (Timestamp)DateTime.Now*/ //This is set in the constructor
		public override Timestamp AccessTime { get { return this._AccessTime; } set { this._AccessTime = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Timestamp _ModificationTime; /*= (Timestamp)DateTime.Now*/ //This is set in the constructor
		public override Timestamp ModificationTime { get { return this._ModificationTime; } set { this._ModificationTime = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Timestamp _CreationTime;
		public Timestamp CreationTime { get { return this._CreationTime; } set { this._CreationTime = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Timestamp _AttributeTime; /*= (Timestamp)DateTime.Now*/ //This is set in the constructor
		public override Timestamp AttributeTime { get { return this._AttributeTime; } set { this._AttributeTime = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private uint _Checkpoint = 1;
		public override uint Checkpoint { get { return this._Checkpoint; } set { this._Checkpoint = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private uint _Reserved;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private LongAllocationDescriptor _ExtendedAttributeICB;
		public LongAllocationDescriptor ExtendedAttributeICB { get { return this._ExtendedAttributeICB; } set { this._ExtendedAttributeICB = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private LongAllocationDescriptor _StreamDirectoryICB;
		public LongAllocationDescriptor StreamDirectoryICB { get { return this._StreamDirectoryICB; } set { this._StreamDirectoryICB = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EntityIdentifier _ImplementationIdentifier;
		public override EntityIdentifier ImplementationIdentifier { get { return this._ImplementationIdentifier; } set { this._ImplementationIdentifier = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ulong _UniqueIdentifier = NewUId();
		private static ulong NewUId() { Guid guid = Guid.NewGuid(); unsafe { return *(ulong*)&guid; } }
		public override ulong UniqueIdentifier { get { return this._UniqueIdentifier; } set { this._UniqueIdentifier = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private uint _ExtendedAttributesLength;
		public uint ExtendedAttributesLength { get { return this._ExtendedAttributesLength; } private set { this._ExtendedAttributesLength = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private uint _AllocationDescriptorsLength;
		public uint AllocationDescriptorsLength { get { return this._AllocationDescriptorsLength; } private set { this._AllocationDescriptorsLength = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		private byte[] _ExtendedAttributes;
		public override byte[] ExtendedAttributes { get { return this._ExtendedAttributes; } set { this._ExtendedAttributes = value; this.ExtendedAttributesLength = (uint)value.Length * sizeof(byte); } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		private byte[] _AllocationDescriptors;
		public override byte[] AllocationDescriptors { get { return this._AllocationDescriptors; } set { this._AllocationDescriptors = value; this.AllocationDescriptorsLength = (uint)value.Length * sizeof(byte); } }

		protected override void MarshalFromBeforeValidate(BufferWithSize buffer)
		{
			base.MarshalFromBeforeValidate(buffer);

			this._UserIdentifier = buffer.Read<uint>(USER_IDENTIFIER_BP);
			this._GroupIdentifier = buffer.Read<uint>(GROUP_IDENTIFIER_BP);
			this._Permissions = buffer.Read<UdfFilePermissions>(PERMISSIONS_BP);
			this._FileLinkCount = buffer.Read<ushort>(FILE_LINK_COUNT_BP);
			this._RecordFormat = buffer.Read<IcbRecordFormat>(RECORD_FORMAT_BP);
			this._RecordDisplayAttributes = buffer.Read<IcbRecordDisplayCharacteristics>(RECORD_DISPLAY_ATTRIBUTES_BP);
			this._RecordLength = buffer.Read<uint>(RECORD_LENGTH_BP);
			this._InformationLength = buffer.Read<long>(INFORMATION_LENGTH_BP);
			this._ObjectSize = buffer.Read<long>(OBJECT_SIZE_BP);
			this._LogicalBlocksRecorded = buffer.Read<long>(LOGICAL_BLOCKS_RECORDED_BP);
			this._AccessTime = buffer.Read<Timestamp>(ACCESS_TIME_BP);
			this._ModificationTime = buffer.Read<Timestamp>(MODIFICATION_TIME_BP);
			this._CreationTime = buffer.Read<Timestamp>(CREATION_TIME_BP);
			this._AttributeTime = buffer.Read<Timestamp>(ATTRIBUTE_TIME_BP);
			this._Checkpoint = buffer.Read<uint>(CHECKPOINT_BP);
			this._Reserved = buffer.Read<uint>(RESERVED_BP);
			this._ExtendedAttributeICB = buffer.Read<LongAllocationDescriptor>(EXTENDED_ATTRIBUTE_ICB_BP);
			this._StreamDirectoryICB = buffer.Read<LongAllocationDescriptor>(STREAM_DIRECTORY_ICB_BP);
			this._ImplementationIdentifier = buffer.Read<EntityIdentifier>(IMPLEMENTATION_IDENTIFIER_BP);
			this._UniqueIdentifier = buffer.Read<ulong>(UNIQUE_IDENTIFIER_BP);
			this._ExtendedAttributesLength = buffer.Read<uint>(EXTENDED_ATTRIBUTES_LENGTH_BP);
			this._AllocationDescriptorsLength = buffer.Read<uint>(ALLOCATION_DESCRIPTORS_LENGTH_BP);
			this._ExtendedAttributes = new byte[this._ExtendedAttributesLength];
			buffer.CopyTo((int)EXTENDED_ATTRIBUTES_BP, this._ExtendedAttributes, 0, this._ExtendedAttributes.Length);
			this._AllocationDescriptors = new byte[this._AllocationDescriptorsLength];
			buffer.CopyTo((int)EXTENDED_ATTRIBUTES_BP + this._ExtendedAttributesLength, this._AllocationDescriptors, 0, this._AllocationDescriptors.Length);
		}

		protected override void MarshalToBeforeValidate(BufferWithSize buffer)
		{
			buffer.Write(this._UserIdentifier, USER_IDENTIFIER_BP);
			buffer.Write(this._GroupIdentifier, GROUP_IDENTIFIER_BP);
			buffer.Write(this._Permissions, PERMISSIONS_BP);
			buffer.Write(this._FileLinkCount, FILE_LINK_COUNT_BP);
			buffer.Write(this._RecordFormat, RECORD_FORMAT_BP);
			buffer.Write(this._RecordDisplayAttributes, RECORD_DISPLAY_ATTRIBUTES_BP);
			buffer.Write(this._RecordLength, RECORD_LENGTH_BP);
			buffer.Write(this._InformationLength, INFORMATION_LENGTH_BP);
			buffer.Write(this._ObjectSize, OBJECT_SIZE_BP);
			buffer.Write(this._LogicalBlocksRecorded, LOGICAL_BLOCKS_RECORDED_BP);
			buffer.Write(this._AccessTime, ACCESS_TIME_BP);
			buffer.Write(this._ModificationTime, MODIFICATION_TIME_BP);
			buffer.Write(this._CreationTime, CREATION_TIME_BP);
			buffer.Write(this._AttributeTime, ATTRIBUTE_TIME_BP);
			buffer.Write(this._Checkpoint, CHECKPOINT_BP);
			buffer.Write(this._Reserved, RESERVED_BP);
			buffer.Write(this._ExtendedAttributeICB, EXTENDED_ATTRIBUTE_ICB_BP);
			buffer.Write(this._StreamDirectoryICB, STREAM_DIRECTORY_ICB_BP);
			buffer.Write(this._ImplementationIdentifier, IMPLEMENTATION_IDENTIFIER_BP);
			buffer.Write(this._UniqueIdentifier, UNIQUE_IDENTIFIER_BP);
			buffer.Write(this._ExtendedAttributesLength, EXTENDED_ATTRIBUTES_LENGTH_BP);
			buffer.Write(this._AllocationDescriptorsLength, ALLOCATION_DESCRIPTORS_LENGTH_BP);
			buffer.CopyFrom((int)EXTENDED_ATTRIBUTES_BP, this._ExtendedAttributes, 0, this._ExtendedAttributes.Length);
			buffer.CopyFrom((int)EXTENDED_ATTRIBUTES_BP + this._ExtendedAttributesLength, this._AllocationDescriptors, 0, this._AllocationDescriptors.Length);
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected override int MarshaledSize { get { return (int)EXTENDED_ATTRIBUTES_BP + (int)this._ExtendedAttributesLength + (int)this._AllocationDescriptorsLength; } }
	}
}