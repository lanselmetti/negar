using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class SetCDSpeedCommand : FixedLengthScsiCommand
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte ROTATION_CONTROL_MASK = 0x03;

        public SetCDSpeedCommand() : base(ScsiCommandCode.SetCDSpeed)
        {
        }

        public SetCDSpeedCommand(ushort readSpeed, ushort writeSpeed, RotationControl rotationControl)
            : this()
        {
            LogicalUnitReadSpeed = readSpeed;
            LogicalUnitWriteSpeed = writeSpeed;
            RotationControl = rotationControl;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte1;

        public RotationControl RotationControl
        {
            get { return (RotationControl) Bits.GetValueMask(byte1, 0, ROTATION_CONTROL_MASK); }
            set { byte1 = Bits.PutValueMask(byte1, (byte) value, 0, ROTATION_CONTROL_MASK); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ushort _LogicalUnitReadSpeed;

        /// <summary>The read speed, in KB (1000 bytes) per second. (This is NOT KiB/s, or 1024 B/s.)</summary>
        [Description("The read speed, in KB (1000 bytes) per second. (This is NOT KiB/s, or 1024 B/s.)")]
        public ushort LogicalUnitReadSpeed
        {
            get { return Bits.BigEndian(_LogicalUnitReadSpeed); }
            set { _LogicalUnitReadSpeed = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ushort _LogicalUnitWriteSpeed;

        /// <summary>The write speed, in KB (1000 bytes) per second. (This is NOT KiB/s, or 1024 B/s.)</summary>
        [Description("The write speed, in KB (1000 bytes) per second. (This is NOT KiB/s, or 1024 B/s.)")]
        public ushort LogicalUnitWriteSpeed
        {
            get { return Bits.BigEndian(_LogicalUnitWriteSpeed); }
            set { _LogicalUnitWriteSpeed = Bits.BigEndian(value); }
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
            get { return ScsiTimeoutGroup.Group1; }
        }
    }
}