using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Scsi.Multimedia
{
    /// <summary>This feature identifies a drive that is able to read control structures and user data from the BD disc.</summary>
    [Description(
        "This feature identifies a drive that is able to read control structures and user data from the BD disc.")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class BDReadFeature : MultimediaFeature
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
                       ? FeatureSupportKind.Mandatory
                       : FeatureSupportKind.None;
        }

        public BDReadFeature() : base(FeatureCode.BDRead)
        {
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte4;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte5;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte6;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte7;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] private
            short[] _BDREReadSupportBitmap = new short[4];

        public short[] BDREReadSupportBitmap
        {
            get { return _BDREReadSupportBitmap; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)] private
            short[] _BDRReadSupportBitmap = new short[8];

        public short[] BDRReadSupportBitmap
        {
            get { return _BDRReadSupportBitmap; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)] private
            short[] _BDROMReadSupportBitmap = new short[8];

        public short[] BDROMReadSupportBitmap
        {
            get { return _BDROMReadSupportBitmap; }
        }
    }
}