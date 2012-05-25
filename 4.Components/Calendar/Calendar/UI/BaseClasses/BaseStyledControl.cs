#region using

using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using Negar.PersianCalendar.UI.Design;
using Negar.PersianCalendar.UI.Drawing;

#endregion

namespace Negar.PersianCalendar.UI.BaseClasses
{
    /// <summary>
    /// Base class for all controls, which provides painting functionality bases on selected theme.
    /// </summary>
    [ToolboxItem(false)]
    public class BaseStyledControl : Control
    {

        #region Fields

        #region CultureName _ControlCulture
        /// <summary>
        /// نوع فرهنگ كنترل
        /// </summary>
        private CultureName _ControlCulture;
        #endregion

        private static readonly FAPainterOffice2007 _PainterOffice2007;
        private static readonly ToolStripProfessionalRenderer _Renderer;
        private Int32 _LockUpdate;
        #endregion

        #region Properties

        #region CultureName ControlCulture
        /// <summary>
        /// نوع فرهنگ كنترل
        /// </summary>
        [Bindable(true)]
        [Localizable(true)]
        [RefreshProperties(RefreshProperties.All)]
        [DefaultValue(typeof(CultureName), "Persian")]
        [Description("نوع فرهنگ كنترل")]
        public CultureName ControlCulture
        {
            get { return _ControlCulture; }
            set
            {
                if (value == CultureName.Persian)
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("fa-Ir");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("fa-Ir");
                }
                else
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                }
                Invalidate();
                _ControlCulture = value;
            }
        }
        #endregion

        #region public Object About
        /// <summary>
        /// Displays the about form of the control when in Design-Mode.
        /// </summary>
        [DesignOnly(true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [ParenthesizePropertyName(true)]
        [Editor(typeof(AboutDialogEditor), typeof(UITypeEditor))]
        public Object About
        {
            get { return null; }
        }
        #endregion

        #region internal static ProfessionalColorTable ColorTable
        [Browsable(false)]
        internal static ProfessionalColorTable ColorTable
        {
            get { return _Renderer.ColorTable; }
        }
        #endregion

        #region internal Boolean IsRightToLeft
        [Browsable(false)]
        internal Boolean IsRightToLeft
        {
            get { return RightToLeft == RightToLeft.Yes; }
        }
        #endregion

        #region internal static ToolStripProfessionalRenderer ToolStripRenderer
        [Browsable(false)]
        internal static ToolStripProfessionalRenderer ToolStripRenderer
        {
            get { return _Renderer; }
        }
        #endregion

        #region public Boolean UseThemes
        /// <summary>
        /// Checks if the control can paint itself using styles. 
        /// Styles are only available on WindowsXP or 
        /// greater, and should be enabled by the developer, 
        /// using <see cref="Application.RenderWithVisualStyles">RenderWithVisualStyles</see> property of 
        /// <see cref="Application">Application</see> class.
        /// </summary>
        [Browsable(false)]
        public Boolean UseThemes
        {
            get { return PersianThemeManager.UseThemes; }
        }
        #endregion

        #endregion

        #region Ctors

        #region static BaseStyledControl()
        /// <summary>
        /// Creates static painter objects for each of available Themes.
        /// </summary>
        static BaseStyledControl()
        {
            _Renderer = new ToolStripProfessionalRenderer();
            _PainterOffice2007 = new FAPainterOffice2007();
        }
        #endregion

        #region public BaseStyledControl()
        /// <summary>
        /// Creates a new instance of BaseStyledControl class.
        /// </summary>
        public BaseStyledControl()
        {
            // Set painting style for better performance.
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.UserPaint, true);
            if (UseThemes) Office2007Colors.Default.Init();
        }
        #endregion

        #endregion

        #region Events

        /// <summary>
        /// Fired when current theme changes.
        /// </summary>
        public event EventHandler ThemeChanged;

        #endregion

        #region Methods

        #region public void BeginUpdate()
        /// <summary>
        /// قفل كننده كنترل برای به روز رسانی
        /// </summary>
        public void BeginUpdate()
        {
            _LockUpdate++;
        }
        #endregion

        #region public void EndUpdate()

        /// <summary>
        /// Removes a update lock from control.
        /// </summary>
        public void EndUpdate()
        {
            _LockUpdate--;
        }

        #endregion

        #region public void CancelUpdate()

        /// <summary>
        /// Cancels all previous locks on the control. Does NOT repaint the control.
        /// </summary>
        public void CancelUpdate()
        {
            _LockUpdate = 0;
        }

        #endregion

        #region public Boolean CanUpdate
        /// <summary>
        /// Decides if the user is updatable or in lock mode.
        /// </summary>
        [Browsable(false)]
        public Boolean CanUpdate
        {
            get { return _LockUpdate == 0; }
        }
        #endregion

        #region public void Repaint()
        /// <summary>
        /// Invalidate and repaints the control if it is not in lock mode.
        /// </summary>
        public void Repaint()
        {
            if (CanUpdate) Invalidate();
        }
        #endregion

        #region public IFAPainter Painter
        /// <summary>
        /// Painter object which helps control paint itself on the screen, based on the current selected theme.
        /// </summary>
        [Browsable(false)]
        public IFAPainter Painter
        {
            get { return _PainterOffice2007; }
        }
        #endregion

        #region protected override void OnSystemColorsChanged(EventArgs e)

        protected override void OnSystemColorsChanged(EventArgs e)
        {
            base.OnSystemColorsChanged(e);
            UpdateRenderer();
            Invalidate();
        }

        #endregion

        #region protected virtual void OnThemeChanged(EventArgs e)

        protected virtual void OnThemeChanged(EventArgs e)
        {
            if (ThemeChanged != null) ThemeChanged(this, e);
            Repaint();
        }

        #endregion

        #region protected virtual void OnThemeChanged()

        /// <summary>
        /// 
        /// </summary>
        protected virtual void OnThemeChanged()
        {
            if (ThemeChanged != null)
                ThemeChanged(this, EventArgs.Empty);
            Repaint();
        }

        #endregion

        #region private void UpdateRenderer()
        /// <summary>
        /// 
        /// </summary>
        private static void UpdateRenderer()
        {
            _Renderer.ColorTable.UseSystemColors = false;
        }
        #endregion

        #endregion

    }
}