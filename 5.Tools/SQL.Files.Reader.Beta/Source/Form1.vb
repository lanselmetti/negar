Option Strict Off
Imports System.Collections.ObjectModel
Imports System.Text

Public Class Form1

    Private Sub btnLoadFilesName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadFilesName.Click
        Dim MyFiles As ReadOnlyCollection(Of String)
        Try
            MyFiles = My.Computer.FileSystem.FindInFiles( _
            txtFilePath.Text, "", True, FileIO.SearchOption.SearchAllSubDirectories, "*.Sql")
        Catch ex As Exception
            Exit Sub
        End Try
        
        Dim FileList As ArrayList = New ArrayList

        For Each FileName As String In MyFiles
            If String.Equals(Mid(FileName, FileName.Length - 2, FileName.Length), _
            "Sql", StringComparison.CurrentCultureIgnoreCase) Then
                FileList.Add(FileName)
            End If
        Next

        lstFileNames.DataSource = FileList

        For index As Integer = 0 To lstFileNames.Items.Count - 1
            lstFileNames.SetItemChecked(index, True)
        Next
    End Sub

    Private Sub btnReadTexts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReadTexts.Click

        Dim SqlString As StringBuilder = New StringBuilder()

        For index As Integer = 0 To lstFileNames.Items.Count - 1
            If lstFileNames.GetItemChecked(index) Then
                SqlString.Append(System.IO.File.ReadAllText(lstFileNames.Items(index).ToString, Encoding.Default))
                SqlString.Append(vbNewLine)
                SqlString.Append(vbNewLine)
                SqlString.Append( _
                "-- EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE" + _
                "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE")
                SqlString.Append(vbNewLine)
                SqlString.Append(vbNewLine)
            End If
        Next

        txtSqlText.Text = SqlString.ToString()
        txtSqlText.SelectAll()
        txtSqlText.Focus()
        txtSqlText.Copy()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtFilePath.Text = My.Computer.FileSystem.CurrentDirectory
    End Sub

    Private Sub btnExecute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExecute.Click
        Dim MySqlCommand As New SqlClient.SqlCommand(txtSqlText.Text, New SqlClient.SqlConnection(txtCs.Text))
        Try
            MySqlCommand.Connection.Open()
            MySqlCommand.ExecuteNonQuery()
        Catch Ex As Exception
            MessageBox.Show(Ex.Message)
        Finally
            MySqlCommand.Connection.Close()
            MySqlCommand.Dispose()
        End Try
    End Sub
End Class
