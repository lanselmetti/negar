namespace BurnApp
{
	partial class FormStartBurn
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.Label lblWriteType;
			System.Windows.Forms.Label lblWriteSpeed;
			System.Windows.Forms.Label lblDataBlockType;
			System.Windows.Forms.Label lblBufferSizeLabel;
			System.Windows.Forms.Label lblCurrentDiscLabel;
			System.Windows.Forms.Label lblCapacityLabel;
			System.Windows.Forms.Label lblDiscStatusLabel;
			System.Windows.Forms.Label lblSessionLabel;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStartBurn));
			this.ttpInfo = new System.Windows.Forms.ToolTip(this.components);
			this.chkEmbedFiles = new System.Windows.Forms.CheckBox();
			this.chkFindDuplicates = new System.Windows.Forms.CheckBox();
			this.chkFinalize = new System.Windows.Forms.CheckBox();
			this.cmbWriteSpeed = new System.Windows.Forms.ComboBox();
			this.cmbWriteType = new System.Windows.Forms.ComboBox();
			this.cmbDataBlockType = new System.Windows.Forms.ComboBox();
			this.txtDiscCapacity = new System.Windows.Forms.TextBox();
			this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
			this.flpButtons = new System.Windows.Forms.FlowLayoutPanel();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.lblCurrentDisc = new System.Windows.Forms.Label();
			this.lblDiscStatus = new System.Windows.Forms.Label();
			this.lblSessions = new System.Windows.Forms.Label();
			this.chkBufferUnderrunProtection = new System.Windows.Forms.CheckBox();
			this.chkSimulation = new System.Windows.Forms.CheckBox();
			this.lnkPrefixHelp = new System.Windows.Forms.LinkLabel();
			this.tbBufferSize = new System.Windows.Forms.TrackBar();
			this.lblBufferSize = new System.Windows.Forms.Label();
			this.tmrRefresh = new System.Windows.Forms.Timer(this.components);
			lblWriteType = new System.Windows.Forms.Label();
			lblWriteSpeed = new System.Windows.Forms.Label();
			lblDataBlockType = new System.Windows.Forms.Label();
			lblBufferSizeLabel = new System.Windows.Forms.Label();
			lblCurrentDiscLabel = new System.Windows.Forms.Label();
			lblCapacityLabel = new System.Windows.Forms.Label();
			lblDiscStatusLabel = new System.Windows.Forms.Label();
			lblSessionLabel = new System.Windows.Forms.Label();
			this.tlpMain.SuspendLayout();
			this.flpButtons.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbBufferSize)).BeginInit();
			this.SuspendLayout();
			// 
			// lblWriteType
			// 
			lblWriteType.AutoEllipsis = true;
			lblWriteType.AutoSize = true;
			lblWriteType.Location = new System.Drawing.Point(19, 118);
			lblWriteType.Margin = new System.Windows.Forms.Padding(3, 6, 0, 6);
			lblWriteType.Name = "lblWriteType";
			lblWriteType.Size = new System.Drawing.Size(58, 13);
			lblWriteType.Text = "Write type:";
			// 
			// lblWriteSpeed
			// 
			lblWriteSpeed.AutoEllipsis = true;
			lblWriteSpeed.AutoSize = true;
			lblWriteSpeed.Location = new System.Drawing.Point(19, 91);
			lblWriteSpeed.Margin = new System.Windows.Forms.Padding(3, 6, 0, 6);
			lblWriteSpeed.Name = "lblWriteSpeed";
			lblWriteSpeed.Size = new System.Drawing.Size(67, 13);
			lblWriteSpeed.Text = "Write speed:";
			// 
			// lblDataBlockType
			// 
			lblDataBlockType.AutoEllipsis = true;
			lblDataBlockType.AutoSize = true;
			lblDataBlockType.Location = new System.Drawing.Point(19, 145);
			lblDataBlockType.Margin = new System.Windows.Forms.Padding(3, 6, 0, 6);
			lblDataBlockType.Name = "lblDataBlockType";
			lblDataBlockType.Size = new System.Drawing.Size(85, 13);
			lblDataBlockType.Text = "Data block type:";
			// 
			// lblBufferSizeLabel
			// 
			lblBufferSizeLabel.AutoEllipsis = true;
			lblBufferSizeLabel.AutoSize = true;
			lblBufferSizeLabel.Location = new System.Drawing.Point(19, 172);
			lblBufferSizeLabel.Margin = new System.Windows.Forms.Padding(3, 6, 0, 6);
			lblBufferSizeLabel.Name = "lblBufferSizeLabel";
			lblBufferSizeLabel.Size = new System.Drawing.Size(86, 13);
			lblBufferSizeLabel.Text = "Buffer size (MiB):";
			// 
			// lblCurrentDiscLabel
			// 
			lblCurrentDiscLabel.AutoEllipsis = true;
			lblCurrentDiscLabel.AutoSize = true;
			lblCurrentDiscLabel.Location = new System.Drawing.Point(19, 219);
			lblCurrentDiscLabel.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			lblCurrentDiscLabel.Name = "lblCurrentDiscLabel";
			lblCurrentDiscLabel.Size = new System.Drawing.Size(54, 13);
			lblCurrentDiscLabel.Text = "Disc type:";
			// 
			// lblCapacityLabel
			// 
			lblCapacityLabel.AutoEllipsis = true;
			lblCapacityLabel.AutoSize = true;
			lblCapacityLabel.Location = new System.Drawing.Point(19, 244);
			lblCapacityLabel.Margin = new System.Windows.Forms.Padding(3, 6, 0, 6);
			lblCapacityLabel.Name = "lblCapacityLabel";
			lblCapacityLabel.Size = new System.Drawing.Size(91, 13);
			lblCapacityLabel.Text = "Disc capacity left:";
			// 
			// lblDiscStatusLabel
			// 
			lblDiscStatusLabel.AutoEllipsis = true;
			lblDiscStatusLabel.AutoSize = true;
			lblDiscStatusLabel.Location = new System.Drawing.Point(193, 219);
			lblDiscStatusLabel.Margin = new System.Windows.Forms.Padding(3, 6, 0, 6);
			lblDiscStatusLabel.Name = "lblDiscStatusLabel";
			lblDiscStatusLabel.Size = new System.Drawing.Size(62, 13);
			lblDiscStatusLabel.Text = "Disc status:";
			// 
			// lblSessionLabel
			// 
			lblSessionLabel.AutoEllipsis = true;
			lblSessionLabel.AutoSize = true;
			lblSessionLabel.Location = new System.Drawing.Point(193, 244);
			lblSessionLabel.Margin = new System.Windows.Forms.Padding(3, 6, 0, 6);
			lblSessionLabel.Name = "lblSessionLabel";
			lblSessionLabel.Size = new System.Drawing.Size(62, 13);
			lblSessionLabel.Text = "Disc layout:";
			// 
			// chkEmbedFiles
			// 
			this.chkEmbedFiles.AutoSize = true;
			this.tlpMain.SetColumnSpan(this.chkEmbedFiles, 2);
			this.chkEmbedFiles.Location = new System.Drawing.Point(196, 65);
			this.chkEmbedFiles.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
			this.chkEmbedFiles.Name = "chkEmbedFiles";
			this.chkEmbedFiles.Size = new System.Drawing.Size(181, 17);
			this.chkEmbedFiles.Text = "&Embed small files in ICB (caution)";
			this.ttpInfo.SetToolTip(this.chkEmbedFiles, resources.GetString("chkEmbedFiles.ToolTip"));
			this.chkEmbedFiles.UseVisualStyleBackColor = true;
			// 
			// chkFindDuplicates
			// 
			this.chkFindDuplicates.AutoSize = true;
			this.tlpMain.SetColumnSpan(this.chkFindDuplicates, 2);
			this.chkFindDuplicates.Location = new System.Drawing.Point(22, 65);
			this.chkFindDuplicates.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
			this.chkFindDuplicates.Name = "chkFindDuplicates";
			this.chkFindDuplicates.Size = new System.Drawing.Size(153, 17);
			this.chkFindDuplicates.Text = "Find and link &duplicate files";
			this.ttpInfo.SetToolTip(this.chkFindDuplicates, resources.GetString("chkFindDuplicates.ToolTip"));
			this.chkFindDuplicates.UseVisualStyleBackColor = true;
			// 
			// chkFinalize
			// 
			this.chkFinalize.AutoSize = true;
			this.tlpMain.SetColumnSpan(this.chkFinalize, 2);
			this.chkFinalize.Location = new System.Drawing.Point(196, 42);
			this.chkFinalize.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
			this.chkFinalize.Name = "chkFinalize";
			this.chkFinalize.Size = new System.Drawing.Size(83, 17);
			this.chkFinalize.Text = "&Finalize disc";
			this.ttpInfo.SetToolTip(this.chkFinalize, "Finalizes the disc, preventing the addition of new sessions to the disc.\r\nYou may" +
					" need to erase the disc in order to write to it again, if it is rewritable.");
			this.chkFinalize.UseVisualStyleBackColor = true;
			// 
			// cmbWriteSpeed
			// 
			this.tlpMain.SetColumnSpan(this.cmbWriteSpeed, 3);
			this.cmbWriteSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cmbWriteSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbWriteSpeed.FormattingEnabled = true;
			this.cmbWriteSpeed.Location = new System.Drawing.Point(113, 88);
			this.cmbWriteSpeed.Name = "cmbWriteSpeed";
			this.cmbWriteSpeed.Size = new System.Drawing.Size(300, 21);
			this.ttpInfo.SetToolTip(this.cmbWriteSpeed, "The write speed to use. Select a lower speed if you find that your discs are burn" +
					"ed incorrectly.");
			// 
			// cmbWriteType
			// 
			this.tlpMain.SetColumnSpan(this.cmbWriteType, 3);
			this.cmbWriteType.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cmbWriteType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbWriteType.FormattingEnabled = true;
			this.cmbWriteType.Location = new System.Drawing.Point(113, 115);
			this.cmbWriteType.Name = "cmbWriteType";
			this.cmbWriteType.Size = new System.Drawing.Size(300, 21);
			this.ttpInfo.SetToolTip(this.cmbWriteType, "The recording method to use. Currently, session-at-once has some bugs, so you sho" +
					"uld use track-at-once.");
			// 
			// cmbDataBlockType
			// 
			this.tlpMain.SetColumnSpan(this.cmbDataBlockType, 3);
			this.cmbDataBlockType.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cmbDataBlockType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbDataBlockType.FormattingEnabled = true;
			this.cmbDataBlockType.Location = new System.Drawing.Point(113, 142);
			this.cmbDataBlockType.Name = "cmbDataBlockType";
			this.cmbDataBlockType.Size = new System.Drawing.Size(300, 21);
			this.ttpInfo.SetToolTip(this.cmbDataBlockType, "The track mode to use. The technical difference between mode 1 and mode 2 form 1 " +
					"is\r\nminor, and it is usually beneficial to choose mode 1 because of its broader " +
					"compatibility.");
			// 
			// txtDiscCapacity
			// 
			this.txtDiscCapacity.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtDiscCapacity.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtDiscCapacity.Location = new System.Drawing.Point(113, 244);
			this.txtDiscCapacity.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtDiscCapacity.MaxLength = 0;
			this.txtDiscCapacity.Name = "txtDiscCapacity";
			this.txtDiscCapacity.ReadOnly = true;
			this.txtDiscCapacity.Size = new System.Drawing.Size(74, 13);
			this.txtDiscCapacity.Text = "N/A";
			this.ttpInfo.SetToolTip(this.txtDiscCapacity, resources.GetString("txtDiscCapacity.ToolTip"));
			// 
			// tlpMain
			// 
			this.tlpMain.AutoSize = true;
			this.tlpMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tlpMain.ColumnCount = 4;
			this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
			this.tlpMain.Controls.Add(this.flpButtons, 0, 13);
			this.tlpMain.Controls.Add(lblWriteSpeed, 0, 5);
			this.tlpMain.Controls.Add(this.cmbWriteSpeed, 1, 5);
			this.tlpMain.Controls.Add(lblWriteType, 0, 6);
			this.tlpMain.Controls.Add(this.cmbWriteType, 1, 6);
			this.tlpMain.Controls.Add(lblDataBlockType, 0, 7);
			this.tlpMain.Controls.Add(this.cmbDataBlockType, 1, 7);
			this.tlpMain.Controls.Add(lblBufferSizeLabel, 0, 8);
			this.tlpMain.Controls.Add(lblCurrentDiscLabel, 0, 9);
			this.tlpMain.Controls.Add(this.lblCurrentDisc, 1, 9);
			this.tlpMain.Controls.Add(lblCapacityLabel, 0, 10);
			this.tlpMain.Controls.Add(lblDiscStatusLabel, 2, 9);
			this.tlpMain.Controls.Add(this.lblDiscStatus, 3, 9);
			this.tlpMain.Controls.Add(lblSessionLabel, 2, 10);
			this.tlpMain.Controls.Add(this.lblSessions, 3, 10);
			this.tlpMain.Controls.Add(this.txtDiscCapacity, 1, 10);
			this.tlpMain.Controls.Add(this.chkBufferUnderrunProtection, 0, 0);
			this.tlpMain.Controls.Add(this.chkSimulation, 0, 1);
			this.tlpMain.Controls.Add(this.chkFindDuplicates, 0, 2);
			this.tlpMain.Controls.Add(this.chkEmbedFiles, 2, 2);
			this.tlpMain.Controls.Add(this.chkFinalize, 2, 1);
			this.tlpMain.Controls.Add(this.lnkPrefixHelp, 0, 11);
			this.tlpMain.Controls.Add(this.tbBufferSize, 2, 8);
			this.tlpMain.Controls.Add(this.lblBufferSize, 1, 8);
			this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpMain.Location = new System.Drawing.Point(0, 0);
			this.tlpMain.Name = "tlpMain";
			this.tlpMain.Padding = new System.Windows.Forms.Padding(16);
			this.tlpMain.RowCount = 14;
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpMain.Size = new System.Drawing.Size(432, 344);
			this.tlpMain.Text = "0";
			// 
			// flpButtons
			// 
			this.flpButtons.AutoSize = true;
			this.flpButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tlpMain.SetColumnSpan(this.flpButtons, 4);
			this.flpButtons.Controls.Add(this.btnCancel);
			this.flpButtons.Controls.Add(this.btnOK);
			this.flpButtons.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flpButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flpButtons.Location = new System.Drawing.Point(19, 287);
			this.flpButtons.Name = "flpButtons";
			this.flpButtons.Size = new System.Drawing.Size(394, 38);
			// 
			// btnCancel
			// 
			this.btnCancel.AutoSize = true;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(281, 3);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(110, 32);
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOK
			// 
			this.btnOK.AutoSize = true;
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Image = global::BurnApp.Properties.Resources.Burn24;
			this.btnOK.Location = new System.Drawing.Point(165, 3);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(110, 32);
			this.btnOK.Text = "&Burn";
			this.btnOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// lblCurrentDisc
			// 
			this.lblCurrentDisc.AutoEllipsis = true;
			this.lblCurrentDisc.AutoSize = true;
			this.lblCurrentDisc.Location = new System.Drawing.Point(110, 219);
			this.lblCurrentDisc.Margin = new System.Windows.Forms.Padding(0, 6, 0, 6);
			this.lblCurrentDisc.Name = "lblCurrentDisc";
			this.lblCurrentDisc.Size = new System.Drawing.Size(27, 13);
			this.lblCurrentDisc.Text = "N/A";
			// 
			// lblDiscStatus
			// 
			this.lblDiscStatus.AutoEllipsis = true;
			this.lblDiscStatus.AutoSize = true;
			this.lblDiscStatus.Location = new System.Drawing.Point(255, 219);
			this.lblDiscStatus.Margin = new System.Windows.Forms.Padding(0, 6, 0, 6);
			this.lblDiscStatus.Name = "lblDiscStatus";
			this.lblDiscStatus.Size = new System.Drawing.Size(27, 13);
			this.lblDiscStatus.Text = "N/A";
			// 
			// lblSessions
			// 
			this.lblSessions.AutoEllipsis = true;
			this.lblSessions.AutoSize = true;
			this.lblSessions.Location = new System.Drawing.Point(255, 244);
			this.lblSessions.Margin = new System.Windows.Forms.Padding(0, 6, 0, 6);
			this.lblSessions.Name = "lblSessions";
			this.lblSessions.Size = new System.Drawing.Size(27, 13);
			this.lblSessions.Text = "N/A";
			// 
			// chkBufferUnderrunProtection
			// 
			this.chkBufferUnderrunProtection.AutoSize = true;
			this.chkBufferUnderrunProtection.Checked = true;
			this.chkBufferUnderrunProtection.CheckState = System.Windows.Forms.CheckState.Checked;
			this.tlpMain.SetColumnSpan(this.chkBufferUnderrunProtection, 2);
			this.chkBufferUnderrunProtection.Location = new System.Drawing.Point(22, 19);
			this.chkBufferUnderrunProtection.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
			this.chkBufferUnderrunProtection.Name = "chkBufferUnderrunProtection";
			this.chkBufferUnderrunProtection.Size = new System.Drawing.Size(149, 17);
			this.chkBufferUnderrunProtection.Text = "Buffer underrun &protection";
			this.chkBufferUnderrunProtection.UseVisualStyleBackColor = true;
			// 
			// chkSimulation
			// 
			this.chkSimulation.AutoSize = true;
			this.tlpMain.SetColumnSpan(this.chkSimulation, 2);
			this.chkSimulation.Location = new System.Drawing.Point(22, 42);
			this.chkSimulation.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
			this.chkSimulation.Name = "chkSimulation";
			this.chkSimulation.Size = new System.Drawing.Size(74, 17);
			this.chkSimulation.Text = "&Simulation";
			this.chkSimulation.UseVisualStyleBackColor = true;
			// 
			// lnkPrefixHelp
			// 
			this.lnkPrefixHelp.AutoEllipsis = true;
			this.lnkPrefixHelp.AutoSize = true;
			this.tlpMain.SetColumnSpan(this.lnkPrefixHelp, 4);
			this.lnkPrefixHelp.Location = new System.Drawing.Point(19, 266);
			this.lnkPrefixHelp.Margin = new System.Windows.Forms.Padding(3);
			this.lnkPrefixHelp.Name = "lnkPrefixHelp";
			this.lnkPrefixHelp.Size = new System.Drawing.Size(303, 13);
			this.lnkPrefixHelp.TabStop = true;
			this.lnkPrefixHelp.Text = "What\'s the difference between KB and KiB, MB and MiB, etc.?";
			this.lnkPrefixHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkPrefixHelp_LinkClicked);
			// 
			// tbBufferSize
			// 
			this.tlpMain.SetColumnSpan(this.tbBufferSize, 2);
			this.tbBufferSize.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbBufferSize.LargeChange = 50;
			this.tbBufferSize.Location = new System.Drawing.Point(191, 167);
			this.tbBufferSize.Margin = new System.Windows.Forms.Padding(1);
			this.tbBufferSize.Maximum = 1000;
			this.tbBufferSize.Name = "tbBufferSize";
			this.tbBufferSize.Size = new System.Drawing.Size(224, 45);
			this.tbBufferSize.SmallChange = 10;
			this.tbBufferSize.TickFrequency = 50;
			this.tbBufferSize.TickStyle = System.Windows.Forms.TickStyle.Both;
			this.tbBufferSize.ValueChanged += new System.EventHandler(this.tbBufferSize_ValueChanged);
			// 
			// lblBufferSize
			// 
			this.lblBufferSize.AutoSize = true;
			this.lblBufferSize.Location = new System.Drawing.Point(110, 172);
			this.lblBufferSize.Margin = new System.Windows.Forms.Padding(0, 6, 0, 6);
			this.lblBufferSize.Name = "lblBufferSize";
			this.lblBufferSize.Size = new System.Drawing.Size(27, 13);
			this.lblBufferSize.Text = "N/A";
			// 
			// tmrRefresh
			// 
			this.tmrRefresh.Interval = 500;
			this.tmrRefresh.Tick += new System.EventHandler(this.tmrRefresh_Tick);
			// 
			// FormStartBurn
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(432, 344);
			this.Controls.Add(this.tlpMain);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormStartBurn";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Burn Disc";
			this.tlpMain.ResumeLayout(false);
			this.tlpMain.PerformLayout();
			this.flpButtons.ResumeLayout(false);
			this.flpButtons.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbBufferSize)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox chkSimulation;
		private System.Windows.Forms.CheckBox chkBufferUnderrunProtection;
		private System.Windows.Forms.CheckBox chkEmbedFiles;
		private System.Windows.Forms.CheckBox chkFindDuplicates;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Timer tmrRefresh;
		private System.Windows.Forms.TableLayoutPanel tlpMain;
		private System.Windows.Forms.ComboBox cmbWriteSpeed;
		private System.Windows.Forms.ComboBox cmbWriteType;
		private System.Windows.Forms.ComboBox cmbDataBlockType;
		private System.Windows.Forms.Label lblCurrentDisc;
		private System.Windows.Forms.FlowLayoutPanel flpButtons;
		private System.Windows.Forms.CheckBox chkFinalize;
		private System.Windows.Forms.Label lblDiscStatus;
		private System.Windows.Forms.Label lblSessions;
		private System.Windows.Forms.TextBox txtDiscCapacity;
		private System.Windows.Forms.ToolTip ttpInfo;
		private System.Windows.Forms.LinkLabel lnkPrefixHelp;
		private System.Windows.Forms.TrackBar tbBufferSize;
		private System.Windows.Forms.Label lblBufferSize;
	}
}