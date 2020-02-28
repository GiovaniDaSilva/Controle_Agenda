
Public Class clsAtividadesGraficoPrincipal

    Public Property TotalHorasAtividades As TimeSpan

    Public Property Atividades As List(Of clsAtividadesGrafico)
End Class


Public Class clsAtividadesGrafico
    Public Sub New(idAtividade As Integer, descricaoAtividade As String)
        Me.IdAtividade = idAtividade
        Me.DescricaoAtividade = descricaoAtividade
    End Sub

    Public Property IdAtividade As Integer

    Public Property DescricaoAtividade As String

    Public Property TotalHoras As TimeSpan

    Public Function RetornaPercentual(total As TimeSpan) As Double
        Return calculaPercentual(clsTools.funRetornaMinutos(Me.TotalHoras), clsTools.funRetornaMinutos(total))
    End Function

    Private Function calculaPercentual(pvalor As Double, total As Double) As Double
        Return Math.Round(((pvalor / total) * 100), 2)
    End Function

End Class
