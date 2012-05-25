using System;
using System.Windows.Forms;
using Scsi.Multimedia;
using System.ComponentModel;
using System.Reflection;

namespace BurnApp
{
	public partial class FormFeatures : Form
	{
		public FormFeatures()
		{
			this.InitializeComponent();
			//Program.SetProperty(this, "Font", System.Drawing.SystemFonts.DialogFont, true);
		}

		public FeatureCollection SelectedObject
		{
			set
			{
				this.peFeature.SelectedObject = null;
				this.cmbFeatures.Items.Clear();
				if (value != null)
				{
					for (int i = 0; i < value.Count; i++)
					{
						var feature = value[i];
						string text = feature.FeatureCode.ToString();
						var field = typeof(FeatureCode).GetField(feature.FeatureCode.ToString(), BindingFlags.Static | BindingFlags.Public);
						if (field != null)
						{
							var att = (EnumValueDisplayNameAttribute)Attribute.GetCustomAttribute(field, typeof(EnumValueDisplayNameAttribute));
							if (att != null && !string.IsNullOrEmpty(att.DisplayName)) { text = att.DisplayName; }
						}
						var description = (DescriptionAttribute)Attribute.GetCustomAttribute(feature.GetType(), typeof(DescriptionAttribute), false);
						this.cmbFeatures.Items.Add(new ValueWithDescription(feature, string.Format("({0:D}) {1}", feature.FeatureCode, text), description != null ? description.Description : null));
					}
					this.RefreshItem();
				}
				this.cmbFeatures.SelectedIndex = value != null && value.Count > 0 ? 0 : -1;
			}
		}

		private void cmbFeatures_SelectedIndexChanged(object sender, EventArgs e) { this.RefreshItem(); }

		private void RefreshItem()
		{
			using (var cursor = new CursorChange(this, Cursors.WaitCursor))
			{
				this.toolTip.Hide(this.cmbFeatures);
				var val = this.cmbFeatures.SelectedItem != null ? (ValueWithDescription)this.cmbFeatures.SelectedItem : default(ValueWithDescription);
				this.peFeature.SelectedObject = val.Value;
				this.toolTip.SetToolTip(this.cmbFeatures, val.Description);
			}
		}
	}
}