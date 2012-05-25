using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class WriteBufferCommand : FixedLengthScsiCommand
    {
        private const byte MODE_MASK = 0x1F;

        public WriteBufferCommand() : base(ScsiCommandCode.WriteBuffer)
        {
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte1;

        public WriteBufferMode Mode
        {
            get { return (WriteBufferMode) Bits.GetValueMask(byte1, 0, MODE_MASK); }
            set { byte1 = Bits.PutValueMask(byte1, (byte) value, 0, MODE_MASK); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _BufferId;

        public byte BufferId
        {
            get { return _BufferId; }
            set { _BufferId = value; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _byte3; //MSB
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _byte4;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _byte5; //LSB

        public uint BufferOffset
        {
            get
            {
                unchecked
                {
                    return _byte5 | ((uint) _byte4 << 8) | ((uint) _byte3 << 16);
                }
            }
            set
            {
                unchecked
                {
                    _byte5 = (byte) (value >> 0);
                    _byte4 = (byte) (value >> 8);
                    _byte3 = (byte) (value >> 16);
                }
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _byte6; //MSB
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _byte7;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _byte8; //LSB

        /// <summary>Do not use this value unless you are responsible for calling the <see cref="IScsiPassThrough.ExecuteCommand"/> method directly.</summary>
        public uint AllocationLength
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

    public enum WriteBufferMode : byte
    {
        CombinedHeaderAndData = 0x00,
        VendorSpecific = 0x01,
        Data = 0x02,
        DownloadMicrocodeAndActivate = 0x04,
        DownloadMicrocodeAndSaveAndActivate = 0x05,
        DownloadMicrocodeWithOffsetsAndActivate = 0x06,
        DownloadMicrocodeWithOffsetsAndSaveAndActivate = 0x07,
        WriteToEchoBuffer = 0x0A,
        DownloadMicrocodeWithOffsetsAndSaveAndDeferActivate = 0x0E,
        ActivateDeferredMicrocode = 0x0F,
        EnableExpansionCommunicationsProtocolAndEchoBuffer = 0x1A,
        DisableExpansionCommunicationsProtocol = 0x1B,
        DownloadApplicationClientErrorHistory = 0x1C,
    }
}