Public Class frmHTML
    Dim HTML As String

    Public Function RetornarHTML() As String


        Me.ShowDialog()


        Return HTML


    End Function

    Private Sub RichTextBox1_Leave(sender As Object, e As EventArgs) Handles RichTextBox1.Leave
        HTML = RichTextBox1.Text
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Me.Close()
    End Sub
End Class