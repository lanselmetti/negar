using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class RawTableOfContents : TocPmaAtipResponseData
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly IntPtr TRACK_DESCRIPTORS_OFFSET =
            Marshal.OffsetOf(typeof (RawTableOfContents), "_TrackDescriptors");

        public byte FirstTrackNumber
        {
            get { return base.FirstTrackOrSession; }
            set { base.FirstTrackOrSession = value; }
        }

        public byte LastTrackNumber
        {
            get { return base.LastTrackOrSession; }
            set { base.LastTrackOrSession = value; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)] private
            RawTocTrackDescriptor[] _TrackDescriptors;

        [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        public RawTocTrackDescriptor[] TrackDescriptors
        {
            get { return _TrackDescriptors; }
            set { _TrackDescriptors = value; }
        }

        protected override void MarshalFrom(BufferWithSize buffer)
        {
            base.MarshalFrom(buffer);
            _TrackDescriptors =
                Marshaler.PtrToStructure<RawTocTrackDescriptor[]>(buffer.ExtractSegment(TRACK_DESCRIPTORS_OFFSET));
        }

        protected override void MarshalTo(BufferWithSize buffer)
        {
            base.MarshalTo(buffer);
            Marshaler.StructureToPtr(_TrackDescriptors, buffer.ExtractSegment(TRACK_DESCRIPTORS_OFFSET));
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected override int MarshaledSize
        {
            get { return Marshaler.DefaultSizeOf<RawTableOfContents>(); }
        }
    }

    public struct RawTocTrackDescriptor
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _AddressControl;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _Frame;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _HourPHour;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _Minute;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _PMinute;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _Point;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _PSecond;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _Second;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _SessionNumber;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _TrackNumber;

        public byte SessionNumber
        {
            get { return _SessionNumber; }
            set { _SessionNumber = value; }
        }

        public CDControl Control
        {
            get { return unchecked((CDControl) (_AddressControl & 0xF0)); }
            private set { _AddressControl = (byte) ((_AddressControl & ~0xF0) | ((byte) value & 0xF0)); }
        }

        public CDAddress Address
        {
            get { return unchecked((CDAddress) (_AddressControl & 0x0F)); }
            private set { _AddressControl = (byte) ((_AddressControl & ~0x0F) | ((byte) value & 0x0F)); }
        }

        public byte TrackNumber
        {
            get { return _TrackNumber; }
            set { _TrackNumber = value; }
        }

        public byte Point
        {
            get { return _Point; }
            set { _Point = value; }
        }

        //Do not use the Msf structure, since sometimes these values don't actually represent time

        public byte Minute
        {
            get { return _Minute; }
            set { _Minute = value; }
        }

        public byte Second
        {
            get { return _Second; }
            set { _Second = value; }
        }

        public byte Frame
        {
            get { return _Frame; }
            set { _Frame = value; }
        }

        public byte HourPHour
        {
            get { return _HourPHour; }
            set { _HourPHour = value; }
        }

        public byte PMinute
        {
            get { return _PMinute; }
            set { _PMinute = value; }
        }

        public byte PSecond
        {
            get { return _PSecond; }
            set { _PSecond = value; }
        }
    }
}