using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;
using Microsoft.Win32.SafeHandles;

namespace Helper.IO
{
	//[DebuggerStepThrough]
	/// <summary>
	/// <para>
	/// A number of API functions from the Windows Driver Kit are used here, as well as some "undocumented" ones, like NtQueryObject().
	/// However, it is safe to assume that they will not change for a while, since they have been here since Windows NT up to Windows 7, and they have no particular deficiencies that would make Microsoft want to remove them.
	/// I use them because you can do some things with those functions that you can't do with the Win32 API (for example, get a file path from its handle) -- or at least, not before Vista.
	/// </para>
	/// <para>Note that this class can also represent directories as well, though its reading/writing functions won't work in that case.</para>
	/// </summary>
	/// <remarks>This class won't work for non-seekable files, e.g. the console.</remarks>
	public class Win32FileStream : Stream //Can be a directory as well!
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly int FID_SIZE = System.Runtime.InteropServices.Marshal.SizeOf(typeof(FileIdBothDirInformation));
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly int DEFAULT_NUM_FILE_ID_BOTH_DIR_INFOS = UnsafeNativeMethods.STACKALLOC_THRESHOLD / Marshal.SizeOf(typeof(FileIdBothDirInformation));
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly int DEFAULT_NUM_FILE_DIRECTORY_INFOS = UnsafeNativeMethods.STACKALLOC_THRESHOLD / Marshal.SizeOf(typeof(FileDirectoryInformation));
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly int DEFAULT_NUM_FILE_NAMES = UnsafeNativeMethods.STACKALLOC_THRESHOLD / Marshal.SizeOf(typeof(FileNamesInformation));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static unsafe IOCompletionCallback IOCompletionCallback = AsyncFSCallback;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _CanRead;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _CanWrite;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private long _Position;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SafeFileHandle _SafeFileHandle;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool modeInformationQueried;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool sizeInformationQueried;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private UnsafeNativeMethods.FileFsSizeInformation sizeInformation;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _IsSynchronous;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _NoIntermediateBuffering;

		public Win32FileStream(string path, FileAccess access) : this(path, access, FileShare.None, FileMode.OpenOrCreate, FileOptions.None) { }

		public Win32FileStream(string path, FileAccess access, FileShare share, FileMode mode, FileOptions options)
			: this(UnsafeNativeMethods.CreateFile(path, ConvertAccessToWin32(access), share, mode, ConvertFileOptionsToWin32(options)), ConvertAccessToWin32(access), false) { }

		public Win32FileStream(string path, Win32FileAccess access, FileShare share, FileMode mode, Win32FileOptions options)
			: this(UnsafeNativeMethods.CreateFile(path, access, share, mode, options), access, false) { }

		public Win32FileStream(SafeFileHandle safeFileHandle, FileAccess accessMask) : this(safeFileHandle, ConvertAccessToWin32(accessMask)) { }

		public Win32FileStream(SafeFileHandle safeFileHandle, Win32FileAccess accessMask) : this(safeFileHandle, accessMask, true) { }

		public Win32FileStream(SafeFileHandle safeFileHandle, Win32FileAccess accessMask, bool cloneHandle)
		{
			if (cloneHandle) { safeFileHandle = UnsafeNativeMethods.DuplicateHandle(safeFileHandle, accessMask, false); }
			this.SafeFileHandle = safeFileHandle;
			if (cloneHandle || (accessMask & Win32FileAccess.MaximumAllowed) != 0) { accessMask = this.AccessMask; }
			this._CanRead = (accessMask & (Win32FileAccess.ReadData | Win32FileAccess.GenericRead)) != 0;
			this._CanWrite = (accessMask & (Win32FileAccess.WriteData | Win32FileAccess.GenericWrite)) != 0;
			//if (!ThreadPool.BindHandle(safeFileHandle)) { throw new IOException("BindHandle for ThreadPool failed on this handle."); }
		}

		#region Async Result
		private sealed class AsyncResult : IAsyncResult
		{
			private bool _IsComplete;
			public AsyncResult(SafeFileHandle handle, byte[] userBuffer, int userBufferOffset, int length, object state, AsyncCallback userCallback, bool write)
			{
				this.AsyncWaitHandle = new ManualResetEvent(false);
				this.AsyncState = state;
				this.UserCallback = userCallback;
				this.UserBuffer = userBuffer;
				this.UserBufferOffset = userBufferOffset;
				this.Length = length;
				this.SafeFileHandle = handle;
				this.Write = write;
			}
			public AsyncCallback UserCallback { get; private set; }
			public object AsyncState { get; private set; }
			public ManualResetEvent AsyncWaitHandle { get; private set; }
			public bool CompletedSynchronously { get; internal set; }
			public bool IsCompleted { get { return this._IsComplete || this.CompletedSynchronously || this.AsyncWaitHandle.WaitOne(0, false); } internal set { this._IsComplete = value; } }
			public unsafe NativeOverlapped* Overlapped { get; internal set; }
			public byte[] UserBuffer { get; private set; }
			public int UserBufferOffset { get; private set; }
			public int Length { get; private set; }
			public int OffsetInHGlobalBufferDueToAlignment { get; internal set; }
			public IntPtr HGlobalBufferAddress { get; internal set; }
			public IntPtr HGlobalBufferLength { get; internal set; }
			public SafeFileHandle SafeFileHandle { get; private set; }
			WaitHandle IAsyncResult.AsyncWaitHandle { get { return this.AsyncWaitHandle; } }
			public bool Write { get; private set; }
			public int ErrorCode { get; set; }
		}
		#endregion

		#region Properties
		public Win32FileAccess AccessMask { get { return (Win32FileAccess)UnsafeNativeMethods.NtQueryObjectAccessMask(this.SafeFileHandle); } }
		public long AllocatedSize { get { UnsafeNativeMethods.FileStandardInformation info; UnsafeNativeMethods.NtQueryStandardInformationFile(this.SafeFileHandle, true, out info); return info.AllocationSize; } }
		public FileAttributes Attributes { get { return (FileAttributes)this.AttributesWin32; } set { this.AttributesWin32 = (Win32FileAttributes)value; } }
		public Win32FileAttributes AttributesWin32 { get { return UnsafeNativeMethods.NtQueryBasicInformationFile(this.SafeFileHandle).FileAttributes; } set { UnsafeNativeMethods.NtSetBasicInformationFile(this.SafeFileHandle, new UnsafeNativeMethods.FileBasicInformation() { LastWriteTime = -1, ChangeTime = -1, LastAccessTime = -1, CreationTime = -1, FileAttributes = value }); } }
		/// <summary>Total number of free allocation units on the volume that are available to the user associated with the calling thread.</summary>
		public long AvailableClusters { get { this.RefreshSizeInformation(false); return this.sizeInformation.AvailableAllocationUnits; } }
		public long BytesPerCluster { get { return Math.BigMul(this.BytesPerSector, this.SectorsPerCluster); } }
		public int BytesPerSector { get { this.RefreshSizeInformation(false); return this.sizeInformation.BytesPerSector; } }
		public override bool CanRead { get { return this._CanRead; } }
		public override bool CanSeek { get { return true; } }
		public override bool CanWrite { get { return this._CanWrite; } }
		public DateTime ChangeTime { get { return DateTime.FromFileTime(UnsafeNativeMethods.NtQueryBasicInformationFile(this.SafeFileHandle).ChangeTime); } set { UnsafeNativeMethods.NtSetBasicInformationFile(this.SafeFileHandle, new UnsafeNativeMethods.FileBasicInformation() { LastWriteTime = -1, ChangeTime = value.ToFileTime(), LastAccessTime = -1, CreationTime = -1, FileAttributes = (Win32FileAttributes)(-1) }); } }
		public DateTime CreationTime { get { return DateTime.FromFileTime(UnsafeNativeMethods.NtQueryBasicInformationFile(this.SafeFileHandle).CreationTime); } set { UnsafeNativeMethods.NtSetBasicInformationFile(this.SafeFileHandle, new UnsafeNativeMethods.FileBasicInformation() { LastWriteTime = -1, ChangeTime = -1, LastAccessTime = -1, CreationTime = value.ToFileTime(), FileAttributes = (Win32FileAttributes)(-1) }); } }
		public bool DeleteOnClose { get { UnsafeNativeMethods.FileStandardInformation info; UnsafeNativeMethods.NtQueryStandardInformationFile(this.SafeFileHandle, true, out info); return info.DeletePending; } set { UnsafeNativeMethods.NtSetDispositionInformationFile(this.SafeFileHandle, value); } }
		public Win32DeviceType DeviceType { get { return UnsafeNativeMethods.NtQueryVolumeDeviceInformationFile(this.SafeFileHandle).DeviceType; } }
		public char DriveLetter { get { string drPath = this.TryGetDriveRelativePath(); string ntName = this.FullObjectName; return UnsafeNativeMethods.GetDriveLetter(ntName.Substring(0, ntName.Length - (drPath == null ? 0 : drPath.Length)), true); } }
		public string DriveRelativePath { get { return UnsafeNativeMethods.NtQueryNameInformationFile(this.SafeFileHandle, true); } }
		public long FileObjectPosition { get { return UnsafeNativeMethods.NtQueryFilePositionInformationFile(this.SafeFileHandle); } set { UnsafeNativeMethods.SetFilePointerEx(this.SafeFileHandle, value, SeekOrigin.Begin); } }
		public override void Flush() { UnsafeNativeMethods.TryFlushFileBuffers(this.SafeFileHandle); }
		public string FullObjectName { get { return UnsafeNativeMethods.NtQueryObjectName(this.SafeFileHandle); } }
		public long IndexNumber { get { return UnsafeNativeMethods.NtQueryInternalInformationFile(this.SafeFileHandle); } }
		public bool IsDirectory { get { UnsafeNativeMethods.FileStandardInformation info; UnsafeNativeMethods.NtQueryStandardInformationFile(this.SafeFileHandle, true, out info); return info.Directory; } }
		public bool IsSynchronous { get { this.RefreshModeInformation(false); return this._IsSynchronous; } private set { this._IsSynchronous = value; } }
		public DateTime LastAccessTime { get { return DateTime.FromFileTime(UnsafeNativeMethods.NtQueryBasicInformationFile(this.SafeFileHandle).LastAccessTime); } set { UnsafeNativeMethods.NtSetBasicInformationFile(this.SafeFileHandle, new UnsafeNativeMethods.FileBasicInformation() { LastWriteTime = -1, ChangeTime = -1, LastAccessTime = value.ToFileTime(), CreationTime = -1, FileAttributes = (Win32FileAttributes)(-1) }); } }
		public DateTime LastWriteTime { get { return DateTime.FromFileTime(UnsafeNativeMethods.NtQueryBasicInformationFile(this.SafeFileHandle).LastWriteTime); } set { UnsafeNativeMethods.NtSetBasicInformationFile(this.SafeFileHandle, new UnsafeNativeMethods.FileBasicInformation() { LastWriteTime = value.ToFileTime(), ChangeTime = -1, LastAccessTime = -1, CreationTime = -1, FileAttributes = (Win32FileAttributes)(-1) }); } }
		public override long Length { get { UnsafeNativeMethods.FileStandardInformation info; if (!UnsafeNativeMethods.NtQueryStandardInformationFile(this.SafeFileHandle, false, out info)) { return this.TotalClusters * this.BytesPerCluster; } else { return info.EndOfFile; } } }
		public int LinkCount { get { UnsafeNativeMethods.FileStandardInformation info; UnsafeNativeMethods.NtQueryStandardInformationFile(this.SafeFileHandle, true, out info); return info.NumberOfLinks; } }
		public string Name { get { return GetName(this.DriveRelativePath); } }
		public bool NoIntermediateBuffering { get { this.RefreshModeInformation(false); return this._NoIntermediateBuffering; } set { this._NoIntermediateBuffering = value; } }
		/// <summary>Use only ONCE per method, to ensure asynchronous calls can work!</summary>
		public override long Position { get { return /*!this.NoIntermediateBuffering && this.IsSynchronous ? UnsafeNativeMethods.GetFilePosition(this.SafeFileHandle) :*/ this._Position; } set { if (value < 0) { throw new ArgumentOutOfRangeException("value", value, "Value must be nonnegative."); } this.Seek(value, SeekOrigin.Begin); } }
		public SafeFileHandle SafeFileHandle { get { if (this._SafeFileHandle == null) { throw new InvalidOperationException("The handle is null."); } return this._SafeFileHandle; } private set { if (value == null) { throw new ArgumentNullException("value"); } this._SafeFileHandle = value; } }
		public int SectorsPerCluster { get { this.RefreshSizeInformation(false); return this.sizeInformation.SectorsPerAllocationUnit; } }
		public long TotalClusters { get { this.RefreshSizeInformation(false); return this.sizeInformation.TotalAllocationUnits; } }
		public string Win32PathName { get { string drPath = this.TryGetDriveRelativePath(); string ntName = this.FullObjectName; return UnsafeNativeMethods.GetDriveLetter(ntName.Substring(0, ntName.Length - (drPath == null ? 0 : drPath.Length)), true) + ":" + drPath; } }
		#endregion

		private static string GetName(string path)
		{
			if (path != null)
			{
				int endIndex = path.Length;
				while (endIndex > 0 && (path[endIndex - 1] == Path.DirectorySeparatorChar | path[endIndex - 1] == Path.AltDirectorySeparatorChar | path[endIndex - 1] == Path.VolumeSeparatorChar))
				{ endIndex--; }
				int startIndex = endIndex - 1;
				while (startIndex >= 0)
				{
					if (path[startIndex] == Path.DirectorySeparatorChar | path[startIndex] == Path.AltDirectorySeparatorChar | path[endIndex - 1] == Path.VolumeSeparatorChar)
					{
						startIndex++;
						break;
					}
					startIndex--;
				}
				return path.Substring(startIndex, endIndex - startIndex);
			}
			return path;
		}

		private static unsafe void AsyncFSCallback(uint errorCode, uint numBytes, NativeOverlapped* pOverlapped)
		{
			var unpacked = Overlapped.Unpack(pOverlapped);
			var asyncResult = (AsyncResult)unpacked.AsyncResult;
			if ((errorCode == 0x6d) || (errorCode == 0xe8)) { errorCode = 0; }
			asyncResult.ErrorCode = (int)errorCode;
			asyncResult.CompletedSynchronously = false;
			asyncResult.IsCompleted = true;
			ManualResetEvent @event = asyncResult.AsyncWaitHandle;
			if ((@event != null) && !@event.Set()) { UnsafeNativeMethods.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error()); }
			var callback = asyncResult.UserCallback;
			if (callback != null) { callback(asyncResult); }
		}

		private IAsyncResult BeginProcessing(byte[] buffer, int offset, int count, AsyncCallback callback, object state, bool write)
		{
			if (write) { throw new NotImplementedException("Read-Modify-Write is not implemented."); }

			//return write ? base.BeginWrite(buffer, offset, count, callback, state) : base.BeginRead(buffer, offset, count, callback, state);
			if (callback != null) { throw new NotImplementedException("BindHandle does not always work correctly (throws an exception in Release mode when not debugging) and using a callback is not yet supported."); }
			long position = this.Position;

			var bps = this.BytesPerSector;
			bool aligned = position % bps == 0 && count % bps == 0;
			long alignedPosition = position / bps * bps;
			bool success = false;
			var fileHandle = this.SafeFileHandle;
			try
			{
				fileHandle.DangerousAddRef(ref success);
				Debug.Assert(success);
				IntPtr len = aligned ? IntPtr.Zero : (IntPtr)((position + count - alignedPosition + bps - 1) / bps * bps);
				var async = new AsyncResult(fileHandle, buffer, offset, count, state, callback, write)
				{
					HGlobalBufferAddress = aligned ? IntPtr.Zero : Marshal.AllocHGlobal(len),
					HGlobalBufferLength = len,
					OffsetInHGlobalBufferDueToAlignment = checked((int)(position - alignedPosition)),
				};
				var waitHandle = async.AsyncWaitHandle.SafeWaitHandle;
				try
				{
					waitHandle.DangerousAddRef(ref success);
					Debug.Assert(success);
					var overlapped = new Overlapped(unchecked((int)position), (int)(position >> 32), waitHandle.DangerousGetHandle(), async);
					unsafe
					{
						NativeOverlapped* pOverlapped;
						IOCompletionCallback nativeCallback;
						if (callback != null) { nativeCallback = IOCompletionCallback; pOverlapped = overlapped.Pack(nativeCallback, buffer); }
						else { nativeCallback = null; pOverlapped = overlapped.UnsafePack(nativeCallback, buffer); }
						async.Overlapped = pOverlapped;
						fixed (byte* pBuffer = &buffer[offset]) //Overlapped already pinned it, so it's ok to do this
						{
							if (write ?
								!UnsafeNativeMethods.WriteFileAsync(this.SafeFileHandle, aligned ? (IntPtr)pBuffer : async.HGlobalBufferAddress, aligned ? count : (int)async.HGlobalBufferLength, pOverlapped, nativeCallback) :
								!UnsafeNativeMethods.ReadFileAsync(this.SafeFileHandle, aligned ? (IntPtr)pBuffer : async.HGlobalBufferAddress, aligned ? count : (int)async.HGlobalBufferLength, pOverlapped, nativeCallback)
								)
							{
								//Async IO
							}
							else
							{
								//IO was actually done synchronously
								async.CompletedSynchronously = true;
							}
						}
						return async;
					}
				}
				catch { if (success) { waitHandle.DangerousRelease(); } throw; }
			}
			catch { if (success) { fileHandle.DangerousRelease(); } throw; }
		}

		public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state) { return this.BeginProcessing(buffer, offset, count, callback, state, false); }

		//public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state) { return this.BeginProcessing(buffer, offset, count, callback, state, true); }

		public void CreateHardLink(SafeFileHandle targetRootDirectory, string newName, bool replaceIfExists) { UnsafeNativeMethods.NtSetRenameOrLinkInformationFile(this.SafeFileHandle, replaceIfExists, targetRootDirectory, newName, false); }

		protected override void Dispose(bool disposing) { if (disposing) { try { this.SafeFileHandle.Close(); } finally { this._SafeFileHandle = null; base.Dispose(disposing); } } }

		private int EndProcessing(IAsyncResult asyncResult, bool write)
		{
			var result = asyncResult as AsyncResult;
			if (result != null)
			{
				if (result.Write != write) { throw new ArgumentException("IAsyncResult object did not come from the corresponding async method on this type."); }
				result.SafeFileHandle.DangerousRelease();
				result.AsyncWaitHandle.SafeWaitHandle.DangerousRelease();
				try
				{
					//Overlapped overlapped;
					//unsafe { overlapped = Overlapped.Unpack(result.Overlapped); }
					int bytesTransferred;
					using (result.AsyncWaitHandle)
					{
						if (!asyncResult.CompletedSynchronously)
						{ unsafe { UnsafeNativeMethods.GetOverlappedResult(result.SafeFileHandle, result.Overlapped, out bytesTransferred, true); /*result.AsyncWaitHandle.WaitOne();*/ } }
					}
				}
				finally { unsafe { Overlapped.Free(result.Overlapped); result.Overlapped = null; } }
				if (result.ErrorCode != 0) { UnsafeNativeMethods.ThrowExceptionForHR(result.ErrorCode | unchecked((int)0x80070000)); }
				if (result.HGlobalBufferAddress != IntPtr.Zero)
				{
					try { if (!write) { unsafe { Marshal.Copy((IntPtr)((byte*)result.HGlobalBufferAddress + result.OffsetInHGlobalBufferDueToAlignment), result.UserBuffer, result.UserBufferOffset, result.Length); } } }
					finally { Marshal.FreeHGlobal(result.HGlobalBufferAddress); }
				}
				return result.Length;
			}
			else { if (write) { base.EndWrite(asyncResult); return result.Length; } else { return base.EndRead(asyncResult); } }
		}

		public override int EndRead(IAsyncResult asyncResult) { return this.EndProcessing(asyncResult, false); }

		//public override void EndWrite(IAsyncResult asyncResult) { this.EndProcessing(asyncResult, true); }

		#region Directories
		/// <summary><para>Returns information for all files and folders in the directory.</para><para>Note that this can include the current directory (name ".") and parent directory (name "..").</para></summary>
		public bool GetNextFileIdBothDirInformation(string pattern, bool restartScan, out FileIdBothDirInformation info) { return this.GetNextFileIdBothDirInformation(pattern, restartScan, out info); }
		/// <summary><para>Returns information for all files and folders in the directory.</para><para>Note that this can include the current directory (name ".") and parent directory (name "..").</para></summary>
		public bool GetNextFileIdBothDirInformation(string pattern, bool restartScan, ref IntPtr pBufferHGlobal, ref int bufferSizeHint, out FileIdBothDirInformation info) { return UnsafeNativeMethods.NtQueryFileIdBothDirInformationDirectoryFileSingleEntry(this.SafeFileHandle, pattern, restartScan, ref pBufferHGlobal, ref bufferSizeHint, out info); }
		/// <summary><para>Returns information for all files and folders in the directory.</para><para>Note that this can include the current directory (name ".") and parent directory (name "..").</para></summary>
		public FileIdBothDirInformation[] GetNextFileIdBothDirInformations(string pattern, bool restartScan) { int size = DEFAULT_NUM_FILE_ID_BOTH_DIR_INFOS * Marshal.SizeOf(typeof(FileIdBothDirInformation)); IntPtr pBufferHGlobal = IntPtr.Zero; return this.GetNextFileIdBothDirInformations(pattern, restartScan, ref pBufferHGlobal, ref size); }
		/// <summary><para>Returns information for all files and folders in the directory.</para><para>Note that this can include the current directory (name ".") and parent directory (name "..").</para></summary>
		public FileIdBothDirInformation[] GetNextFileIdBothDirInformations(string pattern, bool restartScan, ref IntPtr pBufferHGlobal, ref int bufferSizeHint) { var buffer = new List<FileIdBothDirInformation>(64); if (UnsafeNativeMethods.NtQueryFileIdBothDirInformationDirectoryFileMultipleEntries(this.SafeFileHandle, pattern, restartScan, ref pBufferHGlobal, ref bufferSizeHint, buffer)) { return buffer.ToArray(); } else { return null; } }
		/// <summary><para>Returns information for all files and folders in the directory.</para><para>Note that this can include the current directory (name ".") and parent directory (name "..").</para></summary>
		public List<FileIdBothDirInformation> GetFileIdBothDirInformations(string pattern, List<FileIdBothDirInformation> result) { int size = DEFAULT_NUM_FILE_ID_BOTH_DIR_INFOS * Marshal.SizeOf(typeof(FileIdBothDirInformation)); IntPtr pBufferHGlobal = IntPtr.Zero; return this.GetFileIdBothDirInformations(pattern, result, ref pBufferHGlobal, ref size); }
		/// <summary><para>Returns information for all files and folders in the directory.</para><para>Note that this can include the current directory (name ".") and parent directory (name "..").</para></summary>
		public List<FileIdBothDirInformation> GetFileIdBothDirInformations(string pattern, List<FileIdBothDirInformation> result, ref IntPtr pBufferHGlobal, ref int bufferSizeHint)
		{
			if (result == null) { result = new List<FileIdBothDirInformation>(); }
			var infos = this.GetNextFileIdBothDirInformations(pattern, true, ref pBufferHGlobal, ref bufferSizeHint);
			int counter = 0;
			while (infos != null)
			{
				result.AddRange(infos);
				infos = this.GetNextFileIdBothDirInformations(pattern, false, ref pBufferHGlobal, ref bufferSizeHint);
				counter++;
				bufferSizeHint <<= 1;
			}
			return result;
		}

		/// <summary><para>Returns information for all files and folders in the directory.</para><para>Note that this can include the current directory (name ".") and parent directory (name "..").</para></summary>
		public bool GetNextFileDirectoryInformation(string pattern, bool restartScan, out FileDirectoryInformation info) { return this.GetNextFileDirectoryInformation(pattern, restartScan, out info); }
		/// <summary><para>Returns information for all files and folders in the directory.</para><para>Note that this can include the current directory (name ".") and parent directory (name "..").</para></summary>
		public bool GetNextFileDirectoryInformation(string pattern, bool restartScan, ref int bufferSizeHint, ref IntPtr pBufferHGlobal, out FileDirectoryInformation info) { return UnsafeNativeMethods.NtQueryFileDirectoryInformationDirectoryFileSingleEntry(this.SafeFileHandle, pattern, restartScan, ref pBufferHGlobal, ref bufferSizeHint, out info); }
		/// <summary><para>Returns information for all files and folders in the directory.</para><para>Note that this can include the current directory (name ".") and parent directory (name "..").</para></summary>
		public FileDirectoryInformation[] GetNextFileDirectoryInformations(string pattern, bool restartScan) { int size = DEFAULT_NUM_FILE_DIRECTORY_INFOS * Marshal.SizeOf(typeof(FileDirectoryInformation)); IntPtr pBufferHGlobal = IntPtr.Zero; return this.GetNextFileDirectoryInformations(pattern, restartScan, ref pBufferHGlobal, ref size); }
		/// <summary><para>Returns information for all files and folders in the directory.</para><para>Note that this can include the current directory (name ".") and parent directory (name "..").</para></summary>
		public FileDirectoryInformation[] GetNextFileDirectoryInformations(string pattern, bool restartScan, ref IntPtr pBufferHGlobal, ref int bufferSizeHint) { var buffer = new List<FileDirectoryInformation>(64); if (UnsafeNativeMethods.NtQueryFileDirectoryInformationDirectoryFileMultipleEntries(this.SafeFileHandle, pattern, restartScan, ref pBufferHGlobal, ref bufferSizeHint, buffer)) { return buffer.ToArray(); } else { return null; } }
		/// <summary><para>Returns information for all files and folders in the directory.</para><para>Note that this can include the current directory (name ".") and parent directory (name "..").</para></summary>
		public List<FileDirectoryInformation> GetFileDirectoryInformations(string pattern) { IntPtr pBufferHGlobal = IntPtr.Zero; int size = DEFAULT_NUM_FILE_DIRECTORY_INFOS * Marshal.SizeOf(typeof(FileDirectoryInformation)); return this.GetFileDirectoryInformations(pattern, null, ref pBufferHGlobal, ref size); }
		/// <summary><para>Returns information for all files and folders in the directory.</para><para>Note that this can include the current directory (name ".") and parent directory (name "..").</para></summary>
		public List<FileDirectoryInformation> GetFileDirectoryInformations(string pattern, List<FileDirectoryInformation> result, ref IntPtr pBufferHGlobal, ref int bufferSizeHint)
		{
			if (result == null) { result = new List<FileDirectoryInformation>(); }
			var infos = this.GetNextFileDirectoryInformations(pattern, true, ref pBufferHGlobal, ref bufferSizeHint);
			int counter = 0;
			while (infos != null)
			{
				result.AddRange(infos);
				infos = this.GetNextFileDirectoryInformations(pattern, false, ref pBufferHGlobal, ref bufferSizeHint);
				counter++;
				bufferSizeHint <<= 1;
			}
			return result;
		}

		/// <summary><para>Returns information for all files and folders in the directory.</para><para>Note that this can include the current directory (name ".") and parent directory (name "..").</para></summary>
		public bool GetNextFileName(string pattern, bool restartScan, out string info) { return this.GetNextFileName(pattern, restartScan, out info); }
		/// <summary><para>Returns information for all files and folders in the directory.</para><para>Note that this can include the current directory (name ".") and parent directory (name "..").</para></summary>
		public bool GetNextFileName(string pattern, bool restartScan, ref IntPtr pBufferHGlobal, ref int bufferSizeHint, out string info) { return UnsafeNativeMethods.NtQueryFileNamesInformationDirectoryFileSingleEntry(this.SafeFileHandle, pattern, restartScan, ref pBufferHGlobal, ref bufferSizeHint, out info); }
		/// <summary><para>Returns information for all files and folders in the directory.</para><para>Note that this can include the current directory (name ".") and parent directory (name "..").</para></summary>
		public string[] GetNextFileNames(string pattern, bool restartScan) { IntPtr pBufferHGlobal = IntPtr.Zero; int size = DEFAULT_NUM_FILE_NAMES * Marshal.SizeOf(typeof(FileNamesInformation)); return this.GetNextFileNames(pattern, restartScan, ref pBufferHGlobal, ref size); }
		/// <summary><para>Returns information for all files and folders in the directory.</para><para>Note that this can include the current directory (name ".") and parent directory (name "..").</para></summary>
		public string[] GetNextFileNames(string pattern, bool restartScan, ref IntPtr pBufferHGlobal, ref int bufferSizeHint) { return UnsafeNativeMethods.NtQueryFileNamesInformationDirectoryFileMultipleEntries(this.SafeFileHandle, pattern, restartScan, ref pBufferHGlobal, ref bufferSizeHint); }
		/// <summary><para>Returns information for all files and folders in the directory.</para><para>Note that this can include the current directory (name ".") and parent directory (name "..").</para></summary>
		public List<string> GetFileNames(string pattern) { IntPtr pBufferHGlobal = IntPtr.Zero; int size = DEFAULT_NUM_FILE_NAMES * Marshal.SizeOf(typeof(FileNamesInformation)); return this.GetFileNames(pattern, ref pBufferHGlobal, ref size); }
		/// <summary><para>Returns information for all files and folders in the directory.</para><para>Note that this can include the current directory (name ".") and parent directory (name "..").</para></summary>
		public List<string> GetFileNames(string pattern, ref IntPtr pBufferHGlobal, ref int bufferSizeHint)
		{
			var result = new List<string>();
			var infos = this.GetNextFileNames(pattern, true, ref pBufferHGlobal, ref bufferSizeHint);
			int counter = 0;
			while (infos != null)
			{
				result.AddRange(infos);
				infos = this.GetNextFileNames(pattern, false, ref pBufferHGlobal, ref bufferSizeHint);
				counter++;
				bufferSizeHint <<= 1;
			}
			return result;
		}

		public void WaitForDirectoryChange(FileNotifyFilter filter, bool watchSubtree, IntPtr buffer, int bufferSize) { UnsafeNativeMethods.NtNotifyChangeDirectoryFileSynchronous(this.SafeFileHandle, buffer, bufferSize, filter, watchSubtree); }

		public ICollection<KeyValuePair<string, FileAction>> WaitForDirectoryChange(FileNotifyFilter filter, bool watchSubtree, ICollection<KeyValuePair<string, FileAction>> buffer, int bufferSize)
		{
			if (bufferSize == 0) { bufferSize = 0x100000; }
			IntPtr pBuffer;
			bool stackAlloc = bufferSize < 0x800;
			if (stackAlloc) { unsafe { byte* pBuffer2 = stackalloc byte[bufferSize]; pBuffer = (IntPtr)pBuffer2; } }
			else { pBuffer = Marshal.AllocHGlobal(bufferSize); }
			try
			{
				this.WaitForDirectoryChange(filter, watchSubtree, pBuffer, bufferSize);
				return ConvertFileActions(pBuffer, buffer);
			}
			finally { if (!stackAlloc) { Marshal.FreeHGlobal(pBuffer); } }
		}

		public KeyValuePair<string, FileAction>[] WaitForDirectoryChange(FileNotifyFilter filter, bool watchSubtree, int bufferSize) { return (KeyValuePair<string, FileAction>[])this.WaitForDirectoryChange(filter, watchSubtree, null, bufferSize); }

		public KeyValuePair<string, FileAction>[] WaitForDirectoryChange(FileNotifyFilter filter, bool watchSubtree) { return this.WaitForDirectoryChange(filter, watchSubtree, 0); }
		
		#endregion

		/// <returns>Returns an array of key/value pairs mapping each stream's name to its length and allocation size, in that order.</returns>
		public KeyValuePair<string, KeyValuePair<long, long>>[] GetStreams() { return UnsafeNativeMethods.NtQueryStreamInformationFile(this.SafeFileHandle); }

		public KeyValuePair<int, KeyValuePair<long, long>>[] GetVolumeDiskExtents() { return UnsafeNativeMethods.GetVolumeDiskExtents(this.SafeFileHandle); }

		/// <summary>The position must be updated manually!</summary>
		private int Process(long position, byte[] buffer, int bufferOffset, int count, bool write)
		{
			int processed;
			if (count > buffer.Length - bufferOffset) { throw new ArgumentException("Offset and length were out of bounds for the array or count is greater than the number of elements from index to the end of the source collection."); }
			if ((this.IsSynchronous & !this.NoIntermediateBuffering) || (position % this.BytesPerSector == 0 && count % this.BytesPerSector == 0))
			{
				unsafe
				{
					fixed (byte* pData = &buffer[bufferOffset])
					{
						processed = write
							? UnsafeNativeMethods.WriteFile(this.SafeFileHandle, (IntPtr)pData, count, position)
							: UnsafeNativeMethods.ReadFile(this.SafeFileHandle, (IntPtr)pData, count, position);
					}
				}
			}
			else
			{
				var bps = this.BytesPerSector;
				long alignedPosition = position / bps * bps;

#if NEW_METHOD
				unsafe
				{
					byte* pSector = stackalloc byte[bps];

					//Copy bytes in first sector
					UnsafeNativeMethods.ReadFile(this.SafeFileHandle, (IntPtr)pSector, bps, alignedPosition);
					int toCopy = Math.Min(count, bps - (int)(position - alignedPosition));
					if (write)
					{
						Marshal.Copy(buffer, bufferOffset, (IntPtr)(pSector + (int)(position - alignedPosition)), toCopy);
						UnsafeNativeMethods.WriteFile(this.SafeFileHandle, (IntPtr)pSector, bps, alignedPosition);
					}
					else { Marshal.Copy((IntPtr)(pSector + (int)(position - alignedPosition)), buffer, bufferOffset, toCopy); }
					processed = toCopy;
					bufferOffset += toCopy;
					count -= toCopy;
					alignedPosition += bps;
					position = alignedPosition;

					//Copy middle sectors
					int alignedCount = count / bps * bps;
					if (alignedCount > 0)
					{
						fixed (byte* pData = &buffer[bufferOffset])
						{
							if (write) { UnsafeNativeMethods.WriteFile(this.SafeFileHandle, (IntPtr)pData, alignedCount, alignedPosition); }
							else { UnsafeNativeMethods.ReadFile(this.SafeFileHandle, (IntPtr)pData, alignedCount, alignedPosition); }
							processed += alignedCount;
							count -= alignedCount;
							bufferOffset += alignedCount;
							alignedPosition += alignedCount;
							position = alignedPosition;
						}
					}

					//Copy bytes in last sector
					if (count > 0)
					{
						UnsafeNativeMethods.ReadFile(this.SafeFileHandle, (IntPtr)pSector, bps, alignedPosition);
						if (write)
						{
							Marshal.Copy(buffer, bufferOffset, (IntPtr)(pSector), count);
							UnsafeNativeMethods.WriteFile(this.SafeFileHandle, (IntPtr)pSector, bps, alignedPosition);
						}
						else { Marshal.Copy((IntPtr)pSector, buffer, bufferOffset, count); }
						processed += count;
					}
				}
#else
				var alignedData = new byte[(position + count - alignedPosition + bps - 1) / bps * bps];
				unsafe
				{
					fixed (byte* pData = alignedData)
					{
						processed = UnsafeNativeMethods.ReadFile(this.SafeFileHandle, (IntPtr)pData, alignedData.Length, alignedPosition);
						if (write)
						{
							Buffer.BlockCopy(buffer, bufferOffset, alignedData, (int)(position - alignedPosition), count);
							processed = UnsafeNativeMethods.WriteFile(this.SafeFileHandle, (IntPtr)pData, alignedData.Length, alignedPosition);
						}
					}
				}
				if (!write) { checked { Buffer.BlockCopy(alignedData, (int)(position - alignedPosition), buffer, bufferOffset, count); } }
				processed = Math.Min(processed, count);
#endif
			}
			return processed;
		}

		public void Rename(SafeFileHandle targetRootDirectory, string newName, bool replaceIfExists) { UnsafeNativeMethods.NtSetRenameOrLinkInformationFile(this.SafeFileHandle, replaceIfExists, targetRootDirectory, newName, true); }

		public void RefreshModeInformation(bool force) { if (force || !this.modeInformationQueried) { this.IsSynchronous = (UnsafeNativeMethods.NtQueryModeInformationFile(this.SafeFileHandle) & (WinNTFileOptions.SynchronousIoAlert | WinNTFileOptions.SynchronousIoNonalert)) != 0; this.NoIntermediateBuffering = (UnsafeNativeMethods.NtQueryModeInformationFile(this.SafeFileHandle) & WinNTFileOptions.NoIntermediateBuffering) != 0; this.sizeInformation = UnsafeNativeMethods.NtQueryVolumeSizeInformationFile(this.SafeFileHandle); this.modeInformationQueried = true; } }

		public void RefreshSizeInformation(bool force) { if (force || !this.sizeInformationQueried) { this.sizeInformation = UnsafeNativeMethods.NtQueryVolumeSizeInformationFile(this.SafeFileHandle); this.sizeInformationQueried = true; } }

		public override int Read(byte[] buffer, int offset, int count) { var pos = this.Position; int processed = this.Process(pos, buffer, offset, count, false); this.Position = pos + processed; return processed; }

		public override int ReadByte()
		{
			var bps = this.BytesPerSector;
			long position = this.Position;
			int b;
			if (this.IsSynchronous & !this.NoIntermediateBuffering) { unsafe { UnsafeNativeMethods.ReadFile(this.SafeFileHandle, (IntPtr)(&b), 1, position); } }
			else
			{
				long alignedPosition = position / bps * bps;
				int alignedDataLength = checked((int)((position + 1 - alignedPosition + bps - 1) / bps * bps));
				unsafe
				{
					byte* pAlignedData = stackalloc byte[alignedDataLength];
					int bytesRead = UnsafeNativeMethods.ReadFile(this.SafeFileHandle, (IntPtr)pAlignedData, alignedDataLength, alignedPosition);
					b = bytesRead > 0 ? pAlignedData[position - alignedPosition] : -1;
				}
			}
			this.Position = position + (b >= 0 ? 1 : 0);
			return b;
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			//if (!this.CanSeek) { throw new InvalidOperationException(); }
			//if (!this.NoIntermediateBuffering && this.IsSynchronous) { this._Position = UnsafeNativeMethods.SetFilePointerEx(this.SafeFileHandle, offset, origin); }
			//else
			{
				switch (origin)
				{
					case SeekOrigin.Begin:
						this._Position = 0 + offset;
						break;
					case SeekOrigin.Current:
						this._Position = this._Position + offset;
						break;
					case SeekOrigin.End:
						this._Position = this.Length + offset;
						break;
					default:
						throw new ArgumentOutOfRangeException("origin", origin, "Invalid seek origin.");
				}
			}
			return this._Position;
		}

		public override void SetLength(long value) { UnsafeNativeMethods.NtSetEndOfFileInformationFile(this.SafeFileHandle, value); }

		public override string ToString() { string result = this.TryGetWin32PathName(); if (result == null) { result = this.FullObjectName; } return result; }

		public char? TryGetDriveLetter()
		{
			string drPath = this.TryGetDriveRelativePath();
			string ntName = this.FullObjectName;
			char driveLetter;
			int result = UnsafeNativeMethods.GetDriveLetter(ntName.Substring(0, ntName.Length - (drPath == null ? 0 : drPath.Length)), out driveLetter);
			if (result == 0) { return driveLetter; }
			return null;
		}

		public string TryGetDriveRelativePath() { return UnsafeNativeMethods.NtQueryNameInformationFile(this.SafeFileHandle, false); }

		public string TryGetWin32PathName()
		{
			string drPath = this.TryGetDriveRelativePath();
			string ntName = this.FullObjectName;
			char driveLetter;
			int result = UnsafeNativeMethods.GetDriveLetter(ntName.Substring(0, ntName.Length - (drPath == null ? 0 : drPath.Length)), out driveLetter);
			if (result == 0) { return driveLetter + ":" + drPath; }
			return null;
		}

		public override void Write(byte[] buffer, int offset, int count) { var pos = this.Position; this.Position = pos + this.Process(pos, buffer, offset, count, true); }

		public override void WriteByte(byte value)
		{
			var bps = this.BytesPerSector;
			long position = this.Position;
			byte b;
			if (this.IsSynchronous & !this.NoIntermediateBuffering) { unsafe { UnsafeNativeMethods.WriteFile(this.SafeFileHandle, (IntPtr)(&b), 1, position); } }
			else
			{
				long alignedPosition = position / bps * bps;
				int alignedDataLength = checked((int)((position + 1 - alignedPosition + bps - 1) / bps * bps));
				unsafe
				{
					byte* pAlignedData = stackalloc byte[alignedDataLength];
					if (alignedPosition < this.Length)
					{ UnsafeNativeMethods.ReadFile(this.SafeFileHandle, (IntPtr)pAlignedData, alignedDataLength, alignedPosition); }
					pAlignedData[position - alignedPosition] = value;
					int bytesWritten = UnsafeNativeMethods.WriteFile(this.SafeFileHandle, (IntPtr)pAlignedData, alignedDataLength, alignedPosition);
					Debug.Assert(bytesWritten == alignedDataLength);
				}
			}
			this.Position = position + 1;
		}

		//Static

		public static void NtDeleteFile(SafeFileHandle root, string filePath, bool throwOnError) { UnsafeNativeMethods.NtDeleteFile(root, WinNTObjectAttributes.None, RtlDosPathNameToNtPathName(filePath), throwOnError); }
		public static void NtDeleteFile(SafeFileHandle root, WinNTObjectAttributes objectAttributes, string kernelFileName, bool throwOnError) { UnsafeNativeMethods.NtDeleteFile(root, objectAttributes, kernelFileName, throwOnError); }

		public static Win32FileStream NtCreateFile(SafeFileHandle parent, string ntPath, FileAccess access, long? allocationSize, FileAttributes attributes, bool? forceFile, FileShare share, FileMode mode, FileOptions options, bool throwOnError) { return NtCreateFile(parent, ntPath, ConvertAccessToWin32(access) | (mode == FileMode.Append ? Win32FileAccess.AppendData : 0), allocationSize, (Win32FileAttributes)attributes, share, mode == FileMode.Create && forceFile == false ? FileCreationDisposition.OpenIf : ConvertFileModeToCreationDisposition(mode), ConvertFileOptionsToWinNT(options) | (forceFile != true ? forceFile != false ? WinNTFileOptions.None : WinNTFileOptions.DirectoryFile : WinNTFileOptions.NonDirectoryFile), WinNTObjectAttributes.None, throwOnError); }
		public static Win32FileStream NtCreateFile(SafeFileHandle parent, string ntPath, Win32FileAccess access, long? allocationSize, Win32FileAttributes attributes, FileShare share, FileCreationDisposition cd, WinNTFileOptions options, WinNTObjectAttributes objectAttributes, bool throwOnError) { var h = UnsafeNativeMethods.NtCreateFile(parent, objectAttributes, ntPath, ref access, allocationSize, attributes, share, cd, options, throwOnError); return h != null ? new Win32FileStream(h, access, false) : null; }
		public static Win32FileStream NtCreateFileById(SafeFileHandle volumeHandle, long fileID, FileAccess fileAccess, long? allocationSize, FileAttributes attributes, FileShare share, FileMode mode, FileOptions options, bool throwOnError) { return NtCreateFileById(volumeHandle, fileID, ConvertAccessToWin32(fileAccess) | (mode == FileMode.Append ? Win32FileAccess.AppendData : 0), allocationSize, (Win32FileAttributes)attributes, share, ConvertFileModeToCreationDisposition(mode), ConvertFileOptionsToWinNT(options), WinNTObjectAttributes.None, throwOnError); }
		public static Win32FileStream NtCreateFileById(SafeFileHandle volumeHandle, long fileID, Win32FileAccess fileAccess, long? allocationSize, Win32FileAttributes attributes, FileShare share, FileCreationDisposition cd, WinNTFileOptions options, WinNTObjectAttributes objectAttributes, bool throwOnError) { var handle = UnsafeNativeMethods.NtCreateFileById(volumeHandle, objectAttributes, fileID, ref fileAccess, allocationSize, attributes, share, cd, options, throwOnError); return handle != null ? new Win32FileStream(handle, fileAccess, false) : null; }

		public static Win32FileStream NtOpenFile(SafeFileHandle parent, string ntPath, FileAccess access, bool? forceFile, FileShare share, FileOptions options, bool throwOnError) { return NtOpenFile(parent, ntPath, ConvertAccessToWin32(access), share, ConvertFileOptionsToWinNT(options) | (forceFile != true ? forceFile != false ? WinNTFileOptions.None : WinNTFileOptions.DirectoryFile : WinNTFileOptions.NonDirectoryFile), WinNTObjectAttributes.None, throwOnError); }
		public static Win32FileStream NtOpenFile(SafeFileHandle parent, string ntPath, Win32FileAccess access, FileShare share, WinNTFileOptions options, WinNTObjectAttributes objectAttributes, bool throwOnError) { var h = UnsafeNativeMethods.NtOpenFile(parent, objectAttributes, ntPath, ref access, share, options, throwOnError); return h != null ? new Win32FileStream(h, access, false) : null; }
		public static Win32FileStream NtOpenFileById(SafeFileHandle volumeHandle, long fileID, FileAccess fileAccess, FileShare share, FileOptions options, bool throwOnError) { return NtOpenFileById(volumeHandle, fileID, ConvertAccessToWin32(fileAccess), share, ConvertFileOptionsToWinNT(options), WinNTObjectAttributes.None, throwOnError); }
		public static Win32FileStream NtOpenFileById(SafeFileHandle volumeHandle, long fileID, Win32FileAccess fileAccess, FileShare share, WinNTFileOptions options, WinNTObjectAttributes objectAttributes, bool throwOnError) { var handle = UnsafeNativeMethods.NtOpenFileById(volumeHandle, objectAttributes, fileID, ref fileAccess, share, options, throwOnError); return handle != null ? new Win32FileStream(handle, fileAccess, false) : null; }

		public static ICollection<KeyValuePair<string, FileAction>> ConvertFileActions(IntPtr pBuffer, ICollection<KeyValuePair<string, FileAction>> list)
		{
			int offset = 0;
			int count = 1;
			unsafe { var ptr = (byte*)pBuffer; while (*(int*)&ptr[offset] != 0) { offset += *(int*)&ptr[offset]; count++; } }
			offset = 0;
			KeyValuePair<string, FileAction>[] arr = null;
			if (list == null) { list = arr = new KeyValuePair<string, FileAction>[count]; }
			unsafe
			{
				int i = 0;
				var ptr = (byte*)pBuffer;
				while (i < count)
				{
					var pItem = (byte*)&ptr[offset];
					var item = new KeyValuePair<string, FileAction>(Marshal.PtrToStringUni((IntPtr)(&pItem[sizeof(int) + sizeof(FileAction) + sizeof(int)]), *(int*)&pItem[sizeof(int) + sizeof(FileAction)] / sizeof(char)), *(FileAction*)&pItem[sizeof(int)]);
					if (arr != null) { arr[i] = item; }
					else { list.Add(item); }
					offset += *(int*)&ptr[offset];
					i++;
				}
			}
			return list;
		}

		public static SafeFileHandle GetFileIdBothDirInfos(string directoryPath, string pattern, List<FileIdBothDirInformation> result, ref IntPtr pBufferHGlobal, ref int bufferSizeHint, bool returnHandle)
		{
			Win32FileAccess access = Win32FileAccess.ListDirectory | Win32FileAccess.Synchronize;
			var handle = UnsafeNativeMethods.NtOpenFile(null, WinNTObjectAttributes.CaseInsensitive, RtlDosPathNameToNtPathName(directoryPath), ref access, FileShare.ReadWrite, WinNTFileOptions.DirectoryFile | WinNTFileOptions.SynchronousIoNonalert, true);
			try
			{
				if (bufferSizeHint == 0) { bufferSizeHint = DEFAULT_NUM_FILE_ID_BOTH_DIR_INFOS * FID_SIZE / 2; }
				int counter = 0;
				bool restart = true;
				while (UnsafeNativeMethods.NtQueryFileIdBothDirInformationDirectoryFileMultipleEntries(handle, pattern, restart, ref pBufferHGlobal, ref bufferSizeHint, result))
				{
					counter++;
					if (!restart)
					{
						bufferSizeHint <<= 1;
						if (pBufferHGlobal != IntPtr.Zero) { pBufferHGlobal = Marshal.ReAllocHGlobal(pBufferHGlobal, (IntPtr)bufferSizeHint); }
					}
					restart = false;
				}
			}
			finally { if (!returnHandle) { handle.Close(); handle = null; } }
			return handle;
		}

		public static string RtlDosPathNameToNtPathName(string path) { return UnsafeNativeMethods.RtlDosPathNameToNtPathName(path); }

		public static Win32FileAccess ConvertAccessToWin32(FileAccess access) { var result = Win32FileAccess.None; if ((access & FileAccess.Read) != 0) { result |= Win32FileAccess.GenericRead; } if ((access & FileAccess.Write) != 0) { result |= Win32FileAccess.GenericWrite; } return result; }

		public static FileCreationDisposition ConvertFileModeToCreationDisposition(FileMode mode)
		{
			switch (mode)
			{
				case FileMode.Append:
					return FileCreationDisposition.Open;
				case FileMode.Create:
					return FileCreationDisposition.OverwriteIf;
				case FileMode.CreateNew:
					return FileCreationDisposition.Create;
				case FileMode.Open:
					return FileCreationDisposition.Open;
				case FileMode.OpenOrCreate:
					return FileCreationDisposition.OpenIf;
				case FileMode.Truncate:
					return FileCreationDisposition.Overwrite;
				default:
					throw new ArgumentOutOfRangeException("mode", mode, "Invalid file mode");
			}
		}

		public static WinNTFileOptions ConvertFileOptionsToWinNT(FileOptions options)
		{
			var result = WinNTFileOptions.None;
			if ((options & FileOptions.Asynchronous) == 0) { result |= WinNTFileOptions.SynchronousIoNonalert; }
			if ((options & FileOptions.DeleteOnClose) != 0) { result |= WinNTFileOptions.DeleteOnClose; }
			if ((options & FileOptions.RandomAccess) != 0) { result |= WinNTFileOptions.RandomAccess; }
			if ((options & FileOptions.SequentialScan) != 0) { result |= WinNTFileOptions.SequentialOnly; }
			if ((options & FileOptions.WriteThrough) != 0) { result |= WinNTFileOptions.WriteThrough; }
			return result;
		}

		public static Win32FileOptions ConvertFileOptionsToWin32(FileOptions options)
		{
			var result = Win32FileOptions.None;
			if ((options & FileOptions.Asynchronous) != 0) { result |= Win32FileOptions.Overlapped; }
			if ((options & FileOptions.DeleteOnClose) != 0) { result |= Win32FileOptions.DeleteOnClose; }
			if ((options & FileOptions.RandomAccess) != 0) { result |= Win32FileOptions.RandomAccess; }
			if ((options & FileOptions.SequentialScan) != 0) { result |= Win32FileOptions.SequentialScan; }
			if ((options & FileOptions.WriteThrough) != 0) { result |= Win32FileOptions.WriteThrough; }
			return result;
		}

		public static WinNTFileOptions ConvertFileOptionsToWinNT(Win32FileOptions options)
		{
			var result = WinNTFileOptions.None;
			if ((options & Win32FileOptions.Overlapped) == 0) { result |= WinNTFileOptions.SynchronousIoNonalert; }
			if ((options & Win32FileOptions.DeleteOnClose) != 0) { result |= WinNTFileOptions.DeleteOnClose; }
			if ((options & Win32FileOptions.RandomAccess) != 0) { result |= WinNTFileOptions.RandomAccess; }
			if ((options & Win32FileOptions.SequentialScan) != 0) { result |= WinNTFileOptions.SequentialOnly; }
			if ((options & Win32FileOptions.WriteThrough) != 0) { result |= WinNTFileOptions.WriteThrough; }
			if ((options & Win32FileOptions.BackupSemantics) != 0) { result |= WinNTFileOptions.OpenForBackupIntent; }
			if ((options & Win32FileOptions.NoBuffering) != 0) { result |= WinNTFileOptions.NoIntermediateBuffering; }
			if ((options & Win32FileOptions.OpenReparsePoint) != 0) { result |= WinNTFileOptions.OpenReparsePoint; }
			return result;
		}

		public static string QueryFirstDosDevice(string deviceName) { return UnsafeNativeMethods.QueryFirstDosDevice(deviceName); }
		public static string[] QueryDosDevices(string deviceName) { return UnsafeNativeMethods.QueryDosDevices(deviceName).ToArray(); }

		public static char GetDriveLetter(string deviceName, bool throwOnError) { return UnsafeNativeMethods.GetDriveLetter(deviceName, throwOnError); }
	}

	#region Native
	[SuppressUnmanagedCodeSecurity]
	internal static partial class UnsafeNativeMethods //Methods with implementation only
	{
		internal static void ThrowExceptionForHR(int hr)
		{
			var ex = Marshal.GetExceptionForHR(hr);

			if (GetExceptionMessage == null)
			{
				try
				{
					var dyn = new System.Reflection.Emit.DynamicMethod("GetMessage", typeof(string), new Type[] { typeof(Exception) }, typeof(Exception), true);
					var field = typeof(Exception).GetField("_message", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public);
					var gen = dyn.GetILGenerator();
					gen.Emit(System.Reflection.Emit.OpCodes.Ldarg_0);
					gen.Emit(System.Reflection.Emit.OpCodes.Ldfld, field);
					gen.Emit(System.Reflection.Emit.OpCodes.Ret);
					System.Threading.Interlocked.CompareExchange(ref GetExceptionMessage, (Converter<Exception, string>)dyn.CreateDelegate(typeof(Converter<Exception, string>)), null);
				}
				catch { }
			}
			if (GetExceptionMessage != null)
			{
				var msg = GetExceptionMessage(ex);
				var i = msg.IndexOf(" (Exception from HRESULT:");
				if (i >= 0)
				{
					if (SetExceptionMessage == null)
					{
						try
						{
							var dyn = new System.Reflection.Emit.DynamicMethod("SetMessage", null, new Type[] { typeof(Exception), typeof(string) }, typeof(Exception), true);
							var field = typeof(Exception).GetField("_message", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public);
							var gen = dyn.GetILGenerator();
							gen.Emit(System.Reflection.Emit.OpCodes.Ldarg_0);
							gen.Emit(System.Reflection.Emit.OpCodes.Ldarg_1);
							gen.Emit(System.Reflection.Emit.OpCodes.Stfld, field);
							gen.Emit(System.Reflection.Emit.OpCodes.Ret);
							System.Threading.Interlocked.CompareExchange(ref SetExceptionMessage, (Action<Exception, string>)dyn.CreateDelegate(typeof(Action<Exception, string>)), null);
						}
						catch { }
					}
					if (SetExceptionMessage != null)
					{
						SetExceptionMessage(ex, msg.Substring(0, i));
					}
				}
			}
			throw ex;
		}

		public static SafeFileHandle CreateFile(string fileName, Win32FileAccess access, FileShare shareMode, FileMode mode, Win32FileOptions options)
		{
			//var noAccess = FileIOPermissionAccess.NoAccess;
			//if ((access & FileAccess.Read) != 0) { if (mode == FileMode.Append) { throw new ArgumentException("Append access can be requested only in write-only mode."); } noAccess |= FileIOPermissionAccess.Read; }
			//if ((access & FileAccess.Write) != 0) { if (mode == FileMode.Append) { noAccess |= FileIOPermissionAccess.Append; } else { noAccess |= FileIOPermissionAccess.Write; } }
			//var control = AccessControlActions.None;
			//new FileIOPermission(noAccess, control, new string[] { fileName }).Demand();
			Win32FileAccess desiredAccess = access | ((options & Win32FileOptions.Overlapped) == 0 ? Win32FileAccess.Synchronize : Win32FileAccess.None);
			var handle = CreateFile(fileName, desiredAccess, shareMode, IntPtr.Zero, mode, (int)options, IntPtr.Zero);
			if (handle.IsInvalid) { ThrowExceptionForHR(Marshal.GetHRForLastWin32Error()); }
			return handle;
		}

		public static int GetDriveLetter(string deviceName, out char driveLetter)
		{
			unsafe
			{
				driveLetter = '\0';
				int capacity = 260;
				var pChars = stackalloc char[capacity + 1];
				char* pDriveLetter = stackalloc char[3]; // 'X' ':' '\0'
				pDriveLetter[1] = ':';
				pDriveLetter[2] = '\0'; //redundant, but just to make sure
				int result = 0;
				for (pDriveLetter[0] = 'A'; pDriveLetter[0] <= 'Z'; pDriveLetter[0]++)
				{
					bool firstTime = true;
					do
					{
						if (!firstTime)
						{
							capacity <<= 1;
							unsafe { char* pChars2 = stackalloc char[capacity + 1]; pChars = pChars2; }
						}
						result = QueryDosDevice(pDriveLetter, pChars, capacity);
						firstTime = false;
					} while (result == 0 && Marshal.GetLastWin32Error() == ERROR_INSUFFICIENT_BUFFER);

					if (result == 0) { result = Marshal.GetLastWin32Error(); } else { result = 0; }

					if (result == 0)
					{
						bool equal = true;
						for (int i = 0; i < deviceName.Length; i++)
						{
							if (pChars[i] != deviceName[i])
							{
								equal = false;
								break;
							}
						}
						if (equal)
						{
							driveLetter = pDriveLetter[0];
							break;
						}
					}
					else { }
				}
				return result;
			}
		}

		public static SafeFileHandle NtCreateFile(SafeFileHandle root, WinNTObjectAttributes objectAttributes, string kernelFileName, ref Win32FileAccess access, long? allocationSize, Win32FileAttributes attributes, FileShare shareMode, FileCreationDisposition cd, WinNTFileOptions options, bool throwOnError)
		{
			long allocSize = allocationSize.GetValueOrDefault();
			if ((options & (WinNTFileOptions.SynchronousIoNonalert | WinNTFileOptions.SynchronousIoAlert)) != 0) { access |= Win32FileAccess.Synchronize; } //It won't work without (EVER) so might as well be nice
			bool success = false;
			try
			{
				if (root != null)
				{
					root.DangerousAddRef(ref success);
					Debug.Assert(success);
				}
				unsafe
				{
					fixed (char* pName = kernelFileName)
					{
						var name = new UnicodeString((short)(sizeof(char) * kernelFileName.Length), (short)(sizeof(char) * kernelFileName.Length), pName);
						var oa = new ObjectAttributes(root != null ? root.DangerousGetHandle() : IntPtr.Zero, &name, objectAttributes);
						IOStatusBlock iosb;
						SafeFileHandle handle;
						int ntStatus = NtCreateFile(out handle, access, ref oa, out iosb, allocationSize != null ? &allocSize : null, attributes, shareMode, cd, options, IntPtr.Zero, 0);
						if (ntStatus < 0) { if (throwOnError) { CheckAndThrow(ntStatus, root, kernelFileName, true); } else { handle = null; } }
						return handle;
					}
				}
			}
			finally { if (success && root != null) { root.DangerousRelease(); } }
		}

		public static SafeFileHandle NtCreateFileById(SafeFileHandle root, WinNTObjectAttributes objectAttributes, long fileID, ref Win32FileAccess access, long? allocationSize, Win32FileAttributes attributes, FileShare shareMode, FileCreationDisposition cd, WinNTFileOptions options, bool throwOnError)
		{
			options |= WinNTFileOptions.OpenByFileId;
			long allocSize = allocationSize.GetValueOrDefault();
			if ((options & (WinNTFileOptions.SynchronousIoNonalert | WinNTFileOptions.SynchronousIoAlert)) != 0) { access |= Win32FileAccess.Synchronize; } //It won't work without (EVER) so might as well be nice
			bool success = false;
			try
			{
				root.DangerousAddRef(ref success);
				Debug.Assert(success);
				unsafe
				{
					var name = new UnicodeString(sizeof(long), sizeof(long), (char*)&fileID);
					var oa = new ObjectAttributes(root.DangerousGetHandle(), &name, objectAttributes);
					IOStatusBlock iosb;
					SafeFileHandle handle;
					int ntStatus = NtCreateFile(out handle, access, ref oa, out iosb, allocationSize != null ? &allocSize : null, attributes, shareMode, cd, options, IntPtr.Zero, 0);
					if (ntStatus < 0) { if (throwOnError) { CheckAndThrow(ntStatus, root, "0x" + fileID.ToString("X"), true); } else { handle = null; } }
					return handle;
				}
			}
			finally { if (success) { root.DangerousRelease(); } }
		}

		public static SafeFileHandle NtOpenFile(SafeFileHandle root, WinNTObjectAttributes objectAttributes, string kernelFileName, ref Win32FileAccess access, FileShare shareMode, WinNTFileOptions options, bool throwOnError)
		{
			if ((options & (WinNTFileOptions.SynchronousIoNonalert | WinNTFileOptions.SynchronousIoAlert)) != 0) { access |= Win32FileAccess.Synchronize; } //It won't work without (EVER) so might as well be nice
			bool success = false;
			try
			{
				if (root != null)
				{
					root.DangerousAddRef(ref success);
					Debug.Assert(success);
				}
				unsafe
				{
					fixed (char* pName = kernelFileName)
					{
						var name = new UnicodeString((short)(sizeof(char) * kernelFileName.Length), (short)(sizeof(char) * kernelFileName.Length), pName);
						var oa = new ObjectAttributes(root != null ? root.DangerousGetHandle() : IntPtr.Zero, &name, objectAttributes);
						IOStatusBlock iosb;
						SafeFileHandle handle;
						int ntStatus = NtOpenFile(out handle, access, ref oa, out iosb, shareMode, options);
						if (ntStatus < 0) { if (throwOnError) { CheckAndThrow(ntStatus, root, kernelFileName, true); } else { handle = null; } }
						return handle;
					}
				}
			}
			finally { if (success && root != null) { root.DangerousRelease(); } }
		}

		public static SafeFileHandle NtOpenFileById(SafeFileHandle root, WinNTObjectAttributes objectAttributes, long fileID, ref Win32FileAccess fileAccess, FileShare share, WinNTFileOptions options, bool throwOnError)
		{
			options |= WinNTFileOptions.OpenByFileId;
			if ((options & (WinNTFileOptions.SynchronousIoNonalert | WinNTFileOptions.SynchronousIoAlert)) != 0) { fileAccess |= Win32FileAccess.Synchronize; } //It won't work without (EVER) so might as well be nice
			IOStatusBlock iosb;
			bool success = false;
			try
			{
				root.DangerousAddRef(ref success);
				Debug.Assert(success);
				SafeFileHandle handle;
				unsafe
				{
					var name = new UnicodeString(sizeof(long), sizeof(long), (char*)&fileID);
					var oa = new ObjectAttributes(root.DangerousGetHandle(), &name, objectAttributes);
					int ntStatus = UnsafeNativeMethods.NtOpenFile(out handle, fileAccess, ref oa, out iosb, share, options);
					if ((fileAccess & Win32FileAccess.MaximumAllowed) != 0 && ntStatus < 0)
					{ ntStatus = UnsafeNativeMethods.NtOpenFile(out handle, fileAccess & ~Win32FileAccess.MaximumAllowed, ref oa, out iosb, share, options); }
					if (ntStatus < 0) { if (throwOnError) { CheckAndThrow(ntStatus, root, "0x" + fileID.ToString("X"), true); } else { handle = null; } }
					return handle;
				}
			}
			finally { if (success) { root.DangerousRelease(); } }
		}

		public static void NtDeleteFile(SafeFileHandle root, WinNTObjectAttributes objectAttributes, string kernelFileName, bool throwOnError)
		{
			bool success = false;
			try
			{
				if (root != null)
				{
					root.DangerousAddRef(ref success);
					Debug.Assert(success);
				}
				unsafe
				{
					fixed (char* pName = kernelFileName)
					{
						var name = new UnicodeString((short)(sizeof(char) * kernelFileName.Length), (short)(sizeof(char) * kernelFileName.Length), pName);
						var oa = new ObjectAttributes(root != null ? root.DangerousGetHandle() : IntPtr.Zero, &name, objectAttributes);
						int ntStatus = NtDeleteFile(ref oa);
						if (ntStatus < 0) { if (throwOnError) { CheckAndThrow(ntStatus, root, kernelFileName, true); } }
					}
				}
			}
			finally { if (success && root != null) { root.DangerousRelease(); } }
		}

		public static bool NtQueryAttributesFile(SafeFileHandle root, WinNTObjectAttributes objectAttributes, string kernelFileName, bool throwOnError, out FileBasicInformation info)
		{
			bool success = false;
			try
			{
				if (root != null)
				{
					root.DangerousAddRef(ref success);
					Debug.Assert(success);
				}
				unsafe
				{
					fixed (char* pName = kernelFileName)
					{
						var name = new UnicodeString((short)(sizeof(char) * kernelFileName.Length), (short)(sizeof(char) * kernelFileName.Length), pName);
						var oa = new ObjectAttributes(root != null ? root.DangerousGetHandle() : IntPtr.Zero, &name, objectAttributes);
						int ntStatus = NtQueryAttributesFile(ref oa, out info);
						if (ntStatus < 0) { if (throwOnError) { CheckAndThrow(ntStatus, root, kernelFileName, true); } else { return false; } }
						return true;
					}
				}
			}
			finally { if (success && root != null) { root.DangerousRelease(); } }
		}

		private static bool NtQueryDirectoryInformation(SafeFileHandle dirHandle, bool returnSingleEntry, string pattern, bool restartScan, ref IntPtr pBufferHGlobal, ref int bufferSize, FileInformationClass infoClass, TypedReference refToInfoOrInfoArray, bool isList)
		{
			bool stackAlloc;
			if (pBufferHGlobal == IntPtr.Zero && bufferSize == 0) { bufferSize = Marshal.SizeOf(typeof(FileIdBothDirInformation)); }
			if (pBufferHGlobal == IntPtr.Zero) { stackAlloc = bufferSize < STACKALLOC_THRESHOLD; }
			else { stackAlloc = false; }
			int ntstatus;
			IntPtr pBuffer;
			unsafe
			{
				bool firstPass = true;
				if (pBufferHGlobal == IntPtr.Zero)
				{
					if (stackAlloc) { byte* pBuffer2 = stackalloc byte[bufferSize]; pBuffer = (IntPtr)pBuffer2; }
					else { pBuffer = Marshal.AllocHGlobal(bufferSize); }
				}
				else { pBuffer = pBufferHGlobal; }
				try
				{
					fixed (char* pPattern = pattern)
					{
						IOStatusBlock iosb;
						var name = pattern != null ? new UnicodeString((short)(sizeof(char) * pattern.Length), (short)(sizeof(char) * pattern.Length), pPattern) : default(UnicodeString);
						do
						{
							if (!firstPass)
							{
								firstPass = false;
								bufferSize <<= 1;
								if (pBufferHGlobal == IntPtr.Zero)
								{
									bool newStackAlloc = bufferSize < STACKALLOC_THRESHOLD;
									if (stackAlloc)
									{
										if (newStackAlloc) { byte* pBuffer2 = stackalloc byte[bufferSize]; pBuffer = (IntPtr)pBuffer2; }
										else { pBuffer = Marshal.AllocHGlobal(bufferSize); }
									}
									else
									{
										if (newStackAlloc) { Marshal.FreeHGlobal(pBuffer); pBuffer = IntPtr.Zero; byte* pBuffer2 = stackalloc byte[bufferSize]; pBuffer = (IntPtr)pBuffer2; }
										else { pBuffer = Marshal.ReAllocHGlobal(pBuffer, (IntPtr)bufferSize); }
									}
									stackAlloc = newStackAlloc;
								}
								else
								{
									Debug.Assert(pBuffer == pBufferHGlobal);
									pBufferHGlobal = pBuffer = Marshal.ReAllocHGlobal(pBufferHGlobal, (IntPtr)bufferSize);
								}
							}
							ntstatus = NtQueryDirectoryFile(dirHandle, IntPtr.Zero, null, IntPtr.Zero, out iosb, pBuffer, bufferSize, infoClass, returnSingleEntry, pattern != null ? &name : null, restartScan);
							if (WaitIfPending(ntstatus, dirHandle)) { ntstatus = (int)iosb.Status; }
						} while (ntstatus == unchecked((int)0x80000005) | ntstatus == unchecked((int)0xC0000023) | ntstatus == unchecked((int)0xC0000004));
						if (ntstatus == unchecked((int)0x80000006) | ntstatus == unchecked((int)0xC000000F)) //If no more files or none found
						{ return false; }
						else
						{
							CheckAndThrow(ntstatus, dirHandle, null, true);
							if (returnSingleEntry)
							{
								if (infoClass == FileInformationClass.FileIdBothDirectoryInformation) { __refvalue(refToInfoOrInfoArray, FileIdBothDirInformation).MarshalFrom(pBuffer); }
								else if (infoClass == FileInformationClass.FileDirectoryInformation) { __refvalue(refToInfoOrInfoArray, FileDirectoryInformation).MarshalFrom(pBuffer); }
								else if (infoClass == FileInformationClass.FileNamesInformation) { var n = new FileNamesInformation(); n.MarshalFrom(pBuffer); __refvalue(refToInfoOrInfoArray, string) = n.FileName; }
							}
							else
							{
								if (infoClass == FileInformationClass.FileIdBothDirectoryInformation)
								{
									if (isList) { FileIdBothDirInformation.FromBuffer(pBuffer, __refvalue(refToInfoOrInfoArray, List<FileIdBothDirInformation>) ); }
									else { __refvalue(refToInfoOrInfoArray, FileIdBothDirInformation[]) = FileIdBothDirInformation.FromBuffer(pBuffer); }
								}
								else if (infoClass == FileInformationClass.FileDirectoryInformation)
								{
									if (isList) { FileDirectoryInformation.FromBuffer(pBuffer, __refvalue(refToInfoOrInfoArray, List<FileDirectoryInformation>) ); }
									else { __refvalue(refToInfoOrInfoArray, FileDirectoryInformation[]) = FileDirectoryInformation.FromBuffer(pBuffer); }
								}
								else if (infoClass == FileInformationClass.FileNamesInformation) { __refvalue(refToInfoOrInfoArray, string[]) = FileNamesInformation.FromBuffer(pBuffer); }
							}
							return true;
						}
					}
				}
				finally { if (pBufferHGlobal == IntPtr.Zero && pBuffer != IntPtr.Zero && !stackAlloc) { Marshal.FreeHGlobal(pBuffer); } }
			}
		}

		/// <returns><c>true</c> if the wait was pending, or <c>false</c> otherwise.</returns>
		internal static bool WaitIfPending(int ntstatus, SafeFileHandle dirHandle)
		{
			if (ntstatus == 0x00000103 /*If pending*/)
			{
				bool success = false;
				try
				{
					dirHandle.DangerousAddRef(ref success);
					Trace.Assert(success);
					//System.Diagnostics.Debugger.Break();
					WaitOneNative(new SafeWaitHandle(dirHandle.DangerousGetHandle(), false), uint.MaxValue, false, false);
				}
				finally { if (success) { dirHandle.DangerousRelease(); } }
				return true;
			}
			return false;
		}

		/// <returns>An array ov key/value pairs that represent the following mapping: (Disk Number => (Starting Offset, Extent Length))</returns>
		public static KeyValuePair<int, KeyValuePair<long, long>>[] GetVolumeDiskExtents(SafeFileHandle volume)
		{
			unsafe
			{
				int bytesReturned;
				int bufferSize = sizeof(long) + 3 * sizeof(long) * 1;
				byte* pBuffer;
				int lastError;
				do
				{
					bufferSize <<= 1;
					{ byte* pBuffer2 = stackalloc byte[bufferSize]; pBuffer = pBuffer2; }
					if (!DeviceIoControl(volume, IOCTL_VOLUME_GET_VOLUME_DISK_EXTENTS, IntPtr.Zero, 0, (IntPtr)pBuffer, bufferSize, out bytesReturned, null))
					{ lastError = Marshal.GetLastWin32Error(); }
					else { lastError = 0; }
				} while (lastError == ERROR_INSUFFICIENT_BUFFER | lastError == ERROR_MORE_DATA);

				var items = new KeyValuePair<int, KeyValuePair<long, long>>[*(int*)pBuffer];
				long* pItems = (long*)pBuffer + 1;
				for (int i = 0; i < items.Length; i++)
				{ items[i] = new KeyValuePair<int, KeyValuePair<long, long>>(*(int*)&pItems[i * 3], new KeyValuePair<long, long>(pItems[i * 3 + 1], pItems[i * 3 + 2])); }
				return items;
			}
		}

		private static void CheckAndThrow(int ntstatus, SafeFileHandle handleOrParent, string fileName, bool getName)
		{
			if (ntstatus < 0)
			{
				Exception ex;
				int win32Error = RtlNtStatusToDosError(ntstatus);
				int hr = win32Error | unchecked((int)0x80070000);
				ex = Marshal.GetExceptionForHR(hr);

				string fullPath = string.Empty;
				if (handleOrParent != null && getName)
				{
					try
					{
						string drPath = NtQueryNameInformationFile(handleOrParent, true);
						string ntName = NtQueryObjectName(handleOrParent);
						fullPath = GetDriveLetter(ntName.Substring(0, ntName.Length - (drPath == null ? 0 : drPath.Length)), true) + ":" + drPath;
					}
					catch { }
				}
				if (fileName != null)
				{
					if (fileName.StartsWith(@"\??\")) { fileName = fileName.Substring(@"\??\".Length); }
					else if (fileName.StartsWith(@"\DosDevices\")) { fileName = fullPath.Substring(@"\DosDevices\".Length); }
					fullPath += fileName;
				}

				switch (win32Error)
				{
					case 2 /*ERROR_FILE_NOT_FOUND*/:
						if (string.IsNullOrEmpty(fullPath)) { ex = new FileNotFoundException(); }
						else { ex = new FileNotFoundException(string.Format("Could not find file '{0}'.", fullPath), fullPath); }
						break;
					case 3 /*ERROR_PATH_NOT_FOUND*/:
						if (string.IsNullOrEmpty(fullPath)) { ex = new DirectoryNotFoundException(ex.Message); }
						else { ex = new DirectoryNotFoundException(string.Format("Could not find a part of the path '{0}'.", fullPath)); }
						break;
					case 5 /*ERROR_ACCESS_DENIED*/:
						if (string.IsNullOrEmpty(fullPath)) { ex = new UnauthorizedAccessException("Access to the path is denied."); }
						else { ex = new UnauthorizedAccessException(string.Format("Access to the path '{0}' is denied.", fullPath)); }
						break;
					case 186 /*ERROR_ALREADY_EXISTS*/:
						if (fullPath.Length != 0) { ex = new IOException(string.Format("The file '{0}' already exists.", fullPath), hr); }
						break;
					case 206 /*ERROR_FILENAME_EXCED_RANGE*/:
						ex = new PathTooLongException();
						break;
					case 15 /*ERROR_INVALID_DRIVE*/:
						ex = new DriveNotFoundException(string.Format("Could not find the drive '{0}'. The drive might not be ready or might not be mapped.", fullPath));
						break;
					case 87 /*ERROR_INVALID_PARAMETER*/:
						ex = new IOException(new ArgumentException().Message, ex);
						break;
					case 32 /*ERROR_SHARING_VIOLATION*/:
						if (string.IsNullOrEmpty(fullPath)) { ex = new IOException(string.Format("The process cannot access the file because it is being used by another process.", fullPath), hr); }
						else { ex = new IOException(string.Format("The process cannot access the file '{0}' because it is being used by another process.", fullPath), hr); }
						break;
					case 80 /*ERROR_FILE_EXISTS*/:
						if (fullPath.Length != 0) { ex = new IOException(string.Format("The file '{0}' already exists.", fullPath), hr); }
						break;
					case 995 /*ERROR_OPERATION_ABORTED*/:
						ex = new OperationCanceledException();
						break;
				}
				throw ex;
			}
		}

		public static SafeFileHandle DuplicateHandle(SafeFileHandle fileHandle, Win32FileAccess newAccess, bool inherit) { SafeFileHandle duplicated; if (!DuplicateHandle((IntPtr)(-1), fileHandle, (IntPtr)(-1), out duplicated, (int)newAccess, inherit, newAccess == Win32FileAccess.MaximumAllowed ? DUPLICATE_SAME_ACCESS : 0)) { duplicated.SetHandleAsInvalid(); ThrowExceptionForHR(Marshal.GetHRForLastWin32Error()); } return duplicated; }
		public static char GetDriveLetter(string deviceName, bool throwOnError) { char name; int result = GetDriveLetter(deviceName, out name); if (result != 0) { if (throwOnError) { ThrowExceptionForHR(result | unchecked((int)0x80070000)); } else { name = '\0'; } } return name; }
		public static FileBasicInformation NtQueryBasicInformationFile(SafeFileHandle handle) { IOStatusBlock iosb; FileBasicInformation info; unsafe { int ntStatus = NtQueryInformationFile(handle, out iosb, (IntPtr)(&info), sizeof(FileBasicInformation), FileInformationClass.FileBasicInformation); CheckAndThrow(ntStatus, handle, null, true); return info; } }
		public static long NtQueryEndOfFileInformationFile(SafeFileHandle handle) { IOStatusBlock iosb; long eof; unsafe { int ntStatus = NtQueryInformationFile(handle, out iosb, (IntPtr)(&eof), sizeof(long), FileInformationClass.FileEndOfFileInformation); CheckAndThrow(ntStatus, handle, null, true); } return eof; }
		public static WinNTFileOptions NtQueryModeInformationFile(SafeFileHandle handle) { IOStatusBlock iosb; WinNTFileOptions mode; unsafe { int ntStatus = NtQueryInformationFile(handle, out iosb, (IntPtr)(&mode), sizeof(WinNTFileOptions), FileInformationClass.FileModeInformation); CheckAndThrow(ntStatus, handle, null, true); } return mode; }
		public static bool NtQueryFileIdBothDirInformationDirectoryFileSingleEntry(SafeFileHandle dirHandle, string pattern, bool restartScan, ref IntPtr pBufferHGlobal, ref int bufferSizeHint, out FileIdBothDirInformation info) { info = new FileIdBothDirInformation(); return NtQueryDirectoryInformation(dirHandle, true, pattern, restartScan, ref pBufferHGlobal, ref bufferSizeHint, FileInformationClass.FileIdBothDirectoryInformation, __makeref(info), false); }
		public static bool NtQueryFileIdBothDirInformationDirectoryFileMultipleEntries(SafeFileHandle dirHandle, string pattern, bool restartScan, ref IntPtr pBufferHGlobal, ref int bufferSizeHint, List<FileIdBothDirInformation> buffer) { return NtQueryDirectoryInformation(dirHandle, false, pattern, restartScan, ref pBufferHGlobal, ref bufferSizeHint, FileInformationClass.FileIdBothDirectoryInformation, __makeref(buffer), true); }
		public static bool NtQueryFileDirectoryInformationDirectoryFileSingleEntry(SafeFileHandle dirHandle, string pattern, bool restartScan, ref IntPtr pBufferHGlobal, ref int bufferSizeHint, out FileDirectoryInformation info) { info = new FileDirectoryInformation(); return NtQueryDirectoryInformation(dirHandle, true, pattern, restartScan, ref pBufferHGlobal, ref bufferSizeHint, FileInformationClass.FileDirectoryInformation, __makeref(info), false); }
		public static bool NtQueryFileDirectoryInformationDirectoryFileMultipleEntries(SafeFileHandle dirHandle, string pattern, bool restartScan, ref IntPtr pBufferHGlobal, ref int bufferSizeHint, List<FileDirectoryInformation> buffer) { return NtQueryDirectoryInformation(dirHandle, false, pattern, restartScan, ref pBufferHGlobal, ref bufferSizeHint, FileInformationClass.FileDirectoryInformation, __makeref(buffer), true); }
		public static bool NtQueryFileNamesInformationDirectoryFileSingleEntry(SafeFileHandle dirHandle, string pattern, bool restartScan, ref IntPtr pBufferHGlobal, ref int bufferSizeHint, out string info) { info = null; return NtQueryDirectoryInformation(dirHandle, true, pattern, restartScan, ref pBufferHGlobal, ref bufferSizeHint, FileInformationClass.FileNamesInformation, __makeref(info), false); }
		public static string[] NtQueryFileNamesInformationDirectoryFileMultipleEntries(SafeFileHandle dirHandle, string pattern, bool restartScan, ref IntPtr pBufferHGlobal, ref int bufferSizeHint) { string[] info = null; if (!NtQueryDirectoryInformation(dirHandle, false, pattern, restartScan, ref pBufferHGlobal, ref bufferSizeHint, FileInformationClass.FileNamesInformation, __makeref(info), false)) { info = null; } return info; }
		public static long NtQueryFilePositionInformationFile(SafeFileHandle handle) { IOStatusBlock iosb; long position; unsafe { int ntStatus = NtQueryInformationFile(handle, out iosb, (IntPtr)(&position), sizeof(long), FileInformationClass.FilePositionInformation); CheckAndThrow(ntStatus, handle, null, true); } return position; }
		public static long NtQueryInternalInformationFile(SafeFileHandle handle) { IOStatusBlock iosb; long indexNumber; unsafe { int ntStatus = NtQueryInformationFile(handle, out iosb, (IntPtr)(&indexNumber), sizeof(long), FileInformationClass.FileInternalInformation); CheckAndThrow(ntStatus, handle, null, true); } return indexNumber; }
		public static string NtQueryNameInformationFile(SafeFileHandle handle, bool throwOnError)
		{
			IOStatusBlock iosb;
			int nameInfoLength = 1 << (sizeof(short) * 8 - 1);
			unsafe
			{
				int* pNameInfo = stackalloc int[nameInfoLength / sizeof(int)];
				int ntStatus = NtQueryInformationFile(handle, out iosb, (IntPtr)pNameInfo, nameInfoLength, FileInformationClass.FileNameInformation);
				if (ntStatus < 0 && !throwOnError) { return null; }
				CheckAndThrow(ntStatus, handle, null, false);
				return Marshal.PtrToStringUni((IntPtr)(pNameInfo + 1), *pNameInfo / sizeof(char));
			}
		}
		public static int NtQueryObjectAccessMask(SafeFileHandle handle) { unsafe { const int SIZE = 56; int* pData = stackalloc int[SIZE / sizeof(int)]; int resultLength; int ntStatus = NtQueryObject(handle, ObjectInformationClass.ObjectBasicInformation, (IntPtr)pData, SIZE, out resultLength); CheckAndThrow(ntStatus, handle, null, true); return pData[1]; } }
		public static string NtQueryObjectName(SafeFileHandle handle) { unsafe { int nameInfoLength = 1 << (sizeof(short) * 8 - 1); short* pNameInfo = stackalloc short[nameInfoLength / sizeof(short)]; int resultLength; int ntStatus = NtQueryObject(handle, ObjectInformationClass.ObjectNameInformation, (IntPtr)pNameInfo, nameInfoLength, out resultLength); CheckAndThrow(ntStatus, handle, null, false); var pUnicodeString = (UnicodeString*)pNameInfo; return pUnicodeString->ToString(); } }
		public static FileFsSizeInformation NtQueryVolumeSizeInformationFile(SafeFileHandle handle) { IOStatusBlock iosb; FileFsSizeInformation fsInfo; int ntStatus = NtQueryVolumeInformationFile(handle, out iosb, out fsInfo, Marshal.SizeOf(typeof(FileFsSizeInformation)), FSInformationClass.FileFsSizeInformation); CheckAndThrow(ntStatus, handle, null, true); return fsInfo; }
		public static bool NtQueryStandardInformationFile(SafeFileHandle handle, bool throwOnError, out FileStandardInformation info) { IOStatusBlock iosb; unsafe { fixed (FileStandardInformation* pInfo = &info) { unsafe { int ntStatus = NtQueryInformationFile(handle, out iosb, (IntPtr)pInfo, sizeof(FileStandardInformation), FileInformationClass.FileStandardInformation); if (throwOnError) { CheckAndThrow(ntStatus, handle, null, true); } return ntStatus >= 0; } } } }
		public static FileFsDeviceInformation NtQueryVolumeDeviceInformationFile(SafeFileHandle handle) { IOStatusBlock iosb; FileFsDeviceInformation fsInfo; int ntStatus = NtQueryVolumeInformationFile(handle, out iosb, out fsInfo, Marshal.SizeOf(typeof(FileFsDeviceInformation)), FSInformationClass.FileFsDeviceInformation); CheckAndThrow(ntStatus, handle, null, true); return fsInfo; }
		public static void NtSetAllocationInformationFile(SafeFileHandle handle, long allocatedSize) { IOStatusBlock iosb; unsafe { int ntStatus = NtSetInformationFile(handle, out iosb, (IntPtr)(&allocatedSize), sizeof(long), FileInformationClass.FileAllocationInformation); CheckAndThrow(ntStatus, handle, null, true); } }
		public static void NtSetBasicInformationFile(SafeFileHandle handle, FileBasicInformation info) { IOStatusBlock iosb; unsafe { int ntStatus = NtSetInformationFile(handle, out iosb, (IntPtr)(&info), sizeof(FileBasicInformation), FileInformationClass.FileBasicInformation); CheckAndThrow(ntStatus, handle, null, true); } }
		public static void NtSetDispositionInformationFile(SafeFileHandle handle, bool deleteOnClose) { IOStatusBlock iosb; unsafe { int ntStatus = NtSetInformationFile(handle, out iosb, (IntPtr)(&deleteOnClose), sizeof(bool), FileInformationClass.FileDispositionInformation); CheckAndThrow(ntStatus, handle, null, true); } }
		public static void NtSetEndOfFileInformationFile(SafeFileHandle handle, long endOfFile) { IOStatusBlock iosb; unsafe { int ntStatus = NtSetInformationFile(handle, out iosb, (IntPtr)(&endOfFile), sizeof(long), FileInformationClass.FileEndOfFileInformation); CheckAndThrow(ntStatus, handle, null, true); } }
		public static void NtSetPositionInformationFile(SafeFileHandle handle, long position) { IOStatusBlock iosb; unsafe { int ntStatus = NtSetInformationFile(handle, out iosb, (IntPtr)(&position), sizeof(long), FileInformationClass.FilePositionInformation); CheckAndThrow(ntStatus, handle, null, true); } }
		public static void NtSetValidDataLengthInformationFile(SafeFileHandle handle, long length) { IOStatusBlock iosb; unsafe { int ntStatus = NtSetInformationFile(handle, out iosb, (IntPtr)(&length), sizeof(long), FileInformationClass.FileValidDataLengthInformation); CheckAndThrow(ntStatus, handle, null, true); } }

		public static void NtNotifyChangeDirectoryFileSynchronous(SafeFileHandle handle, IntPtr buffer, int bufferLength, FileNotifyFilter filter, bool watchSubtree)
		{
			unsafe
			{
				IOStatusBlock iosb;
				int status = NtNotifyChangeDirectoryFile(handle, IntPtr.Zero, null, IntPtr.Zero, &iosb, buffer, bufferLength, filter, watchSubtree);
				if (WaitIfPending(status, handle)) { status = (int)iosb.Status; }
				CheckAndThrow(status, handle, null, true);
			}
		}

		//Maps size to allocated size
		public static KeyValuePair<string, KeyValuePair<long, long>>[] NtQueryStreamInformationFile(SafeFileHandle handle)
		{
			int bufferSize = Marshal.SizeOf(typeof(FileStreamInformation));
			bool stackAlloc = bufferSize < STACKALLOC_THRESHOLD;
			int ntstatus;
			IntPtr pBuffer;
			unsafe
			{
				if (stackAlloc) { byte* pBuffer2 = stackalloc byte[bufferSize]; pBuffer = (IntPtr)pBuffer2; }
				else { pBuffer = Marshal.AllocHGlobal(bufferSize); }
				try
				{
					do
					{
						bufferSize <<= 1;
						bool newStackAlloc = bufferSize < STACKALLOC_THRESHOLD;
						if (stackAlloc)
						{
							if (newStackAlloc) { byte* pBuffer2 = stackalloc byte[bufferSize]; pBuffer = (IntPtr)pBuffer2; }
							else { pBuffer = Marshal.AllocHGlobal(bufferSize); }
						}
						else
						{
							if (newStackAlloc) { Marshal.FreeHGlobal(pBuffer); pBuffer = IntPtr.Zero; byte* pBuffer2 = stackalloc byte[bufferSize]; pBuffer = (IntPtr)pBuffer2; }
							else { pBuffer = Marshal.ReAllocHGlobal(pBuffer, (IntPtr)bufferSize); }
						}
						stackAlloc = newStackAlloc;
						IOStatusBlock iosb;
						ntstatus = NtQueryInformationFile(handle, out iosb, pBuffer, bufferSize, FileInformationClass.FileStreamInformation);
					} while (ntstatus == unchecked((int)0x80000005) | ntstatus == unchecked((int)0xC0000023) | ntstatus == unchecked((int)0xC0000004));
					CheckAndThrow(ntstatus, handle, null, true);

					int count = 0;
					var pStreams = (FileStreamInformation*)pBuffer;
					for (; ; )
					{
						count++;
						if (pStreams->NextEntryOffset == 0) { break; }
						else { pStreams = (FileStreamInformation*)((byte*)pStreams + pStreams->NextEntryOffset); }
					}

					var result = new KeyValuePair<string, KeyValuePair<long, long>>[count];
					for (int i = 0; i < result.Length; i++)
					{
						result[i] = new KeyValuePair<string, KeyValuePair<long, long>>(Marshal.PtrToStringUni((IntPtr)pStreams->StreamName, pStreams->StreamNameLength / sizeof(char)), new KeyValuePair<long, long>(pStreams->StreamSize, pStreams->StreamAllocationSize));
						pStreams = (FileStreamInformation*)((byte*)pStreams + pStreams->NextEntryOffset);
					}
					return result;

				}
				finally { if (pBuffer != IntPtr.Zero && !stackAlloc) { Marshal.FreeHGlobal(pBuffer); } }
			}
		}
		
		public static void NtSetRenameOrLinkInformationFile(SafeFileHandle handle, bool replaceIfExists, SafeFileHandle targetRootDirectory, string newNameOrPath, bool isRenameInsteadOfLink)
		{
			IOStatusBlock iosb;
			unsafe
			{
				int bufferSize = sizeof(FileRenameOrLinkInformation) + newNameOrPath.Length * sizeof(char);
				byte* pBuffer = stackalloc byte[bufferSize];
				var pInfo = (FileRenameOrLinkInformation*)pBuffer; //Assumes aligned
				pInfo->FileNameLength = newNameOrPath.Length * sizeof(char);
				pInfo->ReplaceIfExists = replaceIfExists;
				for (int i = 0; i < newNameOrPath.Length; i++) { pInfo->FileName[i] = newNameOrPath[i]; }
				bool success = false;
				try
				{
					if (targetRootDirectory != null) { targetRootDirectory.DangerousAddRef(ref success); Debug.Assert(success); pInfo->RootDirectory = targetRootDirectory.DangerousGetHandle(); }
					else { pInfo->RootDirectory = IntPtr.Zero; }
					int ntstatus = NtSetInformationFile(handle, out iosb, (IntPtr)pBuffer, bufferSize, isRenameInsteadOfLink ? FileInformationClass.FileRenameInformation : FileInformationClass.FileLinkInformation);
					CheckAndThrow(ntstatus, handle, null, true);
				}
				finally { if (success) { targetRootDirectory.DangerousRelease(); } }
			}
		}

		public static string QueryFirstDosDevice(string deviceName)
		{
			unsafe
			{
				int capacity = 260;
				var pChars = stackalloc char[capacity + 1];
				int result;
				do
				{
					capacity <<= 1;
					unsafe { char* pChars2 = stackalloc char[capacity + 1]; pChars = pChars2; }
					result = QueryDosDevice(deviceName, pChars, capacity);
				} while (result == 0 && Marshal.GetLastWin32Error() == ERROR_INSUFFICIENT_BUFFER);
				if (result == 0) { ThrowExceptionForHR(Marshal.GetHRForLastWin32Error()); }
				return Marshal.PtrToStringAuto((IntPtr)pChars);
			}
		}

		public static List<string> QueryDosDevices(string deviceName)
		{
			unsafe
			{
				var devices = new List<string>();
				int capacity = 260;
				var pChars = (char*)Marshal.AllocHGlobal((capacity + 1) * sizeof(char));
				try
				{
					int result;
					do
					{
						capacity <<= 1;
						pChars = (char*)Marshal.ReAllocHGlobal((IntPtr)pChars, (IntPtr)capacity);
						result = QueryDosDevice(deviceName, pChars, capacity / sizeof(char) - 1);
					} while (result == 0 && Marshal.GetLastWin32Error() == ERROR_INSUFFICIENT_BUFFER);
					if (result == 0) { ThrowExceptionForHR(Marshal.GetHRForLastWin32Error()); }

					int i = 0;
					while (pChars[i] != '\0')
					{
						var str = Marshal.PtrToStringAuto((IntPtr)(&pChars[i]));
						i += str.Length + 1;
						devices.Add(str);
					}
				}
				finally { Marshal.FreeHGlobal((IntPtr)pChars); }
				return devices;
			}
		}

		public static int ReadFile(SafeFileHandle handle, IntPtr pData, int bytesToRead, long? offset)
		{
			var overlapped = new NativeOverlapped() { OffsetLow = unchecked((int)offset.GetValueOrDefault()), OffsetHigh = unchecked((int)(offset.GetValueOrDefault() >> 32)) };
			unsafe
			{
				var pOverlapped = offset != null ? &overlapped : null;
				int bytesRead;
				bool success = ReadFile(handle, pData, bytesToRead, &bytesRead, pOverlapped);
				if (!success)
				{
					if (Marshal.GetLastWin32Error() == ERROR_INSUFFICIENT_RESOURCES && offset != null)
					{
						long offsetValue = offset.Value;
						int timesRead = 0;
						int chunkSize = bytesToRead;
						do
						{
							chunkSize >>= 1;
							success = ReadFile(handle, (IntPtr)((byte*)pData + timesRead * chunkSize), chunkSize, null, pOverlapped);
							if (success) { success = GetOverlappedResult(handle, pOverlapped, out bytesRead, true); }
						} while (!success && Marshal.GetLastWin32Error() == ERROR_INSUFFICIENT_RESOURCES);
						if (success & chunkSize > 0 & pOverlapped != null)
						{
							timesRead++;
							while (chunkSize * timesRead < bytesToRead && success)
							{
								int actualChunkSize = Math.Min(chunkSize, bytesToRead - chunkSize * timesRead);
								offsetValue += chunkSize;
								pOverlapped->OffsetLow = unchecked((int)offsetValue);
								pOverlapped->OffsetHigh = unchecked((int)(offsetValue >> 32));
								success = ReadFile(handle, (IntPtr)((byte*)pData + timesRead * chunkSize), actualChunkSize, null, pOverlapped);
								if (success) { success = GetOverlappedResult(handle, pOverlapped, out bytesRead, true); }
								else if (Marshal.GetLastWin32Error() == ERROR_INSUFFICIENT_RESOURCES) { }
								timesRead++;
							}
						}
					}
				}
				if (!success && Marshal.GetLastWin32Error() == ERROR_IO_PENDING)
				{
					success = GetOverlappedResult(handle, pOverlapped, out bytesRead, true);
				}
				if (!success)
				{
					int le = Marshal.GetLastWin32Error();
					if (le == ERROR_HANDLE_EOF) { bytesRead = 0; }
					else { ThrowExceptionForHR(Marshal.GetHRForLastWin32Error()); }
				}
				Debug.Assert(bytesRead <= bytesToRead);
				return bytesRead;
			}
		}

		/// <returns>Returns <c>true</c> if the file was read synchronously, or <c>false</c> if the read is pending.</returns>
		public static unsafe bool ReadFileAsync(SafeFileHandle handle, IntPtr pData, int bytesToRead, NativeOverlapped* pOverlapped, IOCompletionCallback completionCallback)
		{
			unsafe
			{
				int errorCode = 0;
				bool success;
#if FILE_EX
				success = ReadFileEx(handle, pData, bytesToRead, pOverlapped, completionCallback);
				int le = Marshal.GetLastWin32Error();
				// Does ReadFileEx() work as intended?
				if (!success || le != 0) { Debugger.Break(); }
#else
				if (completionCallback != null) { throw new NotSupportedException("Completion callbacks are not supported."); }
				success = ReadFile(handle, pData, bytesToRead, &bytesToRead, pOverlapped);
#endif
				if (!success) { errorCode = Marshal.GetLastWin32Error(); }
				if (errorCode == 0x57 && bytesToRead == 0) { throw new ArgumentOutOfRangeException("bytesToRead", bytesToRead, "Length must be positive."); }
				switch (errorCode)
				{
					case 0:
						return true;
					case ERROR_IO_PENDING:
						return false;
					default:
						throw Marshal.GetExceptionForHR(Marshal.GetHRForLastWin32Error());
				}
			}
		}

		public static string RtlDosPathNameToNtPathName(string dosPath) { UnicodeString pathName; bool result = RtlDosPathNameToNtPathName_U(dosPath, out pathName, IntPtr.Zero, IntPtr.Zero); return result ? pathName.ToString() : null; }
		public static long SetFilePointerEx(SafeFileHandle handle, long position, SeekOrigin origin) { if (!SetFilePointerEx(handle, position, out position, origin)) { ThrowExceptionForHR(Marshal.GetHRForLastWin32Error()); } return position; }
		public static bool TryFlushFileBuffers(SafeFileHandle handle) { return FlushFileBuffers(handle); }
		public static int WaitOneNative(SafeWaitHandle waitHandle, uint millisecondsTimeout, bool hasThreadAffinity, bool exitContext) { if (__WaitOneNativeDelegate == null) { Interlocked.CompareExchange(ref __WaitOneNativeDelegate, (WaitOneNativeDelegate)Delegate.CreateDelegate(typeof(WaitOneNativeDelegate), typeof(WaitHandle).GetMethod("WaitOneNative", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)), null); } return __WaitOneNativeDelegate(waitHandle, millisecondsTimeout, hasThreadAffinity, exitContext); }

		public static int WriteFile(SafeFileHandle handle, IntPtr pData, int bytesToWrite, long? offset)
		{
			var overlapped = new NativeOverlapped() { OffsetLow = unchecked((int)offset.GetValueOrDefault()), OffsetHigh = unchecked((int)(offset.GetValueOrDefault() >> 32)) };
			unsafe
			{
				var pOverlapped = offset != null ? &overlapped : null;
				int bytesWritten;
				bool success = WriteFile(handle, pData, bytesToWrite, &bytesWritten, pOverlapped);
				if (!success)
				{
					if (Marshal.GetLastWin32Error() == ERROR_INSUFFICIENT_RESOURCES && offset != null)
					{
						long offsetValue = offset.Value;
						int timesWritten = 0;
						int chunkSize = bytesToWrite;
						do
						{
							chunkSize >>= 1;
							success = WriteFile(handle, (IntPtr)((byte*)pData + timesWritten * chunkSize), chunkSize, null, pOverlapped);
							if (success) { success = GetOverlappedResult(handle, pOverlapped, out bytesWritten, true); }
						} while (!success && Marshal.GetLastWin32Error() == ERROR_INSUFFICIENT_RESOURCES);
						if (success & chunkSize > 0 & pOverlapped != null)
						{
							timesWritten++;
							while (chunkSize * timesWritten < bytesToWrite && success)
							{
								int actualChunkSize = Math.Min(chunkSize, bytesToWrite - chunkSize * timesWritten);
								offsetValue += chunkSize;
								pOverlapped->OffsetLow = unchecked((int)offsetValue);
								pOverlapped->OffsetHigh = unchecked((int)(offsetValue >> 32));
								success = WriteFile(handle, (IntPtr)((byte*)pData + timesWritten * chunkSize), actualChunkSize, null, pOverlapped);
								if (success) { success = GetOverlappedResult(handle, pOverlapped, out bytesWritten, true); }
								else if (Marshal.GetLastWin32Error() == ERROR_INSUFFICIENT_RESOURCES) { }
								timesWritten++;
							}
						}
					}
				}
				if (!success && (Marshal.GetLastWin32Error() != 997 || !GetOverlappedResult(handle, pOverlapped, out bytesWritten, true)))
				{ ThrowExceptionForHR(Marshal.GetHRForLastWin32Error()); }
				Debug.Assert(bytesWritten <= bytesToWrite);
				return bytesWritten;
			}
		}

		/// <returns>Returns <c>true</c> if the file was Write synchronously, or <c>false</c> if the Write is pending.</returns>
		public static unsafe bool WriteFileAsync(SafeFileHandle handle, IntPtr pData, int bytesToWrite, NativeOverlapped* pOverlapped, IOCompletionCallback completionCallback)
		{
			if (completionCallback != null) { throw new NotSupportedException("Completion callbacks are not supported."); }
			unsafe
			{
				int errorCode = 0;
				bool success;
				//success = WriteFileEx(handle, pData, bytesToWrite, pOverlapped, completionCallback);
				success = WriteFile(handle, pData, bytesToWrite, &bytesToWrite, pOverlapped);
				if (!success) { errorCode = Marshal.GetLastWin32Error(); }
				switch (errorCode)
				{
					case 0:
						return true;
					case ERROR_IO_PENDING:
						return false;
					default:
						throw Marshal.GetExceptionForHR(Marshal.GetHRForLastWin32Error());
				}
			}
		}
	}

	internal static partial class UnsafeNativeMethods //Types, constants, and DLL imports only
	{
		private delegate void Action<T1, T2>(T1 param1, T2 param2);
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static Action<Exception, string> SetExceptionMessage;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static Converter<Exception, string> GetExceptionMessage;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private const int IOCTL_VOLUME_GET_VOLUME_DISK_EXTENTS = 'V' << 16 | 0 << 14 | 0 << 2 | 0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private const int DUPLICATE_SAME_ACCESS = 0x2;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private const int OPEN_BY_FILE_ID = 0x2000;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private const int ERROR_INSUFFICIENT_BUFFER = 122;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private const int ERROR_MORE_DATA = 234;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private const int ERROR_INSUFFICIENT_RESOURCES = 1450;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private const int ERROR_IO_PENDING = 997;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private const int ERROR_HANDLE_EOF = 38;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal const int STACKALLOC_THRESHOLD = 8 * 1024;
		
		#region DLL Imports
		[DllImport("Kernel32.dll", CharSet = CharSet.Auto, SetLastError = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
		private static extern SafeFileHandle CreateFile(string lpFileName, Win32FileAccess dwDesiredAccess, FileShare dwShareMode, IntPtr securityAttrs, FileMode dwCreationDisposition, int dwFlagsAndAttributes, IntPtr hTemplateFile);

		[DllImport("Kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern unsafe bool ReadFileEx(SafeFileHandle handle, [In] IntPtr bytes, int numBytesToRead, [In] NativeOverlapped* overlapped, IOCompletionCallback callback);

		[DllImport("Kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern unsafe bool WriteFileEx(SafeFileHandle handle, [Out] IntPtr bytes, int numBytesToRead, [In] NativeOverlapped* overlapped, IOCompletionCallback callback);

		[DllImport("Kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool DuplicateHandle([In] IntPtr hSourceProcessHandle, [In] IntPtr hSourceHandle, [In] IntPtr hTargetProcessHandle, [Out] out IntPtr lpTargetHandle, [In] int dwDesiredAccess, [In, MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, [In] int dwOptions);

		[DllImport("Kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool FlushFileBuffers(SafeFileHandle handle);

		[DllImport("Kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool SetFilePointerEx([In] SafeFileHandle fileHandle, [In] long liDistanceToMove, [Out, Optional] out long lpNewFilePointer, [In] SeekOrigin dwMoveMethod /*I hope the enumeration's values are correct...*/);

		[DllImport("Kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern unsafe bool ReadFile(SafeFileHandle handle, [Out] IntPtr bytes, int numBytesToRead, int* numBytesRead, [In] NativeOverlapped* mustBeZero);

		[DllImport("Kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern unsafe bool WriteFile(SafeFileHandle handle, [In] IntPtr bytes, int numBytesToRead, int* numBytesRead, [In] NativeOverlapped* mustBeZero);

		[DllImport("Kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern unsafe bool DeviceIoControl([In] SafeFileHandle hDevice, [In] int dwIoControlCode, [In] IntPtr lpInBuffer, [In] int nInBufferSize, [Out] IntPtr lpOutBuffer, [In] int nOutBufferSize, [Out] out int lpBytesReturned, [In] NativeOverlapped* lpOverlapped);

		[DllImport("Kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern unsafe bool GetOverlappedResult(SafeFileHandle fileHandle, NativeOverlapped* lpOverlapped, out int lpNumberOfBytesTransferred, [MarshalAs(UnmanagedType.Bool)] bool bWait);

		[DllImport("Kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool DuplicateHandle([In] IntPtr hSourceProcessHandle, [In] SafeFileHandle hSourceHandle, [In] IntPtr hTargetProcessHandle, [Out] out SafeFileHandle lpTargetHandle, [In] int dwDesiredAccess, [In, MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, [In] int dwOptions);

		[DllImport("NTDLL.dll", ThrowOnUnmappableChar = true, BestFitMapping = false, SetLastError = false)]
		private static extern int NtDeleteFile([In] ref ObjectAttributes ObjectAttributes);

		[DllImport("NTDLL.dll", ThrowOnUnmappableChar = true, BestFitMapping = false, SetLastError = false)]
		private static extern unsafe int NtCreateFile([Out] out SafeFileHandle FileHandle, [In] Win32FileAccess DesiredAccess, [In] ref ObjectAttributes ObjectAttributes, [Out] out IOStatusBlock IoStatusBlock, [In, Optional] long* AllocationSize, [In] Win32FileAttributes FileAttributes, [In] FileShare ShareAccess, [In] FileCreationDisposition CreateDisposition, [In] WinNTFileOptions CreateOptions, [In, Optional] IntPtr EaBuffer, [In] int EaLength);
		
		[DllImport("NTDLL.dll", ThrowOnUnmappableChar = true, BestFitMapping = false, SetLastError = false)]
		private static extern int NtOpenFile([Out] out SafeFileHandle FileHandle, [In] Win32FileAccess DesiredAccess, [In] ref ObjectAttributes ObjectAttributes, [Out] out IOStatusBlock IoStatusBlock, [In] FileShare ShareAccess, [In] WinNTFileOptions OpenOptions);

		[DllImport("NTDLL.dll", ThrowOnUnmappableChar = true, BestFitMapping = false, SetLastError = false)]
		private static extern int NtQueryInformationFile([In] SafeFileHandle FileHandle, [Out] out IOStatusBlock IoStatusBlock, [Out] IntPtr FileInformation, [In] int Length, [In] FileInformationClass FileInformationClass);

		[DllImport("NTDLL.dll", ThrowOnUnmappableChar = true, BestFitMapping = false, SetLastError = false)]
		private static extern int NtQueryVolumeInformationFile([In] SafeFileHandle FileHandle, [Out] out IOStatusBlock IoStatusBlock, [Out] out FileFsSizeInformation FsInformation, [In] int Length, [In] FSInformationClass FsInformationClass);

		[DllImport("NTDLL.dll", ThrowOnUnmappableChar = true, BestFitMapping = false, SetLastError = false)]
		private static extern int NtQueryVolumeInformationFile([In] SafeFileHandle FileHandle, [Out] out IOStatusBlock IoStatusBlock, [Out] out FileFsDeviceInformation FsInformation, [In] int Length, [In] FSInformationClass FsInformationClass);

		[DllImport("NTDLL.dll", ThrowOnUnmappableChar = true, BestFitMapping = false, SetLastError = false)]
		private static extern int NtSetInformationFile([In] SafeFileHandle FileHandle, [Out] out IOStatusBlock IoStatusBlock, [In] IntPtr FileInformation, [In] int Length, [In] FileInformationClass FileInformationClass);

		[DllImport("NTDLL.dll", ThrowOnUnmappableChar = true, BestFitMapping = false, SetLastError = false)]
		private static extern int RtlNtStatusToDosError([In] int NtStatus);

		[DllImport("NTDLL.dll", ThrowOnUnmappableChar = true, BestFitMapping = false, SetLastError = false)]
		private static extern int NtQueryObject([In] SafeHandle ObjectHandle, [In, Optional] ObjectInformationClass ObjectInformationClass, [Out] IntPtr ObjectInformation, [In] int Length, [Out] out int ResultLength);

		[DllImport("NTDLL.dll", ThrowOnUnmappableChar = true, BestFitMapping = false, SetLastError = false)]
		private static extern unsafe int NtNotifyChangeDirectoryFile([In] SafeFileHandle FileHandle, [In, Optional] IntPtr Event, [In, Optional] IOApcRoutine ApcRoutine, [In, Optional] IntPtr ApcContext, [Out] IOStatusBlock* IoStatusBlock, [Out] IntPtr Buffer, [In] int BufferLength, [In] FileNotifyFilter NotifyFilter, [In, MarshalAs(UnmanagedType.I1)] bool WatchSubtree);

		[DllImport("Kernel32.dll", ThrowOnUnmappableChar = true, BestFitMapping = false, SetLastError = true, CharSet = CharSet.Unicode)]
		private static extern unsafe int QueryDosDevice([In, MarshalAs(UnmanagedType.LPTStr)] string lpDeviceName, char* lpTargetPath, [In] int ucchMax);

		[DllImport("NTDLL.dll", ThrowOnUnmappableChar = true, BestFitMapping = false, SetLastError = false)]
		private static extern bool RtlDosPathNameToNtPathName_U([In, MarshalAs(UnmanagedType.LPWStr)] string DosPathName, [Out] out UnicodeString NtPathName, [Out] IntPtr NtFileNamePart, [Out] IntPtr DirectoryInfo);

		[DllImport("Kernel32.dll", ThrowOnUnmappableChar = true, BestFitMapping = false, SetLastError = true, CharSet = CharSet.Unicode)]
		private static extern unsafe int QueryDosDevice([In] char* lpDeviceName, char* lpTargetPath, [In] int ucchMax);

		[DllImport("NTDLL.dll", ThrowOnUnmappableChar = true, BestFitMapping = false, SetLastError = false)]
		private static extern unsafe int NtQueryDirectoryFile([In] SafeFileHandle FileHandle, [In, Optional] IntPtr Event, [In, Optional] Delegate ApcRoutine, [In, Optional] IntPtr ApcContext, [Out] out IOStatusBlock IoStatusBlock, [Out] IntPtr FileInformation, [In] int Length, [In] FileInformationClass FileInformationClass, [In, MarshalAs(UnmanagedType.I1)] bool ReturnSingleEntry, [In, Optional] UnicodeString* FileName, [In, MarshalAs(UnmanagedType.I1)] bool RestartScan);

		[DllImport("NTDLL.dll", ThrowOnUnmappableChar = true, BestFitMapping = false, SetLastError = false)]
		private static extern int NtQueryAttributesFile([In] ref ObjectAttributes ObjectAttributes, [Out] out FileBasicInformation FileAttributes);

		//[DllImport("NTDLL.dll", ThrowOnUnmappableChar = true, BestFitMapping = false, SetLastError = false)]
		//public static extern int NtQueryFullAttributesFile([In] ref ObjectAttributes ObjectAttributes, [Out] out FileNetworkOpenInformation FileAttributes);
		#endregion

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static WaitOneNativeDelegate __WaitOneNativeDelegate;
		private delegate int WaitOneNativeDelegate(SafeWaitHandle waitHandle, uint millisecondsTimeout, bool hasThreadAffinity, bool exitContext);
		[StructLayout(LayoutKind.Sequential, Pack = 8)]
		public struct FileBasicInformation { public long CreationTime; public long LastAccessTime; public long LastWriteTime; public long ChangeTime; public Win32FileAttributes FileAttributes; }
		[StructLayout(LayoutKind.Sequential, Pack = 8)]
		public struct FileStandardInformation { public long AllocationSize; public long EndOfFile; public int NumberOfLinks; [MarshalAs(UnmanagedType.I1)] public bool DeletePending; [MarshalAs(UnmanagedType.I1)] public bool Directory; }
		[StructLayout(LayoutKind.Sequential, Pack = 8)]
		private struct FileStreamInformation { internal int NextEntryOffset; internal int StreamNameLength; public long StreamSize; public long StreamAllocationSize; public unsafe fixed char StreamName[1]; }
		[StructLayout(LayoutKind.Sequential, Pack = 8)]
		public struct FileFsSizeInformation { public long TotalAllocationUnits; public long AvailableAllocationUnits; public int SectorsPerAllocationUnit; public int BytesPerSector; }
		[StructLayout(LayoutKind.Sequential, Pack = 8)]
		public struct FileFsDeviceInformation { public Win32DeviceType DeviceType; public int Characteristics; }
		private enum ObjectInformationClass { ObjectBasicInformation = 0, ObjectNameInformation = 1, ObjectTypeInformation = 2, ObjectAllInformation = 3, ObjectDataInformation = 4 }
		private enum FSInformationClass { FileFsVolumeInformation = 1, FileFsSizeInformation = 3, FileFsDeviceInformation = 4, FileFsAttributeInformation = 5, FileFsControlInformation = 6, FileFsFullSizeInformation = 7 }
		private struct UnicodeString { public short ByteLength; public short MaximumLength; public unsafe char* Buffer; public unsafe UnicodeString(short length, short maxLength, char* @string) { this.ByteLength = length; this.MaximumLength = maxLength; this.Buffer = @string; } public override string ToString() { unsafe { return this.Buffer != null ? Marshal.PtrToStringUni(new IntPtr(this.Buffer), this.ByteLength / 2) : null; } } }
		internal struct IOStatusBlock { public IntPtr Status; public IntPtr Information; }
		private struct ObjectAttributes { public unsafe ObjectAttributes(IntPtr rootDirectory, UnicodeString* objectName, WinNTObjectAttributes attributes) : this() { this.Length = (int)Marshal.SizeOf(typeof(ObjectAttributes)); this.RootDirectory = rootDirectory; this.ObjectName = objectName; this.Attributes = attributes; this.SecurityDescriptor = IntPtr.Zero; this.SecurityQualityOfService = IntPtr.Zero; } public int Length; public IntPtr RootDirectory; public unsafe UnicodeString* ObjectName; public WinNTObjectAttributes Attributes; public IntPtr SecurityDescriptor; public IntPtr SecurityQualityOfService; }
		private struct FileRenameOrLinkInformation { [MarshalAs(UnmanagedType.I1)] public bool ReplaceIfExists; public IntPtr RootDirectory; public int FileNameLength; public unsafe fixed char FileName[1]; }
		internal unsafe delegate void IOApcRoutine([In] IntPtr ApcContext, [In] IOStatusBlock* IoStatusBlock, [In] int Reserved);
		internal enum FileInformationClass
		{
			FileDirectoryInformation = 1, FileFullDirectoryInformation = 2, FileBothDirectoryInformation = 3, FileBasicInformation = 4, FileStandardInformation = 5, FileInternalInformation = 6, FileEaInformation = 7, FileAccessInformation = 8, FileNameInformation = 9, FileRenameInformation = 10,
			FileLinkInformation = 11, FileNamesInformation = 12, FileDispositionInformation = 13, FilePositionInformation = 14, FileFullEaInformation = 15, FileModeInformation = 16, FileAlignmentInformation = 17, FileAllInformation = 18, FileAllocationInformation = 19, FileEndOfFileInformation = 20,
			FileAlternateNameInformation = 21, FileStreamInformation = 22, FilePipeInformation = 23, FilePipeLocalInformation = 24, FilePipeRemoteInformation = 25, FileMailslotQueryInformation = 26, FileMailslotSetInformation = 27, FileCompressionInformation = 28, FileObjectIdInformation = 29, FileCompletionInformation = 30,
			FileMoveClusterInformation = 31, FileQuotaInformation = 32, FileReparsePointInformation = 33, FileNetworkOpenInformation = 34, FileAttributeTagInformation = 35, FileTrackingInformation = 36, FileIdBothDirectoryInformation = 37, FileIdFullDirectoryInformation = 38, FileValidDataLengthInformation = 39, FileShortNameInformation = 40,
		}

	}
	#endregion

	#region Other Types
	public enum FileAction
	{
		None = 0,
		Added = 0x00000001,
		Removed = 0x00000002,
		Modified = 0x00000003,
		RenamedOldName = 0x00000004,
		RenamedNewName = 0x00000005,
		AddedStream = 0x00000006,
		RemovedStream = 0x00000007,
		ModifiedStream = 0x00000008,
		RemovedByDelete = 0x00000009,
		IdNotTunnelled = 0x0000000A,
		TunnelledIdCollision = 0x0000000B,
	}

	[Flags]
	public enum FileNotifyFilter
	{
		None = 0,
		FileName = 0x00000001,
		DirectoryName = 0x00000002,
		Attributes = 0x00000004,
		Size = 0x00000008,
		LastWrite = 0x00000010,
		LastAccess = 0x00000020,
		Creation = 0x00000040,
		ExtendedAttribute = 0x00000080,
		Security = 0x00000100,
		StreamName = 0x00000200,
		StreamSize = 0x00000400,
		StreamWrite = 0x00000800,
	}

	[Flags]
	public enum Win32FileAttributes : int
	{
		None = 0,
		/// <summary>
		/// <para>A file or directory that is read-only.</para>
		/// <para>For a file, applications can read the file, but cannot write to it or delete it.</para>
		/// <para>For a directory, applications cannot delete it.</para>
		/// </summary>
		ReadOnly = 0x1,
		/// <summary>The file or directory is hidden. It is not included in an ordinary directory listing.</summary>
		Hidden = 0x2,
		/// <summary>A file or directory that the operating system uses a part of, or uses exclusively.</summary>
		System = 0x4,
		Unknown8 = 0x8,
		/// <summary>The handle that identifies a directory.</summary>
		Directory = 0x10,
		/// <summary>
		/// <para>A file or directory that is an archive file or directory.</para>
		/// <para>Applications use this attribute to mark files for backup or removal.</para>
		/// </summary>
		Archive = 0x20,
		/// <summary>Reserved; do not use.</summary>
		Device = 0x40,
		/// <summary>
		/// <para>A file or directory that does not have other attributes set. </para>
		/// <para>This attribute is valid only when used alone.</para>
		/// </summary>
		Normal = 0x80,
		/// <summary>
		/// <para>A file that is being used for temporary storage.</para>
		/// <para>File systems avoid writing data back to mass storage if sufficient cache memory is available, because typically, an application deletes a temporary file after the handle is closed. In that scenario, the system can entirely avoid writing the data. Otherwise, the data is written after the handle is closed.</para>
		/// </summary>
		Temporary = 0x100,
		/// <summary>A file that is a sparse file.</summary>
		SparseFile = 0x200,
		/// <summary>A file or directory that has an associated reparse point, or a file that is a symbolic link.</summary>
		ReparsePoint = 0x400,
		/// <summary>
		/// <para>A file or directory that is compressed.</para>
		/// <para>For a file, all of the data in the file is compressed.</para>
		/// <para>For a directory, compression is the default for newly created files and subdirectories.</para>
		/// </summary>
		Compressed = 0x800,
		/// <summary>
		/// <para>The data of a file is not available immediately.</para>
		/// <para>This attribute indicates that the file data is physically moved to offline storage. This attribute is used by Remote Storage, which is the hierarchical storage management software. Applications should not arbitrarily change this attribute.</para>
		/// </summary>
		Offline = 0x1000,
		/// <summary>The file is not to be indexed by the content indexing service.</summary>
		NotContentIndexed = 0x2000,
		/// <summary>
		/// <para>A file or directory that is encrypted.</para>
		/// <para>For a file, all data streams in the file are encrypted.</para>
		/// <para>For a directory, encryption is the default for newly created files and subdirectories.</para>
		/// </summary>
		Encrypted = 0x4000,
		/// <summary>A file is a virtual file.</summary>
		Virtual = 0x10000,
		I30IndexPresent = 0x10000000,
		ViewIndexPresent = 0x20000000,
	}

	public enum FileCreationDisposition { Supercede = 0, Open = 1, Create = 2, OpenIf = 3, Overwrite = 4, OverwriteIf = 5 }
	public enum FileCreationResult { Superceded = 0, Opened = 1, Created = 2, Overwritten = 3, Exists = 4, DoesNotExist = 5 }

	[Flags]
	public enum Win32FileOptions : int { None = 0, WriteThrough = unchecked((int)0x80000000), Overlapped = 0x40000000, NoBuffering = 0x20000000, RandomAccess = 0x10000000, SequentialScan = 0x8000000, DeleteOnClose = 0x4000000, BackupSemantics = 0x2000000, PosixSemantics = 0x1000000, OpenReparsePoint = 0x200000, OpenNoRecall = 0x100000, FirstPipeInstance = 0x80000 }

	[Flags]
	public enum WinNTFileOptions : int
	{
		None = 0,
		DirectoryFile = 0x1,
		WriteThrough = 0x2,
		SequentialOnly = 0x4,
		NoIntermediateBuffering = 0x8,
		SynchronousIoAlert = 0x10,
		SynchronousIoNonalert = 0x20,
		NonDirectoryFile = 0x40,
		CreateTreeConnection = 0x80,
		CompleteIfOplocked = 0x100,
		NoEaKnowledge = 0x200,
		OpenRemoteInstance = 0x400,
		RandomAccess = 0x800,
		DeleteOnClose = 0x1000,
		OpenByFileId = 0x2000,
		OpenForBackupIntent = 0x4000,
		NoCompression = 0x8000,
		OpenRequiringOplock = 0x10000,
		DisallowExclusive = 0x20000,
		ReserveOpfilter = 0x100000,
		OpenReparsePoint = 0x200000,
		OpenNoRecall = 0x400000,
		OpenForFreeSpaceQuery = 0x800000,
	}

	public enum Win32DeviceType : int
	{
		Acpi = 0x32, Battery = 0x29, Beep = 0x1, BusExtender = 0x2a, Cdrom = 0x2, CdromFileSystem = 0x3, Changer = 0x30, Controller = 0x4, DataLink = 0x5, Dfs = 0x6, DfsFileSystem = 0x35, DfsVolume = 0x36, Disk = 0x7, DiskFileSystem = 0x8, Dvd = 0x33,
		FileSystem = 0x9, Fips = 0x3a, FullscreenVideo = 0x34, ImportPort = 0xa, Keyboard = 0xb, KS = 0x2f, KSec = 0x39, Mailslot = 0xc, MassStorage = 0x2d, MidiIn = 0xd, MidiOut = 0xe, Modem = 0x2b, Mouse = 0xf, MultiUncProvider = 0x10, NamedPipe = 0x11,
		Network = 0x12, NetworkBrowser = 0x13, NetworkFileSystem = 0x14, NetworkRedirector = 0x28, Null = 0x15, ParallelPort = 0x16, PhysicalNetcard = 0x17, Port8042 = 0x27, Printer = 0x18, Scanner = 0x19, Screen = 0x1c, SerEnum = 0x37, SerialMousePort = 0x1a,
		SerialPort = 0x1b, SmartCard = 0x31, Smb = 0x2e, Sound = 0x1d, Streams = 0x1e, Tape = 0x1f, TapeFileSystem = 0x20, TermSrv = 0x38, Transport = 0x21, Unknown = 0x22, Vdm = 0x2c, Video = 0x23, VirtualDisk = 0x24, WaveIn = 0x25, WaveOut = 0x26,
	}

	[Flags]
	public enum Win32FileAccess
	{
		None = 0, ReadData = 0x1, ListDirectory = 0x1, WriteData = 0x2, AddFile = 0x2, AppendData = 0x4, AddSubdirectory = 0x4, CreatePipeInstance = 0x4, ReadExtendedAttributes = 0x8, WriteExtendedAttributes = 0x10, Execute = 0x20, Traverse = 0x20, DeleteChild = 0x40, ReadAttributes = 0x80, WriteAttributes = 0x100,
		/*The rest are generic access rights for all objects, not just files*/
		Delete = 0x10000, ReadControl = 0x20000, WriteDiscretionaryAcl = 0x40000, WriteOwner = 0x80000, Synchronize = 0x100000, AccessSystemSecurity = 0x1000000, MaximumAllowed = 0x2000000, GenericRead = unchecked((int)0x80000000), GenericWrite = 0x40000000, GenericExecute = 0x20000000, GenericAll = 0x10000000
	}

	[Flags]
	public enum WinNTObjectAttributes
	{
		None = 0x00000000,
		/// <summary>This handle can be inherited by child processes of the current process.</summary>
		Inherit = 0x00000002,
		/// <summary>This flag only applies to objects that are named within the object manager. By default, such objects are deleted when all open handles to them are closed. If this flag is specified, the object is not deleted when all open handles are closed. Drivers can use the ZwMakeTemporaryObject routine to make a permanent object non-permanent.</summary>
		Permanent = 0x00000010,
		/// <summary>
		/// <para>If this flag is set and the routine creates an object, the object can be accessed exclusively. That is, once a process opens such a handle to the object, no other processes can open handles to this object.</para>
		/// <para>If this flag is set and the routine creates an object handle, the caller is requesting exclusive access to the object for the process context that the handle was created in. This request can be granted only if the <see cref="Exclusive"/> flag was set when the object was created.</para>
		/// </summary>
		Exclusive = 0x00000020,
		/// <summary>If this flag is specified, a case-insensitive comparison is used when matching the name member against the names of existing objects. Otherwise, object names are compared using the default system settings.</summary>
		CaseInsensitive = 0x00000040,
		/// <summary>If this flag is specified, by using the object handle, to a routine that creates objects and if that object already exists, the routine should open that object. Otherwise, the routine creating the object returns a status code of Object Name Collision.</summary>
		OpenIf = 0x00000080,
		/// <summary>If an object handle, with this flag set, is passed to a routine that opens objects and if the object is a symbolic link object, the routine should open the symbolic link object itself, rather than the object that the symbolic link refers to (which is the default behavior).</summary>
		OpenLink = 0x00000100,
		/// <summary>The handle is created in system process context and can only be accessed from kernel mode.</summary>
		KernelHandle = 0x00000200,
		/// <summary>The routine that opens the handle should enforce all access checks for the object, even if the handle is being opened in kernel mode.</summary>
		ForceAccessCheck = 0x00000400,
		/// <summary>Reserved.</summary>
		ValidAttributes = 0x000007F2
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal struct FileNamesInformation
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly int NEXT_ENTRY_OFFSET_OFFSET = (int)Marshal.OffsetOf(typeof(FileNamesInformation), "NextEntryOffset");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly int FILE_INDEX_OFFSET = (int)Marshal.OffsetOf(typeof(FileNamesInformation), "FileIndex");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly int FILE_NAME_LENGTH_OFFSET = (int)Marshal.OffsetOf(typeof(FileNamesInformation), "FileNameLength");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly int FILE_NAME_OFFSET = (int)Marshal.OffsetOf(typeof(FileNamesInformation), "FileName");

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int NextEntryOffset;
		public int FileIndex;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int FileNameLength;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
		public string FileName;

		internal static string[] FromBuffer(IntPtr pBuffer)
		{
			int count = 0;
			int offset = 0;
			unsafe { while (*(int*)((byte*)pBuffer + offset) != 0) { count++; offset += *(int*)((byte*)pBuffer + offset); } }
			count++;
			var result = new string[count];
			var info = new FileNamesInformation();
			for (int i = 0; i < result.Length; i++)
			{
				info.MarshalFrom(pBuffer);
				result[i] = info.FileName;
				unsafe { pBuffer = (IntPtr)((byte*)pBuffer + info.NextEntryOffset); }
			}
			return result;
		}

		internal void MarshalFrom(IntPtr pBuffer)
		{
			unsafe
			{
				this.NextEntryOffset = *(int*)((byte*)pBuffer + NEXT_ENTRY_OFFSET_OFFSET);
				this.FileIndex = *(int*)((byte*)pBuffer + FILE_INDEX_OFFSET);
				this.FileNameLength = *(int*)((byte*)pBuffer + FILE_NAME_LENGTH_OFFSET);
				unsafe { this.FileName = Marshal.PtrToStringUni((IntPtr)((byte*)pBuffer + FILE_NAME_OFFSET), this.FileNameLength / sizeof(char)); }
			}
		}

		public override string ToString() { return this.FileName; }
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct FileDirectoryInformation
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly int NEXT_ENTRY_OFFSET_OFFSET = (int)Marshal.OffsetOf(typeof(FileDirectoryInformation), "NextEntryOffset");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly int FILE_INDEX_OFFSET = (int)Marshal.OffsetOf(typeof(FileDirectoryInformation), "FileIndex");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly int CREATION_TIME_OFFSET = (int)Marshal.OffsetOf(typeof(FileDirectoryInformation), "CreationTime");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly int LAST_ACCESS_TIME_OFFSET = (int)Marshal.OffsetOf(typeof(FileDirectoryInformation), "LastAccessTime");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly int LAST_WRITE_TIME_OFFSET = (int)Marshal.OffsetOf(typeof(FileDirectoryInformation), "LastWriteTime");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly int CHANGE_TIME_OFFSET = (int)Marshal.OffsetOf(typeof(FileDirectoryInformation), "ChangeTime");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly int END_OF_FILE_OFFSET = (int)Marshal.OffsetOf(typeof(FileDirectoryInformation), "EndOfFile");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly int ALLOCATION_SIZE_OFFSET = (int)Marshal.OffsetOf(typeof(FileDirectoryInformation), "AllocationSize");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly int FILE_ATTRIBUTES_OFFSET = (int)Marshal.OffsetOf(typeof(FileDirectoryInformation), "FileAttributes");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly int FILE_NAME_LENGTH_OFFSET = (int)Marshal.OffsetOf(typeof(FileDirectoryInformation), "FileNameLength");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly int FILE_NAME_OFFSET = (int)Marshal.OffsetOf(typeof(FileDirectoryInformation), "FileName");

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int NextEntryOffset;
		public int FileIndex;
		public long CreationTime;
		public long LastAccessTime;
		public long LastWriteTime;
		public long ChangeTime;
		public long EndOfFile;
		public long AllocationSize;
		public Win32FileAttributes FileAttributes;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int FileNameLength;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
		public string FileName;

		internal static FileDirectoryInformation[] FromBuffer(IntPtr pBuffer)
		{
			int count = 0;
			int offset = 0;
			unsafe { while (*(int*)((byte*)pBuffer + offset) != 0) { count++; offset += *(int*)((byte*)pBuffer + offset); } }
			count++;
			var result = new FileDirectoryInformation[count];
			for (int i = 0; i < result.Length; i++)
			{
				result[i].MarshalFrom(pBuffer);
				unsafe { pBuffer = (IntPtr)((byte*)pBuffer + result[i].NextEntryOffset); }
			}
			return result;
		}

		internal static void FromBuffer(IntPtr pBuffer, List<FileDirectoryInformation> buffer)
		{
			int offset = 0;
			unsafe
			{
				FileDirectoryInformation info;
				do
				{
					info = new FileDirectoryInformation();
					info.MarshalFrom((IntPtr)((byte*)pBuffer + offset));
					buffer.Add(info);
					offset += info.NextEntryOffset;
				} while (info.NextEntryOffset != 0);
			}
		}

		internal void MarshalFrom(IntPtr pBuffer)
		{
			unsafe
			{
				this.NextEntryOffset = *(int*)((byte*)pBuffer + NEXT_ENTRY_OFFSET_OFFSET);
				this.FileIndex = *(int*)((byte*)pBuffer + FILE_INDEX_OFFSET);
				this.CreationTime = *(long*)((byte*)pBuffer + CREATION_TIME_OFFSET);
				this.LastAccessTime = *(long*)((byte*)pBuffer + LAST_ACCESS_TIME_OFFSET);
				this.LastWriteTime = *(long*)((byte*)pBuffer + LAST_WRITE_TIME_OFFSET);
				this.ChangeTime = *(long*)((byte*)pBuffer + CHANGE_TIME_OFFSET);
				this.EndOfFile = *(long*)((byte*)pBuffer + END_OF_FILE_OFFSET);
				this.AllocationSize = *(long*)((byte*)pBuffer + ALLOCATION_SIZE_OFFSET);
				this.FileAttributes = *(Win32FileAttributes*)((byte*)pBuffer + FILE_ATTRIBUTES_OFFSET);
				this.FileNameLength = *(int*)((byte*)pBuffer + FILE_NAME_LENGTH_OFFSET);
				unsafe { this.FileName = Marshal.PtrToStringUni((IntPtr)((byte*)pBuffer + FILE_NAME_OFFSET), this.FileNameLength / sizeof(char)); }
			}
		}

		public override string ToString() { return this.FileName; }
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct FileIdBothDirInformation
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly int NEXT_ENTRY_OFFSET_OFFSET = (int)Marshal.OffsetOf(typeof(FileIdBothDirInformation), "NextEntryOffset");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly int FILE_INDEX_OFFSET = (int)Marshal.OffsetOf(typeof(FileIdBothDirInformation), "FileIndex");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly int CREATION_TIME_OFFSET = (int)Marshal.OffsetOf(typeof(FileIdBothDirInformation), "CreationTime");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly int LAST_ACCESS_TIME_OFFSET = (int)Marshal.OffsetOf(typeof(FileIdBothDirInformation), "LastAccessTime");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly int LAST_WRITE_TIME_OFFSET = (int)Marshal.OffsetOf(typeof(FileIdBothDirInformation), "LastWriteTime");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly int CHANGE_TIME_OFFSET = (int)Marshal.OffsetOf(typeof(FileIdBothDirInformation), "ChangeTime");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly int END_OF_FILE_OFFSET = (int)Marshal.OffsetOf(typeof(FileIdBothDirInformation), "EndOfFile");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly int ALLOCATION_SIZE_OFFSET = (int)Marshal.OffsetOf(typeof(FileIdBothDirInformation), "AllocationSize");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly int FILE_ATTRIBUTES_OFFSET = (int)Marshal.OffsetOf(typeof(FileIdBothDirInformation), "FileAttributes");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly int FILE_NAME_LENGTH_OFFSET = (int)Marshal.OffsetOf(typeof(FileIdBothDirInformation), "FileNameLength");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly int EA_SIZE_OFFSET = (int)Marshal.OffsetOf(typeof(FileIdBothDirInformation), "EaSize");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly int SHORT_NAME_LENGTH_OFFSET = (int)Marshal.OffsetOf(typeof(FileIdBothDirInformation), "ShortNameLength");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly int SHORT_NAME_OFFSET = (int)Marshal.OffsetOf(typeof(FileIdBothDirInformation), "ShortName");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly int FILE_ID_OFFSET = (int)Marshal.OffsetOf(typeof(FileIdBothDirInformation), "FileId");
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static readonly int FILE_NAME_OFFSET = (int)Marshal.OffsetOf(typeof(FileIdBothDirInformation), "FileName");

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int NextEntryOffset;
		public int FileIndex;
		public long CreationTime;
		public long LastAccessTime;
		public long LastWriteTime;
		public long ChangeTime;
		public long EndOfFile;
		public long AllocationSize;
		public Win32FileAttributes FileAttributes;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int FileNameLength;
		public int EaSize;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private byte ShortNameLength;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 12)]
		public string ShortName;
		public long FileId;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
		public string FileName;

		internal static FileIdBothDirInformation[] FromBuffer(IntPtr pBuffer)
		{
			int count = 0;
			int offset = 0;
			unsafe { while (*(int*)((byte*)pBuffer + offset) != 0) { count++; offset += *(int*)((byte*)pBuffer + offset); } }
			count++;
			var result = new FileIdBothDirInformation[count];
			for (int i = 0; i < result.Length; i++)
			{
				result[i].MarshalFrom(pBuffer);
				unsafe { pBuffer = (IntPtr)((byte*)pBuffer + result[i].NextEntryOffset); }
			}
			return result;
		}

		internal static void FromBuffer(IntPtr pBuffer, List<FileIdBothDirInformation> buffer)
		{
			int offset = 0;
			unsafe
			{
				FileIdBothDirInformation info;
				do
				{
					info = new FileIdBothDirInformation();
					info.MarshalFrom((IntPtr)((byte*)pBuffer + offset));
					buffer.Add(info);
					offset += info.NextEntryOffset;
				} while (info.NextEntryOffset != 0);
			}
		}

		internal void MarshalFrom(IntPtr pBuffer)
		{
			unsafe
			{
				this.NextEntryOffset = *(int*)((byte*)pBuffer + NEXT_ENTRY_OFFSET_OFFSET);
				this.FileIndex = *(int*)((byte*)pBuffer + FILE_INDEX_OFFSET);
				this.CreationTime = *(long*)((byte*)pBuffer + CREATION_TIME_OFFSET);
				this.LastAccessTime = *(long*)((byte*)pBuffer + LAST_ACCESS_TIME_OFFSET);
				this.LastWriteTime = *(long*)((byte*)pBuffer + LAST_WRITE_TIME_OFFSET);
				this.ChangeTime = *(long*)((byte*)pBuffer + CHANGE_TIME_OFFSET);
				this.EndOfFile = *(long*)((byte*)pBuffer + END_OF_FILE_OFFSET);
				this.AllocationSize = *(long*)((byte*)pBuffer + ALLOCATION_SIZE_OFFSET);
				this.FileAttributes = *(Win32FileAttributes*)((byte*)pBuffer + FILE_ATTRIBUTES_OFFSET);
				this.FileNameLength = *(int*)((byte*)pBuffer + FILE_NAME_LENGTH_OFFSET);
				this.EaSize = *(int*)((byte*)pBuffer + EA_SIZE_OFFSET);
				this.ShortNameLength = *(byte*)((byte*)pBuffer + SHORT_NAME_LENGTH_OFFSET);
				unsafe { this.ShortName = Marshal.PtrToStringUni((IntPtr)((byte*)pBuffer + SHORT_NAME_OFFSET), this.ShortNameLength / sizeof(char)); }
				this.FileId = *(long*)((byte*)pBuffer + FILE_ID_OFFSET);
				this.FileNameLength = *(int*)((byte*)pBuffer + FILE_NAME_LENGTH_OFFSET);
				unsafe { this.FileName = Marshal.PtrToStringUni((IntPtr)((byte*)pBuffer + FILE_NAME_OFFSET), this.FileNameLength / sizeof(char)); }
			}
		}

		public override string ToString() { return this.FileName; }
	}
	#endregion
}