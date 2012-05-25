using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class CapabilitiesMechanicalStatusPage : ModePage
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly IntPtr MAX_READ_SPEED_OFFSET =
            Marshal.OffsetOf(typeof (CapabilitiesMechanicalStatusPage), "_MaxReadSpeed");

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly IntPtr MAX_WRITE_SPEED_OFFSET =
            Marshal.OffsetOf(typeof (CapabilitiesMechanicalStatusPage), "_MaxWriteSpeed");

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly IntPtr CURRENT_READ_SPEED_OFFSET =
            Marshal.OffsetOf(typeof (CapabilitiesMechanicalStatusPage), "_CurrentReadSpeed");

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly IntPtr CURRENT_WRITE_SPEED_OFFSET =
            Marshal.OffsetOf(typeof (CapabilitiesMechanicalStatusPage), "_CurrentWriteSpeed");

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly IntPtr
            LOGICAL_UNIT_WRITE_SPEEED_PERFORMANCE_BLOCK_OFFSET =
                Marshal.OffsetOf(typeof (CapabilitiesMechanicalStatusPage), "_LogicalUnitWriteSpeedPerformanceBlocks");


        public CapabilitiesMechanicalStatusPage() : base(ModePageCode.CapabilitiesAndMechanicalStatus)
        {
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte LOADING_MECHANISM_TYPE_MASK = 0xE0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte LENGTH_MASK = 0x30;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte ROTATION_CONTROL_MASK = 0x03;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte2;

        public bool ReadDvdRam
        {
            get { return Bits.GetBit(byte2, 5); }
            set { byte2 = Bits.SetBit(byte2, 5, value); }
        }

        public bool ReadDvdR
        {
            get { return Bits.GetBit(byte2, 4); }
            set { byte2 = Bits.SetBit(byte2, 4, value); }
        }

        public bool ReadDvdRom
        {
            get { return Bits.GetBit(byte2, 3); }
            set { byte2 = Bits.SetBit(byte2, 3, value); }
        }

        public bool Method2
        {
            get { return Bits.GetBit(byte2, 2); }
            set { byte2 = Bits.SetBit(byte2, 2, value); }
        }

        public bool ReadCDRW
        {
            get { return Bits.GetBit(byte2, 1); }
            set { byte2 = Bits.SetBit(byte2, 1, value); }
        }

        public bool ReadCDR
        {
            get { return Bits.GetBit(byte2, 0); }
            set { byte2 = Bits.SetBit(byte2, 0, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte3;

        public bool WriteDvdRam
        {
            get { return Bits.GetBit(byte3, 5); }
            set { byte3 = Bits.SetBit(byte3, 5, value); }
        }

        public bool WriteDvdR
        {
            get { return Bits.GetBit(byte3, 4); }
            set { byte3 = Bits.SetBit(byte3, 4, value); }
        }

        public bool TestWrite
        {
            get { return Bits.GetBit(byte3, 2); }
            set { byte3 = Bits.SetBit(byte3, 2, value); }
        }

        public bool WriteCDRW
        {
            get { return Bits.GetBit(byte3, 1); }
            set { byte3 = Bits.SetBit(byte3, 1, value); }
        }

        public bool WriteCDR
        {
            get { return Bits.GetBit(byte3, 0); }
            set { byte3 = Bits.SetBit(byte3, 0, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte4;

        public bool BufferUnderrunProtection
        {
            get { return Bits.GetBit(byte4, 7); }
            set { byte4 = Bits.SetBit(byte4, 7, value); }
        }

        public bool MultiSession
        {
            get { return Bits.GetBit(byte4, 6); }
            set { byte4 = Bits.SetBit(byte4, 6, value); }
        }

        public bool Mode2Form2
        {
            get { return Bits.GetBit(byte4, 5); }
            set { byte4 = Bits.SetBit(byte4, 5, value); }
        }

        public bool Mode2Form1
        {
            get { return Bits.GetBit(byte4, 4); }
            set { byte4 = Bits.SetBit(byte4, 4, value); }
        }

        public bool DigitalPort2
        {
            get { return Bits.GetBit(byte4, 3); }
            set { byte4 = Bits.SetBit(byte4, 3, value); }
        }

        public bool DigitalPort1
        {
            get { return Bits.GetBit(byte4, 2); }
            set { byte4 = Bits.SetBit(byte4, 2, value); }
        }

        public bool Composite
        {
            get { return Bits.GetBit(byte4, 1); }
            set { byte4 = Bits.SetBit(byte4, 1, value); }
        }

        public bool AudioPlay
        {
            get { return Bits.GetBit(byte4, 0); }
            set { byte4 = Bits.SetBit(byte4, 0, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte5;

        public bool ReadBarCode
        {
            get { return Bits.GetBit(byte5, 7); }
            set { byte5 = Bits.SetBit(byte5, 7, value); }
        }

        public bool UniversalProductCode
        {
            get { return Bits.GetBit(byte5, 6); }
            set { byte5 = Bits.SetBit(byte5, 6, value); }
        }

        public bool InternationalStandardRecordingCode
        {
            get { return Bits.GetBit(byte5, 5); }
            set { byte5 = Bits.SetBit(byte5, 5, value); }
        }

        public bool SupportsC2Pointers
        {
            get { return Bits.GetBit(byte5, 4); }
            set { byte5 = Bits.SetBit(byte5, 4, value); }
        }

        public bool RWDeinterleavedAndCorrected
        {
            get { return Bits.GetBit(byte5, 3); }
            set { byte5 = Bits.SetBit(byte5, 3, value); }
        }

        public bool RWSupported
        {
            get { return Bits.GetBit(byte5, 2); }
            set { byte5 = Bits.SetBit(byte5, 2, value); }
        }

        public bool AccurateCDDigitalAudioStream
        {
            get { return Bits.GetBit(byte5, 1); }
            set { byte5 = Bits.SetBit(byte5, 1, value); }
        }

        public bool SupportsCDDigitalAudioCommands
        {
            get { return Bits.GetBit(byte5, 0); }
            set { byte5 = Bits.SetBit(byte5, 0, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte6;

        public LoadingMechanism LoadingMechanismType
        {
            get { return (LoadingMechanism) Bits.GetValueMask(byte6, 5, LOADING_MECHANISM_TYPE_MASK); }
            set { byte6 = Bits.PutValueMask(byte6, (byte) value, 5, LOADING_MECHANISM_TYPE_MASK); }
        }

        public bool Eject
        {
            get { return Bits.GetBit(byte6, 3); }
            set { byte6 = Bits.SetBit(byte6, 3, value); }
        }

        public bool PreventJumper
        {
            get { return Bits.GetBit(byte6, 2); }
            set { byte6 = Bits.SetBit(byte6, 2, value); }
        }

        public bool LockState
        {
            get { return Bits.GetBit(byte6, 1); }
            set { byte6 = Bits.SetBit(byte6, 1, value); }
        }

        public bool Lock
        {
            get { return Bits.GetBit(byte6, 0); }
            set { byte6 = Bits.SetBit(byte6, 0, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte7;

        public bool RWInLeadIn
        {
            get { return Bits.GetBit(byte7, 5); }
            set { byte7 = Bits.SetBit(byte7, 5, value); }
        }

        public bool SideChangeCapable
        {
            get { return Bits.GetBit(byte7, 4); }
            set { byte7 = Bits.SetBit(byte7, 4, value); }
        }

        public bool SoftwareSlotSelection
        {
            get { return Bits.GetBit(byte7, 3); }
            set { byte7 = Bits.SetBit(byte7, 3, value); }
        }

        public bool ChangerSupportsDiscPresent
        {
            get { return Bits.GetBit(byte7, 2); }
            set { byte7 = Bits.SetBit(byte7, 2, value); }
        }

        public bool SeparateChannelMute
        {
            get { return Bits.GetBit(byte7, 1); }
            set { byte7 = Bits.SetBit(byte7, 1, value); }
        }

        public bool SeparateVolumeLevels
        {
            get { return Bits.GetBit(byte7, 0); }
            set { byte7 = Bits.SetBit(byte7, 0, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ushort _MaxReadSpeed;

        /// <summary>The maximum read speed of the drive, in KB (1000 bytes) per second. (This is NOT KiB/s, or 1024 B/s.)</summary>
        [Description(
            "The maximum read speed of the drive, in KB (1000 bytes) per second. (This is NOT KiB/s, or 1024 B/s.)")]
        public ushort MaxReadSpeed
        {
            get { return Bits.BigEndian(_MaxReadSpeed); }
            set { _MaxReadSpeed = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ushort _VolumeLevelsSupported;

        public ushort VolumeLevelsSupported
        {
            get { return Bits.BigEndian(_VolumeLevelsSupported); }
            set { _VolumeLevelsSupported = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ushort _BufferSizeSupported;

        public ushort BufferSizeSupported
        {
            get { return Bits.BigEndian(_BufferSizeSupported); }
            set { _BufferSizeSupported = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ushort _CurrentReadSpeed;

        /// <summary>The current read speed of the drive, in KB (1000 bytes) per second. (This is NOT KiB/s, or 1024 B/s.)</summary>
        [Description(
            "The current read speed of the drive, in KB (1000 bytes) per second. (This is NOT KiB/s, or 1024 B/s.)")]
        public ushort CurrentReadSpeed
        {
            get { return Bits.BigEndian(_CurrentReadSpeed); }
            set { _CurrentReadSpeed = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte16;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte17;

        public byte Length
        {
            get { return Bits.GetValueMask(byte17, 4, LENGTH_MASK); }
            set { byte17 = Bits.PutValueMask(byte17, value, 4, LENGTH_MASK); }
        }

        /// <summary>Indicates whether the data words are little or big endian.</summary>
        [Description("Indicates whether the data words are little or big endian.")]
        public bool LittleEndian
        {
            get { return Bits.GetBit(byte17, 3); }
            set { byte17 = Bits.SetBit(byte17, 3, value); }
        }

        public bool RCK
        {
            get { return Bits.GetBit(byte17, 2); }
            set { byte17 = Bits.SetBit(byte17, 2, value); }
        }

        public bool BCKF
        {
            get { return Bits.GetBit(byte17, 1); }
            set { byte17 = Bits.SetBit(byte17, 1, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ushort _MaxWriteSpeed;

        /// <summary>The maximum write speed of the drive, in KB (1000 bytes) per second. (This is NOT KiB/s, or 1024 B/s.)</summary>
        [Description(
            "The maximum write speed of the drive, in KB (1000 bytes) per second. (This is NOT KiB/s, or 1024 B/s.)")]
        public ushort MaxWriteSpeed
        {
            get { return Bits.BigEndian(_MaxWriteSpeed); }
            set { _MaxWriteSpeed = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ushort _CurrentWriteSpeed;

        /// <summary>The current write speed of the drive, in KB (1000 bytes) per second. (This is NOT KiB/s, or 1024 B/s.)</summary>
        [Description(
            "The current write speed of the drive, in KB (1000 bytes) per second. (This is NOT KiB/s, or 1024 B/s.)")]
        public ushort CurrentWriteSpeed
        {
            get { return Bits.BigEndian(_CurrentWriteSpeed); }
            set { _CurrentWriteSpeed = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ushort _CopyManagementRevisionSupported;

        public ushort CopyManagementRevisionSupported
        {
            get { return Bits.BigEndian(_CopyManagementRevisionSupported); }
            set { _CopyManagementRevisionSupported = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte24;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte25;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte26;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte27;

        public RotationControl RotationControlSelected
        {
            get { return (RotationControl) Bits.GetValueMask(byte27, 0, ROTATION_CONTROL_MASK); }
            set { byte27 = Bits.PutValueMask(byte27, (byte) value, 0, ROTATION_CONTROL_MASK); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ushort _CurrentWriteSpeedSelected;

        /// <summary>The current write speed of the drive, in KB (1000 bytes) per second. (This is NOT KiB/s, or 1024 B/s.)</summary>
        [Description(
            "The current write speed of the drive, in KB (1000 bytes) per second. (This is NOT KiB/s, or 1024 B/s.)")]
        public ushort CurrentWriteSpeedSelected
        {
            get { return Bits.BigEndian(_CurrentWriteSpeedSelected); }
            set { _CurrentWriteSpeedSelected = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ushort _NumLogicalUnitWriteSpeedPerformanceBlocks;

        public ushort NumLogicalUnitWriteSpeedPerformanceBlocks
        {
            get { return Bits.BigEndian(_NumLogicalUnitWriteSpeedPerformanceBlocks); }
            set { _NumLogicalUnitWriteSpeedPerformanceBlocks = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)] private
            LogicalUnitWriteSpeedPerformanceBlock[] _LogicalUnitWriteSpeedPerformanceBlocks;

        public LogicalUnitWriteSpeedPerformanceBlock[] LogicalUnitWriteSpeedPerformanceBlocks
        {
            get { return _LogicalUnitWriteSpeedPerformanceBlocks; }
            private set
            {
                _LogicalUnitWriteSpeedPerformanceBlocks = value;
                ushort count = value != null ? (ushort) value.Length : (ushort) 0;
                _NumLogicalUnitWriteSpeedPerformanceBlocks = count;
                PageLength = (byte) (count*4 + 28);
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected override int MarshaledSize
        {
            get
            {
                return (Marshal.SizeOf(this) +
                        (LogicalUnitWriteSpeedPerformanceBlocks.Length - 1)*
                        Marshaler.DefaultSizeOf<LogicalUnitWriteSpeedPerformanceBlock>());
            }
        }

        protected override void MarshalFrom(BufferWithSize buffer)
        {
            Marshaler.DefaultPtrToStructure(buffer, this);
            LogicalUnitWriteSpeedPerformanceBlocks =
                new LogicalUnitWriteSpeedPerformanceBlock[NumLogicalUnitWriteSpeedPerformanceBlocks];
            unsafe
            {
                BufferWithSize perfBlocks = buffer.ExtractSegment(LOGICAL_UNIT_WRITE_SPEEED_PERFORMANCE_BLOCK_OFFSET);
                for (ushort i = 0; i < LogicalUnitWriteSpeedPerformanceBlocks.Length; i++)
                {
                    LogicalUnitWriteSpeedPerformanceBlocks[i] =
                        perfBlocks.Read<LogicalUnitWriteSpeedPerformanceBlock>(i*
                                                                               sizeof (
                                                                                   LogicalUnitWriteSpeedPerformanceBlock
                                                                                   ));
                }
            }
        }

        protected override void MarshalTo(BufferWithSize buffer)
        {
            Marshaler.DefaultStructureToPtr((object) this, buffer);
            unsafe
            {
                BufferWithSize perfBlocks = buffer.ExtractSegment(LOGICAL_UNIT_WRITE_SPEEED_PERFORMANCE_BLOCK_OFFSET);
                for (ushort i = 0; i < LogicalUnitWriteSpeedPerformanceBlocks.Length; i++)
                {
                    perfBlocks.Write(LogicalUnitWriteSpeedPerformanceBlocks[i],
                                     i*sizeof (LogicalUnitWriteSpeedPerformanceBlock));
                }
            }
        }
    }


    [StructLayout(LayoutKind.Sequential, Pack = 1),
     DebuggerDisplay(
         @"\{RotationControlSelected = {RotationControlSelected}, WriteSpeedSupported = {WriteSpeedSupported}\}")]
    public struct LogicalUnitWriteSpeedPerformanceBlock
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte ROTATION_CONTROL_MASK = 0x03;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte1;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public RotationControl RotationControlSelected
        {
            get { return (RotationControl) Bits.GetValueMask(byte1, 0, ROTATION_CONTROL_MASK); }
            set { byte1 = Bits.PutValueMask(byte1, (byte) value, 0, ROTATION_CONTROL_MASK); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ushort _WriteSpeedSupported;

        /// <summary>The write speed, in kbytes/sec. (Is this KB or KiB?)</summary>
        [Description("The write speed, in kbytes/sec. (Is this KB or KiB?)")]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ushort WriteSpeedSupported
        {
            get { return Bits.BigEndian(_WriteSpeedSupported); }
            set { _WriteSpeedSupported = Bits.BigEndian(value); }
        }
    }
}