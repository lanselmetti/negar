using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace FileSystems.Udf
{
	[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
	public class FileIdentifierDescriptor : TaggedDescriptor, IComparable<FileIdentifierDescriptor>
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr FILE_VERSION_NUMBER_BP = (IntPtr)16; //Marshal.OffsetOf(typeof(FileIdentifierDescriptor), "_FileVersionNumber");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr FILE_CHARACTERISTICS_BP = (IntPtr)18; //Marshal.OffsetOf(typeof(FileIdentifierDescriptor), "_FileCharacteristics");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr FILE_IDENTIFIER_LENGTH_BP = (IntPtr)19; //Marshal.OffsetOf(typeof(FileIdentifierDescriptor), "_FileIdentifierLength");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr INFORMATION_CONTROL_BLOCK_BP = (IntPtr)20; //Marshal.OffsetOf(typeof(FileIdentifierDescriptor), "_InformationControlBlock");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr IMPLEMENTATION_USE_LENGTH_BP = (IntPtr)36; //Marshal.OffsetOf(typeof(FileIdentifierDescriptor), "_ImplementationUseLengthIncludingImplementationId");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr IMPLEMENTATION_IDENTIFIER_BP = (IntPtr)38; //Marshal.OffsetOf(typeof(FileIdentifierDescriptor), "_ImplementationIdentifier");

		public FileIdentifierDescriptor() : base(DescriptorTagIdentifier.FileIdentifierDescriptor) { }

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ushort _FileVersionNumber;
		public ushort FileVersionNumber { get { return this._FileVersionNumber; } set { this._FileVersionNumber = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private FileCharacteristics _FileCharacteristics;
		public FileCharacteristics FileCharacteristics { get { return this._FileCharacteristics; } set { this._FileCharacteristics = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private byte _FileIdentifierLength;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private LongAllocationDescriptor _InformationControlBlock;
		/// <summary>The address of an ICB describing the file.</summary>
		public LongAllocationDescriptor InformationControlBlock { get { return this._InformationControlBlock; } set { this._InformationControlBlock = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ushort _ImplementationUseLengthIncludingImplementationId; //= (ushort)Marshaler.DefaultSizeOf<EntityIdentifier>();
		[DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
		private EntityIdentifier _ImplementationIdentifier;
		public EntityIdentifier? ImplementationIdentifier
		{
			get { return this._ImplementationUseLengthIncludingImplementationId != 0 ? this._ImplementationIdentifier : (EntityIdentifier?)null; }
			set { this._ImplementationIdentifier = value.GetValueOrDefault(); this._ImplementationUseLengthIncludingImplementationId = (ushort)(value == null ? 0 : Marshaler.SizeOf(value.Value) + (this._ImplementationUseAfterEntryId != null ? this._ImplementationUseAfterEntryId.Length : 0)); }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		private byte[] _ImplementationUseAfterEntryId = EMPTY_BYTES;
		public byte[] ImplementationUseAfterEntryId { get { return this._ImplementationUseAfterEntryId; } set { this._ImplementationUseLengthIncludingImplementationId = (ushort)(Marshaler.SizeOf(this._ImplementationIdentifier) + (value != null ? value.Length : 0)); this._ImplementationUseAfterEntryId = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
		private string _FileIdentifier = string.Empty;
		public string FileIdentifier
		{
			get { return this._FileIdentifier; }
			set
			{
				try
				{
					//NOTE: FileIdentifier is NOT a dstring; it's just a bunch of d-characters
					this._FileIdentifierLength = string.IsNullOrEmpty(value) ? (byte)0 : (byte)(UdfHelper.GetByteLength(value) + 1);
					this._FileIdentifier = value;
				}
				catch (OverflowException ex) { throw new ArgumentNullException(string.Format("File name must be shorter than {0} bytes." + Environment.NewLine + "File name: {1}" + Environment.NewLine + "Actual length: {2:N0}", byte.MaxValue, value, value.Length * sizeof(byte)), ex); }
			}
		}

		protected override void MarshalFromBeforeValidate(BufferWithSize buffer)
		{
			base.MarshalFromBeforeValidate(buffer);

			this._FileVersionNumber = buffer.Read<ushort>(FILE_VERSION_NUMBER_BP);
			this._FileCharacteristics = buffer.Read<FileCharacteristics>(FILE_CHARACTERISTICS_BP);
			this._FileIdentifierLength = buffer.Read<byte>(FILE_IDENTIFIER_LENGTH_BP);
			this._InformationControlBlock = buffer.Read<LongAllocationDescriptor>(INFORMATION_CONTROL_BLOCK_BP);
			this._ImplementationUseLengthIncludingImplementationId = buffer.Read<ushort>(IMPLEMENTATION_USE_LENGTH_BP);
			this._ImplementationIdentifier = this._ImplementationUseLengthIncludingImplementationId > 0 ? buffer.Read<EntityIdentifier>((int)IMPLEMENTATION_IDENTIFIER_BP) : default(EntityIdentifier);
			if (this._ImplementationUseLengthIncludingImplementationId > 0)
			{
				this._ImplementationUseAfterEntryId = new byte[this._ImplementationUseLengthIncludingImplementationId - Marshaler.SizeOf(this._ImplementationIdentifier)];
				buffer.CopyTo((int)IMPLEMENTATION_IDENTIFIER_BP + Marshaler.SizeOf(this._ImplementationIdentifier), this._ImplementationUseAfterEntryId, 0, this._ImplementationUseLengthIncludingImplementationId - Marshaler.SizeOf(this._ImplementationIdentifier));
			}
			this._FileIdentifier = UdfHelper.DecodeOstaCompressedUnicode(buffer.ExtractSegment((int)IMPLEMENTATION_IDENTIFIER_BP + this._ImplementationUseLengthIncludingImplementationId, this._FileIdentifierLength), false);

			//If the implementation doesn't follow the standard and _ImplementationUseLengthIncludingImplementationId > 0 but _ImplementationUseLengthIncludingImplementationId < 32, then it'll lose its data!
			//if (this._ImplementationUseLengthIncludingImplementationId < Marshaler.SizeOf(this._ImplementationIdentifier)) { this._ImplementationUseLengthIncludingImplementationId = (ushort)Marshaler.SizeOf(this._ImplementationIdentifier); }
		}

		protected override void MarshalToBeforeValidate(BufferWithSize buffer)
		{
			base.MarshalToBeforeValidate(buffer);

			buffer.Write(this._FileVersionNumber, FILE_VERSION_NUMBER_BP);
			buffer.Write(this._FileCharacteristics, FILE_CHARACTERISTICS_BP);
			buffer.Write(this._FileIdentifierLength, FILE_IDENTIFIER_LENGTH_BP);
			buffer.Write(this._InformationControlBlock, INFORMATION_CONTROL_BLOCK_BP);
			buffer.Write(this._ImplementationUseLengthIncludingImplementationId, IMPLEMENTATION_USE_LENGTH_BP);
			if (this._ImplementationUseLengthIncludingImplementationId > 0)
			{
				buffer.Write(this._ImplementationIdentifier, IMPLEMENTATION_IDENTIFIER_BP);
				buffer.CopyFrom((int)IMPLEMENTATION_IDENTIFIER_BP + Marshaler.SizeOf(this._ImplementationIdentifier), this._ImplementationUseAfterEntryId, 0, this._ImplementationUseAfterEntryId.Length);
			}
			UdfHelper.EncodeOstaCompressedUnicode(this._FileIdentifier, buffer.ExtractSegment((int)IMPLEMENTATION_IDENTIFIER_BP + this._ImplementationUseLengthIncludingImplementationId, this._FileIdentifierLength), false);
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected override int MarshaledSize { get { return 4 * (1 + ((int)IMPLEMENTATION_IDENTIFIER_BP + this._ImplementationUseLengthIncludingImplementationId + this._FileIdentifierLength - 1) / 4); } }

		public override object Clone() { var me = (FileIdentifierDescriptor)base.Clone(); me._ImplementationUseAfterEntryId = (byte[])me._ImplementationUseAfterEntryId.Clone(); return me; }

		public int CompareTo(FileIdentifierDescriptor other) { int c = string.Compare(this.FileIdentifier, other.FileIdentifier, StringComparison.OrdinalIgnoreCase); if (c == 0) { c = other.FileVersionNumber.CompareTo(this.FileVersionNumber); } return c; }
		public int CompareTo(object other) { return this.CompareTo((FileIdentifierDescriptor)other); }
		public static bool operator <(FileIdentifierDescriptor left, FileIdentifierDescriptor right) { return left.CompareTo(right) < 0; }
		public static bool operator <=(FileIdentifierDescriptor left, FileIdentifierDescriptor right) { return left.CompareTo(right) <= 0; }
		public static bool operator >(FileIdentifierDescriptor left, FileIdentifierDescriptor right) { return left.CompareTo(right) > 0; }
		public static bool operator >=(FileIdentifierDescriptor left, FileIdentifierDescriptor right) { return left.CompareTo(right) >= 0; }

		public static int CalculateSize(string fileName) { return (int)IMPLEMENTATION_IDENTIFIER_BP + 0 + (string.IsNullOrEmpty(fileName) ? 0 : UdfHelper.GetByteLength(fileName) + 1); }

		public override string ToString() { return string.Format("{0} {{ Name = \"{1}\", Version = {2}, ICB = {3}, Characteristics = {4} }}", base.ToString(), this.FileIdentifier, this.FileVersionNumber, this.InformationControlBlock, this.FileCharacteristics); }
	}

	[Flags]
	public enum FileCharacteristics : byte { None = 0, Hidden = 1 << 0, Directory = 1 << 1, Deleted = 1 << 2, Parent = 1 << 3, Metadata = 1 << 4 }
}