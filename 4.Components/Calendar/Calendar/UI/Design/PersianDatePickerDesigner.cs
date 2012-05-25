#region using

using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms.Design;
using Negar.PersianCalendar.UI.Controls;

#endregion

namespace Negar.PersianCalendar.UI.Design
{
    /// <summary>
    /// Design behavior of PersianDatePicker control
    /// </summary>
    internal class PersianDatePickerDesigner : PersianBaseDesigner
    {
        #region Initialize
        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
            Verbs.Add(new DesignerVerb("Multiline", OnMultilineChange));
        }
        #endregion

        #region Event Handler
        private void OnMultilineChange(object sender, EventArgs e)
        {
            ChangeService.OnComponentChanging(Control, null);
            Control.Multiline = !Control.Multiline;
            ChangeService.OnComponentChanged(Control, null, null, null);
        }
        #endregion

        #region Props
        public new virtual PersianContainerComboBox Control
        {
            get { return base.Control as PersianContainerComboBox; }
        }
        #endregion

        #region Overrides
        public override SelectionRules SelectionRules
        {
            get
            {
                if (Control.Multiline)
                {
                    return SelectionRules.AllSizeable | SelectionRules.Moveable |
                           SelectionRules.Visible;
                }
                return SelectionRules.RightSizeable |
                       SelectionRules.LeftSizeable | SelectionRules.Visible |
                       SelectionRules.Moveable;
            }
        }

        protected override void PreFilterProperties(IDictionary properties)
        {
            base.PreFilterProperties(properties);

            properties.Remove("Text");
            properties.Remove("AutoScroll");
            properties.Remove("AutoScrollMargin");
            properties.Remove("AutoScrollMinSize");
            properties.Remove("DockPadding");
            properties.Remove("DrawGrid");
            properties.Remove("MinimumSize");
            properties.Remove("MaximumSize");
            properties.Remove("Margin");
            properties.Remove("ForeColor");
            properties.Remove("BackColor");
            properties.Remove("BackgroundImage");
            properties.Remove("BackgroundImageLayout");
        }

        #endregion
    }
}