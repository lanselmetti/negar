using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace FileSystems.Udf
{
	[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
	public class PrimaryVolumeDescriptor : TaggedDescriptor
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr VOLUME_DESCRIPTOR_SEQUENCE_NUMBER_BP = (IntPtr)16; //Marshal.OffsetOf(typeof(PrimaryVolumeDescriptor), "_VolumeDescriptorSequenceNumber");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr PRIMARY_VOLUME_DESCRIPTOR_NUMBER_BP = (IntPtr)20; //Marshal.OffsetOf(typeof(PrimaryVolumeDescriptor), "_PrimaryVolumeDescriptorNumber");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr VOLUME_IDENTIFIER_BP = (IntPtr)24; //Marshal.OffsetOf(typeof(PrimaryVolumeDescriptor), "_VolumeIdentifier");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr VOLUME_SEQUENCE_NUMBER_BP = (IntPtr)56; //Marshal.OffsetOf(typeof(PrimaryVolumeDescriptor), "_VolumeSequenceNumber");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr MAXIMUM_VOLUME_SEQUENCE_NUMBER_BP = (IntPtr)58; //Marshal.OffsetOf(typeof(PrimaryVolumeDescriptor), "_MaximumVolumeSequenceNumber");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr INTERCHANGE_LEVEL_BP = (IntPtr)60; //Marshal.OffsetOf(typeof(PrimaryVolumeDescriptor), "_InterchangeLevel");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr MAXIMUM_INTERCHANGE_LEVEL_BP = (IntPtr)62; //Marshal.OffsetOf(typeof(PrimaryVolumeDescriptor), "_MaximumInterchangeLevel");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr CHARACTER_SET_LIST_BP = (IntPtr)64; //Marshal.OffsetOf(typeof(PrimaryVolumeDescriptor), "_CharacterSetList");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr MAXIMUM_CHARACTER_SET_LIST_BP = (IntPtr)68; //Marshal.OffsetOf(typeof(PrimaryVolumeDescriptor), "_MaximumCharacterSetList");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr VOLUME_SET_IDENTIFIER_BP = (IntPtr)72; //Marshal.OffsetOf(typeof(PrimaryVolumeDescriptor), "_VolumeSetIdentifier");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr DESCRIPTOR_CHARACTER_SET_BP = (IntPtr)200; //Marshal.OffsetOf(typeof(PrimaryVolumeDescriptor), "_DescriptorCharacterSet");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr EXPLANATORY_CHARACTER_SET_BP = (IntPtr)264; //Marshal.OffsetOf(typeof(PrimaryVolumeDescriptor), "_ExplanatoryCharacterSet");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr VOLUME_ABSTRACT_BP = (IntPtr)328; //Marshal.OffsetOf(typeof(PrimaryVolumeDescriptor), "_VolumeAbstract");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr VOLUME_COPYRIGHT_NOTICE_BP = (IntPtr)336; //Marshal.OffsetOf(typeof(PrimaryVolumeDescriptor), "_VolumeCopyrightNotice");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr APPLICATION_IDENTIFIER_BP = (IntPtr)344; //Marshal.OffsetOf(typeof(PrimaryVolumeDescriptor), "_ApplicationIdentifier");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr RECORDING_TIME_BP = (IntPtr)376; //Marshal.OffsetOf(typeof(PrimaryVolumeDescriptor), "_RecordingTime");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr IMPLEMENTATION_IDENTIFIER_BP = (IntPtr)388; //Marshal.OffsetOf(typeof(PrimaryVolumeDescriptor), "_ImplementationIdentifier");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr IMPLEMENTATION_USE_BP = (IntPtr)420; //Marshal.OffsetOf(typeof(PrimaryVolumeDescriptor), "_ImplementationUse");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr PREDECESSOR_VOLUME_DESCRIPTOR_SEQUENCE_LOCATION_BP = (IntPtr)484; //Marshal.OffsetOf(typeof(PrimaryVolumeDescriptor), "_PredecessorVolumeDescriptorSequenceLocation");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr FLAGS_BP = (IntPtr)488; //Marshal.OffsetOf(typeof(PrimaryVolumeDescriptor), "_Flags");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr RESERVED_BP = (IntPtr)490; //Marshal.OffsetOf(typeof(PrimaryVolumeDescriptor), "_Reserved");

		public PrimaryVolumeDescriptor() : base(DescriptorTagIdentifier.PrimaryVolumeDescriptor) { this.VolumeSetIdentifier = Guid.NewGuid().ToString("N").Substring(0, 31); }

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private uint _VolumeDescriptorSequenceNumber;
		/// <summary>All volume descriptors with identical Volume Descriptor Sequence Numbers have identical contents.</summary>
		/// <remarks>Typically, an originating system will chose a new Volume Descriptor Sequence Number by adding <c>1</c> to the largest such number seen when scanning the Volume Descriptor Sequence.</remarks>
		public uint VolumeDescriptorSequenceNumber { get { return this._VolumeDescriptorSequenceNumber; } set { this._VolumeDescriptorSequenceNumber = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private uint _PrimaryVolumeDescriptorNumber;
		/// <summary>Each Primary Volume Descriptor has an assigned Primary Volume Descriptor Number. Only one prevailing Primary Volume Descriptor of a Volume Descriptor Sequence can have a Primary Volume Descriptor Number of 0.</summary>
		public uint PrimaryVolumeDescriptorNumber { get { return this._PrimaryVolumeDescriptorNumber; } set { this._PrimaryVolumeDescriptorNumber = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		private string _VolumeIdentifier = string.Empty;
		public string VolumeIdentifier { get { return this._VolumeIdentifier; } set { if (value.Length >= 32) { throw new ArgumentException("value", "String must be at most 31 characters long."); } this._VolumeIdentifier = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ushort _VolumeSequenceNumber = 1;
		/// <summary>The ordinal number of the volume in the volume set of which the volume is a member.</summary>
		public ushort VolumeSequenceNumber { get { return this._VolumeSequenceNumber; } set { this._VolumeSequenceNumber = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ushort _MaximumVolumeSequenceNumber = 1;
		/// <summary>The ordinal number of the volume in the volume set with the largest assigned volume sequence number at the time this descriptor was recorded. If this field contains 0, there is no such identification.</summary>
		public ushort MaximumVolumeSequenceNumber { get { return this._MaximumVolumeSequenceNumber; } set { this._MaximumVolumeSequenceNumber = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ushort _InterchangeLevel = 2;
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
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
		private string _VolumeSetIdentifier; //initialized in ctor
		public string VolumeSetIdentifier { get { return this._VolumeSetIdentifier; } set { if (value.Length >= 128) { throw new ArgumentException("value", "String must be at most 127 characters long."); } this._VolumeSetIdentifier = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private CharacterSpecification _DescriptorCharacterSet = CharacterSpecification.OstaCompressedUnicode;
		public CharacterSpecification DescriptorCharacterSet { get { return this._DescriptorCharacterSet; } set { this._DescriptorCharacterSet = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private CharacterSpecification _ExplanatoryCharacterSet = CharacterSpecification.OstaCompressedUnicode;
		public CharacterSpecification ExplanatoryCharacterSet { get { return this._ExplanatoryCharacterSet; } set { this._ExplanatoryCharacterSet = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ExtentAllocationDescriptor _VolumeAbstract;
		public ExtentAllocationDescriptor VolumeAbstract { get { return this._VolumeAbstract; } set { this._VolumeAbstract = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ExtentAllocationDescriptor _VolumeCopyrightNotice;
		public ExtentAllocationDescriptor VolumeCopyrightNotice { get { return this._VolumeCopyrightNotice; } set { this._VolumeCopyrightNotice = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EntityIdentifier _ApplicationIdentifier;
		public EntityIdentifier ApplicationIdentifier { get { return this._ApplicationIdentifier; } set { this._ApplicationIdentifier = value; } }
		[DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
		private Timestamp _RecordingTime = (Timestamp)DateTime.Now;
		public Timestamp RecordingTime { get { return this._RecordingTime; } set { this._RecordingTime = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EntityIdentifier _ImplementationIdentifier;
		public EntityIdentifier ImplementationIdentifier { get { return this._ImplementationIdentifier; } set { this._ImplementationIdentifier = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
		private byte[] _ImplementationUse = EMPTY_BYTES; //new byte[64];
		public byte[] ImplementationUse { get { return this._ImplementationUse; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private uint _PredecessorVolumeDescriptorSequenceLocation;
		public uint PredecessorVolumeDescriptorSequenceLocation { get { return this._PredecessorVolumeDescriptorSequenceLocation; } set { this._PredecessorVolumeDescriptorSequenceLocation = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private PrimaryVolumeDescriptorFlags _Flags;
		public PrimaryVolumeDescriptorFlags Flags { get { return this._Flags; } set { this._Flags = value; } }
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private byte[] _Reserved = EMPTY_BYTES; //new byte[22];

		protected override void MarshalFromBeforeValidate(BufferWithSize buffer)
		{
			base.MarshalFromBeforeValidate(buffer);

			this._DescriptorCharacterSet = buffer.Read<CharacterSpecification>(DESCRIPTOR_CHARACTER_SET_BP);
			if (this._DescriptorCharacterSet != CharacterSpecification.OstaCompressedUnicode) { throw new NotSupportedException("Character set not supported."); }

			this._VolumeDescriptorSequenceNumber = buffer.Read<uint>(VOLUME_DESCRIPTOR_SEQUENCE_NUMBER_BP);
			this._PrimaryVolumeDescriptorNumber = buffer.Read<uint>(PRIMARY_VOLUME_DESCRIPTOR_NUMBER_BP);
			this._VolumeIdentifier = UdfHelper.DecodeOstaCompressedUnicode(buffer.ExtractSegment((int)VOLUME_IDENTIFIER_BP, 32), true);
			this._VolumeSequenceNumber = buffer.Read<ushort>(VOLUME_SEQUENCE_NUMBER_BP);
			this._MaximumVolumeSequenceNumber = buffer.Read<ushort>(MAXIMUM_VOLUME_SEQUENCE_NUMBER_BP);
			this._InterchangeLevel = buffer.Read<ushort>(INTERCHANGE_LEVEL_BP);
			this._MaximumInterchangeLevel = buffer.Read<ushort>(MAXIMUM_INTERCHANGE_LEVEL_BP);
			this._CharacterSetList = buffer.Read<uint>(CHARACTER_SET_LIST_BP);
			this._MaximumCharacterSetList = buffer.Read<uint>(MAXIMUM_CHARACTER_SET_LIST_BP);
			this._VolumeSetIdentifier = UdfHelper.DecodeOstaCompressedUnicode(buffer.ExtractSegment((int)VOLUME_SET_IDENTIFIER_BP, 128), true);
			this._ExplanatoryCharacterSet = buffer.Read<CharacterSpecification>(EXPLANATORY_CHARACTER_SET_BP);
			this._VolumeAbstract = buffer.Read<ExtentAllocationDescriptor>(VOLUME_ABSTRACT_BP);
			this._VolumeCopyrightNotice = buffer.Read<ExtentAllocationDescriptor>(VOLUME_COPYRIGHT_NOTICE_BP);
			this._ApplicationIdentifier = buffer.Read<EntityIdentifier>(APPLICATION_IDENTIFIER_BP);
			this._RecordingTime = buffer.Read<Timestamp>(RECORDING_TIME_BP);
			this._ImplementationIdentifier = buffer.Read<EntityIdentifier>(IMPLEMENTATION_IDENTIFIER_BP);
			this._ImplementationUse = new byte[64];
			buffer.CopyTo((int)IMPLEMENTATION_USE_BP, this._ImplementationUse, 0, this._ImplementationUse.Length);
			this._PredecessorVolumeDescriptorSequenceLocation = buffer.Read<uint>(PREDECESSOR_VOLUME_DESCRIPTOR_SEQUENCE_LOCATION_BP);
			this._Flags = buffer.Read<PrimaryVolumeDescriptorFlags>(FLAGS_BP);
			this._Reserved = new byte[22];
			buffer.CopyTo((int)RESERVED_BP, this._Reserved, 0, this._Reserved.Length);
		}

		protected override void MarshalToBeforeValidate(BufferWithSize buffer)
		{
			base.MarshalToBeforeValidate(buffer);

			if (this._DescriptorCharacterSet != CharacterSpecification.OstaCompressedUnicode) { throw new NotSupportedException("Character set not supported."); }

			buffer.Write(this._VolumeDescriptorSequenceNumber, VOLUME_DESCRIPTOR_SEQUENCE_NUMBER_BP);
			buffer.Write(this._PrimaryVolumeDescriptorNumber, PRIMARY_VOLUME_DESCRIPTOR_NUMBER_BP);
			UdfHelper.EncodeOstaCompressedUnicode(this._VolumeIdentifier, buffer.ExtractSegment((int)VOLUME_IDENTIFIER_BP, 32), true);
			buffer.Write(this._VolumeSequenceNumber, VOLUME_SEQUENCE_NUMBER_BP);
			buffer.Write(this._MaximumVolumeSequenceNumber, MAXIMUM_VOLUME_SEQUENCE_NUMBER_BP);
			buffer.Write(this._InterchangeLevel, INTERCHANGE_LEVEL_BP);
			buffer.Write(this._MaximumInterchangeLevel, MAXIMUM_INTERCHANGE_LEVEL_BP);
			buffer.Write(this._CharacterSetList, CHARACTER_SET_LIST_BP);
			buffer.Write(this._MaximumCharacterSetList, MAXIMUM_CHARACTER_SET_LIST_BP);
			UdfHelper.EncodeOstaCompressedUnicode(this._VolumeSetIdentifier, buffer.ExtractSegment((int)VOLUME_SET_IDENTIFIER_BP, 128), true);
			buffer.Write(this._DescriptorCharacterSet, DESCRIPTOR_CHARACTER_SET_BP);
			buffer.Write(this._ExplanatoryCharacterSet, EXPLANATORY_CHARACTER_SET_BP);
			buffer.Write(this._VolumeAbstract, VOLUME_ABSTRACT_BP);
			buffer.Write(this._VolumeCopyrightNotice, VOLUME_COPYRIGHT_NOTICE_BP);
			buffer.Write(this._ApplicationIdentifier, APPLICATION_IDENTIFIER_BP);
			buffer.Write(this._RecordingTime, RECORDING_TIME_BP);
			buffer.Write(this._ImplementationIdentifier, IMPLEMENTATION_IDENTIFIER_BP);
			if (this._ImplementationUse.Length > 64) { throw new OverflowException("Field is too large."); }
			buffer.CopyFrom((int)IMPLEMENTATION_USE_BP, this._ImplementationUse, 0, this._ImplementationUse.Length);
			buffer.Write(this._PredecessorVolumeDescriptorSequenceLocation, PREDECESSOR_VOLUME_DESCRIPTOR_SEQUENCE_LOCATION_BP);
			buffer.Write(this._Flags, FLAGS_BP);
			if (this._Reserved.Length > 22) { throw new OverflowException("Field is too large."); }
			buffer.CopyFrom((int)RESERVED_BP, this._Reserved, 0, this._Reserved.Length);
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected override int MarshaledSize { get { return 512; } }

		public override object Clone() { var me = (PrimaryVolumeDescriptor)base.Clone(); me._ImplementationUse = (byte[])me._ImplementationUse.Clone(); me._Reserved = (byte[])me._Reserved.Clone(); return me; }
	}

	[Flags]
	public enum PrimaryVolumeDescriptorFlags : short { None = 0, CommonVolumeSetIdentification = 1 << 0 }
}