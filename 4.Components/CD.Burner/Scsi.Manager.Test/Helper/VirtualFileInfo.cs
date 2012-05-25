using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Security.AccessControl;

namespace Helper.IO
{
	public abstract class VirtualFileSystemInfo : IFileSystemInfo
	{
		private static readonly string SEPARATOR_STRING = Path.DirectorySeparatorChar.ToString();
		private static readonly char[] SEPARATORS = new char[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar };
		public IFileSystemInfo LinkedTarget { get; private set; }
		protected VirtualFileSystemInfo(IFileSystemInfo linked) { this.LinkedTarget = linked; if (linked == null) { this._CreationTime = this._LastAccessTime = this._LastWriteTime = DateTime.Now; this._Attributes = FileAttributes.Normal; this._Name = string.Empty; } }
		[DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
		private FileAttributes? _Attributes;
		public FileAttributes Attributes { get { return this._Attributes == null ? this.LinkedTarget.Attributes : this._Attributes.Value; } set { this._Attributes = this.LinkedTarget != null && this.LinkedTarget.Attributes == value ? (FileAttributes?)null : value; } }
		[DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
		private DateTime? _CreationTime;
		public DateTime CreationTime { get { return this._CreationTime == null ? this.LinkedTarget.CreationTime : this._CreationTime.Value; } set { this._CreationTime = this.LinkedTarget != null && this.LinkedTarget.CreationTime == value ? (DateTime?)null : value; } }
		public virtual void Delete()
		{
			if (this.Parent != null)
			{
				var parentAsVirt = this.Parent as VirtualDirectoryInfo;
				if (parentAsVirt != null) { parentAsVirt.Children.Remove(this); }
				else { throw new InvalidOperationException("Cannot change a virtual file in a non-virtual folder."); }
			} 
			this.Parent = null;
		}
		public bool Exists { get { return true; } }
		public string Extension
		{
			get
			{
				string fullName = this.FullName;
				int length = fullName.Length;
				int startIndex = length;
				while (--startIndex >= 0)
				{
					char ch = fullName[startIndex];
					if (ch == '.') { return fullName.Substring(startIndex, length - startIndex); }
					if (((ch == Path.DirectorySeparatorChar) || (ch == Path.AltDirectorySeparatorChar)) || (ch == Path.VolumeSeparatorChar)) { break; }
				}
				return string.Empty;
			}
		}
		public string FullName { get { var parent = this.Parent; if (parent == null) { string result = SEPARATOR_STRING + this.Name; return result; } else { return PathCombine(parent.FullName, this.Name); } } }
		[DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
		private long? _IndexNumber;
		public long IndexNumber { get { return this._IndexNumber == null ? this.LinkedTarget.IndexNumber : this._IndexNumber.Value; } set { this._IndexNumber = this.LinkedTarget != null && this.LinkedTarget.IndexNumber == value ? (long?)null : value; } }
		[DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
		private DateTime? _LastAccessTime;
		public DateTime LastAccessTime { get { return this._LastAccessTime == null ? this.LinkedTarget.LastAccessTime : this._LastAccessTime.Value; } set { this._LastAccessTime = this.LinkedTarget != null && this.LinkedTarget.LastAccessTime == value ? (DateTime?)null : value; } }
		[DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
		private DateTime? _LastWriteTime;
		public DateTime LastWriteTime { get { return this._LastWriteTime == null ? this.LinkedTarget.LastWriteTime : this._LastWriteTime.Value; } set { this._LastWriteTime = this.LinkedTarget != null && this.LinkedTarget.LastWriteTime == value ? (DateTime?)null : value; } }
		[DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
		private string _Name;
		public string Name { get { return this._Name == null ? this.LinkedTarget.Name : this._Name; } }
		public object Tag { get; set; }
		public virtual void Refresh() { if (this.LinkedTarget != null) { this.LinkedTarget.Refresh(); } }
		protected internal IDirectoryInfo Parent { get; internal set; }

		public static VirtualFileSystemInfo Create(IFileSystemInfo info) { var asFile = info as IFileInfo; return asFile != null ? new VirtualFileInfo(asFile) : (VirtualFileSystemInfo)new VirtualDirectoryInfo((IDirectoryInfo)info); }
		internal static IDirectoryInfo GetParent(IFileSystemInfo info) { var asVirt = info as VirtualFileSystemInfo; if (asVirt != null) { return asVirt.Parent; } else { var asFile = info as IFileInfo; return asFile != null ? asFile.Directory : ((IDirectoryInfo)info).Parent; } }

		public override string ToString() { return this.FullName; }

		protected static string PathCombine(string path1, string path2)
		{
			if (path1 == null || path2 == null) { throw new ArgumentNullException((path1 == null) ? "path1" : "path2"); }
			if (path2.Length == 0) { return path1; }
			if (path1.Length == 0) { return path2; }
			if (IsPathRooted(path2))
			{ return path2; }
			char ch = path1[path1.Length - 1];
			if (ch != Path.DirectorySeparatorChar && ch != Path.AltDirectorySeparatorChar && ch != Path.VolumeSeparatorChar)
			{ return path1 + SEPARATOR_STRING + path2; }
			return path1 + path2;
		}

		protected static bool IsPathRooted(string path)
		{
			if (path != null)
			{
				int length = path.Length;
				if ((length >= 1 && (path[0] == Path.DirectorySeparatorChar || path[0] == Path.AltDirectorySeparatorChar)) || (length >= 2 && path[1] == Path.VolumeSeparatorChar))
				{ return true; }
			}
			return false;
		}


		public void Rename(string value)
		{
			string newName = this.LinkedTarget != null && this.LinkedTarget.Name == value ? null : value;
			if (this.Parent != null)
			{
				var parentAsVirt = this.Parent as VirtualDirectoryInfo;
				if (parentAsVirt != null) { parentAsVirt.Children.ChangeKey(this, newName); }
				//else { throw new InvalidOperationException("Cannot change a virtual file in a non-virtual folder."); }
			}
			this._Name = newName;
		}
	}

	public class VirtualDirectoryInfo : VirtualFileSystemInfo, IDirectoryInfo
	{
		public class VirtualFileSystemInfoCollection : KeyedCollection<string, VirtualFileSystemInfo>
		{
			private VirtualDirectoryInfo dir;
			internal VirtualFileSystemInfoCollection(VirtualDirectoryInfo dir) : base(StringComparer.Ordinal) { this.dir = dir; }
			protected override string GetKeyForItem(VirtualFileSystemInfo item) { return item.Name; }
			protected override void ClearItems() { for (int i = 0; i < this.Count; i++) { this[i].Parent = null; } base.ClearItems(); }
			protected override void InsertItem(int index, VirtualFileSystemInfo item) { Debug.Assert(item != null); base.InsertItem(index, item); }
			protected override void RemoveItem(int index) { this[index].Parent = null; base.RemoveItem(index); }
			protected override void SetItem(int index, VirtualFileSystemInfo item) { this[index].Parent = null; base.SetItem(index, item); item.Parent = this.dir; }
			internal void ChangeKey(VirtualFileSystemInfo item, string newName) { this.ChangeItemKey(item, newName); }
		}

		//The FileSystemInfoCollection class takes care of the parent links
		private VirtualFileSystemInfoCollection _Children;
		public VirtualDirectoryInfo(IDirectoryInfo linked) : base(linked) { if (linked == null) { this._Children = new VirtualFileSystemInfoCollection(this); } }
		public new IDirectoryInfo LinkedTarget { get { return (IDirectoryInfo)base.LinkedTarget; } }
		void IDirectoryInfo.Create(DirectorySecurity directorySecurity) { throw new InvalidOperationException(); }
		public IDirectoryInfo CreateSubdirectory(string path, DirectorySecurity directorySecurity)
		{
			//When implementing, make sure to remember that, if LinkedTarget == null, then children != null; else, children may or may not be null
			throw new NotImplementedException();
		}
		public override void Delete() { this.Delete(false); }
		public void Delete(bool recursive)
		{
			if (this.Children != null)
			{
				if (this.Children.Count > 0 && !recursive) { throw new IOException("The directory is not empty."); }
				throw new NotSupportedException("Virtual directories can be removed by unlinking... implement this!");
				//this.Children.Clear(); //Be REALLY careful here not to delete the linked files!
			}

			base.Delete(); //Do NOT call this.Delete() -- that method overrides the base method to redirect here, which calls base.Delete()
		}
		public IDirectoryInfo[] GetDirectories(string searchPattern, SearchOption searchOption) { if (this.Children != null) { var items = new List<IDirectoryInfo>(this.Children.Count); foreach (var item in this.Children) { var asInfo = item as IDirectoryInfo; if (asInfo != null) { items.Add(asInfo); } } return items.ToArray(); } else { return this.LinkedTarget.GetDirectories(searchPattern, searchOption); } }
		public IFileInfo[] GetFiles(string searchPattern, SearchOption searchOption) { if (this.Children != null) { var items = new List<IFileInfo>(this.Children.Count); foreach (var item in this.Children) { var asInfo = item as IFileInfo; if (asInfo != null) { items.Add(asInfo); } } return items.ToArray(); } else { return this.LinkedTarget.GetFiles(searchPattern, searchOption); } }
		public IFileSystemInfo[] GetFileSystemInfos(string searchPattern, SearchOption searchOption)
		{
			if (this.Children != null)
			{
				if (searchOption == SearchOption.AllDirectories)
				{
					var dirs = this.GetDirectories(searchPattern, searchOption);
					var files = this.GetFiles(searchPattern, searchOption);
					var result = new IFileSystemInfo[dirs.Length + files.Length];
					Array.Copy(files, 0, result, 0, files.Length);
					Array.Copy(dirs, 0, result, files.Length, dirs.Length);
					return result;
				}
				else
				{
					var result = new VirtualFileSystemInfo[this.Children.Count];
					this.Children.CopyTo(result, 0);
					return result;
				}
			}
			else { return this.LinkedTarget.GetFileSystemInfos(searchPattern, searchOption); }
		}
		//public void MoveTo(string destDirName) { throw new NotImplementedException(); }
		IDirectoryInfo IDirectoryInfo.Parent { get { return this.Parent; } }
		public IDirectoryInfo Root { get { var dir = this.Parent; while (dir != null && dir.Parent != null) { dir = dir.Parent; } return dir; } }
		IDirectoryInfo IDirectoryInfo.Root { get { return this.Root; } }
		public VirtualFileSystemInfoCollection Children { get { return this._Children; } }

		//NOTE: If I implement these, I need to make sure to check the LinkedTarget before returning my own data!
		public DirectorySecurity GetAccessControl(AccessControlSections includeSections) { throw new NotImplementedException(); }
		public void SetAccessControl(DirectorySecurity directorySecurity) { throw new NotImplementedException(); }
	}

	public class VirtualFileInfo : VirtualFileSystemInfo, IFileInfo
	{
		private KeyValuePair<FileAccess, FileShare>? lastOpened;
		private readonly Stream _Stream;
		public VirtualFileInfo(IFileInfo linked) : base(linked) { if (linked == null) { this._Stream = new MemoryStream(); } }
		public new IFileInfo LinkedTarget { get { return (IFileInfo)base.LinkedTarget; } }
		//public IFileInfo CopyTo(string destFileName, bool overwrite) { throw new NotImplementedException(); }
		//public void Decrypt() { throw new NotImplementedException(); }
		public IDirectoryInfo Directory { get { return this.Parent; } }
		public string DirectoryName { get { return this.Directory.Name; } }
		//public void Encrypt() { throw new NotImplementedException(); }
		public bool IsReadOnly
		{
			get { return this._Stream != null ? !this._Stream.CanWrite : this.LinkedTarget.IsReadOnly; }
			set
			{
				if (this._Stream != null) { throw new NotImplementedException(); }
				else { this.LinkedTarget.IsReadOnly = value; }
			}
		}
		public long Length { get { return this._Stream != null ? this._Stream.Length : this.LinkedTarget.Length; } }
		long IStreamSource.GetLength() { return this.Length; }
		public void MoveTo(string destFileName) { throw new NotImplementedException(); }
		public Stream Open(FileMode mode, FileAccess access, FileShare share, FileOptions options, bool bypassBuffers)
		{
			if (this._Stream == null) { return this.LinkedTarget.Open(mode, access, share, options, bypassBuffers); }
			else
			{
				bool canOpen = true;
				if (this.lastOpened != null)
				{
					var last = this.lastOpened.Value;
					if ((access & FileAccess.Read) != 0) { canOpen &= (last.Value & FileShare.Read) != 0; canOpen &= (share & ToRequiredShare(last.Key)) == share; }
					if ((access & FileAccess.Write) != 0) { canOpen &= (last.Value & FileShare.Write) != 0; canOpen &= (share & ToRequiredShare(last.Key)) == share; }
				}
				if (!canOpen) { throw new IOException("File is already open and the sharing mode is incompatible."); }
				this.lastOpened = new KeyValuePair<FileAccess, FileShare>(access, share);
				return new RestrictedAccessStream(this._Stream, access, true, true);
			}
		}
		private static FileShare ToRequiredShare(FileAccess fileAccess) { FileShare result = 0; if ((fileAccess & FileAccess.Read) != 0) { result |= FileShare.Read; } if ((fileAccess & FileAccess.Write) != 0) { result |= FileShare.Write; } return result; }
		//public IFileInfo Replace(string destinationFileName, string destinationBackupFileName) { throw new NotImplementedException(); }
		//public IFileInfo Replace(string destinationFileName, string destinationBackupFileName, bool ignoreMetadataErrors) { throw new NotImplementedException(); }

		//NOTE: If I implement these, I need to make sure to check the LinkedTarget before returning my own data!
		public FileSecurity GetAccessControl(AccessControlSections includeSections) { throw new NotImplementedException(); }
		public void SetAccessControl(FileSecurity fileSecurity) { throw new NotImplementedException(); }
		object IStreamSource.Source { get { return this.LinkedTarget; } }
	}
}