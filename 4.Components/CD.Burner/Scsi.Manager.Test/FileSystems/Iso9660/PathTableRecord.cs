using System;
using System.Collections.Generic;
using Helper;
using System.Runtime.InteropServices;
using System.IO;
using System.Text;
using System.Diagnostics;

namespace FileSystems.Iso9660
{
	[StructLayout(LayoutKind.Sequential, Pack = 2)]
	public sealed class PathTableRecord : IMarshalable
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal static readonly IntPtr DIRECTORY_ID_OFFSET = Marshal.OffsetOf(typeof(PathTableRecord), "_DirectoryIdentifier");

		public PathTableRecord(bool bigEndian) { this._BigEndian = bigEndian; }

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private byte _DirectoryIdLength;
		internal byte DirectoryIdLength { get { return this._DirectoryIdLength; } private set { this._DirectoryIdLength = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private byte _ExtendedAttributeRecordLength;
		public byte ExtendedAttributeRecordLength { get { return this._ExtendedAttributeRecordLength; } set { this._ExtendedAttributeRecordLength = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private uint _ExtentLBA;
		public uint ExtentLBA { get { return this.BigEndian ? Bits.BigEndian(this._ExtentLBA) : Bits.LittleEndian(this._ExtentLBA); } set { this._ExtentLBA = this.BigEndian ? Bits.BigEndian(value) : Bits.LittleEndian(value); } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ushort _ParentDirectoryNumber;
		public ushort ParentDirectoryNumber { get { return this.BigEndian ? Bits.BigEndian(this._ParentDirectoryNumber) : Bits.LittleEndian(this._ParentDirectoryNumber); } set { this._ParentDirectoryNumber = this.BigEndian ? Bits.BigEndian(value) : Bits.LittleEndian(value); } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private FileSystemIdentifier _DirectoryIdentifier = new FileSystemIdentifier(null, 0); //This is a directory
		public FileSystemIdentifier DirectoryIdentifier { get { return this._DirectoryIdentifier; } set { this._DirectoryIdentifier = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[MarshalAs(UnmanagedType.I1)]
		private bool _BigEndian;
		public bool BigEndian { get { return this._BigEndian; } }

		void IMarshalable.MarshalFrom(BufferWithSize buffer)
		{
			if (buffer.Length32 < (int)DIRECTORY_ID_OFFSET + 3 /*The min size of a long File Identifier*/)
			{
				unsafe
				{
					int newSize = buffer.Length32 + 128; //Just to know it's large enough
					byte* pBuffer = stackalloc byte[newSize];
					var newBuffer = new BufferWithSize(pBuffer, newSize);
					BufferWithSize.Copy(buffer, UIntPtr.Zero, newBuffer, UIntPtr.Zero, buffer.Length);
					buffer = newBuffer;
				}
			}
			Marshaler.DefaultPtrToStructure(buffer, (object)this);
			Marshaler.PtrToStructure(buffer.ExtractSegment((byte)DIRECTORY_ID_OFFSET, this.DirectoryIdLength), ref this._DirectoryIdentifier);
		}

		void IMarshalable.MarshalTo(BufferWithSize buffer)
		{
			Marshaler.DefaultStructureToPtr((object)this, buffer);
			this.DirectoryIdLength = (byte)Marshaler.SizeOf(this.DirectoryIdentifier);
			Marshaler.StructureToPtr(this.DirectoryIdentifier, buffer.ExtractSegment((byte)DIRECTORY_ID_OFFSET, this.DirectoryIdLength));
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		int IMarshalable.MarshaledSize { get { int result = (byte)((int)DIRECTORY_ID_OFFSET + Marshaler.SizeOf(this.DirectoryIdentifier)); if ((result & 1) != 0) { result++; } return result; } }
	}
}