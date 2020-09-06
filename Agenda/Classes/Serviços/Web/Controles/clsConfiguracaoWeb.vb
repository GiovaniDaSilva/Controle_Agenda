Imports System.Text

Public Class clsConfiguracaoWeb

    Public Function RetornaPagina() As String
        Return GeraPagina()
    End Function

    Private Function GeraPagina() As String

        Dim parametros = New clsIni().funCarregaIni()
        Return RetornaHTML(parametros)

    End Function

    Private Function RetornaHTML(parametros As clsParametrosIni) As String
        Dim html As String
        html = My.Resources.Configuracao

        html = html.Replace("[p_pagina]", clsPaginasWeb.Configuracao)
        html = html.Replace("[p_inicializa_campos]", RetornaLinhasInicializacaoCampos(parametros))
        html = html.Replace("{p_lista_tempo_notificacao}", RetornaListaTipoAtividade(parametros.TempoNotificacao))

        CarregaRadioButton(html, parametros)

        Return html
    End Function

    Private Sub CarregaRadioButton(ByRef html As String, parametros As clsParametrosIni)
        Const CHECK = "checked"
        html = html.Replace("{p_hrTrab_checked}", If(parametros.Horastrabalhadas = enuHorasTrabalhadas.Total, CHECK, ""))
        html = html.Replace("{p_Perio_checked}", If(parametros.Horastrabalhadas = enuHorasTrabalhadas.Periodo, CHECK, ""))


        html = html.Replace("{pAusTtDiaSim_checked}", If(parametros.ConsideraTipoAusenteTotal, CHECK, ""))
        html = html.Replace("{p_AusTtDiaNao_checked}", If(Not parametros.ConsideraTipoAusenteTotal, CHECK, ""))

        html = html.Replace("{p_EmBranco_checked}", If(parametros.InicializarCampoApartirDe = enuApartirDe.Branco, CHECK, ""))
        html = html.Replace("{p_DataAtual_checked}", If(Not parametros.InicializarCampoApartirDe = enuApartirDe.Atual, CHECK, ""))
        html = html.Replace("{p_7dias_checked}", If(Not parametros.InicializarCampoApartirDe = enuApartirDe.Dias7, CHECK, ""))

        html = html.Replace("{p_web_checked}", If(parametros.UtilizarVersaoWeb, CHECK, ""))
        html = html.Replace("{p_desktop_checked}", If(Not parametros.UtilizarVersaoWeb, CHECK, ""))

        html = html.Replace("{p_Crescente_checked}", If(parametros.OrdenacaoDasAtividades = enuOrdenacaoDasAtividades.Cre, CHECK, ""))
        html = html.Replace("{p_Decrescente_checked}", If(parametros.OrdenacaoDasAtividades = enuOrdenacaoDasAtividades.Dec, CHECK, ""))
    End Sub

    Private Function RetornaListaTipoAtividade(tempoNotificacao As String) As String
        Dim retorno As New StringBuilder(vbNullString)
        Dim selected As String = "selected"

        Dim itens As New List(Of clsTempoNotificacao)

        itens.Add(New clsTempoNotificacao("1 Hora", enuTempoNotificacao.Hora1))
        itens.Add(New clsTempoNotificacao("2 Horas", enuTempoNotificacao.Hora2))
        itens.Add(New clsTempoNotificacao("3 Horas", enuTempoNotificacao.Hora3))
        itens.Add(New clsTempoNotificacao("4 Horas", enuTempoNotificacao.Hora4))
        itens.Add(New clsTempoNotificacao("Não Utilizar", enuTempoNotificacao.NaoUsar))

        For Each item In itens
            retorno.AppendFormat("<option value = ""{0}"" {1}> {2}</Option>", item.valor, IIf(item.valor = tempoNotificacao, selected, ""), item.descricao)
        Next

        Return retorno.ToString


    End Function

    Private Function RetornaLinhasInicializacaoCampos(parametros As clsParametrosIni) As String
        Dim texto As New StringBuilder(vbNullString)

        texto.AppendFormat("
            document.getElementById('emailBackup').value = ""{0}"";
            document.getElementById('caminhoBase').value = ""{1}"";
            document.getElementById('dataSaldoPonto').value = ""{2}"";            
        ", parametros.Email, parametros.CaminhoBase.Replace("\", "/"), clsTools.funAjustaDataSQL(parametros.AcumuladoPontoApartirDe))
        Return texto.ToString
    End Function

    Private Class clsTempoNotificacao
        Public Sub New(descricao As String, valor As String)
            Me.descricao = descricao
            Me.valor = valor
        End Sub

        Public Property descricao As String
        Public Property valor As String
    End Class
End Class
