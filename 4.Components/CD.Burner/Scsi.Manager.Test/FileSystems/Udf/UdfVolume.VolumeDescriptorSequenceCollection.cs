using System;
using System.Collections.Generic;
using System.IO;
using System.Collections.ObjectModel;
using Helper;
using Helper.IO;

namespace FileSystems.Udf
{
	public partial class UdfVolume
	{
		private class VolumeDescriptorSequenceCollection : Collection<TaggedDescriptor>
		{
			private UdfVolume fs;

			internal VolumeDescriptorSequenceCollection(UdfVolume fs, FileMode mode)
				: base()
			{
				this.fs = fs;
				if (mode == FileMode.Open)
				{
					{
						long newPosition = fs.anchorVolumeDescriptorPointer.MainVolumeDescriptorSequenceExtent.LogicalSectorNumber * this.fs.LogicalSectorSize;
						if (newPosition != this.fs.BaseStream.Position) { this.fs.BaseStream.Position = newPosition; }
						var mainSequenceBytes = new byte[this.fs.anchorVolumeDescriptorPointer.MainVolumeDescriptorSequenceExtent.ByteLength];
						this.fs.BaseStream.ReadExactly(mainSequenceBytes, 0, mainSequenceBytes.Length);
						for (int i = 0; i < mainSequenceBytes.Length / this.fs.LogicalSectorSize; i++)
						{
							var converted = this.fs.ConvertTaggedDescriptorToManaged(mainSequenceBytes, i * this.fs.LogicalSectorSize, true);
							if (converted.TagLocation != newPosition / this.fs.LogicalSectorSize + i) //TODO: It's actually block and not sector...
							{ throw new InvalidDataException("Corrupted volume descriptor sequence element."); }
							base.InsertItem(this.Count, converted);
							if (converted is TerminatingDescriptor) { break; }
						}
					}
#if VERIFY_RESERVE
					//Now read the reserve sequence and check that it is equal
					var reserve = new List<TaggedDescriptor>();
					{
						long newPosition = fs.anchorVolumeDescriptorPointer.ReserveVolumeDescriptorSequenceExtent.LogicalSectorNumber * this.fs.LogicalSectorSize;
						if (newPosition != this.fs.BaseStream.Position) { this.fs.BaseStream.Position = newPosition; }
						var reserveSequenceBytes = new byte[this.fs.anchorVolumeDescriptorPointer.ReserveVolumeDescriptorSequenceExtent.ByteLength];
						this.fs.BaseStream.Read(reserveSequenceBytes, 0, reserveSequenceBytes.Length);
						for (int i = 0; i < reserveSequenceBytes.Length / this.fs.LogicalSectorSize; i++)
						{
							var converted = this.fs.ConvertTaggedDescriptorToManaged(reserveSequenceBytes, i * (int)this.fs.LogicalSectorSize, true);
							if (converted.TagLocation != newPosition / (int)this.fs.LogicalSectorSize + i) //TODO: It's actually block and not sector...
							{ throw new InvalidDataException("Corrupted volume descriptor sequence element."); }
							reserve.Add(converted);
							if (converted is TerminatingDescriptor) { break; }
						}
					}

					bool equal = true;
					if (this.Count == reserve.Count)
					{
						for (int i = 0; i < this.Count; i++)
						{
							var mine = this[i];
							var other = reserve[i];
							if (mine.TagIdentifier != other.TagIdentifier | mine.TagSerialNumber != other.TagSerialNumber
								| mine.DescriptorCrc != other.DescriptorCrc | mine.DescriptorCrcLength != other.DescriptorCrcLength | mine.DescriptorVersion != other.DescriptorVersion)
							{ equal = false; }
						}
					}
					if (!equal) { throw new InvalidDataException("Volume sequence descriptors do not match."); }
#endif
				}
				else { throw new NotImplementedException(); }
			}

			protected override void ClearItems()
			{
				throw new NotImplementedException();
				//base.ClearItems();
			}

			protected override void InsertItem(int index, TaggedDescriptor item)
			{
				//IMPORTANT: This method is BYPASSED in the constructor!
				throw new NotImplementedException();
				//base.InsertItem(index, item);
			}

			protected override void RemoveItem(int index)
			{
				throw new NotImplementedException();
				//base.RemoveItem(index);
			}

			protected override void SetItem(int index, TaggedDescriptor item)
			{
				throw new NotImplementedException();
				//base.SetItem(index, item);
			}

			internal void Update()
			{
				if (this.fs.BaseStream.CanWrite)
				{
					throw new NotImplementedException("The AnchorVolumeDescriptorPointer must be updated, which is not implemented.");
#if false
					if (this.fs.anchorVolumeDescriptorPointer.MainVolumeDescriptorSequenceExtent.ByteLength < this.Count * this.fs.LogicalSectorSize)
					{ throw new EndOfStreamException(); }
					if (this.fs.anchorVolumeDescriptorPointer.ReserveVolumeDescriptorSequenceExtent.ByteLength < this.Count * this.fs.LogicalSectorSize)
					{ throw new EndOfStreamException(); }

					var buffer = new byte[this.fs.LogicalSectorSize];

					{
						long newPosition = this.fs.anchorVolumeDescriptorPointer.MainVolumeDescriptorSequenceExtent.LogicalSectorNumber * this.fs.LogicalSectorSize;
						if (newPosition != this.fs.BaseStream.Position) { this.fs.BaseStream.Position = newPosition; }
						for (int i = 0; i < this.Count; i++)
						{
							var entry = this[i];
							//buffer.Initialize();
							entry.TagLocation = (uint)(this.fs.BaseStream.Position / this.fs.LogicalSectorSize);
							Marshaler.StructureToPtr(entry, buffer, 0);
							this.fs.BaseStream.Write(buffer, 0, buffer.Length);
						}
					}

					{
						long newPosition = this.fs.anchorVolumeDescriptorPointer.ReserveVolumeDescriptorSequenceExtent.LogicalSectorNumber * this.fs.LogicalSectorSize;
						if (newPosition != this.fs.BaseStream.Position) { this.fs.BaseStream.Position = newPosition; }
						for (int i = 0; i < this.Count; i++)
						{
							var entry = this[i];
							//buffer.Initialize();
							entry.TagLocation = (uint)(this.fs.BaseStream.Position / this.fs.LogicalSectorSize);
							Marshaler.StructureToPtr(entry, buffer, 0);
							this.fs.BaseStream.Write(buffer, 0, buffer.Length);
						}
					}

					this.fs.anchorVolumeDescriptorPointer.IncrementSerialNumber();
					foreach (var item in this) { item.TagSerialNumber = this.fs.anchorVolumeDescriptorPointer.TagSerialNumber; }
#endif
				}
			}
		}
	}
}