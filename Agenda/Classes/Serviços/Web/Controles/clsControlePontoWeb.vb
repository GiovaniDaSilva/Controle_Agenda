Public Class clsControlePontoWeb
    Public Function RetornaPagina() As String
        Return RetornaHTML()
    End Function


    Private Function RetornaHTML() As String
        Dim html As String
        html = My.Resources.ControlePonto

        html = html.Replace("[p_id_ponto]", 0)

        Return html
    End Function


    Friend Function RetornaControlePonto_Salvar(json As String) As String
        RetornaControlePonto_Salvar = "Erro"

        Dim controle As New clsControlePonto
        Dim pontoJson = DeserializarNewtonsoft(json)

        controle.Gravar(pontoJson)

        Return "Sucesso"

    End Function



    Private Function DeserializarNewtonsoft(json As String) As clsPonto
        Return Newtonsoft.Json.JsonConvert.DeserializeObject(Of clsPonto)(json)
    End Function


End Class


