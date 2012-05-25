using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Reflection;

namespace Components
{
    /// <summary>
    /// Responsible for resizing a control in canvas panel 
    /// </summary>
    internal class Tracker : UserControl
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public Tracker()
        {
            InitializeComponent();

            trackers[0].Width = TRACKER_LENGTH;
            trackers[0].Height = TRACKER_LENGTH;
            trackers[1].Width = TRACKER_LENGTH;
            trackers[1].Height = TRACKER_LENGTH;
            trackers[2].Width = TRACKER_LENGTH;
            trackers[2].Height = TRACKER_LENGTH;
            trackers[3].Width = TRACKER_LENGTH;
            trackers[3].Height = TRACKER_LENGTH;
            trackers[4].Width = TRACKER_LENGTH;
            trackers[4].Height = TRACKER_LENGTH;
            trackers[5].Width = TRACKER_LENGTH;
            trackers[5].Height = TRACKER_LENGTH;
            trackers[6].Width = TRACKER_LENGTH;
            trackers[6].Height = TRACKER_LENGTH;
            trackers[7].Width = TRACKER_LENGTH;
            trackers[7].Height = TRACKER_LENGTH;
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Name = "Tracker";
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// Responsible for updating the location of small rectangles around the control.
        /// </summary>
        protected override void OnLayout(LayoutEventArgs e)
        {
            base.OnLayout(e);

            // Oreders: TopLeft, TopMiddle, TopRight, RightMiddle, BottomRight,
            // BottomMiddle, BottomLeft, LeftMiddle

            //TopLeft
            trackers[0].X = 0;
            trackers[0].Y = 0;

            //TopMiddle
            trackers[1].X = (Width - TRACKER_LENGTH) / 2;
            trackers[1].Y = 0;

            //TopRight
            trackers[2].X = Width - TRACKER_LENGTH - 1;
            trackers[2].Y = 0;

            //RightMiddle
            trackers[3].X = Width - TRACKER_LENGTH - 1;
            trackers[3].Y = (Height - TRACKER_LENGTH) / 2;

            //BottomRight
            trackers[4].X = Width - TRACKER_LENGTH - 1;
            trackers[4].Y = Height - TRACKER_LENGTH - 1;

            //BottomMiddle
            trackers[5].X = (Width - TRACKER_LENGTH) / 2;
            trackers[5].Y = Height - TRACKER_LENGTH - 1;

            //BottomLeft
            trackers[6].X = 0;
            trackers[6].Y = Height - TRACKER_LENGTH - 1;

            //LeftMiddle
            trackers[7].X = 0;
            trackers[7].Y = (Height - TRACKER_LENGTH) / 2;

            //Fire the Paint event
            Invalidate();
        }

        /// <summary>
        /// Responsible for drawing small rectangles around a control.
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.Clear(BackColor);
            e.Graphics.FillRectangles(Brushes.White, trackers);
            e.Graphics.DrawRectangles(Pens.Black, trackers);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            isMouseDown = true;
            trackerIndex = GetTrackerIndex(e.Location);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (trackerIndex == -1)
                SetCursor(e.Location);
            else
            {
                //PropertyInfo info = control.GetType().GetProperty("AutoSize");
                //if (info != null && ((bool)info.GetValue(control, null)) == true)
                //    return;

                if (Control != null && isMouseDown)
                {
                    Rectangle bounds = Control.Bounds;

                    switch (trackerIndex)
                    {
                        case 0:
                            bounds.X += e.X;
                            if (bounds.X > TRACKER_LENGTH + 1)
                                bounds.Width -= e.X;
                            else
                                bounds.X = TRACKER_LENGTH + 1;
                            bounds.Y += e.Y;
                            if (bounds.Y > TRACKER_LENGTH + 1)
                                bounds.Height -= e.Y;
                            else
                                bounds.Y = TRACKER_LENGTH + 1;
                            break;
                        case 1:
                            bounds.Y += e.Y;
                            if (bounds.Y > TRACKER_LENGTH + 1)
                                bounds.Height -= e.Y;
                            else
                                bounds.Y = TRACKER_LENGTH + 1;
                            break;
                        case 2:
                            bounds.Width = e.X;
                            bounds.Y += e.Y;
                            if (bounds.Y > TRACKER_LENGTH + 1)
                                bounds.Height -= e.Y;
                            else
                                bounds.Y = TRACKER_LENGTH + 1;
                            break;
                        case 3:
                            bounds.Width = e.X;
                            break;
                        case 4:
                            bounds.Width = e.X;
                            bounds.Height = e.Y;
                            break;
                        case 5:
                            bounds.Height = e.Y;
                            break;
                        case 6:
                            bounds.X += e.X;
                            if (bounds.X > TRACKER_LENGTH + 1)
                                bounds.Width -= e.X;
                            else
                                bounds.X = TRACKER_LENGTH + 1;
                            bounds.Height = e.Y;
                            break;
                        case 7:
                            bounds.X += e.X;
                            if (bounds.X > TRACKER_LENGTH + 1)
                                bounds.Width -= e.X;
                            else
                                bounds.X = TRACKER_LENGTH + 1;
                            break;
                    }

                    Control.Bounds = bounds;
                }
            }
        }

        /// <summary>
        /// Responsible for changing the cursor in order to small rectangles
        /// </summary>
        /// <param name="point">Mouse location</param>
        private void SetCursor(Point point)
        {
            if (trackers[0].Contains(point))
                Cursor = Cursors.SizeNWSE;
            else if (trackers[1].Contains(point))
                Cursor = Cursors.SizeNS;
            else if (trackers[2].Contains(point))
                Cursor = Cursors.SizeNESW;
            else if (trackers[3].Contains(point))
                Cursor = Cursors.SizeWE;
            else if (trackers[4].Contains(point))
                Cursor = Cursors.SizeNWSE;
            else if (trackers[5].Contains(point))
                Cursor = Cursors.SizeNS;
            else if (trackers[6].Contains(point))
                Cursor = Cursors.SizeNESW;
            else if (trackers[7].Contains(point))
                Cursor = Cursors.SizeWE;
            else Cursor = Cursors.Default;
        }

        /// <summary>
        /// Responsible for realizing the rectangle which has been clicked.
        /// </summary>
        /// <param name="point">Mouse location</param>
        /// <returns>Index of a rectangle</returns>
        private int GetTrackerIndex(Point point)
        {
            if (trackers[0].Contains(point))
                return 0;
            else if (trackers[1].Contains(point))
                return 1;
            else if (trackers[2].Contains(point))
                return 2;
            else if (trackers[3].Contains(point))
                return 3;
            else if (trackers[4].Contains(point))
                return 4;
            else if (trackers[5].Contains(point))
                return 5;
            else if (trackers[6].Contains(point))
                return 6;
            else if (trackers[7].Contains(point))
                return 7;
            return -1;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            //Invalidate();

            isMouseDown = false;
            trackerIndex = -1;
        }

        /// <summary>
        /// Set the size and the location of this around a control
        /// </summary>
        public void SetBounds()
        {
            if (Control != null)
            {
                Top = Control.Top - TRACKER_LENGTH - 1;
                Left = Control.Left - TRACKER_LENGTH - 1;
                Width = Control.Width + (TRACKER_LENGTH * 2) + 2;
                Height = Control.Height + (TRACKER_LENGTH * 2) + 2;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        public Control Control
        {
            get { return control; }
            set
            {
                if (value == null)
                {
                    this.control = null;
                    Visible = false;
                }
                else
                {
                    SuspendLayout();
                    Visible = false;
                    BringToFront();

                    this.control = value;
                    SetBounds();
                    this.control.BringToFront();

                    Visible = true;
                    ResumeLayout(true);
                    Invalidate();
                }
            }
        }

        private bool isMouseDown;
        private Control control;
        private int trackerIndex = -1;
        private IContainer components = null;
        private const int TRACKER_LENGTH = 6;
        private readonly Rectangle[] trackers = new Rectangle[8];
    }
}
