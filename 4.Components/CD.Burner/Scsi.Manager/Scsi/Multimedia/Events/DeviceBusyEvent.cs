using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct DeviceBusyEvent
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte EVENT_CODE_MASK = 0x0F;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte0;

        public DeviceBusyEventCode DeviceBusyEventCode
        {
            get { return (DeviceBusyEventCode) Bits.GetValueMask(byte0, 0, EVENT_CODE_MASK); }
            set { byte0 = Bits.PutValueMask(byte0, (byte) value, 0, EVENT_CODE_MASK); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private DeviceBusyStatusCode _DeviceBusyStatusCode;

        public DeviceBusyStatusCode DeviceBusyStatusCode
        {
            get { return _DeviceBusyStatusCode; }
            set { _DeviceBusyStatusCode = value; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ushort _Time;

        /// <summary>The predicted amount of time remaining for the drive to become not busy, in units of 100 ms. This is not valid if the device is not busy.</summary>
        public ushort Time
        {
            get { return Bits.BigEndian(_Time); }
            set { _Time = Bits.BigEndian(value); }
        }

        /// <summary>The predicted amount of time remaining for the drive to become not busy. This is not valid if the device is not busy.</summary>
        public TimeSpan TimeSpan
        {
            get { return TimeSpan.FromMilliseconds(Time*100); }
            set
            {
                Time = (ushort) (value.TotalMilliseconds/100);
                ;
            }
        }
    }
}