using System.Runtime.InteropServices;

namespace Scsi.Multimedia
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class CDRWOrDvdMinusRWAddSessionDescriptor : FormatDescriptorOther
    {
        public CDRWOrDvdMinusRWAddSessionDescriptor() : base(FormatType.CDRWOrDvdMinusRWAddSession)
        {
        }

        public uint FixedPacketSizeOrErrorCorrectionCodeBlockSize
        {
            get { return TypeDependentParameter; }
            set { TypeDependentParameter = value; }
        }
    }
}