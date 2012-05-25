using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    /// <summary>This feature indicates that the drive is capable of reading a disc with the MRW format.</summary>
    [Description("This feature indicates that the drive is capable of reading a disc with the MRW format.")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class MountRainierRewritableFeature : MultimediaFeature
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly ScsiCommandCode[]
            __SupportedOperations = new[]
                                        {
                                            ScsiCommandCode.GetEventStatusNotification, ScsiCommandCode.Read10,
                                            ScsiCommandCode.Read12, ScsiCommandCode.ReadCapacity,
                                            ScsiCommandCode.ReadDiscInformation,
                                            /*The rest are for write only*/ScsiCommandCode.CloseSessionOrTrack,
                                            ScsiCommandCode.Format, ScsiCommandCode.Write10,
                                            ScsiCommandCode.WriteAndVerify10, ScsiCommandCode.Verify10,
                                            ScsiCommandCode.ReadFormatCapacities
                                        };

        public override FeatureSupportKind GetSupport(ScsiCommand command)
        {
            return Array.BinarySearch(__SupportedOperations, command.OpCode) >= 0
                       ? FeatureSupportKind.Mandatory
                       : FeatureSupportKind.None;
        }

        public MountRainierRewritableFeature() : base(FeatureCode.MountRainierRewritable)
        {
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte4;

        [DisplayName("Format and Write CD-MRW")]
        public bool CDWrite
        {
            get { return Bits.GetBit(byte4, 0); }
            set { byte4 = Bits.SetBit(byte4, 0, value); }
        }

        [DisplayName("Read DVD+MRW")]
        public bool DvdPlusRead
        {
            get { return Bits.GetBit(byte4, 1); }
            set { byte4 = Bits.SetBit(byte4, 1, value); }
        }

        [DisplayName("Format and Write DVD+MRW")]
        public bool DvdPlusWrite
        {
            get { return Bits.GetBit(byte4, 2); }
            set { byte4 = Bits.SetBit(byte4, 2, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte5;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte6;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte7;
    }
}