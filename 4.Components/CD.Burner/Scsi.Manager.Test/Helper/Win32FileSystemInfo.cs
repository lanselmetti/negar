using System;
using System.Collections.Generic;
using System.IO;
using System.Security.AccessControl;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Globalization;

namespace Helper.IO
{
	public abstract class Win32FileSystemInfo : IFileSystemInfo
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected static readonly TextInfo CurrentTextInfo = System.Globalization.CultureInfo.CurrentCulture.TextInfo;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly FileSystemInfo INVALID_INFO = new FileSystemInfo(null, -1, -1, -1, -1, 0, false, -1, -1);
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected static readonly string DIR_SEP_STRING = Path.DirectorySeparatorChar.ToString();
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected static readonly char[] DIR_SEP_CHARS = new char[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar };

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private IDirectoryInfo _Parent;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal FileSystemInfo _Info = INVALID_INFO;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal bool infoValid;
		[DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
		private string _FullPathInternal;
		private string name;
		private string parentPath;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected FileSystemInfo Info { get { if (!this.infoValid) { this.Refresh(); } return this._Info; } }

		protected Win32FileSystemInfo(string fullName) { if (!Path.IsPathRooted(fullName)) { throw new ArgumentException("The given path must be absolute.", "fullName"); } this._FullPathInternal = fullName; }

		protected Win32FileSystemInfo(string parentPath, string myName) { if (!Path.IsPathRooted(parentPath)) { throw new ArgumentException("The given path must be absolute.", "fullName"); } this.parentPath = parentPath; this.name = myName; }

		public FileAttributes Attributes { get { return this.Info.Attributes; } set { using (var fs = this.Open(Win32FileAccess.WriteAttributes | Win32FileAccess.Synchronize, FileShare.ReadWrite, WinNTFileOptions.None | WinNTFileOptions.SynchronousIoNonalert, FileCreationDisposition.Open, true)) { fs.Attributes = value; this._Info.Attributes = value; } } }
		public DateTime CreationTime { get { return DateTime.FromFileTime(this.Info.CreationTime); } set { using (var fs = this.Open(Win32FileAccess.WriteAttributes | Win32FileAccess.Synchronize, FileShare.ReadWrite, WinNTFileOptions.None | WinNTFileOptions.SynchronousIoNonalert, FileCreationDisposition.Open, true)) { fs.CreationTime = value; this._Info.CreationTime = value.ToFileTime(); } } }
		public virtual void Delete() { throw new NotSupportedException("This operation is dangerous and not supported."); /*this.infoValid = false; Win32FileStream.NtDeleteFile(null, this.fullPath, true);*/ }
		public bool Exists { get { return this.Info.Exists; } }
		public string Extension { get { return Path.GetExtension(this.Name); } }
		public string FullName { get { return this.FullPathInternal.TrimEnd(DIR_SEP_CHARS); } }
		public long IndexNumber { get { return this.Info.IndexNumber; } }
		public DateTime LastAccessTime { get { return DateTime.FromFileTime(this.Info.LastAccessTime); } set { using (var fs = this.Open(Win32FileAccess.WriteAttributes | Win32FileAccess.Synchronize, FileShare.ReadWrite, WinNTFileOptions.None | WinNTFileOptions.SynchronousIoNonalert, FileCreationDisposition.Open, true)) { fs.LastAccessTime = value; this._Info.LastAccessTime = value.ToFileTime(); } } }
		public DateTime LastWriteTime { get { return DateTime.FromFileTime(this.Info.LastWriteTime); } set { using (var fs = this.Open(Win32FileAccess.WriteAttributes | Win32FileAccess.Synchronize, FileShare.ReadWrite, WinNTFileOptions.None | WinNTFileOptions.SynchronousIoNonalert, FileCreationDisposition.Open, true)) { fs.LastWriteTime = value; this._Info.LastWriteTime = value.ToFileTime(); } } }
		public string Name { get { if (this.name == null) { this.name = GetName(this.FullPathInternal); } return this.name; } }
		protected string FullPathInternal
		{
			get
			{
				if (this._FullPathInternal == null)
				{
					this._FullPathInternal = PathCombine(this.parentPath, this.name, this is Win32FileInfo);
				}
				return this._FullPathInternal;
			}
		}

		private static string GetName(string path)
		{
			if (path != null)
			{
				int endIndexExclusive = path.Length;
				while (endIndexExclusive > 0 && (path[endIndexExclusive - 1] == Path.DirectorySeparatorChar | path[endIndexExclusive - 1] == Path.AltDirectorySeparatorChar | path[endIndexExclusive - 1] == Path.VolumeSeparatorChar))
				{ endIndexExclusive--; }
				int startIndex = endIndexExclusive - 1;
				while (startIndex >= 0)
				{
					if (path[startIndex] == Path.DirectorySeparatorChar | path[startIndex] == Path.AltDirectorySeparatorChar | path[startIndex] == Path.VolumeSeparatorChar)
					{
						startIndex++;
						break;
					}
					startIndex--;
				}
				if (startIndex == -1) { return string.Empty; }
				else { return path.Substring(startIndex, endIndexExclusive - startIndex); }
			}
			return path;
		}

		protected virtual Win32FileStream Open(Win32FileAccess access, FileShare share, WinNTFileOptions options, FileCreationDisposition cd, bool throwOnError) { return Win32FileStream.NtCreateFile(null, Win32FileStream.RtlDosPathNameToNtPathName(this.FullPathInternal), access, null, Win32FileAttributes.None, share, cd, options, WinNTObjectAttributes.CaseInsensitive, throwOnError); }

		public virtual void Refresh()
		{
			this._Parent = null;
			this.infoValid = false;
			try
			{
				using (var fs = this.Open(Win32FileAccess.ReadAttributes | Win32FileAccess.Synchronize, FileShare.ReadWrite, WinNTFileOptions.None | WinNTFileOptions.SynchronousIoNonalert, FileCreationDisposition.Open, true))
				{ this._Info = new FileSystemInfo(null, fs.CreationTime.ToFileTime(), fs.LastAccessTime.ToFileTime(), fs.LastWriteTime.ToFileTime(), fs.IndexNumber, fs.Attributes, true, fs.Length, fs.AllocatedSize); }
			}
			catch (DirectoryNotFoundException) { this._Info = new FileSystemInfo() { Exists = false }; }
			catch (FileNotFoundException) { this._Info = new FileSystemInfo() { Exists = false }; }
			this.infoValid = true;
		}

		public override string ToString() { return this.FullName; }

		public override bool Equals(object obj) { var asFSI = obj as Win32FileSystemInfo; return asFSI != null && asFSI.FullPathInternal == this.FullPathInternal; }

		public override int GetHashCode() { return this.FullPathInternal.GetHashCode(); }

		protected internal struct FileSystemInfo
		{
			public FileSystemInfo(Win32FileSystemInfo parent, long creationTime, long lastAccessTime, long lastWriteTime, long indexNumber, FileAttributes attributes, bool exists, long endOfFile, long allocationSize)
			{
				this.Parent = parent;
				this.CreationTime = creationTime;
				this.LastAccessTime = lastAccessTime;
				this.LastWriteTime = lastAccessTime;
				this.IndexNumber = indexNumber;
				this.Attributes = attributes;
				this.Exists = exists;
				this.EndOfFile = endOfFile;
				this.AllocationSize = allocationSize;
			}

			public long CreationTime;
			public long LastAccessTime;
			public long LastWriteTime;
			public long IndexNumber;
			public long EndOfFile;
			public long AllocationSize;
			public Win32FileSystemInfo Parent;
			public FileAttributes Attributes;
			public bool Exists;
		}

		protected static bool IsPathRooted(string path)
		{
			if (path != null)
			{
				int length = path.Length;
				if (length >= 1)
				{
					char firstChar = path[0];
					if ((firstChar == Path.DirectorySeparatorChar || firstChar == Path.AltDirectorySeparatorChar) || (length >= 2 && path[1] == Path.VolumeSeparatorChar))
					{ return true; }
				}
			}
			return false;
		}

		protected static string PathCombine(string path1, string path2, bool file)
		{
			if (path1 == null || path2 == null) { throw new ArgumentNullException((path1 == null) ? "path1" : "path2"); }
			if (path2.Length == 0) { return path1; }
			if (path1.Length == 0) { return path2; }
			if (IsPathRooted(path2)) { return path2; }
			char lastCharPath1 = path1[path1.Length - 1];
			if (lastCharPath1 != Path.DirectorySeparatorChar && lastCharPath1 != Path.AltDirectorySeparatorChar && lastCharPath1 != Path.VolumeSeparatorChar)
			{ return path1 + DIR_SEP_STRING + path2; }
			char lastCharPath2 = path2[path2.Length - 1];
			if (file)
			{
				if (lastCharPath2 != Path.DirectorySeparatorChar && lastCharPath2 != Path.AltDirectorySeparatorChar)
				{ return string.Concat(path1, path2); }
				else { return string.Concat(path1, path2.TrimEnd(DIR_SEP_CHARS)); }
			}
			else
			{
				if (lastCharPath2 == Path.DirectorySeparatorChar || lastCharPath2 == Path.AltDirectorySeparatorChar)
				{ return string.Concat(path1, path2); }
				else { return string.Concat(path1, path2.TrimEnd(DIR_SEP_CHARS)); }
			}
		}

		protected static unsafe bool IsMatch(char* pattern, int patternLength, char* str, int strLength, TextInfo textInfoIfIgnoreCase)
		{
			int strOffset = 0;
			int patternOffset = 0;
			while (pattern[patternOffset] == '?' || (textInfoIfIgnoreCase != null ? textInfoIfIgnoreCase.ToLower(str[strOffset]) == textInfoIfIgnoreCase.ToLower(pattern[patternOffset]) : str[strOffset] == pattern[patternOffset]))
			{
				if (strOffset == patternLength || patternOffset == patternLength) { return strOffset == patternLength && patternOffset == patternLength; }
				strOffset++;
				patternOffset++;
			}

			if (pattern[patternOffset] == '*')
			{
				patternOffset++;
				while (strOffset < strLength)
				{
					if (IsMatch(&pattern[patternOffset], patternLength - patternOffset, &str[strOffset], strLength - strOffset, textInfoIfIgnoreCase)) { return true; }
					else { strOffset++; }
				}
			}

			return strOffset == strLength && patternOffset == patternLength;
		}

		protected static bool IsMatch(string pattern, string @try, TextInfo textInfoIfIgnoreCase) { unsafe { fixed (char* pTry = @try) fixed (char* pPattern = pattern) { return IsMatch(pPattern, pattern.Length, pTry, @try.Length, textInfoIfIgnoreCase); } } }
	
		protected IDirectoryInfo Parent { get { if (this._Parent == null) { string path = Path.GetDirectoryName(this.FullName); this._Parent = path == null ? null : new Win32DirectoryInfo(path); } return this._Parent; } }

		public void Rename(string newName) { throw new NotImplementedException(); }
	}

	public class Win32FileInfo : Win32FileSystemInfo, IFileInfo, IComparable<Win32FileInfo>
	{
		public Win32FileInfo(string path) : base(ToFilePath(path)) { }

		internal Win32FileInfo(string parentPath, string myName) : base(parentPath, ToFilePath(myName)) { }

		public IDirectoryInfo Directory { get { return this.Parent; } }

		public string DirectoryName { get { return Path.GetDirectoryName(this.FullName); } }

		public FileSecurity GetAccessControl(AccessControlSections includeSections) { throw new NotImplementedException(); }

		public bool IsReadOnly { get { return (this.Attributes & FileAttributes.ReadOnly) != 0; } set { this.Attributes |= FileAttributes.ReadOnly; } }

		public long Length { get { return this.Info.EndOfFile; } }

		public void SetAccessControl(FileSecurity fileSecurity) { throw new NotImplementedException(); }

		public Win32FileStream Open(FileMode mode, FileAccess access, FileShare share, FileOptions options, bool bypassBuffers) { return base.Open(Win32FileStream.ConvertAccessToWin32(access), share, Win32FileStream.ConvertFileOptionsToWinNT(options) | WinNTFileOptions.NonDirectoryFile | (bypassBuffers ? WinNTFileOptions.NoIntermediateBuffering : WinNTFileOptions.None), Win32FileStream.ConvertFileModeToCreationDisposition(mode), true); }

		long IStreamSource.GetLength() { return this.Length; }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		object IStreamSource.Source { get { return this.FullName; } }

		internal static string ToFilePath(string path)
		{
			if (!string.IsNullOrEmpty(path))
			{
				if (path[path.Length - 1] == Path.DirectorySeparatorChar || path[path.Length - 1] == Path.AltDirectorySeparatorChar)
				{ path = path.TrimEnd(DIR_SEP_CHARS); }
				if (path.Length == 2 && path[1] == ':')
				{
					path = @"\\.\" + path;
				}
			}
			return path;
		}

		Stream IStreamSource.Open(FileMode mode, FileAccess access, FileShare share, FileOptions options, bool bypassBuffer) { return this.Open(mode, access, share, options, bypassBuffer); }

		public int CompareTo(Win32FileInfo other) { return string.Compare(this.FullPathInternal, other.FullPathInternal, true); }
	}

	public class Win32DirectoryInfo : Win32FileSystemInfo, IDirectoryInfo, IComparable<Win32DirectoryInfo>
	{
		public Win32DirectoryInfo(string path) : base(ToDirectoryPath(path)) { }

		internal Win32DirectoryInfo(string parentPath, string myName) : base(parentPath, myName) { }

		public void Create(DirectorySecurity directorySecurity)
		{
			if (directorySecurity != null) { throw new NotSupportedException("Directory security not supported."); }
			using (var fs = this.Open(Win32FileAccess.ReadAttributes, FileShare.ReadWrite | FileShare.Delete, WinNTFileOptions.DirectoryFile, FileCreationDisposition.Open, true)) { }
		}

		public IDirectoryInfo CreateSubdirectory(string path, DirectorySecurity directorySecurity)
		{
			if (directorySecurity != null) { throw new NotSupportedException("Directory security not supported."); }
			using (var fs = this.Open(Win32FileAccess.AddSubdirectory, FileShare.ReadWrite, WinNTFileOptions.DirectoryFile, FileCreationDisposition.OpenIf, true))
			{
				using (var subDir = Win32FileStream.NtCreateFile(fs.SafeFileHandle, path, Win32FileAccess.ReadAttributes, null, Win32FileAttributes.None, FileShare.ReadWrite | FileShare.Delete, FileCreationDisposition.OpenIf, WinNTFileOptions.DirectoryFile, WinNTObjectAttributes.CaseInsensitive, true))
				{ return new Win32DirectoryInfo(subDir.Win32PathName); }
			}
		}

		public void Delete(bool recursive)
		{
			throw new NotSupportedException("This operation is dangerous and not supported.");
			/*
			if (!recursive) { base.Delete(); }
			else
			{
				var infos = this.GetFileSystemInfos(null);
				foreach (var info in infos)
				{
					var asDir = info as IDirectoryInfo;
					if (asDir != null) { asDir.Delete(recursive); }
					else { info.Delete(); }
				}
				this.Delete();
			}
			*/
		}

		public DirectorySecurity GetAccessControl(AccessControlSections includeSections) { throw new NotImplementedException(); }

		public Win32DirectoryInfo[] GetDirectories(string searchPattern, SearchOption searchOption)
		{
			var arr = new List<Win32DirectoryInfo>();
			IntPtr pBufferHGlobal = IntPtr.Zero; int bufferSizeHint = 0;
			if (searchOption == SearchOption.AllDirectories)
			{
				var queue = new Queue<Win32DirectoryInfo>();
				queue.Enqueue(this);
				GetFileSystemInfosListRecursive(queue, null, searchPattern, false, arr, ref pBufferHGlobal, ref bufferSizeHint, true);
			}
			else { this.GetFileSystemInfosList(searchPattern, false, arr, ref pBufferHGlobal, ref bufferSizeHint); }
			return arr.ToArray();
		}

		public Win32FileInfo[] GetFiles(string searchPattern, SearchOption searchOption)
		{
			var arr = new List<Win32FileInfo>();
			IntPtr pBufferHGlobal = IntPtr.Zero; int bufferSizeHint = 0;
			if (searchOption == SearchOption.AllDirectories)
			{
				var queue = new Queue<Win32DirectoryInfo>();
				queue.Enqueue(this);
				GetFileSystemInfosListRecursive(queue, null, searchPattern, true, arr, ref pBufferHGlobal, ref bufferSizeHint, true);
			}
			else { this.GetFileSystemInfosList(searchPattern, true, arr, ref pBufferHGlobal, ref bufferSizeHint); }
			return arr.ToArray();
		}

		public Win32FileSystemInfo[] GetFileSystemInfos(string searchPattern, SearchOption searchOption)
		{
			int bufferSize = 0x80000;
			IntPtr pBufferHGlobal = Marshal.AllocHGlobal(bufferSize);
			try { return this.GetFileSystemInfos(searchPattern, searchOption, ref pBufferHGlobal, ref bufferSize); }
			finally { Marshal.FreeHGlobal(pBufferHGlobal); }
		}

		public Win32FileSystemInfo[] GetFileSystemInfos(string searchPattern, SearchOption searchOption, ref IntPtr pBufferHGlobal, ref int bufferSizeHint)
		{
			var arr = new List<Win32FileSystemInfo>();
			if (searchOption == SearchOption.AllDirectories)
			{
				var queue = new Queue<Win32DirectoryInfo>();
				queue.Enqueue(this);
				GetFileSystemInfosListRecursive(queue, null, searchPattern, null, arr, ref pBufferHGlobal, ref bufferSizeHint, true);
			}
			else { this.GetFileSystemInfosList(searchPattern, null, arr, ref pBufferHGlobal, ref bufferSizeHint); }
			return arr.ToArray();
		}

		public SortedDictionary<Win32DirectoryInfo, Win32FileInfo[]> GetFileSystemHierarchy(string fileSearchPattern) { var dic = new SortedDictionary<Win32DirectoryInfo, Win32FileInfo[]>(); int bufferSize = 0x80000; IntPtr pBufferHGlobal = Marshal.AllocHGlobal(bufferSize); try { this.GetFileSystemHierarchy(fileSearchPattern, dic, ref pBufferHGlobal, ref bufferSize, false); } finally { Marshal.FreeHGlobal(pBufferHGlobal); } return dic; }

		public void GetFileSystemHierarchy(string fileSearchPattern, IDictionary<Win32DirectoryInfo, Win32FileInfo[]> hierarchy, ref IntPtr pBufferHGlobal, ref int bufferSizeHint, bool includeReparse)
		{
			var queue = new Queue<Win32DirectoryInfo>();
			queue.Enqueue(this);
			GetFileSystemInfosListRecursive(queue, fileSearchPattern, hierarchy, ref pBufferHGlobal, ref bufferSizeHint, includeReparse);
		}

		private void GetFileSystemInfosList<TFSInfo>(string searchPattern, bool? file, List<TFSInfo> arr, ref IntPtr pBufferHGlobal, ref int bufferSizeHint)
			where TFSInfo : Win32FileSystemInfo
		{
			var fileInfos = new List<FileIdBothDirInformation>();
			Win32FileStream.GetFileIdBothDirInfos(this.FullPathInternal, searchPattern, fileInfos, ref pBufferHGlobal, ref bufferSizeHint, false);
			int iFileNames = 0;
			while (iFileNames < fileInfos.Count && fileInfos[iFileNames].FileName == "." | fileInfos[iFileNames].FileName == "..") { iFileNames++; }
			if (arr.Capacity < fileInfos.Count - iFileNames) { arr.Capacity = fileInfos.Count - iFileNames; }
			while (iFileNames < fileInfos.Count)
			{
				if (fileInfos[iFileNames].FileName != "." && fileInfos[iFileNames].FileName != "..")
				{
					var info = fileInfos[iFileNames];
					bool isDir = (info.FileAttributes & Win32FileAttributes.Directory) != 0;
					if (file == null || (file == !isDir))
					{
						var item = isDir ? new Win32DirectoryInfo(this.FullPathInternal, info.FileName) : (Win32FileSystemInfo)new Win32FileInfo(this.FullPathInternal, info.FileName);
						item._Info = new FileSystemInfo(this, info.CreationTime, info.LastAccessTime, info.LastWriteTime, info.FileId, (FileAttributes)info.FileAttributes, true, info.EndOfFile, info.AllocationSize);
						item.infoValid = true;

						arr.Add((TFSInfo)(Win32FileSystemInfo)item);
					}
				}
				iFileNames++;
			}
		}

		private static void GetFileSystemInfosListRecursive<TFSInfo>(Queue<Win32DirectoryInfo> Queue, List<FileIdBothDirInformation> buffer, string searchPattern, bool? file, List<TFSInfo> arr, ref IntPtr pBufferHGlobal, ref int bufferSizeHint, bool includeReparse)
			where TFSInfo : Win32FileSystemInfo
		{
			if (buffer == null) { buffer = new List<FileIdBothDirInformation>(64); }
			while (Queue.Count > 0)
			{
				buffer.Clear();
				
				var next = Queue.Dequeue();
				Win32FileStream.GetFileIdBothDirInfos(next.FullPathInternal, null, buffer, ref pBufferHGlobal, ref bufferSizeHint, false);
				int iFileNames = 0;
				while (iFileNames < buffer.Count && buffer[iFileNames].FileName == "." | buffer[iFileNames].FileName == "..") { iFileNames++; }
				while (iFileNames < buffer.Count)
				{
					var info = buffer[iFileNames];

					bool isDir = (info.FileAttributes & Win32FileAttributes.Directory) != 0;
					if (file == null || (file == !isDir))
					{
						if (searchPattern == null || IsMatch(info.FileName, searchPattern, CurrentTextInfo))
						{
							var item = isDir ? new Win32DirectoryInfo(next.FullPathInternal, info.FileName) : (Win32FileSystemInfo)new Win32FileInfo(next.FullPathInternal, info.FileName);
							item._Info = new FileSystemInfo(next, info.CreationTime, info.LastAccessTime, info.LastWriteTime, info.FileId, (FileAttributes)info.FileAttributes, true, info.EndOfFile, info.AllocationSize);
							item.infoValid = true;
							arr.Add((TFSInfo)(Win32FileSystemInfo)item);
						}
					}

					if ((info.FileAttributes & Win32FileAttributes.Directory) != 0 && (includeReparse || (info.FileAttributes & Win32FileAttributes.ReparsePoint) == 0))
					{ Queue.Enqueue(new Win32DirectoryInfo(next.FullPathInternal, info.FileName)); }
					iFileNames++;
				}
			}
		}

		private static long GetFileSystemInfosListRecursive(Queue<Win32DirectoryInfo> Queue, string searchPattern, IDictionary<Win32DirectoryInfo, Win32FileInfo[]> hierarchy, ref IntPtr pBufferHGlobal, ref int bufferSizeHint, bool includeReparse)
		{
			long fileCount = 0;
			var infos = new List<FileIdBothDirInformation>(64);
			var files = new List<Win32FileInfo>(64);
			while (Queue.Count > 0)
			{
				infos.Clear();
				files.Clear();

				var next = Queue.Dequeue();

				Win32FileStream.GetFileIdBothDirInfos(next.FullPathInternal, null, infos, ref pBufferHGlobal, ref bufferSizeHint, false);
				int iFileNames = 0;
				while (iFileNames < infos.Count && infos[iFileNames].FileName == "." | infos[iFileNames].FileName == "..") { iFileNames++; }
				while (iFileNames < infos.Count)
				{
					var info = infos[iFileNames];
					if (includeReparse || (info.FileAttributes & Win32FileAttributes.ReparsePoint) == 0)
					{
						bool isDir = (info.FileAttributes & Win32FileAttributes.Directory) != 0;
						if (!isDir)
						{
							fileCount++;
							if (searchPattern == null || IsMatch(info.FileName, searchPattern, CurrentTextInfo))
							{
								var item = new Win32FileInfo(next.FullPathInternal, info.FileName);
								item._Info = new FileSystemInfo(next, info.CreationTime, info.LastAccessTime, info.LastWriteTime, info.FileId, (FileAttributes)info.FileAttributes, true, info.EndOfFile, info.AllocationSize);
								item.infoValid = true;
								files.Add(item);
							}
						}
						else
						{ Queue.Enqueue(new Win32DirectoryInfo(next.FullPathInternal, info.FileName)); }
					}
					iFileNames++;
				}

				hierarchy.Add(next, files.ToArray());
			}
			return fileCount;
		}

		protected override Win32FileStream Open(Win32FileAccess access, FileShare share, WinNTFileOptions options, FileCreationDisposition cd, bool throwOnError)
		{
			options |= WinNTFileOptions.DirectoryFile;
			if ((options & (WinNTFileOptions.SynchronousIoNonalert | WinNTFileOptions.SynchronousIoAlert)) == 0) { options |= WinNTFileOptions.SynchronousIoNonalert; }
			access |= Win32FileAccess.Synchronize;
			return base.Open(access, share, options, cd, throwOnError);
		}

		public new IDirectoryInfo Parent { get { return base.Parent; } }

		public IDirectoryInfo Root { get { return new Win32DirectoryInfo(Path.GetPathRoot(this.FullName)); } }

		public void SetAccessControl(DirectorySecurity directorySecurity) { throw new NotImplementedException(); }

		internal static string ToDirectoryPath(string path)
		{
			if (!string.IsNullOrEmpty(path))
			{
				if (path[path.Length - 1] != Path.DirectorySeparatorChar && path[path.Length - 1] != Path.AltDirectorySeparatorChar)
				{ path = path + DIR_SEP_STRING; }
			}
			return path;
		}

		public int CompareTo(Win32DirectoryInfo other) { return string.Compare(this.FullPathInternal, other.FullPathInternal, true); }


		IDirectoryInfo[] IDirectoryInfo.GetDirectories(string searchPattern, SearchOption searchOption) { return this.GetDirectories(searchPattern, searchOption); }

		IFileInfo[] IDirectoryInfo.GetFiles(string searchPattern, SearchOption searchOption) { return this.GetFiles(searchPattern, searchOption); }

		IFileSystemInfo[] IDirectoryInfo.GetFileSystemInfos(string searchPattern, SearchOption searchOption) { return this.GetFileSystemInfos(searchPattern, searchOption); }
	}
}