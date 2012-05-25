using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class ReadWriteErrorRecoveryParametersPage : ModePage
    {
        public ReadWriteErrorRecoveryParametersPage() : base(ModePageCode.ReadWriteErrorRecoveryParameters)
        {
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte errorRecoveryParameter;

        [DisplayName("Automatic Write Reallocation")]
        public bool AutomaticWriteReallocationEnabled
        {
            get { return Bits.GetBit(errorRecoveryParameter, 7); }
            set { errorRecoveryParameter = Bits.SetBit(errorRecoveryParameter, 7, value); }
        }

        [DisplayName("Automatic Read Reallocation")]
        public bool AutomaticReadReallocationEnabled
        {
            get { return Bits.GetBit(errorRecoveryParameter, 6); }
            set { errorRecoveryParameter = Bits.SetBit(errorRecoveryParameter, 6, value); }
        }

        [DisplayName("Transfer Block")]
        public bool TransferBlock
        {
            get { return Bits.GetBit(errorRecoveryParameter, 5); }
            set { errorRecoveryParameter = Bits.SetBit(errorRecoveryParameter, 5, value); }
        }

        [DisplayName("Read Continuous")]
        public bool ReadContinuous
        {
            get { return Bits.GetBit(errorRecoveryParameter, 4); }
            set { errorRecoveryParameter = Bits.SetBit(errorRecoveryParameter, 4, value); }
        }

        [DisplayName("Post Error")]
        public bool PostError
        {
            get { return Bits.GetBit(errorRecoveryParameter, 2); }
            set { errorRecoveryParameter = Bits.SetBit(errorRecoveryParameter, 2, value); }
        }

        [DisplayName("Disable Transfer On Error")]
        public bool DisableTransferOnError
        {
            get { return Bits.GetBit(errorRecoveryParameter, 1); }
            set { errorRecoveryParameter = Bits.SetBit(errorRecoveryParameter, 1, value); }
        }

        [DisplayName("Disable Correction")]
        public bool DisableCorrection
        {
            get { return Bits.GetBit(errorRecoveryParameter, 0); }
            set { errorRecoveryParameter = Bits.SetBit(errorRecoveryParameter, 0, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _ReadRetryCount;

        [DisplayName("Read Retry Count")]
        public byte ReadRetryCount
        {
            get { return _ReadRetryCount; }
            set { _ReadRetryCount = value; }
        }

        private byte _CorrectionSpan;
        private byte _HeadOffsetCount;
        private byte _DataStrobeOffsetCount;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte7;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _WriteRetryCount;

        [DisplayName("Write Retry Count")]
        public byte WriteRetryCount
        {
            get { return _WriteRetryCount; }
            set { _WriteRetryCount = value; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte9;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ushort _RecoveryTimeLimit;

        /// <summary>Should be zero.</summary>
        [DisplayName("Recovery Time Limit")]
        public ushort RecoveryTimeLimit
        {
            get { return Bits.BigEndian(_RecoveryTimeLimit); }
            set { _RecoveryTimeLimit = Bits.BigEndian(value); }
        }
    }
}