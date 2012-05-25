using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace FileSystems.Udf
{
	[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
	public sealed class UnknownVolumeStructureDescriptor : UdfVolumeStructureDescriptor
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr DATA_BP = (IntPtr)7; //Marshal.OffsetOf(typeof(UnknownDescriptor), "_Data");

		private UnknownVolumeStructureDescriptor() : this(null, 0) { }
		public UnknownVolumeStructureDescriptor(string standardID, byte version) : base(standardID, version) { }

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2041)]
		private byte[] _Data = new byte[2041];
		public byte[] Data { get { return this._Data; } }

		protected override void MarshalFrom(BufferWithSize buffer)
		{
			base.MarshalFrom(buffer);
			this._Data = new byte[2041];
			buffer.CopyTo((int)DATA_BP, this._Data, 0, this._Data.Length);
		}

		protected override void MarshalTo(BufferWithSize buffer)
		{
			base.MarshalTo(buffer);
			if (this._Data.Length > 2041) { throw new OverflowException("Field is too large."); }
			buffer.CopyFrom((int)DATA_BP, this._Data, 0, this._Data.Length);
			buffer.Initialize((int)DATA_BP + this._Data.Length, 2041 - this._Data.Length);
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected override int MarshaledSize { get { return Marshaler.DefaultSizeOf<UnknownVolumeStructureDescriptor>(); } }
	}
}