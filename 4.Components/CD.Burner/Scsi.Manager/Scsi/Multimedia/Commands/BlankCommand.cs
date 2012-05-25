using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class BlankCommand : FixedLengthScsiCommand
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte BLANKING_TYPE_MASK = 0x07;

        public BlankCommand() : base(ScsiCommandCode.Blank)
        {
        }

        public BlankCommand(BlankingType blankingType, bool immediate, uint startAddressOrLogicalTrackNumber)
            : this()
        {
            BlankingType = blankingType;
            Immediate = immediate;
            StartAddressOrLogicalTrackNumber = startAddressOrLogicalTrackNumber;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte1;

        public bool Immediate
        {
            get { return Bits.GetBit(byte1, 4); }
            set { byte1 = Bits.SetBit(byte1, 4, value); }
        }

        public BlankingType BlankingType
        {
            get { return (BlankingType) Bits.GetValueMask(byte1, 0, BLANKING_TYPE_MASK); }
            set { byte1 = Bits.PutValueMask(byte1, (byte) value, 0, BLANKING_TYPE_MASK); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private uint _StartAddressOrLogicalTrackNumber;

        public uint StartAddressOrLogicalTrackNumber
        {
            get { return Bits.BigEndian(_StartAddressOrLogicalTrackNumber); }
            set { _StartAddressOrLogicalTrackNumber = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte6;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte7;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte8;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte9;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte10;
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