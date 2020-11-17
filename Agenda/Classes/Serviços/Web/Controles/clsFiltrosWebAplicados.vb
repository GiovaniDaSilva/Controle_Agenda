Public Class clsFiltrosWebAplicados
    Private Shared Property _home As clsParametrosFiltroWeb

    Private Shared _impressaoAtividades As clsFiltroAtividades

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


    Public Shared Function ImpressaoAtividades() As clsFiltroAtividades
        If _impressaoAtividades Is Nothing Then
            Return New clsFiltroAtividades
        End If

        Return _impressaoAtividades
    End Function

    Public Shared Sub SetImpressaoAtividades(filtros As clsFiltroAtividades)
        _impressaoAtividades = filtros
    End Sub


End Class
