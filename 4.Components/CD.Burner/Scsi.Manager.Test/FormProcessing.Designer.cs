namespace BurnApp
{
	partial class FormProcessing
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
			this.colTime = new System.Windows.Forms.ColumnHeader();
			this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
			this.lblFileSystemLabel = new System.Windows.Forms.Label();
			this.lblFileSystem = new System.Windows.Forms.Label();
			this.lvProgress = new System.Windows.Forms.ListView();
			this.colEvent = new System.Windows.Forms.ColumnHeader();
			this.lblCurrentFileLabel = new System.Windows.Forms.Label();
			this.lblCurrentFile = new System.Windows.Forms.Label();
			this.lblElapsedLabel = new System.Windows.Forms.Label();
			this.lblElapsed = new System.Windows.Forms.Label();
			this.lblStatusLabel = new System.Windows.Forms.Label();
			this.lblStatus = new System.Windows.Forms.Label();
			this.lblRemainingTimeLabel = new System.Windows.Forms.Label();
			this.lblRemainingTime = new System.Windows.Forms.Label();
			this.lblSpeedLabel = new System.Windows.Forms.Label();
			this.lblSpeed = new System.Windows.Forms.Label();
			this.lblEndTimeLabel = new System.Windows.Forms.Label();
			this.lblEndTime = new System.Windows.Forms.Label();
			this.lblUsedReadBufferLabel = new System.Windows.Forms.Label();
			this.lblUsedReadBuffer = new System.Windows.Forms.Label();
			this.pbBuffer = new BurnApp.FormProcessing.MyProgressBar();
			this.lblCompletedLabel = new System.Windows.Forms.Label();
			this.lblCompleted = new System.Windows.Forms.Label();
			this.pbBurn = new BurnApp.FormProcessing.MyProgressBar();
			this.lvRecorders = new System.Windows.Forms.ListView();
			this.colRecorder = new System.Windows.Forms.ColumnHeader();
			this.colBufferUsed = new System.Windows.Forms.ColumnHeader();
			this.colBufferCapacity = new System.Windows.Forms.ColumnHeader();
			this.colBufferPercent = new System.Windows.Forms.ColumnHeader();
			this.btnCancel = new System.Windows.Forms.Button();
			this.tbarUpdateInterval = new System.Windows.Forms.TrackBar();
			this.lblUpdateSpeedLabel = new System.Windows.Forms.Label();
			this.lblUpdateSpeed = new System.Windows.Forms.Label();
			this.sbMain = new System.Windows.Forms.StatusBar();
			this.epMain = new System.Windows.Forms.ErrorProvider(this.components);
			this.tlpMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbarUpdateInterval)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.epMain)).BeginInit();
			this.SuspendLayout();
			// 
			// colTime
			// 
			this.colTime.Text = "Time";
			this.colTime.Width = 100;
			// 
			// tlpMain
			// 
			this.tlpMain.ColumnCount = 4;
			this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpMain.Controls.Add(this.lblFileSystemLabel, 0, 0);
			this.tlpMain.Controls.Add(this.lblFileSystem, 1, 0);
			this.tlpMain.Controls.Add(this.lvProgress, 0, 1);
			this.tlpMain.Controls.Add(this.lblCurrentFileLabel, 0, 2);
			this.tlpMain.Controls.Add(this.lblCurrentFile, 1, 2);
			this.tlpMain.Controls.Add(this.lblElapsedLabel, 2, 2);
			this.tlpMain.Controls.Add(this.lblElapsed, 3, 2);
			this.tlpMain.Controls.Add(this.lblStatusLabel, 0, 3);
			this.tlpMain.Controls.Add(this.lblStatus, 1, 3);
			this.tlpMain.Controls.Add(this.lblRemainingTimeLabel, 2, 3);
			this.tlpMain.Controls.Add(this.lblRemainingTime, 3, 3);
			this.tlpMain.Controls.Add(this.lblSpeedLabel, 0, 4);
			this.tlpMain.Controls.Add(this.lblSpeed, 1, 4);
			this.tlpMain.Controls.Add(this.lblEndTimeLabel, 2, 4);
			this.tlpMain.Controls.Add(this.lblEndTime, 3, 4);
			this.tlpMain.Controls.Add(this.lblUsedReadBufferLabel, 0, 6);
			this.tlpMain.Controls.Add(this.lblUsedReadBuffer, 1, 6);
			this.tlpMain.Controls.Add(this.pbBuffer, 0, 7);
			this.tlpMain.Controls.Add(this.lblCompletedLabel, 0, 9);
			this.tlpMain.Controls.Add(this.lblCompleted, 1, 9);
			this.tlpMain.Controls.Add(this.pbBurn, 0, 10);
			this.tlpMain.Controls.Add(this.lvRecorders, 0, 12);
			this.tlpMain.Controls.Add(this.btnCancel, 3, 13);
			this.tlpMain.Controls.Add(this.tbarUpdateInterval, 1, 13);
			this.tlpMain.Controls.Add(this.lblUpdateSpeedLabel, 0, 13);
			this.tlpMain.Controls.Add(this.lblUpdateSpeed, 2, 13);
			this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpMain.Location = new System.Drawing.Point(0, 0);
			this.tlpMain.Name = "tlpMain";
			this.tlpMain.Padding = new System.Windows.Forms.Padding(20, 20, 20, 10);
			this.tlpMain.RowCount = 14;
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 2F));
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpMain.Size = new System.Drawing.Size(651, 431);
			this.tlpMain.TabIndex = 0;
			// 
			// lblFileSystemLabel
			// 
			this.lblFileSystemLabel.AutoEllipsis = true;
			this.lblFileSystemLabel.AutoSize = true;
			this.lblFileSystemLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblFileSystemLabel.Location = new System.Drawing.Point(20, 25);
			this.lblFileSystemLabel.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
			this.lblFileSystemLabel.Name = "lblFileSystemLabel";
			this.lblFileSystemLabel.Size = new System.Drawing.Size(89, 13);
			this.lblFileSystemLabel.TabIndex = 0;
			this.lblFileSystemLabel.Text = "File System:";
			this.lblFileSystemLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblFileSystem
			// 
			this.lblFileSystem.AutoEllipsis = true;
			this.lblFileSystem.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblFileSystem.Location = new System.Drawing.Point(109, 25);
			this.lblFileSystem.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
			this.lblFileSystem.Name = "lblFileSystem";
			this.lblFileSystem.Size = new System.Drawing.Size(312, 13);
			this.lblFileSystem.TabIndex = 1;
			this.lblFileSystem.Text = "UDF";
			this.lblFileSystem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lvProgress
			// 
			this.lvProgress.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTime,
            this.colEvent});
			this.tlpMain.SetColumnSpan(this.lvProgress, 4);
			this.lvProgress.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvProgress.Location = new System.Drawing.Point(23, 46);
			this.lvProgress.MultiSelect = false;
			this.lvProgress.Name = "lvProgress";
			this.lvProgress.OwnerDraw = true;
			this.lvProgress.ShowItemToolTips = true;
			this.lvProgress.Size = new System.Drawing.Size(605, 94);
			this.lvProgress.TabIndex = 2;
			this.lvProgress.UseCompatibleStateImageBehavior = false;
			this.lvProgress.View = System.Windows.Forms.View.Details;
			this.lvProgress.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lvProgress_DrawColumnHeader);
			this.lvProgress.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lvProgress_DrawItem);
			this.lvProgress.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.lvProgress_DrawSubItem);
			// 
			// colEvent
			// 
			this.colEvent.Text = "Event";
			this.colEvent.Width = 390;
			// 
			// lblCurrentFileLabel
			// 
			this.lblCurrentFileLabel.AutoEllipsis = true;
			this.lblCurrentFileLabel.AutoSize = true;
			this.lblCurrentFileLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblCurrentFileLabel.Location = new System.Drawing.Point(20, 148);
			this.lblCurrentFileLabel.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
			this.lblCurrentFileLabel.Name = "lblCurrentFileLabel";
			this.lblCurrentFileLabel.Size = new System.Drawing.Size(89, 13);
			this.lblCurrentFileLabel.TabIndex = 3;
			this.lblCurrentFileLabel.Text = "Writing file:";
			this.lblCurrentFileLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblCurrentFile
			// 
			this.lblCurrentFile.AutoEllipsis = true;
			this.lblCurrentFile.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblCurrentFile.Location = new System.Drawing.Point(109, 148);
			this.lblCurrentFile.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
			this.lblCurrentFile.Name = "lblCurrentFile";
			this.lblCurrentFile.Size = new System.Drawing.Size(312, 13);
			this.lblCurrentFile.TabIndex = 4;
			this.lblCurrentFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblElapsedLabel
			// 
			this.lblElapsedLabel.AutoEllipsis = true;
			this.lblElapsedLabel.AutoSize = true;
			this.lblElapsedLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblElapsedLabel.Location = new System.Drawing.Point(421, 148);
			this.lblElapsedLabel.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
			this.lblElapsedLabel.Name = "lblElapsedLabel";
			this.lblElapsedLabel.Size = new System.Drawing.Size(60, 13);
			this.lblElapsedLabel.TabIndex = 5;
			this.lblElapsedLabel.Text = "Elapsed:";
			this.lblElapsedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblElapsed
			// 
			this.lblElapsed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblElapsed.AutoEllipsis = true;
			this.lblElapsed.AutoSize = true;
			this.lblElapsed.Location = new System.Drawing.Point(604, 148);
			this.lblElapsed.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
			this.lblElapsed.Name = "lblElapsed";
			this.lblElapsed.Size = new System.Drawing.Size(27, 13);
			this.lblElapsed.TabIndex = 6;
			this.lblElapsed.Text = "N/A";
			this.lblElapsed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblStatusLabel
			// 
			this.lblStatusLabel.AutoEllipsis = true;
			this.lblStatusLabel.AutoSize = true;
			this.lblStatusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblStatusLabel.Location = new System.Drawing.Point(20, 171);
			this.lblStatusLabel.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
			this.lblStatusLabel.Name = "lblStatusLabel";
			this.lblStatusLabel.Size = new System.Drawing.Size(89, 13);
			this.lblStatusLabel.TabIndex = 7;
			this.lblStatusLabel.Text = "Status:";
			this.lblStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblStatus
			// 
			this.lblStatus.AutoEllipsis = true;
			this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblStatus.Location = new System.Drawing.Point(109, 171);
			this.lblStatus.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(312, 13);
			this.lblStatus.TabIndex = 8;
			this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblRemainingTimeLabel
			// 
			this.lblRemainingTimeLabel.AutoEllipsis = true;
			this.lblRemainingTimeLabel.AutoSize = true;
			this.lblRemainingTimeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblRemainingTimeLabel.Location = new System.Drawing.Point(421, 171);
			this.lblRemainingTimeLabel.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
			this.lblRemainingTimeLabel.Name = "lblRemainingTimeLabel";
			this.lblRemainingTimeLabel.Size = new System.Drawing.Size(60, 13);
			this.lblRemainingTimeLabel.TabIndex = 9;
			this.lblRemainingTimeLabel.Text = "Remaining:";
			this.lblRemainingTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblRemainingTime
			// 
			this.lblRemainingTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblRemainingTime.AutoEllipsis = true;
			this.lblRemainingTime.AutoSize = true;
			this.lblRemainingTime.Location = new System.Drawing.Point(604, 171);
			this.lblRemainingTime.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
			this.lblRemainingTime.Name = "lblRemainingTime";
			this.lblRemainingTime.Size = new System.Drawing.Size(27, 13);
			this.lblRemainingTime.TabIndex = 10;
			this.lblRemainingTime.Text = "N/A";
			this.lblRemainingTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblSpeedLabel
			// 
			this.lblSpeedLabel.AutoEllipsis = true;
			this.lblSpeedLabel.AutoSize = true;
			this.lblSpeedLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblSpeedLabel.Location = new System.Drawing.Point(20, 194);
			this.lblSpeedLabel.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
			this.lblSpeedLabel.Name = "lblSpeedLabel";
			this.lblSpeedLabel.Size = new System.Drawing.Size(89, 13);
			this.lblSpeedLabel.TabIndex = 11;
			this.lblSpeedLabel.Text = "Speed:";
			this.lblSpeedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblSpeed
			// 
			this.lblSpeed.AutoEllipsis = true;
			this.lblSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblSpeed.Location = new System.Drawing.Point(109, 194);
			this.lblSpeed.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
			this.lblSpeed.Name = "lblSpeed";
			this.lblSpeed.Size = new System.Drawing.Size(312, 13);
			this.lblSpeed.TabIndex = 12;
			this.lblSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblEndTimeLabel
			// 
			this.lblEndTimeLabel.AutoEllipsis = true;
			this.lblEndTimeLabel.AutoSize = true;
			this.lblEndTimeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblEndTimeLabel.Location = new System.Drawing.Point(421, 194);
			this.lblEndTimeLabel.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
			this.lblEndTimeLabel.Name = "lblEndTimeLabel";
			this.lblEndTimeLabel.Size = new System.Drawing.Size(60, 13);
			this.lblEndTimeLabel.TabIndex = 13;
			this.lblEndTimeLabel.Text = "Finishes at:";
			this.lblEndTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblEndTime
			// 
			this.lblEndTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblEndTime.AutoEllipsis = true;
			this.lblEndTime.AutoSize = true;
			this.lblEndTime.Location = new System.Drawing.Point(604, 194);
			this.lblEndTime.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
			this.lblEndTime.Name = "lblEndTime";
			this.lblEndTime.Size = new System.Drawing.Size(27, 13);
			this.lblEndTime.TabIndex = 14;
			this.lblEndTime.Text = "N/A";
			this.lblEndTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblUsedReadBufferLabel
			// 
			this.lblUsedReadBufferLabel.AutoEllipsis = true;
			this.lblUsedReadBufferLabel.AutoSize = true;
			this.lblUsedReadBufferLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblUsedReadBufferLabel.Location = new System.Drawing.Point(20, 227);
			this.lblUsedReadBufferLabel.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
			this.lblUsedReadBufferLabel.Name = "lblUsedReadBufferLabel";
			this.lblUsedReadBufferLabel.Size = new System.Drawing.Size(89, 13);
			this.lblUsedReadBufferLabel.TabIndex = 15;
			this.lblUsedReadBufferLabel.Text = "Used read buffer:";
			this.lblUsedReadBufferLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblUsedReadBuffer
			// 
			this.lblUsedReadBuffer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblUsedReadBuffer.AutoEllipsis = true;
			this.lblUsedReadBuffer.AutoSize = true;
			this.tlpMain.SetColumnSpan(this.lblUsedReadBuffer, 3);
			this.epMain.SetIconAlignment(this.lblUsedReadBuffer, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
			this.lblUsedReadBuffer.Location = new System.Drawing.Point(604, 227);
			this.lblUsedReadBuffer.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
			this.lblUsedReadBuffer.Name = "lblUsedReadBuffer";
			this.lblUsedReadBuffer.Size = new System.Drawing.Size(27, 13);
			this.lblUsedReadBuffer.TabIndex = 16;
			this.lblUsedReadBuffer.Text = "N/A";
			this.lblUsedReadBuffer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// pbBuffer
			// 
			this.tlpMain.SetColumnSpan(this.pbBuffer, 4);
			this.pbBuffer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pbBuffer.Location = new System.Drawing.Point(23, 248);
			this.pbBuffer.MaximumSize = new System.Drawing.Size(0, 20);
			this.pbBuffer.Name = "pbBuffer";
			this.pbBuffer.Size = new System.Drawing.Size(605, 20);
			this.pbBuffer.SmoothReverse = true;
			this.pbBuffer.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.pbBuffer.TabIndex = 17;
			// 
			// lblCompletedLabel
			// 
			this.lblCompletedLabel.AutoEllipsis = true;
			this.lblCompletedLabel.AutoSize = true;
			this.lblCompletedLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblCompletedLabel.Location = new System.Drawing.Point(20, 278);
			this.lblCompletedLabel.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
			this.lblCompletedLabel.Name = "lblCompletedLabel";
			this.lblCompletedLabel.Size = new System.Drawing.Size(89, 13);
			this.lblCompletedLabel.TabIndex = 18;
			this.lblCompletedLabel.Text = "Completed:";
			this.lblCompletedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblCompleted
			// 
			this.lblCompleted.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblCompleted.AutoEllipsis = true;
			this.lblCompleted.AutoSize = true;
			this.tlpMain.SetColumnSpan(this.lblCompleted, 3);
			this.lblCompleted.Location = new System.Drawing.Point(604, 278);
			this.lblCompleted.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
			this.lblCompleted.Name = "lblCompleted";
			this.lblCompleted.Size = new System.Drawing.Size(27, 13);
			this.lblCompleted.TabIndex = 19;
			this.lblCompleted.Text = "N/A";
			this.lblCompleted.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// pbBurn
			// 
			this.tlpMain.SetColumnSpan(this.pbBurn, 4);
			this.pbBurn.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pbBurn.Location = new System.Drawing.Point(23, 299);
			this.pbBurn.MaximumSize = new System.Drawing.Size(0, 20);
			this.pbBurn.Name = "pbBurn";
			this.pbBurn.Size = new System.Drawing.Size(605, 20);
			this.pbBurn.SmoothReverse = true;
			this.pbBurn.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.pbBurn.TabIndex = 20;
			// 
			// lvRecorders
			// 
			this.lvRecorders.AllowColumnReorder = true;
			this.lvRecorders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colRecorder,
            this.colBufferUsed,
            this.colBufferCapacity,
            this.colBufferPercent});
			this.tlpMain.SetColumnSpan(this.lvRecorders, 4);
			this.lvRecorders.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvRecorders.Location = new System.Drawing.Point(23, 330);
			this.lvRecorders.Name = "lvRecorders";
			this.lvRecorders.OwnerDraw = true;
			this.lvRecorders.Size = new System.Drawing.Size(605, 36);
			this.lvRecorders.TabIndex = 21;
			this.lvRecorders.UseCompatibleStateImageBehavior = false;
			this.lvRecorders.View = System.Windows.Forms.View.Details;
			this.lvRecorders.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lvRecorders_DrawColumnHeader);
			this.lvRecorders.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lvRecorders_DrawItem);
			this.lvRecorders.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.lvRecorders_DrawSubItem);
			// 
			// colRecorder
			// 
			this.colRecorder.Text = "Recorder";
			this.colRecorder.Width = 300;
			// 
			// colBufferUsed
			// 
			this.colBufferUsed.Text = "Buffer Used";
			this.colBufferUsed.Width = 100;
			// 
			// colBufferCapacity
			// 
			this.colBufferCapacity.Text = "Buffer Capacity";
			this.colBufferCapacity.Width = 100;
			// 
			// colBufferPercent
			// 
			this.colBufferPercent.Text = "Buffer Percent";
			this.colBufferPercent.Width = 100;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(484, 372);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(144, 32);
			this.btnCancel.TabIndex = 22;
			this.btnCancel.Text = "&Stop";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// tbarUpdateInterval
			// 
			this.tbarUpdateInterval.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbarUpdateInterval.Location = new System.Drawing.Point(112, 372);
			this.tbarUpdateInterval.Maximum = 100;
			this.tbarUpdateInterval.Minimum = -5;
			this.tbarUpdateInterval.Name = "tbarUpdateInterval";
			this.tbarUpdateInterval.Size = new System.Drawing.Size(306, 46);
			this.tbarUpdateInterval.TabIndex = 23;
			this.tbarUpdateInterval.TickFrequency = 5;
			this.tbarUpdateInterval.ValueChanged += new System.EventHandler(this.tbarUpdateInterval_ValueChanged);
			// 
			// lblUpdateSpeedLabel
			// 
			this.lblUpdateSpeedLabel.AutoEllipsis = true;
			this.lblUpdateSpeedLabel.AutoSize = true;
			this.lblUpdateSpeedLabel.Location = new System.Drawing.Point(20, 379);
			this.lblUpdateSpeedLabel.Margin = new System.Windows.Forms.Padding(0, 10, 3, 5);
			this.lblUpdateSpeedLabel.Name = "lblUpdateSpeedLabel";
			this.lblUpdateSpeedLabel.Size = new System.Drawing.Size(68, 13);
			this.lblUpdateSpeedLabel.TabIndex = 24;
			this.lblUpdateSpeedLabel.Text = "Refresh rate:";
			this.lblUpdateSpeedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblUpdateSpeed
			// 
			this.lblUpdateSpeed.AutoEllipsis = true;
			this.lblUpdateSpeed.AutoSize = true;
			this.lblUpdateSpeed.Location = new System.Drawing.Point(424, 379);
			this.lblUpdateSpeed.Margin = new System.Windows.Forms.Padding(3, 10, 3, 5);
			this.lblUpdateSpeed.Name = "lblUpdateSpeed";
			this.lblUpdateSpeed.Size = new System.Drawing.Size(29, 13);
			this.lblUpdateSpeed.TabIndex = 25;
			this.lblUpdateSpeed.Text = "0 Hz";
			this.lblUpdateSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// sbMain
			// 
			this.sbMain.Location = new System.Drawing.Point(0, 431);
			this.sbMain.Name = "sbMain";
			this.sbMain.Size = new System.Drawing.Size(651, 22);
			this.sbMain.TabIndex = 1;
			// 
			// epMain
			// 
			this.epMain.ContainerControl = this;
			// 
			// FormProcessing
			// 
			this.AcceptButton = this.btnCancel;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(651, 453);
			this.Controls.Add(this.tlpMain);
			this.Controls.Add(this.sbMain);
			this.Name = "FormProcessing";
			this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
			this.tlpMain.ResumeLayout(false);
			this.tlpMain.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbarUpdateInterval)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.epMain)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView lvProgress;
		private System.Windows.Forms.ColumnHeader colEvent;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label lblCurrentFile;
		private System.Windows.Forms.Label lblStatus;
		private System.Windows.Forms.Label lblElapsed;
		private System.Windows.Forms.Label lblEndTime;
		private System.Windows.Forms.Label lblUsedReadBuffer;
		private System.Windows.Forms.Label lblCompleted;
		private System.Windows.Forms.Label lblFileSystem;
		private System.Windows.Forms.Label lblSpeed;
		private System.Windows.Forms.Label lblRemainingTime;
		private System.Windows.Forms.ListView lvRecorders;
		private System.Windows.Forms.ColumnHeader colBufferUsed;
		private System.Windows.Forms.ColumnHeader colBufferCapacity;
		private System.Windows.Forms.ColumnHeader colBufferPercent;
		private System.Windows.Forms.ColumnHeader colRecorder;
		private FormProcessing.MyProgressBar pbBurn;
		private FormProcessing.MyProgressBar pbBuffer;
		private System.Windows.Forms.TrackBar tbarUpdateInterval;
		private System.Windows.Forms.Label lblUpdateSpeed;
		private System.Windows.Forms.ErrorProvider epMain;
		private System.Windows.Forms.Label lblUpdateSpeedLabel;
		private System.Windows.Forms.Label lblUsedReadBufferLabel;
		private System.Windows.Forms.ColumnHeader colTime;
		private System.Windows.Forms.TableLayoutPanel tlpMain;
		private System.Windows.Forms.Label lblFileSystemLabel;
		private System.Windows.Forms.Label lblCurrentFileLabel;
		private System.Windows.Forms.Label lblElapsedLabel;
		private System.Windows.Forms.Label lblStatusLabel;
		private System.Windows.Forms.Label lblRemainingTimeLabel;
		private System.Windows.Forms.Label lblSpeedLabel;
		private System.Windows.Forms.Label lblEndTimeLabel;
		private System.Windows.Forms.StatusBar sbMain;
		private System.Windows.Forms.Label lblCompletedLabel;
	}
}