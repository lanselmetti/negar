using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Helper;
using Helper.IO;

namespace FileSystems.Udf
{
	/// <summary>A sector address space as specified in the relevant standard for recording.</summary>
	/// <remarks>
	/// <para>A medium usually has a single set of sector addresses, and is therefore a single volume. A medium may have a separate set of addresses for each side of the medium, and is therefore two volumes.</para>
	/// <para>Note that this is different from a logical volume, which consists of a set of partitions on a set of physical volumes.</para>
	/// </remarks>
	public partial class UdfVolume : IDisposable
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool leaveOpen;
		private AnchorVolumeDescriptorPointer anchorVolumeDescriptorPointer;
		private IDictionary<string, ShareAccess> openVolumes = new Dictionary<string, ShareAccess>();
		private int _LogicalSectorSize = 2048; //Logical size = physical size = usually (or always?) 2048 bytes, based on ECMA 167

		/// <param name="mode">The creation disposition for the new file system. All the meanings ordinarily given to file creation apply to file system creation, except that <see cref="FileMode.Append"/> means that this file system is created in addition to other (compatible) file systems on the disc.</param>
		public UdfVolume(Stream volumeStream, bool leaveOpen, FileMode mode)
		{
			this.leaveOpen = leaveOpen;
			this.BaseStream = volumeStream;

			//Read volume recognition sequence
			this.VolumeRecognitionSequence = new VolumeRecognitionSequenceCollection(this, mode);

			switch (mode)
			{
				case FileMode.Append:
					throw new NotImplementedException("Adding the file system not implemented.");
				case FileMode.Truncate:
					throw new NotImplementedException("Overwriting a preexisting file system not implemented.");
				case FileMode.Create:
					throw new NotImplementedException("Creating (and overwriting) the file system not implemented.");
				case FileMode.CreateNew:
					throw new NotImplementedException("Creating a new file system not implemented.");
				case FileMode.Open:
					//Read anchor volume descriptor
					{
						var buffer = new byte[Marshaler.DefaultSizeOf<AnchorVolumeDescriptorPointer>()];
						long newPosition = this.LogicalSectorSize * 256;
						if (this.BaseStream.Position != newPosition) { this.BaseStream.Position = newPosition; }
						this.BaseStream.ReadExactly(buffer, 0, buffer.Length);
						var anchor = (AnchorVolumeDescriptorPointer)this.ConvertTaggedDescriptorToManaged(buffer, 0, true);
						if (anchor.TagLocation != 256) { throw new InvalidDataException("Anchor volume descriptor pointer invalid."); }
						this.anchorVolumeDescriptorPointer = anchor;
					}
					break;
				case FileMode.OpenOrCreate:
					throw new NotImplementedException("Creating or opening a file system not implemented.");
				default:
					throw new ArgumentOutOfRangeException("mode", mode, "Invalid file mode.");
			}

			this.VolumeDescriptorSequence = new VolumeDescriptorSequenceCollection(this, mode);
		}

		~UdfVolume() { this.Dispose(false); }

		protected internal Stream BaseStream { get; private set; }

		private UdfVolumeStructureDescriptor ConvertVolumeDescriptorToManaged(byte[] buffer, int bufferOffset)
		{
			UdfVolumeStructureDescriptor result;
			string standard = UdfVolumeStructureDescriptor.ReadStandardIdentifier(buffer, bufferOffset);
			byte version = UdfVolumeStructureDescriptor.ReadVersion(buffer, bufferOffset);
			switch (standard)
			{
				case "BEA01":
					result = Marshaler.PtrToStructure<BeginningExtendedAreaDescriptor>(buffer, bufferOffset);
					break;
				case "TEA01":
					result = Marshaler.PtrToStructure<TerminatingExtendedAreaDescriptor>(buffer, bufferOffset);
					break;
				case "BOOT2":
					result = Marshaler.PtrToStructure<BootDescriptor>(buffer, bufferOffset);
					break;
				case "NSR02":
					result = Marshaler.PtrToStructure<NonSequentialRecording2Descriptor>(buffer, bufferOffset);
					break;
				case "NSR03":
					result = Marshaler.PtrToStructure<NonSequentialRecording3Descriptor>(buffer, bufferOffset);
					break;
				default:
					var d = new UnknownVolumeStructureDescriptor(standard, version);
					Marshaler.PtrToStructure<UnknownVolumeStructureDescriptor>(buffer, bufferOffset, ref d);
					result = d;
					break;
			}
			return result;
		}

		/// <summary><para>Converts a tagged descriptor from unmanaged to binary form.</para><para>IMPORTANT: Don't forget to check the tag location to make sure it is valid!</para></summary>
		public TaggedDescriptor ConvertTaggedDescriptorToManaged(byte[] buffer, int bufferOffset, bool throwOnError)
		{
			TaggedDescriptor result;
			var id = TaggedDescriptor.ReadTagId(buffer, bufferOffset);
			switch (id)
			{
				case DescriptorTagIdentifier.PrimaryVolumeDescriptor:
					result = Marshaler.PtrToStructure<PrimaryVolumeDescriptor>(buffer, bufferOffset);
					break;
				case DescriptorTagIdentifier.AnchorVolumeDescriptorPointer:
					result = Marshaler.PtrToStructure<AnchorVolumeDescriptorPointer>(buffer, bufferOffset);
					break;
				case DescriptorTagIdentifier.VolumeDescriptorPointer:
					result = Marshaler.PtrToStructure<VolumeDescriptorPointer>(buffer, bufferOffset);
					break;
				case DescriptorTagIdentifier.ImplementationUseVolumeDescriptor:
					result = Marshaler.PtrToStructure<ImplementationUseVolumeDescriptor>(buffer, bufferOffset);
					break;
				case DescriptorTagIdentifier.PartitionDescriptor:
					result = Marshaler.PtrToStructure<PartitionDescriptor>(buffer, bufferOffset);
					break;
				case DescriptorTagIdentifier.LogicalVolumeDescriptor:
					result = Marshaler.PtrToStructure<LogicalVolumeDescriptor>(buffer, bufferOffset);
					break;
				case DescriptorTagIdentifier.UnallocatedSpaceDescriptor:
					result = Marshaler.PtrToStructure<UnallocatedSpaceDescriptor>(buffer, bufferOffset);
					break;
				case DescriptorTagIdentifier.TerminatingDescriptor:
					result = Marshaler.PtrToStructure<TerminatingDescriptor>(buffer, bufferOffset);
					break;
				case DescriptorTagIdentifier.LogicalVolumeIntegrityDescriptor:
					result = Marshaler.PtrToStructure<LogicalVolumeIntegrityDescriptor>(buffer, bufferOffset);
					break;
				case DescriptorTagIdentifier.FileSetDescriptor:
					result = Marshaler.PtrToStructure<FileSetDescriptor>(buffer, bufferOffset);
					break;
				case DescriptorTagIdentifier.IndirectEntry:
					result = Marshaler.PtrToStructure<IndirectInformationControlBlockDescriptor>(buffer, bufferOffset);
					break;
				case DescriptorTagIdentifier.TerminalEntry:
					result = Marshaler.PtrToStructure<TerminalInformationControlBlockDescriptor>(buffer, bufferOffset);
					break;
				case DescriptorTagIdentifier.FileEntry:
					result = Marshaler.PtrToStructure<FileEntryInformationControlBlockDescriptor>(buffer, bufferOffset);
					break;
				case DescriptorTagIdentifier.ExtendedFileEntry:
					result = Marshaler.PtrToStructure<ExtendedFileEntryInformationControlBlockDescriptor>(buffer, bufferOffset);
					break;
				case DescriptorTagIdentifier.FileIdentifierDescriptor:
					result = Marshaler.PtrToStructure<FileIdentifierDescriptor>(buffer, bufferOffset);
					break;
				case DescriptorTagIdentifier.AllocationExtentDescriptor:
					result = Marshaler.PtrToStructure<AllocationExtentDescriptor>(buffer, bufferOffset);
					break;
				default:
					result = null;
					break;
			}
			if (result == null && throwOnError) { throw new NotSupportedException(string.Format("{0} not supported.", id)); }
			return result;
		}

		public void Dispose() { this.Dispose(true); GC.SuppressFinalize(this); }

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				try
				{
					if (!this.leaveOpen) { this.BaseStream.Close(); }
					//TODO: Dispose objects not disposed elsewhere
					this.Flush();
				}
				finally { this.BaseStream = null; }
			}
		}

		public virtual void Flush()
		{
			//((VolumeRecognitionSequenceCollection)this.VolumeRecognitionSequence).Update();
			((VolumeDescriptorSequenceCollection)this.VolumeDescriptorSequence).Update();
		}

		public string[] GetLogicalVolumeIdentifiers()
		{
			string[] result;
			{
				int count = 0;
				for (int i = 0; i < this.VolumeDescriptorSequence.Count; i++) { if (this.VolumeDescriptorSequence[i] is LogicalVolumeDescriptor) { count++; } }
				result = new string[count];
			}
			int index = 0;
			for (int i = 0; i < this.VolumeDescriptorSequence.Count; i++)
			{
				var casted = this.VolumeDescriptorSequence[i] as LogicalVolumeDescriptor;
				if (casted != null) { result[index++] = casted.LogicalVolumeIdentifier; }
			}
			return result;
		}

		public int LogicalSectorSize { get { return this._LogicalSectorSize; } set { if (value < 512 | value % 512 != 0) { throw new ArgumentOutOfRangeException("value", value, "The logical sector size must be positive and a multiple of 512 bytes."); } this._LogicalSectorSize = value; } }

		private UdfPartition OpenPartition(ushort partitionNumber)
		{
			PartitionDescriptor descriptor = null;
			for (int i = 0; i < this.VolumeDescriptorSequence.Count; i++)
			{
				var asPartitionDescriptor = this.VolumeDescriptorSequence[i] as PartitionDescriptor;
				if (asPartitionDescriptor != null && asPartitionDescriptor.PartitionNumber == partitionNumber)
				{
					descriptor = asPartitionDescriptor;
					break;
				}
			}
			if (descriptor == null) { throw new ArgumentException("Volume not found.", "logicalVolumeIdentifier"); }
			
			var stream = new SubStream(this.BaseStream, descriptor.PartitionStartSector * this.LogicalSectorSize, descriptor.PartitionSectorCount * this.LogicalSectorSize, descriptor.PartitionSectorCount * this.LogicalSectorSize, true);
			//Don't worry about access - the volume manages that
			/*
			FileAccess access;
			bool canSeek;
			switch (descriptor.AccessType)
			{
				case PartitionAccessType.ReadOnly:
					canSeek = true;
					access = FileAccess.Read;
					break;
				case PartitionAccessType.WriteOnce:
				case PartitionAccessType.Rewritable:
					canSeek = true;
					access = FileAccess.ReadWrite;
					break;
				case PartitionAccessType.Overwritable:
					canSeek = true;
					access = FileAccess.ReadWrite;
					break;
				default:
					canSeek = false;
					access = 0;
					break;
			}
			stream = new RestrictedAccessStream(stream, access, stream.CanSeek & canSeek, false);
			//*/
			var partition = new UdfPartition(this, descriptor, stream);
			//try { this.openPartitions.Open(partition.PartitionNumber, partition, access, false, share, true); }
			//catch (UnauthorizedAccessException) { partition.Dispose(); throw; }
			return partition;
		}

		public UdfLogicalVolume OpenLogicalVolume(string logicalVolumeIdentifier, FileAccess access, FileShare share) { LogicalVolumeDescriptor vd; return this.OpenLogicalVolume(logicalVolumeIdentifier, access, share, out vd); }

		private UdfLogicalVolume OpenLogicalVolume(string logicalVolumeIdentifier, FileAccess access, FileShare share, out LogicalVolumeDescriptor descriptor)
		{
			descriptor = null;
			for (int i = 0; i < this.VolumeDescriptorSequence.Count; i++)
			{
				var asVolumeDescriptor = this.VolumeDescriptorSequence[i] as LogicalVolumeDescriptor;
				if (asVolumeDescriptor != null && asVolumeDescriptor.LogicalVolumeIdentifier == logicalVolumeIdentifier)
				{
					descriptor = asVolumeDescriptor;
					break;
				}
			}
			if (descriptor == null) { throw new ArgumentException("Volume not found.", "logicalVolumeIdentifier"); }

			var partitions = new List<UdfPartition>();
			try
			{
				for (int i = 0; i < descriptor.PartitionMaps.Length; i++)
				{
					var map = descriptor.PartitionMaps[i];
					UdfPartition partition;
					var type1Map = map as Type1PartitionMap;
					var type2Map = map as UdfType2PartitionMap;
					if (type1Map != null) { partition = this.OpenPartition(type1Map.PartitionNumber); }
					else if (type2Map != null) { partition = this.OpenPartition(type2Map.PartitionNumber); }
					else { throw new NotSupportedException("Partition map type not supported."); }
					partitions.Add(partition);
				}
			}
			catch //If any exceptions occur (esp. sharing violations), close what we opened first, before throwing them
			{ foreach (var partition in partitions) { if (partition != null) { partition.Dispose(); } } throw; }

			var volume = new UdfLogicalVolume(this, descriptor, partitions.ToArray(), false);

			//try { openVolumes.Open(descriptor.LogicalVolumeIdentifier, volume, access, false, share, true); }
			//catch (UnauthorizedAccessException) { volume.Dispose(); throw; }

			return volume;
		}

		internal IList<TaggedDescriptor> VolumeDescriptorSequence { get; private set; }

		protected IList<UdfVolumeStructureDescriptor> VolumeRecognitionSequence { get; private set; }

		private void UpdateVolumeDescriptorSequence() { ((VolumeDescriptorSequenceCollection)this.VolumeDescriptorSequence).Update(); }


		// Static fields
		/// <summary>The minimum number of logical sectors in any volume.</summary>
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static int MinimumLogicalVolumeSizeInSectors { get { return 256; } }

		

		public static void Test(Stream stream)
		{
			using (var fs = new UdfVolume(stream, true, FileMode.Open))
			{
				var volumeIDs = fs.GetLogicalVolumeIdentifiers();
				using (var volume = fs.OpenLogicalVolume(volumeIDs[0], FileAccess.Read, FileShare.Read))
				{
					var root = (FileEntryInformationControlBlockDescriptor)volume.FileSet.RootInformationControlBlock;
					var rootAllocationDescriptor = Marshaler.PtrToStructure<LongAllocationDescriptor>(root.AllocationDescriptors, 0);
					byte[] bytes = new byte[rootAllocationDescriptor.ShortAllocationDescriptor.ByteLength];

					int read = volume.Read(rootAllocationDescriptor, AllocationDescriptorType.LongAllocationDescriptors, 0, bytes, 0, bytes.Length);
					Trace.Assert(read == bytes.Length);

					int i = 0;
					int offset = 0;
					FileIdentifierDescriptor fid;
					while (offset < bytes.Length)
					{
						fid = Marshaler.PtrToStructure<FileIdentifierDescriptor>(bytes, offset);
						byte[] bytes2 = new byte[fid.InformationControlBlock.ShortAllocationDescriptor.ByteLength];

						read = volume.Read(fid.InformationControlBlock, AllocationDescriptorType.LongAllocationDescriptors, 0, bytes2, 0, bytes2.Length);
						Trace.Assert(read == bytes2.Length);

						var feicb = (FileEntryInformationControlBlockDescriptor)fs.ConvertTaggedDescriptorToManaged(bytes2, 0, true);
						Console.WriteLine("{0:N0}. {1}", i++, fid.FileIdentifier);
						offset += Marshaler.SizeOf(fid);
					}
				}
			}
		}
	}

	public struct ShareAccess
	{
		public int OpenCount;
		public int Readers;
		public int Writers;
		public int Deleters;
		public int SharedRead;
		public int SharedWrite;
		public int SharedDelete;
	}
}