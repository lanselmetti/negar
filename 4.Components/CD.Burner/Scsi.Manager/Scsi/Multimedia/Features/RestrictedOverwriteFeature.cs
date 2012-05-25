using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Scsi.Multimedia
{
    /// <summary>This feature identifies a drive that has the ability to overwrite logical blocks only in fixed sets at a time.</summary>
    [Description(
        "This feature identifies a drive that has the ability to overwrite logical blocks only in fixed sets at a time."
        )]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class RestrictedOverwriteFeature : MultimediaFeature
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

        public RestrictedOverwriteFeature() : base(FeatureCode.RestrictedOverwrite)
        {
        }
    }
}