using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    /// <summary>Represents the data returned by the <see cref="ReadDiscStructureCommand"/> command.</summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public abstract class DiscStructureData : IMarshalable
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ushort _DataLength;

        /// <summary>The length in bytes of the following structure data that is available to be transferred to the initiator, excluding its own size (2 bytes). Do not use this value unless you are responsible for calling the <see cref="IScsiPassThrough.ExecuteCommand"/> method directly.
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ushort DataLength
        {
            get { return Bits.BigEndian(_DataLength); }
            set { _DataLength = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _Byte1;

        /// <summary>The byte at offset <c>1</c>. This is reserved for most formats.</summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public byte Byte1
        {
            get { return _Byte1; }
            set { _Byte1 = value; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _Byte2;

        /// <summary>The byte at offset <c>2</c>. This is reserved for most formats.</summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public byte Byte2
        {
            get { return _Byte2; }
            set { _Byte2 = value; }
        }

        protected virtual void MarshalFrom(BufferWithSize buffer)
        {
            Marshaler.DefaultPtrToStructure(buffer, this);
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected virtual int MarshaledSize
        {
            get { return Marshal.SizeOf(this); }
        }

        void IMarshalable.MarshalFrom(BufferWithSize buffer)
        {
            MarshalFrom(buffer);
        }

        void IMarshalable.MarshalTo(BufferWithSize buffer)
        {
            throw new NotSupportedException(
                "This class will never be marshaled to native code and thus marshaling is not supported.");
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        int IMarshalable.MarshaledSize
        {
            get { return MarshaledSize; }
        }

        internal static ushort ReadDataLength(BufferWithSize buffer)
        {
            return buffer.Read<ushort>();
        }

        private static DiscStructureData CreateInstance(byte formatCode, ReadDiscStructureMediaType mediaType)
        {
            DiscStructureData data;
            if (formatCode >= 0x80) //This is for ALL media
            {
                switch ((GenericDiscStructureFormatCode) formatCode)
                {
                    default:
                        throw new NotImplementedException();
                }
            }
            else //Media type-specific
            {
                switch (mediaType)
                {
                    case ReadDiscStructureMediaType.DvdAndHDDvd:
                        switch ((DvdStructureFormatCode) formatCode)
                        {
                            case DvdStructureFormatCode.PhysicalInformationFromLeadIn:
                                data = new DvdPhysicalFormatInformation();
                                break;
                            default:
                                throw new NotImplementedException();
                        }
                        break;
                    case ReadDiscStructureMediaType.BD:
                        throw new NotImplementedException();
                    default:
                        throw new ArgumentOutOfRangeException("mediaType", mediaType, "Invalid media type.");
                }
            }
            return data;
        }

        internal static DiscStructureData FromBuffer(byte formatCode, ReadDiscStructureMediaType mediaType,
                                                     BufferWithSize buffer)
        {
            buffer = buffer.ExtractSegment(0, ReadDataLength(buffer));
            DiscStructureData data = CreateInstance(formatCode, mediaType);
            data.MarshalFrom(buffer);
            return data;
        }
    }
}