using System.Runtime.InteropServices;

namespace Scsi.Multimedia
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class CDRWOrDvdMinusRWGrowSessionDescriptor : FormatDescriptorOther
    {
        public CDRWOrDvdMinusRWGrowSessionDescriptor() : base(FormatType.CDRWOrDvdMinusRWGrowSession)
        {
        }

        public uint PacketLength
        {
            get { return TypeDependentParameter; }
            set { TypeDependentParameter = value; }
        }
    }
}