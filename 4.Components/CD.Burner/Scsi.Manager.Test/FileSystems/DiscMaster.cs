using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using Helper.IO;

namespace FileSystems
{
	public abstract class DiscMaster : IStreamSource
	{
		protected int SectorSize { get; private set; }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ProgressEventArgs progress = new ProgressEventArgs(MasterStage.None, 0, 0, string.Empty, null, null);
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected static readonly char[] PATH_SEP = new char[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar };
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private VirtualDirectoryInfo _Root = new VirtualDirectoryInfo(null);

		public DiscMaster(int sectorSize)
		{
			this.SectorSize = sectorSize;
		}

		public VirtualDirectoryInfo Root { get { return this._Root; } set { this._Root = value; } }

		protected virtual void OnBuildProgress(ProgressEventArgs e)
		{
			e.Cancel = false;
			if (this.BuildProgress != null)
			{
				this.BuildProgress(this, e);
			}
		}

		public event EventHandler<ProgressEventArgs> BuildProgress;

		protected virtual bool ReportProgress(MasterStage masterStage, string description, long completed, long total, string progressUnits, object extraInformation)
		{
			this.progress.Stage = masterStage;
			this.progress.Completed = completed;
			this.progress.Total = total;
			this.progress.ProgressUnits = progressUnits;
			this.progress.Description = description;
			this.progress.ExtraInformation = extraInformation;
			this.OnBuildProgress(this.progress);
			return !this.progress.Cancel;
		}

		public long GetLength() { long f, d, m; return this.GetLength(out f, out d, out m); }

		public abstract long GetLength(out long fileCount, out long directoryCount, out long metadataSize);

		public abstract AllocatedStream Prepare();

		/*Explicit interface implementations...*/

		Stream IStreamSource.Open(FileMode mode, FileAccess access, FileShare share, FileOptions options, bool bypassBuffers)
		{
			if (mode != FileMode.Open & mode != FileMode.OpenOrCreate) { throw new ArgumentOutOfRangeException("mode", mode, "Invalid file mode."); }
			if ((access & FileAccess.Write) != 0) { throw new ArgumentOutOfRangeException("access", access, "Cannot have write access."); }
			/*Ignore all other parameters*/
			return this.Prepare();
		}

		object IStreamSource.Source { get { return this.Root; } }
	}


	#region Helper Classes
	public enum MasterStage { None = 0, Preparing, Processing, Writing }

	public class ProgressEventArgs : CancelEventArgs
	{
		public ProgressEventArgs(MasterStage stage, long completed, long total, string progressUnits, string description, object extraInformation)
			: base() { this.Stage = stage; this.Completed = completed; this.Total = total; this.ProgressUnits = progressUnits; this.Description = description; this.ExtraInformation = extraInformation; }
		public MasterStage Stage { get; internal set; }
		public long Completed { get; internal set; }
		public long Total { get; internal set; }
		public string ProgressUnits { get; internal set; }
		public string Description { get; internal set; }
		public object ExtraInformation { get; internal set; }
	}

	internal sealed class KeyValuePairKeyComparer<TKey, TValue> : Comparer<KeyValuePair<TKey, TValue>>
	{
		private IComparer<TKey> keyComparer;
		public KeyValuePairKeyComparer(IComparer<TKey> keyComparer) { this.keyComparer = (keyComparer == null) ? Comparer<TKey>.Default : keyComparer; }
		public override int Compare(KeyValuePair<TKey, TValue> x, KeyValuePair<TKey, TValue> y) { return this.keyComparer.Compare(x.Key, y.Key); }
	}

	internal sealed class FunctorComparer<T> : Comparer<T> { private Comparison<T> c; public FunctorComparer(Comparison<T> c) { this.c = c; } public override int Compare(T x, T y) { return this.c(x, y); } }

	internal class StreamEqualityComparer : EqualityComparer<IStreamSource>, IComparer<IStreamSource>
	{
		private byte[] bufferA = new byte[1024 * 64];
		private byte[] bufferB = new byte[1024 * 64];

		public StreamEqualityComparer() : base() { }

		public override bool Equals(IStreamSource x, IStreamSource y) { return this.Compare(x, y) == 0; }
		public override int GetHashCode(IStreamSource obj) { return obj.GetLength().GetHashCode(); }

		public int Compare(IStreamSource x, IStreamSource y)
		{
			int compare;
			if (x == y) { compare = 0; }
			else
			{
				var xLen = x.GetLength();
				var yLen = y.GetLength();
				if (xLen == yLen)
				{
					compare = 0;
					using (var a = x.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite, FileOptions.None, false))
					{
						using (var b = y.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite, FileOptions.None, false))
						{
							while (compare == 0 && a.Position < xLen && b.Position < xLen)
							{
								int rA = a.ReadFully(this.bufferA, 0, this.bufferA.Length);
								int rB = b.ReadFully(this.bufferB, 0, this.bufferB.Length);
								if (rA == rB)
								{
									for (int i = 0; compare == 0 && i < rA; i++)
									{
										compare = this.bufferA[i].CompareTo(this.bufferB[i]);
									}
								}
								else { throw new InvalidOperationException(); }
							}
						}
					}
				}
				else { compare = xLen.CompareTo(yLen); }
			}
			return compare;
		}
	}

	internal class FileInfoComparer : EqualityComparer<IFileInfo>, IComparer<IFileInfo>
	{
		public override bool Equals(IFileInfo a, IFileInfo b) { return this.Compare(a, b) == 0; }

		public int Compare(IFileInfo a, IFileInfo b)
		{
			int c = a.Length.CompareTo(b.Length);
			if (c == 0) { c = a.IndexNumber.CompareTo(b.IndexNumber); }
			if (c == 0)
			{
				/*If files are on different drives, then they're different*/
				string aFullName = a.FullName;
				string aRoot;
				if (!string.IsNullOrEmpty(aFullName))
				{
					int i = aFullName.IndexOf(Path.DirectorySeparatorChar);
					if (i > 0) { aRoot = aFullName.Substring(0, i); }
					else { aRoot = null; }
				}
				else { aRoot = null; }
				string bFullName = b.FullName;
				string bRoot;
				if (!string.IsNullOrEmpty(bFullName))
				{
					int i = bFullName.IndexOf(Path.DirectorySeparatorChar);
					if (i > 0) { bRoot = bFullName.Substring(0, i); }
					else { bRoot = null; }
				}
				else { bRoot = null; }

				c = string.Compare(aRoot, bRoot, true);
			}
			return c;
		}

		public override int GetHashCode(IFileInfo obj) { return obj.Length.GetHashCode() ^ obj.IndexNumber.GetHashCode(); }
	}

	internal class UniqueStreamCollection<TValue>
	{
		private StreamEqualityComparer comparer = new StreamEqualityComparer();

		private IDictionary<long, SortedList<IStreamSource, TValue>> uniqueFiles = new Dictionary<long, SortedList<IStreamSource, TValue>>();

		public UniqueStreamCollection() { }

		public KeyValuePair<IStreamSource, TValue> TryGetValue(IStreamSource source) { KeyValuePair<IStreamSource, TValue> val; return this.TryGetValue(source, out val) ? val : default(KeyValuePair<IStreamSource, TValue>); }

		public bool TryGetValue(IStreamSource source, out KeyValuePair<IStreamSource, TValue> value)
		{
			SortedList<IStreamSource, TValue> dic;
			if (this.uniqueFiles.TryGetValue(source.GetLength(), out dic))
			{
				int iDup = dic.IndexOfKey(source);
				if (iDup >= 0)
				{
					value = new KeyValuePair<IStreamSource, TValue>(dic.Keys[iDup], dic.Values[iDup]);
					return true;
				}
			}
			value = default(KeyValuePair<IStreamSource, TValue>);
			return false;
		}

		public KeyValuePair<IStreamSource, TValue> TryAdd(IStreamSource source, TValue tag)
		{
			long len = source.GetLength();
			SortedList<IStreamSource, TValue> dic;
			if (this.uniqueFiles.TryGetValue(len, out dic))
			{
				int iDup = dic.IndexOfKey(source);
				if (iDup >= 0)
				{
					return new KeyValuePair<IStreamSource, TValue>(dic.Keys[iDup], dic.Values[iDup]);
				}
				else
				{
					dic.Add(source, tag);
					return default(KeyValuePair<IStreamSource, TValue>);
				}
			}
			else
			{
				dic = new SortedList<IStreamSource, TValue>(this.comparer);
				this.uniqueFiles.Add(len, dic);
				dic.Add(source, tag);
				return default(KeyValuePair<IStreamSource, TValue>);
			}
		}
	}

	#endregion
}