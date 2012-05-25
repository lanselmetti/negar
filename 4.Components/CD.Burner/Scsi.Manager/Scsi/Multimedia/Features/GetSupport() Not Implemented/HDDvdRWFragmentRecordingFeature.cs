using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    /// <summary>This feature indicates the ability to perform writing on any part of the data recordable area in multiples of blocking factor. If the currently mounted medium is write protected, this feature is not current. Writing from the host into the media must be in units of blocking. Writing begins and stops at blocking boundaries.</summary>
    [Description(
        "This feature indicates the ability to perform writing on any part of the data recordable area in multiples of blocking factor.\r\nIf the currently mounted medium is write protected, this feature is not current.\r\nWriting from the host into the media must be in units of blocking.\r\nWriting begins and stops at blocking boundaries."
        )]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class HDDvdRWFragmentRecordingFeature : MultimediaFeature
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly ScsiCommandCode[]
            __SupportedOperations = Sort(new ScsiCommandCode[] {});

        public override FeatureSupportKind GetSupport(ScsiCommand command)
        {
            return Array.BinarySearch(__SupportedOperations, command.OpCode) >= 0
                       ? FeatureSupportKind.Mandatory
                       : FeatureSupportKind.None;
        }

        public HDDvdRWFragmentRecordingFeature() : base(FeatureCode.HDDvdRWFragmentRecording)
        {
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte4;

        [DisplayName("Background Padding")]
        public bool BackgroundPadding
        {
            get { return Bits.GetBit(byte4, 0); }
            set { byte4 = Bits.SetBit(byte4, 0, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte5;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte6;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte7;
    }
}