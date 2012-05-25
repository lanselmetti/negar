using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Scsi.Multimedia
{
    /// <summary>This feature identifies a drive that is able to format media into logical blocks.</summary>
    [Description("This feature identifies a drive that is able to format media into logical blocks.")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class FormattableFeature : MultimediaFeature
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly ScsiCommandCode[]
            __SupportedOperations =
                Sort(new[]
                         {
                             ScsiCommandCode.Format, ScsiCommandCode.ReadFormatCapacities, ScsiCommandCode.RequestSense,
                             ScsiCommandCode.Verify10
                         });

        public override FeatureSupportKind GetSupport(ScsiCommand command)
        {
            return Array.BinarySearch(__SupportedOperations, command.OpCode) >= 0
                       ? FeatureSupportKind.Mandatory
                       : FeatureSupportKind.None;
        }

        public FormattableFeature() : base(FeatureCode.Formattable)
        {
        }
    }
}