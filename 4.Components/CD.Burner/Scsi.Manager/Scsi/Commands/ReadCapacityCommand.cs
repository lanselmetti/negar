using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class ReadCapacityCommand : FixedLengthScsiCommand
    {
        public ReadCapacityCommand() : base(ScsiCommandCode.ReadCapacity)
        {
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte0;

        /// <summary>Must be zero for CD/Dvd logical units.</summary>
        public bool RelativeAddress
        {
            get { return Bits.GetBit(byte0, 0); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private uint _LogicalBlockAddress;

        /// <summary>Should be zero.</summary>
        public uint LogicalBlockAddress
        {
            get { return Bits.BigEndian(_LogicalBlockAddress); }
            set { _LogicalBlockAddress = Bits.BigEndian(value); }
        }

        private byte byte6;
        private byte byte7;
        private byte byte8;

        /// <summary>Should be zero for multimedia drives.</summary>
        public bool PMI
        {
            get { return Bits.GetBit(byte8, 0); }
            set { byte8 = Bits.SetBit(byte8, 0, value); }
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