using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Scsi.Multimedia
{
    /// <summary></summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class SectorErasableFeature : MultimediaFeature
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly ScsiCommandCode[]
            __SupportedOperations = Sort(new ScsiCommandCode[] {});

        public override FeatureSupportKind GetSupport(ScsiCommand command)
        {
            return Array.BinarySearch(__SupportedOperations, command.OpCode) >= 0
                       ? FeatureSupportKind.Mandatory
                       : FeatureSupportKind.None;
        }

        public SectorErasableFeature() : base(FeatureCode.SectorErasable)
        {
        }
    }
}