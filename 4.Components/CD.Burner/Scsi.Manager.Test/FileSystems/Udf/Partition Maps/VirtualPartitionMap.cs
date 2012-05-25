using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace FileSystems.Udf
{
	[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
	public class VirtualPartitionMap : UdfType2PartitionMap
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr RESERVED_BP = (IntPtr)2; //Marshal.OffsetOf(typeof(VirtualPartitionMap), "_Reserved");

		public VirtualPartitionMap() : base(new EntityIdentifier(EntityIdentifierFlags.None, EntityIdentifier.VirtualPartitionMapPartitionTypeId, 0)) { }

		protected override void MarshalFrom(BufferWithSize buffer)
		{
			base.MarshalFrom(buffer);
			this._Reserved = new byte[24];
			buffer.CopyTo((int)RESERVED_BP, this._Reserved, 0, this._Reserved.Length);
		}

		protected override void MarshalTo(BufferWithSize buffer)
		{
			base.MarshalTo(buffer);
			if (this._Reserved.Length > 24) { throw new OverflowException("Field is too large."); }
			buffer.CopyFrom((int)RESERVED_BP, this._Reserved, 0, this._Reserved.Length);
			buffer.Initialize((int)RESERVED_BP + this._Reserved.Length, 24 - this._Reserved.Length);
		}

		protected override int MarshaledSize { get { return Marshaler.DefaultSizeOf<VirtualPartitionMap>(); } }

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
		private byte[] _Reserved = new byte[24];

		public override object Clone() { var me = (VirtualPartitionMap)base.Clone(); me._Reserved = (byte[])me._Reserved.Clone(); return me; }
	}
}