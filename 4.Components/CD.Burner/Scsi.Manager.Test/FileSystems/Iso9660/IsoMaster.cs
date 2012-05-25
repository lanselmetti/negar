using System;
using Helper.IO;

namespace FileSystems.Iso9660
{
	public class IsoMaster : DiscMaster
	{
		public IsoMaster(int sectorSize) : base(sectorSize) { }

		public override long GetLength(out long fileCount, out long directoryCount, out long metadataSize)
		{
			throw new NotImplementedException();
		}

		public override AllocatedStream Prepare()
		{
			throw new NotImplementedException();
		}
	}
}