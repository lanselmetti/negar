using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Scsi.Multimedia
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class SendCueSheetCommand : FixedLengthScsiCommand
    {
        public SendCueSheetCommand() : base(ScsiCommandCode.SendCueSheet)
        {
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte1;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte2;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte3;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte4;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte5;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _byte6; //MSB
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _byte7;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _byte8; //LSB

        /// <summary>Do not use this value unless you are responsible for calling the <see cref="IScsiPassThrough.ExecuteCommand"/> method directly.</summary>
        public uint CueSheetSize
        {
            get
            {
                unchecked
                {
                    return _byte8 | ((uint) _byte7 << 8) | ((uint) _byte6 << 16);
                }
            }
            set
            {
                unchecked
                {
                    _byte8 = (byte) (value >> 0);
                    _byte7 = (byte) (value >> 8);
                    _byte6 = (byte) (value >> 16);
                }
            }
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