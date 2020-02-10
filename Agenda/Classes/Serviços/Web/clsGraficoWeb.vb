Imports System.Text

Public Class clsGraficoWeb
    Public Function RetornaPaginaGrafico(pDataInicial As Date, pDataFinal As Date) As String
        Dim locGrafico As New clsGraficoMensal
        Dim locDados As clsAtividadesGrafico

        locDados = locGrafico.subGeraDadosGrafico(pDataInicial, pDataFinal)

        Return GeraPagina(locDados, pDataInicial, pDataFinal)

    End Function

    Private Function GeraPagina(ByVal parDados As clsAtividadesGrafico, pDataInicial As Date, pDataFinal As Date) As String
        Dim locTipoAtividades As New List(Of String)
        Dim locValores As New List(Of String)


        If parDados.TotalHorasAtividades <= 0 Then
            locTipoAtividades.Add("Sem apontamentos neste período.")
            locValores.Add(100)
        End If

        If parDados.TotalHorasSolicitacoes > 0 Then
            locTipoAtividades.Add(enuTipoAtividade.Solicitacao)
            locValores.Add(parDados.PercentualSolicitacoes)
        End If

        If parDados.TotalHorasPBI > 0 Then
            locTipoAtividades.Add(enuTipoAtividade.PBI)
            locValores.Add(parDados.PercentualPBI)
        End If

        If parDados.TotalHorasReuniao > 0 Then
            locTipoAtividades.Add(enuTipoAtividade.Reuniao)
            locValores.Add(parDados.PercentualReuniao)
        End If

        If parDados.TotalHorasAusente > 0 Then
            locTipoAtividades.Add(enuTipoAtividade.Ausente)
            locValores.Add(parDados.PercentualAusente)
        End If

        If parDados.TotalHorasOutros > 0 Then
            locTipoAtividades.Add(enuTipoAtividade.Outros)
            locValores.Add(parDados.PercentualOutros)
        End If

        Return RetornaHTML(locTipoAtividades, locValores, pDataInicial, pDataFinal)

    End Function

    Private Function RetornaHTML(locTipoAtividades As List(Of String), locValores As List(Of String), pDataInicial As Date, pDataFinal As Date) As String
        Dim html As String
        html = My.Resources.GraficoAtividades

        html = html.Replace("{p_atividades}", clsTools.RetornArrayLista(locTipoAtividades, True))

        html = html.Replace("{p_valores}", clsTools.RetornArrayLista(locValores))

        html = html.Replace("{p_linhas_tabela}", RetornaLinhasTabela(locTipoAtividades, locValores))

        html = html.Replace("{p_data_inicio}", clsTools.funFormataData(pDataInicial))
        html = html.Replace("{p_data_final}", clsTools.funFormataData(pDataFinal))

        html = html.Replace("{p_meses_combo}", RetornaMesesCombo(Month(pDataInicial)))

        Return html
    End Function

    Private Function RetornaLinhasTabela(locTipoAtividades As List(Of String), locValores As List(Of String)) As String
        Dim locRetorno As String = vbNullString

        For i = 0 To locTipoAtividades.Count - 1
            Dim linha = New List(Of String)
            linha.Add(locTipoAtividades(i).ToString)
            linha.Add(locValores(i).ToString & " %")
            locRetorno &= clsHTMLTools.funLinhaTabela(linha)
        Next

        Return locRetorno

    End Function

    Private Function RetornaMesesCombo(pMesFiltro As Integer) As String
        Dim retorno As New StringBuilder(vbNullString)
        Dim selected As String = "selected"

        retorno.AppendFormat("<option value = ""1"" {0}> Janeiro</Option>", IIf(pMesFiltro = 1, selected, ""))
        retorno.AppendFormat("<option value = ""2"" {0}> Fevereiro</Option>", IIf(pMesFiltro = 2, selected, ""))
        retorno.AppendFormat("<option value = ""3"" {0}> Março</Option>", IIf(pMesFiltro = 3, selected, ""))
        retorno.AppendFormat("<option value = ""4"" {0}> Abril</Option>", IIf(pMesFiltro = 4, selected, ""))
        retorno.AppendFormat("<option value = ""5"" {0}> Maio</Option>", IIf(pMesFiltro = 5, selected, ""))
        retorno.AppendFormat("<option value = ""6"" {0}> Junho</Option>", IIf(pMesFiltro = 6, selected, ""))
        retorno.AppendFormat("<option value = ""7"" {0}> Julho</Option>", IIf(pMesFiltro = 7, selected, ""))
        retorno.AppendFormat("<option value = ""8"" {0}> Agosto</Option>", IIf(pMesFiltro = 8, selected, ""))
        retorno.AppendFormat("<option value = ""9"" {0}> Setembro</Option>", IIf(pMesFiltro = 9, selected, ""))
        retorno.AppendFormat("<option value = ""10"" {0}> Outubro</Option>", IIf(pMesFiltro = 10, selected, ""))
        retorno.AppendFormat("<option value = ""11"" {0}> Novembro</Option>", IIf(pMesFiltro = 11, selected, ""))
        retorno.AppendFormat("<option value = ""12"" {0}> Dezembro</Option>", IIf(pMesFiltro = 12, selected, ""))

        Return retorno.ToString

    End Function
End Class
