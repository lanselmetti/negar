using System;
using System.Runtime.InteropServices;

namespace Ata
{
    [Flags]
    public enum AtaStatus : byte
    {
        None = 0,
        CheckCondition = 1 << 0,
        SenseDataAvailable = 1 << 1,
        AlignmentError = 1 << 2,
        DataRequest = 1 << 3,
        DeferredWriteError = 1 << 4,
        StreamError = 1 << 5,
        DeviceFault = 1 << 5,
        DeviceReady = 1 << 6,
        Busy = 1 << 7
    }

    [Flags]
    public enum AtaError : byte
    {
        None = 0,
        IllegalLengthOrTimeoutOrMediaErrorOrOther = 1 << 0,
        EndOfMedium = 1 << 1,
        Abort = 1 << 2,
        IdNotFound = 1 << 4,
        UncorrectableError = 1 << 6,
        InterfaceCrc = 1 << 7
    }

    [Flags]
    public enum AtaFlags : short
    {
        None = 0,
        DriveReadyRequired = (1 << 0),
        ReceiveData = (1 << 1),
        SendData = (1 << 2),
        Command48Bit = (1 << 3),
        UseDma = (1 << 4),
        NoMultiple = (1 << 5)
    }

    public enum AtaCommand : byte
    {
        CfaEraseSectors = 0xC0,
        CfaRequestExtendedError = 0x03,
        CfaTranslateSector = 0x87,
        CfaWriteMultipleWithoutErase = 0xCD,
        CfaWriteSectorsWithoutErase = 0xCD,
        CheckMediaCardType = 0xD1,
        CheckPowerMode = 0xE5,
        ConfigureStream = 0x51,
        DataSetManagement = 0x06,
        DeviceConfigurationOverlay = 0xB1,
        DeviceReset = 0x08,
        DownloadMicrocode = 0x92,
        DownloadMicrocodeDma = 0x93,
        ExecuteDeviceDiagnostic = 0x90,
        FlushCache = 0xE7,
        FlushCacheExt = 0xEA,
        IdentifyDevice = 0xEC,
        IdentifyPacketDevice = 0xA1,
        Idle = 0xE3,
        IdleImmediate = 0xE1,
        Nop = 0x00,
        NonvolatileCache = 0xB6,
        Packet = 0xA0,
        ReadBuffer = 0xE4,
        ReadBufferDma = 0xE9,
        ReadDma = 0xC8,
        ReadDmaExt = 0x25,
        ReadFpDmaQueued = 0x60,
        ReadLogDmaExt = 0x47,
        ReadLogExt = 0x2F,
        ReadMultiple = 0xC4,
        ReadMultipleExt = 0x29,
        ReadNativeMaxAddress = 0xF8,
        ReadNativeMaxAddressExt = 0x27,
        ReadSectors = 0x20,
        ReadSectorsExt = 0x24,
        ReadStreamDmaExt = 0x2A,
        ReadStreamExt = 0x2A,
        ReadVerifySectors = 0x40,
        ReadVerifySectorsExt = 0x42,
        RequestSenseDataExt = 0x0B,
        SanitizeDevice = 0xB4,
        SecurityDisablePassword = 0xF6,
        SecurityErasePrepare = 0xF3,
        SecurityEraseUnit = 0xF4,
        SecurityFreezeLock = 0xF5,
        SecuritySetPassword = 0xF1,
        SecurityUnlock = 0xF2,
        SetFeatures = 0xEF,
        SetMaxAddress = 0xF9,
        SetMaxAddressExt = 0x37,
        SetMultipleMode = 0xC6,
        Sleep = 0xE6,
        Smart = 0xB0,
        Standby = 0xE2,
        StandbyImmediate = 0xE0,
        TrustedNonData = 0x5B,
        TrustedReceive = 0x5C,
        TrustedReceiveDma = 0x5D,
        TrustedSend = 0x5E,
        TrustedSendDma = 0x5F,
        WriteBuffer = 0xE8,
        WriteBufferDma = 0xEB,
        WriteDma = 0xCA,
        WriteDmaExt = 0x35,
        WriteDmaForceUnitAccessExt = 0x3D,
        WriteFpDmaQueued = 0x61,
        WriteLogDmaExt = 0x57,
        WriteLogExt = 0x3F,
        WriteMultiple = 0xC5,
        WriteMultipleExt = 0x39,
        WriteMultipleForceUnitAccessExt = 0xCE,
        WriteSectors = 0x30,
        WriteSectorsExt = 0x34,
        WriteStreamDmaExt = 0x3A,
        WriteStreamExt = 0x3B,
        WriteUncorrectableExt = 0x45,
    }

    [StructLayout(LayoutKind.Explicit, Pack = 1)]
    public struct AtaTaskFile
    {
        public AtaTaskFile(AtaCommand command) : this(0, 0, 0, 0, 0, command, 0)
        {
        }

        public AtaTaskFile(byte featuresOrError, byte count, uint logicalBlockAddress, byte deviceOrHead,
                           AtaCommand command, byte reserved)
            : this(
                featuresOrError, count, (byte) (logicalBlockAddress & 0xFF),
                (ushort) ((logicalBlockAddress >> 8) & 0xFFFF), deviceOrHead, command, reserved)
        {
            if ((logicalBlockAddress & unchecked(0xFF000000)) != 0)
            {
                throw new ArgumentOutOfRangeException("logicalBlockAddress", logicalBlockAddress,
                                                      "Logical block address must only use the lower 3 bytes.");
            }
        }

        public AtaTaskFile(byte featuresOrError, byte count, byte sector, ushort cylinder, byte deviceOrHead,
                           AtaCommand command, byte reserved)
        {
            Error = (AtaError) (Features = featuresOrError);
            Count = count;
            Sector = sector;
            Cylinder = cylinder;
            DeviceOrHead = deviceOrHead;
            Status = (AtaStatus) (Command = command);
            Reserved = reserved;
        }

        [FieldOffset(0)] public readonly byte Features;
        [FieldOffset(0)] public readonly AtaError Error;
        [FieldOffset(1)] public readonly byte Count;
        [FieldOffset(2)] public readonly byte Sector;
        [FieldOffset(3)] public readonly ushort Cylinder;

        public uint LogicalBlockAddress
        {
            get { return Sector | ((uint) Cylinder << 8); }
        }

        [FieldOffset(5)] public readonly byte DeviceOrHead;
        [FieldOffset(6)] public readonly AtaCommand Command;
        [FieldOffset(6)] public readonly AtaStatus Status;
        [FieldOffset(7)] public readonly byte Reserved;
    }
}