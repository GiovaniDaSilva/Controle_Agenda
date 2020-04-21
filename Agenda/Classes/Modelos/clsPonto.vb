Public Class clsPonto

    Public Property id_Ponto As Integer
    Public Property dataPonto As String
    Public Property horaTotal As String
    Public Property horaEntrada As String
    Public Property horaSaida As String
    Public Property observacao As String

    Public Property Periodo As List(Of clsPeriodoPonto)

End Class

Public Class clsPeriodoPonto
    Public Property ID As String
    Public Property Entrada As String
    Public Property Saida As String
    Public Property Total As String

End Class
