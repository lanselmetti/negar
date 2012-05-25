using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace FileSystems.Udf
{
	[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
	public class TerminalInformationControlBlockDescriptor : InformationControlBlockDescriptor
	{
		public TerminalInformationControlBlockDescriptor() : base(DescriptorTagIdentifier.TerminalEntry, IcbFileType.TerminalEntry) { }
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected override int MarshaledSize { get { return base.MarshaledSize; } }
	}
}