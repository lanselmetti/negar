using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public abstract class VitalProductDataInquiryData : InquiryData
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly IntPtr PAGE_LENGTH_OFFSET =
            Marshal.OffsetOf(typeof (VitalProductDataInquiryData), "_PageLength");

        protected VitalProductDataInquiryData(VitalProductDataPageCode pageCode)
        {
            PageCode = pageCode;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private VitalProductDataPageCode _PageCode;

        public VitalProductDataPageCode PageCode
        {
            get { return _PageCode; }
            private set { _PageCode = value; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte2;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _PageLength;

        public byte PageLength
        {
            get { return Bits.BigEndian(_PageLength); }
            protected set { _PageLength = Bits.BigEndian(value); }
        }

        internal static byte ReadPageLength(BufferWithSize buffer)
        {
            return buffer.Read<byte>(PAGE_LENGTH_OFFSET);
        }
    }

    public enum VitalProductDataPageCode : byte
    {
        SupportedVitalProductDataPages = 0x00,
        DeviceInformation = 0x83,
        SoftwareInterfaceIdentification = 0x84,
        ManagementNetworkAddresses = 0x85,
        ExtendedInquiryData = 0x86,
        ModePagePolicy = 0x87,
        ScsiPorts = 0x88,
        AdvancedTechnologyAttachmentInformation = 0x89,
        ProtocolSpecificLogicalUnitInformation = 0x90,
        ProtocolSpecificPortInformation = 0x91,
        BlockLimits = 0xB0,
    }
}