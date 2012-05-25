#region using

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

#endregion

namespace Negar.PersianCalendar.UI.Controls
{
    /// <summary>
    /// PersianMonthViewStrip is a wrapper for 
    /// <see cref="Controls.PersianMonthView"/> class, 
    /// which makes it usable on <see cref="ToolStrip"/> Controls.
    /// </summary>
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.All)]
    public class PersianMonthViewStrip : ToolStripControlHost
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of <see cref="PersianMonthViewStrip"/>.
        /// </summary>
        public PersianMonthViewStrip()
            : base(CreateControlInstance())
        {
        }

        #endregion

        #region Properties

        #region PersianMonthView PersianMonthView

        /// <summary>
        /// Returns the <see cref="PersianMonthView"/> instance the control is hosting.
        /// </summary>
        [Description("Represents a PersianMonthView control that displayed by this tool strip.")]
        public PersianMonthView PersianMonthView
        {
            get { return Control as PersianMonthView; }
        }

        #endregion

        #region override Color BackColor

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set { }
        }

        #endregion

        #region override String Text

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override String Text
        {
            get { return String.Empty; }
            set
            {
                value = String.Empty;
                base.Text = value;
            }
        }

        #endregion

        #endregion

        #region Methods

        #region private static Control CreateControlInstance()
        /// <summary>
        /// Create the actual control, this is static so it can be called from the constructor.
        /// </summary>
        /// <returns></returns>
        private static Control CreateControlInstance()
        {
            PersianMonthView mv = new PersianMonthView(false);
            return mv;
        }
        #endregion

        #region public Boolean ShouldSerializeText()

        /// <summary>
        /// Determines when to serialize Text value of the control.
        /// </summary>
        /// <returns></returns>
        public Boolean ShouldSerializeText()
        {
            return false;
        }

        #endregion

        #endregion
    }
}