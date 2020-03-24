Public Class clsControlePonto
    Public Sub Gravar(pPonto As clsPonto)
        Dim controle As New clsControlePontoDAO

        subValidaPonto(pPonto)

        controle.Gravar(pPonto)
    End Sub


    Public Sub subValidaPonto(pPonto As clsPonto)

        If DateDiff("d", CDate("01/01/1900"), pPonto.dataPonto) < 0 Then
            Throw New Exception("Data Inválida.")
        End If

    End Sub


    Public Function CarregaPonto(pPonto As clsPonto) As clsPonto
        Return New clsControlePontoDAO().CarregaPonto(pPonto)
    End Function
End Class
