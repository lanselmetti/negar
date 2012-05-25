using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Block
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class BlockLimitsVitalProductDataPage : VitalProductDataInquiryData
    {
        public BlockLimitsVitalProductDataPage() : base(VitalProductDataPageCode.BlockLimits)
        {
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte4;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte5;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ushort _OptimalTransferBlockCountGranularity;

        public ushort OptimalTransferBlockCountGranularity
        {
            get { return Bits.BigEndian(_OptimalTransferBlockCountGranularity); }
            set { _OptimalTransferBlockCountGranularity = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private uint _MaximumTransferBlockCount;

        public uint MaximumTransferBlockCount
        {
            get { return Bits.BigEndian(_MaximumTransferBlockCount); }
            set { _MaximumTransferBlockCount = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private uint _OptimalTransferBlockCount;

        public uint OptimalTransferBlockCount
        {
            get { return Bits.BigEndian(_OptimalTransferBlockCount); }
            set { _OptimalTransferBlockCount = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private uint _MaximumPrefetchXTransferBlockCount;

        public uint MaximumPrefetchXTransferBlockCount
        {
            get { return Bits.BigEndian(_MaximumPrefetchXTransferBlockCount); }
            set { _MaximumPrefetchXTransferBlockCount = Bits.BigEndian(value); }
        }
    }
}