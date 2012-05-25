using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace BurnApp
{
	public partial class PropertyEditor : ContainerControl
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private BorderStyle _BorderStyle = BorderStyle.None;
		private readonly int VSCROLL_BAR_WIDTH = new VScrollBar() { }.Width;
		private object _SelectedObject;
		private ToolTip toolTip = new ToolTip() { };

		public PropertyEditor() : base() { this.AutoScroll = true; }

		[EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public override bool AutoSize { get { return base.AutoSize; } set { base.AutoSize = value; } }
 
		[DefaultValue(BorderStyle.None), RefreshProperties(RefreshProperties.Repaint)]
		public BorderStyle BorderStyle { get { return this._BorderStyle; } set { this._BorderStyle = value; } }

		private static long EnumToLong(Enum value) { return Convert.ToInt64(value); }

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams createParams = base.CreateParams;
				switch (this.BorderStyle)
				{
					case BorderStyle.FixedSingle:
						createParams.Style |= 0x800000;
						break;
					case BorderStyle.Fixed3D:
						createParams.ExStyle |= 0x200;
						break;
				}
				//createParams.ExStyle |= 0x00000200 /*WS_EX_CLIENTEDGE*/;
				return createParams;
			}
		}

		[DefaultValue(null)]
		public object SelectedObject
		{
			get { return this._SelectedObject; }
			set
			{
				Control c;
				if (value != null)
				{
					c = this.Populate(value, false);
					try { Program.SetProperty(c, "DoubleBuffered", true, true); }
					catch { }
					c.Size = c.GetPreferredSize(this.ClientSize);
					c.CreateControl();
				}
				else { c = null; }
				this._SelectedObject = null;
				while (this.Controls.Count > 0)
				{
					int i = this.Controls.Count - 1;
					var ctrl = this.Controls[i];
					this.Controls.RemoveAt(i);
					ctrl.Dispose();
				}
				if (c != null)
				{
					this.Controls.Add(c);
				}
				this._SelectedObject = value;
			}
		}

		private class EnumValue
		{
			public EnumValue(FieldInfo enumField)
			{
				var displayName = (EnumValueDisplayNameAttribute)Attribute.GetCustomAttribute(enumField, typeof(EnumValueDisplayNameAttribute));
				this.Text = displayName != null ? displayName.DisplayName : enumField.Name;
				var da = (DescriptionAttribute)Attribute.GetCustomAttribute(enumField, typeof(DescriptionAttribute));
				this.Description = da != null ? da.Description : null;
				this.Value = (Enum)enumField.GetValue(null);
			}

			public readonly string Text;
			public readonly string Description;
			public readonly Enum Value;
			public override string ToString() { return this.Text; }
			public override int GetHashCode() { return this.Value.GetHashCode(); }
			public override bool Equals(object obj) { return obj is EnumValue && ((EnumValue)obj).Value.Equals(this.Value); }
		}

		private class ArrayElement
		{
			public static readonly PropertyInfo ItemProperty = typeof(ArrayElement).GetProperty("Item");

			public ArrayElement(Array array, int[] indices)
			{
				this.Array = array;
				this.Indices = indices;
			}

			public Array Array { get; set; }
			public int[] Indices { get; set; }
			[DisplayName("Item")]
			public object Item { get { return this.Array.GetValue(this.Indices); } set { this.Array.SetValue(value, this.Indices); } }
		}

		private void ShowCommitError(string propertyText, object newValue, Exception ex)
		{
			if (ex is TargetInvocationException) { ex = ((TargetInvocationException)ex).InnerException; }
			MessageBox.Show(this, string.Format("Invalid value for {0}." + Environment.NewLine + "{1}", propertyText, ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private Control Populate(object obj, bool readOnly)
		{
			var tbl = new TableLayoutPanel()
			{
				AutoScroll = true,
				AutoSize = true,
				AutoSizeMode = AutoSizeMode.GrowAndShrink,
#if DEBUG
				CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset,
#endif
				//Dock = DockStyle.Fill,
				RowCount = 1,
				ColumnCount = 2,
				Margin = new Padding(0),
				Padding = new Padding(0),
			};
			tbl.SuspendLayout();
			try
			{
				tbl.ColumnStyles.Clear();
				while (tbl.ColumnStyles.Count < tbl.ColumnCount) { tbl.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize)); }

				var type = obj.GetType();
				var properties = new List<PropertyInfo>(128);
				GetProperties(type, properties);
				foreach (var property in properties)
				{
					var browsable = (BrowsableAttribute)Attribute.GetCustomAttribute(property, typeof(BrowsableAttribute));
					if (browsable == null || browsable.Browsable)
					{
						if (property.GetIndexParameters().Length == 0)
						{
							var val = property.GetValue(obj, null);
							this.Populate(tbl, obj, property, property.PropertyType, val, readOnly);
						}
					}
				}
				tbl.RowStyles.Clear();
				while (tbl.RowStyles.Count < tbl.RowCount) { tbl.RowStyles.Add(new RowStyle(SizeType.AutoSize)); }
			}
			finally { tbl.ResumeLayout(false); }
			return tbl;
		}

		private void Populate(TableLayoutPanel tbl, object obj, PropertyInfo property, Type propertyType, object value, bool readOnly)
		{
			var displayName = (DisplayNameAttribute)Attribute.GetCustomAttribute(property, typeof(DisplayNameAttribute));
			string name = displayName != null ? displayName.DisplayName : property.Name;

			var descriptionAttribute = (DescriptionAttribute)Attribute.GetCustomAttribute(property, typeof(DescriptionAttribute));
			string description = descriptionAttribute != null ? descriptionAttribute.Description : null;

			bool canWrite = !readOnly && property.CanWrite && property.GetSetMethod() != null && property.GetSetMethod().IsPublic;

			var readOnlyAttribute = (ReadOnlyAttribute)Attribute.GetCustomAttribute(property, typeof(ReadOnlyAttribute));
			if (readOnlyAttribute != null) { canWrite &= !readOnlyAttribute.IsReadOnly; }

			if (property.CanRead)
			{
				if (propertyType == typeof(bool))
				{
					var chk = new CheckBox()
					{
						CausesValidation = true,
						Checked = (bool)value,
						AutoCheck = canWrite,
						AutoSize = true,
						AutoEllipsis = true,
						Enabled = canWrite,
						Padding = new Padding(3, 0, 3, 0),
						Text = name,
					};
					this.toolTip.SetToolTip(chk, description);
					chk.CheckedChanged += (s, e) =>
					{
						var newState = chk.Checked;
						var oldState = !(bool)newState;
						try
						{
							property.SetValue(obj, newState, null);
							chk.Checked = (bool)newState;
						}
						catch (Exception ex)
						{
							chk.Checked = oldState;
							this.ShowCommitError(chk.Text, newState, ex);
						}
					};
					tbl.Controls.Add(chk);
					tbl.SetColumnSpan(chk, tbl.GetColumnSpan(chk) + 1);
				}
				else
				{
					if (Nullable.GetUnderlyingType(propertyType) != null)
					{
						var underlyingType = Nullable.GetUnderlyingType(propertyType);
						var val = property.GetValue(obj, null);
						var valOrDefault = val;
						if (valOrDefault == null) { valOrDefault = Activator.CreateInstance(underlyingType); }
						var populated = this.Populate(valOrDefault, readOnly || !canWrite);

						var chk = new CheckBox()
						{
							Checked = val != null,
							CausesValidation = true,
							AutoSize = true,
							AutoEllipsis = true,
							Enabled = canWrite,
							Text = name,
						};
						this.toolTip.SetToolTip(chk, description);
						chk.Validating += (s, e) =>
						{ throw new NotImplementedException("Nullable properties not implemented."); };

						tbl.Controls.Add(chk);
						tbl.Controls.Add(populated);
					}
					else
					{
						var label = new Label() //This is not a label since labels don't show tooltips easily
						{
							BorderStyle = BorderStyle.None,
							AutoSize = true,
							//ReadOnly = true,
							//Padding = new Padding(0, 7, 0, 0),
							//Margin = new Padding(3, 7, 0, 0),
							Padding = new Padding(0, 6, 0, 6),
							Text = string.Format("{0}:", name),
							Cursor = Cursors.Default, //Simulate a label
							Dock = DockStyle.Fill,
							ForeColor = SystemColors.ControlText,
							ContextMenu = new ContextMenu(),
							TabStop = false,
						};
						this.toolTip.SetToolTip(label, description);
						tbl.Controls.Add(label);

						Control control;
						if (propertyType == typeof(byte) | propertyType == typeof(ushort)
							| propertyType == typeof(uint) | propertyType == typeof(ulong)
							| propertyType == typeof(sbyte) | propertyType == typeof(short)
							| propertyType == typeof(int) | propertyType == typeof(long)
							| propertyType == typeof(float) | propertyType == typeof(double) | propertyType == typeof(decimal))
						{
							var nud = new NumericUpDown()
							{
								AutoSize = true,
								Maximum = Convert.ToDecimal(propertyType.GetField("MaxValue").GetRawConstantValue()),
								Minimum = Convert.ToDecimal(propertyType.GetField("MinValue").GetRawConstantValue()),
								Value = Convert.ToDecimal(value),
								//TextAlign = HorizontalAlignment.Right,
								ThousandsSeparator = true,
								ReadOnly = !canWrite,
								//Enabled = canWrite,
								Dock = DockStyle.None,
							};
							if (nud.ReadOnly) { nud.ValueChanged += (s, e) => { nud.Value = Convert.ToDecimal(value); }; }
							this.toolTip.SetToolTip(nud, description);
							nud.ValueChanged += (s, e) =>
							{
								var oldState = Convert.ToDecimal(property.GetValue(obj, null));
								var newState = Convert.ChangeType(nud.Value, propertyType);
								try
								{
									property.SetValue(obj, newState, null);

									//Get the REAL new value, not the one the user entered
									nud.Value = Convert.ToDecimal(property.GetValue(obj, null));
								}
								catch (Exception ex)
								{
									nud.Value = oldState;
									this.ShowCommitError(label.Text, newState, ex);
								}
							};
							control = nud;
						}
						else if ((propertyType == typeof(string) | propertyType == typeof(StringBuilder)))
						{
							if (value == null) { value = string.Empty; }
							var txt = new TextBox()
							{
								ReadOnly = !canWrite,
								Text = value.ToString(),
							};
							this.toolTip.SetToolTip(txt, description);
							txt.Validated += (s, e) =>
							{
								var oldState = property.GetValue(obj, null);
								if (oldState == null) { oldState = string.Empty; }
								string oldText = oldState.ToString();
								var newState = txt.Text;
								if (oldText != newState)
								{
									try { property.SetValue(obj, newState.ToString(), null); }
									catch (Exception ex)
									{
										txt.Text = oldState.ToString();
										this.ShowCommitError(label.Text, newState, ex);
									}
								}
							};
							control = txt;
						}
						else if (propertyType.IsEnum)
						{
							if (Attribute.GetCustomAttribute(propertyType, typeof(FlagsAttribute)) != null)
							{
								var lb = new ListBox()
								{
									Dock = DockStyle.Fill,
									Enabled = canWrite,
									SelectionMode = SelectionMode.MultiExtended,
								};
								int maxMeasure = 0;
								EnumValue[] values;
								{
									var enumValues = Enum.GetValues(propertyType);
									values = new EnumValue[enumValues.Length];
									for (int i = 0; i < enumValues.Length; i++)
									{
										var field = propertyType.GetField(enumValues.GetValue(i).ToString());
										values[i] = new EnumValue(field);
										maxMeasure = Math.Max(maxMeasure, TextRenderer.MeasureText(values[i].Text, lb.Font).Width);
									}
								}
								lb.Width = maxMeasure + VSCROLL_BAR_WIDTH;
								var lValue = EnumToLong((Enum)value);
								int maxWidth = -1;
								for (int i = 0; i < values.Length; i++)
								{
									var v = values[i];
									var flag = Convert.ToInt64(v.Value);
									lb.Items.Add(v);
									var textSize = TextRenderer.MeasureText(v.Text, lb.Font);
									maxWidth = Math.Max(maxWidth, textSize.Width);
									if ((flag & lValue) == flag) { lb.SelectedIndices.Add(i); }
								}
								lb.ClientSize = new Size(maxWidth != -1 ? maxWidth : lb.ClientSize.Width, lb.ItemHeight * lb.Items.Count);
								var selected = new int[lb.SelectedIndices.Count];
								lb.SelectedIndices.CopyTo(selected, 0);
								lb.Validating += (s, e) =>
								{
									var flagValue = EnumToLong((Enum)Enum.ToObject(propertyType, 0));
									for (int i = 0; i < lb.SelectedItems.Count; i++)
									{
										var item = (EnumValue)lb.SelectedItems[i];
										flagValue |= EnumToLong(item.Value);
									}
									property.SetValue(obj, Enum.ToObject(propertyType, flagValue), null);
								};
								control = lb;
							}
							else
							{
								var cmb = new ComboBox()
								{
									Enabled = canWrite,
									DropDownStyle = ComboBoxStyle.DropDownList,
									DropDownHeight = int.MaxValue,
									//Dock = DockStyle.Fill,
								};

								int maxMeasure = 0;
								EnumValue[] values;
								{
									var enumValues = Enum.GetValues(propertyType);
									values = new EnumValue[enumValues.Length];
									for (int i = 0; i < enumValues.Length; i++)
									{
										var field = value.GetType().GetField(enumValues.GetValue(i).ToString());
										values[i] = new EnumValue(field);
										maxMeasure = Math.Max(maxMeasure, TextRenderer.MeasureText(values[i].Text, cmb.Font).Width);
									}
								}

								this.toolTip.SetToolTip(cmb, description);
								cmb.Items.AddRange(values);
								cmb.SelectionChangeCommitted += (s, e) =>
								{
									var val = property.GetValue(obj, null);
									var oldState = new EnumValue(val.GetType().GetField(val.ToString()));
									var newState = (EnumValue)cmb.SelectedItem;
									try
									{
										property.SetValue(obj, newState.Value, null);
										cmb.SelectedItem = newState;
									}
									catch (Exception ex)
									{
										cmb.SelectedItem = oldState;
										this.ShowCommitError(label.Text, newState, ex);
									}
									this.toolTip.SetToolTip(cmb, ((EnumValue)cmb.SelectedItem).Description);
								};
								for (int i = 0; i < values.Length; i++)
								{
									if (values[i].Value.Equals(value))
									{
										cmb.SelectedItem = values[i];
										this.toolTip.SetToolTip(cmb, values[i].Description);
										break;
									}
								}
								cmb.SelectedIndexChanged += (s, e) =>
								{
								};

								cmb.Width = maxMeasure + cmb.Height; //Assume drop-down button is square
								control = cmb;
							}
						}
						else if (propertyType.IsArray)
						{
							var values = (Array)property.GetValue(obj, null);
							var tlp = new TableLayoutPanel()
							{
								AutoSize = true,
								AutoSizeMode = AutoSizeMode.GrowAndShrink,
#if DEBUG
								CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset,
#endif
								//Dock = DockStyle.None,
								AutoScroll = true,
								Margin = new Padding(0),
								ColumnCount = 2,
								RowCount = values.Length,
								Padding = new Padding(0),
							};
							tlp.ColumnStyles.Clear();
							while (tlp.ColumnStyles.Count < tlp.ColumnCount)
							{
								tlp.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
							}
							tlp.RowStyles.Clear();
							for (int i = 0; i < values.Length; i++) { tlp.RowStyles.Add(new RowStyle(SizeType.AutoSize)); }
							for (int i = 0; i < values.Length; i++) { this.Populate(tlp, new ArrayElement(values, new int[] { i }), ArrayElement.ItemProperty, propertyType.GetElementType(), values.GetValue(i), readOnly || !canWrite); }
							control = tlp;
						}
						else
						{
							control = this.Populate(property.GetValue(obj, null), readOnly || !canWrite);
						}

						tbl.Controls.Add(control);
					}
				}

			}
		}

		private static void GetProperties(Type type, List<PropertyInfo> props)
		{
			if (type.BaseType != null) { GetProperties(type.BaseType, props); }
			props.AddRange(type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly));
		}
	}
}