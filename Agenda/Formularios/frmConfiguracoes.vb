Public Class frmConfiguracoes
    Private glfParametros As New clsParametrosIni

    Public Function funChamaConfiguracao(parParametros As clsParametrosIni) As clsParametrosIni
        glfParametros = parParametros
        subCarregaCampos()
        Me.ShowDialog()

        subPreenheParametros()
        Dim ini As New clsIni
        ini.gravaArquivoini(glfParametros)
        Return glfParametros
    End Function

    Private Sub subCarregaCampos()
        cbInicializarWindows.Checked = clsRegistro.subExisteRegistroAplicacao()

        rbEmbranco.Checked = IIf(glfParametros.InicializarCampoApartirDe = "Branco", True, False)
        rbDataAtual.Checked = IIf(glfParametros.InicializarCampoApartirDe = "Atual", True, False)

        rbDecrescente.Checked = IIf(glfParametros.OrdenacaoDasAtividades = "Dec", True, False)
        rbCrescente.Checked = IIf(glfParametros.OrdenacaoDasAtividades = "Cre", True, False)

        rbSimHTML.Checked = glfParametros.SolicitarHTML
        rbNaoHTML.Checked = Not rbSimHTML.Checked
    End Sub

    Private Sub subPreenheParametros()
        glfParametros.InicializarCampoApartirDe = IIf(rbEmbranco.Checked, "Branco", "Atual")
        glfParametros.OrdenacaoDasAtividades = IIf(rbCrescente.Checked, "Cre", "Dec")
        glfParametros.SolicitarHTML = IIf(rbSimHTML.Checked, True, False)
    End Sub

    Private Sub cbInicializarWindows_CheckedChanged(sender As Object, e As EventArgs) Handles cbInicializarWindows.CheckedChanged
        If cbInicializarWindows.Checked Then
            clsRegistro.subRegistrarAplicacaoInicializacaoWindows()
        Else
            clsRegistro.subDesregistrarAplicacaoInicializacaoWindows()
        End If
    End Sub
End Class