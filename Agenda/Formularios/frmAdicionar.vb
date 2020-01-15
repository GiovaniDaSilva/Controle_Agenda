Public Class frmAdicionar
    Private Sub frmAdicionar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtData.Text = Now
    End Sub

    Private Sub btnLimpar_Click(sender As Object, e As EventArgs) Handles btnLimpar.Click
        subLimpaTela()
    End Sub

    Private Sub subLimpaTela()
        txtData.Text = Now
        cbTipo.SelectedIndex = -1
        txtCodigo.Clear()
        txtHora.Clear()
        txtDescricao.Clear()
    End Sub

    Private Sub btnGravar_Click(sender As Object, e As EventArgs) Handles btnGravar.Click
        Dim locDados As New clsAdicionar
        If locDados.Gravar(funRetornaAtividade) Then
            MsgBox("Atividade gravada com sucesso.", MsgBoxStyle.Information)
            subLimpaTela()
        End If
    End Sub

    Private Function funRetornaAtividade() As clsAtividade
        Dim locAtividade As New clsAtividade

        locAtividade.Codigo = Val(txtCodigo.Text)
        locAtividade.Data = CDate(txtData.Text)
        locAtividade.Horas = txtHora.Text
        locAtividade.Tipo = cbTipo.GetItemText(cbTipo.SelectedItem)
        locAtividade.Descricao = txtDescricao.Text

        Return locAtividade
    End Function


End Class