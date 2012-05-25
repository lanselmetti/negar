using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Threading;
using Helper;
using Helper.IO;
using Microsoft.Win32.SafeHandles;
using Scsi.Multimedia;

namespace Scsi
{
    /// <summary>The Windows Scsi Pass-Through Interface. This uses a file handle (obtainable through instantiating a <see cref="Win32FileStream"/> object with read/write access) to send I/O control codes to the underlying Scsi device.</summary>
    //[DebuggerStepThrough]
    public class Win32Spti : IScsiPassThrough
    {
        private static Converter<Exception, string> GetExceptionMessage;
        private static Action<Exception, string> SetExceptionMessage;

        private int _Alignment = -1;
        private int _MaximumDataTransferBlockCount; //uninitialized
        private byte[] buffer;
        private SafeFileHandle deviceHandle;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private bool leaveDeviceOpen;

        #region I/O Control Codes

        // I/O Control Code Format
        // Bit:   [  31  ] [30 ..... 16] [15 ......... 14] [  13  ] [12 ....... 02] [01 ....... 00]
        // Value: [Common] [Device type] [Required access] [Custom] [Function code] [Transfer type]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const int FILE_DEVICE_CD_ROM = 0x00000002;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const int FILE_DEVICE_FILE_SYSTEM = 0x00000009;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const int FILE_DEVICE_MASS_STORAGE = 0x0000002D;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const int FSCTL_DISMOUNT_VOLUME =
            FILE_DEVICE_FILE_SYSTEM << 16 | 0 << 14 | 0x0008 << 2 | 0;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const int FSCTL_IS_VOLUME_MOUNTED =
            FILE_DEVICE_FILE_SYSTEM << 16 | 0 << 14 | 0x000A << 2 | 0;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const int FSCTL_LOCK_VOLUME =
            FILE_DEVICE_FILE_SYSTEM << 16 | 0 << 14 | 0x0006 << 2 | 0;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const int FSCTL_UNLOCK_VOLUME =
            FILE_DEVICE_FILE_SYSTEM << 16 | 0 << 14 | 0x0007 << 2 | 0;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const int IOCTL_CDROM_BASE = FILE_DEVICE_CD_ROM;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const int IOCTL_CDROM_GET_CONFIGURATION =
            IOCTL_CDROM_BASE << 16 | 1 << 14 | 0x0016 << 2 | 0;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const int IOCTL_CDROM_GET_INQUIRY_DATA =
            IOCTL_CDROM_BASE << 16 | 1 << 14 | 0x0019 << 2 | 0;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const int IOCTL_SCSI_BASE = 0x00000004;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const int IOCTL_SCSI_GET_ADDRESS =
            IOCTL_SCSI_BASE << 16 | 0 << 14 | 0x0406 << 2 | 0;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const int IOCTL_SCSI_GET_CAPABILITIES =
            IOCTL_SCSI_BASE << 16 | 0 << 14 | 0x0404 << 2 | 0;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const int IOCTL_SCSI_GET_INQUIRY_DATA =
            IOCTL_SCSI_BASE << 16 | 0 << 14 | 0x0403 << 2 | 0;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const int IOCTL_SCSI_MINIPORT =
            IOCTL_SCSI_BASE << 16 | 3 << 14 | 0x0402 << 2 | 0;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const int IOCTL_SCSI_PASS_THROUGH =
            IOCTL_SCSI_BASE << 16 | 3 << 14 | 0x0401 << 2 | 0;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const int IOCTL_SCSI_PASS_THROUGH_DIRECT =
            IOCTL_SCSI_BASE << 16 | 3 << 14 | 0x0405 << 2 | 0;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const int IOCTL_STORAGE_BASE =
            FILE_DEVICE_MASS_STORAGE;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const int IOCTL_STORAGE_CHECK_VERIFY =
            IOCTL_STORAGE_BASE << 16 | 1 << 14 | 0x0200 << 2 | 0;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const int IOCTL_STORAGE_CHECK_VERIFY2 =
            IOCTL_STORAGE_BASE << 16 | 0 << 14 | 0x0200 << 2 | 0;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const int IOCTL_STORAGE_GET_MEDIA_TYPES =
            IOCTL_STORAGE_BASE << 16 | 0 << 14 | 0x0300 << 2 | 0;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const int IOCTL_STORAGE_GET_MEDIA_TYPES_EX =
            IOCTL_STORAGE_BASE << 16 | 0 << 14 | 0x0301 << 2 | 0;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const int IOCTL_STORAGE_MCN_CONTROL =
            IOCTL_STORAGE_BASE << 16 | 0 << 14 | 0x0251 << 2 | 0;

        //IOCTL_STORAGE_EJECT_MEDIA CTL_CODE(IOCTL_STORAGE_BASE, 0x0202, METHOD_BUFFERED, FILE_READ_ACCESS)
        //IOCTL_STORAGE_EJECTION_CONTROL CTL_CODE(IOCTL_STORAGE_BASE, 0x0250, METHOD_BUFFERED, FILE_ANY_ACCESS)
        //IOCTL_STORAGE_FIND_NEW_DEVICES CTL_CODE(IOCTL_STORAGE_BASE, 0x0206, METHOD_BUFFERED, FILE_READ_ACCESS)
        //IOCTL_STORAGE_GET_DEVICE_NUMBER CTL_CODE(IOCTL_STORAGE_BASE, 0x0420, METHOD_BUFFERED, FILE_ANY_ACCESS)
        //IOCTL_STORAGE_GET_MEDIA_SERIAL_NUMBER CTL_CODE(IOCTL_STORAGE_BASE, 0x0304, METHOD_BUFFERED, FILE_ANY_ACCESS)
        //IOCTL_STORAGE_LOAD_MEDIA CTL_CODE(IOCTL_STORAGE_BASE, 0x0203, METHOD_BUFFERED, FILE_READ_ACCESS)
        //IOCTL_STORAGE_LOAD_MEDIA2 CTL_CODE(IOCTL_STORAGE_BASE, 0x0203, METHOD_BUFFERED, FILE_ANY_ACCESS)
        //IOCTL_STORAGE_MEDIA_REMOVAL CTL_CODE(IOCTL_STORAGE_BASE, 0x0201, METHOD_BUFFERED, FILE_READ_ACCESS)
        //IOCTL_STORAGE_PREDICT_FAILURE CTL_CODE(IOCTL_STORAGE_BASE, 0x0440, METHOD_BUFFERED, FILE_ANY_ACCESS)
        //IOCTL_STORAGE_RELEASE CTL_CODE(IOCTL_STORAGE_BASE, 0x0205, METHOD_BUFFERED, FILE_READ_ACCESS)
        //IOCTL_STORAGE_RESERVE CTL_CODE(IOCTL_STORAGE_BASE, 0x0204, METHOD_BUFFERED, FILE_READ_ACCESS)
        //IOCTL_STORAGE_GET_HOTPLUG_INFO CTL_CODE(IOCTL_STORAGE_BASE, 0x0305, METHOD_BUFFERED, FILE_ANY_ACCESS)
        //IOCTL_STORAGE_SET_HOTPLUG_INFO CTL_CODE(IOCTL_STORAGE_BASE, 0x0306, METHOD_BUFFERED, FILE_READ_ACCESS | FILE_WRITE_ACCESS)
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const int IOCTL_STORAGE_QUERY_PROPERTY =
            IOCTL_STORAGE_BASE << 16 | 0 << 14 | 0x0500 << 2 | 0;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const int IOCTL_STORAGE_RESET_BUS =
            IOCTL_STORAGE_BASE << 16 | 3 << 14 | 0x0400 << 2 | 0;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const int IOCTL_STORAGE_RESET_DEVICE =
            IOCTL_STORAGE_BASE << 16 | 3 << 14 | 0x0401 << 2 | 0;

        #endregion

        public Win32Spti(SafeFileHandle deviceHandle, bool leaveDeviceOpen) : this(deviceHandle, leaveDeviceOpen, true)
        {
        }

        public Win32Spti(SafeFileHandle deviceHandle, bool leaveDeviceOpen, bool passThroughDirect)
        {
            this.deviceHandle = deviceHandle;
            this.leaveDeviceOpen = leaveDeviceOpen;
            UseDirectIO = passThroughDirect;
        }

        public bool UseDirectIO { get; set; }

        private ScsiAddress Address
        {
            get
            {
                ScsiAddress address;
                unsafe
                {
                    int bytesReturned;
                    if (
                        DeviceIoControl(deviceHandle, IOCTL_SCSI_GET_ADDRESS, IntPtr.Zero, 0, (IntPtr) (&address),
                                        Marshaler.DefaultSizeOf<ScsiAddress>(), out bytesReturned, IntPtr.Zero) == 0)
                    {
                        ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
                    }
                }
                if (address.Length < Marshaler.DefaultSizeOf<ScsiAddress>())
                {
                    throw new InvalidOperationException("The device did not return as much information as required.");
                }
                return address;
            }
        }

        private IOScsiCapabilities Capabilities
        {
            get
            {
                IOScsiCapabilities result;
                int temp;
                unsafe
                {
                    if (
                        DeviceIoControl(deviceHandle, IOCTL_SCSI_GET_CAPABILITIES, IntPtr.Zero, 0, (IntPtr) (&result),
                                        Marshaler.DefaultSizeOf<IOScsiCapabilities>(), out temp, IntPtr.Zero) == 0)
                    {
                        ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
                    }
                }
                return result;
            }
        }

        #region IScsiPassThrough Members

        /// <returns>Checks whether the mounted medium has changed. If the value is negative, then the medium has probably changed. If the value is zero, the medium has probably not changed. If the value is positive, it represents the media change count; compare it with a previous value to detect changes.</returns>
        public int CheckVerify()
        {
            unsafe
            {
                int mcn;
                int bytesReturned;
                if (
                    DeviceIoControl(deviceHandle, IOCTL_STORAGE_CHECK_VERIFY, IntPtr.Zero, 0, (IntPtr) (&mcn),
                                    sizeof (uint), out bytesReturned, IntPtr.Zero) == 0)
                {
                    int le = Marshal.GetLastWin32Error();
                    if (le != 1110 && le != 1117 && le != 21)
                    {
                        ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
                    }
                    else
                    {
                        mcn = -1;
                    }
                }
                return mcn;
            }
        }

        /// <returns>Checks whether the medium has changed. If the value is negative, then the medium has probably changed. If the value is zero, the medium has probably not changed. If the value is positive, it represents the media change count; compare it with a previous value to detect changes.</returns>
        public int CheckVerify2()
        {
            unsafe
            {
                int mcn;
                int bytesReturned;
                if (
                    DeviceIoControl(deviceHandle, IOCTL_STORAGE_CHECK_VERIFY2, IntPtr.Zero, 0, (IntPtr) (&mcn),
                                    sizeof (uint), out bytesReturned, IntPtr.Zero) == 0)
                {
                    int le = Marshal.GetLastWin32Error();
                    if (le != 1110 && le != 1117 && le != 21)
                    {
                        ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
                    }
                    else
                    {
                        mcn = -1;
                    }
                }
                return mcn;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void DismountVolume()
        {
            int temp;
            if (
                DeviceIoControl(deviceHandle, FSCTL_DISMOUNT_VOLUME, IntPtr.Zero, 0, IntPtr.Zero, 0, out temp,
                                IntPtr.Zero) == 0)
            {
                ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
            }
        }

        public bool IsVolumeMounted()
        {
            int temp;
            return
                DeviceIoControl(deviceHandle, FSCTL_IS_VOLUME_MOUNTED, IntPtr.Zero, 0, IntPtr.Zero, 0, out temp,
                                IntPtr.Zero) != 0;
        }

        public void LockVolume()
        {
            int temp;
            if (
                DeviceIoControl(deviceHandle, FSCTL_LOCK_VOLUME, IntPtr.Zero, 0, IntPtr.Zero, 0, out temp, IntPtr.Zero) ==
                0)
            {
                ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
            }
        }

        public void UnlockVolume()
        {
            int temp;
            if (
                DeviceIoControl(deviceHandle, FSCTL_UNLOCK_VOLUME, IntPtr.Zero, 0, IntPtr.Zero, 0, out temp, IntPtr.Zero) ==
                0)
            {
                ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
            }
        }

        //[DebuggerHidden]
        public ScsiStatus ExecuteCommand(BufferWithSize cdb, DataTransferDirection direction, byte pathId, byte targetId,
                                         byte logicalUnitNumber, BufferWithSize data, uint timeout, bool autoSense,
                                         out SenseData senseData)
        {
            unsafe
            {
                ScsiPassThroughDirect* pSPTD;

                int bufferSize = ScsiPassThroughDirect.DEFAULT_SIZE_WITH_SENSE_BUFFER +
                                 (UseDirectIO ? 0 : data.Length32);

                bool stackAlloc = Marshaler.ShouldStackAlloc(bufferSize);

                fixed (byte* pBufferFixedBefore = buffer)
                {
                    if (stackAlloc)
                    {
                        byte* pBuffer = stackalloc byte[bufferSize];
                        pSPTD = (ScsiPassThroughDirect*) pBuffer;
                    }
                    else
                    {
                        if (buffer == null || buffer.Length < bufferSize)
                        {
                            Array.Resize(ref buffer, bufferSize);
                        }

                        //IGNORE THIS ASSIGNMENT!!! It's just to make the compiler happy!!
                        //pSPTD is really set inside the NEXT fixed block!
                        pSPTD = null;
                    }

                    //These two fixed pointers very well point to different places;
                    //In fact, either or both could be null.
                    //However, this code is optimized for performance and minimizes heap allocations.
                    fixed (byte* pBufferFixedAfter = buffer)
                    {
                        if (!stackAlloc)
                        {
                            pSPTD = (ScsiPassThroughDirect*) pBufferFixedAfter;
                        }

                        *pSPTD = new ScsiPassThroughDirect
                                     {
                                         Length = (ushort) ScsiPassThroughDirect.SENSE_BUFFER_OFFSET,
                                         ScsiStatus = ~(ScsiStatus) 0,
                                         SenseInfoLength =
                                             autoSense ? (byte) ScsiPassThroughDirect.DEFAULT_SENSE_SIZE : (byte) 0,
                                         DataIn = direction,
                                         PathId = pathId,
                                         LogicalUnitNumber = logicalUnitNumber,
                                         TargetId = targetId,
                                         TimeoutValue = timeout,
                                         CdbLength = (byte) cdb.Length,
                                         DataTransferBlockCount = data.LengthU32,
                                     };
                        pSPTD->SenseInfoOffset = autoSense ? pSPTD->Length : (byte) 0;
                        BufferWithSize.Copy(cdb, 0, new BufferWithSize(pSPTD->Cdb, pSPTD->CdbLength), 0, cdb.Length32);

                        if (UseDirectIO)
                        {
                            pSPTD->DataBuffer = data.Address;
                        }
                        else
                        {
                            //It's not a buffer, it's an offset now
                            pSPTD->DataBuffer =
                                (IntPtr)
                                Math.Max(ScsiPassThroughDirect.SENSE_BUFFER_OFFSET,
                                         pSPTD->SenseInfoOffset + pSPTD->SenseInfoLength);
                            if (direction == DataTransferDirection.SendData)
                            {
                                BufferWithSize.Copy(data, UIntPtr.Zero,
                                                    new BufferWithSize((byte*) pSPTD + (int) pSPTD->DataBuffer,
                                                                       pSPTD->DataTransferBlockCount), UIntPtr.Zero,
                                                    data.Length);
                            }
                        }

                        int bytesReturned;
                        if (
                            DeviceIoControl(deviceHandle,
                                            UseDirectIO ? IOCTL_SCSI_PASS_THROUGH_DIRECT : IOCTL_SCSI_PASS_THROUGH,
                                            (IntPtr) pSPTD, bufferSize, (IntPtr) pSPTD, bufferSize, out bytesReturned,
                                            IntPtr.Zero) == 0)
                        {
                            ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
                        }

                        if (!UseDirectIO && direction == DataTransferDirection.ReceiveData)
                        {
                            BufferWithSize.Copy(
                                new BufferWithSize((byte*) pSPTD + (int) pSPTD->DataBuffer,
                                                   pSPTD->DataTransferBlockCount), 0, data, 0,
                                pSPTD->DataTransferBlockCount);
                        }

                        senseData = pSPTD->SenseInfoLength > 0
                                        ? Marshaler.PtrToStructure<SenseData>(
                                              new BufferWithSize((byte*) pSPTD + pSPTD->SenseInfoOffset,
                                                                 /*pSPTD->SenseInfoLength*/
                                                                 bufferSize - pSPTD->SenseInfoOffset))
                                        : new SenseData();
                        return pSPTD->ScsiStatus;
                    }
                }
            }
        }

        //Returns a set (Bus ID, Device Info[]) of pairs
        public KeyValuePair<byte, KeyValuePair<ScsiDeviceInfo, StandardInquiryData>[]>[] GetScsiInquiryData()
        {
            unsafe
            {
                const int ERROR_INSUFFICIENT_BUFFER = 122;
                const int ERROR_MORE_DATA = 234;
                int bytesReturned;
                int bufferSize = Marshaler.DefaultSizeOf<ScsiInquiryData>() +
                                 Marshaler.DefaultSizeOf<StandardInquiryData>();
                byte* pBuffer;
                int lastError;
                do
                {
                    bufferSize <<= 1;
                    {
                        byte* pBuffer2 = stackalloc byte[bufferSize];
                        pBuffer = pBuffer2;
                    }
                    if (
                        DeviceIoControl(deviceHandle, IOCTL_SCSI_GET_INQUIRY_DATA, IntPtr.Zero, 0, (IntPtr) pBuffer,
                                        bufferSize, out bytesReturned, IntPtr.Zero) == 0)
                    {
                        lastError = Marshal.GetLastWin32Error();
                    }
                    else
                    {
                        lastError = 0;
                    }
                } while (lastError == ERROR_INSUFFICIENT_BUFFER | lastError == ERROR_MORE_DATA);

                var buffer = new BufferWithSize(pBuffer, bytesReturned);
                var adapterBuses = Marshaler.PtrToStructure<ScsiAdapterBusInfo>(buffer);
                var result =
                    new KeyValuePair<byte, KeyValuePair<ScsiDeviceInfo, StandardInquiryData>[]>[
                        adapterBuses.BusData.Length];
                for (int i = 0; i < adapterBuses.BusData.Length; i++)
                {
                    ScsiBusData data = adapterBuses.BusData[i];

                    var inqs = new KeyValuePair<ScsiDeviceInfo, StandardInquiryData>[data.NumberOfLogicalUnits];
                    int inqDataOffset = data.InquiryDataOffset;
                    for (int j = 0; j < inqs.Length; j++)
                    {
                        var inq = Marshaler.PtrToStructure<ScsiInquiryData>(buffer.ExtractSegment(inqDataOffset));
                        var stdInq = Marshaler.PtrToStructure<StandardInquiryData>(inq.InquiryData, 0);
                        inqs[j] = new KeyValuePair<ScsiDeviceInfo, StandardInquiryData>(inq.BusInfo, stdInq);
                        inqDataOffset = inq.NextInquiryDataOffset;
                    }
                    result[i] =
                        new KeyValuePair<byte, KeyValuePair<ScsiDeviceInfo, StandardInquiryData>[]>(
                            data.InitiatorBusId, inqs);
                }

                return result;
            }
        }

        public StandardInquiryData ScsiInquiry(bool throwIfNotFound)
        {
            ScsiAddress myAddress = Address;
            KeyValuePair<byte, KeyValuePair<ScsiDeviceInfo, StandardInquiryData>[]>[] data = GetScsiInquiryData();
            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data[i].Value.Length; j++)
                {
                    KeyValuePair<ScsiDeviceInfo, StandardInquiryData> pair = data[i].Value[j];
                    if (myAddress.PathId == pair.Key.PathId && myAddress.TargetId == pair.Key.TargetId &&
                        myAddress.Lun == pair.Key.Lun)
                    {
                        return pair.Value;
                    }
                }
            }
            if (throwIfNotFound)
            {
                throw new InvalidOperationException(
                    string.Format("Could not find device {{{0}}} among the following:" + Environment.NewLine + "{1}",
                                  myAddress, string.Join(", ", Array.ConvertAll(data, d =>
                                                                                          {
                                                                                              var result =
                                                                                                  new string[
                                                                                                      d.Value.Length];
                                                                                              for (int i = 0;
                                                                                                   i < d.Value.Length;
                                                                                                   i++)
                                                                                              {
                                                                                                  result[i] =
                                                                                                      string.Format(
                                                                                                          "{0} {1} {2} ({3}) {{{4}}}",
                                                                                                          VendorIdentifiers
                                                                                                              .
                                                                                                              GetVendorName
                                                                                                              (d.Value[i
                                                                                                                   ].
                                                                                                                   Value
                                                                                                                   .
                                                                                                                   VendorIdentification),
                                                                                                          d.Value[i].
                                                                                                              Value.
                                                                                                              ProductIdentification,
                                                                                                          d.Value[i].
                                                                                                              Value.
                                                                                                              ProductRevisionLevel,
                                                                                                          d.Value[i].
                                                                                                              Value.
                                                                                                              PeripheralDeviceType,
                                                                                                          new ScsiAddress
                                                                                                              (myAddress
                                                                                                                   .
                                                                                                                   PortNumber,
                                                                                                               d.Value[i
                                                                                                                   ].Key
                                                                                                                   .
                                                                                                                   PathId,
                                                                                                               d.Value[i
                                                                                                                   ].Key
                                                                                                                   .
                                                                                                                   TargetId,
                                                                                                               d.Value[i
                                                                                                                   ].Key
                                                                                                                   .Lun));
                                                                                              }
                                                                                              return
                                                                                                  string.Format(
                                                                                                      "• {0}",
                                                                                                      string.Join(
                                                                                                          Environment.
                                                                                                              NewLine,
                                                                                                          result));
                                                                                          }))));
            }
            else
            {
                return null;
            }
        }

        public StandardInquiryData CdromInquiry()
        {
            unsafe
            {
                int bytesReturned;
                int bufferSize = (Marshaler.DefaultSizeOf<StandardInquiryData>() + 1) >> 1;
                byte* pBuffer = stackalloc byte[bufferSize];
                bool success;
                do
                {
                    bufferSize <<= 1;
                    byte* pBuf2 = stackalloc byte[bufferSize];
                    pBuffer = pBuf2;
                    success =
                        DeviceIoControl(deviceHandle, IOCTL_CDROM_GET_INQUIRY_DATA, IntPtr.Zero, 0, (IntPtr) pBuffer,
                                        bufferSize, out bytesReturned, IntPtr.Zero) != 0;
                } while (!success && (Marshal.GetLastWin32Error() == 24 | Marshal.GetLastWin32Error() == 122));
                if (!success)
                {
                    ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
                }
                return Marshaler.PtrToStructure<StandardInquiryData>(new BufferWithSize(pBuffer, bufferSize));
            }
        }

        public FeatureCollection GetCdromConfiguration(FeatureCode startingFeature, FeatureRequestType requestType)
        {
            unsafe
            {
                var input = new GetConfigurationIOCtlInput {Feature = startingFeature, RequestType = (int) requestType};
                int bytesReturned;
                int bufferSize = Marshaler.DefaultSizeOf<FeatureHeader>();
                byte* pBuffer = stackalloc byte[bufferSize];
                bool success;
                var buffer = new BufferWithSize(pBuffer, bufferSize);
                do
                {
                    bufferSize <<= 1;
                    byte* pBuf2 = stackalloc byte[bufferSize];
                    pBuffer = pBuf2;
                    buffer = new BufferWithSize(pBuffer, bufferSize);
                    success =
                        DeviceIoControl(deviceHandle, IOCTL_CDROM_GET_CONFIGURATION, (IntPtr) (&input),
                                        Marshaler.SizeOf(input), (IntPtr) pBuffer, bufferSize, out bytesReturned,
                                        IntPtr.Zero) != 0;
                } while ((!success && (Marshal.GetLastWin32Error() == 24 | Marshal.GetLastWin32Error() == 122)) ||
                         (success &&
                          Marshaler.DefaultSizeOf<FeatureHeader>() +
                          Marshaler.PtrToStructure<FeatureHeader>(buffer).DataLength > bufferSize));
                if (!success)
                {
                    ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
                }
                return FeatureCollection.FromBuffer(buffer);
            }
        }

        public TFeature GetCdromConfiguration<TFeature>()
            where TFeature : MultimediaFeature
        {
            var result = Objects.CreateInstance<TFeature>();
            unsafe
            {
                var input = new GetConfigurationIOCtlInput
                                {
                                    Feature = result.FeatureCode,
                                    RequestType = (int) FeatureRequestType.OneFeatureHeaderAndZeroOrOneDescriptor
                                };
                int bytesReturned;
                int bufferSize = Marshaler.DefaultSizeOf<FeatureHeader>();
                byte* pBuffer = stackalloc byte[bufferSize];
                bool success;
                var buffer = new BufferWithSize(pBuffer, bufferSize);
                do
                {
                    bufferSize <<= 1;
                    byte* pBuf2 = stackalloc byte[bufferSize];
                    pBuffer = pBuf2;
                    buffer = new BufferWithSize(pBuffer, bufferSize);
                    success =
                        DeviceIoControl(deviceHandle, IOCTL_CDROM_GET_CONFIGURATION, (IntPtr) (&input),
                                        Marshaler.SizeOf(input), (IntPtr) pBuffer, bufferSize, out bytesReturned,
                                        IntPtr.Zero) != 0;
                } while ((!success && (Marshal.GetLastWin32Error() == 24 | Marshal.GetLastWin32Error() == 122)) ||
                         (success &&
                          Marshaler.DefaultSizeOf<FeatureHeader>() +
                          Marshaler.PtrToStructure<FeatureHeader>(buffer).DataLength > bufferSize));
                if (!success)
                {
                    ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
                }
                BufferWithSize newBuf = buffer.ExtractSegment(Marshaler.DefaultSizeOf<FeatureHeader>());
                if (newBuf.LengthU32 > 0 && MultimediaFeature.ReadFeatureCode(newBuf) == result.FeatureCode)
                {
                    Marshaler.PtrToStructure(newBuf, ref result);
                }
                else
                {
                    result = null;
                }
                return result;
            }
        }

        public MultimediaProfile CurrentCdromProfile
        {
            get
            {
                var input = new GetConfigurationIOCtlInput
                                {
                                    Feature = 0,
                                    RequestType = (int) FeatureRequestType.OneFeatureHeaderAndZeroOrOneDescriptor
                                };
                int bytesReturned;
                int bufferSize = Marshaler.DefaultSizeOf<FeatureHeader>() + Marshaler.DefaultSizeOf<MultimediaFeature>();
                unsafe
                {
                    byte* pBuffer = stackalloc byte[bufferSize];
                    var buffer = new BufferWithSize(pBuffer, bufferSize);
                    if (
                        DeviceIoControl(deviceHandle, IOCTL_CDROM_GET_CONFIGURATION, (IntPtr) (&input),
                                        Marshaler.SizeOf(input), (IntPtr) pBuffer, bufferSize, out bytesReturned,
                                        IntPtr.Zero) == 0)
                    {
                        ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
                    }
                    return Marshaler.PtrToStructure<FeatureHeader>(buffer).CurrentProfile;
                }
            }
        }

        public int MaximumDataTransferBlockCount
        {
            get
            {
                if (_MaximumDataTransferBlockCount == 0)
                {
                    unsafe
                    {
                        //How to determine the maximum transfer length:
                        //The MaximumTotalTransferBlockCount property specifies the maximum SCSI Request Block size, so to get the
                        // maximum buffer size, we have to subtract the structure length itself.
                        //However, the MaximumTotalPhysicalPages size is more tricky: It's the maximum number of discontiguous pages.
                        // We need to subtract one from it, because our data is not necessarily aligned and can take an extra page.
                        //I'm just being safe here and taking the Min() of both, but I don't know which one is exactly correct.
                        SystemInfo sysInfo;
                        GetSystemInfo(out sysInfo);
                        int result = (MaximumTotalTransferBlockCount - sizeof (ScsiRequestBlock)/sysInfo.PageSize)*
                                     sysInfo.PageSize;
                        result = Math.Min(result, MaximumTotalPhysicalPages - 1);
                        _MaximumDataTransferBlockCount = result; //Round it to page size
                    }
                }
                return _MaximumDataTransferBlockCount;
            }
        }

        public void ResetDevice()
        {
            int temp;
            if (
                DeviceIoControl(deviceHandle, IOCTL_STORAGE_RESET_DEVICE, IntPtr.Zero, 0, IntPtr.Zero, 0, out temp,
                                IntPtr.Zero) == 0)
            {
                ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
            }
        }

        public void ResetBus(byte pathId)
        {
            unsafe
            {
                int temp;
                if (
                    DeviceIoControl(deviceHandle, IOCTL_STORAGE_RESET_BUS, (IntPtr) (&pathId), sizeof (byte),
                                    IntPtr.Zero, 0, out temp, IntPtr.Zero) == 0)
                {
                    ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
                }
            }
        }

        public DiskGeometry[] GetMediaTypes()
        {
            unsafe
            {
                int bytesReturned;
                int bufferSize = Marshaler.DefaultSizeOf<DiskGeometry>();
                byte* pBuffer = stackalloc byte[bufferSize];
                bool success;
                do
                {
                    bufferSize <<= 1;
                    byte* pBuf2 = stackalloc byte[bufferSize];
                    pBuffer = pBuf2;
                    success =
                        DeviceIoControl(deviceHandle, IOCTL_STORAGE_GET_MEDIA_TYPES, IntPtr.Zero, 0, (IntPtr) pBuffer,
                                        bufferSize, out bytesReturned, IntPtr.Zero) != 0;
                } while (!success && (Marshal.GetLastWin32Error() == 24 | Marshal.GetLastWin32Error() == 122));
                if (!success)
                {
                    ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
                }

                var items = new DiskGeometry[bytesReturned/Marshaler.DefaultSizeOf<DiskGeometry>()];
                var pGeom = (DiskGeometry*) pBuffer;
                for (int i = 0; i < items.Length; i++)
                {
                    items[i] = pGeom[i];
                }
                return items;
            }
        }

        public DiskDeviceMediaInfo[] GetMediaTypesEx(out Win32DeviceType deviceType)
        {
            unsafe
            {
                int bytesReturned;
                int bufferSize = Marshaler.DefaultSizeOf<DeviceMediaTypes>();
                byte* pBuffer = stackalloc byte[bufferSize];
                bool success;
                do
                {
                    bufferSize <<= 1;
                    byte* pBuf2 = stackalloc byte[bufferSize];
                    pBuffer = pBuf2;
                    success =
                        DeviceIoControl(deviceHandle, IOCTL_STORAGE_GET_MEDIA_TYPES_EX, IntPtr.Zero, 0, (IntPtr) pBuffer,
                                        bufferSize, out bytesReturned, IntPtr.Zero) != 0;
                } while (!success && (Marshal.GetLastWin32Error() == 24 | Marshal.GetLastWin32Error() == 122));
                if (!success)
                {
                    ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
                }
                var result = Marshaler.PtrToStructure<DeviceMediaTypes>(new BufferWithSize(pBuffer, bytesReturned));
                deviceType = result.DeviceType;
                return result.MediaInfo;
            }
        }

        public byte PortNumber
        {
            get { return Address.PortNumber; }
        }

        public byte PathId
        {
            get { return Address.PathId; }
        }

        public byte TargetId
        {
            get { return Address.TargetId; }
        }

        public byte LogicalUnitNumber
        {
            get { return Address.Lun; }
        }

        public void McnControl(bool disableMediaChangeNotifications)
        {
            int temp;
            unsafe
            {
                if (
                    DeviceIoControl(deviceHandle, IOCTL_STORAGE_MCN_CONTROL, (IntPtr) (&disableMediaChangeNotifications),
                                    sizeof (bool), IntPtr.Zero, 0, out temp, IntPtr.Zero) == 0)
                {
                    ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
                }
            }
        }

        public int MaximumTotalTransferBlockCount
        {
            get { return Capabilities.MaximumTransferBlockCount; }
        }

        public int MaximumTotalPhysicalPages
        {
            get { return Capabilities.MaximumPhysicalPages; }
        }

        public int SupportedAsynchronousEvents
        {
            get { return Capabilities.SupportedAsynchronousEvents; }
        }

        public int AlignmentMask
        {
            get
            {
                if (_Alignment == -1)
                {
                    _Alignment = Capabilities.AlignmentMask;
                }
                return _Alignment;
            }
        }

        public bool TaggedQueuing
        {
            get { return Capabilities.TaggedQueuing; }
        }

        public bool AdapterScansDown
        {
            get { return Capabilities.AdapterScansDown; }
        }

        public bool AdapterUsesProgrammedIO
        {
            get { return Capabilities.AdapterUsesPio; }
        }

        public StandardInquiryData QueryStorageInquiryData()
        {
            var query = new StoragePropertyQuery
                            {
                                PropertyId = StoragePropertyId.StorageDeviceProperty,
                                QueryType = StorageQueryType.PropertyStandardQuery
                            };
            unsafe
            {
                int bytesReturned;
                int bufferSize = Marshaler.DefaultSizeOf<StorageDescriptorHeader>();
                byte* pBuffer = stackalloc byte[bufferSize];
                bool success;
                do
                {
                    bufferSize <<= 1;
                    byte* pBuf2 = stackalloc byte[bufferSize];
                    pBuffer = pBuf2;
                    success =
                        DeviceIoControl(deviceHandle, IOCTL_STORAGE_QUERY_PROPERTY, (IntPtr) (&query),
                                        Marshaler.SizeOf(query), (IntPtr) pBuffer, bufferSize, out bytesReturned,
                                        IntPtr.Zero) != 0;
                } while (!success && (Marshal.GetLastWin32Error() == 24 | Marshal.GetLastWin32Error() == 122));
                if (!success)
                {
                    ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
                }
                var pDescriptor = (StorageDeviceDescriptor*) pBuffer;
                throw new NotImplementedException();
                //return Marshaler.PtrToStructure<StandardInquiryData>(new BufferWithSize((IntPtr)pDescriptor->RawDeviceProperties, pDescriptor->RawPropertiesLength));
            }
        }

        #endregion

        #region Structures

        #region StorageBusType enum

        public enum StorageBusType
        {
            BusTypeUnknown = 0x00,
            BusTypeScsi,
            BusTypeAtapi,
            BusTypeAta,
            BusType1394,
            BusTypeSsa,
            BusTypeFibre,
            BusTypeUsb,
            BusTypeRAID,
            BusTypeiScsi,
            BusTypeSas,
            BusTypeSata,
            BusTypeSd,
            BusTypeMmc,
            BusTypeVirtual,
            BusTypeFileBackedVirtual,
            BusTypeMax,
            BusTypeMaxReserved = 0x7F
        }

        #endregion

        #region StorageQueryType enum

        public enum StorageQueryType
        {
            PropertyStandardQuery = 0,
            PropertyIncludeSwIds,
            PropertyExistsQuery,
            PropertyMaskQuery,
            PropertyQueryMaxDefined
        }

        #endregion

        #region Nested type: DeviceMediaTypes

        private struct DeviceMediaTypes : IMarshalable
        {
            public Win32DeviceType DeviceType;
            public DiskDeviceMediaInfo[] MediaInfo;
            public int MediaInfoCount;

            #region IMarshalable Members

            public void MarshalFrom(BufferWithSize buffer)
            {
                DeviceType = buffer.Read<Win32DeviceType>(0);
                MediaInfoCount = buffer.Read<int>(sizeof (Win32DeviceType));
                MediaInfo = new DiskDeviceMediaInfo[MediaInfoCount];

                BufferWithSize infosBuffer = buffer.ExtractSegment(sizeof (Win32DeviceType) + sizeof (int));
                for (int i = 0; i < MediaInfoCount; i++)
                {
                    MediaInfo[i] =
                        Marshaler.PtrToStructure<DiskDeviceMediaInfo>(
                            infosBuffer.ExtractSegment(i*Marshaler.DefaultSizeOf<DiskDeviceMediaInfo>(),
                                                       Marshaler.DefaultSizeOf<DiskDeviceMediaInfo>()));
                }
            }

            public void MarshalTo(BufferWithSize buffer)
            {
                throw new NotImplementedException();
            }

            public int MarshaledSize
            {
                get { throw new NotImplementedException(); }
            }

            #endregion
        }

        #endregion

        #region Nested type: GetConfigurationIOCtlInput

        private struct GetConfigurationIOCtlInput
        {
            public FeatureCode Feature;
            public int RequestType;
            public IntPtr Reserved1;
            public IntPtr Reserved2;
        }

        #endregion

        #region Nested type: IOScsiCapabilities

        private struct IOScsiCapabilities
        {
            [MarshalAs(UnmanagedType.I1)] public bool AdapterScansDown;
            [MarshalAs(UnmanagedType.I1)] public bool AdapterUsesPio;
            public int AlignmentMask;
            public int Length;
            public int MaximumPhysicalPages;
            public int MaximumTransferBlockCount;
            public int SupportedAsynchronousEvents;
            [MarshalAs(UnmanagedType.I1)] public bool TaggedQueuing;
        }

        #endregion

        #region Nested type: ScsiAdapterBusInfo

        private struct ScsiAdapterBusInfo : IMarshalable
        {
            [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly IntPtr BUS_DATA_OFFSET =
                Marshal.OffsetOf(typeof (ScsiAdapterBusInfo), "_BusData");

            [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly IntPtr NUMBER_OF_BUSES_OFFSET =
                Marshal.OffsetOf(typeof (ScsiAdapterBusInfo), "NumberOfBuses");

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)] [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ScsiBusData[] _BusData;
            private byte NumberOfBuses;

            public ScsiBusData[] BusData
            {
                get { return _BusData; }
                set
                {
                    _BusData = value;
                    NumberOfBuses = (byte) value.Length;
                }
            }

            #region IMarshalable Members

            public void MarshalFrom(BufferWithSize buffer)
            {
                NumberOfBuses = buffer.Read<byte>(NUMBER_OF_BUSES_OFFSET);
                _BusData = new ScsiBusData[NumberOfBuses];
                BufferWithSize remainingBusBuffer = buffer.ExtractSegment(BUS_DATA_OFFSET);
                for (int i = 0; i < _BusData.Length; i++)
                {
                    _BusData[i] = Marshaler.PtrToStructure<ScsiBusData>(remainingBusBuffer);
                    remainingBusBuffer = remainingBusBuffer.ExtractSegment(Marshaler.SizeOf(_BusData[i]));
                }
            }

            public void MarshalTo(BufferWithSize buffer)
            {
                buffer.Write(NumberOfBuses, NUMBER_OF_BUSES_OFFSET);
                BufferWithSize remainingBusBuffer = buffer.ExtractSegment(BUS_DATA_OFFSET);
                for (int i = 0; i < _BusData.Length; i++)
                {
                    Marshaler.StructureToPtr(_BusData[i], remainingBusBuffer);
                    remainingBusBuffer = remainingBusBuffer.ExtractSegment(Marshaler.SizeOf(_BusData[i]));
                }
            }

            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
            public int MarshaledSize
            {
                get
                {
                    return Marshaler.DefaultSizeOf<ScsiAdapterBusInfo>() +
                           (Marshaler.DefaultSizeOf<ScsiBusData>()*(NumberOfBuses - 1));
                }
            }

            #endregion
        }

        #endregion

        #region Nested type: ScsiAddress

        private struct ScsiAddress
        {
            [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly IntPtr LUN_OFFSET =
                Marshal.OffsetOf(typeof (ScsiAddress), "Lun");

            [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly IntPtr PATH_ID_OFFSET =
                Marshal.OffsetOf(typeof (ScsiAddress), "PathId");

            [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly IntPtr PORT_NUMBER_OFFSET =
                Marshal.OffsetOf(typeof (ScsiAddress), "PortNumber");

            [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly IntPtr TARGET_ID_OFFSET =
                Marshal.OffsetOf(typeof (ScsiAddress), "TargetId");

            public readonly int Length;
            public readonly byte Lun;
            public readonly byte PathId /*or Bus#*/;
            public readonly byte PortNumber;
            public readonly byte TargetId;

            public ScsiAddress(byte port, byte path, byte target, byte lun)
            {
                Length = Marshaler.DefaultSizeOf<ScsiAddress>();
                PortNumber = port;
                PathId = path;
                TargetId = target;
                Lun = lun;
            }

            public override string ToString()
            {
                return string.Format("Port {0:N0}, Path ID {1:N0}, Target ID {2:N0}, LUN {3:N0}", PortNumber, PathId,
                                     TargetId, Lun);
            }
        }

        #endregion

#pragma warning disable 0649

        #region Nested type: ScsiBusData

        private struct ScsiBusData
        {
            public byte InitiatorBusId;
            public int InquiryDataOffset;
            public byte NumberOfLogicalUnits;
        }

        #endregion

#pragma warning restore 0649

        #region Nested type: ScsiInquiryData

        public struct ScsiInquiryData : IMarshalable
        {
            [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly IntPtr BUS_INFO_OFFSET =
                Marshal.OffsetOf(typeof (ScsiInquiryData), "_BusInfo");

            [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly IntPtr INQUIRY_DATA_LENGTH_OFFSET
                = Marshal.OffsetOf(typeof (ScsiInquiryData), "InquiryDataLength");

            [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly IntPtr INQUIRY_DATA_OFFSET =
                Marshal.OffsetOf(typeof (ScsiInquiryData), "_InquiryData");

            [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly IntPtr
                NEXT_INQUIRY_DATA_OFFSET_OFFSET = Marshal.OffsetOf(typeof (ScsiInquiryData), "NextInquiryDataOffset");

            [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ScsiDeviceInfo _BusInfo;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)] [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte[] _InquiryData;

            private int InquiryDataLength;
            public int NextInquiryDataOffset;

            public ScsiDeviceInfo BusInfo
            {
                get { return _BusInfo; }
                set { _BusInfo = value; }
            }

            public byte[] InquiryData
            {
                get { return _InquiryData; }
                set
                {
                    _InquiryData = value;
                    InquiryDataLength = value != null ? value.Length : 0;
                    NextInquiryDataOffset = MarshaledSize;
                }
            }

            #region IMarshalable Members

            public void MarshalFrom(BufferWithSize buffer)
            {
                _BusInfo = buffer.Read<ScsiDeviceInfo>(BUS_INFO_OFFSET);
                InquiryDataLength = buffer.Read<int>(INQUIRY_DATA_LENGTH_OFFSET);
                NextInquiryDataOffset = buffer.Read<int>(NEXT_INQUIRY_DATA_OFFSET_OFFSET);
                _InquiryData = new byte[InquiryDataLength];
                buffer.CopyTo((int) INQUIRY_DATA_OFFSET, _InquiryData, 0, _InquiryData.Length);
            }

            public void MarshalTo(BufferWithSize buffer)
            {
                buffer.Write(_BusInfo, BUS_INFO_OFFSET);
                buffer.Write(InquiryDataLength, INQUIRY_DATA_LENGTH_OFFSET);
                buffer.Write(NextInquiryDataOffset, NEXT_INQUIRY_DATA_OFFSET_OFFSET);
                if (_InquiryData.Length > 1)
                {
                    throw new OverflowException("Field is too large.");
                }
                buffer.CopyFrom((int) INQUIRY_DATA_OFFSET, _InquiryData, 0, _InquiryData.Length);
                buffer.Initialize((int) INQUIRY_DATA_OFFSET + _InquiryData.Length, 1 - _InquiryData.Length);
            }

            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
            public int MarshaledSize
            {
                get { return Marshaler.DefaultSizeOf<ScsiInquiryData>() + InquiryDataLength; }
            }

            #endregion
        }

        #endregion

        #region Nested type: ScsiPassThroughDirect

        [StructLayout(LayoutKind.Sequential)]
        private struct ScsiPassThroughDirect
        {
            [DebuggerBrowsable(DebuggerBrowsableState.Never)] internal static readonly int SENSE_BUFFER_OFFSET =
                (int) Marshal.OffsetOf(typeof (ScsiPassThroughDirect), "SenseBuffer");

            [DebuggerBrowsable(DebuggerBrowsableState.Never)] internal static readonly int
                DEFAULT_SIZE_WITH_SENSE_BUFFER = Marshaler.DefaultSizeOf<ScsiPassThroughDirect>();

            [DebuggerBrowsable(DebuggerBrowsableState.Never)] public const int DEFAULT_SENSE_SIZE = 128;
            public ushort Length;
            public ScsiStatus ScsiStatus;
            public byte PathId;
            public byte TargetId;
            public byte LogicalUnitNumber;
            public byte CdbLength;
            public byte SenseInfoLength;
            public DataTransferDirection DataIn;
            public uint DataTransferBlockCount;
            public uint TimeoutValue;
            public IntPtr DataBuffer;
            public uint SenseInfoOffset;
            public unsafe fixed byte Cdb [16];
            public unsafe fixed byte SenseBuffer [DEFAULT_SENSE_SIZE];
        }

        #endregion

        #region Nested type: ScsiRequestBlock

        private struct ScsiRequestBlock
        {
            //We don't actually use this structure --
            //  I just defined it so I can take its size dynamically, instead of hard-coding a value (which could fail on x64)
#pragma warning disable 0649
            public unsafe fixed byte Cdb [16];
            public byte CdbLength;
            public IntPtr DataBuffer;
            public int DataTransferBlockCount;
            public byte Function;
            public ushort Length;
            public byte Lun;
            public unsafe ScsiRequestBlock* NextSrb;
            public IntPtr OriginalRequest;
            public byte PathId;
            public byte QueueAction;
            public int QueueSortKey;
            public byte QueueTag;
            public byte ScsiStatus;
            public IntPtr SenseInfoBuffer;
            public byte SenseInfoBufferLength;
            public IntPtr SrbExtension;
            public int SrbFlags;
            public byte SrbStatus;
            public byte TargetId;
            public int TimeOutValue;
#pragma warning restore 0649
        }

        #endregion

        #region Nested type: StorageDescriptorHeader

        public struct StorageDescriptorHeader
        {
            public int Size;
            public int Version;
        }

        #endregion

        #region Nested type: StorageDeviceDescriptor

        public struct StorageDeviceDescriptor
        {
            public StorageBusType BusType;
            [MarshalAs(UnmanagedType.I1)] public bool CommandQueueing;
            public byte DeviceType;
            public byte DeviceTypeModifier;
            public StorageDescriptorHeader Header;
            public int ProductIdOffset;
            public int ProductRevisionOffset;
            public unsafe fixed byte RawDeviceProperties [1];
            public int RawPropertiesLength;
            [MarshalAs(UnmanagedType.I1)] public bool RemovableMedia;
            public int SerialNumberOffset;
            public int VendorIdOffset;
        }

        #endregion

        #region Nested type: StoragePropertyId

        private enum StoragePropertyId
        {
            StorageDeviceProperty = 0,
            StorageAccessAlignmentProperty,
            StorageAdapterProperty,
            StorageDeviceIdProperty,
            StorageDeviceUniqueIdProperty,
            StorageDeviceWriteCacheProperty
        }

        #endregion

        #region Nested type: StoragePropertyQuery

        private struct StoragePropertyQuery
        {
            public unsafe fixed byte AdditionalParameters [1];
            public StoragePropertyId PropertyId;
            public StorageQueryType QueryType;
        }

        #endregion

        #region Nested type: SystemInfo

        private struct SystemInfo
        {
            public IntPtr ActiveProcessorMask;
            public int AllocationGranularity;
            public IntPtr MaximumApplicationAddress;
            public IntPtr MinimumApplicationAddress;
            public int NumberOfProcessors;
            public int OemId;
            public int PageSize;
            public short ProcessorLevel;
            public short ProcessorRevision;
            public int ProcessorType;
        }

        #endregion

        #endregion

        [DebuggerHidden, DebuggerStepThrough, DebuggerNonUserCode]
        private static void ThrowExceptionForHR(int hr)
        {
            Exception ex = Marshal.GetExceptionForHR(hr);

            if (GetExceptionMessage == null)
            {
                try
                {
                    var dyn = new DynamicMethod("GetMessage", typeof (string), new[] {typeof (Exception)},
                                                typeof (Exception), true);
                    FieldInfo field = typeof (Exception).GetField("_message",
                                                                  BindingFlags.Instance | BindingFlags.NonPublic |
                                                                  BindingFlags.Public);
                    ILGenerator gen = dyn.GetILGenerator();
                    gen.Emit(OpCodes.Ldarg_0);
                    gen.Emit(OpCodes.Ldfld, field);
                    gen.Emit(OpCodes.Ret);
                    Interlocked.CompareExchange(ref GetExceptionMessage,
                                                (Converter<Exception, string>)
                                                dyn.CreateDelegate(typeof (Converter<Exception, string>)), null);
                }
                catch
                {
                }
            }
            if (GetExceptionMessage != null)
            {
                string msg = GetExceptionMessage(ex);
                int i = msg.IndexOf(" (Exception from HRESULT:");
                if (i >= 0)
                {
                    if (SetExceptionMessage == null)
                    {
                        try
                        {
                            var dyn = new DynamicMethod("SetMessage", null, new[] {typeof (Exception), typeof (string)},
                                                        typeof (Exception), true);
                            FieldInfo field = typeof (Exception).GetField("_message",
                                                                          BindingFlags.Instance | BindingFlags.NonPublic |
                                                                          BindingFlags.Public);
                            ILGenerator gen = dyn.GetILGenerator();
                            gen.Emit(OpCodes.Ldarg_0);
                            gen.Emit(OpCodes.Ldarg_1);
                            gen.Emit(OpCodes.Stfld, field);
                            gen.Emit(OpCodes.Ret);
                            Interlocked.CompareExchange(ref SetExceptionMessage,
                                                        (Action<Exception, string>)
                                                        dyn.CreateDelegate(typeof (Action<Exception, string>)), null);
                        }
                        catch
                        {
                        }
                    }
                    if (SetExceptionMessage != null)
                    {
                        SetExceptionMessage(ex, msg.Substring(0, i));
                    }
                }
            }
            throw ex;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                try
                {
                    if (!leaveDeviceOpen)
                    {
                        deviceHandle.Close();
                    }
                }
                finally
                {
                    deviceHandle = null;
                }
            }
        }

        [DllImport("Kernel32.dll", SetLastError = true)]
        private static extern int DeviceIoControl([In] SafeFileHandle hDevice, [In] int dwIoControlCode,
                                                  [In] IntPtr lpInBuffer, [In] int nInBufferSize,
                                                  [Out] IntPtr lpOutBuffer, [In] int nOutBufferSize,
                                                  [Out] out int lpBytesReturned, [In] IntPtr lpOverlapped);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern void GetSystemInfo(out SystemInfo lpSystemInfo);

        #region Nested type: Action

        private delegate void Action<T1, T2>(T1 param1, T2 param2);

        #endregion
    }
}