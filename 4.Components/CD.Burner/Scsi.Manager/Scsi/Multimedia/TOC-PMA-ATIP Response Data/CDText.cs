using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class CDText : TocPmaAtipResponseData
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly IntPtr CD_TEXT_DATA_OFFSET =
            Marshal.OffsetOf(typeof (CDText), "_CDTextData");

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] [MarshalAs(UnmanagedType.ByValArray, SizeConst = 18)] private
            byte[] _CDTextData;

        public byte[] CDTextData
        {
            get { return _CDTextData; }
            set { _CDTextData = value; }
        }

        protected override void MarshalFrom(BufferWithSize buffer)
        {
            base.MarshalFrom(buffer);
            _CDTextData = new byte[18];
            buffer.CopyTo((int) CD_TEXT_DATA_OFFSET, _CDTextData, 0, _CDTextData.Length);
        }

        protected override void MarshalTo(BufferWithSize buffer)
        {
            base.MarshalTo(buffer);
            if (_CDTextData.Length > 18)
            {
                throw new OverflowException("Field is too large.");
            }
            buffer.CopyFrom((int) CD_TEXT_DATA_OFFSET, _CDTextData, 0, _CDTextData.Length);
            buffer.Initialize((int) CD_TEXT_DATA_OFFSET + _CDTextData.Length, 18 - _CDTextData.Length);
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected override int MarshaledSize
        {
            get { return Marshaler.DefaultSizeOf<CDText>(); }
        }
    }
}