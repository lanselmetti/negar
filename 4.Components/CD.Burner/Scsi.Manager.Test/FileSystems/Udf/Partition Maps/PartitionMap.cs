using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using Helper;

namespace FileSystems.Udf
{
	[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
	public abstract class PartitionMap : IMarshalable, ICloneable
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr TYPE_BP = (IntPtr)0; //Marshal.OffsetOf(typeof(PartitionMap), "_Type");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr LENGTH_BP = (IntPtr)1; //Marshal.OffsetOf(typeof(PartitionMap), "_Length");

		//Make private so only marshaler can instantiate this
		private PartitionMap() { }
		//Make protected so only subclasses can instantiate this
		protected PartitionMap(PartitionMapType type, byte length) { this.Type = type; this.Length = length; }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private PartitionMapType _Type;
		public PartitionMapType Type { get { return this._Type; } private set { this._Type = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private byte _Length;
		public byte Length { get { return this._Length; } protected set { this._Length = value; } }

		protected virtual void MarshalFrom(BufferWithSize buffer)
		{
			this._Type = buffer.Read<PartitionMapType>(TYPE_BP);
			this._Length = buffer.Read<byte>(LENGTH_BP);
		}
		
		protected virtual void MarshalTo(BufferWithSize buffer)
		{
			buffer.Write(this._Type, TYPE_BP);
			buffer.Write(this._Length, LENGTH_BP);
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected virtual int MarshaledSize { get { return Marshaler.DefaultSizeOf<PartitionMap>(); } }
		void IMarshalable.MarshalFrom(BufferWithSize buffer) { this.MarshalFrom(buffer); }
		void IMarshalable.MarshalTo(BufferWithSize buffer) { this.MarshalTo(buffer); }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		int IMarshalable.MarshaledSize { get { return this.MarshaledSize; } }

		internal static PartitionMap FromBuffer(BufferWithSize partitionMapBuffer)
		{
			switch (partitionMapBuffer.Read<PartitionMapType>())
			{
				case PartitionMapType.Type1:
					return Marshaler.PtrToStructure<Type1PartitionMap>(partitionMapBuffer);
				case PartitionMapType.Type2:
					return UdfType2PartitionMap.FromBuffer(partitionMapBuffer);
				default:
					throw new InvalidDataException("Invalid partition map type.");
			}
		}

		public virtual object Clone() { return this.MemberwiseClone(); }
	}

	public enum PartitionMapType : byte { Nonstandard = 0, Type1 = 1, Type2 = 2 }
}