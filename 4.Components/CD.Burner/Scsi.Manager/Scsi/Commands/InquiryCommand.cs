using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class InquiryCommand : FixedLengthScsiCommand
    {
        public InquiryCommand() : base(ScsiCommandCode.Inquiry)
        {
        }

        public InquiryCommand(VitalProductDataPageCode? pageCode) : this()
        {
            PageCode = pageCode;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte1;

        /// <summary>If <c>false</c>, the <see cref="PageCode"/> property must not be set.</summary>
        private bool EVitalProductData
        {
            get { return Bits.GetBit(byte1, 0); }
            set { byte1 = Bits.SetBit(byte1, 0, value); }
        }

        public bool CommandSupportData
        {
            get { return Bits.GetBit(byte1, 1); }
            set { byte1 = Bits.SetBit(byte1, 1, value); }
        }

        private VitalProductDataPageCode _PageCode;

        public VitalProductDataPageCode? PageCode
        {
            get { return EVitalProductData ? (VitalProductDataPageCode?) _PageCode : null; }
            set
            {
                EVitalProductData = value != null;
                _PageCode = value.GetValueOrDefault();
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ushort _AllocationLength;

        /// <summary>Do not use this value unless you are responsible for calling the <see cref="IScsiPassThrough.ExecuteCommand"/> method directly.</summary>
        public ushort AllocationLength
        {
            get { return Bits.BigEndian(_AllocationLength); }
            set { _AllocationLength = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private CommandControl _Control;

        public override CommandControl Control
        {
            get { return _Control; }
            set { _Control = value; }
        }

        public override ScsiTimeoutGroup TimeoutGroup
        {
            get { return ScsiTimeoutGroup.None; }
        }
    }
}