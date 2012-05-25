using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class Write10Command : FixedLengthScsiCommand
    {
        public Write10Command() : base(ScsiCommandCode.Write10)
        {
        }

        public Write10Command(bool forceUnitAccess, uint logicalBlockAddress, ushort blocksToTransfer)
            : this()
        {
            ForceUnitAccess = forceUnitAccess;
            LogicalBlockAddress = logicalBlockAddress;
            TransferBlockCount = blocksToTransfer;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte1;

        /// <summary>Must be zero for CD/Dvd logical units.</summary>
        public bool DisablePageOut
        {
            get { return Bits.GetBit(byte1, 4); }
            set { byte1 = Bits.SetBit(byte1, 4, value); }
        }

        public bool ForceUnitAccess
        {
            get { return Bits.GetBit(byte1, 3); }
            set { byte1 = Bits.SetBit(byte1, 3, value); }
        }

        public bool TimelySafeRecording
        {
            get { return Bits.GetBit(byte1, 2); }
            set { byte1 = Bits.SetBit(byte1, 2, value); }
        }

        /// <summary>Must be zero for CD/Dvd logical units.</summary>
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
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ushort _TransferBlockCount;

        /// <summary>The number of blocks to transfer.</summary>
        public ushort TransferBlockCount
        {
            get { return Bits.BigEndian(_TransferBlockCount); }
            set { _TransferBlockCount = Bits.BigEndian(value); }
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