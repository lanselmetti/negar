using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    /// <summary>The S.M.A.R.T. Feature identifies a drive that is able to perform Self-Monitoring Analysis and Reporting Technology. S.M.A.R.T. was developed to manage the reliability of data storage drives. S.M.A.R.T. Peripheral data storage drives may suffer performance degradation or failure due to a single event or a combination of events. Some events are immediate and catastrophic while others cause a gradual degradation of the drive’s ability to perform. It is possible to predict a portion of the failures, but S.M.A.R.T. is unable to and does not predict all future drive failures.</summary>
    [Description(
        "The S.M.A.R.T. Feature identifies a drive that is able to perform Self-Monitoring Analysis and Reporting Technology.\r\nS.M.A.R.T. was developed to manage the reliability of data storage drives.\r\nS.M.A.R.T. Peripheral data storage drives may suffer performance degradation or failure due to a single event or a combination of events.\r\nSome events are immediate and catastrophic while others cause a gradual degradation of the drive’s ability to perform.\r\nIt is possible to predict a portion of the failures, but S.M.A.R.T. is unable to and does not predict all future drive failures."
        )]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class SmartFeature : MultimediaFeature
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly ScsiCommandCode[]
            __SupportedOperations = Sort(new ScsiCommandCode[] {});

        public override FeatureSupportKind GetSupport(ScsiCommand command)
        {
            return Array.BinarySearch(__SupportedOperations, command.OpCode) >= 0
                       ? FeatureSupportKind.Mandatory
                       : FeatureSupportKind.None;
        }

        public SmartFeature() : base(FeatureCode.SelfMonitoringAnalysisAndReportingTechnology)
        {
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte4;

        [DisplayName("Read/Write Error Recovery Page Present")]
        public bool PagePresent
        {
            get { return Bits.GetBit(byte4, 0); }
            set { byte4 = Bits.SetBit(byte4, 0, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte5;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte6;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte7;
    }
}