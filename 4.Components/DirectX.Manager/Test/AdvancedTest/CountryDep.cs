using System;
// ------------------------------------------------------------------
// Negar.DirectX.Capture.Manager
//
// History:
//	2009-Feb-27	HV		- created
//
// This form is added to inform the user to initialize the Tuner settings
// properly. Incorrect settings may cause non-functional TV video/audio.
//
// Copyright (C) 2009 Hans Vosman
// ------------------------------------------------------------------

using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Negar.DirectX.Capture.Manager;
using Negar.DirectShow.Manager;

namespace CaptureTest
{
	/// <summary>
	/// Summary description for CountryDep.
	/// </summary>
	public class CountryDep : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label labelCountryCode1;
		private System.Windows.Forms.TextBox textCountryCode1;
		private System.Windows.Forms.Label labelTuningSpace1;
		private System.Windows.Forms.TextBox textTuningSpace1;
		private System.Windows.Forms.Label labelVideoStandard1;
		private System.Windows.Forms.ComboBox listboxVideoStandard1;
		private System.Windows.Forms.Label labelDefaultTvChannel1;
		private System.Windows.Forms.Label labelInputType1;
		private System.Windows.Forms.ComboBox listboxInputType1;
		private System.Windows.Forms.Button buttonOK1;
		private System.Windows.Forms.Button buttonCancel1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private Capture capture = null;
		private Int32 defaultChannel = 0;
		private Int32 defaultTuningSpace = 0;
		private TunerInputType defaultInputType = TunerInputType.Cable;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private Int32 defaultCountryCode = 0;

		/// <summary>
		/// Local capture variable
		/// </summary>
#if VS2003
		public Capture Capture
#else
        public new Capture Capture
#endif
		{
			set { this.capture = value; }
		}

		public Int32 DefaultChannel
		{
			get { return this.defaultChannel; }
			set { this.defaultChannel = value; }
		}

		public Int32 DefaultTuningSpace
		{
			get { return this.defaultTuningSpace; }
			set { this.defaultTuningSpace = value; }
		}

		public Int32 DefaultCountryCode
		{
			get { return this.defaultCountryCode; }
			set { this.defaultCountryCode = value; }
		}

		public TunerInputType DefaultInputType
		{
			get { return this.defaultInputType; }
			set { this.defaultInputType = value; }
		}

		public CountryDep()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			this.labelCountryCode1 = new System.Windows.Forms.Label();
			this.textCountryCode1 = new System.Windows.Forms.TextBox();
			this.labelTuningSpace1 = new System.Windows.Forms.Label();
			this.textTuningSpace1 = new System.Windows.Forms.TextBox();
			this.labelVideoStandard1 = new System.Windows.Forms.Label();
			this.listboxVideoStandard1 = new System.Windows.Forms.ComboBox();
			this.labelDefaultTvChannel1 = new System.Windows.Forms.Label();
			this.labelInputType1 = new System.Windows.Forms.Label();
			this.listboxInputType1 = new System.Windows.Forms.ComboBox();
			this.buttonOK1 = new System.Windows.Forms.Button();
			this.buttonCancel1 = new System.Windows.Forms.Button();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.SuspendLayout();
			// 
			// labelCountryCode1
			// 
			this.labelCountryCode1.Location = new System.Drawing.Point(8, 8);
			this.labelCountryCode1.Name = "labelCountryCode1";
			this.labelCountryCode1.Size = new System.Drawing.Size(80, 24);
			this.labelCountryCode1.TabIndex = 0;
			this.labelCountryCode1.Text = "Country code:";
			// 
			// textCountryCode1
			// 
			this.textCountryCode1.Location = new System.Drawing.Point(96, 8);
			this.textCountryCode1.Name = "textCountryCode1";
			this.textCountryCode1.Size = new System.Drawing.Size(40, 20);
			this.textCountryCode1.TabIndex = 1;
			this.textCountryCode1.Text = "31";
			// 
			// labelTuningSpace1
			// 
			this.labelTuningSpace1.Location = new System.Drawing.Point(8, 32);
			this.labelTuningSpace1.Name = "labelTuningSpace1";
			this.labelTuningSpace1.Size = new System.Drawing.Size(88, 16);
			this.labelTuningSpace1.TabIndex = 2;
			this.labelTuningSpace1.Text = "Tuning Space:";
			// 
			// textTuningSpace1
			// 
			this.textTuningSpace1.Location = new System.Drawing.Point(96, 32);
			this.textTuningSpace1.Name = "textTuningSpace1";
			this.textTuningSpace1.Size = new System.Drawing.Size(40, 20);
			this.textTuningSpace1.TabIndex = 3;
			this.textTuningSpace1.Text = "0";
			// 
			// labelVideoStandard1
			// 
			this.labelVideoStandard1.Location = new System.Drawing.Point(200, 40);
			this.labelVideoStandard1.Name = "labelVideoStandard1";
			this.labelVideoStandard1.Size = new System.Drawing.Size(88, 16);
			this.labelVideoStandard1.TabIndex = 4;
			this.labelVideoStandard1.Text = "Video Standard:";
			// 
			// listboxVideoStandard1
			// 
			this.listboxVideoStandard1.Location = new System.Drawing.Point(304, 32);
			this.listboxVideoStandard1.Name = "listboxVideoStandard1";
			this.listboxVideoStandard1.Size = new System.Drawing.Size(80, 21);
			this.listboxVideoStandard1.TabIndex = 6;
			// 
			// labelDefaultTvChannel1
			// 
			this.labelDefaultTvChannel1.Location = new System.Drawing.Point(200, 8);
			this.labelDefaultTvChannel1.Name = "labelDefaultTvChannel1";
			this.labelDefaultTvChannel1.Size = new System.Drawing.Size(112, 16);
			this.labelDefaultTvChannel1.TabIndex = 7;
			this.labelDefaultTvChannel1.Text = "Default TV channel:";
			// 
			// labelInputType1
			// 
			this.labelInputType1.Location = new System.Drawing.Point(8, 56);
			this.labelInputType1.Name = "labelInputType1";
			this.labelInputType1.Size = new System.Drawing.Size(72, 16);
			this.labelInputType1.TabIndex = 9;
			this.labelInputType1.Text = "Input Type:";
			// 
			// listboxInputType1
			// 
			this.listboxInputType1.Location = new System.Drawing.Point(96, 56);
			this.listboxInputType1.Name = "listboxInputType1";
			this.listboxInputType1.Size = new System.Drawing.Size(88, 21);
			this.listboxInputType1.TabIndex = 10;
			// 
			// buttonOK1
			// 
			this.buttonOK1.Location = new System.Drawing.Point(304, 58);
			this.buttonOK1.Name = "buttonOK1";
			this.buttonOK1.TabIndex = 11;
			this.buttonOK1.Text = "OK";
			this.buttonOK1.Click += new System.EventHandler(this.buttonOK1_Click);
			// 
			// buttonCancel1
			// 
			this.buttonCancel1.Location = new System.Drawing.Point(216, 58);
			this.buttonCancel1.Name = "buttonCancel1";
			this.buttonCancel1.TabIndex = 12;
			this.buttonCancel1.Text = "Cancel";
			this.buttonCancel1.Click += new System.EventHandler(this.buttonCancel1_Click);
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(304, 8);
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(80, 20);
			this.numericUpDown1.TabIndex = 13;
			// 
			// CountryDep
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(392, 86);
			this.Controls.Add(this.numericUpDown1);
			this.Controls.Add(this.buttonCancel1);
			this.Controls.Add(this.buttonOK1);
			this.Controls.Add(this.listboxInputType1);
			this.Controls.Add(this.labelInputType1);
			this.Controls.Add(this.labelDefaultTvChannel1);
			this.Controls.Add(this.listboxVideoStandard1);
			this.Controls.Add(this.labelVideoStandard1);
			this.Controls.Add(this.textTuningSpace1);
			this.Controls.Add(this.labelTuningSpace1);
			this.Controls.Add(this.textCountryCode1);
			this.Controls.Add(this.labelCountryCode1);
			this.Name = "CountryDep";
			this.Text = "CaptureTest country specific settings";
			this.Load += new System.EventHandler(this.CountryDep_Load);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void buttonOK1_Click(object sender, System.EventArgs e)
		{
			// Accept settings
			if(this.capture != null)
			{
				if(this.capture.dxUtils != null)
				{
					if(this.capture.dxUtils.VideoDecoderAvail)
					{
						try
						{
							AnalogVideoStandard a = (AnalogVideoStandard) Enum.Parse(typeof(AnalogVideoStandard), this.listboxVideoStandard1.Text);
							this.capture.dxUtils.VideoStandard = a;
						}
						catch
						{
							this.capture.dxUtils.VideoStandard = AnalogVideoStandard.None;
						}
					}
					else
					{
						this.capture.dxUtils.VideoStandard = AnalogVideoStandard.None;
					}
				}

				if(this.capture.Tuner != null)
				{
					if(this.listboxInputType1.Text == TunerInputType.Cable.ToString())
					{
						this.capture.Tuner.InputType = TunerInputType.Cable;
					}
					else
					{
						this.capture.Tuner.InputType = TunerInputType.Antenna;
					}
					try
					{
						this.defaultTuningSpace = Convert.ToInt32(this.textTuningSpace1.Text, 10);
					}
					catch {};
					try
					{
						this.defaultCountryCode = Convert.ToInt32(this.textCountryCode1.Text, 10);
					}
					catch {};
					this.capture.Tuner.TuningSpace = this.defaultTuningSpace;
					this.capture.Tuner.CountryCode = this.defaultCountryCode;
					this.defaultChannel = (Int32)this.numericUpDown1.Value;
					this.capture.Tuner.Channel = this.defaultChannel;
				}
			}
			Close();
		}

		private void buttonCancel1_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		private void CountryDep_Load(object sender, System.EventArgs e)
		{
			this.listboxInputType1.Enabled = false;
			this.listboxVideoStandard1.Enabled = false;
			this.numericUpDown1.Enabled = false;

			// Allow change
			this.textCountryCode1.Enabled = true;
			this.textTuningSpace1.Enabled = true;

			if(this.capture == null)
			{
				return; // Nothing to do
			}

			if((this.capture.dxUtils == null)&&(this.capture.Tuner != null))
			{
				return; // Nothing to do
			}

			this.listboxVideoStandard1.Items.Clear();
			if(this.capture.dxUtils != null)
			{
				AnalogVideoStandard currentStandard = this.capture.dxUtils.VideoStandard;
				AnalogVideoStandard availableStandards = this.capture.dxUtils.AvailableVideoStandards;
				Int32 mask = 1;
				Int32 item = 0;
				Int32 curritem = -1;
				while(mask <= (Int32)AnalogVideoStandard.PAL_N_COMBO)
				{
					Int32 avs = mask & (Int32)availableStandards;
					if(avs != 0)
					{
						this.listboxVideoStandard1.Items.Add(((AnalogVideoStandard)avs).ToString());
						if(currentStandard == (AnalogVideoStandard)avs)
						{
							curritem = item;
						}
						item++;
					}
					mask *= 2;
				}
				this.listboxVideoStandard1.Enabled = (this.listboxVideoStandard1.Items.Count > 1);
				if(curritem >= 0)
				{
					this.listboxVideoStandard1.SelectedIndex = curritem;
				}
				else
				{
					if(this.listboxVideoStandard1.Items.Count > 0)
					{
						this.listboxVideoStandard1.SelectedIndex = 0;
					}
				}
			}

			this.listboxInputType1.Items.Clear();
			this.listboxInputType1.Items.Add(TunerInputType.Cable.ToString());
			this.listboxInputType1.Items.Add(TunerInputType.Antenna.ToString());
			if(this.capture.Tuner != null)
			{
				if(this.capture.Tuner.InputType == TunerInputType.Cable)
				{
					this.listboxInputType1.SelectedIndex = 0;
				}
				else
				{
					this.listboxInputType1.SelectedIndex = 1;
				}
				this.listboxInputType1.Enabled = true;

				Int32[] minmax = new Int32[2];
				minmax = this.capture.Tuner.ChanelMinMax;
				this.numericUpDown1.Maximum = minmax[1];
				this.numericUpDown1.Minimum = minmax[0];
				this.numericUpDown1.Increment = 1;
				if(this.defaultChannel < minmax[0])
				{
					this.defaultChannel = minmax[0];
				}
				if(this.defaultChannel > minmax[1])
				{
					this.defaultChannel = minmax[1];
				}
				this.numericUpDown1.Value = this.defaultChannel;
				this.numericUpDown1.Enabled = true;
			}
		}
	}
}
