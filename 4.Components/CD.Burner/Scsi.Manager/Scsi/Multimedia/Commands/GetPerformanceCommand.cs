using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class GetPerformanceCommand : FixedLengthScsiCommand
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte DATA_TYPE_MASK = 0x1F;

        public GetPerformanceCommand() : base(ScsiCommandCode.GetPerformance)
        {
        }

        public GetPerformanceCommand(uint startLBA, ushort maxDescriptorCount, PerformanceInformation dataType)
            : this(startLBA, maxDescriptorCount, PerformanceType.Performance, new PerformanceDataType(dataType))
        {
        }

        public GetPerformanceCommand(uint startLBA, ushort maxDescriptorCount, UnusableAreaInformation dataType)
            : this(startLBA, maxDescriptorCount, PerformanceType.UnusableArea, new PerformanceDataType(dataType))
        {
        }

        public GetPerformanceCommand(uint startLBA, ushort maxDescriptorCount, DefectStatusReportInformation dataType)
            : this(startLBA, maxDescriptorCount, PerformanceType.DefectStatusData, new PerformanceDataType(dataType))
        {
        }

        public GetPerformanceCommand(uint startLBA, ushort maxDescriptorCount, WriteSpeedInformation dataType)
            : this(startLBA, maxDescriptorCount, PerformanceType.WriteSpeed, new PerformanceDataType(dataType))
        {
        }

        public GetPerformanceCommand(uint startLBA, ushort maxDescriptorCount, PerformanceType type,
                                     PerformanceDataType dataType)
            : this()
        {
            DataType = dataType;
            StartingLogicalBlockAddress = startLBA;
            MaximumNumberOfDescriptors = maxDescriptorCount;
            PerformanceType = type;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte1;

        public PerformanceDataType DataType
        {
            get { return new PerformanceDataType(Bits.GetValueMask(byte1, 0, DATA_TYPE_MASK)); }
            set { byte1 = Bits.PutValueMask(byte1, value.Value, 0, DATA_TYPE_MASK); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private uint _StartingLogicalBlockAddress;

        public uint StartingLogicalBlockAddress
        {
            get { return Bits.BigEndian(_StartingLogicalBlockAddress); }
            set { _StartingLogicalBlockAddress = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte6;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte7;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ushort _MaximumNumberOfDescriptors;

        public ushort MaximumNumberOfDescriptors
        {
            get { return Bits.BigEndian(_MaximumNumberOfDescriptors); }
            set { _MaximumNumberOfDescriptors = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private PerformanceType _PerformanceType;

        public PerformanceType PerformanceType
        {
            get { return Bits.BigEndian(_PerformanceType); }
            set { _PerformanceType = Bits.BigEndian(value); }
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