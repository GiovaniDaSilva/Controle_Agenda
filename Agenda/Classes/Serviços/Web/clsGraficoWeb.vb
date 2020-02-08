Public Class clsGraficoWeb
    Public Function RetornaPaginaGrafico() As String
        Dim locGrafico As New clsGraficoMensal
        Dim locDados As clsAtividadesGrafico

        locDados = locGrafico.subGeraDadosGrafico()

        Return GeraPagina(locDados)

    End Function

    Private Function GeraPagina(ByVal parDados As clsAtividadesGrafico) As String
        Dim locTipoAtividades As New List(Of String)
        Dim locValores As New List(Of Double)


        If parDados.TotalHorasAtividades <= 0 Then
            Throw New Exception("Sem informação a gerar no gráfico.")
        End If

        If parDados.TotalHorasSolicitacoes > 0 Then
            locTipoAtividades.Add(enuTipoAtividade.Solicitacao)
            locValores.Add(parDados.TotalHorasSolicitacoes)
        End If

        If parDados.TotalHorasPBI > 0 Then
            locTipoAtividades.Add(enuTipoAtividade.PBI)
            locValores.Add(parDados.TotalHorasPBI)
        End If

        If parDados.TotalHorasReuniao > 0 Then
            locTipoAtividades.Add(enuTipoAtividade.Reuniao)
            locValores.Add(parDados.TotalHorasReuniao)
        End If

        If parDados.TotalHorasAusente > 0 Then
            locTipoAtividades.Add(enuTipoAtividade.Ausente)
            locValores.Add(parDados.TotalHorasAusente)
        End If

        If parDados.TotalHorasOutros > 0 Then
            locTipoAtividades.Add(enuTipoAtividade.Outros)
            locValores.Add(parDados.TotalHorasOutros)
        End If



    End Function

End Class
