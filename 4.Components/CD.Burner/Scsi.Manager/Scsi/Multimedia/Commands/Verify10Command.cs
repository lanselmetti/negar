using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class Verify10Command : FixedLengthScsiCommand
    {
        public Verify10Command() : base(ScsiCommandCode.Verify10)
        {
        }

        public Verify10Command(uint logicalBlockAddress, ushort numberOfBlocks)
            : this()
        {
            LogicalBlockAddress = logicalBlockAddress;
            NumberOfBlocks = numberOfBlocks;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte1;

        /// <summary>Should be zero.</summary>
        public bool DisablePageOut
        {
            get { return Bits.GetBit(byte1, 4); }
            set { byte1 = Bits.SetBit(byte1, 4, value); }
        }

        /// <summary>Should be zero.</summary>
        public bool ByteCheck
        {
            get { return Bits.GetBit(byte1, 1); }
            set { byte1 = Bits.SetBit(byte1, 1, value); }
        }

        [Obsolete("Should be zero.", true)]
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

        public bool Group3Timeout
        {
            get { return Bits.GetBit(byte6, 7); }
            set { byte6 = Bits.SetBit(byte6, 7, value); }
        }

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
            get { return ScsiTimeoutGroup.Group2; }
        }
    }
}