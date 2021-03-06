﻿Public Class frmCadastroTipoAtividade

    Private controle As New clsCadastroTipoAtividade
    Private listaTipo As New List(Of clsTipo)
    Private listaTipoExcluidos As New List(Of clsTipo)

    Private indexAlteracao As Integer = -1

    Private Enum enuColunas
        EXCLUIR = 0
        ID = 1
        CODIGO = 2
        DESCRICAO = 3
    End Enum

    Private Sub frmCadastroTipoAtividade_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CarregaFormulario()
    End Sub

    Private Sub CarregaFormulario()

        subHabilitaCampos(False)

        indexAlteracao = -1

        subLimpaCampos()

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
        gridTipo.Columns("EXCLUIR").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    End Sub

    Private Sub gridTipo_DoubleClick(sender As Object, e As EventArgs) Handles gridTipo.DoubleClick
        indexAlteracao = gridTipo.CurrentCell.RowIndex
        txtCodigo.Text = listaTipo(indexAlteracao).CODIGO
        txtDescricao.Text = listaTipo(indexAlteracao).DESCRICAO

        subHabilitaCampos(True)
    End Sub

    Private Sub txtDescricao_Leave(sender As Object, e As EventArgs) Handles txtDescricao.Leave

        Try
            If Not txtDescricao.Enabled Then Exit Sub

            If Not controle.ValidaCampoDescricao(txtDescricao.Text, indexAlteracao) Then Exit Sub
        Catch ex As Exception
            clsTools.subTrataExcessao(ex)
            txtDescricao.Focus()
            Exit Sub
        End Try

        If indexAlteracao >= 0 Then
            listaTipo(indexAlteracao).DESCRICAO = txtDescricao.Text
        Else
            AdicionaTipo()
        End If

        subAtualizaGrid()
    End Sub

    Private Sub AdicionaTipo()
        Dim tipo As New clsTipo
        tipo.CODIGO = Val(txtCodigo.Text)
        tipo.DESCRICAO = txtDescricao.Text
        listaTipo.Add(tipo)
    End Sub

    Private Sub subLimpaCampos()
        txtCodigo.Clear()
        txtDescricao.Clear()

        subHabilitaCampos(False)
    End Sub

    Private Sub subAtualizaGrid()
        gridTipo.DataSource = Nothing
        gridTipo.DataSource = listaTipo
        subConfiguraGrid()
        gridTipo.Refresh()

        indexAlteracao = -1
        subLimpaCampos()
    End Sub

    Private Sub txtCodigo_Leave(sender As Object, e As EventArgs) Handles txtCodigo.Leave
        Try
            If Not controle.ValidaCampoCodigo(Val(txtCodigo.Text), indexAlteracao, listaTipo) Then Exit Sub
        Catch ex As Exception
            clsTools.subTrataExcessao(ex)
            txtCodigo.Focus()
            Exit Sub
        End Try

        If indexAlteracao > -1 Then
            listaTipo(indexAlteracao).CODIGO = Val(txtCodigo.Text)
        End If

    End Sub

    Private Sub btnLimpar_Click(sender As Object, e As EventArgs) Handles btnLimpar.Click
        CarregaFormulario()
    End Sub

    Private Sub gridTipo_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridTipo.CellClick
        If (e.ColumnIndex = enuColunas.EXCLUIR) Then
            subExcluiTipoAtividade(e)
        End If
    End Sub

    Private Sub subExcluiTipoAtividade(e As DataGridViewCellEventArgs)
        Try

            If funValidaExcludsao(e.RowIndex) Then
                listaTipoExcluidos.Add(listaTipo(e.RowIndex))
                listaTipo.RemoveAt(e.RowIndex)
                subAtualizaGrid()
            End If

        Catch ex As Exception
            clsTools.subTrataExcessao(ex)
        End Try
    End Sub

    Private Function funValidaExcludsao(rowIndex As Integer) As Boolean

        If Not controle.ValidaExclusao(listaTipo(rowIndex)) Then
            Return False
        End If

        Return True

    End Function

    Private Sub subHabilitaCampos(ByVal valor As Boolean)
        txtCodigo.Enabled = valor
        txtDescricao.Enabled = valor
    End Sub

    Private Sub btnNovo_Click(sender As Object, e As EventArgs) Handles btnNovo.Click
        subHabilitaCampos(True)
        txtCodigo.Focus()
    End Sub

    Private Sub btnGravar_Click(sender As Object, e As EventArgs) Handles btnGravar.Click

        Try
            If controle.GravaTipos(listaTipo, listaTipoExcluidos) Then
                MsgBox("Gravado com Sucesso.", vbInformation)
            End If
        Catch ex As Exception
            clsTools.subTrataExcessao(ex)
        End Try

        subLimpaCampos()
    End Sub
End Class