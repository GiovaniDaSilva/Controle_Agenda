Public Class clsGraficoMensal



    Public Function subGeraDadosGrafico2(ByVal parDataInicial As Date, ByVal parDataFinal As Date) As clsAtividadesGraficoPrincipal


        Dim locListaAtividades = New clsAdicionarDAO().carregarAtividades(parDataInicial, parDataFinal)
        Dim locTotais As New clsAtividadesGraficoPrincipal
        Dim TimeTotal As TimeSpan

        If locListaAtividades.Count = 0 Then Return locTotais


        locTotais.Atividades = New List(Of clsAtividadesGrafico)

        'Carrega os Timer para cada tipo de ativdade
        For Each item In locListaAtividades
            If Trim(item.Horas.Replace(":", "")) = vbNullString Then
                Continue For
            End If

            locTotais.TotalHorasAtividades = locTotais.TotalHorasAtividades.Add(TimeSpan.Parse(item.Horas))

            'Se ainda não existe add a atividade ao grafico
            If Not locTotais.Atividades.Exists(Function(x) x.IdAtividade = item.ID_TIPO_ATIVIDADE) Then
                locTotais.Atividades.Add(New clsAtividadesGrafico(item.ID_TIPO_ATIVIDADE, item.TIPO_DESCRICAO))
            End If

            'Atualiza as horas da atividade
            Dim i = locTotais.Atividades.FindIndex(Function(x) x.IdAtividade = item.ID_TIPO_ATIVIDADE)
            If i > -1 Then
                locTotais.Atividades(i).TotalHoras = locTotais.Atividades(i).TotalHoras.Add(TimeSpan.Parse(item.Horas))
            End If
        Next

        Return locTotais

    End Function

End Class


