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

    Public Function RetornaPagina(pFiltro As clsAtividade) As String
        Return RetornaHTML(pFiltro)
    End Function

    Private Function RetornaHTML(pFiltro As clsAtividade) As String

        Dim html As String
        html = My.Resources.ImpressaoPonto



        Return html
    End Function

End Class
