Imports System.Web

Public Class clsRequisicoesWeb

    Public Function trataRequisicoesWeb(pUri As Uri) As String
        Dim locPagRetorno As String = "Não encontrado"

        Select Case pUri.AbsolutePath
            Case "/Grafico/"
                locPagRetorno = funRetornaPaginaGrafico(pUri)
            Case "/Versoes/"
                locPagRetorno = My.Resources.Versoes
        End Select

        Return locPagRetorno
    End Function

    Private Function funRetornaPaginaGrafico(pUri As Uri) As String
        Dim locDataInicial = clsTools.RetornaPrimeiroDiaMes()
        Dim locDataFinal = clsTools.RetornaUltimoDiaMes()

        'Pode ser feito com array
        'Dim parts() As String
        'parts = pUri.ToString.Split(New Char() {"?", "&"})

        If pUri.Query <> vbNullString Then

            Dim mesGeracao = String.Join(String.Empty, pUri.ToString.Split("?").Skip(1)).Replace("meseslista=", "")

            If mesGeracao = vbNullString Then
                Throw New Exception("Parâmetros da Pagina estão inválidos.")
            End If

            locDataInicial = clsTools.RetornaPrimeiroDiaMes(mesGeracao)
            locDataFinal = clsTools.RetornaUltimoDiaMes(mesGeracao)
        End If


        Try
            Return New clsGraficoWeb().RetornaPaginaGrafico(locDataInicial, locDataFinal)
        Catch ex As Exception
            clsTools.subTrataExcessao(ex)
        End Try

        Return vbNullString
    End Function
End Class


