using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using Helper;

namespace FileSystems.Iso9660
{
	public enum SupplementaryVolumeDescriptorFlags : byte
	{
		None = 0,
		NonstandardEscapeSequence = 1 << 0,
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 17)]
	internal struct VolumeTime
	{
		private VolumeTime(DateTime time)
			: this()
		{
			string str = time.ToString("yyyyMMddHHmmssff", System.Globalization.DateTimeFormatInfo.InvariantInfo);
			unsafe { fixed (byte* pDigits = &this.YearDigit1) { for (int i = 0; i < 16; i++) { pDigits[i] = (byte)str[i]; } } }
			this.GmtOffsetIn15MinIntervalCount = (sbyte)((time.ToLocalTime() - time.ToUniversalTime()).TotalMinutes / 15);
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private byte YearDigit1;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly byte YearDigit2;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly byte YearDigit3;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly byte YearDigit4;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly byte MonthDigit1;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly byte MonthDigit2;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly byte DayDigit1;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly byte DayDigit2;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly byte HourDigit1;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly byte HourDigit2;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly byte MinuteDigit1;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly byte MinuteDigit2;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly byte SecondDigit1;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly byte SecondDigit2;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly byte HundredthOfSecondDigit1;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly byte HundredthOfSecondDigit2;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly sbyte GmtOffsetIn15MinIntervalCount;

		public bool IsEmpty { get { unsafe { fixed (byte* pBytes = &this.YearDigit1) { for (int i = 0; i < 16; i++) { if (pBytes[i] != '0') { return false; } } } } return true; } }

		public static explicit operator VolumeTime(DateTime dateTime) { if (dateTime == default(DateTime)) { return new VolumeTime(); } return new VolumeTime(dateTime); }
		public static implicit operator DateTime(VolumeTime volumeTime)
		{
			if (volumeTime.IsEmpty) { return default(DateTime); }
			string str;
			unsafe
			{
				var sb = new StringBuilder(16);
				byte* pDigits = &volumeTime.YearDigit1;
				for (int i = 0; i < 16; i++)
				{ sb.Append((char)pDigits[i]); }
				str = sb.ToString();
			}
			var result = DateTime.ParseExact(str, @"yyyyMMddHHmmssff", System.Globalization.DateTimeFormatInfo.InvariantInfo, System.Globalization.DateTimeStyles.AssumeUniversal).Subtract(TimeSpan.FromMinutes(15 * volumeTime.GmtOffsetIn15MinIntervalCount));
			return result;
		}
	}

	public enum VolumeDescriptorType : byte
	{
		None = 0x00,
		BootRecord = 0x00,
		PrimaryVolumeDescriptor = 0x01,
		SupplementaryVolumeDescriptor = 0x02,
		VolumePartitionDescriptor = 0x03,
		Termination = byte.MaxValue,
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
	public struct FileSystemIdentifier : IMarshalable, IComparable<FileSystemIdentifier>
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal static readonly int DEFAULT_SIZE = (int)Marshaler.DefaultSizeOf<FileSystemIdentifier>();

		//You MUST use the contructor before marshaling to show whether this is a directory or not
		public FileSystemIdentifier(string name, short version)
		{
			this._FileName = name;
			this._FileVersion = version;
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
		private string _FileName;
		public string FileName { get { return this._FileName; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private short _FileVersion;
		public short FileVersion { get { return this._FileVersion; } }
		public bool IsDirectory { get { return this.FileVersion == 0; } }

		void IMarshalable.MarshalFrom(BufferWithSize buffer)
		{
			if (this.IsDirectory)
			{
				if (buffer.Length32 == 1 && buffer[0] == '\0') { this._FileName = "."; }
				else if (buffer.Length32 == 1 && buffer[0] == '\x01') { this._FileName = ".."; }
				else { this._FileName = buffer.ToStringAnsi(); }
			}
			else
			{
				int separator1Index;
				for (separator1Index = 0; buffer[separator1Index] != '.'; separator1Index++) { }
				int separator2Index;
				for (separator2Index = separator1Index + 1; buffer[separator2Index] != ';'; separator2Index++) { }
				this._FileName = buffer.ExtractSegment(0, separator1Index).ToStringAnsi() + '.' + buffer.ExtractSegment(separator1Index + 1, separator2Index - separator1Index - 1).ToStringAnsi();
				var versionBuffer = buffer.ExtractSegment(separator2Index + 1);
				this._FileVersion = versionBuffer.Length != UIntPtr.Zero ? short.Parse(versionBuffer.ToStringAnsi(), System.Globalization.NumberStyles.AllowTrailingWhite) : (short)1;
			}
		}

		void IMarshalable.MarshalTo(BufferWithSize buffer)
		{
			if (this.IsDirectory)
			{
				if (this.FileName == ".") { buffer[0] = (byte)'\0'; }
				else if (this.FileName == "..") { buffer[0] = (byte)'\x01'; }
				else
				{
					for (int i = 0; i < this.FileName.Length; i++)
					{ buffer[i] = (byte)this.FileName[i]; }
				}
			}
			else
			{
				string fnwe = Path.GetFileNameWithoutExtension(this.FileName);
				string ext = Path.GetExtension(this.FileName);
				int i;
				for (i = 0; i < fnwe.Length; i++) { buffer[i] = (byte)fnwe[i]; }
				buffer[i++] = (byte)'.';
				for (int j = 0; j < ext.Length; j++) { buffer[i++] = (byte)ext[j]; }
				buffer[i++] = (byte)';';
				string ver = this.FileVersion.ToString();
				for (int j = 0; j < ver.Length; j++) { buffer[i++] = (byte)ver[j]; }
				buffer[i++] = 0;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		int IMarshalable.MarshaledSize { get { return this.IsDirectory ? this.FileName.Length : Math.Min(this.FileName.Length, 1) + this.FileVersion.ToString().Length; } }

		public int CompareTo(FileSystemIdentifier other) { int compare = this.FileName.CompareTo(other.FileName); return compare; }

		public override string ToString() { return this.IsDirectory ? this.FileName : this.FileName + ";" + this.FileVersion; }
	}

	[StructLayout(LayoutKind.Sequential, Size = 7, Pack = 1), DebuggerDisplay("{(global::System.DateTime)this}")]
	public struct DirectoryTime
	{
		public DirectoryTime(byte yearSince1900, byte month, byte day, byte hour, byte minute, byte second, sbyte gmtOffsetIn15MinuteIntervalCount)
		{
			this.YearSince1900 = yearSince1900;
			this.Month = month;
			this.Day = day;
			this.Hour = hour;
			this.Minute = minute;
			this.Second = second;
			this.GmtOffsetIn15MinIntervalCount = gmtOffsetIn15MinuteIntervalCount;
		}

		public readonly byte YearSince1900;
		public readonly byte Month;
		public readonly byte Day;
		public readonly byte Hour;
		public readonly byte Minute;
		public readonly byte Second;
		public readonly sbyte GmtOffsetIn15MinIntervalCount; //From -48 to +52 -> +-780 minutes -> +- 13 hrs

		public static implicit operator DateTime(DirectoryTime time)
		{ return new DateTime(1900 + time.YearSince1900, time.Month, time.Day, time.Hour, time.Minute, time.Second, DateTimeKind.Utc).Subtract(TimeSpan.FromMinutes(15 * time.GmtOffsetIn15MinIntervalCount)); }

		public static explicit operator DirectoryTime(DateTime time)
		{
			time = time.ToLocalTime();
			var univTime = time.ToUniversalTime();
			var minsOffset = (time - univTime).TotalMinutes;
			var result = new DirectoryTime((byte)(univTime.Year - 1900), (byte)univTime.Month, (byte)univTime.Day, (byte)univTime.Hour,
				(byte)univTime.Minute, (byte)univTime.Second, (sbyte)(minsOffset / 15));
			return result;
		}
	}

	[Flags]
	public enum DirectoryRecordFlags : byte
	{
		None = 0,
		Hidden = 1 << 0,
		Directory = 1 << 1,
		Associated = 1 << 2,
		Record = 1 << 3,
		Protection = 1 << 4,
		LastDirectoryRecord = 1 << 7,
	}
}