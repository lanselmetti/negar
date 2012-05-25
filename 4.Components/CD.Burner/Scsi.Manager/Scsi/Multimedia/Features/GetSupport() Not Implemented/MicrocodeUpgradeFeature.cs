using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Scsi.Multimedia
{
    /// <summary>This feature identifies a drive that is able to upgrade its internal microcode via the interface.</summary>
    [Description("This feature identifies a drive that is able to upgrade its internal microcode via the interface.")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class MicrocodeUpgradeFeature : MultimediaFeature
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly ScsiCommandCode[]
            __SupportedOperations = Sort(new[] {ScsiCommandCode.ReadBuffer, ScsiCommandCode.WriteBuffer});

        public override FeatureSupportKind GetSupport(ScsiCommand command)
        {
            return Array.BinarySearch(__SupportedOperations, command.OpCode) >= 0
                       ? FeatureSupportKind.Mandatory
                       : FeatureSupportKind.None;
        }

        public MicrocodeUpgradeFeature() : base(FeatureCode.MicrocodeUpgrade)
        {
        }
    }
}