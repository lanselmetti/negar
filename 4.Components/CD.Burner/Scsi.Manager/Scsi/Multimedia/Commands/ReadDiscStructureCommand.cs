using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class ReadDiscStructureCommand : FixedLengthScsiCommand
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte AGID_MASK = 0xC0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte MEDIA_TYPE_MASK = 0x0F;

        public ReadDiscStructureCommand() : base(ScsiCommandCode.ReadDiscStructure)
        {
        }

        public ReadDiscStructureCommand(GenericDiscStructureFormatCode formatCode, uint address, byte layerNumber,
                                        byte authenticationGrantId)
            : this(default(ReadDiscStructureMediaType), (byte) formatCode, address, layerNumber, authenticationGrantId)
        {
        }

        public ReadDiscStructureCommand(BDStructureFormatCode formatCode, uint address, byte layerNumber,
                                        byte authenticationGrantId)
            : this(ReadDiscStructureMediaType.BD, (byte) formatCode, address, layerNumber, authenticationGrantId)
        {
        }

        public ReadDiscStructureCommand(DvdStructureFormatCode formatCode, uint address, byte layerNumber,
                                        byte authenticationGrantId)
            : this(
                ReadDiscStructureMediaType.DvdAndHDDvd, (byte) formatCode, address, layerNumber, authenticationGrantId)
        {
        }

        public ReadDiscStructureCommand(ReadDiscStructureMediaType subCommand, byte formatCode, uint address,
                                        byte layerNumber, byte authenticationGrantId)
            : this()
        {
            MediaType = subCommand;
            Format = formatCode;
            Address = address;
            LayerNumber = layerNumber;
            AuthenticationGrantId = authenticationGrantId;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte1;

        public ReadDiscStructureMediaType MediaType
        {
            get { return (ReadDiscStructureMediaType) Bits.GetValueMask(byte1, 0, MEDIA_TYPE_MASK); }
            set { byte1 = Bits.PutValueMask(byte1, (byte) value, 0, MEDIA_TYPE_MASK); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private uint _Address;

        public uint Address
        {
            get { return Bits.BigEndian(_Address); }
            set { _Address = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _LayerNumber;

        public byte LayerNumber
        {
            get { return Bits.BigEndian(_LayerNumber); }
            set { _LayerNumber = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _Format;

        /// <summary>Do not use this value unless you are responsible for calling the <see cref="IScsiPassThrough.ExecuteCommand"/> method directly.</summary>
        public byte Format
        {
            get { return Bits.BigEndian(_Format); }
            set { _Format = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ushort _AllocationLength;

        /// <summary>Do not use this value unless you are responsible for calling the <see cref="IScsiPassThrough.ExecuteCommand"/> method directly.</summary>
        public ushort AllocationLength
        {
            get { return Bits.BigEndian(_AllocationLength); }
            set { _AllocationLength = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _byte10;

        public byte AuthenticationGrantId
        {
            get { return Bits.GetValueMask(_byte10, 6, AGID_MASK); }
            set { _byte10 = Bits.PutValueMask(_byte10, value, 6, AGID_MASK); }
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

    /// <summary>Structure format codes for all media types.</summary>
    public enum GenericDiscStructureFormatCode : byte
    {
        AacsVolumeIdentifier = 0x80,
        AacsMediaSerialNumber = 0x81,
        AacsMediaIdentifier = 0x82,
        AacsMediaLockKey = 0x83,
        ListOfRecognizedFormatLayers = 0x90,
        WriteProtectionStatus = 0xC0,
        CapabilityList = 0xFF,
    }

    /// <summary>Structure format codes for BD media only.</summary>
    public enum BDStructureFormatCode : byte
    {
        DiscInformationFromPicInEmbossedArea = 0x00,
        DiscDefinitionStructure = 0x08,
        CartridgeStatus = 0x09,
        StatusOfSpareAreas = 0x0A,
        UnmodifiedDfl = 0x12,
        PhysicalAccessControlStructure = 0x30,
    }

    /// <summary>Structure format codes for DVD and HD DVD media only.</summary>
    public enum DvdStructureFormatCode : byte
    {
        PhysicalInformationFromLeadIn = 0x00,
        CopyrightInformationFromDvdLeadIn = 0x01,
        DiscKeyObfuscatedByBusKey = 0x02,
        BurstCuttingAreaInformationOnMedia = 0x03,
        DiscManufacturingInformationFromLeadIn = 0x04,
        CopyrightManagementInformationFromSector = 0x05,
        MediaIdentifierProtectedByBusKey = 0x06,
        MediaKeyBlockProtectedByBusKey = 0x07,
        DdsInformationOnRamMedia = 0x08,
        RamMediumStatus = 0x09,
        RamSpareAreaInformation = 0x0A,
        RamRecordingTypeInformation = 0x0B,
        /// <remarks>For DVD-R, DVD-RW, and HD DVD-R</remarks>
        RWRmdInLastBorderOut = 0x0C,
        RmdFieldFromLastRecordedBorderOut = 0x0D,
        PreRecordedInformationFromDvdRWLeadIn = 0x0E,
        RWMediaIdentifier = 0x0F,
        RWPhysicalFormatInformation = 0x10,
        AddressInPreGrooveInformation = 0x11,
        CopyrightProtectionInformationFromHdDvdLeadIn = 0x12,
        CopyrightDataSectionFromHDDvdLeadInOrDvdRom3AdaptedToAacsLeadIn = 0x15,
        HDDvdRMediumStatus = 0x19,
        HDDvdRLastRecordedRmdInLatestRmz = 0x1A,
    }

    public enum ReadDiscStructureMediaType : byte
    {
        DvdAndHDDvd = 0x00,
        BD = 0x01,
    }
}