using System;
using System.Diagnostics;

namespace FileSystems.Udf
{
	[DebuggerDisplay("{(global::System.DateTime)this}")]
	public struct Timestamp
	{
		public Timestamp(TimestampTypeAndTimezone typeAndTimezone, Int16 year, byte month, byte day, byte hour, byte minute, byte second, byte centiseconds, byte hundredsOfMicroseconds, byte microseconds)
		{
			this.TypeAndTimezone = typeAndTimezone;
			this.Year = year;
			this.Month = month;
			this.Day = day;
			this.Hour = hour;
			this.Minute = minute;
			this.Second = second;
			this.Centiseconds = centiseconds;
			this.HundredsofMicroseconds = hundredsOfMicroseconds;
			this.Microseconds = microseconds;
		}

		/* ECMA 167 1/7.3 */
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly TimestampTypeAndTimezone TypeAndTimezone;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly Int16 Year;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly byte Month;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly byte Day;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly byte Hour;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly byte Minute;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly byte Second;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly byte Centiseconds;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly byte HundredsofMicroseconds;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly byte Microseconds;

		public static implicit operator DateTime(Timestamp value)
		{
			if (value.TypeAndTimezone.Type != 0 & value.TypeAndTimezone.Type != 1) { throw new ArgumentOutOfRangeException("value", value, "Invalid timestamp type."); }
			var result = new DateTime(value.Year, value.Month, value.Day, value.Hour, value.Minute, value.Second, value.Centiseconds * 10, value.TypeAndTimezone.Type == 1 ? DateTimeKind.Local : DateTimeKind.Utc);
			int microseconds = value.HundredsofMicroseconds * 100 + value.Microseconds;
			result = result.AddTicks(microseconds * 10);
			return result;
		}

		public static explicit operator Timestamp(DateTime value)
		{
			return new Timestamp(new TimestampTypeAndTimezone(value.Kind == DateTimeKind.Local ? (byte)1 : (byte)0, (short)(value - value.ToUniversalTime()).TotalMinutes), (short)value.Year, (byte)value.Month, (byte)value.Day, (byte)value.Hour, (byte)value.Minute, (byte)value.Second, (byte)(value.Millisecond / 10), (byte)((value.Ticks - value.Ticks / 10000 * 10000) / 1000),
				(byte)((value.Ticks - value.Ticks / 1000 * 1000) / 10));
		}

		public override string ToString() { return ((DateTime)this).ToString(); }
	}

	public struct TimestampTypeAndTimezone
	{
		public TimestampTypeAndTimezone(byte type, short timezone) : this() { this.Type = type; this.Timezone = timezone; }
		private TimestampTypeAndTimezone(ushort value) { this.value = value; }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ushort value;
		public byte Type { get { return (byte)((this.value & 0xF000U) >> 12); } private set { value &= 0x0F; this.value = (ushort)(((uint)this.value & (uint)~0xF000U) | (uint)((ushort)value << 12)); } }
		public short Timezone { get { return unchecked((short)((short)((ushort)(this.value & 0x0FFFU) << 4) >> 4)); } private set { this.value = (ushort)((this.value & ~0x0FFFU) | (value & 0x0FFFU)); } }
	}
}