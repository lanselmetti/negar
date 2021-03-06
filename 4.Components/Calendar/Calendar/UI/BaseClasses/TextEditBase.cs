#region using
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Negar.PersianCalendar.UI.Drawing;
#endregion

namespace Negar.PersianCalendar.UI.BaseClasses
{
    /// <summary>
    /// كلاس پایه جعبه متن برای مدیریت تقویم
    /// </summary>
    [ToolboxItem(false)]
    public class TextEditBase : BaseControl
    {
        #region Fields

        #region internal RightToLeft RTL

        /// <summary>
        /// فیلد تعیین راست به چپ كلاس
        /// </summary>
        internal RightToLeft RTL;

        #endregion

        #region internal MaskedTextBox TextBox
        /// <summary>
        /// كنترل جعبه متن موجود در كلاس
        /// </summary>
        internal MaskedTextBox TextBox;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض كنترل
        /// </summary>
        public TextEditBase()
        {
            // Note: محل تنظیمات مربوط به كنترل جعبه متن
            RTL = RightToLeft.No;
            TextBox = new MaskedTextBox();
            TextBox.RightToLeft = RTL;
            TextBox.BorderStyle = BorderStyle.None;
            TextBox.AutoSize = false;
            TextBox.Dock = DockStyle.Fill;
            TextBox.PromptChar = ' ';
            TextBox.HidePromptOnLeave = true;
            TextBox.Mask = "0000/00/00";
            TextBox.TextMaskFormat = MaskFormat.IncludeLiterals;
            TextBox.InsertKeyMode = InsertKeyMode.Overwrite;
            TextBox.Font = new Font("Tahoma", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 178);
            TextBox.TabIndex = 0;
            // محل تعیین سایز پیش فرض كنترل
            Width = 100;
            Height = 20;
            base.BackColor = Color.White;
            #region Add Event Handlers
            TextBox.MouseEnter += (TextBox_MouseEnter);
            TextBox.MouseLeave += (TextBox_MouseLeave);
            TextBox.GotFocus += (TextBox_GotFocus);
            TextBox.LostFocus += (TextBox_LostFocus);
            TextBox.SizeChanged += (TextBox_SizeChanged);
            TextBox.MouseUp += (InvokeMouseUp);
            TextBox.MouseDown += (InvokeMouseDown);
            TextBox.MouseEnter += (InvokeMouseEnter);
            TextBox.MouseHover += (InvokeMouseHover);
            TextBox.MouseLeave += (InvokeMouseLeave);
            TextBox.MouseMove += (InvokeMouseMove);
            TextBox.KeyDown += (InvokeKeyDown);
            TextBox.KeyUp += (InvokeKeyUp);
            TextBox.Click += (InvokeClick);
            TextBox.DoubleClick += (InvokeDoubleClick);
            ThemeChanged += (OnThemeChanged);
            #endregion
            Controls.Add(TextBox);
        }
        #endregion

        #region Properties

        #region public Boolean Multiline
        /// <summary>
        /// Checks if the textbox control should be in multiline mode.
        /// </summary>
        [DefaultValue(false)]
        [Browsable(false)]
        [RefreshProperties(RefreshProperties.All)]
        public Boolean Multiline
        {
            get { return TextBox.Multiline; }
            set
            {
                if (value) Multiline = false;
                if (TextBox.Multiline == value) return;
                TextBox.Multiline = value;
                OnPropertyChanged("Multiline");
                if (value == false)
                {
                    Height = 20;
                    SetPosTextBox();
                }
            }
        }
        #endregion

        #region public override Color BackColor
        /// <summary>
        /// رنگ پس زمبنه كنترل
        /// </summary>
        [DefaultValue(typeof(Color), "Window")]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                base.BackColor = value;
                OnPropertyChanged("BackColor");
            }
        }
        #endregion

        #region public override RightToLeft RightToLeft
        /// <summary>
        /// وضعیت راست به چپ كنترل
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Browsable(false)]
        [DefaultValue(RightToLeft.No)]
        [RefreshProperties(RefreshProperties.All)]
        public override RightToLeft RightToLeft
        {
            get { return RTL; }
            set
            {
                if (value != RightToLeft.No) value = RightToLeft.No;
                if (RTL == value) return;
                RTL = value;
                TextBox.RightToLeft = value;
                OnPropertyChanged("RightToLeft");
                OnRightToLeftChanged(EventArgs.Empty);
            }
        }
        #endregion

        #region public virtual String SelectionText
        /// <summary>
        /// Selection Text of the textbox control.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public virtual String SelectionText
        {
            get { return TextBox.SelectedText; }
            set
            {
                if (TextBox.SelectedText == value) return;
                TextBox.SelectedText = value;
                OnPropertyChanged("SelectionText");
            }
        }
        #endregion

        #region public virtual Int32 SelectionStart

        /// <summary>
        /// SelectionStart of the control.
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual Int32 SelectionStart
        {
            get { return TextBox.SelectionStart; }
            set { TextBox.SelectionStart = value; }
        }

        #endregion

        #region public override String Text
        /// <summary>
        /// Text of the control.
        /// </summary>
        [DefaultValue("")]
        [Browsable(false)]
        public override String Text
        {
            get { return TextBox.Text; }
            set
            {
                if (Text == value) return;
                base.Text = value;
                TextBox.Text = value;
            }
        }
        #endregion

        #region public override Font Font

        /// <summary>
        /// Font of the control.
        /// </summary>
        public override Font Font
        {
            get { return base.Font; }
            set
            {
                if (base.Font == value) return;
                base.Font = value;
                TextBox.Font = value;
                OnPropertyChanged("Font");
            }
        }

        #endregion

        #region public virtual Int32 SelectionLength

        /// <summary>
        /// Selection length of the control.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public virtual Int32 SelectionLength
        {
            get { return TextBox.SelectionLength; }
            set { TextBox.SelectionLength = value; }
        }

        #endregion

        #region public override Boolean Enabled
        /// <summary>
        /// Sets the control in disabled mode.
        /// </summary>
        [Category("Behavior")]
        [DefaultValue(true)]
        [RefreshProperties(RefreshProperties.All)]
        public override Boolean Enabled
        {
            get { return base.Enabled; }
            set
            {
                if (base.Enabled == value) return;
                base.Enabled = value;
                if (value)
                {
                    TextBox.BackColor = Color.White;
                    TextBox.Enabled = true;
                }
                else
                {
                    TextBox.BackColor = Color.Gray;
                    TextBox.Enabled = false;
                    IsReadonly = true;
                }
                Repaint();
            }
        }
        #endregion

        #region public override Boolean IsReadonly
        /// <summary>
        /// Sets or Gets the control in IsReadonly mode.
        /// </summary>
        [Category("Behavior"), DefaultValue(false)]
        [RefreshProperties(RefreshProperties.All)]
        public override Boolean IsReadonly
        {
            get { return base.IsReadonly; }
            set
            {
                if (base.IsReadonly == value) return;
                base.IsReadonly = value;
                // ReadOnly == True
                if (value)
                {
                    TextBox.BackColor = Color.White;
                    TextBox.ReadOnly = true;
                }
                // ReadOnly == False
                else
                {
                    if (Enabled) TextBox.BackColor = Color.White;
                    else TextBox.BackColor = Color.Gray;
                    TextBox.ReadOnly = false;
                }
                Repaint();
            }
        }

        #endregion

        #region public virtual Int32 MaxLength
        /// <summary>
        /// MaxLength of the TextBox control.
        /// </summary>
        [Category("Behavior"), DefaultValue(32767)]
        [Browsable(false)]
        public virtual Int32 MaxLength
        {
            get { return TextBox.MaxLength; }
            set { TextBox.MaxLength = value; }
        }

        #endregion

        #region public virtual Boolean HideSelection

        /// <summary>
        /// HideSelection of the TextBox control.
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual Boolean HideSelection
        {
            get { return TextBox.HideSelection; }
            set { TextBox.HideSelection = value; }
        }

        #endregion

        #region public override Image BackgroundImage
        /// <summary>
        /// Background Image of the control.
        /// </summary>
        [Browsable(false)]
        public override Image BackgroundImage
        {
            get { return base.BackgroundImage; }
        }
        #endregion

        #region public override Boolean IsFocused
        /// <summary>
        /// Gets or Sets the control in Focused state.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public override Boolean IsFocused
        {
            get
            {
                if (!Focused) return TextBox.Focused;
                return true;
            }
            set
            {
                if (base.IsFocused == value) return;

                base.IsFocused = value;
                if (value) TextBox.Focus();
            }
        }
        #endregion

        #endregion

        #region Event Handlers

        #region TextBox_GotFocus
        private void TextBox_GotFocus(object sender, EventArgs e)
        {
            Repaint();
            InvokeGotFocus(this, e);
            TextBox.SelectionStart = 8;
        }
        #endregion

        #region TextBox_LostFocus
        private void TextBox_LostFocus(object sender, EventArgs e)
        {
            Repaint();
            InvokeLostFocus(this, e);
        }
        #endregion

        #region TextBox_MouseEnter
        private void TextBox_MouseEnter(object sender, EventArgs e)
        {
            IsHot = true;
            Repaint();
        }
        #endregion

        #region TextBox_MouseLeave
        private void TextBox_MouseLeave(object sender, EventArgs e)
        {
            IsHot = ClientRectangle.Contains(PointToClient(Cursor.Position));
            Repaint();
        }
        #endregion

        #region TextBox_SizeChanged
        private void TextBox_SizeChanged(object sender, EventArgs e)
        {
            SetPosTextBox();
            Repaint();
        }
        #endregion

        #region OnThemeChanged
        private void OnThemeChanged(object sender, EventArgs e)
        {
            SetPosTextBox();
        }
        #endregion

        #region private void InvokeClick(object sender, EventArgs e)
        private void InvokeClick(object sender, EventArgs e)
        {
            OnClick(e);
        }
        #endregion

        #region private void InvokeDoubleClick(object sender, EventArgs e)
        private void InvokeDoubleClick(object sender, EventArgs e)
        {
            OnDoubleClick(e);
        }
        #endregion

        #region private void InvokeKeyDown(object sender, KeyEventArgs e)
        private void InvokeKeyDown(object sender, KeyEventArgs e)
        {
            OnKeyDown(e);
        }
        #endregion

        #region private void InvokeKeyUp(object sender, KeyEventArgs e)
        private void InvokeKeyUp(object sender, KeyEventArgs e)
        {
            OnKeyUp(e);
        }
        #endregion

        #region private void InvokeMouseDown(object sender, MouseEventArgs e)
        private void InvokeMouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDown(e);
        }
        #endregion

        #region private void InvokeMouseEnter(object sender, EventArgs e)
        private void InvokeMouseEnter(object sender, EventArgs e)
        {
            OnMouseEnter(e);
        }
        #endregion

        #region private void InvokeMouseHover(object sender, EventArgs e)
        private void InvokeMouseHover(object sender, EventArgs e)
        {
            IsHot = true;
            OnMouseHover(e);
        }
        #endregion

        #region private void InvokeMouseLeave(object sender, EventArgs e)
        private void InvokeMouseLeave(object sender, EventArgs e)
        {
            IsHot = false;
            OnMouseLeave(e);
        }
        #endregion

        #region private void InvokeMouseMove(object sender, MouseEventArgs e)
        private void InvokeMouseMove(object sender, MouseEventArgs e)
        {
            OnMouseMove(e);
        }
        #endregion

        #region private void InvokeMouseUp(object sender, MouseEventArgs e)
        private void InvokeMouseUp(object sender, MouseEventArgs e)
        {
            OnMouseUp(e);
        }
        #endregion

        #endregion

        #region Methods

        #region protected virtual Rectangle GetContentRect()
        protected virtual Rectangle GetContentRect()
        {
            return new Rectangle(2, 2, Width - 2, Height - 4);
        }
        #endregion

        #endregion

        #region Paint Methods

        #region protected override void OnPaint(PaintEventArgs e)
        /// <summary>
        /// تابعی برای مدیریت رسم كنترل
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle clipRect = new Rectangle(0, 0, Width, Height);
            PaintEventArgs args = new PaintEventArgs(e.Graphics, clipRect);
            // حالتی كه كنترل فعال نیست
            if (!Enabled) OnDrawDisabledBackground(args);
            // رسم بر اساس قالب رسم
            OnDrawOffice2007Border(args);
            // رسم دكمه ها
            OnDrawButtons(args);
            base.OnPaint(e);
        }
        #endregion

        #region protected virtual void OnDrawDisabledBackground(PaintEventArgs e)
        /// <summary>
        /// تابع رسم حالت غیر فعال كنترل
        /// </summary>
        protected virtual void OnDrawDisabledBackground(PaintEventArgs e)
        {
            // Note: محل تنظیم رنگ حالت غیر فعال
            e.Graphics.FillRectangle(SystemBrushes.InactiveCaption, e.ClipRectangle);
        }
        #endregion

        #region protected virtual void OnDrawButtons(PaintEventArgs e)
        protected virtual void OnDrawButtons(PaintEventArgs e)
        {

        }
        #endregion

        #region private void OnDrawOffice2007Border(PaintEventArgs e)
        private void OnDrawOffice2007Border(PaintEventArgs e)
        {
            if ((IsHot || IsFocused) && Enabled)
            {
                Color color = Office2007Colors.Default[Office2007Color.NavBarBackColor2];
                using (Pen pen = new Pen(color))
                {
                    e.Graphics.DrawRectangle(pen,
                        new Rectangle(e.ClipRectangle.X, e.ClipRectangle.Y,
                            e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1));
                }
            }
            else if (!Enabled)
            {
                e.Graphics.FillRectangle(SystemBrushes.Control, e.ClipRectangle);
                e.Graphics.DrawRectangle(SystemPens.ControlDark,
                    new Rectangle(e.ClipRectangle.X, e.ClipRectangle.Y,
                        e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1));
            }
        }
        #endregion

        #endregion

        #region Overrides

        #region protected override void OnRightToLeftChanged(EventArgs e)
        protected override void OnRightToLeftChanged(EventArgs e)
        {
            base.OnRightToLeftChanged(e);
            TextBox.RightToLeft = RTL;
            SetPosTextBox();
            Repaint();
        }
        #endregion

        #region protected override void OnBackColorChanged(EventArgs e)
        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
            TextBox.BackColor = BackColor;
        }
        #endregion

        #region protected override void OnGotFocus(EventArgs e)
        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            TextBox.Focus();
        }
        #endregion

        #region protected override void OnSizeChanged(EventArgs e)
        protected override void OnSizeChanged(EventArgs e)
        {
            SetPosTextBox();
            base.OnSizeChanged(e);
        }
        #endregion

        #region protected override void OnTabStopChanged(EventArgs e)
        protected override void OnTabStopChanged(EventArgs e)
        {
            base.OnTabStopChanged(e);
            TextBox.TabStop = TabStop;
        }
        #endregion

        #region protected override void OnTextChanged(EventArgs e)
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            TextBox.Text = Text;
        }
        #endregion

        #region protected virtual void SetPosTextBox()
        protected virtual void SetPosTextBox()
        {
            SetPosTextBox(GetContentRect());
        }
        #endregion

        #region protected virtual void SetPosTextBox(Rectangle content)
        protected virtual void SetPosTextBox(Rectangle content)
        {
            try
            {
                TextBox.Top = (Height - TextBox.Height + 2) / 2;
                TextBox.Size = new Size(content.Width - 4, content.Height);
                TextBox.Left = content.Left;
            }
            // ReSharper disable EmptyGeneralCatchClause
            catch (Exception) { }
            // ReSharper restore EmptyGeneralCatchClause
            Repaint();
        }
        #endregion

        #endregion

    }
}