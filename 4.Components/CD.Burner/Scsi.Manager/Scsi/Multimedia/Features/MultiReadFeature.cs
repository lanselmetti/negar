using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Scsi.Multimedia
{
    /// <summary>The drive conforms to the OSTA Multi-Read specification 1.00, with the exception of CD play capability (the <see cref="CDAudioExternalPlayFeature"/> is not required).</summary>
    [Description(
        "The drive conforms to the OSTA Multi-Read specification 1.00, with the exception of CD play capability (the CDAudioExternalPlayFeature is not required)."
        )]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class MultiReadFeature : MultimediaFeature
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly ScsiCommandCode[]
            __SupportedOperations =
                Sort(new[]
                         {
                             ScsiCommandCode.Read10, ScsiCommandCode.ReadCD, ScsiCommandCode.ReadDiscInformation,
                             ScsiCommandCode.ReadTrackInformation
                         });

        public override FeatureSupportKind GetSupport(ScsiCommand command)
        {
            return Array.BinarySearch(__SupportedOperations, command.OpCode) >= 0
                       ? FeatureSupportKind.Mandatory
                       : FeatureSupportKind.None;
        }

        public MultiReadFeature() : base(FeatureCode.MultiRead)
        {
        }
    }
}