using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class Write12Command : FixedLengthScsiCommand
    {
        public Write12Command() : base(ScsiCommandCode.Write12)
        {
        }

        public Write12Command(bool forceUnitAccess, uint logicalBlockAddress, uint blocksToTransfer, bool streaming)
            : this()
        {
            ForceUnitAccess = forceUnitAccess;
            LogicalBlockAddress = logicalBlockAddress;
            TransferBlockCount = blocksToTransfer;
            Streaming = streaming;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte1;

        /// <summary>Must be zero for CD/Dvd logical units.</summary>
        public bool DisablePageOut
        {
            get { return Bits.GetBit(byte1, 4); }
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
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private uint _LogicalBlockAddress;

        public uint LogicalBlockAddress
        {
            get { return Bits.BigEndian(_LogicalBlockAddress); }
            set { _LogicalBlockAddress = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private uint _TransferBlockCount;

        /// <summary>The number of blocks to transfer.</summary>
        public uint TransferBlockCount
        {
            get { return Bits.BigEndian(_TransferBlockCount); }
            set { _TransferBlockCount = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte10;

        public bool Streaming
        {
            get { return Bits.GetBit(byte10, 7); }
            set { byte10 = Bits.SetBit(byte10, 7, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private CommandControl _Control;

        public override CommandControl Control
        {
            get { return _Control; }
            set { _Control = value; }
        }

        public override ScsiTimeoutGroup TimeoutGroup
        {
            get { return Streaming ? ScsiTimeoutGroup.Group3 : ScsiTimeoutGroup.Group1; }
        }
    }
}