using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class SupportedVitalProductDataPagesDataPage : VitalProductDataInquiryData
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly IntPtr SUPPORTED_PAGE_LIST_OFFSET =
            Marshal.OffsetOf(typeof (SupportedVitalProductDataPagesDataPage), "_SupportedPageList");

        public SupportedVitalProductDataPagesDataPage() : base(VitalProductDataPageCode.SupportedVitalProductDataPages)
        {
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)] private
            VitalProductDataPageCode[] _SupportedPageList;

        public VitalProductDataPageCode[] SupportedPageList
        {
            get { return _SupportedPageList; }
            set
            {
                _SupportedPageList = value;
                PageLength = (byte) (value != null ? value.Length/sizeof (VitalProductDataPageCode) : 0);
            }
        }

        protected override void MarshalFrom(BufferWithSize buffer)
        {
            base.MarshalFrom(buffer);
            _SupportedPageList = new VitalProductDataPageCode[PageLength/sizeof (VitalProductDataPageCode)];
            for (int i = 0; i < _SupportedPageList.Length; i++)
            {
                _SupportedPageList[i] = (VitalProductDataPageCode) buffer[(int) SUPPORTED_PAGE_LIST_OFFSET + i];
            }
        }

        protected override void MarshalTo(BufferWithSize buffer)
        {
            base.MarshalTo(buffer);
            for (int i = 0; i < _SupportedPageList.Length; i++)
            {
                buffer[(int) SUPPORTED_PAGE_LIST_OFFSET + i] = (byte) _SupportedPageList[i];
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected override int MarshaledSize
        {
            get { return base.MarshaledSize + PageLength - sizeof (VitalProductDataPageCode); }
        }
    }
}