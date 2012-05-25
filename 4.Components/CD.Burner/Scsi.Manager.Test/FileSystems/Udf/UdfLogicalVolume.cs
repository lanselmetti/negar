using System;
using System.Diagnostics;
using System.IO;
using Helper.IO;
using Helper;

namespace FileSystems.Udf
{
	public partial class UdfLogicalVolume : IDisposable
	{
		private UdfPartition[] partitions;
		private LogicalVolumeDescriptor descriptor;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private LogicalVolumeIntegrityDescriptor _IntegrityDescriptor;
		private UdfVolume fs;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool leaveOpen;
		private UdfFileSet _FileSet;

		//IMPORTANT NOTE: You CANNOT change the Logical Volume Identifier or a Partition Number unless you notify UdfVolume first!

		internal UdfLogicalVolume(UdfVolume fs, LogicalVolumeDescriptor descriptor, UdfPartition[] partitions, bool leavePartitionsOpen)
		{
			this.fs = fs;
			this.partitions = partitions;
			this.descriptor = descriptor;
			this.leaveOpen = leavePartitionsOpen;
		}

		~UdfLogicalVolume() { this.Dispose(false); }

		public void Dispose() { this.Dispose(true); GC.SuppressFinalize(this); }

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				try
				{
					if (!this.leaveOpen)
					{
						for (int i = 0; i < this.partitions.Length; i++)
						{
							this.partitions[i].Dispose();
							this.partitions[i] = null;
						}
					}
				}
				finally { this.partitions = null; }
			}
		}

		//public LongAllocationDescriptor[] Allocate(ushort preferredPartition, ushort preferredBlock, long bytesToAllocate) { throw new NotImplementedException(); }

		public UdfFileSet FileSet
		{
			get
			{
				if (this._FileSet == null)
				{
					var extent = this.descriptor.FileSetDescriptorExtent;
					//Assume partition[i] is number i
					var data = new byte[extent.ShortAllocationDescriptor.ByteLength];
					int read = this.Read(extent, AllocationDescriptorType.ShortAllocationDescriptors, 0, data, 0, data.Length);
					Trace.Assert(read == data.Length);
					var converted = (FileSetDescriptor)this.fs.ConvertTaggedDescriptorToManaged(data, 0, true);
					if (converted.TagLocation != extent.ExtentLocation.LogicalBlockNumber / this.LogicalBlockSize) { throw new InvalidDataException("Invalid integrity descriptor."); }
					this._FileSet = new UdfFileSet(this, converted);
				}
				return this._FileSet;
			}
		}

		private LogicalVolumeIntegrityDescriptor IntegrityDescriptor
		{
			get
			{
				if (this._IntegrityDescriptor == null)
				{
					var extent = this.descriptor.IntegritySequenceExtent;
					//Assume partition[i] is number i
					var data = new byte[extent.ByteLength];
					long newPosition = this.fs.LogicalSectorSize * extent.LogicalSectorNumber;
					if (newPosition != this.fs.BaseStream.Position) { this.fs.BaseStream.Position = newPosition; }
					this.fs.BaseStream.ReadExactly(data, 0, data.Length);
					var converted = (LogicalVolumeIntegrityDescriptor)this.fs.ConvertTaggedDescriptorToManaged(data, 0, true);
					if (converted.TagLocation != newPosition / this.LogicalBlockSize) { throw new InvalidDataException("Invalid integrity descriptor."); }
					this._IntegrityDescriptor = converted;
				}
				return this._IntegrityDescriptor;
			}
		}

		//Actually unsigned, but no one uses 2-GB block sizes... making these signed prevents unnecessary casts elsewhere
		public int LogicalBlockSize { get { return this.descriptor.LogicalBlockSize; } }

		public int MaximumExtentLength { get { return (1 << 30) - this.LogicalBlockSize; } }

		/// <param name="type">The type of allocation descriptors to read if <see cref="allocationDescriptor.ShortAllocationDescriptor.ExtentType"/> is <see cref="ExtentType.ExtentOfNextAllocationDescriptors"/>. In other cases, this value has no meaning and is ignored.</param>
		public int Read(LongAllocationDescriptor allocationDescriptor, AllocationDescriptorType type, long byteOffset, byte[] buffer, int bufferOffset, int length)
		{
			if (bufferOffset < 0) { throw new ArgumentOutOfRangeException("bufferOffset", bufferOffset, "Nonnegative number required."); }
			if (length < 0) { throw new ArgumentOutOfRangeException("length", length, "Nonnegative number required."); }
			if (byteOffset < 0) { throw new ArgumentOutOfRangeException("byteOffset", byteOffset, "Nonnegative number required."); }
			if (buffer.Length < bufferOffset + length) { throw new ArgumentException("Offset and length were out of bounds for the array or count is greater than the number of elements from index to the end of the source collection."); }
			int read;
			if (allocationDescriptor.ShortAllocationDescriptor.AllocationType != ExtentType.NextAllocationDescriptorsExtent)
			{ if (allocationDescriptor.ShortAllocationDescriptor.ByteLength < length) { throw new ArgumentException("Cannot read more data than the allocation descriptor describes.", "length"); } }
			var partition = this.partitions[allocationDescriptor.ExtentLocation.PartitionReferenceNumber];
			switch (allocationDescriptor.ShortAllocationDescriptor.AllocationType)
			{
				case ExtentType.Recorded:
					long newPosition = allocationDescriptor.ExtentLocation.LogicalBlockNumber * this.LogicalBlockSize;
					if (newPosition != partition.Position) { partition.Position = newPosition; }
					read = partition.ReadFully(buffer, bufferOffset, allocationDescriptor.ShortAllocationDescriptor.ByteLength);
					break;
				case ExtentType.Allocated:
				case ExtentType.Unallocated:
					if (buffer.Length - bufferOffset == length) { buffer.Initialize(); }
					else { unsafe { fixed (byte* pBuffer = &buffer[bufferOffset]) { for (uint i = 0; i < length; i++) { pBuffer[i] = 0; } } } }
					read = length;
					break;
				case ExtentType.NextAllocationDescriptorsExtent:
					AllocationExtentDescriptor allocExtDesc;
					{
						var allocExtDescBin = new byte[allocationDescriptor.ShortAllocationDescriptor.ByteLength];
						partition.ReadExactly(allocExtDescBin, 0, allocExtDescBin.Length);
						allocExtDesc = (AllocationExtentDescriptor)partition.Volume.ConvertTaggedDescriptorToManaged(allocExtDescBin, 0, true);
					}
					read = 0;
					int allocExtDescOffset = 0;
					while (allocExtDescOffset < allocExtDesc.AllocationDescriptors.Length && length > 0)
					{
						LongAllocationDescriptor longAd;
						switch (type)
						{
							case AllocationDescriptorType.ShortAllocationDescriptors:
								var shortAd = Marshaler.PtrToStructure<ShortAllocationDescriptor>(allocExtDesc.AllocationDescriptors, allocExtDescOffset);
								longAd = new LongAllocationDescriptor(shortAd, allocationDescriptor.ExtentLocation.PartitionReferenceNumber, ExtentFlags.None, 0);
								allocExtDescOffset += Marshaler.SizeOf(shortAd);
								break;
							case AllocationDescriptorType.LongAllocationDescriptors:
								longAd = Marshaler.PtrToStructure<LongAllocationDescriptor>(allocExtDesc.AllocationDescriptors, allocExtDescOffset);
								allocExtDescOffset += Marshaler.SizeOf(longAd);
								break;
							case AllocationDescriptorType.ExtendedAllocationDescriptors:
								throw new NotSupportedException("Extended Allocation Descriptors not valid in UDF.");
							case AllocationDescriptorType.DataResidentInAllocationDescriptors: //If it were resident then it wouldn't be here
							default:
								throw new ArgumentOutOfRangeException("type", type, "Invalid extent type.");
						}
						int r = this.Read(longAd, type, byteOffset, buffer, bufferOffset, length);
						if (r != length) { throw new InvalidOperationException("Expected to read entire length."); }
						byteOffset += r;
						bufferOffset += r;
						read += r;
						length -= r;
					}
					break;
				default:
					throw new ArgumentOutOfRangeException("extent", allocationDescriptor, "Invalid extent allocation type.");
			}
			return read;
		}

		/// <param name="type">The type of allocation descriptors to read if <see cref="allocationDescriptor.ShortAllocationDescriptor.ExtentType"/> is <see cref="ExtentType.ExtentOfNextAllocationDescriptors"/>. In other cases, this value has no meaning and is ignored.</param>
		public void Write(LongAllocationDescriptor allocationDescriptor, AllocationDescriptorType type, long byteOffset, byte[] buffer, int bufferOffset, int length)
		{
			if (bufferOffset < 0) { throw new ArgumentOutOfRangeException("bufferOffset", bufferOffset, "Nonnegative number required."); }
			if (length < 0) { throw new ArgumentOutOfRangeException("length", length, "Nonnegative number required."); }
			if (byteOffset < 0) { throw new ArgumentOutOfRangeException("byteOffset", byteOffset, "Nonnegative number required."); }
			if (buffer.Length < bufferOffset + length) { throw new ArgumentException("Offset and length were out of bounds for the array or count is greater than the number of elements from index to the end of the source collection."); }

			if ((this.DomainIdentifier.Flags & (DomainFlags.SoftWriteProtect | DomainFlags.HardWriteProtect)) != 0)
			{ throw new IOException("The logical volume is write-protected.", new UnauthorizedAccessException()); }

			throw new NotImplementedException();
		}

		public DomainIdentifierSuffix DomainIdentifier { get { return this.descriptor.DomainIdentifier.DomainSuffix; } }
	}
}