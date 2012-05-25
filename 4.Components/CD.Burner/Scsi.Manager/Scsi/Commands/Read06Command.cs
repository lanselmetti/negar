using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Scsi
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class Read06Command : FixedLengthScsiCommand
    {
        public Read06Command() : base(ScsiCommandCode.Read06)
        {
        }

        public Read06Command(uint logicalBlockAddress, byte transferBlockCount) : this()
        {
            LogicalBlockAddress = logicalBlockAddress;
            TransferBlockCount = transferBlockCount;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _byte1; //MSB for bits 0-4, reserved for bits 5-7
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _byte2;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _byte3; //LSB

        public uint LogicalBlockAddress
        {
            get
            {
                unchecked
                {
                    return _byte3 | ((uint) _byte2 << 8) | ((uint) (_byte1 & 0x1F) << 16);
                }
            }
            set
            {
                unchecked
                {
                    _byte3 = (byte) (value >> 0);
                    _byte2 = (byte) (value >> 8);
                    _byte1 = unchecked((byte) ((_byte1 & ~0x1FU) | (value >> 16)));
                }
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _TransferBlockCount;

        public byte TransferBlockCount
        {
            get { return _TransferBlockCount; }
            set { _TransferBlockCount = value; }
        }

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