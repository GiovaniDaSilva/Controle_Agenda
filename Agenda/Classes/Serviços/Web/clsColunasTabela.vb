Public Class clsColunasTabela
    Public Property dado As String
    Public Property classe As String
    Public Property estilo As String


    Public Sub New(pDado As String, Optional pClasse As String = vbNullString, Optional pEstilo As String = vbNullString)
        dado = pDado
        classe = pClasse
        estilo = pEstilo
    End Sub


End Class
