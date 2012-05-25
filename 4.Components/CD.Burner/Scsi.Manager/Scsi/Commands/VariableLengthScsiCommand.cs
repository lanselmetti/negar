using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Scsi
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public abstract class VariableLengthScsiCommand : ScsiCommand
    {
        protected VariableLengthScsiCommand(ScsiCommandCode operationCode) : base(operationCode)
        {
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private CommandControl _Control;

        public override sealed CommandControl Control
        {
            get { return _Control; }
            set { _Control = value; }
        }
    }
}