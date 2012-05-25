using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Scsi
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class AtaPassThrough12Command : FixedLengthScsiCommand
    {
        public AtaPassThrough12Command() : base(ScsiCommandCode.AtaPassThrough12)
        {
            throw new NotImplementedException();
        }

        //NotImplemented
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private CommandControl _Control;

        public override ScsiTimeoutGroup TimeoutGroup
        {
            get { throw new NotImplementedException(); }
        }

        public override CommandControl Control
        {
            get { return _Control; }
            set { _Control = value; }
        }
    }
}