using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace FileSystems.Udf
{
	[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
	public class IndirectInformationControlBlockDescriptor : InformationControlBlockDescriptor
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr TARGET_INFORMATION_CONTROL_BLOCK_BP = (IntPtr)36; //Marshal.OffsetOf(typeof(IndirectInformationControlBlockDescriptor), "_TargetInformationControlBlock");

		public IndirectInformationControlBlockDescriptor() : base(DescriptorTagIdentifier.IndirectEntry, IcbFileType.IndirectEntry) { }

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private LongAllocationDescriptor _TargetInformationControlBlock;
		public LongAllocationDescriptor TargetInformationControlBlock { get { return this._TargetInformationControlBlock; } set { this._TargetInformationControlBlock = value; } }

		protected override void MarshalFromBeforeValidate(BufferWithSize buffer)
		{
			base.MarshalFromBeforeValidate(buffer);

			this._TargetInformationControlBlock = buffer.Read<LongAllocationDescriptor>(TARGET_INFORMATION_CONTROL_BLOCK_BP);
		}

		protected override void MarshalToBeforeValidate(BufferWithSize buffer)
		{
			base.MarshalToBeforeValidate(buffer);

			buffer.Write(this._TargetInformationControlBlock, TARGET_INFORMATION_CONTROL_BLOCK_BP);
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected override int MarshaledSize { get { return (int)TARGET_INFORMATION_CONTROL_BLOCK_BP + Marshaler.DefaultSizeOf<LongAllocationDescriptor>(); } }
	}
}