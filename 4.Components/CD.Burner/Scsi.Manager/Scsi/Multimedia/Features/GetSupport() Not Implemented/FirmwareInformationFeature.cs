using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    /// <summary>This feature indicates that the drive provides the date and time of the creation of the current firmware revision loaded on the device. The date and time is the date and time of creation of the firmware version. The date and time is GMT. The date and time do not change for a given firmware revision. The date and time is later on “newer” firmware for a given device. This feature is persistent and current if present. No commands are required for this feature.</summary>
    [Description(
        "This feature indicates that the drive provides the date and time of the creation of the current firmware revision loaded on the device.\r\nThe date and time is the date and time of creation of the firmware version.\r\nThe date and time is GMT.\r\nThe date and time do not change for a given firmware revision.\r\nThe date and time is later on “newer” firmware for a given device.\r\nThis feature is persistent and current if present.\r\nNo commands are required for this feature."
        )]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class FirmwareInformationFeature : MultimediaFeature
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly ScsiCommandCode[]
            __SupportedOperations = Sort(new ScsiCommandCode[] {});

        public override FeatureSupportKind GetSupport(ScsiCommand command)
        {
            return Array.BinarySearch(__SupportedOperations, command.OpCode) >= 0
                       ? FeatureSupportKind.Mandatory
                       : FeatureSupportKind.None;
        }

        public FirmwareInformationFeature() : base(FeatureCode.FirmwareInformation)
        {
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ushort _Century;

        public ushort Century
        {
            get { return Bits.BigEndian(_Century); }
            set { _Century = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ushort _Year;

        public ushort Year
        {
            get { return Bits.BigEndian(_Year); }
            set { _Year = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ushort _Month;

        public ushort Month
        {
            get { return Bits.BigEndian(_Month); }
            set { _Month = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ushort _Day;

        public ushort Day
        {
            get { return Bits.BigEndian(_Day); }
            set { _Day = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ushort _Hour;

        public ushort Hour
        {
            get { return Bits.BigEndian(_Hour); }
            set { _Hour = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ushort _Minute;

        public ushort Minute
        {
            get { return Bits.BigEndian(_Minute); }
            set { _Minute = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ushort _Second;

        public ushort Second
        {
            get { return Bits.BigEndian(_Second); }
            set { _Second = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte18;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte19;
    }
}