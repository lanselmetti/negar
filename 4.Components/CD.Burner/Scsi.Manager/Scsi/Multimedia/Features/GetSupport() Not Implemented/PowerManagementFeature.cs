using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Scsi.Multimedia
{
    /// <summary>This feature identifies a drive that is able to perform host and drive directed power management.</summary>
    [Description("This feature identifies a drive that is able to perform host and drive directed power management.")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class PowerManagementFeature : MultimediaFeature
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly ScsiCommandCode[]
            __SupportedOperations =
                Sort(new[] {ScsiCommandCode.GetEventStatusNotification, ScsiCommandCode.StartStopUnit});

        public override FeatureSupportKind GetSupport(ScsiCommand command)
        {
            return Array.BinarySearch(__SupportedOperations, command.OpCode) >= 0
                       ? FeatureSupportKind.Mandatory
                       : FeatureSupportKind.None;
        }

        public PowerManagementFeature() : base(FeatureCode.PowerManagement)
        {
        }
    }
}