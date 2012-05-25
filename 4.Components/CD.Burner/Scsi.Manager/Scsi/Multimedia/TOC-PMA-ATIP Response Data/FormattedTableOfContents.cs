using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class FormattedTableOfContents : TocPmaAtipResponseData
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly IntPtr TRACK_DESCRIPTORS_OFFSET =
            Marshal.OffsetOf(typeof (FormattedTableOfContents), "_TrackDescriptors");

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
            TocTrackDescriptor[] _TrackDescriptors;

        [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        public TocTrackDescriptor[] TrackDescriptors
        {
            get { return _TrackDescriptors; }
            set { _TrackDescriptors = value; }
        }

        protected override void MarshalFrom(BufferWithSize buffer)
        {
            base.MarshalFrom(buffer);
            _TrackDescriptors =
                new TocTrackDescriptor[
                    (DataLength + sizeof (ushort) - base.MarshaledSize)/Marshaler.DefaultSizeOf<TocTrackDescriptor>()];
            for (int i = 0; i < _TrackDescriptors.Length; i++)
            {
                _TrackDescriptors[i] =
                    Marshaler.PtrToStructure<TocTrackDescriptor>(
                        buffer.ExtractSegment(
                            (int) TRACK_DESCRIPTORS_OFFSET + i*Marshaler.DefaultSizeOf<TocTrackDescriptor>(),
                            Marshaler.DefaultSizeOf<TocTrackDescriptor>()));
            }
        }

        protected override void MarshalTo(BufferWithSize buffer)
        {
            base.MarshalTo(buffer);
            for (int i = 0; i < _TrackDescriptors.Length; i++)
            {
                Marshaler.StructureToPtr(_TrackDescriptors[i],
                                         buffer.ExtractSegment(
                                             (int) TRACK_DESCRIPTORS_OFFSET +
                                             i*Marshaler.DefaultSizeOf<TocTrackDescriptor>(),
                                             Marshaler.SizeOf(_TrackDescriptors[i])));
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected override int MarshaledSize
        {
            get { return Marshaler.DefaultSizeOf<FormattedTableOfContents>(); }
        }
    }

    public struct TocTrackDescriptor
    {
#pragma warning restore 0169
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _AddressControl;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _TrackNumber;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private uint _TrackStartAddress;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
#pragma warning disable 0169
            private byte byte0;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
#pragma warning disable 0169
            private byte byte3;

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

        public uint TrackStartAddress
        {
            get { return Bits.BigEndian(_TrackStartAddress); }
            set { _TrackStartAddress = Bits.BigEndian(value); }
        }
    }
}