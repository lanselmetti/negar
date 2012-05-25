using System.Runtime.InteropServices;

namespace Scsi.Multimedia
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class DvdPlusRWBasicFormatDescriptor : FormatDescriptorOther
    {
        public DvdPlusRWBasicFormatDescriptor() : base(FormatType.DvdPlusRWBasicFormat)
        {
        }

        /// <param name="formatMode">Zero to indicate a new format, or one to indicate a complete format</param>
        public DvdPlusRWBasicFormatDescriptor(uint formatMode) : this()
        {
            FormatMode = formatMode;
        }

        /// <summary>This should be zero to indicate a new format, or one to indicate a complete format.</summary>
        public uint FormatMode
        {
            get { return TypeDependentParameter; }
            set { TypeDependentParameter = value; }
        }
    }
}