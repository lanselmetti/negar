using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Scsi.Multimedia
{
    /// <summary>This feature identifies a drive that is able to read DVD specific information from the media.</summary>
    [Description("This feature identifies a drive that is able to read DVD specific information from the media.")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class DvdReadFeature : MultimediaFeature
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly ScsiCommandCode[]
            __SupportedOperations =
                Sort(new[]
                         {
                             ScsiCommandCode.Read10, ScsiCommandCode.Read12, ScsiCommandCode.ReadDiscStructure,
                             ScsiCommandCode.ReadTocPmaAtip
                         });

        public override FeatureSupportKind GetSupport(ScsiCommand command)
        {
            return Array.BinarySearch(__SupportedOperations, command.OpCode) >= 0
                   && (command.OpCode != ScsiCommandCode.ReadDiscStructure
                       ||
                       (((ReadDiscStructureCommand) command).Format == 0 ||
                        ((ReadDiscStructureCommand) command).Format == 1 ||
                        ((ReadDiscStructureCommand) command).Format == 3 ||
                        ((ReadDiscStructureCommand) command).Format == 4))
                   &&
                   (command.OpCode != ScsiCommandCode.ReadTocPmaAtip ||
                    (((ReadTocPmaAtipCommand) command).Format == ReadTocPmaAtipDataFormat.FormattedTableOfContents ||
                     ((ReadTocPmaAtipCommand) command).Format == ReadTocPmaAtipDataFormat.MultisessionInformation))
                       ? FeatureSupportKind.Mandatory
                       : FeatureSupportKind.None;
        }

        public DvdReadFeature() : base(FeatureCode.DvdRead)
        {
        }
    }
}