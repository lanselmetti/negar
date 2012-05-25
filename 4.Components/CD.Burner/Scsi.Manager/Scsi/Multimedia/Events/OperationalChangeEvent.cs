using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct OperationalChangeEvent
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte EVENT_CODE_MASK = 0x0F;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte OPERATIONAL_STATUS_MASK = 0x0F;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte0;

        public OperationalEventCode OperationalEventCode
        {
            get { return (OperationalEventCode) Bits.GetValueMask(byte0, 0, EVENT_CODE_MASK); }
            set { byte0 = Bits.PutValueMask(byte0, (byte) value, 0, EVENT_CODE_MASK); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte1;

        public bool PersistentPrevented
        {
            get { return Bits.GetBit(byte1, 7); }
            set { byte1 = Bits.SetBit(byte1, 7, value); }
        }

        public OperationalStatusCode OperationalStatusCode
        {
            get { return (OperationalStatusCode) Bits.GetValueMask(byte1, 0, OPERATIONAL_STATUS_MASK); }
            set { byte1 = Bits.PutValueMask(byte1, (byte) value, 0, OPERATIONAL_STATUS_MASK); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private OperationalChangeClass _OperationalChange;

        public OperationalChangeClass OperationalChangeClass
        {
            get { return Bits.BigEndian(_OperationalChange); }
            set { _OperationalChange = Bits.BigEndian(value); }
        }
    }
}