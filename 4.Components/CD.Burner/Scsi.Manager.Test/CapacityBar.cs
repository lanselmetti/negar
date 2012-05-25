using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BurnApp
{
	public partial class CapacityBar : Control
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private BorderStyle _BorderStyle = BorderStyle.None;
		private long _Value = 0, _Capacity = 10;

		public CapacityBar()
		{
			this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			this.SetStyle(ControlStyles.UserPaint, true);
			this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
		}

		[RefreshProperties(RefreshProperties.Repaint), DefaultValue(100L)]
		public long Capacity { get { return this._Capacity; } set { this._Capacity = value; if (this.IsHandleCreated) { this.Invalidate(); } } }

		[RefreshProperties(RefreshProperties.Repaint), DefaultValue(0L)]
		public long Value { get { return this._Value; } set { this._Value = value; if (this.IsHandleCreated) { this.Invalidate(); } } }

		[DefaultValue(BorderStyle.None), RefreshProperties(RefreshProperties.Repaint)]
		public BorderStyle BorderStyle { get { return this._BorderStyle; } set { this._BorderStyle = value; } }

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams createParams = base.CreateParams;
				switch (this.BorderStyle)
				{
					case BorderStyle.FixedSingle:
						createParams.Style |= 0x800000;
						break;
					case BorderStyle.Fixed3D:
						createParams.ExStyle |= 0x200;
						break;
				}
				//createParams.ExStyle |= 0x00000200 /*WS_EX_CLIENTEDGE*/;
				return createParams;
			}
		}

		protected override void OnResize(EventArgs e)
		{
			this.Invalidate();
			base.OnResize(e);
		}

		public Marker[] Markers { get; set; }

		private static string ToString(long size) { return size == 0 ? size.ToString("N0") : (size < 1 << 30 ? string.Format("{0:N0} MiB", size / (double)(1024 * 1024)) : string.Format("{0:N1} GiB", size / (double)(1024 * 1024 * 1024))); }

		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);

			using (var font = new Font(this.Font.FontFamily, this.Font.Size))
			{
				var max = Math.Max(this.Value, this.Capacity);

				var greenEnd = (float)(((double)Math.Min(this.Value, this.Capacity) / (double)max) * this.ClientSize.Width);
				var redEnd = (float)(((double)this.Capacity / (double)max) * this.ClientSize.Width);

				if (greenEnd >= 1)
				{
					using (var brush = new LinearGradientBrush(new PointF(0, 0), new PointF(greenEnd, 0), Color.FromArgb(0, 192, 0), Color.FromArgb(64, 255, 64)))
					{ pe.Graphics.FillRectangle(brush, 0, 0, greenEnd, this.ClientSize.Height); }
				}
				//TextRenderer.DrawText(pe.Graphics, string.Format("{0:N2} MiB total", this.Value / (double)(1024 * 1024)), font, this.ClientRectangle, Color.Black, TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine | TextFormatFlags.WordEllipsis);

				if (redEnd <= this.ClientSize.Width - 1)
				{
					using (var brush = new LinearGradientBrush(new PointF(redEnd, 0), new PointF(this.ClientSize.Width, 0), Color.FromArgb(192, 0, 0), Color.FromArgb(255, 0, 0)))
					{ pe.Graphics.FillRectangle(brush, redEnd, 0, this.ClientSize.Width - redEnd, this.ClientSize.Height); }
					//TextRenderer.DrawText(pe.Graphics, string.Format("{0:N2} MiB over target on current disc", (this.Value - this.Capacity) / (double)(1024 * 1024)), font, this.ClientRectangle, Color.Black, TextFormatFlags.Right | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine | TextFormatFlags.EndEllipsis);
				}

				var flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPrefix | TextFormatFlags.NoPadding;
				var maxLabelSize = TextRenderer.MeasureText(pe.Graphics, ToString(max), font, this.ClientSize, flags);
				var numLabels = (int)Math.Max(1, this.ClientSize.Width / (maxLabelSize.Width * 2.00F));

				var increment = (long)Math.Pow(2, Math.Round(Math.Log((double)max / numLabels, 2)));
				for (long i = 0; i <= max; i += increment)
				{
					var text = ToString(i);
					var textSize = TextRenderer.MeasureText(pe.Graphics, text, font, this.ClientSize, flags);
					var markerLoc = (float)Math.Min(i * this.ClientSize.Width / max, this.ClientSize.Width - 1);

					var targetRect = new RectangleF(markerLoc - textSize.Width / 2, Math.Max(1, this.ClientSize.Height * 0.5F - textSize.Height), textSize.Width, textSize.Height);
					var intersection = RectangleF.Intersect(targetRect, this.ClientRectangle);
					if (intersection.Width < targetRect.Width)
					{
						if (intersection.Right < targetRect.Right) { targetRect.Offset(intersection.Right - targetRect.Right, 0); }
						else if (intersection.Left > targetRect.Left) { targetRect.Offset(intersection.Left - targetRect.Left, 0); }
					}

					pe.Graphics.DrawLine(Pens.Black, new PointF(markerLoc, 0), new PointF(markerLoc, this.ClientSize.Height * 0.5F - targetRect.Height));
					TextRenderer.DrawText(pe.Graphics, text, font, Rectangle.Round(targetRect), Color.Black, flags);
				}

				if (this.Markers != null)
				{
					int maxMarkerHeight = this.ClientSize.Height;
					foreach (var marker in this.Markers)
					{
						if (marker.Location <= max)
						{ maxMarkerHeight = Math.Min(maxMarkerHeight, Math.Max(1, this.ClientSize.Height - TextRenderer.MeasureText(pe.Graphics, marker.Text, font, this.ClientSize, flags).Height)); }
					}

					foreach (var marker in this.Markers)
					{
						if (marker.Location <= max)
						{
							var textSize = TextRenderer.MeasureText(pe.Graphics, marker.Text, font, this.ClientSize, flags);
							var markerLoc = (float)Math.Min((((double)marker.Location / (double)max) * this.ClientSize.Width), this.ClientSize.Width - 1);

							var targetRect = new RectangleF(markerLoc - textSize.Width / 2, Math.Max(1, (this.ClientSize.Height - textSize.Height) * marker.Height), textSize.Width, textSize.Height);
							var intersection = RectangleF.Intersect(targetRect, this.ClientRectangle);
							if (intersection.Width < targetRect.Width)
							{
								if (intersection.Right < targetRect.Right) { targetRect.Offset(intersection.Right - targetRect.Right, 0); }
								else if (intersection.Left > targetRect.Left) { targetRect.Offset(intersection.Left - targetRect.Left, 0); }
							}

							pe.Graphics.DrawLine(marker.Pen, new PointF(markerLoc, 0), new PointF(markerLoc, maxMarkerHeight * marker.Height));
							TextRenderer.DrawText(pe.Graphics, marker.Text, font, Rectangle.Round(targetRect), marker.Pen.Color, flags);
						}
					}
				}
			}
		}

		[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
		public override string Text { get { return base.Text; } set { base.Text = value; } }

		public struct Marker
		{
			public Marker(long location, string text, float height, Pen pen) { this.Text = text; this.Location = location; this.Height = height; this.Pen = pen; }

			public readonly long Location;
			public readonly string Text;
			public readonly float Height;
			public readonly Pen Pen;
		}
	}
}