Public Class clsCadastroAtividadeWeb

    Public Function RetornaPaginaCadastroAtividade() As String

        Return My.Resources.CadastroAtividade


    End Function

    Friend Function RetornaCadastroAtividade_Salvar(json As String) As String

        Dim atividade = DeserializarNewtonsoft(json)


        Return json.ToString
    End Function




    'Private Function DeserializarNewtonsoft(json As String) As List(Of clsPeriodoWeb)
    ' 'Dim Json = System.IO.File.ReadAllText("pedidos2.json")
    ' Return Newtonsoft.Json.JsonConvert.DeserializeObject(Of List(Of clsPeriodoWeb))(json)
    ' End Function

    Private Function DeserializarNewtonsoft(json As String) As clsAtividadeWeb
        'Dim Json = System.IO.File.ReadAllText("pedidos2.json")
        Return Newtonsoft.Json.JsonConvert.DeserializeObject(Of clsAtividadeWeb)(json)
    End Function

End Class



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

'{"dataAtividade""","tipoAtividade":"1","codigoAtividade":"","horaTotal":"","horaInicio":"","horaFinal":"","descricaoAtividade":"","
'Periodo":[{"ID":"1","De":"08:00","Até":"10:30","Total":"02:30"},{"ID":"2","De":"08:00","Até":"10:30","Total":"02:30"},{"ID":"3","De":"08:00","Até":"10:30","Total":"02:30"},{"ID":"4","De":"08:00","Até":"10:30","Total":"02:30"},{"ID":"5","De":"08:00","Até":"10:30","Total":"02:30"},{"ID":"6","De":"08:00","Até":"10:30","Total":"02:30"},{"ID":"7","De":"08:00","Até":"10:30","Total":"02:30"},{"ID":"8","De":"08:00","Até":"10:30","Total":"02:30"}]}
