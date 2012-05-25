using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace FileSystems.Udf
{
	[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
	public abstract class InformationControlBlockDescriptor : TaggedDescriptor
	{
		//The maximum size of any ICB is one logical block; some ICBs have lower max sizes
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr PRIOR_RECORDED_DIRECT_ENTRY_COUNT_BP = (IntPtr)16; //Marshal.OffsetOf(typeof(InformationControlBlockDescriptor), "_PriorRecordedDirectEntryCount");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr STRATEGY_TYPE_BP = (IntPtr)20; //Marshal.OffsetOf(typeof(InformationControlBlockDescriptor), "_StrategyType");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr STRATEGY_PARAMETER_BP = (IntPtr)22; //Marshal.OffsetOf(typeof(InformationControlBlockDescriptor), "_StrategyParameter");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr MAXIMUM_ENTRY_COUNT_BP = (IntPtr)24; //Marshal.OffsetOf(typeof(InformationControlBlockDescriptor), "_MaximumEntryCount");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr RESERVED_BP = (IntPtr)26; //Marshal.OffsetOf(typeof(InformationControlBlockDescriptor), "_Reserved");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr FILE_TYPE_BP = (IntPtr)27; //Marshal.OffsetOf(typeof(InformationControlBlockDescriptor), "_FileType");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr PARENT_ICB_LOCATION_BP = (IntPtr)28; //Marshal.OffsetOf(typeof(InformationControlBlockDescriptor), "_ParentIcbLocation");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr FLAGS_BP = (IntPtr)34; //Marshal.OffsetOf(typeof(InformationControlBlockDescriptor), "_Flags");

		protected InformationControlBlockDescriptor(DescriptorTagIdentifier id, IcbFileType type) : base(id) { this.FileType = type; }

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private uint _PriorRecordedDirectEntryCount;
		/// <summary>The number of direct entries recorded in this ICB hierarchy prior to this entry.</summary>
		public uint PriorRecordedDirectEntryCount { get { return this._PriorRecordedDirectEntryCount; } set { this._PriorRecordedDirectEntryCount = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ushort _StrategyType = 4;
		/// <summary>The strategy for building the ICB hierarchy of which the ICB is a member.</summary>
		public ushort StrategyType { get { return this._StrategyType; } set { this._StrategyType = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ushort _StrategyParameter;
		/// <summary>Interpreted according to the strategy specified by the <see cref="StrategyType"/> field.</summary>
		public ushort StrategyParameter { get { return this._StrategyParameter; } set { this._StrategyParameter = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ushort _MaximumEntryCount;
		/// <summary>This field specifies the maximum number of entries, including both direct and indirect, that may be recorded in this ICB. This field must be greater than zero.</summary>
		public ushort MaximumEntryCount { get { return this._MaximumEntryCount; } set { this._MaximumEntryCount = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private byte _Reserved;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private IcbFileType _FileType;
		/// <summary></summary>
		public IcbFileType FileType { get { return this._FileType; } private set { this._FileType = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private LogicalBlockAddress _ParentIcbLocation;
		/// <summary>Indicate the previously recorded ICB identifying this file. If this field is zero, no such ICB is specified. (An ICB at LBA <c>0</c> on partition <c>0</c> cannot be identified by this field.)</summary>
		public LogicalBlockAddress ParentIcbLocation { get { return this._ParentIcbLocation; } set { this._ParentIcbLocation = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private IcbFlags _Flags;
		public IcbFlags Flags { get { return this._Flags; } set { this._Flags = value; } }

		protected override void MarshalFromBeforeValidate(BufferWithSize buffer)
		{
			base.MarshalFromBeforeValidate(buffer);

			this._PriorRecordedDirectEntryCount = buffer.Read<uint>(PRIOR_RECORDED_DIRECT_ENTRY_COUNT_BP);
			this._StrategyType = buffer.Read<ushort>(STRATEGY_TYPE_BP);
			this._StrategyParameter = buffer.Read<ushort>(STRATEGY_PARAMETER_BP);
			this._MaximumEntryCount = buffer.Read<ushort>(MAXIMUM_ENTRY_COUNT_BP);
			this._Reserved = buffer.Read<byte>(RESERVED_BP);
			this._FileType = buffer.Read<IcbFileType>(FILE_TYPE_BP);
			this._ParentIcbLocation = buffer.Read<LogicalBlockAddress>(PARENT_ICB_LOCATION_BP);
			this._Flags = buffer.Read<IcbFlags>(FLAGS_BP);
		}

		protected override void MarshalToBeforeValidate(BufferWithSize buffer)
		{
			base.MarshalToBeforeValidate(buffer);

			buffer.Write(this._PriorRecordedDirectEntryCount, PRIOR_RECORDED_DIRECT_ENTRY_COUNT_BP);
			buffer.Write(this._StrategyType, STRATEGY_TYPE_BP);
			buffer.Write(this._StrategyParameter, STRATEGY_PARAMETER_BP);
			buffer.Write(this._MaximumEntryCount, MAXIMUM_ENTRY_COUNT_BP);
			buffer.Write(this._Reserved, RESERVED_BP);
			buffer.Write(this._FileType, FILE_TYPE_BP);
			buffer.Write(this._ParentIcbLocation, PARENT_ICB_LOCATION_BP);
			buffer.Write(this._Flags, FLAGS_BP);
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected override int MarshaledSize { get { return (int)FLAGS_BP + sizeof(IcbFlags); } }

		public static IcbFileType ReadFileType(BufferWithSize buffer) { return buffer.Read<IcbFileType>(FILE_TYPE_BP); }
	}

	[Flags]
	public enum IcbFlags : short
	{
		None = 0,
		Sorted = 1 << 3,
		NonRelocatable = 1 << 4,
		Archive = 1 << 5,
		SetUserIdentifier = 1 << 6,
		SetGroupIdentifier = 1 << 7,
		Sticky = 1 << 8,
		Contiguous = 1 << 9,
		System = 1 << 10,
		Transformed = 1 << 11,
		MultiVersion = 1 << 12,

		/// <summary>You cannot use this value directly; you must logically AND the flags with this value and test it against <see cref="AllocationDescriptorType"/>.</summary>
		AllocationDescriptorTypeMask = 3,
	}

	public enum AllocationDescriptorType : byte
	{
		ShortAllocationDescriptors = 0, //NOT a flag!
		LongAllocationDescriptors = 1,
		ExtendedAllocationDescriptors = 2,
		DataResidentInAllocationDescriptors = 3,
	}

	public enum IcbFileType : byte
	{
		None = 0,
		UnallocatedSpaceEntry = 1,
		PartitionIntegrityEntry = 2,
		IndirectEntry = 3,
		Directory = 4,
		RandomAccessByteSequenceFile = 5,
		BlockSpecialDeviceFile = 6,
		CharacterSpecialDeviceFile = 7,
		ExtendedAttributeFile = 8,
		FirstInFirstOutFile = 9,
		ISSOCKFile = 10,
		TerminalEntry = 11,
		SymbolicLink = 12,
		StreamDirectory = 13,
	}
}