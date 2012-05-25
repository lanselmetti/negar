using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    /// <summary>This feature identifies a drive that has the ability to record to any previously unrecorded logical block. The recording of logical blocks may occur in any order. Previously recorded blocks are not overwritten.</summary>
    [Description(
        "This feature identifies a drive that has the ability to record to any previously unrecorded logical block.\r\nThe recording of logical blocks may occur in any order.\r\nPreviously recorded blocks are not overwritten."
        )]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class WriteOnceFeature : MultimediaFeature
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly ScsiCommandCode[]
            __SupportedOperations =
                Sort(new[]
                         {
                             ScsiCommandCode.ReadCapacity, ScsiCommandCode.SynchronizeCache10, ScsiCommandCode.Write10,
                             ScsiCommandCode.WriteAndVerify10
                         });

        public override FeatureSupportKind GetSupport(ScsiCommand command)
        {
            return Array.BinarySearch(__SupportedOperations, command.OpCode) >= 0
                       ? FeatureSupportKind.Mandatory
                       : FeatureSupportKind.None;
        }

        public WriteOnceFeature() : base(FeatureCode.WriteOnce)
        {
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private uint _LogicalBlockSize;

        [DisplayName("Logical Block Size")]
        public uint LogicalBlockSize
        {
            get { return Bits.BigEndian(_LogicalBlockSize); }
            set { _LogicalBlockSize = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ushort _Blocking;

        [DisplayName("Logical Blocks per Writable Unit")]
        public ushort Blocking
        {
            get { return Bits.BigEndian(_Blocking); }
            set { _Blocking = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte10;

        [DisplayName("Read/Write Error Recovery Page Present")]
        public bool PagePresent
        {
            get { return Bits.GetBit(byte10, 0); }
            set { byte10 = Bits.SetBit(byte10, 0, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte15;
    }
}