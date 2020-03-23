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

        Dim controle As New clsAdicionar
        Dim pontoJson = DeserializarNewtonsoft(json)
        ' Dim atividade = funRetornaAtividade(atividadejson)

        ' If controle.Gravar(atividade) Then
        ' Return "Sucesso"
        ' End If


    End Function



    Private Function DeserializarNewtonsoft(json As String) As clsPontoWeb
        Return Newtonsoft.Json.JsonConvert.DeserializeObject(Of clsPontoWeb)(json)
    End Function


End Class

Public Class clsPontoWeb
    Public Property id_Ponto As String
    Public Property dataPonto As String
    Public Property horaTotal As String
    Public Property horaEntrada As String
    Public Property horaSaida As String

    Public Property Periodo As IEnumerable(Of clsPeriodoPontoWeb)

End Class

Public Class clsPeriodoPontoWeb
    Public Property ID As String
    Public Property Entrada As String
    Public Property Saida As String
    Public Property Total As String
End Class

