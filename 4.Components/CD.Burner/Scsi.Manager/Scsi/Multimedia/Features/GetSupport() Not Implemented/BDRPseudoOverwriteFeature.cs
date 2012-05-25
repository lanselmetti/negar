using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Scsi.Multimedia
{
    /// <summary>A drive that reports the feature is able to provide logical block overwrite service on BD-R discs that are formatted as SRM+POW.</summary>
    [Description(
        "A drive that reports the feature is able to provide logical block overwrite service on BD-R discs that are formatted as SRM+POW."
        )]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class BDRPseudoOverwriteFeature : MultimediaFeature
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly ScsiCommandCode[]
            __SupportedOperations = Sort(new[] {ScsiCommandCode.ReadDiscInformation, ScsiCommandCode.ReserveTrack});

        public override FeatureSupportKind GetSupport(ScsiCommand command)
        {
            return Array.BinarySearch(__SupportedOperations, command.OpCode) >= 0
                       ? FeatureSupportKind.Mandatory
                       : FeatureSupportKind.None;
        }

        public BDRPseudoOverwriteFeature() : base(FeatureCode.BDRPseudoOverwrite)
        {
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte4;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte5;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte6;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte7;
    } //Good model
}