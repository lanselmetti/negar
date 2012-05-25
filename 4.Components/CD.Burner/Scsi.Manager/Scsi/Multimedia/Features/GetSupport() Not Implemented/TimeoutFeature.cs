using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Scsi.Multimedia
{
    /// <summary>This feature identifies a drive that is able to always respond to commands within a set time period. If a command is unable to complete normally within the allotted time, it completes with an error.</summary>
    [Description(
        "This feature identifies a drive that is able to always respond to commands within a set time period.\r\nIf a command is unable to complete normally within the allotted time, it completes with an error."
        )]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class TimeoutFeature : MultimediaFeature
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly ScsiCommandCode[]
            __SupportedOperations = Sort(new ScsiCommandCode[] {});

        public override FeatureSupportKind GetSupport(ScsiCommand command)
        {
            return Array.BinarySearch(__SupportedOperations, command.OpCode) >= 0
                       ? FeatureSupportKind.Mandatory
                       : FeatureSupportKind.None;
        }

        public TimeoutFeature() : base(FeatureCode.Timeout)
        {
        }
    }
}