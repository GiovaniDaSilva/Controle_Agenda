Public Class frmPrincipal
    Private controle As New clsPrincipal
    Dim lista As List(Of clsConsultaAtividades)

    Private Sub btnAdicinar_Click(sender As Object, e As EventArgs) Handles btnAdicinar.Click
        controle.Adicionar()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        lista = controle.funCarregarAtividades()

        gridAtividades.DataSource = lista
        subConfiguraGridAtividade()
    End Sub

    Private Sub subConfiguraGridAtividade()
        gridAtividades.Columns("ID").Visible = False
        gridAtividades.Columns("ID_TIPO_ATIVIDADE").Visible = False

        gridAtividades.Columns("DESCRICAO").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        gridAtividades.Columns("DESCRICAO").HeaderText  = "Descrição"

        gridAtividades.Columns("TIPO_DESCRICAO").DisplayIndex = 2
        gridAtividades.Columns("TIPO_DESCRICAO").HeaderText  = "Tipo"
        gridAtividades.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub

    Private Sub btnListar_Click(sender As Object, e As EventArgs) Handles btnListar.Click
        controle.subListarAtivdades(txtDescricao, lista)
    End Sub
        
    Private Sub txtDescricao_Leave(sender As Object, e As EventArgs) Handles txtDescricao.Leave
        lista(gridAtividades.CurrentCell.RowIndex).Descricao = txtDescricao.Text
        gridAtividades.Refresh
    End Sub

    Private Sub gridAtividades_Click(sender As Object, e As EventArgs) Handles gridAtividades.Click
        txtDescricao.Text = lista(gridAtividades.CurrentCell.RowIndex).Descricao 
    End Sub
End Class
