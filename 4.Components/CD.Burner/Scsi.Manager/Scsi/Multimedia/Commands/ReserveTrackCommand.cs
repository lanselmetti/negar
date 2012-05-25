using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class ReserveTrackCommand : FixedLengthScsiCommand
    {
        public ReserveTrackCommand() : base(ScsiCommandCode.ReserveTrack)
        {
        }

        public ReserveTrackCommand(bool isLogicalBlockAddressInsteadOfReservationSize, uint reservation)
            : this()
        {
            ARSV = isLogicalBlockAddressInsteadOfReservationSize;
            LogicalTrackReservationParameter = new LogicalTrackReservationParameter(reservation,
                                                                                    isLogicalBlockAddressInsteadOfReservationSize);
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte1;

        /// <summary>Should be zero for non-HD DVDs.</summary>
        public bool RMZ
        {
            get { return Bits.GetBit(byte1, 1); }
            set { byte1 = Bits.SetBit(byte1, 1, value); }
        }

        /// <summary>When set to <c>false</c>, indicates that the <see cref="Multimedia.LogicalTrackReservationParameter.ReservationSize"/> property is set. When set to <c>true</c>, means that the <see cref="Multimedia.LogicalTrackReservationParameter.ReservationLogicalBlockAddress"/> property is set.</summary>
        [Description(
            "When set to false, indicates that the LogicalTrackReservationParameter.ReservationSize property is set. When set to true, means that the LogicalTrackReservationParameter.ReservationLogicalBlockAddress property is set."
            )]
        public bool ARSV
        {
            get { return Bits.GetBit(byte1, 0); }
            set { byte1 = Bits.SetBit(byte1, 0, value); }
        }

        public LogicalTrackReservationParameter LogicalTrackReservationParameter;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private CommandControl _Control;

        public override CommandControl Control
        {
            get { return _Control; }
            set { _Control = value; }
        }

        public override ScsiTimeoutGroup TimeoutGroup
        {
            get { return ScsiTimeoutGroup.Group2; }
        }
    }
}