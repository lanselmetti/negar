using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Scsi.Multimedia
{
    /// <summary>This feature identifies a drive that is able to write control structures and user data to certain BD discs.</summary>
    [Description(
        "This feature identifies a drive that is able to write control structures and user data to certain BD discs.")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class BDWriteFeature : MultimediaFeature
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly ScsiCommandCode[]
            __SupportedOperations = Sort(new[] {ScsiCommandCode.Format, ScsiCommandCode.Write10});

        public override FeatureSupportKind GetSupport(ScsiCommand command)
        {
            return Array.BinarySearch(__SupportedOperations, command.OpCode) >= 0
                       ? FeatureSupportKind.Mandatory
                       : FeatureSupportKind.None;
        }

        public BDWriteFeature() : base(FeatureCode.BDWrite)
        {
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte4;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte5;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte6;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte7;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] private
            short[] _BDREWriteSupportBitmap = new short[4];

        public short[] BDREWriteSupportBitmap
        {
            get { return _BDREWriteSupportBitmap; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)] private
            short[] _BDRWriteSupportBitmap = new short[8];

        public short[] BDRWriteSupportBitmap
        {
            get { return _BDRWriteSupportBitmap; }
        }
    }
}