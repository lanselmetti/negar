using System;
using System.IO;
using System.Diagnostics;

namespace Helper.IO
{
	public static class Streams
	{
		/// <summary>Reads a block of bytes from the stream and writes the data in a given buffer, ensuring that reading is only prematurely stopped if we have reached the end of the stream.</summary>
		[DebuggerHidden, DebuggerStepThrough]
		public static int ReadFully(this Stream stream, byte[] buffer, int bufferOffset, int length)
		{
			if (stream == null) { throw new ArgumentNullException("stream"); }
			if (buffer == null) { throw new ArgumentNullException("buffer"); }
			if (bufferOffset < 0) { throw new ArgumentOutOfRangeException("bufferOffset", bufferOffset, "Nonnegative number required."); }
			if (length < 0) { throw new ArgumentOutOfRangeException("length", length, "Nonnegative number required."); }
			int totalRead = 0;
			while (length > 0)
			{
				int read = stream.Read(buffer, bufferOffset, length);
				if (read < 0 | read > length) { throw new InvalidOperationException("Expected read amount to be nonnegative and <= the length."); }
				bufferOffset += read;
				length -= read;
				totalRead += read;
				if (read == 0) { break; }
			}
			return totalRead;
		}

		/// <summary>Reads a block of bytes from the stream and writes the data in a given buffer, throwing an exception if all the data cannot be read.</summary>
		/// <exception cref="EndOfStreamException">Reached the end of the stream before <see cref="length"/> bytes could be read.</exception>
		/// <remarks>If the stream is seekable, this function restores the stream position to what it was before the function call.</remarks>
		[DebuggerHidden, DebuggerStepThrough]
		public static void ReadExactly(this Stream stream, byte[] buffer, int bufferOffset, int length) { long prevPos = stream.CanSeek ? stream.Position : -1; int read = ReadFully(stream, buffer, bufferOffset, length); if (read != length) { if (prevPos >= 0) { stream.Position = prevPos; } throw new EndOfStreamException(); } }
	}
}

namespace System.Runtime.CompilerServices { [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Assembly)] public sealed class ExtensionAttribute : Attribute { } }