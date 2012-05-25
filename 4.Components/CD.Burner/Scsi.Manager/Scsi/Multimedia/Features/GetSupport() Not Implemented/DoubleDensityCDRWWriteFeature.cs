using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    /// <summary></summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class DoubleDensityCDRWWriteFeature : MultimediaFeature
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly ScsiCommandCode[]
            __SupportedOperations =
                Sort(new[]
                         {
                             ScsiCommandCode.ReadDiscInformation, ScsiCommandCode.ReadTrackInformation,
                             ScsiCommandCode.ReserveTrack, ScsiCommandCode.Write10, ScsiCommandCode.Write12
                         });

        public override FeatureSupportKind GetSupport(ScsiCommand command)
        {
            return Array.BinarySearch(__SupportedOperations, command.OpCode) >= 0
                       ? FeatureSupportKind.Mandatory
                       : FeatureSupportKind.None;
        }

        public DoubleDensityCDRWWriteFeature() : base(FeatureCode.DoubleDensityCDRWWrite)
        {
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte4;

        public bool Intermediate
        {
            get { return Bits.GetBit(byte4, 1); }
            set { byte4 = Bits.SetBit(byte4, 1, value); }
        }

        public bool Blank
        {
            get { return Bits.GetBit(byte4, 0); }
            set { byte4 = Bits.SetBit(byte4, 0, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte5;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte6;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte7;
    }
}