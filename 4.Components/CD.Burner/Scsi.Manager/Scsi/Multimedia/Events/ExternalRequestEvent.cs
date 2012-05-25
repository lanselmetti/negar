using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ExternalRequestEvent
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte EVENT_CODE_MASK = 0x0F;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte EXTERNAL_REQUEST_STATUS_MASK = 0x0F;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte0;

        public ExternalRequestEventCode ExternalRequestEventCode
        {
            get { return (ExternalRequestEventCode) Bits.GetValueMask(byte0, 0, EVENT_CODE_MASK); }
            set { byte0 = Bits.PutValueMask(byte0, (byte) value, 0, EVENT_CODE_MASK); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte1;

        public bool PersistentPrevented
        {
            get { return Bits.GetBit(byte1, 7); }
            set { byte1 = Bits.SetBit(byte1, 7, value); }
        }

        public ExternalRequestStatusCode ExternalRequestStatusCode
        {
            get { return (ExternalRequestStatusCode) Bits.GetValueMask(byte1, 0, EXTERNAL_REQUEST_STATUS_MASK); }
            set { byte1 = Bits.PutValueMask(byte1, (byte) value, 0, EXTERNAL_REQUEST_STATUS_MASK); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ExternalRequestCode _ExternalRequestStatus;

        public ExternalRequestCode ExternalRequestCode
        {
            get { return Bits.BigEndian(_ExternalRequestStatus); }
            set { _ExternalRequestStatus = Bits.BigEndian(value); }
        }
    }
}