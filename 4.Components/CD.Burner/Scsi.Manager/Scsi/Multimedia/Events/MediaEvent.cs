using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MediaEvent
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte EVENT_CODE_MASK = 0x0F;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte0;

        public MediaEventCode MediaEventCode
        {
            get { return (MediaEventCode) Bits.GetValueMask(byte0, 0, EVENT_CODE_MASK); }
            set { byte0 = Bits.PutValueMask(byte0, (byte) value, 0, EVENT_CODE_MASK); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _MediaStatus;

        public bool MediaPresent
        {
            get { return Bits.GetBit(_MediaStatus, 1); }
            set { _MediaStatus = Bits.SetBit(_MediaStatus, 1, value); }
        }

        public bool DoorOrTrayOpen
        {
            get { return Bits.GetBit(_MediaStatus, 0); }
            set { _MediaStatus = Bits.SetBit(_MediaStatus, 0, value); }
        }

        public byte StartSlot;
        public byte EndSlot;
    }
}