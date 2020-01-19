Public Class frmAdicionar
    Dim controle As New clsAdicionar
    Dim glfAtividade As New clsAtividade

    Private Sub frmAdicionar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If txtData.Text = vbNullString Then txtData.Text = Now
        subValidaComboTipo()
    End Sub

    Private Sub subValidaComboTipo()
        If cbTipo.Items.Count = 0 Then
            controle.CarregaComboTipo(cbTipo)
        End If
    End Sub

    Private Sub btnLimpar_Click(sender As Object, e As EventArgs) Handles btnLimpar.Click
        subLimpaTela()
    End Sub

    Private Sub subLimpaTela()
        txtData.Text = Now
        cbTipo.SelectedIndex = -1
        txtCodigo.Clear()
        txtHora.Clear()
        txtDescrição.Clear()

        glfAtividade = Nothing
        btnExcluir.Visible = False
    End Sub

    Private Sub btnGravar_Click(sender As Object, e As EventArgs) Handles btnGravar.Click
        If controle.Gravar(funRetornaAtividade) Then
            MsgBox("Atividade gravada com sucesso.", MsgBoxStyle.Information)
        End If
        Me.Close()
    End Sub

    Private Function funRetornaAtividade() As clsAtividade
        If glfAtividade Is Nothing Then glfAtividade = New clsAtividade
        glfAtividade.Codigo = Val(txtCodigo.Text)
        glfAtividade.Data = clsTools.funRetornaData(txtData)
        glfAtividade.Horas = txtHora.Text
        glfAtividade.ID_TIPO_ATIVIDADE = cbTipo.SelectedValue()
        glfAtividade.Descricao = txtDescrição.Text

        Return glfAtividade
    End Function

    Public Sub subCarregaAtividade(parAtividade As clsAtividade)

        glfAtividade = parAtividade

        If Not glfAtividade Is Nothing Then
            subValidaComboTipo
            txtCodigo.Text = glfAtividade.Codigo
            txtData.Text = glfAtividade.Data
            txtHora.Text = glfAtividade.Horas
            cbTipo.SelectedValue = glfAtividade.ID_TIPO_ATIVIDADE
            txtDescrição.Text = glfAtividade.Descricao

            btnExcluir.Visible = True
        End If

        Me.ShowDialog()
    End Sub

    Public Sub ChamaFormulario(Optional parAtividade As clsAtividade = Nothing)
        subCarregaAtividade(parAtividade)
    End Sub

    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click
        If controle.excluir(glfAtividade.ID) Then
            MsgBox("Excluido com sucesso.", MsgBoxStyle.Information)
        End If
        Me.Close()
    End Sub



End Class