using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    /// <summary>This feature indicates that the drive is capable of reading a recorded DVD+R disc that is written according to [DVD+Ref1]. Specifically, this includes the capability of reading DCBs.</summary>
    [Description(
        "This feature indicates that the drive is capable of reading a recorded DVD+R disc that is written according to [DVD+Ref1].\r\nSpecifically, this includes the capability of reading DCBs."
        )]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class DvdPlusRFeature : MultimediaFeature
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly ScsiCommandCode[]
            __SupportedOperations =
                Sort(new[]
                         {
                             ScsiCommandCode.CloseSessionOrTrack, ScsiCommandCode.ReadDiscInformation,
                             ScsiCommandCode.ReadDiscStructure, ScsiCommandCode.ReadTocPmaAtip,
                             ScsiCommandCode.ReadTrackInformation, ScsiCommandCode.ReserveTrack,
                             ScsiCommandCode.SendDiscStructure, ScsiCommandCode.SynchronizeCache10, ScsiCommandCode.Write10
                             , ScsiCommandCode.Write12
                         });

        public override FeatureSupportKind GetSupport(ScsiCommand command)
        {
            return Array.BinarySearch(__SupportedOperations, command.OpCode) >= 0
                   &&
                   (command.OpCode != ScsiCommandCode.ReadDiscStructure ||
                    (((ReadDiscStructureCommand) command).Format == 0 ||
                     ((ReadDiscStructureCommand) command).Format == 1 ||
                     ((ReadDiscStructureCommand) command).Format == 3 ||
                     ((ReadDiscStructureCommand) command).Format == 4 ||
                     ((ReadDiscStructureCommand) command).Format == 5 ||
                     ((ReadDiscStructureCommand) command).Format == 0x30 ||
                     ((ReadDiscStructureCommand) command).Format == 0xFF))
                   &&
                   (command.OpCode != ScsiCommandCode.SendDiscStructure || true
                   /*TODO: Implement feature support for SendDiscStructure*/)
                       ? FeatureSupportKind.Mandatory
                       : FeatureSupportKind.None;
        }

        public DvdPlusRFeature() : base(FeatureCode.DvdPlusR)
        {
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte4;

        [DisplayName("Write DVD+R")]
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