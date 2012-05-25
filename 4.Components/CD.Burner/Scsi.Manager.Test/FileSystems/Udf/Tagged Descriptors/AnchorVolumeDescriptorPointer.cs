using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace FileSystems.Udf
{
	[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
	public class AnchorVolumeDescriptorPointer : TaggedDescriptor
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr MAIN_VOLUME_DESCRIPTOR_SEQUENCE_EXTENT_BP = (IntPtr)16; //Marshal.OffsetOf(typeof(AnchorVolumeDescriptorPointer), "_MainVolumeDescriptorSequenceExtent");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr RESERVE_VOLUME_DESCRIPTOR_SEQUENCE_EXTENT_BP = (IntPtr)24; //Marshal.OffsetOf(typeof(AnchorVolumeDescriptorPointer), "_ReserveVolumeDescriptorSequenceExtent");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr RESERVED_BP = (IntPtr)32; //Marshal.OffsetOf(typeof(AnchorVolumeDescriptorPointer), "_Reserved");

		public AnchorVolumeDescriptorPointer() : base(DescriptorTagIdentifier.AnchorVolumeDescriptorPointer) { }

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ExtentAllocationDescriptor _MainVolumeDescriptorSequenceExtent;
		/// <summary>The extent of the Main Volume Descriptor Sequence.</summary>
		/// <remarks>
		/// <para>The extent specifies allocation rather than recording; that is, space that may be available for recording rather than what is actually recorded. The extent need not be completely recorded.</para>
		/// <para>The Main Volume Descriptor Sequence must have a minimum length of <c>16</c> logical sectors.</para>
		/// </remarks>
		public ExtentAllocationDescriptor MainVolumeDescriptorSequenceExtent { get { return this._MainVolumeDescriptorSequenceExtent; } set { this._MainVolumeDescriptorSequenceExtent = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ExtentAllocationDescriptor _ReserveVolumeDescriptorSequenceExtent;
		/// <summary>The extent of the Reserve Volume Descriptor Sequence.</summary>
		/// <remarks>
		/// <para>The extent specifies allocation rather than recording; that is, space that may be available for recording rather than what is actually recorded. The extent need not be completely recorded.</para>
		/// <para>The Reserve Volume Descriptor Sequence must have a minimum length of <c>16</c> logical sectors.</para>
		/// </remarks>
		public ExtentAllocationDescriptor ReserveVolumeDescriptorSequenceExtent { get { return this._ReserveVolumeDescriptorSequenceExtent; } set { this._ReserveVolumeDescriptorSequenceExtent = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 480)]
		private byte[] _Reserved = EMPTY_BYTES; //new byte[480];

		protected override void MarshalFromBeforeValidate(BufferWithSize buffer)
		{
			base.MarshalFromBeforeValidate(buffer);

			this._MainVolumeDescriptorSequenceExtent = buffer.Read<ExtentAllocationDescriptor>(MAIN_VOLUME_DESCRIPTOR_SEQUENCE_EXTENT_BP);
			this._ReserveVolumeDescriptorSequenceExtent = buffer.Read<ExtentAllocationDescriptor>(RESERVE_VOLUME_DESCRIPTOR_SEQUENCE_EXTENT_BP);
			this._Reserved = new byte[480];
			buffer.CopyTo((int)RESERVED_BP, this._Reserved, 0, this._Reserved.Length);
		}

		protected override void MarshalToBeforeValidate(BufferWithSize buffer)
		{
			base.MarshalToBeforeValidate(buffer);

			buffer.Write(this._MainVolumeDescriptorSequenceExtent, MAIN_VOLUME_DESCRIPTOR_SEQUENCE_EXTENT_BP);
			buffer.Write(this._ReserveVolumeDescriptorSequenceExtent, RESERVE_VOLUME_DESCRIPTOR_SEQUENCE_EXTENT_BP);
			if (this._Reserved.Length > 480) { throw new OverflowException("Field is too large."); }
			buffer.CopyFrom((int)RESERVED_BP, this._Reserved, 0, this._Reserved.Length);
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected override int MarshaledSize { get { return 512; } }

		public override object Clone() { var me = (AnchorVolumeDescriptorPointer)base.Clone(); me._Reserved = (byte[])me._Reserved.Clone(); return me; }
	}
}