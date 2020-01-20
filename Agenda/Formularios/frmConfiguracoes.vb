﻿Public Class frmConfiguracoes
    Private glfParametros As New clsParametrosIni

    Public Function funChamaConfiguracao(parParametros As clsParametrosIni) As clsParametrosIni
        glfParametros = parParametros
        subCarregaCampos()
        Me.ShowDialog()

        If Not funValidaCaminhoBase() Then
            End
        End If

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

        txtCaminhoBase.Text = glfParametros.CaminhoBase
    End Sub

    Private Sub subPreenheParametros()
        glfParametros.InicializarCampoApartirDe = IIf(rbEmbranco.Checked, "Branco", "Atual")
        glfParametros.OrdenacaoDasAtividades = IIf(rbCrescente.Checked, "Cre", "Dec")
        glfParametros.SolicitarHTML = IIf(rbSimHTML.Checked, True, False)
        glfParametros.CaminhoBase = txtCaminhoBase.Text
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
End Class