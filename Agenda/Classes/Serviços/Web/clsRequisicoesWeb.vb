Public Class clsRequisicoesWeb

    Public Function trataRequisicoesWeb(pUri As Uri) As String
        Dim locPagRetorno As String = "Não encontrado"

        Select Case pUri.AbsolutePath
            Case "/Grafico/"
                locPagRetorno = funRetornaPaginaGrafico()
            Case "/Versoes/"
                locPagRetorno = My.Resources.Versoes
        End Select

        Return locPagRetorno
    End Function

    Private Function funRetornaPaginaGrafico() As String
        Return My.Resources.GraficoAtividades.Replace("{p_atividades}", "'PBI', 'Solicitações', 'Reunião', 'Ausente'").Replace("{p_valores}", "51.28, 35.89, 10.25, 2.56")

        Return New clsGraficoWeb().RetornaPaginaGrafico
    End Function
End Class


