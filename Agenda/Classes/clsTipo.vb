Public Class clsTipo
    Public Property ID As Integer 
    Public Property CODIGO As Integer 
    Public Property DESCRICAO As string

    Public sub New()
    End sub

    Public Sub New(iD As Integer, cODIGO As Integer, dESCRICAO As String)
        Me.ID = iD
        Me.CODIGO = cODIGO
        Me.DESCRICAO = dESCRICAO
    End Sub
End Class
