#define DRIVE_ICON
//#define DRIVE_ICON_DYNAMIC
#define EFFICIENT_PROGRESS_REPORTING
#define OPEN_WITH_NO_ACCESS
//#define NEW_ADD_METHOD
#if !DEBUG
#define CATCH
#endif

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Shell;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using FileSystems.Udf;
using Helper.Forms;
using Helper.IO;
using Scsi;
using Scsi.Multimedia;
using System.Security;

namespace BurnApp
{
	public partial class FormMain : Form
	{
		private static readonly TextFormatFlags COMBO_BOX_TEXT_FLAGS = TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine;
		private static readonly Padding ICON_PADDING = new Padding(4, 2, 0, 2);
		private static readonly ThreadStart BeginModalMessageLoop = (ThreadStart)Delegate.CreateDelegate(typeof(ThreadStart), typeof(Application).GetMethod("BeginModalMessageLoop", BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public));
		private static readonly ThreadStart EndModalMessageLoop = (ThreadStart)Delegate.CreateDelegate(typeof(ThreadStart), typeof(Application).GetMethod("EndModalMessageLoop", BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public));
		private static readonly char[] PATH_SEPS = new char[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar };
		private static readonly string[] PATH_SEP_STRS = new string[] { Path.DirectorySeparatorChar.ToString(), Path.AltDirectorySeparatorChar.ToString() };
		private const string FOLDER_IMAGE_KEY = "FOLDER";
		private const string CD_DRIVE_IMAGE_KEY = "CD_DRIVE";
		private static readonly bool DIRECT_IO = false;
		private static readonly int ICON_CACHE_SIZE = 2048;
		private static readonly SafeLibraryHandle shell32 = SafeLibraryHandle.LoadLibraryEx("Shell32.dll");
		private UdfMaster master = new UdfMaster(Program.BLOCK_SIZE) { ApplicationId = new EntityIdentifier(EntityIdentifierFlags.None, Program.CurrentAssemblyTitle, new ApplicationIdentifierSuffix()), AlignFileIdentifiers = true };

		#region Nested Types
		private struct COMBOBOXINFO
		{
			public int cbSize;
			public Rect rcItem;
			public Rect rcButton;
			public int stateButton;
			public IntPtr hwndCombo;
			public IntPtr hwndItem;
			public IntPtr hwndList;
		}

		private class NodeTag { public NodeTag() { } }

		private class DirectoryTreeNode : TreeNode, IDirectoryInfo
		{
			private DirectorySecurity security;
			private DirectoryTreeNodeFileInfoCollection _Files;

			public class DirectoryTreeNodeFileInfoCollection : System.Collections.ObjectModel.KeyedCollection<string, IFileInfo>
			{
				private DirectoryTreeNode dir;
				internal DirectoryTreeNodeFileInfoCollection(DirectoryTreeNode dir) : base(StringComparer.Ordinal) { this.dir = dir; }
				protected override string GetKeyForItem(IFileInfo item) { return item.Name; }
				protected override void InsertItem(int index, IFileInfo item)
				{
					if (this.dir.Contains(this.GetKeyForItem(item))) { throw new ArgumentException("A file with the same name already exists.", "item"); }
					var asVirt = item as VirtualFileInfo;
					base.InsertItem(index, item);
					if (asVirt != null) { asVirt.Parent = this.dir; }
				}
				protected override void SetItem(int index, IFileInfo item)
				{
					if (dir.Nodes.ContainsKey(this.GetKeyForItem(item)) || base.Contains(this.GetKeyForItem(item))) { throw new ArgumentException("A file with the same name already exists.", "item"); }
					var prev = base[index];
					var prevAsVirt = prev as VirtualFileInfo;
					if (prevAsVirt != null) { prevAsVirt.Parent = null; }
					var asVirt = item as VirtualFileInfo;
					base.SetItem(index, item);
					if (asVirt != null) { asVirt.Parent = this.dir; }
				}
			}

			public bool Contains(string fileOrDirName) { return this.Nodes.ContainsKey(fileOrDirName) || this.Files.Contains(fileOrDirName); }

			public DirectoryTreeNode() : base() { this._Files = new DirectoryTreeNodeFileInfoCollection(this); }
			public DirectoryTreeNode(string text) : this() { this.Text = text; }

			void IDirectoryInfo.Create(DirectorySecurity directorySecurity) { this.security = directorySecurity; }
			IDirectoryInfo IDirectoryInfo.CreateSubdirectory(string path, DirectorySecurity directorySecurity) { var node = new DirectoryTreeNode() { security = directorySecurity, Name = path, Text = path, Tag = new NodeTag() }; this.Nodes.Add(node); return node; }
			void IDirectoryInfo.Delete(bool recursive)
			{
				if (recursive) { throw new NotImplementedException(); }
				else
				{
					this.Remove();
					IDirectoryInfo idir = this;
					idir.Refresh();
				}
			}
			public DirectorySecurity GetAccessControl(AccessControlSections includeSections) { return this.security; }

			public IDirectoryInfo[] GetDirectories(string searchPattern, SearchOption searchOption)
			{
				if (searchPattern != null && searchPattern != "*" || searchOption != SearchOption.TopDirectoryOnly)
				{ throw new NotSupportedException(); }
				var result = new DirectoryTreeNode[this.Nodes.Count];
				this.Nodes.CopyTo(result, 0);
				return result;
			}

			public IFileInfo[] GetFiles(string searchPattern, SearchOption searchOption)
			{
				if (searchPattern != null && searchPattern != "*" || searchOption != SearchOption.TopDirectoryOnly)
				{ throw new NotSupportedException(); }
				var files = new IFileInfo[this.Files.Count];
				this.Files.CopyTo(files, 0);
				return files;
			}

			public IFileSystemInfo[] GetFileSystemInfos(string searchPattern, SearchOption searchOption)
			{
				var dirs = this.GetDirectories(searchPattern, searchOption);
				var files = this.GetFiles(searchPattern, searchOption);
				var result = new IFileSystemInfo[dirs.Length + files.Length];
				Array.Copy(files, 0, result, 0, files.Length);
				Array.Copy(dirs, 0, result, files.Length, dirs.Length);
				return result;
			}

			public DirectoryTreeNodeFileInfoCollection Files { get { return this._Files; } set { this._Files = value; } }

			IDirectoryInfo IDirectoryInfo.Parent { get { return (DirectoryTreeNode)this.Parent; } } //TODO: DirectoryTreeNode.Parent is a bottleneck!
			IDirectoryInfo IDirectoryInfo.Root { get { TreeNode p = this; while (p.Parent != null) { p = p.Parent; } return (IDirectoryInfo)p; } }
			void IDirectoryInfo.SetAccessControl(DirectorySecurity directorySecurity) { this.security = directorySecurity; }

			[DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
			private FileAttributes _Attributes = FileAttributes.Directory;
			FileAttributes IFileSystemInfo.Attributes { get { return this._Attributes; } set { this._Attributes = value; } }
			[DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
			private DateTime _CreationTime = DateTime.Now;
			DateTime IFileSystemInfo.CreationTime { get { return this._CreationTime; } set { this._CreationTime = value; } }
			void IFileSystemInfo.Delete() { IDirectoryInfo me = this; me.Delete(false); }
			bool IFileSystemInfo.Exists { get { return true; } }
			string IFileSystemInfo.Extension { get { return Path.GetExtension(this.Name); } }
			private string _FullName;
			string IFileSystemInfo.FullName { get { if (this._FullName == null) { this._FullName = this.WithEndingSeparator(this.FullPath); } return this._FullName; } }
			long IFileSystemInfo.IndexNumber { get { return -1; } }
			[DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
			private DateTime _LastAccessTime = DateTime.Now;
			DateTime IFileSystemInfo.LastAccessTime { get { return this._LastAccessTime; } set { this._LastAccessTime = value; } }
			[DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
			private DateTime _LastWriteTime = DateTime.Now;
			DateTime IFileSystemInfo.LastWriteTime { get { return this._LastWriteTime; } set { this._LastWriteTime = value; } }
			void IFileSystemInfo.Refresh()
			{
				this._FullName = null;

				foreach (DirectoryTreeNode item in this.Nodes)
				{
					IDirectoryInfo idir = item;
					idir.Refresh(); //Refresh all children as well
				}
			}

			public void RenameFile(IFileInfo fileInfo, string newName)
			{
				string prevName = fileInfo.Name;
				if (!this.Files.Remove(fileInfo)) { throw new InvalidOperationException(); }
				try
				{
					fileInfo.Rename(newName);
					this.Files.Add(fileInfo);
				}
				catch
				{
					fileInfo.Rename(prevName);
					this.Files.Add(fileInfo);
					fileInfo.Refresh();
					throw;
				}
			}

			private string WithEndingSeparator(string s) { var ps = this.TreeView.PathSeparator; if (!s.EndsWith(ps)) { s += ps; } return s; }

			public override object Clone()
			{
				var me = (DirectoryTreeNode)base.Clone();
				me._Files = new DirectoryTreeNodeFileInfoCollection(me);
				for (int i = 0; i < this._Files.Count; i++)
				{ me._Files.Add(this._Files[i]); }
				return me;
			}

			public void Rename(string newName) { this.Text = this.Name = newName; }

			string IFileSystemInfo.Name { get { return this.Name; } }
		}

		private struct ProgressDialogInfo
		{
			private ProgressDialog dialog;
			private static readonly int TOTAL = int.MaxValue;
			private int start;
			private int length;

			public ProgressDialogInfo(ProgressDialog dialog) : this(dialog, 0, TOTAL) { }
			private ProgressDialogInfo(ProgressDialog dialog, int startOffset, int length) { this.dialog = dialog; this.start = startOffset; this.length = length; }

			public bool Canceled { get { return this.dialog.Canceled; } }
			public bool HasDialog { get { return this.dialog != null; } }
			public void SetLine(int line, string text, bool compact) { this.dialog.SetLine(line, text, compact); }
			public void SetProgress(double completed)
			{
				var c = (int)(this.start + completed * this.length);
				Debug.Assert(c >= this.start && c <= this.start + this.length);
				this.dialog.SetProgress(c, TOTAL);
			}

			public ProgressDialogInfo ExtractSegment(int startDivision, int length, int totalDivisions)
			{
				if (startDivision + (long)length > totalDivisions) { throw new ArgumentException("Invalid progress segment."); }
				var s = (int)(this.start + this.length * (long)startDivision / totalDivisions);
				var l = (int)(this.length * (long)length / totalDivisions);
				Debug.Assert(s >= this.start && s + (long)l <= this.start + (long)this.length);
				return new ProgressDialogInfo(this.dialog, s, l);
			}
		}

		private class MyTreeView : TreeView
		{
			private static readonly MethodInfo NodeFromHandle_Method = typeof(TreeView).GetMethod("NodeFromHandle", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			
			public TreeNode FocusedNode
			{
				get
				{
					IntPtr h = WinHelper.SendMessage(this, 0x110a, (IntPtr)8, (IntPtr)0, false);
					var node = (TreeNode)NodeFromHandle_Method.Invoke(this, new object[] { h });
					if (node == null) { node = this.SelectedNode; }
					return node;
				}
			}
		}

		private class MySplitContainer : SplitContainer
		{
			public MySplitContainer() { this.SetStyle(ControlStyles.OptimizedDoubleBuffer, false); }
		}

		private class DriveItem
		{
			public DriveItem(string drive, string desc)
			{
				this.DevicePath = drive;
				this.Description = desc;
			}

			public string DevicePath;
			public string Description;
#if DRIVE_ICON
			public object Icon;
#endif
			public override string ToString() { return this.Description; }
		}

		private class ItemTag { public ItemTag(IFileInfo file, DirectoryTreeNode dir) { this.FileInfo = file; this.Directory = dir; } public IFileInfo FileInfo; public DirectoryTreeNode Directory; }
		#endregion

		public FormMain()
		{
			this.InitializeComponent();
			Program.SetProperty(this.lvFiles, "DoubleBuffered", true, true);
			this.capacityBar.Markers = new CapacityBar.Marker[]
			{
				new CapacityBar.Marker(700L << 20, "CD", 1F, new Pen(Color.DarkGreen, 1) { DashStyle = DashStyle.Dash }),
				new CapacityBar.Marker(4700000000, "DVD", 1F, new Pen(Color.Red, 1) { DashStyle = DashStyle.Dash }),
				new CapacityBar.Marker(8500000000, "DVD DL", 1F, new Pen(Color.Crimson, 1) { DashStyle = DashStyle.Dash }),
				new CapacityBar.Marker(20000000000, "HD DVD", 1F, new Pen(Color.RoyalBlue, 1) { DashStyle = DashStyle.Dash }),
				new CapacityBar.Marker(25000000000, "BD", 1F, new Pen(Color.DarkBlue, 1) { DashStyle = DashStyle.Dash }),
				new CapacityBar.Marker(40000000000, "HD DVD DL", 1F, new Pen(Color.MediumVioletRed, 1) { DashStyle = DashStyle.Dash }),
				new CapacityBar.Marker(50000000000, "BD DL", 1F, new Pen(Color.Violet, 1) { DashStyle = DashStyle.Dash }),
			};
			this.tsbOpenImage.Image = Properties.Resources.DiscImageFile;
			this.tsbBurn.Image = Properties.Resources.Burn;
			this.tsMain.Renderer = new ToolStripNoBorderRenderer(this.tsMain.Renderer);
			this.tvDirectories.PathSeparator = Path.DirectorySeparatorChar.ToString();
			var root = new DirectoryTreeNode("Disc") { ImageKey = CD_DRIVE_IMAGE_KEY, SelectedImageKey = CD_DRIVE_IMAGE_KEY, Tag = new NodeTag() };
			root.Name = root.Text;
			this.master.Root = new VirtualDirectoryInfo(root);
			this.tvDirectories.Nodes.Add(root);
			this.scMain.Panel2Collapsed = !this.tsbShowExplorer.Checked;
			try
			{
#if DRIVE_ICON
				object cdIcon;
				cdIcon = Program.LoadImageIcon(shell32.DangerousGetHandle(), 12, this.imgListNodes.ImageSize.Width, this.imgListNodes.ImageSize.Height, LoadOptions.DefaultColor);
				if (cdIcon != null)
				{
					if (cdIcon is Icon) { this.imgListNodes.Images.Add(CD_DRIVE_IMAGE_KEY, (Icon)cdIcon); }
					else { this.imgListNodes.Images.Add(CD_DRIVE_IMAGE_KEY, (Image)cdIcon); }
				}
#endif
				this.imgListNodes.Images.Add(FOLDER_IMAGE_KEY, Program.LoadImageIcon(shell32.DangerousGetHandle(), 4, this.imgListNodes.ImageSize.Width, this.imgListNodes.ImageSize.Height, LoadOptions.DefaultColor));
			}
			catch { }

#if DRIVE_ICON
			this.tscmbDevice.ComboBox.DrawMode = DrawMode.OwnerDrawFixed;
			this.tscmbDevice.ComboBox.Dock = DockStyle.Fill;
			this.tscmbDevice.ComboBox.DrawItem += new DrawItemEventHandler(tscmbDevice_ComboBox_DrawItem);
			this.tscmbDevice.ComboBox.ItemHeight = Math.Max(this.tscmbDevice.ComboBox.PreferredHeight, this.imgListFiles.ImageSize.Height + ICON_PADDING.Vertical);
#endif

			try
			{
				using (var explore = Program.LoadImageIcon(shell32.DangerousGetHandle(), 46, this.tsMain.ImageScalingSize.Width, this.tsMain.ImageScalingSize.Height, LoadOptions.DefaultColor))
				{ this.tsbShowExplorer.Image = explore.ToBitmap(); }
			}
			catch { }
		}

		private void tscmbDevice_ComboBox_DrawItem(object sender, DrawItemEventArgs e)
		{
			var cmb = (ComboBox)sender;
			e.DrawBackground();
			e.DrawFocusRectangle();
			var current = e.Index >= 0 ? (DriveItem)cmb.Items[e.Index] : (DriveItem)cmb.SelectedItem;
			Size iconSize = this.imgListNodes.ImageSize;
			Rectangle imageBounds;
			if (current != null && current.Icon != null)
			{ imageBounds = new Rectangle(e.Bounds.X + ICON_PADDING.Left, e.Bounds.Y + (e.Bounds.Height - iconSize.Height) / 2, iconSize.Width + ICON_PADDING.Horizontal, iconSize.Height); }
			else { imageBounds = new Rectangle(e.Bounds.Location, ICON_PADDING.Size); }
			var textBounds = new Rectangle(imageBounds.Right, e.Bounds.Top, e.Bounds.Width - imageBounds.Width, e.Bounds.Height);
			TextRenderer.DrawText(e.Graphics, e.Index < 0 ? cmb.Text : current.ToString(), e.Font, textBounds, e.ForeColor, e.BackColor, COMBO_BOX_TEXT_FLAGS);
			if (current != null && current.Icon != null)
			{
				if (current.Icon is Icon) { e.Graphics.DrawIconUnstretched((Icon)current.Icon, imageBounds); }
				else { e.Graphics.DrawImageUnscaled((Image)current.Icon, imageBounds); }
			}
		}

		private static EnumValue[] GetEnumValues<TEnum>(params TEnum[] values)
			where TEnum : struct
		{
			var result = new EnumValue[values.Length];
			for (int i = 0; i < values.Length; i++) { result[i] = new EnumValue((Enum)(object)values[i]); }
			return result;
		}

		private MultimediaDevice OpenDrive(string device, Win32FileAccess access) { return new MultimediaDevice(new Win32Spti(new Win32FileStream(device, access, FileShare.ReadWrite /*Must be specified in order to be dismountable*/, FileMode.Open, Win32FileOptions.None).SafeFileHandle, false, DIRECT_IO), false) { TimeoutSeconds = 60 }; }

		private ListViewItem ToItem(DirectoryTreeNode parent, ImageList imageList, IFileInfo fi)
		{
			var asVirt = fi as VirtualFileSystemInfo;
			string path = asVirt != null ? asVirt.LinkedTarget.FullName : fi.FullName;
			var item = new ListViewItem(new string[] { fi.Name, path, fi.Length.ToString("N0"), }, fi.FullName) { Name = fi.Name, Tag = new ItemTag(fi, parent), UseItemStyleForSubItems = false };

			if (imageList != null)
			{
				int iImage = imageList.Images.IndexOfKey(item.ImageKey);
				if (iImage >= 0) { item.ImageIndex = iImage; }
				else
				{
					Icon icon = Program.SHGetFileIcon(asVirt != null ? asVirt.LinkedTarget.FullName : fi.FullName, (int)fi.Attributes, out iImage, false);

					if (icon != null)
					{
						if (iImage < 0)
						{
							while (imageList.Images.Count > ICON_CACHE_SIZE)
							{ imageList.Images.RemoveAt(0); }
							imageList.Images.Add(item.ImageKey, icon);
							iImage = imageList.Images.Count - 1;
						}
						imageList.Images.Add(item.ImageKey, icon);
						item.ImageIndex = iImage;
					}
				}
			}
			return item;
		}

		private AddResult ToNode(IDirectoryInfo dir, bool archiveOnly, string imageKey, ProgressDialogInfo progress, ref int lastProgressReportTick, out DirectoryTreeNode node)
		{
			string name = dir.Name;
			if (string.IsNullOrEmpty(name))
			{
				var asVirtDir = dir as VirtualDirectoryInfo;
				if (asVirtDir != null)
				{
					var asLinkedIDir = asVirtDir.LinkedTarget as IDirectoryInfo;
					if (asLinkedIDir != null)
					{ name = Path.GetPathRoot(asLinkedIDir.FullName).Replace(PATH_SEP_STRS[0], string.Empty).Replace(PATH_SEP_STRS[1], string.Empty); }
				}
				if (string.IsNullOrEmpty(name))
				{ throw new InvalidOperationException("The given folder must have a name." + Environment.NewLine + "If you are adding a drive's root folder, please add the contents individually instead."); }
			}
			node = new DirectoryTreeNode()
			{
				Tag = new NodeTag(),
				ImageKey = imageKey,
				SelectedImageKey = imageKey,
				Name = name,
				Text = name,
			};
			IFileSystemInfo[] infos;
			for (; ; )
			{
				try
				{
					infos = dir.GetFileSystemInfos(null, SearchOption.TopDirectoryOnly);
					break;
				}
				catch (Exception ex)
				{
					if (!(ex is IOException | ex is SecurityException | ex is UnauthorizedAccessException)) { throw; }
					var dr = MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
					if (dr == DialogResult.Ignore) { return AddResult.Skipped; }
					else if (dr == DialogResult.Abort) { return AddResult.Failed; }
					else { infos = null; }
				}
			}
			{
#if EFFICIENT_PROGRESS_REPORTING
				int tick = Environment.TickCount;
				if (progress.HasDialog && tick - lastProgressReportTick >= Program.FAST_UPDATE_PAUSE_MILLIS)
#endif
				{
#if EFFICIENT_PROGRESS_REPORTING
					lastProgressReportTick = tick;
#endif
					if (progress.Canceled) { return AddResult.Failed; }
					progress.SetLine(1, string.Format("Processing '{0}'", dir.Name), false);
					progress.SetLine(2, dir.FullName, false);
					progress.SetProgress(1 / (double)(infos.Length + 1));
				}
			}
			IDirectoryInfo asIDir = node;
			asIDir.Attributes = dir.Attributes;
			asIDir.CreationTime = dir.CreationTime;
			//asIDir.IndexNumber = dir.IndexNumber;
			asIDir.LastAccessTime = dir.LastAccessTime;
			asIDir.LastWriteTime = dir.LastWriteTime;
			for (int i = 0; i < infos.Length; i++)
			{
				var child = infos[i];
				{
#if EFFICIENT_PROGRESS_REPORTING
					int tick = Environment.TickCount;
					if (progress.HasDialog && tick - lastProgressReportTick >= Program.FAST_UPDATE_PAUSE_MILLIS)
#endif
					{
#if EFFICIENT_PROGRESS_REPORTING
						lastProgressReportTick = tick;
#endif
						if (progress.Canceled) { return AddResult.Failed; }
						progress.SetLine(1, string.Format("Processing '{0}'", child.Name), false);
						progress.SetLine(2, child.FullName, false);
						progress.SetProgress((i + 1) / (double)(infos.Length + 1));
					}
				}

				var asSubDir = child as IDirectoryInfo;
				if (asSubDir != null)
				{
					DirectoryTreeNode subNode;
					var result = this.ToNode(asSubDir, archiveOnly, imageKey, progress.ExtractSegment((i + 1), 1, (infos.Length + 1)), ref lastProgressReportTick, out subNode);
					if (result == AddResult.Failed) { return result; }
					if (result == AddResult.Succeeded) { node.Nodes.Add(subNode); }
				}
				else
				{
					if (!archiveOnly || (child.Attributes & FileAttributes.Archive) != 0)
					{
						node.Files.Add(new VirtualFileInfo((IFileInfo)child)); //Making it virtual is CRITICAL!! Otherwise the user could delete the file itself!!
					}
				}
			}
			{
#if EFFICIENT_PROGRESS_REPORTING
				int tick = Environment.TickCount;
				if (progress.HasDialog && tick - lastProgressReportTick >= Program.FAST_UPDATE_PAUSE_MILLIS)
#endif
				{
#if EFFICIENT_PROGRESS_REPORTING
					lastProgressReportTick = tick;
#endif
					if (progress.Canceled) { return AddResult.Failed; }
					progress.SetLine(1, string.Format("Processing '{0}'", dir.Name), false);
					progress.SetLine(2, dir.FullName, false);
					progress.SetProgress((infos.Length + 1) / (double)(infos.Length + 1));
				}
			}
			return AddResult.Succeeded;
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			using (new CursorChange(this, Cursors.WaitCursor))
			{
				string oldText = this.sbPnlStage.Text;
				try
				{
					this.CalculateSpace();
					this.sbPnlStage.Text = "Finding and opening drives, please wait...";
					this.Update();

#if CATCH
					try
#endif
					{
						var maxSize = new Size(32, 16);
						this.tscmbDevice.Items.Clear();

						{
							var virtualDrive = new DriveItem(null, "Virtual Image Recorder")
							{
#if DRIVE_ICON
								Icon = Properties.Resources.DiscFile16,
#endif
							};
							this.tscmbDevice.Items.Add(virtualDrive);
							this.tscmbDevice.SelectedIndex = 0;

							var measure = TextRenderer.MeasureText(virtualDrive.ToString(), this.tscmbDevice.Font, this.tscmbDevice.ContentRectangle.Size, COMBO_BOX_TEXT_FLAGS);

							if (virtualDrive.Icon != null)
							{
								Size iconSize;
								if (virtualDrive.Icon is Icon) { iconSize = ((Icon)virtualDrive.Icon).Size; }
								else { iconSize = ((Image)virtualDrive.Icon).Size; }
								measure = new Size(measure.Width + iconSize.Width + ICON_PADDING.Horizontal, Math.Max(measure.Height, iconSize.Height + ICON_PADDING.Vertical));
							}
							maxSize = new Size(Math.Max(maxSize.Width, measure.Width), Math.Max(maxSize.Height, measure.Height));
						}

						var allDevices = Win32FileStream.QueryDosDevices(null);

						Trace.Assert(allDevices != null, "Device array was null!");
						for (int i = 0; i < allDevices.Length; i++)
						{
							var m = Regex.Match(allDevices[i], @"^(?<DEVICE>CdRom\d+)$", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.ExplicitCapture);
							if (m.Success)
							{
								var deviceName = m.Groups["DEVICE"].Value;
								Trace.Assert(deviceName != null, "Device name captured was null!");
								var devicePath = string.Format(@"\\.\{0}", deviceName);
#if CATCH
								try
#endif
								{
									Exception ex = null;
									StandardInquiryData inquiry = null;
									string deviceType = null;
#if GET_ADDRESS
									byte lun = 0, pathId = 0, targetId = 0, portNumber = 0;
#endif
#if OPEN_WITH_NO_ACCESS
#if CATCH
									try
#endif
									{
										//We use the interface to query information instead of the device
										//This way we don't need any read or write access to the drive,
										//meaning there's no media access delay
										using (var cd = OpenDrive(devicePath, Win32FileAccess.ReadAttributes | Win32FileAccess.Synchronize /*no access*/))
										{
#if GET_ADDRESS
											lun = cd.Interface.LogicalUnitNumber;
											pathId = cd.Interface.PathId;
											targetId = cd.Interface.TargetId;
											portNumber = cd.Interface.PortNumber;
#endif
#if CATCH
											try
#endif
											{
												/*Try to be nice*/
												inquiry = cd.Interface.ScsiInquiry(false);
											}
#if CATCH
											catch { inquiry = null; }
#endif

											if (inquiry == null) //We failed with no access; now try method #2
											{
												//OK, I've seen this fail before, so now we have to open the drive
												//with READ access and try another method (use a different I/O Control Code)
												using (var cd2 = OpenDrive(devicePath, Win32FileAccess.GenericRead | Win32FileAccess.Synchronize))
												{
													try { inquiry = cd2.Interface.CdromInquiry(); }
													catch { inquiry = null; } //Fail silently...
												}
											}

											if (inquiry == null) //If we're still unlucky (which shouldn't really happen) use method #3
											{
												//I really don't expect failure here, but let's brute-force with pass-through
												//(needs read/write access and has the same delay as last method)
												using (var cd2 = OpenDrive(devicePath, Win32FileAccess.GenericRead | Win32FileAccess.GenericWrite | Win32FileAccess.Synchronize))
												{ inquiry = cd2.Inquiry(); }
											}

											//Now we're hoping everything's fine...
										}
									}
#if CATCH
									catch (Exception ex2) { ex = ex2; }
#endif
#else
									try
									{
										using (var cd = OpenDrive(devicePath, Win32FileAccess.GenericRead | Win32FileAccess.Synchronize))
										{
											lun = cd.Interface.LogicalUnitNumber;
											pathId = cd.Interface.PathId;
											targetId = cd.Interface.TargetId;
											portNumber = cd.Interface.PortNumber;
											inquiry = cd.Interface.CdromInquiry();
											deviceType = cd.Interface.GetCdromConfiguration<ProfileListFeature>().GetDriveType();
										}
									}
									catch (Exception ex2) { ex = ex2; }
#endif
									string win32Path;
#if CATCH
									try
#endif
									{ win32Path = string.Format(@"{0}:", Win32FileStream.GetDriveLetter(Win32FileStream.QueryFirstDosDevice(deviceName), true)); }
#if CATCH
									catch { win32Path = devicePath; }
#endif
									string description;
									if (inquiry != null)
									{
										string vendor = VendorIdentifiers.GetVendorName(inquiry.VendorIdentification);
										if (vendor == null) { vendor = inquiry.VendorIdentification; }
#if GET_ADDRESS
										//string address = string.Format("{0:N0}:{1:N0}:{2:N0}:{3:N0}", portNumber, pathId, targetId, lun);
#else
										string address = null;
#endif
										description = string.Format("{0} " +
#if GET_ADDRESS
											"[{1}]" +
#endif
 " {2} {3} {4}", win32Path, address, vendor, inquiry.ProductIdentification, inquiry.ProductRevisionLevel);
										if (deviceType != null) { win32Path = string.Format("{0} ({1})", win32Path, deviceType); }
									}
									else
									{
										description = string.Format("{0} (Error: {1})", win32Path, ex.Message);
									}
									var item = new DriveItem(devicePath, description);
#if DRIVE_ICON && DRIVE_ICON_DYNAMIC
									try { int iconIndex; item.Icon = Program.SHGetFileIcon(win32Path.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar) + Path.DirectorySeparatorChar, null, out iconIndex, false); }
									catch { }
#endif
									int index = this.tscmbDevice.Items.Add(item);
									if (this.tscmbDevice.SelectedIndex <= 0) { this.tscmbDevice.SelectedIndex = index; }
									var measure = TextRenderer.MeasureText(item.ToString(), this.tscmbDevice.Font, this.tscmbDevice.ContentRectangle.Size, COMBO_BOX_TEXT_FLAGS);

									if (item.Icon != null)
									{
										Size iconSize;
										if (item.Icon is Icon) { iconSize = ((Icon)item.Icon).Size; }
										else { iconSize = ((Image)item.Icon).Size; }
										measure = new Size(measure.Width + iconSize.Width + ICON_PADDING.Horizontal, Math.Max(measure.Height, iconSize.Height + ICON_PADDING.Vertical));
									}

									maxSize = new Size(Math.Max(maxSize.Width, measure.Width), Math.Max(maxSize.Height, measure.Height));
								}
#if CATCH
								catch (Exception ex) { MessageBox.Show(this, string.Format("Unexpected error while adding drive {0}:" + Environment.NewLine + "{1}", deviceName, ex), "Error Adding Drive", MessageBoxButtons.OK, MessageBoxIcon.Error); }
#endif
							}
						}

						var info = new COMBOBOXINFO() { cbSize = Marshal.SizeOf(typeof(COMBOBOXINFO)) };
						unsafe { WinHelper.SendMessage(this.tscmbDevice.ComboBox, 0x0164, IntPtr.Zero, (IntPtr)(&info), true); }
						this.tscmbDevice.ComboBox.ItemHeight = maxSize.Height;
						this.tscmbDevice.ComboBox.Width = this.tscmbDevice.ComboBox.Width - (info.rcItem.right - info.rcItem.left) + 4 + maxSize.Width;
					}
#if CATCH
					catch (Exception ex) { MessageBox.Show(this, string.Format("Unexpected error while adding drives:" + Environment.NewLine + "{0}", ex), "Error Adding Drives", MessageBoxButtons.OK, MessageBoxIcon.Error); }
#endif
				}
				finally { this.sbPnlStage.Text = oldText; }
			}
		}

		private void tvDirectories_AfterSelect(object sender, TreeViewEventArgs e)
		{
			var node = (DirectoryTreeNode)e.Node;
			if (!this.lvFiles.VirtualMode)
			{
				var tag = (NodeTag)e.Node.Tag;
				var items = new List<ListViewItem>();
				int lastTick = Environment.TickCount;
				var files = node.GetFiles(null, SearchOption.TopDirectoryOnly);
				try
				{
					for (int i = 0; i < files.Length; i++)
					{
						var fi = files[i];
						int tick = Environment.TickCount;
						if (tick - lastTick >= Program.FAST_UPDATE_PAUSE_MILLIS)
						{
							this.sbPnlStage.Text = string.Format("Loading icon {0:N0} of {1:N0} ({2:P2})...", i, files.Length, i / (double)files.Length);
							this.sbPnlDescription.Text = fi.FullName;
							lastTick = tick;
						}
						items.Add(this.ToItem(node, this.lvFiles.SmallImageList, fi));
					}
				}
				finally { this.sbPnlStage.Text = this.sbPnlDescription.Text = string.Empty; }
				this.lvFiles.Items.Clear();
				this.lvFiles.SmallImageList = this.lvFiles.SmallImageList;
				try
				{
					this.sbPnlStage.Text = "Displaying files...";
					this.lvFiles.Items.AddRange(items.ToArray());
				}
				finally { this.sbPnlStage.Text = string.Empty; }
			}
			else { this.lvFiles.VirtualListSize = node.Files.Count; this.lvFiles.Invalidate(); }
		}

		private class FullPathComparer<TDir> : Comparer<TDir> where TDir : IDirectoryInfo { public override int Compare(TDir x, TDir y) { return x.FullName.CompareTo(y.FullName); } public static readonly FullPathComparer<TDir> Instance = new FullPathComparer<TDir>(); }

		private void Add_NewMethod(string[] paths, bool archiveOnly)
		{
			var root = (DirectoryTreeNode)this.tvDirectories.FocusedNode;
			string rootPath = root.FullPath;
			var allPaths = new List<string>(paths.Length);
			for (int i = 0; i < paths.Length; i++)
			{
				var path = paths[i].TrimEnd(PATH_SEPS); //Doesn't end in separator; normalized
				if (Directory.Exists(path))
				{
					var currentDir = new Win32DirectoryInfo(path);
					DirectoryTreeNode currentNode;
					int lastProgressReportTick = Environment.TickCount;
					this.ToNode(currentDir, archiveOnly, FOLDER_IMAGE_KEY, new ProgressDialogInfo(null), ref lastProgressReportTick, out currentNode);

					var dirsToFiles = new SortedDictionary<Win32DirectoryInfo, Win32FileInfo[]>(FullPathComparer<Win32DirectoryInfo>.Instance);


					foreach (var directory in dirsToFiles)
					{
						string dirRelativePath = directory.Key.FullName.Substring(path.Length);
						dirRelativePath = NoTrailingSeparator(dirRelativePath);
						foreach (var file in directory.Value)
						{
						}
					}
				}
				else { allPaths.Add(path); }
			}
		}

		private static string NoTrailingSeparator(string dirRelativePath) { if (!string.IsNullOrEmpty(dirRelativePath) && (dirRelativePath[dirRelativePath.Length - 1] == Path.DirectorySeparatorChar || dirRelativePath[dirRelativePath.Length - 1] == Path.AltDirectorySeparatorChar)) { dirRelativePath = dirRelativePath.Substring(dirRelativePath.Length - 1); } return dirRelativePath; }

		private AddResult AddFolder(DirectoryTreeNode parent, string dirPath, bool archiveOnly, ProgressDialogInfo progress, out DirectoryTreeNode addedNode)
		{
			//If this is really a file, then do something else
			if (File.Exists(dirPath)) { ListViewItem item; addedNode = null; return this.AddFile(parent, dirPath, archiveOnly, progress, out item); }
			else
			{
				var lastTick = Environment.TickCount;
				int lastProgressReportTick = lastTick;
				var result = this.ToNode(new VirtualDirectoryInfo(new Win32DirectoryInfo(dirPath)), archiveOnly, FOLDER_IMAGE_KEY, progress, ref lastProgressReportTick, out addedNode);
				if (result == AddResult.Failed) { return result; }
				if (progress.HasDialog && progress.Canceled) { return AddResult.Failed; }
				if (result == AddResult.Succeeded)
				{
					if (!this.CheckFileNameAndDisplayMessageBox(addedNode.Name)) { return AddResult.Failed; }
					if (parent.Nodes.ContainsKey(addedNode.Name))
					{
						MessageBox.Show(this, string.Format("A directory with the same name already exists:" + Environment.NewLine + "{0}", dirPath), "Duplicate Folder", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return AddResult.Failed;
					}
					parent.Nodes.Add(addedNode);
				}
				return result;
			}
		}

		private AddResult AddFile(DirectoryTreeNode selectedNode, string filePath, bool archiveOnly, ProgressDialogInfo progress, out ListViewItem item)
		{
			if (Directory.Exists(filePath))
			{
				DirectoryTreeNode node;
				item = null;
				var result = this.AddFolder(selectedNode, filePath, archiveOnly, progress, out node);
				if (result == AddResult.Succeeded) { selectedNode.Expand(); }
				return result;
			}
			else
			{
				var tag = (NodeTag)selectedNode.Tag;
				var file = new VirtualFileInfo(new Win32FileInfo(filePath)); //Making it virtual is CRITICAL!! Otherwise the user could delete the file itself!!
				if (archiveOnly)
				{
					if ((file.Attributes & FileAttributes.Archive) == 0)
					{
						item = null;
						return AddResult.Skipped;
					}
				}
				if (!this.CheckFileNameAndDisplayMessageBox(file.Name)) { item = null; return AddResult.Failed; }
				item = this.ToItem(selectedNode, this.lvFiles.SmallImageList, file);
				if (this.lvFiles.Items.ContainsKey(item.Name))
				{
					MessageBox.Show(this, string.Format("A file with the same name already exists:" + Environment.NewLine + "{0}", filePath), "Duplicate File", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return AddResult.Failed;
				}
				selectedNode.Files.Add(file);
				if (this.lvFiles.VirtualMode) { this.lvFiles.VirtualListSize++; }
				else { this.lvFiles.Items.Add(item); }
				return AddResult.Succeeded;
			}
		}

		private enum AddResult { Succeeded, Skipped, Failed }

		private void AddFiles(DirectoryTreeNode selectedNode, bool archiveOnly, string[] filePaths)
		{
#if NEW_ADD_METHOD
			this.Add(filePaths);
#else
			using (new CursorChange(this, Cursors.WaitCursor))
			{
#if CATCH
				try
#endif
				{
					var progress = new ProgressDialog() { Title = "Adding files..." };
#if CATCH
					try
#endif
					{ progress.SetAnimation(shell32.DangerousGetHandle(), 161); }
#if CATCH
					catch { }
#endif
					progress.SetLine(3, "Note: Progress may not accurately indicate time left.", false);
					progress.Start(this.Handle, null, ProgressDialogStartFlags.AutoTime | ProgressDialogStartFlags.Modal);
					progress.SetTimer(ProgressDialogTimerAction.Reset);
					if (Environment.OSVersion.Version.Major < 6) { BeginModalMessageLoop(); }
					try
					{
						var progressInfo = new ProgressDialogInfo(progress);
						int lastProgressReportTick = Environment.TickCount;
						ListViewItem lastItemAdded = null;
						for (int i = 0; i < filePaths.Length; i++)
						{
							ListViewItem item;
							var result = this.AddFile(selectedNode, filePaths[i], archiveOnly, progressInfo.ExtractSegment(i, 1, filePaths.Length), out item);
							if (result == AddResult.Failed) { break; }
							if (result == AddResult.Succeeded && item != null) { lastItemAdded = item; }
						}
						if (lastItemAdded != null) { this.lvFiles.FocusedItem = lastItemAdded; }
					}
					finally
					{
						if (Environment.OSVersion.Version.Major < 6) { EndModalMessageLoop(); }
						progress.Stop();
					}
				}
#if CATCH
				catch (Exception ex)
				{
					MessageBox.Show(this,
#if DEBUG
					ex.ToString()
#else
 ex.Message
#endif
, "Error Adding File", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
#endif
			}

#endif
			this.CalculateSpace();
		}

		private void AddFolders(DirectoryTreeNode selectedNode, bool archiveOnly, string[] folderPaths)
		{
#if NEW_METHOD
			this.Add(folderPaths);
#else
			int prevIndex = selectedNode.Index;
			var parentOfSelectedNode = selectedNode.Parent;
			DirectoryTreeNode lastNode = selectedNode;
			using (new CursorChange(this, Cursors.WaitCursor))
			{
#if CATCH
				try
#endif
				{
					var progress = new ProgressDialog() { Title = "Adding folder..." };
#if CATCH
					try
#endif
					{ progress.SetAnimation(shell32.DangerousGetHandle(), 161); }
#if CATCH
					catch { }
#endif
					progress.SetLine(3, "Note: Progress may not accurately indicate time left.", false);
					progress.Start(this.Handle, null, ProgressDialogStartFlags.AutoTime | ProgressDialogStartFlags.Modal);
					progress.SetTimer(ProgressDialogTimerAction.Reset);
					if (Environment.OSVersion.Version.Major < 6) { BeginModalMessageLoop(); }
					try
					{
						var progressInfo = new ProgressDialogInfo(progress);
						int lastProgressReportTick = Environment.TickCount;
						for (int i = 0; i < folderPaths.Length; i++)
						{
							DirectoryTreeNode node;
							var result = this.AddFolder(selectedNode, folderPaths[i], archiveOnly, progressInfo.ExtractSegment(i, 1, folderPaths.Length), out node);
							if (result == AddResult.Failed) { break; }
							if (result == AddResult.Succeeded && node != null) { lastNode = node; }
						}
					}
					finally
					{
						if (Environment.OSVersion.Version.Major < 6) { EndModalMessageLoop(); }
						progress.Stop();
					}
				}
#if CATCH
				catch (Exception ex) { MessageBox.Show(this, string.Format("An error occurred while adding the files:" + Environment.NewLine + "{0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
#endif
			}
#endif
			if (lastNode != null) { EnsureNodeVisible(lastNode); }
			this.CalculateSpace();
		}

		private void lvFiles_DragEnter(object sender, DragEventArgs e) { this.Focus(); e.Effect = GetEffect(e, false); }
		private void lvFiles_DragLeave(object sender, EventArgs e) { }
		private void lvFiles_DragOver(object sender, DragEventArgs e) { e.Effect = GetEffect(e, false); this.lvFiles.Focus(); }

		private void lvFiles_DragDrop(object sender, DragEventArgs e)
		{
			if ((e.Effect & (DragDropEffects.Copy | DragDropEffects.Move)) != 0)
			{
				if (e.Effect == DragDropEffects.Move)
				{
					var dr = MessageBox.Show(this, "You held the SHIFT key, which alters the way in which the data is added." + Environment.NewLine + "In this mode, ONLY files that have their Archive bits set will be added." + Environment.NewLine + "If this is what you intended, press Yes; if you wanted a normal drag, press no.", "Archive-bit Drag Mode", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
					if (dr == DialogResult.No) { e.Effect = DragDropEffects.Copy; }
					else if (dr != DialogResult.Yes) { return; }
				}
				var shellFiles = (string[])e.Data.GetData(System.Windows.Forms.DataFormats.FileDrop);
				if (shellFiles != null) { this.AddFiles((DirectoryTreeNode)this.tvDirectories.FocusedNode, e.Effect == DragDropEffects.Move, shellFiles); }
				else { this.tvDirectories_DragDrop(sender, e); }
			}
		}

		private void tvDirectories_DragOver(object sender, DragEventArgs e)
		{
			e.Effect = GetEffect(e, true);

			var node = this.tvDirectories.GetNodeAt(this.tvDirectories.PointToClient(new Point(e.X, e.Y)));
			if (node != null) { this.tvDirectories.SelectedNode = node; }
			this.tvDirectories.Focus();
		}

		private static DragDropEffects GetEffect(DragEventArgs e, bool allowSelfDrop)
		{
			bool shift = (e.KeyState & 4) != 0;
			bool ctrl = (e.KeyState & 8) != 0;
			bool alt = (e.KeyState & 32) != 0;
			var result = e.AllowedEffect & (shift ? DragDropEffects.Move : DragDropEffects.Copy);
			if (e.Data.GetDataPresent(DataFormats.FileDrop) || (allowSelfDrop && (e.Data.GetDataPresent(typeof(ListViewItem[])) | e.Data.GetDataPresent(typeof(TreeNode))))) { }
			else { result = DragDropEffects.None; }
			return result;
		}

		private void tvDirectories_DragLeave(object sender, EventArgs e) { }
		private void tvDirectories_DragEnter(object sender, DragEventArgs e) { this.Focus(); e.Effect = GetEffect(e, true); }

		private void tvDirectories_DragDrop(object sender, DragEventArgs e)
		{
			if ((e.Effect & (DragDropEffects.Copy | DragDropEffects.Move)) != 0)
			{
				var destNode = (DirectoryTreeNode)this.tvDirectories.FocusedNode;
				using (new CursorChange(this, Cursors.WaitCursor))
				{
					var shellFiles = (string[])e.Data.GetData(System.Windows.Forms.DataFormats.FileDrop);
					if (shellFiles != null) { this.AddFolders(destNode, e.Effect == DragDropEffects.Move, shellFiles); }
					else
					{
						var sourceNode = (DirectoryTreeNode)e.Data.GetData(typeof(DirectoryTreeNode));
						if (sourceNode != null)
						{
							if (sourceNode != destNode)
							{
								if (CanMove(sourceNode, destNode))
								{
									if (!destNode.Contains(sourceNode.Name))
									{
										var clone = (DirectoryTreeNode)sourceNode.Clone();
										destNode.Nodes.Add(clone);
										sourceNode.Remove();
									}
									else
									{
										MessageBox.Show(this, string.Format("The target folder already contains a file or folder named '{0}'.", sourceNode.Name), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
									}
								}
								else { MessageBox.Show(this, "Cannot move a folder into its own subfolder.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
							}
						}
						else
						{
							var sourceItems = (ListViewItem[])e.Data.GetData(typeof(ListViewItem[]));
							if (sourceItems != null)
							{
								foreach (var sourceItem in sourceItems)
								{
									var tag = (ItemTag)sourceItem.Tag;
									sourceNode = tag.Directory;
									if (sourceNode != destNode)
									{
										if (!destNode.Contains(sourceItem.Name))
										{
											if ((e.KeyState & 4) != 0 && !sourceNode.Files.Remove(tag.FileInfo))
											{ throw new InvalidOperationException(); }
											destNode.Files.Add(tag.FileInfo);
											if (this.lvFiles.VirtualMode)
											{
												this.lvFiles.VirtualListSize = destNode.Files.Count;
												this.lvFiles.Invalidate();
											}
											else { sourceItem.Remove(); }
										}
									}
								}
							}
						}
					}
				}
			}
		}

		private static void EnsureNodeVisible(DirectoryTreeNode node) { var tv = (MyTreeView)node.TreeView; var prevNode = tv.SelectedNode; try { tv.SelectedNode = node; } finally { tv.SelectedNode = prevNode; } }

		private static bool CanMove(TreeNode source, TreeNode destinationParent)
		{
			while (destinationParent != null)
			{
				if (destinationParent == source) { return false; }
				destinationParent = destinationParent.Parent;
			}
			return true;
		}

		private ListViewItem GetItem(DirectoryTreeNode node, int index) { return this.ToItem(node, this.lvFiles.SmallImageList, node.Files[index]); }

		//Returns True of name is valid, otherwise false
		private bool CheckFileNameAndDisplayMessageBox(string name)
		{
			if (UdfHelper.GetByteLength(name) >= byte.MaxValue)
			{
				MessageBox.Show(this, string.Format("File names must be shorter than {0} bytes:" + Environment.NewLine + "{1}", byte.MaxValue, name), "File Name Too Long", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			return true;
		}

		private void tvDirectories_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e) { }

		private void tvDirectories_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
		{
			if (!string.IsNullOrEmpty(e.Label))
			{
				try
				{
					if (e.Node.Parent == null /*root?*/)
					{
						if (e.Label.Length > 32) { MessageBox.Show(this, "The volume label must be at most 32 characters.", "Volume Label Too Long", MessageBoxButtons.OK, MessageBoxIcon.Error); e.CancelEdit = true; }
						else
						{
							if (this.CheckFileNameAndDisplayMessageBox(e.Label)) { this.tvDirectories.Nodes[0].Text = e.Label; }
							else { e.CancelEdit = true; }
						}
					}
					else { e.Node.Name = e.Label; }
				}
				catch { e.CancelEdit = true; throw; }
			}
			else { e.CancelEdit = true; }
		}

		private void tvDirectories_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F2:
					if (this.tvDirectories.SelectedNode != null) { this.tvDirectories.SelectedNode.BeginEdit(); }
					break;
				case Keys.Delete:
					this.DeleteCurrentFolder();
					break;
			}
		}

		private void DeleteCurrentFolder()
		{
			var toRemove = (DirectoryTreeNode)this.tvDirectories.SelectedNode;
			if (toRemove != null)
			{
				if (toRemove.Parent != null)
				{
					if (MessageBox.Show(this, string.Format("Are you sure you want to remove the directory \"{0}\" and all of its children?", toRemove.Name), "Confirm Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						if (toRemove.NextNode == null) { this.tvDirectories.SelectedNode = toRemove.PrevVisibleNode; }
						toRemove.Remove();
						IDirectoryInfo idir = toRemove;
						idir.Refresh();
					}
				}
				else { MessageBox.Show(this, "Cannot remove the root directory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
			}
			this.CalculateSpace();
		}

		private void lvFiles_DrawItem(object sender, DrawListViewItemEventArgs e) { e.DrawDefault = true; }
		private void lvFiles_DrawSubItem(object sender, DrawListViewSubItemEventArgs e) { e.DrawDefault = true; }
		private void lvFiles_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e) { e.DrawDefault = true; }

		private void txtIdentifier_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			var textBox = (TextBox)sender;
			if (string.IsNullOrEmpty(textBox.Text))
			{
				//e.Cancel = true;
				textBox.Text = "Untitled";
			}
		}

		private void DoWork(BurnType type, IStreamSource source)
		{
			using (new CursorChange(this, Cursors.WaitCursor))
			{
#if CATCH
				try
#endif
				{
					MultimediaDevice targetDevice = null;
#if CATCH
					try
#endif
					{
						var item = (DriveItem)this.tscmbDevice.SelectedItem;
						if (type != BurnType.Burn || item.DevicePath != null)
						{
							if (type == BurnType.Erase && item.DevicePath == null)
							{ throw new InvalidOperationException("This is a virtual drive; it contains no physical disc to erase."); }
							targetDevice = this.OpenDrive(item.DevicePath, Win32FileAccess.GenericRead | Win32FileAccess.GenericWrite | Win32FileAccess.Synchronize);
							try { targetDevice.SynchronizeCache(); }
							catch { }
						}
						var info = new DoWorkInfo(type, source, targetDevice);

						info.BufferSize = 8 << 20;
						if (info.Type == BurnType.Erase)
						{
							if (info.TargetDevice == null) { throw new InvalidOperationException("Cannot erase disc in an image recorder."); }
						}
						else
						{
							using (var form = new FormStartBurn())
							{
								form.ApproximateSpaceNeeded = source.GetLength();
								form.MasteringOptionsEnabled = info.Source is UdfMaster;
								form.CurrentDevice = info.TargetDevice;
								if (form.ShowDialog(this) == DialogResult.OK)
								{
									info.SetCDSpeed = form.SetCDSpeed;
									info.BufferSize = form.BufferSize;
									var asMaster = info.Source as UdfMaster;
									if (asMaster != null)
									{
										asMaster.EncodeDuplicatesOnce = form.FindDuplicates;
										asMaster.AllowIcbDataEmbedding = form.EmbedFiles;
									}
								}
								else
								{
									if (form.CurrentDevice != null)
									{
										form.CurrentDevice.Dispose();
										form.CurrentDevice = null;
									}
									return;
								}
							}
						}
						if (type == BurnType.Burn && item.DevicePath == null)
						{
							//If the drive path is null, we're saving to an image file
							if (this.sfdSaveImage.ShowDialog(this) == DialogResult.OK)
							{ info.TargetImage = FSInterface.Wrap(new FileInfo(this.sfdSaveImage.FileName)); }
							else { return; }
						}
						((FormMdiParent)this.MdiParent).DoWork(info);
					}
#if CATCH
					catch
					{
						if (targetDevice != null) { targetDevice.Dispose(); }
						throw;
					}
#endif
				}
#if CATCH
				catch (Exception ex)
				{
					MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
#endif
			}
		}

		private void cmbAllOptions_SelectedIndexChanged(object sender, EventArgs e)
		{
			var enumValue = (EnumValue)((ComboBox)sender).SelectedItem;
			string description;
			if (enumValue != null)
			{
				description = enumValue.Description;
			}
			else { description = null; }
			this.ttpMain.SetToolTip((Control)sender, description);
		}

		private void lvFiles_AfterLabelEdit(object sender, LabelEditEventArgs e)
		{
			if (e.Label != null)
			{
				if (this.CheckFileNameAndDisplayMessageBox(e.Label))
				{
					var item = this.lvFiles.Items[e.Item];
					var tag = (ItemTag)item.Tag;
					string prevName = tag.FileInfo.Name;
#if CATCH
					try
#endif
					{
						item.Name = e.Label;
#if CATCH
						try
#endif
						{
							tag.Directory.RenameFile(tag.FileInfo, e.Label);
						}
#if CATCH
						catch
						{
							item.Name = prevName;
							throw;
						}
#endif
						item.Text = item.Name;
					}
#if CATCH
					catch
					{
						e.CancelEdit = true;
						throw;
					}
#endif
				}
				else { e.CancelEdit = true; }
			}
			else { e.CancelEdit = true; }
		}

		private void lvFiles_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F2:
					if (this.lvFiles.FocusedItem != null) { this.lvFiles.FocusedItem.BeginEdit(); }
					break;
				case Keys.Delete:
					this.DeleteSelectedFiles();
					break;
			}
		}

		private void DeleteSelectedFiles()
		{
			if (this.lvFiles.SelectedIndices.Count > 0)
			{
				var indices = new int[this.lvFiles.SelectedIndices.Count];
				this.lvFiles.SelectedIndices.CopyTo(indices, 0);
				if (MessageBox.Show(this, string.Format("Are you sure you want to remove the {0:N0} selected file(s)?", indices.Length), "Confirm Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					var node = (DirectoryTreeNode)this.tvDirectories.SelectedNode;
					for (int i = indices.Length - 1; i >= 0; i--)
					{
						this.lvFiles.SelectedIndices.Remove(indices[i]);
						node.Files.RemoveAt(indices[i]);
						this.lvFiles.VirtualListSize--;
					}
				}
				this.CalculateSpace();
			}
		}

		private void lvFiles_BeforeLabelEdit(object sender, LabelEditEventArgs e) { }
		private void lvFiles_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e) { e.Item = this.GetItem((DirectoryTreeNode)this.tvDirectories.SelectedNode, e.ItemIndex); }

		private UdfMaster GetUdfMaster()
		{
			this.master.LogicalVolumeIdentifier = this.tvDirectories.Nodes[0].Text;
			return this.master;
		}

		private void tsbBurn_Click(object sender, EventArgs e)
		{
		    DoWork(BurnType.Burn, GetUdfMaster());
		}

		private void tsbOpenImage_Click(object sender, EventArgs e)
		{
			var item = (DriveItem)this.tscmbDevice.SelectedItem;
			if (item.DevicePath != null || MessageBox.Show(this, "You have requested to open an image file and \"burn\" it to a virtual drive." + Environment.NewLine + "This action will, in effect, simply open an existing file and create a new copy of it." + Environment.NewLine + "If this is what you intended, press OK; otherwise, press Cancel and select a different drive.", "Possible Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.OK)
			{
				if (this.ofdMain.ShowDialog(this) == DialogResult.OK)
				{
					this.DoWork(BurnType.Burn, FSInterface.Wrap(new FileInfo(this.ofdMain.FileName)));
				}
			}
		}

		private void CalculateSpace()
		{
			using (new CursorChange(this, Cursors.WaitCursor))
			{
				long metadataSize, fileCount, dirCount;
				long partitionSize = this.GetUdfMaster().GetLength(out fileCount, out dirCount, out metadataSize);
				long sizeExceptPartition = 256 * Program.BLOCK_SIZE /*For first AVDP*/ + (256 + 1) * Program.BLOCK_SIZE  /*For last AVDP(s)*/;
				long estimate = sizeExceptPartition + partitionSize;
				metadataSize += sizeExceptPartition;
				this.sbPnlStage.Text = string.Format("{0:N0} {1} containing {2:N0} {3}", dirCount, dirCount == 1 ? "folder" : "folders", fileCount, fileCount == 1 ? "file" : "files");
				this.sbPnlDescription.Text = string.Format("{0:N1} MiB (including {1:N1} MiB for metadata)", (double)estimate / (1024 * 1024), (double)metadataSize / (1024 * 1024));
				this.capacityBar.Value = estimate;
				long nextSmallestMarker = -1;
				long largestMarker = -1;
				if (this.capacityBar.Markers != null)
				{
					foreach (var marker in this.capacityBar.Markers)
					{
						if (marker.Location >= this.capacityBar.Value) { nextSmallestMarker = nextSmallestMarker == -1 ? marker.Location : Math.Min(marker.Location, nextSmallestMarker); }
						largestMarker = largestMarker == -1 ? marker.Location : Math.Max(largestMarker, marker.Location);
					}
				}
				if (nextSmallestMarker != -1) { this.capacityBar.Capacity = nextSmallestMarker; }
				else { this.capacityBar.Capacity = largestMarker; }

				var item = (DriveItem)this.tscmbDevice.SelectedItem;
#if false
				if (item.DevicePath == null) { this.capacityBar.Capacity = this.capacityBar.Value; }
				else
				{
					using (var device = this.OpenDrive(item.DevicePath, 0))
					{
						Win32DeviceType devType;
						var types = device.Interface.GetMediaTypesEx(out devType);

						if (types.Length > 0)
						{
							var t = types[0];
							this.capacityBar.Capacity = (long)t.DiskGeometry.BytesPerSector * (long)t.DiskGeometry.SectorsPerTrack * (long)t.DiskGeometry.TracksPerCylinder * (long)t.DiskGeometry.Cylinders;
						}
						else { this.capacityBar.Capacity = this.capacityBar.Value; }
					}
				}
#endif
			}
		}

		private void tvDirectories_ItemDrag(object sender, ItemDragEventArgs e) { if (e.Button == MouseButtons.Left) { var effects = this.tvDirectories.DoDragDrop(e.Item, DragDropEffects.Copy | DragDropEffects.Move); } }

		private void lvFiles_ItemDrag(object sender, ItemDragEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				var asItem = e.Item as ListViewItem;
				if (asItem != null)
				{
					ListViewItem[] items;
					if (this.lvFiles.VirtualMode)
					{
						var selectedIndices = new int[this.lvFiles.SelectedIndices.Count];
						this.lvFiles.SelectedIndices.CopyTo(selectedIndices, 0);
						items = new ListViewItem[selectedIndices.Length];
						for (int i = 0; i < selectedIndices.Length; i++)
						{ items[i] = this.GetItem(((ItemTag)asItem.Tag).Directory, selectedIndices[i]); }
					}
					else
					{
						items = new ListViewItem[this.lvFiles.SelectedItems.Count];
						this.lvFiles.SelectedItems.CopyTo(items, 0);
					}
					var effects = this.lvFiles.DoDragDrop(items, DragDropEffects.Copy);
				}
			}
		}

		private void miDirectoriesNewFolder_Click(object sender, EventArgs e)
		{
			var node = (DirectoryTreeNode)this.tvDirectories.SelectedNode;
			string name = "New Folder";
			if (node.Contains(name))
			{
				for (int i = 1; i < int.MaxValue; i++)
				{
					string n = name + " " + i.ToString();
					if (!node.Contains(n)) { name = n; break; }
				}
			}
			DirectoryTreeNode newNode;
			int lastProgressReportTick = Environment.TickCount;
			var virt = new VirtualDirectoryInfo(null);
			virt.Rename(name);
			this.ToNode(virt, false, FOLDER_IMAGE_KEY, new ProgressDialogInfo(null), ref lastProgressReportTick, out newNode);
			node.Nodes.Add(newNode);
			this.tvDirectories.SelectedNode = newNode;
			newNode.BeginEdit();
		}

		protected override CreateParams CreateParams { get { var cp = base.CreateParams; cp.Style &= ~0x00030000; cp.ClassStyle |= 0x0200; return cp; } }

		private void miRecorderBlank_Click(object sender, EventArgs e) { this.DoWork(BurnType.Erase, null); }

		private void miRecorderGetFeatures_Click(object sender, EventArgs e)
		{
			var item = (DriveItem)this.tscmbDevice.SelectedItem;
			if (item.DevicePath == null)
			{
				MessageBox.Show(this, "This is a virtual drive used for image recording; it has no particular features.", "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else
			{
				using (new CursorChange(this, Cursors.WaitCursor))
				{
					using (var form = new FormFeatures())
					{
						using (var cd = this.OpenDrive(item.DevicePath, Win32FileAccess.GenericRead | Win32FileAccess.Synchronize))
						{
							var features = cd.Interface.GetCdromConfiguration(FeatureCode.ProfileList, FeatureRequestType.SupportedFeatureHeaderAndDescriptors);
							form.SelectedObject = features;
						}
						form.ShowDialog(this);
					}
				}
			}
		}

		private void tsbShowExplorer_CheckedChanged(object sender, EventArgs e) { this.scMain.Panel2Collapsed = !this.tsbShowExplorer.Checked; }

		private void miSplitterRotate_Click(object sender, EventArgs e)
		{
			double percent = (double)this.scMain.SplitterDistance / (this.scMain.Orientation == Orientation.Vertical ? (double)this.scMain.ClientSize.Width : (double)this.scMain.ClientSize.Height);
			this.scMain.Orientation = this.scMain.Orientation == Orientation.Vertical ? Orientation.Horizontal : Orientation.Vertical;
			this.scMain.SplitterDistance = (int)(percent * (this.scMain.Orientation == Orientation.Vertical ? (double)this.scMain.ClientSize.Width : (double)this.scMain.ClientSize.Height));
		}

		private void shellBrowser_ItemFilter(object sender, ItemFilterEventArgs e)
		{
			var rid = e.RelativeId;
			bool success = false;
			try
			{
				rid.DangerousAddRef(ref success);
				Trace.Assert(success);
				var ids = new IntPtr[] { rid.DangerousGetHandle() };
				var sfgao = SFGAO.Folder | SFGAO.FileSystem | SFGAO.FileSystemAncestor;
				var f = ShellUtil.OpenFolder(e.ParentId);
				f.GetAttributesOf(ids.Length, ids, ref sfgao);
				e.Cancel = (sfgao & (SFGAO.FileSystemAncestor | SFGAO.FileSystem)) == 0;
			}
			finally { if (success) { rid.DangerousRelease(); } }
		}

		private void miRecorderReadWriteErrorRecoveryParameters_Click(object sender, EventArgs e)
		{
			var item = (DriveItem)this.tscmbDevice.SelectedItem;
			if (item.DevicePath == null)
			{
				MessageBox.Show(this, "This is a virtual drive used for image recording; it has no error recovery parameters.", "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else
			{
				using (new CursorChange(this, Cursors.WaitCursor))
				{
					using (var form = new FormErrorRecovery())
					{
						using (var cd = this.OpenDrive(item.DevicePath, Win32FileAccess.GenericRead | Win32FileAccess.GenericWrite | Win32FileAccess.Synchronize))
						{
							form.SelectedObject = cd.GetReadWriteErrorRecoveryParameters(new ModeSense10Command(PageControl.CurrentValues));
							if (form.ShowDialog(this) == DialogResult.OK)
							{
								cd.SetReadWriteErrorRecoveryParameters(new ModeSelect10Command(false, true), form.SelectedObject);
							}
						}
					}
				}
			}
		}
	}

	[System.Security.SuppressUnmanagedCodeSecurity]
	internal sealed class SafeLibraryHandle : Microsoft.Win32.SafeHandles.SafeHandleZeroOrMinusOneIsInvalid
	{
		private SafeLibraryHandle() : base(true) { }

		protected override bool ReleaseHandle() { return FreeLibrary(base.handle); }

		internal static SafeLibraryHandle LoadLibraryEx(string libFilename) { var result = LoadLibraryEx(libFilename, IntPtr.Zero, 0); if (result.IsInvalid) { Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error()); } return result; }

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[DllImport("Kernel32.dll", SetLastError = true)]
		private static extern bool FreeLibrary(IntPtr hModule);
		
		[DllImport("Kernel32.dll", SetLastError = true)]
		private static extern SafeLibraryHandle LoadLibraryEx(string libFilename, IntPtr reserved, int flags);

		[DllImport("Kernel32.dll", SetLastError = true)]
		public static extern IntPtr GetProcAddress(SafeLibraryHandle hModule, [MarshalAs(UnmanagedType.LPStr)] string lpProcName);
		
		[DllImport("Kernel32.dll", SetLastError = true)]
		public static extern IntPtr GetProcAddress(SafeLibraryHandle hModule, IntPtr lpProcName);
	}
}