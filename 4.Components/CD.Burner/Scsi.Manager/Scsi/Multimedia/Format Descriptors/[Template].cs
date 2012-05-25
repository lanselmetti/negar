namespace Scsi.Multimedia
{
#if false

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public class Descriptor : FormatDescriptorOther
	{
		public Descriptor() : base(FormatType) { }
		public uint  { get { return this.TypeDependentParameter; } set { this.TypeDependentParameter = value; } }
	}
#endif
}