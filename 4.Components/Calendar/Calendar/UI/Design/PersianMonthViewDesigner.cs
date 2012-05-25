using System.Collections;
using System.Windows.Forms.Design;
using Negar.PersianCalendar.UI.Controls;

namespace Negar.PersianCalendar.UI.Design
{
    /// <summary>
    /// Design behaviour of PersianMonthView Control
    /// </summary>
    internal class PersianMonthViewDesigner : PersianBaseDesigner
    {
        #region Overrides

        protected override void PreFilterProperties(IDictionary properties)
        {
            base.PreFilterProperties(properties);

            properties.Remove("Dock");
            properties.Remove("AutoScroll");
            properties.Remove("AutoScrollMargin");
            properties.Remove("AutoScrollMinSize");
            properties.Remove("DockPadding");
            properties.Remove("DrawGrid");
            properties.Remove("Font");
            properties.Remove("Size");
            properties.Remove("Padding");
            properties.Remove("MinimumSize");
            properties.Remove("MaximumSize");
            properties.Remove("Margin");
            properties.Remove("ForeColor");
            properties.Remove("BackColor");
            properties.Remove("BackgroundImage");
            properties.Remove("BackgroundImageLayout");
        }

        #endregion

        #region Props

        public override SelectionRules SelectionRules
        {
            get { return SelectionRules.Moveable | SelectionRules.Visible; }
        }

        public new PersianMonthView Control
        {
            get { return base.Control as PersianMonthView; }
        }

        #endregion
    }
}