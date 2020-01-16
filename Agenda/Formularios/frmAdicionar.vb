Public Class frmAdicionar
    Dim controle As New clsAdicionar

    Private Sub frmAdicionar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtData.Text = Now 
        controle.CarregaComboTipo(cbTipo)
    End Sub

    Private Sub btnLimpar_Click(sender As Object, e As EventArgs) Handles btnLimpar.Click
        subLimpaTela()
    End Sub

    Private Sub subLimpaTela()
        txtData.Text = Now
        cbTipo.SelectedIndex = -1
        txtCodigo.Clear()
        txtHora.Clear()
        txtDescrição.Clear  
    End Sub

    Private Sub btnGravar_Click(sender As Object, e As EventArgs) Handles btnGravar.Click        
        If controle.Gravar(funRetornaAtividade) Then
            MsgBox("Atividade gravada com sucesso.", MsgBoxStyle.Information)
            subLimpaTela()
        End If
    End Sub

    Private Function funRetornaAtividade() As clsAtividade
        Dim locAtividade As New clsAtividade

        locAtividade.Codigo = Val(txtCodigo.Text)
        locAtividade.Data = CDate(txtData.Text)
        locAtividade.Horas = txtHora.Text
        locAtividade.ID_TIPO_ATIVIDADE   = cbTipo.SelectedValue() 
        locAtividade.Descricao = txtDescrição.Text  

        Return locAtividade
    End Function


End Class