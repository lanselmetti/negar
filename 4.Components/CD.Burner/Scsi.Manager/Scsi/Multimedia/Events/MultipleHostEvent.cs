using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MultipleHostEvent
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte EVENT_CODE_MASK = 0x0F;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte MULTIPLE_HOST_STATUS_MASK = 0x0F;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte0;

        public MultipleHostEventCode MultipleHostEventCode
        {
            get { return (MultipleHostEventCode) Bits.GetValueMask(byte0, 0, EVENT_CODE_MASK); }
            set { byte0 = Bits.PutValueMask(byte0, (byte) value, 0, EVENT_CODE_MASK); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte1;

        public bool PersistentPrevented
        {
            get { return Bits.GetBit(byte1, 7); }
            set { byte1 = Bits.SetBit(byte1, 7, value); }
        }

        public MultipleHostStatusCode MultipleHostStatusCode
        {
            get { return (MultipleHostStatusCode) Bits.GetValueMask(byte1, 0, MULTIPLE_HOST_STATUS_MASK); }
            set { byte1 = Bits.PutValueMask(byte0, (byte) value, 1, MULTIPLE_HOST_STATUS_MASK); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ushort _MultipleHostPriority;

        public ushort MultipleHostPriority
        {
            get { return Bits.BigEndian(_MultipleHostPriority); }
            set { _MultipleHostPriority = Bits.BigEndian(value); }
        }
    }
}