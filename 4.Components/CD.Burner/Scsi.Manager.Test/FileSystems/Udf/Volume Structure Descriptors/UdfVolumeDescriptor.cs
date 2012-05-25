using System.Runtime.InteropServices;
using Helper;

namespace FileSystems.Udf
{
	[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
	public abstract class UdfVolumeStructureDescriptor : VolumeStructureDescriptor
	{
		protected UdfVolumeStructureDescriptor(string standardID, byte version) : base(0, standardID, version) { }
		protected override void MarshalFrom(BufferWithSize buffer) { base.MarshalFrom(buffer); }
		protected override void MarshalTo(BufferWithSize buffer) { base.MarshalTo(buffer); }
		protected override int MarshaledSize { get { return Marshaler.DefaultSizeOf<UdfVolumeStructureDescriptor>(); } }
	}
}