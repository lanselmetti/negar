using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Negar.PersianCalendar.UI.Drawing
{
    /// <summary>
    /// Painter class used to paint drawing objects in Office 2007 theme.
    /// </summary>
    public class FAPainterOffice2007 : FAPainterBase, IFAPainter
    {
        #region IFAPainter Members

        public void DrawButtonFocusRect(Graphics g, Rectangle r, ItemState state)
        {
            Rectangle focus = new Rectangle(r.X, r.Y, r.Width, r.Height);
            focus.Inflate(-2, -2);
            ControlPaint.DrawFocusRectangle(g, focus);
        }

        public void DrawSelectionBorder(Graphics g, Rectangle r)
        {
            using (var p = new Pen(Office2007Colors.Default[Office2007Color.TabPageBackColor1]))
                g.DrawRectangle(p, r);
        }

        public void DrawVerticalSeparator(Graphics g, Point from, Point to)
        {
            var pen1 = new Pen(Office2007Colors.Default[Office2007Color.Border]);
            g.DrawLine(pen1, from, to);
        }

        public void DrawFilledBackground(Graphics g, Rectangle rectangle, Boolean isGradient, float angle)
        {
            if (isGradient)
            {
                // Create DrawTab linear gradient brush that covers the area of the parent form
                using (
                    var brush = new LinearGradientBrush(rectangle, Office2007Colors.Default[Office2007Color.Button1],
                                                        Office2007Colors.Default[Office2007Color.Button2], angle))
                {
                    // Blend from the dark to the light over the first 58% of distance and then
                    // the rest should be all in the light colour, this matches Office2007
                    Blend blending = new Blend();
                    blending.Factors = new[] { 0f, 1f, 1f };
                    blending.Positions = new[] { 0f, 0.58f, 1f };
                    brush.Blend = blending;

                    // Finally we draw using the brush
                    g.FillRectangle(brush, rectangle);
                }
            }
            else
            {
                using (Brush brush = new SolidBrush(Color.White))
                {
                    g.FillRectangle(brush, rectangle);
                }
            }
        }

        public void DrawWhiteBackground(Graphics g, Rectangle r, Boolean isGradient, float angle)
        {
            using (Brush brush = new SolidBrush(SystemColors.ControlLightLight))
            {
                g.FillRectangle(brush, r);
            }
        }

        public void DrawBorder(Graphics g, Rectangle rectangle, Boolean enabled)
        {
            if (rectangle.Width > 0 && rectangle.Height > 0)
            {
                Color TheColor;
                if (enabled) TheColor = Office2007Colors.Default[Office2007Color.Border];
                else TheColor = Office2007Colors.Default[Office2007Color.TextDisabled];
                using (Pen p = new Pen(TheColor))
                {
                    g.DrawRectangle(p, rectangle);
                }
            }
        }

        public void DrawButton(Graphics g, Rectangle rectangle, String text, Font font, StringFormat fmt,
                               ItemState state, Boolean hasBorder, Boolean enabled)
        {
            const Single angle = 90;

            if (rectangle.Width > 0 && rectangle.Height > 0)
            {
                if (!enabled)
                {
                    using (Brush backBrush = new LinearGradientBrush(rectangle,
                        Office2007Colors.Default[Office2007Color.Button1], Office2007Colors.Default[Office2007Color.Button2], angle))
                        g.FillRectangle(backBrush, rectangle);
                }
                else
                {
                    switch (state)
                    {
                        case ItemState.Normal:
                            using (Brush backBrush = new LinearGradientBrush(rectangle,
                                Office2007Colors.Default[Office2007Color.Button1], Office2007Colors.Default[Office2007Color.Button2], angle))
                                g.FillRectangle(backBrush, rectangle);
                            break;
                        case ItemState.HotTrack:
                            using (Brush trackBrush = new LinearGradientBrush(rectangle,
                                Office2007Colors.Default[Office2007Color.Button1Hot], Office2007Colors.Default[Office2007Color.Button2Hot],
                                angle)) g.FillRectangle(trackBrush, rectangle);
                            break;
                        case ItemState.Open:
                        case ItemState.Pressed:
                            using (Brush trackBrush = new LinearGradientBrush(rectangle,
                                Office2007Colors.Default[Office2007Color.Button1Pressed],
                                Office2007Colors.Default[Office2007Color.Button2Pressed], angle))
                                g.FillRectangle(trackBrush, rectangle);
                            break;
                        default:
                            break;
                    }
                }

                if (!String.IsNullOrEmpty(text))
                {
                    if (enabled)
                    {
                        using (var br = new SolidBrush(Office2007Colors.Default[Office2007Color.Text]))
                            g.DrawString(text, font, br, rectangle, fmt);
                    }
                    else
                    {
                        using (var br = new SolidBrush(Office2007Colors.Default[Office2007Color.TextDisabled]))
                            g.DrawString(text, font, br, rectangle, fmt);
                    }
                }

                if (hasBorder)
                    DrawBorder(g, new Rectangle(rectangle.X, rectangle.Y, rectangle.Width - 1, rectangle.Height - 1),
                               enabled);
            }
        }

        public void DrawFocusRect(Graphics g, Rectangle r)
        {
            ControlPaint.DrawFocusRectangle(g, r);
        }

        public void DrawSeparator(Graphics g, Point ptFrom, Point ptTo)
        {
            // Find point halfway across for separator lines
            var p = new Pen(Office2007Colors.Default[Office2007Color.TabPageBorderColor]);

            // Draw two lines to give 3D effect and indent by 2 pixels
            g.DrawLine(p, ptFrom, ptTo);

            p.Dispose();
        }

        public void DrawSelectedPanel(Graphics g, Rectangle r)
        {
            using (var brush = new SolidBrush(Office2007Colors.Default[Office2007Color.TabPageBackColor1]))
            {
                g.FillRectangle(brush, r);
            }
        }

        #endregion
    }
}