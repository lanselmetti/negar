using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Scsi.Multimedia
{
    /// <summary>This feature identifies a drive that GetSupport SecurDisc content protection and is able to perform SecurDisc authentication process. This feature is current only when an optical disc currently in the drive can be used with SecurDisc. The feature is current regardless of whether an optical disc has already been written to using SecurDisc or not.</summary>
    [Description(
        "This feature identifies a drive that GetSupport SecurDisc content protection and is able to perform SecurDisc authentication process.\r\nThis feature is current only when an optical disc currently in the drive can be used with SecurDisc.\r\nThe feature is current regardless of whether an optical disc has already been written to using SecurDisc or not."
        )]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class SecurDiscFeature : MultimediaFeature
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly ScsiCommandCode[]
            __SupportedOperations = Sort(new[] {ScsiCommandCode.ReportKey, ScsiCommandCode.SendKey});

        public override FeatureSupportKind GetSupport(ScsiCommand command)
        {
            return Array.BinarySearch(__SupportedOperations, command.OpCode) >= 0
                       ? FeatureSupportKind.Mandatory
                       : FeatureSupportKind.None;
        }

        public SecurDiscFeature() : base(FeatureCode.SecurDisc)
        {
        }
    }
}