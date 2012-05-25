using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    /// <summary>This feature is present when the drive is able to access some Hybrid Discs.</summary>
    [Description("This feature is present when the drive is able to access some Hybrid Discs.")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class HybridDiscFeature : MultimediaFeature
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly ScsiCommandCode[]
            __SupportedOperations = Sort(new[] {ScsiCommandCode.ReadDiscStructure, ScsiCommandCode.StartStopUnit});

        public override FeatureSupportKind GetSupport(ScsiCommand command)
        {
            return Array.BinarySearch(__SupportedOperations, command.OpCode) >= 0
                       ? FeatureSupportKind.Mandatory
                       : FeatureSupportKind.None;
        }

        public HybridDiscFeature() : base(FeatureCode.HybridDisc)
        {
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte4;

        [DisplayName("Format Layer Selection Persistent")]
        public bool ResetImmunity
        {
            get { return Bits.GetBit(byte4, 0); }
            set { byte4 = Bits.SetBit(byte4, 0, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte5;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte6;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte7;
    }
}