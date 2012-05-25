using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace FileSystems.Udf
{
	[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
	public class UnallocatedSpaceDescriptor : TaggedDescriptor
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr VOLUME_DESCRIPTOR_SEQUENCE_NUMBER_BP = (IntPtr)16; //Marshal.OffsetOf(typeof(UnallocatedSpaceDescriptor), "_VolumeDescriptorSequenceNumber");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr ALLOCATION_DESCRIPTOR_COUNT_BP = (IntPtr)20; //Marshal.OffsetOf(typeof(UnallocatedSpaceDescriptor), "_AllocationDescriptorCount");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr ALLOCATION_DESCRIPTORS_BP = (IntPtr)24; //Marshal.OffsetOf(typeof(UnallocatedSpaceDescriptor), "_AllocationDescriptors");

		public UnallocatedSpaceDescriptor() : base(DescriptorTagIdentifier.UnallocatedSpaceDescriptor) { }

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private uint _VolumeDescriptorSequenceNumber;
		public uint VolumeDescriptorSequenceNumber { get { return this._VolumeDescriptorSequenceNumber; } set { this._VolumeDescriptorSequenceNumber = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private uint _AllocationDescriptorCount;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		private ExtentAllocationDescriptor[] _AllocationDescriptors = new ExtentAllocationDescriptor[0];
		public ExtentAllocationDescriptor[] AllocationDescriptors { get { return this._AllocationDescriptors; } set { this._AllocationDescriptors = value; this._AllocationDescriptorCount = value != null ? (uint)value.Length : 0; } }

		protected override void MarshalFromBeforeValidate(BufferWithSize buffer)
		{
			base.MarshalFromBeforeValidate(buffer);

			this._VolumeDescriptorSequenceNumber = buffer.Read<uint>(VOLUME_DESCRIPTOR_SEQUENCE_NUMBER_BP);
			this._AllocationDescriptorCount = buffer.Read<uint>(ALLOCATION_DESCRIPTOR_COUNT_BP);
			this._AllocationDescriptors = new ExtentAllocationDescriptor[this._AllocationDescriptorCount];
			var descriptorsBuffer = buffer.ExtractSegment(ALLOCATION_DESCRIPTORS_BP);
			for (int i = 0; i < this._AllocationDescriptors.Length; i++)
			{ unsafe { this._AllocationDescriptors[i] = Marshaler.PtrToStructure<ExtentAllocationDescriptor>(descriptorsBuffer.ExtractSegment(i * sizeof(ExtentAllocationDescriptor), sizeof(ExtentAllocationDescriptor))); } }
		}

		protected override void MarshalToBeforeValidate(BufferWithSize buffer)
		{
			base.MarshalToBeforeValidate(buffer);

			buffer.Write(this._VolumeDescriptorSequenceNumber, VOLUME_DESCRIPTOR_SEQUENCE_NUMBER_BP);
			buffer.Write(this._AllocationDescriptorCount, ALLOCATION_DESCRIPTOR_COUNT_BP);
			var descriptorsBuffer = buffer.ExtractSegment(ALLOCATION_DESCRIPTORS_BP);
			for (int i = 0; i < this._AllocationDescriptors.Length; i++)
			{ unsafe { Marshaler.StructureToPtr(this._AllocationDescriptors[i], descriptorsBuffer.ExtractSegment(i * sizeof(ExtentAllocationDescriptor), sizeof(ExtentAllocationDescriptor))); } }
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected override int MarshaledSize { get { return (int)ALLOCATION_DESCRIPTORS_BP + (int)this._AllocationDescriptorCount * Marshaler.DefaultSizeOf<ExtentAllocationDescriptor>(); } }

		public override object Clone() { var me = (UnallocatedSpaceDescriptor)base.Clone(); me._AllocationDescriptors = (ExtentAllocationDescriptor[])me._AllocationDescriptors.Clone(); return me; }
	}
}