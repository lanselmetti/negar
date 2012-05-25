using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class CDParametersPage : ModePage
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte INACTIVITY_TIMER_MULTIPLIER_MASK = 0x0F;

        public CDParametersPage() : base(ModePageCode.CDDeviceParameters)
        {
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte2;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte3;

        public InactivityTimerMultiplierValue InactivityTimerMultiplierValue
        {
            get { return (InactivityTimerMultiplierValue) Bits.GetValueMask(byte3, 0, INACTIVITY_TIMER_MULTIPLIER_MASK); }
            set { byte3 = Bits.PutValueMask(byte3, (byte) value, 0, INACTIVITY_TIMER_MULTIPLIER_MASK); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ushort _SecondsPerMinute;

        public ushort SecondsPerMinute
        {
            get { return Bits.BigEndian(_SecondsPerMinute); }
            set { _SecondsPerMinute = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ushort _FramesPerSecond;

        public ushort FramesPerSecond
        {
            get { return Bits.BigEndian(_FramesPerSecond); }
            set { _FramesPerSecond = Bits.BigEndian(value); }
        }
    }
}