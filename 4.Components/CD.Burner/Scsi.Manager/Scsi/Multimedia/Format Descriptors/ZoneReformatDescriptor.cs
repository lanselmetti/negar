using System.Runtime.InteropServices;

namespace Scsi.Multimedia
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class ZoneReformatDescriptor : FormatDescriptorOther
    {
        public ZoneReformatDescriptor() : base(FormatType.ZoneReformat)
        {
        }

        public uint ZoneNumber
        {
            get { return TypeDependentParameter; }
            set { TypeDependentParameter = value; }
        }
    }
}