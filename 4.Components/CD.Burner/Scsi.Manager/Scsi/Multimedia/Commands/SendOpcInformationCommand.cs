using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class SendOpcInformationCommand : FixedLengthScsiCommand
    {
        public SendOpcInformationCommand() : base(ScsiCommandCode.SendOpcInformation)
        {
        }

        public SendOpcInformationCommand(bool exclude0, bool exclude1)
            : this()
        {
            Exclude0 = exclude0;
            Exclude1 = exclude1;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte1;

        public bool DoOptimumPowerCalibration
        {
            get { return Bits.GetBit(byte1, 0); }
            set { byte1 = Bits.SetBit(byte1, 0, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte2;

        public bool Exclude0
        {
            get { return Bits.GetBit(byte2, 0); }
            set { byte2 = Bits.SetBit(byte2, 0, value); }
        }

        public bool Exclude1
        {
            get { return Bits.GetBit(byte2, 1); }
            set { byte2 = Bits.SetBit(byte2, 1, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte3;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte4;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte5;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte6;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ushort _ParameterListLength;

        /// <summary>Do not use this value unless you are responsible for calling the <see cref="IScsiPassThrough.ExecuteCommand"/> method directly.</summary>
        public ushort ParameterListLength
        {
            get { return Bits.BigEndian(_ParameterListLength); }
            set { _ParameterListLength = Bits.BigEndian(value); }
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