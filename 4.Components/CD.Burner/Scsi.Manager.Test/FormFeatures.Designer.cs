namespace BurnApp
{
	partial class FormFeatures
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.cmbFeatures = new System.Windows.Forms.ComboBox();
			this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.peFeature = new BurnApp.PropertyEditor();
			this.tlpMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmbFeatures
			// 
			this.cmbFeatures.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cmbFeatures.DropDownHeight = 0xFFFF;
			this.cmbFeatures.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbFeatures.FormattingEnabled = true;
			this.cmbFeatures.IntegralHeight = false;
			this.cmbFeatures.Location = new System.Drawing.Point(15, 15);
			this.cmbFeatures.Name = "cmbFeatures";
			this.cmbFeatures.Size = new System.Drawing.Size(602, 21);
			this.cmbFeatures.TabIndex = 1;
			this.cmbFeatures.SelectedIndexChanged += new System.EventHandler(this.cmbFeatures_SelectedIndexChanged);
			// 
			// tlpMain
			// 
			this.tlpMain.ColumnCount = 1;
			this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpMain.Controls.Add(this.cmbFeatures, 0, 0);
			this.tlpMain.Controls.Add(this.peFeature, 0, 1);
			this.tlpMain.Controls.Add(this.label1, 0, 2);
			this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpMain.Location = new System.Drawing.Point(0, 0);
			this.tlpMain.Name = "tlpMain";
			this.tlpMain.Padding = new System.Windows.Forms.Padding(12);
			this.tlpMain.RowCount = 3;
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpMain.Size = new System.Drawing.Size(632, 633);
			this.tlpMain.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(15, 602);
			this.label1.Name = "label1";
			this.label1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.label1.Size = new System.Drawing.Size(316, 19);
			this.label1.TabIndex = 3;
			this.label1.Text = "Note: If a feature is not listed, then it is not supported by the drive.";
			// 
			// peFeature
			// 
			this.peFeature.AutoScroll = true;
			this.peFeature.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.peFeature.Dock = System.Windows.Forms.DockStyle.Fill;
			this.peFeature.Location = new System.Drawing.Point(15, 42);
			this.peFeature.Name = "peFeature";
			this.peFeature.Padding = new System.Windows.Forms.Padding(3);
			this.peFeature.Size = new System.Drawing.Size(602, 557);
			this.peFeature.TabIndex = 2;
			// 
			// FormFeatures
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(632, 633);
			this.Controls.Add(this.tlpMain);
			this.Name = "FormFeatures";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Features";
			this.tlpMain.ResumeLayout(false);
			this.tlpMain.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox cmbFeatures;
		private PropertyEditor peFeature;
		private System.Windows.Forms.TableLayoutPanel tlpMain;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.Label label1;
	}
}