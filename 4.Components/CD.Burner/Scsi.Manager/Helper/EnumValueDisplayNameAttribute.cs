namespace System.ComponentModel
{
	[AttributeUsage(AttributeTargets.Field)]
	public class EnumValueDisplayNameAttribute : Attribute
	{
		private string _displayName;
		public static readonly DisplayNameAttribute Default = new DisplayNameAttribute();

		public EnumValueDisplayNameAttribute() : this(string.Empty) { }
		public EnumValueDisplayNameAttribute(string displayName) { this._displayName = displayName; }
		public override bool Equals(object obj) { if (obj == this) { return true; } var attribute = obj as EnumValueDisplayNameAttribute; return ((attribute != null) && (attribute.DisplayName == this.DisplayName)); }
		public override int GetHashCode() { return this.DisplayName.GetHashCode(); }
		public override bool IsDefaultAttribute() { return this.Equals(Default); }

		public virtual string DisplayName { get { return this.DisplayNameValue; } }
		protected string DisplayNameValue { get { return this._displayName; } set { this._displayName = value; } }
	}
}