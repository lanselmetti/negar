using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace FileSystems.Udf
{
	[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
	public struct PathComponent : IMarshalable
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr TYPE_BP = (IntPtr)0; //Marshal.OffsetOf(typeof(PathComponent), "Type");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr COMPONENT_IDENTIFIER_LENGTH_BP = (IntPtr)1; //Marshal.OffsetOf(typeof(PathComponent), "ComponentIdentifierLength");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr COMPONENT_FILE_VERSION_NUMBER_BP = (IntPtr)2; //Marshal.OffsetOf(typeof(PathComponent), "ComponentFileVersionNumber");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr COMPONENT_IDENTIFIER_BP = (IntPtr)4; //Marshal.OffsetOf(typeof(PathComponent), "ComponentIdentifier");

		public PathComponent(PathComponentType type, ushort version, string id)
		{
			this.Type = type;
			this.ComponentFileVersionNumber = version;
			this.ComponentIdentifierLength = checked((byte)id.Length);
			this.ComponentIdentifier = id;
		}

		public readonly PathComponentType Type;
		public readonly byte ComponentIdentifierLength;
		public readonly ushort ComponentFileVersionNumber;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
		public readonly string ComponentIdentifier;

		public void MarshalFrom(BufferWithSize buffer) { this = new PathComponent(buffer.Read<PathComponentType>(TYPE_BP), buffer.Read<byte>(ComponentIdentifierLength), buffer.ToStringAnsi((int)COMPONENT_IDENTIFIER_BP, buffer.Read<byte>(COMPONENT_IDENTIFIER_LENGTH_BP))); }

		public void MarshalTo(BufferWithSize buffer)
		{
			buffer.Write(this.Type, TYPE_BP);
			buffer.Write(this.ComponentIdentifierLength, COMPONENT_IDENTIFIER_LENGTH_BP);
			buffer.Write(this.ComponentFileVersionNumber, COMPONENT_FILE_VERSION_NUMBER_BP);

			var cidBuffer = buffer.ExtractSegment(COMPONENT_IDENTIFIER_BP);
			for (int i = 0; i < this.ComponentIdentifier.Length; i++)
			{ cidBuffer[i] = (byte)this.ComponentIdentifier[i]; }
			for (int i = this.ComponentIdentifier.Length; i < this.ComponentIdentifierLength; i++)
			{ cidBuffer[i] = (byte)' '; }
		}

		public int MarshaledSize { get { return Marshaler.DefaultSizeOf<PathComponent>() + this.ComponentIdentifierLength - 1; } }
	}

	public enum PathComponentType : byte
	{
		Root = 1,
		RootOfPredecessor = 2,
		ParentDirectoryOfPredecessor = 3,
		SameDirectoryAsPredecessor = 4,
		FileOrDirectoryOrAliasWithIdenticalIdentifier = 5,
	}

	//public enum VolumeDescriptorStandards { CD001, BEA01, BOOT2, CDW02, NSR02, NSR03, TEA01 }
}