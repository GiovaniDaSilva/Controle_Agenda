Imports System.Text

Public Class clsGraficoWeb
    Public Function RetornaPaginaGrafico(pDataInicial As Date, pDataFinal As Date) As String
        Dim locGrafico As New clsGraficoMensal
        Dim locDados As clsAtividadesGraficoPrincipal

        locDados = locGrafico.subGeraDadosGrafico2(pDataInicial, pDataFinal)

        Return GeraPagina(locDados, pDataInicial, pDataFinal)

    End Function


    Private Function GeraPagina(ByVal parDados As clsAtividadesGraficoPrincipal, pDataInicial As Date, pDataFinal As Date) As String
        Dim locTipoAtividades As New List(Of String)
        Dim locValores As New List(Of String)


        If clsTools.funRetornaMinutos(parDados.TotalHorasAtividades) <= 0 Then
            locTipoAtividades.Add("Sem apontamentos neste período.")
            locValores.Add(100)
        End If

        If parDados.Atividades IsNot Nothing Then
            For Each item In parDados.Atividades

                If clsTools.funRetornaMinutos(item.TotalHoras) > 0 Then
                    locTipoAtividades.Add(item.DescricaoAtividade)
                    locValores.Add(item.RetornaPercentual(parDados.TotalHorasAtividades))
                End If
            Next
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

        html = html.Replace("{p_meses_combo}", clsHTMLComum.RetornaMesesCombo(Month(pDataInicial)))

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


End Class
