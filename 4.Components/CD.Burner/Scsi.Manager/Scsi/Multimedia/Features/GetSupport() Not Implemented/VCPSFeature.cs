using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Scsi.Multimedia
{
    /// <summary>This feature specifies that the drive is able to process disc data structures that are specified in the [VCPS].</summary>
    [Description(
        "This feature specifies that the drive is able to process disc data structures that are specified in the [VCPS]."
        )]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class VCPSFeature : MultimediaFeature
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly ScsiCommandCode[]
            __SupportedOperations = Sort(new[] {ScsiCommandCode.ReportKey, ScsiCommandCode.SendKey});

        public override FeatureSupportKind GetSupport(ScsiCommand command)
        {
            return Array.BinarySearch(__SupportedOperations, command.OpCode) >= 0
                       ? FeatureSupportKind.Mandatory
                       : FeatureSupportKind.None;
        }

        public VCPSFeature() : base(FeatureCode.VCPS)
        {
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte4;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte5;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte6;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte7;
    }
}