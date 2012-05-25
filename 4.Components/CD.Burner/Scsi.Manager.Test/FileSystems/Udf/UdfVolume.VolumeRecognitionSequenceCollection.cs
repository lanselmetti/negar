using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using Helper;
using Helper.IO;

namespace FileSystems.Udf
{
	public partial class UdfVolume
	{
		private class VolumeRecognitionSequenceCollection : Collection<UdfVolumeStructureDescriptor>
		{
			private static readonly byte VRS_START_SECTOR = 16;
			private UdfVolume fs;

			internal VolumeRecognitionSequenceCollection(UdfVolume fs, FileMode mode)
				: base()
			{
				this.fs = fs;
				if (mode == FileMode.Open)
				{
					long newPosition = this.fs.LogicalSectorSize * VRS_START_SECTOR;
					if (this.fs.BaseStream.Position != newPosition) { this.fs.BaseStream.Position = newPosition; }
					var buffer = new byte[this.fs.LogicalSectorSize];
					bool adding = false;
					for (; ; )
					{
						this.fs.BaseStream.ReadExactly(buffer, 0, buffer.Length);
						var entry = this.fs.ConvertVolumeDescriptorToManaged(buffer, 0);
						if (entry is BeginningExtendedAreaDescriptor) { adding = true; }
						if (adding) { base.InsertItem(this.Count, entry); }
						if (entry is TerminatingExtendedAreaDescriptor) { adding = false; break; }
					}
				}
				else { throw new NotImplementedException(); }
			}

			protected override void ClearItems()
			{
				throw new NotImplementedException();
				//base.ClearItems();
			}

			protected override void InsertItem(int index, UdfVolumeStructureDescriptor item)
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

			protected override void SetItem(int index, UdfVolumeStructureDescriptor item)
			{
				throw new NotImplementedException();
				//base.SetItem(index, item);
			}

			internal void Update()
			{
				long newPosition = this.fs.LogicalSectorSize * VRS_START_SECTOR;
				if (this.fs.BaseStream.Position != newPosition) { this.fs.BaseStream.Position = newPosition; }
				var buffer = new byte[this.fs.LogicalSectorSize];
				foreach (var item in this)
				{
					Marshaler.StructureToPtr(item, buffer, 0);
					this.fs.BaseStream.Write(buffer, 0, buffer.Length);
				}
			}
		}
	}
}