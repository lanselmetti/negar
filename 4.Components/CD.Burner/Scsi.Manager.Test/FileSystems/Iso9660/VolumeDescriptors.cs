using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using Helper;

namespace FileSystems.Iso9660
{
	[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
	public abstract class IsoVolumeDescriptor : VolumeStructureDescriptor
	{
		protected IsoVolumeDescriptor(VolumeDescriptorType type) : base((byte)type, "CD001", 1) { }

		public static IsoVolumeDescriptor FromBuffer(byte[] buffer, int bufferOffset) { unsafe { fixed (byte* pBuffer = &buffer[bufferOffset]) { return FromBuffer(new BufferWithSize(pBuffer, buffer.Length - bufferOffset)); } } }

		public static IsoVolumeDescriptor FromBuffer(BufferWithSize buffer)
		{
			IsoVolumeDescriptor result;
			switch (buffer.Read<VolumeDescriptorType>())
			{
				case VolumeDescriptorType.BootRecord:
					result = Marshaler.PtrToStructure<BootRecord>(buffer);
					break;
				case VolumeDescriptorType.PrimaryVolumeDescriptor:
					result = Marshaler.PtrToStructure<PrimaryVolumeDescriptor>(buffer);
					break;
				case VolumeDescriptorType.SupplementaryVolumeDescriptor:
					result = Marshaler.PtrToStructure<SupplementaryVolumeDescriptor>(buffer);
					break;
				case VolumeDescriptorType.VolumePartitionDescriptor:
					result = Marshaler.PtrToStructure<VolumePartitionDescriptor>(buffer);
					break;
				case VolumeDescriptorType.Termination:
					result = Marshaler.PtrToStructure<VolumeSetDescriptorTerminator>(buffer);
					break;
				default:
					throw new NotSupportedException("Volume descriptor not supported.");
			}
			return result;
		}
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
	public class BootRecord : IsoVolumeDescriptor
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr BOOT_SYSTEM_IDENTIFIER_OFFSET = Marshal.OffsetOf(typeof(BootRecord), "_BootSystemIdentifier");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr BOOT_IDENTIFIER_OFFSET = Marshal.OffsetOf(typeof(BootRecord), "_BootIdentifier");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr BOOT_CODE_OFFSET = Marshal.OffsetOf(typeof(BootRecord), "_BootCode");

		public BootRecord() : base(VolumeDescriptorType.BootRecord) { }

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		private string _BootSystemIdentifier;
		public string BootSystemIdentifier { get { return this._BootSystemIdentifier; } set { if (value == null) { value = string.Empty; } this._BootSystemIdentifier = value.PadRight(32, ' '); } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		private string _BootIdentifier;
		public string BootIdentifier { get { return this._BootIdentifier; } set { if (value == null) { value = string.Empty; } this._BootIdentifier = value.PadRight(32, ' '); } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1977)]
		private byte[] _BootCode = new byte[1977];
		public byte[] BootCode { get { return this._BootCode; } }

		protected override void MarshalFrom(BufferWithSize buffer)
		{
			base.MarshalFrom(buffer);
			this._BootSystemIdentifier = buffer.ToStringAnsi((int)BOOT_SYSTEM_IDENTIFIER_OFFSET, 32).TrimEnd();
			this._BootIdentifier = buffer.ToStringAnsi((int)BOOT_IDENTIFIER_OFFSET, 32).TrimEnd();
			this._BootCode = new byte[1977];
			buffer.CopyTo((int)BOOT_CODE_OFFSET, this._BootCode, 0, this._BootCode.Length);
		}

		protected override void MarshalTo(BufferWithSize buffer)
		{
			base.MarshalTo(buffer);
			IsoHelper.StringToPtrAnsi(buffer.ExtractSegment(BOOT_SYSTEM_IDENTIFIER_OFFSET), this.BootSystemIdentifier, 32, ' ');
			IsoHelper.StringToPtrAnsi(buffer.ExtractSegment(BOOT_IDENTIFIER_OFFSET), this.BootIdentifier, 32, ' ');
			if (this._BootCode.Length > 1977) { throw new OverflowException("Field is too large."); }
			buffer.CopyFrom((int)BOOT_CODE_OFFSET, this._BootCode, 0, this._BootCode.Length);
			buffer.Initialize((int)BOOT_CODE_OFFSET + this._BootCode.Length, 1977 - this._BootCode.Length);
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected override int MarshaledSize { get { return Marshaler.DefaultSizeOf<BootRecord>(); } }
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
	public class VolumeSetDescriptorTerminator : IsoVolumeDescriptor
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr RESERVED_OFFSET = Marshal.OffsetOf(typeof(VolumeSetDescriptorTerminator), "_Reserved");

		public VolumeSetDescriptorTerminator() : base(VolumeDescriptorType.Termination) { }

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2040)]
		private byte[] _Reserved = new byte[2040];
		public byte[] Reserved { get { return this._Reserved; } }

		protected override void MarshalFrom(BufferWithSize buffer)
		{
			base.MarshalFrom(buffer);
			this._Reserved = new byte[2040];
			buffer.CopyTo((int)RESERVED_OFFSET, this._Reserved, 0, this._Reserved.Length);
		}

		protected override void MarshalTo(BufferWithSize buffer)
		{
			base.MarshalTo(buffer);
			if (this._Reserved.Length > 2040) { throw new OverflowException("Field is too large."); }
			buffer.CopyFrom((int)RESERVED_OFFSET, this._Reserved, 0, this._Reserved.Length);
			buffer.Initialize((int)RESERVED_OFFSET + this._Reserved.Length, 2040 - this._Reserved.Length);
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected override int MarshaledSize { get { return Marshaler.DefaultSizeOf<VolumeSetDescriptorTerminator>(); } }
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
	public abstract class PrimaryAndSupplementaryVolumeDescriptorBase : IsoVolumeDescriptor
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr UNUSED1_OFFSET = Marshal.OffsetOf(typeof(PrimaryAndSupplementaryVolumeDescriptorBase), "_Unused1");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr SYSTEM_IDENTIFIER_OFFSET = Marshal.OffsetOf(typeof(PrimaryAndSupplementaryVolumeDescriptorBase), "_SystemIdentifier");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr VOLUME_IDENTIFIER_OFFSET = Marshal.OffsetOf(typeof(PrimaryAndSupplementaryVolumeDescriptorBase), "_VolumeIdentifier");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr UNUSED2_OFFSET = Marshal.OffsetOf(typeof(PrimaryAndSupplementaryVolumeDescriptorBase), "_Unused2");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr VOLUME_SPACE_SIZE_OFFSET = Marshal.OffsetOf(typeof(PrimaryAndSupplementaryVolumeDescriptorBase), "_VolumeSpaceSize");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr UNUSED3_OFFSET = Marshal.OffsetOf(typeof(PrimaryAndSupplementaryVolumeDescriptorBase), "_Unused3");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr VOLUME_SET_SIZE_OFFSET = Marshal.OffsetOf(typeof(PrimaryAndSupplementaryVolumeDescriptorBase), "_VolumeSetSize");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr VOLUME_SEQUENCE_NUMBER_OFFSET = Marshal.OffsetOf(typeof(PrimaryAndSupplementaryVolumeDescriptorBase), "_VolumeSequenceNumber");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr LOGICAL_BLOCK_SIZE_OFFSET = Marshal.OffsetOf(typeof(PrimaryAndSupplementaryVolumeDescriptorBase), "_LogicalBlockSize");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr PATH_TABLE_SIZE_OFFSET = Marshal.OffsetOf(typeof(PrimaryAndSupplementaryVolumeDescriptorBase), "_PathTableSize");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr LITTLE_ENDIAN_PATH_TABLE_LOCATION_OFFSET = Marshal.OffsetOf(typeof(PrimaryAndSupplementaryVolumeDescriptorBase), "_LittleEndianPathTableLocation");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr OPTIONAL_LITTLE_ENDIAN_PATH_TABLE_LOCATION_OFFSET = Marshal.OffsetOf(typeof(PrimaryAndSupplementaryVolumeDescriptorBase), "_OptionalLittleEndianPathTableLocation");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr BIG_ENDIAN_PATH_TABLE_LOCATION_OFFSET = Marshal.OffsetOf(typeof(PrimaryAndSupplementaryVolumeDescriptorBase), "_BigEndianPathTableLocation");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr OPTIONAL_BIG_ENDIAN_PATH_TABLE_LOCATION_OFFSET = Marshal.OffsetOf(typeof(PrimaryAndSupplementaryVolumeDescriptorBase), "_OptionalBigEndianPathTableLocation");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr ROOT_DIRECTORY_RECORD_DATA_OFFSET = Marshal.OffsetOf(typeof(PrimaryAndSupplementaryVolumeDescriptorBase), "_RootDirectoryRecordData");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr VOLUME_SET_IDENTIFIER_OFFSET = Marshal.OffsetOf(typeof(PrimaryAndSupplementaryVolumeDescriptorBase), "_VolumeSetIdentifier");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr PUBLISHER_IDENTIFIER_OFFSET = Marshal.OffsetOf(typeof(PrimaryAndSupplementaryVolumeDescriptorBase), "_PublisherIdentifier");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr DATA_PREPARER_IDENTIFIER_OFFSET = Marshal.OffsetOf(typeof(PrimaryAndSupplementaryVolumeDescriptorBase), "_DataPreparerIdentifier");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr APPLICATION_IDENTIFIER_OFFSET = Marshal.OffsetOf(typeof(PrimaryAndSupplementaryVolumeDescriptorBase), "_ApplicationIdentifier");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr COPYRIGHT_FILE_IDENTIFIER_OFFSET = Marshal.OffsetOf(typeof(PrimaryAndSupplementaryVolumeDescriptorBase), "_CopyrightFileIdentifier");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr ABSTRACT_FILE_IDENTIFIER_OFFSET = Marshal.OffsetOf(typeof(PrimaryAndSupplementaryVolumeDescriptorBase), "_AbstractFileIdentifier");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr BIBLIOGRAPHIC_FILE_IDENTIFIER_OFFSET = Marshal.OffsetOf(typeof(PrimaryAndSupplementaryVolumeDescriptorBase), "_BibliographicFileIdentifier");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr VOLUME_CREATION_TIME_OFFSET = Marshal.OffsetOf(typeof(PrimaryAndSupplementaryVolumeDescriptorBase), "_VolumeCreationTime");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr VOLUME_MODIFICATION_TIME_OFFSET = Marshal.OffsetOf(typeof(PrimaryAndSupplementaryVolumeDescriptorBase), "_VolumeModificationTime");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr VOLUME_EXPIRATION_TIME_OFFSET = Marshal.OffsetOf(typeof(PrimaryAndSupplementaryVolumeDescriptorBase), "_VolumeExpirationTime");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr VOLUME_EFFECTIVE_TIME_OFFSET = Marshal.OffsetOf(typeof(PrimaryAndSupplementaryVolumeDescriptorBase), "_VolumeEffectiveTime");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr FILE_STRUCTURE_VERSION_OFFSET = Marshal.OffsetOf(typeof(PrimaryAndSupplementaryVolumeDescriptorBase), "_FileStructureVersion");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr UNUSED4_OFFSET = Marshal.OffsetOf(typeof(PrimaryAndSupplementaryVolumeDescriptorBase), "_Unused4");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr APPLICATION_USE_OFFSET = Marshal.OffsetOf(typeof(PrimaryAndSupplementaryVolumeDescriptorBase), "_ApplicationUse");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr RESERVED_OFFSET = Marshal.OffsetOf(typeof(PrimaryAndSupplementaryVolumeDescriptorBase), "_Reserved");

		protected PrimaryAndSupplementaryVolumeDescriptorBase(VolumeDescriptorType type) : base(type) { }

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected byte _Unused1;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		private string _SystemIdentifier;
		public string SystemIdentifier { get { return this._SystemIdentifier; } set { if (value == null) { value = string.Empty; } this._SystemIdentifier = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		private string _VolumeIdentifier;
		public string VolumeIdentifier { get { return this._VolumeIdentifier; } set { if (value == null) { value = string.Empty; } this._VolumeIdentifier = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ulong _Unused2;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ulong _VolumeSpaceSize;
		/// <summary>The number of blocks in the volume space of the volume.</summary>
		public uint VolumeSpaceSize { get { return IsoHelper.FromBothByteOrder(this._VolumeSpaceSize); } set { this._VolumeSpaceSize = IsoHelper.ToBothByteOrder(value); } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
		protected byte[] _Unused3;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private uint _VolumeSetSize;
		public ushort VolumeSetSize { get { return IsoHelper.FromBothByteOrder(this._VolumeSetSize); } set { this._VolumeSetSize = IsoHelper.ToBothByteOrder(value); } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private uint _VolumeSequenceNumber;
		public ushort VolumeSequenceNumber { get { return IsoHelper.FromBothByteOrder(this._VolumeSequenceNumber); } set { this._VolumeSequenceNumber = IsoHelper.ToBothByteOrder(value); } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private uint _LogicalBlockSize;
		public ushort LogicalBlockSize { get { return IsoHelper.FromBothByteOrder(this._LogicalBlockSize); } set { this._LogicalBlockSize = IsoHelper.ToBothByteOrder(value); } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ulong _PathTableSize;
		public uint PathTableSize { get { return IsoHelper.FromBothByteOrder(this._PathTableSize); } set { this._PathTableSize = IsoHelper.ToBothByteOrder(value); } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private uint _LittleEndianPathTableLocation;
		public uint LittleEndianPathTableLocation { get { return this._LittleEndianPathTableLocation; } set { this._LittleEndianPathTableLocation = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private uint _OptionalLittleEndianPathTableLocation;
		public uint OptionalLittleEndianPathTableLocation { get { return this._OptionalLittleEndianPathTableLocation; } set { this._OptionalLittleEndianPathTableLocation = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private uint _BigEndianPathTableLocation;
		public uint BigEndianPathTableLocation { get { return Bits.BigEndian(this._BigEndianPathTableLocation); } set { this._BigEndianPathTableLocation = Bits.BigEndian(value); } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private uint _OptionalBigEndianPathTableLocation;
		public uint OptionalBigEndianPathTableLocation { get { return Bits.BigEndian(this._OptionalBigEndianPathTableLocation); } set { this._OptionalBigEndianPathTableLocation = Bits.BigEndian(value); } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 34)]
		private byte[] _RootDirectoryRecordData = new byte[34];
		public byte[] RootDirectoryRecordData { get { return this._RootDirectoryRecordData; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
		private string _VolumeSetIdentifier;
		public string VolumeSetIdentifier { get { return this._VolumeSetIdentifier; } set { if (value == null) { value = string.Empty; } this._VolumeSetIdentifier = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
		private string _PublisherIdentifier;
		public string PublisherIdentifier { get { return this._PublisherIdentifier; } set { if (value == null) { value = string.Empty; } this._PublisherIdentifier = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
		private string _DataPreparerIdentifier;
		public string DataPreparerIdentifier { get { return this._DataPreparerIdentifier; } set { if (value == null) { value = string.Empty; } this._DataPreparerIdentifier = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
		private string _ApplicationIdentifier;
		public string ApplicationIdentifier { get { return this._ApplicationIdentifier; } set { if (value == null) { value = string.Empty; } this._ApplicationIdentifier = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private FileIdentifier37Bytes _CopyrightFileIdentifier;
		public FileSystemIdentifier CopyrightFileIdentifier { get { return this._CopyrightFileIdentifier.Identifier; } set { this._CopyrightFileIdentifier = new FileIdentifier37Bytes(value); } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private FileIdentifier37Bytes _AbstractFileIdentifier;
		public FileSystemIdentifier AbstractFileIdentifier { get { return this._AbstractFileIdentifier.Identifier; } set { this._AbstractFileIdentifier = new FileIdentifier37Bytes(value); } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private FileIdentifier37Bytes _BibliographicFileIdentifier;
		public FileSystemIdentifier BibliographicFileIdentifier { get { return this._BibliographicFileIdentifier.Identifier; } set { this._BibliographicFileIdentifier = new FileIdentifier37Bytes(value); } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private VolumeTime _VolumeCreationTime = (VolumeTime)DateTime.Now;
		public DateTime? VolumeCreationTime { get { return this._VolumeCreationTime.IsEmpty ? (DateTime?)null : (DateTime)this._VolumeCreationTime; } set { this._VolumeCreationTime = (VolumeTime)value.GetValueOrDefault(default(DateTime)); } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private VolumeTime _VolumeModificationTime = (VolumeTime)DateTime.Now;
		public DateTime? VolumeModificationTime { get { return this._VolumeModificationTime.IsEmpty ? (DateTime?)null : (DateTime)this._VolumeModificationTime; } set { this._VolumeModificationTime = (VolumeTime)value.GetValueOrDefault(default(DateTime)); } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private VolumeTime _VolumeExpirationTime = (VolumeTime)DateTime.Now;
		public DateTime? VolumeExpirationTime { get { return this._VolumeExpirationTime.IsEmpty ? (DateTime?)null : (DateTime)this._VolumeExpirationTime; } set { this._VolumeExpirationTime = (VolumeTime)value.GetValueOrDefault(default(DateTime)); } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private VolumeTime _VolumeEffectiveTime = (VolumeTime)DateTime.Now;
		public DateTime? VolumeEffectiveTime { get { return this._VolumeEffectiveTime.IsEmpty ? (DateTime?)null : (DateTime)this._VolumeEffectiveTime; } set { this._VolumeEffectiveTime = (VolumeTime)value.GetValueOrDefault(default(DateTime)); } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private byte _FileStructureVersion = 1;
		public byte FileStructureVersion { get { return this._FileStructureVersion; } set { this._FileStructureVersion = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private byte _Unused4;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
		private byte[] _ApplicationUse = new byte[512];
		public byte[] ApplicationUse { get { return this._ApplicationUse; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2048 - 1395)]
		private byte[] _Reserved = new byte[2048 - 1395];


		protected override void MarshalFrom(BufferWithSize buffer)
		{
			base.MarshalFrom(buffer);
			this._Unused1 = buffer.Read<byte>(UNUSED1_OFFSET);
			this._SystemIdentifier = buffer.ToStringAnsi((int)SYSTEM_IDENTIFIER_OFFSET, 32).TrimEnd();
			this._VolumeIdentifier = buffer.ToStringAnsi((int)VOLUME_IDENTIFIER_OFFSET, 32).TrimEnd();
			this._Unused2 = buffer.Read<ulong>(UNUSED2_OFFSET);
			this._VolumeSpaceSize = buffer.Read<ulong>(VOLUME_SPACE_SIZE_OFFSET);
			this._Unused3 = new byte[32];
			buffer.CopyTo((int)UNUSED3_OFFSET, this._Unused3, 0, this._Unused3.Length);
			this._VolumeSetSize = buffer.Read<uint>(VOLUME_SET_SIZE_OFFSET);
			this._VolumeSequenceNumber = buffer.Read<uint>(VOLUME_SEQUENCE_NUMBER_OFFSET);
			this._LogicalBlockSize = buffer.Read<uint>(LOGICAL_BLOCK_SIZE_OFFSET);
			this._PathTableSize = buffer.Read<ulong>(PATH_TABLE_SIZE_OFFSET);
			this._LittleEndianPathTableLocation = buffer.Read<uint>(LITTLE_ENDIAN_PATH_TABLE_LOCATION_OFFSET);
			this._OptionalLittleEndianPathTableLocation = buffer.Read<uint>(OPTIONAL_LITTLE_ENDIAN_PATH_TABLE_LOCATION_OFFSET);
			this._BigEndianPathTableLocation = buffer.Read<uint>(BIG_ENDIAN_PATH_TABLE_LOCATION_OFFSET);
			this._OptionalBigEndianPathTableLocation = buffer.Read<uint>(OPTIONAL_BIG_ENDIAN_PATH_TABLE_LOCATION_OFFSET);
			this._RootDirectoryRecordData = new byte[34];
			buffer.CopyTo((int)ROOT_DIRECTORY_RECORD_DATA_OFFSET, this._RootDirectoryRecordData, 0, this._RootDirectoryRecordData.Length);
			this._VolumeSetIdentifier = buffer.ToStringAnsi((int)VOLUME_SET_IDENTIFIER_OFFSET, 128).TrimEnd();
			this._PublisherIdentifier = buffer.ToStringAnsi((int)PUBLISHER_IDENTIFIER_OFFSET, 128).TrimEnd();
			this._DataPreparerIdentifier = buffer.ToStringAnsi((int)DATA_PREPARER_IDENTIFIER_OFFSET, 128).TrimEnd();
			this._ApplicationIdentifier = buffer.ToStringAnsi((int)APPLICATION_IDENTIFIER_OFFSET, 128).TrimEnd();
			this._CopyrightFileIdentifier = new FileIdentifier37Bytes(Marshaler.PtrToStructure<FileSystemIdentifier>(buffer.ExtractSegment((int)COPYRIGHT_FILE_IDENTIFIER_OFFSET, 37)));
			this._AbstractFileIdentifier = new FileIdentifier37Bytes(Marshaler.PtrToStructure<FileSystemIdentifier>(buffer.ExtractSegment((int)ABSTRACT_FILE_IDENTIFIER_OFFSET, 37)));
			this._BibliographicFileIdentifier = new FileIdentifier37Bytes(Marshaler.PtrToStructure<FileSystemIdentifier>(buffer.ExtractSegment((int)BIBLIOGRAPHIC_FILE_IDENTIFIER_OFFSET, 37)));
			this._VolumeCreationTime = buffer.Read<VolumeTime>(VOLUME_CREATION_TIME_OFFSET);
			this._VolumeModificationTime = buffer.Read<VolumeTime>(VOLUME_MODIFICATION_TIME_OFFSET);
			this._VolumeExpirationTime = buffer.Read<VolumeTime>(VOLUME_EXPIRATION_TIME_OFFSET);
			this._VolumeEffectiveTime = buffer.Read<VolumeTime>(VOLUME_EFFECTIVE_TIME_OFFSET);
			this._FileStructureVersion = buffer.Read<byte>(FILE_STRUCTURE_VERSION_OFFSET);
			this._Unused4 = buffer.Read<byte>(UNUSED4_OFFSET);
			this._ApplicationUse = new byte[512];
			buffer.CopyTo((int)APPLICATION_USE_OFFSET, this._ApplicationUse, 0, this._ApplicationUse.Length);
			this._Reserved = new byte[653];
			buffer.CopyTo((int)RESERVED_OFFSET, this._Reserved, 0, this._Reserved.Length);
		}

		protected override void MarshalTo(BufferWithSize buffer)
		{
			base.MarshalTo(buffer);
			buffer.Write(this._Unused1, UNUSED1_OFFSET);
			IsoHelper.StringToPtrAnsi(buffer.ExtractSegment(SYSTEM_IDENTIFIER_OFFSET), this._SystemIdentifier, 32, ' ');
			IsoHelper.StringToPtrAnsi(buffer.ExtractSegment(VOLUME_IDENTIFIER_OFFSET), this._VolumeIdentifier, 32, ' ');
			buffer.Write(this._Unused2, UNUSED2_OFFSET);
			buffer.Write(this._VolumeSpaceSize, VOLUME_SPACE_SIZE_OFFSET);
			if (this._Unused3.Length > 32) { throw new OverflowException("Field is too large."); }
			buffer.CopyFrom((int)UNUSED3_OFFSET, this._Unused3, 0, this._Unused3.Length);
			buffer.Initialize((int)UNUSED3_OFFSET + this._Unused3.Length, 32 - this._Unused3.Length);
			buffer.Write(this._VolumeSetSize, VOLUME_SET_SIZE_OFFSET);
			buffer.Write(this._VolumeSequenceNumber, VOLUME_SEQUENCE_NUMBER_OFFSET);
			buffer.Write(this._LogicalBlockSize, LOGICAL_BLOCK_SIZE_OFFSET);
			buffer.Write(this._PathTableSize, PATH_TABLE_SIZE_OFFSET);
			buffer.Write(this._LittleEndianPathTableLocation, LITTLE_ENDIAN_PATH_TABLE_LOCATION_OFFSET);
			buffer.Write(this._OptionalLittleEndianPathTableLocation, OPTIONAL_LITTLE_ENDIAN_PATH_TABLE_LOCATION_OFFSET);
			buffer.Write(this._BigEndianPathTableLocation, BIG_ENDIAN_PATH_TABLE_LOCATION_OFFSET);
			buffer.Write(this._OptionalBigEndianPathTableLocation, OPTIONAL_BIG_ENDIAN_PATH_TABLE_LOCATION_OFFSET);
			if (this._RootDirectoryRecordData.Length > 34) { throw new OverflowException("Field is too large."); }
			buffer.CopyFrom((int)ROOT_DIRECTORY_RECORD_DATA_OFFSET, this._RootDirectoryRecordData, 0, this._RootDirectoryRecordData.Length);
			buffer.Initialize((int)ROOT_DIRECTORY_RECORD_DATA_OFFSET + this._RootDirectoryRecordData.Length, 34 - this._RootDirectoryRecordData.Length);
			IsoHelper.StringToPtrAnsi(buffer.ExtractSegment(VOLUME_SET_IDENTIFIER_OFFSET), this._VolumeSetIdentifier, 128, ' ');
			IsoHelper.StringToPtrAnsi(buffer.ExtractSegment(PUBLISHER_IDENTIFIER_OFFSET), this._PublisherIdentifier, 128, ' ');
			IsoHelper.StringToPtrAnsi(buffer.ExtractSegment(DATA_PREPARER_IDENTIFIER_OFFSET), this._DataPreparerIdentifier, 128, ' ');
			IsoHelper.StringToPtrAnsi(buffer.ExtractSegment(APPLICATION_IDENTIFIER_OFFSET), this._ApplicationIdentifier, 128, ' ');
			Marshaler.StructureToPtr(this._CopyrightFileIdentifier.Identifier, buffer.ExtractSegment((int)COPYRIGHT_FILE_IDENTIFIER_OFFSET, 37));
			Marshaler.StructureToPtr(this._AbstractFileIdentifier.Identifier, buffer.ExtractSegment((int)ABSTRACT_FILE_IDENTIFIER_OFFSET, 37));
			Marshaler.StructureToPtr(this._BibliographicFileIdentifier.Identifier, buffer.ExtractSegment((int)BIBLIOGRAPHIC_FILE_IDENTIFIER_OFFSET, 37));
			Marshaler.StructureToPtr(this._VolumeCreationTime, buffer.ExtractSegment((int)VOLUME_CREATION_TIME_OFFSET, 17));
			Marshaler.StructureToPtr(this._VolumeModificationTime, buffer.ExtractSegment((int)VOLUME_MODIFICATION_TIME_OFFSET, 17));
			Marshaler.StructureToPtr(this._VolumeExpirationTime, buffer.ExtractSegment((int)VOLUME_EXPIRATION_TIME_OFFSET, 17));
			Marshaler.StructureToPtr(this._VolumeEffectiveTime, buffer.ExtractSegment((int)VOLUME_EFFECTIVE_TIME_OFFSET, 17));
			buffer.Write(this._VolumeCreationTime, VOLUME_CREATION_TIME_OFFSET);
			buffer.Write(this._VolumeModificationTime, VOLUME_MODIFICATION_TIME_OFFSET);
			buffer.Write(this._VolumeExpirationTime, VOLUME_EXPIRATION_TIME_OFFSET);
			buffer.Write(this._VolumeEffectiveTime, VOLUME_EFFECTIVE_TIME_OFFSET);
			buffer.Write(this._FileStructureVersion, FILE_STRUCTURE_VERSION_OFFSET);
			buffer.Write(this._Unused4, UNUSED4_OFFSET);
			if (this._ApplicationUse.Length > 512) { throw new OverflowException("Field is too large."); }
			buffer.CopyFrom((int)APPLICATION_USE_OFFSET, this._ApplicationUse, 0, this._ApplicationUse.Length);
			buffer.Initialize((int)APPLICATION_USE_OFFSET + this._ApplicationUse.Length, 512 - this._ApplicationUse.Length);
			if (this._Reserved.Length > 653) { throw new OverflowException("Field is too large."); }
			buffer.CopyFrom((int)RESERVED_OFFSET, this._Reserved, 0, this._Reserved.Length);
			buffer.Initialize((int)RESERVED_OFFSET + this._Reserved.Length, 653 - this._Reserved.Length);
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected override int MarshaledSize { get { return Marshaler.DefaultSizeOf<PrimaryAndSupplementaryVolumeDescriptorBase>(); } }
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 37)]
	internal struct FileIdentifier37Bytes { public FileIdentifier37Bytes(FileSystemIdentifier id) { this.Identifier = id; } public readonly FileSystemIdentifier Identifier; }

	[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
	public sealed class PrimaryVolumeDescriptor : PrimaryAndSupplementaryVolumeDescriptorBase { public PrimaryVolumeDescriptor() : base(VolumeDescriptorType.PrimaryVolumeDescriptor) { } }

	[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
	public sealed class SupplementaryVolumeDescriptor : PrimaryAndSupplementaryVolumeDescriptorBase
	{
		public SupplementaryVolumeDescriptor() : base(VolumeDescriptorType.SupplementaryVolumeDescriptor) { }
		public SupplementaryVolumeDescriptorFlags Flags { get { return (SupplementaryVolumeDescriptorFlags)base._Unused1; } set { base._Unused1 = (byte)value; } }
		public byte[] EscapeSequences { get { return base._Unused3; } }
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
	public class VolumePartitionDescriptor : IsoVolumeDescriptor
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr UNUSED1_OFFSET = Marshal.OffsetOf(typeof(VolumePartitionDescriptor), "_Unused1");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr SYSTEM_IDENTIFIER_OFFSET = Marshal.OffsetOf(typeof(VolumePartitionDescriptor), "_SystemIdentifier");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr VOLUME_PARTITION_IDENTIFIER_OFFSET = Marshal.OffsetOf(typeof(VolumePartitionDescriptor), "_VolumePartitionIdentifier");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr VOLUME_PARTITION_LOGICAL_BLOCK_NUMBER_OFFSET = Marshal.OffsetOf(typeof(VolumePartitionDescriptor), "_VolumePartitionLogicalBlockNumber");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr VOLUME_PARTITION_SIZE_OFFSET = Marshal.OffsetOf(typeof(VolumePartitionDescriptor), "_VolumePartitionSize");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr RESERVED_OFFSET = Marshal.OffsetOf(typeof(VolumePartitionDescriptor), "_Reserved");

		public VolumePartitionDescriptor() : base(VolumeDescriptorType.VolumePartitionDescriptor) { }

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private byte _Unused1;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		private string _SystemIdentifier;
		public string SystemIdentifier { get { return this._SystemIdentifier; } private set { if (value == null) { value = string.Empty; } this._SystemIdentifier = value.PadRight(5, ' '); } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		private string _VolumePartitionIdentifier;
		public string VolumePartitionIdentifier { get { return this._VolumePartitionIdentifier; } set { if (value == null) { value = string.Empty; } this._VolumePartitionIdentifier = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ulong _VolumePartitionLogicalBlockNumber;
		public uint VolumePartitionLogicalBlockNumber { get { return IsoHelper.FromBothByteOrder(this._VolumePartitionLogicalBlockNumber); } set { this._VolumePartitionLogicalBlockNumber = IsoHelper.ToBothByteOrder(value); } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ulong _VolumePartitionSize;
		public uint VolumePartitionSize { get { return IsoHelper.FromBothByteOrder(this._VolumePartitionSize); } set { this._VolumePartitionSize = IsoHelper.ToBothByteOrder(value); } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2048 - 88)]
		private byte[] _Reserved;
		public byte[] Reserved { get { return this._Reserved; } set { this._Reserved = value; } }

		protected override void MarshalFrom(BufferWithSize buffer)
		{
			base.MarshalFrom(buffer);
			this._Unused1 = buffer.Read<byte>(UNUSED1_OFFSET);
			this._SystemIdentifier = buffer.ToStringAnsi((int)SYSTEM_IDENTIFIER_OFFSET, 32).TrimEnd();
			this._VolumePartitionIdentifier = buffer.ToStringAnsi((int)VOLUME_PARTITION_IDENTIFIER_OFFSET, 32).TrimEnd();
			this._VolumePartitionLogicalBlockNumber = buffer.Read<ulong>(VOLUME_PARTITION_LOGICAL_BLOCK_NUMBER_OFFSET);
			this._VolumePartitionSize = buffer.Read<ulong>(VOLUME_PARTITION_SIZE_OFFSET);
			this._Reserved = new byte[1960];
			buffer.CopyTo((int)RESERVED_OFFSET, this._Reserved, 0, this._Reserved.Length);
		}

		protected override void MarshalTo(BufferWithSize buffer)
		{
			base.MarshalTo(buffer);
			buffer.Write(this._Unused1, UNUSED1_OFFSET);
			IsoHelper.StringToPtrAnsi(buffer.ExtractSegment(SYSTEM_IDENTIFIER_OFFSET), this.SystemIdentifier, 32, ' ');
			IsoHelper.StringToPtrAnsi(buffer.ExtractSegment(VOLUME_PARTITION_IDENTIFIER_OFFSET), this.VolumePartitionIdentifier, 32, ' ');
			buffer.Write(this._VolumePartitionLogicalBlockNumber, VOLUME_PARTITION_LOGICAL_BLOCK_NUMBER_OFFSET);
			buffer.Write(this._VolumePartitionSize, VOLUME_PARTITION_SIZE_OFFSET);
			if (this._Reserved.Length > 1960) { throw new OverflowException("Field is too large."); }
			buffer.CopyFrom((int)RESERVED_OFFSET, this._Reserved, 0, this._Reserved.Length);
			buffer.Initialize((int)RESERVED_OFFSET + this._Reserved.Length, 1960 - this._Reserved.Length);
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected override int MarshaledSize { get { return Marshaler.DefaultSizeOf<VolumePartitionDescriptor>(); } }
	}
}