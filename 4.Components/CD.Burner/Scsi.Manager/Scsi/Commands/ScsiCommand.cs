using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;
using Scsi.Multimedia;

namespace Scsi
{
    /// <summary>Represents a generic Scsi command with a specific operation code. Any derived classes MUST be blittable (that is, contain only primitive types) so that marshaling can be performed. This means that all subclasses must override <see cref="ScsiCommand.Control"/> and make it access the appropriate field.</summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public abstract class ScsiCommand : IMarshalable
    {
        protected ScsiCommand(ScsiCommandCode operationCode)
        {
            OpCode = operationCode;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] internal ScsiCommandCode _OperationCode;
                                                                                   //Internal so we can pin it

        public ScsiCommandCode OpCode
        {
            get { return _OperationCode; }
            private set { _OperationCode = value; }
        }

        public abstract CommandControl Control { get; set; }

        public override string ToString()
        {
#if TO_STRING_OPCODE_ONLY
			return this.OpCode.ToString();
#else
            return Internal.GenericToString(this, true);
#endif
        }

        protected virtual void MarshalFrom(BufferWithSize buffer)
        {
            Marshaler.DefaultPtrToStructure(buffer, this);
        }

        protected virtual void MarshalTo(BufferWithSize buffer)
        {
            Marshaler.DefaultStructureToPtr((object) this, buffer);
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected virtual int MarshaledSize
        {
            get { return Marshal.SizeOf(this); }
        }

        public abstract ScsiTimeoutGroup TimeoutGroup { get; }

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

        public static ScsiCommand CreateInstance(ScsiCommandCode operationCode)
        {
            ScsiCommand result = TryCreateInstance(operationCode);
            if (result == null)
            {
                throw new ArgumentOutOfRangeException("operationCode", operationCode, "Unsupported OpCode.");
            }
            return result;
        }

        public static ScsiCommand TryCreateInstance(ScsiCommandCode operationCode)
        {
            ScsiCommand result;
            switch (operationCode)
            {
                case ScsiCommandCode.Blank:
                    result = new BlankCommand();
                    break;
                case ScsiCommandCode.CloseSessionOrTrack:
                    result = new CloseSessionTrackCommand();
                    break;
                case ScsiCommandCode.Erase10:
                    result = new Erase10Command();
                    break;
                case ScsiCommandCode.Format:
                    result = new FormatUnitCommand();
                    break;
                case ScsiCommandCode.GetConfiguration:
                    result = new GetConfigurationCommand();
                    break;
                case ScsiCommandCode.GetEventStatusNotification:
                    result = new GetEventStatusNotificationCommand();
                    break;
                case ScsiCommandCode.GetPerformance:
                    result = new GetPerformanceCommand();
                    break;
                case ScsiCommandCode.Inquiry:
                    result = new InquiryCommand();
                    break;
                case ScsiCommandCode.LoadUnloadMedium:
                    result = new LoadUnloadMediumCommand();
                    break;
                case ScsiCommandCode.ModeSelect10:
                    result = new ModeSelect10Command();
                    break;
                case ScsiCommandCode.ModeSense10:
                    result = new ModeSense10Command();
                    break;
                case ScsiCommandCode.PreventAllowMediumRemoval:
                    result = new PreventAllowMediumRemovalCommand();
                    break;
                case ScsiCommandCode.Read10:
                    result = new Read10Command();
                    break;
                case ScsiCommandCode.Read12:
                    result = new Read12Command();
                    break;
                case ScsiCommandCode.ReadBuffer:
                    result = new ReadBufferCommand();
                    break;
                case ScsiCommandCode.ReadBufferCapacity:
                    result = new ReadBufferCapacityCommand();
                    break;
                case ScsiCommandCode.ReadCapacity:
                    result = new ReadCapacityCommand();
                    break;
                case ScsiCommandCode.ReadCD:
                    result = new ReadCDCommand();
                    break;
                case ScsiCommandCode.ReadDiscInformation:
                    result = new ReadDiscInformationCommand();
                    break;
                case ScsiCommandCode.ReadDiscStructure:
                    result = new ReadDiscStructureCommand();
                    break;
                case ScsiCommandCode.ReadFormatCapacities:
                    result = new ReadFormatCapacitiesCommand();
                    break;
                case ScsiCommandCode.ReadTocPmaAtip:
                    result = new ReadTocPmaAtipCommand();
                    break;
                case ScsiCommandCode.ReadTrackInformation:
                    result = new ReadTrackInformationCommand();
                    break;
                case ScsiCommandCode.Read06:
                    result = new Read06Command();
                    break;
                case ScsiCommandCode.ReportKey:
                    result = new ReportKeyCommand();
                    break;
                case ScsiCommandCode.RequestSense:
                    result = new RequestSenseCommand();
                    break;
                case ScsiCommandCode.ReserveTrack:
                    result = new ReserveTrackCommand();
                    break;
                case ScsiCommandCode.Seek10:
                    result = new Seek10Command();
                    break;
                case ScsiCommandCode.SendCueSheet:
                    result = new SendCueSheetCommand();
                    break;
                case ScsiCommandCode.SendDiagnostic:
                    result = new SendDiagnosticCommand();
                    break;
                case ScsiCommandCode.SendOpcInformation:
                    result = new SendOpcInformationCommand();
                    break;
                case ScsiCommandCode.SetCDSpeed:
                    result = new SetCDSpeedCommand();
                    break;
                case ScsiCommandCode.SetReadAhead:
                    result = new SetReadAheadCommand();
                    break;
                case ScsiCommandCode.SetRemovableMediaBit:
                    result = new SetRemovableMediaBitCommand();
                    break;
                case ScsiCommandCode.SetStreaming:
                    result = new SetStreamingCommand();
                    break;
                case ScsiCommandCode.StartStopUnit:
                    result = new StartStopUnitCommand();
                    break;
                case ScsiCommandCode.SynchronizeCache10:
                    result = new SynchronizeCache10Command();
                    break;
                case ScsiCommandCode.TestUnitReady:
                    result = new TestUnitReadyCommand();
                    break;
                case ScsiCommandCode.Verify10:
                    result = new Verify10Command();
                    break;
                case ScsiCommandCode.Write10:
                    result = new Write10Command();
                    break;
                case ScsiCommandCode.Write12:
                    result = new Write12Command();
                    break;
                case ScsiCommandCode.WriteBuffer:
                    result = new WriteBufferCommand();
                    break;
                default:
                    result = null;
                    break;
            }
            return result;
        }

        public static ScsiCommand FromBuffer(IntPtr pBuffer, int bufferLength)
        {
            var buffer = new BufferWithSize(pBuffer, bufferLength);
            ScsiCommand instance = CreateInstance(buffer.Read<ScsiCommandCode>());
            Marshaler.PtrToStructure(buffer, ref instance);
            return instance;
        }

        public static ScsiCommand TryFromBuffer(IntPtr pBuffer, int bufferLength)
        {
            var buffer = new BufferWithSize(pBuffer, bufferLength);
            ScsiCommand instance = TryCreateInstance(buffer.Read<ScsiCommandCode>());
            if (instance != null)
            {
                Marshaler.PtrToStructure(buffer, ref instance);
            }
            return instance;
        }

        public static ScsiCommandCode ReadOperationCode(IntPtr cdb, int cdbLength)
        {
            return new BufferWithSize(cdb, cdbLength).Read<ScsiCommandCode>();
        }
    }

    public enum ScsiCommandCode : byte
    {
        AtaPassThrough12 = 0xA1,
        Blank = 0xA1,
        CloseSessionOrTrack = 0x5B,
        CloseTrack = 0x5B,
        Copy = 0x18,
        Erase06 = 0x19,
        Erase10 = 0x2C,
        Format = 0x04,
        GetConfiguration = 0x46,
        GetEventStatusNotification = 0x4A,
        GetPerformance = 0xAC,
        Inquiry = 0x12,
        LoadUnloadMedium = 0xA6,
        MechanismStatus = 0xBD,
        ModeSelect06 = 0x15,
        ModeSelect10 = 0x55,
        ModeSense10 = 0x5A,
        Pause = 0x4B,
        PlayAudio10 = 0x45,
        PlayAudio12 = 0xA5,
        PlayAudioMinuteSecondFrame = 0x47,
        PreventAllowMediumRemoval = 0x1E,
        Read06 = 0x08,
        Read10 = 0x28,
        Read12 = 0xA8,
        Read16 = 0x88,
        Read32 = 0x7F,
        ReadBlockLimits = 0x05,
        ReadBuffer = 0x3C,
        ReadBufferCapacity = 0x5C,
        ReadCapacity = 0x25,
        ReadCD = 0xBE,
        ReadCDMinuteSecondFrame = 0xB9,
        ReadDiscInformation = 0x51,
        ReadDiscStructure = 0xAD,
        ReadFormatCapacities = 0x23,
        ReadReverse06 = 0x0F,
        ReadSubChannel = 0x42,
        ReadTocPmaAtip = 0x43,
        ReadTrackInformation = 0x52,
        ReassignBlocks = 0x07,
        RecoverBufferedData = 0x14,
        Release06 = 0x17,
        RepairTrack = 0x58,
        ReportKey = 0xA4,
        RequestSense = 0x03,
        Reserve06 = 0x16,
        ReserveTrack = 0x53,
        Resume = 0x4B,
        Rewind = 0x01,
        RezeroUnit = 0x01,
        Scan = 0xBA,
        Seek = 0x0B,
        Seek10 = 0x2B,
        SendCueSheet = 0x5D,
        SendDiagnostic = 0x1D,
        SendDiscStructure = 0xBF,
        SendKey = 0xA3,
        SendOpcInformation = 0x54,
        SetCDSpeed = 0xBB,
        SetReadAhead = 0xA7,
        SetRemovableMediaBit = 0xD2,
        SetStreaming = 0xB6,
        Space06 = 0x11,
        StartStopUnit = 0x1B,
        StopPlayScan = 0x4E,
        SynchronizeCache10 = 0x35,
        TestUnitReady = 0x00,
        Verify06 = 0x13,
        Verify10 = 0x2F,
        Write06 = 0x0A,
        Write10 = 0x2A,
        Write12 = 0xAA,
        WriteAndVerify10 = 0x2E,
        WriteBuffer = 0x3B,
        WriteFilemarks06 = 0x10,

        //Vendor-specific: 0x0C, 0x0D, 0x0E
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 1)]
    public struct CommandControl
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte0;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool Link
        {
            get { return Bits.GetBit(byte0, 0); }
            set { byte0 = Bits.SetBit(byte0, 0, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool NormalACA
        {
            get { return Bits.GetBit(byte0, 2); }
            set { byte0 = Bits.SetBit(byte0, 2, value); }
        }

        public override string ToString()
        {
            return string.Format("Lined = {0}, NACA = {1}", Link, NormalACA);
        }
    }
}