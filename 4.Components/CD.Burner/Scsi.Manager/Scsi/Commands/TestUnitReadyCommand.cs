using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Scsi
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class TestUnitReadyCommand : FixedLengthScsiCommand
    {
        public TestUnitReadyCommand() : base(ScsiCommandCode.TestUnitReady)
        {
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte1;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte2;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte3;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte4;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private CommandControl _Control;

        public override CommandControl Control
        {
            get { return _Control; }
            set { _Control = value; }
        }

        public override ScsiTimeoutGroup TimeoutGroup
        {
            get { return ScsiTimeoutGroup.Group1; }
        }
    }
}