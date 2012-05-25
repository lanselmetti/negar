using System.Runtime.InteropServices;

namespace Scsi.Multimedia
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class SpareAreaExpansionDescriptor : FormatDescriptorOther
    {
        public SpareAreaExpansionDescriptor() : base(FormatType.SpareAreaExpansion)
        {
        }

        public uint BlockLength
        {
            get { return TypeDependentParameter; }
            set { TypeDependentParameter = value; }
        }
    }
}