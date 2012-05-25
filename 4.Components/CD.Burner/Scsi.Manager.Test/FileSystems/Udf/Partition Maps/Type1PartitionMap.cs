using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace FileSystems.Udf
{
	[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
	public class Type1PartitionMap : PartitionMap
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr VOLUME_SEQUENCE_NUMBER_BP = (IntPtr)2; //Marshal.OffsetOf(typeof(Type1PartitionMap), "_VolumeSequenceNumber");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr PARTITION_NUMBER_BP = (IntPtr)4; //Marshal.OffsetOf(typeof(Type1PartitionMap), "_PartitionNumber");

		public Type1PartitionMap() : base(PartitionMapType.Type1, 6) { }

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ushort _VolumeSequenceNumber;
		public ushort VolumeSequenceNumber { get { return this._VolumeSequenceNumber; } set { this._VolumeSequenceNumber = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ushort _PartitionNumber;
		public ushort PartitionNumber { get { return this._PartitionNumber; } set { this._PartitionNumber = value; } }

		protected override void MarshalFrom(BufferWithSize buffer)
		{
			base.MarshalFrom(buffer);
			this._VolumeSequenceNumber = buffer.Read<ushort>(VOLUME_SEQUENCE_NUMBER_BP);
			this._PartitionNumber = buffer.Read<ushort>(PARTITION_NUMBER_BP);
		}

		protected override void MarshalTo(BufferWithSize buffer)
		{
			base.MarshalTo(buffer);
			buffer.Write(this._VolumeSequenceNumber, VOLUME_SEQUENCE_NUMBER_BP);
			buffer.Write(this._PartitionNumber, PARTITION_NUMBER_BP);
		}

		protected override int MarshaledSize { get { return Marshaler.DefaultSizeOf<Type1PartitionMap>(); } }
	}
}