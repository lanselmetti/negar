using System;
using System.Drawing;

namespace Negar.PersianCalendar.UI.Drawing
{
    /// <summary>
    /// كلاس طراحی پایه برای كلیه طراحی ها ، برای طراح های جدید باید این كلاس به ارث برسد
    /// </summary>
    public class FAPainterBase
    {
        #region Methods

        #region public Rectangle DrawArrow(Graphics g, Rectangle rc, Boolean isLeft, Boolean isDisabled, Int32 arrowSize)
        public Rectangle DrawArrow(Graphics g, Rectangle rc, Boolean isLeft, Boolean isDisabled, Int32 arrowSize)
        {
            Int32 xLeft = rc.Left + 1;
            Int32 xRight = xLeft + arrowSize;
            Int32 yMidd = rc.Top + (rc.Height / 2);
            Int32 yTop = yMidd - arrowSize;
            Int32 yBott = yMidd + arrowSize;

            Point[] PointsArray;

            if (isLeft)
            {
                PointsArray = new[]
                {
                    new Point(new Size(xLeft, yMidd)),
                    new Point(new Size(xRight, yTop)),
                    new Point(new Size(xRight, yBott))
                };
            }
            else
            {
                PointsArray = new[]
                {
                    new Point(new Size(xLeft, yTop)),
                    new Point(new Size(xLeft, yBott)),
                    new Point(new Size(xRight, yMidd))
                };
            }

            g.DrawPolygon((isDisabled ? SystemPens.GrayText : SystemPens.WindowText), PointsArray);
            g.FillPolygon((isDisabled ? SystemBrushes.GrayText : SystemBrushes.WindowText), PointsArray);

            return new Rectangle(xLeft - 2, yTop - 2, arrowSize + 4, arrowSize * 2 + 4);
        }
        #endregion

        #region public Rectangle DrawVerticalArrow(Graphics g, Rectangle rc, Boolean isLeft, Boolean isDisabled, Int32 arrowSize)
        /// <summary>
        /// تابع رسم فلش كمبو باكس تقویم
        /// </summary>
        public Rectangle DrawVerticalArrow(Graphics g, Rectangle rc, Boolean isLeft, Boolean isDisabled, Int32 arrowSize)
        {
            Int32 middle = rc.Height / 2;
            Point[] pntArrow = new Point[3];
            SolidBrush br;

            if (isLeft)
            {
                pntArrow[0] = new Point(rc.Width - 11, middle - 1);
                pntArrow[1] = new Point(rc.Width - 9, middle + 2);
                pntArrow[2] = new Point(rc.Width - 6, middle - 1);
            }
            else
            {
                pntArrow[0] = new Point(rc.Left + 6, middle - 2);
                pntArrow[1] = new Point(rc.Left + 9, middle + 2);
                pntArrow[2] = new Point(rc.Left + 13, middle - 2);
            }

            if (isDisabled) br = new SolidBrush(Color.Gray);
            else br = new SolidBrush(Color.Green);

            g.FillPolygon(br, pntArrow);
            br.Dispose();

            return rc;
        }
        #endregion
        
        #endregion
    }
}