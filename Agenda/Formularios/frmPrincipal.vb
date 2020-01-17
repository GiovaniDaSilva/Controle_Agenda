Imports Agenda

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

        subAtualizaLista
    End Sub

    Private Sub subRemoveSelecao()
        If Not gridAtividades.CurrentRow Is Nothing Then
            gridAtividades.CurrentRow.Selected = False
        End If

        txtDescricao.Clear()
    End Sub

    Private Sub btnAtualiza_Click(sender As Object, e As EventArgs) Handles btnAtualiza.Click
        subAtualizaLista()
    End Sub

    Private Sub subAtualizaLista()
        lista = controle.funCarregarAtividades(clsTools.funRetornaData(txtApartirDe))

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
        Dim locAlterou As Boolean = Not lista(gridAtividades.CurrentCell.RowIndex).Descricao.Equals(txtDescricao.Text)

        lista(gridAtividades.CurrentCell.RowIndex).Descricao = txtDescricao.Text
        gridAtividades.Refresh()

        If locAlterou Then controle.GravaDescricao(lista(gridAtividades.CurrentCell.RowIndex))
    End Sub
    

    Private Sub gridAtividades_Click(sender As Object, e As EventArgs) Handles gridAtividades.Click
        txtDescricao.Text = lista(gridAtividades.CurrentCell.RowIndex).Descricao
    End Sub

    Private Sub gridAtividades_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridAtividades.CellClick
        If (e.ColumnIndex = enuIndexColunas.EDITAR) Then            
            subChamaFormularioAdicionarEdicao(e.RowIndex)
        End If
    End Sub

    Private Sub subChamaFormularioAdicionarEdicao(i As Integer)
        controle.Adicionar(New clsAtividade(lista(i).ID, lista(i).Data, lista(i).Codigo, lista(i).Horas, lista(i).Descricao, lista(i).ID_TIPO_ATIVIDADE))
        subAtualizaLista 
    End Sub

    Private Sub frmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        subAtualizaLista 
    End Sub
End Class
