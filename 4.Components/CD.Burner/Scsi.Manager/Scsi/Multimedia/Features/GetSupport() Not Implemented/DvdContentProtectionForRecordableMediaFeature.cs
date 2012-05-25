using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Scsi.Multimedia
{
    /// <summary>This feature identifies a drive that is able to perform DVD CPRM and is able to perform CPRM authentication and key management. This feature is current only if a DVD CPRM recordable or rewritable medium is loaded.</summary>
    [Description(
        "This feature identifies a drive that is able to perform DVD CPRM and is able to perform CPRM authentication and key management.\r\nThis feature is current only if a DVD CPRM recordable or rewritable medium is loaded."
        )]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class DvdContentProtectionForRecordableMediaFeature : MultimediaFeature
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly ScsiCommandCode[]
            __SupportedOperations =
                Sort(new[] {ScsiCommandCode.ReportKey, ScsiCommandCode.SendKey, ScsiCommandCode.ReadDiscStructure});

        public override FeatureSupportKind GetSupport(ScsiCommand command)
        {
            return Array.BinarySearch(__SupportedOperations, command.OpCode) >= 0
                       ? FeatureSupportKind.Mandatory
                       : FeatureSupportKind.None;
        }

        public DvdContentProtectionForRecordableMediaFeature()
            : base(FeatureCode.DvdContentProtectionForRecordableMedia)
        {
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte4;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte5;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte6;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _ContentProtectionForRecordableMediaVersion;

        [DisplayName("Content Protection for Recordable Media Version")]
        public byte ContentProtectionForRecordableMediaVersion
        {
            get { return _ContentProtectionForRecordableMediaVersion; }
            set { _ContentProtectionForRecordableMediaVersion = value; }
        }
    }
}