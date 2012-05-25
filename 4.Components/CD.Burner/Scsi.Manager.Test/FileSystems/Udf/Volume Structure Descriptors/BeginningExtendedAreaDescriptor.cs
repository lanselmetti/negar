using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace FileSystems.Udf
{
	[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
	public class BeginningExtendedAreaDescriptor : UdfVolumeStructureDescriptor
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr STRUCTURE_DATA_BP = (IntPtr)7; //Marshal.OffsetOf(typeof(BeginningExtendedAreaDescriptor), "_StructureData");
		public BeginningExtendedAreaDescriptor() : base("BEA01", 1) { }

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2041)]
		private byte[] _StructureData = new byte[2041];
		public byte[] StructureData { get { return this._StructureData; } }

		protected override void MarshalFrom(BufferWithSize buffer)
		{
			base.MarshalFrom(buffer);
			this._StructureData = new byte[2041];
			buffer.CopyTo((int)STRUCTURE_DATA_BP, this._StructureData, 0, this._StructureData.Length);
		}

		protected override void MarshalTo(BufferWithSize buffer)
		{
			base.MarshalTo(buffer);
			if (this._StructureData.Length > 2041) { throw new OverflowException("Field is too large."); }
			buffer.CopyFrom((int)STRUCTURE_DATA_BP, this._StructureData, 0, this._StructureData.Length);
			buffer.Initialize((int)STRUCTURE_DATA_BP + this._StructureData.Length, 2041 - this._StructureData.Length);
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected override int MarshaledSize { get { return Marshaler.DefaultSizeOf<BeginningExtendedAreaDescriptor>(); } }
	}
}