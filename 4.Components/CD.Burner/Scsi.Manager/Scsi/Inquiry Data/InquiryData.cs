using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public abstract class InquiryData : IMarshalable
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte PERIPHERAL_DEVICE_TYPE_MASK = 0x1F;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte PERIPHERAL_QUALIFIER_MASK = 0xE0;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly IntPtr BYTE0_OFFSET =
            Marshal.OffsetOf(typeof (InquiryData), "byte0");


        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte0;

        public PeripheralQualifier PeripheralQualifier
        {
            get { return (PeripheralQualifier) Bits.GetValueMask(byte0, 5, PERIPHERAL_QUALIFIER_MASK); }
            set { byte0 = Bits.PutValueMask(byte0, (byte) value, 5, PERIPHERAL_QUALIFIER_MASK); }
        }

        public PeripheralDeviceType PeripheralDeviceType
        {
            get { return (PeripheralDeviceType) Bits.GetValueMask(byte0, 0, PERIPHERAL_DEVICE_TYPE_MASK); }
            set { byte0 = Bits.PutValueMask(byte0, (byte) value, 0, PERIPHERAL_DEVICE_TYPE_MASK); }
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

        protected virtual void MarshalFrom(BufferWithSize buffer)
        {
            byte0 = buffer.Read<byte>(BYTE0_OFFSET);
        }

        protected virtual void MarshalTo(BufferWithSize buffer)
        {
            buffer.Write(byte0, BYTE0_OFFSET);
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected virtual int MarshaledSize
        {
            get { return Marshaler.DefaultSizeOf<InquiryData>(); }
        }
    }

    public enum PeripheralDeviceType : byte
    {
        DirectAccessBlockDevice = 0x00,
        SequentialAccessDevice = 0x01,
        PrinterDevice = 0x02,
        ProcessorDevice = 0x03,
        WriteOnceDevice = 0x04,
        CDDvdDevice = 0x05,
        [Obsolete] ScannerDevice = 0x06,
        OpticalMemoryDevice = 0x07,
        MediaChangerDevice = 0x08,
        [Obsolete] CommunicationsDevice = 0x09,
        //Obsolete: = 0x0A,
        //Obsolete: = 0x0B,
        StorageArrayControllerDevice = 0x0C,
        EnclosureServicesDevice = 0x0D,
        SimplifiedDirectAccessDevice = 0x0E,
        OpticalCardReaderWriterDevice = 0x0F,
        BridgeControllerCommands = 0x10,
        ObjectBasedStorageDevice = 0x11,
        AutomationDriveInterface = 0x12,
        SecurityManagerDevice = 0x13,
        WellKnownLogicalUnit = 0x1E,
        Unknown = 0x1F,
    }

    public enum PeripheralQualifier : byte
    {
        UnknownOrConnected = 0x0,
        NotConnectedButSupported = 0x1,
        NotSupported = 0x3,
    }
}