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
        Try
            Return New clsGraficoWeb().RetornaPaginaGrafico
        Catch ex As Exception
            clsTools.subTrataExcessao(ex)
        End Try
        Return vbNullString
    End Function
End Class


