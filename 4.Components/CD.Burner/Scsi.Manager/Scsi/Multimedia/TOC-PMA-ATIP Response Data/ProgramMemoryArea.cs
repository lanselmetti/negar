using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class ProgramMemoryArea : TocPmaAtipResponseData
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly IntPtr PMA_DESCRIPTORS_OFFSET =
            Marshal.OffsetOf(typeof (ProgramMemoryArea), "_PmaDescriptors");

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)] private
            ProgramMemoryAreaDescriptor[] _PmaDescriptors;

        [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        public ProgramMemoryAreaDescriptor[] PmaDescriptors
        {
            get { return _PmaDescriptors; }
            set { _PmaDescriptors = value; }
        }

        protected override void MarshalFrom(BufferWithSize buffer)
        {
            base.MarshalFrom(buffer);
            _PmaDescriptors =
                new ProgramMemoryAreaDescriptor[
                    (DataLength + sizeof (ushort) - base.MarshaledSize)/
                    Marshaler.DefaultSizeOf<ProgramMemoryAreaDescriptor>()];
            for (int i = 0; i < _PmaDescriptors.Length; i++)
            {
                _PmaDescriptors[i] =
                    Marshaler.PtrToStructure<ProgramMemoryAreaDescriptor>(
                        buffer.ExtractSegment(
                            (int) PMA_DESCRIPTORS_OFFSET + i*Marshaler.DefaultSizeOf<ProgramMemoryAreaDescriptor>(),
                            Marshaler.DefaultSizeOf<ProgramMemoryAreaDescriptor>()));
            }
        }

        protected override void MarshalTo(BufferWithSize buffer)
        {
            base.MarshalTo(buffer);
            for (int i = 0; i < _PmaDescriptors.Length; i++)
            {
                Marshaler.StructureToPtr(_PmaDescriptors[i],
                                         buffer.ExtractSegment(
                                             (int) PMA_DESCRIPTORS_OFFSET +
                                             i*Marshaler.DefaultSizeOf<ProgramMemoryAreaDescriptor>(),
                                             Marshaler.SizeOf(_PmaDescriptors[i])));
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected override int MarshaledSize
        {
            get { return Marshaler.DefaultSizeOf<ProgramMemoryArea>(); }
        }
    }

    public struct ProgramMemoryAreaDescriptor
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