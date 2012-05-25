using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class PerformanceData : IMarshalable
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly IntPtr PERFORMANCE_DATA_LENGTH_OFFSET
            = Marshal.OffsetOf(typeof (PerformanceData), "_PerformanceDataLength");

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly IntPtr BYTE_4_OFFSET =
            Marshal.OffsetOf(typeof (PerformanceData), "_byte4");

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly IntPtr BYTE_5_OFFSET =
            Marshal.OffsetOf(typeof (PerformanceData), "byte5");

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly IntPtr BYTE_6_OFFSET =
            Marshal.OffsetOf(typeof (PerformanceData), "byte6");

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly IntPtr BYTE_7_OFFSET =
            Marshal.OffsetOf(typeof (PerformanceData), "byte7");

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly IntPtr PERFORMANCE_DESCRIPTORS_OFFSET
            = Marshal.OffsetOf(typeof (PerformanceData), "_PerformanceDescriptors");

        public PerformanceData()
        {
        }

        internal PerformanceData(PerformanceType type, PerformanceDataType dataType)
        {
            performanceTypeToBeMarshaled = type;
            performanceDataTypeToBeMarshaled = dataType;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private int _PerformanceDataLength;

        public int PerformanceDataLength
        {
            get { return Bits.BigEndian(_PerformanceDataLength); }
            set { _PerformanceDataLength = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _byte4;

        public bool Write
        {
            get { return Bits.GetBit(_byte4, 1); }
            set { _byte4 = Bits.SetBit(_byte4, 1, value); }
        }

        public bool Except
        {
            get { return Bits.GetBit(_byte4, 0); }
            set { _byte4 = Bits.SetBit(_byte4, 0, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte5;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte6;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte7;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private PerformanceDescriptor[] _PerformanceDescriptors;

        public PerformanceDescriptor[] PerformanceDescriptors
        {
            get { return _PerformanceDescriptors; }
            set { _PerformanceDescriptors = value; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private PerformanceType performanceTypeToBeMarshaled;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private PerformanceDataType performanceDataTypeToBeMarshaled;

        protected virtual void MarshalFrom(BufferWithSize buffer)
        {
            _PerformanceDataLength = buffer.Read<int>(PERFORMANCE_DATA_LENGTH_OFFSET);
            _byte4 = buffer.Read<byte>(BYTE_4_OFFSET);
            byte5 = buffer.Read<byte>(BYTE_5_OFFSET);
            byte6 = buffer.Read<byte>(BYTE_6_OFFSET);
            byte7 = buffer.Read<byte>(BYTE_7_OFFSET);
            BufferWithSize descriptorsBuffer = buffer.ExtractSegment(PERFORMANCE_DESCRIPTORS_OFFSET);
            switch (performanceTypeToBeMarshaled)
            {
                case PerformanceType.Performance:
                    switch (performanceDataTypeToBeMarshaled.Performance.Except)
                    {
                        case ExceptionList.NominalPerformanceParameters:
                            int nominalSize = Marshaler.DefaultSizeOf<NominalPerformanceDescriptor>();
                            PerformanceDescriptors = new NominalPerformanceDescriptor[PerformanceDataLength/nominalSize];
                            for (int i = 0; i < PerformanceDescriptors.Length; i++)
                            {
                                PerformanceDescriptors[i] =
                                    Marshaler.PtrToStructure<NominalPerformanceDescriptor>(
                                        descriptorsBuffer.ExtractSegment(nominalSize*i, nominalSize));
                            }
                            break;
                        case ExceptionList.EntirePerformanceExceptionList:
                        case ExceptionList.OutlyingPerformanceExceptions:
                            int exceptionSize = Marshaler.DefaultSizeOf<ExceptionsPerformanceDescriptor>();
                            PerformanceDescriptors =
                                new ExceptionsPerformanceDescriptor[PerformanceDataLength/exceptionSize];
                            for (int i = 0; i < PerformanceDescriptors.Length; i++)
                            {
                                PerformanceDescriptors[i] =
                                    Marshaler.PtrToStructure<ExceptionsPerformanceDescriptor>(
                                        descriptorsBuffer.ExtractSegment(exceptionSize*i, exceptionSize));
                            }
                            break;
                        default:
                            throw new InvalidOperationException("Invalid performance data type.");
                    }
                    break;
                case PerformanceType.UnusableArea:
                    int uadSize = Marshaler.DefaultSizeOf<UnusableAreaDescriptor>();
                    PerformanceDescriptors = new UnusableAreaDescriptor[PerformanceDataLength/uadSize];
                    for (int i = 0; i < PerformanceDescriptors.Length; i++)
                    {
                        PerformanceDescriptors[i] =
                            Marshaler.PtrToStructure<UnusableAreaDescriptor>(descriptorsBuffer.ExtractSegment(
                                                                                 uadSize*i, uadSize));
                    }
                    break;
                case PerformanceType.DefectStatusData:
                    int dfdSize = Marshaler.DefaultSizeOf<DefectStatusDescriptor>();
                    PerformanceDescriptors = new DefectStatusDescriptor[PerformanceDataLength/dfdSize];
                    for (int i = 0; i < PerformanceDescriptors.Length; i++)
                    {
                        PerformanceDescriptors[i] =
                            Marshaler.PtrToStructure<DefectStatusDescriptor>(descriptorsBuffer.ExtractSegment(
                                                                                 dfdSize*i, dfdSize));
                    }
                    break;
                case PerformanceType.WriteSpeed:
                    int wsdSize = Marshaler.DefaultSizeOf<WriteSpeedDescriptor>();
                    PerformanceDescriptors = new WriteSpeedDescriptor[PerformanceDataLength/wsdSize];
                    for (int i = 0; i < PerformanceDescriptors.Length; i++)
                    {
                        PerformanceDescriptors[i] =
                            Marshaler.PtrToStructure<WriteSpeedDescriptor>(descriptorsBuffer.ExtractSegment(wsdSize*i,
                                                                                                            wsdSize));
                    }
                    break;
                case PerformanceType.DefectiveBlockInformation:
                    throw new NotImplementedException();
                case PerformanceType.DefectiveBlockInformationCacheZone:
                    throw new NotImplementedException();
                default:
                    throw new InvalidOperationException("Invalid performance type.");
            }
        }

        protected virtual void MarshalTo(BufferWithSize buffer)
        {
            throw new NotSupportedException();
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected virtual int MarshaledSize
        {
            get
            {
                var size = (int) PERFORMANCE_DESCRIPTORS_OFFSET;
                if (PerformanceDescriptors != null)
                {
                    for (int i = 0; i < PerformanceDescriptors.Length; i++)
                    {
                        size += Marshaler.SizeOf(PerformanceDescriptors[i]);
                    }
                }
                return size;
            }
        }

        internal static int ReadPerformanceDataLength(BufferWithSize buffer)
        {
            return Bits.BigEndian(buffer.Read<int>(PERFORMANCE_DATA_LENGTH_OFFSET));
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