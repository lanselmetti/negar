using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class FormatUnitCommand : FixedLengthScsiCommand
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte FORMAT_CODE_MASK = 0x7;

        public FormatUnitCommand() : base(ScsiCommandCode.Format)
        {
            FormatData = true;
            FormatCode = FormatCode.Other;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte1;

        /// <summary>Should be one.</summary>
        public bool FormatData
        {
            get { return Bits.GetBit(byte1, 4); }
            set { byte1 = Bits.SetBit(byte1, 4, value); }
        }

        /// <summary>Should be zero on most discs except DVD-RAM.</summary>
        public bool CompleteList
        {
            get { return Bits.GetBit(byte1, 3); }
            set { byte1 = Bits.SetBit(byte1, 3, value); }
        }

        public FormatCode FormatCode
        {
            get { return (FormatCode) Bits.GetValueMask(byte1, 0, FORMAT_CODE_MASK); }
            set { byte1 = Bits.PutValueMask(byte1, (byte) value, 0, FORMAT_CODE_MASK); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte2;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ushort _InterleaveValue;

        [Obsolete("Should be zero.", true)]
        public ushort InterleaveValue
        {
            get { return Bits.BigEndian(_InterleaveValue); }
            set { _InterleaveValue = Bits.BigEndian(value); }
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