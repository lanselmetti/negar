using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public abstract class FormatDescriptor : IMarshalable
    {
        protected FormatDescriptor()
        {
            FormatDescriptorLength = (ushort) (Marshal.SizeOf(this) - Marshaler.DefaultSizeOf<FormatDescriptor>());
            FormatOptionsValid = true;
        }

        //Header starts here
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte1;

        /// <summary>Whether to use these values (valid) or the default settings (invalid).</summary>
        [Description("Whether to use these values (valid) or the default settings (invalid).")]
        public bool FormatOptionsValid
        {
            get { return Bits.GetBit(byte1, 7); }
            set { byte1 = Bits.SetBit(byte1, 7, value); }
        }

        public bool DisablePrimary
        {
            get { return Bits.GetBit(byte1, 6); }
            set { byte1 = Bits.SetBit(byte1, 6, value); }
        }

        public bool DisableCertification
        {
            get { return Bits.GetBit(byte1, 5); }
            set { byte1 = Bits.SetBit(byte1, 5, value); }
        }

        /// <summary>Must be zero.</summary>
        public bool StopFormat
        {
            get { return Bits.GetBit(byte1, 4); }
        }

        /// <summary>Must be zero.</summary>
        public bool InitializationPattern
        {
            get { return Bits.GetBit(byte1, 3); }
            protected set { byte1 = Bits.SetBit(byte1, 3, value); }
        }

        public bool TryOut
        {
            get { return Bits.GetBit(byte1, 2); }
            set { byte1 = Bits.SetBit(byte1, 2, value); }
        }

        public bool Immediate
        {
            get { return Bits.GetBit(byte1, 1); }
            set { byte1 = Bits.SetBit(byte1, 1, value); }
        }

        public bool VendorSpecific
        {
            get { return Bits.GetBit(byte1, 0); }
            set { byte1 = Bits.SetBit(byte1, 0, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ushort _FormatDescriptorLength;

        private ushort FormatDescriptorLength
        {
            get { return Bits.BigEndian(_FormatDescriptorLength); }
            set { _FormatDescriptorLength = Bits.BigEndian(value); }
        }

        //End of header

        public abstract FormatCode FormatCode { get; }

        protected virtual void MarshalFrom(BufferWithSize buffer)
        {
            Marshaler.DefaultPtrToStructure(buffer, this);
        }

        protected virtual void MarshalTo(BufferWithSize buffer)
        {
            Marshaler.DefaultStructureToPtr((object) this, buffer);
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
            MarshalTo(buffer);
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        int IMarshalable.MarshaledSize
        {
            get { return MarshaledSize; }
        }
    }
}