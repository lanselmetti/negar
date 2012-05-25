using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Scsi
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class RequestSenseCommand : FixedLengthScsiCommand
    {
        public RequestSenseCommand() : base(ScsiCommandCode.RequestSense)
        {
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte1;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte2;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte3;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _AllocationLength;

        /// <summary>Do not use this value unless you are responsible for calling the <see cref="IScsiPassThrough.ExecuteCommand"/> method directly.</summary>
        public byte AllocationLength
        {
            get { return _AllocationLength; }
            set { _AllocationLength = value; }
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