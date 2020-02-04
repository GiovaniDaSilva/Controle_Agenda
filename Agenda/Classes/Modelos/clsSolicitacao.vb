Public Class clsSolicitacao
    Public Sub New(codigo As Integer, uF As String, resumo As String, objeto As String, subTipo As String, situacao As String)
        Me.Codigo = codigo
        Me.UF = uF
        Me.Resumo = resumo
        Me.Objeto = objeto
        Me.SubTipo = subTipo
        Me.Situacao = situacao
    End Sub
    Public Sub New()

    End Sub

    Public Property ID As Integer
    Public Property Codigo As Integer
    Public Property UF As String
    Public Property Resumo As String
    Public Property Objeto As String
    Public Property SubTipo As String
    Public Property Situacao As String
    Public Property ID_ATIVIDADE As Integer


    Public Shared Function funCarregaDetalhesSolicitacoes(pHTML As String) As List(Of clsSolicitacao)
        Return clsHTML.funCarregaSolicitacoes(pHTML)
    End Function

End Class
