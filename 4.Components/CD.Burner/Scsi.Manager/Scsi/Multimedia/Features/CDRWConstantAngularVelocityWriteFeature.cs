using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Scsi.Multimedia
{
    /// <summary>This feature identifies a drive that has the ability to write CD-RW media that is designed for constant angular velocity recording. The drive conforms to the Orange Book Part 3 Volume 2 specification. This feature is not current if high-speed recordable CD-RW media is not mounted.</summary>
    [Description(
        "This feature identifies a drive that has the ability to write CD-RW media that is designed for constant angular velocity recording.\r\nThe drive conforms to the Orange Book Part 3 Volume 2 specification.\r\nThis feature is not current if high-speed recordable CD-RW media is not mounted."
        )]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class CDRWConstantAngularVelocityWriteFeature : MultimediaFeature
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly ScsiCommandCode[]
            __SupportedOperations =
                Sort(new[]
                         {
                             ScsiCommandCode.ReadCapacity, ScsiCommandCode.ReadDiscInformation,
                             ScsiCommandCode.ReadTrackInformation, ScsiCommandCode.SynchronizeCache10,
                             ScsiCommandCode.Write10
                         });

        public override FeatureSupportKind GetSupport(ScsiCommand command)
        {
            return Array.BinarySearch(__SupportedOperations, command.OpCode) >= 0
                       ? FeatureSupportKind.Mandatory
                       : FeatureSupportKind.None;
        }

        public CDRWConstantAngularVelocityWriteFeature() : base(FeatureCode.CDRWConstantAngularVelocityWrite)
        {
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte4;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte5;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte6;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte7;
    }
}