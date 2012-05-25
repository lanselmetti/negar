using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class ReportKeyCommand : FixedLengthScsiCommand
    {
        private const byte KEY_FORMAT_MASK = 0x3F;
        private const byte AuthenticationGrantId_MASK = 0xC0;

        public ReportKeyCommand() : base(ScsiCommandCode.ReportKey)
        {
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte1;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private uint _ReservedOrLogicalBlockAddressOrStartingOffset;

        public uint ReservedOrLogicalBlockAddressOrStartingOffset
        {
            get { return Bits.BigEndian(_ReservedOrLogicalBlockAddressOrStartingOffset); }
            set { _ReservedOrLogicalBlockAddressOrStartingOffset = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _ReservedOrBlockCountOrVCPSFunction;

        public byte ReservedOrBlockCountOrVCPSFunction
        {
            get { return _ReservedOrBlockCountOrVCPSFunction; }
            set { _ReservedOrBlockCountOrVCPSFunction = value; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private KeyClass _KeyClass;

        public KeyClass KeyClass
        {
            get { return _KeyClass; }
            set { _KeyClass = value; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ushort _AllocationLength;

        public ushort AllocationLength
        {
            get { return Bits.BigEndian(_AllocationLength); }
            set { _AllocationLength = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte10;

        public KeyFormat KeyFormat
        {
            get { return (KeyFormat) Bits.GetValueMask(byte10, 0, KEY_FORMAT_MASK); }
            set { byte10 = Bits.PutValueMask(byte10, (byte) value, 0, KEY_FORMAT_MASK); }
        }

        public byte AuthenticationGrantId
        {
            get { return Bits.GetValueMask(byte10, 6, AuthenticationGrantId_MASK); }
            set { byte10 = Bits.PutValueMask(byte10, value, 6, AuthenticationGrantId_MASK); }
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