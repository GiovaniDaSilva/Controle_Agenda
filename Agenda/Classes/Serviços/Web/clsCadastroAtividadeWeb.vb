Public Class clsCadastroAtividadeWeb

    Public Function RetornaPaginaCadastroAtividade() As String
        Return My.Resources.CadastroAtividade
    End Function


    Friend Function RetornaCadastroAtividade_Salvar(json As String) As String

        Dim atividade = DeserializarNewtonsoft(json)
        Dim controle As New clsAdicionar

        controle.Gravar(funRetornaAtividade(atividade))

        Return json.ToString
    End Function

    Private Function DeserializarNewtonsoft(json As String) As clsAtividadeWeb
        Return Newtonsoft.Json.JsonConvert.DeserializeObject(Of clsAtividadeWeb)(json)
    End Function

    Private Function funRetornaAtividade(atividade As clsAtividadeWeb) As clsAtividade
        Dim locAtividade As New clsAtividade
        Dim locPeriodos As New List(Of clsPeriodo)

        For Each periodo In atividade.Periodo

            If Not funValidaPeriodo(periodo) Then Continue For

            Dim aux As New clsPeriodo
            aux.Hora_Inicial = periodo.De
            aux.Hora_Final = periodo.Ate
            aux.Total = periodo.Total
            locPeriodos.Add(aux)
        Next

        With locAtividade
            .Codigo = IIf(atividade.codigoAtividade = vbNullString, "0", atividade.codigoAtividade)
            .Data = atividade.dataAtividade
            .Horas = IIf(atividade.horaTotal = vbNullString, "  :  ", atividade.horaTotal) 'informado : para mander o padrao do desktop
            .ID_TIPO_ATIVIDADE = atividade.tipoAtividade
            .Descricao = atividade.descricaoAtividade
            .Periodos = locPeriodos
        End With

        Return locAtividade
    End Function

    Private Function funValidaPeriodo(periodo As clsPeriodoWeb) As Boolean
        Try
            clsTools.funValidaHora(periodo.De)
            clsTools.funValidaHora(periodo.Ate)
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function
End Class


''' <summary>
''' Classes para carregar a partir do json
''' </summary>
Public Class clsAtividadeWeb
    Public Property dataAtividade As String
    Public Property tipoAtividade As Integer
    Public Property codigoAtividade As String
    Public Property horaTotal As String
    Public Property horaInicio As String
    Public Property horaFinal As String
    Public Property descricaoAtividade As String

    Public Property Periodo As IEnumerable(Of clsPeriodoWeb)

End Class

Public Class clsPeriodoWeb
    Public Property ID As String
    Public Property De As String
    Public Property Ate As String
    Public Property Total As String
End Class
