using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using Helper;
using Helper.Algorithms;

namespace FileSystems.Udf
{
	[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
	public abstract class TaggedDescriptor : IMarshalable, ICloneable, ILocatable
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected static readonly byte[] EMPTY_BYTES = new byte[0];
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal const int TAG_SIZE = 16;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr TAG_IDENTIFIER_BP = (IntPtr)0; //Marshal.OffsetOf(typeof(TaggedDescriptor), "_TagIdentifier");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr DESCRIPTOR_VERSION_BP = (IntPtr)2; //Marshal.OffsetOf(typeof(TaggedDescriptor), "_DescriptorVersion");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr TAG_CHECKSUM_BP = (IntPtr)4; //Marshal.OffsetOf(typeof(TaggedDescriptor), "_TagChecksum");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr RESERVED_BP = (IntPtr)5; //Marshal.OffsetOf(typeof(TaggedDescriptor), "_Reserved");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr TAG_SERIAL_NUMBER_BP = (IntPtr)6; //Marshal.OffsetOf(typeof(TaggedDescriptor), "_TagSerialNumber");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr DESCRIPTOR_CRC_BP = (IntPtr)8; //Marshal.OffsetOf(typeof(TaggedDescriptor), "_DescriptorCrc");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr DESCRIPTOR_CRC_LENGTH_BP = (IntPtr)10; //Marshal.OffsetOf(typeof(TaggedDescriptor), "_DescriptorCrcLength");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr TAG_LOCATION_BP = (IntPtr)12; //Marshal.OffsetOf(typeof(TaggedDescriptor), "_TagLocation");

		//MAKE SURE that the content of THIS TAG is ENTIRELY unmanaged (that means this class, not derived classes) -- that way, checksumming is a piece of cake
		protected TaggedDescriptor(DescriptorTagIdentifier id) : base() { this.TagIdentifier = id; }

		[DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
		private DescriptorTagIdentifier _TagIdentifier;
		public DescriptorTagIdentifier TagIdentifier { get { return this._TagIdentifier; } private set { this._TagIdentifier = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ushort _DescriptorVersion = 3;
		public ushort DescriptorVersion { get { return this._DescriptorVersion; } set { this._DescriptorVersion = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private byte _TagChecksum;
		/// <summary>The previous calculated tag checksum, equal to the sum modulo <c>256</c> of all bytes in the <see cref="TaggedDescriptor"/>, assuming this value is zero. Note that this does not include any fields of the subclasses, but it does include the CRC.</csummary>
		public byte TagChecksum { get { return this._TagChecksum; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private byte _Reserved;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ushort _TagSerialNumber = 0;
		public ushort TagSerialNumber { get { return this._TagSerialNumber; } set { this._TagSerialNumber = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ushort _DescriptorCrc;
		/// <summary>The previous calculated cyclic redundancy check value. Note that this value is always overwritten before storage to make the descriptor valid; its previous value is not persisted. However, changes to this value can be used to detect changes to the underlying structure.</summary>
		public ushort DescriptorCrc { get { return this._DescriptorCrc; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ushort _DescriptorCrcLength;
		/// <summary>The length of the descriptor subject to CRC checking. If zero, indicates that the marshaler will calculate the length. (This implies that CRCs must always be calculated.)</summary>
		public ushort DescriptorCrcLength { get { return this._DescriptorCrcLength; } set { this._DescriptorCrcLength = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private uint _TagLocation;
		/// <summary>The number of the logical block, within the partition the descriptor is recorded on, containing the first byte of the descriptor.</summary>
		public uint TagLocation { get { return this._TagLocation; } set { this._TagLocation = value; } }

		protected virtual bool AutomaticCyclicRedundancyCheck { get { return true; } }

		public void IncrementSerialNumber() { this.TagSerialNumber = this.GetNextSerialNumber(); }
		public ushort GetNextSerialNumber() { var serial = this.TagSerialNumber; return serial != 0 ? unchecked((ushort)(serial + 1)) : serial; }
		
		public byte CalculateHeaderChecksum()
		{
			int checksum = 0;
			unchecked
			{
				checksum += (byte)((ushort)this._TagIdentifier >> 0);
				checksum += (byte)((ushort)this._TagIdentifier >> 8);
				checksum += (byte)(this._DescriptorVersion >> 0);
				checksum += (byte)(this._DescriptorVersion >> 8);
				checksum += (byte)(this._Reserved >> 0);
				checksum += (byte)(this._TagSerialNumber >> 0);
				checksum += (byte)(this._TagSerialNumber >> 8);
				checksum += (byte)(this._DescriptorCrc >> 0);
				checksum += (byte)(this._DescriptorCrc >> 8);
				checksum += (byte)(this._DescriptorCrcLength >> 0);
				checksum += (byte)(this._DescriptorCrcLength >> 8);
				checksum += (byte)(this._TagLocation >> 0);
				checksum += (byte)(this._TagLocation >> 8);
				checksum += (byte)(this._TagLocation >> 16);
				checksum += (byte)(this._TagLocation >> 24);
			}
			return unchecked((byte)checksum);
		}

		protected virtual void MarshalFromBeforeValidate(BufferWithSize buffer)
		{
			if (this._TagIdentifier != buffer.Read<DescriptorTagIdentifier>(TAG_IDENTIFIER_BP)) { throw new InvalidDataException("The descriptor tag identifier is invalid."); }
			this._DescriptorVersion = buffer.Read<ushort>(DESCRIPTOR_VERSION_BP);
			this._TagChecksum = buffer.Read<byte>(TAG_CHECKSUM_BP);
			this._Reserved = buffer.Read<byte>(RESERVED_BP);
			this._TagSerialNumber = buffer.Read<ushort>(TAG_SERIAL_NUMBER_BP);
			this._DescriptorCrc = buffer.Read<ushort>(DESCRIPTOR_CRC_BP);
			this._DescriptorCrcLength = buffer.Read<ushort>(DESCRIPTOR_CRC_LENGTH_BP);
			this._TagLocation = buffer.Read<uint>(TAG_LOCATION_BP);
		}

		protected virtual void MarshalToBeforeValidate(BufferWithSize buffer)
		{
			buffer.Write(this._TagIdentifier, TAG_IDENTIFIER_BP);
			buffer.Write(this._DescriptorVersion, DESCRIPTOR_VERSION_BP);
			buffer.Write(this._TagChecksum, TAG_CHECKSUM_BP);
			buffer.Write(this._Reserved, RESERVED_BP);
			buffer.Write(this._TagSerialNumber, TAG_SERIAL_NUMBER_BP);
			buffer.Write(this._DescriptorCrc, DESCRIPTOR_CRC_BP);
			buffer.Write(this._DescriptorCrcLength, DESCRIPTOR_CRC_LENGTH_BP);
			buffer.Write(this._TagLocation, TAG_LOCATION_BP);
		}

		private void MarshalFrom(BufferWithSize buffer)
		{
			this.MarshalFromBeforeValidate(buffer);

			if (this.CalculateHeaderChecksum() != this._TagChecksum) { throw new InvalidDataException("Checksum failed."); }
			
			if (this.AutomaticCyclicRedundancyCheck)
			{
				var crc = Checksum.CyclicRedundancyCheck(buffer.ExtractSegment(TAG_SIZE).Address, buffer.LengthU32 - (uint)TAG_SIZE, this.DescriptorCrcLength, 0);
				if (crc != this._DescriptorCrc) { throw new InvalidDataException("Data error (cyclic redundancy check)."); }
			}
		}

		private void MarshalTo(BufferWithSize buffer)
		{
			this.MarshalToBeforeValidate(buffer);

			//HACK: This is a bad way of calculating CRC's, but it ensures that the user can set it to whatever he wants
			ushort prevCrcLen = this._DescriptorCrcLength;
			try
			{
				if (this.AutomaticCyclicRedundancyCheck)
				{
					if (prevCrcLen == 0)
					{
						this._DescriptorCrcLength = (ushort)Math.Min(this.MarshaledSize - TAG_SIZE, 0xFFFFU);
						buffer.Write(this._DescriptorCrcLength, DESCRIPTOR_CRC_LENGTH_BP);
					}
					var crc = Checksum.CyclicRedundancyCheck(buffer.ExtractSegment(TAG_SIZE).Address, buffer.LengthU32 - (uint)TAG_SIZE, this._DescriptorCrcLength, 0);
					this._DescriptorCrc = crc;
					buffer.Write(this._DescriptorCrc, DESCRIPTOR_CRC_BP);
				}

				//It's important that the checksum be calculated AFTER the CRC

				this._TagChecksum = this.CalculateHeaderChecksum();
				buffer.Write(this._TagChecksum, TAG_CHECKSUM_BP);
			}
			finally { if (prevCrcLen != 0) { this._DescriptorCrcLength = prevCrcLen; } }
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected virtual int MarshaledSize { get { return 16; } }

		[DebuggerHidden]
		void IMarshalable.MarshalFrom(BufferWithSize buffer) { this.MarshalFrom(buffer); }
		[DebuggerHidden]
		void IMarshalable.MarshalTo(BufferWithSize buffer) { this.MarshalTo(buffer); }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[DebuggerHidden]
		int IMarshalable.MarshaledSize { get { return this.MarshaledSize; } }

		public static uint ReadTagLocation(byte[] buffer, int bufferOffset) { unsafe { fixed (byte* pBuffer = &buffer[bufferOffset]) { return new BufferWithSize(pBuffer, buffer.Length - bufferOffset).Read<uint>(TAG_LOCATION_BP); } } }
		public static DescriptorTagIdentifier ReadTagId(byte[] buffer, int bufferOffset) { unsafe { fixed (byte* pBuffer = &buffer[bufferOffset]) { return new BufferWithSize(pBuffer, buffer.Length - bufferOffset).Read<DescriptorTagIdentifier>(0); } } }

		public static ushort MarshalToAndCalculateCRC(TaggedDescriptor descriptor, byte[] buffer, int bufferOffset)
		{
			int size = Marshaler.StructureToPtr(descriptor, buffer, bufferOffset);

			return Checksum.CyclicRedundancyCheck(buffer, bufferOffset, size, descriptor.DescriptorCrcLength, 0);
		}

		public virtual object Clone() { return this.MemberwiseClone(); }

		/*
		public override string ToString()
		{
			string tagID;
			switch (this.TagIdentifier)
			{
				case DescriptorTagIdentifier.PrimaryVolumeDescriptor:
					tagID = "PVD";
					break;
				case DescriptorTagIdentifier.AnchorVolumeDescriptorPointer:
					tagID = "AVDP";
					break;
				case DescriptorTagIdentifier.VolumeDescriptorPointer:
					tagID = "VDP";
					break;
				case DescriptorTagIdentifier.ImplementationUseVolumeDescriptor:
					tagID = "IUVD";
					break;
				case DescriptorTagIdentifier.PartitionDescriptor:
					tagID = "PD";
					break;
				case DescriptorTagIdentifier.LogicalVolumeDescriptor:
					tagID = "LVD";
					break;
				case DescriptorTagIdentifier.UnallocatedSpaceDescriptor:
					tagID = "USD";
					break;
				case DescriptorTagIdentifier.TerminatingDescriptor:
					tagID = "TD";
					break;
				case DescriptorTagIdentifier.LogicalVolumeIntegrityDescriptor:
					tagID = "LVID";
					break;
				case DescriptorTagIdentifier.FileSetDescriptor:
					tagID = "FSD";
					break;
				case DescriptorTagIdentifier.FileIdentifierDescriptor:
					tagID = "FID";
					break;
				case DescriptorTagIdentifier.AllocationExtentDescriptor:
					tagID = "AED";
					break;
				case DescriptorTagIdentifier.IndirectEntry:
					tagID = "IE";
					break;
				case DescriptorTagIdentifier.TerminalEntry:
					tagID = "TE";
					break;
				case DescriptorTagIdentifier.FileEntry:
					tagID = "FE";
					break;
				case DescriptorTagIdentifier.ExtendedAttributeHeaderDescriptor:
					tagID = "EAHD";
					break;
				case DescriptorTagIdentifier.UnallocatedSpaceEntry:
					tagID = "USE";
					break;
				case DescriptorTagIdentifier.SpaceBitmapDescriptor:
					tagID = "SBD";
					break;
				case DescriptorTagIdentifier.PartitionIntegrityEntry:
					tagID = "PIE";
					break;
				case DescriptorTagIdentifier.ExtendedFileEntry:
					tagID = "EFE";
					break;
				default:
					throw new InvalidOperationException();
			}

			return string.Format("{0} @ LBA 0x{1:X}", tagID, this.TagLocation);
		}
		//*/

		uint ILocatable.Location { get { return this.TagLocation; } set { this.TagLocation = value; } }
	}

	public enum DescriptorTagIdentifier : short
	{
		None = 0,
		PrimaryVolumeDescriptor = 1,
		AnchorVolumeDescriptorPointer = 2,
		VolumeDescriptorPointer = 3,
		ImplementationUseVolumeDescriptor = 4,
		PartitionDescriptor = 5,
		LogicalVolumeDescriptor = 6,
		UnallocatedSpaceDescriptor = 7,
		TerminatingDescriptor = 8,
		LogicalVolumeIntegrityDescriptor = 9,

		FileSetDescriptor = 256,
		FileIdentifierDescriptor = 257,
		AllocationExtentDescriptor = 258,
		IndirectEntry = 259,
		TerminalEntry = 260,
		FileEntry = 261,
		ExtendedAttributeHeaderDescriptor = 262,
		UnallocatedSpaceEntry = 263,
		SpaceBitmapDescriptor = 264,
		PartitionIntegrityEntry = 265,
		ExtendedFileEntry = 266,
	}
}