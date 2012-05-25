using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public abstract class MultimediaFeature : IMarshalable
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte VERSION_MASK = 0x3C;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly IntPtr FEATURE_CODE_OFFSET =
            Marshal.OffsetOf(typeof (MultimediaFeature), "_FeatureCode");

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly IntPtr ADDITIONAL_LENGTH_OFFSET =
            Marshal.OffsetOf(typeof (MultimediaFeature), "_AdditionalLength");

#if false
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static IDictionary<MultimediaProfile, ReadOnlyCollection<FeatureCode>> __Profiles;
#endif

        protected MultimediaFeature(FeatureCode featureCode)
        {
            FeatureCode = featureCode;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private FeatureCode _FeatureCode;

        [Browsable(false)]
        public FeatureCode FeatureCode
        {
            get { return Bits.BigEndian(_FeatureCode); }
            private set { _FeatureCode = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte2;

        [DisplayName("Currently Active")]
        public bool Current
        {
            get { return Bits.GetBit(byte2, 0); }
            protected set { byte2 = Bits.SetBit(byte2, 0, value); }
        }

        [DisplayName("Always Active")]
        public bool Persistent
        {
            get { return Bits.GetBit(byte2, 1); }
            protected set { byte2 = Bits.SetBit(byte2, 1, value); }
        }

        [DisplayName("Feature Version")]
        public byte Version
        {
            get { return Bits.GetValueMask(byte2, 2, VERSION_MASK); }
            protected set { byte2 = Bits.PutValueMask(byte2, value, 2, VERSION_MASK); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _AdditionalLength;

        [Browsable(false)]
        public byte AdditionalLength
        {
            get { return _AdditionalLength; }
            protected set { _AdditionalLength = value; }
        }

        public abstract FeatureSupportKind GetSupport(ScsiCommand command);

        protected virtual void MarshalFrom(BufferWithSize buffer)
        {
            int defaultSize = Marshal.SizeOf(this);
            if (buffer.Length32 < defaultSize)
            {
                unsafe
                {
                    byte* pBuf = stackalloc byte[defaultSize];
                    var newBuf = new BufferWithSize(pBuf, defaultSize);
                    BufferWithSize.Copy(buffer, UIntPtr.Zero, newBuf, UIntPtr.Zero, buffer.Length);
                    buffer = newBuf;
                }
            }

            FeatureCode previousFeatureCode = FeatureCode;
            Marshaler.DefaultPtrToStructure(buffer, this);
            Debug.Assert(previousFeatureCode == FeatureCode);
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected virtual int MarshaledSize
        {
            get { return Marshal.SizeOf(this) + AdditionalLength; }
        }

        protected virtual void MarshalTo(BufferWithSize buffer)
        {
            Marshaler.DefaultStructureToPtr((object) this, buffer);
        }

        //public override string ToString() { return this.GetType().Name; }

        internal static MultimediaFeature FromBuffer(BufferWithSize buffer)
        {
            FeatureCode code = ReadFeatureCode(buffer);
            MultimediaFeature result = CreateInstance(code);
            if (result != null)
            {
                result.MarshalFrom(buffer);
            }
            return result;
        }

        internal static MultimediaFeature CreateInstance(FeatureCode code)
        {
            MultimediaFeature result;
            switch (code)
            {
                case FeatureCode.ProfileList:
                    result = new ProfileListFeature();
                    break;
                case FeatureCode.Core:
                    result = new CoreFeature();
                    break;
                case FeatureCode.Morphing:
                    result = new MorphingFeature();
                    break;
                case FeatureCode.RemovableMedium:
                    result = new RemovableMediumFeature();
                    break;
                case FeatureCode.WriteProtect:
                    result = new WriteProtectFeature();
                    break;
                case FeatureCode.RandomReadable:
                    result = new RandomReadableFeature();
                    break;
                case FeatureCode.MultiRead:
                    result = new MultiReadFeature();
                    break;
                case FeatureCode.CDRead:
                    result = new CDReadFeature();
                    break;
                case FeatureCode.DvdRead:
                    result = new DvdReadFeature();
                    break;
                case FeatureCode.RandomWritable:
                    result = new RandomWritableFeature();
                    break;
                case FeatureCode.IncrementalStreamingWritable:
                    result = new IncrementalStreamingWritableFeature();
                    break;
                case FeatureCode.SectorErasable:
                    result = new SectorErasableFeature();
                    break;
                case FeatureCode.Formattable:
                    result = new FormattableFeature();
                    break;
                case FeatureCode.DefectManagement:
                    result = new DefectManagementFeature();
                    break;
                case FeatureCode.WriteOnce:
                    result = new WriteOnceFeature();
                    break;
                case FeatureCode.RestrictedOverwrite:
                    result = new RestrictedOverwriteFeature();
                    break;
                case FeatureCode.CDRWConstantAngularVelocityWrite:
                    result = new CDRWConstantAngularVelocityWriteFeature();
                    break;
                case FeatureCode.MountRainierRewritable:
                    result = new MountRainierRewritableFeature();
                    break;
                case FeatureCode.EnhancedDefectReporting:
                    result = new EnhancedDefectReportingFeature();
                    break;
                case FeatureCode.DvdPlusRW:
                    result = new DvdPlusRWFeature();
                    break;
                case FeatureCode.DvdPlusR:
                    result = new DvdPlusRFeature();
                    break;
                case FeatureCode.RigidRestrictedOverwrite:
                    result = new RigidRestrictedOverwriteFeature();
                    break;
                case FeatureCode.CDTrackAtOnce:
                    result = new CDTrackAtOnceFeature();
                    break;
                case FeatureCode.CDMastering:
                    result = new CDMasteringFeature();
                    break;
                case FeatureCode.DvdMinusRWWrite:
                    result = new DvdMinusRWWriteFeature();
                    break;
                case FeatureCode.DoubleDensityCDRead:
                    result = new DoubleDensityCDReadFeature();
                    break;
                case FeatureCode.DoubleDensityCDRWrite:
                    result = new DoubleDensityCDRWriteFeature();
                    break;
                case FeatureCode.DoubleDensityCDRWWrite:
                    result = new DoubleDensityCDRWWriteFeature();
                    break;
                case FeatureCode.LayerJumpRecording:
                    result = new LayerJumpRecordingFeature();
                    break;
                case FeatureCode.LayerJumpRigidRestrictedOverwrite:
                    result = new LayerJumpRigidRestrictedOverwriteFeature();
                    break;
                case FeatureCode.StopLongOperation:
                    result = new StopLongOperationFeature();
                    break;
                case FeatureCode.CDRWMediaWriteSupport:
                    result = new CDRWMediaWriteSupportFeature();
                    break;
                case FeatureCode.BDRPseudoOverwrite:
                    result = new BDRPseudoOverwriteFeature();
                    break;
                case FeatureCode.DvdPlusRWDualLayer:
                    result = new DvdPlusRWDualLayerFeature();
                    break;
                case FeatureCode.DvdPlusRDualLayer:
                    result = new DvdPlusRDualLayerFeature();
                    break;
                case FeatureCode.BDRead:
                    result = new BDReadFeature();
                    break;
                case FeatureCode.BDWrite:
                    result = new BDWriteFeature();
                    break;
                case FeatureCode.TimelySafeRecording:
                    result = new TimelySafeRecordingFeature();
                    break;
                case FeatureCode.HDDvdRead:
                    result = new HDDvdReadFeature();
                    break;
                case FeatureCode.HDDvdWrite:
                    result = new HDDvdWriteFeature();
                    break;
                case FeatureCode.HDDvdRWFragmentRecording:
                    result = new HDDvdRWFragmentRecordingFeature();
                    break;
                case FeatureCode.HybridDisc:
                    result = new HybridDiscFeature();
                    break;
                case FeatureCode.PowerManagement:
                    result = new PowerManagementFeature();
                    break;
                case FeatureCode.SelfMonitoringAnalysisAndReportingTechnology:
                    result = new SmartFeature();
                    break;
                case FeatureCode.EmbeddedChanger:
                    result = new EmbeddedChangerFeature();
                    break;
                case FeatureCode.CDAudioExternalPlay:
                    result = new CDAudioExternalPlayFeature();
                    break;
                case FeatureCode.MicrocodeUpgrade:
                    result = new MicrocodeUpgradeFeature();
                    break;
                case FeatureCode.Timeout:
                    result = new TimeoutFeature();
                    break;
                case FeatureCode.DvdContentScramblingSystem:
                    result = new DvdContentScramblingSystemFeature();
                    break;
                case FeatureCode.RealTimeStreaming:
                    result = new RealTimeStreamingFeature();
                    break;
                case FeatureCode.DriveSerialNumber:
                    result = new DriveSerialNumberFeature();
                    break;
                case FeatureCode.MediaSerialNumber:
                    result = new MediaSerialNumberFeature();
                    break;
                case FeatureCode.DiscControlBlocks:
                    result = new DiscControlBlocksFeature();
                    break;
                case FeatureCode.DvdContentProtectionForRecordableMedia:
                    result = new DvdContentProtectionForRecordableMediaFeature();
                    break;
                case FeatureCode.FirmwareInformation:
                    result = new FirmwareInformationFeature();
                    break;
                case FeatureCode.AdvancedAccessContentSystem:
                    result = new AdvancedAccessContentSystemFeature();
                    break;
                case FeatureCode.DvdContentScramblingSystemManagedRecording:
                    result = new DvdCssManagedRecordingFeature();
                    break;
                case FeatureCode.VCPS:
                    result = new VCPSFeature();
                    break;
                case FeatureCode.SecurDisc:
                    result = new SecurDiscFeature();
                    break;
                default:
                    if (unchecked((ushort) code) >= 0xFF00 && unchecked((ushort) code) <= 0xFFFF)
                    {
                        result = new VendorSpecificFeature();
                    }
                    else
                    {
                        if (!Enum.IsDefined(typeof (FeatureCode), code))
                        {
                            throw new ArgumentOutOfRangeException("code", code, "Invalid feature code.");
                        }
                        result = null;
                    }
                    break;
            }
            return result;
        }

        internal static FeatureCode ReadFeatureCode(BufferWithSize buffer)
        {
            return Bits.BigEndian(buffer.Read<FeatureCode>(FEATURE_CODE_OFFSET));
        }

        internal static byte ReadAdditionalLength(BufferWithSize buffer)
        {
            return Bits.BigEndian(buffer.Read<byte>(ADDITIONAL_LENGTH_OFFSET));
        }

        protected static T[] Sort<T>(T[] array)
        {
            Array.Sort(array);
            return array;
        }

#if false
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static IDictionary<MultimediaProfile, ReadOnlyCollection<FeatureCode>> KnownProfiles
		{
			get
			{
				if (__Profiles == null)
				{
					var profiles = new Dictionary<MultimediaProfile, ReadOnlyCollection<FeatureCode>>();
					profiles.Add(MultimediaProfile.NonRemovableDisc, new ReadOnlyCollection<FeatureCode>(new FeatureCode[] { FeatureCode.ProfileList, FeatureCode.Core, FeatureCode.RandomReadable, FeatureCode.RandomWritable, FeatureCode.DefectManagement, FeatureCode.PowerManagement, FeatureCode.SelfMonitoringAnalysisAndReportingTechnology }));
					profiles.Add(MultimediaProfile.RemovableDisc, new ReadOnlyCollection<FeatureCode>(new FeatureCode[] { FeatureCode.ProfileList, FeatureCode.Core, FeatureCode.Morphing, FeatureCode.RemovableMedium, FeatureCode.RandomReadable, FeatureCode.RandomWritable, FeatureCode.Formattable, FeatureCode.DefectManagement, FeatureCode.PowerManagement, FeatureCode.Timeout }));
					profiles.Add(MultimediaProfile.MagnetoOpticalErasable, new ReadOnlyCollection<FeatureCode>(new FeatureCode[] { FeatureCode.ProfileList, FeatureCode.Core, FeatureCode.Morphing, FeatureCode.RemovableMedium, FeatureCode.RandomReadable, FeatureCode.RandomWritable, FeatureCode.SectorErasable, FeatureCode.Formattable, FeatureCode.DefectManagement, FeatureCode.PowerManagement, FeatureCode.Timeout }));
					profiles.Add(MultimediaProfile.OpticalWriteOnce, new ReadOnlyCollection<FeatureCode>(new FeatureCode[] { FeatureCode.ProfileList, FeatureCode.Core, FeatureCode.Morphing, FeatureCode.RemovableMedium, FeatureCode.RandomReadable, FeatureCode.DefectManagement, FeatureCode.WriteOnce, FeatureCode.PowerManagement, FeatureCode.Timeout }));
					profiles.Add(MultimediaProfile.ASMO, new ReadOnlyCollection<FeatureCode>(new FeatureCode[] { FeatureCode.ProfileList, FeatureCode.Core, FeatureCode.Morphing, FeatureCode.RemovableMedium, FeatureCode.RandomReadable, FeatureCode.RandomWritable, FeatureCode.Formattable, FeatureCode.DefectManagement, FeatureCode.PowerManagement, FeatureCode.Timeout, FeatureCode.RealTimeStreaming }));
					profiles.Add(MultimediaProfile.CDROM, new ReadOnlyCollection<FeatureCode>(new FeatureCode[] { FeatureCode.ProfileList, FeatureCode.Core, FeatureCode.Morphing, FeatureCode.RemovableMedium, FeatureCode.RandomReadable, FeatureCode.CDRead, FeatureCode.PowerManagement, FeatureCode.Timeout }));
					profiles.Add(MultimediaProfile.CDR, new ReadOnlyCollection<FeatureCode>(new FeatureCode[] { FeatureCode.ProfileList, FeatureCode.Core, FeatureCode.Morphing, FeatureCode.RemovableMedium, FeatureCode.RandomReadable, FeatureCode.CDRead, FeatureCode.IncrementalStreamingWritable, FeatureCode.CDTrackAtOnce, FeatureCode.PowerManagement, FeatureCode.Timeout, FeatureCode.RealTimeStreaming }));
					profiles.Add(MultimediaProfile.CDRW, new ReadOnlyCollection<FeatureCode>(new FeatureCode[] { FeatureCode.ProfileList, FeatureCode.Core, FeatureCode.Morphing, FeatureCode.RemovableMedium, FeatureCode.RandomReadable, FeatureCode.MultiRead, FeatureCode.CDRead, FeatureCode.IncrementalStreamingWritable, FeatureCode.Formattable, FeatureCode.RestrictedOverwrite, FeatureCode.CDTrackAtOnce, FeatureCode.PowerManagement, FeatureCode.Timeout, FeatureCode.RealTimeStreaming }));
					profiles.Add(MultimediaProfile.DvdRom, new ReadOnlyCollection<FeatureCode>(new FeatureCode[] { FeatureCode.ProfileList, FeatureCode.Core, FeatureCode.Morphing, FeatureCode.RemovableMedium, FeatureCode.RandomReadable, FeatureCode.DvdRead, FeatureCode.PowerManagement, FeatureCode.Timeout, FeatureCode.RealTimeStreaming }));
					profiles.Add(MultimediaProfile.DvdMinusRSequentialRecording, new ReadOnlyCollection<FeatureCode>(new FeatureCode[] { FeatureCode.ProfileList, FeatureCode.Core, FeatureCode.Morphing, FeatureCode.RemovableMedium, FeatureCode.RandomReadable, FeatureCode.DvdRead, FeatureCode.IncrementalStreamingWritable, FeatureCode.DvdMinusRWWrite, FeatureCode.PowerManagement, FeatureCode.Timeout, FeatureCode.RealTimeStreaming, FeatureCode.DriveSerialNumber }));
					profiles.Add(MultimediaProfile.DvdRam, new ReadOnlyCollection<FeatureCode>(new FeatureCode[] { FeatureCode.ProfileList, FeatureCode.Core, FeatureCode.Morphing, FeatureCode.RemovableMedium, FeatureCode.RandomReadable, FeatureCode.DvdRead, FeatureCode.RandomWritable, FeatureCode.Formattable, FeatureCode.DefectManagement, FeatureCode.PowerManagement, FeatureCode.Timeout, FeatureCode.RealTimeStreaming }));
					profiles.Add(MultimediaProfile.DvdMinusRWRestrictedOverwrite, new ReadOnlyCollection<FeatureCode>(new FeatureCode[] { FeatureCode.ProfileList, FeatureCode.Core, FeatureCode.Morphing, FeatureCode.RemovableMedium, FeatureCode.RandomReadable, FeatureCode.DvdRead, FeatureCode.Formattable, FeatureCode.RigidRestrictedOverwrite, FeatureCode.PowerManagement, FeatureCode.Timeout, FeatureCode.RealTimeStreaming, FeatureCode.DriveSerialNumber }));
					profiles.Add(MultimediaProfile.DvdMinusRWSequentialRecording, new ReadOnlyCollection<FeatureCode>(new FeatureCode[] { FeatureCode.ProfileList, FeatureCode.Core, FeatureCode.Morphing, FeatureCode.RemovableMedium, FeatureCode.RandomReadable, FeatureCode.DvdRead, FeatureCode.IncrementalStreamingWritable, FeatureCode.DvdMinusRWWrite, FeatureCode.PowerManagement, FeatureCode.Timeout, FeatureCode.RealTimeStreaming, FeatureCode.DriveSerialNumber }));
					profiles.Add(MultimediaProfile.DvdMinusRDualLayerSequentialRecording, new ReadOnlyCollection<FeatureCode>(new FeatureCode[] { FeatureCode.ProfileList, FeatureCode.Core, FeatureCode.Morphing, FeatureCode.RemovableMedium, FeatureCode.RandomReadable, FeatureCode.DvdRead, FeatureCode.IncrementalStreamingWritable, FeatureCode.DvdMinusRWWrite, FeatureCode.PowerManagement, FeatureCode.Timeout, FeatureCode.DriveSerialNumber }));
					profiles.Add(MultimediaProfile.DvdMinusRDualLayerJumpRecording, new ReadOnlyCollection<FeatureCode>(new FeatureCode[] { FeatureCode.ProfileList, FeatureCode.Core, FeatureCode.Morphing, FeatureCode.RemovableMedium, FeatureCode.DvdRead, FeatureCode.LayerJumpRecording, FeatureCode.PowerManagement, FeatureCode.Timeout, FeatureCode.RealTimeStreaming, FeatureCode.DriveSerialNumber }));
					profiles.Add(MultimediaProfile.DvdMinusRWDualLayer, new ReadOnlyCollection<FeatureCode>(new FeatureCode[] { FeatureCode.ProfileList, FeatureCode.Core, FeatureCode.Morphing, FeatureCode.RemovableMedium, FeatureCode.RandomReadable, FeatureCode.DvdRead, FeatureCode.Formattable, FeatureCode.RigidRestrictedOverwrite, FeatureCode.StopLongOperation, FeatureCode.PowerManagement, FeatureCode.Timeout, FeatureCode.RealTimeStreaming, FeatureCode.DriveSerialNumber }));
					profiles.Add(MultimediaProfile.DvdDownloadDiscRecording, new ReadOnlyCollection<FeatureCode>(new FeatureCode[] { FeatureCode.ProfileList, FeatureCode.Core, FeatureCode.Morphing, FeatureCode.RemovableMedium, FeatureCode.RandomReadable, FeatureCode.DvdRead, FeatureCode.IncrementalStreamingWritable, FeatureCode.DvdMinusRWWrite, FeatureCode.PowerManagement, FeatureCode.Timeout, FeatureCode.RealTimeStreaming, FeatureCode.DriveSerialNumber, FeatureCode.DvdContentScramblingSystemManagedRecording }));
					profiles.Add(MultimediaProfile.DvdPlusRW, new ReadOnlyCollection<FeatureCode>(new FeatureCode[] { FeatureCode.ProfileList, FeatureCode.Core, FeatureCode.Morphing, FeatureCode.RemovableMedium, FeatureCode.RandomReadable, FeatureCode.DvdRead, FeatureCode.RandomWritable, FeatureCode.Formattable, FeatureCode.DvdPlusRW, FeatureCode.PowerManagement, FeatureCode.Timeout, FeatureCode.RealTimeStreaming, FeatureCode.DiscControlBlocks }));
					profiles.Add(MultimediaProfile.DvdPlusR, new ReadOnlyCollection<FeatureCode>(new FeatureCode[] { FeatureCode.ProfileList, FeatureCode.Core, FeatureCode.Morphing, FeatureCode.RemovableMedium, FeatureCode.RandomReadable, FeatureCode.DvdRead, FeatureCode.DvdPlusR, FeatureCode.PowerManagement, FeatureCode.Timeout, FeatureCode.RealTimeStreaming, FeatureCode.DiscControlBlocks }));
					profiles.Add(MultimediaProfile.DvdPlusRWDualLayer, new ReadOnlyCollection<FeatureCode>(new FeatureCode[] { FeatureCode.ProfileList, FeatureCode.Core, FeatureCode.Morphing, FeatureCode.RemovableMedium, FeatureCode.RandomReadable, FeatureCode.DvdRead, FeatureCode.RandomWritable, FeatureCode.Formattable, FeatureCode.DvdPlusRW, FeatureCode.DvdPlusRWDualLayer, FeatureCode.PowerManagement, FeatureCode.Timeout, FeatureCode.RealTimeStreaming, FeatureCode.DiscControlBlocks }));
					profiles.Add(MultimediaProfile.DvdPlusRDualLayer, new ReadOnlyCollection<FeatureCode>(new FeatureCode[] { FeatureCode.ProfileList, FeatureCode.Core, FeatureCode.Morphing, FeatureCode.RandomReadable, FeatureCode.DvdRead, FeatureCode.DvdPlusRDualLayer, FeatureCode.PowerManagement, FeatureCode.Timeout, FeatureCode.RealTimeStreaming, FeatureCode.DiscControlBlocks }));
					/*
					profiles.Add(MultimediaProfile.BDROM, new ReadOnlyCollection<FeatureCode>(new FeatureCode[] { FeatureCode.ProfileList, FeatureCode.Core, FeatureCode }));
					profiles.Add(MultimediaProfile.BDRSequentialRecording, new ReadOnlyCollection<FeatureCode>(new FeatureCode[] { FeatureCode.ProfileList, FeatureCode.Core, FeatureCode }));
					profiles.Add(MultimediaProfile.BDRERandomRecording, new ReadOnlyCollection<FeatureCode>(new FeatureCode[] { FeatureCode.ProfileList, FeatureCode.Core, FeatureCode }));
					profiles.Add(MultimediaProfile.BDRE, new ReadOnlyCollection<FeatureCode>(new FeatureCode[] { FeatureCode.ProfileList, FeatureCode.Core, FeatureCode }));
					profiles.Add(MultimediaProfile.HDDvdRom, new ReadOnlyCollection<FeatureCode>(new FeatureCode[] { FeatureCode.ProfileList, FeatureCode.Core, FeatureCode }));
					profiles.Add(MultimediaProfile.HDDvdR, new ReadOnlyCollection<FeatureCode>(new FeatureCode[] { FeatureCode.ProfileList, FeatureCode.Core, FeatureCode }));
					profiles.Add(MultimediaProfile.HDDvdRam, new ReadOnlyCollection<FeatureCode>(new FeatureCode[] { FeatureCode.ProfileList, FeatureCode.Core, FeatureCode }));
					profiles.Add(MultimediaProfile.HDDvdRW, new ReadOnlyCollection<FeatureCode>(new FeatureCode[] { FeatureCode.ProfileList, FeatureCode.Core, FeatureCode }));
					profiles.Add(MultimediaProfile.HDDvdRDualLayer, new ReadOnlyCollection<FeatureCode>(new FeatureCode[] { FeatureCode.ProfileList, FeatureCode.Core, FeatureCode }));
					profiles.Add(MultimediaProfile.HDDvdRWDualLayer, new ReadOnlyCollection<FeatureCode>(new FeatureCode[] { FeatureCode.ProfileList, FeatureCode.Core, FeatureCode }));
					profiles.Add(MultimediaProfile.Nonstandard, new ReadOnlyCollection<FeatureCode>(new FeatureCode[] { FeatureCode.ProfileList, FeatureCode.Core }));
					//*/
					System.Threading.Interlocked.CompareExchange(ref __Profiles, profiles, null);
				}
				return __Profiles;
			}
		}
#endif

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

    public enum FeatureSupportKind
    {
        None,
        Mandatory,
        Optional,
        ConditionalMandatory
    }

    public enum FeatureCode : short
    {
        /// <summary>This feature identifies profiles supported by the drive.</summary>
        [EnumValueDisplayName("Profile List")] ProfileList = 0x0000,
        /// <summary>This feature identifies a drive that supports functionality common to all devices.</summary>
        [EnumValueDisplayName("Core")] [Description("This feature identifies a drive that supports functionality common to all devices.")] Core =
            0x0001,
        /// <summary>This feature identifies the ability of the drive to notify a host about operational changes and accept host requests to prevent operational changes.</summary>
        [EnumValueDisplayName("Morphing")] [Description(
            "This feature identifies the ability of the drive to notify a host about operational changes and accept host requests to prevent operational changes."
            )] Morphing = 0x0002,
        /// <summary>This feature identifies a drive that has a medium that is removable. Media is be considered removable if it is possible to remove it from the loaded position, i.e., a single mechanism changer, even if the media is captive to the changer.</summary>
        [EnumValueDisplayName("Removable Medium")] [Description(
            "This feature identifies a drive that has a medium that is removable. Media is be considered removable if it is possible to remove it from the loaded position, i.e., a single mechanism changer, even if the media is captive to the changer."
            )] RemovableMedium = 0x0003,
        /// <summary>This feature identifies reporting capability and changing capability for write protection status of the drive.</summary>
        [EnumValueDisplayName("Write Protect")] [Description(
            "This feature identifies reporting capability and changing capability for write protection status of the drive."
            )] WriteProtect = 0x0004,
        //0x0005-0x0010 reserved
        /// <summary>This feature identifies a drive that is able to read data from logical blocks referenced by logical block addresses, but not requiring that either the addresses or the read sequences occur in any particular order.</summary>
        [EnumValueDisplayName("Random Read")] [Description(
            "This feature identifies a drive that is able to read data from logical blocks referenced by logical block addresses, but not requiring that either the addresses or the read sequences occur in any particular order."
            )] RandomReadable = 0x0010,
        //0x0011-0x001C reserved
        /// <summary>The drive conforms to the OSTA Multi-Read specification 1.00, with the exception of CD play capability (the <see cref="CDAudioExternalPlayFeature"/> is not required).</summary>
        [EnumValueDisplayName("Multi-Read")] [Description(
            "The drive conforms to the OSTA Multi-Read specification 1.00, with the exception of CD play capability (the CDAudioExternalPlayFeature) is not required)."
            )] MultiRead = 0x001D,
        /// <summary>This feature identifies a drive that is able to read CD specific information from the media and is able to read user data from all types of CD sectors.</summary>
        [EnumValueDisplayName("CD Read")] [Description(
            "This feature identifies a drive that is able to read CD specific information from the media and is able to read user data from all types of CD sectors."
            )] CDRead = 0x001E,
        /// <summary>This feature identifies a drive that is able to read DVD specific information from the media.</summary>
        [EnumValueDisplayName("DVD Read")] [Description("This feature identifies a drive that is able to read DVD specific information from the media.")] DvdRead = 0x001F,
        /// <summary>This feature identifies a drive that is able to write data to logical blocks specified by logical block addresses. There is no requirement that the addresses in sequences of writes occur in any particular order.</summary>
        [EnumValueDisplayName("Random Write")] [Description(
            "This feature identifies a drive that is able to write data to logical blocks specified by logical block addresses. There is no requirement that the addresses in sequences of writes occur in any particular order."
            )] RandomWritable = 0x0020,
        /// <summary>This feature identifies a drive that is able to write data to a contiguous region, and is able to append data to a limited number of locations on the media. On CD media, this is known as packet recording, on DVD and HD DVD media it is known as Incremental Recording, and on a BD-R disc it is known as SRM recording.</summary>
        [EnumValueDisplayName("Incremental Streaming Write")] [Description(
            "This feature identifies a drive that is able to write data to a contiguous region, and is able to append data to a limited number of locations on the media. On CD media, this is known as packet recording, on DVD and HD DVD media it is known as Incremental Recording, and on a BD-R disc it is known as SRM recording."
            )] IncrementalStreamingWritable = 0x0021,
        /// <summary></summary>
        [EnumValueDisplayName("Sector Erase")] SectorErasable = 0x0022,
        /// <summary>This feature identifies a drive that is able to format media into logical blocks.</summary>
        [EnumValueDisplayName("Format")] [Description("This feature identifies a drive that is able to format media into logical blocks.")] Formattable =
            0x0023,
        /// <summary>This feature identifies a drive that has defect management available to provide a defect-free contiguous address space.</summary>
        [EnumValueDisplayName("Defect Management")] [Description(
            "This feature identifies a drive that has defect management available to provide a defect-free contiguous address space."
            )] DefectManagement = 0x0024,
        /// <summary>This feature identifies a drive that has the ability to record to any previously unrecorded logical block. The recording of logical blocks may occur in any order. Previously recorded blocks are not overwritten.</summary>
        [EnumValueDisplayName("Write-Once")] [Description(
            "This feature identifies a drive that has the ability to record to any previously unrecorded logical block. The recording of logical blocks may occur in any order. Previously recorded blocks are not overwritten."
            )] WriteOnce = 0x0025,
        /// <summary>This feature identifies a drive that has the ability to overwrite logical blocks only in fixed sets at a time.</summary>
        [EnumValueDisplayName("Restricted Overwrite")] [Description(
            "This feature identifies a drive that has the ability to overwrite logical blocks only in fixed sets at a time."
            )] RestrictedOverwrite = 0x0026,
        /// <summary>This feature identifies a drive that has the ability to write CD-RW media that is designed for constant angular velocity recording. The drive conforms to the Orange Book Part 3 Volume 2 specification. This feature is not current if high-speed recordable CD-RW media is not mounted.</summary>
        [EnumValueDisplayName("CD-RW CAV Write")] [Description(
            "This feature identifies a drive that has the ability to write CD-RW media that is designed for constant angular velocity recording. The drive conforms to the Orange Book Part 3 Volume 2 specification. This feature is not current if high-speed recordable CD-RW media is not mounted."
            )] CDRWConstantAngularVelocityWrite = 0x0027,
        /// <summary>This feature indicates that the drive is capable of reading a disc with the MRW format.</summary>
        [EnumValueDisplayName("Mount Rainier Rewritable (MRW)")] [Description("This feature indicates that the drive is capable of reading a disc with the MRW format.")] MountRainierRewritable = 0x0028,
        /// <summary>This feature identifies a drive that has the ability to perform media certification and RECOVERED ERROR reporting for drive assisted software defect management. In case of Persistent-DM mode, the <see cref="Read12Command"/> command with Streaming bit = 1 may be performed without medium certification. When this feature is current, the <see cref="DefectManagementFeature"/> is not current. This feature may be current when Restricted Overwrite formatted media or Rigid Restricted Overwrite formatted media is present.</summary>
        [EnumValueDisplayName("Enhanced Defect Reporting")] [Description(
            "This feature identifies a drive that has the ability to perform media certification and RECOVERED ERROR reporting for drive assisted software defect management. In case of Persistent-DM mode, the Read12Command command with Streaming bit = 1 may be performed without medium certification. When this feature is current, the DefectManagementFeature is not current. This feature may be current when Restricted Overwrite formatted media or Rigid Restricted Overwrite formatted media is present."
            )] EnhancedDefectReporting = 0x0029, //added
        /// <summary>This feature indicates that the drive is capable of reading a recorded DVD+RW disc that is formatted according to [DVD+Ref2].</summary>
        [EnumValueDisplayName("DVD+RW")] [Description(
            "This feature indicates that the drive is capable of reading a recorded DVD+RW disc that is formatted according to [DVD+Ref2]."
            )] DvdPlusRW = 0x002A,
        /// <summary>This feature indicates that the drive is capable of reading a recorded DVD+R disc that is written according to [DVD+Ref1]. Specifically, this includes the capability of reading DCBs.</summary>
        [EnumValueDisplayName("DVD+R")] [Description(
            "This feature indicates that the drive is capable of reading a recorded DVD+R disc that is written according to [DVD+Ref1]. Specifically, this includes the capability of reading DCBs."
            )] DvdPlusR = 0x002B, //added
        /// <summary>This feature identifies a drive that has the ability to perform writing only on blocking boundaries. This feature is different from the <see cref="RestrictedOverwriteFeature"/> feature because each write command is also required to end on a blocking boundary. This feature replaces the <see cref="RandomWritableFeature"/> for drives that do not perform readmodify- write operations on write requests smaller than blocking. This feature may be present when DVD-RW Restricted Over Writable media is loaded. Drives with write protected media do not have this feature current. This feature is not current if the <see cref="RandomWritableFeature"/> is current. If this feature is current, the <see cref="RandomWritableFeature"/> feature is not current.</summary>
        [EnumValueDisplayName("Rigid Restricted Overwrite")] [Description(
            "This feature identifies a drive that has the ability to perform writing only on blocking boundaries. This feature is different from the RestrictedOverwriteFeature feature because each write command is also required to end on a blocking boundary. This feature replaces the RandomWritableFeature for drives that do not perform readmodify- write operations on write requests smaller than blocking. This feature may be present when DVD-RW Restricted Over Writable media is loaded. Drives with write protected media do not have this feature current. This feature is not current if the RandomWritableFeature is current. If this feature is current, the RandomWritableFeature feature is not current."
            )] RigidRestrictedOverwrite = 0x002C,
        /// <summary>This feature identifies a drive that is able to write data to a CD track.</summary>
        [EnumValueDisplayName("CD Track-at-Once")] [Description("This feature identifies a drive that is able to write data to a CD track.")] CDTrackAtOnce =
            0x002D,
        /// <summary>This feature identifies a drive that is able to write a CD in session-at-once or raw mode.</summary>
        [EnumValueDisplayName("CD Mastering (Session-at-once or RAW)")] [Description("This feature identifies a drive that is able to write a CD in session-at-once or raw mode.")] CDMastering = 0x002E,
        /// <summary>This feature identifies a drive that has the ability to write data to DVD-R/-RW in disc at once mode.</summary>
        [EnumValueDisplayName("DVD-RW Write")] [Description(
            "This feature identifies a drive that has the ability to write data to DVD-R/-RW in disc at once mode.")] DvdMinusRWWrite = 0x002F,
        /// <summary></summary>
        [EnumValueDisplayName("Double-Density CD (DDCD) Read")] DoubleDensityCDRead = 0x0030,
        /// <summary></summary>
        [EnumValueDisplayName("Double-Density CD-R (DDCD-R) Write")] DoubleDensityCDRWrite = 0x0031,
        /// <summary></summary>
        [EnumValueDisplayName("Double-Density CD-RW (DDCD-RW) Write")] DoubleDensityCDRWWrite = 0x0032,
        /// <summary>This feature identifies a drive that is able to write data to contiguous regions that are allocated on multiple layers, and is able to append data to a limited number of locations on the media. The drive may write two or more recording layers sequentially and alternately.</summary>
        [EnumValueDisplayName("Layer Jump Recording")] [Description(
            "This feature identifies a drive that is able to write data to contiguous regions that are allocated on multiple layers, and is able to append data to a limited number of locations on the media. The drive may write two or more recording layers sequentially and alternately."
            )] LayerJumpRecording = 0x0033, //added
        /// <summary>This feature indicate the ability to write in layer jump recording mode and the ability to overwrite the logically recorded blocks, but only in blocking boundaries. The layer Jump <see cref="RigidRestrictedOverwriteFeature"/> and the <see cref="RandomWritableFeature"/> are not be concurrently current. If the mounted medium is write protected, this feature is not current. This feature and the <see cref="RigidRestrictedOverwriteFeature"/> may be concurrently current, but when the current recording mode of the mounted disc is layer jump recording mode, <see cref="RigidRestrictedOverwriteFeature"/> is not current.</summary>
        [EnumValueDisplayName("Layer Jump Rigid Restricted Overwrite")] [Description(
            "This feature indicate the ability to write in layer jump recording mode and the ability to overwrite the logically recorded blocks, but only in blocking boundaries. The layer Jump RigidRestrictedOverwriteFeature and the RandomWritableFeature are not be concurrently current. If the mounted medium is write protected, this feature is not current. This feature and the RigidRestrictedOverwriteFeature may be concurrently current, but when the current recording mode of the mounted disc is layer jump recording mode, RigidRestrictedOverwriteFeature is not current."
            )] LayerJumpRigidRestrictedOverwrite = 0x0034, //added
        /// <summary>This feature identifies the ability to stop the long immediate operation (e.g., formatting and closing) by a command.</summary>
        [EnumValueDisplayName("Stop Long Operation")] [Description(
            "This feature identifies the ability to stop the long immediate operation (e.g., formatting and closing) by a command."
            )] StopLongOperation = 0x0035, //added
        //0x0036 reserved
        /// <summary>This feature identifies a drive that has the ability to perform writing CD-RW media. This feature is not current if CD-RW media is not mounted.</summary>
        [EnumValueDisplayName("CD-RW Write")] [Description(
            "This feature identifies a drive that has the ability to perform writing CD-RW media. This feature is not current if CD-RW media is not mounted."
            )] CDRWMediaWriteSupport = 0x0037, //added
        /// <summary>A drive that reports the feature is able to provide logical block overwrite service on BD-R discs that are formatted as SRM+POW.</summary>
        [EnumValueDisplayName("BD Pseudo-Overwrite (BD-POW)")] [Description(
            "A drive that reports the feature is able to provide logical block overwrite service on BD-R discs that are formatted as SRM+POW."
            )] BDRPseudoOverwrite = 0x0038, //added
        //0x0039 reserved
        /// <summary>This feature indicates that the drive is capable of reading a recorded DVD+RW DL disc that is formatted according to [DVD+Ref4]. Specifically, this includes the capability of reading DCBs.</summary>
        [EnumValueDisplayName("DVD+RW DL")] [Description(
            "This feature indicates that the drive is capable of reading a recorded DVD+RW DL disc that is formatted according to [DVD+Ref4]. Specifically, this includes the capability of reading DCBs."
            )] DvdPlusRWDualLayer = 0x003A, //added
        /// <summary>This feature indicates that the drive is capable of reading a recorded DVD+R Dual Layer disc that is written according to [DVD+Ref3].</summary>
        [EnumValueDisplayName("DVD+R DL")] [Description(
            "This feature indicates that the drive is capable of reading a recorded DVD+R Dual Layer disc that is written according to [DVD+Ref3]."
            )] DvdPlusRDualLayer = 0x003B, //added
        //0x003C-0x003F reserved
        /// <summary>This feature identifies a drive that is able to read control structures and user data from the BD disc.</summary>
        [EnumValueDisplayName("BD Read")] [Description(
            "This feature identifies a drive that is able to read control structures and user data from the BD disc.")] BDRead = 0x0040, //added
        /// <summary>This feature identifies a drive that is able to write control structures and user data to certain BD discs.</summary>
        [EnumValueDisplayName("BD Write")] [Description(
            "This feature identifies a drive that is able to write control structures and user data to certain BD discs."
            )] BDWrite = 0x0041, //added
        /// <summary>A drive that reports this feature is able to detect and report defective writable units and to manage the defect or not according to instructions from the host.</summary>
        [EnumValueDisplayName("Timely Safe Recording")] [Description(
            "A drive that reports this feature is able to detect and report defective writable units and to manage the defect or not according to instructions from the host."
            )] TimelySafeRecording = 0x0042, //added
        //0x0043-0x004F reserved
        /// <summary>This feature identifies a drive that is able to read HD DVD specific information from the media. This feature indicates support for reading HD DVD specific structures.</summary>
        [EnumValueDisplayName("HD DVD Read")] [Description(
            "This feature identifies a drive that is able to read HD DVD specific information from the media. This feature indicates support for reading HD DVD specific structures."
            )] HDDvdRead = 0x0050, //added
        /// <summary>This feature indicates the ability to write to HD DVD-R/-RW media.</summary>
        [EnumValueDisplayName("HD DVD Write")] [Description("This feature indicates the ability to write to HD DVD-R/-RW media.")] HDDvdWrite = 0x0051, //added
        /// <summary>This feature indicates the ability to perform writing on any part of the data recordable area in multiples of blocking factor. If the currently mounted medium is write protected, this feature is not current. Writing from the host into the media must be in units of blocking. Writing begins and stops at blocking boundaries.</summary>
        [EnumValueDisplayName("HD DVD-RW Fragment Recording")] [Description(
            "This feature indicates the ability to perform writing on any part of the data recordable area in multiples of blocking factor. If the currently mounted medium is write protected, this feature is not current. Writing from the host into the media must be in units of blocking. Writing begins and stops at blocking boundaries."
            )] HDDvdRWFragmentRecording = 0x0052, //added
        //0x0053-0x007F reserved
        /// <summary>This feature is present when the drive is able to access some Hybrid Discs.</summary>
        [EnumValueDisplayName("Hybrid Disc")] [Description("This feature is present when the drive is able to access some Hybrid Discs.")] HybridDisc = 0x0080
        , //added
        //0x0081-0x00FF reserved
        /// <summary>This feature identifies a drive that is able to perform host and drive directed power management.</summary>
        [EnumValueDisplayName("Power Management")] [Description("This feature identifies a drive that is able to perform host and drive directed power management."
            )] PowerManagement = 0x0100,
        /// <summary>The S.M.A.R.T. Feature identifies a drive that is able to perform Self-Monitoring Analysis and Reporting Technology. S.M.A.R.T. was developed to manage the reliability of data storage drives. S.M.A.R.T. Peripheral data storage drives may suffer performance degradation or failure due to a single event or a combination of events. Some events are immediate and catastrophic while others cause a gradual degradation of the drive’s ability to perform. It is possible to predict a portion of the failures, but S.M.A.R.T. is unable to and does not predict all future drive failures.</summary>
        [EnumValueDisplayName("Self Monitoring Analysis and Reporting Technology (SMART)")] [Description(
            "The S.M.A.R.T. Feature identifies a drive that is able to perform Self-Monitoring Analysis and Reporting Technology. S.M.A.R.T. was developed to manage the reliability of data storage drives. S.M.A.R.T. Peripheral data storage drives may suffer performance degradation or failure due to a single event or a combination of events. Some events are immediate and catastrophic while others cause a gradual degradation of the drive’s ability to perform. It is possible to predict a portion of the failures, but S.M.A.R.T. is unable to and does not predict all future drive failures."
            )] SelfMonitoringAnalysisAndReportingTechnology = 0x0101,
        /// <summary>This feature identifies a drive that is able to move media from a storage area to a mechanism and back.</summary>
        [EnumValueDisplayName("Embedded Changer")] [Description(
            "This feature identifies a drive that is able to move media from a storage area to a mechanism and back.")] EmbeddedChanger = 0x0102,
        /// <summary></summary>
        [EnumValueDisplayName("CD Audio External Play")] CDAudioExternalPlay = 0x0103,
        /// <summary>This feature identifies a drive that is able to upgrade its internal microcode via the interface.</summary>
        [EnumValueDisplayName("Microcode Upgrade")] [Description("This feature identifies a drive that is able to upgrade its internal microcode via the interface."
            )] MicrocodeUpgrade = 0x0104,
        /// <summary>This feature identifies a drive that is able to always respond to commands within a set time period. If a command is unable to complete normally within the allotted time, it completes with an error.</summary>
        [EnumValueDisplayName("Timeout")] [Description(
            "This feature identifies a drive that is able to always respond to commands within a set time period. If a command is unable to complete normally within the allotted time, it completes with an error."
            )] Timeout = 0x0105,
        /// <summary>This feature identifies a drive that is able to perform DVD CSS/CPPM authentication and key management. This feature identifies drives that support CSS for DVD-Video and CPPM for DVD-Audio. The drive maintains the integrity of the keys by only using DVD CSS authentication and key management procedures. This feature is current only if a media containing CSS-protected DVD-Video and/or CPPM-protected DVDAudio content is loaded.</summary>
        [EnumValueDisplayName("DVD Content Scrambling System (CSS)")] [Description(
            "This feature identifies a drive that is able to perform DVD CSS/CPPM authentication and key management. This feature identifies drives that support CSS for DVD-Video and CPPM for DVD-Audio. The drive maintains the integrity of the keys by only using DVD CSS authentication and key management procedures. This feature is current only if a media containing CSS-protected DVD-Video and/or CPPM-protected DVDAudio content is loaded."
            )] DvdContentScramblingSystem = 0x0106,
        /// <summary>This feature identifies a drive that is able to perform reading and writing within host specified (and drive verified) performance ranges. This feature also indicates whether the drive supports the Stream playback.</summary>
        [EnumValueDisplayName("Realtime Streaming")] [Description(
            "This feature identifies a drive that is able to perform reading and writing within host specified (and drive verified) performance ranges. This feature also indicates whether the drive supports the Stream playback."
            )] RealTimeStreaming = 0x0107,
        /// <summary>This feature identifies a drive that has a unique serial number. The vendor ID, model ID, and serial number is able to uniquely identify a drive that has this feature.</summary>
        [EnumValueDisplayName("Drive Serial Number")] [Description(
            "This feature identifies a drive that has a unique serial number. The vendor ID, model ID, and serial number is able to uniquely identify a drive that has this feature."
            )] DriveSerialNumber = 0x0108,
        /// <summary>This feature identifies a drive that is capable of reading a media serial number of the currently installed media.</summary>
        [EnumValueDisplayName("Media Serial Number")] [Description(
            "This feature identifies a drive that is capable of reading a media serial number of the currently installed media."
            )] MediaSerialNumber = 0x0109, //added
        /// <summary>This feature identifies a drive that is able to read and/or write DCBs from or to the media.</summary>
        [EnumValueDisplayName("Disc Control Blocks")] DiscControlBlocks = 0x010A,
        /// <summary>This feature identifies a drive that is able to perform DVD CPRM and is able to perform CPRM authentication and key management. This feature is current only if a DVD CPRM recordable or rewritable medium is loaded.</summary>
        [EnumValueDisplayName("DVD Content Protection for Recordable Media (CCPM)")] DvdContentProtectionForRecordableMedia = 0x010B,
        /// <summary>This feature indicates that the drive provides the date and time of the creation of the current firmware revision loaded on the device. The date and time is the date and time of creation of the firmware version. The date and time is GMT. The date and time do not change for a given firmware revision. The date and time is later on “newer” firmware for a given device. This feature is persistent and current if present. No commands are required for this feature.</summary>
        [EnumValueDisplayName("Firmware Information")] FirmwareInformation = 0x010C, //added
        /// <summary>This feature identifies a drive that supports AACS and is able to perform AACS authentication process.</summary>
        [EnumValueDisplayName("Advanced Access Content System (AACS)")] AdvancedAccessContentSystem = 0x010D, //added
        /// <summary>This feature identifies a drive that supports CSS Managed recording on DVDDownload disc. This feature is current only if a recordable DVD-Download disc is loaded.</summary>
        [EnumValueDisplayName("DVD Content Scrambling System (CSS) Managed Recording")] DvdContentScramblingSystemManagedRecording = 0x010E, //added
        //0x010F reserved
        /// <summary>This feature specifies that the drive is able to process disc data structures that are specified in the [VCPS].</summary>
        [EnumValueDisplayName("VCPS")] VCPS = 0x0110, //added
        //0x0111-0x0112 reserved
        /// <summary>This feature identifies a drive that supports SecurDisc content protection and is able to perform SecurDisc authentication process. This feature is current only when an optical disc currently in the drive can be used with SecurDisc. The feature is current regardless of whether an optical disc has already been written to using SecurDisc or not.</summary>
        [EnumValueDisplayName("SecurDisc")] SecurDisc = 0x0113, //added
        //0x0114-0xFEFF reserved
        //0xFF00-0xFFFF Vendor Specific
    }
}