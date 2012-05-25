using System;
using System.ComponentModel;
using System.Diagnostics;
using Helper;

namespace Ata
{
    /// <summary>Represents a generic ATA device. This class should not be instantiated directly unless no subclasses exist that are appropriate.</summary>
    [Description(
        "Represents a generic ATA device. This class should not be instantiated directly unless no subclasses exist that are appropriate."
        )]
    public class AtaDevice : IDisposable
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private int _DmaSupported = -1;
                                                                      //Boolean... but we need 3 states

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private int _Is48LBA = -1; //Boolean... but we need 3 states
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private uint _LogicalSectorSize;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private bool leaveOpen;

        /// <summary>Initializes a new instance of the <see cref="AtaDevice"/> class.</summary>
        /// <param name="interface">The pass-through interface to use.</param>
        /// <param name="leaveOpen"><c>true</c> to leave the interface open, or <c>false</c> to dispose along with this object.</param>
        public AtaDevice(IAtaPassThrough @interface, bool leaveOpen)
        {
            this.leaveOpen = leaveOpen;
            Interface = @interface;
        }

        public byte? AdvancedPowerManagementLevel
        {
            get
            {
                DeviceIdentifier id = IdentifyDevice();
                return id.AdvancedPowerManagementFeatureSetEnabled
                           ? id.AdvancedPowerManagementLevelCurrent
                           : (byte?) null;
            }
            set
            {
                if (value != null)
                {
                    SetFeatures(0x05, value.Value, 0);
                }
                else
                {
                    SetFeatures(0x85, 0, 0);
                }
            }
        }

        public byte? AutomaticAcousticManagementLevel
        {
            get
            {
                DeviceIdentifier id = IdentifyDevice();
                return id.AutomaticAcousticManagementFeatureSetEnabled
                           ? id.AutomaticAcousticManagementLevelCurrent
                           : (byte?) null;
            }
            set
            {
                if (value != null)
                {
                    SetFeatures(0x42, value.Value, 0);
                }
                else
                {
                    SetFeatures(0xC2, 0, 0);
                }
            }
        }

        public bool DmaSupported
        {
            get
            {
                if (_DmaSupported != -1)
                {
                    _DmaSupported = IdentifyDevice().DmaSupported ? 1 : 0;
                }
                return _DmaSupported != 0;
            }
        }

        public byte? FreeFallSensitivityLevel
        {
            get
            {
                DeviceIdentifier id = IdentifyDevice();
                return id.FreeFallControlFeatureSetEnabled ? id.FreeFallControlSensitivityLevelCurrent : (byte?) null;
            }
            set
            {
                if (value != null)
                {
                    SetFeatures(0x41, value.Value, 0);
                }
                else
                {
                    SetFeatures(0xC1, 0, 0);
                }
            }
        }

        [Obsolete(
            "Do not use. This is only for viewing the data in the debugger, because manipulating the returned data has no effect. Use the appropriate Get and Set methods instead."
            , true)]
        private DeviceIdentifier Identifier
        {
            get { return IdentifyDevice(); }
        }

        public IAtaPassThrough Interface { get; private set; }

        public uint LogicalSectorSize
        {
            get
            {
                if (_LogicalSectorSize == 0)
                {
                    DeviceIdentifier id = IdentifyDevice();
                    _LogicalSectorSize = id.LogicalSectorSize;
                }
                return _LogicalSectorSize;
            }
        }

        /// <summary>The highest addressable logical block address. Note that this is one less than the number of logical blocks on the disk.</summary>
        public int NativeMaximumAddress
        {
            get
            {
                var task = new AtaTaskFile(0, 0, 0, 1 << 6, AtaCommand.ReadNativeMaxAddress, 0);
                ExecuteCommand28(ref task, BufferWithSize.Zero, AtaFlags.NoMultiple, true);
                return checked((int) task.LogicalBlockAddress);
            }
        }

        /// <summary>The highest addressable logical block address, in 48-bit form. Note that this is one less than the number of logical blocks on the disk.</summary>
        public long NativeMaximumAddressExt
        {
            get
            {
                var low = new AtaTaskFile(0, 0, 0, 1 << 6, AtaCommand.ReadNativeMaxAddressExt, 0);
                var high = new AtaTaskFile(0, 0, 0, 1 << 6, AtaCommand.ReadNativeMaxAddressExt, 0);
                ExecuteCommand48(ref low, ref high, BufferWithSize.Zero, AtaFlags.Command48Bit, true);
                return low.LogicalBlockAddress;
            }
        }

        public bool ReadLookAhead
        {
            get { return IdentifyDevice().ReadLookAheadEnabled; }
            set { SetFeatures(value ? (byte) 0xAA : (byte) 0x55, 0, 0); }
        }

        public bool Supports48BitLogicalBlockAddressing
        {
            get
            {
                if (_Is48LBA != -1)
                {
                    _Is48LBA = IdentifyDevice().Command48BitAddressFeatureSetEnabled ? 1 : 0;
                }
                return _Is48LBA != 0;
            }
        }

        public virtual uint TimeoutSeconds
        {
            get { return 10; }
        }

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        public void DeviceReset()
        {
            var task = new AtaTaskFile(AtaCommand.DeviceReset);
            ExecuteCommand28(ref task, BufferWithSize.Zero, AtaFlags.None, true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                try
                {
                    if (!leaveOpen)
                    {
                        Interface.Dispose();
                    }
                }
                finally
                {
                    Interface = null;
                }
            }
        }

        protected void ExecuteCommand28(ref AtaTaskFile task, BufferWithSize buffer, AtaFlags flags, bool checkError)
        {
            flags &= ~AtaFlags.Command48Bit;
            var high = new AtaTaskFile();
            ExecuteCommandCore(ref task, ref high, buffer, flags, checkError);
        }

        protected void ExecuteCommand48(ref AtaTaskFile low, ref AtaTaskFile high, BufferWithSize buffer, AtaFlags flags,
                                        bool checkError)
        {
            flags |= AtaFlags.Command48Bit;
            ExecuteCommandCore(ref low, ref high, buffer, flags, checkError);
        }

        protected virtual void ExecuteCommandCore(ref AtaTaskFile low, ref AtaTaskFile high, BufferWithSize buffer,
                                                  AtaFlags flags, bool checkError)
        {
            Interface.ExecuteCommand(ref low, ref high, buffer.Address, buffer.LengthU32, TimeoutSeconds, flags);
            if (checkError)
            {
                if (low.Error != AtaError.None)
                {
                    throw AtaException.CreateException(low.Error);
                }
                //if (high.Error != AtaError.None) { throw AtaException.CreateException(high.Error); }
            }
        }

        public void FlushCache()
        {
            var task = new AtaTaskFile(AtaCommand.FlushCache);
            ExecuteCommand28(ref task, BufferWithSize.Zero, AtaFlags.None, true);
        }

        public void FlushCacheExt()
        {
            AtaTaskFile low = new AtaTaskFile(AtaCommand.FlushCache), high = low;
            ExecuteCommand48(ref low, ref high, BufferWithSize.Zero, AtaFlags.Command48Bit, true);
        }

        public DeviceIdentifier IdentifyDevice()
        {
            var task = new AtaTaskFile(AtaCommand.IdentifyDevice);
            var id = new DeviceIdentifier();
            BufferWithSize buffer;
            unsafe
            {
                buffer = new BufferWithSize((IntPtr) (&id), Marshaler.DefaultSizeOf<DeviceIdentifier>());
            }
            ExecuteCommand28(ref task, buffer, AtaFlags.ReceiveData, true);
            return id;
        }

        public byte[] ReadDma(int logicalBlockAddress, byte sectorCount)
        {
            var data = new byte[LogicalSectorSize*sectorCount];
            ReadDma(logicalBlockAddress, sectorCount, data, 0);
            return data;
        }

        /// <param name="sectorCount">The number of sectors to read. IMPORTANT NOTE: If zero, then this value specifies <c>0x100</c> sectors.</param>
        public void ReadDma(int logicalBlockAddress, byte sectorCount, byte[] buffer, int bufferOffset)
        {
            unsafe
            {
                fixed (byte* pBuffer = &buffer[bufferOffset])
                {
                    ReadDma(logicalBlockAddress, sectorCount, new BufferWithSize(pBuffer, buffer.Length - bufferOffset));
                }
            }
        }

        /// <param name="sectorCount">The number of sectors to read. IMPORTANT NOTE: If zero, then this value specifies <c>0x100</c> sectors.</param>
        public void ReadDma(int logicalBlockAddress, byte sectorCount, BufferWithSize buffer)
        {
            var sectorsToRead = (uint) (sectorCount == 0 ? 256 : sectorCount);
            if (sectorsToRead*LogicalSectorSize > buffer.LengthU32)
            {
                throw new ArgumentOutOfRangeException("buffer", buffer, "Buffer was too small.");
            }
            var task = new AtaTaskFile(0, sectorCount, checked((uint) logicalBlockAddress), 1 << 6, AtaCommand.ReadDma,
                                       0);
            ExecuteCommand28(ref task, buffer, AtaFlags.ReceiveData | AtaFlags.UseDma, true);
        }

        public byte[] ReadDmaExt(long logicalBlockAddress, ushort sectorCount)
        {
            var data = new byte[LogicalSectorSize*sectorCount];
            ReadDmaExt(logicalBlockAddress, sectorCount, data, 0);
            return data;
        }

        /// <param name="sectorCount">The number of sectors to read. IMPORTANT NOTE: If zero, then this value specifies <c>0x10000</c> sectors.</param>
        public void ReadDmaExt(long logicalBlockAddress, ushort sectorCount, byte[] buffer, int bufferOffset)
        {
            unsafe
            {
                fixed (byte* pBuffer = &buffer[bufferOffset])
                {
                    ReadDmaExt(logicalBlockAddress, sectorCount,
                               new BufferWithSize(pBuffer, buffer.Length - bufferOffset));
                }
            }
        }

        /// <param name="sectorCount">The number of sectors to read. IMPORTANT NOTE: If zero, then this value specifies <c>0x10000</c> sectors.</param>
        public void ReadDmaExt(long logicalBlockAddress, ushort sectorCount, BufferWithSize buffer)
        {
            var sectorsToRead = (uint) (sectorCount == 0 ? 256 : sectorCount);
            if (sectorsToRead*LogicalSectorSize > buffer.LengthU32)
            {
                throw new ArgumentOutOfRangeException("buffer", buffer, "Buffer was too small.");
            }
            var low = new AtaTaskFile(0, unchecked((byte) sectorCount),
                                      unchecked((uint) logicalBlockAddress & 0x00FFFFFFU), 1 << 6, AtaCommand.ReadDmaExt,
                                      0);
            var high = new AtaTaskFile(0, checked((byte) (sectorCount >> 8)),
                                       checked((uint) (logicalBlockAddress >> 24)), 1 << 6, AtaCommand.ReadDmaExt, 0);
            ExecuteCommand48(ref low, ref high, buffer, AtaFlags.ReceiveData | AtaFlags.UseDma | AtaFlags.Command48Bit,
                             true);
        }

        public byte[] ReadSectors(int logicalBlockAddress, byte sectorCount)
        {
            var data = new byte[LogicalSectorSize*sectorCount];
            ReadSectors(logicalBlockAddress, sectorCount, data, 0);
            return data;
        }

        /// <param name="sectorCount">The number of sectors to read. IMPORTANT NOTE: If zero, then this value specifies <c>0x100</c> sectors.</param>
        public void ReadSectors(int logicalBlockAddress, byte sectorCount, byte[] buffer, int bufferOffset)
        {
            unsafe
            {
                fixed (byte* pBuffer = &buffer[bufferOffset])
                {
                    ReadSectors(logicalBlockAddress, sectorCount,
                                new BufferWithSize(pBuffer, buffer.Length - bufferOffset));
                }
            }
        }

        /// <param name="sectorCount">The number of sectors to read. IMPORTANT NOTE: If zero, then this value specifies <c>0x100</c> sectors.</param>
        public void ReadSectors(int logicalBlockAddress, byte sectorCount, BufferWithSize buffer)
        {
            var sectorsToRead = (uint) (sectorCount == 0 ? 256 : sectorCount);
            if (sectorsToRead*LogicalSectorSize > buffer.LengthU32)
            {
                throw new ArgumentOutOfRangeException("buffer", buffer, "Buffer was too small.");
            }
            var task = new AtaTaskFile(0, sectorCount, checked((uint) logicalBlockAddress), 1 << 6,
                                       AtaCommand.ReadSectors, 0);
            ExecuteCommand28(ref task, buffer, AtaFlags.ReceiveData, true);
        }

        public byte[] ReadSectorsExt(long logicalBlockAddress, ushort sectorCount)
        {
            var data = new byte[LogicalSectorSize*sectorCount];
            ReadSectorsExt(logicalBlockAddress, sectorCount, data, 0);
            return data;
        }

        /// <param name="sectorCount">The number of sectors to read. IMPORTANT NOTE: If zero, then this value specifies <c>0x10000</c> sectors.</param>
        public void ReadSectorsExt(long logicalBlockAddress, ushort sectorCount, byte[] buffer, int bufferOffset)
        {
            unsafe
            {
                fixed (byte* pBuffer = &buffer[bufferOffset])
                {
                    ReadSectorsExt(logicalBlockAddress, sectorCount,
                                   new BufferWithSize(pBuffer, buffer.Length - bufferOffset));
                }
            }
        }

        /// <param name="sectorCount">The number of sectors to read. IMPORTANT NOTE: If zero, then this value specifies <c>0x10000</c> sectors.</param>
        public void ReadSectorsExt(long logicalBlockAddress, ushort sectorCount, BufferWithSize buffer)
        {
            var sectorsToRead = (uint) (sectorCount == 0 ? 256 : sectorCount);
            if (sectorsToRead*LogicalSectorSize > buffer.LengthU32)
            {
                throw new ArgumentOutOfRangeException("buffer", buffer, "Buffer was too small.");
            }
            var low = new AtaTaskFile(0, unchecked((byte) sectorCount),
                                      unchecked((uint) logicalBlockAddress & 0x00FFFFFFU), 1 << 6,
                                      AtaCommand.ReadSectorsExt, 0);
            var high = new AtaTaskFile(0, checked((byte) (sectorCount >> 8)),
                                       checked((uint) (logicalBlockAddress >> 24)), 1 << 6, AtaCommand.ReadSectorsExt, 0);
            ExecuteCommand48(ref low, ref high, buffer, AtaFlags.ReceiveData | AtaFlags.Command48Bit, true);
        }

        private void SetFeatures(byte feature, byte count, int logicalBlockAddress)
        {
            var task = new AtaTaskFile(feature, count, checked((uint) logicalBlockAddress), 0, AtaCommand.SetFeatures, 0);
            ExecuteCommand28(ref task, BufferWithSize.Zero, AtaFlags.None, true);
        }
    }
}