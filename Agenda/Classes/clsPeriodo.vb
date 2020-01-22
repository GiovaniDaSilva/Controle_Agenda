Public Class clsPeriodo
    Public Sub New(iD_Atividade As Integer, hora_Inicial As String, hora_Final As String, total As String)        
        Me.ID_Atividade = iD_Atividade
        Me.Hora_Inicial = hora_Inicial
        Me.Hora_Final = hora_Final
        Me.Total = total
    End Sub

    Public sub New()
    End sub

    Public Property ID As Integer 
    Public Property ID_Atividade As Integer 
    Public Property Hora_Inicial As String
    Public Property Hora_Final As string
    Public Property Total As string    
End Class
