using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ReadCapacityInfo
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private uint _LogicalBlockAddress;

        public uint LogicalBlockAddress
        {
            get { return Bits.BigEndian(_LogicalBlockAddress); }
            set { _LogicalBlockAddress = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private uint _BlockLength;

        public uint BlockLength
        {
            get { return Bits.BigEndian(_BlockLength); }
            set { _BlockLength = Bits.BigEndian(value); }
        }

        public override string ToString()
        {
            return Internal.GenericToString(this, false);
        }
    }

    public enum ServiceAction : short
    {
        None = 0x00,
        Read32 = 0x0009
    }

    public enum DataTransferDirection : byte
    {
        /// <summary>Send data to the drive</summary>
        [Description("Send data to the drive")] SendData,
        /// <summary>Receive data from the drive</summary>
        [Description("Receive data from the drive")] ReceiveData,
        /// <summary>No data transfer</summary>
        [Description("No data transfer")] NoData,
    }

    public enum ScsiTimeoutGroup
    {
        None = 0,
        Group1 = 1,
        Group2 = 2,
        Group3 = 3
    }
}