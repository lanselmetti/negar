using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    /// <summary>This feature identifies a drive that has the ability to perform writing only on blocking boundaries. This feature is different from the <see cref="RestrictedOverwriteFeature"/> feature because each write command is also required to end on a blocking boundary. This feature replaces the <see cref="RandomWritableFeature"/> for drives that do not perform readmodify- write operations on write requests smaller than blocking. This feature may be present when DVD-RW Restricted Over Writable media is loaded. Drives with write protected media do not have this feature current. This feature is not current if the <see cref="RandomWritableFeature"/> is current. If this feature is current, the <see cref="RandomWritableFeature"/> feature is not current.</summary>
    [Description(
        "This feature identifies a drive that has the ability to perform writing only on blocking boundaries.\r\nThis feature is different from the RestrictedOverwriteFeature feature because each write command is also required to end on a blocking boundary.\r\nThis feature replaces the RandomWritableFeature for drives that do not perform readmodify- write operations on write requests smaller than blocking.\r\nThis feature may be present when DVD-RW Restricted Over Writable media is loaded.\r\nDrives with write protected media do not have this feature current.\r\nThis feature is not current if the RandomWritableFeature is current.\r\nIf this feature is current, the RandomWritableFeature feature is not current."
        )]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class RigidRestrictedOverwriteFeature : MultimediaFeature
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly ScsiCommandCode[]
            __SupportedOperations =
                Sort(new[]
                         {
                             ScsiCommandCode.Blank, ScsiCommandCode.GetPerformance, ScsiCommandCode.ReadDiscInformation,
                             ScsiCommandCode.ReadTrackInformation, ScsiCommandCode.ReadCapacity,
                             ScsiCommandCode.SynchronizeCache10, ScsiCommandCode.Verify10, ScsiCommandCode.Write10
                         });

        public override FeatureSupportKind GetSupport(ScsiCommand command)
        {
            return Array.BinarySearch(__SupportedOperations, command.OpCode) >= 0
                       ? FeatureSupportKind.Mandatory
                       : FeatureSupportKind.None;
        }

        public RigidRestrictedOverwriteFeature() : base(FeatureCode.RigidRestrictedOverwrite)
        {
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte4;

        [DisplayName("Generate Defect Status Data While Formatting")]
        public bool DefectStatusDataGenerate
        {
            get { return Bits.GetBit(byte4, 3); }
            set { byte4 = Bits.SetBit(byte4, 3, value); }
        }

        [DisplayName("Read Defect Status Data")]
        public bool DefectStatusDataRead
        {
            get { return Bits.GetBit(byte4, 2); }
            set { byte4 = Bits.SetBit(byte4, 2, value); }
        }

        [DisplayName("Quick Format and Write in Intermediate State Session")]
        public bool Intermediate
        {
            get { return Bits.GetBit(byte4, 1); }
            set { byte4 = Bits.SetBit(byte4, 1, value); }
        }

        [DisplayName("Blank")]
        public bool Blank
        {
            get { return Bits.GetBit(byte4, 0); }
            set { byte4 = Bits.SetBit(byte4, 0, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte5;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte6;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte7;
    }
}