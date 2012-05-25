using System.Runtime.InteropServices;

namespace Scsi.Multimedia
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class MountRainierRewritableFullFormatDescriptor : FormatDescriptorOther
    {
        public MountRainierRewritableFullFormatDescriptor() : base(FormatType.MountRainierRewritableFormat)
        {
            NumberOfBlocks = ~0U;
        }

        public MountRainierRewritableFullFormatDescriptor(MountRainierRewritableFormatOption options) : this()
        {
            FormatOptions = options;
        }

        public MountRainierRewritableFormatOption FormatOptions
        {
            get { return (MountRainierRewritableFormatOption) TypeDependentParameter; }
            set { TypeDependentParameter = (uint) value; }
        }
    }

    public enum MountRainierRewritableFormatOption
    {
        NewFormat = 0x00000000,
        RestartFormat = 0x00000001,
    }
}