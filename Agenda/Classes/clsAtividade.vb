Public Class clsAtividade
    Public Sub New(iD As Long, data As Date, tipo As String, codigo As Integer, horas As String, descricao As String)
        Me.ID = iD
        Me.Data = data
        Me.Tipo = tipo
        Me.Codigo = codigo
        Me.Horas = horas
        Me.Descricao = descricao
    End Sub
    Public Sub New()
    End Sub

    Public Property ID As Long
    Public Property Data As Date
    Public Property Tipo As String
    Public Property Codigo As Integer
    Public Property Horas As String
    Public Property Descricao As String
End Class
