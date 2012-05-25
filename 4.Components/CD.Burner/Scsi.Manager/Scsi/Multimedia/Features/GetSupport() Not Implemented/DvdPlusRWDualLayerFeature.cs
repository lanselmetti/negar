using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    /// <summary>This feature indicates that the drive is capable of reading a recorded DVD+RW DL disc that is formatted according to [DVD+Ref4]. Specifically, this includes the capability of reading DCBs.</summary>
    [Description(
        "This feature indicates that the drive is capable of reading a recorded DVD+RW DL disc that is formatted according to [DVD+Ref4].\r\nSpecifically, this includes the capability of reading DCBs."
        )]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class DvdPlusRWDualLayerFeature : MultimediaFeature
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly ScsiCommandCode[]
            __SupportedOperations =
                Sort(new[]
                         {
                             ScsiCommandCode.CloseSessionOrTrack, ScsiCommandCode.Format, ScsiCommandCode.Read10,
                             ScsiCommandCode.Read12, ScsiCommandCode.ReadDiscStructure, ScsiCommandCode.SendOpcInformation,
                             ScsiCommandCode.SynchronizeCache10, ScsiCommandCode.Write10, ScsiCommandCode.Write12,
                             ScsiCommandCode.WriteAndVerify10
                         });

        public override FeatureSupportKind GetSupport(ScsiCommand command)
        {
            return Array.BinarySearch(__SupportedOperations, command.OpCode) >= 0
                       ? FeatureSupportKind.Mandatory
                       : FeatureSupportKind.None;
        }

        public DvdPlusRWDualLayerFeature() : base(FeatureCode.DvdPlusRWDualLayer)
        {
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte4;

        [DisplayName("Write and Background Format DVD+RW DL")]
        public bool Write
        {
            get { return Bits.GetBit(byte4, 0); }
            set { byte4 = Bits.SetBit(byte4, 0, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte5;

        [DisplayName("Quick Start Format")]
        public bool QuickStart
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