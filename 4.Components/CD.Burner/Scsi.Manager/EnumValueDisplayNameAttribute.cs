namespace System.ComponentModel
{
    [AttributeUsage(AttributeTargets.Field)]
    public class EnumValueDisplayNameAttribute : Attribute
    {
        public static readonly DisplayNameAttribute Default = new DisplayNameAttribute();

        public EnumValueDisplayNameAttribute() : this(string.Empty)
        {
        }

        public EnumValueDisplayNameAttribute(string displayName)
        {
            DisplayNameValue = displayName;
        }

        public virtual string DisplayName
        {
            get { return DisplayNameValue; }
        }

        protected string DisplayNameValue { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == this)
            {
                return true;
            }
            var attribute = obj as EnumValueDisplayNameAttribute;
            return ((attribute != null) && (attribute.DisplayName == DisplayName));
        }

        public override int GetHashCode()
        {
            return DisplayName.GetHashCode();
        }

        public override bool IsDefaultAttribute()
        {
            return Equals(Default);
        }
    }
}