using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace FileSystems.Udf
{
	[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
	public class BootDescriptor : UdfVolumeStructureDescriptor
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr RESERVED1_BP = (IntPtr)7; //Marshal.OffsetOf(typeof(BootDescriptor), "_Reserved1");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr ARCHITECTURE_TYPE_BP = (IntPtr)8; //Marshal.OffsetOf(typeof(BootDescriptor), "_ArchitectureType");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr BOOT_IDENTIFIER_BP = (IntPtr)40; //Marshal.OffsetOf(typeof(BootDescriptor), "_BootIdentifier");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr BOOT_EXTENT_LOCATION_BP = (IntPtr)72; //Marshal.OffsetOf(typeof(BootDescriptor), "_BootExtentLocation");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr BOOT_EXTENT_LENGTH_BP = (IntPtr)76; //Marshal.OffsetOf(typeof(BootDescriptor), "_BootExtentLength");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr LOAD_ADDRESS_BP = (IntPtr)80; //Marshal.OffsetOf(typeof(BootDescriptor), "_LoadAddress");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr START_ADDRESS_BP = (IntPtr)88; //Marshal.OffsetOf(typeof(BootDescriptor), "_StartAddress");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr DESCRIPTOR_CREATION_TIME_BP = (IntPtr)96; //Marshal.OffsetOf(typeof(BootDescriptor), "_DescriptorCreationTime");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr FLAGS_BP = (IntPtr)108; //Marshal.OffsetOf(typeof(BootDescriptor), "_Flags");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr RESERVED2_BP = (IntPtr)110; //Marshal.OffsetOf(typeof(BootDescriptor), "_Reserved2");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr BOOT_USE_BP = (IntPtr)142; //Marshal.OffsetOf(typeof(BootDescriptor), "_BootUse");

		public BootDescriptor() : base("BOOT2", 1) { }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private byte _Reserved1;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EntityIdentifier _ArchitectureType;
		public EntityIdentifier ArchitectureType { get { return this._ArchitectureType; } set { this._ArchitectureType = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EntityIdentifier _BootIdentifier;
		public EntityIdentifier BootIdentifier { get { return this._BootIdentifier; } set { this._BootIdentifier = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private uint _BootExtentLocation;
		public uint BootExtentLocation { get { return this._BootExtentLocation; } set { this._BootExtentLocation = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private uint _BootExtentLength;
		public uint BootExtentLength { get { return this._BootExtentLength; } set { this._BootExtentLength = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ulong _LoadAddress;
		public ulong LoadAddress { get { return this._LoadAddress; } set { this._LoadAddress = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ulong _StartAddress;
		public ulong StartAddress { get { return this._StartAddress; } set { this._StartAddress = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Timestamp _DescriptorCreationTime = (Timestamp)DateTime.Now;
		public Timestamp DescriptorCreationTime { get { return this._DescriptorCreationTime; } set { this._DescriptorCreationTime = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private BootDescriptorFlags _Flags;
		public BootDescriptorFlags Flags { get { return this._Flags; } set { this._Flags = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
		private byte[] _Reserved2 = new byte[32];
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1906)]
		private byte[] _BootUse = new byte[1906];
		public byte[] BootUse { get { return this._BootUse; } }

		protected override void MarshalFrom(BufferWithSize buffer)
		{
			base.MarshalFrom(buffer);
			this._Reserved1 = buffer.Read<byte>(RESERVED1_BP);
			this._ArchitectureType = buffer.Read<EntityIdentifier>(ARCHITECTURE_TYPE_BP);
			this._BootIdentifier = buffer.Read<EntityIdentifier>(BOOT_IDENTIFIER_BP);
			this._BootExtentLocation = buffer.Read<uint>(BOOT_EXTENT_LOCATION_BP);
			this._BootExtentLength = buffer.Read<uint>(BOOT_EXTENT_LENGTH_BP);
			this._LoadAddress = buffer.Read<ulong>(LOAD_ADDRESS_BP);
			this._StartAddress = buffer.Read<ulong>(START_ADDRESS_BP);
			this._DescriptorCreationTime = buffer.Read<Timestamp>(DESCRIPTOR_CREATION_TIME_BP);
			this._Flags = buffer.Read<BootDescriptorFlags>(FLAGS_BP);
			this._Reserved2 = new byte[32];
			buffer.CopyTo((int)RESERVED2_BP, this._Reserved2, 0, this._Reserved2.Length);
			this._BootUse = new byte[1906];
			buffer.CopyTo((int)BOOT_USE_BP, this._BootUse, 0, this._BootUse.Length);
		}

		protected override void MarshalTo(BufferWithSize buffer)
		{
			base.MarshalTo(buffer);
			buffer.Write(this._Reserved1, RESERVED1_BP);
			buffer.Write(this._ArchitectureType, ARCHITECTURE_TYPE_BP);
			buffer.Write(this._BootIdentifier, BOOT_IDENTIFIER_BP);
			buffer.Write(this._BootExtentLocation, BOOT_EXTENT_LOCATION_BP);
			buffer.Write(this._BootExtentLength, BOOT_EXTENT_LENGTH_BP);
			buffer.Write(this._LoadAddress, LOAD_ADDRESS_BP);
			buffer.Write(this._StartAddress, START_ADDRESS_BP);
			buffer.Write(this._DescriptorCreationTime, DESCRIPTOR_CREATION_TIME_BP);
			buffer.Write(this._Flags, FLAGS_BP);
			if (this._Reserved2.Length > 32) { throw new OverflowException("Field is too large."); }
			buffer.CopyFrom((int)RESERVED2_BP, this._Reserved2, 0, this._Reserved2.Length);
			buffer.Initialize((int)RESERVED2_BP + this._Reserved2.Length, 32 - this._Reserved2.Length);
			if (this._BootUse.Length > 1906) { throw new OverflowException("Field is too large."); }
			buffer.CopyFrom((int)BOOT_USE_BP, this._BootUse, 0, this._BootUse.Length);
			buffer.Initialize((int)BOOT_USE_BP + this._BootUse.Length, 1906 - this._BootUse.Length);
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected override int MarshaledSize { get { return Marshaler.DefaultSizeOf<BootDescriptor>(); } }
	}

	[Flags]
	public enum BootDescriptorFlags : short { None = 0, Erase = 1 << 0 }
}