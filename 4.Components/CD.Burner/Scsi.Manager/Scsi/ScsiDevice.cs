using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using Helper;
using Scsi.Block;
using Scsi.Multimedia;

namespace Scsi
{
    /// <summary>Represents a generic SCSI device. This class should not be instantiated directly unless no subclasses exist that are appropriate.</summary>
    [Description(
        "Represents a generic SCSI device. This class should not be instantiated directly unless no subclasses exist that are appropriate."
        )]
    public class ScsiDevice : IScsiDevice
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const int MAX_DATA_SIZE = 64 << 10;
        private bool _CanWrite = true; //TODO: Query write protection
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private int _Lun = -1;
        private uint _MaxBlockTransferCount = 16; //It seems like 16 sectors is most optimal... I don't know why
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private int _PathId = -1;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private int _TargetId = -1;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private uint _TimeoutSeconds = 60;
        private ReadCapacityInfo capacityInfo;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private SenseData lastSenseData;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private bool leaveOpen;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Read10Command read10CommandTemp = new Read10Command();
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Read12Command read12CommandTemp = new Read12Command();
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Read16Command read16CommandTemp = new Read16Command();

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Write10Command write10CommandTemp =
            new Write10Command();

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Write12Command write12CommandTemp =
            new Write12Command();

        /// <summary>Initializes a new instance of the <see cref="ScsiDevice"/> class.</summary>
        /// <param name="interface">The pass-through interface to use.</param>
        /// <param name="leaveOpen"><c>true</c> to leave the interface open, or <c>false</c> to dispose along with this object.</param>
        public ScsiDevice(IScsiPassThrough @interface, bool leaveOpen)
        {
            AutoSense = true;
            this.leaveOpen = leaveOpen;
            Interface = @interface;
            DefaultPollingInterval = 1;
        }

        public virtual bool AutoSense { get; set; }

        private byte PathId
        {
            get
            {
                if (_PathId == -1)
                {
                    int val;
                    try
                    {
                        val = Interface.PathId;
                    }
                    catch
                    {
                        val = 0;
                    }
                    Interlocked.CompareExchange(ref _PathId, val, -1);
                }
                return (byte) _PathId;
            }
        }

        private byte TargetId
        {
            get
            {
                if (_TargetId == -1)
                {
                    int val;
                    try
                    {
                        val = Interface.TargetId;
                    }
                    catch
                    {
                        val = 0;
                    }
                    Interlocked.CompareExchange(ref _TargetId, val, -1);
                }
                return (byte) _TargetId;
            }
        }

        private byte LogicalUnitNumber
        {
            get
            {
                if (_Lun == -1)
                {
                    int val;
                    try
                    {
                        val = Interface.LogicalUnitNumber;
                    }
                    catch
                    {
                        val = 0;
                    }
                    Interlocked.CompareExchange(ref _Lun, val, -1);
                }
                return (byte) _Lun;
            }
        }

        [Obsolete(
            "Do not use. This is only for viewing the data in the debugger, because manipulating the returned data has no effect. Use the appropriate Get and Set methods instead."
            , true)]
        private CachingModePage Caching
        {
            get { return GetCachingInformation(new ModeSense10Command(PageControl.CurrentValues)); }
        }

        /// <summary>The default polling interval for the drive, in units of 100 ms.</summary>
        public ushort DefaultPollingInterval { get; set; }

        public IScsiPassThrough Interface { get; private set; }

        [Obsolete(
            "Do not use. This is only for viewing the data in the debugger, because manipulating the returned data has no effect. Use the appropriate Get and Set methods instead."
            , true)]
        private SenseData LastSenseData
        {
            get { return GetLastSenseData(); }
        }

        private PowerConditionsModePage PowerConditions
        {
            get { return GetPowerConditions(new ModeSense10Command(PageControl.CurrentValues)); }
        }

        [Obsolete(
            "Do not use. This is only for viewing the data in the debugger, because manipulating the returned data has no effect. Use the appropriate Get and Set methods instead."
            , true)]
        private ReadWriteErrorRecoveryParametersPage ReadWriteErrorRecoveryParameters
        {
            get { return GetReadWriteErrorRecoveryParameters(new ModeSense10Command(PageControl.CurrentValues)); }
        }

        public uint TimeoutSeconds
        {
            get { return _TimeoutSeconds; }
            set { _TimeoutSeconds = value; }
        }

        public uint MaxBlockTransferCount
        {
            get { return _MaxBlockTransferCount; }
        }

        #region IScsiDevice Members

        public virtual uint BlockSize
        {
            get { return GetCapacity().BlockLength; }
        }

        /// <summary>The capacity of the medium, in bytes.</summary>
        [Description("The capacity of the medium, in bytes.")]
        public long Capacity
        {
            get
            {
                ReadCapacityInfo cap = GetCapacity();
                return ((long) cap.LogicalBlockAddress + 1)*cap.BlockLength;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual bool CanRead
        {
            get { return true; }
        }

        public virtual bool CanSeek
        {
            get { return true; }
        }

        public virtual bool CanWrite
        {
            get { return _CanWrite; }
        }

        #endregion

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

        [DebuggerHidden]
        protected void ExecuteCommand(ScsiCommand command, DataTransferDirection direction, BufferWithSize buffer)
        {
            ExecuteCommand(command, direction, buffer, true);
        }

        //[DebuggerHidden]
        protected ScsiStatus ExecuteCommand(ScsiCommand command, DataTransferDirection direction, BufferWithSize buffer,
                                            bool throwOnError)
        {
            bool heapAlloc;
            bool reallocated;

            ScsiStatus status;
            BufferWithSize cdb;
            unsafe
            {
                int cmdSize = Marshaler.SizeOf(command);
                byte* pBuffer = stackalloc byte[cmdSize];
                cdb = new BufferWithSize(pBuffer, cmdSize);
                Marshaler.StructureToPtr(command, cdb);
            }

            BufferWithSize entireAlignedBuffer, portionOfAlignedBuffer;

            unsafe
            {
                int alignment = Interface.AlignmentMask;
                if (((ulong) (void*) buffer.Address & ((uint) alignment - 1)) != 0)
                {
                    int alignedLen = buffer.Length32 + alignment;
                    bool stackAlloc = Marshaler.ShouldStackAlloc(alignedLen);
                    if (stackAlloc)
                    {
                        byte* pData = stackalloc byte[alignedLen];
                        entireAlignedBuffer = new BufferWithSize(pData, alignedLen);
                        heapAlloc = false;
                    }
                    else
                    {
                        entireAlignedBuffer = BufferWithSize.AllocHGlobal(alignedLen);
                        heapAlloc = true;
                    }
                    portionOfAlignedBuffer =
                        entireAlignedBuffer.ExtractSegment(
                            (UIntPtr)
                            ((byte*)
                             ((ulong) ((byte*) entireAlignedBuffer.Address + alignment - 1)/(uint) alignment*
                              (uint) alignment) - (byte*) entireAlignedBuffer.Address), buffer.Length);
                    if (direction == DataTransferDirection.SendData)
                    {
                        BufferWithSize.Copy(buffer, UIntPtr.Zero, portionOfAlignedBuffer, UIntPtr.Zero, buffer.Length);
                    }
                    heapAlloc = !stackAlloc;
                    reallocated = true;
                }
                else
                {
                    entireAlignedBuffer = portionOfAlignedBuffer = buffer;
                    heapAlloc = false;
                    reallocated = false;
                }
            }
            try
            {
                status = Interface.ExecuteCommand(cdb, direction, PathId, TargetId, LogicalUnitNumber,
                                                  portionOfAlignedBuffer, TimeoutSeconds, AutoSense, out lastSenseData);
                if (throwOnError && status != ScsiStatus.Good)
                {
                    throw ScsiException.CreateException(lastSenseData, false);
                }
            }
            finally
            {
                if (reallocated)
                {
                    if (direction == DataTransferDirection.ReceiveData)
                    {
                        BufferWithSize.Copy(portionOfAlignedBuffer, UIntPtr.Zero, buffer, UIntPtr.Zero, buffer.Length);
                    }
                }
                if (reallocated && heapAlloc)
                {
                    BufferWithSize.FreeHGlobal(entireAlignedBuffer);
                }
            }

            return status;
        }

        public CachingModePage GetCachingInformation(ModeSense10Command command)
        {
            return ModeSense10<CachingModePage>(command);
        }

        private ReadCapacityInfo GetCapacity()
        {
            if (capacityInfo.BlockLength == 0 || HasMediumChanged())
            {
                capacityInfo = ReadCapacity();
            }
            return capacityInfo;
        }

        public SenseData GetLastSenseData()
        {
            return lastSenseData.Clone();
        }

        public PowerConditionsModePage GetPowerConditions(ModeSense10Command command)
        {
            return ModeSense10<PowerConditionsModePage>(command);
        }

        public ReadWriteErrorRecoveryParametersPage GetReadWriteErrorRecoveryParameters(ModeSense10Command command)
        {
            return ModeSense10<ReadWriteErrorRecoveryParametersPage>(command);
        }

        protected virtual bool HasMediumChanged()
        {
            return false;
        }

        public StandardInquiryData Inquiry()
        {
            return (StandardInquiryData) Inquiry(new InquiryCommand(null));
        }

        public virtual InquiryData Inquiry(InquiryCommand command)
        {
            if (command.PageCode == null)
            {
                unsafe
                {
                    int bufferSize = StandardInquiryData.MinimumSize;
                    byte* pData1 = stackalloc byte[bufferSize];
                    var buffer = new BufferWithSize(pData1, bufferSize);
                    command.AllocationLength = (ushort) buffer.Length;
                    ExecuteCommand(command, DataTransferDirection.ReceiveData, buffer);
                    byte additionalLength = command.PageCode == null
                                                ? StandardInquiryData.ReadAdditionalLength(buffer)
                                                : (byte) 0;
                    int requiredSize = additionalLength + (int) StandardInquiryData.ADDITIONAL_LENGTH_OFFSET;
                    if (bufferSize < requiredSize)
                    {
                        bufferSize = requiredSize;
                        byte* pData2 = stackalloc byte[bufferSize];
                        buffer = new BufferWithSize(pData2, bufferSize);
                        command.AllocationLength = (ushort) buffer.Length;
                        ExecuteCommand(command, DataTransferDirection.ReceiveData, buffer);
                    }
                    return Marshaler.PtrToStructure<StandardInquiryData>(buffer);
                }
            }
            else if (command.PageCode == VitalProductDataPageCode.SupportedVitalProductDataPages)
            {
                unsafe
                {
                    int bufferSize = Marshaler.DefaultSizeOf<SupportedVitalProductDataPagesDataPage>();
                    byte* pData1 = stackalloc byte[bufferSize];
                    var buffer = new BufferWithSize(pData1, bufferSize);
                    command.AllocationLength = (ushort) buffer.Length;
                    ExecuteCommand(command, DataTransferDirection.ReceiveData, buffer);
                    byte additionalLength = VitalProductDataInquiryData.ReadPageLength(buffer);
                    command.AllocationLength += additionalLength;
                    ExecuteCommand(command, DataTransferDirection.ReceiveData, buffer);
                    return Marshaler.PtrToStructure<SupportedVitalProductDataPagesDataPage>(buffer);
                }
            }
            else
            {
                throw new InvalidOperationException("Vital product data not implemented.");
            }
        }

        public void ModeSense10(ModeSense10Command command, BufferWithSize buffer)
        {
            command.AllocationLength = (ushort) buffer.Length;
            ExecuteCommand(command, DataTransferDirection.ReceiveData, buffer);
        }

        public TModePage ModeSense10<TModePage>(ModeSense10Command command)
            where TModePage : ModePage, new()
        {
            var result = Objects.CreateInstance<TModePage>();
            command.PageCode = result.PageCode;
            unsafe
            {
                int bufferSize = Marshaler.DefaultSizeOf<Mode10ParametersHeader>() +
                                 Marshaler.DefaultSizeOf<TModePage>();
                byte* pBuffer1 = stackalloc byte[bufferSize];
                var buffer = new BufferWithSize(pBuffer1, bufferSize);
                var pHeader = (Mode10ParametersHeader*) buffer.Address;
                command.AllocationLength = (ushort) buffer.LengthU32;
                pHeader->ModeDataLength = (ushort) (buffer.LengthU32 - sizeof (ushort));
                ModeSense10(command, buffer);
                var requiredLength = (byte) (2 + pHeader->ModeDataLength);
                if (buffer.LengthU32 < requiredLength)
                {
                    bufferSize = requiredLength;
                    byte* pBuffer2 = stackalloc byte[bufferSize];
                    buffer = new BufferWithSize(pBuffer2, bufferSize);
                    pHeader = (Mode10ParametersHeader*) buffer.Address;
                    command.AllocationLength = (ushort) buffer.LengthU32;
                    pHeader->ModeDataLength = (ushort) (buffer.LengthU32 - sizeof (ushort));
                    ModeSense10(command, buffer);
                }
                BufferWithSize newBuf = buffer.ExtractSegment(Marshaler.DefaultSizeOf<Mode10ParametersHeader>());
                Marshaler.PtrToStructure(newBuf, ref result);
            }
            return result;
        }

        public void ModeSelect10(ModeSelect10Command command, BufferWithSize buffer)
        {
            if (command.ParameterListLength == 0)
            {
                command.ParameterListLength = (ushort) buffer.Length;
            }
            else if (command.ParameterListLength > buffer.LengthU32)
            {
                throw new ArgumentException("Parameter list length exceeds buffer size.", "command");
            }
            ExecuteCommand(command, DataTransferDirection.SendData, buffer);
        }

        public void ModeSelect10(ModeSelect10Command command, ModePage modePage)
        {
            unsafe
            {
                int bufferSize = Marshaler.SizeOf(modePage) + Marshaler.DefaultSizeOf<Mode10ParametersHeader>();
                byte* pBuffer = stackalloc byte[bufferSize];
                var buffer = new BufferWithSize(pBuffer, bufferSize);
                var pHeader = (Mode10ParametersHeader*) buffer.Address;
                pHeader->ModeDataLength = (ushort) Marshaler.SizeOf(modePage);
                BufferWithSize bufferModePage = buffer.ExtractSegment(Marshaler.DefaultSizeOf<Mode10ParametersHeader>());
                Marshaler.StructureToPtr(modePage, bufferModePage);
                ModeSelect10(command, buffer);
            }
        }

        //public byte[] Read(bool forceUnitAccess, ulong logicalBlockAddress, uint lengthInBlocks) { var bytes = new byte[lengthInBlocks * this.BlockSize]; this.Read(forceUnitAccess, logicalBlockAddress, lengthInBlocks, bytes, 0); return bytes; }

        public void Read(bool forceUnitAccess, ulong logicalBlockAddress, uint lengthInBlocks, byte[] buffer,
                         int bufferOffset)
        {
            //if (lengthInBlocks * this.BlockSize > buffer.Length - bufferOffset) { throw new ArgumentOutOfRangeException("buffer", buffer, "Buffer given was too small."); }
            if (logicalBlockAddress < uint.MaxValue && lengthInBlocks < ushort.MaxValue)
            {
                read10CommandTemp.LogicalBlockAddress = (uint) logicalBlockAddress;
                read10CommandTemp.TransferBlockCount = (ushort) lengthInBlocks;
                read10CommandTemp.ForceUnitAccess = forceUnitAccess;
                Read10(read10CommandTemp, buffer, bufferOffset);
            }
            else if (logicalBlockAddress < uint.MaxValue && lengthInBlocks < uint.MaxValue)
            {
                read12CommandTemp.LogicalBlockAddress = (uint) logicalBlockAddress;
                read12CommandTemp.TransferBlockCount = lengthInBlocks;
                read12CommandTemp.ForceUnitAccess = forceUnitAccess;
                Read12(read12CommandTemp, buffer, bufferOffset);
            }
            else
            {
                read16CommandTemp.LogicalBlockAddress = logicalBlockAddress;
                read16CommandTemp.TransferBlockCount = lengthInBlocks;
                read16CommandTemp.ForceUnitAccess = forceUnitAccess;
                Read16(read16CommandTemp, buffer, bufferOffset);
            }
        }

        //public byte[] Read06(Read06Command command) { var result = new byte[command.TransferBlockCount * this.BlockSize]; this.Read06(command, result, 0); return result; }

        public void Read06(Read06Command command, byte[] buffer, int bufferOffset)
        {
            unsafe
            {
                fixed (byte* pBuffer = &buffer[bufferOffset])
                {
                    Read06(command, new BufferWithSize(pBuffer, buffer.Length - bufferOffset));
                }
            }
        }

        public void Read06(Read06Command command, BufferWithSize buffer)
        {
            uint blockSize = BlockSize;
            if ((ulong) command.TransferBlockCount*blockSize > buffer.LengthU32)
            {
                throw new ArgumentException("Buffer was too small for the given transfer length.", "buffer");
            }
            byte totalTransferBlockCount = command.TransferBlockCount;
            uint maximumTransferBlockCount = MaxBlockTransferCount;

            byte blocksLeft = totalTransferBlockCount;
            while (blocksLeft > 0)
            {
                var blockCountToProcess = (byte) Math.Min(blocksLeft, maximumTransferBlockCount);
                command.TransferBlockCount = blockCountToProcess;
                ExecuteCommand(command, DataTransferDirection.ReceiveData,
                               buffer.ExtractSegment(blockSize*(totalTransferBlockCount - blocksLeft),
                                                     blockSize*blockCountToProcess));
                blocksLeft -= blockCountToProcess;
                unchecked
                {
                    command.LogicalBlockAddress += blockCountToProcess;
                }
            }
        }

        //public byte[] Read10(Read10Command command) { var result = new byte[command.TransferBlockCount * this.BlockSize]; this.Read10(command, result, 0); return result; }

        public void Read10(Read10Command command, byte[] buffer, int bufferOffset)
        {
            unsafe
            {
                fixed (byte* pBuffer = &buffer[bufferOffset])
                {
                    Read10(command, new BufferWithSize(pBuffer, buffer.Length - bufferOffset));
                }
            }
        }

        public void Read10(Read10Command command, BufferWithSize buffer)
        {
            uint blockSize = BlockSize;
            if ((ulong) command.TransferBlockCount*blockSize > buffer.LengthU32)
            {
                throw new ArgumentException("Buffer was too small for the given transfer length.", "buffer");
            }
            ushort totalTransferBlockCount = command.TransferBlockCount;
            uint maximumTransferBlockCount = MaxBlockTransferCount;

            ushort blocksLeft = totalTransferBlockCount;
            while (blocksLeft > 0)
            {
                var blockCountToProcess = (ushort) Math.Min(blocksLeft, maximumTransferBlockCount);
                command.TransferBlockCount = blockCountToProcess;
                ExecuteCommand(command, DataTransferDirection.ReceiveData,
                               buffer.ExtractSegment(blockSize*(totalTransferBlockCount - blocksLeft),
                                                     blockSize*blockCountToProcess));
                blocksLeft -= blockCountToProcess;
                unchecked
                {
                    command.LogicalBlockAddress += blockCountToProcess;
                }
            }
        }

        //public byte[] Read12(Read12Command command) { byte[] result = new byte[command.TransferBlockCount * this.BlockSize]; this.Read12(command, result, 0); return result; }

        public void Read12(Read12Command command, byte[] buffer, int bufferOffset)
        {
            unsafe
            {
                fixed (byte* pBuffer = &buffer[bufferOffset])
                {
                    Read12(command, new BufferWithSize(pBuffer, buffer.Length - bufferOffset));
                }
            }
        }

        public void Read12(Read12Command command, BufferWithSize buffer)
        {
            uint blockSize = BlockSize;
            if ((ulong) command.TransferBlockCount*blockSize > buffer.LengthU32)
            {
                throw new ArgumentException("Buffer was too small for the given transfer length.", "buffer");
            }
            uint totalTransferBlockCount = command.TransferBlockCount;
            uint maximumTransferBlockCount = MaxBlockTransferCount;

            uint blocksLeft = totalTransferBlockCount;
            while (blocksLeft > 0)
            {
                uint blockCountToProcess = Math.Min(blocksLeft, maximumTransferBlockCount);
                command.TransferBlockCount = blockCountToProcess;
                ExecuteCommand(command, DataTransferDirection.ReceiveData,
                               buffer.ExtractSegment(blockSize*(totalTransferBlockCount - blocksLeft),
                                                     blockSize*blockCountToProcess));
                blocksLeft -= blockCountToProcess;
                unchecked
                {
                    command.LogicalBlockAddress += blockCountToProcess;
                }
            }
        }

        //public byte[] Read16(Read16Command command) { var result = new byte[command.TransferBlockCount * this.BlockSize]; this.Read16(command, result, 0); return result; }

        public void Read16(Read16Command command, byte[] buffer, int bufferOffset)
        {
            unsafe
            {
                fixed (byte* pBuffer = &buffer[bufferOffset])
                {
                    Read16(command, new BufferWithSize(pBuffer, buffer.Length - bufferOffset));
                }
            }
        }

        public void Read16(Read16Command command, BufferWithSize buffer)
        {
            uint blockSize = BlockSize;
            if ((ulong) command.TransferBlockCount*blockSize > buffer.LengthU32)
            {
                throw new ArgumentException("Buffer was too small for the given transfer length.", "buffer");
            }
            uint totalTransferBlockCount = command.TransferBlockCount;
            uint maximumTransferBlockCount = MaxBlockTransferCount;

            uint blocksLeft = totalTransferBlockCount;
            while (blocksLeft > 0)
            {
                uint blockCountToProcess = Math.Min(blocksLeft, maximumTransferBlockCount);
                command.TransferBlockCount = blockCountToProcess;
                ExecuteCommand(command, DataTransferDirection.ReceiveData,
                               buffer.ExtractSegment(blockSize*(totalTransferBlockCount - blocksLeft),
                                                     blockSize*blockCountToProcess));
                blocksLeft -= blockCountToProcess;
                unchecked
                {
                    command.LogicalBlockAddress += blockCountToProcess;
                }
            }
        }

        //public byte[] Read32(Read32Command command) { var result = new byte[command.TransferBlockCount * this.BlockSize]; this.Read32(command, result, 0); return result; }

        public void Read32(Read32Command command, byte[] buffer, int bufferOffset)
        {
            unsafe
            {
                fixed (byte* pBuffer = &buffer[bufferOffset])
                {
                    Read32(command, new BufferWithSize(pBuffer, buffer.Length - bufferOffset));
                }
            }
        }

        public void Read32(Read32Command command, BufferWithSize buffer)
        {
            uint blockSize = BlockSize;
            if ((ulong) command.TransferBlockCount*blockSize > buffer.LengthU32)
            {
                throw new ArgumentException("Buffer was too small for the given transfer length.", "buffer");
            }
            uint totalTransferBlockCount = command.TransferBlockCount;
            uint maximumTransferBlockCount = MaxBlockTransferCount;

            uint blocksLeft = totalTransferBlockCount;
            while (blocksLeft > 0)
            {
                uint blockCountToProcess = Math.Min(blocksLeft, maximumTransferBlockCount);
                command.TransferBlockCount = blockCountToProcess;
                ExecuteCommand(command, DataTransferDirection.ReceiveData,
                               buffer.ExtractSegment(blockSize*(totalTransferBlockCount - blocksLeft),
                                                     blockSize*blockCountToProcess));
                blocksLeft -= blockCountToProcess;
                unchecked
                {
                    command.LogicalBlockAddress += blockCountToProcess;
                }
            }
        }

        public byte[] ReadBufferData(ReadBufferCommand command, int length)
        {
            var result = new byte[length];
            ReadBufferData(command, result, 0);
            return result;
        }

        public void ReadBufferData(ReadBufferCommand command, byte[] buffer, int resultOffset)
        {
            ReadBufferData(command, buffer, resultOffset, buffer.Length - resultOffset);
        }

        public void ReadBufferData(ReadBufferCommand command, byte[] buffer, int resultOffset, int resultLength)
        {
            if (resultLength > buffer.Length - resultOffset)
            {
                throw new ArgumentOutOfRangeException("resultLength", resultLength,
                                                      "Result length cannot overflow buffer.");
            }
            unsafe
            {
                fixed (byte* pBuffer = buffer)
                {
                    ReadBufferData(command, new BufferWithSize(pBuffer + resultOffset, resultLength));
                }
            }
        }

        public void ReadBufferData(ReadBufferCommand command, BufferWithSize buffer)
        {
            command.Mode = ReadBufferMode.Data;
            ReadBuffer(command, buffer);
        }

        public ReadBufferDescriptor ReadBufferDescriptor(ReadBufferCommand command)
        {
            var result = new ReadBufferDescriptor();
            command.Mode = ReadBufferMode.Descriptor;
            unsafe
            {
                ReadBuffer(command,
                           new BufferWithSize((IntPtr) (&result), Marshaler.DefaultSizeOf<ReadBufferDescriptor>()));
            }
            return result;
        }

        public BufferCombinedHeaderAndData ReadBufferCombinedHeaderAndData(ReadBufferCommand command)
        {
            command.Mode = ReadBufferMode.CombinedHeaderAndData;
            unsafe
            {
                BufferWithSize buffer;
                int bufferSize = Marshaler.DefaultSizeOf<BufferCombinedHeaderAndData>();
                bool stackAlloc = Marshaler.ShouldStackAlloc(bufferSize);
                if (stackAlloc)
                {
                    byte* pResult1 = stackalloc byte[bufferSize];
                    buffer = new BufferWithSize(pResult1, bufferSize);
                }
                else
                {
                    buffer = BufferWithSize.AllocHGlobal(bufferSize);
                }
                try
                {
                    ReadBuffer(command, buffer);
                    int requiredSize = (int) BufferCombinedHeaderAndData.ReadBufferCapacity(buffer.Address) +
                                       Marshaler.DefaultSizeOf<BufferCombinedHeaderAndData>();
                    if (bufferSize < requiredSize)
                    {
                        bufferSize = requiredSize;
                        bool stackAlloc2 = Marshaler.ShouldStackAlloc(bufferSize);
                        if (stackAlloc)
                        {
                            if (stackAlloc2)
                            {
                                byte* pResult2 = stackalloc byte[bufferSize];
                                buffer = new BufferWithSize(pResult2, bufferSize);
                            }
                            else
                            {
                                buffer = BufferWithSize.AllocHGlobal(bufferSize);
                            }
                        }
                        else
                        {
                            if (stackAlloc2)
                            {
                                BufferWithSize.FreeHGlobal(buffer);
                                byte* pResult2 = stackalloc byte[bufferSize];
                                buffer = new BufferWithSize(pResult2, bufferSize);
                            }
                            else
                            {
                                buffer = BufferWithSize.ReAllocHGlobal(buffer, bufferSize);
                            }
                        }
                        stackAlloc = stackAlloc2;
                        ReadBuffer(command, buffer);
                    }
                    return Marshaler.PtrToStructure<BufferCombinedHeaderAndData>(buffer);
                }
                finally
                {
                    if (!stackAlloc)
                    {
                        BufferWithSize.FreeHGlobal(buffer);
                    }
                }
            }
        }

        private void ReadBuffer(ReadBufferCommand command, BufferWithSize buffer)
        {
            command.AllocationLength = (ushort) buffer.Length;
            ExecuteCommand(command, DataTransferDirection.ReceiveData, buffer);
        }

        public ReadCapacityInfo ReadCapacity()
        {
            return ReadCapacity(new ReadCapacityCommand());
        }

        public ReadCapacityInfo ReadCapacity(ReadCapacityCommand command)
        {
            var result = new ReadCapacityInfo();
            unsafe
            {
                ExecuteCommand(command, DataTransferDirection.ReceiveData,
                               new BufferWithSize((IntPtr) (&result), Marshaler.DefaultSizeOf<ReadCapacityInfo>()));
            }
            return result;
        }

        public SenseData RequestSense()
        {
            return RequestSense(new RequestSenseCommand());
        }

        public SenseData RequestSense(RequestSenseCommand command)
        {
            SenseData result;
            unsafe
            {
                int bufferSize = 252;
                byte* pSenseData = stackalloc byte[bufferSize];
                var buffer = new BufferWithSize(pSenseData, bufferSize);
                command.AllocationLength = (byte) buffer.Length;
                ExecuteCommand(command, DataTransferDirection.ReceiveData, buffer);
                result = Marshaler.PtrToStructure<SenseData>(buffer);
            }
            return result;
        }

        public void Seek10(Seek10Command command)
        {
            ExecuteCommand(command, DataTransferDirection.NoData, BufferWithSize.Zero);
        }

        public void SendDiagnostic(SendDiagnosticCommand command)
        {
            SendDiagnostic(command, BufferWithSize.Zero);
        }

        public void SendDiagnostic(SendDiagnosticCommand command, BufferWithSize buffer)
        {
            command.ParameterListLength = (byte) buffer.Length;
            switch (command.SelfTestCode)
            {
                case SelfTestCode.BackgroundShortSelfTest:
                    if (command.ParameterListLength != 0)
                    {
                        throw new InvalidOperationException();
                    }
                    break;
                case SelfTestCode.BackgroundExtendedSelfTest:
                    if (command.ParameterListLength != 0)
                    {
                        throw new InvalidOperationException();
                    }
                    break;
                case SelfTestCode.AbortBackgroundSelfTest:
                    if (command.ParameterListLength != 0)
                    {
                        throw new InvalidOperationException();
                    }
                    break;
                case SelfTestCode.ForegroundShortSelfTest:
                    if (command.ParameterListLength != 0)
                    {
                        throw new InvalidOperationException();
                    }
                    break;
                case SelfTestCode.ForegroundExtendedSelfTest:
                    if (command.ParameterListLength != 0)
                    {
                        throw new InvalidOperationException();
                    }
                    break;
                case null:
                    if (command.ParameterListLength != 0)
                    {
                        throw new InvalidOperationException();
                    }
                    break;
            }
            ExecuteCommand(command, DataTransferDirection.SendData, buffer);
        }

        public void SetCachingInformation(ModeSelect10Command command, CachingModePage modePage)
        {
            ModeSelect10(command, modePage);
        }

        public void SetPowerConditions(ModeSelect10Command command, PowerConditionsModePage modePage)
        {
            ModeSelect10(command, modePage);
        }

        public void SetReadWriteErrorRecoveryParameters(ModeSelect10Command command,
                                                        ReadWriteErrorRecoveryParametersPage modePage)
        {
            ModeSelect10(command, modePage);
        }

        public void SetRemovableMediaBit(SetRemovableMediaBitCommand command)
        {
            unsafe
            {
                const byte BUFFER_SIZE = 36;
                byte* pBuffer = stackalloc byte[BUFFER_SIZE];
                ExecuteCommand(command, DataTransferDirection.SendData, new BufferWithSize(pBuffer, BUFFER_SIZE));
            }
        }

        public void SynchronizeCache()
        {
            SynchronizeCache(new SynchronizeCache10Command());
        }

        public void SynchronizeCache(SynchronizeCache10Command command)
        {
            ExecuteCommand(command, DataTransferDirection.NoData, BufferWithSize.Zero);
        }

        public ScsiStatus TestUnitReady()
        {
            return TestUnitReady(new TestUnitReadyCommand());
        }

        public ScsiStatus TestUnitReady(TestUnitReadyCommand command)
        {
            return ExecuteCommand(command, DataTransferDirection.NoData, BufferWithSize.Zero, false);
        }

        public void Write(bool forceUnitAccess, ulong logicalBlockAddress, uint lengthInBlocks, byte[] buffer,
                          int bufferOffset)
        {
            //if (lengthInBlocks * this.BlockSize > buffer.Length - bufferOffset) { throw new ArgumentOutOfRangeException("buffer", buffer, "Buffer given was too small."); }
            if (logicalBlockAddress < uint.MaxValue && lengthInBlocks < ushort.MaxValue)
            {
                write10CommandTemp.LogicalBlockAddress = (uint) logicalBlockAddress;
                write10CommandTemp.TransferBlockCount = (ushort) lengthInBlocks;
                write10CommandTemp.ForceUnitAccess = forceUnitAccess;
                Write10(write10CommandTemp, buffer, bufferOffset);
            }
            else if (logicalBlockAddress < uint.MaxValue && lengthInBlocks < uint.MaxValue)
            {
                write12CommandTemp.LogicalBlockAddress = (uint) logicalBlockAddress;
                write12CommandTemp.TransferBlockCount = lengthInBlocks;
                write12CommandTemp.ForceUnitAccess = forceUnitAccess;
                Write12(write12CommandTemp, buffer, bufferOffset);
            }
            else
            {
                throw new NotSupportedException();
            }
        }

        public void Write10(Write10Command command, byte[] buffer, int bufferOffset)
        {
            unsafe
            {
                fixed (byte* pBuffer = &buffer[bufferOffset])
                {
                    Write10(command, new BufferWithSize(pBuffer, buffer.Length - bufferOffset));
                }
            }
        }

        public void Write10(Write10Command command, BufferWithSize buffer)
        {
            uint blockSize = BlockSize;
            if ((ulong) command.TransferBlockCount*blockSize > buffer.LengthU32)
            {
                throw new ArgumentException("Buffer was too small for the given transfer length.", "buffer");
            }
            ushort totalTransferBlockCount = command.TransferBlockCount;
            uint maximumTransferBlockCount = MaxBlockTransferCount;

            ushort blocksLeft = totalTransferBlockCount;
            while (blocksLeft > 0)
            {
                var blockCountToProcess = (ushort) Math.Min(blocksLeft, maximumTransferBlockCount);
                command.TransferBlockCount = blockCountToProcess;
                ExecuteCommand(command, DataTransferDirection.SendData,
                               buffer.ExtractSegment(blockSize*(totalTransferBlockCount - blocksLeft),
                                                     blockSize*blockCountToProcess));
                blocksLeft -= blockCountToProcess;
                unchecked
                {
                    command.LogicalBlockAddress += blockCountToProcess;
                }
            }
        }

        public void Write12(Write12Command command, byte[] buffer, int bufferOffset)
        {
            unsafe
            {
                fixed (byte* pBuffer = &buffer[bufferOffset])
                {
                    Write12(command, new BufferWithSize(pBuffer, buffer.Length - bufferOffset));
                }
            }
        }

        public void Write12(Write12Command command, BufferWithSize buffer)
        {
            uint blockSize = BlockSize;
            if ((ulong) command.TransferBlockCount*blockSize > buffer.LengthU32)
            {
                throw new ArgumentException("Buffer was too small for the given transfer length.", "buffer");
            }
            uint totalTransferBlockCount = command.TransferBlockCount;
            uint maximumTransferBlockCount = MaxBlockTransferCount;

            uint blocksLeft = totalTransferBlockCount;
            while (blocksLeft > 0)
            {
                uint blockCountToProcess = Math.Min(blocksLeft, maximumTransferBlockCount);
                command.TransferBlockCount = blockCountToProcess;
                ExecuteCommand(command, DataTransferDirection.SendData,
                               buffer.ExtractSegment(blockSize*(totalTransferBlockCount - blocksLeft),
                                                     blockSize*blockCountToProcess));
                blocksLeft -= blockCountToProcess;
                unchecked
                {
                    command.LogicalBlockAddress += blockCountToProcess;
                }
            }
        }


        public static ScsiDevice Create(IScsiPassThrough passThrough, bool leaveOpen)
        {
            StandardInquiryData inq = passThrough.ScsiInquiry(true);
            ScsiDevice result;
            switch (inq.PeripheralDeviceType)
            {
                case PeripheralDeviceType.DirectAccessBlockDevice:
                    result = new BlockDevice(passThrough, leaveOpen);
                    break;
                case PeripheralDeviceType.CDDvdDevice:
                    result = new MultimediaDevice(passThrough, leaveOpen);
                    break;
                default:
                    result = new ScsiDevice(passThrough, leaveOpen);
                    break;
            }
            return result;
        }

        #region IScsiDevice

        public virtual ScsiStatus Status
        {
            get { return TestUnitReady(); }
        }

        void IScsiDevice.Read(long position, byte[] buffer, int bufferOffset, int length, bool forceUnitAccess)
        {
            Read(position, buffer, bufferOffset, length, forceUnitAccess);
        }

        void IScsiDevice.Write(long position, byte[] buffer, int bufferOffset, int length, bool forceUnitAccess)
        {
            Write(position, buffer, bufferOffset, length, forceUnitAccess);
        }

        void IScsiDevice.Flush()
        {
            Flush();
        }

        protected virtual void Read(long position, byte[] buffer, int bufferOffset, int length, bool forceUnitAccess)
        {
            uint blockSize = BlockSize;
            long rem;
            long logicalBlockAddress = Math.DivRem(position, blockSize, out rem);
            if (rem != 0)
            {
                var ex = new DataMisalignedException();
                throw new ArgumentException(null, "position", ex);
            }
            var blockLength = (uint) Math.DivRem(length, blockSize, out rem);
            if (rem != 0)
            {
                var ex = new DataMisalignedException();
                throw new ArgumentException(null, "length", ex);
            }
            Read(forceUnitAccess, (ulong) logicalBlockAddress, blockLength, buffer, bufferOffset);
        }

        protected virtual void Write(long position, byte[] buffer, int bufferOffset, int length, bool forceUnitAccess)
        {
            bool unaligned = false;
            long rem;
            uint blockSize = BlockSize;
            long logicalBlockAddress = Math.DivRem(position, blockSize, out rem);
            //if (rem != 0) { var ex = new DataMisalignedException(); throw new ArgumentException("Value is not aligned to the correct boundary.", "position", ex); }
            unaligned |= rem != 0;
            var blockLength = (uint) Math.DivRem(length, blockSize, out rem);
            //if (rem != 0) { var ex = new DataMisalignedException(); throw new ArgumentException("Value is not aligned to the correct boundary.", "length", ex); }
            unaligned |= rem != 0;
            if (length > buffer.Length - bufferOffset)
            {
                throw new ArgumentException(
                    "Offset and length were out of bounds for the array or count is greater than the number of elements from index to the end of the source collection.");
            }
            if (!unaligned)
            {
                Write(forceUnitAccess, (ulong) logicalBlockAddress, blockLength, buffer, bufferOffset);
            }
            else
            {
                uint bpsRead = blockSize;
                uint bpsWrite = blockSize;
                if (bpsRead != bpsWrite)
                {
                    throw new NotSupportedException("Read-Modify-Write not supported for unequal block lengths.");
                }
                long alignedPosition = position/bpsWrite*bpsWrite;

                var alignedData = new byte[(position + length - alignedPosition + bpsWrite - 1)/bpsWrite*bpsWrite];
                Read(alignedPosition, alignedData, 0, alignedData.Length, forceUnitAccess);
                Buffer.BlockCopy(buffer, bufferOffset, alignedData, (int) (position - alignedPosition), length);
                Write(forceUnitAccess, (ulong) alignedPosition/bpsWrite, (uint) alignedData.Length/bpsWrite, alignedData,
                      0);
            }
        }

        protected virtual void Flush()
        {
            SynchronizeCache(new SynchronizeCache10Command());
        }

        #endregion
    }
}