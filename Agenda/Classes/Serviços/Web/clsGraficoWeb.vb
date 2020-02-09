Public Class clsGraficoWeb
    Public Function RetornaPaginaGrafico() As String
        Dim locGrafico As New clsGraficoMensal
        Dim locDados As clsAtividadesGrafico

        locDados = locGrafico.subGeraDadosGrafico()

        Return GeraPagina(locDados)

    End Function

    Private Function GeraPagina(ByVal parDados As clsAtividadesGrafico) As String
        Dim locTipoAtividades As New List(Of String)
        Dim locValores As New List(Of String)


        If parDados.TotalHorasAtividades <= 0 Then
            Throw New Exception("Sem informação a gerar no gráfico.")
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

        Return RetornaHTML(locTipoAtividades, locValores)

    End Function

    Private Function RetornaHTML(locTipoAtividades As List(Of String), locValores As List(Of String)) As String
        Dim html As String
        html = My.Resources.GraficoAtividades

        html = html.Replace("{p_atividades}", clsTools.RetornArrayLista(locTipoAtividades, True))

        html = html.Replace("{p_valores}", clsTools.RetornArrayLista(locValores))

        html = html.Replace("{p_linhas_tabela}", RetornaLinhasTabela(locTipoAtividades, locValores))

        html = html.Replace("{p_data_inicio}", clsTools.funFormataData(clsTools.RetornaPrimeiroDiaMes()))
        html = html.Replace("{p_data_final}", clsTools.funFormataData(clsTools.RetornaUltimoDiaMes()))

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
