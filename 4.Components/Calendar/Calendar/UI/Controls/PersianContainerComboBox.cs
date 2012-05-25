#region using
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Negar.PersianCalendar.UI.BaseClasses;
using Negar.PersianCalendar.UI.Drawing;
using Negar.PersianCalendar.UI.PersianPopup;
#endregion

namespace Negar.PersianCalendar.UI.Controls
{
    /// <summary>
    /// كلاس پایه كمبو باكسی كه قابلیت دارد كنترل های دلخواهی را در خود جای دهد.
    /// این كلاس به صورت پیش فرض از سه قالب مختلف پشتیبانی می كند
    /// </summary>
    public class PersianContainerComboBox : DateEditBase
    {

        #region Fields
        /// <summary>
        /// كنترل تقویم ملحق شده به كمبو باكس
        /// </summary>
        private IPopupControl _BindedCalendarControl;
        /// <summary>
        /// تعیین فشرده شدن دكمه كمبوباكس
        /// </summary>
        private Boolean _IsButtonPressed;
        #endregion

        #region Events
        /// <summary>
        /// تعیین كلیك شدن دكمه ی انتخاب
        /// </summary>
        protected event EventHandler ButtonClick;
        /// <summary>
        /// رخداد به وقوع پیوسته قبل از نمایش كنترل زیر مجموعه
        /// </summary>
        protected event EventHandler PopupShowing;
        /// <summary>
        /// رخداد به وقوع پیوسته قبل از مخفی شدن كنترل زیر مجموعه
        /// </summary>
        protected event EventHandler PopupClosing;
        protected event BindPopupControlEventHandler BindPopupControl;
        #endregion

        #region Ctor

        #region PersianContainerComboBox()
        /// <summary>
        /// سازنده پیش فرض كلاس
        /// </summary>
        public PersianContainerComboBox()
        {
            SetStyle(ControlStyles.Selectable, false);
            TextBox.Enter += TextBox_Enter;
            LostFocus += OnInternalLostFocus;
            // ReSharper disable DoNotCallOverridableMethodsInConstructor
            TextBox.RightToLeft = RightToLeft;
            TextBox.Font = Font;
            // ReSharper restore DoNotCallOverridableMethodsInConstructor
            TextBox.MouseMove += OnDropDownMouseMove;
            TextBox.KeyDown += OnDropDownKeyDown;
        }
        #endregion

        #region protected override void Dispose(Boolean disposing)
        /// <summary>
        /// Disposes the control.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(Boolean disposing)
        {
            if (TextBox != null)
            {
                TextBox.Enter -= TextBox_Enter;
                LostFocus -= OnInternalLostFocus;
                TextBox.MouseMove -= OnDropDownMouseMove;
                TextBox.KeyDown -= OnDropDownKeyDown;
            }
            base.Dispose(disposing);
        }
        #endregion

        #endregion

        #region Properties

        #region protected IPopupControl BindedControl
        /// <summary>
        /// كنترل جانبی الحاق شده به كمبوباكس
        /// </summary>
        protected IPopupControl BindedControl
        {
            get { return _BindedCalendarControl; }
        }
        #endregion

        #region new String Text
        /// <summary>
        /// متن تاریخ انتخاب شده
        /// </summary>
        [DefaultValue("")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Description("متن تاریخ انتخاب شده.")]
        public new String Text
        {
            get { return TextBox.Text; }
            set
            {
                if (value == TextBox.Text) return;
                TextBox.Text = value;
                OnValueChanged();
                Repaint();
            }
        }
        #endregion

        #region Boolean IsReadonly
        /// <summary>
        /// تغییر وضعیت كنترل به فقط خواندنی
        /// </summary>
        [DefaultValue(false)]
        [Description("تغییر وضعیت كنترل به فقط خواندنی.")]
        public new Boolean IsReadonly
        {
            get { return base.IsReadonly; }
            set
            {
                if (base.IsReadonly == value) return;
                base.IsReadonly = value;
                OnReadOnlyStateChanged();
                Repaint();
            }
        }
        #endregion

        #region Boolean IsPopupOpen
        /// <summary>
        /// تعیین باز بودن كنترل تقویم
        /// </summary>
        [Browsable((false))]
        public Boolean IsPopupOpen { get; set; }
        #endregion

        #endregion

        #region Overrided Methods

        #region protected virtual void OnBindingPopupControl(BindPopupControlEventArgs e)
        protected virtual void OnBindingPopupControl(BindPopupControlEventArgs e)
        {
            if (BindPopupControl != null) BindPopupControl(this, e);
            _BindedCalendarControl = e.BindedControl;
        }
        #endregion

        #region protected override void OnHandleCreated(EventArgs e)

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            SetPosTextBox();
        }

        #endregion

        #region protected override void OnFontChanged(EventArgs e)

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            TextBox.Font = Font;
        }

        #endregion

        #region protected virtual Rectangle GetButtonRect()
        protected virtual Rectangle GetButtonRect()
        {
            // Note: شكل ظاهری دكمه ی كمبوباكس اینجا تعریف می شود
            const Int32 buttonWidth = 18;
            Rectangle bounds = GetContentRect();
            if (!Enabled || IsReadonly)
                return new Rectangle(bounds.Width + 20, bounds.Top, 0, 0);
            if (RightToLeft != RightToLeft.Yes)
                return new Rectangle(bounds.Width + 1, bounds.Top - 1, buttonWidth, bounds.Height + 2);
            return new Rectangle(1, bounds.Top - 1, buttonWidth, bounds.Height + 2);
        }
        #endregion

        #region protected override Rectangle GetContentRect()
        protected override Rectangle GetContentRect()
        {
            const Int32 buttonWidth = 18;
            if (RightToLeft != RightToLeft.Yes)
                return new Rectangle(4, 2, Width - buttonWidth - 2, Height - 4);
            return new Rectangle(buttonWidth + 5, 2, Width - buttonWidth - 7, Height - 4);
        }
        #endregion

        #endregion

        #region Event Handlers

        #region OnInternalLostFocus
        /// <summary>
        /// در هنگام خارج شدن از این كنترل این تابع فراخوانی می شود
        /// </summary>
        private void OnInternalLostFocus(object sender, EventArgs e)
        {
            HideDropDown();
        }
        #endregion

        #region OnPopupClosing
        protected virtual void OnPopupClosing(EventArgs e)
        {
            if (PopupClosing != null) PopupClosing(this, EventArgs.Empty);
        }
        #endregion

        #region OnPopupShowing
        protected virtual void OnPopupShowing(EventArgs e)
        {
            if (PopupShowing != null) PopupShowing(this, EventArgs.Empty);
        }
        #endregion

        #region OnDropDownKeyDown
        private void OnDropDownKeyDown(object sender, KeyEventArgs e)
        {
            base.OnKeyDown(e);
            Int32 Position = TextBox.SelectionStart;
            // Note: محل تغییر كلید های میانبر
            // Up Or Down
            if (e.KeyData == Keys.Up || e.KeyData == Keys.Down) { e.Handled = true; return; }
            // Alt + Up
            if (e.KeyData == (Keys.Alt | Keys.Up) && !IsReadonly) HideDropDown();
            // Alt + Down
            else if (e.KeyData == (Keys.Alt | Keys.Down) && !IsReadonly) ShowDropDown();

            #region Ctrl + Left
            else if (e.KeyData == (Keys.Control | Keys.Left) && !IsReadonly)
            {
                // اگر بر روی ماه قرار داشته باشد
                if (TextBox.SelectionStart < 8)
                {
                    TextBox.SelectionStart = 0;
                    TextBox.SelectionLength = 0;
                }
                // اگر بر روی روز قرار داشته باشد
                else
                {
                    TextBox.SelectionStart = 5;
                    TextBox.SelectionLength = 0;
                }
                e.Handled = true;
                return;
            }
            #endregion

            #region Ctrl + Right
            else if (e.KeyData == (Keys.Control | Keys.Right) && !IsReadonly)
            {
                // اگر بر روی سال قرار داشته باشد
                if (TextBox.SelectionStart < 5)
                {
                    TextBox.SelectionStart = 5;
                    TextBox.SelectionLength = 0;
                }
                // اگر بر روی ماه قرار داشته باشد
                else
                {
                    TextBox.SelectionStart = 8;
                    TextBox.SelectionLength = 0;
                }
                e.Handled = true;
                return;
            }
            #endregion
            // Escape:
            else if (e.KeyCode == Keys.Escape && IsPopupOpen && !IsReadonly) HideDropDown();
            // Enter:
            else if (e.KeyCode == Keys.Enter && !IsReadonly)
            {
                if (IsPopupOpen) HideDropDown();
                else ShowDropDown();
            }
            TextBox.SelectionStart = Position;
        }
        #endregion

        #region TextBox_Enter
        void TextBox_Enter(object sender, EventArgs e)
        {
            TextBox.SelectionStart = 8;
            TextBox.SelectionLength = 0;
        }
        #endregion

        #region OnDropDownMouseMove
        private void OnDropDownMouseMove(object sender, MouseEventArgs e)
        {
            _IsButtonPressed = false;
            Repaint();
        }
        #endregion

        #region OnMouseDown
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (IsMouseOverButton()) _IsButtonPressed = true;
            else _IsButtonPressed = false;
            Repaint();
        }
        #endregion

        #region OnMouseUp
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (IsMouseOverButton() && _IsButtonPressed)
            {
                RaiseButtonClick();
                if (IsPopupOpen) HideDropDown();
                else ShowDropDown();
            }
            else if (BindedControl != null) BindedControl.ClosePopup();
            _IsButtonPressed = false;
            Repaint();
        }
        #endregion

        #endregion

        #region Methods

        #region private Boolean IsMouseOverButton()
        private Boolean IsMouseOverButton()
        {
            Point point = PointToClient(MousePosition);
            if (GetButtonRect().Contains(point) && !GetContentRect().Contains(point))
                return true;
            return false;
        }
        #endregion

        #region protected void RaiseButtonClick()
        protected void RaiseButtonClick()
        {
            if (ButtonClick != null) ButtonClick(this, EventArgs.Empty);
        }
        #endregion

        #region Show/Hide DropDown Window

        #region public void ShowDropDown()
        /// <summary>
        /// تابعی برای نمایش كنترل الحاقی به كمبوباكس
        /// </summary>
        public void ShowDropDown()
        {
            if (BindedControl == null)
            {
                BindPopupControlEventArgs args = new BindPopupControlEventArgs(this);
                OnBindingPopupControl(args);
            }
            else
            {
                OnPopupShowing(EventArgs.Empty);
                BindedControl.ShowPopup();
            }
            IsPopupOpen = true;
        }
        #endregion

        #region public void HideDropDown()
        /// <summary>
        /// تابعی برای مخفی كردن كنترل جانبی
        /// </summary>
        public void HideDropDown()
        {

            if (BindedControl != null) BindedControl.ClosePopup();
            IsPopupOpen = false;
            Repaint();
        }
        #endregion

        #endregion

        #endregion

        #region Paint Methods

        #region protected override void OnDrawButtons(PaintEventArgs e)
        protected override void OnDrawButtons(PaintEventArgs e)
        {
            // Note: دكمه ی كمبوباكس اینجا رسم می شود
            base.OnDrawButtons(e);
            Rectangle rect = GetButtonRect();
            Painter.DrawWhiteBackground(e.Graphics, rect, false, 0);
            if (Enabled || !IsReadonly)
            {
                if (_IsButtonPressed)
                {
                    Painter.DrawButton(e.Graphics, rect, String.Empty, Font, null, ItemState.Pressed, false, true);
                    Painter.DrawVerticalArrow(e.Graphics, rect, IsRightToLeft, false, 3);
                    Color c = Office2007Colors.Default[Office2007Color.NavBarBackColor2];
                    using (Pen p = new Pen(c))
                    {
                        e.Graphics.DrawLine(p, new Point(IsRightToLeft ? rect.Right : rect.Left, rect.Top),
                            new Point(IsRightToLeft ? rect.Right : rect.Left, rect.Bottom));
                    }
                }
                else if (IsHot || IsFocused)
                {
                    Painter.DrawButton(e.Graphics, rect, String.Empty, Font, null, ItemState.HotTrack, false, true);
                    Painter.DrawVerticalArrow(e.Graphics, rect, IsRightToLeft, false, 3);
                    Color c = Office2007Colors.Default[Office2007Color.NavBarBackColor2];
                    using (Pen p = new Pen(c))
                    {
                        p.Color = Color.Blue;
                        e.Graphics.DrawLine(p, new Point(IsRightToLeft ? rect.Right : rect.Left, rect.Top),
                            new Point(IsRightToLeft ? rect.Right : rect.Left, rect.Bottom));
                    }
                }
                else
                {
                    Painter.DrawButton(e.Graphics, rect, String.Empty, Font, null, ItemState.Normal, false, true);
                    Painter.DrawVerticalArrow(e.Graphics, rect, IsRightToLeft, false, 3);
                }
            }
        }
        #endregion

        #endregion

    }
}