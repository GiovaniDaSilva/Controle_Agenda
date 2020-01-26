Public Class frmConfiguracoes
    Private glfParametros As New clsParametrosIni

    Public Function funChamaConfiguracao(ByVal parParametros As clsParametrosIni) As clsParametrosIni

        glfParametros = parParametros
        subCarregaCampos()
        Me.ShowDialog()

        If Not funValidaCaminhoBase() Then
            End
        End If


        If Not glfParametros Is Nothing Then
            subPreenheParametros()
            Dim ini As New clsIni
            ini.gravaArquivoini(glfParametros)
        End If

        Return glfParametros
    End Function

    Private Sub subCarregaCampos()
        cbInicializarWindows.Checked = clsRegistro.subExisteRegistroAplicacao()

        rbEmbranco.Checked = IIf(glfParametros.InicializarCampoApartirDe = enuApartirDe.Branco, True, False)
        rbDataAtual.Checked = IIf(glfParametros.InicializarCampoApartirDe = enuApartirDe.Atual, True, False)
        rbSeteDias.Checked = IIf(glfParametros.InicializarCampoApartirDe = enuApartirDe.Dias7, True, False)

        rbDecrescente.Checked = IIf(glfParametros.OrdenacaoDasAtividades = enuOrdenacaoDasAtividades.Dec, True, False)
        rbCrescente.Checked = IIf(glfParametros.OrdenacaoDasAtividades = enuOrdenacaoDasAtividades.Cre, True, False)

        rbSimHTML.Checked = glfParametros.SolicitarHTML
        rbNaoHTML.Checked = Not rbSimHTML.Checked

        txtCaminhoBase.Text = glfParametros.CaminhoBase

        rbHorasTrabalhadas.Checked = IIf(glfParametros.Horastrabalhadas = enuHorasTrabalhadas.Total, True, False)
        rbPeriodo.Checked = IIf(glfParametros.Horastrabalhadas = enuHorasTrabalhadas.Periodo, True, False)

        Select Case glfParametros.TempoNotificacao
            Case enuTempoNotificacao.Hora1 : cbTempoNotificacao.SelectedIndex = 0
            Case enuTempoNotificacao.Hora2 : cbTempoNotificacao.SelectedIndex = 1
            Case enuTempoNotificacao.Hora3 : cbTempoNotificacao.SelectedIndex = 2
            Case enuTempoNotificacao.Hora4 : cbTempoNotificacao.SelectedIndex = 3
            Case Else : cbTempoNotificacao.SelectedIndex = 1
        End Select

    End Sub

    Private Sub subPreenheParametros()
        If rbEmbranco.Checked Then
            glfParametros.InicializarCampoApartirDe = enuApartirDe.Branco
        ElseIf rbDataAtual.Checked Then
            glfParametros.InicializarCampoApartirDe = enuApartirDe.Atual
        Else
            glfParametros.InicializarCampoApartirDe = enuApartirDe.Dias7
        End If

        glfParametros.OrdenacaoDasAtividades = IIf(rbCrescente.Checked, enuOrdenacaoDasAtividades.Cre, enuOrdenacaoDasAtividades.Dec)
        glfParametros.SolicitarHTML = IIf(rbSimHTML.Checked, True, False)
        glfParametros.CaminhoBase = txtCaminhoBase.Text
        glfParametros.Horastrabalhadas = IIf(rbHorasTrabalhadas.Checked, enuHorasTrabalhadas.Total, enuHorasTrabalhadas.Periodo)

        Select Case cbTempoNotificacao.SelectedIndex
            Case 0 : glfParametros.TempoNotificacao = enuTempoNotificacao.Hora1
            Case 1 : glfParametros.TempoNotificacao = enuTempoNotificacao.Hora2
            Case 2 : glfParametros.TempoNotificacao = enuTempoNotificacao.Hora3
            Case 3 : glfParametros.TempoNotificacao = enuTempoNotificacao.Hora4
        End Select

    End Sub

    Private Sub cbInicializarWindows_CheckedChanged(sender As Object, e As EventArgs) Handles cbInicializarWindows.CheckedChanged
        If cbInicializarWindows.Checked Then
            clsRegistro.subRegistrarAplicacaoInicializacaoWindows()
        Else
            clsRegistro.subDesregistrarAplicacaoInicializacaoWindows()
        End If
    End Sub

    Private Sub txtCaminhoBase_Leave(sender As Object, e As EventArgs) Handles txtCaminhoBase.Leave
        If Not funValidaCaminhoBase() Then
            txtCaminhoBase.Focus()
        End If

    End Sub

    Private Function funValidaCaminhoBase() As Boolean

        Try
            clsConexao.CaminhoBase = txtCaminhoBase.Text
            If Not clsConexao.ExisteBase Then
                Throw New Exception("Caminho Inválido." & vbNewLine & "Inferme o diretório do arquivo da base de dados." & vbNewLine & "Ex: C:\Agenda\BancoAgenda.db")
            End If

        Catch ex As Exception
            clsTools.subTrataExcessao(ex)
            Return False
        End Try

        Return True

    End Function

    Private Sub frmConfiguracoes_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox("Deseja gravar as alterações?", MsgBoxStyle.YesNo, "Questão") = Windows.Forms.DialogResult.No Then
            glfParametros = Nothing
        End If

    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub
End Class