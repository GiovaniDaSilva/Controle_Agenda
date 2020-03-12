
Public Class clsVerificacoesTimerGeral


    Public Sub ExecutaValidacoes()
        ExecutaBackupBase()
    End Sub



    ''' <summary>
    ''' Executa o backup da base de dados, quando a data do backup for anterir a data atual
    ''' </summary>
    Private Sub ExecutaBackupBase()
        Dim dataUltbackup As Date

        dataUltbackup = clsRegistro.RetornaDatabackup()

        If DateDiff("d", Now, dataUltbackup) < 0 Then
            MsgBox("Executa backup", vbInformation)
        End If

    End Sub
End Class
