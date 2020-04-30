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
            Dim linha = New List(Of clsColunasTabela)
            linha.Add(New clsColunasTabela(funRetornaData(ponto)))
            linha.Add(New clsColunasTabela(ponto.horaTotal))
            linha.Add(New clsColunasTabela(funRetornaPeriodo(ponto.Periodo)))
            linha.Add(New clsColunasTabela(funRetornaSaldoDia(ponto), "class='text-right'"))
            dados &= clsHTMLTools.funLinhaTabela(linha)
        Next


        html.Append(dados)

    End Sub

    Private Function funRetornaSaldoDia(ponto As clsPonto) As String
        Dim controle As New clsControlePonto

        Return controle.CalculaSaldoDia(ponto.dataPonto)
    End Function

    Private Function funRetornaPeriodo(periodo As List(Of clsPeriodoPonto)) As String
        Dim retorno As String = vbNullString

        For Each ponto In periodo
            retorno &= "[" & ponto.Entrada & "-" & ponto.Saida & "]  "
        Next

        Return retorno
    End Function

    Private Shared Function funRetornaData(ponto As clsPonto) As String
        Return clsTools.funFormataData(ponto.dataPonto) & "   " & clsTools.funRetornaDiaSemana(ponto.dataPonto, True)
    End Function

    Private Sub subImprimePonto(ponto As clsPonto)




    End Sub
End Class
