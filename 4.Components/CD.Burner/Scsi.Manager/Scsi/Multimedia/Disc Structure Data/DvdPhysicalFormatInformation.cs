using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class DvdPhysicalFormatInformation : DiscStructureData
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte PART_VERSION_MASK = 0x0F;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte BOOK_TYPE_MASK = 0xF0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte MAXIMUM_RATE_MASK = 0x0F;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte DISC_SIZE_MASK = 0xF0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte LAYER_TYPE_MASK = 0x0F;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte NUMBER_OF_LAYERS_MASK = 0x60;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte TRACK_DENSITY_MASK = 0x0F;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte LINEAR_DENSITY_MASK = 0xF0;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly IntPtr MEDIA_SPECIFIC_OFFSET =
            Marshal.OffsetOf(typeof (DvdPhysicalFormatInformation), "_MediaSpecific");

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte0;

        public byte PartVersion
        {
            get { return Bits.GetValueMask(byte0, 0, PART_VERSION_MASK); }
            set { byte0 = Bits.PutValueMask(byte0, value, 0, PART_VERSION_MASK); }
        }

        public DiscCategory BookType
        {
            get { return (DiscCategory) Bits.GetValueMask(byte0, 4, BOOK_TYPE_MASK); }
            set { byte0 = Bits.PutValueMask(byte0, (byte) value, 4, BOOK_TYPE_MASK); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte1;

        public MaximumRate MaximumRate
        {
            get { return (MaximumRate) Bits.GetValueMask(byte1, 0, MAXIMUM_RATE_MASK); }
            set { byte1 = Bits.PutValueMask(byte1, (byte) value, 0, MAXIMUM_RATE_MASK); }
        }

        public DiscSizeCode DiscSizeCode
        {
            get { return (DiscSizeCode) Bits.GetValueMask(byte1, 4, DISC_SIZE_MASK); }
            set { byte1 = Bits.PutValueMask(byte1, (byte) value, 4, DISC_SIZE_MASK); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte2;

        public LayerType LayerType
        {
            get { return (LayerType) Bits.GetValueMask(byte2, 0, LAYER_TYPE_MASK); }
            set { byte2 = Bits.PutValueMask(byte2, (byte) value, 0, LAYER_TYPE_MASK); }
        }

        public byte NumberOfLayers
        {
            get { return (byte) (Bits.GetValueMask(byte2, 5, NUMBER_OF_LAYERS_MASK) + 1); }
            set { byte2 = Bits.PutValueMask(byte2, (byte) (value - 1), 5, NUMBER_OF_LAYERS_MASK); }
        }

        /// <summary>
        /// Specifies the direction of the layers when more than one layer is used.
        /// If set to <c>false</c>, then this media uses Parallel Track Path (PTP). When PTP is used each layer is independent and has its own Lead-in and Lead-out areas on the media.
        /// If set to <c>true</c>, then the media uses Opposite Track Path (OTP). With opposite track path both layers are tied together.
        /// There is only one Lead-in and Lead-out. In the middle of the media there is an area called the middle area.
        /// The addresses of blocks in one layer are mirrored in the other layer. The Layer Type field indicates the read/write ability of the layer.
        /// </summary>
        public bool OppositeTrackPath
        {
            get { return Bits.GetBit(byte2, 4); }
            set { byte2 = Bits.SetBit(byte2, 4, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte3;

        public LinearDensity LinearDensity
        {
            get { return (LinearDensity) Bits.GetValueMask(byte3, 4, LINEAR_DENSITY_MASK); }
            set { byte3 = Bits.PutValueMask(byte3, (byte) value, 4, LINEAR_DENSITY_MASK); }
        }

        public TrackDensity TrackDensity
        {
            get { return (TrackDensity) Bits.GetValueMask(byte3, 0, TRACK_DENSITY_MASK); }
            set { byte3 = Bits.PutValueMask(byte3, (byte) value, 0, TRACK_DENSITY_MASK); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private uint _StartingDataAreaPhysicalSectorNumber;

        /// <summary>Four DVD-ROM, DVD-R, DVD-RW, and DVD+RW, this field should be <c>0x30000</c>. For DVD-RAM, it should be <c>0x31000</c>.</summary>
        /// <remarks>Technically, this should be a 48-bit value, but since the upper byte is supposed to be zero by the standard, I made it easier here.</remarks>
        public uint StartingDataAreaPhysicalSectorNumber
        {
            get { return Bits.BigEndian(_StartingDataAreaPhysicalSectorNumber); }
            set { _StartingDataAreaPhysicalSectorNumber = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private uint _EndingDataAreaPhysicalSectorNumber;

        /// <remarks>Technically, this should be a 48-bit value, but since the upper byte is supposed to be zero by the standard, I made it easier here.</remarks>
        public uint EndingDataAreaPhysicalSectorNumber
        {
            get { return Bits.BigEndian(_EndingDataAreaPhysicalSectorNumber); }
            set { _EndingDataAreaPhysicalSectorNumber = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private uint _StartingLayer0PhysicalSectorNumber;

        /// <remarks>Technically, this should be a 48-bit value, but since the upper byte is supposed to be zero by the standard, I made it easier here.</remarks>
        public uint StartingLayer0PhysicalSectorNumber
        {
            get { return Bits.BigEndian(_StartingLayer0PhysicalSectorNumber); }
            set { _StartingLayer0PhysicalSectorNumber = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _byte16;

        public bool BurstCuttingArea
        {
            get { return Bits.GetBit(_byte16, 7); }
            set { _byte16 = Bits.SetBit(_byte16, 7, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2048 - 17)] //17 is the size of the structure before this field, EXCLUDING the superclass's size
            private byte[] _MediaSpecific = new byte[2048 - 17];

        public byte[] MediaSpecific
        {
            get { return _MediaSpecific; }
        }

        protected override void MarshalFrom(BufferWithSize buffer)
        {
            if (buffer.Length32 < MarshaledSize)
            {
                //If so, then assume zeros for rest
                unsafe
                {
                    int newSize = MarshaledSize;
                    byte* pNewBuf = stackalloc byte[newSize];
                    var newBuf = new BufferWithSize(pNewBuf, newSize);
                    BufferWithSize.Copy(buffer, UIntPtr.Zero, newBuf, UIntPtr.Zero, buffer.Length);
                    buffer = newBuf;
                }
            }
            //Now we're ready to marshal
            base.MarshalFrom(buffer);
        }
    }

    public enum DiscSizeCode : byte
    {
        OneHundredTwentyMillimeters = 0x0,
        EightyMillimeters = 0x1,
    }

    public enum TrackDensity : byte
    {
        SevenHundredFortyNanometersPerTrack = 0x0,
        EightHundredNanometersPerTrack = 0x1,
        SixHundredFifteenNanometersPerTrack = 0x2,
        FourHundredNanometersPerTrack = 0x3,
        ThreeHundredFortyNanometersPerTrack = 0x4,
    }

    public enum LinearDensity : byte
    {
        TwoHundredSixtySevenNanometersPerBit = 0x0,
        TwoHundredNinetyThreeNanometersPerBit = 0x1,
        FourHundredNineToFourHundredThirtyFiveNanometersPerBit = 0x2,
        TwoHundredEightyToTwoHundredNinetyOneNanometersPerBit = 0x4,
        OneHundredFiftyThreeNanometersPerBit = 0x5,
        OneHundredThirtyToOneHundredFortyNanometersPerBit = 0x6,
        ThreeHundredFiftyThreeNanometersPerBit = 0x8,
    }

    public enum MaximumRate : byte
    {
        TwoPointFiftyTwoMbps = 0x0,
        FivePointZeroFourMbps = 0x1,
        TenPointZeroEight = 0x2,
        Unspecified = 0xF,
    }

    public enum DiscCategory : byte
    {
        DvdRom = 0x0,
        DvdRam = 0x1,
        DvdMinusR = 0x2,
        DvdMinusRW = 0x3,
        HDDvdRom = 0x4,
        HDDvdRam = 0x5,
        DvdPlusRW = 0x9,
        DvdPlusR = 0xA,
        DvdPlusRWDualLayer = 0xD,
        DvdPlusRDualLayer = 0xE,
    }

    [Flags]
    public enum LayerType : byte
    {
        EmbossedData = 0x0,
        RecordableArea = 0x1,
        RewritableArea = 0x2,
    }
}