using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    /// <summary>This feature identifies a drive that is able to write data to a contiguous region, and is able to append data to a limited number of locations on the media. On CD media, this is known as packet recording, on DVD and HD DVD media it is known as Incremental Recording, and on a BD-R disc it is known as SRM recording.</summary>
    [Description(
        "This feature identifies a drive that is able to write data to a contiguous region, and is able to append data to a limited number of locations on the media.\r\nOn CD media, this is known as packet recording, on DVD and HD DVD media it is known as Incremental Recording, and on a BD-R disc it is known as SRM recording."
        )]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class IncrementalStreamingWritableFeature : MultimediaFeature
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly IntPtr LINK_SIZES_OFFSET =
            Marshal.OffsetOf(typeof (IncrementalStreamingWritableFeature), "_LinkSizes");

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly ScsiCommandCode[]
            __SupportedOperations =
                Sort(new[]
                         {
                             ScsiCommandCode.Blank, ScsiCommandCode.CloseSessionOrTrack,
                             ScsiCommandCode.ReadDiscInformation, ScsiCommandCode.ReadTrackInformation,
                             ScsiCommandCode.ReserveTrack, ScsiCommandCode.SendOpcInformation,
                             ScsiCommandCode.SynchronizeCache10, ScsiCommandCode.Write10
                         });

        public override FeatureSupportKind GetSupport(ScsiCommand command)
        {
            return Array.BinarySearch(__SupportedOperations, command.OpCode) >= 0
                   &&
                   (command.OpCode != ScsiCommandCode.Blank ||
                    (((BlankCommand) command).BlankingType == BlankingType.Blank ||
                     ((BlankCommand) command).BlankingType == BlankingType.BlankMinimal ||
                     ((BlankCommand) command).BlankingType == BlankingType.BlankTrackTail))
                       ? FeatureSupportKind.Mandatory
                       : FeatureSupportKind.None;
        }


        public IncrementalStreamingWritableFeature() : base(FeatureCode.IncrementalStreamingWritable)
        {
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private DataBlockTypesSupported _DataBlockTypesSupported;

        [DisplayName("CD Data Block Types")]
        public DataBlockTypesSupported DataBlockTypesSupported
        {
            get { return _DataBlockTypesSupported; }
            set { _DataBlockTypesSupported = value; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte6;

        /// <summary>This bit, if set to <c>true</c>, indicates that the logical unit is capable of zero loss linking.</summary>
        [Description("This bit, if set to <c>true</c>, indicates that the logical unit is capable of zero loss linking."
            )]
        [DisplayName("Buffer Underrun Protection")]
        public bool BufferUnderrunProtection
        {
            get { return Bits.GetBit(byte6, 0); }
            set { byte6 = Bits.SetBit(byte6, 0, value); }
        }

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
                AdditionalLength = (byte) (4 + CalculatePadBytes() + _NumberOfLinkSizes);
                ;
            }
        }

        protected override void MarshalFrom(BufferWithSize buffer)
        {
            Marshaler.DefaultPtrToStructure(buffer, this);
            _LinkSizes = new byte[AdditionalLength - _NumberOfLinkSizes - CalculatePadBytes()];
            buffer.CopyTo(LINK_SIZES_OFFSET, _LinkSizes, IntPtr.Zero, (IntPtr) _LinkSizes.Length);
        }

        protected override void MarshalTo(BufferWithSize buffer)
        {
            Marshaler.DefaultStructureToPtr((object) this, buffer);
            buffer.CopyFrom(LINK_SIZES_OFFSET, _LinkSizes, IntPtr.Zero, (IntPtr) _LinkSizes.Length);
        }

        private byte CalculatePadBytes()
        {
            return (byte) (4* /*Integer Part only*/((_NumberOfLinkSizes + 3)/4) - _NumberOfLinkSizes);
        }
    }
}