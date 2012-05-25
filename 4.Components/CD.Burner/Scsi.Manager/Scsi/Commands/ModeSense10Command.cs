using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class ModeSense10Command : FixedLengthScsiCommand
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte PAGE_CODE_MASK = 0x3F;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte PAGE_CONTROL_MASK = 0xC0;

        public ModeSense10Command() : base(ScsiCommandCode.ModeSense10)
        {
            DisableBlockDescriptors = true;
            PageControl = PageControl.CurrentValues;
        }

        public ModeSense10Command(PageControl pageControl) : this()
        {
            PageControl = pageControl;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte1;

        public bool DisableBlockDescriptors
        {
            get { return Bits.GetBit(byte1, 3); }
            set { byte1 = Bits.SetBit(byte1, 3, value); }
        }

        public bool LongLogicalBlockAddressAccepted
        {
            get { return Bits.GetBit(byte1, 4); }
            set { byte1 = Bits.SetBit(byte1, 4, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte2;

        /// <summary>Do not use this value unless you are responsible for calling the <see cref="IScsiPassThrough.ExecuteCommand"/> method directly.</summary>
        public ModePageCode PageCode
        {
            get { return (ModePageCode) Bits.GetValueMask(byte2, 0, PAGE_CODE_MASK); }
            set { byte2 = Bits.PutValueMask(byte2, (byte) value, 0, PAGE_CODE_MASK); }
        }

        public PageControl PageControl
        {
            get { return (PageControl) Bits.GetValueMask(byte2, 6, PAGE_CONTROL_MASK); }
            set { byte2 = Bits.PutValueMask(byte2, (byte) value, 6, PAGE_CONTROL_MASK); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte3;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte4;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte5;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte6;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ushort _AllocationLength;

        /// <summary>Do not use this value unless you are responsible for calling the <see cref="IScsiPassThrough.ExecuteCommand"/> method directly.</summary>
        public ushort AllocationLength
        {
            get { return Bits.BigEndian(_AllocationLength); }
            set { _AllocationLength = Bits.BigEndian(value); }
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