using System;
using System.Collections.Generic;
using Helper;
using System.Runtime.InteropServices;
using System.IO;
using System.Text;
using System.Diagnostics;

namespace FileSystems.Iso9660
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public sealed class DirectoryRecord : IMarshalable, IComparable<DirectoryRecord>
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr FILE_ID_OFFSET = Marshal.OffsetOf(typeof(DirectoryRecord), "_FileId");

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private byte _RecordLength = (byte)Marshal.SizeOf(typeof(DirectoryRecord));
		internal byte RecordLength { get { return this._RecordLength; } private set { this._RecordLength = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private byte _ExtendedAttributeLength;
		public byte ExtendedAttributeLength { get { return this._ExtendedAttributeLength; } set { this._ExtendedAttributeLength = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ulong _ExtentLBA;
		public uint ExtentLBA { get { return IsoHelper.FromBothByteOrder(this._ExtentLBA); } set { this._ExtentLBA = IsoHelper.ToBothByteOrder(value); } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ulong _DataLength;
		public uint DataLength { get { return IsoHelper.FromBothByteOrder(this._DataLength); } set { this._DataLength = IsoHelper.ToBothByteOrder(value); } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DirectoryTime _RecordingTime = (DirectoryTime)DateTime.Now;
		public DirectoryTime RecordingTime { get { return this._RecordingTime; } set { this._RecordingTime = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DirectoryRecordFlags _RecordFlags;
		public DirectoryRecordFlags RecordFlags { get { return this._RecordFlags; } set { this._RecordFlags = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private byte _FileSizeIfInterleaved;
		public byte FileSizeIfInterleaved { get { return this._FileSizeIfInterleaved; } set { this._FileSizeIfInterleaved = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private byte _InterleavedGapSize;
		public byte InterleavedGapSize { get { return this._InterleavedGapSize; } set { this._InterleavedGapSize = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private uint _VolumeSequenceNumber;
		public ushort VolumeSequenceNumber { get { return IsoHelper.FromBothByteOrder(this._VolumeSequenceNumber); } set { this._VolumeSequenceNumber = IsoHelper.ToBothByteOrder(value); } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private byte _FileIdLength;
		public byte FileIdLength { get { return this._FileIdLength; } set { this._FileIdLength = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private FileSystemIdentifier _FileId;
		public FileSystemIdentifier FileId { get { return this._FileId; } set { this._FileId = value; } }


		public void MarshalFrom(BufferWithSize buffer)
		{
			if (buffer.Length32 < (int)FILE_ID_OFFSET + 3 /*The min size of a long File Identifier*/)
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
			this.FileId = new FileSystemIdentifier(null, (short)(((this.RecordFlags & DirectoryRecordFlags.Directory) != 0) ? 0 : 1));
			Marshaler.PtrToStructure(buffer.ExtractSegment((byte)FILE_ID_OFFSET, this.FileIdLength), ref this._FileId);
		}

		public void MarshalTo(BufferWithSize buffer)
		{
			this.RecordLength = (byte)Marshaler.SizeOf(this);
			Marshaler.DefaultStructureToPtr((object)this, buffer);
			this.FileIdLength = (byte)Marshaler.SizeOf(this.FileId);
			Marshaler.StructureToPtr(this.FileId, buffer.ExtractSegment((byte)FILE_ID_OFFSET, this.FileIdLength));
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int MarshaledSize { get { int result = (byte)((int)FILE_ID_OFFSET + Marshaler.SizeOf(this.FileId)); if ((result & 1) != 0) { result++; } this.RecordLength = (byte)result; return result; } }

		public int CompareTo(DirectoryRecord other)
		{
			int result = this.FileId.CompareTo(other.FileId);
			if (result == 0) { result = other.FileId.FileVersion.CompareTo(this.FileId.FileVersion); }
			if (result == 0) { result = (((this.RecordFlags & DirectoryRecordFlags.Associated) != 0) ? 1 : 0).CompareTo((((other.RecordFlags & DirectoryRecordFlags.Associated) != 0) ? 1 : 0)); }
			if (result == 0) { result = this.ExtentLBA.CompareTo(other.ExtentLBA); }
			return result;
		}

		public static byte ReadRecordLength(byte[] buffer, int offset) { return buffer[offset]; }

		public override string ToString() { return this.FileId.ToString(); }
	}
}