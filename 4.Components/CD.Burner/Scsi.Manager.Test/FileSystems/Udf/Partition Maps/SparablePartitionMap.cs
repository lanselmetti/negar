using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace FileSystems.Udf
{
	[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
	public class SparablePartitionMap : UdfType2PartitionMap
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr PACKET_LENGTH_BP = (IntPtr)40; //Marshal.OffsetOf(typeof(SparablePartitionMap), "_PacketLength");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr SPARING_TABLE_COUNT_BP = (IntPtr)42; //Marshal.OffsetOf(typeof(SparablePartitionMap), "_SparingTableCount");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr RESERVED2_BP = (IntPtr)43; //Marshal.OffsetOf(typeof(SparablePartitionMap), "_Reserved2");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr SPARING_TABLE_SIZE_BP = (IntPtr)44; //Marshal.OffsetOf(typeof(SparablePartitionMap), "_SparingTableSize");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr SPARING_TABLE_LOCATIONS_BP = (IntPtr)48; //Marshal.OffsetOf(typeof(SparablePartitionMap), "_SparingTableLocations");

		public SparablePartitionMap() : base(new EntityIdentifier(0, EntityIdentifier.SparablePartitionMapPartitionTypeId, 0)) { }

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ushort _PacketLength;
		public ushort PacketLength { get { return this._PacketLength; } set { this._PacketLength = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private byte _SparingTableCount;
		public byte SparingTableCount { get { return this._SparingTableCount; } set { this._SparingTableCount = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private byte _Reserved2;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private uint _SparingTableSize; //Size of EACH sparing table, not total, in bytes
		public uint SparingTableSize { get { return this._SparingTableSize; } set { this._SparingTableSize = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] //Can be at most 4 elements
		private uint[] _SparingTableLocations = new uint[4];
		/// <summary>The logical block numbers of the sparing tables. Elements with value <c>0</c> are unused and should be at the end of the array.</summary>
		public uint[] SparingTableLocations { get { return this._SparingTableLocations; } }

		protected override void MarshalFrom(BufferWithSize buffer)
		{
			base.MarshalFrom(buffer);
			this._PacketLength = buffer.Read<ushort>(PACKET_LENGTH_BP);
			this._SparingTableCount = buffer.Read<byte>(SPARING_TABLE_COUNT_BP);
			this._Reserved2 = buffer.Read<byte>(RESERVED2_BP);
			this._SparingTableSize = buffer.Read<uint>(SPARING_TABLE_SIZE_BP);
			this._SparingTableLocations = new uint[4];
			for (int i = 0; i < this._SparingTableCount; i++)
			{ this._SparingTableLocations[i] = buffer.Read<uint>((int)SPARING_TABLE_LOCATIONS_BP + i * sizeof(uint)); }
		}

		protected override void MarshalTo(BufferWithSize buffer)
		{
			base.MarshalTo(buffer);
			buffer.Write(this._PacketLength, PACKET_LENGTH_BP);
			buffer.Write(this._SparingTableCount, SPARING_TABLE_COUNT_BP);
			buffer.Write(this._Reserved2, RESERVED2_BP);
			buffer.Write(this._SparingTableSize, SPARING_TABLE_SIZE_BP);
			if (this._SparingTableLocations.Length > 4) { throw new OverflowException("Field is too large."); }
			for (int i = 0; i < this._SparingTableCount; i++)
			{ buffer.Write(this._SparingTableLocations[i], (int)SPARING_TABLE_LOCATIONS_BP + i * sizeof(uint)); }
			buffer.Initialize((int)SPARING_TABLE_LOCATIONS_BP + this._SparingTableLocations.Length, 4 - this._SparingTableLocations.Length);
		}

		protected override int MarshaledSize { get { return Marshaler.DefaultSizeOf<SparablePartitionMap>(); } }

		public override object Clone() { var me = (SparablePartitionMap)base.Clone(); me._SparingTableLocations = (uint[])me._SparingTableLocations.Clone(); return me; }
	}
}