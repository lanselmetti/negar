using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PowerManagementEvent
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte EVENT_CODE_MASK = 0x0F;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte0;

        public PowerEventCode PowerEventCode
        {
            get { return (PowerEventCode) Bits.GetValueMask(byte0, 0, EVENT_CODE_MASK); }
            set { byte0 = Bits.PutValueMask(byte0, (byte) value, 0, EVENT_CODE_MASK); }
        }

        public PowerStatusCode PowerStatusCode;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte2;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte3;
    }
}