using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Helper;
using Helper.IO;

namespace FileSystems.Udf
{
	public class UdfMaster : DiscMaster
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly int NUM_ANCHORS_AT_END = 2;
		private List<KeyValuePair<FileIdentifierDescriptor, FileEntryInformationControlBlockDescriptorBase>> fidBuffer = new List<KeyValuePair<FileIdentifierDescriptor, FileEntryInformationControlBlockDescriptorBase>>();

		public UdfMaster(int sectorSize)
			: base(sectorSize)
		{
			this.LogicalVolumeIdentifier = "New";
			this.VolumeIdentifier = "Volume";
			this.OwnerName = string.Empty;
			this.Organization = string.Empty;
			this.ContactInfo = string.Empty;
			this.FileSetIdentifier = "FileSet";
			this.DeveloperId = "MehrdadN";
			this.ApplicationId = new EntityIdentifier(EntityIdentifierFlags.None, "*[Application ID]", new ApplicationIdentifierSuffix(0));
		}

		public bool AlignFileIdentifiers { get; set; }
		public bool AllowIcbDataEmbedding { get; set; }
		public string DeveloperId { get; set; }
		public EntityIdentifier ApplicationId { get; set; }
		public bool EncodeDuplicatesOnce { get; set; }
		public string LogicalVolumeIdentifier { get; set; }
		public string VolumeIdentifier { get; set; }
		public string OwnerName { get; set; }
		public string Organization { get; set; }
		public string ContactInfo { get; set; }
		public string FileSetIdentifier { get; set; }
		/// <summary>The sector on the disc to which sector zero of the track actually corresponds.</summary>
		public uint TrackStartSector { get; set; }

		public Dictionary<IStreamSource, List<IStreamSource>> DuplicateFilesFound { get; private set; }

		private bool AllocateFiles(PartitionDescriptor pd, int logicalBlockSize, IList<FileDescriptorsWithInfo> filesToBurn, List<KeyValuePair<Range<long>, IStreamSource>> partitionAllocation, ref long nextFreeByte, ref long currentProgress, long progressTotal)
		{
			/*Go through all files that have some data (zero-length files are excluded)*/
			foreach (var pair in filesToBurn)
			{
				long dataStart = nextFreeByte;

				if (this.AllowIcbDataEmbedding && Marshaler.SizeOf(pair.FileEntry) - pair.FileEntry.AllocationDescriptors.Length + ((IFileInfo)pair.File).Length <= logicalBlockSize)
				{
					using (var stream = ((IFileInfo)pair.File).Open(FileMode.Open, FileAccess.Read, FileShare.Read, FileOptions.SequentialScan, false))
					{
						pair.FileEntry.AllocationDescriptors = new byte[stream.Length];
						long newPosition = 0;
						if (newPosition != stream.Position) { stream.Position = newPosition; }
						stream.ReadFully(pair.FileEntry.AllocationDescriptors, 0, (int)stream.Length);
					}
					pair.FileEntry.Flags &= ~IcbFlags.AllocationDescriptorTypeMask;
					pair.FileEntry.Flags |= (IcbFlags)AllocationDescriptorType.DataResidentInAllocationDescriptors;

				}
				else
				{
					var allocDescs = new List<LongAllocationDescriptor>(1);
					long lengthLeft = ((IFileInfo)pair.File).Length;
					while (lengthLeft > 0)
					{
						uint len = (uint)Math.Min(uint.MaxValue >> 2 /*Upper two bits are reserved!*/, ((IFileInfo)pair.File).Length);
						var allocDesc = new LongAllocationDescriptor(new ShortAllocationDescriptor((uint)(nextFreeByte / logicalBlockSize), len, ExtentType.Recorded), pd.PartitionNumber, ExtentFlags.None, 0);
						allocDescs.Add(allocDesc);
						nextFreeByte += len;
						lengthLeft -= len;
					}
					nextFreeByte = logicalBlockSize * (1 + (nextFreeByte - 1) / logicalBlockSize);
					if (allocDescs.Count > 0)
					{
						partitionAllocation.Add(new KeyValuePair<Range<long>, IStreamSource>(new Range<long>(dataStart, nextFreeByte), (IFileInfo)pair.File));

						pair.FileEntry.AllocationDescriptors = new byte[Marshaler.SizeOf(allocDescs[0]) * allocDescs.Count];
						int offset = 0;
						foreach (var desc in allocDescs)
						{
							Marshaler.StructureToPtr(desc, pair.FileEntry.AllocationDescriptors, offset);
							pair.FileEntry.LogicalBlocksRecorded += 1 + (desc.ShortAllocationDescriptor.ByteLength - 1) / logicalBlockSize;
							pair.FileEntry.InformationLength += desc.ShortAllocationDescriptor.ByteLength;
							offset += Marshaler.SizeOf(desc);
						}
					}
				}

				/************ NOTE: This loop DOESN'T account for all files (exceptions include hardlinks, etc.)*/
				/*However, we account for those exceptions when we look at them*/

				/*We just processed file data*/
				if (!this.ReportProgress(MasterStage.Processing, "Processing file data", currentProgress++, progressTotal, "files", pair.File))
				{ return false; }
			}
			return true;
		}

		private static void BuildVolumeMap(int sectorSize, long vrsStartSector, AnchorVolumeDescriptorPointer anchor, PartitionDescriptor pd, int logicalBlockSize, LogicalVolumeIntegrityDescriptor integrityDescriptor, TaggedDescriptor[] descriptors, List<KeyValuePair<Range<long>, IStreamSource>> volumeAllocation, List<KeyValuePair<Range<long>, IStreamSource>> partitionAllocation)
		{
			var volumeRecognitionSequence = new UdfVolumeStructureDescriptor[] { new BeginningExtendedAreaDescriptor() { }, new NonSequentialRecording2Descriptor() { }, new TerminatingExtendedAreaDescriptor() { } };
			{
				var start = vrsStartSector * sectorSize;
				for (int i = 0; i < volumeRecognitionSequence.Length; i++)
				{
					var descriptor = volumeRecognitionSequence[i];
					var src = new MarshalableStreamSource<VolumeStructureDescriptor>(descriptor, string.Format("Volume Recognition Sequence: {0}", descriptor.StandardIdentifier));
					volumeAllocation.Add(new KeyValuePair<Range<long>, IStreamSource>(new Range<long>(start + i * sectorSize, start + i * sectorSize + logicalBlockSize), src));
				}
			}
			{
				var start = anchor.MainVolumeDescriptorSequenceExtent.LogicalSectorNumber * sectorSize;
				for (int i = 0; i < descriptors.Length; i++)
				{
					var descriptor = descriptors[i];
					descriptor.TagLocation = (uint)((start + i * sectorSize) / sectorSize);
					var src = new MarshalableStreamSource<TaggedDescriptor>(descriptor, string.Format("Main Volume Descriptor Sequence: {0}", descriptor.TagIdentifier));
					volumeAllocation.Add(new KeyValuePair<Range<long>, IStreamSource>(new Range<long>(descriptor.TagLocation * sectorSize, descriptor.TagLocation * sectorSize + logicalBlockSize), src));
				}
				var mainLength = descriptors.Length * sectorSize;
				if (mainLength < anchor.MainVolumeDescriptorSequenceExtent.ByteLength)
				{
					var zero = new MemoryStream(anchor.MainVolumeDescriptorSequenceExtent.ByteLength - mainLength);
					zero.SetLength(zero.Capacity);
					volumeAllocation.Add(new KeyValuePair<Range<long>, IStreamSource>(new Range<long>(start + mainLength, start + anchor.MainVolumeDescriptorSequenceExtent.ByteLength), new StreamSource(zero)));
				}
			}
			{
				var src = new MarshalableStreamSource<TaggedDescriptor>(integrityDescriptor, "Logical Volume Integrity Descriptor");
				var start = integrityDescriptor.TagLocation * logicalBlockSize;
				volumeAllocation.Add(new KeyValuePair<Range<long>, IStreamSource>(new Range<long>(start, start + logicalBlockSize), src));
			}
			{
				var clone = (TaggedDescriptor)anchor.Clone();
				var src = new MarshalableStreamSource<TaggedDescriptor>(clone, "Anchor Volume Descriptor Pointer");
				var start = clone.TagLocation * sectorSize;
				volumeAllocation.Add(new KeyValuePair<Range<long>, IStreamSource>(new Range<long>(start, start + logicalBlockSize), src));
			}
			{
				long partitionStartByte = pd.PartitionStartSector * sectorSize;
				foreach (var item in partitionAllocation)
				{ volumeAllocation.Add(new KeyValuePair<Range<long>, IStreamSource>(new Range<long>(partitionStartByte + item.Key.Start, partitionStartByte + item.Key.End), item.Value)); }
			}
			{
				var start = anchor.ReserveVolumeDescriptorSequenceExtent.LogicalSectorNumber * sectorSize;
				for (int i = 0; i < descriptors.Length; i++)
				{
					var cloned = (TaggedDescriptor)descriptors[i].Clone();
					cloned.TagLocation = (uint)((start + i * sectorSize) / sectorSize);
					var src = new MarshalableStreamSource<TaggedDescriptor>(cloned, string.Format("Reserve Volume Descriptor Sequence: {0}", cloned.TagIdentifier));
					volumeAllocation.Add(new KeyValuePair<Range<long>, IStreamSource>(new Range<long>(cloned.TagLocation * sectorSize, cloned.TagLocation * sectorSize + logicalBlockSize), src));
				}
				var reserveLength = descriptors.Length * sectorSize;
				if (reserveLength < anchor.ReserveVolumeDescriptorSequenceExtent.ByteLength)
				{
					var zero = new MemoryStream(anchor.ReserveVolumeDescriptorSequenceExtent.ByteLength - reserveLength);
					zero.SetLength(zero.Capacity);
					volumeAllocation.Add(new KeyValuePair<Range<long>, IStreamSource>(new Range<long>(start + reserveLength, start + anchor.ReserveVolumeDescriptorSequenceExtent.ByteLength), new StreamSource(zero)));
				}
			}
			uint nextFreeSector = (uint)(1 + (volumeAllocation[volumeAllocation.Count - 1].Key.End - 1) / sectorSize);
			{
				for (uint i = 0; i < NUM_ANCHORS_AT_END; i++)
				{
					var clone = (TaggedDescriptor)anchor.Clone();
					var src = new MarshalableStreamSource<TaggedDescriptor>(clone, "Anchor Volume Descriptor Pointer");
					clone.TagLocation = nextFreeSector + 256 * i;
					var start = clone.TagLocation * sectorSize;
					volumeAllocation.Add(new KeyValuePair<Range<long>, IStreamSource>(new Range<long>(start, start + logicalBlockSize), src));
				}
			}
		}

		private static void Count(IDirectoryInfo dir, out long fileCount, out long directoryCount)
		{
			var stack = new Stack<IDirectoryInfo>(64);
			stack.Push(dir);

			fileCount = 0;
			directoryCount = 0;
			while (stack.Count > 0)
			{
				var next = stack.Pop();
				directoryCount++;

				foreach (var fso in next.GetFileSystemInfos(null, SearchOption.TopDirectoryOnly))
				{
					var asDir = fso as IDirectoryInfo;
					if (asDir != null)
					{
						stack.Push(asDir);
					}
					else
					{
						fileCount++;
					}
				}
			}
		}

		private static void CheckAndAlignFileIdentifiers(LogicalVolumeDescriptor lvd, List<KeyValuePair<Range<long>, IStreamSource>> partitionAllocation, ref long nextFreeByte, FileIdentifierDescriptor fid, int idSize)
		{
			if (nextFreeByte + idSize > (fid.TagLocation + 1) * lvd.LogicalBlockSize) /*If FID crosses block boundary*/
			{
				/*nextFreeByte still points to before the current FID...*/
				KeyValuePair<Range<long>, IStreamSource> prevItem = partitionAllocation[partitionAllocation.Count - 1];
				partitionAllocation.RemoveAt(partitionAllocation.Count - 1);
				nextFreeByte = lvd.LogicalBlockSize * (1 + (nextFreeByte - 1) / lvd.LogicalBlockSize); /*Align to next block*/
				/*nextFreeByte is now aligned to the next valid block...*/
				var prevFID = (FileIdentifierDescriptor)prevItem.Value.Source;

				if (nextFreeByte - prevItem.Key.End < Marshaler.DefaultSizeOf<EntityIdentifier>())
				{
					/*Darn... we moved this FID to the next block, but the last one doesn't have at*/
					/*least sizeof(EntityIdentifier) bytes to expand either, so we have to move that too*/

					KeyValuePair<Range<long>, IStreamSource> prevPrevItem = partitionAllocation[partitionAllocation.Count - 1];
					partitionAllocation.RemoveAt(partitionAllocation.Count - 1);
					var prevPrevFID = (FileIdentifierDescriptor)prevPrevItem.Value.Source;
					prevPrevFID.ImplementationIdentifier = lvd.ImplementationIdentifier;
					prevPrevFID.ImplementationUseAfterEntryId = new byte[nextFreeByte - (prevPrevItem.Key.Start + Marshaler.SizeOf(prevPrevFID))];
					prevPrevItem = new KeyValuePair<Range<long>, IStreamSource>(new Range<long>(prevPrevItem.Key.Start, prevPrevItem.Key.Start + Marshaler.SizeOf(prevPrevFID)), prevPrevItem.Value);
					Debug.Assert(prevPrevItem.Key.End % lvd.LogicalBlockSize == 0);
					partitionAllocation.Add(prevPrevItem);
					prevItem = new KeyValuePair<Range<long>, IStreamSource>(new Range<long>(nextFreeByte, prevItem.Key.End - prevItem.Key.Start), prevItem.Value);
					prevFID.TagLocation = (uint)(prevItem.Key.Start / lvd.LogicalBlockSize);
					nextFreeByte += prevPrevItem.Key.End - prevPrevItem.Key.Start;
				}

				prevFID.ImplementationIdentifier = lvd.ImplementationIdentifier;
				prevFID.ImplementationUseAfterEntryId = new byte[nextFreeByte - prevItem.Key.Start - Marshaler.SizeOf(prevFID)];
				prevItem = new KeyValuePair<Range<long>, IStreamSource>(new Range<long>(prevItem.Key.Start, nextFreeByte), prevItem.Value);
				partitionAllocation.Add(prevItem);

				fid.TagLocation = (uint)(nextFreeByte / lvd.LogicalBlockSize);
			}
		}

		private void CreateVolumeDescriptorSequence(UdfRevision udfVersion, AnchorVolumeDescriptorPointer anchor, out PartitionDescriptor pd, out LogicalVolumeDescriptor lvd, out LogicalVolumeIntegrityDescriptor integrityDescriptor, out TaggedDescriptor[] descriptors)
		{
			pd = new PartitionDescriptor()
			{
				DescriptorVersion = 2,
				PartitionContents = new EntityIdentifier(EntityIdentifierFlags.None, "+NSR02", new ApplicationIdentifierSuffix(0)),
				VolumeDescriptorSequenceNumber = 2,
				AccessType = PartitionAccessType.ReadOnly,
				Flags = PartitionFlags.VolumeSpaceAllocated,
				PartitionStartSector = anchor.TagLocation + 1, /*Start right after the AVDP*/
				ImplementationIdentifier = new EntityIdentifier(EntityIdentifierFlags.None, this.DeveloperId, new ImplementationIdentifierSuffix(OperatingSystemClass.WindowsNT, 0)),
			};
			lvd = new LogicalVolumeDescriptor()
			{
				DescriptorVersion = 2,
				VolumeDescriptorSequenceNumber = 3,
				LogicalBlockSize = this.SectorSize,
				LogicalVolumeIdentifier = this.LogicalVolumeIdentifier, /*128 chars max*/
				ImplementationIdentifier = new EntityIdentifier(EntityIdentifierFlags.None, this.DeveloperId, new ImplementationIdentifierSuffix(OperatingSystemClass.WindowsNT, 0)),
				PartitionMaps = new PartitionMap[] { new Type1PartitionMap() { PartitionNumber = pd.PartitionNumber, VolumeSequenceNumber = 1 } },
			};
			lvd.DomainIdentifier = new EntityIdentifier(lvd.DomainIdentifier.Flags, lvd.DomainIdentifier.IdentifierToString(), new DomainIdentifierSuffix(udfVersion, DomainFlags.HardWriteProtect | DomainFlags.SoftWriteProtect));
			integrityDescriptor = new LogicalVolumeIntegrityDescriptor()
			{
				DescriptorVersion = 2,
				IntegrityType = LogicalVolumeIntegrityType.Closed,
				FileCount = 0,
				DirectoryCount = 0,
				ImplementationIdentifier = new EntityIdentifier(EntityIdentifierFlags.None, this.DeveloperId, new ImplementationIdentifierSuffix(OperatingSystemClass.WindowsNT, 0)),
				MinimumUdfReadRevision = udfVersion,
				MinimumUdfWriteRevision = udfVersion,
				MaximumUdfWriteRevision = new UdfRevision(0x1, 0x50),
			};
			integrityDescriptor.TagLocation = this.TrackStartSector + 0x40;
			lvd.IntegritySequenceExtent = new ExtentAllocationDescriptor((uint)(integrityDescriptor.TagLocation * lvd.LogicalBlockSize / this.SectorSize), lvd.LogicalBlockSize);
			descriptors = new TaggedDescriptor[] /*TagLocations are set later*/
			{
				new PrimaryVolumeDescriptor()
				{
					DescriptorVersion = 2,
					RecordingTime = integrityDescriptor.RecordingTime,
					VolumeDescriptorSequenceNumber = 1,
					VolumeIdentifier = this.VolumeIdentifier, /*32 chars max*/
					ImplementationIdentifier = new EntityIdentifier(EntityIdentifierFlags.None, this.DeveloperId, new ImplementationIdentifierSuffix(OperatingSystemClass.WindowsNT, 0)),
					ApplicationIdentifier = this.ApplicationId,
					VolumeSequenceNumber = 1,
				},
				pd,
				lvd,
				new ImplementationUseVolumeDescriptor()
				{
					DescriptorVersion = 2,
					ImplementationIdentifier = new EntityIdentifier(EntityIdentifierFlags.None, EntityIdentifier.ImplementationUseVolumeDescriptorImplementationId, new UdfIdentifierSuffix(udfVersion, OperatingSystemClass.WindowsNT, 0)),
					ImplementationIdentifier2 = new EntityIdentifier(EntityIdentifierFlags.None, this.DeveloperId, new ImplementationIdentifierSuffix(OperatingSystemClass.WindowsNT, 0)),
					LogicalVolumeIdentifier = lvd.LogicalVolumeIdentifier,
					LogicalVolumeInformation1 = this.OwnerName,
					LogicalVolumeInformation2 = this.Organization,
					LogicalVolumeInformation3 = this.ContactInfo,
					VolumeDescriptorSequenceNumber = 4,
				},
				new UnallocatedSpaceDescriptor()
				{
					DescriptorVersion = 2,
					VolumeDescriptorSequenceNumber = 5,
				},
				new TerminatingDescriptor()
				{
					DescriptorVersion = 2,
				},
			};
		}

		public override long GetLength(out long fileCount, out long directoryCount, out long metadataSize) { metadataSize = fileCount = directoryCount = 0; return GetSize(this.Root, ref fileCount, ref directoryCount, ref metadataSize, this.SectorSize); }

		private static long GetSize(IDirectoryInfo directoryTreeNode, ref long fileCount, ref long directoryCount, ref long sizeForMetadata, int blockSize)
		{
			var files = directoryTreeNode.GetFiles(null, SearchOption.TopDirectoryOnly);
			var dirs = directoryTreeNode.GetDirectories(null, SearchOption.TopDirectoryOnly);
			fileCount += files.Length;
			directoryCount += dirs.Length;

			long filesDataSize = 0;
			int prevFidSize = FileIdentifierDescriptor.CalculateSize("..");
			long fidsSize = prevFidSize; /*For ".." file*/
			for (int i = 0; i < files.Length; i++)
			{
				var file = files[i];
				int fidSize = FileIdentifierDescriptor.CalculateSize(file.Name);
				if (fidsSize / blockSize != (fidsSize + fidSize) / blockSize)
				{
					fidsSize -= prevFidSize;
					fidsSize = (1 + (fidsSize - 1) / blockSize) * blockSize;
					fidsSize += prevFidSize;
				}
				fidsSize += fidSize;

				filesDataSize += (1 + (file.Length - 1) / blockSize) * blockSize;
				prevFidSize = fidSize;
			}
			fidsSize = (1 + (fidsSize - 1) / blockSize) * blockSize;

			long icbsSize = (files.Length + 1) * blockSize;

			long size = icbsSize + fidsSize; /*DON'T swap this statement with the next!*/
			sizeForMetadata += size;
			size += filesDataSize;

			for (int i = 0; i < dirs.Length; i++) { size += GetSize(dirs[i], ref fileCount, ref directoryCount, ref sizeForMetadata, blockSize); }
			return size;
		}

		public override AllocatedStream Prepare()
		{
			var udfVersion = new UdfRevision(0x01, 0x02);
			this.DuplicateFilesFound = new Dictionary<IStreamSource, List<IStreamSource>>(new StreamEqualityComparer());

			/*Count all the files to be able to report deterministic progress*/
			if (!this.ReportProgress(MasterStage.Preparing, "Counting files and directories", 0, 1, "files", null)) { return null; }
			long fileCount, directoryCount;
			Count(this.Root, out fileCount, out directoryCount);
			if (!this.ReportProgress(MasterStage.Preparing, "Counted files and directories", fileCount + directoryCount, fileCount + directoryCount, "files", null)) { return null; }

			/*Find out where the Volume Recognition Sequence should start, according to standard*/
			long vrsStartSector = (this.TrackStartSector + (0x7FFFL / this.SectorSize) + 1); /*First byte of the first sector after byte 0x7FFF; almost always equal to 0x8000*/

			/*TODO: Don't hard-code MainVolumeDescriptorSequenceExtent and other locations*/
			var anchor = new AnchorVolumeDescriptorPointer()
			{
				DescriptorVersion = 2,
				TagLocation = this.TrackStartSector + 256,
				MainVolumeDescriptorSequenceExtent = new ExtentAllocationDescriptor(this.TrackStartSector + 0x20, 0x8000),
				/*Set the reserve later*/
			};

			PartitionDescriptor pd;
			LogicalVolumeDescriptor lvd;
			LogicalVolumeIntegrityDescriptor integrityDescriptor;
			TaggedDescriptor[] descriptors;
			this.CreateVolumeDescriptorSequence(udfVersion, anchor, out pd, out lvd, out integrityDescriptor, out descriptors);

			List<KeyValuePair<Range<long>, IStreamSource>> volumeAllocation;

			/*This cache is used to detect hardlinks to files*/
			var hardlinkCache = new Dictionary<IFileInfo, FileEntryInformationControlBlockDescriptorBase>(new FileInfoComparer());
			var sameFileCache = this.EncodeDuplicatesOnce ? new UniqueStreamCollection<FileEntryInformationControlBlockDescriptorBase>() : null;
			/*We want to burn files after we burn all the other data*/
			var filesToBurn = new List<FileDescriptorsWithInfo>();
			List<KeyValuePair<Range<long>, IStreamSource>> partitionAllocation;
			{
				partitionAllocation = new List<KeyValuePair<Range<long>, IStreamSource>>();
				long nextFreeByte = 1 * lvd.LogicalBlockSize;  /*Don't use block 0, due to inconsistencies in standard*/

				var rootICB = new FileEntryInformationControlBlockDescriptor(IcbFileType.Directory)
				{
					DescriptorVersion = 2,
					TagLocation = (uint)(nextFreeByte / lvd.LogicalBlockSize),
					AccessTime = (Timestamp)this.Root.LastAccessTime,
					ModificationTime = (Timestamp)this.Root.LastWriteTime,
					AttributeTime = (Timestamp)this.Root.LastWriteTime,
					Permissions = UdfFilePermissions.GroupRead | UdfFilePermissions.GroupExecute | UdfFilePermissions.OwnerRead | UdfFilePermissions.OwnerExecute | UdfFilePermissions.OtherRead | UdfFilePermissions.OtherExecute,
					Flags = (IcbFlags)AllocationDescriptorType.LongAllocationDescriptors,
					FileLinkCount = 0,
					UniqueIdentifier = 0, /*Must be zero for root*/
					MaximumEntryCount = 1,
					ImplementationIdentifier = new EntityIdentifier(EntityIdentifierFlags.None, this.DeveloperId, new ImplementationIdentifierSuffix(OperatingSystemClass.WindowsNT, 0)),
				};
				partitionAllocation.Add(new KeyValuePair<Range<long>, IStreamSource>(new Range<long>(nextFreeByte, nextFreeByte + lvd.LogicalBlockSize), new MarshalableStreamSource<TaggedDescriptor>(rootICB, "Root Directory ICB")));
				nextFreeByte += lvd.LogicalBlockSize;


				/*Record all file names, then all ICB's*/
				/*Pair: FileDescriptorsWithInfo => Parent*/

				long currentProgress = 0;
				long progressTotal = fileCount /*for all FIDs*/ + fileCount /*for all FE ICBs*/ + fileCount /*for all file data*/ + directoryCount /*For all ".." entries*/ + (directoryCount - 1) /*For all subdirectory FIDs*/ + directoryCount /*for all FE ICBs*/;

				var fileInfos = new List<FileDescriptorsWithInfo>();
				var stack = new Stack<FileDescriptorsWithInfo>();
				var reversingStack = new Stack<FileDescriptorsWithInfo>();
				stack.Push(new FileDescriptorsWithInfo(this.Root, null, rootICB, rootICB)); /*Own parent*/
				while (stack.Count > 0)
				{
					var pair = stack.Pop();
					integrityDescriptor.DirectoryCount++;

					var fsInfos = ((IDirectoryInfo)pair.File).GetFileSystemInfos(null, SearchOption.TopDirectoryOnly);

					if (!this.ReportProgress(MasterStage.Processing, "Processing files and directories", currentProgress, progressTotal, "files", pair.File))
					{ return null; }

					long startOfFIds = nextFreeByte;

					/*Add the parent as the first subdirectory*/
					var parentFID = new FileIdentifierDescriptor()
					{
						DescriptorVersion = 2,
						FileCharacteristics = FileCharacteristics.Directory | FileCharacteristics.Parent,
						FileIdentifier = string.Empty,
						TagLocation = (uint)(nextFreeByte / lvd.LogicalBlockSize),
						InformationControlBlock = new LongAllocationDescriptor(new ShortAllocationDescriptor(pair.ParentFileEntry.TagLocation, lvd.LogicalBlockSize, ExtentType.Recorded), pd.PartitionNumber, ExtentFlags.None, 0),
						FileVersionNumber = 1,
						/*ImplementationIdentifier = lvd.ImplementationIdentifier,*/
					};
					pair.ParentFileEntry.FileLinkCount++;
					partitionAllocation.Add(new KeyValuePair<Range<long>, IStreamSource>(new Range<long>(nextFreeByte, nextFreeByte + Marshaler.SizeOf(parentFID)), new MarshalableStreamSource<TaggedDescriptor>(parentFID, string.Format(@"{0}\..", pair.File.Name))));
					nextFreeByte += Marshaler.SizeOf(parentFID);

					/*We just added the ".." FID*/
					if (!this.ReportProgress(MasterStage.Processing, "Processing directories", currentProgress++, progressTotal, "files", pair.File))
					{ return null; }

					/*Maps each FID => (its corresponding file, its ICB)*/
					fileInfos.Clear();
					for (int i = 0; i < fsInfos.Length; i++)
					{
						var child = fsInfos[i];
						var asDir = child as IDirectoryInfo;

						var fid = new FileIdentifierDescriptor()
						{
							DescriptorVersion = 2,
							FileCharacteristics = (asDir != null ? FileCharacteristics.Directory : FileCharacteristics.None)
							| ((child.Attributes & FileAttributes.Hidden) != 0 ? FileCharacteristics.Hidden : FileCharacteristics.None),
							FileIdentifier = child.Name,
							TagLocation = (uint)(nextFreeByte / lvd.LogicalBlockSize),
							FileVersionNumber = 1,
							/*ImplementationIdentifier = lvd.ImplementationIdentifier,*/
						};

						int idSize = Marshaler.SizeOf(fid);

						/*It's better to align these, but the only real requirement is that tags don't cross block boundaries; since I wrote the code for this, though, I might as well use it!*/
						if (this.AlignFileIdentifiers) { CheckAndAlignFileIdentifiers(lvd, partitionAllocation, ref nextFreeByte, fid, idSize); }

						partitionAllocation.Add(new KeyValuePair<Range<long>, IStreamSource>(new Range<long>(nextFreeByte, nextFreeByte + idSize), new MarshalableStreamSource<TaggedDescriptor>(fid, string.Format("File Identifier: {0}", fid.FileIdentifier))));
						nextFreeByte += idSize;

						/*We just processed an FID (ICB is processed later)*/
						if (!this.ReportProgress(MasterStage.Processing, "Processing child File Identifier", currentProgress++, progressTotal, "files", Path.Combine(pair.File.FullName, child.Name)))
						{ return null; }

						FileEntryInformationControlBlockDescriptorBase icb;

						var asFile = child as IFileInfo;
						if (asFile == null || !hardlinkCache.TryGetValue(asFile, out icb)) { icb = null; }
						var duplicate = new KeyValuePair<IStreamSource, FileEntryInformationControlBlockDescriptorBase>();
						if (this.EncodeDuplicatesOnce && icb == null && asFile != null) { duplicate = sameFileCache.TryGetValue(asFile); icb = duplicate.Value; }
						if (icb == null)
						{
							icb = new FileEntryInformationControlBlockDescriptor(asDir != null ? IcbFileType.Directory : IcbFileType.RandomAccessByteSequenceFile)
							{
								DescriptorVersion = 2,
								AccessTime = (Timestamp)child.LastAccessTime,
								ModificationTime = (Timestamp)child.LastWriteTime,
								AttributeTime = (Timestamp)child.CreationTime,
								Permissions = UdfFilePermissions.GroupRead | UdfFilePermissions.GroupExecute | UdfFilePermissions.OwnerRead | UdfFilePermissions.OwnerExecute | UdfFilePermissions.OtherRead | UdfFilePermissions.OtherExecute,
								Flags = (IcbFlags)AllocationDescriptorType.LongAllocationDescriptors,
								FileLinkCount = 1,
								MaximumEntryCount = 1,
								ImplementationIdentifier = new EntityIdentifier(EntityIdentifierFlags.None, this.DeveloperId, new ImplementationIdentifierSuffix(OperatingSystemClass.WindowsNT, 0)),
								UniqueIdentifier = integrityDescriptor.GetNextUniqueId(true),
							};
							if (asFile != null && child.IndexNumber != -1) { hardlinkCache.Add(asFile, icb); }
							if (this.EncodeDuplicatesOnce) { if (asFile != null) { sameFileCache.TryAdd(asFile, icb); } }
						}
						else
						{
							if (duplicate.Key != null) /*This means that we found a duplicate file, not the same file with a hardlink*/
							{
								List<IStreamSource> dups;
								if (this.DuplicateFilesFound.TryGetValue(duplicate.Key, out dups))
								{ dups.Add(asFile); }
								else
								{
									dups = new List<IStreamSource>();
									dups.Add(duplicate.Key);
									dups.Add(asFile);
									this.DuplicateFilesFound.Add(duplicate.Key, dups);
								}
							}
							icb.FileLinkCount++;
						}

						fileInfos.Add(new FileDescriptorsWithInfo(child, fid, icb, null));
						if (asDir != null)
						{
							reversingStack.Push(new FileDescriptorsWithInfo(asDir, null, icb, pair.FileEntry));
						}
						else { integrityDescriptor.FileCount++; }
					}
					pair.FileEntry.LogicalBlocksRecorded = 1 + ((nextFreeByte - startOfFIds - 1) / lvd.LogicalBlockSize);
					pair.FileEntry.InformationLength = nextFreeByte - startOfFIds;
					pair.FileEntry.AllocationDescriptors = Marshaler.StructureToPtr(new LongAllocationDescriptor(new ShortAllocationDescriptor(parentFID.TagLocation, (uint)pair.FileEntry.InformationLength, ExtentType.Recorded), pd.PartitionNumber, ExtentFlags.None, 0));

					nextFreeByte = lvd.LogicalBlockSize * (1 + (nextFreeByte - 1) / lvd.LogicalBlockSize);

					for (int i = 0; i < fileInfos.Count; i++)
					{
						var info = fileInfos[i];

						currentProgress++; /*We are processing an ICB*/
						if (info.FileEntry.TagLocation <= 0)
						{
							info.FileEntry.TagLocation = (uint)(nextFreeByte / lvd.LogicalBlockSize);
							partitionAllocation.Add(new KeyValuePair<Range<long>, IStreamSource>(new Range<long>(nextFreeByte, nextFreeByte + lvd.LogicalBlockSize), new MarshalableStreamSource<TaggedDescriptor>(info.FileEntry, string.Format("File ICB: {0}", info.FileIdentifier))));
							nextFreeByte += lvd.LogicalBlockSize;
							if (info.FileEntry.FileType == IcbFileType.Directory)
							{ var dir = (IDirectoryInfo)info.File; }
							else { filesToBurn.Add(info); }
						}
						else { currentProgress++; /*NOTE: We're re-incrementing here to account for later, when we won't increment in the Data stage*/ }

						if (!this.ReportProgress(MasterStage.Processing, "Processing child Information Control Block", currentProgress/*pi.Completed is incremented above, outside of loop*/, progressTotal, "files", Path.Combine(pair.File.FullName, info.FileIdentifier.FileIdentifier)))
						{ return null; }

						info.FileIdentifier.InformationControlBlock = new LongAllocationDescriptor(new ShortAllocationDescriptor(info.FileEntry.TagLocation, lvd.LogicalBlockSize, ExtentType.Recorded), pd.PartitionNumber, ExtentFlags.None, 0);
					}

					/*This is used to keep directories in the same, and not opposite, order*/
					while (reversingStack.Count > 0) { stack.Push(reversingStack.Pop()); }
				}

				if (!this.AllocateFiles(pd, lvd.LogicalBlockSize, filesToBurn, partitionAllocation, ref nextFreeByte, ref currentProgress, progressTotal))
				{ return null; }

				/*Allocate the file table*/
				{
					var fsd = new FileSetDescriptor()
					{
						DomainIdentifier = lvd.DomainIdentifier,
						DescriptorVersion = 2,
						FileSetIdentifier = this.FileSetIdentifier,
						RecordingTime = integrityDescriptor.RecordingTime,
						RootDirectoryIcb = new LongAllocationDescriptor(new ShortAllocationDescriptor(rootICB.TagLocation, lvd.LogicalBlockSize, ExtentType.Recorded), pd.PartitionNumber, ExtentFlags.None, 0),
						LogicalVolumeIdentifier = lvd.LogicalVolumeIdentifier,
						TagLocation = 0,
					};
					lvd.FileSetDescriptorExtent = new LongAllocationDescriptor(new ShortAllocationDescriptor(fsd.TagLocation, lvd.LogicalBlockSize, ExtentType.Recorded), pd.PartitionNumber, ExtentFlags.None, 0);
					partitionAllocation.Add(new KeyValuePair<Range<long>, IStreamSource>(new Range<long>(fsd.TagLocation * lvd.LogicalBlockSize, (fsd.TagLocation + 1) * lvd.LogicalBlockSize), new MarshalableStreamSource<TaggedDescriptor>(fsd, "File Set Descriptor")));
					nextFreeByte += lvd.LogicalBlockSize;
				}

				/*Sort the allocation table; otherwise, we're in for a performance hit*/
				{
					if (!this.ReportProgress(MasterStage.Processing, "Processed all files, organizing table", progressTotal - 1, progressTotal, "files", string.Empty))
					{ return null; }

					partitionAllocation = SortAndCombineFileIdentifierRanges(lvd.LogicalBlockSize, partitionAllocation);
					pd.PartitionSectorCount = 1 + (uint)((partitionAllocation[partitionAllocation.Count - 1].Key.End - 1) / this.SectorSize);

					if (!this.ReportProgress(MasterStage.Processing, "Processed table", progressTotal, progressTotal, "files", string.Empty))
					{ return null; }
				}

				/*Don't allocate anything after here in partition (but in logical volume is OK)!!*/

				volumeAllocation = new List<KeyValuePair<Range<long>, IStreamSource>>(partitionAllocation.Count);

				/*We want to create the Reserve Volume Descriptor Sequence as far as as possible from the Main one*/
				/*This is not as far as possible on the disc, but separating them by the entire partition is the best I can currently implement*/
				integrityDescriptor.PartitionSizeInfos = new PartitionSizeInformation[] { new PartitionSizeInformation(0, (uint)(pd.PartitionSectorCount * lvd.LogicalBlockSize / this.SectorSize)) };
				anchor.ReserveVolumeDescriptorSequenceExtent = new ExtentAllocationDescriptor(pd.PartitionStartSector + pd.PartitionSectorCount, 0x8000);
				var nextFreeSector = (uint)Math.Max(pd.PartitionStartSector + pd.PartitionSectorCount,
					anchor.ReserveVolumeDescriptorSequenceExtent.LogicalSectorNumber + (1 + (anchor.ReserveVolumeDescriptorSequenceExtent.ByteLength - 1) / this.SectorSize));

				nextFreeSector = (1 + (1 + (nextFreeSector - 1) / 256)) * 256 - 1; /*Align this to the sector before the next sector that is a multiple of 256*/
			}

			AllocatedStream result;
			{
				if (!this.ReportProgress(MasterStage.Processing, "Building volume map", 0, 1, "steps", string.Empty))
				{ return null; }

				BuildVolumeMap(this.SectorSize, vrsStartSector, anchor, pd, lvd.LogicalBlockSize, integrityDescriptor, descriptors, volumeAllocation, partitionAllocation);

				var comparer = Range<long>.StartComparer.Default;
				volumeAllocation.Sort((a, b) => comparer.Compare(a.Key, b.Key));

				result = new AllocatedStream(volumeAllocation, true, false);

				if (!this.ReportProgress(MasterStage.Processing, "Built volume map", 1, 1, "steps", string.Empty))
				{ return null; }
			}
			return result;
		}

		public AllocatedStream PrepareWithDataFirst()
		{
			var udfVersion = new UdfRevision(0x01, 0x02);
			this.DuplicateFilesFound = new Dictionary<IStreamSource, List<IStreamSource>>(new StreamEqualityComparer());

			/*Count all the files to be able to report deterministic progress*/
			if (!this.ReportProgress(MasterStage.Preparing, "Counting files and directories", 0, 1, "files", null)) { return null; }
			long fileCount, directoryCount;
			Count(this.Root, out fileCount, out directoryCount);
			if (!this.ReportProgress(MasterStage.Preparing, "Counted files and directories", fileCount + directoryCount, fileCount + directoryCount, "files", null)) { return null; }

			/*Find out where the Volume Recognition Sequence should start, according to standard*/
			long vrsStartSector = (this.TrackStartSector + (0x7FFFL / this.SectorSize) + 1); /*First byte of the first sector after byte 0x7FFF; almost always equal to 0x8000*/

			/*TODO: Don't hard-code MainVolumeDescriptorSequenceExtent and other locations*/
			var anchor = new AnchorVolumeDescriptorPointer()
			{
				DescriptorVersion = 2,
				TagLocation = this.TrackStartSector + 256,
				MainVolumeDescriptorSequenceExtent = new ExtentAllocationDescriptor(this.TrackStartSector + 0x20, 0x8000),
				/*Set the reserve later*/
			};

			PartitionDescriptor pd;
			LogicalVolumeDescriptor lvd;
			LogicalVolumeIntegrityDescriptor integrityDescriptor;
			TaggedDescriptor[] descriptors;
			this.CreateVolumeDescriptorSequence(udfVersion, anchor, out pd, out lvd, out integrityDescriptor, out descriptors);

			List<KeyValuePair<Range<long>, IStreamSource>> volumeAllocation;

			/*This cache is used to detect hardlinks to files*/
			var hardlinkCache = new Dictionary<IFileInfo, FileEntryInformationControlBlockDescriptorBase>(new FileInfoComparer());
			var sameFileCache = this.EncodeDuplicatesOnce ? new UniqueStreamCollection<FileEntryInformationControlBlockDescriptorBase>() : null;
			/*We want to burn files after we burn all the other data*/
			var filesToBurn = new List<FileDescriptorsWithInfo>();
			List<KeyValuePair<Range<long>, IStreamSource>> partitionAllocation;
			{
				partitionAllocation = new List<KeyValuePair<Range<long>, IStreamSource>>();
				long nextFreeByte = 1 * lvd.LogicalBlockSize;  /*Don't use block 0, due to inconsistencies in standard*/

				var rootICB = new FileEntryInformationControlBlockDescriptor(IcbFileType.Directory)
				{
					DescriptorVersion = 2,
					TagLocation = (uint)(nextFreeByte / lvd.LogicalBlockSize),
					AccessTime = (Timestamp)this.Root.LastAccessTime,
					ModificationTime = (Timestamp)this.Root.LastWriteTime,
					AttributeTime = (Timestamp)this.Root.LastWriteTime,
					Permissions = UdfFilePermissions.GroupRead | UdfFilePermissions.GroupExecute | UdfFilePermissions.OwnerRead | UdfFilePermissions.OwnerExecute | UdfFilePermissions.OtherRead | UdfFilePermissions.OtherExecute,
					Flags = (IcbFlags)AllocationDescriptorType.LongAllocationDescriptors,
					FileLinkCount = 0,
					UniqueIdentifier = 0, /*Must be zero for root*/
					MaximumEntryCount = 1,
					ImplementationIdentifier = new EntityIdentifier(EntityIdentifierFlags.None, this.DeveloperId, new ImplementationIdentifierSuffix(OperatingSystemClass.WindowsNT, 0)),
				};
				partitionAllocation.Add(new KeyValuePair<Range<long>, IStreamSource>(new Range<long>(nextFreeByte, nextFreeByte + lvd.LogicalBlockSize), new MarshalableStreamSource<TaggedDescriptor>(rootICB, "Root Directory ICB")));
				nextFreeByte += lvd.LogicalBlockSize;


				/*Record all file names, then all ICB's*/
				/*Pair: FileDescriptorsWithInfo => Parent*/

				long currentProgress = 0;
				long progressTotal = fileCount /*for all FIDs*/ + fileCount /*for all FE ICBs*/ + fileCount /*for all file data*/ + directoryCount /*For all ".." entries*/ + (directoryCount - 1) /*For all subdirectory FIDs*/ + directoryCount /*for all FE ICBs*/;

				var fileInfos = new List<FileDescriptorsWithInfo>();
				var stack = new Stack<FileDescriptorsWithInfo>();
				var reversingStack = new Stack<FileDescriptorsWithInfo>();
				stack.Push(new FileDescriptorsWithInfo(this.Root, null, rootICB, rootICB)); /*Own parent*/
				while (stack.Count > 0)
				{
					var pair = stack.Pop();
					integrityDescriptor.DirectoryCount++;

					var fsInfos = ((IDirectoryInfo)pair.File).GetFileSystemInfos(null, SearchOption.TopDirectoryOnly);

					if (!this.ReportProgress(MasterStage.Processing, "Processing directories", currentProgress, progressTotal, "files", pair.File))
					{ return null; }

					long startOfFIds = nextFreeByte;

					/*Add the parent as the first subdirectory*/
					var parentFID = new FileIdentifierDescriptor()
					{
						DescriptorVersion = 2,
						FileCharacteristics = FileCharacteristics.Directory | FileCharacteristics.Parent,
						FileIdentifier = string.Empty,
						TagLocation = (uint)(nextFreeByte / lvd.LogicalBlockSize),
						InformationControlBlock = new LongAllocationDescriptor(new ShortAllocationDescriptor(pair.ParentFileEntry.TagLocation, lvd.LogicalBlockSize, ExtentType.Recorded), pd.PartitionNumber, ExtentFlags.None, 0),
						FileVersionNumber = 1,
						/*ImplementationIdentifier = lvd.ImplementationIdentifier,*/
					};
					pair.ParentFileEntry.FileLinkCount++;
					partitionAllocation.Add(new KeyValuePair<Range<long>, IStreamSource>(new Range<long>(nextFreeByte, nextFreeByte + Marshaler.SizeOf(parentFID)), new MarshalableStreamSource<TaggedDescriptor>(parentFID, string.Format(@"{0}\..", pair.File.Name))));
					nextFreeByte += Marshaler.SizeOf(parentFID);

					/*We just added the ".." FID*/
					if (!this.ReportProgress(MasterStage.Processing, "Processing directories", currentProgress++, progressTotal, "files", pair.File))
					{ return null; }

					/*Maps each FID => (its corresponding file, its ICB)*/
					fileInfos.Clear();
					for (int i = 0; i < fsInfos.Length; i++)
					{
						var child = fsInfos[i];
						var asDir = child as IDirectoryInfo;

						var fid = new FileIdentifierDescriptor()
						{
							DescriptorVersion = 2,
							FileCharacteristics = (asDir != null ? FileCharacteristics.Directory : FileCharacteristics.None) | ((child.Attributes & FileAttributes.Hidden) != 0 ? FileCharacteristics.Hidden : FileCharacteristics.None),
							FileIdentifier = child.Name,
							TagLocation = (uint)(nextFreeByte / lvd.LogicalBlockSize),
							FileVersionNumber = 1,
							/*ImplementationIdentifier = lvd.ImplementationIdentifier,*/
						};

						int idSize = Marshaler.SizeOf(fid);

						/*It's better to align these, but the only real requirement is that tags don't cross block boundaries; since I wrote the code for this, though, I might as well use it!*/
						if (this.AlignFileIdentifiers) { CheckAndAlignFileIdentifiers(lvd, partitionAllocation, ref nextFreeByte, fid, idSize); }

						partitionAllocation.Add(new KeyValuePair<Range<long>, IStreamSource>(new Range<long>(nextFreeByte, nextFreeByte + idSize), new MarshalableStreamSource<TaggedDescriptor>(fid, string.Format("File Identifier: {0}", fid.FileIdentifier))));
						nextFreeByte += idSize;

						/*We just processed an FID (ICB is processed later)*/
						if (!this.ReportProgress(MasterStage.Processing, "Processing child File Identifier", currentProgress++, progressTotal, "files", Path.Combine(pair.File.FullName, child.Name)))
						{ return null; }

						FileEntryInformationControlBlockDescriptorBase icb;

						var asFile = child as IFileInfo;
						if (asFile == null || !hardlinkCache.TryGetValue(asFile, out icb)) { icb = null; }
						var duplicate = new KeyValuePair<IStreamSource, FileEntryInformationControlBlockDescriptorBase>();
						if (this.EncodeDuplicatesOnce && icb == null && asFile != null) { duplicate = sameFileCache.TryGetValue(asFile); icb = duplicate.Value; }
						if (icb == null)
						{
							icb = new FileEntryInformationControlBlockDescriptor(asDir != null ? IcbFileType.Directory : IcbFileType.RandomAccessByteSequenceFile)
							{
								DescriptorVersion = 2,
								AccessTime = (Timestamp)child.LastAccessTime,
								ModificationTime = (Timestamp)child.LastWriteTime,
								AttributeTime = (Timestamp)child.CreationTime,
								Permissions = UdfFilePermissions.GroupRead | UdfFilePermissions.GroupExecute | UdfFilePermissions.OwnerRead | UdfFilePermissions.OwnerExecute | UdfFilePermissions.OtherRead | UdfFilePermissions.OtherExecute,
								Flags = (IcbFlags)AllocationDescriptorType.LongAllocationDescriptors,
								FileLinkCount = 1,
								MaximumEntryCount = 1,
								ImplementationIdentifier = new EntityIdentifier(EntityIdentifierFlags.None, this.DeveloperId, new ImplementationIdentifierSuffix(OperatingSystemClass.WindowsNT, 0)),
								UniqueIdentifier = integrityDescriptor.GetNextUniqueId(true),
							};
							if (asFile != null && child.IndexNumber != -1) { hardlinkCache.Add(asFile, icb); }
							if (this.EncodeDuplicatesOnce) { if (asFile != null) { sameFileCache.TryAdd(asFile, icb); } }
						}
						else
						{
							if (duplicate.Key != null) /*This means that we found a duplicate file, not the same file with a hardlink*/
							{
								List<IStreamSource> dups;
								if (this.DuplicateFilesFound.TryGetValue(duplicate.Key, out dups))
								{ dups.Add(asFile); }
								else
								{
									dups = new List<IStreamSource>();
									dups.Add(duplicate.Key);
									dups.Add(asFile);
									this.DuplicateFilesFound.Add(duplicate.Key, dups);
								}
							}
							icb.FileLinkCount++;
						}

						fileInfos.Add(new FileDescriptorsWithInfo(child, fid, icb, null));
						if (asDir != null)
						{
							reversingStack.Push(new FileDescriptorsWithInfo(asDir, null, icb, pair.FileEntry));
						}
						else { integrityDescriptor.FileCount++; }
					}
					pair.FileEntry.LogicalBlocksRecorded = 1 + ((nextFreeByte - startOfFIds - 1) / lvd.LogicalBlockSize);
					pair.FileEntry.InformationLength = nextFreeByte - startOfFIds;
					pair.FileEntry.AllocationDescriptors = Marshaler.StructureToPtr(new LongAllocationDescriptor(new ShortAllocationDescriptor(parentFID.TagLocation, (uint)pair.FileEntry.InformationLength, ExtentType.Recorded), pd.PartitionNumber, ExtentFlags.None, 0));

					nextFreeByte = lvd.LogicalBlockSize * (1 + (nextFreeByte - 1) / lvd.LogicalBlockSize);

					for (int i = 0; i < fileInfos.Count; i++)
					{
						var info = fileInfos[i];

						currentProgress++; /*We are processing an ICB*/
						if (info.FileEntry.TagLocation <= 0)
						{
							info.FileEntry.TagLocation = (uint)(nextFreeByte / lvd.LogicalBlockSize);
							partitionAllocation.Add(new KeyValuePair<Range<long>, IStreamSource>(new Range<long>(nextFreeByte, nextFreeByte + lvd.LogicalBlockSize), new MarshalableStreamSource<TaggedDescriptor>(info.FileEntry, string.Format("File ICB: {0}", info.FileIdentifier))));
							nextFreeByte += lvd.LogicalBlockSize;
							if (info.FileEntry.FileType == IcbFileType.Directory)
							{ var dir = (IDirectoryInfo)info.File; }
							else { filesToBurn.Add(info); }
						}
						else { currentProgress++; /*NOTE: We're re-incrementing here to account for later, when we won't increment in the Data stage*/ }

						if (!this.ReportProgress(MasterStage.Processing, "Processing child Information Control Block", currentProgress/*pi.Completed is incremented above, outside of loop*/, progressTotal, "files", Path.Combine(pair.File.FullName, info.FileIdentifier.FileIdentifier)))
						{ return null; }

						info.FileIdentifier.InformationControlBlock = new LongAllocationDescriptor(new ShortAllocationDescriptor(info.FileEntry.TagLocation, lvd.LogicalBlockSize, ExtentType.Recorded), pd.PartitionNumber, ExtentFlags.None, 0);
					}

					/*This is used to keep directories in the same, and not opposite, order*/
					while (reversingStack.Count > 0) { stack.Push(reversingStack.Pop()); }
				}

				if (!this.AllocateFiles(pd, lvd.LogicalBlockSize, filesToBurn, partitionAllocation, ref nextFreeByte, ref currentProgress, progressTotal))
				{ return null; }

				/*Allocate the file table*/
				{
					var fsd = new FileSetDescriptor()
					{
						DomainIdentifier = lvd.DomainIdentifier,
						DescriptorVersion = 2,
						FileSetIdentifier = this.FileSetIdentifier,
						RecordingTime = integrityDescriptor.RecordingTime,
						RootDirectoryIcb = new LongAllocationDescriptor(new ShortAllocationDescriptor(rootICB.TagLocation, lvd.LogicalBlockSize, ExtentType.Recorded), pd.PartitionNumber, ExtentFlags.None, 0),
						LogicalVolumeIdentifier = lvd.LogicalVolumeIdentifier,
						TagLocation = 0,
					};
					lvd.FileSetDescriptorExtent = new LongAllocationDescriptor(new ShortAllocationDescriptor(fsd.TagLocation, lvd.LogicalBlockSize, ExtentType.Recorded), pd.PartitionNumber, ExtentFlags.None, 0);
					partitionAllocation.Add(new KeyValuePair<Range<long>, IStreamSource>(new Range<long>(fsd.TagLocation * lvd.LogicalBlockSize, (fsd.TagLocation + 1) * lvd.LogicalBlockSize), new MarshalableStreamSource<TaggedDescriptor>(fsd, "File Set Descriptor")));
					nextFreeByte += lvd.LogicalBlockSize;
				}

				/*Sort the allocation table; otherwise, we're in for a performance hit*/
				{
					if (!this.ReportProgress(MasterStage.Processing, "Processed all files, organizing table", progressTotal - 1, progressTotal, "files", string.Empty))
					{ return null; }

					partitionAllocation = SortAndCombineFileIdentifierRanges(lvd.LogicalBlockSize, partitionAllocation);
					pd.PartitionSectorCount = 1 + (uint)((partitionAllocation[partitionAllocation.Count - 1].Key.End - 1) / this.SectorSize);

					if (!this.ReportProgress(MasterStage.Processing, "Processed table", progressTotal, progressTotal, "files", string.Empty))
					{ return null; }
				}

				/*Don't allocate anything after here in partition (but in logical volume is OK)!!*/

				volumeAllocation = new List<KeyValuePair<Range<long>, IStreamSource>>(partitionAllocation.Count);

				/*We want to create the Reserve Volume Descriptor Sequence as far as as possible from the Main one*/
				/*This is not as far as possible on the disc, but separating them by the entire partition is the best I can currently implement*/
				integrityDescriptor.PartitionSizeInfos = new PartitionSizeInformation[] { new PartitionSizeInformation(0, (uint)(pd.PartitionSectorCount * lvd.LogicalBlockSize / this.SectorSize)) };
				anchor.ReserveVolumeDescriptorSequenceExtent = new ExtentAllocationDescriptor(pd.PartitionStartSector + pd.PartitionSectorCount, 0x8000);
				var nextFreeSector = (uint)Math.Max(pd.PartitionStartSector + pd.PartitionSectorCount,
					anchor.ReserveVolumeDescriptorSequenceExtent.LogicalSectorNumber + (1 + (anchor.ReserveVolumeDescriptorSequenceExtent.ByteLength - 1) / this.SectorSize));

				nextFreeSector = (1 + (1 + (nextFreeSector - 1) / 256)) * 256 - 1; /*Align this to the sector before the next sector that is a multiple of 256*/
			}

			AllocatedStream result;
			{
				if (!this.ReportProgress(MasterStage.Processing, "Building volume map", 0, 1, "steps", string.Empty))
				{ return null; }

				BuildVolumeMap(this.SectorSize, vrsStartSector, anchor, pd, lvd.LogicalBlockSize, integrityDescriptor, descriptors, volumeAllocation, partitionAllocation);

				var comparer = Range<long>.StartComparer.Default;
				volumeAllocation.Sort((a, b) => comparer.Compare(a.Key, b.Key));

				result = new AllocatedStream(volumeAllocation, true, false);

				if (!this.ReportProgress(MasterStage.Processing, "Built volume map", 1, 1, "steps", string.Empty))
				{ return null; }
			}
			return result;
		}

		private List<KeyValuePair<Range<long>, IStreamSource>> SortAndCombineFileIdentifierRanges(int logicalBlockSize, IList<KeyValuePair<Range<long>, IStreamSource>> allocation)
		{
			var ranges = new KeyValuePair<Range<long>, IStreamSource>[allocation.Count];
			/*((IDictionary<Range<long>, IStreamSource>)allocation).CopyTo(ranges, 0);*/
			int iTemp = 0;
			foreach (var item in allocation) { ranges[iTemp++] = item; }

			var result = new List<KeyValuePair<Range<long>, IStreamSource>>(allocation.Count);

			int i = 0;
			while (i < ranges.Length)
			{
				if (ranges[i].Value.Source is FileIdentifierDescriptor)
				{
					long startOffset = ranges[i].Key.Start;
					Debug.Assert(startOffset % logicalBlockSize == 0);
					int start = i;
					long length = 0;
					do
					{
						length += ranges[i].Key.End - ranges[i].Key.Start;
						i++;
					} while (i < ranges.Length && ranges[i].Value.Source is FileIdentifierDescriptor && ((((FileIdentifierDescriptor)ranges[i].Value.Source).FileCharacteristics & FileCharacteristics.Parent) == 0));


					int count = i - start;
					if (count > 1)
					{
						var ids = new FileIdentifierDescriptor[count];
						for (int j = start; j < i; j++)
						{
							ids[j - start] = (FileIdentifierDescriptor)ranges[j].Value.Source;
						}

						length = logicalBlockSize * (1 + (length - 1) / logicalBlockSize);

						result.Add(new KeyValuePair<Range<long>, IStreamSource>(new Range<long>(startOffset, startOffset + length), new MarshalableArrayStreamSource<TaggedDescriptor>(ids, "[Directory Contents]")));
					}
					else { result.Add(new KeyValuePair<Range<long>, IStreamSource>(ranges[i - 1].Key, ranges[i - 1].Value)); }
				}
				else
				{
					result.Add(new KeyValuePair<Range<long>, IStreamSource>(ranges[i].Key, ranges[i].Value));
					i++;
				}
			}

			result.Sort(new KeyValuePairKeyComparer<Range<long>, IStreamSource>(Range<long>.StartComparer.Default));

			return result;
		}

		private struct FileDescriptorsWithInfo
		{
			public FileDescriptorsWithInfo(IFileSystemInfo file, FileIdentifierDescriptor id, FileEntryInformationControlBlockDescriptorBase icb, FileEntryInformationControlBlockDescriptorBase parentIcb)
			{
				this.File = file;
				this.FileIdentifier = id;
				this.FileEntry = icb;
				this.ParentFileEntry = parentIcb;
			}

			public IFileSystemInfo File;
			public FileIdentifierDescriptor FileIdentifier;
			public FileEntryInformationControlBlockDescriptorBase FileEntry;
			public FileEntryInformationControlBlockDescriptorBase ParentFileEntry;
		}
	}

}