using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class DefectStatusDescriptor : PerformanceDescriptor
    {
        private const byte FIRST_BIT_OFFSET_MASK = 0x7;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private uint _StartLogicalBlockAddress;

        public uint StartLogicalBlockAddress
        {
            get { return Bits.BigEndian(_StartLogicalBlockAddress); }
            set { _StartLogicalBlockAddress = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private uint _EndLogicalBlockAddress;

        public uint EndLogicalBlockAddress
        {
            get { return Bits.BigEndian(_EndLogicalBlockAddress); }
            set { _EndLogicalBlockAddress = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _BlockingFactor;

        public byte BlockingFactor
        {
            get { return _BlockingFactor; }
            set { _BlockingFactor = value; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte9;

        public byte FirstBitOffset
        {
            get { return Bits.GetValueMask(byte9, 0, FIRST_BIT_OFFSET_MASK); }
            set { byte9 = Bits.PutValueMask(byte9, value, 0, FIRST_BIT_OFFSET_MASK); }
        }

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2048 - 10), DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte[] _DefectStatuses = new byte[2048 - 10];

        public bool GetDefectStatus(ushort index)
        {
            return (_DefectStatuses[index >> 3] & (index%8)) != 0;
        }

        public void SetDefectStatus(ushort index, bool value)
        {
            _DefectStatuses[index >> 3] = Bits.SetBit(_DefectStatuses[index >> 3], 7, value);
        }
    }
}