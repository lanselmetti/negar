using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace FileSystems.Udf
{
	[StructLayout(LayoutKind.Sequential, Size = 64, Pack = 1)]
	public struct CharacterSpecification : IEquatable<CharacterSpecification>
	{
		public CharacterSpecification(byte charSetType, string charSetInfo)
			: this()
		{
			this.CharacterSetType = charSetType;
			if (charSetInfo == null) { charSetInfo = string.Empty; }
			if (charSetInfo.Length > 63) { throw new ArgumentOutOfRangeException("charSetInfo", charSetInfo, "Character set information may only be up to 63 bytes."); }
			unsafe { fixed (byte* pCharSetInfo = &this.byte1) { for (int i = 0; i < charSetInfo.Length; i++) { pCharSetInfo[i] = (byte)charSetInfo[i]; } } }
		}

		public readonly byte CharacterSetType;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private byte byte1;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private short byte2;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int byte4;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private long byte9;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Guid byte17;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Guid byte33;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Guid byte49;

		public override string ToString()
		{
			unsafe
			{
				fixed (byte* pChars = &this.byte1)
				{
					int length = 0;
					while (length < 63 && pChars[length] != 0) { length++; }
					return Marshal.PtrToStringAnsi((IntPtr)pChars, length);
				}
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static readonly CharacterSpecification OstaCompressedUnicode = new CharacterSpecification(0, @"OSTA Compressed Unicode");

		public bool Equals(CharacterSpecification other)
		{
			unsafe
			{
				fixed (CharacterSpecification* pMe = &this)
				{
					var pOther = (byte*)&other;
					var pMeBytes = (byte*)pMe;
					for (int i = 0; i < sizeof(CharacterSpecification); i++)
					{ if (pMeBytes[i] != pOther[i]) { return false; } }
				}
			}
			return true;
		}

		public override bool Equals(object obj) { return obj is CharacterSpecification && this.Equals((CharacterSpecification)obj); }

		public override int GetHashCode()
		{
			unsafe
			{
				int hashCode = 0;
				fixed (CharacterSpecification* pMe = &this)
				{
					var pMeBytes = (int*)pMe;
					for (int i = 0; i < sizeof(CharacterSpecification) / sizeof(int) /*Our size is a multiple of 4, so it's ok*/; i++)
					{ hashCode ^= pMeBytes[i]; }
				}
				return hashCode;
			}
		}

		public static bool operator ==(CharacterSpecification left, CharacterSpecification right) { return left.Equals(right); }
		public static bool operator !=(CharacterSpecification left, CharacterSpecification right) { return !left.Equals(right); }
	}
}
