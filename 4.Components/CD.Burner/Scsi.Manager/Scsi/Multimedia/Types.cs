using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Helper;

namespace Scsi.Multimedia
{
    public enum GeneralDiscType
    {
        None = 0,
        CompactDisc,
        DigitalVersatileDisc,
        HighDensityDigitalVersatileDisc,
        BluRayDisc,
        Unknown = -1,
    }

    public enum TrackSessionCloseFunction : byte
    {
        /// <summary>Stops a background format on a DVD+RW or DVD+RW DL disc (quick).</summary>
        [Description("Stops a background format on a DVD+RW or DVD+RW DL disc (quick).")] QuickStopBackgroundFormat =
            0x00,
        /// <summary>Closes a logical track on a CD-R, CD-RW, DVD-R, DVD-RW, DVD-R DL, DVD+R, DVD+R DL, HD DVD-R, or BD-R disc. </summary>
        [Description(
            "Closes a logical track on a CD-R, CD-RW, DVD-R, DVD-RW, DVD-R DL, DVD+R, DVD+R DL, HD DVD-R, or BD-R disc. "
            )] CloseLogicalTrack = 0x01,
        /// <summary>Closes a session on a CD-R, CD-RW, DVD-R, DVD-RW, DVD-R DL, DVD+R, DVD+R DL, HD DVD-R, or BD-R disc. NOTE: For a CD-R, CD-RW, and DVD-R, the disc is also finalized! Stops a background format (compatibility) for DVD+RW and DVD+RW DL discs with radius >= 30 mm. Stops a background format on MountRainierRewritable discs.</summary>
        [Description(
            "Closes a session on a CD-R, CD-RW, DVD-R, DVD-RW, DVD-R DL, DVD+R, DVD+R DL, HD DVD-R, or BD-R disc. NOTE: For a CD-R, CD-RW, and DVD-R, the disc is also finalized! Stops a background format (compatibility) for DVD+RW and DVD+RW DL discs with radius >= 30 mm. Stops a background format on MountRainierRewritable discs."
            )] CloseSessionOrStopBGFormat = 0x02,
        /// <summary>Stops a background format (compatibility) on a DVD+RW and DVD+RW DL disc, or finalizes a DVD-RW disc.</summary>
        [Description(
            "Stops a background format (compatibility) on a DVD+RW and DVD+RW DL disc, or finalizes a DVD-RW disc.")] StopBGFormatOrFinalizeDvdMinusRW = 0x03,
        /// <summary>Closes a session and records an extended leadout on a DVD+R DL disc. RESERVED for other discs!</summary>
        [Description("Closes a session and records an extended leadout on a DVD+R DL disc. RESERVED for other discs!")] CloseSessionWithExtendedLeadout = 0x04,
        /// <summary>Finalizes a DVD+R or DVD+R DL disc with >= 30 mm radius.</summary>
        [Description("Finalizes a DVD+R or DVD+R DL disc with >= 30 mm radius.")] FinalizeLargeDvdPlusR = 0x05,
        /// <summary>Finalizes a DVD+R, DVD+R DL, HD DVD-R, or BD-R disc.</summary>
        [Description("Finalizes a DVD+R, DVD+R DL, HD DVD-R, or BD-R disc.")] Finalize = 0x06,
    }

    public enum KeyClass : byte
    {
        DvdCssCppmOrCprm = 0x00,
        AdvancedAccessContentSystem = 0x02,
        VCPS = 0x20,
    }

    public enum KeyFormat : byte
    {
        None = 0x3F,

        #region DvdContentScramblingSystemContentProtectionForPrerecordedMediaOrContentProtectionForRecordableMedia

        AuthenticationGrantIdForContentScramblingSystemOrContentProtectionForPrerecordedMedia = 0x00,
        ChallengeKey = 0x01,
        Key1 = 0x02,
        TitleKey = 0x04,
        AuthenticationSuccess = 0x05,
        ReportDriveRegionSettings = 0x08,

        #endregion

        #region AdvancedAccessContentSystem

        AuthenticationGrantIdForAdvancedAccessContentSystem = 0x00,
        DriveCertificateChallenge = 0x01,
        DriveKey = 0x02,
        GenerateAndReturnBindingNonce = 0x20,
        ReturnBindingNonce = 0x21,

        #endregion
    }

    [StructLayout(LayoutKind.Explicit, Pack = 1)]
    public struct ReadBufferCapacityInfo
    {
        [FieldOffset(0)] [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ushort _DataLength;

        /// <summary>Do not use this value unless you are responsible for calling the <see cref="IScsiPassThrough.ExecuteCommand"/> method directly.</summary>
        public ushort DataLength
        {
            get { return Bits.BigEndian(_DataLength); }
            set { _DataLength = Bits.BigEndian(value); }
        }

        [FieldOffset(2)] public BufferCapacityStructureInBytes Bytes;
        [FieldOffset(2)] public BufferCapacityStructureInBlocks Blocks;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct BufferCapacityStructureInBytes
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte2;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte3;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private uint _BufferLength;

        public uint BufferLength
        {
            get { return Bits.BigEndian(_BufferLength); }
            set { _BufferLength = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private uint _BlankBufferLength;

        public uint BlankBufferLength
        {
            get { return Bits.BigEndian(_BlankBufferLength); }
            set { _BlankBufferLength = Bits.BigEndian(value); }
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct BufferCapacityStructureInBlocks
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte2;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte3;

        public bool Block
        {
            get { return Bits.GetBit(byte3, 0); }
            set { byte3 = Bits.SetBit(byte3, 0, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte4;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte5;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte6;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte7;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private uint _AvailableBufferLength;

        public uint AvailableBufferLength
        {
            get { return Bits.BigEndian(_AvailableBufferLength); }
            set { _AvailableBufferLength = Bits.BigEndian(value); }
        }
    }

    [StructLayout(LayoutKind.Explicit, Pack = 1)]
    public struct PerformanceDataType
    {
        public PerformanceDataType(byte value) : this()
        {
            Value = value;
        }

        public PerformanceDataType(PerformanceInformation data) : this()
        {
            _Performance = data;
        }

        public PerformanceDataType(UnusableAreaInformation data) : this()
        {
            _UnusableArea = data;
        }

        public PerformanceDataType(DefectStatusReportInformation data) : this()
        {
            _DefectStatusReport = data;
        }

        public PerformanceDataType(WriteSpeedInformation data) : this()
        {
            _WriteSpeed = data;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] [FieldOffset(0)] private readonly PerformanceInformation
            _Performance;

        public PerformanceInformation Performance
        {
            get { return _Performance; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] [FieldOffset(0)] private readonly UnusableAreaInformation
            _UnusableArea;

        public UnusableAreaInformation UnusableArea
        {
            get { return _UnusableArea; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] [FieldOffset(0)] private readonly
            DefectStatusReportInformation _DefectStatusReport;

        public DefectStatusReportInformation DefectStatusReport
        {
            get { return _DefectStatusReport; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] [FieldOffset(0)] private readonly WriteSpeedInformation
            _WriteSpeed;

        public WriteSpeedInformation WriteSpeed
        {
            get { return _WriteSpeed; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] [FieldOffset(0)] public readonly byte Value;

        public override string ToString()
        {
            return Internal.GenericToString(this, false);
        }
    }

    /// <summary>The Performance Descriptors for nominal performance are intended to give the host an approximation of Drive performance. All numbers are nominal. On CD media, all sectors are reported as 2352 byte sectors. The descriptor includes a Start LogicalBlockAddress value, a Start Performance value in increments of 1000 Bytes/second, an End LogicalBlockAddress value, and an End Performance value in increments of 1000 Bytes/second.</summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PerformanceInformation
    {
        public PerformanceInformation(bool write, ExceptionList except, Tolerance tolerance) : this()
        {
            Write = write;
            Except = except;
            Tolerance = tolerance;
        }

        private byte Value;

        public bool Write
        {
            get { return Bits.GetBit(Value, 2); }
            set { Value = Bits.SetBit(Value, 2, value); }
        }

        public ExceptionList Except
        {
            get { return (ExceptionList) Bits.GetValueMask(Value, 0, (byte) 0x3); }
            set { Value = Bits.PutValueMask(Value, (byte) value, 0, (byte) 0x3); }
        }

        public Tolerance Tolerance
        {
            get { return (Tolerance) Bits.GetValueMask(Value, 3, (byte) 0x18); }
            set { Value = Bits.PutValueMask(Value, (byte) value, 3, (byte) 0x18); }
        }

        public override string ToString()
        {
            return Internal.GenericToString(this, false);
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct UnusableAreaInformation
    {
        public UnusableAreaInformation(UsableAreaType type) : this()
        {
            UsableAreaType = type;
        }

        private byte Value;

        public UsableAreaType UsableAreaType
        {
            get { return (UsableAreaType) Bits.GetValueMask(Value, 0, (byte) 0x7); }
            set { Value = Bits.PutValueMask(Value, (byte) value, 0, (byte) 0x7); }
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct DefectStatusReportInformation
    {
        private byte value;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct WriteSpeedInformation
    {
        private byte value;
    }

    public enum UsableAreaType : byte
    {
        ZoneBoundaryInformation = 0x0,
        PDLInformation = 0x1,
        SDLInformation = 0x2,
    }

    public enum Tolerance : byte
    {
        [Obsolete("This value is invalid.", false)] None = 0x00,
        NominalPerformance10Exception20 = 0x2,
    }

    public enum ExceptionList : byte
    {
        NominalPerformanceParameters = 0x0,
        EntirePerformanceExceptionList = 0x1,
        OutlyingPerformanceExceptions = 0x2,
    }

    public enum PerformanceType : byte
    {
        Performance = 0x00,
        UnusableArea = 0x01,
        DefectStatusData = 0x02,
        WriteSpeed = 0x03,
        DefectiveBlockInformation = 0x04,
        DefectiveBlockInformationCacheZone = 0x05,
    }

    [StructLayout(LayoutKind.Explicit, Pack = 1)]
    public struct LogicalTrackReservationParameter
    {
        public LogicalTrackReservationParameter(uint reservationSizeOrLBA, bool isLogicalBlockAddress)
            : this()
        {
            if (isLogicalBlockAddress)
            {
                ReservationLogicalBlockAddress = reservationSizeOrLBA;
            }
            else
            {
                ReservationSize = reservationSizeOrLBA;
            }
        }

        [FieldOffset(3), DebuggerBrowsable(DebuggerBrowsableState.Never)] private uint _ReservationSize;

        /// <summary>The number of user blocks desired for track reservation.</summary>
        [Description("The number of user blocks desired for track reservation.")]
        public uint ReservationSize
        {
            get { return Bits.BigEndian(_ReservationSize); }
            set { _ReservationSize = Bits.BigEndian(value); }
        }

        [FieldOffset(0), DebuggerBrowsable(DebuggerBrowsableState.Never)] private uint _ReservationLogicalBlockAddress;

        public uint ReservationLogicalBlockAddress
        {
            get { return Bits.BigEndian(_ReservationLogicalBlockAddress); }
            set { _ReservationLogicalBlockAddress = Bits.BigEndian(value); }
        }
    }

    public enum StreamingDataType : byte
    {
        PerformanceDescriptor = 0x00,
        DefectiveBlockInformationCacheZoneDescriptor = 0x05,
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class DefectiveBlockInformationCacheZoneDescriptors : IMarshalable
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly IntPtr DESCRIPTORS_OFFSET =
            Marshal.OffsetOf(typeof (DefectiveBlockInformationCacheZoneDescriptors), "_Descriptors");

        public DefectiveBlockInformationCacheZoneDescriptors()
        {
            DefectiveBlockInformationCacheZoneDataLength =
                (uint)
                (Marshaler.DefaultSizeOf<DefectiveBlockInformationCacheZoneDescriptors>() -
                 1*Marshaler.DefaultSizeOf<DefectiveBlockInformationCacheZoneDescriptor>());
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private uint _DefectiveBlockInformationCacheZoneDataLength;

        /// <summary>Do not use this value unless you are responsible for calling the <see cref="IScsiPassThrough.ExecuteCommand"/> method directly.</summary>
        public uint DefectiveBlockInformationCacheZoneDataLength
        {
            get { return Bits.BigEndian(_DefectiveBlockInformationCacheZoneDataLength); }
            private set { _DefectiveBlockInformationCacheZoneDataLength = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte4;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte5;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte6;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte7;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)] private DefectiveBlockInformationCacheZoneDescriptor[]
            _Descriptors;

        public DefectiveBlockInformationCacheZoneDescriptor[] Descriptors
        {
            get { return _Descriptors; }
            set
            {
                _Descriptors = value;
                DefectiveBlockInformationCacheZoneDataLength = value == null
                                                                   ? 0
                                                                   : (uint)
                                                                     (Marshaler.DefaultSizeOf
                                                                          <DefectiveBlockInformationCacheZoneDescriptor>
                                                                          ()*value.Length);
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected virtual int MarshaledSize
        {
            get
            {
                return Marshal.SizeOf(this) +
                       Marshaler.DefaultSizeOf<DefectiveBlockInformationCacheZoneDescriptor>()*
                       ((int) DefectiveBlockInformationCacheZoneDataLength - 1);
            }
        }

        protected virtual void MarshalFrom(BufferWithSize buffer)
        {
            Marshaler.DefaultPtrToStructure(buffer, this);
            Descriptors =
                new DefectiveBlockInformationCacheZoneDescriptor[
                    DefectiveBlockInformationCacheZoneDataLength/
                    Marshaler.DefaultSizeOf<DefectiveBlockInformationCacheZoneDescriptor>()];
            unsafe
            {
                BufferWithSize descriptors = buffer.ExtractSegment(DESCRIPTORS_OFFSET);
                for (int i = 0; i < Descriptors.Length; i++)
                {
                    Descriptors[i] =
                        descriptors.Read<DefectiveBlockInformationCacheZoneDescriptor>(i*
                                                                                       sizeof (
                                                                                           DefectiveBlockInformationCacheZoneDescriptor
                                                                                           ));
                }
            }
        }

        protected virtual void MarshalTo(BufferWithSize buffer)
        {
            Marshaler.DefaultStructureToPtr((object) this, buffer);
            unsafe
            {
                BufferWithSize descriptors = buffer.ExtractSegment(DESCRIPTORS_OFFSET);
                for (int i = 0; i < Descriptors.Length; i++)
                {
                    descriptors.Write(Descriptors[i], i*sizeof (DefectiveBlockInformationCacheZoneDescriptor));
                }
            }
        }

        void IMarshalable.MarshalFrom(BufferWithSize buffer)
        {
            MarshalFrom(buffer);
        }

        void IMarshalable.MarshalTo(BufferWithSize buffer)
        {
            MarshalTo(buffer);
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        int IMarshalable.MarshaledSize
        {
            get { return MarshaledSize; }
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct DefectiveBlockInformationCacheZoneDescriptor
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private uint
            _StartLogicalBlockAddressOfDefectiveBlockInformationCacheZone;

        public uint StartLogicalBlockAddressOfDefectiveBlockInformationCacheZone
        {
            get { return Bits.BigEndian(_StartLogicalBlockAddressOfDefectiveBlockInformationCacheZone); }
            set { _StartLogicalBlockAddressOfDefectiveBlockInformationCacheZone = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte4;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte5;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte6;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte7;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct StreamingPerformanceDescriptor
    {
        public StreamingPerformanceDescriptor(bool randomAccess, bool exact, uint startLogicalBlockAddress,
                                              uint endLogicalBlockAddress, uint readSize, TimeSpan readTime,
                                              uint writeSize, TimeSpan writeTime)
            : this()
        {
            RandomAccess = randomAccess;
            Exact = exact;
            StartLogicalBlockAddress = startLogicalBlockAddress;
            EndLogicalBlockAddress = endLogicalBlockAddress;
            ReadSize = readSize;
            ReadTime = readTime;
            WriteSize = writeSize;
            WriteTime = writeTime;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte0;

        public bool RandomAccess
        {
            get { return Bits.GetBit(byte0, 0); }
            set { byte0 = Bits.SetBit(byte0, 0, value); }
        }

        public bool Exact
        {
            get { return Bits.GetBit(byte0, 1); }
            set { byte0 = Bits.SetBit(byte0, 1, value); }
        }

        public bool RestoreDriveDefaults
        {
            get { return Bits.GetBit(byte0, 2); }
            set { byte0 = Bits.SetBit(byte0, 2, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte1;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte2;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte3;
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

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private uint _ReadSize;

        /// <summary>Number of kilobytes to be read per <see cref="ReadTime"/></summary>
        [Description("Number of kilobytes to be read per ReadTime")]
        public uint ReadSize
        {
            get { return Bits.BigEndian(_ReadSize); }
            set { _ReadSize = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private int _ReadTime;

        /// <summary>The amount of time, in milliseconds, over that the <see cref="ReadTime"/> is expected to be read</summary>
        [Description("The amount of time, in milliseconds, over that the ReadTime is expected to be read")]
        public TimeSpan ReadTime
        {
            get { return TimeSpan.FromMilliseconds(Bits.BigEndian(_ReadTime)); }
            set { _ReadTime = Bits.BigEndian((int) value.TotalMilliseconds); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private uint _WriteSize;

        /// <summary>Number of kilobytes to be written per <see cref="WriteTime"/></summary>
        [Description("Number of kilobytes to be written per WriteTime")]
        public uint WriteSize
        {
            get { return Bits.BigEndian(_WriteSize); }
            set { _WriteSize = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private int _WriteTime;

        /// <summary>The amount of time, in milliseconds, over that the <see cref="WriteTime"/> is expected to be written</summary>
        [Description("The amount of time, in milliseconds, over that the WriteTime is expected to be written")]
        public TimeSpan WriteTime
        {
            get { return TimeSpan.FromMilliseconds(Bits.BigEndian(_WriteTime)); }
            set { _WriteTime = Bits.BigEndian((int) value.TotalMilliseconds); }
        }
    }

    public enum DescriptorType : byte
    {
        UnformattedOrBlankMedia = 0x0,
        FormattedMedia = 0x1,
        NoMediaPresentOrUnknownCapacity = 0x2,
    }

    public enum FormatType : byte
    {
        FullFormat = 0x00,
        SpareAreaExpansion = 0x01,
        ZoneReformat = 0x04,
        ZoneFormat = 0x05,
        CDRWOrDvdMinusRWFullFormat = 0x10,
        CDRWOrDvdMinusRWGrowSession = 0x11,
        CDRWOrDvdMinusRWAddSession = 0x12,
        DvdMinusRWQuickGrowLastBorder = 0x13,
        DvdMinusRWQuickAddBorder = 0x14,
        DvdMinusRWQuickFormat = 0x15,
        HDDvdRTestZoneExpansion = 0x16,
        FullFormatWithSparingParameters = 0x20,
        MountRainierRewritableFormat = 0x24,
        DvdPlusRWBasicFormat = 0x26,
        BDREFullFormatWithSpareAreas = 0x30,
        BDREFullFormatWithoutSpareAreas = 0x31,
        BDRFullFormatWithSpareAreas = 0x32,
    }

    public enum FormatCode : byte
    {
        None = 0x00,
        Other = 0x1,
        CDRW = 0x7,
    }

    public enum TrackIdentificationType : byte
    {
        /// <summary>Matches the logical track that contains the given LogicalBlockAddress.</summary>
        [Description("Matches the logical track that contains the given LogicalBlockAddress.")] LogicalBlockAddress =
            0x0,
        /// <summary>Matches the logical track with the given track number.</summary>
        [Description("Matches the logical track with the given track number.")] LogicalTrackNumber = 0x1,
        /// <summary>Matches the first logical track for the given session.</summary>
        [Description("Matches the first logical track for the given session.")] SessionNumber = 0x2,
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1 /*, Size = 48*/)]
    public struct TrackInformationBlock : IMarshalable
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte TRACK_MODE_MASK = 0x0F;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte DATA_MODE_MASK = 0x0F;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte LAYER_JUMP_RECORDING_STATUS_MASK = 0xC0;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ushort _DataLength;

        /// <summary>Do not use this value unless you are responsible for calling the <see cref="IScsiPassThrough.ExecuteCommand"/> method directly.</summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ushort DataLength
        {
            get { return Bits.BigEndian(_DataLength); }
            set { _DataLength = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _LogicalTrackNumberLSB;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _SessionNumberLSB;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte4;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte5;

        public TrackMode TrackMode
        {
            get { return (TrackMode) Bits.GetValueMask(byte5, 0, TRACK_MODE_MASK); }
            set { byte5 = Bits.PutValueMask(byte5, (byte) value, 0, TRACK_MODE_MASK); }
        }

        public bool Copy
        {
            get { return Bits.GetBit(byte5, 4); }
            set { byte5 = Bits.SetBit(byte5, 4, value); }
        }

        public bool Damage
        {
            get { return Bits.GetBit(byte5, 5); }
            set { byte5 = Bits.SetBit(byte5, 5, value); }
        }

        public LayerJumpRecordingStatus LayerJumpRecordingStatus
        {
            get { return (LayerJumpRecordingStatus) Bits.GetValueMask(byte5, 6, LAYER_JUMP_RECORDING_STATUS_MASK); }
            set { byte5 = Bits.PutValueMask(byte5, (byte) value, 6, LAYER_JUMP_RECORDING_STATUS_MASK); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte6;

        public DataMode DataMode
        {
            get { return (DataMode) Bits.GetValueMask(byte6, 0, DATA_MODE_MASK); }
            set { byte6 = Bits.PutValueMask(byte6, (byte) value, 0, DATA_MODE_MASK); }
        }

        public bool FixedPacket
        {
            get { return Bits.GetBit(byte6, 4); }
            set { byte6 = Bits.SetBit(byte6, 4, value); }
        }

        public bool PacketOrIncrement
        {
            get { return Bits.GetBit(byte6, 5); }
            set { byte6 = Bits.SetBit(byte6, 5, value); }
        }

        public bool Blank
        {
            get { return Bits.GetBit(byte6, 6); }
            set { byte6 = Bits.SetBit(byte6, 6, value); }
        }

        public bool ReservedTrack
        {
            get { return Bits.GetBit(byte6, 7); }
            set { byte6 = Bits.SetBit(byte6, 7, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte7;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool NextWritableAddressValid
        {
            get { return Bits.GetBit(byte7, 0); }
            set { byte7 = Bits.SetBit(byte7, 0, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool LastRecordedAddressValid
        {
            get { return Bits.GetBit(byte7, 1); }
            set { byte7 = Bits.SetBit(byte7, 1, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private uint _LogicalTrackStartAddress;

        public uint LogicalTrackStartAddress
        {
            get { return Bits.BigEndian(_LogicalTrackStartAddress); }
            set { _LogicalTrackStartAddress = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private uint _NextWritableAddress;

        /// <summary>
        /// <para>The logical block address of the next writable user block in the track.</para>
        /// <para>NOTE: If the write type is RAW, this field may be a negative number as required to point to the start of the first lead-in, which would alter the range of this field to [-41450, 4294922146], both inclusive. (Hexadecimal 0xFFFF4FA2 to 0xFFFFFFFF, inclusive, are negative, and the rest are positive.)</para>
        /// </summary>
        public uint? NextWritableAddress
        {
            get { return NextWritableAddressValid ? (uint?) Bits.BigEndian(_NextWritableAddress) : null; }
            set
            {
                NextWritableAddressValid = value != null;
                _NextWritableAddress = Bits.BigEndian(value.GetValueOrDefault());
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private uint _FreeBlocks;

        public uint FreeBlocks
        {
            get { return Bits.BigEndian(_FreeBlocks); }
            set { _FreeBlocks = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private uint _BlockingFactor;

        public uint BlockingFactor
        {
            get { return Bits.BigEndian(_BlockingFactor); }
            set { _BlockingFactor = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private uint _LogicalTrackSize;

        public uint LogicalTrackSize
        {
            get { return Bits.BigEndian(_LogicalTrackSize); }
            set { _LogicalTrackSize = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private uint _LastRecordedAddress;

        public uint? LastRecordedAddress
        {
            get { return LastRecordedAddressValid ? (uint?) Bits.BigEndian(_LastRecordedAddress) : null; }
            set
            {
                LastRecordedAddressValid = value != null;
                _LastRecordedAddress = Bits.BigEndian(value.GetValueOrDefault());
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _LogicalTrackNumberMSB;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _SessionNumberMSB;

        public ushort LogicalTrackNumber
        {
            get { return (ushort) (_LogicalTrackNumberLSB | (_LogicalTrackNumberMSB << 8)); }
            set
            {
                _LogicalTrackNumberLSB = unchecked((byte) value);
                _LogicalTrackNumberMSB = unchecked((byte) (value >> 8));
            }
        }

        public ushort SessionNumber
        {
            get { return (ushort) (_SessionNumberLSB | (_SessionNumberMSB << 8)); }
            set
            {
                _SessionNumberLSB = unchecked((byte) value);
                _SessionNumberMSB = unchecked((byte) (value >> 8));
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte34;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte35;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private uint _ReadCompatibilityLogicalBlockAddress;

        public uint ReadCompatibilityLogicalBlockAddress
        {
            get { return Bits.BigEndian(_ReadCompatibilityLogicalBlockAddress); }
            set { _ReadCompatibilityLogicalBlockAddress = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private uint _NextLayerJumpAddress;

        public uint NextLayerJumpAddress
        {
            get { return Bits.BigEndian(_NextLayerJumpAddress); }
            set { _NextLayerJumpAddress = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private uint _LastLayerJumpAddress;

        public uint LastLayerJumpAddress
        {
            get { return Bits.BigEndian(_LastLayerJumpAddress); }
            set { _LastLayerJumpAddress = Bits.BigEndian(value); }
        }


        public void MarshalFrom(BufferWithSize buffer)
        {
            this = buffer.Read<TrackInformationBlock>();
        }

        public void MarshalTo(BufferWithSize buffer)
        {
            buffer.Write(this);
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public int MarshaledSize
        {
            get { return Marshaler.DefaultSizeOf<TrackInformationBlock>(); }
        }
    }

    public enum LayerJumpRecordingStatus : byte
    {
        DiscAtOnceOrIncremental = 0x0,
        LayerJumpUnspecified = 0x1,
        LayerJumpManual = 0x2,
        LayerJumpRegularInterval = 0x3,
    }

    public enum TrackMode : byte
    {
        /// <summary>Invalid; do not use.</summary>
        [EnumValueDisplayName("CD-ROM, CD-R, or CD-RW")] None = 0x00,
        /// <summary>Data, incremental recording, copy permitted</summary>
        [Description("Data; incremental recording, copy permitted")] [EnumValueDisplayName("DVD+R or DVD+MRW")] DVD =
            0x7,
        /// <summary>Data, uninterrupted recording, no copy permissions</summary>
        [Description("Data, uninterrupted recording, no copy permissions")] [EnumValueDisplayName("All other media")] Other = 0x4,
    }

    public enum DataMode : byte
    {
        None = 0x00,
        /// <summary>Mode 1 (ISO/IEC 10149)</summary>
        [Description("Mode 1 (ISO/IEC 10149)")] Mode1 = 0x01,
        /// <summary>Mode 2 (ISO/IEC 10149 or CD-ROM XA)</summary>
        [Description("Mode 2 (ISO/IEC 10149 or CD-ROM XA)")] Mode2 = 0x02,
        /// <summary>Data Block Type unknown (no track descriptor block)</summary>
        [Description("Data Block Type unknown (no track descriptor block)")] Unknown = 0x0F,
    }

    public enum DeviceBusyStatusCode : byte
    {
        NotBusy = 0x0,
        Busy = 0x1,
    }

    public enum DeviceBusyEventCode : byte
    {
        NoChange = 0x0,
        Changed = 0x1,
    }

    public enum MultipleHostEventCode : byte
    {
        NoChange = 0x0,
        ControlRequest = 0x1,
        ControlGrant = 0x2,
        ControlRelease = 0x3,
    }

    public enum MultipleHostStatusCode : byte
    {
        Ready = 0x0,
        OtherPrevent = 0x1,
    }

    public enum MultipleHostPriority : short
    {
        NoRequest = 0x0,
        Low = 0x1,
        Medium = 0x2,
        High = 0x3,
    }

    public enum ExternalRequestEventCode : byte
    {
        NoChange = 0x0,
        DriveKeyDown = 0x1,
        DriveKeyUp = 0x2,
        ExternalRequestNotification = 0x3,
    }

    public enum ExternalRequestStatusCode : short
    {
        Ready = 0x0,
        OtherPrevent = 0x1,
    }

    public enum ExternalRequestCode : short
    {
        NoRequest = 0x0000,
        Overrun = 0x0001,
        Play = 0x0101,
        RewindOrBack = 0x0102,
        FastForward = 0x0103,
        Pause = 0x0104,
        //0x0105 reserved
        Stop = 0x0106,
        //0x0200-0x02FF ASCII Buttons
        //0xF000-0xFFFF Vendor unique
    }

    public enum PowerEventCode : byte
    {
        NoChange = 0x0,
        PowerChangeSuccessful = 0x1,
        PowerChangeFailed = 0x2,
    }

    public enum PowerStatusCode : byte
    {
        None = 0x00,
        Active = 0x1,
        Idle = 0x2,
        Standby = 0x3,
        Sleep = 0x4,
    }

    public enum OperationalEventCode : byte
    {
        NoChange = 0x0,
        OperationalChangeRequest = 0x1,
        OperationalStateChanged = 0x2,
    }

    public enum OperationalStatusCode : byte
    {
        Available = 0x0,
        TemporarilyBusy = 0x1,
        BusyOrReserved = 0x2,
    }

    public enum OperationalChangeClass : short
    {
        NoChange = 0x0,
        FeatureChange = 0x1,
        AddChange = 0x2,
        Reset = 0x3,
        FirmwareChanged = 0x4,
        InquiryChange = 0x5,
    }

    public enum BlankingType : byte
    {
        /// <summary>
        /// <para>CD-RW: The entire disc is to be blanked. The <see cref="BlankCommand.StartAddressOrLogicalTrackNumber"/> parameter is ignored. This is used for clearing the entire disc. The PCA may be excluded. At completion of the operation, the entire PMA, the area from the start time of the lead-in through the last possible start time of lead-out plus <c>6750</c> blocks.</para>
        /// <para>DVD-RW: The entire disc is to be blanked. The area from the RMA through the end of Last address of data area plus <c>3</c> ECC blocks into the lead-out area is blanked. The RMA Lead-in and six RMD blocks at the beginning of RMA is not blanked. The <see cref="BlankCommand.StartAddressOrLogicalTrackNumber"/> parameter is ignored. If a disc is to be blanked that is already fully blanked, no error is reported.</para>
        /// </summary>
        Blank = 0x00,
        /// <summary>
        /// <para>CD-RW: Blanks only the PMA, disc lead-in and the pre-gap of the first track. The <see cref="BlankCommand.StartAddressOrLogicalTrackNumber"/> parameter is ignored. This is used for blanking a disc quickly. After completion of this command the disc is treated as a blank disc. Caution should be exercised when using this command since the program area may still contain user data.</para>
        /// <para>DVD-RW: This operation is used for blanking a disc quickly. The Lead-in and the RMA are blanked. The RMA Lead-in and six RMD blocks at the beginning of RMA is not blanked. The <see cref="BlankCommand.StartAddressOrLogicalTrackNumber"/> parameter is ignored. Caution should be exercised when using this command since the data area still contains user data. If a disc is to be blanked that is already fully/minimally blanked, no error is reported.</para>
        /// </summary>
        BlankMinimal = 0x01,
        /// <summary>
        /// <para>
        /// CD-RW:
        /// Blanks the track specified in the <see cref="BlankCommand.StartAddressOrLogicalTrackNumber"/> field.
        /// This command blanks the track only, it does not blank the TOC or the PMA. The track to be blanked is in the incomplete session.
        /// If the <see cref="BlankCommand.StartAddressOrLogicalTrackNumber"/> does not reference a track in the incomplete session,
        /// then this command is terminated with <see cref="ScsiStatus.CheckCondition"/> status and the sense code values are set to <see cref="SenseKey.IllegalRequest"/>/<see cref="AdditionalSenseCode.InvalidFieldInCommandDescriptorBlock"/>.
        /// </para>
        /// <para>DVD-RW: Reserved</para>
        /// </summary>
        BlankTrack = 0x02,
        /// <summary>
        /// <para>CD-RW: All data for the last track in the incomplete session is blanked. If the track has a PMA entry, the PMA entry is blanked. If the disc is blank, the command is terminated with <see cref="ScsiStatus.Good"/> status. The <see cref="BlankCommand.StartAddressOrLogicalTrackNumber"/> parameter is ignored.</para>
        /// <para>DVD-RW: This operation is valid only when the last session has the incomplete state. If the last track is invisible, the track that immediately precedes the invisible track and its RMD entry are blanked. If the last track is incomplete, the incomplete track is blanked. The <see cref="BlankCommand.StartAddressOrLogicalTrackNumber"/> parameter is ignored.</para>
        /// </summary>
        UnreserveTrack = 0x03,
        /// <summary>
        /// <para>
        /// CD-RW:
        /// This blank type is valid only for packet tracks within the incomplete session. If <see cref="BlankCommand.StartAddressOrLogicalTrackNumber"/>
        /// specifies a valid LBA within a track and the LBA is the first sector of a packet, then the area between the LBA and the end of the track that is blanked.
        /// If the LBA does not exist in any track within the incomplete session, or if the LBA is not the first sector of a packet, then the command is terminated with
        /// <see cref="ScsiStatus.CheckCondition"/> status and the sense code values are set to <see cref="SenseKey.IllegalRequest"/>/<see cref="AdditionalSenseInformation.LogicalBlockAddressOutOfRange"/>.
        /// If the track is not a packet track, then this command is terminated with <see cref="ScsiStatus.CheckCondition"/> status and the sense code values are set to <see cref="SenseKey.IllegalRequest"/>/<see cref="AdditionalSenseCode.InvalidFieldInCommandDescriptorBlock"/>.
        /// </para>
        /// <para>
        /// DVD-RW:
        /// This blanking type is valid for only a incrementally recorded track. The track to be blanked is in an incomplete session.
        /// Blank the area between the LBA specified in <see cref="BlankCommand.StartAddressOrLogicalTrackNumber"/> field and the end of the track that includes the LBA specified.
        /// When the track that is to be blanked is complete track and if the next track is recorded, the last ECC block of the complete track is retained as BSGA to guarantee next track readable.
        /// If attempting to blank a track that causes generation of fourth NWA, the command is terminated with <see cref="ScsiStatus.CheckCondition"/> status and sense code values are set to <see cref="SenseKey.IllegalRequest"/>/<see cref="AdditionalSenseInformation.NoMoreTrackReservationsAllowed"/>.
        /// The LBA specified is the first user data block of an ECC block and is an existing linking block of a track.
        /// If the start address sector is not a linking block, the command is terminated with <see cref="ScsiStatus.CheckCondition"/> status and the sense code values are set to <see cref="SenseKey.IllegalRequest"/>/<see cref="AdditionalSenseInformation.InvalidAddressForWrite"/>.</para>
        /// </summary>
        BlankTrackTail = 0x04,
        /// <summary>
        /// <para>CD-RW: If the disc is blank or the last session is not empty and not closed, then this command is terminated with <see cref="ScsiStatus.Good"/> status. If the last session is empty or if the disc is finalized, the Lead-in and Lead-out of the last complete session is blanked.</para>
        /// <para>DVD-RW: This blanking type is valid for only a incrementally recorded track. If the disc is blank or the last session is not empty and not closed, then this command is terminated with <see cref="ScsiStatus.Good"/> status. If the last session is empty or if the disc is finalized, the Lead-in and Lead-out of the last complete session is blanked.</para>
        /// </summary>
        UncloseLastSession = 0x05,
        /// <summary>
        /// <para>
        /// CD-RW:
        /// If the last session is empty, then the Lead-in, program area, and Lead-out of the last compete session is blanked.
        /// If the last session is incomplete, its program area is blanked. Each PMA item for each track in the newly blanked session is blanked.
        /// If the disc is blank, the command is terminated with <see cref="ScsiStatus.Good"/> status.
        /// </para>
        /// <para>
        /// DVD-RW:
        /// If the last session is complete, its Lead-in/Border-in through the end of the Lead-out/Border-out is blanked.
        /// If the last session is incomplete state, all track(s) in the incomplete session is blanked.
        /// If the last session is empty state, the complete session immediately preceding the empty session is blanked.
        /// If the disc is blank, the command is terminated with <see cref="ScsiStatus.Good"/> status.
        /// </para>
        /// </summary>
        EraseSession = 0x06,
    }

    public enum SubChannelSelection : byte
    {
        NoSubChannelInfo = 0x0,
        QSubChannel = 0x1,
        RWSubChannel = 0x4,
    }

    public enum C2ErrorCode : byte
    {
        NoError = 0,
        Error1 = 1,
        Error2 = 2,
    }

    [Flags]
    public enum HeaderCodes : byte
    {
        None = 0,
        Header4Byte = 1,
        Subheader8Byte = 2,
        HeaderAndSubheader = 3
    }

    public enum ReadCDExpectedSectorType : byte
    {
        /// <summary>No checking of the data type is performed.</summary>
        AllTypes = 0x0,
        /// <summary>Only IEC 908 (CD-DA) sectors is returned.</summary>
        CDDigitalAudio = 0x1,
        /// <summary>Only sectors with a user data field of <c>2048</c> bytes are returned.</summary>
        Mode1 = 0x2,
        /// <summary>Only sectors with the expanded user data field (<c>2336</c> bytes) are returned.</summary>
        Mode2Formless = 0x3,
        /// <summary>Only sectors that have a user data field of <c>2048</c> bytes are returned.</summary>
        Mode2Form1 = 0x4,
        /// <summary>Only sectors that have a user data field of <c>2324</c> bytes are returned.</summary>
        Mode2Form2 = 0x5
    }

    public enum PhysicalInterfaceStandard
    {
        [EnumValueDisplayName("Unspecified")] Unspecified = 0x00000000,
        [EnumValueDisplayName("SCSI Family")] ScsiFamily = 0x00000001,
        [EnumValueDisplayName("ATAPI")] ATAPI = 0x00000002,
        [EnumValueDisplayName("IEEE 1394/1995")] IEEE1394_1995 = 0x00000003,
        [EnumValueDisplayName("IEEE 1394 A")] IEEE1394A = 0x00000004,
        [EnumValueDisplayName("Fiber Channel")] FiberChannel = 0x00000005,
        [EnumValueDisplayName("IEEE 1394 B")] IEEE1394B = 0x00000006,
        [EnumValueDisplayName("Serial ATAPI")] SerialATAPI = 0x00000007,
        [EnumValueDisplayName("USB")] UniversalSerialBus = 0x00000008,
        [EnumValueDisplayName("Vendor-Unique")] VendorUnique = 0x0000FFFF,
    }

    public enum DataBlockType : byte
    {
        [EnumValueDisplayName("RAW (2352 bytes/sector)")] Raw2352 = 0,
        [EnumValueDisplayName("RAW (2352 bytes/sector) + P/Q subchannel (16 bytes/sector)")] Raw2352WithPQSubchannel16 =
            1,
        [EnumValueDisplayName("RAW (2352 bytes/sector) + P/W subchannel (96 bytes/sector)")] Raw2352WithPWSubchannel96 =
            2,
        [EnumValueDisplayName("RAW (2352 bytes/sector) + RAW P/W subchannel (96 bytes/sector)")] Raw2352WithRawPWSubchannel96 = 3,
        [EnumValueDisplayName("Vendor-Specific Mode 1")] VendorSpecific7 = 7,
        [EnumValueDisplayName("Mode 1 (2048 bytes/sector)")] [Description(
            "Mode 1 data is most prevalent in CD-ROM applications.\r\nThe sync pattern, header and user data are protected by a 32-bit error detection code.\r\nTwo additional layers of error correction, P and Q, collectively called Level 3 correction cover the header and user data.\r\nThis is also referred to as Layered error correction (L-EC or C3)."
            )] Mode1 = 8,
        [EnumValueDisplayName("Mode 2 (2336 bytes/sector)")] Mode2 = 9,
        [EnumValueDisplayName("Mode 2/XA Form 1 (2048 bytes/sector)")] [Description(
            "The Mode 2 form 1 block format is regularly used in recorder applications and Video CD movies.\r\nThe Mode 2 form 1 format is very similar to Mode 1 format.\r\nThe differences are:\r\n- The 8 zero fill bytes have been moved to between the header and user data as two copies of a 4 byte subheader.\r\n- The error detection code, P-parity, and Q-parity do not cover the block header.\r\nThis assures the ability of relocating data, including all parity symbols."
            )] Mode2XAForm1 = 10,
        [EnumValueDisplayName("Mode 2/XA Form 1 (2048 bytes/sector) + Subheader (8 bytes/sector)")] Mode2XAForm1WithSubHeader = 11,
        [EnumValueDisplayName("Mode 2/XA Form 2 (2324 bytes/sector)")] Mode2XAForm2 = 12,
        [EnumValueDisplayName("Mode 2/XA Mixed (2324 bytes/sector) + Subheader (8 bytes/sector)")] Mode2XAMixed = 13,
        [EnumValueDisplayName("Vendor-Specific Mode 2")] VendorSpecific15 = 15,
    }

    [Flags]
    public enum DataBlockTypesSupported : ushort
    {
        [EnumValueDisplayName("RAW (2352 bytes/sector)")] Raw2352 = 1 << DataBlockType.Raw2352,
        [EnumValueDisplayName("RAW (2352 bytes/sector) + P/Q subchannel (16 bytes/sector)")] Raw2352WithPQSubchannel16 =
            1 << DataBlockType.Raw2352WithPQSubchannel16,
        [EnumValueDisplayName("RAW (2352 bytes/sector) + P/W subchannel (96 bytes/sector)")] Raw2352WithPWSubchannel96 =
            1 << DataBlockType.Raw2352WithPWSubchannel96,
        [EnumValueDisplayName("RAW (2352 bytes/sector) + RAW P/W subchannel (96 bytes/sector)")] Raw2352WithRawPWSubchannel96 = 1 << DataBlockType.Raw2352WithRawPWSubchannel96,
        [EnumValueDisplayName("Vendor-Specific Mode 1")] VendorSpecific7 = 1 << DataBlockType.VendorSpecific7,
        [EnumValueDisplayName("Mode 1 (2048 bytes/sector)")] [Description(
            "Mode 1 data is most prevalent in CD-ROM applications.\r\nThe sync pattern, header and user data are protected by a 32-bit error detection code.\r\nTwo additional layers of error correction, P and Q, collectively called Level 3 correction cover the header and user data.\r\nThis is also referred to as Layered error correction (L-EC or C3)."
            )] Mode1 = 1 << DataBlockType.Mode1,
        [EnumValueDisplayName("Mode 2 (2336 bytes/sector)")] Mode2 = 1 << DataBlockType.Mode2,
        [EnumValueDisplayName("Mode 2/XA Form 1 (2048 bytes/sector)")] [Description(
            "The Mode 2 form 1 block format is regularly used in recorder applications and Video CD movies.\r\nThe Mode 2 form 1 format is very similar to Mode 1 format.\r\nThe differences are:\r\n- The 8 zero fill bytes have been moved to between the header and user data as two copies of a 4 byte subheader.\r\n- The error detection code, P-parity, and Q-parity do not cover the block header.\r\nThis assures the ability of relocating data, including all parity symbols."
            )] Mode2XAForm1 = 1 << DataBlockType.Mode2XAForm1,
        [EnumValueDisplayName("Mode 2/XA Form 1 (2048 bytes/sector) + Subheader (8 bytes/sector)")] Mode2XAForm1WithSubHeader = 1 << DataBlockType.Mode2XAForm1WithSubHeader,
        [EnumValueDisplayName("Mode 2/XA Form 2 (2324 bytes/sector)")] Mode2XAForm2 = 1 << DataBlockType.Mode2XAForm2,
        [EnumValueDisplayName("Mode 2/XA Mixed (2324 bytes/sector) + Subheader (8 bytes/sector)")] Mode2XAMixed =
            1 << DataBlockType.Mode2XAMixed,
        [EnumValueDisplayName("Vendor-Specific Mode 2")] VendorSpecific15 = 1 << DataBlockType.VendorSpecific15,
    }

    public enum MultisessionType : byte
    {
        /// <summary>For CD, No B0 pointer. Next Session not allowed. For DVD-R/-RW, next Border not allowed. When current Border is closed, Lead-out is appended after the last Border-out. In the case of DVD-R media, the Next Border Marker in last Border-out is padded with zero bytes and has the Lead-out attribute set.</summary>
        [Description(
            "For CD, No B0 pointer. Next Session not allowed. For DVD-R/-RW, next Border not allowed.\r\nWhen current Border is closed, Lead-out is appended after the last Border-out.\r\nIn the case of DVD-R media, the Next Border Marker in last Border-out is padded with zero bytes and has the Lead-out attribute set."
            )] [EnumValueDisplayName("Single Session (No B0 Pointer)")] SingleSession = 0x00,
        /// <summary>For CD media, B0 pointer is FF:FF:FF. Next session not allowed. Reserved for DVD-R/-RW.</summary>
        [Description("For CD media, B0 pointer is FF:FF:FF. Next session not allowed. Reserved for DVD-R/-RW.")] [EnumValueDisplayName("Single Session (B0 Pointer = -1)")] SingleSessionWithB0Pointer = 0x01,
        // 0x02 reserved
        [Description("For CD media, indicates that a next session is allowed. Reserved for DVD-R/-RW.")] [EnumValueDisplayName("Multisession")] Multisession = 0x03,
    }

    public enum WriteType : byte
    {
        /// <summary>The device performs Packet/Incremental writing when Write commands are issued.</summary>
        [EnumValueDisplayName("Packet/Incremental")] PacketOrIncremental = 0x00,
        /// <summary>The device performs track-at-once recording when write commands are issued, burning the entire track in one pass.</summary>
        [Description(
            "The device performs track-at-once recording when write commands are issued, burning the entire track in one pass."
            )] [EnumValueDisplayName("Track-at-once")] TrackAtOnce = 0x01,
        /// <summary>The device performs Session-at-Once recording, burning the entire session or disc in one pass. For CD, this mode requires that a cue sheet be sent prior to sending write commands.</summary>
        [Description(
            "The device performs Session-at-Once recording, burning the entire session or disc in one pass.\r\nFor CD, this mode requires that a cue sheet be sent prior to sending write commands.\r\nWARNING: This mode is somewhat buggy and may not work correctly!"
            )] [EnumValueDisplayName("Session-at-once")] SessionAtOnce = 0x02,
        /// <summary>
        /// <para>The device writes data as received from the Host. In this mode, the Host sends the Lead-in. The Host should provide Q Sub-channel in this mode, the only valid Data Block Types are 1, 2, and 3. The Next Writable Address starts at the beginning of the Lead-in (this is a negative LBA on a blank disc).</para>
        /// <para>In <see cref="Raw"/> record mode the Drive does not generate run-in and run-out blocks (main and Sub-channel 1 data) but generates and records the link block. Write Type of <see cref="TrackAtOnce"/> and <see cref="Raw"/> are invalid when DVD-R media is present.</para>
        /// </summary>
        [Description(
            "The device writes data as received from the Host. In this mode, the Host sends the Lead-in.\r\nThe Host should provide Q Sub-channel in this mode.\r\nThe next writable address starts at the beginning of the lead-in (this is a negative LBA on a blank disc).\r\nIn RAW record mode the Drive does not generate run-in and run-out blocks (main and Sub-channel 1 data)\r\nbut generates and records the link block.\r\nTrack-at-once and RAW are invalid when DVD-R medium is present."
            )] [EnumValueDisplayName("RAW")] Raw = 0x03,
        /// <summary>The drive performs Layer Jump recording when Write commands are issued. When this write type is specified, buffer underrun protection is always active.</summary>
        [Description(
            "The drive performs Layer Jump recording when Write commands are issued.\r\nWhen this write type is specified, buffer underrun protection is always active."
            )] [EnumValueDisplayName("Layer Jump")] LayerJump = 0x04,
        [Obsolete("May not be correct.", false)] [EnumValueDisplayName("Variable Packet")] VariablePacket = 0x05,
    }

    public enum MultimediaProfile : ushort
    {
        /// <summary>When this is the current profile, the <see cref="CoreFeature"/>, <see cref="MorphingFeature"/>, and <see cref="RemovableMediumFeature"/> features must be current.</summary>
        NoProfile = 0x0000,
        [EnumValueDisplayName("Non-removable Disc")] NonRemovableDisc = 0x0001,
        [EnumValueDisplayName("Removable Disc")] RemovableDisc = 0x0002,
        [EnumValueDisplayName("Magneto-Optical Erasable")] MagnetoOpticalErasable = 0x0003,
        [EnumValueDisplayName("Optical Write-Once")] OpticalWriteOnce = 0x0004,
        [EnumValueDisplayName("ASMO")] ASMO = 0x0005,
        [EnumValueDisplayName("CD-ROM")] CDROM = 0x0008,
        [EnumValueDisplayName("CD-R")] CDR = 0x0009,
        [EnumValueDisplayName("CD-RW")] CDRW = 0x000A,
        [EnumValueDisplayName("DVD-ROM")] DvdRom = 0x0010,
        [EnumValueDisplayName("DVD-R Sequential Recording")] DvdMinusRSequentialRecording = 0x0011,
        [EnumValueDisplayName("DVD-RAM")] DvdRam = 0x0012,
        [EnumValueDisplayName("DVD-RW Restricted Overwrite")] DvdMinusRWRestrictedOverwrite = 0x0013,
        [EnumValueDisplayName("DVD-RW Sequential Recording")] DvdMinusRWSequentialRecording = 0x0014,
        [EnumValueDisplayName("DVD-R DL Sequential Recording")] DvdMinusRDualLayerSequentialRecording = 0x0015,
        [EnumValueDisplayName("DVD-R DL Layer Jump Recording")] DvdMinusRDualLayerJumpRecording = 0x0016,
        [EnumValueDisplayName("DVD-RW DL")] DvdMinusRWDualLayer = 0x0017,
        [EnumValueDisplayName("DVD Download Disc Recording")] DvdDownloadDiscRecording = 0x0018,
        [EnumValueDisplayName("DVD+RW")] DvdPlusRW = 0x001A,
        [EnumValueDisplayName("DVD+R")] DvdPlusR = 0x001B,
        [EnumValueDisplayName("DVD+RW DL")] DvdPlusRWDualLayer = 0x002A,
        [EnumValueDisplayName("DVD+R DL")] DvdPlusRDualLayer = 0x002B,
        [EnumValueDisplayName("BD-ROM")] BDROM = 0x0040,
        [EnumValueDisplayName("BD-R Sequential Recording (SRM)")] BDRSequentialRecording = 0x0041,
        [EnumValueDisplayName("BD-RE Random Recording (RRM)")] BDRERandomRecording = 0x0042,
        [EnumValueDisplayName("BD-RE")] BDRE = 0x0043,
        [EnumValueDisplayName("HD DVD-ROM")] HDDvdRom = 0x0050,
        [EnumValueDisplayName("HD DVD-R")] HDDvdR = 0x0051,
        [EnumValueDisplayName("HD DVD-RAM")] HDDvdRam = 0x0052,
        [EnumValueDisplayName("HD DVD-RW")] HDDvdRW = 0x0053,
        [EnumValueDisplayName("HD DVD-R Dual Layer")] HDDvdRDualLayer = 0x0058,
        [EnumValueDisplayName("HD DVD-RW Dual Layer")] HDDvdRWDualLayer = 0x005A,
        [EnumValueDisplayName("Nonstandard")] Nonstandard = unchecked((ushort) (~0)),
    }

    [Flags]
    public enum MultimediaProfileFlags : long
    {
        /// <summary>When this is the current profile, the <see cref="CoreFeature"/>, <see cref="MorphingFeature"/>, and <see cref="RemovableMediumFeature"/> features must be current.</summary>
        [EnumValueDisplayName("No Profile")] NoProfile = 1L << 0,
        [EnumValueDisplayName("Non-removable Disc")] NonRemovableDisc = 1L << 1,
        [EnumValueDisplayName("Removable Disc")] RemovableDisc = 1L << 2,
        [EnumValueDisplayName("Magneto-Optical Erasable")] MagnetoOpticalErasable = 1L << 3,
        [EnumValueDisplayName("Optical Write-Once")] OpticalWriteOnce = 1L << 4,
        [EnumValueDisplayName("ASMO")] ASMO = 1L << 5,
        [EnumValueDisplayName("CD-ROM")] CDROM = 1L << 6,
        [EnumValueDisplayName("CD-R")] CDR = 1L << 7,
        [EnumValueDisplayName("CD-RW")] CDRW = 1L << 8,
        [EnumValueDisplayName("DVD-ROM")] DvdRom = 1L << 9,
        [EnumValueDisplayName("DVD-R Sequential Recording")] DvdMinusRSequentialRecording = 1L << 10,
        [EnumValueDisplayName("DVD-RAM")] DvdRam = 1L << 11,
        [EnumValueDisplayName("DVD-RW Restricted Overwrite")] DvdMinusRWRestrictedOverwrite = 1L << 12,
        [EnumValueDisplayName("DVD-RW Sequential Recording")] DvdMinusRWSequentialRecording = 1L << 13,
        [EnumValueDisplayName("DVD-R Dual Layer Sequential Recording")] DvdMinusRDualLayerSequentialRecording = 1L << 14
        ,
        [EnumValueDisplayName("DVD-R Dual Layer Layer Jump Recording")] DvdMinusRDualLayerJumpRecording = 1L << 15,
        [EnumValueDisplayName("DVD-RW Dual Layer")] DvdMinusRWDualLayer = 1L << 16,
        [EnumValueDisplayName("DVD Download Disc Recording")] DvdDownloadDiscRecording = 1L << 17,
        [EnumValueDisplayName("DVD+RW")] DvdPlusRW = 1L << 18,
        [EnumValueDisplayName("DVD+R")] DvdPlusR = 1L << 19,
        [EnumValueDisplayName("DVD+RW Dual Layer")] DvdPlusRWDualLayer = 1L << 20,
        [EnumValueDisplayName("DVD+R Dual Layer")] DvdPlusRDualLayer = 1L << 21,
        [EnumValueDisplayName("BD-ROM")] BDROM = 1L << 22,
        [EnumValueDisplayName("BD-R Sequential Recording")] BDRSequentialRecording = 1L << 23,
        [EnumValueDisplayName("BD-RE Random Recording")] BDRERandomRecording = 1L << 24,
        [EnumValueDisplayName("BD-RE")] BDRE = 1L << 25,
        [EnumValueDisplayName("HD DVD-ROM")] HDDvdRom = 1L << 26,
        [EnumValueDisplayName("HD DVD-R")] HDDvdR = 1L << 27,
        [EnumValueDisplayName("HD DVD-RAM")] HDDvdRam = 1L << 28,
        [EnumValueDisplayName("HD DVD-RW")] HDDvdRW = 1L << 29,
        [EnumValueDisplayName("HD DVD-R Dual Layer")] HDDvdRDualLayer = 1L << 30,
        [EnumValueDisplayName("HD DVD-RW Dual Layer")] HDDvdRWDualLayer = 1L << 31,
        [EnumValueDisplayName("Nonstandard")] Nonstandard = 1L << 32,
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class DiscInformationBlock : IMarshalable
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly IntPtr OPC_TABLE_OFFSET =
            Marshal.OffsetOf(typeof (DiscInformationBlock), "_OptimumPowerCalibrationTable");

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly IntPtr NUM_OPC_TABLE_ENTRIES_OFFSET =
            Marshal.OffsetOf(typeof (DiscInformationBlock), "_NumberOfOPCTableEntries");

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte LAST_SESSION_STATE_MASK = 0x0C;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte DISC_STATUS_MASK = 0x03;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte BG_FORMAT_STATUS_MASK = 0x03;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ushort _DiscInformationLength;

        public ushort DiscInformationLength
        {
            get { return Bits.BigEndian(_DiscInformationLength); }
            set { _DiscInformationLength = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte2;

        public bool Erasable
        {
            get { return Bits.GetBit(byte2, 4); }
            set { byte2 = Bits.SetBit(byte2, 4, value); }
        }

        public LastSessionState LastSessionState
        {
            get { return (LastSessionState) Bits.GetValueMask(byte2, 2, LAST_SESSION_STATE_MASK); }
            set { byte2 = Bits.PutValueMask(byte2, (byte) value, 2, LAST_SESSION_STATE_MASK); }
        }

        public DiscStatus DiscStatus
        {
            get { return (DiscStatus) Bits.GetValueMask(byte2, 0, DISC_STATUS_MASK); }
            set { byte2 = Bits.PutValueMask(byte2, (byte) value, 0, DISC_STATUS_MASK); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _FirstTrackNumber;

        public byte FirstTrackNumber
        {
            get { return _FirstTrackNumber; }
            set { _FirstTrackNumber = value; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _SessionCountLSB;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _FirstTrackNumberInLastSessionLSB;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _LastTrackNumberInLastSessionLSB;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte7;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool DiscIdValid
        {
            get { return Bits.GetBit(byte7, 7); }
            set { byte7 = Bits.SetBit(byte7, 7, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool DiscBarCodeValid
        {
            get { return Bits.GetBit(byte7, 6); }
            set { byte7 = Bits.SetBit(byte7, 6, value); }
        }

        public bool UnrestrictedCodeUse
        {
            get { return Bits.GetBit(byte7, 5); }
            set { byte7 = Bits.SetBit(byte7, 5, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool DiscApplicationCodeValid
        {
            get { return Bits.GetBit(byte7, 4); }
            set { byte7 = Bits.SetBit(byte7, 4, value); }
        }

        public bool Dirty
        {
            get { return Bits.GetBit(byte7, 2); }
            set { byte7 = Bits.SetBit(byte7, 2, value); }
        }

        public BackgroundFormatStatus BackgroundFormatStatus
        {
            get { return (BackgroundFormatStatus) Bits.GetValueMask(byte7, 0, BG_FORMAT_STATUS_MASK); }
            set { byte7 = Bits.PutValueMask(byte7, (byte) value, 0, BG_FORMAT_STATUS_MASK); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private CompactDiscType _DiscType;

        public CompactDiscType DiscType
        {
            get { return _DiscType; }
            set { _DiscType = value; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _SessionCountMSB;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _FirstTrackNumberInLastSessionMSB;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _LastTrackNumberInLastSessionMSB;

        public ushort SessionCount
        {
            get { return (ushort) (_SessionCountLSB | (_SessionCountMSB << 8)); }
            set
            {
                _SessionCountLSB = (byte) (value & 0x00FFU);
                _SessionCountMSB = (byte) ((value & 0xFF00U) >> 8);
            }
        }

        public ushort FirstTrackNumberInLastSession
        {
            get { return (ushort) (_FirstTrackNumberInLastSessionLSB | (_FirstTrackNumberInLastSessionMSB << 8)); }
            set
            {
                _FirstTrackNumberInLastSessionLSB = (byte) (value & 0x00FFU);
                _FirstTrackNumberInLastSessionMSB = (byte) ((value & 0xFF00U) >> 8);
            }
        }

        public ushort LastTrackNumberInLastSession
        {
            get { return (ushort) (_LastTrackNumberInLastSessionLSB | (_LastTrackNumberInLastSessionMSB << 8)); }
            set
            {
                _LastTrackNumberInLastSessionLSB = (byte) (value & 0x00FFU);
                _LastTrackNumberInLastSessionMSB = (byte) ((value & 0xFF00U) >> 8);
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private uint _DiscIdentification;

        public uint? DiscIdentification
        {
            get { return DiscIdValid ? Bits.BigEndian(_DiscIdentification) : 0; }
            set
            {
                DiscIdValid = value != null;
                _DiscIdentification = Bits.BigEndian(value.GetValueOrDefault());
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Time _LastSessionLeadInStartTime;

        public Time LastSessionLeadInStartTime
        {
            get { return _LastSessionLeadInStartTime; }
            set { _LastSessionLeadInStartTime = value; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Time _LastPossibleStartTimeForLeadOut;

        public Time LastPossibleStartTimeForLeadOut
        {
            get { return _LastPossibleStartTimeForLeadOut; }
            set { _LastPossibleStartTimeForLeadOut = value; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private long _DiscBarCode;

        public long? DiscBarCode
        {
            get { return DiscBarCodeValid ? Bits.BigEndian(_DiscBarCode) : 0; }
            set
            {
                DiscBarCodeValid = value != null;
                _DiscBarCode = Bits.BigEndian(value.GetValueOrDefault());
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _DiscApplicationCode;

        public byte? DiscApplicationCode
        {
            get { return DiscApplicationCodeValid ? _DiscApplicationCode : (byte?) null; }
            set
            {
                DiscBarCodeValid = value != null;
                _DiscApplicationCode = value.GetValueOrDefault();
            }
        }

        private byte _NumberOfOPCTableEntries;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)] private
            OptimumPowerCalibration[] _OptimumPowerCalibrationTable;

        public OptimumPowerCalibration[] OptimumPowerCalibrationTable
        {
            get { return _OptimumPowerCalibrationTable; }
            set
            {
                _OptimumPowerCalibrationTable = value;
                _NumberOfOPCTableEntries = value == null ? (byte) 0 : (byte) value.Length;
            }
        }


        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected virtual int MarshaledSize
        {
            get
            {
                return (Marshal.SizeOf(this) +
                        (_NumberOfOPCTableEntries - 1)*Marshaler.DefaultSizeOf<OptimumPowerCalibration>());
            }
        }

        protected virtual void MarshalFrom(BufferWithSize buffer)
        {
            Marshaler.DefaultPtrToStructure(buffer, this);
            _OptimumPowerCalibrationTable = new OptimumPowerCalibration[_NumberOfOPCTableEntries];
            unsafe
            {
                BufferWithSize opcs = buffer.ExtractSegment(OPC_TABLE_OFFSET);
                for (int i = 0; i < _OptimumPowerCalibrationTable.Length; i++)
                {
                    _OptimumPowerCalibrationTable[i] =
                        opcs.Read<OptimumPowerCalibration>(i*sizeof (OptimumPowerCalibration));
                }
            }
        }

        protected virtual void MarshalTo(BufferWithSize buffer)
        {
            Marshaler.DefaultStructureToPtr((object) this, buffer);
            unsafe
            {
                BufferWithSize opcs = buffer.ExtractSegment(OPC_TABLE_OFFSET);
                for (int i = 0; i < _OptimumPowerCalibrationTable.Length; i++)
                {
                    opcs.Write(_OptimumPowerCalibrationTable[i], i*sizeof (OptimumPowerCalibration));
                }
            }
        }

        internal static byte ReadNumOptimumPowerCalibrationEntries(BufferWithSize buffer)
        {
            return Bits.BigEndian(buffer.Read<byte>(NUM_OPC_TABLE_ENTRIES_OFFSET));
        }

        void IMarshalable.MarshalFrom(BufferWithSize buffer)
        {
            MarshalFrom(buffer);
        }

        void IMarshalable.MarshalTo(BufferWithSize buffer)
        {
            MarshalTo(buffer);
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        int IMarshalable.MarshaledSize
        {
            get { return MarshaledSize; }
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
    public struct OptimumPowerCalibration
    {
        /// <summary>In kBytes per second</summary>
        [Description("In kBytes per second")] private ushort _Speed;

        public ushort Speed
        {
            get { return Bits.BigEndian(_Speed); }
            set { _Speed = Bits.BigEndian(value); }
        }

        public unsafe fixed byte OptimumPowerCalibrationValues [6];

        public override string ToString()
        {
            return Internal.GenericToString(this, false);
        }
    }

    public struct CueLine
    {
        public readonly Msf AbsoluteTime;
        public readonly byte Index;
        public readonly byte TrackNumber;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte ControlAddress;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte DataForm;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte SerialCopyManagementSystem;

        public CueLine(CDControl control, CDAddress address, byte trackNumber, byte index,
                       CDSubChannelDataForm subchannel, CDMainChannelDataForm mainChannel, bool alternateCopy,
                       Msf absoluteTime)
            : this()
        {
            Control = control;
            Address = address;
            TrackNumber = trackNumber;
            Index = index;
            SubChannelDataForm = subchannel;
            MainChannelDataForm = mainChannel;
            AlternateCopy = alternateCopy;
            AbsoluteTime = absoluteTime;
        }

        public CDControl Control
        {
            get { return unchecked((CDControl) (ControlAddress & 0xF0)); }
            private set { ControlAddress = (byte) ((ControlAddress & ~0xF0) | ((byte) value & 0xF0)); }
        }

        public CDAddress Address
        {
            get { return unchecked((CDAddress) (ControlAddress & 0x0F)); }
            private set { ControlAddress = (byte) ((ControlAddress & ~0x0F) | ((byte) value & 0x0F)); }
        }

        public CDSubChannelDataForm SubChannelDataForm
        {
            get { return unchecked((CDSubChannelDataForm) (DataForm & 0xC0)); }
            private set { DataForm = (byte) ((DataForm & ~0xC0) | ((byte) value & 0xC0)); }
        }

        public CDMainChannelDataForm MainChannelDataForm
        {
            get { return unchecked((CDMainChannelDataForm) (DataForm & 0x3F)); }
            private set { DataForm = (byte) ((DataForm & ~0x3F) | ((byte) value & 0x3F)); }
        }

        public bool AlternateCopy
        {
            get { return Bits.GetBit(SerialCopyManagementSystem, 7); }
            private set { SerialCopyManagementSystem = Bits.SetBit(SerialCopyManagementSystem, 7, value); }
        }
    }

    public enum CDMainChannelDataForm : byte
    {
        Cdda2352 = 0x00,
        Cdda0 = 0x01,
        CdromMode1HostData2048 = 0x10,
        CdromMode1HostData2352 = 0x11,
        CdromMode1IgnoredData2048 = 0x12,
        CdromMode1IgnoredData2352 = 0x13,
        CdromMode1GeneratedData0 = 0x14,
        CdromXAHostData2336 = 0x20,
        CdromXAHostData2352 = 0x21,
        CdromXAIgnoredData2336 = 0x22,
        CdromXAIgnoredData2352 = 0x23,
        CdromXAGeneratedData0 = 0x24,
        CdromMode2HostData2336 = 0x30,
        CdromMode2HostData2352 = 0x31,
        CdromMode2IgnoredData2336 = 0x30,
        CdromMode2IgnoredData2352 = 0x31,
        CdromMode2GeneratedData0 = 0x32,
    }

    public enum CDSubChannelDataForm : byte
    {
        GenerateZeroData = 0x00,
        RawData = 0x40,
        PackedData = 0xC0,
    }

    [Flags]
    public enum CDControl : byte //Value is pre-shifted; just cast
    {
        /// <summary>Indicates a non-data track with two audio channels without pre-emphasis, with or without digital copy.</summary>
        TwoChannelCopyProtectedAudioWithoutPreemphasis = 0,
        /// <summary>Indicates that four audio channels instead of the default two are used. Can be combined with all flags other than <see cref="DataTrack"/>.</summary>
        FourAudioChannels = 1 << 7,
        /// <summary>Indicates a pre-emphasis of 50/15 microseconds. Can be combined with all flags other than <see cref="DataTrack"/>.</summary>
        PreEmphasisOf50Per15Microseconds = 1 << 4,
        /// <summary>Indicates a data track. Can be combined only with the <see cref="DigitalCopyPermitted"/> flag; other flags must be unset.</summary>
        DataTrack = 1 << 6,
        /// <summary>Indicates that digital copying is permitted. Can be combined with all other flags.</summary>
        DigitalCopyPermitted = 1 << 5,
    }

    public enum CDAddress : byte
    {
        None = 0,
        StartTime = 1,
        CatalogCode = 2,
        IsrcCode = 3
    }

    public enum SessionFormat : byte
    {
        [EnumValueDisplayName("CD-ROM/CD-DA/Other")] CdromOrCddaOrOtherDataDisc = 0x00,
        [EnumValueDisplayName("CD-I")] CDIDisc = 0x10,
        [EnumValueDisplayName("CD-ROM XA/DD-CD")] CdromXAOrDdcd = 0x20,
    }

    public enum BackgroundFormatStatus : byte
    {
        None = 0x00,
        NotCompleted = 0x01,
        InProgress = 0x02,
        Completed = 0x03,
    }

    public enum DiscStatus : byte
    {
        /// <summary>A recordable disc is present and is either logically or physically blank.</summary>
        [Description("A recordable disc is present and is either logically or physically blank.")] Empty = 0x00,
        /// <summary>The currently mounted disc is recorded/recordable serially in sessions. The last session is either blank or partially recorded.</summary>
        [Description(
            "The currently mounted disc is recorded/recordable serially in sessions. The last session is either blank or partially recorded."
            )] Appendable = 0x01,
        /// <summary>The currently mounted disc is recorded/recordable serially in sessions. The last session is closed and there is no possibility of appending a new session.</summary>
        [Description(
            "The currently mounted disc is recorded/recordable serially in sessions. The last session is closed and there is no possibility of appending a new session."
            )] Finalized = 0x02,
        /// <summary>The currently mounted disc supports only random access writing and is not recordable serially in multiple sessions.</summary>
        /// <remarks>Some ReWritable media may allow the last session to be grown via the <see cref="FormatUnitCommand"/> command.</remarks>
        [Description(
            "The currently mounted disc supports only random access writing and is not recordable serially in multiple sessions."
            )] Other = 0x03,
    }

    public enum LastSessionState : byte
    {
        Empty = 0x00,
        Incomplete = 0x01,
        ReservedOrDamaged = 0x02,
        Complete = 0x03,
    }

    /// <summary>All bytes, even the year, are in ASCII.</summary>
    [Description("All bytes, even the year, are in ASCII.")]
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 16, CharSet = CharSet.Ansi)]
    public struct InternationalStandardRecordingCode : IMarshalable
    {
        private static readonly char[] TRIM_CHARS = new[] {' ', '\0'};

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly IntPtr COUNTRY_CODE_OFFSET =
            Marshal.OffsetOf(typeof (InternationalStandardRecordingCode), "_CountryCode");

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly IntPtr OWNER_CODE_OFFSET =
            Marshal.OffsetOf(typeof (InternationalStandardRecordingCode), "_OwnerCode");

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly IntPtr YEAR_OF_RECORDING_OFFSET =
            Marshal.OffsetOf(typeof (InternationalStandardRecordingCode), "_YearOfRecording");

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly IntPtr SERIAL_NUMBER_OFFSET =
            Marshal.OffsetOf(typeof (InternationalStandardRecordingCode), "_SerialNumber");

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte COUNTRY_CODE_LENGTH = 2;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte OWNER_CODE_LENGTH = 3;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte YEAR_OF_RECORDING_LENGTH = 2;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte SERIAL_NUMBER_LENGTH = 5;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte0;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool Valid
        {
            get { return Bits.GetBit(byte0, 7); }
            set { byte0 = Bits.SetBit(byte0, 7, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)] private
            string _CountryCode;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public string CountryCode
        {
            get
            {
                if (_CountryCode == null)
                {
                    _CountryCode = string.Empty;
                }
                return _CountryCode;
            }
            set
            {
                if (!Regex.IsMatch(value, @"\A[A-Z]{2}\z"))
                {
                    throw new ArgumentOutOfRangeException("value", value,
                                                          "Value must exactly have 2 the characters A-Z.");
                }
                _CountryCode = value;
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)] private
            string _OwnerCode;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public string OwnerCode
        {
            get
            {
                if (_OwnerCode == null)
                {
                    _OwnerCode = string.Empty;
                }
                return _OwnerCode;
            }
            set
            {
                if (!Regex.IsMatch(value, @"\A[A-Z0-9]{3}\z"))
                {
                    throw new ArgumentOutOfRangeException("value", value,
                                                          "Value must exactly have 3 of the characters A-Z or 0-9.");
                }
                _OwnerCode = value;
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)] private
            string _YearOfRecording;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public string YearOfRecording
        {
            get
            {
                if (_YearOfRecording == null)
                {
                    _YearOfRecording = string.Empty;
                }
                return _YearOfRecording;
            }
            set
            {
                if (!Regex.IsMatch(value, @"\A[0-9]{2}\z"))
                {
                    throw new ArgumentOutOfRangeException("value", value,
                                                          "Value must exactly have 2 of the characters 0-9.");
                }
                _YearOfRecording = value;
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)] private
            string _SerialNumber;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public string SerialNumber
        {
            get
            {
                if (_SerialNumber == null)
                {
                    _SerialNumber = string.Empty;
                }
                return _SerialNumber;
            }
            set
            {
                if (!Regex.IsMatch(value, @"\A[0-9]{5}\z"))
                {
                    throw new ArgumentOutOfRangeException("value", value,
                                                          "Value must exactly have 5 of the characters 0-9.");
                }
                _SerialNumber = value;
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte Zero;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _AFrame;

        public byte AFrame
        {
            get { return _AFrame; }
            set { _AFrame = value; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte15;

        public void MarshalFrom(BufferWithSize buffer)
        {
            _CountryCode = buffer.ToStringAnsi((int) COUNTRY_CODE_OFFSET, COUNTRY_CODE_LENGTH).TrimEnd(TRIM_CHARS);
            _OwnerCode = buffer.ToStringAnsi((int) OWNER_CODE_OFFSET, OWNER_CODE_LENGTH).TrimEnd(TRIM_CHARS);
            _SerialNumber = buffer.ToStringAnsi((int) SERIAL_NUMBER_OFFSET, SERIAL_NUMBER_LENGTH).TrimEnd(TRIM_CHARS);
            _YearOfRecording =
                buffer.ToStringAnsi((int) YEAR_OF_RECORDING_OFFSET, YEAR_OF_RECORDING_LENGTH).TrimEnd(TRIM_CHARS);
        }

        public void MarshalTo(BufferWithSize buffer)
        {
            Marshaler.DefaultStructureToPtr((object) this, buffer);
            Internal.StringToBufferAnsi(CountryCode.PadRight(COUNTRY_CODE_LENGTH, '\0'),
                                        buffer.ExtractSegment((byte) COUNTRY_CODE_OFFSET, COUNTRY_CODE_LENGTH));
            Internal.StringToBufferAnsi(OwnerCode.PadRight(COUNTRY_CODE_LENGTH, '\0'),
                                        buffer.ExtractSegment((byte) OWNER_CODE_OFFSET, OWNER_CODE_LENGTH));
            Internal.StringToBufferAnsi(SerialNumber.PadRight(COUNTRY_CODE_LENGTH, '\0'),
                                        buffer.ExtractSegment((byte) SERIAL_NUMBER_OFFSET, SERIAL_NUMBER_LENGTH));
            Internal.StringToBufferAnsi(YearOfRecording.PadRight(COUNTRY_CODE_LENGTH, '\0'),
                                        buffer.ExtractSegment((byte) YEAR_OF_RECORDING_OFFSET, YEAR_OF_RECORDING_LENGTH));
        }

        public int MarshaledSize
        {
            get { return Marshaler.DefaultSizeOf<InternationalStandardRecordingCode>(); }
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 16)]
    public struct MediaCatalogNumber
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte0;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool Valid
        {
            get { return Bits.GetBit(byte0, 7); }
            set { byte0 = Bits.SetBit(byte0, 7, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)] private
            string _Number;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public string Number
        {
            get { return _Number; }
            set
            {
                value = (value == null ? string.Empty : value).PadLeft(13);
                _Number = value;
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte Zero;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] public byte AFrame;

        //public override string ToString() { return Internal.GenericToString(this, false); }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 4)]
    public struct Time : IEquatable<Time>, IComparable<Time>
    {
        public Time(uint time)
            : this(
                unchecked((byte) (time >> 24)), unchecked((byte) (time >> 16)), unchecked((byte) (time >> 8)),
                unchecked((byte) time))
        {
        }

        public Time(byte hour, byte minute, byte second, byte frame)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
            Frame = frame;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] public readonly byte Hour;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] public readonly byte Minute;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] public readonly byte Second;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] public readonly byte Frame;

        public override bool Equals(object obj)
        {
            return obj is Time && Equals((Time) obj);
        }

        public override int GetHashCode()
        {
            return ((uint) this).GetHashCode();
        }

        public bool Equals(Time other)
        {
            return Hour == other.Hour & Minute == other.Minute & Second == other.Second & Frame == other.Frame;
        }

        public static explicit operator uint(Time time)
        {
            return
                unchecked(((uint) time.Hour << 24) | ((uint) time.Minute << 16) | ((uint) time.Second << 8) | time.Frame
                    );
        }

        public static explicit operator Time(uint time)
        {
            return new Time(time);
        }

        public int CompareTo(Time other)
        {
            return ((uint) this).CompareTo((uint) other);
        }

        public static Time operator +(Time left, Time right)
        {
            return new Time((uint) left + (uint) right);
        }

        public static Time operator -(Time left, Time right)
        {
            return new Time((uint) left - (uint) right);
        }

        public static bool operator ==(Time left, Time right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Time left, Time right)
        {
            return !left.Equals(right);
        }

        public static bool operator <(Time left, Time right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator >(Time left, Time right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator <=(Time left, Time right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >=(Time left, Time right)
        {
            return left.CompareTo(right) >= 0;
        }

        public override string ToString()
        {
            return string.Format("{0:D2}:{1:D2}:{2:D2}:{3:D2}", Hour, Minute, Second, Frame);
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Msf : IEquatable<Msf>, IComparable<Msf>, IComparable
    {
        //Do NOT change the fields, size, or packing of this structure, since it's embedded in MANY OTHER COMMANDS that depends on this particular layout!!

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] public static readonly Msf Zero = new Msf(0, 0, 0);

        public Msf(byte minute, byte second, byte frame)
        {
            second += (byte) (frame/75);
            frame %= 75;
            minute += (byte) (second/60);
            second %= 60;
            if (minute >= 100)
            {
                throw new ArgumentOutOfRangeException("minute", minute, "Minutes must be less than 100.");
            }
            Minute = minute;
            Second = second;
            Frame = frame;
        }

        public readonly byte Minute;
        public readonly byte Second;
        public readonly byte Frame;

        public override bool Equals(object obj)
        {
            return obj is Msf && Equals((Msf) obj);
        }

        public override int GetHashCode()
        {
            return ((int) this).GetHashCode();
        }

        public bool Equals(Msf other)
        {
            return (int) this == (int) other;
        }

        public int CompareTo(Msf other)
        {
            int c = Minute.CompareTo(other.Minute);
            if (c == 0)
            {
                c = Second.CompareTo(other.Second);
            }
            if (c == 0)
            {
                c = Frame.CompareTo(other.Frame);
            }
            return c;
        }

        public int CompareTo(object other)
        {
            return CompareTo((Msf) other);
        }

        public override string ToString()
        {
            return string.Format("{0:D2}:{1:D2}:{2:D2}", Minute, Second, Frame);
        }

        public static explicit operator int(Msf value)
        {
            return (60*value.Minute + value.Second)*75 + value.Frame - (value.Minute < 90 ? 150 : 450150);
        }

        public static explicit operator uint(Msf value)
        {
            return unchecked((uint) (int) value);
        }

        public static explicit operator Msf(int logicalBlockAddress)
        {
            int i = logicalBlockAddress >= 150 ? 150 : 450150;
            var m = (byte) ((logicalBlockAddress + i)/(60*75));
            var s = (byte) ((logicalBlockAddress + i - m*60*75)/75);
            var f = (byte) (logicalBlockAddress + i - m*60*75 - s*75);
            return new Msf((byte) (m%100), s, f);
        }

        public static explicit operator Msf(uint logicalBlockAddress)
        {
            return (Msf) unchecked((int) logicalBlockAddress);
        }

        public static int operator -(Msf left, Msf right)
        {
            return (int) left - (int) right;
        }

        public static bool operator ==(Msf left, Msf right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Msf left, Msf right)
        {
            return !left.Equals(right);
        }

        public static bool operator <(Msf left, Msf right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(Msf left, Msf right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(Msf left, Msf right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(Msf left, Msf right)
        {
            return left.CompareTo(right) >= 0;
        }
    }

    public enum CompactDiscType : byte
    {
        CDROMOrCDDigitalAudio = 0x00,
        CDI = 0x10,
        CDROMXAOrDoubleDensityCD = 0x20,
        Undefined = 0xFF,
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct FeatureHeader
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private uint _DataLength;

        public uint DataLength
        {
            get { return Bits.BigEndian(_DataLength); }
            set { _DataLength = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte4;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte5;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private MultimediaProfile _CurrentProfile;

        public MultimediaProfile CurrentProfile
        {
            get { return Bits.BigEndian(_CurrentProfile); }
            set { _CurrentProfile = Bits.BigEndian(value); }
        }

        public override string ToString()
        {
            return Internal.GenericToString(this, false);
        }
    }

    public enum FeatureRequestType : byte
    {
        SupportedFeatureHeaderAndDescriptors = 0x00,
        CurrentFeatureHeaderAndDescriptors = 0x01,
        OneFeatureHeaderAndZeroOrOneDescriptor = 0x02,
    }

    public enum GroupCode : byte
    {
        SixByteCommands = 0x00,
        TenByteCommands1 = 0x01,
        TenByteCommands2 = 0x02,
        SixteenByteCommands = 0x04,
        TwelveByteCommands = 0x05,
    }

    public enum MediaEventCode : byte
    {
        NoChange = 0x0,
        EjectRequest = 0x1,
        NewMedia = 0x2,
        MediaRemoval = 0x3,
        MediaChanged = 0x4,
        BackgroundFormatCompleted = 0x5,
        BackgroundFormatRestarted = 0x6,
    }

    public enum LoadingMechanism : byte
    {
        Caddy = 0x00,
        Tray = 0x01,
        Popup = 0x02,
        [EnumValueDisplayName("Changer with Individually Changeable Discs")] ChangerWithIndividuallyChangeableDiscs =
            0x04,
        [EnumValueDisplayName("Changer with Magazine Mechanism")] ChangerWithMagazineMechanism = 0x05,
    }

    public enum InactivityTimerMultiplierValue : byte
    {
        VendorSpecific = 0x0,
        Milliseconds125 = 0x1,
        Milliseconds250 = 0x2,
        Milliseconds500 = 0x3,
        Seconds1 = 0x4,
        Seconds2 = 0x5,
        Seconds4 = 0x6,
        Seconds8 = 0x7,
        Seconds16 = 0x8,
        Seconds32 = 0x9,
        Minutes1 = 0xA,
        Minutes2 = 0xB,
        Minutes4 = 0xC,
        Minutes8 = 0xD,
        Minutes16 = 0xE,
        Minutes32 = 0xF,
    }

    public enum RotationControl : byte
    {
        ConstantLinearVelocity = 0x00,
        ConstantAngularVelocity = 0x01
    }
}