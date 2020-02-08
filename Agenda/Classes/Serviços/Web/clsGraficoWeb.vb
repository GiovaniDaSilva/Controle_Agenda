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

        'Return My.Resources.GraficoAtividades.Replace("{p_atividades}", "'PBI', 'Solicitações', 'Reunião', 'Ausente'").Replace("{p_valores}", "51.28, 35.89, 10.25, 2.56")

        'Return My.Resources.GraficoAtividades.Replace("{p_atividades}", clsTools.RetornArrayLista(locTipoAtividades, True)).Replace("{p_valores}", clsTools.RetornArrayLista(locValores))

        Return html
    End Function


End Class
