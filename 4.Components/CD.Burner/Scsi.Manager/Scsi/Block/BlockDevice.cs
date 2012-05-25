using System;
using Helper;

namespace Scsi.Block
{
    /// <summary>Represents a block device (e.g. a hard disk).</summary>
    public class BlockDevice : ScsiDevice
    {
        /// <summary>Initializes a new instance of the <see cref="BlockDevice"/> class.</summary>
        /// <param name="interface">The pass-through interface to use.</param>
        /// <param name="leaveOpen"><c>true</c> to leave the interface open, or <c>false</c> to dispose along with this object.</param>
        public BlockDevice(IScsiPassThrough @interface, bool leaveOpen) : base(@interface, leaveOpen)
        {
        }

        public override InquiryData Inquiry(InquiryCommand command)
        {
            if (command.PageCode == VitalProductDataPageCode.BlockLimits)
            {
                unsafe
                {
                    int bufferSize = Marshaler.DefaultSizeOf<BlockLimitsVitalProductDataPage>();
                    byte* pData1 = stackalloc byte[bufferSize];
                    var buffer = new BufferWithSize(pData1, bufferSize);
                    command.AllocationLength = (ushort) buffer.Length;
                    ExecuteCommand(command, DataTransferDirection.ReceiveData, buffer);
                    return Marshaler.PtrToStructure<BlockLimitsVitalProductDataPage>(buffer);
                }
            }
            else
            {
                return base.Inquiry(command);
            }
        }

        public void StartStopUnit(StartStopUnitCommand command)
        {
            try
            {
                ExecuteCommand(command, DataTransferDirection.NoData, BufferWithSize.Zero);
            }
            catch (ScsiException ex)
            {
                SenseData sense = ex.SenseData;
                if (sense.SenseKey == SenseKey.IllegalRequest ^
                    sense.AdditionalSenseCode == AdditionalSenseCode.InvalidFieldInCommandDescriptorBlock)
                {
                    throw new InvalidOperationException("An error occurred. This operation may not be supported.", ex);
                }
                throw;
            }
        }
    }
}