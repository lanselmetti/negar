using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    /// <summary>This feature identifies a drive that is able to read and/or write DCBs from or to the media.</summary>
    [Description("This feature identifies a drive that is able to read and/or write DCBs from or to the media.")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class DiscControlBlocksFeature : MultimediaFeature
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly IntPtr DCB_ENTRIES_OFFSET =
            Marshal.OffsetOf(typeof (DiscControlBlocksFeature), "_DCBEntries");

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly ScsiCommandCode[]
            __SupportedOperations = Sort(new[] {ScsiCommandCode.ReadDiscStructure, ScsiCommandCode.SendDiscStructure});

        public override FeatureSupportKind GetSupport(ScsiCommand command)
        {
            return Array.BinarySearch(__SupportedOperations, command.OpCode) >= 0
                       ? FeatureSupportKind.Mandatory
                       : FeatureSupportKind.None;
        }

        public DiscControlBlocksFeature() : base(FeatureCode.DiscControlBlocks)
        {
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)] private
            uint[] _DCBEntries;

        [DisplayName("Disc Control Block Entries")]
        public uint[] DCBEntries
        {
            get { return _DCBEntries; }
            set
            {
                _DCBEntries = value;
                AdditionalLength = (byte) (4*(value == null ? 0 : value.Length));
            }
        }

        protected override void MarshalFrom(BufferWithSize buffer)
        {
            base.MarshalFrom(buffer);
            _DCBEntries = new uint[AdditionalLength/4];
            BufferWithSize entriesBuffer = buffer.ExtractSegment(DCB_ENTRIES_OFFSET);
            for (int i = 0; i < _DCBEntries.Length; i++)
            {
                _DCBEntries[i] = Bits.BigEndian<uint>(entriesBuffer.Read<uint>(i*sizeof (uint)));
            }
        }

        protected override void MarshalTo(BufferWithSize buffer)
        {
            base.MarshalTo(buffer);
            BufferWithSize entries = buffer.ExtractSegment(DCB_ENTRIES_OFFSET);
            for (int i = 0; i < _DCBEntries.Length; i++)
            {
                entries.Write(Bits.BigEndian(_DCBEntries[i]), i*sizeof (uint));
            }
        }
    }
}