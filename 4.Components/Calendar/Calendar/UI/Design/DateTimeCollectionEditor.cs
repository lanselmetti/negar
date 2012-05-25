using System;
using System.ComponentModel.Design;

namespace Negar.PersianCalendar.UI.Design
{
    public class DateTimeCollectionEditor : CollectionEditor
    {
        public DateTimeCollectionEditor(Type type)
            : base(type)
        {
        }

        protected override Type CreateCollectionItemType()
        {
            return typeof (DateTime);
        }

        protected override Type[] CreateNewItemTypes()
        {
            return new[] {typeof (DateTime)};
        }

        protected override object CreateInstance(Type itemType)
        {
            var dt = (DateTime) base.CreateInstance(itemType);
            return dt;
        }
    }
}