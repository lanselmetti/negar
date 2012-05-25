using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class WriteSpeedDescriptor : PerformanceDescriptor
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte ROTATION_CONTROL_MASK = 0x18;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte0;

        /// <summary>Must be zero.</summary>
        public RotationControl WriteRotationControl
        {
            get { return (RotationControl) Bits.GetValueMask(byte0, 3, ROTATION_CONTROL_MASK); }
            set { byte0 = Bits.PutValueMask(byte0, (byte) value, 3, ROTATION_CONTROL_MASK); }
        }

        public bool RDD
        {
            get { return Bits.GetBit(byte0, 2); }
            set { byte0 = Bits.SetBit(byte0, 2, value); }
        }

        public bool Exact
        {
            get { return Bits.GetBit(byte0, 1); }
            set { byte0 = Bits.SetBit(byte0, 1, value); }
        }

        public bool MountRainierRewritable
        {
            get { return Bits.GetBit(byte0, 0); }
            set { byte0 = Bits.SetBit(byte0, 0, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte1;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte2;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte3;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private uint _EndLogicalBlockAddress;

        public uint EndLogicalBlockAddress
        {
            get { return Bits.BigEndian(_EndLogicalBlockAddress); }
            set { _EndLogicalBlockAddress = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private uint _ReadSpeed;

        /// <summary>The lowest read performance data of all Blocks in increments of <c>1000</c> (NOT <c>1024</c>) bytes per second.</summary>
        public uint ReadSpeed
        {
            get { return Bits.BigEndian(_ReadSpeed); }
            set { _ReadSpeed = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private uint _WriteSpeed;

        /// <summary>The lowest write performance data of all Blocks in increments of <c>1000</c> (NOT <c>1024</c>) bytes per second.</summary>
        public uint WriteSpeed
        {
            get { return Bits.BigEndian(_WriteSpeed); }
            set { _WriteSpeed = Bits.BigEndian(value); }
        }
    }
}