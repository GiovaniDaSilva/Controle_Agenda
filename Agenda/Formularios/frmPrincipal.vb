Public Class frmPrincipal
    Private controle As New clsPrincipal

    Private Sub btnAdicinar_Click(sender As Object, e As EventArgs) Handles btnAdicinar.Click
        controle.Adicionar()
    End Sub
End Class
