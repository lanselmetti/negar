using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    /// <summary>This feature indicates that the drive is capable of reading a recorded DVD+R Dual Layer disc that is written according to [DVD+Ref3].</summary>
    [Description(
        "This feature indicates that the drive is capable of reading a recorded DVD+R Dual Layer disc that is written according to [DVD+Ref3]."
        )]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class DvdPlusRDualLayerFeature : MultimediaFeature
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly ScsiCommandCode[]
            __SupportedOperations =
                Sort(new[]
                         {
                             ScsiCommandCode.CloseSessionOrTrack, ScsiCommandCode.Read10, ScsiCommandCode.Write12,
                             ScsiCommandCode.ReadDiscInformation, ScsiCommandCode.ReadDiscStructure,
                             ScsiCommandCode.ReadTrackInformation, ScsiCommandCode.ReserveTrack,
                             ScsiCommandCode.SendDiscStructure, ScsiCommandCode.SendOpcInformation,
                             ScsiCommandCode.SynchronizeCache10, ScsiCommandCode.Write10, ScsiCommandCode.Write12
                         });

        public override FeatureSupportKind GetSupport(ScsiCommand command)
        {
            return Array.BinarySearch(__SupportedOperations, command.OpCode) >= 0
                       ? FeatureSupportKind.Mandatory
                       : FeatureSupportKind.None;
        }

        public DvdPlusRDualLayerFeature() : base(FeatureCode.DvdPlusRDualLayer)
        {
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte4;

        [DisplayName("Write DVD+R DL")]
        public bool Write
        {
            get { return Bits.GetBit(byte4, 0); }
            set { byte4 = Bits.SetBit(byte4, 0, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte5;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte6;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte7;
    }
}