using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows.Forms;
using Helper.Forms;

namespace BurnApp
{
	[SuppressUnmanagedCodeSecurity]
	static class Program
	{
		public static readonly TimeSpan INSTANTANEOUS_SPEED_INCLUSION_TIME = new TimeSpan(0, 0, 0, 5, 0);
		//  ***** DON'T ******    lower this below 100 ms -- Windows seems to have a hard time keeping up and uses up a lot of CPU
		public static volatile int SLOW_UPDATE_PAUSE_MILLIS = Environment.OSVersion.Platform == PlatformID.Win32NT && Environment.OSVersion.Version.Major >= 6 ? 500 /*Aero in Vista+ slows things down*/ : 50;
		public static volatile int FAST_UPDATE_PAUSE_MILLIS = Environment.OSVersion.Platform == PlatformID.Win32NT && Environment.OSVersion.Version.Major >= 6 ? 250 /*Aero in Vista+ slows things down*/ : 40;
		public static readonly int POLL_MILLIS = 5;
		public static readonly int POLL_SPIN = 10000;
		public static readonly int BLOCK_SIZE = 2048;

		[STAThread]
		static void Main()
		{
			try { typeof(Control).GetField("defaultFont", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetValue(null, SystemFonts.MessageBoxFont); }
			catch { }
			try { typeof(ToolStripManager).GetField("defaultFont", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetValue(null, SystemFonts.MessageBoxFont); }
			catch { }
			Application.OleRequired();
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			//Application.Run(new FormTemp());
			Application.Run(new FormMdiParent());
		}

		public static Image Overlay(Image target, Image overlay, System.Drawing.ContentAlignment alignment)
		{
			var result = (Image)target.Clone();
			Rectangle rect;
			switch (alignment)
			{
				case System.Drawing.ContentAlignment.BottomLeft:
					rect = new Rectangle(new Point(0, target.Height - overlay.Height), overlay.Size);
					break;
				case System.Drawing.ContentAlignment.BottomCenter:
					rect = new Rectangle(new Point((target.Width - overlay.Width) / 2, target.Height - overlay.Height), overlay.Size);
					break;
				case System.Drawing.ContentAlignment.BottomRight:
					rect = new Rectangle(new Point(target.Width - overlay.Width, target.Height - overlay.Height), overlay.Size);
					break;
				case System.Drawing.ContentAlignment.MiddleLeft:
					rect = new Rectangle(new Point(0, (target.Height - overlay.Height) / 2), overlay.Size);
					break;
				case System.Drawing.ContentAlignment.MiddleCenter:
					rect = new Rectangle(new Point((target.Width - overlay.Width) / 2, (target.Height - overlay.Height) / 2), overlay.Size);
					break;
				case System.Drawing.ContentAlignment.MiddleRight:
					rect = new Rectangle(new Point(target.Width - overlay.Width, (target.Height - overlay.Height) / 2), overlay.Size);
					break;
				case System.Drawing.ContentAlignment.TopLeft:
					rect = new Rectangle(new Point(0, 0), overlay.Size);
					break;
				case System.Drawing.ContentAlignment.TopCenter:
					rect = new Rectangle(new Point((target.Width - overlay.Width) / 2, 0), overlay.Size);
					break;
				case System.Drawing.ContentAlignment.TopRight:
					rect = new Rectangle(new Point(target.Width - overlay.Width, 0), overlay.Size);
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
			using (var g = Graphics.FromImage(result)) { g.DrawImageUnscaled(overlay, rect); }
			return result;
		}

		public static string CurrentAssemblyTitle
		{
			get
			{
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
				if (attributes.Length > 0)
				{
					AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
					if (titleAttribute.Title != "")
					{
						return titleAttribute.Title;
					}
				}
				return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
			}
		}

		public static object SetProperty(Control control, string name, object value, bool recurse) { object result = null; var property = control.GetType().GetProperty(name, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance); if (property != null) { result = property.GetValue(control, null); property.SetValue(control, value, null); } foreach (Control c in control.Controls) { SetProperty(c, name, value, recurse); } return result; }

		public static string FormatTimeUserFriendly(TimeSpan timeRemaining, int maxDigits)
		{
			//return string.Format("{0}{1:D2}:{2:D2}:{3:D2}", timeRemaining < TimeSpan.Zero ? "-" : string.Empty, Math.Abs(timeRemaining.Hours), Math.Abs(timeRemaining.Minutes), Math.Abs(timeRemaining.Seconds));
			//*
			if (timeRemaining < TimeSpan.Zero) { timeRemaining = TimeSpan.Zero; }
			if (timeRemaining.Days >= 1) { return string.Format("{0:N" + maxDigits.ToString() + "} days", timeRemaining.TotalDays); }
			if (timeRemaining.TotalMilliseconds > int.MaxValue) { return timeRemaining.ToString(); }
			else
			{
				var sb = new System.Text.StringBuilder(1024);
				var msRemaining = timeRemaining.TotalMilliseconds;
				//msRemaining -= msRemaining % 5000;
				sb.Length = Program.StrFromTimeInterval(sb, sb.Capacity, (int)msRemaining, maxDigits);
				return sb.ToString();
			}
			//*/
		}

		public static int RoundUserFriendly(double speed, int radix, int sigDigits)
		{
			if (double.IsNaN(speed)) { speed = 0; }
			speed = Math.Max(int.MinValue / 2, Math.Min(int.MaxValue / 2, speed));
			int intSpeed = (int)(speed + radix / 2);
			int log = 0;
			int temp = intSpeed;
			while (temp > 0)
			{
				temp /= radix;
				log++;
			}
			int pow = radix;
			for (int i = 0; i < Math.Max(0, log - sigDigits - 1); i++) { pow *= radix; }
			return intSpeed / pow * pow;
		}

		public static string FormatByteSize(long bytes, int maxMultipleOfPower, byte decimalPlaces, out DataUnits units)
		{
			const int power = 1024;
			int i = 0;
			long divided = bytes;
			long pow = 1;
			while (divided / pow > maxMultipleOfPower - 1 && i < 4) { pow *= power; i++; }
			pow /= power;
			i--;
			units = (DataUnits)i;
			return ((double)bytes / pow).ToString("N" + decimalPlaces);
		}

		public static Icon SHGetFileIcon(string filePath, int? fileAttributes, out int iconIndex, bool? getLargeIcon)
		{
			//if (string.Equals(System.IO.Path.GetExtension(filePath), ".exe", StringComparison.CurrentCultureIgnoreCase)) { iconIndex = -3; return Helper.Drawing.SystemIcons.LoadIcon("Shell32.dll", 3); }
			//ese
			{
				var output = new SHFILEINFO();
				IntPtr result = SHGetFileInfo(filePath, fileAttributes.GetValueOrDefault(), out output, (uint)Marshal.SizeOf(typeof(SHFILEINFO)), ShellFileInformationType.ICON | (getLargeIcon == true ? ShellFileInformationType.LARGEICON : (getLargeIcon == false ? ShellFileInformationType.SMALLICON : ShellFileInformationType.None)) | (fileAttributes != null ? ShellFileInformationType.USEFILEATTRIBUTES : ShellFileInformationType.None));
				if (result != IntPtr.Zero)
				{
					if (output.hIcon != IntPtr.Zero)
					{
						iconIndex = output.iIcon;
						using (var icon = System.Drawing.Icon.FromHandle(output.hIcon))
						{
							var dup = (System.Drawing.Icon)icon.Clone();
							WinHelper.UnsafeNativeMethods.DestroyIcon(output.hIcon);
							return dup;
						}
					}
					else { iconIndex = -1; return null; }
				}
				else { iconIndex = -1; if (Marshal.GetLastWin32Error() != 0) { Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error()); } return null; }
			}
		}

		public static Icon LoadImageIcon(IntPtr hInstance, short icon, [Optional, DefaultParameterValue(0)] int width, [Optional, DefaultParameterValue(0)] int height, [Optional, DefaultParameterValue(LoadOptions.None)] LoadOptions fuLoad)
		{
			IntPtr hImage = WinHelper.UnsafeNativeMethods.LoadImage(hInstance, (IntPtr)icon, ImageType.Icon, width, height, fuLoad);
			if (hImage == IntPtr.Zero) { Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error()); }
			return Icon.FromHandle(hImage);
		}

		#region DLL Imports
		[DllImport("Kernel32.dll", SetLastError = true)]
		private static extern IntPtr LoadLibrary([In] string lpFileName);

		[DllImport("Kernel32.dll", SetLastError = true)]
		private static extern bool FreeLibrary([In] IntPtr hModule);

		[DllImport("Shell32.dll", SetLastError = true)]
		private static extern IntPtr SHGetFileInfo(string pszPath, int dwFileAttributes, out SHFILEINFO psfi, uint cbFileInfo, ShellFileInformationType uFlags);

		[DllImport("ShlWAPI.dll", SetLastError = false)]
		public static extern int StrFromTimeInterval([Out] System.Text.StringBuilder pszOut, int cchMax, int dwTimeMS, int digits);
		#endregion

		public static string GetUserFriendlyString(DataUnits units)
		{
			switch (units)
			{
				case DataUnits.Bytes:
					return "bytes";
				case DataUnits.Kilobytes:
					return "KiB";
				case DataUnits.Megabytes:
					return "MiB";
				case DataUnits.Gigabytes:
					return "GiB";
				case DataUnits.Terabytes:
					return "TiB";
				default:
					throw new ArgumentOutOfRangeException("steps", units, "Invalid units.");
			}
		}
	}

	public struct CursorChange : IDisposable
	{
		private Control control;
		private Cursor oldCursor;

		public CursorChange(Control control, Cursor newCursor)
		{
			this.control = control;
			this.oldCursor = control == null ? Cursor.Current : control.Cursor;
			var p = Cursor.Position;
			if (control != null)
			{
				var child = control;
				for (; ; )
				{
					var c = child.GetChildAtPoint(child.PointToClient(p));
					if (c == null) { break; }
					child = c;
				}
				if (child.Cursor == Cursors.Default)
				{ control.Cursor = newCursor; }
				else { this.oldCursor = null; }
			}
			else { if (Cursor.Current == Cursors.Default) { Cursor.Current = newCursor; } else { this.oldCursor = null; } }
		}

		public void Dispose() { if (this.oldCursor != null) { if (control != null) { control.Cursor = this.oldCursor; } else { Cursor.Current = this.oldCursor; } } this.oldCursor = null; }
	}

	public struct MemoryStatusEx
	{
		public int length;
		public int memoryLoad;
		public long totalPhys;
		public long availPhys;
		public long totalPageFile;
		public long availPageFile;
		public long totalVirtual;
		public long availVirtual;
		public long availExtendedVirtual;

		[System.Security.SuppressUnmanagedCodeSecurity, DllImport("Kernel32.dll", SetLastError = true)]
		private static extern bool GlobalMemoryStatusEx([In, Out] ref MemoryStatusEx buffer);

		public static MemoryStatusEx GlobalMemoryStatusEx() { var mem = new MemoryStatusEx() { length = Marshal.SizeOf(typeof(MemoryStatusEx)) }; if (!GlobalMemoryStatusEx(ref mem)) { Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error()); } return mem; }
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SystemInfo
	{
		public int OemId;
		public int PageSize;
		public IntPtr MinimumApplicationAddress;
		public IntPtr MaximumApplicationAddress;
		public IntPtr ActiveProcessorMask;
		public int NumberOfProcessors;
		public int ProcessorType;
		public int AllocationGranularity;
		public short ProcessorLevel;
		public short ProcessorRevision;
		[System.Security.SuppressUnmanagedCodeSecurity, DllImport("Kernel32.dll", SetLastError = true)]
		private static extern void GetSystemInfo(out SystemInfo lpSystemInfo);
		public static SystemInfo Current { get { SystemInfo info; GetSystemInfo(out info); return info; } }
	}


	internal class EnumValue
	{
		public EnumValue(Enum value)
		{
			var enumField = value.GetType().GetField(value.ToString());
			var displayName = (EnumValueDisplayNameAttribute)Attribute.GetCustomAttribute(enumField, typeof(EnumValueDisplayNameAttribute));
			this.Text = displayName != null ? displayName.DisplayName : enumField.Name;
			var da = (DescriptionAttribute)Attribute.GetCustomAttribute(enumField, typeof(DescriptionAttribute));
			this.Description = da != null ? da.Description : null;
			this.Value = enumField.GetValue(null);
		}

		public readonly string Text;
		public readonly string Description;
		public readonly object Value;
		public override string ToString() { return this.Text; }
		public override int GetHashCode() { return this.Value.GetHashCode(); }
		public override bool Equals(object obj) { return obj is EnumValue && ((EnumValue)obj).Value.Equals(this.Value); }
	}

	public enum DataUnits
	{
		Bytes = 0,
		Kilobytes = 1,
		Megabytes = 2,
		Gigabytes = 3,
		Terabytes = 4,
	}

	#region Native Structures

	public enum MenuItemEnableState { Enabled = 0x00000000, Grayed = 0x00000001, Disabled = 0x00000002 }

	public enum RemoveMenuFlags { ByCommand = 0x00000000, ByPosition = 0x00000400 }

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct SHFILEINFO
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public const ushort DISPLAY_NAME_LENGTH = 260;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public const ushort TYPE_NAME_LENGTH = 260;
		public IntPtr hIcon;
		public int iIcon;
		public uint dwAttributes;
		//[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
		private unsafe fixed char szDisplayName[DISPLAY_NAME_LENGTH];
		//[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
		private unsafe fixed char szTypeName[TYPE_NAME_LENGTH];
		public string DisplayName
		{
			get
			{
				unsafe
				{
					fixed (char* pName = this.szDisplayName)
					{
						if (pName[DISPLAY_NAME_LENGTH - 1] != '\0') { return Marshal.PtrToStringUni((IntPtr)pName, DISPLAY_NAME_LENGTH); }
						else { return Marshal.PtrToStringUni((IntPtr)pName); }
					}
				}
			}
		}
		public string TypeName
		{
			get
			{
				unsafe
				{
					fixed (char* pName = this.szTypeName)
					{
						if (pName[DISPLAY_NAME_LENGTH - 1] != '\0') { return Marshal.PtrToStringUni((IntPtr)pName, DISPLAY_NAME_LENGTH); }
						else { return Marshal.PtrToStringUni((IntPtr)pName); }
					}
				}
			}
		}
	}

	[Flags]
	public enum ShellFileInformationType : int
	{
		None = 0x000000000,
		ICON = 0x000000100,     // get icon
		DISPLAYNAME = 0x000000200,     // get display name
		TYPENAME = 0x000000400,     // get type name
		ATTRIBUTES = 0x000000800,     // get attributes
		ICONLOCATION = 0x000001000,     // get icon location
		EXETYPE = 0x000002000,     // return exe type
		SYSICONINDEX = 0x000004000,     // get system icon index
		LINKOVERLAY = 0x000008000,     // put a link overlay on icon
		SELECTED = 0x000010000,     // show icon in selected state
		ATTR_SPECIFIED = 0x000020000,     // get only specified attributes
		LARGEICON = 0x000000000,     // get large icon
		SMALLICON = 0x000000001,     // get small icon
		OPENICON = 0x000000002,     // get open icon
		SHELLICONSIZE = 0x000000004,     // get shell size icon
		PIDL = 0x000000008,     // pszPath is a pidl
		USEFILEATTRIBUTES = 0x000000010,     // use passed dwFileAttribute
		ADDOVERLAYS = 0x000000020,     // apply the appropriate overlays
		OVERLAYINDEX = 0x000000040,     // Get the index of the overlay
	}
	#endregion

	public struct ValueWithDescription
	{
		public ValueWithDescription(object value, string text, string description) { this.Value = value; this.Text = text; this.Description = description; }
		public readonly string Text;
		public readonly string Description;
		public readonly object Value;
		public override string ToString() { return this.Text; }
	}

	public class ToolStripNoBorderRenderer : ToolStripRenderer
	{
		private ToolStripRenderer renderer;
		public ToolStripNoBorderRenderer(ToolStripRenderer renderer) : base() { this.renderer = renderer; }
		protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e) { this.renderer.DrawArrow(e); }
		protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e) { this.renderer.DrawButtonBackground(e); }
		protected override void OnRenderDropDownButtonBackground(ToolStripItemRenderEventArgs e) { this.renderer.DrawDropDownButtonBackground(e); }
		protected override void OnRenderGrip(ToolStripGripRenderEventArgs e) { this.renderer.DrawGrip(e); }
		protected override void OnRenderImageMargin(ToolStripRenderEventArgs e) { this.renderer.DrawImageMargin(e); }
		protected override void OnRenderItemBackground(ToolStripItemRenderEventArgs e) { this.renderer.DrawItemBackground(e); }
		protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e) { this.renderer.DrawItemCheck(e); }
		protected override void OnRenderItemImage(ToolStripItemImageRenderEventArgs e) { this.renderer.DrawItemImage(e); }
		protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e) { this.renderer.DrawItemText(e); }
		protected override void OnRenderLabelBackground(ToolStripItemRenderEventArgs e) { this.renderer.DrawLabelBackground(e); }
		protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e) { this.renderer.DrawMenuItemBackground(e); }
		protected override void OnRenderOverflowButtonBackground(ToolStripItemRenderEventArgs e) { this.renderer.DrawOverflowButtonBackground(e); }
		protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e) { this.renderer.DrawSeparator(e); }
		protected override void OnRenderSplitButtonBackground(ToolStripItemRenderEventArgs e) { this.renderer.DrawSplitButton(e); }
		protected override void OnRenderStatusStripSizingGrip(ToolStripRenderEventArgs e) { this.renderer.DrawStatusStripSizingGrip(e); }
		protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e) { this.renderer.DrawToolStripBackground(e); }
		protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e) { if (e.ToolStrip is StatusStrip || e.ToolStrip is ToolStripDropDown) { this.renderer.DrawToolStripBorder(e); } }
		protected override void OnRenderToolStripContentPanelBackground(ToolStripContentPanelRenderEventArgs e) { this.renderer.DrawToolStripContentPanelBackground(e); }
		protected override void OnRenderToolStripPanelBackground(ToolStripPanelRenderEventArgs e) { this.renderer.DrawToolStripPanelBackground(e); }
		protected override void OnRenderToolStripStatusLabelBackground(ToolStripItemRenderEventArgs e) { this.renderer.DrawToolStripStatusLabelBackground(e); }
	}
}