using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using Helper;
using System.Reflection;
using System.Reflection.Emit;

namespace FileSystems.Udf
{
	public static class UdfHelper
	{
		private static readonly char[] INVALID_NT_CHARS = GetInvalidNtCharsSorted();
		public static Predicate<string> __IsAscii;
		
		private static bool IsAscii(string str)
		{
			if (__IsAscii == null)
			{
				var method = typeof(string).GetMethod("IsAscii", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, null, Type.EmptyTypes, null);
				var dynMethod = new DynamicMethod(method.Name, typeof(bool), new Type[] { typeof(string) }, typeof(string), true);
				var gen = dynMethod.GetILGenerator();
				gen.Emit(OpCodes.Ldarg_0);
				gen.Emit(OpCodes.Call, method);
				gen.Emit(OpCodes.Ret);
				System.Threading.Interlocked.CompareExchange(ref __IsAscii, (Predicate<string>)dynMethod.CreateDelegate(typeof(Predicate<string>)), null);
			}
			return __IsAscii(str);
		}

		private static char[] GetInvalidNtCharsSorted() { var result = Path.GetInvalidFileNameChars(); Array.Sort(result); return result; }

		public static int GetByteLength(string str) { return IsAscii(str) ? str.Length : str.Length * sizeof(char); }

		public static string DecodeOstaCompressedUnicode(BufferWithSize buffer, bool isDString)
		{
			if (buffer.Length == UIntPtr.Zero) { return string.Empty; }
			int byteLenExcludingCompressionCode = (isDString ? buffer[buffer.Length32 - 1] : buffer.Length32) - 1;
			string str;
			switch (buffer[0])
			{
				case 0:
					for (int i = 0; i < buffer.Length32; i++)
					{ if (buffer[i] != 0) { goto default; } }
					str = string.Empty;
					break;
				case 8:
					str = buffer.ToStringAnsi(1, byteLenExcludingCompressionCode);
					break;
				case 16:
					var sb = new StringBuilder(byteLenExcludingCompressionCode / sizeof(char));
					for (int i = 0; i < byteLenExcludingCompressionCode / sizeof(char); i++)
					{ sb.Append((char)(((char)buffer[1 + i * 2] << 8) | (char)buffer[2 + i * 2])); }
					//str = Encoding.BigEndianUnicode.GetString(buffer.ToArray(1, len - 1));
					str = sb.ToString();
					break;
				default:
					throw new InvalidDataException("Invalid compression type.");
			}
			return str;
		}

		public static void EncodeOstaCompressedUnicode(string str, BufferWithSize buffer, bool isDString)
		{
			if (string.IsNullOrEmpty(str)) { buffer.Initialize(); }
			else
			{
				unsafe
				{
					if (IsAscii(str))
					{
						buffer[0] = 8;
						fixed (char* pString = str)
						{
							for (int i = 0; i < str.Length; i++)
							{
								buffer[i + 1] = checked((byte)pString[i]);
							}
						}
					}
					else
					{
						buffer[0] = 16;
						fixed (char* pString = str)
						{
							for (int i = 0; i < str.Length; i++)
							{
								buffer[(i << 1) + 1] = unchecked((byte)(pString[i] >> 8));
								buffer[(i << 1) + 2] = unchecked((byte)pString[i]);
							}
						}
					}
					if (isDString) { buffer[buffer.Length32 - 1] = (byte)(GetByteLength(str) + 1); }
#if DEBUG
					Debug.Assert(str == DecodeOstaCompressedUnicode(buffer, isDString), "OSTA Encoding Problem", "Encoded data does not decode to original string.");
#endif
				}
			}
		}

		private static unsafe string UDFTransName(string udfName)
		{
			const char ILLEGAL_CHAR_MARK = '_';
			const char CRC_MARK = '#';
			const ushort EXT_SIZE = 5;
			const char PERIOD = '.';
			const char SPACE = ' ';
			const ushort MAXLEN = 255;

			char* newName = stackalloc char[MAXLEN];

			int index, newIndex = 0;
			bool needsCRC = false;
			int extIndex = 0, newExtIndex = 0;
			bool hasExt = false;
			int trailIndex = 0;
			ushort valueCRC;
			char current;
			for (index = 0; index < udfName.Length; index++)
			{
				current = udfName[index];
				if (IsIllegal(current) || !UnicodeIsPrint(current))
				{
					needsCRC = true;
					/* Replace Illegal and non-displayable chars with underscore. */
					current = ILLEGAL_CHAR_MARK;
					/* Skip any other illegal or non-displayable characters. */
					while (index + 1 < udfName.Length && (IsIllegal(udfName[index + 1]) || !UnicodeIsPrint(udfName[index + 1])))
					{ index++; }
				}
				/* Record position of extension, if one is found. */
				if (current == PERIOD && (udfName.Length - index - 1) <= EXT_SIZE)
				{
					if (udfName.Length == index + 1)
					{
						/* A trailing period is NOT an extension. */
						hasExt = false;
					}
					else
					{
						hasExt = true;
						extIndex = index;
						newExtIndex = newIndex;
					}
				}
				/* Record position of last char which is NOT period or space. */
				else if (current != PERIOD && current != SPACE)
				{
					trailIndex = newIndex;
				}
				if (newIndex < MAXLEN)
				{
					newName[newIndex++] = current;
				}
				else
				{
					needsCRC = true;
				}
			}
			/* For OS2, 95 & NT, truncate any trailing periods and\or spaces. */
			if (trailIndex != newIndex - 1)
			{
				newIndex = trailIndex + 1;
				needsCRC = true;
				hasExt = false; /* Trailing period does not make an extension. */
			}

			if (needsCRC)
			{
				char* ext = stackalloc char[EXT_SIZE];
				int localExtIndex = 0;
				if (hasExt)
				{
					int maxFilenameLen;
					/* Translate extension, and store it in ext. */
					for (index = 0; index < EXT_SIZE && extIndex + index + 1 < udfName.Length; index++)
					{
						current = udfName[extIndex + index + 1];
						if (IsIllegal(current) || !UnicodeIsPrint(current))
						{
							needsCRC = true;
							/* Replace Illegal and non-displayable chars with underscore. */
							current = ILLEGAL_CHAR_MARK;
							/* Skip any other illegal or non-displayable characters. */
							while (index + 1 < EXT_SIZE && (IsIllegal(udfName[extIndex + index + 2]) || !UnicodeIsPrint(udfName[extIndex + index + 2])))
							{ index++; }
						}
						ext[localExtIndex++] = current;
					}
					/* Truncate filename to leave room for extension and CRC. */
					maxFilenameLen = ((MAXLEN - 5) - localExtIndex - 1);
					if (newIndex > maxFilenameLen) { newIndex = maxFilenameLen; }
					else { newIndex = newExtIndex; }
				}
				else if (newIndex > MAXLEN - 5)
				{
					/*If no extension, make sure to leave room for CRC. */
					newIndex = MAXLEN - 5;
				}
				newName[newIndex++] = CRC_MARK; /* Add mark for CRC. */
				/*Calculate CRC from original filename from FileIdentifier. */
				valueCRC = Helper.Algorithms.Checksum.UnicodeChecksum(udfName);
				/* Convert 16-bits of CRC to hex characters. */
				newName[newIndex++] = (char)('0' + ((valueCRC & 0xf000) >> 12));
				newName[newIndex++] = (char)('0' + ((valueCRC & 0x0f00) >> 8));
				newName[newIndex++] = (char)('0' + ((valueCRC & 0x00f0) >> 4));
				newName[newIndex++] = (char)('0' + ((valueCRC & 0x000f)));
				/* Place a translated extension at end, if found. */
				if (hasExt)
				{
					newName[newIndex++] = PERIOD;
					for (index = 0; index < localExtIndex; index++)
					{ newName[newIndex++] = ext[index]; }
				}
			}
			return System.Runtime.InteropServices.Marshal.PtrToStringUni((IntPtr)newName, newIndex);
		}

		private static bool IsIllegal(char c) { return Array.BinarySearch(INVALID_NT_CHARS, c) >= 0; }

		private static bool UnicodeIsPrint(char c) { return true; /*TODO: Implement UnicodeIsPrint()*/ }

		public static string TranslateNtToUdfFileIdentifier(string identifier)
		{
			StringBuilder sb = null;

			bool lastCharValid = true;
			for (int i = 0; i < identifier.Length; i++)
			{
				if (IsIllegal(identifier[i]))
				{
					if (sb == null) { sb = new StringBuilder(identifier, 0, i, identifier.Length); }
					if (lastCharValid) { sb.Append('_'); }
					lastCharValid = false;
				}
				else { sb.Append(identifier[i]); lastCharValid = true; }
			}

			return sb != null ? sb.ToString() : identifier;
		}
	}
}