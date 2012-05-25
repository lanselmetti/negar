using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    /// <summary>This feature indicates that the drive is capable of reading a recorded DVD+RW disc that is formatted according to [DVD+Ref2].</summary>
    [Description(
        "This feature indicates that the drive is capable of reading a recorded DVD+RW disc that is formatted according to [DVD+Ref2]."
        )]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class DvdPlusRWFeature : MultimediaFeature
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly ScsiCommandCode[]
            __SupportedOperations =
                Sort(new[]
                         {
                             ScsiCommandCode.CloseSessionOrTrack, ScsiCommandCode.Format, ScsiCommandCode.ReadDiscStructure
                             , ScsiCommandCode.ReadTocPmaAtip, ScsiCommandCode.SendDiscStructure, ScsiCommandCode.Write10,
                             ScsiCommandCode.Write12, ScsiCommandCode.WriteAndVerify10
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

        public DvdPlusRWFeature() : base(FeatureCode.DvdPlusRW)
        {
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte4;

        [DisplayName("Write and Background Format DVD+RW")]
        public bool Write
        {
            get { return Bits.GetBit(byte4, 0); }
            set { byte4 = Bits.SetBit(byte4, 0, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte5;

        [DisplayName("Quick Start Format")]
        public bool QuickStartFormat
        {
            get { return Bits.GetBit(byte5, 1); }
            set { byte5 = Bits.SetBit(byte5, 1, value); }
        }

        [DisplayName("Close Only")]
        public bool CloseOnly
        {
            get { return Bits.GetBit(byte5, 0); }
            set { byte5 = Bits.SetBit(byte5, 0, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte6;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte7;
    }
}