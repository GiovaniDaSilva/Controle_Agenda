Public Class clsGraficoMensal

    Public Function subGeraDadosGrafico(ByVal parDataInicial As Date, ByVal parDataFinal As Date) As clsAtividadesGrafico


        Dim locListaAtividades = New clsAdicionarDAO().carregarAtividades(parDataInicial, parDataFinal)
        Dim locTotais As New clsAtividadesGrafico
        Dim TimeTotal As TimeSpan
        Dim TimeSol As TimeSpan
        Dim TimePBI As TimeSpan
        Dim TimeReu As TimeSpan
        Dim TimeAus As TimeSpan
        Dim TimeOut As TimeSpan

        If locListaAtividades.Count = 0 Then Return locTotais

        'Carrega os Timer para cada tipo de ativdade
        For Each item In locListaAtividades
            If Trim(item.Horas.Replace(":", "")) = vbNullString Then
                Continue For
            End If

            TimeTotal = TimeTotal.Add(TimeSpan.Parse(item.Horas))

            Select Case item.ID_TIPO_ATIVIDADE
                Case enuTipoAtividades.Solicitacao : TimeSol = TimeSol.Add(TimeSpan.Parse(item.Horas))
                Case enuTipoAtividades.PBI : TimePBI = TimePBI.Add(TimeSpan.Parse(item.Horas))
                Case enuTipoAtividades.Reuniao : TimeReu = TimeReu.Add(TimeSpan.Parse(item.Horas))
                Case enuTipoAtividades.Ausente : TimeAus = TimeAus.Add(TimeSpan.Parse(item.Horas))
                Case enuTipoAtividades.Outros : TimeOut = TimeOut.Add(TimeSpan.Parse(item.Horas))
            End Select
        Next


        locTotais.TotalHorasAtividades = funRetornaMinutos(TimeTotal)
        locTotais.TotalHorasSolicitacoes = funRetornaMinutos(TimeSol)
        locTotais.TotalHorasPBI = funRetornaMinutos(TimePBI)
        locTotais.TotalHorasReuniao = funRetornaMinutos(TimeReu)
        locTotais.TotalHorasAusente = funRetornaMinutos(TimeAus)
        locTotais.TotalHorasOutros = funRetornaMinutos(TimeOut)

        Return locTotais

    End Function

    Private Function funRetornaMinutos(timeAux As TimeSpan) As Double
        Return (timeAux.TotalHours * 60) + timeAux.Minutes
    End Function



    Public Enum enuTipoAtividades
        Solicitacao = 1
        PBI = 2
        Reuniao = 3
        Ausente = 4
        Outros = 5
    End Enum
End Class


