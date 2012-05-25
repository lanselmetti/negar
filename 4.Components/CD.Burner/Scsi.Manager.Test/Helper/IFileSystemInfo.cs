using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.AccessControl;

namespace Helper.IO
{
	public interface IFileSystemInfo
	{
		FileAttributes Attributes { get; set; }
		DateTime CreationTime { get; set; }
		//[ComVisible(false)]
		//DateTime CreationTimeUtc { get; set; }
		void Delete();
		bool Exists { get; }
		string Extension { get; }
		string FullName { get; }
		/// <summary>The index number of the file, or <c>-1</c> if the index number cannot be returned for any reason.</summary>
		long IndexNumber { get; }
		DateTime LastAccessTime { get; set; }
		//[ComVisible(false)]
		//DateTime LastAccessTimeUtc { get; set; }
		DateTime LastWriteTime { get; set; }
		//[ComVisible(false)]
		//DateTime LastWriteTimeUtc { get; set; }
		string Name { get; }
		void Refresh();
		void Rename(string newName);
	}

	public interface IFileInfo : IFileSystemInfo, IStreamSource
	{
		//StreamWriter AppendText();
		//IFileInfo CopyTo(string destFileName);
		//IFileInfo CopyTo(string destFileName, bool overwrite);
		//Stream Create();
		//StreamWriter CreateText();
		//[ComVisible(false)]
		//void Decrypt();
		IDirectoryInfo Directory { get; }
		string DirectoryName { get; }
		//[ComVisible(false)]
		//void Encrypt();
		//FileSecurity GetAccessControl();
		FileSecurity GetAccessControl(AccessControlSections includeSections);
		bool IsReadOnly { get; set; }
		long Length { get; }
		//void MoveTo(string destFileName);
#if ISTREAMSOURCE_NOT_DEFINED
		long Length { get; }
		//Stream Open(FileMode mode);
		//Stream Open(FileMode mode, FileAccess access);
		Stream Open(FileMode mode, FileAccess access, FileShare share, FileOptions options);
#endif
		//Stream OpenRead();
		//StreamReader OpenText();
		//Stream OpenWrite();
		//[ComVisible(false)]
		//IFileInfo Replace(string destinationFileName, string destinationBackupFileName);
		//[ComVisible(false)]
		//IFileInfo Replace(string destinationFileName, string destinationBackupFileName, bool ignoreMetadataErrors);
		void SetAccessControl(FileSecurity fileSecurity);
	}

	public interface IDirectoryInfo : IFileSystemInfo
	{
		void Create(DirectorySecurity directorySecurity);
		IDirectoryInfo CreateSubdirectory(string path, DirectorySecurity directorySecurity);
		void Delete(bool recursive);
		DirectorySecurity GetAccessControl(AccessControlSections includeSections);
		IDirectoryInfo[] GetDirectories(string searchPattern, SearchOption searchOption);
		IFileInfo[] GetFiles(string searchPattern, SearchOption searchOption);
		IFileSystemInfo[] GetFileSystemInfos(string searchPattern, SearchOption searchOption);
		//void MoveTo(string destDirName);
		IDirectoryInfo Parent { get; }
		IDirectoryInfo Root { get; }
		void SetAccessControl(DirectorySecurity directorySecurity);
	}

	public static class FSInterface
	{
		public static IFileSystemInfo Wrap(FileSystemInfo info) { return info is DirectoryInfo ? (FileSystemInfoWrapper)new DirectoryInfoWrapper((DirectoryInfo)info) : new FileInfoWrapper((FileInfo)info); }
		public static IDirectoryInfo Wrap(DirectoryInfo info) { return new DirectoryInfoWrapper(info); }
		public static IFileInfo Wrap(FileInfo info) { return new FileInfoWrapper(info); }
	}

	internal abstract class FileSystemInfoWrapper : IFileSystemInfo
	{
		protected virtual FileSystemInfo Info { get; private set; }
		protected FileSystemInfoWrapper(FileSystemInfo info) { this.Info = info; }
		public override bool Equals(object obj) { if (obj == null || GetType() != obj.GetType()) { return false; } return this.Info.Equals(((FileSystemInfoWrapper)obj).Info); }
		public override int GetHashCode() { return this.Info.GetHashCode(); }
		public virtual FileAttributes Attributes { get { return this.Info.Attributes; } set { this.Info.Attributes = value; } }
		public virtual DateTime CreationTime { get { return this.Info.CreationTime; } set { this.Info.CreationTime = value; } }
		public virtual DateTime CreationTimeUtc { get { return this.Info.CreationTimeUtc; } set { this.Info.CreationTimeUtc = value; } }
		public virtual void Delete() { this.Info.Delete(); }
		public virtual bool Exists { get { return this.Info.Exists; } }
		public virtual string Extension { get { return this.Info.Extension; } }
		public virtual long IndexNumber { get { return -1; } }
		public virtual string FullName { get { return this.Info.FullName; } }
		public virtual DateTime LastAccessTime { get { return this.Info.LastAccessTime; } set { this.Info.LastAccessTime = value; } }
		public virtual DateTime LastAccessTimeUtc { get { return this.Info.LastAccessTimeUtc; } set { this.Info.LastAccessTimeUtc = value; } }
		public virtual DateTime LastWriteTime { get { return this.Info.LastWriteTime; } set { this.Info.LastWriteTime = value; } }
		public virtual DateTime LastWriteTimeUtc { get { return this.Info.LastWriteTimeUtc; } set { this.Info.LastWriteTimeUtc = value; } }
		public virtual string Name { get { return this.Info.Name; } }
		public virtual void Refresh() { this.Info.Refresh(); }
		public void Rename(string newName) { throw new NotImplementedException(); }
		public override string ToString() { return this.Info.ToString(); }

		[System.Security.SuppressUnmanagedCodeSecurity, DllImport("NTDLL.dll", ThrowOnUnmappableChar = true, BestFitMapping = false, SetLastError = false)]
		private static extern unsafe int NtQueryInformationFile([In] Microsoft.Win32.SafeHandles.SafeFileHandle FileHandle, [Out] IntPtr* IoStatusBlock, [Out] IntPtr FileInformation, [In] int Length, [In] int FileInformationClass);
		[System.Security.SuppressUnmanagedCodeSecurity, DllImport("NTDLL.dll", ThrowOnUnmappableChar = true, BestFitMapping = false, SetLastError = false)]
		private static extern int RtlNtStatusToDosError([In] int NtStatus);
		protected static long NtQueryInternalInformationFile(Microsoft.Win32.SafeHandles.SafeFileHandle handle) { long indexNumber; unsafe { IntPtr* pIOSB = stackalloc IntPtr[2]; int ntStatus = NtQueryInformationFile(handle, pIOSB, (IntPtr)(&indexNumber), sizeof(long), 6); if (ntStatus < 0) { Marshal.ThrowExceptionForHR(RtlNtStatusToDosError(ntStatus) | unchecked((int)0x80070000)); } } return indexNumber; }
	}

	internal class FileInfoWrapper : FileSystemInfoWrapper, IFileInfo
	{
		public FileInfoWrapper(FileInfo info) : base(info) { }
		public virtual IFileInfo CopyTo(string destFileName, bool overwrite) { return new FileInfoWrapper(((FileInfo)this.Info).CopyTo(destFileName, overwrite)); }
		public virtual void Decrypt() { ((FileInfo)this.Info).Decrypt(); }
		public virtual IDirectoryInfo Directory { get { return new DirectoryInfoWrapper(((FileInfo)this.Info).Directory); } }
		public virtual string DirectoryName { get { return ((FileInfo)this.Info).DirectoryName; } }
		public virtual void Encrypt() { ((FileInfo)this.Info).Encrypt(); }
		public virtual FileSecurity GetAccessControl(AccessControlSections includeSections) { return ((FileInfo)this.Info).GetAccessControl(includeSections); }
		public virtual bool IsReadOnly { get { return ((FileInfo)this.Info).IsReadOnly; } set { ((FileInfo)this.Info).IsReadOnly = value; } }
		public virtual long Length { get { return ((FileInfo)this.Info).Length; } }
		long IStreamSource.GetLength() { return this.Length; }
		public virtual void MoveTo(string destFileName) { ((FileInfo)this.Info).MoveTo(destFileName); }
		public virtual Stream Open(FileMode mode, FileAccess access, FileShare share, FileOptions options, bool bypassBuffers) { return new FileStream(this.Info.FullName, mode, access, share, 4096, options); }
		public virtual IFileInfo Replace(string destinationFileName, string destinationBackupFileName, bool ignoreMetadataErrors) { return new FileInfoWrapper(((FileInfo)this.Info).Replace(destinationFileName, destinationBackupFileName, ignoreMetadataErrors)); }
		public virtual void SetAccessControl(FileSecurity fileSecurity) { ((FileInfo)this.Info).SetAccessControl(fileSecurity); }
		public override long IndexNumber { get { if (this.Exists) { using (var me = ((FileInfo)this.Info).Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite)) { return NtQueryInternalInformationFile(me.SafeFileHandle); } } else { return base.IndexNumber; } } }

		object IStreamSource.Source { get { return this.Info; } }
	}

	internal class DirectoryInfoWrapper : FileSystemInfoWrapper, IDirectoryInfo
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly Converter<DirectoryInfo, IDirectoryInfo> DIRECTORY_INFO_CONVERTER = d => new DirectoryInfoWrapper(d);
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly Converter<FileInfo, IFileInfo> FILE_INFO_CONVERTER = d => new FileInfoWrapper(d);
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly Converter<FileSystemInfo, IFileSystemInfo> FS_INFO_CONVERTER = d => d is DirectoryInfo ? (FileSystemInfoWrapper)new DirectoryInfoWrapper((DirectoryInfo)d) : new FileInfoWrapper((FileInfo)d);
		public DirectoryInfoWrapper(DirectoryInfo info) : base(info) { }
		public virtual void Create(DirectorySecurity directorySecurity) { ((DirectoryInfo)this.Info).Create(directorySecurity); }
		public virtual IDirectoryInfo CreateSubdirectory(string path, DirectorySecurity directorySecurity) { return new DirectoryInfoWrapper(((DirectoryInfo)this.Info).CreateSubdirectory(path, directorySecurity)); }
		public virtual void Delete(bool recursive) { ((DirectoryInfo)this.Info).Delete(recursive); }
		public virtual DirectorySecurity GetAccessControl(AccessControlSections includeSections) { return ((DirectoryInfo)this.Info).GetAccessControl(includeSections); }
		public virtual IDirectoryInfo[] GetDirectories(string searchPattern, SearchOption searchOption) { if (searchPattern == null) { searchPattern = "*"; } return Array.ConvertAll(((DirectoryInfo)this.Info).GetDirectories(searchPattern, searchOption), DIRECTORY_INFO_CONVERTER); }
		public virtual IFileInfo[] GetFiles(string searchPattern, SearchOption searchOption) { if (searchPattern == null) { searchPattern = "*"; } return Array.ConvertAll(((DirectoryInfo)this.Info).GetFiles(searchPattern, searchOption), FILE_INFO_CONVERTER); }
		public virtual IFileSystemInfo[] GetFileSystemInfos(string searchPattern, SearchOption searchOption)
		{
			if (searchPattern == null) { searchPattern = "*"; }
			if (searchOption == SearchOption.AllDirectories)
			{
				var dirs = this.GetDirectories(searchPattern, searchOption);
				var files = this.GetFiles(searchPattern, searchOption);
				var result = new IFileSystemInfo[dirs.Length + files.Length];
				Array.Copy(files, 0, result, 0, files.Length);
				Array.Copy(dirs, 0, result, files.Length, dirs.Length);
				return result;
			}
			else { return Array.ConvertAll(((DirectoryInfo)this.Info).GetFileSystemInfos(searchPattern), FS_INFO_CONVERTER); }
		}
		public virtual void MoveTo(string destDirName) { ((DirectoryInfo)this.Info).MoveTo(destDirName); }
		public virtual IDirectoryInfo Parent { get { return ((DirectoryInfo)this.Info).Parent != null ? new DirectoryInfoWrapper(((DirectoryInfo)this.Info).Parent) : null; } }
		public virtual IDirectoryInfo Root { get { return ((DirectoryInfo)this.Info).Root != null ? new DirectoryInfoWrapper(((DirectoryInfo)this.Info).Root) : null; } }
		public virtual void SetAccessControl(DirectorySecurity directorySecurity) { ((DirectoryInfo)this.Info).SetAccessControl(directorySecurity); }
	}
}