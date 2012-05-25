<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lstFileNames = New System.Windows.Forms.CheckedListBox
        Me.txtFilePath = New System.Windows.Forms.TextBox
        Me.btnLoadFilesName = New System.Windows.Forms.Button
        Me.btnReadTexts = New System.Windows.Forms.Button
        Me.btnExecute = New System.Windows.Forms.Button
        Me.txtCs = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtSqlText = New System.Windows.Forms.RichTextBox
        Me.SuspendLayout()
        '
        'lstFileNames
        '
        Me.lstFileNames.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstFileNames.CheckOnClick = True
        Me.lstFileNames.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lstFileNames.FormattingEnabled = True
        Me.lstFileNames.IntegralHeight = False
        Me.lstFileNames.Location = New System.Drawing.Point(12, 38)
        Me.lstFileNames.Name = "lstFileNames"
        Me.lstFileNames.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstFileNames.Size = New System.Drawing.Size(760, 243)
        Me.lstFileNames.TabIndex = 2
        '
        'txtFilePath
        '
        Me.txtFilePath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFilePath.ForeColor = System.Drawing.Color.Blue
        Me.txtFilePath.Location = New System.Drawing.Point(12, 12)
        Me.txtFilePath.Name = "txtFilePath"
        Me.txtFilePath.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtFilePath.Size = New System.Drawing.Size(679, 21)
        Me.txtFilePath.TabIndex = 3
        Me.txtFilePath.Text = "G:\Projects\Rayan PartoNegar\R&D\00 - PMS\Database\Stored Procedures"
        '
        'btnLoadFilesName
        '
        Me.btnLoadFilesName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLoadFilesName.Location = New System.Drawing.Point(697, 9)
        Me.btnLoadFilesName.Name = "btnLoadFilesName"
        Me.btnLoadFilesName.Size = New System.Drawing.Size(75, 23)
        Me.btnLoadFilesName.TabIndex = 4
        Me.btnLoadFilesName.Text = "خواندن فایل ها"
        Me.btnLoadFilesName.UseVisualStyleBackColor = True
        '
        'btnReadTexts
        '
        Me.btnReadTexts.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReadTexts.Location = New System.Drawing.Point(12, 287)
        Me.btnReadTexts.Name = "btnReadTexts"
        Me.btnReadTexts.Size = New System.Drawing.Size(760, 23)
        Me.btnReadTexts.TabIndex = 5
        Me.btnReadTexts.Text = "خواندن متن فایل های انتخاب شده"
        Me.btnReadTexts.UseVisualStyleBackColor = True
        '
        'btnExecute
        '
        Me.btnExecute.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExecute.Location = New System.Drawing.Point(637, 529)
        Me.btnExecute.Name = "btnExecute"
        Me.btnExecute.Size = New System.Drawing.Size(135, 23)
        Me.btnExecute.TabIndex = 6
        Me.btnExecute.Text = "اجرای دستورات"
        Me.btnExecute.UseVisualStyleBackColor = True
        '
        'txtCs
        '
        Me.txtCs.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCs.ForeColor = System.Drawing.Color.Blue
        Me.txtCs.Location = New System.Drawing.Point(78, 529)
        Me.txtCs.Name = "txtCs"
        Me.txtCs.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCs.Size = New System.Drawing.Size(553, 21)
        Me.txtCs.TabIndex = 3
        Me.txtCs.Text = "Data Source=.\sqldeveloper; Initial Catalog = ImagingSystem; Integrated Security=" & _
            "True"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 533)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "رشته اتصال"
        '
        'txtSqlText
        '
        Me.txtSqlText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSqlText.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtSqlText.Location = New System.Drawing.Point(12, 316)
        Me.txtSqlText.Name = "txtSqlText"
        Me.txtSqlText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSqlText.Size = New System.Drawing.Size(760, 207)
        Me.txtSqlText.TabIndex = 8
        Me.txtSqlText.Text = ""
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 564)
        Me.Controls.Add(Me.txtSqlText)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnExecute)
        Me.Controls.Add(Me.btnReadTexts)
        Me.Controls.Add(Me.btnLoadFilesName)
        Me.Controls.Add(Me.txtCs)
        Me.Controls.Add(Me.txtFilePath)
        Me.Controls.Add(Me.lstFileNames)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.MinimumSize = New System.Drawing.Size(800, 600)
        Me.Name = "Form1"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "خواندن اطلاعات فایل های اس كیو ال"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstFileNames As System.Windows.Forms.CheckedListBox
    Friend WithEvents txtFilePath As System.Windows.Forms.TextBox
    Friend WithEvents btnLoadFilesName As System.Windows.Forms.Button
    Friend WithEvents btnReadTexts As System.Windows.Forms.Button
    Friend WithEvents btnExecute As System.Windows.Forms.Button
    Friend WithEvents txtCs As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSqlText As System.Windows.Forms.RichTextBox

End Class
