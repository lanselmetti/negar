using System.Runtime.InteropServices;

namespace Scsi.Multimedia
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class ZoneFormatDescriptor : FormatDescriptorOther
    {
        public ZoneFormatDescriptor() : base(FormatType.ZoneFormat)
        {
        }

        public uint ZoneNumber
        {
            get { return TypeDependentParameter; }
            set { TypeDependentParameter = value; }
        }
    }
}