Imports System.Text

Public Class clsImpressaoPontoWeb

    Public Enum enuEstiloImpressao
        Data = 1
        Titulo = 2
        Titulo_Destaque = 3
        Informacao = 4
        Informacao_Destaque = 5
    End Enum

    Private Property html As New StringBuilder

    Public Function RetornaPagina(pDataInicial As Date, pDataFinal As Date) As String
        Return RetornaHTML(pDataInicial, pDataFinal)
    End Function

    Private Function RetornaHTML(pDataInicial As Date, pDataFinal As Date) As String

        Dim html As String
        html = My.Resources.ImpressaoPonto
        html = html.Replace("{p_meses_combo}", clsHTMLComum.RetornaMesesCombo(Month(pDataInicial)))
        html = html.Replace("{p_data_inicio}", clsTools.funFormataData(pDataInicial))
        html = html.Replace("{p_data_final}", clsTools.funFormataData(pDataFinal))
        html = html.Replace("{p_dados_impresso}", funRetornaDadosImpresso(pDataInicial, pDataFinal))

        Return html
    End Function

    Private Function funRetornaDadosImpresso(pDataInicial As Date, pDataFinal As Date) As String
        Dim listaPonto As New List(Of clsPonto)

        listaPonto = New clsControlePontoDAO().RetornaPontoPeriodo(pDataInicial, pDataFinal)

        subListaPontos(listaPonto)

        Return html.ToString
    End Function

    Private Sub subListaPontos(listaPonto As List(Of clsPonto))

        Dim dados As String = ""


        For Each ponto In listaPonto
            Dim linha = New List(Of String)
            linha.Add(ponto.dataPonto)
            linha.Add(ponto.horaTotal)
            linha.Add("[08:00 - 10:00] [13:30 - 18:00] [08:00 - 10:00] [13:30 - 18:00] [08:00 - 10:00]")
            linha.Add("-02:00")
            dados &= clsHTMLTools.funLinhaTabela(linha)
        Next


        html.Append(dados)

    End Sub

    Private Sub subImprimePonto(ponto As clsPonto)




    End Sub
End Class
