﻿using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    /// <summary>This feature identifies a drive that is able to write data to logical blocks specified by logical block addresses. There is no requirement that the addresses in sequences of writes occur in any particular order.</summary>
    [Description(
        "This feature identifies a drive that is able to write data to logical blocks specified by logical block addresses.\r\nThere is no requirement that the addresses in sequences of writes occur in any particular order."
        )]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class RandomWritableFeature : MultimediaFeature
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly ScsiCommandCode[]
            __SupportedOperations =
                Sort(new[]
                         {
                             ScsiCommandCode.ReadCapacity, ScsiCommandCode.Write10, ScsiCommandCode.WriteAndVerify10,
                             ScsiCommandCode.SynchronizeCache10
                         });

        public override FeatureSupportKind GetSupport(ScsiCommand command)
        {
            return Array.BinarySearch(__SupportedOperations, command.OpCode) >= 0
                       ? FeatureSupportKind.Mandatory
                       : FeatureSupportKind.None;
        }

        public RandomWritableFeature() : base(FeatureCode.RandomWritable)
        {
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private uint _LastLogicalBlockAddress;

        [DisplayName("Last Logical Block Address")]
        public uint LastLogicalBlockAddress
        {
            get { return Bits.BigEndian(_LastLogicalBlockAddress); }
            set { _LastLogicalBlockAddress = Bits.BigEndian(value); }
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