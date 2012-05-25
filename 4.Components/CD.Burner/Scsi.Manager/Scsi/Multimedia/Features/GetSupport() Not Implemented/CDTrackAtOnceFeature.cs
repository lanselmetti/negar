using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    /// <summary>This feature identifies a drive that is able to write data to a CD track.</summary>
    [Description("This feature identifies a drive that is able to write data to a CD track.")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class CDTrackAtOnceFeature : MultimediaFeature
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly ScsiCommandCode[]
            __SupportedOperations =
                Sort(new[]
                         {
                             ScsiCommandCode.Blank, ScsiCommandCode.CloseSessionOrTrack,
                             ScsiCommandCode.ReadDiscInformation, ScsiCommandCode.ReadTrackInformation,
                             ScsiCommandCode.ReserveTrack, ScsiCommandCode.SendOpcInformation,
                             ScsiCommandCode.SynchronizeCache10, ScsiCommandCode.Write10
                         });

        public override FeatureSupportKind GetSupport(ScsiCommand command)
        {
            return Array.BinarySearch(__SupportedOperations, command.OpCode) >= 0
                       ? FeatureSupportKind.Mandatory
                       : FeatureSupportKind.None;
        }

        public CDTrackAtOnceFeature() : base(FeatureCode.CDTrackAtOnce)
        {
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte4;

        [DisplayName("Buffer Under-run Protection")]
        public bool BufferUnderrunProtection
        {
            get { return Bits.GetBit(byte4, 6); }
            set { byte4 = Bits.SetBit(byte4, 6, value); }
        }

        [DisplayName("R-W Subcode in RAW Mode")]
        public bool RWRaw
        {
            get { return Bits.GetBit(byte4, 4); }
            set { byte4 = Bits.SetBit(byte4, 4, value); }
        }

        [DisplayName("R-W Subcode in Packed Mode")]
        public bool RWPack
        {
            get { return Bits.GetBit(byte4, 3); }
            set { byte4 = Bits.SetBit(byte4, 3, value); }
        }

        [DisplayName("Simulation")]
        public bool TestWrite
        {
            get { return Bits.GetBit(byte4, 2); }
            set { byte4 = Bits.SetBit(byte4, 2, value); }
        }

        [DisplayName("Overwrite Track at Once")]
        public bool CDRW
        {
            get { return Bits.GetBit(byte4, 1); }
            set { byte4 = Bits.SetBit(byte4, 1, value); }
        }

        [DisplayName("R-W Subcode")]
        public bool RWSubCode
        {
            get { return Bits.GetBit(byte4, 0); }
            set { byte4 = Bits.SetBit(byte4, 0, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte5;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private DataBlockTypesSupported _DataBlockTypesSupported;

        [DisplayName("Data Types Supported")]
        public DataBlockTypesSupported DataBlockTypesSupported
        {
            get { return Bits.BigEndian(_DataBlockTypesSupported); }
            set { _DataBlockTypesSupported = Bits.BigEndian(value); }
        }
    }
}