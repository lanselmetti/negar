using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    /// <summary></summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class VendorSpecificFeature : MultimediaFeature
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly IntPtr DATA_OFFSET =
            Marshal.OffsetOf(typeof (VendorSpecificFeature), "_Data");

        public override FeatureSupportKind GetSupport(ScsiCommand command)
        {
            return FeatureSupportKind.None;
        }

        public VendorSpecificFeature() : base(FeatureCode.Core)
        {
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)] private
            byte[] _Data = new byte[0];

        public byte[] Data
        {
            get { return _Data; }
            set
            {
                AdditionalLength = value != null ? (byte) value.Length : (byte) 0;
                _Data = value != null ? value : new byte[0];
            }
        }

        protected override void MarshalFrom(BufferWithSize buffer)
        {
            base.MarshalFrom(buffer);
            _Data = new byte[AdditionalLength];
            buffer.CopyTo((int) DATA_OFFSET, _Data, 0, _Data.Length);
        }

        protected override void MarshalTo(BufferWithSize buffer)
        {
            base.MarshalTo(buffer);
            buffer.CopyFrom((int) DATA_OFFSET, _Data, 0, _Data.Length);
        }
    }
}