using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class ModeSelect10Command : FixedLengthScsiCommand
    {
        public ModeSelect10Command() : base(ScsiCommandCode.ModeSelect10)
        {
            PageFormat = true;
        }

        public ModeSelect10Command(bool savePages, bool pageFormat)
            : this()
        {
            SavePages = savePages;
            PageFormat = pageFormat;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte1;

        public bool SavePages
        {
            get { return Bits.GetBit(byte1, 0); }
            set { byte1 = Bits.SetBit(byte1, 0, value); }
        }

        /// <summary>Indicates whether or not the commands are as defined in the SPC-2 standard.</summary>
        [Description("Indicates whether or not the commands are as defined in the SPC-2 standard.")]
        public bool PageFormat
        {
            get { return Bits.GetBit(byte1, 4); }
            set { byte1 = Bits.SetBit(byte1, 4, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte2;
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