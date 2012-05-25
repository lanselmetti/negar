using System;
using System.IO;
using Helper;
namespace FileSystems.Udf
{
	//Whenever a property is set, set the Dirty bit to TRUE!!
	public class FileEntryInformationControlBlock
	{
		private UdfLogicalVolume.UdfFileSet fileSet;
		private FileEntryInformationControlBlockDescriptorBase descriptor;
		private ushort myPartitionNumber;

		public FileEntryInformationControlBlock(UdfLogicalVolume.UdfFileSet fileSet, ushort myPartitionNumber, FileEntryInformationControlBlockDescriptorBase descriptor)
		{
			this.fileSet = fileSet;
			this.myPartitionNumber = myPartitionNumber;
			this.descriptor = descriptor;
		}

		public Timestamp AccessTime { get { return this.descriptor.AccessTime; } set { this.Dirty = true; this.descriptor.AccessTime = value; } }
		public Timestamp AttributeTime { get { return this.descriptor.AttributeTime; } set { this.Dirty = true; this.descriptor.AttributeTime = value; } }
		public uint Checkpoint { get { return this.descriptor.Checkpoint; } set { this.Dirty = true; this.descriptor.Checkpoint = value; } }
		internal bool Dirty { get; private set; }
		public ushort FileLinkCount { get { return this.descriptor.FileLinkCount; } set { this.Dirty = true; this.descriptor.FileLinkCount = value; } }
		public uint GroupIdentifier { get { return this.descriptor.GroupIdentifier; } set { this.Dirty = true; this.descriptor.GroupIdentifier = value; } }
		public EntityIdentifier ImplementationIdentifier { get { return this.descriptor.ImplementationIdentifier; } set { this.Dirty = true; this.descriptor.ImplementationIdentifier = value; } }
		public long InformationLength { get { return this.descriptor.InformationLength; } }
		public Timestamp ModificationTime { get { return this.descriptor.ModificationTime; } set { this.Dirty = true; this.descriptor.ModificationTime = value; } }
		public UdfFilePermissions Permissions { get { return this.descriptor.Permissions; } set { this.Dirty = true; this.descriptor.Permissions = value; } }
		public IcbRecordDisplayCharacteristics RecordDisplayAttributes { get { return this.descriptor.RecordDisplayAttributes; } set { this.Dirty = true; this.descriptor.RecordDisplayAttributes = value; } }
		public IcbRecordFormat RecordFormat { get { return this.descriptor.RecordFormat; } set { this.Dirty = true; this.descriptor.RecordFormat = value; } }
		public uint RecordLength { get { return this.descriptor.RecordLength; } set { this.Dirty = true; this.descriptor.RecordLength = value; } }
		public ulong UniqueIdentifier { get { return this.descriptor.UniqueIdentifier; } set { this.Dirty = true; this.descriptor.UniqueIdentifier = value; } }
		public uint UserIdentifier { get { return this.descriptor.UserIdentifier; } set { this.Dirty = true; this.descriptor.UserIdentifier = value; } }

		public int Read(long pos, byte[] buffer, int bufferOffset, int length)
		{
			if (length < 0) { throw new ArgumentOutOfRangeException("length", length, "Nonnegative number required."); }
			if (bufferOffset < 0) { throw new ArgumentOutOfRangeException("bufferOffset", bufferOffset, "Nonnegative number required."); }

			if (this.descriptor.InformationLength > pos + length)
			{
				length = (int)(this.descriptor.InformationLength - pos);
			}

			int totalRead;
			if ((AllocationDescriptorType)(this.descriptor.Flags & IcbFlags.AllocationDescriptorTypeMask) == AllocationDescriptorType.DataResidentInAllocationDescriptors)
			{
				Array.Copy(this.descriptor.AllocationDescriptors, pos, buffer, bufferOffset, length);
				totalRead = length;
			}
			else if ((AllocationDescriptorType)(this.descriptor.Flags & IcbFlags.AllocationDescriptorTypeMask) == AllocationDescriptorType.ExtendedAllocationDescriptors)
			{ throw new InvalidOperationException("ExtendedAllocationDescriptors are invalid in UDF."); }
			else if ((AllocationDescriptorType)(this.descriptor.Flags & IcbFlags.AllocationDescriptorTypeMask) == AllocationDescriptorType.LongAllocationDescriptors)
			{
				totalRead = 0;
				int offset = 0;
				while (offset < this.descriptor.AllocationDescriptors.Length)
				{
					var ad = Marshaler.PtrToStructure<LongAllocationDescriptor>(this.descriptor.AllocationDescriptors, offset);
					int read = this.fileSet.Volume.Read(ad, (AllocationDescriptorType)(this.descriptor.Flags & IcbFlags.AllocationDescriptorTypeMask), 0, buffer, bufferOffset, length);
					if (read != ad.ShortAllocationDescriptor.ByteLength) { throw new InvalidOperationException("Expected to read the entire extent."); }
					totalRead += read;
					length -= read;
					offset += Marshaler.SizeOf(ad);
				}
			}
			else if ((AllocationDescriptorType)(this.descriptor.Flags & IcbFlags.AllocationDescriptorTypeMask) == AllocationDescriptorType.ShortAllocationDescriptors)
			{
				totalRead = 0;
				int offset = 0;
				while (offset < this.descriptor.AllocationDescriptors.Length)
				{
					var ad = Marshaler.PtrToStructure<ShortAllocationDescriptor>(this.descriptor.AllocationDescriptors, offset);
					int read = this.fileSet.Volume.Read(new LongAllocationDescriptor(ad, this.myPartitionNumber, ExtentFlags.None, 0), (AllocationDescriptorType)(this.descriptor.Flags & IcbFlags.AllocationDescriptorTypeMask), 0, buffer, bufferOffset, length);
					if (read != ad.ByteLength) { throw new InvalidOperationException("Expected to read the entire extent."); }
					totalRead += read;
					length -= read;
					offset += Marshaler.SizeOf(ad);
				}
			}
			else { throw new InvalidOperationException("Invalid ICB type."); }

			return totalRead;
		}

		public void SetLength(long value)
		{
			//Don't forget to:
			//Set InformationLength, LogicalBlocksRecorded, AllocationDescriptors, and Allocation Type
			//Unallocate space
			this.Dirty = true;
		}

		public void Write(byte[] buffer, int offset, int count)
		{
			/*NOTE: Any allocation changes (whether extent type or location) must mark this record as dirty!*/
			throw new NotImplementedException();
		}
	}
}