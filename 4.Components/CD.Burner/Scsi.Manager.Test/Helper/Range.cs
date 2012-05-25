using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
namespace Helper
{
	[DebuggerDisplay("[{Start}, {End})")]
	public struct Range<T>
	{
		public T Start;
		public T End;
		public Range(T start, T end)
		{
			this.Start = start;
			this.End = end;
		}

		public bool Contains(T value, [Optional, DefaultParameterValue(null)] IComparer<T> comparer)
		{
			if (comparer == null)
			{
				comparer = Comparer<T>.Default;
			}
			int startValueCompare = comparer.Compare(this.Start, value);
			int valueEndCompare = comparer.Compare(value, this.End);
			return ((startValueCompare <= 0) == (valueEndCompare < 0));
		}

		public Range<T> Reverse()
		{
			return new Range<T>(this.End, this.Start);
		}

		public bool Overlaps(Range<T> other, [Optional, DefaultParameterValue(null)] IComparer<T> comparer)
		{
			if (comparer == null)
			{
				comparer = Comparer<T>.Default;
			}
			return (((comparer.Compare(this.Start, other.Start) <= 0) & (comparer.Compare(this.End, other.Start) > 0)) | ((comparer.Compare(other.Start, this.Start) <= 0) & (comparer.Compare(other.End, this.Start) > 0)));
		}

		public override string ToString()
		{
			return ("[" + this.Start.ToString() + ", " + this.End.ToString() + ")");
		}

		public sealed class EndComparer : Comparer<Range<T>>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			private static EndComparer _Default;
			private IComparer<T> valueComparer;

			public EndComparer([Optional, DefaultParameterValue(null)] IComparer<T> comparer)
			{
				if (comparer == null)
				{
					comparer = Comparer<T>.Default;
				}
				this.valueComparer = comparer;
			}

			public override int Compare(Range<T> x, Range<T> y)
			{
				return this.valueComparer.Compare(x.End, y.End);
			}

			public static new EndComparer Default
			{
				get
				{
					if (EndComparer._Default == null)
					{
						Interlocked.CompareExchange<EndComparer>(ref EndComparer._Default, new EndComparer(null), null);
					}
					return EndComparer._Default;
				}
			}
		}

		public sealed class StartComparer : Comparer<Range<T>>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			private static StartComparer _Default;
			private IComparer<T> valueComparer;

			public StartComparer([Optional, DefaultParameterValue(null)] IComparer<T> comparer)
			{
				if (comparer == null)
				{
					comparer = Comparer<T>.Default;
				}
				this.valueComparer = comparer;
			}

			public override int Compare(Range<T> x, Range<T> y)
			{
				return this.valueComparer.Compare(x.Start, y.Start);
			}

			public static new StartComparer Default
			{
				get
				{
					if (StartComparer._Default == null)
					{
						Interlocked.CompareExchange<StartComparer>(ref StartComparer._Default, new StartComparer(null), null);
					}
					return StartComparer._Default;
				}
			}
		}
	}
}