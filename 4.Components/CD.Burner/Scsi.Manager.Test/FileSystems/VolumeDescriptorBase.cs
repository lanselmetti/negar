using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using Helper;

namespace FileSystems
{
	[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
	public abstract class VolumeStructureDescriptor : IMarshalable
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr TYPE_BP = (IntPtr)0; //Marshal.OffsetOf(typeof(VolumeDescriptorBase), "_Type");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr STANDARD_IDENTIFIER_BP = (IntPtr)1; //Marshal.OffsetOf(typeof(VolumeDescriptorBase), "_StandardIdentifier");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly IntPtr VERSION_BP = (IntPtr)6; //Marshal.OffsetOf(typeof(VolumeDescriptorBase), "_Version");

		protected VolumeStructureDescriptor(byte type, string standardIdentifier, byte version) : base() { this.Type = type; this.StandardIdentifier = standardIdentifier; this.Version = version; }

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private byte _Type;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public byte Type { get { return this._Type; } private set { this._Type = value; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
		private string _StandardIdentifier;
		public string StandardIdentifier { get { return this._StandardIdentifier; } private set { if (value == null) { value = string.Empty; } this._StandardIdentifier = value.PadRight(5, ' '); } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private byte _Version;
		public byte Version { get { return this._Version; } private set { this._Version = value; } }

		protected virtual void MarshalFrom(BufferWithSize buffer)
		{
			//base.MarshalFrom(buffer);
			this._Type = buffer.Read<byte>(TYPE_BP);
			this._StandardIdentifier = buffer.ToStringAnsi((int)STANDARD_IDENTIFIER_BP, 5).TrimEnd();
			this._Version = buffer.Read<byte>(VERSION_BP);
		}

		protected virtual void MarshalTo(BufferWithSize buffer)
		{
			//base.MarshalTo(buffer);
			buffer.Write(this._Type, TYPE_BP);
			var sidBuffer = buffer.ExtractSegment(STANDARD_IDENTIFIER_BP);
			for (int i = 0; i < this.StandardIdentifier.Length; i++)
			{ sidBuffer[i] = (byte)this.StandardIdentifier[i]; }
			for (int i = this.StandardIdentifier.Length; i < 5; i++)
			{ sidBuffer[i] = (byte)' '; }
			buffer.Write(this._Version, VERSION_BP);
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected virtual int MarshaledSize { get { return Marshaler.DefaultSizeOf<VolumeStructureDescriptor>(); } }

		[DebuggerHidden]
		void IMarshalable.MarshalFrom(BufferWithSize buffer) { this.MarshalFrom(buffer); }
		[DebuggerHidden]
		void IMarshalable.MarshalTo(BufferWithSize buffer) { this.MarshalTo(buffer); }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[DebuggerHidden]
		int IMarshalable.MarshaledSize { get { return this.MarshaledSize; } }

		public static byte ReadType(byte[] buffer, int bufferOffset) { return buffer[bufferOffset + 0]; }

		public static string ReadStandardIdentifier(byte[] buffer, int bufferOffset) { return Encoding.ASCII.GetString(buffer, bufferOffset + (int)STANDARD_IDENTIFIER_BP, 5); }
		public static byte ReadVersion(byte[] buffer, int bufferOffset) { return buffer[bufferOffset + 6]; }

		//public override string ToString() { return string.Format("{{Type = {0}, Standard ID = {1}, Version = {2}}}", this.Type, this.StandardIdentifier, this.Version); }
	}
}