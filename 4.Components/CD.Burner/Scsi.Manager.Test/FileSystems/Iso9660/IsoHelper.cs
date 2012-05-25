using System;
using System.Collections.Generic;
using Helper;
using System.Diagnostics;

namespace FileSystems.Iso9660
{
	internal static class IsoHelper
	{
		public static uint FromBothByteOrder(ulong value)
		{
			var lower = unchecked((uint)value);
			var upper = unchecked((uint)(value >> 32));
			if (System.BitConverter.IsLittleEndian) { upper = Bits.ReverseBytes(upper); }
			else { lower = Bits.ReverseBytes(lower); }
			if (lower != upper) { throw new ArgumentException("Value is invalid.", "value"); }
			return upper;
		}

		public static ulong ToBothByteOrder(uint value) { return (ulong)value | Bits.ReverseBytes((ulong)value); }

		public static ushort FromBothByteOrder(uint value)
		{
			var lower = unchecked((ushort)value);
			var upper = unchecked((ushort)(value >> 16));
			if (System.BitConverter.IsLittleEndian) { upper = Bits.ReverseBytes(upper); }
			else { lower = Bits.ReverseBytes(lower); }
			if (lower != upper) { throw new ArgumentException("Value is invalid.", "value"); }
			return upper;
		}

		public static uint ToBothByteOrder(ushort value) { return (uint)value | Bits.ReverseBytes((uint)value); }

		public static void StringToPtrAnsi(BufferWithSize buffer, string str, int totalLength, char paddingChar)
		{
			if (str == null) { str = string.Empty; }
			for (int i = 0; i < str.Length; i++)
			{ buffer[i] = (byte)str[i]; }
			for (int i = str.Length; i < totalLength; i++)
			{ buffer[i] = (byte)paddingChar; }
		}
	}
}