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
    /// PersianDatePickerStrip is a wrapper for <see cref="PersianDatePickerStrip"/> 
    /// class, which makes it usable on <see cref="ToolStrip"/> Controls.
    /// </summary>
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.All)]
    public class PersianDatePickerStrip : ToolStripControlHost
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of <see cref="PersianDatePickerStrip"/>.
        /// </summary>
        public PersianDatePickerStrip()
            : base(CreateControlInstance())
        {
        }

        #endregion

        #region Properties

        #region PersianDatePicker PersianDatePicker

        /// <summary>
        /// Represents the PersianDatePicker control that will be displayed by the tool strip.
        /// </summary>
        [Description("Represents control that will be displayed by the tool strip.")]
        public PersianDatePicker PersianDatePicker
        {
            get { return Control as PersianDatePicker; }
        }

        #endregion

        #region Color BackColor

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
        /// 
        /// </summary>
        /// <returns></returns>
        private static Control CreateControlInstance()
        {
            PersianDatePicker TheDatePicker = new PersianDatePicker();
            return TheDatePicker;
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