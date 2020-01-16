Public Class frmPrincipal
    Private controle As New clsPrincipal

    Private Sub btnAdicinar_Click(sender As Object, e As EventArgs) Handles btnAdicinar.Click
        controle.Adicionar()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim lista As List(Of clsAtividade)
        lista = controle.funCarregarAtividades()

        gridAtividades.DataSource = lista
        subConfiguraGridAtividade()
    End Sub

    Private Sub subConfiguraGridAtividade()
        gridAtividades.Columns("ID").Visible = False
        gridAtividades.Columns("DESCRICAO").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        gridAtividades.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub

    Private Sub btnListar_Click(sender As Object, e As EventArgs) Handles btnListar.Click

    End Sub
End Class
