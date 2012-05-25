using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;
using Negar.PersianCalendar.Utilities;

namespace Negar.PersianCalendar.UI.Design
{
    /// <summary>
    /// Type Converter for PersianDate type which handles convertion of various types to PersianDate, mostly in design mode.
    /// </summary>
    internal class PersianDateTypeConverter : TypeConverter
    {
        #region Override

        public override Boolean CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof (String))
                return true;

            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value != null && value is String)
                return new PersianDate(value.ToString());

            return base.ConvertFrom(context, culture, value);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value,
                                         Type destinationType)
        {
            if (value != null && value is PersianDate)
            {
                if (destinationType == typeof (InstanceDescriptor) && value != null)
                {
                    var pd = (PersianDate) value;
                    ConstructorInfo ctor =
                        typeof (PersianDate).GetConstructor(new[] {typeof (Int32), typeof (Int32), typeof (Int32)});
                    var args = new object[] {pd.Year, pd.Month, pd.Day};

                    if (ctor != null)
                        return new InstanceDescriptor(ctor, args);
                }
                else if (destinationType == typeof (String))
                {
                    var pd = (PersianDate) value;
                    return pd.ToString();
                }
                else if (destinationType == typeof (PersianDate))
                {
                    var pd = (PersianDate) value;
                    return pd;
                }
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override Boolean CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof (String) ||
                destinationType == typeof (PersianDate) ||
                destinationType == typeof (InstanceDescriptor))
                return true;

            return base.CanConvertTo(context, destinationType);
        }

        #endregion
    }
}