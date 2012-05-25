using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using Negar.PersianCalendar.UI.PersianPopup;

namespace Negar.PersianCalendar.UI.PersianPopup
{
    internal class PersianShadowManager : IDisposable
    {
        #region Fields

        private const Int32 bottomShadow = 1;

        private const Int32 rightShadow = 0;
        private Rectangle creator;
        private Form form;

        private Hashtable shadows;
        private Int32 shadowSize = PersianShadow.DefaultShadowSize;
        private Boolean visible;

        #endregion

        #region Ctor & Dispose

        public PersianShadowManager(Form form)
        {
            creator = Rectangle.Empty;
            this.form = form;
            this.form.VisibleChanged += OnForm_VisibleChanged;
            this.form.Move += OnForm_Move;
        }

        public virtual void Dispose()
        {
            if (Form != null)
            {
                Hide();
                Form.Move -= OnForm_Move;
                Form.VisibleChanged -= OnForm_VisibleChanged;
                DestroyShadows();
                form = null;
            }
        }

        #endregion

        #region Props

        public Int32 ShadowSize
        {
            get { return shadowSize; }
            set { shadowSize = value; }
        }

        protected Hashtable Shadows
        {
            get
            {
                if (shadows == null)
                    shadows = new Hashtable();

                return shadows;
            }
        }

        public Form Form
        {
            get { return form; }
        }

        protected Rectangle CreatorBounds
        {
            get { return creator; }
            set { creator = value; }
        }

        public Boolean Visible
        {
            get { return visible; }
        }

        protected virtual Boolean CanShowShadow
        {
            get { return Form != null && Form.Visible && !Form.Bounds.IsEmpty && !Form.Disposing; }
        }

        #endregion

        #region Methods

        public void Move()
        {
            Move(CreatorBounds);
        }

        public virtual void Update()
        {
            Move();
        }

        public void Show()
        {
            Show(Rectangle.Empty);
        }

        public virtual void Show(Rectangle creatorBounds)
        {
            if (Visible || !CanShowShadow) return;
            visible = true;
            UpdateShadowBounds();
            UpdateShadowRegions();
            foreach (DictionaryEntry entry in Shadows)
            {
                ShowShadow(entry.Value as PersianShadow);
            }
        }

        protected virtual void ShowShadow(PersianShadow shadow)
        {
            if (Form != null)
                Form.AddOwnedForm(shadow);

            shadow.ShowShadow();
        }

        public virtual void Move(Rectangle creatorBounds)
        {
            creator = creatorBounds;
            if (!Visible) return;
            UpdateShadowBounds();
            UpdateShadowRegions();
            foreach (DictionaryEntry entry in Shadows)
            {
                (entry.Value as PersianShadow).MoveShadow();
            }
        }

        protected virtual void UpdateShadowBounds()
        {
            Rectangle bounds = Form.Bounds;

            var vertRect = new Rectangle(bounds.Left - ShadowSize, bounds.Top + ShadowSize, ShadowSize, bounds.Height);
            var horzRect = new Rectangle(bounds.X, bounds.Bottom - ShadowSize, bounds.Width - ShadowSize, ShadowSize);

            CreateShadow(rightShadow).RealBounds = vertRect;
            CreateShadow(bottomShadow).RealBounds = horzRect;

            //Rectangle or = CreatorBounds;
            //if (or.IsEmpty)
            //{
            //    DestroyShadow(creatorBottomShadow);
            //    DestroyShadow(creatorRightShadow);
            //}
            //else
            //{
            //CreateShadow(creatorRightShadow).RealBounds = new Rectangle(or.Right, or.Top + ShadowSize, ShadowSize, or.Height);
            //CreateShadow(creatorBottomShadow).RealBounds = new Rectangle(or.X + ShadowSize, or.Bottom, or.Width - ShadowSize, ShadowSize);
            //}
        }

        public virtual void Hide()
        {
            if (!Visible) return;
            foreach (DictionaryEntry entry in Shadows)
            {
                (entry.Value as PersianShadow).HideShadow();
            }

            visible = false;
        }

        protected virtual void UpdateShadowRegions()
        {
            if (!Visible || shadows == null) return;
            foreach (DictionaryEntry entry in shadows)
            {
                var shadow = entry.Value as PersianShadow;
                shadow.Region = GetShadowRegion(shadow.RealBounds);
            }
        }

        private Region GetShadowRegion(Rectangle shadow)
        {
            if (Form == null) return null;
            Rectangle i1 = CheckShadowIntersects(shadow, Form.Bounds),
                      i2 = CheckShadowIntersects(shadow, CreatorBounds);
            if (!i1.IsEmpty || !i2.IsEmpty)
            {
                var reg = new Region(new Rectangle(Point.Empty, shadow.Size));
                if (!i1.IsEmpty) reg.Exclude(i1);
                if (!i2.IsEmpty) reg.Exclude(i2);
                return reg;
            }
            return null;
        }

        private Rectangle CheckShadowIntersects(Rectangle shadow, Rectangle rect)
        {
            if (rect.IsEmpty || shadow.IsEmpty || !rect.IntersectsWith(shadow)) return Rectangle.Empty;
            Rectangle r = rect;
            r.Offset(-shadow.X, -shadow.Y);
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
            if (r.Width > 0 && r.Height > 0) return r;
            return Rectangle.Empty;
        }

        protected virtual PersianShadow CreateShadow(Int32 shadow)
        {
            PersianShadow res = GetShadow(shadow);
            if (res == null) Shadows[shadow] = res = new PersianShadow(shadow%2 != 0, 0, Form);
            return res;
        }

        protected PersianShadow GetShadow(Int32 shadow)
        {
            if (shadows == null)
                return null;

            return Shadows[shadow] as PersianShadow;
        }

        private void OnForm_VisibleChanged(object sender, EventArgs e)
        {
            if (!Form.Visible)
                Hide();
        }

        private void OnForm_Move(object sender, EventArgs e)
        {
            if (Visible)
                Move(CreatorBounds);
        }

        protected virtual void DestroyShadows()
        {
            if (shadows == null) return;
            foreach (DictionaryEntry entry in shadows)
            {
                (entry.Value as PersianShadow).Dispose();
            }
            shadows.Clear();
        }

        protected void DestroyShadow(Int32 shadow)
        {
            PersianShadow sh = GetShadow(shadow);
            if (sh != null)
            {
                sh.Dispose();
                Shadows.Remove(sh);
            }
        }

        #endregion
    }
}