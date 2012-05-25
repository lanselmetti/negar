using System.Runtime.InteropServices;
using Helper;

namespace FileSystems.Udf
{
	[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
	public class Type2PartitionMap : PartitionMap
	{
		public Type2PartitionMap() : base(PartitionMapType.Type2, 64) { }
		protected override void MarshalFrom(BufferWithSize buffer) { base.MarshalFrom(buffer); }
		protected override void MarshalTo(BufferWithSize buffer) { base.MarshalTo(buffer); }
		protected override int MarshaledSize { get { return Marshaler.DefaultSizeOf<Type2PartitionMap>(); } }
	}
}