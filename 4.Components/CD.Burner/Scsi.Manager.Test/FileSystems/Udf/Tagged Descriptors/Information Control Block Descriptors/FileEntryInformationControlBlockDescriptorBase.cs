using System.Diagnostics;
using System.Runtime.InteropServices;
using System;

namespace FileSystems.Udf
{
	[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
	public abstract class FileEntryInformationControlBlockDescriptorBase : InformationControlBlockDescriptor
	{
		public FileEntryInformationControlBlockDescriptorBase(DescriptorTagIdentifier id, IcbFileType type) : base(id, type) { }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public abstract Timestamp AccessTime { get; set; }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public abstract byte[] AllocationDescriptors { get; set; }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public abstract Timestamp AttributeTime { get; set; }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public abstract uint Checkpoint { get; set; }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public abstract byte[] ExtendedAttributes { get; set; }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public abstract ushort FileLinkCount { get; set; }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public abstract uint GroupIdentifier { get; set; }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public abstract EntityIdentifier ImplementationIdentifier { get; set; }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public abstract long InformationLength { get; set; } //Technically unsigned, but no one stores 16 billion GB of data on a disc... the benefits outweigh the costs :D
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public abstract long LogicalBlocksRecorded { get; set; } //Technically unsigned, but no one stores 32 trillion GB of data on a disc... the benefits outweigh the costs :D
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public abstract Timestamp ModificationTime { get; set; }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public abstract UdfFilePermissions Permissions { get; set; }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public abstract IcbRecordDisplayCharacteristics RecordDisplayAttributes { get; set; }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public abstract IcbRecordFormat RecordFormat { get; set; }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public abstract uint RecordLength { get; set; }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public abstract ulong UniqueIdentifier { get; set; }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public abstract uint UserIdentifier { get; set; }

		public new uint TagLocation { get { return base.TagLocation; } set { base.TagLocation = value; } }
	}

	[Flags]
	public enum UdfFilePermissions : int
	{
		OtherExecute = 1 << 0,
		OtherWrite = 1 << 1,
		OtherRead = 1 << 2,
		OtherChangeAttributes = 1 << 3,
		OtherDelete = 1 << 4,

		GroupExecute = 1 << 5,
		GroupWrite = 1 << 6,
		GroupRead = 1 << 7,
		GroupChangeAttributes = 1 << 8,
		GroupDelete = 1 << 9,

		OwnerExecute = 1 << 10,
		OwnerWrite = 1 << 11,
		OwnerRead = 1 << 12,
		OwnerChangeAttributes = 1 << 13,
		OwnerDelete = 1 << 14,
	}

	public enum IcbRecordDisplayCharacteristics : byte
	{
		None = 0,
		LineFeedPrefixedCarriageReturnPostfixed = 1,
		FirstBytePositionDisplay = 2,
		ImpliedDisplay = 3,
	}

	public enum IcbRecordFormat : byte
	{
		None = 0,
		PaddedFixedLength = 1,
		FixedLength = 2,
		VariableLength8 = 3,
		VariableLength16 = 4,
		VariableLength16BigEndian = 5,
		VariableLength32 = 6,
		StreamPrint = 7,
		StreamLineFeed = 8,
		StreamCarriageReturn = 9,
		StreamCarriageReturnLineFeed = 10,
		StreamLineFeedCarriageReturn = 11,
	}
}