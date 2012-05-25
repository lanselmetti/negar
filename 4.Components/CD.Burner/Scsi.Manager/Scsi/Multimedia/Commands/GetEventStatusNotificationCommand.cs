using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class GetEventStatusNotificationCommand : FixedLengthScsiCommand
    {
        public GetEventStatusNotificationCommand()
            : base(ScsiCommandCode.GetEventStatusNotification)
        {
            Polled = true;
        }

        public GetEventStatusNotificationCommand(NotificationClassFlags notificationClassRequest)
            : this()
        {
            NotificationClassRequest = notificationClassRequest;
        }

        public GetEventStatusNotificationCommand(NotificationClassFlags notificationClassRequest, bool polled)
            : this(notificationClassRequest)
        {
            Polled = polled;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte1;

        public bool Polled
        {
            get { return Bits.GetBit(byte1, 0); }
            set { byte1 = Bits.SetBit(byte1, 0, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte2;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte3;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private NotificationClassFlags _NotificationClassRequest;

        public NotificationClassFlags NotificationClassRequest
        {
            get { return _NotificationClassRequest; }
            set { _NotificationClassRequest = value; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte5;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte6;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ushort _AllocationLength;

        /// <summary>Do not use this value unless you are responsible for calling the <see cref="IScsiPassThrough.ExecuteCommand"/> method directly.</summary>
        public ushort AllocationLength
        {
            get { return Bits.BigEndian(_AllocationLength); }
            set { _AllocationLength = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private CommandControl _Control;

        public override CommandControl Control
        {
            get { return _Control; }
            set { _Control = value; }
        }

        public override ScsiTimeoutGroup TimeoutGroup
        {
            get { return ScsiTimeoutGroup.None; }
        }
    }
}