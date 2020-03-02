Public Class frmCadastroTipoAtividade

    Private controle As New clsCadastroTipoAtividade
    Private listaTipo As New List(Of clsTipo)

    Private indexAlteracao As Integer = -1

    Private Enum enuColunas
        ID = 0
        CODIGO = 1
        DESCRICAO = 2
    End Enum

    Private Sub frmCadastroTipoAtividade_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CarregaFormulario()
    End Sub

    Private Sub CarregaFormulario()

        indexAlteracao = -1

        txtCodigo.Clear()
        txtDescricao.Clear()

        listaTipo = controle.CarregarTiposAtividades()
        gridTipo.DataSource = listaTipo

        subConfiguraGrid()

        If Not gridTipo.CurrentRow Is Nothing Then
            gridTipo.CurrentRow.Selected = False
        End If
    End Sub

    Private Sub subConfiguraGrid()
        gridTipo.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        gridTipo.Columns("ID").Visible = False
        gridTipo.Columns("CODIGO").HeaderText = "Código"
        gridTipo.Columns("DESCRICAO").HeaderText = "Descrição"
        gridTipo.Columns("DESCRICAO").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub

    Private Sub gridTipo_DoubleClick(sender As Object, e As EventArgs) Handles gridTipo.DoubleClick
        indexAlteracao = gridTipo.CurrentCell.RowIndex
        txtCodigo.Text = listaTipo(indexAlteracao).CODIGO
        txtDescricao.Text = listaTipo(indexAlteracao).DESCRICAO
    End Sub

    Private Sub txtDescricao_Leave(sender As Object, e As EventArgs) Handles txtDescricao.Leave

        Try
            If Not controle.ValidaCampoDescricao(txtDescricao.Text, indexAlteracao) Then Exit Sub
        Catch ex As Exception
            clsTools.subTrataExcessao(ex)
            txtDescricao.Focus()
            Exit Sub
        End Try

        listaTipo(indexAlteracao).DESCRICAO = txtDescricao.Text
        subAtualizaGrid()
    End Sub



    Private Sub subAtualizaGrid()
        gridTipo.Refresh()
    End Sub

    Private Sub txtCodigo_Leave(sender As Object, e As EventArgs) Handles txtCodigo.Leave
        Try
            If Not controle.ValidaCampoCodigo(Val(txtCodigo.Text), indexAlteracao, listaTipo) Then Exit Sub
        Catch ex As Exception
            clsTools.subTrataExcessao(ex)
            txtCodigo.Text = listaTipo(indexAlteracao).CODIGO
            txtCodigo.Focus()
            Exit Sub
        End Try

        listaTipo(indexAlteracao).CODIGO = Val(txtCodigo.Text)
        subAtualizaGrid()
    End Sub

    Private Sub btnLimpar_Click(sender As Object, e As EventArgs) Handles btnLimpar.Click
        CarregaFormulario()
    End Sub
End Class