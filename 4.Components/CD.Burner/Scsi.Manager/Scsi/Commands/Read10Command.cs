using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class Read10Command : FixedLengthScsiCommand
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte GROUP_NUMBER_MASK = 0x1F;

        public Read10Command() : base(ScsiCommandCode.Read10)
        {
        }

        public Read10Command(bool forceUnitAccess, uint logicalBlockAddress, ushort transferBlockCount)
            : this()
        {
            ForceUnitAccess = forceUnitAccess;
            LogicalBlockAddress = logicalBlockAddress;
            TransferBlockCount = transferBlockCount;
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

        /// <summary>Must be zero.</summary>
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

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte6;

        public byte GroupNumber
        {
            get { return Bits.GetValueMask(byte6, 0, GROUP_NUMBER_MASK); }
            set { byte6 = Bits.PutValueMask(byte6, value, 0, GROUP_NUMBER_MASK); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ushort _TransferBlockCount;

        /// <summary>This field specifies the number of contiguous logical blocks of data that is transferred. A Transfer Length of zero indicates that no logical blocks is transferred. This condition is not considered an error. Any other value indicates the number of logical blocks that are transferred.</summary>
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