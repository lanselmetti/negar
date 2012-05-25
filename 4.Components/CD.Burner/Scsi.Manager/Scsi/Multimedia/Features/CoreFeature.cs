using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    /// <summary>This feature identifies a drive that supports functionality common to all devices.</summary>
    [Description("This feature identifies a drive that supports functionality common to all devices.")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class CoreFeature : MultimediaFeature
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly ScsiCommandCode[]
            __SupportedOperations =
                Sort(new[]
                         {
                             ScsiCommandCode.GetConfiguration, ScsiCommandCode.GetEventStatusNotification,
                             ScsiCommandCode.Inquiry, ScsiCommandCode.ModeSelect10, ScsiCommandCode.ModeSense10,
                             ScsiCommandCode.RequestSense, ScsiCommandCode.TestUnitReady
                         });

        public override FeatureSupportKind GetSupport(ScsiCommand command)
        {
            return Array.BinarySearch(__SupportedOperations, command.OpCode) >= 0
                       ? FeatureSupportKind.Mandatory
                       : FeatureSupportKind.None;
        }


        public CoreFeature() : base(FeatureCode.Core)
        {
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private PhysicalInterfaceStandard _PhysicalInterfaceStandard;

        [DisplayName("Physical Interface Standard")]
        public PhysicalInterfaceStandard PhysicalInterfaceStandard
        {
            get { return Bits.BigEndian(_PhysicalInterfaceStandard); }
            set { _PhysicalInterfaceStandard = Bits.BigEndian(value); }
        }
    }
}