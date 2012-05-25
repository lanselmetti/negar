using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    /// <summary>This feature identifies a drive that is able to write data to contiguous regions that are allocated on multiple layers, and is able to append data to a limited number of locations on the media. The drive may write two or more recording layers sequentially and alternately.</summary>
    [Description(
        "This feature identifies a drive that is able to write data to contiguous regions that are allocated on multiple layers, and is able to append data to a limited number of locations on the media.\r\nThe drive may write two or more recording layers sequentially and alternately."
        )]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class LayerJumpRecordingFeature : MultimediaFeature
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly IntPtr LINK_SIZES_OFFSET =
            Marshal.OffsetOf(typeof (LayerJumpRecordingFeature), "_LinkSizes");

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly ScsiCommandCode[]
            __SupportedOperations = Sort(new ScsiCommandCode[] {});

        public override FeatureSupportKind GetSupport(ScsiCommand command)
        {
            return Array.BinarySearch(__SupportedOperations, command.OpCode) >= 0
                       ? FeatureSupportKind.Mandatory
                       : FeatureSupportKind.None;
        }

        public LayerJumpRecordingFeature() : base(FeatureCode.LayerJumpRecording)
        {
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte4;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte5;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte6;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _NumberOfLinkSizes;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)] private
            byte[] _LinkSizes;

        [DisplayName("Link Sizes (in blocks)")]
        public byte[] LinkSizes
        {
            get { return _LinkSizes; }
            set
            {
                _LinkSizes = value;
                _NumberOfLinkSizes = value == null ? (byte) 0 : (byte) value.Length;
                AdditionalLength = (byte) (4 + _NumberOfLinkSizes + 7 + CalculatePadBytes());
                ;
            }
        }

        protected override void MarshalFrom(BufferWithSize buffer)
        {
            base.MarshalFrom(buffer);
            _LinkSizes = new byte[AdditionalLength - _NumberOfLinkSizes - CalculatePadBytes()];
            buffer.CopyTo(LINK_SIZES_OFFSET, _LinkSizes, IntPtr.Zero, (IntPtr) _LinkSizes.Length);
        }

        protected override void MarshalTo(BufferWithSize buffer)
        {
            base.MarshalTo(buffer);
            buffer.CopyFrom(LINK_SIZES_OFFSET, _LinkSizes, IntPtr.Zero, (IntPtr) _LinkSizes.Length);
        }

        private byte CalculatePadBytes()
        {
            return (byte) (3 - (_NumberOfLinkSizes + 3)%4);
        }
    }
}