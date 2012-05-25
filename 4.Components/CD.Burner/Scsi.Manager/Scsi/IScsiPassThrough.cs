using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Helper;
using Helper.IO;
using Scsi.Multimedia;

namespace Scsi
{
    /// <summary>A generic pass-through interface. As long as this can be implemented, the library works.</summary>
    /// <remarks>I haven't specified whether this interface represents a device or an adapter, since in Windows it's kind of hard to figure that out.</remarks>
    public interface IScsiPassThrough : IDisposable
    {
        /// <summary>The number of the SCSI adapter.</summary>
        byte PortNumber { get; }

        /// <summary>The number of the bus.</summary>
        byte PathId { get; }

        /// <summary>The number of the target device.</summary>
        byte TargetId { get; }

        /// <summary>The logical unit number.</summary>
        byte LogicalUnitNumber { get; }

        MultimediaProfile CurrentCdromProfile { get; }

        int MaximumTotalTransferBlockCount { get; }
        int MaximumDataTransferBlockCount { get; }
        int MaximumTotalPhysicalPages { get; }
        int SupportedAsynchronousEvents { get; }

        /// <summary>The mask used to check whether data is aligned. This is one less than a power of two; for example, a value of zero means single-byte aligned, while a value of seven means quadword aligned.</summary>
        int AlignmentMask { get; }

        bool TaggedQueuing { get; }
        bool AdapterScansDown { get; }
        bool AdapterUsesProgrammedIO { get; }

        ScsiStatus ExecuteCommand(BufferWithSize cdb, DataTransferDirection direction, byte pathId, byte targetId,
                                  byte logicalUnitNumber, BufferWithSize data, uint timeout, bool autoSense,
                                  out SenseData senseData);

        bool IsVolumeMounted();
        void DismountVolume();
        void LockVolume();
        void UnlockVolume();
        void ResetDevice();
        void ResetBus(byte pathId);
        TFeature GetCdromConfiguration<TFeature>() where TFeature : MultimediaFeature;
        FeatureCollection GetCdromConfiguration(FeatureCode startingFeature, FeatureRequestType requestType);

        /// <summary>Requests the driver to inquiry the current SCSI device on our behalf, using <see cref="GetScsiInquiryData()"/>.</summary>
        StandardInquiryData ScsiInquiry(bool throwIfNotFound);

        StandardInquiryData QueryStorageInquiryData();

        /// <summary>
        /// Requests the driver to return information for all devices on the current Host Bus Adapter.
        /// This is useful because in Windows we cannot directly send a command to a device unless we open it for read/write access,
        /// which causes Windows to wait for the device to finish becoming ready (e.g. upon media insertion). However, this request
        /// does not need any type of access, and can be fulfilled immediately.
        /// </summary>
        /// <returns>An array of key/value pairs in the following format: ((initiator bus ID) => (devices on bus)[])[]</returns>
        KeyValuePair<byte, KeyValuePair<ScsiDeviceInfo, StandardInquiryData>[]>[] GetScsiInquiryData();

        //Deprecated, but who cares?!
        void McnControl(bool disableMediaChangeNotifications);

        /// <returns>Checks whether the mounted medium has changed. If the value is negative, then the medium has probably changed. If the value is zero, the medium has probably not changed. If the value is positive, it represents the media change count; compare it with a previous value to detect changes.</returns>
        int CheckVerify();

        /// <returns>Checks whether the medium has changed. If the value is negative, then the medium has probably changed. If the value is zero, the medium has probably not changed. If the value is positive, it represents the media change count; compare it with a previous value to detect changes.</returns>
        int CheckVerify2();

        DiskGeometry[] GetMediaTypes();
        DiskDeviceMediaInfo[] GetMediaTypesEx(out Win32DeviceType deviceType);
        StandardInquiryData CdromInquiry();
    }

    public struct DiskGeometry
    {
        public int BytesPerSector;
        public long Cylinders;
        public StorageMediaType MediaType;
        public int SectorsPerTrack;
        public int TracksPerCylinder;
    }

    public struct DiskDeviceMediaInfo
    {
        public DiskGeometry DiskGeometry;
        public MediaCharacteristics MediaCharacteristics;
        public int NumberMediaSides;
    }

    public enum StorageMediaType
    {
        Unknown, // Format is unknown
        F5_1Pt2_512, // 5.25", 1.2MB,  512 bytes/sector
        F3_1Pt44_512, // 3.5",  1.44MB, 512 bytes/sector
        F3_2Pt88_512, // 3.5",  2.88MB, 512 bytes/sector
        F3_20Pt8_512, // 3.5",  20.8MB, 512 bytes/sector
        F3_720_512, // 3.5",  720KB,  512 bytes/sector
        F5_360_512, // 5.25", 360KB,  512 bytes/sector
        F5_320_512, // 5.25", 320KB,  512 bytes/sector
        F5_320_1024, // 5.25", 320KB,  1024 bytes/sector
        F5_180_512, // 5.25", 180KB,  512 bytes/sector
        F5_160_512, // 5.25", 160KB,  512 bytes/sector
        RemovableMedia, // Removable media other than floppy
        FixedMedia, // Fixed hard disk media
        F3_120M_512, // 3.5", 120M Floppy
        F3_640_512, // 3.5" ,  640KB,  512 bytes/sector
        F5_640_512, // 5.25",  640KB,  512 bytes/sector
        F5_720_512, // 5.25",  720KB,  512 bytes/sector
        F3_1Pt2_512, // 3.5" ,  1.2Mb,  512 bytes/sector
        F3_1Pt23_1024, // 3.5" ,  1.23Mb, 1024 bytes/sector
        F5_1Pt23_1024, // 5.25",  1.23MB, 1024 bytes/sector
        F3_128Mb_512, // 3.5" MO 128Mb   512 bytes/sector
        F3_230Mb_512, // 3.5" MO 230Mb   512 bytes/sector
        F8_256_128, // 8",     256KB,  128 bytes/sector
        F3_200Mb_512, // 3.5",   200M Floppy (HiFD)


        DDS_4mm = 0x20, // Tape - DAT DDS1,2,... (all vendors)
        MiniQic, // Tape - miniQIC Tape
        Travan, // Tape - Travan TR-1,2,3,...
        QIC, // Tape - QIC
        MP_8mm, // Tape - 8mm Exabyte Metal Particle
        AME_8mm, // Tape - 8mm Exabyte Advanced Metal Evap
        AIT1_8mm, // Tape - 8mm Sony AIT
        DLT, // Tape - DLT Compact IIIxt, IV
        NCTP, // Tape - Philips NCTP
        IBM_3480, // Tape - IBM 3480
        IBM_3490E, // Tape - IBM 3490E
        IBM_Magstar_3590, // Tape - IBM Magstar 3590
        IBM_Magstar_MP, // Tape - IBM Magstar MP
        STK_DATA_D3, // Tape - STK Data D3
        SONY_DTF, // Tape - Sony DTF
        DV_6mm, // Tape - 6mm Digital Video
        DMI, // Tape - Exabyte DMI and compatibles
        SONY_D2, // Tape - Sony D2S and D2L
        CLEANER_CARTRIDGE, // Cleaner - All Drive types that support Drive Cleaners
        CDRom, // Opt_Disk - CD
        CDRecordable, // Opt_Disk - CD-Recordable (Write Once)
        CDRewritable, // Opt_Disk - CD-Rewriteable
        DvdRom, // Opt_Disk - DVD-ROM
        DvdRecordable, // Opt_Disk - DVD-Recordable (Write Once)
        DvdRewritable, // Opt_Disk - DVD-Rewriteable
        MO_3_RW, // Opt_Disk - 3.5" Rewriteable MO Disk
        MO_5_WO, // Opt_Disk - MO 5.25" Write Once
        MO_5_RW, // Opt_Disk - MO 5.25" Rewriteable (not LIMDOW)
        MO_5_LIMDOW, // Opt_Disk - MO 5.25" Rewriteable (LIMDOW)
        PC_5_WO, // Opt_Disk - Phase Change 5.25" Write Once Optical
        PC_5_RW, // Opt_Disk - Phase Change 5.25" Rewriteable
        PD_5_RW, // Opt_Disk - PhaseChange Dual Rewriteable
        ABL_5_WO, // Opt_Disk - Ablative 5.25" Write Once Optical
        PINNACLE_APEX_5_RW, // Opt_Disk - Pinnacle Apex 4.6GB Rewriteable Optical
        SONY_12_WO, // Opt_Disk - Sony 12" Write Once
        PHILIPS_12_WO, // Opt_Disk - Philips/LMS 12" Write Once
        HITACHI_12_WO, // Opt_Disk - Hitachi 12" Write Once
        CYGNET_12_WO, // Opt_Disk - Cygnet/ATG 12" Write Once
        KODAK_14_WO, // Opt_Disk - Kodak 14" Write Once
        MO_NFR_525, // Opt_Disk - Near Field Recording (Terastor)
        NIKON_12_RW, // Opt_Disk - Nikon 12" Rewriteable
        IOMEGA_ZIP, // Mag_Disk - Iomega Zip
        IOMEGA_JAZ, // Mag_Disk - Iomega Jaz
        SYQUEST_EZ135, // Mag_Disk - Syquest EZ135
        SYQUEST_EZFLYER, // Mag_Disk - Syquest EzFlyer
        SYQUEST_SYJET, // Mag_Disk - Syquest SyJet
        AVATAR_F2, // Mag_Disk - 2.5" Floppy
        MP2_8mm, // Tape - 8mm Hitachi
        DST_S, // Ampex DST Small Tapes
        DST_M, // Ampex DST Medium Tapes
        DST_L, // Ampex DST Large Tapes
        VXATape_1, // Ecrix 8mm Tape
        VXATape_2, // Ecrix 8mm Tape
        STK_9840, // STK 9840
        LTO_Ultrium, // IBM, HP, Seagate LTO Ultrium
        LTO_Accelis, // IBM, HP, Seagate LTO Accelis
        DvdRam, // Opt_Disk - DVD-RAM
        AIT_8mm, // AIT2 or higher
        ADR_1, // OnStream ADR Mediatypes
        ADR_2,
        STK_9940, // STK 9940
        SAIT, // SAIT Tapes
        VXATape // VXA (Ecrix 8mm) Tape
    }

    [Flags]
    public enum MediaCharacteristics
    {
        None = 0,
        Erasable = 0x00000001,
        WriteOnce = 0x00000002,
        ReadOnly = 0x00000004,
        ReadWrite = 0x00000008,
        WriteProtected = 0x00000100,
        CurrentlyMounted = unchecked((int) 0x80000000),
    }

    public struct ScsiDeviceInfo
    {
        /// <summary>Indicates whether a device has been claimed by a class driver.</summary>
        [MarshalAs(UnmanagedType.I1)] public readonly bool DeviceClaimed;

        /// <summary>Indicates the logical unit number of the logical unit on the target device.</summary>
        public readonly byte Lun;

        /// <summary>Indicates the number of the bus a device is located on.</summary>
        public readonly byte PathId;

        /// <summary>Indicates the number of the device on a bus.</summary>
        public readonly byte TargetId;

        public ScsiDeviceInfo(byte pathId, byte targetId, byte lun, bool claimed)
        {
            PathId = pathId;
            TargetId = targetId;
            Lun = lun;
            DeviceClaimed = claimed;
        }
    }
}