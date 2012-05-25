using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class GetConfigurationCommand : FixedLengthScsiCommand
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte REQUEST_TYPE_MASK = 0x03;

        public GetConfigurationCommand() : base(ScsiCommandCode.GetConfiguration)
        {
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte1;

        public FeatureRequestType RequestType
        {
            get { return (FeatureRequestType) Bits.GetValueMask(byte1, 0, REQUEST_TYPE_MASK); }
            set { byte1 = Bits.PutValueMask(byte1, (byte) value, 0, REQUEST_TYPE_MASK); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private FeatureCode _StartingFeatureNumber;

        public FeatureCode StartingFeatureNumber
        {
            get { return Bits.BigEndian(_StartingFeatureNumber); }
            set { _StartingFeatureNumber = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte4;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte5;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte6;
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