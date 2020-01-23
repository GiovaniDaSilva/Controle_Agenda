Public Class frmBrowser
    Private Sub frmBrowser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WebBrowser1.Navigate("about:blank")
        Me.WebBrowser1.Document.Write(String.Empty)
        Me.WebBrowser1.DocumentText = My.Resources.Versoes
    End Sub
End Class