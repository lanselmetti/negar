using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    /// <summary>This feature identifies a drive that is able to perform reading and writing within host specified (and drive verified) performance ranges. This feature also indicates whether the drive GetSupport the Stream playback.</summary>
    [Description(
        "This feature identifies a drive that is able to perform reading and writing within host specified (and drive verified) performance ranges.\r\nThis feature also indicates whether the drive GetSupport the Stream playback."
        )]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class RealTimeStreamingFeature : MultimediaFeature
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly ScsiCommandCode[]
            __SupportedOperations =
                Sort(new[]
                         {
                             ScsiCommandCode.GetPerformance, ScsiCommandCode.Read12, ScsiCommandCode.ReadBufferCapacity,
                             ScsiCommandCode.SetStreaming, ScsiCommandCode.Write12
                         });

        public override FeatureSupportKind GetSupport(ScsiCommand command)
        {
            return Array.BinarySearch(__SupportedOperations, command.OpCode) >= 0
                       ? FeatureSupportKind.Mandatory
                       : FeatureSupportKind.None;
        }

        public RealTimeStreamingFeature() : base(FeatureCode.RealTimeStreaming)
        {
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte4;

        [DisplayName("Read Buffer Capacity Block")]
        public bool ReadBufferCapacityBlock
        {
            get { return Bits.GetBit(byte4, 4); }
            set { byte4 = Bits.SetBit(byte4, 4, value); }
        }

        [DisplayName("Set CD Speed")]
        public bool SetCDSpeed
        {
            get { return Bits.GetBit(byte4, 3); }
            set { byte4 = Bits.SetBit(byte4, 3, value); }
        }

        [DisplayName("Extended Capabilities and Mechanical Status Page")]
        public bool ModePage2A
        {
            get { return Bits.GetBit(byte4, 2); }
            set { byte4 = Bits.SetBit(byte4, 2, value); }
        }

        [DisplayName("Write Speed Performance Descriptor")]
        public bool WriteSpeedPerformanceDescriptor
        {
            get { return Bits.GetBit(byte4, 1); }
            set { byte4 = Bits.SetBit(byte4, 1, value); }
        }

        [DisplayName("Stream Writing")]
        public bool StreamWriting
        {
            get { return Bits.GetBit(byte4, 0); }
            set { byte4 = Bits.SetBit(byte4, 0, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte5;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte6;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte7;
    }
}