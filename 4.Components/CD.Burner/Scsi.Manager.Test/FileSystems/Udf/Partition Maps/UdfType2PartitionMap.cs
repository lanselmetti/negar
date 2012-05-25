using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace FileSystems.Udf
{
	[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
	public abstract class UdfType2PartitionMap : Type2PartitionMap
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr RESERVED1_BP = (IntPtr)2; //Marshal.OffsetOf(typeof(UdfType2PartitionMap), "_Reserved1");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr PARTITION_TYPE_IDENTIFIER_BP = (IntPtr)4; //Marshal.OffsetOf(typeof(UdfType2PartitionMap), "_PartitionTypeIdentifier");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr VOLUME_SEQUENCE_NUMBER_BP = (IntPtr)36; //Marshal.OffsetOf(typeof(UdfType2PartitionMap), "_VolumeSequenceNumber");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr PARTITION_NUMBER_BP = (IntPtr)38; //Marshal.OffsetOf(typeof(UdfType2PartitionMap), "_PartitionNumber");

		protected UdfType2PartitionMap(EntityIdentifier identifier) : base() { this._PartitionTypeIdentifier = identifier; }

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ushort _Reserved1;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EntityIdentifier _PartitionTypeIdentifier;
		public EntityIdentifier PartitionTypeIdentifier { get { return this._PartitionTypeIdentifier; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ushort _VolumeSequenceNumber;
		public ushort VolumeSequenceNumber { get { return this._VolumeSequenceNumber; } set { this._VolumeSequenceNumber = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ushort _PartitionNumber;
		public ushort PartitionNumber { get { return this._PartitionNumber; } set { this._PartitionNumber = value; } }

		internal static EntityIdentifier ReadPartitionTypeIdentifier(BufferWithSize buffer) { return Marshaler.PtrToStructure<EntityIdentifier>(buffer.ExtractSegment(PARTITION_TYPE_IDENTIFIER_BP)); }

		internal new static UdfType2PartitionMap FromBuffer(BufferWithSize type2PartMap)
		{
			Debug.Assert(type2PartMap.Read<PartitionMapType>() == PartitionMapType.Type2);
			var id = ReadPartitionTypeIdentifier(type2PartMap);
			UdfType2PartitionMap result;
			if (id.ToString() == EntityIdentifier.MetadataPartitionMapId) { result = Marshaler.PtrToStructure<MetadataPartitionMap>(type2PartMap); }
			else if (id.ToString() == EntityIdentifier.VirtualPartitionMapPartitionTypeId) { result = Marshaler.PtrToStructure<VirtualPartitionMap>(type2PartMap); }
			else if (id.ToString() == EntityIdentifier.SparablePartitionMapPartitionTypeId) { result = Marshaler.PtrToStructure<SparablePartitionMap>(type2PartMap); }
			else { throw new NotSupportedException(string.Format("Partition map {0} type not supported.", id.IdentifierToString())); }
			return result;
		}

		protected override void MarshalFrom(BufferWithSize buffer)
		{
			base.MarshalFrom(buffer);
			this._Reserved1 = buffer.Read<ushort>(RESERVED1_BP);
			this._PartitionTypeIdentifier = buffer.Read<EntityIdentifier>(PARTITION_TYPE_IDENTIFIER_BP);
			this._VolumeSequenceNumber = buffer.Read<ushort>(VOLUME_SEQUENCE_NUMBER_BP);
			this._PartitionNumber = buffer.Read<ushort>(PARTITION_NUMBER_BP);
		}

		protected override void MarshalTo(BufferWithSize buffer)
		{
			base.MarshalTo(buffer);
			buffer.Write(this._Reserved1, RESERVED1_BP);
			buffer.Write(this._PartitionTypeIdentifier, PARTITION_TYPE_IDENTIFIER_BP);
			buffer.Write(this._VolumeSequenceNumber, VOLUME_SEQUENCE_NUMBER_BP);
			buffer.Write(this._PartitionNumber, PARTITION_NUMBER_BP);
		}

		protected override int MarshaledSize { get { return Marshaler.DefaultSizeOf<UdfType2PartitionMap>(); } }
	}
}