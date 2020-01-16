Public Class frmPrincipal
    Private controle As New clsPrincipal
    Dim lista As List(Of clsConsultaAtividades)

    Private Enum enuPosicaoColunas
        DATA = 1
        TIPO = 2
        CODIGO = 3
        HORA = 4
        DESCRICAO = 5
        EDITAR = 6
    End Enum

    Private Enum enuIndexColunas
        EDITAR = 0
        DATA = 3
        TIPO = 1
        CODIGO = 4
        HORA = 5
        DESCRICAO = 6
    End Enum


    Private Sub btnAdicinar_Click(sender As Object, e As EventArgs) Handles btnAdicinar.Click
        subRemoveSelecao()
        controle.Adicionar()
    End Sub

    Private Sub subRemoveSelecao()
        gridAtividades.CurrentRow.Selected = False
        txtDescricao.Clear()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnAtualiza.Click
        lista = controle.funCarregarAtividades()

        gridAtividades.DataSource = lista
        subConfiguraGridAtividade()
        subRemoveSelecao()
    End Sub

    Private Sub subConfiguraGridAtividade()
        gridAtividades.Columns("ID").Visible = False
        gridAtividades.Columns("ID_TIPO_ATIVIDADE").Visible = False

        gridAtividades.Columns("DESCRICAO").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        gridAtividades.Columns("DESCRICAO").HeaderText = "Descrição"
        gridAtividades.Columns("TIPO_DESCRICAO").HeaderText = "Tipo"
        gridAtividades.SelectionMode = DataGridViewSelectionMode.FullRowSelect



        'Sequencia de colunas
        gridAtividades.Columns("DATA").DisplayIndex = enuPosicaoColunas.DATA
        gridAtividades.Columns("TIPO_DESCRICAO").DisplayIndex = enuPosicaoColunas.TIPO
        gridAtividades.Columns("CODIGO").DisplayIndex = enuPosicaoColunas.CODIGO
        gridAtividades.Columns("HORAS").DisplayIndex = enuPosicaoColunas.HORA
        gridAtividades.Columns("DESCRICAO").DisplayIndex = enuPosicaoColunas.DESCRICAO
        gridAtividades.Columns("EDITAR").DisplayIndex = enuPosicaoColunas.EDITAR
    End Sub

    Private Sub btnListar_Click(sender As Object, e As EventArgs) Handles btnListar.Click
        controle.subListarAtivdades(txtDescricao, lista)
    End Sub

    Private Sub txtDescricao_Leave(sender As Object, e As EventArgs) Handles txtDescricao.Leave
        lista(gridAtividades.CurrentCell.RowIndex).Descricao = txtDescricao.Text
        gridAtividades.Refresh()
    End Sub

    Private Sub gridAtividades_Click(sender As Object, e As EventArgs) Handles gridAtividades.Click
        txtDescricao.Text = lista(gridAtividades.CurrentCell.RowIndex).Descricao
    End Sub

    Private Sub gridAtividades_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridAtividades.CellClick
        If (e.ColumnIndex = enuIndexColunas.EDITAR) Then
            Dim i As Integer = e.RowIndex
            controle.Adicionar(New clsAtividade(lista(i).ID, lista(i).Data, lista(i).Codigo, lista(i).Horas, lista(i).Descricao, lista(i).ID_TIPO_ATIVIDADE))
        End If
    End Sub
End Class
