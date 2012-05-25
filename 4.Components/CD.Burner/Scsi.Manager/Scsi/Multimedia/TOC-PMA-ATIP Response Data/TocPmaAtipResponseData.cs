using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public abstract class TocPmaAtipResponseData : IMarshalable
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly IntPtr DATA_LENGTH_OFFSET =
            Marshal.OffsetOf(typeof (TocPmaAtipResponseData), "_DataLength");

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly IntPtr FIRST_TRACK_OR_SESSION_OFFSET =
            Marshal.OffsetOf(typeof (TocPmaAtipResponseData), "_FirstTrackOrSession");

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly IntPtr LAST_TRACK_OR_SESSION_OFFSET =
            Marshal.OffsetOf(typeof (TocPmaAtipResponseData), "_LastTrackOrSession");

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ushort _DataLength;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ushort DataLength
        {
            get { return Bits.BigEndian(_DataLength); }
            private set { _DataLength = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _FirstTrackOrSession;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected byte FirstTrackOrSession
        {
            get { return Bits.BigEndian(_FirstTrackOrSession); }
            set { _FirstTrackOrSession = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _LastTrackOrSession;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected byte LastTrackOrSession
        {
            get { return Bits.BigEndian(_LastTrackOrSession); }
            set { _LastTrackOrSession = Bits.BigEndian(value); }
        }

        protected virtual void MarshalFrom(BufferWithSize buffer)
        {
            _DataLength = buffer.Read<ushort>(DATA_LENGTH_OFFSET);
            _FirstTrackOrSession = buffer.Read<byte>(FIRST_TRACK_OR_SESSION_OFFSET);
            _LastTrackOrSession = buffer.Read<byte>(LAST_TRACK_OR_SESSION_OFFSET);
        }

        protected virtual void MarshalTo(BufferWithSize buffer)
        {
            //Don't reference _DataLength FIELD since it's big-endian
            DataLength = (ushort) (MarshaledSize - sizeof (ushort));
            buffer.Write(_DataLength, DATA_LENGTH_OFFSET);
            buffer.Write(_FirstTrackOrSession, FIRST_TRACK_OR_SESSION_OFFSET);
            buffer.Write(_LastTrackOrSession, LAST_TRACK_OR_SESSION_OFFSET);
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected virtual int MarshaledSize
        {
            get { return Marshaler.DefaultSizeOf<TocPmaAtipResponseData>(); }
        }

        void IMarshalable.MarshalFrom(BufferWithSize buffer)
        {
            MarshalFrom(buffer);
        }

        void IMarshalable.MarshalTo(BufferWithSize buffer)
        {
            MarshalTo(buffer);
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        int IMarshalable.MarshaledSize
        {
            get { return MarshaledSize; }
        }

        public static TocPmaAtipResponseData CreateInstance(ReadTocPmaAtipDataFormat formatCode)
        {
            TocPmaAtipResponseData result;
            switch (formatCode)
            {
                case ReadTocPmaAtipDataFormat.FormattedTableOfContents:
                    result = new FormattedTableOfContents();
                    break;
                case ReadTocPmaAtipDataFormat.MultisessionInformation:
                    result = new MultisessionInformation();
                    break;
                case ReadTocPmaAtipDataFormat.RawTableOfContents:
                    result = new RawTableOfContents();
                    break;
                case ReadTocPmaAtipDataFormat.ProgramMemoryArea:
                    result = new ProgramMemoryArea();
                    break;
                case ReadTocPmaAtipDataFormat.AbsoluteTimeInPreGroove:
                    result = new AbsoluteTimeInPregroove();
                    break;
                case ReadTocPmaAtipDataFormat.CDTextInRWSubChannel:
                    result = new CDText();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("formatCode", formatCode, "Invalid command format code.");
            }
            return result;
        }

        public static ushort ReadDataLength(IntPtr pBuffer)
        {
            unsafe
            {
                return Bits.BigEndian(*(ushort*) pBuffer);
            }
        }
    }
}