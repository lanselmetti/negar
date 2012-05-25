using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    /// <summary>This feature identifies a drive that has defect management available to provide a defect-free contiguous address space.</summary>
    [Description(
        "This feature identifies a drive that has defect management available to provide a defect-free contiguous address space."
        )]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class DefectManagementFeature : MultimediaFeature
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly ScsiCommandCode[]
            __SupportedOperations = Sort(new[] {ScsiCommandCode.ReadDiscStructure});

        public override FeatureSupportKind GetSupport(ScsiCommand command)
        {
            return Array.BinarySearch(__SupportedOperations, command.OpCode) >= 0
                   &&
                   (command.OpCode != ScsiCommandCode.ReadDiscStructure ||
                    (!SpareAreaInformation || ((ReadDiscStructureCommand) command).Format == 0x0A))
                       ? FeatureSupportKind.Mandatory
                       : FeatureSupportKind.None;
        }

        public DefectManagementFeature() : base(FeatureCode.DefectManagement)
        {
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte4;

        [DisplayName("Spare Area Information")]
        public bool SpareAreaInformation
        {
            get { return Bits.GetBit(byte4, 7); }
            set { byte4 = Bits.SetBit(byte4, 7, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte5;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte6;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte7;
    }
}