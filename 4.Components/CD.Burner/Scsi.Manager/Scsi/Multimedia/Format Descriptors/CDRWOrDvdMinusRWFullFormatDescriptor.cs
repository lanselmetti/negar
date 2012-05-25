using System.Runtime.InteropServices;

namespace Scsi.Multimedia
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class CDRWOrDvdMinusRWFullFormatDescriptor : FormatDescriptorOther
    {
        public CDRWOrDvdMinusRWFullFormatDescriptor() : base(FormatType.CDRWOrDvdMinusRWFullFormat)
        {
        }

        public CDRWOrDvdMinusRWFullFormatDescriptor(uint fixedPacketSizeOrErrorCorrectionCodeBlockSize) : this()
        {
            FixedPacketSizeOrErrorCorrectionCodeBlockSize = fixedPacketSizeOrErrorCorrectionCodeBlockSize;
        }

        public uint FixedPacketSizeOrErrorCorrectionCodeBlockSize
        {
            get { return TypeDependentParameter; }
            set { TypeDependentParameter = value; }
        }
    }
}