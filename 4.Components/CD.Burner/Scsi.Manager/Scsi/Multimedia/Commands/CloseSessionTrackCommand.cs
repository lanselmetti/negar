using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class CloseSessionTrackCommand : FixedLengthScsiCommand
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte FUNCTION_MASK = 0x7;

        public CloseSessionTrackCommand() : base(ScsiCommandCode.CloseSessionOrTrack)
        {
        }

        public CloseSessionTrackCommand(bool immediate, TrackSessionCloseFunction function, ushort trackNumber)
            : this()
        {
            Immediate = immediate;
            Function = function;
            TrackNumber = trackNumber;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte1;

        public bool Immediate
        {
            get { return Bits.GetBit(byte1, 0); }
            set { byte1 = Bits.SetBit(byte1, 0, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte2;

        public TrackSessionCloseFunction Function
        {
            get { return (TrackSessionCloseFunction) Bits.GetValueMask(byte2, 0, FUNCTION_MASK); }
            set { byte2 = Bits.PutValueMask(byte2, (byte) value, 0, FUNCTION_MASK); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte3;
        private ushort _TrackNumber;

        public ushort TrackNumber
        {
            get { return Bits.BigEndian(_TrackNumber); }
            set { _TrackNumber = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte6;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte7;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte8;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private CommandControl _Control;

        public override CommandControl Control
        {
            get { return _Control; }
            set { _Control = value; }
        }

        public override ScsiTimeoutGroup TimeoutGroup
        {
            get { return Immediate ? ScsiTimeoutGroup.Group1 : ScsiTimeoutGroup.Group2; }
        }
    }
}