Public Class frmHTML
    Dim HTML As String

    Public Function RetornarHTML() As String
        Me.ShowDialog()
        HTML = RichTextBox1.Text
        Return HTML
    End Function

    Private Sub RichTextBox1_Leave(sender As Object, e As EventArgs) Handles RichTextBox1.Leave
        HTML = RichTextBox1.Text
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        HTML = RichTextBox1.Text
        Me.Close()
    End Sub
End Class