using System;
using System.Runtime.InteropServices;

namespace Scsi.Multimedia
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Event
    {
        public MultimediaEventHeader Header;
        public EventUnion Events;
    }

    [StructLayout(LayoutKind.Explicit, Pack = 1)]
    public struct EventUnion
    {
        [FieldOffset(0)] public OperationalChangeEvent OperationalChangeEvent;
        [FieldOffset(0)] public PowerManagementEvent PowerManagementEvent;
        [FieldOffset(0)] public ExternalRequestEvent ExternalRequestEvent;
        [FieldOffset(0)] public MediaEvent MediaEvent;
        [FieldOffset(0)] public MultipleHostEvent MultipleHostEvent;
        [FieldOffset(0)] public DeviceBusyEvent DeviceBusyEvent;
    }

    public enum NotificationClass : byte
    {
        None = 0,
        OperationalChange = 1,
        PowerManagement = 2,
        ExternalRequest = 3,
        Media = 4,
        MultiHost = 5,
        DeviceBusy = 6,
    }

    [Flags]
    public enum NotificationClassFlags : byte
    {
        None = 0,
        OperationalChange = 1 << 1,
        PowerManagement = 1 << 2,
        ExternalRequest = 1 << 3,
        Media = 1 << 4,
        MultiHost = 1 << 5,
        DeviceBusy = 1 << 6,
    }
}