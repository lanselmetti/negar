using System;
using System.Collections.Generic;
using System.Diagnostics;
namespace Helper.Algorithms
{
	public class LinearProgressEstimator
	{
		private int maxPoints;
		private List<OrderedPair> dataPoints;

		private struct OrderedPair : IEquatable<OrderedPair>
		{
			public OrderedPair(double x, double y) { this.X = x; this.Y = y; }
			public double X;
			public double Y;
			public override bool Equals(object obj) { return obj is OrderedPair && ((OrderedPair)obj).Equals(this); }
			public bool Equals(OrderedPair other) { return this.X == other.X & this.Y == other.Y; }
			public override int GetHashCode() { return this.X.GetHashCode() ^ (31 * this.Y).GetHashCode(); }
			public override string ToString() { return string.Format("({0:N}, {1:N})", this.X, this.Y); }
			public static bool operator ==(OrderedPair a, OrderedPair b) { return a.Equals(b); }
			public static bool operator !=(OrderedPair a, OrderedPair b) { return !a.Equals(b); }
		}

		public LinearProgressEstimator(int maxPoints)
		{
			if (maxPoints > 0 && maxPoints < 2) { maxPoints = 2; }
			this.dataPoints = new List<OrderedPair>(maxPoints);
			this.maxPoints = maxPoints;
		}

		public void ReportProgress(double progress)
		{
			if (this.dataPoints.Count >= this.maxPoints) { this.dataPoints.RemoveRange(0, this.dataPoints.Count - this.maxPoints); }
			this.dataPoints.Add(new OrderedPair(System.Environment.TickCount, progress));
		}

		public TimeSpan GetTimeTo(double targetProgress)
		{
			if (this.dataPoints.Count >= 2)
			{
				double progressPerMillisecond, yIntercept;
				Regression.LineFit(0, this.dataPoints.Count, this.dataPoints, out progressPerMillisecond, out yIntercept);
				//return double.IsNaN(progressPerMillisecond) ? TimeSpan.Zero : TimeSpan.FromMilliseconds((targetProgress - yIntercept) / progressPerMillisecond);
				var last = new OrderedPair();
				foreach (var item in this.dataPoints) { last = item; }
				if (progressPerMillisecond == 0 || double.IsNaN(progressPerMillisecond))
				{ return TimeSpan.Zero; }
				else
				{
					var ms = (targetProgress - last.Y) / progressPerMillisecond;
					return ms <= TimeSpan.MaxValue.TotalMilliseconds ? ms >= TimeSpan.MinValue.TotalMilliseconds ? TimeSpan.FromMilliseconds(ms) : TimeSpan.MinValue : TimeSpan.MaxValue;
				}
			}
			else { return TimeSpan.Zero; }
		}

		public double CalculateAverageSpeed()
		{
			double progressPerMillisecond, yIntercept;
			Regression.LineFit(0, this.dataPoints.Count, this.dataPoints, out progressPerMillisecond, out yIntercept);
			return progressPerMillisecond;
		}

		public double CalculateCurrentSpeed(TimeSpan timespanToInclude)
		{
			if (this.dataPoints.Count > 0)
			{
				var lastMillis = this.dataPoints[this.dataPoints.Count - 1].X;
				int count = 0;
				while (this.dataPoints.Count > count && lastMillis - this.dataPoints[this.dataPoints.Count - count - 1].X <= timespanToInclude.TotalMilliseconds)
				{
					count++;
				}
				return this.CalculateCurrentSpeed(count);
			}
			else { return double.NaN; }
		}

		public double CalculateCurrentSpeed(int numPointsToUse)
		{
			if (numPointsToUse < 2) { return double.NaN; }
			if (this.dataPoints.Count >= 2)
			{
				numPointsToUse = Math.Min(numPointsToUse, this.dataPoints.Count);
				double progressPerMillisecond, yIntercept;
				Regression.LineFit(this.dataPoints.Count - numPointsToUse, numPointsToUse, this.dataPoints, out progressPerMillisecond, out yIntercept);
				return progressPerMillisecond;
			}
			else { return double.NaN; }
		}

		public void Clear() { this.dataPoints.Clear(); }

		public int DataPointCount { get { return this.dataPoints.Count; } }

		private static class Regression
		{
			public static void LineFit(out double slope, out double yIntercept, params OrderedPair[] data) { LineFit(0, data.Length, data, out slope, out yIntercept); }

			public static void LineFit(int start, int maxCount, IEnumerable<OrderedPair> data, out double slope, out double yIntercept)
			{
				double sumX = 0, sumY = 0, sumX2 = 0, sumXY = 0;
				int count = 0;
				foreach (var item in data)
				{
					if (start > 0) { start--; }
					else if (maxCount > 0)
					{
						maxCount--;
						sumX += item.X;
						sumY += item.Y;
						sumX2 += item.X * item.X;
						sumXY += item.X * item.Y;
						count++;
					}
					else { break; }
				}
				double denom = count * sumX2 - sumX * sumX;
				slope = (count * sumXY - sumY * sumX) / denom;
				yIntercept = (sumY * sumX2 - sumXY * sumX) / denom;
			}
		}
	}
}