using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace FileSystems.Udf
{
	[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
	public class AllocationExtentDescriptor : TaggedDescriptor
	{
		[DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
		private static readonly IntPtr PREVIOUS_ALLOCATION_LOCATION_BP = (IntPtr)16; //Marshal.OffsetOf(typeof(AllocationExtentDescriptor), "_PreviousAllocationLocation");
		[DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
		private static readonly IntPtr LENGTH_OF_ALLOCATION_DESCRIPTORS_BP = (IntPtr)20; //Marshal.OffsetOf(typeof(AllocationExtentDescriptor), "_AllocationDescriptorsLength");
		[DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
		private static readonly IntPtr ALLOCATION_DESCRIPTORS_BP = (IntPtr)((int)LENGTH_OF_ALLOCATION_DESCRIPTORS_BP + sizeof(uint)); //Marshal.OffsetOf(typeof(AllocationExtentDescriptor), "_AllocationDescriptors");

		public AllocationExtentDescriptor() : base(DescriptorTagIdentifier.AllocationExtentDescriptor) { }

		[DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
		private uint _PreviousAllocationLocation;
		/// <summary>Must be unused and set to zero.</summary>
		public uint PreviousAllocationLocation { get { return this._PreviousAllocationLocation; } set { this._PreviousAllocationLocation = value; } }
		[DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
		private uint _AllocationDescriptorsLength;
		[DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
		private byte[] _AllocationDescriptors = EMPTY_BYTES; //Technically not part of descriptor
		public byte[] AllocationDescriptors { get { return this._AllocationDescriptors; } set { this._AllocationDescriptors = value; this._AllocationDescriptorsLength = value != null ? (uint)value.Length : 0; } }

		protected override void MarshalFromBeforeValidate(BufferWithSize buffer)
		{
			base.MarshalFromBeforeValidate(buffer);

			this._PreviousAllocationLocation = buffer.Read<uint>(PREVIOUS_ALLOCATION_LOCATION_BP);
			this._AllocationDescriptorsLength = buffer.Read<uint>(LENGTH_OF_ALLOCATION_DESCRIPTORS_BP);
			this._AllocationDescriptors = new byte[this._AllocationDescriptorsLength];
			buffer.CopyTo((int)ALLOCATION_DESCRIPTORS_BP, this._AllocationDescriptors, 0, this._AllocationDescriptorsLength);
		}

		protected override void MarshalToBeforeValidate(BufferWithSize buffer)
		{
			base.MarshalToBeforeValidate(buffer);

			buffer.Write(this._PreviousAllocationLocation, PREVIOUS_ALLOCATION_LOCATION_BP);
			buffer.Write(this._AllocationDescriptorsLength, LENGTH_OF_ALLOCATION_DESCRIPTORS_BP);
			buffer.CopyFrom((int)ALLOCATION_DESCRIPTORS_BP, this._AllocationDescriptors, 0, this._AllocationDescriptorsLength);
		}

		protected override int MarshaledSize { get { return (int)ALLOCATION_DESCRIPTORS_BP + (int)this._AllocationDescriptorsLength; } }
	}
}