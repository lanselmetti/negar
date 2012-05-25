using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    /// <summary>This feature identifies reporting capability and changing capability for write protection status of the drive.</summary>
    [Description(
        "This feature identifies reporting capability and changing capability for write protection status of the drive."
        )]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class WriteProtectFeature : MultimediaFeature
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly ScsiCommandCode[]
            __SupportedOperations =
                Sort(new[]
                         {
                             ScsiCommandCode.ReadDiscInformation, ScsiCommandCode.ReadDiscStructure,
                             ScsiCommandCode.SendDiscStructure
                         });

        public override FeatureSupportKind GetSupport(ScsiCommand command)
        {
            return Array.BinarySearch(__SupportedOperations, command.OpCode) >= 0
                       ? FeatureSupportKind.Mandatory
                       : FeatureSupportKind.None;
        }


        public WriteProtectFeature() : base(FeatureCode.WriteProtect)
        {
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte4;

        [DisplayName("Read/Write Disc Write Protect PAC on BD")]
        public bool DWP
        {
            get { return Bits.GetBit(byte4, 3); }
            set { byte4 = Bits.SetBit(byte4, 3, value); }
        }

        [DisplayName("Write Inhibit DCB on DVD+RW")]
        public bool WDCB
        {
            get { return Bits.GetBit(byte4, 2); }
            set { byte4 = Bits.SetBit(byte4, 2, value); }
        }

        [DisplayName("Set PWP Status")]
        public bool SPWP
        {
            get { return Bits.GetBit(byte4, 1); }
            set { byte4 = Bits.SetBit(byte4, 1, value); }
        }

        [DisplayName("SPWP in Timeout")]
        public bool SSWPP
        {
            get { return Bits.GetBit(byte4, 0); }
            set { byte4 = Bits.SetBit(byte4, 0, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte5;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte6;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte7;
    }
}