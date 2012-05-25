using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    /// <summary>This feature identifies a drive that GetSupport AACS and is able to perform AACS authentication process.</summary>
    [Description(
        "This feature identifies a drive that GetSupport AACS and is able to perform AACS authentication process.")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class AdvancedAccessContentSystemFeature : MultimediaFeature
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte NUMBER_OF_AuthenticationGrantIdS_MASK =
            0x0F;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly ScsiCommandCode[]
            __SupportedOperations =
                Sort(new[] {ScsiCommandCode.ReportKey, ScsiCommandCode.SendKey, ScsiCommandCode.ReadDiscStructure});

        public override FeatureSupportKind GetSupport(ScsiCommand command)
        {
            return Array.BinarySearch(__SupportedOperations, command.OpCode) >= 0
                       ? FeatureSupportKind.Mandatory
                       : FeatureSupportKind.None;
        }

        public AdvancedAccessContentSystemFeature() : base(FeatureCode.AdvancedAccessContentSystem)
        {
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte4;

        [DisplayName("Binding Nonce")]
        public bool BindingNonce
        {
            get { return Bits.GetBit(byte4, 0); }
            set { byte4 = Bits.SetBit(byte4, 0, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _BindingNonceBlockCount;

        [DisplayName("Binding Nonce Block Count")]
        public byte BindingNonceBlockCount
        {
            get { return _BindingNonceBlockCount; }
            set { _BindingNonceBlockCount = value; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte6;

        [DisplayName("Authentication Grant ID Count")]
        public byte AuthenticationGrantIdCount
        {
            get { return Bits.GetValueMask(byte6, 0, NUMBER_OF_AuthenticationGrantIdS_MASK); }
            set { byte6 = Bits.PutValueMask(byte6, value, 0, NUMBER_OF_AuthenticationGrantIdS_MASK); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _AdvancedAccessContentSystemVersion;

        [DisplayName("Advanced Access Content System Version")]
        public byte AdvancedAccessContentSystemVersion
        {
            get { return _AdvancedAccessContentSystemVersion; }
            set { _AdvancedAccessContentSystemVersion = value; }
        }
    }
}