using System;
using System.IO;

namespace Helper.IO
{
	public interface IStreamSource
	{
		Stream Open(FileMode mode, FileAccess access, FileShare share, FileOptions options, bool bypassBuffers);
		long GetLength();
		/// <summary>Where the stream's source is. Note that this could be any type of object (or even null if the creator chooses not to expose it).</summary>
		object Source { get; }
	}

	public class MarshalableStreamSource<T> : IStreamSource
	{
		public MarshalableStreamSource(T structure, string description)
		{
			this.Source = structure;
			this.Description = description;
		}

		public override string ToString() { return this.Description != null ? this.Description : this.Source.ToString(); }

		public Stream Open(FileMode mode, FileAccess access, FileShare share, FileOptions options, bool bypassBuffers)
		{
			var buf = Marshaler.StructureToPtr(this.Source);
			return new MemoryStream(buf, 0, buf.Length, (access & FileAccess.Write) != 0, true);
		}

		public string Description { get; set; }

		public T Source { get; set; }

		public long GetLength() { return Marshaler.SizeOf(this.Source); }

		object IStreamSource.Source { get { return this.Source; } }
	}

	public class MarshalableArrayStreamSource<T> : IStreamSource
	{
		public MarshalableArrayStreamSource(T[] array, string description) { this.Source = array; this.Description = description; }

		public T[] Source { get; set; }

		public string Description { get; set; }

		public Stream Open(FileMode mode, FileAccess access, FileShare share, FileOptions options, bool bypassBuffers)
		{
			var bytes = new byte[this.GetLength()];
			int offset = 0;
			foreach (var s in Source) { offset += Marshaler.StructureToPtr(s, bytes, offset); }
			return new MemoryStream(bytes, 0, bytes.Length, (access & FileAccess.Write) != 0, true);
		}

		public override string ToString() { return this.Description != null ? this.Description : this.Source.ToString(); }

		public long GetLength() { int size = 0; foreach (var s in Source) { size += Marshaler.SizeOf(s); } return size; }

		object IStreamSource.Source { get { return this.Source; } }
	}

	public class StreamSource : IStreamSource
	{
		private Stream stream;

		public StreamSource(Stream stream) { this.stream = stream; }

		public Stream Open(FileMode mode, FileAccess access, FileShare share, FileOptions options, bool bypassBuffers)
		{
			return this.stream;
		}

		public long GetLength() { return this.stream.Length; }

		public object Source { get { return this.stream; } }
	}
}