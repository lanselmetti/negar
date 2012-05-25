using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi
{
    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    public sealed class StandardInquiryData : InquiryData
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly char[] TRIM_CHARS = new[] {'\0', ' '};
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] public static readonly int MinimumSize = 36;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly IntPtr BYTE1_OFFSET =
            Marshal.OffsetOf(typeof (StandardInquiryData), "byte1");

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly IntPtr VERSION_OFFSET =
            Marshal.OffsetOf(typeof (StandardInquiryData), "_Version");

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly IntPtr BYTE3_OFFSET =
            Marshal.OffsetOf(typeof (StandardInquiryData), "byte3");

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] internal static readonly IntPtr ADDITIONAL_LENGTH_OFFSET =
            Marshal.OffsetOf(typeof (StandardInquiryData), "_AdditionalLength");

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly IntPtr BYTE5_OFFSET =
            Marshal.OffsetOf(typeof (StandardInquiryData), "byte5");

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly IntPtr BYTE6_OFFSET =
            Marshal.OffsetOf(typeof (StandardInquiryData), "byte6");

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly IntPtr BYTE7_OFFSET =
            Marshal.OffsetOf(typeof (StandardInquiryData), "byte7");

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly IntPtr VENDOR_IDENTIFICATION_OFFSET =
            Marshal.OffsetOf(typeof (StandardInquiryData), "_VendorIdentification");

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly IntPtr PRODUCT_IDENTIFICATION_OFFSET =
            Marshal.OffsetOf(typeof (StandardInquiryData), "_ProductIdentification");

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly IntPtr PRODUCT_REVISION_LEVEL_OFFSET =
            Marshal.OffsetOf(typeof (StandardInquiryData), "_ProductRevisionLevel");

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly IntPtr VENDOR_SPECIFIC_OFFSET =
            Marshal.OffsetOf(typeof (StandardInquiryData), "_VendorSpecific");

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly IntPtr BYTE56_OFFSET =
            Marshal.OffsetOf(typeof (StandardInquiryData), "byte56");

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly IntPtr BYTE57_OFFSET =
            Marshal.OffsetOf(typeof (StandardInquiryData), "byte57");

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly IntPtr VERSION_DESCRIPTORS_OFFSET =
            Marshal.OffsetOf(typeof (StandardInquiryData), "_VersionDescriptors");

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly IntPtr RESERVED74_TO95_OFFSET =
            Marshal.OffsetOf(typeof (StandardInquiryData), "reserved74To95");

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly IntPtr
            VENDOR_SPECIFIC_PARAMETERS_OFFSET = Marshal.OffsetOf(typeof (StandardInquiryData),
                                                                 "_VendorSpecificParameters");

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte VENDOR_IDENTIFICATION_LENGTH = 8;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte PRODUCT_IDENTIFICATION_LENGTH = 16;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte PRODUCT_REVISION_LENGTH = 4;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte RESPONSE_DATA_FORMAT_MASK = 0x0F;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte TARGET_PORT_GROUP_SUPPORT_MASK = 0x30;


        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte1;

        public bool RemovableMedium
        {
            get { return Bits.GetBit(byte1, 7); }
            set { byte1 = Bits.SetBit(byte1, 7, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private DeviceVersion _Version;

        public DeviceVersion Version
        {
            get { return _Version; }
            set { _Version = value; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte3;

        public bool AsynchronousEventReportingCapability
        {
            get { return Bits.GetBit(byte3, 7); }
            set { byte3 = Bits.SetBit(byte3, 7, value); }
        }

        public bool NormalACA
        {
            get { return Bits.GetBit(byte3, 6); }
            set { byte3 = Bits.SetBit(byte3, 6, value); }
        }

        public bool HierarchicalSupport
        {
            get { return Bits.GetBit(byte3, 5); }
            set { byte3 = Bits.SetBit(byte3, 5, value); }
        }

        public byte ResponseDataFormat
        {
            get { return Bits.GetValueMask(byte3, 0, RESPONSE_DATA_FORMAT_MASK); }
            set { byte3 = Bits.PutValueMask(byte3, value, 0, RESPONSE_DATA_FORMAT_MASK); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _AdditionalLength;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte5;

        public bool EmbeddedStorageArrayControlComponentSupported
        {
            get { return Bits.GetBit(byte5, 7); }
            set { byte5 = Bits.SetBit(byte5, 7, value); }
        }

        public bool AccessControlsCoordinator
        {
            get { return Bits.GetBit(byte5, 6); }
            set { byte5 = Bits.SetBit(byte5, 6, value); }
        }

        public TargetPortGroupSupport TargetPortGroupSupport
        {
            get { return (TargetPortGroupSupport) Bits.GetValueMask(byte5, 4, TARGET_PORT_GROUP_SUPPORT_MASK); }
            set { byte5 = Bits.PutValueMask(byte5, (byte) value, 4, TARGET_PORT_GROUP_SUPPORT_MASK); }
        }

        public bool ThirdPartyCopy
        {
            get { return Bits.GetBit(byte5, 3); }
            set { byte5 = Bits.SetBit(byte5, 3, value); }
        }

        public bool Protect
        {
            get { return Bits.GetBit(byte5, 0); }
            set { byte5 = Bits.SetBit(byte5, 0, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte6;

        public bool BasicQueuing
        {
            get { return Bits.GetBit(byte6, 7); }
            set { byte6 = Bits.SetBit(byte6, 7, value); }
        }

        public bool EnclosureServices
        {
            get { return Bits.GetBit(byte6, 6); }
            set { byte6 = Bits.SetBit(byte6, 6, value); }
        }

        public bool MultiPort
        {
            get { return Bits.GetBit(byte6, 4); }
            set { byte6 = Bits.SetBit(byte6, 4, value); }
        }

        public bool MediumChanger
        {
            get { return Bits.GetBit(byte6, 3); }
            set { byte6 = Bits.SetBit(byte6, 3, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte7;

        public bool RelativeAddressing
        {
            get { return Bits.GetBit(byte7, 7); }
            set { byte7 = Bits.SetBit(byte7, 7, value); }
        }

        public bool Linked
        {
            get { return Bits.GetBit(byte7, 3); }
            set { byte7 = Bits.SetBit(byte7, 3, value); }
        }

        public bool CommandQueuing
        {
            get { return Bits.GetBit(byte7, 1); }
            set { byte7 = Bits.SetBit(byte7, 1, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)] private
            string _VendorIdentification;

        public string VendorIdentification
        {
            get { return _VendorIdentification; }
            set { _VendorIdentification = value; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)] private
            string _ProductIdentification;

        public string ProductIdentification
        {
            get { return _ProductIdentification; }
            set { _ProductIdentification = value; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)] private
            string _ProductRevisionLevel;

        public string ProductRevisionLevel
        {
            get { return _ProductRevisionLevel; }
            set { _ProductRevisionLevel = value; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)] private
            byte[] _VendorSpecific = new byte[20];

        public byte[] VendorSpecific
        {
            get { return _VendorSpecific; }
            set { _VendorSpecific = value; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte56;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte57;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private VersionDescriptorCollection _VersionDescriptors;

        public VersionDescriptorCollection VersionDescriptors
        {
            get { return _VersionDescriptors; }
            set { _VersionDescriptors = value; }
        }

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)] private byte[] reserved74To95;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)] private
            byte[] _VendorSpecificParameters = new byte[0];

        public byte[] VendorSpecificParameters
        {
            get { return _VendorSpecificParameters; }
        }

        protected override void MarshalFrom(BufferWithSize buffer)
        {
            base.MarshalFrom(buffer);
            byte1 = buffer.Read<byte>(BYTE1_OFFSET);
            _Version = buffer.Read<DeviceVersion>(VERSION_OFFSET);
            byte3 = buffer.Read<byte>(BYTE3_OFFSET);
            _AdditionalLength = buffer.Read<byte>(ADDITIONAL_LENGTH_OFFSET);
            byte5 = buffer.Read<byte>(BYTE5_OFFSET);
            byte6 = buffer.Read<byte>(BYTE6_OFFSET);
            byte7 = buffer.Read<byte>(BYTE7_OFFSET);
            _VendorIdentification = buffer.ToStringAnsi((int) VENDOR_IDENTIFICATION_OFFSET, 8).TrimEnd(TRIM_CHARS);
            _ProductIdentification = buffer.ToStringAnsi((int) PRODUCT_IDENTIFICATION_OFFSET, 16).TrimEnd(TRIM_CHARS);
            _ProductRevisionLevel = buffer.ToStringAnsi((int) PRODUCT_REVISION_LEVEL_OFFSET, 4).TrimEnd(TRIM_CHARS);
            if (buffer.Length32 > (int) VENDOR_SPECIFIC_OFFSET)
            {
                _VendorSpecific = new byte[20];
                buffer.CopyTo((int) VENDOR_SPECIFIC_OFFSET, _VendorSpecific, 0, _VendorSpecific.Length);
            }
            if (buffer.Length32 > (int) BYTE56_OFFSET)
            {
                byte56 = buffer.Read<byte>(BYTE56_OFFSET);
            }
            if (buffer.Length32 > (int) BYTE57_OFFSET)
            {
                byte57 = buffer.Read<byte>(BYTE57_OFFSET);
            }
            if (buffer.Length32 > (int) VERSION_DESCRIPTORS_OFFSET)
            {
                _VersionDescriptors =
                    Marshaler.PtrToStructure<VersionDescriptorCollection>(
                        buffer.ExtractSegment(VERSION_DESCRIPTORS_OFFSET));
            }
            if (buffer.Length32 > (int) RESERVED74_TO95_OFFSET)
            {
                reserved74To95 = new byte[Math.Min(22, buffer.Length32 - (int) RESERVED74_TO95_OFFSET)];
                buffer.CopyTo((int) RESERVED74_TO95_OFFSET, reserved74To95, 0, reserved74To95.Length);
            }
            if (buffer.Length32 > (int) VENDOR_SPECIFIC_PARAMETERS_OFFSET)
            {
                _VendorSpecificParameters =
                    new byte[_AdditionalLength + 4 + 1 - (int) VENDOR_SPECIFIC_PARAMETERS_OFFSET];
                buffer.CopyTo(VENDOR_SPECIFIC_PARAMETERS_OFFSET, _VendorSpecificParameters, IntPtr.Zero,
                              (IntPtr) _VendorSpecificParameters.Length);
            }
        }

        protected override void MarshalTo(BufferWithSize buffer)
        {
            throw new NotSupportedException("This operation is never needed and is not supported.");
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected override int MarshaledSize
        {
            get { throw new NotSupportedException("This operation is never needed and is not supported."); }
        }

        public static byte ReadAdditionalLength(BufferWithSize buffer)
        {
            return Bits.BigEndian(buffer.Read<byte>(ADDITIONAL_LENGTH_OFFSET));
        }
    }

    public enum DeviceVersion : byte
    {
        Nonstandard = 0x00,
        ScsiPrimaryCommands = 0x03,
        ScsiPrimaryCommands2 = 0x04,
        ScsiPrimaryCommands3 = 0x05,
        ScsiPrimaryCommands4 = 0x06,
    }

    public enum TargetPortGroupSupport : byte
    {
        NoneSupported = 0x00,
        ImplicitAsymmetricLogicalAccessSupported = 0x01,
        ExplicitAsymmetricLogicalAccessSupported = 0x02,
        ImplicitAndExplicitAsymmetricLogicalAccessSupported = 0x03,
    }
}