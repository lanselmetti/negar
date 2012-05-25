namespace BurnApp
{
	partial class FormBlank
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
			System.Windows.Forms.TableLayoutPanel tlpMain;
			this.rbBlankLastSession = new System.Windows.Forms.RadioButton();
			this.rbUncloseLastSession = new System.Windows.Forms.RadioButton();
			this.rbBlankTrackTail = new System.Windows.Forms.RadioButton();
			this.rbUnreserveTrack = new System.Windows.Forms.RadioButton();
			this.rbBlankTrack = new System.Windows.Forms.RadioButton();
			this.rbBlank = new System.Windows.Forms.RadioButton();
			this.rbBlankMinimal = new System.Windows.Forms.RadioButton();
			this.nudStartLBA = new System.Windows.Forms.NumericUpDown();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.nudTrackNumber = new System.Windows.Forms.NumericUpDown();
			tlpMain = new System.Windows.Forms.TableLayoutPanel();
			tlpMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudStartLBA)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudTrackNumber)).BeginInit();
			this.SuspendLayout();
			// 
			// tlpMain
			// 
			tlpMain.ColumnCount = 3;
			tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tlpMain.Controls.Add(this.rbBlankMinimal, 0, 0);
			tlpMain.Controls.Add(this.rbBlank, 0, 1);
			tlpMain.Controls.Add(this.rbBlankTrack, 0, 2);
			tlpMain.Controls.Add(this.nudTrackNumber, 2, 2);
			tlpMain.Controls.Add(this.rbUnreserveTrack, 0, 3);
			tlpMain.Controls.Add(this.rbBlankTrackTail, 0, 4);
			tlpMain.Controls.Add(this.nudStartLBA, 2, 4);
			tlpMain.Controls.Add(this.rbUncloseLastSession, 0, 5);
			tlpMain.Controls.Add(this.rbBlankLastSession, 0, 6);
			tlpMain.Controls.Add(this.btnOK, 1, 8);
			tlpMain.Controls.Add(this.btnCancel, 2, 8);
			tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
			tlpMain.Location = new System.Drawing.Point(0, 0);
			tlpMain.Name = "tlpMain";
			tlpMain.Padding = new System.Windows.Forms.Padding(10);
			tlpMain.RowCount = 9;
			tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tlpMain.Size = new System.Drawing.Size(289, 218);
			// 
			// rbBlankLastSession
			// 
			this.rbBlankLastSession.AutoSize = true;
			tlpMain.SetColumnSpan(this.rbBlankLastSession, 2);
			this.rbBlankLastSession.Location = new System.Drawing.Point(13, 151);
			this.rbBlankLastSession.Name = "rbBlankLastSession";
			this.rbBlankLastSession.Size = new System.Drawing.Size(161, 17);
			this.rbBlankLastSession.TabStop = true;
			this.rbBlankLastSession.Text = "Blank last non-empty session";
			this.rbBlankLastSession.UseVisualStyleBackColor = true;
			// 
			// rbUncloseLastSession
			// 
			this.rbUncloseLastSession.AutoSize = true;
			tlpMain.SetColumnSpan(this.rbUncloseLastSession, 2);
			this.rbUncloseLastSession.Location = new System.Drawing.Point(13, 128);
			this.rbUncloseLastSession.Name = "rbUncloseLastSession";
			this.rbUncloseLastSession.Size = new System.Drawing.Size(167, 17);
			this.rbUncloseLastSession.TabStop = true;
			this.rbUncloseLastSession.Text = "Unclose last complete session";
			this.rbUncloseLastSession.UseVisualStyleBackColor = true;
			// 
			// rbBlankTrackTail
			// 
			this.rbBlankTrackTail.AutoSize = true;
			tlpMain.SetColumnSpan(this.rbBlankTrackTail, 2);
			this.rbBlankTrackTail.Location = new System.Drawing.Point(13, 105);
			this.rbBlankTrackTail.Name = "rbBlankTrackTail";
			this.rbBlankTrackTail.Size = new System.Drawing.Size(170, 17);
			this.rbBlankTrackTail.TabStop = true;
			this.rbBlankTrackTail.Text = "Blank track tail starting at LBA:";
			this.rbBlankTrackTail.UseVisualStyleBackColor = true;
			this.rbBlankTrackTail.CheckedChanged += new System.EventHandler(this.rbBlankTrackTail_CheckedChanged);
			// 
			// rbUnreserveTrack
			// 
			this.rbUnreserveTrack.AutoSize = true;
			tlpMain.SetColumnSpan(this.rbUnreserveTrack, 2);
			this.rbUnreserveTrack.Location = new System.Drawing.Point(13, 82);
			this.rbUnreserveTrack.Name = "rbUnreserveTrack";
			this.rbUnreserveTrack.Size = new System.Drawing.Size(113, 17);
			this.rbUnreserveTrack.TabStop = true;
			this.rbUnreserveTrack.Text = "Un-reserve a track";
			this.rbUnreserveTrack.UseVisualStyleBackColor = true;
			// 
			// rbBlankTrack
			// 
			this.rbBlankTrack.AutoSize = true;
			tlpMain.SetColumnSpan(this.rbBlankTrack, 2);
			this.rbBlankTrack.Location = new System.Drawing.Point(13, 59);
			this.rbBlankTrack.Name = "rbBlankTrack";
			this.rbBlankTrack.Size = new System.Drawing.Size(169, 17);
			this.rbBlankTrack.TabStop = true;
			this.rbBlankTrack.Text = "Blank track with track number:";
			this.rbBlankTrack.UseVisualStyleBackColor = true;
			this.rbBlankTrack.CheckedChanged += new System.EventHandler(this.rbBlankTrack_CheckedChanged);
			// 
			// rbBlank
			// 
			this.rbBlank.AutoSize = true;
			tlpMain.SetColumnSpan(this.rbBlank, 2);
			this.rbBlank.Location = new System.Drawing.Point(13, 36);
			this.rbBlank.Name = "rbBlank";
			this.rbBlank.Size = new System.Drawing.Size(96, 17);
			this.rbBlank.TabStop = true;
			this.rbBlank.Text = "Erase disc (full)";
			this.rbBlank.UseVisualStyleBackColor = true;
			// 
			// rbBlankMinimal
			// 
			this.rbBlankMinimal.AutoSize = true;
			tlpMain.SetColumnSpan(this.rbBlankMinimal, 2);
			this.rbBlankMinimal.Location = new System.Drawing.Point(13, 13);
			this.rbBlankMinimal.Name = "rbBlankMinimal";
			this.rbBlankMinimal.Size = new System.Drawing.Size(109, 17);
			this.rbBlankMinimal.TabStop = true;
			this.rbBlankMinimal.Text = "Erase disc (quick)";
			this.rbBlankMinimal.UseVisualStyleBackColor = true;
			// 
			// nudStartLBA
			// 
			this.nudStartLBA.Enabled = false;
			this.nudStartLBA.Location = new System.Drawing.Point(201, 104);
			this.nudStartLBA.Margin = new System.Windows.Forms.Padding(3, 2, 3, 0);
			this.nudStartLBA.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
			this.nudStartLBA.Name = "nudStartLBA";
			this.nudStartLBA.Size = new System.Drawing.Size(75, 20);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(201, 182);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(120, 182);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.Text = "&OK";
			this.btnOK.UseVisualStyleBackColor = true;
			// 
			// nudTrackNumber
			// 
			this.nudTrackNumber.Enabled = false;
			this.nudTrackNumber.Location = new System.Drawing.Point(201, 58);
			this.nudTrackNumber.Margin = new System.Windows.Forms.Padding(3, 2, 3, 0);
			this.nudTrackNumber.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
			this.nudTrackNumber.Name = "nudTrackNumber";
			this.nudTrackNumber.Size = new System.Drawing.Size(75, 20);
			this.nudTrackNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// FormBlank
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(289, 218);
			this.Controls.Add(tlpMain);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormBlank";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Erase Disc";
			tlpMain.ResumeLayout(false);
			tlpMain.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudStartLBA)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudTrackNumber)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.RadioButton rbBlankLastSession;
		private System.Windows.Forms.RadioButton rbUncloseLastSession;
		private System.Windows.Forms.RadioButton rbBlankTrackTail;
		private System.Windows.Forms.RadioButton rbUnreserveTrack;
		private System.Windows.Forms.RadioButton rbBlankTrack;
		private System.Windows.Forms.RadioButton rbBlank;
		private System.Windows.Forms.RadioButton rbBlankMinimal;
		private System.Windows.Forms.NumericUpDown nudTrackNumber;
		private System.Windows.Forms.NumericUpDown nudStartLBA;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
	}
}