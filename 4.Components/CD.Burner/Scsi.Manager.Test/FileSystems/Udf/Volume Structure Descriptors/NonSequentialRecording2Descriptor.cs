using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace FileSystems.Udf
{
	[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
	public class NonSequentialRecording2Descriptor : UdfVolumeStructureDescriptor
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr RESERVED1_BP = (IntPtr)7; //Marshal.OffsetOf(typeof(NonSequentialRecording2Descriptor), "_Reserved1");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr STRUCTURE_DATA_BP = (IntPtr)8; //Marshal.OffsetOf(typeof(NonSequentialRecording2Descriptor), "_StructureData");

		public NonSequentialRecording2Descriptor() : base("NSR02", 1) { }

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private byte _Reserved1;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2040)]
		private byte[] _StructureData = new byte[2040];
		public byte[] StructureData { get { return this._StructureData; } }

		protected override void MarshalFrom(BufferWithSize buffer)
		{
			base.MarshalFrom(buffer);
			this._Reserved1 = buffer.Read<byte>(RESERVED1_BP);
			this._StructureData = new byte[2040];
			buffer.CopyTo((int)STRUCTURE_DATA_BP, this._StructureData, 0, this._StructureData.Length);
		}

		protected override void MarshalTo(BufferWithSize buffer)
		{
			base.MarshalTo(buffer);
			buffer.Write(this._Reserved1, RESERVED1_BP);
			if (this._StructureData.Length > 2040) { throw new OverflowException("Field is too large."); }
			buffer.CopyFrom((int)STRUCTURE_DATA_BP, this._StructureData, 0, this._StructureData.Length);
			buffer.Initialize((int)STRUCTURE_DATA_BP + this._StructureData.Length, 2040 - this._StructureData.Length);
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected override int MarshaledSize { get { return Marshaler.DefaultSizeOf<NonSequentialRecording2Descriptor>(); } }
	}
}