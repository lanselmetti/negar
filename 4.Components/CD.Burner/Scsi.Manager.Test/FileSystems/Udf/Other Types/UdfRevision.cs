using System;
using System.Diagnostics;

namespace FileSystems.Udf
{
	public struct UdfRevision : IComparable<UdfRevision>
	{
		public UdfRevision(byte major, byte minor) { this.value = (ushort)(((ushort)major << 8) | (ushort)minor); }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly ushort value;
		public byte MajorVersion { get { return (byte)(this.value >> 8); } }
		public byte MinorVersion { get { return unchecked((byte)this.value); } }
		public override bool Equals(object obj) { return obj is UdfRevision && this.Equals((UdfRevision)obj); }
		public override int GetHashCode() { return this.value.GetHashCode(); }
		public bool Equals(UdfRevision other) { return this.value == other.value; }
		public int CompareTo(UdfRevision other) { return this.value.CompareTo(other.value); }
		public static bool operator ==(UdfRevision left, UdfRevision right) { return left.Equals(right); }
		public static bool operator !=(UdfRevision left, UdfRevision right) { return !left.Equals(right); }
		public static bool operator <(UdfRevision left, UdfRevision right) { return left.CompareTo(right) < 0; }
		public static bool operator <=(UdfRevision left, UdfRevision right) { return left.CompareTo(right) <= 0; }
		public static bool operator >(UdfRevision left, UdfRevision right) { return left.CompareTo(right) > 0; }
		public static bool operator >=(UdfRevision left, UdfRevision right) { return left.CompareTo(right) >= 0; }
		public override string ToString() { return string.Format("{0:X}.{1:X2}", this.MajorVersion, this.MinorVersion); }
	}
}