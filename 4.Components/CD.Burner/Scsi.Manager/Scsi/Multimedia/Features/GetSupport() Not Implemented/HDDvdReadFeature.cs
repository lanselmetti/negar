using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    /// <summary>This feature identifies a drive that is able to read HD DVD specific information from the media. This feature indicates support for reading HD DVD specific structures.</summary>
    [Description(
        "This feature identifies a drive that is able to read HD DVD specific information from the media.\r\nThis feature indicates support for reading HD DVD specific structures."
        )]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class HDDvdReadFeature : MultimediaFeature
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly ScsiCommandCode[]
            __SupportedOperations =
                Sort(new[]
                         {
                             ScsiCommandCode.Read10, ScsiCommandCode.Read12, ScsiCommandCode.ReadDiscStructure,
                             ScsiCommandCode.ReadTocPmaAtip
                         });

        public override FeatureSupportKind GetSupport(ScsiCommand command)
        {
            return Array.BinarySearch(__SupportedOperations, command.OpCode) >= 0
                       ? FeatureSupportKind.Mandatory
                       : FeatureSupportKind.None;
        }

        public HDDvdReadFeature() : base(FeatureCode.HDDvdRead)
        {
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte4;

        [DisplayName("Read HD DVD-R")]
        public bool HDDvdR
        {
            get { return Bits.GetBit(byte4, 0); }
            set { byte4 = Bits.SetBit(byte4, 0, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte5;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte6;

        [DisplayName("Read HD DVD-RAM")]
        public bool HDDvdRam
        {
            get { return Bits.GetBit(byte6, 0); }
            set { byte6 = Bits.SetBit(byte6, 0, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte7;
    }
}