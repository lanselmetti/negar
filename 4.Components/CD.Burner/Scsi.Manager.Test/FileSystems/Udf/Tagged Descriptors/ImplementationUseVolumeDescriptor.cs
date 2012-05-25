using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace FileSystems.Udf
{
	[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
	public class ImplementationUseVolumeDescriptor : TaggedDescriptor
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr VOLUME_DESCRIPTOR_SEQUENCE_NUMBER_BP = (IntPtr)16; //Marshal.OffsetOf(typeof(ImplementationUseVolumeDescriptor), "_VolumeDescriptorSequenceNumber");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr IMPLEMENTATION_IDENTIFIER_BP = (IntPtr)20; //Marshal.OffsetOf(typeof(ImplementationUseVolumeDescriptor), "_ImplementationIdentifier");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr LOGICAL_VOLUME_IDENTIFIER_CHARACTER_SET_BP = (IntPtr)52; //Marshal.OffsetOf(typeof(ImplementationUseVolumeDescriptor), "_LogicalVolumeIdentifierCharacterSet");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr LOGICAL_VOLUME_IDENTIFIER_BP = (IntPtr)116; //Marshal.OffsetOf(typeof(ImplementationUseVolumeDescriptor), "_LogicalVolumeIdentifier");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr LOGICAL_VOLUME_INFORMATION_1_BP = (IntPtr)244; //Marshal.OffsetOf(typeof(ImplementationUseVolumeDescriptor), "_LogicalVolumeInformation1");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr LOGICAL_VOLUME_INFORMATION_2_BP = (IntPtr)280; //Marshal.OffsetOf(typeof(ImplementationUseVolumeDescriptor), "_LogicalVolumeInformation2");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr LOGICAL_VOLUME_INFORMATION_3_BP = (IntPtr)316; //Marshal.OffsetOf(typeof(ImplementationUseVolumeDescriptor), "_LogicalVolumeInformation3");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr IMPLEMENTATION_IDENTIFIER_2_BP = (IntPtr)352; //Marshal.OffsetOf(typeof(ImplementationUseVolumeDescriptor), "_ImplementationIdentifier2");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr IMPLEMENTATION_USE_BP = (IntPtr)384; //Marshal.OffsetOf(typeof(ImplementationUseVolumeDescriptor), "_ImplementationUse");

		public ImplementationUseVolumeDescriptor() : base(DescriptorTagIdentifier.ImplementationUseVolumeDescriptor) { }

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private uint _VolumeDescriptorSequenceNumber;
		public uint VolumeDescriptorSequenceNumber { get { return this._VolumeDescriptorSequenceNumber; } set { this._VolumeDescriptorSequenceNumber = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EntityIdentifier _ImplementationIdentifier = new EntityIdentifier(EntityIdentifierFlags.None, EntityIdentifier.ImplementationUseVolumeDescriptorImplementationId, 0);
		public EntityIdentifier ImplementationIdentifier { get { return this._ImplementationIdentifier; } set { this._ImplementationIdentifier = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private CharacterSpecification _LogicalVolumeIdentifierCharacterSet = CharacterSpecification.OstaCompressedUnicode;
		public CharacterSpecification LogicalVolumeIdentifierCharacterSet { get { return this._LogicalVolumeIdentifierCharacterSet; } set { this._LogicalVolumeIdentifierCharacterSet = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
		private string _LogicalVolumeIdentifier = string.Empty;
		public string LogicalVolumeIdentifier { get { return this._LogicalVolumeIdentifier; } set { if (value.Length >= 128) { throw new ArgumentException("value", "String must be at most 127 characters long."); } this._LogicalVolumeIdentifier = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 36)]
		private string _LogicalVolumeInformation1 = string.Empty;
		public string LogicalVolumeInformation1 { get { return this._LogicalVolumeInformation1; } set { if (value.Length >= 36) { throw new ArgumentException("value", "String must be at most 35 characters long."); } this._LogicalVolumeInformation1 = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 36)]
		private string _LogicalVolumeInformation2 = string.Empty;
		public string LogicalVolumeInformation2 { get { return this._LogicalVolumeInformation2; } set { if (value.Length >= 36) { throw new ArgumentException("value", "String must be at most 35 characters long."); } this._LogicalVolumeInformation2 = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 36)]
		private string _LogicalVolumeInformation3 = string.Empty;
		public string LogicalVolumeInformation3 { get { return this._LogicalVolumeInformation3; } set { if (value.Length >= 36) { throw new ArgumentException("value", "String must be at most 35 characters long."); } this._LogicalVolumeInformation3 = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EntityIdentifier _ImplementationIdentifier2;
		public EntityIdentifier ImplementationIdentifier2 { get { return this._ImplementationIdentifier2; } set { this._ImplementationIdentifier2 = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
		private byte[] _ImplementationUse = EMPTY_BYTES; //new byte[128];
		public byte[] ImplementationUse { get { return this._ImplementationUse; } }

		protected override void MarshalFromBeforeValidate(BufferWithSize buffer)
		{
			base.MarshalFromBeforeValidate(buffer);

			this._LogicalVolumeIdentifierCharacterSet = buffer.Read<CharacterSpecification>(LOGICAL_VOLUME_IDENTIFIER_CHARACTER_SET_BP);
			if (this._LogicalVolumeIdentifierCharacterSet != CharacterSpecification.OstaCompressedUnicode) { throw new NotSupportedException("Character set not supported."); }

			this._VolumeDescriptorSequenceNumber = buffer.Read<uint>(VOLUME_DESCRIPTOR_SEQUENCE_NUMBER_BP);
			this._ImplementationIdentifier = buffer.Read<EntityIdentifier>(IMPLEMENTATION_IDENTIFIER_BP);
			this._LogicalVolumeIdentifier = UdfHelper.DecodeOstaCompressedUnicode(buffer.ExtractSegment((int)LOGICAL_VOLUME_IDENTIFIER_BP, 128), true);
			this._LogicalVolumeInformation1 = UdfHelper.DecodeOstaCompressedUnicode(buffer.ExtractSegment((int)LOGICAL_VOLUME_INFORMATION_1_BP, 36), true);
			this._LogicalVolumeInformation2 = UdfHelper.DecodeOstaCompressedUnicode(buffer.ExtractSegment((int)LOGICAL_VOLUME_INFORMATION_2_BP, 36), true);
			this._LogicalVolumeInformation3 = UdfHelper.DecodeOstaCompressedUnicode(buffer.ExtractSegment((int)LOGICAL_VOLUME_INFORMATION_3_BP, 36), true);
			this._ImplementationIdentifier2 = buffer.Read<EntityIdentifier>(IMPLEMENTATION_IDENTIFIER_2_BP);
			this._ImplementationUse = new byte[128];
			buffer.CopyTo((int)IMPLEMENTATION_USE_BP, this._ImplementationUse, 0, this._ImplementationUse.Length);
		}

		protected override void MarshalToBeforeValidate(BufferWithSize buffer)
		{
			base.MarshalToBeforeValidate(buffer);

			if (this._LogicalVolumeIdentifierCharacterSet != CharacterSpecification.OstaCompressedUnicode) { throw new NotSupportedException("Character set not supported."); }

			buffer.Write(this._VolumeDescriptorSequenceNumber, VOLUME_DESCRIPTOR_SEQUENCE_NUMBER_BP);
			buffer.Write(this._ImplementationIdentifier, IMPLEMENTATION_IDENTIFIER_BP);
			buffer.Write(this._LogicalVolumeIdentifierCharacterSet, LOGICAL_VOLUME_IDENTIFIER_CHARACTER_SET_BP);
			UdfHelper.EncodeOstaCompressedUnicode(this._LogicalVolumeIdentifier, buffer.ExtractSegment((int)LOGICAL_VOLUME_IDENTIFIER_BP, 128), true);
			UdfHelper.EncodeOstaCompressedUnicode(this._LogicalVolumeInformation1, buffer.ExtractSegment((int)LOGICAL_VOLUME_INFORMATION_1_BP, 36), true);
			UdfHelper.EncodeOstaCompressedUnicode(this._LogicalVolumeInformation2, buffer.ExtractSegment((int)LOGICAL_VOLUME_INFORMATION_2_BP, 36), true);
			UdfHelper.EncodeOstaCompressedUnicode(this._LogicalVolumeInformation3, buffer.ExtractSegment((int)LOGICAL_VOLUME_INFORMATION_3_BP, 36), true);
			buffer.Write(this._ImplementationIdentifier2, IMPLEMENTATION_IDENTIFIER_2_BP);
			if (this._ImplementationUse.Length > 128) { throw new OverflowException("Field is too large."); }
			buffer.CopyFrom((int)IMPLEMENTATION_USE_BP, this._ImplementationUse, 0, this._ImplementationUse.Length);
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected override int MarshaledSize { get { return 512; } }

		public override object Clone() { var me = (ImplementationUseVolumeDescriptor)base.Clone(); me._ImplementationUse = (byte[])me._ImplementationUse.Clone(); return me; }
	}
}