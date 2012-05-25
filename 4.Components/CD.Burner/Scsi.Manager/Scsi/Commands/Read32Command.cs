using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class Read32Command : FixedLengthScsiCommand
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte GROUP_NUMBER_MASK = 0x1F;

        public Read32Command() : base(ScsiCommandCode.Read32)
        {
        }

        public Read32Command(bool forceUnitAccess, ulong logicalBlockAddress, uint transferBlockCount)
            : this()
        {
            ForceUnitAccess = forceUnitAccess;
            LogicalBlockAddress = logicalBlockAddress;
            TransferBlockCount = transferBlockCount;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private CommandControl _Control;

        public override CommandControl Control
        {
            get { return _Control; }
            set { _Control = value; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte2;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte3;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte4;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte5;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte6;

        public byte GroupNumber
        {
            get { return Bits.GetValueMask(byte6, 0, GROUP_NUMBER_MASK); }
            set { byte6 = Bits.PutValueMask(byte6, value, 0, GROUP_NUMBER_MASK); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _AdditionalCDBLength =
            Bits.ReverseBytes((byte) 0x18);

        public byte AdditionalCDBLength
        {
            get { return _AdditionalCDBLength; }
            set { _AdditionalCDBLength = value; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ServiceAction _ServiceAction =
            Bits.ReverseBytes(ServiceAction.Read32);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte10;

        /// <summary>Must be zero for CD/Dvd logical units.</summary>
        public bool DisablePageOut
        {
            get { return Bits.GetBit(byte10, 4); }
            set { byte10 = Bits.SetBit(byte10, 4, value); }
        }

        public bool ForceUnitAccess
        {
            get { return Bits.GetBit(byte10, 3); }
            set { byte10 = Bits.SetBit(byte10, 3, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte11;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ulong _LogicalBlockAddress;

        public ulong LogicalBlockAddress
        {
            get { return Bits.ReverseBytes(_LogicalBlockAddress); }
            set { _LogicalBlockAddress = Bits.ReverseBytes(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private uint _ExpectedInitialLogicalBlockReferenceTag;

        public uint ExpectedInitialLogicalBlockReferenceTag
        {
            get { return Bits.ReverseBytes(_ExpectedInitialLogicalBlockReferenceTag); }
            set { _ExpectedInitialLogicalBlockReferenceTag = Bits.ReverseBytes(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ushort _ExpectedLogicalBlockApplicationTag;

        public ushort ExpectedLogicalBlockApplicationTag
        {
            get { return Bits.ReverseBytes(_ExpectedLogicalBlockApplicationTag); }
            set { _ExpectedLogicalBlockApplicationTag = Bits.ReverseBytes(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ushort _LogicalBlockApplicationTagMask;

        public ushort LogicalBlockApplicationTagMask
        {
            get { return Bits.ReverseBytes(_LogicalBlockApplicationTagMask); }
            set { _LogicalBlockApplicationTagMask = Bits.ReverseBytes(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private uint _TransferBlockCount;

        public uint TransferBlockCount
        {
            get { return Bits.ReverseBytes(_TransferBlockCount); }
            set { _TransferBlockCount = Bits.ReverseBytes(value); }
        }

        public override ScsiTimeoutGroup TimeoutGroup
        {
            get { return ScsiTimeoutGroup.Group1; }
        }
    }
}