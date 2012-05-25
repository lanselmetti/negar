using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class Erase10Command : FixedLengthScsiCommand
    {
        public Erase10Command() : base(ScsiCommandCode.Erase10)
        {
        }

        public Erase10Command(bool eraseAll, bool immediate, uint logicalBlockAddress, ushort numBlocks)
            : this()
        {
            EraseAll = eraseAll;
            Immediate = immediate;
            LogicalBlockAddress = logicalBlockAddress;
            NumberOfBlocks = numBlocks;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte1;

        public bool EraseAll
        {
            get { return Bits.GetBit(byte1, 2); }
            set { byte1 = Bits.SetBit(byte1, 2, value); }
        }

        public bool Immediate
        {
            get { return Bits.GetBit(byte1, 1); }
            set { byte1 = Bits.SetBit(byte1, 1, value); }
        }

        [Obsolete("Must be zero.", true)]
        public bool RelativeAddress
        {
            get { return Bits.GetBit(byte1, 0); }
            set { byte1 = Bits.SetBit(byte1, 0, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private uint _LogicalBlockAddress;

        public uint LogicalBlockAddress
        {
            get { return Bits.BigEndian(_LogicalBlockAddress); }
            set { _LogicalBlockAddress = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte6;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ushort _NumberOfBlocks;

        public ushort NumberOfBlocks
        {
            get { return Bits.BigEndian(_NumberOfBlocks); }
            set { _NumberOfBlocks = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private CommandControl _Control;

        public override CommandControl Control
        {
            get { return _Control; }
            set { _Control = value; }
        }

        public override ScsiTimeoutGroup TimeoutGroup
        {
            get { return Immediate ? ScsiTimeoutGroup.Group1 : ScsiTimeoutGroup.Group2; }
        }
    }
}