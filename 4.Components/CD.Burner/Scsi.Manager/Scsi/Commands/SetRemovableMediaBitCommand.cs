using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class SetRemovableMediaBitCommand : FixedLengthScsiCommand
    {
        public SetRemovableMediaBitCommand() : base(ScsiCommandCode.SetRemovableMediaBit)
        {
        }

        public SetRemovableMediaBitCommand(bool removable) : this()
        {
            RemovableBit = removable;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte1 = 0x03;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte2;

        public bool RemovableBit
        {
            get { return Bits.GetBit(byte2, 0); }
            set { byte2 = Bits.SetBit(byte2, 0, value); }
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