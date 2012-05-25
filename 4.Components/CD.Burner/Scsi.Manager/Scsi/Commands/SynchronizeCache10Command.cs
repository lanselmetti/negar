using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class SynchronizeCache10Command : FixedLengthScsiCommand
    {
        public SynchronizeCache10Command() : base(ScsiCommandCode.SynchronizeCache10)
        {
        }

        public SynchronizeCache10Command(bool immediate) : this()
        {
            Immediate = immediate;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte1;

        public bool Immediate
        {
            get { return Bits.GetBit(byte1, 1); }
            set { byte1 = Bits.SetBit(byte1, 1, value); }
        }

        /// <summary>Must be zero for CD/Dvd logical units.</summary>
        public bool RelativeAddress
        {
            get { return Bits.GetBit(byte1, 0); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private uint _LogicalBlockAddress;

        /// <summary>Multimedia devices ignore this field.</summary>
        [Description("Multimedia devices ignore this field.")]
        public uint LogicalBlockAddress
        {
            get { return Bits.BigEndian(_LogicalBlockAddress); }
            set { _LogicalBlockAddress = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte6;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ushort _BlockCount;

        /// <summary>Multimedia devices ignore this field.</summary>
        [Description("Multimedia devices ignore this field.")]
        public ushort BlockCount
        {
            get { return Bits.BigEndian(_BlockCount); }
            set { _BlockCount = Bits.BigEndian(value); }
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