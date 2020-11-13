Public Class clsFiltrosWebAplicados
    Private Shared Property _home As clsParametrosFiltroWeb

    Private Sub New()
    End Sub

    Public Shared Function Home() As clsParametrosFiltroWeb
        If _home Is Nothing Then
            Return New clsParametrosFiltroWeb
        End If

        Return _home
    End Function

    Public Shared Sub SetHome(filtros As clsParametrosFiltroWeb)
        _home = filtros
    End Sub


End Class
