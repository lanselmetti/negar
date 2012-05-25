using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    /// <summary>This feature identifies a drive that has the ability to perform media certification and RECOVERED ERROR reporting for drive assisted software defect management. In case of Persistent-DM mode, the <see cref="Read12Command"/> command with Streaming bit = 1 may be performed without medium certification. When this feature is current, the <see cref="DefectManagementFeature"/> is not current. This feature may be current when Restricted Overwrite formatted media or Rigid Restricted Overwrite formatted media is present.</summary>
    [Description(
        "This feature identifies a drive that has the ability to perform media certification and RECOVERED ERROR reporting for drive assisted software defect management.\r\nIn case of Persistent-DM mode, the Read12Command command with Streaming bit = 1 may be performed without medium certification.\r\nWhen this feature is current, the DefectManagementFeature is not current.\r\nThis feature may be current when Restricted Overwrite formatted media or Rigid Restricted Overwrite formatted media is present."
        )]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class EnhancedDefectReportingFeature : MultimediaFeature
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly ScsiCommandCode[]
            __SupportedOperations =
                Sort(new[]
                         {
                             ScsiCommandCode.GetPerformance, ScsiCommandCode.Read10, ScsiCommandCode.Read12,
                             ScsiCommandCode.ReadDiscInformation, ScsiCommandCode.Write10, ScsiCommandCode.Write12,
                             ScsiCommandCode.Verify10, ScsiCommandCode.WriteAndVerify10, ScsiCommandCode.SynchronizeCache10
                             , ScsiCommandCode.SetStreaming
                         });

        public override FeatureSupportKind GetSupport(ScsiCommand command)
        {
            return Array.BinarySearch(__SupportedOperations, command.OpCode) >= 0
                   &&
                   (command.OpCode != ScsiCommandCode.GetPerformance ||
                    (((GetPerformanceCommand) command).PerformanceType == PerformanceType.DefectiveBlockInformation))
                   && (command.OpCode != ScsiCommandCode.Read12 || (DRTDM == ((Read12Command) command).Streaming))
                   && (command.OpCode != ScsiCommandCode.Write12 || (DRTDM == ((Write12Command) command).Streaming))
                       ? FeatureSupportKind.Mandatory
                       : FeatureSupportKind.None;
        }

        public EnhancedDefectReportingFeature() : base(FeatureCode.EnhancedDefectReporting)
        {
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte4;

        [DisplayName("DRT-DM")]
        public bool DRTDM
        {
            get { return Bits.GetBit(byte4, 0); }
            set { byte4 = Bits.SetBit(byte4, 0, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _NumberOfDefectiveBlockInformationCacheZones;

        [DisplayName("Defective Block Information Cache Zones")]
        public byte NumberOfDefectiveBlockInformationCacheZones
        {
            get { return _NumberOfDefectiveBlockInformationCacheZones; }
            set { _NumberOfDefectiveBlockInformationCacheZones = value; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ushort _NumberOfEntries;

        [DisplayName("Entry Count")]
        public ushort NumberOfEntries
        {
            get { return Bits.BigEndian(_NumberOfEntries); }
            set { _NumberOfEntries = Bits.BigEndian(value); }
        }
    }
}