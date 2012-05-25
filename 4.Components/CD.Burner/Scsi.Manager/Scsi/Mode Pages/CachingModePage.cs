using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class CachingModePage : ModePage
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte DEMAND_READ_RETENTION_PRIORITY_MASK = 0xF0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte DEMAND_WRITE_RETENTION_PRIORITY_MASK = 0x0F;

        public CachingModePage() : base(ModePageCode.Caching)
        {
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte2;

        public bool InitiatorControl
        {
            get { return Bits.GetBit(byte2, 7); }
            set { byte2 = Bits.SetBit(byte2, 7, value); }
        }

        public bool AbortPrefetch
        {
            get { return Bits.GetBit(byte2, 6); }
            set { byte2 = Bits.SetBit(byte2, 6, value); }
        }

        public bool CacheAnalysisPermitted
        {
            get { return Bits.GetBit(byte2, 5); }
            set { byte2 = Bits.SetBit(byte2, 5, value); }
        }

        public bool Discontinuity
        {
            get { return Bits.GetBit(byte2, 4); }
            set { byte2 = Bits.SetBit(byte2, 4, value); }
        }

        public bool SizeEnable
        {
            get { return Bits.GetBit(byte2, 3); }
            set { byte2 = Bits.SetBit(byte2, 3, value); }
        }

        public bool WritebackCacheEnable
        {
            get { return Bits.GetBit(byte2, 2); }
            set { byte2 = Bits.SetBit(byte2, 2, value); }
        }

        public bool MultiplicationFactor
        {
            get { return Bits.GetBit(byte2, 1); }
            set { byte2 = Bits.SetBit(byte2, 1, value); }
        }

        public bool ReadCacheDisable
        {
            get { return Bits.GetBit(byte2, 0); }
            set { byte2 = Bits.SetBit(byte2, 0, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte3;

        public DemandReadRetentionPriority DemandReadRetentionPriority
        {
            get { return (DemandReadRetentionPriority) Bits.GetValueMask(byte3, 4, DEMAND_READ_RETENTION_PRIORITY_MASK); }
            set { byte3 = Bits.PutValueMask(byte3, (byte) value, 4, DEMAND_READ_RETENTION_PRIORITY_MASK); }
        }

        public DemandWriteRetentionPriority DemandWriteRetentionPriority
        {
            get { return (DemandWriteRetentionPriority) Bits.GetValueMask(byte3, 4, DEMAND_WRITE_RETENTION_PRIORITY_MASK); }
            set { byte3 = Bits.PutValueMask(byte3, (byte) value, 4, DEMAND_WRITE_RETENTION_PRIORITY_MASK); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ushort _DisablePrefetchTransferBlockCount;

        public ushort DisablePrefetchTransferBlockCount
        {
            get { return Bits.BigEndian(_DisablePrefetchTransferBlockCount); }
            set { _DisablePrefetchTransferBlockCount = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ushort _MinimumPrefetch;

        public ushort MinimumPrefetch
        {
            get { return Bits.BigEndian(_MinimumPrefetch); }
            set { _MinimumPrefetch = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ushort _MaximumPrefetch;

        public ushort MaximumPrefetch
        {
            get { return Bits.BigEndian(_MaximumPrefetch); }
            set { _MaximumPrefetch = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ushort _MaximumPrefetchCeiling;

        public ushort MaximumPrefetchCeiling
        {
            get { return Bits.BigEndian(_MaximumPrefetchCeiling); }
            set { _MaximumPrefetchCeiling = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte12;

        public bool ForceSequentialWrite
        {
            get { return Bits.GetBit(byte12, 7); }
            set { byte12 = Bits.SetBit(byte12, 7, value); }
        }

        public bool LogicalBlockCacheSegmentSize
        {
            get { return Bits.GetBit(byte12, 6); }
            set { byte12 = Bits.SetBit(byte12, 6, value); }
        }

        public bool DisableReadAhead
        {
            get { return Bits.GetBit(byte12, 5); }
            set { byte12 = Bits.SetBit(byte12, 5, value); }
        }

        public bool NonvolatileCacheDisabled
        {
            get { return Bits.GetBit(byte12, 0); }
            set { byte12 = Bits.SetBit(byte12, 0, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _NumberOfCacheSegments;

        public byte NumberOfCacheSegments
        {
            get { return _NumberOfCacheSegments; }
            set { _NumberOfCacheSegments = value; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ushort _CacheSegmentSize;

        public ushort CacheSegmentSize
        {
            get { return Bits.BigEndian(_CacheSegmentSize); }
            set { _CacheSegmentSize = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
#pragma warning disable 0169
            private byte byte16;
#pragma warning restore 0169
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _byte17; //MSB
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _byte18;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _byte19; //LSB

        [Obsolete]
        public uint NonCacheSegmentSize
        {
            get
            {
                unchecked
                {
                    return _byte19 | ((uint) _byte18 << 8) | ((uint) _byte17 << 16);
                }
            }
            set
            {
                unchecked
                {
                    _byte19 = (byte) (value >> 0);
                    _byte18 = (byte) (value >> 8);
                    _byte17 = (byte) (value >> 16);
                }
            }
        }
    }

    public enum DemandReadRetentionPriority : byte
    {
        NoDistinction = 0x0,
        LowerReadPriority = 0x1,
        ZeroReadPriority = 0xF,
    }

    public enum DemandWriteRetentionPriority : byte
    {
        NoDistinction = 0x0,
        LowerWritePriority = 0x1,
        ZeroWritePriority = 0xF,
    }
}