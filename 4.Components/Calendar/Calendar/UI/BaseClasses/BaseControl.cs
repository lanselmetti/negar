#region using
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Threading;
using System.Windows.Forms;
using Negar.PersianCalendar.Resource;
using Negar.PersianCalendar.UI.Drawing;
#endregion

namespace Negar.PersianCalendar.UI.BaseClasses
{
    /// <summary>
    /// Base Control for all UI controls which adds base functionality, events and properties to inheriting controls.
    /// </summary>
    [ToolboxItem(false)]
    public abstract class BaseControl : BaseStyledControl, INotifyPropertyChanged
    {

        #region Fields
        private readonly ErrorProvider _Error;
        private Boolean _AllowWrap = true;
        private Font _Font;
        private Boolean _IsDefault;
        private Boolean _IsFocused;
        private Boolean _IsHot;
        private Boolean _IsPressed;
        private Boolean _IsReadOnly;
        private TextAlignment _TextHorizontalAlignment;
        private TextAlignment _TextVerticalAlignment;
        #endregion

        #region Properties

        #region public Boolean WordWrap
        /// <summary>
        /// Specifies to use WordWrapping displaying the Text of the control.
        /// </summary>
        [DefaultValue(true)]
        [Browsable(false)]
        public Boolean WordWrap
        {
            get { return _AllowWrap; }
            set
            {
                if (_AllowWrap == value) return;
                _AllowWrap = value;
                OnPropertyChanged("WordWrap");
                Repaint();
            }
        }
        #endregion

        #region public TextAlignment TextHorizontalAlignment
        /// <summary>
        /// Specifies Horizontal Alignment of the Text of the control.
        /// </summary>
        [DefaultValue(typeof (TextAlignment), "Default")]
        [Browsable(false)]
        public TextAlignment TextHorizontalAlignment
        {
            get { return _TextHorizontalAlignment; }
            set
            {
                if (_TextHorizontalAlignment == value)
                    return;

                _TextHorizontalAlignment = value;
                OnPropertyChanged("TextHorizontalAlignment");
                Repaint();
            }
        }
        #endregion

        #region public TextAlignment TextVerticalAlignment
        /// <summary>
        /// Specifies Vertical Alignment of the Text of the control.
        /// </summary>
        [DefaultValue(typeof (TextAlignment), "Default")]
        [Browsable(false)]
        public TextAlignment TextVerticalAlignment
        {
            get { return _TextVerticalAlignment; }
            set
            {
                if (_TextVerticalAlignment == value)
                    return;

                _TextVerticalAlignment = value;
                OnPropertyChanged("TextVerticalAlignment");
                Repaint();
            }
        }
        #endregion

        #region public virtual Boolean IsDefault
        /// <summary>
        /// Specifies if the contorl is the default control.
        /// </summary>
        [Browsable(false)]
        [DefaultValue(false)]
        public virtual Boolean IsDefault
        {
            get { return _IsDefault; }
            set
            {
                if (IsDefault == value)
                    return;

                _IsDefault = value;
                OnPropertyChanged("IsDefault");
            }
        }
        #endregion

        #region public virtual Boolean IsPressed
        /// <summary>
        /// Specifies if the control is in Pressed state.
        /// </summary>
        [Browsable(false)]
        [DefaultValue(false)]
        public virtual Boolean IsPressed
        {
            get { return _IsPressed; }
            set
            {
                if (IsPressed == value)
                    return;

                _IsPressed = value;
                OnPropertyChanged("IsPressed");
            }
        }
        #endregion

        #region public virtual Boolean IsFocused
        /// <summary>
        /// Specifies if the control is in Focused state.
        /// </summary>
        [DefaultValue(false)]
        [Browsable(false)]
        public virtual Boolean IsFocused
        {
            get { return _IsFocused; }
            set
            {
                if (_IsFocused == value)
                    return;

                _IsFocused = value;
                OnPropertyChanged("IsFocused");
            }
        }
        #endregion

        #region public virtual Boolean IsReadonly
        /// <summary>
        /// Specifies if the control is in IsReadonly state.
        /// </summary>
        [DefaultValue(false)]
        public virtual Boolean IsReadonly
        {
            get { return _IsReadOnly; }
            set
            {
                if (_IsReadOnly == value)
                    return;

                _IsReadOnly = value;
                OnPropertyChanged("IsReadonly");
                Repaint();
            }
        }
        #endregion

        #region public virtual Boolean Enabled
        /// <summary>
        /// تعیین حالت غیر فعال كنترل
        /// </summary>
        [DefaultValue(true)]
        public new virtual Boolean Enabled
        {
            get { return base.Enabled; }
            set
            {
                if (base.Enabled == value) return;
                base.Enabled = value;
                OnPropertyChanged("Enabled");
                Repaint();
            }
        }
        #endregion

        #region public virtual Boolean IsHot
        /// <summary>
        /// Specifies if the control is in Hot state and mouse is over the control.
        /// </summary>
        [DefaultValue(false)]
        [Browsable(false)]
        public virtual Boolean IsHot
        {
            get { return _IsHot; }
            set
            {
                if (_IsHot == value)
                    return;

                _IsHot = value;
                OnPropertyChanged("IsHot");
            }
        }
        #endregion

        #region public ErrorProvider Error
        /// <summary>
        /// Internal error provider of the control which displays the errors.
        /// </summary>
        [Browsable(false)]
        public ErrorProvider Error
        {
            get { return _Error; }
        }
        #endregion

        #region public Boolean HasErrors
        /// <summary>
        /// Checks if the control currently has any errors.
        /// </summary>
        [Browsable(false)]
        [DefaultValue(false)]
        public Boolean HasErrors
        {
            get { return !String.IsNullOrEmpty(Error.GetError(this)); }
            set
            {
                if (!value) Error.SetError(this, String.Empty);
                else
                    Error.SetError(this, PersianLocalizeManager.GetLocalizerByCulture(
                        Thread.CurrentThread.CurrentUICulture).GetLocalizedString(
                        StringIDEnum.Validation_NotValid));
            }
        }
        #endregion

        #region public new virtual Font Font
        /// <summary>
        /// Font of the control.
        /// </summary>
        public new virtual Font Font
        {
            get { return _Font; }
            set
            {
                if (_Font == value) return;
                _Font = value;
                OnPropertyChanged("Font");
                Repaint();
            }
        }

        #endregion

        #region protected virtual StringFormat TextFormat
        protected virtual StringFormat TextFormat
        {
            get
            {
                var TheStringFormat = (StringFormat) StringFormat.GenericDefault.Clone();

                switch (TextHorizontalAlignment)
                {
                    case TextAlignment.Default:
                    case TextAlignment.Center:
                        TheStringFormat.Alignment = StringAlignment.Center;
                        break;
                    case TextAlignment.Near:
                        TheStringFormat.Alignment = StringAlignment.Near;
                        break;
                    case TextAlignment.Far:
                        TheStringFormat.Alignment = StringAlignment.Far;
                        break;
                }
                // =============================================
                switch (TextVerticalAlignment)
                {
                    case TextAlignment.Default:
                    case TextAlignment.Center:
                        TheStringFormat.LineAlignment = StringAlignment.Center;
                        break;
                    case TextAlignment.Near:
                        TheStringFormat.LineAlignment = StringAlignment.Near;
                        break;
                    case TextAlignment.Far:
                        TheStringFormat.LineAlignment = StringAlignment.Far;
                        break;
                }
                // =============================================
                TheStringFormat.HotkeyPrefix = HotkeyPrefix.Show;
                TheStringFormat.Trimming = StringTrimming.Word;
                // =============================================
                if (RightToLeft == RightToLeft.Yes)
                    TheStringFormat.FormatFlags |= StringFormatFlags.DirectionRightToLeft;
                // =============================================
                if (!WordWrap)
                {
                    TheStringFormat.FormatFlags |= StringFormatFlags.NoWrap;
                    TheStringFormat.Trimming = StringTrimming.EllipsisCharacter;
                }
                return TheStringFormat;
            }
        }

        #endregion

        #endregion

        #region INotifyPropertyChanged Implementation

        /// <summary>
        /// Fires when every Property of the control changes.
        /// </summary>
        public virtual event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Events

        /// <summary>
        /// Fires when control is validating the entered value.
        /// </summary>
        public event ValueValidatingEventHandler ValueValidating;

        /// <summary>
        /// Fires when value of the control is changing.
        /// </summary>
        public event EventHandler ValueChanged;

        /// <summary>
        /// Fires when layout of the control is changed.
        /// </summary>
        public event EventHandler LayoutChanged;

        /// <summary>
        /// Fires when layout of the control is changing.
        /// </summary>
        public event EventHandler LayoutChanging;

        /// <summary>
        /// Fires when user scrolls to next item of the control using MouseWheel.
        /// </summary>
        public event EventHandler NextScrollItems;

        /// <summary>
        /// Fires when user scrolls to previous item of the control using MouseWheel.
        /// </summary>
        public event EventHandler PreviousScrollItems;

        /// <summary>
        /// Fires when readonly state of the control changes.
        /// </summary>
        public event EventHandler ReadOnlyChanged;

        /// <summary>
        /// Fires when Enabled state of the control changes.
        /// </summary>
        public new event EventHandler EnabledChanged;
        #endregion

        #region Ctors

        #region protected BaseControl()
        /// <summary>
        /// Creates a new instance of BaseControl class.
        /// </summary>
        protected BaseControl()
        {
            _Error = new ErrorProvider();
            _Error.SetIconAlignment(this, ErrorIconAlignment.MiddleLeft);
            _Error.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            _Error.SetIconPadding(this, 5);

            _Font = new Font("Tahoma", 8, FontStyle.Regular);
            _AllowWrap = true;

            _TextHorizontalAlignment = TextAlignment.Default;
            _TextVerticalAlignment = TextAlignment.Default;

            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
        }

        #endregion

        #endregion

        #region Overrided Methods

        #region protected override void OnRightToLeftChanged(EventArgs e)

        protected override void OnRightToLeftChanged(EventArgs e)
        {
            base.OnRightToLeftChanged(e);
            if (RightToLeft == RightToLeft.Yes)
                _Error.SetIconAlignment(this, ErrorIconAlignment.MiddleLeft);
            else
                _Error.SetIconAlignment(this, ErrorIconAlignment.MiddleRight);
            Repaint();
        }

        #endregion

        #region protected override void OnSystemColorsChanged(EventArgs e)

        protected override void OnSystemColorsChanged(EventArgs e)
        {
            base.OnSystemColorsChanged(e);
            Office2007Colors.Default.Init();
            Repaint();
        }

        #endregion

        #region public override void Refresh()

        /// <summary>
        /// Refreshes the control if it is not in locked mode. 
        /// <seealso cref="BaseStyledControl.BeginUpdate" />, 
        /// <seealso cref="BaseStyledControl.EndUpdate" /> and 
        /// <seealso cref="BaseStyledControl.CancelUpdate"/> methods.
        /// </summary>
        public override void Refresh()
        {
            OnLayoutChanged();
            Repaint();
        }

        #endregion

        #region protected override void OnResize(EventArgs e)

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Repaint();
        }

        #endregion

        #region protected override void OnEnabledChanged(EventArgs e)
        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            Repaint();
        }
        #endregion

        #region protected override void OnMouseMove(MouseEventArgs e)

        protected override void OnMouseMove(MouseEventArgs e)
        {
            IsHot = true;

            Repaint();
            base.OnMouseMove(e);
        }

        #endregion

        #region protected override void OnMouseEnter(EventArgs e)

        protected override void OnMouseEnter(EventArgs e)
        {
            IsHot = true;
            Repaint();
            base.OnMouseEnter(e);
        }

        #endregion

        #region protected override void OnMouseLeave(EventArgs e)

        protected override void OnMouseLeave(EventArgs e)
        {
            IsHot = false;
            Repaint();
            base.OnMouseLeave(e);
        }

        #endregion

        #region protected override void OnMouseDown(MouseEventArgs e)
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button != MouseButtons.Left) return;
            IsFocused = true;
            IsPressed = true;
            Repaint();
        }
        #endregion

        #region protected override void OnMouseUp(MouseEventArgs e)
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button != MouseButtons.Left) return;
            IsPressed = false;
            Repaint();
        }
        #endregion

        #region protected override void OnEnter(EventArgs e)

        protected override void OnEnter(EventArgs e)
        {
            IsFocused = true;
            IsDefault = true;

            Repaint();
            base.OnEnter(e);
        }

        #endregion

        #region protected override void OnLeave(EventArgs e)

        protected override void OnLeave(EventArgs e)
        {
            IsFocused = false;
            IsDefault = false;
            Repaint();
            base.OnLeave(e);
        }

        #endregion

        #endregion

        #region Virtual Methods

        #region protected virtual void FocusNextControl()

        protected virtual void FocusNextControl()
        {
            Form CurrentForm = FindForm();
            if (CurrentForm != null)
            {
                Control ctrl = CurrentForm.GetNextControl(this, true);
                if (ctrl != null) ctrl.Focus();
                CurrentForm.Dispose();
            }
        }

        #endregion

        #region protected virtual void OnValueValidating(ValueValidatingEventArgs e)

        protected virtual void OnValueValidating(ValueValidatingEventArgs e)
        {
            if (ValueValidating != null) ValueValidating(this, e);
        }

        #endregion

        #region protected virtual void OnEnabledStateChanged()
        protected virtual void OnEnabledStateChanged()
        {
            if (EnabledChanged != null) EnabledChanged(this, EventArgs.Empty);
        }
        #endregion

        #region protected virtual void OnReadOnlyStateChanged()
        protected virtual void OnReadOnlyStateChanged()
        {
            if (ReadOnlyChanged != null) ReadOnlyChanged(this, EventArgs.Empty);
        }
        #endregion

        #region protected override void OnGotFocus(EventArgs e)
        protected override void OnGotFocus(EventArgs e)
        {
            IsFocused = true;
            Repaint();
            base.OnGotFocus(e);
        }
        #endregion

        #region protected override void OnLostFocus(EventArgs e)

        protected override void OnLostFocus(EventArgs e)
        {
            IsFocused = false;
            Repaint();
            base.OnLostFocus(e);
        }

        #endregion

        #region protected override void OnMouseWheel(MouseEventArgs e)

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (e.Delta < 0) OnPreviousScrollItems(e);
            else OnNextScrollItems(e);
        }

        #endregion

        #region protected virtual void OnNextScrollItems(object sender, KeyEventArgs e)

        protected virtual void OnNextScrollItems(object sender, KeyEventArgs e)
        {
            if (NextScrollItems != null) NextScrollItems(sender, e);
        }

        #endregion

        #region protected virtual void OnNextScrollItems(MouseEventArgs e)

        protected virtual void OnNextScrollItems(MouseEventArgs e)
        {
            if (NextScrollItems != null) NextScrollItems(this, e);
        }

        #endregion

        #region protected virtual void OnPreviousScrollItems(MouseEventArgs e)

        protected virtual void OnPreviousScrollItems(MouseEventArgs e)
        {
            if (PreviousScrollItems != null) PreviousScrollItems(this, e);
        }

        #endregion

        #region protected virtual void OnPreviousScrollItems(object sender, KeyEventArgs e)

        protected virtual void OnPreviousScrollItems(object sender, KeyEventArgs e)
        {
            if (PreviousScrollItems != null) PreviousScrollItems(sender, e);
        }

        #endregion

        #region protected virtual void OnPropertyChanged(String propertyName)

        protected virtual void OnPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #endregion

        #region Event Handlers

        #region protected virtual void OnLayoutChanged()

        protected virtual void OnLayoutChanged()
        {
            if (!IsHandleCreated || IsDisposed) return;
            if (LayoutChanging != null)
                LayoutChanging(this, EventArgs.Empty);
            Repaint();
            if (LayoutChanged != null)
                LayoutChanged(this, EventArgs.Empty);
        }

        #endregion

        #region protected virtual void OnValueChanged()

        protected virtual void OnValueChanged()
        {
            if (ValueChanged != null)
                ValueChanged(this, EventArgs.Empty);
        }

        #endregion

        #endregion

        #region Serialization

        /// <summary>
        /// Decides to serialize the Font property or not.
        /// </summary>
        /// <returns></returns>
        public Boolean ShouldSerializeFont()
        {
            using (var fnt = new Font("Tahoma", 8, FontStyle.Regular))
            {
                return !Font.Equals(fnt);
            }
        }

        #endregion
    }
}