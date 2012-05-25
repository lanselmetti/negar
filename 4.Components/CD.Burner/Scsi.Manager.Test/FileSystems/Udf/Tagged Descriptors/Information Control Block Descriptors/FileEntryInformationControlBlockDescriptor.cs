using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace FileSystems.Udf
{
	[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
	public class FileEntryInformationControlBlockDescriptor : FileEntryInformationControlBlockDescriptorBase
	{
		#region Offsets
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr USER_IDENTIFIER_BP = (IntPtr)36; //Marshal.OffsetOf(typeof(FileEntryInformationControlBlockDescriptor), "_UserIdentifier");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr GROUP_IDENTIFIER_BP = (IntPtr)40; //Marshal.OffsetOf(typeof(FileEntryInformationControlBlockDescriptor), "_GroupIdentifier");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr PERMISSIONS_BP = (IntPtr)44; //Marshal.OffsetOf(typeof(FileEntryInformationControlBlockDescriptor), "_Permissions");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr FILE_LINK_COUNT_BP = (IntPtr)48; //Marshal.OffsetOf(typeof(FileEntryInformationControlBlockDescriptor), "_FileLinkCount");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr RECORD_FORMAT_BP = (IntPtr)50; //Marshal.OffsetOf(typeof(FileEntryInformationControlBlockDescriptor), "_RecordFormat");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr RECORD_DISPLAY_ATTRIBUTES_BP = (IntPtr)51; //Marshal.OffsetOf(typeof(FileEntryInformationControlBlockDescriptor), "_RecordDisplayAttributes");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr RECORD_LENGTH_BP = (IntPtr)52; //Marshal.OffsetOf(typeof(FileEntryInformationControlBlockDescriptor), "_RecordLength");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr INFORMATION_LENGTH_BP = (IntPtr)56; //Marshal.OffsetOf(typeof(FileEntryInformationControlBlockDescriptor), "_InformationLength");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr LOGICAL_BLOCKS_RECORDED_BP = (IntPtr)64; //Marshal.OffsetOf(typeof(FileEntryInformationControlBlockDescriptor), "_LogicalBlocksRecorded");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr ACCESS_TIME_BP = (IntPtr)72; //Marshal.OffsetOf(typeof(FileEntryInformationControlBlockDescriptor), "_AccessTime");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr MODIFICATION_TIME_BP = (IntPtr)84; //Marshal.OffsetOf(typeof(FileEntryInformationControlBlockDescriptor), "_ModificationTime");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr ATTRIBUTE_TIME_BP = (IntPtr)96; //Marshal.OffsetOf(typeof(FileEntryInformationControlBlockDescriptor), "_AttributeTime");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr CHECKPOINT_BP = (IntPtr)108; //Marshal.OffsetOf(typeof(FileEntryInformationControlBlockDescriptor), "_Checkpoint");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr EXTENDED_ATTRIBUTE_ICB_BP = (IntPtr)112; //Marshal.OffsetOf(typeof(FileEntryInformationControlBlockDescriptor), "_ExtendedAttributeIcb");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr IMPLEMENTATION_IDENTIFIER_BP = (IntPtr)128; //Marshal.OffsetOf(typeof(FileEntryInformationControlBlockDescriptor), "_ImplementationIdentifier");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr UNIQUE_IDENTIFIER_BP = (IntPtr)160; //Marshal.OffsetOf(typeof(FileEntryInformationControlBlockDescriptor), "_UniqueIdentifier");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr EXTENDED_ATTRIBUTES_LENGTH_BP = (IntPtr)168; //Marshal.OffsetOf(typeof(FileEntryInformationControlBlockDescriptor), "_ExtendedAttributesLength");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr ALLOCATION_DESCRIPTORS_LENGTH_BP = (IntPtr)172; //Marshal.OffsetOf(typeof(FileEntryInformationControlBlockDescriptor), "_AllocationDescriptorsLength");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr EXTENDED_ATTRIBUTES_BP = (IntPtr)176; //Marshal.OffsetOf(typeof(FileEntryInformationControlBlockDescriptor), "_ExtendedAttributes");
		#endregion

		private FileEntryInformationControlBlockDescriptor() : this(IcbFileType.None) { this._AccessTime = this._AttributeTime = this._ModificationTime = (Timestamp)DateTime.Now; }
		public FileEntryInformationControlBlockDescriptor(IcbFileType type) : base(DescriptorTagIdentifier.FileEntry, type) { }

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private uint _UserIdentifier = ~0U;
		/// <summary>The user ID of the owner of the file.</summary>
		/// <remarks>Originating systems that do not support the notion of user IDs will probably use an arbitrary user ID (and group ID). For various historical reasons, it is recommended such systems do not choose <c>0</c> for these IDs.</remarks>
		public override uint UserIdentifier { get { return this._UserIdentifier; } set { this._UserIdentifier = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private uint _GroupIdentifier = ~0U;
		/// <summary>The group ID of the owner of the file.</summary>
		public override uint GroupIdentifier { get { return this._GroupIdentifier; } set { this._GroupIdentifier = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private UdfFilePermissions _Permissions;
		/// <summary>The access allowed to the current file for certain classes of users.</summary>
		public override UdfFilePermissions Permissions { get { return this._Permissions; } set { this._Permissions = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ushort _FileLinkCount;
		/// <summary>The number of <see cref="FileIdentifierDescriptor"/>s identifying this ICB.</summary>
		public override ushort FileLinkCount { get { return this._FileLinkCount; } set { this._FileLinkCount = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private IcbRecordFormat _RecordFormat = IcbRecordFormat.None;
		/// <summary>Identifies the format of the information in the file.</summary>
		public override IcbRecordFormat RecordFormat { get { return this._RecordFormat; } set { this._RecordFormat = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private IcbRecordDisplayCharacteristics _RecordDisplayAttributes = IcbRecordDisplayCharacteristics.None;
		/// <summary>The intended display attributes of the records in a file.</summary>
		public override IcbRecordDisplayCharacteristics RecordDisplayAttributes { get { return this._RecordDisplayAttributes; } set { this._RecordDisplayAttributes = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private uint _RecordLength = 0;
		/// <summary>
		/// <para>If the <see cref="RecordFormat"/> field contains the number <see cref="IcbRecordFormat.None"/>, the interpretation of the <see cref="RecordLength"/> field is subject to agreement between the originator and recipient of the medium.</para>
		/// <para>If the <see cref="RecordFormat"/> field contains either <see cref="IcbRecordFormat.PaddedFixedLength"/> or <see cref="IcbRecordFormat.FixedLength"/>, the <see cref="RecordLength"/> field shall specify the length, in bytes, of each record in the file.</para>
		/// <para>If the <see cref="RecordFormat"/> field contains another number, the <see cref="RecordLength"/> field shall specify the maximum length, in bytes, of a record that may be recorded in the file.</para>
		/// </summary>
		public override uint RecordLength { get { return this._RecordLength; } set { this._RecordLength = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private long _InformationLength;
		/// <summary>The file size, in bytes. This is be equal to the sum of the Information Lengths of the allocation descriptors for the body of the file.</summary>
		/// <remarks>This is not necessarily the number of recorded bytes; there may be unrecorded extents.</remarks>
		public override long InformationLength { get { return this._InformationLength; } set { this._InformationLength = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private long _LogicalBlocksRecorded;
		/// <summary>The number of recorded logical blocks specified by the allocation descriptors for the body of the file.</summary>
		public override long LogicalBlocksRecorded { get { return this._LogicalBlocksRecorded; } set { this._LogicalBlocksRecorded = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Timestamp _AccessTime; /*= (Timestamp)DateTime.Now*/ //This is set in the constructor
		/// <summary>The most recent date and time of the day of file creation or read access to the file prior to recording this file entry.</summary>
		public override Timestamp AccessTime { get { return this._AccessTime; } set { this._AccessTime = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Timestamp _ModificationTime; /*= (Timestamp)DateTime.Now*/ //This is set in the constructor
		/// <summary>The most recent date and time of the day of file creation or write access to the file.</summary>
		public override Timestamp ModificationTime { get { return this._ModificationTime; } set { this._ModificationTime = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Timestamp _AttributeTime; /*= (Timestamp)DateTime.Now*/ //This is set in the constructor
		/// <summary>The most recent date and time of the day of file creation or modification of the attributes of the file.</summary>
		public override Timestamp AttributeTime { get { return this._AttributeTime; } set { this._AttributeTime = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private uint _Checkpoint = 1;
		/// <summary>This field contains <c>1</c> for the first instance of a file and is incremented by one when directed to do so by the user.</summary>
		public override uint Checkpoint { get { return this._Checkpoint; } set { this._Checkpoint = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private LongAllocationDescriptor _ExtendedAttributeIcb;
		/// <summary>The ICB describing the extended attribute file for the file. If the extent's length is <c>0</c>, no such ICB is specified.</summary>
		public LongAllocationDescriptor ExtendedAttributeIcb { get { return this._ExtendedAttributeIcb; } set { this._ExtendedAttributeIcb = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EntityIdentifier _ImplementationIdentifier;
		public override EntityIdentifier ImplementationIdentifier { get { return this._ImplementationIdentifier; } set { this._ImplementationIdentifier = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ulong _UniqueIdentifier = 16;
		/// <summary>A numeric identifier for this file. All file entries with the same contents of this field must describe the same file or directory.</summary>
		public override ulong UniqueIdentifier { get { return this._UniqueIdentifier; } set { this._UniqueIdentifier = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private uint _ExtendedAttributesLength;
		/// <summary>The length, in bytes, of the <see cref="ExtendedAttributes"/> field; it must be an integral multiple of <c>4</c>.</summary>
		public uint ExtendedAttributesLength { get { return this._ExtendedAttributesLength; } private set { this._ExtendedAttributesLength = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private uint _AllocationDescriptorsLength;
		/// <summary>This field shall specify the length, in bytes, of the <see cref="AllocationDescriptors"/> field.</summary>
		public uint AllocationDescriptorsLength { get { return this._AllocationDescriptorsLength; } private set { this._AllocationDescriptorsLength = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		private byte[] _ExtendedAttributes = EMPTY_BYTES;
		public override byte[] ExtendedAttributes { get { return this._ExtendedAttributes; } set { this._ExtendedAttributes = value; this.ExtendedAttributesLength = (uint)value.Length * sizeof(byte); } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		private byte[] _AllocationDescriptors = EMPTY_BYTES;
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
			this._LogicalBlocksRecorded = buffer.Read<long>(LOGICAL_BLOCKS_RECORDED_BP);
			this._AccessTime = buffer.Read<Timestamp>(ACCESS_TIME_BP);
			this._ModificationTime = buffer.Read<Timestamp>(MODIFICATION_TIME_BP);
			this._AttributeTime = buffer.Read<Timestamp>(ATTRIBUTE_TIME_BP);
			this._Checkpoint = buffer.Read<uint>(CHECKPOINT_BP);
			this._ExtendedAttributeIcb = buffer.Read<LongAllocationDescriptor>(EXTENDED_ATTRIBUTE_ICB_BP);
			this._ImplementationIdentifier = buffer.Read<EntityIdentifier>(IMPLEMENTATION_IDENTIFIER_BP);
			this._UniqueIdentifier = buffer.Read<ulong>(UNIQUE_IDENTIFIER_BP);
			this._ExtendedAttributesLength = buffer.Read<uint>(EXTENDED_ATTRIBUTES_LENGTH_BP);
			this._AllocationDescriptorsLength = buffer.Read<uint>(ALLOCATION_DESCRIPTORS_LENGTH_BP);
			this._ExtendedAttributes = new byte[this._ExtendedAttributesLength];
			buffer.CopyTo((int)EXTENDED_ATTRIBUTES_BP, this._ExtendedAttributes, 0, this._ExtendedAttributesLength);
			this._AllocationDescriptors = new byte[this._AllocationDescriptorsLength];
			buffer.CopyTo((int)EXTENDED_ATTRIBUTES_BP + this._ExtendedAttributesLength, this._AllocationDescriptors, 0, this._AllocationDescriptorsLength);
		}

		protected override void MarshalToBeforeValidate(BufferWithSize buffer)
		{
			base.MarshalToBeforeValidate(buffer);

			buffer.Write(this._UserIdentifier, USER_IDENTIFIER_BP);
			buffer.Write(this._GroupIdentifier, GROUP_IDENTIFIER_BP);
			buffer.Write(this._Permissions, PERMISSIONS_BP);
			buffer.Write(this._FileLinkCount, FILE_LINK_COUNT_BP);
			buffer.Write(this._RecordFormat, RECORD_FORMAT_BP);
			buffer.Write(this._RecordDisplayAttributes, RECORD_DISPLAY_ATTRIBUTES_BP);
			buffer.Write(this._RecordLength, RECORD_LENGTH_BP);
			buffer.Write(this._InformationLength, INFORMATION_LENGTH_BP);
			buffer.Write(this._LogicalBlocksRecorded, LOGICAL_BLOCKS_RECORDED_BP);
			buffer.Write(this._AccessTime, ACCESS_TIME_BP);
			buffer.Write(this._ModificationTime, MODIFICATION_TIME_BP);
			buffer.Write(this._AttributeTime, ATTRIBUTE_TIME_BP);
			buffer.Write(this._Checkpoint, CHECKPOINT_BP);
			buffer.Write(this._ExtendedAttributeIcb, EXTENDED_ATTRIBUTE_ICB_BP);
			buffer.Write(this._ImplementationIdentifier, IMPLEMENTATION_IDENTIFIER_BP);
			buffer.Write(this._UniqueIdentifier, UNIQUE_IDENTIFIER_BP);
			buffer.Write(this._ExtendedAttributesLength, EXTENDED_ATTRIBUTES_LENGTH_BP);
			buffer.Write(this._AllocationDescriptorsLength, ALLOCATION_DESCRIPTORS_LENGTH_BP);
			buffer.CopyFrom((int)EXTENDED_ATTRIBUTES_BP, this._ExtendedAttributes, 0, this._ExtendedAttributesLength);
			buffer.CopyFrom((int)EXTENDED_ATTRIBUTES_BP + this._ExtendedAttributesLength, this._AllocationDescriptors, 0, this._AllocationDescriptorsLength);
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected override int MarshaledSize { get { return (int)EXTENDED_ATTRIBUTES_BP + (int)this._ExtendedAttributesLength + (int)this._AllocationDescriptorsLength; } }

		//public override string ToString() { return string.Format("{0} {{ Unique ID: 0x{1:X}, Information Length: 0x{2:X} }}", base.ToString(), this.UniqueIdentifier, this.InformationLength); }
	}
}