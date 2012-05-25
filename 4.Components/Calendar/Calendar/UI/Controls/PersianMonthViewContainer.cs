#region using

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Negar.PersianCalendar.UI.Helpers;
using Negar.PersianCalendar.UI.PersianPopup;

#endregion

namespace Negar.PersianCalendar.UI.Controls
{
    /// <summary>
    /// PersianMonthViewContainer is a control which hosts a 
    /// <see cref="PersianMonthView"/> control, and displays in 
    /// <see cref="PersianDatePicker"/> control when user wants to select a date.
    /// </summary>
    [ToolboxItem(false)]
    public class PersianMonthViewContainer : PersianPopupContainer, IPopupControl
    {

        #region Fields
        private static readonly IPopupServiceControl popupServiceControl = new PersianHookPopupController();
        private PersianMonthView _PersianMonthView;
        private readonly PersianHookPopup hook;
        private Control owner;
        private IPopupServiceControl serviceObject;
        #endregion

        #region Properties

        #region Control OwnerControl

        /// <summary>
        /// Owner control of this Popup control.
        /// </summary>
        [Browsable(false)]
        public Control OwnerControl
        {
            get { return owner; }
            set { owner = value; }
        }

        #endregion

        #region IPopupServiceControl ServiceObject

        /// <summary>
        /// Service object which handles popup behaviors.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IPopupServiceControl ServiceObject
        {
            get { return serviceObject; }
            set
            {
                if (value == null) return;
                serviceObject = value;
            }
        }

        #endregion

        #region PersianMonthView MonthViewControl
        /// <summary>
        /// Actual control that is being displayed.
        /// </summary>
        [Browsable(false)]
        public PersianMonthView MonthViewControl
        {
            get { return _PersianMonthView; }
            set { _PersianMonthView = value; }
        }
        #endregion

        #region override Control OwnerEdit

        /// <summary>
        /// Editor which shows the popup control.
        /// </summary>
        public override Control OwnerEdit
        {
            get { return owner; }
        }

        #endregion

        #region internal PersianHookPopup PopupHook

        internal PersianHookPopup PopupHook
        {
            get { return hook; }
        }

        #endregion

        #endregion

        #region Ctor

        #region public PersianMonthViewContainer() : this(null)

        /// <summary>
        /// Creates a new instance of PersianMonthViewContainer class.
        /// </summary>
        public PersianMonthViewContainer()
            : this(null)
        {
        }

        #endregion

        #region public PersianMonthViewContainer(Control ownerControl)

        /// <summary>
        /// Creates a new instance of PersianMonthViewContainer which 
        /// hosts a <see cref="PersianMonthView"/> control in popup mode.
        /// </summary>
        /// <param name="ownerControl"></param>
        public PersianMonthViewContainer(Control ownerControl)
        {
            hook = new PersianHookPopup(this);
            _PersianMonthView = new PersianMonthView(true);
            _PersianMonthView.Dock = DockStyle.Fill;
            Size = new Size(_PersianMonthView.Size.Width - 2, _PersianMonthView.Size.Height - 2);
            Controls.Add(_PersianMonthView);
            _PersianMonthView.IsPopupMode = true;
            serviceObject = popupServiceControl;
            // ReSharper disable DoNotCallOverridableMethodsInConstructor
            RealBounds =
                new Rectangle(_PersianMonthView.Bounds.X, _PersianMonthView.Bounds.Y,
                              _PersianMonthView.Bounds.Width, _PersianMonthView.Bounds.Height);
            Parent = owner;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            ControlBox = false;
            owner = ownerControl;
            SetStyle(ControlStyles.Opaque, true);
            ShadowSize = 3;
            RightToLeft = ownerControl.RightToLeft;
            // ReSharper restore DoNotCallOverridableMethodsInConstructor
        }

        #endregion

        #region protected override void Dispose(Boolean disposing)

        /// <summary>
        /// Disposes the control.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(Boolean disposing)
        {
            hook.Dispose();
            base.Dispose(disposing);
        }

        #endregion

        #endregion

        #region Methods

        protected override void OnRightToLeftChanged(EventArgs e)
        {
            base.OnRightToLeftChanged(e);
            UpdateShadows();
        }

        private void ShowCalendar()
        {
            Rectangle r = OwnerEdit.RectangleToScreen(OwnerEdit.ClientRectangle);
            Point topLocation;

            if (OwnerEdit.RightToLeft == RightToLeft.Yes)
            {
                topLocation = new Point(r.Left, r.Bottom);
            }
            else
            {
                topLocation = new Point(r.Right - Width, r.Bottom);
            }

            Point bottomLocation = new Point(topLocation.X, topLocation.Y);
            Point showLocation = ControlUtils.CalcLocation(bottomLocation, topLocation, Size);

            ClientSize = Size;
            Location = showLocation;

            CalendarChanged(true);
            Visible = true;
        }

        public void ShowCalendar(Point position)
        {
            Point topLocation = position;
            Point bottomLocation = new Point(topLocation.X, topLocation.Y);
            Point newLoc = ControlUtils.CalcLocation(bottomLocation, topLocation, Size);

            ClientSize = Size;
            Location = newLoc;

            CalendarChanged(true);
            Visible = true;
        }

        private void HideCalendar()
        {
            Visible = false;
            Form form = OwnerEdit.FindForm();
            if (form != null && ActiveForm == form)
                form.Activate();
        }

        protected virtual void CalendarChanged(Boolean makeVisible)
        {
            if (!Visible && !makeVisible) return;

            Invalidate();
            if (makeVisible) Visible = true;
        }

        #endregion

        #region IPopupControl Members

        /// <summary>
        /// Closes the Popup window.
        /// </summary>
        public void ClosePopup()
        {
            HideCalendar();
        }

        /// <summary>
        /// Shows the Popup window.
        /// </summary>
        public void ShowPopup()
        {
            ShowCalendar();
        }

        /// <summary>
        /// Popup control that will be shown.
        /// </summary>
        public Control PopupWindow
        {
            get { return _PersianMonthView; }
        }

        /// <summary>
        /// Is mouse clicks on the control allowed?
        /// </summary>
        /// <param name="control"></param>
        /// <param name="mousePosition"></param>
        /// <returns></returns>
        public Boolean AllowMouseClick(Control control, Point mousePosition)
        {
            return false;
        }

        #endregion
    }
}