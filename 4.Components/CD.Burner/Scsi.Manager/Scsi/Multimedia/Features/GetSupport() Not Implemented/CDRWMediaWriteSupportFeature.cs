using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Scsi.Multimedia
{
    /// <summary>This feature identifies a drive that has the ability to perform writing CD-RW media. This feature is not current if CD-RW media is not mounted.</summary>
    [Description(
        "This feature identifies a drive that has the ability to perform writing CD-RW media.\r\nThis feature is not current if CD-RW media is not mounted."
        )]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class CDRWMediaWriteSupportFeature : MultimediaFeature
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly ScsiCommandCode[]
            __SupportedOperations = Sort(new ScsiCommandCode[] {});

        public override FeatureSupportKind GetSupport(ScsiCommand command)
        {
            return Array.BinarySearch(__SupportedOperations, command.OpCode) >= 0
                       ? FeatureSupportKind.Mandatory
                       : FeatureSupportKind.None;
        }

        public CDRWMediaWriteSupportFeature() : base(FeatureCode.CDRWMediaWriteSupport)
        {
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte4;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _MediaSubtypeSupport;

        [DisplayName("Media Sub-type Support")]
        public byte MediaSubtypeSupport
        {
            get { return _MediaSubtypeSupport; }
            set { _MediaSubtypeSupport = value; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte6;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte7;
    }
}