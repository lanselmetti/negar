using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    /// <summary>This feature identifies a drive that is able to read CD specific information from the media and is able to read user data from all types of CD sectors.</summary>
    [Description(
        "This feature identifies a drive that is able to read CD specific information from the media and is able to read user data from all types of CD sectors."
        )]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class CDReadFeature : MultimediaFeature
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly ScsiCommandCode[]
            __SupportedOperations =
                Sort(new[]
                         {
                             ScsiCommandCode.ReadCD, ScsiCommandCode.ReadCDMinuteSecondFrame,
                             ScsiCommandCode.ReadTocPmaAtip
                         });

        public override FeatureSupportKind GetSupport(ScsiCommand command)
        {
            return Array.BinarySearch(__SupportedOperations, command.OpCode) >= 0
                   &&
                   (command.OpCode != ScsiCommandCode.ReadTocPmaAtip ||
                    (((ReadTocPmaAtipCommand) command).Format != ReadTocPmaAtipDataFormat.AbsoluteTimeInPreGroove &&
                     (CDText ||
                      ((ReadTocPmaAtipCommand) command).Format != ReadTocPmaAtipDataFormat.CDTextInRWSubChannel)))
                       ? FeatureSupportKind.Mandatory
                       : FeatureSupportKind.None;
        }

        public CDReadFeature() : base(FeatureCode.CDRead)
        {
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte4;

        [DisplayName("C2 Error Pointers")]
        public bool C2Flags
        {
            get { return Bits.GetBit(byte4, 1); }
            set { byte4 = Bits.SetBit(byte4, 1, value); }
        }

        [DisplayName("CD-TEXT")]
        public bool CDText
        {
            get { return Bits.GetBit(byte4, 0); }
            set { byte4 = Bits.SetBit(byte4, 0, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte5;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte6;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte7;
    }
}