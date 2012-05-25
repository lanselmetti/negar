using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Negar.PersianCalendar.UI.PersianPopup;

namespace Negar.PersianCalendar.UI.PersianPopup
{
    [ToolboxItem(false)]
    internal class PersianShadow : PersianPopupContainer
    {
        #region Fields

        [ThreadStatic] private static Brush horzBrush;
        [ThreadStatic] private static Brush vertBrush;
        private readonly Brush brush;
        private Boolean horizontalShadow;
        private Form owner;
        private Rectangle realBounds;

        #endregion

        #region Ctor

        #endregion

        #region Props

        private static Brush VertBrush
        {
            get
            {
                if (vertBrush == null) vertBrush = CreateBrush(false, 4);
                return vertBrush;
            }
        }

        private static Brush HorzBrush
        {
            get
            {
                if (horzBrush == null) horzBrush = CreateBrush(true, 4);
                return horzBrush;
            }
        }

        public override Rectangle RealBounds
        {
            get { return realBounds; }
            set { realBounds = value; }
        }

        public static Int32 DefaultShadowSize
        {
            get { return 5; }
        }

        #endregion

        #region Methods

        public PersianShadow(Boolean horz, Int32 width, Form Owner)
        {
            SetStyle(ControlStyles.ResizeRedraw, false);
            owner = Owner;
            Visible = false;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            var r = new RectangleF(0, 0, (horz ? width : 4), (horz ? 4 : width));
            brush = (horz ? HorzBrush : VertBrush);
            Bounds = new Rectangle(-6000, -6000, 1, 1);
            Opacity = 0.20;
            horizontalShadow = horz;
            HideShadow();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style &= (~0x00800000);

                return cp;
            }
        }

        public static void CreateShadows(ArrayList shadows, Int32 shadowSize, Boolean canShow, Form form,
                                         Rectangle creatorRect)
        {
            CreateShadows(shadows, shadowSize, canShow, form, creatorRect, Rectangle.Empty);
        }

        public static void CreateShadows(ArrayList shadows, Int32 shadowSize, Boolean canShow, Form form,
                                         Rectangle creatorRect1, Rectangle creatorRect2)
        {
            if (!canShow || !form.Visible || form.Bounds.IsEmpty || form.Disposing)
            {
                HideShadows(shadows);
                return;
            }
            var bounds = new Rectangle(form.PointToScreen(Point.Empty), form.ClientSize);
            Rectangle vertRect;
            Rectangle horzRect;
            var topForm = form as PersianTopFormBase;
            if (topForm == null) return;

            if (topForm.OwnerEdit.RightToLeft == RightToLeft.No)
            {
                vertRect = new Rectangle(bounds.Right, bounds.Top + shadowSize, shadowSize, bounds.Height);
                horzRect = new Rectangle(bounds.X + shadowSize, bounds.Bottom, bounds.Width - shadowSize, shadowSize);
            }
            else
            {
                vertRect = new Rectangle(bounds.Left - shadowSize, bounds.Top + shadowSize, shadowSize, bounds.Height);
                horzRect = new Rectangle(bounds.X, bounds.Bottom, bounds.Width - shadowSize, shadowSize);
            }

            if (shadows.Count == 0)
            {
                var vertShadow = new PersianShadow(false, shadowSize, form);
                var horzShadow = new PersianShadow(true, shadowSize, form);
                shadows.Add(vertShadow);
                shadows.Add(horzShadow);
            }

            //vertRect = CheckShadowRectangle(vertRect, creatorRect1, true);
            //vertRect = CheckShadowRectangle(vertRect, creatorRect2, true);
            //horzRect = CheckShadowRectangle(horzRect, creatorRect1, false);
            //horzRect = CheckShadowRectangle(horzRect, creatorRect2, false);
            (shadows[0] as PersianShadow).RealBounds = vertRect;
            (shadows[1] as PersianShadow).RealBounds = horzRect;


            UpdateShadows(shadows, creatorRect1, creatorRect2, shadowSize);
            ShowShadows(shadows);
        }

        private static Rectangle CheckRectangle(Rectangle r)
        {
            if (r.X < 0)
            {
                r.Width += r.X;
                r.X = 0;
            }
            if (r.Y < 0)
            {
                r.Height += r.Y;
                r.Y = 0;
            }
            return r;
        }

        public static void UpdateShadows(ArrayList shadows, Rectangle creatorRect, Int32 shadowSize)
        {
            UpdateShadows(shadows, creatorRect, Rectangle.Empty, shadowSize);
        }

        public static void UpdateShadows(ArrayList shadows, Rectangle creatorRect1, Rectangle creatorRect2,
                                         Int32 shadowSize)
        {
            if (shadows.Count < 1) return;
            foreach (PersianShadow shadow in shadows)
                shadow.Region = null;

            if (creatorRect1.IsEmpty && creatorRect2.IsEmpty) return;

            foreach (PersianShadow shadow in shadows)
            {
                Rectangle i1 = CheckShadowIntersects(shadow.RealBounds, creatorRect1),
                          i2 = CheckShadowIntersects(shadow.RealBounds, creatorRect2);
                if (!i1.IsEmpty || !i2.IsEmpty)
                {
                    var reg = new Region(CheckRectangle(new Rectangle(Point.Empty, shadow.RealBounds.Size)));
                    if (!i1.IsEmpty) reg.Exclude(i1);
                    if (!i2.IsEmpty) reg.Exclude(i2);
                    shadow.Region = reg;
                }
            }
        }

        private static Rectangle CheckShadowIntersects(Rectangle shadow, Rectangle rect)
        {
            if (!rect.IntersectsWith(shadow)) return Rectangle.Empty;
            Rectangle r = rect;
            r.Offset(-shadow.X, -shadow.Y);
            r = CheckRectangle(r);
            if (r.Width > 0 && r.Height > 0) return r;
            return Rectangle.Empty;
        }

        public static void ShowShadows(ArrayList shadows)
        {
            ShowShadows(shadows, true);
        }

        public static void HideShadows(ArrayList shadows)
        {
            ShowShadows(shadows, false);
        }

        public static void ShowShadows(ArrayList shadows, Boolean show)
        {
            foreach (PersianShadow form in shadows)
            {
                if (show)
                    form.ShowShadow();
                else
                    form.HideShadow();
            }
        }

        public static void DestroyShadows(ArrayList shadows)
        {
            if (shadows == null) return;
            foreach (PersianShadow shadow in shadows)
            {
                shadow.Dispose();
            }
            shadows.Clear();
        }

        internal static Boolean NeedHideCursor(Control control)
        {
            if (!control.Visible) return false;
            if (Cursor.Current == null) return false;
            Size size = Cursor.Current.Size;
            Point p = control.PointToClient(Cursor.Position);
            p.Offset(size.Width, size.Height);
            Rectangle r = control.ClientRectangle;
            r.Offset(size.Width, size.Height);
            r.Inflate(size);
            if (r.Contains(p)) return true;
            return false;
        }

        private static Brush CreateBrush(Boolean horz, Int32 width)
        {
            var r = new Rectangle(0, 0, (horz ? width : 4), (horz ? 4 : width));
            Brush br = new LinearGradientBrush(r, Color.Black, Color.Gray,
                                               (!horz ? LinearGradientMode.Horizontal : LinearGradientMode.Vertical));
            return br;
        }

        public void HideShadow()
        {
            realBounds = new Rectangle(-6000, -6000, 0, 0);
            Bounds = realBounds;
            Visible = false;
        }

        public void MoveShadow()
        {
            if (RealBounds == Bounds) return;
            Bounds = RealBounds;
        }

        public void ShowShadow()
        {
            Visible = true;
            Bounds = RealBounds;

            UpdateZOrder(new IntPtr(-1));
            Refresh();
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x83:
                    m.Result = new IntPtr(0);
                    return;
            }
            base.WndProc(ref m);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Boolean needHide = NeedHideCursor(this);
            if (needHide)
                Cursor.Hide();

            Rectangle r = ClientRectangle;

            //if(!this.horizontalShadow) 
            //{
            //    r.Height -= 4;								
            //}

            e.Graphics.FillRectangle(brush, r);

            //if(!this.horizontalShadow) 
            //{
            //e.Graphics.FillRectangle(Brushes.White, new Rectangle(r.X - 3, r.Y, 1, 1));
            //r.Y = r.Bottom;
            //r.Height = 4;
            //e.Graphics.FillRectangle(Brushes.Red, r);// CornerBrush, r);
            //e.Graphics.FillRectangle(Brushes.White, new Rectangle(r.X + 1, r.Y + 1, 3, 3));
            //e.Graphics.FillRectangle(CornerBrush, new Rectangle(r.X + 1, r.Y + 1, 2, 2));
            //e.Graphics.FillRectangle(Brushes.Gray, new Rectangle(r.X, r.Y + 3, 2, 1));
            //e.Graphics.FillRectangle(Brushes.Gray, new Rectangle(r.X + 3, r.Y, 1, 2));
            //}
            //else 
            //{
            //e.Graphics.FillRectangle(Brushes.White, new Rectangle(r.X, r.Y - 3, 1, 1));
            //}

            if (needHide)
                Cursor.Show();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }

        #endregion
    }
}