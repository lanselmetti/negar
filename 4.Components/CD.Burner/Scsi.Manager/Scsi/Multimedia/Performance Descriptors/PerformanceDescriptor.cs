using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public abstract class PerformanceDescriptor : IMarshalable
    {
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