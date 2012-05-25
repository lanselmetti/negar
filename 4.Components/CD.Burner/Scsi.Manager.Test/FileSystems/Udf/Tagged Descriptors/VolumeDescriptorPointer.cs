using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace FileSystems.Udf
{
	[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
	public class VolumeDescriptorPointer : TaggedDescriptor
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr VOLUME_DESCRIPTOR_SEQUENCE_NUMBER_BP = (IntPtr)16; //Marshal.OffsetOf(typeof(VolumeDescriptorPointer), "_VolumeDescriptorSequenceNumber");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr NEXT_VOLUME_DESCRIPTOR_SEQUENCE_EXTENT_BP = (IntPtr)20; //Marshal.OffsetOf(typeof(VolumeDescriptorPointer), "_NextVolumeDescriptorSequenceExtent");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr RESERVED_BP = (IntPtr)28; //Marshal.OffsetOf(typeof(VolumeDescriptorPointer), "_Reserved");

		public VolumeDescriptorPointer() : base(DescriptorTagIdentifier.VolumeDescriptorPointer) { }

		[DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
		private uint _VolumeDescriptorSequenceNumber;
		public uint VolumeDescriptorSequenceNumber { get { return this._VolumeDescriptorSequenceNumber; } set { this._VolumeDescriptorSequenceNumber = value; } }
		[DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
		private ExtentAllocationDescriptor _NextVolumeDescriptorSequenceExtent;
		public ExtentAllocationDescriptor NextVolumeDescriptorSequenceExtent { get { return this._NextVolumeDescriptorSequenceExtent; } set { this._NextVolumeDescriptorSequenceExtent = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 484)]
		private byte[] _Reserved = EMPTY_BYTES; //new byte[484];

		protected override void MarshalFromBeforeValidate(BufferWithSize buffer)
		{
			base.MarshalFromBeforeValidate(buffer);

			this._VolumeDescriptorSequenceNumber = buffer.Read<uint>(VOLUME_DESCRIPTOR_SEQUENCE_NUMBER_BP);
			this._NextVolumeDescriptorSequenceExtent = buffer.Read<ExtentAllocationDescriptor>(NEXT_VOLUME_DESCRIPTOR_SEQUENCE_EXTENT_BP);
			this._Reserved = new byte[484];
			buffer.CopyTo((int)RESERVED_BP, this._Reserved, 0, this._Reserved.Length);
		}

		protected override void MarshalToBeforeValidate(BufferWithSize buffer)
		{
			base.MarshalToBeforeValidate(buffer);

			buffer.Write(this._VolumeDescriptorSequenceNumber, VOLUME_DESCRIPTOR_SEQUENCE_NUMBER_BP);
			buffer.Write(this._NextVolumeDescriptorSequenceExtent, NEXT_VOLUME_DESCRIPTOR_SEQUENCE_EXTENT_BP);
			if (this._Reserved.Length > 484) { throw new OverflowException("Field is too large."); }
			buffer.CopyFrom((int)RESERVED_BP, this._Reserved, 0, this._Reserved.Length);
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected override int MarshaledSize { get { return 512; } }

		public override object Clone() { var me = (VolumeDescriptorPointer)base.Clone(); me._Reserved = (byte[])me._Reserved.Clone(); return me; }
	}
}