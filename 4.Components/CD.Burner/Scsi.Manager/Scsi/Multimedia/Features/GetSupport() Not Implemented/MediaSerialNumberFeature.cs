using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Scsi.Multimedia
{
    /// <summary>This feature identifies a drive that is capable of reading a media serial number of the currently installed media.</summary>
    [Description(
        "This feature identifies a drive that is capable of reading a media serial number of the currently installed media."
        )]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class MediaSerialNumberFeature : MultimediaFeature
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly ScsiCommandCode[]
            __SupportedOperations = Sort(new ScsiCommandCode[] {/*ScsiCommandCode.ReadMediaSerialNumber*/});

        public override FeatureSupportKind GetSupport(ScsiCommand command)
        {
            return Array.BinarySearch(__SupportedOperations, command.OpCode) >= 0
                       ? FeatureSupportKind.Mandatory
                       : FeatureSupportKind.None;
        }

        public MediaSerialNumberFeature() : base(FeatureCode.MediaSerialNumber)
        {
        }
    }
}