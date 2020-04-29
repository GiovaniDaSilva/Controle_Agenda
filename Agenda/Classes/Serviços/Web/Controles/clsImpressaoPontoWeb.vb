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




        Return html
    End Function

End Class
