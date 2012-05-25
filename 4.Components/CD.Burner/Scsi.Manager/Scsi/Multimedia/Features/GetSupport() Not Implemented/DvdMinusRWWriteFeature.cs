using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    /// <summary>This feature identifies a drive that has the ability to write data to DVD-R/-RW in disc at once mode.</summary>
    [Description("This feature identifies a drive that has the ability to write data to DVD-R/-RW in disc at once mode."
        )]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class DvdMinusRWWriteFeature : MultimediaFeature
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly ScsiCommandCode[]
            __SupportedOperations =
                Sort(new[]
                         {
                             ScsiCommandCode.Blank, ScsiCommandCode.ReadDiscInformation,
                             ScsiCommandCode.ReadTrackInformation, ScsiCommandCode.ReserveTrack,
                             ScsiCommandCode.SendDiscStructure, ScsiCommandCode.Write10
                         });

        public override FeatureSupportKind GetSupport(ScsiCommand command)
        {
            return Array.BinarySearch(__SupportedOperations, command.OpCode) >= 0
                       ? FeatureSupportKind.Mandatory
                       : FeatureSupportKind.None;
        }

        public DvdMinusRWWriteFeature() : base(FeatureCode.DvdMinusRWWrite)
        {
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte4;

        [DisplayName("Buffer Under-run Protection")]
        public bool BufferUnderrunProtection
        {
            get { return Bits.GetBit(byte4, 6); }
            set { byte4 = Bits.SetBit(byte4, 6, value); }
        }

        [DisplayName("Write DVD-RW DL")]
        public bool DvdRDL
        {
            get { return Bits.GetBit(byte4, 6); }
            set { byte4 = Bits.SetBit(byte4, 6, value); }
        }

        [DisplayName("Simulation")]
        public bool TestWrite
        {
            get { return Bits.GetBit(byte4, 2); }
            set { byte4 = Bits.SetBit(byte4, 2, value); }
        }

        [DisplayName("Write and Erase DVD-RW")]
        public bool DvdMinusRW
        {
            get { return Bits.GetBit(byte4, 1); }
            set { byte4 = Bits.SetBit(byte4, 1, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte5;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte6;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte7;
    }
}