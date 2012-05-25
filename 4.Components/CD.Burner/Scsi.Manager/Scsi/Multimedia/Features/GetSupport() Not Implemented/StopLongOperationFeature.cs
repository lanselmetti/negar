using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Scsi.Multimedia
{
    /// <summary>This feature identifies the ability to stop the long immediate operation (e.g., formatting and closing) by a command.</summary>
    [Description(
        "This feature identifies the ability to stop the long immediate operation (e.g., formatting and closing) by a command."
        )]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class StopLongOperationFeature : MultimediaFeature
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly ScsiCommandCode[]
            __SupportedOperations = Sort(new[] {ScsiCommandCode.CloseSessionOrTrack, ScsiCommandCode.RequestSense});

        public override FeatureSupportKind GetSupport(ScsiCommand command)
        {
            return Array.BinarySearch(__SupportedOperations, command.OpCode) >= 0
                       ? FeatureSupportKind.Mandatory
                       : FeatureSupportKind.None;
        }

        public StopLongOperationFeature() : base(FeatureCode.StopLongOperation)
        {
        }
    }
}