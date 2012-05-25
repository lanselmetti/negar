using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class ReadBufferCommand : FixedLengthScsiCommand
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte MODE_MASK = 0x1F;

        public ReadBufferCommand() : base(ScsiCommandCode.ReadBuffer)
        {
        }

        public ReadBufferCommand(byte bufferId, uint offset) : this()
        {
            BufferId = bufferId;
            BufferOffset = offset;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte1;

        public ReadBufferMode Mode
        {
            get { return (ReadBufferMode) Bits.GetValueMask(byte1, 0, MODE_MASK); }
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

    public enum ReadBufferMode : byte
    {
        CombinedHeaderAndData = 0x00,
        VendorSpecific = 0x01,
        Data = 0x02,
        Descriptor = 0x03,
        ReadDataFromEchoBuffer = 0x0A,
        EchoBufferDescriptor = 0x0B,
        EnableExpansionCommunicationsProtocolAndEchoBuffer = 0x1A,
        ErrorHistory = 0x1C,
    }
}