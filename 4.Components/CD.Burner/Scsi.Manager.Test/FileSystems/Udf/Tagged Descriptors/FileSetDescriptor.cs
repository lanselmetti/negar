using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace FileSystems.Udf
{
	[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
	public class FileSetDescriptor : TaggedDescriptor
	{
		#region Offsets
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr RECORDING_TIME_BP = (IntPtr)16; //Marshal.OffsetOf(typeof(FileSetDescriptor), "_RecordingTime");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr INTERCHANGE_LEVEL_BP = (IntPtr)28; //Marshal.OffsetOf(typeof(FileSetDescriptor), "_InterchangeLevel");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr MAXIMUM_INTERCHANGE_LEVEL_BP = (IntPtr)30; //Marshal.OffsetOf(typeof(FileSetDescriptor), "_MaximumInterchangeLevel");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr CHARACTER_SET_LIST_BP = (IntPtr)32; //Marshal.OffsetOf(typeof(FileSetDescriptor), "_CharacterSetList");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr MAXIMUM_CHARACTER_SET_LIST_BP = (IntPtr)36; //Marshal.OffsetOf(typeof(FileSetDescriptor), "_MaximumCharacterSetList");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr FILE_SET_NUMBER_BP = (IntPtr)40; //Marshal.OffsetOf(typeof(FileSetDescriptor), "_FileSetNumber");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr FILE_SET_DESCRIPTOR_NUMBER_BP = (IntPtr)44; //Marshal.OffsetOf(typeof(FileSetDescriptor), "_FileSetDescriptorNumber");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr LOGICAL_VOLUME_IDENTIFIER_CHARACTER_SET_BP = (IntPtr)48; //Marshal.OffsetOf(typeof(FileSetDescriptor), "_LogicalVolumeIdentifierCharacterSet");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr LOGICAL_VOLUME_IDENTIFIER_BP = (IntPtr)112; //Marshal.OffsetOf(typeof(FileSetDescriptor), "_LogicalVolumeIdentifier");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr FILE_SET_CHARACTER_SET_BP = (IntPtr)240; //Marshal.OffsetOf(typeof(FileSetDescriptor), "_FileSetCharacterSet");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr FILE_SET_IDENTIFIER_BP = (IntPtr)304; //Marshal.OffsetOf(typeof(FileSetDescriptor), "_FileSetIdentifier");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr COPYRIGHT_FILE_IDENTIFIER_BP = (IntPtr)336; //Marshal.OffsetOf(typeof(FileSetDescriptor), "_CopyrightFileIdentifier");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr ABSTRACT_FILE_IDENTIFIER_BP = (IntPtr)368; //Marshal.OffsetOf(typeof(FileSetDescriptor), "_AbstractFileIdentifier");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr ROOT_DIRECTORY_ICB_BP = (IntPtr)400; //Marshal.OffsetOf(typeof(FileSetDescriptor), "_RootDirectoryIcb");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr DOMAIN_IDENTIFIER_BP = (IntPtr)416; //Marshal.OffsetOf(typeof(FileSetDescriptor), "_DomainIdentifier");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr NEXT_EXTENT_BP = (IntPtr)448; //Marshal.OffsetOf(typeof(FileSetDescriptor), "_NextExtent");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr SYSTEM_STREAM_DIRECTORY_ICB_BP = (IntPtr)464; //Marshal.OffsetOf(typeof(FileSetDescriptor), "_SystemStreamDirectoryICB");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr RESERVED_BP = (IntPtr)480; //Marshal.OffsetOf(typeof(FileSetDescriptor), "_Reserved");
		#endregion

		public FileSetDescriptor() : base(DescriptorTagIdentifier.FileSetDescriptor) { }

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Timestamp _RecordingTime = (Timestamp)DateTime.Now;
		public Timestamp RecordingTime { get { return this._RecordingTime; } set { this._RecordingTime = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ushort _InterchangeLevel = 3;
		public ushort InterchangeLevel { get { return this._InterchangeLevel; } set { this._InterchangeLevel = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ushort _MaximumInterchangeLevel = 3;
		public ushort MaximumInterchangeLevel { get { return this._MaximumInterchangeLevel; } set { this._MaximumInterchangeLevel = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private uint _CharacterSetList = 1;
		public uint CharacterSetList { get { return this._CharacterSetList; } set { this._CharacterSetList = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private uint _MaximumCharacterSetList = 1;
		public uint MaximumCharacterSetList { get { return this._MaximumCharacterSetList; } set { this._MaximumCharacterSetList = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private uint _FileSetNumber;
		public uint FileSetNumber { get { return this._FileSetNumber; } set { this._FileSetNumber = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private uint _FileSetDescriptorNumber;
		public uint FileSetDescriptorNumber { get { return this._FileSetDescriptorNumber; } set { this._FileSetDescriptorNumber = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private CharacterSpecification _LogicalVolumeIdentifierCharacterSet = CharacterSpecification.OstaCompressedUnicode;
		public CharacterSpecification LogicalVolumeIdentifierCharacterSet { get { return this._LogicalVolumeIdentifierCharacterSet; } set { this._LogicalVolumeIdentifierCharacterSet = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
		private string _LogicalVolumeIdentifier = string.Empty;
		public string LogicalVolumeIdentifier { get { return this._LogicalVolumeIdentifier; } set { if (value.Length >= 128) { throw new ArgumentException("value", "String must be at most 127 characters long."); } this._LogicalVolumeIdentifier = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private CharacterSpecification _FileSetCharacterSet = CharacterSpecification.OstaCompressedUnicode;
		public CharacterSpecification FileSetCharacterSet { get { return this._FileSetCharacterSet; } set { this._FileSetCharacterSet = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		private string _FileSetIdentifier = string.Empty;
		public string FileSetIdentifier { get { return this._FileSetIdentifier; } set { if (value.Length >= 32) { throw new ArgumentException("value", "String must be at most 31 characters long."); } this._FileSetIdentifier = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		private string _CopyrightFileIdentifier = string.Empty;
		public string CopyrightFileIdentifier { get { return this._CopyrightFileIdentifier; } set { if (value.Length >= 32) { throw new ArgumentException("value", "String must be at most 31 characters long."); } this._CopyrightFileIdentifier = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		private string _AbstractFileIdentifier = string.Empty;
		public string AbstractFileIdentifier { get { return this._AbstractFileIdentifier; } set { if (value.Length >= 32) { throw new ArgumentException("value", "String must be at most 31 characters long."); } this._AbstractFileIdentifier = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private LongAllocationDescriptor _RootDirectoryIcb;
		public LongAllocationDescriptor RootDirectoryIcb { get { return this._RootDirectoryIcb; } set { this._RootDirectoryIcb = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EntityIdentifier _DomainIdentifier = new EntityIdentifier(EntityIdentifierFlags.None, EntityIdentifier.FileSetDescriptorDomainId, 0);
		public EntityIdentifier DomainIdentifier { get { return this._DomainIdentifier; } set { this._DomainIdentifier = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private LongAllocationDescriptor _NextExtent;
		public LongAllocationDescriptor NextExtent { get { return this._NextExtent; } set { this._NextExtent = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private LongAllocationDescriptor _SystemStreamDirectoryICB;
		public LongAllocationDescriptor SystemStreamDirectoryICB { get { return this._SystemStreamDirectoryICB; } set { this._SystemStreamDirectoryICB = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
		private byte[] _Reserved = EMPTY_BYTES; //new byte[32];
		public byte[] Reserved { get { return this._Reserved; } }

		protected override void MarshalFromBeforeValidate(BufferWithSize buffer)
		{
			base.MarshalFromBeforeValidate(buffer);

			this._LogicalVolumeIdentifierCharacterSet = buffer.Read<CharacterSpecification>(LOGICAL_VOLUME_IDENTIFIER_CHARACTER_SET_BP);
			if (this._LogicalVolumeIdentifierCharacterSet != CharacterSpecification.OstaCompressedUnicode) { throw new NotSupportedException("Character set not supported."); }
			this._FileSetCharacterSet = buffer.Read<CharacterSpecification>(FILE_SET_CHARACTER_SET_BP);
			if (this._FileSetCharacterSet != CharacterSpecification.OstaCompressedUnicode) { throw new NotSupportedException("Character set not supported."); }

			this._RecordingTime = buffer.Read<Timestamp>(RECORDING_TIME_BP);
			this._InterchangeLevel = buffer.Read<ushort>(INTERCHANGE_LEVEL_BP);
			this._MaximumInterchangeLevel = buffer.Read<ushort>(MAXIMUM_INTERCHANGE_LEVEL_BP);
			this._CharacterSetList = buffer.Read<uint>(CHARACTER_SET_LIST_BP);
			this._MaximumCharacterSetList = buffer.Read<uint>(MAXIMUM_CHARACTER_SET_LIST_BP);
			this._FileSetNumber = buffer.Read<uint>(FILE_SET_NUMBER_BP);
			this._FileSetDescriptorNumber = buffer.Read<uint>(FILE_SET_DESCRIPTOR_NUMBER_BP);
			this._LogicalVolumeIdentifier = UdfHelper.DecodeOstaCompressedUnicode(buffer.ExtractSegment((int)LOGICAL_VOLUME_IDENTIFIER_BP, 128), true);
			this._FileSetIdentifier = UdfHelper.DecodeOstaCompressedUnicode(buffer.ExtractSegment((int)FILE_SET_IDENTIFIER_BP, 32), true);
			this._CopyrightFileIdentifier = UdfHelper.DecodeOstaCompressedUnicode(buffer.ExtractSegment((int)COPYRIGHT_FILE_IDENTIFIER_BP, 32), true);
			this._AbstractFileIdentifier = UdfHelper.DecodeOstaCompressedUnicode(buffer.ExtractSegment((int)ABSTRACT_FILE_IDENTIFIER_BP, 32), true);
			this._RootDirectoryIcb = buffer.Read<LongAllocationDescriptor>(ROOT_DIRECTORY_ICB_BP);
			this._DomainIdentifier = buffer.Read<EntityIdentifier>(DOMAIN_IDENTIFIER_BP);
			this._NextExtent = buffer.Read<LongAllocationDescriptor>(NEXT_EXTENT_BP);
			this._SystemStreamDirectoryICB = buffer.Read<LongAllocationDescriptor>(SYSTEM_STREAM_DIRECTORY_ICB_BP);
			this._Reserved = new byte[32];
			buffer.CopyTo((int)RESERVED_BP, this._Reserved, 0, this._Reserved.Length);
		}

		protected override void MarshalToBeforeValidate(BufferWithSize buffer)
		{
			base.MarshalToBeforeValidate(buffer);

			if (this._LogicalVolumeIdentifierCharacterSet != CharacterSpecification.OstaCompressedUnicode) { throw new NotSupportedException("Character set not supported."); }
			if (this._FileSetCharacterSet != CharacterSpecification.OstaCompressedUnicode) { throw new NotSupportedException("Character set not supported."); }

			buffer.Write(this._RecordingTime, RECORDING_TIME_BP);
			buffer.Write(this._InterchangeLevel, INTERCHANGE_LEVEL_BP);
			buffer.Write(this._MaximumInterchangeLevel, MAXIMUM_INTERCHANGE_LEVEL_BP);
			buffer.Write(this._CharacterSetList, CHARACTER_SET_LIST_BP);
			buffer.Write(this._MaximumCharacterSetList, MAXIMUM_CHARACTER_SET_LIST_BP);
			buffer.Write(this._FileSetNumber, FILE_SET_NUMBER_BP);
			buffer.Write(this._FileSetDescriptorNumber, FILE_SET_DESCRIPTOR_NUMBER_BP);
			buffer.Write(this._LogicalVolumeIdentifierCharacterSet, LOGICAL_VOLUME_IDENTIFIER_CHARACTER_SET_BP);
			UdfHelper.EncodeOstaCompressedUnicode(this._LogicalVolumeIdentifier, buffer.ExtractSegment((int)LOGICAL_VOLUME_IDENTIFIER_BP, 128), true);
			buffer.Write(this._FileSetCharacterSet, FILE_SET_CHARACTER_SET_BP);
			UdfHelper.EncodeOstaCompressedUnicode(this._FileSetIdentifier, buffer.ExtractSegment((int)FILE_SET_IDENTIFIER_BP, 32), true);
			UdfHelper.EncodeOstaCompressedUnicode(this._CopyrightFileIdentifier, buffer.ExtractSegment((int)COPYRIGHT_FILE_IDENTIFIER_BP, 32), true);
			UdfHelper.EncodeOstaCompressedUnicode(this._AbstractFileIdentifier, buffer.ExtractSegment((int)ABSTRACT_FILE_IDENTIFIER_BP, 32), true);
			buffer.Write(this._RootDirectoryIcb, ROOT_DIRECTORY_ICB_BP);
			buffer.Write(this._DomainIdentifier, DOMAIN_IDENTIFIER_BP);
			buffer.Write(this._NextExtent, NEXT_EXTENT_BP);
			buffer.Write(this._SystemStreamDirectoryICB, SYSTEM_STREAM_DIRECTORY_ICB_BP);
			if (this._Reserved.Length > 32) { throw new OverflowException("Field is too large."); }
			buffer.CopyFrom((int)RESERVED_BP, this._Reserved, 0, this._Reserved.Length);
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected override int MarshaledSize { get { return 512; } }

		public override object Clone() { var me = (FileSetDescriptor)base.Clone(); me._Reserved = (byte[])me._Reserved.Clone(); return me; }
	}
}