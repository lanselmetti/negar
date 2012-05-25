// ------------------------------------------------------------------
// CaptureTest
//
// History:
// 2006-March-1 HV - created
//
// Copyright (C) 2006 Hans Vosman
// ------------------------------------------------------------------
using System;
using System.Windows.Forms;
using Negar.DirectX.Capture.Manager;

namespace CaptureTest
{
	/// <summary>
	/// Summary description for AsfForm.
	/// </summary>
	public class AsfForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ComboBox AsfAvListBox1;
		private System.Windows.Forms.Button OkButton1;
		private System.Windows.Forms.Button CancelButton1;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label labelAudioInfo1;
		private System.Windows.Forms.Label labelVideoInfo1;
		private System.Windows.Forms.Label labelDescription1;
		private System.Windows.Forms.CheckBox checkBoxIndex1;

		Capture capture = null;

		public AsfForm(Capture capture)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			this.capture = capture;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(AsfForm));
			this.AsfAvListBox1 = new System.Windows.Forms.ComboBox();
			this.OkButton1 = new System.Windows.Forms.Button();
			this.CancelButton1 = new System.Windows.Forms.Button();
			this.labelAudioInfo1 = new System.Windows.Forms.Label();
			this.labelVideoInfo1 = new System.Windows.Forms.Label();
			this.labelDescription1 = new System.Windows.Forms.Label();
			this.checkBoxIndex1 = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// AsfAvListBox1
			// 
			this.AsfAvListBox1.Location = new System.Drawing.Point(8, 8);
			this.AsfAvListBox1.Name = "AsfAvListBox1";
			this.AsfAvListBox1.Size = new System.Drawing.Size(368, 21);
			this.AsfAvListBox1.TabIndex = 0;
			this.AsfAvListBox1.SelectedIndexChanged += new System.EventHandler(this.AsfAvListBox1_SelectedIndexChanged);
			// 
			// OkButton1
			// 
			this.OkButton1.Location = new System.Drawing.Point(104, 136);
			this.OkButton1.Name = "OkButton1";
			this.OkButton1.TabIndex = 1;
			this.OkButton1.Text = "OK";
			this.OkButton1.Click += new System.EventHandler(this.OkButton1_Click);
			// 
			// CancelButton1
			// 
			this.CancelButton1.Location = new System.Drawing.Point(200, 136);
			this.CancelButton1.Name = "CancelButton1";
			this.CancelButton1.TabIndex = 2;
			this.CancelButton1.Text = "Cancel";
			this.CancelButton1.Click += new System.EventHandler(this.CancelButton1_Click);
			// 
			// labelAudioInfo1
			// 
			this.labelAudioInfo1.Location = new System.Drawing.Point(8, 40);
			this.labelAudioInfo1.Name = "labelAudioInfo1";
			this.labelAudioInfo1.Size = new System.Drawing.Size(136, 16);
			this.labelAudioInfo1.TabIndex = 4;
			// 
			// labelVideoInfo1
			// 
			this.labelVideoInfo1.Location = new System.Drawing.Point(8, 64);
			this.labelVideoInfo1.Name = "labelVideoInfo1";
			this.labelVideoInfo1.Size = new System.Drawing.Size(136, 16);
			this.labelVideoInfo1.TabIndex = 5;
			// 
			// labelDescription1
			// 
			this.labelDescription1.Location = new System.Drawing.Point(8, 88);
			this.labelDescription1.Name = "labelDescription1";
			this.labelDescription1.Size = new System.Drawing.Size(368, 40);
			this.labelDescription1.TabIndex = 3;
			// 
			// checkBoxIndex1
			// 
			this.checkBoxIndex1.Checked = true;
			this.checkBoxIndex1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxIndex1.Location = new System.Drawing.Point(176, 32);
			this.checkBoxIndex1.Name = "checkBoxIndex1";
			this.checkBoxIndex1.Size = new System.Drawing.Size(56, 24);
			this.checkBoxIndex1.TabIndex = 6;
			this.checkBoxIndex1.Text = "Index";
			this.checkBoxIndex1.CheckedChanged += new System.EventHandler(this.checkBoxIndex1_CheckedChanged);
			// 
			// AsfForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(384, 166);
			this.Controls.Add(this.checkBoxIndex1);
			this.Controls.Add(this.labelVideoInfo1);
			this.Controls.Add(this.labelAudioInfo1);
			this.Controls.Add(this.labelDescription1);
			this.Controls.Add(this.CancelButton1);
			this.Controls.Add(this.OkButton1);
			this.Controls.Add(this.AsfAvListBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "AsfForm";
			this.Text = "Windows Media formats";
			this.TransparencyKey = System.Drawing.Color.WhiteSmoke;
			this.Closing += new System.ComponentModel.CancelEventHandler(this.AsfForm_Closing);
			this.Load += new System.EventHandler(this.AsfForm_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private bool formatchanged = false;
		private bool indexchanged = false;

		private void OkButton1_Click(object sender, System.EventArgs e)
		{
			// Store form data
			if(formatchanged)
			{
				if((this.AsfAvListBox1.SelectedIndex >= 0)&&
					(this.AsfAvListBox1.SelectedIndex < this.capture.AsfFormat.NbrAsfItems()))
				{
					this.capture.AsfFormat.CurrentAsfItem = this.AsfAvListBox1.SelectedIndex; // Valid index
				}

				formatchanged = false;
			}

			if(indexchanged)
			{
				this.capture.AsfFormat.UseIndex = this.checkBoxIndex1.Checked;
				indexchanged = false;
			}

			Close();
		}

		private void CancelButton1_Click(object sender, System.EventArgs e)
		{
			// Do nothing
			Close();
		}

		private void AsfForm_Load(object sender, System.EventArgs e)
		{
			if( (this.capture == null)||
				((this.capture != null)&&(this.capture.AsfFormat == null)) )
			{
				MessageBox.Show("Windows Media format module not loaded, nothing to select!");
				Close();
			}
			else
			{
				this.AsfAvListBox1.Items.Clear();

				// Load relevant form data
				for(Int32 i = 0; i < this.capture.AsfFormat.NbrAsfItems(); i++)
				{
					this.AsfAvListBox1.Items.Add(this.capture.AsfFormat[i].Name.ToString());
				}

				if((this.capture.AsfFormat.CurrentAsfItem >= 0)&&
					(this.capture.AsfFormat.CurrentAsfItem < this.capture.AsfFormat.NbrAsfItems()))
				{
					this.AsfAvListBox1.SelectedIndex = this.capture.AsfFormat.CurrentAsfItem;
					this.formatchanged = false; // reset value, will be set by previous line ...
				}

				this.checkBoxIndex1.Checked = this.capture.AsfFormat.UseIndex;
			}
		}

		private void AsfForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			capture = null;
		}

		private void AsfAvListBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// Mark selection change
			formatchanged = true;

			// Show Asf specific information
			if((this.AsfAvListBox1.SelectedIndex >= 0)&&
				(this.AsfAvListBox1.SelectedIndex < this.capture.AsfFormat.NbrAsfItems()))
			{
				this.labelDescription1.Text = this.capture.AsfFormat[this.AsfAvListBox1.SelectedIndex].Description.ToString();

				if(this.capture.AsfFormat[this.AsfAvListBox1.SelectedIndex].Audio)
				{
					Int32 bitrate = this.capture.AsfFormat[this.AsfAvListBox1.SelectedIndex].AudioBitrate/1000;
					this.labelAudioInfo1.Text = "Audio  (" + bitrate.ToString() + " kb/s)";
				} 
				else
				{
					this.labelAudioInfo1.Text = "";
				}

				if(this.capture.AsfFormat[this.AsfAvListBox1.SelectedIndex].Video)
				{
					Int32 bitrate = this.capture.AsfFormat[this.AsfAvListBox1.SelectedIndex].VideoBitrate/1000;
					if(bitrate == 0)
					{
						this.labelVideoInfo1.Text = "Video  (variable bitrate)";
					} 
					else
					{
						this.labelVideoInfo1.Text = "Video  (" + bitrate.ToString() + " kb/s)";
					}
				} 
				else
				{
					this.labelVideoInfo1.Text = "";
				}
			}
		}

		private void checkBoxIndex1_CheckedChanged(object sender, System.EventArgs e)
		{
			this.indexchanged = true;
		}
	}
}
