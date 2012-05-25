#region using

using System;
using System.Windows.Forms;
using System.Drawing;
using Components;

#endregion


namespace Sepehr.Settings.DynamicForms
{
    /// <summary>
    /// كلاس پنل با مدیریت جابه جایی كنترل ها و تغییر سایز آنها
    /// </summary>
    public class FormDesigner : Panel
    {
        #region Fields

        #region Boolean isMouseDown
        /// <summary>
        /// 
        /// </summary>
        private Boolean isMouseDown;
        #endregion

        #region Point hitPoint
        /// <summary>
        /// 
        /// </summary>
        private Point hitPoint = new Point(0, 0);
        #endregion

        #region Cursor defaultCursor
        /// <summary>
        /// 
        /// </summary>
        private Cursor defaultCursor = Cursors.Default;
        #endregion

        #region readonly Tracker tracker
        /// <summary>
        /// 
        /// </summary>
        private readonly Tracker tracker;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض
        /// </summary>
        public FormDesigner()
        {
            AutoScroll = true;
            BackColor = Color.White;
            //Responsible for resizing a control in canvas panel 
            tracker = new Tracker();
            tracker.Visible = false;
            Controls.Add(tracker);
        }
        #endregion

        #region Override EventHandlers

        #region override void OnControlAdded
        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            if (e.Control is Tracker) return;

            e.Control.MouseEnter += (Control_MouseEnter);
            e.Control.MouseLeave += (Control_MouseLeave);
            e.Control.MouseDown += (Control_MouseDown);
            e.Control.MouseMove += (Control_MouseMove);
            e.Control.MouseUp += (Control_MouseUp);
            e.Control.VisibleChanged += (Control_VisibleChanged);
            e.Control.SizeChanged += (Control_SizeChanged);
            e.Control.LocationChanged += (Control_LocationChanged);
            e.Control.HandleDestroyed += (Control_HandleDestroyed);
        }
        #endregion

        #region override void OnControlRemoved(ControlEventArgs e)
        protected override void OnControlRemoved(ControlEventArgs e)
        {
            base.OnControlRemoved(e);
            if (e.Control == tracker.Control) tracker.Control = null;
        }
        #endregion

        #endregion

        #region EventHandlers

        #region Control_MouseEnter
        private void Control_MouseEnter(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            defaultCursor = control.Cursor;

            control.Cursor = Cursors.SizeAll;
        }
        #endregion

        #region Control_MouseLeave
        private void Control_MouseLeave(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            control.Cursor = defaultCursor;
        }
        #endregion

        #region Control_MouseDown
        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = true;
                hitPoint = e.Location;

                Control control = (Control)sender;
                //PropertyInfo info = control.GetType().GetProperty("AutoSize");
                //if (info != null && ((bool)info.GetValue(control, null)) == false)
                tracker.Control = control;
            }
        }
        #endregion

        #region Control_MouseMove
        private void Control_MouseMove(object sender, MouseEventArgs e)
        {
            Control control = (Control)sender;

            if (isMouseDown)
            {
                if (tracker.Control == control)
                    tracker.Visible = false;
                control.Left += e.Location.X - hitPoint.X;
                control.Top += e.Location.Y - hitPoint.Y;
            }
        }
        #endregion

        #region Control_MouseUp
        private void Control_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;

            Control control = (Control)sender;
            if (tracker.Control == control)
            {
                tracker.Visible = true;

                if (control.Top < 0)
                    control.Top = 0;
                if (control.Left < 0)
                    control.Left = 0;
            }
        }
        #endregion

        #region Control_VisibleChanged
        private void Control_VisibleChanged(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            if (tracker.Control == control)
                tracker.Visible = control.Visible;
        }

        #endregion

        #region Control_SizeChanged
        private void Control_SizeChanged(object sender, EventArgs e)
        {
            if (tracker != null)
                tracker.SetBounds();
        }
        #endregion

        #region Control_LocationChanged
        private void Control_LocationChanged(object sender, EventArgs e)
        {
            if (tracker != null)
                tracker.SetBounds();
        }
        #endregion

        #region Control_HandleDestroyed
        private void Control_HandleDestroyed(object sender, EventArgs e)
        {
            tracker.Control = null;
        }
        #endregion

        #endregion
    }
}
