using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class ReadTrackInformationCommand : FixedLengthScsiCommand
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte ADDRESS_OR_NUMBER_TYPE_MASK = 0x3;

        public ReadTrackInformationCommand() : base(ScsiCommandCode.ReadTrackInformation)
        {
        }

        public ReadTrackInformationCommand(bool findFirstOpen, TrackIdentificationType addressOrNumberType,
                                           uint trackNumberOrSessionNumberOrLogicalBlockAddress)
            : this()
        {
            Open = findFirstOpen;
            AddressOrNumberType = addressOrNumberType;
            TrackNumberOrSessionNumberOrLogicalBlockAddress = trackNumberOrSessionNumberOrLogicalBlockAddress;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte1;

        /// <summary>If <c>false</c>, finds the logical track that contains the given LogicalBlockAddress, logical track number, or logical session number. If <c>true</c>, finds the first open logical track with a logical track number that is GREATER than the given LogicalBlockAddress, logical track number, or logical session number.</summary>
        [Description(
            "If false, finds the logical track that contains the given LogicalBlockAddress, logical track number, or logical session number. If true, finds the first open logical track with a logical track number that is GREATER than the given LogicalBlockAddress, logical track number, or logical session number."
            )]
        public bool Open
        {
            get { return Bits.GetBit(byte1, 2); }
            set { byte1 = Bits.SetBit(byte1, 2, value); }
        }

        public TrackIdentificationType AddressOrNumberType
        {
            get { return (TrackIdentificationType) Bits.GetValueMask(byte1, 0, ADDRESS_OR_NUMBER_TYPE_MASK); }
            set { byte1 = Bits.PutValueMask(byte1, (byte) value, 0, ADDRESS_OR_NUMBER_TYPE_MASK); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private uint _TrackNumberOrSessionNumberOrLogicalBlockAddress;

        public uint TrackNumberOrSessionNumberOrLogicalBlockAddress
        {
            get { return Bits.BigEndian(_TrackNumberOrSessionNumberOrLogicalBlockAddress); }
            set { _TrackNumberOrSessionNumberOrLogicalBlockAddress = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte6;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ushort _AllocationLength;

        /// <summary>Do not use this value unless you are responsible for calling the <see cref="IScsiPassThrough.ExecuteCommand"/> method directly.</summary>
        public ushort AllocationLength
        {
            get { return Bits.BigEndian(_AllocationLength); }
            set { _AllocationLength = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private CommandControl _Control;

        public override CommandControl Control
        {
            get { return _Control; }
            set { _Control = value; }
        }

        public override ScsiTimeoutGroup TimeoutGroup
        {
            get { return ScsiTimeoutGroup.Group1; }
        }
    }
}