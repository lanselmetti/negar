using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace FileSystems.Udf
{
	[StructLayout(LayoutKind.Explicit, Pack = 1)]
	public struct EntityIdentifier
	{
		public EntityIdentifier(EntityIdentifierFlags flags, string identifier) : this(flags, identifier, 0) { }
		public EntityIdentifier(EntityIdentifierFlags flags, string identifier, UdfIdentifierSuffix suffix) : this(flags, identifier, (long)suffix) { }
		public EntityIdentifier(EntityIdentifierFlags flags, string identifier, ApplicationIdentifierSuffix suffix) : this(flags, identifier, (long)suffix) { }
		public EntityIdentifier(EntityIdentifierFlags flags, string identifier, DomainIdentifierSuffix suffix) : this(flags, identifier, (long)suffix) { }
		public EntityIdentifier(EntityIdentifierFlags flags, string identifier, ImplementationIdentifierSuffix suffix) : this(flags, identifier, (long)suffix) { }

		public EntityIdentifier(EntityIdentifierFlags flags, string identifier, long suffix)
			: this()
		{
			this.Flags = flags;
			this.Suffix = suffix;
			if (identifier == null) { identifier = string.Empty; }
			if (identifier.Length > 23) { throw new ArgumentOutOfRangeException("identifier", identifier, "Identifier may only be up to 23 bytes."); }
			unsafe { fixed (byte* pID = &this.idByte01) { for (int i = 0; i < identifier.Length; i++) { pID[i] = (byte)identifier[i]; } } }
		}

		public override string ToString() { return string.Format("Identifier = \"{0}\", Flags = {1}, Suffix = 0x{2:X}", this.IdentifierToString().Trim('\0'), this.Flags, this.Suffix); }

		[FieldOffset(0)]
		public readonly EntityIdentifierFlags Flags;
		/// <summary>The ANSI identifier string.</summary>
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[FieldOffset(1)]
		private byte idByte01;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[FieldOffset(2)]
		private byte idByte02;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[FieldOffset(3)]
		private byte idByte03;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[FieldOffset(4)]
		private byte idByte04;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[FieldOffset(5)]
		private byte idByte05;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[FieldOffset(6)]
		private byte idByte06;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[FieldOffset(7)]
		private byte idByte07;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[FieldOffset(8)]
		private byte idByte08;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[FieldOffset(9)]
		private byte idByte09;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[FieldOffset(10)]
		private byte idByte10;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[FieldOffset(11)]
		private byte idByte11;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[FieldOffset(12)]
		private byte idByte12;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[FieldOffset(13)]
		private byte idByte13;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[FieldOffset(14)]
		private byte idByte14;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[FieldOffset(15)]
		private byte idByte15;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[FieldOffset(16)]
		private byte idByte16;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[FieldOffset(17)]
		private byte idByte17;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[FieldOffset(18)]
		private byte idByte18;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[FieldOffset(19)]
		private byte idByte19;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[FieldOffset(20)]
		private byte idByte20;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[FieldOffset(21)]
		private byte idByte21;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[FieldOffset(22)]
		private byte idByte22;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[FieldOffset(23)]
		private byte idByte23;
		/// <summary>The ANSI identifier suffix string.</summary>
		[FieldOffset(24)]
		public readonly long Suffix;
		[FieldOffset(24)]
		public readonly ImplementationIdentifierSuffix ImplementationSuffix;
		[FieldOffset(24)]
		public readonly UdfIdentifierSuffix UdfSuffix;
		[FieldOffset(24)]
		public readonly ApplicationIdentifierSuffix ApplicationSuffix;
		[FieldOffset(24)]
		public readonly DomainIdentifierSuffix DomainSuffix;

		[EditorBrowsable(EditorBrowsableState.Never), Obsolete("For debugger viewing only!")]
		private string Identifier { get { return this.IdentifierToString(); } }

		public string IdentifierToString() { unsafe { fixed (byte* pID = &this.idByte01) { return Marshal.PtrToStringAnsi((IntPtr)pID, 23).TrimEnd('\0'); } } }

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static readonly string ImplementationUseVolumeDescriptorImplementationId = "*UDF LV Info";
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static readonly string LogicalVolumeDescriptorDomainId = "*OSTA UDF Compliant";
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static readonly string FileSetDescriptorDomainId = "*OSTA UDF Compliant";
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static readonly string VirtualPartitionMapPartitionTypeId = "*UDF Virtual Partition";
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static readonly string SparablePartitionMapPartitionTypeId = "*UDF Sparable Partition";
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static readonly string SparingTableSparingId = "*UDF Sparing Table";
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static readonly string MetadataPartitionMapId = "*UDF Metadata Partition";
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static readonly string DeveloperId = "*Developer ID";
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct UdfIdentifierSuffix
	{
		public UdfIdentifierSuffix(long value)
		{
			unsafe
			{
				fixed (UdfIdentifierSuffix* pMe = &this)
				{
					var pMyBytes = (byte*)pMe;
					var pBytes = (byte*)&value;
					for (int i = 0; i < sizeof(long); i++)
					{ pMyBytes[i] = pBytes[i]; }
				}
			}
		}

		public UdfIdentifierSuffix(UdfRevision udfVersion, OperatingSystemClass osClass, byte osId)
			: this() { this.UdfVersion = udfVersion; this.OperatingSystemClass = osClass; this.OperatingSystemIdentifier = osId; }

		public readonly UdfRevision UdfVersion;
		public readonly OperatingSystemClass OperatingSystemClass;
		public readonly byte OperatingSystemIdentifier;
		public readonly byte Byte5;
		public readonly byte Byte6;
		public readonly byte Byte7;
		public readonly byte Byte8;

		public static explicit operator UdfIdentifierSuffix(long value) { return new UdfIdentifierSuffix(value); }
		public static explicit operator long(UdfIdentifierSuffix value)
		{
			unsafe
			{
				long result;
				var pValueBytes = (byte*)&value;
				var pResultBytes = (byte*)&result;
				for (int i = 0; i < sizeof(long); i++)
				{ pResultBytes[i] = pValueBytes[i]; }
				return result;
			}
		}

		public override bool Equals(object obj) { return obj is UdfIdentifierSuffix && this.Equals((UdfIdentifierSuffix)obj); }
		public override int GetHashCode() { return ((long)this).GetHashCode(); }
		public bool Equals(UdfIdentifierSuffix other) { return (long)this == (long)other; }
		public static bool operator ==(UdfIdentifierSuffix left, UdfIdentifierSuffix right) { return left.Equals(right); }
		public static bool operator !=(UdfIdentifierSuffix left, UdfIdentifierSuffix right) { return !left.Equals(right); }
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct ApplicationIdentifierSuffix
	{
		public ApplicationIdentifierSuffix(long value) { this.ApplicationUse = value; }
		public readonly long ApplicationUse;
		public static explicit operator ApplicationIdentifierSuffix(long value) { return new ApplicationIdentifierSuffix(value); }
		public static explicit operator long(ApplicationIdentifierSuffix value) { return value.ApplicationUse; }

		public override bool Equals(object obj) { return obj is ApplicationIdentifierSuffix && this.Equals((ApplicationIdentifierSuffix)obj); }
		public override int GetHashCode() { return ((long)this).GetHashCode(); }
		public bool Equals(ApplicationIdentifierSuffix other) { return (long)this == (long)other; }
		public static bool operator ==(ApplicationIdentifierSuffix left, ApplicationIdentifierSuffix right) { return left.Equals(right); }
		public static bool operator !=(ApplicationIdentifierSuffix left, ApplicationIdentifierSuffix right) { return !left.Equals(right); }
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct ImplementationIdentifierSuffix
	{
		public ImplementationIdentifierSuffix(long value)
		{
			unsafe
			{
				fixed (ImplementationIdentifierSuffix* pMe = &this)
				{
					var pMyBytes = (byte*)pMe;
					var pBytes = (byte*)&value;
					for (int i = 0; i < sizeof(long); i++)
					{ pMyBytes[i] = pBytes[i]; }
				}
			}
		}

		public ImplementationIdentifierSuffix(OperatingSystemClass osClass, byte osId)
			: this()
		{
			this.OperatingSystemClass = osClass;
			this.OperatingSystemIdentifier = osId;
		}

		public readonly OperatingSystemClass OperatingSystemClass;
		public readonly byte OperatingSystemIdentifier;
		public readonly byte Byte3;
		public readonly byte Byte4;
		public readonly byte Byte5;
		public readonly byte Byte6;
		public readonly byte Byte7;
		public readonly byte Byte8;

		public static explicit operator ImplementationIdentifierSuffix(long value) { return new ImplementationIdentifierSuffix(value); }
		public static explicit operator long(ImplementationIdentifierSuffix value)
		{
			unsafe
			{
				long result;
				var pValueBytes = (byte*)&value;
				var pResultBytes = (byte*)&result;
				for (int i = 0; i < sizeof(long); i++)
				{ pResultBytes[i] = pValueBytes[i]; }
				return result;
			}
		}

		public override bool Equals(object obj) { return obj is ImplementationIdentifierSuffix && this.Equals((ImplementationIdentifierSuffix)obj); }
		public override int GetHashCode() { return ((long)this).GetHashCode(); }
		public bool Equals(ImplementationIdentifierSuffix other) { return (long)this == (long)other; }
		public static bool operator ==(ImplementationIdentifierSuffix left, ImplementationIdentifierSuffix right) { return left.Equals(right); }
		public static bool operator !=(ImplementationIdentifierSuffix left, ImplementationIdentifierSuffix right) { return !left.Equals(right); }
	}

	[Flags]
	public enum DomainFlags : byte { None = 0, HardWriteProtect = 1 << 0, SoftWriteProtect = 1 << 1 }

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct DomainIdentifierSuffix
	{
		public DomainIdentifierSuffix(long value)
		{
			unsafe
			{
				fixed (DomainIdentifierSuffix* pMe = &this)
				{
					var pMyBytes = (byte*)pMe;
					var pBytes = (byte*)&value;
					for (int i = 0; i < sizeof(long); i++)
					{ pMyBytes[i] = pBytes[i]; }
				}
			}
		}

		public DomainIdentifierSuffix(UdfRevision udfVersion, DomainFlags flags)
			: this() { this.UdfVersion = udfVersion; this.Flags = flags; }

		public readonly UdfRevision UdfVersion;
		public readonly DomainFlags Flags;
		public readonly byte Byte4;
		public readonly byte Byte5;
		public readonly byte Byte6;
		public readonly byte Byte7;
		public readonly byte Byte8;

		public static explicit operator DomainIdentifierSuffix(long value) { return new DomainIdentifierSuffix(value); }
		public static explicit operator long(DomainIdentifierSuffix value)
		{
			unsafe
			{
				long result;
				var pValueBytes = (byte*)&value;
				var pResultBytes = (byte*)&result;
				for (int i = 0; i < sizeof(long); i++)
				{ pResultBytes[i] = pValueBytes[i]; }
				return result;
			}
		}

		public override bool Equals(object obj) { return obj is DomainIdentifierSuffix && this.Equals((DomainIdentifierSuffix)obj); }
		public override int GetHashCode() { return ((long)this).GetHashCode(); }
		public bool Equals(DomainIdentifierSuffix other) { return (long)this == (long)other; }
		public static bool operator ==(DomainIdentifierSuffix left, DomainIdentifierSuffix right) { return left.Equals(right); }
		public static bool operator !=(DomainIdentifierSuffix left, DomainIdentifierSuffix right) { return !left.Equals(right); }
	}

	public enum OperatingSystemClass : byte { None = 0, Dos = 1, OS2 = 2, Macintosh = 3, Unix = 4, Windows9x = 5, WindowsNT = 6, OS400 = 7, BeOS = 8, WindowsCE = 9 }

	[Flags]
	public enum EntityIdentifierFlags : byte { None = 0, Dirty = 1 << 0, WriteProtected = 1 << 1 }
}