using Helper.Collections;
using Helper.IO;
using System.Diagnostics;
using System;
using Helper;

namespace FileSystems.Udf
{
	public partial class UdfLogicalVolume
	{
		public class UdfFileSet
		{
			/// <summary>Important: Do **NOT** change the ICB's tag location; that is its key here!!</summary>
			private WeakDictionary<LongAllocationDescriptor, InformationControlBlockDescriptor> icbCache = new WeakDictionary<LongAllocationDescriptor, InformationControlBlockDescriptor>();

			internal UdfFileSet(UdfLogicalVolume volume, FileSetDescriptor fileSetDescriptor) { this.Volume = volume; this.FileSetDescriptor = fileSetDescriptor; }

			public FileSetDescriptor FileSetDescriptor { get; private set; }

			public InformationControlBlockDescriptor RootInformationControlBlock { get { return this.GetIcb(this.FileSetDescriptor.RootDirectoryIcb); } }

			public UdfLogicalVolume Volume { get; private set; }

			/// <param name="extent">The extent of the ICB. This extent must have either the type <see cref="ExtentType.RecordedAndAllocated"/> or the type <see cref="ExtentType.UnrecordedAndAllocated"/>, and it must be no larger than one logical block.</param>
			public InformationControlBlockDescriptor GetIcb(LongAllocationDescriptor extent)
			{
				if (extent.ShortAllocationDescriptor.ByteLength > this.Volume.LogicalBlockSize ||
					(extent.ShortAllocationDescriptor.AllocationType != ExtentType.Recorded && extent.ShortAllocationDescriptor.AllocationType != ExtentType.Allocated))
				{ throw new ArgumentOutOfRangeException("extent", extent, "Invalid ICB extent."); }
				var result = this.icbCache.TryGetValue(extent);
				if (result == null)
				{
					var icbData = new byte[this.Volume.LogicalBlockSize];
					int read = this.Volume.Read(extent, AllocationDescriptorType.LongAllocationDescriptors, 0, icbData, 0, icbData.Length);
					Trace.Assert(read == icbData.Length);
					result = (InformationControlBlockDescriptor)this.Volume.fs.ConvertTaggedDescriptorToManaged(icbData, 0, true);
					if (result.TagLocation != extent.ExtentLocation.LogicalBlockNumber) { throw new InvalidOperationException("ICB did not have a correct tag location."); }
					this.icbCache[extent] = result;
				}
				return result;
			}

			public InformationControlBlockDescriptor UpdateIcb(LongAllocationDescriptor extent, InformationControlBlockDescriptor icb)
			{
				if (extent.ShortAllocationDescriptor.AllocationType != ExtentType.Recorded && extent.ShortAllocationDescriptor.AllocationType != ExtentType.Allocated
					|| extent.ExtentLocation.LogicalBlockNumber != icb.TagLocation) { throw new ArgumentException("The given ICB's tag location did not match the logical block number of the extent."); }
				var prevICB = this.icbCache[extent];
				if (prevICB != null && icb != prevICB) { throw new InvalidOperationException("How did you get another reference to the ICB?! You can only change what you get here!"); }

				var bytes = Marshaler.StructureToPtr(icb);
				extent = new LongAllocationDescriptor(new ShortAllocationDescriptor(extent.ShortAllocationDescriptor.LogicalBlockNumber, bytes.Length, ExtentType.Recorded), extent.ExtentLocation.PartitionReferenceNumber, extent.Flags, extent.ImplementationUse);
				this.Volume.Write(extent, AllocationDescriptorType.LongAllocationDescriptors, 0, bytes, 0, bytes.Length);

				this.icbCache[extent] = icb;
				return prevICB; //Which is equal to the actual ICB
			}
		}
	}
}