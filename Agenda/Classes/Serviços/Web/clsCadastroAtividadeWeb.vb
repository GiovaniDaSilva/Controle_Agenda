Public Class clsCadastroAtividadeWeb

    Public Function RetornaPaginaCadastroAtividade() As String
        Return My.Resources.CadastroAtividade
    End Function


    Friend Function RetornaCadastroAtividade_Salvar(json As String) As String

        Dim atividade = DeserializarNewtonsoft(json)


        Return json.ToString
    End Function

    Private Function DeserializarNewtonsoft(json As String) As clsAtividadeWeb
        Return Newtonsoft.Json.JsonConvert.DeserializeObject(Of clsAtividadeWeb)(json)
    End Function

End Class


''' <summary>
''' Classes para carregar a partir do json
''' </summary>
Public Class clsAtividadeWeb
    Public Property dataAtividade As Date
    Public Property tipoAtividade As Integer
    Public Property codigoAtividade As Integer
    Public Property horaTotal As String
    Public Property horaInicio As String
    Public Property horaFinal As String
    Public Property descricaoAtividade As String

    Public Property Periodo As IEnumerable(Of clsPeriodoWeb)

End Class

Public Class clsPeriodoWeb
    Public Property ID As Integer
    Public Property De As String
    Public Property Ate As String
    Public Property Total As String
End Class
