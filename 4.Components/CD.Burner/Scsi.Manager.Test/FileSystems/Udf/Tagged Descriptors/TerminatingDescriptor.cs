using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace FileSystems.Udf
{
	[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
	public class TerminatingDescriptor : TaggedDescriptor
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr RESERVED_BP = (IntPtr)16; //Marshal.OffsetOf(typeof(TerminatingDescriptor), "_Reserved");

		public TerminatingDescriptor() : base(DescriptorTagIdentifier.TerminatingDescriptor) { }

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 496)]
		private byte[] _Reserved = EMPTY_BYTES; //new byte[496];

		protected override void MarshalFromBeforeValidate(BufferWithSize buffer)
		{
			base.MarshalFromBeforeValidate(buffer);

			this._Reserved = new byte[496];
			buffer.CopyTo((int)RESERVED_BP, this._Reserved, 0, this._Reserved.Length);
		}

		protected override void MarshalToBeforeValidate(BufferWithSize buffer)
		{
			base.MarshalToBeforeValidate(buffer);

			if (this._Reserved.Length > 496) { throw new OverflowException("Field is too large."); }
			buffer.CopyFrom((int)RESERVED_BP, this._Reserved, 0, this._Reserved.Length);
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected override int MarshaledSize { get { return 512; } }

		public override object Clone() { var me = (TerminatingDescriptor)base.Clone(); me._Reserved = (byte[])me._Reserved.Clone(); return me; }
	}
}